namespace ArtStudioManager.Components.Interfaces
{
    /// <summary>
    /// A form of strategy pattern that allows different data loading implementations.
    /// The Load method loads data into the entity object.
    /// </summary>
    /// <typeparam name="T">The type of object needing data load</typeparam>
    public interface IModelLoader<T> where T : class
    {
        void Load(T entityObj);
        Task LoadAsync(T entityObj);
    }
}
