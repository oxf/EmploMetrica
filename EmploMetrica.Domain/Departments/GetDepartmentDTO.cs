using EmploMetrica.Domain.Companies;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploMetrica.Domain.Departments
{
    public class GetDepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
