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
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A Panel control
    /// </summary>
    [Skin(typeof(MasterPageContentSkin))]
    [MetadataTag(WGTags.MasterPageContent)]
    [Serializable()]
    internal class MasterPageContent : ContainerControl, INavigationControl
    {
        public MasterPageContent()
        {
            this.CustomStyle = "MasterPageContentSkin";

            Name = "FormsContainer";

            // Set the ClientId of the control, for accessing it in the client.
            ClientId = "MasterPageContent";
        }

        /// <summary>
        /// Gets the current navigation control.
        /// </summary>
        /// <returns></returns>
        private INavigationControl GetCurrentNavigationControl()
        {
            INavigationControl objNavigationControl = null;
            Form objFrom = Context.ActiveForm as Form;
            if (objFrom != null)
            {
                ProxyForm objProxyForm = objFrom.ProxyComponent as ProxyForm;
                if (objProxyForm != null)
                {
                    ProxyComponent objProxyNavigationControl = objProxyForm.NavigationControl;
                    if (objProxyNavigationControl != null)
                    {
                        objNavigationControl = objProxyNavigationControl.SourceComponent as INavigationControl;
                    }
                }
            }

            return objNavigationControl;
        }

        /// <summary>
        /// Gets the number of views.
        /// </summary>
        int INavigationControl.Count
        {
            get
            {
                INavigationControl objNavigationControl = GetCurrentNavigationControl();
                if (objNavigationControl != null)
                {
                    return objNavigationControl.Count;
                }

                return -1;
            }
        }

        /// <summary>
        /// Move to view index.
        /// </summary>
        /// <returns></returns>
        void INavigationControl.MoveTo(int intIndex)
        {
            INavigationControl objNavigationControl = GetCurrentNavigationControl();
            if (objNavigationControl != null)
            {
                objNavigationControl.MoveTo(intIndex);
            }
        }

        /// <summary>
        /// Gets the selected view index.
        /// </summary>
        int INavigationControl.SelectedIndex
        {
            get 
            {
                INavigationControl objNavigationControl = GetCurrentNavigationControl();
                if (objNavigationControl != null)
                {
                    return objNavigationControl.SelectedIndex;
                }

                return -1;
            }
        }

        /// <summary>
        /// Navigate to first view.
        /// </summary>
        bool INavigationControl.MoveFirst()
        {
            INavigationControl objNavigationControl = GetCurrentNavigationControl();
            if (objNavigationControl != null)
            {
                return objNavigationControl.MoveFirst();
            }
            return false;
        }

        /// <summary>
        /// Navigate to last view.
        /// </summary>
        bool INavigationControl.MoveLast()
        {
            INavigationControl objNavigationControl = GetCurrentNavigationControl();
            if (objNavigationControl != null)
            {
                return objNavigationControl.MoveLast();
            }
            return false;
        }

        /// <summary>
        /// Navigate to next view.
        /// </summary>
        bool INavigationControl.MoveNext()
        {
            INavigationControl objNavigationControl = GetCurrentNavigationControl();
            if (objNavigationControl != null)
            {
                return objNavigationControl.MoveNext();
            }
            return false;
        }

        /// <summary>
        /// Navigate to previous view.
        /// </summary>
        bool INavigationControl.MovePrevious()
        {
            INavigationControl objNavigationControl = GetCurrentNavigationControl();
            if (objNavigationControl != null)
            {
                return objNavigationControl.MovePrevious();
            }
            return false;
        }
    }

}
