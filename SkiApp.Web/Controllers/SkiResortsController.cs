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
    public class SkiResortsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkiResortsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkiResorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SkiResorts.ToListAsync());
        }

        // GET: SkiResorts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiResort = await _context.SkiResorts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skiResort == null)
            {
                return NotFound();
            }

            return View(skiResort);
        }

        // GET: SkiResorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkiResorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,Elevation,NumberOfSlopes,Difficulty,SeasonStart,SeasonEnd")] SkiResort skiResort)
        {
            if (ModelState.IsValid)
            {
                skiResort.Id = Guid.NewGuid();
                _context.Add(skiResort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skiResort);
        }

        // GET: SkiResorts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiResort = await _context.SkiResorts.FindAsync(id);
            if (skiResort == null)
            {
                return NotFound();
            }
            return View(skiResort);
        }

        // POST: SkiResorts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Location,Elevation,NumberOfSlopes,Difficulty,SeasonStart,SeasonEnd")] SkiResort skiResort)
        {
            if (id != skiResort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skiResort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkiResortExists(skiResort.Id))
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
            return View(skiResort);
        }

        // GET: SkiResorts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiResort = await _context.SkiResorts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skiResort == null)
            {
                return NotFound();
            }

            return View(skiResort);
        }

        // POST: SkiResorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var skiResort = await _context.SkiResorts.FindAsync(id);
            if (skiResort != null)
            {
                _context.SkiResorts.Remove(skiResort);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkiResortExists(Guid id)
        {
            return _context.SkiResorts.Any(e => e.Id == id);
        }
    }
}
