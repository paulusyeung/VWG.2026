// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.StatusBarPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a panel in a <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control. Although the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> control replaces and adds functionality to the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control of previous versions, <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> is retained for both backward compatibility and future use if you choose.
  /// </summary>
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DefaultProperty("Text")]
  [ToolboxItem(false)]
  [DesignTimeVisible(false)]
  [Serializable]
  public class StatusBarPanel : Component, ISupportInitialize
  {
    private StatusBarPanelAutoSize menmAutoSize = StatusBarPanelAutoSize.None;
    private HorizontalAlignment menmAlignment;
    private string mstrText = "";
    private int mintWidth = 100;

    /// <summary>Updates the containing status bar.</summary>
    private void UpdateStatusBar() => this.OwnerStatusBar?.Update();

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      StatusBar ownerStatusBar = this.OwnerStatusBar;
      if (ownerStatusBar != null)
        criticalEventsData.Set(ownerStatusBar.GetStatusBarCriticalEventsData());
      return criticalEventsData;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      this.OwnerStatusBar?.FireStatusBarEvent(objEvent);
    }

    /// <summary>Renders the panel.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    internal void RenderPanel(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      if (!this.IsDirty(lngRequestID))
        return;
      objWriter.WriteStartElement("SP");
      this.RegisterSelf();
      this.RenderComponentAttributes(objContext, (IAttributeWriter) objWriter);
      if (this.menmAlignment != HorizontalAlignment.Left)
        objWriter.WriteAttributeString("HA", this.menmAlignment.ToString());
      if (this.InternalParent is StatusBar internalParent)
      {
        if (internalParent.Font != Control.DefaultFont)
          objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(internalParent.Font));
        if (internalParent.BackColor != internalParent.DefaultBackColorInternal)
          objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(internalParent.BackColor));
        if (internalParent.ForeColor != internalParent.DefaultForeColorInternal)
          objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(internalParent.ForeColor));
      }
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
      objWriter.WriteAttributeString("AS", ((int) this.AutoSize).ToString());
      objWriter.WriteAttributeString("W", this.Width.ToString());
      objWriter.WriteEndElement();
    }

    /// <summary>
    /// Gets or sets the width of the status bar panel within the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.
    /// </summary>
    /// <returns>The width, in pixels, of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see>.</returns>
    /// <exception cref="T:System.ArgumentException">The width specified is less than the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.MinWidth"></see> property. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Localizable(true)]
    [SRDescription("StatusBarPanelWidthDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(100)]
    public int Width
    {
      get => this.mintWidth;
      set
      {
        if (this.mintWidth == value)
          return;
        this.mintWidth = value;
        this.FireObservableItemPropertyChanged(nameof (Width));
        this.UpdateStatusBar();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the status bar panel is automatically resized.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> values. The default is<see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.None"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned to the property is not a member of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> enumeration. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(1)]
    [SRCategory("CatAppearance")]
    [SRDescription("StatusBarPanelAutoSizeDescr")]
    [RefreshProperties(RefreshProperties.All)]
    public StatusBarPanelAutoSize AutoSize
    {
      get => this.menmAutoSize;
      set
      {
        if (this.menmAutoSize == value)
          return;
        this.menmAutoSize = value;
        this.FireObservableItemPropertyChanged(nameof (AutoSize));
        this.UpdateStatusBar();
      }
    }

    /// <summary>
    /// Gets or sets the alignment of text and icons within the status bar panel.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values. The default is<see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned to the property is not a member of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> enumeration. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("StatusBarPanelAlignmentDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(HorizontalAlignment.Left)]
    [Localizable(true)]
    public HorizontalAlignment Alignment
    {
      get => this.menmAlignment;
      set
      {
        if (this.menmAlignment == value)
          return;
        this.menmAlignment = value;
        this.FireObservableItemPropertyChanged(nameof (Alignment));
        this.Update();
      }
    }

    /// <summary>Gets the owner status bar.</summary>
    /// <value>The owner status bar.</value>
    private StatusBar OwnerStatusBar => this.InternalParent as StatusBar;

    /// <summary>Gets or sets the text of the status bar panel.</summary>
    /// <returns>The text displayed in the panel.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Localizable(true)]
    [SRDescription("StatusBarPanelTextDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue("")]
    public string Text
    {
      get => this.mstrText;
      set
      {
        if (!(this.mstrText != value))
          return;
        this.mstrText = value;
        this.FireObservableItemPropertyChanged(nameof (Text));
        this.Update();
      }
    }

    /// <summary>Gets or sets the minimum allowed width of the status bar panel within the <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> control.</summary>
    /// <returns>The minimum width, in pixels, of the <see cref="T:Gizmox.WebGui.Forms.StatusBarPanel"></see>.</returns>
    /// <exception cref="T:System.ArgumentException">A value less than 0 is assigned to the property. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [SRDescription("StatusBarPanelMinWidthDescr")]
    [DefaultValue(10)]
    [RefreshProperties(RefreshProperties.All)]
    public int MinWidth
    {
      get => 10;
      set
      {
      }
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> control that hosts the status bar panel.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> that contains the panel.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("StatusBarPanelNameDescr")]
    public string Name
    {
      get => string.Empty;
      set
      {
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public void BeginInit()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public void EndInit()
    {
    }
  }
}
