/*
' Visual WebGui - http://www.visualwebgui.com
' Copyright (c) 2005
' by Gizmox Inc. ( http://www.gizmox.com )
'
' This program is free software; you can redistribute it and/or modify it 
' under the terms of the GNU General Public License as published by the Free 
' Software Foundation; either version 2 of the License, or (at your option) 
' any later version.
'
' THIS PROGRAM IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, 
' BUT WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY 
' OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU GENERAL PUBLIC LICENSE FOR MORE DETAILS.
' YOU SHOULD HAVE RECEIVED A COPY OF THE GNU GENERAL PUBLIC LICENSE ALONG WITH THIS PROGRAM; if not, 
' write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
'
' contact: opensource@visualwebgui.com
*/

#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A button control
    /// </summary>
    [Skin(typeof(ZoneCloseButtonSkin))]
    [Serializable()]
    [System.ComponentModel.ToolboxItem(false)]
    public class ZoneCloseButton : Button
    {
        public ZoneCloseButton()
        {
            this.CustomStyle = "ZoneCloseButtonSkin";
        }

        /// <summary>
        /// Gets a value indicating whether [supports key navigation].
        /// </summary>
        /// <value>
        /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
        /// </value>
        protected override bool SupportsKeyNavigation
        {
            get
            {
                return true;
            }
        }
    }

}
