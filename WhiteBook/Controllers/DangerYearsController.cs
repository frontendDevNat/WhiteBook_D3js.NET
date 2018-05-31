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
    public class DangerYearsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangerYearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DangerYears
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DangerYears.Include(d => d.Danger).Include(d => d.Year)
                .OrderBy(d => d.Danger.Descr)
                .ThenBy(d => d.Year.Value);

            return View(await applicationDbContext.ToListAsync());
        }
        
        // GET: DangerYears/Create
        public IActionResult Create()
        {
            ViewData["DangerId"] = new SelectList(_context.Dangers, "Id", "Descr");
            ViewData["YearId"] = new SelectList(_context.Years.OrderBy(o=>o.Value), "Id", "Value");
            return View();
        }

        // POST: DangerYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DangerId,YearId,Amount")] DangerYear dangerYear)
        {
            if (ModelState.IsValid)
            {
                if (DangerYearExists(dangerYear.DangerId, dangerYear.YearId))
                {
                    var dangerYearOld = await _context.DangerYears.SingleOrDefaultAsync(m => m.DangerId == dangerYear.DangerId && m.YearId == dangerYear.YearId);
                    dangerYearOld.Amount = dangerYear.Amount;

                    _context.Update(dangerYearOld);
                }
                else
                {
                    _context.Add(dangerYear);
                }                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DangerId"] = new SelectList(_context.Dangers, "Id", "Descr", dangerYear.DangerId);
            ViewData["YearId"] = new SelectList(_context.Years, "Id", "Value", dangerYear.YearId);
            return View(dangerYear);
        }

        // GET: DangerYears/Edit/5
        public async Task<IActionResult> Edit(int? DangerId, int? YearId)
        {
            if (DangerId == null || YearId == null)
            {
                return NotFound();
            }

            var dangerYear = await _context.DangerYears
                .Include(d => d.Danger)
                .Include(d => d.Year)
                .SingleOrDefaultAsync(m => m.DangerId == DangerId && m.YearId == YearId);                                            

            if (dangerYear == null)
            {
                return NotFound();
            }
            ViewData["DangerId"] = new SelectList(_context.Dangers, "Id", "Descr", dangerYear.DangerId);
            ViewData["YearId"] = new SelectList(_context.Years, "Id", "Value", dangerYear.YearId);
            return View(dangerYear);
        }

        // POST: DangerYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int DangerId, int YearId, [Bind("DangerId,YearId,Amount")] DangerYear dangerYear)
        {
            if (DangerId != dangerYear.DangerId)
            {
                return NotFound();
            }

            if (YearId != dangerYear.YearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangerYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangerYearExists(dangerYear.DangerId, dangerYear.YearId))
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
            ViewData["DangerId"] = new SelectList(_context.Dangers, "Id", "Descr", dangerYear.DangerId);
            ViewData["YearId"] = new SelectList(_context.Years, "Id", "Value", dangerYear.YearId);
            return View(dangerYear);
        }

        // GET: DangerYears/Delete/5
        public async Task<IActionResult> Delete(int? DangerId, int? YearId)
        {
            if (DangerId == null || YearId == null)
            {
                return NotFound();
            }

            var dangerYear = await _context.DangerYears
                .Include(d => d.Danger)
                .Include(d => d.Year)
                .SingleOrDefaultAsync(m => m.DangerId == DangerId && m.YearId == YearId);
            if (dangerYear == null)
            {
                return NotFound();
            }

            return View(dangerYear);
        }

        // POST: DangerYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int DangerId, int YearId)
        {
            var dangerYear = await _context.DangerYears.SingleOrDefaultAsync(m => m.DangerId == DangerId && m.YearId == YearId);
            _context.DangerYears.Remove(dangerYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangerYearExists(int DangerId, int YearId)
        {
            return _context.DangerYears.Any(e => e.DangerId == DangerId && e.YearId == YearId);
        }

        public IActionResult DataLoading()
        {            
            return View();
        }

        //public IActionResult BasicBarChart()
        //{
        //    return View();
        //}
        
        public async Task<IActionResult> BasicBarChart()
        {
            return View(await _context.Dangers.ToListAsync());
        }

    }
}
