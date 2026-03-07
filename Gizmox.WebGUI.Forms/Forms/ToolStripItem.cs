// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItem
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [DefaultProperty("Text")]
  [DefaultEvent("Click")]
  [ToolboxItem(false)]
  [DesignTimeVisible(false)]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public abstract class ToolStripItem : 
    Component,
    IDropTarget,
    IArrangedElement,
    IComponent,
    IDisposable,
    IRegisteredComponentMember,
    IEventHandler,
    ISkinable
  {
    private static readonly SerializableProperty mobjParentProperty = SerializableProperty.Register(nameof (mobjParent), typeof (ToolStrip), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjOwnerProperty = SerializableProperty.Register(nameof (mobjOwner), typeof (ToolStrip), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjFontProperty = SerializableProperty.Register(nameof (mobjFont), typeof (Font), typeof (ToolStripItem));
    private static readonly SerializableProperty menmDisplayStyleProperty = SerializableProperty.Register(nameof (menmDisplayStyle), typeof (ToolStripItemDisplayStyle), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjBoundsProperty = SerializableProperty.Register(nameof (mobjBounds), typeof (Rectangle), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjTagProperty = SerializableProperty.Register(nameof (mobjTag), typeof (object), typeof (ToolStripItem));
    private static readonly SerializableProperty mstrTextProperty = SerializableProperty.Register(nameof (mstrText), typeof (string), typeof (ToolStripItem));
    private static readonly SerializableProperty menmRightToLeftProperty = SerializableProperty.Register(nameof (menmRightToLeft), typeof (RightToLeft), typeof (ToolStripItem));
    private static readonly SerializableProperty mblnEnabledProperty = SerializableProperty.Register(nameof (mblnEnabled), typeof (bool), typeof (ToolStripItem));
    private static readonly SerializableProperty mblnDoubleClickEnabledProperty = SerializableProperty.Register(nameof (mblnDoubleClickEnabled), typeof (bool), typeof (ToolStripItem));
    private static readonly SerializableProperty menmDockProperty = SerializableProperty.Register(nameof (menmDock), typeof (DockStyle), typeof (ToolStripItem));
    private static readonly SerializableProperty menmBackgroundImageLayoutProperty = SerializableProperty.Register(nameof (menmBackgroundImageLayout), typeof (ImageLayout), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjBackgroundImageProperty = SerializableProperty.Register(nameof (mobjBackgroundImage), typeof (ResourceHandle), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjBackColorProperty = SerializableProperty.Register(nameof (mobjBackColor), typeof (Color), typeof (ToolStripItem));
    private static readonly SerializableProperty menmAlignmentProperty = SerializableProperty.Register(nameof (menmAlignment), typeof (ToolStripItemAlignment), typeof (ToolStripItem));
    private static readonly SerializableProperty menmAnchorProperty = SerializableProperty.Register(nameof (menmAnchor), typeof (AnchorStyles), typeof (ToolStripItem));
    private static readonly SerializableProperty mblnAutoSizeProperty = SerializableProperty.Register(nameof (mblnAutoSize), typeof (bool), typeof (ToolStripItem));
    private static readonly SerializableProperty mblnAutoToolTipProperty = SerializableProperty.Register(nameof (mblnAutoToolTip), typeof (bool), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjForeColorProperty = SerializableProperty.Register(nameof (mobjForeColor), typeof (Color), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjImageProperty = SerializableProperty.Register(nameof (mobjImage), typeof (ResourceHandle), typeof (ToolStripItem));
    private static readonly SerializableProperty menmImageAlignProperty = SerializableProperty.Register(nameof (menmImageAlign), typeof (ContentAlignment), typeof (ToolStripItem));
    private static readonly SerializableProperty mintImageIndexProperty = SerializableProperty.Register(nameof (mintImageIndex), typeof (int), typeof (ToolStripItem), new SerializablePropertyMetadata((object) -1));
    private static readonly SerializableProperty mstrImageKeyProperty = SerializableProperty.Register(nameof (mstrImageKey), typeof (string), typeof (ToolStripItem), new SerializablePropertyMetadata((object) string.Empty));
    private static readonly SerializableProperty mobjMarginProperty = SerializableProperty.Register(nameof (mobjMargin), typeof (Padding), typeof (ToolStripItem));
    private static readonly SerializableProperty menmMergeActionProperty = SerializableProperty.Register(nameof (menmMergeAction), typeof (MergeAction), typeof (ToolStripItem));
    private static readonly SerializableProperty mintMergeIndexProperty = SerializableProperty.Register(nameof (mintMergeIndex), typeof (int), typeof (ToolStripItem), new SerializablePropertyMetadata((object) -1));
    private static readonly SerializableProperty mstrNameProperty = SerializableProperty.Register(nameof (mstrName), typeof (string), typeof (ToolStripItem));
    private static readonly SerializableProperty mobjPaddingProperty = SerializableProperty.Register(nameof (mobjPadding), typeof (Padding), typeof (ToolStripItem));
    private static readonly SerializableProperty menmPlacementProperty = SerializableProperty.Register(nameof (menmPlacement), typeof (ToolStripItemPlacement), typeof (ToolStripItem));
    private static readonly SerializableProperty mblnRightToLeftAutoMirrorImageProperty = SerializableProperty.Register(nameof (mblnRightToLeftAutoMirrorImage), typeof (bool), typeof (ToolStripItem));
    private static readonly SerializableProperty menmTextAlignProperty = SerializableProperty.Register(nameof (menmTextAlign), typeof (ContentAlignment), typeof (ToolStripItem));
    private static readonly SerializableProperty menmTextDirectionProperty = SerializableProperty.Register(nameof (menmTextDirection), typeof (ToolStripTextDirection), typeof (ToolStripItem));
    private static readonly SerializableProperty menmTextImageRelationProperty = SerializableProperty.Register(nameof (menmTextImageRelation), typeof (TextImageRelation), typeof (ToolStripItem));
    private static readonly SerializableProperty memnImageScalingProperty = SerializableProperty.Register("memnImageScaling", typeof (ToolStripItemImageScaling), typeof (ToolStripItem));
    private static readonly SerializableProperty mstrToolTipTextProperty = SerializableProperty.Register(nameof (mstrToolTipText), typeof (string), typeof (ToolStripItem));
    private static readonly SerializableProperty mstrCustomStyleProperty = SerializableProperty.Register(nameof (CustomStyle), typeof (string), typeof (ToolStripItem), new SerializablePropertyMetadata((object) string.Empty));
    private static readonly SerializableEvent AvailableChangedEvent = SerializableEvent.Register("AvailableChanged", typeof (EventHandler), typeof (ToolStripItem));
    private static readonly SerializableEvent BackColorChangedEvent = SerializableEvent.Register("BackColorChanged", typeof (EventHandler), typeof (ToolStripItem));
    protected static readonly SerializableEvent ClickEvent = SerializableEvent.Register(nameof (ClickEvent), typeof (EventHandler), typeof (ToolStripItem));
    private static readonly SerializableEvent DisplayStyleChangedEvent = SerializableEvent.Register("DisplayStyleChanged", typeof (EventHandler), typeof (ToolStripItem));
    protected static readonly SerializableEvent DoubleClickEvent = SerializableEvent.Register("DoubleClick", typeof (EventHandler), typeof (ToolStripItem));
    private static readonly SerializableEvent EnabledChangedEvent = SerializableEvent.Register("EnabledChanged", typeof (EventHandler), typeof (ToolStripItem));
    private static readonly SerializableEvent ForeColorChangedEvent = SerializableEvent.Register("ForeColorChanged", typeof (EventHandler), typeof (ToolStripItem));
    private static readonly SerializableEvent LocationChangedEvent = SerializableEvent.Register("LocationChanged", typeof (EventHandler), typeof (ToolStripItem));
    protected static readonly SerializableEvent MouseDownEvent = SerializableEvent.Register("MouseDown", typeof (EventHandler), typeof (ToolStripItem));
    protected static readonly SerializableEvent MouseUpEvent = SerializableEvent.Register("MouseUp", typeof (EventHandler), typeof (ToolStripItem));
    private static readonly SerializableEvent RightToLeftChangedEvent = SerializableEvent.Register("RightToLeftChanged", typeof (EventHandler), typeof (ToolStripItem));
    private static readonly SerializableEvent OwnerChangedEvent = SerializableEvent.Register("OwnerChanged", typeof (EventHandler), typeof (ToolStripItem));
    private static readonly SerializableEvent VisibleChangedEvent = SerializableEvent.Register("VisibleChanged", typeof (EventHandler), typeof (ToolStripItem));
    protected static readonly SerializableEvent TextChangedEvent = SerializableEvent.Register("TextChanged", typeof (EventHandler), typeof (ToolStripItem));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class.</summary>
    protected ToolStripItem()
    {
      this.mobjBounds = Rectangle.Empty;
      this.menmPlacement = ToolStripItemPlacement.None;
      this.menmImageAlign = ContentAlignment.MiddleCenter;
      this.menmTextAlign = ContentAlignment.MiddleCenter;
      this.menmTextImageRelation = TextImageRelation.ImageBeforeText;
      this.menmDisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
      this.ImageScaling = ToolStripItemImageScaling.SizeToFit;
      this.mblnAutoSize = true;
      this.mblnEnabled = true;
      this.mblnDoubleClickEnabled = false;
      this.SetState(Component.ComponentState.Visible | Component.ComponentState.Enabled, true);
      this.SetState(Component.ComponentState.Selected | Component.ComponentState.AllowDrop, false);
      this.mobjMargin = this.DefaultMargin;
      this.Size = this.DefaultSize;
      this.DisplayStyle = this.DefaultDisplayStyle;
      this.AutoToolTip = this.DefaultAutoToolTip;
      this.RegisterSelf();
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class with the specified name, image, and event handler.</summary>
    /// <param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
    /// <param name="text">A <see cref="T:System.String"></see> representing the name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
    protected ToolStripItem(string text, ResourceHandle image, EventHandler onClick)
      : this(text, image, onClick, (string) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class with the specified display text, image, event handler, and name. </summary>
    /// <param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
    /// <param name="image">The ResourceHandle to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
    protected ToolStripItem(string text, ResourceHandle image, EventHandler onClick, string name)
      : this()
    {
      this.Text = text;
      this.Image = image;
      if (onClick != null)
        this.Click += onClick;
      this.Name = name;
    }

    /// <summary>Begins a drag-and-drop operation.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEffects"></see> values.</returns>
    /// <param name="data">The object to be dragged. </param>
    /// <param name="allowedEffects">The drag operations that can occur. </param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects) => DragDropEffects.None;

    /// <summary>Retrieves the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the container of the current <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the container of the current <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public ToolStrip GetCurrentParent() => this.Parent;

    /// <summary>Retrieves the size of a rectangular area into which a control can be fit.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.</returns>
    /// <param name="objConstrainingSize">The custom-sized area for a control. </param>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public virtual Size GetPreferredSize(Size objConstrainingSize) => objConstrainingSize;

    /// <summary>Gets the preferred size with image.</summary>
    /// <param name="objSizeWithoutImage">The obj size without image.</param>
    /// <returns></returns>
    protected internal virtual Size GetPreferredSizeByImage(Size objSizeWithoutImage)
    {
      Size preferredSizeByImage = objSizeWithoutImage;
      if (this.Image != null && (this.DisplayStyle == ToolStripItemDisplayStyle.Image || this.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText))
      {
        int val2_1;
        int val2_2;
        switch (this.ImageScaling)
        {
          case ToolStripItemImageScaling.None:
            val2_1 = this.Image.Height;
            val2_2 = this.Image.Width;
            break;
          case ToolStripItemImageScaling.SizeToFit:
            ToolStrip parentInternal = this.ParentInternal;
            Size size = Size.Empty;
            if (this.ParentInternal != null)
              size = this.ParentInternal.ImageScalingSize;
            val2_1 = parentInternal != null ? size.Height : 16;
            val2_2 = parentInternal != null ? size.Width : 16;
            break;
          default:
            throw new NotImplementedException();
        }
        switch (this.TextImageRelation)
        {
          case TextImageRelation.Overlay:
            preferredSizeByImage.Width = Math.Max(objSizeWithoutImage.Width, val2_2);
            preferredSizeByImage.Height = Math.Max(objSizeWithoutImage.Height, val2_1);
            break;
          case TextImageRelation.ImageAboveText:
          case TextImageRelation.TextAboveImage:
            preferredSizeByImage.Width = Math.Max(objSizeWithoutImage.Width, val2_2);
            preferredSizeByImage.Height = objSizeWithoutImage.Height + val2_1;
            break;
          case TextImageRelation.ImageBeforeText:
          case TextImageRelation.TextBeforeImage:
            preferredSizeByImage.Height = Math.Max(objSizeWithoutImage.Height, val2_1);
            preferredSizeByImage.Width = objSizeWithoutImage.Width + val2_2;
            break;
          default:
            throw new NotImplementedException();
        }
      }
      return preferredSizeByImage;
    }

    /// <summary>Applies the size of the font to.</summary>
    /// <param name="objGivenSize">Size of the obj given.</param>
    /// <returns></returns>
    protected internal virtual Size GetPreferredeSizeByText() => this.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText || this.DisplayStyle == ToolStripItemDisplayStyle.Text ? this.GetTextSize(this.Text) : Size.Empty;

    /// <summary>Gets the size of the text.</summary>
    /// <param name="strText">The STR text.</param>
    /// <returns></returns>
    internal Size GetTextSize(string strText)
    {
      Font objFont = this.Font;
      if (objFont == null && this.ParentInternal != null)
        objFont = this.ParentInternal.Font;
      if (objFont == null)
        objFont = SkinFactory.GetSkin((ISkinable) this) is CommonSkin skin && skin.Font != null ? skin.Font : throw new NullReferenceException("ToolStripItem.ApplyToolStripItemTextToSize: The item does not have a font '" + this.Name + "'.");
      return CommonUtils.GetStringMeasurements(strText, objFont);
    }

    /// <summary>Applies the size of the button skin to.</summary>
    /// <param name="objSkin">The obj skin.</param>
    /// <param name="objBaseSize">Size of the obj given.</param>
    /// <returns></returns>
    protected internal Size GetPreferredSizeByButtonSkin(ButtonSkin objSkin, Size objBaseSize)
    {
      if (objSkin != null)
      {
        int buttonImageTextGap = objSkin.ButtonImageTextGap;
        BorderWidth borderWidth = objSkin.BorderWidth;
        Padding padding = (Padding) objSkin.Padding;
        objBaseSize.Width += borderWidth.Left + borderWidth.Right + buttonImageTextGap + padding.Horizontal;
        objBaseSize.Height += borderWidth.Top + borderWidth.Bottom + buttonImageTextGap + padding.Vertical;
      }
      return objBaseSize;
    }

    /// <summary>Invalidates the entire surface of the control and causes the control to be redrawn.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public void Invalidate()
    {
      if (this.ParentInternal == null)
        return;
      this.ParentInternal.Invalidate();
    }

    /// <summary>Invalidates the specified region of the control by adding it to the control's update region, which is the area that will be repainted at the next paint operation, and causes a paint message to be sent to the control.</summary>
    /// <param name="r">A <see cref="T:System.Drawing.Rectangle"></see> that represents the region to invalidate. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public void Invalidate(Rectangle r) => this.Invalidate();

    /// <summary>Sets the size and location of the item.</summary>
    /// <param name="bounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the <see cref="T:System.Windows.Forms.ToolStripItem"></see></param>
    protected internal virtual void SetBounds(Rectangle bounds)
    {
      Rectangle mobjBounds = this.mobjBounds;
      this.mobjBounds = bounds;
      if (this.mobjBounds != mobjBounds)
        this.OnBoundsChanged();
      if (!(this.mobjBounds.Location != mobjBounds.Location))
        return;
      this.OnLocationChanged(EventArgs.Empty);
    }

    internal void SetBounds(int x, int y, int width, int height) => this.SetBounds(new Rectangle(x, y, width, height));

    /// <summary>Raises the AvailableChanged event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnAvailableChanged(EventArgs e)
    {
      EventHandler availableChangedHandler = this.AvailableChangedHandler;
      if (availableChangedHandler == null)
        return;
      availableChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.BackColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBackColorChanged(EventArgs e)
    {
      this.Invalidate();
      EventHandler colorChangedHandler = this.BackColorChangedHandler;
      if (colorChangedHandler == null)
        return;
      colorChangedHandler((object) this, e);
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Bounds"></see> property changes.</summary>
    protected virtual void OnBoundsChanged()
    {
    }

    /// <summary>
    /// Raises the <see cref="E:Click" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnClick(EventArgs objEventArgs)
    {
      if (!(objEventArgs is MouseEventArgs e))
        e = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
      this.OnMouseDown(e);
      EventHandler clickHandler = this.ClickHandler;
      if (clickHandler != null)
        clickHandler((object) this, objEventArgs);
      this.OnMouseUp(e);
      this.Owner?.OnItemClicked(new ToolStripItemClickedEventArgs(this));
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DisplayStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnDisplayStyleChanged(EventArgs e)
    {
      EventHandler styleChangedHandler = this.DisplayStyleChangedHandler;
      if (styleChangedHandler == null)
        return;
      styleChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DoubleClick"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDoubleClick(EventArgs e)
    {
      EventHandler doubleClickHandler = this.DoubleClickHandler;
      if (doubleClickHandler == null)
        return;
      doubleClickHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragEnter"></see> event.</summary>
    /// <param name="dragEvent">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnDragEnter(DragEventArgs dragEvent)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragLeave"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnDragLeave(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragOver"></see> event.</summary>
    /// <param name="dragEvent">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnDragOver(DragEventArgs dragEvent)
    {
    }

    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    void IDropTarget.OnDragDrop(DragEventArgs dragEvent)
    {
    }

    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    void IDropTarget.OnDragEnter(DragEventArgs dragEvent)
    {
    }

    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    void IDropTarget.OnDragLeave(EventArgs e)
    {
    }

    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    void IDropTarget.OnDragOver(DragEventArgs dragEvent)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.EnabledChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnEnabledChanged(EventArgs e)
    {
      EventHandler enabledChangedHandler = this.EnabledChangedHandler;
      if (enabledChangedHandler == null)
        return;
      enabledChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.FontChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnFontChanged(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.ForeColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Always)]
    protected virtual void OnForeColorChanged(EventArgs e)
    {
      EventHandler colorChangedHandler = this.ForeColorChangedHandler;
      if (colorChangedHandler == null)
        return;
      colorChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.GiveFeedback"></see> event.</summary>
    /// <param name="giveFeedbackEvent">A <see cref="T:Gizmox.WebGUI.Forms.GiveFeedbackEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnGiveFeedback(GiveFeedbackEventArgs giveFeedbackEvent)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.LocationChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnLocationChanged(EventArgs e)
    {
      EventHandler locationChangedHandler = this.LocationChangedHandler;
      if (locationChangedHandler == null)
        return;
      locationChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseDown"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    protected virtual void OnMouseDown(MouseEventArgs e)
    {
      MouseEventHandler mouseDownHandler = this.MouseDownHandler;
      if (mouseDownHandler == null)
        return;
      mouseDownHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseEnter"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnMouseEnter(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseHover"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnMouseHover(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseLeave"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnMouseLeave(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseMove"></see> event.</summary>
    /// <param name="mea">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnMouseMove(MouseEventArgs mea)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseUp"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    protected virtual void OnMouseUp(MouseEventArgs e)
    {
      MouseEventHandler mouseUpHandler = this.MouseUpHandler;
      if (mouseUpHandler == null)
        return;
      mouseUpHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.OwnerChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnOwnerChanged(EventArgs e)
    {
      EventHandler ownerChangedHandler = this.OwnerChangedHandler;
      if (ownerChangedHandler != null)
        ownerChangedHandler((object) this, e);
      if (this.Owner == null || this.menmRightToLeft != RightToLeft.Inherit || this.RightToLeft == this.DefaultRightToLeft)
        return;
      this.OnRightToLeftChanged(EventArgs.Empty);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Paint"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnPaint(PaintEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.BackColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnParentBackColorChanged(EventArgs e)
    {
      if (!this.mobjBackColor.IsEmpty)
        return;
      this.OnBackColorChanged(e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.</summary>
    /// <param name="oldParent">The original parent of the item. </param>
    /// <param name="newParent">The new parent of the item. </param>
    protected virtual void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.ForeColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnParentForeColorChanged(EventArgs e)
    {
      if (!this.mobjForeColor.IsEmpty)
        return;
      this.OnForeColorChanged(e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.QueryContinueDrag"></see> event.</summary>
    /// <param name="queryContinueDragEvent">A <see cref="T:Gizmox.WebGUI.Forms.QueryContinueDragEventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnQueryContinueDrag(QueryContinueDragEventArgs queryContinueDragEvent)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeftChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnRightToLeftChanged(EventArgs e)
    {
      EventHandler leftChangedHandler = this.RightToLeftChangedHandler;
      if (leftChangedHandler == null)
        return;
      leftChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ParentEnabledChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected internal virtual void OnParentEnabledChanged(EventArgs e) => this.OnEnabledChanged(EventArgs.Empty);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.TextChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Always)]
    protected virtual void OnTextChanged(EventArgs e)
    {
      EventHandler textChangedHandler = this.TextChangedHandler;
      if (textChangedHandler == null)
        return;
      textChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.VisibleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnVisibleChanged(EventArgs e)
    {
      EventHandler visibleChangedHandler = this.VisibleChangedHandler;
      if (visibleChangedHandler == null)
        return;
      visibleChangedHandler((object) this, e);
    }

    /// <summary>Activates the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> when it is clicked with the mouse.</summary>
    public void PerformClick() => this.OnClick(new EventArgs());

    /// <summary>This method is not relevant to this class.</summary>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetBackColor() => this.BackColor = Color.Empty;

    /// <summary>This method is not relevant to this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetDisplayStyle() => this.DisplayStyle = this.DefaultDisplayStyle;

    /// <summary>This method is not relevant to this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetFont() => this.Font = (Font) null;

    /// <summary>Sets the owner.</summary>
    /// <param name="newOwner">The new owner.</param>
    internal void SetOwner(ToolStrip objNewOwner)
    {
      if (this.OwnerInternal == objNewOwner)
        return;
      Font font1 = this.Font;
      this.ParentInternal = this.OwnerInternal = objNewOwner;
      this.OnOwnerChanged(EventArgs.Empty);
      Font font2 = this.Font;
      if (font1 == font2)
        return;
      this.OnFontChanged(EventArgs.Empty);
    }

    /// <summary>This method is not relevant to this class.</summary>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetForeColor() => this.ForeColor = Color.Empty;

    /// <summary>Gets the owner font.</summary>
    /// <returns></returns>
    private Font GetOwnerFont() => this.Owner != null ? this.Owner.Font : (Font) null;

    /// <summary>Gets the name of the client component.</summary>
    /// <returns></returns>
    protected override string GetClientComponentName() => this.Name;

    /// <summary>Gets the client component ID.</summary>
    /// <returns></returns>
    protected override string GetClientComponentID() => this.Owner != null ? string.Format("{0}_{1}", (object) this.Owner.ID, (object) this.MemberID) : base.GetClientComponentID();

    /// <summary>This method is not relevant to this class.</summary>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetImage() => this.Image = (ResourceHandle) null;

    /// <summary>This method is not relevant to this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void ResetMargin() => this.mobjMargin = this.DefaultMargin;

    /// <summary>This method is not relevant to this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void ResetPadding() => this.mobjPadding = this.DefaultPadding;

    /// <summary>This method is not relevant to this class.</summary>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetRightToLeft() => this.RightToLeft = RightToLeft.Inherit;

    /// <summary>This method is not relevant to this class.</summary>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetTextDirection() => this.TextDirection = ToolStripTextDirection.Inherit;

    /// <summary>Selects the item.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public void Select()
    {
      if (!this.CanSelect || this.Owner != null || this.ParentInternal != null || this.Selected || !this.IsOnDropDown || this.OwnerItem == null || !this.OwnerItem.IsOnDropDown)
        return;
      this.OwnerItem.Select();
    }

    /// <summary>Sets the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to the specified visible state. </summary>
    /// <param name="visible">true to make the <see cref="T:System.Windows.Forms.ToolStripItem"></see> visible; otherwise, false.</param>
    protected virtual void SetVisibleCore(bool visible)
    {
      if (this.GetState(Component.ComponentState.Visible) == visible)
        return;
      this.SetState(Component.ComponentState.Visible, visible);
      this.OnAvailableChanged(EventArgs.Empty);
      this.OnVisibleChanged(EventArgs.Empty);
    }

    /// <summary>Sets the bounds.</summary>
    /// <param name="bounds">The bounds.</param>
    /// <param name="specified">The specified.</param>
    void IArrangedElement.SetBounds(Rectangle bounds, BoundsSpecified specified) => this.SetBounds(bounds);

    /// <summary>Gets the value.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objSerializableProperty">The serializable property.</param>
    /// <returns></returns>
    T IArrangedElement.GetValue<T>(SerializableProperty objSerializableProperty) => this.GetValue<T>(objSerializableProperty);

    /// <summary>Sets the value.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objSerializableProperty">The serializable property.</param>
    /// <param name="objValue">The obj value.</param>
    void IArrangedElement.SetValue<T>(SerializableProperty objSerializableProperty, T objValue) => this.SetValue<T>(objSerializableProperty, objValue);

    /// <summary>Disposes the specified component.</summary>
    /// <param name="blnDisposing"></param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing && this.Owner != null)
        this.Owner.Items.Remove(this);
      base.Dispose(blnDisposing);
    }

    /// <summary>Fires the tool strip item event.</summary>
    /// <param name="objEvent">The obj event.</param>
    internal void FireToolStripItemEvent(IEvent objEvent) => this.FireEvent(objEvent);

    /// <summary>Pres the render tool strip item.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal virtual void PreRenderToolStripItem(IContext objContext, long lngRequestID)
    {
    }

    /// <summary>Posts the render tool strip item.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal virtual void PostRenderToolStripItem(IContext objContext, long lngRequestID) => this.ResetParams();

    /// <summary>Renders a tool strip item.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected internal virtual void RenderToolStripItem(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (this.IsDirty(lngRequestID))
      {
        objWriter.WriteStartElement(WGConst.ControlsPrefix, "TSI", WGConst.ControlsNamespace);
        this.RenderToolStripItemAttributes(objContext, (IAttributeWriter) objWriter);
        this.RenderToolStripItemControls(objContext, objWriter, lngRequestID);
        objWriter.WriteEndElement();
      }
      else if (this.IsDirtyAttributes(lngRequestID))
      {
        objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
        this.RenderToolStripItemUpdatedAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID);
        if (this.Visible)
          this.RenderToolStripItemControls(objContext, objWriter, lngRequestID);
        objWriter.WriteEndElement();
      }
      else
      {
        if (!this.Visible)
          return;
        this.RenderToolStripItemControls(objContext, objWriter, lngRequestID);
      }
    }

    /// <summary>Renders the tool strip item updated attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected virtual void RenderToolStripItemUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter,
      long lngRequestID)
    {
      if (this.IsDirtyAttributes(lngRequestID))
        this.RenderComponentID(objAttributeWriter);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
      {
        this.RenderTextAlignAttribute(objAttributeWriter);
        this.RenderImageAlignAttribute(objAttributeWriter);
        this.RenderImageAttribute(objAttributeWriter, true);
        this.RenderForeColorAttribute(objAttributeWriter, true);
        this.RenderTextImageRelationAttribute(objAttributeWriter, true);
        this.RenderVisibleAttribute(objAttributeWriter, true);
        this.RenderAlignmentAttribute(objAttributeWriter);
      }
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        this.RenderEnabledAttribute(objAttributeWriter, true);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
      {
        this.RenderSizeAttributes(objAttributeWriter, true);
        this.RenderAutoSizeAttributes(objAttributeWriter, true);
        this.RenderImageScalingAttribute(objAttributeWriter, true);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
        return;
      this.RenderToolTipAttribute(objAttributeWriter, false);
    }

    /// <summary>Renders the tool strip item's controls.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected virtual void RenderToolStripItemControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
    }

    /// <summary>Renders the tool strip item's attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    protected virtual void RenderToolStripItemAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter)
    {
      this.RenderComponentAttributes(objContext, objAttributeWriter);
      int toolStripItemType = this.ToolStripItemType;
      if (toolStripItemType >= 0)
        objAttributeWriter.WriteAttributeString("TP", toolStripItemType.ToString());
      if (this.HideOnWrap)
        objAttributeWriter.WriteAttributeString("HOW", "1");
      if (this.CustomStyle != "")
        objAttributeWriter.WriteAttributeString("ES", this.CustomStyle);
      this.RenderSizeAttributes(objAttributeWriter, false);
      this.RenderAutoSizeAttributes(objAttributeWriter, false);
      this.RenderTextAlignAttribute(objAttributeWriter);
      this.RenderImageAlignAttribute(objAttributeWriter);
      this.RenderImageAttribute(objAttributeWriter, false);
      this.RenderEnabledAttribute(objAttributeWriter, false);
      this.RenderVisibleAttribute(objAttributeWriter, false);
      this.RenderAlignmentAttribute(objAttributeWriter);
      this.RenderFontAttribute(objAttributeWriter, false);
      this.RenderForeColorAttribute(objAttributeWriter, false);
      this.RenderBackColorAttribute(objAttributeWriter, false);
      this.RenderTextImageRelationAttribute(objAttributeWriter, false);
      this.RenderImageScalingAttribute(objAttributeWriter, false);
      this.RenderToolTipAttribute(objAttributeWriter, false);
    }

    /// <summary>Renders the tool tip attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderToolTipAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      if (!blnForceRender && string.IsNullOrEmpty(this.ToolTipText))
        return;
      objAttributeWriter.WriteAttributeString("TL", this.ToolTipText);
    }

    /// <summary>Renders the font attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderFontAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      if (!blnForceRender && !this.ShouldRenderFont())
        return;
      objAttributeWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(this.Font));
    }

    /// <summary>Renders the fore color attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderForeColorAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      if (!blnForceRender && !this.ShouldRenderForeColor())
        return;
      objAttributeWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(this.ForeColor));
    }

    /// <summary>Renders the back color attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderBackColorAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      if (!blnForceRender && !this.ShouldSerializeBackColor())
        return;
      objAttributeWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(this.BackColor));
    }

    /// <summary>Renders the size attributes.</summary>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderSizeAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      Size size = Size.Empty;
      if (this.AutoSize)
      {
        size = this.GetPreferredSize(this.Size);
      }
      else
      {
        size.Width = this.Width;
        size.Height = this.Height;
      }
      int num;
      if (size.Width > 0 | blnForceRender)
      {
        IAttributeWriter attributeWriter = objAttributeWriter;
        num = size.Width;
        string strValue = num.ToString();
        attributeWriter.WriteAttributeString("W", strValue);
      }
      if (!(size.Height > 0 | blnForceRender))
        return;
      IAttributeWriter attributeWriter1 = objAttributeWriter;
      num = size.Height;
      string strValue1 = num.ToString();
      attributeWriter1.WriteAttributeString("H", strValue1);
    }

    /// <summary>Renders the auto size attributes.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderAutoSizeAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      bool autoSize = this.AutoSize;
      if (!(!autoSize | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeString("AS", autoSize ? "1" : "0");
    }

    /// <summary>Renders the image attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderImageAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      if (!this.ShouldRenderImage)
        return;
      ResourceHandle image = this.Image;
      if (!(image != null | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeString("IM", image != null ? image.ToString() : string.Empty);
    }

    /// <summary>Renders the enabled attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderEnabledAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      if (!(!this.mblnEnabled | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeString("En", this.mblnEnabled ? "1" : "0");
    }

    /// <summary>Renders the Visible attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderVisibleAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
    {
      bool visible = this.Visible;
      if (!(!visible | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeString("V", visible ? "1" : "0");
    }

    /// <summary>Renders the Item align attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    private void RenderAlignmentAttribute(IAttributeWriter objAttributeWriter)
    {
      if (this.Alignment == ToolStripItemAlignment.Left)
        return;
      objAttributeWriter.WriteAttributeString("HA", this.Alignment == ToolStripItemAlignment.Left ? "0" : "1");
    }

    /// <summary>Renders the text align attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    protected virtual void RenderTextAlignAttribute(IAttributeWriter objAttributeWriter)
    {
      if (!this.ShouldRenderText)
        return;
      objAttributeWriter.WriteAttributeString("TA", this.TextAlign.ToString());
    }

    /// <summary>Renders the image align attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    private void RenderImageAlignAttribute(IAttributeWriter objAttributeWriter)
    {
      if (!this.ShouldRenderImage)
        return;
      objAttributeWriter.WriteAttributeString("IA", this.ImageAlign.ToString());
    }

    /// <summary>Renders the text image relation attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderTextImageRelationAttribute(
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      TextImageRelation textImageRelation = this.TextImageRelation;
      if (!(TextImageRelation.ImageBeforeText != textImageRelation | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeText("TIR", ((int) textImageRelation).ToString());
    }

    /// <summary>Renders the text image relation attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderImageScalingAttribute(
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      ToolStripItemImageScaling imageScaling = this.ImageScaling;
      if (!(ToolStripItemImageScaling.SizeToFit != imageScaling | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeString("IMSC", ((int) imageScaling).ToString());
    }

    /// <summary>Renders the component's ID.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderComponentID(IAttributeWriter objWriter)
    {
      long memberId = this.MemberID;
      if (memberId > 0L)
        objWriter.WriteAttributeString("mId", memberId.ToString());
      long ownerId = this.OwnerID;
      if (ownerId <= 0L)
        return;
      objWriter.WriteAttributeString("oId", ownerId.ToString());
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      bool flag = false;
      ToolStrip owner = this.Owner;
      if (owner != null)
        flag = owner.IsCriticalEvent(ToolStrip.ItemClickedEvent);
      if (flag || this.ClickHandler != null || this.MouseDownHandler != null || this.MouseUpHandler != null)
        criticalEventsData.Set("CL");
      if (this.DoubleClickHandler != null)
        criticalEventsData.Set("DCL");
      return criticalEventsData;
    }

    /// <summary>Gets the mouse event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    protected internal MouseEventArgs GetMouseEventArgs(IEvent objEvent) => new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0);

    /// <summary>Does the on click from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected internal void DoOnClickFromEvent(IEvent objEvent) => this.OnClick((EventArgs) this.GetMouseEventArgs(objEvent));

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "Click":
          this.DoOnClickFromEvent(objEvent);
          break;
        case "DoubleClick":
          this.OnClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          this.OnDoubleClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 2, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          break;
      }
    }

    /// <summary>Indicates if to render font.</summary>
    /// <returns></returns>
    private bool ShouldRenderFont() => this.Font != null && !this.Font.Equals((object) this.SkinFont);

    /// <summary>Checks whether item should render the forecolor.</summary>
    /// <returns></returns>
    private bool ShouldRenderForeColor() => !this.ForeColor.Equals((object) this.SkinForeColor);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeBackColor() => this.ContainsValue<Color>(ToolStripItem.mobjBackColorProperty);

    private bool ShouldSerializeDisplayStyle() => this.DisplayStyle != this.DefaultDisplayStyle;

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeFont() => this.ContainsValue<Font>(ToolStripItem.mobjFontProperty);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeForeColor() => this.ContainsValue<Color>(ToolStripItem.mobjForeColorProperty);

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeImage() => this.ContainsValue<ResourceHandle>(ToolStripItem.mobjImageProperty);

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeImageIndex() => this.ContainsValue<int>(ToolStripItem.mintImageIndexProperty);

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeImageKey() => this.ContainsValue<string>(ToolStripItem.mstrImageKeyProperty);

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeImageTransparentColor() => false;

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeMargin() => this.Margin != this.DefaultMargin;

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializePadding() => this.Padding != this.DefaultPadding;

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeRightToLeft() => this.ContainsValue<RightToLeft>(ToolStripItem.menmRightToLeftProperty);

    private bool ShouldSerializeTextDirection() => this.ContainsValue<ToolStripTextDirection>(ToolStripItem.menmTextDirectionProperty);

    private bool ShouldSerializeToolTipText() => this.ContainsValue<string>(ToolStripItem.mstrToolTipTextProperty);

    [EditorBrowsable(EditorBrowsableState.Never)]
    private bool ShouldSerializeVisible() => !this.GetState(Component.ComponentState.Visible);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Available"></see> property changes.</summary>
    public event EventHandler AvailableChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.AvailableChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.AvailableChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the available changed handler.</summary>
    /// <value>The available changed handler.</value>
    private EventHandler AvailableChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.AvailableChangedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.BackColor"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler BackColorChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.BackColorChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.BackColorChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the back color changed handler.</summary>
    /// <value>The back color changed handler.</value>
    private EventHandler BackColorChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.BackColorChangedEvent);

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.</summary>
    /// <filterpriority>1</filterpriority>
    public virtual event EventHandler Click
    {
      add => this.AddCriticalHandler(ToolStripItem.ClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.ClickEvent, (Delegate) value);
    }

    /// <summary>Gets the click handler.</summary>
    /// <value>The click handler.</value>
    private EventHandler ClickHandler => (EventHandler) this.GetHandler(ToolStripItem.ClickEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.DisplayStyle"></see> has changed.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler DisplayStyleChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.DisplayStyleChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.DisplayStyleChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the DisplayStyleChanged handler.</summary>
    /// <value>The DisplayStyleChanged handler.</value>
    private EventHandler DisplayStyleChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.DisplayStyleChangedEvent);

    /// <summary>Occurs when the item is double-clicked with the mouse.</summary>
    /// <filterpriority>1</filterpriority>
    public virtual event EventHandler DoubleClick
    {
      add => this.AddCriticalHandler(ToolStripItem.DoubleClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.DoubleClickEvent, (Delegate) value);
    }

    /// <summary>Gets the DoubleClick handler.</summary>
    /// <value>The DoubleClick handler.</value>
    private EventHandler DoubleClickHandler => (EventHandler) this.GetHandler(ToolStripItem.DoubleClickEvent);

    /// <summary>Occurs when the user drags an item into the client area of this item.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event DragEventHandler DragEnter
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the user drags an item and the mouse pointer is no longer over the client area of this item.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler DragLeave
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the user drags an item over the client area of this item.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event DragEventHandler DragOver
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Enabled"></see> property value has changed.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler EnabledChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.EnabledChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.EnabledChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the EnabledChanged handler.</summary>
    /// <value>The EnabledChanged handler.</value>
    private EventHandler EnabledChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.EnabledChangedEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ForeColor"></see> property value changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler ForeColorChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.ForeColorChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.ForeColorChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the ForeColorChanged handler.</summary>
    /// <value>The ForeColorChanged handler.</value>
    private EventHandler ForeColorChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.ForeColorChangedEvent);

    /// <summary>Occurs during a drag operation.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event GiveFeedbackEventHandler GiveFeedback
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the location of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is updated.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler LocationChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.LocationChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.LocationChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the LocationChanged handler.</summary>
    /// <value>The LocationChanged handler.</value>
    private EventHandler LocationChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.LocationChangedEvent);

    /// <summary>Occurs when the mouse pointer is over the item and a mouse button is pressed.</summary>
    /// <filterpriority>1</filterpriority>
    public virtual event MouseEventHandler MouseDown
    {
      add => this.AddCriticalHandler(ToolStripItem.MouseDownEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.MouseDownEvent, (Delegate) value);
    }

    /// <summary>Gets the MouseDown handler.</summary>
    /// <value>The MouseDown handler.</value>
    private MouseEventHandler MouseDownHandler => (MouseEventHandler) this.GetHandler(ToolStripItem.MouseDownEvent);

    /// <summary>Occurs when the mouse pointer enters the item.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler MouseEnter
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the mouse pointer hovers over the item.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler MouseHover
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the mouse pointer leaves the item.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler MouseLeave
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the mouse pointer is moved over the item.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event MouseEventHandler MouseMove
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the mouse pointer is over the item and a mouse button is released.</summary>
    /// <filterpriority>1</filterpriority>
    public virtual event MouseEventHandler MouseUp
    {
      add => this.AddCriticalHandler(ToolStripItem.MouseUpEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.MouseUpEvent, (Delegate) value);
    }

    /// <summary>Gets the MouseUp handler.</summary>
    /// <value>The MouseUp handler.</value>
    private MouseEventHandler MouseUpHandler => (MouseEventHandler) this.GetHandler(ToolStripItem.MouseUpEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Owner"></see> property changes. </summary>
    public event EventHandler OwnerChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.OwnerChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.OwnerChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the OwnerChanged handler.</summary>
    /// <value>The OwnerChanged handler.</value>
    private EventHandler OwnerChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.OwnerChangedEvent);

    /// <summary>Occurs when the item is redrawn.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event PaintEventHandler Paint
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs during a drag-and-drop operation and allows the drag source to determine whether the drag-and-drop operation should be canceled.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event QueryContinueDragEventHandler QueryContinueDrag
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeft"></see> property value changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler RightToLeftChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.RightToLeftChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.RightToLeftChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the RightToLeftChanged handler.</summary>
    /// <value>The RightToLeftChanged handler.</value>
    private EventHandler RightToLeftChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.RightToLeftChangedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    public virtual event EventHandler TextChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.TextChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.TextChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the TextChanged handler.</summary>
    /// <value>The TextChanged handler.</value>
    private EventHandler TextChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.TextChangedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Visible"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler VisibleChanged
    {
      add => this.AddCriticalHandler(ToolStripItem.VisibleChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripItem.VisibleChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the VisibleChanged handler.</summary>
    /// <value>The VisibleChanged handler.</value>
    private EventHandler VisibleChangedHandler => (EventHandler) this.GetHandler(ToolStripItem.VisibleChangedEvent);

    private ToolStrip mobjParent
    {
      get => this.GetValue<ToolStrip>(ToolStripItem.mobjParentProperty, (ToolStrip) null);
      set => this.SetValue<ToolStrip>(ToolStripItem.mobjParentProperty, value);
    }

    private ToolStrip mobjOwner
    {
      get => this.GetValue<ToolStrip>(ToolStripItem.mobjOwnerProperty, (ToolStrip) null);
      set => this.SetValue<ToolStrip>(ToolStripItem.mobjOwnerProperty, value);
    }

    private Font mobjFont
    {
      get => this.GetValue<Font>(ToolStripItem.mobjFontProperty);
      set => this.SetValue<Font>(ToolStripItem.mobjFontProperty, value);
    }

    private ToolStripItemDisplayStyle menmDisplayStyle
    {
      get => this.GetValue<ToolStripItemDisplayStyle>(ToolStripItem.menmDisplayStyleProperty);
      set => this.SetValue<ToolStripItemDisplayStyle>(ToolStripItem.menmDisplayStyleProperty, value);
    }

    private Rectangle mobjBounds
    {
      get => this.GetValue<Rectangle>(ToolStripItem.mobjBoundsProperty);
      set => this.SetValue<Rectangle>(ToolStripItem.mobjBoundsProperty, value);
    }

    private object mobjTag
    {
      get => this.GetValue<object>(ToolStripItem.mobjTagProperty, (object) null);
      set => this.SetValue<object>(ToolStripItem.mobjTagProperty, value);
    }

    private string mstrText
    {
      get => this.GetValue<string>(ToolStripItem.mstrTextProperty, string.Empty);
      set => this.SetValue<string>(ToolStripItem.mstrTextProperty, value);
    }

    private RightToLeft menmRightToLeft
    {
      get => this.GetValue<RightToLeft>(ToolStripItem.menmRightToLeftProperty);
      set => this.SetValue<RightToLeft>(ToolStripItem.menmRightToLeftProperty, value);
    }

    internal bool mblnEnabled
    {
      get => this.GetValue<bool>(ToolStripItem.mblnEnabledProperty);
      set => this.SetValue<bool>(ToolStripItem.mblnEnabledProperty, value);
    }

    private bool mblnDoubleClickEnabled
    {
      get => this.GetValue<bool>(ToolStripItem.mblnDoubleClickEnabledProperty);
      set => this.SetValue<bool>(ToolStripItem.mblnDoubleClickEnabledProperty, value);
    }

    private DockStyle menmDock
    {
      get => this.GetValue<DockStyle>(ToolStripItem.menmDockProperty);
      set => this.SetValue<DockStyle>(ToolStripItem.menmDockProperty, value);
    }

    private ImageLayout menmBackgroundImageLayout
    {
      get => this.GetValue<ImageLayout>(ToolStripItem.menmBackgroundImageLayoutProperty, ImageLayout.Tile);
      set => this.SetValue<ImageLayout>(ToolStripItem.menmBackgroundImageLayoutProperty, value);
    }

    private ResourceHandle mobjBackgroundImage
    {
      get => this.GetValue<ResourceHandle>(ToolStripItem.mobjBackgroundImageProperty, (ResourceHandle) null);
      set => this.SetValue<ResourceHandle>(ToolStripItem.mobjBackgroundImageProperty, value);
    }

    private Color mobjBackColor
    {
      get => this.GetValue<Color>(ToolStripItem.mobjBackColorProperty, Color.Empty);
      set => this.SetValue<Color>(ToolStripItem.mobjBackColorProperty, value);
    }

    private ToolStripItemAlignment menmAlignment
    {
      get => this.GetValue<ToolStripItemAlignment>(ToolStripItem.menmAlignmentProperty);
      set => this.SetValue<ToolStripItemAlignment>(ToolStripItem.menmAlignmentProperty, value);
    }

    private AnchorStyles menmAnchor
    {
      get => this.GetValue<AnchorStyles>(ToolStripItem.menmAnchorProperty, AnchorStyles.Left | AnchorStyles.Top);
      set => this.SetValue<AnchorStyles>(ToolStripItem.menmAnchorProperty, value, AnchorStyles.Left | AnchorStyles.Top);
    }

    private bool mblnAutoSize
    {
      get => this.GetValue<bool>(ToolStripItem.mblnAutoSizeProperty);
      set => this.SetValue<bool>(ToolStripItem.mblnAutoSizeProperty, value);
    }

    private bool mblnAutoToolTip
    {
      get => this.GetValue<bool>(ToolStripItem.mblnAutoToolTipProperty);
      set => this.SetValue<bool>(ToolStripItem.mblnAutoToolTipProperty, value);
    }

    private Color mobjForeColor
    {
      get => this.GetValue<Color>(ToolStripItem.mobjForeColorProperty);
      set => this.SetValue<Color>(ToolStripItem.mobjForeColorProperty, value);
    }

    private ResourceHandle mobjImage
    {
      get => this.GetValue<ResourceHandle>(ToolStripItem.mobjImageProperty, (ResourceHandle) null);
      set => this.SetValue<ResourceHandle>(ToolStripItem.mobjImageProperty, value);
    }

    private ContentAlignment menmImageAlign
    {
      get => this.GetValue<ContentAlignment>(ToolStripItem.menmImageAlignProperty);
      set => this.SetValue<ContentAlignment>(ToolStripItem.menmImageAlignProperty, value);
    }

    private int mintImageIndex
    {
      get => this.GetValue<int>(ToolStripItem.mintImageIndexProperty, -1);
      set => this.SetValue<int>(ToolStripItem.mintImageIndexProperty, value);
    }

    private string mstrImageKey
    {
      get => this.GetValue<string>(ToolStripItem.mstrImageKeyProperty, string.Empty);
      set => this.SetValue<string>(ToolStripItem.mstrImageKeyProperty, value);
    }

    private Padding mobjMargin
    {
      get => this.GetValue<Padding>(ToolStripItem.mobjMarginProperty);
      set => this.SetValue<Padding>(ToolStripItem.mobjMarginProperty, value);
    }

    private MergeAction menmMergeAction
    {
      get => this.GetValue<MergeAction>(ToolStripItem.menmMergeActionProperty, MergeAction.Append);
      set => this.SetValue<MergeAction>(ToolStripItem.menmMergeActionProperty, value);
    }

    private int mintMergeIndex
    {
      get => this.GetValue<int>(ToolStripItem.mintMergeIndexProperty);
      set => this.SetValue<int>(ToolStripItem.mintMergeIndexProperty, value);
    }

    private string mstrName
    {
      get => this.GetValue<string>(ToolStripItem.mstrNameProperty, string.Empty);
      set => this.SetValue<string>(ToolStripItem.mstrNameProperty, value);
    }

    private Padding mobjPadding
    {
      get => this.GetValue<Padding>(ToolStripItem.mobjPaddingProperty);
      set => this.SetValue<Padding>(ToolStripItem.mobjPaddingProperty, value);
    }

    private ToolStripItemPlacement menmPlacement
    {
      get => this.GetValue<ToolStripItemPlacement>(ToolStripItem.menmPlacementProperty);
      set => this.SetValue<ToolStripItemPlacement>(ToolStripItem.menmPlacementProperty, value);
    }

    private bool mblnRightToLeftAutoMirrorImage
    {
      get => this.GetValue<bool>(ToolStripItem.mblnRightToLeftAutoMirrorImageProperty);
      set => this.SetValue<bool>(ToolStripItem.mblnRightToLeftAutoMirrorImageProperty, value);
    }

    private ContentAlignment menmTextAlign
    {
      get => this.GetValue<ContentAlignment>(ToolStripItem.menmTextAlignProperty);
      set => this.SetValue<ContentAlignment>(ToolStripItem.menmTextAlignProperty, value);
    }

    private ToolStripTextDirection menmTextDirection
    {
      get => this.GetValue<ToolStripTextDirection>(ToolStripItem.menmTextDirectionProperty, ToolStripTextDirection.Inherit);
      set => this.SetValue<ToolStripTextDirection>(ToolStripItem.menmTextDirectionProperty, value);
    }

    private TextImageRelation menmTextImageRelation
    {
      get => this.GetValue<TextImageRelation>(ToolStripItem.menmTextImageRelationProperty);
      set => this.SetValue<TextImageRelation>(ToolStripItem.menmTextImageRelationProperty, value);
    }

    private string mstrToolTipText
    {
      get => this.GetValue<string>(ToolStripItem.mstrToolTipTextProperty);
      set => this.SetValue<string>(ToolStripItem.mstrToolTipTextProperty, value);
    }

    private ToolStripItemImageScaling menmImageScaling
    {
      get => this.GetValue<ToolStripItemImageScaling>(ToolStripItem.memnImageScalingProperty);
      set => this.SetValue<ToolStripItemImageScaling>(ToolStripItem.memnImageScalingProperty, value);
    }

    /// <summary>Gets the font from skin.</summary>
    /// <value>The color of the skin fore.</value>
    protected virtual Font SkinFont
    {
      get
      {
        Font skinFont = (Font) null;
        if (SkinFactory.GetSkin((ISkinable) this) is CommonSkin skin)
          skinFont = skin.Font;
        return skinFont;
      }
    }

    /// <summary>Gets the forecolor from skin.</summary>
    /// <value>The color of the skin fore.</value>
    protected virtual Color SkinForeColor
    {
      get
      {
        Color skinForeColor = Color.Empty;
        if (SkinFactory.GetSkin((ISkinable) this) is CommonSkin skin)
          skinForeColor = skin.ForeColor;
        return skinForeColor;
      }
    }

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected virtual int ToolStripItemType => -1;

    /// <summary>Gets or sets a value indicating whether the item aligns towards the beginning or end of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Left"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ToolStripItemAlignmentDescr")]
    [DefaultValue(ToolStripItemAlignment.Left)]
    [SRCategory("CatLayout")]
    public ToolStripItemAlignment Alignment
    {
      get => this.menmAlignment;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 1))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ToolStripItemAlignment));
        if (this.menmAlignment == value)
          return;
        this.menmAlignment = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether drag-and-drop and item reordering are handled through events that you implement.</summary>
    /// <returns>true if drag-and-drop operations are allowed in the control; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.ArgumentException">
    /// <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new virtual bool AllowDrop
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the edges of the container to which a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is bound and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>  is resized with its parent.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.AnchorStyles"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value is not one of the <see cref="T:Gizmox.WebGUI.Forms.AnchorStyles"></see> values.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(AnchorStyles.Left | AnchorStyles.Top)]
    public AnchorStyles Anchor
    {
      get => this.menmAnchor;
      set
      {
        if (value == this.Anchor)
          return;
        this.menmAnchor = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the item is automatically sized.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically sized; otherwise, false. The default value is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ToolStripItemAutoSizeDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    [Localizable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [RefreshProperties(RefreshProperties.All)]
    public bool AutoSize
    {
      get => this.mblnAutoSize;
      set
      {
        if (this.mblnAutoSize == value)
          return;
        this.mblnAutoSize = value;
        if (this.DesignMode)
          return;
        this.InvalidateParentLayout();
      }
    }

    /// <summary>Gets or sets a value indicating whether to use the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ToolTipText"></see> property for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> ToolTip. </summary>
    /// <returns>true to use the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property for the ToolTip; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    [SRDescription("ToolStripItemAutoToolTipDescr")]
    [SRCategory("CatBehavior")]
    public bool AutoToolTip
    {
      get => this.mblnAutoToolTip;
      set
      {
        if (this.mblnAutoToolTip == value)
          return;
        this.mblnAutoToolTip = value;
        this.UpdateParams(AttributeType.ToolTip);
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> should be placed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is placed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>; otherwise, false.</returns>
    [SRDescription("ToolStripItemAvailableDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool Available
    {
      get => this.GetState(Component.ComponentState.Visible);
      set
      {
        if (this.Available == value)
          return;
        this.SetVisibleCore(value);
      }
    }

    /// <summary>Gets or sets the background color for the item.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the item. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultBackColor"></see> property.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripItemBackColorDescr")]
    public virtual Color BackColor
    {
      get
      {
        if (!this.mobjBackColor.IsEmpty)
          return this.mobjBackColor;
        Control parentInternal = (Control) this.ParentInternal;
        return parentInternal != null ? parentInternal.BackColor : Color.FromKnownColor(KnownColor.Control);
      }
      set
      {
        Color backColor = this.BackColor;
        if (!value.IsEmpty)
          this.mobjBackColor = value;
        if (backColor.Equals((object) this.BackColor))
          return;
        this.OnBackColorChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets the background image.</summary>
    /// <value>The background image.</value>
    [DefaultValue(null)]
    [SRDescription("ToolStripItemImageDescr")]
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    public virtual ResourceHandle BackgroundImage
    {
      get => this.mobjBackgroundImage;
      set
      {
        if (this.BackgroundImage == value)
          return;
        this.mobjBackgroundImage = value;
        this.Invalidate();
      }
    }

    /// <summary>Gets or sets the background image layout used for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlBackgroundImageLayoutDescr")]
    [DefaultValue(ImageLayout.Tile)]
    [Localizable(true)]
    public virtual ImageLayout BackgroundImageLayout
    {
      get => this.menmBackgroundImageLayout;
      set
      {
        if (this.BackgroundImageLayout == value)
          return;
        this.menmBackgroundImageLayout = ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 4) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ImageLayout));
        this.Invalidate();
      }
    }

    /// <summary>Gets the size and location of the item.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual Rectangle Bounds => this.mobjBounds;

    /// <summary>Gets a value indicating whether the item can be selected.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be selected; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual bool CanSelect => true;

    /// <summary>Gets the area where content, such as text and icons, can be placed within a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> without overwriting background borders.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> containing four integers that represent the location and size of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> contents, excluding its border.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ContentRectangle => Rectangle.Empty;

    /// <summary>Gets or sets the control custom style.</summary>
    /// <value></value>
    [DefaultValue("")]
    [SRDescription("ControlCustomStyleDescr")]
    [SRCategory("CatAppearance")]
    public virtual string CustomStyle
    {
      get => this.GetValue<string>(ToolStripItem.mstrCustomStyleProperty);
      set
      {
        if (!this.SetValue<string>(ToolStripItem.mstrCustomStyleProperty, value))
          return;
        this.Invalidate();
      }
    }

    /// <summary>Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default.</summary>
    /// <returns>false in all cases.</returns>
    protected virtual bool DefaultAutoToolTip => false;

    /// <summary>Gets the default margin of an item.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> representing the margin.</returns>
    protected internal virtual Padding DefaultMargin => this.Owner != null && this.Owner is StatusStrip ? new Padding(0, 2, 0, 0) : new Padding(0, 1, 0, 2);

    /// <summary>Gets the internal spacing characteristics of the item.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.Padding"></see> values.</returns>
    protected virtual Padding DefaultPadding => Padding.Empty;

    /// <summary>Gets a value indicating what is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.ImageAndText"></see>.</returns>
    protected virtual ToolStripItemDisplayStyle DefaultDisplayStyle => ToolStripItemDisplayStyle.ImageAndText;

    /// <summary>Gets the internal spacing characteristics of the item.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.</returns>
    protected virtual Size DefaultSize => new Size(23, 23);

    /// <summary>Gets or sets whether text and images are displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.ImageAndText"></see> .</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripItemDisplayStyleDescr")]
    [SRCategory("CatAppearance")]
    public virtual ToolStripItemDisplayStyle DisplayStyle
    {
      get => this.menmDisplayStyle;
      set
      {
        if (this.menmDisplayStyle == value)
          return;
        this.menmDisplayStyle = ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 3) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ToolStripItemDisplayStyle));
        this.OnDisplayStyleChanged(new EventArgs());
        this.Owner?.Update();
      }
    }

    /// <summary>Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is resized with its parent.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.None"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DockStyle.None)]
    [Browsable(false)]
    public DockStyle Dock
    {
      get => this.menmDock;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 5))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DockStyle));
        if (value == this.Dock)
          return;
        this.menmDock = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be activated by double-clicking the mouse. </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be activated by double-clicking the mouse; otherwise, false. The default is false.</returns>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("ToolStripItemDoubleClickedEnabledDescr")]
    public bool DoubleClickEnabled
    {
      get => this.mblnDoubleClickEnabled;
      set
      {
        if (this.mblnDoubleClickEnabled == value)
          return;
        this.mblnDoubleClickEnabled = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the parent control of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is enabled. </summary>
    /// <returns>true if the parent control of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is enabled; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripItemEnabledDescr")]
    [Localizable(true)]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public virtual bool Enabled
    {
      get
      {
        bool flag = true;
        if (this.Owner != null)
          flag = this.Owner.Enabled;
        return this.mblnEnabled & flag;
      }
      set
      {
        if (this.mblnEnabled == value)
          return;
        this.mblnEnabled = value;
        this.OnEnabledChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the font of the text displayed by the item.</summary>
    /// <returns>The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultFont"></see> property.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripItemFontDescr")]
    [Localizable(true)]
    public virtual Font Font
    {
      get
      {
        if (this.mobjFont == null)
        {
          Font ownerFont = this.GetOwnerFont();
          if (ownerFont != null)
            return ownerFont;
        }
        return this.mobjFont;
      }
      set
      {
        if (this.mobjFont == value)
          return;
        this.mobjFont = value;
        this.OnFontChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets the foreground color of the item.</summary>
    /// <returns>The foreground <see cref="T:System.Drawing.Color"></see> of the item. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultForeColor"></see> property.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripItemForeColorDescr")]
    [SRCategory("CatAppearance")]
    public virtual Color ForeColor
    {
      get
      {
        Color mobjForeColor = this.mobjForeColor;
        if (!mobjForeColor.IsEmpty)
          return mobjForeColor;
        ToolStrip owner = this.Owner;
        if (owner != null && owner.HasForeColor)
        {
          Color foreColor = owner.ForeColor;
          if (!foreColor.IsEmpty)
            return foreColor;
        }
        return this.SkinForeColor;
      }
      set
      {
        Color foreColor = this.ForeColor;
        if (!value.IsEmpty)
          this.mobjForeColor = value;
        if (foreColor.Equals((object) this.ForeColor))
          return;
        this.OnForeColorChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the height, in pixels, of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the height, in pixels.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Browsable(false)]
    [SRCategory("CatLayout")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Height
    {
      get => this.Bounds.Height;
      set
      {
        Rectangle bounds = this.Bounds;
        if (bounds.Height == value)
          return;
        this.SetBounds(bounds.X, bounds.Y, bounds.Width, value);
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets or sets the parent container of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStrip"></see> that is the parent container of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    protected internal ToolStrip Parent
    {
      get => this.ParentInternal;
      set => this.ParentInternal = value;
    }

    /// <summary>Gets or sets the context menu code.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ContextMenu ContextMenu
    {
      get => base.ContextMenu;
      set => base.ContextMenu = value;
    }

    /// <summary>
    /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
    /// </summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ContextMenuStrip ContextMenuStrip
    {
      get => base.ContextMenuStrip;
      set => base.ContextMenuStrip = value;
    }

    /// <summary>Gets or sets the image that is displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripItemImageDescr")]
    [Localizable(true)]
    public virtual ResourceHandle Image
    {
      get
      {
        ResourceHandle mobjImage = this.mobjImage;
        if (mobjImage != null || this.Owner == null || this.Owner.ImageList == null)
          return mobjImage;
        int imageIndex = this.ImageIndex;
        ResourceHandle resourceHandle;
        if (imageIndex >= 0)
        {
          if (imageIndex < this.Owner.ImageList.Images.Count)
          {
            ResourceHandle image1;
            resourceHandle = image1 = this.Owner.ImageList.Images[imageIndex];
            ResourceHandle image2 = image1;
            this.mobjImage = image1;
            return image2;
          }
        }
        else
        {
          string imageKey = this.ImageKey;
          if (!string.IsNullOrEmpty(imageKey))
          {
            ResourceHandle image3;
            resourceHandle = image3 = this.Owner.ImageList.Images[imageKey];
            ResourceHandle image4 = image3;
            this.mobjImage = image3;
            return image4;
          }
        }
        return (ResourceHandle) null;
      }
      set
      {
        if (this.Image == value)
          return;
        if (value != null)
          this.ImageIndex = -1;
        this.mobjImage = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the alignment of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleLeft"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [DefaultValue(ContentAlignment.MiddleCenter)]
    [SRDescription("ToolStripItemImageAlignDescr")]
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    public ContentAlignment ImageAlign
    {
      get => this.menmImageAlign;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 1, 1024))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ContentAlignment));
        if (this.menmImageAlign == value)
          return;
        this.menmImageAlign = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the index value of the image that is displayed on the item.</summary>
    /// <returns>The zero-based index of the image in the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ImageList"></see> that is displayed for the item. The default is -1, signifying that the image list is empty.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripItemImageIndexDescr")]
    [RelatedImageList("Owner.ImageList")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Browsable(false)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    public int ImageIndex
    {
      get => this.Owner != null && this.mintImageIndex != -1 && this.Owner.ImageList != null && this.mintImageIndex >= this.Owner.ImageList.Images.Count ? this.Owner.ImageList.Images.Count - 1 : this.mintImageIndex;
      set
      {
        if (value < -1)
          throw new ArgumentOutOfRangeException(nameof (ImageIndex), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (ImageIndex), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) -1.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (this.mintImageIndex == value)
          return;
        this.mintImageIndex = value;
        this.mobjImage = (ResourceHandle) null;
        this.mstrImageKey = string.Empty;
      }
    }

    /// <summary>Gets or sets the key accessor for the image in the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ImageList"></see> that is displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>A string representing the key of the image.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRCategory("CatBehavior")]
    [Browsable(false)]
    [SRDescription("ToolStripItemImageKeyDescr")]
    [Localizable(true)]
    [RelatedImageList("Owner.ImageList")]
    public string ImageKey
    {
      get => this.mstrImageKey;
      set
      {
        if (!(this.mstrImageKey != value))
          return;
        this.mstrImageKey = value;
        this.mobjImage = (ResourceHandle) null;
        this.mintImageIndex = -1;
      }
    }

    /// <summary>Gets or sets a value indicating whether an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically resized to fit in a container.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageScaling"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemImageScaling.SizeToFit"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    [SRDescription("ToolStripItemImageScalingDescr")]
    [DefaultValue(ToolStripItemImageScaling.SizeToFit)]
    public ToolStripItemImageScaling ImageScaling
    {
      get => this.menmImageScaling;
      set
      {
        if (value == this.ImageScaling)
          return;
        this.menmImageScaling = value;
        if (this.DesignMode)
          return;
        this.InvalidateParentLayout();
      }
    }

    /// <summary>Invalidates the parent layout.</summary>
    private void InvalidateParentLayout()
    {
      if (this.ParentInternal == null)
        return;
      this.ParentInternal.InvalidateLayout(new LayoutEventArgs(true, false, false));
      this.ParentInternal.UpdateStripAttributes(AttributeType.Layout);
      this.UpdateParams(AttributeType.Layout);
    }

    /// <summary>Gets or sets the color to treat as transparent in a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> image.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.Color"></see> values.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color ImageTransparentColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <returns>true if the control has been disposed of; otherwise, false.</returns>
    /// <filterpriority>2</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsDisposed => false;

    /// <summary>Gets a value indicating whether the container of the current <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>. </summary>
    /// <returns>true if the container of the current <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public bool IsOnDropDown
    {
      get
      {
        if (this.ParentInternal != null)
          return this.ParentInternal.IsDropDown;
        return this.Owner != null && this.Owner.IsDropDown;
      }
    }

    /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Placement"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemPlacement.Overflow"></see>.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Placement"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemPlacement.Overflow"></see>; otherwise, false.</returns>
    [Browsable(false)]
    public bool IsOnOverflow => this.Placement == ToolStripItemPlacement.Overflow;

    /// <summary>Gets or sets the space between the item and adjacent items.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between the item and adjacent items.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ToolStripItemMarginDescr")]
    [SRCategory("CatLayout")]
    public Padding Margin
    {
      get => this.mobjMargin;
      set
      {
        if (!(this.Margin != value))
          return;
        this.mobjMargin = value;
      }
    }

    /// <summary>Gets or sets how child menus are merged with parent menus. </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.MergeAction"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.MergeAction.MatchOnly"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.MergeAction"></see> values.</exception>
    /// <filterpriority>2</filterpriority>
    [SRCategory("CatLayout")]
    [SRDescription("ToolStripMergeActionDescr")]
    [DefaultValue(MergeAction.Append)]
    public MergeAction MergeAction
    {
      get => this.menmMergeAction;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 4))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (MergeAction));
        if (this.menmMergeAction == value)
          return;
        this.menmMergeAction = value;
      }
    }

    /// <summary>Gets or sets the position of a merged item within the current <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>An integer representing the index of the merged item, if a match is found, or -1 if a match is not found.</returns>
    /// <filterpriority>2</filterpriority>
    [SRDescription("ToolStripMergeIndexDescr")]
    [SRCategory("CatLayout")]
    [DefaultValue(-1)]
    public int MergeIndex
    {
      get => this.mintMergeIndex;
      set
      {
        if (this.mintMergeIndex == value)
          return;
        this.mintMergeIndex = value;
      }
    }

    /// <summary>Gets or sets the name of the item.</summary>
    /// <returns>A string representing the name. The default value is null.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    [Browsable(false)]
    public string Name
    {
      get
      {
        if (!string.IsNullOrEmpty(this.mstrName))
          return this.mstrName;
        string name = string.Empty;
        if (this.Site != null && this.Site.DesignMode)
          name = this.Site.Name;
        if (name == null)
          name = string.Empty;
        return name;
      }
      set
      {
        if (!(this.mstrName != value))
          return;
        this.mstrName = value;
      }
    }

    /// <summary>Gets or sets whether the item is attached to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> or <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> or can float between the two.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.AsNeeded"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(ToolStripItemOverflow.AsNeeded)]
    [SRDescription("ToolStripItemOverflowDescr")]
    [SRCategory("CatLayout")]
    public ToolStripItemOverflow Overflow
    {
      get => ToolStripItemOverflow.AsNeeded;
      set
      {
      }
    }

    /// <summary>Gets or sets the owner of this item.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that owns or is to own the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStrip Owner
    {
      get => this.OwnerInternal;
      set
      {
        ToolStrip ownerInternal = this.OwnerInternal;
        if (ownerInternal == value)
          return;
        this.OwnerInternal = value;
        if (ownerInternal != null)
        {
          ownerInternal.Items.Remove(this);
          ownerInternal.Update();
        }
        if (value == null)
          return;
        value.Items.Add(this);
        value.Update();
      }
    }

    /// <summary>Gets or sets the owner internal.</summary>
    /// <value>The owner internal.</value>
    private ToolStrip OwnerInternal
    {
      get => this.mobjOwner;
      set => this.mobjOwner = value;
    }

    /// <summary>Gets the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>The parent <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripItem OwnerItem
    {
      get
      {
        ToolStripDropDown toolStripDropDown = (ToolStripDropDown) null;
        if (this.ParentInternal != null)
          toolStripDropDown = this.ParentInternal as ToolStripDropDown;
        else if (this.Owner != null)
          toolStripDropDown = this.Owner as ToolStripDropDown;
        return toolStripDropDown?.OwnerItem;
      }
    }

    /// <summary>Gets or sets the internal spacing, in pixels, between the item's contents and its edges.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the item's internal spacing, in pixels.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatLayout")]
    [SRDescription("ToolStripItemPaddingDescr")]
    public virtual Padding Padding
    {
      get => this.mobjPadding;
      set
      {
        if (!(this.Padding != value))
          return;
        this.mobjPadding = value;
      }
    }

    /// <summary>Gets the current layout of the item.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemPlacement"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public ToolStripItemPlacement Placement => this.menmPlacement;

    /// <summary>Gets a value indicating whether the state of the item is pressed. </summary>
    /// <returns>true if the state of the item is pressed; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Pressed => false;

    /// <summary>Gets the default right to left.</summary>
    /// <value>The default right to left.</value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private RightToLeft DefaultRightToLeft => RightToLeft.Inherit;

    /// <summary>Gets or sets a value indicating whether items are to be placed from right to left and text is to be written from right to left.</summary>
    /// <returns>true if items are to be placed from right to left and text is to be written from right to left; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripItemRightToLeftDescr")]
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    public virtual RightToLeft RightToLeft
    {
      get
      {
        RightToLeft rightToLeft = this.menmRightToLeft;
        if (rightToLeft == RightToLeft.Inherit)
          rightToLeft = this.Owner == null ? (this.ParentInternal == null ? this.DefaultRightToLeft : this.ParentInternal.RightToLeft) : this.Owner.RightToLeft;
        return rightToLeft;
      }
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (RightToLeft), (int) value, typeof (RightToLeft));
        int rightToLeft1 = (int) this.RightToLeft;
        if (value != RightToLeft.Inherit)
          this.menmRightToLeft = value;
        int rightToLeft2 = (int) this.RightToLeft;
        if (rightToLeft1 == rightToLeft2)
          return;
        this.OnRightToLeftChanged(EventArgs.Empty);
      }
    }

    /// <summary>Mirrors automatically the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> image when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeft"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Yes"></see>.</summary>
    /// <returns>true to automatically mirror the image; otherwise, false. The default is false.</returns>
    [DefaultValue(false)]
    [Localizable(true)]
    [SRDescription("ToolStripItemRightToLeftAutoMirrorImageDescr")]
    [SRCategory("CatAppearance")]
    public bool RightToLeftAutoMirrorImage
    {
      get => this.mblnRightToLeftAutoMirrorImage;
      set
      {
        if (this.mblnRightToLeftAutoMirrorImage == value)
          return;
        this.mblnRightToLeftAutoMirrorImage = value;
        this.Invalidate();
      }
    }

    /// <summary>Gets a value indicating whether the item is selected.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is selected; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Selected => false;

    /// <summary>Gets or sets the size of the item.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see>, representing the width and height of a rectangle.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripItemSizeDescr")]
    [Localizable(true)]
    [SRCategory("CatLayout")]
    public virtual Size Size
    {
      get => this.Bounds.Size;
      set
      {
        Rectangle bounds = this.Bounds;
        if (!(bounds.Size != value))
          return;
        bounds.Size = value;
        this.SetBounds(bounds);
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets a value indicating whether [should render text].</summary>
    /// <value><c>true</c> if [should render text]; otherwise, <c>false</c>.</value>
    protected bool ShouldRenderText
    {
      get
      {
        ToolStripItemDisplayStyle displayStyle = this.DisplayStyle;
        return displayStyle == ToolStripItemDisplayStyle.Text || displayStyle == ToolStripItemDisplayStyle.ImageAndText;
      }
    }

    /// <summary>
    /// Gets a value indicating whether [should render image].
    /// </summary>
    /// <value><c>true</c> if [should render image]; otherwise, <c>false</c>.</value>
    protected bool ShouldRenderImage
    {
      get
      {
        ToolStripItemDisplayStyle displayStyle = this.DisplayStyle;
        return displayStyle == ToolStripItemDisplayStyle.Image || displayStyle == ToolStripItemDisplayStyle.ImageAndText;
      }
    }

    /// <summary>Gets or sets the object that contains data about the item.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that contains data about the control. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [DefaultValue(null)]
    [Bindable(true)]
    [SRDescription("ToolStripItemTagDescr")]
    [TypeConverter(typeof (StringConverter))]
    [Localizable(false)]
    public new object Tag
    {
      get => this.mobjTag;
      set
      {
        if (this.mobjTag == value)
          return;
        this.mobjTag = value;
      }
    }

    /// <summary>Gets or sets the text that is to be displayed on the item.</summary>
    /// <returns>A string representing the item's text. The default value is the empty string ("").</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Localizable(true)]
    [SRDescription("ToolStripItemTextDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue("")]
    public virtual string Text
    {
      get => this.mstrText;
      set
      {
        if (!(value != this.Text))
          return;
        this.mstrText = value;
        this.OnTextChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Layout | AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets a value indicating whether to hide item on strip wrapping.
    /// </summary>
    /// <value><c>true</c> if [hide on wrap]; otherwise, <c>false</c>.</value>
    protected virtual bool HideOnWrap => false;

    /// <summary>Gets or sets the parent internal.</summary>
    /// <value>The parent internal.</value>
    internal ToolStrip ParentInternal
    {
      get => this.mobjParent;
      set
      {
        ToolStrip parentInternal = this.ParentInternal;
        if (this.mobjParent == value)
          return;
        this.mobjParent = value;
        this.OnParentChanged(parentInternal, value);
        parentInternal?.Update();
        value?.Update();
      }
    }

    /// <summary>Gets or sets the alignment of the text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleRight"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripItemTextAlignDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(ContentAlignment.MiddleCenter)]
    [Localizable(true)]
    public virtual ContentAlignment TextAlign
    {
      get => this.menmTextAlign;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 1, 1024))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ContentAlignment));
        if (this.menmTextAlign == value)
          return;
        this.menmTextAlign = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets the orientation of text used on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripTextDirectionDescr")]
    public virtual ToolStripTextDirection TextDirection
    {
      get
      {
        if (this.menmTextDirection != ToolStripTextDirection.Inherit)
          return this.menmTextDirection;
        if (this.ParentInternal != null)
          return this.ParentInternal.TextDirection;
        return this.Owner != null ? this.Owner.TextDirection : ToolStripTextDirection.Horizontal;
      }
      set => this.menmTextDirection = ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 3) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ToolStripTextDirection));
    }

    /// <summary>Gets or sets the position of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> text and image relative to each other.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText"></see>.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [DefaultValue(TextImageRelation.ImageBeforeText)]
    [Localizable(true)]
    [SRDescription("ToolStripItemTextImageRelationDescr")]
    public TextImageRelation TextImageRelation
    {
      get => this.menmTextImageRelation;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 8))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (TextImageRelation));
        if (value == this.TextImageRelation)
          return;
        this.menmTextImageRelation = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the text that appears as a <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> for a control.</summary>
    /// <returns>A string representing the ToolTip text.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ToolStripItemToolTipTextDescr")]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    public string ToolTipText
    {
      get
      {
        if (!this.AutoToolTip || !string.IsNullOrEmpty(this.mstrToolTipText))
          return this.mstrToolTipText;
        string strText = this.Text;
        if (ClientUtils.ContainsMnemonic(strText))
          strText = string.Join("", strText.Split('&'));
        return strText;
      }
      set
      {
        if (!(this.mstrToolTipText != value))
          return;
        this.mstrToolTipText = value;
        this.UpdateParams(AttributeType.ToolTip);
      }
    }

    private void ResetToolTipText() => this.RemoveValue<string>(ToolStripItem.mstrToolTipTextProperty);

    /// <summary>Gets or sets a value indicating whether the item is displayed.</summary>
    /// <returns>true if the item is displayed; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripItemVisibleDescr")]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    [DefaultValue(true)]
    public bool Visible
    {
      get => this.ParentInternal != null && this.ParentInternal.Visible && this.Available;
      set
      {
        this.SetVisibleCore(value);
        this.UpdateParams(AttributeType.Visual);
        ToolStrip owner = this.Owner;
        if (owner == null)
          return;
        owner.InvalidateLayout(new LayoutEventArgs(false, false, false));
        owner.Update(true);
      }
    }

    /// <summary>Gets or sets the width in pixels of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the width in pixels.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatLayout")]
    [Browsable(false)]
    public int Width
    {
      get => this.Bounds.Width;
      set
      {
        Rectangle bounds = this.Bounds;
        if (bounds.Width == value)
          return;
        this.SetBounds(bounds.X, bounds.Y, value, bounds.Height);
        this.UpdateParams(AttributeType.Layout);
      }
    }

    ArrangedElementCollection IArrangedElement.Children => new ArrangedElementCollection();

    bool IArrangedElement.ParticipatesInLayout => this.Visible;

    /// <summary>Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
    /// <returns>One of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. The options are AllSystemSources, AllUrl, FileSystem, HistoryList, RecentlyUsedList, CustomSource, and None. The default is None.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatAccessibility")]
    [DefaultValue(AccessibleRole.Default)]
    [SRDescription("ToolStripItemAccessibleRoleDescr")]
    public AccessibleRole AccessibleRole
    {
      get => AccessibleRole.Default;
      set
      {
      }
    }

    /// <summary>Gets or sets the member ID.</summary>
    /// <value>The member ID.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public long MemberID
    {
      get
      {
        ToolStrip owner = this.Owner;
        return owner != null && owner.Items.Contains(this) ? (long) (owner.Items.IndexOf(this) + 1) : -1L;
      }
      set
      {
      }
    }

    /// <summary>Gets the owner ID.</summary>
    /// <value>The owner ID.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public long OwnerID
    {
      get
      {
        if (this.Owner is ToolStripDropDown owner1)
        {
          Form dropDownForm = owner1.DropDownForm;
          if (dropDownForm != null)
            return dropDownForm.GetProxyPropertyValue<long>("ID", dropDownForm.ID);
        }
        ToolStrip owner2 = this.Owner;
        return owner2 != null ? owner2.GetProxyPropertyValue<long>("ID", owner2.ID) : 0L;
      }
    }

    /// <summary>Gets the theme.</summary>
    /// <value>The theme.</value>
    string ISkinable.Theme => this.Context != null ? this.Context.CurrentTheme : string.Empty;
  }
}
