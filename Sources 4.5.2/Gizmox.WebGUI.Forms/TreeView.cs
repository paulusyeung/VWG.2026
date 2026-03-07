#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Globalization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Serialization;
using System.Drawing.Design;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Configuration;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region TreeView Class

    /// <summary>
    /// Summary description for TreeView.
    /// </summary>
    [System.ComponentModel.DefaultEvent("AfterSelect")]
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(TreeView), "TreeView_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(TreeView), "TreeView.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#endif
    [ToolboxItemCategory("Common Controls")]
    [Serializable()]
    [MetadataTag(WGTags.TreeView)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.TreeViewSkin))]
    [ProxyComponent(typeof(ProxyTreeView))]
    public class TreeView : Control
    {
        #region Fields

        /// <summary>
        /// Provides a property reference to CheckBoxes property.
        /// </summary>
        private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register("CheckBoxes", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to EditNode property.
        /// </summary>
        private static SerializableProperty EditNodeProperty = SerializableProperty.Register("EditNode", typeof(TreeNode), typeof(TreeView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to FullRowSelect property.
        /// Default value determined at the property get/set.
        /// </summary>
        private static SerializableProperty FullRowSelectProperty = SerializableProperty.Register("FullRowSelect", typeof(bool), typeof(TreeView));

        /// <summary>
        /// Provides a property reference to ImageIndex property.
        /// </summary>
        private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(TreeView), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to ImageKey property.
        /// </summary>
        private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(TreeView), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to ImageList property.
        /// </summary>
        private static SerializableProperty ImageListProperty = SerializableProperty.Register("ImageList", typeof(ImageList), typeof(TreeView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to PathSeparator property.
        /// </summary>
        private static SerializableProperty PathSeparatorProperty = SerializableProperty.Register("PathSeparator", typeof(string), typeof(TreeView), new SerializablePropertyMetadata(@"\"));

        /// <summary>
        /// Provides a property reference to SelectedImageIndex property.
        /// </summary>
        private static SerializableProperty SelectedImageIndexProperty = SerializableProperty.Register("SelectedImageIndex", typeof(int), typeof(TreeView), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to SelectedImageKey property.
        /// </summary>
        private static SerializableProperty SelectedImageKeyProperty = SerializableProperty.Register("SelectedImageKey", typeof(string), typeof(TreeView), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to SelectedNode property.
        /// </summary>
        private static SerializableProperty SelectedNodeProperty = SerializableProperty.Register("SelectedNode", typeof(TreeNode), typeof(TreeView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ShowLines property.
        /// </summary>
        private static SerializableProperty ShowLinesProperty = SerializableProperty.Register("ShowLines", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to ShowPlusMinus property.
        /// </summary>
        private static SerializableProperty ShowPlusMinusProperty = SerializableProperty.Register("ShowPlusMinus", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to Sorted property.
        /// </summary>
        private static SerializableProperty SortedProperty = SerializableProperty.Register("Sorted", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to StateImageList property.
        /// </summary>
        private static SerializableProperty StateImageListProperty = SerializableProperty.Register("StateImageList", typeof(ImageList), typeof(TreeView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to TreeViewNodeSorter property.
        /// </summary>
        private static SerializableProperty TreeViewNodeSorterProperty = SerializableProperty.Register("TreeViewNodeSorter", typeof(IComparer), typeof(TreeView), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ExpandedImageIndex property.
        /// </summary>
        private static SerializableProperty ExpandedImageIndexProperty = SerializableProperty.Register("ExpandedImageIndex", typeof(int), typeof(TreeView), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to ExpandedImageKey property.
        /// </summary>
        private static SerializableProperty ExpandedImageKeyProperty = SerializableProperty.Register("ExpandedImageKey", typeof(string), typeof(TreeView), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to SelectOnRightClick property.
        /// </summary>        
        private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register("SelectOnRightClick", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to Indent property.
        /// </summary>
        private static SerializableProperty IndentProperty = SerializableProperty.Register("Indent", typeof(int), typeof(TreeView));

        /// <summary>
        /// Provides a property reference to HotTracking property.
        /// </summary>
        private static SerializableProperty HotTrackingProperty = SerializableProperty.Register("HotTracking", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to Scrollable property.
        /// </summary>
        private static SerializableProperty ScrollableProperty = SerializableProperty.Register("Scrollable", typeof(bool), typeof(TreeView), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to ItemHeight property.
        /// </summary>
        private static SerializableProperty ItemHeightProperty = SerializableProperty.Register("ItemHeight", typeof(int), typeof(TreeView), new SerializablePropertyMetadata(-1));

        #endregion Fields

        #region Class Members

        /// <summary>Occurs when the user clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse. </summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("TreeViewNodeMouseClickDescr"), SRCategory("CatBehavior")]
        public event TreeNodeMouseClickEventHandler NodeMouseClick
        {
            add
            {
                this.AddCriticalHandler(TreeView.NodeMouseClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.NodeMouseClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the NodeMouseClick event.
        /// </summary>
        internal TreeNodeMouseClickEventHandler NodeMouseClickHandler
        {
            get
            {
                return (TreeNodeMouseClickEventHandler)this.GetHandler(TreeView.NodeMouseClickEvent);
            }
        }

        /// <summary>
        /// The NodeMouseClick event registration.
        /// </summary>
        internal static readonly SerializableEvent NodeMouseClickEvent = SerializableEvent.Register("NodeMouseClick", typeof(TreeNodeMouseClickEventHandler), typeof(TreeView));

        /// <summary>Occurs when the user double-clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewNodeMouseDoubleClickDescr")]
        public event TreeNodeMouseClickEventHandler NodeMouseDoubleClick
        {
            add
            {
                this.AddCriticalHandler(TreeView.NodeMouseDoubleClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.NodeMouseDoubleClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the NodeMouseDoubleClick event.
        /// </summary>
        internal TreeNodeMouseClickEventHandler NodeMouseDoubleClickHandler
        {
            get
            {
                return (TreeNodeMouseClickEventHandler)this.GetHandler(TreeView.NodeMouseDoubleClickEvent);
            }
        }

        /// <summary>
        /// The NodeMouseDoubleClick event registration.
        /// </summary>
        internal static readonly SerializableEvent NodeMouseDoubleClickEvent = SerializableEvent.Register("NodeMouseDoubleClick", typeof(TreeNodeMouseClickEventHandler), typeof(TreeView));

        /// <summary>Occurs before the tree node is selected.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewBeforeSelectDescr")]
        public event TreeViewCancelEventHandler BeforeSelect
        {
            add
            {
                this.AddHandler(TreeView.BeforeSelectEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeView.BeforeSelectEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeSelect event.
        /// </summary>
        private TreeViewCancelEventHandler BeforeSelectHandler
        {
            get
            {
                return (TreeViewCancelEventHandler)this.GetHandler(TreeView.BeforeSelectEvent);
            }
        }

        /// <summary>
        /// The BeforeSelect event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeSelectEvent = SerializableEvent.Register("BeforeSelect", typeof(TreeViewCancelEventHandler), typeof(TreeView));

        /// <summary>Occurs after the tree node is selected.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewAfterSelectDescr")]
        public event TreeViewEventHandler AfterSelect
        {
            add
            {
                this.AddCriticalHandler(TreeView.AfterSelectEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.AfterSelectEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterSelect event.
        /// </summary>
        private TreeViewEventHandler AfterSelectHandler
        {
            get
            {
                return (TreeViewEventHandler)this.GetHandler(TreeView.AfterSelectEvent);
            }
        }

        /// <summary>
        /// The AfterSelect event registration.
        /// </summary>
        internal static readonly SerializableEvent AfterSelectEvent = SerializableEvent.Register("AfterSelect", typeof(TreeViewEventHandler), typeof(TreeView));

        /// <summary>Occurs after the tree node label text is edited.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewAfterEditDescr")]
        public event NodeLabelEditEventHandler AfterLabelEdit
        {
            add
            {
                this.AddCriticalHandler(TreeView.AfterLabelEditEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.AfterLabelEditEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterLabelEdit event.
        /// </summary>
        private NodeLabelEditEventHandler AfterLabelEditHandler
        {
            get
            {
                return (NodeLabelEditEventHandler)this.GetHandler(TreeView.AfterLabelEditEvent);
            }
        }

        /// <summary>
        /// The AfterLabelEdit event registration.
        /// </summary>
        internal static readonly SerializableEvent AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof(NodeLabelEditEventHandler), typeof(TreeView));

        /// <summary>Occurs before the tree node label text is edited.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("TreeViewBeforeEditDescr"), SRCategory("CatBehavior")]
        public event NodeLabelEditEventHandler BeforeLabelEdit
        {
            add
            {
                this.AddHandler(TreeView.BeforeLabelEditEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeView.BeforeLabelEditEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeLabelEdit event.
        /// </summary>
        private NodeLabelEditEventHandler BeforeLabelEditHandler
        {
            get
            {
                return (NodeLabelEditEventHandler)this.GetHandler(TreeView.BeforeLabelEditEvent);
            }
        }

        /// <summary>
        /// The BeforeLabelEdit event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeLabelEditEvent = SerializableEvent.Register("BeforeLabelEdit", typeof(NodeLabelEditEventHandler), typeof(TreeView));

        /// <summary>Occurs before the tree node is expanded.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("TreeViewBeforeExpandDescr"), SRCategory("CatBehavior")]
        public event TreeViewCancelEventHandler BeforeExpand
        {
            add
            {
                this.AddCriticalHandler(TreeView.BeforeExpandEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.BeforeExpandEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeExpand event.
        /// </summary>
        private TreeViewCancelEventHandler BeforeExpandHandler
        {
            get
            {
                return (TreeViewCancelEventHandler)this.GetHandler(TreeView.BeforeExpandEvent);
            }
        }

        /// <summary>
        /// The BeforeExpand event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeExpandEvent = SerializableEvent.Register("BeforeExpand", typeof(TreeViewCancelEventHandler), typeof(TreeView));

        /// <summary>Occurs before the tree node check box is checked.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("TreeViewBeforeCheckDescr"), SRCategory("CatBehavior")]
        public event TreeViewCancelEventHandler BeforeCheck
        {
            add
            {
                this.AddCriticalHandler(TreeView.BeforeCheckEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.BeforeCheckEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeCheck event.
        /// </summary>
        private TreeViewCancelEventHandler BeforeCheckHandler
        {
            get
            {
                return (TreeViewCancelEventHandler)this.GetHandler(TreeView.BeforeCheckEvent);
            }
        }

        /// <summary>
        /// The BeforeCheck event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeCheckEvent = SerializableEvent.Register("BeforeCheck", typeof(TreeViewCancelEventHandler), typeof(TreeView));

        /// <summary>Occurs before the tree node is collapsed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewBeforeCollapseDescr")]
        public event TreeViewCancelEventHandler BeforeCollapse
        {
            add
            {
                this.AddCriticalHandler(TreeView.BeforeCollapseEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.BeforeCollapseEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeCollapse event.
        /// </summary>
        private TreeViewCancelEventHandler BeforeCollapseHandler
        {
            get
            {
                return (TreeViewCancelEventHandler)this.GetHandler(TreeView.BeforeCollapseEvent);
            }
        }

        /// <summary>
        /// The BeforeCollapse event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeCollapseEvent = SerializableEvent.Register("BeforeCollapse", typeof(TreeViewCancelEventHandler), typeof(TreeView));

        /// <summary>Occurs after the tree node check box is checked.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("TreeViewAfterCheckDescr"), SRCategory("CatBehavior")]
        public event TreeViewEventHandler AfterCheck
        {
            add
            {
                this.AddCriticalHandler(TreeView.AfterCheckEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.AfterCheckEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterCheck event.
        /// </summary>
        private TreeViewEventHandler AfterCheckHandler
        {
            get
            {
                return (TreeViewEventHandler)this.GetHandler(TreeView.AfterCheckEvent);
            }
        }

        /// <summary>
        /// The AfterCheck event registration.
        /// </summary>
        private static readonly SerializableEvent AfterCheckEvent = SerializableEvent.Register("AfterCheck", typeof(TreeViewEventHandler), typeof(TreeView));

        /// <summary>Occurs after the tree node is expanded.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewAfterExpandDescr")]
        public event TreeViewEventHandler AfterExpand
        {
            add
            {
                this.AddCriticalHandler(TreeView.AfterExpandEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.AfterExpandEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterExpand event.
        /// </summary>
        private TreeViewEventHandler AfterExpandHandler
        {
            get
            {
                return (TreeViewEventHandler)this.GetHandler(TreeView.AfterExpandEvent);
            }
        }

        /// <summary>
        /// The AfterExpand event registration.
        /// </summary>
        private static readonly SerializableEvent AfterExpandEvent = SerializableEvent.Register("AfterExpand", typeof(TreeViewEventHandler), typeof(TreeView));

        /// <summary>Occurs after the tree node is collapsed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewAfterCollapseDescr")]
        public event TreeViewEventHandler AfterCollapse
        {
            add
            {
                this.AddCriticalHandler(TreeView.AfterCollapseEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TreeView.AfterCollapseEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterCollapse event.
        /// </summary>
        private TreeViewEventHandler AfterCollapseHandler
        {
            get
            {
                return (TreeViewEventHandler)this.GetHandler(TreeView.AfterCollapseEvent);
            }
        }

        /// <summary>
        /// The AfterCollapse event registration.
        /// </summary>
        private static readonly SerializableEvent AfterCollapseEvent = SerializableEvent.Register("AfterCollapse", typeof(TreeViewEventHandler), typeof(TreeView));

        /// <summary>
        /// The tree nodes collection
        /// </summary>
        [NonSerialized()]
        private TreeNodeCollection mobjNodes = null;

        #endregion Class Members

        #region C'Tor

        /// <summary>
        /// Creates a new <see cref="TreeView"/> instance.
        /// </summary>
        public TreeView()
        {
            // create a tree node collection
            mobjNodes = CreateNodeCollection();

            base.SetStyle(ControlStyles.UserPaint, false);
            base.SetStyle(ControlStyles.StandardClick, false);
            base.SetStyle(ControlStyles.UseTextForAccessibility, false);
        }

        #endregion C'Tor

        #region Serialization Methods

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                int intSerializableDataInitialSize = base.SerializableDataInitialSize;

                // Add the nodes required capacity
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjNodes);

                return intSerializableDataInitialSize;
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Read the nodes array
            object[] arrNodes = objReader.ReadArray();

            // Initialize the nodes collection 
            mobjNodes = CreateNodeCollection(arrNodes);

        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write the nodes array
            objWriter.WriteArray(mobjNodes);
        }

        #endregion

        #region Events

        /// <summary>Occurs when the user begins dragging a node.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAction"), SRDescription("ListViewItemDragDescr")]
        public event ItemDragEventHandler ItemDrag
        {
            add
            {
                this.AddHandler(TreeView.ItemDragEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeView.ItemDragEvent, value);
            }
        }

        /// <summary>
        /// Gets the item drag handler.
        /// </summary>
        /// <value>The item drag handler.</value>
        internal ItemDragEventHandler ItemDragHandler
        {
            get
            {
                return (ItemDragEventHandler)this.GetHandler(TreeView.ItemDragEvent);
            }
        }

        /// <summary>
        /// The ItemDrag event registration.
        /// </summary>
        private static readonly SerializableEvent ItemDragEvent = SerializableEvent.Register("ItemDrag", typeof(ItemDragEventHandler), typeof(TreeView));

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();
            if (AfterCheckHandler != null || BeforeCheckHandler != null) objEvents.Set(WGEvents.CheckedChange);
            if (AfterCollapseHandler != null) objEvents.Set(WGEvents.Collapse);
            if (AfterExpandHandler != null) objEvents.Set(WGEvents.Expand);
            if (BeforeCollapseHandler != null) objEvents.Set(WGEvents.Collapse);
            if (BeforeExpandHandler != null) objEvents.Set(WGEvents.Expand);
            if (AfterLabelEditHandler != null) objEvents.Set(WGEvents.AfterLabelEdit);
            if (this.AfterSelectHandler != null || this.BeforeSelectHandler != null) objEvents.Set(WGEvents.SelectionChange);

            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.HasClientHandler("Selection"))
            {
                objEvents.Set(WGEvents.SelectionChange);
            }

            if (this.HasClientHandler("Expand"))
            {
                objEvents.Set(WGEvents.Expand);
            }

            if (this.HasClientHandler("Collapse"))
            {
                objEvents.Set(WGEvents.Collapse);
            }

            if (this.HasClientHandler("CheckedChange"))
            {
                objEvents.Set(WGEvents.CheckedChange);
            }
            return objEvents;
        }

        /// <summary>
        /// Occurs when [client after select].
        /// </summary>
        [SRDescription("Occurs when control selection changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientAfterSelect
        {
            add
            {
                this.AddClientHandler("Selection", value);
            }
            remove
            {
                this.RemoveClientHandler("Selection", value);
            }
        }

        /// <summary>
        /// Occurs when [client node mouse click].
        /// </summary>
        [SRDescription("Occurs when control's node clicked in client mode."), Category("Client")]
        public event ClientEventHandler ClientNodeMouseClick
        {
            add
            {
                this.AddClientHandler("Click", value);
            }
            remove
            {
                this.RemoveClientHandler("Click", value);
            }
        }

        /// <summary>
        /// Occurs when [client node mouse double click].
        /// </summary>
        [SRDescription("Occurs when control's node double-clicked in client mode."), Category("Client")]
        public event ClientEventHandler ClientNodeMouseDoubleClick
        {
            add
            {
                this.AddClientHandler("DoubleClick", value);
            }
            remove
            {
                this.RemoveClientHandler("DoubleClick", value);
            }
        }


        /// <summary>
        /// Occurs when [client after expand].
        /// </summary>
        [SRDescription("Occurs when control expanded in client mode."), Category("Client")]
        public event ClientEventHandler ClientAfterExpand
        {
            add
            {
                this.AddClientHandler("Expand", value);
            }
            remove
            {
                this.RemoveClientHandler("Expand", value);
            }
        }

        /// <summary>
        /// Occurs when [client after collapse].
        /// </summary>
        [SRDescription("Occurs when control collapsed in client mode."), Category("Client")]
        public event ClientEventHandler ClientAfterCollapse
        {
            add
            {
                this.AddClientHandler("Collapse", value);
            }
            remove
            {
                this.RemoveClientHandler("Collapse", value);
            }
        }

        /// <summary>
        /// Occurs when [client after checked].
        /// </summary>
        [SRDescription("Occurs when control checked state changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientAfterCheck
        {
            add
            {
                this.AddClientHandler("CheckedChange", value);
            }
            remove
            {
                this.RemoveClientHandler("CheckedChange", value);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:AfterCheck"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        internal void OnAfterCheckInternal(TreeViewEventArgs e)
        {
            OnAfterCheck(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCheck"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
        protected virtual void OnAfterCheck(TreeViewEventArgs e)
        {
            // Raise event if needed
            TreeViewEventHandler objEventHandler = this.AfterCheckHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ItemDrag"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ItemDragEventArgs"/> instance containing the event data.</param>
        protected virtual void OnItemDrag(ItemDragEventArgs e)
        {
            // Raise event if needed
            ItemDragEventHandler objEventHandler = this.ItemDragHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Fires the item drag.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ItemDragEventArgs"/> instance containing the event data.</param>
        internal void FireItemDrag(ItemDragEventArgs e)
        {
            OnItemDrag(e);
        }

        /// <summary>
        /// Raises the <see cref="E:AfterSelect"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        internal void OnAfterSelectInternal(TreeViewEventArgs e)
        {
            OnAfterSelect(e);
        }

        /// <summary>
        /// Raises the <see cref="E:AfterSelect"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="Gizmox.WebGUI.Forms.TreeViewEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnAfterSelect(TreeViewEventArgs e)
        {
            // Raise event if needed
            TreeViewEventHandler objEventHandler = this.AfterSelectHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Called after node is expanded.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        internal void OnAfterExpandInternal(TreeViewEventArgs e)
        {
            OnAfterExpand(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterExpand"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
        protected virtual void OnAfterExpand(TreeViewEventArgs e)
        {
            // Raise event if needed
            TreeViewEventHandler objEventHandler = this.AfterExpandHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:AfterCollapse"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        internal void OnAfterCollapseInternal(TreeViewEventArgs e)
        {
            OnAfterCollapse(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCollapse"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
        protected virtual void OnAfterCollapse(TreeViewEventArgs e)
        {
            // Raise event if needed
            TreeViewEventHandler objEventHandler = this.AfterCollapseHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:BeforeCheck"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"/> instance containing the event data.</param>
        internal void OnBeforeCheckInternal(TreeViewCancelEventArgs e)
        {
            OnBeforeCheck(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCheck"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
        protected virtual void OnBeforeCheck(TreeViewCancelEventArgs e)
        {
            // Raise event if needed
            TreeViewCancelEventHandler objEventHandler = this.BeforeCheckHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Called before collapsing node.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"/> instance containing the event data.</param>
        internal void OnBeforeCollapseInternal(TreeViewCancelEventArgs e)
        {
            OnBeforeCollapse(e);
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCollapse"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data.</param>
        protected internal virtual void OnBeforeCollapse(TreeViewCancelEventArgs e)
        {
            // Raise event if needed
            TreeViewCancelEventHandler objEventHandler = this.BeforeCollapseHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterLabelEdit"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs"></see> that contains the event data. </param>
        protected virtual void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            // Raise event if needed
            NodeLabelEditEventHandler objEventHandler = this.AfterLabelEditHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeLabelEdit"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs"></see> that contains the event data. </param>
        protected virtual void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
        {
            // Raise event if needed
            NodeLabelEditEventHandler objEventHandler = this.BeforeLabelEditHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:AfterLabelEditInternal"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.NodeLabelEditEventArgs"/> instance containing the event data.</param>
        internal void OnAfterLabelEditInternal(NodeLabelEditEventArgs e)
        {
            OnAfterLabelEdit(e);
        }

        /// <summary>
        /// Raises the <see cref="E:BeforeSelect"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"/> instance containing the event data.</param>
        internal void OnBeforeSelectInternal(TreeViewCancelEventArgs e)
        {
            OnBeforeSelect(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeSelect"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
        protected virtual void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            // Raise event if needed
            TreeViewCancelEventHandler objEventHandler = this.BeforeSelectHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:NodeMouseClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        internal void OnNodeMouseClickInternal(TreeNodeMouseClickEventArgs e)
        {
            OnNodeMouseClick(e);
            OnClick(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
        protected virtual void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            // Raise event if needed
            TreeNodeMouseClickEventHandler objEventHandler = this.NodeMouseClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:NodeMouseDoubleClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        internal void OnNodeMouseDoubleClickInternal(TreeNodeMouseClickEventArgs e)
        {
            OnNodeMouseDoubleClick(e);
            OnDoubleClick(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
        protected virtual void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            // Raise event if needed
            TreeNodeMouseClickEventHandler objEventHandler = this.NodeMouseDoubleClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:BeforeExpand"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"/> instance containing the event data.</param>
        internal void OnBeforeExpandIntenral(TreeViewCancelEventArgs e)
        {
            OnBeforeExpand(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeExpand"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
        protected virtual void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            // Raise event if needed
            TreeViewCancelEventHandler objEventHandler = this.BeforeExpandHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #endregion Events

        #region Render


        /// <summary>
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
                // Render the SelectOnRightClick attribute.
                RenderSelectOnRightClick(objWriter, true);

                // Render the TreeNodeClickEventsOnToggle attribute.
                objWriter.WriteAttributeString(WGAttributes.TreeNodeClickEventsOnToggle, this.WinFormsCompatibility.IsTreeNodeClickEventsOnToggle ? "1" : "0");
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                RenderItemHeight(objWriter);
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderItemHeight(objWriter);

            RenderEditingInformation(objContext, objWriter);

            // Render the SelectOnRightClick attribute.
            RenderSelectOnRightClick(objWriter, false);

            // Render the TreeNodeClickEventsOnToggle attribute.
            objWriter.WriteAttributeString(WGAttributes.TreeNodeClickEventsOnToggle, this.WinFormsCompatibility.IsTreeNodeClickEventsOnToggle ? "1" : "0");
        }

        /// <summary>
        /// Renders the height of the item.
        /// </summary>
        /// <param name="objWriter">The object writer.</param>
        private void RenderItemHeight(IAttributeWriter objWriter)
        {
            int intPreferedItemHeight = GetPreferdItemHeight();

            objWriter.WriteAttributeString(WGAttributes.ItemHeight, intPreferedItemHeight.ToString());
        }



        /// <summary>
        /// Gets the height of the preferd item font.
        /// </summary>
        /// <returns></returns>
        internal int GetPreferdItemHeight()
        {
            if (this.HasItemHeight || this.HasProxyPropertyValue("ItemHeight"))
            {
                return this.GetProxyPropertyValue<int>("ItemHeight", this.InnerItemHeight);
            }
            else
            {
                //Set the default padding fix
                int intHeigtFixConstant = 4;

                return CommonUtils.GetFontHeight(this.GetProxyPropertyValue<Font>("Font", this.Font)) + intHeigtFixConstant;
            }
        }

        /// <summary>
        /// Renders the select on right click.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.SelectOnRightClick)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectOnRightClick, "1");
            }
            else if (blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectOnRightClick, "0");
            }
        }

        /// <summary>
        /// Renders the editing information.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected void RenderEditingInformation(IContext objContext, IAttributeWriter objWriter)
        {
            if (this.LabelEdit)
            {
                objWriter.WriteAttributeString(WGAttributes.LabelEdit, "1");
            }
        }

        /// <summary>
        /// Renderes the tree view control
        /// </summary>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {

            // add attributes to control element
            objWriter.WriteAttributeText(WGAttributes.Text, Text, TextFilter.CarriageReturn | TextFilter.NewLine);

            if (this.CheckBoxes) objWriter.WriteAttributeString(WGAttributes.CheckBoxes, "1");
            if (!ShowPlusMinus) objWriter.WriteAttributeString(WGAttributes.HidePlusMinus, "1");
            if (this.ShowLines) objWriter.WriteAttributeString(WGAttributes.ShowLines, "1");

            //If the tree view has checkboxes
            if (this.CheckBoxes)
            {
                //and the State ImageList is set
                if (this.StateImageList != null)
                {
                    //We must check that the state image list has 2 images
                    if (this.StateImageList.Images.Count > 1)
                    {
                        //So the first image will be the unchecked value image
                        //and the second image will be the checked value image
                        objWriter.WriteAttributeString(WGAttributes.StateImageUnchecked, this.StateImageList.Images[0].ToString());
                        objWriter.WriteAttributeString(WGAttributes.StateImageChecked, this.StateImageList.Images[1].ToString());
                    }
                }
            }


            RenderControls(objContext, objWriter, 0);
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // add all child nodes
            foreach (TreeNode objNode in Nodes)
            {
                // If the node is visible
                if (objNode.Visible)
                {
                    // Render the node
                    objNode.RenderNode(objContext, objWriter, lngRequestID, this.CheckBoxes ? CheckBoxVisibility.True : CheckBoxVisibility.False);
                }
            }
        }

        #endregion Render

        #region Properties

        /// <summary>
        /// Gets the default full row select.
        /// </summary>
        private bool DefaultFullRowSelect
        {
            get
            {
                TreeViewSkin objTreeViewSkin = this.Skin as TreeViewSkin;
                if (objTreeViewSkin != null)
                {
                    return objTreeViewSkin.FullRowSelect;
                }
                return false;
            }
        }

        /// <summary>
        /// Adds a critical event delegate to the list.
        /// </summary>
        /// <param name="objSerializableEvent">The serializable event.</param>
        /// <param name="objValue">The delegate to add to the list.</param>
        /// <returns></returns>
        protected override void AddCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
        {
            if (base.AddHandler(objSerializableEvent, objValue))
            {
                // Render the whole tree.
                this.Update();
            }
        }

        /// <summary>
        /// Removes a critical event delegate from the list.
        /// </summary>
        /// <param name="objSerializableEvent">The serializable event.</param>
        /// <param name="objValue">The delegate to remove from the list.</param>
        /// <returns></returns>
        protected override void RemoveCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
        {
            if (base.RemoveHandler(objSerializableEvent, objValue))
            {
                // Render the whole tree.
                this.Update();
            }
        }

        /// <summary>Gets or sets a value indicating whether the selection highlight spans the width of the tree view control.</summary>
        /// <returns>true if the selection highlight spans the width of the tree view control; otherwise, false. The default is false.</returns>
        /// <remarks>Not implemented.</remarks>
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("TreeViewFullRowSelectDescr")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FullRowSelect
        {
            get
            {
                return this.GetValue<bool>(TreeView.FullRowSelectProperty, this.DefaultFullRowSelect);
            }
            set
            {
                if (this.SetValue<bool>(TreeView.FullRowSelectProperty, value, this.DefaultFullRowSelect))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override bool IsDelayedDrawing
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets or sets the implementation of <see cref="T:System.Collections.IComparer"></see> to perform a custom sort of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> nodes.</summary>
        /// <returns>The <see cref="T:System.Collections.IComparer"></see> to perform the custom sort.</returns>
        /// <filterpriority>2</filterpriority>
        [Browsable(false), SRCategory("CatBehavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("TreeViewNodeSorterDescr")]
        public IComparer TreeViewNodeSorter
        {
            get
            {
                return this.GetValue<IComparer>(TreeView.TreeViewNodeSorterProperty);
            }
            set
            {
                if (this.SetValue<IComparer>(TreeView.TreeViewNodeSorterProperty, value))
                {
                    // If the new sorter is not null
                    if (value != null)
                    {
                        // Sort the items
                        this.Sort();
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the tree nodes in the tree view are sorted.</summary>
        /// <returns>true if the tree nodes in the tree view are sorted; otherwise, false. The default is false.</returns>
        [SRDescription("TreeViewSortedDescr"), SRCategory("CatBehavior"), DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool Sorted
        {
            get
            {
                return this.GetValue<bool>(TreeView.SortedProperty);
            }
            set
            {
                if (this.SetValue<bool>(TreeView.SortedProperty, value))
                {
                    if (value && (this.TreeViewNodeSorter == null) && (this.Nodes.Count >= 1))
                    {
                        this.RefreshNodes();
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the label text of the tree nodes can be edited.</summary>
        /// <returns>true if the label text of the tree nodes can be edited; otherwise, false. The default is false.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), SRDescription("TreeViewLabelEditDescr"), DefaultValue(false)]
        public bool LabelEdit
        {
            get
            {
                // If treeview is not in readonly state
                return this.GetState(ComponentState.ReadOnly);
            }
            set
            {
                // Set the treeview readonly state
                if (this.SetStateWithCheck(ComponentState.ReadOnly, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [edit node].
        /// </summary>
        /// <value>The edit node.</value>
        internal TreeNode EditNode
        {
            get
            {
                return this.GetValue<TreeNode>(TreeView.EditNodeProperty);
            }
            set
            {
                this.SetValue<TreeNode>(TreeView.EditNodeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [hide selection].
        /// </summary>
        /// <value><c>true</c> if [hide selection]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.DefaultValue(false)]
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

        /// <summary>
        ///
        /// </summary>
        [DefaultValue((string)null), SRDescription("TreeViewImageListDescr"), SRCategory("CatBehavior")]
        public ImageList ImageList
        {
            get
            {
                return this.GetValue<ImageList>(TreeView.ImageListProperty);
            }
            set
            {
                if (this.SetValue<ImageList>(TreeView.ImageListProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the image list used for indicating the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> and its nodes.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> used for indicating the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> and its nodes.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), SRDescription("TreeViewStateImageListDescr"), DefaultValue((string)null)]
        public ImageList StateImageList
        {
            get
            {
                return this.GetValue<ImageList>(TreeView.StateImageListProperty);
            }
            set
            {
                // If value has changed
                if (this.SetValue<ImageList>(TreeView.StateImageListProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether check boxes are displayed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if check boxes are displayed; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(false)]
        public bool CheckBoxes
        {
            get
            {
                return this.GetValue<bool>(TreeView.CheckBoxesProperty);
            }
            set
            {
                if (this.SetValue<bool>(TreeView.CheckBoxesProperty, value))
                {
                    // Update the control
                    Update();

                    // Fire the property changed event.
                    FireObservableItemPropertyChanged("CheckBoxes");
                }
            }
        }

        /// <summary>
        /// <para>Gets the collection of tree nodes that are assigned to the tree view control.</para>
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), MergableProperty(false), SRCategory("CatBehavior"), Localizable(true), SRDescription("TreeViewNodesDescr")]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        public TreeNodeCollection Nodes
        {
            get
            {
                return mobjNodes;
            }
        }

        /// <summary>
        /// Gets or sets the selected node.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public TreeNode SelectedNode
        {
            get
            {
                return this.GetValue<TreeNode>(TreeView.SelectedNodeProperty);
            }
            set
            {
                SelectNode(value, true, TreeViewAction.Unknown);
            }

        }

        /// <summary>
        /// Selects the node.
        /// </summary>
        /// <param name="objTreeNode">The obj tree node.</param>
        /// <param name="blnCode">if set to <c>true</c> [BLN code].</param>
        /// <param name="enmAction">The action.</param>
        internal void SelectNode(TreeNode objTreeNode, bool blnCode, TreeViewAction enmAction)
        {
            TreeNode objSelectedNode = this.SelectedNode;

            // If tree node is not null
            if (objTreeNode != null)
            {
                // If not current selected tree node
                if (objTreeNode.TreeView != this || objTreeNode == objSelectedNode)
                {
                    return;
                }

                // If the before select did not cancel the selection
                if (!objTreeNode.OnBeforeSelect(enmAction))
                {
                    // Change previous selected node
                    if (objSelectedNode != null)
                    {
                        objSelectedNode.SetSelected(false, blnCode);
                    }

                    // Update current selected node member
                    this.SetValue<TreeNode>(TreeView.SelectedNodeProperty, objTreeNode);

                    // Set selected node true
                    objTreeNode.SetSelected(true, blnCode);

                    // Call the after select event
                    objTreeNode.OnAfterSelect(enmAction);
                }
                else
                {
                    // Cancel selected node and if is from event
                    objTreeNode.SetSelected(false, !blnCode);

                    // If from event
                    if (!blnCode)
                    {
                        // If there is a selected node update it
                        if (objSelectedNode != null)
                        {
                            objSelectedNode.Update();
                        }
                    }
                    return;
                }
            }
            else
            {
                // If there was a selected node clear it
                if (objSelectedNode != null)
                {
                    objSelectedNode.SetSelected(false, blnCode);
                    this.SetValue<TreeNode>(TreeView.SelectedNodeProperty, null);
                }
            }
        }

        /// <summary>Sorts the items if the value of the <see cref="P:Gizmox.WebGUI.Forms.TreeView.TreeViewNodeSorter"></see> property is not null.</summary>
        public void Sort()
        {
            this.Sorted = true;
            this.RefreshNodes();
        }

        /// <summary>
        /// Refresh current nodes
        /// </summary>
        private void RefreshNodes()
        {
            TreeNode[] arrDestination = new TreeNode[this.Nodes.Count];
            this.Nodes.CopyTo(arrDestination, 0);
            this.Nodes.Clear();
            this.Nodes.AddRange(arrDestination);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show plus minus.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [to show plus minus]; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(true)]
        public bool ShowPlusMinus
        {
            get
            {
                return this.GetValue<bool>(TreeView.ShowPlusMinusProperty);
            }
            set
            {
                if (this.SetValue<bool>(TreeView.ShowPlusMinusProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show lines.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if to show lines; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(true)]
        public bool ShowLines
        {
            get
            {
                return this.GetValue<bool>(TreeView.ShowLinesProperty);
            }
            set
            {
                if (this.SetValue<bool>(TreeView.ShowLinesProperty, value))
                {
                    // Update the control
                    this.Update();

                    // Fire the 'item property changed' event
                    FireObservableItemPropertyChanged("ShowLines");
                }
            }
        }

        /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
        /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
        /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), SRDescription("TreeViewImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        [RelatedImageList("ImageList")]
        public int ImageIndex
        {
            get
            {
                if (ImageList == null)
                {
                    return -1;
                }
                int imageIndex = this.GetValue<int>(TreeView.ImageIndexProperty);
                if (imageIndex >= ImageList.Images.Count)
                {
                    return Math.Max(0, ImageList.Images.Count - 1);
                }
                return imageIndex;
            }
            set
            {
                if (value == -1)
                {
                    value = 0;
                }
                if (value < 0)
                {
                    object[] args = new object[] { "ImageIndex", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("ImageIndex", SR.GetString("InvalidLowBoundArgumentEx", args));
                }
                if (this.SetValue<int>(TreeView.ImageIndexProperty, value))
                {
                    // Set the ImageKeyProperty to the default value
                    this.RemoveValue<string>(TreeView.ImageKeyProperty);

                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the image list index value of the image that is displayed when a tree node is selected.</summary>
        /// <returns>A zero-based index value that represents the position of an <see cref="T:System.Drawing.Image"></see> in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
        /// <exception cref="T:System.ArgumentException">The index assigned value is less than zero. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), SRDescription("TreeViewImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        [RelatedImageList("ImageList")]
        public int SelectedImageIndex
        {
            get
            {
                if (ImageList == null)
                {
                    return -1;
                }
                int selectedImageIndex = this.GetValue<int>(TreeView.SelectedImageIndexProperty);
                if (ImageList != null && selectedImageIndex >= ImageList.Images.Count)
                {
                    return Math.Max(0, ImageList.Images.Count - 1);
                }
                return selectedImageIndex;
            }
            set
            {
                if (value == -1)
                {
                    value = 0;
                }
                if (value < 0)
                {
                    object[] args = new object[] { "SelectedImageIndex", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("SelectedImageIndex", SR.GetString("InvalidLowBoundArgumentEx", args));
                }
                if (this.SetValue<int>(TreeView.SelectedImageIndexProperty, value))
                {
                    // Set the SelectedImageKey Property to the default value
                    this.RemoveValue<string>(TreeView.SelectedImageKeyProperty);

                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
        /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), Localizable(true), DefaultValue("")]
        [RelatedImageList("ImageList")]
        public string ImageKey
        {
            get
            {
                return this.GetValue<string>(TreeView.ImageKeyProperty);
            }
            set
            {
                if (this.SetValue<string>(TreeView.ImageKeyProperty, value))
                {
                    // Set the ImageKeyProperty to the default value
                    this.RemoveValue<int>(TreeView.ImageIndexProperty);

                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a selected state.</summary>
        /// <returns>The key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a selected state.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), Localizable(true), DefaultValue(""), SRDescription("TreeViewSelectedImageKeyDescr")]
        [RelatedImageList("ImageList")]
        public string SelectedImageKey
        {
            get
            {
                return this.GetValue<string>(TreeView.SelectedImageKeyProperty);
            }
            set
            {
                if (this.SetValue<string>(TreeView.SelectedImageKeyProperty, value))
                {
                    // Set the SelectedImageKey Property to the default value
                    this.RemoveValue<int>(TreeView.SelectedImageIndexProperty);

                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a Expanded state.</summary>
        /// <returns>The key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a Expanded state.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), Localizable(true), DefaultValue(""), SRDescription("TreeViewExpandedImageKeyDescr")]
        [RelatedImageList("ImageList")]
        public string ExpandedImageKey
        {
            get
            {
                return this.GetValue<string>(TreeView.ExpandedImageKeyProperty);
            }
            set
            {
                // If value has changed
                if (this.SetValue<string>(TreeView.ExpandedImageKeyProperty, value))
                {
                    // Set the ExpandedImageIndex Property to the default value
                    this.RemoveValue<int>(TreeView.ExpandedImageIndexProperty);

                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the image list index value of the image that is displayed when a tree node is Expanded.</summary>
        /// <returns>A zero-based index value that represents the position of an <see cref="T:System.Drawing.Image"></see> in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
        /// <exception cref="T:System.ArgumentException">The index assigned value is less than zero. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), SRDescription("TreeViewImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        [RelatedImageList("ImageList")]
        public int ExpandedImageIndex
        {
            get
            {
                if (ImageList == null)
                {
                    return -1;
                }
                int expandedImageIndex = this.GetValue<int>(TreeView.ExpandedImageIndexProperty);
                if (expandedImageIndex >= ImageList.Images.Count)
                {
                    return Math.Max(0, ImageList.Images.Count - 1);
                }
                return expandedImageIndex;
            }
            set
            {
                if (value == -1)
                {
                    value = 0;
                }
                if (value < 0)
                {
                    object[] args = new object[] { "ExpandedImageIndex", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("ExpandedImageIndex", SR.GetString("InvalidLowBoundArgumentEx", args));
                }
                // If value has changed
                if (this.SetValue<int>(TreeView.ExpandedImageIndexProperty, value))
                {
                    // Set the ExpandedImageKey Property to the default value
                    this.RemoveValue<string>(TreeView.ExpandedImageKeyProperty);

                    // Update the control
                    this.Update();
                }
            }
        }

        protected override string ClientEventsPropogationTags
        {
            get
            {
                return WGTags.TreeNode;
            }
        }

        /// <summary>
        /// Gets or sets the path separator.
        /// </summary>
        /// <value>The path separator.</value>
        [System.ComponentModel.DefaultValue(@"\")]
        public string PathSeparator
        {
            get
            {
                return this.GetValue<string>(TreeView.PathSeparatorProperty);
            }
            set
            {
                this.SetValue<string>(TreeView.PathSeparatorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the select on right click.
        /// </summary>
        /// <value>The select on right click.</value>
        [SRCategory("CatAppearance"), SRDescription("SelectOnRightClickDescr"), DefaultValue(false)]
        public bool SelectOnRightClick
        {
            get
            {
                return this.GetValue<bool>(TreeView.SelectOnRightClickProperty);
            }
            set
            {
                if (this.SetValue<bool>(TreeView.SelectOnRightClickProperty, value))
                {
                    // Update the control
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [raise click on mouse down].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [raise click on mouse down]; otherwise, <c>false</c>.
        /// </value>
        internal bool RaiseClickOnMouseDown
        {
            get
            {
                return base.ShouldRaiseClickOnRightMouseDown;
            }
        }


        /// <summary>
        /// Gets or sets the indent.
        /// </summary>
        /// <value>
        /// The indent.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int Indent
        {
            get
            {
                return this.GetValue<int>(TreeView.IndentProperty);
            }
            set
            {
                this.SetValue<int>(TreeView.IndentProperty, value);

            }
        }

        /// <summary>
        /// Gets or sets the height of the item.
        /// When none is given, calculates the treenode height by using the font size.
        /// </summary>
        /// <value>
        /// The height of the item.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">ItemHeight</exception>        
        [SRDescription("TreeViewItemHeightDescr"), SRCategory("CatAppearance")]
        [ProxyBrowsable(true)]
        public int ItemHeight
        {
            get
            {
                int intItemHeightFromProperty = this.InnerItemHeight;
                if (intItemHeightFromProperty == -1)
                {
                    intItemHeightFromProperty = GetPreferdItemHeight();
                }
              
                return intItemHeightFromProperty;
            }
            set
            {
                if (value < 1)
                {
                    object[] args = new object[] { "ItemHeight", value.ToString(CultureInfo.CurrentCulture), 1.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("ItemHeight", SR.GetString("InvalidLowBoundArgumentEx", args));
                }
                if (value > 0x7fff)
                {
                    object[] args = new object[] { "ItemHeight", value.ToString(CultureInfo.CurrentCulture), 0x7fff.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("ItemHeight", SR.GetString("InvalidHighBoundArgumentEx", args));
                }

                this.InnerItemHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the inner item.
        /// </summary>
        /// <value>
        /// The height of the inner item.
        /// </value>
        private int InnerItemHeight
        {
            get
            {
                return this.GetValue<int>(TreeView.ItemHeightProperty);
            }
            set
            {
                if (this.SetValue<int>(TreeView.ItemHeightProperty, value))
                {
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets or sets the height of the inner item.
        /// </summary>
        /// <value>
        /// The height of the inner item.
        /// </value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasItemHeight
        {
            get
            {
                return this.ContainsValue<int>(TreeView.ItemHeightProperty);
            }          
        }

        /// <summary>
        /// Shoulds the height of the serialize item.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeItemHeight()
        {
            return HasItemHeight;
        }

        /// <summary>
        /// Resets the height of the item.
        /// </summary>
        private void ResetItemHeight()
        {
            this.RemoveValue<int>(TreeView.ItemHeightProperty);
            this.UpdateParams(AttributeType.Visual);
        }

        /// <summary>Gets the first fully-visible tree node in the tree view control.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> that represents the first fully-visible tree node in the tree view control.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatAppearance"), SRDescription("TreeViewTopNodeDescr")]
        public TreeNode TopNode
        {
            get
            {
                return this.GetTopNode();
            }
            set
            {
                // if(Scrollable == true) - TODO: implement Scrollable property
                value.EnsureVisible();
            }
        }

        /// <summary>
        /// Gets the top node in the tree view visible area.
        /// </summary>
        /// <returns></returns>
        private TreeNode GetTopNode()
        {
            if (this.Nodes.Count == 0)
            {
                return null;
            }

            return GetNodeFromOriginPointAndDistance(this.Nodes[0], this.ScrollTop);
        }


        /// <summary>
        /// Gets the node from origin point and distance.
        /// </summary>
        /// <param name="objNode">The origin node.</param>
        /// <param name="intDistance">The distance from the node (downwards).</param>
        /// <returns></returns>
        private TreeNode GetNodeFromOriginPointAndDistance(TreeNode objNode, int intDistance)
        {
            // If a half of a node is visible then return it
            if (intDistance < this.ItemHeight / 2)
            {
                return objNode;
            }
            else
            {
                return GetNodeFromOriginPointAndDistance(objNode.NextVisibleNode, intDistance - this.ItemHeight);
            }
        }

        /// <summary>Gets or sets a value indicating ToolTips are shown when the mouse pointer hovers over a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>.</summary>
        /// <returns>true if ToolTips are shown when the mouse pointer hovers over a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>; otherwise, false. The default is false.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatBehavior"), SRDescription("TreeViewShowShowNodeToolTipsDescr"), DefaultValue(false)]
        public bool ShowNodeToolTips
        {
            get
            {
                return false;
            }
            set
            { }
        }

        /// <summary>Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> label takes on the appearance of a hyperlink as the mouse pointer passes over it.</summary>
        /// <returns>true if a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> label takes on the appearance of a hyperlink as the mouse pointer passes over it; otherwise, false. The default is false.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("TreeViewHotTrackingDescr")]
        public bool HotTracking
        {
            get
            {
                return GetValue(HotTrackingProperty, false);
            }
            set
            {
                SetValue(HotTrackingProperty, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the tree view control displays scroll bars when they are needed.</summary>
        /// <returns>true if the tree view control displays scroll bars when they are needed; otherwise, false. The default is true.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("TreeViewScrollableDescr"), SRCategory("CatBehavior"), DefaultValue(true)]
        public bool Scrollable
        {
            get
            {
                return GetValue(ScrollableProperty, true);
            }
            set
            {
                SetValue(ScrollableProperty, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether lines are drawn between the tree nodes that are at the root of the tree view.</summary>
        /// <returns>true if lines are drawn between the tree nodes that are at the root of the tree view; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("TreeViewShowRootLinesDescr"), SRCategory("CatBehavior"), DefaultValue(true)]
        public bool ShowRootLines
        {
            get
            {
                return true;
            }
            set
            { }
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <value>
        /// The win forms compatibility.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new TreeViewWinFormsCompatibility WinFormsCompatibility
        {
            get
            {
                return base.WinFormsCompatibility as TreeViewWinFormsCompatibility;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            return this.Nodes;
        }

        /// <summary>
        /// Creates the node collection.
        /// </summary>
        /// <returns></returns>
        protected virtual TreeNodeCollection CreateNodeCollection()
        {
            return new TreeNodeCollection(this);
        }

        /// <summary>
        /// Creates the node collection.
        /// </summary>
        /// <param name="treeView">The tree view.</param>
        /// <param name="arrNodes">The arr nodes.</param>
        /// <returns></returns>
        protected virtual TreeNodeCollection CreateNodeCollection(object[] arrNodes)
        {
            return new TreeNodeCollection(this, arrNodes);
        }

        /// <summary>Expands all the tree nodes.</summary>
        public void ExpandAll()
        {
            foreach (TreeNode objChildNode in this.Nodes)
            {
                objChildNode.ExpandAll();
            }
        }

        /// <summary>Collapses all the tree nodes.</summary>
        public void CollapseAll()
        {
            foreach (TreeNode objChildNode in this.Nodes)
            {
                objChildNode.Collapse();
            }
        }


        /// <summary>
        /// Adds a child object.
        /// </summary>
        /// <param name="objValue">The child object to add.</param>
        protected override void AddChild(object objValue)
        {
            // If value is a tree node
            if (objValue is TreeNode)
            {
                this.Nodes.Add((TreeNode)objValue);
            }
            else
            {
                base.AddChild(objValue);
            }
        }

        /// <summary>Retrieves the number of tree nodes, optionally including those in all subtrees, assigned to the tree view control.</summary>
        /// <returns>The number of tree nodes, optionally including those in all subtrees, assigned to the tree view control.</returns>
        public int GetNodeCount(bool blnIncludeSubTrees)
        {
            int intTotal = this.Nodes.Count;
            if (blnIncludeSubTrees)
            {
                foreach (TreeNode objChildNode in this.Nodes)
                {
                    intTotal += objChildNode.GetNodeCount(true);
                }
            }
            return intTotal;
        }

        /// <summary>
        /// Disables any redrawing of the tree view.
        /// </summary>
        public void BeginUpdate()
        {

        }

        /// <summary>
        /// Enables the redrawing of the tree view.
        /// </summary>
        public void EndUpdate()
        {
        }

        /// <summary>
        ///Retrieves the tree node that is at the specified point.
        /// Not implemented
        /// </summary>
        /// <param name="intX"></param>
        /// <param name="intY"></param>
        [Obsolete("Not implemented")]
        public TreeNode GetNodeAt(int intX, int intY)
        {
            return null;
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            TreeNodeCollection objNodes = this.Nodes;
            if (objNodes != null)
            {
                // register control children
                RegisterBatch(objNodes);
            }
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            TreeNodeCollection objNodes = this.Nodes;
            if (objNodes != null)
            {
                // Unregister control children
                UnRegisterBatch(objNodes);
            }
        }


        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new TreeViewRenderer(this);
        }

        /// <summary>
        /// Determines whether [is critical event] [the specified enm event type].
        /// </summary>
        /// <param name="enmEventType">Type of the enm event.</param>
        /// <returns>
        /// 	<c>true</c> if [is critical event] [the specified enm event type]; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsCriticalEvent(string strEventName)
        {
            CriticalEventsData objEvents = this.GetCriticalEventsData();
            return objEvents.HasEvent(strEventName);
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <returns></returns>
        protected override WinFormsCompatibility GetWinFormsCompatibility()
        {
            return new TreeViewWinFormsCompatibility();
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
        {
            if (strChangedOptionName == WinFormsCompatibilityPredefinedOptions.TreeNodeClickEventsOnToggle)
            {
                // Update control params.
                this.UpdateParams(AttributeType.Control);
            }

            base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
        }

        #endregion Methods
    }

    #endregion TreeView Class

    #region TreeNode Class

    /// <summary>
    /// Defines the node's check box - visibility
    /// </summary>
    [Serializable()]
    public enum CheckBoxVisibility
    {
        /// <summary>
        /// Do not display the CheckBox.
        /// </summary>
        False = 0,
        /// <summary>
        /// Display the CheckBox.
        /// </summary>
        True = 1,
        /// <summary>
        ///  CheckBox inherits the visibility property of its parent.
        /// </summary>
        Inherited = 2
    }

    /// <summary>
    /// Defines RightClick Behvior
    /// </summary>
    [Serializable()]
    public enum SelectOnRightClickBehvior : byte
    {
        /// <summary>
        /// RightClick disabled
        /// </summary>
        No = 0,
        /// <summary>
        /// RightClick enabled
        /// </summary>
        Yes = 1,
        /// <summary>
        /// Inherits the RightClickBehvior property of its parent.
        /// </summary>
        Inherit = 2
    }

    /// <summary>
    /// Summary description for TreeNode.
    /// </summary>
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#endif
    [Serializable()]
    [ProxyComponent(typeof(ProxyTreeNode))]
    public class TreeNode : Component
    {
        #region Client Members

        /// <summary>
        /// Occurs when [client after label edit].
        /// </summary>
        [SRDescription("Occurs when control's label edited in client mode."), Category("Client")]
        public event ClientEventHandler ClientAfterLabelEdit
        {
            add
            {
                this.AddClientHandler("AfterLabelEdit", value);
            }
            remove
            {
                this.RemoveClientHandler("AfterLabelEdit", value);
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// Provides a property reference to BackColor property.
        /// </summary>
        private static SerializableProperty BackColorProperty = SerializableProperty.Register("BackColor", typeof(Color), typeof(TreeNode), new SerializablePropertyMetadata(Color.White));

        /// <summary>
        /// Provides a property reference to CheckBox property.
        /// </summary>
        private static SerializableProperty CheckBoxProperty = SerializableProperty.Register("CheckBox", typeof(CheckBoxVisibility), typeof(TreeNode), new SerializablePropertyMetadata(CheckBoxVisibility.Inherited));

        /// <summary>
        /// Provides a property reference to ExpandedImageIndex property.
        /// </summary>
        private static SerializableProperty ExpandedImageIndexProperty = SerializableProperty.Register("ExpandedImageIndex", typeof(int), typeof(TreeNode), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to ExpandedImage property.
        /// </summary>
        private static SerializableProperty ExpandedImageProperty = SerializableProperty.Register("ExpandedImage", typeof(ResourceHandle), typeof(TreeNode), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ForeColor property.
        /// </summary>
        private static SerializableProperty ForeColorProperty = SerializableProperty.Register("ForeColor", typeof(Color), typeof(TreeNode), new SerializablePropertyMetadata(Color.Black));

        /// <summary>
        /// Provides a property reference to HasNodes property.
        /// </summary>
        private static SerializableProperty HasNodesProperty = SerializableProperty.Register("HasNodes", typeof(bool), typeof(TreeNode), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ImageIndex property.
        /// </summary>
        private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(TreeNode), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to ImageKey property.
        /// </summary>
        private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to Image property.
        /// </summary>
        private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(TreeNode), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to IsExpanded property.
        /// </summary>
        private static SerializableProperty IsExpandedProperty = SerializableProperty.Register("IsExpanded", typeof(bool), typeof(TreeNode), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to Label property.
        /// </summary>
        private static SerializableProperty LabelProperty = SerializableProperty.Register("Label", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to Name property.
        /// </summary>
        private static SerializableProperty NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to NodeFont property.
        /// </summary>
        private static SerializableProperty NodeFontProperty = SerializableProperty.Register("NodeFont", typeof(Font), typeof(TreeNode), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to SelectedImageIndex property.
        /// </summary>
        private static SerializableProperty SelectedImageIndexProperty = SerializableProperty.Register("SelectedImageIndex", typeof(int), typeof(TreeNode), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to SelectedImageKey property.
        /// </summary>
        private static SerializableProperty SelectedImageKeyProperty = SerializableProperty.Register("SelectedImageKey", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to SelectedImage property.
        /// </summary>
        private static SerializableProperty SelectedImageProperty = SerializableProperty.Register("SelectedImage", typeof(ResourceHandle), typeof(TreeNode), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to SelectOnRightClick property.
        /// </summary>
        private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register("SelectOnRightClick", typeof(SelectOnRightClickBehvior), typeof(TreeNode), new SerializablePropertyMetadata(SelectOnRightClickBehvior.Inherit));

        /// <summary>
        /// Provides a property reference to StateImageIndex property. 
        /// </summary>
        private static SerializableProperty StateImageIndexProperty = SerializableProperty.Register("StateImageIndex", typeof(int), typeof(TreeNode), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to StateImageKey property. 
        /// </summary>
        private static SerializableProperty StateImageKeyProperty = SerializableProperty.Register("StateImageKey", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to StateImage property.
        /// </summary>
        private static SerializableProperty StateImageProperty = SerializableProperty.Register("StateImage", typeof(ResourceHandle), typeof(TreeNode), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ToolTipText property.
        /// </summary>
        private static SerializableProperty ToolTipTextProperty = SerializableProperty.Register("ToolTipText", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to ExpandedImageKey property.
        /// </summary>
        private static SerializableProperty ExpandedImageKeyProperty = SerializableProperty.Register("ExpandedImageKey", typeof(string), typeof(TreeNode), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// The node collection
        /// </summary>
        [NonSerialized]
        private TreeNodeCollection mobjNodes = null;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Renders the update attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        internal void RenderUpdateAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                objWriter.WriteAttributeText(WGAttributes.Text, this.Text, TextFilter.CarriageReturn | TextFilter.NewLine);

                // Render the SelectOnRightClick attribute.
                RenderSelectOnRightClick(objWriter, true);

            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
            {
                objWriter.WriteAttributeText(WGAttributes.ToolTip, this.ToolTipText);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
            {
                Font objNodeFont = this.NodeFont;
                if (objNodeFont != null)
                {
                    objWriter.WriteAttributeString(WGAttributes.Font, ClientUtils.GetWebFont(objNodeFont));
                }
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                RenderImages(objWriter);
            }
        }

        /// <summary>
        /// Renders the select on right click.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
        {
            SelectOnRightClickBehvior enmSelectOnRightClick = this.SelectOnRightClick;
            if (enmSelectOnRightClick != SelectOnRightClickBehvior.Inherit)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectOnRightClick, Convert.ToByte(enmSelectOnRightClick).ToString());
            }
            else if (blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectOnRightClick, string.Empty);
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Create the node collection array
            mobjNodes = CreateNodeCollection(objReader);
        }

        protected virtual TreeNodeCollection CreateNodeCollection(SerializationReader objReader)
        {
            return new TreeNodeCollection(this, objReader.ReadArray());
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write the node collection array
            objWriter.WriteArray(mobjNodes);
        }

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                int intSerializableDataInitialSize = base.SerializableDataInitialSize;

                // Add the nodes collection required capacity
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjNodes);

                return intSerializableDataInitialSize;
            }
        }

        #endregion Methods

        #region Class Members

        #region Events

        /// <summary>Occurs when the user double-clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse.</summary>
        [SRCategory("CatBehavior"), SRDescription("TreeViewNodeMouseDoubleClickDescr")]
        public event TreeNodeMouseClickEventHandler NodeMouseDoubleClick
        {
            add
            {
                this.AddHandler(TreeNode.NodeMouseDoubleClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.NodeMouseDoubleClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the NodeMouseDoubleClick event.
        /// </summary>
        private TreeNodeMouseClickEventHandler NodeMouseDoubleClickHandler
        {
            get
            {
                return (TreeNodeMouseClickEventHandler)this.GetHandler(TreeNode.NodeMouseDoubleClickEvent);
            }
        }

        /// <summary>
        /// The NodeMouseDoubleClick event registration.
        /// </summary>
        private static readonly SerializableEvent NodeMouseDoubleClickEvent = SerializableEvent.Register("NodeMouseDoubleClick", typeof(TreeNodeMouseClickEventHandler), typeof(TreeNode));

        /// <summary>Occurs when the user clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse. </summary>
        [SRDescription("TreeViewNodeMouseClickDescr"), SRCategory("CatBehavior")]
        public event TreeNodeMouseClickEventHandler NodeMouseClick
        {
            add
            {
                this.AddHandler(TreeNode.NodeMouseClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.NodeMouseClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the NodeMouseClick event.
        /// </summary>
        private TreeNodeMouseClickEventHandler NodeMouseClickHandler
        {
            get
            {
                return (TreeNodeMouseClickEventHandler)this.GetHandler(TreeNode.NodeMouseClickEvent);
            }
        }

        /// <summary>
        /// The NodeMouseClick event registration.
        /// </summary>
        private static readonly SerializableEvent NodeMouseClickEvent = SerializableEvent.Register("NodeMouseClick", typeof(TreeNodeMouseClickEventHandler), typeof(TreeNode));

        /// <summary>Occurs before the tree node is selected.</summary>
        [SRDescription("TreeViewBeforeSelectDescr"), SRCategory("CatBehavior")]
        public event TreeViewCancelEventHandler BeforeSelect
        {
            add
            {
                this.AddHandler(TreeNode.BeforeSelectEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.BeforeSelectEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeSelect event.
        /// </summary>
        private TreeViewCancelEventHandler BeforeSelectHandler
        {
            get
            {
                return (TreeViewCancelEventHandler)this.GetHandler(TreeNode.BeforeSelectEvent);
            }
        }

        /// <summary>
        /// The BeforeSelect event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeSelectEvent = SerializableEvent.Register("BeforeSelect", typeof(TreeViewCancelEventHandler), typeof(TreeNode));

        /// <summary>Occurs before the tree node label text is edited.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewBeforeEditDescr")]
        public event NodeLabelEditEventHandler BeforeLabelEdit
        {
            add
            {
                this.AddHandler(TreeNode.BeforeLabelEditEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.BeforeLabelEditEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeLabelEdit event.
        /// </summary>
        private NodeLabelEditEventHandler BeforeLabelEditHandler
        {
            get
            {
                return (NodeLabelEditEventHandler)this.GetHandler(TreeNode.BeforeLabelEditEvent);
            }
        }

        /// <summary>
        /// The BeforeLabelEdit event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeLabelEditEvent = SerializableEvent.Register("BeforeLabelEdit", typeof(NodeLabelEditEventHandler), typeof(TreeNode));

        /// <summary>Occurs before the tree node is expanded.</summary>
        [SRDescription("TreeViewBeforeExpandDescr"), SRCategory("CatBehavior")]
        public event TreeViewCancelEventHandler BeforeExpand
        {
            add
            {
                this.AddHandler(TreeNode.BeforeExpandEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.BeforeExpandEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeExpand event.
        /// </summary>
        private TreeViewCancelEventHandler BeforeExpandHandler
        {
            get
            {
                return (TreeViewCancelEventHandler)this.GetHandler(TreeNode.BeforeExpandEvent);
            }
        }

        /// <summary>
        /// The BeforeExpand event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeExpandEvent = SerializableEvent.Register("BeforeExpand", typeof(TreeViewCancelEventHandler), typeof(TreeNode));

        /// <summary>Occurs after the tree node is expanded.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("TreeViewAfterExpandDescr")]
        public event TreeViewEventHandler AfterExpand
        {
            add
            {
                this.AddHandler(TreeNode.AfterExpandEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.AfterExpandEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterExpand event.
        /// </summary>
        private TreeViewEventHandler AfterExpandHandler
        {
            get
            {
                return (TreeViewEventHandler)this.GetHandler(TreeNode.AfterExpandEvent);
            }
        }

        /// <summary>
        /// The AfterExpand event registration.
        /// </summary>
        private static readonly SerializableEvent AfterExpandEvent = SerializableEvent.Register("AfterExpand", typeof(TreeViewEventHandler), typeof(TreeNode));

        /// <summary>Occurs before the tree node check box is checked.</summary>
        [SRCategory("CatBehavior"), SRDescription("TreeViewBeforeCheckDescr")]
        public event TreeViewCancelEventHandler BeforeCheck
        {
            add
            {
                this.AddHandler(TreeNode.BeforeCheckEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.BeforeCheckEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeCheck event.
        /// </summary>
        private TreeViewCancelEventHandler BeforeCheckHandler
        {
            get
            {
                return (TreeViewCancelEventHandler)this.GetHandler(TreeNode.BeforeCheckEvent);
            }
        }

        /// <summary>
        /// The BeforeCheck event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeCheckEvent = SerializableEvent.Register("BeforeCheck", typeof(TreeViewCancelEventHandler), typeof(TreeNode));

        /// <summary>Occurs after the tree node check box is checked.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("TreeViewAfterCheckDescr"), SRCategory("CatBehavior")]
        public event TreeViewEventHandler AfterCheck
        {
            add
            {
                this.AddHandler(TreeNode.AfterCheckEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.AfterCheckEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterCheck event.
        /// </summary>
        private TreeViewEventHandler AfterCheckHandler
        {
            get
            {
                return (TreeViewEventHandler)this.GetHandler(TreeNode.AfterCheckEvent);
            }
        }

        /// <summary>
        /// The AfterCheck event registration.
        /// </summary>
        private static readonly SerializableEvent AfterCheckEvent = SerializableEvent.Register("AfterCheck", typeof(TreeViewEventHandler), typeof(TreeNode));

        /// <summary>Occurs after the tree node is collapsed.</summary>
        [SRCategory("CatBehavior"), SRDescription("TreeViewAfterCollapseDescr")]
        public event TreeViewEventHandler AfterCollapse
        {
            add
            {
                this.AddHandler(TreeNode.AfterCollapseEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.AfterCollapseEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterCollapse event.
        /// </summary>
        private TreeViewEventHandler AfterCollapseHandler
        {
            get
            {
                return (TreeViewEventHandler)this.GetHandler(TreeNode.AfterCollapseEvent);
            }
        }

        /// <summary>
        /// The AfterCollapse event registration.
        /// </summary>
        private static readonly SerializableEvent AfterCollapseEvent = SerializableEvent.Register("AfterCollapse", typeof(TreeViewEventHandler), typeof(TreeNode));

        /// <summary>Occurs before the tree node is collapsed.</summary>
        [SRCategory("CatBehavior"), SRDescription("TreeViewBeforeCollapseDescr")]
        public event TreeViewCancelEventHandler BeforeCollapse
        {
            add
            {
                this.AddHandler(TreeNode.BeforeCollapseEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.BeforeCollapseEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BeforeCollapse event.
        /// </summary>
        private TreeViewCancelEventHandler BeforeCollapseHandler
        {
            get
            {
                return (TreeViewCancelEventHandler)this.GetHandler(TreeNode.BeforeCollapseEvent);
            }
        }

        /// <summary>
        /// The BeforeCollapse event registration.
        /// </summary>
        private static readonly SerializableEvent BeforeCollapseEvent = SerializableEvent.Register("BeforeCollapse", typeof(TreeViewCancelEventHandler), typeof(TreeNode));

        /// <summary>Occurs after the tree node label text is edited.</summary>
        [SRCategory("CatBehavior"), SRDescription("TreeViewAfterEditDescr")]
        public event NodeLabelEditEventHandler AfterLabelEdit
        {
            add
            {
                this.AddHandler(TreeNode.AfterLabelEditEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.AfterLabelEditEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterLabelEdit event.
        /// </summary>
        private NodeLabelEditEventHandler AfterLabelEditHandler
        {
            get
            {
                return (NodeLabelEditEventHandler)this.GetHandler(TreeNode.AfterLabelEditEvent);
            }
        }

        /// <summary>
        /// The AfterLabelEdit event registration.
        /// </summary>
        private static readonly SerializableEvent AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof(NodeLabelEditEventHandler), typeof(TreeNode));

        /// <summary>Occurs after the tree node is selected.</summary>
        [SRCategory("CatBehavior"), SRDescription("TreeViewAfterSelectDescr")]
        public event TreeViewEventHandler AfterSelect
        {
            add
            {
                this.AddHandler(TreeNode.AfterSelectEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeNode.AfterSelectEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AfterSelect event.
        /// </summary>
        private TreeViewEventHandler AfterSelectHandler
        {
            get
            {
                return (TreeViewEventHandler)this.GetHandler(TreeNode.AfterSelectEvent);
            }
        }

        /// <summary>
        /// The AfterSelect event registration.
        /// </summary>
        private static readonly SerializableEvent AfterSelectEvent = SerializableEvent.Register("AfterSelect", typeof(TreeViewEventHandler), typeof(TreeNode));

        #endregion

        #endregion Class Members

        #region C'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strLabel"></param>
        /// <param name="strIcon"></param>
        public TreeNode(string strName, string strLabel, string strIcon)
        {
            this.SetValue<string>(TreeNode.NameProperty, strName);
            this.SetValue<string>(TreeNode.LabelProperty, strLabel);
            if (strIcon != "")
            {
                this.SetValue<ResourceHandle>(TreeNode.ImageProperty, new IconResourceHandle(strIcon + ".gif"));
            }

            // Create a new node collection
            mobjNodes = CreateNodeCollection();

            // Set the initialize state
            this.SetState(ComponentState.Loaded | ComponentState.Visible, true);
        }

        /// <summary>
        /// Creates the node collection.
        /// </summary>
        /// <returns></returns>
        protected virtual TreeNodeCollection CreateNodeCollection()
        {
            return new TreeNodeCollection(this);
        }

        /// <summary>
        ///
        /// </summary>
        public TreeNode(string strLabel)
            : this("", strLabel, "")
        {

        }

        /// <summary>
        ///
        /// </summary>
        public TreeNode()
            : this("", "", "")
        {

        }

        /// <summary>
        ///
        /// </summary>
        public TreeNode(string strLabel, TreeNode[] arrTreeNodes)
            : this("", strLabel, "")
        {
            Nodes.AddRange(arrTreeNodes);
        }

        /// <summary>
        ///
        /// </summary>
        public TreeNode(string strLabel, int intImageIndex, int intSelectedImageIndex)
            : this(strLabel)
        {
            this.ImageIndex = intImageIndex;
            this.SelectedImageIndex = intSelectedImageIndex;
        }

        /// <summary>
        ///
        /// </summary>
        public TreeNode(string strLabel, int intImageIndex, int intSelectedImageIndex, TreeNode[] arrTreeNodes)
            : this(strLabel, arrTreeNodes)
        {
            this.ImageIndex = intImageIndex;
            this.SelectedImageIndex = intSelectedImageIndex;
        }


        #endregion C'Tor

        #region Events

        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
        /// </value>        
        /// <returns>false if one of the controls is hidden or disabled.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsEventsEnabled
        {
            get
            {
                if (!this.IsVisible)
                {
                    return false;
                }
                else
                {
                    return base.IsEventsEnabled;
                }
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            // Select event type
            switch (objEvent.Type)
            {
                case "Click":
                    this.OnNodeMouseClick(objEvent);
                    break;

                case "DoubleClick":
                    this.OnNodeMouseDoubleClick(objEvent);
                    break;

                case "CheckedChange":
                    ChangeCheckState((objEvent["Value"] == "1"), TreeViewAction.ByMouse);
                    break;

                case "Selection":
                    bool blnIsKeyboard = (objEvent["Keyboard"] == "1");
                    this.OnSelect(blnIsKeyboard);
                    break;

                case "FirstExpand":
                case "Expand":
                    // If is not expanded
                    if (!this.IsExpanded)
                    {
                        // Check if not canceled and raise before check
                        if (!this.OnBeforeExpand())
                        {
                            // Change expanded mode
                            this.SetValue<bool>(TreeNode.IsExpandedProperty, true);


                            // Raise after check
                            this.OnAfterExpand();

                            // If was needs to be loaded
                            if (objEvent.Type == "FirstExpand")
                            {
                                this.Update();
                            }
                        }
                        else
                        {
                            // Update the current node
                            this.Update();
                        }
                    }
                    break;

                case "Collapse":
                    if (this.IsExpanded)
                    {
                        // Check if not canceled and raise before check
                        if (!this.OnBeforeCollapse())
                        {
                            // Set expanded value
                            this.SetValue<bool>(TreeNode.IsExpandedProperty, false);

                            // Raise after check
                            this.OnAfterCollapse();
                        }
                        else
                        {
                            // Update the current node
                            this.Update();
                        }
                    }
                    break;

                case "AfterLabelEdit":

                    string strText = CommonUtils.DecodeText(objEvent["Text"]);

                    //create event arg
                    NodeLabelEditEventArgs objArgs = new NodeLabelEditEventArgs(this, strText);

                    // Raise AfterLabelEdit
                    OnAfterLabelEdit(objArgs);

                    //check if user cancel edit
                    if (!objArgs.CancelEdit)
                    {
                        //update node label value
                        this.TextInternal = strText;
                    }
                    else
                    {
                        //render old text
                        this.UpdateParams(AttributeType.Control);
                    }

                    break;
                case "StartDrag":
                    TreeView objTreeView = this.TreeView;
                    if (objTreeView != null)
                    {
                        objTreeView.FireItemDrag(new ItemDragEventArgs(MouseButtons.Left, this));
                    }
                    break;
            }
        }

        private void OnSelect(bool blnIsKeyboard)
        {
            bool blnIsSelection = !this.IsSelected;
            if (blnIsSelection)
            {
                if (this.TreeView != null)
                {
                    this.TreeView.SelectNode(this, false, blnIsKeyboard ? TreeViewAction.ByKeyboard : TreeViewAction.ByMouse);
                }
            }
        }

        /// <summary>
        /// Called when this node mouse is double clicked.
        /// </summary>
        private void OnNodeMouseDoubleClick(IEvent objEvent)
        {
            // Raise node mouse click.
            OnNodeMouseClick(objEvent);

            // Get x and coordinates.
            int intX = GetEventValue(objEvent, "X", 0);
            int intY = GetEventValue(objEvent, "Y", 0);

            TreeNodeMouseClickEventArgs objArgs = CreateTreeNodeMouseClickEventArgs(this, MouseButtons.Left, 2, intX, intY);
            OnNodeMouseDoubleClick(objArgs);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
        protected virtual void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            this.OnSelect(false);

            // Raise event if needed
            TreeNodeMouseClickEventHandler objEventHandler = this.NodeMouseDoubleClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnNodeMouseDoubleClickInternal(e);
            }
        }

        /// <summary>
        /// Called when this node is clicked.
        /// </summary>
        private void OnNodeMouseClick(IEvent objEvent)
        {
            // Get x and coordinates.
            int intX = GetEventValue(objEvent, "X", 0);
            int intY = GetEventValue(objEvent, "Y", 0);

            //Get mouse event args from the objevent
            MouseEventArgs objMouseEventArgs = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, intX, intY, 0);

            TreeNodeMouseClickEventArgs objArgs = CreateTreeNodeMouseClickEventArgs(this, objMouseEventArgs.Button, 1, objMouseEventArgs.X, objMouseEventArgs.Y);
            OnNodeMouseClick(objArgs);
        }

        /// <summary>
        /// Creates the tree node mouse click event args.
        /// </summary>
        /// <param name="objNode">The node.</param>
        /// <param name="objButton">The button.</param>
        /// <param name="intClicks">The clicks.</param>
        /// <param name="intX">The X.</param>
        /// <param name="intY">The Y.</param>
        /// <returns></returns>
        protected virtual TreeNodeMouseClickEventArgs CreateTreeNodeMouseClickEventArgs(TreeNode objNode, MouseButtons objButton, int intClicks, int intX, int intY)
        {
            return new TreeNodeMouseClickEventArgs(objNode, objButton, intClicks, intX, intY);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
        protected virtual void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            // Raise event if needed
            TreeNodeMouseClickEventHandler objEventHandler = this.NodeMouseClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnNodeMouseClickInternal(e);
            }
        }

        /// <summary>
        /// Called before node checked status is changed.
        /// </summary>
        /// <returns></returns>
        private bool OnBeforeCheck(TreeViewAction enmTreeViewAction)
        {
            TreeViewCancelEventArgs objArgs = new TreeViewCancelEventArgs(this, false, enmTreeViewAction);
            OnBeforeCheck(objArgs);
            return objArgs.Cancel;
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCheck"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
        protected virtual void OnBeforeCheck(TreeViewCancelEventArgs e)
        {
            // Raise event if needed
            TreeViewCancelEventHandler objEventHandler = this.BeforeCheckHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnBeforeCheckInternal(e);
            }
        }

        /// <summary>
        /// Called after node checked status is changed.
        /// </summary>
        private void OnAfterCheck()
        {
            TreeViewEventArgs objArgs = new TreeViewEventArgs(this);
            OnAfterCheck(objArgs);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCheck"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
        protected virtual void OnAfterCheck(TreeViewEventArgs e)
        {
            // Raise event if needed
            TreeViewEventHandler objEventHandler = this.AfterCheckHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnAfterCheckInternal(e);
            }
        }

        /// <summary>
        /// Called before the node is selected.
        /// </summary>
        internal bool OnBeforeSelect(TreeViewAction enmTreeViewAction)
        {
            TreeViewCancelEventArgs objArgs = new TreeViewCancelEventArgs(this, false, enmTreeViewAction);
            OnBeforeSelect(objArgs);
            return objArgs.Cancel;
        }

        /// <summary>
        /// Raises the <see cref="E:BeforeSelect"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"/> instance containing the event data.</param>
        protected virtual void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            // Raise event if needed
            TreeViewCancelEventHandler objEventHandler = this.BeforeSelectHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnBeforeSelectInternal(e);
            }
        }

        /// <summary>
        /// Called after node is selected.
        /// </summary>
        internal void OnAfterSelect(TreeViewAction enmTreeViewAction)
        {
            TreeViewEventArgs objArgs = new TreeViewEventArgs(this, enmTreeViewAction);
            OnAfterSelect(objArgs);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterSelect"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
        protected virtual void OnAfterSelect(TreeViewEventArgs e)
        {
            // Raise event if needed
            TreeViewEventHandler objEventHandler = this.AfterSelectHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnAfterSelectInternal(e);
            }
        }

        /// <summary>
        /// Called after node is expanded.
        /// </summary>
        private void OnAfterExpand()
        {
            TreeViewEventArgs objArgs = new TreeViewEventArgs(this, TreeViewAction.Expand);
            OnAfterExpand(objArgs);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterExpand"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
        protected virtual void OnAfterExpand(TreeViewEventArgs e)
        {
            // Raise event if needed
            TreeViewEventHandler objEventHandler = this.AfterExpandHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnAfterExpandInternal(e);
            }
        }

        /// <summary>
        /// Called before node is collapsed.
        /// </summary>
        /// <returns></returns>
        private bool OnBeforeCollapse()
        {
            TreeViewCancelEventArgs objArgs = new TreeViewCancelEventArgs(this, false, TreeViewAction.Collapse);
            OnBeforeCollapse(objArgs);
            return objArgs.Cancel;
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCollapse"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
        protected virtual void OnBeforeCollapse(TreeViewCancelEventArgs e)
        {
            // Raise event if needed
            TreeViewCancelEventHandler objEventHandler = this.BeforeCollapseHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnBeforeCollapse(e);
            }
        }

        /// <summary>
        /// Called after node is collapsed.
        /// </summary>
        private void OnAfterCollapse()
        {
            TreeViewEventArgs objArgs = new TreeViewEventArgs(this, TreeViewAction.Collapse);
            OnAfterCollapse(objArgs);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCollapse"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
        protected internal virtual void OnAfterCollapse(TreeViewEventArgs e)
        {
            // Raise event if needed
            TreeViewEventHandler objEventHandler = this.AfterCollapseHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnAfterCollapseInternal(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:AfterLabelEdit"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.NodeLabelEditEventArgs"/> instance containing the event data.</param>
        protected internal virtual void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            // Raise event if needed
            NodeLabelEditEventHandler objEventHandler = this.AfterLabelEditHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnAfterLabelEditInternal(e);
            }
        }

        /// <summary>
        /// Called before node is expanded.
        /// </summary>
        /// <returns></returns>
        private bool OnBeforeExpand()
        {
            TreeViewCancelEventArgs objArgs = new TreeViewCancelEventArgs(this, false, TreeViewAction.ByMouse);
            OnBeforeExpand(objArgs);
            return objArgs.Cancel;
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeExpand"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
        protected virtual void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            // Raise event if needed
            TreeViewCancelEventHandler objEventHandler = this.BeforeExpandHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.TreeView != null)
            {
                this.TreeView.OnBeforeExpandIntenral(e);
            }
        }

        #endregion Events

        #region Render

        /// <summary>
        /// Disposes the specified component.
        /// </summary>
        /// <param name="blnDisposing"></param>
        protected override void Dispose(bool blnDisposing)
        {
            // Dispose the node
            base.Dispose(blnDisposing);

            if (blnDisposing)
            {
                // Loop all nodes and dispose them
                foreach (TreeNode objTreeNode in this.Nodes)
                {
                    objTreeNode.Dispose();
                }
            }
        }

        /// <summary>
        /// Renders the node attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected virtual void RenderNodeAttributes(IContext objContext, IResponseWriter objWriter)
        {

        }

        /// <summary>
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
                // set flags
                if (Nodes.Count > 0) HasNodes = true;
                if (HasNodes && Nodes.Count == 0) Loaded = false;

                objWriter.WriteStartElement(WGTags.TreeNode);

                // Render Attributes.
                this.RenderNodeAttributes(objContext, objWriter);

                // render component attributes
                RegisterSelf();
                RenderComponentAttributes(objContext, (IAttributeWriter)objWriter);

                objWriter.WriteAttributeText(WGAttributes.Text, Label, TextFilter.CarriageReturn | TextFilter.NewLine);

                RenderImages((IAttributeWriter)objWriter);

                // Render select on right click.
                RenderSelectOnRightClick((IAttributeWriter)objWriter, false);

                Font objNodeFont = NodeFont;
                if (objNodeFont != null)
                {
                    objWriter.WriteAttributeString(WGAttributes.Font, ClientUtils.GetWebFont(objNodeFont));
                }

                Color objForeColor = ForeColor;
                if (objForeColor != Color.Black)
                {
                    objWriter.WriteAttributeString(WGAttributes.Fore, CommonUtils.GetHtmlColor(objForeColor));
                }

                Color objBackColor = BackColor;
                if (objBackColor != Color.White)
                {
                    objWriter.WriteAttributeString(WGAttributes.Background, CommonUtils.GetHtmlColor(objBackColor));
                }
                if (this.HasRedrawingParent) objWriter.WriteAttributeString(WGAttributes.HasRedrawingParent, "1");
                
                if ((!Loaded || (!IsExpanded && HasNodes)) && !(this.TreeView.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient))
                {
                    objWriter.WriteAttributeString(WGAttributes.Loaded, "0");
                } 
                
                if (!IsExpanded && HasNodes == true) objWriter.WriteAttributeString(WGAttributes.Expanded, "0");
                if (HasNodes) objWriter.WriteAttributeString(WGAttributes.HasNodes, "1");
                if (Selected) objWriter.WriteAttributeString(WGAttributes.Selected, "1");
                if (this.CheckBox == CheckBoxVisibility.True || (this.CheckBox == CheckBoxVisibility.Inherited && enmParentCheckBoxVisibility == CheckBoxVisibility.True)) objWriter.WriteAttributeString(WGAttributes.CheckBoxes, "1");
                if (Checked) objWriter.WriteAttributeString(WGAttributes.Checked, "1");

                string strToolTip = this.ToolTipText;
                if (strToolTip != string.Empty) objWriter.WriteAttributeText(WGAttributes.ToolTip, strToolTip);
                if (IsExpanded == true || this.TreeView.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
                {
                    RenderComponents(objContext, objWriter, 0, enmParentCheckBoxVisibility);
                }

                // Render component client events
                RenderComponentClientEvents(objContext, objWriter, lngRequestID);

                objWriter.WriteEndElement();
            }
            else
            {
                // if only control params are dirty
                if (IsDirtyAttributes(lngRequestID))
                {
                    // write control element tags
                    objWriter.WriteStartElement(WGConst.Prefix, WGTags.UpdateParams, WGConst.Namespace);

                    // Render component update attributes
                    RenderComponentUpdateAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);

                    // render control
                    RenderUpdateAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);

                    // Render sub nodes
                    RenderComponents(objContext, objWriter, lngRequestID, enmParentCheckBoxVisibility);

                    // close control element tag
                    objWriter.WriteEndElement();
                }
                else
                {
                    RenderComponents(objContext, objWriter, lngRequestID, enmParentCheckBoxVisibility);
                }
            }
        }

        /// <summary>
        /// Renders the components.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The response writer object.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="enmParentCheckBoxVisibility">The enm parent check box visibility.</param>
        internal void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, CheckBoxVisibility enmParentCheckBoxVisibility)
        {
            // render node and sub nodes
            foreach (TreeNode objNode in Nodes)
            {
                // If the node is visible
                if (objNode.Visible || this.TreeView.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
                {
                    objNode.RenderNode(objContext, objWriter, lngRequestID, this.CheckBox == CheckBoxVisibility.Inherited ? enmParentCheckBoxVisibility : this.CheckBox);
                }
            }
        }

        /// <summary>
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
                // If visible value had changed
                if (SetStateWithCheck(ComponentState.Visible, value))
                {
                    // Get the parent
                    Component objParent = this.InternalParent;

                    // If there is a valid parent
                    if (objParent != null)
                    {
                        // Update the parent
                        objParent.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Renders the images.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        internal void RenderImages(IAttributeWriter objWriter)
        {
            ResourceHandle objImage = this.Image;
            if (objImage != null)
            {
                objWriter.WriteAttributeString(WGAttributes.Image, objImage.ToString());
            }

            ResourceHandle objSelectedImage = this.SelectedImage;
            if (objSelectedImage != null)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectedImage, objSelectedImage.ToString());
            }

            ResourceHandle objExpandedImage = this.ExpandedImage;
            if (objExpandedImage != null)
            {
                objWriter.WriteAttributeString(WGAttributes.ExpandedImage, objExpandedImage.ToString());
            }

            //If checkboxes property is not set
            if (!this.TreeView.CheckBoxes)
            {
                ResourceHandle objStateImage = this.StateImage;
                if (objStateImage != null)
                {
                    //Rander state image for each node if exist
                    objWriter.WriteAttributeString(WGAttributes.StateImage, objStateImage.ToString());
                }
            }
        }

        /// <summary>
        /// Gets the name of the client component.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string GetClientComponentName()
        {
            return this.Name;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();

            if (this.HasClientHandler("AfterLabelEdit"))
            {
                objEvents.Set(WGEvents.AfterLabelEdit);
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.AfterCollapseHandler != null) objEvents.Set(WGEvents.Collapse);
            if (this.AfterExpandHandler != null) objEvents.Set(WGEvents.Expand);
            if (this.BeforeCollapseHandler != null) objEvents.Set(WGEvents.Collapse);
            if (this.BeforeExpandHandler != null) objEvents.Set(WGEvents.Expand);

            TreeView objTreeView = this.TreeView;
            if (objTreeView != null)
            {
                if(!objTreeView.IsCriticalEvent(WGEvents.CheckedChange) && (this.AfterCheckHandler != null || this.BeforeCheckHandler != null))
                {
                    objEvents.Set(WGEvents.CheckedChange);
                }

                if (this.NodeMouseClickHandler != null ||
                    ((objTreeView.IsCriticalEvent(WGEvents.Click) || objTreeView.NodeMouseClickHandler != null)))
                {
                    objEvents.Set(WGEvents.Click);

                    if (objTreeView.RaiseClickOnMouseDown)
                    {
                        objEvents.Set(WGEvents.RightClick);
                    }
                }

                if (this.NodeMouseDoubleClickHandler != null ||
                    ((objTreeView.IsCriticalEvent(WGEvents.DoubleClick) || objTreeView.NodeMouseDoubleClickHandler != null)))
                {
                    objEvents.Set(WGEvents.DoubleClick);
                }

                if (this.AfterSelectHandler != null || this.BeforeSelectHandler != null ||
                    (objTreeView.IsCriticalEvent(WGEvents.SelectionChange)))
                {
                    objEvents.Set(WGEvents.SelectionChange);
                }

                if (this.AfterLabelEditHandler != null ||
                    (objTreeView.IsCriticalEvent(WGEvents.AfterLabelEdit)))
                {
                    objEvents.Set(WGEvents.AfterLabelEdit);
                }

                if (objTreeView.ItemDragHandler != null)
                {
                    objEvents.Set(WGEvents.StartDrag);
                }
            }

            return objEvents;
        }

        /// <summary>
        /// Shoulds the color of the serialize back.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeBackColor()
        {
            return BackColor != Color.White;
        }

        /// <summary>
        /// Shoulds the color of the serialize fore.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeForeColor()
        {
            return ForeColor != Color.Black;
        }

        #endregion Render

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether check boxes are displayed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if check boxes are displayed; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(CheckBoxVisibility.Inherited)]
        public CheckBoxVisibility CheckBox
        {
            get
            {
                return this.GetValue<CheckBoxVisibility>(TreeNode.CheckBoxProperty);
            }
            set
            {

                if (this.SetValue<CheckBoxVisibility>(TreeNode.CheckBoxProperty, value))
                {
                    // Update the control
                    Update();

                    // Fire the property changed event
                    FireObservableItemPropertyChanged("CheckBox");

                }
            }
        }

        /// <summary>
        /// Gets or sets the tool tip text for the tree node.
        /// </summary>
        /// <value></value>
        [DefaultValue("")]
        public string ToolTipText
        {
            get
            {
                return this.GetValue<string>(TreeNode.ToolTipTextProperty);
            }
            set
            {

                if (this.SetValue<string>(TreeNode.ToolTipTextProperty, value))
                {
                    // Update node
                    UpdateParams(AttributeType.ToolTip);
                }
            }
        }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <value></value>
        public string FullPath
        {
            get
            {
                TreeView objTreeView = this.TreeView;
                if (objTreeView != null)
                {
                    StringBuilder objPath = new StringBuilder();
                    this.GetFullPath(objPath, objTreeView.PathSeparator);
                    return objPath.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Gets the tree node parent.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public TreeNode Parent
        {
            get
            {
                return InternalParent as TreeNode;
            }
        }

        /// <summary>Gets or sets the background color of the tree node.</summary>
        /// <returns>The background <see cref="T:System.Drawing.Color"></see> of the tree node. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
        [SRCategory("CatAppearance"), SRDescription("TreeNodeBackColorDescr")]
        public Color BackColor
        {
            get
            {
                return this.GetValue<Color>(TreeNode.BackColorProperty);
            }
            set
            {
                if (this.SetValue<Color>(TreeNode.BackColorProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Resets the color of the back.
        /// </summary>
        private void ResetBackColor()
        {
            this.BackColor = Color.White;
        }

        /// <summary>Gets the first child tree node in the tree node collection.</summary>
        /// <returns>The first child <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> in the <see cref="P:Gizmox.WebGUI.Forms.TreeNode.Nodes"></see> collection.</returns>
        [Browsable(false)]
        public TreeNode FirstNode
        {
            get
            {
                TreeNodeCollection objNodes = this.Nodes;
                if (objNodes.Count == 0)
                {
                    return null;
                }
                return objNodes[0];
            }
        }

        /// <summary>Gets or sets the foreground color of the tree node.</summary>
        /// <returns>The foreground <see cref="T:System.Drawing.Color"></see> of the tree node.</returns>
        [SRCategory("CatAppearance"), SRDescription("TreeNodeForeColorDescr")]
        public Color ForeColor
        {
            get
            {
                return this.GetValue<Color>(TreeNode.ForeColorProperty);
            }
            set
            {
                if (this.SetValue<Color>(TreeNode.ForeColorProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Resets the color of the fore.
        /// </summary>
        private void ResetForeColor()
        {
            this.ForeColor = Color.Black;
        }

        /// <summary>
        /// Gets or sets the select on right click.
        /// </summary>
        /// <value>The select on right click.</value>
        [SRCategory("CatAppearance"), SRDescription("SelectOnRightClickDescr"), DefaultValue(SelectOnRightClickBehvior.Inherit)]
        public SelectOnRightClickBehvior SelectOnRightClick
        {
            get
            {
                return this.GetValue<SelectOnRightClickBehvior>(TreeNode.SelectOnRightClickProperty);
            }
            set
            {
                if (this.SetValue<SelectOnRightClickBehvior>(TreeNode.SelectOnRightClickProperty, value))
                {
                    // Update the control
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>Gets the position of the tree node in the tree node collection.</summary>
        /// <returns>A zero-based index value that represents the position of the tree node in the <see cref="P:Gizmox.WebGUI.Forms.TreeNode.Nodes"></see> collection.</returns>
        [SRCategory("CatBehavior"), SRDescription("TreeNodeIndexDescr")]
        public int Index
        {
            get
            {
                if (this.Parent != null)
                {
                    return (((IList)this.Parent.Nodes).IndexOf(this));
                }
                else if (this.TreeView != null)
                {
                    return (((IList)this.TreeView.Nodes).IndexOf(this));
                }
                else
                {
                    return -1;
                }
            }
            internal set
            {
                if (this.Parent != null)
                {
                    ((IList)this.Parent.Nodes).Insert(value, this);
                }
                else if (this.TreeView != null)
                {
                    ((IList)this.TreeView.Nodes).Insert(value, this);
                }

            }
        }

        /// <summary>Gets a value indicating whether the tree node is in an editable state.</summary>
        /// <returns>true if the tree node is in editable state; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public bool IsEditing
        {
            get
            {
                TreeView treeView = this.TreeView;
                return ((treeView != null) && (treeView.EditNode == this));
            }
        }

        /// <summary>Gets a value indicating whether the tree node is in the selected state.</summary>
        /// <returns>true if the tree node is in the selected state; otherwise, false.</returns>
        [Browsable(false)]
        public bool IsSelected
        {
            get
            {
                return this.Selected;
            }
        }

        /// <summary>Gets a value indicating whether the tree node is visible or partially visible.</summary>
        /// <returns>true if the tree node is visible or partially visible; otherwise, false.</returns>
        [Browsable(false)]
        public bool IsVisible
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets the last child tree node.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the last child tree node.</returns>
        [Browsable(false)]
        public TreeNode LastNode
        {
            get
            {
                TreeNodeCollection objNodes = this.Nodes;
                if (objNodes.Count == 0)
                {
                    return null;
                }
                return objNodes[objNodes.Count - 1];

            }
        }

        /// <summary>Gets the zero-based depth of the tree node in the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> control.</summary>
        /// <returns>The zero-based depth of the tree node in the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> control.</returns>
        [Browsable(false)]
        public int Level
        {
            get
            {
                if (this.Parent == null)
                {
                    return 0;
                }
                return (this.Parent.Level + 1);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has a redrawing parent.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has redrawing parent; otherwise, <c>false</c>.
        /// </value>
        private bool HasRedrawingParent
        {
            get
            {
                bool blnHasRedrawingParent = false;
                Control objParent = this.TreeView;

                while (objParent != null && !blnHasRedrawingParent)
                {
                    if (objParent.Redraws)
                    {
                        blnHasRedrawingParent = true;
                    }
                    else
                    {
                        objParent = objParent.Parent;
                    }
                }

                return blnHasRedrawingParent;
            }
        }

        private TreeNodeCollection ParentNodes
        {
            get
            {
                if (this.Parent != null)
                {
                    return this.Parent.Nodes;
                }
                else if (this.TreeView != null)
                {
                    return this.TreeView.Nodes;
                }
                else
                {
                    return null;
                }
            }
        }

        private TreeNode NextUncle
        {
            get
            {
                bool blnContinueUpwards = false;
                TreeNode objTreeNode = this;

                do
                {
                    if (objTreeNode.Parent != null)
                    {
                        // if parent is not last child (of grandparent), next uncle is parent's next sibling
                        if (objTreeNode.Parent.ParentNodes.Count > (objTreeNode.Parent.Index + 1))
                        {
                            return objTreeNode.Parent.ParentNodes[objTreeNode.Parent.Index + 1];
                        }
                        // if parent is last child (of grandparent), iterate on next level up
                        else
                        {
                            objTreeNode = objTreeNode.Parent;
                            blnContinueUpwards = true;
                        }
                    }
                    else
                    {
                        return null;
                    }
                } while (blnContinueUpwards);

                return null;
            }
        }

        /// <summary>Gets the previous sibling tree node.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the previous sibling tree node.</returns>
        [Browsable(false)]
        public TreeNode PrevNode
        {
            get
            {
                int intIndex = this.Index;
                // if first child, return null
                if (intIndex < 1)
                {
                    return null;
                }
                else
                // if not first child, return previous sibling
                {
                    TreeNodeCollection objParentNodes = this.ParentNodes;
                    if (objParentNodes != null)
                    {
                        return objParentNodes[intIndex - 1];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>Gets the previous visible tree node.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the previous visible tree node.</returns>  
        [Browsable(false)]
        public TreeNode PrevVisibleNode
        {
            get
            {
                TreeNode objNode = null;
                // if this is not first child, return last visible child of previous sibling
                if (this.PrevNode != null)
                {
                    objNode = this.PrevNode.LastVisibleChild;
                }
                // if first child, return parent
                else if (this.Parent != null)
                {
                    objNode = this.Parent;
                }
                return objNode;
            }
        }
        /// <summary>
        /// Returns last visible child of last child
        /// or self if no children or not expanded
        /// </summary>
        private TreeNode LastVisibleChild
        {
            get
            {
                TreeNode objNode = this;
                while (objNode.IsExpanded && objNode.LastChild != null)
                {
                    objNode = objNode.LastChild;
                }
                return objNode;
            }
        }
        /// <summary>
        /// Returns the last child of this node,
        /// if any, otherwise returns null
        /// </summary>
        private TreeNode LastChild
        {
            get
            {
                TreeNode objNode = null;
                if ((this.Nodes != null) && (this.Nodes.Count > 0))
                {
                    objNode = this.Nodes[this.Nodes.Count - 1];
                }
                return objNode;
            }
        }

        /// <summary>Gets the next sibling tree node.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the next sibling tree node.</returns>
        [Browsable(false)]
        public TreeNode NextNode
        {
            get
            {
                TreeNodeCollection objParentNodes = this.ParentNodes;
                if (objParentNodes != null)
                {
                    int intIndex = this.Index;
                    if (objParentNodes.Count > (intIndex + 1))
                    {
                        return objParentNodes[intIndex + 1];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>Gets the next visible tree node.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the next visible tree node.</returns>
        /// <filterpriority>1</filterpriority>        
        [Browsable(false)]
        public TreeNode NextVisibleNode
        {
            get
            {
                TreeNode objNode = null;
                // has children and expanded --> return first child
                if ((this.IsExpanded) && (this.Nodes.Count > 0))
                {
                    objNode = this.Nodes[0];
                }
                // next sibling, if any
                else if (this.NextNode != null)
                {
                    objNode = this.NextNode;
                }
                // next uncle, if any, or null
                else
                {
                    objNode = NextUncle;
                }

                return objNode;
            }
        }

        /// <summary>
        /// Gets or sets the node font.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public Font NodeFont
        {
            get
            {
                return this.GetValue<Font>(TreeNode.NodeFontProperty);
            }
            set
            {
                // If value has changed
                if (this.SetValue<Font>(TreeNode.NodeFontProperty, value))
                {
                    UpdateParams(AttributeType.Layout);
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected image index.
        /// </summary>
        /// <value></value>
        [SRCategory("CatBehavior"), System.ComponentModel.DefaultValue(-1)]
        public int SelectedImageIndex
        {
            get
            {
                return this.GetValue<int>(TreeNode.SelectedImageIndexProperty);
            }
            set
            {
                // If value has changed
                if (this.SetValue<int>(TreeNode.SelectedImageIndexProperty, value))
                {
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>Gets or sets the index of the image used to indicate the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> when the parent <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> has its <see cref="P:Gizmox.WebGUI.Forms.TreeView.CheckBoxes"></see> property set to false.</summary>
        /// <returns>The index of the image used to indicate the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), RelatedImageList("TreeView.StateImageList"), SRDescription("TreeNodeStateImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        public int StateImageIndex
        {
            get
            {
                return this.GetValue<int>(TreeNode.StateImageIndexProperty);
            }
            set
            {
                // If value has changed
                if (this.SetValue<int>(TreeNode.StateImageIndexProperty, value))
                {
                    // Update the node
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets or sets the image index.
        /// </summary>
        /// <value></value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), RelatedImageList("TreeView.ImageList"), SRDescription("TreeNodeImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        public int ImageIndex
        {
            get
            {
                return this.GetValue<int>(TreeNode.ImageIndexProperty);
            }
            set
            {
                if (this.SetValue<int>(TreeNode.ImageIndexProperty, value))
                {
                    // Set the ImageKey Property to the default value
                    this.RemoveValue<string>(TreeNode.ImageKeyProperty);

                    // Update the control.
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>Gets or sets the key of the image displayed in the tree node when it is in a selected state.</summary>
        /// <returns>The key of the image displayed when the tree node is in a selected state.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), RelatedImageList("TreeView.ImageList"), SRDescription("TreeNodeImageKeyDescr"), Localizable(true), DefaultValue("")]
        public string SelectedImageKey
        {
            get
            {
                return this.GetValue<string>(TreeNode.SelectedImageKeyProperty);
            }
            set
            {
                if (this.SetValue<string>(TreeNode.SelectedImageKeyProperty, value))
                {
                    // Set the SelectedImageIndex Property to the default value
                    this.RemoveValue<int>(TreeNode.SelectedImageIndexProperty);

                    // Update the params
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>Gets or sets the key of the image displayed in the tree node when it is in a selected state.</summary>
        /// <returns>The key of the image displayed when the tree node is in a selected state.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), RelatedImageList("TreeView.StateImageList"), SRDescription("TreeNodeStateImageKeyDescr"), Localizable(true), DefaultValue("")]
        public string StateImageKey
        {
            get
            {
                return this.GetValue<string>(TreeNode.StateImageKeyProperty);
            }
            set
            {
                if (this.SetValue<string>(TreeNode.StateImageKeyProperty, value))
                {
                    // Set the StateImageIndex Property to the default value
                    this.RemoveValue<int>(TreeNode.StateImageIndexProperty);

                    // Update the node
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
        /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), RelatedImageList("TreeView.ImageList"), SRDescription("TreeNodeImageKeyDescr"), Localizable(true), DefaultValue("")]
        public string ImageKey
        {
            get
            {
                return this.GetValue<string>(TreeNode.ImageKeyProperty);
            }
            set
            {
                if (this.SetValue<string>(TreeNode.ImageKeyProperty, value))
                {
                    // Set the ImageKey Property to the default value
                    this.RemoveValue<int>(TreeNode.ImageIndexProperty);

                    // Update the control.
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>Gets the parent tree view that the tree node is assigned to.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> that represents the parent tree view that the tree node is assigned to, or null if the node has not been assigned to a tree view.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public TreeView TreeView
        {
            get
            {
                return GetAncestorByType(typeof(TreeView)) as TreeView;
            }
        }

        /// <summary>Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> objects assigned to the current tree node.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeCollection"></see> that represents the tree nodes assigned to the current tree node.</returns>
        /// <filterpriority>1</filterpriority>
        [ListBindable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        public TreeNodeCollection Nodes
        {
            get
            {
                return mobjNodes;
            }
        }

        /// <summary>Gets a value indicating whether the tree node is in the expanded state.</summary>
        /// <returns>true if the tree node is in the expanded state; otherwise, false.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsExpanded
        {
            get
            {
                return this.GetValue<bool>(TreeNode.IsExpandedProperty);
            }
            set
            {
                if (this.IsExpanded != value)
                {
                    if (value)
                    {
                        this.Expand();
                    }
                    else
                    {
                        this.Collapse(true);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TreeNode"/> is selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        internal bool Selected
        {
            get
            {
                return this.GetState(ComponentState.Selected);
            }
            set
            {
                SetSelected(value, true);
            }
        }

        /// <summary>
        /// Sets the selected.
        /// </summary>
        /// <param name="blnSelected">if set to <c>true</c> node is selected.</param>
        /// <param name="blnUpdate">if set to <c>true</c> update.</param>
        internal void SetSelected(bool blnSelected, bool blnUpdate)
        {
            // Set the selected value 
            this.SetState(ComponentState.Selected, blnSelected);

            // If should update node
            if (blnUpdate)
            {
                this.Update();
            }

            // If is selected
            if (blnSelected)
            {
                this.EnsureVisiblePath();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TreeNode"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [System.ComponentModel.DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return this.GetState(ComponentState.Checked);
            }
            set
            {
                ChangeCheckState(value, TreeViewAction.Unknown);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TreeNode"/> is loaded.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if loaded; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public bool Loaded
        {
            get
            {
                return this.GetState(ComponentState.Loaded);
            }
            set
            {
                this.SetState(ComponentState.Loaded, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has nodes.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has nodes; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public bool HasNodes
        {
            get
            {
                return this.GetValue<bool>(TreeNode.HasNodesProperty);
            }
            set
            {
                this.SetValue<bool>(TreeNode.HasNodesProperty, value);
            }
        }

        /// <summary>
        /// The tree node name
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get
            {
                return this.GetValue<string>(TreeNode.NameProperty);
            }
            set
            {
                this.SetValue<string>(TreeNode.NameProperty, value);
            }
        }

        /// <summary>
        /// The tree node label
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
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

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value></value>
        [Localizable(true), System.ComponentModel.DefaultValue("")]
        public string Text
        {
            get
            {
                return this.TextInternal;
            }
            set
            {
                if (this.TextInternal != value)
                {
                    this.TextInternal = value;

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text internal.
        /// </summary>
        /// <value>The text internal.</value>
        private string TextInternal
        {
            get
            {
                return this.GetValue<string>(TreeNode.LabelProperty);
            }
            set
            {
                this.SetValue<string>(TreeNode.LabelProperty, value);
            }
        }

        /// <summary>
        /// The tree node icon
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), Browsable(false)]
        public ResourceHandle Image
        {
            get
            {
                return this.GetImage(TreeNode.ImageProperty, ImageList, this.ImageIndex, this.ImageKey, (TreeView != null ? TreeView.ImageIndex : -1), (TreeView != null ? TreeView.ImageKey : string.Empty));
            }
            set
            {
                if (this.SetImage(TreeNode.ImageProperty, value, ImageList))
                {
                    bool blnFoundNodeWithImage = false;

                    //Check if we have a parent node
                    if (this.InternalParent != null)
                    {
                        //get all of the current node Siblings
                        TreeNodeCollection objSiblings = GetTreeNodesFromComponent(this.InternalParent);
                        if (objSiblings != null)
                        {
                            //Run over all of the nodes that are siblings to the current node 
                            //include the current node
                            foreach (TreeNode objSibling in objSiblings)
                            {
                                //if one of the siblings
                                if (objSibling != this)
                                {
                                    //Check if one of the siblings has alredy an image
                                    if (objSibling.Image != null)
                                    {
                                        blnFoundNodeWithImage = true;
                                        break;
                                    }
                                }
                            }

                            //If one of the siblings alredy has an image we don't have to update the parent
                            if (!blnFoundNodeWithImage)
                            {
                                this.InternalParent.Update();
                            }
                        }
                    }
                    if (blnFoundNodeWithImage)
                    {
                        this.UpdateParams(AttributeType.Visual);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the tree nodes from component.
        /// </summary>
        /// <param name="objComponent">The component.</param>
        /// <returns></returns>
        private TreeNodeCollection GetTreeNodesFromComponent(Component objComponent)
        {
            TreeView objTreeView = objComponent as TreeView;

            //If the current node is the root node
            if (objTreeView != null)
            {
                return objTreeView.Nodes;
            }
            else
            {
                TreeNode objTreeNode = objComponent as TreeNode;
                if (objTreeNode != null)
                {
                    return objTreeNode.Nodes;
                }
            }
            return null;
        }

        /// <summary>
        /// Shoulds the serialize image.
        /// </summary>
        /// <returns></returns>
        protected bool ShouldSerializeImage()
        {
            if (this.TreeView != null && this.TreeView.ImageList != null)
            {
                return false;
            }
            else
            {
                return (this.Image != null);
            }
        }

        /// <summary>
        /// Gets the image list.
        /// </summary>
        /// <value>The image list.</value>
        private ImageList ImageList
        {
            get
            {
                // If there is a valid list view owner for this list item
                if (this.TreeView != null)
                {
                    return this.TreeView.ImageList;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the image list.
        /// </summary>
        /// <value>The image list.</value>
        private ImageList StateImageList
        {
            get
            {
                // If there is a valid list view owner for this list item
                if (this.TreeView != null)
                {
                    return this.TreeView.StateImageList;
                }
                return null;
            }
        }

        /// <summary>
        /// The selected tree node icon
        /// </summary>
        [DefaultValue((string)null), Browsable(false), DesignerSerializationVisibility(0)]
        public ResourceHandle SelectedImage
        {
            get
            {
                return this.GetImage(TreeNode.SelectedImageProperty, ImageList, this.SelectedImageIndex, this.SelectedImageKey, (TreeView != null ? TreeView.SelectedImageIndex : -1), (TreeView != null ? TreeView.SelectedImageKey : string.Empty));
            }
            set
            {
                // If value has changed.
                if (this.SetImage(TreeNode.SelectedImageProperty, value, ImageList))
                {
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// The selected tree node icon
        /// </summary>
        [DefaultValue((string)null), Browsable(false), DesignerSerializationVisibility(0)]
        public ResourceHandle StateImage
        {
            get
            {
                return this.GetImage(TreeNode.StateImageProperty, this.StateImageList, this.StateImageIndex, this.StateImageKey, -1, string.Empty);
            }
            set
            {
                this.SetImage(TreeNode.StateImageProperty, value, this.StateImageList);
            }
        }

        /// <summary>
        /// The expanded tree node icon
        /// </summary>
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public ResourceHandle ExpandedImage
        {
            get
            {
                return this.GetImage(TreeNode.ExpandedImageProperty, ImageList, this.ExpandedImageIndex, this.ExpandedImageKey, (TreeView != null ? TreeView.ExpandedImageIndex : -1), (TreeView != null ? TreeView.ExpandedImageKey : string.Empty));
            }
            set
            {
                // If value has changed.
                if (this.SetImage(TreeNode.ExpandedImageProperty, value, ImageList))
                {
                    this.UpdateParams(AttributeType.Visual);
                }

            }
        }

        /// <summary>
        /// Gets or sets the expanded image index.
        /// </summary>
        /// <value></value>
        [SRCategory("CatBehavior"), System.ComponentModel.DefaultValue(-1)]
        public int ExpandedImageIndex
        {
            get
            {
                return this.GetValue<int>(TreeNode.ExpandedImageIndexProperty);
            }
            set
            {
                if (this.SetValue<int>(TreeNode.ExpandedImageIndexProperty, value))
                {
                    // Set the ExpandedImageKeyProperty property to the default value
                    this.RemoveValue<string>(TreeNode.ExpandedImageKeyProperty);

                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>Gets or sets the key of the image displayed in the tree node when it is Expanded.</summary>
        /// <returns>The key of the image displayed when the tree node is Expanded.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), RelatedImageList("TreeView.ImageList"), SRDescription("TreeNodeImageKeyDescr"), Localizable(true), DefaultValue("")]
        public string ExpandedImageKey
        {
            get
            {
                return this.GetValue<string>(TreeNode.ExpandedImageKeyProperty);
            }
            set
            {
                if (this.SetValue<string>(TreeNode.ExpandedImageKeyProperty, value))
                {
                    // Set the ExpandedImageIndex property to the default value
                    this.RemoveValue<int>(TreeNode.ExpandedImageIndexProperty);

                    // Update node
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>Gets the bounds of the tree node.</summary>
        /// <returns>The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds of the tree node.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Rectangle Bounds
        {
            get
            {
                return Rectangle.Empty;
            }
        }




        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="objComponent">The component.</param>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            return this.Nodes;
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string strText = this.Text;

            return string.Format("TreeNode: {0}", string.IsNullOrEmpty(strText) ? string.Empty : strText);
        }

        /// <summary>Toggles the tree node to either the expanded or collapsed state.</summary>
        public void Toggle()
        {
            if (this.IsExpanded)
            {
                this.Collapse();
            }
            else
            {
                this.Expand();
            }
        }

        /// <summary>Removes the current tree node from the tree view control.</summary>
        public void Remove()
        {
            TreeNodeCollection objParentNodes = this.ParentNodes;
            if (objParentNodes != null)
            {
                objParentNodes.Remove(this);
            }
        }

        /// <summary>Expands all the child tree nodes.</summary>
        public void ExpandAll()
        {
            this.Expand();
            foreach (TreeNode objChildNode in this.Nodes)
            {
                objChildNode.ExpandAll();
            }
        }

        /// <summary>
        /// Adds a child object.
        /// </summary>
        /// <param name="objValue">The child object to add.</param>
        protected override void AddChild(object objValue)
        {
            // If value is a tree node
            if (objValue is TreeNode)
            {
                this.Nodes.Add((TreeNode)objValue);
            }
            else
            {
                base.AddChild(objValue);
            }
        }

        /// <summary>Expands the tree node.</summary>
        public void Expand()
        {
            if (!this.IsExpanded)
            {
                // If the before select did not cancel the selection
                if (!this.OnBeforeExpand())
                {
                    this.SetValue<bool>(TreeNode.IsExpandedProperty, true);
                    this.Update();
                    this.OnAfterExpand();
                }
            }
        }

        /// <summary>Initiates the editing of the tree node label.</summary>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.TreeView.LabelEdit"></see> is set to false. </exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void BeginEdit()
        {
            if (this.TreeView != null && this.TreeView.LabelEdit)
            {
                this.TreeView.EditNode = this;
                this.InvokeMethodWithId("LabelEditor_Show");
            }
        }

        /// <summary>Ends the editing of the tree node label.</summary>
        /// <param name="blnCancel">true if the editing of the tree node label text was canceled without being saved; otherwise, false. </param>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void EndEdit(bool blnCancel)
        {
        }

        /// <summary>Ensures that the tree node is visible, expanding tree nodes and scrolling the tree view control as necessary.</summary>
        public void EnsureVisible()
        {
            EnsureVisiblePath();
            this.InvokeMethodWithId("Controls_ScrollIntoView", null, 0);
        }

        /// <summary>
        /// Ensures that the tree path is visible
        /// </summary>
        private void EnsureVisiblePath()
        {
            if (this.Parent != null)
            {
                if (!this.Parent.IsExpanded)
                {
                    this.Parent.Expand();
                }
                this.Parent.EnsureVisiblePath();
            }
        }

        /// <summary>Collapses the tree node.</summary>
        public void Collapse()
        {
            this.Collapse(false);
        }

        /// <summary>Collapses the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> and optionally collapses its children.</summary>
        /// <param name="blnIgnoreChildren">true to leave the child nodes in their current state; false to collapse the child nodes.</param>
        public void Collapse(bool blnIgnoreChildren)
        {
            if (this.IsExpanded)
            {

                if (!OnBeforeCollapse())
                {
                    this.SetValue<bool>(TreeNode.IsExpandedProperty, false);
                    this.Update();
                    OnAfterCollapse();
                }
            }

            if (!blnIgnoreChildren)
            {
                foreach (TreeNode objChildNode in this.Nodes)
                {
                    objChildNode.Collapse(false);
                }
            }
        }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <param name="objPath">Path builder.</param>
        /// <param name="strPathSeparator">Path separator.</param>
        private void GetFullPath(StringBuilder objPath, string strPathSeparator)
        {
            if (this.Parent != null)
            {
                this.Parent.GetFullPath(objPath, strPathSeparator);
                objPath.Append(strPathSeparator);
            }
            objPath.Append(this.Text);

        }

        /// <summary>
        /// Returns the number of child tree nodes.
        /// </summary>
        /// <param name="blnIncludeSubTrees">true if the resulting count includes all tree nodes indirectly rooted at this tree node; otherwise, false . </param>
        /// <returns></returns>
        public int GetNodeCount(bool blnIncludeSubTrees)
        {
            TreeNodeCollection objNodes = this.Nodes;
            int intCount = objNodes.Count;

            if (blnIncludeSubTrees)
            {
                if (objNodes != null)
                {
                    foreach (TreeNode objChildNode in objNodes)
                    {
                        intCount += objChildNode.GetNodeCount(true);
                    }
                }
            }
            return intCount;
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            TreeNodeCollection objNodes = this.Nodes;
            if (objNodes != null)
            {
                // register sub children
                foreach (IRegisteredComponent objRegisteredComponent in objNodes)
                {
                    objRegisteredComponent.RegisterComponents();
                }
                // register children
                RegisterBatch(objNodes);
            }
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            TreeNodeCollection objNodes = this.Nodes;
            if (objNodes != null)
            {
                // Unregister sub children
                foreach (IRegisteredComponent objRegisteredComponent in objNodes)
                {
                    objRegisteredComponent.UnregisterComponents();
                }
                // Unregister children
                UnRegisterBatch(objNodes);
            }
        }

        /// <summary>
        /// Change check state
        /// </summary>
        /// <param name="blnValue">the new check value</param>
        /// <param name="enmTreeViewAction">treeview action</param>
        private void ChangeCheckState(bool blnValue, TreeViewAction enmTreeViewAction)
        {
            // Check if not canceled and raise before check
            if (!this.OnBeforeCheck(enmTreeViewAction))
            {
                // Check if the action source is mouse
                if (enmTreeViewAction == TreeViewAction.ByMouse)
                {
                    // Set check value
                    this.SetState(ComponentState.Checked, blnValue);
                }
                else
                {
                    // Set the checked value and update control if value had changed
                    if (this.SetStateWithCheck(ComponentState.Checked, blnValue))
                    {
                        this.Update();
                    }
                }

                // Raise after check
                this.OnAfterCheck();
            }
            else
            {
                // Check if the action source is mouse
                if (enmTreeViewAction == TreeViewAction.ByMouse)
                {
                    // Update the current node
                    this.Update();
                }
            }
        }

        /// <summary>Copies the tree node and the entire subtree rooted at this tree node.</summary>
        /// <returns>The <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public virtual object Clone()
        {

            Type type = base.GetType();
            TreeNode objTreeNode = null;
            if (type == typeof(TreeNode))
            {
                //Creates an instance
                objTreeNode = new TreeNode(this.Text, this.ImageIndex, this.SelectedImageIndex);
            }
            else
            {
                //Creates an instance of the specified type using that type's default constructor.
                objTreeNode = (TreeNode)Activator.CreateInstance(type);

                objTreeNode.Text = this.Text;
                objTreeNode.ImageIndex = this.ImageIndex;
                objTreeNode.SelectedImageIndex = this.SelectedImageIndex;
            }

            //Copy the properties
            objTreeNode.Name = this.Name;
            objTreeNode.StateImageIndex = this.StateImageIndex;
            objTreeNode.ToolTipText = this.ToolTipText;
            objTreeNode.ContextMenu = this.ContextMenu;
            objTreeNode.ContextMenuStrip = this.ContextMenuStrip;
            objTreeNode.DragTargets = this.DragTargets;
            objTreeNode.AllowDrop = this.AllowDrop;
            objTreeNode.Animation = this.Animation;

            string strImageKey = this.ImageKey;
            if (!string.IsNullOrEmpty(strImageKey))
            {
                objTreeNode.ImageKey = strImageKey;
            }

            string strSelectedImageKey = this.SelectedImageKey;
            if (!string.IsNullOrEmpty(strSelectedImageKey))
            {
                objTreeNode.SelectedImageKey = strSelectedImageKey;
            }

            string strStateImageKey = this.StateImageKey;
            if (!string.IsNullOrEmpty(strStateImageKey))
            {
                objTreeNode.StateImageKey = strStateImageKey;
            }

            //Get tree node child number
            int intNodeCount = this.GetNodeCount(false);

            //Check if the tree node has child nodes
            if (intNodeCount > 0)
            {
                foreach (TreeNode objChildNode in this.Nodes)
                {
                    objChildNode.ExpandAll();
                }

                //Copy the child nodes
                for (int i = 0; i < intNodeCount; i++)
                {
                    objTreeNode.Nodes.Add((TreeNode)this.Nodes[i].Clone());
                }
            }
            objTreeNode.Checked = this.Checked;
            objTreeNode.Tag = this.Tag;
            return objTreeNode;

        }

        /// <summary>
        /// Registers the self node.
        /// </summary>
        internal void RegisterSelfNode()
        {
            this.RegisterSelf();
        }

        /// <summary>
        /// Uns the register self node.
        /// </summary>
        internal void UnRegisterSelfNode()
        {
            this.UnRegisterSelf();
        }

        #endregion Methods
    }

    #endregion TreeNode Class

    #region TreeNodeCollection

    /// <summary>
    /// Collection of tree view nodes
    /// </summary>
    [Browsable(true)]
    [Serializable()]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public class TreeNodeCollection : BaseCollection, IList, IObservableList
    {
        #region Class Members

        private Component mobjParent = null;

        private ArrayList mobjTreeNodes = null;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        /// Creates a new <see cref="TreeNodeCollection"/> instance.
        /// </summary>
        /// <param name="objParent">Obj parent.</param>
        public TreeNodeCollection(Component objParent)
        {
            mobjParent = objParent;
            mobjTreeNodes = new ArrayList();
        }

        // <summary>
        /// Creates a new <see cref="TreeNodeCollection"/> instance.
        /// </summary>
        /// <param name="objParent">Obj parent.</param>
        protected internal TreeNodeCollection(Component objParent, object[] arrNodes)
        {
            mobjParent = objParent;
            mobjTreeNodes = new ArrayList(arrNodes);
        }

        #endregion C'Tor / D'Tor

        #region Methods

        /// <summary>
        /// Adds the specified tree view node.
        /// </summary>
        /// <param name="objTreeViewNode">Obj tree view node.</param>
        /// <returns></returns>
        public int Add(TreeNode objTreeViewNode)
        {
            // set the control parent
            objTreeViewNode.InternalParent = mobjParent;

            // update parent render state
            if (this.mobjParent != null)
            {
                this.mobjParent.Update();
            }

            // Register self.
            objTreeViewNode.RegisterSelfNode();

            // Added index
            int intIndex = 0;

            // Get tree node
            TreeView objTreeView = this.TreeView;

            // If tree node found and sorted is true
            if ((objTreeView != null) && objTreeView.Sorted)
            {
                // Add to sorted index
                intIndex = this.AddSorted(objTreeViewNode, objTreeView);
            }
            else
            {
                intIndex = List.Add(objTreeViewNode);
            }


            // Raise item added to list observer
            if (ObservableItemAdded != null)
            {
                ObservableItemAdded(this, new ObservableListEventArgs(objTreeViewNode));
            }

            // Change parent tree node to has nodes
            TreeNode objParentTreeNode = this.mobjParent as TreeNode;
            if (objParentTreeNode != null)
            {
                objParentTreeNode.HasNodes = true;
            }

            // Return add index
            return intIndex;

        }

        /// <summary>
        /// Adds a new tree node to the end of the current tree node collection with the specified label text.
        /// </summary>
        /// <param name="strText">The label text displayed by the TreeNode .</param>
        /// <returns>A TreeNode that represents the tree node being added to the collection.</returns>
        public virtual TreeNode Add(string strText)
        {
            TreeNode objNode = new TreeNode(strText);
            this.Add(objNode);
            return objNode;
        }

        /// <summary>
        /// Creates a new tree node with the specified key and text, and adds it to the collection.
        /// </summary>
        /// <param name="strKey">The name of the tree node.</param>
        /// <param name="strText">The text to display in the tree node.</param>
        /// <returns>The TreeNode that was added to the collection.</returns>
        public TreeNode Add(string strKey, string strText)
        {
            TreeNode objNode = this.Add(strText);
            objNode.Name = strKey;
            return objNode;
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
            TreeNode objNode = this.Add(strKey, strText);
            objNode.ImageIndex = intImageIndex;
            return objNode;
        }

        /// <summary>
        /// Creates a tree node with the specified key, text, and image, and adds it to the collection.
        /// </summary>
        /// <param name="strKey">The name of the tree node.</param>
        /// <param name="strText">The text to display in the tree node.</param>
        /// <param name="strImageKey">The image to display in the tree node.</param>
        /// <returns>The TreeNode that was added to the collection.</returns>
        public TreeNode Add(string strKey, string strText, string strImageKey)
        {
            return this.Add(strKey, strText);
        }

        /// <summary>
        /// Creates a tree node with the specified key, text, and images, and adds it to the collection
        /// </summary>
        /// <param name="strKey">The name of the tree node.</param>
        /// <param name="strText">The text to display in the tree node.</param>
        /// <param name="intImageIndex">The index of the image to display in the tree node.</param>
        /// <param name="intSelectedImageIndex">The index of the image to be displayed in the tree node when it is in a selected state.</param>
        /// <returns>The TreeNode that was added to the collection.</returns>
        public TreeNode Add(string strKey, string strText, int intImageIndex, int intSelectedImageIndex)
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
        public TreeNode Add(string strKey, string strText, string strImageKey, string strIntSelectedImageIndex)
        {
            return this.Add(strKey, strText);
        }

        /// <summary>
        /// Add node in its sorted index
        /// </summary>
        /// <param name="objTreeNode">The obj tree node.</param>
        /// <param name="objTreeView">The obj tree view.</param>
        /// <returns></returns>
        internal int AddSorted(TreeNode objTreeNode, TreeView objTreeView)
        {
            // Adding index
            int intIndex = 0;

            // Get current node text
            string strNodeText = objTreeNode.Text;

            // If there are other nodes
            if (this.Count > 0)
            {
                // The current child count
                int intChildCount;

                // Auxilury indexes
                int intTempIndex1;
                int intTempIndex2;

                // If there is not internal tree node sorter
                if (objTreeView.TreeViewNodeSorter == null)
                {
                    // Get context compare info
                    CompareInfo objCompareInfo = VWGContext.Current.CurrentUICulture.CompareInfo;

                    // If is sorted last
                    if (objCompareInfo.Compare(this[this.Count - 1].Text, strNodeText) <= 0)
                    {
                        // Set last item as index
                        intIndex = this.Count;
                    }
                    else
                    {
                        // Initialize current index
                        intTempIndex1 = 0;

                        // Set current child count
                        intChildCount = this.Count;

                        // Loop until last child
                        while (intTempIndex1 < intChildCount)
                        {
                            // Get center index
                            intTempIndex2 = (intTempIndex1 + intChildCount) / 2;

                            // Compare to center index
                            if (objCompareInfo.Compare(this[intTempIndex2].Text, strNodeText) <= 0)
                            {
                                // Set center index plus one
                                intTempIndex1 = intTempIndex2 + 1;
                            }
                            else
                            {
                                // Set current center index as total child count
                                intChildCount = intTempIndex2;
                            }
                        }

                        // Set current index
                        intIndex = intTempIndex1;
                    }
                }
                else
                {
                    // Get node sorted
                    IComparer treeViewNodeSorter = objTreeView.TreeViewNodeSorter;

                    // Set initial index
                    intTempIndex1 = 0;

                    // Set initial total node count
                    intChildCount = this.Count;

                    // Loop until passed child count
                    while (intTempIndex1 < intChildCount)
                    {
                        // Get center index
                        intTempIndex2 = (intTempIndex1 + intChildCount) / 2;

                        // Compare to center index
                        if (treeViewNodeSorter.Compare(this[intTempIndex2], objTreeNode) <= 0)
                        {
                            // Set center index plus one
                            intTempIndex1 = intTempIndex2 + 1;
                        }
                        else
                        {
                            // Set current center index as total child count
                            intChildCount = intTempIndex2;
                        }
                    }
                    // Set current index
                    intIndex = intTempIndex1;
                }
            }

            // Sort sub child nodes
            objTreeNode.Nodes.SortChildren(objTreeView);

            // Add to designetad index
            this.List.Insert(intIndex, objTreeNode);

            // Return index
            return intIndex;
        }

        /// <summary>
        /// Sorts current node children
        /// </summary>
        /// <param name="objParentTreeView">The current owner treeview</param>
        private void SortChildren(TreeView objParentTreeView)
        {
            // If there are child nodes
            if (this.Count > 0)
            {
                // Create node array
                TreeNode[] arrNodeArray = new TreeNode[this.Count];

                // If not valid treeview or node sorter
                if ((objParentTreeView == null) || (objParentTreeView.TreeViewNodeSorter == null))
                {
                    // Get current compare info
                    CompareInfo compareInfo = VWGContext.Current.CurrentUICulture.CompareInfo;
                    for (int intIndex = 0; intIndex < this.Count; intIndex++)
                    {
                        int intIndex2 = -1;
                        for (int intIndex3 = 0; intIndex3 < this.Count; intIndex3++)
                        {
                            if (this[intIndex3] != null)
                            {
                                if (intIndex2 == -1)
                                {
                                    intIndex2 = intIndex3;
                                }
                                else if (compareInfo.Compare(((TreeNode)this.List[intIndex3]).Text, ((TreeNode)this.List[intIndex2]).Text) <= 0)
                                {
                                    intIndex2 = intIndex3;
                                }
                            }
                        }
                        arrNodeArray[intIndex] = ((TreeNode)this.List[intIndex2]);
                        this.List[intIndex2] = null;
                        arrNodeArray[intIndex].Nodes.SortChildren(objParentTreeView);
                    }
                }
                else
                {
                    IComparer treeViewNodeSorter = objParentTreeView.TreeViewNodeSorter;
                    for (int intIndex4 = 0; intIndex4 < this.Count; intIndex4++)
                    {
                        int intIndex5 = -1;
                        for (int intIndex6 = 0; intIndex6 < this.Count; intIndex6++)
                        {
                            if (this.List[intIndex6] != null)
                            {
                                if (intIndex5 == -1)
                                {
                                    intIndex5 = intIndex6;
                                }
                                else if (treeViewNodeSorter.Compare(((TreeNode)this.List[intIndex6]), ((TreeNode)this.List[intIndex5])) <= 0)
                                {
                                    intIndex5 = intIndex6;
                                }
                            }
                        }
                        arrNodeArray[intIndex4] = ((TreeNode)this.List[intIndex5]);
                        this.List[intIndex5] = null;
                        arrNodeArray[intIndex4].Nodes.SortChildren(objParentTreeView);
                    }
                }

                // Clear nodes
                this.List.Clear();

                // Add sorted nodes 
                this.List.AddRange(arrNodeArray);
            }
        }

        /// <summary>
        /// Returns the owner treeview
        /// </summary>
        private TreeView TreeView
        {
            get
            {
                TreeView objTreeView = mobjParent as TreeView;
                if (objTreeView == null)
                {
                    TreeNode objTreeNode = mobjParent as TreeNode;
                    if (objTreeNode != null)
                    {
                        objTreeView = objTreeNode.TreeView;
                    }
                }
                return objTreeView;
            }
        }

        /// <summary>
        /// Clear the node collection 
        /// </summary>
        public void Clear()
        {
            ((IRegisteredComponent)this.mobjParent).UnregisterComponents();

            this.List.Clear();

            // update parent render state
            if (this.mobjParent != null)
            {
                this.mobjParent.Update();
            }

            TreeNode objParentTreeNode = this.mobjParent as TreeNode;
            if (objParentTreeNode != null)
            {
                objParentTreeNode.HasNodes = false;
            }

            if (ObservableListCleared != null)
            {
                ObservableListCleared(this, EventArgs.Empty);
            }
        }

        /// <summary>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="objArray"></param>
        /// <param name="intIndex"></param>
        new public void CopyTo(Array objArray, int intIndex)
        {
            List.CopyTo(objArray, intIndex);
        }

        /// <summary>
        /// Removes the specified tree view node.
        /// </summary>
        /// <param name="objTreeViewNode">Obj tree view node.</param>
        public void Remove(TreeNode objTreeViewNode)
        {
            // remove parent if needed
            if (objTreeViewNode.InternalParent == mobjParent)
            {
                objTreeViewNode.InternalParent = null;
            }

            // Remove item
            this.RemoveAt(List.IndexOf(objTreeViewNode));

            // If is empty collection
            if (List.Count == 0)
            {
                TreeNode objParentTreeNode = this.mobjParent as TreeNode;
                if (objParentTreeNode != null)
                {
                    objParentTreeNode.HasNodes = false;
                }
            }

            // update parent render state
            if (this.mobjParent != null)
            {
                this.mobjParent.Update();
            }

            if (ObservableItemRemoved != null)
            {
                ObservableItemRemoved(this, new ObservableListEventArgs(objTreeViewNode));
            }
        }

        /// <summary>
        /// Removes the current tree node from the tree view control at a specified index.
        /// </summary>
        /// <param name="intIndex"></param>
        public void RemoveAt(int intIndex)
        {
            if (this.IsValidIndex(intIndex))
            {
                TreeNode objTreeNode = List[intIndex] as TreeNode;
                if (objTreeNode != null)
                {
                    objTreeNode.UnRegisterSelfNode();
                }

                List.RemoveAt(intIndex);
            }
        }

        /// <summary>
        /// Returns the index of the first occurrence of a tree node.
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public int IndexOf(TreeNode objNode)
        {
            if (objNode != null)
            {
                return List.IndexOf(objNode);
            }
            return -1;
        }

        /// <summary>
        /// Returns the index of the first occurrence of a tree node with the specified key.
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public int IndexOfKey(string strKey)
        {
            if (!string.IsNullOrEmpty(strKey))
            {
                foreach (TreeNode objTreeNode in List)
                {
                    if (objTreeNode.Name == strKey)
                    {
                        return List.IndexOf(objTreeNode);
                    }
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
            int intIndex = IndexOfKey(strKey);
            if (this.IsValidIndex(intIndex))
            {
                this.RemoveAt(intIndex);
            }
        }

        /// <summary>
        /// Determines whether the collection contains a tree node with the specified key.
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public bool ContainsKey(string strKey)
        {
            return this.IsValidIndex(this.IndexOfKey(strKey));
        }

        /// <summary>
        /// Determines whether [contains] [the specified obj tree node].
        /// </summary>
        /// <param name="objTreeNode">The obj tree node.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified obj tree node]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(TreeNode objTreeNode)
        {
            return (this.List.IndexOf(objTreeNode) != -1);
        }

        /// <summary>
        /// Determines if Index is valid
        /// </summary>
        /// <param name="intIndex"></param>
        /// <returns></returns>
        private bool IsValidIndex(int intIndex)
        {
            return ((List != null) && (intIndex >= 0) && (intIndex < List.Count));
        }

        /// <summary>
        /// Insert the specified tree view node.
        /// </summary>
        /// <param name="intIndex"></param>
        /// <param name="objTreeViewNode"></param>
        public void Insert(int intIndex, TreeNode objTreeViewNode)
        {
            if (this.IsValidIndex(intIndex))
            {
                // Set the control parent
                objTreeViewNode.InternalParent = mobjParent;

                // Insert item 
                List.Insert(intIndex, objTreeViewNode);

                // Register self.
                objTreeViewNode.RegisterSelfNode();

                // update parent render state
                if (this.mobjParent != null)
                {
                    this.mobjParent.Update();
                }
            }
        }

        /// <summary>
        /// Finds the tree nodes with specified key, optionally searching subnodes.
        /// </summary>
        /// <param name="strKey">The name of the tree node to search for.</param>
        /// <param name="blnSearchAllChildren">if set to <c>true</c> [search child nodes of tree nodes].</param>
        /// <returns>An array of TreeNode objects whose TreeNode.Name property matches the specified key.</returns>
        public TreeNode[] Find(string strKey, bool blnSearchAllChildren)
        {
            ArrayList objList = this.FindInternal(strKey, blnSearchAllChildren, this, new ArrayList());
            TreeNode[] arrNodeArray = new TreeNode[objList.Count];

            objList.CopyTo(arrNodeArray, 0);

            return arrNodeArray;
        }

        /// <summary>
        /// Finds the tree nodes with specified key, optionally searching subnodes.
        /// </summary>
        /// <param name="strKey">The name of the tree node to search for.</param>
        /// <param name="blnSearchAllChildren">if set to <c>true</c> [search child nodes of tree nodes].</param>
        /// <param name="objTreeNodeCollectionToLookIn">The collection of nodes to search within</param>
        /// <param name="objFoundTreeNodes">The collection of nodes that was already found</param>
        /// <returns>An array of TreeNode objects whose TreeNode.Name property matches the specified key.</returns>
        private ArrayList FindInternal(string strKey, bool blnSearchAllChildren, TreeNodeCollection objTreeNodeCollectionToLookIn, ArrayList objFoundTreeNodes)
        {
            if ((objTreeNodeCollectionToLookIn == null) || (objFoundTreeNodes == null))
            {
                return null;
            }

            for (int i = 0; i < objTreeNodeCollectionToLookIn.Count; i++)
            {
                if ((objTreeNodeCollectionToLookIn[i] != null) && ClientUtils.SafeCompareStrings(objTreeNodeCollectionToLookIn[i].Name, strKey, true))
                {
                    objFoundTreeNodes.Add(objTreeNodeCollectionToLookIn[i]);
                }
            }

            if (blnSearchAllChildren)
            {
                for (int j = 0; j < objTreeNodeCollectionToLookIn.Count; j++)
                {
                    if (((objTreeNodeCollectionToLookIn[j] != null) && (objTreeNodeCollectionToLookIn[j].Nodes != null)) && (objTreeNodeCollectionToLookIn[j].Nodes.Count > 0))
                    {
                        objFoundTreeNodes = this.FindInternal(strKey, blnSearchAllChildren, objTreeNodeCollectionToLookIn[j].Nodes, objFoundTreeNodes);
                    }
                }
            }
            return objFoundTreeNodes;
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> at the specified indexed location in the collection.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> at the specified indexed location in the collection.</returns>
        /// <param name="intIndex">The indexed location of the <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> in the collection. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than 0 or is greater than the number of tree nodes in the collection. </exception>
        /// <filterpriority>1</filterpriority>
        public TreeNode this[int intIndex]
        {
            get
            {
                return (TreeNode)List[intIndex];
            }
            set
            {
                //If the index is invalid
                if ((intIndex < 0) || (intIndex >= List.Count))
                {
                    throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", intIndex.ToString(CultureInfo.CurrentCulture) }));
                }
                value.InternalParent = this.mobjParent;

                //Insert the new value(node) to the TreeView , in the intIndex position
                value.Index = intIndex;

                //Set the new value
                List[intIndex] = value;

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
                    int index = this.IndexOfKey(strKey);
                    if (this.IsValidIndex(index))
                    {
                        return this[index];
                    }
                }
                return null;

            }
        }

        /// <summary>
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

        /// <summary>
        /// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
        /// </summary>
        /// <value></value>
        /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
        protected override ArrayList List
        {
            get
            {
                return this.mobjTreeNodes;
            }
        }

        #endregion Properties

        #region IList Members

        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

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

        void IList.Remove(object objValue)
        {
            this.Remove((TreeNode)objValue);
        }

        bool IList.Contains(object objValue)
        {
            return this.List.Contains((TreeNode)objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.List.IndexOf(objValue);
        }

        int IList.Add(object objValue)
        {
            return this.Add(((TreeNode)objValue));
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        void IList.Insert(int intIndex, object objNode)
        {
            if (!(objNode is TreeNode))
            {
                throw new ArgumentException("node");
            }
            this.Insert(intIndex, (TreeNode)objNode);
        }

        void IList.RemoveAt(int intIndex)
        {
            this.RemoveAt(intIndex);
        }

        #endregion

        #region IObservableList Members

        /// <summary>
        /// Occurs when [observable item inserted].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemInserted;

        /// <summary>
        /// Occurs when [observable item added].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemAdded;

        /// <summary>
        /// Occurs when [observable list cleared].
        /// </summary>
        public event System.EventHandler ObservableListCleared;

        /// <summary>
        /// Occurs when [observable item removed].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemRemoved;

        #endregion
    }

    #endregion TreeNodeCollection

    #region EventArgs Classes

    #region NodeLabelEditEventArgs

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class NodeLabelEditEventArgs : EventArgs
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objTreeNode"></param>
        public NodeLabelEditEventArgs(TreeNode objTreeNode)
        {
            this.mblnCancelEdit = false;
            this.mobjTreeNode = objTreeNode;
            this.mstrLabel = null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objTreeNode"></param>
        /// <param name="strLabel"></param>
        public NodeLabelEditEventArgs(TreeNode objTreeNode, string strLabel)
        {
            this.mblnCancelEdit = false;
            this.mobjTreeNode = objTreeNode;
            this.mstrLabel = strLabel;
        }


        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public bool CancelEdit
        {
            get
            {
                return this.mblnCancelEdit;
            }
            set
            {
                this.mblnCancelEdit = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public string Label
        {
            get
            {
                return this.mstrLabel;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public TreeNode Node
        {
            get
            {
                return this.mobjTreeNode;
            }
        }


        #endregion Properties

        #region Class Members

        private bool mblnCancelEdit;

        private readonly string mstrLabel;

        private readonly TreeNode mobjTreeNode;


        #endregion Class Members
    }

    /// <summary>
    ///     Identifies the method that will handle the <see cref="TreeView.AfterLabelEdit">AfterLabelEdit</see> event and the <see cref="TreeView.BeforeLabelEdit">BeforeLabelEdit</see> event
    ///     of a <see cref="TreeView">TreeView</see> control.
    /// </summary>
    public delegate void NodeLabelEditEventHandler(object sender, NodeLabelEditEventArgs e);

    #endregion NodeLabelEditEventArgs

    #region TreeViewEventArgs Class

    /// <summary>
    /// Specifies the action that raised a TreeViewEventArgs event.
    /// </summary>
    //[Serializable()]
    public enum TreeViewAction
    {
        // Fields
        /// <summary>
        /// The event was caused by a keystroke.
        /// </summary>
        ByKeyboard = 1,
        /// <summary>
        /// The event was caused by a mouse operation.
        /// </summary>
        ByMouse = 2,
        /// <summary>
        /// The event was caused by the TreeNode collapsing.
        /// </summary>
        Collapse = 3,
        /// <summary>
        /// The event was caused by the TreeNode expanding.
        /// </summary>
        Expand = 4,
        /// <summary>
        /// The action that caused the event is unknown.
        /// </summary>
        Unknown = 0
    }

    /// <summary>
    /// Represents the method that will handle the <see cref="TreeView.AfterCheck">AfterCheck</see>, <see cref="TreeView.AfterCollapse">AfterCollapse</see>, <see cref="TreeView.AfterExpand">AfterExpand</see>, or <see cref="TreeView.AfterSelect">AfterSelect</see> event of a <see cref="TreeView">TreeView</see>.
    /// </summary>
    public delegate void TreeViewEventHandler(object sender, TreeViewEventArgs e);

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class TreeViewEventArgs : EventArgs
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objTreeNode"></param>
        public TreeViewEventArgs(TreeNode objTreeNode)
            : this(objTreeNode, TreeViewAction.Unknown)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objTreeNode"></param>
        /// <param name="enmAction"></param>
        public TreeViewEventArgs(TreeNode objTreeNode, TreeViewAction enmAction)
        {
            this.menmAction = enmAction;
            this.mobjTreeNode = objTreeNode;
            this.menmAction = enmAction;
        }


        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public TreeViewAction Action
        {
            get
            {
                return this.menmAction;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public TreeNode Node
        {
            get
            {
                return this.mobjTreeNode;
            }
        }


        #endregion Properties

        #region Class Members

        private TreeViewAction menmAction;

        private TreeNode mobjTreeNode;


        #endregion Class Members
    }

    #endregion TreeViewEventArgs Class

    #region TreeViewCancelEventArgs Class

    /// <summary>
    /// Identifies the method that will handle the <see cref="TreeView.BeforeCollapse"> beforeCollapse</see>, the <see cref="TreeView.BeforeExpand"> beforeExpand</see>, and the <see cref="TreeView.BeforeSelect"> beforeSelect</see> events of a <see cref="TreeView"> TreeView</see> control.
    /// </summary>
    public delegate void TreeViewCancelEventHandler(object sender, TreeViewCancelEventArgs e);

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class TreeViewCancelEventArgs : CancelEventArgs
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        public TreeViewCancelEventArgs(TreeNode objTreeNode, bool blnCancel, TreeViewAction enmAction)
            : base(blnCancel)
        {
            this.mobjTreeNode = objTreeNode;
            this.menmAction = enmAction;
        }

        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public TreeViewAction Action
        {
            get
            {
                return this.menmAction;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public TreeNode Node
        {
            get
            {
                return this.mobjTreeNode;
            }
        }

        #endregion Properties

        #region Class Members

        private TreeViewAction menmAction;

        private TreeNode mobjTreeNode;

        #endregion Class Members
    }

    #endregion TreeViewCancelEventArgs Class

    #region TreeNodeMouseClickEventArgs Class

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> and <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> events of a <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void TreeNodeMouseClickEventHandler(object sender, TreeNodeMouseClickEventArgs e);

    /// <summary>
    /// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> and 
    /// <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> events. 
    /// </summary>
    [Serializable()]
    public class TreeNodeMouseClickEventArgs : MouseEventArgs
    {
        #region Fields

        private TreeNode mobjNode;

        #endregion Fields

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> class. </summary>
        /// <param name="intY">The y-coordinate where the click occurred.</param>
        /// <param name="intClicks">The number of clicks that occurred.</param>
        /// <param name="objNode">The node that was clicked.</param>
        /// <param name="objButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MouseButtons"></see> members.</param>
        /// <param name="intX">The x-coordinate where the click occurred.</param>
        public TreeNodeMouseClickEventArgs(TreeNode objNode, MouseButtons objButton, int intClicks, int intX, int intY)
            : base(objButton, intClicks, intX, intY, 0)
        {
            this.mobjNode = objNode;
        }

        #endregion Constructors

        #region Properties

        /// <summary>Gets the node that was clicked.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that was clicked.</returns>
        /// <filterpriority>1</filterpriority>
        public TreeNode Node
        {
            get
            {
                return this.mobjNode;
            }
        }

        #endregion Properties
    }

    #endregion TreeNodeMouseClickEventArgs Class

    #region ItemDragEventArgs Class
    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGui.Forms.ListView.ItemDrag"></see> event of a <see cref="T:Gizmox.WebGui.Forms.ListView"></see> or <see cref="T:Gizmox.WebGui.Forms.TreeView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void ItemDragEventHandler(object sender, ItemDragEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGui.Forms.ListView.ItemDrag"></see> event of the <see cref="T:Gizmox.WebGui.Forms.ListView"></see> and <see cref="T:Gizmox.WebGui.Forms.TreeView"></see> controls.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class ItemDragEventArgs : EventArgs
    {
        private readonly MouseButtons menmMouseButtons;
        private readonly object mobjItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDragEventArgs"/> class.
        /// </summary>
        /// <param name="button">The button.</param>
        public ItemDragEventArgs(MouseButtons button)
        {
            this.menmMouseButtons = button;
            this.mobjItem = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDragEventArgs"/> class.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="item">The item.</param>
        public ItemDragEventArgs(MouseButtons button, object item)
        {
            this.menmMouseButtons = button;
            this.mobjItem = item;
        }

        /// <summary>
        /// Gets the button.
        /// </summary>
        /// <value>The button.</value>
        public MouseButtons Button
        {
            get
            {
                return this.menmMouseButtons;
            }
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public object Item
        {
            get
            {
                return this.mobjItem;
            }
        }
    }

    #endregion

    #endregion EventArgs Classes

    #region TreeViewRenderer Class

    /// <summary>
    /// Provides support for rendering a scrollable control  
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class TreeViewRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewRenderer"/> class.
        /// </summary>
        /// <param name="objTreeView">The treeview control.</param>
        public TreeViewRenderer(TreeView objTreeView)
            : base(objTreeView)
        {
        }



        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the treeview control
            TreeView objTreeView = this.Control as TreeView;
            if (objTreeView != null)
            {
                // Get the treeview skin
                TreeViewSkin objTreeViewSkin = objTreeView.Skin as TreeViewSkin;
                if (objTreeViewSkin != null)
                {
                    // Get the content region
                    Rectangle objContentRegion = GetContentRegion(objTreeView);

                    // Render the nodes
                    RenderNodes(objContext, objGraphics, objTreeViewSkin, objTreeView.Nodes, objContentRegion);
                }
            }
        }

        /// <summary>
        /// Renders the nodes.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objNodes">The nodes.</param>
        /// <param name="objContentRegion">The content region.</param>
        private void RenderNodes(ControlRenderingContext objContext, Graphics objGraphics, TreeViewSkin objTreeViewSkin, TreeNodeCollection objNodes, Rectangle objContentRegion)
        {

            // Loop all tree nodes
            foreach (TreeNode objNode in objNodes)
            {
                // Render the node in the current region
                objContentRegion = DockInRegion(objContentRegion, DockStyle.Top, RenderNode(objContext, objGraphics, objTreeViewSkin, objNode, objContentRegion));

                // If no more place to render nodes
                if (!IsVisibleRegion(objContentRegion))
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Renders the node.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objTreeViewSkin">The tree view skin.</param>
        /// <param name="objContentRegion">The content region.</param>
        /// <returns></returns>
        private Rectangle RenderNode(ControlRenderingContext objContext, Graphics objGraphics, TreeViewSkin objTreeViewSkin, TreeNode objNode, Rectangle objContentRegion)
        {
            // The node region
            Rectangle objNodeRegion = new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, 20));

            // Render tree nodes
            objNodeRegion = DockInRegion(objNodeRegion, DockStyle.Left, RenderImage(objContext, objGraphics, objNode.Image, objNodeRegion, ContentAlignment.MiddleLeft));
            objNodeRegion = DockInRegion(objNodeRegion, DockStyle.Left, RenderText(objContext, objGraphics, objNode.Text, objNode.NodeFont, objNode.ForeColor, objNodeRegion, ContentAlignment.MiddleLeft, false));

            // If node is expanded
            if (objNode.IsExpanded)
            {
                // Get the nodes region
                Rectangle objNodesRegions = new Rectangle(objContentRegion.X + 20, objNodeRegion.Bottom, Math.Max(0, objNodeRegion.Width - 20), Math.Max(0, objContentRegion.Height - 20));

                // If nodes region is visible
                if (IsVisibleRegion(objNodesRegions))
                {
                    // The sub nodes height
                    int intNodesHeight = 0;

                    // Loop all tree nodes
                    foreach (TreeNode objSubNode in objNode.Nodes)
                    {
                        // Get the sub node rectangle
                        Rectangle objSubNodeRegion = RenderNode(objContext, objGraphics, objTreeViewSkin, objSubNode, objNodesRegions);

                        // Add the node height
                        intNodesHeight += objSubNodeRegion.Height;

                        // Render the node in the current region
                        objNodesRegions = DockInRegion(objNodesRegions, DockStyle.Top, objSubNodeRegion);

                        // If no more place to render nodes
                        if (!IsVisibleRegion(objNodesRegions))
                        {
                            break;
                        }
                    }

                    // Add the nodes height to the region
                    objNodeRegion.Height += intNodesHeight;
                }
            }

            return objNodeRegion;
        }
    }

    #endregion
}
