// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SRDescriptionAttribute
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
  [AttributeUsage(AttributeTargets.All)]
  [Serializable]
  internal sealed class SRDescriptionAttribute : DescriptionAttribute
  {
    private bool mblnReplaced;

    /// <summary>
    /// 
    /// </summary>
    public SRDescriptionAttribute(string strDescription)
      : base(strDescription)
    {
      this.mblnReplaced = false;
    }

    /// <summary>
    /// 
    /// </summary>
    public override string Description
    {
      get
      {
        if (!this.mblnReplaced)
        {
          this.mblnReplaced = true;
          string str = SR.GetString(base.Description);
          if (!CommonUtils.IsNullOrEmpty(str))
            this.DescriptionValue = str;
        }
        return base.Description;
      }
    }
  }
}
