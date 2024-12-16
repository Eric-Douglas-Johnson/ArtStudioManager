
namespace ArtStudioManager.Components
{
    public class NonMember : Artist
    {
        public NonMember() : base() { }

        public NonMember(IEntityLoader<NonMember> dataLoader)
        {
            dataLoader.Load(this);
        }

        public override ArtistType GetArtistType()
        {
            return ArtistType.NonMember;
        }
    }
}
