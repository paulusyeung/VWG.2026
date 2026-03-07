// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.LimitedTrustBrowsableAttribute
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>
  /// Specifies whether a property or event should be displayed in a Properties window
  /// of the PropertyGrid in Partially Trusted Environment.
  /// </summary>
  [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
  [Serializable]
  public sealed class LimitedTrustBrowsableAttribute : Attribute
  {
    /// <summary>
    /// Specifies the default value for the <see cref="T:Gizmox.WebGUI.Forms.Design.LimitedTrustBrowsableAttribute"></see>,
    /// which is <see cref="F:Gizmox.WebGUI.Forms.Design.LimitedTrustBrowsableAttribute.Yes"></see>. This static field is read-only.</summary>
    public static readonly LimitedTrustBrowsableAttribute Default;
    private bool mblnBrowsable = true;
    /// <summary>
    /// Specifies that a property or event cannot be modified at design time. This static field is read-only.
    /// </summary>
    public static readonly LimitedTrustBrowsableAttribute No = new LimitedTrustBrowsableAttribute(false);
    /// <summary>
    /// Specifies that a property or event can be modified at design time. This static field is read-only.
    /// </summary>
    public static readonly LimitedTrustBrowsableAttribute Yes = new LimitedTrustBrowsableAttribute(true);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.BrowsableAttribute"></see> class.
    /// </summary>
    /// <param name="blnBrowsable">true if a property or event can be modified at design time; otherwise, false. The default is true. </param>
    public LimitedTrustBrowsableAttribute(bool blnBrowsable) => this.mblnBrowsable = blnBrowsable;

    static LimitedTrustBrowsableAttribute() => LimitedTrustBrowsableAttribute.Default = LimitedTrustBrowsableAttribute.Yes;

    /// <summary>
    /// Gets a value indicating whether an object is browsable.
    /// </summary>
    /// <returns>true if the object is browsable; otherwise, false.</returns>
    public bool Browsable => this.mblnBrowsable;

    /// <summary>Indicates whether this instance and a specified object are equal.</summary>
    /// <returns>true if obj is equal to this instance; otherwise, false.</returns>
    /// <param name="obj">Another object to compare to. </param>
    public override bool Equals(object obj)
    {
      if (obj == this)
        return true;
      return obj is LimitedTrustBrowsableAttribute browsableAttribute && browsableAttribute.Browsable == this.mblnBrowsable;
    }

    /// <summary>Returns the hash code for this instance.</summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => this.mblnBrowsable.GetHashCode();

    /// <summary>Determines if this attribute is the default.</summary>
    /// <returns>
    /// true if the attribute is the default value for this attribute class; otherwise, false.
    /// </returns>
    public override bool IsDefaultAttribute() => this.Equals((object) LimitedTrustBrowsableAttribute.Default);
  }
}
