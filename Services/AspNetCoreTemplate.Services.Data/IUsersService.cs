namespace AspNetCoreTemplate.Services.Data
{
    using AspNetCoreTemplate.Data.Models;
    using System.Collections.Generic;

    public interface IUsersService
    {
        IEnumerable<Post> GetPostsByUser(string userId);

        Post GetMostLikedPost(string userId);
    }
}
