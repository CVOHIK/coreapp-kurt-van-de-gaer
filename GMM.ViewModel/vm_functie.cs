using GMM.Data;
using System.Collections.Generic;
using System.Linq;

namespace GMM.ViewModel
{
    public interface IFunctie
    {
        List<Functie> GetAll();
        void GetFunctieById(int pFunctieId);
        int Save();
    }

    public class vm_functie : IFunctie
    {
        private GmmDbContext _context;
        private Functie _functie;

        public vm_functie(GmmDbContext pContext)
        {
            _context = pContext;
            _functie = new Functie { Id = 0 };
        }

        public int Id { get { return _functie.Id; } set { _functie.Id = value; } }
        public string Omschrijving { get { return _functie.Omschrijving; } set { _functie.Omschrijving = value; } }

        public List<Functie> GetAll()
        {
            return _context.Functies.ToList();
        }

        public void GetFunctieById(int pFunctieIdId)
        {
            _functie = (_context.Functies.Where(b => b.Id == pFunctieIdId).SingleOrDefault());
        }

        public int Save()
        {
            _context.Functies.Update(_functie);
            return _context.SaveChanges();
        }
    }
}
