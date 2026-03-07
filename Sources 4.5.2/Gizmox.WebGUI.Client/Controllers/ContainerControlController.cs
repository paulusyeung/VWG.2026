#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ContainerControlController Class
	
	/// <summary>
	/// Controls the relations between a webgui container control and a winforms container control
	/// </summary>
	
	public class ContainerControlController : ScrollableControlController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ContainerControlController(IContext objContext,object objWebContainerControl,object objWinContainerControl) :base(objContext,objWebContainerControl,objWinContainerControl)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ContainerControlController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		new public WebForms.ScrollableControl WebScrollableControl
		{
			get
			{
				return base.SourceObject as WebForms.ScrollableControl;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		new public WinForms.ScrollableControl WinScrollableControl
		{
			get
			{
				return base.TargetObject as WinForms.ScrollableControl;
			}
		}
		
		
		#endregion Properties
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			base.InitializedContained();
		}
		
		
		#endregion Methods
		
	}
	
	#endregion ContainerControlController Class
	
}
