
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;

namespace ArtStudioManager.Components.Factories
{
    public static class ArtClassFactory
    {
        public static ArtClass Create()
        {

            return new ArtClass(Guid.NewGuid());
        }

        public static ArtClass Create(Guid id, IModelLoader<ArtClass> modelLoader)
        {
            var newClass = new ArtClass(id);
            modelLoader.Load(newClass);
            return newClass;
        }
    }
}
