namespace ArtStudioManager.Components.Interfaces
{
    /// <summary>
    /// A form of strategy pattern that allows different data loading implementations.
    /// The Load method loads data into the collection object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICollectionLoader<T> where T : class
    {
        void Load(ICollection<T> collectionObj);
        Task LoadAsync(ICollection<T> collectionObj);
    }
}
