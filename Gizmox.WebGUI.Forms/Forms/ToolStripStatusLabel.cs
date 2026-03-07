// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripStatusLabel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a panel in a <see cref="T:System.Windows.Forms.StatusStrip"></see> control. </summary>
  [Skin(typeof (ToolStripStatusLabelSkin))]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripStatusLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
  [Serializable]
  public class ToolStripStatusLabel : ToolStripLabel
  {
    private static readonly SerializableProperty menmBorderSidesProperty = SerializableProperty.Register(nameof (menmBorderSides), typeof (ToolStripStatusLabelBorderSides), typeof (ToolStripStatusLabel));
    private static readonly SerializableProperty mblnSpringProperty = SerializableProperty.Register(nameof (mblnSpring), typeof (bool), typeof (ToolStripStatusLabel));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class. </summary>
    public ToolStripStatusLabel()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified text.</summary>
    /// <param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    public ToolStripStatusLabel(string text)
      : base(text, (ResourceHandle) null, false, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image. </summary>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    public ToolStripStatusLabel(ResourceHandle image)
      : base((string) null, image, false, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image and text.</summary>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    /// <param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    public ToolStripStatusLabel(string text, ResourceHandle image)
      : base(text, image, false, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class that displays the specified image and text, and that carries out the specified action when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary>
    /// <param name="onClick">Specifies the action to carry out when the control is clicked.</param>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    /// <param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    public ToolStripStatusLabel(string text, ResourceHandle image, EventHandler onClick)
      : base(text, image, false, onClick, (string) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> class with the specified name that displays the specified image and text, and that carries out the specified action when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary>
    /// <param name="onClick">Specifies the action to carry out when the control is clicked.</param>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    /// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> that is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    /// <param name="text">A <see cref="T:System.String"></see> representing the text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</param>
    public ToolStripStatusLabel(
      string text,
      ResourceHandle image,
      EventHandler onClick,
      string name)
      : base(text, image, false, onClick, (string) null)
    {
    }

    private ToolStripStatusLabelBorderSides menmBorderSides
    {
      get => this.GetValue<ToolStripStatusLabelBorderSides>(ToolStripStatusLabel.menmBorderSidesProperty);
      set => this.SetValue<ToolStripStatusLabelBorderSides>(ToolStripStatusLabel.menmBorderSidesProperty, value);
    }

    private bool mblnSpring
    {
      get => this.GetValue<bool>(ToolStripStatusLabel.mblnSpringProperty);
      set => this.SetValue<bool>(ToolStripStatusLabel.mblnSpringProperty, value);
    }

    /// <summary>Gets or sets a value that determines where the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> is aligned on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public new ToolStripItemAlignment Alignment
    {
      get => base.Alignment;
      set => base.Alignment = value;
    }

    /// <summary>Gets or sets a value that indicates which sides of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> show borders.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabelBorderSides"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripStatusLabelBorderSides.None"></see>.</returns>
    [DefaultValue(ToolStripStatusLabelBorderSides.None)]
    [SRDescription("ToolStripStatusLabelBorderSidesDescr")]
    [SRCategory("CatAppearance")]
    public ToolStripStatusLabelBorderSides BorderSides
    {
      get => this.menmBorderSides;
      set
      {
        if (this.menmBorderSides == value)
          return;
        this.menmBorderSides = value;
        this.Invalidate();
      }
    }

    /// <summary>Gets or sets the border style of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Border3DStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Border3DStyle.Flat"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value of <see cref="P:Gizmox.WebGUI.Forms.ToolStripStatusLabel.BorderStyle"></see> is not one of the <see cref="T:Gizmox.WebGUI.Forms.Border3DStyle"></see> values.</exception>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Border3DStyle BorderStyle
    {
      get => Border3DStyle.Flat;
      set
      {
      }
    }

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected override int ToolStripItemType => 6;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> automatically fills the available space on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> as the form is resized. </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> automatically fills the available space on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> as the form is resized; otherwise, false. The default is false.</returns>
    [DefaultValue(false)]
    [SRDescription("ToolStripStatusLabelSpringDescr")]
    [SRCategory("CatAppearance")]
    public bool Spring
    {
      get => this.mblnSpring;
      set
      {
        if (this.mblnSpring == value)
          return;
        this.mblnSpring = value;
      }
    }
  }
}
