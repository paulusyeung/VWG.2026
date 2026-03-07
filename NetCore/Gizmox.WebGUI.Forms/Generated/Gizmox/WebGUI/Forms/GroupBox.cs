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
	///  Represents a Panel control.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(GroupBox), "GroupBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("GB")]
	[Skin(typeof(GroupBoxSkin))]
	public class GroupBox : Control
	{
		/// 
		/// Gets a value indicating whether is owner draw.
		/// </summary>
		/// true</c> if owner draw; otherwise, false</c>.</value>
		private bool OwnerDraw => FlatStyle != FlatStyle.System;

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}

		/// 
		/// Gets or sets the text.
		/// </summary>
		/// </value>
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				UpdateParams();
				base.Text = value;
			}
		}

		/// 
		/// Gets the control contained area offset.
		/// </summary>
		protected override PaddingValue ContainedAreaOffset
		{
			get
			{
				if (SkinFactory.GetSkin(this) is GroupBoxSkin groupBoxSkin)
				{
					return new PaddingValue(new Padding
					{
						Bottom = groupBoxSkin.BottomFrameHeight,
						Top = groupBoxSkin.TopFrameHeight,
						Left = groupBoxSkin.LeftFrameWidth,
						Right = groupBoxSkin.RightFrameWidth
					} + base.ContainedAreaOffset);
				}
				return base.ContainedAreaOffset;
			}
		}

		/// 
		/// Gets or sets the flat style.
		/// </summary>
		/// The flat style.</value>
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

		/// 
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected override Size DefaultSize => new Size(200, 100);

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Panel" /> instance.
		/// </summary>
		public GroupBox()
		{
			SetStyle(ControlStyles.ContainerControl, blnValue: true);
			SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, OwnerDraw);
			SetStyle(ControlStyles.Selectable, blnValue: false);
			TabStop = false;
		}

		/// 
		/// Gets the preferred size or the client minimum size.
		/// </summary>
		/// <param name="objProposedSize">The proposed size.</param>
		/// <param name="blnIsClientMinimumSize">if set to true</c> [BLN is client minimum size].</param>
		/// </returns>
		protected override Size GetPreferredSize(Size objProposedSize, bool blnIsClientMinimumSize)
		{
			Size preferredSize = base.GetPreferredSize(objProposedSize, blnIsClientMinimumSize);
			if (AutoSize && base.Skin is GroupBoxSkin { Padding: var padding } groupBoxSkin)
			{
				if (padding != null)
				{
					preferredSize.Width += padding.Horizontal;
					preferredSize.Height += padding.Vertical;
				}
				preferredSize.Width += groupBoxSkin.LeftFrameWidth;
				preferredSize.Width += groupBoxSkin.RightFrameWidth;
				preferredSize.Height += groupBoxSkin.TopFrameHeight;
				preferredSize.Height += groupBoxSkin.BottomFrameHeight;
			}
			return preferredSize;
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new GroupBoxRenderer(this);
		}

		/// 
		/// Indicates if to render padding attribute
		/// </summary>
		/// </returns>
		protected override bool ShouldRenderPaddingAttribute(Padding objPadding)
		{
			return PaddingValue.Empty != objPadding;
		}
	}
}
