using System;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web;
using Gizmox.WebGUI.Hosting;


namespace Gizmox.WebGUI.Forms.HelpLibrary
{
    
	internal class CHMResource : IStaticGateway
    {
        

        static CHMResource()
        {
            
        }

		#region CHMController Property

		private CHMExplorerController mobjCHMExplorerController = null;

		private CHMExplorerController CHMController
		{
			get
			{
				if(mobjCHMExplorerController==null)
				{
                    mobjCHMExplorerController = CHMExplorerController.Get(this.CHMCReference);
				}
				return mobjCHMExplorerController;
			}
		}

        private string CHMCReference
        {
            get
            {
                return HostContext.Current.Request.QueryString["chm"];
            }
        }

		private string Local
		{
			get
			{
                return HostContext.Current.Request.QueryString["src"];
			}
		}




		#endregion

        #region IStaticGateway Members

        public IStaticGatewayHandler GetGatewayHandler(IContext objContext)
        {
            if (this.CHMController != null)
            {
                try
                {
                    this.CHMController.WriteResource(objContext.HostContext.Response, this.Local);
                }
                catch (Exception objException)
                {
                    objContext.HostContext.Response.StatusDescription = objException.Message;
                    objContext.HostContext.Response.StatusCode = 404;
                }
            }
            else
            {
                objContext.HostContext.Response.StatusCode = 404;
            }
            return null;
        }

        #endregion


    }
}
