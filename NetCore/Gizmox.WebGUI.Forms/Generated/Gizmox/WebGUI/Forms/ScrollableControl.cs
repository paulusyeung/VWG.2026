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
	/// Defines a base class for controls that support auto-scrolling behavior.  
	/// </summary>
	[Serializable]
	[Skin(typeof(ScrollableControlSkin))]
	public class ScrollableControl : Control
	{
		/// 
		/// Determines the border padding for docked controls.
		/// </summary>
		[Serializable]
		[TypeConverter(typeof(DockPaddingEdgesConverter))]
		public class DockPaddingEdges
		{
			private ScrollableControl mobjOwner = null;

			internal bool IsAll => mobjOwner.Padding.All != -1;

			/// 
			/// Gets or sets the padding width for all edges of a docked control.
			/// </summary>
			/// The padding width, in pixels.</value>
			[SRDescription("PaddingAllDescr")]
			[RefreshProperties(RefreshProperties.All)]
			public int All
			{
				get
				{
					return mobjOwner.Padding.All;
				}
				set
				{
					Padding padding = mobjOwner.Padding;
					padding.All = value;
					mobjOwner.Padding = padding;
				}
			}

			/// 
			/// Gets or sets the padding width for the bottom edge of a docked control.
			/// </summary>
			/// The padding width, in pixels.</value>
			[SRDescription("PaddingBottomDescr")]
			[RefreshProperties(RefreshProperties.All)]
			public int Bottom
			{
				get
				{
					return mobjOwner.Padding.Bottom;
				}
				set
				{
					Padding padding = mobjOwner.Padding;
					padding.Bottom = value;
					mobjOwner.Padding = padding;
				}
			}

			/// 
			/// Gets or sets the padding width for the top edge of a docked control.
			/// </summary>
			/// The padding width, in pixels.</value>
			[SRDescription("PaddingTopDescr")]
			[RefreshProperties(RefreshProperties.All)]
			public int Top
			{
				get
				{
					return mobjOwner.Padding.Top;
				}
				set
				{
					Padding padding = mobjOwner.Padding;
					padding.Top = value;
					mobjOwner.Padding = padding;
				}
			}

			/// 
			/// Gets or sets the padding width for the right edge of a docked control.
			/// </summary>
			/// The padding width, in pixels.</value>
			[RefreshProperties(RefreshProperties.All)]
			[SRDescription("PaddingRightDescr")]
			public int Right
			{
				get
				{
					return mobjOwner.Padding.Right;
				}
				set
				{
					Padding padding = mobjOwner.Padding;
					padding.Right = value;
					mobjOwner.Padding = padding;
				}
			}

			/// 
			/// Gets or sets the padding width for the left edge of a docked control.
			/// </summary>
			/// The padding width, in pixels.</value>
			[RefreshProperties(RefreshProperties.All)]
			[SRDescription("PaddingLeftDescr")]
			public int Left
			{
				get
				{
					return mobjOwner.Padding.Left;
				}
				set
				{
					Padding padding = mobjOwner.Padding;
					padding.Left = value;
					mobjOwner.Padding = padding;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdges" /> class.
			/// </summary>
			/// <param name="objOwner">The owner.</param>
			internal DockPaddingEdges(ScrollableControl objOwner)
			{
				mobjOwner = objOwner;
			}

			private bool ShouldSerializeAll()
			{
				return IsAll && All != 0;
			}

			private bool ShouldSerializeBottom()
			{
				return !IsAll && Bottom != 0;
			}

			private bool ShouldSerializeLeft()
			{
				return !IsAll && Left != 0;
			}

			private bool ShouldSerializeRight()
			{
				return !IsAll && Right != 0;
			}

			private bool ShouldSerializeTop()
			{
				return !IsAll && Top != 0;
			}

			/// 
			/// Returns an empty string.
			/// </summary>
			/// An empty string.</returns>
			public override string ToString()
			{
				return "";
			}
		}

		/// 
		/// DockPaddingEdgesConverter class.
		/// </summary>
		[Serializable]
		public class DockPaddingEdgesConverter : TypeConverter
		{
			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdgesConverter" /> class.
			/// </summary>
			public DockPaddingEdgesConverter()
			{
			}

			/// 
			/// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
			/// </summary>
			/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
			/// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
			/// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
			/// 
			/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
			/// </returns>
			public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
			{
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(DockPaddingEdges), arrAttributes);
				string[] names = new string[5] { "All", "Left", "Top", "Right", "Bottom" };
				return properties.Sort(names);
			}

			/// 
			/// Returns whether this object supports properties, using the specified context.
			/// </summary>
			/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
			/// 
			/// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
			/// </returns>
			public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
			{
				return true;
			}
		}

		/// 
		/// Provides a property reference to DockPadding property.
		/// </summary>
		private static SerializableProperty DockPaddingProperty = SerializableProperty.Register("DockPadding", typeof(DockPaddingEdges), typeof(ScrollableControl), new SerializablePropertyMetadata(null));

		/// 
		/// The client minimum height of the control.
		/// </summary>
		/// The client minimum height of the control.</value>
		[NonSerialized]
		private int mintMinimumClientHeight = -1;

		/// 
		/// The render client minimum of the control.
		/// </summary>
		/// The client minimum width of the control.</value>
		[NonSerialized]
		private int mintMinimumClientWidth = -1;

		private ScrollerType menmScrollerType;

		/// 
		/// Gets or sets the size of the auto scroll min.
		/// </summary>
		/// 
		/// The size of the auto scroll min.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size AutoScrollMinSize
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether the vertical scroll bar is visible.
		/// </summary>
		/// true if the vertical scroll bar is visible; otherwise, false.</value>
		[DefaultValue(true)]
		protected bool VScroll
		{
			get
			{
				return GetState(ControlState.VScroll);
			}
			set
			{
				if (SetStateWithCheck(ControlState.VScroll, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether the horizontal scroll bar is visible.
		/// </summary>
		/// true if the horizontal scroll bar is visible; otherwise, false.</value>
		[DefaultValue(true)]
		protected bool HScroll
		{
			get
			{
				return GetState(ControlState.HScroll);
			}
			set
			{
				if (SetStateWithCheck(ControlState.HScroll, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
		/// </summary>
		/// true if the container enables auto-scrolling; otherwise, false. The default value is false.</value>
		[SRCategory("CatLayout")]
		[SRDescription("FormAutoScrollDescr")]
		[DefaultValue(false)]
		[Localizable(true)]
		[ProxyBrowsable(true)]
		public virtual bool AutoScroll
		{
			get
			{
				return GetState(ControlState.AutoScroll);
			}
			set
			{
				if (SetStateWithCheck(ControlState.AutoScroll, value))
				{
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the type of the scroller.
		/// </summary>
		/// 
		/// The type of the scroller.
		/// </value>
		[SRCategory("CatLayout")]
		[SRDescription("FormScrollerTypeDescr")]
		[DefaultValue(ScrollerType.Default)]
		[Localizable(true)]
		[ProxyBrowsable(true)]
		public ScrollerType ScrollerType
		{
			get
			{
				return menmScrollerType;
			}
			set
			{
				if (menmScrollerType != value)
				{
					menmScrollerType = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets a value indicating whether [should render minimum client size].
		/// </summary>
		/// 
		/// 	true</c> if [should render minimum client size]; otherwise, false</c>.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual bool ShouldRenderMinimumClientSize => ShouldRenderMinimumClientWidth() || ShouldRenderMinimumClientHeight();

		/// 
		/// Gets the dock padding settings for all edges of the control.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdges" /> that represents the padding for all the edges of a docked control.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public DockPaddingEdges DockPadding
		{
			get
			{
				DockPaddingEdges dockPaddingEdges = GetValue(DockPaddingProperty);
				if (dockPaddingEdges == null)
				{
					dockPaddingEdges = new DockPaddingEdges(this);
					SetValue(DockPaddingProperty, dockPaddingEdges);
				}
				return dockPaddingEdges;
			}
		}

		/// 
		/// Gets the horizontal padding.
		/// </summary>
		/// The horizontal padding.</value>
		internal int HorizontalPadding
		{
			get
			{
				DockPaddingEdges dockPadding = DockPadding;
				return dockPadding.Left + dockPadding.Right;
			}
		}

		/// 
		/// Gets the vertical padding.
		/// </summary>
		/// The vertical padding.</value>
		internal int VerticalPadding
		{
			get
			{
				DockPaddingEdges dockPadding = DockPadding;
				return dockPadding.Top + dockPadding.Bottom;
			}
		}

		/// 
		/// Gets the display size.
		/// </summary>
		/// </value>
		protected override Size DisplaySize
		{
			get
			{
				if (AutoScroll)
				{
					return base.PreferredSize;
				}
				return base.DisplaySize;
			}
		}

		/// Gets or sets the size of the auto-scroll margin.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the height and width of the auto-scroll margin in pixels.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <see cref="P:System.Drawing.Size.Height"></see> or <see cref="P:System.Drawing.Size.Width"></see> value assigned is less than 0. </exception>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatLayout")]
		[Localizable(true)]
		[SRDescription("FormAutoScrollMarginDescr")]
		public Size AutoScrollMargin
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see> class.
		/// </summary>
		public ScrollableControl()
		{
			SetStyle(ControlStyles.ContainerControl, blnValue: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, blnValue: false);
			SetState(ControlState.HScroll | ControlState.VScroll, blnValue: true);
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mintMinimumClientHeight = objReader.ReadInt32();
			mintMinimumClientWidth = objReader.ReadInt32();
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteInt32(mintMinimumClientHeight);
			objWriter.WriteInt32(mintMinimumClientWidth);
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderMinimumClientSize(objContext, objWriter, blnForceRedraw: false);
			RenderScrollBars(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the scroll bars.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderScrollBars(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (GetProxyPropertyValue("AutoScroll", AutoScroll))
			{
				bool vScroll = VScroll;
				bool hScroll = HScroll;
				if (hScroll && vScroll)
				{
					objWriter.WriteAttributeString("SB", "B");
				}
				else if (hScroll)
				{
					objWriter.WriteAttributeString("SB", "H");
				}
				else if (vScroll)
				{
					objWriter.WriteAttributeString("SB", "V");
				}
				if (ScrollerType != ScrollerType.Default || blnForceRender)
				{
					objWriter.WriteAttributeString("SCTP", ((int)ScrollerType).ToString());
				}
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SB", string.Empty);
			}
		}

		/// 
		/// Renders the preferred size.
		/// </summary>
		/// <param name="objContext">The current context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRedraw">if set to true</c> force redraw.</param>
		private void RenderMinimumClientSize(IContext objContext, IAttributeWriter objWriter, bool blnForceRedraw)
		{
			if (ShouldRenderMinimumClientHeight())
			{
				if (mintMinimumClientHeight > 0 && VScroll)
				{
					objWriter.WriteAttributeString("MCH", mintMinimumClientHeight.ToString());
				}
				else if (blnForceRedraw)
				{
					objWriter.WriteAttributeString("MCH", "0");
				}
			}
			if (ShouldRenderMinimumClientWidth())
			{
				if (mintMinimumClientWidth > 0 && HScroll)
				{
					objWriter.WriteAttributeString("MCW", mintMinimumClientWidth.ToString());
				}
				else if (blnForceRedraw)
				{
					objWriter.WriteAttributeString("MCW", "0");
				}
			}
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderScrollBars(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				RenderMinimumClientSize(objContext, objWriter, blnForceRedraw: true);
			}
		}

		/// 
		/// Scrolls the specified child control into view on an auto-scroll enabled control.
		/// </summary>
		/// <param name="objActiveControl">The child control to scroll into view. </param>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void ScrollControlIntoView(Control objActiveControl)
		{
			if (IsDescendant(objActiveControl) && AutoScroll && (HScroll || VScroll) && objActiveControl != null)
			{
				InvokeMethod("Controls_ScrollIntoView", objActiveControl.ID, ID, "0", true);
			}
		}

		/// 
		/// Sets the minimum size of the client.
		/// </summary>
		/// <param name="objProposedSize">Proposed size.</param>
		protected override void SetMinimumClientSize(Size objProposedSize)
		{
			if (AutoScroll)
			{
				Size preferredSize = GetPreferredSize(objProposedSize, blnIsClientMinimumSize: true);
				mintMinimumClientWidth = preferredSize.Width;
				mintMinimumClientHeight = preferredSize.Height;
			}
			else
			{
				mintMinimumClientWidth = -1;
				mintMinimumClientHeight = -1;
			}
		}

		/// Sets the size of the auto-scroll margins.</summary>
		/// <param name="y">The <see cref="P:System.Drawing.Size.Height"></see> value. </param>
		/// <param name="x">The <see cref="P:System.Drawing.Size.Width"></see> value. </param>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void SetAutoScrollMargin(int x, int y)
		{
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new ScrollableControlRenderer(this);
		}

		/// 
		/// Indicates if to render padding attribute
		/// </summary>
		/// </returns>
		protected override bool ShouldRenderPaddingAttribute(Padding objPadding)
		{
			return PaddingValue.Empty != objPadding;
		}

		/// 
		/// Gets a value indicating whether [should render minimum client Width].
		/// </summary>
		/// 
		/// 	true</c> if [should render minimum client Width]; otherwise, false</c>.
		/// </value>        
		private bool ShouldRenderMinimumClientWidth()
		{
			return (Dock != DockStyle.Fill && Dock != DockStyle.Top && Dock != DockStyle.Bottom) || AutoScroll;
		}

		/// 
		/// Gets a value indicating whether [should render minimum client height].
		/// </summary>
		/// 
		/// 	true</c> if [should render minimum client height]; otherwise, false</c>.
		/// </value>        
		private bool ShouldRenderMinimumClientHeight()
		{
			return (Dock != DockStyle.Fill && Dock != DockStyle.Left && Dock != DockStyle.Right) || AutoScroll;
		}

		/// 
		/// Prevent serializing DockPadding if not required
		/// </summary>
		/// whether the store value differs form the default skin value.</returns>
		private bool ShouldSerializeDockPadding()
		{
			DockPaddingEdges value = GetValue(DockPaddingProperty);
			if (value != null)
			{
				Padding padding = new Padding(value.Left, value.Top, value.Right, value.Bottom);
				return !base.Skin.Padding.Value.Equals(padding);
			}
			return false;
		}
	}
}
