#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Controllers
{
    public class birTabloesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public birTabloesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: birTabloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.birTablo.ToListAsync());
        }

        // GET: birTabloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birTablo = await _context.birTablo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (birTablo == null)
            {
                return NotFound();
            }

            return View(birTablo);
        }

        // GET: birTabloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: birTabloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,isim,ucret")] birTablo birTablo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birTablo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(birTablo);
        }

        // GET: birTabloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birTablo = await _context.birTablo.FindAsync(id);
            if (birTablo == null)
            {
                return NotFound();
            }
            return View(birTablo);
        }

        // POST: birTabloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,isim,ucret")] birTablo birTablo)
        {
            if (id != birTablo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(birTablo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!birTabloExists(birTablo.ID))
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
            return View(birTablo);
        }

        // GET: birTabloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birTablo = await _context.birTablo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (birTablo == null)
            {
                return NotFound();
            }

            return View(birTablo);
        }

        // POST: birTabloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var birTablo = await _context.birTablo.FindAsync(id);
            _context.birTablo.Remove(birTablo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool birTabloExists(int id)
        {
            return _context.birTablo.Any(e => e.ID == id);
        }
    }
}
