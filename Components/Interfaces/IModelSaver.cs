namespace ArtStudioManager.Components.Interfaces
{
    /// <summary>
    /// A form of strategy pattern that allows different data saving implementations.
    /// The Save method saves the provided model instance data to storage.
    /// </summary>
    /// <typeparam name="T">The type of model needing data save</typeparam>
    public interface IModelSaver<T> where T : class
    {
        void Save(T modelInstance);
        Task SaveAsync(T modelInstance);
    }
}
