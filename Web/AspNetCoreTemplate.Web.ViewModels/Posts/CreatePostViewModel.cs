namespace AspNetCoreTemplate.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class CreatePostViewModel : IMapFrom<Post>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 10)]
        public string Description { get; set; }

        [StringLength(100, MinimumLength = 8)]
        public string ImageURL { get; set; }

        [Required]
        [Display(Name = "Categories")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
