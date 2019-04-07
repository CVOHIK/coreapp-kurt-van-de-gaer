using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IKleurCode
    {
        List<KleurCode> GetAll();
        void GetKleurcodeById(int pKleurcodeId);
        int Save();
    }

    public class vm_kleurcode : IKleurCode
    {
        private GmmDbContext _context;
        private KleurCode _kleurCode;

        public vm_kleurcode(GmmDbContext pContext)
        {
            _context = pContext;
            _kleurCode = new KleurCode { Id = 0 };
        }

        public int Id { get { return _kleurCode.Id; } set { _kleurCode.Id = value; } }
        public string Omschrijving { get { return _kleurCode.Omschrijving; } set { _kleurCode.Omschrijving = value; } }
        public string Code { get { return _kleurCode.Code; } set { _kleurCode.Code = value; } }

        public List<KleurCode> GetAll()
        {
            return _context.KleurCodes.ToList();
        }

        public void GetKleurcodeById(int pKleurcodeId)
        {
            _kleurCode = (_context.KleurCodes.Where(k => k.Id == pKleurcodeId).SingleOrDefault());
        }

        public int Save()
        {
            _context.KleurCodes.Update(_kleurCode);
            return _context.SaveChanges();
        }
    }
}
