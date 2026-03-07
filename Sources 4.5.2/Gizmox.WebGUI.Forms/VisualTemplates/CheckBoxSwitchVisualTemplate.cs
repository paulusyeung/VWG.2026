using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// CheckBoxSwitchVisualTemplate SwitchSizing enum
    /// </summary>
    public enum CheckBoxSwitchVisualTemplateSwitchSizing : int
    {
        /// <summary>
        /// sizing in percentage
        /// </summary>
        Percent = 0,

        /// <summary>
        /// sizing in pixel
        /// </summary>
        Pixel = 1
    }

    #endregion Enums

    /// <summary>
    /// 
    /// </summary>
    [VisualTemplate(typeof(CheckBox), "Visually adjusts the CheckBoxSwitch control to an appearance more suitable for the customized device.")]
    [Skin(typeof(CheckBoxSwitchVisualTemplateSkin))]
    [Serializable()]
    public class CheckBoxSwitchVisualTemplate : VisualTemplate
    {
        private string mstrUnCheckedText = string.Empty;
        private string mstrCheckedText = string.Empty;

        private bool mblnShowCheckBoxLabel = true;
        private int mintSwitchWidth = 35;
        private CheckBoxSwitchVisualTemplateSwitchSizing menmCheckBoxSwitchVisualTemplateSwitchSizing = CheckBoxSwitchVisualTemplateSwitchSizing.Percent;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxSwitchVisualTemplate"/> class.
        /// </summary>
        public CheckBoxSwitchVisualTemplate()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxSwitchVisualTemplate"/> class.
        /// </summary>
        /// <param name="blnShowCheckBoxLabel">if set to <c>true</c> [BLN show check box label].</param>
        /// <param name="intSwitchWidth">Width of the int switch.</param>
        /// <param name="enmCheckBoxSwitchVisualTemplateSwitchSizing">The enm check box switch visual template switch sizing.</param>
        /// <param name="strUnCheckedText">The STR un checked text.</param>
        /// <param name="strCheckedText">The STR checked text.</param>
        public CheckBoxSwitchVisualTemplate(bool blnShowCheckBoxLabel, int intSwitchWidth, CheckBoxSwitchVisualTemplateSwitchSizing enmCheckBoxSwitchVisualTemplateSwitchSizing, string strUnCheckedText, string strCheckedText)
        {
            mblnShowCheckBoxLabel = blnShowCheckBoxLabel;
            mintSwitchWidth = intSwitchWidth;
            menmCheckBoxSwitchVisualTemplateSwitchSizing = enmCheckBoxSwitchVisualTemplateSwitchSizing;
            mstrUnCheckedText = strUnCheckedText;
            mstrCheckedText = strCheckedText;
        }


        /// <summary>
        /// Gets or sets the switch sizing.
        /// </summary>
        /// <value>
        /// The switch sizing.
        /// </value>
        public CheckBoxSwitchVisualTemplateSwitchSizing SwitchSizing
        {
            get
            {
                return menmCheckBoxSwitchVisualTemplateSwitchSizing;
            }
            set
            {
                menmCheckBoxSwitchVisualTemplateSwitchSizing = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the switch.
        /// </summary>
        /// <value>
        /// The width of the switch.
        /// </value>
        [Description("Set switch width when displaying label.")]
        public int SwitchWidth
        {
            get
            {
                return mintSwitchWidth;
            }
            set
            {
                mintSwitchWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether show the check box label.
        /// </summary>
        /// <value>
        ///   <c>true</c> if show check box label; otherwise, <c>false</c>.
        /// </value>
        public bool ShowCheckBoxLabel
        {
            get
            {
                return mblnShowCheckBoxLabel;
            }
            set
            {
                mblnShowCheckBoxLabel = value;
            }
        }

        /// <summary>
        /// Gets or sets the un checked text.
        /// </summary>
        /// <value>
        /// The un checked text.
        /// </value>
        public string UnCheckedText
        {
            get
            {
                return mstrUnCheckedText;
            }
            set
            {
                mstrUnCheckedText = value;
            }
        }

        /// <summary>
        /// Gets or sets the checked text.
        /// </summary>
        /// <value>
        /// The checked text.
        /// </value>
        public string CheckedText
        {
            get
            {
                return mstrCheckedText;
            }
            set
            {
                mstrCheckedText = value;
            }
        }

        /// <summary>
        /// Gets the name of the visual template.
        /// </summary>
        /// <value>
        /// The name of the visual template.
        /// </value>
        public override string VisualTemplateName
        {
            get
            {
                return "CheckBoxSwitchVisualTemplate";
            }
        }

        /// <summary>
        /// Gets the visualizer image.
        /// </summary>
        /// <value>
        /// The visualizer image.
        /// </value>
        public override ResourceHandle VisualizerImage
        {
            get
            {
                return new SkinResourceHandle(typeof(CheckBoxSwitchVisualTemplateSkin), "CheckBoxSwitch.png"); ;
            }
        }

        /// <summary>
        /// Gets the constroctor arguments. (For TypeConverter)
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override object[] GetConsturctorArguments()
        {
            return new object[5] { mblnShowCheckBoxLabel, mintSwitchWidth, menmCheckBoxSwitchVisualTemplateSwitchSizing,  mstrUnCheckedText, mstrCheckedText };
        }

        /// <summary>
        /// Gets the constroctor types. (For TypeConverter)
        /// </summary>
        public override Type[] GetConstructorTypes()
        {
            return new Type[5] { typeof(bool), typeof(int), typeof(CheckBoxSwitchVisualTemplateSwitchSizing), typeof(string), typeof(string) };
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        internal override string ConvertToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}", base.ConvertToString(), mblnShowCheckBoxLabel, mintSwitchWidth, (int)menmCheckBoxSwitchVisualTemplateSwitchSizing, mstrUnCheckedText, mstrCheckedText);
        }

        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="objVisualTemplateValues">The object visual template values.</param>
        internal override void ConvertFromString(List<string> objVisualTemplateValues)
        {
            bool blnShowCheckBoxLabel;
            int intSwitchWidth;
            int intCheckBoxSwitchVisualTemplateSwitchSizing;
            if (objVisualTemplateValues.Count == 5 && bool.TryParse(objVisualTemplateValues[0], out blnShowCheckBoxLabel) && int.TryParse(objVisualTemplateValues[1], out intSwitchWidth) && int.TryParse(objVisualTemplateValues[2], out intCheckBoxSwitchVisualTemplateSwitchSizing))
            {
                mblnShowCheckBoxLabel = blnShowCheckBoxLabel;
                mintSwitchWidth = intSwitchWidth;

                if (Enum.IsDefined(typeof(CheckBoxSwitchVisualTemplateSwitchSizing), intCheckBoxSwitchVisualTemplateSwitchSizing))
                {
                    menmCheckBoxSwitchVisualTemplateSwitchSizing = (CheckBoxSwitchVisualTemplateSwitchSizing)intCheckBoxSwitchVisualTemplateSwitchSizing;
                }

                mstrUnCheckedText = objVisualTemplateValues[3];
                mstrCheckedText = objVisualTemplateValues[4];
            }
        }

        /// <summary>
        /// Renders the specified object context.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="objWriter">The object writer.</param>
        public override void Render(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter)
        {
            base.Render(objContext, objWriter);

            if (!string.IsNullOrEmpty(mstrCheckedText))
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateCheckBoxCheckedText, mstrCheckedText);
            }
            if (!string.IsNullOrEmpty(mstrUnCheckedText))
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateCheckBoxUnCheckedText, mstrUnCheckedText);
            }

            objWriter.WriteAttributeString(WGAttributes.VisualTemplateCheckBoxShowLabel, this.ShowCheckBoxLabel ? "1" : "0");

            if (this.ShowCheckBoxLabel)
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateCheckBoxSwitchWidth, mintSwitchWidth);
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateCheckBoxSwitchSizing, (int)menmCheckBoxSwitchVisualTemplateSwitchSizing);
            }
        }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "CheckBox Switch Appearance";
        }
    }
}