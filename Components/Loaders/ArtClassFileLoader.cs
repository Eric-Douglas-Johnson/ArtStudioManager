
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;
using System.Text.Json;

namespace ArtStudioManager.Components.Loaders
{
    public class ArtClassFileLoader : IEntityLoader<ArtClass>
    {
        public Task Load(ArtClass artClass)
        {
            var targetFile = Environment.CurrentDirectory + @"\Files\ArtClasses\" + artClass.Id.ToString();
            if (!File.Exists(targetFile)) { throw new FileNotFoundException(); }

            using var fileStream = File.OpenRead(targetFile);
            using var reader = new StreamReader(fileStream);
            var dataStr = reader.ReadToEnd();

            var savedArtClass = JsonSerializer.Deserialize<ArtClass>(dataStr) ?? 
                throw new InvalidOperationException("Art Class file was found, but there was no object data.");

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

            return Task.CompletedTask;
        }
    }
}
