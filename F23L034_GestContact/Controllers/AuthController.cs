using F23L034_GestContact.Models.Bll.Entities;
using F23L034_GestContact.Models.Bll.Repositories;
using F23L034_GestContact.Models.Bll.Services;
using F23L034_GestContact.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Tools.Database;

namespace F23L034_GestContact.Controllers
{
    public class AuthController : Controller
    {
        //const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=F23L034_GestContact;Integrated Security=True;";

        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            /* Appel à la procédure stockée */

            Utilisateur? utilisateur = _authRepository.Login(form.Email, form.Passwd);

            if(utilisateur is null)
            {
                ModelState.AddModelError("", "Email ou Mot de passe incorrecte");
                return View(form);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            if(!ModelState.IsValid)
            {
                return View(form);                
            }
            
            _authRepository.Register(new Utilisateur(form.Nom, form.Prenom, form.Email, form.Passwd));

            return RedirectToAction(nameof(Login));
        }
    }
}
