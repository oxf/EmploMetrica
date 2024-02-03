using EmploMetrica.Domain.Companies;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploMetrica.Domain.Departments
{
    public class UpdateDepartmentDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
