using baitaptuan4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace baitaptuan4.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly StudentDbContext _context;

        public SinhVienController(StudentDbContext context)
        {
            _context = context;
        }

        // 1. READ: Danh sách sinh viên
        public async Task<IActionResult> Index()
        {
            var dsSinhVien = await _context.SinhViens.ToListAsync();
            return View(dsSinhVien);
        }

        // 2. CREATE (GET): Hiển thị form thêm mới
        public IActionResult Create()
        {
            return View();
        }

        // 2. CREATE (POST): Xu lý thêm sinh viên vào DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sv);
        }

        // 3. UPDATE (GET): Hiển thị form sửa thông tin
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var sv = await _context.SinhViens.FindAsync(id);
            if (sv == null) return NotFound();

            return View(sv);
        }

        // 3. UPDATE (POST): Cập nhật dữ liệu vào DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SinhVien sv)
        {
            if (id != sv.MaSv) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.SinhViens.Any(e => e.MaSv == sv.MaSv)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sv);
        }

        // 4. DELETE (GET): Xác nhận xóa
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var sv = await _context.SinhViens.FirstOrDefaultAsync(m => m.MaSv == id);
            if (sv == null) return NotFound();

            return View(sv);
        }

        // 4. DELETE (POST): Thực hiện xóa khỏi DB
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sv = await _context.SinhViens.FindAsync(id);
            if (sv != null)
            {
                _context.SinhViens.Remove(sv);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}