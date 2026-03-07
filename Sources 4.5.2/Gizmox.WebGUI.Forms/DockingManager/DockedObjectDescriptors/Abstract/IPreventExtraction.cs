using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreventExtraction
    {
		#region Operations (1) 

        /// <summary>
        /// Disables the extraction.
        /// </summary>
        /// <param name="blnDisable">if set to <c>true</c> [BLN disable].</param>
        void DisableExtraction(bool blnDisable);

		#endregion Operations 
    }
}
