using System.Collections;
using System.Collections.Specialized;

namespace System.Web.SessionState
{
    public interface IRequiresSessionState { }

    public enum SessionStateMode { Off, InProc, StateServer, SQLServer, Custom }

    public sealed class HttpSessionState
    {
        private readonly Hashtable _data = new();

        public int Count => _data.Count;
        public bool IsNewSession { get; set; } = true;
        public int LCID { get; set; } = 0x0409;
        public string SessionID { get; set; } = Guid.NewGuid().ToString("N");
        public object SyncRoot => _data.SyncRoot;
        public bool IsSynchronized => _data.IsSynchronized;
        public bool IsReadOnly => false;
        public bool IsCookieless => false;
        public SessionStateMode Mode { get; set; } = SessionStateMode.InProc;

        public object? this[int index]
        {
            get
            {
                int i = 0;
                foreach (DictionaryEntry e in _data)
                {
                    if (i == index) return e.Value;
                    i++;
                }
                return null;
            }
            set
            {
                int i = 0;
                foreach (DictionaryEntry e in _data)
                {
                    if (i == index) { _data[e.Key] = value; return; }
                    i++;
                }
            }
        }

        public object? this[string name]
        {
            get => _data[name];
            set => _data[name] = value;
        }

        public NameObjectCollectionBase.KeysCollection Keys
        {
            get
            {
                var nvc = new NameValueCollection();
                foreach (DictionaryEntry e in _data)
                    nvc.Add(e.Key?.ToString() ?? "", e.Value?.ToString());
                return nvc.Keys;
            }
        }

        public void Abandon() { }
        public void Add(string name, object value) => _data[name] = value;
        public void Clear() => _data.Clear();
        public void Remove(string name) => _data.Remove(name);
        public void RemoveAt(int index)
        {
            int i = 0;
            object? keyToRemove = null;
            foreach (DictionaryEntry e in _data)
            {
                if (i == index) { keyToRemove = e.Key; break; }
                i++;
            }
            if (keyToRemove != null) _data.Remove(keyToRemove);
        }
        public void RemoveAll() => _data.Clear();
        public void CopyTo(Array array, int index) => _data.CopyTo(array, index);
        public IEnumerator GetEnumerator() => _data.GetEnumerator();
    }
}
