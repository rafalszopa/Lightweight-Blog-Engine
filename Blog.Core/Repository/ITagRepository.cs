using Blog.Core.Models;
using System.Collections.Generic;

namespace Blog.Core.Repository
{
    public interface ITagRepository
    {
        int Add(Tag tag);

        void AddMany(IEnumerable<Tag> tags);

        int DeleteByName(string tagName);

        Tag GetByName(string tagName);

        IEnumerable<Tag> GetTagsByPostId(int postId);

        IEnumerable<Tag> GetAll();
    }
}
