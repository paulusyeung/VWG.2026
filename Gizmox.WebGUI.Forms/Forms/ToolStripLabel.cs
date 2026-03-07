// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripLabel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a nonselectable <see cref="T:System.Windows.Forms.ToolStripItem"></see> that renders text and images and can display hyperlinks.</summary>
  [Skin(typeof (ToolStripLabelSkin))]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
  [Serializable]
  public class ToolStripLabel : ToolStripItem
  {
    private static readonly SerializableProperty mblnIsLinkProperty = SerializableProperty.Register(nameof (mblnIsLink), typeof (bool), typeof (ToolStripLabel));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class.</summary>
    public ToolStripLabel()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text to display.</summary>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    public ToolStripLabel(string text)
      : base(text, (ResourceHandle) null, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the image to display.</summary>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    public ToolStripLabel(ResourceHandle image)
      : base((string) null, image, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display.</summary>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    public ToolStripLabel(string text, ResourceHandle image)
      : base(text, image, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display and whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link.</summary>
    /// <param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    public ToolStripLabel(string text, ResourceHandle image, bool isLink)
      : this(text, image, isLink, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display, whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link, and providing a <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</summary>
    /// <param name="onClick">A <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</param>
    /// <param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    public ToolStripLabel(string text, ResourceHandle image, bool isLink, EventHandler onClick)
      : this(text, image, isLink, (EventHandler) null, (string) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display, whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link, and providing a <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler and name for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary>
    /// <param name="onClick">A <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</param>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    /// <param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
    public ToolStripLabel(
      string text,
      ResourceHandle image,
      bool isLink,
      EventHandler onClick,
      string name)
      : base(text, image, (EventHandler) null, (string) null)
    {
      this.IsLink = isLink;
    }

    private bool mblnIsLink
    {
      get => this.GetValue<bool>(ToolStripLabel.mblnIsLinkProperty);
      set => this.SetValue<bool>(ToolStripLabel.mblnIsLinkProperty, value);
    }

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected override int ToolStripItemType => 1;

    /// <summary>Gets or sets the color used to display an active link.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color to display an active link. The default color is specified by the system. Typically, this color is Color.Red.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color ActiveLinkColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>Gets a value indicating the selectable state of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary>
    /// <returns>false in all cases.</returns>
    /// <filterpriority>1</filterpriority>
    public override bool CanSelect => this.IsLink || this.DesignMode;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is a hyperlink. </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is a hyperlink; otherwise, false. The default is false.</returns>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("ToolStripLabelIsLinkDescr")]
    public bool IsLink
    {
      get => this.mblnIsLink;
      set
      {
        if (this.mblnIsLink == value)
          return;
        this.mblnIsLink = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets a value that represents the behavior of a link.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.LinkBehavior"></see> values. The default is LinkBehavior.SystemDefault.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public LinkBehavior LinkBehavior
    {
      get => LinkBehavior.AlwaysUnderline;
      set
      {
      }
    }

    /// <summary>Gets or sets the color used when displaying a normal link.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to displaying a normal link. The default color is specified by the system. Typically, this color is Color.Blue.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color LinkColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether a link should be displayed as though it were visited.</summary>
    /// <returns>true if links should display as though they were visited; otherwise, false. The default is false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool LinkVisited
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the color used when displaying a link that that has been previously visited.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display links that have been visited. The default color is specified by the system. Typically, this color is Color.Purple.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color VisitedLinkColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fit.
    /// </summary>
    /// <param name="objConstrainingSize">The custom-sized area for a control.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
    /// </returns>
    /// <PermissionSet>
    /// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    /// <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public override Size GetPreferredSize(Size objConstrainingSize) => this.GetPreferredSizeByImage(this.GetPreferredeSizeByText());

    /// <summary>Renders the tool strip item's attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    protected override void RenderToolStripItemAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter)
    {
      base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
      this.RenderTextAttributes(objAttributeWriter, false);
      this.RenderLinkStateAttribute(objAttributeWriter, false);
    }

    /// <summary>Renders the tool strip item updated attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected override void RenderToolStripItemUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter,
      long lngRequestID)
    {
      base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderTextAttributes(objAttributeWriter, true);
      this.RenderLinkStateAttribute(objAttributeWriter, true);
    }

    /// <summary>Renders the text attributes.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderTextAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      if (!this.ShouldRenderText)
        return;
      string text = this.Text;
      if (!(!string.IsNullOrEmpty(text) | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeText("VLB", text);
      if (!this.IsLink)
        return;
      objAttributeWriter.WriteAttributeText("TX", text);
    }

    /// <summary>Renders the link state attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderLinkStateAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      bool isLink = this.IsLink;
      if (!(isLink | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeText("LS", isLink ? "1" : "0");
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeActiveLinkColor() => false;

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeLinkColor() => false;

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeVisitedLinkColor() => false;
  }
}
