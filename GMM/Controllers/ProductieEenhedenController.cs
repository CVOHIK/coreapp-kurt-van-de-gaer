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
    public class ProductieEenhedenController : Controller
    {
        private readonly GmmDbContext _context;

        public ProductieEenhedenController(GmmDbContext context)
        {
            _context = context;
        }

        // GET: ProductieEenheden
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductieEenheden.ToListAsync());
        }

        // GET: ProductieEenheden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productieEenheid = await _context.ProductieEenheden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productieEenheid == null)
            {
                return NotFound();
            }

            return View(productieEenheid);
        }

        // GET: ProductieEenheden/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductieEenheden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Omschrijving")] ProductieEenheid productieEenheid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productieEenheid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productieEenheid);
        }

        // GET: ProductieEenheden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productieEenheid = await _context.ProductieEenheden.FindAsync(id);
            if (productieEenheid == null)
            {
                return NotFound();
            }
            return View(productieEenheid);
        }

        // POST: ProductieEenheden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Omschrijving")] ProductieEenheid productieEenheid)
        {
            if (id != productieEenheid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productieEenheid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductieEenheidExists(productieEenheid.Id))
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
            return View(productieEenheid);
        }

        // GET: ProductieEenheden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productieEenheid = await _context.ProductieEenheden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productieEenheid == null)
            {
                return NotFound();
            }

            return View(productieEenheid);
        }

        // POST: ProductieEenheden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productieEenheid = await _context.ProductieEenheden.FindAsync(id);
            _context.ProductieEenheden.Remove(productieEenheid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductieEenheidExists(int id)
        {
            return _context.ProductieEenheden.Any(e => e.Id == id);
        }
    }
}
