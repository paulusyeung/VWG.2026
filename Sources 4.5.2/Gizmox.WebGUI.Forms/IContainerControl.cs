using System;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>Provides the functionality for a control to act as a parent for other controls.</summary>
    /// <filterpriority>2</filterpriority>
    public interface IContainerControl
    {
        /// <summary>Activates a specified control.</summary>
        /// <returns>true if the control is successfully activated; otherwise, false.</returns>
        /// <param name="objActive">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> being activated. </param>
        bool ActivateControl(Control objActive);

        /// <summary>Gets or sets the control that is active on the container control.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that is currently active on the container control.</returns>
        Control ActiveControl { get; set; }
    }
 

}
