// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MenuStrip
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
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides a menu system for a form.</summary>
  /// <filterpriority>1</filterpriority>
  [Gizmox.WebGUI.Forms.MetadataTag("MSP")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MenuStripSkin))]
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [SRDescription("DescriptionMenuStrip")]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (StatusStrip), "MenuStrip_45.bmp")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class MenuStrip : ToolStrip
  {
    /// <summary>
    /// 
    /// </summary>
    private static readonly SerializableProperty mblnShowDropDownItemsOnEnterProperty = SerializableProperty.Register(nameof (mblnShowDropDownItemsOnEnter), typeof (bool), typeof (MenuStrip), new SerializablePropertyMetadata((object) false));

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.MenuStrip"></see> class. </summary>
    public MenuStrip()
    {
      this.CanOverflow = false;
      this.GripStyle = ToolStripGripStyle.Hidden;
      this.Stretch = true;
    }

    /// <summary>
    /// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.
    /// </summary>
    /// <value></value>
    /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public override ToolStripItemCollection Items => base.Items;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.MenuStrip"></see> supports overflow functionality. </summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.MenuStrip"></see> supports overflow functionality; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [SRDescription("ToolStripCanOverflowDescr")]
    [SRCategory("CatLayout")]
    [DefaultValue(false)]
    public new bool CanOverflow
    {
      get => base.CanOverflow;
      set => base.CanOverflow = value;
    }

    /// <summary>Gets the default spacing, in pixels, between the sizing grip and the edges of the <see cref="T:System.Windows.Forms.MenuStrip"></see>.</summary>
    /// <returns><see cref="T:System.Windows.Forms.Padding"></see> values representing the spacing, in pixels.</returns>
    protected override Padding DefaultGripMargin => new Padding(2, 2, 0, 2);

    /// <summary>Gets the spacing, in pixels, between the left, right, top, and bottom edges of the <see cref="T:System.Windows.Forms.MenuStrip"></see> from the edges of the form.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> that represents the spacing. The default is {Left=6, Top=2, Right=0, Bottom=2}.</returns>
    protected override Padding DefaultPadding => this.Skin is MenuStripSkin skin ? (this.GripStyle == ToolStripGripStyle.Visible ? (Padding) skin.PaddingWithGrip : (Padding) skin.PaddingWithOutGrip) : (this.GripStyle == ToolStripGripStyle.Visible ? new Padding(3, 2, 0, 2) : new Padding(6, 2, 0, 2));

    /// <summary>
    /// Gets a value indicating whether strip supports menu stickiness.
    /// </summary>
    /// <value><c>true</c> if [supports stickiness]; otherwise, <c>false</c>.</value>
    protected override bool SupportMenuStickiness => true;

    /// <summary>
    /// Gets or sets a value indicating whether [show items drop down on enter].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [show items drop down on enter]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool ShowDropDownItemsOnEnter
    {
      get => this.mblnShowDropDownItemsOnEnter;
      set
      {
        if (this.mblnShowDropDownItemsOnEnter == value)
          return;
        this.mblnShowDropDownItemsOnEnter = value;
        this.UpdateParams(AttributeType.Extended);
      }
    }

    /// <summary>Gets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see> by default.</summary>
    /// <returns>false in all cases.</returns>
    protected override bool DefaultShowItemToolTips => false;

    /// <summary>Gets the horizontal and vertical dimensions, in pixels, of the <see cref="T:System.Windows.Forms.MenuStrip"></see> when it is first created.</summary>
    /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> value representing the <see cref="T:System.Windows.Forms.MenuStrip"></see> horizontal and vertical dimensions, in pixels. The default is 200 x 21 pixels.</returns>
    protected override Size DefaultSize => new Size(200, 24);

    /// <summary>Gets or sets the visibility of the grip used to reposition the control.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripGripStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripGripStyle.Hidden"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(ToolStripGripStyle.Hidden)]
    public new ToolStripGripStyle GripStyle
    {
      get => base.GripStyle;
      set => base.GripStyle = value;
    }

    /// <summary>Gets or sets the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> that is used to display a list of Multiple-document interface (MDI) child forms.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> that represents the menu item displaying a list of MDI child forms that are open in the application.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripMenuItem MdiWindowListItem
    {
      get => (ToolStripMenuItem) null;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see>. </summary>
    /// <returns>true if ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see>; otherwise, false. The default is false.</returns>
    [SRDescription("ToolStripShowItemToolTipsDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public new bool ShowItemToolTips
    {
      get => base.ShowItemToolTips;
      set => base.ShowItemToolTips = value;
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.MenuStrip"></see> stretches from end to end in its container. </summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.MenuStrip"></see> stretches from end to end in its container; otherwise, false. The default is true.</returns>
    [SRDescription("ToolStripStretchDescr")]
    [DefaultValue(true)]
    [SRCategory("CatLayout")]
    public new bool Stretch
    {
      get => base.Stretch;
      set => base.Stretch = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [MBLN show items drop down on enter].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [MBLN show items drop down on enter]; otherwise, <c>false</c>.
    /// </value>
    private bool mblnShowDropDownItemsOnEnter
    {
      get => this.GetValue<bool>(MenuStrip.mblnShowDropDownItemsOnEnterProperty);
      set => this.SetValue<bool>(MenuStrip.mblnShowDropDownItemsOnEnterProperty, value);
    }

    /// <summary>Occurs when the user accesses the menu with the keyboard or mouse. </summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler MenuActivate;

    /// <summary>Occurs when the <see cref="T:System.Windows.Forms.MenuStrip"></see> is deactivated.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler MenuDeactivate;

    /// <summary>Creates a <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> with the specified text, image, and event handler on a new <see cref="T:System.Windows.Forms.MenuStrip"></see>.</summary>
    /// <returns>A <see cref="M:System.Windows.Forms.ToolStripMenuItem.#ctor(System.String,System.Drawing.Image,System.EventHandler)"></see>, or a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see> if the text parameter is a hyphen (-).</returns>
    /// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.Control.Click"></see> event when the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> is clicked.</param>
    /// <param name="image">The <see cref="T:System.Drawing.Image"></see> to display on the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>.</param>
    /// <param name="text">The text to use for the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>. If the text parameter is a hyphen (-), this method creates a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see>.</param>
    protected internal override ToolStripItem CreateDefaultItem(
      string text,
      ResourceHandle image,
      EventHandler onClick)
    {
      return text == "-" ? (ToolStripItem) new ToolStripSeparator() : (ToolStripItem) new ToolStripMenuItem(text, image, onClick);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.MenuStrip.MenuActivate"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnMenuActivate(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.MenuStrip.MenuDeactivate"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnMenuDeactivate(EventArgs e)
    {
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderShowDropDownItemsOnEnterAttribute(objWriter, false);
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Extended))
        return;
      this.RenderShowDropDownItemsOnEnterAttribute(objWriter, true);
    }

    /// <summary>Renders the show items drop down on enter attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowDropDownItemsOnEnterAttribute(
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      bool downItemsOnEnter = this.ShowDropDownItemsOnEnter;
      if (!(downItemsOnEnter | blnForceRender))
        return;
      objWriter.WriteAttributeString("SDOE", downItemsOnEnter ? "1" : "0");
    }
  }
}
