using System.Collections.Generic;

namespace GMM.Data
{
    public class Tent
    {
        public int Id { get; set; }
        public string Omschrijving { get; set; }

        public ICollection<Boeking> Boekingen { get; set; }
    }
}
