// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Storage
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  [Serializable]
  public class Storage : DeviceComponent, IStorage
  {
    private Gizmox.WebGUI.Forms.DeviceIntegration.LocalStorage mobjLocalStorage;
    private SingleCallMethodStore<LocalStorageEventArgs> mobjClearLocalStorageMethods;
    private SingleCallMethodStore<LocalStorageEventArgs> mobjGetLocalStorageItemMethods;
    private SingleCallMethodStore<LocalStorageEventArgs> mobjSetLocalStorageItemMethods;
    private SingleCallMethodStore<LocalStorageEventArgs> mobjRemoveLocalStorageItemMethods;
    private SingleCallMethodStore<LocalStorageEventArgs> mobjGetLocalStorageKeyMethods;
    private SingleCallMethodStore<SQLResultEventArgs> mobjExecuteSQLMethods;
    private SingleCallMethodStore<TransactionEventArgs> mobjTransactionCallbackMethods;

    public Storage(DeviceIntegrator objPhonegapIntegrator)
      : base(objPhonegapIntegrator)
    {
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Storage_Initialize", (object) this.ID);
    }

    /// <summary>Gets the transaction callback methods.</summary>
    internal SingleCallMethodStore<TransactionEventArgs> TransactionCallbackMethods
    {
      get
      {
        if (this.mobjTransactionCallbackMethods == null)
          this.mobjTransactionCallbackMethods = new SingleCallMethodStore<TransactionEventArgs>();
        return this.mobjTransactionCallbackMethods;
      }
    }

    /// <summary>Gets the execute SQL methods store.</summary>
    internal SingleCallMethodStore<SQLResultEventArgs> ExecuteSQLMethods
    {
      get
      {
        if (this.mobjExecuteSQLMethods == null)
          this.mobjExecuteSQLMethods = new SingleCallMethodStore<SQLResultEventArgs>();
        return this.mobjExecuteSQLMethods;
      }
    }

    /// <summary>Gets the clear local storage methods.</summary>
    internal SingleCallMethodStore<LocalStorageEventArgs> ClearLocalStorageMethods
    {
      get
      {
        if (this.mobjClearLocalStorageMethods == null)
          this.mobjClearLocalStorageMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
        return this.mobjClearLocalStorageMethods;
      }
    }

    /// <summary>Gets the set local storage item methods store.</summary>
    internal SingleCallMethodStore<LocalStorageEventArgs> SetLocalStorageItemMethods
    {
      get
      {
        if (this.mobjSetLocalStorageItemMethods == null)
          this.mobjSetLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
        return this.mobjSetLocalStorageItemMethods;
      }
    }

    /// <summary>Gets the get local storage item methods store.</summary>
    internal SingleCallMethodStore<LocalStorageEventArgs> GetLocalStorageItemMethods
    {
      get
      {
        if (this.mobjGetLocalStorageItemMethods == null)
          this.mobjGetLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
        return this.mobjGetLocalStorageItemMethods;
      }
    }

    /// <summary>Gets the get local storage key methods store.</summary>
    internal SingleCallMethodStore<LocalStorageEventArgs> GetLocalStorageKeyMethods
    {
      get
      {
        if (this.mobjGetLocalStorageKeyMethods == null)
          this.mobjGetLocalStorageKeyMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
        return this.mobjGetLocalStorageKeyMethods;
      }
    }

    /// <summary>Gets the remove local storage item methods store.</summary>
    internal SingleCallMethodStore<LocalStorageEventArgs> RemoveLocalStorageItemMethods
    {
      get
      {
        if (this.mobjRemoveLocalStorageItemMethods == null)
          this.mobjRemoveLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
        return this.mobjRemoveLocalStorageItemMethods;
      }
    }

    /// <summary>Gets the local storage.</summary>
    public ILocalStorage LocalStorage
    {
      get
      {
        if (this.mobjLocalStorage == null)
          this.mobjLocalStorage = new Gizmox.WebGUI.Forms.DeviceIntegration.LocalStorage(this);
        return (ILocalStorage) this.mobjLocalStorage;
      }
    }

    /// <summary>Opens the database (server).</summary>
    /// <param name="objOptions">The database options.</param>
    /// <returns>The database instance.</returns>
    public IDatabase OpenDatabase(DatabaseOptions objOptions) => (IDatabase) new Database(objOptions, this);

    protected internal override string GetTag() => "SQL";

    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      KeyValuePair<string, string> keyValuePair = this.SplitPrefixFromMethodKey(objEvent.Type);
      string key = keyValuePair.Key;
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(key))
      {
        case 1172432944:
          if (!(key == "getItem"))
            break;
          LocalStorageEventArgs storageArgsFromEvent1 = this.GetLocalStorageArgsFromEvent(objEvent);
          if (storageArgsFromEvent1 == null)
            break;
          this.GetLocalStorageItemMethods.InvokeContextualMethod(keyValuePair.Value, storageArgsFromEvent1);
          break;
        case 1547502974:
          if (!(key == "removeItem"))
            break;
          LocalStorageEventArgs storageArgsFromEvent2 = this.GetLocalStorageArgsFromEvent(objEvent);
          if (storageArgsFromEvent2 == null)
            break;
          this.RemoveLocalStorageItemMethods.InvokeContextualMethod(keyValuePair.Value, storageArgsFromEvent2);
          break;
        case 1746258028:
          if (!(key == "key"))
            break;
          LocalStorageEventArgs storageArgsFromEvent3 = this.GetLocalStorageArgsFromEvent(objEvent);
          if (storageArgsFromEvent3 == null)
            break;
          this.GetLocalStorageKeyMethods.InvokeContextualMethod(keyValuePair.Value, storageArgsFromEvent3);
          break;
        case 1963546403:
          if (!(key == "transaction"))
            break;
          TransactionEventArgs eventArgsFromEvent1 = this.GetTransactionEventArgsFromEvent(objEvent);
          if (eventArgsFromEvent1 == null)
            break;
          this.TransactionCallbackMethods.InvokeContextualMethod(keyValuePair.Value, eventArgsFromEvent1);
          break;
        case 2196189924:
          if (!(key == "executeSQL"))
            break;
          SQLResultEventArgs eventArgsFromEvent2 = this.GetSQLResultEventArgsFromEvent(objEvent);
          if (eventArgsFromEvent2 == null)
            break;
          this.ExecuteSQLMethods.InvokeContextualMethod(keyValuePair.Value, eventArgsFromEvent2);
          break;
        case 3247475074:
          if (!(key == "clearLocalStorage"))
            break;
          this.ClearLocalStorageMethods.InvokeContextualMethod(keyValuePair.Value, new LocalStorageEventArgs());
          break;
        case 3705221316:
          if (!(key == "setItem"))
            break;
          LocalStorageEventArgs storageArgsFromEvent4 = this.GetLocalStorageArgsFromEvent(objEvent);
          if (storageArgsFromEvent4 == null)
            break;
          this.SetLocalStorageItemMethods.InvokeContextualMethod(keyValuePair.Value, storageArgsFromEvent4);
          break;
      }
    }

    /// <summary>Gets the transaction event args from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private TransactionEventArgs GetTransactionEventArgsFromEvent(IEvent objEvent)
    {
      TransactionEventArgs objEventArgs = (TransactionEventArgs) null;
      if (!DeviceEventArgs.TryGetError<TransactionEventArgs>(objEvent, out objEventArgs))
        objEventArgs = new TransactionEventArgs();
      return objEventArgs;
    }

    /// <summary>Gets the transaction event args from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private SQLResultEventArgs GetSQLResultEventArgsFromEvent(IEvent objEvent)
    {
      SQLResultEventArgs objEventArgs = (SQLResultEventArgs) null;
      if (!DeviceEventArgs.TryGetError<SQLResultEventArgs>(objEvent, out objEventArgs))
      {
        SQLResultSet objResultSet = new SQLResultSet();
        if (!string.IsNullOrEmpty(objEvent["rows"]))
        {
          int num = JsonUtils.Deserialize<int>(objEvent["rows"]);
          if (num > 0)
          {
            List<Dictionary<string, string>> dictionaryList = new List<Dictionary<string, string>>();
            for (int index = 0; index < num; ++index)
            {
              if (!string.IsNullOrEmpty(objEvent["row" + (object) index]))
              {
                Dictionary<string, string> rowFromJson = this.ParseRowFromJSON(objEvent["row" + (object) index]);
                if (rowFromJson != null)
                  dictionaryList.Add(rowFromJson);
              }
            }
            objResultSet.Rows = (IEnumerable<Dictionary<string, string>>) dictionaryList;
          }
        }
        uint result1;
        if (!string.IsNullOrEmpty(objEvent["insertId"]) && uint.TryParse(objEvent["insertId"], out result1))
          objResultSet.InsertID = new uint?(result1);
        uint result2;
        if (!string.IsNullOrEmpty(objEvent["rowsAffected"]) && uint.TryParse(objEvent["rowsAffected"], out result2))
          objResultSet.RowsAffected = new uint?(result2);
        objEventArgs = new SQLResultEventArgs((ISQLResultSet) objResultSet);
        if (!string.IsNullOrEmpty(objEvent["command"]))
          objEventArgs.Command = objEvent["command"];
      }
      return objEventArgs;
    }

    /// <summary>Parses the rows from JSON.</summary>
    /// <param name="strRowData">The STR rows.</param>
    /// <returns></returns>
    private Dictionary<string, string> ParseRowFromJSON(string strRowData) => JsonUtils.Deserialize<Dictionary<string, string>>(strRowData);

    /// <summary>Gets the local storage args from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private LocalStorageEventArgs GetLocalStorageArgsFromEvent(IEvent objEvent)
    {
      LocalStorageEventArgs objEventArgs = (LocalStorageEventArgs) null;
      if (!DeviceEventArgs.TryGetError<LocalStorageEventArgs>(objEvent, out objEventArgs) && !string.IsNullOrEmpty(objEvent["localStorageArgs"]))
      {
        JObject jobject = JsonUtils.Deserialize(objEvent["localStorageArgs"]);
        objEventArgs = new LocalStorageEventArgs(jobject.Value<string>((object) "key"), jobject.Value<string>((object) "item"));
      }
      return objEventArgs;
    }
  }
}
