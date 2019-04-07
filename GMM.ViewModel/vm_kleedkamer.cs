using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IKleedkamer
    {
        List<Kleedkamer> GetAll();
        void GetKleedkamerById(int pKleedkamerId);
        int Save();
    }

    public class vm_kleedkamer : IKleedkamer
    {
        private GmmDbContext _context;
        private Kleedkamer _kleedkamer;

        public vm_kleedkamer(GmmDbContext pContext)
        {
            _context = pContext;
            _kleedkamer = new Kleedkamer { Id = 0 };
        }

        public int Id { get { return _kleedkamer.Id; } set { _kleedkamer.Id = value; } }
        public string Omschrijving { get { return _kleedkamer.Omschrijving; } set { _kleedkamer.Omschrijving = value; } }

        public List<Kleedkamer> GetAll()
        {
            return _context.Kleedkamers.ToList();
        }

        public void GetKleedkamerById(int pKleedkamerIdId)
        {
            _kleedkamer = (_context.Kleedkamers.Where(b => b.Id == pKleedkamerIdId).SingleOrDefault());
        }

        public int Save()
        {
            _context.Kleedkamers.Update(_kleedkamer);
            return _context.SaveChanges();
        }
    }
}
