namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(
            IUsersService usersService,
            UserManager<ApplicationUser> userManager
            )
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> MyProfile()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var mostLikedPost = this.usersService.GetMostLikedPost(user.Id);

            var viewModel = new PostViewModel
            {
                Title = mostLikedPost.Title,
                Description = mostLikedPost.Description,
                ImageURL = mostLikedPost.ImageURL,
                Date = mostLikedPost.CreatedOn.ToString(),
                Likes = mostLikedPost.Likes,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> MyPosts()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var posts = this.usersService.GetPostsByUser(user.Id);

            var viewModel = new ListPostsViewModel
            {
                Posts = posts,
            };

            return this.View(viewModel);
        }
    }
}
