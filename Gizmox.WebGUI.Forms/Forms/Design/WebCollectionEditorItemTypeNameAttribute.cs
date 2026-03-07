// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.WebCollectionEditorItemTypeNameAttribute
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.Design
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  [Serializable]
  public class WebCollectionEditorItemTypeNameAttribute : Attribute
  {
    private string mstrDisplayName = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.WebCollectionEditorItemTypeNameAttribute" /> class.
    /// </summary>
    /// <param name="strDisplayName">Display name of the string.</param>
    public WebCollectionEditorItemTypeNameAttribute(string strDisplayName) => this.mstrDisplayName = strDisplayName;

    /// <summary>Gets or sets the display name.</summary>
    /// <value>The display name.</value>
    public string DisplayName
    {
      get => this.mstrDisplayName;
      set => this.mstrDisplayName = value;
    }
  }
}
