using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplicationDemo2023.Models;

namespace WebApplication2.Controllers
{
    public class FacturesController : Controller
    {
        private readonly SqlServerContext _context;

        public FacturesController(SqlServerContext context)
        {
            _context = context;
        }

        // GET: Factures
        public async Task<IActionResult> Index()
        {
            string role = User.Claims.FirstOrDefault(x => x.Type == "Role").Value;
            int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var maliste = _context.Factures.Include(f => f.Client).Include(f => f.LigneFactures).ToList();
            if (role == "user")
            {
                maliste = maliste.Where(x => x.UtilisateurId == id).ToList();
            }
            return View(maliste);
        }

        // GET: Factures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Factures == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }

        // GET: Factures/Create
        public IActionResult Create()
        {
            //création de la liste des clients
            List<SelectListItem> listClients = new List<SelectListItem>();
            foreach (Client c in _context.Clients)
            {
                listClients.Add(new SelectListItem() { Text = c.Prenom + " " + c.Nom, Value = c.Id.ToString() });
            }
            ViewData["Clients"] = listClients;
            //transformation de la liste des articles en json pour javascript plus tard
            ViewBag.ArticlesJson = JsonConvert.SerializeObject(_context.Articles);
            return View(new Facture() { DateFacture = DateTime.Now});
        }

        // POST: Factures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Numero,DateFacture,ClientId,Actif")] Facture facture, List<LigneFacture> LignesFacture, string Numero, DateTime DateFacture, int ClientId)
        //{
        //    //var LignesFacture = ViewBag.LignesFacture;
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(facture);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Localite", facture.ClientId);
        //    return View(facture);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> CreateNewFacture(List<LigneFacture> LignesFacture, DateTime DateFacture, int ClientId)
        {
            Facture facture = new Facture();
            facture.DateFacture = DateFacture;
            facture.ClientId = ClientId;
            facture.LigneFactures = LignesFacture; ;
            _context.Add(facture);
            await _context.SaveChangesAsync();
            return true;
        }

        // GET: Factures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Factures == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures.FindAsync(id);
            if (facture == null)
            {
                return NotFound();
            }
            List<SelectListItem> listClients = new List<SelectListItem>();
            foreach(Client c in _context.Clients)
            {
                listClients.Add(new SelectListItem() { Text = c.Prenom + " " + c.Nom, Value = c.Id.ToString() });
            }
            listClients.Add(new SelectListItem() { Text = "Veuillez sélectionner un client", Value = "" });
            ViewData["ClientId"] = listClients;
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,DateFacture,ClientId,Actif")] Facture facture)
        {
            if (id != facture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactureExists(facture.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Localite", facture.ClientId);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Factures == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Factures == null)
            {
                return Problem("Entity set 'MonContext.Factures'  is null.");
            }
            var facture = await _context.Factures.FindAsync(id);
            if (facture != null)
            {
                _context.Factures.Remove(facture);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactureExists(int id)
        {
          return _context.Factures.Any(e => e.Id == id);
        }
    }
}
