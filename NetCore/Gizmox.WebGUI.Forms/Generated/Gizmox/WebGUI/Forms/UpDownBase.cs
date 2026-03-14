#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// 
	/// Implements the basic functionality required by a spin box (also known as an up-down control).
	/// </summary>
	/// 2</filterpriority>
	[Serializable]
	[Skin(typeof(UpDownBaseSkin))]
	public abstract class UpDownBase : ContainerControl
	{
		/// 
		///
		/// </summary>
		internal enum ButtonID
		{
			/// 
			///
			/// </summary>
			None,
			/// 
			///
			/// </summary>
			Up,
			/// 
			///
			/// </summary>
			Down
		}

		/// 
		/// Provides a property reference to ChangingText Property.
		/// </summary>
		private static SerializableProperty ChangingTextProperty = SerializableProperty.Register("ChangingText", typeof(bool), typeof(UpDownBase), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to HideButtons property.
		/// </summary>
		private static SerializableProperty HideButtonsProperty = SerializableProperty.Register("HideButtons", typeof(bool), typeof(UpDownBase), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to UpDownAlign  Property.
		/// </summary>        
		private static SerializableProperty InterceptArrowKeysProperty = SerializableProperty.Register("InterceptArrowKeys", typeof(bool), typeof(UpDownBase), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to HorizontalAlignment property.
		/// </summary>
		private static SerializableProperty TextAlignProperty = SerializableProperty.Register("TextAlign", typeof(HorizontalAlignment), typeof(UpDownBase), new SerializablePropertyMetadata(HorizontalAlignment.Left));

		/// 
		/// Provides a property reference to Text property.
		/// </summary>
		private static SerializableProperty TextProperty = SerializableProperty.Register("Text", typeof(string), typeof(UpDownBase), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to UpDownAlign  Property.
		/// </summary>        
		private static SerializableProperty UpDownAlignProperty = SerializableProperty.Register("UpDownAlign", typeof(LeftRightAlignment), typeof(UpDownBase), new SerializablePropertyMetadata(LeftRightAlignment.Right));

		/// 
		/// Provides a property reference to HideButtons property.
		/// </summary>
		private static SerializableProperty UserEditProperty = SerializableProperty.Register("UserEdit", typeof(bool), typeof(UpDownBase), new SerializablePropertyMetadata(false));

		/// Gets a value indicating whether the container will allow the user to scroll to any controls placed outside of its visible boundaries.</summary>
		/// false in all cases.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool AutoScroll
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether the control should automatically resize based on its contents.</summary>
		/// true to indicate the control should automatically resize based on its contents; otherwise, false.</returns>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
			}
		}

		/// Gets or sets the layout of the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.BackgroundImage"></see> of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see>.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> values.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
				base.BackgroundImageLayout = value;
			}
		}

		/// Gets or sets the border style for the spin box (also known as an up-down control).</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.BorderStyle.Fixed3D"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> values. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("UpDownBaseBorderStyleDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(2)]
		[DispId(-504)]
		public override BorderStyle BorderStyle
		{
			get
			{
				return base.BorderStyle;
			}
			set
			{
				base.BorderStyle = value;
			}
		}

		/// Gets or sets a value indicating whether the text property is being changed internally by its parent class.</summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.Text"></see> property is being changed internally by the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> class; otherwise, false.</returns>
		protected bool ChangingText
		{
			get
			{
				return GetValue(ChangingTextProperty);
			}
			set
			{
				SetValue(ChangingTextProperty, value);
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected override Size DefaultSize => new Size(120, PreferredHeight);

		/// Gets the dock padding settings for all edges of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> control.</summary>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DockPaddingEdges DockPadding => base.DockPadding;

		/// 
		/// Gets or sets a value indicating whether the buttons are hidden or not.
		/// </summary>
		/// true if the buttons are hidden; otherwise, false. The default is false.</returns>
		[DefaultValue(false)]
		[SRCategory("CatAppearance")]
		public bool HideButtons
		{
			get
			{
				return GetValue(HideButtonsProperty);
			}
			set
			{
				if (SetValue(HideButtonsProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether the user can use the UP ARROW and DOWN ARROW keys to select values.</summary>
		/// true if the control allows the use of the UP ARROW and DOWN ARROW keys to select values; otherwise, false. The default value is true.</returns>
		/// 1</filterpriority>
		[DefaultValue(true)]
		[SRDescription("UpDownBaseInterceptArrowKeysDescr")]
		[SRCategory("CatBehavior")]
		public bool InterceptArrowKeys
		{
			get
			{
				return GetValue(InterceptArrowKeysProperty);
			}
			set
			{
				if (SetValue(InterceptArrowKeysProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the maximum size of the spin box (also known as an up-down control).</summary>
		/// The <see cref="T:System.Drawing.Size"></see>, which is the maximum size of the spin box.</returns>
		/// 1</filterpriority>
		public override Size MaximumSize
		{
			get
			{
				return base.MaximumSize;
			}
			set
			{
				base.MaximumSize = new Size(value.Width, 0);
			}
		}

		/// Gets or sets the minimum size of the spin box (also known as an up-down control).</summary>
		/// The <see cref="T:System.Drawing.Size"></see>, which is the minimum size of the spin box.</returns>
		/// 1</filterpriority>
		public override Size MinimumSize
		{
			get
			{
				return base.MinimumSize;
			}
			set
			{
				base.MinimumSize = new Size(value.Width, 0);
			}
		}

		/// Gets the height of the spin box (also known as an up-down control).</summary>
		/// The height, in pixels, of the spin box.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("UpDownBasePreferredHeightDescr")]
		[SRCategory("CatLayout")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int PreferredHeight
		{
			get
			{
				int num = Convert.ToInt32(CommonUtils.GetFontHeight(Font));
				if (BorderStyle != BorderStyle.None)
				{
					return num + (BorderWidth.Bottom + BorderWidth.Left + BorderWidth.Right + BorderWidth.Top + 3);
				}
				return num + 3;
			}
		}

		/// Gets or sets a value indicating whether the user can edit the band's cells.</summary>
		/// true if the user cannot edit the band's cells; otherwise, false. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
		/// 1</filterpriority>
		[DefaultValue(false)]
		public virtual bool ReadOnly
		{
			get
			{
				return GetState(ComponentState.ReadOnly);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.ReadOnly, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the text displayed in the spin box (also known as an up-down control).</summary>
		/// The string value displayed in the spin box.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		public override string Text
		{
			get
			{
				return GetValue(TextProperty);
			}
			set
			{
				if (SetTextInternal(value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the alignment of the text in the spin box (also known as an up-down control).</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[DefaultValue(HorizontalAlignment.Left)]
		[SRDescription("UpDownBaseTextAlignDescr")]
		[Localizable(true)]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return GetValue(TextAlignProperty);
			}
			set
			{
				if (SetValue(TextAlignProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the alignment of the up and down buttons on the spin box (also known as an up-down control).</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.LeftRightAlignment"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.LeftRightAlignment.Right"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.LeftRightAlignment"></see> values. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("UpDownBaseAlignmentDescr")]
		[Localizable(true)]
		[DefaultValue(1)]
		[SRCategory("CatAppearance")]
		public LeftRightAlignment UpDownAlign
		{
			get
			{
				return GetValue(UpDownAlignProperty);
			}
			set
			{
				if (SetValue(UpDownAlignProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether a value has been entered by the user.</summary>
		/// true if the user has changed the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.Text"></see> property; otherwise, false.</returns>
		protected bool UserEdit
		{
			get
			{
				return GetValue(UserEditProperty);
			}
			set
			{
				SetValue(UserEditProperty, value);
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// 
		/// Gets a value indicating whether [supports focus events].
		/// </summary>
		/// true</c> if [supports focus events]; otherwise, false</c>.</value>
		protected internal override bool SupportsFocusEvents => true;

		/// 
		/// Gets a value indicating whether raise click event on mouse down.
		/// </summary>
		/// 
		/// 	true</c> if should raise click event on mouse down; otherwise, false</c>.
		/// </value>
		protected override bool ShouldRaiseClickOnRightMouseDown => false;

		/// 
		/// Gets the resizable allowed directions.
		/// </summary>
		protected override string[] ResizableAllowedDirections => new string[2] { "e", "w" };

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> class.
		/// </summary>
		public UpDownBase()
		{
			SetStyle(ControlStyles.FixedHeight | ControlStyles.Opaque | ControlStyles.ResizeRedraw, blnValue: true);
			SetStyle(ControlStyles.StandardClick, blnValue: false);
			SetStyle(ControlStyles.UseTextForAccessibility, blnValue: false);
		}

		/// 
		/// Gets or sets the text internal.
		/// </summary>
		/// <param name="strValue">The value.</param>
		/// </returns>
		protected bool SetTextInternal(string strValue)
		{
			if (SetValue(TextProperty, strValue))
			{
				OnTextBoxTextChanged(this, EventArgs.Empty);
				ChangingText = false;
				if (UserEdit)
				{
					ValidateEditText();
				}
				return true;
			}
			return false;
		}

		/// 
		/// When overridden in a derived class, 
		/// handles the clicking of the down button on the spin box 
		/// (also known as an up-down control).</summary>
		/// 1</filterpriority>
		public abstract void DownButton();

		/// 
		/// Selects a range of text in the spin box 
		/// (also known as an up-down control) specifying 
		/// the starting position and number of characters 
		/// to select.
		/// </summary>
		/// <param name="intStart">The position of the first character to be selected. </param>
		/// <param name="intLength">The total number of characters to be selected. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Select(int intStart, int intLength)
		{
			InvokeMethodWithId("UpDownBase_SetSelection", intStart, intLength);
		}

		/// When overridden in a derived class, handles the clicking of the up button on the spin box (also known as an up-down control).</summary>
		/// 1</filterpriority>
		public abstract void UpButton();

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "ValueChange")
			{
				string text = CommonUtils.DecodeText(objEvent["VLB"]);
				bool blnIsIndex = objEvent["IX"] == "1";
				if (!string.IsNullOrEmpty(text))
				{
					SetUpDownValue(text, blnIsIndex);
				}
			}
			else
			{
				base.FireEvent(objEvent);
			}
		}

		/// 
		/// Gets the key event captures.
		/// </summary>
		/// </returns>
		protected override KeyCaptures GetKeyEventCaptures()
		{
			KeyCaptures keyEventCaptures = base.GetKeyEventCaptures();
			keyEventCaptures |= KeyCaptures.UpKeyCapture;
			keyEventCaptures |= KeyCaptures.DownKeyCapture;
			keyEventCaptures |= KeyCaptures.EndKeyCapture;
			keyEventCaptures |= KeyCaptures.HomeKeyCapture;
			keyEventCaptures |= KeyCaptures.PageDownKeyCapture;
			return keyEventCaptures | KeyCaptures.PageUpKeyCapture;
		}

		/// When overridden in a derived class, raises the Changed event.</summary>
		/// <param name="objSource">The source of the event.</param>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnChanged(object objSource, EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.FontChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected override void OnFontChanged(EventArgs e)
		{
			base.Height = PreferredHeight;
			base.OnFontChanged(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleCreated"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.</summary>
		/// <param name="objSource">The source of the event. </param>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		protected virtual void OnTextBoxKeyDown(object objSource, KeyEventArgs e)
		{
			if (InterceptArrowKeys)
			{
				if (e.KeyData == Keys.Up)
				{
					UpButton();
				}
				else if (e.KeyData == Keys.Down)
				{
					DownButton();
				}
			}
			if (e.KeyCode == Keys.Enter && UserEdit)
			{
				ValidateEditText();
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyPress"></see> event.</summary>
		/// <param name="objSource">The source of the event. </param>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
		protected virtual void OnTextBoxKeyPress(object objSource, KeyPressEventArgs e)
		{
			OnKeyPress(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LostFocus"></see> event.</summary>
		/// <param name="objSource">The source of the event. </param>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnTextBoxLostFocus(object objSource, EventArgs e)
		{
			if (UserEdit)
			{
				ValidateEditText();
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Resize"></see> event.</summary>
		/// <param name="objSource">The source of the event. </param>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnTextBoxResize(object objSource, EventArgs e)
		{
			base.Height = PreferredHeight;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.TextChanged"></see> event.</summary>
		/// <param name="objSource">The source of the event. </param>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnTextBoxTextChanged(object objSource, EventArgs e)
		{
			if (ChangingText)
			{
				ChangingText = false;
			}
			else
			{
				UserEdit = true;
			}
			OnTextChanged(e);
			OnChanged(objSource, new EventArgs());
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (HideButtons)
			{
				objWriter.WriteAttributeString("HB", "1");
			}
			if (ReadOnly)
			{
				objWriter.WriteAttributeString("RO", "1");
			}
			if (!InterceptArrowKeys)
			{
				objWriter.WriteAttributeString("IAK", "0");
			}
			if (TextAlign != HorizontalAlignment.Center)
			{
				objWriter.WriteAttributeString("TA", TextAlign.ToString());
			}
			LeftRightAlignment upDownAlign = UpDownAlign;
			if ((upDownAlign == LeftRightAlignment.Left && !Context.RightToLeft) || (upDownAlign == LeftRightAlignment.Right && Context.RightToLeft))
			{
				objWriter.WriteAttributeString("UDA", LeftRightAlignment.Left.ToString());
			}
		}

		/// 
		/// Sets up down value.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// <param name="blnIsIndex">if set to true</c> [BLN is index].</param>
		protected virtual void SetUpDownValue(string strValue, bool blnIsIndex)
		{
		}

		/// When overridden in a derived class, updates the text displayed in the spin box (also known as an up-down control).</summary>
		protected abstract void UpdateEditText();

		/// When overridden in a derived class, validates the text displayed in the spin box (also known as an up-down control).</summary>
		protected virtual void ValidateEditText()
		{
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new UpDownBaseRenderer(this);
		}

		/// 
		/// Called when [up down].
		/// </summary>
		/// <param name="objSource">The source.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.UpDownEventArgs" /> instance containing the event data.</param>
		private void OnUpDown(object objSource, UpDownEventArgs e)
		{
			if (e.ButtonID == 1)
			{
				UpButton();
			}
			else if (e.ButtonID == 2)
			{
				DownButton();
			}
		}

		internal override Rectangle ApplyBoundsConstraints(int intSuggestedX, int intSuggestedY, int intProposedWidth, int intProposedHeight)
		{
			return base.ApplyBoundsConstraints(intSuggestedX, intSuggestedY, intProposedWidth, PreferredHeight);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
		/// </summary>
		internal virtual void OnStartTimer()
		{
		}

		/// 
		/// Called when [stop timer].
		/// </summary>
		internal virtual void OnStopTimer()
		{
		}
	}
}
