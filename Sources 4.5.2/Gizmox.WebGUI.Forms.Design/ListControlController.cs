using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class ListControlController : Gizmox.WebGUI.Client.Controllers.ListControlController
    {
		#region Constructors

        public ListControlController(IContext objContext, object objWebObject, object objWinObject) : base(objContext, objWebObject, objWinObject)
        {
        }

        public ListControlController(IContext objContext, object objWebObject) : base(objContext, objWebObject)
        {
        }

		#endregion Constructors 
    }
}
