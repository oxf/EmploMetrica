﻿using EmploMetrica.Domain.Departments;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploMetrica.Domain.Companies
{

    [Table("Company")]
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Department> Departments { get; set; }
    }
}
