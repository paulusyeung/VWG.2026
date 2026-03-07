// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TreeNodeCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Collection of tree view nodes</summary>
  [Browsable(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [Serializable]
  public class TreeNodeCollection : BaseCollection, IList, ICollection, IEnumerable, IObservableList
  {
    private Component mobjParent;
    private ArrayList mobjTreeNodes;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.TreeNodeCollection" /> instance.
    /// </summary>
    /// <param name="objParent">Obj parent.</param>
    public TreeNodeCollection(Component objParent)
    {
      this.mobjParent = objParent;
      this.mobjTreeNodes = new ArrayList();
    }

    protected internal TreeNodeCollection(Component objParent, object[] arrNodes)
    {
      this.mobjParent = objParent;
      this.mobjTreeNodes = new ArrayList((ICollection) arrNodes);
    }

    /// <summary>Adds the specified tree view node.</summary>
    /// <param name="objTreeViewNode">Obj tree view node.</param>
    /// <returns></returns>
    public int Add(TreeNode objTreeViewNode)
    {
      objTreeViewNode.InternalParent = this.mobjParent;
      if (this.mobjParent != null)
        this.mobjParent.Update();
      objTreeViewNode.RegisterSelfNode();
      TreeView treeView = this.TreeView;
      int num = treeView == null || !treeView.Sorted ? this.List.Add((object) objTreeViewNode) : this.AddSorted(objTreeViewNode, treeView);
      if (this.ObservableItemAdded != null)
        this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objTreeViewNode));
      if (this.mobjParent is TreeNode mobjParent)
        mobjParent.HasNodes = true;
      return num;
    }

    /// <summary>
    /// Adds a new tree node to the end of the current tree node collection with the specified label text.
    /// </summary>
    /// <param name="strText">The label text displayed by the TreeNode .</param>
    /// <returns>A TreeNode that represents the tree node being added to the collection.</returns>
    public virtual TreeNode Add(string strText)
    {
      TreeNode objTreeViewNode = new TreeNode(strText);
      this.Add(objTreeViewNode);
      return objTreeViewNode;
    }

    /// <summary>
    /// Creates a new tree node with the specified key and text, and adds it to the collection.
    /// </summary>
    /// <param name="strKey">The name of the tree node.</param>
    /// <param name="strText">The text to display in the tree node.</param>
    /// <returns>The TreeNode that was added to the collection.</returns>
    public TreeNode Add(string strKey, string strText)
    {
      TreeNode treeNode = this.Add(strText);
      treeNode.Name = strKey;
      return treeNode;
    }

    /// <summary>
    /// Creates a tree node with the specified key, text, and image, and adds it to the collection.
    /// </summary>
    /// <param name="strKey">The name of the tree node.</param>
    /// <param name="strText">The text to display in the tree node.</param>
    /// <param name="intImageIndex">The index of the image to display in the tree node.</param>
    /// <returns>The TreeNode that was added to the collection.</returns>
    public TreeNode Add(string strKey, string strText, int intImageIndex)
    {
      TreeNode treeNode = this.Add(strKey, strText);
      treeNode.ImageIndex = intImageIndex;
      return treeNode;
    }

    /// <summary>
    /// Creates a tree node with the specified key, text, and image, and adds it to the collection.
    /// </summary>
    /// <param name="strKey">The name of the tree node.</param>
    /// <param name="strText">The text to display in the tree node.</param>
    /// <param name="strImageKey">The image to display in the tree node.</param>
    /// <returns>The TreeNode that was added to the collection.</returns>
    public TreeNode Add(string strKey, string strText, string strImageKey) => this.Add(strKey, strText);

    /// <summary>
    /// Creates a tree node with the specified key, text, and images, and adds it to the collection
    /// </summary>
    /// <param name="strKey">The name of the tree node.</param>
    /// <param name="strText">The text to display in the tree node.</param>
    /// <param name="intImageIndex">The index of the image to display in the tree node.</param>
    /// <param name="intSelectedImageIndex">The index of the image to be displayed in the tree node when it is in a selected state.</param>
    /// <returns>The TreeNode that was added to the collection.</returns>
    public TreeNode Add(
      string strKey,
      string strText,
      int intImageIndex,
      int intSelectedImageIndex)
    {
      return this.Add(strKey, strText, intImageIndex);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strKey">The name of the tree node.</param>
    /// <param name="strText">The text to display in the tree node.</param>
    /// <param name="strImageKey">The key of the image to display in the tree node.</param>
    /// <param name="strIntSelectedImageIndex">The key of the image to display when the node is in a selected state.</param>
    /// <returns>The TreeNode that was added to the collection.</returns>
    public TreeNode Add(
      string strKey,
      string strText,
      string strImageKey,
      string strIntSelectedImageIndex)
    {
      return this.Add(strKey, strText);
    }

    /// <summary>Add node in its sorted index</summary>
    /// <param name="objTreeNode">The obj tree node.</param>
    /// <param name="objTreeView">The obj tree view.</param>
    /// <returns></returns>
    internal int AddSorted(TreeNode objTreeNode, TreeView objTreeView)
    {
      int index = 0;
      string text = objTreeNode.Text;
      if (this.Count > 0)
      {
        if (objTreeView.TreeViewNodeSorter == null)
        {
          CompareInfo compareInfo = VWGContext.Current.CurrentUICulture.CompareInfo;
          if (compareInfo.Compare(this[this.Count - 1].Text, text) <= 0)
          {
            index = this.Count;
          }
          else
          {
            int num1 = 0;
            int num2 = this.Count;
            while (num1 < num2)
            {
              int intIndex = (num1 + num2) / 2;
              if (compareInfo.Compare(this[intIndex].Text, text) <= 0)
                num1 = intIndex + 1;
              else
                num2 = intIndex;
            }
            index = num1;
          }
        }
        else
        {
          IComparer treeViewNodeSorter = objTreeView.TreeViewNodeSorter;
          int num3 = 0;
          int num4 = this.Count;
          while (num3 < num4)
          {
            int intIndex = (num3 + num4) / 2;
            if (treeViewNodeSorter.Compare((object) this[intIndex], (object) objTreeNode) <= 0)
              num3 = intIndex + 1;
            else
              num4 = intIndex;
          }
          index = num3;
        }
      }
      objTreeNode.Nodes.SortChildren(objTreeView);
      this.List.Insert(index, (object) objTreeNode);
      return index;
    }

    /// <summary>Sorts current node children</summary>
    /// <param name="objParentTreeView">The current owner treeview</param>
    private void SortChildren(TreeView objParentTreeView)
    {
      if (this.Count <= 0)
        return;
      TreeNode[] c = new TreeNode[this.Count];
      if (objParentTreeView == null || objParentTreeView.TreeViewNodeSorter == null)
      {
        CompareInfo compareInfo = VWGContext.Current.CurrentUICulture.CompareInfo;
        for (int index1 = 0; index1 < this.Count; ++index1)
        {
          int index2 = -1;
          for (int index3 = 0; index3 < this.Count; ++index3)
          {
            if (this[index3] != null)
            {
              if (index2 == -1)
                index2 = index3;
              else if (compareInfo.Compare(((TreeNode) this.List[index3]).Text, ((TreeNode) this.List[index2]).Text) <= 0)
                index2 = index3;
            }
          }
          c[index1] = (TreeNode) this.List[index2];
          this.List[index2] = (object) null;
          c[index1].Nodes.SortChildren(objParentTreeView);
        }
      }
      else
      {
        IComparer treeViewNodeSorter = objParentTreeView.TreeViewNodeSorter;
        for (int index4 = 0; index4 < this.Count; ++index4)
        {
          int index5 = -1;
          for (int index6 = 0; index6 < this.Count; ++index6)
          {
            if (this.List[index6] != null)
            {
              if (index5 == -1)
                index5 = index6;
              else if (treeViewNodeSorter.Compare((object) (TreeNode) this.List[index6], (object) (TreeNode) this.List[index5]) <= 0)
                index5 = index6;
            }
          }
          c[index4] = (TreeNode) this.List[index5];
          this.List[index5] = (object) null;
          c[index4].Nodes.SortChildren(objParentTreeView);
        }
      }
      this.List.Clear();
      this.List.AddRange((ICollection) c);
    }

    /// <summary>Returns the owner treeview</summary>
    private TreeView TreeView
    {
      get
      {
        if (!(this.mobjParent is TreeView treeView) && this.mobjParent is TreeNode mobjParent)
          treeView = mobjParent.TreeView;
        return treeView;
      }
    }

    /// <summary>Clear the node collection</summary>
    public void Clear()
    {
      ((IRegisteredComponent) this.mobjParent).UnregisterComponents();
      this.List.Clear();
      if (this.mobjParent != null)
        this.mobjParent.Update();
      if (this.mobjParent is TreeNode mobjParent)
        mobjParent.HasNodes = false;
      if (this.ObservableListCleared == null)
        return;
      this.ObservableListCleared((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrTreeViewNodes"></param>
    public void AddRange(TreeNode[] arrTreeViewNodes)
    {
      foreach (TreeNode arrTreeViewNode in arrTreeViewNodes)
        this.Add(arrTreeViewNode);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objArray"></param>
    /// <param name="intIndex"></param>
    public new void CopyTo(Array objArray, int intIndex) => this.List.CopyTo(objArray, intIndex);

    /// <summary>Removes the specified tree view node.</summary>
    /// <param name="objTreeViewNode">Obj tree view node.</param>
    public void Remove(TreeNode objTreeViewNode)
    {
      if (objTreeViewNode.InternalParent == this.mobjParent)
        objTreeViewNode.InternalParent = (Component) null;
      this.RemoveAt(this.List.IndexOf((object) objTreeViewNode));
      if (this.List.Count == 0 && this.mobjParent is TreeNode mobjParent)
        mobjParent.HasNodes = false;
      if (this.mobjParent != null)
        this.mobjParent.Update();
      if (this.ObservableItemRemoved == null)
        return;
      this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) objTreeViewNode));
    }

    /// <summary>
    /// Removes the current tree node from the tree view control at a specified index.
    /// </summary>
    /// <param name="intIndex"></param>
    public void RemoveAt(int intIndex)
    {
      if (!this.IsValidIndex(intIndex))
        return;
      if (this.List[intIndex] is TreeNode treeNode)
        treeNode.UnRegisterSelfNode();
      this.List.RemoveAt(intIndex);
    }

    /// <summary>
    /// Returns the index of the first occurrence of a tree node.
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns></returns>
    public int IndexOf(TreeNode objNode) => objNode != null ? this.List.IndexOf((object) objNode) : -1;

    /// <summary>
    /// Returns the index of the first occurrence of a tree node with the specified key.
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns></returns>
    public int IndexOfKey(string strKey)
    {
      if (!string.IsNullOrEmpty(strKey))
      {
        foreach (TreeNode treeNode in this.List)
        {
          if (treeNode.Name == strKey)
            return this.List.IndexOf((object) treeNode);
        }
      }
      return -1;
    }

    /// <summary>
    /// Removes the tree node with the specified key from the collection.
    /// </summary>
    /// <param name="strKey"></param>
    public void RemoveByKey(string strKey)
    {
      int intIndex = this.IndexOfKey(strKey);
      if (!this.IsValidIndex(intIndex))
        return;
      this.RemoveAt(intIndex);
    }

    /// <summary>
    /// Determines whether the collection contains a tree node with the specified key.
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns></returns>
    public bool ContainsKey(string strKey) => this.IsValidIndex(this.IndexOfKey(strKey));

    /// <summary>
    /// Determines whether [contains] [the specified obj tree node].
    /// </summary>
    /// <param name="objTreeNode">The obj tree node.</param>
    /// <returns>
    /// 	<c>true</c> if [contains] [the specified obj tree node]; otherwise, <c>false</c>.
    /// </returns>
    public bool Contains(TreeNode objTreeNode) => this.List.IndexOf((object) objTreeNode) != -1;

    /// <summary>Determines if Index is valid</summary>
    /// <param name="intIndex"></param>
    /// <returns></returns>
    private bool IsValidIndex(int intIndex) => this.List != null && intIndex >= 0 && intIndex < this.List.Count;

    /// <summary>Insert the specified tree view node.</summary>
    /// <param name="intIndex"></param>
    /// <param name="objTreeViewNode"></param>
    public void Insert(int intIndex, TreeNode objTreeViewNode)
    {
      if (!this.IsValidIndex(intIndex))
        return;
      objTreeViewNode.InternalParent = this.mobjParent;
      this.List.Insert(intIndex, (object) objTreeViewNode);
      objTreeViewNode.RegisterSelfNode();
      if (this.mobjParent == null)
        return;
      this.mobjParent.Update();
    }

    /// <summary>
    /// Finds the tree nodes with specified key, optionally searching subnodes.
    /// </summary>
    /// <param name="strKey">The name of the tree node to search for.</param>
    /// <param name="blnSearchAllChildren">if set to <c>true</c> [search child nodes of tree nodes].</param>
    /// <returns>An array of TreeNode objects whose TreeNode.Name property matches the specified key.</returns>
    public TreeNode[] Find(string strKey, bool blnSearchAllChildren)
    {
      ArrayList arrayList = this.FindInternal(strKey, blnSearchAllChildren, this, new ArrayList());
      TreeNode[] treeNodeArray = new TreeNode[arrayList.Count];
      arrayList.CopyTo((Array) treeNodeArray, 0);
      return treeNodeArray;
    }

    /// <summary>
    /// Finds the tree nodes with specified key, optionally searching subnodes.
    /// </summary>
    /// <param name="strKey">The name of the tree node to search for.</param>
    /// <param name="blnSearchAllChildren">if set to <c>true</c> [search child nodes of tree nodes].</param>
    /// <param name="objTreeNodeCollectionToLookIn">The collection of nodes to search within</param>
    /// <param name="objFoundTreeNodes">The collection of nodes that was already found</param>
    /// <returns>An array of TreeNode objects whose TreeNode.Name property matches the specified key.</returns>
    private ArrayList FindInternal(
      string strKey,
      bool blnSearchAllChildren,
      TreeNodeCollection objTreeNodeCollectionToLookIn,
      ArrayList objFoundTreeNodes)
    {
      if (objTreeNodeCollectionToLookIn == null || objFoundTreeNodes == null)
        return (ArrayList) null;
      for (int intIndex = 0; intIndex < objTreeNodeCollectionToLookIn.Count; ++intIndex)
      {
        if (objTreeNodeCollectionToLookIn[intIndex] != null && ClientUtils.SafeCompareStrings(objTreeNodeCollectionToLookIn[intIndex].Name, strKey, true))
          objFoundTreeNodes.Add((object) objTreeNodeCollectionToLookIn[intIndex]);
      }
      if (blnSearchAllChildren)
      {
        for (int intIndex = 0; intIndex < objTreeNodeCollectionToLookIn.Count; ++intIndex)
        {
          if (objTreeNodeCollectionToLookIn[intIndex] != null && objTreeNodeCollectionToLookIn[intIndex].Nodes != null && objTreeNodeCollectionToLookIn[intIndex].Nodes.Count > 0)
            objFoundTreeNodes = this.FindInternal(strKey, blnSearchAllChildren, objTreeNodeCollectionToLookIn[intIndex].Nodes, objFoundTreeNodes);
        }
      }
      return objFoundTreeNodes;
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> at the specified indexed location in the collection.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> at the specified indexed location in the collection.</returns>
    /// <param name="intIndex">The indexed location of the <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> in the collection. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than 0 or is greater than the number of tree nodes in the collection. </exception>
    /// <filterpriority>1</filterpriority>
    public TreeNode this[int intIndex]
    {
      get => (TreeNode) this.List[intIndex];
      set
      {
        if (intIndex < 0 || intIndex >= this.List.Count)
          throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", (object) "index", (object) intIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        value.InternalParent = this.mobjParent;
        value.Index = intIndex;
        this.List[intIndex] = (object) value;
      }
    }

    /// <summary>Gets the tree node with the specified key from the collection. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> with the specified key.</returns>
    /// <param name="key">The name of the <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> to retrieve from the collection.</param>
    /// <filterpriority>1</filterpriority>
    public virtual TreeNode this[string strKey]
    {
      get
      {
        if (!string.IsNullOrEmpty(strKey))
        {
          int intIndex = this.IndexOfKey(strKey);
          if (this.IsValidIndex(intIndex))
            return this[intIndex];
        }
        return (TreeNode) null;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public int ImageIndex
    {
      get => -1;
      set
      {
      }
    }

    /// <summary>
    /// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
    /// </summary>
    /// <value></value>
    /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
    protected override ArrayList List => this.mobjTreeNodes;

    bool IList.IsReadOnly => false;

    object IList.this[int intIndex]
    {
      get => (object) this[intIndex];
      set
      {
      }
    }

    void IList.Remove(object objValue) => this.Remove((TreeNode) objValue);

    bool IList.Contains(object objValue) => this.List.Contains((object) (TreeNode) objValue);

    int IList.IndexOf(object objValue) => this.List.IndexOf(objValue);

    int IList.Add(object objValue) => this.Add((TreeNode) objValue);

    bool IList.IsFixedSize => false;

    void IList.Insert(int intIndex, object objNode)
    {
      if (!(objNode is TreeNode))
        throw new ArgumentException("node");
      this.Insert(intIndex, (TreeNode) objNode);
    }

    void IList.RemoveAt(int intIndex) => this.RemoveAt(intIndex);

    /// <summary>Occurs when [observable item inserted].</summary>
    public event ObservableListEventHandler ObservableItemInserted;

    /// <summary>Occurs when [observable item added].</summary>
    public event ObservableListEventHandler ObservableItemAdded;

    /// <summary>Occurs when [observable list cleared].</summary>
    public event EventHandler ObservableListCleared;

    /// <summary>Occurs when [observable item removed].</summary>
    public event ObservableListEventHandler ObservableItemRemoved;
  }
}
