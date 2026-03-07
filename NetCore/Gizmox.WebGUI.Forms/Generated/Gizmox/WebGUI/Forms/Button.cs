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
	/// A button control
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxItemCategory("Common Controls")]
	[ToolboxBitmap(typeof(Button), "Button_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[MetadataTag("B")]
	[Skin(typeof(ButtonSkin))]
	public class Button : ButtonBase, IButtonControl
	{
		/// 
		/// Provides a property reference to ButtonStyle property.
		/// </summary>
		private static SerializableProperty ButtonStyleProperty = SerializableProperty.Register("ButtonStyle", typeof(ButtonStyle), typeof(Button), new SerializablePropertyMetadata(ButtonStyle.Normal));

		/// 
		/// Provides a property reference to DialogResult property.
		/// </summary>
		private static SerializableProperty DialogResultProperty = SerializableProperty.Register("DialogResult", typeof(DialogResult), typeof(Button), new SerializablePropertyMetadata(DialogResult.None));

		/// 
		/// Provides a property reference to DropDownMenu property.
		/// </summary>
		private static SerializableProperty DropDownMenuProperty = SerializableProperty.Register("DropDownMenu", typeof(Menu), typeof(Button), new SerializablePropertyMetadata(null));

		/// 
		/// Defines a dropdown menu to the button
		/// </summary>
		[DefaultValue(null)]
		public Menu DropDownMenu
		{
			get
			{
				return GetValue(DropDownMenuProperty);
			}
			set
			{
				if (SetValue(DropDownMenuProperty, value))
				{
					if (value != null)
					{
						value.InternalParent = this;
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value that is returned to the parent form when the button is clicked.
		/// </summary>
		/// </value>
		[SRDescription("ButtonDialogResultDescr")]
		[DefaultValue(DialogResult.None)]
		[SRCategory("CatBehavior")]
		public DialogResult DialogResult
		{
			get
			{
				return GetValue(DialogResultProperty);
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 7))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DialogResult));
				}
				SetValue(DialogResultProperty, value);
			}
		}

		/// 
		/// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
		/// </summary>
		[Localizable(true)]
		[SRDescription("ControlAutoSizeModeDescr")]
		[SRCategory("CatLayout")]
		[DefaultValue(AutoSizeMode.GrowOnly)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override AutoSizeMode AutoSizeMode
		{
			get
			{
				return base.AutoSizeMode;
			}
			set
			{
				base.AutoSizeMode = value;
			}
		}

		/// 
		/// Gets or sets the button style.
		/// </summary>
		/// </value>
		[DefaultValue(ButtonStyle.Normal)]
		public ButtonStyle ButtonStyle
		{
			get
			{
				return GetValue(ButtonStyleProperty);
			}
			set
			{
				if (SetValue(ButtonStyleProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the ClickOnce property.
		/// </summary>
		/// The key down filter.</value>
		[DefaultValue(false)]
		[SRDescription("ControlClickOnceDescr")]
		[SRCategory("CatBehavior")]
		public bool ClickOnce
		{
			get
			{
				return GetState(ComponentState.ClickOnce);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.ClickOnce, value))
				{
					Update();
				}
			}
		}

		/// 
		///
		/// </summary>
		protected override Size DefaultSize => new Size(75, 23);

		/// 
		/// Gets or sets the border style.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
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

		/// 
		/// Gets or sets the border color.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override BorderColor BorderColor
		{
			get
			{
				return base.BorderColor;
			}
			set
			{
				base.BorderColor = value;
			}
		}

		/// 
		/// Gets or sets the width of the border.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override BorderWidth BorderWidth
		{
			get
			{
				return base.BorderWidth;
			}
			set
			{
				base.BorderWidth = value;
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Button" /> instance.
		/// </summary>
		public Button()
		{
			SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, blnValue: false);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (DropDownMenu != null)
			{
				criticalEventsData.Set("CL");
			}
			else if (DialogResult != DialogResult.None)
			{
				criticalEventsData.Set("CL");
			}
			return criticalEventsData;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			if (objEvent.Type == "Click")
			{
				if (ClickOnce)
				{
					SetEnabledInternal(blnValue: false);
				}
				Menu dropDownMenu = DropDownMenu;
				if (dropDownMenu != null)
				{
					MouseButtons eventButtonsValue = GetEventButtonsValue(objEvent, MouseButtons.Left);
					if (eventButtonsValue == MouseButtons.Left)
					{
						dropDownMenu.Show(this, Point.Empty, DialogAlignment.Below);
					}
				}
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (DropDownMenu != null)
			{
				objWriter.WriteAttributeString("DD", "1");
			}
			if (ClickOnce)
			{
				objWriter.WriteAttributeString("CL1", "1");
			}
		}

		/// 
		/// Renders the back color attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderBackColorAttribute(IAttributeWriter objWriter, Color objBackColor)
		{
			if (!base.UseVisualStyleBackColor)
			{
				base.RenderBackColorAttribute(objWriter, objBackColor);
			}
		}

		/// 
		///
		/// </summary>
		/// </returns>
		public override string ToString()
		{
			string text = base.ToString();
			return text + ", Text: " + Text;
		}

		/// 
		/// Retrieves the size of a rectangular area into which a control can be fitted.
		/// </summary>
		/// <param name="objProposedSize">The custom-sized area for a control.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			Size preferredSize = base.GetPreferredSize(objProposedSize);
			if (AutoSize)
			{
				if (base.Skin is ButtonSkin { Padding: var padding } buttonSkin)
				{
					if (padding != null)
					{
						preferredSize.Width += padding.Horizontal;
						preferredSize.Height += padding.Vertical;
					}
					preferredSize.Width += buttonSkin.LeftFrameWidth;
					preferredSize.Width += buttonSkin.RightFrameWidth;
					preferredSize.Height += buttonSkin.TopFrameHeight;
					preferredSize.Height += buttonSkin.BottomFrameHeight;
				}
				_ = base.ImageSize;
				if (true && (base.Image != null || base.ImageIndex != -1 || base.ImageKey != string.Empty))
				{
					switch (base.TextImageRelation)
					{
					case TextImageRelation.ImageAboveText:
					case TextImageRelation.TextAboveImage:
						preferredSize.Height += base.ImageSize.Height;
						preferredSize.Width = Math.Max(base.ImageSize.Width, preferredSize.Width);
						break;
					case TextImageRelation.ImageBeforeText:
					case TextImageRelation.TextBeforeImage:
						preferredSize.Width += base.ImageSize.Width;
						preferredSize.Height = Math.Max(base.ImageSize.Height, preferredSize.Height);
						break;
					case TextImageRelation.Overlay:
						preferredSize.Width = Math.Max(base.ImageSize.Width, preferredSize.Width);
						preferredSize.Height = Math.Max(base.ImageSize.Height, preferredSize.Height);
						break;
					}
				}
			}
			return preferredSize;
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new ButtonRenderer(this);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
		/// event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnClick(EventArgs objEventArgs)
		{
			DialogResult dialogResult = DialogResult;
			Form form = Form;
			if (form != null)
			{
				form.DialogResult = dialogResult;
			}
			base.OnClick(objEventArgs);
			if (form != null && (form.DialogType == DialogTypes.ModalWindow || form.DialogType == DialogTypes.PopupWindow) && form.DialogResult != DialogResult.None)
			{
				form.Close();
			}
		}

		/// 
		/// Performs the click.
		/// </summary>
		public void PerformClick()
		{
			OnClick(EventArgs.Empty);
		}

		/// 
		/// Notifies the default.
		/// </summary>
		/// <param name="value">Value.</param>
		public void NotifyDefault(bool blnValue)
		{
		}
	}
}
