using System;
using System.Collections.Generic;

#nullable disable

namespace PreSemesterProject.Models.DBModels
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
