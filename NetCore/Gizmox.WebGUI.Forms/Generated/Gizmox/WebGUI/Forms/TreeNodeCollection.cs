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
	/// Collection of tree view nodes
	/// </summary>
	[Serializable]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public class TreeNodeCollection : BaseCollection, IList, ICollection, IEnumerable, IObservableList
	{
		private Component mobjParent = null;

		private ArrayList mobjTreeNodes = null;

		/// 
		/// Returns the owner treeview
		/// </summary>
		private TreeView TreeView
		{
			get
			{
				TreeView treeView = mobjParent as TreeView;
				if (treeView == null && mobjParent is TreeNode treeNode)
				{
					treeView = treeNode.TreeView;
				}
				return treeView;
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> at the specified indexed location in the collection.</summary>
		/// The <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> at the specified indexed location in the collection.</returns>
		/// <param name="intIndex">The indexed location of the <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> in the collection. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than 0 or is greater than the number of tree nodes in the collection. </exception>
		/// 1</filterpriority>
		public TreeNode this[int intIndex]
		{
			get
			{
				return (TreeNode)List[intIndex];
			}
			set
			{
				if (intIndex < 0 || intIndex >= List.Count)
				{
					throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", intIndex.ToString(CultureInfo.CurrentCulture)));
				}
				value.InternalParent = mobjParent;
				value.Index = intIndex;
				List[intIndex] = value;
			}
		}

		/// Gets the tree node with the specified key from the collection. </summary>
		/// The <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> with the specified key.</returns>
		/// <param name="key">The name of the <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> to retrieve from the collection.</param>
		/// 1</filterpriority>
		public virtual TreeNode this[string strKey]
		{
			get
			{
				if (!string.IsNullOrEmpty(strKey))
				{
					int intIndex = IndexOfKey(strKey);
					if (IsValidIndex(intIndex))
					{
						return this[intIndex];
					}
				}
				return null;
			}
		}

		/// 
		///
		/// </summary>
		public int ImageIndex
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		/// 
		/// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
		/// </summary>
		/// </value>
		/// An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
		protected override ArrayList List => mobjTreeNodes;

		bool IList.IsReadOnly => false;

		object IList.this[int intIndex]
		{
			get
			{
				return this[intIndex];
			}
			set
			{
			}
		}

		bool IList.IsFixedSize => false;

		/// 
		/// Occurs when [observable item inserted].
		/// </summary>
		public event ObservableListEventHandler ObservableItemInserted;

		/// 
		/// Occurs when [observable item added].
		/// </summary>
		public event ObservableListEventHandler ObservableItemAdded;

		/// 
		/// Occurs when [observable list cleared].
		/// </summary>
		public event EventHandler ObservableListCleared;

		/// 
		/// Occurs when [observable item removed].
		/// </summary>
		public event ObservableListEventHandler ObservableItemRemoved;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.TreeNodeCollection" /> instance.
		/// </summary>
		/// <param name="objParent">Obj parent.</param>
		public TreeNodeCollection(Component objParent)
		{
			mobjParent = objParent;
			mobjTreeNodes = new ArrayList();
		}

		protected internal TreeNodeCollection(Component objParent, object[] arrNodes)
		{
			mobjParent = objParent;
			mobjTreeNodes = new ArrayList(arrNodes);
		}

		/// 
		/// Adds the specified tree view node.
		/// </summary>
		/// <param name="objTreeViewNode">Obj tree view node.</param>
		/// </returns>
		public int Add(TreeNode objTreeViewNode)
		{
			objTreeViewNode.InternalParent = mobjParent;
			if (mobjParent != null)
			{
				mobjParent.Update();
			}
			objTreeViewNode.RegisterSelfNode();
			int num = 0;
			TreeView treeView = TreeView;
			num = ((treeView == null || !treeView.Sorted) ? List.Add(objTreeViewNode) : AddSorted(objTreeViewNode, treeView));
			if (this.ObservableItemAdded != null)
			{
				this.ObservableItemAdded(this, new ObservableListEventArgs(objTreeViewNode));
			}
			if (mobjParent is TreeNode treeNode)
			{
				treeNode.HasNodes = true;
			}
			return num;
		}

		/// 
		/// Adds a new tree node to the end of the current tree node collection with the specified label text.
		/// </summary>
		/// <param name="strText">The label text displayed by the TreeNode .</param>
		/// A TreeNode that represents the tree node being added to the collection.</returns>
		public virtual TreeNode Add(string strText)
		{
			TreeNode treeNode = new TreeNode(strText);
			Add(treeNode);
			return treeNode;
		}

		/// 
		/// Creates a new tree node with the specified key and text, and adds it to the collection.
		/// </summary>
		/// <param name="strKey">The name of the tree node.</param>
		/// <param name="strText">The text to display in the tree node.</param>
		/// The TreeNode that was added to the collection.</returns>
		public TreeNode Add(string strKey, string strText)
		{
			TreeNode treeNode = Add(strText);
			treeNode.Name = strKey;
			return treeNode;
		}

		/// 
		/// Creates a tree node with the specified key, text, and image, and adds it to the collection.
		/// </summary>
		/// <param name="strKey">The name of the tree node.</param>
		/// <param name="strText">The text to display in the tree node.</param>
		/// <param name="intImageIndex">The index of the image to display in the tree node.</param>
		/// The TreeNode that was added to the collection.</returns>
		public TreeNode Add(string strKey, string strText, int intImageIndex)
		{
			TreeNode treeNode = Add(strKey, strText);
			treeNode.ImageIndex = intImageIndex;
			return treeNode;
		}

		/// 
		/// Creates a tree node with the specified key, text, and image, and adds it to the collection.
		/// </summary>
		/// <param name="strKey">The name of the tree node.</param>
		/// <param name="strText">The text to display in the tree node.</param>
		/// <param name="strImageKey">The image to display in the tree node.</param>
		/// The TreeNode that was added to the collection.</returns>
		public TreeNode Add(string strKey, string strText, string strImageKey)
		{
			return Add(strKey, strText);
		}

		/// 
		/// Creates a tree node with the specified key, text, and images, and adds it to the collection
		/// </summary>
		/// <param name="strKey">The name of the tree node.</param>
		/// <param name="strText">The text to display in the tree node.</param>
		/// <param name="intImageIndex">The index of the image to display in the tree node.</param>
		/// <param name="intSelectedImageIndex">The index of the image to be displayed in the tree node when it is in a selected state.</param>
		/// The TreeNode that was added to the collection.</returns>
		public TreeNode Add(string strKey, string strText, int intImageIndex, int intSelectedImageIndex)
		{
			return Add(strKey, strText, intImageIndex);
		}

		/// 
		///
		/// </summary>
		/// <param name="strKey">The name of the tree node.</param>
		/// <param name="strText">The text to display in the tree node.</param>
		/// <param name="strImageKey">The key of the image to display in the tree node.</param>
		/// <param name="strIntSelectedImageIndex">The key of the image to display when the node is in a selected state.</param>
		/// The TreeNode that was added to the collection.</returns>
		public TreeNode Add(string strKey, string strText, string strImageKey, string strIntSelectedImageIndex)
		{
			return Add(strKey, strText);
		}

		/// 
		/// Add node in its sorted index
		/// </summary>
		/// <param name="objTreeNode">The obj tree node.</param>
		/// <param name="objTreeView">The obj tree view.</param>
		/// </returns>
		internal int AddSorted(TreeNode objTreeNode, TreeView objTreeView)
		{
			int num = 0;
			string text = objTreeNode.Text;
			if (Count > 0)
			{
				if (objTreeView.TreeViewNodeSorter == null)
				{
					CompareInfo compareInfo = VWGContext.Current.CurrentUICulture.CompareInfo;
					if (compareInfo.Compare(this[Count - 1].Text, text) <= 0)
					{
						num = Count;
					}
					else
					{
						int num2 = 0;
						int num3 = Count;
						while (num2 < num3)
						{
							int num4 = (num2 + num3) / 2;
							if (compareInfo.Compare(this[num4].Text, text) <= 0)
							{
								num2 = num4 + 1;
							}
							else
							{
								num3 = num4;
							}
						}
						num = num2;
					}
				}
				else
				{
					IComparer treeViewNodeSorter = objTreeView.TreeViewNodeSorter;
					int num2 = 0;
					int num3 = Count;
					while (num2 < num3)
					{
						int num4 = (num2 + num3) / 2;
						if (treeViewNodeSorter.Compare(this[num4], objTreeNode) <= 0)
						{
							num2 = num4 + 1;
						}
						else
						{
							num3 = num4;
						}
					}
					num = num2;
				}
			}
			objTreeNode.Nodes.SortChildren(objTreeView);
			List.Insert(num, objTreeNode);
			return num;
		}

		/// 
		/// Sorts current node children
		/// </summary>
		/// <param name="objParentTreeView">The current owner treeview</param>
		private void SortChildren(TreeView objParentTreeView)
		{
			if (Count <= 0)
			{
				return;
			}
			TreeNode[] array = new TreeNode[Count];
			if (objParentTreeView == null || objParentTreeView.TreeViewNodeSorter == null)
			{
				CompareInfo compareInfo = VWGContext.Current.CurrentUICulture.CompareInfo;
				for (int i = 0; i < Count; i++)
				{
					int num = -1;
					for (int j = 0; j < Count; j++)
					{
						if (this[j] != null)
						{
							if (num == -1)
							{
								num = j;
							}
							else if (compareInfo.Compare(((TreeNode)List[j]).Text, ((TreeNode)List[num]).Text) <= 0)
							{
								num = j;
							}
						}
					}
					array[i] = (TreeNode)List[num];
					List[num] = null;
					array[i].Nodes.SortChildren(objParentTreeView);
				}
			}
			else
			{
				IComparer treeViewNodeSorter = objParentTreeView.TreeViewNodeSorter;
				for (int k = 0; k < Count; k++)
				{
					int num2 = -1;
					for (int l = 0; l < Count; l++)
					{
						if (List[l] != null)
						{
							if (num2 == -1)
							{
								num2 = l;
							}
							else if (treeViewNodeSorter.Compare((TreeNode)List[l], (TreeNode)List[num2]) <= 0)
							{
								num2 = l;
							}
						}
					}
					array[k] = (TreeNode)List[num2];
					List[num2] = null;
					array[k].Nodes.SortChildren(objParentTreeView);
				}
			}
			List.Clear();
			List.AddRange(array);
		}

		/// 
		/// Clear the node collection 
		/// </summary>
		public void Clear()
		{
			((IRegisteredComponent)mobjParent).UnregisterComponents();
			List.Clear();
			if (mobjParent != null)
			{
				mobjParent.Update();
			}
			if (mobjParent is TreeNode treeNode)
			{
				treeNode.HasNodes = false;
			}
			if (this.ObservableListCleared != null)
			{
				this.ObservableListCleared(this, EventArgs.Empty);
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="arrTreeViewNodes"></param>
		public void AddRange(TreeNode[] arrTreeViewNodes)
		{
			foreach (TreeNode objTreeViewNode in arrTreeViewNodes)
			{
				Add(objTreeViewNode);
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objArray"></param>
		/// <param name="intIndex"></param>
		public new void CopyTo(Array objArray, int intIndex)
		{
			List.CopyTo(objArray, intIndex);
		}

		/// 
		/// Removes the specified tree view node.
		/// </summary>
		/// <param name="objTreeViewNode">Obj tree view node.</param>
		public void Remove(TreeNode objTreeViewNode)
		{
			if (objTreeViewNode.InternalParent == mobjParent)
			{
				objTreeViewNode.InternalParent = null;
			}
			RemoveAt(List.IndexOf(objTreeViewNode));
			if (List.Count == 0 && mobjParent is TreeNode treeNode)
			{
				treeNode.HasNodes = false;
			}
			if (mobjParent != null)
			{
				mobjParent.Update();
			}
			if (this.ObservableItemRemoved != null)
			{
				this.ObservableItemRemoved(this, new ObservableListEventArgs(objTreeViewNode));
			}
		}

		/// 
		/// Removes the current tree node from the tree view control at a specified index.
		/// </summary>
		/// <param name="intIndex"></param>
		public void RemoveAt(int intIndex)
		{
			if (IsValidIndex(intIndex))
			{
				if (List[intIndex] is TreeNode treeNode)
				{
					treeNode.UnRegisterSelfNode();
				}
				List.RemoveAt(intIndex);
			}
		}

		/// 
		/// Returns the index of the first occurrence of a tree node.
		/// </summary>
		/// <param name="strKey"></param>
		/// </returns>
		public int IndexOf(TreeNode objNode)
		{
			if (objNode != null)
			{
				return List.IndexOf(objNode);
			}
			return -1;
		}

		/// 
		/// Returns the index of the first occurrence of a tree node with the specified key.
		/// </summary>
		/// <param name="strKey"></param>
		/// </returns>
		public int IndexOfKey(string strKey)
		{
			if (!string.IsNullOrEmpty(strKey))
			{
				foreach (TreeNode item in List)
				{
					if (item.Name == strKey)
					{
						return List.IndexOf(item);
					}
				}
			}
			return -1;
		}

		/// 
		/// Removes the tree node with the specified key from the collection.
		/// </summary>
		/// <param name="strKey"></param>
		public void RemoveByKey(string strKey)
		{
			int intIndex = IndexOfKey(strKey);
			if (IsValidIndex(intIndex))
			{
				RemoveAt(intIndex);
			}
		}

		/// 
		/// Determines whether the collection contains a tree node with the specified key.
		/// </summary>
		/// <param name="strKey"></param>
		/// </returns>
		public bool ContainsKey(string strKey)
		{
			return IsValidIndex(IndexOfKey(strKey));
		}

		/// 
		/// Determines whether [contains] [the specified obj tree node].
		/// </summary>
		/// <param name="objTreeNode">The obj tree node.</param>
		/// 
		/// 	true</c> if [contains] [the specified obj tree node]; otherwise, false</c>.
		/// </returns>
		public bool Contains(TreeNode objTreeNode)
		{
			return List.IndexOf(objTreeNode) != -1;
		}

		/// 
		/// Determines if Index is valid
		/// </summary>
		/// <param name="intIndex"></param>
		/// </returns>
		private bool IsValidIndex(int intIndex)
		{
			return List != null && intIndex >= 0 && intIndex < List.Count;
		}

		/// 
		/// Insert the specified tree view node.
		/// </summary>
		/// <param name="intIndex"></param>
		/// <param name="objTreeViewNode"></param>
		public void Insert(int intIndex, TreeNode objTreeViewNode)
		{
			if (IsValidIndex(intIndex))
			{
				objTreeViewNode.InternalParent = mobjParent;
				List.Insert(intIndex, objTreeViewNode);
				objTreeViewNode.RegisterSelfNode();
				if (mobjParent != null)
				{
					mobjParent.Update();
				}
			}
		}

		/// 
		/// Finds the tree nodes with specified key, optionally searching subnodes.
		/// </summary>
		/// <param name="strKey">The name of the tree node to search for.</param>
		/// <param name="blnSearchAllChildren">if set to true</c> [search child nodes of tree nodes].</param>
		/// An array of TreeNode objects whose TreeNode.Name property matches the specified key.</returns>
		public TreeNode[] Find(string strKey, bool blnSearchAllChildren)
		{
			ArrayList arrayList = FindInternal(strKey, blnSearchAllChildren, this, new ArrayList());
			TreeNode[] array = new TreeNode[arrayList.Count];
			arrayList.CopyTo(array, 0);
			return array;
		}

		/// 
		/// Finds the tree nodes with specified key, optionally searching subnodes.
		/// </summary>
		/// <param name="strKey">The name of the tree node to search for.</param>
		/// <param name="blnSearchAllChildren">if set to true</c> [search child nodes of tree nodes].</param>
		/// <param name="objTreeNodeCollectionToLookIn">The collection of nodes to search within</param>
		/// <param name="objFoundTreeNodes">The collection of nodes that was already found</param>
		/// An array of TreeNode objects whose TreeNode.Name property matches the specified key.</returns>
		private ArrayList FindInternal(string strKey, bool blnSearchAllChildren, TreeNodeCollection objTreeNodeCollectionToLookIn, ArrayList objFoundTreeNodes)
		{
			if (objTreeNodeCollectionToLookIn == null || objFoundTreeNodes == null)
			{
				return null;
			}
			for (int i = 0; i < objTreeNodeCollectionToLookIn.Count; i++)
			{
				if (objTreeNodeCollectionToLookIn[i] != null && ClientUtils.SafeCompareStrings(objTreeNodeCollectionToLookIn[i].Name, strKey, blnIgnoreCase: true))
				{
					objFoundTreeNodes.Add(objTreeNodeCollectionToLookIn[i]);
				}
			}
			if (blnSearchAllChildren)
			{
				for (int j = 0; j < objTreeNodeCollectionToLookIn.Count; j++)
				{
					if (objTreeNodeCollectionToLookIn[j] != null && objTreeNodeCollectionToLookIn[j].Nodes != null && objTreeNodeCollectionToLookIn[j].Nodes.Count > 0)
					{
						objFoundTreeNodes = FindInternal(strKey, blnSearchAllChildren, objTreeNodeCollectionToLookIn[j].Nodes, objFoundTreeNodes);
					}
				}
			}
			return objFoundTreeNodes;
		}

		void IList.Remove(object objValue)
		{
			Remove((TreeNode)objValue);
		}

		bool IList.Contains(object objValue)
		{
			return List.Contains((TreeNode)objValue);
		}

		int IList.IndexOf(object objValue)
		{
			return List.IndexOf(objValue);
		}

		int IList.Add(object objValue)
		{
			return Add((TreeNode)objValue);
		}

		void IList.Insert(int intIndex, object objNode)
		{
			if (!(objNode is TreeNode))
			{
				throw new ArgumentException("node");
			}
			Insert(intIndex, (TreeNode)objNode);
		}

		void IList.RemoveAt(int intIndex)
		{
			RemoveAt(intIndex);
		}
	}
}
