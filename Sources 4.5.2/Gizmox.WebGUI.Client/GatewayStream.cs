#region Using

using System;
using System.IO;
using System.Web;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region GatewayStream Class
	
	/// <summary>
	/// Summary description for Capture.
	/// </summary>
	
	internal class GatewayStream : MemoryStream
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objMainStream"></param>
		public GatewayStream(Stream objMainStream)
		{
			mobjMainStream = objMainStream;
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Class Members
		
		private Stream mobjMainStream;
		
		
		#endregion Class Members
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}
		
		
		#endregion Properties
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="offset"></param>
		/// <param name="count"></param>
		public override void Write(byte[] buffer, int offset, int count)
		{
			base.Write(buffer,offset,count);
			mobjMainStream.Write(buffer,offset,count);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		public override void WriteByte(byte value)
		{
			base.WriteByte (value);
			mobjMainStream.WriteByte(value);
		}
		
		/// <summary>
		///
		/// </summary>
		public override void Flush()
		{
			base.Flush ();
			mobjMainStream.Flush();
		}
		
		/// <summary>
		///
		/// </summary>
		public override void Close()
		{
			base.Close ();
			mobjMainStream.Close();
		}
		
		
		#endregion Methods
		
	}
	
	#endregion GatewayStream Class
	
}
