// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore`1
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
  /// <summary>
  /// Represents store for device component single-call methods.
  /// </summary>
  /// <typeparam name="TEventArgsType">The type of the event args type.</typeparam>
  [Serializable]
  internal class SingleCallMethodStore<TEventArgsType> where TEventArgsType : EventArgs
  {
    /// <summary>Stores typed EventHandlers by key.</summary>
    private Dictionary<string, Action<TEventArgsType>> mobjMethodsIndexByMethodKey;
    private Dictionary<string, SingleCallMethodStore<TEventArgsType>.ContextualData<TEventArgsType>> mobjContextualMethodsIndexByMethodKey;

    /// <summary>Gets the contextual methods.</summary>
    private Dictionary<string, SingleCallMethodStore<TEventArgsType>.ContextualData<TEventArgsType>> ContextualMethods
    {
      get
      {
        if (this.mobjContextualMethodsIndexByMethodKey == null)
          this.mobjContextualMethodsIndexByMethodKey = new Dictionary<string, SingleCallMethodStore<TEventArgsType>.ContextualData<TEventArgsType>>();
        return this.mobjContextualMethodsIndexByMethodKey;
      }
    }

    /// <summary>Gets the methods store.</summary>
    private Dictionary<string, Action<TEventArgsType>> Methods
    {
      get
      {
        if (this.mobjMethodsIndexByMethodKey == null)
          this.mobjMethodsIndexByMethodKey = new Dictionary<string, Action<TEventArgsType>>();
        return this.mobjMethodsIndexByMethodKey;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore`1" /> class.
    /// </summary>
    internal SingleCallMethodStore()
    {
    }

    /// <summary>Stores a single-call method.</summary>
    /// <param name="objMethod">The method.</param>
    /// <returns></returns>
    internal string StoreSingleCallMethod(Action<TEventArgsType> objMethod) => this.StoreSingleCallMethod((string) null, objMethod);

    internal string StoreContextualSingleCallMethod(
      object objThis,
      string strPrefix,
      EventHandler<TEventArgsType> objMethod)
    {
      if (objMethod == null)
        return (string) null;
      string key = Guid.NewGuid().ToString("N");
      this.ContextualMethods.Add(key, new SingleCallMethodStore<TEventArgsType>.ContextualData<TEventArgsType>(objThis, objMethod));
      if (!string.IsNullOrEmpty(strPrefix))
        key = strPrefix + "-" + key;
      return key;
    }

    /// <summary>Stores a single-call method.</summary>
    /// <param name="objMethod">The method.</param>
    /// <returns></returns>
    internal string StoreSingleCallMethod(string strPrefix, Action<TEventArgsType> objMethod)
    {
      if (objMethod == null)
        return (string) null;
      string key = Guid.NewGuid().ToString("N");
      this.Methods.Add(key, objMethod);
      if (!string.IsNullOrEmpty(strPrefix))
        key = strPrefix + "-" + key;
      return key;
    }

    /// <summary>
    /// Determines whether [has registered method] [the specified STR method key].
    /// </summary>
    /// <param name="strMethodKey">The STR method key.</param>
    /// <returns>
    ///   <c>true</c> if [has registered method] [the specified STR method key]; otherwise, <c>false</c>.
    /// </returns>
    internal bool HasRegisteredMethod(string strMethodKey) => this.Methods.ContainsKey(strMethodKey);

    /// <summary>Invokes the contextual method.</summary>
    /// <param name="strMethodKey">The STR method key.</param>
    /// <param name="args">The args.</param>
    protected internal void InvokeContextualMethod(string strMethodKey, TEventArgsType args)
    {
      if (!this.ContextualMethods.ContainsKey(strMethodKey))
        return;
      SingleCallMethodStore<TEventArgsType>.ContextualData<TEventArgsType> contextualMethod = this.ContextualMethods[strMethodKey];
      contextualMethod.Handler(contextualMethod.Context, args);
      this.ContextualMethods.Remove(strMethodKey);
    }

    /// <summary>Invokes the single call method.</summary>
    /// <param name="strMethodKey">The STR method key.</param>
    /// <param name="args">The args.</param>
    protected internal void InvokeSingleCallMethod(string strMethodKey, TEventArgsType args)
    {
      if (!this.Methods.ContainsKey(strMethodKey))
        return;
      this.Methods[strMethodKey](args);
      this.Methods.Remove(strMethodKey);
    }

    internal TContextType GetContaxt<TContextType>(string strMethodKey) where TContextType : class => this.ContextualMethods.ContainsKey(strMethodKey) ? this.ContextualMethods[strMethodKey].Context as TContextType : default (TContextType);

    /// <summary>Determines whether [has event listeners].</summary>
    /// <returns>
    ///   <c>true</c> if [has event listeners]; otherwise, <c>false</c>.
    /// </returns>
    internal bool HasEventListeners() => this.Methods.Count > 0;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventArgsType">The type of the event args type.</typeparam>
    private class ContextualData<TEventArgsType> where TEventArgsType : EventArgs
    {
      private object mobjContext;
      private EventHandler<TEventArgsType> mobjHandler;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore`1.ContextualData`1" /> class.
      /// </summary>
      /// <param name="objContext">The obj context.</param>
      /// <param name="objHandler">The obj handler.</param>
      public ContextualData(object objContext, EventHandler<TEventArgsType> objHandler)
      {
        this.mobjContext = objContext;
        this.mobjHandler = objHandler;
      }

      /// <summary>Gets the context.</summary>
      internal object Context => this.mobjContext;

      /// <summary>Gets the handler.</summary>
      internal EventHandler<TEventArgsType> Handler => this.mobjHandler;
    }
  }
}
