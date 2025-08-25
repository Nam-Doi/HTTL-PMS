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
    public class TblUsersController : Controller
    {
        private readonly PMSDbContext _context;

        public TblUsersController(PMSDbContext context)
        {
            _context = context;
        }

        // GET: TblUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblUsers.ToListAsync());
        }

        // GET: TblUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // GET: TblUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserCode,Dob,BankNo,SalaryConfficient,EmploymentDate,DateIssued,AccountName,Password,EmailAddress,Description,OrderNumber,Status,CreatedDate,CreatedUser,ModifiedDate,ModifiedUser")] TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUser);
        }

        // GET: TblUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUsers.FindAsync(id);
            if (tblUser == null)
            {
                return NotFound();
            }
            return View(tblUser);
        }

        // POST: TblUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserCode,Dob,BankNo,SalaryConfficient,EmploymentDate,DateIssued,AccountName,Password,EmailAddress,Description,OrderNumber,Status,CreatedDate,CreatedUser,ModifiedDate,ModifiedUser")] TblUser tblUser)
        {
            if (id != tblUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserExists(tblUser.Id))
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
            return View(tblUser);
        }

        // GET: TblUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.TblUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Kiểm tra nếu user này còn trong tblUserDepartment
            var hasDepartments = await _context.TblUserDepartments.AnyAsync(x => x.UserId == id);
            if (hasDepartments)
            {
                TempData["ErrorMessage"] = "Không thể xóa nhân viên này vì đang được gán vào phòng ban.";
                return RedirectToAction(nameof(Index));
            }

            _context.TblUsers.Remove(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xóa nhân viên thành công.";
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserExists(int id)
        {
            return _context.TblUsers.Any(e => e.Id == id);
        }
    }
}
