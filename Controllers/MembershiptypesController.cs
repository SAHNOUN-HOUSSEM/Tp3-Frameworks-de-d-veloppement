using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp3.Data;
using tp3.Models;

namespace tp3.Controllers
{
    public class MembershiptypesController : Controller
    {
        private readonly ApplicationdbContext _context;

        public MembershiptypesController(ApplicationdbContext context)
        {
            _context = context;
        }

        // GET: Membershiptypes
        public async Task<IActionResult> Index()
        {
            return _context.membershiptypes != null ?
                        View(await _context.membershiptypes.ToListAsync()) :
                        Problem("Entity set 'ApplicationdbContext.membershiptypes'  is null.");
        }

        // GET: Membershiptypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.membershiptypes == null)
            {
                return NotFound();
            }

            var membershiptypes = await _context.membershiptypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membershiptypes == null)
            {
                return NotFound();
            }

            return View(membershiptypes);
        }

        // GET: Membershiptypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membershiptypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SignUpFee,DurationInMonth,DiscountRate")] Membershiptypes membershiptypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membershiptypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membershiptypes);
        }

        // GET: Membershiptypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.membershiptypes == null)
            {
                return NotFound();
            }

            var membershiptypes = await _context.membershiptypes.FindAsync(id);
            if (membershiptypes == null)
            {
                return NotFound();
            }
            return View(membershiptypes);
        }

        // POST: Membershiptypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SignUpFee,DurationInMonth,DiscountRate")] Membershiptypes membershiptypes)
        {
            if (id != membershiptypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membershiptypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershiptypesExists(membershiptypes.Id))
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
            return View(membershiptypes);
        }

        // GET: Membershiptypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.membershiptypes == null)
            {
                return NotFound();
            }

            var membershiptypes = await _context.membershiptypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membershiptypes == null)
            {
                return NotFound();
            }

            return View(membershiptypes);
        }

        // POST: Membershiptypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.membershiptypes == null)
            {
                return Problem("Entity set 'ApplicationdbContext.membershiptypes'  is null.");
            }
            var membershiptypes = await _context.membershiptypes.FindAsync(id);
            if (membershiptypes != null)
            {
                _context.membershiptypes.Remove(membershiptypes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershiptypesExists(int id)
        {
            return (_context.membershiptypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
