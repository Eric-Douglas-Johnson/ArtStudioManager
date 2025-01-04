
using ArtStudioManager.Components.Interfaces;

namespace ArtStudioManager.Components.Models
{
    public partial class Member : Artist
    {
        public string? MemberId { get; set; }
        public MembershipType MemberType { get; set; }
        public DateOnly? DateJoined { get; set; }

        public Member() : base() { }

        public Member(Guid artistId)
        {
            base.Id = artistId;
        }

        public override ArtistType GetArtistType()
        {
            return ArtistType.Member;
        }
    }
}
