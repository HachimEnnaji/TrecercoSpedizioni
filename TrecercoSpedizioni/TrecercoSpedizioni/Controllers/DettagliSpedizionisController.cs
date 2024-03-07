using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrecercoSpedizioni.data;
using TrecercoSpedizioni.Models;

namespace TrecercoSpedizioni.Controllers
{
    public class DettagliSpedizionisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DettagliSpedizionisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DettagliSpedizionis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DettagliSpedizioni.Include(s => s.Shipping);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: DettagliSpedizionis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dettagliSpedizioni = await _context.DettagliSpedizioni
                .FirstOrDefaultAsync(m => m.idDettagliSpedizione == id);
            if (dettagliSpedizioni == null)
            {
                return NotFound();
            }

            return View(dettagliSpedizioni);
        }

        // GET: DettagliSpedizionis/Create
        public IActionResult Create()
        {
            ViewData["IdSpedizione"] = new SelectList(_context.Spedizioni, "Id", "IndirizzoDestinatario");
            return View();
        }

        // POST: DettagliSpedizionis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDettagliSpedizione,IdSpedizione,StatoSpedizione,LuogoCorrente,NoteSpedizione,DataAggiornamento")] DettagliSpedizioni dettagliSpedizioni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dettagliSpedizioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dettagliSpedizioni);
        }

        // GET: DettagliSpedizionis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dettagliSpedizioni = await _context.DettagliSpedizioni.FindAsync(id);
            if (dettagliSpedizioni == null)
            {
                return NotFound();
            }
            return View(dettagliSpedizioni);
        }

        // POST: DettagliSpedizionis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDettagliSpedizione,IdSpedizione,StatoSpedizione,LuogoCorrente,NoteSpedizione,DataAggiornamento")] DettagliSpedizioni dettagliSpedizioni)
        {
            if (id != dettagliSpedizioni.idDettagliSpedizione)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dettagliSpedizioni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DettagliSpedizioniExists(dettagliSpedizioni.idDettagliSpedizione))
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
            return View(dettagliSpedizioni);
        }

        // GET: DettagliSpedizionis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dettagliSpedizioni = await _context.DettagliSpedizioni
                .FirstOrDefaultAsync(m => m.idDettagliSpedizione == id);
            if (dettagliSpedizioni == null)
            {
                return NotFound();
            }

            return View(dettagliSpedizioni);
        }

        // POST: DettagliSpedizionis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dettagliSpedizioni = await _context.DettagliSpedizioni.FindAsync(id);
            if (dettagliSpedizioni != null)
            {
                _context.DettagliSpedizioni.Remove(dettagliSpedizioni);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DettagliSpedizioniExists(int id)
        {
            return _context.DettagliSpedizioni.Any(e => e.idDettagliSpedizione == id);
        }
    }
}
