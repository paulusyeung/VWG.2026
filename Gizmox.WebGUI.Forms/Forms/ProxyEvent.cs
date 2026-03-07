// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyEvent
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>ProxyEvent class</summary>
  [WebCollectionEditorItemTypeName("Event")]
  [Serializable]
  public class ProxyEvent : ProxyAction
  {
    private string mstrTargetComponentUniqueID;

    /// <summary>Gets or sets the target component unique ID.</summary>
    /// <value>The target component unique ID.</value>
    [WebEditor("Gizmox.WebGUI.Forms.Design.TargetComponentUniqueIDEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof (WebUITypeEditor))]
    public string TargetComponentUniqueID
    {
      get => this.mstrTargetComponentUniqueID;
      set => this.mstrTargetComponentUniqueID = value;
    }

    /// <summary>Executes action.</summary>
    public override void Execute()
    {
      IContext context = Global.Context;
      if (context == null)
        return;
      string componentUniqueId = this.TargetComponentUniqueID;
      if (string.IsNullOrEmpty(componentUniqueId))
        return;
      ProxyComponent actionOwner = this.ActionOwner;
      if (actionOwner == null || !(context.ActiveForm is Form activeForm))
        return;
      Component componentByUniqueId = actionOwner.GetComponentByUniqueId((Component) activeForm, componentUniqueId);
      if (componentByUniqueId == null)
        return;
      Type type = componentByUniqueId.GetType();
      object[] customAttributes = type.GetCustomAttributes(typeof (DefaultEventAttribute), true);
      if (customAttributes == null || customAttributes.Length == 0 || !(customAttributes[0] is DefaultEventAttribute defaultEventAttribute))
        return;
      MethodInfo method = type.GetMethod(string.Format("On{0}", (object) defaultEventAttribute.Name), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      if (!(method != (MethodInfo) null))
        return;
      ArrayList arrayList = new ArrayList();
      ParameterInfo[] parameters = method.GetParameters();
      if (parameters != null)
      {
        foreach (ParameterInfo parameterInfo in parameters)
        {
          object typeDefaultValue = CommonUtils.GetTypeDefaultValue(parameterInfo.ParameterType);
          arrayList.Add(typeDefaultValue);
        }
      }
      method.Invoke((object) componentByUniqueId, arrayList.ToArray());
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Event";
  }
}
