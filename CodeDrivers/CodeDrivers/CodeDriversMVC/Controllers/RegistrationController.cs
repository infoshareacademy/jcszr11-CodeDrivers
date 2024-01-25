﻿using CodeDrivers;
using CodeDrivers.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using System.Reflection;

namespace CodeDriversMVC.Controllers
{
    public class RegistrationController : Controller
    {
        private const string Path = @"fakeUsers.json";

        // GET: RegistrationController
        //RegistrationService _registrationService = new RegistrationService();

        private readonly RegistrationService _registrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public ActionResult Index()
        {
            ViewData["ShowToast"] = true;

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            var validator = new UserValidationHelper();

            if (!validator.IsValidPassword(user.Password))
            {
                ModelState.AddModelError("PasswordValidationError", "Hasło musi składać się z co najmniej 8 znaków w tym co najmniej jednej cyfry.");
                return View("Index", user);
            }
            else if (!validator.IsConfirmedPassword(user.Password, Request.Form["PasswordConfirmation"]))
            {
                ModelState.AddModelError("PasswordValidationError", "Hasła nie są zgodne!");
                return View("Index", user);
            }
            else if (!validator.IsValidEmail(user.Email))
            {
                ModelState.AddModelError("EmailValidationError", "Wprowadzono niepoprawny e-mail");
                return View("Index", user);
            }
            else if (!validator.IsValidPhoneNumber(user.PhoneNumber))
            {
                ModelState.AddModelError("PhoneValidationError", "Numer telefonu powinien składać się z 9 cyfr nieodzielonych odstępami.");
                return View("Index", user);
            }
            else if (!validator.IsMoreThan18(user.DateOfBirth))
            {
                ModelState.AddModelError("DateOfBirthValidationError", "Aby zarezerwować samochód, musisz mieć ukończone 18 lat.");
                return View("Index", user);
            }
            else if(_registrationService.CheckIfEmailExits(user.Email))
            {
                ModelState.AddModelError("UserAlreadyExists", "Użytkownik o tym adresie e-mail już istnieje.");
                return View("Index", user);
            }
            else
            {
                _registrationService.Create(user);
                TempData["ShowToast"] = "success";
                return RedirectToAction("Index", "Home");
            }
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
