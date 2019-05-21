using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxProject.Core.IService;
using TaxProject.Core.IRepository;
using TaxProject.Core.Models;

namespace TaxProject.Service
{
    public class UserService: IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public bool IsValidUser(string userName, string password)
        {
            return _userRepository.IsValidUser( userName,  password);
        }
        public Users GetUsersDetailsByUserName(string userName)
        {
            return _userRepository.GetUsersDetailsByUserName(userName);
        }
    }
}
