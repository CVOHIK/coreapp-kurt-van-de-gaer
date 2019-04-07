using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IBoekingKleedkamer
    {
        List<BoekingKleedkamer> GetAll();
        void GetBoekingKleedkamerById(int pBoekingKleedkamerId);
        int Save();
    }

    public class vm_boeking_kleedkamer : IBoekingKleedkamer
    {
        private GmmDbContext _context;
        private BoekingKleedkamer _boekingKleedkamer;

        public vm_boeking_kleedkamer(GmmDbContext pContext)
        {
            _context = pContext;
            _boekingKleedkamer = new BoekingKleedkamer { Id = 0, BoekingId = 0, KleedkamerId = 0 };
        }

        public vm_boeking_kleedkamer(GmmDbContext pContext, BoekingKleedkamer pBoekingKleedkamer) : this(pContext)
        {
            _boekingKleedkamer = pBoekingKleedkamer;
        }

        public int Id { get { return _boekingKleedkamer.Id; } set { _boekingKleedkamer.Id = value; } }
        public int BoekingId { get { return _boekingKleedkamer.BoekingId; } set { _boekingKleedkamer.BoekingId = value; } }
        public int KleedkamerId { get { return _boekingKleedkamer.KleedkamerId; } set { _boekingKleedkamer.KleedkamerId = value; } }
        public string Kleedkamer { get { vm_kleedkamer kk = new vm_kleedkamer(_context); kk.GetKleedkamerById(KleedkamerId); return kk.Omschrijving; } }

        public List<BoekingKleedkamer> GetAll()
        {
            return _context.BoekingKleedkamers.ToList();
        }

        public void GetBoekingKleedkamerById(int pBoekingKleedkamerId)
        {
            _boekingKleedkamer = (_context.BoekingKleedkamers.Where(b => b.Id == pBoekingKleedkamerId).SingleOrDefault());
        }

        public int Save()
        {
            _context.BoekingKleedkamers.Update(_boekingKleedkamer);
            return _context.SaveChanges();
        }
    }
}
