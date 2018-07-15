using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.MVC.ViewModels
{
    public class HomePageViewModel
    {
        public class User
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string Avatar { get; set; }
        }

        public string Slug { get; set; }

        public  string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Thumbnail { get; set; }

        public User Author { get; set; }

        public string _tags { get; set; }

        public List<string> Tags
        {
            get
            {
                return _tags.Split(",").ToList();
            }

            set
            {
                _tags = string.Join(",", value);
            }
        }
    }
}
