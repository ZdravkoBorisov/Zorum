namespace AspNetCoreTemplate.Web.ViewModels.Users
{
    using AspNetCoreTemplate.Data.Models;

    public class MyProfileViewModel
    {
        public string Username { get; set; }

        public string Image { get; set; }

        public Post TopPost { get; set; }
    }
}
