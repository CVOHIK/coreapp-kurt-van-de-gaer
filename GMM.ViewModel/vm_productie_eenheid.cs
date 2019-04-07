using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IProductieEenheid
    {
        List<ProductieEenheid> GetAll();
        void GetProductieEenheidById(int pProductieEenheidId);
        int Save();
    }

    public class vm_productie_eenheid : IProductieEenheid
    {
        private GmmDbContext _context;
        private ProductieEenheid _productieEenheid;

        public vm_productie_eenheid(GmmDbContext pContext)
        {
            _context = pContext;
            _productieEenheid = new ProductieEenheid { Id = 0 };
        }

        public int Id { get { return _productieEenheid.Id; } set { _productieEenheid.Id = value; } }
        public string Omschrijving { get { return _productieEenheid.Omschrijving; } set { _productieEenheid.Omschrijving = value; } }

        public List<ProductieEenheid> GetAll()
        {
            return _context.ProductieEenheden.ToList();
        }

        public void GetProductieEenheidById(int pProductieEenheidIdId)
        {
            _productieEenheid = (_context.ProductieEenheden.Where(b => b.Id == pProductieEenheidIdId).SingleOrDefault());
        }

        public int Save()
        {
            _context.ProductieEenheden.Update(_productieEenheid);
            return _context.SaveChanges();
        }
    }
}
