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
	/// Summary description for TreeNode.
	/// </summary>
	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ProxyComponent(typeof(ProxyTreeNode))]
	public class TreeNode : Component
	{
		/// 
		/// Provides a property reference to BackColor property.
		/// </summary>
		private static SerializableProperty BackColorProperty = SerializableProperty.Register("BackColor", typeof(Color), typeof(TreeNode), new SerializablePropertyMetadata(Color.White));

		/// 
		/// Provides a property reference to CheckBox property.
		/// </summary>
		private static SerializableProperty CheckBoxProperty = SerializableProperty.Register("CheckBox", typeof(CheckBoxVisibility), typeof(TreeNode), new SerializablePropertyMetadata(CheckBoxVisibility.Inherited));

		/// 
		/// Provides a property reference to ExpandedImageIndex property.
		/// </summary>
		private static SerializableProperty ExpandedImageIndexProperty = SerializableProperty.Register("ExpandedImageIndex", typeof(int), typeof(TreeNode), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to ExpandedImage property.
		/// </summary>
		private static SerializableProperty ExpandedImageProperty = SerializableProperty.Register("ExpandedImage", typeof(ResourceHandle), typeof(TreeNode), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ForeColor property.
		/// </summary>
		private static SerializableProperty ForeColorProperty = SerializableProperty.Register("ForeColor", typeof(Color), typeof(TreeNode), new SerializablePropertyMetadata(Color.Black));

		/// 
		/// Provides a property reference to HasNodes property.
		/// </summary>
		private static SerializableProperty HasNodesProperty = SerializableProperty.Register("HasNodes", typeof(bool), typeof(TreeNode), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ImageIndex property.
		/// </summary>
		private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(TreeNode), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to ImageKey property.
		/// </summary>
		private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to Image property.
		/// </summary>
		private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(TreeNode), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to IsExpanded property.
		/// </summary>
		private static SerializableProperty IsExpandedProperty = SerializableProperty.Register("IsExpanded", typeof(bool), typeof(TreeNode), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to Label property.
		/// </summary>
		private static SerializableProperty LabelProperty = SerializableProperty.Register("Label", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to Name property.
		/// </summary>
		private static SerializableProperty NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to NodeFont property.
		/// </summary>
		private static SerializableProperty NodeFontProperty = SerializableProperty.Register("NodeFont", typeof(Font), typeof(TreeNode), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to SelectedImageIndex property.
		/// </summary>
		private static SerializableProperty SelectedImageIndexProperty = SerializableProperty.Register("SelectedImageIndex", typeof(int), typeof(TreeNode), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to SelectedImageKey property.
		/// </summary>
		private static SerializableProperty SelectedImageKeyProperty = SerializableProperty.Register("SelectedImageKey", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to SelectedImage property.
		/// </summary>
		private static SerializableProperty SelectedImageProperty = SerializableProperty.Register("SelectedImage", typeof(ResourceHandle), typeof(TreeNode), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to SelectOnRightClick property.
		/// </summary>
		private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register("SelectOnRightClick", typeof(SelectOnRightClickBehvior), typeof(TreeNode), new SerializablePropertyMetadata(SelectOnRightClickBehvior.Inherit));

		/// 
		/// Provides a property reference to StateImageIndex property. 
		/// </summary>
		private static SerializableProperty StateImageIndexProperty = SerializableProperty.Register("StateImageIndex", typeof(int), typeof(TreeNode), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to StateImageKey property. 
		/// </summary>
		private static SerializableProperty StateImageKeyProperty = SerializableProperty.Register("StateImageKey", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to StateImage property.
		/// </summary>
		private static SerializableProperty StateImageProperty = SerializableProperty.Register("StateImage", typeof(ResourceHandle), typeof(TreeNode), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ToolTipText property.
		/// </summary>
		private static SerializableProperty ToolTipTextProperty = SerializableProperty.Register("ToolTipText", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to ExpandedImageKey property.
		/// </summary>
		private static SerializableProperty ExpandedImageKeyProperty = SerializableProperty.Register("ExpandedImageKey", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// The node collection
		/// </summary>
		[NonSerialized]
		private TreeNodeCollection mobjNodes = null;

		/// 
		/// The NodeMouseDoubleClick event registration.
		/// </summary>
		private static readonly SerializableEvent NodeMouseDoubleClickEvent;

		/// 
		/// The NodeMouseClick event registration.
		/// </summary>
		private static readonly SerializableEvent NodeMouseClickEvent;

		/// 
		/// The BeforeSelect event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeSelectEvent;

		/// 
		/// The BeforeLabelEdit event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeLabelEditEvent;

		/// 
		/// The BeforeExpand event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeExpandEvent;

		/// 
		/// The AfterExpand event registration.
		/// </summary>
		private static readonly SerializableEvent AfterExpandEvent;

		/// 
		/// The BeforeCheck event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeCheckEvent;

		/// 
		/// The AfterCheck event registration.
		/// </summary>
		private static readonly SerializableEvent AfterCheckEvent;

		/// 
		/// The AfterCollapse event registration.
		/// </summary>
		private static readonly SerializableEvent AfterCollapseEvent;

		/// 
		/// The BeforeCollapse event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeCollapseEvent;

		/// 
		/// The AfterLabelEdit event registration.
		/// </summary>
		private static readonly SerializableEvent AfterLabelEditEvent;

		/// 
		/// The AfterSelect event registration.
		/// </summary>
		private static readonly SerializableEvent AfterSelectEvent;

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize
		{
			get
			{
				int serializableDataInitialSize = base.SerializableDataInitialSize;
				return serializableDataInitialSize + SerializationWriter.GetRequiredCapacity(mobjNodes);
			}
		}

		/// 
		/// Gets the hanlder for the NodeMouseDoubleClick event.
		/// </summary>
		private TreeNodeMouseClickEventHandler NodeMouseDoubleClickHandler => (TreeNodeMouseClickEventHandler)GetHandler(NodeMouseDoubleClick);

		/// 
		/// Gets the hanlder for the NodeMouseClick event.
		/// </summary>
		private TreeNodeMouseClickEventHandler NodeMouseClickHandler => (TreeNodeMouseClickEventHandler)GetHandler(NodeMouseClick);

		/// 
		/// Gets the hanlder for the BeforeSelect event.
		/// </summary>
		private TreeViewCancelEventHandler BeforeSelectHandler => (TreeViewCancelEventHandler)GetHandler(BeforeSelect);

		/// 
		/// Gets the hanlder for the BeforeLabelEdit event.
		/// </summary>
		private NodeLabelEditEventHandler BeforeLabelEditHandler => (NodeLabelEditEventHandler)GetHandler(BeforeLabelEditEvent);

		/// 
		/// Gets the hanlder for the BeforeExpand event.
		/// </summary>
		private TreeViewCancelEventHandler BeforeExpandHandler => (TreeViewCancelEventHandler)GetHandler(BeforeExpand);

		/// 
		/// Gets the hanlder for the AfterExpand event.
		/// </summary>
		private TreeViewEventHandler AfterExpandHandler => (TreeViewEventHandler)GetHandler(AfterExpand);

		/// 
		/// Gets the hanlder for the BeforeCheck event.
		/// </summary>
		private TreeViewCancelEventHandler BeforeCheckHandler => (TreeViewCancelEventHandler)GetHandler(BeforeCheck);

		/// 
		/// Gets the hanlder for the AfterCheck event.
		/// </summary>
		private TreeViewEventHandler AfterCheckHandler => (TreeViewEventHandler)GetHandler(AfterCheck);

		/// 
		/// Gets the hanlder for the AfterCollapse event.
		/// </summary>
		private TreeViewEventHandler AfterCollapseHandler => (TreeViewEventHandler)GetHandler(AfterCollapse);

		/// 
		/// Gets the hanlder for the BeforeCollapse event.
		/// </summary>
		private TreeViewCancelEventHandler BeforeCollapseHandler => (TreeViewCancelEventHandler)GetHandler(BeforeCollapse);

		/// 
		/// Gets the hanlder for the AfterLabelEdit event.
		/// </summary>
		private NodeLabelEditEventHandler AfterLabelEditHandler => (NodeLabelEditEventHandler)GetHandler(AfterLabelEditEvent);

		/// 
		/// Gets the hanlder for the AfterSelect event.
		/// </summary>
		private TreeViewEventHandler AfterSelectHandler => (TreeViewEventHandler)GetHandler(AfterSelect);

		/// 
		/// This is a recursive function that loop through a control and all of its parents
		/// cheching if one of the controls(and control containers) is hidden or
		/// disabled.
		/// </summary>
		/// 
		/// 	true</c> if this instance is events enabled; otherwise, false</c>.
		/// </value>        
		/// false if one of the controls is hidden or disabled.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool IsEventsEnabled
		{
			get
			{
				if (!IsVisible)
				{
					return false;
				}
				return base.IsEventsEnabled;
			}
		}

		/// 
		/// Gets or sets the control visability.  
		/// </summary>
		[DefaultValue(true)]
		[SRDescription("TreeNodeVisibleDescr")]
		[SRCategory("CatBehavior")]
		public bool Visible
		{
			get
			{
				return GetState(ComponentState.Visible);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Visible, value))
				{
					InternalParent?.Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether check boxes are displayed.
		/// </summary>
		/// 
		/// 	true</c> if check boxes are displayed; otherwise, false</c>.
		/// </value>
		[DefaultValue(CheckBoxVisibility.Inherited)]
		public CheckBoxVisibility CheckBox
		{
			get
			{
				return GetValue(CheckBoxProperty);
			}
			set
			{
				if (SetValue(CheckBoxProperty, value))
				{
					Update();
					FireObservableItemPropertyChanged("CheckBox");
				}
			}
		}

		/// 
		/// Gets or sets the tool tip text for the tree node.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		public string ToolTipText
		{
			get
			{
				return GetValue(ToolTipTextProperty);
			}
			set
			{
				if (SetValue(ToolTipTextProperty, value))
				{
					UpdateParams(AttributeType.ToolTip);
				}
			}
		}

		/// 
		/// Gets the full path.
		/// </summary>
		/// </value>
		public string FullPath
		{
			get
			{
				TreeView treeView = TreeView;
				if (treeView != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					GetFullPath(stringBuilder, treeView.PathSeparator);
					return stringBuilder.ToString();
				}
				return "";
			}
		}

		/// 
		/// Gets the tree node parent.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public TreeNode Parent => InternalParent as TreeNode;

		/// Gets or sets the background color of the tree node.</summary>
		/// The background <see cref="T:System.Drawing.Color"></see> of the tree node. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("TreeNodeBackColorDescr")]
		public Color BackColor
		{
			get
			{
				return GetValue(BackColorProperty);
			}
			set
			{
				if (SetValue(BackColorProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets the first child tree node in the tree node collection.</summary>
		/// The first child <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> in the <see cref="P:Gizmox.WebGUI.Forms.TreeNode.Nodes"></see> collection.</returns>
		[Browsable(false)]
		public TreeNode FirstNode
		{
			get
			{
				TreeNodeCollection nodes = Nodes;
				if (nodes.Count == 0)
				{
					return null;
				}
				return nodes[0];
			}
		}

		/// Gets or sets the foreground color of the tree node.</summary>
		/// The foreground <see cref="T:System.Drawing.Color"></see> of the tree node.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("TreeNodeForeColorDescr")]
		public Color ForeColor
		{
			get
			{
				return GetValue(ForeColorProperty);
			}
			set
			{
				if (SetValue(ForeColorProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the select on right click.
		/// </summary>
		/// The select on right click.</value>
		[SRCategory("CatAppearance")]
		[SRDescription("SelectOnRightClickDescr")]
		[DefaultValue(SelectOnRightClickBehvior.Inherit)]
		public SelectOnRightClickBehvior SelectOnRightClick
		{
			get
			{
				return GetValue(SelectOnRightClickProperty);
			}
			set
			{
				if (SetValue(SelectOnRightClickProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets the position of the tree node in the tree node collection.</summary>
		/// A zero-based index value that represents the position of the tree node in the <see cref="P:Gizmox.WebGUI.Forms.TreeNode.Nodes"></see> collection.</returns>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeNodeIndexDescr")]
		public int Index
		{
			get
			{
				if (Parent != null)
				{
					return ((IList)Parent.Nodes).IndexOf((object)this);
				}
				if (TreeView != null)
				{
					return ((IList)TreeView.Nodes).IndexOf((object)this);
				}
				return -1;
			}
			internal set
			{
				if (Parent != null)
				{
					((IList)Parent.Nodes).Insert(value, (object)this);
				}
				else if (TreeView != null)
				{
					((IList)TreeView.Nodes).Insert(value, (object)this);
				}
			}
		}

		/// Gets a value indicating whether the tree node is in an editable state.</summary>
		/// true if the tree node is in editable state; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public bool IsEditing
		{
			get
			{
				TreeView treeView = TreeView;
				return treeView != null && treeView.EditNode == this;
			}
		}

		/// Gets a value indicating whether the tree node is in the selected state.</summary>
		/// true if the tree node is in the selected state; otherwise, false.</returns>
		[Browsable(false)]
		public bool IsSelected => Selected;

		/// Gets a value indicating whether the tree node is visible or partially visible.</summary>
		/// true if the tree node is visible or partially visible; otherwise, false.</returns>
		[Browsable(false)]
		public bool IsVisible => true;

		/// Gets the last child tree node.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the last child tree node.</returns>
		[Browsable(false)]
		public TreeNode LastNode
		{
			get
			{
				TreeNodeCollection nodes = Nodes;
				if (nodes.Count == 0)
				{
					return null;
				}
				return nodes[nodes.Count - 1];
			}
		}

		/// Gets the zero-based depth of the tree node in the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> control.</summary>
		/// The zero-based depth of the tree node in the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> control.</returns>
		[Browsable(false)]
		public int Level
		{
			get
			{
				if (Parent == null)
				{
					return 0;
				}
				return Parent.Level + 1;
			}
		}

		/// 
		/// Gets a value indicating whether this instance has a redrawing parent.
		/// </summary>
		/// 
		/// 	true</c> if this instance has redrawing parent; otherwise, false</c>.
		/// </value>
		private bool HasRedrawingParent
		{
			get
			{
				bool flag = false;
				Control control = TreeView;
				while (control != null && !flag)
				{
					if (control.Redraws)
					{
						flag = true;
					}
					else
					{
						control = control.Parent;
					}
				}
				return flag;
			}
		}

		private TreeNodeCollection ParentNodes
		{
			get
			{
				if (Parent != null)
				{
					return Parent.Nodes;
				}
				if (TreeView != null)
				{
					return TreeView.Nodes;
				}
				return null;
			}
		}

		private TreeNode NextUncle
		{
			get
			{
				bool flag = false;
				TreeNode treeNode = this;
				do
				{
					if (treeNode.Parent != null)
					{
						if (treeNode.Parent.ParentNodes.Count > treeNode.Parent.Index + 1)
						{
							return treeNode.Parent.ParentNodes[treeNode.Parent.Index + 1];
						}
						treeNode = treeNode.Parent;
						continue;
					}
					return null;
				}
				while (true);
				TreeNode treeNode2 = null;
				return treeNode2;
			}
		}

		/// Gets the previous sibling tree node.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the previous sibling tree node.</returns>
		[Browsable(false)]
		public TreeNode PrevNode
		{
			get
			{
				int index = Index;
				if (index < 1)
				{
					return null;
				}
				return ParentNodes?[index - 1];
			}
		}

		/// Gets the previous visible tree node.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the previous visible tree node.</returns>  
		[Browsable(false)]
		public TreeNode PrevVisibleNode
		{
			get
			{
				TreeNode result = null;
				if (PrevNode != null)
				{
					result = PrevNode.LastVisibleChild;
				}
				else if (Parent != null)
				{
					result = Parent;
				}
				return result;
			}
		}

		/// 
		/// Returns last visible child of last child
		/// or self if no children or not expanded
		/// </summary>
		private TreeNode LastVisibleChild
		{
			get
			{
				TreeNode treeNode = this;
				while (treeNode.IsExpanded && treeNode.LastChild != null)
				{
					treeNode = treeNode.LastChild;
				}
				return treeNode;
			}
		}

		/// 
		/// Returns the last child of this node,
		/// if any, otherwise returns null
		/// </summary>
		private TreeNode LastChild
		{
			get
			{
				TreeNode result = null;
				if (Nodes != null && Nodes.Count > 0)
				{
					result = Nodes[Nodes.Count - 1];
				}
				return result;
			}
		}

		/// Gets the next sibling tree node.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the next sibling tree node.</returns>
		[Browsable(false)]
		public TreeNode NextNode
		{
			get
			{
				TreeNodeCollection parentNodes = ParentNodes;
				if (parentNodes != null)
				{
					int index = Index;
					if (parentNodes.Count > index + 1)
					{
						return parentNodes[index + 1];
					}
					return null;
				}
				return null;
			}
		}

		/// Gets the next visible tree node.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the next visible tree node.</returns>
		/// 1</filterpriority>        
		[Browsable(false)]
		public TreeNode NextVisibleNode
		{
			get
			{
				TreeNode treeNode = null;
				if (IsExpanded && Nodes.Count > 0)
				{
					return Nodes[0];
				}
				if (NextNode != null)
				{
					return NextNode;
				}
				return NextUncle;
			}
		}

		/// 
		/// Gets or sets the node font.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Font NodeFont
		{
			get
			{
				return GetValue(NodeFontProperty);
			}
			set
			{
				if (SetValue(NodeFontProperty, value))
				{
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets or sets the selected image index.
		/// </summary>
		/// </value>
		[SRCategory("CatBehavior")]
		[DefaultValue(-1)]
		public int SelectedImageIndex
		{
			get
			{
				return GetValue(SelectedImageIndexProperty);
			}
			set
			{
				if (SetValue(SelectedImageIndexProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the index of the image used to indicate the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> when the parent <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> has its <see cref="P:Gizmox.WebGUI.Forms.TreeView.CheckBoxes"></see> property set to false.</summary>
		/// The index of the image used to indicate the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("TreeView.StateImageList")]
		[SRDescription("TreeNodeStateImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		public int StateImageIndex
		{
			get
			{
				return GetValue(StateImageIndexProperty);
			}
			set
			{
				if (SetValue(StateImageIndexProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the image index.
		/// </summary>
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("TreeView.ImageList")]
		[SRDescription("TreeNodeImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		public int ImageIndex
		{
			get
			{
				return GetValue(ImageIndexProperty);
			}
			set
			{
				if (SetValue(ImageIndexProperty, value))
				{
					RemoveValue(ImageKeyProperty);
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the key of the image displayed in the tree node when it is in a selected state.</summary>
		/// The key of the image displayed when the tree node is in a selected state.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("TreeView.ImageList")]
		[SRDescription("TreeNodeImageKeyDescr")]
		[Localizable(true)]
		[DefaultValue("")]
		public string SelectedImageKey
		{
			get
			{
				return GetValue(SelectedImageKeyProperty);
			}
			set
			{
				if (SetValue(SelectedImageKeyProperty, value))
				{
					RemoveValue(SelectedImageIndexProperty);
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the key of the image displayed in the tree node when it is in a selected state.</summary>
		/// The key of the image displayed when the tree node is in a selected state.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("TreeView.StateImageList")]
		[SRDescription("TreeNodeStateImageKeyDescr")]
		[Localizable(true)]
		[DefaultValue("")]
		public string StateImageKey
		{
			get
			{
				return GetValue(StateImageKeyProperty);
			}
			set
			{
				if (SetValue(StateImageKeyProperty, value))
				{
					RemoveValue(StateImageIndexProperty);
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the key for the image that is displayed for the item.</summary>
		/// The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("TreeView.ImageList")]
		[SRDescription("TreeNodeImageKeyDescr")]
		[Localizable(true)]
		[DefaultValue("")]
		public string ImageKey
		{
			get
			{
				return GetValue(ImageKeyProperty);
			}
			set
			{
				if (SetValue(ImageKeyProperty, value))
				{
					RemoveValue(ImageIndexProperty);
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets the parent tree view that the tree node is assigned to.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> that represents the parent tree view that the tree node is assigned to, or null if the node has not been assigned to a tree view.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public TreeView TreeView => GetAncestorByType(typeof(TreeView)) as TreeView;

		/// Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> objects assigned to the current tree node.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeCollection"></see> that represents the tree nodes assigned to the current tree node.</returns>
		/// 1</filterpriority>
		[ListBindable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public TreeNodeCollection Nodes => mobjNodes;

		/// Gets a value indicating whether the tree node is in the expanded state.</summary>
		/// true if the tree node is in the expanded state; otherwise, false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsExpanded
		{
			get
			{
				return GetValue(IsExpandedProperty);
			}
			set
			{
				if (IsExpanded != value)
				{
					if (value)
					{
						Expand();
					}
					else
					{
						Collapse(blnIgnoreChildren: true);
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.TreeNode" /> is selected.
		/// </summary>
		/// 
		/// 	true</c> if selected; otherwise, false</c>.
		/// </value>
		internal bool Selected
		{
			get
			{
				return GetState(ComponentState.Selected);
			}
			set
			{
				SetSelected(value, blnUpdate: true);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.TreeNode" /> is checked.
		/// </summary>
		/// true</c> if checked; otherwise, false</c>.</value>
		[DefaultValue(false)]
		public bool Checked
		{
			get
			{
				return GetState(ComponentState.Checked);
			}
			set
			{
				ChangeCheckState(value, TreeViewAction.Unknown);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.TreeNode" /> is loaded.
		/// </summary>
		/// 
		/// 	true</c> if loaded; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Loaded
		{
			get
			{
				return GetState(ComponentState.Loaded);
			}
			set
			{
				SetState(ComponentState.Loaded, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance has nodes.
		/// </summary>
		/// 
		/// 	true</c> if this instance has nodes; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool HasNodes
		{
			get
			{
				return GetValue(HasNodesProperty);
			}
			set
			{
				SetValue(HasNodesProperty, value);
			}
		}

		/// 
		/// The tree node name
		/// </summary>
		[Browsable(false)]
		public string Name
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

		/// 
		/// The tree node label
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Label
		{
			get
			{
				return Text;
			}
			set
			{
				Text = value;
			}
		}

		/// 
		/// Gets or sets the text.
		/// </summary>
		/// </value>
		[Localizable(true)]
		[DefaultValue("")]
		public string Text
		{
			get
			{
				return TextInternal;
			}
			set
			{
				if (TextInternal != value)
				{
					TextInternal = value;
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the text internal.
		/// </summary>
		/// The text internal.</value>
		private string TextInternal
		{
			get
			{
				return GetValue(LabelProperty);
			}
			set
			{
				SetValue(LabelProperty, value);
			}
		}

		/// 
		/// The tree node icon
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public ResourceHandle Image
		{
			get
			{
				return GetImage(ImageProperty, ImageList, ImageIndex, ImageKey, (TreeView != null) ? TreeView.ImageIndex : (-1), (TreeView != null) ? TreeView.ImageKey : string.Empty);
			}
			set
			{
				if (!SetImage(ImageProperty, value, ImageList))
				{
					return;
				}
				bool flag = false;
				if (InternalParent != null)
				{
					TreeNodeCollection treeNodesFromComponent = GetTreeNodesFromComponent(InternalParent);
					if (treeNodesFromComponent != null)
					{
						foreach (TreeNode item in treeNodesFromComponent)
						{
							if (item != this && item.Image != null)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							InternalParent.Update();
						}
					}
				}
				if (flag)
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets the image list.
		/// </summary>
		/// The image list.</value>
		private ImageList ImageList
		{
			get
			{
				if (TreeView != null)
				{
					return TreeView.ImageList;
				}
				return null;
			}
		}

		/// 
		/// Gets the image list.
		/// </summary>
		/// The image list.</value>
		private ImageList StateImageList
		{
			get
			{
				if (TreeView != null)
				{
					return TreeView.StateImageList;
				}
				return null;
			}
		}

		/// 
		/// The selected tree node icon
		/// </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ResourceHandle SelectedImage
		{
			get
			{
				return GetImage(SelectedImageProperty, ImageList, SelectedImageIndex, SelectedImageKey, (TreeView != null) ? TreeView.SelectedImageIndex : (-1), (TreeView != null) ? TreeView.SelectedImageKey : string.Empty);
			}
			set
			{
				if (SetImage(SelectedImageProperty, value, ImageList))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// The selected tree node icon
		/// </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ResourceHandle StateImage
		{
			get
			{
				return GetImage(StateImageProperty, StateImageList, StateImageIndex, StateImageKey, -1, string.Empty);
			}
			set
			{
				SetImage(StateImageProperty, value, StateImageList);
			}
		}

		/// 
		/// The expanded tree node icon
		/// </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ResourceHandle ExpandedImage
		{
			get
			{
				return GetImage(ExpandedImageProperty, ImageList, ExpandedImageIndex, ExpandedImageKey, (TreeView != null) ? TreeView.ExpandedImageIndex : (-1), (TreeView != null) ? TreeView.ExpandedImageKey : string.Empty);
			}
			set
			{
				if (SetImage(ExpandedImageProperty, value, ImageList))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the expanded image index.
		/// </summary>
		/// </value>
		[SRCategory("CatBehavior")]
		[DefaultValue(-1)]
		public int ExpandedImageIndex
		{
			get
			{
				return GetValue(ExpandedImageIndexProperty);
			}
			set
			{
				if (SetValue(ExpandedImageIndexProperty, value))
				{
					RemoveValue(ExpandedImageKeyProperty);
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the key of the image displayed in the tree node when it is Expanded.</summary>
		/// The key of the image displayed when the tree node is Expanded.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("TreeView.ImageList")]
		[SRDescription("TreeNodeImageKeyDescr")]
		[Localizable(true)]
		[DefaultValue("")]
		public string ExpandedImageKey
		{
			get
			{
				return GetValue(ExpandedImageKeyProperty);
			}
			set
			{
				if (SetValue(ExpandedImageKeyProperty, value))
				{
					RemoveValue(ExpandedImageIndexProperty);
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets the bounds of the tree node.</summary>
		/// The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds of the tree node.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Rectangle Bounds => Rectangle.Empty;

		/// 
		/// Occurs when [client after label edit].
		/// </summary>
		[SRDescription("Occurs when control's label edited in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientAfterLabelEdit
		{
			add
			{
				AddClientHandler("AfterLabelEdit", value);
			}
			remove
			{
				RemoveClientHandler("AfterLabelEdit", value);
			}
		}

		/// Occurs when the user double-clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse.</summary>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewNodeMouseDoubleClickDescr")]
		public event TreeNodeMouseClickEventHandler NodeMouseDoubleClick
		{
			add
			{
				AddHandler(NodeMouseDoubleClickEvent, value);
			}
			remove
			{
				RemoveHandler(NodeMouseDoubleClickEvent, value);
			}
		}

		/// Occurs when the user clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse. </summary>
		[SRDescription("TreeViewNodeMouseClickDescr")]
		[SRCategory("CatBehavior")]
		public event TreeNodeMouseClickEventHandler NodeMouseClick
		{
			add
			{
				AddHandler(NodeMouseClickEvent, value);
			}
			remove
			{
				RemoveHandler(NodeMouseClickEvent, value);
			}
		}

		/// Occurs before the tree node is selected.</summary>
		[SRDescription("TreeViewBeforeSelectDescr")]
		[SRCategory("CatBehavior")]
		public event TreeViewCancelEventHandler BeforeSelect
		{
			add
			{
				AddHandler(BeforeSelectEvent, value);
			}
			remove
			{
				RemoveHandler(BeforeSelectEvent, value);
			}
		}

		/// Occurs before the tree node label text is edited.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewBeforeEditDescr")]
		public event NodeLabelEditEventHandler BeforeLabelEdit
		{
			add
			{
				AddHandler(BeforeLabelEditEvent, value);
			}
			remove
			{
				RemoveHandler(BeforeLabelEditEvent, value);
			}
		}

		/// Occurs before the tree node is expanded.</summary>
		[SRDescription("TreeViewBeforeExpandDescr")]
		[SRCategory("CatBehavior")]
		public event TreeViewCancelEventHandler BeforeExpand
		{
			add
			{
				AddHandler(BeforeExpandEvent, value);
			}
			remove
			{
				RemoveHandler(BeforeExpandEvent, value);
			}
		}

		/// Occurs after the tree node is expanded.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewAfterExpandDescr")]
		public event TreeViewEventHandler AfterExpand
		{
			add
			{
				AddHandler(AfterExpandEvent, value);
			}
			remove
			{
				RemoveHandler(AfterExpandEvent, value);
			}
		}

		/// Occurs before the tree node check box is checked.</summary>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewBeforeCheckDescr")]
		public event TreeViewCancelEventHandler BeforeCheck
		{
			add
			{
				AddHandler(BeforeCheckEvent, value);
			}
			remove
			{
				RemoveHandler(BeforeCheckEvent, value);
			}
		}

		/// Occurs after the tree node check box is checked.</summary>
		/// 1</filterpriority>
		[SRDescription("TreeViewAfterCheckDescr")]
		[SRCategory("CatBehavior")]
		public event TreeViewEventHandler AfterCheck
		{
			add
			{
				AddHandler(AfterCheckEvent, value);
			}
			remove
			{
				RemoveHandler(AfterCheckEvent, value);
			}
		}

		/// Occurs after the tree node is collapsed.</summary>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewAfterCollapseDescr")]
		public event TreeViewEventHandler AfterCollapse
		{
			add
			{
				AddHandler(AfterCollapseEvent, value);
			}
			remove
			{
				RemoveHandler(AfterCollapseEvent, value);
			}
		}

		/// Occurs before the tree node is collapsed.</summary>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewBeforeCollapseDescr")]
		public event TreeViewCancelEventHandler BeforeCollapse
		{
			add
			{
				AddHandler(BeforeCollapseEvent, value);
			}
			remove
			{
				RemoveHandler(BeforeCollapseEvent, value);
			}
		}

		/// Occurs after the tree node label text is edited.</summary>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewAfterEditDescr")]
		public event NodeLabelEditEventHandler AfterLabelEdit
		{
			add
			{
				AddHandler(AfterLabelEditEvent, value);
			}
			remove
			{
				RemoveHandler(AfterLabelEditEvent, value);
			}
		}

		/// Occurs after the tree node is selected.</summary>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewAfterSelectDescr")]
		public event TreeViewEventHandler AfterSelect
		{
			add
			{
				AddHandler(AfterSelectEvent, value);
			}
			remove
			{
				RemoveHandler(AfterSelectEvent, value);
			}
		}

		/// 
		/// Renders the update attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		internal void RenderUpdateAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
				RenderSelectOnRightClick(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
			{
				objWriter.WriteAttributeText("TT", ToolTipText);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				Font nodeFont = NodeFont;
				if (nodeFont != null)
				{
					objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(nodeFont));
				}
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderImages(objWriter);
			}
		}

		/// 
		/// Renders the select on right click.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
		{
			SelectOnRightClickBehvior selectOnRightClick = SelectOnRightClick;
			if (selectOnRightClick != SelectOnRightClickBehvior.Inherit)
			{
				objWriter.WriteAttributeString("SOR", Convert.ToByte(selectOnRightClick).ToString());
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SOR", string.Empty);
			}
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mobjNodes = CreateNodeCollection(objReader);
		}

		protected virtual TreeNodeCollection CreateNodeCollection(SerializationReader objReader)
		{
			return new TreeNodeCollection(this, objReader.ReadArray());
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteArray(mobjNodes);
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="strLabel"></param>
		/// <param name="strIcon"></param>
		public TreeNode(string strName, string strLabel, string strIcon)
		{
			SetValue(NameProperty, strName);
			SetValue(LabelProperty, strLabel);
			if (strIcon != "")
			{
				SetValue(ImageProperty, (ResourceHandle)new IconResourceHandle(strIcon + ".gif"));
			}
			mobjNodes = CreateNodeCollection();
			SetState(ComponentState.Visible | ComponentState.Loaded, blnValue: true);
		}

		/// 
		/// Creates the node collection.
		/// </summary>
		/// </returns>
		protected virtual TreeNodeCollection CreateNodeCollection()
		{
			return new TreeNodeCollection(this);
		}

		/// 
		///
		/// </summary>
		public TreeNode(string strLabel)
			: this("", strLabel, "")
		{
		}

		/// 
		///
		/// </summary>
		public TreeNode()
			: this("", "", "")
		{
		}

		/// 
		///
		/// </summary>
		public TreeNode(string strLabel, TreeNode[] arrTreeNodes)
			: this("", strLabel, "")
		{
			Nodes.AddRange(arrTreeNodes);
		}

		/// 
		///
		/// </summary>
		public TreeNode(string strLabel, int intImageIndex, int intSelectedImageIndex)
			: this(strLabel)
		{
			ImageIndex = intImageIndex;
			SelectedImageIndex = intSelectedImageIndex;
		}

		/// 
		///
		/// </summary>
		public TreeNode(string strLabel, int intImageIndex, int intSelectedImageIndex, TreeNode[] arrTreeNodes)
			: this(strLabel, arrTreeNodes)
		{
			ImageIndex = intImageIndex;
			SelectedImageIndex = intSelectedImageIndex;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			switch (objEvent.Type)
			{
			case "Click":
				OnNodeMouseClick(objEvent);
				break;
			case "DoubleClick":
				OnNodeMouseDoubleClick(objEvent);
				break;
			case "CheckedChange":
				ChangeCheckState(objEvent["Value"] == "1", TreeViewAction.ByMouse);
				break;
			case "Selection":
			{
				bool blnIsKeyboard = objEvent["Keyboard"] == "1";
				OnSelect(blnIsKeyboard);
				break;
			}
			case "FirstExpand":
			case "Expand":
				if (IsExpanded)
				{
					break;
				}
				if (!OnBeforeExpand())
				{
					SetValue(IsExpandedProperty, objValue: true);
					OnAfterExpand();
					if (objEvent.Type == "FirstExpand")
					{
						Update();
					}
				}
				else
				{
					Update();
				}
				break;
			case "Collapse":
				if (IsExpanded)
				{
					if (!OnBeforeCollapse())
					{
						SetValue(IsExpandedProperty, objValue: false);
						OnAfterCollapse();
					}
					else
					{
						Update();
					}
				}
				break;
			case "AfterLabelEdit":
			{
				string text = CommonUtils.DecodeText(objEvent["Text"]);
				NodeLabelEditEventArgs e = new NodeLabelEditEventArgs(this, text);
				OnAfterLabelEdit(e);
				if (!e.CancelEdit)
				{
					TextInternal = text;
				}
				else
				{
					UpdateParams(AttributeType.Control);
				}
				break;
			}
			case "StartDrag":
				TreeView?.FireItemDrag(new ItemDragEventArgs(MouseButtons.Left, this));
				break;
			}
		}

		private void OnSelect(bool blnIsKeyboard)
		{
			if (!IsSelected && TreeView != null)
			{
				TreeView.SelectNode(this, blnCode: false, blnIsKeyboard ? TreeViewAction.ByKeyboard : TreeViewAction.ByMouse);
			}
		}

		/// 
		/// Called when this node mouse is double clicked.
		/// </summary>
		private void OnNodeMouseDoubleClick(IEvent objEvent)
		{
			OnNodeMouseClick(objEvent);
			int eventValue = GetEventValue(objEvent, "X", 0);
			int eventValue2 = GetEventValue(objEvent, "Y", 0);
			TreeNodeMouseClickEventArgs e = CreateTreeNodeMouseClickEventArgs(this, MouseButtons.Left, 2, eventValue, eventValue2);
			OnNodeMouseDoubleClick(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
		protected virtual void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
		{
			OnSelect(blnIsKeyboard: false);
			NodeMouseDoubleClickHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnNodeMouseDoubleClickInternal(e);
			}
		}

		/// 
		/// Called when this node is clicked.
		/// </summary>
		private void OnNodeMouseClick(IEvent objEvent)
		{
			int eventValue = GetEventValue(objEvent, "X", 0);
			int eventValue2 = GetEventValue(objEvent, "Y", 0);
			MouseEventArgs e = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue, eventValue2, 0);
			TreeNodeMouseClickEventArgs e2 = CreateTreeNodeMouseClickEventArgs(this, e.Button, 1, e.X, e.Y);
			OnNodeMouseClick(e2);
		}

		/// 
		/// Creates the tree node mouse click event args.
		/// </summary>
		/// <param name="objNode">The node.</param>
		/// <param name="objButton">The button.</param>
		/// <param name="intClicks">The clicks.</param>
		/// <param name="intX">The X.</param>
		/// <param name="intY">The Y.</param>
		/// </returns>
		protected virtual TreeNodeMouseClickEventArgs CreateTreeNodeMouseClickEventArgs(TreeNode objNode, MouseButtons objButton, int intClicks, int intX, int intY)
		{
			return new TreeNodeMouseClickEventArgs(objNode, objButton, intClicks, intX, intY);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
		protected virtual void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
		{
			NodeMouseClickHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnNodeMouseClickInternal(e);
			}
		}

		/// 
		/// Called before node checked status is changed.
		/// </summary>
		/// </returns>
		private bool OnBeforeCheck(TreeViewAction enmTreeViewAction)
		{
			TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, blnCancel: false, enmTreeViewAction);
			OnBeforeCheck(e);
			return e.Cancel;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCheck"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
		protected virtual void OnBeforeCheck(TreeViewCancelEventArgs e)
		{
			BeforeCheckHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnBeforeCheckInternal(e);
			}
		}

		/// 
		/// Called after node checked status is changed.
		/// </summary>
		private void OnAfterCheck()
		{
			TreeViewEventArgs e = new TreeViewEventArgs(this);
			OnAfterCheck(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCheck"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
		protected virtual void OnAfterCheck(TreeViewEventArgs e)
		{
			AfterCheckHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnAfterCheckInternal(e);
			}
		}

		/// 
		/// Called before the node is selected.
		/// </summary>
		internal bool OnBeforeSelect(TreeViewAction enmTreeViewAction)
		{
			TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, blnCancel: false, enmTreeViewAction);
			OnBeforeSelect(e);
			return e.Cancel;
		}

		/// 
		/// Raises the <see cref="E:BeforeSelect" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
		protected virtual void OnBeforeSelect(TreeViewCancelEventArgs e)
		{
			BeforeSelectHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnBeforeSelectInternal(e);
			}
		}

		/// 
		/// Called after node is selected.
		/// </summary>
		internal void OnAfterSelect(TreeViewAction enmTreeViewAction)
		{
			TreeViewEventArgs e = new TreeViewEventArgs(this, enmTreeViewAction);
			OnAfterSelect(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterSelect"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
		protected virtual void OnAfterSelect(TreeViewEventArgs e)
		{
			AfterSelectHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnAfterSelectInternal(e);
			}
		}

		/// 
		/// Called after node is expanded.
		/// </summary>
		private void OnAfterExpand()
		{
			TreeViewEventArgs e = new TreeViewEventArgs(this, TreeViewAction.Expand);
			OnAfterExpand(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterExpand"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
		protected virtual void OnAfterExpand(TreeViewEventArgs e)
		{
			AfterExpandHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnAfterExpandInternal(e);
			}
		}

		/// 
		/// Called before node is collapsed.
		/// </summary>
		/// </returns>
		private bool OnBeforeCollapse()
		{
			TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, blnCancel: false, TreeViewAction.Collapse);
			OnBeforeCollapse(e);
			return e.Cancel;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCollapse"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
		protected virtual void OnBeforeCollapse(TreeViewCancelEventArgs e)
		{
			BeforeCollapseHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnBeforeCollapse(e);
			}
		}

		/// 
		/// Called after node is collapsed.
		/// </summary>
		private void OnAfterCollapse()
		{
			TreeViewEventArgs e = new TreeViewEventArgs(this, TreeViewAction.Collapse);
			OnAfterCollapse(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCollapse"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
		protected internal virtual void OnAfterCollapse(TreeViewEventArgs e)
		{
			AfterCollapseHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnAfterCollapseInternal(e);
			}
		}

		/// 
		/// Raises the <see cref="E:AfterLabelEdit" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs" /> instance containing the event data.</param>
		protected internal virtual void OnAfterLabelEdit(NodeLabelEditEventArgs e)
		{
			AfterLabelEditHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnAfterLabelEditInternal(e);
			}
		}

		/// 
		/// Called before node is expanded.
		/// </summary>
		/// </returns>
		private bool OnBeforeExpand()
		{
			TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, blnCancel: false, TreeViewAction.ByMouse);
			OnBeforeExpand(e);
			return e.Cancel;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeExpand"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
		protected virtual void OnBeforeExpand(TreeViewCancelEventArgs e)
		{
			BeforeExpandHandler?.Invoke(this, e);
			if (TreeView != null)
			{
				TreeView.OnBeforeExpandIntenral(e);
			}
		}

		/// 
		/// Disposes the specified component.
		/// </summary>
		/// <param name="blnDisposing"></param>
		protected override void Dispose(bool blnDisposing)
		{
			base.Dispose(blnDisposing);
			if (!blnDisposing)
			{
				return;
			}
			foreach (TreeNode node in Nodes)
			{
				node.Dispose();
			}
		}

		/// 
		/// Renders the node attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected virtual void RenderNodeAttributes(IContext objContext, IResponseWriter objWriter)
		{
		}

		/// 
		/// Renders the node.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">Request ID.</param>
		/// <param name="enmParentCheckBoxVisibility">The enm parent check box visibility.</param>
		internal void RenderNode(IContext objContext, IResponseWriter objWriter, long lngRequestID, CheckBoxVisibility enmParentCheckBoxVisibility)
		{
			if (IsDirty(lngRequestID))
			{
				if (Nodes.Count > 0)
				{
					HasNodes = true;
				}
				if (HasNodes && Nodes.Count == 0)
				{
					Loaded = false;
				}
				objWriter.WriteStartElement("TN");
				RenderNodeAttributes(objContext, objWriter);
				RegisterSelf();
				RenderComponentAttributes(objContext, (IAttributeWriter)objWriter);
				objWriter.WriteAttributeText("TX", Label, (TextFilter)5);
				RenderImages((IAttributeWriter)objWriter);
				RenderSelectOnRightClick((IAttributeWriter)objWriter, blnForceRender: false);
				Font nodeFont = NodeFont;
				if (nodeFont != null)
				{
					objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(nodeFont));
				}
				Color foreColor = ForeColor;
				if (foreColor != Color.Black)
				{
					objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(foreColor));
				}
				Color backColor = BackColor;
				if (backColor != Color.White)
				{
					objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(backColor));
				}
				if (HasRedrawingParent)
				{
					objWriter.WriteAttributeString("HRP", "1");
				}
				if ((!Loaded || (!IsExpanded && HasNodes)) && !TreeView.ForceContentAvailabilityOnClient && !ConfigHelper.ForceContentAvailabilityOnClient)
				{
					objWriter.WriteAttributeString("LO", "0");
				}
				if (!IsExpanded && HasNodes)
				{
					objWriter.WriteAttributeString("EX", "0");
				}
				if (HasNodes)
				{
					objWriter.WriteAttributeString("HN", "1");
				}
				if (Selected)
				{
					objWriter.WriteAttributeString("SE", "1");
				}
				if (CheckBox == CheckBoxVisibility.True || (CheckBox == CheckBoxVisibility.Inherited && enmParentCheckBoxVisibility == CheckBoxVisibility.True))
				{
					objWriter.WriteAttributeString("CB", "1");
				}
				if (Checked)
				{
					objWriter.WriteAttributeString("C", "1");
				}
				string toolTipText = ToolTipText;
				if (toolTipText != string.Empty)
				{
					objWriter.WriteAttributeText("TT", toolTipText);
				}
				if (IsExpanded || TreeView.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
				{
					RenderComponents(objContext, objWriter, 0L, enmParentCheckBoxVisibility);
				}
				RenderComponentClientEvents(objContext, objWriter, lngRequestID);
				objWriter.WriteEndElement();
			}
			else if (IsDirtyAttributes(lngRequestID))
			{
				objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
				RenderComponentUpdateAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);
				RenderUpdateAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);
				RenderComponents(objContext, objWriter, lngRequestID, enmParentCheckBoxVisibility);
				objWriter.WriteEndElement();
			}
			else
			{
				RenderComponents(objContext, objWriter, lngRequestID, enmParentCheckBoxVisibility);
			}
		}

		/// 
		/// Renders the components.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The response writer object.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="enmParentCheckBoxVisibility">The enm parent check box visibility.</param>
		internal void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, CheckBoxVisibility enmParentCheckBoxVisibility)
		{
			foreach (TreeNode node in Nodes)
			{
				if (node.Visible || TreeView.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
				{
					node.RenderNode(objContext, objWriter, lngRequestID, (CheckBox == CheckBoxVisibility.Inherited) ? enmParentCheckBoxVisibility : CheckBox);
				}
			}
		}

		/// 
		/// Renders the images.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		internal void RenderImages(IAttributeWriter objWriter)
		{
			ResourceHandle image = Image;
			if (image != null)
			{
				objWriter.WriteAttributeString("IM", image.ToString());
			}
			ResourceHandle selectedImage = SelectedImage;
			if (selectedImage != null)
			{
				objWriter.WriteAttributeString("SIM", selectedImage.ToString());
			}
			ResourceHandle expandedImage = ExpandedImage;
			if (expandedImage != null)
			{
				objWriter.WriteAttributeString("EIM", expandedImage.ToString());
			}
			if (!TreeView.CheckBoxes)
			{
				ResourceHandle stateImage = StateImage;
				if (stateImage != null)
				{
					objWriter.WriteAttributeString("TIM", stateImage.ToString());
				}
			}
		}

		/// 
		/// Gets the name of the client component.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override string GetClientComponentName()
		{
			return Name;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("AfterLabelEdit"))
			{
				criticalClientEventsData.Set("ALE");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (AfterCollapseHandler != null)
			{
				criticalEventsData.Set("COL");
			}
			if (AfterExpandHandler != null)
			{
				criticalEventsData.Set("EXP");
			}
			if (BeforeCollapseHandler != null)
			{
				criticalEventsData.Set("COL");
			}
			if (BeforeExpandHandler != null)
			{
				criticalEventsData.Set("EXP");
			}
			TreeView treeView = TreeView;
			if (treeView != null)
			{
				if (!treeView.IsCriticalEvent("CC") && (AfterCheckHandler != null || BeforeCheckHandler != null))
				{
					criticalEventsData.Set("CC");
				}
				if (NodeMouseClickHandler != null || treeView.IsCriticalEvent("CL") || treeView.NodeMouseClickHandler != null)
				{
					criticalEventsData.Set("CL");
					if (treeView.RaiseClickOnMouseDown)
					{
						criticalEventsData.Set("RC");
					}
				}
				if (NodeMouseDoubleClickHandler != null || treeView.IsCriticalEvent("DCL") || treeView.NodeMouseDoubleClickHandler != null)
				{
					criticalEventsData.Set("DCL");
				}
				if (AfterSelectHandler != null || BeforeSelectHandler != null || treeView.IsCriticalEvent("SLC"))
				{
					criticalEventsData.Set("SLC");
				}
				if (AfterLabelEditHandler != null || treeView.IsCriticalEvent("ALE"))
				{
					criticalEventsData.Set("ALE");
				}
				if (treeView.ItemDragHandler != null)
				{
					criticalEventsData.Set("SD");
				}
			}
			return criticalEventsData;
		}

		/// 
		/// Shoulds the color of the serialize back.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeBackColor()
		{
			return BackColor != Color.White;
		}

		/// 
		/// Shoulds the color of the serialize fore.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeForeColor()
		{
			return ForeColor != Color.Black;
		}

		/// 
		/// Resets the color of the back.
		/// </summary>
		private void ResetBackColor()
		{
			BackColor = Color.White;
		}

		/// 
		/// Resets the color of the fore.
		/// </summary>
		private void ResetForeColor()
		{
			ForeColor = Color.Black;
		}

		/// 
		/// Sets the selected.
		/// </summary>
		/// <param name="blnSelected">if set to true</c> node is selected.</param>
		/// <param name="blnUpdate">if set to true</c> update.</param>
		internal void SetSelected(bool blnSelected, bool blnUpdate)
		{
			SetState(ComponentState.Selected, blnSelected);
			if (blnUpdate)
			{
				Update();
			}
			if (blnSelected)
			{
				EnsureVisiblePath();
			}
		}

		/// 
		/// Gets the tree nodes from component.
		/// </summary>
		/// <param name="objComponent">The component.</param>
		/// </returns>
		private TreeNodeCollection GetTreeNodesFromComponent(Component objComponent)
		{
			if (objComponent is TreeView { Nodes: var nodes })
			{
				return nodes;
			}
			if (!(objComponent is TreeNode { Nodes: var nodes2 }))
			{
				return null;
			}
			return nodes2;
		}

		/// 
		/// Shoulds the serialize image.
		/// </summary>
		/// </returns>
		protected bool ShouldSerializeImage()
		{
			if (TreeView != null && TreeView.ImageList != null)
			{
				return false;
			}
			return Image != null;
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="objComponent">The component.</param>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			return Nodes;
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			string text = Text;
			return $"TreeNode: {(string.IsNullOrEmpty(text) ? string.Empty : text)}";
		}

		/// Toggles the tree node to either the expanded or collapsed state.</summary>
		public void Toggle()
		{
			if (IsExpanded)
			{
				Collapse();
			}
			else
			{
				Expand();
			}
		}

		/// Removes the current tree node from the tree view control.</summary>
		public void Remove()
		{
			ParentNodes?.Remove(this);
		}

		/// Expands all the child tree nodes.</summary>
		public void ExpandAll()
		{
			Expand();
			foreach (TreeNode node in Nodes)
			{
				node.ExpandAll();
			}
		}

		/// 
		/// Adds a child object.
		/// </summary>
		/// <param name="objValue">The child object to add.</param>
		protected override void AddChild(object objValue)
		{
			if (objValue is TreeNode)
			{
				Nodes.Add((TreeNode)objValue);
			}
			else
			{
				base.AddChild(objValue);
			}
		}

		/// Expands the tree node.</summary>
		public void Expand()
		{
			if (!IsExpanded && !OnBeforeExpand())
			{
				SetValue(IsExpandedProperty, objValue: true);
				Update();
				OnAfterExpand();
			}
		}

		/// Initiates the editing of the tree node label.</summary>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.TreeView.LabelEdit"></see> is set to false. </exception>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void BeginEdit()
		{
			if (TreeView != null && TreeView.LabelEdit)
			{
				TreeView.EditNode = this;
				InvokeMethodWithId("LabelEditor_Show");
			}
		}

		/// Ends the editing of the tree node label.</summary>
		/// <param name="blnCancel">true if the editing of the tree node label text was canceled without being saved; otherwise, false. </param>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void EndEdit(bool blnCancel)
		{
		}

		/// Ensures that the tree node is visible, expanding tree nodes and scrolling the tree view control as necessary.</summary>
		public void EnsureVisible()
		{
			EnsureVisiblePath();
			InvokeMethodWithId("Controls_ScrollIntoView", null, 0);
		}

		/// 
		/// Ensures that the tree path is visible
		/// </summary>
		private void EnsureVisiblePath()
		{
			if (Parent != null)
			{
				if (!Parent.IsExpanded)
				{
					Parent.Expand();
				}
				Parent.EnsureVisiblePath();
			}
		}

		/// Collapses the tree node.</summary>
		public void Collapse()
		{
			Collapse(blnIgnoreChildren: false);
		}

		/// Collapses the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> and optionally collapses its children.</summary>
		/// <param name="blnIgnoreChildren">true to leave the child nodes in their current state; false to collapse the child nodes.</param>
		public void Collapse(bool blnIgnoreChildren)
		{
			if (IsExpanded && !OnBeforeCollapse())
			{
				SetValue(IsExpandedProperty, objValue: false);
				Update();
				OnAfterCollapse();
			}
			if (blnIgnoreChildren)
			{
				return;
			}
			foreach (TreeNode node in Nodes)
			{
				node.Collapse(blnIgnoreChildren: false);
			}
		}

		/// 
		/// Gets the full path.
		/// </summary>
		/// <param name="objPath">Path builder.</param>
		/// <param name="strPathSeparator">Path separator.</param>
		private void GetFullPath(StringBuilder objPath, string strPathSeparator)
		{
			if (Parent != null)
			{
				Parent.GetFullPath(objPath, strPathSeparator);
				objPath.Append(strPathSeparator);
			}
			objPath.Append(Text);
		}

		/// 
		/// Returns the number of child tree nodes.
		/// </summary>
		/// <param name="blnIncludeSubTrees">true if the resulting count includes all tree nodes indirectly rooted at this tree node; otherwise, false . </param>
		/// </returns>
		public int GetNodeCount(bool blnIncludeSubTrees)
		{
			TreeNodeCollection nodes = Nodes;
			int num = nodes.Count;
			if (blnIncludeSubTrees && nodes != null)
			{
				foreach (TreeNode item in nodes)
				{
					num += item.GetNodeCount(blnIncludeSubTrees: true);
				}
			}
			return num;
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			TreeNodeCollection nodes = Nodes;
			if (nodes == null)
			{
				return;
			}
			foreach (IRegisteredComponent item in nodes)
			{
				item.RegisterComponents();
			}
			RegisterBatch(nodes);
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			TreeNodeCollection nodes = Nodes;
			if (nodes == null)
			{
				return;
			}
			foreach (IRegisteredComponent item in nodes)
			{
				item.UnregisterComponents();
			}
			UnRegisterBatch(nodes);
		}

		/// 
		/// Change check state
		/// </summary>
		/// <param name="blnValue">the new check value</param>
		/// <param name="enmTreeViewAction">treeview action</param>
		private void ChangeCheckState(bool blnValue, TreeViewAction enmTreeViewAction)
		{
			if (!OnBeforeCheck(enmTreeViewAction))
			{
				if (enmTreeViewAction == TreeViewAction.ByMouse)
				{
					SetState(ComponentState.Checked, blnValue);
				}
				else if (SetStateWithCheck(ComponentState.Checked, blnValue))
				{
					Update();
				}
				OnAfterCheck();
			}
			else if (enmTreeViewAction == TreeViewAction.ByMouse)
			{
				Update();
			}
		}

		/// Copies the tree node and the entire subtree rooted at this tree node.</summary>
		/// The <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual object Clone()
		{
			Type type = GetType();
			TreeNode treeNode = null;
			if (type == typeof(TreeNode))
			{
				treeNode = new TreeNode(Text, ImageIndex, SelectedImageIndex);
			}
			else
			{
				treeNode = (TreeNode)Activator.CreateInstance(type);
				treeNode.Text = Text;
				treeNode.ImageIndex = ImageIndex;
				treeNode.SelectedImageIndex = SelectedImageIndex;
			}
			treeNode.Name = Name;
			treeNode.StateImageIndex = StateImageIndex;
			treeNode.ToolTipText = ToolTipText;
			treeNode.ContextMenu = ContextMenu;
			treeNode.ContextMenuStrip = ContextMenuStrip;
			treeNode.DragTargets = DragTargets;
			treeNode.AllowDrop = AllowDrop;
			treeNode.Animation = base.Animation;
			string imageKey = ImageKey;
			if (!string.IsNullOrEmpty(imageKey))
			{
				treeNode.ImageKey = imageKey;
			}
			string selectedImageKey = SelectedImageKey;
			if (!string.IsNullOrEmpty(selectedImageKey))
			{
				treeNode.SelectedImageKey = selectedImageKey;
			}
			string stateImageKey = StateImageKey;
			if (!string.IsNullOrEmpty(stateImageKey))
			{
				treeNode.StateImageKey = stateImageKey;
			}
			int nodeCount = GetNodeCount(blnIncludeSubTrees: false);
			if (nodeCount > 0)
			{
				foreach (TreeNode node in Nodes)
				{
					node.ExpandAll();
				}
				for (int i = 0; i < nodeCount; i++)
				{
					treeNode.Nodes.Add((TreeNode)Nodes[i].Clone());
				}
			}
			treeNode.Checked = Checked;
			treeNode.Tag = base.Tag;
			return treeNode;
		}

		/// 
		/// Registers the self node.
		/// </summary>
		internal void RegisterSelfNode()
		{
			RegisterSelf();
		}

		/// 
		/// Uns the register self node.
		/// </summary>
		internal void UnRegisterSelfNode()
		{
			UnRegisterSelf();
		}

		static TreeNode()
		{
			NodeMouseDoubleClickEvent = SerializableEvent.Register("NodeMouseDoubleClick", typeof(TreeNodeMouseClickEventHandler), typeof(TreeNode));
			NodeMouseClickEvent = SerializableEvent.Register("NodeMouseClick", typeof(TreeNodeMouseClickEventHandler), typeof(TreeNode));
			BeforeSelect = SerializableEvent.Register("BeforeSelect", typeof(TreeViewCancelEventHandler), typeof(TreeNode));
			BeforeLabelEdit = SerializableEvent.Register("BeforeLabelEdit", typeof(NodeLabelEditEventHandler), typeof(TreeNode));
			BeforeExpand = SerializableEvent.Register("BeforeExpand", typeof(TreeViewCancelEventHandler), typeof(TreeNode));
			AfterExpand = SerializableEvent.Register("AfterExpand", typeof(TreeViewEventHandler), typeof(TreeNode));
			BeforeCheck = SerializableEvent.Register("BeforeCheck", typeof(TreeViewCancelEventHandler), typeof(TreeNode));
			AfterCheck = SerializableEvent.Register("AfterCheck", typeof(TreeViewEventHandler), typeof(TreeNode));
			AfterCollapse = SerializableEvent.Register("AfterCollapse", typeof(TreeViewEventHandler), typeof(TreeNode));
			BeforeCollapse = SerializableEvent.Register("BeforeCollapse", typeof(TreeViewCancelEventHandler), typeof(TreeNode));
			AfterLabelEdit = SerializableEvent.Register("AfterLabelEdit", typeof(NodeLabelEditEventHandler), typeof(TreeNode));
			AfterSelect = SerializableEvent.Register("AfterSelect", typeof(TreeViewEventHandler), typeof(TreeNode));
		}
	}
}
