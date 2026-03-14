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

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
[Serializable]
	internal class CategoryGridEntry : GridEntry
	{
		private static Hashtable mobjCategoryStates;

		/// 
		/// The string property registration.
		/// </summary>
		private static readonly SerializableProperty NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(CategoryGridEntry));

		/// 
		/// Gets or sets the name.
		/// </summary>
		/// The name.</value>
		internal string Name
		{
			get
			{
				return GetValue(NameProperty);
			}
			set
			{
				SetValue(NameProperty, value);
			}
		}

		public override bool Expandable => !GetStateSet(524288);

		public override GridItemType GridItemType => GridItemType.Category;

		internal override bool HasValue => false;

		public override string HelpKeyword => null;

		internal override bool InternalExpanded
		{
			set
			{
				base.InternalExpanded = value;
				lock (mobjCategoryStates)
				{
					mobjCategoryStates[Name] = value;
				}
			}
		}

		public override int PropertyDepth => base.PropertyDepth - 1;

		public override string PropertyLabel => Name;

		public override Type PropertyType => typeof(void);

		public CategoryGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGrid, string strName, GridEntry[] arrChildGridEntries)
			: base(objOwnerGrid, objParentGrid)
		{
			Name = strName;
			if (mobjCategoryStates == null)
			{
				mobjCategoryStates = new Hashtable();
			}
			lock (mobjCategoryStates)
			{
				if (!mobjCategoryStates.ContainsKey(strName))
				{
					mobjCategoryStates.Add(strName, true);
				}
			}
			IsExpandable = true;
			for (int i = 0; i < arrChildGridEntries.Length; i++)
			{
				arrChildGridEntries[i].ParentGridEntry = this;
			}
			base.ChildCollection = new GridEntryCollection(this, arrChildGridEntries);
			lock (mobjCategoryStates)
			{
				InternalExpanded = (bool)mobjCategoryStates[strName];
			}
			SetState(64, blnValue: true);
		}

		protected override bool CreateChildren(bool blnDiffOldChildren)
		{
			return true;
		}

		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing && base.ChildCollection != null)
			{
				base.ChildCollection = null;
			}
			base.Dispose(blnDisposing);
		}

		public override void DisposeChildren()
		{
		}

		public override object GetChildValueOwner(GridEntry objChildGridEntry)
		{
			return ParentGridEntry.GetChildValueOwner(objChildGridEntry);
		}

		public override string GetPropertyTextValue(object objObject)
		{
			return "";
		}

		public override string GetTestingInfo()
		{
			string text = "object = (";
			text += base.FullLabel;
			return text + "), Category = (" + PropertyLabel + ")";
		}

		internal override bool NotifyChildValue(GridEntry objGridEntry, int intType)
		{
			return base.mobjParentGridEntry.NotifyChildValue(objGridEntry, intType);
		}
	}
}
