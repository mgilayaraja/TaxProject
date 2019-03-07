using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxProject.Core.IService;
using TaxProject.Core.Models;

namespace TaxProject.com.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(FormCollection form)
        {
            Users users = _userService.GetUsersDetailsByUserName(form["email"]);
            return View();
        }


    }
}