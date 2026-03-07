#region Using

using System;
using System.Drawing;
using System.Collections;
using System.Reflection;

using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;

using Gizmox.WebGUI.Forms;


using Gizmox.WebGUI.Virtualization.Win32;
using System.Collections.Generic;

#endregion 

namespace Gizmox.WebGUI.Virtualization.Management
{

	#region ServerExplorer Class

	/// <summary>
	/// Summary description for ServerExplorer.
	/// </summary>

    [Serializable()]
    public class ServerExplorer : Form
	{
		#region Class Members

        private static readonly SerializableEvent ComponentDoubleClickEvent = SerializableEvent.Register("ComponentDoubleClickEvent", typeof(EventHandler<ComponentDoubleClickEventArgs>), typeof(ServerExplorer));

		#region Designer Members

        private bool mblnIsDoubleClickRegistered;
        private IRegisteredComponent mobjSelectedComponent;
        private IEnumerable<Type> mobjAllowedSelectedTypes;
        private IEnumerable<Type> mobjAllowedProxySourceSelectedTypes;

        private Panel mobjButtonsPanel;
        private Panel mobjSeperatorPanel;
        private Button mobjOkButton;
        private Button mobjCancelButton;
        private ServerExplorerTree mobjServerExplorerTree;
        private Splitter mobjSplitterTrace;
        private ListView mobjListTrace;
        private TreeNode mobjRootTraceNode;

		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		#endregion 

		#endregion 

        #region C'Tor\D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerExplorer" /> class.
        /// </summary>
        public ServerExplorer()
            : this(true, true, true, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerExplorer" /> class.
        /// </summary>
        /// <param name="blnShowPhysicalEnviroment">if set to <c>true</c> [BLN show physical enviroment].</param>
        /// <param name="blnShowRuntimeEnvironment">if set to <c>true</c> [BLN show runtime environment].</param>
        /// <param name="blnShowTraceList">if set to <c>true</c> [BLN show trace list].</param>
        /// <param name="blnShowOkCancel">if set to <c>true</c> [BLN show ok cancel].</param>
        public ServerExplorer(bool blnShowPhysicalEnviroment, bool blnShowRuntimeEnvironment, bool blnShowTraceList, bool blnShowOkCancel)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            if (blnShowTraceList)
            {
                InitialzeTraceList();
                mobjServerExplorerTree.List = mobjListTrace;
            }
            else
            {
                mobjServerExplorerTree.Dock = DockStyle.Fill;
            }
            
            if (blnShowPhysicalEnviroment)
            {
                InitialzePhysicalEnviroment();
            }
            if (blnShowRuntimeEnvironment)
            {
                InitialzeRuntimeEnvironment();
            }
            if (blnShowOkCancel)
            {
                InitializeOkCancel();
            }
        }

        /// <summary>
        /// Initializes the ok cancel.
        /// </summary>
        private void InitializeOkCancel()
        {
            this.mobjButtonsPanel = new Panel();
            this.mobjOkButton = new Button();
            this.mobjSeperatorPanel = new Panel();
            this.mobjCancelButton = new Button();
            //
            // objButtonsPanel
            //
            this.mobjButtonsPanel.Height = 40;
            this.mobjButtonsPanel.Dock = DockStyle.Bottom;
            this.mobjButtonsPanel.DockPadding.Top = 10;
            this.mobjButtonsPanel.DockPadding.Bottom = 10;
            this.mobjButtonsPanel.DockPadding.Right = 10;
            this.mobjButtonsPanel.Controls.Add(mobjOkButton);
            this.mobjButtonsPanel.Controls.Add(mobjSeperatorPanel);
            this.mobjButtonsPanel.Controls.Add(mobjCancelButton);
            //
            // objOkButton
            //
            this.mobjOkButton.Text = WGLabels.Ok;
            this.mobjOkButton.Dock = DockStyle.Right;
            this.mobjOkButton.Enabled = false;
            this.mobjOkButton.DialogResult = Forms.DialogResult.OK;
            //
            // mobjSeperatorPanel
            //
            mobjSeperatorPanel.Width = 20;
            mobjSeperatorPanel.Dock = DockStyle.Right;
            //
            // objCancelButton
            //
            this.mobjCancelButton.Text = WGLabels.Cancel;
            this.mobjCancelButton.Dock = DockStyle.Right;
            //
            // this
            //
            this.CancelButton = mobjCancelButton;
            this.AcceptButton = mobjOkButton;
            this.Controls.Add(mobjButtonsPanel);
        }

