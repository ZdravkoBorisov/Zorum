namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AspNetCoreTemplate.Data.Models;

    public interface IUsersService
    {
        IEnumerable<Post> GetPostsByUser(string userId);

        IEnumerable<Post> GetMostLikedPosts(string userId);

        Post GetTopPost(string userId);
    }
}
