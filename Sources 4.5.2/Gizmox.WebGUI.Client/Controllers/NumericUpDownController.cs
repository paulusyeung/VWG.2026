using System;
using System.Collections.Generic;
using System.Text;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Client.Controllers
{
    public class NumericUpDownController : UpDownBaseController
    {
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public NumericUpDownController(IContext objContext,object objWebUpDown) :base(objContext, objWebUpDown)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
        public NumericUpDownController(IContext objContext, object objWebUpDown, object objWinUpDown)
            : base(objContext, objWebUpDown, objWinUpDown)
		{
		}

        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinNumericUpDownMinimum();
            SetWinNumericUpDownMaximum();
            SetWinNumericUpDownThousandsSeparator();
            SetWinNumericUpDownIncrement();
            SetWinNumericUpDownValue();

        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Minimum":
                    SetWinNumericUpDownMinimum();
                    break;
                case "Maximum":
                    SetWinNumericUpDownMaximum();
                    break;
                case "ThousandsSeparator":
                    SetWinNumericUpDownThousandsSeparator();
                    break;
                case "Increment":
                    SetWinNumericUpDownIncrement();
                    break;
                case "Value":
                    SetWinNumericUpDownValue();
                    break;
            }
        }

        protected override object CreateTargetObject(object objWebObject)
        {
            return new Forms.ClientNumericUpDown();
        }

        /// <summary>
        /// </summary>
        protected virtual void SetWinNumericUpDownMinimum()
        {
            WinNumericUpDown.Minimum = WebNumericUpDown.Minimum;
        }

        /// <summary>
        /// </summary>
        protected virtual void SetWinNumericUpDownMaximum()
        {
            WinNumericUpDown.Maximum = WebNumericUpDown.Maximum;
        }

        /// <summary>
        /// </summary>
        protected virtual void SetWinNumericUpDownIncrement()
        {
            WinNumericUpDown.Increment = WebNumericUpDown.Increment;
        }

        /// <summary>
        /// </summary>
        protected virtual void SetWinNumericUpDownThousandsSeparator()
        {
            WinNumericUpDown.ThousandsSeparator = WebNumericUpDown.ThousandsSeparator;
        }

        /// <summary>
        /// </summary>
        protected virtual void SetWinNumericUpDownValue()
        {
            WinNumericUpDown.Value = WebNumericUpDown.Value;
        }

		#endregion C'Tor/D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.NumericUpDown WebNumericUpDown
        {
            get
            {
                return base.SourceObject as WebForms.NumericUpDown;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.NumericUpDown WinNumericUpDown
        {
            get
            {
                return base.TargetObject as WinForms.NumericUpDown;
            }
        }


        #endregion Properties
    }
}
