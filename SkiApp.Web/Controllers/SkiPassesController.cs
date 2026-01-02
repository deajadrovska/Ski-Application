using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkiApp.Domain.DomainModels;
using SkiApp.Web.Data;

namespace SkiApp.Web.Controllers
{
    public class SkiPassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkiPassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkiPasses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SkiPasses.Include(s => s.SkiResort);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SkiPasses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiPass = await _context.SkiPasses
                .Include(s => s.SkiResort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skiPass == null)
            {
                return NotFound();
            }

            return View(skiPass);
        }

        // GET: SkiPasses/Create
        public IActionResult Create()
        {
            ViewData["SkiResortId"] = new SelectList(_context.SkiResorts, "Id", "Difficulty");
            return View();
        }

        // POST: SkiPasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PassType,Price,ValidFrom,ValidUntil,AccessLevel,SkiResortId")] SkiPass skiPass)
        {
            if (ModelState.IsValid)
            {
                skiPass.Id = Guid.NewGuid();
                _context.Add(skiPass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SkiResortId"] = new SelectList(_context.SkiResorts, "Id", "Difficulty", skiPass.SkiResortId);
            return View(skiPass);
        }

        // GET: SkiPasses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiPass = await _context.SkiPasses.FindAsync(id);
            if (skiPass == null)
            {
                return NotFound();
            }
            ViewData["SkiResortId"] = new SelectList(_context.SkiResorts, "Id", "Difficulty", skiPass.SkiResortId);
            return View(skiPass);
        }

        // POST: SkiPasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PassType,Price,ValidFrom,ValidUntil,AccessLevel,SkiResortId")] SkiPass skiPass)
        {
            if (id != skiPass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skiPass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkiPassExists(skiPass.Id))
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
            ViewData["SkiResortId"] = new SelectList(_context.SkiResorts, "Id", "Difficulty", skiPass.SkiResortId);
            return View(skiPass);
        }

        // GET: SkiPasses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiPass = await _context.SkiPasses
                .Include(s => s.SkiResort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skiPass == null)
            {
                return NotFound();
            }

            return View(skiPass);
        }

        // POST: SkiPasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var skiPass = await _context.SkiPasses.FindAsync(id);
            if (skiPass != null)
            {
                _context.SkiPasses.Remove(skiPass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkiPassExists(Guid id)
        {
            return _context.SkiPasses.Any(e => e.Id == id);
        }
    }
}
