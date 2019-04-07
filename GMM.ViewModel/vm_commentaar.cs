using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface ICommentaar
    {
        List<Commentaar> GetAll();
        void GetCommentaarById(int pCommentaarId);
        void GetCommentaarByBoekingIdAndType(int pBoekingId, int pCommentaarTypeId);
        int Save();
    }

    public class vm_commentaar : ICommentaar
    {
        private GmmDbContext _context;
        private Commentaar _commentaar;

        public vm_commentaar(GmmDbContext pContext)
        {
            _context = pContext;
            _commentaar = new Commentaar { Id = 0, BoekingId = 0, CommentaarTypeId = 0 };
        }

        public vm_commentaar(GmmDbContext pContext, Commentaar pCommentaar) : this(pContext)
        {
            _commentaar = pCommentaar;
        }

        public int Id { get { return _commentaar.Id; } set { _commentaar.Id = value; } }
        public int BoekingId { get { return _commentaar.BoekingId; } set { _commentaar.BoekingId = value; } }
        public int CommentaarTypeId { get { return _commentaar.CommentaarTypeId; } set { _commentaar.CommentaarTypeId = value; } }
        public string Omschrijving { get { return _commentaar.Omschrijving; } set { _commentaar.Omschrijving = value; } }

        public List<Commentaar> GetAll()
        {
            return _context.Commentaren.ToList();
        }

        public void GetCommentaarById(int pCommentaarId)
        {
            _commentaar = (_context.Commentaren.Where(c => c.Id == pCommentaarId).SingleOrDefault());
            if (_commentaar == null) _commentaar = new Commentaar { Id = 0, BoekingId = 0, CommentaarTypeId = 0 };
        }

        public void GetCommentaarByBoekingIdAndType(int pBoekingId, int pCommentaarTypeId)
        {
            _commentaar = (_context.Commentaren.Where(c => c.BoekingId == pBoekingId && c.CommentaarTypeId == pCommentaarTypeId).SingleOrDefault());
            if (_commentaar == null) _commentaar = new Commentaar { Id = 0, BoekingId = 0, CommentaarTypeId = 0 };
        }

        public int Save()
        {
            _context.Commentaren.Update(_commentaar);
            return _context.SaveChanges();
        }
    }
}
