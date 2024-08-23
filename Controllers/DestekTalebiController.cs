using DestekTalebiUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace DestekTalebiUygulamasi.Controllers
{
    public class DestekTalebiController : Controller
    {
        private readonly AppDbContext _context;

        public DestekTalebiController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Veritabanındaki tüm destek taleplerini alıp listele
            var destekTalepleri = await _context.DestekTalepleri.ToListAsync();
            foreach (var talep in destekTalepleri)
            {
                if (string.IsNullOrEmpty(talep.Durum))
                {
                    talep.Durum = "Yeni"; // Örnek olarak 'Yeni' set ettim, duruma göre değişebilir.
                }
            }

            return View(destekTalepleri);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestekTalebi destekTalebi)
        {
            if (ModelState.IsValid)
            {
                // Yeni destek talebini veritabanına ekle
                _context.Add(destekTalebi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destekTalebi);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Düzenlenecek destek talebini veritabanından al
            var destekTalebi = await _context.DestekTalepleri.FindAsync(id);
            if (destekTalebi == null)
            {
                return NotFound();
            }
            return View(destekTalebi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DestekTalebi destekTalebi)
        {
            if (id != destekTalebi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Destek talebini güncelle
                    _context.Update(destekTalebi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestekTalebiExists(destekTalebi.ID))
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
            return View(destekTalebi);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Silinecek destek talebini veritabanından al
            var destekTalebi = await _context.DestekTalepleri
                .FirstOrDefaultAsync(m => m.ID == id);
            if (destekTalebi == null)
            {
                return NotFound();
            }

            return View(destekTalebi);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Destek talebini veritabanından sil
            var destekTalebi = await _context.DestekTalepleri.FindAsync(id);
            _context.DestekTalepleri.Remove(destekTalebi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Destek talebinin detaylarını getir
            var destekTalebi = await _context.DestekTalepleri
                .FirstOrDefaultAsync(m => m.ID == id);
            if (destekTalebi == null)
            {
                return NotFound();
            }

            return View(destekTalebi);
        }

        private bool DestekTalebiExists(int id)
        {
            return _context.DestekTalepleri.Any(e => e.ID == id);
        }
    }
}