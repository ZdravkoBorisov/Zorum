namespace AspNetCoreTemplate.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class ListPostsViewModel : IMapFrom<Post>
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
