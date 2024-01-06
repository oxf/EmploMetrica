using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Domain.Entity
{
    public class Check
    {
        public Guid Id { get; set; }
        public Card Card { get; set; }
        public DateTime DateTime { get; set; }
    }
}
