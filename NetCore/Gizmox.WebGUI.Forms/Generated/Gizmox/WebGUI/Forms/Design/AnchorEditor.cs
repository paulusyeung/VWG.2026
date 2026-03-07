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

namespace Gizmox.WebGUI.Forms.Design
{
	/// 
	///
	/// </summary>
	[Serializable]
	public class AnchorEditor : WebUITypeEditor
	{
		[Serializable]
		private class AnchorEditorDropDown : Form
		{
			private AnchorPanel mobjPanelTop;

			private AnchorPanel mobjPanelBottom;

			private AnchorPanel mobjPanelLeft;

			private AnchorPanel mobjPanelRight;

			private Panel mobjPanelCenter;

			private bool mblnIsCompleted = true;

			private bool mblnTop = false;

			private bool mblnBottom = false;

			private bool mblnLeft = false;

			private bool mblnRight = false;

			private AnchorStyles mobjValue = AnchorStyles.None;

			public AnchorStyles Value
			{
				get
				{
					return mobjValue;
				}
				set
				{
					if (mobjValue != value)
					{
						mblnLeft = (value & AnchorStyles.Left) == AnchorStyles.Left;
						mblnRight = (value & AnchorStyles.Right) == AnchorStyles.Right;
						mblnTop = (value & AnchorStyles.Top) == AnchorStyles.Top;
						mblnBottom = (value & AnchorStyles.Bottom) == AnchorStyles.Bottom;
						UpdateAnchoring();
						mobjValue = value;
					}
				}
			}

			public bool IsCompleted => mblnIsCompleted;

			/// 
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				mobjPanelTop = new AnchorPanel();
				mobjPanelBottom = new AnchorPanel();
				mobjPanelLeft = new AnchorPanel();
				mobjPanelRight = new AnchorPanel();
				mobjPanelCenter = new Panel();
				SuspendLayout();
				mobjPanelTop.BackColor = SystemColors.ControlDarkDark;
				mobjPanelTop.DragTargets = new Control[0];
				mobjPanelTop.Location = new Point(68, 0);
				mobjPanelTop.Name = "mobjPanelTop";
				mobjPanelTop.Size = new Size(9, 25);
				mobjPanelTop.TabIndex = 0;
				mobjPanelTop.Click += mobjPanelTop_Click;
				mobjPanelBottom.BackColor = SystemColors.ControlDarkDark;
				mobjPanelBottom.DragTargets = new Control[0];
				mobjPanelBottom.Location = new Point(68, 67);
				mobjPanelBottom.Name = "mobjPanelBottom";
				mobjPanelBottom.Size = new Size(9, 25);
				mobjPanelBottom.TabIndex = 1;
				mobjPanelBottom.Click += mobjPanelBottom_Click;
				mobjPanelLeft.BackColor = SystemColors.ControlDarkDark;
				mobjPanelLeft.DragTargets = new Control[0];
				mobjPanelLeft.Location = new Point(0, 41);
				mobjPanelLeft.Name = "mobjPanelLeft";
				mobjPanelLeft.Size = new Size(25, 10);
				mobjPanelLeft.TabIndex = 2;
				mobjPanelLeft.Click += mobjPanelLeft_Click;
				mobjPanelRight.BackColor = SystemColors.ControlDarkDark;
				mobjPanelRight.DragTargets = new Control[0];
				mobjPanelRight.Location = new Point(120, 41);
				mobjPanelRight.Name = "mobjPanelRight";
				mobjPanelRight.Size = new Size(25, 10);
				mobjPanelRight.TabIndex = 3;
				mobjPanelRight.Click += mobjPanelRight_Click;
				mobjPanelCenter.BackColor = Color.FromArgb(200, 200, 200);
				mobjPanelCenter.DragTargets = new Control[0];
				mobjPanelCenter.Location = new Point(27, 27);
				mobjPanelCenter.Name = "mobjPanelCenter";
				mobjPanelCenter.Size = new Size(91, 38);
				mobjPanelCenter.TabIndex = 4;
				Anchor = AnchorStyles.Left;
				base.Controls.Add(mobjPanelCenter);
				base.Controls.Add(mobjPanelRight);
				base.Controls.Add(mobjPanelLeft);
				base.Controls.Add(mobjPanelBottom);
				base.Controls.Add(mobjPanelTop);
				DragTargets = new Control[0];
				base.Size = new Size(145, 92);
				Text = "AnchorEditorDropDown";
				ResumeLayout(blnPerformLayout: false);
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.AnchorEditor.AnchorEditorDropDown" /> class.
			/// </summary>
			public AnchorEditorDropDown()
			{
				InitializeComponent();
			}

