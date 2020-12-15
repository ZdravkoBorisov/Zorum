namespace AspNetCoreTemplate.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<Post> repositoryPosts;

        public UsersService(IDeletableEntityRepository<Post> repositoryPosts)
        {
            this.repositoryPosts = repositoryPosts;
        }

        public IEnumerable<Post> GetMostLikedPosts(string userId)
        {
            var post = this.repositoryPosts
                .All()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Likes)
                .Take(5)
                .ToList();

            return post;
        }

        public IEnumerable<Post> GetPostsByUser(string userId)
        {
            var posts = this.repositoryPosts
                .All()
                .Where(x => x.UserId == userId)
                .ToList();

            return posts;
        }

        public Post GetTopPost(string userId)
        {
            var topPost = this.repositoryPosts
                .All()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Likes)
                .FirstOrDefault();

            return topPost;
        }
    }
}
