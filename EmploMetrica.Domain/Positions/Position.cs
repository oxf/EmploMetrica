using EmploMetrica.Domain.Companies;

namespace EmploMetrica.Domain.Positions
{
    public class Position
    {
        public int Id { get; set; }
        public Company Company { get; set; }
    }
}