			private void mobjPanelTop_Click(object sender, EventArgs e)
			{
				mblnTop = !mblnTop;
				UpdateAnchoring();
				UpdateValue();
			}

			private void mobjPanelRight_Click(object sender, EventArgs e)
			{
				mblnRight = !mblnRight;
				UpdateAnchoring();
				UpdateValue();
			}

			private void mobjPanelLeft_Click(object sender, EventArgs e)
			{
				mblnLeft = !mblnLeft;
				UpdateAnchoring();
				UpdateValue();
			}

			private void mobjPanelBottom_Click(object sender, EventArgs e)
			{
				mblnBottom = !mblnBottom;
				UpdateAnchoring();
				UpdateValue();
			}

			private void UpdateAnchoring()
			{
				Color white = Color.White;
				Color color = Color.FromKnownColor(KnownColor.ControlDarkDark);
				mobjPanelTop.BackColor = (mblnTop ? color : white);
				mobjPanelBottom.BackColor = (mblnBottom ? color : white);
				mobjPanelLeft.BackColor = (mblnLeft ? color : white);
				mobjPanelRight.BackColor = (mblnRight ? color : white);
			}

			private void UpdateValue()
			{
				AnchorStyles anchorStyles = AnchorStyles.None;
				if (mblnLeft)
				{
					anchorStyles |= AnchorStyles.Left;
				}
				if (mblnTop)
				{
					anchorStyles |= AnchorStyles.Top;
				}
				if (mblnBottom)
				{
					anchorStyles |= AnchorStyles.Bottom;
				}
				if (mblnRight)
				{
					anchorStyles |= AnchorStyles.Right;
				}
				mobjValue = anchorStyles;
			}
		}

		private WebUITypeEditorHandler mobjHandler = null;

		private AnchorStyles mobjPropertyValue = AnchorStyles.None;

		/// 
		/// Gets the property value.
		/// </summary>
		/// The property value.</value>
		protected AnchorStyles PropertyValue => mobjPropertyValue;

		/// 
		/// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
		/// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
		/// <param name="objValue">The object to edit.</param>
		/// <param name="objHandler">The obj handler.</param>
		public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
		{
			AnchorEditorDropDown anchorEditorDropDown = new AnchorEditorDropDown();
			anchorEditorDropDown.Value = (AnchorStyles)GetEditorValueFromPropertyValue(objValue);
			anchorEditorDropDown.Closed += objAnchorDialog_Closed;
			mobjPropertyValue = anchorEditorDropDown.Anchor;
			mobjHandler = objHandler;
			if (objProvider.GetService(typeof(IWebUIEditorService)) is IWebUIEditorService webUIEditorService)
			{
				webUIEditorService.ShowDropDown(anchorEditorDropDown);
			}
		}

		private void objAnchorDialog_Closed(object sender, EventArgs e)
		{
			AnchorEditorDropDown anchorEditorDropDown = (AnchorEditorDropDown)sender;
			if (anchorEditorDropDown.IsCompleted && mobjHandler != null)
			{
				object obj = null;
				try
				{
					obj = GetPropertyValueFromEditorValue(anchorEditorDropDown.Value);
				}
				catch (Exception objException)
				{
					OnValueChangeError(objException);
					return;
				}
				mobjHandler(obj);
			}
		}

		/// 
		/// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
		/// 
		/// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}
}
