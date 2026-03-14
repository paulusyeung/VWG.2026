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
	/// Represents a panel that dynamically lays out its contents horizontally or vertically.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(FlowLayoutPanel), "FlowLayoutPanel_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItemCategory("Containers")]
	[MetadataTag("FL")]
	[Skin(typeof(FlowLayoutPanelSkin))]
	[ProxyComponent(typeof(ProxyFlowLayoutPanel))]
	public class FlowLayoutPanel : Panel
	{
		/// 
		/// Provides a property reference to WrapContents property.
		/// </summary>
		private static SerializableProperty WrapContentsProperty = SerializableProperty.Register("WrapContents", typeof(bool), typeof(FlowLayoutPanel), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to FlowDirection property.
		/// </summary>
		private static SerializableProperty FlowDirectionProperty = SerializableProperty.Register("FlowDirection", typeof(FlowDirection), typeof(FlowLayoutPanel), new SerializablePropertyMetadata(FlowDirection.LeftToRight));

		/// 
		/// Gets a value indicating whether to reverse control rendering.
		/// </summary>
		/// 
		/// 	true</c> if to reverse control rendering; otherwise, false</c>.
		/// </value>
		protected override bool ReverseControls => true;

		/// 
		/// Gets a value indicating whether [use minimum client size].
		/// </summary>
		/// 
		/// 	true</c> if [use minimum client size]; otherwise, false</c>.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected override bool ShouldRenderMinimumClientSize => false;

		/// 
		/// Gets or sets a value indicating the flow direction of the <see cref="T:Gizmox.WebGUI.Forms.FlowLayoutPanel"></see> control.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.FlowDirection"></see> values indicating the direction of consecutive placement of controls in the panel. The default is <see cref="F:Gizmox.WebGUI.Forms.FlowDirection.LeftToRight"></see>.</returns>
		[DefaultValue(FlowDirection.LeftToRight)]
		[SRCategory("CatLayout")]
		[Localizable(true)]
		[SRDescription("FlowPanelFlowDirectionDescr")]
		public FlowDirection FlowDirection
		{
			get
			{
				return GetValue(FlowDirectionProperty);
			}
			set
			{
				if (SetValue(FlowDirectionProperty, value))
				{
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
					FireObservableItemPropertyChanged("FlowDirection");
				}
			}
		}

		/// 
		/// Gets a value indicating whether [support child margins].
		/// </summary>
		/// 
		///   true</c> if [support child margins]; otherwise, false</c>.
		/// </value>
		protected override bool SupportChildMargins => true;

		/// 
		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.FlowLayoutPanel"></see> control should wrap its contents or let the contents be clipped.
		/// </summary>
		/// true if the contents should be wrapped; otherwise, false. The default is true.</returns>
		[DefaultValue(true)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public bool WrapContents
		{
			get
			{
				return GetValue(WrapContentsProperty);
			}
			set
			{
				if (SetValue(WrapContentsProperty, value))
				{
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					FireObservableItemPropertyChanged("WrapContents");
					Update();
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FlowLayoutPanel"></see> class.
		/// </summary>
		public FlowLayoutPanel()
		{
		}

		/// 
		/// Layout the internal controls to reflect parent changes
		/// </summary>
		/// <param name="objEventArgs">The layout arguments.</param>
		/// <param name="objNewSize">The new parent size.</param>
		/// <param name="objOldSize">The old parent size.</param>
		protected override void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
		{
		}

		/// 
		/// Gets the preferred size core.
		/// </summary>
		/// <param name="objProposedSize">The size proposed.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			Size size = new Size(base.Width, base.Height);
			if (AutoSize)
			{
				switch (Dock)
				{
				case DockStyle.None:
					size = new Size(int.MaxValue, int.MaxValue);
					break;
				case DockStyle.Top:
				case DockStyle.Bottom:
					size = new Size(base.Width, int.MaxValue);
					break;
				case DockStyle.Right:
				case DockStyle.Left:
					size = new Size(int.MaxValue, base.Height);
					break;
				case DockStyle.Fill:
					size = new Size(base.Width, base.Height);
					break;
				}
				if (MaximumSize.Width > 0 && size.Width > MaximumSize.Width)
				{
					size.Width = Math.Max(MaximumSize.Width, base.Width);
				}
				if (MaximumSize.Height > 0 && size.Height > MaximumSize.Height)
				{
					size.Height = Math.Max(MaximumSize.Height, base.Height);
				}
			}
			Point point = new Point(0, 0);
			int num = 0;
			int num2 = 0;
			FlowDirection flowDirection = FlowDirection;
			foreach (Control control in base.Controls)
			{
				if (!control.Visible)
				{
					continue;
				}
				Padding margin = control.Margin;
				switch (flowDirection)
				{
				case FlowDirection.TopDown:
				case FlowDirection.BottomUp:
					if (point.Y == 0)
					{
						point.Y = control.Height + margin.Vertical;
						num2 = control.Height + margin.Vertical;
						num = control.Width + margin.Horizontal;
					}
					else if (point.Y + control.Height + margin.Vertical > size.Height)
					{
						point.X = num;
						point.Y = control.Height + margin.Vertical;
						num2 = Math.Max(num2, control.Height + margin.Vertical);
						num += control.Width + margin.Horizontal;
					}
					else
					{
						point.Y += control.Height + margin.Vertical;
						num2 = Math.Max(num2, point.Y);
					}
					break;
				case FlowDirection.LeftToRight:
				case FlowDirection.RightToLeft:
					if (point.X == 0)
					{
						point.X = control.Width + margin.Horizontal;
						num2 = control.Height + margin.Vertical;
						num = control.Width + margin.Horizontal;
					}
					else if (point.X + control.Width + margin.Horizontal > size.Width)
					{
						point.X = control.Width + margin.Horizontal;
						point.Y = num2;
						num2 += control.Height + margin.Vertical;
						num = Math.Max(num, control.Width + margin.Horizontal);
					}
					else
					{
						point.X += control.Width + margin.Horizontal;
						num = Math.Max(num2, point.X);
					}
					break;
				}
			}
			Padding padding = Padding;
			return new Size(num + padding.Horizontal, num2 + padding.Vertical);
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (ReverseControls)
			{
				for (int i = 0; i < base.Controls.Count; i++)
				{
					base.Controls[i]?.RenderControl(objContext, objWriter, lngRequestID);
				}
				return;
			}
			for (int num = base.Controls.Count - 1; num > -1; num--)
			{
				base.Controls[num]?.RenderControl(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Renders the attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			string strValue = (objContext.ShouldApplyMirroring ? "right" : "left");
			string strValue2 = (objContext.ShouldApplyMirroring ? "left" : "right");
			if (WrapContents)
			{
				objWriter.WriteAttributeString("WC", "1");
			}
			objWriter.WriteAttributeString("FD", Convert.ToInt32(FlowDirection).ToString());
			if ((FlowDirection & FlowDirection.RightToLeft) > (FlowDirection)0)
			{
				objWriter.WriteAttributeString("HA", strValue2);
			}
			else
			{
				objWriter.WriteAttributeString("HA", strValue);
			}
			if ((FlowDirection & FlowDirection.BottomUp) > (FlowDirection)0)
			{
				objWriter.WriteAttributeString("VA", "bottom");
			}
			else
			{
				objWriter.WriteAttributeString("VA", "top");
			}
			base.RenderAttributes(objContext, objWriter);
		}

		/// 
		/// Sets the minimum size of the client.
		/// </summary>
		/// <param name="objProposedSize">Proposed size.</param>
		protected override void SetMinimumClientSize(Size objProposedSize)
		{
		}
	}
}
