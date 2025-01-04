
namespace ArtStudioManager.Components.Models
{
    public abstract partial class Artist
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Email { get; set; }
        public string? ReferredBy { get; set; }
        public DateOnly? Birthday { get; set; }
        public string Groups { get; set; } = string.Empty;

        public Artist()
        {
            Id = Guid.NewGuid();
        }

        public abstract ArtistType GetArtistType();
    }
}
