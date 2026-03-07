// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SRCategoryAttribute
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for SRCategoryAttribute.</summary>
  [AttributeUsage(AttributeTargets.All)]
  [Serializable]
  internal sealed class SRCategoryAttribute : CategoryAttribute
  {
    /// <summary>
    /// 
    /// </summary>
    public SRCategoryAttribute(string strCategory)
      : base(strCategory)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strValue"></param>
    protected override string GetLocalizedString(string strValue)
    {
      string localizedString = SR.GetString(strValue);
      if (CommonUtils.IsNullOrEmpty(localizedString))
        localizedString = strValue;
      return localizedString;
    }
  }
}
