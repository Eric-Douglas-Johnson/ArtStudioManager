
namespace ArtStudioManager.Components
{
    /// <summary>
    /// A form of strategy pattern that allows different data saving implementations.
    /// The Save method saves the entity object to some storage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntitySaver<T> where T : class
    {
        Task Save(T entityObj);
    }
}
