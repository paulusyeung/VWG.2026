#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region DateTimePickerController Class

    /// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class DateTimePickerController : ControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public DateTimePickerController(IContext objContext,object objWebLabel,object objWinLabel) :base(objContext,objWebLabel,objWinLabel)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
        public DateTimePickerController(IContext objContext, object objWebLabel) : base(objContext, objWebLabel)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
            SetWinDateTimePickerCustomFormat();
            SetWinDateTimePickerFormat();
            SetWinDateTimePickerShowCheckBox();
            SetWinDateTimePickerShowUpDown();
            SetWinDateTimePickerChecked();
		}

        /// <summary>
        /// </summary>
        protected override void SetWebControlText()
        {
        }

        /// <summary>
        /// </summary>
        protected override void SetWinControlText()
        {
        }

		/// <summary>
		///
		/// </summary>
        protected virtual void SetWinDateTimePickerShowCheckBox()
		{
            if (this.WinDateTimePicker.ShowCheckBox != this.WebDateTimePicker.ShowCheckBox)
            {
                this.WinDateTimePicker.ShowCheckBox = this.WebDateTimePicker.ShowCheckBox;
            }
		}

        /// <summary>
        /// Sets the win date time picker show up down.
        /// </summary>
        protected virtual void SetWinDateTimePickerShowUpDown()
        {
            if (this.WinDateTimePicker.ShowUpDown != this.WebDateTimePicker.ShowUpDown)
            {
                this.WinDateTimePicker.ShowUpDown = this.WebDateTimePicker.ShowUpDown;
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinDateTimePickerChecked()
        {
            if (this.WinDateTimePicker.Checked != this.WebDateTimePicker.Checked)
            {
                this.WinDateTimePicker.Checked = this.WebDateTimePicker.Checked;
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinDateTimePickerCustomFormat()
        {
            if (this.WebDateTimePicker.Format == Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom)
            {
                this.WinDateTimePicker.CustomFormat = this.WebDateTimePicker.CustomFormat;
            }
        }
		
		/// <summary>
		///
		/// </summary>
        protected virtual void SetWinDateTimePickerFormat()
		{
            this.WinDateTimePicker.Format = (WinForms.DateTimePickerFormat)GetConvertedEnum(typeof(WinForms.DateTimePickerFormat), this.WebDateTimePicker.Format);
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinDateTimePickerValue()
        {
            this.WinDateTimePicker.Value = this.WebDateTimePicker.Value;
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
            return new WinForms.DateTimePicker();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			
			switch (objPropertyChangeArgs.Property)
			{
                case "ShowUpDown":
                    SetWinDateTimePickerShowUpDown();
                    break;
                case "Checked":
                    SetWinDateTimePickerChecked();
                    break;
                case "ShowCheckBox":
                    SetWinDateTimePickerShowCheckBox();
                    break;
                case "CustomFormat":
                    SetWinDateTimePickerCustomFormat();
				    break;
                case "Format":
                    SetWinDateTimePickerFormat();
				    break;
                case "Value":
                    SetWinDateTimePickerValue();
                    break;
			}
		}
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
        public WebForms.DateTimePicker WebDateTimePicker
		{
			get
			{
                return base.SourceObject as WebForms.DateTimePicker;
			}
		}
		
		/// <summary>
		///
		/// </summary>
        public WinForms.DateTimePicker WinDateTimePicker
		{
			get
			{
                return base.TargetObject as WinForms.DateTimePicker;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion LabelController Class
	
}
