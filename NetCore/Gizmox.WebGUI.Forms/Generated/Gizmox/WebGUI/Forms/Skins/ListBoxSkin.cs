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

namespace Gizmox.WebGUI.Forms.Skins
{
	/// 
	/// ListBox Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(ListBox), "ListBox.bmp")]
	public class ListBoxSkin : ControlSkin
	{
		/// 
		/// Gets the height of the selection icon image.
		/// </summary>
		/// The height of the selection icon image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int SelectionIconHeight => GetMaxImageHeight(DefaultSelectionIconHeight, "CheckBox0.gif", "CheckBox1.gif", "Radio0.gif", "Radio1.gif");

		/// 
		/// Gets the default height of the selection icon.
		/// </summary>
		/// The default height of the selection icon.</value>
		protected virtual int DefaultSelectionIconHeight => 13;

		/// 
		/// Gets the width of the selection icon image.
		/// </summary>
		/// The width of the selection icon image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int SelectionIconWidth => GetMaxImageWidth(DefaultSelectionIconWidth, "CheckBox0.gif", "CheckBox1.gif", "Radio0.gif", "Radio1.gif");

		/// 
		/// Gets the default width of the selection icon.
		/// </summary>
		/// The default width of the selection icon.</value>
		protected virtual int DefaultSelectionIconWidth => 13;

		/// 
		/// Gets or sets the width of the check box cell.
		/// </summary>
		/// The width of the check box cell.</value>
		[SRCategory("Sizes")]
		[SRDescription("The check box cell width.")]
		public virtual int CheckBoxCellWidth
		{
			get
			{
				return GetValue("CheckBoxCellWidth", DefaultCheckBoxCellWidth);
			}
			set
			{
				SetValue("CheckBoxCellWidth", value);
			}
		}

		/// 
		/// Gets the default width of the check box cell.
		/// </summary>
		/// The default width of the check box cell.</value>
		protected virtual int DefaultCheckBoxCellWidth => 20;

		/// 
		/// Gets or sets the width of the list box color cell.
		/// </summary>
		/// The width of the list box color cell.</value>
		[SRCategory("Sizes")]
		[SRDescription("The ListBox color cell width.")]
		public virtual int ListBoxColorCellWidth
		{
			get
			{
				return GetValue("ListBoxColorCellWidth", DefaultListBoxColorCellWidth);
			}
			set
			{
				SetValue("ListBoxColorCellWidth", value);
			}
		}

		/// 
		/// Gets the default width of the color list box color cell.
		/// </summary>
		/// The default width of the color list box color cell.</value>
		protected virtual int DefaultListBoxColorCellWidth => 30;

		/// 
		/// Gets or sets the Height of the list box image cell.
		/// </summary>
		/// The Height of the list box image cell.</value>
		[SRCategory("Sizes")]
		[SRDescription("The ListBox Image Cell Height.")]
		public virtual int ListBoxColorBoxHeight
		{
			get
			{
				return GetValue("ListBoxColorBoxHeight", DefaultListBoxColorBoxHeight);
			}
			set
			{
				SetValue("ListBoxColorBoxHeight", value);
			}
		}

		/// 
		/// Gets the default height of the selection icon.
		/// </summary>
		/// The default height of the selection icon.</value>
		protected virtual int DefaultListBoxColorBoxHeight => 14;

		/// 
		/// Gets or sets the width of the list box image cell.
		/// </summary>
		/// The width of the list box image cell.</value>
		[SRCategory("Sizes")]
		[SRDescription("The ListBox Image Cell Width.")]
		public virtual int ListBoxImageCellWidth
		{
			get
			{
				return GetValue("ListBoxImageCellWidth", DefaultListBoxImageCellWidth);
			}
			set
			{
				SetValue("ListBoxImageCellWidth", value);
			}
		}

		/// 
		/// Gets the default width of the color list box color cell.
		/// </summary>
		/// The default width of the color list box color cell.</value>
		protected virtual int DefaultListBoxImageCellWidth => 16;

		/// 
		/// Gets or sets the height of the list box image cell.
		/// </summary>
		/// The height of the list box image cell.</value>
		[SRCategory("Sizes")]
		[SRDescription("The ListBox Image Cell Height.")]
		public virtual int ListBoxImageCellHeight
		{
			get
			{
				return GetValue("ListBoxImageCellHeight", DefaultListBoxImageCellHeight);
			}
			set
			{
				SetValue("ListBoxImageCellHeight", value);
			}
		}

		/// 
		/// Gets the default height of the list box image cell.
		/// </summary>
		/// The default height of the list box image cell.</value>
		protected virtual int DefaultListBoxImageCellHeight => 16;

		/// 
		/// Gets the width of the preferd image box.
		/// </summary>
		/// The width of the preferd image box.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PreferdImageBoxWidth => ListBoxImageCellWidth + CellStyle.Padding.Horizontal;

		/// 
		/// Gets the width of the preferd color box.
		/// </summary>
		/// The width of the preferd color box.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PreferdColorBoxWidth => ListBoxColorCellWidth + CellStyle.Padding.Horizontal;

