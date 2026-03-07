using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.Design
{
    public class NoneExcludedImageIndexConverter : ImageIndexConverter
    {        
		#region Properties 

        /// <summary>
        /// Gets a value indicating whether [include none as standard value].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [include none as standard value]; otherwise, <c>false</c>.
        /// </value>
		protected override bool IncludeNoneAsStandardValue
        {
            get
            {
                return false;
            }
        }
		
		#endregion 
    }
}
