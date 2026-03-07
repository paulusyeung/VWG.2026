using System;
using System.Drawing.Design;
using Gizmox.WebGUI.Common;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{

	#region Enums
    /// <summary>
    /// Specifies constants indicating when the error icon, supplied by an <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"/>, should blink to alert the user that an error has occurred.
    /// </summary>
	
	public enum ErrorBlinkStyle
	{
        /// <summary>
        /// Always blink when the error icon is first displayed, or when a error description string is set for the control and the error icon is already displayed.
        /// </summary>
		AlwaysBlink = 1,
        /// <summary>
        /// Blinks when the icon is already displayed and a new error string is set for the control.
        /// </summary>
		BlinkIfDifferentError = 0,
        /// <summary>
        /// Never blink the error icon.
        /// </summary>
		NeverBlink = 2
	}


    /// <summary>
    /// Specifies constants indicating the locations that an error icon can appear in relation to the control with an error.
    /// </summary>
	
	public enum ErrorIconAlignment
	{
        /// <summary>
        /// The icon appears aligned with the bottom of the control and the left of the control.
        /// </summary>
        BottomLeft = 4,

        /// <summary>
        /// The icon appears aligned with the bottom of the control and the right of the control.
        /// </summary>
        BottomRight = 5,

        /// <summary>
        /// The icon appears aligned with the middle of the control and the left of the control.
        /// </summary>
        MiddleLeft = 2,


        /// <summary>
        /// The icon appears aligned with the middle of the control and the right of the control.
        /// </summary>
        MiddleRight = 3,

        /// <summary>
        /// The icon appears aligned with the top of the control and to the left of the control.
        /// </summary>
        TopLeft = 0,

        /// <summary>
        /// The icon appears aligned with the top of the control and to the right of the control.
        /// </summary>
        TopRight = 1
	}

	#endregion 

	#region ErrorProvider Class

	/// <summary>
    /// Provides a user interface for indicating that a control on a form has an error associated with it.
	/// </summary>
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [System.Drawing.ToolboxBitmap(typeof(ErrorProvider), "ErrorProvider_45.bmp")]
#else
    [System.Drawing.ToolboxBitmap(typeof(ErrorProvider), "ErrorProvider.bmp")]
#endif
    [ProvideProperty("IconAlignment", typeof(Control)), SRDescription("DescriptionErrorProvider"), ComplexBindingProperties("DataSource", "DataMember"), ProvideProperty("Error", typeof(Control)), ProvideProperty("IconPadding", typeof(Control))]
	
    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
    [ToolboxItemCategory("Components"), Serializable()]
    public class ErrorProvider : ComponentBase
	{

		#region Class Members

		private int mintBlinkRate = 3;
		private ErrorBlinkStyle menmBlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
		private string mstrDataMember = "";
		private object mobjDataSource = "";
		private ContainerControl mobjContainerControl = null;
        private ResourceHandle mobjIcon = null;
        private Dictionary<Control, Control> mobjControlWithErrorsMap = new Dictionary<Control, Control>();

		#endregion 

		#region C'Tor\D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"></see> class and initializes the default settings for <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.BlinkRate"></see>, <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.BlinkStyle"></see>, and the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.Icon"></see>.
        /// </summary>
		public ErrorProvider()
		{
			
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"></see> class attached to a container.
        /// </summary>
        ///	<param name="objParentControl">The container of the control to monitor for errors. </param>
        public ErrorProvider(ContainerControl objParentControl)
		{
            mobjContainerControl = objParentControl;
		}

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ErrorProvider"></see> class attached to an <see cref="T:System.ComponentModel.IContainer"></see> implementation.</summary>
        /// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to monitor for errors.</param>
        public ErrorProvider(IContainer objContainer)
            : this()
        {
            // Null is retrieved during Runtime. Should work in Design Time only
            if (objContainer != null)
            {
                objContainer.Add(this);
            }
        }

		#endregion 

		#region Methods

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Remove the errors from the controls.
                List<Control> objControlErrorsToDispose = new List<Control>();
                foreach (Control control in mobjControlWithErrorsMap.Keys)
                {
                    objControlErrorsToDispose.Add(control);
                }

                foreach (Control objControlErrorToDispse in objControlErrorsToDispose)
                {
                    SetError(objControlErrorToDispse, null);
                }

                mobjControlWithErrorsMap.Clear();
            }
            // base Dispose
            base.Dispose(disposing);
        }

		/// <summary>
		/// Returns the current error description string for the specified control.
		/// </summary>
		///	<returns>The error description string for the specified control.</returns>
        ///	<param name="objControl">The item to get the error description string for. </param>
		///	<exception cref="T:System.ArgumentNullException">control is null.</exception>
		/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ErrorProviderErrorDescr"), SRCategory("CatAppearance"), DefaultValue(""), Localizable(true)]
        public string GetError(Control objControl)
		{
			return objControl.GetErrorMessage();
		}
		
		/// <summary>
		/// Gets a value indicating where the error icon should be placed in relation to the control.
		/// </summary>
        ///	<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorIconAlignment"></see> values. The default icon alignment is <see cref="F:System.Windows.Forms.ErrorIconAlignment.MiddleRight"></see>.</returns>
        ///	<param name="objControl">The control to get the icon location for. </param>
		///	<exception cref="T:System.ArgumentNullException">control is null.</exception>
		/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ErrorProviderIconAlignmentDescr"), DefaultValue(3), Localizable(true), SRCategory("CatAppearance")]
        public ErrorIconAlignment GetIconAlignment(Control objControl)
		{
			return objControl.ErrorIconAlignment;
		}

        /// <summary>
        /// Returns the amount of extra space to leave next to the error icon.
        /// </summary>
        /// <returns>The number of pixels to leave between the icon and the control. </returns>
        /// <param name="objControl">The control to get the padding for. </param>
        /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ErrorProviderIconPaddingDescr"), DefaultValue(0), Localizable(true)]
		public int GetIconPadding(Control objControl)
		{
			return objControl.ErrorIconPadding;
		}

        /// <summary>
        /// Sets the error description string for the specified control.
        /// </summary>
        /// <param name="objControl">The control to set the error description string for. </param>
        /// <param name="strValue">The error description string. </param>
        /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SetError(Control objControl, string strValue)
		{
			objControl.SetErrorMessage(strValue, mobjIcon);

            // Update the list of controls with errors.
            if (string.IsNullOrEmpty(strValue))
            {
                mobjControlWithErrorsMap.Remove(objControl);
            }
            else if (!mobjControlWithErrorsMap.ContainsKey(objControl))
            {
                mobjControlWithErrorsMap.Add(objControl, objControl);
            }
		}

        /// <summary>
        /// Sets the location where the error icon should be placed in relation to the control.
        /// </summary>
        /// <param name="objControl">The control to set the icon location for. </param>
        /// <param name="enmValue">One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorIconAlignment"/> values. </param>
        /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SetIconAlignment(Control objControl, ErrorIconAlignment enmValue)
		{
			objControl.ErrorIconAlignment = enmValue;
		}

        /// <summary>
        /// Sets the amount of extra space to leave between the specified control and the error icon.
        /// </summary>
        /// <param name="objControl">The control to set the padding for. </param>
        /// <param name="intPadding">The number of pixels to add between the icon and the control. </param>
        /// <exception cref="T:System.ArgumentNullException">control is null.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SetIconPadding(Control objControl, int intPadding)
		{
			objControl.ErrorIconPadding = intPadding;
		}

		#region Compatible Methods

        /// <summary>
        /// Provides a method to update the bindings of the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataSource"/>, <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataMember"/>, and the error text.
        /// </summary>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void UpdateBinding()
		{
		}

        /// <summary>
        /// Gets a value indicating whether a control can be extended.
        /// </summary>
        /// <returns>true if the control can be extended; otherwise, false.This property will be true if the object is a <see cref="T:Gizmox.WebGUI.Forms.Control"/> and is not a <see cref="T:Gizmox.WebGUI.Forms.Form"/> or <see cref="T:Gizmox.WebGUI.Forms.ToolBar"/>.</returns>
        /// <param name="objExtendee">The control to be extended. </param>
		public bool CanExtend(object objExtendee)
		{
			return false;
		}

		#endregion 

		#endregion 

		#region Properties

        /// <summary>Gets or sets the <see cref="T:System.Drawing.Icon"></see> that is displayed next to a control when an error description string has been set for the control.</summary>
        /// <returns>An <see cref="T:System.Drawing.Icon"></see> that signals an error has occurred. The default icon consists of an exclamation point in a circle with a red background.</returns>
        /// <exception cref="T:System.ArgumentNullException">The assigned value of the <see cref="T:System.Drawing.Icon"></see> is null. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), SRCategory("CatAppearance"), SRDescription("ErrorProviderIconDescr"),DefaultValue(null)]
        public ResourceHandle Icon
        {
            get
            {
                return mobjIcon;
            }
            set
            {
                if (mobjIcon != value)
                {
                    mobjIcon = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the rate at which the error icon flashes.
        /// </summary>
        /// <returns>The rate, in milliseconds, at which the error icon should flash. The default is 250 milliseconds.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than zero. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [RefreshProperties(RefreshProperties.Repaint), DefaultValue(250), SRDescription("ErrorProviderBlinkRateDescr"), SRCategory("CatBehavior")]
		public int BlinkRate 
		{ 
			get 
			{
				return mintBlinkRate;
			}
			set
			{
				mintBlinkRate = value;
			}
		}

        /// <summary>
        /// Gets or sets a value indicating when the error icon flashes.
        /// </summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorBlinkStyle"/> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError"/>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ErrorBlinkStyle"/> values. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), DefaultValue(0), SRDescription("ErrorProviderBlinkStyleDescr")]
		public ErrorBlinkStyle BlinkStyle
		{ 
			get 
			{
				return menmBlinkStyle;
			}
			set
			{
				menmBlinkStyle = value;
			}
		}

        /// <summary>
        /// Gets or sets a value indicating the parent control for this <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"/>.
        /// </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ContainerControl"/> that contains the controls that the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"/> is attached to.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Window="AllWindows" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ErrorProviderContainerControlDescr"), DefaultValue((string)null), SRCategory("CatData")]
		public ContainerControl ContainerControl 
		{ 
			get 
			{
				return mobjContainerControl;
			}
			set
			{
				mobjContainerControl = value;
			}
		}

        /// <summary>
        /// Gets or sets the list within a data source to monitor.
        /// </summary>
        /// <returns>The string that represents a list within the data source specified by the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataSource"/> to be monitored. Typically, this will be a <see cref="T:System.Data.DataTable"/>.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DefaultValue(""), SRCategory("CatData"), Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SRDescription("ErrorProviderDataMemberDescr")]
#else
        [DefaultValue(""), SRCategory("CatData"), Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SRDescription("ErrorProviderDataMemberDescr")]
#endif
        public string DataMember 
		{ 
			get 
			{
				return mstrDataMember;
			}
			set
			{
				mstrDataMember = value;
			}
		}

        /// <summary>
        /// Gets or sets the data source that the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"/> monitors.
        /// </summary>
        /// <returns>A data source based on the <see cref="T:System.Collections.IList"/> interface to be monitored for errors. Typically, this is a <see cref="T:System.Data.DataSet"/> to be monitored for errors.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatData"), SRDescription("ErrorProviderDataSourceDescr"), AttributeProvider(typeof(IListSource)), DefaultValue("")]
		public object DataSource 
		{ 
			get 
			{
				return mobjDataSource;
			}
			set
			{
				mobjDataSource = value;
			}
		}

		#endregion 

	}

	#endregion 
}
