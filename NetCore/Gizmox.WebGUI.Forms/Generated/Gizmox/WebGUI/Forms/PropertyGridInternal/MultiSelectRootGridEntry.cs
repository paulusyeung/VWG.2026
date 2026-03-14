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
	internal class MultiSelectRootGridEntry : SingleSelectRootGridEntry
	{
		[Serializable]
		private class PDComparer : IComparer
		{
			public int Compare(object obj1, object obj2)
			{
				PropertyDescriptor propertyDescriptor = obj1 as PropertyDescriptor;
				PropertyDescriptor propertyDescriptor2 = obj2 as PropertyDescriptor;
				if (propertyDescriptor == null && propertyDescriptor2 == null)
				{
					return 0;
				}
				if (propertyDescriptor == null)
				{
					return -1;
				}
				if (propertyDescriptor2 == null)
				{
					return 1;
				}
				int num = string.Compare(propertyDescriptor.Name, propertyDescriptor2.Name, ignoreCase: false, CultureInfo.InvariantCulture);
				if (num == 0)
				{
					num = string.Compare(propertyDescriptor.PropertyType.FullName, propertyDescriptor2.PropertyType.FullName, ignoreCase: true, CultureInfo.CurrentCulture);
				}
				return num;
			}
		}

		[Serializable]
		internal class PropertyMerger
		{
			private static ArrayList GetCommonProperties(object[] arrObjects, bool blnPresort, PropertyTab objPropertyTab, GridEntry objParentEntry)
			{
				PropertyDescriptorCollection[] array = new PropertyDescriptorCollection[arrObjects.Length];
				Attribute[] array2 = new Attribute[objParentEntry.BrowsableAttributes.Count];
				objParentEntry.BrowsableAttributes.CopyTo(array2, 0);
				for (int i = 0; i < arrObjects.Length; i++)
				{
					PropertyDescriptorCollection propertyDescriptorCollection = objPropertyTab.GetProperties(objParentEntry, arrObjects[i], array2);
					if (blnPresort)
					{
						propertyDescriptorCollection = propertyDescriptorCollection.Sort(PropertyComparer);
					}
					array[i] = propertyDescriptorCollection;
				}
				ArrayList arrayList = new ArrayList();
				PropertyDescriptor[] array3 = new PropertyDescriptor[arrObjects.Length];
				int[] array4 = new int[array.Length];
				for (int j = 0; j < array[0].Count; j++)
				{
					PropertyDescriptor propertyDescriptor = array[0][j];
					bool flag = propertyDescriptor.Attributes[typeof(MergablePropertyAttribute)].IsDefaultAttribute();
					int num = 1;
					while (flag && num < array.Length)
					{
						if (array4[num] >= array[num].Count)
						{
							flag = false;
							break;
						}
						PropertyDescriptor propertyDescriptor2 = array[num][array4[num]];
						if (propertyDescriptor.Equals(propertyDescriptor2))
						{
							array4[num]++;
							if (!propertyDescriptor2.Attributes[typeof(MergablePropertyAttribute)].IsDefaultAttribute())
							{
								flag = false;
								break;
							}
							array3[num] = propertyDescriptor2;
						}
						else
						{
							int num2 = array4[num];
							propertyDescriptor2 = array[num][num2];
							flag = false;
							while (PropertyComparer.Compare(propertyDescriptor2, propertyDescriptor) <= 0)
							{
								if (propertyDescriptor.Equals(propertyDescriptor2))
								{
									if (!propertyDescriptor2.Attributes[typeof(MergablePropertyAttribute)].IsDefaultAttribute())
									{
										flag = false;
										num2++;
									}
									else
									{
										flag = true;
										array3[num] = propertyDescriptor2;
										array4[num] = num2 + 1;
									}
									break;
								}
								num2++;
								if (num2 >= array[num].Count)
								{
									break;
								}
								propertyDescriptor2 = array[num][num2];
							}
							if (!flag)
							{
								array4[num] = num2;
								break;
							}
						}
						num++;
					}
					if (flag)
					{
						array3[0] = propertyDescriptor;
						arrayList.Add(array3.Clone());
					}
				}
				return arrayList;
			}

			/// 
			/// Gets the merged properties.
			/// </summary>
			/// <param name="arrObjects">The arr objects.</param>
			/// <param name="objParentEntry">The obj parent entry.</param>
			/// <param name="objSort">The obj sort.</param>
			/// <param name="objPropertyTab">The obj property tab.</param>
			/// </returns>
			public static MultiPropertyDescriptorGridEntry[] GetMergedProperties(object[] arrObjects, GridEntry objParentEntry, PropertySort objSort, PropertyTab objPropertyTab)
			{
				try
				{
					int num = arrObjects.Length;
					if ((objSort & PropertySort.Alphabetical) != PropertySort.NoSort)
					{
						ArrayList commonProperties = GetCommonProperties(arrObjects, blnPresort: true, objPropertyTab, objParentEntry);
						MultiPropertyDescriptorGridEntry[] array = new MultiPropertyDescriptorGridEntry[commonProperties.Count];
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = new MultiPropertyDescriptorGridEntry(objParentEntry.OwnerGrid, objParentEntry, arrObjects, (PropertyDescriptor[])commonProperties[i], blnHide: false);
						}
						return SortParenEntries(array);
					}
					object[] array2 = new object[num - 1];
					Array.Copy(arrObjects, 1, array2, 0, num - 1);
					ArrayList commonProperties2 = GetCommonProperties(array2, blnPresort: true, objPropertyTab, objParentEntry);
					ArrayList commonProperties3 = GetCommonProperties(new object[1] { arrObjects[0] }, blnPresort: false, objPropertyTab, objParentEntry);
					PropertyDescriptor[] array3 = new PropertyDescriptor[commonProperties3.Count];
					for (int j = 0; j < commonProperties3.Count; j++)
					{
						array3[j] = ((PropertyDescriptor[])commonProperties3[j])[0];
					}
					commonProperties2 = UnsortedMerge(array3, commonProperties2);
					MultiPropertyDescriptorGridEntry[] array4 = new MultiPropertyDescriptorGridEntry[commonProperties2.Count];
					for (int k = 0; k < array4.Length; k++)
					{
						array4[k] = new MultiPropertyDescriptorGridEntry(objParentEntry.OwnerGrid, objParentEntry, arrObjects, (PropertyDescriptor[])commonProperties2[k], blnHide: false);
					}
					return SortParenEntries(array4);
				}
				catch
				{
					return null;
				}
			}

			private static MultiPropertyDescriptorGridEntry[] SortParenEntries(MultiPropertyDescriptorGridEntry[] arrEntries)
			{
				MultiPropertyDescriptorGridEntry[] array = null;
				int num = 0;
				for (int i = 0; i < arrEntries.Length; i++)
				{
					if (arrEntries[i].ParensAroundName)
					{
						if (array == null)
						{
							array = new MultiPropertyDescriptorGridEntry[arrEntries.Length];
						}
						array[num++] = arrEntries[i];
						arrEntries[i] = null;
					}
				}
				if (num > 0)
				{
					for (int j = 0; j < arrEntries.Length; j++)
					{
						if (arrEntries[j] != null)
						{
							array[num++] = arrEntries[j];
						}
					}
					arrEntries = array;
				}
				return arrEntries;
			}

			private static ArrayList UnsortedMerge(PropertyDescriptor[] arrBaseEntries, ArrayList sortedMergedEntries)
			{
				ArrayList arrayList = new ArrayList();
				PropertyDescriptor[] array = new PropertyDescriptor[((PropertyDescriptor[])sortedMergedEntries[0]).Length + 1];
				foreach (PropertyDescriptor propertyDescriptor in arrBaseEntries)
				{
					PropertyDescriptor[] array2 = null;
					string strA = propertyDescriptor.Name + " " + propertyDescriptor.PropertyType.FullName;
					int num = sortedMergedEntries.Count;
					int num2 = num / 2;
					int num3 = 0;
					while (num > 0)
					{
						PropertyDescriptor[] array3 = (PropertyDescriptor[])sortedMergedEntries[num3 + num2];
						PropertyDescriptor propertyDescriptor2 = array3[0];
						string strB = propertyDescriptor2.Name + " " + propertyDescriptor2.PropertyType.FullName;
						int num4 = string.Compare(strA, strB, ignoreCase: false, CultureInfo.InvariantCulture);
						if (num4 == 0)
						{
							array2 = array3;
							break;
						}
						if (num4 < 0)
						{
							num = num2;
						}
						else
						{
							int num5 = num2 + 1;
							num3 += num5;
							num -= num5;
						}
						num2 = num / 2;
					}
					if (array2 != null)
					{
						array[0] = propertyDescriptor;
						Array.Copy(array2, 0, array, 1, array2.Length);
						arrayList.Add(array.Clone());
					}
				}
				return arrayList;
			}
		}

		private static PDComparer PropertyComparer;

		internal override bool ForceReadOnly
		{
			get
			{
				if (!base.forceReadOnlyChecked)
				{
					bool flag = false;
					foreach (object item in (Array)base.objValue)
					{
						ReadOnlyAttribute readOnlyAttribute = (ReadOnlyAttribute)TypeDescriptor.GetAttributes(item)[typeof(ReadOnlyAttribute)];
						if ((readOnlyAttribute != null && !readOnlyAttribute.IsDefaultAttribute()) || TypeDescriptor.GetAttributes(item).Contains(InheritanceAttribute.InheritedReadOnly))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						base.State |= 1024;
					}
					base.forceReadOnlyChecked = true;
				}
				return base.ForceReadOnly;
			}
		}

		static MultiSelectRootGridEntry()
		{
			PropertyComparer = new PDComparer();
		}

		internal MultiSelectRootGridEntry(PropertyGridView objPropertyGridView, object obj, IServiceProvider objBaseProvider, IDesignerHost objHost, PropertyTab objPropertyTab, PropertySort objSortType)
			: base(objPropertyGridView, obj, objBaseProvider, objHost, objPropertyTab, objSortType)
		{
		}

		protected override bool CreateChildren()
		{
			return CreateChildren(blnDiffOldChildren: false);
		}

		protected override bool CreateChildren(bool blnDiffOldChildren)
		{
			try
			{
				object[] arrObjects = (object[])base.objValue;
				base.ChildCollection.Clear();
				MultiPropertyDescriptorGridEntry[] mergedProperties = PropertyMerger.GetMergedProperties(arrObjects, this, base.menmPropertySort, CurrentTab);
				if (mergedProperties != null)
				{
					base.ChildCollection.AddRange(mergedProperties);
				}
				bool flag = Children.Count > 0;
				if (!flag)
				{
					SetState(524288, blnValue: true);
				}
				CategorizePropEntries();
				return flag;
			}
			catch
			{
				return false;
			}
		}
	}
}
