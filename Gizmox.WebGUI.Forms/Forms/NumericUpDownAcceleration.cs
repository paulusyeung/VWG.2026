// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.NumericUpDownAcceleration
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides information specifying how acceleration should be performed on a spin box (also known as an up-down control) when the up or down button is pressed for specified time period.</summary>
  public class NumericUpDownAcceleration
  {
    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> class.</summary>
    /// <param name="seconds">The number of seconds the up or down button is pressed before the acceleration starts. </param>
    /// <param name="increment">The quantity the value displayed in the control should be incremented or decremented during acceleration.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">seconds or increment is less than 0.</exception>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    public NumericUpDownAcceleration(int seconds, Decimal increment)
    {
    }

    /// <summary>Gets or sets the quantity to increment or decrement the displayed value during acceleration.</summary>
    /// <returns>The quantity to increment or decrement the displayed value during acceleration.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The set value is less than 0.</exception>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Decimal Increment
    {
      get => 0M;
      set
      {
      }
    }

    /// <summary>Gets or sets the number of seconds the up or down button must be pressed before the acceleration starts.</summary>
    /// <returns>Gets or sets the number of seconds the up or down button must be pressed before the acceleration starts.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The set value is less than 0.</exception>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int Seconds
    {
      get => 0;
      set
      {
      }
    }
  }
}
