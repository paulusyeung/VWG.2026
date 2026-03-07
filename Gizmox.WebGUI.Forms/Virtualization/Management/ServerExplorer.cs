// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.ServerExplorer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Gizmox.WebGUI.Virtualization.Management
{
  /// <summary>Summary description for ServerExplorer.</summary>
  [Serializable]
  public class ServerExplorer : Form
  {
    private static readonly SerializableEvent ComponentDoubleClickEvent = SerializableEvent.Register(nameof (ComponentDoubleClickEvent), typeof (EventHandler<ComponentDoubleClickEventArgs>), typeof (ServerExplorer));
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
    /// <summary>Required designer variable.</summary>
    [NonSerialized]
    private System.ComponentModel.Container components;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Virtualization.Management.ServerExplorer" /> class.
    /// </summary>
    public ServerExplorer()
      : this(true, true, true, false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Virtualization.Management.ServerExplorer" /> class.
    /// </summary>
    /// <param name="blnShowPhysicalEnviroment">if set to <c>true</c> [BLN show physical enviroment].</param>
    /// <param name="blnShowRuntimeEnvironment">if set to <c>true</c> [BLN show runtime environment].</param>
    /// <param name="blnShowTraceList">if set to <c>true</c> [BLN show trace list].</param>
    /// <param name="blnShowOkCancel">if set to <c>true</c> [BLN show ok cancel].</param>
    public ServerExplorer(
      bool blnShowPhysicalEnviroment,
      bool blnShowRuntimeEnvironment,
      bool blnShowTraceList,
      bool blnShowOkCancel)
    {
      this.InitializeComponent();
      if (blnShowTraceList)
      {
        this.InitialzeTraceList();
        this.mobjServerExplorerTree.List = this.mobjListTrace;
      }
      else
        this.mobjServerExplorerTree.Dock = DockStyle.Fill;
      if (blnShowPhysicalEnviroment)
        this.InitialzePhysicalEnviroment();
      if (blnShowRuntimeEnvironment)
        this.InitialzeRuntimeEnvironment();
      if (!blnShowOkCancel)
        return;
      this.InitializeOkCancel();
    }

    /// <summary>Initializes the ok cancel.</summary>
    private void InitializeOkCancel()
    {
      this.mobjButtonsPanel = new Panel();
      this.mobjOkButton = new Button();
      this.mobjSeperatorPanel = new Panel();
      this.mobjCancelButton = new Button();
      this.mobjButtonsPanel.Height = 40;
      this.mobjButtonsPanel.Dock = DockStyle.Bottom;
      this.mobjButtonsPanel.DockPadding.Top = 10;
      this.mobjButtonsPanel.DockPadding.Bottom = 10;
      this.mobjButtonsPanel.DockPadding.Right = 10;
      this.mobjButtonsPanel.Controls.Add((Control) this.mobjOkButton);
      this.mobjButtonsPanel.Controls.Add((Control) this.mobjSeperatorPanel);
      this.mobjButtonsPanel.Controls.Add((Control) this.mobjCancelButton);
      this.mobjOkButton.Text = WGLabels.Ok;
      this.mobjOkButton.Dock = DockStyle.Right;
      this.mobjOkButton.Enabled = false;
      this.mobjOkButton.DialogResult = DialogResult.OK;
      this.mobjSeperatorPanel.Width = 20;
      this.mobjSeperatorPanel.Dock = DockStyle.Right;
      this.mobjCancelButton.Text = WGLabels.Cancel;
      this.mobjCancelButton.Dock = DockStyle.Right;
      this.CancelButton = (IButtonControl) this.mobjCancelButton;
      this.AcceptButton = (IButtonControl) this.mobjOkButton;
      this.Controls.Add((Control) this.mobjButtonsPanel);
    }

    /// <summary>Occurs when [node mouse double click].</summary>
    public event EventHandler<ComponentDoubleClickEventArgs> ComponentDoubleClick
    {
      add
      {
        this.AddHandler(ServerExplorer.ComponentDoubleClickEvent, (Delegate) value);
        if (this.mblnIsDoubleClickRegistered)
          return;
        this.mblnIsDoubleClickRegistered = true;
        this.mobjServerExplorerTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.OnTreeNodeMouseClick);
      }
      remove
      {
        this.RemoveHandler(ServerExplorer.ComponentDoubleClickEvent, (Delegate) value);
        if (this.ComponentDoubleHandler.GetInvocationList().Length != 0)
          return;
        this.mblnIsDoubleClickRegistered = false;
        this.mobjServerExplorerTree.NodeMouseDoubleClick -= new TreeNodeMouseClickEventHandler(this.OnTreeNodeMouseClick);
      }
    }

    /// <summary>Called when [tree node mouse click].</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
    private void OnTreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) => this.OnComponentDoubleClick(e.Node);

    /// <summary>Gets or sets the allowed selected types.</summary>
    /// <value>The allowed selected types.</value>
    public IEnumerable<Type> AllowedSelectedTypes
    {
      get
      {
        IEnumerable<Type> allowedSelectedTypes = this.mobjAllowedSelectedTypes;
        if (allowedSelectedTypes != null)
          return allowedSelectedTypes;
        return (IEnumerable<Type>) new Type[1]
        {
          typeof (IRegisteredComponent)
        };
      }
      set => this.mobjAllowedSelectedTypes = value;
    }

    /// <summary>Gets or sets the allowed selected types.</summary>
    /// <value>The allowed selected types.</value>
    public IEnumerable<Type> AllowedProxySourceSelectedTypes
    {
      get
      {
        IEnumerable<Type> sourceSelectedTypes = this.mobjAllowedProxySourceSelectedTypes;
        if (sourceSelectedTypes != null)
          return sourceSelectedTypes;
        return (IEnumerable<Type>) new Type[1]
        {
          typeof (IRegisteredComponent)
        };
      }
      set => this.mobjAllowedProxySourceSelectedTypes = value;
    }

    /// <summary>Gets the selected component.</summary>
    /// <value>The selected component.</value>
    public IRegisteredComponent SelectedComponent
    {
      get => this.mobjSelectedComponent;
      internal set
      {
        bool flag = this.IsSupportSelect(value);
        if (value == null | flag)
        {
          this.mobjSelectedComponent = value;
          if (!flag)
            return;
          this.mobjOkButton.Enabled = true;
        }
        else
          this.mobjOkButton.Enabled = false;
      }
    }

    /// <summary>Gets the component double handler.</summary>
    /// <value>The component double handler.</value>
    private EventHandler<ComponentDoubleClickEventArgs> ComponentDoubleHandler => this.GetHandler(ServerExplorer.ComponentDoubleClickEvent) as EventHandler<ComponentDoubleClickEventArgs>;

    /// <summary>Called when [component double click].</summary>
    /// <param name="treeNode">The tree node.</param>
    private void OnComponentDoubleClick(TreeNode treeNode)
    {
      if (!(treeNode is ApplicationDOMNode) || !this.IsSupportSelect(treeNode.Tag as IRegisteredComponent))
        return;
      EventHandler<ComponentDoubleClickEventArgs> componentDoubleHandler = this.ComponentDoubleHandler;
      if (componentDoubleHandler == null)
        return;
      componentDoubleHandler((object) this, new ComponentDoubleClickEventArgs(treeNode.Tag as IRegisteredComponent));
    }

    /// <summary>Initialzes the runtime environment.</summary>
    private void InitialzeRuntimeEnvironment()
    {
      TreeNode objTreeViewNode = new TreeNode("RuntimeEnviroment", "Runtime Enviroment", "Folders");
      this.mobjServerExplorerTree.Nodes.Add(objTreeViewNode);
      this.mobjServerExplorerTree.AfterSelect += new TreeViewEventHandler(this.mobjServerExplorerTree_AfterSelect);
      this.mobjRootTraceNode = new TreeNode("UserInterface", "User Interface", "Folder");
      this.mobjRootTraceNode.IsExpanded = false;
      objTreeViewNode.Nodes.Add(this.mobjRootTraceNode);
    }

    /// <summary>
    /// Handles the AfterSelect event of the mobjServerExplorerTree control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
    private void mobjServerExplorerTree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (e.Node == this.mobjRootTraceNode && this.mobjListTrace != null)
      {
        this.mobjListTrace.Columns.Clear();
        this.mobjListTrace.Items.Clear();
        this.mobjListTrace.Update();
      }
      if (e.Node is ApplicationDOMNode)
        this.SelectedComponent = (e.Node as ApplicationDOMNode).Tag as IRegisteredComponent;
      else
        this.SelectedComponent = (IRegisteredComponent) null;
    }

    /// <summary>Sets the root component.</summary>
    /// <param name="objComponent">The object component.</param>
    public void SetRootComponent(IRegisteredComponent objComponent)
    {
      if (this.mobjRootTraceNode == null)
        return;
      this.mobjRootTraceNode.Nodes.Clear();
      this.mobjRootTraceNode.Nodes.Add((TreeNode) new ApplicationDOMNode(objComponent, this.IsSupportSelect(objComponent)));
    }

    /// <summary>Initialzes the physical enviroment.</summary>
    private void InitialzePhysicalEnviroment()
    {
      TreeNode objTreeViewNode1 = new TreeNode("PhysicalEnviroment", "Physical Enviroment", "Folders");
      this.mobjServerExplorerTree.Nodes.Add(objTreeViewNode1);
      TreeNode objTreeViewNode2 = new TreeNode("PhysicalRegistry", "Registry", "Registry");
      objTreeViewNode1.Nodes.Add(objTreeViewNode2);
      objTreeViewNode1.Nodes.Add(new TreeNode("PhysicalStorage", "Storage", "Storage")
      {
        Nodes = {
          (TreeNode) new PhysicalStorageNode(this.Context.HostContext.Server.MapPath("/"))
        },
        IsExpanded = false
      });
    }

    /// <summary>Initialzes the trace list.</summary>
    private void InitialzeTraceList()
    {
      this.mobjListTrace = new ListView();
      this.mobjSplitterTrace = new Splitter();
      this.mobjSplitterTrace.Location = new Point(168, 5);
      this.mobjSplitterTrace.Name = "mobjSplitterTrace";
      this.mobjSplitterTrace.Size = new Size(3, 420);
      this.mobjSplitterTrace.TabIndex = 1;
      this.mobjSplitterTrace.TabStop = false;
      this.mobjListTrace.Dock = DockStyle.Fill;
      this.mobjListTrace.Location = new Point(171, 5);
      this.mobjListTrace.Name = "mobjListTrace";
      this.mobjListTrace.Size = new Size(576, 420);
      this.mobjListTrace.TabIndex = 2;
      this.mobjListTrace.View = View.Details;
      this.mobjListTrace.DoubleClick += new EventHandler(this.mobjListTrace_DoubleClick);
      this.Controls.Insert(0, (object) this.mobjSplitterTrace);
      this.Controls.Insert(0, (object) this.mobjListTrace);
    }

    /// <summary>Clean up any resources being used.</summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing && this.components != null)
        this.components.Dispose();
      base.Dispose(blnDisposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mobjServerExplorerTree = new ServerExplorerTree();
      this.SuspendLayout();
      this.mobjServerExplorerTree.Dock = DockStyle.Left;
      this.mobjServerExplorerTree.ImageIndex = -1;
      this.mobjServerExplorerTree.Location = new Point(5, 5);
      this.mobjServerExplorerTree.Name = "mobjTreeTrace";
      this.mobjServerExplorerTree.SelectedImageIndex = -1;
      this.mobjServerExplorerTree.Size = new Size(163, 420);
      this.mobjServerExplorerTree.TabIndex = 0;
      this.ClientSize = new Size(752, 430);
      this.Controls.Add((Control) this.mobjServerExplorerTree);
      this.DockPadding.All = 5;
      this.Name = nameof (ServerExplorer);
      this.Text = "Server Explorer";
      this.ResumeLayout(false);
    }

    /// <summary>
    /// Handles the DoubleClick event of the mobjListTrace control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjListTrace_DoubleClick(object sender, EventArgs e)
    {
      if (this.mobjListTrace.SelectedItem == null || !(this.mobjServerExplorerTree.SelectedNode is ServerExplorerNode selectedNode))
        return;
      selectedNode.OnItemDoubleClick(this.mobjListTrace.SelectedItem);
    }

    /// <summary>
    /// Determines whether [is support select] [the specified object component].
    /// </summary>
    /// <param name="objComponent">The object component.</param>
    /// <returns></returns>
    internal bool IsSupportSelect(IRegisteredComponent objComponent)
    {
      bool flag1 = false;
      if (objComponent != null)
      {
        Type type1 = objComponent.GetType();
        foreach (Type allowedSelectedType in this.AllowedSelectedTypes)
        {
          flag1 |= allowedSelectedType.IsAssignableFrom(type1);
          if (flag1)
            break;
        }
        if (flag1 && objComponent is ProxyComponent proxyComponent)
        {
          bool flag2 = false;
          Gizmox.WebGUI.Forms.Component sourceComponent = proxyComponent.SourceComponent;
          if (sourceComponent != null)
          {
            Type type2 = sourceComponent.GetType();
            foreach (Type sourceSelectedType in this.AllowedProxySourceSelectedTypes)
            {
              flag2 |= sourceSelectedType.IsAssignableFrom(type2);
              if (flag2)
                break;
            }
          }
          flag1 &= flag2;
        }
      }
      return flag1;
    }
  }
}
