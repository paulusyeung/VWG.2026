#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Runtime.Serialization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Specifies how an image is positioned within a <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>.
    /// </summary>
    [Serializable()]
    public enum PictureBoxSizeMode
    {
        /// <summary>
        /// The <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> is sized equal to the size of the image that it contains.This mode doesn't work at run time.
        /// </summary>
        AutoSize = 2,
        /// <summary>
        /// The image is displayed in the center if the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> is larger than the image. If the image is larger than the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>, the picture is placed in the center of the <see cref="T:System.Windows.Forms.PictureBox"></see> and the outside edges are clipped.
        /// </summary>
        CenterImage = 3,
        /// <summary>
        /// The image is placed in the upper-left corner of the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>. The image is clipped if it is larger than the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> it is contained in.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// The image within the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> is stretched or shrunk to fit the size of the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>.
        /// </summary>
        StretchImage = 1,

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        Zoom = 4
    }

    #endregion Enums

    #region PictureBox Class

    /// <summary>
    /// Represents a Windows picture box control for displaying an image.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(PictureBox), "PictureBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(PictureBox), "PictureBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Image")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Image")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Image")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Image")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Image")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Image")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultBindingProperty("Image")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [DefaultProperty("Image"), SRDescription("DescriptionPictureBox")]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.PictureBox)]
    [Skin(typeof(PictureBoxSkin))]
    [Serializable()]
    public class PictureBox : Control, ISupportInitialize
    {
        #region Class Members

        /// <summary>
        /// Provides a property reference to Image property.
        /// </summary>
        private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(PictureBox));

        /// <summary>
        /// Provides a property reference to PictureBoxSizeMode property.
        /// </summary>
        private static SerializableProperty PictureBoxSizeModeProperty = SerializableProperty.Register("PictureBoxSizeMode", typeof(PictureBoxSizeMode), typeof(PictureBox));

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> class.
        /// </summary>
        public PictureBox()
        {
            // Set the default size
            this.Size = new System.Drawing.Size(64, 105);
            base.SetStyle(ControlStyles.Selectable | ControlStyles.Opaque, false);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            this.TabStop = false;
        }

        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            objWriter.WriteAttributeString(WGAttributes.ImageSize, ((int)SizeMode).ToString());

            ResourceHandle objImage = this.GetProxyPropertyValue<ResourceHandle>("Image", this.Image);
            if (objImage != null)
            {
                // add attributes to control element
                objWriter.WriteAttributeString(WGAttributes.Image, objImage.ToString());
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Indicates how the image is displayed.
        /// </summary>
        ///	<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.PictureBoxSizeMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.PictureBoxSizeMode.Normal"></see>.</returns>
        ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.PictureBoxSizeMode"></see> values. </exception>
        [DefaultValue(PictureBoxSizeMode.Normal), Localizable(true), SRDescription("PictureBoxSizeModeDescr"), SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint)]
        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return this.GetValue<PictureBoxSizeMode>(PictureBox.PictureBoxSizeModeProperty, PictureBoxSizeMode.Normal);
            }
            set
            {
                if (this.SizeMode != value)
                {
                    if (value != PictureBoxSizeMode.Normal)
                    {
                        this.SetValue<PictureBoxSizeMode>(PictureBox.PictureBoxSizeModeProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<PictureBoxSizeMode>(PictureBox.PictureBoxSizeModeProperty);
                    }
                    //update the control.
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }

        /// <summary>
        /// Gets or sets the tab index.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public int TabIndex
        {
            get
            {
                return base.TabIndex;
            }
            set
            {
                base.TabIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the image that is displayed by <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>.
        /// </summary>
        /// <returns>The <see cref="T:System.Drawing.Image"></see> to display.</returns>
        [SRDescription("PictureBoxImageDescr"), Localizable(true), Bindable(true), SRCategory("CatAppearance"), DefaultValue(null), ProxyBrowsable(true)]
        public ResourceHandle Image
        {
            get
            {
                return this.GetValue<ResourceHandle>(PictureBox.ImageProperty, null);
            }
            set
            {
                if (this.Image != value)
                {
                    if (value != null)
                    {
                        this.SetValue<ResourceHandle>(PictureBox.ImageProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<ResourceHandle>(PictureBox.ImageProperty);
                    }
                    Update();

                }
            }
        }

        /// <summary>Gets or sets a value indicating whether an image is loaded synchronously.</summary>
        /// <returns>true if an image-loading operation is done synchronously, otherwise, false. The default is false.</returns>
        /// <filterpriority>2</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Localizable(true), SRCategory("CatAsynchronous"), SRDescription("PictureBoxWaitOnLoadDescr"), DefaultValue(false)]
        public bool WaitOnLoad
        {
            get
            {
                return false;
            }
            set
            { 
            }
        }

        /// <summary>Gets or sets the image displayed in the <see cref="T:System.Windows.Forms.PictureBox"></see> control while the main image is loading.</summary>
        /// <returns>The <see cref="T:System.Drawing.Image"></see> displayed in the picture box control while the main image is loading.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatAsynchronous"), Localizable(true), RefreshProperties(RefreshProperties.All), SRDescription("PictureBoxInitialImageDescr")]
        public ResourceHandle InitialImage
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        #endregion Properties

        #region Events

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.CausesValidation"></see> property changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler CausesValidationChanged
        {
            add
            {
                base.CausesValidationChanged += value;
            }
            remove
            {
                base.CausesValidationChanged -= value;
            }
        }

        /// <summary>
        /// Occurs when the control is entered.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler Enter
        {
            add
            {
                base.Enter += value;
            }
            remove
            {
                base.Enter -= value;
            }
        }

        /// <summary>
        /// Occurs when the FontChanged property changes.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler FontChanged
        {
            add
            {
                base.FontChanged += value;
            }
            remove
            {
                base.FontChanged -= value;
            }
        }

        /// <summary>
        /// Occurs when the ForeColorChanged property changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler ForeColorChanged
        {
            add
            {
                base.ForeColorChanged += value;
            }
            remove
            {
                base.ForeColorChanged -= value;
            }
        }

        /// <summary>
        /// Occurs on key down.
        /// Implemented by design as KeyPress (Use KeyPress instead).
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event KeyEventHandler KeyDown
        {
            add
            {
                base.KeyDown += value;
            }
            remove
            {
                base.KeyDown -= value;
            }
        }

        /// <summary>
        /// Occurs on key press.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event KeyPressEventHandler KeyPress
        {
            add
            {
                base.KeyPress += value;
            }
            remove
            {
                base.KeyPress -= value;
            }
        }

        /// <summary>
        /// Occurs on key up.
        /// Implemented by design as KeyPress (Use KeyPress instead).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event KeyEventHandler KeyUp
        {
            add
            {
                base.KeyUp += value;
            }
            remove
            {
                base.KeyUp -= value;
            }
        }

        /// <summary>
        /// Occurs when the input focus leaves the control.
        /// Not implemented by design.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler Leave
        {
            add
            {
                base.Leave += value;
            }
            remove
            {
                base.Leave -= value;
            }
        }

        /// <summary>
        /// Occurs when the Text property value changes.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler TextChanged
        {
            add
            {
                base.TextChanged += value;
            }
            remove
            {
                base.TextChanged -= value;
            }
        }

        /// <summary>
        /// Occurs when [client key down].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event ClientEventHandler ClientKeyDown
        {
            add
            {
                base.ClientKeyDown += value;
            }
            remove
            {
                base.ClientKeyDown -= value;
            }
        }



        #endregion Events

        #region Migration compatibility

        /// <summary>
        /// Loads the specified URL.
        /// </summary>
        /// <param name="strUrl">The URL.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [SRCategory("CatAsynchronous"), SRDescription("PictureBoxLoad1Descr")]
        public void Load(string strUrl)
        {
        }

        #endregion Migration compatibility

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new PictureBoxRenderer(this);
        }

        void ISupportInitialize.BeginInit()
        {

        }

        void ISupportInitialize.EndInit()
        {

        }
    }

    #endregion PictureBox Class

    #region PictureBoxRenderer Class

    /// <summary>
    /// Provides support for rendering PictureBoxes
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class PictureBoxRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PictureBoxRenderer"/> class.
        /// </summary>
        /// <param name="objPictureBox">The combo box.</param>
        internal PictureBoxRenderer(PictureBox objPictureBox)
            : base(objPictureBox)
        {
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            try
            {
                PictureBox objPictureBox = this.Control as PictureBox;
                if (objPictureBox != null)
                {
                    // Draw the image
                    RenderImage(objContext, objGraphics, objPictureBox.Image, new Point(0, 0));
                }
            }
            catch
            {
                // prevent errors when rendering image
            }
        }
    }

    #endregion

}