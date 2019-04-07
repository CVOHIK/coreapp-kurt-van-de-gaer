using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GMM.Data;
using GMM.ViewModel;

namespace GMM.Controllers
{
    public class BoekingenController : Controller
    {
        private readonly GmmDbContext _context;

        public BoekingenController(GmmDbContext context)
        {
            _context = context;
        }

        // GET: Boekingen
        public async Task<IActionResult> Index()
        {
            ViewBag.festivalDate = DateTime.Today.ToString("yyyy-MM-dd");
            var gmmDbContext = _context.Boekingen.Include(b => b.Band).Include(b => b.Podium).Include(b => b.Tent).Where(b => b.Datum == DateTime.Today).OrderBy(b => b.Datum).ThenBy(b => b.BeginUur).ThenBy(b => b.Band.Omschrijving);
            return View(await gmmDbContext.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index(DateTime festivalDate)
        {
            //return View(new ViewModel.vm_boeking(_context));
            ViewBag.festivalDate = festivalDate.ToString("yyyy-MM-dd");
            return View(_context.Boekingen.Include(b => b.Band).Include(b => b.Podium).Include(b => b.Tent).Where(b => b.Datum == festivalDate).OrderBy(b => b.Datum).ThenBy(b => b.BeginUur).ThenBy(b => b.Band.Omschrijving).ToList());
        }

        // GET: Boekingen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boeking = new vm_boeking(_context);
            boeking.GetBoekingById((int)id);

            return View(boeking.BoekingModel);
        }

        // GET: Boekingen/Create
        public IActionResult Create(int bandId)
        {
            DataManager dataManager = new DataManager(_context);

            ViewData["PodiumId"] = new SelectList(dataManager.GetAllPodia(), "Id", "Omschrijving");
            ViewData["TentId"] = new SelectList(dataManager.GetAllTenten(), "Id", "Omschrijving");
            ViewData["KleedkamerId"] = new SelectList(dataManager.GetAllKleedkamers(), "Id", "Omschrijving");
            ViewData["ProductieEenheidId"] = new SelectList(dataManager.GetAllProductieEenheden(), "Id", "Omschrijving");
            ViewData["BegeleiderId"] = new SelectList(dataManager.GetAllBegeleiders(), "Omschrijving", "Omschrijving");

            return View((new vm_boeking(_context)
                            { BandId = bandId,
                              Datum = DateTime.Today,
                              BeginUur = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0),
                              PodiumId = 0 }).BoekingModel);
        }

        [HttpPost]
        public IActionResult Create(BoekingModel model)
        {
            if (model == null)
            {
                return View(model);
            }
            else
            {
                if(model.PodiumId == 0)
                {
                    return View(model);
                }
                else
                {
                    vm_boeking boeking = new vm_boeking(_context) { BoekingModel = model };
                    boeking.Save();
                    return RedirectToAction(nameof(Index));
                }
                
            }
        }

        // GET: Boekingen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            DataManager dataManager = new DataManager(_context);

            if (id == null)
            {
                return NotFound();
            }

            var boeking = new vm_boeking(_context);
            boeking.GetBoekingById((int)id);

            if (boeking == null)
            {
                return NotFound();
            }

            ViewData["PodiumId"] = new SelectList(dataManager.GetAllPodia(), "Id", "Omschrijving", boeking.BoekingModel.PodiumId);
            ViewData["TentId"] = new SelectList(dataManager.GetAllTenten(), "Id", "Omschrijving", boeking.BoekingModel.TentId);
            ViewData["KleedkamerId"] = new SelectList(dataManager.GetAllKleedkamers(), "Id", "Omschrijving");
            ViewData["ProductieEenheidId"] = new SelectList(dataManager.GetAllProductieEenheden(), "Id", "Omschrijving");
            ViewData["BegeleiderId"] = new SelectList(dataManager.GetAllBegeleiders(), "Omschrijving", "Omschrijving");

            return View(boeking.BoekingModel);
        }

        // POST: Boekingen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,BandId,Datum,BeginUur,EindUur,KleedkamerBeginUur,KleedkamerEindUur,PodiumId,TentId")] Boeking boeking)
        public IActionResult Edit(int id, BoekingModel model)
        {
            DataManager dataManager = new DataManager(_context);

            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (model.PodiumId == 0)
                    return View(model);

                try
                {

                    var boeking = new vm_boeking(_context) { BoekingModel = model };
                    boeking.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoekingExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["PodiumId"] = new SelectList(dataManager.GetAllPodia(), "Id", "Omschrijving", model.PodiumId);
            ViewData["TentId"] = new SelectList(dataManager.GetAllTenten(), "Id", "Omschrijving", model.TentId);
            ViewData["KleedkamerId"] = new SelectList(dataManager.GetAllKleedkamers(), "Id", "Omschrijving");
            ViewData["ProductieEenheidId"] = new SelectList(dataManager.GetAllProductieEenheden(), "Id", "Omschrijving");
            ViewData["BegeleiderId"] = new SelectList(dataManager.GetAllBegeleiders(), "Omschrijving", "Omschrijving");

            return View(model);
        }

        // GET: Boekingen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boeking = await _context.Boekingen
                .Include(b => b.Band)
                .Include(b => b.Podium)
                .Include(b => b.Tent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boeking == null)
            {
                return NotFound();
            }

            return View(boeking);
        }

        // POST: Boekingen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boeking = await _context.Boekingen.FindAsync(id);
            _context.Boekingen.Remove(boeking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoekingExists(int id)
        {
            return _context.Boekingen.Any(e => e.Id == id);
        }
    }
}
