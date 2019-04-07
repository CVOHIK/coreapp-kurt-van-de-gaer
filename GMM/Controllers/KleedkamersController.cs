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
    public class KleedkamersController : Controller
    {
        private readonly GmmDbContext _context;

        public KleedkamersController(GmmDbContext context)
        {
            _context = context;
        }

        // GET: Kleedkamers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kleedkamers.ToListAsync());
        }

        // GET: Kleedkamers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleedkamer = await _context.Kleedkamers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kleedkamer == null)
            {
                return NotFound();
            }

            return View(kleedkamer);
        }

        // GET: Kleedkamers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kleedkamers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Omschrijving")] Kleedkamer kleedkamer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kleedkamer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kleedkamer);
        }

        // GET: Kleedkamers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleedkamer = await _context.Kleedkamers.FindAsync(id);
            if (kleedkamer == null)
            {
                return NotFound();
            }
            return View(kleedkamer);
        }

        // POST: Kleedkamers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Omschrijving")] Kleedkamer kleedkamer)
        {
            if (id != kleedkamer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kleedkamer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KleedkamerExists(kleedkamer.Id))
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
            return View(kleedkamer);
        }

        // GET: Kleedkamers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleedkamer = await _context.Kleedkamers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kleedkamer == null)
            {
                return NotFound();
            }

            return View(kleedkamer);
        }

        // POST: Kleedkamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kleedkamer = await _context.Kleedkamers.FindAsync(id);
            _context.Kleedkamers.Remove(kleedkamer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KleedkamerExists(int id)
        {
            return _context.Kleedkamers.Any(e => e.Id == id);
        }
    }
}
