namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Models;

    public interface IPostsService
    {
        Task<int> CreateAsync(string title, string description, string imageURL, int categoryId, string userId);

        IEnumerable<Post> GetRecent5();

        T GetById<T>(int postId);

        Task Delete(int postId);

        IEnumerable<Post> GetAll();

        Task Like(int postId);

        IEnumerable<Post> GetTrending();
    }
}
