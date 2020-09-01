using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreTemplate.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<Post> repositoryPosts;

        public UsersService(IDeletableEntityRepository<Post> repositoryPosts)
        {
            this.repositoryPosts = repositoryPosts;
        }

        public Post GetMostLikedPost(string userId)
        {
            var post = this.repositoryPosts
                .All()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Likes)
                .FirstOrDefault();

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
    }
}
