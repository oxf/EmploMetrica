using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Domain.Entity
{
    public class Card
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; }
        public bool IsValid { get; set; }
    }
}
