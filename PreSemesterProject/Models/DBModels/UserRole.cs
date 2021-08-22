using System;
using System.Collections.Generic;

#nullable disable

namespace PreSemesterProject.Models.DBModels
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
