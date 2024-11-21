
namespace ArtStudioManager.Components
{
    /// <summary>
    /// A form of strategy pattern that allows different data loading implementations
    /// </summary>
    /// <typeparam name="T">The type of object needing data load</typeparam>
    public interface IDataLoader<T>
    {
        Task Load(T loadObj);
    }
}
