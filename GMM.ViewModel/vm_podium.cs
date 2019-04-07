using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IPodium
    {
        List<Podium> GetAll();
        void GetPodiumById(int pPodiumId);
        int Save();
    }

    public class vm_podium : IPodium
    {
        private GmmDbContext _context;
        private Podium _podium;

        public vm_podium(GmmDbContext pContext)
        {
            _context = pContext;
            _podium = new Podium { Id = 0 };
        }

        public int Id { get { return _podium.Id; } set { _podium.Id = value; } }
        public string Omschrijving { get { return _podium.Omschrijving; } set { _podium.Omschrijving = value; } }

        public List<Podium> GetAll()
        {
            return _context.Podia.ToList();
        }

        public void GetPodiumById(int pPodiumIdId)
        {
            _podium = (_context.Podia.Where(b => b.Id == pPodiumIdId).SingleOrDefault());
        }

        public int Save()
        {
            _context.Podia.Update(_podium);
            return _context.SaveChanges();
        }
    }
}
