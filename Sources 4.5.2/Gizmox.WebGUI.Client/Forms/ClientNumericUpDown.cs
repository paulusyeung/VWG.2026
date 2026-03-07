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
    public partial class ClientNumericUpDown : NumericUpDown, IContextContainer
    {
        public ClientNumericUpDown()
        {
        }

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
    }
}
