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
    public class KleurCodesController : Controller
    {
        private readonly GmmDbContext _context;

        public KleurCodesController(GmmDbContext context)
        {
            _context = context;
        }

        // GET: KleurCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.KleurCodes.ToListAsync());
        }

        // GET: KleurCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleurCode = await _context.KleurCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kleurCode == null)
            {
                return NotFound();
            }

            return View(kleurCode);
        }

        // GET: KleurCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KleurCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Omschrijving,Code")] KleurCode kleurCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kleurCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kleurCode);
        }

        // GET: KleurCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleurCode = await _context.KleurCodes.FindAsync(id);
            if (kleurCode == null)
            {
                return NotFound();
            }
            return View(kleurCode);
        }

        // POST: KleurCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Omschrijving,Code")] KleurCode kleurCode)
        {
            if (id != kleurCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kleurCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KleurCodeExists(kleurCode.Id))
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
            return View(kleurCode);
        }

        // GET: KleurCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleurCode = await _context.KleurCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kleurCode == null)
            {
                return NotFound();
            }

            return View(kleurCode);
        }

        // POST: KleurCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kleurCode = await _context.KleurCodes.FindAsync(id);
            _context.KleurCodes.Remove(kleurCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KleurCodeExists(int id)
        {
            return _context.KleurCodes.Any(e => e.Id == id);
        }
    }
}
