
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

        public Artist() { }

        public abstract ArtistType GetArtistType();
    }

    public class Member : Artist
    {
        public enum MembershipType
        {
            Student,
            Single,
            Family
        }

        public string? Id { get; set; }      
        public MembershipType MemberType { get; set; }
        public DateOnly? DateJoined { get; set; }

        public Member() : base() { }

        public Member(IDataLoader<Member> dataLoader)
        {
            dataLoader.Load(this);
        }

        public override ArtistType GetArtistType()
        {
            return ArtistType.Member;
        }
    }

    public class NonMember : Artist
    {
        public NonMember() : base() { }

        public NonMember(IDataLoader<NonMember> dataLoader)
        {
            dataLoader.Load(this);
        }

        public override ArtistType GetArtistType()
        {
            return ArtistType.NonMember;
        }
    }
}
