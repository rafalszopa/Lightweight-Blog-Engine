using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Blog.MVC.ViewModels
{
    public class PostTeaserViewModel
    {
        public class User
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string Avatar { get; set; }

            public string FullName { get => String.Format("{0} {1}", this.FirstName, this.LastName); }
        }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Thumbnail { get; set; }

        public User Author { get; set; }

        public string _tags { get; set; }

        public List<string> Tags { get => _tags.Split(",").ToList(); }

        public string PublishedOnFormatted { get => String.Format("{0} {1} {2}", this.PublishedOn.Year, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.PublishedOn.Month), this.PublishedOn.Day); }
    }
}
