#region Using

using System;
using System.Drawing;
using System.Xml;
using System.Web;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using System.ComponentModel;

#endregion Using

namespace Gizmox.WebGUI.Forms.Hosts
{
	#region FlashBox Class

    /// <summary>
    /// Flash box control can host Flash movies and embed them in a Visual WebGui
    /// application.
    /// </summary>
    /// <example>
    /// 	<code lang="CS">
    /// 		<![CDATA[
    /// FlashBox objFlashBox = new FlashBox();
    /// objFlashBox.Movie = "../../../../../Resources/Flash/FC_2_3_Column3D.swf";
    /// objFlashBox.AddParameter("FlashVars","&dataURL=../../../../../Resources/Flash/FC_2_3_Column3D.xml");
    /// objFlashBox.AddParameter("quality", "high");
    /// objFlashBox.Dock = DockStyle.Fill;
    /// this.Controls.Add(objFlashBox);]]>
    /// 	</code>
    /// 	<code lang="VB">
    /// 		<![CDATA[
    /// Dim objFlashBox As New FlashBox()
    /// objFlashBox.Movie = "../../../../../Resources/Flash/FC_2_3_Column3D.swf"
    /// objFlashBox.AddParameter("FlashVars", "&dataURL=../../../../../Resources/Flash/FC_2_3_Column3D.xml")
    /// objFlashBox.AddParameter("quality", "high")
    /// objFlashBox.Dock = DockStyle.Fill
    /// Me.Controls.Add(objFlashBox)]]>
    /// 	</code>
    /// </example>
    [System.ComponentModel.ToolboxItem(true), Serializable()]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(FlashBox), "FlashBox_45.png")]
#else
    [ToolboxBitmap(typeof(FlashBox), "FlashBox.bmp")]
#endif
    public class FlashBox : FlashBoxBase
	{
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="FlashBox"/> instance.
		/// </summary>
		public FlashBox()
		{
			
		}
		
		#endregion C'Tor\D'Tor
		
		#region Methods
		
		#region Parameters
		
		/// <summary>
		/// Adds the parameter.
		/// </summary>
		public void AddParameter(string strName,string strValue)
		{
			Parameters[strName] = strValue;
			
		}
		
		/// <summary>
		/// Adds the parameter.
		/// </summary>
		public void AddParameter(string strName,GatewayHandler objHandler)
		{
			Parameters[strName] = objHandler;
		}
		
		/// <summary>
		/// Gets the parameter.
		/// </summary>
		public string GetParameter(string strName)
		{
			return Parameters[strName] as string;
		}
		
		/// <summary>
		/// Removes the parameter.
		/// </summary>
		public void RemoveParameter(string strName)
		{
			if(Parameters.Contains(strName))
			{
				Parameters.Remove(strName);
			}
		
		}
		
		/// <summary>
		/// Clears the parameters.
		/// </summary>
		public void ClearParameters()
		{
			Parameters.Clear();
		}
		
		
		#endregion Parameters
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue("")]
		public string Movie
		{
			get
			{
				return InternalMovie;
			}
			set
			{
				InternalMovie = value;
			}
		}

        /// <summary>
        /// Gets or sets the code base.
        /// </summary>
        /// <value>The code base.</value>
        [DefaultValue("")]
        public string CodeBase
        {
            get
            {
                return this.ObjectCodeBase;
            }
            set
            {
                this.ObjectCodeBase = value;
            }
        } 

		#endregion Properties
		

		
	}
	
	#endregion FlashBox Class
	
}
