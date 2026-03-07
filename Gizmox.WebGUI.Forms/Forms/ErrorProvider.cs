// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ErrorProvider
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides a user interface for indicating that a control on a form has an error associated with it.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ErrorProvider), "ErrorProvider_45.bmp")]
  [ProvideProperty("IconAlignment", typeof (Control))]
  [SRDescription("DescriptionErrorProvider")]
  [ComplexBindingProperties("DataSource", "DataMember")]
  [ProvideProperty("Error", typeof (Control))]
  [ProvideProperty("IconPadding", typeof (Control))]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [ToolboxItemCategory("Components")]
  [Serializable]
  public class ErrorProvider : ComponentBase
  {
    private int mintBlinkRate = 3;
    private ErrorBlinkStyle menmBlinkStyle;
    private string mstrDataMember = "";
    private object mobjDataSource = (object) "";
    private ContainerControl mobjContainerControl;
    private ResourceHandle mobjIcon;
    private Dictionary<Control, Control> mobjControlWithErrorsMap = new Dictionary<Control, Control>();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"></see> class and initializes the default settings for <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.BlinkRate"></see>, <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.BlinkStyle"></see>, and the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.Icon"></see>.
    /// </summary>
    public ErrorProvider()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"></see> class attached to a container.
    /// </summary>
    /// <param name="objParentControl">The container of the control to monitor for errors. </param>
    public ErrorProvider(ContainerControl objParentControl) => this.mobjContainerControl = objParentControl;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ErrorProvider"></see> class attached to an <see cref="T:System.ComponentModel.IContainer"></see> implementation.</summary>
    /// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to monitor for errors.</param>
    public ErrorProvider(IContainer objContainer)
      : this()
    {
      objContainer?.Add((IComponent) this);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        List<Control> controlList = new List<Control>();
        foreach (Control key in this.mobjControlWithErrorsMap.Keys)
          controlList.Add(key);
        foreach (Control objControl in controlList)
          this.SetError(objControl, (string) null);
        this.mobjControlWithErrorsMap.Clear();
      }
      base.Dispose(disposing);
    }

    /// <summary>
    /// Returns the current error description string for the specified control.
    /// </summary>
    /// <returns>The error description string for the specified control.</returns>
    /// <param name="objControl">The item to get the error description string for. </param>
    /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ErrorProviderErrorDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue("")]
    [Localizable(true)]
    public string GetError(Control objControl) => objControl.GetErrorMessage();

    /// <summary>
    /// Gets a value indicating where the error icon should be placed in relation to the control.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorIconAlignment"></see> values. The default icon alignment is <see cref="F:System.Windows.Forms.ErrorIconAlignment.MiddleRight"></see>.</returns>
    /// <param name="objControl">The control to get the icon location for. </param>
    /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ErrorProviderIconAlignmentDescr")]
    [DefaultValue(3)]
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    public ErrorIconAlignment GetIconAlignment(Control objControl) => objControl.ErrorIconAlignment;

    /// <summary>
    /// Returns the amount of extra space to leave next to the error icon.
    /// </summary>
    /// <returns>The number of pixels to leave between the icon and the control. </returns>
    /// <param name="objControl">The control to get the padding for. </param>
    /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ErrorProviderIconPaddingDescr")]
    [DefaultValue(0)]
    [Localizable(true)]
    public int GetIconPadding(Control objControl) => objControl.ErrorIconPadding;

    /// <summary>
    /// Sets the error description string for the specified control.
    /// </summary>
    /// <param name="objControl">The control to set the error description string for. </param>
    /// <param name="strValue">The error description string. </param>
    /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void SetError(Control objControl, string strValue)
    {
      objControl.SetErrorMessage(strValue, this.mobjIcon);
      if (string.IsNullOrEmpty(strValue))
      {
        this.mobjControlWithErrorsMap.Remove(objControl);
      }
      else
      {
        if (this.mobjControlWithErrorsMap.ContainsKey(objControl))
          return;
        Dictionary<Control, Control> controlWithErrorsMap = this.mobjControlWithErrorsMap;
        Control key = objControl;
        controlWithErrorsMap.Add(key, key);
      }
    }

    /// <summary>
    /// Sets the location where the error icon should be placed in relation to the control.
    /// </summary>
    /// <param name="objControl">The control to set the icon location for. </param>
    /// <param name="enmValue">One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorIconAlignment" /> values. </param>
    /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void SetIconAlignment(Control objControl, ErrorIconAlignment enmValue) => objControl.ErrorIconAlignment = enmValue;

    /// <summary>
    /// Sets the amount of extra space to leave between the specified control and the error icon.
    /// </summary>
    /// <param name="objControl">The control to set the padding for. </param>
    /// <param name="intPadding">The number of pixels to add between the icon and the control. </param>
    /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void SetIconPadding(Control objControl, int intPadding) => objControl.ErrorIconPadding = intPadding;

    /// <summary>
    /// Provides a method to update the bindings of the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataSource" />, <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataMember" />, and the error text.
    /// </summary>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void UpdateBinding()
    {
    }

    /// <summary>
    /// Gets a value indicating whether a control can be extended.
    /// </summary>
    /// <returns>true if the control can be extended; otherwise, false.This property will be true if the object is a <see cref="T:Gizmox.WebGUI.Forms.Control" /> and is not a <see cref="T:Gizmox.WebGUI.Forms.Form" /> or <see cref="T:Gizmox.WebGUI.Forms.ToolBar" />.</returns>
    /// <param name="objExtendee">The control to be extended. </param>
    public bool CanExtend(object objExtendee) => false;

    /// <summary>Gets or sets the <see cref="T:System.Drawing.Icon"></see> that is displayed next to a control when an error description string has been set for the control.</summary>
    /// <returns>An <see cref="T:System.Drawing.Icon"></see> that signals an error has occurred. The default icon consists of an exclamation point in a circle with a red background.</returns>
    /// <exception cref="T:System.ArgumentNullException">The assigned value of the <see cref="T:System.Drawing.Icon"></see> is null. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("ErrorProviderIconDescr")]
    [DefaultValue(null)]
    public ResourceHandle Icon
    {
      get => this.mobjIcon;
      set
      {
        if (this.mobjIcon == value)
          return;
        this.mobjIcon = value;
      }
    }

    /// <summary>
    /// Gets or sets the rate at which the error icon flashes.
    /// </summary>
    /// <returns>The rate, in milliseconds, at which the error icon should flash. The default is 250 milliseconds.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than zero. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(250)]
    [SRDescription("ErrorProviderBlinkRateDescr")]
    [SRCategory("CatBehavior")]
    public int BlinkRate
    {
      get => this.mintBlinkRate;
      set => this.mintBlinkRate = value;
    }

    /// <summary>
    /// Gets or sets a value indicating when the error icon flashes.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorBlinkStyle" /> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError" />.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ErrorBlinkStyle" /> values. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatBehavior")]
    [DefaultValue(0)]
    [SRDescription("ErrorProviderBlinkStyleDescr")]
    public ErrorBlinkStyle BlinkStyle
    {
      get => this.menmBlinkStyle;
      set => this.menmBlinkStyle = value;
    }

    /// <summary>
    /// Gets or sets a value indicating the parent control for this <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider" />.
    /// </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ContainerControl" /> that contains the controls that the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider" /> is attached to.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Window="AllWindows" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ErrorProviderContainerControlDescr")]
    [DefaultValue(null)]
    [SRCategory("CatData")]
    public ContainerControl ContainerControl
    {
      get => this.mobjContainerControl;
      set => this.mobjContainerControl = value;
    }

    /// <summary>
    /// Gets or sets the list within a data source to monitor.
    /// </summary>
    /// <returns>The string that represents a list within the data source specified by the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataSource" /> to be monitored. Typically, this will be a <see cref="T:System.Data.DataTable" />.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue("")]
    [SRCategory("CatData")]
    [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [SRDescription("ErrorProviderDataMemberDescr")]
    public string DataMember
    {
      get => this.mstrDataMember;
      set => this.mstrDataMember = value;
    }

    /// <summary>
    /// Gets or sets the data source that the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider" /> monitors.
    /// </summary>
    /// <returns>A data source based on the <see cref="T:System.Collections.IList" /> interface to be monitored for errors. Typically, this is a <see cref="T:System.Data.DataSet" /> to be monitored for errors.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatData")]
    [SRDescription("ErrorProviderDataSourceDescr")]
    [AttributeProvider(typeof (IListSource))]
    [DefaultValue("")]
    public object DataSource
    {
      get => this.mobjDataSource;
      set => this.mobjDataSource = value;
    }
  }
}
