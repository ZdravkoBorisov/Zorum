namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels;
    using AspNetCoreTemplate.Web.ViewModels.Posts;

    public class HomeController : BaseController
    {
        private readonly IPostsService postsService;

        public HomeController(
             IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult Index()
        {
            var posts = this.postsService.GetAll();

            var vm = new ListPostsViewModel
            {
                Posts = posts,
            };

            return this.View(vm);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
