// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.ArrayElementGridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class ArrayElementGridEntry : GridEntry
  {
    /// <summary>The int property registration.</summary>
    private static readonly SerializableProperty mintIndexProperty = SerializableProperty.Register(nameof (mintIndex), typeof (int), typeof (ArrayElementGridEntry));

    protected int mintIndex
    {
      get => this.GetValue<int>(ArrayElementGridEntry.mintIndexProperty);
      set => this.SetValue<int>(ArrayElementGridEntry.mintIndexProperty, value);
    }

    public ArrayElementGridEntry(
      PropertyGrid objOwnerGrid,
      GridEntry objParentGridEntry,
      int intIndex)
      : base(objOwnerGrid, objParentGridEntry)
    {
      this.mintIndex = intIndex;
      this.SetState(256, (objParentGridEntry.Flags & 256) != 0 || objParentGridEntry.ForceReadOnly);
    }

    public override GridItemType GridItemType => GridItemType.ArrayValue;

    public override bool IsValueEditable => this.ParentGridEntry.IsValueEditable;

    public override string PropertyLabel => "[" + this.mintIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + "]";

    public override Type PropertyType => this.mobjParentGridEntry.PropertyType.GetElementType();

    public override object PropertyValue
    {
      get => ((Array) this.GetValueOwner()).GetValue(this.mintIndex);
      set => ((Array) this.GetValueOwner()).SetValue(value, this.mintIndex);
    }

    public override bool ShouldRenderReadOnly => this.ParentGridEntry.ShouldRenderReadOnly;
  }
}
