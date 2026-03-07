// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedFormDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class DockedFormDescriptor : DockedObjectDescriptor
  {
    private long mlngOwningFormId;
    private Point mobjLocation;
    private Size mobjSize;
    private FormWindowState menmWindowState;

    /// <summary>Gets or sets the state of the window.</summary>
    /// <value>The state of the window.</value>
    public FormWindowState WindowState
    {
      get => this.menmWindowState;
      set => this.menmWindowState = value;
    }

    /// <summary>Gets the location.</summary>
    public Point Location => this.mobjLocation;

    /// <summary>Gets the owning form id.</summary>
    public long OwningFormId
    {
      get => this.mlngOwningFormId;
      set => this.mlngOwningFormId = value;
    }

    /// <summary>Gets the size.</summary>
    public Size Size => this.mobjSize;

    /// <summary>
    /// Determines whether this instance [can update from] the specified obj type.
    /// </summary>
    /// <param name="objType">Type of the obj.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
    /// </returns>
    internal override bool CanUpdateFrom(Type objType) => typeof (DockingManager).IsAssignableFrom(objType);

    /// <summary>Clones without references.</summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal override T CloneWithoutReferences<T>() => throw new NotImplementedException();

    /// <summary>Forms the closing.</summary>
    internal void FormClosing() => this.mlngOwningFormId = -1L;

    /// <summary>Updates the self.</summary>
    /// <param name="objControl">The obj control.</param>
    internal override void UpdateSelf(Control objControl, DockingManager objManager)
    {
      DockedForm dockedForm = objControl as DockedForm;
      this.menmWindowState = dockedForm.WindowState;
      this.mobjSize = dockedForm.Size;
      this.mobjLocation = dockedForm.Location;
    }
  }
}
