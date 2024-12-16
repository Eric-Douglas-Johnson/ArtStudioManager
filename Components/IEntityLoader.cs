
namespace ArtStudioManager.Components
{
    /// <summary>
    /// A form of strategy pattern that allows different data loading implementations.
    /// The Load method loads data into the entity object.
    /// </summary>
    /// <typeparam name="T">The type of object needing data load</typeparam>
    public interface IEntityLoader<T> where T : class
    {
        Task Load(T entityObj);
    }
}
