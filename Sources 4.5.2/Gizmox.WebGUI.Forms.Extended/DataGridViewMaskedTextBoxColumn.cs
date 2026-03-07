using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#endif
    [Serializable()]
    public class DataGridViewMaskedTextBoxColumn : DataGridViewTextBoxColumn
    {

        #region Members

        private const char mcntPromptChar = '_';

        #endregion Members

        #region C'tors / D'tors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxColumn"></see> class to the default state.</summary>
        public DataGridViewMaskedTextBoxColumn()
            : base(new DataGridViewMaskedTextBoxCell())
        {
        }

        #endregion C'tors / D'tors


        #region Methods

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder builder1 = new StringBuilder(0x40);
            builder1.Append("DataGridViewMaskedTextBoxColumn { Name=");
            builder1.Append(base.Name);
            builder1.Append(", Index=");
            builder1.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder1.Append(" }");
            return builder1.ToString();
        }
        #endregion Methods

        #region Properties

        /// <summary>Gets or sets the template used to model cell appearance.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
        /// <exception cref="T:System.InvalidCastException">The set type is not compatible with type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if ((value != null) && !(value is DataGridViewMaskedTextBoxCell))
                {
                    throw new InvalidCastException(string.Format("Value provided for CellTemplate must be of type {0} or derive from it.", new object[] { "Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxCell" }));
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Gets the masked text box cell template.
        /// </summary>
        /// <value>The masked text box cell template.</value>
        private DataGridViewMaskedTextBoxCell MaskedTextBoxCellTemplate
        {
            get
            {
                return (DataGridViewMaskedTextBoxCell)this.CellTemplate;
            }
        }



        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        /// <value>The mask.</value>
#if WG_NET46
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        [Localizable(true), RefreshProperties(RefreshProperties.Repaint), DefaultValue("")]
        public string Mask
        {
            get
            {
                if (this.MaskedTextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.MaskedTextBoxCellTemplate.Mask;
            }
            set
            {
                if (this.Mask != value)
                {
                    this.MaskedTextBoxCellTemplate.Mask = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewMaskedTextBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewMaskedTextBoxCell;
                            if (objCell != null)
                            {
                                objCell.Mask = value;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets the prompt char.
        /// </summary>
        /// <value>The prompt char.</value>
        [Localizable(true), DefaultValue(mcntPromptChar), RefreshProperties(RefreshProperties.Repaint)]
        public char PromptChar
        {
            get
            {
                if (this.MaskedTextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.MaskedTextBoxCellTemplate.PromptChar;
            }
            set
            {
                if (this.PromptChar != value)
                {
                    this.MaskedTextBoxCellTemplate.PromptChar = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewMaskedTextBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewMaskedTextBoxCell;
                            if (objCell != null)
                            {
                                objCell.PromptChar = value;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [hide prompt on leave].
        /// </summary>
        /// <value><c>true</c> if [hide prompt on leave]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), RefreshProperties(RefreshProperties.Repaint)]
        public bool HidePromptOnLeave
        {
            get
            {
                if (this.MaskedTextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.MaskedTextBoxCellTemplate.HidePromptOnLeave;
            }
            set
            {
                if (this.HidePromptOnLeave != value)
                {
                    this.MaskedTextBoxCellTemplate.HidePromptOnLeave = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewMaskedTextBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewMaskedTextBoxCell;
                            if (objCell != null)
                            {
                                objCell.HidePromptOnLeave = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the text mask format.
        /// </summary>
        /// <value>The text mask format.</value>
        [DefaultValue(MaskFormat.IncludeLiterals)]
        public MaskFormat TextMaskFormat
        {
            get
            {
                if (this.MaskedTextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.MaskedTextBoxCellTemplate.TextMaskFormat;
            }
            set
            {
                if (this.TextMaskFormat != value)
                {
                    this.MaskedTextBoxCellTemplate.TextMaskFormat = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewMaskedTextBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewMaskedTextBoxCell;
                            if (objCell != null)
                            {
                                objCell.TextMaskFormat = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether System.Windows.Forms.MaskedTextBox.PromptChar
        /// can be entered as valid data by the user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the user can enter the prompt character into the control; otherwise, <c>false</c>.
        /// </value>
        [Category("CatBehavior")]
        [Description("MaskedTextBoxAllowPromptAsInputDescr")]
        [DefaultValue(true)]
        public bool AllowPromptAsInput
        {
            get
            {
                if (this.MaskedTextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.MaskedTextBoxCellTemplate.AllowPromptAsInput;
            }
            set
            {
                if (this.HidePromptOnLeave != value)
                {
                    this.MaskedTextBoxCellTemplate.AllowPromptAsInput = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewMaskedTextBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewMaskedTextBoxCell;
                            if (objCell != null)
                            {
                                objCell.AllowPromptAsInput = value;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets a value that determines how an input character that matches
        /// the prompt character should be handled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the prompt character entered as input causes the current editable
        ///     position in the mask to be reset; otherwise, <c>false</c>.to indicate that the prompt
        ///     character is to be processed as a normal input character
        /// </value>
        [Description("MaskedTextBoxResetOnPrompt")]
        [DefaultValue(true)]
        [Category("CatBehavior")]
        public bool ResetOnPrompt
        {
            get
            {
                if (this.MaskedTextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.MaskedTextBoxCellTemplate.ResetOnPrompt;
            }
            set
            {
                if (this.HidePromptOnLeave != value)
                {
                    this.MaskedTextBoxCellTemplate.ResetOnPrompt = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewMaskedTextBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewMaskedTextBoxCell;
                            if (objCell != null)
                            {
                                objCell.ResetOnPrompt = value;
                            }
                        }
                    }
                }
            }
        }




        //
        // Summary:
        //     Gets or sets a value that determines how a space input character should be
        //     handled.
        //
        // Returns:
        //     true if the space input character causes the current editable position in
        //     the mask to be reset; otherwise, false to indicate that it is to be processed
        //     as a normal input character. The default is true.
        [Description("MaskedTextBoxResetOnSpace")]
        [DefaultValue(true)]
        [Category("CatBehavior")]
        public bool ResetOnSpace
        {
            get
            {
                if (this.MaskedTextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.MaskedTextBoxCellTemplate.ResetOnSpace;
            }
            set
            {
                if (this.HidePromptOnLeave != value)
                {
                    this.MaskedTextBoxCellTemplate.ResetOnSpace = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewMaskedTextBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewMaskedTextBoxCell;
                            if (objCell != null)
                            {
                                objCell.ResetOnSpace= value;
                            }
                        }
                    }
                }
            }
        }


        #endregion Properties
    }
}
