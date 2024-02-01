using CodeDrivers.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeDriversMVC.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: RegistrationController
        RegistationService _registrationService = new RegistationService();
        
        public ActionResult Index()
        {
            //ViewData["ShowToast"] = true;

            //return View();
            var allUsers = _registrationService.GetAll();
            return View(allUsers);
        }
        
        [HttpPost]
        public ActionResult Register(User user)
        {
            _registrationService.AddNewUser(user);
            TempData["ShowToast"] = true;

            return RedirectToAction("Index", "Home");

        }


        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {
            var allUsers = _registrationService.GetById(id);
            return View(allUsers);
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            return View(new User());
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            _registrationService.Create(user);
            TempData["SuccessUser"] = "Użytkownik został dodany do listy.";
            return RedirectToAction(nameof(Index));
          
        }

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            var allUsers = _registrationService.GetById(id);
            return View(allUsers);
            
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User userToEdit)
        {
            _registrationService.Update(userToEdit);
            return RedirectToAction(nameof(Index));
          
        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            var userToBeRemoved = _registrationService.GetById(id);
            return View(userToBeRemoved);
           
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User userToBeRemoved)
        {
            _registrationService.Remove(id);
            TempData["DeleteUser"] = "Użytkownik został usunięty z listy.";
            return RedirectToAction(nameof(Index));
        }
    }
}
