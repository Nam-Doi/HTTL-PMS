﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMS.Models;

namespace PMS.Controllers
{
    public class TblDepartmentsController : Controller
    {
        private readonly PMSDbContext _context;

        public TblDepartmentsController(PMSDbContext context)
        {
            _context = context;
        }

        // GET: TblDepartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblDepartments.ToListAsync());
        }

        // GET: TblDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepartment = await _context.TblDepartments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            return View(tblDepartment);
        }

        // GET: TblDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortName,Description,Note,Status")] TblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblDepartment);
        }

        // GET: TblDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepartment = await _context.TblDepartments.FindAsync(id);
            if (tblDepartment == null)
            {
                return NotFound();
            }
            return View(tblDepartment);
        }

        // POST: TblDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortName,Description,Note,Status")] TblDepartment tblDepartment)
        {
            if (id != tblDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDepartmentExists(tblDepartment.Id))
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
            return View(tblDepartment);
        }

        // GET: TblDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepartment = await _context.TblDepartments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            return View(tblDepartment);
        }

        // POST: TblDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDepartment = await _context.TblDepartments.FindAsync(id);
            _context.TblDepartments.Remove(tblDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDepartmentExists(int id)
        {
            return _context.TblDepartments.Any(e => e.Id == id);
        }
    }
}
