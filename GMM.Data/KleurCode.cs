using System.Collections.Generic;

namespace GMM.Data
{
    public class KleurCode
    {
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public string Code { get; set; }

        public ICollection<Band> Bands { get; set; }
    }
}
