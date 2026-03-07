#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.Serialization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Defines the style used on the button.
    /// </summary>

    public enum ButtonStyle
    {
        /// <summary>
        /// Normal Button Style
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Custom Button Style
        /// </summary>
        Custom = 1
    }


    /// <summary>Specifies the appearance of a button.</summary>
    /// <filterpriority>2</filterpriority>
    [Flags]

    public enum ButtonState
    {
        /// <summary>All flags except Normal are set.</summary>
        /// <filterpriority>1</filterpriority>
        All = 0x4700,
        /// <summary>The button has a checked or latched appearance. Use this appearance to show that a toggle button has been pressed.</summary>
        /// <filterpriority>1</filterpriority>
        Checked = 0x400,
        /// <summary>The button has a flat, two-dimensional appearance.</summary>
        /// <filterpriority>1</filterpriority>
        Flat = 0x4000,
        /// <summary>The button is inactive (grayed).</summary>
        /// <filterpriority>1</filterpriority>
        Inactive = 0x100,
        /// <summary>The button has its normal appearance (three-dimensional).</summary>
        /// <filterpriority>1</filterpriority>
        Normal = 0,
        /// <summary>The button appears pressed.</summary>
        /// <filterpriority>1</filterpriority>
        Pushed = 0x200
    }

    #endregion Enums

    #region Button Class

    /// <summary>
    /// A button control
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxItemCategory("Common Controls")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(Button), "Button_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(Button), "Button.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ButtonController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ButtonController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [MetadataTag(WGTags.Button)]
    [Skin(typeof(Gizmox.WebGUI.Forms.Skins.ButtonSkin))]
    [Serializable()]
    public class Button : ButtonBase, IButtonControl
    {
        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to ButtonStyle property.
        /// </summary>
        private static SerializableProperty ButtonStyleProperty = SerializableProperty.Register("ButtonStyle", typeof(ButtonStyle), typeof(Button), new SerializablePropertyMetadata(ButtonStyle.Normal));

        /// <summary>
        /// Provides a property reference to DialogResult property.
        /// </summary>
        private static SerializableProperty DialogResultProperty = SerializableProperty.Register("DialogResult", typeof(DialogResult), typeof(Button), new SerializablePropertyMetadata(DialogResult.None));

        /// <summary>
        /// Provides a property reference to DropDownMenu property.
        /// </summary>
        private static SerializableProperty DropDownMenuProperty = SerializableProperty.Register("DropDownMenu", typeof(Menu), typeof(Button), new SerializablePropertyMetadata(null));

        #endregion Serializable Properties

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Creates a new <see cref="Button"/> instance.
        /// </summary>
        public Button()
        {
            base.SetStyle(ControlStyles.StandardDoubleClick | ControlStyles.StandardClick, false);

        }

        #endregion C'Tor/D'Tor

        #region Events

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            // Check if a dropdown menu is configured.
            if (this.DropDownMenu != null)
            {
                objEvents.Set(WGEvents.Click);
            }

            // Check if this is an accept button or a cancel button and that dialog
            // result is not none.
            else if (this.DialogResult != DialogResult.None)
            {
                objEvents.Set(WGEvents.Click);                
            }

            return objEvents;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            if (objEvent.Type == "Click")
            {
                // Disable button after click when ClickOnce property is true
                if (this.ClickOnce)
                {
                    // Set the control enabled mode
                    this.SetEnabledInternal(false);
                }

                // Get the drop down menu.
                Menu objMenu = this.DropDownMenu;
                if (objMenu != null)
                {
                    MouseButtons enmMouseButtons = GetEventButtonsValue(objEvent, MouseButtons.Left);
                    if (enmMouseButtons == MouseButtons.Left)
                    {
                        objMenu.Show(this, Point.Empty, DialogAlignment.Below);
                    }
                }
            }

            // Invoke base method
            base.FireEvent(objEvent);
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // render context menu if needed
            if (DropDownMenu != null)
            {
                objWriter.WriteAttributeString(WGAttributes.DropDown, "1");
            }

            // render ClickOnce attribute
            if (ClickOnce)
            {
                objWriter.WriteAttributeString(WGAttributes.ClickOnce, "1");
            }

        }

        /// <summary>
        /// Renders the back color attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderBackColorAttribute(IAttributeWriter objWriter, Color objBackColor)
        {
            if (!UseVisualStyleBackColor)
            {
                base.RenderBackColorAttribute(objWriter, objBackColor);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string strText = base.ToString();
            return (strText + ", Text: " + this.Text);
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="objProposedSize">The custom-sized area for a control.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            //Get the base preferd size
            Size objPreferredSize = base.GetPreferredSize(objProposedSize);

            //If the control is set to auto size
            if (this.AutoSize)
            {
                //Get the skin
                ButtonSkin objButtonSkin = this.Skin as ButtonSkin;

                //If we got a skin
                if (objButtonSkin != null)
                {
                    //Get the padding value
                    PaddingValue objPaddingValue = objButtonSkin.Padding;
                    if (objPaddingValue != null)
                    {
                        //Add the padding size
                        objPreferredSize.Width += objPaddingValue.Horizontal;
                        objPreferredSize.Height += objPaddingValue.Vertical;
                    }

                    // Add frame width and height
                    objPreferredSize.Width += objButtonSkin.LeftFrameWidth;
                    objPreferredSize.Width += objButtonSkin.RightFrameWidth;

                    objPreferredSize.Height += objButtonSkin.TopFrameHeight;
                    objPreferredSize.Height += objButtonSkin.BottomFrameHeight;
                }

                //Add the background image size
                if (this.ImageSize != null)
                {
                    if (this.Image != null || this.ImageIndex != -1 || this.ImageKey != string.Empty)
                    {
                        switch (this.TextImageRelation)
                        {
                            case TextImageRelation.ImageAboveText:
                            case TextImageRelation.TextAboveImage:
                                objPreferredSize.Height += ImageSize.Height;
                                objPreferredSize.Width = Math.Max(ImageSize.Width, objPreferredSize.Width);
                                break;
                            case TextImageRelation.TextBeforeImage:
                            case TextImageRelation.ImageBeforeText:
                                objPreferredSize.Width += ImageSize.Width;
                                objPreferredSize.Height = Math.Max(ImageSize.Height, objPreferredSize.Height);
                                break;

                            case TextImageRelation.Overlay:
                                objPreferredSize.Width = Math.Max(ImageSize.Width, objPreferredSize.Width);
                                objPreferredSize.Height = Math.Max(ImageSize.Height, objPreferredSize.Height);
                                break;
                        }
                    }
                }
            }
            return objPreferredSize;
        }


        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new ButtonRenderer(this);
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"/>
        /// event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(EventArgs objEventArgs)
        {
            // Get dialog result.
            DialogResult enmDialogResult = this.DialogResult;

            // Get owner form
            Form objOwnerForm = this.Form;
            if (objOwnerForm != null)
            {
                // Set ownre form's result.
                objOwnerForm.DialogResult = enmDialogResult;
            }

            base.OnClick(objEventArgs);

            if (objOwnerForm != null)
            {
                // Check if owner form is modal
                if ((objOwnerForm.DialogType == DialogTypes.ModalWindow || objOwnerForm.DialogType == DialogTypes.PopupWindow) && objOwnerForm.DialogResult != Forms.DialogResult.None)
                {
                    // Close owner form.
                    objOwnerForm.Close();
                }
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Defines a dropdown menu to the button
        /// </summary>
        [System.ComponentModel.DefaultValue(null)]
        public Menu DropDownMenu
        {
            get
            {
                return this.GetValue<Menu>(Button.DropDownMenuProperty);
            }
            set
            {
                // Try to set the menu and if menu had changed update the control
                if (this.SetValue<Menu>(Button.DropDownMenuProperty, value))
                {
                    // If there is a valid value
                    if (value != null)
                    {
                        // Set the menu parent
                        value.InternalParent = this;
                    }

                    // Redraw the button
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value that is returned to the parent form when the button is clicked.
        /// </summary>
        /// <value></value>
        [SRDescription("ButtonDialogResultDescr"), DefaultValue(DialogResult.None), SRCategory("CatBehavior")]
        public DialogResult DialogResult
        {
            get
            {
                return this.GetValue<DialogResult>(Button.DialogResultProperty);
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 7))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DialogResult));
                }

                this.SetValue<DialogResult>(Button.DialogResultProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
        /// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
        /// </summary>
        [Localizable(true), SRDescription("ControlAutoSizeModeDescr"), SRCategory("CatLayout"), DefaultValue(AutoSizeMode.GrowOnly), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override AutoSizeMode AutoSizeMode
        {
            get
            {
                return base.AutoSizeMode;
            }
            set
            {
                base.AutoSizeMode = value;
            }
        }

        /// <summary>
        /// Gets or sets the button style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(ButtonStyle.Normal)]
        public ButtonStyle ButtonStyle
        {
            get
            {
                return this.GetValue<ButtonStyle>(Button.ButtonStyleProperty);
            }
            set
            {
                // If the button style property changed
                if (this.SetValue<ButtonStyle>(Button.ButtonStyleProperty, value))
                {
                    // Update the button to reflect style changed
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the ClickOnce property.
        /// </summary>
        /// <value>The key down filter.</value>
        [System.ComponentModel.DefaultValue(false)]
        [SRDescription("ControlClickOnceDescr")]
        [SRCategory("CatBehavior")]
        public bool ClickOnce
        {
            get
            {
                return this.GetState(ComponentState.ClickOnce);
            }
            set
            {
                // Set the control clickonce value and update the control if value changed
                if (this.SetStateWithCheck(ComponentState.ClickOnce, value))
                {
                    this.Update();
                }
            }
        }
        #endregion Properties

        #region Default Member Values

        /// <summary>
        ///
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(75, 23);
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                base.BorderStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override BorderColor BorderColor
        {
            get
            {
                return base.BorderColor;
            }
            set
            {
                base.BorderColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override BorderWidth BorderWidth
        {
            get
            {
                return base.BorderWidth;
            }
            set
            {
                base.BorderWidth = value;
            }
        }

        #endregion Default Member Values

        #region IButtonControl Members

        /// <summary>
        /// Performs the click.
        /// </summary>
        public void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }

        /// <summary>
        /// Notifies the default.
        /// </summary>
        /// <param name="value">Value.</param>
        public void NotifyDefault(bool blnValue)
        {

        }

        #endregion

    }

    #endregion Button Class



    #region ButtonRenderer Class

    /// <summary>
    /// Provides support for rendering a Button control  
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class ButtonRenderer : ButtonBaseRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonRenderer"/> class.
        /// </summary>
        /// <param name="objButton">The Button control.</param>
        public ButtonRenderer(Button objButton)
            : base(objButton)
        {
        }


        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the button control
            Button objButton = this.Control as Button;
            if (objButton != null)
            {
                // Get the button skin
                ButtonSkin objButtonSkin = objButton.Skin as ButtonSkin;
                if (objButtonSkin != null)
                {
                    // If button is enabled
                    if (objButton.Enabled)
                    {
                        // Draw the normal style
                        RenderFrame(objContext, objGraphics, objButtonSkin, objButtonSkin.NormalStyle, GetContentRegion(objButton, false, false));
                    }
                    else
                    {
                        // Draw the frame style
                        RenderFrame(objContext, objGraphics, objButtonSkin, objButtonSkin.DisabledStyle, GetContentRegion(objButton, false, false));
                    }
                }
            }
        }

        


    }

    #endregion

}
