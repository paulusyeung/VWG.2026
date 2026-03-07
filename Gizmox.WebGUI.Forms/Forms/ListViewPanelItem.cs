// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewPanelItem
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a list view item that can have a panel</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ListViewPanelItem : ListViewItem
  {
    /// <summary>The panel control</summary>
    private Control mobjPanel;

    /// <summary>Gets or sets the panel.</summary>
    /// <value>The panel.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control Panel => this.mobjPanel;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
    /// </summary>
    /// <param name="objPanel">The panel control.</param>
    public ListViewPanelItem(Control objPanel) => this.SetItemPanel(objPanel);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
    /// </summary>
    /// <param name="objPanel">The panel control.</param>
    /// <param name="strText">The text of the first sub item.</param>
    public ListViewPanelItem(Control objPanel, string strText)
      : base(strText)
    {
      this.SetItemPanel(objPanel);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
    /// </summary>
    /// <param name="objPanel">The panel control.</param>
    /// <param name="arrItems">The sub items.</param>
    public ListViewPanelItem(Control objPanel, string[] arrItems)
      : base(arrItems)
    {
      this.SetItemPanel(objPanel);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
    /// </summary>
    /// <param name="objPanel">The panel control.</param>
    /// <param name="strText">The text of the first sub item.</param>
    /// <param name="intImageIndex">The index of the image in the image list.</param>
    public ListViewPanelItem(Control objPanel, string strText, int intImageIndex)
      : base(strText, intImageIndex)
    {
      this.SetItemPanel(objPanel);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
    /// </summary>
    /// <param name="objPanel">The panel control.</param>
    /// <param name="arrItems">The sub items.</param>
    /// <param name="intImageIndex">The index of the image in the image list.</param>
    public ListViewPanelItem(Control objPanel, string[] arrItems, int intImageIndex)
      : base(arrItems, intImageIndex)
    {
      this.SetItemPanel(objPanel);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
    /// </summary>
    /// <param name="objPanel">The panel control.</param>
    /// <param name="arrSubItems">The sub items.</param>
    /// <param name="intImageIndex">The index of the image in the image list.</param>
    public ListViewPanelItem(
      Control objPanel,
      ListViewItem.ListViewSubItem[] arrSubItems,
      int intImageIndex)
      : base(arrSubItems, intImageIndex)
    {
      this.SetItemPanel(objPanel);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
    /// </summary>
    /// <param name="objPanel">The panel.</param>
    /// <param name="arrItems">The items.</param>
    /// <param name="intImageIndex">Index of the int image.</param>
    /// <param name="objForeColor">Color of the obj fore.</param>
    /// <param name="objBackColor">Color of the obj back.</param>
    /// <param name="objFont">The obj font.</param>
    public ListViewPanelItem(
      Control objPanel,
      string[] arrItems,
      int intImageIndex,
      Color objForeColor,
      Color objBackColor,
      Font objFont)
      : base(arrItems, intImageIndex, objForeColor, objBackColor, objFont)
    {
      this.SetItemPanel(objPanel);
    }

    /// <summary>Set the item panel</summary>
    /// <param name="objPanel"></param>
    private void SetItemPanel(Control objPanel)
    {
      if (objPanel == null)
        throw new ArgumentException("ListViewItem panel cannot be null.", nameof (objPanel));
      objPanel.Dock = DockStyle.Top;
      objPanel.TabIndex = 1;
      this.mobjPanel = objPanel;
    }

    /// <summary>Renders the dirty item.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objProcessor">The processor.</param>
    /// <param name="lngRequestID">The request id.</param>
    internal override void RenderDirtyItem(
      IContext objContext,
      IResponseWriter objWriter,
      ListView.ItemRenderingProcessor objProcessor,
      long lngRequestID)
    {
      base.RenderDirtyItem(objContext, objWriter, objProcessor, lngRequestID);
      if (objProcessor.View != View.Details)
        return;
      if (objProcessor.FullListRedraw)
      {
        objWriter.WriteStartElement("LVP");
        ((IRenderableComponent) this.Panel).RenderComponent(objContext, objWriter, lngRequestID);
        objWriter.WriteEndElement();
      }
      else
        ((IRenderableComponent) this.Panel).RenderComponent(objContext, objWriter, lngRequestID);
    }
  }
}
