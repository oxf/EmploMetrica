using EmploMetrica.Domain.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Domain.Employees
{
    public class Employee
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
