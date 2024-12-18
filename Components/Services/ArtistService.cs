
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;
using System.Collections.ObjectModel;

namespace ArtStudioManager.Components.Services
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
