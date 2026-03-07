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

namespace Gizmox.WebGUI.Forms.Layout
{
	/// Represents a collection of objects.</summary>
	[Serializable]
	public class ArrangedElementCollection : IList, ICollection, IEnumerable
	{
		private ArrayList mobjInnerList;

		internal static ArrangedElementCollection Empty;

		/// Gets the number of elements in the collection.</summary>
		/// The number of elements currently contained in the collection.</returns>
		public virtual int Count => InnerList.Count;

		internal ArrayList InnerList => mobjInnerList;

		/// Gets a value indicating whether the collection is read-only.</summary>
		/// true if the collection is read-only; otherwise, false. The default is false.</returns>
		public virtual bool IsReadOnly => InnerList.IsReadOnly;

		internal virtual IArrangedElement this[int index] => (IArrangedElement)InnerList[index];

		bool ICollection.IsSynchronized => InnerList.IsSynchronized;

		object ICollection.SyncRoot => InnerList.SyncRoot;

		bool IList.IsFixedSize => InnerList.IsFixedSize;

		object IList.this[int index]
		{
			get
			{
				return InnerList[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		static ArrangedElementCollection()
		{
			Empty = new ArrangedElementCollection(0);
		}

		internal ArrangedElementCollection()
		{
			mobjInnerList = new ArrayList(4);
		}

		internal ArrangedElementCollection(ArrayList innerList)
		{
			mobjInnerList = innerList;
		}

		private ArrangedElementCollection(int intSize)
		{
			mobjInnerList = new ArrayList(intSize);
		}

		private static void Copy(ArrangedElementCollection objSourceList, int intSourceIndex, ArrangedElementCollection objDestinationList, int intDestinationIndex, int intLength)
		{
			if (intSourceIndex < intDestinationIndex)
			{
				intSourceIndex += intLength;
				intDestinationIndex += intLength;
				while (intLength > 0)
				{
					objDestinationList.InnerList[--intDestinationIndex] = objSourceList.InnerList[--intSourceIndex];
					intLength--;
				}
			}
			else
			{
				while (intLength > 0)
				{
					objDestinationList.InnerList[intDestinationIndex++] = objSourceList.InnerList[intSourceIndex++];
					intLength--;
				}
			}
		}

		/// Copies the entire contents of this collection to a compatible one-dimensional <see cref="T:System.Array"></see>, starting at the specified index of the target array.</summary>
		/// <param name="objArray">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from the current collection. The array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		/// <exception cref="T:System.InvalidCastException">The type of the source element cannot be cast automatically to the type of array.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0.</exception>
		/// <exception cref="T:System.ArgumentException">One of the following conditions has occurred:array is multidimensional.index is equal to or greater than the length of array.The number of elements in the source collection is greater than the available space from index to the end of array.</exception>
		/// <exception cref="T:System.ArgumentNullException">array is null.</exception>
		public void CopyTo(Array objArray, int index)
		{
			InnerList.CopyTo(objArray, index);
		}

		/// Determines whether two <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> instances are equal.</summary>
		/// true if the specified <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> is equal to the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>; otherwise, false.</returns>
		/// <param name="obj">The <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> to compare with the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>.</param>
		public override bool Equals(object obj)
		{
			if (!(obj is ArrangedElementCollection arrangedElementCollection) || Count != arrangedElementCollection.Count)
			{
				return false;
			}
			for (int i = 0; i < Count; i++)
			{
				if (InnerList[i] != arrangedElementCollection.InnerList[i])
				{
					return false;
				}
			}
			return true;
		}

		/// Returns an enumerator for the entire collection.</summary>
		/// An <see cref="T:System.Collections.IEnumerator"></see> for the entire collection.</returns>
		public virtual IEnumerator GetEnumerator()
		{
			return InnerList.GetEnumerator();
		}

		/// Returns the hash code for this instance.</summary>
		/// A hash code for the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>.</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		internal void MoveElement(IArrangedElement objElement, int intFromIndex, int intToIndex)
		{
			int num = intToIndex - intFromIndex;
			int num2 = num;
			if (num2 == -1 || num2 == 1)
			{
				InnerList[intFromIndex] = InnerList[intToIndex];
			}
			else
			{
				int num3 = 0;
				int num4 = 0;
				if (num > 0)
				{
					num3 = intFromIndex + 1;
					num4 = intFromIndex;
				}
				else
				{
					num3 = intToIndex;
					num4 = intToIndex + 1;
					num = -num;
				}
				Copy(this, num3, this, num4, num);
			}
			InnerList[intToIndex] = objElement;
		}

		int IList.Add(object objValue)
		{
			return InnerList.Add(objValue);
		}

		void IList.Clear()
		{
			InnerList.Clear();
		}

		bool IList.Contains(object objValue)
		{
			return InnerList.Contains(objValue);
		}

		int IList.IndexOf(object objValue)
		{
			return InnerList.IndexOf(objValue);
		}

		void IList.Insert(int index, object objValue)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object objValue)
		{
			InnerList.Remove(objValue);
		}

		void IList.RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}
	}
}
