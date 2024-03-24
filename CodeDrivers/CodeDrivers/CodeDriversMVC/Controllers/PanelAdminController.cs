using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeDriversMVC.Controllers
{
    public class PanelAdminController : Controller
    {
        
        // GET: PanelAdminController
        public ActionResult Index()
        {

            return View();
        }

        // GET: PanelAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PanelAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanelAdminController/Create
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

        // GET: PanelAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PanelAdminController/Edit/5
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

        // GET: PanelAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PanelAdminController/Delete/5
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
