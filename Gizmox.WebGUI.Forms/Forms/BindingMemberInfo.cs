// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingMemberInfo
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Contains information that enables a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to resolve a data binding to either the property of an object or the property of the current object in a list of objects.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public struct BindingMemberInfo
  {
    private string mstrDataList;
    private string mstrDataField;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> class.</summary>
    /// <param name="strDataMember">A navigation path that resolves to either the property of an object or the property of the current object in a list of objects. </param>
    public BindingMemberInfo(string strDataMember)
    {
      if (strDataMember == null)
        strDataMember = "";
      int length = strDataMember.LastIndexOf(".");
      if (length != -1)
      {
        this.mstrDataList = strDataMember.Substring(0, length);
        this.mstrDataField = strDataMember.Substring(length + 1);
      }
      else
      {
        this.mstrDataList = "";
        this.mstrDataField = strDataMember;
      }
    }

    /// <summary>Gets the property name, or the period-delimited hierarchy of property names, that comes before the property name of the data-bound object.</summary>
    /// <returns>The property name, or the period-delimited hierarchy of property names, that comes before the data-bound object property name.</returns>
    /// <filterpriority>1</filterpriority>
    public string BindingPath => this.mstrDataList == null ? "" : this.mstrDataList;

    /// <summary>Gets the property name of the data-bound object.</summary>
    /// <returns>The property name of the data-bound object. This can be an empty string ("").</returns>
    /// <filterpriority>1</filterpriority>
    public string BindingField => this.mstrDataField == null ? "" : this.mstrDataField;

    /// <summary>Gets the information that is used to specify the property name of the data-bound object.</summary>
    /// <returns>An empty string (""), a single property name, or a hierarchy of period-delimited property names that resolves to the property name of the final data-bound object.</returns>
    /// <filterpriority>1</filterpriority>
    public string BindingMember => this.BindingPath.Length <= 0 ? this.BindingField : this.BindingPath + "." + this.BindingField;

    /// <summary>Determines whether the specified object is equal to this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</summary>
    /// <returns>true if otherObject is a <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> and both <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings are equal; otherwise false.</returns>
    /// <param name="otherObject">The object to compare for equality.</param>
    /// <filterpriority>1</filterpriority>
    public override bool Equals(object otherObject) => otherObject is BindingMemberInfo bindingMemberInfo && ClientUtils.IsEquals(this.BindingMember, bindingMemberInfo.BindingMember, StringComparison.OrdinalIgnoreCase);

    /// <summary>Determines whether two <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> objects are equal.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings for a and b are equal; otherwise false.</returns>
    /// <param name="BindingMemberInfo1">The first <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for equality.</param>
    /// <param name="BindingMemberInfo2">The second <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for equality.</param>
    public static bool operator ==(
      BindingMemberInfo BindingMemberInfo1,
      BindingMemberInfo BindingMemberInfo2)
    {
      return BindingMemberInfo1.Equals((object) BindingMemberInfo2);
    }

    /// <summary>Determines whether two <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> objects are not equal.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings for a and b are not equal; otherwise false.</returns>
    /// <param name="BindingMemberInfo1">The first <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for inequality.</param>
    /// <param name="BindingMemberInfo2">The second <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for inequality.</param>
    public static bool operator !=(
      BindingMemberInfo BindingMemberInfo1,
      BindingMemberInfo BindingMemberInfo2)
    {
      return !BindingMemberInfo1.Equals((object) BindingMemberInfo2);
    }

    /// <summary>Returns the hash code for this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</summary>
    /// <returns>The hash code for this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override int GetHashCode() => base.GetHashCode();
  }
}
