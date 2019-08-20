using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using luchadores.Models;
using X.PagedList;

namespace luchadores.Controllers
{
    public class VerbsController : Controller
    {
        private readonly luchadoresContext _context;

        public VerbsController(luchadoresContext context)
        {
            _context = context;
        }

        // GET: Verbs
        public ViewResult Index( int? page, string letter, string currentFilter, string searchString)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (!String.IsNullOrEmpty(letter))
            {
                return View(_context.Verb.Where(l => l.FirstLetter == letter).ToPagedList(pageNumber, pageSize));
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.CurrentFilter = searchString;
                return View(_context.Verb.Where(s => s.Name.Contains(searchString)).ToPagedList(pageNumber, pageSize));
            }
            return View(_context.Verb.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Letter(string letter, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(_context.Verb.Where(l => l.FirstLetter == letter).ToPagedList(pageNumber, pageSize));
        }

        // GET: Verbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verb = await _context.Verb
                .FirstOrDefaultAsync(m => m.ID == id);
            if (verb == null)
            {
                return NotFound();
            }

            return View(verb);
        }

        // GET: Verbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Verbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstLetter,Name,Tense,Form1,Form2,Form3,Form4,Form5,Form6,Created")] Verb verb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verb);
        }

        // GET: Verbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verb = await _context.Verb.FindAsync(id);
            if (verb == null)
            {
                return NotFound();
            }
            return View(verb);
        }

        // POST: Verbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstLetter,Name,Tense,Form1,Form2,Form3,Form4,Form5,Form6,Created")] Verb verb)
        {
            if (id != verb.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerbExists(verb.ID))
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
            return View(verb);
        }

        // GET: Verbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verb = await _context.Verb
                .FirstOrDefaultAsync(m => m.ID == id);
            if (verb == null)
            {
                return NotFound();
            }

            return View(verb);
        }

        // POST: Verbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verb = await _context.Verb.FindAsync(id);
            _context.Verb.Remove(verb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerbExists(long id)
        {
            return _context.Verb.Any(e => e.ID == id);
        }
    }
}
