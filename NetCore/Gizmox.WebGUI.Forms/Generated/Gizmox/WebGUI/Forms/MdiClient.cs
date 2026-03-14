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
	/// Represents the container for multiple-document interface (MDI) child forms. This class cannot be inherited.
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[DesignTimeVisible(false)]
	[MetadataTag("MDIC")]
	[Skin(typeof(MdiClientSkin))]
	public sealed class MdiClient : Control
	{
		/// 
		/// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> controls.
		/// </summary>
		[Serializable]
		public new class ControlCollection : Control.ControlCollection
		{
			private MdiClient mobjOwner;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient.ControlCollection"></see> class, specifying the owner of the collection. 
			/// </summary>
			/// <param name="objOwner">The owner of the collection.</param>
			public ControlCollection(MdiClient objOwner)
				: base(objOwner)
			{
				mobjOwner = objOwner;
			}

			/// 
			/// Adds a control to the multiple-document interface (MDI) Container.
			/// </summary>
			/// <param name="objControl">MDI Child Form to add. </param>
			public override void Add(Control objControl)
			{
				if (!(objControl is Form) || !((Form)objControl).IsMdiChild)
				{
					throw new ArgumentException(SR.GetString("MDIChildAddToNonMDIParent"), "value");
				}
				mobjOwner.ChildrenInternal.Add((Form)objControl);
				base.Add(objControl);
			}

			/// 
			/// Removes a child control.
			/// </summary>
			/// <param name="objValue">MDI Child Form to remove. </param>
			public override void Remove(Control objValue)
			{
				mobjOwner.ChildrenInternal.Remove(objValue);
				base.Remove(objValue);
			}
		}

		/// 
		/// The Children property registration.
		/// </summary>
		private static readonly SerializableProperty ChildrenProperty = SerializableProperty.Register("Children", typeof(ArrayList), typeof(MdiClient));

		/// 
		/// Gets or sets the children.
		/// </summary>
		/// The children.</value>
		private ArrayList ChildrenInternal
		{
			get
			{
				return GetValue(ChildrenProperty);
			}
			set
			{
				SetValue(ChildrenProperty, value);
			}
		}

		/// 
		/// Gets or sets the background image displayed in the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> control.
		/// </summary>
		/// An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.</returns>
		[Localizable(true)]
		public override ResourceHandle BackgroundImage
		{
			get
			{
				ResourceHandle backgroundImage = base.BackgroundImage;
				if (backgroundImage == null && ParentInternal != null)
				{
					backgroundImage = ParentInternal.BackgroundImage;
				}
				return backgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		/// 
		/// This property is not relevant to this class.
		/// </summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> value.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				if (BackgroundImage != null && ParentInternal != null && base.BackgroundImageLayout != ParentInternal.BackgroundImageLayout)
				{
					return ParentInternal.BackgroundImageLayout;
				}
				return base.BackgroundImageLayout;
			}
			set
			{
				base.BackgroundImageLayout = value;
			}
		}

		/// 
		/// Gets the child multiple-document interface (MDI) forms of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> control.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> array that contains the child MDI forms of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see>.</returns>
		public Form[] MdiChildren
		{
			get
			{
				Form[] array = new Form[ChildrenInternal.Count];
				ChildrenInternal.CopyTo(array, 0);
				return array;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> class. 
		/// </summary>
		public MdiClient()
		{
			ChildrenInternal = new ArrayList();
			SetStyle(ControlStyles.Selectable, blnValue: false);
			Dock = DockStyle.Fill;
		}

		/// 
		/// Creates a new instance of the control collection for the control.
		/// </summary>
		/// 
		/// A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection" /> assigned to the control.
		/// </returns>
		protected override Control.ControlCollection CreateControlsInstance()
		{
			return new ControlCollection(this);
		}

		/// 
		/// Arranges the multiple-document interface (MDI) child forms within the MDI parent form.
		/// </summary>
		/// <param name="value">One of the <see cref="T:Gizmox.WebGUI.Forms.MdiLayout"></see> values that defines the layout of MDI child forms.</param>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void LayoutMdi(MdiLayout value)
		{
			if (!(base.Parent is Form { IsMdiContainer: not false } form) || form.OwnedForms.Length == 0)
			{
				return;
			}
			int num = 0;
			Form[] ownedForms = form.OwnedForms;
			foreach (Form form2 in ownedForms)
			{
				form2.StartPosition = FormStartPosition.Manual;
				if (value == MdiLayout.Cascade)
				{
					form2.Top = num * 29;
					form2.Left = num * 22;
				}
				form2.UpdateParamsInternal(AttributeType.Layout);
				num++;
			}
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (base.Parent != null)
			{
				objWriter.WriteAttributeString("MDP", base.Parent.ID.ToString());
			}
		}

		/// 
		/// Shoulds the color of the serialize back.
		/// </summary>
		/// </returns>
		internal override bool ShouldSerializeBackColor()
		{
			return BackColor != SystemColors.AppWorkspace;
		}

		private bool ShouldSerializeLocation()
		{
			return false;
		}

		/// 
		/// Shoulds the size of the serialize.
		/// </summary>
		/// </returns>
		protected override bool ShouldSerializeSize()
		{
			return false;
		}
	}
}
