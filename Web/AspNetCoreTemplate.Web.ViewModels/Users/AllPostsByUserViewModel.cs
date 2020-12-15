namespace AspNetCoreTemplate.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class AllPostsByUserViewModel : IMapFrom<Post>
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
