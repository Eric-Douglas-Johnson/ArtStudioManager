
namespace ArtStudioManager.Components
{
    public class ArtistCheck(Artist artist, bool sendEmail)
    {
        public Artist Artist { get; set; } = artist;
        public bool SendEmail { get; set; } = sendEmail;
    }
}
