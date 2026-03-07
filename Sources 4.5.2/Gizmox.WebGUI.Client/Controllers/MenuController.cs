#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region ContextMenuController Class
    /// <summary>
    /// Controls the relations between a webgui menu and a winforms menu
    /// </summary>
    
	public class MenuController : ComponentController
    {
        #region C'Tor/D'Tor
		
		
		public MenuController(IContext objContext,object objWebComponent,object objWinComponent) : base(objContext,objWebComponent,objWinComponent)
		{
			
		}
		
        public MenuController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
        public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.FireWinPropertyChanged(objPropertyChangeArgs);
        }
        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
        }
    }
    #endregion
}
