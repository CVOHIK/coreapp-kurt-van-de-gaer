using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IBand
    {
        List<Band> GetAll();
        void GetBandById(int pBandId);
        int Save();
    }

    public class vm_band : IBand
    {
        private GmmDbContext _context;
        private Band _band;

        public vm_band(GmmDbContext pContext)
        {
            _context = pContext;
            _band = new Band { Id = 0, KleurCodeId = 4 };
        }

        public int Id { get { return _band.Id; } set { _band.Id = value; } }
        public string Omschrijving { get { return _band.Omschrijving; } set { _band.Omschrijving = value; } }
        public int? KleurCodeId { get { return _band.KleurCodeId; } set { _band.KleurCodeId = value; } }
        public vm_kleurcode KleurCode { get; set; }

        public List<Band> GetAll()
        {
            return _context.Bands.ToList();
        }

        public void GetBandById(int pBandId)
        {
            _band = (_context.Bands.Where(b => b.Id == pBandId).SingleOrDefault());
            KleurCode = new vm_kleurcode(_context);
            KleurCode.GetKleurcodeById((int)_band.KleurCodeId);
        }

        public int Save()
        {
            _context.Bands.Update(_band);
            return _context.SaveChanges();
        }
    }
}
