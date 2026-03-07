// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.LocalStorage
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Device;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>
  /// Provides access to a W3C Storage interface (http://dev.w3.org/html5/webstorage/#the-localstorage-attribute)
  /// </summary>
  [Serializable]
  public class LocalStorage : ILocalStorage
  {
    private Gizmox.WebGUI.Forms.DeviceIntegration.Storage mobjStorage;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.LocalStorage" /> class.
    /// </summary>
    /// <param name="objStorage">The storage.</param>
    public LocalStorage(Gizmox.WebGUI.Forms.DeviceIntegration.Storage objStorage) => this.mobjStorage = objStorage;

    /// <summary>Removes all of the key value pairs (server side).</summary>
    public void Clear(EventHandler<LocalStorageEventArgs> objMethod) => this.mobjStorage.Invoke("DeviceIntegrator.Storage.clear", (object) this.mobjStorage.ClearLocalStorageMethods.StoreContextualSingleCallMethod((object) this, "clearLocalStorage", objMethod));

    /// <summary>
    /// Returns the name of the key at the position specified (server).
    /// </summary>
    /// <param name="intPosition">The position.</param>
    /// <returns></returns>
    public void Key(EventHandler<LocalStorageEventArgs> objMethod, int intPosition) => this.mobjStorage.Invoke("DeviceIntegrator.Storage.key", (object) this.mobjStorage.GetLocalStorageKeyMethods.StoreContextualSingleCallMethod((object) this, "key", objMethod), (object) intPosition);

    /// <summary>Returns the item identified by it's key (server).</summary>
    /// <param name="strKey">The key.</param>
    /// <returns></returns>
    public void GetItem(EventHandler<LocalStorageEventArgs> objMethod, string strKey) => this.mobjStorage.Invoke("DeviceIntegrator.Storage.getItem", (object) this.mobjStorage.GetLocalStorageItemMethods.StoreContextualSingleCallMethod((object) this, "getItem", objMethod), (object) strKey);

    /// <summary>Saves and item at the key provided (server).</summary>
    /// <param name="strKey">The key.</param>
    /// <param name="strValue">The value.</param>
    public void SetItem(
      EventHandler<LocalStorageEventArgs> objMethod,
      string strKey,
      string strValue)
    {
      this.mobjStorage.Invoke("DeviceIntegrator.Storage.setItem", (object) this.mobjStorage.SetLocalStorageItemMethods.StoreContextualSingleCallMethod((object) this, "setItem", objMethod), (object) strKey, (object) strValue);
    }

    /// <summary>Removes the item identified by it's key (server).</summary>
    /// <param name="objMethod">The method.</param>
    /// <param name="strKey">The key.</param>
    public void RemoveItem(EventHandler<LocalStorageEventArgs> objMethod, string strKey) => this.mobjStorage.Invoke("DeviceIntegrator.Storage.removeItem", (object) this.mobjStorage.RemoveLocalStorageItemMethods.StoreContextualSingleCallMethod((object) this, "removeItem", objMethod), (object) strKey);
  }
}
