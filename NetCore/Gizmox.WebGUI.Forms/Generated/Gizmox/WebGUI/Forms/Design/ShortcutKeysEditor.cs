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

namespace Gizmox.WebGUI.Forms.Design
{
	/// 
	/// Provides a user interface for specifying a ShortcutKeys property.
	/// </summary>
	[Serializable]
	public class ShortcutKeysEditor : WebUITypeEditor
	{
		/// 
		///
		/// </summary>
		[Serializable]
		private class ShortcutKeysUI : Form
		{
			private Label mobjLabelmodifiers;

			private CheckBox mobjCheckBoxCtrl;

			private CheckBox mobjCheckBoxShift;

			private CheckBox mobjCheckBoxAlt;

			private Label mobjLabelKeys;

			private ComboBox mobjComboBoxKeys;

			private Button mobjButtonReset;

			private TypeConverter mobjKeysConverter = null;

			private static Keys[] validKeys = new Keys[94]
			{
				Keys.A,
				Keys.B,
				Keys.C,
				Keys.D,
				Keys.D0,
				Keys.D1,
				Keys.D2,
				Keys.D3,
				Keys.D4,
				Keys.D5,
				Keys.D6,
				Keys.D7,
				Keys.D8,
				Keys.D9,
				Keys.Delete,
				Keys.Down,
				Keys.E,
				Keys.End,
				Keys.F,
				Keys.F1,
				Keys.F10,
				Keys.F11,
				Keys.F12,
				Keys.F13,
				Keys.F14,
				Keys.F15,
				Keys.F16,
				Keys.F17,
				Keys.F18,
				Keys.F19,
				Keys.F2,
				Keys.F20,
				Keys.F21,
				Keys.F22,
				Keys.F23,
				Keys.F24,
				Keys.F3,
				Keys.F4,
				Keys.F5,
				Keys.F6,
				Keys.F7,
				Keys.F8,
				Keys.F9,
				Keys.G,
				Keys.H,
				Keys.I,
				Keys.Insert,
				Keys.J,
				Keys.K,
				Keys.L,
				Keys.Left,
				Keys.M,
				Keys.N,
				Keys.NumLock,
				Keys.NumPad0,
				Keys.NumPad1,
				Keys.NumPad2,
				Keys.NumPad3,
				Keys.NumPad4,
				Keys.NumPad5,
				Keys.NumPad6,
				Keys.NumPad7,
				Keys.NumPad8,
				Keys.NumPad9,
				Keys.O,
				Keys.OemBackslash,
				Keys.OemClear,
				Keys.OemCloseBrackets,
				Keys.Oemcomma,
				Keys.OemMinus,
				Keys.OemOpenBrackets,
				Keys.OemPeriod,
				Keys.OemPipe,
				Keys.Oemplus,
				Keys.OemQuestion,
				Keys.OemQuotes,
				Keys.OemSemicolon,
				Keys.Oemtilde,
				Keys.P,
				Keys.Pause,
				Keys.Q,
				Keys.R,
				Keys.Right,
				Keys.S,
				Keys.Space,
				Keys.T,
				Keys.Tab,
				Keys.U,
				Keys.Up,
				Keys.V,
				Keys.W,
				Keys.X,
				Keys.Y,
				Keys.Z
			};

			private Keys menmValue = Keys.None;

			/// 
			/// Gets or sets the shortcut keys.
			/// </summary>
			/// 
			/// The shortcut keys.
			/// </value>
			public Keys ShortcutKeys
			{
				get
				{
					UpdateCurrentValue();
					return menmValue;
				}
				set
				{
					menmValue = value;
					UpdateUI();
				}
			}

			/// 
			/// Gets or sets a value indicating whether this instance is completed.
			/// </summary>
			/// 
			/// 	true</c> if this instance is completed; otherwise, false</c>.
			/// </value>
			public bool IsCompleted
			{
				get
				{
					return true;
				}
				set
				{
				}
			}

