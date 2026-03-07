// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.GridEntryCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class GridEntryCollection : GridItemCollection
  {
    private GridEntry mobjOwner;

    public GridEntryCollection(GridEntry objOwner, GridEntry[] arrEntries)
      : base((GridItem[]) arrEntries)
    {
      this.mobjOwner = objOwner;
    }

    /// <summary>Adds the range.</summary>
    /// <param name="arrValues">The arr values.</param>
    public void AddRange(GridEntry[] arrValues)
    {
      if (arrValues == null)
        throw new ArgumentNullException("value");
      if (this.marrEntries != null)
      {
        GridEntry[] gridEntryArray = new GridEntry[this.marrEntries.Length + arrValues.Length];
        this.marrEntries.CopyTo((Array) gridEntryArray, 0);
        arrValues.CopyTo((Array) gridEntryArray, this.marrEntries.Length);
        this.marrEntries = (GridItem[]) gridEntryArray;
      }
      else
        this.marrEntries = (GridItem[]) arrValues.Clone();
      this.mobjOwner.OwnerGrid.RegisterGridComponents((ICollection) this.marrEntries);
    }

    public void Clear()
    {
      this.mobjOwner.OwnerGrid.UnRegisterGridComponents((ICollection) this.marrEntries);
      this.marrEntries = (GridItem[]) new GridEntry[0];
    }

    public void CopyTo(Array objDestinationArray, int index) => this.marrEntries.CopyTo(objDestinationArray, index);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool blnDisposing)
    {
      if (!blnDisposing || this.mobjOwner == null || this.marrEntries == null)
        return;
      for (int index = 0; index < this.marrEntries.Length; ++index)
      {
        if (this.marrEntries[index] != null)
        {
          ((GridEntry) this.marrEntries[index]).Dispose();
          this.marrEntries[index] = (GridItem) null;
        }
      }
      this.marrEntries = (GridItem[]) new GridEntry[0];
    }

    ~GridEntryCollection() => this.Dispose(false);

    internal GridEntry GetEntry(int index) => (GridEntry) this.marrEntries[index];

    internal int GetEntry(GridEntry objChild) => Array.IndexOf<GridItem>(this.marrEntries, (GridItem) objChild);
  }
}
