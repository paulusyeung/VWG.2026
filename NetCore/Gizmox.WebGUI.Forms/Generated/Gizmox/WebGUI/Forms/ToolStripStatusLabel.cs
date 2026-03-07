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
	/// Represents a panel in a <see cref="T:System.Windows.Forms.StatusStrip"></see> control. </summary>
	[Serializable]
	[Skin(typeof(ToolStripStatusLabelSkin))]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
	public class ToolStripStatusLabel : ToolStripLabel
	{
		private static readonly SerializableProperty menmBorderSidesProperty = SerializableProperty.Register("menmBorderSides", typeof(ToolStripStatusLabelBorderSides), typeof(ToolStripStatusLabel));

		private static readonly SerializableProperty mblnSpringProperty = SerializableProperty.Register("mblnSpring", typeof(bool), typeof(ToolStripStatusLabel));

		private ToolStripStatusLabelBorderSides menmBorderSides
		{
			get
			{
				return GetValue(menmBorderSidesProperty);
			}
			set
			{
				SetValue(menmBorderSidesProperty, value);
			}
		}

		private bool mblnSpring
		{
			get
			{
				return GetValue(mblnSpringProperty);
			}
			set
			{
				SetValue(mblnSpringProperty, value);
			}
		}

		/// Gets or sets a value that determines where the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> is aligned on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public new ToolStripItemAlignment Alignment
		{
			get
			{
				return base.Alignment;
			}
			set
			{
				base.Alignment = value;
			}
		}

		/// Gets or sets a value that indicates which sides of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> show borders.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabelBorderSides"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripStatusLabelBorderSides.None"></see>.</returns>
		[DefaultValue(ToolStripStatusLabelBorderSides.None)]
		[SRDescription("ToolStripStatusLabelBorderSidesDescr")]
		[SRCategory("CatAppearance")]
		public ToolStripStatusLabelBorderSides BorderSides
		{
			get
			{
				return menmBorderSides;
			}
			set
			{
				if (menmBorderSides != value)
				{
					menmBorderSides = value;
					Invalidate();
				}
			}
		}

		/// Gets or sets the border style of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.Border3DStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Border3DStyle.Flat"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value of <see cref="P:Gizmox.WebGUI.Forms.ToolStripStatusLabel.BorderStyle"></see> is not one of the <see cref="T:Gizmox.WebGUI.Forms.Border3DStyle"></see> values.</exception>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Border3DStyle BorderStyle
		{
			get
			{
				return Border3DStyle.Flat;
			}
			set
			{
			}
		}

		/// 
		/// Gets the type of the tool strip item.
		/// </summary>
		/// The type of the tool strip item.</value>
		protected override int ToolStripItemType => 6;

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> automatically fills the available space on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> as the form is resized. </summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> automatically fills the available space on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> as the form is resized; otherwise, false. The default is false.</returns>
		[DefaultValue(false)]
		[SRDescription("ToolStripStatusLabelSpringDescr")]
		[SRCategory("CatAppearance")]
		public bool Spring
		{
			get
			{
				return mblnSpring;
			}
			set
			{
				if (mblnSpring != value)
				{
					mblnSpring = value;
				}
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class. </summary>
		public ToolStripStatusLabel()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified text.</summary> 
		/// <param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
		public ToolStripStatusLabel(string text)
			: base(text, null, isLink: false, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image. </summary> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
		public ToolStripStatusLabel(ResourceHandle image)
			: base(null, image, isLink: false, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image and text.</summary> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param> 
		/// <param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
		public ToolStripStatusLabel(string text, ResourceHandle image)
			: base(text, image, isLink: false, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image and text, and that carries out the specified action when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary> 
		/// <param name="onClick">Specifies the action to carry out when the control is clicked.</param> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param> 
		/// <param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
		public ToolStripStatusLabel(string text, ResourceHandle image, EventHandler onClick)
			: base(text, image, isLink: false, onClick, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class with the specified name that displays the specified image and text, and that carries out the specified action when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary> 
		/// <param name="onClick">Specifies the action to carry out when the control is clicked.</param> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param> 
		/// <param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
		public ToolStripStatusLabel(string text, ResourceHandle image, EventHandler onClick, string name)
			: base(text, image, isLink: false, onClick, null)
		{
		}
	}
}
