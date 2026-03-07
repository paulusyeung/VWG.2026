// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyPropertyBag
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// The property bag dictionary added to support events when changing it.
  /// </summary>
  [Serializable]
  public class ProxyPropertyBag : Dictionary<string, object>
  {
    /// <summary>
    /// 
    /// </summary>
    private UiPropertyValueChangedEventHandler mobjPropertyValueChangedEventHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyBag" /> class.
    /// </summary>
    public ProxyPropertyBag()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyBag" /> class.
    /// </summary>
    /// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object containing the information required to serialize the <see cref="T:System.Collections.Generic.Dictionary`2" />.</param>
    /// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> structure containing the source and destination of the serialized stream associated with the <see cref="T:System.Collections.Generic.Dictionary`2" />.</param>
    protected ProxyPropertyBag(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.mobjPropertyValueChangedEventHandler = info.GetValue("UiPropertyValueChangedEventHandler", typeof (UiPropertyValueChangedEventHandler)) as UiPropertyValueChangedEventHandler;
    }

    /// <summary>Occurs when [UI property value changing].</summary>
    internal event UiPropertyValueChangedEventHandler PropertyValueChanging
    {
      add => this.mobjPropertyValueChangedEventHandler += value;
      remove => this.mobjPropertyValueChangedEventHandler -= value;
    }

    /// <summary>
    /// Gets or sets the <see cref="T:System.Object" /> with the specified string key.
    /// </summary>
    /// <value>
    /// The <see cref="T:System.Object" />.
    /// </value>
    /// <param name="strKey">The string key.</param>
    /// <returns></returns>
    public new object this[string strKey]
    {
      get => base[strKey];
      set
      {
        this.OnPropertyValueChanging(new ProxyPropertyValueEventArgs(strKey, value));
        base[strKey] = value;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:PropertyValueChanging" /> event.
    /// </summary>
    /// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
    private void OnPropertyValueChanging(
      ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
    {
      if (this.mobjPropertyValueChangedEventHandler == null)
        return;
      this.mobjPropertyValueChangedEventHandler((object) this, objProxyPropertyValueEventArgs);
    }

    /// <summary>
    /// Implements the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface and returns the data needed to serialize the <see cref="T:System.Collections.Generic.Dictionary`2" /> instance.
    /// </summary>
    /// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object that contains the information required to serialize the <see cref="T:System.Collections.Generic.Dictionary`2" /> instance.</param>
    /// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> structure that contains the source and destination of the serialized stream associated with the <see cref="T:System.Collections.Generic.Dictionary`2" /> instance.</param>
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("UiPropertyValueChangedEventHandler", (object) this.mobjPropertyValueChangedEventHandler);
    }
  }
}
