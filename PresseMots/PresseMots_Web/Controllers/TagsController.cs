using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresseMots.Models;
using PresseMots.Models.Data;

namespace PresseMots.Controllers
{
    public class TagsController : Controller
    {
        private readonly PresseMotsDbContext _context;

        public TagsController(PresseMotsDbContext context)
        {
            _context = context;
        }

        // GET: Tags
        public async Task<IActionResult> Index()
        {
            var listTaG = await _context.Tags.ToListAsync();
            return View(listTaG);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var LeTag = await _context.Tags.FirstOrDefaultAsync(t =>t.Id == id);

            if (LeTag == null)
            {
                return NotFound();
            }

            return View(LeTag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var DelTag = await _context.Tags.FindAsync(id);

            if (DelTag == null) {
                return NotFound();
            }

            _context.Tags.Remove(DelTag);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
