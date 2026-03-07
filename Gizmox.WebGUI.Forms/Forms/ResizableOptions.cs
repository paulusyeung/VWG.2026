// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ResizableOptions
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// This class represents the abilities of the jquery Resizable.
  /// </summary>
  [TypeConverter(typeof (ResizableOptionsTypeConverter))]
  [Serializable]
  public class ResizableOptions : JQueryUIOptions
  {
    private bool mblnIsResizable = true;
    private Component[] mobjAlsoResize = new Component[0];
    private bool mblnAnimate;
    private int mintAnimateDuration = 500;
    private bool mblnAspectRatio;
    private bool mblnAutoHide;
    private ContainmentMode menmContainmentMode;
    private bool mblnGhost;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ResizableOptions" /> class.
    /// </summary>
    internal ResizableOptions()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ResizableOptions" /> class.
    /// </summary>
    /// <param name="blnIsResizable">if set to <c>true</c> [BLN is Resizable].</param>
    public ResizableOptions(bool blnIsResizable) => this.mblnIsResizable = blnIsResizable;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ResizableOptions" /> class.
    /// </summary>
    /// <param name="blnIsResizable">if set to <c>true</c> [BLN is Resizable].</param>
    /// <param name="objAlsoResize">The obj also resize.</param>
    /// <param name="blnAnimate">if set to <c>true</c> [BLN animate].</param>
    /// <param name="intAnimateDuration">Duration of the int animate.</param>
    /// <param name="blnAspectRatio">if set to <c>true</c> [BLN aspect ratio].</param>
    /// <param name="blnAutoHide">if set to <c>true</c> [BLN auto hide].</param>
    /// <param name="enmContainmentMode">The enm containment mode.</param>
    /// <param name="blnGhost">if set to <c>true</c> [BLN ghost].</param>
    /// <param name="intXgrid">The int xgrid.</param>
    /// <param name="intYgrid">The int ygrid.</param>
    public ResizableOptions(
      bool blnIsResizable,
      Component[] objAlsoResize,
      bool blnAnimate,
      int intAnimateDuration,
      bool blnAspectRatio,
      bool blnAutoHide,
      ContainmentMode enmContainmentMode,
      bool blnGhost,
      int intXgrid,
      int intYgrid)
      : base(intXgrid, intYgrid)
    {
      this.mblnIsResizable = blnIsResizable;
      this.mobjAlsoResize = objAlsoResize;
      this.mblnAnimate = blnAnimate;
      this.mintAnimateDuration = intAnimateDuration;
      this.mblnAspectRatio = blnAspectRatio;
      this.mblnAutoHide = blnAutoHide;
      this.menmContainmentMode = enmContainmentMode;
      this.mblnGhost = blnGhost;
    }

    /// <summary>Determines whether this instance is default.</summary>
    /// <returns>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </returns>
    internal new bool IsDefault() => base.IsDefault() && (this.mobjAlsoResize == null || this.mobjAlsoResize.Length == 0) && !this.mblnAnimate && this.mintAnimateDuration == 500 && !this.mblnAspectRatio && !this.mblnAutoHide && this.menmContainmentMode == ContainmentMode.None && !this.mblnGhost;

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", this.mblnIsResizable ? (object) "1" : (object) "0", this.mblnAnimate ? (object) "1" : (object) "0", (object) this.mintAnimateDuration, this.mblnAspectRatio ? (object) "1" : (object) "0", this.mblnAutoHide ? (object) "1" : (object) "0", (object) (int) this.menmContainmentMode, this.mblnGhost ? (object) "1" : (object) "0", (object) base.ToString());

    /// <summary>To the render string.</summary>
    /// <returns></returns>
    internal new string ToRenderString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(base.ToRenderString());
      if (this.mblnAnimate)
      {
        stringBuilder.AppendFormat("{0}|", (object) "animate:true");
        if (this.mintAnimateDuration != 500)
          stringBuilder.AppendFormat("{0}|", (object) ("animateDuration:" + (object) this.mintAnimateDuration));
      }
      if (this.mblnAspectRatio)
        stringBuilder.AppendFormat("{0}|", (object) "aspectRatio:true");
      if (this.mblnAutoHide)
        stringBuilder.AppendFormat("{0}|", (object) "autoHide:true");
      if (this.mblnGhost)
        stringBuilder.AppendFormat("{0}|", (object) "ghost:true");
      if (this.menmContainmentMode != ContainmentMode.None)
      {
        if (this.menmContainmentMode == ContainmentMode.Form)
          stringBuilder.AppendFormat("{0}|", (object) "containment:\\'document\\'");
        else if (this.menmContainmentMode == ContainmentMode.Parent)
          stringBuilder.AppendFormat("{0}|", (object) "containment:\\'parent\\'");
      }
      if (this.mobjAlsoResize != null && this.mobjAlsoResize.Length != 0)
      {
        stringBuilder.Append("alsoResize:\\'");
        bool flag = true;
        foreach (Component component in this.mobjAlsoResize)
        {
          if (!flag)
            stringBuilder.Append(",");
          stringBuilder.AppendFormat("#VWG_{0}", (object) component.ID);
          flag = false;
        }
        stringBuilder.Append("\\'|");
      }
      return stringBuilder.ToString().TrimEnd('|');
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is Resizable.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is Resizable; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("One or more elements to resize synchronously with the resizable element.")]
    public bool IsResizable
    {
      get => this.mblnIsResizable;
      set => this.mblnIsResizable = value;
    }

    /// <summary>
    /// One or more elements to resize synchronously with the resizable element.
    /// </summary>
    /// <value>The also resize.</value>
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [TypeConverter(typeof (JQueryUIOptionsComponentTypeConverter))]
    [SRDescription("Gets or sets a value indicating whether this instance is Resizable.")]
    public Component[] AlsoResize
    {
      get => this.mobjAlsoResize;
      set => this.mobjAlsoResize = value;
    }

    /// <summary>
    /// Animates to the final size after resizing.
    /// Due to a known bug in jQeury (http://bugs.jqueryui.com/ticket/7453), this property is hidden at the moment.
    /// </summary>
    /// <value>
    ///   <c>true</c> if animate; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    [SRDescription("Animates to the final size after resizing.")]
    public bool Animate
    {
      get => this.mblnAnimate;
      set => this.mblnAnimate = value;
    }

    /// <summary>How long to animate when using the animate option.</summary>
    /// <value>The duration of the animate.</value>
    [Browsable(false)]
    [SRDescription("How long to animate when using the animate option.")]
    public int AnimateDuration
    {
      get => this.mintAnimateDuration;
      set => this.mintAnimateDuration = value;
    }

    /// <summary>
    /// Whether the element should be constrained to a specific aspect ratio.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [aspect ratio]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("Whether the element should be constrained to a specific aspect ratio.")]
    public bool AspectRatio
    {
      get => this.mblnAspectRatio;
      set => this.mblnAspectRatio = value;
    }

    /// <summary>
    /// Whether the handles should hide when the user is not hovering over the element.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [auto hide]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("Whether the handles should hide when the user is not hovering over the element.")]
    public bool AutoHide
    {
      get => this.mblnAutoHide;
      set => this.mblnAutoHide = value;
    }

    /// <summary>
    /// Constrains resizing to within the bounds of the specified element or region.
    /// </summary>
    /// <value>The containment mode.</value>
    [SRDescription("Constrains resizing to within the bounds of the specified element or region.")]
    public ContainmentMode ContainmentMode
    {
      get => this.menmContainmentMode;
      set => this.menmContainmentMode = value;
    }

    /// <summary>
    /// If set to true, a semi-transparent helper element is shown for resizing.
    /// </summary>
    /// <value>
    ///   <c>true</c> if ghost; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("If set to true, a semi-transparent helper element is shown for resizing.")]
    public bool Ghost
    {
      get => this.mblnGhost;
      set => this.mblnGhost = value;
    }

    /// <summary>Converts from string.</summary>
    /// <param name="strValues">The STR values.</param>
    /// <returns></returns>
    internal void ConvertFromString(string strValue)
    {
      string[] strArray = strValue.Split('|');
      if (strArray.Length == 9)
      {
        this.IsResizable = strArray[0] == "1";
        this.Animate = strArray[1] == "1";
        this.AnimateDuration = int.Parse(strArray[2]);
        this.AspectRatio = strArray[3] == "1";
        this.AutoHide = strArray[4] == "1";
        this.ContainmentMode = (ContainmentMode) int.Parse(strArray[5]);
        this.Ghost = strArray[6] == "1";
        this.ConvertFromString(strArray[7], strArray[8]);
      }
      else if (strArray.Length == 1)
        this.IsResizable = strArray[0] == "1";
      else
        this.IsResizable = false;
    }
  }
}
