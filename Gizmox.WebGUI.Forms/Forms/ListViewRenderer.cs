// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides support for rendering a ListView control</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class ListViewRenderer : ControlRenderer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewRenderer" /> class.
    /// </summary>
    /// <param name="objListView">The ListView control.</param>
    public ListViewRenderer(ListView objListView)
      : base((Control) objListView)
    {
    }

    /// <summary>Renders the content.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
    {
      if (!(this.Control is ListView control) || control.View != View.Details)
        return;
      this.RenderDetailsViewContent(objContext, objGraphics, control);
    }

    /// <summary>Renders the content of the details view.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    private void RenderDetailsViewContent(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ListView objListView)
    {
      Rectangle rectangle = ControlRenderer.GetContentRegion((Control) objListView);
      if (!(objListView.Skin is ListViewSkin skin))
        return;
      ListView.ColumnHeaderCollection columns = objListView.Columns;
      if (columns == null)
        return;
      if (objListView.HeaderStyle != ColumnHeaderStyle.None)
      {
        rectangle = ControlRenderer.DockInRegion(rectangle, DockStyle.Top, this.RenderHeaders(objContext, objGraphics, skin, objListView, columns, rectangle));
        if (!ControlRenderer.IsVisibleRegion(rectangle))
          return;
      }
      foreach (ListViewItem objListViewItem in objListView.Items)
      {
        rectangle = ControlRenderer.DockInRegion(rectangle, DockStyle.Top, this.RenderDetailsItem(objContext, objGraphics, skin, objListView, objListViewItem, columns, rectangle));
        if (!ControlRenderer.IsVisibleRegion(rectangle))
          break;
      }
    }

    /// <summary>Renders the details item.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objListViewSkin">The list view skin.</param>
    /// <param name="objListView">The list view.</param>
    /// <param name="objListViewItem">The list view item.</param>
    /// <param name="objColumns">The columns.</param>
    /// <param name="objContentRegion">The content region.</param>
    /// <returns></returns>
    private Rectangle RenderDetailsItem(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ListViewSkin objListViewSkin,
      ListView objListView,
      ListViewItem objListViewItem,
      ListView.ColumnHeaderCollection objColumns,
      Rectangle objContentRegion)
    {
      int height = 20;
      Rectangle rectangle = new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, height));
      int intIndex = 0;
      foreach (ListViewItem.ListViewSubItem subItem in objListViewItem.SubItems)
      {
        if (objColumns.Count > intIndex)
          rectangle = ControlRenderer.DockInRegion(rectangle, DockStyle.Left, this.RenderDetailsSubItem(objContext, objGraphics, objListViewSkin, objListView, objColumns[intIndex], subItem, rectangle));
        ++intIndex;
      }
      return new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, height));
    }

    /// <summary>Renders the details sub item.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objListViewSkin">The list view skin.</param>
    /// <param name="objListView">The list view.</param>
    /// <param name="objColumnHeader">The column header.</param>
    /// <param name="objSubItem">The sub item.</param>
    /// <param name="objItemsRegion">The items region.</param>
    /// <returns></returns>
    private Rectangle RenderDetailsSubItem(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ListViewSkin objListViewSkin,
      ListView objListView,
      ColumnHeader objColumnHeader,
      ListViewItem.ListViewSubItem objSubItem,
      Rectangle objItemsRegion)
    {
      Rectangle objRegion = new Rectangle(objItemsRegion.Location, new Size(objColumnHeader.Width, objItemsRegion.Height));
      StyleValue cellNormalStyle = objListViewSkin.CellNormalStyle;
      ControlRenderer.RenderStyle(objContext, objGraphics, (Skin) objListViewSkin, cellNormalStyle, objRegion);
      if (objColumnHeader.Type == ListViewColumnType.Text)
        ControlRenderer.RenderText(objContext, objGraphics, objSubItem.Text, cellNormalStyle.Font, cellNormalStyle.ForeColor, objRegion, ContentAlignment.MiddleLeft, false);
      return objRegion;
    }

    /// <summary>Renders the headers.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objListViewSkin">The list view skin.</param>
    /// <param name="objListView">The list view.</param>
    /// <param name="objColumns">The columns.</param>
    /// <param name="objContentRegion">The content region.</param>
    /// <returns></returns>
    private Rectangle RenderHeaders(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ListViewSkin objListViewSkin,
      ListView objListView,
      ListView.ColumnHeaderCollection objColumns,
      Rectangle objContentRegion)
    {
      int headerHeight = objListViewSkin.HeaderHeight;
      Rectangle rectangle = new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, headerHeight));
      foreach (ColumnHeader objColumn in objColumns)
        rectangle = ControlRenderer.DockInRegion(rectangle, DockStyle.Left, this.RenderHeader(objContext, objGraphics, objListViewSkin, objListView, objColumn, rectangle));
      return new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, headerHeight));
    }

    /// <summary>Renders the headers.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objListViewSkin">The list view skin.</param>
    /// <param name="objListView">The list view.</param>
    /// <param name="objColumnHeader">The column header.</param>
    /// <returns></returns>
    private Rectangle RenderHeader(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ListViewSkin objListViewSkin,
      ListView objListView,
      ColumnHeader objColumnHeader,
      Rectangle objHeadersRegion)
    {
      Rectangle objRegion = new Rectangle(objHeadersRegion.Location, new Size(objColumnHeader.Width, objHeadersRegion.Height));
      StyleValue headerNormalStyle = objListViewSkin.HeaderNormalStyle;
      ControlRenderer.RenderStyle(objContext, objGraphics, (Skin) objListViewSkin, headerNormalStyle, objRegion);
      ControlRenderer.RenderText(objContext, objGraphics, objColumnHeader.Text, headerNormalStyle.Font, headerNormalStyle.ForeColor, objRegion, ContentAlignment.MiddleCenter, false);
      return objRegion;
    }
  }
}
