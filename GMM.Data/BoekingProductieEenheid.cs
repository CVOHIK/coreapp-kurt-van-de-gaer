using System;

namespace GMM.Data
{
    public class BoekingProductieEenheid
    {
        public int Id { get; set; }
        public int BoekingId { get; set; }
        public int ProductieEenheidId { get; set; }

        public Boeking Boeking { get; set; }
        public ProductieEenheid ProductieEenheid { get; set; }
    }
}
