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
/// Represents a text box in a <see cref="T:System.Windows.Forms.ToolStrip"></see> that allows the user to enter text.</summary>
	[Serializable]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripTextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolStripItemDesignerAvailability((ToolStripItemDesignerAvailability)7)]
	public class ToolStripTextBox : ToolStripControlHost
	{
		/// Gets or sets a value indicating whether pressing ENTER in a multiline <see cref="T:System.Windows.Forms.TextBox"></see> control creates a new line of text in the control or activates the default button for the form.</summary>
		/// true if the ENTER key creates a new line of text in a multiline version of the control; false if the ENTER key activates the default button for the form. The default is false.</returns>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("TextBoxAcceptsReturnDescr")]
		public bool AcceptsReturn
		{
			get
			{
				return TextBox.AcceptsReturn;
			}
			set
			{
				TextBox.AcceptsReturn = value;
			}
		}

		/// Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order.</summary>
		/// true if users can enter tabs in a multiline text box using the TAB key; false if pressing the TAB key moves the focus. The default is false.</returns>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("TextBoxAcceptsTabDescr")]
		public bool AcceptsTab
		{
			get
			{
				return TextBox.AcceptsTab;
			}
			set
			{
				TextBox.AcceptsTab = value;
			}
		}

		/// Gets or sets a custom string collection to use when the <see cref="P:System.Windows.Forms.ToolStripTextBox.AutoCompleteSource"></see> property is set to CustomSource.</summary>
		/// An <see cref="T:System.Windows.Forms.AutoCompleteStringCollection"></see> to use with <see cref="P:System.Windows.Forms.TextBox.AutoCompleteSource"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AutoCompleteStringCollection AutoCompleteCustomSource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// Gets or sets an option that controls how automatic completion works for the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
		/// One of the <see cref="T:System.Windows.Forms.AutoCompleteMode"></see> values. The default is <see cref="F:System.Windows.Forms.AutoCompleteMode.None"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AutoCompleteMode AutoCompleteMode
		{
			get
			{
				return AutoCompleteMode.None;
			}
			set
			{
			}
		}

		/// Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
		/// One of the <see cref="T:System.Windows.Forms.AutoCompleteSource"></see> values. The default is <see cref="F:System.Windows.Forms.AutoCompleteSource.None"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AutoCompleteSource AutoCompleteSource
		{
			get
			{
				return AutoCompleteSource.None;
			}
			set
			{
			}
		}

		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Drawing.Image"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ResourceHandle BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Windows.Forms.ImageLayout"></see> value.</returns>
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

		/// Gets or sets the border type of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control.</summary>
		/// One of the <see cref="T:System.Windows.Forms.BorderStyle"></see> values. The default is <see cref="F:System.Windows.Forms.BorderStyle.FixedSingle"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[DefaultValue(BorderStyle.Fixed3D)]
		[DispId(-504)]
		[SRDescription("TextBoxBorderDescr")]
		public BorderStyle BorderStyle
		{
			get
			{
				return TextBox.BorderStyle;
			}
			set
			{
				TextBox.BorderStyle = value;
			}
		}

		/// Gets a value indicating whether the user can undo the previous operation in a <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control.</summary>
		/// true if the user can undo the previous operation performed in a text box control; otherwise, false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("TextBoxCanUndoDescr")]
		public bool CanUndo => TextBox.CanUndo;

		/// Gets or sets whether the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control modifies the case of characters as they are typed.</summary>
		/// One of the <see cref="T:System.Windows.Forms.CharacterCasing"></see> values. The default is <see cref="F:System.Windows.Forms.CharacterCasing.Normal"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[DefaultValue(CharacterCasing.Normal)]
		[SRDescription("TextBoxCharacterCasingDescr")]
		public CharacterCasing CharacterCasing
		{
			get
			{
				return TextBox.CharacterCasing;
			}
			set
			{
				TextBox.CharacterCasing = value;
			}
		}

		/// Gets the default size of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see>.</summary> 
		/// The default <see cref="T:System.Drawing.Size"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> in pixels. The default size is 100 pixels by 25 pixels.</returns>
		protected new virtual Size DefaultSize => new Size(100, 22);

		/// Gets or sets a value indicating whether the selected text in the text box control remains highlighted when the control loses focus.</summary> 
		/// true if the selected text does not appear highlighted when the text box control loses focus; false, if the selected text remains highlighted when the text box control loses focus. The default is true.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("TextBoxHideSelectionDescr")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool HideSelection
		{
			get
			{
				return TextBox.HideSelection;
			}
			set
			{
				TextBox.HideSelection = value;
			}
		}

		/// Gets or sets the lines of text in a <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control.</summary>
		/// An array of strings that contains the text in a text box control.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[SRDescription("TextBoxLinesDescr")]
		public string[] Lines
		{
			get
			{
				return TextBox.Lines;
			}
			set
			{
				TextBox.Lines = value;
			}
		}

		/// Gets or sets the maximum number of characters the user can type or paste into the text box control.</summary>
		/// The number of characters that can be entered into the control. The default is 32767 characters.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		[DefaultValue(32767)]
		[SRCategory("CatBehavior")]
		[SRDescription("TextBoxMaxLengthDescr")]
		public int MaxLength
		{
			get
			{
				return TextBox.MaxLength;
			}
			set
			{
				TextBox.MaxLength = value;
			}
		}

		/// Gets or sets a value that indicates that the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control has been modified by the user since the control was created or its contents were last set.</summary>
		/// true if the control's contents have been modified; otherwise, false. </returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Modified
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[SRDescription("TextBoxMultilineDescr")]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Multiline
		{
			get
			{
				return TextBox.Multiline;
			}
			set
			{
				TextBox.Multiline = value;
			}
		}

		/// Gets or sets a value indicating whether text in the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> is read-only.</summary>
		/// true if the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> is read-only; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("TextBoxReadOnlyDescr")]
		public bool ReadOnly
		{
			get
			{
				return TextBox.ReadOnly;
			}
			set
			{
				TextBox.ReadOnly = value;
			}
		}

		/// Gets or sets a value indicating the currently selected text in the control.</summary>
		/// A string that represents the currently selected text in the text box.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRCategory("CatAppearance")]
		[SRDescription("TextBoxSelectedTextDescr")]
		public string SelectedText
		{
			get
			{
				return TextBox.SelectedText;
			}
			set
			{
				TextBox.SelectedText = value;
			}
		}

		/// Gets or sets the number of characters selected in the<see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
		/// The number of characters selected in the<see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("TextBoxSelectionLengthDescr")]
		public int SelectionLength
		{
			get
			{
				return TextBox.SelectionLength;
			}
			set
			{
				TextBox.SelectionLength = value;
			}
		}

		/// Gets or sets the starting point of text selected in the<see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
		/// The starting position of text selected in the<see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("TextBoxSelectionStartDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatAppearance")]
		public int SelectionStart
		{
			get
			{
				return TextBox.SelectionStart;
			}
			set
			{
				TextBox.SelectionStart = value;
			}
		}

		/// Gets or sets a value indicating whether the defined shortcuts are enabled.</summary>
		/// true to enable the shortcuts; otherwise, false.</returns>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShortcutsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets the hosted <see cref="T:System.Windows.Forms.TextBox"></see> control.</summary>
		/// The hosted <see cref="T:System.Windows.Forms.TextBox"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TextBox TextBox => base.Control as TextBox;

		/// Gets or sets how text is aligned in a <see cref="T:System.Windows.Forms.TextBox"></see> control.</summary>
		/// One of the <see cref="T:System.Windows.Forms.HorizontalAlignment"></see> enumeration values that specifies how text is aligned in the control. The default is <see cref="F:System.Windows.Forms.HorizontalAlignment.Left"></see>.</returns>
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[DefaultValue(HorizontalAlignment.Left)]
		[SRDescription("TextBoxTextAlignDescr")]
		public HorizontalAlignment TextBoxTextAlign
		{
			get
			{
				return TextBox.TextAlign;
			}
			set
			{
				TextBox.TextAlign = value;
			}
		}

		/// Gets the length of text in the control.</summary>
		/// The number of characters contained in the text of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		public int TextLength => TextBox.TextLength;

		/// This property is not relevant to this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		[SRDescription("TextBoxWordWrapDescr")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool WordWrap
		{
			get
			{
				return TextBox.WordWrap;
			}
			set
			{
				TextBox.WordWrap = value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.AcceptsTab"></see> property changes.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler AcceptsTabChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.BorderStyle"></see> property changes.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler BorderStyleChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.HideSelection"></see> property changes.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler HideSelectionChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.Modified"></see> property changes.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler ModifiedChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// This event is not relevant to this class.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler MultilineChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.ReadOnly"></see> property changes.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler ReadOnlyChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripTextBox.TextBoxTextAlign"></see> property changes.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TextBoxTextAlignChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> class.</summary>
		public ToolStripTextBox()
			: base(new TextBox())
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> class with the specified name. </summary> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see>.</param>
		public ToolStripTextBox(string name)
			: this()
		{
			base.Name = name;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> class derived from a base control.</summary> 
		/// <param name="c">The control from which to derive the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see>. </param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ToolStripTextBox(Control c)
			: base(c)
		{
			throw new NotSupportedException(SR.GetString("ToolStripMustSupplyItsOwnTextBox"));
		}

		/// Appends text to the current text of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
		/// <param name="text">The text to append to the current contents of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void AppendText(string text)
		{
			TextBox.AppendText(text);
		}

		/// Clears all text from the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> control.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Clear()
		{
			TextBox.Clear();
		}

		/// Clears information about the most recent operation from the undo buffer of the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see>.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void ClearUndo()
		{
		}

		/// Copies the current selection in the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> to the Clipboard.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Copy()
		{
			TextBox.Copy();
		}

		/// Moves the current selection in the <see cref="T:System.Windows.Forms.ToolStripTextBox"></see> to the Clipboard.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Cut()
		{
			TextBox.Copy();
		}

		/// Specifies that the value of the <see cref="P:System.Windows.Forms.ToolStripTextBox.SelectionLength"></see> property is zero so that no characters are selected in the control.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DeselectAll()
		{
		}

		/// Retrieves the character that is closest to the specified location within the control.</summary>
		/// The character at the specified location.</returns>
		/// <param name="pt">The location from which to seek the nearest character.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public char GetCharFromPosition(Point pt)
		{
			return '\0';
		}

		/// Retrieves the index of the character nearest to the specified location.</summary>
		/// The zero-based character index at the specified location.</returns>
		/// <param name="pt">The location to search.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int GetCharIndexFromPosition(Point pt)
		{
			return 0;
		}

		/// Retrieves the index of the first character of a given line.</summary>
		/// The zero-based character index in the specified line.</returns>
		/// <param name="lineNumber">The line for which to get the index of its first character.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int GetFirstCharIndexFromLine(int lineNumber)
		{
			return 0;
		}

		/// Retrieves the index of the first character of the current line.</summary>
		/// The zero-based character index in the current line.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int GetFirstCharIndexOfCurrentLine()
		{
			return 0;
		}

		/// Retrieves the line number from the specified character position within the text of the control.</summary>
		/// The zero-based line number in which the character index is located.</returns>
		/// <param name="index">The character index position to search.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int GetLineFromCharIndex(int index)
		{
			return 0;
		}

		/// Retrieves the location within the control at the specified character index.</summary>
		/// The location of the specified character.</returns>
		/// <param name="index">The index of the character for which to retrieve the location.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point GetPositionFromCharIndex(int index)
		{
			return Point.Empty;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.AcceptsTabChanged"></see> event. </summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnAcceptsTabChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.BorderStyleChanged"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnBorderStyleChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.HideSelectionChanged"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnHideSelectionChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.ModifiedChanged"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnModifiedChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.MultilineChanged"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnMultilineChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripTextBox.ReadOnlyChanged"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnReadOnlyChanged(EventArgs e)
		{
		}

		/// Replaces the current selection in the text box with the contents of the Clipboard.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Paste()
		{
			TextBox.Paste();
		}

		/// Scrolls the contents of the control to the current caret position.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void ScrollToCaret()
		{
			TextBox.ScrollToCaret();
		}

		/// Selects a range of text in the text box.</summary>
		/// <param name="start">The position of the first character in the current text selection within the text box.</param>
		/// <param name="length">The number of characters to select.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Select(int start, int length)
		{
			TextBox.Select(start, length);
		}

		/// Selects all text in the text box.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SelectAll()
		{
			TextBox.SelectAll();
		}

		/// Undoes the last edit operation in the text box.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Undo()
		{
			TextBox.Undo();
		}
	}
}
