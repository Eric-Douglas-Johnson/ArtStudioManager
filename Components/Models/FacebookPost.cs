namespace ArtStudioManager.Components.Models
{
    public class FacebookPost
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public ICollection<string>? ImageFiles { get; set; }
    }
}
