﻿
namespace ArtStudioManager.Components
{
    public interface IDataLoader<T>
    {
        Task Load(T objectNeedingLoad);
    }
}
