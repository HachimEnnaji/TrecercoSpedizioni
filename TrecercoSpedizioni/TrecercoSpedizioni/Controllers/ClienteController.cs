using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Create(Cliente obj)
        {
            if (ModelState.IsValid && (obj.TipoCliente.ToLower() == "azienda" || obj.TipoCliente.ToLower() == "privato"))
            {
                _db.Clienti.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("TipoCliente", "Il tipo cliente deve essere azienda o privato");
                return View(obj);
            }
        }
        //GET
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
    }
}
