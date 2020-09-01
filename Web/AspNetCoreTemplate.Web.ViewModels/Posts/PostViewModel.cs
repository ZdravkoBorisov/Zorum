namespace AspNetCoreTemplate.Web.ViewModels.Posts
{
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int Likes { get; set; }

        public string Date { get; set; }
    }
}
