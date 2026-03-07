#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Runtime.Serialization;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel;

#endregion

namespace Gizmox.WebGUI.Forms
{
	#region ContextMenu Class

    /// <summary>
    /// ContextMenu Class
    /// </summary>
	[System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ContextMenu), "ContextMenu_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ContextMenu), "ContextMenu.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ContextMenuController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ContextMenuController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.DesignTimeVisible(true)]    
    [ToolboxItemCategory("Menus & Toolbars")]
    [Serializable()]
	public class ContextMenu : Menu, IContextMenu
	{		
		#region Class Members
				
        public event EventHandler Collapse;

		#endregion
		
		#region C'Tor/D'Tor
		
		/// <summary>
		/// Creates a new <see cref="ContextMenu"/> instance.
		/// </summary>
		public ContextMenu()
		{

		}
		
		#endregion
		
		#region Methods

        /// <summary>
        /// Raises the <see cref="E:Collapse"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected internal virtual void OnCollapse(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.Collapse;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collapse event is registered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the collapse event is registered; otherwise, <c>false</c>.
        /// </value>
        internal bool RegisteredCollapseEvent
        {
            get 
            {
                return this.Collapse != null;
            }
        }

        /// <summary>
        /// Gets the source control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ContextMenuSourceControlDescr"), Browsable(false)]
        public Control SourceControl
        {
            get
            {
                Control objControl = null;

                // Get source component
                Component objSourceComponent = this.Owner;

                // Climb up till finding a control parent
                while (objSourceComponent != null)
                {
                    // Check if source component is control
                    objControl = objSourceComponent as Control;
                    if (objControl != null)
                    {
                        break;
                    }
                    else
                    {
                        // Climb to parent
                        objSourceComponent = objSourceComponent.InternalParent;
                    }
                }

                return objControl;
            }
        }

		#endregion

		#region Properties



		#endregion 


	}

	#endregion
}
