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
    public class TerroristAttacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TerroristAttacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TerroristAttacks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TerroristAttacks.Include(t => t.GermanyCity).Include(t => t.RadicalOrganization).Include(t => t.TerroristAttackType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TerroristAttacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terroristAttack = await _context.TerroristAttacks
                .Include(t => t.GermanyCity)
                .Include(t => t.RadicalOrganization)
                .Include(t => t.TerroristAttackType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (terroristAttack == null)
            {
                return NotFound();
            }

            return View(terroristAttack);
        }

        // GET: TerroristAttacks/Create
        public IActionResult Create()
        {
            ViewData["GermanyCityId"] = new SelectList(_context.GermanyCities, "Id", "Descr");
            ViewData["RadicalOrganizationId"] = new SelectList(_context.RadicalOrganizations, "Id", "Descr");
            ViewData["TerroristAttackTypeId"] = new SelectList(_context.TerroristAttackTypes, "Id", "Descr");
            return View();
        }

        // POST: TerroristAttacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr,Date,VictimsQuantity,InjuredQuantity,RadicalOrganizationId,TerroristAttackTypeId,GermanyCityId")] TerroristAttack terroristAttack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terroristAttack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GermanyCityId"] = new SelectList(_context.GermanyCities, "Id", "Descr", terroristAttack.GermanyCityId);
            ViewData["RadicalOrganizationId"] = new SelectList(_context.RadicalOrganizations, "Id", "Descr", terroristAttack.RadicalOrganizationId);
            ViewData["TerroristAttackTypeId"] = new SelectList(_context.TerroristAttackTypes, "Id", "Descr", terroristAttack.TerroristAttackTypeId);
            return View(terroristAttack);
        }

        // GET: TerroristAttacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terroristAttack = await _context.TerroristAttacks.SingleOrDefaultAsync(m => m.Id == id);
            if (terroristAttack == null)
            {
                return NotFound();
            }
            ViewData["GermanyCityId"] = new SelectList(_context.GermanyCities, "Id", "Descr", terroristAttack.GermanyCityId);
            ViewData["RadicalOrganizationId"] = new SelectList(_context.RadicalOrganizations, "Id", "Descr", terroristAttack.RadicalOrganizationId);
            ViewData["TerroristAttackTypeId"] = new SelectList(_context.TerroristAttackTypes, "Id", "Descr", terroristAttack.TerroristAttackTypeId);
            return View(terroristAttack);
        }

        // POST: TerroristAttacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr,Date,VictimsQuantity,InjuredQuantity,RadicalOrganizationId,TerroristAttackTypeId,GermanyCityId")] TerroristAttack terroristAttack)
        {
            if (id != terroristAttack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terroristAttack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerroristAttackExists(terroristAttack.Id))
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
            ViewData["GermanyCityId"] = new SelectList(_context.GermanyCities, "Id", "Descr", terroristAttack.GermanyCityId);
            ViewData["RadicalOrganizationId"] = new SelectList(_context.RadicalOrganizations, "Id", "Descr", terroristAttack.RadicalOrganizationId);
            ViewData["TerroristAttackTypeId"] = new SelectList(_context.TerroristAttackTypes, "Id", "Descr", terroristAttack.TerroristAttackTypeId);
            return View(terroristAttack);
        }

        // GET: TerroristAttacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terroristAttack = await _context.TerroristAttacks
                .Include(t => t.GermanyCity)
                .Include(t => t.RadicalOrganization)
                .Include(t => t.TerroristAttackType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (terroristAttack == null)
            {
                return NotFound();
            }

            return View(terroristAttack);
        }

        // POST: TerroristAttacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var terroristAttack = await _context.TerroristAttacks.SingleOrDefaultAsync(m => m.Id == id);
            _context.TerroristAttacks.Remove(terroristAttack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerroristAttackExists(int id)
        {
            return _context.TerroristAttacks.Any(e => e.Id == id);
        }
    }
}
