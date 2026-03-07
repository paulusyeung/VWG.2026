using System;
using System.Globalization;
using System.Collections;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using Gizmox.WebGUI.Forms.Serialization;

namespace Gizmox.WebGUI.Forms
{

    /// <summary>Prompts the user to choose a font from among those installed on the local computer.</summary>
    /// <filterpriority>2</filterpriority>
    [SRDescription("DescriptionFontDialog"), DefaultEvent("Apply"), DefaultProperty("Font")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(FontDialog), "FontDialog_45.bmp")]
#else
    [ToolboxBitmap(typeof(FontDialog), "FontDialog.bmp")]
#endif
    [ToolboxItem(true), Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.FontDialogSkin)), Serializable()]
    public class FontDialog : CommonDialog
    {
        #region Classes

        /// <summary>
        /// Implements the font dialog form
        /// </summary>

        [Serializable()]
        protected class FontDialogForm : CommonDialogForm
        {
            #region Members

            /// <summary>Occurs when the user clicks the Apply button in the font dialog box.</summary>
            /// <filterpriority>1</filterpriority>
            [SRDescription("FnDapplyDescr")]
            public event EventHandler Apply;

            private bool mblnTextChanged = false;
            private bool mblnListChanging = false;
            private bool mblnInitializing = false;
            private bool mblnInitialized = false;


            private Gizmox.WebGUI.Forms.Button mobjButtonOk;
            private Gizmox.WebGUI.Forms.Button mobjButtonCancel;
            private Gizmox.WebGUI.Forms.Button mobjButtonApply;
            private Gizmox.WebGUI.Forms.GroupBox mobjGroupsEffects;
            private Gizmox.WebGUI.Forms.CheckBox mobjCheckStrikeout;
            private Gizmox.WebGUI.Forms.CheckBox mobjCheckUnderline;
            private Gizmox.WebGUI.Forms.GroupBox mobjGroupSample;
            private Gizmox.WebGUI.Forms.Label mobjLabelSample;
            private Gizmox.WebGUI.Forms.Label mobjLabelScrpt;
            private Gizmox.WebGUI.Forms.Label mobjLabelColor;
            private Gizmox.WebGUI.Forms.ComboBox mobjComboScript;
            private Gizmox.WebGUI.Forms.ColorComboBox mobjComboColor;
            private Gizmox.WebGUI.Forms.ListBox mobjListFont;
            private Gizmox.WebGUI.Forms.ListBox mobjListFontStyle;
            private Gizmox.WebGUI.Forms.ListBox mobjListSize;
            private Gizmox.WebGUI.Forms.TextBox mobjTextFont;
            private Gizmox.WebGUI.Forms.TextBox mobjTextFontStyle;
            private Gizmox.WebGUI.Forms.TextBox mobjTextSize;
            private Gizmox.WebGUI.Forms.Label mobjLabelFont;
            private Gizmox.WebGUI.Forms.Label mobjLabelFontStyle;
            private Gizmox.WebGUI.Forms.Label mobjLabelSize;

            #endregion

            #region C'Tors

            /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see> class.</summary>
            public FontDialogForm(FontDialog objFontDialog)
                : base(objFontDialog)
            {
                InitializeComponent();
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

                this.Load += new EventHandler(FontDialog_Load);
            }

            #endregion

            #region Methods

            private void UpdateFromFont()
            {
                if (this.Font != null)
                {
                    this.mobjTextFont.Text = this.Font.FontFamily.Name;
                    this.mobjTextFontStyle.Text = this.Font.Style.ToString();
                    this.mobjTextSize.Text = this.Font.Size.ToString();
                    this.mobjCheckStrikeout.Checked = this.Font.Strikeout;
                    this.mobjCheckUnderline.Checked = this.Font.Underline;
                }
            }

            /// <summary>
            /// Gets the web colors.
            /// </summary>
            /// <returns></returns>
            protected virtual Color[] GetWebColors()
            {
                return GetConstants(typeof(Color));
            }

            /// <summary>
            /// Gets the constants.
            /// </summary>
            /// <param name="objEnumType">Type of the enum.</param>
            /// <returns></returns>
            private Color[] GetConstants(Type objEnumType)
            {
                MethodAttributes objMethodAttributes = MethodAttributes.Static | MethodAttributes.Public;
                PropertyInfo[] arrPropertyInfos = objEnumType.GetProperties();
                ArrayList objArrayList = new ArrayList();
                for (int i = 0; i < arrPropertyInfos.Length; i++)
                {
                    PropertyInfo objPropertyInfo = arrPropertyInfos[i];
                    if (objPropertyInfo.PropertyType == typeof(Color))
                    {
                        MethodInfo objMethodInfo = objPropertyInfo.GetGetMethod();
                        if ((objMethodInfo != null) && ((objMethodInfo.Attributes & objMethodAttributes) == objMethodAttributes))
                        {
                            object[] arrObjects = null;
                            objArrayList.Add(objPropertyInfo.GetValue(null, arrObjects));
                        }
                    }
                }
                return (Color[])objArrayList.ToArray(typeof(Color));
            }

            private void FontDialog_Load(object sender, EventArgs e)
            {
                int intSize = 0;
                mblnInitializing = true;

                int[] arrIntaSize = new int[] { 8, 9, 10, 11, 12, 13, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

                mobjListFont.DataSource = SerializableFontFamily.Families;

                mobjListFont.DisplayMember = "Name";
                mobjListFont.ValueMember = "Name";

                if (this.Font == null)
                {
                    this.Font = new Font("Arial", 10);
                }

                //Support Min and Max size
                for (int i = 0; i < arrIntaSize.Length; i++)
                {
                    intSize = (int)arrIntaSize.GetValue(i);
                    if (intSize >= MinSize && intSize <= MaxSize)
                    {
                        mobjListSize.Items.Add(intSize);
                    }
                }

                //If the selected size is not exist in the min max size renge
                //Set the size as the max range;
                if (mobjListSize.Items.Count < 1)
                {
                    mobjTextSize.Text = MaxSize.ToString();
                }

                mobjLabelSample.Font = this.Font;
                mobjLabelSample.ForeColor = this.Color;

                //Set the selected color in the combo
                if (FontDialogOwner.ShowColor)
                {
                    mobjComboColor.SelectedItem = this.Color;
                }

                int intIndex = mobjListSize.FindString(Math.Round(this.Font.Size).ToString());
                intIndex = intIndex == -1 ? 0 : intIndex;
                mobjListSize.SelectedIndex = intIndex;

                intIndex = mobjListFont.FindString(this.Font.FontFamily.Name.ToString());
                intIndex = intIndex == -1 ? 0 : intIndex;
                mobjListFont.SelectedIndex = intIndex;

                this.mobjCheckStrikeout.Checked = this.Font.Strikeout;
                this.mobjCheckUnderline.Checked = this.Font.Underline;

                mblnInitializing = false;

                UpdateFontStyles((SerializableFontFamily)this.Font.FontFamily, false);

                if (this.Font.Bold && this.Font.Italic)
                {
                    intIndex = mobjListFontStyle.FindString(WGLabels.BoldItalic);
                    intIndex = intIndex == -1 ? 0 : intIndex;
                    mobjListFontStyle.SelectedIndex = intIndex;
                }
                else if (this.Font.Bold)
                {
                    intIndex = mobjListFontStyle.FindString(WGLabels.Bold);
                    intIndex = intIndex == -1 ? 0 : intIndex;
                    mobjListFontStyle.SelectedIndex = intIndex;
                }
                else if (this.Font.Italic)
                {
                    intIndex = mobjListFontStyle.FindString(WGLabels.Italic);
                    intIndex = intIndex == -1 ? 0 : intIndex;
                    mobjListFontStyle.SelectedIndex = intIndex;
                }
                else
                {
                    intIndex = mobjListFontStyle.FindString(WGLabels.Regular);
                    intIndex = intIndex == -1 ? 0 : intIndex;
                    mobjListFontStyle.SelectedIndex = intIndex;
                }



                mblnInitialized = true;

                //UpdateFromFont();
            }

            private void InitializeComponent()
            {
                this.mobjButtonOk = new Gizmox.WebGUI.Forms.Button();
                this.mobjButtonCancel = new Gizmox.WebGUI.Forms.Button();
                this.mobjButtonApply = new Gizmox.WebGUI.Forms.Button();
                this.mobjGroupsEffects = new Gizmox.WebGUI.Forms.GroupBox();
                this.mobjCheckStrikeout = new Gizmox.WebGUI.Forms.CheckBox();
                this.mobjCheckUnderline = new Gizmox.WebGUI.Forms.CheckBox();
                this.mobjGroupSample = new Gizmox.WebGUI.Forms.GroupBox();
                this.mobjLabelSample = new Gizmox.WebGUI.Forms.Label();
                this.mobjLabelScrpt = new Gizmox.WebGUI.Forms.Label();
                this.mobjLabelColor = new Gizmox.WebGUI.Forms.Label();
                this.mobjComboScript = new Gizmox.WebGUI.Forms.ComboBox();
                this.mobjComboColor = new Gizmox.WebGUI.Forms.ColorComboBox();
                this.mobjListFont = new Gizmox.WebGUI.Forms.ListBox();
                this.mobjListFontStyle = new Gizmox.WebGUI.Forms.ListBox();
                this.mobjListSize = new Gizmox.WebGUI.Forms.ListBox();
                this.mobjTextFont = new Gizmox.WebGUI.Forms.TextBox();
                this.mobjTextFontStyle = new Gizmox.WebGUI.Forms.TextBox();
                this.mobjTextSize = new Gizmox.WebGUI.Forms.TextBox();
                this.mobjLabelFont = new Gizmox.WebGUI.Forms.Label();
                this.mobjLabelFontStyle = new Gizmox.WebGUI.Forms.Label();
                this.mobjLabelSize = new Gizmox.WebGUI.Forms.Label();
                this.mobjGroupsEffects.SuspendLayout();
                this.mobjGroupSample.SuspendLayout();
                this.SuspendLayout();
                // 
                // mobjButtonOk
                // 
                this.mobjButtonOk.Location = new System.Drawing.Point(351, 27);
                this.mobjButtonOk.Name = "mobjButtonOk";
                this.mobjButtonOk.Size = new System.Drawing.Size(62, 23);
                this.mobjButtonOk.TabIndex = 0;
                this.mobjButtonOk.Text = WGLabels.Ok;
                this.mobjButtonOk.Click += new EventHandler(mobjButtonOk_Click);

                // 
                // mobjButtonCancel
                // 
                this.mobjButtonCancel.Location = new System.Drawing.Point(351, 52);
                this.mobjButtonCancel.Name = "mobjButtonCancel";
                this.mobjButtonCancel.Size = new System.Drawing.Size(62, 23);
                this.mobjButtonCancel.TabIndex = 1;
                this.mobjButtonCancel.Text = WGLabels.Cancel;
                this.mobjButtonCancel.Click += new EventHandler(mobjButtonCancel_Click);

                // 
                // mobjButtonApply
                // 
                this.mobjButtonApply.Location = new System.Drawing.Point(351, 77);
                this.mobjButtonApply.Name = "mobjButtonApply";
                this.mobjButtonApply.Size = new System.Drawing.Size(62, 23);
                this.mobjButtonApply.TabIndex = 1;
                this.mobjButtonApply.Text = WGLabels.Apply;
                this.mobjButtonApply.Click += new EventHandler(mobjButtonApply_Click);

                // 
                // mobjGroupsEffects
                // 
                this.mobjGroupsEffects.Controls.Add(this.mobjCheckUnderline);
                this.mobjGroupsEffects.Controls.Add(this.mobjCheckStrikeout);
                this.mobjGroupsEffects.Controls.Add(this.mobjLabelColor);
                this.mobjGroupsEffects.Controls.Add(this.mobjComboColor);
                this.mobjGroupsEffects.Location = new System.Drawing.Point(12, 158);
                this.mobjGroupsEffects.Name = "mobjGroupsEffects";
                this.mobjGroupsEffects.Size = new System.Drawing.Size(146, 120);
                this.mobjGroupsEffects.TabIndex = 2;
                this.mobjGroupsEffects.TabStop = false;
                this.mobjGroupsEffects.Text = WGLabels.Effects;
                // 
                // mobjCheckStrikeout
                // 

                this.mobjCheckStrikeout.Location = new System.Drawing.Point(7, 20);
                this.mobjCheckStrikeout.Name = "mobjCheckStrikeout";
                this.mobjCheckStrikeout.Size = new System.Drawing.Size(80, 17);
                this.mobjCheckStrikeout.TabIndex = 0;
                this.mobjCheckStrikeout.Text = WGLabels.Strikeout;
                this.mobjCheckStrikeout.CheckedChanged += new EventHandler(mobjCheckStrikeout_CheckedChanged);

                // 
                // mobjCheckUnderline
                // 

                this.mobjCheckUnderline.Location = new System.Drawing.Point(7, 40);
                this.mobjCheckUnderline.Name = "mobjCheckUnderline";
                this.mobjCheckUnderline.Size = new System.Drawing.Size(80, 17);
                this.mobjCheckUnderline.TabIndex = 1;
                this.mobjCheckUnderline.Text = WGLabels.Underline;
                this.mobjCheckUnderline.CheckedChanged += new EventHandler(mobjCheckUnderline_CheckedChanged);
                // 
                // mobjLabelColor
                // 
                this.mobjLabelColor.AutoSize = true;
                this.mobjLabelColor.Location = new System.Drawing.Point(7, 60);
                this.mobjLabelColor.Name = "mobjLabelScrpt";
                this.mobjLabelColor.Size = new System.Drawing.Size(71, 21);
                this.mobjLabelColor.TabIndex = 4;
                this.mobjLabelColor.Text = WGLabels.Color;
                this.mobjLabelColor.Visible = false;
                // 
                // mobjComboColor
                // 
                this.mobjComboColor.FormattingEnabled = true;
                this.mobjComboColor.Location = new System.Drawing.Point(7, 75);
                this.mobjComboColor.Name = "mobjComboColor";
                this.mobjComboColor.Size = new System.Drawing.Size(125, 21);
                this.mobjComboColor.TabIndex = 2;
                this.mobjComboColor.Visible = false;
                this.mobjComboColor.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
                this.mobjComboColor.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
                this.mobjComboColor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.mobjComboColor.SelectedValueChanged += new EventHandler(mobjComboColor_SelectedValueChanged);

                // 
                // mobjGroupSample
                // 
                this.mobjGroupSample.Controls.Add(this.mobjLabelSample);
                this.mobjGroupSample.Location = new System.Drawing.Point(164, 158);
                this.mobjGroupSample.Name = "mobjGroupSample";
                this.mobjGroupSample.Size = new System.Drawing.Size(176, 70);
                this.mobjGroupSample.TabIndex = 3;
                this.mobjGroupSample.TabStop = false;
                this.mobjGroupSample.Text = WGLabels.Sample;
                // 
                // mobjLabelSample
                // 
                this.mobjLabelSample.Location = new System.Drawing.Point(15, 21);
                this.mobjLabelSample.Name = "mobjLabelSample";
                this.mobjLabelSample.Size = new System.Drawing.Size(144, 42);
                this.mobjLabelSample.TabIndex = 0;
                this.mobjLabelSample.Text = "AaBbðñùú";
                this.mobjLabelSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // mobjLabelScrpt
                // 
                this.mobjLabelScrpt.AutoSize = true;
                this.mobjLabelScrpt.Location = new System.Drawing.Point(164, 240);
                this.mobjLabelScrpt.Name = "mobjLabelScrpt";
                this.mobjLabelScrpt.Size = new System.Drawing.Size(37, 13);
                this.mobjLabelScrpt.TabIndex = 4;
                this.mobjLabelScrpt.Text = WGLabels.Script;
                this.mobjLabelScrpt.Visible = false;
                // 
                // mobjComboScript
                // 
                this.mobjComboScript.FormattingEnabled = true;
                this.mobjComboScript.Location = new System.Drawing.Point(167, 257);
                this.mobjComboScript.Name = "mobjComboScript";
                this.mobjComboScript.Size = new System.Drawing.Size(173, 21);
                this.mobjComboScript.TabIndex = 5;
                this.mobjComboScript.Visible = false;
                // 
                // mobjListFont
                // 
                this.mobjListFont.FormattingEnabled = true;
                this.mobjListFont.Location = new System.Drawing.Point(12, 49);
                this.mobjListFont.Name = "mobjListFont";
                this.mobjListFont.Size = new System.Drawing.Size(146, 95);
                this.mobjListFont.TabIndex = 6;
                this.mobjListFont.SelectedIndexChanged += new EventHandler(mobjListFont_SelectedIndexChanged);
                this.mobjListFont.SelectionMode = SelectionMode.One;
                // 
                // mobjListFontStyle
                // 
                this.mobjListFontStyle.FormattingEnabled = true;
                this.mobjListFontStyle.Location = new System.Drawing.Point(167, 49);
                this.mobjListFontStyle.Name = "mobjListFontStyle";
                this.mobjListFontStyle.Size = new System.Drawing.Size(110, 95);
                this.mobjListFontStyle.TabIndex = 7;
                this.mobjListFontStyle.SelectedIndexChanged += new EventHandler(mobjListFontStyle_SelectedIndexChanged);
                this.mobjListFontStyle.SelectionMode = SelectionMode.One;
                // 
                // mobjListSize
                // 
                this.mobjListSize.FormattingEnabled = true;
                this.mobjListSize.Location = new System.Drawing.Point(284, 49);
                this.mobjListSize.Name = "mobjListSize";
                this.mobjListSize.Size = new System.Drawing.Size(56, 95);
                this.mobjListSize.TabIndex = 8;
                this.mobjListSize.SelectedIndexChanged += new EventHandler(mobjListSize_SelectedIndexChanged);
                this.mobjListSize.SelectionMode = SelectionMode.One;
                // 
                // mobjTextFont
                // 
                this.mobjTextFont.Location = new System.Drawing.Point(12, 27);
                this.mobjTextFont.Name = "mobjTextFont";
                this.mobjTextFont.Size = new System.Drawing.Size(146, 20);
                this.mobjTextFont.TabIndex = 9;
                this.mobjTextFont.TextChanged += new EventHandler(mobjTextFont_TextChanged);
                // 
                // mobjTextFontStyle
                // 
                this.mobjTextFontStyle.Location = new System.Drawing.Point(167, 27);
                this.mobjTextFontStyle.Name = "mobjTextFontStyle";
                this.mobjTextFontStyle.Size = new System.Drawing.Size(110, 20);
                this.mobjTextFontStyle.TabIndex = 10;
                this.mobjTextFontStyle.TextChanged += new EventHandler(mobjTextFontStyle_TextChanged);

                // 
                // mobjTextSize
                // 
                this.mobjTextSize.Location = new System.Drawing.Point(284, 27);
                this.mobjTextSize.Name = "mobjTextSize";
                this.mobjTextSize.Size = new System.Drawing.Size(56, 20);
                this.mobjTextSize.TabIndex = 11;
                this.mobjTextSize.TextChanged += new EventHandler(mobjTextSize_TextChanged);
                // 
                // mobjLabelFont
                // 
                this.mobjLabelFont.Location = new System.Drawing.Point(12, 13);
                this.mobjLabelFont.Name = "mobjLabelFont";
                this.mobjLabelFont.Size = new System.Drawing.Size(31, 13);
                this.mobjLabelFont.TabIndex = 12;
                this.mobjLabelFont.Text = WGLabels.FontColon;
                // 
                // mobjLabelFontStyle
                // 
                this.mobjLabelFontStyle.Location = new System.Drawing.Point(167, 12);
                this.mobjLabelFontStyle.Name = "mobjLabelFontStyle";
                this.mobjLabelFontStyle.Size = new System.Drawing.Size(57, 13);
                this.mobjLabelFontStyle.TabIndex = 13;
                this.mobjLabelFontStyle.Text = WGLabels.FontStyle;
                // 
                // mobjLabelSize
                // 
                this.mobjLabelSize.Location = new System.Drawing.Point(284, 12);
                this.mobjLabelSize.Name = "mobjLabelSize";
                this.mobjLabelSize.Size = new System.Drawing.Size(30, 13);
                this.mobjLabelSize.TabIndex = 14;
                this.mobjLabelSize.Text = WGLabels.Size;
                // 
                // FontDialog
                // 
                this.ClientSize = new System.Drawing.Size(433, 319);
                this.Controls.Add(this.mobjLabelSize);
                this.Controls.Add(this.mobjLabelFontStyle);
                this.Controls.Add(this.mobjLabelFont);
                this.Controls.Add(this.mobjTextSize);
                this.Controls.Add(this.mobjTextFontStyle);
                this.Controls.Add(this.mobjTextFont);
                this.Controls.Add(this.mobjListSize);
                this.Controls.Add(this.mobjListFontStyle);
                this.Controls.Add(this.mobjListFont);
                this.Controls.Add(this.mobjComboScript);
                this.Controls.Add(this.mobjLabelScrpt);
                this.Controls.Add(this.mobjGroupSample);
                this.Controls.Add(this.mobjGroupsEffects);
                this.Controls.Add(this.mobjButtonCancel);
                this.Controls.Add(this.mobjButtonApply);
                this.Controls.Add(this.mobjButtonOk);
                this.Name = "FontDialog";
                this.Text = WGLabels.Font;
                this.mobjGroupsEffects.ResumeLayout(true);
                this.mobjGroupSample.ResumeLayout(false);
                this.ResumeLayout(true);
            }

            /// <summary>
            /// Handles the SelectedValueChanged event of the mobjComboColor control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void mobjComboColor_SelectedValueChanged(object sender, EventArgs e)
            {
                if (mobjComboColor.SelectedItem != null)
                {

                    Color objCurrentColor = Color.Empty;
                    try
                    {
                        //Get the selected color 
                        objCurrentColor = (Color)mobjComboColor.SelectedItem;
                    }
                    catch { }

                    if (objCurrentColor != null)
                    {
                        FontDialogOwner.mobjColor = objCurrentColor;

                        //Paint the text
                        mobjLabelSample.ForeColor = objCurrentColor;
                    }
                }
            }

            private void mobjCheckUnderline_CheckedChanged(object sender, EventArgs e)
            {
                RefreshFont();
            }

            private void mobjCheckStrikeout_CheckedChanged(object sender, EventArgs e)
            {
                RefreshFont();
            }

            private void UpdateFontStyles(SerializableFontFamily objFontFamily, bool blnUpdateSelection)
            {
                if (!mblnInitializing)
                {
                    ArrayList objList = new ArrayList();

                    if (objFontFamily.IsStyleAvailable(FontStyle.Regular))
                    {
                        objList.Add(new FontStyleListItem(FontStyle.Regular,WGLabels.Regular));
                    }

                    if (objFontFamily.IsStyleAvailable(FontStyle.Italic))
                    {
                        objList.Add(new FontStyleListItem(FontStyle.Italic, WGLabels.Italic));
                    }

                    if (objFontFamily.IsStyleAvailable(FontStyle.Bold))
                    {
                        objList.Add(new FontStyleListItem(FontStyle.Bold, WGLabels.Bold));
                    }

                    if (objFontFamily.IsStyleAvailable(FontStyle.Bold) || objFontFamily.IsStyleAvailable(FontStyle.Italic))
                    {
                        objList.Add(new FontStyleListItem(FontStyle.Bold | FontStyle.Italic , WGLabels.BoldItalic));
                    }


                    bool blnRedraw = mobjListFontStyle.Items.Count != objList.Count;
                    if (!blnRedraw)
                    {
                        foreach (FontStyleListItem objItem in objList)
                        {
                            if (mobjListFontStyle.FindString(objItem.ToString())==-1)
                            {
                                blnRedraw = true;
                                break;
                            }
                        }
                    }

                    if (blnRedraw)
                    {
                        mobjListFontStyle.Items.Clear();
                        mobjListFontStyle.Items.AddRange(objList);
                        if (blnUpdateSelection)
                        {
                            int intIndex = mobjListFontStyle.FindString(WGLabels.Regular);
                            intIndex = intIndex == -1 ? 0 : intIndex;
                            mobjListFontStyle.SelectedIndex = intIndex;
                        }
                    }
                }
            }

            private void mobjTextFont_TextChanged(object sender, EventArgs e)
            {
                if (!mblnListChanging)
                {
                    ApplyFontName(false);
                }
            }

            private void mobjTextFontStyle_TextChanged(object sender, EventArgs e)
            {
                if (!mblnListChanging)
                {
                    int intIndex = mobjListFontStyle.FindString(mobjTextFontStyle.Text);
                    if (intIndex > -1)
                    {
                        mblnTextChanged = true;
                        mobjListFontStyle.SelectedIndex = intIndex;
                        mobjListFontStyle.Update();

                        RefreshFont();
                        mblnTextChanged = false;
                    }
                    else
                    {
                        mobjTextFontStyle.Text = mobjListFontStyle.SelectedItem.ToString();
                    }
                }
            }

            private void mobjTextSize_TextChanged(object sender, EventArgs e)
            {
                if (!mblnListChanging)
                {
                    ApplyFontSize(false);
                }
            }

            /// <summary>
            /// Applies the size of the font.
            /// </summary>
            /// <returns></returns>
            private bool ApplyFontSize(bool blnShowValidationMessages)
            {
                bool blnValid = false;

                int intIndex = mobjListSize.FindString(mobjTextSize.Text);
                if (intIndex > -1 && !String.IsNullOrEmpty(mobjTextSize.Text))
                {
                    mblnTextChanged = true;
                    mobjListSize.SelectedIndex = intIndex;
                    mobjListSize.Update();
                    RefreshFont();
                    mblnTextChanged = false;
                    blnValid = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(mobjTextSize.Text))
                    {
                        int intFontSize = -1;
                        if (int.TryParse(mobjTextSize.Text, out intFontSize))
                        {
                            if (intFontSize >= this.MinSize && intFontSize <= this.MaxSize)
                            {
                                blnValid = true;
                            }
                            else
                            {
                                if (mobjListSize.SelectedItem != null)
                                {
                                    mobjTextSize.Text = mobjListSize.SelectedItem.ToString();
                                }

                                if (blnShowValidationMessages)
                                {
                                    MessageBox.Show("Size must be between " + MinSize + " and " + MaxSize + " points.", "Font");
                                }
                            }
                        }
                        else if (blnShowValidationMessages)
                        {
                            MessageBox.Show("Size must be a number.", "Font");
                        }
                    }
                }

                return blnValid;
            }

            /// <summary>
            /// Applies the name of the font.
            /// </summary>
            /// <returns></returns>
            private bool ApplyFontName(bool blnShowValidationMessages)
            {
                bool blnValid = false;

                int intIndex = mobjListFont.FindString(mobjTextFont.Text);
                if (intIndex > -1)
                {
                    mblnTextChanged = true;
                    mobjListFont.SelectedIndex = intIndex;
                    UpdateFontStyles((SerializableFontFamily)mobjListFont.SelectedItem, true);
                    mobjListFont.Update();
                    RefreshFont();
                    mblnTextChanged = false;
                    blnValid = true;
                }
                else
                {
                    if (this.FontMustExist)
                    {
                        if (blnShowValidationMessages)
                        {
                            MessageBox.Show("There is no font with that name. \r\n Choose a font from the list of fonts.", "Font");
                        }
                    }
                    else
                    {
                        blnValid = true;
                    }

                }

                return blnValid;
            }

            /// <summary>
            /// Validates the font.
            /// </summary>
            /// <returns></returns>
            private bool ApplyFont()
            {
                return ApplyFontName(true) && ApplyFontSize(true);
            }

            private void mobjListFontStyle_SelectedIndexChanged(object sender, EventArgs e)
            {
                mblnListChanging = true;
                if (!mblnTextChanged)
                {
                    mobjTextFontStyle.Text = mobjListFontStyle.SelectedItem.ToString();

                    RefreshFont();
                }
                mblnListChanging = false;
            }

            private void mobjListSize_SelectedIndexChanged(object sender, EventArgs e)
            {
                mblnListChanging = true;
                if (!mblnTextChanged)
                {
                    mobjTextSize.Text = mobjListSize.SelectedItem.ToString();
                    RefreshFont();
                }
                mblnListChanging = false;
            }

            private void mobjListFont_SelectedIndexChanged(object sender, EventArgs e)
            {
                mblnListChanging = true;
                if (!mblnTextChanged)
                {

                    mobjTextFont.Text = ((SerializableFontFamily)mobjListFont.SelectedItem).Name;

                    UpdateFontStyles((SerializableFontFamily)mobjListFont.SelectedItem, true);
                    RefreshFont();
                }

                mblnListChanging = false;
            }

            void mobjButtonApply_Click(object sender, EventArgs e)
            {
                FontDialogOwner.OnApply(EventArgs.Empty);
            }

            private void mobjButtonCancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            private void mobjButtonOk_Click(object sender, EventArgs e)
            {
                if (ApplyFont() )
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            private void RefreshFont()
            {
                if (!mblnInitializing)
                {
                    float fltSize;
					if (CommonUtils.TryParse(mobjTextSize.Text, out fltSize))
                    {
                        FontStyle enmFontStyle = ((FontStyleListItem)mobjListFontStyle.SelectedItem).FontStyle;
                        
                        if (mobjCheckStrikeout.Checked) enmFontStyle = enmFontStyle | FontStyle.Strikeout;
                        if (mobjCheckUnderline.Checked) enmFontStyle = enmFontStyle | FontStyle.Underline;
                        this.Font = new SerializableFont((SerializableFontFamily)mobjListFont.SelectedItem, fltSize, enmFontStyle, GraphicsUnit.Point);
                        this.mobjLabelSample.Font = this.Font;
                        this.mobjLabelSample.Update();
                    }
                }
            }

            /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.FontDialog.Apply"></see> event.</summary>
            /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the data. </param>
            protected virtual void OnApply(EventArgs e)
            {
                // Raise event if needed
                EventHandler objEventHandler = this.Apply;
                if (objEventHandler != null)
                {
                    objEventHandler(this, e);
                }
            }

            /// <summary>Resets all dialog box options to their default values.</summary>
            /// <filterpriority>1</filterpriority>
            public virtual void Reset()
            {
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the font dialog owner.
            /// </summary>
            /// <value>The font dialog owner.</value>
            protected FontDialog FontDialogOwner
            {
                get
                {
                    return (FontDialog)this.CommonDialogOwner;
                }
            }

            /// <summary>Gets or sets a value indicating whether the user can change the character set specified in the Script combo box to display a character set other than the one currently displayed.</summary>
            /// <returns>true if the user can change the character set specified in the Script combo box; otherwise, false. The default value is true.</returns>
            /// <filterpriority>1</filterpriority>
            [DefaultValue(true), SRCategory("CatBehavior"), SRDescription("FnDallowScriptChangeDescr")]
            public bool AllowScriptChange
            {
                get
                {
                    return FontDialogOwner.AllowScriptChange;
                }
                set
                {
                    FontDialogOwner.AllowScriptChange = value;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box allows graphics device interface (GDI) font simulations.</summary>
            /// <returns>true if font simulations are allowed; otherwise, false. The default value is true.</returns>
            /// <filterpriority>1</filterpriority>
            [DefaultValue(true), SRCategory("CatBehavior"), SRDescription("FnDallowSimulationsDescr")]
            public bool AllowSimulations
            {
                get
                {
                    return FontDialogOwner.AllowSimulations;
                }
                set
                {
                    FontDialogOwner.AllowSimulations = value;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box allows vector font selections.</summary>
            /// <returns>true if vector fonts are allowed; otherwise, false. The default value is true.</returns>
            /// <filterpriority>1</filterpriority>
            [SRDescription("FnDallowVectorFontsDescr"), SRCategory("CatBehavior"), DefaultValue(true)]
            public bool AllowVectorFonts
            {
                get
                {
                    return FontDialogOwner.AllowVectorFonts;
                }
                set
                {
                    FontDialogOwner.AllowVectorFonts = value;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box displays both vertical and horizontal fonts or only horizontal fonts.</summary>
            /// <returns>true if both vertical and horizontal fonts are allowed; otherwise, false. The default value is true.</returns>
            /// <filterpriority>1</filterpriority>
            [DefaultValue(true), SRCategory("CatBehavior"), SRDescription("FnDallowVerticalFontsDescr")]
            public bool AllowVerticalFonts
            {
                get
                {
                    return FontDialogOwner.AllowVerticalFonts;
                }
                set
                {
                    FontDialogOwner.AllowVerticalFonts = value;
                }
            }

            /// <summary>Gets or sets the selected font color.</summary>
            /// <returns>The color of the selected font. The default value is <see cref="P:System.Drawing.Color.Black"></see>.</returns>
            /// <filterpriority>1</filterpriority>
            [SRCategory("CatData"), DefaultValue(typeof(Color), "Black"), SRDescription("FnDcolorDescr")]
            public Color Color
            {
                get
                {
                    return FontDialogOwner.Color;
                }
                set
                {
                    FontDialogOwner.Color = value;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box allows only the selection of fixed-pitch fonts.</summary>
            /// <returns>true if only fixed-pitch fonts can be selected; otherwise, false. The default value is false.</returns>
            /// <filterpriority>1</filterpriority>
            [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("FnDfixedPitchOnlyDescr")]
            public bool FixedPitchOnly
            {
                get
                {
                    return FontDialogOwner.FixedPitchOnly;
                }
                set
                {
                    FontDialogOwner.FixedPitchOnly = value;
                }
            }

            /// <summary>Gets or sets the selected font.</summary>
            /// <returns>The selected font.</returns>
            /// <filterpriority>1</filterpriority>
            [SRDescription("FnDfontDescr"), SRCategory("CatData")]
            new public Font Font
            {
                get
                {
                    return FontDialogOwner.Font;
                }
                set
                {
                    FontDialogOwner.Font = value;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box specifies an error condition if the user attempts to select a font or style that does not exist.</summary>
            /// <returns>true if the dialog box specifies an error condition when the user tries to select a font or style that does not exist; otherwise, false. The default is false.</returns>
            /// <filterpriority>1</filterpriority>
            [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("FnDfontMustExistDescr")]
            public bool FontMustExist
            {
                get
                {
                    return FontDialogOwner.FontMustExist;
                }
                set
                {
                    FontDialogOwner.FontMustExist = value;
                }
            }

            /// <summary>Gets or sets the maximum point size a user can select.</summary>
            /// <returns>The maximum point size a user can select. The default is 0.</returns>
            /// <filterpriority>1</filterpriority>
            [SRCategory("CatData"), DefaultValue(0), SRDescription("FnDmaxSizeDescr")]
            public int MaxSize
            {
                get
                {
                    return FontDialogOwner.MaxSize;
                }
                set
                {
                    FontDialogOwner.MaxSize = value;
                }
            }

            /// <summary>Gets or sets the minimum point size a user can select.</summary>
            /// <returns>The minimum point size a user can select. The default is 0.</returns>
            /// <filterpriority>1</filterpriority>
            [SRCategory("CatData"), DefaultValue(0), SRDescription("FnDminSizeDescr")]
            public int MinSize
            {
                get
                {
                    return FontDialogOwner.MinSize;
                }
                set
                {
                    FontDialogOwner.MinSize = value;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box allows selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.</summary>
            /// <returns>true if selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set, is allowed; otherwise, false. The default value is false.</returns>
            /// <filterpriority>1</filterpriority>
            [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("FnDscriptsOnlyDescr")]
            public bool ScriptsOnly
            {
                get
                {
                    return FontDialogOwner.ScriptsOnly;
                }
                set
                {
                    FontDialogOwner.ScriptsOnly = value;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box contains an Apply button.</summary>
            /// <returns>true if the dialog box contains an Apply button; otherwise, false. The default value is false.</returns>
            /// <filterpriority>1</filterpriority>
            [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("FnDshowApplyDescr")]
            public bool ShowApply
            {
                get
                {
                    return FontDialogOwner.ShowApply;
                }
                set
                {
                    FontDialogOwner.ShowApply = value;
                    mobjButtonApply.Visible = FontDialogOwner.ShowApply;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box displays the color choice.</summary>
            /// <returns>true if the dialog box displays the color choice; otherwise, false. The default value is false.</returns>
            /// <filterpriority>1</filterpriority>
            [DefaultValue(false), SRDescription("FnDshowColorDescr"), SRCategory("CatBehavior")]
            public bool ShowColor
            {
                get
                {
                    return FontDialogOwner.ShowColor;
                }
                set
                {
                    FontDialogOwner.ShowColor = value;

                    //Make the combo visible
                    mobjComboColor.Visible = FontDialogOwner.mblnShowColor;
                    mobjLabelColor.Visible = FontDialogOwner.mblnShowColor;

                    //If the combo is empty of colors fill it
                    if (FontDialogOwner.mblnShowColor && mobjComboColor.Items.Count == 0)
                    {
                        this.mobjComboColor.Items.AddRange(GetWebColors());
                    }
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box contains controls that allow the user to specify strikethrough, underline, and text color options.</summary>
            /// <returns>true if the dialog box contains controls to set strikethrough, underline, and text color options; otherwise, false. The default value is true.</returns>
            /// <filterpriority>1</filterpriority>
            [DefaultValue(true), SRCategory("CatBehavior"), SRDescription("FnDshowEffectsDescr")]
            public bool ShowEffects
            {
                get
                {
                    return FontDialogOwner.ShowEffects;
                }
                set
                {
                    FontDialogOwner.ShowEffects = value;
                    mobjGroupsEffects.Visible = FontDialogOwner.ShowEffects;
                }
            }

            /// <summary>Gets or sets a value indicating whether the dialog box displays a Help button.</summary>
            /// <returns>true if the dialog box displays a Help button; otherwise, false. The default value is false.</returns>
            /// <filterpriority>1</filterpriority>
            [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("FnDshowHelpDescr")]
            public bool ShowHelp
            {
                get
                {
                    return FontDialogOwner.ShowHelp;
                }
                set
                {
                    FontDialogOwner.ShowHelp = value;
                }
            }

            #endregion

            #region FontStyleListItem

            [Serializable()]
            private class FontStyleListItem
            {
                #region Members

                private FontStyle menmFontStyle;
                private string mstrText;

                #endregion Members

                #region C'Tors

                /// <summary>
                /// Initializes a new instance of the <see cref="FontStyleListItem"/> class.
                /// </summary>
                /// <param name="objFontStyle">the font style.</param>
                /// <param name="strText">the font style text.</param>
                public FontStyleListItem(FontStyle objFontStyle,string strText)
                {
                    menmFontStyle = objFontStyle;
                    mstrText = strText;
                }

                #endregion C'Tors

                #region Methods
               
                /// <summary>
                /// return font style name
                /// </summary>
                /// <returns></returns>
                public override string ToString()
                {
                    return mstrText;
                }
                
                #endregion Methods

                #region Properties

                /// <summary>
                /// Gets the font style.
                /// </summary>
                /// <value>The font style.</value>
                public FontStyle FontStyle
                {
                    get
                    {
                        return menmFontStyle;
                    }
                }

                #endregion Properties
            }

            #endregion FontStyleListItem
        }

        #endregion

        #region Members

        private Color mobjColor;
        private const int mintDefaultMaxSize = 0;
        private const int mintDefaultMinSize = 0;
        /// <summary>
        /// Owns the Apply event.
        /// </summary>
        protected static readonly SerializableEvent EventApply = SerializableEvent.Register("Event", typeof(Delegate), typeof(FontDialog));
        private SerializableFont mobjFont;
        private int mintMaxSize;
        private int mintMinSize;
        private int mintOptions;
        private bool mblnShowColor;

        /// <summary>
        /// Occurs when [apply].
        /// </summary>
        public event EventHandler Apply
        {
            add
            {
                this.AddHandler(EventApply, value);
            }
            remove
            {
                this.RemoveHandler(EventApply, value);
            }
        }

        #endregion

        #region C'Tor

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see> class.</summary>
        public FontDialog()
        {
            this.Reset();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a dialog option value
        /// </summary>
        /// <param name="intOption"></param>
        /// <returns></returns>
        internal bool GetOption(int intOption)
        {
            return ((this.mintOptions & intOption) != 0);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.FontDialog.Apply"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the data. </param>
        protected override void OnApply(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = (EventHandler)this.GetHandler(EventApply);
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Resets all dialog box options to their default values.</summary>
        /// <filterpriority>1</filterpriority>
        public override void Reset()
        {
            this.mintOptions = 0x101;
            this.mobjFont = null;
            this.mobjColor = Color.Black;
            this.mblnShowColor = false;
            this.mintMinSize = 8;
            this.mintMaxSize = 72;
            this.SetOption(0x40000, true);
        }

        private void ResetFont()
        {
            this.mobjFont = null;
        }

        /// <summary>
        /// Sets a dialog option value
        /// </summary>
        /// <param name="intOption"></param>
        /// <param name="blnValue"></param>
        internal void SetOption(int intOption, bool blnValue)
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

        private bool ShouldSerializeFont()
        {
            return !this.Font.Equals(Control.DefaultFont);
        }

        /// <summary>Retrieves a string that includes the name of the current font selected in the dialog box.</summary>
        /// <returns>A string that includes the name of the currently selected font.</returns>
        public override string ToString()
        {
            return (base.ToString() + ",  Font: " + this.Font.ToString());
        }

        /// <summary>
        /// Create the color dialog form
        /// </summary>
        /// <returns></returns>
        protected override CommonDialogForm CreateForm()
        {
            return new FontDialogForm(this);
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets a value indicating whether the user can change the character set specified in the Script combo box to display a character set other than the one currently displayed.</summary>
        /// <returns>true if the user can change the character set specified in the Script combo box; otherwise, false. The default value is true.</returns>
        [DefaultValue(true), SRDescription("FnDallowScriptChangeDescr"), SRCategory("CatBehavior")]
        public bool AllowScriptChange
        {
            get
            {
                return !this.GetOption(0x400000);
            }
            set
            {
                this.SetOption(0x400000, !value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box allows graphics device interface (GDI) font simulations.</summary>
        /// <returns>true if font simulations are allowed; otherwise, false. The default value is true.</returns>
        [SRDescription("FnDallowSimulationsDescr"), SRCategory("CatBehavior"), DefaultValue(true)]
        public bool AllowSimulations
        {
            get
            {
                return !this.GetOption(0x1000);
            }
            set
            {
                this.SetOption(0x1000, !value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box allows vector font selections.</summary>
        /// <returns>true if vector fonts are allowed; otherwise, false. The default value is true.</returns>
        [DefaultValue(true), SRCategory("CatBehavior"), SRDescription("FnDallowVectorFontsDescr")]
        public bool AllowVectorFonts
        {
            get
            {
                return !this.GetOption(0x800);
            }
            set
            {
                this.SetOption(0x800, !value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box displays both vertical and horizontal fonts or only horizontal fonts.</summary>
        /// <returns>true if both vertical and horizontal fonts are allowed; otherwise, false. The default value is true.</returns>
        [SRCategory("CatBehavior"), SRDescription("FnDallowVerticalFontsDescr"), DefaultValue(true)]
        public bool AllowVerticalFonts
        {
            get
            {
                return !this.GetOption(0x1000000);
            }
            set
            {
                this.SetOption(0x1000000, !value);
            }
        }

        /// <summary>Gets or sets the selected font color.</summary>
        /// <returns>The color of the selected font. The default value is <see cref="P:System.Drawing.Color.Black"></see>.</returns>
        [SRDescription("FnDcolorDescr"), DefaultValue(typeof(Color), "Black"), SRCategory("CatData")]
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

        /// <summary>Gets or sets a value indicating whether the dialog box allows only the selection of fixed-pitch fonts.</summary>
        /// <returns>true if only fixed-pitch fonts can be selected; otherwise, false. The default value is false.</returns>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("FnDfixedPitchOnlyDescr")]
        public bool FixedPitchOnly
        {
            get
            {
                return this.GetOption(0x4000);
            }
            set
            {
                this.SetOption(0x4000, value);
            }
        }

        /// <summary>Gets or sets the selected font.</summary>
        /// <returns>The selected font.</returns>
        [SRCategory("CatData"), SRDescription("FnDfontDescr")]
        public Font Font
        {
            get
            {
                Font objDefaultFont = this.mobjFont;
                if (objDefaultFont == null)
                {
                    objDefaultFont = Control.DefaultFont;
                }
                float fltSizeInPoints = objDefaultFont.SizeInPoints;
                if ((this.mintMinSize != 0) && (fltSizeInPoints < this.MinSize))
                {
                    objDefaultFont = new Font(objDefaultFont.FontFamily, (float)this.MinSize, objDefaultFont.Style, GraphicsUnit.Point);
                }
                if ((this.mintMaxSize != 0) && (fltSizeInPoints > this.MaxSize))
                {
                    objDefaultFont = new Font(objDefaultFont.FontFamily, (float)this.MaxSize, objDefaultFont.Style, GraphicsUnit.Point);
                }
                return objDefaultFont;
            }
            set
            {
                this.mobjFont = (SerializableFont)value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box specifies an error condition if the user attempts to select a font or style that does not exist.</summary>
        /// <returns>true if the dialog box specifies an error condition when the user tries to select a font or style that does not exist; otherwise, false. The default is false.</returns>
        [DefaultValue(false), SRDescription("FnDfontMustExistDescr"), SRCategory("CatBehavior")]
        public bool FontMustExist
        {
            get
            {
                return this.GetOption(0x10000);
            }
            set
            {
                this.SetOption(0x10000, value);
            }
        }

        /// <summary>Gets or sets the maximum point size a user can select.</summary>
        /// <returns>The maximum point size a user can select. The default is 0.</returns>
        [SRDescription("FnDmaxSizeDescr"), SRCategory("CatData"), DefaultValue(0)]
        public int MaxSize
        {
            get
            {
                return this.mintMaxSize;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.mintMaxSize = value;
                if ((this.mintMaxSize > 0) && (this.mintMaxSize < this.mintMinSize))
                {
                    this.mintMinSize = this.mintMaxSize;
                }
            }
        }

        /// <summary>Gets or sets the minimum point size a user can select.</summary>
        /// <returns>The minimum point size a user can select. The default is 0.</returns>
        [DefaultValue(0), SRDescription("FnDminSizeDescr"), SRCategory("CatData")]
        public int MinSize
        {
            get
            {
                return this.mintMinSize;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.mintMinSize = value;
                if ((this.mintMaxSize > 0) && (this.mintMaxSize < this.mintMinSize))
                {
                    this.mintMaxSize = this.mintMinSize;
                }
            }
        }

        /// <summary>Gets values to initialize the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see>.</summary>
        /// <returns>A bitwise combination of internal values that initializes the <see cref="T:Gizmox.WebGUI.Forms.FontDialog"></see>.</returns>
        protected int Options
        {
            get
            {
                return this.mintOptions;
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box allows selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.</summary>
        /// <returns>true if selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set, is allowed; otherwise, false. The default value is false.</returns>
        [SRDescription("FnDscriptsOnlyDescr"), DefaultValue(false), SRCategory("CatBehavior")]
        public bool ScriptsOnly
        {
            get
            {
                return this.GetOption(0x400);
            }
            set
            {
                this.SetOption(0x400, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box contains an Apply button.</summary>
        /// <returns>true if the dialog box contains an Apply button; otherwise, false. The default value is false.</returns>
        [SRDescription("FnDshowApplyDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public bool ShowApply
        {
            get
            {
                return this.GetOption(0x200);
            }
            set
            {
                this.SetOption(0x200, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box displays the color choice.</summary>
        /// <returns>true if the dialog box displays the color choice; otherwise, false. The default value is false.</returns>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("FnDshowColorDescr")]
        public bool ShowColor
        {
            get
            {
                return this.mblnShowColor;
            }
            set
            {
                this.mblnShowColor = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box contains controls that allow the user to specify strikethrough, underline, and text color options.</summary>
        /// <returns>true if the dialog box contains controls to set strikethrough, underline, and text color options; otherwise, false. The default value is true.</returns>
        [DefaultValue(true), SRCategory("CatBehavior"), SRDescription("FnDshowEffectsDescr")]
        public bool ShowEffects
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

        /// <summary>Gets or sets a value indicating whether the dialog box displays a Help button.</summary>
        /// <returns>true if the dialog box displays a Help button; otherwise, false. The default value is false.</returns>
        [SRCategory("CatBehavior"), SRDescription("FnDshowHelpDescr"), DefaultValue(false)]
        public bool ShowHelp
        {
            get
            {
                return this.GetOption(4);
            }
            set
            {
                this.SetOption(4, value);
            }
        }

        #endregion
    }
}
