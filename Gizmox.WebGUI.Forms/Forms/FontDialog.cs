// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FontDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Prompts the user to choose a font from among those installed on the local computer.</summary>
  /// <filterpriority>2</filterpriority>
  [SRDescription("DescriptionFontDialog")]
  [DefaultEvent("Apply")]
  [DefaultProperty("Font")]
  [ToolboxBitmap(typeof (FontDialog), "FontDialog_45.bmp")]
  [ToolboxItem(true)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (FontDialogSkin))]
  [Serializable]
  public class FontDialog : CommonDialog
  {
    private Color mobjColor;
    private const int mintDefaultMaxSize = 0;
    private const int mintDefaultMinSize = 0;
    /// <summary>Owns the Apply event.</summary>
    protected static readonly SerializableEvent EventApply = SerializableEvent.Register("Event", typeof (Delegate), typeof (FontDialog));
    private SerializableFont mobjFont;
    private int mintMaxSize;
    private int mintMinSize;
    private int mintOptions;
    private bool mblnShowColor;

    /// <summary>Occurs when [apply].</summary>
    public event EventHandler Apply
    {
      add => this.AddHandler(FontDialog.EventApply, (Delegate) value);
      remove => this.RemoveHandler(FontDialog.EventApply, (Delegate) value);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see> class.</summary>
    public FontDialog() => this.Reset();

    /// <summary>Gets a dialog option value</summary>
    /// <param name="intOption"></param>
    /// <returns></returns>
    internal bool GetOption(int intOption) => (this.mintOptions & intOption) != 0;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.FontDialog.Apply"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the data. </param>
    protected override void OnApply(EventArgs e)
    {
      EventHandler handler = (EventHandler) this.GetHandler(FontDialog.EventApply);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>Resets all dialog box options to their default values.</summary>
    /// <filterpriority>1</filterpriority>
    public override void Reset()
    {
      this.mintOptions = 257;
      this.mobjFont = (SerializableFont) null;
      this.mobjColor = Color.Black;
      this.mblnShowColor = false;
      this.mintMinSize = 8;
      this.mintMaxSize = 72;
      this.SetOption(262144, true);
    }

    private void ResetFont() => this.mobjFont = (SerializableFont) null;

    /// <summary>Sets a dialog option value</summary>
    /// <param name="intOption"></param>
    /// <param name="blnValue"></param>
    internal void SetOption(int intOption, bool blnValue)
    {
      if (blnValue)
        this.mintOptions |= intOption;
      else
        this.mintOptions &= ~intOption;
    }

    private bool ShouldSerializeFont() => !this.Font.Equals((object) Control.DefaultFont);

    /// <summary>Retrieves a string that includes the name of the current font selected in the dialog box.</summary>
    /// <returns>A string that includes the name of the currently selected font.</returns>
    public override string ToString() => base.ToString() + ",  Font: " + this.Font.ToString();

    /// <summary>Create the color dialog form</summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm() => (CommonDialog.CommonDialogForm) new FontDialog.FontDialogForm(this);

    /// <summary>Gets or sets a value indicating whether the user can change the character set specified in the Script combo box to display a character set other than the one currently displayed.</summary>
    /// <returns>true if the user can change the character set specified in the Script combo box; otherwise, false. The default value is true.</returns>
    [DefaultValue(true)]
    [SRDescription("FnDallowScriptChangeDescr")]
    [SRCategory("CatBehavior")]
    public bool AllowScriptChange
    {
      get => !this.GetOption(4194304);
      set => this.SetOption(4194304, !value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box allows graphics device interface (GDI) font simulations.</summary>
    /// <returns>true if font simulations are allowed; otherwise, false. The default value is true.</returns>
    [SRDescription("FnDallowSimulationsDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public bool AllowSimulations
    {
      get => !this.GetOption(4096);
      set => this.SetOption(4096, !value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box allows vector font selections.</summary>
    /// <returns>true if vector fonts are allowed; otherwise, false. The default value is true.</returns>
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    [SRDescription("FnDallowVectorFontsDescr")]
    public bool AllowVectorFonts
    {
      get => !this.GetOption(2048);
      set => this.SetOption(2048, !value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box displays both vertical and horizontal fonts or only horizontal fonts.</summary>
    /// <returns>true if both vertical and horizontal fonts are allowed; otherwise, false. The default value is true.</returns>
    [SRCategory("CatBehavior")]
    [SRDescription("FnDallowVerticalFontsDescr")]
    [DefaultValue(true)]
    public bool AllowVerticalFonts
    {
      get => !this.GetOption(16777216);
      set => this.SetOption(16777216, !value);
    }

    /// <summary>Gets or sets the selected font color.</summary>
    /// <returns>The color of the selected font. The default value is <see cref="P:System.Drawing.Color.Black"></see>.</returns>
    [SRDescription("FnDcolorDescr")]
    [DefaultValue(typeof (Color), "Black")]
    [SRCategory("CatData")]
    public Color Color
    {
      get => this.mobjColor;
      set
      {
        if (!value.IsEmpty)
          this.mobjColor = value;
        else
          this.mobjColor = Color.Black;
      }
    }

    /// <summary>Gets or sets a value indicating whether the dialog box allows only the selection of fixed-pitch fonts.</summary>
    /// <returns>true if only fixed-pitch fonts can be selected; otherwise, false. The default value is false.</returns>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("FnDfixedPitchOnlyDescr")]
    public bool FixedPitchOnly
    {
      get => this.GetOption(16384);
      set => this.SetOption(16384, value);
    }

    /// <summary>Gets or sets the selected font.</summary>
    /// <returns>The selected font.</returns>
    [SRCategory("CatData")]
    [SRDescription("FnDfontDescr")]
    public Font Font
    {
      get
      {
        Font font = (Font) this.mobjFont ?? Control.DefaultFont;
        float sizeInPoints = font.SizeInPoints;
        if (this.mintMinSize != 0 && (double) sizeInPoints < (double) this.MinSize)
          font = new Font(font.FontFamily, (float) this.MinSize, font.Style, GraphicsUnit.Point);
        if (this.mintMaxSize != 0 && (double) sizeInPoints > (double) this.MaxSize)
          font = new Font(font.FontFamily, (float) this.MaxSize, font.Style, GraphicsUnit.Point);
        return font;
      }
      set => this.mobjFont = (SerializableFont) value;
    }

    /// <summary>Gets or sets a value indicating whether the dialog box specifies an error condition if the user attempts to select a font or style that does not exist.</summary>
    /// <returns>true if the dialog box specifies an error condition when the user tries to select a font or style that does not exist; otherwise, false. The default is false.</returns>
    [DefaultValue(false)]
    [SRDescription("FnDfontMustExistDescr")]
    [SRCategory("CatBehavior")]
    public bool FontMustExist
    {
      get => this.GetOption(65536);
      set => this.SetOption(65536, value);
    }

    /// <summary>Gets or sets the maximum point size a user can select.</summary>
    /// <returns>The maximum point size a user can select. The default is 0.</returns>
    [SRDescription("FnDmaxSizeDescr")]
    [SRCategory("CatData")]
    [DefaultValue(0)]
    public int MaxSize
    {
      get => this.mintMaxSize;
      set
      {
        if (value < 0)
          value = 0;
        this.mintMaxSize = value;
        if (this.mintMaxSize <= 0 || this.mintMaxSize >= this.mintMinSize)
          return;
        this.mintMinSize = this.mintMaxSize;
      }
    }

    /// <summary>Gets or sets the minimum point size a user can select.</summary>
    /// <returns>The minimum point size a user can select. The default is 0.</returns>
    [DefaultValue(0)]
    [SRDescription("FnDminSizeDescr")]
    [SRCategory("CatData")]
    public int MinSize
    {
      get => this.mintMinSize;
      set
      {
        if (value < 0)
          value = 0;
        this.mintMinSize = value;
        if (this.mintMaxSize <= 0 || this.mintMaxSize >= this.mintMinSize)
          return;
        this.mintMaxSize = this.mintMinSize;
      }
    }

    /// <summary>Gets values to initialize the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see>.</summary>
    /// <returns>A bitwise combination of internal values that initializes the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see>.</returns>
    protected int Options => this.mintOptions;

    /// <summary>Gets or sets a value indicating whether the dialog box allows selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.</summary>
    /// <returns>true if selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set, is allowed; otherwise, false. The default value is false.</returns>
    [SRDescription("FnDscriptsOnlyDescr")]
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    public bool ScriptsOnly
    {
      get => this.GetOption(1024);
      set => this.SetOption(1024, value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box contains an Apply button.</summary>
    /// <returns>true if the dialog box contains an Apply button; otherwise, false. The default value is false.</returns>
    [SRDescription("FnDshowApplyDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool ShowApply
    {
      get => this.GetOption(512);
      set => this.SetOption(512, value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box displays the color choice.</summary>
    /// <returns>true if the dialog box displays the color choice; otherwise, false. The default value is false.</returns>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("FnDshowColorDescr")]
    public bool ShowColor
    {
      get => this.mblnShowColor;
      set => this.mblnShowColor = value;
    }

    /// <summary>Gets or sets a value indicating whether the dialog box contains controls that allow the user to specify strikethrough, underline, and text color options.</summary>
    /// <returns>true if the dialog box contains controls to set strikethrough, underline, and text color options; otherwise, false. The default value is true.</returns>
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    [SRDescription("FnDshowEffectsDescr")]
    public bool ShowEffects
    {
      get => this.GetOption(256);
      set => this.SetOption(256, value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box displays a Help button.</summary>
    /// <returns>true if the dialog box displays a Help button; otherwise, false. The default value is false.</returns>
    [SRCategory("CatBehavior")]
    [SRDescription("FnDshowHelpDescr")]
    [DefaultValue(false)]
    public bool ShowHelp
    {
      get => this.GetOption(4);
      set => this.SetOption(4, value);
    }

    /// <summary>Implements the font dialog form</summary>
    [Serializable]
    protected class FontDialogForm : CommonDialog.CommonDialogForm
    {
      private bool mblnTextChanged;
      private bool mblnListChanging;
      private bool mblnInitializing;
      private bool mblnInitialized;
      private Button mobjButtonOk;
      private Button mobjButtonCancel;
      private Button mobjButtonApply;
      private GroupBox mobjGroupsEffects;
      private CheckBox mobjCheckStrikeout;
      private CheckBox mobjCheckUnderline;
      private GroupBox mobjGroupSample;
      private Label mobjLabelSample;
      private Label mobjLabelScrpt;
      private Label mobjLabelColor;
      private ComboBox mobjComboScript;
      private ColorComboBox mobjComboColor;
      private ListBox mobjListFont;
      private ListBox mobjListFontStyle;
      private ListBox mobjListSize;
      private TextBox mobjTextFont;
      private TextBox mobjTextFontStyle;
      private TextBox mobjTextSize;
      private Label mobjLabelFont;
      private Label mobjLabelFontStyle;
      private Label mobjLabelSize;

      /// <summary>Occurs when the user clicks the Apply button in the font dialog box.</summary>
      /// <filterpriority>1</filterpriority>
      [SRDescription("FnDapplyDescr")]
      public event EventHandler Apply;

      /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see> class.</summary>
      public FontDialogForm(FontDialog objFontDialog)
        : base((CommonDialog) objFontDialog)
      {
        this.InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.AllowScriptChange = objFontDialog.AllowScriptChange;
        this.AllowSimulations = objFontDialog.AllowSimulations;
        this.AllowVectorFonts = objFontDialog.AllowVectorFonts;
        this.AllowVerticalFonts = objFontDialog.AllowVerticalFonts;
        this.Color = objFontDialog.mobjColor;
        this.FixedPitchOnly = objFontDialog.FixedPitchOnly;
        this.Font = objFontDialog.Font;
        this.FontMustExist = objFontDialog.FontMustExist;
        this.MaxSize = objFontDialog.MaxSize;
        this.MinSize = objFontDialog.MinSize;
        this.ScriptsOnly = objFontDialog.ScriptsOnly;
        this.ShowApply = objFontDialog.ShowApply;
        this.ShowColor = objFontDialog.ShowColor;
        this.ShowEffects = objFontDialog.ShowEffects;
        this.ShowHelp = objFontDialog.ShowHelp;
        this.Load += new EventHandler(this.FontDialog_Load);
      }

      private void UpdateFromFont()
      {
        if (this.Font == null)
          return;
        this.mobjTextFont.Text = this.Font.FontFamily.Name;
        this.mobjTextFontStyle.Text = this.Font.Style.ToString();
        this.mobjTextSize.Text = this.Font.Size.ToString();
        this.mobjCheckStrikeout.Checked = this.Font.Strikeout;
        this.mobjCheckUnderline.Checked = this.Font.Underline;
      }

      /// <summary>Gets the web colors.</summary>
      /// <returns></returns>
      protected virtual Color[] GetWebColors() => this.GetConstants(typeof (Color));

      /// <summary>Gets the constants.</summary>
      /// <param name="objEnumType">Type of the enum.</param>
      /// <returns></returns>
      private Color[] GetConstants(Type objEnumType)
      {
        MethodAttributes methodAttributes = MethodAttributes.Public | MethodAttributes.Static;
        PropertyInfo[] properties = objEnumType.GetProperties();
        ArrayList arrayList = new ArrayList();
        for (int index1 = 0; index1 < properties.Length; ++index1)
        {
          PropertyInfo propertyInfo = properties[index1];
          if (propertyInfo.PropertyType == typeof (Color))
          {
            MethodInfo getMethod = propertyInfo.GetGetMethod();
            if (getMethod != (MethodInfo) null && (getMethod.Attributes & methodAttributes) == methodAttributes)
            {
              object[] index2 = (object[]) null;
              arrayList.Add(propertyInfo.GetValue((object) null, index2));
            }
          }
        }
        return (Color[]) arrayList.ToArray(typeof (Color));
      }

      private void FontDialog_Load(object sender, EventArgs e)
      {
        this.mblnInitializing = true;
        int[] numArray = new int[17]
        {
          8,
          9,
          10,
          11,
          12,
          13,
          14,
          16,
          18,
          20,
          22,
          24,
          26,
          28,
          36,
          48,
          72
        };
        this.mobjListFont.DataSource = (object) SerializableFontFamily.Families;
        this.mobjListFont.DisplayMember = "Name";
        this.mobjListFont.ValueMember = "Name";
        if (this.Font == null)
          this.Font = new Font("Arial", 10f);
        for (int index = 0; index < numArray.Length; ++index)
        {
          int objObject = (int) numArray.GetValue(index);
          if (objObject >= this.MinSize && objObject <= this.MaxSize)
            this.mobjListSize.Items.Add((object) objObject);
        }
        if (this.mobjListSize.Items.Count < 1)
          this.mobjTextSize.Text = this.MaxSize.ToString();
        this.mobjLabelSample.Font = this.Font;
        this.mobjLabelSample.ForeColor = this.Color;
        if (this.FontDialogOwner.ShowColor)
          this.mobjComboColor.SelectedItem = (object) this.Color;
        int num1 = this.mobjListSize.FindString(Math.Round((double) this.Font.Size).ToString());
        this.mobjListSize.SelectedIndex = num1 == -1 ? 0 : num1;
        int num2 = this.mobjListFont.FindString(this.Font.FontFamily.Name.ToString());
        this.mobjListFont.SelectedIndex = num2 == -1 ? 0 : num2;
        this.mobjCheckStrikeout.Checked = this.Font.Strikeout;
        this.mobjCheckUnderline.Checked = this.Font.Underline;
        this.mblnInitializing = false;
        this.UpdateFontStyles((SerializableFontFamily) this.Font.FontFamily, false);
        if (this.Font.Bold && this.Font.Italic)
        {
          int num3 = this.mobjListFontStyle.FindString(WGLabels.BoldItalic);
          this.mobjListFontStyle.SelectedIndex = num3 == -1 ? 0 : num3;
        }
        else if (this.Font.Bold)
        {
          int num4 = this.mobjListFontStyle.FindString(WGLabels.Bold);
          this.mobjListFontStyle.SelectedIndex = num4 == -1 ? 0 : num4;
        }
        else if (this.Font.Italic)
        {
          int num5 = this.mobjListFontStyle.FindString(WGLabels.Italic);
          this.mobjListFontStyle.SelectedIndex = num5 == -1 ? 0 : num5;
        }
        else
        {
          int num6 = this.mobjListFontStyle.FindString(WGLabels.Regular);
          this.mobjListFontStyle.SelectedIndex = num6 == -1 ? 0 : num6;
        }
        this.mblnInitialized = true;
      }

      private void InitializeComponent()
      {
        this.mobjButtonOk = new Button();
        this.mobjButtonCancel = new Button();
        this.mobjButtonApply = new Button();
        this.mobjGroupsEffects = new GroupBox();
        this.mobjCheckStrikeout = new CheckBox();
        this.mobjCheckUnderline = new CheckBox();
        this.mobjGroupSample = new GroupBox();
        this.mobjLabelSample = new Label();
        this.mobjLabelScrpt = new Label();
        this.mobjLabelColor = new Label();
        this.mobjComboScript = new ComboBox();
        this.mobjComboColor = new ColorComboBox();
        this.mobjListFont = new ListBox();
        this.mobjListFontStyle = new ListBox();
        this.mobjListSize = new ListBox();
        this.mobjTextFont = new TextBox();
        this.mobjTextFontStyle = new TextBox();
        this.mobjTextSize = new TextBox();
        this.mobjLabelFont = new Label();
        this.mobjLabelFontStyle = new Label();
        this.mobjLabelSize = new Label();
        this.mobjGroupsEffects.SuspendLayout();
        this.mobjGroupSample.SuspendLayout();
        this.SuspendLayout();
        this.mobjButtonOk.Location = new Point(351, 27);
        this.mobjButtonOk.Name = "mobjButtonOk";
        this.mobjButtonOk.Size = new Size(62, 23);
        this.mobjButtonOk.TabIndex = 0;
        this.mobjButtonOk.Text = WGLabels.Ok;
        this.mobjButtonOk.Click += new EventHandler(this.mobjButtonOk_Click);
        this.mobjButtonCancel.Location = new Point(351, 52);
        this.mobjButtonCancel.Name = "mobjButtonCancel";
        this.mobjButtonCancel.Size = new Size(62, 23);
        this.mobjButtonCancel.TabIndex = 1;
        this.mobjButtonCancel.Text = WGLabels.Cancel;
        this.mobjButtonCancel.Click += new EventHandler(this.mobjButtonCancel_Click);
        this.mobjButtonApply.Location = new Point(351, 77);
        this.mobjButtonApply.Name = "mobjButtonApply";
        this.mobjButtonApply.Size = new Size(62, 23);
        this.mobjButtonApply.TabIndex = 1;
        this.mobjButtonApply.Text = WGLabels.Apply;
        this.mobjButtonApply.Click += new EventHandler(this.mobjButtonApply_Click);
        this.mobjGroupsEffects.Controls.Add((Control) this.mobjCheckUnderline);
        this.mobjGroupsEffects.Controls.Add((Control) this.mobjCheckStrikeout);
        this.mobjGroupsEffects.Controls.Add((Control) this.mobjLabelColor);
        this.mobjGroupsEffects.Controls.Add((Control) this.mobjComboColor);
        this.mobjGroupsEffects.Location = new Point(12, 158);
        this.mobjGroupsEffects.Name = "mobjGroupsEffects";
        this.mobjGroupsEffects.Size = new Size(146, 120);
        this.mobjGroupsEffects.TabIndex = 2;
        this.mobjGroupsEffects.TabStop = false;
        this.mobjGroupsEffects.Text = WGLabels.Effects;
        this.mobjCheckStrikeout.Location = new Point(7, 20);
        this.mobjCheckStrikeout.Name = "mobjCheckStrikeout";
        this.mobjCheckStrikeout.Size = new Size(80, 17);
        this.mobjCheckStrikeout.TabIndex = 0;
        this.mobjCheckStrikeout.Text = WGLabels.Strikeout;
        this.mobjCheckStrikeout.CheckedChanged += new EventHandler(this.mobjCheckStrikeout_CheckedChanged);
        this.mobjCheckUnderline.Location = new Point(7, 40);
        this.mobjCheckUnderline.Name = "mobjCheckUnderline";
        this.mobjCheckUnderline.Size = new Size(80, 17);
        this.mobjCheckUnderline.TabIndex = 1;
        this.mobjCheckUnderline.Text = WGLabels.Underline;
        this.mobjCheckUnderline.CheckedChanged += new EventHandler(this.mobjCheckUnderline_CheckedChanged);
        this.mobjLabelColor.AutoSize = true;
        this.mobjLabelColor.Location = new Point(7, 60);
        this.mobjLabelColor.Name = "mobjLabelScrpt";
        this.mobjLabelColor.Size = new Size(71, 21);
        this.mobjLabelColor.TabIndex = 4;
        this.mobjLabelColor.Text = WGLabels.Color;
        this.mobjLabelColor.Visible = false;
        this.mobjComboColor.FormattingEnabled = true;
        this.mobjComboColor.Location = new Point(7, 75);
        this.mobjComboColor.Name = "mobjComboColor";
        this.mobjComboColor.Size = new Size(125, 21);
        this.mobjComboColor.TabIndex = 2;
        this.mobjComboColor.Visible = false;
        this.mobjComboColor.BackgroundImageLayout = ImageLayout.Tile;
        this.mobjComboColor.BorderStyle = BorderStyle.Fixed3D;
        this.mobjComboColor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        this.mobjComboColor.SelectedValueChanged += new EventHandler(this.mobjComboColor_SelectedValueChanged);
        this.mobjGroupSample.Controls.Add((Control) this.mobjLabelSample);
        this.mobjGroupSample.Location = new Point(164, 158);
        this.mobjGroupSample.Name = "mobjGroupSample";
        this.mobjGroupSample.Size = new Size(176, 70);
        this.mobjGroupSample.TabIndex = 3;
        this.mobjGroupSample.TabStop = false;
        this.mobjGroupSample.Text = WGLabels.Sample;
        this.mobjLabelSample.Location = new Point(15, 21);
        this.mobjLabelSample.Name = "mobjLabelSample";
        this.mobjLabelSample.Size = new Size(144, 42);
        this.mobjLabelSample.TabIndex = 0;
        this.mobjLabelSample.Text = "AaBbðñùú";
        this.mobjLabelSample.TextAlign = ContentAlignment.MiddleCenter;
        this.mobjLabelScrpt.AutoSize = true;
        this.mobjLabelScrpt.Location = new Point(164, 240);
        this.mobjLabelScrpt.Name = "mobjLabelScrpt";
        this.mobjLabelScrpt.Size = new Size(37, 13);
        this.mobjLabelScrpt.TabIndex = 4;
        this.mobjLabelScrpt.Text = WGLabels.Script;
        this.mobjLabelScrpt.Visible = false;
        this.mobjComboScript.FormattingEnabled = true;
        this.mobjComboScript.Location = new Point(167, 257);
        this.mobjComboScript.Name = "mobjComboScript";
        this.mobjComboScript.Size = new Size(173, 21);
        this.mobjComboScript.TabIndex = 5;
        this.mobjComboScript.Visible = false;
        this.mobjListFont.FormattingEnabled = true;
        this.mobjListFont.Location = new Point(12, 49);
        this.mobjListFont.Name = "mobjListFont";
        this.mobjListFont.Size = new Size(146, 95);
        this.mobjListFont.TabIndex = 6;
        this.mobjListFont.SelectedIndexChanged += new EventHandler(this.mobjListFont_SelectedIndexChanged);
        this.mobjListFont.SelectionMode = SelectionMode.One;
        this.mobjListFontStyle.FormattingEnabled = true;
        this.mobjListFontStyle.Location = new Point(167, 49);
        this.mobjListFontStyle.Name = "mobjListFontStyle";
        this.mobjListFontStyle.Size = new Size(110, 95);
        this.mobjListFontStyle.TabIndex = 7;
        this.mobjListFontStyle.SelectedIndexChanged += new EventHandler(this.mobjListFontStyle_SelectedIndexChanged);
        this.mobjListFontStyle.SelectionMode = SelectionMode.One;
        this.mobjListSize.FormattingEnabled = true;
        this.mobjListSize.Location = new Point(284, 49);
        this.mobjListSize.Name = "mobjListSize";
        this.mobjListSize.Size = new Size(56, 95);
        this.mobjListSize.TabIndex = 8;
        this.mobjListSize.SelectedIndexChanged += new EventHandler(this.mobjListSize_SelectedIndexChanged);
        this.mobjListSize.SelectionMode = SelectionMode.One;
        this.mobjTextFont.Location = new Point(12, 27);
        this.mobjTextFont.Name = "mobjTextFont";
        this.mobjTextFont.Size = new Size(146, 20);
        this.mobjTextFont.TabIndex = 9;
        this.mobjTextFont.TextChanged += new EventHandler(this.mobjTextFont_TextChanged);
        this.mobjTextFontStyle.Location = new Point(167, 27);
        this.mobjTextFontStyle.Name = "mobjTextFontStyle";
        this.mobjTextFontStyle.Size = new Size(110, 20);
        this.mobjTextFontStyle.TabIndex = 10;
        this.mobjTextFontStyle.TextChanged += new EventHandler(this.mobjTextFontStyle_TextChanged);
        this.mobjTextSize.Location = new Point(284, 27);
        this.mobjTextSize.Name = "mobjTextSize";
        this.mobjTextSize.Size = new Size(56, 20);
        this.mobjTextSize.TabIndex = 11;
        this.mobjTextSize.TextChanged += new EventHandler(this.mobjTextSize_TextChanged);
        this.mobjLabelFont.Location = new Point(12, 13);
        this.mobjLabelFont.Name = "mobjLabelFont";
        this.mobjLabelFont.Size = new Size(31, 13);
        this.mobjLabelFont.TabIndex = 12;
        this.mobjLabelFont.Text = WGLabels.FontColon;
        this.mobjLabelFontStyle.Location = new Point(167, 12);
        this.mobjLabelFontStyle.Name = "mobjLabelFontStyle";
        this.mobjLabelFontStyle.Size = new Size(57, 13);
        this.mobjLabelFontStyle.TabIndex = 13;
        this.mobjLabelFontStyle.Text = WGLabels.FontStyle;
        this.mobjLabelSize.Location = new Point(284, 12);
        this.mobjLabelSize.Name = "mobjLabelSize";
        this.mobjLabelSize.Size = new Size(30, 13);
        this.mobjLabelSize.TabIndex = 14;
        this.mobjLabelSize.Text = WGLabels.Size;
        this.ClientSize = new Size(433, 319);
        this.Controls.Add((Control) this.mobjLabelSize);
        this.Controls.Add((Control) this.mobjLabelFontStyle);
        this.Controls.Add((Control) this.mobjLabelFont);
        this.Controls.Add((Control) this.mobjTextSize);
        this.Controls.Add((Control) this.mobjTextFontStyle);
        this.Controls.Add((Control) this.mobjTextFont);
        this.Controls.Add((Control) this.mobjListSize);
        this.Controls.Add((Control) this.mobjListFontStyle);
        this.Controls.Add((Control) this.mobjListFont);
        this.Controls.Add((Control) this.mobjComboScript);
        this.Controls.Add((Control) this.mobjLabelScrpt);
        this.Controls.Add((Control) this.mobjGroupSample);
        this.Controls.Add((Control) this.mobjGroupsEffects);
        this.Controls.Add((Control) this.mobjButtonCancel);
        this.Controls.Add((Control) this.mobjButtonApply);
        this.Controls.Add((Control) this.mobjButtonOk);
        this.Name = nameof (FontDialog);
        this.Text = WGLabels.Font;
        this.mobjGroupsEffects.ResumeLayout(true);
        this.mobjGroupSample.ResumeLayout(false);
        this.ResumeLayout(true);
      }

      /// <summary>
      /// Handles the SelectedValueChanged event of the mobjComboColor control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mobjComboColor_SelectedValueChanged(object sender, EventArgs e)
      {
        if (this.mobjComboColor.SelectedItem == null)
          return;
        Color color = Color.Empty;
        try
        {
          color = (Color) this.mobjComboColor.SelectedItem;
        }
        catch
        {
        }
        this.FontDialogOwner.mobjColor = color;
        this.mobjLabelSample.ForeColor = color;
      }

      private void mobjCheckUnderline_CheckedChanged(object sender, EventArgs e) => this.RefreshFont();

      private void mobjCheckStrikeout_CheckedChanged(object sender, EventArgs e) => this.RefreshFont();

      private void UpdateFontStyles(SerializableFontFamily objFontFamily, bool blnUpdateSelection)
      {
        if (this.mblnInitializing)
          return;
        ArrayList objObjects = new ArrayList();
        if (objFontFamily.IsStyleAvailable(FontStyle.Regular))
          objObjects.Add((object) new FontDialog.FontDialogForm.FontStyleListItem(FontStyle.Regular, WGLabels.Regular));
        if (objFontFamily.IsStyleAvailable(FontStyle.Italic))
          objObjects.Add((object) new FontDialog.FontDialogForm.FontStyleListItem(FontStyle.Italic, WGLabels.Italic));
        if (objFontFamily.IsStyleAvailable(FontStyle.Bold))
          objObjects.Add((object) new FontDialog.FontDialogForm.FontStyleListItem(FontStyle.Bold, WGLabels.Bold));
        if (objFontFamily.IsStyleAvailable(FontStyle.Bold) || objFontFamily.IsStyleAvailable(FontStyle.Italic))
          objObjects.Add((object) new FontDialog.FontDialogForm.FontStyleListItem(FontStyle.Bold | FontStyle.Italic, WGLabels.BoldItalic));
        bool flag = this.mobjListFontStyle.Items.Count != objObjects.Count;
        if (!flag)
        {
          foreach (FontDialog.FontDialogForm.FontStyleListItem fontStyleListItem in objObjects)
          {
            if (this.mobjListFontStyle.FindString(fontStyleListItem.ToString()) == -1)
            {
              flag = true;
              break;
            }
          }
        }
        if (!flag)
          return;
        this.mobjListFontStyle.Items.Clear();
        this.mobjListFontStyle.Items.AddRange((ICollection) objObjects);
        if (!blnUpdateSelection)
          return;
        int num = this.mobjListFontStyle.FindString(WGLabels.Regular);
        this.mobjListFontStyle.SelectedIndex = num == -1 ? 0 : num;
      }

      private void mobjTextFont_TextChanged(object sender, EventArgs e)
      {
        if (this.mblnListChanging)
          return;
        this.ApplyFontName(false);
      }

      private void mobjTextFontStyle_TextChanged(object sender, EventArgs e)
      {
        if (this.mblnListChanging)
          return;
        int num = this.mobjListFontStyle.FindString(this.mobjTextFontStyle.Text);
        if (num > -1)
        {
          this.mblnTextChanged = true;
          this.mobjListFontStyle.SelectedIndex = num;
          this.mobjListFontStyle.Update();
          this.RefreshFont();
          this.mblnTextChanged = false;
        }
        else
          this.mobjTextFontStyle.Text = this.mobjListFontStyle.SelectedItem.ToString();
      }

      private void mobjTextSize_TextChanged(object sender, EventArgs e)
      {
        if (this.mblnListChanging)
          return;
        this.ApplyFontSize(false);
      }

      /// <summary>Applies the size of the font.</summary>
      /// <returns></returns>
      private bool ApplyFontSize(bool blnShowValidationMessages)
      {
        bool flag = false;
        int num1 = this.mobjListSize.FindString(this.mobjTextSize.Text);
        if (num1 > -1 && !string.IsNullOrEmpty(this.mobjTextSize.Text))
        {
          this.mblnTextChanged = true;
          this.mobjListSize.SelectedIndex = num1;
          this.mobjListSize.Update();
          this.RefreshFont();
          this.mblnTextChanged = false;
          flag = true;
        }
        else if (!string.IsNullOrEmpty(this.mobjTextSize.Text))
        {
          int result = -1;
          if (int.TryParse(this.mobjTextSize.Text, out result))
          {
            if (result >= this.MinSize && result <= this.MaxSize)
            {
              flag = true;
            }
            else
            {
              if (this.mobjListSize.SelectedItem != null)
                this.mobjTextSize.Text = this.mobjListSize.SelectedItem.ToString();
              if (blnShowValidationMessages)
              {
                int num2 = (int) MessageBox.Show("Size must be between " + (object) this.MinSize + " and " + (object) this.MaxSize + " points.", "Font");
              }
            }
          }
          else if (blnShowValidationMessages)
          {
            int num3 = (int) MessageBox.Show("Size must be a number.", "Font");
          }
        }
        return flag;
      }

      /// <summary>Applies the name of the font.</summary>
      /// <returns></returns>
      private bool ApplyFontName(bool blnShowValidationMessages)
      {
        bool flag = false;
        int num1 = this.mobjListFont.FindString(this.mobjTextFont.Text);
        if (num1 > -1)
        {
          this.mblnTextChanged = true;
          this.mobjListFont.SelectedIndex = num1;
          this.UpdateFontStyles((SerializableFontFamily) this.mobjListFont.SelectedItem, true);
          this.mobjListFont.Update();
          this.RefreshFont();
          this.mblnTextChanged = false;
          flag = true;
        }
        else if (this.FontMustExist)
        {
          if (blnShowValidationMessages)
          {
            int num2 = (int) MessageBox.Show("There is no font with that name. \r\n Choose a font from the list of fonts.", "Font");
          }
        }
        else
          flag = true;
        return flag;
      }

      /// <summary>Validates the font.</summary>
      /// <returns></returns>
      private bool ApplyFont() => this.ApplyFontName(true) && this.ApplyFontSize(true);

      private void mobjListFontStyle_SelectedIndexChanged(object sender, EventArgs e)
      {
        this.mblnListChanging = true;
        if (!this.mblnTextChanged)
        {
          this.mobjTextFontStyle.Text = this.mobjListFontStyle.SelectedItem.ToString();
          this.RefreshFont();
        }
        this.mblnListChanging = false;
      }

      private void mobjListSize_SelectedIndexChanged(object sender, EventArgs e)
      {
        this.mblnListChanging = true;
        if (!this.mblnTextChanged)
        {
          this.mobjTextSize.Text = this.mobjListSize.SelectedItem.ToString();
          this.RefreshFont();
        }
        this.mblnListChanging = false;
      }

      private void mobjListFont_SelectedIndexChanged(object sender, EventArgs e)
      {
        this.mblnListChanging = true;
        if (!this.mblnTextChanged)
        {
          this.mobjTextFont.Text = ((SerializableFontFamily) this.mobjListFont.SelectedItem).Name;
          this.UpdateFontStyles((SerializableFontFamily) this.mobjListFont.SelectedItem, true);
          this.RefreshFont();
        }
        this.mblnListChanging = false;
      }

      private void mobjButtonApply_Click(object sender, EventArgs e) => this.FontDialogOwner.OnApply(EventArgs.Empty);

      private void mobjButtonCancel_Click(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }

      private void mobjButtonOk_Click(object sender, EventArgs e)
      {
        if (!this.ApplyFont())
          return;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }

      private void RefreshFont()
      {
        float fltValue;
        if (this.mblnInitializing || !CommonUtils.TryParse(this.mobjTextSize.Text, out fltValue))
          return;
        FontStyle fontStyle = ((FontDialog.FontDialogForm.FontStyleListItem) this.mobjListFontStyle.SelectedItem).FontStyle;
        if (this.mobjCheckStrikeout.Checked)
          fontStyle |= FontStyle.Strikeout;
        if (this.mobjCheckUnderline.Checked)
          fontStyle |= FontStyle.Underline;
        this.Font = (Font) new SerializableFont((FontFamily) (SerializableFontFamily) this.mobjListFont.SelectedItem, fltValue, fontStyle, GraphicsUnit.Point);
        this.mobjLabelSample.Font = this.Font;
        this.mobjLabelSample.Update();
      }

      /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.FontDialog.Apply"></see> event.</summary>
      /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the data. </param>
      protected virtual void OnApply(EventArgs e)
      {
        EventHandler apply = this.Apply;
        if (apply == null)
          return;
        apply((object) this, e);
      }

      /// <summary>Resets all dialog box options to their default values.</summary>
      /// <filterpriority>1</filterpriority>
      public virtual void Reset()
      {
      }

      /// <summary>Gets the font dialog owner.</summary>
      /// <value>The font dialog owner.</value>
      protected FontDialog FontDialogOwner => (FontDialog) this.CommonDialogOwner;

      /// <summary>Gets or sets a value indicating whether the user can change the character set specified in the Script combo box to display a character set other than the one currently displayed.</summary>
      /// <returns>true if the user can change the character set specified in the Script combo box; otherwise, false. The default value is true.</returns>
      /// <filterpriority>1</filterpriority>
      [DefaultValue(true)]
      [SRCategory("CatBehavior")]
      [SRDescription("FnDallowScriptChangeDescr")]
      public bool AllowScriptChange
      {
        get => this.FontDialogOwner.AllowScriptChange;
        set => this.FontDialogOwner.AllowScriptChange = value;
      }

      /// <summary>Gets or sets a value indicating whether the dialog box allows graphics device interface (GDI) font simulations.</summary>
      /// <returns>true if font simulations are allowed; otherwise, false. The default value is true.</returns>
      /// <filterpriority>1</filterpriority>
      [DefaultValue(true)]
      [SRCategory("CatBehavior")]
      [SRDescription("FnDallowSimulationsDescr")]
      public bool AllowSimulations
      {
        get => this.FontDialogOwner.AllowSimulations;
        set => this.FontDialogOwner.AllowSimulations = value;
      }

      /// <summary>Gets or sets a value indicating whether the dialog box allows vector font selections.</summary>
      /// <returns>true if vector fonts are allowed; otherwise, false. The default value is true.</returns>
      /// <filterpriority>1</filterpriority>
      [SRDescription("FnDallowVectorFontsDescr")]
      [SRCategory("CatBehavior")]
      [DefaultValue(true)]
      public bool AllowVectorFonts
      {
        get => this.FontDialogOwner.AllowVectorFonts;
        set => this.FontDialogOwner.AllowVectorFonts = value;
      }

      /// <summary>Gets or sets a value indicating whether the dialog box displays both vertical and horizontal fonts or only horizontal fonts.</summary>
      /// <returns>true if both vertical and horizontal fonts are allowed; otherwise, false. The default value is true.</returns>
      /// <filterpriority>1</filterpriority>
      [DefaultValue(true)]
      [SRCategory("CatBehavior")]
      [SRDescription("FnDallowVerticalFontsDescr")]
      public bool AllowVerticalFonts
      {
        get => this.FontDialogOwner.AllowVerticalFonts;
        set => this.FontDialogOwner.AllowVerticalFonts = value;
      }

      /// <summary>Gets or sets the selected font color.</summary>
      /// <returns>The color of the selected font. The default value is <see cref="P:System.Drawing.Color.Black"></see>.</returns>
      /// <filterpriority>1</filterpriority>
      [SRCategory("CatData")]
      [DefaultValue(typeof (Color), "Black")]
      [SRDescription("FnDcolorDescr")]
      public Color Color
      {
        get => this.FontDialogOwner.Color;
        set => this.FontDialogOwner.Color = value;
      }

      /// <summary>Gets or sets a value indicating whether the dialog box allows only the selection of fixed-pitch fonts.</summary>
      /// <returns>true if only fixed-pitch fonts can be selected; otherwise, false. The default value is false.</returns>
      /// <filterpriority>1</filterpriority>
      [SRCategory("CatBehavior")]
      [DefaultValue(false)]
      [SRDescription("FnDfixedPitchOnlyDescr")]
      public bool FixedPitchOnly
      {
        get => this.FontDialogOwner.FixedPitchOnly;
        set => this.FontDialogOwner.FixedPitchOnly = value;
      }

      /// <summary>Gets or sets the selected font.</summary>
      /// <returns>The selected font.</returns>
      /// <filterpriority>1</filterpriority>
      [SRDescription("FnDfontDescr")]
      [SRCategory("CatData")]
      public new Font Font
      {
        get => this.FontDialogOwner.Font;
        set => this.FontDialogOwner.Font = value;
      }

      /// <summary>Gets or sets a value indicating whether the dialog box specifies an error condition if the user attempts to select a font or style that does not exist.</summary>
      /// <returns>true if the dialog box specifies an error condition when the user tries to select a font or style that does not exist; otherwise, false. The default is false.</returns>
      /// <filterpriority>1</filterpriority>
      [DefaultValue(false)]
      [SRCategory("CatBehavior")]
      [SRDescription("FnDfontMustExistDescr")]
      public bool FontMustExist
      {
        get => this.FontDialogOwner.FontMustExist;
        set => this.FontDialogOwner.FontMustExist = value;
      }

      /// <summary>Gets or sets the maximum point size a user can select.</summary>
      /// <returns>The maximum point size a user can select. The default is 0.</returns>
      /// <filterpriority>1</filterpriority>
      [SRCategory("CatData")]
      [DefaultValue(0)]
      [SRDescription("FnDmaxSizeDescr")]
      public int MaxSize
      {
        get => this.FontDialogOwner.MaxSize;
        set => this.FontDialogOwner.MaxSize = value;
      }

      /// <summary>Gets or sets the minimum point size a user can select.</summary>
      /// <returns>The minimum point size a user can select. The default is 0.</returns>
      /// <filterpriority>1</filterpriority>
      [SRCategory("CatData")]
      [DefaultValue(0)]
      [SRDescription("FnDminSizeDescr")]
      public int MinSize
      {
        get => this.FontDialogOwner.MinSize;
        set => this.FontDialogOwner.MinSize = value;
      }

      /// <summary>Gets or sets a value indicating whether the dialog box allows selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.</summary>
      /// <returns>true if selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set, is allowed; otherwise, false. The default value is false.</returns>
      /// <filterpriority>1</filterpriority>
      [SRCategory("CatBehavior")]
      [DefaultValue(false)]
      [SRDescription("FnDscriptsOnlyDescr")]
      public bool ScriptsOnly
      {
        get => this.FontDialogOwner.ScriptsOnly;
        set => this.FontDialogOwner.ScriptsOnly = value;
      }

      /// <summary>Gets or sets a value indicating whether the dialog box contains an Apply button.</summary>
      /// <returns>true if the dialog box contains an Apply button; otherwise, false. The default value is false.</returns>
      /// <filterpriority>1</filterpriority>
      [DefaultValue(false)]
      [SRCategory("CatBehavior")]
      [SRDescription("FnDshowApplyDescr")]
      public bool ShowApply
      {
        get => this.FontDialogOwner.ShowApply;
        set
        {
          this.FontDialogOwner.ShowApply = value;
          this.mobjButtonApply.Visible = this.FontDialogOwner.ShowApply;
        }
      }

      /// <summary>Gets or sets a value indicating whether the dialog box displays the color choice.</summary>
      /// <returns>true if the dialog box displays the color choice; otherwise, false. The default value is false.</returns>
      /// <filterpriority>1</filterpriority>
      [DefaultValue(false)]
      [SRDescription("FnDshowColorDescr")]
      [SRCategory("CatBehavior")]
      public bool ShowColor
      {
        get => this.FontDialogOwner.ShowColor;
        set
        {
          this.FontDialogOwner.ShowColor = value;
          this.mobjComboColor.Visible = this.FontDialogOwner.mblnShowColor;
          this.mobjLabelColor.Visible = this.FontDialogOwner.mblnShowColor;
          if (!this.FontDialogOwner.mblnShowColor || this.mobjComboColor.Items.Count != 0)
            return;
          this.mobjComboColor.Items.AddRange((ICollection) this.GetWebColors());
        }
      }

      /// <summary>Gets or sets a value indicating whether the dialog box contains controls that allow the user to specify strikethrough, underline, and text color options.</summary>
      /// <returns>true if the dialog box contains controls to set strikethrough, underline, and text color options; otherwise, false. The default value is true.</returns>
      /// <filterpriority>1</filterpriority>
      [DefaultValue(true)]
      [SRCategory("CatBehavior")]
      [SRDescription("FnDshowEffectsDescr")]
      public bool ShowEffects
      {
        get => this.FontDialogOwner.ShowEffects;
        set
        {
          this.FontDialogOwner.ShowEffects = value;
          this.mobjGroupsEffects.Visible = this.FontDialogOwner.ShowEffects;
        }
      }

      /// <summary>Gets or sets a value indicating whether the dialog box displays a Help button.</summary>
      /// <returns>true if the dialog box displays a Help button; otherwise, false. The default value is false.</returns>
      /// <filterpriority>1</filterpriority>
      [SRCategory("CatBehavior")]
      [DefaultValue(false)]
      [SRDescription("FnDshowHelpDescr")]
      public bool ShowHelp
      {
        get => this.FontDialogOwner.ShowHelp;
        set => this.FontDialogOwner.ShowHelp = value;
      }

      [Serializable]
      private class FontStyleListItem
      {
        private FontStyle menmFontStyle;
        private string mstrText;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FontDialog.FontDialogForm.FontStyleListItem" /> class.
        /// </summary>
        /// <param name="objFontStyle">the font style.</param>
        /// <param name="strText">the font style text.</param>
        public FontStyleListItem(FontStyle objFontStyle, string strText)
        {
          this.menmFontStyle = objFontStyle;
          this.mstrText = strText;
        }

        /// <summary>return font style name</summary>
        /// <returns></returns>
        public override string ToString() => this.mstrText;

        /// <summary>Gets the font style.</summary>
        /// <value>The font style.</value>
        public FontStyle FontStyle => this.menmFontStyle;
      }
    }
  }
}
