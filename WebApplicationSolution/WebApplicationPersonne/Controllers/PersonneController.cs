using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationPersonne.Models;

namespace WebApplicationPersonne.Controllers
{
    public class PersonneController : Controller
    {
        private readonly SqlServerContext _context;
        string login = "Yves";
        string login2 = "admin";

        public PersonneController(SqlServerContext context)
        {
            _context = context;
        }

        // GET: Personne
        public async Task<IActionResult> Index()
        {
            
              return View(await _context.Personnes.
                  Where(x => x.Utilisateur == login || x.Utilisateur == login2).ToListAsync());
        }

        // GET: Personne/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personnes == null)
            {
                return NotFound();
            }

            var personne = await _context.Personnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // GET: Personne/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personne/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,DateDeNaissance")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personne);
        }

        // GET: Personne/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personnes == null)
            {
                return NotFound();
            }

            var personne = _context.Personnes.Where(x => x.Utilisateur == login && x.Id == id).FirstOrDefault();
            if (personne == null)
            {
                return RedirectToAction("Index");
            }
            return View(personne);
        }

        // POST: Personne/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,DateDeNaissance")] Personne personne)
        {
            if (id != personne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneExists(personne.Id))
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
            return View(personne);
        }


        private bool PersonneExists(int id)
        {
          return (_context.Personnes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
