// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListManagerBindingsCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [DefaultEvent("CollectionChanged")]
  [Serializable]
  internal class ListManagerBindingsCollection : BindingsCollection
  {
    private BindingManagerBase mobjBindingManagerBase;

    internal ListManagerBindingsCollection(BindingManagerBase objBindingManagerBase) => this.mobjBindingManagerBase = objBindingManagerBase;

    protected override void AddCore(Binding objDataBinding)
    {
      if (objDataBinding == null)
        throw new ArgumentNullException("dataBinding");
      if (objDataBinding.BindingManagerBase == this.mobjBindingManagerBase)
        throw new ArgumentException(SR.GetString("BindingsCollectionAdd1"), "dataBinding");
      if (objDataBinding.BindingManagerBase != null)
        throw new ArgumentException(SR.GetString("BindingsCollectionAdd2"), "dataBinding");
      objDataBinding.SetListManager(this.mobjBindingManagerBase);
      base.AddCore(objDataBinding);
    }

    protected override void ClearCore()
    {
      int count = this.Count;
      for (int index = 0; index < count; ++index)
        this[index].SetListManager((BindingManagerBase) null);
      base.ClearCore();
    }

    protected override void RemoveCore(Binding objDataBinding)
    {
      if (objDataBinding.BindingManagerBase != this.mobjBindingManagerBase)
        throw new ArgumentException(SR.GetString("BindingsCollectionForeign"));
      objDataBinding.SetListManager((BindingManagerBase) null);
      base.RemoveCore(objDataBinding);
    }
  }
}
