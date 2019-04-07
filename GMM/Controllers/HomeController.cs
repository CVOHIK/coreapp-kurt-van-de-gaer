using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GMM.Models;
using GMM.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace GMM.Controllers
{
    public class HomeController : Controller
    {
        private readonly GmmDbContext _context;

        public HomeController(GmmDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //return View(new ViewModel.vm_boeking(_context));
            ViewBag.festivalDate = DateTime.Today.ToString("yyyy-MM-dd");
            return View(_context.Boekingen.Include(b => b.Band).Include(b => b.Podium).Include(b => b.Tent).Where(b => b.Datum == DateTime.Today).OrderBy(b => b.Datum).ThenBy(b => b.BeginUur).ThenBy(b => b.Band.Omschrijving).ToList());
        }

        [HttpPost]
        public IActionResult Index(DateTime festivalDate)
        {
            //return View(new ViewModel.vm_boeking(_context));
            ViewBag.festivalDate = festivalDate.ToString("yyyy-MM-dd");
            return View(_context.Boekingen.Include(b => b.Band).Include(b => b.Podium).Include(b => b.Tent).Where(b => b.Datum == festivalDate).OrderBy(b => b.Datum).ThenBy(b => b.BeginUur).ThenBy(b => b.Band.Omschrijving).ToList());
        }

        public IActionResult IndexByYear(int year)
        {
            return View();
        }

        // GET: Boekingen/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boeking = new vm_boeking(_context);
            boeking.GetBoekingById((int)id);

            return View(boeking.BoekingModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
