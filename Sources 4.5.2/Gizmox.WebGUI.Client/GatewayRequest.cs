#region Using

using System;
using System.Web;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region GatewayRequest Class
	
	/// <summary>
	/// Summary description for GatewayRequest.
	/// </summary>
	
	internal class GatewayRequest : HttpWorkerRequest
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public GatewayRequest()
		{
			
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		public override string GetUriPath()
		{
			return null;
		}
		
		/// <summary>
		///
		/// </summary>
		public override string GetQueryString()
		{
			return "";
		}
		
		/// <summary>
		///
		/// </summary>
		public override string GetRawUrl()
		{
			return "http://clientgateway.com/gateway.aspx";
		}
		
		/// <summary>
		///
		/// </summary>
		public override string GetHttpVerbName()
		{
			return "GET";
		}
		
		/// <summary>
		///
		/// </summary>
		public override string GetHttpVersion()
		{
			return "1.1";
		}
		
		/// <summary>
		///
		/// </summary>
		public override string GetRemoteAddress()
		{
			return "";
		}
		
		/// <summary>
		///
		/// </summary>
		public override int GetRemotePort()
		{
			return 80;
		}
		
		/// <summary>
		///
		/// </summary>
		public override string GetLocalAddress()
		{
			return "";
		}
		
		/// <summary>
		///
		/// </summary>
		public override int GetLocalPort()
		{
			return 0;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="statusCode"></param>
		/// <param name="statusDescription"></param>
		public override void SendStatus(int statusCode, string statusDescription)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public override void SendKnownResponseHeader(int index, string value)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public override void SendUnknownResponseHeader(string name, string value)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="data"></param>
		/// <param name="length"></param>
		public override void SendResponseFromMemory(byte[] data, int length)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="offset"></param>
		/// <param name="length"></param>
		public override void SendResponseFromFile(System.IntPtr handle, long offset, long length)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="offset"></param>
		/// <param name="length"></param>
		public override void SendResponseFromFile(string filename, long offset, long length)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="finalFlush"></param>
		public override void FlushResponse(bool finalFlush)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		public override void EndOfRequest()
		{
			
		}
		
		
		#endregion Methods
		
	}
	
	#endregion GatewayRequest Class
	
}
