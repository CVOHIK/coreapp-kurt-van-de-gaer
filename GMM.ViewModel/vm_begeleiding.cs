using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IBegeleiding
    {
        List<Begeleiding> GetAll();
        void GetBegeleiderById(int pBegeleidingId);
        int Save();
    }

    public class vm_begeleiding : IBegeleiding
    {
        private GmmDbContext _context;
        private Begeleiding _begeleiding;

        public vm_begeleiding(GmmDbContext pContext)
        {
            _context = pContext;
            _begeleiding = new Begeleiding { Id = 0, BoekingId = 0, FunctieId = 3, WalkieTalkie = false };
        }

        public vm_begeleiding(GmmDbContext pContext, Begeleiding pBegeleiding) : this(pContext)
        {
            _begeleiding = pBegeleiding;
        }

        public int Id { get {return _begeleiding.Id; } set { _begeleiding.Id = value; } }
        public int BoekingId { get { return _begeleiding.BoekingId; } set { _begeleiding.BoekingId = value; } }
        public string Omschrijving { get { return _begeleiding.Omschrijving; } set { _begeleiding.Omschrijving = value; } }
        public int FunctieId { get { return _begeleiding.FunctieId; } set { _begeleiding.FunctieId = value; } }
        public string Email { get { return _begeleiding.Email; } set { _begeleiding.Email = value; } }
        public string Gsm { get { return _begeleiding.Gsm; } set { _begeleiding.Gsm = value; } }
        public bool WalkieTalkie { get { return _begeleiding.WalkieTalkie; } set { _begeleiding.WalkieTalkie = value; } }

        public List<Begeleiding> GetAll()
        {
            return _context.Begeleiders.ToList();
        }

        public void GetBegeleiderById(int pBegeleidingId)
        {
            _begeleiding = (_context.Begeleiders.Where(b => b.Id == pBegeleidingId).SingleOrDefault());
        }

        public int Save()
        {
            _context.Begeleiders.Update(_begeleiding);
            return _context.SaveChanges();
        }
    }
}
