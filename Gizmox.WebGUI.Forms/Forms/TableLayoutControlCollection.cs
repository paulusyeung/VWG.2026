// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutControlCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [ListBindable(false)]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class TableLayoutControlCollection : Control.ControlCollection, IObservableList
  {
    private TableLayoutPanel mobjContainer;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutControlCollection" /> class.
    /// </summary>
    /// <param name="objContainer">The container.</param>
    public TableLayoutControlCollection(TableLayoutPanel objContainer)
      : base((Control) objContainer)
    {
      this.mobjContainer = objContainer;
    }

    /// <summary>Gets the container.</summary>
    /// <value>The container.</value>
    public TableLayoutPanel Container => this.mobjContainer;

    /// <summary>Adds the specified control.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intColumn">The column.</param>
    /// <param name="intRow">The row.</param>
    public virtual void Add(Control objControl, int intColumn, int intRow)
    {
      if (this.ObservableItemAdded != null)
        this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objControl));
      this.Add(objControl);
      this.mobjContainer.SetColumn(objControl, intColumn);
      this.mobjContainer.SetRow(objControl, intRow);
    }

    /// <summary>Occurs when [observable item added].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event ObservableListEventHandler ObservableItemAdded;

    /// <summary>Occurs when [observable item inserted].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event ObservableListEventHandler ObservableItemInserted;

    /// <summary>Occurs when [observable item removed].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event ObservableListEventHandler ObservableItemRemoved;

    /// <summary>Occurs when [observable list cleared].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler ObservableListCleared;
  }
}
