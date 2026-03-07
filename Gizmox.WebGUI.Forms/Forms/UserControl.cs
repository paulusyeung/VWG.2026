// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.UserControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides an empty control that can be used to create other controls.
  /// </summary>
  [ToolboxItem(true)]
  [DesignerCategory("UserControl")]
  [DefaultEvent("Load")]
  [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof (IRootDesigner))]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [Gizmox.WebGUI.Forms.MetadataTag("UC")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (UserControlSkin))]
  [Serializable]
  public class UserControl : 
    ContainerControl,
    IUserControl,
    IControl,
    IRegisteredComponent,
    IEventHandler,
    IWin32Window
  {
    /// <summary>The Load event registration.</summary>
    private static readonly SerializableEvent LoadEvent = SerializableEvent.Register("Load", typeof (EventHandler), typeof (UserControl));
    /// <summary>The current context object</summary>
    [NonSerialized]
    private IContext mobjContext;

    /// <summary>
    /// Occurs before the control becomes visible for the first time.
    /// </summary>
    [SRCategory("CatBehavior")]
    [SRDescription("UserControlOnLoadDescr")]
    public event EventHandler Load
    {
      add => this.AddHandler(UserControl.LoadEvent, (Delegate) value);
      remove => this.RemoveHandler(UserControl.LoadEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Load event.</summary>
    private EventHandler LoadHandler => (EventHandler) this.GetHandler(UserControl.LoadEvent);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UserControl"></see> class.
    /// </summary>
    public UserControl() => this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

    /// <summary>Renders the specified obj context.</summary>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.RenderControls(objContext, objWriter, lngRequestID);
    }

    /// <summary>Raises the CreateControl event.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.OnLoad(EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.UserControl.Load"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnLoad(EventArgs e)
    {
      EventHandler loadHandler = this.LoadHandler;
      if (loadHandler == null)
        return;
      loadHandler((object) this, e);
    }

    /// <summary>Determines whether has focusable child.</summary>
    /// <returns>
    /// 	<c>true</c> if has focusable child; otherwise, <c>false</c>.
    /// </returns>
    internal bool HasFocusableChild()
    {
      Control objControl = (Control) null;
      do
      {
        objControl = this.GetNextControl(objControl, true);
      }
      while ((objControl == null || !objControl.CanSelect || !objControl.TabStop) && objControl != null);
      return objControl != null;
    }

    /// <summary>
    /// Causes all of the child controls within a control that support validation to validate their data.
    /// </summary>
    /// <param name="validationConstraints">Tells <see cref="M:System.Windows.Forms.ContainerControl.ValidateChildren(System.Windows.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
    /// <returns>
    /// true if all of the children validated successfully; otherwise, false.
    /// </returns>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override bool ValidateChildren(ValidationConstraints validationConstraints) => base.ValidateChildren(validationConstraints);

    /// <summary>This property is not relevant for this class.</summary>
    /// <value></value>
    /// <returns>true if enabled; otherwise, false.</returns>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>Indicates the automatic sizing behavior of the control.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new virtual AutoSizeMode AutoSizeMode
    {
      get => base.AutoSizeMode;
      set => base.AutoSizeMode = ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 1) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (AutoSizeMode));
    }

    /// <summary>Gets the context.</summary>
    /// <value></value>
    public override IContext Context => this.mobjContext != null ? this.mobjContext : base.Context;

    /// <summary>Sets the context.</summary>
    /// <param name="objContext">The context.</param>
    void IUserControl.SetContext(IContext objContext) => this.mobjContext = objContext;
  }
}