        /// <summary>
        /// Occurs when [node mouse double click].
        /// </summary>
        public event EventHandler<ComponentDoubleClickEventArgs> ComponentDoubleClick
        {
            add
            {
                this.AddHandler(ServerExplorer.ComponentDoubleClickEvent, value);
                if (!mblnIsDoubleClickRegistered)
                {
                    mblnIsDoubleClickRegistered = true;
                    mobjServerExplorerTree.NodeMouseDoubleClick += OnTreeNodeMouseClick;
                }
            }
            remove
            {
                this.RemoveHandler(ServerExplorer.ComponentDoubleClickEvent, value);

                if (this.ComponentDoubleHandler.GetInvocationList().Length == 0)
                {
                    mblnIsDoubleClickRegistered = false;
                    mobjServerExplorerTree.NodeMouseDoubleClick -= OnTreeNodeMouseClick;
                }
            }
        }

        /// <summary>
        /// Called when [tree node mouse click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        private void OnTreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OnComponentDoubleClick(e.Node);
        }


        /// <summary>
        /// Gets or sets the allowed selected types.
        /// </summary>
        /// <value>
        /// The allowed selected types.
        /// </value>
        public IEnumerable<Type> AllowedSelectedTypes
        {
            get 
            {
                return mobjAllowedSelectedTypes ?? new Type[]{ typeof(IRegisteredComponent) }; 
            }
            set { mobjAllowedSelectedTypes = value; }
        }


        /// <summary>
        /// Gets or sets the allowed selected types.
        /// </summary>
        /// <value>
        /// The allowed selected types.
        /// </value>
        public IEnumerable<Type> AllowedProxySourceSelectedTypes
        {
            get
            {
                return mobjAllowedProxySourceSelectedTypes ?? new Type[] { typeof(IRegisteredComponent) };
            }
            set { mobjAllowedProxySourceSelectedTypes = value; }
        }


