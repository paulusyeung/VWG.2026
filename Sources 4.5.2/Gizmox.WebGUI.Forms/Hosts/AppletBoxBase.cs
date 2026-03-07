#region Using

using System;
using System.Xml;
using System.Web;
using System.Collections;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;

#endregion Using

namespace Gizmox.WebGUI.Forms.Hosts
{
	#region AppletBoxBase Class
	
	/// <summary>
	/// Summary description for AppletBoxBase.
	/// </summary>
	[System.ComponentModel.ToolboxItem(false)]
    [Serializable]
        public class AppletBoxBase : ObjectBox
	{
      
		#region Class Members								
		
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="AppletBoxBase"/> instance.
		/// </summary>
		public AppletBoxBase()
		{						     			
		}
		
		/// <summary>
		/// Creates a new <see cref="AppletBoxBase"/> instance.
		/// </summary>
		/// <param name="strCodeBase">Applet code base.</param>
		/// <param name="strArchive">Applet archive.</param>
		/// <param name="strCode">Applet code.</param>
        public AppletBoxBase(string strArchive, string strCode)
        {                                 
            InternalArchive = strArchive;
        }            
		
		
		#endregion C'Tor\D'Tor		
		
		#region Properties
				
		
		/// <summary>
		/// Gets or sets the archive.
		/// </summary>
		/// <value></value>
		protected string InternalArchive
		{
			get
            {
                return base.Parameters["archive"] != null ? base.Parameters["archive"].ToString() : string.Empty;
            }
            set
            {
                base.Parameters["archive"] = value;
            }
		}

        /// <summary>
        /// Gets or sets the archive.
        /// </summary>
        /// <value></value>
        protected string ObjectCode
        {
            get
            {
                return base.Parameters["code"] != null ?  base.Parameters["code"].ToString() : string.Empty;
            }
            set
            {
                base.Parameters["code"] = value;
            }
        }

		#endregion Properties
				
	}
	
	#endregion AppletBoxBase Class
	
}
