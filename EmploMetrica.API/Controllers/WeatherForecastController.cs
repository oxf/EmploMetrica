using EmploMetrica.Domain.Company;
using EmploMetrica.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace EmploMetrica.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController(AppDbContext _db) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _db.CompanyDbSet.ToList();
        }
    }
}
