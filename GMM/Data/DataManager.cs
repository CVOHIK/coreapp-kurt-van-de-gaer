using GMM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMM.Data
{
    public class DataManager
    {
        private GmmDbContext _context;

        public DataManager(GmmDbContext context)
        {
            _context = context;
        }

        public List<Podium> GetAllPodia()
        {
            List<Podium> podia = new List<Podium>();

            podia.Add(new Podium() { Id = 0, Omschrijving = "Kies..." });

            foreach(Podium item in _context.Podia.OrderBy(p => p.Omschrijving))
            {
                podia.Add(item);
            }

            return podia;
        }

        public List<Tent> GetAllTenten()
        {
            List<Tent> tenten = new List<Tent>();

            tenten.Add(new Tent() { Id = 0, Omschrijving = "Kies..." });

            foreach (Tent item in _context.Tenten.OrderBy(t => t.Omschrijving))
            {
                tenten.Add(item);
            }

            return tenten;
        }

        public List<Kleedkamer> GetAllKleedkamers()
        {
            List<Kleedkamer> Kleedkamers = new List<Kleedkamer>();

            Kleedkamers.Add(new Kleedkamer() { Id = 0, Omschrijving = "Kies..." });

            foreach (Kleedkamer item in _context.Kleedkamers.OrderBy(p => p.Omschrijving))
            {
                Kleedkamers.Add(item);
            }

            return Kleedkamers;
        }

        public List<ProductieEenheid> GetAllProductieEenheden()
        {
            List<ProductieEenheid> productieEenheden = new List<ProductieEenheid>();

            productieEenheden.Add(new ProductieEenheid() { Id = 0, Omschrijving = "Kies..." });

            foreach (ProductieEenheid item in _context.ProductieEenheden.OrderBy(p => p.Omschrijving))
            {
                productieEenheden.Add(item);
            }

            return productieEenheden;
        }

        public List<Begeleiding> GetAllBegeleiders()
        {
            int ctr = 0;
            List<Begeleiding> begeleiders = new List<Begeleiding>();
            List<string> preList = new List<string>();

            begeleiders.Add(new Begeleiding() { Id = ctr, Omschrijving = "Kies..." });

            foreach (Begeleiding item in _context.Begeleiders.Where(b => b.FunctieId == 3).OrderBy(b => b.Omschrijving))
            {
                if (!preList.Contains(item.Omschrijving)) preList.Add(item.Omschrijving);
            }

            foreach (string item in preList)
            {
                begeleiders.Add(new Begeleiding() { Id = ctr, Omschrijving = item});
            }

            return begeleiders;
        }
    }
}


//Carolien Luyts
//Gilles Dresselaars
//Helga Castelijns
//Ingrid Engelen
//Jolien Melis
//Jurgen Van Overmeire
//Koen klaasen
//Liesbeth Huber
//Melissa Vanendert
//Michele Damen
//Muriel Delens
//Nele Knockaert
//Petra Lakiere
//Rob Theunis
//Steve Demare