using AutoMapper;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Departments;
using EmploMetrica.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace EmploMetrica.API.Controllers
{
    [ApiController]
    [Route("Company")]
    public class DepartmentController(AppDbContext _db, IMapper _mapper) : ControllerBase
    {
        // GET: /Department/
        [HttpGet("{CompanyId}/department/")]
        public ActionResult<IEnumerable<GetDepartmentDTO>> Get(int CompanyId)
        {
            return Ok(_db.DepartmentDbSet.Where(x => x.Company.Id == CompanyId)
                .Select(x => _mapper.Map<GetDepartmentDTO>(x))
                .ToList());
        }

        // GET: /Department/{Id}
        [HttpGet("{CompanyId}/department/{Id}")]
        public ActionResult<GetDepartmentDTO> GetById(int CompanyId, int Id)
        {
            var Department = _db.DepartmentDbSet.Where(x => x.Company.Id == CompanyId && x.Id == Id)
                .Select(x => _mapper.Map<GetDepartmentDTO>(x))
                .FirstOrDefault();

            if (Department == null)
            {
                return NotFound();
            }
            return Ok(Department);
        }

        // POST: /Department
        [HttpPost("{CompanyId}/department")]
        public ActionResult<GetDepartmentDTO> Post([FromBody] CreateDepartmentDTO DepartmentDto, int CompanyId)
        {
            Department Department = _mapper.Map<Department>(DepartmentDto);

            Company company = _db.CompanyDbSet.Find(CompanyId);
            if (company == null)
            {
                return NotFound("Company Not Found");
            }
            Department.Company = company;
            _db.DepartmentDbSet.Add(Department);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { Id = Department.Id, CompanyId = company.Id }, _mapper.Map<GetDepartmentDTO>(Department));
        }

        // PUT: /Department/{Id}
        [HttpPut("{CompanyId}/department/{Id}")]
        public IActionResult Put(int CompanyId, int Id, [FromBody] Department updatedDepartment)
        {
            Company company = _db.CompanyDbSet.Find(CompanyId);
            if (company == null)
            {
                return NotFound();
            }
            var Department = _db.DepartmentDbSet.Find(Id);
            if (Department == null)
            {
                return NotFound();
            }

            Department.Name = updatedDepartment.Name;
            Department.IsActive = updatedDepartment.IsActive;

            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{CompanyId}/department/{Id}")]
        public IActionResult Delete(int Id)
        {
            var Department = _db.DepartmentDbSet.Find(Id);
            if (Department == null)
            {
                return NotFound();
            }

            _db.DepartmentDbSet.Remove(Department);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
