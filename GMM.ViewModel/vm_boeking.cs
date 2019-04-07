using GMM.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GMM.ViewModel
{
    public interface IBoeking
    {
        List<Boeking> GetAll();
        void GetBoekingById(int pBoekingId);
        int Save();
    }

    public class vm_boeking : IBoeking
    {
        private GmmDbContext _context;
        private Boeking _boeking;

        public vm_boeking(GmmDbContext pContext)
        {
            _context = pContext;
            _boeking = new Boeking { Id = 0, BandId = 0, Datum = DateTime.Today, BeginUur = DateTime.Now, EindUur = DateTime.Now.AddHours(2), PodiumId = 0 };

            Band = new vm_band(_context);
            KleurCode = new vm_kleurcode(_context);
            Podium = new vm_podium(_context);
            Tent = new vm_tent(_context);
            Tourmanager = new vm_begeleiding(_context) { BoekingId = Id, FunctieId = 1 };
            ProductieManager = new vm_begeleiding(_context) { BoekingId = Id, FunctieId = 2 };
            Catering = new vm_catering(_context);
            CateringCommentaren = new vm_commentaar(_context);
            Voorzieningen = new vm_voorziening(_context);
            VoorzieningCommentaren = new vm_commentaar(_context);
        }

        public BoekingModel BoekingModel { get; set; } = new BoekingModel()
        {
            VoorzieningenBusStock = 0,
            VoorzieningenCoolersBand = 0,
            VoorzieningenCoolersGmm = 0,
            VoorzieningenRunner = 0,
            VoorzieningenV110 = 0,
            VoorzieningenZuurstof = 0,
        };

        public int Id { get { return BoekingModel.Id; } set { BoekingModel.Id = value; } }
        public int BandId { get { return BoekingModel.BandId; } set { BoekingModel.BandId = value; Band.GetBandById(value); BoekingModel.BandNaam = Band.Omschrijving; KleurCode.GetKleurcodeById((int)Band.KleurCodeId); BoekingModel.KleurCode = KleurCode.Code; } }
        public DateTime Datum { get { return BoekingModel.Datum; } set { BoekingModel.Datum = value; } }
        public DateTime BeginUur { get { return BoekingModel.BeginUur; } set { BoekingModel.BeginUur = value; BoekingModel.EindUur = ((DateTime)BeginUur).AddHours(2); BoekingModel.KleedkamerBeginUur = value; } }
        public int PodiumId { get { return BoekingModel.PodiumId; } set { BoekingModel.PodiumId = value; } }
        
        public vm_band Band { get; set; }
        public vm_podium Podium { get; set; }
        public vm_tent Tent { get; set; }
        public vm_kleurcode KleurCode { get; set; }
        public vm_begeleiding Tourmanager { get; set; }
        public vm_begeleiding ProductieManager { get; set; }
        public List<vm_begeleiding> Begeleiders { get; set; } = new List<vm_begeleiding>();
        public List<vm_boeking_kleedkamer> BoekingKleedkamers { get; set; } = new List<vm_boeking_kleedkamer>();
        public List<vm_boeking_productieeenheid> BoekingProductieEenheden { get; set; } = new List<vm_boeking_productieeenheid>();
        public vm_catering Catering { get; set; }
        public vm_commentaar CateringCommentaren { get; set; }
        public vm_voorziening Voorzieningen { get; set; }
        public vm_commentaar VoorzieningCommentaren { get; set; }

        public List<Boeking> GetAll()
        {
            return _context.Boekingen.Include(b => b.Band).Include(p => p.Podium).ToList();
        }

        public void GetBoekingById(int pBoekingId)
        {
            Begeleiding tourManager;
            Begeleiding productieManager;
            List<Begeleiding> begeleiders;
            List<BoekingKleedkamer> boekingKleedkamers;
            List<BoekingProductieEenheid> boekingProductieEenheden;
            Catering catering;
            Voorziening voorzieningen;

            _boeking = (_context.Boekingen.Where(b => b.Id == pBoekingId).SingleOrDefault());

            Band = new vm_band(_context);
            Band.GetBandById(_boeking.BandId);

            Podium = new vm_podium(_context);
            Podium.GetPodiumById(_boeking.PodiumId);

            Tent = new vm_tent(_context);
            if (_boeking.TentId != null) Tent.GetTentById((int)_boeking.TentId);

            KleurCode.GetKleurcodeById((int)Band.KleurCodeId);

            BoekingModel.Id = _boeking.Id;
            BoekingModel.Datum = _boeking.Datum;
            BoekingModel.BeginUur = _boeking.BeginUur ?? DateTime.Today;
            BoekingModel.EindUur = _boeking.EindUur ?? DateTime.Today;
            BoekingModel.KleedkamerBeginUur = _boeking.KleedkamerBeginUur ?? DateTime.Today;
            BoekingModel.KleedkamerEindUur = _boeking.KleedkamerEindUur ?? DateTime.Today;
            BoekingModel.BandId = Band.Id;
            BoekingModel.BandNaam = Band.Omschrijving;
            BoekingModel.PodiumId = Podium.Id;
            BoekingModel.PodiumNaam = Podium.Omschrijving;
            BoekingModel.TentId = Tent.Id;
            BoekingModel.TentNaam = Tent.Omschrijving;
            BoekingModel.KleurCode = KleurCode.Code;

            // Get kleedkamers
            boekingKleedkamers = _context.BoekingKleedkamers.Include(k => k.Kleedkamer).Where(k => k.BoekingId == Id).ToList();
            if(boekingKleedkamers != null)
            {
                int ctr = 0;
                StringBuilder sb = new StringBuilder();

                foreach(BoekingKleedkamer item in boekingKleedkamers)
                {
                    BoekingKleedkamers.Add(new vm_boeking_kleedkamer(_context, item));
                    switch (ctr)
                    {
                        case 0: BoekingModel.Kleedkamer1 = item.KleedkamerId; break;
                        case 1: BoekingModel.Kleedkamer2 = item.KleedkamerId; break;
                        case 2: BoekingModel.Kleedkamer3 = item.KleedkamerId; break;
                        case 3: BoekingModel.Kleedkamer4 = item.KleedkamerId; break;
                        case 4: BoekingModel.Kleedkamer5 = item.KleedkamerId; break;
                        case 5: BoekingModel.Kleedkamer6 = item.KleedkamerId; break;
                    }

                    if (sb.Length == 0) sb.Append(item.KleedkamerId);
                    else { sb.Append(" - "); sb.Append(item.KleedkamerId); }

                    ctr++;
                }

                BoekingModel.BoekingKleedkamersString = sb.ToString();
            }
            // Get productie eenheden
            boekingProductieEenheden = _context.BoekingProductieEenheden.Include(p => p.ProductieEenheid).Where(p => p.BoekingId == _boeking.Id).ToList();
            if (boekingProductieEenheden != null)
            {
                int ctr = 0;
                StringBuilder sb = new StringBuilder();

                foreach (BoekingProductieEenheid item in boekingProductieEenheden)
                {
                    BoekingProductieEenheden.Add(new vm_boeking_productieeenheid(_context, item));
                    switch (ctr)
                    {
                        case 0: BoekingModel.ProductieEenheid1 = item.ProductieEenheidId; break;
                        case 1: BoekingModel.ProductieEenheid2 = item.ProductieEenheidId; break;
                        case 2: BoekingModel.ProductieEenheid3 = item.ProductieEenheidId; break;
                        case 3: BoekingModel.ProductieEenheid4 = item.ProductieEenheidId; break;
                        case 4: BoekingModel.ProductieEenheid5 = item.ProductieEenheidId; break;
                        case 5: BoekingModel.ProductieEenheid6 = item.ProductieEenheidId; break;
                    }

                    if (sb.Length == 0) sb.Append(item.ProductieEenheidId);
                    else { sb.Append(" - "); sb.Append(item.ProductieEenheidId); }

                    ctr++;
                }

                BoekingModel.BoekingProductieEenhedenString = sb.ToString();
            }

            // Get begeleiders
            tourManager = _context.Begeleiders.Where(b => b.BoekingId == Id && b.FunctieId == 1).SingleOrDefault();
            if (tourManager != null)
            {
                Tourmanager = new vm_begeleiding(_context, tourManager);

                BoekingModel.TourmanagerNaam = Tourmanager.Omschrijving;
                BoekingModel.TourmanagerGsm = Tourmanager.Gsm;
                BoekingModel.TourmanagerEmail = Tourmanager.Email;
                BoekingModel.TourmanagerWalkieTalkie = Tourmanager.WalkieTalkie;
            }


            productieManager = _context.Begeleiders.Where(b => b.BoekingId == Id && b.FunctieId == 2).SingleOrDefault();
            if (productieManager != null)
            {
                ProductieManager = new vm_begeleiding(_context, productieManager);

                BoekingModel.ProductieManagerNaam = ProductieManager.Omschrijving;
                BoekingModel.ProductieManagerGsm = ProductieManager.Gsm;
                BoekingModel.ProductieManagerEmail = ProductieManager.Email;
                BoekingModel.ProductieManagerWalkieTalkie = ProductieManager.WalkieTalkie;
            }

            begeleiders = _context.Begeleiders.Where(b => b.BoekingId == Id && b.FunctieId == 3).ToList();
            if (begeleiders != null)
            {
                int ctr = 0;
                foreach (Begeleiding item in begeleiders)
                {
                    Begeleiders.Add(new vm_begeleiding(_context, item));
                    switch (ctr)
                    {
                        case 0: BoekingModel.Begeleider1 = item.Omschrijving; break;
                        case 1: BoekingModel.Begeleider2 = item.Omschrijving; break;
                        case 2: BoekingModel.Begeleider3 = item.Omschrijving; break;
                        case 3: BoekingModel.Begeleider4 = item.Omschrijving; break;
                        case 4: BoekingModel.Begeleider5 = item.Omschrijving; break;
                        case 5: BoekingModel.Begeleider6 = item.Omschrijving; break;
                    }

                    ctr++;
                }
            }

            // Get catering
            catering = _context.Caterings.Where(c => c.BoekingId == Id).SingleOrDefault();
            if (catering != null)
            {
                Catering.GetCateringById(catering.Id);

                BoekingModel.CateringAfterShow = Catering.AfterShow;
                BoekingModel.CateringOptie1 = Catering.Optie1;
                BoekingModel.CateringOptie1Waarde = Catering.Optie1Waarde;
                BoekingModel.CateringOptie2 = Catering.Optie2;
                BoekingModel.CateringOptie2Waarde = Catering.Optie2Waarde;
                BoekingModel.CateringSpecial = Catering.Special;
                BoekingModel.CateringTakeAwayFood = Catering.TakeAwayFood;
            }

            // Get catering remarks
            CateringCommentaren.GetCommentaarByBoekingIdAndType(pBoekingId, 2);
            BoekingModel.CateringCommentaar = CateringCommentaren.Omschrijving;

            // Get voorzieningen
            voorzieningen = _context.Voorzieningen.Where(v => v.BoekingId == Id).SingleOrDefault();
            if (voorzieningen != null)
            {
                Voorzieningen.GetVoorzieningById(voorzieningen.Id);

                BoekingModel.VoorzieningenArts = Voorzieningen.Arts;
                BoekingModel.VoorzieningenBusStock = Voorzieningen.BusStock;
                BoekingModel.VoorzieningenCoolersBand = Voorzieningen.CoolersBand;
                BoekingModel.VoorzieningenCoolersGmm = Voorzieningen.CoolersGmm;
                BoekingModel.VoorzieningenKinesist = Voorzieningen.Kinesist;
                BoekingModel.VoorzieningenRunner = Voorzieningen.Runner;
                BoekingModel.VoorzieningenV110 = Voorzieningen.V110;
                BoekingModel.VoorzieningenWasserij = Voorzieningen.Wasserij;
                BoekingModel.VoorzieningenZuurstof = Voorzieningen.Zuurstof;
            }

            // Get voorzieningen remarks
            VoorzieningCommentaren.GetCommentaarByBoekingIdAndType(pBoekingId, 1);
            BoekingModel.VoorzieningenCommentaar = VoorzieningCommentaren.Omschrijving;
        }

        public int Save()
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // In Edit-mode - due to complexity the save principle of delete - insert is applied, no search and update statements //
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Delete boeking kleedkamers
            foreach (BoekingKleedkamer item in _context.BoekingKleedkamers.Where(b => b.BoekingId == _boeking.Id))
            {
                _context.BoekingKleedkamers.Remove(item);
            }

            // Delete boeking productie eenheden
            foreach (BoekingProductieEenheid item in _context.BoekingProductieEenheden.Where(b => b.BoekingId == _boeking.Id))
            {
                _context.BoekingProductieEenheden.Remove(item);
            }

            // Delete begeleiders
            foreach (Begeleiding item in _context.Begeleiders.Where(b => b.BoekingId == _boeking.Id))
            {
                _context.Begeleiders.Remove(item);
            }

            // Delete catering
            foreach (Catering item in _context.Caterings.Where(b => b.BoekingId == _boeking.Id))
            {
                _context.Caterings.Remove(item);
            }

            // Delete voorzieningen
            foreach (Voorziening item in _context.Voorzieningen.Where(b => b.BoekingId == _boeking.Id))
            {
                _context.Voorzieningen.Remove(item);
            }

            // Delete boeking commentaren
            foreach (Commentaar item in _context.Commentaren.Where(b => b.BoekingId == _boeking.Id))
            {
                _context.Commentaren.Remove(item);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            _boeking.BandId = BoekingModel.BandId;
            _boeking.Datum = BoekingModel.Datum;
            _boeking.BeginUur = BoekingModel.BeginUur;
            _boeking.EindUur = BoekingModel.EindUur;
            _boeking.KleedkamerBeginUur = BoekingModel.KleedkamerBeginUur;
            _boeking.KleedkamerEindUur = BoekingModel.KleedkamerEindUur;
            _boeking.PodiumId = BoekingModel.PodiumId;
            if (BoekingModel.TentId != 0) _boeking.TentId = BoekingModel.TentId;

            if (_boeking.Id == 0) _context.Boekingen.Add(_boeking);
            else _context.Boekingen.Update(_boeking);

            //_context.SaveChanges();

            // Create entries for kleedkamers
            if (BoekingModel.Kleedkamer1 != 0)
            {
                _context.Add(new BoekingKleedkamer() { Boeking = _boeking, KleedkamerId = (int)BoekingModel.Kleedkamer1 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Kleedkamer2 != 0)
            {
                _context.Add(new BoekingKleedkamer() { Boeking = _boeking, KleedkamerId = (int)BoekingModel.Kleedkamer2 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Kleedkamer3 != 0)
            {
                _context.Add(new BoekingKleedkamer() { Boeking = _boeking, KleedkamerId = (int)BoekingModel.Kleedkamer3 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Kleedkamer4 != 0)
            {
                _context.Add(new BoekingKleedkamer() { Boeking = _boeking, KleedkamerId = (int)BoekingModel.Kleedkamer4 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Kleedkamer5 != 0)
            {
                _context.Add(new BoekingKleedkamer() { Boeking = _boeking, KleedkamerId = (int)BoekingModel.Kleedkamer5 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Kleedkamer6 != 0)
            {
                _context.Add(new BoekingKleedkamer() { Boeking = _boeking, KleedkamerId = (int)BoekingModel.Kleedkamer6 });
                //_context.SaveChanges();
            }

            // Create entries for productie eenheden
            if (BoekingModel.ProductieEenheid1 != 0)
            {
                _context.Add(new BoekingProductieEenheid() { Boeking = _boeking, ProductieEenheidId = (int)BoekingModel.ProductieEenheid1 });
                //_context.SaveChanges();
            }
            if (BoekingModel.ProductieEenheid2 != 0)
            {
                _context.Add(new BoekingProductieEenheid() { Boeking = _boeking, ProductieEenheidId = (int)BoekingModel.ProductieEenheid2 });
                //_context.SaveChanges();
            }
            if (BoekingModel.ProductieEenheid3 != 0)
            {
                _context.Add(new BoekingProductieEenheid() { Boeking = _boeking, ProductieEenheidId = (int)BoekingModel.ProductieEenheid3 });
                //_context.SaveChanges();
            }
            if (BoekingModel.ProductieEenheid4 != 0)
            {
                _context.Add(new BoekingProductieEenheid() { Boeking = _boeking, ProductieEenheidId = (int)BoekingModel.ProductieEenheid4 });
                //_context.SaveChanges();
            }
            if (BoekingModel.ProductieEenheid5 != 0)
            {
                _context.Add(new BoekingProductieEenheid() { Boeking = _boeking, ProductieEenheidId = (int)BoekingModel.ProductieEenheid5 });
                //_context.SaveChanges();
            }
            if (BoekingModel.ProductieEenheid6 != 0)
            {
                _context.Add(new BoekingProductieEenheid() { Boeking = _boeking, ProductieEenheidId = (int)BoekingModel.ProductieEenheid6 });
                //_context.SaveChanges();
            }

            // Create entries for begeleiders
            if ((BoekingModel.TourmanagerNaam ?? "").Trim().Length > 0)
            {
                _context.Add(new Begeleiding() { Boeking = _boeking, Omschrijving = BoekingModel.TourmanagerNaam, FunctieId = 1, Email = BoekingModel.TourmanagerEmail, Gsm = BoekingModel.TourmanagerGsm, WalkieTalkie = BoekingModel.TourmanagerWalkieTalkie });
                //_context.SaveChanges();
            }

            if ((BoekingModel.ProductieManagerNaam ?? "").Trim().Length > 0)
            {
                _context.Add(new Begeleiding() { Boeking = _boeking, Omschrijving = BoekingModel.ProductieManagerNaam, FunctieId = 2, Email = BoekingModel.ProductieManagerEmail, Gsm = BoekingModel.ProductieManagerGsm, WalkieTalkie = BoekingModel.ProductieManagerWalkieTalkie });
                //_context.SaveChanges();
            }

            if (BoekingModel.Begeleider1 != "Kies...")
            {
                _context.Add(new Begeleiding() { Boeking = _boeking, Omschrijving = BoekingModel.Begeleider1, FunctieId = 3 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Begeleider2 != "Kies...")
            {
                _context.Add(new Begeleiding() { Boeking = _boeking, Omschrijving = BoekingModel.Begeleider2, FunctieId = 3 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Begeleider3 != "Kies...")
            {
                _context.Add(new Begeleiding() { Boeking = _boeking, Omschrijving = BoekingModel.Begeleider3, FunctieId = 3 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Begeleider4 != "Kies...")
            {
                _context.Add(new Begeleiding() { Boeking = _boeking, Omschrijving = BoekingModel.Begeleider4, FunctieId = 3 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Begeleider5 != "Kies...")
            {
                _context.Add(new Begeleiding() { Boeking = _boeking, Omschrijving = BoekingModel.Begeleider5, FunctieId = 3 });
                //_context.SaveChanges();
            }
            if (BoekingModel.Begeleider6 != "Kies...")
            {
                _context.Add(new Begeleiding() { Boeking = _boeking, Omschrijving = BoekingModel.Begeleider6, FunctieId = 3 });
                //_context.SaveChanges();
            }

            // Create entries for catering
            _context.Add(new Catering() { Boeking = _boeking, AfterShow = BoekingModel.CateringAfterShow, Optie1 = BoekingModel.CateringOptie1, Optie1Waarde = BoekingModel.CateringOptie1Waarde, Optie2 = BoekingModel.CateringOptie2, Optie2Waarde = BoekingModel.CateringOptie2Waarde, Special = BoekingModel.CateringSpecial, TakeAwayFood = BoekingModel.CateringTakeAwayFood });
            //_context.SaveChanges();

            // Create entries for catering commentaren
            if ((BoekingModel.CateringCommentaar ?? "").Trim().Length > 0)
            {
                _context.Add(new Commentaar() { Boeking = _boeking, CommentaarTypeId = 2, Omschrijving = BoekingModel.CateringCommentaar });
                //_context.SaveChanges();
            }

            // Create entries for voorzieningen
            _context.Add(new Voorziening() { Boeking = _boeking, Arts = BoekingModel.VoorzieningenArts, BusStock = BoekingModel.VoorzieningenBusStock, CoolersBand = BoekingModel.VoorzieningenCoolersBand, CoolersGmm = BoekingModel.VoorzieningenCoolersGmm, Kinesist = BoekingModel.VoorzieningenKinesist, Runner = BoekingModel.VoorzieningenRunner, V110 = BoekingModel.VoorzieningenV110, Wasserij = BoekingModel.VoorzieningenWasserij, Zuurstof = BoekingModel.VoorzieningenZuurstof });
            //_context.SaveChanges();

            // Create entries for voorzieningen commentaren
            if ((BoekingModel.VoorzieningenCommentaar ?? "").Trim().Length > 0)
            {
                _context.Add(new Commentaar() { Boeking = _boeking, CommentaarTypeId = 1, Omschrijving = BoekingModel.VoorzieningenCommentaar });                
            }

            return _context.SaveChanges();
        }
    }
}
