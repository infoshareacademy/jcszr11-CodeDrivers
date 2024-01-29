using CodeDrivers.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace CodeDriversMVC.Controllers
{
    public class PanelUserController : Controller
    {
        private readonly PanelUserService _panelUserService;
        public PanelUserController()
        {
            _panelUserService = new PanelUserService();
        }
        //private readonly RegistrationService _registrationService;

        //public PanelUserController(RegistrationService registrationService)
        //{
        //    _registrationService = registrationService;
        //}
        // GET: PanelUserController
        public ActionResult Index()
        {
            var allUsers = _panelUserService.GetUsers();
            //var allUsers = _registrationService.GetAllUsers();
            return View(allUsers);
        }

        // GET: PanelUserController/Details/5
        public ActionResult Details(int id)
        {
            //var allUsers = _panelUserService.GetById(id);
            return View();
            
        }

        // GET: PanelUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanelUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User newUser)
        {
            _panelUserService.Create(newUser);
            TempData["SuccessUser"] = "Użytkownik został dodany.";
            return RedirectToAction(nameof(Index));
           
        }

        // GET: PanelUserController/Edit/5
        public ActionResult Edit(int id)
        {
            var allUsers = _panelUserService.GetById(id);
            return View(allUsers);
        }

        // POST: PanelUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            _panelUserService.Update(user);
            return RedirectToAction(nameof(Index));
           
        }

        // GET: PanelUserController/Delete/5
        public ActionResult Delete(int id)
        {
            var allUsers = _panelUserService.GetById(id);
            return View(allUsers);
        }

        // POST: PanelUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            //_panelUserService.Delete(id);
            TempData["DeleteUser"] = "Użytkownik został usunięty.";
            return RedirectToAction(nameof(Index));
           
        }
    }
}
