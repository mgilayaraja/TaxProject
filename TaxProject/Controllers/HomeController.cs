using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TaxProject.com.Utilities;
using TaxProject.Core.Models;

namespace TaxProject.com.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async System.Threading.Tasks.Task<ActionResult> dashboard()
        {
            string accessToken = Request.Cookies["accesstoken"].Value;
            using (var client = new ApiClient("user/GetEmailAddressById?userName=babu", "GET"))
            {
                client.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), "`Bearer` " + accessToken);
                HttpResponseMessage Res = await client.GetAsync("user/GetEmailAddressById?userName=babu");
            }
            return View();
        }

        public PartialViewResult Service()
        {
            Thread.Sleep(1000); // To show the loader
            List<Users> lstUsers = new List<Users>();

            Users users = new Users();
            users.UserId = Guid.NewGuid();
            users.EmailAddress = "mgilayaraja@gmail.com";
            users.PhoneNumber = "9600440135";
            users.Salary = 20000;
            lstUsers.Add(users);

            users = new Users();
            users.UserId = Guid.NewGuid();
            users.EmailAddress = "babu@gmail.com";
            users.PhoneNumber = "9898554755";
            users.Salary = 30000;
            lstUsers.Add(users);

            users = new Users();
            users.UserId = Guid.NewGuid();
            users.EmailAddress = "Senthil@gmail.com";
            users.PhoneNumber = "987456321";
            users.Salary = 40000;
            lstUsers.Add(users);

            return PartialView(lstUsers);
        }

        public PartialViewResult Clients()
        {
            Thread.Sleep(1000);// To show the loader
            List<Users> lstUsers = new List<Users>();

            Users users = new Users();
            users.EmailAddress = "BizWiz";
            users.PhoneNumber = "9600440135";
            users.Salary = 20000;
            lstUsers.Add(users);

            users = new Users();
            users.EmailAddress = "Payticks";
            users.PhoneNumber = "9898554755";
            users.Salary = 30000;
            lstUsers.Add(users);

            users = new Users();
            users.EmailAddress = "ADP";
            users.PhoneNumber = "987456321";
            users.Salary = 40000;
            lstUsers.Add(users);

            return PartialView(lstUsers);
        }
    }
}