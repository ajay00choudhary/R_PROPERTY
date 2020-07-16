using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using R_PROPERTY.Data;
using R_PROPERTY.Models;

namespace R_PROPERTY.Controllers
{
    public class wishlistsController : Controller
    {
        private readonly R_PROPERTY_DB_Context _context;

        public wishlistsController(R_PROPERTY_DB_Context context)
        {
            _context = context;
        }

        // GET: wishlists
        public async Task<IActionResult> Index()
        {
            return View(await _context.wishlist.ToListAsync());
        }

        // GET: wishlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.wishlist
                .FirstOrDefaultAsync(m => m.wishlist_id == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }
        [Authorize]
        // GET: wishlists/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: wishlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("wishlist_id,user_id,property_id")] wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wishlist);
        }
        [Authorize]
        // GET: wishlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.wishlist.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            return View(wishlist);
        }
        [Authorize]
        // POST: wishlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("wishlist_id,user_id,property_id")] wishlist wishlist)
        {
            if (id != wishlist.wishlist_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!wishlistExists(wishlist.wishlist_id))
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
            return View(wishlist);
        }
        [Authorize]
        // GET: wishlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.wishlist
                .FirstOrDefaultAsync(m => m.wishlist_id == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }
        [Authorize]
        // POST: wishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wishlist = await _context.wishlist.FindAsync(id);
            _context.wishlist.Remove(wishlist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool wishlistExists(int id)
        {
            return _context.wishlist.Any(e => e.wishlist_id == id);
        }
    }
}
