// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewGroupingTreeViewSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for GroupingTreeViewSkin</summary>
  [SkinContainer(typeof (DataGridViewSkin))]
  [Serializable]
  public class DataGridViewGroupingTreeViewSkin : TreeViewSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the node close button style.</summary>
    [SRCategory("Styles")]
    [SRDescription("Grouping TreeNode Close button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue TreeNodeCloseButtonStyle => new StyleValue((CommonSkin) this, nameof (TreeNodeCloseButtonStyle));

    /// <summary>Gets the node joint style.</summary>
    [SRCategory("Styles")]
    [SRDescription("Grouping TreeNode joint style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue TreeNodeJointStyle => new StyleValue((CommonSkin) this, nameof (TreeNodeJointStyle));

    /// <summary>Gets or sets the height of the tree node.</summary>
    /// <value>The height of the tree node.</value>
    [SRCategory("Sizes")]
    [SRDescription("Grouping TreeNode height in pixels.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual int TreeNodeHeight
    {
      get => this.GetValue<int>(nameof (TreeNodeHeight), 18);
      set => this.SetValue(nameof (TreeNodeHeight), (object) value);
    }

    /// <summary>Gets the width of the node close button.</summary>
    /// <value>The width of the node close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int TreeNodeCloseButtonWidth => this.GetImageWidth(this.TreeNodeCloseButtonStyle.BackgroundImage);

    /// <summary>Gets the width of the tree node joint image.</summary>
    /// <value>The width of the tree node joint image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int TreeNodeJointImageWidth => Math.Max(this.GetImageWidth(this.TreeNodeJointLTRImage), this.GetImageWidth(this.TreeNodeJointRTLImage));

    /// <summary>Gets the height of the tree node joint image.</summary>
    /// <value>The height of the tree node joint image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int TreeNodeJointImageHeight => Math.Max(this.GetImageHeight(this.TreeNodeJointLTRImage), this.GetImageHeight(this.TreeNodeJointRTLImage));

    /// <summary>Gets or sets the height of top indicator placeholder.</summary>
    /// <value>The height of top indicator placeholder.</value>
    [SRCategory("Sizes")]
    [SRDescription("Grouping Area top indicator placeholder height in pixels.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual int TopNodePlaceHolderHeight
    {
      get => this.GetValue<int>(nameof (TopNodePlaceHolderHeight), 5);
      set => this.SetValue(nameof (TopNodePlaceHolderHeight), (object) value);
    }

    /// <summary>Gets the height of the node close button.</summary>
    /// <value>The height of the node close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int TreeNodeCloseButtonHeight => this.GetImageHeight(this.TreeNodeCloseButtonStyle.BackgroundImage);

    /// <summary>Gets or sets the tree node padding top.</summary>
    /// <value>The tree node padding top.</value>
    [SRDescription("The tree node top padding.")]
    [SRCategory("Images")]
    public virtual int TreeNodePaddingTop
    {
      get => this.GetValue<int>(nameof (TreeNodePaddingTop), (this.TreeNodeJointImageHeight - this.TreeNodeHeight) / 2);
      set => this.SetValue(nameof (TreeNodePaddingTop), (object) value);
    }

    /// <summary>Gets or sets the node joint LTR image.</summary>
    /// <value>The node joint LTR image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference TreeNodeJointLTRImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (TreeNodeJointLTRImage), new ImageResourceReference(typeof (DataGridViewGroupingTreeViewSkin), "GroupingTreeNodeJointLTR.gif"));
      set => this.SetValue(nameof (TreeNodeJointLTRImage), (object) value);
    }

    /// <summary>Resets the node joint LTR image.</summary>
    private void ResetNodeJointLTRImage() => this.Reset("TreeNodeJointLTRImage");

    /// <summary>Gets or sets the node joint RTL image.</summary>
    /// <value>The node joint RTL image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference TreeNodeJointRTLImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (TreeNodeJointRTLImage), new ImageResourceReference(typeof (DataGridViewGroupingTreeViewSkin), "GroupingTreeNodeJointRTL.gif"));
      set => this.SetValue(nameof (TreeNodeJointRTLImage), (object) value);
    }

    /// <summary>Resets the node joint RTL image.</summary>
    private void ResetNodeJointRTLImage() => this.Reset("TreeNodeJointRTLImage");

    /// <summary>Gets the tree node joint image.</summary>
    [SRDescription("The node joint image.")]
    [SRCategory("Images")]
    public virtual BidirectionalSkinProperty<ImageResourceReference> TreeNodeJointImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "TreeNodeJointLTRImage", "TreeNodeJointRTLImage");
  }
}
