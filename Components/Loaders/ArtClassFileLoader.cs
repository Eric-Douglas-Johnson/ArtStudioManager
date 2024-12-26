
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;

namespace ArtStudioManager.Components.Loaders
{
    public class ArtClassFileLoader : IModelLoader<ArtClass>
    {
        private readonly string _artClassFolderPath;

        public ArtClassFileLoader(string artClassFolderPath)
        {
            _artClassFolderPath = artClassFolderPath;
        }

        public void Load(ArtClass artClass)
        {
            var targetFile = _artClassFolderPath + artClass.Id.ToString();
            if (!File.Exists(targetFile)) { throw new FileNotFoundException(); }

            using var fileStream = File.OpenRead(targetFile);
            using var reader = new StreamReader(fileStream);

            if (!Enum.TryParse(reader.ReadLine(), out ArtClassType type)) 
            { 
                throw new InvalidOperationException("Art class type is not valid"); 
            }

            artClass.Type = type;
            artClass.Name = reader.ReadLine();
            artClass.Description = reader.ReadLine();
            artClass.Start = DateTime.Parse(reader.ReadLine()!);
            artClass.End = DateTime.Parse(reader.ReadLine()!);
            artClass.Cost = decimal.Parse(reader.ReadLine()!);

            string currentLine;
            while (!reader.EndOfStream)
            {
                currentLine = reader.ReadLine()!;

                if (currentLine == typeof(FlatRateDiscount).ToString())
                {
                    artClass.MemberDiscount = new FlatRateDiscount(decimal.Parse(reader.ReadLine()!));
                }
                else if (currentLine == typeof(PercentageDiscount).ToString())
                {
                    artClass.MemberDiscount = new PercentageDiscount(decimal.Parse(reader.ReadLine()!), decimal.Parse(reader.ReadLine()!));
                }
                else if (currentLine == typeof(Instructor).ToString())
                {

                }
            }
        }

        public Task LoadAsync(ArtClass entityObj)
        {
            throw new NotImplementedException();
        }
    }
}
