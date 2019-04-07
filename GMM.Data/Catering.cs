namespace GMM.Data
{
    public class Catering
    {
        public int Id { get; set; }
        public int BoekingId { get; set; }
        public bool AfterShow { get; set; }
        public bool Special { get; set; }
        public bool TakeAwayFood { get; set; }
        public string Optie1 { get; set; }
        public string Optie1Waarde { get; set; }
        public string Optie2 { get; set; }
        public string Optie2Waarde { get; set; }

        public Boeking Boeking { get; set; }
    }
}
