// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Contacts
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>
  /// Represents entity that provides access to the device contacts database.
  /// </summary>
  [Serializable]
  public class Contacts : DeviceComponent, IContacts
  {
    private SingleCallMethodStore<FindContactsEventArgs> mobjFindContactsCallbackStore;
    private SingleCallMethodStore<EmptyDeviceEventArgs> mobjRemoveContactCallbackStore;
    private SingleCallMethodStore<SaveContactEventArgs> mobjSaveContactCallbackStore;

    /// <summary>
    /// Gets the method store for FindContacts() server callbacks.
    /// </summary>
    internal SingleCallMethodStore<FindContactsEventArgs> FindContactsCallbackStore
    {
      get
      {
        if (this.mobjFindContactsCallbackStore == null)
          this.mobjFindContactsCallbackStore = new SingleCallMethodStore<FindContactsEventArgs>();
        return this.mobjFindContactsCallbackStore;
      }
    }

    /// <summary>Gets the RemoveContact callback store.</summary>
    internal SingleCallMethodStore<EmptyDeviceEventArgs> RemoveContactCallbackStore
    {
      get
      {
        this.mobjRemoveContactCallbackStore = this.mobjRemoveContactCallbackStore ?? new SingleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjRemoveContactCallbackStore;
      }
    }

    /// <summary>Gets the SaveContact callback store.</summary>
    internal SingleCallMethodStore<SaveContactEventArgs> SaveContactCallbackStore
    {
      get
      {
        this.mobjSaveContactCallbackStore = this.mobjSaveContactCallbackStore ?? new SingleCallMethodStore<SaveContactEventArgs>();
        return this.mobjSaveContactCallbackStore;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Contacts" /> class.
    /// </summary>
    /// <param name="objMobileIntegrator">The obj mobile integrator.</param>
    public Contacts(DeviceIntegrator objMobileIntegrator)
      : base(objMobileIntegrator)
    {
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "CON";

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      KeyValuePair<string, string> keyValuePair = this.SplitPrefixFromMethodKey(objEvent.Type);
      switch (keyValuePair.Key)
      {
        case "remove":
          EmptyDeviceEventArgs fromVwgEvent1 = EmptyDeviceEventArgs.ParseFromVWGEvent(objEvent);
          if (fromVwgEvent1 == null)
            break;
          this.RemoveContactCallbackStore.InvokeContextualMethod(keyValuePair.Value, fromVwgEvent1);
          break;
        case "save":
          SaveContactEventArgs fromVwgEvent2 = SaveContactEventArgs.ParseFromVWGEvent(objEvent);
          if (fromVwgEvent2 == null)
            break;
          this.SaveContactCallbackStore.InvokeContextualMethod(keyValuePair.Value, fromVwgEvent2);
          break;
        case "find":
          FindContactsEventArgs findEventArgs = this.GetFindEventArgs(objEvent);
          if (findEventArgs == null)
            break;
          this.FindContactsCallbackStore.InvokeContextualMethod(keyValuePair.Value, findEventArgs);
          break;
      }
    }

    /// <summary>Gets the find eventArgs.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private FindContactsEventArgs GetFindEventArgs(IEvent objEvent)
    {
      FindContactsEventArgs objEventArgs = (FindContactsEventArgs) null;
      if (!DeviceEventArgs.TryGetError<FindContactsEventArgs>(objEvent, out objEventArgs))
      {
        string s = objEvent["contacts"];
        List<IContact> arrContacts = (List<IContact>) null;
        if (!string.IsNullOrEmpty(s))
        {
          int result;
          if (int.TryParse(s, out result))
          {
            arrContacts = new List<IContact>();
            for (int index = 0; index < result; ++index)
            {
              Contact contact = new Contact(this);
              string strContact = objEvent["contact" + (object) index];
              if (!string.IsNullOrEmpty(strContact))
              {
                contact.ParseFromJson(strContact);
                arrContacts.Add((IContact) contact);
              }
            }
          }
          objEventArgs = new FindContactsEventArgs(arrContacts);
        }
      }
      return objEventArgs;
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Contacts_Initialize", (object) this.ID);
    }

    /// <summary>Creates the contact on server.</summary>
    /// <param name="objProperties">The contact properties.</param>
    /// <returns></returns>
    public IContact CreateContact() => (IContact) new Contact(this);

    /// <summary>
    /// Queries the device contacts database and returns an array of Contact objects (server callback).
    /// </summary>
    /// <param name="objMethod">The callback method.</param>
    /// <param name="objOptions">The contact options.</param>
    public void FindContacts(
      EventHandler<FindContactsEventArgs> objMethod,
      ContactFindOptions objOptions)
    {
      this.Invoke("DeviceIntegrator.Contacts.findContacts", (object) this.FindContactsCallbackStore.StoreContextualSingleCallMethod((object) this, "find", objMethod), (object) CommonUtils.GetClientJsonObject((object) objOptions));
    }
  }
}
