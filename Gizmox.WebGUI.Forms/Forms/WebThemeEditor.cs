// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.WebThemeEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class WebThemeEditor : StandardValuesEditor
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WebThemeEditor" /> class.
    /// </summary>
    /// <param name="objTypeConvertor">The obj type convertor.</param>
    public WebThemeEditor(TypeConverter objTypeConvertor)
      : base(objTypeConvertor)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WebThemeEditor" /> class.
    /// </summary>
    public WebThemeEditor()
    {
    }

    /// <summary>Gets the list values.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <returns></returns>
    protected override ArrayList GetListValues(ITypeDescriptorContext objContext)
    {
      ArrayList listValues = new ArrayList();
      foreach (string theme in ConfigHelper.Themes)
        listValues.Add((object) theme);
      return listValues;
    }
  }
}
