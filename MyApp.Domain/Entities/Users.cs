using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Users
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string FirstName { get; private set; }
        public string? MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string ContactNumber { get; private set; }
        public bool IsActive { get; private set; }

        public int BranchId { get; private set; }
        public Branches Branch { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
