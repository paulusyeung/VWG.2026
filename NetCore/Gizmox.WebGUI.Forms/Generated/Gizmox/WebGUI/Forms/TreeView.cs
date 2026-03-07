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
	/// Summary description for TreeView.
	/// </summary>
	[Serializable]
	[DefaultEvent("AfterSelect")]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(TreeView), "TreeView_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("TV")]
	[Skin(typeof(TreeViewSkin))]
	[ProxyComponent(typeof(ProxyTreeView))]
	public class TreeView : Control
	{
		/// 
		/// Provides a property reference to CheckBoxes property.
		/// </summary>
		private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register("CheckBoxes", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to EditNode property.
		/// </summary>
		private static SerializableProperty EditNodeProperty = SerializableProperty.Register("EditNode", typeof(TreeNode), typeof(TreeView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to FullRowSelect property.
		/// Default value determined at the property get/set.
		/// </summary>
		private static SerializableProperty FullRowSelectProperty = SerializableProperty.Register("FullRowSelect", typeof(bool), typeof(TreeView));

		/// 
		/// Provides a property reference to ImageIndex property.
		/// </summary>
		private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(TreeView), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to ImageKey property.
		/// </summary>
		private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(TreeView), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to ImageList property.
		/// </summary>
		private static SerializableProperty ImageListProperty = SerializableProperty.Register("ImageList", typeof(ImageList), typeof(TreeView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to PathSeparator property.
		/// </summary>
		private static SerializableProperty PathSeparatorProperty = SerializableProperty.Register("PathSeparator", typeof(string), typeof(TreeView), new SerializablePropertyMetadata("\\"));

		/// 
		/// Provides a property reference to SelectedImageIndex property.
		/// </summary>
		private static SerializableProperty SelectedImageIndexProperty = SerializableProperty.Register("SelectedImageIndex", typeof(int), typeof(TreeView), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to SelectedImageKey property.
		/// </summary>
		private static SerializableProperty SelectedImageKeyProperty = SerializableProperty.Register("SelectedImageKey", typeof(string), typeof(TreeView), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to SelectedNode property.
		/// </summary>
		private static SerializableProperty SelectedNodeProperty = SerializableProperty.Register("SelectedNode", typeof(TreeNode), typeof(TreeView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ShowLines property.
		/// </summary>
		private static SerializableProperty ShowLinesProperty = SerializableProperty.Register("ShowLines", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to ShowPlusMinus property.
		/// </summary>
		private static SerializableProperty ShowPlusMinusProperty = SerializableProperty.Register("ShowPlusMinus", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to Sorted property.
		/// </summary>
		private static SerializableProperty SortedProperty = SerializableProperty.Register("Sorted", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to StateImageList property.
		/// </summary>
		private static SerializableProperty StateImageListProperty = SerializableProperty.Register("StateImageList", typeof(ImageList), typeof(TreeView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to TreeViewNodeSorter property.
		/// </summary>
		private static SerializableProperty TreeViewNodeSorterProperty = SerializableProperty.Register("TreeViewNodeSorter", typeof(IComparer), typeof(TreeView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ExpandedImageIndex property.
		/// </summary>
		private static SerializableProperty ExpandedImageIndexProperty = SerializableProperty.Register("ExpandedImageIndex", typeof(int), typeof(TreeView), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to ExpandedImageKey property.
		/// </summary>
		private static SerializableProperty ExpandedImageKeyProperty = SerializableProperty.Register("ExpandedImageKey", typeof(string), typeof(TreeView), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to SelectOnRightClick property.
		/// </summary>        
		private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register("SelectOnRightClick", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to Indent property.
		/// </summary>
		private static SerializableProperty IndentProperty = SerializableProperty.Register("Indent", typeof(int), typeof(TreeView));

		/// 
		/// Provides a property reference to HotTracking property.
		/// </summary>
		private static SerializableProperty HotTrackingProperty = SerializableProperty.Register("HotTracking", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to Scrollable property.
		/// </summary>
		private static SerializableProperty ScrollableProperty = SerializableProperty.Register("Scrollable", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to ItemHeight property.
		/// </summary>
		private static SerializableProperty ItemHeightProperty = SerializableProperty.Register("ItemHeight", typeof(int), typeof(TreeView), new SerializablePropertyMetadata(-1));

		/// 
		/// The NodeMouseClick event registration.
		/// </summary>
		internal static readonly SerializableEvent NodeMouseClickEvent = SerializableEvent.Register("NodeMouseClick", typeof(TreeNodeMouseClickEventHandler), typeof(TreeView));

		/// 
		/// The NodeMouseDoubleClick event registration.
		/// </summary>
		internal static readonly SerializableEvent NodeMouseDoubleClickEvent = SerializableEvent.Register("NodeMouseDoubleClick", typeof(TreeNodeMouseClickEventHandler), typeof(TreeView));

		/// 
		/// The BeforeSelect event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeSelectEvent;

		/// 
		/// The AfterSelect event registration.
		/// </summary>
		internal static readonly SerializableEvent AfterSelectEvent;

		/// 
		/// The AfterLabelEdit event registration.
		/// </summary>
		internal static readonly SerializableEvent AfterLabelEditEvent;

		/// 
		/// The BeforeLabelEdit event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeLabelEditEvent;

		/// 
		/// The BeforeExpand event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeExpandEvent;

		/// 
		/// The BeforeCheck event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeCheckEvent;

		/// 
		/// The BeforeCollapse event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeCollapseEvent;

		/// 
		/// The AfterCheck event registration.
		/// </summary>
		private static readonly SerializableEvent AfterCheckEvent;

		/// 
		/// The AfterExpand event registration.
		/// </summary>
		private static readonly SerializableEvent AfterExpandEvent;

		/// 
		/// The AfterCollapse event registration.
		/// </summary>
		private static readonly SerializableEvent AfterCollapseEvent;

		/// 
		/// The tree nodes collection
		/// </summary>
		[NonSerialized]
		private TreeNodeCollection mobjNodes = null;

		/// 
		/// The ItemDrag event registration.
		/// </summary>
		private static readonly SerializableEvent ItemDragEvent;

		/// 
		/// Gets the hanlder for the NodeMouseClick event.
		/// </summary>
		internal TreeNodeMouseClickEventHandler NodeMouseClickHandler => (TreeNodeMouseClickEventHandler)GetHandler(NodeMouseClickEvent);

		/// 
		/// Gets the hanlder for the NodeMouseDoubleClick event.
		/// </summary>
		internal TreeNodeMouseClickEventHandler NodeMouseDoubleClickHandler => (TreeNodeMouseClickEventHandler)GetHandler(NodeMouseDoubleClickEvent);

		/// 
		/// Gets the hanlder for the BeforeSelect event.
		/// </summary>
		private TreeViewCancelEventHandler BeforeSelectHandler => (TreeViewCancelEventHandler)GetHandler(BeforeSelect);

		/// 
		/// Gets the hanlder for the AfterSelect event.
		/// </summary>
		private TreeViewEventHandler AfterSelectHandler => (TreeViewEventHandler)GetHandler(AfterSelectEvent);

		/// 
		/// Gets the hanlder for the AfterLabelEdit event.
		/// </summary>
		private NodeLabelEditEventHandler AfterLabelEditHandler => (NodeLabelEditEventHandler)GetHandler(AfterLabelEditEvent);

		/// 
		/// Gets the hanlder for the BeforeLabelEdit event.
		/// </summary>
		private NodeLabelEditEventHandler BeforeLabelEditHandler => (NodeLabelEditEventHandler)GetHandler(BeforeLabelEdit);

		/// 
		/// Gets the hanlder for the BeforeExpand event.
		/// </summary>
		private TreeViewCancelEventHandler BeforeExpandHandler => (TreeViewCancelEventHandler)GetHandler(BeforeExpand);

		/// 
		/// Gets the hanlder for the BeforeCheck event.
		/// </summary>
		private TreeViewCancelEventHandler BeforeCheckHandler => (TreeViewCancelEventHandler)GetHandler(BeforeCheck);

		/// 
		/// Gets the hanlder for the BeforeCollapse event.
		/// </summary>
		private TreeViewCancelEventHandler BeforeCollapseHandler => (TreeViewCancelEventHandler)GetHandler(BeforeCollapse);

		/// 
		/// Gets the hanlder for the AfterCheck event.
		/// </summary>
		private TreeViewEventHandler AfterCheckHandler => (TreeViewEventHandler)GetHandler(AfterCheck);

		/// 
		/// Gets the hanlder for the AfterExpand event.
		/// </summary>
		private TreeViewEventHandler AfterExpandHandler => (TreeViewEventHandler)GetHandler(AfterExpand);

		/// 
		/// Gets the hanlder for the AfterCollapse event.
		/// </summary>
		private TreeViewEventHandler AfterCollapseHandler => (TreeViewEventHandler)GetHandler(AfterCollapse);

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
		/// Gets the item drag handler.
		/// </summary>
		/// The item drag handler.</value>
		internal ItemDragEventHandler ItemDragHandler => (ItemDragEventHandler)GetHandler(ItemDrag);

		/// 
		/// Gets the default full row select.
		/// </summary>
		private bool DefaultFullRowSelect
		{
			get
			{
				if (!(base.Skin is TreeViewSkin { FullRowSelect: var fullRowSelect }))
				{
					return false;
				}
				return fullRowSelect;
			}
		}

		/// Gets or sets a value indicating whether the selection highlight spans the width of the tree view control.</summary>
		/// true if the selection highlight spans the width of the tree view control; otherwise, false. The default is false.</returns>
		/// Not implemented.</remarks>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewFullRowSelectDescr")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool FullRowSelect
		{
			get
			{
				return GetValue(FullRowSelectProperty, DefaultFullRowSelect);
			}
			set
			{
				if (SetValue(FullRowSelectProperty, value, DefaultFullRowSelect))
				{
					Update();
				}
			}
		}

		/// 
		///
		/// </summary>
		protected override bool IsDelayedDrawing => true;

		/// Gets or sets the implementation of <see cref="T:System.Collections.IComparer"></see> to perform a custom sort of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> nodes.</summary>
		/// The <see cref="T:System.Collections.IComparer"></see> to perform the custom sort.</returns>
		/// 2</filterpriority>
		[Browsable(false)]
		[SRCategory("CatBehavior")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("TreeViewNodeSorterDescr")]
		public IComparer TreeViewNodeSorter
		{
			get
			{
				return GetValue(TreeViewNodeSorterProperty);
			}
			set
			{
				if (SetValue(TreeViewNodeSorterProperty, value) && value != null)
				{
					Sort();
				}
			}
		}

		/// Gets or sets a value indicating whether the tree nodes in the tree view are sorted.</summary>
		/// true if the tree nodes in the tree view are sorted; otherwise, false. The default is false.</returns>
		[SRDescription("TreeViewSortedDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Sorted
		{
			get
			{
				return GetValue(SortedProperty);
			}
			set
			{
				if (SetValue(SortedProperty, value) && value && TreeViewNodeSorter == null && Nodes.Count >= 1)
				{
					RefreshNodes();
				}
			}
		}

		/// Gets or sets a value indicating whether the label text of the tree nodes can be edited.</summary>
		/// true if the label text of the tree nodes can be edited; otherwise, false. The default is false.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewLabelEditDescr")]
		[DefaultValue(false)]
		public bool LabelEdit
		{
			get
			{
				return GetState(ComponentState.ReadOnly);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.ReadOnly, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [edit node].
		/// </summary>
		/// The edit node.</value>
		internal TreeNode EditNode
		{
			get
			{
				return GetValue(EditNodeProperty);
			}
			set
			{
				SetValue(EditNodeProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [hide selection].
		/// </summary>
		/// true</c> if [hide selection]; otherwise, false</c>.</value>
		[DefaultValue(false)]
		public bool HideSelection
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// 
		///
		/// </summary>
		[DefaultValue(null)]
		[SRDescription("TreeViewImageListDescr")]
		[SRCategory("CatBehavior")]
		public ImageList ImageList
		{
			get
			{
				return GetValue(ImageListProperty);
			}
			set
			{
				if (SetValue(ImageListProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the image list used for indicating the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> and its nodes.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> used for indicating the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> and its nodes.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewStateImageListDescr")]
		[DefaultValue(null)]
		public ImageList StateImageList
		{
			get
			{
				return GetValue(StateImageListProperty);
			}
			set
			{
				if (SetValue(StateImageListProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether check boxes are displayed.
		/// </summary>
		/// 
		/// 	true</c> if check boxes are displayed; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool CheckBoxes
		{
			get
			{
				return GetValue(CheckBoxesProperty);
			}
			set
			{
				if (SetValue(CheckBoxesProperty, value))
				{
					Update();
					FireObservableItemPropertyChanged("CheckBoxes");
				}
			}
		}

		/// 
		/// Gets the collection of tree nodes that are assigned to the tree view control.</para>
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[MergableProperty(false)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[SRDescription("TreeViewNodesDescr")]
		[Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public TreeNodeCollection Nodes => mobjNodes;

		/// 
		/// Gets or sets the selected node.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TreeNode SelectedNode
		{
			get
			{
				return GetValue(SelectedNodeProperty);
			}
			set
			{
				SelectNode(value, blnCode: true, TreeViewAction.Unknown);
			}
		}

		/// 
		/// Gets or sets a value indicating whether to show plus minus.
		/// </summary>
		/// 
		/// 	true</c> if [to show plus minus]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool ShowPlusMinus
		{
			get
			{
				return GetValue(ShowPlusMinusProperty);
			}
			set
			{
				if (SetValue(ShowPlusMinusProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether to show lines.
		/// </summary>
		/// 
		/// 	true</c> if to show lines; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool ShowLines
		{
			get
			{
				return GetValue(ShowLinesProperty);
			}
			set
			{
				if (SetValue(ShowLinesProperty, value))
				{
					Update();
					FireObservableItemPropertyChanged("ShowLines");
				}
			}
		}

		/// Gets or sets the index of the image that is displayed for the item.</summary>
		/// The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
		/// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("TreeViewImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[RelatedImageList("ImageList")]
		public int ImageIndex
		{
			get
			{
				if (ImageList == null)
				{
					return -1;
				}
				int value = GetValue(ImageIndexProperty);
				if (value >= ImageList.Images.Count)
				{
					return Math.Max(0, ImageList.Images.Count - 1);
				}
				return value;
			}
			set
			{
				if (value == -1)
				{
					value = 0;
				}
				if (value < 0)
				{
					object[] arrArgs = new object[3]
					{
						"ImageIndex",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ImageIndex", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (SetValue(ImageIndexProperty, value))
				{
					RemoveValue(ImageKeyProperty);
					Update();
				}
			}
		}

		/// Gets or sets the image list index value of the image that is displayed when a tree node is selected.</summary>
		/// A zero-based index value that represents the position of an <see cref="T:System.Drawing.Image"></see> in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
		/// <exception cref="T:System.ArgumentException">The index assigned value is less than zero. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("TreeViewImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[RelatedImageList("ImageList")]
		public int SelectedImageIndex
		{
			get
			{
				if (ImageList == null)
				{
					return -1;
				}
				int value = GetValue(SelectedImageIndexProperty);
				if (ImageList != null && value >= ImageList.Images.Count)
				{
					return Math.Max(0, ImageList.Images.Count - 1);
				}
				return value;
			}
			set
			{
				if (value == -1)
				{
					value = 0;
				}
				if (value < 0)
				{
					object[] arrArgs = new object[3]
					{
						"SelectedImageIndex",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("SelectedImageIndex", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (SetValue(SelectedImageIndexProperty, value))
				{
					RemoveValue(SelectedImageKeyProperty);
					Update();
				}
			}
		}

		/// Gets or sets the key for the image that is displayed for the item.</summary>
		/// The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[DefaultValue("")]
		[RelatedImageList("ImageList")]
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
					Update();
				}
			}
		}

		/// Gets or sets the key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a selected state.</summary>
		/// The key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a selected state.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[DefaultValue("")]
		[SRDescription("TreeViewSelectedImageKeyDescr")]
		[RelatedImageList("ImageList")]
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
					Update();
				}
			}
		}

		/// Gets or sets the key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a Expanded state.</summary>
		/// The key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a Expanded state.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[DefaultValue("")]
		[SRDescription("TreeViewExpandedImageKeyDescr")]
		[RelatedImageList("ImageList")]
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
					Update();
				}
			}
		}

		/// Gets or sets the image list index value of the image that is displayed when a tree node is Expanded.</summary>
		/// A zero-based index value that represents the position of an <see cref="T:System.Drawing.Image"></see> in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
		/// <exception cref="T:System.ArgumentException">The index assigned value is less than zero. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("TreeViewImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[RelatedImageList("ImageList")]
		public int ExpandedImageIndex
		{
			get
			{
				if (ImageList == null)
				{
					return -1;
				}
				int value = GetValue(ExpandedImageIndexProperty);
				if (value >= ImageList.Images.Count)
				{
					return Math.Max(0, ImageList.Images.Count - 1);
				}
				return value;
			}
			set
			{
				if (value == -1)
				{
					value = 0;
				}
				if (value < 0)
				{
					object[] arrArgs = new object[3]
					{
						"ExpandedImageIndex",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ExpandedImageIndex", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (SetValue(ExpandedImageIndexProperty, value))
				{
					RemoveValue(ExpandedImageKeyProperty);
					Update();
				}
			}
		}

		protected override string ClientEventsPropogationTags => "TN";

		/// 
		/// Gets or sets the path separator.
		/// </summary>
		/// The path separator.</value>
		[DefaultValue("\\")]
		public string PathSeparator
		{
			get
			{
				return GetValue(PathSeparatorProperty);
			}
			set
			{
				SetValue(PathSeparatorProperty, value);
			}
		}

		/// 
		/// Gets or sets the select on right click.
		/// </summary>
		/// The select on right click.</value>
		[SRCategory("CatAppearance")]
		[SRDescription("SelectOnRightClickDescr")]
		[DefaultValue(false)]
		public bool SelectOnRightClick
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

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// 
		/// Gets a value indicating whether [raise click on mouse down].
		/// </summary>
		/// 
		/// 	true</c> if [raise click on mouse down]; otherwise, false</c>.
		/// </value>
		internal bool RaiseClickOnMouseDown => base.ShouldRaiseClickOnRightMouseDown;

		/// 
		/// Gets or sets the indent.
		/// </summary>
		/// 
		/// The indent.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Indent
		{
			get
			{
				return GetValue(IndentProperty);
			}
			set
			{
				SetValue(IndentProperty, value);
			}
		}

		/// 
		/// Gets or sets the height of the item.
		/// When none is given, calculates the treenode height by using the font size.
		/// </summary>
		/// 
		/// The height of the item.
		/// </value>
		/// <exception cref="T:System.ArgumentOutOfRangeException">ItemHeight</exception>        
		[SRDescription("TreeViewItemHeightDescr")]
		[SRCategory("CatAppearance")]
		[ProxyBrowsable(true)]
		public int ItemHeight
		{
			get
			{
				int num = InnerItemHeight;
				if (num == -1)
				{
					num = GetPreferdItemHeight();
				}
				return num;
			}
			set
			{
				if (value < 1)
				{
					object[] arrArgs = new object[3]
					{
						"ItemHeight",
						value.ToString(CultureInfo.CurrentCulture),
						1.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ItemHeight", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (value > 32767)
				{
					object[] arrArgs2 = new object[3]
					{
						"ItemHeight",
						value.ToString(CultureInfo.CurrentCulture),
						32767.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ItemHeight", SR.GetString("InvalidHighBoundArgumentEx", arrArgs2));
				}
				InnerItemHeight = value;
			}
		}

		/// 
		/// Gets or sets the height of the inner item.
		/// </summary>
		/// 
		/// The height of the inner item.
		/// </value>
		private int InnerItemHeight
		{
			get
			{
				return GetValue(ItemHeightProperty);
			}
			set
			{
				if (SetValue(ItemHeightProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the height of the inner item.
		/// </summary>
		/// 
		/// The height of the inner item.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool HasItemHeight => ContainsValue(ItemHeightProperty);

		/// Gets the first fully-visible tree node in the tree view control.</summary>
		/// A <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> that represents the first fully-visible tree node in the tree view control.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatAppearance")]
		[SRDescription("TreeViewTopNodeDescr")]
		public TreeNode TopNode
		{
			get
			{
				return GetTopNode();
			}
			set
			{
				value.EnsureVisible();
			}
		}

		/// Gets or sets a value indicating ToolTips are shown when the mouse pointer hovers over a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>.</summary>
		/// true if ToolTips are shown when the mouse pointer hovers over a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>; otherwise, false. The default is false.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewShowShowNodeToolTipsDescr")]
		[DefaultValue(false)]
		public bool ShowNodeToolTips
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> label takes on the appearance of a hyperlink as the mouse pointer passes over it.</summary>
		/// true if a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> label takes on the appearance of a hyperlink as the mouse pointer passes over it; otherwise, false. The default is false.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewHotTrackingDescr")]
		public bool HotTracking
		{
			get
			{
				return GetValue(HotTrackingProperty, objDefault: false);
			}
			set
			{
				SetValue(HotTrackingProperty, value);
			}
		}

		/// Gets or sets a value indicating whether the tree view control displays scroll bars when they are needed.</summary>
		/// true if the tree view control displays scroll bars when they are needed; otherwise, false. The default is true.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("TreeViewScrollableDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public bool Scrollable
		{
			get
			{
				return GetValue(ScrollableProperty, objDefault: true);
			}
			set
			{
				SetValue(ScrollableProperty, value);
			}
		}

		/// Gets or sets a value indicating whether lines are drawn between the tree nodes that are at the root of the tree view.</summary>
		/// true if lines are drawn between the tree nodes that are at the root of the tree view; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("TreeViewShowRootLinesDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public bool ShowRootLines
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// 
		/// The win forms compatibility.
		/// </value>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new TreeViewWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as TreeViewWinFormsCompatibility;

		/// Occurs when the user clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse. </summary>
		/// 1</filterpriority>
		[SRDescription("TreeViewNodeMouseClickDescr")]
		[SRCategory("CatBehavior")]
		public event TreeNodeMouseClickEventHandler NodeMouseClick
		{
			add
			{
				AddCriticalHandler(NodeMouseClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(NodeMouseClickEvent, value);
			}
		}

		/// Occurs when the user double-clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewNodeMouseDoubleClickDescr")]
		public event TreeNodeMouseClickEventHandler NodeMouseDoubleClick
		{
			add
			{
				AddCriticalHandler(NodeMouseDoubleClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(NodeMouseDoubleClickEvent, value);
			}
		}

		/// Occurs before the tree node is selected.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewBeforeSelectDescr")]
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

		/// Occurs after the tree node is selected.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewAfterSelectDescr")]
		public event TreeViewEventHandler AfterSelect
		{
			add
			{
				AddCriticalHandler(AfterSelectEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(AfterSelectEvent, value);
			}
		}

		/// Occurs after the tree node label text is edited.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewAfterEditDescr")]
		public event NodeLabelEditEventHandler AfterLabelEdit
		{
			add
			{
				AddCriticalHandler(AfterLabelEditEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(AfterLabelEditEvent, value);
			}
		}

		/// Occurs before the tree node label text is edited.</summary>
		/// 1</filterpriority>
		[SRDescription("TreeViewBeforeEditDescr")]
		[SRCategory("CatBehavior")]
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
		/// 1</filterpriority>
		[SRDescription("TreeViewBeforeExpandDescr")]
		[SRCategory("CatBehavior")]
		public event TreeViewCancelEventHandler BeforeExpand
		{
			add
			{
				AddCriticalHandler(BeforeExpandEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(BeforeExpandEvent, value);
			}
		}

		/// Occurs before the tree node check box is checked.</summary>
		/// 1</filterpriority>
		[SRDescription("TreeViewBeforeCheckDescr")]
		[SRCategory("CatBehavior")]
		public event TreeViewCancelEventHandler BeforeCheck
		{
			add
			{
				AddCriticalHandler(BeforeCheckEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(BeforeCheckEvent, value);
			}
		}

		/// Occurs before the tree node is collapsed.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewBeforeCollapseDescr")]
		public event TreeViewCancelEventHandler BeforeCollapse
		{
			add
			{
				AddCriticalHandler(BeforeCollapseEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(BeforeCollapseEvent, value);
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
				AddCriticalHandler(AfterCheckEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(AfterCheckEvent, value);
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
				AddCriticalHandler(AfterExpandEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(AfterExpandEvent, value);
			}
		}

		/// Occurs after the tree node is collapsed.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewAfterCollapseDescr")]
		public event TreeViewEventHandler AfterCollapse
		{
			add
			{
				AddCriticalHandler(AfterCollapseEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(AfterCollapseEvent, value);
			}
		}

		/// Occurs when the user begins dragging a node.</summary>
		/// 1</filterpriority>
		[SRCategory("CatAction")]
		[SRDescription("ListViewItemDragDescr")]
		public event ItemDragEventHandler ItemDrag
		{
			add
			{
				AddHandler(ItemDragEvent, value);
			}
			remove
			{
				RemoveHandler(ItemDragEvent, value);
			}
		}

		/// 
		/// Occurs when [client after select].
		/// </summary>
		[SRDescription("Occurs when control selection changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientAfterSelect
		{
			add
			{
				AddClientHandler("Selection", value);
			}
			remove
			{
				RemoveClientHandler("Selection", value);
			}
		}

		/// 
		/// Occurs when [client node mouse click].
		/// </summary>
		[SRDescription("Occurs when control's node clicked in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientNodeMouseClick
		{
			add
			{
				AddClientHandler("Click", value);
			}
			remove
			{
				RemoveClientHandler("Click", value);
			}
		}

		/// 
		/// Occurs when [client node mouse double click].
		/// </summary>
		[SRDescription("Occurs when control's node double-clicked in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientNodeMouseDoubleClick
		{
			add
			{
				AddClientHandler("DoubleClick", value);
			}
			remove
			{
				RemoveClientHandler("DoubleClick", value);
			}
		}

		/// 
		/// Occurs when [client after expand].
		/// </summary>
		[SRDescription("Occurs when control expanded in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientAfterExpand
		{
			add
			{
				AddClientHandler("Expand", value);
			}
			remove
			{
				RemoveClientHandler("Expand", value);
			}
		}

		/// 
		/// Occurs when [client after collapse].
		/// </summary>
		[SRDescription("Occurs when control collapsed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientAfterCollapse
		{
			add
			{
				AddClientHandler("Collapse", value);
			}
			remove
			{
				RemoveClientHandler("Collapse", value);
			}
		}

		/// 
		/// Occurs when [client after checked].
		/// </summary>
		[SRDescription("Occurs when control checked state changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientAfterCheck
		{
			add
			{
				AddClientHandler("CheckedChange", value);
			}
			remove
			{
				RemoveClientHandler("CheckedChange", value);
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.TreeView" /> instance.
		/// </summary>
		public TreeView()
		{
			mobjNodes = CreateNodeCollection();
			SetStyle(ControlStyles.UserPaint, blnValue: false);
			SetStyle(ControlStyles.StandardClick, blnValue: false);
			SetStyle(ControlStyles.UseTextForAccessibility, blnValue: false);
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			object[] arrNodes = objReader.ReadArray();
			mobjNodes = CreateNodeCollection(arrNodes);
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
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (AfterCheckHandler != null || BeforeCheckHandler != null)
			{
				criticalEventsData.Set("CC");
			}
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
			if (AfterLabelEditHandler != null)
			{
				criticalEventsData.Set("ALE");
			}
			if (AfterSelectHandler != null || BeforeSelectHandler != null)
			{
				criticalEventsData.Set("SLC");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("Selection"))
			{
				criticalClientEventsData.Set("SLC");
			}
			if (HasClientHandler("Expand"))
			{
				criticalClientEventsData.Set("EXP");
			}
			if (HasClientHandler("Collapse"))
			{
				criticalClientEventsData.Set("COL");
			}
			if (HasClientHandler("CheckedChange"))
			{
				criticalClientEventsData.Set("CC");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Raises the <see cref="E:AfterCheck" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
		internal void OnAfterCheckInternal(TreeViewEventArgs e)
		{
			OnAfterCheck(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCheck"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
		protected virtual void OnAfterCheck(TreeViewEventArgs e)
		{
			AfterCheckHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:ItemDrag" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ItemDragEventArgs" /> instance containing the event data.</param>
		protected virtual void OnItemDrag(ItemDragEventArgs e)
		{
			ItemDragHandler?.Invoke(this, e);
		}

		/// 
		/// Fires the item drag.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ItemDragEventArgs" /> instance containing the event data.</param>
		internal void FireItemDrag(ItemDragEventArgs e)
		{
			OnItemDrag(e);
		}

		/// 
		/// Raises the <see cref="E:AfterSelect" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
		internal void OnAfterSelectInternal(TreeViewEventArgs e)
		{
			OnAfterSelect(e);
		}

		/// 
		/// Raises the <see cref="E:AfterSelect" /> event.
		/// </summary>
		/// <param name="e">
		/// The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.
		/// </param>
		protected virtual void OnAfterSelect(TreeViewEventArgs e)
		{
			AfterSelectHandler?.Invoke(this, e);
		}

		/// 
		/// Called after node is expanded.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		internal void OnAfterExpandInternal(TreeViewEventArgs e)
		{
			OnAfterExpand(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterExpand"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
		protected virtual void OnAfterExpand(TreeViewEventArgs e)
		{
			AfterExpandHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:AfterCollapse" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
		internal void OnAfterCollapseInternal(TreeViewEventArgs e)
		{
			OnAfterCollapse(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCollapse"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
		protected virtual void OnAfterCollapse(TreeViewEventArgs e)
		{
			AfterCollapseHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:BeforeCheck" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
		internal void OnBeforeCheckInternal(TreeViewCancelEventArgs e)
		{
			OnBeforeCheck(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCheck"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
		protected virtual void OnBeforeCheck(TreeViewCancelEventArgs e)
		{
			BeforeCheckHandler?.Invoke(this, e);
		}

		/// 
		/// Called before collapsing node.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
		internal void OnBeforeCollapseInternal(TreeViewCancelEventArgs e)
		{
			OnBeforeCollapse(e);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCollapse"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data.</param>
		protected internal virtual void OnBeforeCollapse(TreeViewCancelEventArgs e)
		{
			BeforeCollapseHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterLabelEdit"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs"></see> that contains the event data. </param>
		protected virtual void OnAfterLabelEdit(NodeLabelEditEventArgs e)
		{
			AfterLabelEditHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeLabelEdit"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs"></see> that contains the event data. </param>
		protected virtual void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
		{
			BeforeLabelEditHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:AfterLabelEditInternal" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs" /> instance containing the event data.</param>
		internal void OnAfterLabelEditInternal(NodeLabelEditEventArgs e)
		{
			OnAfterLabelEdit(e);
		}

		/// 
		/// Raises the <see cref="E:BeforeSelect" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
		internal void OnBeforeSelectInternal(TreeViewCancelEventArgs e)
		{
			OnBeforeSelect(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeSelect"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
		protected virtual void OnBeforeSelect(TreeViewCancelEventArgs e)
		{
			BeforeSelectHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:NodeMouseClick" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
		internal void OnNodeMouseClickInternal(TreeNodeMouseClickEventArgs e)
		{
			OnNodeMouseClick(e);
			OnClick(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
		protected virtual void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
		{
			NodeMouseClickHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:NodeMouseDoubleClick" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
		internal void OnNodeMouseDoubleClickInternal(TreeNodeMouseClickEventArgs e)
		{
			OnNodeMouseDoubleClick(e);
			OnDoubleClick(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
		protected virtual void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
		{
			NodeMouseDoubleClickHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:BeforeExpand" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
		internal void OnBeforeExpandIntenral(TreeViewCancelEventArgs e)
		{
			OnBeforeExpand(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeExpand"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
		protected virtual void OnBeforeExpand(TreeViewCancelEventArgs e)
		{
			BeforeExpandHandler?.Invoke(this, e);
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderSelectOnRightClick(objWriter, blnForceRender: true);
				objWriter.WriteAttributeString("TNCEOT", WinFormsCompatibility.IsTreeNodeClickEventsOnToggle ? "1" : "0");
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderItemHeight(objWriter);
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
			RenderItemHeight(objWriter);
			RenderEditingInformation(objContext, objWriter);
			RenderSelectOnRightClick(objWriter, blnForceRender: false);
			objWriter.WriteAttributeString("TNCEOT", WinFormsCompatibility.IsTreeNodeClickEventsOnToggle ? "1" : "0");
		}

		/// 
		/// Renders the height of the item.
		/// </summary>
		/// <param name="objWriter">The object writer.</param>
		private void RenderItemHeight(IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("IMH", GetPreferdItemHeight().ToString());
		}

		/// 
		/// Gets the height of the preferd item font.
		/// </summary>
		/// </returns>
		internal int GetPreferdItemHeight()
		{
			if (HasItemHeight || HasProxyPropertyValue("ItemHeight"))
			{
				return GetProxyPropertyValue("ItemHeight", InnerItemHeight);
			}
			int num = 4;
			return CommonUtils.GetFontHeight(GetProxyPropertyValue("Font", Font)) + num;
		}

		/// 
		/// Renders the select on right click.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (SelectOnRightClick)
			{
				objWriter.WriteAttributeString("SOR", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SOR", "0");
			}
		}

		/// 
		/// Renders the editing information.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected void RenderEditingInformation(IContext objContext, IAttributeWriter objWriter)
		{
			if (LabelEdit)
			{
				objWriter.WriteAttributeString("LE", "1");
			}
		}

		/// 
		/// Renderes the tree view control
		/// </summary>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
			if (CheckBoxes)
			{
				objWriter.WriteAttributeString("CB", "1");
			}
			if (!ShowPlusMinus)
			{
				objWriter.WriteAttributeString("HP", "1");
			}
			if (ShowLines)
			{
				objWriter.WriteAttributeString("SL", "1");
			}
			if (CheckBoxes && StateImageList != null && StateImageList.Images.Count > 1)
			{
				objWriter.WriteAttributeString("TIMU", StateImageList.Images[0].ToString());
				objWriter.WriteAttributeString("TIMC", StateImageList.Images[1].ToString());
			}
			RenderControls(objContext, objWriter, 0L);
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			foreach (TreeNode node in Nodes)
			{
				if (node.Visible)
				{
					node.RenderNode(objContext, objWriter, lngRequestID, CheckBoxes ? CheckBoxVisibility.True : CheckBoxVisibility.False);
				}
			}
		}

		/// 
		/// Adds a critical event delegate to the list.
		/// </summary>
		/// <param name="objSerializableEvent">The serializable event.</param>
		/// <param name="objValue">The delegate to add to the list.</param>
		/// </returns>
		protected override void AddCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
		{
			if (AddHandler(objSerializableEvent, objValue))
			{
				Update();
			}
		}

		/// 
		/// Removes a critical event delegate from the list.
		/// </summary>
		/// <param name="objSerializableEvent">The serializable event.</param>
		/// <param name="objValue">The delegate to remove from the list.</param>
		/// </returns>
		protected override void RemoveCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
		{
			if (RemoveHandler(objSerializableEvent, objValue))
			{
				Update();
			}
		}

		/// 
		/// Selects the node.
		/// </summary>
		/// <param name="objTreeNode">The obj tree node.</param>
		/// <param name="blnCode">if set to true</c> [BLN code].</param>
		/// <param name="enmAction">The action.</param>
		internal void SelectNode(TreeNode objTreeNode, bool blnCode, TreeViewAction enmAction)
		{
			TreeNode selectedNode = SelectedNode;
			if (objTreeNode != null)
			{
				if (objTreeNode.TreeView != this || objTreeNode == selectedNode)
				{
					return;
				}
				if (!objTreeNode.OnBeforeSelect(enmAction))
				{
					selectedNode?.SetSelected(blnSelected: false, blnCode);
					SetValue(SelectedNodeProperty, objTreeNode);
					objTreeNode.SetSelected(blnSelected: true, blnCode);
					objTreeNode.OnAfterSelect(enmAction);
				}
				else
				{
					objTreeNode.SetSelected(blnSelected: false, !blnCode);
					if (!blnCode)
					{
						selectedNode?.Update();
					}
				}
			}
			else if (selectedNode != null)
			{
				selectedNode.SetSelected(blnSelected: false, blnCode);
				SetValue(SelectedNodeProperty, null);
			}
		}

		/// Sorts the items if the value of the <see cref="P:Gizmox.WebGUI.Forms.TreeView.TreeViewNodeSorter"></see> property is not null.</summary>
		public void Sort()
		{
			Sorted = true;
			RefreshNodes();
		}

		/// 
		/// Refresh current nodes
		/// </summary>
		private void RefreshNodes()
		{
			TreeNode[] array = new TreeNode[Nodes.Count];
			Nodes.CopyTo(array, 0);
			Nodes.Clear();
			Nodes.AddRange(array);
		}

		/// 
		/// Shoulds the height of the serialize item.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeItemHeight()
		{
			return HasItemHeight;
		}

		/// 
		/// Resets the height of the item.
		/// </summary>
		private void ResetItemHeight()
		{
			RemoveValue(ItemHeightProperty);
			UpdateParams(AttributeType.Visual);
		}

		/// 
		/// Gets the top node in the tree view visible area.
		/// </summary>
		/// </returns>
		private TreeNode GetTopNode()
		{
			if (Nodes.Count == 0)
			{
				return null;
			}
			return GetNodeFromOriginPointAndDistance(Nodes[0], base.ScrollTop);
		}

		/// 
		/// Gets the node from origin point and distance.
		/// </summary>
		/// <param name="objNode">The origin node.</param>
		/// <param name="intDistance">The distance from the node (downwards).</param>
		/// </returns>
		private TreeNode GetNodeFromOriginPointAndDistance(TreeNode objNode, int intDistance)
		{
			if (intDistance < ItemHeight / 2)
			{
				return objNode;
			}
			return GetNodeFromOriginPointAndDistance(objNode.NextVisibleNode, intDistance - ItemHeight);
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			return Nodes;
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
		/// Creates the node collection.
		/// </summary>
		/// <param name="treeView">The tree view.</param>
		/// <param name="arrNodes">The arr nodes.</param>
		/// </returns>
		protected virtual TreeNodeCollection CreateNodeCollection(object[] arrNodes)
		{
			return new TreeNodeCollection(this, arrNodes);
		}

		/// Expands all the tree nodes.</summary>
		public void ExpandAll()
		{
			foreach (TreeNode node in Nodes)
			{
				node.ExpandAll();
			}
		}

		/// Collapses all the tree nodes.</summary>
		public void CollapseAll()
		{
			foreach (TreeNode node in Nodes)
			{
				node.Collapse();
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

		/// Retrieves the number of tree nodes, optionally including those in all subtrees, assigned to the tree view control.</summary>
		/// The number of tree nodes, optionally including those in all subtrees, assigned to the tree view control.</returns>
		public int GetNodeCount(bool blnIncludeSubTrees)
		{
			int num = Nodes.Count;
			if (blnIncludeSubTrees)
			{
				foreach (TreeNode node in Nodes)
				{
					num += node.GetNodeCount(blnIncludeSubTrees: true);
				}
			}
			return num;
		}

		/// 
		/// Disables any redrawing of the tree view.
		/// </summary>
		public void BeginUpdate()
		{
		}

		/// 
		/// Enables the redrawing of the tree view.
		/// </summary>
		public void EndUpdate()
		{
		}

		/// 
		///             Retrieves the tree node that is at the specified point.
		/// Not implemented
		/// </summary>
		/// <param name="intX"></param>
		/// <param name="intY"></param>
		[Obsolete("Not implemented")]
		public TreeNode GetNodeAt(int intX, int intY)
		{
			return null;
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			TreeNodeCollection nodes = Nodes;
			if (nodes != null)
			{
				RegisterBatch(nodes);
			}
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			TreeNodeCollection nodes = Nodes;
			if (nodes != null)
			{
				UnRegisterBatch(nodes);
			}
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new TreeViewRenderer(this);
		}

		/// 
		/// Determines whether [is critical event] [the specified enm event type].
		/// </summary>
		/// <param name="enmEventType">Type of the enm event.</param>
		/// 
		/// 	true</c> if [is critical event] [the specified enm event type]; otherwise, false</c>.
		/// </returns>
		internal bool IsCriticalEvent(string strEventName)
		{
			CriticalEventsData criticalEventsData = GetCriticalEventsData();
			return criticalEventsData.HasEvent(strEventName);
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// </returns>
		protected override WinFormsCompatibility GetWinFormsCompatibility()
		{
			return new TreeViewWinFormsCompatibility();
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
		{
			if (strChangedOptionName == "TreeNodeClickEventsOnToggle")
			{
				UpdateParams(AttributeType.Control);
			}
			base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
		}

		static TreeView()
		{
			BeforeSelect = SerializableEvent.Register("BeforeSelect", typeof(TreeViewCancelEventHandler), typeof(TreeView));
			AfterSelectEvent = SerializableEvent.Register("AfterSelect", typeof(TreeViewEventHandler), typeof(TreeView));
			AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof(NodeLabelEditEventHandler), typeof(TreeView));
			BeforeLabelEdit = SerializableEvent.Register("BeforeLabelEdit", typeof(NodeLabelEditEventHandler), typeof(TreeView));
			BeforeExpand = SerializableEvent.Register("BeforeExpand", typeof(TreeViewCancelEventHandler), typeof(TreeView));
			BeforeCheck = SerializableEvent.Register("BeforeCheck", typeof(TreeViewCancelEventHandler), typeof(TreeView));
			BeforeCollapse = SerializableEvent.Register("BeforeCollapse", typeof(TreeViewCancelEventHandler), typeof(TreeView));
			AfterCheck = SerializableEvent.Register("AfterCheck", typeof(TreeViewEventHandler), typeof(TreeView));
			AfterExpand = SerializableEvent.Register("AfterExpand", typeof(TreeViewEventHandler), typeof(TreeView));
			AfterCollapse = SerializableEvent.Register("AfterCollapse", typeof(TreeViewEventHandler), typeof(TreeView));
			ItemDrag = SerializableEvent.Register("ItemDrag", typeof(ItemDragEventHandler), typeof(TreeView));
		}
	}
}
