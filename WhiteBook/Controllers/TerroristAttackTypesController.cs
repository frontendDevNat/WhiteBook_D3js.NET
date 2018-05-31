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
    public class TerroristAttackTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TerroristAttackTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TerroristAttackTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TerroristAttackTypes.ToListAsync());
        }

        // GET: TerroristAttackTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terroristAttackType = await _context.TerroristAttackTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (terroristAttackType == null)
            {
                return NotFound();
            }

            return View(terroristAttackType);
        }

        // GET: TerroristAttackTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TerroristAttackTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descr")] TerroristAttackType terroristAttackType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terroristAttackType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terroristAttackType);
        }

        // GET: TerroristAttackTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terroristAttackType = await _context.TerroristAttackTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (terroristAttackType == null)
            {
                return NotFound();
            }
            return View(terroristAttackType);
        }

        // POST: TerroristAttackTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descr")] TerroristAttackType terroristAttackType)
        {
            if (id != terroristAttackType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terroristAttackType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerroristAttackTypeExists(terroristAttackType.Id))
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
            return View(terroristAttackType);
        }

        // GET: TerroristAttackTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terroristAttackType = await _context.TerroristAttackTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (terroristAttackType == null)
            {
                return NotFound();
            }

            return View(terroristAttackType);
        }

        // POST: TerroristAttackTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var terroristAttackType = await _context.TerroristAttackTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.TerroristAttackTypes.Remove(terroristAttackType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerroristAttackTypeExists(int id)
        {
            return _context.TerroristAttackTypes.Any(e => e.Id == id);
        }
    }
}
