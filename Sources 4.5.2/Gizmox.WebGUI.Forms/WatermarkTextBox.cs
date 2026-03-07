#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;

#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Summary description for WatermarkTextBox
    /// </summary>
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(WatermarkTextBox), "Extended.WatermarkTextBox_45.png")]
#else
    [ToolboxBitmap(typeof(WatermarkTextBox), "Extended.WatermarkTextBox.png")]
#endif
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.WatermarkTextBoxSkin)), Serializable()]
    [MetadataTag(WGTags.WatermarkTextBox)]
    public class WatermarkTextBox : TextBox, IRequiresRegistration
    {
        /// <summary>
        /// The string property registration.
        /// </summary>
        private static readonly SerializableProperty MessageProperty = SerializableProperty.Register("mstrMessage", typeof(string), typeof(WatermarkTextBox));
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WatermarkTextBox"/> class.
        /// </summary>
        public WatermarkTextBox()
        {
            this.CustomStyle = "Watermark";
        }

        /// <summary>
        /// Renders the attributes.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="writer">The writer.</param>
        protected override void RenderAttributes(IContext context, IAttributeWriter writer)
        {
            base.RenderAttributes(context, writer);

            writer.WriteAttributeText(WGAttributes.Message, this.Message, TextFilter.CarriageReturn | TextFilter.NewLine);
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [DefaultValue("Write text here...")]
        public string Message
        {
            get
            {
                return this.GetValue<string>(WatermarkTextBox.MessageProperty, "Write text here...");
            }
            set
            {
                if (this.Message != value)
                {
                    this.SetValue<string>(WatermarkTextBox.MessageProperty, value);

                    this.Update();
                }
            }
        }
    }
}
