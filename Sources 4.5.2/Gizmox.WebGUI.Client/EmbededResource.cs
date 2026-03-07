#region Using

using System;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Text;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region EmbededResource Class
	
	/// <summary>
	/// Summary description for EmbededResource.
	/// </summary>
	
	internal class EmbededResource
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		/// Create a new embeded resource class
		/// </summary>
		/// <param name="objAssembly">The assembly.</param>
		/// <param name="strResource">The resource name.</param>
		internal EmbededResource(Assembly objAssembly, string strResource)
		{
			mobjAssembly = objAssembly;

            if (objAssembly != null)
            {
                mstrResource = objAssembly.FullName.Split(',')[0] + "." + strResource;
            }
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Class Members
		
		/// <summary>
		/// The resouce name
		/// </summary>
		private string mstrResource = string.Empty;
		
		/// <summary>
		/// The resource assembly
		/// </summary>
		private Assembly mobjAssembly = null;
		
		
		#endregion Class Members
		
		#region Properties
		
		/// <summary>
		/// Gets a is valid flag for the current resource path
		/// </summary>
		public bool IsValid
		{
			get
			{
				return ResourceInfo!=null;
			}
		}
		
		/// <summary>
		/// Get the resource information manifast
		/// </summary>
		public ManifestResourceInfo ResourceInfo
		{
			get
			{
                if (mobjAssembly != null)
                {
                    return mobjAssembly.GetManifestResourceInfo(mstrResource);
                }

				return null;
			}
		}
		
		
		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets the resource as a stream
		/// </summary>
		public Stream ToStream()
		{
			return mobjAssembly.GetManifestResourceStream(mstrResource);
		}
		
		/// <summary>
		/// Gets the resource as an xml document
		/// </summary>
		/// <returns></returns>
		public XmlDocument ToXml()
		{
			XmlDocument objDoc = new XmlDocument();
			Stream objStream = this.ToStream();
			try
			{
				objDoc.Load(objStream);
			}
			catch(Exception objException)
			{
				objStream.Close();
				throw new Exception(this.mstrResource + ": " + objException.Message,objException);
			}
			
			objStream.Close();
			
			return objDoc;
		}
		
		/// <summary>
		/// Gets the resource as a string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StreamReader objStreamReader = new StreamReader(ToStream());
			string strContent = objStreamReader.ReadToEnd();
			objStreamReader.Close();
			return strContent;
		}
		
		/// <summary>
		/// Writes the resource stream to an output stream
		/// </summary>
		/// <param name="objOutputStream"></param>
		public void WriteToStream(Stream objOutputStream)
		{
			Stream objStream = this.ToStream();
			if (objStream != null)
			{
				byte[] arrFile = new byte[objStream.Length];
				objStream.Read(arrFile, 0, (int)objStream.Length);
				objOutputStream.Write(arrFile, 0, arrFile.Length);
				objOutputStream.Flush();
				objStream.Close();
			}
		}
		
		
		#endregion Methods
		
	}
	
	#endregion EmbededResource Class
	
}
