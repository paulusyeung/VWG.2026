// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Contains border styles for the cells in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public sealed class DataGridViewAdvancedBorderStyle : ICloneable
  {
    private bool mblnAll;
    private DataGridViewAdvancedCellBorderStyle menmBanned1;
    private DataGridViewAdvancedCellBorderStyle menmBanned2;
    private DataGridViewAdvancedCellBorderStyle menmBanned3;
    private DataGridViewAdvancedCellBorderStyle menmBottom;
    private DataGridViewAdvancedCellBorderStyle menmLeft;
    private DataGridView mobjOwner;
    private DataGridViewAdvancedCellBorderStyle menmRight;
    private DataGridViewAdvancedCellBorderStyle menmTop;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> class. </summary>
    public DataGridViewAdvancedBorderStyle()
      : this((DataGridView) null, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet)
    {
    }

    internal DataGridViewAdvancedBorderStyle(DataGridView objOwner)
      : this(objOwner, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet)
    {
    }

    internal DataGridViewAdvancedBorderStyle(
      DataGridView objOwner,
      DataGridViewAdvancedCellBorderStyle enmBanned1,
      DataGridViewAdvancedCellBorderStyle enmBanned2,
      DataGridViewAdvancedCellBorderStyle enmBanned3)
    {
      this.mblnAll = true;
      this.menmTop = DataGridViewAdvancedCellBorderStyle.None;
      this.menmLeft = DataGridViewAdvancedCellBorderStyle.None;
      this.menmRight = DataGridViewAdvancedCellBorderStyle.None;
      this.menmBottom = DataGridViewAdvancedCellBorderStyle.None;
      this.mobjOwner = objOwner;
      this.menmBanned1 = enmBanned1;
      this.menmBanned2 = enmBanned2;
      this.menmBanned3 = enmBanned3;
    }

    /// <summary>Determines whether the specified object is equal to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</summary>
    /// <returns>true if other is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> and the values for the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Top"></see>, <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Bottom"></see>, <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Left"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Right"></see> properties are equal to their counterpart in the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>; otherwise, false.</returns>
    /// <param name="other">An <see cref="T:System.Object"></see> to be compared.</param>
    /// <filterpriority>1</filterpriority>
    public override bool Equals(object other) => other is DataGridViewAdvancedBorderStyle advancedBorderStyle && advancedBorderStyle.mblnAll == this.mblnAll && advancedBorderStyle.menmTop == this.menmTop && advancedBorderStyle.menmLeft == this.menmLeft && advancedBorderStyle.menmBottom == this.menmBottom && advancedBorderStyle.menmRight == this.menmRight;

    /// <filterpriority>1</filterpriority>
    public override int GetHashCode() => ClientUtils.GetCombinedHashCodes((int) this.menmTop, (int) this.menmLeft, (int) this.menmBottom, (int) this.menmRight);

    object ICloneable.Clone() => (object) new DataGridViewAdvancedBorderStyle(this.mobjOwner, this.menmBanned1, this.menmBanned2, this.menmBanned3)
    {
      mblnAll = this.mblnAll,
      menmTop = this.menmTop,
      menmRight = this.menmRight,
      menmBottom = this.menmBottom,
      menmLeft = this.menmLeft
    };

    /// <summary>Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</summary>
    /// <returns>A string that represents the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString() => "DataGridViewAdvancedBorderStyle { All=" + this.All.ToString() + ", Left=" + this.Left.ToString() + ", Right=" + this.Right.ToString() + ", Top=" + this.Top.ToString() + ", Bottom=" + this.Bottom.ToString() + " }";

    /// <summary>Gets or sets the border style for all of the borders of a cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</exception>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetPartial"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance was retrieved through the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AdvancedCellBorderStyle"></see> property.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewAdvancedCellBorderStyle All
    {
      get => !this.mblnAll ? DataGridViewAdvancedCellBorderStyle.NotSet : this.menmTop;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 7))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewAdvancedCellBorderStyle));
        if (value == DataGridViewAdvancedCellBorderStyle.NotSet || value == this.menmBanned1 || value == this.menmBanned2 || value == this.menmBanned3)
          throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", (object) nameof (All)));
        if (this.mblnAll && this.menmTop == value)
          return;
        this.mblnAll = true;
        this.menmTop = this.menmLeft = this.menmRight = this.menmBottom = value;
        DataGridView mobjOwner = this.mobjOwner;
      }
    }

    /// <summary>Gets or sets the style for the bottom border of a cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</exception>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewAdvancedCellBorderStyle Bottom
    {
      get => this.mblnAll ? this.menmTop : this.menmBottom;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 7))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewAdvancedCellBorderStyle));
        this.BottomInternal = value != DataGridViewAdvancedCellBorderStyle.NotSet ? value : throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", (object) nameof (Bottom)));
      }
    }

    internal DataGridViewAdvancedCellBorderStyle BottomInternal
    {
      set
      {
        if ((!this.mblnAll || this.menmTop == value) && (this.mblnAll || this.menmBottom == value))
          return;
        if (this.mblnAll && this.menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
          this.menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
        this.mblnAll = false;
        this.menmBottom = value;
        DataGridView mobjOwner = this.mobjOwner;
      }
    }

    /// <summary>Gets the style for the left border of a cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance has an associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control with a <see cref="P:Gizmox.WebGUI.Forms.Control.RightToLeft"></see> property value of true.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewAdvancedCellBorderStyle Left
    {
      get => this.mblnAll ? this.menmTop : this.menmLeft;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 7))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewAdvancedCellBorderStyle));
        this.LeftInternal = value != DataGridViewAdvancedCellBorderStyle.NotSet ? value : throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", (object) nameof (Left)));
      }
    }

    internal DataGridViewAdvancedCellBorderStyle LeftInternal
    {
      set
      {
        if ((!this.mblnAll || this.menmTop == value) && (this.mblnAll || this.menmLeft == value))
          return;
        DataGridView mobjOwner1 = this.mobjOwner;
        if (this.mblnAll)
        {
          if (this.menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
            this.menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
          if (this.menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
            this.menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
        }
        this.mblnAll = false;
        this.menmLeft = value;
        DataGridView mobjOwner2 = this.mobjOwner;
      }
    }

    /// <summary>Gets the style for the right border of a cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance has an associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control with a <see cref="P:Gizmox.WebGUI.Forms.Control.RightToLeft"></see> property value of false.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewAdvancedCellBorderStyle Right
    {
      get => this.mblnAll ? this.menmTop : this.menmRight;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 7))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewAdvancedCellBorderStyle));
        this.RightInternal = value != DataGridViewAdvancedCellBorderStyle.NotSet ? value : throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", (object) nameof (Right)));
      }
    }

    internal DataGridViewAdvancedCellBorderStyle RightInternal
    {
      set
      {
        if ((!this.mblnAll || this.menmTop == value) && (this.mblnAll || this.menmRight == value))
          return;
        DataGridView mobjOwner1 = this.mobjOwner;
        if (this.mblnAll && this.menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
          this.menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
        this.mblnAll = false;
        this.menmRight = value;
        DataGridView mobjOwner2 = this.mobjOwner;
      }
    }

    /// <summary>Gets the style for the top border of a cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewAdvancedCellBorderStyle Top
    {
      get => this.menmTop;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 7))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewAdvancedCellBorderStyle));
        this.TopInternal = value != DataGridViewAdvancedCellBorderStyle.NotSet ? value : throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", (object) nameof (Top)));
      }
    }

    internal DataGridViewAdvancedCellBorderStyle TopInternal
    {
      set
      {
        if ((!this.mblnAll || this.menmTop == value) && (this.mblnAll || this.menmTop == value))
          return;
        if (this.mblnAll)
        {
          if (this.menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
            this.menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
          if (this.menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
            this.menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
        }
        this.mblnAll = false;
        this.menmTop = value;
        DataGridView mobjOwner = this.mobjOwner;
      }
    }
  }
}