		/// 
		/// Gets the focused list box selected row style.
		/// </summary>
		/// The focused list box selected row style.</value>
		[Category("States")]
		[SRDescription("The focused listbox selected row style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue FocusedListBoxSelectedRowStyle => new StyleValue(this, "FocusedListBoxSelectedRowStyle");

		/// 
		/// Gets the selected cell style.
		/// </summary>
		/// The selected cell style.</value>
		[Category("States")]
		[SRDescription("The selected cell style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SelectedCellStyle => new StyleValue(this, "SelectedCellStyle");

		/// 
		/// Gets the color list box color box style.
		/// </summary>
		/// The color list box color box style.</value>
		[Category("States")]
		[SRDescription("The color listbox color box style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ColorBoxStyle => new StyleValue(this, "ColorBoxStyle");

		/// 
		/// Gets the cell style.
		/// </summary>
		/// The cell style.</value>
		public virtual StyleValue CellStyle => new StyleValue(this, "CellStyle");

		/// 
		/// Gets or sets the checked radio button image.
		/// </summary>
		/// The checked radio button image.</value>
		[SRDescription("The CheckedRadioButtonImage.")]
		[SRCategory("Images")]
		public ImageResourceReference CheckedRadioButtonImage
		{
			get
			{
				return GetValue("CheckedRadioButtonImage", new ImageResourceReference(typeof(ListBoxSkin), "Radio1.gif"));
			}
			set
			{
				SetValue("CheckedRadioButtonImage", value);
			}
		}

		/// 
		/// Gets or sets the unchecked radio button image.
		/// </summary>
		/// The unchecked radio button image.</value>
		[SRDescription("The UncheckedRadioButtonImage.")]
		[SRCategory("Images")]
		public ImageResourceReference UncheckedRadioButtonImage
		{
			get
			{
				return GetValue("UncheckedRadioButtonImage", new ImageResourceReference(typeof(ListBoxSkin), "Radio0.gif"));
			}
			set
			{
				SetValue("UncheckedRadioButtonImage", value);
			}
		}

		/// 
		/// Gets or sets the checked check box image.
		/// </summary>
		/// The checked check box image.</value>
		[SRDescription("The CheckedCheckBoxImage.")]
		[SRCategory("Images")]
		public ImageResourceReference CheckedCheckBoxImage
		{
			get
			{
				return GetValue("CheckedCheckBoxImage", new ImageResourceReference(typeof(ListBoxSkin), "CheckBox1.gif"));
			}
			set
			{
				SetValue("CheckedCheckBoxImage", value);
			}
		}

		/// 
		/// Gets or sets the unchecked check box image.
		/// </summary>
		/// The unchecked check box image.</value>
		[SRDescription("The UncheckedCheckBoxImage.")]
		[SRCategory("Images")]
		public ImageResourceReference UncheckedCheckBoxImage
		{
			get
			{
				return GetValue("UncheckedCheckBoxImage", new ImageResourceReference(typeof(ListBoxSkin), "CheckBox0.gif"));
			}
			set
			{
				SetValue("UncheckedCheckBoxImage", value);
			}
		}

		/// 
		/// Gets or sets the indeterminate check box image.
		/// </summary>
		/// The indeterminate check box image.</value>
		[SRDescription("The Indeterminate checkbox image.")]
		[SRCategory("Images")]
		public ImageResourceReference IndeterminateCheckBoxImage
		{
			get
			{
				return GetValue("IndeterminateCheckBoxImage", new ImageResourceReference(typeof(ListBoxSkin), "CheckBox2.gif"));
			}
			set
			{
				SetValue("IndeterminateCheckBoxImage", value);
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the height of the selection icon.
		/// </summary>
		private void ResetSelectionIconHeight()
		{
			Reset("SelectionIconHeight");
		}

		/// 
		/// Resets the width of the selection icon.
		/// </summary>
		private void ResetSelectionIconWidth()
		{
			Reset("SelectionIconWidth");
		}

		/// 
		/// Resets the width of the check box cell.
		/// </summary>
		internal void ResetCheckBoxCellWidth()
		{
			Reset("CheckBoxCellWidth");
		}

		/// 
		/// Resets the width of the color list box color cell.
		/// </summary>
		internal void ResetListBoxColorCellWidth()
		{
			Reset("ListBoxColorCellWidth");
		}

		/// 
		/// Resets the height of the selection icon.
		/// </summary>
		private void ResetListBoxColorBoxHeight()
		{
			Reset("ListBoxColorBoxHeight");
		}

		/// 
		/// Resets the width of the list box image cell.
		/// </summary>
		internal void ResetListBoxImageCellWidth()
		{
			Reset("ListBoxImageCellWidth");
		}

		/// 
		/// Resets the height of the list box image cell.
		/// </summary>
		internal void ResetListBoxImageCellHeight()
		{
			Reset("ListBoxImageCellHeight");
		}

		internal void ResetCheckedRadioButtonImage()
		{
			Reset("CheckedRadioButtonImage");
		}

		internal void ResetUncheckedRadioButtonImage()
		{
			Reset("UncheckedRadioButtonImage");
		}

		internal void ResetCheckedCheckBoxImage()
		{
			Reset("CheckedCheckBoxImage");
		}

		internal void ResetUncheckedCheckBoxImage()
		{
			Reset("UncheckedCheckBoxImage");
		}

		internal void ResetIndeterminateCheckBoxImage()
		{
			Reset("IndeterminateCheckBoxImage");
		}
	}
}
