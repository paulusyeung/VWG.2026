// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.JQueryUIOptions
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
  [Serializable]
  public abstract class JQueryUIOptions
  {
    private int mintXgrid;
    private int mintYgrid;
    private Component mobjOwner;

    /// <summary>
    /// Initializes a new instance of the <see cref="!:jQueryUIOptions" /> class.
    /// </summary>
    internal JQueryUIOptions()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="!:jQueryUIOptions" /> class.
    /// </summary>
    /// <param name="intXgrid">The int xgrid.</param>
    /// <param name="intYgrid">The int ygrid.</param>
    public JQueryUIOptions(int intXgrid, int intYgrid)
    {
      this.mintXgrid = intXgrid;
      this.mintYgrid = intYgrid;
    }

    /// <summary>Gets or sets the xgrid.</summary>
    /// <value>The xgrid.</value>
    [DefaultValue(0)]
    [SRDescription("Gets or sets the Xgrid (Used to when resizing or dragging in snap mode.).")]
    public int Xgrid
    {
      get => this.mintXgrid;
      set => this.mintXgrid = value;
    }

    /// <summary>Gets or sets the ygrid.</summary>
    /// <value>The ygrid.</value>
    [DefaultValue(0)]
    [SRDescription("Gets or sets the Xgrid (Used to when resizing or dragging in snap mode.).")]
    public int Ygrid
    {
      get => this.mintYgrid;
      set => this.mintYgrid = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal Component Owner
    {
      get => this.mobjOwner;
      set => this.mobjOwner = value;
    }

    /// <summary>Determines whether this instance is default.</summary>
    /// <returns>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </returns>
    internal virtual bool IsDefault() => this.mintXgrid == 0 && this.mintXgrid == 0;

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => string.Format("{0}|{1}", (object) this.Xgrid, (object) this.Ygrid);

    /// <summary>To the render string.</summary>
    /// <returns></returns>
    public virtual string ToRenderString()
    {
      if (this.mintXgrid <= 1 && this.mintYgrid <= 1)
        return string.Empty;
      return string.Format("{0}|", (object) ("grid:[" + (object) this.mintXgrid + "," + (object) this.mintYgrid + "]"));
    }

    /// <summary>Converts from string.</summary>
    /// <param name="strValues">The STR values.</param>
    internal virtual void ConvertFromString(params string[] strValues)
    {
      if (strValues.Length != 2)
        return;
      this.Xgrid = int.Parse(strValues[0]);
      this.Ygrid = int.Parse(strValues[1]);
    }
  }
}
