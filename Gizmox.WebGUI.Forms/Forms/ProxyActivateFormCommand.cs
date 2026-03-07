// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyActivateFormCommand
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [WebCollectionEditorItemTypeName("Activate Form")]
  [Serializable]
  public class ProxyActivateFormCommand : ProxyAction
  {
    private Type mobjFormType;

    /// <summary>Gets or sets the type of the form.</summary>
    /// <value>The type of the form.</value>
    [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActivateFormCommandEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof (WebUITypeEditor))]
    public Type FormType
    {
      get => this.mobjFormType;
      set => this.mobjFormType = value;
    }

    /// <summary>Executes action</summary>
    public override void Execute()
    {
      IContext context = Global.Context;
      if (context == null || !(context.ActiveForm.GetType() != this.FormType))
        return;
      List<IForm> formList = new List<IForm>((IEnumerable<IForm>) ((IFormResolver) context).AccessibleForms);
      if (formList == null)
        return;
      foreach (IForm form1 in formList)
      {
        if (form1 is Form form2 && form2.GetType() == this.FormType)
        {
          form2.ActivateForm(true);
          break;
        }
      }
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Activate Form";
  }
}
