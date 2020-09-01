using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Data;
using AspNetCoreTemplate.Web.ViewModels.Likes;
using Microsoft.AspNetCore.Authorization;
namespace AspNetCoreTemplate.Web.Controllers.Posts
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;

        public LikesController(
            IPostsService postsService,
            UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.userManager = userManager;
        }

        // POST /api/votes
        // Request body: {"postId":1,"isUpVote":true}
        // Response body: {"votesCount":16}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post(LikesInputViewModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.postsService.Like(input.PostId);

            return new LikeResponseViewModel { Count = }
        }
    }
}
