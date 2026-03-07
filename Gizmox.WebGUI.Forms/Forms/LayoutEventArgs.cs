// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LayoutEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides data for the Layout event. This class cannot be inherited.
  /// </summary>
  [Serializable]
  public sealed class LayoutEventArgs : EventArgs
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly IComponent affectedComponent;
    /// <summary>
    /// 
    /// </summary>
    private readonly string mstrAffectedProperty;
    /// <summary>
    /// 
    /// </summary>
    private readonly bool mblnIsClientSource;
    /// <summary>
    /// 
    /// </summary>
    private readonly bool mblnShouldUpdateSiblings;
    /// <summary>
    /// 
    /// </summary>
    private readonly bool mblnShouldUpdateParent;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> class.
    /// </summary>
    /// <param name="objAffectedComponent">The affected component.</param>
    /// <param name="strAffectedProperty">The affected property.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public LayoutEventArgs(IComponent objAffectedComponent, string strAffectedProperty)
    {
      this.affectedComponent = objAffectedComponent;
      this.mstrAffectedProperty = strAffectedProperty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> class.
    /// </summary>
    /// <param name="objAffectedControl">The affected control.</param>
    /// <param name="strAffectedProperty">The affected property.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public LayoutEventArgs(Control objAffectedControl, string strAffectedProperty)
      : this((IComponent) objAffectedControl, strAffectedProperty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> class.
    /// </summary>
    /// <param name="blnIsClientSource">if set to <c>true</c> is client source.</param>
    /// <param name="blnShouldUpdateSiblings">if set to <c>true</c> should update siblings.</param>
    /// <param name="blnShouldUpdateParent">if set to <c>true</c> [BLN should update parent].</param>
    public LayoutEventArgs(
      bool blnIsClientSource,
      bool blnShouldUpdateSiblings,
      bool blnShouldUpdateParent)
    {
      this.mblnIsClientSource = blnIsClientSource;
      this.mblnShouldUpdateSiblings = blnShouldUpdateSiblings;
      this.mblnShouldUpdateParent = blnShouldUpdateParent;
    }

    /// <summary>Clones the specified should update siblings.</summary>
    /// <param name="blnShouldUpdateSiblings">if set to <c>true</c> should update siblings.</param>
    /// <param name="blnShouldUpdateParent">if set to <c>true</c> [BLN should update parent].</param>
    /// <returns></returns>
    public LayoutEventArgs Clone(bool blnShouldUpdateSiblings, bool blnShouldUpdateParent) => new LayoutEventArgs(this.IsClientSource, blnShouldUpdateSiblings, blnShouldUpdateParent);

    /// <summary>Gets the affected component.</summary>
    /// <value>The affected component.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IComponent AffectedComponent => this.affectedComponent;

    /// <summary>Gets the affected control.</summary>
    /// <value>The affected control.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control AffectedControl => this.affectedComponent as Control;

    /// <summary>Gets the affected property.</summary>
    /// <value>The affected property.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string AffectedProperty => this.mstrAffectedProperty;

    /// <summary>
    /// Gets a value indicating whether this event is client source.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this event is client source; otherwise, <c>false</c>.
    /// </value>
    public bool IsClientSource => this.mblnIsClientSource;

    /// <summary>
    /// Gets a value indicating whether should update siblings.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if should update siblings; otherwise, <c>false</c>.
    /// </value>
    public bool ShouldUpdateSiblings => this.mblnShouldUpdateSiblings;

    /// <summary>
    /// Gets a value indicating whether [should update parent].
    /// </summary>
    /// <value><c>true</c> if [should update parent]; otherwise, <c>false</c>.</value>
    public bool ShouldUpdateParent => this.mblnShouldUpdateParent;
  }
}
