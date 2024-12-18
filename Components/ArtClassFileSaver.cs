
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;
using System.Text.Json;

namespace ArtStudioManager.Components
{
    public class ArtClassFileSaver : IModelSaver<ArtClass>
    {
        public void Save(ArtClass artClass)
        {
            var json = JsonSerializer.Serialize(artClass);
            var fileName = Environment.CurrentDirectory + @"\Files\ArtClasses\" + artClass.Id.ToString();
            File.WriteAllText(fileName, json);
        }

        public async Task SaveAsync(ArtClass artClass)
        {
            var fileName = Environment.CurrentDirectory + @"\Files\ArtClasses\" + artClass.Id.ToString();
            await using var createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, artClass);
        }
    }
}
