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
	#region FlashBase Class
	
	/// <summary>
	/// Summary description for FlashBoxBase.
	/// </summary>
    [System.ComponentModel.ToolboxItem(false), Serializable()]   
    public class FlashBoxBase : ObjectBox
	{       
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="FlashBoxBase"/> instance.
		/// </summary>
		public FlashBoxBase() : base()
		{
            // Set the flash object attributes.
            this.ObjectClassId = "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000";
            this.ObjectCodeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0";
            this.ObjectPluginsPageType = "http://www.macromedia.com/go/getflashplayer";
            this.ObjectType = "application/x-shockwave-flash";
		}				
		#endregion C'Tor\D'Tor
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the movie.
		/// </summary>
		/// <value></value>
		protected string InternalMovie
		{
			get
			{
                if (this.Parameters.Contains("src"))
                {
                    return this.Parameters["src"].ToString();
                }
                else
                {
                    return string.Empty;
                }
			}
			set
			{
				this.Parameters["src"] = this.ObjectData = value;
			}
		}



		#endregion Properties                 
	}
	
	#endregion FlashBoxBase Class
	
}
