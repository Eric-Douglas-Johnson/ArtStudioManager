

namespace ArtStudioManager.Components
{
    public class ClassTestSaver : IEntitySaver<ArtClass>
    {
        public Task Save(ArtClass artClass)
        {
            //where to save? should probably just define file saver and file loader implementations
            return Task.CompletedTask;
        }
    }
}
