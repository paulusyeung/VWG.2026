// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ExtendedColumnHeaders
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [ToolboxItem(false)]
  [Serializable]
  public class ExtendedColumnHeaders
  {
    private bool mblnExtendedColumnHeaderVisible;
    private ObservableCollection<ExtendedHeaderRowData> mobjExtendedHeaderRows;
    private DataGridView mobjDataGridView;
    private ObservableCollection<ExtendedHeaderUserControl> mobjHeaderControls;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ExtendedColumnHeaders" /> class.
    /// </summary>
    /// <param name="objDataGridView">The obj data grid view.</param>
    public ExtendedColumnHeaders(DataGridView objDataGridView)
    {
      this.mobjDataGridView = objDataGridView;
      this.InitRowsData();
    }

    /// <summary>Inits the rows data.</summary>
    private void InitRowsData()
    {
      this.mobjExtendedHeaderRows = new ObservableCollection<ExtendedHeaderRowData>();
      this.mobjExtendedHeaderRows.CollectionChanged += new NotifyCollectionChangedEventHandler(this.mobjExtendedHeaderRows_CollectionChanged);
    }

    /// <summary>
    /// Handles the CollectionChanged event of the mobjExtendedHeaderRows control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
    private void mobjExtendedHeaderRows_CollectionChanged(
      object sender,
      NotifyCollectionChangedEventArgs e)
    {
      if (this.mobjDataGridView == null)
        return;
      this.mobjDataGridView.Update();
    }

    /// <summary>
    /// Gets or sets a value indicating whether [extended column header visible].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [extended column header visible]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool ShowExtendedColumnHeader
    {
      get => this.mblnExtendedColumnHeaderVisible;
      set
      {
        if (this.mblnExtendedColumnHeaderVisible == value)
          return;
        this.mblnExtendedColumnHeaderVisible = value;
        this.mobjDataGridView.Update();
      }
    }

    /// <summary>
    /// Gets or sets the extended header rows data and number.
    /// </summary>
    /// <value>The extended header rows.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ObservableCollection<ExtendedHeaderRowData> Rows
    {
      get => this.mobjExtendedHeaderRows;
      set => this.mobjExtendedHeaderRows = value;
    }

    /// <summary>
    /// Gets or sets the extended column header cell panels main collection.
    /// </summary>
    /// <value>The extended column header cell panels.</value>
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public ObservableCollection<ExtendedHeaderUserControl> HeaderControls
    {
      get
      {
        if (this.mobjHeaderControls == null)
        {
          this.mobjHeaderControls = new ObservableCollection<ExtendedHeaderUserControl>();
          this.mobjHeaderControls.CollectionChanged += new NotifyCollectionChangedEventHandler(this.mobjHeaderControls_CollectionChanged);
        }
        return this.mobjHeaderControls;
      }
    }

    /// <summary>
    /// Handles the CollectionChanged event of the mobjHeaderControls control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
    private void mobjHeaderControls_CollectionChanged(
      object sender,
      NotifyCollectionChangedEventArgs e)
    {
      DataGridView dataGridView = (DataGridView) null;
      if (e.Action == NotifyCollectionChangedAction.Add)
        dataGridView = this.mobjDataGridView;
      if (e.NewItems == null)
        return;
      foreach (ExtendedHeaderUserControl newItem in (IEnumerable) e.NewItems)
        newItem.ParentGrid = dataGridView;
    }
  }
}
