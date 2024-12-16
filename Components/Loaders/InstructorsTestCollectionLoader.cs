using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;

namespace ArtStudioManager.Components.Loaders
{
    public class InstructorsTestCollectionLoader : ICollectionLoader<Instructor>
    {
        public Task Load(ICollection<Instructor> collectionToLoadInto)
        {
            collectionToLoadInto.Add(
                new Instructor()
                {
                    Name = "Eric Johnson",
                    Email = "e_d_johnson2003@yahoo.com"
                }
            );

            collectionToLoadInto.Add(
                new Instructor()
                {
                    Name = "Paula Ramos",
                    Email = "someemail@yahoo.com"
                }
            );

            collectionToLoadInto.Add(
                new Instructor()
                {
                    Name = "Karen Somethingorother",
                    Email = "bobrye@yahoo.com"
                }
            );

            collectionToLoadInto.Add(
                new Instructor()
                {
                    Name = "Dave Cannotremember",
                    Email = "apple@yahoo.com"
                }
            );

            return Task.CompletedTask;
        }
    }
}
