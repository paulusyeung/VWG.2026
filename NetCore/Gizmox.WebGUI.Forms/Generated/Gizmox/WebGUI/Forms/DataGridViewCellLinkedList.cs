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
	internal class DataGridViewCellLinkedList : IEnumerable
	{
		private int mintCount;

		private DataGridViewCellLinkedListElement headElement;

		private DataGridViewCellLinkedListElement lastAccessedElement;

		private int mintLastAccessedIndex;

		public int Count => mintCount;

		public DataGridViewCell HeadCell => headElement.DataGridViewCell;

		public DataGridViewCell this[int index]
		{
			get
			{
				if (mintLastAccessedIndex == -1 || index < mintLastAccessedIndex)
				{
					DataGridViewCellLinkedListElement next = headElement;
					for (int num = index; num > 0; num--)
					{
						next = next.Next;
					}
					lastAccessedElement = next;
					mintLastAccessedIndex = index;
					return next.DataGridViewCell;
				}
				while (mintLastAccessedIndex < index)
				{
					lastAccessedElement = lastAccessedElement.Next;
					mintLastAccessedIndex++;
				}
				return lastAccessedElement.DataGridViewCell;
			}
		}

		public DataGridViewCellLinkedList()
		{
			mintLastAccessedIndex = -1;
		}

		public void Add(DataGridViewCell objDataGridViewCell)
		{
			DataGridViewCellLinkedListElement dataGridViewCellLinkedListElement = new DataGridViewCellLinkedListElement(objDataGridViewCell);
			if (headElement != null)
			{
				dataGridViewCellLinkedListElement.Next = headElement;
			}
			headElement = dataGridViewCellLinkedListElement;
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

		public bool Contains(DataGridViewCell objDataGridViewCell)
		{
			int num = 0;
			DataGridViewCellLinkedListElement next = headElement;
			while (next != null)
			{
				if (next.DataGridViewCell == objDataGridViewCell)
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

		public bool Remove(DataGridViewCell objDataGridViewCell)
		{
			DataGridViewCellLinkedListElement dataGridViewCellLinkedListElement = null;
			DataGridViewCellLinkedListElement next = headElement;
			while (next != null && next.DataGridViewCell != objDataGridViewCell)
			{
				dataGridViewCellLinkedListElement = next;
				next = next.Next;
			}
			if (next.DataGridViewCell != objDataGridViewCell)
			{
				return false;
			}
			DataGridViewCellLinkedListElement next2 = next.Next;
			if (dataGridViewCellLinkedListElement == null)
			{
				headElement = next2;
			}
			else
			{
				dataGridViewCellLinkedListElement.Next = next2;
			}
			mintCount--;
			lastAccessedElement = null;
			mintLastAccessedIndex = -1;
			return true;
		}

		public int RemoveAllCellsAtBand(bool blnColumn, int intBandIndex)
		{
			int num = 0;
			DataGridViewCellLinkedListElement dataGridViewCellLinkedListElement = null;
			DataGridViewCellLinkedListElement dataGridViewCellLinkedListElement2 = headElement;
			while (dataGridViewCellLinkedListElement2 != null)
			{
				if ((blnColumn && dataGridViewCellLinkedListElement2.DataGridViewCell.ColumnIndex == intBandIndex) || (!blnColumn && dataGridViewCellLinkedListElement2.DataGridViewCell.RowIndex == intBandIndex))
				{
					DataGridViewCellLinkedListElement next = dataGridViewCellLinkedListElement2.Next;
					if (dataGridViewCellLinkedListElement == null)
					{
						headElement = next;
					}
					else
					{
						dataGridViewCellLinkedListElement.Next = next;
					}
					dataGridViewCellLinkedListElement2 = next;
					mintCount--;
					lastAccessedElement = null;
					mintLastAccessedIndex = -1;
					num++;
				}
				else
				{
					dataGridViewCellLinkedListElement = dataGridViewCellLinkedListElement2;
					dataGridViewCellLinkedListElement2 = dataGridViewCellLinkedListElement2.Next;
				}
			}
			return num;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new DataGridViewCellLinkedListEnumerator(headElement);
		}
	}
}
