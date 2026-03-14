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
	/// Provides a user interface for specifying a Dock property.
	/// </summary>
	[Serializable]
	public class DockEditor : WebUITypeEditor
	{
		[Serializable]
		private class DockEditorDropDown : Form
		{
			private DockButton mobjButtonNone;

			private DockButton mobjButtonTop;

			private DockButton mobjButtonBottom;

			private DockButton mobjButtonLeft;

			private DockButton mobjButtonRight;

			private DockButton mobjButtonFill;

			private DockStyle menmValue = DockStyle.None;

			private bool mblnIsCompleted = false;

			/// 
			/// Gets/Sets the controls docking style
			/// </summary>
			/// </value>
			public new DockStyle Dock
			{
				get
				{
					return menmValue;
				}
				set
				{
					menmValue = value;
				}
			}

			public bool IsCompleted => mblnIsCompleted;

			public DockEditorDropDown()
			{
				InitializeComponent();
			}

			/// 
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				mobjButtonNone = new DockButton();
				mobjButtonTop = new DockButton();
				mobjButtonBottom = new DockButton();
				mobjButtonLeft = new DockButton();
				mobjButtonRight = new DockButton();
				mobjButtonFill = new DockButton();
				SuspendLayout();
				mobjButtonNone.Dock = DockStyle.Bottom;
				mobjButtonNone.Location = new Point(0, 103);
				mobjButtonNone.Name = "mobjButtonNone";
				mobjButtonNone.Size = new Size(144, 23);
				mobjButtonNone.TabIndex = 0;
				mobjButtonNone.Text = "None";
				mobjButtonNone.Click += mobjButtonNone_Click;
				mobjButtonTop.Dock = DockStyle.Top;
				mobjButtonTop.Location = new Point(0, 0);
				mobjButtonTop.Name = "mobjButtonTop";
				mobjButtonTop.Size = new Size(144, 20);
				mobjButtonTop.TabIndex = 1;
				mobjButtonTop.Click += mobjButtonTop_Click;
				mobjButtonBottom.Dock = DockStyle.Bottom;
				mobjButtonBottom.Location = new Point(0, 83);
				mobjButtonBottom.Name = "mobjButtonBottom";
				mobjButtonBottom.Size = new Size(144, 20);
				mobjButtonBottom.TabIndex = 2;
				mobjButtonBottom.Click += mobjButtonBottom_Click;
				mobjButtonLeft.Dock = DockStyle.Left;
				mobjButtonLeft.Location = new Point(0, 20);
				mobjButtonLeft.Name = "mobjButtonLeft";
				mobjButtonLeft.Size = new Size(20, 63);
				mobjButtonLeft.TabIndex = 3;
				mobjButtonLeft.Click += mobjButtonLeft_Click;
				mobjButtonRight.Dock = DockStyle.Right;
				mobjButtonRight.Location = new Point(124, 20);
				mobjButtonRight.Name = "mobjButtonRight";
				mobjButtonRight.Size = new Size(20, 63);
				mobjButtonRight.TabIndex = 4;
				mobjButtonRight.Click += mobjButtonRight_Click;
				mobjButtonFill.Dock = DockStyle.Fill;
				mobjButtonFill.Location = new Point(20, 20);
				mobjButtonFill.Name = "mobjButtonFill";
				mobjButtonFill.Size = new Size(104, 63);
				mobjButtonFill.TabIndex = 5;
				mobjButtonFill.Click += mobjButtonFill_Click;
				base.ClientSize = new Size(144, 126);
				base.Controls.Add(mobjButtonFill);
				base.Controls.Add(mobjButtonRight);
				base.Controls.Add(mobjButtonLeft);
				base.Controls.Add(mobjButtonBottom);
				base.Controls.Add(mobjButtonTop);
				base.Controls.Add(mobjButtonNone);
				base.Name = "Form3";
				Text = "Form3";
				ResumeLayout(blnPerformLayout: false);
			}

			private void mobjButtonTop_Click(object sender, EventArgs e)
			{
				menmValue = DockStyle.Top;
				mblnIsCompleted = true;
				Close();
			}

			private void mobjButtonRight_Click(object sender, EventArgs e)
			{
				menmValue = DockStyle.Right;
				mblnIsCompleted = true;
				Close();
			}

			private void mobjButtonFill_Click(object sender, EventArgs e)
			{
				menmValue = DockStyle.Fill;
				mblnIsCompleted = true;
				Close();
			}

			private void mobjButtonLeft_Click(object sender, EventArgs e)
			{
				menmValue = DockStyle.Left;
				mblnIsCompleted = true;
				Close();
			}

			private void mobjButtonBottom_Click(object sender, EventArgs e)
			{
				menmValue = DockStyle.Bottom;
				mblnIsCompleted = true;
				Close();
			}

			private void mobjButtonNone_Click(object sender, EventArgs e)
			{
				menmValue = DockStyle.None;
				mblnIsCompleted = true;
				Close();
			}
		}

		private WebUITypeEditorHandler mobjHandler = null;

		private DockStyle menmPropertyValue = DockStyle.None;

		/// 
		/// Gets the property value.
		/// </summary>
		/// The property value.</value>
		protected DockStyle PropertyValue => menmPropertyValue;

		/// 
		/// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
		/// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
		/// <param name="objValue">The object to edit.</param>
		/// <param name="objHandler">The obj handler.</param>
		public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
		{
			DockEditorDropDown dockEditorDropDown = new DockEditorDropDown();
			dockEditorDropDown.Dock = (DockStyle)GetEditorValueFromPropertyValue(objValue);
			dockEditorDropDown.Closed += objDockDialog_Closed;
			menmPropertyValue = dockEditorDropDown.Dock;
			mobjHandler = objHandler;
			if (objProvider.GetService(typeof(IWebUIEditorService)) is IWebUIEditorService webUIEditorService)
			{
				webUIEditorService.ShowDropDown(dockEditorDropDown);
			}
		}

		private void objDockDialog_Closed(object sender, EventArgs e)
		{
			DockEditorDropDown dockEditorDropDown = (DockEditorDropDown)sender;
			if (dockEditorDropDown.IsCompleted && mobjHandler != null)
			{
				object obj = null;
				try
				{
					obj = GetPropertyValueFromEditorValue(dockEditorDropDown.Dock);
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
