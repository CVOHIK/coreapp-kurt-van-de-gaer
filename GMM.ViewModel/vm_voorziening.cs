using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IVoorziening
    {
        List<Voorziening> GetAll();
        void GetVoorzieningById(int pVoorzieningId);
        int Save();
    }

    public class vm_voorziening : IVoorziening
    {
        private GmmDbContext _context;
        private Voorziening _voorziening;

        public vm_voorziening(GmmDbContext pContext)
        {
            _context = pContext;
            _voorziening = new Voorziening { Id = 0, BoekingId = 0, BusStock = 0, CoolersBand = 0, CoolersGmm = 0, Kinesist = false, Runner = 0, V110 = 0, Wasserij = false, Zuurstof = 0 };
        }

        public int Id { get { return _voorziening.Id; } set { _voorziening.Id = value; } }
        public int BoekingId { get { return _voorziening.BoekingId; } set { _voorziening.BoekingId = value; } }
        public string Arts { get { return _voorziening.Arts; } set { _voorziening.Arts = value; } }
        public int? BusStock { get { return _voorziening.BusStock; } set { _voorziening.BusStock = value; } }
        public int? CoolersBand { get { return _voorziening.CoolersBand; } set { _voorziening.CoolersBand = value; } }
        public int? CoolersGmm { get { return _voorziening.CoolersGmm; } set { _voorziening.CoolersGmm = value; } }
        public int? Runner { get { return _voorziening.Runner; } set { _voorziening.Runner = value; } }
        public int? V110 { get { return _voorziening.V110; } set { _voorziening.V110 = value; } }
        public int? Zuurstof { get { return _voorziening.Zuurstof; } set { _voorziening.Zuurstof = value; } }
        public bool Kinesist { get { return _voorziening.Kinesist; } set { _voorziening.Kinesist = value; } }
        public bool Wasserij { get { return _voorziening.Wasserij; } set { _voorziening.Wasserij = value; } }

        public List<Voorziening> GetAll()
        {
            return _context.Voorzieningen.ToList();
        }

        public void GetVoorzieningById(int pVoorzieningIdId)
        {
            _voorziening = (_context.Voorzieningen.Where(b => b.Id == pVoorzieningIdId).SingleOrDefault());
        }

        public int Save()
        {
            _context.Voorzieningen.Update(_voorziening);
            return _context.SaveChanges();
        }
    }
}
