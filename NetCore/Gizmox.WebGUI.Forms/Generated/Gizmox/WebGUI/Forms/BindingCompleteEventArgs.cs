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
/// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event. </summary>
	/// 2</filterpriority>
	public class BindingCompleteEventArgs : CancelEventArgs
	{
		private Binding mobjBinding;

		private BindingCompleteContext menmContext;

		private string mstrErrorText;

		private Exception mobjException;

		private BindingCompleteState menmState;

		/// Gets the binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>.</returns>
		public Binding Binding => mobjBinding;

		/// Gets the direction of the binding operation.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </returns>
		public BindingCompleteContext BindingCompleteContext => menmContext;

		/// Gets the completion state of the binding operation.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</returns>
		public BindingCompleteState BindingCompleteState => menmState;

		/// Gets the text description of the error that occurred during the binding operation.</summary>
		/// The text description of the error that occurred during the binding operation.</returns>
		/// 1</filterpriority>
		public string ErrorText => mstrErrorText;

		/// Gets the exception that occurred during the binding operation.</summary>
		/// The <see cref="T:System.Exception"></see> that occurred during the binding operation.</returns>
		/// 1</filterpriority>
		public Exception Exception => mobjException;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state, and binding context.</summary>
		/// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
		/// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
		/// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
		public BindingCompleteEventArgs(Binding objBinding, BindingCompleteState enmBindingCompleteState, BindingCompleteContext enmContext)
			: this(objBinding, enmBindingCompleteState, enmContext, string.Empty, null, blnCancel: false)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, and binding context.</summary>
		/// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
		/// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
		/// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
		/// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
		public BindingCompleteEventArgs(Binding objBinding, BindingCompleteState enmBindingCompleteState, BindingCompleteContext enmContext, string strErrorText)
			: this(objBinding, enmBindingCompleteState, enmContext, strErrorText, null, blnCancel: true)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, binding context, and exception.</summary>
		/// <param name="objException">The <see cref="T:System.Exception"></see> that occurred during the binding.</param>
		/// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
		/// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
		/// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
		/// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
		public BindingCompleteEventArgs(Binding objBinding, BindingCompleteState enmBindingCompleteState, BindingCompleteContext enmContext, string strErrorText, Exception objException)
			: this(objBinding, enmBindingCompleteState, enmContext, strErrorText, objException, blnCancel: true)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, binding context, exception, and whether the binding should be cancelled.</summary>
		/// <param name="objException">The <see cref="T:System.Exception"></see> that occurred during the binding.</param>
		/// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
		/// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
		/// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
		/// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
		/// <param name="blnCancel">true to cancel the binding and keep focus on the current control; false to allow focus to shift to another control.</param>
		public BindingCompleteEventArgs(Binding objBinding, BindingCompleteState enmBindingCompleteState, BindingCompleteContext enmContext, string strErrorText, Exception objException, bool blnCancel)
			: base(blnCancel)
		{
			mobjBinding = objBinding;
			menmState = enmBindingCompleteState;
			menmContext = enmContext;
			mstrErrorText = ((strErrorText == null) ? string.Empty : strErrorText);
			mobjException = objException;
		}
	}
}
