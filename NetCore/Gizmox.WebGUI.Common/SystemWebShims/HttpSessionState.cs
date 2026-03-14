using System.Collections;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Linq;

namespace System.Web.SessionState
{
    public interface IRequiresSessionState { }

    public enum SessionStateMode { Off, InProc, StateServer, SQLServer, Custom }

    public sealed class HttpSessionState
    {
        private readonly Hashtable _data = new();
        private ISession? _session;

        public void Initialize(ISession session)
        {
            _session = session;
        }

        public int Count => _session != null ? _session.Keys.Count() : _data.Count;
        public bool IsNewSession { get; set; } = true;
        public int LCID { get; set; } = 0x0409;
        public string SessionID => _session != null ? _session.Id : Guid.NewGuid().ToString("N");
        public object SyncRoot => _data.SyncRoot;
        public bool IsSynchronized => _data.IsSynchronized;
        public bool IsReadOnly => false;
        public bool IsCookieless => false;
        public SessionStateMode Mode { get; set; } = SessionStateMode.InProc;

        public object? this[int index]
        {
            get
            {
                if (_session != null)
                {
                    var key = _session.Keys.ElementAtOrDefault(index);
                    return key != null ? this[key] : null;
                }
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
                if (_session != null)
                {
                    var key = _session.Keys.ElementAtOrDefault(index);
                    if (key != null) this[key] = value;
                    return;
                }
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
            get
            {
                if (_session != null && _session.TryGetValue(name, out var bytes))
                {
                    try 
                    { 
                        var obj = JsonSerializer.Deserialize<object>(bytes);
                        if (obj is JsonElement je)
                        {
                            return je.ValueKind switch
                            {
                                JsonValueKind.String => je.GetString(),
                                JsonValueKind.Number => je.TryGetInt32(out int i) ? i : je.GetDouble(),
                                JsonValueKind.True => true,
                                JsonValueKind.False => false,
                                JsonValueKind.Null => null,
                                _ => je
                            };
                        }
                        return obj;
                    }
                    catch { return System.Text.Encoding.UTF8.GetString(bytes); }
                }
                return _data[name];
            }
            set
            {
                if (_session != null)
                {
                    if (value == null) _session.Remove(name);
                    else if (value is string s) _session.SetString(name, s);
                    else if (value is int i) _session.SetInt32(name, i);
                    else _session.Set(name, JsonSerializer.SerializeToUtf8Bytes(value));
                }
                else
                {
                    _data[name] = value;
                }
            }
        }

        public NameObjectCollectionBase.KeysCollection Keys
        {
            get
            {
                var nvc = new NameValueCollection();
                if (_session != null)
                {
                    foreach (var k in _session.Keys) nvc.Add(k, null);
                }
                else
                {
                    foreach (DictionaryEntry e in _data)
                        nvc.Add(e.Key?.ToString() ?? "", e.Value?.ToString());
                }
                return nvc.Keys;
            }
        }

        public void Abandon() => _session?.Clear();
        public void Add(string name, object value) => this[name] = value;
        public void Clear()
        {
            if (_session != null) _session.Clear();
            else _data.Clear();
        }
        public void Remove(string name)
        {
            if (_session != null) _session.Remove(name);
            else _data.Remove(name);
        }
        public void RemoveAt(int index)
        {
            if (_session != null)
            {
                var key = _session.Keys.ElementAtOrDefault(index);
                if (key != null) _session.Remove(key);
            }
            else
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
        }
        public void RemoveAll() => Clear();
        public void CopyTo(Array array, int index) => _data.CopyTo(array, index); // Not fully supported by ISession, keep dummy
        public IEnumerator GetEnumerator() => _data.GetEnumerator();
    }
}
