using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectAd.Data;
using ProjectAd.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ProjectAd.Controllers
{
    [Authorize]
    public class AdsController : Controller
    {
        private readonly ApplicationDbContext _context;
        string currentUserId;
        ApplicationUser currentUser;
        private List<Ad> AdData { get; }

        public AdsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            currentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
        }

        // GET: Ads of current user
        public async Task<IActionResult> Index()
        {
   
            var applicationDbContext = _context.Ads.Where(x => x.User.Id == currentUserId);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ads/Create
        public IActionResult Create()
        {
            //ViewData["Id"] = new SelectList(_context.Ads, "Id", "Id");
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DateCreated,Link")] Ad ad)
        {
            
            if (ModelState.IsValid)
            {
                // Create target that uses same ID as ad (one to one relationship)
                Target target = new Target();
                target.Id = ad.Id;
                target.Ad = ad;
                _context.Add(target);

                // Create Ad
                // Assign ad.user to current user
                ad.User = currentUser;
                ad.DateCreated = DateTime.Today;
                _context.Add(ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(include: "Id,Title,Link")] Ad ad)
        {
            if (id != ad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Ads.Update(ad).State = EntityState.Modified;
                    _context.Entry(ad).Property("DateCreated").IsModified = false;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.Id))
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
            return View(ad);
        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var target = await _context.Targets.FindAsync(id);
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            _context.Targets.Remove(target);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }
    

        // Targets views:
        // GET: Ads/Target/5
        public async Task<IActionResult> Target(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _target = await _context.Targets.FindAsync(id);
            if (_target == null)
            {
                return NotFound();
            }
            return View(_target);
        }

        // POST: Ads//Target/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Target(int id, [Bind("Id,Country,AgeFrom,AgeTo,Gender")] Target _target)
        {
            if (id != _target.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //ad.User = currentUser;
                    _context.Targets.Update(_target).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(_target.Id))
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
            return View(_target);
        }

        // Credits view:
        // GET: Ads/Credits/5
        public IActionResult Credits(int? id)
        {
            double PricePerItem = 2.5;
            ViewData["pricePerItem"] = PricePerItem;
            ViewData["Id"] = id;
            return View();
        }
    }
}