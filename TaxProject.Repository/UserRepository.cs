using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxProject.Core.IRepository;
using TaxProject.Core.Models;

namespace TaxProject.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool IsValidUser(string userName, string password)
        {
            using (var entity = new TaxProjectDB.TaxProjectDB())
            {
                return entity.Users.Any(a => a.USERNAME == userName && a.Password == password);
            }
        }

        public Users GetUsersDetailsByUserName(string userName)
        {
            Users users = null;
            using (var entity = new TaxProjectDB.TaxProjectDB())
            {
                var dbUser = (from u in entity.Users
                              where u.USERNAME == userName
                              select new
                              {
                                  u.USERNAME,
                                  u.Password,
                                  u.Salary
                              }).SingleOrDefault();

                if (dbUser != null)
                {
                    users = new Users();
                    users.EmailAddress = dbUser.USERNAME;
                    users.Password = dbUser.Password;
                    users.Salary = dbUser.Salary.Value;
                }
            }
            return users;
        }
    }
}
