using System;
using System.Collections.Generic;

namespace Blog.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public PostStatus Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime PublishDate { get; set; }

        public string PhotoUrl { get; set; }

        public PostDetails Details { get; set; }

        public Post()
        {

        }
    }
}
