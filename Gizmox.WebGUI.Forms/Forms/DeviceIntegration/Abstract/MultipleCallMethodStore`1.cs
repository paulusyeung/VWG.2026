// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore`1
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
  /// <summary>
  /// Represents store for device component multiple-call methods.
  /// </summary>
  /// <typeparam name="TEventArgsType">The type of the event args type.</typeparam>
  [Serializable]
  internal class MultipleCallMethodStore<TEventArgsType> where TEventArgsType : EventArgs
  {
    /// <summary>Multiple-call event handler.</summary>
    private Action<TEventArgsType> mobjMultipleCallMethods;

    /// <summary>Invokes the multiple call method.</summary>
    /// <param name="args">The args.</param>
    protected internal void InvokeMultipleCallMethods(TEventArgsType args)
    {
      if (this.mobjMultipleCallMethods == null)
        return;
      this.mobjMultipleCallMethods(args);
    }

    /// <summary>Adds the multiple call method.</summary>
    /// <param name="objMethod">The obj method.</param>
    internal void AddMultipleCallMethod(Action<TEventArgsType> objMethod) => this.mobjMultipleCallMethods += objMethod;

    /// <summary>Removes the multiple call method.</summary>
    /// <param name="objMethod">The obj method.</param>
    internal void RemoveMultipleCallMethod(Action<TEventArgsType> objMethod) => this.mobjMultipleCallMethods -= objMethod;

    /// <summary>Determines whether [has event listeners].</summary>
    /// <returns>
    ///   <c>true</c> if [has event listeners]; otherwise, <c>false</c>.
    /// </returns>
    internal bool HasEventListeners() => this.mobjMultipleCallMethods != null && this.mobjMultipleCallMethods.GetInvocationList().Length != 0;
  }
}
