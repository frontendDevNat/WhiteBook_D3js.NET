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
    public class GermanyRegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GermanyRegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GermanyRegions
        public async Task<IActionResult> Index()
        {
            return View(await _context.GermanyRegions.ToListAsync());
        }

        // GET: GermanyRegions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var germanyRegion = await _context.GermanyRegions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (germanyRegion == null)
            {
                return NotFound();
            }

            return View(germanyRegion);
        }

        // GET: GermanyRegions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GermanyRegions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr")] GermanyRegion germanyRegion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(germanyRegion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(germanyRegion);
        }

        // GET: GermanyRegions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var germanyRegion = await _context.GermanyRegions.SingleOrDefaultAsync(m => m.Id == id);
            if (germanyRegion == null)
            {
                return NotFound();
            }
            return View(germanyRegion);
        }

        // POST: GermanyRegions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr")] GermanyRegion germanyRegion)
        {
            if (id != germanyRegion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(germanyRegion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GermanyRegionExists(germanyRegion.Id))
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
            return View(germanyRegion);
        }

        // GET: GermanyRegions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var germanyRegion = await _context.GermanyRegions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (germanyRegion == null)
            {
                return NotFound();
            }

            return View(germanyRegion);
        }

        // POST: GermanyRegions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var germanyRegion = await _context.GermanyRegions.SingleOrDefaultAsync(m => m.Id == id);
            _context.GermanyRegions.Remove(germanyRegion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GermanyRegionExists(int id)
        {
            return _context.GermanyRegions.Any(e => e.Id == id);
        }
    }
}
