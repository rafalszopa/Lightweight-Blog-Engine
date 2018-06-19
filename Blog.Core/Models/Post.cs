using System;
using System.Collections.Generic;

namespace Blog.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Tag> Tags { get; set; }

        public PostStatus Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime PublishDate { get; set; }

        public string PhotoUrl { get; set; }

        public PostDetails Details { get; set; }

        public User Author { get; private set; }

        public Post()
        {

        }

        public Post(string title, string description, PostStatus status, DateTime createTime, DateTime publishData, string photoUrl,
            List<Tag> tags, PostDetails postDetails, User author, int id = 0)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Tags = tags;
            this.Status = status;
            this.CreateDate = createTime;
            this.PublishDate = publishData;
            this.PhotoUrl = photoUrl;
            this.Details = postDetails;
            this.Author = author;

        }
    }
}
