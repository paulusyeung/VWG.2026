// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutColumnStyleCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class TableLayoutColumnStyleCollection : TableLayoutStyleCollection, IObservableList
  {
    internal TableLayoutColumnStyleCollection(IArrangedElement objOwner)
      : base(objOwner)
    {
    }

    internal TableLayoutColumnStyleCollection()
      : base((IArrangedElement) null)
    {
    }

    internal override string PropertyName => PropertyNames.ColumnStyles;

    /// <summary>
    /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutStyle" /> at the specified index.
    /// </summary>
    /// <value></value>
    public ColumnStyle this[int index]
    {
      get => (ColumnStyle) base[index];
      set => this[index] = value;
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

    /// <summary>Adds the specified column style.</summary>
    /// <param name="objcolumnStyle">The column style.</param>
    /// <returns></returns>
    public int Add(ColumnStyle objcolumnStyle)
    {
      if (this.ObservableItemAdded != null)
        this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objcolumnStyle));
      return ((IList) this).Add((object) objcolumnStyle);
    }

    /// <summary>Adds a new column style.</summary>
    /// <param name="intWidth"></param>
    /// <returns></returns>
    public int Add(int intWidth)
    {
      ColumnStyle columnStyle = new ColumnStyle(intWidth.ToString());
      if (this.ObservableItemAdded != null)
        this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) columnStyle));
      return this.Add(columnStyle);
    }

    /// <summary>
    /// Determines whether [contains] [the specified column style].
    /// </summary>
    /// <param name="objcolumnStyle">The column style.</param>
    /// <returns>
    /// 	<c>true</c> if [contains] [the specified column style]; otherwise, <c>false</c>.
    /// </returns>
    public bool Contains(ColumnStyle objcolumnStyle) => ((IList) this).Contains((object) objcolumnStyle);

    /// <summary>Indexes the of.</summary>
    /// <param name="objcolumnStyle">The column style.</param>
    /// <returns></returns>
    public int IndexOf(ColumnStyle objcolumnStyle) => ((IList) this).IndexOf((object) objcolumnStyle);

    /// <summary>Inserts the specified index.</summary>
    /// <param name="intIndex">The index.</param>
    /// <param name="objcolumnStyle">The column style.</param>
    public void Insert(int intIndex, ColumnStyle objcolumnStyle)
    {
      if (this.ObservableItemInserted != null)
        this.ObservableItemInserted((object) this, new ObservableListEventArgs((object) objcolumnStyle));
      ((IList) this).Insert(intIndex, (object) objcolumnStyle);
    }

    /// <summary>Removes the specified column style.</summary>
    /// <param name="objcolumnStyle">The column style.</param>
    public void Remove(ColumnStyle objcolumnStyle)
    {
      if (this.ObservableItemRemoved != null)
        this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) objcolumnStyle));
      ((IList) this).Remove((object) objcolumnStyle);
    }
  }
}
