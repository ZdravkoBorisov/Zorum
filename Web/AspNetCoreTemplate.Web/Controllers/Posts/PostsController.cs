namespace AspNetCoreTemplate.Web.Controllers.Posts
{
    using System.Linq;
    using System.Threading.Tasks;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Posts;
    using javax.jws;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager
            )
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var postViewModel = this.postsService.GetById<PostViewModel>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var vm = new CreatePostViewModel
            {
                Categories = categories,
            };

            return this.View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var postId = await this.postsService.CreateAsync(input.Title, input.Description, input.ImageURL, input.CategoryId, user.Id);

            return this.View("/Index");
        }

        public async Task<IActionResult> Like(ListPostsViewModel inputViewModel)
        {
            var postId = inputViewModel.Posts.Select(x => x.Id).FirstOrDefault();
            await this.postsService.Like(postId);

            return this.View("/Index");
        }

        public IActionResult Trending()
        {
            var posts = this.postsService.GetTrending();

            var viewModel = new ListPostsViewModel
            {
                Posts = posts,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(PostViewModel vm)
        {
            var postId = this.postsService.GetAll().Where(x => x.Id == vm.Id).FirstOrDefault();

            await this.postsService.Delete(postId.Id);

            return this.View("/Index");
        }
    }
}
