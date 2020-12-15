namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Users;
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
            var topPost =  this.usersService.GetTopPost(user.Id);

            var vm = new MyProfileViewModel
            {
                Image = "http://static.guim.co.uk/sys-images/Lifeandhealth/Pix/pictures/2009/3/3/1236074833250/Angry-man-001.jpg",
                Username = user.UserName,
                TopPost = topPost,
            };

            return this.View(vm);
        }

        public async Task<IActionResult> MyTopPosts()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var posts = this.usersService.GetMostLikedPosts(user.Id);

            var viewModel = new UserMostLikedPostsViewModel
            {
                Posts = posts,
            };

            return this.View(viewModel);
        }
    }
}
