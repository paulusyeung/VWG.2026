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
	/// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class DataGridViewDataErrorEventArgs : DataGridViewCellCancelEventArgs
	{
		private DataGridViewDataErrorContexts menmContext;

		private Exception mobjException;

		private bool mblnThrowException;

		/// Gets details about the state of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the error occurred.</summary>
		/// A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which the error occurred.</returns>
		/// 1</filterpriority>
		public DataGridViewDataErrorContexts Context => menmContext;

		/// Gets the exception that represents the error.</summary>
		/// An <see cref="T:System.Exception"></see> that represents the error.</returns>
		/// 1</filterpriority>
		public Exception Exception => mobjException;

		/// Gets or sets a value indicating whether to throw the exception after the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventHandler"></see> delegate is finished with it.</summary>
		/// true if the exception should be thrown; otherwise, false. The default is false.</returns>
		/// <exception cref="T:System.ArgumentException">When setting this property to true, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.Exception"></see> property value is null.</exception>
		/// 1</filterpriority>
		public bool ThrowException
		{
			get
			{
				return mblnThrowException;
			}
			set
			{
				if (value && mobjException == null)
				{
					throw new ArgumentException(SR.GetString("DataGridView_CannotThrowNullException"));
				}
				mblnThrowException = value;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs"></see> class.</summary>
		/// <param name="objException">The exception that occurred.</param>
		/// <param name="intColumnIndex">The column index of the cell that raised the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see>.</param>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values indicating the context in which the error occurred. </param>
		/// <param name="intRowIndex">The row index of the cell that raised the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see>.</param>
		public DataGridViewDataErrorEventArgs(Exception objException, int intColumnIndex, int intRowIndex, DataGridViewDataErrorContexts enmContext)
			: base(intColumnIndex, intRowIndex)
		{
			mobjException = objException;
			menmContext = enmContext;
		}
	}
}
