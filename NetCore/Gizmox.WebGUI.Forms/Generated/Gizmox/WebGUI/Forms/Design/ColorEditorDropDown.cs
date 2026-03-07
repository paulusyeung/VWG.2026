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
	[Serializable]
	internal class ColorEditorDropDown : Form
	{
		private TabControl mobjTabControl;

		private TabPage mobjTabCustom;

		private TabPage mobjTabWeb;

		private TabPage mobjTabSystem;

		private ColorListBox mobjListWeb;

		private ColorListBox mobjListSystem;

		private bool mblnIsCompleted = false;

		private Color mobjColor = Color.Empty;

		private static Color[] marrWebColors;

		private static Color[] marrSystemColors;

		public Color Color
		{
			get
			{
				return mobjColor;
			}
			set
			{
				mobjColor = value;
			}
		}

		public bool IsCompleted => mblnIsCompleted;

		public ColorEditorDropDown()
		{
			InitializeComponenet();
			base.Load += ColorEditorDropDown_Load;
		}

		private void ColorEditorDropDown_Load(object sender, EventArgs e)
		{
			TabControlSkin tabControlCurrentSkin = mobjTabControl.TabControlCurrentSkin;
			if (tabControlCurrentSkin != null)
			{
				base.Height += tabControlCurrentSkin.TopFrameHeight + tabControlCurrentSkin.BottomFrameHeight + tabControlCurrentSkin.SeperatorFrameHeight;
				base.Width += tabControlCurrentSkin.LeftFrameWidth + tabControlCurrentSkin.RightFrameWidth;
			}
			mobjTabControl.SelectedIndex = 0;
			mobjListSystem.Items.AddRange(GetSystemColors());
			mobjListWeb.Items.AddRange(GetWebColors());
			InitializePalette(mobjTabCustom, GetWebColors());
		}

		private static Color[] GetWebColors()
		{
			if (marrWebColors == null)
			{
				marrWebColors = GetConstants(typeof(Color));
			}
			return marrWebColors;
		}

		private static Color[] GetSystemColors()
		{
			if (marrSystemColors == null)
			{
				marrSystemColors = GetConstants(typeof(SystemColors));
			}
			return marrSystemColors;
		}

		private static Color[] GetConstants(Type objEnumType)
		{
			MethodAttributes methodAttributes = MethodAttributes.Public | MethodAttributes.Static;
			PropertyInfo[] properties = objEnumType.GetProperties();
			ArrayList arrayList = new ArrayList();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.PropertyType == typeof(Color))
				{
					MethodInfo getMethod = propertyInfo.GetGetMethod();
					if (getMethod != null && (getMethod.Attributes & methodAttributes) == methodAttributes)
					{
						object[] index = null;
						arrayList.Add(propertyInfo.GetValue(null, index));
					}
				}
			}
			return (Color[])arrayList.ToArray(typeof(Color));
		}

		private void InitializePalette(TabPage objTabPage, Color[] arrColors)
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Panel panel = new Panel();
					panel.Location = new Point(6 + j * 26, 6 + i * 26);
					panel.Size = new Size(20, 20);
					panel.BorderStyle = BorderStyle.FixedSingle;
					panel.Click += objPanel_Click;
					if (arrColors.Length > num)
					{
						Color color = (panel.BackColor = arrColors[num]);
						panel.Tag = color;
					}
					else
					{
						Color color = (panel.BackColor = Color.White);
						panel.Tag = color;
					}
					objTabPage.Controls.Add(panel);
					num++;
				}
			}
		}

		private void InitializeComponenet()
		{
			mobjTabControl = new TabControl();
			mobjTabCustom = new TabPage();
			mobjTabWeb = new TabPage();
			mobjListWeb = new ColorListBox();
			mobjTabSystem = new TabPage();
			mobjListSystem = new ColorListBox();
			mobjTabControl.SuspendLayout();
			mobjTabWeb.SuspendLayout();
			mobjTabSystem.SuspendLayout();
			SuspendLayout();
			mobjTabControl.Controls.Add(mobjTabCustom);
			mobjTabControl.Controls.Add(mobjTabWeb);
			mobjTabControl.Controls.Add(mobjTabSystem);
			mobjTabControl.Dock = DockStyle.Fill;
			mobjTabControl.Location = new Point(0, 0);
			mobjTabControl.Name = "tabControl1";
			mobjTabControl.SelectedIndex = 0;
			mobjTabControl.Size = new Size(224, 242);
			mobjTabControl.TabIndex = 0;
			mobjTabControl.BorderStyle = BorderStyle.FixedSingle;
			mobjTabControl.Multiline = false;
			mobjTabCustom.Location = new Point(4, 22);
			mobjTabCustom.Name = "mobjTabCustom";
			mobjTabCustom.Padding = new Padding(2);
			mobjTabCustom.Size = new Size(216, 216);
			mobjTabCustom.TabIndex = 0;
			mobjTabCustom.Text = "Custom";
			mobjTabCustom.AutoScroll = false;
			mobjTabWeb.Controls.Add(mobjListWeb);
			mobjTabWeb.Location = new Point(4, 22);
			mobjTabWeb.Name = "mobjTabWeb";
			mobjTabWeb.Padding = new Padding(2);
			mobjTabWeb.Size = new Size(216, 216);
			mobjTabWeb.TabIndex = 1;
			mobjTabWeb.Text = "Web";
			mobjListWeb.Dock = DockStyle.Fill;
			mobjListWeb.FormattingEnabled = true;
			mobjListWeb.Location = new Point(3, 3);
			mobjListWeb.Name = "mobjListWeb";
			mobjListWeb.Size = new Size(210, 199);
			mobjListWeb.TabIndex = 0;
			mobjListWeb.SelectedIndexChanged += mobjListWeb_SelectedIndexChanged;
			mobjTabSystem.Controls.Add(mobjListSystem);
			mobjTabSystem.Location = new Point(4, 22);
			mobjTabSystem.Name = "mobjTabSystem";
			mobjTabSystem.Size = new Size(216, 216);
			mobjTabSystem.TabIndex = 2;
			mobjTabSystem.Text = "System";
			mobjTabSystem.Padding = new Padding(2);
			mobjListSystem.Dock = DockStyle.Fill;
			mobjListSystem.FormattingEnabled = true;
			mobjListSystem.Location = new Point(0, 0);
			mobjListSystem.Name = "mobjListSystem";
			mobjListSystem.Size = new Size(216, 212);
			mobjListSystem.TabIndex = 0;
			mobjListSystem.SelectedIndexChanged += mobjListSystem_SelectedIndexChanged;
			base.DockPadding.All = 2;
			base.ClientSize = new Size(224, 242);
			base.Controls.Add(mobjTabControl);
			base.Name = "ColorControl";
			mobjTabControl.ResumeLayout(blnPerformLayout: false);
			mobjTabWeb.ResumeLayout(blnPerformLayout: false);
			mobjTabSystem.ResumeLayout(blnPerformLayout: false);
			ResumeLayout(blnPerformLayout: false);
		}

		private void objPanel_Click(object sender, EventArgs e)
		{
			mblnIsCompleted = true;
			mobjColor = (Color)((Panel)sender).Tag;
			Close();
		}

		public void mobjListWeb_SelectedIndexChanged(object sender, EventArgs e)
		{
			mblnIsCompleted = true;
			mobjColor = (Color)mobjListWeb.SelectedItem;
			Close();
		}

		public void mobjListSystem_SelectedIndexChanged(object sender, EventArgs e)
		{
			mblnIsCompleted = true;
			mobjColor = (Color)mobjListSystem.SelectedItem;
			Close();
		}
	}
}
