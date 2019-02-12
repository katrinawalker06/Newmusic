using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newmusic.Data;
using Newmusic.Models;

namespace Newmusic.Controllers
{
    public class BandMemberBandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BandMemberBandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BandMemberBands
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BandMemberBand.Include(b => b.Band).Include(b => b.BandMember);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BandMemberBands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandMemberBand = await _context.BandMemberBand
                .Include(b => b.Band)
                .Include(b => b.BandMember)
                .FirstOrDefaultAsync(m => m.BandMemberBandId == id);
            if (bandMemberBand == null)
            {
                return NotFound();
            }

            return View(bandMemberBand);
        }

        // GET: BandMemberBands/Create
        public IActionResult Create()
        {
            ViewData["BandId"] = new SelectList(_context.Band, "Id", "Id");
            ViewData["BandMemberId"] = new SelectList(_context.BandMember, "Id", "Id");
            return View();
        }

        // POST: BandMemberBands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BandMemberBandId,BandMemberId,BandId")] BandMemberBand bandMemberBand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bandMemberBand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BandId"] = new SelectList(_context.Band, "Id", "Id", bandMemberBand.BandId);
            ViewData["BandMemberId"] = new SelectList(_context.BandMember, "Id", "Id", bandMemberBand.BandMemberId);
            return View(bandMemberBand);
        }

        // GET: BandMemberBands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandMemberBand = await _context.BandMemberBand.FindAsync(id);
            if (bandMemberBand == null)
            {
                return NotFound();
            }
            ViewData["BandId"] = new SelectList(_context.Band, "Id", "Id", bandMemberBand.BandId);
            ViewData["BandMemberId"] = new SelectList(_context.BandMember, "Id", "Id", bandMemberBand.BandMemberId);
            return View(bandMemberBand);
        }

        // POST: BandMemberBands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BandMemberBandId,BandMemberId,BandId")] BandMemberBand bandMemberBand)
        {
            if (id != bandMemberBand.BandMemberBandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bandMemberBand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandMemberBandExists(bandMemberBand.BandMemberBandId))
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
            ViewData["BandId"] = new SelectList(_context.Band, "Id", "Id", bandMemberBand.BandId);
            ViewData["BandMemberId"] = new SelectList(_context.BandMember, "Id", "Id", bandMemberBand.BandMemberId);
            return View(bandMemberBand);
        }

        // GET: BandMemberBands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandMemberBand = await _context.BandMemberBand
                .Include(b => b.Band)
                .Include(b => b.BandMember)
                .FirstOrDefaultAsync(m => m.BandMemberBandId == id);
            if (bandMemberBand == null)
            {
                return NotFound();
            }

            return View(bandMemberBand);
        }

        // POST: BandMemberBands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bandMemberBand = await _context.BandMemberBand.FindAsync(id);
            _context.BandMemberBand.Remove(bandMemberBand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandMemberBandExists(int id)
        {
            return _context.BandMemberBand.Any(e => e.BandMemberBandId == id);
        }
    }
}
