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
	/// Represents a <see cref="T:System.Windows.Forms.ToolStripComboBox"></see> that is properly rendered in a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
	[Serializable]
	[DefaultProperty("Items")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolStripItemDesignerAvailability((ToolStripItemDesignerAvailability)7)]
	public class ToolStripComboBox : ToolStripControlHost
	{
		/// 
		///
		/// </summary>
		[Serializable]
		[ToolboxItem(false)]
		private class ToolStripComboBoxControl : ComboBox
		{
			/// 
			/// Gets the default size.
			/// </summary>
			/// The default size.</value>
			protected override Size DefaultSize => new Size(100, 22);
		}

		private static readonly SerializableEvent SelectedIndexChangedEvent;

		/// 
		/// The drop down event
		/// </summary>
		private static readonly SerializableEvent DropDownEvent;

		/// 
		/// The drop down closed event
		/// </summary>
		private static readonly SerializableEvent DropDownClosedEvent;

		/// 
		/// Gets the drop down handler.
		/// </summary>
		/// 
		/// The drop down handler.
		/// </value>
		private EventHandler DropDownHandler => (EventHandler)GetHandler(DropDown);

		/// 
		/// Gets the drop down closed handler.
		/// </summary>
		/// 
		/// The drop down closed handler.
		/// </value>
		private EventHandler DropDownClosedHandler => (EventHandler)GetHandler(DropDownClosed);

		/// 
		/// Gets the SelectedIndexChanged handler.
		/// </summary>
		/// The SelectedIndexChanged handler.</value>
		private EventHandler SelectedIndexChangedHandler => (EventHandler)GetHandler(SelectedIndexChanged);

		/// Gets or sets the custom string collection to use when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.AutoCompleteSource"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteSource.CustomSource"></see>.</summary> 
		/// An <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteStringCollection"></see> that contains the strings.</returns> 
		/// 1</filterpriority>
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

		/// Gets or sets a value that indicates the text completion behavior of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteMode.None"></see>.</returns> 
		/// 1</filterpriority>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(AutoCompleteMode.None)]
		[SRDescription("ComboBoxAutoCompleteModeDescr")]
		public AutoCompleteMode AutoCompleteMode
		{
			get
			{
				return ComboBox.AutoCompleteMode;
			}
			set
			{
				ComboBox.AutoCompleteMode = value;
			}
		}

		/// Gets or sets the source of complete strings used for automatic completion.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteSource"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteSource.None"></see>.</returns> 
		/// 1</filterpriority>
		[SRDescription("ComboBoxAutoCompleteSourceDescr")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DefaultValue(AutoCompleteSource.None)]
		public AutoCompleteSource AutoCompleteSource
		{
			get
			{
				return ComboBox.AutoCompleteSource;
			}
			set
			{
				ComboBox.AutoCompleteSource = value;
			}
		}

		/// This property is not relevant to this class.</summary> 
		/// An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
		/// An <see cref="T:System.Windows.Forms.ImageLayout"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		/// Gets a <see cref="T:System.Windows.Forms.ComboBox"></see> in which the user can enter text, along with a list from which the user can select.</summary>
		/// A <see cref="T:System.Windows.Forms.ComboBox"></see> for a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ComboBox ComboBox => base.Control as ComboBox;

		/// Gets the default size of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// The default <see cref="T:System.Drawing.Size"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> in pixels. The default size is 100 x 20 pixels.</returns>
		protected new virtual Size DefaultSize => new Size(100, 22);

		/// Gets or sets the height, in pixels, of the drop-down portion box of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// The height, in pixels, of the drop-down box.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int DropDownHeight
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		/// Gets or sets a value specifying the style of the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
		/// One of the <see cref="T:System.Windows.Forms.ComboBoxStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ComboBoxStyle.DropDown"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ComboBoxStyleDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(ComboBoxStyle.DropDown)]
		[RefreshProperties(RefreshProperties.Repaint)]
		public ComboBoxStyle DropDownStyle
		{
			get
			{
				return ComboBox.DropDownStyle;
			}
			set
			{
				ComboBox.DropDownStyle = value;
			}
		}

		/// Gets or sets the width, in pixels, of the of the drop-down portion of a <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
		/// The width, in pixels, of the drop-down box.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ComboBoxDropDownWidthDescr")]
		[SRCategory("CatBehavior")]
		public int DropDownWidth
		{
			get
			{
				return ComboBox.DropDownWidth;
			}
			set
			{
				ComboBox.DropDownWidth = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [dropped down].
		/// </summary>
		/// 
		///   true</c> if [dropped down]; otherwise, false</c>.
		/// </value>
		public bool DroppedDown
		{
			get
			{
				return ComboBox.DroppedDown;
			}
			set
			{
				ComboBox.DroppedDown = value;
			}
		}

		/// Gets or sets the appearance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// One of the values of <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see>. The options are <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Flat"></see>, <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Popup"></see>, <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>, and <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.System"></see>. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Popup"></see>.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public FlatStyle FlatStyle
		{
			get
			{
				return FlatStyle.Flat;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> should resize to avoid showing partial items.</summary> 
		/// true if the list portion can contain only complete items; otherwise, false. The default is true.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IntegralHeight
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets a collection of the items contained in this <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// A collection of items.</returns> 
		/// 1</filterpriority>
		[Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Localizable(true)]
		[SRDescription("ComboBoxItemsDescr")]
		[SRCategory("CatData")]
		public ComboBox.ObjectCollection Items => ComboBox.Items;

		/// 
		/// Gets or sets the max drop down items.
		/// </summary>
		/// The max drop down items.</value>
		[DefaultValue(8)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[SRDescription("ComboBoxMaxDropDownItemsDescr")]
		public int MaxDropDownItems
		{
			get
			{
				return ComboBox.MaxDropDownItems;
			}
			set
			{
				ComboBox.MaxDropDownItems = value;
			}
		}

		/// Gets or sets the maximum number of characters allowed in the editable portion of a combo box.</summary> 
		/// The maximum number of characters the user can enter. Values of less than zero are reset to zero, which is the default value.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int MaxLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		/// Gets or sets the index specifying the currently selected item.</summary> 
		/// A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ComboBoxSelectedIndexDescr")]
		public int SelectedIndex
		{
			get
			{
				return ComboBox.SelectedIndex;
			}
			set
			{
				ComboBox.SelectedIndex = value;
			}
		}

		/// Gets or sets currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// The object that is the currently selected item or null if there is no currently selected item.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Browsable(false)]
		[Bindable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ComboBoxSelectedItemDescr")]
		public object SelectedItem
		{
			get
			{
				return ComboBox.SelectedItem;
			}
			set
			{
				ComboBox.SelectedItem = value;
			}
		}

		/// Gets or sets the text that is selected in the editable portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// A string that represents the currently selected text in the combo box. If <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyle"></see> is set to DropDownList, the return value is an empty string ("").</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ComboBoxSelectedTextDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string SelectedText
		{
			get
			{
				return ComboBox.SelectedText;
			}
			set
			{
				ComboBox.SelectedText = value;
			}
		}

		/// Gets or sets the number of characters selected in the editable portion of the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
		/// The number of characters selected in the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRDescription("ComboBoxSelectionLengthDescr")]
		public int SelectionLength
		{
			get
			{
				return ComboBox.SelectionLength;
			}
			set
			{
				ComboBox.SelectionLength = value;
			}
		}

		/// Gets or sets the starting index of text selected in the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
		/// The zero-based index of the first character in the string of the current text selection.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ComboBoxSelectionStartDescr")]
		public int SelectionStart
		{
			get
			{
				return ComboBox.SelectionStart;
			}
			set
			{
				ComboBox.SelectionStart = value;
			}
		}

		/// Gets or sets a value indicating whether the items in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> are sorted.</summary> 
		/// true if the combo box is sorted; otherwise, false. The default is false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("ComboBoxSortedDescr")]
		public bool Sorted
		{
			get
			{
				return ComboBox.Sorted;
			}
			set
			{
				ComboBox.Sorted = value;
			}
		}

		/// This event is not relevant to this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler DoubleClick
		{
			add
			{
				base.DoubleClick += value;
			}
			remove
			{
				base.DoubleClick -= value;
			}
		}

		/// Occurs when the drop-down portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> is shown.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler DropDown
		{
			add
			{
				AddCriticalHandler(DropDownEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DropDownEvent, value);
			}
		}

		/// Occurs when the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> has closed.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler DropDownClosed
		{
			add
			{
				AddCriticalHandler(DropDownClosedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DropDownClosedEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyle"></see> property has changed.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler DropDownStyleChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.SelectedIndex"></see> property has changed.</summary> 
		/// 1</filterpriority>
		public event EventHandler SelectedIndexChanged
		{
			add
			{
				if (!HasHandler(SelectedIndexChangedEvent) && base.Control is ComboBox comboBox)
				{
					comboBox.SelectedIndexChanged += HandleSelectedIndexChanged;
				}
				AddCriticalHandler(SelectedIndexChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SelectedIndexChangedEvent, value);
				if (!HasHandler(SelectedIndexChangedEvent) && base.Control is ComboBox comboBox)
				{
					comboBox.SelectedIndexChanged -= HandleSelectedIndexChanged;
				}
			}
		}

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> text has changed.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TextUpdate
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class.</summary>
		public ToolStripComboBox()
			: base(new ToolStripComboBoxControl())
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class with the specified name. </summary> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</param>
		public ToolStripComboBox(string name)
			: this()
		{
			base.Name = name;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class derived from a base control.</summary> 
		/// <param name="c">The base control. </param> 
		/// <exception cref="T:System.NotSupportedException">The operation is not supported. </exception>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ToolStripComboBox(Control objControl)
			: base(objControl)
		{
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public override void Update()
		{
			base.Update();
			ComboBox.Update();
		}

		/// 
		/// Handles the selected index changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void HandleSelectedIndexChanged(object sender, EventArgs e)
		{
			OnSelectedIndexChanged(e);
		}

		/// Maintains performance when items are added to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> one at a time.</summary> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void BeginUpdate()
		{
		}

		/// Resumes painting the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> control after painting is suspended by the <see cref="M:Gizmox.WebGUI.Forms.ToolStripComboBox.BeginUpdate"></see> method.</summary> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void EndUpdate()
		{
		}

		/// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> that starts with the specified string.</summary> 
		/// The zero-based index of the first item found; returns -1 if no match is found.</returns> 
		/// <param name="s">The <see cref="T:System.String"></see> to search for.</param> 
		/// 1</filterpriority>
		public int FindString(string s)
		{
			return ComboBox.FindString(s);
		}

		/// Finds the first item after the given index which starts with the given string. </summary> 
		/// The zero-based index of the first item found; returns -1 if no match is found.</returns> 
		/// <param name="s">The <see cref="T:System.String"></see> to search for.</param> 
		/// <param name="startIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control.</param> 
		/// 1</filterpriority>
		public int FindString(string s, int startIndex)
		{
			return ComboBox.FindString(s, startIndex);
		}

		/// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> that exactly matches the specified string.</summary> 
		/// The zero-based index of the first item found; -1 if no match is found.</returns> 
		/// <param name="s">The <see cref="T:System.String"></see> to search for.</param> 
		/// 1</filterpriority>
		public int FindStringExact(string s)
		{
			return ComboBox.FindStringExact(s);
		}

		/// Finds the first item after the specified index that exactly matches the specified string.</summary> 
		/// The zero-based index of the first item found; returns -1 if no match is found.</returns> 
		/// <param name="s">The <see cref="T:System.String"></see> to search for.</param> 
		/// <param name="startIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control.</param> 
		/// 1</filterpriority>
		public int FindStringExact(string s, int startIndex)
		{
			return ComboBox.FindStringExact(s, startIndex);
		}

		/// Returns the height, in pixels, of an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// The height, in pixels, of the item at the specified index.</returns> 
		/// <param name="index">The index of the item to return the height of.</param> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int GetItemHeight(int index)
		{
			return 0;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDown"></see> event. </summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnDropDown(EventArgs objEventArgs)
		{
			DropDownHandler?.Invoke(this, objEventArgs);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownClosed"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnDropDownClosed(EventArgs objEventArgs)
		{
			DropDownClosedHandler?.Invoke(this, objEventArgs);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyleChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnDropDownStyleChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.SelectedIndexChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnSelectedIndexChanged(EventArgs e)
		{
			SelectedIndexChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ComboBox.SelectionChangeCommitted"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnSelectionChangeCommitted(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.TextUpdate"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnTextUpdate(EventArgs e)
		{
		}

		/// Selects a range of text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// <param name="start">The position of the first character in the current text selection within the text box.</param> 
		/// <param name="length">The number of characters to select.</param> 
		/// <exception cref="T:System.ArgumentException">The start is less than zero.-or- start minus length is less than zero. </exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void Select(int start, int length)
		{
			ComboBox.Select(start, length);
		}

		/// Selects all the text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void SelectAll()
		{
			ComboBox.SelectAll();
		}

		/// 
		/// Handles the drop down.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void HandleDropDown(object sender, EventArgs e)
		{
			OnDropDown(e);
		}

		/// 
		/// Handles the drop down closed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void HandleDropDownClosed(object sender, EventArgs e)
		{
			OnDropDownClosed(e);
		}

		/// Subscribes events from the hosted control.</summary> 
		/// <param name="objControl">The control from which to subscribe events.</param>
		protected override void OnSubscribeControlEvents(Control objControl)
		{
			if (objControl is ComboBox comboBox)
			{
				comboBox.DropDown += HandleDropDown;
				comboBox.DropDownClosed += HandleDropDownClosed;
			}
			base.OnSubscribeControlEvents(objControl);
		}

		/// Unsubscribes events from the hosted control.</summary> 
		/// <param name="objControl">The control from which to unsubscribe events.</param>
		protected override void OnUnsubscribeControlEvents(Control objControl)
		{
			if (objControl is ComboBox comboBox)
			{
				comboBox.DropDown -= HandleDropDown;
				comboBox.DropDownClosed -= HandleDropDownClosed;
			}
			base.OnUnsubscribeControlEvents(objControl);
		}

		/// 
		/// Resets the width of the drop down.
		/// </summary>
		private void ResetDropDownWidth()
		{
			ComboBox.ResetDropDownWidth();
		}

		static ToolStripComboBox()
		{
			SelectedIndexChanged = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(ToolStripComboBox));
			DropDown = SerializableEvent.Register("DropDown", typeof(EventHandler), typeof(ToolStripComboBox));
			DropDownClosed = SerializableEvent.Register("DropDownClosed", typeof(EventHandler), typeof(ToolStripComboBox));
		}
	}
}
