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
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	internal class MainContent : ContentChangeNotifierUserControl, IContentUpdateable
	{
		/// 
		/// The mobj administration tabs
		/// </summary>
		private AdministrationTabs mobjAdministrationTabs;

		/// 
		/// The mobj devider panel
		/// </summary>
		private Panel mobjDeviderPanel;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MainContent" /> class.
		/// </summary>
		public MainContent()
		{
			InitializeComponent();
		}

		/// 
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent()
		{
			mobjDeviderPanel = new Panel();
			mobjAdministrationTabs = new AdministrationTabs();
			mobjDeviderPanel.Dock = DockStyle.Top;
			mobjDeviderPanel.Height = 30;
			mobjDeviderPanel.BackColor = Color.Transparent;
			mobjAdministrationTabs.Dock = DockStyle.Fill;
			mobjAdministrationTabs.SelectedIndexChanged += mobjAdministrationTabs_SelectedIndexChanged;
			base.Load += MainContent_Load;
			base.Controls.Add(mobjAdministrationTabs);
			base.Controls.Add(mobjDeviderPanel);
		}

		/// 
		/// Handles the SelectedIndexChanged event of the mobjAdministrationTabs control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjAdministrationTabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateContentState();
		}

		internal void UpdateContentState()
		{
			if (mobjAdministrationTabs.SelectedTab is AdministrationTabPage administrationTabPage)
			{
				bool fullScreen = administrationTabPage.Content.ContentProperties.FullScreen;
				administrationTabPage.SetFullScrean(fullScreen);
				if (fullScreen)
				{
					mobjDeviderPanel.Visible = false;
					mobjAdministrationTabs.Appearance = TabAppearance.Logical;
				}
				else
				{
					mobjDeviderPanel.Visible = true;
					mobjAdministrationTabs.Appearance = TabAppearance.Normal;
				}
				if (Context.Arguments["hosted"] != null && Context.Arguments["hosted"] == "1")
				{
					mobjAdministrationTabs.Appearance = TabAppearance.Logical;
				}
			}
			OnContentChanged();
		}

		/// 
		/// Handles the Load event of the MainContent control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void MainContent_Load(object sender, EventArgs e)
		{
			PopulateTabs();
			RedirectByArguments();
		}

		/// 
		/// Checks for "page" and "form" arguments in the querystring for redirecting to a specified page and form
		/// </summary>
		private void RedirectByArguments()
		{
			if (Context.Arguments["page"] == null)
			{
				return;
			}
			string text = Context.Arguments["page"];
			foreach (AdministrationTabPage tabPage in mobjAdministrationTabs.TabPages)
			{
				if (tabPage.Name == text.ToLower())
				{
					mobjAdministrationTabs.SelectedIndex = tabPage.TabIndex;
					mobjAdministrationTabs.Update();
				}
				if (Context.Arguments["form"] != null)
				{
					string objData = Context.Arguments["form"];
					tabPage.Content.PerformAutomateAction(objData);
				}
			}
		}

		/// 
		/// Populates the tabs.
		/// </summary>
		private void PopulateTabs()
		{
			List<AdministrationContent> supportedAdministrationContent = GetSupportedAdministrationContent();
			supportedAdministrationContent.Sort(new AdministrationContent.AdministrationContentSorter());
			foreach (AdministrationContent item in supportedAdministrationContent)
			{
				AdministrationTabPage objTabPage = new AdministrationTabPage(item);
				mobjAdministrationTabs.TabPages.Add(objTabPage);
			}
		}

		/// 
		/// Gets the content of the supported administration.
		/// </summary>
		/// </returns>
		private List<AdministrationContent> GetSupportedAdministrationContent()
		{
			List<AdministrationContent> list = new List<AdministrationContent>();
			List<Type> administrationContentTypesList = GetAdministrationContentTypesList();
			foreach (Type item2 in administrationContentTypesList)
			{
				if (item2 != null && Activator.CreateInstance(item2) is AdministrationContent item)
				{
					list.Add(item);
				}
			}
			return list;
		}

		/// 
		/// Gets the administration content types list.
		/// </summary>
		/// </returns>
		private List<Type> GetAdministrationContentTypesList()
		{
			List<Type> list = new List<Type>();
			Type[] types = GetType().Assembly.GetTypes();
			foreach (Type type in types)
			{
				if (!type.IsAbstract && typeof(AdministrationContent).IsAssignableFrom(type))
				{
					list.Add(type);
				}
			}
			Type emulationFormNodeType = GetEmulationFormNodeType();
			if (emulationFormNodeType != null)
			{
				list.Add(emulationFormNodeType);
			}
			return list;
		}

		/// 
		/// Gets the type of the emulation form node.
		/// </summary>
		/// </returns>
		private Type GetEmulationFormNodeType()
		{
			string typeName = string.Format("{0}, {1}", "Gizmox.WebGUI.Forms.EmulationContentControl", CommonUtils.GetFullAssemblyName("Gizmox.WebGUI.Emulation"));
			return Type.GetType(typeName);
		}

		/// 
		/// Gets the name of the current content.
		/// </summary>
		/// </returns>
		public override string GetCurrentContentName()
		{
			if (mobjAdministrationTabs.SelectedTab is AdministrationTabPage administrationTabPage)
			{
				ContentProperties contentProperties = administrationTabPage.Content.ContentProperties;
				if (contentProperties != null && !string.IsNullOrEmpty(contentProperties.ContentName))
				{
					if (!string.IsNullOrEmpty(contentProperties.ContentDescription))
					{
						return $"{contentProperties.ContentName} - {contentProperties.ContentDescription}";
					}
					return $"{contentProperties.ContentName}";
				}
			}
			return string.Empty;
		}

		/// 
		/// Updates the content.
		/// </summary>
		void IContentUpdateable.UpdateContent()
		{
			UpdateContentState();
		}

		/// 
		/// Gets the status.
		/// </summary>
		/// </returns>
		public override List<Gizmox.WebGUI.Forms.Administration.Abstract.StatusData> GetStatus()
		{
			if (mobjAdministrationTabs.SelectedTab is AdministrationTabPage administrationTabPage)
			{
				ContentProperties contentProperties = administrationTabPage.Content.ContentProperties;
				return contentProperties.StatusData;
			}
			return null;
		}
	}
}
