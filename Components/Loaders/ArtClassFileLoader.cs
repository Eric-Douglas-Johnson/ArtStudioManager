
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;
using System.Text.Json;

namespace ArtStudioManager.Components.Loaders
{
    public class ArtClassFileLoader : IModelLoader<ArtClass>
    {
        public void Load(ArtClass artClass)
        {
            var targetFile = Environment.CurrentDirectory + @"\Files\ArtClasses\" + artClass.Id.ToString();
            if (!File.Exists(targetFile)) { throw new FileNotFoundException(); }

            using var fileStream = File.OpenRead(targetFile);
            using var reader = new StreamReader(fileStream);
            var dataStr = reader.ReadToEnd();

            var savedArtClass = JsonSerializer.Deserialize<ArtClass>(dataStr) ?? 
                throw new InvalidOperationException("Art Class file was found, but there was no object data.");

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

        public Task LoadAsync(ArtClass entityObj)
        {
            throw new NotImplementedException();
        }
    }
}
