using System;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>Provides pop-up or online Help for controls.</summary>
    /// <filterpriority>2</filterpriority>
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(HelpProvider), "HelpProvider_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(HelpProvider), "HelpProvider.bmp")]
#endif
    [ProvideProperty("ShowHelp", typeof(Control))]
    [ProvideProperty("HelpString", typeof(Control))]
    [ProvideProperty("HelpNavigator", typeof(Control))]
    [SRDescription("DescriptionHelpProvider")]
    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
    [ProvideProperty("HelpKeyword", typeof(Control))]

    [ToolboxItemCategory("Components"), Serializable()]
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
        public virtual bool CanExtend(object objTarget)
        {
            return (objTarget is Control);
        }

        /// <summary>Returns the Help keyword for the specified control.</summary>
        /// <returns>The Help keyword associated with this control, or null if the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see> is currently configured to display the entire Help file or is configured to provide a Help string.</returns>
        /// <param name="Control">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help topic. </param>
        /// <filterpriority>1</filterpriority>
        [DefaultValue((string)null), SRDescription("HelpProviderHelpKeywordDescr"), Localizable(true)]
        public virtual string GetHelpKeyword(Control objControl)
        {
            return (string)this.mobjKeywords[objControl];
        }

        /// <summary>Returns the current <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> setting for the specified control.</summary>
        /// <returns>The <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> setting for the specified control. The default is <see cref="F: Gizmox.WebGUI.Forms.HelpNavigator.AssociateIndex"></see>.</returns>
        /// <param name="Control">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help navigator. </param>
        /// <filterpriority>1</filterpriority>
        [Localizable(true), DefaultValue(HelpNavigator.AssociateIndex), SRDescription("HelpProviderNavigatorDescr")]
        public virtual HelpNavigator GetHelpNavigator(Control Control)
        {
            object obj2 = this.mobjNavigators[Control];
            if (obj2 != null)
            {
                return (HelpNavigator)obj2;
            }
            return HelpNavigator.AssociateIndex;
        }

        /// <summary>Returns the contents of the pop-up Help window for the specified control.</summary>
        /// <returns>The Help string associated with this control. The default is null.</returns>
        /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help string. </param>
        /// <filterpriority>1</filterpriority>
        [DefaultValue((string)null), Localizable(true), SRDescription("HelpProviderHelpStringDescr")]
        public virtual string GetHelpString(Control objControl)
        {
            return (string)this.mobjHelpStrings[objControl];
        }

        /// <summary>Returns a value indicating whether the specified control's Help should be displayed.</summary>
        /// <returns>true if Help will be displayed for the control; otherwise, false.</returns>
        /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> for which Help will be displayed. </param>
        /// <filterpriority>1</filterpriority>
        [Localizable(true), SRDescription("HelpProviderShowHelpDescr")]
        public virtual bool GetShowHelp(Control objControl)
        {
            object obj2 = this.mobjShowHelp[objControl];
            if (obj2 == null)
            {
                return false;
            }
            return (bool)obj2;
        }

        private void OnControlHelp(object sender, HelpEventArgs objHelpEventArgs)
        {
            Control objControl = (Control)sender;
            string strCaption = this.GetHelpString(objControl);
            string strParameter = this.GetHelpKeyword(objControl);
            HelpNavigator enmCommand = this.GetHelpNavigator(objControl);
            if (this.GetShowHelp(objControl))
            {
                //if (((Control.MouseButtons != MouseButtons.None) && (caption != null)) && (caption.Length > 0))
                //{
                //    Help.ShowPopup(ctl, caption, hevent.MousePos);
                //    hevent.Handled = true;
                //}
                if (!objHelpEventArgs.Handled && (this.mstrHelpNamespace != null))
                {
                    if ((strParameter != null) && (strParameter.Length > 0))
                    {
                        Help.ShowHelp(objControl, this.mstrHelpNamespace, enmCommand, strParameter);
                        objHelpEventArgs.Handled = true;
                    }
                    if (!objHelpEventArgs.Handled)
                    {
                        Help.ShowHelp(objControl, this.mstrHelpNamespace, enmCommand);
                        objHelpEventArgs.Handled = true;
                    }
                }
                //if ((!hevent.Handled && (caption != null)) && (caption.Length > 0))
                //{
                //    Help.ShowPopup(ctl, caption, hevent.MousePos);
                //    hevent.Handled = true;
                //}
                if (!objHelpEventArgs.Handled && (this.mstrHelpNamespace != null))
                {
                    Help.ShowHelp(objControl, this.mstrHelpNamespace);
                    objHelpEventArgs.Handled = true;
                }
            }
        }

        //private void OnQueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        //{
        //    Control ctl = (Control)sender;
        //    e.HelpString = this.GetHelpString(ctl);
        //    e.HelpKeyword = this.GetHelpKeyword(ctl);
        //    e.HelpNamespace = this.HelpNamespace;
        //}

        /// <summary>Removes the Help associated with the specified control.</summary>
        /// <param name="objControl">The control to remove Help from.</param>
        /// <filterpriority>1</filterpriority>
        public virtual void ResetShowHelp(Control objControl)
        {
            this.mobjShowHelp.Remove(objControl);
        }

        /// <summary>Specifies the keyword used to retrieve Help when the user invokes Help for the specified control.</summary>
        /// <param name="strKeyword">The Help keyword to associate with the control. </param>
        /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> that specifies the control for which to set the Help topic. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public virtual void SetHelpKeyword(Control objControl, string strKeyword)
        {
            this.mobjKeywords[objControl] = strKeyword;
            if ((strKeyword != null) && (strKeyword.Length > 0))
            {
                this.SetShowHelp(objControl, true);
            }
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
            if (!ClientUtils.IsEnumValid(enmNavigator, (int)enmNavigator, -2147483647, -2147483641))
            {
                throw new InvalidEnumArgumentException("navigator", (int)enmNavigator, typeof(HelpNavigator));
            }
            this.mobjNavigators[objControl] = enmNavigator;
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
            this.mobjHelpStrings[objControl] = strHelpString;
            if ((strHelpString != null) && (strHelpString.Length > 0))
            {
                this.SetShowHelp(objControl, true);
            }
            this.UpdateEventBinding(objControl);
        }

        /// <summary>Specifies whether Help is displayed for the specified control.</summary>
        /// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> for which Help is turned on or off. </param>
        /// <param name="blnValue">true if Help displays for the control; otherwise, false. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public virtual void SetShowHelp(Control objControl, bool blnValue)
        {
            this.mobjShowHelp[objControl] = blnValue;
            this.UpdateEventBinding(objControl);
        }

        internal virtual bool ShouldSerializeShowHelp(Control objControl)
        {
            return this.mobjShowHelp.ContainsKey(objControl);
        }

        /// <summary>Returns a string that represents the current <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</summary>
        /// <returns>A string that represents the current <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return (base.ToString() + ", HelpNamespace: " + this.HelpNamespace);
        }

        private void UpdateEventBinding(Control objControl)
        {
            if (this.GetShowHelp(objControl) && !this.mobjBoundControls.ContainsKey(objControl))
            {
                objControl.HelpRequested += new HelpEventHandler(this.OnControlHelp);
                //ctl.QueryAccessibilityHelp += new QueryAccessibilityHelpEventHandler(this.OnQueryAccessibilityHelp);
                this.mobjBoundControls[objControl] = objControl;
            }
            else if (!this.GetShowHelp(objControl) && this.mobjBoundControls.ContainsKey(objControl))
            {
                objControl.HelpRequested -= new HelpEventHandler(this.OnControlHelp);
                //ctl.QueryAccessibilityHelp -= new QueryAccessibilityHelpEventHandler(this.OnQueryAccessibilityHelp);
                this.mobjBoundControls.Remove(objControl);
            }
        }

        /// <summary>Gets or sets a value specifying the name of the Help file associated with this <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see> object.</summary>
        /// <returns>The name of the Help file. This can be of the form C:\path\sample.chm or /folder/file.htm.</returns>
        /// <filterpriority>1</filterpriority>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        //[Editor(" Gizmox.WebGUI.Forms.Design.HelpNamespaceEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SRDescription("HelpProviderHelpNamespaceDescr"), Localizable(true), DefaultValue((string)null)]
