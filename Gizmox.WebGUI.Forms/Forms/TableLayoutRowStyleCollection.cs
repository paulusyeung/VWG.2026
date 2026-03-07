// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutRowStyleCollection
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
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class TableLayoutRowStyleCollection : TableLayoutStyleCollection, IObservableList
  {
    internal TableLayoutRowStyleCollection(IArrangedElement objOwner)
      : base(objOwner)
    {
    }

    internal TableLayoutRowStyleCollection()
      : base((IArrangedElement) null)
    {
    }

    internal override string PropertyName => PropertyNames.RowStyles;

    /// <summary>
    /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutStyle" /> at the specified index.
    /// </summary>
    /// <value></value>
    public RowStyle this[int index]
    {
      get => (RowStyle) base[index];
      set => this[index] = value;
    }

    /// <summary>Adds the specified row style.</summary>
    /// <param name="objRowStyle">The row style.</param>
    /// <returns></returns>
    public int Add(RowStyle objRowStyle)
    {
      if (this.ObservableItemAdded != null)
        this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objRowStyle));
      return ((IList) this).Add((object) objRowStyle);
    }

    /// <summary>Adds a row style.</summary>
    /// <param name="intHeight"></param>
    /// <returns></returns>
    public int Add(int intHeight)
    {
      RowStyle rowStyle = new RowStyle(intHeight.ToString());
      if (this.ObservableItemAdded != null)
        this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) rowStyle));
      return this.Add(rowStyle);
    }

    /// <summary>
    /// Determines whether [contains] [the specified row style].
    /// </summary>
    /// <param name="objRowStyle">The row style.</param>
    /// <returns>
    /// 	<c>true</c> if [contains] [the specified row style]; otherwise, <c>false</c>.
    /// </returns>
    public bool Contains(RowStyle objRowStyle) => ((IList) this).Contains((object) objRowStyle);

    /// <summary>Indexes the of.</summary>
    /// <param name="objRowStyle">The row style.</param>
    /// <returns></returns>
    public int IndexOf(RowStyle objRowStyle) => ((IList) this).IndexOf((object) objRowStyle);

    /// <summary>Inserts the specified index.</summary>
    /// <param name="intIndex">The index.</param>
    /// <param name="objRowStyle">The row style.</param>
    public void Insert(int intIndex, RowStyle objRowStyle)
    {
      if (this.ObservableItemInserted != null)
        this.ObservableItemInserted((object) this, new ObservableListEventArgs((object) objRowStyle));
      ((IList) this).Insert(intIndex, (object) objRowStyle);
    }

    /// <summary>Removes the specified row style.</summary>
    /// <param name="objRowStyle">The row style.</param>
    public void Remove(RowStyle objRowStyle)
    {
      if (this.ObservableItemRemoved != null)
        this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) objRowStyle));
      ((IList) this).Remove((object) objRowStyle);
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
