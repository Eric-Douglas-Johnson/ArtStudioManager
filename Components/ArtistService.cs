
using System.Collections.ObjectModel;

namespace ArtStudioManager.Components
{
    public static class ArtistService
    {
        public static ICollection<Member> GetMembers(ICollectionLoader<Member> memberLoader)
        {
            var members = new Collection<Member>();
            memberLoader.Load(members);
            return members;
        }
    }
}
