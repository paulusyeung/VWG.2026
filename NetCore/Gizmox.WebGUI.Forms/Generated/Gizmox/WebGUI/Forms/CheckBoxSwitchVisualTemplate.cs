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
	///
	/// </summary>
	[Serializable]
	[VisualTemplate(typeof(CheckBox), "Visually adjusts the CheckBoxSwitch control to an appearance more suitable for the customized device.")]
	[Skin(typeof(CheckBoxSwitchVisualTemplateSkin))]
	public class CheckBoxSwitchVisualTemplate : VisualTemplate
	{
		private string mstrUnCheckedText = string.Empty;

		private string mstrCheckedText = string.Empty;

		private bool mblnShowCheckBoxLabel = true;

		private int mintSwitchWidth = 35;

		private CheckBoxSwitchVisualTemplateSwitchSizing menmCheckBoxSwitchVisualTemplateSwitchSizing = CheckBoxSwitchVisualTemplateSwitchSizing.Percent;

		/// 
		/// Gets or sets the switch sizing.
		/// </summary>
		/// 
		/// The switch sizing.
		/// </value>
		public CheckBoxSwitchVisualTemplateSwitchSizing SwitchSizing
		{
			get
			{
				return menmCheckBoxSwitchVisualTemplateSwitchSizing;
			}
			set
			{
				menmCheckBoxSwitchVisualTemplateSwitchSizing = value;
			}
		}

		/// 
		/// Gets or sets the width of the switch.
		/// </summary>
		/// 
		/// The width of the switch.
		/// </value>
		[Description("Set switch width when displaying label.")]
		public int SwitchWidth
		{
			get
			{
				return mintSwitchWidth;
			}
			set
			{
				mintSwitchWidth = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether show the check box label.
		/// </summary>
		/// 
		///   true</c> if show check box label; otherwise, false</c>.
		/// </value>
		public bool ShowCheckBoxLabel
		{
			get
			{
				return mblnShowCheckBoxLabel;
			}
			set
			{
				mblnShowCheckBoxLabel = value;
			}
		}

		/// 
		/// Gets or sets the un checked text.
		/// </summary>
		/// 
		/// The un checked text.
		/// </value>
		public string UnCheckedText
		{
			get
			{
				return mstrUnCheckedText;
			}
			set
			{
				mstrUnCheckedText = value;
			}
		}

		/// 
		/// Gets or sets the checked text.
		/// </summary>
		/// 
		/// The checked text.
		/// </value>
		public string CheckedText
		{
			get
			{
				return mstrCheckedText;
			}
			set
			{
				mstrCheckedText = value;
			}
		}

		/// 
		/// Gets the name of the visual template.
		/// </summary>
		/// 
		/// The name of the visual template.
		/// </value>
		public override string VisualTemplateName => "CheckBoxSwitchVisualTemplate";

		/// 
		/// Gets the visualizer image.
		/// </summary>
		/// 
		/// The visualizer image.
		/// </value>
		public override ResourceHandle VisualizerImage => new SkinResourceHandle(typeof(CheckBoxSwitchVisualTemplateSkin), "CheckBoxSwitch.png");

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CheckBoxSwitchVisualTemplate" /> class.
		/// </summary>
		public CheckBoxSwitchVisualTemplate()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CheckBoxSwitchVisualTemplate" /> class.
		/// </summary>
		/// <param name="blnShowCheckBoxLabel">if set to true</c> [BLN show check box label].</param>
		/// <param name="intSwitchWidth">Width of the int switch.</param>
		/// <param name="enmCheckBoxSwitchVisualTemplateSwitchSizing">The enm check box switch visual template switch sizing.</param>
		/// <param name="strUnCheckedText">The STR un checked text.</param>
		/// <param name="strCheckedText">The STR checked text.</param>
		public CheckBoxSwitchVisualTemplate(bool blnShowCheckBoxLabel, int intSwitchWidth, CheckBoxSwitchVisualTemplateSwitchSizing enmCheckBoxSwitchVisualTemplateSwitchSizing, string strUnCheckedText, string strCheckedText)
		{
			mblnShowCheckBoxLabel = blnShowCheckBoxLabel;
			mintSwitchWidth = intSwitchWidth;
			menmCheckBoxSwitchVisualTemplateSwitchSizing = enmCheckBoxSwitchVisualTemplateSwitchSizing;
			mstrUnCheckedText = strUnCheckedText;
			mstrCheckedText = strCheckedText;
		}

		/// 
		/// Gets the constroctor arguments. (For TypeConverter)
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override object[] GetConsturctorArguments()
		{
			return new object[5] { mblnShowCheckBoxLabel, mintSwitchWidth, menmCheckBoxSwitchVisualTemplateSwitchSizing, mstrUnCheckedText, mstrCheckedText };
		}

		/// 
		/// Gets the constroctor types. (For TypeConverter)
		/// </summary>
		public override Type[] GetConstructorTypes()
		{
			return new Type[5]
			{
				typeof(bool),
				typeof(int),
				typeof(CheckBoxSwitchVisualTemplateSwitchSizing),
				typeof(string),
				typeof(string)
			};
		}

		/// 
		/// Converts to string.
		/// </summary>
		/// </returns>
		internal override string ConvertToString()
		{
			return $"{base.ConvertToString()}|{mblnShowCheckBoxLabel}|{mintSwitchWidth}|{(int)menmCheckBoxSwitchVisualTemplateSwitchSizing}|{mstrUnCheckedText}|{mstrCheckedText}";
		}

		/// 
		/// Converts from string.
		/// </summary>
		/// <param name="objVisualTemplateValues">The object visual template values.</param>
		internal override void ConvertFromString(List<object> objVisualTemplateValues)
		{
			if (objVisualTemplateValues.Count == 5 && bool.TryParse(objVisualTemplateValues[0]?.ToString(), out var result) && int.TryParse(objVisualTemplateValues[1]?.ToString(), out var result2) && int.TryParse(objVisualTemplateValues[2]?.ToString(), out var result3))
			{
				mblnShowCheckBoxLabel = result;
				mintSwitchWidth = result2;
				if (Enum.IsDefined(typeof(CheckBoxSwitchVisualTemplateSwitchSizing), result3))
				{
					menmCheckBoxSwitchVisualTemplateSwitchSizing = (CheckBoxSwitchVisualTemplateSwitchSizing)result3;
				}
				mstrUnCheckedText = objVisualTemplateValues[3]?.ToString();
				mstrCheckedText = objVisualTemplateValues[4]?.ToString();
			}
		}

		/// 
		/// Renders the specified object context.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		public override void Render(IContext objContext, IAttributeWriter objWriter)
		{
			base.Render(objContext, objWriter);
			if (!string.IsNullOrEmpty(mstrCheckedText))
			{
				objWriter.WriteAttributeString("VIS_CH_CT", mstrCheckedText);
			}
			if (!string.IsNullOrEmpty(mstrUnCheckedText))
			{
				objWriter.WriteAttributeString("VIS_CH_UT", mstrUnCheckedText);
			}
			objWriter.WriteAttributeString("VIS_CH_SL", ShowCheckBoxLabel ? "1" : "0");
			if (ShowCheckBoxLabel)
			{
				objWriter.WriteAttributeString("VIS_CH_SW", mintSwitchWidth);
				objWriter.WriteAttributeString("VIS_CHSS", (int)menmCheckBoxSwitchVisualTemplateSwitchSizing);
			}
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return "CheckBox Switch Appearance";
		}
	}
}
