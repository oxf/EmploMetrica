using EmploMetrica.Domain.Departments;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploMetrica.Domain.Companies
{

    public class CreateCompanyDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
