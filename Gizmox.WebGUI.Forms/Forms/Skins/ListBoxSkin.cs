// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ListBoxSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ListBox Skin</summary>
  [ToolboxBitmap(typeof (ListBox), "ListBox.bmp")]
  [Serializable]
  public class ListBoxSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the height of the selection icon image.</summary>
    /// <value>The height of the selection icon image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int SelectionIconHeight => this.GetMaxImageHeight(this.DefaultSelectionIconHeight, "CheckBox0.gif", "CheckBox1.gif", "Radio0.gif", "Radio1.gif");

    /// <summary>Resets the height of the selection icon.</summary>
    private void ResetSelectionIconHeight() => this.Reset("SelectionIconHeight");

    /// <summary>Gets the default height of the selection icon.</summary>
    /// <value>The default height of the selection icon.</value>
    protected virtual int DefaultSelectionIconHeight => 13;

    /// <summary>Gets the width of the selection icon image.</summary>
    /// <value>The width of the selection icon image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int SelectionIconWidth => this.GetMaxImageWidth(this.DefaultSelectionIconWidth, "CheckBox0.gif", "CheckBox1.gif", "Radio0.gif", "Radio1.gif");

    /// <summary>Resets the width of the selection icon.</summary>
    private void ResetSelectionIconWidth() => this.Reset("SelectionIconWidth");

    /// <summary>Gets the default width of the selection icon.</summary>
    /// <value>The default width of the selection icon.</value>
    protected virtual int DefaultSelectionIconWidth => 13;

    /// <summary>Gets or sets the width of the check box cell.</summary>
    /// <value>The width of the check box cell.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The check box cell width.")]
    public virtual int CheckBoxCellWidth
    {
      get => this.GetValue<int>(nameof (CheckBoxCellWidth), this.DefaultCheckBoxCellWidth);
      set => this.SetValue(nameof (CheckBoxCellWidth), (object) value);
    }

    /// <summary>Resets the width of the check box cell.</summary>
    internal void ResetCheckBoxCellWidth() => this.Reset("CheckBoxCellWidth");

    /// <summary>Gets the default width of the check box cell.</summary>
    /// <value>The default width of the check box cell.</value>
    protected virtual int DefaultCheckBoxCellWidth => 20;

    /// <summary>Gets or sets the width of the list box color cell.</summary>
    /// <value>The width of the list box color cell.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The ListBox color cell width.")]
    public virtual int ListBoxColorCellWidth
    {
      get => this.GetValue<int>(nameof (ListBoxColorCellWidth), this.DefaultListBoxColorCellWidth);
      set => this.SetValue(nameof (ListBoxColorCellWidth), (object) value);
    }

    /// <summary>Resets the width of the color list box color cell.</summary>
    internal void ResetListBoxColorCellWidth() => this.Reset("ListBoxColorCellWidth");

    /// <summary>
    /// Gets the default width of the color list box color cell.
    /// </summary>
    /// <value>The default width of the color list box color cell.</value>
    protected virtual int DefaultListBoxColorCellWidth => 30;

    /// <summary>Gets or sets the Height of the list box image cell.</summary>
    /// <value>The Height of the list box image cell.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The ListBox Image Cell Height.")]
    public virtual int ListBoxColorBoxHeight
    {
      get => this.GetValue<int>(nameof (ListBoxColorBoxHeight), this.DefaultListBoxColorBoxHeight);
      set => this.SetValue(nameof (ListBoxColorBoxHeight), (object) value);
    }

    /// <summary>Resets the height of the selection icon.</summary>
    private void ResetListBoxColorBoxHeight() => this.Reset("ListBoxColorBoxHeight");

    /// <summary>Gets the default height of the selection icon.</summary>
    /// <value>The default height of the selection icon.</value>
    protected virtual int DefaultListBoxColorBoxHeight => 14;

    /// <summary>Gets or sets the width of the list box image cell.</summary>
    /// <value>The width of the list box image cell.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The ListBox Image Cell Width.")]
    public virtual int ListBoxImageCellWidth
    {
      get => this.GetValue<int>(nameof (ListBoxImageCellWidth), this.DefaultListBoxImageCellWidth);
      set => this.SetValue(nameof (ListBoxImageCellWidth), (object) value);
    }

    /// <summary>Resets the width of the list box image cell.</summary>
    internal void ResetListBoxImageCellWidth() => this.Reset("ListBoxImageCellWidth");

    /// <summary>
    /// Gets the default width of the color list box color cell.
    /// </summary>
    /// <value>The default width of the color list box color cell.</value>
    protected virtual int DefaultListBoxImageCellWidth => 16;

    /// <summary>Gets or sets the height of the list box image cell.</summary>
    /// <value>The height of the list box image cell.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The ListBox Image Cell Height.")]
    public virtual int ListBoxImageCellHeight
    {
      get => this.GetValue<int>(nameof (ListBoxImageCellHeight), this.DefaultListBoxImageCellHeight);
      set => this.SetValue(nameof (ListBoxImageCellHeight), (object) value);
    }

    /// <summary>Resets the height of the list box image cell.</summary>
    internal void ResetListBoxImageCellHeight() => this.Reset("ListBoxImageCellHeight");

    /// <summary>Gets the default height of the list box image cell.</summary>
    /// <value>The default height of the list box image cell.</value>
    protected virtual int DefaultListBoxImageCellHeight => 16;

    /// <summary>Gets the width of the preferd image box.</summary>
    /// <value>The width of the preferd image box.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int PreferdImageBoxWidth => this.ListBoxImageCellWidth + this.CellStyle.Padding.Horizontal;

    /// <summary>Gets the width of the preferd color box.</summary>
    /// <value>The width of the preferd color box.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int PreferdColorBoxWidth => this.ListBoxColorCellWidth + this.CellStyle.Padding.Horizontal;

    /// <summary>Gets the focused list box selected row style.</summary>
    /// <value>The focused list box selected row style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The focused listbox selected row style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue FocusedListBoxSelectedRowStyle => new StyleValue((CommonSkin) this, nameof (FocusedListBoxSelectedRowStyle));

    /// <summary>Gets the selected cell style.</summary>
    /// <value>The selected cell style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The selected cell style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SelectedCellStyle => new StyleValue((CommonSkin) this, nameof (SelectedCellStyle));

    /// <summary>Gets the color list box color box style.</summary>
    /// <value>The color list box color box style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The color listbox color box style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ColorBoxStyle => new StyleValue((CommonSkin) this, nameof (ColorBoxStyle));

    /// <summary>Gets the cell style.</summary>
    /// <value>The cell style.</value>
    public virtual StyleValue CellStyle => new StyleValue((CommonSkin) this, nameof (CellStyle));

    /// <summary>Gets or sets the checked radio button image.</summary>
    /// <value>The checked radio button image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The CheckedRadioButtonImage.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference CheckedRadioButtonImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (CheckedRadioButtonImage), new ImageResourceReference(typeof (ListBoxSkin), "Radio1.gif"));
      set => this.SetValue(nameof (CheckedRadioButtonImage), (object) value);
    }

    internal void ResetCheckedRadioButtonImage() => this.Reset("CheckedRadioButtonImage");

    /// <summary>Gets or sets the unchecked radio button image.</summary>
    /// <value>The unchecked radio button image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The UncheckedRadioButtonImage.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UncheckedRadioButtonImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UncheckedRadioButtonImage), new ImageResourceReference(typeof (ListBoxSkin), "Radio0.gif"));
      set => this.SetValue(nameof (UncheckedRadioButtonImage), (object) value);
    }

    internal void ResetUncheckedRadioButtonImage() => this.Reset("UncheckedRadioButtonImage");

    /// <summary>Gets or sets the checked check box image.</summary>
    /// <value>The checked check box image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The CheckedCheckBoxImage.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference CheckedCheckBoxImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (CheckedCheckBoxImage), new ImageResourceReference(typeof (ListBoxSkin), "CheckBox1.gif"));
      set => this.SetValue(nameof (CheckedCheckBoxImage), (object) value);
    }

    internal void ResetCheckedCheckBoxImage() => this.Reset("CheckedCheckBoxImage");

    /// <summary>Gets or sets the unchecked check box image.</summary>
    /// <value>The unchecked check box image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The UncheckedCheckBoxImage.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UncheckedCheckBoxImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UncheckedCheckBoxImage), new ImageResourceReference(typeof (ListBoxSkin), "CheckBox0.gif"));
      set => this.SetValue(nameof (UncheckedCheckBoxImage), (object) value);
    }

    internal void ResetUncheckedCheckBoxImage() => this.Reset("UncheckedCheckBoxImage");

    /// <summary>Gets or sets the indeterminate check box image.</summary>
    /// <value>The indeterminate check box image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The Indeterminate checkbox image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference IndeterminateCheckBoxImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (IndeterminateCheckBoxImage), new ImageResourceReference(typeof (ListBoxSkin), "CheckBox2.gif"));
      set => this.SetValue(nameof (IndeterminateCheckBoxImage), (object) value);
    }

    internal void ResetIndeterminateCheckBoxImage() => this.Reset("IndeterminateCheckBoxImage");
  }
}
