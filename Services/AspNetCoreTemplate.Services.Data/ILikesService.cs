using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public interface ILikesService
    {
        int GetLikes(int postId);

        Task LikeAsync(int postId, string userId);
    }
}
