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
/// Prompts the user to choose a font from among those installed on the local computer.</summary>
	/// 2</filterpriority>
	[Serializable]
	[SRDescription("DescriptionFontDialog")]
	[DefaultEvent("Apply")]
	[DefaultProperty("Font")]
	[ToolboxBitmap(typeof(FontDialog), "FontDialog_45.bmp")]
	[ToolboxItem(true)]
	[Skin(typeof(FontDialogSkin))]
	public class FontDialog : CommonDialog
	{
		/// 
		/// Implements the font dialog form
		/// </summary>
		[Serializable]
		protected class FontDialogForm : CommonDialogForm
		{
			[Serializable]
			private class FontStyleListItem
			{
				private FontStyle menmFontStyle;

				private string mstrText;

				/// 
				/// Gets the font style.
				/// </summary>
				/// The font style.</value>
				public FontStyle FontStyle => menmFontStyle;

				/// 
				/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FontDialog.FontDialogForm.FontStyleListItem" /> class.
				/// </summary>
				/// <param name="objFontStyle">the font style.</param>
				/// <param name="strText">the font style text.</param>
				public FontStyleListItem(FontStyle objFontStyle, string strText)
				{
					menmFontStyle = objFontStyle;
					mstrText = strText;
				}

				/// 
				/// return font style name
				/// </summary>
				/// </returns>
				public override string ToString()
				{
					return mstrText;
				}
			}

			private bool mblnTextChanged = false;

			private bool mblnListChanging = false;

			private bool mblnInitializing = false;

			private bool mblnInitialized = false;

			private Button mobjButtonOk;

			private Button mobjButtonCancel;

			private Button mobjButtonApply;

			private GroupBox mobjGroupsEffects;

			private CheckBox mobjCheckStrikeout;

			private CheckBox mobjCheckUnderline;

			private GroupBox mobjGroupSample;

			private Label mobjLabelSample;

			private Label mobjLabelScrpt;

			private Label mobjLabelColor;

			private ComboBox mobjComboScript;

			private ColorComboBox mobjComboColor;

			private ListBox mobjListFont;

			private ListBox mobjListFontStyle;

			private ListBox mobjListSize;

			private TextBox mobjTextFont;

			private TextBox mobjTextFontStyle;

			private TextBox mobjTextSize;

			private Label mobjLabelFont;

			private Label mobjLabelFontStyle;

			private Label mobjLabelSize;

			/// 
			/// Gets the font dialog owner.
			/// </summary>
			/// The font dialog owner.</value>
			protected FontDialog FontDialogOwner => (FontDialog)base.CommonDialogOwner;

			/// Gets or sets a value indicating whether the user can change the character set specified in the Script combo box to display a character set other than the one currently displayed.</summary>
			/// true if the user can change the character set specified in the Script combo box; otherwise, false. The default value is true.</returns>
			/// 1</filterpriority>
			[DefaultValue(true)]
			[SRCategory("CatBehavior")]
			[SRDescription("FnDallowScriptChangeDescr")]
			public bool AllowScriptChange
			{
				get
				{
					return FontDialogOwner.AllowScriptChange;
				}
				set
				{
					FontDialogOwner.AllowScriptChange = value;
				}
			}

			/// Gets or sets a value indicating whether the dialog box allows graphics device interface (GDI) font simulations.</summary>
			/// true if font simulations are allowed; otherwise, false. The default value is true.</returns>
			/// 1</filterpriority>
			[DefaultValue(true)]
			[SRCategory("CatBehavior")]
			[SRDescription("FnDallowSimulationsDescr")]
			public bool AllowSimulations
			{
				get
				{
					return FontDialogOwner.AllowSimulations;
				}
				set
				{
					FontDialogOwner.AllowSimulations = value;
				}
			}

			/// Gets or sets a value indicating whether the dialog box allows vector font selections.</summary>
			/// true if vector fonts are allowed; otherwise, false. The default value is true.</returns>
			/// 1</filterpriority>
			[SRDescription("FnDallowVectorFontsDescr")]
			[SRCategory("CatBehavior")]
			[DefaultValue(true)]
			public bool AllowVectorFonts
			{
				get
				{
					return FontDialogOwner.AllowVectorFonts;
				}
				set
				{
					FontDialogOwner.AllowVectorFonts = value;
				}
			}

			/// Gets or sets a value indicating whether the dialog box displays both vertical and horizontal fonts or only horizontal fonts.</summary>
			/// true if both vertical and horizontal fonts are allowed; otherwise, false. The default value is true.</returns>
			/// 1</filterpriority>
			[DefaultValue(true)]
			[SRCategory("CatBehavior")]
			[SRDescription("FnDallowVerticalFontsDescr")]
			public bool AllowVerticalFonts
			{
				get
				{
					return FontDialogOwner.AllowVerticalFonts;
				}
				set
				{
					FontDialogOwner.AllowVerticalFonts = value;
				}
			}

			/// Gets or sets the selected font color.</summary>
			/// The color of the selected font. The default value is <see cref="P:System.Drawing.Color.Black"></see>.</returns>
			/// 1</filterpriority>
			[SRCategory("CatData")]
			[DefaultValue(typeof(Color), "Black")]
			[SRDescription("FnDcolorDescr")]
			public Color Color
			{
				get
				{
					return FontDialogOwner.Color;
				}
				set
				{
					FontDialogOwner.Color = value;
				}
			}

			/// Gets or sets a value indicating whether the dialog box allows only the selection of fixed-pitch fonts.</summary>
			/// true if only fixed-pitch fonts can be selected; otherwise, false. The default value is false.</returns>
			/// 1</filterpriority>
			[SRCategory("CatBehavior")]
			[DefaultValue(false)]
			[SRDescription("FnDfixedPitchOnlyDescr")]
			public bool FixedPitchOnly
			{
				get
				{
					return FontDialogOwner.FixedPitchOnly;
				}
				set
				{
					FontDialogOwner.FixedPitchOnly = value;
				}
			}

			/// Gets or sets the selected font.</summary>
			/// The selected font.</returns>
			/// 1</filterpriority>
			[SRDescription("FnDfontDescr")]
			[SRCategory("CatData")]
			public new Font Font
			{
				get
				{
					return FontDialogOwner.Font;
				}
				set
				{
					FontDialogOwner.Font = value;
				}
			}

			/// Gets or sets a value indicating whether the dialog box specifies an error condition if the user attempts to select a font or style that does not exist.</summary>
			/// true if the dialog box specifies an error condition when the user tries to select a font or style that does not exist; otherwise, false. The default is false.</returns>
			/// 1</filterpriority>
			[DefaultValue(false)]
			[SRCategory("CatBehavior")]
			[SRDescription("FnDfontMustExistDescr")]
			public bool FontMustExist
			{
				get
				{
					return FontDialogOwner.FontMustExist;
				}
				set
				{
					FontDialogOwner.FontMustExist = value;
				}
			}

			/// Gets or sets the maximum point size a user can select.</summary>
			/// The maximum point size a user can select. The default is 0.</returns>
			/// 1</filterpriority>
			[SRCategory("CatData")]
			[DefaultValue(0)]
			[SRDescription("FnDmaxSizeDescr")]
			public int MaxSize
			{
				get
				{
					return FontDialogOwner.MaxSize;
				}
				set
				{
					FontDialogOwner.MaxSize = value;
				}
			}

			/// Gets or sets the minimum point size a user can select.</summary>
			/// The minimum point size a user can select. The default is 0.</returns>
			/// 1</filterpriority>
			[SRCategory("CatData")]
			[DefaultValue(0)]
			[SRDescription("FnDminSizeDescr")]
			public int MinSize
			{
				get
				{
					return FontDialogOwner.MinSize;
				}
				set
				{
					FontDialogOwner.MinSize = value;
				}
			}

			/// Gets or sets a value indicating whether the dialog box allows selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.</summary>
			/// true if selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set, is allowed; otherwise, false. The default value is false.</returns>
			/// 1</filterpriority>
			[SRCategory("CatBehavior")]
			[DefaultValue(false)]
			[SRDescription("FnDscriptsOnlyDescr")]
			public bool ScriptsOnly
			{
				get
				{
					return FontDialogOwner.ScriptsOnly;
				}
				set
				{
					FontDialogOwner.ScriptsOnly = value;
				}
			}

			/// Gets or sets a value indicating whether the dialog box contains an Apply button.</summary>
			/// true if the dialog box contains an Apply button; otherwise, false. The default value is false.</returns>
			/// 1</filterpriority>
			[DefaultValue(false)]
			[SRCategory("CatBehavior")]
			[SRDescription("FnDshowApplyDescr")]
			public bool ShowApply
			{
				get
				{
					return FontDialogOwner.ShowApply;
				}
				set
				{
					FontDialogOwner.ShowApply = value;
					mobjButtonApply.Visible = FontDialogOwner.ShowApply;
				}
			}

			/// Gets or sets a value indicating whether the dialog box displays the color choice.</summary>
			/// true if the dialog box displays the color choice; otherwise, false. The default value is false.</returns>
			/// 1</filterpriority>
			[DefaultValue(false)]
			[SRDescription("FnDshowColorDescr")]
			[SRCategory("CatBehavior")]
			public bool ShowColor
			{
				get
				{
					return FontDialogOwner.ShowColor;
				}
				set
				{
					FontDialogOwner.ShowColor = value;
					mobjComboColor.Visible = FontDialogOwner.mblnShowColor;
					mobjLabelColor.Visible = FontDialogOwner.mblnShowColor;
					if (FontDialogOwner.mblnShowColor && mobjComboColor.Items.Count == 0)
					{
						mobjComboColor.Items.AddRange(GetWebColors());
					}
				}
			}

			/// Gets or sets a value indicating whether the dialog box contains controls that allow the user to specify strikethrough, underline, and text color options.</summary>
			/// true if the dialog box contains controls to set strikethrough, underline, and text color options; otherwise, false. The default value is true.</returns>
			/// 1</filterpriority>
			[DefaultValue(true)]
			[SRCategory("CatBehavior")]
			[SRDescription("FnDshowEffectsDescr")]
			public bool ShowEffects
			{
				get
				{
					return FontDialogOwner.ShowEffects;
				}
				set
				{
					FontDialogOwner.ShowEffects = value;
					mobjGroupsEffects.Visible = FontDialogOwner.ShowEffects;
				}
			}

			/// Gets or sets a value indicating whether the dialog box displays a Help button.</summary>
			/// true if the dialog box displays a Help button; otherwise, false. The default value is false.</returns>
			/// 1</filterpriority>
			[SRCategory("CatBehavior")]
			[DefaultValue(false)]
			[SRDescription("FnDshowHelpDescr")]
			public bool ShowHelp
			{
				get
				{
					return FontDialogOwner.ShowHelp;
				}
				set
				{
					FontDialogOwner.ShowHelp = value;
				}
			}

			/// Occurs when the user clicks the Apply button in the font dialog box.</summary>
			/// 1</filterpriority>
			[SRDescription("FnDapplyDescr")]
			public event EventHandler Apply;

			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see> class.</summary>
			public FontDialogForm(FontDialog objFontDialog)
				: base(objFontDialog)
			{
				InitializeComponent();
				base.FormBorderStyle = FormBorderStyle.FixedSingle;
				base.MaximizeBox = false;
				base.MinimizeBox = false;
				AllowScriptChange = objFontDialog.AllowScriptChange;
				AllowSimulations = objFontDialog.AllowSimulations;
				AllowVectorFonts = objFontDialog.AllowVectorFonts;
				AllowVerticalFonts = objFontDialog.AllowVerticalFonts;
				Color = objFontDialog.mobjColor;
				FixedPitchOnly = objFontDialog.FixedPitchOnly;
				Font = objFontDialog.Font;
				FontMustExist = objFontDialog.FontMustExist;
				MaxSize = objFontDialog.MaxSize;
				MinSize = objFontDialog.MinSize;
				ScriptsOnly = objFontDialog.ScriptsOnly;
				ShowApply = objFontDialog.ShowApply;
				ShowColor = objFontDialog.ShowColor;
				ShowEffects = objFontDialog.ShowEffects;
				ShowHelp = objFontDialog.ShowHelp;
				base.Load += FontDialog_Load;
			}

			private void UpdateFromFont()
			{
				if (Font != null)
				{
					mobjTextFont.Text = Font.FontFamily.Name;
					mobjTextFontStyle.Text = Font.Style.ToString();
					mobjTextSize.Text = Font.Size.ToString();
					mobjCheckStrikeout.Checked = Font.Strikeout;
					mobjCheckUnderline.Checked = Font.Underline;
				}
			}

			/// 
			/// Gets the web colors.
			/// </summary>
			/// </returns>
			protected virtual Color[] GetWebColors()
			{
				return GetConstants(typeof(Color));
			}

			/// 
			/// Gets the constants.
			/// </summary>
			/// <param name="objEnumType">Type of the enum.</param>
			/// </returns>
			private Color[] GetConstants(Type objEnumType)
			{
				MethodAttributes methodAttributes = MethodAttributes.Public | MethodAttributes.Static;
				PropertyInfo[] properties = objEnumType.GetProperties();
				ArrayList arrayList = new ArrayList();
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (propertyInfo.PropertyType == typeof(Color))
					{
						MethodInfo getMethod = propertyInfo.GetGetMethod();
						if (getMethod != null && (getMethod.Attributes & methodAttributes) == methodAttributes)
						{
							object[] index = null;
							arrayList.Add(propertyInfo.GetValue(null, index));
						}
					}
				}
				return (Color[])arrayList.ToArray(typeof(Color));
			}

			private void FontDialog_Load(object sender, EventArgs e)
			{
				int num = 0;
				mblnInitializing = true;
				int[] array = new int[17]
				{
					8, 9, 10, 11, 12, 13, 14, 16, 18, 20,
					22, 24, 26, 28, 36, 48, 72
				};
				mobjListFont.DataSource = SerializableFontFamily.Families;
				mobjListFont.DisplayMember = "Name";
				mobjListFont.ValueMember = "Name";
				if (Font == null)
				{
					Font = new Font("Arial", 10f);
				}
				for (int i = 0; i < array.Length; i++)
				{
					num = (int)array.GetValue(i);
					if (num >= MinSize && num <= MaxSize)
					{
						mobjListSize.Items.Add(num);
					}
				}
				if (mobjListSize.Items.Count < 1)
				{
					mobjTextSize.Text = MaxSize.ToString();
				}
				mobjLabelSample.Font = Font;
				mobjLabelSample.ForeColor = Color;
				if (FontDialogOwner.ShowColor)
				{
					mobjComboColor.SelectedItem = Color;
				}
				int num2 = mobjListSize.FindString(Math.Round(Font.Size).ToString());
				num2 = ((num2 != -1) ? num2 : 0);
				mobjListSize.SelectedIndex = num2;
				num2 = mobjListFont.FindString(Font.FontFamily.Name.ToString());
				num2 = ((num2 != -1) ? num2 : 0);
				mobjListFont.SelectedIndex = num2;
				mobjCheckStrikeout.Checked = Font.Strikeout;
				mobjCheckUnderline.Checked = Font.Underline;
				mblnInitializing = false;
				UpdateFontStyles((SerializableFontFamily)Font.FontFamily, blnUpdateSelection: false);
				if (Font.Bold && Font.Italic)
				{
					num2 = mobjListFontStyle.FindString(WGLabels.BoldItalic);
					num2 = ((num2 != -1) ? num2 : 0);
					mobjListFontStyle.SelectedIndex = num2;
				}
				else if (Font.Bold)
				{
					num2 = mobjListFontStyle.FindString(WGLabels.Bold);
					num2 = ((num2 != -1) ? num2 : 0);
					mobjListFontStyle.SelectedIndex = num2;
				}
				else if (Font.Italic)
				{
					num2 = mobjListFontStyle.FindString(WGLabels.Italic);
					num2 = ((num2 != -1) ? num2 : 0);
					mobjListFontStyle.SelectedIndex = num2;
				}
				else
				{
					num2 = mobjListFontStyle.FindString(WGLabels.Regular);
					num2 = ((num2 != -1) ? num2 : 0);
					mobjListFontStyle.SelectedIndex = num2;
				}
				mblnInitialized = true;
			}

			private void InitializeComponent()
			{
				mobjButtonOk = new Button();
				mobjButtonCancel = new Button();
				mobjButtonApply = new Button();
				mobjGroupsEffects = new GroupBox();
				mobjCheckStrikeout = new CheckBox();
				mobjCheckUnderline = new CheckBox();
				mobjGroupSample = new GroupBox();
				mobjLabelSample = new Label();
				mobjLabelScrpt = new Label();
				mobjLabelColor = new Label();
				mobjComboScript = new ComboBox();
				mobjComboColor = new ColorComboBox();
				mobjListFont = new ListBox();
				mobjListFontStyle = new ListBox();
				mobjListSize = new ListBox();
				mobjTextFont = new TextBox();
				mobjTextFontStyle = new TextBox();
				mobjTextSize = new TextBox();
				mobjLabelFont = new Label();
				mobjLabelFontStyle = new Label();
				mobjLabelSize = new Label();
				mobjGroupsEffects.SuspendLayout();
				mobjGroupSample.SuspendLayout();
				SuspendLayout();
				mobjButtonOk.Location = new Point(351, 27);
				mobjButtonOk.Name = "mobjButtonOk";
				mobjButtonOk.Size = new Size(62, 23);
				mobjButtonOk.TabIndex = 0;
				mobjButtonOk.Text = WGLabels.Ok;
				mobjButtonOk.Click += mobjButtonOk_Click;
				mobjButtonCancel.Location = new Point(351, 52);
				mobjButtonCancel.Name = "mobjButtonCancel";
				mobjButtonCancel.Size = new Size(62, 23);
				mobjButtonCancel.TabIndex = 1;
				mobjButtonCancel.Text = WGLabels.Cancel;
				mobjButtonCancel.Click += mobjButtonCancel_Click;
				mobjButtonApply.Location = new Point(351, 77);
				mobjButtonApply.Name = "mobjButtonApply";
				mobjButtonApply.Size = new Size(62, 23);
				mobjButtonApply.TabIndex = 1;
				mobjButtonApply.Text = WGLabels.Apply;
				mobjButtonApply.Click += mobjButtonApply_Click;
				mobjGroupsEffects.Controls.Add(mobjCheckUnderline);
				mobjGroupsEffects.Controls.Add(mobjCheckStrikeout);
				mobjGroupsEffects.Controls.Add(mobjLabelColor);
				mobjGroupsEffects.Controls.Add(mobjComboColor);
				mobjGroupsEffects.Location = new Point(12, 158);
				mobjGroupsEffects.Name = "mobjGroupsEffects";
				mobjGroupsEffects.Size = new Size(146, 120);
				mobjGroupsEffects.TabIndex = 2;
				mobjGroupsEffects.TabStop = false;
				mobjGroupsEffects.Text = WGLabels.Effects;
				mobjCheckStrikeout.Location = new Point(7, 20);
				mobjCheckStrikeout.Name = "mobjCheckStrikeout";
				mobjCheckStrikeout.Size = new Size(80, 17);
				mobjCheckStrikeout.TabIndex = 0;
				mobjCheckStrikeout.Text = WGLabels.Strikeout;
				mobjCheckStrikeout.CheckedChanged += mobjCheckStrikeout_CheckedChanged;
				mobjCheckUnderline.Location = new Point(7, 40);
				mobjCheckUnderline.Name = "mobjCheckUnderline";
				mobjCheckUnderline.Size = new Size(80, 17);
				mobjCheckUnderline.TabIndex = 1;
				mobjCheckUnderline.Text = WGLabels.Underline;
				mobjCheckUnderline.CheckedChanged += mobjCheckUnderline_CheckedChanged;
				mobjLabelColor.AutoSize = true;
				mobjLabelColor.Location = new Point(7, 60);
				mobjLabelColor.Name = "mobjLabelScrpt";
				mobjLabelColor.Size = new Size(71, 21);
				mobjLabelColor.TabIndex = 4;
				mobjLabelColor.Text = WGLabels.Color;
				mobjLabelColor.Visible = false;
				mobjComboColor.FormattingEnabled = true;
				mobjComboColor.Location = new Point(7, 75);
				mobjComboColor.Name = "mobjComboColor";
				mobjComboColor.Size = new Size(125, 21);
				mobjComboColor.TabIndex = 2;
				mobjComboColor.Visible = false;
				mobjComboColor.BackgroundImageLayout = ImageLayout.Tile;
				mobjComboColor.BorderStyle = BorderStyle.Fixed3D;
				mobjComboColor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				mobjComboColor.SelectedValueChanged += mobjComboColor_SelectedValueChanged;
				mobjGroupSample.Controls.Add(mobjLabelSample);
				mobjGroupSample.Location = new Point(164, 158);
				mobjGroupSample.Name = "mobjGroupSample";
				mobjGroupSample.Size = new Size(176, 70);
				mobjGroupSample.TabIndex = 3;
				mobjGroupSample.TabStop = false;
				mobjGroupSample.Text = WGLabels.Sample;
				mobjLabelSample.Location = new Point(15, 21);
				mobjLabelSample.Name = "mobjLabelSample";
				mobjLabelSample.Size = new Size(144, 42);
				mobjLabelSample.TabIndex = 0;
				mobjLabelSample.Text = "AaBbðñùú";
				mobjLabelSample.TextAlign = ContentAlignment.MiddleCenter;
				mobjLabelScrpt.AutoSize = true;
				mobjLabelScrpt.Location = new Point(164, 240);
				mobjLabelScrpt.Name = "mobjLabelScrpt";
				mobjLabelScrpt.Size = new Size(37, 13);
				mobjLabelScrpt.TabIndex = 4;
				mobjLabelScrpt.Text = WGLabels.Script;
				mobjLabelScrpt.Visible = false;
				mobjComboScript.FormattingEnabled = true;
				mobjComboScript.Location = new Point(167, 257);
				mobjComboScript.Name = "mobjComboScript";
				mobjComboScript.Size = new Size(173, 21);
				mobjComboScript.TabIndex = 5;
				mobjComboScript.Visible = false;
				mobjListFont.FormattingEnabled = true;
				mobjListFont.Location = new Point(12, 49);
				mobjListFont.Name = "mobjListFont";
				mobjListFont.Size = new Size(146, 95);
				mobjListFont.TabIndex = 6;
				mobjListFont.SelectedIndexChanged += mobjListFont_SelectedIndexChanged;
				mobjListFont.SelectionMode = SelectionMode.One;
				mobjListFontStyle.FormattingEnabled = true;
				mobjListFontStyle.Location = new Point(167, 49);
				mobjListFontStyle.Name = "mobjListFontStyle";
				mobjListFontStyle.Size = new Size(110, 95);
				mobjListFontStyle.TabIndex = 7;
				mobjListFontStyle.SelectedIndexChanged += mobjListFontStyle_SelectedIndexChanged;
				mobjListFontStyle.SelectionMode = SelectionMode.One;
				mobjListSize.FormattingEnabled = true;
				mobjListSize.Location = new Point(284, 49);
				mobjListSize.Name = "mobjListSize";
				mobjListSize.Size = new Size(56, 95);
				mobjListSize.TabIndex = 8;
				mobjListSize.SelectedIndexChanged += mobjListSize_SelectedIndexChanged;
				mobjListSize.SelectionMode = SelectionMode.One;
				mobjTextFont.Location = new Point(12, 27);
				mobjTextFont.Name = "mobjTextFont";
				mobjTextFont.Size = new Size(146, 20);
				mobjTextFont.TabIndex = 9;
				mobjTextFont.TextChanged += mobjTextFont_TextChanged;
				mobjTextFontStyle.Location = new Point(167, 27);
				mobjTextFontStyle.Name = "mobjTextFontStyle";
				mobjTextFontStyle.Size = new Size(110, 20);
				mobjTextFontStyle.TabIndex = 10;
				mobjTextFontStyle.TextChanged += mobjTextFontStyle_TextChanged;
				mobjTextSize.Location = new Point(284, 27);
				mobjTextSize.Name = "mobjTextSize";
				mobjTextSize.Size = new Size(56, 20);
				mobjTextSize.TabIndex = 11;
				mobjTextSize.TextChanged += mobjTextSize_TextChanged;
				mobjLabelFont.Location = new Point(12, 13);
				mobjLabelFont.Name = "mobjLabelFont";
				mobjLabelFont.Size = new Size(31, 13);
				mobjLabelFont.TabIndex = 12;
				mobjLabelFont.Text = WGLabels.FontColon;
				mobjLabelFontStyle.Location = new Point(167, 12);
				mobjLabelFontStyle.Name = "mobjLabelFontStyle";
				mobjLabelFontStyle.Size = new Size(57, 13);
				mobjLabelFontStyle.TabIndex = 13;
				mobjLabelFontStyle.Text = WGLabels.FontStyle;
				mobjLabelSize.Location = new Point(284, 12);
				mobjLabelSize.Name = "mobjLabelSize";
				mobjLabelSize.Size = new Size(30, 13);
				mobjLabelSize.TabIndex = 14;
				mobjLabelSize.Text = WGLabels.Size;
				base.ClientSize = new Size(433, 319);
				base.Controls.Add(mobjLabelSize);
				base.Controls.Add(mobjLabelFontStyle);
				base.Controls.Add(mobjLabelFont);
				base.Controls.Add(mobjTextSize);
				base.Controls.Add(mobjTextFontStyle);
				base.Controls.Add(mobjTextFont);
				base.Controls.Add(mobjListSize);
				base.Controls.Add(mobjListFontStyle);
				base.Controls.Add(mobjListFont);
				base.Controls.Add(mobjComboScript);
				base.Controls.Add(mobjLabelScrpt);
				base.Controls.Add(mobjGroupSample);
				base.Controls.Add(mobjGroupsEffects);
				base.Controls.Add(mobjButtonCancel);
				base.Controls.Add(mobjButtonApply);
				base.Controls.Add(mobjButtonOk);
				base.Name = "FontDialog";
				Text = WGLabels.Font;
				mobjGroupsEffects.ResumeLayout(blnPerformLayout: true);
				mobjGroupSample.ResumeLayout(blnPerformLayout: false);
				ResumeLayout(blnPerformLayout: true);
			}

			/// 
			/// Handles the SelectedValueChanged event of the mobjComboColor control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mobjComboColor_SelectedValueChanged(object sender, EventArgs e)
			{
				if (mobjComboColor.SelectedItem != null)
				{
					Color color = Color.Empty;
					try
					{
						color = (Color)mobjComboColor.SelectedItem;
					}
					catch
					{
					}
					bool flag = true;
					FontDialogOwner.mobjColor = color;
					mobjLabelSample.ForeColor = color;
				}
			}

			private void mobjCheckUnderline_CheckedChanged(object sender, EventArgs e)
			{
				RefreshFont();
			}

			private void mobjCheckStrikeout_CheckedChanged(object sender, EventArgs e)
			{
				RefreshFont();
			}

			private void UpdateFontStyles(SerializableFontFamily objFontFamily, bool blnUpdateSelection)
			{
				if (mblnInitializing)
				{
					return;
				}
				ArrayList arrayList = new ArrayList();
				if (objFontFamily.IsStyleAvailable(FontStyle.Regular))
				{
					arrayList.Add(new FontStyleListItem(FontStyle.Regular, WGLabels.Regular));
				}
				if (objFontFamily.IsStyleAvailable(FontStyle.Italic))
				{
					arrayList.Add(new FontStyleListItem(FontStyle.Italic, WGLabels.Italic));
				}
				if (objFontFamily.IsStyleAvailable(FontStyle.Bold))
				{
					arrayList.Add(new FontStyleListItem(FontStyle.Bold, WGLabels.Bold));
				}
				if (objFontFamily.IsStyleAvailable(FontStyle.Bold) || objFontFamily.IsStyleAvailable(FontStyle.Italic))
				{
					arrayList.Add(new FontStyleListItem(FontStyle.Bold | FontStyle.Italic, WGLabels.BoldItalic));
				}
				bool flag = mobjListFontStyle.Items.Count != arrayList.Count;
				if (!flag)
				{
					foreach (FontStyleListItem item in arrayList)
					{
						if (mobjListFontStyle.FindString(item.ToString()) == -1)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					mobjListFontStyle.Items.Clear();
					mobjListFontStyle.Items.AddRange(arrayList);
					if (blnUpdateSelection)
					{
						int num = mobjListFontStyle.FindString(WGLabels.Regular);
						num = ((num != -1) ? num : 0);
						mobjListFontStyle.SelectedIndex = num;
					}
				}
			}

			private void mobjTextFont_TextChanged(object sender, EventArgs e)
			{
				if (!mblnListChanging)
				{
					ApplyFontName(blnShowValidationMessages: false);
				}
			}

			private void mobjTextFontStyle_TextChanged(object sender, EventArgs e)
			{
				if (!mblnListChanging)
				{
					int num = mobjListFontStyle.FindString(mobjTextFontStyle.Text);
					if (num > -1)
					{
						mblnTextChanged = true;
						mobjListFontStyle.SelectedIndex = num;
						mobjListFontStyle.Update();
						RefreshFont();
						mblnTextChanged = false;
					}
					else
					{
						mobjTextFontStyle.Text = mobjListFontStyle.SelectedItem.ToString();
					}
				}
			}

			private void mobjTextSize_TextChanged(object sender, EventArgs e)
			{
				if (!mblnListChanging)
				{
					ApplyFontSize(blnShowValidationMessages: false);
				}
			}

			/// 
			/// Applies the size of the font.
			/// </summary>
			/// </returns>
			private bool ApplyFontSize(bool blnShowValidationMessages)
			{
				bool result = false;
				int num = mobjListSize.FindString(mobjTextSize.Text);
				if (num > -1 && !string.IsNullOrEmpty(mobjTextSize.Text))
				{
					mblnTextChanged = true;
					mobjListSize.SelectedIndex = num;
					mobjListSize.Update();
					RefreshFont();
					mblnTextChanged = false;
					result = true;
				}
				else if (!string.IsNullOrEmpty(mobjTextSize.Text))
				{
					int result2 = -1;
					if (int.TryParse(mobjTextSize.Text, out result2))
					{
						if (result2 >= MinSize && result2 <= MaxSize)
						{
							result = true;
						}
						else
						{
							if (mobjListSize.SelectedItem != null)
							{
								mobjTextSize.Text = mobjListSize.SelectedItem.ToString();
							}
							if (blnShowValidationMessages)
							{
								MessageBox.Show("Size must be between " + MinSize + " and " + MaxSize + " points.", "Font");
							}
						}
					}
					else if (blnShowValidationMessages)
					{
						MessageBox.Show("Size must be a number.", "Font");
					}
				}
				return result;
			}

			/// 
			/// Applies the name of the font.
			/// </summary>
			/// </returns>
			private bool ApplyFontName(bool blnShowValidationMessages)
			{
				bool result = false;
				int num = mobjListFont.FindString(mobjTextFont.Text);
				if (num > -1)
				{
					mblnTextChanged = true;
					mobjListFont.SelectedIndex = num;
					UpdateFontStyles((SerializableFontFamily)mobjListFont.SelectedItem, blnUpdateSelection: true);
					mobjListFont.Update();
					RefreshFont();
					mblnTextChanged = false;
					result = true;
				}
				else if (FontMustExist)
				{
					if (blnShowValidationMessages)
					{
						MessageBox.Show("There is no font with that name. \r\n Choose a font from the list of fonts.", "Font");
					}
				}
				else
				{
					result = true;
				}
				return result;
			}

			/// 
			/// Validates the font.
			/// </summary>
			/// </returns>
			private bool ApplyFont()
			{
				return ApplyFontName(blnShowValidationMessages: true) && ApplyFontSize(blnShowValidationMessages: true);
			}

			private void mobjListFontStyle_SelectedIndexChanged(object sender, EventArgs e)
			{
				mblnListChanging = true;
				if (!mblnTextChanged)
				{
					mobjTextFontStyle.Text = mobjListFontStyle.SelectedItem.ToString();
					RefreshFont();
				}
				mblnListChanging = false;
			}

			private void mobjListSize_SelectedIndexChanged(object sender, EventArgs e)
			{
				mblnListChanging = true;
				if (!mblnTextChanged)
				{
					mobjTextSize.Text = mobjListSize.SelectedItem.ToString();
					RefreshFont();
				}
				mblnListChanging = false;
			}

			private void mobjListFont_SelectedIndexChanged(object sender, EventArgs e)
			{
				mblnListChanging = true;
				if (!mblnTextChanged)
				{
					mobjTextFont.Text = ((SerializableFontFamily)mobjListFont.SelectedItem).Name;
					UpdateFontStyles((SerializableFontFamily)mobjListFont.SelectedItem, blnUpdateSelection: true);
					RefreshFont();
				}
				mblnListChanging = false;
			}

			private void mobjButtonApply_Click(object sender, EventArgs e)
			{
				FontDialogOwner.OnApply(EventArgs.Empty);
			}

			private void mobjButtonCancel_Click(object sender, EventArgs e)
			{
				base.DialogResult = DialogResult.Cancel;
				Close();
			}

			private void mobjButtonOk_Click(object sender, EventArgs e)
			{
				if (ApplyFont())
				{
					base.DialogResult = DialogResult.OK;
					Close();
				}
			}

			private void RefreshFont()
			{
				if (!mblnInitializing && CommonUtils.TryParse(mobjTextSize.Text, out float fltValue))
				{
					FontStyle fontStyle = ((FontStyleListItem)mobjListFontStyle.SelectedItem).FontStyle;
					if (mobjCheckStrikeout.Checked)
					{
						fontStyle |= FontStyle.Strikeout;
					}
					if (mobjCheckUnderline.Checked)
					{
						fontStyle |= FontStyle.Underline;
					}
					Font = new SerializableFont((SerializableFontFamily)mobjListFont.SelectedItem, fltValue, fontStyle, GraphicsUnit.Point);
					mobjLabelSample.Font = Font;
					mobjLabelSample.Update();
				}
			}

			/// Raises the <see cref="E:Gizmox.WebGUI.Forms.FontDialog.Apply"></see> event.</summary>
			/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the data. </param>
			protected virtual void OnApply(EventArgs e)
			{
				this.Apply?.Invoke(this, e);
			}

			/// Resets all dialog box options to their default values.</summary>
			/// 1</filterpriority>
			public virtual void Reset()
			{
			}
		}

		private Color mobjColor;

		private const int mintDefaultMaxSize = 0;

		private const int mintDefaultMinSize = 0;

		/// 
		/// Owns the Apply event.
		/// </summary>
		protected static readonly SerializableEvent EventApply = SerializableEvent.Register("Event", typeof(Delegate), typeof(FontDialog));

		private SerializableFont mobjFont;

		private int mintMaxSize;

		private int mintMinSize;

		private int mintOptions;

		private bool mblnShowColor;

		/// Gets or sets a value indicating whether the user can change the character set specified in the Script combo box to display a character set other than the one currently displayed.</summary>
		/// true if the user can change the character set specified in the Script combo box; otherwise, false. The default value is true.</returns>
		[DefaultValue(true)]
		[SRDescription("FnDallowScriptChangeDescr")]
		[SRCategory("CatBehavior")]
		public bool AllowScriptChange
		{
			get
			{
				return !GetOption(4194304);
			}
			set
			{
				SetOption(4194304, !value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box allows graphics device interface (GDI) font simulations.</summary>
		/// true if font simulations are allowed; otherwise, false. The default value is true.</returns>
		[SRDescription("FnDallowSimulationsDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public bool AllowSimulations
		{
			get
			{
				return !GetOption(4096);
			}
			set
			{
				SetOption(4096, !value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box allows vector font selections.</summary>
		/// true if vector fonts are allowed; otherwise, false. The default value is true.</returns>
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		[SRDescription("FnDallowVectorFontsDescr")]
		public bool AllowVectorFonts
		{
			get
			{
				return !GetOption(2048);
			}
			set
			{
				SetOption(2048, !value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box displays both vertical and horizontal fonts or only horizontal fonts.</summary>
		/// true if both vertical and horizontal fonts are allowed; otherwise, false. The default value is true.</returns>
		[SRCategory("CatBehavior")]
		[SRDescription("FnDallowVerticalFontsDescr")]
		[DefaultValue(true)]
		public bool AllowVerticalFonts
		{
			get
			{
				return !GetOption(16777216);
			}
			set
			{
				SetOption(16777216, !value);
			}
		}

		/// Gets or sets the selected font color.</summary>
		/// The color of the selected font. The default value is <see cref="P:System.Drawing.Color.Black"></see>.</returns>
		[SRDescription("FnDcolorDescr")]
		[DefaultValue(typeof(Color), "Black")]
		[SRCategory("CatData")]
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

		/// Gets or sets a value indicating whether the dialog box allows only the selection of fixed-pitch fonts.</summary>
		/// true if only fixed-pitch fonts can be selected; otherwise, false. The default value is false.</returns>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("FnDfixedPitchOnlyDescr")]
		public bool FixedPitchOnly
		{
			get
			{
				return GetOption(16384);
			}
			set
			{
				SetOption(16384, value);
			}
		}

		/// Gets or sets the selected font.</summary>
		/// The selected font.</returns>
		[SRCategory("CatData")]
		[SRDescription("FnDfontDescr")]
		public Font Font
		{
			get
			{
				Font font = mobjFont;
				if (font == null)
				{
					font = Control.DefaultFont;
				}
				float sizeInPoints = font.SizeInPoints;
				if (mintMinSize != 0 && sizeInPoints < (float)MinSize)
				{
					font = new Font(font.FontFamily, MinSize, font.Style, GraphicsUnit.Point);
				}
				if (mintMaxSize != 0 && sizeInPoints > (float)MaxSize)
				{
					font = new Font(font.FontFamily, MaxSize, font.Style, GraphicsUnit.Point);
				}
				return font;
			}
			set
			{
				mobjFont = (SerializableFont)value;
			}
		}

		/// Gets or sets a value indicating whether the dialog box specifies an error condition if the user attempts to select a font or style that does not exist.</summary>
		/// true if the dialog box specifies an error condition when the user tries to select a font or style that does not exist; otherwise, false. The default is false.</returns>
		[DefaultValue(false)]
		[SRDescription("FnDfontMustExistDescr")]
		[SRCategory("CatBehavior")]
		public bool FontMustExist
		{
			get
			{
				return GetOption(65536);
			}
			set
			{
				SetOption(65536, value);
			}
		}

		/// Gets or sets the maximum point size a user can select.</summary>
		/// The maximum point size a user can select. The default is 0.</returns>
		[SRDescription("FnDmaxSizeDescr")]
		[SRCategory("CatData")]
		[DefaultValue(0)]
		public int MaxSize
		{
			get
			{
				return mintMaxSize;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				mintMaxSize = value;
				if (mintMaxSize > 0 && mintMaxSize < mintMinSize)
				{
					mintMinSize = mintMaxSize;
				}
			}
		}

		/// Gets or sets the minimum point size a user can select.</summary>
		/// The minimum point size a user can select. The default is 0.</returns>
		[DefaultValue(0)]
		[SRDescription("FnDminSizeDescr")]
		[SRCategory("CatData")]
		public int MinSize
		{
			get
			{
				return mintMinSize;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				mintMinSize = value;
				if (mintMaxSize > 0 && mintMaxSize < mintMinSize)
				{
					mintMaxSize = mintMinSize;
				}
			}
		}

		/// Gets values to initialize the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see>.</summary>
		/// A bitwise combination of internal values that initializes the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see>.</returns>
		protected int Options => mintOptions;

		/// Gets or sets a value indicating whether the dialog box allows selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.</summary>
		/// true if selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set, is allowed; otherwise, false. The default value is false.</returns>
		[SRDescription("FnDscriptsOnlyDescr")]
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		public bool ScriptsOnly
		{
			get
			{
				return GetOption(1024);
			}
			set
			{
				SetOption(1024, value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box contains an Apply button.</summary>
		/// true if the dialog box contains an Apply button; otherwise, false. The default value is false.</returns>
		[SRDescription("FnDshowApplyDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool ShowApply
		{
			get
			{
				return GetOption(512);
			}
			set
			{
				SetOption(512, value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box displays the color choice.</summary>
		/// true if the dialog box displays the color choice; otherwise, false. The default value is false.</returns>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("FnDshowColorDescr")]
		public bool ShowColor
		{
			get
			{
				return mblnShowColor;
			}
			set
			{
				mblnShowColor = value;
			}
		}

		/// Gets or sets a value indicating whether the dialog box contains controls that allow the user to specify strikethrough, underline, and text color options.</summary>
		/// true if the dialog box contains controls to set strikethrough, underline, and text color options; otherwise, false. The default value is true.</returns>
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		[SRDescription("FnDshowEffectsDescr")]
		public bool ShowEffects
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

		/// Gets or sets a value indicating whether the dialog box displays a Help button.</summary>
		/// true if the dialog box displays a Help button; otherwise, false. The default value is false.</returns>
		[SRCategory("CatBehavior")]
		[SRDescription("FnDshowHelpDescr")]
		[DefaultValue(false)]
		public bool ShowHelp
		{
			get
			{
				return GetOption(4);
			}
			set
			{
				SetOption(4, value);
			}
		}

		/// 
		/// Occurs when [apply].
		/// </summary>
		public event EventHandler Apply
		{
			add
			{
				AddHandler(EventApply, value);
			}
			remove
			{
				RemoveHandler(EventApply, value);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see> class.</summary>
		public FontDialog()
		{
			Reset();
		}

		/// 
		/// Gets a dialog option value
		/// </summary>
		/// <param name="intOption"></param>
		/// </returns>
		internal bool GetOption(int intOption)
		{
			return (mintOptions & intOption) != 0;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.FontDialog.Apply"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the data. </param>
		protected override void OnApply(EventArgs e)
		{
			((EventHandler)GetHandler(EventApply))?.Invoke(this, e);
		}

		/// Resets all dialog box options to their default values.</summary>
		/// 1</filterpriority>
		public override void Reset()
		{
			mintOptions = 257;
			mobjFont = null;
			mobjColor = Color.Black;
			mblnShowColor = false;
			mintMinSize = 8;
			mintMaxSize = 72;
			SetOption(262144, blnValue: true);
		}

		private void ResetFont()
		{
			mobjFont = null;
		}

		/// 
		/// Sets a dialog option value
		/// </summary>
		/// <param name="intOption"></param>
		/// <param name="blnValue"></param>
		internal void SetOption(int intOption, bool blnValue)
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

		private bool ShouldSerializeFont()
		{
			return !Font.Equals(Control.DefaultFont);
		}

		/// Retrieves a string that includes the name of the current font selected in the dialog box.</summary>
		/// A string that includes the name of the currently selected font.</returns>
		public override string ToString()
		{
			return base.ToString() + ",  Font: " + Font.ToString();
		}

		/// 
		/// Create the color dialog form
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			return new FontDialogForm(this);
		}
	}
}
