// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies whether a column type is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer. This class cannot be inherited. </summary>
  [AttributeUsage(AttributeTargets.Class)]
  [Serializable]
  public sealed class DataGridViewColumnDesignTimeVisibleAttribute : Attribute
  {
    /// <summary>The default <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> value, which is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Yes"></see>, indicating that the column is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer. </summary>
    public static readonly DataGridViewColumnDesignTimeVisibleAttribute Default;
    /// <summary>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> value indicating that the column is not visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer. </summary>
    public static readonly DataGridViewColumnDesignTimeVisibleAttribute No;
    private bool mblnVisible;
    /// <summary>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> value indicating that the column is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer. </summary>
    public static readonly DataGridViewColumnDesignTimeVisibleAttribute Yes = new DataGridViewColumnDesignTimeVisibleAttribute(true);

    static DataGridViewColumnDesignTimeVisibleAttribute()
    {
      DataGridViewColumnDesignTimeVisibleAttribute.No = new DataGridViewColumnDesignTimeVisibleAttribute(false);
      DataGridViewColumnDesignTimeVisibleAttribute.Default = DataGridViewColumnDesignTimeVisibleAttribute.Yes;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> class using the default <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Visible"></see> property value of true. </summary>
    public DataGridViewColumnDesignTimeVisibleAttribute()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> class using the specified value to initialize the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Visible"></see> property. </summary>
    /// <param name="blnVisible">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Visible"></see> property.</param>
    public DataGridViewColumnDesignTimeVisibleAttribute(bool blnVisible) => this.mblnVisible = blnVisible;

    /// <summary>Gets a value indicating whether this object is equivalent to the specified object.</summary>
    /// <returns>true to indicate that the specified object is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> instance with the same <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Visible"></see> property value as this instance; otherwise, false.</returns>
    /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
    public override bool Equals(object obj)
    {
      if (obj == this)
        return true;
      return obj is DataGridViewColumnDesignTimeVisibleAttribute visibleAttribute && visibleAttribute.Visible == this.mblnVisible;
    }

    /// <summary>Returns the hash code for this instance.</summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => typeof (DataGridViewColumnDesignTimeVisibleAttribute).GetHashCode() ^ (this.mblnVisible ? -1 : 0);

    /// <summary>Gets a value indicating whether this attribute instance is equal to the <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Default"></see> attribute value.</summary>
    /// <returns>true to indicate that this instance is equal to the <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Default"></see> instance; otherwise, false.</returns>
    public override bool IsDefaultAttribute() => this.Visible == DataGridViewColumnDesignTimeVisibleAttribute.Default.Visible;

    /// <summary>Gets a value indicating whether the column type is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer.</summary>
    /// <returns>true to indicate that the column type is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer; otherwise, false.</returns>
    public bool Visible => this.mblnVisible;
  }
}
