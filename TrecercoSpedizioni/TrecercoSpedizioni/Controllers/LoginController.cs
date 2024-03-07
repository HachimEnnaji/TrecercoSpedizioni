using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrecercoSpedizioni.data;
using TrecercoSpedizioni.Models;

namespace TrecercoSpedizioni.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public LoginController(ApplicationDbContext context, IAuthenticationSchemeProvider schemeProvider)
        {
            _db = context;
            _schemeProvider = schemeProvider;
        }
        //GET
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            Cliente? cliente = _db.Clienti.SingleOrDefault(x => x.Username == login.Username);

            if (cliente == null)
            {
                TempData["error"] = "Non esiste questo account";
                return View();

            }
            if (Password.VerifyPassword(login.Password, cliente.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, cliente.Username),
                    new Claim(ClaimTypes.Role, cliente.Usertype)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                TempData["success"] = "Login effettuato";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Password sbagliata";
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["message"] = "Logout effettuato";
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("Username,Password,TipoCliente,Nome,CodiceFiscale,PartitaIva")] Cliente cliente)
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
    }
}
