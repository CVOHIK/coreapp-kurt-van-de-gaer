namespace GMM.Data
{
    public class Commentaar
    {
        public int Id { get; set; }
        public int BoekingId { get; set; }
        public int CommentaarTypeId { get; set; }
        public string Omschrijving { get; set; }

        public Boeking Boeking { get; set; }
        public CommentaarType CommentaarType { get; set; }
    }
}
