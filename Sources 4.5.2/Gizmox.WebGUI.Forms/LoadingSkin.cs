using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Provides loading customization capabilities
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ProgressBar))]
    public class LoadingSkin : CommonSkin
    {
        #region Properties

        /// <summary>
        /// Gets the loading panel style.
        /// </summary>
        /// <value>The loading panel style.</value>
        [Category("States"), SRDescription("The loading animation style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue LoadingAnimationStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LoadingAnimationStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the loading message horizontal alignment.
        /// </summary>
        /// <value>The loading message horizontal alignment.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignmentValue MessageHorizontalAlignment
        {
            get
            {
                return this.GetValue<HorizontalAlignmentValue>("MessageHorizontalAlignment", new HorizontalAlignmentValue(HorizontalAlignment.Center));
            }
            set
            {
                this.SetValue("MessageHorizontalAlignment", value);
            }
        }

        /// <summary>
        /// Gets the loading message style.
        /// </summary>
        /// <value>The loading message style.</value>
        [Category("States"), SRDescription("The loading message style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public LoadingMessageStyle LoadingMessageStyle
        {
            get
            {
                return new LoadingMessageStyle(this.MessageVerticalAlignment, this.MessageHorizontalAlignment, this.MessageStyle);
            }
        }

        /// <summary>
        /// Gets the message style.
        /// </summary>
        /// <value>The message style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue MessageStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MessageStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the loading message vertical alignment.
        /// </summary>
        /// <value>The loading message vertical alignment.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignmentValue MessageVerticalAlignment
        {
            get
            {
                return this.GetValue<VerticalAlignmentValue>("MessageVerticalAlignment", new VerticalAlignmentValue(VerticalAlignment.Center));
            }
            set
            {
                this.SetValue("MessageVerticalAlignment", value);
            }
        }


        /// <summary>
        /// Gets the web set style function.
        /// </summary>
        /// <value>The web set style function.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public TextResourceReference LoadingAnimationCSS
        {
            get
            {
                return new TextResourceReference(typeof(LoadingSkin), "LoadingAnimation.css");
            }
        }

        #endregion

        #region Methods

        private void InitializeComponent()
        {

        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable(), TypeConverter(typeof(LoadingMessageStyleConverter))]
    public class LoadingMessageStyle
    {
        #region Fields

        private HorizontalAlignmentValue menmMessageHorizontalAlignment;
        private VerticalAlignmentValue menmMessageVerticalAlignment;
        private StyleValue mobjMessageStyle;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingMessageStyle"/> class.
        /// </summary>
        /// <param name="enmMessageVerticalAlignment">The enm message vertical alignment.</param>
        /// <param name="enmMessageHorizontalAlignment">The enm message horizontal alignment.</param>
        /// <param name="objMessageStyle">The obj message style.</param>
        public LoadingMessageStyle(VerticalAlignmentValue enmMessageVerticalAlignment, HorizontalAlignmentValue enmMessageHorizontalAlignment, StyleValue objMessageStyle)
        {
            menmMessageVerticalAlignment = enmMessageVerticalAlignment;
            menmMessageHorizontalAlignment = enmMessageHorizontalAlignment;
            mobjMessageStyle = objMessageStyle;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the message horizontal alignment.
        /// </summary>
        /// <value>The message horizontal alignment.</value>
        public HorizontalAlignmentValue MessageHorizontalAlignment
        {
            get { return menmMessageHorizontalAlignment; }
            set { menmMessageHorizontalAlignment = value; }
        }

        /// <summary>
        /// Gets or sets the message style.
        /// </summary>
        /// <value>The message style.</value>
        public StyleValue MessageStyle
        {
            get { return mobjMessageStyle; }
            set { mobjMessageStyle = value; }
        }

        /// <summary>
        /// Gets or sets the message vertical alignment.
        /// </summary>
        /// <value>The message vertical alignment.</value>
        public VerticalAlignmentValue MessageVerticalAlignment
        {
            get { return menmMessageVerticalAlignment; }
            set { menmMessageVerticalAlignment = value; }
        }

        #endregion

        #region LoadingMessageStyleConverter

        /// <summary>
        /// 
        /// </summary>
        public class LoadingMessageStyleConverter : TypeConverter
        {
            /// <summary>
            /// Returns whether this object supports properties, using the specified context.
            /// </summary>
            /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <returns>
            /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"/> should be called to find the properties of this object; otherwise, false.
            /// </returns>
            public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
            {
                return true;
            }

            /// <summary>
            /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
            /// </summary>
            /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="objValue">An <see cref="T:System.Object"/> that specifies the type of array for which to get properties.</param>
            /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"/> that is used as a filter.</param>
            /// <returns>
            /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> with the properties that are exposed for this data type, or null if there are no properties.
            /// </returns>
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
            {
                PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(LoadingMessageStyle), arrAttributes);
                string[] arrText = new string[] { "MessageStyle", "MessageHorizontalAlignment", "MessageVerticalAlignment" };
                return objCollection.Sort(arrText);
            }
        }

        #endregion
    }
}