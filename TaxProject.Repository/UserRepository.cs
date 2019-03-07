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
        public Users GetUsersDetailsByUserName(string userName)
        {
            Users users = null;
            using (var entity = new TaxProjectDB.TaxProjectDB())
            {
                var dbUser = (from u in entity.LOGINs
                              where u.USERNAME == userName
                              select new
                              {
                                  u.USERNAME,
                                  u.PASSWORD,
                              }).SingleOrDefault();

                if (dbUser != null)
                {
                    users = new Users();
                    users.EmailAddress = dbUser.USERNAME;
                    users.Password = dbUser.PASSWORD;
                }
            }
            return users;
        }
    }
}
