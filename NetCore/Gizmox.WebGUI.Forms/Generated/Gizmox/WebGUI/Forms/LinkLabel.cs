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
	/// Represents a Gizmox.WebGUI.Forms label control that can display hyperlinks.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(LinkLabel), "LinkLabel_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[SRDescription("DescriptionLinkLabel")]
	[DefaultEvent("LinkClicked")]
	[ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("LL")]
	[Skin(typeof(LinkLabelSkin))]
	public class LinkLabel : Label, IButtonControl
	{
		/// 
		/// Represents a link within a <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> control.
		/// </summary>
		[Serializable]
		public class Link : ILink
		{
			private string mstrUrl = "";

			private object mobjLinkData = null;

			/// 
			/// Gets or sets the URL.
			/// </summary>
			/// The URL.</value>
			internal string Url
			{
				get
				{
					return mstrUrl;
				}
				set
				{
					mstrUrl = value;
				}
			}

			/// 
			/// Gets the URL.
			/// </summary>
			/// The URL.</value>
			string ILink.Url => mstrUrl;

			/// 
			/// Gets or sets a value indicating whether the link is enabled.
			/// </summary>
			/// true if the link is enabled; otherwise, false.</returns>
			[DefaultValue(true)]
			public bool Enabled
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
			/// Gets or sets the number of characters in the link text.
			/// </summary>
			/// The number of characters, including spaces, in the link text.</returns>
			public int Length
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			/// 
			/// Gets or sets the data associated with the link.
			/// </summary>
			/// An <see cref="T:System.Object"></see> representing the data associated with the link.</returns>
			[DefaultValue(null)]
			public object LinkData
			{
				get
				{
					return mobjLinkData;
				}
				set
				{
					mobjLinkData = value;
				}
			}

			/// 
			/// Gets or sets the starting location of the link within the text of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see>.
			/// </summary>
			/// The location within the text of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> control where the link starts.</returns>
			public int Start
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			/// 
			/// Gets or sets a value indicating whether the user has visited the link.
			/// </summary>
			/// true if the link has been visited; otherwise, false.</returns>
			[DefaultValue(true)]
			public bool Visited
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
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> class.
			/// </summary>
			internal Link(string strUrl)
			{
				mstrUrl = strUrl;
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> class.
			/// </summary>
			internal Link(LinkLabel objLinkLabel, string strUrl)
				: this(strUrl)
			{
			}

			/// 
			/// Opens the specified link.
			/// </summary>
			/// <param name="objLink">The link.</param>
			public static void Open(Link objLink)
			{
				Global.Context.OpenLink(objLink);
			}
		}

		/// 
		/// Provides a property reference to Link property.
		/// </summary>
		private static SerializableProperty LinkProperty = SerializableProperty.Register("Link", typeof(Link), typeof(LinkLabel));

		/// 
		/// Provides a property reference to ClientMode property.
		/// </summary>
		private static SerializableProperty ClientModeProperty = SerializableProperty.Register("ClientMode", typeof(bool), typeof(LinkLabel));

		/// 
		/// Provides a property reference to DialogResult property.
		/// </summary>
		private static SerializableProperty DialogResultProperty = SerializableProperty.Register("DialogResult", typeof(DialogResult), typeof(LinkLabel));

		/// 
		///
		/// </summary>
		private static SerializableProperty LinkColorProperty = SerializableProperty.Register("LinkColor", typeof(Color), typeof(LinkLabel));

		/// 
		/// Gets or sets the color of the link.
		/// </summary>
		/// The color of the link.</value>
		[SRDescription("LinkLabelLinkColorDescr")]
		[SRCategory("CatAppearance")]
		public Color LinkColor
		{
			get
			{
				Color value = GetValue(LinkColorProperty, Color.Empty);
				if (value != Color.Empty)
				{
					return value;
				}
				if (!(base.Skin is LinkLabelSkin { LinkColor: var linkColor }))
				{
					return Color.Blue;
				}
				return linkColor;
			}
			set
			{
				if (LinkColor != value)
				{
					if (value == Color.Empty)
					{
						RemoveValue(LinkColorProperty);
					}
					else
					{
						SetValue(LinkColorProperty, value);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the URL.
		/// </summary>
		/// The URL.</value>
		[DefaultValue("")]
		public string Url
		{
			get
			{
				return InternalLink?.Url;
			}
			set
			{
				InternalLink = new Link(value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [client mode].
		/// </summary>
		/// true</c> if [client mode]; otherwise, false</c>.</value>
		[SRDescription("LinkLabelClientModeDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool ClientMode
		{
			get
			{
				return GetValue(ClientModeProperty, objDefault: false);
			}
			set
			{
				if (ClientMode != value)
				{
					if (!value)
					{
						RemoveValue(ClientModeProperty);
					}
					else
					{
						SetValue(ClientModeProperty, value);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the internal link.
		/// </summary>
		/// The internal link.</value>
		private Link InternalLink
		{
			get
			{
				return GetValue(LinkProperty, new Link(""));
			}
			set
			{
				if (InternalLink == value)
				{
					return;
				}
				Link internalLink = InternalLink;
				SetValue(LinkProperty, value);
				if (ClientMode)
				{
					if (internalLink.Url != InternalLink.Url)
					{
						UpdateParams(AttributeType.Control, blnUseClientUpdateHandler: false);
					}
				}
				else if ((internalLink.Url == "" && InternalLink.Url != "") || (internalLink.Url != "" && InternalLink.Url == ""))
				{
					UpdateParams(AttributeType.Events, blnUseClientUpdateHandler: false);
				}
			}
		}

		/// 
		/// Gets or sets the value returned to the parent form when the
		/// button is clicked.
		/// </summary>
		/// </value>
		DialogResult IButtonControl.DialogResult
		{
			get
			{
				return GetValue(DialogResultProperty, DialogResult.None);
			}
			set
			{
				if (value == DialogResult.None)
				{
					RemoveValue(DialogResultProperty);
				}
				else
				{
					SetValue(DialogResultProperty, value);
				}
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[RefreshProperties(RefreshProperties.Repaint)]
		public override Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// 
		/// Gets a value indicating whether [supports key navigation].
		/// </summary>
		/// 
		/// true</c> if [supports key navigation]; otherwise, false</c>.
		/// </value>
		protected override bool SupportsKeyNavigation => false;

		/// 
		/// Occurs when a link is clicked within the control.
		/// </summary>
		public event LinkLabelLinkClickedEventHandler LinkClicked;

		/// 
		/// Resets the color of the link.
		/// </summary>
		private void ResetLinkColor()
		{
			LinkLabelSkin linkLabelSkin = base.Skin as LinkLabelSkin;
			LinkColor = Color.Empty;
		}

		/// 
		/// Initializes a new default instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
		/// </summary>
		public LinkLabel()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.StandardClick | ControlStyles.UserPaint, blnValue: true);
			base.TabStop = true;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
		/// </summary>
		/// <param name="strText">Label text.</param>
		public LinkLabel(string strText)
			: base(strText)
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.StandardClick | ControlStyles.UserPaint, blnValue: true);
			base.TabStop = true;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
		/// </summary>
		/// <param name="strText">Label text.</param>
		/// <param name="strUrl">Label url.</param>
		public LinkLabel(string strText, string strUrl)
			: base(strText)
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.StandardClick | ControlStyles.UserPaint, blnValue: true);
			InternalLink = new Link(strUrl);
			base.TabStop = true;
		}

		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderUrlAttribute(objWriter, blnForceRender: false);
		}

		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderUrlAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the URL attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderUrlAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (ClientMode && (!string.IsNullOrEmpty(Url) || blnForceRender))
			{
				objWriter.WriteAttributeString("VLB", Url);
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (this.LinkClicked != null || (!ClientMode && !string.IsNullOrEmpty(Url)))
			{
				criticalEventsData.Set("CL");
			}
			return criticalEventsData;
		}

		/// 
		/// Retrieves the size of a rectangular area into which a control can be fitted.
		/// </summary>
		/// <param name="objProposedSize">The custom-sized area for a control.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			Size result = base.GetPreferredSize(objProposedSize);
			if (base.AutoSize)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int intWidth = -1;
				if (base.Skin is LinkLabelSkin { ContentStyle: { } contentStyle })
				{
					num = contentStyle.Padding.Horizontal;
					num2 = contentStyle.Margin.Horizontal;
					num3 = contentStyle.Padding.Vertical;
					num4 = contentStyle.Margin.Vertical;
				}
				Size maximumSize = MaximumSize;
				if (!maximumSize.IsEmpty)
				{
					intWidth = maximumSize.Width - num - num2;
				}
				result = CommonUtils.GetStringMeasurements(Text, Font, intWidth);
				result.Width += num + num2;
				result.Height += num3 + num4;
			}
			return result;
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
		/// event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnClick(EventArgs objEventArgs)
		{
			base.OnClick(objEventArgs);
			Link internalLink = InternalLink;
			if (!ClientMode && internalLink != null && !string.IsNullOrEmpty(internalLink.Url))
			{
				Link.Open(internalLink);
			}
			OnLinkClicked(new LinkLabelLinkClickedEventArgs(internalLink));
		}

		/// 
		/// Invokes LinkClicked event.
		/// </summary>
		/// <param name="e">Event arguments</param>
		protected virtual void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
		{
			this.LinkClicked?.Invoke(this, e);
		}

		/// 
		/// Renders the color of the fore.
		/// </summary>
		/// </returns>
		protected override Color GetForeColor()
		{
			return LinkColor;
		}

		/// 
		/// Shoulds the serialize URL.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeUrl()
		{
			Link internalLink = InternalLink;
			return internalLink != null && !string.IsNullOrEmpty(internalLink.Url);
		}

		/// 
		/// Performs the click.
		/// </summary>
		void IButtonControl.PerformClick()
		{
			OnClick(EventArgs.Empty);
		}

		/// 
		/// Notifies the default.
		/// </summary>
		/// <param name="value">Value.</param>
		void IButtonControl.NotifyDefault(bool blnValue)
		{
		}
	}
}
