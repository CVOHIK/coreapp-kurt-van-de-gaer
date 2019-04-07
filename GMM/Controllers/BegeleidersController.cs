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
    public class BegeleidersController : Controller
    {
        private readonly GmmDbContext _context;

        public BegeleidersController(GmmDbContext context)
        {
            _context = context;
        }

        // GET: Begeleiders
        public async Task<IActionResult> Index()
        {
            var gmmDbContext = _context.Begeleiders.Include(b => b.Boeking).Include(b => b.Functie);
            return View(await gmmDbContext.ToListAsync());
        }

        // GET: Begeleiders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var begeleiding = await _context.Begeleiders
                .Include(b => b.Boeking)
                .Include(b => b.Functie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (begeleiding == null)
            {
                return NotFound();
            }

            return View(begeleiding);
        }

        // GET: Begeleiders/Create
        public IActionResult Create()
        {
            ViewData["BoekingId"] = new SelectList(_context.Boekingen, "Id", "Id");
            ViewData["FunctieId"] = new SelectList(_context.Functies, "Id", "Id");
            return View();
        }

        // POST: Begeleiders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoekingId,Omschrijving,FunctieId,Email,Gsm,WalkieTalkie")] Begeleiding begeleiding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(begeleiding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoekingId"] = new SelectList(_context.Boekingen, "Id", "Id", begeleiding.BoekingId);
            ViewData["FunctieId"] = new SelectList(_context.Functies, "Id", "Id", begeleiding.FunctieId);
            return View(begeleiding);
        }

        // GET: Begeleiders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var begeleiding = await _context.Begeleiders.FindAsync(id);
            if (begeleiding == null)
            {
                return NotFound();
            }
            ViewData["BoekingId"] = new SelectList(_context.Boekingen, "Id", "Id", begeleiding.BoekingId);
            ViewData["FunctieId"] = new SelectList(_context.Functies, "Id", "Id", begeleiding.FunctieId);
            return View(begeleiding);
        }

        // POST: Begeleiders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoekingId,Omschrijving,FunctieId,Email,Gsm,WalkieTalkie")] Begeleiding begeleiding)
        {
            if (id != begeleiding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(begeleiding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BegeleidingExists(begeleiding.Id))
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
            ViewData["BoekingId"] = new SelectList(_context.Boekingen, "Id", "Id", begeleiding.BoekingId);
            ViewData["FunctieId"] = new SelectList(_context.Functies, "Id", "Id", begeleiding.FunctieId);
            return View(begeleiding);
        }

        // GET: Begeleiders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var begeleiding = await _context.Begeleiders
                .Include(b => b.Boeking)
                .Include(b => b.Functie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (begeleiding == null)
            {
                return NotFound();
            }

            return View(begeleiding);
        }

        // POST: Begeleiders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var begeleiding = await _context.Begeleiders.FindAsync(id);
            _context.Begeleiders.Remove(begeleiding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BegeleidingExists(int id)
        {
            return _context.Begeleiders.Any(e => e.Id == id);
        }
    }
}
