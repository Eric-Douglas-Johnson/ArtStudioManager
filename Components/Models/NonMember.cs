
using ArtStudioManager.Components.Interfaces;

namespace ArtStudioManager.Components.Models
{
    public class NonMember : Artist
    {
        public NonMember() : base() { }

        public NonMember(IModelLoader<NonMember> dataLoader)
        {
            dataLoader.Load(this);
        }

        public override ArtistType GetArtistType()
        {
            return ArtistType.NonMember;
        }
    }
}
