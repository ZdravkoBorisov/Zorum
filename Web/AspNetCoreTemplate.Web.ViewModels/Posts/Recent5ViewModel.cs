namespace AspNetCoreTemplate.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class Recent5ViewModel : IMapFrom<Post>
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
