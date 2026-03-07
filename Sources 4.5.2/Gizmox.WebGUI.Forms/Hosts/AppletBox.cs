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
	#region AppletBox Class

    /// <summary>
    /// Applet box control can host java applets and embed the in a Visual WebGui
    /// application
    /// </summary>
    /// <example>
    /// 	<code lang="CS">
    /// 		<![CDATA[
    /// AppletBox objAppletBox = new AppletBox();
    ///  
    /// objAppletBox.CodeBase = [URL Relative location]
    /// objAppletBox.Code = [Class filename]
    ///  
    /// //If your class file is located in Resources folder inside project and it's a dedicated server:
    ///  
    /// objAppletBox.CodeBase = "/Resources/";
    /// objAppletBox.Code = "MyClass.class";
    ///  
    /// //If your class files located in virtual directory inside server:
    ///  
    /// objAppletBox.CodeBase = "Resources/";
    /// objAppletBox.Code = "MyClass.class";]]>
    /// 	</code>
    /// 	<code lang="VB">
    /// 		<![CDATA[
    /// Dim objAppletBox As New AppletBox()
    ///  
    /// objAppletBox.CodeBase = [URL Relative location]
    /// objAppletBox.Code = [Class filename]
    ///  
    /// //If your Class file Is located In Resources folder inside project And it's a dedicated server:
    ///  
    /// objAppletBox.CodeBase = "/Resources/"
    /// objAppletBox.Code = "MyClass.class"
    ///  
    /// //If your Class files located In virtual directory inside server:
    ///  
    /// objAppletBox.CodeBase = "Resources/"
    /// objAppletBox.Code = "MyClass.class"]]>
    /// 	</code>
    /// </example>
	
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(AppletBox), "AppletBox_45.png")]
#else
    [ToolboxBitmap(typeof(AppletBox), "AppletBox.bmp")]
#endif
    [Serializable]
    public class AppletBox : AppletBoxBase, IGatewayComponent
	{
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="AppletBox"/> instance.
		/// </summary>
		public AppletBox() : this(null, null)
		{            
		}
		
		/// <summary>
		/// Creates a new <see cref="AppletBox"/> instance.
		/// </summary>
		/// <param name="strCodeBase">Applet code base.</param>
		/// <param name="strArchive">Applet archive.</param>
		/// <param name="strCode">Applet code.</param>
		public AppletBox(string strArchive,string strCode) : base(strArchive,strCode)
		{
            this.ObjectType = "application/x-java-applet";
		}
		
		
		#endregion C'Tor\D'Tor
		
		#region Methods			
		
		#endregion Methods
		
		#region Properties
		
					
		
		/// <summary>
		/// Gets or sets the archive.
		/// </summary>
		/// <value></value>
        [DefaultValue("")]
        public string Archive
		{
			get
			{
				return InternalArchive;
			}
			set
			{
				InternalArchive = value;
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

        /// <summary>
        /// Gets or sets the code base.
        /// </summary>
        /// <value>The code base.</value>
        [DefaultValue("")]
        public string Code
        {
            get
            {
                return this.ObjectCode;
            }
            set
            {
                this.ObjectCode = value;
            }
        }
		#endregion Properties
		
		#region IGatewayControl Members
					
		
		#endregion IGatewayControl Members
		
	}
	
	#endregion AppletBox Class
	
}
