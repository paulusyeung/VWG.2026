using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public class EditValueEditingEventArgs : CancelEventArgs
    {
        private bool mblnExitEditMode;
        private IEvent mobjParameters;
        private object mobjFormattedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditValueEditingEventArgs"/> class.
        /// </summary>
        /// <param name="objParameters">The object parameters.</param>
        internal EditValueEditingEventArgs(IEvent objParameters)
        {
            this.mobjParameters = objParameters;
            this.mblnExitEditMode = true;
            this.mobjFormattedValue = objParameters["value"];
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public IEvent Parameters
        {
            get { return mobjParameters; }
            set { mobjParameters = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [exit edit mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [exit edit mode]; otherwise, <c>false</c>.
        /// </value>
        public bool ExitEditMode
        {
            get { return mblnExitEditMode; }
            set { mblnExitEditMode = value; }
        }

        /// <summary>
        /// Gets or sets the formatted value.
        /// </summary>
        /// <value>
        /// The formatted value.
        /// </value>
        public object FormattedValue
        {
            get { return mobjFormattedValue; }
            set { mobjFormattedValue = value; }
        }
    }
}
