namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;

    public class LikesService : ILikesService
    {
        private readonly IRepository<Like> likesRepository;

        public LikesService(IRepository<Like> likesRepository)
        {
            this.likesRepository = likesRepository;
        }

        public int GetLikes(int postId)
        {
            var likes = this.likesRepository.All()
                   .Where(x => x.PostId == postId)
                   .FirstOrDefault();

            return likes;
        }

        public Task LikeAsync(int postId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
