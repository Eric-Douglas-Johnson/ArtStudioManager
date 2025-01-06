
using ArtStudioManager.Components.Factories;
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;

namespace ArtStudioManager.Components.Loaders
{
    public class ArtClassesFileCollectionLoader : ICollectionLoader<ArtClass>
    {
        public void Load(ICollection<ArtClass> artClasses)
        {
            var targetFolderName = Environment.CurrentDirectory + @"\Files\ArtClasses";
            var directoryInfo = new DirectoryInfo(targetFolderName);

            foreach (var file in directoryInfo.GetFiles())
            {
                var artClassLoader = new ArtClassFileLoader(targetFolderName);
                var loadedArtClassInstance = ArtClassFactory.Create(Guid.Parse(file.Name), artClassLoader);
                artClasses.Add(loadedArtClassInstance);
            }
        }

        public Task LoadAsync(ICollection<ArtClass> artClasses)
        {
            var targetFolderName = Environment.CurrentDirectory + @"\Files\ArtClasses";
            var directoryInfo = new DirectoryInfo(targetFolderName);

            foreach (var file in directoryInfo.GetFiles())
            {
                var artClassLoader = new ArtClassFileLoader(targetFolderName);
                var loadedArtClassInstance = ArtClassFactory.Create(Guid.Parse(file.Name), artClassLoader);
                artClasses.Add(loadedArtClassInstance);
            }

            return Task.CompletedTask;
        }
    }
}
