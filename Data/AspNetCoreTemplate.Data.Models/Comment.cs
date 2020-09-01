namespace AspNetCoreTemplate.Data.Models
{
    using AspNetCoreTemplate.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Text { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
