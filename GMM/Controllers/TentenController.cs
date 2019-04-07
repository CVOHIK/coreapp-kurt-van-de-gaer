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
    public class TentenController : Controller
    {
        private readonly GmmDbContext _context;

        public TentenController(GmmDbContext context)
        {
            _context = context;
        }

        // GET: Tenten
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tenten.ToListAsync());
        }

        // GET: Tenten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tent = await _context.Tenten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tent == null)
            {
                return NotFound();
            }

            return View(tent);
        }

        // GET: Tenten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Omschrijving")] Tent tent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tent);
        }

        // GET: Tenten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tent = await _context.Tenten.FindAsync(id);
            if (tent == null)
            {
                return NotFound();
            }
            return View(tent);
        }

        // POST: Tenten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Omschrijving")] Tent tent)
        {
            if (id != tent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TentExists(tent.Id))
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
            return View(tent);
        }

        // GET: Tenten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tent = await _context.Tenten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tent == null)
            {
                return NotFound();
            }

            return View(tent);
        }

        // POST: Tenten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tent = await _context.Tenten.FindAsync(id);
            _context.Tenten.Remove(tent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TentExists(int id)
        {
            return _context.Tenten.Any(e => e.Id == id);
        }
    }
}
