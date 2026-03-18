using System;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.HelpLibrary;

internal class CHMResource : IStaticGateway
{
	private CHMExplorerController mobjCHMExplorerController = null;

	private CHMExplorerController CHMController
	{
		get
		{
			if (mobjCHMExplorerController == null)
			{
				mobjCHMExplorerController = CHMExplorerController.Get(CHMCReference);
			}
			return mobjCHMExplorerController;
		}
	}

	private string CHMCReference => HostContext.Current.Request.QueryString["chm"];

	private string Local => HostContext.Current.Request.QueryString["src"];

	static CHMResource()
	{
	}

	public IStaticGatewayHandler GetGatewayHandler(IContext objContext)
	{
		if (CHMController != null)
		{
			try
			{
				CHMController.WriteResource(objContext.HostContext.Response, Local);
			}
			catch (Exception ex)
			{
				objContext.HostContext.Response.StatusDescription = ex.Message;
				objContext.HostContext.Response.StatusCode = 404;
			}
		}
		else
		{
			objContext.HostContext.Response.StatusCode = 404;
		}
		return null;
	}
}
