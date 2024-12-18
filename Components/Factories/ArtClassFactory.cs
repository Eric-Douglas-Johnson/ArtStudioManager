
using ArtStudioManager.Components.Interfaces;
using ArtStudioManager.Components.Models;

namespace ArtStudioManager.Components.Factories
{
    public static class ArtClassFactory
    {
        /// <summary>
        /// For creating a new ArtClass.
        /// The unique id of the ArtClass is automatically generated.
        /// </summary>
        /// <returns>ArtClass</returns>
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
