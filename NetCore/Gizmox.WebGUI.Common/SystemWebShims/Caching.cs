using System.Collections;

namespace System.Web.Caching
{
    public sealed class Cache
    {
        private readonly Hashtable _items = new();

        public object? this[string key]
        {
            get => _items[key];
            set => _items[key] = value;
        }
    }
}
