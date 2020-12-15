namespace AspNetCoreTemplate.Services.Data
{
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostsService : IPostsService
    {
        private IDeletableEntityRepository<Post> repositoryPosts;

        public PostsService(IDeletableEntityRepository<Post> repositoryPosts)
        {
            this.repositoryPosts = repositoryPosts;
        }

        public async Task<int> CreateAsync(string title, string description, string imageURL, int categoryId, string userId)
        {
            var post = new Post
            {
                Title = title,
                Description = description,
                ImageURL = imageURL,
                CategoryId = categoryId,
                UserId = userId,
            };

            await this.repositoryPosts.AddAsync(post);
            await this.repositoryPosts.SaveChangesAsync();

            return post.Id;
        }

        public async Task Delete(int postId)
        {
            var post = this.repositoryPosts
                .All()
                .Where(x => x.Id == postId)
                .FirstOrDefault();

            if (post != null)
            {
                this.repositoryPosts.Delete(post);
            }

            await this.repositoryPosts.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            var posts = this.repositoryPosts.All();

            return posts.ToList();
        }

        public T GetById<T>(int postId)
        {
            var post = this.repositoryPosts
                .All()
                .Where(x => x.Id == postId)
                .To<T>()
                .FirstOrDefault();

            return post;
        }

        public IEnumerable<Post> GetRecent5()
        {
            IQueryable<Post> posts = this.repositoryPosts
                .All()
                .OrderBy(x => x.CreatedOn);

            return posts.ToList();
        }

        public IEnumerable<Post> GetTrending()
        {
            var posts = this.repositoryPosts
                .All()
                .OrderByDescending(x => x.Likes)
                .ToList();

            return posts;
        }


        public async Task Like(int postId)
        {
            var post = this.repositoryPosts
                .All()
                .Where(x => x.Id == postId)
                .FirstOrDefault();

            post.Likes += 1;

            await this.repositoryPosts.SaveChangesAsync();
        }
    }
}
