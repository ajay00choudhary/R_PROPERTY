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
    public class user_detailsController : Controller
    {
        private readonly R_PROPERTY_DB_Context _context;

        public user_detailsController(R_PROPERTY_DB_Context context)
        {
            _context = context;
        }

        // GET: user_details
        public async Task<IActionResult> Index()
        {
            return View(await _context.user_details.ToListAsync());
        }

        // GET: user_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_details = await _context.user_details
                .FirstOrDefaultAsync(m => m.user_id == id);
            if (user_details == null)
            {
                return NotFound();
            }

            return View(user_details);
        }
        [Authorize]
        // GET: user_details/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: user_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("user_id,user_name,user_phone_number,user_address,user_email")] user_details user_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_details);
        }
        [Authorize]
        // GET: user_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_details = await _context.user_details.FindAsync(id);
            if (user_details == null)
            {
                return NotFound();
            }
            return View(user_details);
        }
        [Authorize]
        // POST: user_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("user_id,user_name,user_phone_number,user_address,user_email")] user_details user_details)
        {
            if (id != user_details.user_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!user_detailsExists(user_details.user_id))
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
            return View(user_details);
        }
        [Authorize]
        // GET: user_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_details = await _context.user_details
                .FirstOrDefaultAsync(m => m.user_id == id);
            if (user_details == null)
            {
                return NotFound();
            }

            return View(user_details);
        }
        [Authorize]
        // POST: user_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_details = await _context.user_details.FindAsync(id);
            _context.user_details.Remove(user_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool user_detailsExists(int id)
        {
            return _context.user_details.Any(e => e.user_id == id);
        }
    }
}
