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
/// Represents a cell that contains a link. </summary>
	/// 2</filterpriority>
	[Serializable]
	[Skin(typeof(DataGridViewLinkCellSkin))]
	public class DataGridViewLinkCell : DataGridViewCell
	{
		private const byte DATAGRIDVIEWLINKCELL_horizontalTextMarginLeft = 1;

		private const byte DATAGRIDVIEWLINKCELL_horizontalTextMarginRight = 2;

		private const byte DATAGRIDVIEWLINKCELL_verticalTextMarginBottom = 1;

		private const byte DATAGRIDVIEWLINKCELL_verticalTextMarginTop = 1;

		private bool mblnClientMode;

		private bool mblnLinkVisited;

		private bool mblnLinkVisitedSet;

		private string mstrUrl = string.Empty;

		private LinkState menmLinkState = LinkState.Normal;

		private Color mobjLinkVisitedLinkColor = Color.Empty;

		private int mintLinkTrackVisitedState = 0;

		private Color mobjLinkColor = Color.Empty;

		private LinkBehavior menmLinkBehavior = LinkBehavior.SystemDefault;

		private int mintLinkUseColumnTextForLinkValue = 0;

		private Color mobjLinkActiveColor = Color.Empty;

		private static Type mobjCellType;

		private static Type mobjDefaultFormattedValueType;

		private static Type mobjDefaultValueType;

		/// Gets or sets the color used to display an active link.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that is being selected. The default value is the user's Internet Explorer setting for the color of links in the hover state. </returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
		public Color ActiveLinkColor
		{
			get
			{
				if (!mobjLinkActiveColor.IsEmpty)
				{
					return mobjLinkActiveColor;
				}
				return LinkUtilities.IEActiveLinkColor;
			}
			set
			{
				if (value.Equals(ActiveLinkColor))
				{
					return;
				}
				mobjLinkActiveColor = value;
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		/// 
		/// Sets the active link color internal.
		/// </summary>
		/// The active link color internal.</value>
		internal Color ActiveLinkColorInternal
		{
			set
			{
				if (!value.Equals(ActiveLinkColor))
				{
					mobjLinkActiveColor = value;
				}
			}
		}

		/// 
		/// Gets or sets the URL.
		/// </summary>
		/// The URL.</value>
		public string Url
		{
			get
			{
				return mstrUrl;
			}
			set
			{
				if (mstrUrl != value)
				{
					mstrUrl = value;
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [client mode].
		/// Setting a value to the cell does not change the ClientMode property of the containing column.
		/// </summary>
		/// true</c> if [client mode]; otherwise, false</c>.</value>
		[SRDescription("DataGridView_LinkCellClientModeDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool ClientMode
		{
			get
			{
				return mblnClientMode;
			}
			set
			{
				if (mblnClientMode != value)
				{
					mblnClientMode = value;
					Update();
				}
			}
		}

		/// Gets the type of the cell's hosted editing control.</summary>
		/// Always null. </returns>
		/// 1</filterpriority>
		public override Type EditType => null;

		/// Gets the display <see cref="T:System.Type"></see> of the cell value.</summary>
		/// Always <see cref="T:System.String"></see>.</returns>
		/// 1</filterpriority>
		public override Type FormattedValueType => mobjDefaultFormattedValueType;

		/// Gets or sets a value that represents the behavior of a link.</summary>
		/// One of the <see cref="T:System.Windows.Forms.LinkBehavior"></see> values. The default is <see cref="F:System.Windows.Forms.LinkBehavior.SystemDefault"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.LinkBehavior"></see> value.</exception>
		/// 1</filterpriority>
		[DefaultValue(0)]
		public LinkBehavior LinkBehavior
		{
			get
			{
				return menmLinkBehavior;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(LinkBehavior));
				}
				if (value == LinkBehavior)
				{
					return;
				}
				menmLinkBehavior = value;
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		/// 
		/// Sets the link behavior internal.
		/// </summary>
		/// The link behavior internal.</value>
		internal LinkBehavior LinkBehaviorInternal
		{
			set
			{
				if (value != LinkBehavior)
				{
					menmLinkBehavior = value;
				}
			}
		}

		/// Gets or sets the color used to display an inactive and unvisited link.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color used to initially display a link. The default value is the user's Internet Explorer setting for the link color.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
		public Color LinkColor
		{
			get
			{
				if (!mobjLinkColor.IsEmpty)
				{
					return mobjLinkColor;
				}
				return LinkUtilities.IELinkColor;
			}
			set
			{
				if (value.Equals(LinkColor))
				{
					return;
				}
				mobjLinkColor = value;
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		/// 
		/// Sets the link color internal.
		/// </summary>
		/// The link color internal.</value>
		internal Color LinkColorInternal
		{
			set
			{
				if (!value.Equals(LinkColor))
				{
					mobjLinkColor = value;
				}
			}
		}

		/// 
		/// Gets or sets the state of the link.
		/// </summary>
		/// The state of the link.</value>
		private LinkState LinkState
		{
			get
			{
				return menmLinkState;
			}
			set
			{
				if (LinkState != value)
				{
					menmLinkState = value;
				}
			}
		}

		/// Gets or sets a value indicating whether the link was visited.</summary>
		/// true if the link has been visited; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		public bool LinkVisited
		{
			get
			{
				return mblnLinkVisitedSet && mblnLinkVisited;
			}
			set
			{
				mblnLinkVisitedSet = true;
				if (value == LinkVisited)
				{
					return;
				}
				mblnLinkVisited = value;
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		/// Gets or sets a value indicating whether the link changes color when it is visited.</summary>
		/// true if the link changes color when it is selected; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[DefaultValue(true)]
		public bool TrackVisitedState
		{
			get
			{
				return mintLinkTrackVisitedState != 0;
			}
			set
			{
				if (value == TrackVisitedState)
				{
					return;
				}
				mintLinkTrackVisitedState = (value ? 1 : 0);
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		/// 
		/// Sets a value indicating whether [track visited state internal].
		/// </summary>
		/// 
		/// 	true</c> if [track visited state internal]; otherwise, false</c>.
		/// </value>
		internal bool TrackVisitedStateInternal
		{
			set
			{
				if (value != TrackVisitedState)
				{
					mintLinkTrackVisitedState = (value ? 1 : 0);
				}
			}
		}

		/// Gets or sets a value indicating whether the column <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text.</summary>
		/// true if the column <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text; false if the cell <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value is displayed as the link text. The default is false.</returns>
		[DefaultValue(false)]
		public bool UseColumnTextForLinkValue
		{
			get
			{
				return mintLinkUseColumnTextForLinkValue != 0;
			}
			set
			{
				if (value != UseColumnTextForLinkValue)
				{
					mintLinkUseColumnTextForLinkValue = (value ? 1 : 0);
					OnCommonChange();
				}
			}
		}

		/// 
		/// Sets a value indicating whether [use column text for link value internal].
		/// </summary>
		/// 
		/// 	true</c> if [use column text for link value internal]; otherwise, false</c>.
		/// </value>
		internal bool UseColumnTextForLinkValueInternal
		{
			set
			{
				if (value != UseColumnTextForLinkValue)
				{
					mintLinkUseColumnTextForLinkValue = (value ? 1 : 0);
				}
			}
		}

		/// 
		/// Gets or sets the data type of the values in the cell.
		/// </summary>
		/// </value>
		/// A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
		public override Type ValueType
		{
			get
			{
				Type valueType = base.ValueType;
				if (valueType != null)
				{
					return valueType;
				}
				return mobjDefaultValueType;
			}
		}

		/// Gets or sets the color used to display a link that has been previously visited.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that has been visited. The default value is the user's Internet Explorer setting for the visited link color.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
		public Color VisitedLinkColor
		{
			get
			{
				if (!mobjLinkVisitedLinkColor.IsEmpty)
				{
					return mobjLinkVisitedLinkColor;
				}
				return LinkUtilities.IEVisitedLinkColor;
			}
			set
			{
				if (value.Equals(VisitedLinkColor))
				{
					return;
				}
				mobjLinkVisitedLinkColor = value;
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		/// 
		/// Sets the visited link color internal.
		/// </summary>
		/// The visited link color internal.</value>
		internal Color VisitedLinkColorInternal
		{
			set
			{
				if (!value.Equals(VisitedLinkColor))
				{
					mobjLinkVisitedLinkColor = value;
				}
			}
		}

		/// 
		/// Gets the color of the inherited link.
		/// </summary>
		/// The color of the inherited link.</value>
		private Color InheritedLinkColor
		{
			get
			{
				Color linkColor = LinkColor;
				if (linkColor == LinkUtilities.IELinkColor && base.OwningColumn != null && base.OwningColumn is DataGridViewLinkColumn)
				{
					linkColor = ((DataGridViewLinkColumn)base.OwningColumn).LinkColor;
				}
				return linkColor;
			}
		}

		/// 
		/// Gets the color of the inherited active link.
		/// </summary>
		/// The color of the inherited active link.</value>
		private Color InheritedActiveLinkColor
		{
			get
			{
				Color activeLinkColor = ActiveLinkColor;
				if (activeLinkColor == LinkUtilities.IEActiveLinkColor && base.OwningColumn != null && base.OwningColumn is DataGridViewLinkColumn)
				{
					activeLinkColor = ((DataGridViewLinkColumn)base.OwningColumn).ActiveLinkColor;
				}
				return activeLinkColor;
			}
		}

		/// 
		/// Gets the color of the inherited visited link.
		/// </summary>
		/// The color of the inherited visited link.</value>
		private Color InheritedVisitedLinkColor
		{
			get
			{
				Color visitedLinkColor = VisitedLinkColor;
				if (visitedLinkColor == LinkUtilities.IEVisitedLinkColor && base.OwningColumn != null && base.OwningColumn is DataGridViewLinkColumn)
				{
					visitedLinkColor = ((DataGridViewLinkColumn)base.OwningColumn).VisitedLinkColor;
				}
				return visitedLinkColor;
			}
		}

		static DataGridViewLinkCell()
		{
			mobjDefaultFormattedValueType = typeof(string);
			mobjDefaultValueType = typeof(object);
			mobjCellType = typeof(DataGridViewLinkCell);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell"></see> class.</summary>
		public DataGridViewLinkCell()
		{
		}

		/// Indicates whether the row containing the cell will be unshared when a key is released and the cell has focus.</summary>
		/// true if the SPACE key was released, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkCell.TrackVisitedState"></see> property is true, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkCell.LinkVisited"></see> property is false, and the CTRL, ALT, and SHIFT keys are not pressed; otherwise, false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains data about the key press.</param>
		/// <param name="intRowIndex">The index of the row containing the cell.</param>
		protected override bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex)
		{
			return false;
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (!ClientMode && !string.IsNullOrEmpty(Url) && !ReadOnly)
			{
				criticalEventsData.Set("CL");
			}
			return criticalEventsData;
		}

		/// 
		///
		/// </summary>
		/// <param name="objEvent"></param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (!(type == "LinkStateChange"))
			{
				if (type == "Click" && !ReadOnly)
				{
					OpenLink();
				}
			}
			else
			{
				LinkState = (LinkState)Enum.Parse(typeof(LinkState), objEvent["LS"]);
			}
		}

		/// Indicates whether the row containing the cell will be unshared when the mouse button is pressed while the pointer is over the cell.</summary>
		/// true if the mouse pointer is over the link; otherwise, false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
		protected override bool MouseDownUnsharesRow(DataGridViewCellMouseEventArgs e)
		{
			return false;
		}

		/// Indicates whether the row containing the cell will be unshared when the mouse pointer leaves the cell.</summary>
		/// true if the link displayed by the cell is not in the normal state; otherwise, false.</returns>
		/// <param name="intRowIndex">The index of the row containing the cell.</param>
		protected override bool MouseLeaveUnsharesRow(int intRowIndex)
		{
			return false;
		}

		/// Indicates whether the row containing the cell will be unshared when the mouse pointer moves over the cell.</summary>
		/// true if the mouse pointer is over the link and the link is has not yet changed color to reflect the hover state; otherwise, false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
		protected override bool MouseMoveUnsharesRow(DataGridViewCellMouseEventArgs e)
		{
			return false;
		}

		/// Indicates whether the row containing the cell will be unshared when the mouse button is released while the pointer is over the cell. </summary>
		/// true if the mouse pointer is over the link; otherwise, false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
		protected override bool MouseUpUnsharesRow(DataGridViewCellMouseEventArgs e)
		{
			return false;
		}

		/// 
		/// Renders the cell text/value.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objFormatedValue">The formated value.</param>
		protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
		{
			base.RenderCellValue(objContext, objWriter, objFormatedValue);
			if (objFormatedValue != null && objFormatedValue.ToString() != string.Empty)
			{
				objWriter.WriteAttributeText("TX", objFormatedValue.ToString());
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			if (InheritedLinkColor != LinkUtilities.IELinkColor)
			{
				objWriter.WriteAttributeString("LC", CommonUtils.GetHtmlColor(InheritedLinkColor));
			}
			if (InheritedActiveLinkColor != LinkUtilities.IEActiveLinkColor)
			{
				objWriter.WriteAttributeString("ALC", CommonUtils.GetHtmlColor(InheritedActiveLinkColor));
			}
			if (InheritedVisitedLinkColor != LinkUtilities.IEVisitedLinkColor)
			{
				objWriter.WriteAttributeString("VLC", CommonUtils.GetHtmlColor(InheritedVisitedLinkColor));
			}
			if (LinkState == LinkState.Visited)
			{
				objWriter.WriteAttributeString("LS", Convert.ToInt32(LinkState).ToString());
			}
			if (ClientMode && !string.IsNullOrEmpty(Url))
			{
				objWriter.WriteAttributeString("VLB", Url);
			}
		}

		/// 
		/// Renders the cell style attributes.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objCellStyle">The cell style.</param>
		protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
		{
			base.RenderCellStyleAttributes(objWriter, objCellStyle);
			if (objCellStyle != null)
			{
				objWriter.WriteAttributeString("TA", objCellStyle.Alignment.ToString());
			}
		}

		/// Creates an exact copy of this cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:System.Windows.Forms.DataGridViewLinkCell"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewLinkCell dataGridViewLinkCell = ((!(type == mobjCellType)) ? ((DataGridViewLinkCell)Activator.CreateInstance(type)) : new DataGridViewLinkCell());
			CloneInternal(dataGridViewLinkCell);
			if (mobjLinkActiveColor != Color.Empty)
			{
				dataGridViewLinkCell.ActiveLinkColorInternal = ActiveLinkColor;
			}
			if (mintLinkUseColumnTextForLinkValue != 0)
			{
				dataGridViewLinkCell.UseColumnTextForLinkValueInternal = UseColumnTextForLinkValue;
			}
			if (menmLinkBehavior != LinkBehavior.SystemDefault)
			{
				dataGridViewLinkCell.LinkBehaviorInternal = LinkBehavior;
			}
			if (mobjLinkColor != Color.Empty)
			{
				dataGridViewLinkCell.LinkColorInternal = LinkColor;
			}
			if (mintLinkTrackVisitedState != 0)
			{
				dataGridViewLinkCell.TrackVisitedStateInternal = TrackVisitedState;
			}
			if (mobjLinkVisitedLinkColor != Color.Empty)
			{
				dataGridViewLinkCell.VisitedLinkColorInternal = VisitedLinkColor;
			}
			if (mblnLinkVisitedSet)
			{
				dataGridViewLinkCell.LinkVisited = LinkVisited;
			}
			if (Url != string.Empty)
			{
				dataGridViewLinkCell.Url = Url;
			}
			dataGridViewLinkCell.ClientMode = ClientMode;
			return dataGridViewLinkCell;
		}

		/// 
		/// Gets the value of the cell.
		/// </summary>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// 
		/// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.
		/// </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
		protected override object GetValue(int intRowIndex)
		{
			if (UseColumnTextForLinkValue && base.DataGridView != null && base.DataGridView.NewRowIndex != intRowIndex && base.OwningColumn != null && base.OwningColumn is DataGridViewLinkColumn)
			{
				return ((DataGridViewLinkColumn)base.OwningColumn).Text;
			}
			return base.GetValue(intRowIndex);
		}

		private bool LinkBoundsContainPoint(int intX, int intY, int intRowIndex)
		{
			return false;
		}

		/// 
		/// Shoulds the color of the serialize active link.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeActiveLinkColor()
		{
			return !ActiveLinkColor.Equals(LinkUtilities.IEActiveLinkColor);
		}

		/// 
		/// Shoulds the color of the serialize link.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeLinkColor()
		{
			return !LinkColor.Equals(LinkUtilities.IELinkColor);
		}

		/// 
		/// Shoulds the color of the serialize visited link.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeVisitedLinkColor()
		{
			return !VisitedLinkColor.Equals(LinkUtilities.IEVisitedLinkColor);
		}

		/// 
		/// Returns a string that describes the current object.
		/// </summary>
		/// 
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			return "DataGridViewLinkCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
		}

		/// 
		/// Open the Link in the URL in a new window
		/// </summary>
		protected void OpenLink()
		{
			if (!ClientMode && !string.IsNullOrEmpty(Url))
			{
				LinkLabel.Link link = new LinkLabel.Link(Url);
				if (link != null)
				{
					LinkLabel.Link.Open(link);
				}
			}
		}
	}
}
