using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface ICatering
    {
        List<Catering> GetAll();
        void GetCateringById(int pCateringId);
        int Save();
    }

    public class vm_catering : ICatering
    {
        private GmmDbContext _context;
        private Catering _catering;

        public vm_catering(GmmDbContext pContext)
        {
            _context = pContext;
            _catering = new Catering { Id = 0, AfterShow = false, BoekingId = 0, Special = false, TakeAwayFood = false };
        }

        public int Id { get { return _catering.Id; } set { _catering.Id = value; } }
        public bool AfterShow { get { return _catering.AfterShow; } set { _catering.AfterShow = value; } }
        public int BoekingId { get { return _catering.BoekingId; } set { _catering.BoekingId = value; } }
        public string Optie1 { get { return _catering.Optie1; } set { _catering.Optie1 = value; } }
        public string Optie1Waarde { get { return _catering.Optie1Waarde; } set { _catering.Optie1Waarde = value; } }
        public string Optie2 { get { return _catering.Optie2; } set { _catering.Optie2 = value; } }
        public string Optie2Waarde { get { return _catering.Optie2Waarde; } set { _catering.Optie2Waarde = value; } }
        public bool Special { get { return _catering.Special; } set { _catering.Special = value; } }
        public bool TakeAwayFood { get { return _catering.TakeAwayFood; } set { _catering.TakeAwayFood = value; } }

        public List<Catering> GetAll()
        {
            return _context.Caterings.ToList();
        }

        public void GetCateringById(int pCateringId)
        {
            _catering = (_context.Caterings.Where(b => b.Id == pCateringId).SingleOrDefault());
        }

        public int Save()
        {
            _context.Caterings.Update(_catering);
            return _context.SaveChanges();
        }
    }
}
