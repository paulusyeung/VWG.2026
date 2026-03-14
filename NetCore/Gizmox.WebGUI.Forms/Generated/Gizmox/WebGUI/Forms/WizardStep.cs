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
	internal abstract class WizardStep : UserControl
	{
		private WizardStep mobjPrevious;

		private WizardStep mobjNext;

		private WizardForm mobjWizardForm;

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		public override DockStyle Dock
		{
			get
			{
				return DockStyle.Fill;
			}
			set
			{
			}
		}

		/// 
		/// Gets a value indicating whether this instance can navigate next.
		/// </summary>
		/// 
		/// 	true</c> if this instance can navigate next; otherwise, false</c>.
		/// </value>
		protected internal virtual bool CanNavigateNext => true;

		/// 
		/// Gets a value indicating whether this instance can navigate previous.
		/// </summary>
		/// 
		/// 	true</c> if this instance can navigate previous; otherwise, false</c>.
		/// </value>
		protected internal virtual bool CanNavigatePrevious => false;

		/// 
		/// Gets the caption.
		/// </summary>
		protected internal virtual string Caption => string.Empty;

		/// 
		/// Gets the previous page.
		/// </summary>
		protected internal virtual WizardStep PreviousPage => mobjPrevious;

		/// 
		/// Gets the next page.
		/// </summary>
		protected internal virtual WizardStep NextPage => mobjNext;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WizardStep" /> class.
		/// </summary>
		public WizardStep()
		{
		}

		/// 
		/// Gets the next page.
		/// </summary>
		/// </returns>
		protected internal virtual WizardStep GetNextPage()
		{
			return mobjNext;
		}

		/// 
		/// Gets the previous page.
		/// </summary>
		/// </returns>
		protected internal virtual WizardStep GetPreviousPage()
		{
			return mobjPrevious;
		}

		/// 
		/// Sets the next step.
		/// </summary>
		/// <param name="objCurrentStep">The obj current step.</param>
		internal void SetNextStep(WizardStep objCurrentStep)
		{
			mobjNext = objCurrentStep;
		}

		/// 
		/// Sets the previous step.
		/// </summary>
		/// <param name="objPreviousStep">The obj previous step.</param>
		internal void SetPreviousStep(WizardStep objPreviousStep)
		{
			mobjPrevious = objPreviousStep;
		}

		/// 
		/// Sets the wizard form.
		/// </summary>
		/// <param name="objWizardForm">The obj wizard form.</param>
		internal void SetWizardForm(WizardForm objWizardForm)
		{
			mobjWizardForm = objWizardForm;
		}

		/// 
		/// Updates the wizard.
		/// </summary>
		protected void UpdateWizard()
		{
			mobjWizardForm.UpdateWizard();
		}

		/// 
		/// Sets the message.
		/// </summary>
		/// <param name="strMessage">The STR message.</param>
		/// <param name="enmMessageType">Type of the enm message.</param>
		protected void SetMessage(string strMessage, MessageType enmMessageType)
		{
			mobjWizardForm.SetMessage(strMessage, enmMessageType);
		}

		/// 
		/// Called when [next].
		/// </summary>
		/// </returns>
		protected internal virtual bool OnNext()
		{
			return CanNavigateNext;
		}

		/// 
		/// Called when [previous].
		/// </summary>
		/// </returns>
		protected internal virtual bool OnPrevious()
		{
			return CanNavigatePrevious;
		}

		/// 
		/// Activates this instance.
		/// </summary>
		protected internal virtual void Activate()
		{
		}
	}
}
