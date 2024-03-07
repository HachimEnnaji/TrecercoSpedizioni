using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrecercoSpedizioni.data;
using TrecercoSpedizioni.Models;

namespace TrecercoSpedizioni.Controllers
{
    public class SpedizioniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpedizioniController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Spedizonis
        public IActionResult Index()
        {
            IEnumerable<Spedizioni> objList = _context.Spedizioni.Include(c => c.Cliente);
            return View(objList);
        }

        // GET: Spedizonis/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.Spedizioni.Include(s => s.Cliente).Include(s => s.DettagliSpedizioni).FirstOrDefaultAsync(m => m.Id == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // GET: Spedizonis/Create
        public IActionResult Create()
        {
            if (ViewBag.NomeCliente == null)
            {
                ViewBag.NomeCliente = new SelectList(_context.Clienti, "idCliente", "Nome");
            }


            return View();
        }

        // POST: Spedizonis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,DataSpedizione,Peso,IndirizzoDestinatario,CittaDestinazione,NominativoDestinatario,CostoSpedizione,DataConsegnaPrevista")] Spedizioni spedizioni)
        {
            try
            {
                spedizioni.Id = Guid.NewGuid();
                _context.Add(spedizioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine("ERROREEE" + ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);

                return View(spedizioni);
            }
        }

        // GET: Spedizonis/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spedizoni = await _context.Spedizioni.FindAsync(id);
            if (spedizoni == null)
            {
                return NotFound();
            }


            return View(spedizoni);
        }

        // POST: Spedizonis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,IdCliente,DataSpedizione,Peso,CittaDestinazione,IndirizzoDestinatario,NominativoDestinatario,CostoSpedizione,DataConsegnaPrevista")] Spedizioni spedizioni)
        {
            if (id != spedizioni.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(spedizioni);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROREEE" + ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return RedirectToAction("Index");
        }

        // GET: Spedizonis/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spedizioni = await _context.Spedizioni
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spedizioni == null)
            {
                return NotFound();
            }

            return View(spedizioni);
        }

        // POST: Spedizonis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var spedizoni = await _context.Spedizioni.FindAsync(id);
            if (spedizoni != null)
            {
                _context.Spedizioni.Remove(spedizoni);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpedizoniExists(Guid id)
        {
            return _context.Spedizioni.Any(e => e.Id == id);
        }
    }
}
