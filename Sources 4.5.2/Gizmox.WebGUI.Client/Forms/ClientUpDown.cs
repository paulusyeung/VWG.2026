#region Using

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Client.Design;

#endregion Using

namespace Gizmox.WebGUI.Client.Forms
{
    #region ClientUpDown Class

    /// <summary>
    /// Summary description for ClientUpDown.
    /// </summary>
    
    public partial class ClientUpDown : UpDownBase, IContextContainer
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        public ClientUpDown()
        {

        }


        #endregion C'Tor / D'Tor

        #region Class Members

        #endregion Class Members

        #region IContextContainer Members

        private Gizmox.WebGUI.Common.Interfaces.IContext mobjContext = null;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        /// <summary>
        ///
        /// </summary>
        Gizmox.WebGUI.Common.Interfaces.IContext IContextContainer.Context
        {
            get
            {
                return mobjContext;
            }
            set
            {
                mobjContext = value;
            }
        }


        #endregion IContextContainer Members

        #region Methods

        #endregion Methods

        #region Properties

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

        #endregion Properties


        public override void DownButton()
        {
        }

        public override void UpButton()
        {
        }

        protected override void UpdateEditText()
        {
        }
    }

    #endregion ClientUpDown Class

}
