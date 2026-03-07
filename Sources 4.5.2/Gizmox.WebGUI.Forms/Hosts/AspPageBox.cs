#region Using

using System;
using System.IO;
using System.Web;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Specialized;


#endregion

namespace Gizmox.WebGUI.Forms.Hosts
{
    /// <summary>
    /// Summary description for AspPageBox
    /// </summary>
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(AspPageBox), "AspPageBox_45.png")]
#else
    [ToolboxBitmapAttribute(typeof(AspPageBox), "AspPageBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolboxItemCategory("Host Controls")]
    [Skin(typeof(Skins.AspPageBoxSkin)), Serializable()]
    public class AspPageBox : FrameControl 
    {

        /// <summary>
        /// 
        /// </summary>
         private static SerializableProperty PathProperty = SerializableProperty.Register("Path", typeof(string), typeof(AspPageBox));

        /// <summary>
        /// Initializes a new instance of the <see cref="AspPageBox"/> class.
        /// </summary>
        public AspPageBox()
        {

        }


        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        protected override string Source
        {
            get
            {
                if (this.IsValidPath(this.Path))
                {
                    // NOTE: For the wrap controls, the source should be absolute. (start with http://) because otherwise the source url will be the vwg base href url,
                    // that contains lots of virtual segments. Example: http://localhost/Route/2.800017.1.1/ie/en-US/Default/983038.49150.918/0/
                    // If we will not put the source with "http://" and let the source be the vwg base href, if the asp control do ResolveClientPath, the resolve will 
                    // go up in the directories according to the pathes in the vwg base href, and will throw "top directory" exception.

                    string strSource = CommonUtils.GetBaseUrl(VWGContext.Current.HostContext.Request);

                    string strGatewayReference = (new GatewayReference(this, "ASPXhost", this.SourceArguments)).ToString();

                    // Add cookie to Url on cookieless sessionstates
                    if (VWGContext.Current.HostContext.HttpContext.Session.IsCookieless)
                        strGatewayReference = VWGContext.Current.HostContext.HttpContext.Response.ApplyAppPathModifier(strGatewayReference);

                    strSource += strGatewayReference;
                    return strSource;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the source arguments.
        /// </summary>
        /// <value>The source arguments.</value>
        private NameValueCollection SourceArguments
        {
            get
            {
                // Get query string
                string strQueryString = this.PathQueryString;

                // If there is a valid query string
                if (!string.IsNullOrEmpty(strQueryString))
                {
                    // Create a new arguments collection
                    NameValueCollection objArguments = new NameValueCollection();

                    // Get the parameters
                    string[] arrParameters = strQueryString.Split('&');

                    // Loop all parameters
                    foreach (string strParameter in arrParameters)
                    {
                        // Get the parameter parts
                        string[] arrParameter = strParameter.Split('=');

                        // If is a valid parameter
                        if (arrParameter.Length == 2)
                        {
                            objArguments[HttpUtility.UrlDecode(arrParameter[0])] = HttpUtility.UrlDecode(arrParameter[1]);
                        }
                    }

                    // Return the argument collection
                    return objArguments;
                }

                // Return empty arguments
                return null;
                
            }
        }

        /// <summary>
        /// Gets the path query string.
        /// </summary>
        /// <value>The path query string.</value>
        private string PathQueryString
        {
            get
            {
                // Get path 
                string strPath = this.Path;

                // If path is valid
                if (!string.IsNullOrEmpty(strPath))
                {
                    // Get path parts
                    string[] arrPath = strPath.Split('?');

                    // If there query string parameters
                    if (arrPath.Length > 1)
                    {
                        // return the query string
                        return arrPath[1];
                    }
                }

                // return an empty query string
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the path page.
        /// </summary>
        /// <value>The path page.</value>
        private string PagePath
        {
            get
            {
                // Get path 
                string strPath = this.Path;

                // If path is valid
                if (!string.IsNullOrEmpty(strPath))
                {
                    // Normalize path seperator
                    strPath = strPath.Replace("\\", "/");

                    // If path does not contain root
                    if(!strPath.StartsWith("~/"))
                    {
                        strPath = string.Format("~/{0}", strPath);
                    }

                    // If path has a query string then remove it
                    if (strPath.Contains("?"))
                    {
                        strPath = strPath.Split('?')[0];
                    }

                    // Return formated path
                    return strPath;                    
                }

                // return an empty query string
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns a flag indicating if path is valid
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        private bool IsValidPath(string strPath)
        {
            // If string is not null or empty
            if (!string.IsNullOrEmpty(strPath))
            {
                // If not empty spaces
                if (strPath.Trim() != string.Empty)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// The path of the asp page to be displayed
        /// </summary>
        [DefaultValue("")]
        public string Path
        {
            get
            {
                //Get The value from the property store.
               return this.GetValue<string>(AspPageBox.PathProperty);                              
            }
            set
            {
                // If the control code has changed
                if (Path != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        //Remove from the property store
                        this.RemoveValue<string>(AspPageBox.PathProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<string>(AspPageBox.PathProperty, value);
                    }
                }
            }
            
        }

        #region IGatewayControl Members

        /// <summary>
        /// Provides a way to handle gateway requests.
        /// </summary>
        /// <param name="objHttpContext">The gateway request HTTP context.</param>
        /// <param name="strAction">The gateway request action.</param>
        /// <returns>
        /// By default this method returns a instance of a class which implements the IGatewayHandler and
        /// throws a non implemented HttpException.
        /// </returns>
        /// <remarks>
        /// This method is called from the implementation of IGatewayComponent which replaces the
        /// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
        /// RegisteredComponent class which is the base class of most of the Visual WebGui
        /// components.
        /// Referencing a RegisterComponent that overrides this method is done the same way that
        /// a control implementing IGatewayControl, which is by using the GatewayReference class.
        /// </remarks>
        protected override IGatewayHandler ProcessGatewayRequest(HttpContext objHttpContext, string strAction)
        {
            // If there is not http context
            if (objHttpContext == null)
            {
                // Throw an ASP.NET runtime unavailable exception
                throw new HttpException("ASP.NET runtime is unavailable.");
            }
            else
            {
                // Get the page path
                string strPagePath = this.PagePath;

                try
                {
                    // Get the page for this page
                    IHttpHandler objHttpHandler = (System.Web.UI.Page)System.Web.UI.PageParser.GetCompiledPageInstance(strPagePath, objHttpContext.Server.MapPath(strPagePath), objHttpContext);
                    if (objHttpHandler != null)
                    {
                        // Get AspPageBase if available
                        AspPageBase objAspPageBase = objHttpHandler as AspPageBase;
                        if (objAspPageBase != null)
                        {
                            // Set the host to current control
                            objAspPageBase.SetHost(this);
                        }

                        // Process the gateway request
                        objHttpHandler.ProcessRequest(objHttpContext);

                        // Return a null for the gateway handler
                        return null;

                    }
                }
                catch (Exception objEx)
                {
                    throw objEx;//new HttpException(404, string.Format("ASPX page '{0}' was not found.", strUrl));
                }
            }
            return null;
        }


        #endregion


        
    }
}
