using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxProject.Core.Models
{
    public class Users : EntityBase
    {
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

        public string PhoneNumber { get; set; }
        public bool IsGoogle { get; set; }
        public string GoogleId { get; set; }
        public bool IsFacebook { get; set; }
        public string FacebookId { get; set; }
        public string OTPNumber { get; set; }
        public string IPAddress { get; set; }
        public bool IsValidUser { get; set; }
        public OperationStatus OperationStatus { get; set; }
    }
}
