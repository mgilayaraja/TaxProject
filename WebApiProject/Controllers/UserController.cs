using System;
using System.Web.Http;
using TaxProject.Core.IService;
using TaxProject.Core.Models;

namespace WebApiProject.Controllers
{
    public class UserController : ApiController
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpGet]
        public bool IsValidUser(string userName,string password)
        {
            return _userService.IsValidUser(userName, password);
        }

        [HttpGet]
        [Authorize]
        public Users GetEmailAddressById(string userName)
        {
            Users users = _userService.GetUsersDetailsByUserName(userName);
            return users;
        }

    }
}
