using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxProject.Core.Models;

namespace TaxProject.Core.IRepository
{
    public interface IUserRepository
    {
        Users GetUsersDetailsByUserName(string userName);
    }
}
