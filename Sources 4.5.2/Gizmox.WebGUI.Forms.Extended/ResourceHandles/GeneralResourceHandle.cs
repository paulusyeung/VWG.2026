using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web;

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Hosting;
using System.Collections.Specialized;

namespace Gizmox.WebGUI.Common.Resources
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class GeneralResourceHandleDefaultGranter : IGeneralResourceHandleAccessGranter
    {
        /// <summary>
        /// Determines whether the specified string path is granted.
        /// </summary>
        /// <param name="strPath">The string path.</param>
        /// <param name="blnIsLocalFile">if set to <c>true</c> [BLN is local file].</param>
        /// <returns></returns>
        public bool IsGranted(string strPath, bool blnIsLocalFile)
        {
            // All non-local resources are granted by default
            bool blnIsGranted = !blnIsLocalFile;

            if (blnIsLocalFile)
            {
                // Get the resources folder
                string strResourcesPath = Path.Combine(Application.StartupPath, "Resources");

                // Normalize path to resource
                string strNormalizedPath = Path.GetFullPath(strPath);

                // Check that the given file path is within the resources folder
                if (Directory.Exists(strResourcesPath) && strNormalizedPath.StartsWith(strResourcesPath))
                {
                    blnIsGranted = true;
                }
            }

            return blnIsGranted;
        }
    }
    /// <summary>
    /// Static gateway that will serve any file or resource accessible by the server, provided the
    /// IGeneralResourceHandleAccessGranter provider grants access to the resource. By default, access
    /// is granted to non-local resources (Urls) and all files under the virtual folder's Resources folder.
    /// 
    /// Custom access granter can be set through Provider in web.config, default being equal to:
    /// 
    ///  <WebGUI>
    ///    <Providers>
    ///      <Provider key="IGeneralResourceHandleAccessGranter" value="Gizmox.WebGUI.Common.Resources.GeneralResourceHandleDefaultGranter, Gizmox.WebGUI.Forms.Extended" />
    ///    </Providers>
    ///  </WebGUI>
    /// 
    /// Names of file resources are always interpreted relative to application's virtual folder,
    /// which means a resource named 'test.jpg' will mean a test.jpg file directly on the application's
    /// virtual folder.
    /// 
    /// Default caching is set at application startup according to the VWG_DisableCachingSwitch of web.config, 
    /// and if enabled, resources are by default cached for 1 year. 
    /// </summary>
    [Serializable()]
    public class GeneralResourceHandle : StaticGatewayResourceHandle, IStaticGateway
    {
        internal const string FULL_NAME = "FN";
        internal const string CONTENT_TYPE = "CT";

        #region Private Class Members for internal use

        /// <summary>
        /// Full name of file/resource - used for internal processing
        /// </summary>
        protected string mstrFileName = string.Empty;

        /// <summary>
        /// ContentType of file/resource - used for internal processing
        /// </summary>
        protected string mstrContentType = string.Empty;
        
        #endregion

        #region C'Tors

        #region Internal C'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralResourceHandle"/> class.
        /// 
        /// Required by StaticGatewayResourceHandle derived classes - Best practice: No code should be in here.
        /// 
        /// This constructor is required by the router when serving requests for resources served by this static
        /// gateway and should not contain any code.
        /// </summary>
        public GeneralResourceHandle()
        {
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralResourceHandle"/> class.
        /// </summary>
        /// <param name="strFullName">Full name of the string.</param>
        public GeneralResourceHandle(string strFullName)
            : this(strFullName, CommonUtils.GetMimeType(strFullName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralResourceHandle"/> class.
        /// </summary>
        /// <param name="strFullName">Full name of the string.</param>
        /// <param name="strContentType">Type of the string content.</param>
        public GeneralResourceHandle(string strFullName, string strContentType) 
            : this(strFullName, strContentType, typeof(GeneralResourceHandle).FullName , typeof(GeneralResourceHandle))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralResourceHandle"/> class.
        /// </summary>
        /// <param name="strFullName">The filename to reference</param>
        /// <param name="strContentType">The content type to use when serving the gateway request.</param>
        /// <param name="strTypeName">The full name of the static gateway class type</param>
        /// <param name="objType">The static gateway class type</param>
        internal protected GeneralResourceHandle(string strFullName, string strContentType, string strTypeName, Type objType)
            : base(strTypeName, objType)
        {
            mstrFileName = strFullName;
            mstrContentType = strContentType;
        }


        #endregion

        #region IStaticGateway Members

        /// <summary>
        /// Gets the gateway handler.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <returns></returns>
        IStaticGatewayHandler IStaticGateway.GetGatewayHandler(IContext objContext)
        {
            // Get request and response
            NameValueCollection objQueryCollection = objContext.HostContext.Request.QueryString;
            
            // Get filename and content type from decoded query parameters
            this.mstrFileName = HttpUtility.UrlDecode(objQueryCollection[FULL_NAME]);
            this.mstrContentType = HttpUtility.UrlDecode(objQueryCollection[CONTENT_TYPE]);
            
            // Write it
            this.Write(objContext, mstrContentType);

            // Return null = handled
            return null;
        }

        #endregion

        #region Repsponse writing virtuals

        /// <summary>
        /// Writes the resource and it's headers to the response stream.
        /// Calls WriteCacheHeaders, WriteContentType, WriteContent in this order
        /// </summary>
        /// <param name="objContext">The response.</param>
        /// <param name="strContentType">Type of the string content.</param>
        protected virtual void Write(IContext objContext, string strContentType)
        {
            WriteCacheHeaders(objContext);
            WriteContentType(objContext, strContentType);
            WriteContent(objContext);
        }

        /// <summary>
        /// Writes the caching headers.
        /// </summary>
        /// <param name="objContext">The response.</param>
        protected virtual void WriteCacheHeaders(IContext objContext)
        {
            if (ConfigHelper.IsCacheEnabled)
            {
                objContext.HostContext.Response.Cache.SetExpires(DateTime.Now.AddYears(1));
                objContext.HostContext.Response.Cache.SetCacheability(HttpCacheability.Public);
                objContext.HostContext.Response.Cache.SetValidUntilExpires(true);
            }
            else
            {
                objContext.HostContext.Response.Cache.SetExpires(DateTime.Now);
                objContext.HostContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                objContext.HostContext.Response.Cache.SetValidUntilExpires(false);
            }
        }

        /// <summary>
        /// Writes the content type header.
        /// </summary>
        /// <param name="objContext">The response.</param>
        /// <param name="strContentType">The data reader.</param>
        protected virtual void WriteContentType(IContext objContext, string strContentType)
        {
            objContext.HostContext.Response.ContentType = strContentType;
        }

        /// <summary>
        /// Writes the binary content of the file/resource.
        /// </summary>
        /// <param name="objContext">The response.</param>
        /// <param name="strFullName">The data reader.</param>
        protected virtual void WriteContent(IContext objContext)
        {
            GeneralResourceHandle.CopyStream(this.ToStream(), objContext.HostContext.Response.OutputStream);
        }

        #endregion

        #region StaticGatewayResourceHandle Members

        /// <summary>
        /// Gets a value indicating whether this resource is a local server resource.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is a local server resource; otherwise, <c>false</c>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsServerResource
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// Gets the resource stream
        /// </summary>
        /// <returns></returns>
        public override Stream ToStream()
        {
            string strResourceLocation = mstrFileName;
            bool? blnIsFile = null;
            Stream objStream = null;

            // if mstrFileName is full file path
            if (System.IO.File.Exists(mstrFileName))
            {
                blnIsFile = true;
            }
            
            // Check if relative file path
            strResourceLocation = Path.Combine(Application.StartupPath, strResourceLocation.Replace("/", @"\"));
            if (!blnIsFile.HasValue && System.IO.File.Exists(strResourceLocation))
            {
                blnIsFile = true;
            }

            // Check absolute URL
            if (!blnIsFile.HasValue && mstrFileName.StartsWith(Uri.UriSchemeHttp) || mstrFileName.StartsWith(Uri.UriSchemeHttps))
            {
                strResourceLocation = mstrFileName;
                blnIsFile = false;
            }

            IGeneralResourceHandleAccessGranter objAccessGranter = CommonUtils.GetProvider<IGeneralResourceHandleAccessGranter>("Gizmox.WebGUI.Common.Resources.GeneralResourceHandleDefaultGranter, Gizmox.WebGUI.Forms.Extended", true, false);
            
            if (blnIsFile.HasValue && objAccessGranter.IsGranted(strResourceLocation, blnIsFile.Value))
            {
                if (blnIsFile.Value) // File system
                {
                    using (Stream objTempStream = new FileStream(strResourceLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                    {
                        if (objTempStream == null)
                            objStream = null;
                        else
                        {
                            objStream = new MemoryStream();
                            CopyStream(objTempStream, objStream);
                            objStream.Seek(0, SeekOrigin.Begin);
                        }
                    }
                }
                else // Http URL
                {
                    System.Net.HttpWebRequest objRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(strResourceLocation);
                    objRequest.Method = "GET";
                    
                    System.Net.WebResponse objWebResponse = objRequest.GetResponse();
                    if (objWebResponse != null)
                    {
                        objStream = objWebResponse.GetResponseStream();
                    }
                }
            }

            return objStream;
        }

        /// <summary>
        /// Gets the specific resource handle  - used for ToString().
        /// 
        /// The returned value will be the Url used for this particular resource/file.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string GetSpecificResourceHandle()
        {
            return string.Format("{0}?{1}={2}&{3}={4}", 
                base.GetSpecificResourceHandle(), 
                FULL_NAME,
                HttpUtility.UrlEncode(this.mstrFileName),
                CONTENT_TYPE,
                HttpUtility.UrlEncode(this.mstrContentType));
        }

        #endregion
        
        #region Private helpers
        
        /// <summary>
        /// Copy one stream to another. 
        /// </summary>
        /// <param name="objFromStream"></param>
        /// <param name="objToStream"></param>
        private static void CopyStream(Stream objFromStream, Stream objToStream)
        {
            if (objFromStream != null && objToStream != null)
            {
                byte[] buffer = new byte[32768];
                int read;
                while ((read = objFromStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    objToStream.Write(buffer, 0, read);
                }
            }
        }

        #endregion 
    
    }
}
