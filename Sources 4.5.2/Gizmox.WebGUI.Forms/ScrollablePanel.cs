#region Using

using System;
using System.Xml;
using System.Drawing;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
	#region Enums
	
	/// <summary>
	/// Scrollable panel type
	/// </summary>
	
	public enum ScrolledPanelType
	{
		Horizontal=1,
		Vertical=2
	}
	
	
	#endregion Enums
	
	#region ScrollablePanel Class
	
	/// <summary>
	///
	/// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	[ToolboxBitmapAttribute(typeof(Panel), "Panel.bmp")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ScrollablePanelController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ScrollablePanelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ScrollablePanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ScrollablePanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ScrollablePanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ScrollablePanelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ScrollablePanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ScrollablePanelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ScrollablePanelController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ScrollablePanelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ScrollablePanelController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ScrollablePanelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ScrollablePanelController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ScrollablePanelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ScrollablePanelController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ScrollablePanelController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
	
    [MetadataTag(WGTags.ScrollablePanel)]
    [Serializable()]
	public class ScrollablePanel : Panel
	{
		#region Class Members
		
		private ScrolledPanelType menmScrolledPanelType = ScrolledPanelType.Horizontal;
		
		
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="ScrollablePanel"/> instance.
		/// </summary>
		public ScrollablePanel() : base()
		{

		}
		
		
		#endregion C'Tor\D'Tor
		
		#region Methods
		
		#region Render
		
		/// <summary>
		/// Renders the attributes.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("Dir",ScrolledPanelType.ToString());
			base.RenderAttributes (objContext, objWriter);
		}
		
		
		#endregion Render
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the scroll panel type.
		/// </summary>
		/// <value></value>
		public ScrolledPanelType ScrolledPanelType
		{
			get
			{
				return menmScrolledPanelType;
			}
			set
			{
				if(menmScrolledPanelType!=value)
				{
					Update();
				}
				menmScrolledPanelType = value;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ScrollablePanel Class
	
}
