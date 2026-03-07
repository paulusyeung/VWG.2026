// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HelpProvider
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides pop-up or online Help for controls.</summary>
  /// <filterpriority>2</filterpriority>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (HelpProvider), "HelpProvider_45.bmp")]
  [ProvideProperty("ShowHelp", typeof (Control))]
  [ProvideProperty("HelpString", typeof (Control))]
  [ProvideProperty("HelpNavigator", typeof (Control))]
  [SRDescription("DescriptionHelpProvider")]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [ProvideProperty("HelpKeyword", typeof (Control))]
  [ToolboxItemCategory("Components")]
  [Serializable]
  public class HelpProvider : ComponentBase, IExtenderProvider
  {
    private Hashtable mobjBoundControls = new Hashtable();
    private string mstrHelpNamespace;
    private Hashtable mobjHelpStrings = new Hashtable();
    private Hashtable mobjKeywords = new Hashtable();
    private Hashtable mobjNavigators = new Hashtable();
    private Hashtable mobjShowHelp = new Hashtable();
    private object mobjUserData;

    /// <summary>Specifies whether this object can provide its extender properties to the specified object.</summary>
    /// <param name="objTarget">The object </param>
    /// <filterpriority>1</filterpriority>
    public virtual bool CanExtend(object objTarget) => objTarget is Control;

    /// <summary>Returns the Help keyword for the specified control.</summary>
    /// <returns>The Help keyword associated with this control, or null if the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see> is currently configured to display the entire Help file or is configured to provide a Help string.</returns>
    /// <param name="Control">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help topic. </param>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    [SRDescription("HelpProviderHelpKeywordDescr")]
    [Localizable(true)]
    public virtual string GetHelpKeyword(Control objControl) => (string) this.mobjKeywords[(object) objControl];

    /// <summary>Returns the current <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> setting for the specified control.</summary>
    /// <returns>The <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> setting for the specified control. The default is <see cref="F: Gizmox.WebGUI.Forms.HelpNavigator.AssociateIndex"></see>.</returns>
    /// <param name="Control">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help navigator. </param>
    /// <filterpriority>1</filterpriority>
    [Localizable(true)]
    [DefaultValue(HelpNavigator.AssociateIndex)]
    [SRDescription("HelpProviderNavigatorDescr")]
    public virtual HelpNavigator GetHelpNavigator(Control Control)
    {
      object mobjNavigator = this.mobjNavigators[(object) Control];
      return mobjNavigator != null ? (HelpNavigator) mobjNavigator : HelpNavigator.AssociateIndex;
    }

    /// <summary>Returns the contents of the pop-up Help window for the specified control.</summary>
    /// <returns>The Help string associated with this control. The default is null.</returns>
    /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help string. </param>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    [Localizable(true)]
    [SRDescription("HelpProviderHelpStringDescr")]
    public virtual string GetHelpString(Control objControl) => (string) this.mobjHelpStrings[(object) objControl];

    /// <summary>Returns a value indicating whether the specified control's Help should be displayed.</summary>
    /// <returns>true if Help will be displayed for the control; otherwise, false.</returns>
    /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> for which Help will be displayed. </param>
    /// <filterpriority>1</filterpriority>
    [Localizable(true)]
    [SRDescription("HelpProviderShowHelpDescr")]
    public virtual bool GetShowHelp(Control objControl)
    {
      object obj = this.mobjShowHelp[(object) objControl];
      return obj != null && (bool) obj;
    }

    private void OnControlHelp(object sender, HelpEventArgs objHelpEventArgs)
    {
      Control control = (Control) sender;
      this.GetHelpString(control);
      string helpKeyword = this.GetHelpKeyword(control);
      HelpNavigator helpNavigator = this.GetHelpNavigator(control);
      if (!this.GetShowHelp(control))
        return;
      if (!objHelpEventArgs.Handled && this.mstrHelpNamespace != null)
      {
        if (helpKeyword != null && helpKeyword.Length > 0)
        {
          Help.ShowHelp(control, this.mstrHelpNamespace, helpNavigator, (object) helpKeyword);
          objHelpEventArgs.Handled = true;
        }
        if (!objHelpEventArgs.Handled)
        {
          Help.ShowHelp(control, this.mstrHelpNamespace, helpNavigator);
          objHelpEventArgs.Handled = true;
        }
      }
      if (objHelpEventArgs.Handled || this.mstrHelpNamespace == null)
        return;
      Help.ShowHelp(control, this.mstrHelpNamespace);
      objHelpEventArgs.Handled = true;
    }

    /// <summary>Removes the Help associated with the specified control.</summary>
    /// <param name="objControl">The control to remove Help from.</param>
    /// <filterpriority>1</filterpriority>
    public virtual void ResetShowHelp(Control objControl) => this.mobjShowHelp.Remove((object) objControl);

    /// <summary>Specifies the keyword used to retrieve Help when the user invokes Help for the specified control.</summary>
    /// <param name="strKeyword">The Help keyword to associate with the control. </param>
    /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> that specifies the control for which to set the Help topic. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual void SetHelpKeyword(Control objControl, string strKeyword)
    {
      this.mobjKeywords[(object) objControl] = (object) strKeyword;
      if (strKeyword != null && strKeyword.Length > 0)
        this.SetShowHelp(objControl, true);
      this.UpdateEventBinding(objControl);
    }

    /// <summary>Specifies the Help command to use when retrieving Help from the Help file for the specified control.</summary>
    /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> for which to set the Help keyword. </param>
    /// <param name="enmNavigator">One of the <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> values. </param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value of navigator is not one of the <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual void SetHelpNavigator(Control objControl, HelpNavigator enmNavigator)
    {
      this.mobjNavigators[(object) objControl] = ClientUtils.IsEnumValid((Enum) enmNavigator, (int) enmNavigator, -2147483647, -2147483641) ? (object) enmNavigator : throw new InvalidEnumArgumentException("navigator", (int) enmNavigator, typeof (HelpNavigator));
      this.SetShowHelp(objControl, true);
      this.UpdateEventBinding(objControl);
    }

    /// <summary>Specifies the Help string associated with the specified control.</summary>
    /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> with which to associate the Help string. </param>
    /// <param name="strHelpString">The Help string associated with the control. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual void SetHelpString(Control objControl, string strHelpString)
    {
      this.mobjHelpStrings[(object) objControl] = (object) strHelpString;
      if (strHelpString != null && strHelpString.Length > 0)
        this.SetShowHelp(objControl, true);
      this.UpdateEventBinding(objControl);
    }

    /// <summary>Specifies whether Help is displayed for the specified control.</summary>
    /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> for which Help is turned on or off. </param>
    /// <param name="blnValue">true if Help displays for the control; otherwise, false. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual void SetShowHelp(Control objControl, bool blnValue)
    {
      this.mobjShowHelp[(object) objControl] = (object) blnValue;
      this.UpdateEventBinding(objControl);
    }

    internal virtual bool ShouldSerializeShowHelp(Control objControl) => this.mobjShowHelp.ContainsKey((object) objControl);

    /// <summary>Returns a string that represents the current <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</summary>
    /// <returns>A string that represents the current <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString() => base.ToString() + ", HelpNamespace: " + this.HelpNamespace;

    private void UpdateEventBinding(Control objControl)
    {
      if (this.GetShowHelp(objControl) && !this.mobjBoundControls.ContainsKey((object) objControl))
      {
        objControl.HelpRequested += new HelpEventHandler(this.OnControlHelp);
        this.mobjBoundControls[(object) objControl] = (object) objControl;
      }
      else
      {
        if (this.GetShowHelp(objControl) || !this.mobjBoundControls.ContainsKey((object) objControl))
          return;
        objControl.HelpRequested -= new HelpEventHandler(this.OnControlHelp);
        this.mobjBoundControls.Remove((object) objControl);
      }
    }

    /// <summary>Gets or sets a value specifying the name of the Help file associated with this <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see> object.</summary>
    /// <returns>The name of the Help file. This can be of the form C:\path\sample.chm or /folder/file.htm.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    public virtual string HelpNamespace
    {
      get => this.mstrHelpNamespace;
      set => this.mstrHelpNamespace = value;
    }

    /// <summary>Gets or sets the object that contains supplemental data about the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that contains data about the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [Bindable(true)]
    [DefaultValue(null)]
    [Localizable(false)]
    [SRDescription("ControlTagDescr")]
    [TypeConverter(typeof (StringConverter))]
    public object Tag
    {
      get => this.mobjUserData;
      set => this.mobjUserData = value;
    }
  }
}
