// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownButton
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
  /// <summary>Represents a control that when clicked displays an associated <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> from which the user can select a single item.</summary>
  [Skin(typeof (ToolStripDropDownButtonSkin))]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip | ToolStripItemDesignerAvailability.ToolStrip)]
  [Serializable]
  public class ToolStripDropDownButton : ToolStripDropDownItem
  {
    private static readonly SerializableProperty mblnShowDropDownArrowProperty = SerializableProperty.Register(nameof (mblnShowDropDownArrow), typeof (bool), typeof (ToolStripDropDownButton));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class. </summary>
    public ToolStripDropDownButton() => this.mblnShowDropDownArrow = true;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text.</summary>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    public ToolStripDropDownButton(string text)
      : base(text, (ResourceHandle) null, (EventHandler) null)
    {
      this.mblnShowDropDownArrow = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified image.</summary>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    public ToolStripDropDownButton(ResourceHandle image)
      : base((string) null, image, (EventHandler) null)
    {
      this.mblnShowDropDownArrow = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text and image.</summary>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    public ToolStripDropDownButton(string text, ResourceHandle image)
      : base(text, image, (EventHandler) null)
    {
      this.mblnShowDropDownArrow = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text and image and raises the Click event.</summary>
    /// <param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event.</param>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    public ToolStripDropDownButton(string text, ResourceHandle image, EventHandler onClick)
      : base(text, image, onClick)
    {
      this.mblnShowDropDownArrow = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that has the specified name, displays the specified text and image, and raises the Click event.</summary>
    /// <param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event.</param>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    public ToolStripDropDownButton(
      string text,
      ResourceHandle image,
      EventHandler onClick,
      string name)
      : base(text, image, onClick, (string) null)
    {
      this.mblnShowDropDownArrow = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class.</summary>
    /// <param name="dropDownItems">An array of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> containing the items of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
    public ToolStripDropDownButton(
      string text,
      ResourceHandle image,
      ToolStripItem[] dropDownItems)
      : base(text, image, dropDownItems)
    {
      this.mblnShowDropDownArrow = true;
    }

    private bool mblnShowDropDownArrow
    {
      get => this.GetValue<bool>(ToolStripDropDownButton.mblnShowDropDownArrowProperty);
      set => this.SetValue<bool>(ToolStripDropDownButton.mblnShowDropDownArrowProperty, value);
    }

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected override int ToolStripItemType => 3;

    /// <summary>Gets or sets a value indicating whether to use the Text property or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ToolTipText"></see> property for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> ToolTip.</summary>
    /// <returns>true to use the <see cref="P:Gizmox.WebGUI.Forms.Control.Text"></see> property for the ToolTip; otherwise, false. The default is true.</returns>
    [DefaultValue(true)]
    public new bool AutoToolTip
    {
      get => base.AutoToolTip;
      set => base.AutoToolTip = value;
    }

    /// <summary>Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default.</summary>
    /// <returns>true in all cases.</returns>
    protected override bool DefaultAutoToolTip => true;

    /// <summary>Gets or sets a value indicating whether an arrow is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>, which indicates that further options are available in a drop-down list.</summary>
    /// <returns>true to show an arrow on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripDropDownButtonShowDropDownArrowDescr")]
    [DefaultValue(true)]
    public bool ShowDropDownArrow
    {
      get => this.mblnShowDropDownArrow;
      set
      {
        if (this.mblnShowDropDownArrow == value)
          return;
        this.mblnShowDropDownArrow = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripItem.MouseDown"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
      this.ShowDropDown();
      base.OnMouseDown(e);
    }

    /// <summary>Gets the size of the preferred.</summary>
    /// <param name="objConstrainingSize">Size of the obj constraining.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objConstrainingSize)
    {
      Size size = this.GetPreferredeSizeByText();
      if (SkinFactory.GetSkin((ISkinable) this) is ButtonSkin skin && this.ShowDropDownArrow)
      {
        size.Width += skin.DropDownImageWidth;
        size.Height = Math.Max(size.Height, skin.DropDownImageHeight);
      }
      size = this.GetPreferredSizeByImage(size);
      return this.GetPreferredSizeByButtonSkin(skin, size);
    }

    /// <summary>Renders the tool strip item's attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    protected override void RenderToolStripItemAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter)
    {
      base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
      this.RenderShowDropDownArrowAttribute(objAttributeWriter, false);
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
      this.RenderShowDropDownArrowAttribute(objAttributeWriter, true);
    }

    /// <summary>Renders the show drop down arrow attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowDropDownArrowAttribute(
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      bool showDropDownArrow = this.ShowDropDownArrow;
      if (!(!showDropDownArrow | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeString("SDA", showDropDownArrow ? "1" : "0");
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DropDownItems.Count > 0)
        criticalEventsData.Set("CL");
      return criticalEventsData;
    }
  }
}
