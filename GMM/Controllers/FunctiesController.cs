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
    public class FunctiesController : Controller
    {
        private readonly GmmDbContext _context;

        public FunctiesController(GmmDbContext context)
        {
            _context = context;
        }

        // GET: Functie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Functies.ToListAsync());
        }

        // GET: Functie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functie = await _context.Functies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (functie == null)
            {
                return NotFound();
            }

            return View(functie);
        }

        // GET: Functie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Functie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Omschrijving")] Functie functie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(functie);
        }

        // GET: Functie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functie = await _context.Functies.FindAsync(id);
            if (functie == null)
            {
                return NotFound();
            }
            return View(functie);
        }

        // POST: Functie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Omschrijving")] Functie functie)
        {
            if (id != functie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(functie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctieExists(functie.Id))
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
            return View(functie);
        }

        // GET: Functie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functie = await _context.Functies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (functie == null)
            {
                return NotFound();
            }

            return View(functie);
        }

        // POST: Functie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var functie = await _context.Functies.FindAsync(id);
            _context.Functies.Remove(functie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunctieExists(int id)
        {
            return _context.Functies.Any(e => e.Id == id);
        }
    }
}
