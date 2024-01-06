using EmploMetrica.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Domain.Checks
{
    public class Check
    {
        public Guid Id { get; set; }
        public Card Card { get; set; }
        public DateTime DateTime { get; set; }
    }
}
