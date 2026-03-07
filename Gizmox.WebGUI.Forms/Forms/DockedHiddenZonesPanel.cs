// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedHiddenZonesPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A Panel control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DockedHiddenZonesPanelSkin))]
  [ToolboxItem(false)]
  [Serializable]
  internal class DockedHiddenZonesPanel : Panel, IDescriptable
  {
    private DockedHiddenZonePanelDescriptor mobjData;
    private DockingManager mobjManager;
    private List<List<Zone>> mobjAllZoneGroups;
    private Dictionary<DockingWindowName, List<Zone>> mobjZonesIndexByWindowName;
    private Dictionary<long, Zone> mobjZonesIndexByZoneID;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedHiddenZonesPanel" /> class.
    /// </summary>
    /// <param name="objManager">The obj manager.</param>
    public DockedHiddenZonesPanel(DockingManager objManager)
    {
      this.mobjData = new DockedHiddenZonePanelDescriptor();
      this.mobjAllZoneGroups = new List<List<Zone>>();
      this.mobjManager = objManager;
      this.mobjZonesIndexByWindowName = new Dictionary<DockingWindowName, List<Zone>>(DockingWindowName.DockedWindowNameEqulityComparer);
      this.mobjZonesIndexByZoneID = new Dictionary<long, Zone>();
      this.Visible = false;
      this.CustomStyle = "DockedHiddenZonesPanelSkin";
    }

    /// <summary>Gets the docked hidden panel descriptor.</summary>
    public DockedHiddenZonePanelDescriptor DockedHiddenPanelDescriptor => this.mobjData;

    /// <summary>Gets the docked hidden zone panel descriptor.</summary>
    public DockedHiddenZonePanelDescriptor DockedHiddenZonePanelDescriptor => this.mobjData;

    DockedObjectDescriptor IDescriptable.Descriptor => (DockedObjectDescriptor) this.mobjData;

    /// <summary>Gets or sets the name of the zones index by window.</summary>
    /// <value>The name of the zones index by window.</value>
    internal Dictionary<DockingWindowName, List<Zone>> ZonesIndexByWindowName
    {
      get => this.mobjZonesIndexByWindowName;
      set => this.mobjZonesIndexByWindowName = value;
    }

    /// <summary>Invokes the method internal.</summary>
    /// <param name="strMember">The STR member.</param>
    /// <param name="arrArgs">The arr args.</param>
    internal void InvokeMethodInternal(string strMember, params object[] arrArgs) => this.InvokeMethod(strMember, arrArgs);

    /// <summary>Loads the specified descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    void IDescriptable.Load(DockedObjectDescriptor objDescriptor) => this.mobjData = objDescriptor as DockedHiddenZonePanelDescriptor;

    /// <summary>Resets the descriptors tree.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <param name="objDockingPosition">The obj docking position.</param>
    void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition) => throw new NotImplementedException();

    /// <summary>Adds the new zones.</summary>
    /// <param name="objHiddenZones">The obj hidden zones.</param>
    internal void AddNewZones(List<Zone> objHiddenZones)
    {
      foreach (Zone objHiddenZone in objHiddenZones)
      {
        DockingWindow dockingWindow = objHiddenZone.ZoneType == ZoneType.Hidden ? objHiddenZone.CurrentWindow : throw new Exception("DockedHiddenZonesPanel.AddNewZones - Cannot accept zone of ZoneType=" + objHiddenZone.ZoneType.ToString());
        objHiddenZone.ContainingHiddenPanel = this;
        this.mobjZonesIndexByWindowName.Add(dockingWindow.WindowName, objHiddenZones);
        this.mobjZonesIndexByZoneID.Add(objHiddenZone.ID, objHiddenZone);
        objHiddenZone.InvokeParentChanged();
        this.Visible = true;
        this.mobjManager.UpdateHiddenPanelsDimentions();
        this.Update();
      }
      this.AllZoneGroups.Add(objHiddenZones);
      this.mobjData.UpdateSelf((Control) this, this.mobjManager);
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      foreach (Zone objZone in this.mobjZonesIndexByZoneID.Values)
        this.RenderZoneAttributes(objZone, objWriter);
    }

    /// <summary>Renders the zone attributes.</summary>
    /// <param name="objZone">The obj zone.</param>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderZoneAttributes(Zone objZone, IResponseWriter objWriter)
    {
      if (objZone == null)
        return;
      DockingWindow currentWindow = objZone.CurrentWindow;
      if (currentWindow == null)
        return;
      objWriter.WriteStartElement("DZH");
      objWriter.WriteAttributeString("DZI", objZone.ID.ToString());
      int itemQuareEdgeLength = this.GetHiddenZoneItemQuareEdgeLength(currentWindow);
      objWriter.WriteAttributeString("LEN", itemQuareEdgeLength.ToString());
      objWriter.WriteAttributeString("TX", currentWindow.Text);
      if (currentWindow.Image != null)
        objWriter.WriteAttributeString("IM", currentWindow.Image.ToString());
      objWriter.WriteEndElement();
    }

    /// <summary>Gets the length of the hidden zone item quare edge.</summary>
    /// <param name="strItemText">The string item text.</param>
    /// <returns></returns>
    private int GetHiddenZoneItemQuareEdgeLength(DockingWindow objDockingWindow)
    {
      DockedHiddenZonesPanelSkin skin = this.Skin as DockedHiddenZonesPanelSkin;
      Size stringMeasurements = CommonUtils.GetStringMeasurements(objDockingWindow.Text, skin.FontData);
      stringMeasurements.Width += skin.HiddenZoneItemStyleHorizontalPadding;
      if (objDockingWindow.Image != null)
      {
        stringMeasurements.Width += skin.HiddenZoneItemImageWidth;
        stringMeasurements.Height = Math.Max(stringMeasurements.Height, skin.HiddenZoneItemImageWidth);
      }
      return Math.Max(stringMeasurements.Width, stringMeasurements.Height);
    }

    /// <summary>Pins the specified obj docked window.</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    /// <returns></returns>
    internal List<DockingWindow> RemoveAndReturnHiddenWindows(DockingWindow objDockedWindow)
    {
      List<Zone> zoneList = this.mobjZonesIndexByWindowName[objDockedWindow.WindowName];
      this.mobjAllZoneGroups.Remove(zoneList);
      List<DockingWindow> dockingWindowList = new List<DockingWindow>();
      foreach (Zone objHiddenZone in zoneList.ToArray())
      {
        DockingWindow currentWindow = objHiddenZone.CurrentWindow;
        this.mobjZonesIndexByWindowName.Remove(currentWindow.WindowName);
        this.RemoveSingleZoneFromPanel(objHiddenZone);
        objHiddenZone.RemoveWindows(currentWindow);
        dockingWindowList.Add(currentWindow);
      }
      this.mobjData.UpdateSelf((Control) this, this.mobjManager);
      return dockingWindowList;
    }

    /// <summary>Removes a single hidden zone.</summary>
    /// <param name="objHiddenZone">The obj hidden zone.</param>
    internal void RemoveHiddenZone(Zone objHiddenZone)
    {
      DockingWindowName windowName = objHiddenZone.CurrentWindow.WindowName;
      this.mobjZonesIndexByWindowName[windowName].Remove(objHiddenZone);
      this.mobjZonesIndexByWindowName.Remove(windowName);
      objHiddenZone.RemoveWindows(objHiddenZone.CurrentWindow);
      this.mobjData.UpdateSelf((Control) this, this.mobjManager);
      this.RemoveSingleZoneFromPanel(objHiddenZone);
    }

    /// <summary>Removes the single zone from panel.</summary>
    /// <param name="objHiddenZone">The obj hidden zone.</param>
    internal void RemoveSingleZoneFromPanel(Zone objHiddenZone)
    {
      this.mobjZonesIndexByZoneID.Remove(objHiddenZone.ID);
      objHiddenZone.ContainingHiddenPanel = (DockedHiddenZonesPanel) null;
      if (this.mobjZonesIndexByZoneID.Count == 0)
      {
        this.Visible = false;
        this.mobjManager.UpdateHiddenPanelsDimentions();
      }
      this.Update();
      objHiddenZone.InvokeParentChanged();
    }

    /// <summary>Shows the hidden zone popup form.</summary>
    /// <param name="objZone">The obj zone.</param>
    private void ShowHiddenZonePopupForm(Zone objZone)
    {
      if (objZone == null)
        return;
      int height = 0;
      int width = 0;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      Padding dockedPanelsPadding = this.mobjManager.DockedPanelsPadding;
      int num4 = this.mobjManager.Width - dockedPanelsPadding.Left - dockedPanelsPadding.Right;
      int num5 = this.mobjManager.Height - dockedPanelsPadding.Top - dockedPanelsPadding.Bottom;
      DockingWindow currentWindow = objZone.CurrentWindow;
      Size size = Size.Empty;
      if (currentWindow != null)
        size = currentWindow.HiddenZonePopupSize;
      if (size.IsEmpty)
      {
        if (SkinFactory.GetSkin((ISkinable) this) is DockedHiddenZonesPanelSkin skin)
          num3 = skin.HiddenZoneItemExpantionWidth;
      }
      else
      {
        switch (this.Dock)
        {
          case DockStyle.Top:
          case DockStyle.Bottom:
            num3 = size.Height;
            break;
          case DockStyle.Right:
          case DockStyle.Left:
            num3 = size.Width;
            break;
        }
      }
      switch (this.Dock)
      {
        case DockStyle.Top:
          width = num4;
          height = num3 > num5 ? num5 : num3;
          num1 = dockedPanelsPadding.Top;
          num2 = dockedPanelsPadding.Left;
          break;
        case DockStyle.Right:
          width = num3 > num4 ? num4 : num3;
          height = num5;
          num1 = dockedPanelsPadding.Top;
          num2 = num4 + dockedPanelsPadding.Left - width;
          break;
        case DockStyle.Bottom:
          width = num4;
          height = num3 > num5 ? num5 : num3;
          num1 = num5 + dockedPanelsPadding.Top - height;
          num2 = dockedPanelsPadding.Left;
          break;
        case DockStyle.Left:
          width = num3 > num4 ? num4 : num3;
          height = num5;
          num1 = dockedPanelsPadding.Top;
          num2 = dockedPanelsPadding.Left;
          break;
      }
      HiddenZonePopupForm hiddenZonePopupForm = new HiddenZonePopupForm();
      hiddenZonePopupForm.Size = new Size(width, height);
      hiddenZonePopupForm.StartPosition = FormStartPosition.Manual;
      hiddenZonePopupForm.Top = num1;
      hiddenZonePopupForm.Left = num2;
      hiddenZonePopupForm.Load += new EventHandler(this.HiddenZonePopupForm_Load);
      hiddenZonePopupForm.Closed += new EventHandler(this.HiddenZonePopupForm_Closed);
      hiddenZonePopupForm.ContainedZone = objZone;
      objZone.ZonePopupForm = (Form) hiddenZonePopupForm;
      hiddenZonePopupForm.Controls.Add((Control) objZone);
      int num6 = (int) hiddenZonePopupForm.ShowPopup((Component) this.mobjManager, DialogAlignment.Custom);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      long result;
      Zone objZone;
      if (objEvent.Type == "ShowZonePopUp" && long.TryParse(objEvent["ZoneId"], out result) && this.mobjZonesIndexByZoneID.TryGetValue(result, out objZone))
        this.ShowHiddenZonePopupForm(objZone);
      base.FireEvent(objEvent);
    }

    /// <summary>Handles the Load event of the zone pop up form.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void HiddenZonePopupForm_Load(object sender, EventArgs e)
    {
      if (!(sender is HiddenZonePopupForm hiddenZonePopupForm) || hiddenZonePopupForm.ContainedZone == null)
        return;
      object[] objArray = new object[2];
      long id = this.ID;
      objArray[0] = (object) id.ToString();
      id = hiddenZonePopupForm.ContainedZone.ID;
      objArray[1] = (object) id.ToString();
      this.InvokeMethodInternal("DockedHiddenZonesPanel_OnZonePopUpFormLoad", objArray);
    }

    /// <summary>Handles the Closed event of the zone pop up form.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void HiddenZonePopupForm_Closed(object sender, EventArgs e)
    {
      if (!(sender is HiddenZonePopupForm hiddenZonePopupForm) || hiddenZonePopupForm.ContainedZone == null)
        return;
      object[] objArray = new object[2];
      long id = this.ID;
      objArray[0] = (object) id.ToString();
      id = hiddenZonePopupForm.ContainedZone.ID;
      objArray[1] = (object) id.ToString();
      this.InvokeMethodInternal("DockedHiddenZonesPanel_OnZonePopUpFormClosed", objArray);
    }

    /// <summary>Gets or sets the unique zone groups.</summary>
    /// <value>The unique zone groups.</value>
    public List<List<Zone>> AllZoneGroups
    {
      get => this.mobjAllZoneGroups;
      set => this.mobjAllZoneGroups = value;
    }
  }
}
