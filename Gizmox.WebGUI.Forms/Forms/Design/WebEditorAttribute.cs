// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.WebEditorAttribute
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>Specifies the editor to use to change a property. This class cannot be inherited.</summary>
  [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
  [Serializable]
  public sealed class WebEditorAttribute : Attribute
  {
    private string mstrBaseTypeName;
    private string mstrTypeId;
    private string mstrTypeName;

    /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the default editor, which is no editor.</summary>
    public WebEditorAttribute()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the type name and base type name of the editor.</summary>
    /// <param name="strTypeName">The fully qualified type name of the editor. </param>
    /// <param name="strBaseTypeName">The fully qualified type name of the base class or interface to use as a lookup key for the editor. This class must be or derive from <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. </param>
    public WebEditorAttribute(string strTypeName, string strBaseTypeName)
    {
      this.mstrTypeName = strTypeName.ToUpper();
      this.mstrBaseTypeName = strBaseTypeName;
    }

    /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the type name and the base type.</summary>
    /// <param name="strTypeName">The fully qualified type name of the editor. </param>
    /// <param name="objBaseType">The <see cref="T:System.Type"></see> of the base class or interface to use as a lookup key for the editor. This class must be or derive from <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. </param>
    public WebEditorAttribute(string strTypeName, Type objBaseType)
    {
      this.mstrTypeName = strTypeName.ToUpper();
      this.mstrBaseTypeName = objBaseType.AssemblyQualifiedName;
    }

    /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the type name and the base type.</summary>
    /// <param name="strTypeName">The fully qualified type name of the editor. </param>
    public WebEditorAttribute(string strTypeName)
    {
      this.mstrTypeName = strTypeName.ToUpper();
      this.mstrBaseTypeName = typeof (WebUITypeEditor).AssemblyQualifiedName;
    }

    /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the type and the base type.</summary>
    /// <param name="objType">A <see cref="T:System.Type"></see> that represents the type of the editor. </param>
    /// <param name="objBaseType">The <see cref="T:System.Type"></see> of the base class or interface to use as a lookup key for the editor. This class must be or derive from <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. </param>
    public WebEditorAttribute(Type objType, Type objBaseType)
    {
      this.mstrTypeName = objType.AssemblyQualifiedName;
      this.mstrBaseTypeName = objBaseType.AssemblyQualifiedName;
    }

    /// <summary>Returns whether the value of the given object is equal to the current <see cref="T:System.ComponentModel.WebEditorAttribute"></see>.</summary>
    /// <returns>true if the value of the given object is equal to that of the current object; otherwise, false.</returns>
    /// <param name="obj">The object to test the value equality of. </param>
    public override bool Equals(object obj)
    {
      if (obj == this)
        return true;
      return obj is WebEditorAttribute webEditorAttribute && webEditorAttribute.mstrTypeName == this.mstrTypeName && webEditorAttribute.mstrBaseTypeName == this.mstrBaseTypeName;
    }

    /// <summary>Returns the hash code for this instance.</summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => base.GetHashCode();

    /// <summary>Gets the name of the base class or interface serving as a lookup key for this editor.</summary>
    /// <returns>The name of the base class or interface serving as a lookup key for this editor.</returns>
    public string EditorBaseTypeName => this.mstrBaseTypeName;

    /// <summary>Gets the name of the editor class in the <see cref="P:Type.AssemblyQualifiedName"></see> format.</summary>
    /// <returns>The name of the editor class in the <see cref="P:Type.AssemblyQualifiedName"></see> format.</returns>
    public string EditorTypeName => this.mstrTypeName;

    /// <summary>Gets a unique ID for this attribute type.</summary>
    /// <returns>A unique ID for this attribute type.</returns>
    public override object TypeId
    {
      get
      {
        if (this.mstrTypeId == null)
        {
          string str = this.mstrBaseTypeName;
          int length = str.IndexOf(',');
          if (length != -1)
            str = str.Substring(0, length);
          this.mstrTypeId = this.GetType().FullName + str;
        }
        return (object) this.mstrTypeId;
      }
    }
  }
}
