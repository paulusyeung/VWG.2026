// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.OrientationTabControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A TabControl control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (OrientationTabControlSkin))]
  [Serializable]
  public class OrientationTabControl : TabControl
  {
    private long mlngProxyId;
    private bool? mblnDeviceLandscape;

    /// <summary>Handle pre render.</summary>
    protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
    {
      base.PreRenderControl(objContext, lngRequestID);
      if (VWGContext.Current.MainForm is IAdministrationForm)
        return;
      if (!this.mblnDeviceLandscape.HasValue)
      {
        this.mblnDeviceLandscape = new bool?(this.IsDeviceLandscape());
        this.SelectedIndex = this.mblnDeviceLandscape.Value == this.IsStartupLandscape() ? 0 : 1;
      }
      if (!this.IsDirty(lngRequestID))
        return;
      this.mlngProxyId = this.GetProxyPropertyValue<long>("ID", 0L);
      this.Form.ClientOrientationChanged += new ClientEventHandler(this.Form_ClientOrientationChanged);
    }

    /// <summary>Handle client orientation changed event.</summary>
    private void Form_ClientOrientationChanged(object objSender, ClientEventArgs objArgs) => objArgs.Context.Invoke((ISkinable) this, "OrientationTabControl_UpdateOrientation", (object) this.mlngProxyId, (object) this.mblnDeviceLandscape.Value);

    /// <summary>
    /// Returns whether the device start the application in landscape.
    /// </summary>
    private bool IsStartupLandscape()
    {
      bool flag = false;
      if (((IContextParams) VWGContext.Current).StartupDeviceOrientation == DeviceOrientation.Landscape)
        flag = true;
      return flag;
    }

    /// <summary>Return if the current device is landscape.</summary>
    private bool IsDeviceLandscape()
    {
      Size deviceSize = new BrowserRepository().GetDeviceSize(VWGContext.Current as IClientDesignServices, (VWGContext.Current as IContextParams).BrowserId);
      bool flag = false;
      if (deviceSize.Width > deviceSize.Height)
        flag = true;
      return flag;
    }
  }
}
