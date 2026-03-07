#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Configuration;
using System.Globalization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;
using System.IO;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Specifies constants that define the state of the link.
    /// </summary>
    [Serializable]
    public enum LinkState
    {
        /// <summary>
        /// The state of a link that has been clicked.
        /// </summary>
        Active = 2,
        /// <summary>
        /// The state of a link over which a mouse pointer is resting.
        /// </summary>
        Hover = 1,
        /// <summary>
        /// The state of a link in its normal state (none of the other states apply).
        /// </summary>
        Normal = 0,
        /// <summary>
        /// The state of a link that has been visited.
        /// </summary>
        Visited = 4
    }

    /// <summary>
    /// Specifies the behaviors of a link in a <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see>.
    /// </summary>
    [Serializable]
    public enum LinkBehavior
    {
        /// <summary>
        /// The behavior of this setting depends on the options set using the Internet Options dialog box in Control Panel or Internet Explorer.
        /// </summary>
        SystemDefault,
        /// <summary>
        /// The link always displays with underlined text.
        /// </summary>
        AlwaysUnderline,
        /// <summary>
        /// The link displays underlined text only when the mouse is hovered over the link text.
        /// </summary>
        HoverUnderline,
        /// <summary>
        /// The link text is never underlined. The link can still be distinguished from other text by use of the <see cref="P:Gizmox.WebGUI.Forms.LinkLabel.LinkColor"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> control.
        /// </summary>
        NeverUnderline
    }
    #endregion

    #region LinkLabelLinkClickedEventArgs Class

    /// <summary>
    /// Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.LinkLabel.LinkClicked"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see>.
    /// </summary>
    public delegate void LinkLabelLinkClickedEventHandler(object sender, LinkLabelLinkClickedEventArgs e);

    /// <summary>
    /// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.LinkLabel.LinkClicked"></see> event.
    /// </summary>

    [Serializable()]
    public class LinkLabelLinkClickedEventArgs : EventArgs
    {
        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventArgs"></see> class with the specified link.
        /// </summary>
        ///	<param name="objLink">The <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> that was clicked. </param>
        public LinkLabelLinkClickedEventArgs(LinkLabel.Link objLink)
        {
            mobjLink = objLink;
        }

        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        /// Gets the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> that was clicked.
        /// </summary>
        ///	<returns>A link on the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see>.</returns>
        public LinkLabel.Link Link
        {
            get
            {
                return mobjLink;
            }
        }

        #endregion Properties

        #region Class Members

        private readonly LinkLabel.Link mobjLink;

        #endregion Class Members

    }

    #endregion LinkLabelLinkClickedEventArgs Class

    #region LinkLabel Class

    /// <summary>
    /// Represents a Gizmox.WebGUI.Forms label control that can display hyperlinks.
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(LinkLabel), "LinkLabel_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(LinkLabel), "LinkLabel.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [SRDescription("DescriptionLinkLabel"), DefaultEvent("LinkClicked")]
    [System.ComponentModel.ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.LinkLabel)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.LinkLabelSkin)), Serializable()]
    public class LinkLabel : Label, IButtonControl
    {
        /// <summary>
        /// Provides a property reference to Link property.
        /// </summary>
        private static SerializableProperty LinkProperty = SerializableProperty.Register("Link", typeof(Link), typeof(LinkLabel));

        /// <summary>
        /// Provides a property reference to ClientMode property.
        /// </summary>
        private static SerializableProperty ClientModeProperty = SerializableProperty.Register("ClientMode", typeof(bool), typeof(LinkLabel));

        /// <summary>
        /// Provides a property reference to DialogResult property.
        /// </summary>
        private static SerializableProperty DialogResultProperty = SerializableProperty.Register("DialogResult", typeof(DialogResult), typeof(LinkLabel));

        /// <summary>
        /// 
        /// </summary>
        private static SerializableProperty LinkColorProperty = SerializableProperty.Register("LinkColor", typeof(Color), typeof(LinkLabel));

        #region Classes

        /// <summary>
        /// Represents a link within a <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> control.
        /// </summary>

        [Serializable()]
        public class Link : ILink
        {
            #region Class Members

            private string mstrUrl = "";

            private object mobjLinkData = null;

            #endregion Class Members

            #region C'Tor / D'Tor

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> class.
            /// </summary>
            internal Link(string strUrl)
            {
                mstrUrl = strUrl;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> class.
            /// </summary>
            internal Link(LinkLabel objLinkLabel, string strUrl)
                : this(strUrl)
            {

            }

            #endregion C'Tor / D'Tor

            #region Methods

            /// <summary>
            /// Opens the specified link.
            /// </summary>
            /// <param name="objLink">The link.</param>
            public static void Open(LinkLabel.Link objLink)
            {
                Global.Context.OpenLink((ILink)objLink);
            }

            #endregion Methods

            #region Properties

            /// <summary>
            /// Gets or sets the URL.
            /// </summary>
            /// <value>The URL.</value>
            internal string Url
            {
                get
                {
                    return mstrUrl;
                }
                set
                {
                    mstrUrl = value;
                }
            }

            /// <summary>
            /// Gets the URL.
            /// </summary>
            /// <value>The URL.</value>
            string ILink.Url
            {
                get
                {
                    return mstrUrl;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether the link is enabled.
            /// </summary>
            /// <returns>true if the link is enabled; otherwise, false.</returns>
            [DefaultValue(true)]
            public bool Enabled
            {
                get
                {
                    return true;
                }
                set
                {
                }
            }

            /// <summary>
            /// Gets or sets the number of characters in the link text.
            /// </summary>
            /// <returns>The number of characters, including spaces, in the link text.</returns>
            public int Length
            {
                get
                {
                    return 0;
                }
                set
                {
                }
            }

            /// <summary>
            /// Gets or sets the data associated with the link.
            /// </summary>
            /// <returns>An <see cref="T:System.Object"></see> representing the data associated with the link.</returns>
            [DefaultValue((string)null)]
            public object LinkData
            {
                get
                {
                    return mobjLinkData;
                }
                set
                {
                    mobjLinkData = value;
                }
            }

            /// <summary>
            /// Gets or sets the starting location of the link within the text of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see>.
            /// </summary>
            /// <returns>The location within the text of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> control where the link starts.</returns>
            public int Start
            {
                get
                {
                    return 0;
                }
                set
                {
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether the user has visited the link.
            /// </summary>
            /// <returns>true if the link has been visited; otherwise, false.</returns>
            [DefaultValue(true)]
            public bool Visited
            {
                get
                {
                    // TODO: Consider changing the default to "false" as it's appears in the .NET Framework documentation.
                    return true;
                }
                set
                {
                }
            }

            #endregion Properties

        }

        #endregion Classes

        /// <summary>
        /// Occurs when a link is clicked within the control.
        /// </summary>
        public event LinkLabelLinkClickedEventHandler LinkClicked;

        #region Class Members


        /// <summary>
        /// Gets or sets the color of the link.
        /// </summary>
        /// <value>The color of the link.</value>
        [SRDescription("LinkLabelLinkColorDescr"), SRCategory("CatAppearance")]
        public Color LinkColor
        {
            get
            {
                Color objColor = this.GetValue<Color>(LinkLabel.LinkColorProperty, Color.Empty);
                if (objColor != Color.Empty)
                {
                    return objColor;
                }

                //Get the default value from the skin 
                LinkLabelSkin objSkin = this.Skin as LinkLabelSkin;

                if (objSkin != null)
                {
                    return (Color)objSkin.LinkColor;
                }
                return Color.Blue;

            }
            set
            {
                if (this.LinkColor != value)
                {
                    if (value == Color.Empty)
                    {
                        this.RemoveValue<Color>(LinkLabel.LinkColorProperty);
                    }
                    else
                    {
                        this.SetValue<Color>(LinkLabel.LinkColorProperty, value);
                    }
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Resets the color of the link.
        /// </summary>
        private void ResetLinkColor()
        {
            LinkLabelSkin objSkin = this.Skin as LinkLabelSkin;

            // Set value from skin, or blue.
            this.LinkColor =Color.Empty;            
        }

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new default instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
        /// </summary>
        public LinkLabel()
            : base()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.StandardClick | ControlStyles.ResizeRedraw | ControlStyles.Opaque | ControlStyles.UserPaint, true);
            this.TabStop = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
        /// </summary>
        /// <param name="strText">Label text.</param>
        public LinkLabel(string strText)
            : base(strText)
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.StandardClick | ControlStyles.ResizeRedraw | ControlStyles.Opaque | ControlStyles.UserPaint, true);
            this.TabStop = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
        /// </summary>
        /// <param name="strText">Label text.</param>
        /// <param name="strUrl">Label url.</param>
        public LinkLabel(string strText, string strUrl)
            : base(strText)
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.StandardClick | ControlStyles.ResizeRedraw | ControlStyles.Opaque | ControlStyles.UserPaint, true);
            this.InternalLink = new Link(strUrl);
            this.TabStop = true;
        }


        #endregion C'Tor / D'Tor

        #region Methods

        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderUrlAttribute(objWriter, false);
        }

        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
        
             if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                RenderUrlAttribute(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the URL attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderUrlAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.ClientMode && (!string.IsNullOrEmpty(this.Url) || blnForceRender))
            {
                objWriter.WriteAttributeString(WGAttributes.Value, this.Url);
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();
            if (this.LinkClicked != null || (!this.ClientMode && !string.IsNullOrEmpty(this.Url)))
            {
                objEvents.Set(WGEvents.Click);
            }

            return objEvents;
        }

        

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="objProposedSize">The custom-sized area for a control.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            Size objPreferredSize = base.GetPreferredSize(objProposedSize);

            if (this.AutoSize)
            {
                int intContentStylePaddingHorizontal = 0;
                int intContentStyleMarginHorizontal = 0;
                int intContentStylePaddingVertical = 0;
                int intContentStyleMarginVertical = 0;

                int intMaximumWidth = -1;

                // Get label skin.
                LinkLabelSkin objLinkLabelSkin = this.Skin as LinkLabelSkin;
                if (objLinkLabelSkin != null)
                {
                    // Get content style.
                    StyleValue objContentStyle = objLinkLabelSkin.ContentStyle;
                    if (objContentStyle != null)
                    {
                        // Get padding and margin values to prefered size.
                        intContentStylePaddingHorizontal = objContentStyle.Padding.Horizontal;
                        intContentStyleMarginHorizontal = objContentStyle.Margin.Horizontal;
                        intContentStylePaddingVertical = objContentStyle.Padding.Vertical;
                        intContentStyleMarginVertical = objContentStyle.Margin.Vertical;
                    }
                }

                Size objMaximumSize = this.MaximumSize;
                if (!objMaximumSize.IsEmpty)
                {
                    intMaximumWidth = objMaximumSize.Width - intContentStylePaddingHorizontal - intContentStyleMarginHorizontal;
                }

                objPreferredSize = CommonUtils.GetStringMeasurements(this.Text, this.Font, intMaximumWidth);

                // Add padding and margin values to prefered size.
                objPreferredSize.Width += (intContentStylePaddingHorizontal + intContentStyleMarginHorizontal);
                objPreferredSize.Height += (intContentStylePaddingVertical + intContentStyleMarginVertical);
            }

            return objPreferredSize;
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"/>
        /// event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(EventArgs objEventArgs)
        {
            base.OnClick(objEventArgs);

            Link objLink = this.InternalLink;

            if (!this.ClientMode && objLink != null && !string.IsNullOrEmpty(objLink.Url))
            {
                Link.Open(objLink);
            }

            this.OnLinkClicked(new LinkLabelLinkClickedEventArgs(objLink));
        }

        /// <summary>
        /// Invokes LinkClicked event.
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected virtual void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
        {
            // Raise event if needed
            LinkLabelLinkClickedEventHandler objEventHandler = this.LinkClicked;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Renders the color of the fore.
        /// </summary>
        /// <returns></returns>
        protected override Color GetForeColor()
        {
            return this.LinkColor;
        }

        #endregion Methods

        #region Properties


        /// <summary>
        /// Shoulds the serialize URL.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeUrl()
        {
            Link objLink = this.InternalLink;
            return (objLink != null && !string.IsNullOrEmpty(objLink.Url));
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [DefaultValue("")]
        public string Url
        {
            get
            {
                Link objLink = this.InternalLink;
                if (objLink != null)
                {
                    return objLink.Url;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.InternalLink = new Link(value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [client mode].
        /// </summary>
        /// <value><c>true</c> if [client mode]; otherwise, <c>false</c>.</value>
        [SRDescription("LinkLabelClientModeDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public bool ClientMode
        {
            get
            {
                return this.GetValue<bool>(LinkLabel.ClientModeProperty, false);
            }
            set
            {
                //If the value has changed
                if (this.ClientMode != value)
                {
                    if (!value)
                    {
                        this.RemoveValue<bool>(LinkLabel.ClientModeProperty);
                    }
                    else
                    {
                        this.SetValue<bool>(LinkLabel.ClientModeProperty, value);
                    }

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the internal link.
        /// </summary>
        /// <value>The internal link.</value>
        private Link InternalLink
        {
            get
            {
                return this.GetValue<Link>(LinkLabel.LinkProperty, new Link(""));
            }
            set
            {
                //If the value changed
                if (this.InternalLink != value)
                {
                    Link objOriginalInternalLink = this.InternalLink;

                    //Set the value in the property store
                    this.SetValue<Link>(LinkLabel.LinkProperty, value);

                    if (ClientMode == true)
                    {
                        // NOTE: In case of url change we just call the UpdateParams, that will cause the 
                        // RenderUpdatedAttributes to be called, and there we will render the url with the new value.
                        if (objOriginalInternalLink.Url != InternalLink.Url)
                        {
                            UpdateParams(AttributeType.Control, false);
                        }
                    }
                    else
                    {
                        // NOTE: We must update the link label if the link was not set and now set or vise versa. 
                        // When the link is set the click is critical event, and when the link is not set, the click is not critical.
                        if (objOriginalInternalLink.Url == "" && InternalLink.Url != "" ||
                            objOriginalInternalLink.Url != "" && InternalLink.Url == "")
                        {                            
                            UpdateParams(AttributeType.Events, false);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the value returned to the parent form when the
        /// button is clicked.
        /// </summary>
        /// <value></value>
        DialogResult IButtonControl.DialogResult
        {
            get
            {
                return this.GetValue<DialogResult>(LinkLabel.DialogResultProperty, DialogResult.None);
            }
            set
            {
                if (value == DialogResult.None)
                {
                    // Remove DialogResultProperty value which will revert to default .
                    this.RemoveValue<DialogResult>(LinkLabel.DialogResultProperty);
                }
                else
                {
                    //Set DialogResultProperty to property store
                    this.SetValue<DialogResult>(LinkLabel.DialogResultProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [RefreshProperties(RefreshProperties.Repaint)]
        public override Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports key navigation].
        /// </summary>
        /// <value>
        /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
        /// </value>
        protected override bool SupportsKeyNavigation
        {
            get
            {
                return false;
            }
        }

        #endregion Properties

        #region IButtonControl Members

        /// <summary>
        /// Performs the click.
        /// </summary>
        void IButtonControl.PerformClick()
        {
            OnClick(EventArgs.Empty);
        }


        /// <summary>
        /// Notifies the default.
        /// </summary>
        /// <param name="value">Value.</param>
        void IButtonControl.NotifyDefault(bool blnValue)
        {

        }

        #endregion

    }

    #endregion LinkLabel Class

    #region Link Class

    /// <summary>
    /// The Link class provides services for opening links in a new window
    /// </summary>

    [Serializable()]
    public class Link : ILink
    {
        /// <summary>
        /// The current link url
        /// </summary>
        private string mstrUrl = string.Empty;

        /// <summary>
        /// Create a new link object
        /// </summary>
        /// <param name="strUrl"></param>
        internal Link(string strUrl)
        {
            mstrUrl = strUrl;
        }

        /// <summary>
        /// Opens a new url
        /// </summary>
        /// <param name="strUrl">The url to open</param>
        public static void Open(string strUrl)
        {
            Global.Context.OpenLink((ILink)new Link(strUrl));
        }

        /// <summary>
        /// Opens a new url with window parameters
        /// </summary>
        /// <param name="strUrl">The url to open</param>
        /// <param name="objLinkParameters">The link window paramters</param>
        public static void Open(string strUrl, LinkParameters objLinkParameters)
        {
            Global.Context.OpenLink((ILink)new Link(strUrl), (ILinkParameters)objLinkParameters);
        }

        /// <summary>
        /// Download a resource handle with content disposition to force browser save as.
        /// </summary>
        /// <param name="objResourceHandle">The resource handle to download its content.</param>
        /// <remarks>
        /// Only local server resource handles (such as ImageResourceHandle, GatewayResourceHandle) can be downloaded using the content disposition header and
        /// non local server resources (such as UrlResourceHandle) will be opened in a blank window.
        /// </remarks>
        public static void Download(ResourceHandle objResourceHandle)
        {
            // Generate a file name
            string strFileName = Path.GetFileName(objResourceHandle.File);

            // Download the resource
            Download(objResourceHandle, strFileName);
            
        }

        /// <summary>
        /// Download a resource handle with content disposition to force browser save as.
        /// </summary>
        /// <param name="objResourceHandle">The resource handle to download its content.</param>
        /// <param name="strFileName">The file name to give the downloaded file.</param>
        /// <remarks>
        /// Only local server resource handles (such as ImageResourceHandle, GatewayResourceHandle) can be downloaded using the content disposition header and
        /// non local server resources (such as UrlResourceHandle) will be opened in a blank window.
        /// </remarks> 
        public static void Download(ResourceHandle objResourceHandle, string strFileName)
        {
            // Create open link parameters
            LinkParameters objLinkParameters = new LinkParameters();

            // If is a server resource we can download it with content disposition prameter
            if (objResourceHandle.IsServerResource)
            {
                // Add content disposition paramter
                objLinkParameters.QueryString["content-disposition"] = strFileName;
                objLinkParameters.Target = "_self";
            }
            else
            {
                // Simply open the url
                objLinkParameters.Target = "_blank";
            }

            // Open the link
            Link.Open(objResourceHandle.ToString(), objLinkParameters);
        }


        /// <summary>
        /// Opens a gateway link
        /// </summary>
        /// <param name="objGatewayReference">The gateway reference</param>
        public static void Open(GatewayReference objGatewayReference)
        {
            Open(objGatewayReference.ToString());
        }

        /// <summary>
        /// Opens a gateway link with parameters
        /// </summary>
        /// <param name="objGatewayReference">The gateway reference</param>
        /// <param name="objLinkParameters">The link window paramters</param>
        public static void Open(GatewayReference objGatewayReference, LinkParameters objLinkParameters)
        {
            Open(objGatewayReference.ToString(), objLinkParameters);
        }

        /// <summary>
        /// Opens a form reference link
        /// </summary>
        /// <param name="objFormReference">The form reference</param>
        public static void Open(FormReference objFormReference)
        {
            Open(objFormReference, new LinkParameters());
        }

        /// <summary>
        /// Opens a form reference link with parameters
        /// </summary>
        /// <param name="objFormReference">The form reference</param>
        /// <param name="objLinkParameters">The link window paramters</param>
        public static void Open(FormReference objFormReference, LinkParameters objLinkParameters)
        {
            // Ensure valid link parameters instance
            if (objLinkParameters == null)
            {
                objLinkParameters = new LinkParameters();
            }

            Global.Context.OpenLink((ILink)objFormReference, (ILinkParameters)objLinkParameters);
        }

        /// <summary>
        /// Gets the link url
        /// </summary>
        public string Url
        {
            get
            {
                return mstrUrl;
            }
        }
    }

    #endregion

    #region LinkParameters Class

    /// <summary>
    /// Holds window parameters for opening links
    /// </summary>

    [Serializable()]
    public class LinkParameters : ILinkParameters
    {
        /// <summary>
        /// Holds arguments to open links with
        /// </summary>

        [Serializable()]
        public class LinkArguments : ILinkArguments
        {
            /// <summary>
            /// Arguments storage
            /// </summary>
            private Hashtable mobjArguments = null;

            #region ILinkArguments Members

            /// <summary>
            /// Set or get arguments
            /// </summary>
            /// <param name="strName"></param>
            /// <returns></returns>
            public string this[string strName]
            {
                get
                {
                    if (mobjArguments != null)
                    {
                        return mobjArguments[strName] as string;
                    }
                    return null;
                }
                set
                {
                    if (mobjArguments == null)
                    {
                        mobjArguments = new Hashtable();
                    }
                    mobjArguments[strName] = value;
                }
            }

            /// <summary>
            /// Gets an array of argument names
            /// </summary>
            public string[] Names
            {
                get
                {
                    if (mobjArguments == null)
                    {
                        return new string[] { };
                    }
                    else
                    {
                        return (string[])(new ArrayList(mobjArguments.Keys)).ToArray(typeof(string));
                    }
                }
            }

            /// <summary>
            /// Gets the arguments count
            /// </summary>
            public int Count
            {
                get
                {
                    return this.Names.Length;
                }
            }

            /// <summary>
            /// Clears the argument collection
            /// </summary>
            public void Clear()
            {
                if (mobjArguments != null)
                {
                    mobjArguments.Clear();
                }
            }

            #endregion
        }

        #region Class Members

        /// <summary>
        /// The link window stule
        /// </summary>
        private LinkWindowStyle menmWindowStyle = LinkWindowStyle.Normal;

        /// <summary>
        /// The link window size 
        /// </summary>
        private Size mobjWindowSize = Size.Empty;

        /// <summary>
        /// A flag indicating if window should be opened in full screen
        /// </summary>
        private bool mblnFullScreen = false;

        /// <summary>
        /// The link window location
        /// </summary>
        private Point mobjLocation = Point.Empty;

        /// <summary>
        /// A flag indicating of location bar should be displayed in the link window
        /// </summary>
        private bool mblnShowLocationBar = false;

        /// <summary>
        /// A flag indicating of menu bar should be displayed in the link window
        /// </summary>
        private bool mblnShowMenuBar = false;

        /// <summary>
        /// A flag indicating of title bar should be displayed in the link window
        /// </summary>
        private bool mblnShowTitleBar = true;

        /// <summary>
        /// A flag indicating of toolbar should be displayed in the link window
        /// </summary>
        private bool mblnShowToolBar = false;

        /// <summary>
        /// A flag indicating of status bar should be displayed in the link window
        /// </summary>
        private bool mblnShowStatusBar = false;

        /// <summary>
        /// A flag indicating if the link window should be resizable
        /// </summary>
        private bool mblnResizable = true;

        /// <summary>
        /// A flag indicating if the link window should have scrollbars
        /// </summary>
        private bool mblnScrollBars = true;

        /// <summary>
        /// The target window name
        /// </summary>
        private string mstrTarget = "_blank";

        /// <summary>
        /// Holds form related arguments
        /// </summary>
        private ILinkArguments mobjFormArguments = null;

        /// <summary>
        /// Holds form related arguments
        /// </summary>
        private ILinkArguments mobjQueryArguments = null;

        #endregion

        #region C'Tors

        /// <summary>
        /// Create a new link parameters instance
        /// </summary>
        public LinkParameters()
        {

        }

        /// <summary>
        /// Create a new link parameters instance
        /// </summary>
        /// <param name="enmWindowStyle">The link window style</param>
        public LinkParameters(LinkWindowStyle enmWindowStyle)
        {

        }

        /// <summary>
        /// Create a new link parameters instance
        /// </summary>
        /// <param name="enmWindowStyle">The link window style</param>
        /// <param name="objWindowSize">The link window size</param>
        public LinkParameters(LinkWindowStyle enmWindowStyle, Size objWindowSize)
        {
            menmWindowStyle = enmWindowStyle;
            mobjWindowSize = objWindowSize;
        }

        #endregion

        #region ILinkParameters Members

        /// <summary>
        /// Gets or sets query string arguments
        /// </summary>
        public ILinkArguments QueryString
        {
            get
            {
                if (mobjQueryArguments == null)
                {
                    mobjQueryArguments = new LinkArguments();
                }
                return mobjQueryArguments;
            }
        }

        /// <summary>
        /// Gets or sets form arguments
        /// </summary>
        public ILinkArguments Form
        {
            get
            {
                if (mobjFormArguments == null)
                {
                    mobjFormArguments = new LinkArguments();
                }
                return mobjFormArguments;
            }
        }

        /// <summary>
        /// Get or sets the window style
        /// </summary>
        public LinkWindowStyle WindowStyle
        {
            get
            {
                return menmWindowStyle;
            }
            set
            {
                menmWindowStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the window size
        /// </summary>
        public Size Size
        {
            get
            {
                return mobjWindowSize;
            }
            set
            {
                mobjWindowSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the link window full screen mode
        /// </summary>
        public bool FullScreen
        {
            get
            {
                return mblnFullScreen;
            }
            set
            {
                mblnFullScreen = value;
            }
        }

        /// <summary>
        /// Gets or sets the link window location
        /// </summary>
        public Point Location
        {
            get
            {
                return mobjLocation;
            }
            set
            {
                mobjLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the link windows location bar visibility
        /// </summary>
        public bool ShowLocationBar
        {
            get
            {
                return mblnShowLocationBar;
            }
            set
            {
                mblnShowLocationBar = value;
            }
        }

        /// <summary>
        /// Gets or sets the link windows menu bar visibility
        /// </summary>
        public bool ShowMenuBar
        {
            get
            {
                return mblnShowMenuBar;
            }
            set
            {
                mblnShowMenuBar = value;
            }
        }

        /// <summary>
        /// Gets or sets the link windows title bar visibility
        /// </summary>
        public bool ShowTitleBar
        {
            get
            {
                return mblnShowTitleBar;
            }
            set
            {
                mblnShowTitleBar = value;
            }
        }

        /// <summary>
        /// Gets or sets the link windows toolbar visibility
        /// </summary>
        public bool ShowToolBar
        {
            get
            {
                return mblnShowToolBar;
            }
            set
            {
                mblnShowToolBar = value;
            }
        }

        /// <summary>
        /// Gets or sets the link windows status bar visibility
        /// </summary>
        public bool ShowStatusBar
        {
            get
            {
                return mblnShowStatusBar;
            }
            set
            {
                mblnShowStatusBar = value;
            }
        }

        /// <summary>
        /// Gets or sets the resizable mode of the link window
        /// </summary>
        public bool Resizable
        {
            get
            {
                return mblnResizable;
            }
            set
            {
                mblnResizable = value;
            }
        }

        /// <summary>
        /// Gets or sets the scrollbars visibility in the link window
        /// </summary>
        public bool ScrollBars
        {
            get
            {
                return mblnScrollBars;
            }
            set
            {
                mblnScrollBars = value;
            }
        }

        /// <summary>
        /// Gets or sets the link targer
        /// </summary>
        public string Target
        {
            get
            {
                return mstrTarget;
            }
            set
            {
                mstrTarget = value;
            }
        }

        #endregion
    }

    #endregion

    #region FormReference Class

    /// <summary>
    /// References a form
    /// </summary>

    [Serializable()]
    public class FormReference : IFormLink
    {
        /// <summary>
        /// The webgui configuration object
        /// </summary>
        private static Config mobjConfig = null;

        /// <summary>
        /// The form type
        /// </summary>
        private Type mobjType = null;

        /// <summary>
        /// The form reference instance id
        /// </summary>
        private Guid mobjInstance = Guid.Empty;

        /// <summary>
        /// The form link url
        /// </summary>
        private string mstrUrl = null;

        /// <summary>
        /// The form application name
        /// </summary>
        private string mstrApplication = null;

        /// <summary>
        /// Initializes the configuration object
        /// </summary>
        static FormReference()
        {
            mobjConfig = Config.GetInstance();
        }

        /// <summary>
        /// Initialize form reference by application code
        /// </summary>
        /// <param name="strApplication">The application code as defined in the web config</param>
        public FormReference(string strApplication)
        {
            // Validate non null application value
            if (strApplication == null)
            {
                throw new ArgumentNullException("application");
            }

            // Store application value
            mstrApplication = strApplication;

            // Get application form type
            string strType = mobjConfig.GetApplication(strApplication.ToLower(CultureInfo.InvariantCulture));
            if (strType == null)
            {
                throw new ArgumentException(string.Format("Cound not find application definition for '{0}'.", strApplication), "application");
            }

            // Get type from application
            mobjType = Type.GetType(strType, false);
            if (mobjType == null)
            {
                throw new ArgumentException(string.Format("Cound not find application definition for '{0}'.", strApplication), "application");
            }

            // Set form url
            mstrUrl = string.Format("{0}{1}", strApplication, mobjConfig.DynamicExtension);

            // Create a new form reference instance guid
            mobjInstance = Guid.NewGuid();
        }

        ///// <summary>
        ///// Initialize form reference by form type
        ///// </summary>
        ///// <param name="objType">The form type to initialize</param>
        //public FormReference(Type objType)
        //{
        //    // If not a form type
        //    if (!objType.IsSubclassOf(typeof(Form)))
        //    {
        //        throw new ArgumentException(string.Format("'{0}' is not inherited from Gizmox.WebGUI.Form", type.Name), "type");
        //    }

        //    // Create a new form reference instance guid
        //    mobjInstance = Guid.NewGuid();
        //}

        /// <summary>
        /// Gets the form reference type 
        /// </summary>
        Type IFormLink.FormType
        {
            get
            {
                return mobjType;
            }
        }

        /// <summary>
        /// Gets the form instance id
        /// </summary>
        string IFormLink.FormInstance
        {
            get
            {
                return mobjInstance.ToString();
            }
        }

        /// <summary>
        /// Gets the form application name
        /// </summary>
        string IFormLink.FormApplication
        {
            get
            {
                return mstrApplication;
            }
        }

        #region ILink Members

        /// <summary>
        /// Returns the url to open
        /// </summary>
        string ILink.Url
        {
            get
            {
                return mstrUrl;
            }
        }

        #endregion
    }

    #endregion
}
