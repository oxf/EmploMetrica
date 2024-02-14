using EmploMetrica.Application.UseCases.Departments;
using EmploMetrica.Domain.Departments;
using Microsoft.AspNetCore.Mvc;

namespace EmploMetrica.API.Controllers
{
    [ApiController]
    [Route("Company")]
    public class DepartmentController(DepartmentService _departmentService) : ControllerBase
    {
        [HttpGet("{CompanyId}/department/")]
        public IActionResult Get(int CompanyId)
        {
            var value = _departmentService.Get(CompanyId);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }

        [HttpGet("{CompanyId}/department/{Id}")]
        public IActionResult GetById(int CompanyId, int Id)
        {
            var value = _departmentService.GetById(CompanyId, Id);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }

        [HttpPost("{CompanyId}/department")]
        public IActionResult Post(int CompanyId, [FromBody] CreateDepartmentDTO departmentDto)
        {
            var value = _departmentService.Create(CompanyId, departmentDto);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }

        [HttpPut("{CompanyId}/department/{Id}")]
        public IActionResult Put(int CompanyId, int Id, [FromBody] UpdateDepartmentDTO updateDepartmentDto)
        {
            var value = _departmentService.Edit(CompanyId, Id, updateDepartmentDto);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }

        [HttpDelete("{CompanyId}/department/{Id}")]
        public IActionResult Delete(int CompanyId, int Id)
        {
            var value = _departmentService.Delete(CompanyId, Id);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }
    }
}