#elif WG_NET35
        //[Editor(" Gizmox.WebGUI.Forms.Design.HelpNamespaceEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SRDescription("HelpProviderHelpNamespaceDescr"), Localizable(true), DefaultValue((string)null)]
#elif WG_NET2
        //[Editor(" Gizmox.WebGUI.Forms.Design.HelpNamespaceEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SRDescription("HelpProviderHelpNamespaceDescr"), Localizable(true), DefaultValue((string)null)]
#else
        //[Editor(" Gizmox.WebGUI.Forms.Design.HelpNamespaceEditor, System.Design, Version=1.0.500.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SRDescription("HelpProviderHelpNamespaceDescr"), Localizable(true), DefaultValue((string)null)]
#endif
        [DefaultValue("")]
        public virtual string HelpNamespace
        {
            get
            {
                return this.mstrHelpNamespace;
            }
            set
            {
                this.mstrHelpNamespace = value;
            }
        }

        /// <summary>Gets or sets the object that contains supplemental data about the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that contains data about the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatData"), Bindable(true), DefaultValue((string)null), Localizable(false), SRDescription("ControlTagDescr"), TypeConverter(typeof(StringConverter))]
        public object Tag
        {
            get
            {
                return this.mobjUserData;
            }
            set
            {
                this.mobjUserData = value;
            }
        }
    }
}
