namespace ArtStudioManager.Components.Interfaces
{
    /// <summary>
    /// A form of strategy pattern that allows different data saving implementations.
    /// The Save method saves the entity object to some storage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelSaver<T> where T : class
    {
        void Save(T entityObj);
        Task SaveAsync(T entityObj);
    }
}
