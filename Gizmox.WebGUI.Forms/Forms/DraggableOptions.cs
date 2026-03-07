// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DraggableOptions
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// This class represents the abilities of the jquery draggble.
  /// </summary>
  [TypeConverter(typeof (DraggableOptionsTypeConverter))]
  [Serializable]
  public class DraggableOptions : JQueryUIOptions
  {
    private bool mblnIsDraggable = true;
    private SnapTo menmSnapTo;
    private SnapMode menmSnapMode;
    private int mintSnapTolerance = 20;
    private RevertMode menmRevertMode;
    private int mintRevertDuration = 500;
    private bool mblnAllowNegativeAxes = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DraggableOptions" /> class.
    /// </summary>
    /// <param name="blnIsDraggable">if set to <c>true</c> [BLN is draggable].</param>
    public DraggableOptions(bool blnIsDraggable) => this.mblnIsDraggable = blnIsDraggable;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DraggableOptions" /> class.
    /// </summary>
    /// <param name="blnIsDraggable">if set to <c>true</c> [BLN is draggable].</param>
    /// <param name="enmSnapTo">The enm snap to.</param>
    /// <param name="enmSnapMode">The enm snap mode.</param>
    /// <param name="intSnapTolerance">The int snap tolerance.</param>
    /// <param name="enmRevertMode">The enm revert mode.</param>
    /// <param name="intRevertDuration">Duration of the int revert.</param>
    /// <param name="intXgrid">The int xgrid.</param>
    /// <param name="intYgrid">The int ygrid.</param>
    /// <param name="blnAllowNegativeAxes">if set to <c>true</c> [BLN allow negative values].</param>
    public DraggableOptions(
      bool blnIsDraggable,
      SnapTo enmSnapTo,
      SnapMode enmSnapMode,
      int intSnapTolerance,
      RevertMode enmRevertMode,
      int intRevertDuration,
      int intXgrid,
      int intYgrid,
      bool blnAllowNegativeAxes)
    {
      this.mblnIsDraggable = blnIsDraggable;
      this.menmSnapTo = enmSnapTo;
      this.menmSnapMode = enmSnapMode;
      this.menmRevertMode = enmRevertMode;
      this.mintSnapTolerance = intSnapTolerance;
      this.mintRevertDuration = intRevertDuration;
      this.Xgrid = intXgrid;
      this.Ygrid = intYgrid;
      this.mblnAllowNegativeAxes = blnAllowNegativeAxes;
    }

    /// <summary>Determines whether this instance is default.</summary>
    /// <returns>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </returns>
    internal override bool IsDefault() => base.IsDefault() && this.menmSnapTo == SnapTo.None && this.SnapMode == SnapMode.Both && this.SnapTolerance == 20 && this.RevertMode == RevertMode.None && this.RevertDuration == 500 && this.AllowNegativeAxes;

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", this.mblnIsDraggable ? (object) "1" : (object) "0", (object) (int) this.menmSnapTo, (object) (int) this.menmSnapMode, (object) this.Xgrid, (object) this.Ygrid, (object) this.mintSnapTolerance, (object) (int) this.menmRevertMode, (object) this.mintRevertDuration, (object) this.mblnAllowNegativeAxes);

    /// <summary>To the render string.</summary>
    /// <returns></returns>
    internal new string ToRenderString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(base.ToRenderString());
      if (this.menmSnapTo != SnapTo.None)
      {
        if (this.menmSnapTo == SnapTo.Siblings)
          stringBuilder.AppendFormat("{0}|", (object) "snap:siblings");
        else
          stringBuilder.AppendFormat("{0}|", (object) "snap:true");
      }
      if (this.menmSnapMode != SnapMode.Both)
        stringBuilder.AppendFormat("{0}|", (object) ("snapMode:\\'" + this.menmSnapMode.ToString().ToLower() + "\\'"));
      if (this.mintSnapTolerance != 20)
        stringBuilder.AppendFormat("{0}|", (object) ("snapTolerance:" + this.mintSnapTolerance.ToString()));
      if (this.menmRevertMode != RevertMode.None)
      {
        if (this.menmRevertMode != RevertMode.Always)
          stringBuilder.AppendFormat("{0}|", (object) ("revert:\\'" + this.menmRevertMode.ToString().ToLower() + "\\'"));
        else
          stringBuilder.AppendFormat("{0}|", (object) "revert:true");
      }
      if (this.mintRevertDuration != 500)
        stringBuilder.AppendFormat("{0}|", (object) ("revertDuration:" + this.mintRevertDuration.ToString()));
      if (!this.mblnAllowNegativeAxes)
        stringBuilder.AppendFormat("{0}|", (object) "allowNegativeAxes:false");
      return stringBuilder.ToString().TrimEnd('|');
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is draggable.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is draggable; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [SRDescription("Gets or sets a value indicating whether this instance is draggable.")]
    public bool IsDraggable
    {
      get => this.mblnIsDraggable;
      set => this.mblnIsDraggable = value;
    }

    /// <summary>Whether the element should snap to other elements.</summary>
    /// <value>The snap to.</value>
    [DefaultValue(SnapTo.None)]
    [SRDescription("Whether the element should snap to other elements.")]
    public SnapTo SnapTo
    {
      get => this.menmSnapTo;
      set => this.menmSnapTo = value;
    }

    /// <summary>
    /// Determines which edges of snap elements the draggable will snap to. Ignored if the SnapTo option is off.. Possible values: "inner", "outer", "both", "Grid".
    /// </summary>
    /// <value>The snap mode.</value>
    [DefaultValue(SnapMode.Both)]
    [SRDescription("Determines which edges of snap elements the draggable will snap to. Ignored if the SnapTo option is off.. Possible values: \"inner\", \"outer\", \"both\",\"Grid\".")]
    public SnapMode SnapMode
    {
      get => this.menmSnapMode;
      set => this.menmSnapMode = value;
    }

    /// <summary>
    /// The distance in pixels from the snap element edges at which snapping should occur. Ignored if the SnapTo option is off.
    /// </summary>
    /// <value>The snap tolerance.</value>
    [DefaultValue(20)]
    [SRDescription("The distance in pixels from the snap element edges at which snapping should occur. Ignored if the SnapTo option is off.")]
    public int SnapTolerance
    {
      get => this.mintSnapTolerance;
      set => this.mintSnapTolerance = value;
    }

    /// <summary>
    /// Whether the element should revert to its start position when dragging stops.
    /// </summary>
    /// <value>The revert mode.</value>
    [DefaultValue(RevertMode.None)]
    [SRDescription("Whether the element should revert to its start position when dragging stops.")]
    public RevertMode RevertMode
    {
      get => this.menmRevertMode;
      set => this.menmRevertMode = value;
    }

    /// <summary>
    /// The duration of the revert animation, in milliseconds. Ignored if the RevertMode option is none.
    /// </summary>
    /// <value>The duration of the revert.</value>
    [DefaultValue(500)]
    [SRDescription("The duration of the revert animation, in milliseconds. Ignored if the RevertMode option is none.")]
    public int RevertDuration
    {
      get => this.mintRevertDuration;
      set => this.mintRevertDuration = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether negative axes values are permitted.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [allow negative axes values]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool AllowNegativeAxes
    {
      get => this.mblnAllowNegativeAxes;
      set => this.mblnAllowNegativeAxes = value;
    }
  }
}
