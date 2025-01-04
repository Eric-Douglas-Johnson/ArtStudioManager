
using ArtStudioManager.Components.Interfaces;

namespace ArtStudioManager.Components.Models
{
    public class NonMember : Artist
    {
        public NonMember() : base() { }

        public NonMember(Guid id)
        {
            base.Id = id;
        }

        public override ArtistType GetArtistType()
        {
            return ArtistType.NonMember;
        }
    }
}
