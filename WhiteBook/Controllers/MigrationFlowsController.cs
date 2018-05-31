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
    public class MigrationFlowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MigrationFlowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MigrationFlows
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MigrationFlow.Include(m => m.Confession).Include(m => m.Country).Include(m => m.GermanyCity).Include(m => m.MigrationType).Include(m => m.RiskyLevel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MigrationFlows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrationFlow = await _context.MigrationFlow
                .Include(m => m.Confession)
                .Include(m => m.Country)
                .Include(m => m.GermanyCity)
                .Include(m => m.MigrationType)
                .Include(m => m.RiskyLevel)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (migrationFlow == null)
            {
                return NotFound();
            }

            return View(migrationFlow);
        }

        // GET: MigrationFlows/Create
        public IActionResult Create()
        {
            ViewData["ConfessionId"] = new SelectList(_context.Confessions, "Id", "Descr");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Descr");
            ViewData["GermanyCityId"] = new SelectList(_context.GermanyCities, "Id", "Descr");
            ViewData["MigrationTypeId"] = new SelectList(_context.MigrationTypes, "Id", "Descr");
            ViewData["RiskyLevelId"] = new SelectList(_context.RiskyLevels, "Id", "Descr");
            return View();
        }

        // POST: MigrationFlows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr,DateFrom,DateTill,Amount,RiskyLevelId,GermanyCityId,CountryId,ConfessionId,MigrationTypeId")] MigrationFlow migrationFlow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(migrationFlow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConfessionId"] = new SelectList(_context.Confessions, "Id", "Descr", migrationFlow.ConfessionId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Descr", migrationFlow.CountryId);
            ViewData["GermanyCityId"] = new SelectList(_context.GermanyCities, "Id", "Descr", migrationFlow.GermanyCityId);
            ViewData["MigrationTypeId"] = new SelectList(_context.MigrationTypes, "Id", "Descr", migrationFlow.MigrationTypeId);
            ViewData["RiskyLevelId"] = new SelectList(_context.RiskyLevels, "Id", "Descr", migrationFlow.RiskyLevelId);
            return View(migrationFlow);
        }

        // GET: MigrationFlows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrationFlow = await _context.MigrationFlow.SingleOrDefaultAsync(m => m.Id == id);
            if (migrationFlow == null)
            {
                return NotFound();
            }
            ViewData["ConfessionId"] = new SelectList(_context.Confessions, "Id", "Descr", migrationFlow.ConfessionId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Descr", migrationFlow.CountryId);
            ViewData["GermanyCityId"] = new SelectList(_context.GermanyCities, "Id", "Descr", migrationFlow.GermanyCityId);
            ViewData["MigrationTypeId"] = new SelectList(_context.MigrationTypes, "Id", "Descr", migrationFlow.MigrationTypeId);
            ViewData["RiskyLevelId"] = new SelectList(_context.RiskyLevels, "Id", "Descr", migrationFlow.RiskyLevelId);
            return View(migrationFlow);
        }

        // POST: MigrationFlows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr,DateFrom,DateTill,Amount,RiskyLevelId,GermanyCityId,CountryId,ConfessionId,MigrationTypeId")] MigrationFlow migrationFlow)
        {
            if (id != migrationFlow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(migrationFlow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MigrationFlowExists(migrationFlow.Id))
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
            ViewData["ConfessionId"] = new SelectList(_context.Confessions, "Id", "Descr", migrationFlow.ConfessionId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Descr", migrationFlow.CountryId);
            ViewData["GermanyCityId"] = new SelectList(_context.GermanyCities, "Id", "Descr", migrationFlow.GermanyCityId);
            ViewData["MigrationTypeId"] = new SelectList(_context.MigrationTypes, "Id", "Descr", migrationFlow.MigrationTypeId);
            ViewData["RiskyLevelId"] = new SelectList(_context.RiskyLevels, "Id", "Descr", migrationFlow.RiskyLevelId);
            return View(migrationFlow);
        }

        // GET: MigrationFlows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrationFlow = await _context.MigrationFlow
                .Include(m => m.Confession)
                .Include(m => m.Country)
                .Include(m => m.GermanyCity)
                .Include(m => m.MigrationType)
                .Include(m => m.RiskyLevel)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (migrationFlow == null)
            {
                return NotFound();
            }

            return View(migrationFlow);
        }

        // POST: MigrationFlows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var migrationFlow = await _context.MigrationFlow.SingleOrDefaultAsync(m => m.Id == id);
            _context.MigrationFlow.Remove(migrationFlow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MigrationFlowExists(int id)
        {
            return _context.MigrationFlow.Any(e => e.Id == id);
        }
    }
}
