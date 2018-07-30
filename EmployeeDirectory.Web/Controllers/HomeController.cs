using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeDirectory.Web.Models;
using EmployeeDirectoryProcessor.Model;
using EmployeeDirectory.Web.Interfaces;

namespace EmployeeDirectory.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IEmployeeDirectoyWebAppService _employeeDirectoryWebAppService;
        public HomeController(IEmployeeDirectoyWebAppService employeeDirectoyWebAppService)
        {
            _employeeDirectoryWebAppService = employeeDirectoyWebAppService;
        }
        public ActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(UserModel user)
        //{
        //    // this action is for handle post (login)
        //    if (ModelState.IsValid) // this is check validity
        //    {
        //        using (MyDatabaseEntities dc = new MyDatabaseEntities())
        //        {
        //            var v = dc.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
        //            if (v != null)
        //            {
        //                Session["LogedUserID"] = v.UserID.ToString();
        //                Session["LogedUserFullname"] = v.FullName.ToString();
        //                return RedirectToAction("AfterLogin");
        //            }
        //        }

                
        //    }
        //    return View(u);
        //}
    }
}
