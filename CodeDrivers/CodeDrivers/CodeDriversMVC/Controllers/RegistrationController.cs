using CodeDrivers.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CodeDriversMVC.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: RegistrationController
        RegistationService _registrationService = new RegistationService();

        public ActionResult Index()
        {
            ViewData["ShowToast"] = true;

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ValidatePassword(user.Password, Request.Form["PasswordConfirmation"]))
            {
                _registrationService.AddNewUser(user);
                ViewData["ShowToast"] = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Password", "Hasła nie są zgodne lub nie spełniają wymaganych kryteriów.");
            }

            // Jeśli ModelState nie jest prawidłowy, zwróć użytkownika do widoku rejestracji z błędami
            return View(user);

        }
        private bool ValidatePassword(string password, string passwordConfirmation)
        {
            // Logika walidacji hasła
            return password == passwordConfirmation && password.Length >= 8 && password.Any(char.IsDigit) && password.Any(char.IsUpper);
        }


        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationController/Create
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

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
