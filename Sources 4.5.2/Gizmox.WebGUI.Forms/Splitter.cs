#region Using

using System;
using System.Xml;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Splitter Class

    /// <summary>
    /// Represents a splitter control that enables the user to resize docked controls. <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> has been replaced by <see cref="T:System.Windows.Forms.SplitContainer"></see> and is provided only for compatibility with previous versions.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(Splitter), "Splitter_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(Splitter), "Splitter.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.Splitter)]
    [Skin(typeof(SplitterSkin))]
    [Serializable()]
    public class Splitter : Control
    {
        #region Class Members

        /// <summary>
        /// Gets the hanlder for the SplitterMoved event.
        /// </summary>
        private SplitterEventHandler SplitterMovedHandler
        {
            get
            {
                return (SplitterEventHandler)this.GetHandler(Splitter.SplitterMovedEvent);
            }
        }

        /// <summary>
        /// The SplitterMoved event registration.
        /// </summary>
        private static readonly SerializableEvent SplitterMovedEvent = SerializableEvent.Register("SplitterMoved", typeof(SplitterEventHandler), typeof(Splitter));
        private static readonly SerializableProperty SplitterFixedProperty = SerializableProperty.Register("SplitterFixed", typeof(bool), typeof(Splitter), new SerializablePropertyMetadata(false));



        /// <summary>
        /// Occurs when the Splitter is Moved.
        /// </summary>
        [SRDescription("SplitterSplitterMovedDescr"), SRCategory("CatBehavior")]
        public event SplitterEventHandler SplitterMoved
        {
            add
            {
                this.AddCriticalHandler(Splitter.SplitterMovedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Splitter.SplitterMovedEvent, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether in this instance the splitter is fixed or movable.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is splitter fixed. otherwise, <c>false</c>.
        /// </value>
        [SRCategory("CatLayout"), DefaultValue(false)]
        public bool IsSplitterFixed
        {
            get
            {
                // Get the value From Serializable Property
                return this.GetValue<bool>(Splitter.SplitterFixedProperty);
            }
            set
            {
                // If value different from current value 
                if (this.SetValue<bool>(Splitter.SplitterFixedProperty, value))
                {
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        #endregion Class Members

        #region render related

        /// <summary>
        /// An abstract control method rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // render child controls
            RenderControls(objContext, objWriter, 0);
        }


        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderIsSplitterFixedAttribute(objWriter, false);
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

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                RenderIsSplitterFixedAttribute(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the is splitter fixed attribute.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderIsSplitterFixedAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnIsSplitterFixed = this.IsSplitterFixed;

            if (blnForceRender || blnIsSplitterFixed)
            {
                objWriter.WriteAttributeString(WGAttributes.IsSplitterFixed, blnIsSplitterFixed ? "1" : "0");
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            int intX = 0;
            int intY = 0;
            Double dblResult = 0;
            int intSize = 0;

            if (objEvent.Type == "SplitterMoved")
            {
                //Gets the size of the control which the splitter rests on. 
                if (CommonUtils.TryParse(objEvent["Size"], out  dblResult))
                {
                    intSize = Convert.ToInt32(dblResult);
                }

                //Gets the x-coordinate of the mouse pointer 
                if (CommonUtils.TryParse(objEvent["X"], out  dblResult))
                {
                    intX = Convert.ToInt32(dblResult);
                }

                //Gets the y-coordinate of the mouse pointer 
                if (CommonUtils.TryParse(objEvent["Y"], out  dblResult))
                {
                    intY = Convert.ToInt32(dblResult);
                }

                if (this.Context != null && this.Context.Session != null)
                {
                    Control objTargetControl = ((ISessionRegistry)this.Context).GetRegisteredComponent(objEvent.Target) as Control;
                    if (objTargetControl != null)
                    {
                        switch (this.Dock)
                        {
                            case DockStyle.Left:
                            case DockStyle.Right:
                                // Set the control new bound
                                if (objTargetControl.SetBounds(0, 0, intSize, 0, BoundsSpecified.Width))
                                {
                                    // Raise the resize event
                                    objTargetControl.OnResizeInternal(new LayoutEventArgs(true, true, true));
                                }
                                break;
                            case DockStyle.Top:
                            case DockStyle.Bottom:
                                // Set the control new bound
                                if (objTargetControl.SetBounds(0, 0, 0, intSize, BoundsSpecified.Height, true))
                                {
                                    // Raise the resize event
                                    objTargetControl.OnResizeInternal(new LayoutEventArgs(true, true, true));
                                }
                                break;
                        }
                    }
                }
                this.OnSplitterMoved(new SplitterEventArgs(intX, intY, intX, intY));
            }
            base.FireEvent(objEvent);
        }

        /// <summary>
        /// Occurs when [client splitter moved].
        /// </summary>
        [SRDescription("Occurs when splitter moved in client mode."), Category("Client")]
        public event ClientEventHandler ClientSplitterMoved
        {
            add
            {
                this.AddClientHandler("SplitterMoved", value);
            }
            remove
            {
                this.RemoveClientHandler("SplitterMoved", value);
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if ((SplitterMovedHandler) != null)
            {
                objEvents.Set(WGEvents.PositionChanged);
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
            if (this.HasClientHandler("SplitterMoved"))
            {
                objEvents.Set(WGEvents.PositionChanged);
            }
            return objEvents;
        }

        #endregion render related

        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> class. <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> has been replaced by <see cref="T:Gizmox.WebGUI.Forms.SplitContainer"></see>, and is provided only for compatibility with previous versions.
        /// </summary>
        public Splitter()
        {
            base.SetStyle(ControlStyles.Selectable, false);

            Dock = DockStyle.Left;

            Width = 3;
            Height = 3;

            this.TabStop = false;
        }

        #endregion C'Tor / D'Tor

        #region Events

        /// <summary>
        /// Raises the SplitterMoved event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.SplitterEventArgs"/> instance containing the event data.</param>
        protected virtual void OnSplitterMoved(SplitterEventArgs e)
        {
            // Raise event if needed
            SplitterEventHandler objEventHandler = this.SplitterMovedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Gets/Sets the controls docking style
        /// </summary>
        [System.ComponentModel.DefaultValue(DockStyle.Left)]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                if (((value != DockStyle.Top) && (value != DockStyle.Bottom)) && ((value != DockStyle.Left) && (value != DockStyle.Right)))
                {
                    throw new ArgumentException(SR.GetString("SplitterInvalidDockEnum"));
                }

                // Get splitter size values
                int intWidth = this.Width;
                int intHeight = this.Height;

                // Get current dock value
                DockStyle enmOldValue = base.Dock;

                // Check if dock value changed
                if (enmOldValue != value)
                {
                    // Update dock value
                    base.Dock = value;

                    switch (this.Dock)
                    {
                        case DockStyle.Top:
                        case DockStyle.Bottom:
                            if (enmOldValue == DockStyle.Left || enmOldValue == DockStyle.Right)
                            {
                                // Update spliter height
                                this.Height = intWidth;
                            }
                            break;
                        case DockStyle.Left:
                        case DockStyle.Right:
                            if (enmOldValue == DockStyle.Top || enmOldValue == DockStyle.Bottom)
                            {
                                // Update spliter width
                                base.Width = intHeight;
                            }
                            break;
                    }
                }
            }
        }

        #endregion
    }

    #endregion Splitter Class

}
