// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ConvertEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.Binding.Format"></see> and <see cref="E:Gizmox.WebGUI.Forms.Binding.Parse"></see> events.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class ConvertEventArgs : EventArgs
  {
    private Type mobjDesiredType;
    private object mobjValue;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see> class.</summary>
    /// <param name="objDesiredType">The <see cref="T:System.Type"></see> of the value. </param>
    /// <param name="objValue">An <see cref="T:System.Object"></see> that contains the value of the current property. </param>
    public ConvertEventArgs(object objValue, Type objDesiredType)
    {
      this.mobjValue = objValue;
      this.mobjDesiredType = objDesiredType;
    }

    /// <summary>Gets the data type of the desired value.</summary>
    /// <returns>The <see cref="T:System.Type"></see> of the desired value.</returns>
    /// <filterpriority>1</filterpriority>
    public Type DesiredType => this.mobjDesiredType;

    /// <summary>Gets or sets the value of the <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see>.</summary>
    /// <returns>The value of the <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public object Value
    {
      get => this.mobjValue;
      set => this.mobjValue = value;
    }
  }
}
