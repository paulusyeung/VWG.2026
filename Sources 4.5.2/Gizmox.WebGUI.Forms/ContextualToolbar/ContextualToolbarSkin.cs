#region Using

using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;
using System.ComponentModel;


#endregion

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
    /// <summary>
    /// Summary description for ContextualToolbarSkin
    /// </summary>   
    [Serializable()]
    public class ContextualToolbarSkin : FormSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        public class ContextualToolbarButtonSkinValue : StyleValue
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StyleValue"/> class.
            /// </summary>
            /// <param name="objPropertyOwner">The property owner.</param>
            /// <param name="strPropertyPrefix">The property prefix.</param>
            public ContextualToolbarButtonSkinValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
                : base(objPropertyOwner, strPropertyPrefix)
            {
            }

            /// <summary>
            /// Gets or sets the size of the contextual toolbar.
            /// </summary>
            /// <value>
            /// The size of the contextual toolbar.
            /// </value>
            public virtual Size ContextualToolbarButtonSize
            {
                get
                {
                    return this.GetValue<Size>("ContextualToolbarButtonSize", new Size(32, 32));
                }
                set
                {
                    this.SetValue("ContextualToolbarButtonSize", value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the contextual toolbar font.
        /// </summary>
        /// <value>
        /// The contextual toolbar font.
        /// </value>
        [SRDescription("The contextual image font button image.")]
        [SRCategory("Images")]
        public virtual ImageResourceReference ContextualToolbarFont
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContextualToolbarFont", null);
            }
            set
            {
                this.SetValue("ContextualToolbarFont", value);
            }
        }


        /// <summary>
        /// Gets or sets the color of the contextual toolbar fore.
        /// </summary>
        /// <value>
        /// The color of the contextual toolbar fore.
        /// </value>
        [SRDescription("The contextual image forecolor button image.")]
        [SRCategory("Images")]
        public virtual ImageResourceReference ContextualToolbarForeColor
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContextualToolbarForeColor", null);
            }
            set
            {
                this.SetValue("ContextualToolbarForeColor", value);
            }
        }


        /// <summary>
        /// Gets or sets the color of the contextual toolbar fore.
        /// </summary>
        /// <value>
        /// The color of the contextual toolbar fore.
        /// </value>
        [SRDescription("The contextual image backcolor button image.")]
        [SRCategory("Images")]
        public virtual ImageResourceReference ContextualToolbarBackColor
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContextualToolbarBackColor", null);
            }
            set
            {
                this.SetValue("ContextualToolbarBackColor", value);
            }
        }


        /// <summary>
        /// Gets or sets the contextual toolbar dock.
        /// </summary>
        /// <value>
        /// The contextual toolbar dock.
        /// </value>
        [SRDescription("The contextual image forecolor button image.")]
        [SRCategory("Images")]
        public virtual ImageResourceReference ContextualToolbarDock
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContextualToolbarDock", null);
            }
            set
            {
                this.SetValue("ContextualToolbarDock", value);
            }
        }

        /// <summary>
        /// Gets or sets the contextual toolbar dock.
        /// </summary>
        /// <value>
        /// The contextual toolbar dock.
        /// </value>
        [SRDescription("The contextual image forecolor button image.")]
        [SRCategory("Images")]
        public virtual ImageResourceReference ContextualToolbarDelete
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContextualToolbarDelete", null);
            }
            set
            {
                this.SetValue("ContextualToolbarDelete", value);
            }
        }

        /// <summary>
        /// Gets or sets the contextual toolbar action.
        /// </summary>
        /// <value>
        /// The contextual toolbar dock.
        /// </value>
        [SRDescription("The contextual image forecolor button image.")]
        [SRCategory("Images")]
        public virtual ImageResourceReference ContextualToolbarActions
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContextualToolbarActions", null);
            }
            set
            {
                this.SetValue("ContextualToolbarActions", value);
            }
        }

        /// <summary>
        /// Gets or sets the contextual toolbar dock.
        /// </summary>
        /// <value>
        /// The contextual toolbar dock.
        /// </value>
        [SRDescription("The contextual image forecolor button image.")]
        [SRCategory("Images")]
        public virtual ImageResourceReference ContextualToolbarAnchor
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContextualToolbarAnchor", null);
            }
            set
            {
                this.SetValue("ContextualToolbarAnchor", value);
            }
        }

        /// <summary>
        /// Gets or sets the contextual toolbar visual templates.
        /// </summary>
        /// <value>
        /// The contextual toolbar dock.
        /// </value>
        [SRDescription("The contextual image forecolor button image.")]
        [SRCategory("Images")]
        public virtual ImageResourceReference ContextualToolbarVisualTemplates
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContextualToolbarVisualTemplates", null);
            }
            set
            {
                this.SetValue("ContextualToolbarVisualTemplates", value);
            }
        }


        /// <summary>
        /// Gets or sets the size of the contextual toolbar.
        /// </summary>
        /// <value>
        /// The size of the contextual toolbar.
        /// </value>
        public virtual Size ContextualToolbarSize
        {
            get
            {
                return this.GetValue<Size>("ContextualToolbarSize", new Size(150, 38));
            }
            set
            {
                this.SetValue("ContextualToolbarSize", value);
            }
        }



        /// <summary>
        /// Gets the contextual toolbar container LTR style.
        /// </summary>
        /// <value>
        /// The contextual toolbar container LTR style.
        /// </value>
        [SRDescription("Sets the buttons container style of the contextualtoolbar.")]
        public StyleValue ContextualToolbarContainerLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ContextualToolbarContainerLTRStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the contextual toolbar container RTL style.
        /// </summary>
        /// <value>
        /// The contextual toolbar container RTL style.
        /// </value>
        [SRDescription("Sets the buttons container style of the contextualtoolbar.")]
        public StyleValue ContextualToolbarContainerRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ContextualToolbarContainerRTLStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the contextual toolbar container.
        /// </summary>
        /// <value>
        /// The contextual toolbar container.
        /// </value>
        public BidirectionalSkinValue<StyleValue> ContextualToolbarContainer
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.ContextualToolbarContainerLTRStyle, this.ContextualToolbarContainerRTLStyle);
            }
        }        

        /// <summary>
        /// Gets the contextual toolbar container style.
        /// </summary>
        /// <value>
        /// The contextual toolbar container.
        /// </value>
        [SRDescription("Sets a single button style.")]
        public ContextualToolbarButtonSkinValue ContextualToolbarButton
        {
            get
            {
                ContextualToolbarButtonSkinValue objStyle = new ContextualToolbarButtonSkinValue(this, "ContextualToolbarButton");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the contextual toolbar container style.
        /// </summary>
        /// <value>
        /// The contextual toolbar container.
        /// </value>
        [SRDescription("Sets a single button LTR style.")]
        public ContextualToolbarButtonSkinValue ContextualToolbarButtonFirstLTRStyle
        {
            get
            {
                ContextualToolbarButtonSkinValue objStyle = new ContextualToolbarButtonSkinValue(this, "ContextualToolbarButtonFirstLTRStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the contextual toolbar button first RTL style.
        /// </summary>
        /// <value>
        /// The contextual toolbar button first RTL style.
        /// </value>
        [SRDescription("Sets a single button RTL style.")]
        public ContextualToolbarButtonSkinValue ContextualToolbarButtonFirstRTLStyle
        {
            get
            {
                ContextualToolbarButtonSkinValue objStyle = new ContextualToolbarButtonSkinValue(this, "ContextualToolbarButtonFirstRTLStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the contextual toolbar button first.
        /// </summary>
        /// <value>
        /// The contextual toolbar button first.
        /// </value>
        public BidirectionalSkinValue<ContextualToolbarButtonSkinValue> ContextualToolbarButtonFirst
        {
            get
            {
                return new BidirectionalSkinValue<ContextualToolbarButtonSkinValue>(this, this.ContextualToolbarButtonFirstLTRStyle, this.ContextualToolbarButtonFirstRTLStyle);
            }
        }     

        /// <summary>
        /// Gets the contextual toolbar container style.
        /// </summary>
        /// <value>
        /// The contextual toolbar container.
        /// </value>
        [SRDescription("Sets a single button style.")]
        public ContextualToolbarButtonSkinValue ContextualToolbarButtonHover
        {
            get
            {
                ContextualToolbarButtonSkinValue objStyle = new ContextualToolbarButtonSkinValue(this, "ContextualToolbarButtonHover");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the width of the contextual toolbar button.
        /// </summary>
        /// <value>
        /// The width of the contextual toolbar button.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public int ContextualToolbarButtonWidth
        {
            get
            {
                return ContextualToolbarButton.ContextualToolbarButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the contextual toolbar button.
        /// </summary>
        /// <value>
        /// The height of the contextual toolbar button.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public int ContextualToolbarButtonHeight
        {
            get
            {
                return ContextualToolbarButton.ContextualToolbarButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the contextual toolbar button.
        /// </summary>
        /// <value>
        /// The width of the contextual toolbar button.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public int ContextualToolbarButtonHoverWidth
        {
            get
            {
                return ContextualToolbarButtonHover.ContextualToolbarButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the contextual toolbar button.
        /// </summary>
        /// <value>
        /// The height of the contextual toolbar button.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public int ContextualToolbarButtonHoverHeight
        {
            get
            {
                return ContextualToolbarButtonHover.ContextualToolbarButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets the height of the contextual toolbar button image.
        /// </summary>
        /// <value>
        /// The height of the contextual toolbar button image.
        /// </value>
        public int ContextualToolbarButtonImageHeight
        {
            get
            {
                return this.GetValue<int>("ContextualToolbarButtonImageHeight", this.GetImageHeight(this.ContextualToolbarFont, this.DefaultContextualToolbarButtonImageHeight));
            }
            set
            {
                this.SetValue("ContextualToolbarButtonImageHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the contextual toolbar button image.
        /// </summary>
        private void ResetContextualToolbarButtonImageHeight()
        {
            this.Reset("ContextualToolbarButtonImageHeight");
        }

        /// <summary>
        /// Gets the default height of the contextual toolbar button image.
        /// </summary>
        /// <value>
        /// The default height of the contextual toolbar button image.
        /// </value>
        protected virtual int DefaultContextualToolbarButtonImageHeight
        {
            get
            {
                return 30;
            }
        }

        /// <summary>
        /// Gets the width of the contextual toolbar button image.
        /// </summary>
        /// <value>
        /// The width of the contextual toolbar button image.
        /// </value>
        public int ContextualToolbarButtonImageWidth
        {
            get
            {
                return this.GetValue<int>("ContextualToolbarButtonImageWidth", this.GetImageHeight(this.ContextualToolbarFont, this.DefaultContextualToolbarButtonImageWidth));
            }
            set
            {
                this.SetValue("ContextualToolbarButtonImageWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the contextual toolbar button image.
        /// </summary>
        private void ResetContextualToolbarButtonImageWidth()
        {
            this.Reset("ContextualToolbarButtonImageWidth");
        }


        /// <summary>
        /// Gets the default width of the contextual toolbar button image.
        /// </summary>
        /// <value>
        /// The default width of the contextual toolbar button image.
        /// </value>
        protected virtual int DefaultContextualToolbarButtonImageWidth
        {
            get
            {
                return 30;
            }
        }

    }
}

