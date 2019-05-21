using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TaxProject.com.Utilities;

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
    }
}