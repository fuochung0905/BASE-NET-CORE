using AutoDependencyRegistration.Attributes;
using System.Runtime.Caching;

namespace REPONSITORY.HETHONG
{
    [RegisterClassAsTransient]
    public class CacheService : ICacheService
    {
        public T? Get<T>(string cacheKey) where T : class
        {
            T? item = MemoryCache.Default.Get(cacheKey) as T;
            return item;
        }

        public void Set<T>(string cacheKey, T item, int minute = 2) where T : class
        {
            T? itemExist = MemoryCache.Default.Get(cacheKey) as T;
            if (itemExist != null)
            {
                MemoryCache.Default.Remove(cacheKey);
            }
            MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(minute));
        }
    }

    public interface ICacheService
    {
        T? Get<T>(string cacheKey) where T : class;
        void Set<T>(string cacheKey, T item, int minute = 2) where T : class;
    }
}
