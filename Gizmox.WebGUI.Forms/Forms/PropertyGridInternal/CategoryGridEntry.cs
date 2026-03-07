// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.CategoryGridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class CategoryGridEntry : GridEntry
  {
    private static Hashtable mobjCategoryStates;
    /// <summary>The string property registration.</summary>
    private static readonly SerializableProperty NameProperty = SerializableProperty.Register(nameof (Name), typeof (string), typeof (CategoryGridEntry));

    /// <summary>Gets or sets the name.</summary>
    /// <value>The name.</value>
    internal string Name
    {
      get => this.GetValue<string>(CategoryGridEntry.NameProperty);
      set => this.SetValue<string>(CategoryGridEntry.NameProperty, value);
    }

    public CategoryGridEntry(
      PropertyGrid objOwnerGrid,
      GridEntry objParentGrid,
      string strName,
      GridEntry[] arrChildGridEntries)
      : base(objOwnerGrid, objParentGrid)
    {
      this.Name = strName;
      if (CategoryGridEntry.mobjCategoryStates == null)
        CategoryGridEntry.mobjCategoryStates = new Hashtable();
      lock (CategoryGridEntry.mobjCategoryStates)
      {
        if (!CategoryGridEntry.mobjCategoryStates.ContainsKey((object) strName))
          CategoryGridEntry.mobjCategoryStates.Add((object) strName, (object) true);
      }
      this.IsExpandable = true;
      for (int index = 0; index < arrChildGridEntries.Length; ++index)
        arrChildGridEntries[index].ParentGridEntry = (GridEntry) this;
      this.ChildCollection = new GridEntryCollection((GridEntry) this, arrChildGridEntries);
      lock (CategoryGridEntry.mobjCategoryStates)
        this.InternalExpanded = (bool) CategoryGridEntry.mobjCategoryStates[(object) strName];
      this.SetState(64, true);
    }

    protected override bool CreateChildren(bool blnDiffOldChildren) => true;

    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing && this.ChildCollection != null)
        this.ChildCollection = (GridEntryCollection) null;
      base.Dispose(blnDisposing);
    }

    public override void DisposeChildren()
    {
    }

    public override object GetChildValueOwner(GridEntry objChildGridEntry) => this.ParentGridEntry.GetChildValueOwner(objChildGridEntry);

    public override string GetPropertyTextValue(object objObject) => "";

    public override string GetTestingInfo() => "object = (" + this.FullLabel + "), Category = (" + this.PropertyLabel + ")";

    internal override bool NotifyChildValue(GridEntry objGridEntry, int intType) => this.mobjParentGridEntry.NotifyChildValue(objGridEntry, intType);

    public override bool Expandable => !this.GetStateSet(524288);

    public override GridItemType GridItemType => GridItemType.Category;

    internal override bool HasValue => false;

    public override string HelpKeyword => (string) null;

    internal override bool InternalExpanded
    {
      set
      {
        base.InternalExpanded = value;
        lock (CategoryGridEntry.mobjCategoryStates)
          CategoryGridEntry.mobjCategoryStates[(object) this.Name] = (object) value;
      }
    }

    public override int PropertyDepth => base.PropertyDepth - 1;

    public override string PropertyLabel => this.Name;

    public override Type PropertyType => typeof (void);
  }
}
