#nullable enable annotations

using System.Collections;
using Microsoft.Extensions.Caching.Memory;

namespace System.Web.Caching
{
    public sealed class Cache
    {
        private static IMemoryCache? _memoryCache;
        private readonly Hashtable _items = new();

        public static void Initialize(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public object? this[string key]
        {
            get => _memoryCache != null ? _memoryCache.Get(key) : _items[key];
            set 
            {
                if (_memoryCache != null)
                {
                    if (value == null) _memoryCache.Remove(key);
                    else _memoryCache.Set(key, value);
                }
                else
                {
                    _items[key] = value;
                }
            }
        }

        public object? Get(string key) => this[key];

        public void Insert(string key, object? value) => this[key] = value;

        public void Remove(string key) => this[key] = null;
    }
}
