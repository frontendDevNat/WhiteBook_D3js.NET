using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteBook.Models;

namespace WhiteBook.Controllers
{
    public class GermanyCitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GermanyCitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GermanyCities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GermanyCities.Include(g => g.GermanyRegion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GermanyCities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var germanyCity = await _context.GermanyCities
                .Include(g => g.GermanyRegion)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (germanyCity == null)
            {
                return NotFound();
            }

            return View(germanyCity);
        }

        // GET: GermanyCities/Create
        public IActionResult Create()
        {
            ViewData["GermanyRegionId"] = new SelectList(_context.GermanyRegions, "Id", "Descr");
            return View();
        }

        // POST: GermanyCities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr,GermanyRegionId")] GermanyCity germanyCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(germanyCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GermanyRegionId"] = new SelectList(_context.GermanyRegions, "Id", "Descr", germanyCity.GermanyRegionId);
            return View(germanyCity);
        }

        // GET: GermanyCities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var germanyCity = await _context.GermanyCities.SingleOrDefaultAsync(m => m.Id == id);
            if (germanyCity == null)
            {
                return NotFound();
            }
            ViewData["GermanyRegionId"] = new SelectList(_context.GermanyRegions, "Id", "Descr", germanyCity.GermanyRegionId);
            return View(germanyCity);
        }

        // POST: GermanyCities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr,GermanyRegionId")] GermanyCity germanyCity)
        {
            if (id != germanyCity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(germanyCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GermanyCityExists(germanyCity.Id))
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
            ViewData["GermanyRegionId"] = new SelectList(_context.GermanyRegions, "Id", "Descr", germanyCity.GermanyRegionId);
            return View(germanyCity);
        }

        // GET: GermanyCities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var germanyCity = await _context.GermanyCities
                .Include(g => g.GermanyRegion)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (germanyCity == null)
            {
                return NotFound();
            }

            return View(germanyCity);
        }

        // POST: GermanyCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var germanyCity = await _context.GermanyCities.SingleOrDefaultAsync(m => m.Id == id);
            _context.GermanyCities.Remove(germanyCity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GermanyCityExists(int id)
        {
            return _context.GermanyCities.Any(e => e.Id == id);
        }
    }
}