			/// 
			/// Gets the keys converter.
			/// </summary>
			private TypeConverter KeysConverter
			{
				get
				{
					if (mobjKeysConverter == null)
					{
						mobjKeysConverter = TypeDescriptor.GetConverter(typeof(Keys));
					}
					return mobjKeysConverter;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.ShortcutKeysEditor.ShortcutKeysUI" /> class.
			/// </summary>
			public ShortcutKeysUI()
			{
				InitializeComponent();
				Keys[] array = validKeys;
				foreach (Keys keys in array)
				{
					mobjComboBoxKeys.Items.Add(KeysConverter.ConvertToString(keys));
				}
			}

			/// 
			/// Updates the value.
			/// </summary>
			private void UpdateUI()
			{
				Keys keys = menmValue;
				if (keys != Keys.None)
				{
					mobjCheckBoxCtrl.Checked = (keys & Keys.Control) != 0;
					mobjCheckBoxAlt.Checked = (keys & Keys.Alt) != 0;
					mobjCheckBoxShift.Checked = (keys & Keys.Shift) != 0;
					Keys keys2 = keys & Keys.KeyCode;
					mobjComboBoxKeys.SelectedItem = KeysConverter.ConvertToString(keys2);
				}
			}

			/// 
			/// Initializes the component.
			/// </summary>
			private void InitializeComponent()
			{
				mobjLabelmodifiers = new Label();
				mobjCheckBoxCtrl = new CheckBox();
				mobjCheckBoxShift = new CheckBox();
				mobjCheckBoxAlt = new CheckBox();
				mobjLabelKeys = new Label();
				mobjComboBoxKeys = new ComboBox();
				mobjButtonReset = new Button();
				SuspendLayout();
				mobjLabelmodifiers.AutoSize = true;
				mobjLabelmodifiers.Location = new Point(10, 10);
				mobjLabelmodifiers.Name = "mobjLabelmodifiers";
				mobjLabelmodifiers.Size = new Size(35, 13);
				mobjLabelmodifiers.TabIndex = 0;
				mobjLabelmodifiers.Text = WGLabels.ModifiersColon;
				mobjCheckBoxCtrl.AutoSize = true;
				mobjCheckBoxCtrl.CheckState = CheckState.Unchecked;
				mobjCheckBoxCtrl.Location = new Point(20, 40);
				mobjCheckBoxCtrl.Name = "mobjCheckBoxCtrl";
				mobjCheckBoxCtrl.Size = new Size(43, 17);
				mobjCheckBoxCtrl.TabIndex = 1;
				mobjCheckBoxCtrl.Text = "Ctrl";
				mobjCheckBoxShift.AutoSize = true;
				mobjCheckBoxShift.CheckState = CheckState.Unchecked;
				mobjCheckBoxShift.Location = new Point(71, 40);
				mobjCheckBoxShift.Name = "mobjCheckBoxShift";
				mobjCheckBoxShift.Size = new Size(48, 17);
				mobjCheckBoxShift.TabIndex = 2;
				mobjCheckBoxShift.Text = "Shift";
				mobjCheckBoxAlt.AutoSize = true;
				mobjCheckBoxAlt.CheckState = CheckState.Unchecked;
				mobjCheckBoxAlt.Location = new Point(129, 40);
				mobjCheckBoxAlt.Name = "mobjCheckBoxAlt";
				mobjCheckBoxAlt.Size = new Size(39, 17);
				mobjCheckBoxAlt.TabIndex = 3;
				mobjCheckBoxAlt.Text = "Alt";
				mobjLabelKeys.AutoSize = true;
				mobjLabelKeys.Location = new Point(13, 70);
				mobjLabelKeys.Name = "mobjLabelKeys";
				mobjLabelKeys.Size = new Size(35, 13);
				mobjLabelKeys.TabIndex = 4;
				mobjLabelKeys.Text = WGLabels.KeysColon;
				mobjComboBoxKeys.AllowDrag = false;
				mobjComboBoxKeys.DropDownStyle = ComboBoxStyle.DropDownList;
				mobjComboBoxKeys.FormattingEnabled = true;
				mobjComboBoxKeys.Location = new Point(20, 100);
				mobjComboBoxKeys.Name = "mobjComboBoxKeys";
				mobjComboBoxKeys.Size = new Size(148, 21);
				mobjComboBoxKeys.TabIndex = 5;
				mobjButtonReset.AutoSize = true;
				mobjButtonReset.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				mobjButtonReset.Location = new Point(182, 100);
				mobjButtonReset.Name = "mobjButtonReset";
				mobjButtonReset.Size = new Size(75, 23);
				mobjButtonReset.TabIndex = 6;
				mobjButtonReset.Text = WGLabels.Reset;
				mobjButtonReset.Click += mobjButtonReset_Click;
				base.Controls.Add(mobjButtonReset);
				base.Controls.Add(mobjComboBoxKeys);
				base.Controls.Add(mobjLabelKeys);
				base.Controls.Add(mobjCheckBoxAlt);
				base.Controls.Add(mobjCheckBoxShift);
				base.Controls.Add(mobjCheckBoxCtrl);
				base.Controls.Add(mobjLabelmodifiers);
				base.Size = new Size(240, 140);
				Text = "";
				ResumeLayout(blnPerformLayout: false);
			}

			/// 
			/// Handles the Click event of the mobjButtonReset control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mobjButtonReset_Click(object sender, EventArgs e)
			{
				mobjCheckBoxCtrl.Checked = false;
				mobjCheckBoxAlt.Checked = false;
				mobjCheckBoxShift.Checked = false;
				mobjComboBoxKeys.SelectedIndex = -1;
			}

			/// 
			/// Updates the current value.
			/// </summary>
			private void UpdateCurrentValue()
			{
				menmValue = Keys.None;
				if (mobjComboBoxKeys.SelectedIndex > -1)
				{
					menmValue = validKeys[mobjComboBoxKeys.SelectedIndex];
					if (mobjCheckBoxCtrl.Checked)
					{
						menmValue |= Keys.Control;
					}
					if (mobjCheckBoxAlt.Checked)
					{
						menmValue |= Keys.Alt;
					}
					if (mobjCheckBoxShift.Checked)
					{
						menmValue |= Keys.Shift;
					}
				}
			}
		}

		private Keys menmPropertyValue = Keys.None;

		private WebUITypeEditorHandler mobjHandler = null;

		/// 
		/// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
		/// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
		/// <param name="objValue">The object to edit.</param>
		/// <param name="objHandler">The obj handler.</param>
		public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
		{
			ShortcutKeysUI shortcutKeysUI = new ShortcutKeysUI();
			shortcutKeysUI.ShortcutKeys = (Keys)GetEditorValueFromPropertyValue(objValue);
			shortcutKeysUI.Closed += objShortcutKeysUI_Closed;
			menmPropertyValue = shortcutKeysUI.ShortcutKeys;
			mobjHandler = objHandler;
			if (objProvider.GetService(typeof(IWebUIEditorService)) is IWebUIEditorService webUIEditorService)
			{
				webUIEditorService.ShowDropDown(shortcutKeysUI);
			}
		}

		/// 
		/// Handles the Closed event of the objShortcutKeysUI control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void objShortcutKeysUI_Closed(object sender, EventArgs e)
		{
			ShortcutKeysUI shortcutKeysUI = (ShortcutKeysUI)sender;
			if (shortcutKeysUI.IsCompleted && mobjHandler != null)
			{
				object obj = null;
				try
				{
					obj = GetPropertyValueFromEditorValue(shortcutKeysUI.ShortcutKeys);
				}
				catch (Exception objException)
				{
					OnValueChangeError(objException);
					return;
				}
				mobjHandler(obj);
			}
		}

		/// 
		/// Gets the edit style.
		/// </summary>
		/// <param name="context">The context.</param>
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}
}
