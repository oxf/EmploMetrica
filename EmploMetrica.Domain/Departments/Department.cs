using EmploMetrica.Domain.Companies;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploMetrica.Domain.Departments
{

    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Company Company { get; set; }
    }
}
