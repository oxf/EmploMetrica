using System.ComponentModel.DataAnnotations.Schema;

namespace EmploMetrica.Domain.Entity;

[Table("Company")]
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
