using System.Collections.Generic;

namespace GMM.Data
{
    public class Kleedkamer
    {
        public int Id { get; set; }
        public string Omschrijving { get; set; }

        public ICollection<BoekingProductieEenheid> BoekingProductieEenheids { get; set; }
    }
}
