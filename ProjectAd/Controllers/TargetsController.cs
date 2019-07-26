using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectAd.Data;
using ProjectAd.Models;

namespace ProjectAd.Controllers
{
    public class TargetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TargetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Targets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Targets.Include(t => t.Ad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Targets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = await _context.Targets
                .Include(t => t.Ad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (target == null)
            {
                return NotFound();
            }

            return View(target);
        }

        // GET: Targets/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Ads, "Id", "Id");
            return View();
        }

        // POST: Targets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,AgeFrom,AgeTo,Gender")] Target target)
        {
            if (ModelState.IsValid)
            {
                _context.Add(target);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Ads, "Id", "Id", target.Id);
            return View(target);
        }

        // GET: Targets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = await _context.Targets.FindAsync(id);
            if (target == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Ads, "Id", "Id", target.Id);
            return View(target);
        }

        // POST: Targets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,AgeFrom,AgeTo,Gender")] Target target)
        {
            if (id != target.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(target);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TargetExists(target.Id))
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
            ViewData["Id"] = new SelectList(_context.Ads, "Id", "Id", target.Id);
            return View(target);
        }

        // GET: Targets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = await _context.Targets
                .Include(t => t.Ad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (target == null)
            {
                return NotFound();
            }

            return View(target);
        }

        // POST: Targets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var target = await _context.Targets.FindAsync(id);
            _context.Targets.Remove(target);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TargetExists(int id)
        {
            return _context.Targets.Any(e => e.Id == id);
        }
    }
}
