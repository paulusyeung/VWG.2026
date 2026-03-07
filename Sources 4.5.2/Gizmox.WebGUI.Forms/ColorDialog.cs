using System;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Represents a common dialog box that displays available colors along with controls that enable the user to define custom colors.
    /// </summary>
    [DefaultProperty("Color"), SRDescription("DescriptionColorDialog"), ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(ColorDialog), "ColorDialog_45.bmp")]
#else
    [ToolboxBitmap(typeof(ColorDialog), "ColorDialog.bmp")]
#endif
    [Skin(typeof(ColorDialogSkin))]
    [Serializable()]
    public class ColorDialog : CommonDialog
    {

        #region Classes

        #region ColorDialogForm Class

        /// <summary>
        /// 
        /// </summary>
        [Skin(typeof(ColorDialogSkin)), Serializable()]
        protected class ColorDialogForm : CommonDialogForm
        {

            #region C'Tor

            /// <summary>
            /// 
            /// </summary>
            /// <param name="objCommonDialog"></param>
            public ColorDialogForm(CommonDialog objCommonDialog)
                : base(objCommonDialog)
            {
                InitializeComponent();

                ColorDialog objColorDialog = objCommonDialog as ColorDialog;
                if (objColorDialog != null)
                {
                    this.mobjColor = objColorDialog.Color;
                }
            }

            #endregion

            private HtmlBoxHost mobjHtmlBoxHost;
            private Color mobjColor;
            private Button mobjDefineCustomColorsButton;
            private Button mobjCancelButton;
            private Button mobjOkButton;
            private Button mobjAddToCustomColors;

            /// <summary>
            /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
            /// </summary>
            /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                mobjHtmlBoxHost.SetProperty(WGAttributes.Value, CommonUtils.GetRGBColor(ColorDialogOwner.Color));
                
                if (this.ColorDialogOwner != null)
                {
                    int[] arrCustomColors = this.ColorDialogOwner.CustomColors;
                    if (arrCustomColors != null)
                    {
                        string strColors = string.Empty;
                        string strSeperator = string.Empty;

                        foreach (int intColor in arrCustomColors)
                        {
                            strColors += strSeperator + CommonUtils.GetWebColor(ColorTranslator.FromWin32(intColor));
                            strSeperator = ",";
                        }

                        if (!string.IsNullOrEmpty(strColors))
                        {
                            mobjHtmlBoxHost.SetProperty(WGAttributes.CustomColors, strColors);
                        }
                    }

                    // Check if FullOpen
                    if (this.ColorDialogOwner.FullOpen)
                    {
                        SetFullOpen(false);
                    }
                }
            }

            /// <summary>
            /// Raises the <see cref="E:Closed"/> event.
            /// </summary>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);

                ColorDialogOwner.FullOpen = false;
                mobjHtmlBoxHost.SetProperty("OpenFull", "0");
            }

            /// <summary>
            /// Gets the color dialog owner.
            /// </summary>
            /// <value>The color dialog owner.</value>
            public ColorDialog ColorDialogOwner
            {
                get
                {
                    return (ColorDialog)this.CommonDialogOwner;
                }
            }
            private void InitializeComponent()
            {
                mobjHtmlBoxHost = new HtmlBoxHost();
                mobjOkButton = new Button();
                mobjCancelButton = new Button();
                mobjDefineCustomColorsButton = new Button();
                mobjAddToCustomColors = new Button();

                this.SuspendLayout();

                mobjHtmlBoxHost.Dock = DockStyle.Fill;
                mobjHtmlBoxHost.Url = this.Skin.GetResourcePath("ColorDialog.htm");
                mobjHtmlBoxHost.EventRaised += new EventRaisedHander(HtmlBoxHost_EventRaised);

                mobjOkButton.Text = WGLabels.Ok;
                mobjOkButton.Location = new Point(10, 306);
                mobjOkButton.Click += new EventHandler(btnOk_Click);

                mobjCancelButton.Text = WGLabels.Cancel;
                mobjCancelButton.Location = new Point(mobjOkButton.Left + mobjOkButton.Width + 10, mobjOkButton.Location.Y);
                mobjCancelButton.Click += new EventHandler(btnCancel_Click);

                mobjDefineCustomColorsButton.Text = WGLabels.GetString("DefineCustomColors", WebGUI.Common.Global.Context, true);
                mobjDefineCustomColorsButton.Width = 160;
                mobjDefineCustomColorsButton.Location = new Point(mobjOkButton.Left, mobjOkButton.Top - 10 - mobjDefineCustomColorsButton.Height);
                mobjDefineCustomColorsButton.Click += new EventHandler(btnDefineCustomColors_Click);
                mobjDefineCustomColorsButton.Enabled = ColorDialogOwner.AllowFullOpen;

                mobjAddToCustomColors.Text = WGLabels.GetString("AddToCustomColors", WebGUI.Common.Global.Context, true);
                mobjAddToCustomColors.Width = 135;
                mobjAddToCustomColors.Location = new Point(237, mobjOkButton.Top);
                mobjAddToCustomColors.Click += new EventHandler(mobjDefineCustomColorsButton_Click);
                mobjAddToCustomColors.Visible = false;

                this.Controls.Add(mobjHtmlBoxHost);
                this.Controls.Add(mobjOkButton);
                this.Controls.Add(mobjCancelButton);
                this.Controls.Add(mobjDefineCustomColorsButton);
                this.Controls.Add(mobjAddToCustomColors);

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
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            void mobjDefineCustomColorsButton_Click(object sender, EventArgs e)
            {
                mobjHtmlBoxHost.InvokeExecuter("AddColorToCustomColors");
            }

            /// <summary>
            /// Handles the Click event of the btnDefineCustomColors control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            void btnDefineCustomColors_Click(object sender, EventArgs e)
            {
                ColorDialogOwner.FullOpen = true;
                mobjHtmlBoxHost.SetProperty("OpenFull", "1");

                SetFullOpen(true);
            }

            /// <summary>
            /// Sets the full open mode.
            /// </summary>
            private void SetFullOpen(bool blnSendClientInvocation)
            {
                this.Width = 463;
                mobjDefineCustomColorsButton.Enabled = false;
                mobjAddToCustomColors.Visible = true;

                if (blnSendClientInvocation)
                {
                    mobjHtmlBoxHost.InvokeExecuter("EditCustomColors");
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            private void btnOk_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK;
                ColorDialogOwner.Color = this.mobjColor;
                this.Close();
            }

            void HtmlBoxHost_EventRaised(IEvent objEvent)
            {
                switch (objEvent.Type)
                {

                    case "ValueChange":
                        string strNewColor = objEvent[WGAttributes.Color];
                        if (!CommonUtils.IsNullOrEmpty(strNewColor))
                        {
                            this.mobjColor = ColorTranslator.FromHtml("#" + strNewColor);
                        }

                        string strNewCustomColors = objEvent[WGAttributes.CustomColors];
                        if (!CommonUtils.IsNullOrEmpty(strNewCustomColors))
                        {
                            if (this.ColorDialogOwner != null)
                            {
                                string[] arrCustomColorsInHEX = strNewCustomColors.Split(',');
                                int[] arrCustomColors = new int[arrCustomColorsInHEX.Length];

                                for (int intColorIndex = 0; intColorIndex < arrCustomColorsInHEX.Length; intColorIndex++)
                                {
                                    string strHtmlColor = arrCustomColorsInHEX[intColorIndex];
                                    if (!strHtmlColor.StartsWith("#"))
                                    {
                                        strHtmlColor = string.Format("#{0}", strHtmlColor);
                                    }
                                    arrCustomColors[intColorIndex] = ColorTranslator.ToWin32(ColorTranslator.FromHtml(strHtmlColor));
                                }

                                this.ColorDialogOwner.CustomColors = arrCustomColors;
                            }
                        }
                        break;
                }
            }

        }

        #endregion

        #endregion

        #region Members

        /// <summary>
        /// The selected color
        /// </summary>
        private Color mobjColor;

        /// <summary>
        /// The user custom colors
        /// </summary>
        private int[] marrCustomColors = new int[0x10];

        /// <summary>
        /// The dialog bitmap options
        /// </summary>
        private int mintOptions;

        #endregion

        #region C'Tor

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see> class.</summary>
        public ColorDialog()
        {
            this.Reset();
        }

        #endregion

        #region Methods

        /// <summary>Resets all options to their default values, the last selected color to black, and the custom colors to their default values.</summary>
        public override void Reset()
        {
            this.mintOptions = 0;
            this.mobjColor = Color.Black;
            this.CustomColors = null;

        }

        /// <summary>
        /// Resets the selected color
        /// </summary>
        private void ResetColor()
        {
            this.Color = Color.Black;
        }

        /// <summary>
        /// Set internal dialog option
        /// </summary>
        /// <param name="intOption"></param>
        /// <param name="blnValue"></param>
        private void SetOption(int intOption, bool blnValue)
        {
            if (blnValue)
            {
                this.mintOptions |= intOption;
            }
            else
            {
                this.mintOptions &= ~intOption;
            }
        }

        /// <summary>
        /// Get internal dialog option
        /// </summary>
        /// <param name="intOption"></param>
        /// <returns></returns>
        private bool GetOption(int intOption)
        {
            return ((this.mintOptions & intOption) != 0);
        }

        /// <summary>
        /// Indicates when the color needs to be serialized
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeColor()
        {
            return !this.Color.Equals(Color.Black);
        }

        /// <summary>Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</summary>
        /// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>. </returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override string ToString()
        {
            return (base.ToString() + ",  Color: " + this.Color.ToString());
        }

        /// <summary>
        /// Create the color dialog form
        /// </summary>
        /// <returns></returns>
        protected override CommonDialogForm CreateForm()
        {
            return new ColorDialogForm(this);
        }



        #endregion

        /// <summary>Gets values to initialize the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</summary>
        /// <returns>A bitwise combination of internal values that initializes the <see cref="T:Gizmox.WebGUI.Forms.ColorDialog"></see>.</returns>
        protected virtual int Options
        {
            get
            {
                return this.mintOptions;
            }
        }


        /// <summary>Gets or sets a value indicating whether the user can use the dialog box to define custom colors.</summary>
        /// <returns>true if the user can define custom colors; otherwise, false. The default is true.</returns>
        /// <filterpriority>2</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("CDallowFullOpenDescr"), DefaultValue(true)]
        public virtual bool AllowFullOpen
        {
            get
            {
                return !this.GetOption(4);
            }
            set
            {
                this.SetOption(4, !value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box displays all available colors in the set of basic colors.</summary>
        /// <returns>true if the dialog box displays all available colors in the set of basic colors; otherwise, false. The default value is false.</returns>
        [DefaultValue(false), SRDescription("CDanyColorDescr"), SRCategory("CatBehavior")]
        public virtual bool AnyColor
        {
            get
            {
                return this.GetOption(0x100);
            }
            set
            {
                this.SetOption(0x100, value);
            }
        }

        /// <summary>Gets or sets the color selected by the user.</summary>
        /// <returns>The color selected by the user. If a color is not selected, the default value is black.</returns>
        [SRCategory("CatData"), SRDescription("CDcolorDescr")]
        public Color Color
        {
            get
            {
                return this.mobjColor;
            }
            set
            {
                if (!value.IsEmpty)
                {
                    this.mobjColor = value;
                }
                else
                {
                    this.mobjColor = Color.Black;
                }
            }
        }

        /// <summary>Gets or sets the set of custom colors shown in the dialog box.</summary>
        /// <returns>A set of custom colors shown by the dialog box. The default value is null.</returns>

        [SRDescription("CDcustomColorsDescr"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[] CustomColors
        {
            get
            {
                return (int[])this.marrCustomColors.Clone();
            }
            set
            {
                int intLength = (value == null) ? 0 : Math.Min(value.Length, 0x10);
                if (intLength > 0)
                {
                    Array.Copy(value, 0, this.marrCustomColors, 0, intLength);
                }
                for (int i = intLength; i < 0x10; i++)
                {
                    this.marrCustomColors[i] = 0xffffff;
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the controls used to create custom colors are visible when the dialog box is opened </summary>
        /// <returns>true if the custom color controls are available when the dialog box is opened; otherwise, false. The default value is false.</returns>
        /// <filterpriority>2</filterpriority>
        [DefaultValue(false), SRDescription("CDfullOpenDescr"), SRCategory("CatAppearance")]
        public virtual bool FullOpen
        {
            get
            {
                return this.GetOption(2);
            }
            set
            {
                this.SetOption(2, value);
            }
        }


        /// <summary>Gets or sets a value indicating whether a Help button appears in the color dialog box.</summary>
        /// <returns>true if the Help button is shown in the dialog box; otherwise, false. The default value is false.</returns>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("CDshowHelpDescr")]
        public virtual bool ShowHelp
        {
            get
            {
                return this.GetOption(8);
            }
            set
            {
                this.SetOption(8, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box will restrict users to selecting solid colors only.</summary>
        /// <returns>true if users can select only solid colors; otherwise, false. The default value is false.</returns>
        [DefaultValue(false), SRDescription("CDsolidColorOnlyDescr"), SRCategory("CatBehavior")]
        public virtual bool SolidColorOnly
        {
            get
            {
                return this.GetOption(0x80);
            }
            set
            {
                this.SetOption(0x80, value);
            }

        }
    }
}