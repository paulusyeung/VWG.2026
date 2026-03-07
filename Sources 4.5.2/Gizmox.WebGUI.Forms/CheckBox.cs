#region Using

using System;
using System.Xml;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region CheckBox Class

    /// <summary>
    /// A checkBox control.
    /// </summary>
    [ToolboxItemCategory("Common Controls")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(CheckBox), "CheckBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(CheckBox), "CheckBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [MetadataTag(WGTags.CheckBox)]
    [Skin(typeof(CheckBoxSkin))]
    [Serializable()]
    [DefaultProperty("Checked"), SRDescription("DescriptionCheckBox"), DefaultEvent("CheckedChanged"), DefaultBindingProperty("CheckState")]
    public class CheckBox : ButtonBase
    {
        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to AutoCheck property.
        /// </summary>
        private static SerializableProperty AutoCheckProperty = SerializableProperty.Register("AutoCheck", typeof(bool), typeof(CheckBox), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to ThreeState property.
        /// </summary>
        private static SerializableProperty ThreeStateProperty = SerializableProperty.Register("ThreeState", typeof(bool), typeof(CheckBox), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to CheckState property.
        /// </summary>
        private static SerializableProperty CheckStateProperty = SerializableProperty.Register("CheckState", typeof(CheckState), typeof(CheckBox), new SerializablePropertyMetadata(CheckState.Unchecked));

        /// <summary>
        /// Provides a property reference to CheckAlign property.
        /// </summary>
        private static SerializableProperty CheckAlignProperty = SerializableProperty.Register("CheckAlign", typeof(ContentAlignment), typeof(CheckBox), new SerializablePropertyMetadata(ContentAlignment.MiddleLeft));

        /// <summary>
        /// Provides a property reference to Appearance property.
        /// </summary>
        private static SerializableProperty AppearanceProperty = SerializableProperty.Register("Appearance", typeof(Appearance), typeof(CheckBox), new SerializablePropertyMetadata(Appearance.Normal));

        #endregion Serializable Properties

        #region Serializable Events

        /// <summary>
        /// The CheckStateChangedQueued event registration.
        /// </summary>
        private static readonly SerializableEvent CheckStateChangedQueuedEvent = SerializableEvent.Register("CheckStateChangedQueued", typeof(EventHandler), typeof(CheckBox));

        /// <summary>
        /// The CheckStateChanged event registration.
        /// </summary>
        private static readonly SerializableEvent CheckStateChangedEvent = SerializableEvent.Register("CheckStateChanged", typeof(EventHandler), typeof(CheckBox));

        /// <summary>
        /// The CheckedChangedQueued event registration.
        /// </summary>
        private static readonly SerializableEvent CheckedChangedQueuedEvent = SerializableEvent.Register("CheckedChangedQueued", typeof(EventHandler), typeof(CheckBox));

        /// <summary>
        /// The CheckedChanged event registration.
        /// </summary>
        private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(CheckBox));

        #endregion Serializable Events

        #region Events Handlers

        /// <summary>
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("checkedChangedEventDescr"), Category("Client")]
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
        /// Occurs when the value of the Checked property changes.
        /// </summary>
        public event EventHandler CheckedChanged
        {
            add
            {
                this.AddCriticalHandler(CheckBox.CheckedChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(CheckBox.CheckedChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CheckedChanged event.
        /// </summary>
        private EventHandler CheckedChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(CheckBox.CheckedChangedEvent);
            }
        }

        /// <summary>
        /// Occurs when the value of the Checked property changes (Queued).
        /// </summary>
        public event EventHandler CheckedChangedQueued
        {
            add
            {
                this.AddHandler(CheckBox.CheckedChangedQueuedEvent, value);
            }
            remove
            {
                this.RemoveHandler(CheckBox.CheckedChangedQueuedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CheckedChangedQueued event.
        /// </summary>
        private EventHandler CheckedChangedQueuedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(CheckBox.CheckedChangedQueuedEvent);
            }
        }

        /// <summary>
        /// Occurs when the value of the CheckState property changes.
        /// </summary>
        public event EventHandler CheckStateChanged
        {
            add
            {
                this.AddCriticalHandler(CheckBox.CheckStateChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(CheckBox.CheckStateChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CheckStateChanged event.
        /// </summary>
        private EventHandler CheckStateChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(CheckBox.CheckStateChangedEvent);
            }
        }

        /// <summary>
        /// Occurs when the value of the CheckState property changes (Queued).
        /// </summary>
        public event EventHandler CheckStateChangedQueued
        {
            add
            {
                this.AddHandler(CheckBox.CheckStateChangedQueuedEvent, value);
            }
            remove
            {
                this.RemoveHandler(CheckBox.CheckStateChangedQueuedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CheckStateChangedQueued event.
        /// </summary>
        private EventHandler CheckStateChangedQueuedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(CheckBox.CheckStateChangedQueuedEvent);
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

        /// <summary>
        /// Gets the hanlder for the AppearanceChanged event.
        /// </summary>
        private EventHandler AppearanceChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(CheckBox.AppearanceChangedEvent);
            }
        }

        /// <summary>
        /// The AppearanceChanged event registration.
        /// </summary>
        private static readonly SerializableEvent AppearanceChangedEvent = SerializableEvent.Register("AppearanceChanged", typeof(EventHandler), typeof(CheckBox));

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> property changes.
        /// </summary>
        [SRDescription("CheckBoxOnAppearanceChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler AppearanceChanged
        {
            add
            {
                this.AddCriticalHandler(CheckBox.AppearanceChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(CheckBox.AppearanceChangedEvent, value);
            }
        }

        #endregion Events Handlers

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Creates a new <see cref="CheckBox"/> instance.
        /// </summary>
        public CheckBox()
        {
            // Set the auto check default value
            this.AutoCheck = true;

            base.SetStyle(ControlStyles.StandardDoubleClick | ControlStyles.StandardClick, false);

            // Set the default text align value
            this.TextAlign = ContentAlignment.MiddleLeft;

        }

        #endregion C'Tor/D'Tor

        #region Methods

        #region Render

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            bool blnChecked = this.Checked;

            CheckState enmCheckState = this.CheckState;

            // set the checkbox value
            if (blnChecked)
            {
                if (enmCheckState == CheckState.Indeterminate)
                {
                    objWriter.WriteAttributeString(WGAttributes.Checked, "2");
                }
                else
                {
                    objWriter.WriteAttributeString(WGAttributes.Checked, "1");
                }
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.Checked, "0");
            }

            if (!this.AutoCheck)
            {
                objWriter.WriteAttributeString(WGAttributes.AutoCheck, "0");
            }

            if (this.ThreeState)
            {
                objWriter.WriteAttributeString(WGAttributes.Mode, "3");
            }


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

            if (objAppearance != Forms.Appearance.Normal || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Appearance, ((int)objAppearance).ToString());
            }
        }

        /// <summary>
        /// Renders the visual template.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderVisualTemplate(IContext objContext, IAttributeWriter objWriter)
        {
            VisualTemplate objVisualTemplate = this.GetProxyPropertyValue<VisualTemplate>("VisualTemplate", this.VisualTemplate);

            if (objVisualTemplate == null && this.Appearance == Forms.Appearance.Switch)
            {
                objVisualTemplate = new CheckBoxSwitchVisualTemplate(false, 50, CheckBoxSwitchVisualTemplateSwitchSizing.Percent, string.Empty, string.Empty);
            }

            RenderVisualTemplate(objContext, objWriter, objVisualTemplate);
        }

        #endregion Render

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

                    // Get the checked state and set internal members
                    string strCheckState = objEvent[WGAttributes.Checked] as string;
                    switch (strCheckState)
                    {
                        case "0":
                            this.InternalCheckState = CheckState.Unchecked;
                            break;
                        case "1":
                            this.InternalCheckState = CheckState.Checked;
                            break;
                        case "2":
                            this.InternalCheckState = CheckState.Indeterminate;
                            break;
                    }
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
            if (CheckedChangedHandler != null || CheckStateChangedHandler != null)
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// <summary>
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
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckedChanged"></see> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCheckedChanged(EventArgs objEventArgs)
        {
            EventHandler objEventHandler = this.CheckedChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Raises the CheckedChangedQueued event
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCheckedChangedQueued(EventArgs objEventArgs)
        {
            EventHandler objEventHandler = this.CheckedChangedQueuedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckStateChanged"></see> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCheckStateChanged(EventArgs objEventArgs)
        {
            EventHandler objEventHandler = this.CheckStateChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckStateChanged"></see> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCheckStateChangedQueued(EventArgs objEventArgs)
        {
            EventHandler objEventHandler = this.CheckStateChangedQueuedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        #endregion Events

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
        /// </returns>
        public override string ToString()
        {
            string strText = base.ToString();
            int intCheckState = (int)this.CheckState;
            return string.Format("{0}, CheckState: {1}", strText, intCheckState.ToString());
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
                CheckBoxSkin objCheckBoxSkin = this.Skin as CheckBoxSkin;

                // Get radio button appreance.
                Appearance enmAppearance = this.Appearance;

                if (enmAppearance == Appearance.Normal)
                {
                    //If we got a skin
                    if (objCheckBoxSkin != null)
                    {
                        //Add the max of padding + border size in normal and focused style
                        objPreferredSize.Width += Math.Max(objCheckBoxSkin.LabelNormalStyle.Padding.Horizontal,objCheckBoxSkin.LabelFocusedStyle.Padding.Horizontal);
                        objPreferredSize.Width += Math.Max(objCheckBoxSkin.LabelNormalStyle.BorderStyle!= Forms.BorderStyle.None ? objCheckBoxSkin.LabelNormalStyle.BorderWidth.Left + objCheckBoxSkin.LabelNormalStyle.BorderWidth.Right : 0, objCheckBoxSkin.LabelFocusedStyle.BorderStyle!=Forms.BorderStyle.None ? objCheckBoxSkin.LabelFocusedStyle.BorderWidth.Left + objCheckBoxSkin.LabelFocusedStyle.BorderWidth.Right : 0);
                        objPreferredSize.Height += Math.Max(objCheckBoxSkin.LabelNormalStyle.Padding.Vertical, objCheckBoxSkin.LabelFocusedStyle.Padding.Vertical);
                        objPreferredSize.Height += Math.Max(objCheckBoxSkin.LabelNormalStyle.BorderStyle!= Forms.BorderStyle.None ? objCheckBoxSkin.LabelNormalStyle.BorderWidth.Top + objCheckBoxSkin.LabelNormalStyle.BorderWidth.Bottom : 0 , objCheckBoxSkin.LabelFocusedStyle.BorderStyle!=Forms.BorderStyle.None ? objCheckBoxSkin.LabelFocusedStyle.BorderWidth.Top + objCheckBoxSkin.LabelFocusedStyle.BorderWidth.Bottom : 0);
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
                                objPreferredSize.Height += objCheckBoxSkin.ButtonImageTextGap;
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
                if (objCheckBoxSkin != null)
                {
                    if (enmAppearance == Appearance.Normal)
                    {
                        //Add the state image size
                        objPreferredSize.Height = Math.Max(objCheckBoxSkin.CheckBoxImageHeight, objPreferredSize.Height);
                        objPreferredSize.Width += objCheckBoxSkin.CheckBoxImageWidth;
                        objPreferredSize.Width += objCheckBoxSkin.ButtonImageTextGap;
                    }
                    else if (enmAppearance == Appearance.Button)
                    {
                        objPreferredSize.Height += (objCheckBoxSkin.TopFrameHeight + objCheckBoxSkin.BottomFrameHeight);
                        objPreferredSize.Width += (objCheckBoxSkin.LeftFrameWidth + objCheckBoxSkin.RightFrameWidth);
                    }

                    //Get the padding value
                    PaddingValue objPaddingValue = objCheckBoxSkin.Padding;
                    if (objPaddingValue != null)
                    {
                        //Add the padding size
                        objPreferredSize.Width += objPaddingValue.Horizontal;
                        objPreferredSize.Height += objPaddingValue.Vertical;
                    }

                    if (objCheckBoxSkin.BorderStyle != Forms.BorderStyle.None)
                    {
                        objPreferredSize.Height += objCheckBoxSkin.BorderWidth.Top + objCheckBoxSkin.BorderWidth.Bottom;
                        objPreferredSize.Width += objCheckBoxSkin.BorderWidth.Left + objCheckBoxSkin.BorderWidth.Right;
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
            return new CheckBoxRenderer(this);
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets or sets the horizontal and vertical alignment of the check mark on a <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see> control.</summary>
        /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default value is MiddleLeft.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> enumeration values. </exception>
        [Bindable(true), SRCategory("CatAppearance"), DefaultValue(ContentAlignment.MiddleLeft), Localizable(true), SRDescription("CheckBoxCheckAlignDescr")]
        public ContentAlignment CheckAlign
        {
            get
            {
                return this.GetValue<ContentAlignment>(CheckBox.CheckAlignProperty);
            }
            set
            {
                if (ClientUtils.GetBitCount((uint)value) != 1)
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
                }

                if (this.SetValue<ContentAlignment>(CheckBox.CheckAlignProperty, value))
                {
                    this.Update();

                    FireObservableItemPropertyChanged("CheckAlign");
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether internal checked value.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if internal value is checked; otherwise, <c>false</c>.
        /// </value>
        internal CheckState InternalCheckState
        {
            get
            {
                return this.GetValue<CheckState>(CheckBox.CheckStateProperty);
            }
            set
            {

                // Get check state the old valud
                CheckState enmOldValue = this.GetValue<CheckState>(CheckBox.CheckStateProperty);

                // Make sure value had changed to prevent setting if not needed
                if (enmOldValue != value)
                {
                    // Set the new value of the check state
                    if (this.SetValue<CheckState>(CheckBox.CheckStateProperty, value))
                    {
                        // If checked changed
                        if (IsCheckedChanged(enmOldValue, value))
                        {
                            // Raise the check changed event
                            this.OnCheckedChanged(EventArgs.Empty);
                            this.OnCheckedChangedQueued(EventArgs.Empty);

                            FireObservableItemPropertyChanged("Checked");
                        }

                        // Raise check state changed
                        this.OnCheckStateChanged(EventArgs.Empty);
                        this.OnCheckStateChangedQueued(EventArgs.Empty);

                        FireObservableItemPropertyChanged("CheckState");
                    }
                }
            }
        }

        /// <summary>
        /// Returns a flag indicating if checked has changed
        /// </summary>
        /// <param name="enmValue1"></param>
        /// <param name="enmValue2"></param>
        /// <returns></returns>
        private bool IsCheckedChanged(CheckState enmValue1, CheckState enmValue2)
        {
            if (enmValue1 == CheckState.Unchecked)
            {
                return enmValue2 == CheckState.Indeterminate || enmValue2 == CheckState.Checked;
            }
            else
            {
                return enmValue2 == CheckState.Unchecked;
            }
        }

        /// <summary>
        /// Gets or sets the state of the check.
        /// </summary>
        /// <value>The state of the check from the CheckState enum. Default is CheckState.Unchecked.</value>
        [SRDescription("The state of the check from the CheckState enum"), RefreshProperties(RefreshProperties.All), Bindable(true), SRCategory("CatAppearance"), DefaultValue(CheckState.Unchecked)]
        public CheckState CheckState
        {
            get
            {
                //Get CheckState Property from property store
                return this.InternalCheckState;
            }
            set
            {
                // check if the set value is legal in the enum
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(CheckState));
                }

                if (this.CheckState != value)
                {
                    InternalCheckState = value;

                    this.Update();
                }
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether the check box will allow three check states rather than two.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [three state]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool ThreeState
        {
            get
            {
                return this.GetValue<bool>(CheckBox.ThreeStateProperty);
            }
            set
            {
                if (this.SetValue<bool>(CheckBox.ThreeStateProperty, value))
                {
                    this.Update();

                    this.FireObservableItemPropertyChanged("ThreeState");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CheckBox"/> is checked.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("Gets or sets a value indicating whether this CheckBox is Checked"), SRCategory("CatAppearance"), Bindable(true), DefaultValue(false), RefreshProperties(RefreshProperties.All), SettingsBindable(true)]
        public bool Checked
        {
            get
            {
                //return boolean depanding on CheckState value
                return (this.CheckState != CheckState.Unchecked);
            }
            set
            {
                //If value has changed, set CheckState.
                //CheckedChanged is fired from CheckState setter.
                if (this.Checked != value)
                {
                    this.CheckState = (value ? CheckState.Checked : CheckState.Unchecked);
                }
            }
        }

        /// <summary>Gets or set a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> or <see cref="P:Gizmox.WebGUI.Forms.CheckBox.CheckState"></see> values and the <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see>'s appearance are automatically changed when the <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see> is clicked.</summary>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> value or <see cref="P:Gizmox.WebGUI.Forms.CheckBox.CheckState"></see> value and the appearance of the control are automatically changed on the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event; otherwise, false. The default value is true.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("CheckBoxAutoCheckDescr"), DefaultValue(true), SRCategory("CatBehavior")]
        public bool AutoCheck
        {
            get
            {
                return this.GetValue<bool>(CheckBox.AutoCheckProperty);
            }
            set
            {
                if (this.SetValue<bool>(CheckBox.AutoCheckProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the flat style.
        /// </summary>
        /// <value></value>
        public FlatStyle FlatStyle
        {
            get
            {
                return FlatStyle.Standard;
            }
            set
            {

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
        /// Gets or sets the appearance.
        /// </summary>
        /// <value>The appearance.</value>
        [SRCategory("CatAppearance"), Localizable(true), SRDescription("CheckBoxAppearanceDescr"), DefaultValue(Appearance.Normal), ProxyBrowsable(true)]
        public Appearance Appearance
        {
            get
            {
                // Get AppearanceProperty from property store
                return this.GetValue<Appearance>(CheckBox.AppearanceProperty);
            }
            set
            {
                // Check if value has been cahnged.
                if (this.SetValue<Appearance>(CheckBox.AppearanceProperty, value))
                {
                    // Validate value.
                    if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                    {
                        throw new InvalidEnumArgumentException("value", (int)value, typeof(Appearance));
                    }

                    this.OnAppearanceChanged(EventArgs.Empty);

                    this.UpdateParams(AttributeType.Visual);

                    // Invalidates layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));
                }
            }
        }
        #endregion Properties
    }
    #endregion CheckBox Class

    #region CheckBoxRenderer Class

    /// <summary>
    /// Provides support for rendering CheckBoxes
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class CheckBoxRenderer : ButtonBaseRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxRenderer"/> class.
        /// </summary>
        /// <param name="objCheckBox">The checkbox.</param>
        internal CheckBoxRenderer(CheckBox objCheckBox)
            : base(objCheckBox)
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
            // Get the current CheckBox
            CheckBox objCheckBox = this.Control as CheckBox;
            if (objCheckBox != null)
            {
                CheckBoxSkin objCheckBoxSkin = objCheckBox.Skin as CheckBoxSkin;
                if (objCheckBoxSkin != null)
                {

                    ResourceHandle objCheckImage = null;

                    switch (objCheckBox.CheckState)
                    {
                        case CheckState.Checked:
                            objCheckImage = objCheckBoxSkin.GetResourceHandleFromReference(objCheckBoxSkin.CheckedCheckBoxImage);
                            break;
                        case CheckState.Indeterminate:
                            objCheckImage = objCheckBoxSkin.GetResourceHandleFromReference(objCheckBoxSkin.IndeterminateCheckBoxImage);
                            break;
                        case CheckState.Unchecked:
                            objCheckImage = objCheckBoxSkin.GetResourceHandleFromReference(objCheckBoxSkin.UnCheckedCheckBoxImage);
                            break;
                    }

                    objRegion = DockInRegion(objRegion, DockStyle.Left, RenderImage(objContext, objGraphics, objCheckImage, objRegion, ContentAlignment.MiddleLeft));
                }


            }

            base.RenderButtonContent(objContext, objGraphics, objButtonBase, objRegion);
        }

    }

    #endregion
}
