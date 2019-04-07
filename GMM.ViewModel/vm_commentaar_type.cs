using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface ICommentaarType
    {
        List<CommentaarType> GetAll();
        void GetCommentaarTypeById(int pCommentaarTypeId);
        int Save();
    }

    public class vm_commentaar_type : ICommentaarType
    {
        private GmmDbContext _context;
        private CommentaarType _commentaarType;

        public vm_commentaar_type(GmmDbContext pContext)
        {
            _context = pContext;
            _commentaarType = new CommentaarType { Id = 0 };
        }

        public int Id { get { return _commentaarType.Id; } set { _commentaarType.Id = value; } }
        public string Omschrijving { get { return _commentaarType.Omschrijving; } set { _commentaarType.Omschrijving = value; } }

        public List<CommentaarType> GetAll()
        {
            return _context.CommentaarTypes.ToList();
        }

        public void GetCommentaarTypeById(int pCommentaarTypeIdId)
        {
            _commentaarType = (_context.CommentaarTypes.Where(b => b.Id == pCommentaarTypeIdId).SingleOrDefault());
        }

        public int Save()
        {
            _context.CommentaarTypes.Update(_commentaarType);
            return _context.SaveChanges();
        }
    }
}
