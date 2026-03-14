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
/// Specifies the base class used for displaying dialog boxes on the screen.</summary>
	[Serializable]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	[ToolboxItem(false)]
	[ToolboxItemCategory("Dialogs")]
	[Skin(typeof(CommonDialogSkin))]
	public abstract class CommonDialog : ComponentBase, ICommonDialog, ISkinable
	{
		/// 
		///
		/// </summary>
		[Serializable]
		protected class CommonDialogForm : Form, ICommonDialogHandler
		{
			/// 
			/// Holds reference to the owner color dialog component
			/// </summary>
			private CommonDialog mobjCommonDialog = null;

			/// 
			/// The dialog direct handler
			/// </summary>
			private EventHandler mobjDirectHandler = null;

			/// 
			/// Gets the theme related to the skinable component.
			/// </summary>
			/// 
			/// The theme related to the skinable component.
			/// </value>
			public override string Theme
			{
				get
				{
					if (CommonDialogOwner != null)
					{
						return CommonDialogOwner.Theme;
					}
					return base.Theme;
				}
				set
				{
					base.Theme = value;
				}
			}

			/// 
			/// Gets the owner commong 
			/// </summary>
			protected CommonDialog CommonDialogOwner => mobjCommonDialog;

			/// 
			/// Gets or sets the direct handler
			/// </summary>
			internal EventHandler DirectHandler
			{
				get
				{
					return mobjDirectHandler;
				}
				set
				{
					mobjDirectHandler = value;
				}
			}

			/// 
			///
			/// </summary>
			EventHandler ICommonDialogHandler.DirectHandler => DirectHandler;

			/// 
			///
			/// </summary>
			DialogResult ICommonDialogHandler.DialogResult => base.DialogResult;

			/// 
			///
			/// </summary>
			/// <param name="objCommonDialog"></param>
			public CommonDialogForm(CommonDialog objCommonDialog)
			{
				mobjCommonDialog = objCommonDialog;
			}
		}

		internal delegate void EventRaisedHander(IEvent objEvent);

		[Serializable]
		[ToolboxItem(false)]
		internal class HtmlBoxHost : HtmlBox
		{
			private NameValueCollection mobjProperties = null;

			public override string Url
			{
				get
				{
					string url = base.Url;
					if (url != null)
					{
						if (url.IndexOf("?") == -1)
						{
							return $"{url}?id={ID}";
						}
						return $"{url}&id={ID}";
					}
					return null;
				}
				set
				{
					base.Url = value;
				}
			}

			internal event EventRaisedHander EventRaised;

			protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
			{
				base.RenderAttributes(objContext, objWriter);
				if (mobjProperties != null)
				{
					string[] allKeys = mobjProperties.AllKeys;
					foreach (string text in allKeys)
					{
						objWriter.WriteAttributeString(text, mobjProperties[text]);
					}
				}
			}

			protected override void FireEvent(IEvent objEvent)
			{
				base.FireEvent(objEvent);
				if (this.EventRaised != null)
				{
					this.EventRaised(objEvent);
				}
			}

			public string GetProperty(string strName)
			{
				if (mobjProperties == null)
				{
					return null;
				}
				return mobjProperties[strName];
			}

			public void SetProperty(string strName, string strValue)
			{
				if (strValue == null && mobjProperties != null)
				{
					mobjProperties.Remove(strValue);
				}
				if (mobjProperties == null)
				{
					mobjProperties = new NameValueCollection();
				}
				mobjProperties[strName] = strValue;
			}

			internal void InvokeExecuter(params object[] arrParams)
			{
				InvokeMethodWithId("FrameControl_Execute", arrParams);
			}
		}

		/// 
		/// Holds the user data
		/// </summary>
		private object mobjTag = null;

		/// 
		///
		/// </summary>
		private string mstrTheme = string.Empty;

		/// 
		/// The last dialog result
		/// </summary>
		private DialogResult menmDialogResult = DialogResult.None;

		/// 
		/// The skin of the current control
		/// </summary>
		[NonSerialized]
		private CommonDialogSkin mobjSkin = null;

		/// 
		/// Returns the last dialog result
		/// </summary>
		public DialogResult DialogResult => menmDialogResult;

		/// Gets or sets an object that contains data about the control. </summary>
		/// 1</filterpriority>
		[DefaultValue(null)]
		[TypeConverter(typeof(StringConverter))]
		[Bindable(true)]
		[Localizable(false)]
		[SRCategory("CatData")]
		[SRDescription("ControlTagDescr")]
		public object Tag
		{
			get
			{
				return mobjTag;
			}
			set
			{
				mobjTag = value;
			}
		}

		/// 
		/// Gets the theme related to the skinable component.
		/// </summary>
		/// 
		/// The theme related to the skinable component.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[WebEditor(typeof(WebThemeEditor), typeof(WebUITypeEditor))]
		[SRCategory("CatAppearance")]
		[SRDescription("ControlThemeDescr")]
		[DefaultValue("Inherit")]
		[ProxyBrowsable(true)]
		public string Theme
		{
			get
			{
				return mstrTheme;
			}
			set
			{
				mstrTheme = value;
			}
		}

		/// 
		/// Gets the skin of the current control.
		/// </summary>
		/// The skin of the current control.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		protected CommonDialogSkin Skin
		{
			get
			{
				if (mobjSkin == null)
				{
					mobjSkin = (CommonDialogSkin)SkinFactory.GetSkin(this);
				}
				return mobjSkin;
			}
		}

		/// 
		/// Gets the theme related to the skinable component.
		/// </summary>
		/// The theme related to the skinable component.</value>
		string ISkinable.Theme
		{
			get
			{
				IContext current = VWGContext.Current;
				if (current != null)
				{
					return current.CurrentTheme;
				}
				return "Default";
			}
		}

		/// Occurs when the user clicks the Help button on a common dialog box.</summary>
		[SRDescription("CommonDialogHelpRequested")]
		public event EventHandler HelpRequest;

		/// 
		/// The form close event
		/// </summary>
		public event EventHandler Closed;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> class.</summary>
		public CommonDialog()
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.HelpRequest"></see> event.</summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.HelpEventArgs"></see> that provides the event data. </param>
		protected virtual void OnHelpRequest(EventArgs e)
		{
			this.HelpRequest?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.Close"></see> event.</summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.EventArgs"></see> that provides the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnClosed(EventArgs e)
		{
			this.Closed?.Invoke(this, e);
		}

		/// When overridden in a derived class, resets the properties of a common dialog box to their default values.</summary>
		public abstract void Reset();

		/// Runs a common dialog box with a default owner.</summary>
		/// <see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
		public DialogResult ShowDialog()
		{
			return ShowDialog(null, null, blnShowModalMask: true);
		}

		/// Runs a common dialog box with a default owner.</summary>
		/// <see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public DialogResult ShowDialog(bool blnShowModalMask)
		{
			return ShowDialog(null, null, blnShowModalMask);
		}

		/// Runs a common dialog box with a default owner.</summary>
		/// <param name="objEventHandler">Event handler for dialog closed event</param>
		/// <see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
		public DialogResult ShowDialog(EventHandler objEventHandler)
		{
			return ShowDialog(null, objEventHandler, blnShowModalMask: true);
		}

		/// Runs a common dialog box with a default owner.</summary>
		/// <param name="objEventHandler">Event handler for dialog closed event</param>
		/// <see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>                
		public DialogResult ShowDialog(EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowDialog(null, objEventHandler, blnShowModalMask);
		}

		/// Runs a common dialog box with the specified owner.</summary>
		/// <see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
		/// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
		public DialogResult ShowDialog(Form objOwner)
		{
			return ShowDialog(objOwner, null, blnShowModalMask: true);
		}

		/// Runs a common dialog box with the specified owner.</summary>
		/// <see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
		/// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>                        
		public DialogResult ShowDialog(Form objOwner, bool blnShowModalMask)
		{
			return ShowDialog(objOwner, null, blnShowModalMask);
		}

		/// Runs a common dialog box with the specified owner.</summary>
		/// <see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
		/// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
		/// <param name="objEventHandler">Event handler for dialog closed event</param>
		public DialogResult ShowDialog(Form objOwner, EventHandler objEventHandler)
		{
			return ShowDialog(objOwner, objEventHandler, blnShowModalMask: true);
		}

		/// 
		/// Runs a common dialog box with the specified owner.
		/// </summary>
		/// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box.</param>
		/// <param name="objEventHandler">The obj event handler.</param>
		/// <param name="blnShowModalMask">if set to true</c> [BLN show modal mask].</param>
		/// 
		/// 	<see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.
		/// </returns>
		public DialogResult ShowDialog(Form objOwner, EventHandler objEventHandler, bool blnShowModalMask)
		{
			DialogResult result = DialogResult.None;
			if (VWGContext.Current is IContextCommonDialogHandler contextCommonDialogHandler)
			{
				contextCommonDialogHandler.ShowDialog(this, objOwner, CommonDialogForm_Closed, objEventHandler);
			}
			else
			{
				CommonDialogForm commonDialogForm = CreateForm();
				if (commonDialogForm != null)
				{
					if (objEventHandler != null)
					{
						commonDialogForm.DirectHandler = objEventHandler;
					}
					commonDialogForm.ModalMask = blnShowModalMask;
					commonDialogForm.Closed += CommonDialogForm_Closed;
					result = ((objOwner == null) ? commonDialogForm.ShowDialog() : commonDialogForm.ShowDialog(objOwner));
				}
			}
			return result;
		}

		/// 
		/// Displays the form as a popup window.
		/// </summary>
		public DialogResult ShowPopup(Form objOwnerForm, IRegisteredComponent objComponent, EventHandler objEventHandler, DialogAlignment enmAlignment, Point objPopupLocation)
		{
			DialogResult result = DialogResult.None;
			CommonDialogForm commonDialogForm = CreateForm();
			if (commonDialogForm != null)
			{
				if (objEventHandler != null)
				{
					commonDialogForm.DirectHandler = objEventHandler;
				}
				commonDialogForm.Closed += CommonDialogForm_Closed;
				if (objPopupLocation.IsEmpty)
				{
					result = commonDialogForm.ShowPopup(objOwnerForm, objComponent, DialogAlignment.Below);
				}
				else
				{
					commonDialogForm.Location = objPopupLocation;
					commonDialogForm.StartPosition = FormStartPosition.Manual;
					result = commonDialogForm.ShowPopup(objOwnerForm, objComponent, DialogAlignment.Custom);
				}
			}
			return result;
		}

		/// 
		/// Displays the form as a popup window.
		/// </summary>
		public DialogResult ShowPopup(Form objOwnerForm, IRegisteredComponentMember objComponentMember, EventHandler objEventHandler, DialogAlignment enmAlignment, Point objPopupLocation)
		{
			DialogResult result = DialogResult.None;
			CommonDialogForm commonDialogForm = CreateForm();
			if (commonDialogForm != null)
			{
				if (objEventHandler != null)
				{
					commonDialogForm.DirectHandler = objEventHandler;
				}
				commonDialogForm.Closed += CommonDialogForm_Closed;
				if (objPopupLocation.IsEmpty)
				{
					result = commonDialogForm.ShowPopup(objOwnerForm, objComponentMember, DialogAlignment.Below);
				}
				else
				{
					commonDialogForm.Location = objPopupLocation;
					commonDialogForm.StartPosition = FormStartPosition.Manual;
					result = commonDialogForm.ShowPopup(objOwnerForm, objComponentMember, DialogAlignment.Custom);
				}
			}
			return result;
		}

		/// 
		/// Handles the form close event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CommonDialogForm_Closed(object sender, EventArgs e)
		{
			ICommonDialogHandler commonDialogHandler = (ICommonDialogHandler)sender;
			if (commonDialogHandler != null)
			{
				menmDialogResult = commonDialogHandler.DialogResult;
				OnClosed(EventArgs.Empty);
				if (commonDialogHandler.DirectHandler != null)
				{
					commonDialogHandler.DirectHandler(this, EventArgs.Empty);
				}
			}
		}

		/// 
		/// Creates a dialog for instance for the current common dialog
		/// </summary>
		/// </returns>
		protected abstract CommonDialogForm CreateForm();

		/// 
		/// Handles apply event
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnApply(EventArgs e)
		{
		}

		/// 
		/// Execute the apply event
		/// </summary>
		void ICommonDialog.OnApply()
		{
			OnApply(EventArgs.Empty);
		}
	}
}
