using System.Collections.Generic;

namespace PreSemesterProject.Models
{
    public class User
    {
        public User()
        {
            Roles = new List<string>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<string> Roles { get; set; }

    }
}
