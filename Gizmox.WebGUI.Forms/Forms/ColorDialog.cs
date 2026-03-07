// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColorDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a common dialog box that displays available colors along with controls that enable the user to define custom colors.
  /// </summary>
  [DefaultProperty("Color")]
  [SRDescription("DescriptionColorDialog")]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ColorDialog), "ColorDialog_45.bmp")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ColorDialogSkin))]
  [Serializable]
  public class ColorDialog : CommonDialog
  {
    /// <summary>The selected color</summary>
    private Color mobjColor;
    /// <summary>The user custom colors</summary>
    private int[] marrCustomColors = new int[16];
    /// <summary>The dialog bitmap options</summary>
    private int mintOptions;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see> class.</summary>
    public ColorDialog() => this.Reset();

    /// <summary>Resets all options to their default values, the last selected color to black, and the custom colors to their default values.</summary>
    public override void Reset()
    {
      this.mintOptions = 0;
      this.mobjColor = Color.Black;
      this.CustomColors = (int[]) null;
    }

    /// <summary>Resets the selected color</summary>
    private void ResetColor() => this.Color = Color.Black;

    /// <summary>Set internal dialog option</summary>
    /// <param name="intOption"></param>
    /// <param name="blnValue"></param>
    private void SetOption(int intOption, bool blnValue)
    {
      if (blnValue)
        this.mintOptions |= intOption;
      else
        this.mintOptions &= ~intOption;
    }

    /// <summary>Get internal dialog option</summary>
    /// <param name="intOption"></param>
    /// <returns></returns>
    private bool GetOption(int intOption) => (this.mintOptions & intOption) != 0;

    /// <summary>Indicates when the color needs to be serialized</summary>
    /// <returns></returns>
    private bool ShouldSerializeColor() => !this.Color.Equals((object) Color.Black);

    /// <summary>Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</summary>
    /// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>. </returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override string ToString() => base.ToString() + ",  Color: " + this.Color.ToString();

    /// <summary>Create the color dialog form</summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm() => (CommonDialog.CommonDialogForm) new ColorDialog.ColorDialogForm((CommonDialog) this);

    /// <summary>Gets values to initialize the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</summary>
    /// <returns>A bitwise combination of internal values that initializes the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</returns>
    protected virtual int Options => this.mintOptions;

    /// <summary>Gets or sets a value indicating whether the user can use the dialog box to define custom colors.</summary>
    /// <returns>true if the user can define custom colors; otherwise, false. The default is true.</returns>
    /// <filterpriority>2</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("CDallowFullOpenDescr")]
    [DefaultValue(true)]
    public virtual bool AllowFullOpen
    {
      get => !this.GetOption(4);
      set => this.SetOption(4, !value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box displays all available colors in the set of basic colors.</summary>
    /// <returns>true if the dialog box displays all available colors in the set of basic colors; otherwise, false. The default value is false.</returns>
    [DefaultValue(false)]
    [SRDescription("CDanyColorDescr")]
    [SRCategory("CatBehavior")]
    public virtual bool AnyColor
    {
      get => this.GetOption(256);
      set => this.SetOption(256, value);
    }

    /// <summary>Gets or sets the color selected by the user.</summary>
    /// <returns>The color selected by the user. If a color is not selected, the default value is black.</returns>
    [SRCategory("CatData")]
    [SRDescription("CDcolorDescr")]
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

    /// <summary>Gets or sets the set of custom colors shown in the dialog box.</summary>
    /// <returns>A set of custom colors shown by the dialog box. The default value is null.</returns>
    [SRDescription("CDcustomColorsDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int[] CustomColors
    {
      get => (int[]) this.marrCustomColors.Clone();
      set
      {
        int length = value == null ? 0 : Math.Min(value.Length, 16);
        if (length > 0)
          Array.Copy((Array) value, 0, (Array) this.marrCustomColors, 0, length);
        for (int index = length; index < 16; ++index)
          this.marrCustomColors[index] = 16777215;
      }
    }

    /// <summary>Gets or sets a value indicating whether the controls used to create custom colors are visible when the dialog box is opened </summary>
    /// <returns>true if the custom color controls are available when the dialog box is opened; otherwise, false. The default value is false.</returns>
    /// <filterpriority>2</filterpriority>
    [DefaultValue(false)]
    [SRDescription("CDfullOpenDescr")]
    [SRCategory("CatAppearance")]
    public virtual bool FullOpen
    {
      get => this.GetOption(2);
      set => this.SetOption(2, value);
    }

    /// <summary>Gets or sets a value indicating whether a Help button appears in the color dialog box.</summary>
    /// <returns>true if the Help button is shown in the dialog box; otherwise, false. The default value is false.</returns>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("CDshowHelpDescr")]
    public virtual bool ShowHelp
    {
      get => this.GetOption(8);
      set => this.SetOption(8, value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box will restrict users to selecting solid colors only.</summary>
    /// <returns>true if users can select only solid colors; otherwise, false. The default value is false.</returns>
    [DefaultValue(false)]
    [SRDescription("CDsolidColorOnlyDescr")]
    [SRCategory("CatBehavior")]
    public virtual bool SolidColorOnly
    {
      get => this.GetOption(128);
      set => this.SetOption(128, value);
    }

    /// <summary>
    /// 
    /// </summary>
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ColorDialogSkin))]
    [Serializable]
    protected class ColorDialogForm : CommonDialog.CommonDialogForm
    {
      private CommonDialog.HtmlBoxHost mobjHtmlBoxHost;
      private Color mobjColor;
      private Button mobjDefineCustomColorsButton;
      private Button mobjCancelButton;
      private Button mobjOkButton;
      private Button mobjAddToCustomColors;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objCommonDialog"></param>
      public ColorDialogForm(CommonDialog objCommonDialog)
        : base(objCommonDialog)
      {
        this.InitializeComponent();
        if (!(objCommonDialog is ColorDialog colorDialog))
          return;
        this.mobjColor = colorDialog.Color;
      }

      /// <summary>
      /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
      /// </summary>
      /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
      protected override void OnLoad(EventArgs e)
      {
        base.OnLoad(e);
        this.mobjHtmlBoxHost.SetProperty("VLB", CommonUtils.GetRGBColor(this.ColorDialogOwner.Color));
        if (this.ColorDialogOwner == null)
          return;
        int[] customColors = this.ColorDialogOwner.CustomColors;
        if (customColors != null)
        {
          string strValue = string.Empty;
          string str = string.Empty;
          foreach (int win32Color in customColors)
          {
            strValue = strValue + str + CommonUtils.GetWebColor(ColorTranslator.FromWin32(win32Color));
            str = ",";
          }
          if (!string.IsNullOrEmpty(strValue))
            this.mobjHtmlBoxHost.SetProperty("CCS", strValue);
        }
        if (!this.ColorDialogOwner.FullOpen)
          return;
        this.SetFullOpen(false);
      }

      /// <summary>
      /// Raises the <see cref="E:Closed" /> event.
      /// </summary>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      protected override void OnClosed(EventArgs e)
      {
        base.OnClosed(e);
        this.ColorDialogOwner.FullOpen = false;
        this.mobjHtmlBoxHost.SetProperty("OpenFull", "0");
      }

      /// <summary>Gets the color dialog owner.</summary>
      /// <value>The color dialog owner.</value>
      public ColorDialog ColorDialogOwner => (ColorDialog) this.CommonDialogOwner;

      private void InitializeComponent()
      {
        this.mobjHtmlBoxHost = new CommonDialog.HtmlBoxHost();
        this.mobjOkButton = new Button();
        this.mobjCancelButton = new Button();
        this.mobjDefineCustomColorsButton = new Button();
        this.mobjAddToCustomColors = new Button();
        this.SuspendLayout();
        this.mobjHtmlBoxHost.Dock = DockStyle.Fill;
        this.mobjHtmlBoxHost.Url = this.Skin.GetResourcePath("ColorDialog.htm");
        this.mobjHtmlBoxHost.EventRaised += new CommonDialog.EventRaisedHander(this.HtmlBoxHost_EventRaised);
        this.mobjOkButton.Text = WGLabels.Ok;
        this.mobjOkButton.Location = new Point(10, 306);
        this.mobjOkButton.Click += new EventHandler(this.btnOk_Click);
        this.mobjCancelButton.Text = WGLabels.Cancel;
        this.mobjCancelButton.Location = new Point(this.mobjOkButton.Left + this.mobjOkButton.Width + 10, this.mobjOkButton.Location.Y);
        this.mobjCancelButton.Click += new EventHandler(this.btnCancel_Click);
        this.mobjDefineCustomColorsButton.Text = WGLabels.GetString("DefineCustomColors", Global.Context, true);
        this.mobjDefineCustomColorsButton.Width = 160;
        this.mobjDefineCustomColorsButton.Location = new Point(this.mobjOkButton.Left, this.mobjOkButton.Top - 10 - this.mobjDefineCustomColorsButton.Height);
        this.mobjDefineCustomColorsButton.Click += new EventHandler(this.btnDefineCustomColors_Click);
        this.mobjDefineCustomColorsButton.Enabled = this.ColorDialogOwner.AllowFullOpen;
        this.mobjAddToCustomColors.Text = WGLabels.GetString("AddToCustomColors", Global.Context, true);
        this.mobjAddToCustomColors.Width = 135;
        this.mobjAddToCustomColors.Location = new Point(237, this.mobjOkButton.Top);
        this.mobjAddToCustomColors.Click += new EventHandler(this.mobjDefineCustomColorsButton_Click);
        this.mobjAddToCustomColors.Visible = false;
        this.Controls.Add((Control) this.mobjHtmlBoxHost);
        this.Controls.Add((Control) this.mobjOkButton);
        this.Controls.Add((Control) this.mobjCancelButton);
        this.Controls.Add((Control) this.mobjDefineCustomColorsButton);
        this.Controls.Add((Control) this.mobjAddToCustomColors);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Size = new Size(218, 336);
        this.ResumeLayout(false);
      }

      /// <summary>
      /// Handles the Click event of the mobjDefineCustomColorsButton control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void mobjDefineCustomColorsButton_Click(object sender, EventArgs e) => this.mobjHtmlBoxHost.InvokeExecuter((object) "AddColorToCustomColors");

      /// <summary>
      /// Handles the Click event of the btnDefineCustomColors control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void btnDefineCustomColors_Click(object sender, EventArgs e)
      {
        this.ColorDialogOwner.FullOpen = true;
        this.mobjHtmlBoxHost.SetProperty("OpenFull", "1");
        this.SetFullOpen(true);
      }

      /// <summary>Sets the full open mode.</summary>
      private void SetFullOpen(bool blnSendClientInvocation)
      {
        this.Width = 463;
        this.mobjDefineCustomColorsButton.Enabled = false;
        this.mobjAddToCustomColors.Visible = true;
        if (!blnSendClientInvocation)
          return;
        this.mobjHtmlBoxHost.InvokeExecuter((object) "EditCustomColors");
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }

      private void btnOk_Click(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.OK;
        this.ColorDialogOwner.Color = this.mobjColor;
        this.Close();
      }

      private void HtmlBoxHost_EventRaised(IEvent objEvent)
      {
        if (!(objEvent.Type == "ValueChange"))
          return;
        string str1 = objEvent["CO"];
        if (!CommonUtils.IsNullOrEmpty(str1))
          this.mobjColor = ColorTranslator.FromHtml("#" + str1);
        string str2 = objEvent["CCS"];
        if (CommonUtils.IsNullOrEmpty(str2) || this.ColorDialogOwner == null)
          return;
        string[] strArray = str2.Split(',');
        int[] numArray = new int[strArray.Length];
        for (int index = 0; index < strArray.Length; ++index)
        {
          string htmlColor = strArray[index];
          if (!htmlColor.StartsWith("#"))
            htmlColor = string.Format("#{0}", (object) htmlColor);
          numArray[index] = ColorTranslator.ToWin32(ColorTranslator.FromHtml(htmlColor));
        }
        this.ColorDialogOwner.CustomColors = numArray;
      }
    }
  }
}
