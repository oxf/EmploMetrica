using AutoMapper;
using EmploMetrica.Application.UseCases.Companies;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Persistence.Contexts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EmploMetrica.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController(CompanyService _companyService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var value = _companyService.Get();
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var value = _companyService.GetById(Id);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCompanyDTO companyDto)
        {
            var value = _companyService.Create(companyDto);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] UpdateCompanyDTO updateCompanyDto)
        {
            var value = _companyService.Edit(Id, updateCompanyDto);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _companyService.Delete(Id);
            return value.Success ? base.Ok(value.Data) : BadRequest(value.Errors);
        }
    }
}
