// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyCloseActiveFormCommand
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [WebCollectionEditorItemTypeName("Close Active Form")]
  [Serializable]
  public class ProxyCloseActiveFormCommand : ProxyAction
  {
    private Type mobjFormType;

    /// <summary>Executes action</summary>
    public override void Execute()
    {
      IContext context = Global.Context;
      if (context == null || !(context.ActiveForm is Form activeForm) || !activeForm.CloseBox || activeForm.FormBorderStyle == FormBorderStyle.None)
        return;
      context.ActiveForm.Close();
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Close Active Form";
  }
}
