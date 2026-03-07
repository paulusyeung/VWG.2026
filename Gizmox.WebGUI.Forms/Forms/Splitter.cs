// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Splitter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a splitter control that enables the user to resize docked controls. <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> has been replaced by <see cref="T:System.Windows.Forms.SplitContainer"></see> and is provided only for compatibility with previous versions.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (Splitter), "Splitter_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("S")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (SplitterSkin))]
  [Serializable]
  public class Splitter : Control
  {
    /// <summary>The SplitterMoved event registration.</summary>
    private static readonly SerializableEvent SplitterMovedEvent = SerializableEvent.Register("SplitterMoved", typeof (SplitterEventHandler), typeof (Splitter));
    private static readonly SerializableProperty SplitterFixedProperty = SerializableProperty.Register("SplitterFixed", typeof (bool), typeof (Splitter), new SerializablePropertyMetadata((object) false));

    /// <summary>Gets the hanlder for the SplitterMoved event.</summary>
    private SplitterEventHandler SplitterMovedHandler => (SplitterEventHandler) this.GetHandler(Splitter.SplitterMovedEvent);

    /// <summary>Occurs when the Splitter is Moved.</summary>
    [SRDescription("SplitterSplitterMovedDescr")]
    [SRCategory("CatBehavior")]
    public event SplitterEventHandler SplitterMoved
    {
      add => this.AddCriticalHandler(Splitter.SplitterMovedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Splitter.SplitterMovedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether in this instance the splitter is fixed or movable.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is splitter fixed. otherwise, <c>false</c>.
    /// </value>
    [SRCategory("CatLayout")]
    [DefaultValue(false)]
    public bool IsSplitterFixed
    {
      get => this.GetValue<bool>(Splitter.SplitterFixedProperty);
      set
      {
        if (!this.SetValue<bool>(Splitter.SplitterFixedProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>An abstract control method rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.RenderControls(objContext, objWriter, 0L);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderIsSplitterFixedAttribute(objWriter, false);
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderIsSplitterFixedAttribute(objWriter, true);
    }

    /// <summary>Renders the is splitter fixed attribute.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderIsSplitterFixedAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool isSplitterFixed = this.IsSplitterFixed;
      if (!(blnForceRender | isSplitterFixed))
        return;
      objWriter.WriteAttributeString("ISF", isSplitterFixed ? "1" : "0");
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      int num1 = 0;
      int num2 = 0;
      double dblValue = 0.0;
      int num3 = 0;
      if (objEvent.Type == "SplitterMoved")
      {
        if (CommonUtils.TryParse(objEvent["Size"], out dblValue))
          num3 = Convert.ToInt32(dblValue);
        if (CommonUtils.TryParse(objEvent["X"], out dblValue))
          num1 = Convert.ToInt32(dblValue);
        if (CommonUtils.TryParse(objEvent["Y"], out dblValue))
          num2 = Convert.ToInt32(dblValue);
        if (this.Context != null && this.Context.Session != null && ((ISessionRegistry) this.Context).GetRegisteredComponent(objEvent.Target) is Control registeredComponent)
        {
          switch (this.Dock)
          {
            case DockStyle.Top:
            case DockStyle.Bottom:
              if (registeredComponent.SetBounds(0, 0, 0, num3, BoundsSpecified.Height, true))
              {
                registeredComponent.OnResizeInternal(new LayoutEventArgs(true, true, true));
                break;
              }
              break;
            case DockStyle.Right:
            case DockStyle.Left:
              if (registeredComponent.SetBounds(0, 0, num3, 0, BoundsSpecified.Width))
              {
                registeredComponent.OnResizeInternal(new LayoutEventArgs(true, true, true));
                break;
              }
              break;
          }
        }
        this.OnSplitterMoved(new SplitterEventArgs(num1, num2, num1, num2));
      }
      base.FireEvent(objEvent);
    }

    /// <summary>Occurs when [client splitter moved].</summary>
    [SRDescription("Occurs when splitter moved in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientSplitterMoved
    {
      add => this.AddClientHandler("SplitterMoved", value);
      remove => this.RemoveClientHandler("SplitterMoved", value);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.SplitterMovedHandler != null)
        criticalEventsData.Set("PC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("SplitterMoved"))
        clientEventsData.Set("PC");
      return clientEventsData;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> class. <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> has been replaced by <see cref="T:Gizmox.WebGUI.Forms.SplitContainer"></see>, and is provided only for compatibility with previous versions.
    /// </summary>
    public Splitter()
    {
      this.SetStyle(ControlStyles.Selectable, false);
      this.Dock = DockStyle.Left;
      this.Width = 3;
      this.Height = 3;
      this.TabStop = false;
    }

    /// <summary>Raises the SplitterMoved event.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterEventArgs" /> instance containing the event data.</param>
    protected virtual void OnSplitterMoved(SplitterEventArgs e)
    {
      SplitterEventHandler splitterMovedHandler = this.SplitterMovedHandler;
      if (splitterMovedHandler == null)
        return;
      splitterMovedHandler((object) this, e);
    }

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets/Sets the controls docking style</summary>
    [DefaultValue(DockStyle.Left)]
    public override DockStyle Dock
    {
      get => base.Dock;
      set
      {
        if (value != DockStyle.Top && value != DockStyle.Bottom && value != DockStyle.Left && value != DockStyle.Right)
          throw new ArgumentException(SR.GetString("SplitterInvalidDockEnum"));
        int width = this.Width;
        int height = this.Height;
        DockStyle dock = base.Dock;
        if (dock == value)
          return;
        base.Dock = value;
        switch (this.Dock)
        {
          case DockStyle.Top:
          case DockStyle.Bottom:
            if (dock != DockStyle.Left && dock != DockStyle.Right)
              break;
            this.Height = width;
            break;
          case DockStyle.Right:
          case DockStyle.Left:
            if (dock != DockStyle.Top && dock != DockStyle.Bottom)
              break;
            this.Width = height;
            break;
        }
      }
    }
  }
}
