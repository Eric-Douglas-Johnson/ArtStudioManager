
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;
using Microsoft.Office.Interop.Excel;
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

                var artClass = new ArtClass();
                artClass.Id = savedArtClass.Id;
                artClass.Type = savedArtClass.Type;
                artClass.Name = savedArtClass.Name;
                artClass.Description = savedArtClass.Description;
                artClass.Start = savedArtClass.Start;
                artClass.End = savedArtClass.End;
                artClass.Instructors = savedArtClass.Instructors;
                artClass.Artists = savedArtClass.Artists;
                artClass.Cost = savedArtClass.Cost;
                artClass.MemberDiscount = savedArtClass.MemberDiscount;
                artClass.Materials = savedArtClass.Materials;
                artClass.Attendance = savedArtClass.Attendance;
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
