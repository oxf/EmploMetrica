using AutoMapper;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace EmploMetrica.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController(AppDbContext _db, IMapper _mapper) : ControllerBase
    {
        // GET: /Company/
        [HttpGet]
        public ActionResult<IEnumerable<GetCompanyDTO>> Get()
        {
            return Ok(_db.CompanyDbSet.Select(x => _mapper.Map<GetCompanyDTO>(x)).ToList());
        }

        // GET: /Company/{id}
        [HttpGet("{id}")]
        public ActionResult<GetCompanyDTO> GetById(int id)
        {
            var company = _mapper.Map<GetCompanyDTO>(_db.CompanyDbSet.Find(id));
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        // POST: /Company
        [HttpPost]
        public ActionResult<GetCompanyDTO> Post([FromBody] CreateCompanyDTO companyDto)
        {
            Company company = _mapper.Map<Company>(companyDto);
            _db.CompanyDbSet.Add(company);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = company.Id }, _mapper.Map<GetCompanyDTO>(company));
        }

        // PUT: /Company/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Company updatedCompany)
        {
            var company = _db.CompanyDbSet.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            company.Name = updatedCompany.Name;
            company.IsActive = updatedCompany.IsActive;

            _db.SaveChanges();
            return NoContent();
        }

        // DELETE: /Company/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = _db.CompanyDbSet.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            _db.CompanyDbSet.Remove(company);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
