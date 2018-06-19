using System;

namespace Blog.Core.Models
{
    public class User
    {
        #region

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public UserType Type { get; set; }

        public DateTime CreateTime { get; private set; }
        
        public bool IsActive { get; set; }

        #endregion

        #region Constructors

        public User() { }

        // For creating new users that are not in database yet
        public User(string firstName, string lastName, string email, string bio, UserType userType, bool isActive)
            : this(0, firstName, lastName, DateTime.Now, email, bio, userType, isActive) { }

        // Used for creating users from database
        public User(int id, string firstName, string lastName, DateTime createTime, string email, string bio, UserType userType, bool isActive)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Bio = bio;
            this.Type = userType;
            this.CreateTime = createTime;
            this.IsActive = isActive;
        }

        #endregion
    }
}
