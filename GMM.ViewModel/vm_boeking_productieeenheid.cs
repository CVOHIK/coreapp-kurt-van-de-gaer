using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IBoekingProductieEenheid
    {
        List<BoekingProductieEenheid> GetAll();
        void GetBoekingProductieEenheidById(int pBoekingProductieEenheidId);
        int Save();
    }

    public class vm_boeking_productieeenheid : IBoekingProductieEenheid
    {
        private GmmDbContext _context;
        private BoekingProductieEenheid _boekingProductieEenheid;

        public vm_boeking_productieeenheid(GmmDbContext pContext)
        {
            _context = pContext;
            _boekingProductieEenheid = new BoekingProductieEenheid { Id = 0, BoekingId = 0, ProductieEenheidId = 0 };
        }

        public vm_boeking_productieeenheid(GmmDbContext pContext, BoekingProductieEenheid pProductieEenheid) : this(pContext)
        {
            _boekingProductieEenheid = pProductieEenheid;
        }

        public int Id { get { return _boekingProductieEenheid.Id; } set { _boekingProductieEenheid.Id = value; } }
        public int BoekingId { get { return _boekingProductieEenheid.BoekingId; } set { _boekingProductieEenheid.BoekingId = value; } }
        public int ProductieEenheidId { get { return _boekingProductieEenheid.ProductieEenheidId; } set { _boekingProductieEenheid.ProductieEenheidId = value; } }
        public string ProductieEenheid { get { vm_productie_eenheid pe = new vm_productie_eenheid(_context); pe.GetProductieEenheidById(ProductieEenheidId); return pe.Omschrijving; } }

        public List<BoekingProductieEenheid> GetAll()
        {
            return _context.BoekingProductieEenheden.ToList();
        }

        public void GetBoekingProductieEenheidById(int pBoekingProductieEenheidId)
        {
            _boekingProductieEenheid = (_context.BoekingProductieEenheden.Where(b => b.Id == pBoekingProductieEenheidId).SingleOrDefault());
        }

        public int Save()
        {
            _context.BoekingProductieEenheden.Update(_boekingProductieEenheid);
            return _context.SaveChanges();
        }
    }
}
