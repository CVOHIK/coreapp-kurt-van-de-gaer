namespace GMM.Data
{
    public class Begeleiding
    {
        public int Id { get; set; }
        public int BoekingId { get; set; }
        public string Omschrijving { get; set; }
        public int FunctieId { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public bool WalkieTalkie { get; set; }

        public Boeking Boeking { get; set; }
        public Functie Functie { get; set; }
    }
}
