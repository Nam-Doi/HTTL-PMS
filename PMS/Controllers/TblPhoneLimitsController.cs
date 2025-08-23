using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMS.Models;

namespace PMS.Controllers
{
    public class TblPhoneLimitsController : Controller
    {
        private readonly PMSDbContext _context;

        public TblPhoneLimitsController(PMSDbContext context)
        {
            _context = context;
        }

        // GET: TblPhoneLimits
        public async Task<IActionResult> Index()
        {
            var pMSDbContext = _context.TblPhoneLimits.Include(t => t.Posion);
            return View(await pMSDbContext.ToListAsync());
        }

        // GET: TblPhoneLimits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhoneLimit = await _context.TblPhoneLimits
                .Include(t => t.Posion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPhoneLimit == null)
            {
                return NotFound();
            }

            return View(tblPhoneLimit);
        }

        // GET: TblPhoneLimits/Create
        public IActionResult Create()
        {
            ViewData["PosionId"] = new SelectList(_context.TblPositions, "Id", "Name");
            return View();
        }

        // POST: TblPhoneLimits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PosionId,ValueLimit,DateIssued,Note,Status,CreatedDate,CreatedUser,ModifiedDate,ModifiedUser")] TblPhoneLimit tblPhoneLimit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPhoneLimit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PosionId"] = new SelectList(_context.TblPositions, "Id", "Name", tblPhoneLimit.PosionId);
            return View(tblPhoneLimit);
        }

        // GET: TblPhoneLimits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhoneLimit = await _context.TblPhoneLimits.FindAsync(id);
            if (tblPhoneLimit == null)
            {
                return NotFound();
            }
            ViewData["PosionId"] = new SelectList(_context.TblPositions, "Id", "Name", tblPhoneLimit.PosionId);
            return View(tblPhoneLimit);
        }

        // POST: TblPhoneLimits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PosionId,ValueLimit,DateIssued,Note,Status,CreatedDate,CreatedUser,ModifiedDate,ModifiedUser")] TblPhoneLimit tblPhoneLimit)
        {
            if (id != tblPhoneLimit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPhoneLimit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPhoneLimitExists(tblPhoneLimit.Id))
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
            ViewData["PosionId"] = new SelectList(_context.TblPositions, "Id", "Name", tblPhoneLimit.PosionId);
            return View(tblPhoneLimit);
        }

        // GET: TblPhoneLimits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhoneLimit = await _context.TblPhoneLimits
                .Include(t => t.Posion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPhoneLimit == null)
            {
                return NotFound();
            }

            return View(tblPhoneLimit);
        }

        // POST: TblPhoneLimits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPhoneLimit = await _context.TblPhoneLimits.FindAsync(id);
            _context.TblPhoneLimits.Remove(tblPhoneLimit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPhoneLimitExists(int id)
        {
            return _context.TblPhoneLimits.Any(e => e.Id == id);
        }
    }
}
