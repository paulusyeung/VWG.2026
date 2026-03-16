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
	/// 	Represents a control that allows the user to select a single item from a list that is displayed when the user clicks a <see cref="T:System.Windows.Forms.ToolStripDropDownButton"></see>. Although <see cref="T:System.Windows.Forms.ToolStripDropDownMenu"></see> and <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> replace and add functionality to the <see cref="T:System.Windows.Forms.Menu"></see> control of previous versions, <see cref="T:System.Windows.Forms.Menu"></see> is retained for both backward compatibility and future use if you choose.</summary>
	/// </summary>
	[Serializable]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ToolboxItem(false)]
	[Skin(typeof(ToolStripDropDownSkin))]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class ToolStripDropDown : ToolStrip
	{
		/// 
		///
		/// </summary>
		[Serializable]
		[ToolboxItem(false)]
		public class ToolStripDropDownHeaderPanel : Panel
		{
			/// 
			/// Gets/Sets the controls docking style
			/// </summary>
			public override DockStyle Dock
			{
				get
				{
					return base.Dock;
				}
				set
				{
					if (value != DockStyle.None && value != DockStyle.Fill)
					{
						base.Dock = value;
						return;
					}
					throw new ArgumentException(string.Format("Invalid docking value '{0}' for a tool strip drop down header panel."));
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown.ToolStripDropDownHeaderPanel" /> class.
			/// </summary>
			public ToolStripDropDownHeaderPanel()
			{
				base.Size = Size.Empty;
				Dock = DockStyle.Left;
			}
		}

		/// 
		///
		/// </summary>
		[Serializable]
		[ToolboxItem(false)]
		private class ToolStripDropDownContentPanel : Panel
		{
			private ToolStripDropDown mobjOwnerToolStripDropDown = null;

			/// 
			/// Gets or sets the control custom style.
			/// </summary>
			public override string CustomStyle
			{
				get
				{
					return "ToolStripDropDownContentPanel";
				}
				set
				{
					base.CustomStyle = value;
				}
			}

			/// 
			/// Gets or sets the owner tool strip drop down.
			/// </summary>
			/// 
			/// The owner tool strip drop down.
			/// </value>
			internal ToolStripDropDown OwnerToolStripDropDown
			{
				get
				{
					return mobjOwnerToolStripDropDown;
				}
				set
				{
					mobjOwnerToolStripDropDown = value;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown.ToolStripDropDownContentPanel" /> class.
			/// </summary>
			/// <param name="objOwnerToolStripDropDown">The obj owner tool strip drop down.</param>
			public ToolStripDropDownContentPanel()
			{
				AutoScroll = true;
				base.ScrollerType = ScrollerType.Arrows;
				base.VScroll = true;
			}

			/// 
			/// Renders the controls sub tree
			/// </summary>
			/// <param name="objContext"></param>
			/// <param name="objWriter"></param>
			/// <param name="lngRequestID"></param>
			protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
			{
				if (mobjOwnerToolStripDropDown == null)
				{
					return;
				}
				ToolStripItemCollection items = mobjOwnerToolStripDropDown.Items;
				if (items == null)
				{
					return;
				}
				foreach (ToolStripItem item in items)
				{
					if (item.Visible)
					{
						item.RenderToolStripItem(objContext, objWriter, lngRequestID);
					}
				}
			}

			/// 
			/// Get maximum width of image over all items
			/// </summary>
			/// </returns>
			internal int GetContentImageMaxWidth()
			{
				int num = 0;
				if (mobjOwnerToolStripDropDown != null)
				{
					num = mobjOwnerToolStripDropDown.ImageScalingSize.Width;
					ToolStripItemCollection items = mobjOwnerToolStripDropDown.Items;
					if (items != null)
					{
						num = 0;
						foreach (ToolStripItem item in items)
						{
							if (item.Visible)
							{
								int num2 = (item.AutoSize ? item.GetPreferredSizeByImage(Size.Empty).Width : mobjOwnerToolStripDropDown.ImageScalingSize.Width);
								if (num2 > num)
								{
									num = num2;
								}
							}
						}
					}
				}
				return num;
			}

			/// 
			/// Gets the size of the content preffered.
			/// </summary>
			/// </returns>
			internal Size GetContentPrefferedSize()
			{
				int num = 0;
				int num2 = 0;
				ToolStripMenuItemSkin toolStripMenuItemSkin = SkinFactory.GetSkin(this, typeof(ToolStripMenuItemSkin)) as ToolStripMenuItemSkin;
				if (mobjOwnerToolStripDropDown != null)
				{
					ToolStripItemCollection items = mobjOwnerToolStripDropDown.Items;
					if (items != null)
					{
						int num3 = 0;
						foreach (ToolStripItem item in items)
						{
							if (item.Visible)
							{
								Size size = (item.AutoSize ? item.GetPreferredSize(Size.Empty) : item.Size);
								if (size.Width > num3)
								{
									num3 = size.Width;
								}
								num2 += size.Height;
							}
						}
						num += num3;
						if (toolStripMenuItemSkin != null)
						{
							bool flag = Context != null && Context.RightToLeft;
							num = ((!flag) ? (num + toolStripMenuItemSkin.MenuItemImageWidthLTR) : (num + toolStripMenuItemSkin.MenuItemImageWidthRTL));
							num += toolStripMenuItemSkin.TextImageGapSize;
							num += toolStripMenuItemSkin.TextArrowGapSize;
							num = ((!flag) ? (num + toolStripMenuItemSkin.MenuItemArrowImageWidthLTR) : (num + toolStripMenuItemSkin.MenuItemArrowImageWidthRTL));
						}
					}
				}
				if (toolStripMenuItemSkin != null)
				{
					num += toolStripMenuItemSkin.MenuItemImageExtraWidth;
				}
				return new Size(num, num2);
			}
		}

		/// 
		///
		/// </summary>
		[Serializable]
		protected internal class ToolStripDropDownForm : Form
		{
			private static readonly SerializableProperty mobjOwnerToolStripDropDownProperty = SerializableProperty.Register("mobjOwnerToolStripDropDown", typeof(ToolStripDropDown), typeof(ToolStripDropDownForm));

			private static readonly SerializableProperty mobjOwnerToolStripItemProperty = SerializableProperty.Register("mobjOwnerToolStripItem", typeof(ToolStripItem), typeof(ToolStripDropDownForm));

			private ToolStripDropDownContentPanel mobjToolStripDropDownContentPanel;

			/// 
			/// Gets the owner tool strip item.
			/// </summary>
			/// The owner tool strip item.</value>
			private ToolStripItem OwnerToolStripItem
			{
				get
				{
					if (mobjOwnerToolStripItem == null && mobjOwnerToolStripDropDown != null)
					{
						mobjOwnerToolStripItem = mobjOwnerToolStripDropDown.OwnerItem;
					}
					return mobjOwnerToolStripItem;
				}
			}

			private ToolStripDropDown mobjOwnerToolStripDropDown
			{
				get
				{
					return GetValue(mobjOwnerToolStripDropDownProperty, null);
				}
				set
				{
					SetValue(mobjOwnerToolStripDropDownProperty, value);
				}
			}

			private ToolStripItem mobjOwnerToolStripItem
			{
				get
				{
					return GetValue(mobjOwnerToolStripItemProperty, null);
				}
				set
				{
					SetValue(mobjOwnerToolStripItemProperty, value);
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown.ToolStripDropDownForm" /> class.
			/// </summary>
			/// <param name="objOwnerToolStripDropDown">The obj owner tool strip drop down.</param>
			public ToolStripDropDownForm(ToolStripDropDown objOwnerToolStripDropDown)
			{
				InitializeComponent();
				mobjToolStripDropDownContentPanel.OwnerToolStripDropDown = (mobjOwnerToolStripDropDown = objOwnerToolStripDropDown);
				if (mobjOwnerToolStripDropDown != null)
				{
					base.Controls.Add(mobjOwnerToolStripDropDown.HeaderPanel);
					mobjOwnerToolStripDropDown.ItemAdded += OnOwnerDropDownItemCollectionChanged;
					mobjOwnerToolStripDropDown.ItemRemoved += OnOwnerDropDownItemCollectionChanged;
					Font = objOwnerToolStripDropDown.Font;
					BackColor = objOwnerToolStripDropDown.BackColor;
					ForeColor = objOwnerToolStripDropDown.ForeColor;
				}
				if (OwnerToolStripItem != null && OwnerToolStripItem.Parent != null)
				{
					Theme = OwnerToolStripItem.Parent.Theme;
				}
			}

			/// 
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				mobjToolStripDropDownContentPanel = new ToolStripDropDownContentPanel();
				SuspendLayout();
				mobjToolStripDropDownContentPanel.Dock = DockStyle.Fill;
				mobjToolStripDropDownContentPanel.Location = new Point(100, 0);
				mobjToolStripDropDownContentPanel.Name = "mobjToolStripDropDownContentPanel";
				mobjToolStripDropDownContentPanel.Size = new Size(577, 506);
				mobjToolStripDropDownContentPanel.TabIndex = 1;
				base.Controls.Add(mobjToolStripDropDownContentPanel);
				base.FormBorderStyle = FormBorderStyle.Sizable;
				base.Size = new Size(677, 506);
				CustomStyle = "ToolStripDropDown";
				MinimumSize = new Size(80, 0);
				Text = "Form1";
				ResumeLayout(blnPerformLayout: false);
			}

			/// 
			/// Called when [owner drop down item collection changed].
			/// </summary>
			/// <param name="objSender">The obj sender.</param>
			/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemEventArgs" /> instance containing the event data.</param>
			private void OnOwnerDropDownItemCollectionChanged(object objSender, ToolStripItemEventArgs objArgs)
			{
				InitializePrefferedSize();
			}

			/// 
			/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
			/// </summary>
			/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad(e);
				InitializePrefferedSize();
			}

			/// 
			/// Initializes a preffered size.
			/// </summary>
			private void InitializePrefferedSize()
			{
				int num = 0;
				int num2 = 0;
				if (SkinFactory.GetSkin(this, typeof(ToolStripDropDownSkin)) is ToolStripDropDownSkin toolStripDropDownSkin)
				{
					num2 += toolStripDropDownSkin.DropDownOffsetHeight;
					num += toolStripDropDownSkin.DropDownOffsetWidth;
				}
				if (mobjToolStripDropDownContentPanel != null)
				{
					Size contentPrefferedSize = mobjToolStripDropDownContentPanel.GetContentPrefferedSize();
					bool flag = true;
					num += contentPrefferedSize.Width;
					num2 += contentPrefferedSize.Height;
				}
				if (mobjOwnerToolStripDropDown != null && mobjOwnerToolStripDropDown.HeaderPanel != null)
				{
					switch (mobjOwnerToolStripDropDown.HeaderPanel.Dock)
					{
					case DockStyle.Top:
					case DockStyle.Bottom:
						num2 += mobjOwnerToolStripDropDown.HeaderPanel.Height;
						break;
					case DockStyle.Right:
					case DockStyle.Left:
						num += mobjOwnerToolStripDropDown.HeaderPanel.Width;
						break;
					}
				}
				if (num2 > 0 && num > 0)
				{
					base.Size = new Size(num, num2);
				}
			}

			/// 
			/// Renders the image size attributes.
			/// </summary>
			/// <param name="objWriter">The writer.</param>
			/// /// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
			private void RenderImageSizeAttributes(IAttributeWriter objWriter)
			{
				if (mobjOwnerToolStripDropDown != null)
				{
					Size imageScalingSize = mobjOwnerToolStripDropDown.ImageScalingSize;
					objWriter.WriteAttributeString("IH", imageScalingSize.Height.ToString(CultureInfo.InvariantCulture));
					objWriter.WriteAttributeString("IW", imageScalingSize.Width.ToString(CultureInfo.InvariantCulture));
					objWriter.WriteAttributeString("MIMW", mobjToolStripDropDownContentPanel.GetContentImageMaxWidth().ToString(CultureInfo.InvariantCulture));
				}
			}

			/// 
			/// Renders the forms attribute
			/// </summary>
			/// <param name="objContext"></param>
			/// <param name="objWriter"></param>
			protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
			{
				base.RenderAttributes(objContext, objWriter);
				RenderImageSizeAttributes(objWriter);
				ToolStripItem ownerToolStripItem = OwnerToolStripItem;
				if (ownerToolStripItem != null)
				{
					objWriter.WriteAttributeString("oId", $"{ownerToolStripItem.OwnerID.ToString()}_{ownerToolStripItem.MemberID.ToString()}");
					if (ownerToolStripItem.Owner is ToolStripDropDown && ownerToolStripItem is ToolStripDropDownItem toolStripDropDownItem && toolStripDropDownItem.DropDown.Items.Count > 0)
					{
						objWriter.WriteAttributeString("SF", "1");
					}
				}
				objWriter.WriteAttributeString("TSDD", "1");
				if (!mobjOwnerToolStripDropDown.AutoClose)
				{
					objWriter.WriteAttributeString("ACDD", "0");
				}
			}

			/// 
			/// Fires an event.
			/// </summary>
			/// <param name="objEvent">event.</param>
			protected override void FireEvent(IEvent objEvent)
			{
				ToolStripItem toolStripItem = null;
				if (mobjOwnerToolStripDropDown != null)
				{
					string member = objEvent.Member;
					if (!string.IsNullOrEmpty(member))
					{
						int result = -1;
						if (int.TryParse(member, out result))
						{
							toolStripItem = mobjOwnerToolStripDropDown.Items[result - 1];
						}
					}
				}
				if (toolStripItem != null)
				{
					toolStripItem.FireToolStripItemEvent(objEvent);
				}
				else
				{
					base.FireEvent(objEvent);
				}
			}
		}

		private static readonly SerializableProperty mblnAutoCloseProperty = SerializableProperty.Register("mblnAutoClose", typeof(bool), typeof(ToolStripDropDown));

		private static readonly SerializableProperty mblnAutoSizeProperty = SerializableProperty.Register("mblnAutoSize", typeof(bool), typeof(ToolStripDropDown));

		private static readonly SerializableProperty mblnIsAutoGeneratedProperty = SerializableProperty.Register("mblnIsAutoGenerated", typeof(bool), typeof(ToolStripDropDown));

		private static readonly SerializableProperty mobjOwnerItemProperty = SerializableProperty.Register("mobjOwnerItem", typeof(ToolStripItem), typeof(ToolStripDropDown));

		private static readonly SerializableProperty menmCloseReasonProperty = SerializableProperty.Register("menmCloseReason", typeof(ToolStripDropDownCloseReason), typeof(ToolStripDropDown));

		private static readonly SerializableProperty mobjSourceComponentProperty = SerializableProperty.Register("mobjSourceComponent", typeof(Component), typeof(ToolStripDropDown));

		private static readonly SerializableProperty mobjSourceMemberComponentProperty = SerializableProperty.Register("mobjSourceMemberComponent", typeof(IIdentifiedComponent), typeof(ToolStripDropDown));

		private static readonly SerializableProperty mobjToolStripDropDownFormProperty = SerializableProperty.Register("mobjToolStripDropDownForm", typeof(ToolStripDropDownForm), typeof(ToolStripDropDown));

		private static readonly SerializableProperty HeaderPanelProperty = SerializableProperty.Register("HeaderPanel", typeof(ToolStripDropDownHeaderPanel), typeof(ToolStripDropDown), new SerializablePropertyMetadata(null));

		private static readonly SerializableEvent ClosedEvent;

		private static readonly SerializableEvent OpenedEvent;

		private static readonly SerializableEvent OpeningEvent;

		/// 
		/// Gets the closed handler.
		/// </summary>
		/// The closed handler.</value>
		private ToolStripDropDownClosedEventHandler ClosedHandler => (ToolStripDropDownClosedEventHandler)GetHandler(ClosedEvent);

		/// 
		/// Gets the opened handler.
		/// </summary>
		/// The opened handler.</value>
		private EventHandler OpenedHandler => (EventHandler)GetHandler(OpenedEvent);

		/// 
		/// Gets the opening handler.
		/// </summary>
		/// The opening handler.</value>
		private CancelEventHandler OpeningHandler => (CancelEventHandler)GetHandler(OpeningEvent);

		private bool mblnAutoClose
		{
			get
			{
				return GetValue(mblnAutoCloseProperty);
			}
			set
			{
				SetValue(mblnAutoCloseProperty, value);
			}
		}

		private bool mblnAutoSize
		{
			get
			{
				return GetValue(mblnAutoSizeProperty);
			}
			set
			{
				SetValue(mblnAutoSizeProperty, value);
			}
		}

		private bool mblnIsAutoGenerated
		{
			get
			{
				return GetValue(mblnIsAutoGeneratedProperty);
			}
			set
			{
				SetValue(mblnIsAutoGeneratedProperty, value);
			}
		}

		private ToolStripItem mobjOwnerItem
		{
			get
			{
				return GetValue(mobjOwnerItemProperty);
			}
			set
			{
				SetValue(mobjOwnerItemProperty, value);
			}
		}

		private ToolStripDropDownCloseReason menmCloseReason
		{
			get
			{
				return GetValue(menmCloseReasonProperty);
			}
			set
			{
				SetValue(menmCloseReasonProperty, value);
			}
		}

		private Component mobjSourceComponent
		{
			get
			{
				return GetValue(mobjSourceComponentProperty, null);
			}
			set
			{
				SetValue(mobjSourceComponentProperty, value);
			}
		}

		private IIdentifiedComponent mobjSourceMemberComponent
		{
			get
			{
				return GetValue(mobjSourceMemberComponentProperty, null);
			}
			set
			{
				SetValue(mobjSourceMemberComponentProperty, value);
			}
		}

		private ToolStripDropDownForm mobjToolStripDropDownForm
		{
			get
			{
				return GetValue(mobjToolStripDropDownFormProperty, null);
			}
			set
			{
				SetValue(mobjToolStripDropDownFormProperty, value);
			}
		}

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// true to enable item reordering; otherwise, false.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AllowItemReorder
		{
			get
			{
				return base.AllowItemReorder;
			}
			set
			{
				base.AllowItemReorder = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.Opacity"></see> of the form can be adjusted.
		/// </summary>
		/// true</c> if [allow transparency]; otherwise, false</c>.</value>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.Opacity"></see> of the form can be adjusted; otherwise, false. </returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AllowTransparency
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.AnchorStyles"></see> values.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override AnchorStyles Anchor
		{
			get
			{
				return base.Anchor;
			}
			set
			{
				base.Anchor = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control should automatically close when it has lost activation.
		/// </summary>
		/// true</c> if [auto close]; otherwise, false</c>.</value>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control automatically closes; otherwise, false. The default is true.</returns>
		/// 
		/// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		/// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		[DefaultValue(true)]
		[SRDescription("ToolStripDropDownAutoCloseDescr")]
		[SRCategory("CatBehavior")]
		public bool AutoClose
		{
			get
			{
				return mblnAutoClose;
			}
			set
			{
				if (mblnAutoClose != value)
				{
					mblnAutoClose = value;
					if (mobjToolStripDropDownForm != null)
					{
						mobjToolStripDropDownForm.Update();
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> automatically adjusts its size when the form is resized.
		/// </summary>
		/// </value>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control automatically resizes; otherwise, false. The default is true.</returns>
		/// 
		/// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		/// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		[DefaultValue(true)]
		public override bool AutoSize
		{
			get
			{
				return mblnAutoSize;
			}
			set
			{
				if (mblnAutoSize != value)
				{
					mblnAutoSize = value;
					OnAutoSizeChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ContextMenu"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new ContextMenu ContextMenu
		{
			get
			{
				return base.ContextMenu;
			}
			set
			{
				base.ContextMenu = value;
			}
		}

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return base.ContextMenuStrip;
			}
			set
			{
				base.ContextMenuStrip = value;
			}
		}

		protected override DockStyle DefaultDock => DockStyle.None;

		protected override bool DefaultShowItemToolTips => true;

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values.</returns>
		[DefaultValue(DockStyle.None)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(false)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether a three-dimensional shadow effect appears when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed.
		/// </summary>
		/// true</c> if [drop shadow enabled]; otherwise, false</c>.</value>
		/// true to enable the shadow effect; otherwise, false.</returns>
		/// 
		/// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		/// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool DropShadowEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the font of the text displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.
		/// </summary>
		/// </value>
		/// The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the control.</returns>
		public override Font Font
		{
			get
			{
				if (IsAutoGenerated && OwnerItem != null)
				{
					return OwnerItem.Font;
				}
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		/// This property is not relevant to this class.</summary> 
		/// One of <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> the values.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new ToolStripGripDisplayStyle GripDisplayStyle => base.GripDisplayStyle;

		/// This property is not relevant to this class.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new Padding GripMargin
		{
			get
			{
				return base.GripMargin;
			}
			set
			{
				base.GripMargin = value;
			}
		}

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripStyle"></see> values.</returns>
		/// 
		/// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		/// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(ToolStripGripStyle.Hidden)]
		[Browsable(false)]
		public new ToolStripGripStyle GripStyle
		{
			get
			{
				return base.GripStyle;
			}
			set
			{
				base.GripStyle = value;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> was automatically generated.
		/// </summary>
		/// 
		/// 	true</c> if this instance is auto generated; otherwise, false</c>.
		/// </value>
		/// true if this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is generated automatically; otherwise, false.</returns>
		[Browsable(false)]
		public bool IsAutoGenerated => mblnIsAutoGenerated;

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// A <see cref="T:System.Drawing.Point"></see>.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Point Location
		{
			get
			{
				return base.Location;
			}
			set
			{
				base.Location = value;
			}
		}

		/// 
		/// Determines the opacity of the form.
		/// </summary>
		/// The opacity.</value>
		/// The level of opacity for the form. The default is 1.00.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Opacity
		{
			get
			{
				return 1.0;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the owner of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.
		/// </summary>
		/// The owner item.</value>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the owner of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>. The default value is null.</returns>
		[Browsable(false)]
		[DefaultValue(null)]
		public ToolStripItem OwnerItem
		{
			get
			{
				return mobjOwnerItem;
			}
			set
			{
				if (mobjOwnerItem != value)
				{
					Font font = Font;
					RightToLeft rightToLeft = RightToLeft;
					mobjOwnerItem = value;
				}
			}
		}

		/// 
		/// Gets the parent of this component.
		/// </summary>
		public override Component InternalParent
		{
			get
			{
				Component internalParent = base.InternalParent;
				if (internalParent == null)
				{
					return mobjOwnerItem;
				}
				return internalParent;
			}
			set
			{
				base.InternalParent = value;
			}
		}

		/// 
		/// Gets or sets the source component internal.
		/// </summary>
		/// The source component internal.</value>
		internal Component SourceComponentInternal
		{
			get
			{
				return mobjSourceComponent;
			}
			set
			{
				if (value != mobjSourceComponent)
				{
					mobjSourceComponent = value;
				}
			}
		}

		internal IIdentifiedComponent SourceMemberComponentInternal
		{
			get
			{
				return mobjSourceMemberComponent;
			}
			set
			{
				if (value != mobjSourceMemberComponent)
				{
					mobjSourceMemberComponent = value;
				}
			}
		}

		/// 
		/// Gets or sets the window region associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.
		/// </summary>
		/// The region.</value>
		/// The window <see cref="T:System.Drawing.Region"></see> associated with the control.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Region Region
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// 
		/// Gets a value indicating whether [right to left inherited].
		/// </summary>
		/// 
		/// 	true</c> if [right to left inherited]; otherwise, false</c>.
		/// </value>
		private bool RightToLeftInherited => !ShouldSerializeRightToLeft();

		/// 
		/// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
		/// </summary>
		/// </value>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Inherit"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[AmbientValue(2)]
		[SRDescription("ControlRightToLeftDescr")]
		public override RightToLeft RightToLeft
		{
			get
			{
				if (RightToLeftInherited && OwnerItem != null)
				{
					return OwnerItem.RightToLeft;
				}
				return base.RightToLeft;
			}
			set
			{
				base.RightToLeft = value;
			}
		}

		/// 
		/// Gets the drop down form.
		/// </summary>
		/// The drop down form.</value>
		internal Form DropDownForm => mobjToolStripDropDownForm;

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// true to enable stretching; otherwise, false.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new bool Stretch
		{
			get
			{
				return base.Stretch;
			}
			set
			{
				base.Stretch = value;
			}
		}

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// </value>
		/// An <see cref="T:System.Int32"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}

		/// 
		/// Specifies the direction in which to draw the text on the item.
		/// </summary>
		/// </value>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripTextDirection.Horizontal"></see>.</returns>
		[DefaultValue(ToolStripTextDirection.Horizontal)]
		[SRCategory("CatAppearance")]
		[Browsable(false)]
		[SRDescription("ToolStripTextDirectionDescr")]
		public override ToolStripTextDirection TextDirection
		{
			get
			{
				return base.TextDirection;
			}
			set
			{
				base.TextDirection = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is a top-level control.
		/// </summary>
		/// true</c> if [top level]; otherwise, false</c>.</value>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is a top-level control; otherwise, false.</returns>
		/// 
		/// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		/// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool TopLevel
		{
			get
			{
				return GetTopLevel();
			}
			set
			{
				if (value != GetTopLevel())
				{
					SetTopLevelInternal(value);
				}
			}
		}

		/// 
		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the overflow button for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> with overflow enabled.
		/// </summary>
		/// An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> with its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Right"></see> and its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> value set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.Never"></see>.</returns>
		///
		/// 
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   </PermissionSet>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new ToolStripOverflowButton OverflowButton => base.OverflowButton;

		/// 
		/// Gets or sets a value indicating whether the form should be displayed as a topmost form.
		/// </summary>
		/// true</c> if [top most]; otherwise, false</c>.</value>
		/// true in all cases.</returns>
		protected virtual bool TopMost => true;

		/// 
		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is visible or hidden.
		/// </summary>
		/// </value>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is visible; otherwise, false. The default is false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool Visible => DropDownForm != null && DropDownForm.Visible;

		/// 
		/// Gets the header panel.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRDescription("ToolStripDropDownHeaderPanelDescr")]
		[SRCategory("CatAppearance")]
		public ToolStripDropDownHeaderPanel HeaderPanel
		{
			get
			{
				ToolStripDropDownHeaderPanel toolStripDropDownHeaderPanel = GetValue(HeaderPanelProperty);
				if (toolStripDropDownHeaderPanel == null)
				{
					toolStripDropDownHeaderPanel = new ToolStripDropDownHeaderPanel();
					SetValue(HeaderPanelProperty, toolStripDropDownHeaderPanel);
				}
				return toolStripDropDownHeaderPanel;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.BackgroundImage"></see> property changes.</summary>
		[Browsable(false)]
		public new event EventHandler BackgroundImageChanged
		{
			add
			{
				base.BackgroundImageChanged += value;
			}
			remove
			{
				base.BackgroundImageChanged -= value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.BackgroundImage"></see> property changes.</summary>
		[Browsable(false)]
		public new event EventHandler BackgroundImageLayoutChanged
		{
			add
			{
				base.BackgroundImageLayoutChanged += value;
			}
			remove
			{
				base.BackgroundImageLayoutChanged -= value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.BindingContext"></see> property changes.</summary>
		[Browsable(false)]
		public new event EventHandler BindingContextChanged
		{
			add
			{
				base.BindingContextChanged += value;
			}
			remove
			{
				base.BindingContextChanged -= value;
			}
		}

		/// Occurs when the focus or keyboard user interface (UI) cues change.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event UICuesEventHandler ChangeUICues;

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is closed.</summary> 
		/// 1</filterpriority>
		public event ToolStripDropDownClosedEventHandler Closed
		{
			add
			{
				AddHandler(ClosedEvent, value);
			}
			remove
			{
				RemoveHandler(ClosedEvent, value);
			}
		}

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is about to close.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripDropDownClosingEventHandler Closing;

		/// This event is not relevant to this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler ContextMenuChanged;

		/// This event is not relevant to this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new event EventHandler ContextMenuStripChanged
		{
			add
			{
				base.ContextMenuStripChanged += value;
			}
			remove
			{
				base.ContextMenuStripChanged -= value;
			}
		}

		/// This event is not relevant to this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler DockChanged;

		/// Occurs when the focus enters the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new event EventHandler Enter
		{
			add
			{
				base.Enter += value;
			}
			remove
			{
				base.Enter -= value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.Font"></see> property changes.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new event EventHandler FontChanged
		{
			add
			{
				base.FontChanged += value;
			}
			remove
			{
				base.FontChanged -= value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ForeColor"></see> property changes.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler ForeColorChanged
		{
			add
			{
				base.ForeColorChanged += value;
			}
			remove
			{
				base.ForeColorChanged -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event GiveFeedbackEventHandler GiveFeedback;

		/// Occurs when the user requests help for a control.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new event HelpEventHandler HelpRequested;

		/// Occurs when the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.ImeModeChanged"></see> property has changed.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler ImeModeChanged;

		/// Occurs when a key is pressed and held down while the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> has focus.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new event KeyEventHandler KeyDown
		{
			add
			{
				base.KeyDown += value;
			}
			remove
			{
				base.KeyDown -= value;
			}
		}

		/// Occurs when a key is pressed while the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> has focus.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new event KeyPressEventHandler KeyPress
		{
			add
			{
				base.KeyPress += value;
			}
			remove
			{
				base.KeyPress -= value;
			}
		}

		/// Occurs when a key is released while the control has focus.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new event KeyEventHandler KeyUp
		{
			add
			{
				base.KeyUp += value;
			}
			remove
			{
				base.KeyUp -= value;
			}
		}

		/// 
		/// Occurs when the input focus leaves the control.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new event EventHandler Leave
		{
			add
			{
				base.Leave += value;
			}
			remove
			{
				base.Leave -= value;
			}
		}

		/// 
		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is opened.
		/// </summary>
		public event EventHandler Opened
		{
			add
			{
				AddHandler(OpenedEvent, value);
			}
			remove
			{
				RemoveHandler(OpenedEvent, value);
			}
		}

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is opening.</summary>
		[SRCategory("CatAction")]
		[SRDescription("ToolStripDropDownOpeningDescr")]
		public event CancelEventHandler Opening
		{
			add
			{
				AddHandler(OpeningEvent, value);
			}
			remove
			{
				RemoveHandler(OpeningEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.Region"></see> property changes.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler RegionChanged;

		/// This event is not relevant for this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ScrollEventHandler Scroll;

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> style changes.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler StyleChanged;

		/// This event is not relevant to this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TabIndexChanged;

		/// This event is not relevant for this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TabStopChanged;

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler TextChanged
		{
			add
			{
				base.TextChanged += value;
			}
			remove
			{
				base.TextChanged -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler Validated
		{
			add
			{
				base.Validated += value;
			}
			remove
			{
				base.Validated -= value;
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event CancelEventHandler Validating
		{
			add
			{
				base.Validating += value;
			}
			remove
			{
				base.Validating -= value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> class.
		/// </summary>
		public ToolStripDropDown()
		{
			mblnAutoClose = true;
			mblnAutoSize = true;
			SuspendLayout();
			Initialize();
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown" /> class.
		/// </summary>
		/// <param name="objOwnerItem">The owner item.</param>
		internal ToolStripDropDown(ToolStripItem objOwnerItem)
			: this()
		{
			mobjOwnerItem = objOwnerItem;
			if (objOwnerItem != null)
			{
				ToolStrip parent = objOwnerItem.Parent;
				if (parent != null)
				{
					base.ImageScalingSize = parent.ImageScalingSize;
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown" /> class.
		/// </summary>
		/// <param name="objOwnerItem">The owner item.</param>
		/// <param name="blnIsAutoGenerated">if set to true</c> [is auto generated].</param>
		internal ToolStripDropDown(ToolStripItem objOwnerItem, bool blnIsAutoGenerated)
			: this(objOwnerItem)
		{
			mblnIsAutoGenerated = blnIsAutoGenerated;
		}

		/// 
		/// Sets the auto generated internal.
		/// </summary>
		/// <param name="autoGenerated">if set to true</c> [auto generated].</param>
		internal void SetAutoGeneratedInternal(bool autoGenerated)
		{
			mblnIsAutoGenerated = autoGenerated;
		}

		/// 
		/// Initializes this instance.
		/// </summary>
		internal virtual void Initialize()
		{
			SetTopLevelInternal(blnValue: true);
			SetStyle(ControlStyles.ResizeRedraw, blnValue: true);
			GripStyle = ToolStripGripStyle.Hidden;
			base.LayoutStyle = ToolStripLayoutStyle.Flow;
			AutoSize = true;
		}

		/// 
		/// Sets the close reason.
		/// </summary>
		/// <param name="reason">The reason.</param>
		internal void SetCloseReason(ToolStripDropDownCloseReason enmCloseReason)
		{
			menmCloseReason = enmCloseReason;
		}

		/// 
		/// Closes the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control.
		/// </summary>
		public void Close()
		{
			Close(ToolStripDropDownCloseReason.CloseCalled);
		}

		/// 
		/// Closes the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control for the specified reason.
		/// </summary>
		/// <param name="enmReason">One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownCloseReason"></see> values.</param>
		public void Close(ToolStripDropDownCloseReason enmReason)
		{
			SetCloseReason(enmReason);
			mobjToolStripDropDownForm.Close();
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.Closed"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownClosedEventArgs"></see> that contains the event data.</param>
		protected virtual void OnClosed(ToolStripDropDownClosedEventArgs e)
		{
			ClosedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.Closing"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownClosingEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnClosing(ToolStripDropDownClosingEventArgs e)
		{
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.Opened"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnOpened(EventArgs e)
		{
			OpenedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripDropDown.Opening"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data.</param>
		protected virtual void OnOpening(CancelEventArgs e)
		{
			OpeningHandler?.Invoke(this, e);
		}

		/// 
		/// Displays the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control in its default position.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new void Show()
		{
			ShowCore(ToolStripDropDownDirection.Default);
		}

		/// 
		/// Shows the specified control.
		/// </summary>
		/// <param name="objComponent">The control.</param>
		/// <param name="objPosition">The position.</param>
		public void Show(Component objComponent, Point objPosition)
		{
			Show(objComponent, objPosition, ToolStripDropDownDirection.Default);
		}

		/// 
		/// Shows the core.
		/// </summary>
		/// <param name="objDirection">The direction.</param>
		private void ShowCore(ToolStripDropDownDirection objDirection)
		{
			if (SourceComponentInternal == null && OwnerItem == null)
			{
				SourceComponentInternal = VWGContext.Current.MainForm as Form;
			}
			DialogAlignment enmAlignment = DialogAlignment.Custom;
			CancelEventArgs e = new CancelEventArgs(Items.Count == 0);
			OnOpening(e);
			if (e.Cancel || Items.Count <= 0)
			{
				return;
			}
			mobjToolStripDropDownForm = CreateToolStripDropDownForm();
			if (mobjToolStripDropDownForm == null)
			{
				return;
			}
			switch (objDirection)
			{
			case ToolStripDropDownDirection.Left:
				enmAlignment = DialogAlignment.Left;
				break;
			case ToolStripDropDownDirection.Right:
				enmAlignment = DialogAlignment.Right;
				break;
			case ToolStripDropDownDirection.AboveLeft:
			case ToolStripDropDownDirection.AboveRight:
				enmAlignment = DialogAlignment.Above;
				break;
			case ToolStripDropDownDirection.BelowLeft:
			case ToolStripDropDownDirection.BelowRight:
				enmAlignment = DialogAlignment.Below;
				break;
			}
			Component sourceComponentInternal = SourceComponentInternal;
			if (sourceComponentInternal != null)
			{
				mobjToolStripDropDownForm.Location = Location;
				mobjToolStripDropDownForm.ShowPopup(sourceComponentInternal, SourceMemberComponentInternal, enmAlignment);
				return;
			}
			ToolStripItem ownerItem = OwnerItem;
			if (ownerItem == null)
			{
				return;
			}
			ToolStrip owner = ownerItem.Owner;
			if (owner == null)
			{
				return;
			}
			if (owner is ToolStripDropDown { DropDownForm: var dropDownForm })
			{
				if (dropDownForm == null || !dropDownForm.Visible)
				{
					Form objForm = Context.ActiveForm as Form;
					mobjToolStripDropDownForm.ShowPopup(objForm);
				}
				else
				{
					mobjToolStripDropDownForm.ShowPopup(dropDownForm, (IRegisteredComponentMember)ownerItem, Context.RightToLeft ? DialogAlignment.Left : DialogAlignment.Right);
				}
			}
			else if (owner.TopLevelControl is Form objForm2)
			{
				mobjToolStripDropDownForm.ShowPopup(objForm2, (IRegisteredComponentMember)ownerItem, DialogAlignment.Below);
			}
		}

		/// 
		/// Creates the tool strip drop down form.
		/// </summary>
		/// </returns>
		private ToolStripDropDownForm CreateToolStripDropDownForm()
		{
			ToolStripDropDownForm toolStripDropDownForm = CreateToolStripDropDownFormInstance();
			toolStripDropDownForm.StartPosition = FormStartPosition.Manual;
			if (ClosedHandler != null)
			{
				toolStripDropDownForm.Closed += OnToolStripDropDownFormClosed;
			}
			if (OpenedHandler != null)
			{
				toolStripDropDownForm.Load += OnToolStripDropDownFormLoaded;
			}
			return toolStripDropDownForm;
		}

		/// 
		/// Creates the tool strip drop down form instance.
		/// </summary>
		/// </returns>
		protected virtual ToolStripDropDownForm CreateToolStripDropDownFormInstance()
		{
			return new ToolStripDropDownForm(this);
		}

		/// 
		/// Called when [tool strip drop down form loaded].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnToolStripDropDownFormLoaded(object sender, EventArgs e)
		{
			OnOpened(EventArgs.Empty);
		}

		/// 
		/// Handles the Closed event of the objToolStripDropDownForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnToolStripDropDownFormClosed(object sender, EventArgs e)
		{
			OnClosed(new ToolStripDropDownClosedEventArgs(ToolStripDropDownCloseReason.AppFocusChange));
		}

		/// 
		/// Shows the specified control.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="objPosition">The position.</param>
		/// <param name="enmDirection">The direction.</param>
		public void Show(Component objComponent, Point objPosition, ToolStripDropDownDirection enmDirection)
		{
			if (objComponent == null)
			{
				throw new ArgumentNullException("objComponent");
			}
			SourceComponentInternal = objComponent;
			SourceMemberComponentInternal = null;
			Show(objPosition, enmDirection);
		}

		/// 
		/// Shows the specified control.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="objMemberComponent">The member component.</param>
		/// <param name="objPoint">The point.</param>
		public void Show(Component objComponent, IIdentifiedComponent objMemberComponent, Point objPoint)
		{
			if (objComponent == null)
			{
				throw new ArgumentNullException("objComponent");
			}
			SourceComponentInternal = objComponent;
			SourceMemberComponentInternal = objMemberComponent;
			Show(objPoint);
		}

		/// 
		/// Shows the specified control.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intX">The X.</param>
		/// <param name="intY">The Y.</param>
		public void Show(Control objControl, int intX, int intY)
		{
			Show(objControl, new Point(intX, intY));
		}

		/// 
		/// Shows the drop down.
		/// </summary>
		/// <param name="objComponent">The component.</param>
		/// <param name="intX">The X.</param>
		/// <param name="intY">The Y.</param>
		internal void ShowDropDown(Component objComponent, int intX, int intY)
		{
			if (objComponent == null)
			{
				throw new ArgumentNullException("objComponent");
			}
			SourceComponentInternal = objComponent;
			SourceMemberComponentInternal = null;
			Show(new Point(intX, intY));
		}

		/// 
		/// Shows the drop down.
		/// </summary>
		/// <param name="objOwnerItem">The obj owner item.</param>
		internal void ShowDropDown(ToolStripDropDownItem objOwnerItem)
		{
			OwnerItem = objOwnerItem;
			SourceComponentInternal = null;
			Location = Point.Empty;
			ShowCore(ToolStripDropDownDirection.Default);
		}

		/// Positions the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> relative to the specified screen location.</summary> 
		/// <param name="screenLocation">The horizontal and vertical location of the screen's upper-left corner, in pixels.</param> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void Show(Point screenLocation)
		{
			Show(screenLocation, ToolStripDropDownDirection.Default);
		}

		/// Positions the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> relative to the specified control location and with the specified direction relative to the parent control.</summary> 
		/// <param name="direction">One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</param> 
		/// <param name="position">The horizontal and vertical location of the reference control's upper-left corner, in pixels.</param>
		public void Show(Point position, ToolStripDropDownDirection direction)
		{
			Location = position;
			ShowCore(direction);
		}

		/// Positions the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> relative to the specified screen coordinates.</summary> 
		/// <param name="y">The vertical screen coordinate, in pixels.</param> 
		/// <param name="x">The horizontal screen coordinate, in pixels.</param> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void Show(int x, int y)
		{
			Show(new Point(x, y));
		}

		/// 
		/// Sets the control to the specified visible state.
		/// </summary>
		/// <param name="blnValue">true to make the control visible; otherwise, false.</param>
		protected override void SetVisibleCore(bool blnValue)
		{
			if (!blnValue && AutoClose && mobjToolStripDropDownForm != null)
			{
				mobjToolStripDropDownForm.Close();
			}
		}

		/// 
		/// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemAdded"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
		protected internal override void OnItemAdded(ToolStripItemEventArgs e)
		{
			base.OnItemAdded(e);
			if (mobjOwnerItem != null)
			{
				mobjOwnerItem.UpdateParams(AttributeType.Extended);
			}
		}

		/// 
		/// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemRemoved"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
		protected internal override void OnItemRemoved(ToolStripItemEventArgs e)
		{
			base.OnItemRemoved(e);
			if (mobjOwnerItem != null)
			{
				mobjOwnerItem.UpdateParams(AttributeType.Extended);
			}
		}

		static ToolStripDropDown()
		{
			ClosedEvent = SerializableEvent.Register("Closed", typeof(ToolStripDropDownClosedEventHandler), typeof(ToolStripDropDown));
			OpenedEvent = SerializableEvent.Register("Opened", typeof(EventHandler), typeof(ToolStripDropDown));
			OpeningEvent = SerializableEvent.Register("Opening", typeof(CancelEventHandler), typeof(ToolStripDropDown));
		}
	}
}
