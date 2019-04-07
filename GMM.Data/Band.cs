using System.Collections.Generic;

namespace GMM.Data
{
    /*
    Comment of TOM PEETERS 
    */
    public class Band
    {
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public int? KleurCodeId { get; set; }

        public KleurCode KleurCode { get; set; }

        public ICollection<Boeking> Boekingen { get; set; }
    }
}
