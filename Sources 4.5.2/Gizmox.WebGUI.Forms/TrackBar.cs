#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Globalization;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Specifies the location of tick marks in a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> control.
    /// </summary>	
    public enum TickStyle
    {
        /// <summary>
        /// No tick marks appear in the control.
        /// </summary>
        None,
        /// <summary>
        /// Tick marks are located on the top of a horizontal control or on the left of a vertical control.
        /// </summary>
        TopLeft,
        /// <summary>
        /// Tick marks are located on the bottom of a horizontal control or on the right side of a vertical control.
        /// </summary>
        BottomRight,
        /// <summary>
        /// Tick marks are located on both sides of the control.
        /// </summary>
        Both
    }



    /// <summary>
    /// Represents a standard Visual WebGui track bar.
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(TrackBar), "TrackBar_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(TrackBar), "TrackBar.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TrackBarController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TrackBarController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem(true)]
    [DefaultProperty("Value"), DefaultEvent("ValueChanged"), SRDescription("DescriptionTrackBar")]
    [ToolboxItemCategory("Common Controls")]
    [Serializable()]
    [MetadataTag(WGTags.TrackBar)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.TrackBarSkin))]
    public class TrackBar : Control, ISupportInitialize
    {


        /// <summary>
        /// Provides a property reference to TickStyle property.
        /// </summary>
        private static SerializableProperty TickStyleProperty = SerializableProperty.Register("TickStyle", typeof(TickStyle), typeof(TrackBar));



        /// <summary>
        /// Provides a property reference to TickFrequency property.
        /// </summary>
        private static SerializableProperty TickFrequencyProperty = SerializableProperty.Register("TickFrequency", typeof(int), typeof(TrackBar));



        /// <summary>
        /// Provides a property reference to SmallChange property.
        /// </summary>
        private static SerializableProperty SmallChangeProperty = SerializableProperty.Register("SmallChange", typeof(int), typeof(TrackBar));



        /// <summary>
        /// Provides a property reference to Orientation property.
        /// </summary>
        private static SerializableProperty OrientationProperty = SerializableProperty.Register("Orientation", typeof(Orientation), typeof(TrackBar));



        /// <summary>
        /// Provides a property reference to Minimum property.
        /// </summary>
        private static SerializableProperty MinimumProperty = SerializableProperty.Register("Minimum", typeof(int), typeof(TrackBar));



        /// <summary>
        /// Provides a property reference to Maximum property.
        /// </summary>
        private static SerializableProperty MaximumProperty = SerializableProperty.Register("Maximum", typeof(int), typeof(TrackBar));



        /// <summary>
        /// Provides a property reference to LargeChange property.
        /// </summary>
        private static SerializableProperty LargeChangeProperty = SerializableProperty.Register("LargeChange", typeof(int), typeof(TrackBar));



        /// <summary>
        /// Provides a property reference to Value property.
        /// </summary>
        private static SerializableProperty ValueProperty = SerializableProperty.Register("Value", typeof(float), typeof(TrackBar), new SerializablePropertyMetadata(0));


        /// <summary>
        /// Provides a RequestedDim property.
        /// </summary>
        private int mintRequestedDim = 0;


        /// <summary>
        /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property of a track bar changes, either by movement of the scroll box or by manipulation in code.
        /// </summary>
        [SRCategory("CatAction"), SRDescription("valueChangedEventDescr")]
        public event EventHandler ValueChanged
        {
            add
            {
                this.AddCriticalHandler(TrackBar.ValueChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TrackBar.ValueChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("Occurs when control's value changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientValueChanged
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
        /// Gets the value changed handler.
        /// </summary>
        /// <value>The value changed handler.</value>
        private EventHandler ValueChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(TrackBar.ValueChangedEvent);
            }
        }

        /// <summary>
        /// The value change event reference
        /// </summary>
        private static readonly SerializableEvent ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(TrackBar));




        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> class.
        /// </summary>
        public TrackBar()
        {

        }



        /// <summary>
        /// Begins the initialization of a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> that is used on a form or used by another component. The initialization occurs at run time.
        /// </summary>
        public void BeginInit()
        {
        }

        /// <summary>
        /// Ends the initialization of a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> that is used on a form or used by another component. The initialization occurs at run time.
        /// </summary>
        public void EndInit()
        {
        }


        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.TrackBar.ValueChanged"></see> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ValueChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Sets the minimum and maximum values for a <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>.
        /// </summary>
        /// <param name="intMinValue">The lower limit of the range of the track bar. </param>
        /// <param name="intMaxValue">The upper limit of the range of the track bar. </param>
        public void SetRange(int intMinValue, int intMaxValue)
        {
            int intMaximum = this.MaximumInternal;

            bool blnMinMinimumChanged = (this.MinimumInternal != intMinValue);
            bool blnMaximumChanged = (intMaximum != intMaxValue);

            //check if the values changed
            if (blnMinMinimumChanged || blnMaximumChanged)
            {
                float fltValue = this.ValueInternal;

                //insure that the minimum is not greater then maximum
                if (intMinValue > intMaxValue)
                {
                    intMaxValue = intMinValue;
                    blnMaximumChanged = (intMaximum != intMaxValue);
                }

                //update Minimum and Maximum values if needed
                if (blnMinMinimumChanged)
                {
                    this.MinimumInternal = intMinValue;
                }
                if (blnMaximumChanged)
                {
                    this.MaximumInternal = intMaxValue;
                }

                //check that the trackbar value is in between Minimum and Maximum range
                if (fltValue < intMinValue)
                {
                    this.SetValue<float>(TrackBar.ValueProperty, intMinValue);
                }
                if (fltValue > intMaxValue)
                {
                    this.SetValue<float>(TrackBar.ValueProperty, intMaxValue);
                }
            }
        }

        /// <summary>
        /// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> control.
        /// </summary>
        /// <returns>A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. </returns>
        public override string ToString()
        {
            return (base.ToString() + ", Minimum: " + this.Minimum.ToString() + ", Maximum: " + this.Maximum.ToString() + ", Value: " + this.Value.ToString());
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.ValueChangedHandler != null)
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
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "ValueChange":
                    // Parse recieved value from client.
					float fltPrecentage = float.Parse(objEvent[WGAttributes.Value], NumberStyles.Any, CultureInfo.InvariantCulture);

                    // Check if precentage is out of borders.
                    if (fltPrecentage < 0)
                    {
                        fltPrecentage = 0;
                    }
                    else if (fltPrecentage > 100)
                    {
                        fltPrecentage = 100;
                    }

                    // Get the minimum value.
                    int intMinimum = this.Minimum;

                    // Calculate and set percise value.
                    this.ValueInternal = intMinimum + ((this.Maximum - intMinimum) * (fltPrecentage / 100));
                    break;
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

            int intTickFrequency = this.TickFrequency;
            float fltLength = (this.Maximum - this.Minimum) + 1;

            // Calculate tick size (precentage)
            decimal decTickSize = Math.Round((decimal)((intTickFrequency / fltLength) * 100), 2);

            decimal decValue = 0;
            if (fltLength > 1)
            {
                // Calculate a precentage position of the knob.
                decValue = Math.Round((decimal)(((this.ValueInternal - this.Minimum) / (fltLength - 1)) * 100), 2);
            }
            else
            {
                // When Minimum=Maximum dont let the user move the knob
                objWriter.WriteAttributeString(WGAttributes.Frozen, "1");
            }

            // Calculate number of ticks
            decimal decTickCount = 1;
            if (intTickFrequency > 0)
            {
                decTickCount = Convert.ToDecimal(Math.Floor((double)(fltLength - 1) / (double)intTickFrequency));
            }

            objWriter.WriteAttributeString(WGAttributes.Style, ((int)this.TickStyle).ToString());
            objWriter.WriteAttributeString(WGAttributes.Orientation, ((int)this.Orientation).ToString());
            objWriter.WriteAttributeString(WGAttributes.Length, decTickCount.ToString(CultureInfo.InvariantCulture));
            objWriter.WriteAttributeString(WGAttributes.TickSize, decTickSize.ToString(CultureInfo.InvariantCulture));
            objWriter.WriteAttributeString(WGAttributes.Value, decValue.ToString(CultureInfo.InvariantCulture));

            if (this.VisualTemplate != null)
            {
                // Render maximum attribute if it is different from default value.
                objWriter.WriteAttributeString(WGAttributes.Minimum, this.Minimum.ToString(CultureInfo.InvariantCulture));
                objWriter.WriteAttributeString(WGAttributes.Maximum, this.Maximum.ToString(CultureInfo.InvariantCulture));
                
            }
        }

        /// <summary>
        /// Gets or sets a value to be added to or subtracted from the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property when the scroll box is moved a large distance.
        /// </summary>
        /// <returns>A numeric value. The default is 5.</returns>
        /// <exception cref="T:System.ArgumentException">The assigned value is less than 0. </exception>
        [SRCategory("CatBehavior"), SRDescription("TrackBarLargeChangeDescr"), DefaultValue(5)]
        public int LargeChange
        {
            get
            {
                return this.GetValue<int>(TrackBar.LargeChangeProperty, 5);
            }
            set
            {
                if (this.LargeChange != value)
                {
                    this.SetValue<int>(TrackBar.LargeChangeProperty, value);
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum internal.
        /// </summary>
        /// <value>The maximum internal.</value>
        private int MaximumInternal
        {
            get
            {
                return this.GetValue<int>(TrackBar.MaximumProperty, 10);
            }
            set
            {
                this.SetValue<int>(TrackBar.MaximumProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the upper limit of the range this <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> is working with.
        /// </summary>
        /// <returns>The maximum value for the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. The default is 10.</returns>
        [DefaultValue(10), RefreshProperties(RefreshProperties.All), SRDescription("TrackBarMaximumDescr"), SRCategory("CatBehavior")]
        public int Maximum
        {
            get
            {
                return this.MaximumInternal;
            }
            set
            {
                if (this.MaximumInternal != value)
                {
                    int intMinimum = this.MinimumInternal;

                    if (value < intMinimum)
                    {
                        this.MinimumInternal = intMinimum = value;
                    }

                    this.SetRange(intMinimum, value);

                    this.Update();
                }
            }
        }


        /// <summary>
        /// Gets or sets the minimum internal.
        /// </summary>
        /// <value>The minimum internal.</value>
        private int MinimumInternal
        {
            get
            {
                return this.GetValue<int>(TrackBar.MinimumProperty, 0);
            }
            set
            {
                this.SetValue<int>(TrackBar.MinimumProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the lower limit of the range this <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see> is working with.
        /// </summary>
        /// <returns>The minimum value for the <see cref="T:Gizmox.WebGUI.Forms.TrackBar"></see>. The default is 0.</returns>
        [DefaultValue(0), SRCategory("CatBehavior"), SRDescription("TrackBarMinimumDescr"), RefreshProperties(RefreshProperties.All)]
        public int Minimum
        {
            get
            {
                return this.MinimumInternal;
            }
            set
            {
                if (this.MinimumInternal != value)
                {
                    int intMaximum = this.MaximumInternal;

                    if (value > intMaximum)
                    {
                        this.MaximumInternal = intMaximum = value;
                    }

                    this.SetRange(value, intMaximum);

                    this.Update();
                }
            }
        }


        /// <summary>
        /// Gets or sets the requested dim.
        /// </summary>
        /// <value>The requested dim.</value>
        [SRCategory("CatBehavior"), SRDescription("TrackBarLargeChangeDescr"), DefaultValue(5)]
        private int RequestedDim
        {
            get
            {
                return mintRequestedDim;
            }
            set
            {
                mintRequestedDim = value;
            }
        }


        /// <summary>
        /// Gets or sets a value indicating the horizontal or vertical orientation of the track bar.
        /// </summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values. </exception>
        [DefaultValue(Orientation.Horizontal), Localizable(true), SRDescription("TrackBarOrientationDescr"), SRCategory("CatAppearance")]
        public Orientation Orientation
        {
            get
            {
                return this.GetValue<Orientation>(TrackBar.OrientationProperty, Orientation.Horizontal);
            }
            set
            {
                if (this.Orientation != value)
                {
                    this.SetValue<Orientation>(TrackBar.OrientationProperty, value);

                    //Set the FixedHeight and FixedWidth according to the Orientation
                    if (this.Orientation == Orientation.Horizontal)
                    {
                        base.SetStyle(ControlStyles.FixedHeight, this.AutoSize);
                        base.SetStyle(ControlStyles.FixedWidth, false);
                        base.Width = this.RequestedDim;
                    }
                    else
                    {
                        base.SetStyle(ControlStyles.FixedHeight, false);
                        base.SetStyle(ControlStyles.FixedWidth, this.AutoSize);
                        base.Height = this.RequestedDim;
                    }


                    //Get the bounds of the trackbar
                    Rectangle objBounds = base.Bounds;

                    //When the Orientation changes, this replace the height and width with one another
                    base.SetBoundsCore(objBounds.X, objBounds.Y, objBounds.Height, objBounds.Width, BoundsSpecified.All);
                    this.AdjustSize();

                    this.Update();
                }

            }
        }


        /// <summary>
        /// Performs the work of setting the specified bounds of this control.
        /// </summary>
        /// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control.</param>
        /// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control.</param>
        /// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control.</param>
        /// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control.</param>
        /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values.</param>
        /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
        /// <returns></returns>
        protected override bool SetBoundsCore(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified, bool blnIsClientSource)
        {
            this.RequestedDim = (this.Orientation == Orientation.Horizontal) ? intHeight : intWidth;

            return base.SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
        }


        /// <summary>
        /// Adjusts the size.
        /// </summary>
        private void AdjustSize()
        {
            int intRequestedDim = this.RequestedDim;
            try
            {
                if (this.Orientation == Orientation.Horizontal)
                {
                    base.Height = intRequestedDim;
                }
                else
                {
                    base.Width = intRequestedDim;
                }
            }
            finally
            {
                this.RequestedDim = intRequestedDim;
            }
        }



        /// <summary>
        /// Gets or sets the value added to or subtracted from the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Value"></see> property when the scroll box is moved a small distance.
        /// </summary>
        /// <returns>A numeric value. The default value is 1.</returns>
        /// <exception cref="T:System.ArgumentException">The assigned value is less than 0. </exception>
        [SRCategory("CatAppearance"), DefaultValue(1), SRDescription("TrackBarSmallChangeDescr")]
        public int SmallChange
        {
            get
            {
                return this.GetValue<int>(TrackBar.SmallChangeProperty, 1);
            }
            set
            {
                if (this.SmallChange != value)
                {
                    this.SetValue<int>(TrackBar.SmallChangeProperty, value);
                    this.Update();
                }
            }
        }


        /// <summary>
        /// Gets or sets a value that specifies the delta between ticks drawn on the control.
        /// </summary>
        /// <returns>The numeric value representing the delta between ticks. The default is 1.</returns>
        [DefaultValue(1), SRDescription("TrackBarTickFrequencyDescr"), SRCategory("CatAppearance")]
        public int TickFrequency
        {
            get
            {
                return this.GetValue<int>(TrackBar.TickFrequencyProperty, 1);
            }
            set
            {
                if (this.TickFrequency != value)
                {
                    this.SetValue<int>(TrackBar.TickFrequencyProperty, value);
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating how to display the tick marks on the track bar.
        /// </summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.TickStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.TickStyle.BottomRight"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TickStyle"></see>. </exception>
        [DefaultValue(TickStyle.BottomRight), SRCategory("CatAppearance"), SRDescription("TrackBarTickStyleDescr")]
        public TickStyle TickStyle
        {
            get
            {
                return this.GetValue<TickStyle>(TrackBar.TickStyleProperty, TickStyle.BottomRight);
            }
            set
            {
                if (this.TickStyle != value)
                {
                    this.SetValue<TickStyle>(TrackBar.TickStyleProperty, value, TickStyle.BottomRight);
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a numeric value that represents the current position of the scroll box on the track bar.
        /// </summary>
        /// <returns>A numeric value that is within the <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Minimum"></see> and <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Maximum"></see> range. The default value is 0.</returns>
        /// <exception cref="T:System.ArgumentException">The assigned value is less than the value of <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Minimum"></see>.-or- The assigned value is greater than the value of <see cref="P:Gizmox.WebGUI.Forms.TrackBar.Maximum"></see>. </exception>
        [DefaultValue(0), SRCategory("CatBehavior"), SRDescription("TrackBarValueDescr"), Bindable(true)]
        public int Value
        {
            get
            {
                return Convert.ToInt32(this.ValueInternal);
            }
            set
            {
                if (((value < this.Minimum) || (value > this.Maximum)))
                {
                    throw new ArgumentOutOfRangeException("Value", SR.GetString("InvalidBoundArgument", new object[] { "Value", value.ToString(CultureInfo.CurrentCulture), "'Minimum'", "'Maximum'" }));
                }

                if (this.Value != value)
                {
                    this.ValueInternal = value;

                    this.Update();

                    FireObservableItemPropertyChanged("Value");
                }
            }
        }

        /// <summary>
        /// Gets or sets the internal value.
        /// </summary>
        /// <value>The internal value.</value>
        private float ValueInternal
        {
            get
            {
                return this.GetValue<float>(TrackBar.ValueProperty, 0);
            }
            set
            {
                if (this.SetValue<float>(TrackBar.ValueProperty, value))
                {
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), Bindable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
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
    }
}