        /// <summary>
        /// Gets the selected component.
        /// </summary>
        /// <value>
        /// The selected component.
        /// </value>
        public IRegisteredComponent SelectedComponent
        {
            get 
            {
                return mobjSelectedComponent; 
            }
            internal set
            {
                bool blnIsSupported = IsSupportSelect(value);
                if (value == null || blnIsSupported)
                {
                    mobjSelectedComponent = value;

                    if (blnIsSupported)
                    {
                        this.mobjOkButton.Enabled = true;
                    }
                }
                else
                {
                    this.mobjOkButton.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Gets the component double handler.
        /// </summary>
        /// <value>
        /// The component double handler.
        /// </value>
        private EventHandler<ComponentDoubleClickEventArgs> ComponentDoubleHandler
        {
            get
            {
                return GetHandler(ServerExplorer.ComponentDoubleClickEvent) as EventHandler<ComponentDoubleClickEventArgs>;
            }
        }

        /// <summary>
        /// Called when [component double click].
        /// </summary>
        /// <param name="treeNode">The tree node.</param>
        private void OnComponentDoubleClick(TreeNode treeNode)
        {
            if(treeNode is ApplicationDOMNode)
            {
                IRegisteredComponent objComponent = treeNode.Tag as IRegisteredComponent;
                if (IsSupportSelect(objComponent))
                {
                    EventHandler<ComponentDoubleClickEventArgs> objHandler = this.ComponentDoubleHandler;
                    if (objHandler != null)
                    {
                        objHandler(this, new ComponentDoubleClickEventArgs(treeNode.Tag as IRegisteredComponent));
                    }
                }
            }
        }

        /// <summary>
        /// Initialzes the runtime environment.
        /// </summary>
        private void InitialzeRuntimeEnvironment()
        {
            // Add the runtime enviroment node
            TreeNode objRuntimeEnviromentNode = new TreeNode("RuntimeEnviroment", "Runtime Enviroment", "Folders");
            this.mobjServerExplorerTree.Nodes.Add(objRuntimeEnviromentNode);
            mobjServerExplorerTree.AfterSelect += mobjServerExplorerTree_AfterSelect;
            mobjRootTraceNode = new TreeNode("UserInterface", "User Interface", "Folder");
            mobjRootTraceNode.IsExpanded = false;
            objRuntimeEnviromentNode.Nodes.Add(mobjRootTraceNode);
        }

        /// <summary>
        /// Handles the AfterSelect event of the mobjServerExplorerTree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        void mobjServerExplorerTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == mobjRootTraceNode && mobjListTrace != null)
            {
                this.mobjListTrace.Columns.Clear();
                this.mobjListTrace.Items.Clear();
                this.mobjListTrace.Update();
            }
            
            if (e.Node is ApplicationDOMNode)
            {
                this.SelectedComponent = (e.Node as ApplicationDOMNode).Tag as IRegisteredComponent;
            }
            else
            {
                this.SelectedComponent = null;
            }
        }

        /// <summary>
        /// Sets the root component.
        /// </summary>
        /// <param name="objComponent">The object component.</param>
        public void SetRootComponent(IRegisteredComponent objComponent)
        {
            // If Runtime Environment was not initialize then mobjRootTraceNode == null
            if (mobjRootTraceNode != null)
            {
                mobjRootTraceNode.Nodes.Clear();
                mobjRootTraceNode.Nodes.Add(new ApplicationDOMNode(objComponent, this.IsSupportSelect(objComponent)));
            }
        }

        /// <summary>
        /// Initialzes the physical enviroment.
        /// </summary>
        private void InitialzePhysicalEnviroment()
        {
            // Add the phisical enviroment node
            TreeNode objPhysicalEnviromentNode = new TreeNode("PhysicalEnviroment", "Physical Enviroment", "Folders");
            this.mobjServerExplorerTree.Nodes.Add(objPhysicalEnviromentNode);

            TreeNode objPhysicalRegistryNode = new TreeNode("PhysicalRegistry", "Registry", "Registry");
            objPhysicalEnviromentNode.Nodes.Add(objPhysicalRegistryNode);

            TreeNode objPhysicalStorageNode = new TreeNode("PhysicalStorage", "Storage", "Storage");
            objPhysicalStorageNode.Nodes.Add(new PhysicalStorageNode(Context.HostContext.Server.MapPath("/")));
            objPhysicalStorageNode.IsExpanded = false;
            objPhysicalEnviromentNode.Nodes.Add(objPhysicalStorageNode);
        }

        /// <summary>
        /// Initialzes the trace list.
        /// </summary>
        private void InitialzeTraceList()
        {
            this.mobjListTrace = new ListView();
            this.mobjSplitterTrace = new Splitter();
            // 
            // mobjSplitterTrace
            // 
            this.mobjSplitterTrace.Location = new System.Drawing.Point(168, 5);
            this.mobjSplitterTrace.Name = "mobjSplitterTrace";
            this.mobjSplitterTrace.Size = new System.Drawing.Size(3, 420);
            this.mobjSplitterTrace.TabIndex = 1;
            this.mobjSplitterTrace.TabStop = false;
            // 
            // mobjListTrace
            // 
            this.mobjListTrace.Dock = DockStyle.Fill;
            this.mobjListTrace.Location = new System.Drawing.Point(171, 5);
            this.mobjListTrace.Name = "mobjListTrace";
            this.mobjListTrace.Size = new System.Drawing.Size(576, 420);
            this.mobjListTrace.TabIndex = 2;
            this.mobjListTrace.View = View.Details;
            this.mobjListTrace.DoubleClick += new EventHandler(mobjListTrace_DoubleClick);
            //
            // this
            //
            this.Controls.Insert(0, this.mobjSplitterTrace);
            this.Controls.Insert(0, this.mobjListTrace);
        }

		#endregion 

		#region Methods

		#region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool blnDisposing)
		{
            if (blnDisposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
            base.Dispose(blnDisposing);
		}

		#endregion 

		#region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
		private void InitializeComponent()
		{
			this.mobjServerExplorerTree = new ServerExplorerTree();
			this.SuspendLayout();
			// 
			// mobjTreeTrace
			// 
			this.mobjServerExplorerTree.Dock = DockStyle.Left;
			this.mobjServerExplorerTree.ImageIndex = -1;
			this.mobjServerExplorerTree.Location = new System.Drawing.Point(5, 5);
			this.mobjServerExplorerTree.Name = "mobjTreeTrace";
			this.mobjServerExplorerTree.SelectedImageIndex = -1;
			this.mobjServerExplorerTree.Size = new System.Drawing.Size(163, 420);
			this.mobjServerExplorerTree.TabIndex = 0;
			// 
			// ServerExplorer
			// 			
			this.ClientSize = new System.Drawing.Size(752, 430);
			this.Controls.Add(this.mobjServerExplorerTree);
			this.DockPadding.All = 5;
			this.Name = "ServerExplorer";
			this.Text = "Server Explorer";
			this.ResumeLayout(false);

		}

        /// <summary>
        /// Handles the DoubleClick event of the mobjListTrace control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void mobjListTrace_DoubleClick(object sender, EventArgs e)
        {
            if (mobjListTrace.SelectedItem != null)
            {
                ServerExplorerNode objNode = mobjServerExplorerTree.SelectedNode as ServerExplorerNode;
                if (objNode != null)
                {
                    objNode.OnItemDoubleClick(mobjListTrace.SelectedItem);
                }
            }
        }
		#endregion

		#region Events

		#endregion 

		#endregion



        /// <summary>
        /// Determines whether [is support select] [the specified object component].
        /// </summary>
        /// <param name="objComponent">The object component.</param>
        /// <returns></returns>
        internal bool IsSupportSelect(IRegisteredComponent objComponent)
        {
            bool blnIsSupported = false;
            
            if (objComponent != null)
            {
                Type objComponentType = objComponent.GetType();
                foreach (Type objSupportedType in this.AllowedSelectedTypes)
                {
                    blnIsSupported |= objSupportedType.IsAssignableFrom(objComponentType);
                    if (blnIsSupported) { break; }
                }

                if (blnIsSupported)
                {
                    ProxyComponent objProxyComponent = objComponent as ProxyComponent;
                    if (objProxyComponent != null)
                    {
                        bool blnIsProxySupported = false;

                        Component objSourceComponent = objProxyComponent.SourceComponent;
                        if (objSourceComponent != null)
                        {
                            Type objSourceComponentType = objSourceComponent.GetType();
                            foreach (Type objSupportedType in this.AllowedProxySourceSelectedTypes)
                            {
                                blnIsProxySupported |= objSupportedType.IsAssignableFrom(objSourceComponentType);
                                if (blnIsProxySupported) { break; }
                            }
                        }

                        blnIsSupported &= blnIsProxySupported;
                    }
                }
            }

            return blnIsSupported;
        }
    }


	#endregion 

	#region ServerExplorerTree Class

    [System.ComponentModel.ToolboxItem(false), Serializable()]
	
	internal class ServerExplorerTree : TreeView
	{
		private ListView mobjListView;

		internal ListView List
		{
			get {  return mobjListView; }
			set { mobjListView = value; }    
		}
	}

	#endregion 

	#region ServerExplorerNode Class


    [Serializable()]
    internal class ServerExplorerNode : TreeNode
	{
		public ServerExplorerNode()
		{
			Loaded		= false;
			IsExpanded	= false;
			HasNodes	= true;
			BeforeExpand+=new TreeViewCancelEventHandler(TraceTreeNode_BeforeExpand);
            BeforeSelect += new TreeViewCancelEventHandler(TraceTreeNode_BeforeSelect);
		}

        private void TraceTreeNode_BeforeExpand(object objSource, TreeViewCancelEventArgs objArgs)
		{
			if(!Loaded)
			{
				LoadNodes();
				Loaded		= true;
				IsExpanded	= true;
				HasNodes	= Nodes.Count>0;
			}
		}

		protected virtual void LoadNodes()
		{
		}

		private void TraceTreeNode_BeforeSelect(object objSource, TreeViewCancelEventArgs objArgs)
		{
			ListView objListView = List;
			if(objListView!=null)
			{
				objListView.Columns.Clear();
				objListView.Items.Clear();
				objListView.Update();
				LoadColumns(objListView.Columns);
				LoadItems(objListView.Items);
			}
		}

		protected virtual void LoadColumns(ListView.ColumnHeaderCollection objColumns)
		{
		}

		protected virtual void LoadItems(ListView.ListViewItemCollection objItems)
		{
		}

        /// <summary>
        /// Gets the explorer.
        /// </summary>
        /// <value>
        /// The explorer.
        /// </value>
        protected ServerExplorer Explorer
        {
            get
            {
                return Form as ServerExplorer;
            }
        }


		internal ListView List
		{
			get
			{
				if(this.TreeView is ServerExplorerTree)
				{
					return ((ServerExplorerTree)this.TreeView).List;
				}
				else
				{
					return null;
				}
			}
		}

        protected internal virtual void OnItemDoubleClick(ListViewItem listViewItem)
        {
            
        }
    }

	#endregion 

    /// <summary>
    /// 
    /// </summary>
    public class ComponentDoubleClickEventArgs : EventArgs
    {
        /// <summary>
        /// The mobj component
        /// </summary>
        private IRegisteredComponent mobjComponent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentDoubleClickEventArgs"/> class.
        /// </summary>
        /// <param name="objComponent">The object component.</param>
        public ComponentDoubleClickEventArgs(IRegisteredComponent objComponent)
        {
            mobjComponent = objComponent;
        }

        /// <summary>
        /// Gets the component.
        /// </summary>
        /// <value>
        /// The component.
        /// </value>
        public IRegisteredComponent Component
        {
            get { return mobjComponent; }
        }
    }
}
