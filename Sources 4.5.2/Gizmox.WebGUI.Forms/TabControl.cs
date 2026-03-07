#region Using

using System;
using System.Xml;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Layout;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Configuration;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region TabControl Enums

    /// <summary>
    /// Specifies the appearance of the tabs in a tab control.
    /// </summary>
    [Serializable()]
    public enum TabAppearance
    {
        /// <summary>
        /// The tabs have the standard appearance of tabs.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// The tabs have the appearance of three-dimensional buttons.
        /// </summary>
        Buttons = 1,
        /// <summary>
        /// The tabs have the appearance of flat buttons.
        /// </summary>
        FlatButtons = 2,
        /// <summary>
        /// The tabs have the appearance of workspace buttons.
        /// </summary>
        [Obsolete("Use the WorkspaceTabs class in the forms extension instead")]
        Workspace = 4,
        /// <summary>
        /// The tabs have the appearance of logical buttons.
        /// </summary>
        Logical = 8,
        /// <summary>
        /// The tabs have the appearance of navigation buttons.
        /// </summary>
        Navigation = 16,

        /// <summary>
        ///  The tabs have spread appearance.
        /// </summary>
        Spread = 32
    }

    /// <summary>
    /// Specifies the locations of the tabs in a tab control.
    /// </summary>
    [Serializable()]
    public enum TabAlignment
    {

        /// <summary>
        /// The tabs are located across the top of the control.
        /// </summary>
        Top = 0,

        /// <summary>
        /// The tabs are located across the bottom of the control.
        /// </summary>
        Bottom = 1,

        /// <summary>
        /// The tabs are located along the left edge of the control.
        /// </summary>
        Left = 2,

        /// <summary>
        /// The tabs are located along the right edge of the control.
        /// </summary>
        Right = 3
    }

    /// <summary>
    /// Tab control client behavior modes
    /// </summary>
    public enum TabControlClientBehavior
    {
        /// <summary>
        /// TabControl draws only on tab at a time. This mode is optimized for large tab page content displaying in DHTML.
        /// When loading lots of controls or data intensive controls in multiple tabs,
        /// this mode avoids browser from having to deal with large amount of dom elements.
        /// </summary>
        MemoryOptimized,

        /// <summary>
        /// TabControl does not redraw its tabs when switching between tabs. 
        /// This mode is optimized for resonable tab page content and provides an
        /// advantage for working with browser navigation inside the tab pages.
        /// </summary>
        DrawingOptimized,

        /// <summary>
        /// Tabcontrol won't have any optimizations.
        /// </summary>
        NoOptimizations
    }

    #endregion TabControl Enums

    #region TabControlCancelEventArgs Class

    /// <summary>
    /// Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.TabControl.Selecting"></see> or <see cref="E:Gizmox.WebGUI.Forms.TabControl.Deselecting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> control. 
    /// </summary>
    public delegate void TabControlCancelEventHandler(object sender, TabControlCancelEventArgs e);

    /// <summary>
    /// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.TabControl.Selecting"></see> and <see cref="E:Gizmox.WebGUI.Forms.TabControl.Deselecting"></see> events of a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> control. 
    /// </summary>
    [Serializable()]
    public class TabControlCancelEventArgs : CancelEventArgs
    {
        #region Class Members

        private TabPage mobjTabPage;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabControlCancelEventArgs"></see> class. 
        /// </summary>
        ///	<param name="blnCancel">true to cancel the tab change by default; otherwise, false.</param>
        ///	<param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> the event is occurring for.</param>
        public TabControlCancelEventArgs(TabPage objTabPage, bool blnCancel)
            : base(blnCancel)
        {
            this.mobjTabPage = objTabPage;
        }

        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        /// Gets the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> the event is occurring for.
        /// </summary>
        ///	<returns>The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> the event is occurring for.</returns>
        public TabPage TabPage
        {
            get
            {
                return this.mobjTabPage;
            }
        }

        #endregion Properties
    }

    #endregion TabControlCancelEventArgs Class

    #region TabControl Class

    /// <summary>
    /// Manages a related set of tab pages.
    /// </summary>
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(TabControl), "TabControl_45.bmp")]
#else
    [ToolboxBitmap(typeof(TabControl), "TabControl.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [DefaultProperty("TabPages"), SRDescription("DescriptionTabControl"), DefaultEvent("SelectedIndexChanged")]
    [ToolboxItemCategory("Containers")]
    [MetadataTag(WGTags.TabControl)]
    [Skin(typeof(TabControlSkin))]
    [Serializable()]
    [ProxyComponent(typeof(ProxyTabControl))]
    public class TabControl : Control, ISupportInitialize, INavigationControl
    {
        #region ControlCollection Class

        /// <summary>
        /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects.
        /// </summary>
        [Serializable()]
        public class ControlCollection : Control.ControlCollection
        {
            private TabControl mobjOwner;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlCollection"></see> class.
            /// </summary>
            ///	<param name="owner">The <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> that this collection belongs to. </param>
            public ControlCollection(TabControl objOwner)
                : base(objOwner)
            {
                this.mobjOwner = objOwner;
            }

            /// <summary>
            /// Adds a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to the collection.
            /// </summary>
            /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add. </param>
            /// <exception cref="T:System.Exception">The specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see>. </exception>
            public override void Add(Control objControl)
            {
                if (!(objControl is TabPage))
                {
                    throw new ArgumentException(SR.GetString("TabControlInvalidTabPageType", new object[] { objControl.GetType().Name }));
                }

                TabPage objTabPage = objControl as TabPage;
                if (objTabPage != null)
                {
                    // Add the recieved tabpage.
                    base.Add(objTabPage);
                }
            }

            /// <summary>
            /// Removes a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> from the collection.
            /// </summary>
            ///	<param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove. </param>
            public override void Remove(Control objControl)
            {
                // get the removed tab index
                int intIndex = this.IndexOf(objControl);

                // call base function
                base.Remove(objControl);

                if (mobjOwner != null)
                {
                    // Cast control to a tab page.
                    TabPage objTabPage = objControl as TabPage;
                    if (objTabPage != null)
                    {
                        // check if the removed tab is part of this collection
                        if (intIndex != -1)
                        {
                            // initialize the new selected index to be current selected index
                            int intNewSelectedIndex = 0;

                            // Get current selected index
                            int intCurrentSelectedIndex = mobjOwner.SelectedIndex;

                            // if there is no more tabs then set new index to -1
                            if (this.Count == 0)
                            {
                                intNewSelectedIndex = -1;
                            }
                            else
                            {
                                // initialize the new selected index to be current selected index
                                intNewSelectedIndex = intCurrentSelectedIndex;

                                // check if the removed tab is the current selected tab
                                if (intIndex == intNewSelectedIndex)
                                {
                                    // set selected tab to be the first tab
                                    intNewSelectedIndex = 0;
                                }
                                // check if the removed tab is before the selected tab
                                else if (intIndex < intNewSelectedIndex)
                                {
                                    // update the new selected tab index
                                    intNewSelectedIndex--;
                                }
                            }

                            // Check if Tab Index changed
                            if (intCurrentSelectedIndex != intNewSelectedIndex)
                            {
                                // Update new selected index
                                mobjOwner.SelectedIndex = intNewSelectedIndex;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Updates the owner.
            /// </summary>
            protected override void UpdateOwner()
            {
                if (mobjOwner != null)
                {
                    if (mobjOwner.ShouldUseClientUpdateHandler)
                    {
                        mobjOwner.Update(false, true);
                    }
                    else
                    {
                        base.UpdateOwner();
                    }
                }
            }
        }

        #endregion

        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to Multiline property.
        /// </summary>
        private static SerializableProperty MultilineProperty = SerializableProperty.Register("Multiline", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to SelectOnRightClick property.
        /// </summary>        
        private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register("SelectOnRightClick", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to TabAppearance property.
        /// </summary>
        private static SerializableProperty TabAppearanceProperty = SerializableProperty.Register("TabAppearance", typeof(TabAppearance), typeof(TabControl), new SerializablePropertyMetadata(TabAppearance.Normal));

        /// <summary>
        /// Provides a property reference to SelectedIndex property.
        /// </summary>
        private static SerializableProperty SelectedIndexProperty = SerializableProperty.Register("SelectedIndex", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to ClientBehavior property.
        /// </summary>
        private static SerializableProperty ClientBehaviorProperty = SerializableProperty.Register("ClientBehavior", typeof(TabControlClientBehavior), typeof(TabControl), new SerializablePropertyMetadata(TabControlClientBehavior.MemoryOptimized));

        /// <summary>
        /// Provides a property reference to ShowCloseButton property.
        /// </summary>
        private static SerializableProperty ShowCloseButtonProperty = SerializableProperty.Register("ShowCloseButton", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ShowExpandButton property.
        /// </summary>
        private static SerializableProperty ShowExpandButtonProperty = SerializableProperty.Register("ShowExpandButton", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to IsExpandedProperty property.
        /// </summary>
        private static SerializableProperty IsExpandedProperty = SerializableProperty.Register("IsExpandedProperty", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to ImageList property.
        /// </summary>
        private static SerializableProperty ImageListProperty = SerializableProperty.Register("ImageList", typeof(ImageList), typeof(TabControl), new SerializablePropertyMetadata(null));

        /// <summary>
        /// The menmAlignment property registration.
        /// </summary>
        private static readonly SerializableProperty AlignmentProperty = SerializableProperty.Register("menmAlignment", typeof(TabAlignment), typeof(TabControl), new SerializablePropertyMetadata(TabAlignment.Top));

        /// <summary>
        /// The ItemSize property registration. 
        /// </summary>
        private static SerializableProperty ItemSizeProperty = SerializableProperty.Register("ItemSize", typeof(Size), typeof(TabControl));

        /// <summary>
        /// Provides a property reference to IsExpanding property.
        /// </summary>
        private static SerializableProperty IsExpandingProperty = SerializableProperty.Register("IsExpandingProperty", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to HeaderHeight property.
        /// </summary>
        private static SerializableProperty HeaderHeightProperty = SerializableProperty.Register("HeaderHeightProperty", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to RestoredHeight property.
        /// </summary>
        private static SerializableProperty RestoredHeightProperty = SerializableProperty.Register("RestoredHeightProperty", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to HeadersOffset property.
        /// </summary>
        private static SerializableProperty HeadersOffsetProperty = SerializableProperty.Register("HeadersOffsetProperty", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to ContextualTabGroupCollection property.
        /// </summary>
        private static SerializableProperty ContextualTabGroupCollectionProperty = SerializableProperty.Register("ContextualTabGroupCollectionProperty", typeof(ContextualTabGroupCollection), typeof(TabControl), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to MaxTabPageHeaders property.
        /// </summary>   
        private static SerializableProperty MaxTabPageHeadersProperty = SerializableProperty.Register("MaxTabPageHeadersProperty", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(0));

        #endregion Serializable Properties

        /// <summary>
        /// Gets the tab control current skin.
        /// </summary>
        /// <value>The tab control current skin.</value>
        internal TabControlSkin TabControlCurrentSkin
        {
            get
            {
                return (TabControlSkin)this.Skin;
            }
        }

        /// <summary>
        /// Occurs when the user clicks the tab control close button
        /// </summary>
        public virtual event EventHandler CloseClick
        {
            add
            {
                this.AddHandler(TabControl.CloseClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(TabControl.CloseClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CloseClick event.
        /// </summary>
        private EventHandler CloseClickHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(TabControl.CloseClickEvent);
            }
        }

        /// <summary>
        /// The CloseClick event registration.
        /// </summary>
        private static readonly SerializableEvent CloseClickEvent = SerializableEvent.Register("CloseClick", typeof(EventHandler), typeof(TabControl));

        /// <summary>
        /// Occurs when the SelectedIndex property is changed.
        /// </summary>
        [SRDescription("selectedIndexChangedEventDescr"), SRCategory("CatBehavior")]
        public event EventHandler SelectedIndexChanged
        {
            add
            {
                this.AddCriticalHandler(TabControl.SelectedIndexChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TabControl.SelectedIndexChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectedIndexChanged event.
        /// </summary>
        private EventHandler SelectedIndexChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(TabControl.SelectedIndexChangedEvent);
            }
        }

        /// <summary>
        /// The SelectedIndexChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(TabControl));

        /// <summary>
        /// Occurs when the SelectedIndex property is about to change.
        /// </summary>
        public event TabControlCancelEventHandler SelectedIndexChanging
        {
            add
            {
                this.AddCriticalHandler(TabControl.SelectedIndexChangingEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TabControl.SelectedIndexChangingEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectedIndexChanging event.
        /// </summary>
        private TabControlCancelEventHandler SelectedIndexChangingHandler
        {
            get
            {
                return (TabControlCancelEventHandler)this.GetHandler(TabControl.SelectedIndexChangingEvent);
            }
        }

        /// <summary>
        /// The SelectedIndexChanging event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedIndexChangingEvent = SerializableEvent.Register("SelectedIndexChanging", typeof(TabControlCancelEventHandler), typeof(TabControl));

        /// <summary>
        /// The control tabs collection
        /// </summary>
        private TabPageCollection mobjTabs = null;

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> class.
        /// </summary>
        public TabControl()
        {
            // create a tabpage collection wrapper
            mobjTabs = CreateTabPageCollection();
            this.RestoredHeight = this.Height;
        }

        #endregion C'Tor/D'Tor

        #region Methods

        #region Render

        /// <summary>
        /// Renders the max tab page headers attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderMaxTabPageHeadersAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (blnForceRender || (this.ContainsValue<int>(TabControl.MaxTabPageHeadersProperty) && this.Appearance == TabAppearance.Spread))
            {
                objWriter.WriteAttributeText(WGAttributes.MaximumTabPageHeaders, this.MaxTabPageHeaders.ToString());
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderMaxTabPageHeadersAttribute(objWriter, false);

            if (this.Multiline)
            {
                objWriter.WriteAttributeString(WGAttributes.Multiline, "1");
            }

            objWriter.WriteAttributeString(WGAttributes.TabLayout, GetTabLayoutId(this.GetProxyPropertyValue<TabAlignment>("Alignment", this.Alignment)));

            TabPage objSelectedItem = this.SelectedItem;
            if (objSelectedItem != null)
            {
                long lngID = objSelectedItem.ProxyComponent != null ? objSelectedItem.GetProxyPropertyValue<long>("ID", objSelectedItem.ID) : objSelectedItem.ID;

                objWriter.WriteAttributeString(WGAttributes.Selected, lngID.ToString());
            }

            // Render the SelectOnRightClick attribute.
            RenderSelectOnRightClick(objWriter, false);

            // Render show close button value
            RenderShowCloseButtonAttribute(objWriter, false);

            // Render show expand button value
            RenderShowExpandAttribute(objWriter, false);

            // Render the Expanded attribute.
            RenderExpandedAttribute(objWriter, false);

            // Render the restored height attribute.
            RenderRestoredHeightAttribute(objWriter);

            // Render the header offset attribute.
            RenderHeaderOffsetAttribute(objWriter, false);

            // Render the appearance attribute
            RenderAppearanceAttribute(objWriter, false);
        }


        /// <summary>
        /// Renders the appearance attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            TabAppearance enmAppearance = this.GetProxyPropertyValue<TabAppearance>("Appearance", this.Appearance);

            if (enmAppearance != TabAppearance.Normal || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Appearance, (int)enmAppearance);
            }
        }

        /// <summary>
        /// Renders the controls.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">writer.</param>
        /// <param name="lngRequestID">Request ID.</param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            if (this.IsDirty(lngRequestID))
            {
                // Render ContextualTabGroups
                RenderContextualTabGroups(objContext, objWriter);
            }

            ICollection objTabPages = this.GetProxyPropertyValue<ICollection>("TabPages", this.TabPages);

            // add all tabs
            foreach (TabPage objTabPage in objTabPages)
            {
                if (objTabPage.Visible)
                {
                    if (this.ClientBehavior == TabControlClientBehavior.NoOptimizations)
                    {
                        objTabPage.InternalLoaded = true;
                    }
                    else
                    {
                        if (lngRequestID == 0)
                        {
                            if (!this.ShouldUseClientUpdateHandler)
                            {
                                objTabPage.InternalLoaded = false;
                            }
                        }
                    }

                    ((IRenderableComponent)objTabPage).RenderComponent(objContext, objWriter, lngRequestID);
                }
            }
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                TabPage objSelectedItem = this.SelectedItem;
                if (objSelectedItem != null)
                {
                    long lngID = objSelectedItem.ProxyComponent != null ? objSelectedItem.GetProxyPropertyValue<long>("ID", objSelectedItem.ID) : objSelectedItem.ID;

                    objWriter.WriteAttributeString(WGAttributes.Selected, lngID.ToString());
                }

                // Render the SelectOnRightClick attribute.
                RenderSelectOnRightClick(objWriter, true);

                // Render show close button value
                RenderShowCloseButtonAttribute(objWriter, true);
            }
            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Render show expand button value
                RenderShowExpandAttribute(objWriter, true);

                RenderMaxTabPageHeadersAttribute(objWriter, true);


                // Render is expanded value
                RenderExpandedAttribute(objWriter, true);

                // Renders the restored height attribute.
                RenderRestoredHeightAttribute(objWriter);

                // Render the header offset attribute.
                RenderHeaderOffsetAttribute(objWriter, true);

                // Render the appearance attribute
                RenderAppearanceAttribute(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the select on right click.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.SelectOnRightClick)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectOnRightClick, "1");
            }
            else if (blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectOnRightClick, "0");
            }
        }

        /// <summary>
        /// Renders the restored height attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderRestoredHeightAttribute(IAttributeWriter objWriter)
        {
            // Render restored heightonly if the user has the expand button or the tabcontrol is collapsed
            if (!this.IsExpanded || this.ShowExpandButton)
            {
                objWriter.WriteAttributeString(WGAttributes.RestoredHeight, this.RestoredHeight.ToString());
            }
        }

        /// <summary>
        /// Renders the expanded attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderExpandedAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnIsExpanded = this.IsExpanded;

            if (!blnIsExpanded || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Expanded, blnIsExpanded ? "1" : "0");
            }
        }


        /// <summary>
        /// Renders the show expand button attribute.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderShowExpandAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnShowExpanded = this.ShowExpandButton;

            if (blnShowExpanded || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ExpansionIndicator, blnShowExpanded ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the show expand button attribute.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderShowCloseButtonAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnShowCloseButton = this.ShowCloseButton;

            if (blnShowCloseButton || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ShowCloseButton, blnShowCloseButton ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the header offset attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderHeaderOffsetAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            int intHeadersOffset = this.HeadersOffset;

            if (intHeadersOffset >= 0 || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.HeadersOffset, intHeadersOffset.ToString());
            }
        }

        /// <summary>
        /// Renders the contextual tab groups.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        private void RenderContextualTabGroups(IContext objContext, IResponseWriter objWriter)
        {
            ContextualTabGroupCollection objContextualTabGroups = this.ContextualTabGroupsInternal;
            if (objContextualTabGroups != null)
            {
                int intPosition = 0;
                foreach (ContextualTabGroup objContextualTabGroup in objContextualTabGroups)
                {
                    // Write start group tag
                    objWriter.WriteStartElement(WGTags.Group);

                    // Write id and text
                    objWriter.WriteAttributeText(WGAttributes.Index, intPosition.ToString());
                    objWriter.WriteAttributeText(WGAttributes.Text, objContextualTabGroup.Text, TextFilter.CarriageReturn | TextFilter.NewLine);

                    // Write end group tag
                    objWriter.WriteEndElement();
                    intPosition++;
                }
            }
        }

        #endregion Render


        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new TabControlRenderer(this);
        }

        /// <summary>
        /// Adds a child object.
        /// </summary>
        /// <param name="objValue">The child object to add.</param>
        protected override void AddChild(object objValue)
        {
            // If value is a tab page
            if (objValue is TabPage)
            {
                this.TabPages.Add((TabPage)objValue);
            }
            else
            {
                base.AddChild(objValue);
            }
        }

        /// <summary>
        /// Creates the tab page collection.
        /// </summary>
        /// <returns></returns>
        protected virtual TabPageCollection CreateTabPageCollection()
        {
            return new TabPageCollection(this);
        }

        /// <summary>
        /// This member overrides <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControlsInstance"></see>.
        /// </summary>
        ///	<returns>A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> assigned to the control.</returns>
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new TabControl.ControlCollection(this);
        }

        /// <summary>
        /// Gets the tab layout id.
        /// </summary>
        /// <param name="enmTabAlignment">The tab layout id.</param>
        /// <returns></returns>
        protected virtual int GetTabLayoutId(TabAlignment enmTabAlignment)
        {
            // If is logical mode then use the empty tab layout
            if (this.GetProxyPropertyValue<TabAppearance>("Appearance", this.Appearance) == TabAppearance.Logical)
            {
                return -1;
            }
            else
            {
                return (int)enmTabAlignment;
            }
        }

        /// <summary>
        /// Gets or Sets value indication if the close button (when Appearance==TabAppearance.Workspace) 
        /// should be shown
        /// </summary>
        [DefaultValue(false)]
        public virtual bool ShowCloseButton
        {
            get
            {
                return this.GetValue<bool>(TabControl.ShowCloseButtonProperty);
            }
            set
            {
                if (this.SetValue<bool>(TabControl.ShowCloseButtonProperty, value))
                {
                    this.UpdateParams(AttributeType.Control, false);
                }
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();
            if (SelectedIndexChangedHandler != null || SelectedIndexChangingHandler != null)
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            // Check if expand is critical.
            if (this.ExpandHandler != null)
            {
                objEvents.Set(WGEvents.Expand);
            }

            // Check if collapse is critical.
            if (this.CollapseHandler != null)
            {
                objEvents.Set(WGEvents.Collapse);
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

            if (this.HasClientHandler("Expand"))
            {
                objEvents.Set(WGEvents.Expand);
                objEvents.Set(WGEvents.Collapse);
            }

            return objEvents;
        }

        /// <summary>
        /// Occurs when [client close click].
        /// </summary>
        [SRDescription("Occurs when control's tab closed in client mode."), Category("Client")]
        public event ClientEventHandler ClientCloseClick
        {
            add
            {
                this.AddClientHandler("TabClose", value);
            }
            remove
            {
                this.RemoveClientHandler("TabClose", value);
            }
        }

        /// <summary>
        /// Occurs when [client expand].
        /// </summary>
        [SRDescription("Occurs when control's tab expanded in client mode."), Category("Client")]
        public event ClientEventHandler ClientExpandedChanged
        {
            add
            {
                this.AddClientHandler("Expand", value);
            }
            remove
            {
                this.RemoveClientHandler("Expand", value);
            }
        }

        /// <summary>
        /// Occurs when [client selected index changing].
        /// </summary>
        [SRDescription("Occurs when control's selected index changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientSelectedIndexChanged
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
        /// Called when [collapse].
        /// </summary>
        protected virtual void OnCollapse(bool blnClientSource)
        {
            if (CollapseHandler != null)
            {
                CollapseHandler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [expand].
        /// </summary>
        protected virtual void OnExpand(bool blnClientSource)
        {
            if (ExpandHandler != null)
            {
                ExpandHandler(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// Sets the specified bounds of the control to the specified location and size.
        /// </summary>
        /// <param name="intLeft">The int left.</param>
        /// <param name="intTop">The int top.</param>
        /// <param name="intWidth">Width of the int layout.</param>
        /// <param name="intHeight">Height of the int layout.</param>
        /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
        /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
        /// <returns></returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified, bool blnIsClientSource)
        {
            if (!this.DesignMode && (enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None)
            {
                if (!this.IsExpanding)
                {
                    // if collapsed then do not update height
                    if (!this.IsExpanded)
                    {
                        enmSpecified = enmSpecified & ~BoundsSpecified.Height;
                    }

                    // Preserve restored height.
                    this.RestoredHeight = intHeight;
                }
            }

            // Call base function
            return base.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
        }


        /// <summary>
        /// Sets the IsExpanded.
        /// </summary>
        /// <param name="blnIsExpanded">if set to <c>true</c> [BLN is expanded].</param>
        /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
        private bool SetIsExpanded(bool blnIsExpanded, bool blnClientSource)
        {
            bool blnShowExpandButton = this.ShowExpandButton;

            // Validate new value
            ValidateExpandAndMultiLine(blnIsExpanded, this.Multiline, blnShowExpandButton);
            ValidateExpandAndDock(blnIsExpanded, this.Dock, blnShowExpandButton);

            bool blnValueChanged = this.SetValue<bool>(TabControl.IsExpandedProperty, blnIsExpanded);
            if (blnValueChanged)
            {
                if (!this.DesignMode && !this.IsLayoutSuspended)
                {
                    ApplyHeight(blnClientSource);

                    if (!blnClientSource)
                    {
                        // Update visual params and layout params.
                        this.UpdateParams(AttributeType.Visual | AttributeType.Layout, false);
                    }
                }
            }

            if (blnValueChanged || blnClientSource)
            {
                // If expanded
                if (blnIsExpanded)
                {
                    // Process Expand server event
                    OnExpand(blnClientSource);
                }
                // If collapsed
                else
                {
                    // Process Collapse server event
                    OnCollapse(blnClientSource);
                }
            }

            return blnValueChanged;
        }


        /// <summary>
        /// Applies the height.
        /// </summary>
        /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
        private void ApplyHeight(bool blnClientSource)
        {
            if (!blnClientSource)
            {
                UpdateParams(AttributeType.Visual);
            }

            // Set expanding flag on
            this.IsExpanding = true;

            int intHeight = this.IsExpanded ? this.RestoredHeight : this.SkinHeaderHeight;

            // Sets the height = restored height.
            if (this.SetBounds(0, 0, 0, intHeight, BoundsSpecified.Height, blnClientSource))
            {
                this.InvalidateParentLayout(new LayoutEventArgs(false, true, true));
            }

            // Set expanding flag off
            this.IsExpanding = false;
        }

        /// <summary>
        /// Validates the expand and multi line.
        /// </summary>
        /// <param name="blnIsExpanded">if set to <c>true</c> [BLN is expanded].</param>
        /// <param name="blnMultiline">if set to <c>true</c> [BLN multiline].</param>
        /// <param name="blnShowExpandButton">if set to <c>true</c> [BLN show expand button].</param>
        private void ValidateExpandAndMultiLine(bool blnIsExpanded, bool blnMultiline, bool blnShowExpandButton)
        {
            if ((!blnIsExpanded || blnShowExpandButton) && blnMultiline)
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Validates the expand and dock.
        /// </summary>
        /// <param name="blnIsExpanded">if set to <c>true</c> [BLN is expanded].</param>
        /// <param name="enmDockStyle">The enm dock style.</param>
        /// <param name="blnShowExpandButton">if set to <c>true</c> [BLN show expand button].</param>
        internal virtual void ValidateExpandAndDock(bool blnIsExpanded, DockStyle enmDockStyle, bool blnShowExpandButton)
        {
            if ((!blnIsExpanded || blnShowExpandButton) && (enmDockStyle == DockStyle.Fill || enmDockStyle == DockStyle.Left || enmDockStyle == DockStyle.Right))
            {
                throw new NotSupportedException(SR.GetString("TabControlValidateExpandAndDock", new object[] { enmDockStyle }));
            }
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            switch (objEvent.Type)
            {
                case "TabClose":
                    // If there are tabs
                    if (this.Controls.Count > 0)
                    {
                        if (CloseClickHandler != null)
                        {
                            CloseClickHandler(this, new EventArgs());
                        }
                    }
                    break;

                case "ValueChange":
                    long lngGuid = long.Parse(objEvent["Value"]);
                    ISessionRegistry objSessionRegistry = this.Context as ISessionRegistry;

                    if (objSessionRegistry != null)
                    {
                        TabPage objTabPage = null;

                        // Get registered component
                        IRegisteredComponent objComponent = objSessionRegistry.GetRegisteredComponent(lngGuid);

                        // Check if the component is proxy component or regular one, and if its a proxy then get proxy source tabpage
                        ProxyComponent objProxyComponent = objComponent as ProxyComponent;
                        if (objProxyComponent != null)
                        {
                            objTabPage = objProxyComponent.SourceComponent as TabPage;
                        }
                        else
                        {
                            objTabPage = objComponent as TabPage;
                        }

                        // Check if valid tabpage
                        if (objTabPage != null && objTabPage.TabControl == this)
                        {
                            ChangeSelectedTab(objTabPage as TabPage);
                        }

                    }
                    break;

                case "Expand":
                    bool blnExpanded = false;

                    // If 'Expanded' attribute found
                    if (bool.TryParse(objEvent[WGAttributes.Expanded], out blnExpanded))
                    {
                        // Update IsExpanded property
                        this.SetIsExpanded(blnExpanded, true);
                    }

                    break;
                default:
                    base.FireEvent(objEvent);
                    break;
            }
        }

        /// <summary>
        /// Changes the selected tab.
        /// </summary>
        /// <param name="objTabPage">tab page.</param>
        internal void ChangeSelectedTab(TabPage objTabPage)
        {
            if (objTabPage != null)
            {
                // Get the current tab index
                int intTabIndex = this.TabPages.IndexOf(objTabPage);

                // If is a difrent tab
                if (SelectedIndex != intTabIndex)
                {
                    // Set the selected tab
                    SelectedIndex = intTabIndex;

                    // Check if tab change was effective, or canceled by SelectedIndexChanging
                    if (SelectedIndex == intTabIndex)
                    {
                        // If not loaded update tab
                        if (!objTabPage.Loaded) SelectedItem.Update();

                        // Update control params
                        UpdateParams(AttributeType.Control);
                    }
                }
                else
                {
                    // We will get here in case the selected tab changed is critical in the following scenario:
                    // Tab1 -> Change to MoreTabs -> Return to Tab1. In this case we just need to redraw the tab.
                    UpdateParams(AttributeType.Redraw);
                }
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.TabControl.SelectedIndexChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.SelectedIndexChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Provides controls with the ability to handle size changed
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <param name="objNewSize">The control new size.</param>
        /// <param name="objOldSize">The control old size.</param>
        internal override void OnLayoutInternal(LayoutEventArgs e, Size objNewSize, Size objOldSize)
        {
            base.OnLayoutInternal(e, objNewSize, objOldSize);

            // Get width change
            int intWidthChange = objNewSize.Width - objOldSize.Width;

            // Get height change
            int intHeightChange = objNewSize.Height - objOldSize.Height;

            // Loop all tab pages and raise the size changed event
            foreach (TabPage objTabPage in this.TabPages)
            {
                // Get the current control docking
                DockStyle enmTabPageDock = objTabPage.Dock;

                // If parent size had changed
                if (intWidthChange != 0 || intHeightChange != 0)
                {
                    objTabPage.OnResizeInternal(e.Clone(false, false));
                }
            }
        }

        #region Collapse Event

        /// <summary>
        /// Gets the hanlder for the Collapse event.
        /// </summary>
        private EventHandler CollapseHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(TabControl.CollapseEvent);
            }
        }

        /// <summary>
        /// The Collapse event registration.
        /// </summary>
        private static readonly SerializableEvent CollapseEvent = SerializableEvent.Register("Collapse", typeof(EventHandler), typeof(TabControl));

        /// <summary>
        /// Occurs when [Collapseed].
        /// </summary>
        public event EventHandler Collapse
        {
            add
            {
                this.AddCriticalHandler(TabControl.CollapseEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TabControl.CollapseEvent, value);
            }
        }

        #endregion

        #region Expand Event

        /// <summary>
        /// Gets the hanlder for the Expand event.
        /// </summary>
        private EventHandler ExpandHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(TabControl.ExpandEvent);
            }
        }

        /// <summary>
        /// The Expand event registration.
        /// </summary>
        private static readonly SerializableEvent ExpandEvent = SerializableEvent.Register("Expand", typeof(EventHandler), typeof(TabControl));

        /// <summary>
        /// Occurs when [expanded].
        /// </summary>
        public event EventHandler Expand
        {
            add
            {
                this.AddCriticalHandler(TabControl.ExpandEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TabControl.ExpandEvent, value);
            }
        }

        #endregion

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets the select on right click.
        /// </summary>
        /// <value>The select on right click.</value>
        [SRCategory("CatAppearance"), SRDescription("SelectOnRightClickDescr"), DefaultValue(false)]
        public bool SelectOnRightClick
        {
            get
            {
                return this.GetValue<bool>(TabControl.SelectOnRightClickProperty);
            }
            set
            {
                if (this.SetValue<bool>(TabControl.SelectOnRightClickProperty, value))
                {
                    // Update the control
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expanding.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is expanding; otherwise, <c>false</c>.
        /// </value>
        private bool IsExpanding
        {
            get
            {
                return this.GetValue<bool>(TabControl.IsExpandingProperty);
            }
            set
            {
                this.SetValue<bool>(TabControl.IsExpandingProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the header.
        /// </summary>
        /// <value>
        /// The height of the header.
        /// </value>
        private int HeaderHeight
        {
            get
            {
                return this.GetValue<int>(TabControl.HeaderHeightProperty);
            }
            set
            {
                this.SetValue<int>(TabControl.HeaderHeightProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the restored.
        /// </summary>
        /// <value>
        /// The height of the restored.
        /// </value>
        internal int RestoredHeight
        {
            get
            {
                return this.GetValue<int>(TabControl.RestoredHeightProperty);
            }
            set
            {
                if (this.SetValue<int>(TabControl.RestoredHeightProperty, value))
                {
                    // Ensure update client restored height
                    UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.
        /// </summary>
        /// <value></value>
        /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        /// <summary>
        /// Gets or sets the client drawing mode behavior
        /// </summary>
        [DefaultValue(TabControlClientBehavior.MemoryOptimized)]
        public virtual TabControlClientBehavior ClientBehavior
        {
            get
            {
                // Get context params.
                IContextParams objContextParams = this.Context as IContextParams;
                if (objContextParams != null)
                {
                    // Check if client is enabled.
                    if (this.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
                    {
                        // Return no optimizations...
                        return TabControlClientBehavior.NoOptimizations;
                    }
                }

                // Setting the value
                return this.GetValue<TabControlClientBehavior>(TabControl.ClientBehaviorProperty);
            }
            set
            {
                // If value has changed
                if (this.SetValue<TabControlClientBehavior>(TabControl.ClientBehaviorProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the collection of tab pages in this tab control.
        /// </summary>
        ///	<returns>A <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects in this <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see>.</returns>
        [SRCategory("CatBehavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), MergableProperty(false), SRDescription("TabControlTabsDescr")]
        public TabPageCollection TabPages
        {
            get
            {
                return mobjTabs;
            }
        }

        /// <summary>
        /// Gets the control contained area offset.
        /// </summary>
        protected override PaddingValue ContainedAreaOffset
        {
            get
            {
                if (this.Appearance == TabAppearance.Normal || this.Appearance == TabAppearance.Workspace)
                {
                    TabControlSkin objTabControlSkin = SkinFactory.GetSkin(this) as TabControlSkin;
                    if (objTabControlSkin != null)
                    {
                        Padding objFramePadding = new Padding();

                        objFramePadding.Bottom = objTabControlSkin.BottomFrameHeight;
                        objFramePadding.Top = objTabControlSkin.TopFrameHeight;
                        objFramePadding.Left = objTabControlSkin.LeftFrameWidth;
                        objFramePadding.Right = objTabControlSkin.RightFrameWidth;

                        int intSkinHeaderHeight = this.SkinHeaderHeight;
                        switch (this.Alignment)
                        {
                            case TabAlignment.Bottom:
                                objFramePadding.Bottom += intSkinHeaderHeight;
                                break;
                            case TabAlignment.Left:
                                objFramePadding.Left += intSkinHeaderHeight;
                                break;
                            case TabAlignment.Right:
                                objFramePadding.Right += intSkinHeaderHeight;
                                break;
                            case TabAlignment.Top:
                                objFramePadding.Top += intSkinHeaderHeight;
                                break;
                        }

                        return new PaddingValue(objFramePadding + base.ContainedAreaOffset);
                    }
                }

                return base.ContainedAreaOffset;
            }
        }

        /// <summary>
        /// Gets or sets the index of the currently selected tab page.
        /// </summary>
        ///	<returns>The zero-based index of the currently selected tab page. The default is -1, which is also the value if no tab page is selected.</returns>
        ///	<exception cref="T:System.ArgumentOutOfRangeException">The value is less than -1. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), SRDescription("selectedIndexDescr"), SRCategory("CatBehavior"), DefaultValue(-1)]
        public int SelectedIndex
        {
            get
            {
                int intSelectedIndex = this.GetValue<int>(TabControl.SelectedIndexProperty);
                TabPageCollection objTabPageCollection = this.TabPages;

                // Occures only after adding first tab page to an empty tab control.
                if (intSelectedIndex == -1 &&
                    objTabPageCollection != null &&
                    objTabPageCollection.Count > 0)
                {
                    // Setting the selected index as 0
                    intSelectedIndex = 0;
                    this.SetValue<int>(TabControl.SelectedIndexProperty, intSelectedIndex);
                }

                return intSelectedIndex;
            }
            set
            {
                // If value is invalid, throw an exception
                if (value < -1)
                {
                    object[] arrArgs = new object[] { "SelectedIndex", value.ToString(CultureInfo.CurrentCulture), (-1).ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("SelectedIndex", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
                }

                // If valid tab index
                if (value >= -1 && value < this.TabPages.Count)
                {
                    // If changing, Raise SelectedIndexChanging, giving it a chance to cancel the change
                    if (this.SelectedIndex != value)
                    {
                        // If there is a before selecting event handler
                        if (SelectedIndexChangingHandler != null)
                        {
                            TabControlCancelEventArgs objArgs = null;
                            // Setting index to -1, or when there are no pages, TabPage is null in eventargs
                            if (value == -1 || this.TabPages.Count == 0)
                                objArgs = new TabControlCancelEventArgs(null, false);
                            else
                                objArgs = new TabControlCancelEventArgs(this.TabPages[value], false);
                            SelectedIndexChangingHandler(this, objArgs);
                            if (objArgs.Cancel)
                            {
                                // Sync cancellation to client
                                this.UpdateParams(AttributeType.Control);
                                // Return without change of page
                                return;
                            }
                        }

                        // If is diffrent index
                        if (this.SetValue<int>(TabControl.SelectedIndexProperty, value))
                        {
                            // Update params
                            this.UpdateParams(AttributeType.Control);

                            if (this.SelectedItem != null)
                            {
                                // If tab was not loaded to the client
                                if (!SelectedItem.Loaded)
                                {
                                    // Will cause tab to render
                                    SelectedItem.Update();
                                }
                            }

                            FireObservableItemPropertyChanged("SelectedIndex");

                            OnSelectedIndexChanged(new EventArgs());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the update handler.
        /// </summary>
        /// <value>The update handler.</value>
        protected override string ClientUpdateHandler
        {
            get
            {
                return (this.ClientBehavior == TabControlClientBehavior.DrawingOptimized ? "TabControl_UpdateHandler" : string.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the image list.
        /// </summary>
        /// <value>The image list.</value>
        [RefreshProperties(RefreshProperties.Repaint), SRDescription("TabBaseImageListDescr"), SRCategory("CatAppearance"), DefaultValue((string)null)]
        public ImageList ImageList
        {
            get
            {
                // Setting the value
                return this.GetValue<ImageList>(TabControl.ImageListProperty);
            }
            set
            {

                if (this.SetValue<ImageList>(TabControl.ImageListProperty, value))
                {
                    // Upadte the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the selected item.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TabPage SelectedItem
        {
            get
            {
                TabPageCollection objTabPageCollection = this.TabPages;

                if (this.SelectedIndex > -1 && this.SelectedIndex < objTabPageCollection.Count)
                {
                    return (TabPage)objTabPageCollection[SelectedIndex];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    SelectedIndex = this.TabPages.IndexOf(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the area of the control (for example, along the top) where the tabs are aligned.
        /// </summary>
        /// <returns>
        /// One of the <see cref="T:Gizmox.WebGUI.Forms.TabAlignment"></see> values. The default is Top.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
        /// The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TabAlignment"></see> value. 
        /// </exception>
        [DefaultValue(0), RefreshProperties(RefreshProperties.All), SRDescription("TabBaseAlignmentDescr"), Localizable(true), SRCategory("CatBehavior"), ProxyBrowsable(true)]
        public virtual TabAlignment Alignment
        {
            get
            {
                return this.GetValue<TabAlignment>(TabControl.AlignmentProperty);
            }
            set
            {
                // Check that the enumerator is valid
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(TabAlignment));
                }

                // Left and right currently not supported
                if (value == TabAlignment.Left || value == TabAlignment.Right)
                {
                    throw new NotSupportedException("Tab alignment left and right are currently unsupported.");
                }

                // If alignment has changed
                if (this.SetValue<TabAlignment>(TabControl.AlignmentProperty, value))
                {
                    // If the valud is right or left force multiline
                    if ((value == TabAlignment.Left) || (value == TabAlignment.Right))
                    {
                        this.Multiline = true;
                    }

                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the default alignment.
        /// </summary>
        /// <value>The default alignment.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual TabAlignment DefaultAlignment
        {
            get
            {
                return TabAlignment.Top;
            }
        }

        /// <summary>
        /// Gets or sets the visual appearance of the control's tabs.
        /// </summary>
        ///	<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> values. The default is Normal.</returns>
        ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> value. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(TabAppearance.Normal), Localizable(true), SRDescription("TabBaseAppearanceDescr"), SRCategory("CatBehavior"), ProxyBrowsable(true)]
        public virtual TabAppearance Appearance
        {
            get
            {
                return this.GetValue<TabAppearance>(TabControl.TabAppearanceProperty);
            }
            set
            {
                // If the value has changed
                if (this.SetValue<TabAppearance>(TabControl.TabAppearanceProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether more than one row of tabs can be displayed.
        /// </summary>
        ///	<returns>true if more than one row of tabs can be displayed; otherwise, false. The default is true.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("TabBaseMultilineDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public virtual bool Multiline
        {
            get
            {
                // Setting the value
                return this.GetValue<bool>(TabControl.MultilineProperty);
            }
            set
            {
                // Validate new value
                ValidateExpandAndMultiLine(this.IsExpanded, value, this.ShowExpandButton);

                // If the value has changed
                if (this.SetValue<bool>(TabControl.MultilineProperty, value))
                {
                    FireObservableItemPropertyChanged("Multiline");

                    if (this.CustomStyle == string.Empty)
                    {
                        // Update the control
                        this.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the control enabled state.
        /// </summary>
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                SetEnabled(value, AttributeType.Enabled, false);
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [Localizable(true), SRDescription("TabBasePaddingDescr"), SRCategory("CatBehavior")]
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
        /// Gets or sets the fore color.
        /// </summary>
        /// <value></value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override ResourceHandle BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the item.
        /// </summary>
        /// <value>
        /// The size of the item.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Size ItemSize
        {
            get
            {
                return this.GetValue<Size>(TabControl.ItemSizeProperty);
            }
            set
            {
                this.SetValue<Size>(TabControl.ItemSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected tab.
        /// </summary>
        /// <value>
        /// The selected tab.
        /// </value>
        [SRDescription("TabControlSelectedTabDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatAppearance"), Browsable(false)]
        public TabPage SelectedTab
        {
            get
            {
                return this.SelectedItem;
            }
            set
            {
                this.SelectedItem = value;
            }
        }

        /// <summary>
        /// Gets or sets the max page headers.
        /// </summary>
        /// <value>
        /// The max page headers.
        /// </value>
        [SRCategory("CatAppearance"), SRDescription("MaxTabPageHeadersDescr"), DefaultValue(0)]
        public virtual int MaxTabPageHeaders
        {
            get
            {
                return this.GetValue<int>(TabControl.MaxTabPageHeadersProperty);
            }
            set
            {
                if (this.SetValue<int>(TabControl.MaxTabPageHeadersProperty, value))
                {
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }


        /// <summary>Gets or sets the way that the control's tabs are sized.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.TabSizeMode"></see> values. The default is Normal.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:System.Windows.Forms.TabSizeMode"></see> value. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("TabBaseSizeModeDescr"), SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), DefaultValue(TabSizeMode.Normal)]
        public TabSizeMode SizeMode
        {
            get
            {
                return TabSizeMode.Normal;

            }
            set
            { }
        }



        /// <summary>
        /// Gets or Sets value indication if the close button should be shown
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show expand button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public virtual bool ShowExpandButton
        {
            get
            {
                return this.GetValue<bool>(TabControl.ShowExpandButtonProperty);
            }
            set
            {
                bool blnIsExpanded = this.IsExpanded;

                // Validate new value
                ValidateExpandAndMultiLine(blnIsExpanded, this.Multiline, value);
                ValidateExpandAndDock(blnIsExpanded, this.Dock, value);

                if (this.SetValue<bool>(TabControl.ShowExpandButtonProperty, value))
                {
                    this.UpdateParams(AttributeType.Visual, false);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether tab control is expanded.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this tab control is expanded; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public virtual bool IsExpanded
        {
            get
            {
                return this.GetValue<bool>(TabControl.IsExpandedProperty);
            }
            set
            {
                SetIsExpanded(value, false);
            }
        }

        /// <summary>
        /// Gets the height of the header.
        /// </summary>
        /// <value>
        /// The height of the header.
        /// </value>
        internal int SkinHeaderHeight
        {
            get
            {
                int intHeaderHeight = this.HeaderHeight;
                // If not set
                if (intHeaderHeight == -1)
                {
                    // Get Header height from skin
                    TabControlSkin objTabControlSkin = this.Skin as TabControlSkin;
                    if (objTabControlSkin != null)
                    {
                        int intTabHeight = this.Appearance == TabAppearance.Spread ? objTabControlSkin.TabSpreadHeight : objTabControlSkin.TabHeight;
                        intHeaderHeight = this.HeaderHeight = (this.ContextualTabGroupsInternal != null && this.ContextualTabGroupsInternal.Count > 0 ? (objTabControlSkin.ContextualTabGroupHeight + intTabHeight) : intTabHeight) + objTabControlSkin.Padding.Top;
                    }
                }

                return intHeaderHeight;
            }
        }


        /// <summary>
        /// Gets or sets the headers offset.
        /// </summary>
        /// <value>
        /// The headers offset.
        /// </value>
        [DefaultValue(-1)]
        public int HeadersOffset
        {
            get
            {
                return this.GetValue<int>(TabControl.HeadersOffsetProperty);
            }
            set
            {
                if (this.SetValue<int>(TabControl.HeadersOffsetProperty, value))
                {
                    // Update visual paramsparams.
                    this.UpdateParams(AttributeType.Visual, false);
                }
            }
        }

        /// <summary>
        /// Gets the contextual tab groups.
        /// </summary>
        /// <value>
        /// The contextual tab groups.
        /// </value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [WebEditor(typeof(ContextualTabGroupCollectionEditor), typeof(WebUITypeEditor))]
        [MergableProperty(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(true)]
        public virtual ContextualTabGroupCollection ContextualTabGroups
        {
            get
            {
                ContextualTabGroupCollection objContextualTabGroupCollection = this.ContextualTabGroupsInternal;

                // Create new collection if current is null 
                if (objContextualTabGroupCollection == null)
                {
                    objContextualTabGroupCollection = new ContextualTabGroupCollection(this);

                    this.ContextualTabGroupsInternal = objContextualTabGroupCollection;
                }

                return objContextualTabGroupCollection;
            }
        }

        /// <summary>
        /// Gets or sets the contextual tab groups internal.
        /// </summary>
        /// <value>
        /// The contextual tab groups internal.
        /// </value>
        internal ContextualTabGroupCollection ContextualTabGroupsInternal
        {
            get
            {
                return this.GetValue<ContextualTabGroupCollection>(TabControl.ContextualTabGroupCollectionProperty);
            }
            set
            {
                this.SetValue<ContextualTabGroupCollection>(TabControl.ContextualTabGroupCollectionProperty, value);
            }
        }

        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                ValidateExpandAndDock(this.IsExpanded, value, this.ShowExpandButton);
                base.Dock = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [should use client update handler].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [should use client update handler]; otherwise, <c>false</c>.
        /// </value>
        internal virtual bool ShouldUseClientUpdateHandler
        {
            get
            {
                return this.ClientBehavior == TabControlClientBehavior.DrawingOptimized;
            }
        }

        #endregion Properties

        #region ISupportInitialize

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        void ISupportInitialize.BeginInit()
        {
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        void ISupportInitialize.EndInit()
        {
            if (!this.DesignMode)
            {
                ApplyHeight(false);
            }
        }

        #endregion

        #region INavigationControl

        /// <summary>
        /// Navigate to first view.
        /// </summary>
        /// <returns></returns>
        bool INavigationControl.MoveFirst()
        {
            if (this.TabPages.Count > 0)
            {
                this.SelectedIndex = 0;
                
                return true;
            }

            return false;
        }

        /// <summary>
        /// Navigate to last view.
        /// </summary>
        /// <returns></returns>
        bool INavigationControl.MoveLast()
        {
            if (this.TabPages.Count > 0)
            {
                this.SelectedIndex = this.TabPages.Count - 1;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Navigate to next view.
        /// </summary>
        /// <returns></returns>
        bool INavigationControl.MoveNext()
        {
            if (this.TabPages.Count > 0 && this.SelectedIndex < this.TabPages.Count)
            {
                this.SelectedIndex++;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Navigate to Previous view.
        /// </summary>
        /// <returns></returns>
        bool INavigationControl.MovePrevious()
        {
            if (this.TabPages.Count > 0 && this.SelectedIndex > 0)
            {
                this.SelectedIndex--;

                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Gets the number of views.
        /// </summary>
        int INavigationControl.Count
        {
            get 
            {
                return TabPages.Count;
            }
        }

        /// <summary>
        /// move to specific tab page.
        /// </summary>
        /// <returns></returns>
        void INavigationControl.MoveTo(int intIndex)
        {
            if (intIndex < 0) { return; }
            if (intIndex > TabPages.Count - 1) { return; }

            SelectedIndex = intIndex;
        }

        /// <summary>
        /// Gets the selected index.
        /// </summary>
        int INavigationControl.SelectedIndex
        {
            get 
            {
                return SelectedIndex;
            }
        }

        #endregion INavigationControl
    }

    #endregion TabControl Class

    #region TabPage

    /// <summary>
    /// Represents a single tab page in a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see>.
    /// </summary>
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [DesignTimeVisible(false), ToolboxItem(false), DefaultProperty("Text")]
    [Serializable()]
    [MetadataTag(WGTags.TabPage), Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.TabPageSkin))]
    [ProxyComponent(typeof(ProxyTabPage))]
    public class TabPage : Panel, IComparable
    {
        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to TabAppearance property.
        /// </summary>
        private static SerializableProperty TabAppearanceProperty = SerializableProperty.Register("TabAppearance", typeof(TabAppearance), typeof(TabPage), new SerializablePropertyMetadata(TabAppearance.Normal));

        /// <summary>
        /// Provides a property reference to Loaded property.
        /// </summary>
        private static SerializableProperty LoadedProperty = SerializableProperty.Register("Loaded", typeof(bool), typeof(TabPage), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to Visible property.
        /// </summary>
        private static SerializableProperty VisibleProperty = SerializableProperty.Register("Visible", typeof(bool), typeof(TabPage), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to Image property.
        /// </summary>
        private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(TabPage), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ImageKey property.
        /// </summary>
        private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(TabPage), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to ImageKey property.
        /// </summary>
        private static SerializableProperty HeaderToolTipProperty = SerializableProperty.Register("HeaderToolTip", typeof(string), typeof(TabPage), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to ImageIndex property.
        /// </summary>
        private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(TabPage), new SerializablePropertyMetadata(-1));

        /// <summary>
        /// Provides a property reference to ContextualTabGroup property.
        /// </summary>
        private static SerializableProperty ContextualTabGroupProperty = SerializableProperty.Register("ContextualTabGroupProperty", typeof(ContextualTabGroup), typeof(TabPage), new SerializablePropertyMetadata(null));

        #endregion Serializable Properties

        /// <summary>
        /// Represents Image of the tab if exists
        /// </summary>
        internal ResourceHandle ImageInternal
        {
            get
            {
                // Get Image value
                return this.GetValue<ResourceHandle>(TabPage.ImageProperty);
            }
            set
            {
                // Setting the new value
                this.SetValue<ResourceHandle>(TabPage.ImageProperty, value);
            }
        }

        #endregion Class Members

        #region C'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> class.
        /// </summary>
        public TabPage()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> class and specifies the text for the tab.
        /// </summary>
        ///	<param name="strText">The text for the tab. </param>
        public TabPage(string strText)
        {
            Text = strText;
        }

        #endregion C'Tors

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance is redrawing its contained controls.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is redrawing; otherwise, <c>false</c>.
        /// </value>
        internal override bool Redraws
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the header tool tip.
        /// </summary>
        /// <value>
        /// The header tool tip.
        /// </value>
        [DefaultValue("")]
        public string HeaderToolTip
        {
            get
            {
                return this.GetValue<string>(TabPage.HeaderToolTipProperty, string.Empty);
            }
            set
            {
                if (this.SetValue<string>(TabPage.HeaderToolTipProperty, value))
                {
                    this.UpdateParams(AttributeType.ToolTip);
                }
            }
        }

        /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
        /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
        /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), SRDescription("ListViewItemImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        public int ImageIndex
        {
            get
            {
                // get the value
                return this.ImageIndexInternal;
            }
            set
            {
                // If value has changed
                if (this.ImageIndexInternal != value)
                {
                    //reset ImageKey value
                    this.ImageKeyInternal = string.Empty;

                    //update value
                    this.ImageIndexInternal = value;

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the image index internal.
        /// </summary>
        /// <value>The image index internal.</value>
        internal int ImageIndexInternal
        {
            get
            {
                // Setting the value
                return this.GetValue<int>(TabPage.ImageIndexProperty);
            }
            set
            {
                // Setting the value
                this.SetValue<int>(TabPage.ImageIndexProperty, value);
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
        /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), Localizable(true), DefaultValue("")]
        public string ImageKey
        {
            get
            {
                return this.ImageKeyInternal;
            }
            set
            {
                if (this.ImageKeyInternal != value)
                {
                    //reset ImageIndex value
                    this.ImageIndexInternal = -1;

                    //update value
                    this.ImageKeyInternal = value;

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the image key internal.
        /// </summary>
        /// <value>The image key internal.</value>
        internal string ImageKeyInternal
        {
            get
            {
                return this.GetValue<string>(TabPage.ImageKeyProperty);
            }
            set
            {
                this.SetValue<string>(TabPage.ImageKeyProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the appearance.
        /// </summary>
        /// <value>
        /// The appearance.
        /// </value>
        internal protected virtual TabAppearance Appearance
        {
            get
            {
                return this.GetValue<TabAppearance>(TabPage.TabAppearanceProperty);
            }
            set
            {
                // If the value has changed
                if (this.SetValue<TabAppearance>(TabPage.TabAppearanceProperty, value))
                {
                    // Update the control
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Shows the serialize image.
        /// </summary>
        protected bool ShouldSerializeImage()
        {
            if (this.TabControl != null && this.TabControl.ImageList != null)
            {
                return false;
            }
            else
            {
                return (this.ImageInternal != null);
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public ResourceHandle Image
        {
            get
            {
                return this.GetImage(TabPage.ImageProperty, ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
            }
            set
            {
                this.SetImage(TabPage.ImageProperty, value, ImageList);
            }
        }

        /// <summary>
        /// Gets the image list.
        /// </summary>
        /// <value>The image list.</value>
        private ImageList ImageList
        {
            get
            {
                // If there is a valid list view owner for this list item
                if (this.TabControl != null)
                {
                    return this.TabControl.ImageList;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:Gizmox.WebGUI.Forms.TabControl"/> control.
        /// </summary>
        [Browsable(false)]
        public TabControl TabControl
        {
            get
            {
                return (TabControl)InternalParent;
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
        /// Gets or sets the panel type.
        /// </summary>
        [Browsable(false)]
        new public PanelType PanelType
        {
            get
            {
                return base.PanelType;
            }
            set
            {
                base.PanelType = value;
            }
        }

        /// <summary>
        /// Gets or sets the tab index.
        /// </summary>
        /// <value></value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Gets a value indicating whether this <see cref="TabPage"/> is loaded.
        /// </summary>
        /// <value><c>true</c> if loaded; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool Loaded
        {
            get
            {
                return this.InternalLoaded;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tabpage was loaded.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the tabpage was loaded; otherwise, <c>false</c>.
        /// </value>
        internal bool InternalLoaded
        {
            get
            {
                return this.GetValue<bool>(TabPage.LoadedProperty);
            }
            set
            {
                this.SetValue<bool>(TabPage.LoadedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text to display on the tab.
        /// </summary>
        ///	<returns>The text to display on the tab.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), EditorBrowsable(EditorBrowsableState.Always), Browsable(true), ProxyBrowsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the tab visability.
        /// </summary>
        /// <value></value>
        [DefaultValue(true)]
        [SRDescription("ControlVisibleDescr")]
        [SRCategory("CatBehavior")]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                base.Visible = value;
            }
        }

        /// <summary>
        /// Sets the visible internal.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> set visibility true.</param>
        internal override void SetVisibleInternal(bool blnValue)
        {
            if (!this.DesignMode)
            {
                // If the value has changed
                if (this.SetValue<bool>(TabPage.VisibleProperty, blnValue))
                {
                    this.OnVisibleChanged(EventArgs.Empty);

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Create a control.
        /// </summary>
        /// <param name="blnVisible">if set to <c>true</c> [BLN visible].</param>
        protected override void DoCreateControl(bool blnVisible)
        {
            // Get parent tabcontrol.
            TabControl objTabControl = this.TabControl;
            if (objTabControl != null)
            {
                // Update tabcotnrol.
                objTabControl.Update(false, objTabControl.ShouldUseClientUpdateHandler);

                // Check if visibility should turn true and parent tabcotnrol was already created.
                if (blnVisible && objTabControl.Created)
                {
                    this.CreateControl();
                }
            }
        }

        /// <summary>
        /// Returns the visibility internally
        /// </summary>
        /// <returns></returns>
        internal override bool GetVisibleCore()
        {
            return this.GetValue<bool>(TabPage.VisibleProperty);
        }

        /// <summary>This member is not meaningful for this control.</summary>
        /// <returns>A <see cref="T:GizmoxWebGUI.DockStyle"></see> value.</returns>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override DockStyle Dock
        {
            get
            {
                return DockStyle.Fill;
            }
            set
            {
                base.Dock = value;
            }
        }

        /// <summary>
        /// This property is not relevant for this class.
        /// </summary>
        /// <value></value>
        /// <returns>true if enabled; otherwise, false.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }



        /// <summary>
        /// Indicates the automatic sizing behavior of the control.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override AutoSizeMode AutoSizeMode
        {
            get
            {
                return AutoSizeMode.GrowOnly;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets a value indicating whether [use preferred size].
        /// </summary>
        /// <value><c>true</c> if [use preferred size]; otherwise, <c>false</c>.</value>
        protected internal override bool UsePreferredSize
        {
            get
            {
                return false;
            }
        }


        /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.TabPage"></see> background renders using the current visual style when visual styles are enabled.</summary>
        /// <returns>true to render the background using the current visual style; otherwise, false. The default is false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("TabItemUseVisualStyleBackColorDescr"), DefaultValue(false), SRCategory("CatAppearance")]
        public bool UseVisualStyleBackColor
        {
            get
            {
                return false;
            }
            set
            { }
        }

        /// <summary>
        /// Gets or sets the contextual tab group key.
        /// </summary>
        /// <value>
        /// The contextual tab group key.
        /// </value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [DefaultValue(null), MergableProperty(false)]
        public virtual ContextualTabGroup ContextualTabGroup
        {
            get
            {
                return this.GetValue<ContextualTabGroup>(TabPage.ContextualTabGroupProperty);
            }
            set
            {
                // Get tab control
                TabControl objTabControl = this.TabControl;
                if ((value != null) && objTabControl != null)
                {
                    // Check ContextualTabGroup exist in tabcontrol ContextualTabGroups
                    ContextualTabGroupCollection objContextualTabGroups = objTabControl.ContextualTabGroupsInternal;
                    if (objContextualTabGroups == null || !objContextualTabGroups.Contains(value))
                    {
                        throw new ArgumentException("ContextualTabGroup");
                    }
                }

                if (this.SetValue<ContextualTabGroup>(TabPage.ContextualTabGroupProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);

                    if (objTabControl != null)
                    {
                        objTabControl.Update(true);
                    }
                }
            }
        }

        #endregion Properties

        #region Methods

        #region Render

        /// <summary>
        /// Shoulds the content of the control.
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRenderContent()
        {
            // If not loaded and not selected tab return false
            if (!(this.TabControl.SelectedItem == this || this.Loaded))
            {
                return false;
            }

            // If parent exists return it's should render content, otherwise return true.
            Control objParent = this.ParentInternal;
            if (objParent != null)
            {
                return objParent.ShouldRenderContentInternal();
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Render control attributes
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            if (TabControl.SelectedItem == this)
            {
                this.InternalLoaded = true;
            }

            objWriter.WriteAttributeString(WGAttributes.Loaded, this.InternalLoaded ? "1" : "0");

            int intFontHeight = CommonUtils.GetFontHeight(this.Font) ;

            //Render the text container height only if the font is smaller then the tab height
            if (this.Image == null && intFontHeight < this.TabControl.TabControlCurrentSkin.TabHeight)
            {

                objWriter.WriteAttributeString(WGAttributes.TabFontContainerHeight, intFontHeight);
            }

            ResourceHandle objImage = this.Image;
            if (objImage != null)
            {
                objWriter.WriteAttributeString(WGAttributes.Image, objImage.ToString());
            }

            // Render ContextualTabGroup value
            RenderContextualTabGroup(objWriter, false);

            // Render the header tool tip
            RenderHeaderToolTip(objWriter, false);

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

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                // Render ContextualTabGroup value
                RenderContextualTabGroup(objWriter, true);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
            {
                // Render the header tool tip
                RenderHeaderToolTip(objWriter, true);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                RenderAppearanceAttribute(objWriter, true);
            }

        }

        /// <summary>
        /// Renders the header tool tip.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderHeaderToolTip(IAttributeWriter objWriter, bool blnForceRender)
        {
            string strHeaderToolTip = this.HeaderToolTip;

            if (!string.IsNullOrEmpty(strHeaderToolTip) || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.HeaderToolTip, strHeaderToolTip != null ? strHeaderToolTip : string.Empty);
            }
        }

        /// <summary>
        /// Renders the appearance attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            TabAppearance enmAppearance = this.Appearance;

            if (enmAppearance != TabAppearance.Normal || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Appearance, (int)enmAppearance);
            }
        }

        /// <summary>
        /// Renders the contextual tab group.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderContextualTabGroup(IAttributeWriter objWriter, bool blnForceRender)
        {
            string strContextualTabGroup = string.Empty;

            // Get ContextualTabGroup value
            ContextualTabGroup objContextualTabGroup = this.ContextualTabGroup;

            // Check if ContextualTabGroup is valud
            if (objContextualTabGroup != null)
            {
                ContextualTabGroupCollection objContextualTabGroups = this.TabControl.ContextualTabGroupsInternal;

                if (objContextualTabGroups != null)
                {
                    // Get ContextualTabGroup position in collection
                    int intPosition = objContextualTabGroups.IndexOf(objContextualTabGroup);
                    if (intPosition != -1)
                    {
                        strContextualTabGroup = intPosition.ToString();
                    }
                }
            }

            if (!string.IsNullOrEmpty(strContextualTabGroup) || blnForceRender)
            {
                // Render ContextualTabGroup position
                objWriter.WriteAttributeString(WGAttributes.ContextualTabGroup, strContextualTabGroup.ToString());
            }
        }

        #endregion Render

        /// <summary>
        /// Returns a string containing the value of the <see cref="P:Gizmox.WebGUI.Forms.TabPage.Text"></see> property.
        /// </summary>
        ///	<returns>A string containing the value of the <see cref="P:Gizmox.WebGUI.Forms.TabPage.Text"></see> property.</returns>
        public override string ToString()
        {
            return ("TabPage: {" + this.Text + "}");
        }


        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new TabPageRenderer(this);
        }

        #region IComparable Members

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj"/>. Zero This instance is equal to <paramref name="obj"/>. Greater than zero This instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="obj"/> is not the same type as this instance. </exception>
        public int CompareTo(object obj)
        {
            TabPage objTabPage = obj as TabPage;
            if (objTabPage == null)
            {
                throw new ArgumentException();
            }

            // Sort by the TabIndex property of TabPage
            return this.TabIndex.CompareTo(objTabPage.TabIndex);
        }

        #endregion

        /// <summary>
        /// Applies the pre release dock fill compatibility.
        /// </summary>
        protected internal override void ApplyPreReleaseDockFillCompatibility()
        {
            // Prevent PreReleaseDockFillCompatibility in order to prevent changing of tab page indexes.
        }

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        public override void Update()
        {
            base.Update();

            UpdateTabControl();
        }

        /// <summary>
        /// Redraw only
        /// </summary>
        /// <param name="blnRedrawOnly"></param>
        public override void Update(bool blnRedrawOnly)
        {
            base.Update(blnRedrawOnly);

            UpdateTabControl();
        }

        /// <summary>
        /// Updates the tab control.
        /// </summary>
        private void UpdateTabControl()
        {
            TabControl objParent = this.Parent as TabControl;

            if (objParent != null)
            {
                objParent.Update(true, objParent.ShouldUseClientUpdateHandler);
            }
        }

        /// <summary>
        /// Updates only the parameters of this instance.
        /// </summary>
        public override void UpdateParams()
        {
            base.UpdateParams();
            UpdateTabControl();
        }

        /// <summary>
        /// Updates the params.
        /// </summary>
        /// <param name="enmParams">The enm params.</param>
        public override void UpdateParams(AttributeType enmParams)
        {
            base.UpdateParams(enmParams);
            UpdateTabControl();
        }

        #endregion Methods
    }

    #endregion TabPage

    #region TabPageEventArgs Class

    /// <summary>
    /// Represents the method that will handle events of a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> control. 
    /// </summary>
    public delegate void TabPageEventHandler(object objSource, TabPageEventArgs objArgs);

    /// <summary>
    /// Provides data for events of a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> control. 
    /// </summary>
    [Serializable()]
    public class TabPageEventArgs : EventArgs
    {
        #region Class Members

        /// <summary>
        /// Represents the <see cref="T:Gizmox.WebGUI.Forms.TabPage"/>
        /// </summary>
        public readonly TabPage TabPage;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPageEventArgs"/> class.
        /// </summary>
        /// <param name="objTabPage">The tab page.</param>
        public TabPageEventArgs(TabPage objTabPage)
        {
            TabPage = objTabPage;
        }

        #endregion C'Tor / D'Tor
    }

    #endregion TabPageEventArgs Class

    #region TabPageCollection

    /// <summary>
    /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects.
    /// </summary>
    [Serializable()]
    public class TabPageCollection : ICollection, IEnumerable, IList, IComparer
    {
        #region Class Members

        /// <summary>
        /// The owner tab control
        /// </summary>
        private TabControl mobjTabControl = null;

        #endregion Class Members

        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> class.
        /// </summary>
        ///	<param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> that this collection belongs to. </param>
        ///	<exception cref="T:System.ArgumentNullException">The specified <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabPageCollection(TabControl objOwner)
        {
            mobjTabControl = objOwner;
        }

        #endregion C'Tor

        #region Members

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        protected TabControl Owner
        {
            get { return mobjTabControl; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is synchronized (thread safe).
        /// </summary>
        ///	<returns>false in all cases.</returns>
        public bool IsSynchronized
        {
            get
            {
                return ((ICollection)mobjTabControl.Controls).IsSynchronized;
            }
        }

        /// <summary>
        /// Gets the number of tab pages in the collection.
        /// </summary>
        ///	<returns>The number of tab pages in the collection.</returns>
        [Browsable(false)]
        public int Count
        {
            get
            {
                return mobjTabControl.Controls.Count;
            }
        }

        /// <summary>
        /// Copies the elements of the collection to the specified array, starting at the specified index.
        /// </summary>
        ///	<param name="objDestArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
        ///	<param name="index">The zero-based index in the array at which copying begins.</param>
        ///	<exception cref="T:System.ArgumentException">dest is multidimensional.-or-index is equal to or greater than the length of dest.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is greater than the available space from index to the end of dest.</exception>
        ///	<exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
        ///	<exception cref="T:System.InvalidCastException">The items in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> cannot be cast automatically to the type of dest.</exception>
        ///	<exception cref="T:System.ArgumentNullException">dest is null.</exception>
        public void CopyTo(Array objDestArray, int index)
        {
            mobjTabControl.Controls.CopyTo(objDestArray, index);
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
        /// </summary>
        ///	<returns>An object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.</returns>
        public object SyncRoot
        {
            get
            {
                return ((ICollection)mobjTabControl.Controls).SyncRoot;
            }
        }

        /// <summary>
        /// Adds a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to the collection.
        /// </summary>
        ///	<param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to add. </param>
        ///	<exception cref="T:System.ArgumentNullException">The specified value is null. </exception>
        public virtual int Add(TabPage objTabPage)
        {
            Insert(this.Count, objTabPage);
            return mobjTabControl.Controls.IndexOf(objTabPage);
        }

        /// <summary>
        /// Removes a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> from the collection.
        /// </summary>
        ///	<param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove. </param>
        ///	<exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
        public virtual void Remove(TabPage objTabPage)
        {
            mobjTabControl.Controls.Remove(objTabPage);
        }

        /// <summary>
        /// Returns an enumeration of all the tab pages in the collection.
        /// </summary>
        ///	<returns>An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.</returns>
        public IEnumerator GetEnumerator()
        {
            return mobjTabControl.Controls.GetEnumerator();
        }

        /// <summary>
        /// Returns the index of the specified tab page in the collection.
        /// </summary>
        ///	<returns>The zero-based index of the tab page; -1 if it cannot be found.</returns>
        ///	<param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to locate in the collection. </param>
        ///	<exception cref="T:System.ArgumentNullException">The value of page is null. </exception>
        public int IndexOf(TabPage objTabPage)
        {
            return mobjTabControl.Controls.IndexOf(objTabPage);
        }

        /// <summary>
        /// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection.
        /// </summary>
        ///	<returns>The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> at the specified index.</returns>
        ///	<param name="index">The zero-based index of the tab page to get or set. </param>
        ///	<exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the highest available index. </exception>
        public TabPage this[int index]
        {
            get
            {
                return (TabPage)mobjTabControl.Controls[index];
            }
        }

        #endregion Members

        #region IList Members

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        ///	<returns>This property always returns false.</returns>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection.
        /// </summary>
        ///	<returns>The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> at the specified index.</returns>
        ///	<param name="index">The zero-based index of the element to get.</param>
        ///	<exception cref="T:System.ArgumentException">The value is not a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see>.</exception>
        object IList.this[int index]
        {
            get
            {
                return mobjTabControl.Controls[index];
            }
            set
            {

            }
        }

        /// <summary>
        /// Removes the tab page at the specified index from the collection.
        /// </summary>
        ///	<param name="index">The zero-based index of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove. </param>
        public void RemoveAt(int index)
        {
            mobjTabControl.Controls.RemoveAt(index);
        }

        /// <summary>
        /// Inserts an existing tab page into the collection at the specified index. 
        /// </summary>
        ///	<param name="index">The location where the tab page is inserted.</param>
        ///	<param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to insert in the collection.</param>
        public void Insert(int index, object objTabPage)
        {
            TabPage objNewTabPage = objTabPage as TabPage;
            Hashtable ObjTabIndexHashTable = new Hashtable();

            // if received variable is not a TabPage, exit immediately
            if (objNewTabPage == null)
            {
                return;
            }
            // if the current TabPageCollection is not holding any TabPages
            if (this.Count == 0)
            {
                // adding the TabPage to the current TabPageCollection
                mobjTabControl.Controls.Add(objNewTabPage);
            }
            else
            {
                // Saving all actual indexes into tabindexes.
                foreach (TabPage objPage in this)
                {
                    ObjTabIndexHashTable.Add(objPage.GetHashCode(), objPage.TabIndex);
                    objPage.TabIndex = this.IndexOf(objPage);
                }

                // if requested index is out of range, set the tab, at the end of the sequence.
                if (index > this.Count || index < 0)
                {
                    index = this.Count;
                }

                // advancing the TabIndex of all TabPages with a TabIndex value that is equal or greater than 'index'.
                this.AdvanceTabIndexFromIndex((ushort)index, 1);
                // adding the TabPage to the current TabPageCollection
                mobjTabControl.Controls.Add(objNewTabPage);
                objNewTabPage.TabIndex = index;

                // Sorting tabs by TabIndexes
                mobjTabControl.Controls.Sort(new TabIndexComparer());
            }
        }

        /// <summary>
        /// Returns a sorted TabPage list from current unsorted TabPageCollection.
        /// </summary>
        /// <returns></returns>
        protected ArrayList GetSortedTabPageListFromCurrent(bool blnSortByIndex)
        {
            // Creating an Array and copying all TabPages from 'this' to a TabPage Array and sorting by TabIndex.            
            ArrayList objTabPageList;
            objTabPageList = new ArrayList();

            foreach (TabPage objTabPage in this)
            {
                objTabPageList.Add(objTabPage);
            }

            if (blnSortByIndex) // Sorting by the index of the TabPageCollection.
            {

                objTabPageList.Sort(this);
            }
            else               // Sorting by the TabIndex property of TabPage.
            {
                objTabPageList.Sort(new TabIndexComparer());
            }
            return objTabPageList;
        }

        /// <summary>
        /// Advances the TabIndex property by the value of 'advanceBy', begginning at the 'fromIndex' position.
        /// </summary>
        /// <param name="usrFromIndex">Index of the usr from.</param>
        /// <param name="usrAdvanceBy">The usr advance by.</param>
        protected void AdvanceTabIndexFromIndex(ushort usrFromIndex, ushort usrAdvanceBy)
        {
            if (this.Count < 2)
            {
                return;
            }

            // Getting a list of all the TabPages, sorted by the index of the TabPageCollection
            ArrayList objTabPageList = GetSortedTabPageListFromCurrent(true);
            this.AdvanceTabIndexFromIndex(ref objTabPageList, usrFromIndex, usrAdvanceBy);
        }

        /// <summary>
        /// Advances the TabIndex property by the value of 'advanceBy', begginning at the 'fromIndex' position.
        /// </summary>
        /// <param name="objTabPageList">The obj tab page list.</param>
        /// <param name="usrFromIndex">Index of the usr from.</param>
        /// <param name="usrAdvanceBy">The usr advance by.</param>
        protected void AdvanceTabIndexFromIndex(ref ArrayList objTabPageList, ushort usrFromIndex, ushort usrAdvanceBy)
        {
            TabPage objTabPage = null;
            // if received invalid input, exit immediately.
            if (usrFromIndex < 0 || usrAdvanceBy <= 0 || usrFromIndex > (objTabPageList.Count - 1))
            {
                return;
            }

            for (ushort usrInd = usrFromIndex; usrInd < objTabPageList.Count; usrInd++)
            {
                objTabPage = objTabPageList[usrInd] as TabPage;
                if (objTabPage == null)
                {
                    continue;
                }

                objTabPage.TabIndex += usrAdvanceBy;
            }
        }

        /// <summary>
        /// Removes a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> from the collection.
        /// </summary>
        ///	<param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove.</param>
        void IList.Remove(object objValue)
        {
            mobjTabControl.Controls.Remove((TabPage)objValue);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control is in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
        /// </summary>
        ///	<returns>true if the specified object is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection; otherwise, false.</returns>
        ///	<param name="objValue">The object to locate in the collection.</param>
        public bool Contains(object objValue)
        {
            return mobjTabControl.Controls.Contains((TabPage)objValue);
        }

        /// <summary>
        /// Removes all the tab pages from the collection.
        /// </summary>
        public void Clear()
        {
            mobjTabControl.Controls.Clear();
        }

        /// <summary>
        /// Returns the index of the specified <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control in the collection.
        /// </summary>
        ///	<returns>The zero-based index if page is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection; otherwise -1.</returns>
        ///	<param name="objPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to locate in the collection.</param>
        int IList.IndexOf(object objPage)
        {
            if (objPage is TabPage)
            {
                return this.IndexOf((TabPage)objPage);
            }
            return -1;
        }

        /// <summary>
        /// Adds a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control to the collection.
        /// </summary>
        ///	<returns>The position into which the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> was inserted.</returns>
        ///	<param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to add to the collection.</param>
        ///	<exception cref="T:System.ArgumentException">value is not a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see>.</exception>
        ///	<exception cref="T:System.ArgumentNullException">value is null.</exception>
        int IList.Add(object objValue)
        {
            if (objValue is TabPage)
            {
                return this.Add((TabPage)objValue);
            }
            throw new ArgumentException("value");
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> has a fixed size.
        /// </summary>
        ///	<returns>false in all cases.</returns>
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        #endregion IList Members

        #region IComparer Members

        /// <summary>
        /// Compares the index of two sequencial TabPages in the TabPageCollection.
        /// </summary>
        /// <param name="objArgFirstTP">The first TabPage.</param>
        /// <param name="objArgSecondTP">The second TabPage.</param>
        /// <returns></returns>
        public int Compare(object objArgFirstTP, object objArgSecondTP)
        {
            TabPage objFirstTabPage = objArgFirstTP as TabPage;
            TabPage objSecondTabPage = objArgSecondTP as TabPage;

            if (objFirstTabPage == null || objSecondTabPage == null)
            {
                return 0;
            }

            return this.IndexOf(objFirstTabPage).CompareTo(this.IndexOf(objSecondTabPage));
        }

        /// <summary>
        /// Implements IComparer for TabPages sorting by TabIndex
        /// </summary>
        /// <returns></returns>
        [Serializable()]
        private class TabIndexComparer : IComparer
        {
            #region IComparer Members

            int IComparer.Compare(object objX, object objY)
            {
                TabPage objControlX = objX as TabPage;
                TabPage objControlY = objY as TabPage;
                if (objControlX != null && objControlY != null)
                {
                    int intResult = objControlX.TabIndex.CompareTo(objControlY.TabIndex);
                    return intResult;
                }
                return 0;
            }

            #endregion
        }

        #endregion
    }

    #endregion TabPageCollection

    #region ContextualTabGroup Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable, DesignTimeVisible(false), ToolboxItem(false)]
    public class ContextualTabGroup : SerializableObject, IComponent
    {

        #region Class Members

        private TabControl mobjTabControl = null;

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to Text property.
        /// </summary>
        private static SerializableProperty TextProperty = SerializableProperty.Register("TextProperty", typeof(string), typeof(ContextualTabGroup), new SerializablePropertyMetadata(string.Empty));

        #endregion Serializable Properties

        #endregion Class Members

        #region C'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualTabGroup"/> class.
        /// </summary>
        public ContextualTabGroup()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualTabGroup"/> class.
        /// </summary>
        /// <param name="strKey">The contextual tab group Key.</param>
        /// <param name="strText">The contextual tab group Text.</param>
        public ContextualTabGroup(string strText)
        {
            this.Text = strText;
        }


        #endregion C'Tors

        #region Properties

        /// <summary>
        /// Gets or sets the contextual tab group key.
        /// </summary>
        /// <value>
        /// The contextual tab group text.
        /// </value>
        [DefaultValue("")]
        public string Text
        {
            get
            {
                return this.GetValue<string>(ContextualTabGroup.TextProperty);
            }
            set
            {
                if (this.SetValue<string>(ContextualTabGroup.TextProperty, value))
                {
                    if (mobjTabControl != null)
                    {
                        // Update tab control
                        mobjTabControl.Update();
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets the tab control internal.
        /// </summary>
        /// <value>
        /// The tab control internal.
        /// </value>
        internal TabControl TabControlInternal
        {
            get
            {
                return mobjTabControl;
            }
            set
            {
                mobjTabControl = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            // Get ContextualTabGroup text
            string strThisText = this.Text;

            if (!string.IsNullOrEmpty(strThisText))
            {
                // Add brackets if text is not empty
                strThisText = string.Concat(" [", strThisText, "]");
            }

            ISite objSite = this.mobjSite;
            if (objSite != null)
            {
                // In design mode return component name + ContextualTabGroup text
                return (string.Concat(objSite.Name, strThisText));
            }

            // In run time return type + ContextualTabGroup text
            return string.Concat(this.GetType().FullName, strThisText);
        }

        #endregion Methods


        #region IComponent Members

        /// <summary>
        /// The disposed event 
        /// </summary>
        private static readonly SerializableEvent DisposedEvent = SerializableEvent.Register("DisposedEvent", typeof(EventHandler), typeof(ContextualTabGroup));

        /// <summary>Adds an event handler to listen to the <see cref="E:System.ComponentModel.Component.Disposed"></see> event on the component.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler Disposed
        {
            add
            {
                this.AddHandler(ContextualTabGroup.DisposedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ContextualTabGroup.DisposedEvent, value);
            }
        }

        [NonSerialized()]
        private ISite mobjSite;

        /// <summary>
        /// Gets or sets the <see cref="T:System.ComponentModel.ISite"/> associated with the <see cref="T:System.ComponentModel.IComponent"/>.
        /// </summary>
        /// <returns>The <see cref="T:System.ComponentModel.ISite"/> object associated with the component; or null, if the component does not have a site.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISite Site
        {
            get
            {
                return this.mobjSite;
            }
            set
            {
                this.mobjSite = value;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (this)
                {
                    if ((this.mobjSite != null) && (this.mobjSite.Container != null))
                    {
                        this.mobjSite.Container.Remove(this);
                    }

                    EventHandler handler = (EventHandler)this.GetHandler(ContextualTabGroup.DisposedEvent);
                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
            }
        }

        #endregion IComponent Members
    }

    #endregion ContextualTabGroup Class

    #region ContextualTabGroupCollection Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ContextualTabGroupCollection : IList, ICollection, IEnumerable
    {
        #region Members

        /// <summary>
        /// 
        /// </summary>
        private ArrayList mobjGroups;

        /// <summary>
        /// 
        /// </summary>
        private TabControl mobjOwner;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list.</value>
        private ArrayList List
        {
            get
            {
                if (this.mobjGroups == null)
                {
                    this.mobjGroups = new ArrayList();
                }
                return this.mobjGroups;
            }
        }

        /// <summary>Gets the number of groups in the collection.</summary>
        /// <returns>The number of groups in the collection.</returns>
        /// <filterpriority>1</filterpriority>
        public int Count
        {
            get
            {
                return this.List.Count;
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> at the specified index within the collection.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> at the specified index within the collection.</returns>
        /// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to get or set. </param>
        /// <filterpriority>1</filterpriority>
        public ContextualTabGroup this[int index]
        {
            get
            {
                return (ContextualTabGroup)this.List[index];
            }
            set
            {
                if (!this.List.Contains(value))
                {
                    this.List[index] = value;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.</returns>
        bool ICollection.IsSynchronized
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.</returns>
        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, false.</returns>
        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> is read-only; otherwise, false.</returns>
        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> at the specified index.
        /// </summary>
        /// <value></value>
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                if (value is ContextualTabGroup)
                {
                    this[index] = (ContextualTabGroup)value;
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to the collection.</summary>
        /// <returns>The index of the group within the collection, or -1 if the group is already present in the collection.</returns>
        /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to add to the collection. </param>
        public int Add(ContextualTabGroup objGroup)
        {
            if (this.Contains(objGroup))
            {
                return -1;
            }
            if (mobjOwner != null)
            {
                mobjOwner.Update();
            }

            objGroup.TabControlInternal = mobjOwner;

            return this.List.Add(objGroup);

        }

        /// <summary>Adds a new <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to the collection using the specified values to initialize the <see cref="P:Gizmox.WebGUI.Forms.ContextualTabGroup.key"></see> and <see cref="P:Gizmox.WebGUI.Forms.ContextualTabGroup.Text"></see> properties </summary>
        /// <returns>The new <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see>.</returns>
        /// <param name="strKey">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ContextualTabGroup.Key"></see> property for the new group.</param>
        /// <param name="strText">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ContextualTabGroup.Text"></see> property for the new group.</param>
        public ContextualTabGroup Add(string strText)
        {
            ContextualTabGroup objGroup = new ContextualTabGroup(strText);
            this.Add(objGroup);
            return objGroup;
        }

        /// <summary>
        /// Adds an array of groups to the collection.
        /// </summary>
        /// <param name="arrContextualTabGroups">An array of type <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> that specifies the groups to add to the collection.</param>
        public void AddRange(ContextualTabGroup[] arrContextualTabGroups)
        {
            for (int intIndex = 0; intIndex < arrContextualTabGroups.Length; intIndex++)
            {
                this.Add(arrContextualTabGroups[intIndex]);
            }
        }

        /// <summary>
        /// Adds the groups in an existing <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroupCollection"></see> to the collection.
        /// </summary>
        /// <param name="objGroups">A <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroupCollection"></see> containing the groups to add to the collection.</param>
        public void AddRange(ContextualTabGroupCollection objGroups)
        {
            for (int intIndex = 0; intIndex < objGroups.Count; intIndex++)
            {
                this.Add(objGroups[intIndex]);
            }
        }

        /// <summary>
        /// Removes all groups from the collection.
        /// </summary>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public void Clear()
        {
            // Remove all items and clear contextualTabGroup references
            for (int i = this.List.Count - 1; i >= 0; i--)
            {
                this.Remove(this[i], true);
            }
        }

        /// <summary>
        /// Internal clears.
        /// </summary>
        internal void ClearInternal()
        {
            // Remove all items
            for (int i = this.List.Count - 1; i >= 0; i--)
            {
                // Remove item without clearing contextualTabGroup references
                this.Remove(this[i], false);
            }
        }

        /// <summary>
        /// Determines whether the specified group is located in the collection.
        /// </summary>
        /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to locate in the collection.</param>
        /// <returns>
        /// true if the group is in the collection; otherwise, false.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public bool Contains(ContextualTabGroup value)
        {
            return this.List.Contains(value);
        }

        /// <summary>Copies the groups in the collection to a compatible one-dimensional <see cref="T:System.Array"></see>, starting at the specified index of the target array.</summary>
        /// <param name="objArray">The <see cref="T:System.Array"></see> to which the groups are copied. </param>
        /// <param name="index">The first index within the array to which the groups are copied. </param>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(Array objArray, int index)
        {
            this.List.CopyTo(objArray, index);
        }

        /// <summary>Returns an enumerator used to iterate through the collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the collection.</returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        /// <summary>Returns the index of the specified <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> within the collection.</summary>
        /// <returns>The zero-based index of the group within the collection, or -1 if the group is not in the collection.</returns>
        /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to locate in the collection. </param>
        /// <filterpriority>1</filterpriority>
        public int IndexOf(ContextualTabGroup value)
        {
            return this.List.IndexOf(value);
        }

        /// <summary>Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> into the collection at the specified index.</summary>
        /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to insert into the collection. </param>
        /// <param name="index">The index within the collection at which to insert the group. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Insert(int index, ContextualTabGroup objGroup)
        {
            if (!this.Contains(objGroup))
            {
                objGroup.TabControlInternal = mobjOwner;
                this.List.Insert(index, objGroup);
            }
        }

        /// <summary>Removes the specified <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> from the collection.</summary>
        /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to remove from the collection. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Remove(ContextualTabGroup objGroup)
        {
            Remove(objGroup, true);
        }

        /// <summary>
        /// Removes the specified obj group.
        /// </summary>
        /// <param name="objGroup">The obj group.</param>
        /// <param name="blnClearContextualTabGroupReferences">if set to <c>true</c> [BLN clear contextual tab group references].</param>
        private void Remove(ContextualTabGroup objGroup, bool blnClearContextualTabGroupReferences)
        {
            if (blnClearContextualTabGroupReferences)
            {
                // Remove use of this ContextualTabGroup from parent tab pages
                ClearContextualTabGroupReferences(objGroup);
            }

            objGroup.TabControlInternal = null;
            this.List.Remove(objGroup);
        }

        /// <summary>Removes the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> at the specified index within the collection.</summary>
        /// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to remove. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="objValue">The <see cref="T:System.Object"/> to add to the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The position into which the new element was inserted.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        int IList.Add(object objValue)
        {
            if (!(objValue is ContextualTabGroup))
            {
                throw new ArgumentException("objValue");
            }
            return this.Add((ContextualTabGroup)objValue);
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.
        /// </summary>
        /// <param name="objValue">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// true if the <see cref="T:System.Object"/> is found in the <see cref="T:System.Collections.IList"/>; otherwise, false.
        /// </returns>
        bool IList.Contains(object objValue)
        {
            return ((objValue is ContextualTabGroup) && this.Contains((ContextualTabGroup)objValue));
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="objValue">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The index of <paramref name="value"/> if found in the list; otherwise, -1.
        /// </returns>
        int IList.IndexOf(object objValue)
        {
            if (objValue is ContextualTabGroup)
            {
                return this.IndexOf((ContextualTabGroup)objValue);
            }
            return -1;
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.IList"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to insert into the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        /// <exception cref="T:System.NullReferenceException">
        /// 	<paramref name="value"/> is null reference in the <see cref="T:System.Collections.IList"/>.</exception>
        void IList.Insert(int index, object objValue)
        {
            ContextualTabGroup objContextualTabGroup = objValue as ContextualTabGroup;
            if (objContextualTabGroup != null)
            {
                this.Insert(index, objContextualTabGroup);
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="objValue">The <see cref="T:System.Object"/> to remove from the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        void IList.Remove(object objValue)
        {
            ContextualTabGroup objContextualTabGroup = objValue as ContextualTabGroup;
            if (objContextualTabGroup != null)
            {
                this.Remove(objContextualTabGroup);
            }
        }


        /// <summary>
        /// Clears the contextual tab group references.
        /// </summary>
        /// <param name="objContextualTabGroup">The obj contextual tab group.</param>
        private void ClearContextualTabGroupReferences(ContextualTabGroup objContextualTabGroup)
        {
            // Chek for valid tabcontrol
            if (mobjOwner != null)
            {
                // Loop on all tabpages
                for (int i = 0; i < mobjOwner.TabPages.Count; i++)
                {
                    TabPage objTabPage = mobjOwner.TabPages[i];

                    // Check if this ContextualTabGroup in use
                    if (objTabPage.ContextualTabGroup == objContextualTabGroup)
                    {
                        // Clear ContextualTabGroup
                        objTabPage.ContextualTabGroup = null;
                    }
                }

                mobjOwner.Update();
            }
        }

        #endregion Methods

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualTabGroupCollection"/> class.
        /// </summary>
        /// <param name="objOwner">The owner list view.</param>
        internal ContextualTabGroupCollection(TabControl objOwner)
        {
            this.mobjOwner = objOwner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualTabGroupCollection"/> class.
        /// </summary>
        /// <param name="objOwner">The owner TabControl.</param>
        /// <param name="arrGroups">The arr groups.</param>
        internal ContextualTabGroupCollection(TabControl objOwner, object[] arrGroups)
        {
            this.mobjOwner = objOwner;
            this.mobjGroups = new ArrayList(arrGroups);
        }

        #endregion C'tors
    }

    #endregion ContextualTabGroupCollection Class

    #region TabControlRenderer Class

    /// <summary>
    /// Provides support for rendering a TabControl control  
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class TabControlRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabControlRenderer"/> class.
        /// </summary>
        /// <param name="objTabControl">The TabControl control.</param>
        public TabControlRenderer(TabControl objTabControl)
            : base(objTabControl)
        {
        }

        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
        {

        }

        /// <summary>
        /// Renders the background.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderBackground(ControlRenderingContext objContext, Graphics objGraphics)
        {

        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            TabControl objTabControl = this.Control as TabControl;
            if (objTabControl != null)
            {
                // Get the selected tab
                TabPage objSelectedTab = objTabControl.SelectedTab;
                if (objSelectedTab != null)
                {
                    // Get the control bitmap
                    Bitmap objControlBitmap = objSelectedTab.DrawControl(objContext, objSelectedTab.Width, objSelectedTab.Height);

                    // If there is a valid control bitmap
                    if (objControlBitmap != null)
                    {
                        // Draw the control at the specified location
                        objGraphics.DrawImage(objControlBitmap, new Point(0, 0));
                    }
                }
            }
        }


    }

    #endregion

    #region TabPageRenderer Class

    /// <summary>
    /// Provides support for rendering a TabPage control  
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class TabPageRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabPageRenderer"/> class.
        /// </summary>
        /// <param name="objTabPage">The TabPage control.</param>
        public TabPageRenderer(TabPage objTabPage)
            : base(objTabPage)
        {
        }

        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
        {

        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            RenderControls(objContext, objGraphics);
        }


    }

    #endregion

}
