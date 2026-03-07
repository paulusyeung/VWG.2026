#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Newtonsoft.Json.Linq;
using Gizmox.WebGUI.Common.Device.Storage;
using System.Collections;

#endregion

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// Provides access to a W3C Storage interface (http://dev.w3.org/html5/webstorage/#the-localstorage-attribute)
    /// </summary>
    [Serializable]
    public class LocalStorage : ILocalStorage
    {
        #region Members

        private Storage mobjStorage;

        #endregion Members

        #region Properties


        #endregion Properties

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalStorage"/> class.
        /// </summary>
        /// <param name="objStorage">The storage.</param>
        public LocalStorage(Storage objStorage)
        {
            this.mobjStorage = objStorage;
        }

        #endregion C'tors

        #region ILocalStorage

        /// <summary>
        /// Removes all of the key value pairs (server side).
        /// </summary>
        public void Clear(EventHandler<LocalStorageEventArgs> objMethod)
        {
            string strMethodKey = mobjStorage.ClearLocalStorageMethods.StoreContextualSingleCallMethod(this, "clearLocalStorage", objMethod);
            mobjStorage.Invoke("DeviceIntegrator.Storage.clear", strMethodKey);
        }

        /// <summary>
        /// Returns the name of the key at the position specified (server).
        /// </summary>
        /// <param name="intPosition">The position.</param>
        /// <returns></returns>
        public void Key(EventHandler<LocalStorageEventArgs> objMethod, int intPosition)
        {
            string strMethodKey = mobjStorage.GetLocalStorageKeyMethods.StoreContextualSingleCallMethod(this, "key", objMethod);

            mobjStorage.Invoke("DeviceIntegrator.Storage.key", strMethodKey, intPosition);
        }

        /// <summary>
        /// Returns the item identified by it's key (server).
        /// </summary>
        /// <param name="strKey">The key.</param>
        /// <returns></returns>
        public void GetItem(EventHandler<LocalStorageEventArgs> objMethod, string strKey)
        {
            string strMethodKey = mobjStorage.GetLocalStorageItemMethods.StoreContextualSingleCallMethod(this, "getItem", objMethod);
            mobjStorage.Invoke("DeviceIntegrator.Storage.getItem", strMethodKey, strKey);
        }

        /// <summary>
        /// Saves and item at the key provided (server).
        /// </summary>
        /// <param name="strKey">The key.</param>
        /// <param name="strValue">The value.</param>
        public void SetItem(EventHandler<LocalStorageEventArgs> objMethod, string strKey, string strValue)
        {
            string strMethodKey = mobjStorage.SetLocalStorageItemMethods.StoreContextualSingleCallMethod(this, "setItem", objMethod);

            mobjStorage.Invoke("DeviceIntegrator.Storage.setItem", strMethodKey, strKey, strValue);
        }

        /// <summary>
        /// Removes the item identified by it's key (server).
        /// </summary>
        /// <param name="objMethod">The method.</param>
        /// <param name="strKey">The key.</param>
        public void RemoveItem(EventHandler<LocalStorageEventArgs> objMethod, string strKey)
        {
            string strMethodKey = mobjStorage.RemoveLocalStorageItemMethods.StoreContextualSingleCallMethod(this, "removeItem", objMethod);
            mobjStorage.Invoke("DeviceIntegrator.Storage.removeItem", strMethodKey, strKey);
        }

        #endregion
    }
}
