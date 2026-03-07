#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Runtime.Serialization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
	#region ProgressBar Class
	
	/// <summary>
	/// Represents a WebGUI progress bar control.
	/// </summary>
	[System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ProgressBar), "ProgressBar_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ProgressBar), "ProgressBar.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Value")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Value")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Value")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Value")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Value")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DefaultBindingProperty("Value")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultBindingProperty("Value")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ProgressBarController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ProgressBarController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [SRDescription("DescriptionProgressBar"), DefaultProperty("Value")]
	[ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.ProgressBar)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.ProgressBarSkin)), Serializable()]
	public class ProgressBar : Control
	{


      /// <summary>
        /// Provides a property reference to Step property.
        /// </summary>
        private static SerializableProperty StepProperty = SerializableProperty.Register("Step", typeof(int), typeof(ProgressBar));



      /// <summary>
        /// Provides a property reference to Value property.
        /// </summary>
        private static SerializableProperty ValueProperty = SerializableProperty.Register("Value", typeof(int), typeof(ProgressBar));



      /// <summary>
        /// Provides a property reference to Minimum property.
        /// </summary>
        private static SerializableProperty MinimumProperty = SerializableProperty.Register("Minimum", typeof(int), typeof(ProgressBar));



      /// <summary>
        /// Provides a property reference to Maximum property.
        /// </summary>
        private static SerializableProperty MaximumProperty = SerializableProperty.Register("Maximum", typeof(int), typeof(ProgressBar));

		#region Class Members

		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see> class.
		/// </summary>
		public ProgressBar()
		{
            base.SetStyle(ControlStyles.UseTextForAccessibility | ControlStyles.Selectable | ControlStyles.UserPaint, false);
		}

		#endregion C'Tor/D'Tor
		
	
		#region Methods

        /// <summary>
        /// Renders the current control.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext,IResponseWriter objWriter,long lngRequestID)
		{
			int intTotal	= this.Maximum - this.Minimum;
			int intValue	= this.Value - this.Minimum;
			int intPrecent	= 0;
			if(intTotal!=0)
			{
				intPrecent = (int)((double)intValue/(double)intTotal * 100);
			}
			
			// add attributes to control element
			objWriter.WriteAttributeString("Precent",intPrecent.ToString());
		}
		
		/// <summary>
        /// Advances the current position of the progress bar by the amount of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Step"></see> property.
        /// </summary>
        ///	<exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Style"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.ProgressBarStyle.Marquee"></see>.</exception>
		public void PerformStep()
		{
			this.Increment(this.Step);
		}
		
		/// <summary>
        /// Advances the current position of the progress bar by the specified amount.
        /// </summary>
		///	<param name="value">The amount by which to increment the progress bar's current position. </param>
        ///	<exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Style"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ProgressBarStyle.Marquee"></see></exception>
		public void Increment(int value)
		{
            this.Value += value;
			if (this.Value < this.Minimum)
			{
                this.Value = this.Minimum;
			}
			if (this.Value > this.Maximum)
			{
                this.Value = this.Maximum;
			}
			this.Update();
		}
		
		
		#endregion Methods
		
		#region Properties

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
        /// Gets the default size.
        /// </summary>
        /// <value>
        /// The default size.
        /// </value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(100, 23);
            }
        }
		
		/// <summary>
        /// Gets or sets the maximum value of the range of the control.
        /// </summary>
		///	<returns>The maximum value of the range. The default is 100.</returns>
		///	<exception cref="T:System.ArgumentException">The value specified is less than 0. </exception>
        [DefaultValue(100), SRDescription("ProgressBarMaximumDescr"), SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint)]
        public int Maximum
		{
			get
			{
                return this.GetValue<int>(ProgressBar.MaximumProperty, 100);
			}
			set
			{
                if (this.Maximum != value)
				{
					if (this.Minimum > value)
					{
                        this.SetValue<int>(ProgressBar.MinimumProperty, value);
					}
                    
                    if (value != 100)
                    {
                        this.SetValue<int>(ProgressBar.MaximumProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<int>(ProgressBar.MaximumProperty);
                    }

					if (this.Value > Maximum)
					{
                        this.SetValue<int>(ProgressBar.ValueProperty, this.Maximum);
					}
					
					Update();
				}
			}
		}
		
		/// <summary>
        /// Gets or sets the minimum value of the range of the control.
        /// </summary>
		///	<returns>The minimum value of the range. The default is 0.</returns>
		///	<exception cref="T:System.ArgumentException">The value specified for the property is less than 0. </exception>
        [SRDescription("ProgressBarMinimumDescr"), DefaultValue(0), SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint)]
        public int Minimum
		{
			get
			{
                return this.GetValue<int>(ProgressBar.MinimumProperty, 0);
			}
			set
			{
				if (this.Minimum != value)
				{
					if (this.Maximum < value)
					{
                        this.SetValue<int>(ProgressBar.MaximumProperty, value);
					}

                    if (value != 0)
                    {
                        this.SetValue<int>(ProgressBar.MinimumProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<int>(ProgressBar.MinimumProperty);
                    }
					
                    if (this.Value < this.Minimum)
					{
                        this.SetValue<int>(ProgressBar.ValueProperty, this.Minimum);
					}
					Update();
				}
			}
		}
		
		/// <summary>
        /// Gets or sets the current position of the progress bar.
        /// </summary>
		///	<returns>The position within the range of the progress bar. The default is 0.</returns>
        ///	<exception cref="T:System.ArgumentException">The value specified is greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Maximum"></see> property.-or- The value specified is less than the value of the <see cref="P:Gizmox.WebGUI.Forms.ProgressBar.Minimum"></see> property. </exception>
        [SRDescription("ProgressBarValueDescr"), Bindable(true), SRCategory("CatBehavior"), DefaultValue(0)]
        public int Value
		{
			get
			{
                return this.GetValue<int>(ProgressBar.ValueProperty);
			}
			set
			{
				if (this.Value != value)
				{
					if ((value < this.Minimum) || (value > this.Maximum))
					{
						throw new ArgumentOutOfRangeException("Value");
					}
                    if (value != 0)
                    {
                        this.SetValue<int>(ProgressBar.ValueProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<int>(ProgressBar.ValueProperty);
                    }
					this.Update();
				}
			}
		}
		
		/// <summary>
        /// Gets or sets the amount by which a call to the <see cref="M:Gizmox.WebGUI.Forms.ProgressBar.PerformStep"></see> method increases the current position of the progress bar.
        /// </summary>
        ///	<returns>The amount by which to increment the progress bar with each call to the <see cref="M:Gizmox.WebGUI.Forms.ProgressBar.PerformStep"></see> method. The default is 10.</returns>
        [SRCategory("CatBehavior"), DefaultValue(10), SRDescription("ProgressBarStepDescr")]
        public int Step
		{
			get
			{
                return this.GetValue<int>(ProgressBar.StepProperty, 10);
			}
			set
			{
                if (value != 10)
                {
                    this.SetValue<int>(ProgressBar.StepProperty, value);
                }
                else
                {
                    this.RemoveValue<int>(ProgressBar.StepProperty);
                }
				Update();
			}
		}

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
        [Bindable(false), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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
		
		#endregion Properties
		
	}
	
	#endregion ProgressBar Class
	
}
