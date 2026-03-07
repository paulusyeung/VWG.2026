// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PictureBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a Windows picture box control for displaying an image.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (PictureBox), "PictureBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DefaultBindingProperty("Image")]
  [DefaultProperty("Image")]
  [SRDescription("DescriptionPictureBox")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("PBX")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (PictureBoxSkin))]
  [Serializable]
  public class PictureBox : Control, ISupportInitialize
  {
    /// <summary>Provides a property reference to Image property.</summary>
    private static SerializableProperty ImageProperty = SerializableProperty.Register(nameof (Image), typeof (ResourceHandle), typeof (PictureBox));
    /// <summary>
    /// Provides a property reference to PictureBoxSizeMode property.
    /// </summary>
    private static SerializableProperty PictureBoxSizeModeProperty = SerializableProperty.Register("PictureBoxSizeMode", typeof (PictureBoxSizeMode), typeof (PictureBox));

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> class.
    /// </summary>
    public PictureBox()
    {
      this.Size = new Size(64, 105);
      this.SetStyle(ControlStyles.Opaque | ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
      this.TabStop = false;
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeString("IMS", ((int) this.SizeMode).ToString());
      ResourceHandle proxyPropertyValue = this.GetProxyPropertyValue<ResourceHandle>("Image", this.Image);
      if (proxyPropertyValue == null)
        return;
      objWriter.WriteAttributeString("IM", proxyPropertyValue.ToString());
    }

    /// <summary>Indicates how the image is displayed.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.PictureBoxSizeMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.PictureBoxSizeMode.Normal"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.PictureBoxSizeMode"></see> values. </exception>
    [DefaultValue(PictureBoxSizeMode.Normal)]
    [Localizable(true)]
    [SRDescription("PictureBoxSizeModeDescr")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    public PictureBoxSizeMode SizeMode
    {
      get => this.GetValue<PictureBoxSizeMode>(PictureBox.PictureBoxSizeModeProperty, PictureBoxSizeMode.Normal);
      set
      {
        if (this.SizeMode == value)
          return;
        if (value != PictureBoxSizeMode.Normal)
          this.SetValue<PictureBoxSizeMode>(PictureBox.PictureBoxSizeModeProperty, value);
        else
          this.RemoveValue<PictureBoxSizeMode>(PictureBox.PictureBoxSizeModeProperty);
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets or sets the tab index.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new int TabIndex
    {
      get => base.TabIndex;
      set => base.TabIndex = value;
    }

    /// <summary>
    /// Gets or sets the image that is displayed by <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>.
    /// </summary>
    /// <returns>The <see cref="T:System.Drawing.Image"></see> to display.</returns>
    [SRDescription("PictureBoxImageDescr")]
    [Localizable(true)]
    [Bindable(true)]
    [SRCategory("CatAppearance")]
    [DefaultValue(null)]
    [ProxyBrowsable(true)]
    public ResourceHandle Image
    {
      get => this.GetValue<ResourceHandle>(PictureBox.ImageProperty, (ResourceHandle) null);
      set
      {
        if (this.Image == value)
          return;
        if (value != null)
          this.SetValue<ResourceHandle>(PictureBox.ImageProperty, value);
        else
          this.RemoveValue<ResourceHandle>(PictureBox.ImageProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether an image is loaded synchronously.</summary>
    /// <returns>true if an image-loading operation is done synchronously, otherwise, false. The default is false.</returns>
    /// <filterpriority>2</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [SRCategory("CatAsynchronous")]
    [SRDescription("PictureBoxWaitOnLoadDescr")]
    [DefaultValue(false)]
    public bool WaitOnLoad
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the image displayed in the <see cref="T:System.Windows.Forms.PictureBox"></see> control while the main image is loading.</summary>
    /// <returns>The <see cref="T:System.Drawing.Image"></see> displayed in the picture box control while the main image is loading.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatAsynchronous")]
    [Localizable(true)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("PictureBoxInitialImageDescr")]
    public ResourceHandle InitialImage
    {
      get => (ResourceHandle) null;
      set
      {
      }
    }

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.CausesValidation"></see> property changes.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler CausesValidationChanged
    {
      add => base.CausesValidationChanged += value;
      remove => base.CausesValidationChanged -= value;
    }

    /// <summary>Occurs when the control is entered.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler Enter
    {
      add => base.Enter += value;
      remove => base.Enter -= value;
    }

    /// <summary>Occurs when the FontChanged property changes.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler FontChanged
    {
      add => base.FontChanged += value;
      remove => base.FontChanged -= value;
    }

    /// <summary>Occurs when the ForeColorChanged property changes.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler ForeColorChanged
    {
      add => base.ForeColorChanged += value;
      remove => base.ForeColorChanged -= value;
    }

    /// <summary>
    /// Occurs on key down.
    /// Implemented by design as KeyPress (Use KeyPress instead).
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event KeyEventHandler KeyDown
    {
      add => base.KeyDown += value;
      remove => base.KeyDown -= value;
    }

    /// <summary>Occurs on key press.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event KeyPressEventHandler KeyPress
    {
      add => base.KeyPress += value;
      remove => base.KeyPress -= value;
    }

    /// <summary>
    /// Occurs on key up.
    /// Implemented by design as KeyPress (Use KeyPress instead).
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event KeyEventHandler KeyUp
    {
      add => base.KeyUp += value;
      remove => base.KeyUp -= value;
    }

    /// <summary>
    /// Occurs when the input focus leaves the control.
    /// Not implemented by design.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler Leave
    {
      add => base.Leave += value;
      remove => base.Leave -= value;
    }

    /// <summary>Occurs when the Text property value changes.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler TextChanged
    {
      add => base.TextChanged += value;
      remove => base.TextChanged -= value;
    }

    /// <summary>Occurs when [client key down].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event ClientEventHandler ClientKeyDown
    {
      add => base.ClientKeyDown += value;
      remove => base.ClientKeyDown -= value;
    }

    /// <summary>Loads the specified URL.</summary>
    /// <param name="strUrl">The URL.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatAsynchronous")]
    [SRDescription("PictureBoxLoad1Descr")]
    public void Load(string strUrl)
    {
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new PictureBoxRenderer(this);

    void ISupportInitialize.BeginInit()
    {
    }

    void ISupportInitialize.EndInit()
    {
    }
  }
}
