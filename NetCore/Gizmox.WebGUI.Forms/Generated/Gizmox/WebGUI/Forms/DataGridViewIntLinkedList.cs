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
	internal class DataGridViewIntLinkedList : IEnumerable
	{
		private int mintCount;

		private DataGridViewIntLinkedListElement headElement;

		private DataGridViewIntLinkedListElement lastAccessedElement;

		private int mintLastAccessedIndex;

		public int Count => mintCount;

		public int HeadInt => headElement.Int;

		public int this[int index]
		{
			get
			{
				if (mintLastAccessedIndex == -1 || index < mintLastAccessedIndex)
				{
					DataGridViewIntLinkedListElement next = headElement;
					for (int num = index; num > 0; num--)
					{
						next = next.Next;
					}
					lastAccessedElement = next;
					mintLastAccessedIndex = index;
					return next.Int;
				}
				while (mintLastAccessedIndex < index)
				{
					lastAccessedElement = lastAccessedElement.Next;
					mintLastAccessedIndex++;
				}
				return lastAccessedElement.Int;
			}
			set
			{
				if (index != mintLastAccessedIndex)
				{
					int num = this[index];
				}
				lastAccessedElement.Int = value;
			}
		}

		public DataGridViewIntLinkedList()
		{
			mintLastAccessedIndex = -1;
		}

		public DataGridViewIntLinkedList(DataGridViewIntLinkedList source)
		{
			int count = source.Count;
			for (int i = 0; i < count; i++)
			{
				Add(source[i]);
			}
		}

		public void Add(int integer)
		{
			DataGridViewIntLinkedListElement dataGridViewIntLinkedListElement = new DataGridViewIntLinkedListElement(integer);
			if (headElement != null)
			{
				dataGridViewIntLinkedListElement.Next = headElement;
			}
			headElement = dataGridViewIntLinkedListElement;
			mintCount++;
			lastAccessedElement = null;
			mintLastAccessedIndex = -1;
		}

		public void Clear()
		{
			lastAccessedElement = null;
			mintLastAccessedIndex = -1;
			headElement = null;
			mintCount = 0;
		}

		public bool Contains(int integer)
		{
			int num = 0;
			DataGridViewIntLinkedListElement next = headElement;
			while (next != null)
			{
				if (next.Int == integer)
				{
					lastAccessedElement = next;
					mintLastAccessedIndex = num;
					return true;
				}
				next = next.Next;
				num++;
			}
			return false;
		}

		public int IndexOf(int integer)
		{
			if (Contains(integer))
			{
				return mintLastAccessedIndex;
			}
			return -1;
		}

		public bool Remove(int integer)
		{
			DataGridViewIntLinkedListElement dataGridViewIntLinkedListElement = null;
			DataGridViewIntLinkedListElement next = headElement;
			while (next != null && next.Int != integer)
			{
				dataGridViewIntLinkedListElement = next;
				next = next.Next;
			}
			if (next.Int != integer)
			{
				return false;
			}
			DataGridViewIntLinkedListElement next2 = next.Next;
			if (dataGridViewIntLinkedListElement == null)
			{
				headElement = next2;
			}
			else
			{
				dataGridViewIntLinkedListElement.Next = next2;
			}
			mintCount--;
			lastAccessedElement = null;
			mintLastAccessedIndex = -1;
			return true;
		}

		public void RemoveAt(int index)
		{
			DataGridViewIntLinkedListElement dataGridViewIntLinkedListElement = null;
			DataGridViewIntLinkedListElement next = headElement;
			while (index > 0)
			{
				dataGridViewIntLinkedListElement = next;
				next = next.Next;
				index--;
			}
			DataGridViewIntLinkedListElement next2 = next.Next;
			if (dataGridViewIntLinkedListElement == null)
			{
				headElement = next2;
			}
			else
			{
				dataGridViewIntLinkedListElement.Next = next2;
			}
			mintCount--;
			lastAccessedElement = null;
			mintLastAccessedIndex = -1;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new DataGridViewIntLinkedListEnumerator(headElement);
		}
	}
}
