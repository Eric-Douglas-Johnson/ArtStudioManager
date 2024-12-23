namespace ArtStudioManager.Components.Interfaces
{
    /// <summary>
    /// A form of strategy pattern that allows different data loading implementations.
    /// The Load method populates the provided model instance.
    /// </summary>
    /// <typeparam name="T">The type of model needing data load</typeparam>
    public interface IModelLoader<T> where T : class
    {
        void Load(T modelInstance);
        Task LoadAsync(T modelInstance);
    }
}
