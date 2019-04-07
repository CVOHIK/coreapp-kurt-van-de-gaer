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
    public class PodiaController : Controller
    {
        private readonly GmmDbContext _context;

        public PodiaController(GmmDbContext context)
        {
            _context = context;
        }

        // GET: Podia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Podia.ToListAsync());
        }

        // GET: Podia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podium = await _context.Podia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podium == null)
            {
                return NotFound();
            }

            return View(podium);
        }

        // GET: Podia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Podia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Omschrijving")] Podium podium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podium);
        }

        // GET: Podia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podium = await _context.Podia.FindAsync(id);
            if (podium == null)
            {
                return NotFound();
            }
            return View(podium);
        }

        // POST: Podia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Omschrijving")] Podium podium)
        {
            if (id != podium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodiumExists(podium.Id))
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
            return View(podium);
        }

        // GET: Podia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podium = await _context.Podia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podium == null)
            {
                return NotFound();
            }

            return View(podium);
        }

        // POST: Podia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var podium = await _context.Podia.FindAsync(id);
            _context.Podia.Remove(podium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodiumExists(int id)
        {
            return _context.Podia.Any(e => e.Id == id);
        }
    }
}
