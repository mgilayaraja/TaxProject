using System;

namespace TaxProject.Core.Models
{
    public class EntityBase
    {
        public Guid UserId { get; set; }
        public string EmailAddress { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public DateTime UpdateTimeStamp { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum OperationStatus
    {
        Failure,
        Success
    }
}
