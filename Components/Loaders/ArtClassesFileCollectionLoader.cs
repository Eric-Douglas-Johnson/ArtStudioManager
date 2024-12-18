
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;
using System.Text.Json;

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
                using var fileStream = File.OpenRead(file.FullName);
                using var reader = new StreamReader(fileStream);
                var dataStr = reader.ReadToEnd();

                var savedArtClass = JsonSerializer.Deserialize<ArtClass>(dataStr) ??
                    throw new InvalidOperationException("Art Class file was found, but there was no object data.");

                artClasses.Add(savedArtClass);
            }
        }

        public Task LoadAsync(ICollection<ArtClass> artClasses)
        {
            var targetFolderName = Environment.CurrentDirectory + @"\Files\ArtClasses";
            var directoryInfo = new DirectoryInfo(targetFolderName);

            foreach (var file in directoryInfo.GetFiles())
            {

            }

            return Task.CompletedTask;
        }
    }
}
