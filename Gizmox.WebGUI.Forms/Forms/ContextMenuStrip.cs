// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextMenuStrip
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a shortcut menu. </summary>
  [DefaultEvent("Opening")]
  [ComVisible(true)]
  [SRDescription("DescriptionContextMenuStrip")]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ContextMenuStrip), "ContextMenuStrip_45.bmp")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class ContextMenuStrip : ToolStripDropDownMenu
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> class and associates it with the specified container.</summary>
    /// <param name="container">A component that implements <see cref="T:System.ComponentModel.IContainer"></see> that is the container of the <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see>.</param>
    public ContextMenuStrip(IContainer container)
    {
      if (container == null)
        throw new ArgumentNullException(nameof (container));
      container.Add((IComponent) this);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> class. </summary>
    public ContextMenuStrip()
    {
    }

    /// <summary>Gets or sets the border color.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override BorderColor BorderColor
    {
      get => base.BorderColor;
      set => base.BorderColor = value;
    }

    /// <summary>Gets or sets the border style.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override BorderStyle BorderStyle
    {
      get => base.BorderStyle;
      set => base.BorderStyle = value;
    }

    /// <summary>Gets or sets the thickness of the border.</summary>
    /// <value>Gets or sets a border thickness.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override BorderWidth BorderWidth
    {
      get => base.BorderWidth;
      set => base.BorderWidth = value;
    }

    /// <summary>
    /// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.
    /// </summary>
    /// <value></value>
    /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public override ToolStripItemCollection Items => base.Items;

    /// <summary>Gets the last control that caused this <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> to be displayed.</summary>
    /// <returns>The control that caused this <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> to be displayed.</returns>
    [SRDescription("ContextMenuStripSourceControlDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Control SourceControl
    {
      get
      {
        sourceControl = (Control) null;
        Component component = this.SourceComponentInternal;
        while (true)
        {
          switch (component)
          {
            case null:
            case Control sourceControl:
              goto label_3;
            default:
              component = component.InternalParent;
              continue;
          }
        }
label_3:
        return sourceControl;
      }
    }

    /// <summary>Draggable indication is disabled for ContextMenuStrip</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override DraggableOptions Draggable
    {
      get => (DraggableOptions) null;
      set
      {
      }
    }
  }
}
