// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolTipDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ToolTipDescriptor
  {
    private string mstrToolTipKey;
    private string mstrToolTipTemplateName;
    private Dictionary<string, string> marrExtendedProperties;

    /// <summary>Gets the tool tip key.</summary>
    /// <value>The tool tip key.</value>
    public string ToolTipKey
    {
      get => this.mstrToolTipKey;
      set => this.mstrToolTipKey = value;
    }

    /// <summary>Gets the extended properties.</summary>
    /// <value>The extended properties.</value>
    public Dictionary<string, string> ExtendedProperties
    {
      get
      {
        if (this.marrExtendedProperties == null)
          this.marrExtendedProperties = new Dictionary<string, string>();
        return this.marrExtendedProperties;
      }
    }

    /// <summary>Gets the serialized properties.</summary>
    public string SerializedProperties
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder(string.Empty);
        string str1 = "_VWG_KVS_";
        string str2 = string.Empty;
        foreach (string key in this.marrExtendedProperties.Keys)
        {
          stringBuilder.AppendFormat("{0}{1}{2}{3}", (object) str2, (object) key, (object) str1, (object) this.marrExtendedProperties[key]);
          str2 = "_VWG_ETT_";
        }
        return stringBuilder.ToString();
      }
    }

    /// <summary>Gets or sets the name of the tool tip template.</summary>
    /// <value>The name of the tool tip template.</value>
    public string ToolTipTemplateName
    {
      get => this.mstrToolTipTemplateName;
      set => this.mstrToolTipTemplateName = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTipDescriptor" /> class.
    /// </summary>
    /// <param name="strToolTipKey">The STR tool tip key.</param>
    public ToolTipDescriptor(string strToolTipKey) => this.mstrToolTipKey = strToolTipKey;
  }
}
