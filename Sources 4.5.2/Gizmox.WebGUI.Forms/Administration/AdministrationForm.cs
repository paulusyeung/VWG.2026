using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    internal partial class AdministrationForm : AdministrationFormBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationForm"/> class.
        /// </summary>
        public AdministrationForm()
        {
            
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns></returns>
        public override ContentChangeNotifierUserControl GetContent()
        {
            return new MainContent();
        }
    }
}
