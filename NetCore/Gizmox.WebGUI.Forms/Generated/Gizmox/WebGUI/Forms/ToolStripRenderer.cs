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
/// Handles the painting functionality for <see cref="T:System.Windows.Forms.ToolStrip"></see> objects.</summary>
	[Serializable]
	[Obsolete("Not implemented. Added for migration compatibility")]
	public abstract class ToolStripRenderer
	{
		/// Occurs when an arrow on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripArrowRenderEventHandler RenderArrow
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is rendered</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemRenderEventHandler RenderButtonBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> is rendered.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemRenderEventHandler RenderDropDownButtonBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the move handle for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripGripRenderEventHandler RenderGrip
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Draws the margin between an image and its container. </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripRenderEventHandler RenderImageMargin
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemRenderEventHandler RenderItemBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the image for a selected <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemImageRenderEventHandler RenderItemCheck
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the image for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemImageRenderEventHandler RenderItemImage
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the text for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is rendered.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemTextRenderEventHandler RenderItemText
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is rendered.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemRenderEventHandler RenderLabelBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is rendered.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemRenderEventHandler RenderMenuItemBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the background for an overflow button is rendered.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemRenderEventHandler RenderOverflowButtonBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is rendered.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripSeparatorRenderEventHandler RenderSeparator
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is rendered.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemRenderEventHandler RenderSplitButtonBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the display style changes.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripRenderEventHandler RenderStatusStripSizingGrip
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripRenderEventHandler RenderToolStripBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the border for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is rendered.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripRenderEventHandler RenderToolStripBorder
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripContentPanelRenderEventHandler RenderToolStripContentPanelBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripPanelRenderEventHandler RenderToolStripPanelBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Draws the background of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event ToolStripItemRenderEventHandler RenderToolStripStatusLabelBackground
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> class. </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		protected ToolStripRenderer()
		{
		}

		/// Creates a gray-scale copy of a given image.</summary> 
		/// An <see cref="T:System.Drawing.Image"></see> that is a copy of the given image, but with a gray-scale color matrix.</returns> 
		/// <param name="normalImage">The image to be copied. </param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static ResourceHandle CreateDisabledImage(ResourceHandle normalImage)
		{
			return null;
		}

		/// Draws an arrow on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> that contains data to draw the arrow.</param> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawArrow(ToolStripArrowRenderEventArgs e)
		{
		}

		/// Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</summary> 
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains data to draw the button's background.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawButtonBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the drop-down button's background.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Draws a move handle on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs"></see> that contains the data to draw the move handle.</param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawGrip(ToolStripGripRenderEventArgs e)
		{
		}

		/// Draws the space around an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the space around the image.</param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawImageMargin(ToolStripRenderEventArgs e)
		{
		}

		/// Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background of the item.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawItemBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Draws an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that indicates the item is in a selected state.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the data to draw the selected image.</param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawItemCheck(ToolStripItemImageRenderEventArgs e)
		{
		}

		/// Draws an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the data to draw the image.</param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawItemImage(ToolStripItemImageRenderEventArgs e)
		{
		}

		/// Draws text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> that contains the data to draw the text.</param> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawItemText(ToolStripItemTextRenderEventArgs e)
		{
		}

		/// Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background for the label.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawLabelBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the data to draw the background for the menu item.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Draws the background for an overflow button.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawOverflowButtonBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Draws a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs"></see> that contains the data to draw the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawSeparator(ToolStripSeparatorRenderEventArgs e)
		{
		}

		/// Draws a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawSplitButton(ToolStripItemRenderEventArgs e)
		{
		}

		/// Draws a sizing grip.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawStatusStripSizingGrip(ToolStripRenderEventArgs e)
		{
		}

		/// Draws the background for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the background for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawToolStripBackground(ToolStripRenderEventArgs e)
		{
		}

		/// Draws the border for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the data to draw the border for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawToolStripBorder(ToolStripRenderEventArgs e)
		{
		}

		/// Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
		{
		}

		/// Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
		{
		}

		/// Draws the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderArrow"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderButtonBackground"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderDropDownButtonBackground"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderGrip"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderGrip(ToolStripGripRenderEventArgs e)
		{
		}

		/// Draws the item background.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
		}

		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.ToolStripSystemRenderer.OnRenderItemBackground(Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs)"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemCheck"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemImage"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderItemText"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderLabelBackground"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderMenuItemBackground"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderOverflowButtonBackground"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderSeparator"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
		}

		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.ToolStripRenderer.OnRenderSplitButtonBackground(Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs)"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderStatusStripSizingGrip"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripBackground"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripBorder"></see> event. </summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripContentPanelBackground"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripPanelBackground"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripRenderer.RenderToolStripStatusLabelBackground"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
		{
		}
	}
}
