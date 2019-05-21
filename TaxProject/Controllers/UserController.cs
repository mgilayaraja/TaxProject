using System;
using System.Web;
using System.Web.Mvc;
using TaxProject.com.Utilities;
using TaxProject.Core.Models;
using Newtonsoft.Json;

namespace TaxProject.com.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
        }

        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(FormCollection form)
        {
            Users users = new Users();
            users.EmailAddress = "babu";
            users.Password = "123123";

            string data = "username=" + users.EmailAddress + "&password=" + users.Password + "&grant_type=password";
            using (var client = new ApiClient("token", "POST"))
            {
                string jsonString = JsonConvert.SerializeObject(users);
                string token = client.PostAsAsync("token", data);
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(token);

                HttpCookie StudentCookies = new HttpCookie("accesstoken");
                StudentCookies.Value = rootObject.access_token;
                StudentCookies.Expires = DateTime.Now.AddDays(30);
                this.ControllerContext.HttpContext.Response.Cookies.Add(StudentCookies);
                return RedirectToAction("dashboard", "home");
            }
        }
    }

    public class RootObject
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}