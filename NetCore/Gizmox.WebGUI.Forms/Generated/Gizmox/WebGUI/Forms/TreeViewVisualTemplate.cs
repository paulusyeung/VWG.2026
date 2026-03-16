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
	[VisualTemplate(typeof(TreeView), "Visually adjusts the TreeView control to an appearance more suitable for the customized device.")]
	[Skin(typeof(TreeViewVisualTemplateSkin))]
	public class TreeViewVisualTemplate : VisualTemplate
	{
		private bool mblnUseTreeViewOriginalFont;

		private int mintItemHeight = 0;

		private int mintBackButtonHeight = 0;

		private int? mintCalculatedItemHeight;

		private string mstrDefaultBackButtonText = "Back";

		/// 
		/// Gets the name of the visual template.
		/// </summary>
		/// 
		/// The name of the visual template.
		/// </value>
		public override string VisualTemplateName => "TreeViewVisualTemplateWithPaging";

		/// 
		/// Gets the visualizer image.
		/// </summary>
		/// 
		/// The visualizer image.
		/// </value>
		public override ResourceHandle VisualizerImage => new SkinResourceHandle(typeof(TreeViewVisualTemplateSkin), "TreeViewVisualTemplate_Paging.png");

		/// 
		/// Gets or sets a value indicating whether [use TreeView font].
		/// </summary>
		/// 
		///   true</c> if [use TreeView font]; otherwise, false</c>.
		/// </value>
		[DisplayName("Use Original Font")]
		[Description("This will set the font of the treeview as the original font, avoiding the visualtemplate style.")]
		public bool UseTreeViewOriginalFont
		{
			get
			{
				return mblnUseTreeViewOriginalFont;
			}
			set
			{
				mblnUseTreeViewOriginalFont = value;
			}
		}

		/// 
		/// Gets or sets the height of the item.
		/// </summary>
		/// 
		/// The height of the item.
		/// </value>        
		public int ItemHeight
		{
			get
			{
				return mintItemHeight;
			}
			set
			{
				mintItemHeight = value;
			}
		}

		/// 
		/// Gets or sets the height of the back button.
		/// </summary>
		/// 
		/// The height of the back button.
		/// </value>
		public int BackButtonHeight
		{
			get
			{
				return mintBackButtonHeight;
			}
			set
			{
				mintBackButtonHeight = value;
			}
		}

		/// 
		/// Gets or sets the default back button text.
		/// </summary>
		/// 
		/// The default back button text.
		/// </value>
		public string DefaultBackButtonText
		{
			get
			{
				return mstrDefaultBackButtonText;
			}
			set
			{
				mstrDefaultBackButtonText = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TreeViewVisualTemplate" /> class.
		/// </summary>
		public TreeViewVisualTemplate()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TreeViewVisualTemplate" /> class.
		/// </summary>
		/// <param name="blnUseTreeViewOriginalFont">if set to true</c> [BLN use TreeView original font].</param>
		public TreeViewVisualTemplate(bool blnUseTreeViewOriginalFont, int intItemHeight, int intBackButtonHeight, string strDefaultBackButtonText)
		{
			mblnUseTreeViewOriginalFont = blnUseTreeViewOriginalFont;
			mintItemHeight = intItemHeight;
			mintBackButtonHeight = intBackButtonHeight;
			mstrDefaultBackButtonText = strDefaultBackButtonText;
		}

		/// 
		/// Renders the specified object context.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		public override void Render(IContext objContext, IAttributeWriter objWriter)
		{
			base.Render(objContext, objWriter);
			objWriter.WriteAttributeString("VIS_OF", mblnUseTreeViewOriginalFont ? "1" : "0");
			if (mintItemHeight > 0)
			{
				objWriter.WriteAttributeString("VIS_TV_IH", mintItemHeight);
			}
			else
			{
				objWriter.WriteAttributeString("VIS_TV_IH", GetCalculatedNodeHeight());
			}
			if (mintBackButtonHeight > 0)
			{
				objWriter.WriteAttributeString("VIS_TV_BBH", mintBackButtonHeight);
			}
			else
			{
				objWriter.WriteAttributeString("VIS_TV_BBH", GetCalculatedNodeHeight());
			}
			objWriter.WriteAttributeString("VIS_TV_BBT", string.IsNullOrEmpty(mstrDefaultBackButtonText) ? "" : mstrDefaultBackButtonText);
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return "Paged TreeView";
		}

		/// 
		/// Gets the calculated height of the node.
		/// </summary>
		/// </returns>
		private int GetCalculatedNodeHeight()
		{
			if (!mintCalculatedItemHeight.HasValue)
			{
				TreeViewVisualTemplateSkin treeViewVisualTemplateSkin = SkinFactory.GetSkin(this) as TreeViewVisualTemplateSkin;
				int imageHeight = treeViewVisualTemplateSkin.GetImageHeight(treeViewVisualTemplateSkin.TreeViewVisualTemplateNextLTR, 0);
				int val = 0;
				int num = 4;
				if (treeViewVisualTemplateSkin.TreeNodeNormalStyle.Font != null)
				{
					Bitmap image = new Bitmap(1, 1);
					Graphics graphics = Graphics.FromImage(image);
					val = (int)Math.Ceiling(treeViewVisualTemplateSkin.TreeNodeNormalStyle.Font.GetHeight(graphics)) + num;
				}
				mintCalculatedItemHeight = Math.Max(Math.Max(imageHeight, val), treeViewVisualTemplateSkin.TreeViewNodeHeight);
			}
			return mintCalculatedItemHeight.Value;
		}

		/// 
		/// Converts to string.
		/// </summary>
		/// </returns>
		internal override string ConvertToString()
		{
			string text = (mblnUseTreeViewOriginalFont ? "1" : "0");
			return $"{base.ConvertToString()}|{text}|{mintItemHeight}|{mintBackButtonHeight}|{mstrDefaultBackButtonText}";
		}

		/// 
		/// Converts from string.
		/// </summary>
		/// <param name="objVisualTemplateValues">The object visual template values.</param>
		internal override void ConvertFromString(List<object> objVisualTemplateValues)
		{
			if (objVisualTemplateValues.Count == 4)
			{
				string text = objVisualTemplateValues[0] as string;
				mblnUseTreeViewOriginalFont = !string.IsNullOrEmpty(text) && text == "1";
				int.TryParse(objVisualTemplateValues[1] as string, out mintItemHeight);
				int.TryParse(objVisualTemplateValues[2] as string, out mintBackButtonHeight);
				mstrDefaultBackButtonText = objVisualTemplateValues[3] as string;
			}
		}

		/// 
		/// Gets the constroctor arguments. (For TypeContevert)
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override object[] GetConsturctorArguments()
		{
			return new object[4] { mblnUseTreeViewOriginalFont, mintItemHeight, mintBackButtonHeight, mstrDefaultBackButtonText };
		}

		/// 
		/// Gets the constroctor types. (For TypeContevert)
		/// </summary>
		public override Type[] GetConstructorTypes()
		{
			return new Type[4]
			{
				typeof(bool),
				typeof(int),
				typeof(int),
				typeof(string)
			};
		}
	}
}
