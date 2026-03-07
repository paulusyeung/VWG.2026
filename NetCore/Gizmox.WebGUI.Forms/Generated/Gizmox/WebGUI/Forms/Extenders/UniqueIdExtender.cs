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

namespace Gizmox.WebGUI.Forms.Extenders
{
	/// 
	/// 	UniqueIdExtender adds the ability to sets a unique id to a control.</para>
	/// 	Since Visual WebGui optimizes its requests we can not lean on the internal
	///     ids of components specified by the server.</para>
	/// 	By uniquely identifying anchor components, we ensure that those Ids will be
	///     sent back from the server at any response so that we would be able to lean on ids
	///     in order to create valuable replays.</para>
	/// </summary>
	/// 
	///     This shows how to use a <span style="COLOR: #2b91af">UniqueIdExtender</span> and
	///     anchor controls to a spesific id.
	///     <code lang="CS">
	/// 		<![CDATA[
	///     //Create a global unique Identifiers extender object: 
	///
	///     UniqueIdExtender mobjUniqueIdExtender = new UniqueIdExtender();
	///
	///     //Then use it to set Unique-Ids to your anchor components and items:
	///
	///     mobjUniqueIdExtender.SetUniqueId(button1, "B1");
	///
	///     //If you are using control with children controls such as DataGrid or ListView
	///     //remember to unique identify all created items 
	///
	///     DataClasses1DataContext objDataClasses = new DataClasses1DataContext();
	///     foreach (Employee objEmployee in objDataClasses.Employees)
	///     {
	///         ListViewItem mobjListViewItem = new ListViewItem(new string[] 
	///             {objEmployee.EmployeeID.ToString(), objEmployee.FirstName, objEmployee.LastName,
	///             objEmployee.Title, objEmployee.Country});
	///         mobjUniqueIdExtender.SetUniqueId(listView1,string.Format("LI{0}", objEmployee.EmployeeID));
	///
	///         listView1.Items.Add(mobjListViewItem);
	///     }
	///     ]]>
	/// 	</code>
	/// 	<code lang="VB">
	/// 		<![CDATA[
	///     'Create a global unique Identifiers extender object: 
	///
	///     Dim mobjUniqueIdExtender As New UniqueIdExtender()
	///
	///     'Then use it to set Unique-Ids to your anchor components and items:
	///
	///     mobjUniqueIdExtender.SetUniqueId(Button1, "B1")
	///
	///     'If you are using control with children controls such as DataGrid or ListView
	///     'remember to unique identify all created items 
	///     Dim objDataClasses As New DataClasses1DataContext()
	///
	///     For Each objEmployee As Employee In objDataClasses.Employees
	///         Dim mobjListViewItem As New ListViewItem(New String() {objEmployee.EmployeeID.ToString(), objEmployee.FirstName, objEmployee.LastName, objEmployee.Title, objEmployee.Country})
	///         mobjUniqueIdExtender.SetUniqueId(ListView1, String.Format("LI{0}", objEmployee.EmployeeID))
	///         ListView1.Items.Add(mobjListViewItem)
	///     Next]]>
	/// 	</code>
	/// </example>
	/// 
	/// 	You nee to add a using/import to <font size="2">Gizmox.WebGUI.Forms.Extenders
	///     to the form</font></para>
	/// </requirements>
	[Serializable]
	[ProvideProperty("UniqueId", typeof(Component))]
	[ToolboxItem(false)]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	public class UniqueIdExtender : ComponentBase, IExtenderProvider
	{
		/// 
		/// Sets the unique id.
		/// </summary>
		/// <param name="objComponent">The component.</param>
		/// <param name="strId">The unique id.</param>
		public void SetUniqueId(Component objComponent, string strId)
		{
			((IAttributeExtender)objComponent)?.SetAttribute("CUID", strId);
		}

		/// 
		/// Gets the unique id.
		/// </summary>
		/// <param name="objComponent">The component.</param>
		/// </returns>
		[Description("Defines the component unique id.")]
		[DefaultValue("")]
		public string GetUniqueId(Component objComponent)
		{
			if (objComponent != null)
			{
				return ((IAttributeExtender)objComponent).GetAttribute("CUID");
			}
			return string.Empty;
		}

		/// 
		/// Specifies whether this object can provide its extender properties to the specified object.
		/// </summary>
		/// <param name="objExtendee">The <see cref="T:System.Object" /> to receive the extender properties.</param>
		/// 
		/// true if this object can provide extender properties to the specified object; otherwise, false.
		/// </returns>
		public bool CanExtend(object objExtendee)
		{
			return objExtendee is Component;
		}
	}
}
