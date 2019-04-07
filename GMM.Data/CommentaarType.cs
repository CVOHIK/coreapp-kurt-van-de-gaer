using System.Collections.Generic;

namespace GMM.Data
{
    public class CommentaarType
    {
        public int Id { get; set; }
        public string Omschrijving { get; set; }

        public ICollection<Commentaar> Commentaren { get; set; }
    }
}
