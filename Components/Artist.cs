
namespace ArtStudioManager.Components
{
    public abstract class Artist
    {
        public enum ArtistType
        {
            Member,
            NonMember
        }

        public string? Name { get; set; }

        public abstract ArtistType GetArtistType();
    }

    public class Member : Artist
    {
        public string? Id { get; set; }

        public override ArtistType GetArtistType()
        {
            return ArtistType.Member;
        }
    }

    public class NonMember : Artist
    {
        public string? ReferredBy { get; set; }

        public override ArtistType GetArtistType()
        {
            return ArtistType.NonMember;
        }
    }
}
