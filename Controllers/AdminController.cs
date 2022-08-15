using Library.Data.Interfaces;
using Library.Data.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        private IAllUsers allUsers;
        public AdminController(IAllUsers allUsers)
        {
            this.allUsers = allUsers;
        }
        public IActionResult Index()
        {
            IEnumerable<User> Users = allUsers.Users;
            AdminViewModel obj = new AdminViewModel
            {
                Users = Users
            };
            return View(obj);
        }
        [HttpPost]
        public IActionResult AccauntControl(User user)
        {
            if (ModelState.IsValid && allUsers.ValidUser(user))
            {
                allUsers.UpdateUser(user);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("ValidUser", "Что-то не так с данными.");
            }
            return View(user);
        }
        public ViewResult AccauntControl(int id)
        {
            User user = allUsers.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewUser(User user)
        {
            if (ModelState.IsValid && allUsers.ValidNewUser(user))
            {
                allUsers.UpdateUser(user);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("ValidUser", "Что-то не так с данными.");
            }
            return View(user);
        }
        public IActionResult UserDelete(int id)
        {
            allUsers.UserDelete(id);
            return RedirectToAction("Index");
        }
    }
}
