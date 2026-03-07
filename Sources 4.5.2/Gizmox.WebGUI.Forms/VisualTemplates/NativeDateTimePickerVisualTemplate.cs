using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public enum NativeDateTimePickerVisualTemplateFormat : int
    {
        /// <summary>
        /// date
        /// </summary>
        Date,
        /// <summary>
        ///  time
        /// </summary>
        Time,
        /// <summary>
        /// date and time local
        /// </summary>
        DateTime_Local
    }

    /// <summary>
    /// 
    /// </summary>
    [VisualTemplate(typeof(DateTimePicker), "Visually adjusts the DateTimePicker control to appear identical to a native DateTimePicker on the customized device.")]
    [Skin(typeof(NativeDateTimePickerVisualTemplateSkin))]
    [Serializable()]
    public class NativeDateTimePickerVisualTemplate : VisualTemplate
    {

        private NativeDateTimePickerVisualTemplateFormat menmNativeDateTimePickerVisualTemplateFormat = NativeDateTimePickerVisualTemplateFormat.Date;

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeDateTimePickerVisualTemplate"/> class.
        /// </summary>
        public NativeDateTimePickerVisualTemplate()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeDateTimePickerVisualTemplate"/> class.
        /// </summary>
        /// <param name="enmNativeDateTimePickerVisualTemplateFormat">The enm native date time picker visual template format.</param>
        public NativeDateTimePickerVisualTemplate(NativeDateTimePickerVisualTemplateFormat enmNativeDateTimePickerVisualTemplateFormat)
        {
            menmNativeDateTimePickerVisualTemplateFormat = enmNativeDateTimePickerVisualTemplateFormat;
        }


        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        public NativeDateTimePickerVisualTemplateFormat Format
        {
            get
            {
                return menmNativeDateTimePickerVisualTemplateFormat;
            }
            set
            {
                menmNativeDateTimePickerVisualTemplateFormat = value;
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
                return "NativeDateTimePickerVisualTemplate";
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
                return new SkinResourceHandle(typeof(NativeDateTimePickerVisualTemplateSkin), "NativeDateTimePicker.png"); ;
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

            objWriter.WriteAttributeString(WGAttributes.VisualTemplateNativeDateTimePickerFormat, menmNativeDateTimePickerVisualTemplateFormat.ToString().Replace("_","-").ToLower());           
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Native DateTimePicker";
        }

        /// <summary>
        /// Gets the constroctor arguments. (For TypeConverter)
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override object[] GetConsturctorArguments()
        {
            return new object[1] { menmNativeDateTimePickerVisualTemplateFormat };
        }

        /// <summary>
        /// Gets the constroctor types. (For TypeConverter)
        /// </summary>
        public override Type[] GetConstructorTypes()
        {
            return new Type[1] { typeof(NativeDateTimePickerVisualTemplateFormat) };
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        internal override string ConvertToString()
        {
            return string.Format("{0}|{1}", base.ConvertToString(), (int)menmNativeDateTimePickerVisualTemplateFormat);
        }

        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="objVisualTemplateValues">The object visual template values.</param>
        internal override void ConvertFromString(List<string> objVisualTemplateValues)
        {
            int intNativeDateTimePickerVisualTemplateFormat = 0;
            if (objVisualTemplateValues.Count == 1 && int.TryParse(objVisualTemplateValues[0], out intNativeDateTimePickerVisualTemplateFormat))
            {
                if (Enum.IsDefined(typeof(NativeDateTimePickerVisualTemplateFormat), intNativeDateTimePickerVisualTemplateFormat))
                {
                    this.menmNativeDateTimePickerVisualTemplateFormat = (NativeDateTimePickerVisualTemplateFormat)intNativeDateTimePickerVisualTemplateFormat;
                }
            }
        }
    }
}