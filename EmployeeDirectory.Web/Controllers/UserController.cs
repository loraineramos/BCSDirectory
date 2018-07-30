using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeDirectory.Web.Common;
using EmployeeDirectory.Web.Interfaces;
using EmployeeDirectory.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Web.Controllers
{
    public class UserController : Controller
    {
        public readonly IEmployeeDirectoyWebAppService _employeeDirectoryWebAppService;
        public UserController(IEmployeeDirectoyWebAppService employeeDirectoyWebAppService)
        {
            _employeeDirectoryWebAppService = employeeDirectoyWebAppService;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var users = await _employeeDirectoryWebAppService.GetAllUsers();
            return View(users);
        }

        // GET: User/Details/test
        public async Task<IActionResult> Details(string userName)
        {
            var user = await _employeeDirectoryWebAppService.GetUser(userName);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel user)
        {
            try
            {
                bool isSuccess = _employeeDirectoryWebAppService.CreateUser(Utility.UserMapper(user));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: User/Edit/test
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/test
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserViewModel user)
        {
            try
            {
                bool isSuccess = _employeeDirectoryWebAppService.UpdateUser(Utility.UserMapper(user));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }


        }

        // GET: User/Delete/test
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/test
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string userName)
        {
            try
            {
                bool isSuccess = _employeeDirectoryWebAppService.DeleteUser(userName);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}