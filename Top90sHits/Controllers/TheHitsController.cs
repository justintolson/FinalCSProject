using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Top90sHits.Data;
using Top90sHits.Models;

namespace Top90sHits.Controllers
{
    public class TheHitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheHitsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TheHits
        public async Task<IActionResult> Index()
        {
            return View(await _context.TheHits.ToListAsync());
        }

        // GET: TheHits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theHits = await _context.TheHits.SingleOrDefaultAsync(m => m.ID == id);
            if (theHits == null)
            {
                return NotFound();
            }

            return View(theHits);
        }

        // GET: TheHits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheHits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Artist,Genre,ReleaseDate,Title")] TheHits theHits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theHits);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(theHits);
        }

        // GET: TheHits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theHits = await _context.TheHits.SingleOrDefaultAsync(m => m.ID == id);
            if (theHits == null)
            {
                return NotFound();
            }
            return View(theHits);
        }

        // POST: TheHits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Artist,Genre,ReleaseDate,Title")] TheHits theHits)
        {
            if (id != theHits.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theHits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheHitsExists(theHits.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(theHits);
        }

        // GET: TheHits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theHits = await _context.TheHits.SingleOrDefaultAsync(m => m.ID == id);
            if (theHits == null)
            {
                return NotFound();
            }

            return View(theHits);
        }

        // POST: TheHits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theHits = await _context.TheHits.SingleOrDefaultAsync(m => m.ID == id);
            _context.TheHits.Remove(theHits);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TheHitsExists(int id)
        {
            return _context.TheHits.Any(e => e.ID == id);
        }
    }
}
