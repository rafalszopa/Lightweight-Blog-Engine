using System;

namespace Blog.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public DateTime CreateTime { get; set; }

        public UserType Type { get; set; }

        public User()
        {

        }
    }
}
