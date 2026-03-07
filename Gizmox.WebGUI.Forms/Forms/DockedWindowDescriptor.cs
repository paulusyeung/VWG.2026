// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedWindowDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class DockedWindowDescriptor : DockedObjectDescriptor
  {
    private Type mobjWindowType;
    private string mstrText;
    private string mstrHeaderText;
    private string mstrHeaderToolTip;
    private string mstrTabHeaderToolTip;
    private DockingWindowName mobjWindowName;
    private DockState menmCurrentDockState;
    private DockState menmLastDockState;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedWindowDescriptor" /> class.
    /// </summary>
    /// <param name="objWindow">The obj window.</param>
    public DockedWindowDescriptor(DockingWindow objWindow)
    {
      this.mobjWindowName = new DockingWindowName();
      this.mobjWindowType = objWindow.GetType();
    }

    /// <summary>Gets or sets the text.</summary>
    /// <value>The text.</value>
    public string Text => this.mstrText;

    /// <summary>Gets the type of the window.</summary>
    /// <value>The type of the window.</value>
    public Type WindowType => this.mobjWindowType;

    /// <summary>Gets or sets the state of the current dock.</summary>
    /// <value>The state of the current dock.</value>
    internal DockState CurrentDockState
    {
      get => this.menmCurrentDockState;
      set => this.menmCurrentDockState = value;
    }

    /// <summary>
    /// Determines whether this instance [can update from] the specified obj type.
    /// </summary>
    /// <param name="objType">Type of the obj.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
    /// </returns>
    internal override bool CanUpdateFrom(Type objType) => objType == typeof (DockedTabControl);

    /// <summary>Clones the without references.</summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal override T CloneWithoutReferences<T>() => throw new NotImplementedException();

    /// <summary>Updates from tab control.</summary>
    /// <param name="objDockedTabControl">The obj docked tab control.</param>
    /// <param name="blnPreventExtraction">if set to <c>true</c> [BLN prevent extraction].</param>
    internal override void UpdateFromTabControl(
      DockedTabControl objDockedTabControl,
      bool blnPreventExtraction)
    {
      if (blnPreventExtraction)
        return;
      objDockedTabControl.OwningZone.Manager.HandleWindowStateChanged(this, objDockedTabControl);
    }

    /// <summary>Updates the self.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objManager"></param>
    internal override void UpdateSelf(Control objControl, DockingManager objManager)
    {
      if (!(objControl is DockingWindow dockingWindow))
        return;
      this.mstrText = dockingWindow.Text;
      this.mobjWindowName.WindowName = dockingWindow.Name;
    }

    /// <summary>Gets the name of the window.</summary>
    /// <value>The name of the window.</value>
    internal DockingWindowName WindowName => this.mobjWindowName;

    /// <summary>Gets or sets the header text.</summary>
    /// <value>The header text.</value>
    public string HeaderText
    {
      get => this.mstrHeaderText;
      set => this.mstrHeaderText = value;
    }

    /// <summary>Gets or sets the header tool tip.</summary>
    /// <value>The header tool tip.</value>
    public string HeaderToolTip
    {
      get => this.mstrHeaderToolTip;
      set => this.mstrHeaderToolTip = value;
    }

    /// <summary>Gets or sets the tab header tool tip.</summary>
    /// <value>The tab header tool tip.</value>
    public string TabHeaderToolTip
    {
      get => this.mstrTabHeaderToolTip;
      set => this.mstrTabHeaderToolTip = value;
    }

    /// <summary>Gets or sets the last state of the dock.</summary>
    /// <value>The last state of the dock.</value>
    public DockState LastDockState
    {
      get => this.menmLastDockState;
      set => this.menmLastDockState = value;
    }
  }
}
