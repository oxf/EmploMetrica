using AutoMapper;
using EmploMetrica.Application.UseCases.Companies;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Persistence.Contexts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EmploMetrica.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController(CompanyService _companyService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_companyService.Get());
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_companyService.GetById(Id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCompanyDTO companyDto)
        {
            return Ok(_companyService.Post(companyDto));
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] UpdateCompanyDTO updateCompanyDto)
        {
            return Ok(_companyService.Put(Id, updateCompanyDto));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_companyService.Delete(Id));
        }
    }
}
