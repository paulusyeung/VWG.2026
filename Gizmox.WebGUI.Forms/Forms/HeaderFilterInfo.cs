// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HeaderFilterInfo
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [TypeConverter(typeof (HeaderFilterInfoConverter))]
  [Serializable]
  public class HeaderFilterInfo
  {
    private string mstrDataPropertyName = string.Empty;
    private bool mblnIsCustomFilter;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HeaderFilterInfo" /> class.
    /// </summary>
    public HeaderFilterInfo()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HeaderFilterInfo" /> class.
    /// </summary>
    /// <param name="strDataPropertyName">Name of the STR data property.</param>
    /// <param name="blnIsCustomFilter">if set to <c>true</c> [BLN is custom filter].</param>
    public HeaderFilterInfo(string strDataPropertyName, bool blnIsCustomFilter)
    {
      this.mstrDataPropertyName = !string.IsNullOrEmpty(strDataPropertyName) ? strDataPropertyName : throw new ArgumentNullException(nameof (DataPropertyName));
      this.mblnIsCustomFilter = blnIsCustomFilter;
    }

    /// <summary>Gets or sets the name of the data property.</summary>
    /// <value>The name of the data property.</value>
    public string DataPropertyName
    {
      get => this.mstrDataPropertyName;
      set => this.mstrDataPropertyName = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof (DataPropertyName));
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is custom filter.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is custom filter; otherwise, <c>false</c>.
    /// </value>
    public bool IsCustomFilter
    {
      get => this.mblnIsCustomFilter;
      set => this.mblnIsCustomFilter = value;
    }
  }
}
