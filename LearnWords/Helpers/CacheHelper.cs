using System.Collections.Concurrent;

namespace LearnWords.Helpers
{
    public static class CacheHelper
    {
        private static readonly ConcurrentDictionary<string, object> ConcurrentDictionary = new ConcurrentDictionary<string, object>();

        public static void Set<T>(string key, T value)
        {
            if (ConcurrentDictionary.ContainsKey(key))
            {
                ConcurrentDictionary[key] = value;
            }
            else
            {
                ConcurrentDictionary.TryAdd(key, value);
            }
        }
        public static T Get<T>(string key)
        {
            object obj;
            if (ConcurrentDictionary.TryGetValue(key, out obj))
            {
                return (T) obj;
            }
            return default(T);
        }
    }
}