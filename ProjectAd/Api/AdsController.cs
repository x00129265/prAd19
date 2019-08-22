using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAd.Data;
using ProjectAd.Models;

namespace ProjectAd.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAds()
        {
            return await _context.Ads.ToListAsync();
        }

        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ad>> GetAd(int id)
        {
            var ad = await _context.Ads.FindAsync(id);

            if (ad == null)
            {
                return NotFound();
            }

            return ad;
        }

        // GET: api/Ad/Random
        // TODO: This should be accessed only with token
        // TODO: Implement better random selecotr
        [HttpGet("number/")]
        public async Task<ActionResult<Ad>> GetAdRandom()
        {
            return await _context.Ads.FirstOrDefaultAsync(x => x.Credit > 0);
        }



        //// PUT: api/Ads/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAd(int id, Ad ad)
        //{
        //    if (id != ad.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ad).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AdExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Ads
        //[HttpPost]
        //public async Task<ActionResult<Ad>> PostAd(Ad ad)
        //{
        //    _context.Ads.Add(ad);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAd", new { id = ad.Id }, ad);
        //}

        //// DELETE: api/Ads/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Ad>> DeleteAd(int id)
        //{
        //    var ad = await _context.Ads.FindAsync(id);
        //    if (ad == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Ads.Remove(ad);
        //    await _context.SaveChangesAsync();

        //    return ad;
        //}

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }
    }
}
