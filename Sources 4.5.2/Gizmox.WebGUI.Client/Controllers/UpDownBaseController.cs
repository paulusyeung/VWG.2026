#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.IO;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
    public class UpDownBaseController : ControlController
    {
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
        /// <param name="objWebUpDown"></param>
		public UpDownBaseController(IContext objContext,object objWebUpDown) :base(objContext, objWebUpDown)
		{
		}
		
		/// <summary>
		///
		/// </summary>
        /// <param name="objWebUpDown"></param>
        /// <param name="objWinUpDown"></param>
        public UpDownBaseController(IContext objContext, object objWebUpDown, object objWinUpDown)
            : base(objContext, objWebUpDown, objWinUpDown)
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

            SetWinControlReadOnly();
            SetWinControlTextAlign();
            SetWinControlUpDownAlign();
  
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "ReadOnly":
                    SetWinControlReadOnly();
                    break;
                case "TextAlign":
                    SetWinControlTextAlign();
                    break;
                case "UpDownAlign":
                    SetWinControlUpDownAlign();
                    break;
            }
        }

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return base.CreateTargetObject(objWebObject);
        }

        /// <summary>
        /// Sets the win updown read only value.
        /// </summary>
        protected virtual void SetWinControlReadOnly()
        {
            this.WinUpDownBase.ReadOnly = this.WebUpDownBase.ReadOnly;
        }

        /// <summary>
        /// Sets the win updown text alignment value.
        /// </summary>
        protected virtual void SetWinControlTextAlign()
        {
            this.WinUpDownBase.TextAlign = (System.Windows.Forms.HorizontalAlignment)GetConvertedEnum(typeof(System.Windows.Forms.HorizontalAlignment), this.WebUpDownBase.TextAlign);
        }

        /// <summary>
        /// </summary>
        protected virtual void SetWinControlUpDownAlign()
        {
            WinUpDownBase.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)GetConvertedEnum(typeof(System.Windows.Forms.LeftRightAlignment), this.WebUpDownBase.UpDownAlign);
        }


        #endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.UpDownBase WebUpDownBase
        {
            get
            {
                return base.SourceObject as WebForms.UpDownBase;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.UpDownBase WinUpDownBase
        {
            get
            {
                return base.TargetObject as WinForms.UpDownBase;
            }
        }

        #endregion Properties
    }
}
