// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.DeviceIntegrator
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>
  /// Represents default device integrator implemented by PhoneGap
  /// </summary>
  [Skin(typeof (DeviceIntegratorSkin))]
  [Serializable]
  public class DeviceIntegrator : 
    RegisteredComponent,
    ISkinable,
    IDeviceIntegrator,
    IRenderableComponent
  {
    private Gizmox.WebGUI.Forms.DeviceIntegration.Accelerometer mobjAccelerometer;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Camera mobjCamera;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Compass mobjCompass;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Geolocation mobjGeolocation;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Notifications mobjNotifications;
    private DeviceEvents mobjEvents;
    private Gizmox.WebGUI.Forms.DeviceIntegration.FileManager mobjFileManager;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Contacts mobjContacts;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Connection mobjConnection;
    private Gizmox.WebGUI.Forms.DeviceIntegration.DeviceInfo mobjDeviceInfo;
    private DeviceMedia mobjMedia;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Globalization mobjGlobalizaion;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Capture mobjCapture;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Splashscreen mobjSplashscreen;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Storage mobjStorage;
    private List<DeviceComponent> marrDeviceComponents = new List<DeviceComponent>();

    /// <summary>
    /// Initializes a new instance of the <see cref="!:PhonegapIntegrator" /> class.
    /// </summary>
    public DeviceIntegrator()
    {
      this.mobjAccelerometer = new Gizmox.WebGUI.Forms.DeviceIntegration.Accelerometer(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjAccelerometer);
      this.mobjCamera = new Gizmox.WebGUI.Forms.DeviceIntegration.Camera(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjCamera);
      this.mobjCompass = new Gizmox.WebGUI.Forms.DeviceIntegration.Compass(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjCompass);
      this.mobjGeolocation = new Gizmox.WebGUI.Forms.DeviceIntegration.Geolocation(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjGeolocation);
      this.mobjNotifications = new Gizmox.WebGUI.Forms.DeviceIntegration.Notifications(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjNotifications);
      this.mobjEvents = new DeviceEvents(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjEvents);
      this.mobjFileManager = new Gizmox.WebGUI.Forms.DeviceIntegration.FileManager(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjFileManager);
      this.mobjContacts = new Gizmox.WebGUI.Forms.DeviceIntegration.Contacts(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjContacts);
      this.mobjConnection = new Gizmox.WebGUI.Forms.DeviceIntegration.Connection(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjConnection);
      this.mobjDeviceInfo = new Gizmox.WebGUI.Forms.DeviceIntegration.DeviceInfo(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjDeviceInfo);
      this.mobjMedia = new DeviceMedia(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjMedia);
      this.mobjGlobalizaion = new Gizmox.WebGUI.Forms.DeviceIntegration.Globalization(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjGlobalizaion);
      this.mobjCapture = new Gizmox.WebGUI.Forms.DeviceIntegration.Capture(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjCapture);
      this.mobjSplashscreen = new Gizmox.WebGUI.Forms.DeviceIntegration.Splashscreen(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjSplashscreen);
      this.mobjStorage = new Gizmox.WebGUI.Forms.DeviceIntegration.Storage(this);
      this.marrDeviceComponents.Add((DeviceComponent) this.mobjStorage);
    }

    /// <summary>Gets the theme related to the skinable component.</summary>
    /// <value>The theme related to the skinable component.</value>
    public string Theme => VWGContext.Current != null ? VWGContext.Current.CurrentTheme : (string) null;

    /// <summary>Gets the current application context.</summary>
    public override IContext Context => VWGContext.Current;

    /// <summary>Gets the accelerometer.</summary>
    public IAccelerometer Accelerometer => (IAccelerometer) this.mobjAccelerometer;

    /// <summary>Gets the camera.</summary>
    public ICamera Camera => (ICamera) this.mobjCamera;

    /// <summary>Gets the compass.</summary>
    public ICompass Compass => (ICompass) this.mobjCompass;

    /// <summary>Gets the geolocation.</summary>
    public IGeolocation Geolocation => (IGeolocation) this.mobjGeolocation;

    /// <summary>Gets the notifications.</summary>
    public INotifications Notifications => (INotifications) this.mobjNotifications;

    /// <summary>Gets the file manager.</summary>
    public IFileManagement FileManager => (IFileManagement) this.mobjFileManager;

    /// <summary>Gets the client events.</summary>
    public IDeviceEvents Events => (IDeviceEvents) this.mobjEvents;

    /// <summary>Gets the connection.</summary>
    public IConnection Connection => (IConnection) this.mobjConnection;

    /// <summary>Gets the Device Info.</summary>
    public IDeviceInfo DeviceInfo => (IDeviceInfo) this.mobjDeviceInfo;

    /// <summary>Gets the contacts.</summary>
    public IContacts Contacts => (IContacts) this.mobjContacts;

    /// <summary>Gets the Device Info.</summary>
    public IDeviceMedia Media => (IDeviceMedia) this.mobjMedia;

    /// <summary>Gets the device storage.</summary>
    public IStorage Storage => (IStorage) this.mobjStorage;

    /// <summary>Gets the Capture.</summary>
    public ICapture Capture => (ICapture) this.mobjCapture;

    /// <summary>Gets the globalization.</summary>
    public IGlobalization Globalization => (IGlobalization) this.mobjGlobalizaion;

    /// <summary>Gets the splashscreen.</summary>
    public ISplashscreen Splashscreen => (ISplashscreen) this.mobjSplashscreen;

    public void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      foreach (DeviceComponent marrDeviceComponent in this.marrDeviceComponents)
        marrDeviceComponent.OnRendering(objContext, objWriter, lngRequestID);
      if (this.IsDirty(lngRequestID))
      {
        if (!this.IsRegistered)
          this.RegisterSelf();
        objWriter.WriteStartElement("DI");
        (objWriter as IAttributeWriter).WriteAttributeString("Id", (double) this.ID);
        foreach (DeviceComponent marrDeviceComponent in this.marrDeviceComponents)
          marrDeviceComponent.RenderComponent(objContext, objWriter, lngRequestID);
        objWriter.WriteEndElement();
      }
      foreach (DeviceComponent marrDeviceComponent in this.marrDeviceComponents)
        marrDeviceComponent.OnRendered(objContext, objWriter, lngRequestID);
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ConnectionType
    {
      public const string TYPE_UNKNOWN = "unknown";
      public const string TYPE_ETHERNET = "ethernet";
      public const string TYPE_WIFI = "wifi";
      public const string TYPE_CELL_2G = "2g";
      public const string TYPE_CELL_3G = "3g";
      public const string TYPE_CELL_4G = "4g";
      public const string TYPE_NONE = "none";
    }
  }
}
