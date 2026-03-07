#region Using

using System;
using System.Xml;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region RadioButton Class

    /// <summary>
    /// Enables the user to select a single option from a group of choices when paired with other <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> controls.
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(RadioButton), "RadioButton_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(RadioButton), "RadioButton.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Checked")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Checked")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Checked")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Checked")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Checked")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Checked")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultBindingProperty("Checked")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Serializable()]
    [SRDescription("DescriptionRadioButton"), DefaultProperty("Checked"), DefaultEvent("CheckedChanged")]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.RadioButton)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.RadioButtonSkin))]
    public class RadioButton : ButtonBase
    {

        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to Checked property.
        /// </summary>
        private static SerializableProperty CheckedProperty = SerializableProperty.Register("Checked", typeof(bool), typeof(RadioButton), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to CheckAlign property.
        /// </summary>
        private static SerializableProperty CheckAlignProperty = SerializableProperty.Register("CheckAlign", typeof(ContentAlignment), typeof(RadioButton), new SerializablePropertyMetadata(ContentAlignment.MiddleLeft));

        /// <summary>
        /// Provides a property reference to Appearance property.
        /// </summary>
        private static SerializableProperty AppearanceProperty = SerializableProperty.Register("Appearance", typeof(Appearance), typeof(RadioButton), new SerializablePropertyMetadata(Appearance.Normal));

        #endregion Serializable Properties

        /// <summary>
        /// Gets the hanlder for the AppearanceChanged event.
        /// </summary>
        private EventHandler AppearanceChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(RadioButton.AppearanceChangedEvent);
            }
        }

        /// <summary>
        /// The AppearanceChanged event registration.
        /// </summary>
        private static readonly SerializableEvent AppearanceChangedEvent = SerializableEvent.Register("AppearanceChanged", typeof(EventHandler), typeof(RadioButton));

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.RadioButton.Checked"></see> property changes.
        /// </summary>
        [SRDescription("RadioButtonOnAppearanceChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler AppearanceChanged
        {
            add
            {
                this.AddCriticalHandler(RadioButton.AppearanceChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(RadioButton.AppearanceChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CheckedChanged event.
        /// </summary>
        private EventHandler CheckedChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(RadioButton.CheckedChangedEvent);
            }
        }

        /// <summary>
        /// The CheckedChanged event registration.
        /// </summary>
        private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(RadioButton));

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.RadioButton.Checked"></see> property changes.
        /// </summary>
        [SRDescription("RadioButtonOnCheckedChangedDescr")]
        public event EventHandler CheckedChanged
        {
            add
            {
                this.AddCriticalHandler(RadioButton.CheckedChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(RadioButton.CheckedChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("valueChangedEventDescr"), Category("Client")]
        public event ClientEventHandler ClientCheckedChanged
        {
            add
            {
                this.AddClientHandler("ValueChange", value);
            }
            remove
            {
                this.RemoveClientHandler("ValueChange", value);
            }
        }

        /// <summary>
        /// Occurs when checked property value queued for change.
        /// </summary>
        public event EventHandler CheckedChangedQueued;

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> class.
        /// </summary>
        public RadioButton()
        {
            base.SetStyle(ControlStyles.StandardClick, false);

            // Set the defaul text align value
            this.TextAlign = ContentAlignment.MiddleLeft;
        }

        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Add attributes to control element
            objWriter.WriteAttributeString(WGAttributes.Checked, this.Checked ? "1" : "0");

            // Set the content alignment of the check image
            objWriter.WriteAttributeString(WGAttributes.ContentAlign, this.CheckAlign.ToString());

            RenderAppearanceAttribute(objWriter, false);
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Render the Appearance attribute
                RenderAppearanceAttribute(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the appearance attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            Appearance objAppearance = this.GetProxyPropertyValue<Appearance>("Appearance", this.Appearance);

            if (objAppearance == Forms.Appearance.Button || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Appearance, ((int)objAppearance).ToString());
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}, Checked: {1}", base.ToString(), this.Checked.ToString());
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
                RadioButtonSkin objRadioButtonSkin = this.Skin as RadioButtonSkin;

                // Get radio button appreance.
                Appearance enmAppearance = this.Appearance;

                if (enmAppearance == Appearance.Normal)
                {
                    //If we got a skin
                    if (objRadioButtonSkin != null)
                    {
                        //Add the padding size
                        objPreferredSize.Width += objRadioButtonSkin.TextNormalStyle.Padding.Horizontal;
                        objPreferredSize.Height += objRadioButtonSkin.TextNormalStyle.Padding.Vertical;
                    }

                    //Add the back ground image size
                    if (this.HasImageSize || this.Image != null)
                    {
                        switch (this.TextImageRelation)
                        {
                            case TextImageRelation.Overlay:
                                objPreferredSize.Width = Math.Max(ImageSize.Width, objPreferredSize.Width);
                                objPreferredSize.Height = Math.Max(ImageSize.Height, objPreferredSize.Height);
                                break;
                            case TextImageRelation.ImageAboveText:
                            case TextImageRelation.TextAboveImage:
                                objPreferredSize.Width = Math.Max(ImageSize.Width, objPreferredSize.Width);
                                objPreferredSize.Height += ImageSize.Height;
                                objPreferredSize.Height += objRadioButtonSkin.ButtonImageTextGap;
                                break;
                            case TextImageRelation.TextBeforeImage:
                            case TextImageRelation.ImageBeforeText:
                                objPreferredSize.Width += ImageSize.Width;
                                objPreferredSize.Height = Math.Max(ImageSize.Height, objPreferredSize.Height);
                                break;
                        }
                    }
                }

                //If we got a skin
                if (objRadioButtonSkin != null)
                {
                    if (enmAppearance == Appearance.Normal)
                    {
                        //Add the state image size
                        objPreferredSize.Height = Math.Max(objRadioButtonSkin.RadioImageHeight, objPreferredSize.Height);
                        objPreferredSize.Width += objRadioButtonSkin.RadioImageWidth;
                        objPreferredSize.Width += objRadioButtonSkin.ButtonImageTextGap;
                    }
                    else if (enmAppearance == Appearance.Button)
                    {
                        objPreferredSize.Height += (objRadioButtonSkin.TopFrameHeight + objRadioButtonSkin.BottomFrameHeight);
                        objPreferredSize.Width += (objRadioButtonSkin.LeftFrameWidth + objRadioButtonSkin.RightFrameWidth);
                    }

                    //Get the padding value
                    PaddingValue objPaddingValue = objRadioButtonSkin.Padding;
                    if (objPaddingValue != null)
                    {
                        //Add the padding size
                        objPreferredSize.Width += objPaddingValue.Horizontal;
                        objPreferredSize.Height += objPaddingValue.Vertical;
                    }
                }
            }
            return objPreferredSize;
        }
        /// <summary>
        /// Handles the check.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> [value].</param>
        /// <param name="blnUpdateSibling">if set to <c>true</c> [BLN update sibling].</param>
        private void SetChecked(bool blnValue, bool blnUpdateSibling)
        {

            //set new value
            this.InternalChecked = blnValue;

            // If checked is true
            if (blnValue)
            {
                // If there is a valid parent
                if (this.Parent != null)
                {
                    // Loop all child control of parent control
                    foreach (Control objControl in this.Parent.Controls)
                    {
                        // Try to get radio button
                        RadioButton objRadioButton = objControl as RadioButton;
                        if (objRadioButton != null)
                        {
                            // If not current radio button
                            if (objRadioButton != this)
                            {
                                // If radio button is checked
                                if (objRadioButton.InternalChecked)
                                {
                                    // Uncheck radio button
                                    objRadioButton.InternalChecked = false;

                                    // Raise event if needed
                                    if (objRadioButton.CheckedChangedHandler != null)
                                    {
                                        objRadioButton.CheckedChangedHandler(objRadioButton, EventArgs.Empty);
                                    }

                                    // Raise queued event if needed
                                    if (objRadioButton.CheckedChangedQueued != null)
                                    {
                                        objRadioButton.CheckedChangedQueued(objRadioButton, EventArgs.Empty);
                                    }

                                    // Update radio button to reflect changes
                                    if (blnUpdateSibling)
                                    {
                                        objRadioButton.Update();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Raise event if needed
            this.OnCheckedChanged(EventArgs.Empty);

            // Raise queued event if needed
            EventHandler objEventHandler = this.CheckedChangedQueued;
            if (objEventHandler != null)
            {
                CheckedChangedQueued(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new RadioButtonRenderer(this);
        }

        #region Events

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {

            // Select event type
            switch (objEvent.Type)
            {
                case "ValueChange":
                    // set the new checked value
                    SetChecked(true, false);
                    break;
            }

            base.FireEvent(objEvent);

        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (CheckedChangedHandler != null)
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.HasClientHandler("ValueChange"))
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.CheckBox.CheckedChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.CheckedChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:AppearanceChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnAppearanceChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.AppearanceChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #endregion Events

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        ///	<returns>true if the check box is checked; otherwise, false.</returns>
        [DefaultValue(false), SRDescription("RadioButtonCheckedDescr"), SRCategory("CatAppearance"), Bindable(true)]
        public bool Checked
        {
            get
            {
                return InternalChecked;
            }
            set
            {
                // If checked value has changed
                if (this.Checked != value)
                {
                    // set the new checked value
                    SetChecked(value, true);

                    // Update this radio button(as selected)
                    this.Update();
                }
            }

        }

        /// <summary>
        /// Sets a value indicating whether internal checked value.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if internal value is checked; otherwise, <c>false</c>.
        /// </value>
        internal bool InternalChecked
        {
            get
            {
                return this.GetValue<bool>(RadioButton.CheckedProperty);
            }
            set
            {
                this.SetValue<bool>(RadioButton.CheckedProperty, value);
            }
        }

        /// <summary>Gets or sets the horizontal and vertical alignment of the check mark on a <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> control.</summary>
        /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default value is MiddleLeft.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> enumeration values. </exception>
        [Bindable(true), SRCategory("CatAppearance"), DefaultValue(ContentAlignment.MiddleLeft), Localizable(true), SRDescription("RadioButtonCheckAlignDescr")]
        public ContentAlignment CheckAlign
        {
            get
            {
                // Get CheckAlignProperty from property store
                return this.GetValue<ContentAlignment>(RadioButton.CheckAlignProperty);
            }
            set
            {
                if (ClientUtils.GetBitCount((uint)value) != 1)
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
                }
                if (this.SetValue<ContentAlignment>(RadioButton.CheckAlignProperty, value))
                {
                    // Update control
                    this.Update();

                    FireObservableItemPropertyChanged("CheckAlign");
                }
            }
        }

        /// <summary>
        /// Gets or sets the appearance.
        /// </summary>
        /// <value>The appearance.</value>
        [SRCategory("CatAppearance"), Localizable(true), SRDescription("RadioButtonAppearanceDescr"), DefaultValue(Appearance.Normal), ProxyBrowsable(true)]
        public Appearance Appearance
        {
            get
            {
                // Get AppearanceProperty from property store
                return this.GetValue<Appearance>(RadioButton.AppearanceProperty);
            }
            set
            {
                // Validate value.
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(Appearance));
                }

                // Check if value has been changed.
                if (this.SetValue<Appearance>(RadioButton.AppearanceProperty, value))
                {
                    this.OnAppearanceChanged(EventArgs.Empty);

                    this.UpdateParams(AttributeType.Visual);

                    // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));
                }
            }
        }



        /// <summary>
        /// Gets or sets the alignment of the text on the <see cref="T:Gizmox.WebGUI.Forms.CheckBox">
        /// </see> control.
        /// </summary>
        /// <returns>
        /// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleLeft"></see>.
        /// </returns>
        [DefaultValue(ContentAlignment.MiddleLeft), Localizable(true)]
        public override ContentAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
            set
            {
                base.TextAlign = value;
            }
        }

        /// <summary>
        /// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
        /// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
        /// </summary>
        /// <value></value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override AutoSizeMode AutoSizeMode
        {
            get
            {
                return AutoSizeMode.GrowAndShrink;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is defined for tabbing as group.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is tab for group; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        protected override bool EnableGroupTabbing
        {
            get
            {

                return true;
            }
        }
        #endregion Properties
    }

    #endregion RadioButton Class

    #region CheckBoxRenderer Class

    /// <summary>
    /// Provides support for rendering RadioButtones
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class RadioButtonRenderer : ButtonBaseRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButtonRenderer"/> class.
        /// </summary>
        /// <param name="objRadioButton">The RadioButton.</param>
        internal RadioButtonRenderer(RadioButton objRadioButton)
            : base(objRadioButton)
        {
        }


        /// <summary>
        /// Renders the content of the button.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objButtonBase">The button base.</param>
        /// <param name="objRegion">The region.</param>
        protected override void RenderButtonContent(ControlRenderingContext objContext, Graphics objGraphics, ButtonBase objButtonBase, Rectangle objRegion)
        {
            // Get the current RadioButton
            RadioButton objRadioButton = this.Control as RadioButton;
            if (objRadioButton != null)
            {
                RadioButtonSkin objRadioButtonSkin = objRadioButton.Skin as RadioButtonSkin;
                if (objRadioButtonSkin != null)
                {

                    ResourceHandle objCheckImage = null;

                    if (objRadioButton.Checked)
                    {
                        objCheckImage = objRadioButtonSkin.GetResourceHandleFromReference(objRadioButtonSkin.CheckedRadioImage);
                    }
                    else
                    {
                        objCheckImage = objRadioButtonSkin.GetResourceHandleFromReference(objRadioButtonSkin.UnCheckedRadioImage);
                    }


                    objRegion = DockInRegion(objRegion, DockStyle.Left, RenderImage(objContext, objGraphics, objCheckImage, objRegion, ContentAlignment.MiddleLeft));
                }


            }

            base.RenderButtonContent(objContext, objGraphics, objButtonBase, objRegion);
        }

    }

    #endregion
}
