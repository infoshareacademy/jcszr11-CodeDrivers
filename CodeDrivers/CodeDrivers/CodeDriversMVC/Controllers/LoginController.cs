using CodeDrivers.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeDriversMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult SignIn(User user)
        {
            if (!_loginService.AuthorizeUser(user.Email, user.Password))
            {
                ModelState.AddModelError("CredentialsValidationError", "Nieprawidłowy adres e-mail lub hasło.");
                return View("Index", user);
            }
            else
            {
                //TempData["ShowToast"] = "success";
                return RedirectToAction("Index", "Home");
            }
        }
        

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
