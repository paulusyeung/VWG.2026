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
	/// Represents a common dialog box that displays available colors along with controls that enable the user to define custom colors.
	/// </summary>
	[Serializable]
	[DefaultProperty("Color")]
	[SRDescription("DescriptionColorDialog")]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ColorDialog), "ColorDialog_45.bmp")]
	[Skin(typeof(ColorDialogSkin))]
	public class ColorDialog : CommonDialog
	{
		/// 
		///
		/// </summary>
		[Serializable]
		[Skin(typeof(ColorDialogSkin))]
		protected class ColorDialogForm : CommonDialogForm
		{
			private HtmlBoxHost mobjHtmlBoxHost;

			private Color mobjColor;

			private Button mobjDefineCustomColorsButton;

			private Button mobjCancelButton;

			private Button mobjOkButton;

			private Button mobjAddToCustomColors;

			/// 
			/// Gets the color dialog owner.
			/// </summary>
			/// The color dialog owner.</value>
			public ColorDialog ColorDialogOwner => (ColorDialog)base.CommonDialogOwner;

			/// 
			///
			/// </summary>
			/// <param name="objCommonDialog"></param>
			public ColorDialogForm(CommonDialog objCommonDialog)
				: base(objCommonDialog)
			{
				InitializeComponent();
				if (objCommonDialog is ColorDialog colorDialog)
				{
					mobjColor = colorDialog.Color;
				}
			}

			/// 
			/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
			/// </summary>
			/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad(e);
				mobjHtmlBoxHost.SetProperty("VLB", CommonUtils.GetRGBColor(ColorDialogOwner.Color));
				if (ColorDialogOwner == null)
				{
					return;
				}
				int[] customColors = ColorDialogOwner.CustomColors;
				if (customColors != null)
				{
					string text = string.Empty;
					string text2 = string.Empty;
					int[] array = customColors;
					foreach (int win32Color in array)
					{
						text = text + text2 + CommonUtils.GetWebColor(ColorTranslator.FromWin32(win32Color));
						text2 = ",";
					}
					if (!string.IsNullOrEmpty(text))
					{
						mobjHtmlBoxHost.SetProperty("CCS", text);
					}
				}
				if (ColorDialogOwner.FullOpen)
				{
					SetFullOpen(blnSendClientInvocation: false);
				}
			}

			/// 
			/// Raises the <see cref="E:Closed" /> event.
			/// </summary>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			protected override void OnClosed(EventArgs e)
			{
				base.OnClosed(e);
				ColorDialogOwner.FullOpen = false;
				mobjHtmlBoxHost.SetProperty("OpenFull", "0");
			}

			private void InitializeComponent()
			{
				mobjHtmlBoxHost = new HtmlBoxHost();
				mobjOkButton = new Button();
				mobjCancelButton = new Button();
				mobjDefineCustomColorsButton = new Button();
				mobjAddToCustomColors = new Button();
				SuspendLayout();
				mobjHtmlBoxHost.Dock = DockStyle.Fill;
				mobjHtmlBoxHost.Url = base.Skin.GetResourcePath("ColorDialog.htm");
				mobjHtmlBoxHost.EventRaised += HtmlBoxHost_EventRaised;
				mobjOkButton.Text = WGLabels.Ok;
				mobjOkButton.Location = new Point(10, 306);
				mobjOkButton.Click += btnOk_Click;
				mobjCancelButton.Text = WGLabels.Cancel;
				mobjCancelButton.Location = new Point(mobjOkButton.Left + mobjOkButton.Width + 10, mobjOkButton.Location.Y);
				mobjCancelButton.Click += btnCancel_Click;
				mobjDefineCustomColorsButton.Text = WGLabels.GetString("DefineCustomColors", Global.Context, blnApplyCultureInfoValues: true);
				mobjDefineCustomColorsButton.Width = 160;
				mobjDefineCustomColorsButton.Location = new Point(mobjOkButton.Left, mobjOkButton.Top - 10 - mobjDefineCustomColorsButton.Height);
				mobjDefineCustomColorsButton.Click += btnDefineCustomColors_Click;
				mobjDefineCustomColorsButton.Enabled = ColorDialogOwner.AllowFullOpen;
				mobjAddToCustomColors.Text = WGLabels.GetString("AddToCustomColors", Global.Context, blnApplyCultureInfoValues: true);
				mobjAddToCustomColors.Width = 135;
				mobjAddToCustomColors.Location = new Point(237, mobjOkButton.Top);
				mobjAddToCustomColors.Click += mobjDefineCustomColorsButton_Click;
				mobjAddToCustomColors.Visible = false;
				base.Controls.Add(mobjHtmlBoxHost);
				base.Controls.Add(mobjOkButton);
				base.Controls.Add(mobjCancelButton);
				base.Controls.Add(mobjDefineCustomColorsButton);
				base.Controls.Add(mobjAddToCustomColors);
				base.FormBorderStyle = FormBorderStyle.FixedDialog;
				base.MaximizeBox = false;
				base.MinimizeBox = false;
				base.Size = new Size(218, 336);
				ResumeLayout(blnPerformLayout: false);
			}

			/// 
			/// Handles the Click event of the mobjDefineCustomColorsButton control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mobjDefineCustomColorsButton_Click(object sender, EventArgs e)
			{
				mobjHtmlBoxHost.InvokeExecuter("AddColorToCustomColors");
			}

			/// 
			/// Handles the Click event of the btnDefineCustomColors control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void btnDefineCustomColors_Click(object sender, EventArgs e)
			{
				ColorDialogOwner.FullOpen = true;
				mobjHtmlBoxHost.SetProperty("OpenFull", "1");
				SetFullOpen(blnSendClientInvocation: true);
			}

			/// 
			/// Sets the full open mode.
			/// </summary>
			private void SetFullOpen(bool blnSendClientInvocation)
			{
				base.Width = 463;
				mobjDefineCustomColorsButton.Enabled = false;
				mobjAddToCustomColors.Visible = true;
				if (blnSendClientInvocation)
				{
					mobjHtmlBoxHost.InvokeExecuter("EditCustomColors");
				}
			}

			private void btnCancel_Click(object sender, EventArgs e)
			{
				base.DialogResult = DialogResult.Cancel;
				Close();
			}

			private void btnOk_Click(object sender, EventArgs e)
			{
				base.DialogResult = DialogResult.OK;
				ColorDialogOwner.Color = mobjColor;
				Close();
			}

			private void HtmlBoxHost_EventRaised(IEvent objEvent)
			{
				string type = objEvent.Type;
				if (!(type == "ValueChange"))
				{
					return;
				}
				string text = objEvent["CO"];
				if (!CommonUtils.IsNullOrEmpty(text))
				{
					mobjColor = ColorTranslator.FromHtml("#" + text);
				}
				string text2 = objEvent["CCS"];
				if (CommonUtils.IsNullOrEmpty(text2) || ColorDialogOwner == null)
				{
					return;
				}
				string[] array = text2.Split(',');
				int[] array2 = new int[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					string text3 = array[i];
					if (!text3.StartsWith("#"))
					{
						text3 = $"#{text3}";
					}
					array2[i] = ColorTranslator.ToWin32(ColorTranslator.FromHtml(text3));
				}
				ColorDialogOwner.CustomColors = array2;
			}
		}

		/// 
		/// The selected color
		/// </summary>
		private Color mobjColor;

		/// 
		/// The user custom colors
		/// </summary>
		private int[] marrCustomColors = new int[16];

		/// 
		/// The dialog bitmap options
		/// </summary>
		private int mintOptions;

		/// Gets values to initialize the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</summary>
		/// A bitwise combination of internal values that initializes the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</returns>
		protected virtual int Options => mintOptions;

		/// Gets or sets a value indicating whether the user can use the dialog box to define custom colors.</summary>
		/// true if the user can define custom colors; otherwise, false. The default is true.</returns>
		/// 2</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("CDallowFullOpenDescr")]
		[DefaultValue(true)]
		public virtual bool AllowFullOpen
		{
			get
			{
				return !GetOption(4);
			}
			set
			{
				SetOption(4, !value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box displays all available colors in the set of basic colors.</summary>
		/// true if the dialog box displays all available colors in the set of basic colors; otherwise, false. The default value is false.</returns>
		[DefaultValue(false)]
		[SRDescription("CDanyColorDescr")]
		[SRCategory("CatBehavior")]
		public virtual bool AnyColor
		{
			get
			{
				return GetOption(256);
			}
			set
			{
				SetOption(256, value);
			}
		}

		/// Gets or sets the color selected by the user.</summary>
		/// The color selected by the user. If a color is not selected, the default value is black.</returns>
		[SRCategory("CatData")]
		[SRDescription("CDcolorDescr")]
		public Color Color
		{
			get
			{
				return mobjColor;
			}
			set
			{
				if (!value.IsEmpty)
				{
					mobjColor = value;
				}
				else
				{
					mobjColor = Color.Black;
				}
			}
		}

		/// Gets or sets the set of custom colors shown in the dialog box.</summary>
		/// A set of custom colors shown by the dialog box. The default value is null.</returns>
		[SRDescription("CDcustomColorsDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int[] CustomColors
		{
			get
			{
				return (int[])marrCustomColors.Clone();
			}
			set
			{
				int num = ((value != null) ? Math.Min(value.Length, 16) : 0);
				if (num > 0)
				{
					Array.Copy(value, 0, marrCustomColors, 0, num);
				}
				for (int i = num; i < 16; i++)
				{
					marrCustomColors[i] = 16777215;
				}
			}
		}

		/// Gets or sets a value indicating whether the controls used to create custom colors are visible when the dialog box is opened </summary>
		/// true if the custom color controls are available when the dialog box is opened; otherwise, false. The default value is false.</returns>
		/// 2</filterpriority>
		[DefaultValue(false)]
		[SRDescription("CDfullOpenDescr")]
		[SRCategory("CatAppearance")]
		public virtual bool FullOpen
		{
			get
			{
				return GetOption(2);
			}
			set
			{
				SetOption(2, value);
			}
		}

		/// Gets or sets a value indicating whether a Help button appears in the color dialog box.</summary>
		/// true if the Help button is shown in the dialog box; otherwise, false. The default value is false.</returns>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("CDshowHelpDescr")]
		public virtual bool ShowHelp
		{
			get
			{
				return GetOption(8);
			}
			set
			{
				SetOption(8, value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box will restrict users to selecting solid colors only.</summary>
		/// true if users can select only solid colors; otherwise, false. The default value is false.</returns>
		[DefaultValue(false)]
		[SRDescription("CDsolidColorOnlyDescr")]
		[SRCategory("CatBehavior")]
		public virtual bool SolidColorOnly
		{
			get
			{
				return GetOption(128);
			}
			set
			{
				SetOption(128, value);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see> class.</summary>
		public ColorDialog()
		{
			Reset();
		}

		/// Resets all options to their default values, the last selected color to black, and the custom colors to their default values.</summary>
		public override void Reset()
		{
			mintOptions = 0;
			mobjColor = Color.Black;
			CustomColors = null;
		}

		/// 
		/// Resets the selected color
		/// </summary>
		private void ResetColor()
		{
			Color = Color.Black;
		}

		/// 
		/// Set internal dialog option
		/// </summary>
		/// <param name="intOption"></param>
		/// <param name="blnValue"></param>
		private void SetOption(int intOption, bool blnValue)
		{
			if (blnValue)
			{
				mintOptions |= intOption;
			}
			else
			{
				mintOptions &= ~intOption;
			}
		}

		/// 
		/// Get internal dialog option
		/// </summary>
		/// <param name="intOption"></param>
		/// </returns>
		private bool GetOption(int intOption)
		{
			return (mintOptions & intOption) != 0;
		}

		/// 
		/// Indicates when the color needs to be serialized
		/// </summary>
		/// </returns>
		private bool ShouldSerializeColor()
		{
			return !Color.Equals(Color.Black);
		}

		/// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</summary>
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>. </returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override string ToString()
		{
			return base.ToString() + ",  Color: " + Color.ToString();
		}

		/// 
		/// Create the color dialog form
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			return new ColorDialogForm(this);
		}
	}
}
