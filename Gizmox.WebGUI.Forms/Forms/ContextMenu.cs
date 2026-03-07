// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextMenu
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>ContextMenu Class</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ContextMenu), "ContextMenu_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DesignTimeVisible(true)]
  [ToolboxItemCategory("Menus & Toolbars")]
  [Serializable]
  public class ContextMenu : Menu, IContextMenu
  {
    public new event EventHandler Collapse;

    /// <summary>
    /// Raises the <see cref="E:Collapse" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected internal virtual void OnCollapse(EventArgs e)
    {
      EventHandler collapse = this.Collapse;
      if (collapse == null)
        return;
      collapse((object) this, e);
    }

    /// <summary>
    /// Gets a value indicating whether the collapse event is registered.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if the collapse event is registered; otherwise, <c>false</c>.
    /// </value>
    internal bool RegisteredCollapseEvent => this.Collapse != null;

    /// <summary>Gets the source control.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ContextMenuSourceControlDescr")]
    [Browsable(false)]
    public Control SourceControl
    {
      get
      {
        sourceControl = (Control) null;
        Component component = this.Owner;
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
  }
}
