using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrecercoSpedizioni.data;
using TrecercoSpedizioni.Models;

namespace TrecercoSpedizioni.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public IActionResult Index()
        {
            IEnumerable<Cliente> objList = _db.Clienti;
            return View(objList);
        }
        //GET

        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Cliente cliente)
        {
            if (cliente.TipoCliente.ToLower() == "azienda" || cliente.TipoCliente.ToLower() == "privato")
                try
                {


                    string HashedPassword = Password.HashPassword(cliente.Password);
                    cliente.Password = HashedPassword;
                    _db.Clienti.Add(cliente);

                    _db.SaveChanges();
                    TempData["message"] = "Cliente aggiunto con successo";
                    //ritorna a Home Index
                    return RedirectToAction("Index", "Home");
                }

                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ERROREEE" + ex.Message);
                    ModelState.AddModelError("TipoCliente", "Il tipo cliente deve essere azienda o privato");
                }
            return View(cliente);
        }

        //GET
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return View("Error");
            }
            var obj = _db.Clienti.Find(id);
            if (obj == null)
            {
                return View("Error");

            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Cliente obj)
        {
            if (ModelState.IsValid)
            {
                string HashedPassword = Password.HashPassword(obj.Password);
                obj.Password = HashedPassword;
                _db.Clienti.Update(obj);
                _db.SaveChanges();
                TempData["message"] = "Cliente modificato con successo";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return View("Error");
            }
            var obj = _db.Clienti.Find(id);
            if (obj == null)
            {
                return View("Error");

            }
            return View(obj);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _db.Clienti.FirstOrDefaultAsync(m => m.idCliente == id);
            if (obj == null)
            {
                return View("Error");

            }
            _db.Clienti.Remove(obj);
            _db.SaveChanges();
            TempData["error"] = "Cliente eliminato con successo";
            return RedirectToAction("Index");
        }
        //GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _db.Clienti
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);

        }
    }
}
