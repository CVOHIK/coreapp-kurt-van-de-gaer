using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface ITent
    {
        List<Tent> GetAll();
        void GetTentById(int pTentId);
        int Save();
    }

    public class vm_tent : ITent
    {
        private GmmDbContext _context;
        private Tent _tent;

        public vm_tent(GmmDbContext pContext)
        {
            _context = pContext;
            _tent = new Tent { Id = 0 };
        }

        public int Id { get { return _tent.Id; } set { _tent.Id = value; } }
        public string Omschrijving { get { return _tent.Omschrijving; } set { _tent.Omschrijving = value; } }

        public List<Tent> GetAll()
        {
            return _context.Tenten.ToList();
        }

        public void GetTentById(int pTentIdId)
        {
            _tent = (_context.Tenten.Where(b => b.Id == pTentIdId).SingleOrDefault());
        }

        public int Save()
        {
            _context.Tenten.Update(_tent);
            return _context.SaveChanges();
        }
    }
}
