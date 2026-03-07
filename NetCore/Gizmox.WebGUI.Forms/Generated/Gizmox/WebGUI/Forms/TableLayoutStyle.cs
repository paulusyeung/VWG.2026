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
	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[TypeConverter(typeof(TableLayoutSettings.StyleConverter))]
	public abstract class TableLayoutStyle : IObservableItem
	{
		private IArrangedElement mobjOwner;

		private float mfltSize;

		private SizeType menmSizeType;

		internal IArrangedElement Owner
		{
			get
			{
				return mobjOwner;
			}
			set
			{
				if (mobjOwner != value)
				{
					mobjOwner = value;
					FireObservableItemPropertyChanged("Owner");
				}
			}
		}

		internal float Size
		{
			get
			{
				return mfltSize;
			}
			set
			{
				if (value < 0f)
				{
					object[] arrArgs = new object[3]
					{
						"Size",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("Size", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (mfltSize != value)
				{
					mfltSize = value;
					FireObservableItemPropertyChanged("Size");
					if (Owner != null && Owner is Control control)
					{
						control.OnResizeInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
						control.Invalidate();
					}
				}
			}
		}

		/// 
		/// Gets or sets the type of the size.
		/// </summary>
		/// The type of the size.</value>
		[DefaultValue(0)]
		public SizeType SizeType
		{
			get
			{
				return menmSizeType;
			}
			set
			{
				if (menmSizeType != value)
				{
					menmSizeType = value;
					FireObservableItemPropertyChanged("SizeType");
					if (Owner != null && Owner is Control control)
					{
						control.Invalidate();
					}
				}
			}
		}

		/// 
		/// Property change indicator for the observable item interface
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutStyle" /> class.
		/// </summary>
		protected TableLayoutStyle()
		{
		}

		private bool ShouldSerializeSize()
		{
			return SizeType != SizeType.AutoSize;
		}

		internal void SetSize(float fltSize)
		{
			mfltSize = fltSize;
		}

		/// 
		/// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
		/// </summary>
		/// <param name="strProperty">The name of the property that has changed</param>
		protected void FireObservableItemPropertyChanged(string strProperty)
		{
			if (this.ObservableItemPropertyChanged != null)
			{
				this.ObservableItemPropertyChanged(this, new ObservableItemPropertyChangedArgs(strProperty));
			}
		}
	}
}
