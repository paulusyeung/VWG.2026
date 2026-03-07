#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Extensibility;
using System.Web;


using HtmlControls = System.Web.UI.HtmlControls;
using WebControls = System.Web.UI.WebControls;
using WebUI = System.Web.UI;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Web.Compilation;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Hosting;
using System.Web.UI;

#endregion

namespace Gizmox.WebGUI.Forms.Hosts
{

    /// <summary>
    /// 
    /// </summary>
    public delegate void AspSubmitHandler(object sender, AspSubmitArgs e);

    /// <summary>
    /// 
    /// </summary>
    public class AspSubmitArgs : EventArgs
    {
        private readonly string mstrEventArgument;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspSubmitArgs"/> class.
        /// </summary>
        /// <param name="strEventArgument">The event argument.</param>
        internal AspSubmitArgs(string strEventArgument)
        {
            mstrEventArgument = strEventArgument;
        }

        /// <summary>
        /// Gets the event argument.
        /// </summary>
        /// <value>The event argument.</value>
        public string EventArgument
        {
            get { return mstrEventArgument; }
        }
    }

    /// <summary>
    /// 	<para>AspControlBoxBase
    ///     provides a base class for creating ASP.NET wrapped controls that can be integrated
    ///     into VWG as a native control.</para>
    /// 	<para>The class provides
    ///     services for ASP.NET VWG communication and using ASP.NET markup code to
    ///     initialize the ASP.NET control.</para>
    /// </summary>
    /// <example>
    /// 	<para><font size="2">The following example illustrates the basic use of
    ///     AspControlBoxBase.</font></para>
    /// 	<code lang="CS">
    /// 		<![CDATA[
    /// [System.ComponentModel.ToolboxItem(true)]
    ///  public class MyWrappedWebControl : Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
    ///  {
    ///     /// <SUMMARY>
    ///     /// Get the hosted control type
    ///     /// </SUMMARY>
    ///     protected override Type HostedControlType
    ///     {
    ///         get
    ///         {
    ///             return typeof(WebControl);
    ///         }   
    ///     }
    ///  
    ///     /// <SUMMARY>
    ///     /// Get hosted control typed instance
    ///     /// </SUMMARY>
    ///     protected WebControl HostedASPxTreeList
    ///     {
    ///         get
    ///         {
    ///             return (WebControl)this.HostedControl;
    ///         }
    ///     }
    ///  
    /// }]]>
    /// 	</code>
    /// 	<code lang="VB">
    /// 		<![CDATA[
    /// <SYSTEM.COMPONENTMODEL.TOOLBOXITEM(TRUE)> _
    ///  Partial Class MyWrappedWebControl 
    /// Inherits Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
    ///  
    ///     ''' <SUMMARY>
    ///     ''' Get the hosted control type
    ///     ''' </SUMMARY>
    ///     Protected Overrides Readonly Property HostedControlType() As Type
    ///         Get
    ///             Return GetType(System.Web.UI.Control)
    ///         End Get
    ///     End Property
    ///  
    ///     ''' <SUMMARY>
    ///     ''' Get hosted control typed instance
    ///     ''' </SUMMARY>
    ///     Protected Readonly Property HostedControl As WebControl
    ///         Get
    ///             Return CType(Me.HostedControl, WebControl)
    ///         End Get
    ///     End Property
    ///  
    /// End Class]]>
    /// 	</code>
    /// </example>
    [ToolboxItem(false)]
    [ToolboxBitmapAttribute(typeof(AspControlBoxBase), "Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.bmp")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
    [Serializable()]
    [Skin(typeof(Skins.AspControlBoxBaseSkin))]
    public abstract class AspControlBoxBase : FrameControl
    {
        #region Classes

        /// <summary>
        /// Provides an implementation of a virtual file that can compile a code at runtime from a string or an embeded resource
        /// </summary>
        [Serializable()]
        internal class ResourceFile : VirtualFile
        {
            /// <summary>
            /// The relative path produced from the virtual path
            /// </summary>
            private string mstrRelativePath;

            /// <summary>
            /// Initializes a new instance of the <see cref="ResourceFile"/> class.
            /// </summary>
            /// <param name="strVirtualPath">The virtual path.</param>
            internal ResourceFile(string strVirtualPath)
                : base(strVirtualPath)
            {
                mstrRelativePath = VirtualPathUtility.ToAppRelative(strVirtualPath);
            }

            /// <summary>
            /// Opens this instance.
            /// </summary>
            /// <returns></returns>
            public override System.IO.Stream Open()
            {
                // Get the path parts
                string[] arrPath = mstrRelativePath.Split('/');
                string strContainerName = arrPath.Length > 1 ? arrPath[1] : "";
                string strResourceName = arrPath.Length > 2 ? arrPath[2] : "";

                // If the container name starts with a VwgResourcePrefix this is a dynamic string to be compilied
                string strContainerGuid = strContainerName.Substring(ResourceProvider.VwgResourcePrefix.Length + 1).Replace(".ascx", "");
                Guid objContainerGuid = new Guid(strContainerGuid);
                return ResourceProvider.GetBuildCode(objContainerGuid);
            }

            private Stream GetDisconectedStream(Assembly objAssembly, string strResourceName)
            {
                Stream objStream = objAssembly.GetManifestResourceStream(strResourceName);
                if (objStream != null)
                {
                    // Create a memory stream
                    MemoryStream objMemoryStream = new MemoryStream();

                    StreamReader objStreamReader = new StreamReader(objStream);

                    StreamWriter objMemoryWriter = new StreamWriter(objMemoryStream);
                    objMemoryWriter.Write(objStreamReader.ReadToEnd());
                    objMemoryWriter.Flush();

                    // Return the position to the first byte
                    objMemoryStream.Position = 0;

                    objStream.Close();

                    // Return the generated stream
                    return objMemoryStream;
                }
                return null;
            }

        }

        /// <summary>
        /// Provides a custom resource provider to help build types from string or an embeded resource
        /// </summary>
        [Serializable()]
        internal class ResourceProvider : System.Web.Hosting.VirtualPathProvider
        {
            internal const string VwgResourcePrefix = "VWG_AspResource";

            /// <summary>
            /// Temporary stored code strings
            /// </summary>
            private static Dictionary<Guid, string> mobjTemporaryStoredCode;

            /// <summary>
            /// Initializes the <see cref="ResourceProvider"/> class.
            /// </summary>
            static ResourceProvider()
            {
                // Stores code for later use
                mobjTemporaryStoredCode = new Dictionary<Guid, string>();

                // Registeres the current resource provider
                HostingEnvironment.RegisterVirtualPathProvider(new ResourceProvider());
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ResourceProvider"/> class.
            /// </summary>
            internal ResourceProvider()
            {
            }

            /// <summary>
            /// Determines whether virtual path is a resource path.
            /// </summary>
            /// <param name="strVirtualPath">The virtual path.</param>
            /// <returns>
            /// 	<c>true</c> if virtual path is a resource path; otherwise, <c>false</c>.
            /// </returns>
            private bool IsAppResourcePath(string strVirtualPath)
            {
                String checkPath = VirtualPathUtility.ToAppRelative(strVirtualPath);
                return checkPath.Contains(VwgResourcePrefix);
            }

            /// <summary>
            /// Gets a value that indicates whether a file exists in the virtual file system.
            /// </summary>
            /// <param name="strVirtualPath">The path to the virtual file.</param>
            /// <returns>
            /// true if the file exists in the virtual file system; otherwise, false.
            /// </returns>
            public override bool FileExists(string strVirtualPath)
            {
                return (IsAppResourcePath(strVirtualPath) || base.FileExists(strVirtualPath));
            }

            /// <summary>
            /// Gets the file.
            /// </summary>
            /// <param name="strVirtualPath">The virtual path.</param>
            /// <returns></returns>
            public override System.Web.Hosting.VirtualFile GetFile(string strVirtualPath)
            {
                if (IsAppResourcePath(strVirtualPath))
                    return new ResourceFile(strVirtualPath);
                else
                    return base.GetFile(strVirtualPath);
            }

            /// <summary>
            /// Creates a cache dependency based on the specified virtual paths.
            /// </summary>
            /// <param name="strVirtualPath">The path to the primary virtual resource.</param>
            /// <param name="objVirtualPathDependencies">An array of paths to other resources required by the primary virtual resource.</param>
            /// <param name="utcStart">The UTC time at which the virtual resources were read.</param>
            /// <returns>
            /// A <see cref="T:System.Web.Caching.CacheDependency"/> object for the specified virtual resources.
            /// </returns>
            public override System.Web.Caching.CacheDependency GetCacheDependency(string strVirtualPath, System.Collections.IEnumerable objVirtualPathDependencies, DateTime objUtcStart)
            {
                if (IsAppResourcePath(strVirtualPath))
                    return null;
                else
                    return base.GetCacheDependency(strVirtualPath, objVirtualPathDependencies, objUtcStart);
            }

            /// <summary>
            /// Gets the type of the virtual path.
            /// </summary>
            /// <param name="strVirtualPath">The control virtual path.</param>
            internal static Type GetVirtualPathType(string strVirtualPath)
            {
                return BuildManager.GetCompiledType(strVirtualPath);
            }

            /// <summary>
            /// Gets the type of the compiled.
            /// </summary>
            /// <param name="strAspCode">The ASP code.</param>
            /// <returns></returns>
            public static Type GetCompiledType(string strAspCode)
            {
                // Create a temporary build guid
                System.Guid objBuildGuid = System.Guid.NewGuid();

                // Reference to the compiled type
                Type objBuildType = null;

                // Store the code to a temporaty hashtable based on the build guid
                mobjTemporaryStoredCode[objBuildGuid] = strAspCode;

                try
                {
                    // compile the code using a virtual path that is based on the build guid (the ResourceProvider handles this path.
                    string strVirtualPath = string.Format("~/{0}_{1}.ascx", VwgResourcePrefix, objBuildGuid.ToString("N"));
                    objBuildType = BuildManager.GetCompiledType(strVirtualPath);
                }
                finally
                {
                    // Remove code from temporary storage
                    mobjTemporaryStoredCode.Remove(objBuildGuid);
                }

                // Return the built type
                return objBuildType;

            }

            /// <summary>
            /// Gets the build code.
            /// </summary>
            /// <param name="objBuildGuid">The obj build GUID.</param>
            /// <returns></returns>
            internal static Stream GetBuildCode(Guid objBuildGuid)
            {
                // Create a memory stream
                MemoryStream objStream = new MemoryStream();

                // Check if temporary storage contains the build guid
                if (mobjTemporaryStoredCode.ContainsKey(objBuildGuid))
                {
                    // Create a stream writer and write the code to the stream
                    StreamWriter objBuildCodeWriter = new StreamWriter(objStream);
                    objBuildCodeWriter.Write(mobjTemporaryStoredCode[objBuildGuid]);
                    objBuildCodeWriter.Flush();

                    // Return the position to the first byte
                    objStream.Position = 0;
                }

                // Return the generated stream
                return objStream;
            }
        }

        #endregion

        #region Members

        protected internal enum VersionCompatibilityMode
        {
            Version6,
            Version72
        }

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to ControlState property.
        /// </summary>
        private static SerializableProperty ControlStateProperty = SerializableProperty.Register("ControlState", typeof(object), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to ViewState property.
        /// </summary>
        private static SerializableProperty ViewStateProperty = SerializableProperty.Register("ViewState", typeof(object), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to DefaultDesignValues property.
        /// </summary>
        private static SerializableProperty DefaultDesignValuesProperty = SerializableProperty.Register("DefaultDesignValues", typeof(Dictionary<string, object>), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to DesignTimeProperties property.
        /// </summary>
        private static SerializableProperty DesignTimePropertiesProperty = SerializableProperty.Register("DesignTimeProperties", typeof(Dictionary<string, object>), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to DesignTimeProperties property.
        /// </summary>
        private static SerializableProperty DesignTimeEventHandlersProperty = SerializableProperty.Register("DesignTimeEventHandlers", typeof(Dictionary<string, List<Delegate>>), typeof(AspControlBoxBase), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to Properties property.
        /// </summary>
        private static SerializableProperty PropertiesProperty = SerializableProperty.Register("Properties", typeof(Dictionary<string, PropertyInfo>), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to AspPipeLinePage property.
        /// </summary>
        private static SerializableProperty AspPipeLinePageProperty = SerializableProperty.Register("AspPipeLinePage", typeof(AspPipeLinePage), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to EventHandlers property.
        /// </summary>
        private static SerializableProperty EventHandlersProperty = SerializableProperty.Register("EventHandlers", typeof(Dictionary<string, List<Delegate>>), typeof(AspControlBoxBase), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to Events property.
        /// </summary>
        private static SerializableProperty EventsProperty = SerializableProperty.Register("Events", typeof(Dictionary<string, EventInfo>), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to IsAspRequest property.
        /// </summary>
        private static SerializableProperty IsAspRequestProperty = SerializableProperty.Register("IsAspRequest", typeof(bool), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to AutoScroll property.
        /// </summary>
        private static SerializableProperty AutoScrollProperty = SerializableProperty.Register("AutoScroll", typeof(bool), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to ControlCodeType property.
        /// </summary>
        private static SerializableProperty ControlCodeTypeProperty = SerializableProperty.Register("ControlCodeType", typeof(Type), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to ControlCode property.
        /// </summary>
        private static SerializableProperty ControlCodeProperty = SerializableProperty.Register("ControlCode", typeof(string), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to ControlID property.
        /// </summary>
        private static SerializableProperty ControlIDProperty = SerializableProperty.Register("ControlID", typeof(string), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to SyncPostDataChangesMode property.
        /// </summary>
        private static SerializableProperty SyncChangesOnVwgPostBackProperty = SerializableProperty.Register("SyncChangesOnVwgPostBack", typeof(SyncPostDataChangesMode), typeof(AspControlBoxBase), new SerializablePropertyMetadata(SyncPostDataChangesMode.None));

        /// <summary>
        /// Provides a property reference to SyncPostDataChangesMode property.
        /// </summary>
        private static SerializableProperty ScriptsProperty = SerializableProperty.Register("Scripts", typeof(string[]), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to SyncPostDataChangesMode property.
        /// </summary>
        private static SerializableProperty StylesProperty = SerializableProperty.Register("Styles", typeof(string[]), typeof(AspControlBoxBase));

        /// <summary>
        /// Provides a property reference to SyncPostData property.
        /// </summary>
        private static SerializableProperty SyncPostDataProperty = SerializableProperty.Register("SyncPostData", typeof(NameValueCollection), typeof(AspControlBoxBase));

        #endregion

        [NonSerialized()]
        private bool mblnProcessMainEndRequired = false;

        [NonSerialized()]
        private bool mblnAspUpdate = false;

        [NonSerialized()]
        private WebUI.Control mobjHostedControlForAspUpdate;

        [NonSerialized()]
        private AspPipeLinePage mobjHostedPage;


        public event AspSubmitHandler Submit;

        #endregion

        #region C'Tor

        /// <summary>Create asp.net control box</summary>
        public AspControlBoxBase()
        {
            // Create property storage
            this.Properties = new Dictionary<string, PropertyInfo>();
            this.EventsList = new Dictionary<string, EventInfo>();
            this.EventHandlers = new Dictionary<string, List<Delegate>>();
        }

        #endregion

        #region Methods

        #region Rendering & Gateway

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        protected override string Source
        {
            get
            {
                // NOTE: For the wrap controls, the source should be absolute. (start with http://) because otherwise the source url will be the vwg base href url,
                // that contains lots of virtual segments. Example: http://localhost/Route/2.800017.1.1/ie/en-US/Default/983038.49150.918/0/
                // If we will not put the source with "http://" and let the source be the vwg base href, if the asp control do ResolveClientPath, the resolve will 
                // go up in the directories according to the pathes in the vwg base href, and will throw "top directory" exception.

                string strSource = CommonUtils.GetBaseUrl(VWGContext.Current.HostContext.Request);

                string strGatewayReference = (new GatewayReference(this, "ASCXHost", null)).ToString();

                // Add cookie to Url on cookieless sessionstates
                if (VWGContext.Current.HostContext.HttpContext.Session.IsCookieless)
                    strGatewayReference = VWGContext.Current.HostContext.HttpContext.Response.ApplyAppPathModifier(strGatewayReference);

                strSource += strGatewayReference;
                return strSource;
            }
        }

        /// <summary>
        /// Handle the HostedPageProcessStarting event.
        /// </summary>
        void AspControlBoxBase_HostedPageProcessStarting(object sender, AspPageEventArgs e)
        {
            if (SyncPostData != null)
            {
                // Add the Request with the post data so the AspControl will use it.
                EmulatePost(e.Page.Request, SyncPostData);
            }

            mblnProcessMainEndRequired = true;
        }

        /// <summary>
        /// Recieves request and post data collection, and emulates the request as post request.
        /// </summary>
        private void EmulatePost(HttpRequest objRequest, NameValueCollection arrPostData)
        {
            // Create request form data collection object.            
            Type objRequestFormType = GetSystemWebFullTypeName("System.Web.HttpValueCollection");
            ConstructorInfo objConstructorInfo = objRequestFormType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
            NameValueCollection objRequestFormData = objConstructorInfo.Invoke(new object[] { }) as NameValueCollection;

            // Set the IsReadOnly request form data collection to false, so we will be able to update the object.
            PropertyInfo objReadOnlyPropertyInfo = objRequestFormData.GetType().GetProperty("IsReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            objReadOnlyPropertyInfo.SetValue(objRequestFormData, false, null);

            // Set post data to the request form data.
            for (int i = 0; i < arrPostData.Count; i++)
            {
                objRequestFormData.Add(arrPostData.GetKey(i), arrPostData.Get(i));
            }

            // Return the IsReadOnly to true.
            objReadOnlyPropertyInfo.SetValue(objRequestFormData, true, null);

            // Set form data to the request form field.
            FieldInfo objRequestFormField = typeof(HttpRequest).GetField("_form", BindingFlags.NonPublic | BindingFlags.Instance);
            objRequestFormField.SetValue(objRequest, objRequestFormData);

            // Set HttpMethod/Verb to POST. (Required for the asp conrol to process the posted data)
            FieldInfo objHttpMethodField = typeof(HttpRequest).GetField("_httpMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            objHttpMethodField.SetValue(objRequest, "POST");

            FieldInfo objHttpVerbField = typeof(HttpRequest).GetField("_httpVerb", BindingFlags.NonPublic | BindingFlags.Instance);
            Type objHttpVerbType = GetSystemWebFullTypeName("System.Web.HttpVerb");
            object objHttpPostVerb = Enum.Parse(objHttpVerbType, "POST");
            objHttpVerbField.SetValue(objRequest, objHttpPostVerb);
        }

        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            // NOTE: If we are in asp request, we should not user the post data. (It is used only for the vwg requests)
            if (objEvent.Type == "SyncVwgChanges" && !IsAspRequest)
            {
                // If we got post data that needs to be sync to the asp control, we will save it here and set it when the hosted page is create and its request form can be accessed.
                string strSyncPostData = objEvent["PostData"];
                strSyncPostData = HttpUtility.UrlDecode(strSyncPostData);
                strSyncPostData = HttpUtility.HtmlDecode(strSyncPostData);

                NameValueCollection arrPostData = new NameValueCollection();
                string[] objPostDataFields = strSyncPostData.Split('&');

                // Build name value collection with the post data.
                SyncPostData = new NameValueCollection();
                foreach (string strPostDataField in objPostDataFields)
                {
                    // NOTE: The value of the post data field might have also "=" character, so for this case we do split to only 2 items)
                    string[] objKeyValue = strPostDataField.Split(new char[] { '=' }, 2);
                    SyncPostData.Add(objKeyValue[0], objKeyValue[1]);
                }
            }
        }

        /// <summary>
        /// Creates the host page head control.
        /// </summary>
        /// <returns></returns>
        protected virtual HtmlControls.HtmlHead CreateHostPageHead()
        {
            // Create head
            HtmlControls.HtmlHead objASPHead = new HtmlControls.HtmlHead();
            HtmlControls.HtmlTitle objASPTitle = new HtmlControls.HtmlTitle();
            objASPHead.Controls.Add(objASPTitle);
            return objASPHead;
        }

        /// <summary>
        /// Creates the host page form control.
        /// </summary>
        /// <returns></returns>
        protected virtual HtmlControls.HtmlForm CreateHostPageForm()
        {
            HtmlControls.HtmlForm objASPForm = new HtmlControls.HtmlForm();
            objASPForm.ID = this.FormName;
            return objASPForm;
        }

        /// <summary>
        /// Creates the host page body control.
        /// </summary>
        /// <returns></returns>
        protected virtual HtmlControls.HtmlControl CreateHostPageBody()
        {
            HtmlControls.HtmlControl objASPBody = new HtmlControls.HtmlGenericControl("body");
            objASPBody.Style.Add("margin", "0px");
            if (this.AutoScroll)
            {
                objASPBody.Style.Add("overflow", "auto");
            }
            else
            {
                objASPBody.Style.Add("overflow", "hidden");
            }
            
          


            return objASPBody;
        }

        /// <summary>
        /// Get ASP.NET page
        /// </summary>
        /// <returns></returns>
        private AspPipeLinePage CreateHostPage()
        {
            // Create aspx page
            AspPipeLinePage objHostedPage = new AspPipeLinePage(this);
            objHostedPage.VwgControlId = this.ID;
            objHostedPage.EnableViewState = true;
            objHostedPage.Load += new EventHandler(OnHostedPageLoad);
            objHostedPage.PreInit += new EventHandler(OnHostedPagePreInit);
            objHostedPage.PreLoad += new EventHandler(OnHostedPagePreLoadInternal);
            objHostedPage.PreRender += new EventHandler(OnHostedPagePreRender);
            objHostedPage.PreRenderComplete += new EventHandler(OnHostedPagePreRenderComplete);
            objHostedPage.Init += new EventHandler(OnHostedPageInit);
            objHostedPage.InitComplete += new EventHandler(OnHostedPageInitComplete);
            objHostedPage.LoadComplete += new EventHandler(OnHostedPageLoadComplete);
            objHostedPage.Error += new EventHandler(OnHostedPageError);
            objHostedPage.DataBinding += new EventHandler(OnHostedPageDataBinding);
            objHostedPage.Disposed += new EventHandler(OnHostedPageDisposed);
            objHostedPage.PageProcessStarting += AspControlBoxBase_HostedPageProcessStarting;

            // Create html tag
            HtmlControls.HtmlControl objASPHtml = new HtmlControls.HtmlGenericControl("html");
            objHostedPage.Controls.Add(objASPHtml);

            // Create head
            HtmlControls.HtmlHead objASPHead = this.CreateHostPageHead();
            if (objASPHead != null)
            {
                objASPHtml.Controls.Add(objASPHead);
            }

            HtmlControls.HtmlControl objASPBody = this.CreateHostPageBody();
            if (objASPBody == null)
            {
                throw new Exception("CreateHostPageBody method should not return a null value.");
            }
            objASPHtml.Controls.Add(objASPBody);


            // Get form
            HtmlControls.HtmlForm objASPForm = this.CreateHostPageForm();
            if (objASPForm == null)
            {
                throw new Exception("CreateHostPageForm method should not return a null value.");
            }
            objASPBody.Controls.Add(objASPForm); ;


            // Create hosted control from hosted control type
            System.Web.UI.Control objHostedControlContainer = CreateHostedControlContainer(objHostedPage);
            if (objHostedControlContainer != null)
            {

                // Add control to form
                objASPForm.Controls.Add(objHostedControlContainer);

                // Get hosted control
                System.Web.UI.Control objHostedControl = null;

                // Get the hosted control
                objHostedControl = objHostedControlContainer.FindControl(this.ControlID);
                if (objHostedControl == null)
                {
                    // Could not find the hosted control in the code
                    throw new Exception(string.Format("Could not resolve the hosted control using '{0}' control ID.", this.ControlID));
                }
                else
                {
                    // Check that the control is from the right type
                    if (!this.HostedControlType.IsAssignableFrom(objHostedControl.GetType()))
                    {
                        throw new Exception(string.Format("Cannot convert hosted control found using '{0}' control ID to '{1}' type.", this.ControlID, this.HostedControlType.FullName));
                    }
                }

                // If hosted control was resolved                
                if (objHostedControl != null)
                {
                    // Attach hosted control events
                    objHostedControl.Init += new EventHandler(OnHostedControlInit);
                    objHostedControl.Load += new EventHandler(OnHostedControlLoad);
                    objHostedControl.PreRender += new EventHandler(OnHostedControlPreRender);
                    objHostedControl.Unload += new EventHandler(OnHostedControlUnload);
                    objHostedControl.DataBinding += new EventHandler(OnHostedControlDataBinding);
                    objHostedControl.Disposed += new EventHandler(OnHostedControlDisposed);
                                        // Restore contol events
                    RestoreControlDesignEvents(objHostedControl);

                    // Eneable control view state
                    objHostedControl.EnableViewState = true;

                    // Set the hosted control
                    objHostedPage.HostedControl = objHostedControl;
                }
            }

            // Return aspx page
            return objHostedPage;
        }

        protected virtual void RestoreControlSize(System.Web.UI.Control objHostedControl)
        {
            // Get web control
            WebControls.WebControl objWebControl = objHostedControl as WebControls.WebControl;
            if (objWebControl != null)
            {
                if (!this.IsFixedSize)
                {
                    // Set control dimensions
                    objWebControl.Height = new WebControls.Unit("100%");
                    objWebControl.Width = new WebControls.Unit("100%");
                }
                else
                {
                    // Set control dimensions
                    objWebControl.Height = new WebControls.Unit(this.Height - Padding.Vertical);
                    objWebControl.Width = new WebControls.Unit(this.Width - Padding.Horizontal);
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Resize"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.IsFixedSize)
            {
                this.Update(true);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is fixed size.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is fixed size; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Occurs when the hosted control page loads
        /// </summary>
        public event AspPageEventHandler HostedPageLoad;

        /// <summary>
        /// Occurs when the hosting page is loaded.
        /// </summary>
        protected virtual void OnHostedPageLoad(object sender, EventArgs e)
        {
            // If AspUpdateHostedControl is set it means we are in ProcessGatewayRequest after VwgRequest - AspUpdate, we should not
            // raise the event because it was already raised in the VwgRequest.
            if (HostedControlForAspUpdate != null) { return; }

            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPageLoad;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPageError;

        /// <summary>
        /// Called when hosted page throws error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnHostedPageError(object sender, EventArgs e)
        {
            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPageError;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPageLoadComplete;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPageLoadComplete(object sender, EventArgs e)
        {
            // If AspUpdateHostedControl is set it means we are in ProcessGatewayRequest after VwgRequest - AspUpdate, we should not
            // raise the event because it was already raised in the VwgRequest.
            if (HostedControlForAspUpdate == null)
            {
            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPageLoadComplete;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

            // Replace the HostedControl with the HostedControl for replace.
            if (HostedControlForAspUpdate != null)
            {
                WebUI.Control objParentHostedControl = HostedControl.Parent;
                objParentHostedControl.Controls.Clear();
                objParentHostedControl.Controls.Add(HostedControlForAspUpdate);
                HostedPage.HostedControl = HostedControlForAspUpdate;

                HostedControlForAspUpdate = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPageInitComplete;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPageInitComplete(object sender, EventArgs e)
        {
            // If AspUpdateHostedControl is set it means we are in ProcessGatewayRequest after VwgRequest - AspUpdate, we should not
            // raise the event because it was already raised in the VwgRequest.
            if (HostedControlForAspUpdate != null) { return; }

            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPageInitComplete;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPagePageInit;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPageInit(object sender, EventArgs e)
        {
            // If AspUpdateHostedControl is set it means we are in ProcessGatewayRequest after VwgRequest - AspUpdate, we should not
            // raise the event because it was already raised in the VwgRequest.
            if (HostedControlForAspUpdate != null) { return; }

            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPagePageInit;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPagePreRenderComplete;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPagePreRenderComplete(object sender, EventArgs e)
        {
            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPagePreRenderComplete;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPagePreRender;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPagePreRender(object sender, EventArgs e)
        {
            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPagePreRender;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPagePreLoad;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHostedPagePreLoadInternal(object sender, EventArgs e)
        {
            RestoreControlSize(this.HostedControl);

            // NOTE: We must restore the design properties here and not in the CreateHostedPage, because in the CreateHostedPage
            // the properties will not insert into the ViewState, so in the following scenario it wont work:
            // VwgRequest -> SetText="123" -> SaveState (The "123" will not be save in the state because it was changed too early (In the CreateHostedPage)
            // AspControlRequest -> Show Text "123" because the HostedPage used by the AspRequest is the same as the one of VwgRequest -> AspRequest set HostedPage to null 
            // -> VwgRequest -> Text becomes "" because it was not saved in the state.
            TryRestoreControlDesignProperties(this.HostedControl);

            OnHostedPagePreLoad(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPagePreLoad(object sender, EventArgs e)
        {
            // If AspUpdateHostedControl is set it means we are in ProcessGatewayRequest after VwgRequest - AspUpdate, we should not
            // raise the event because it was already raised in the VwgRequest.
            if (HostedControlForAspUpdate != null) { return; }

            if (this.HostedPagePreLoad != null)
            {
                this.HostedPagePreLoad(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPagePreInit;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPagePreInit(object sender, EventArgs e)
        {
            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPagePreInit;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspControlEventHandler HostedControlDisposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedControlDisposed(object sender, EventArgs e)
        {
            // Raise event if needed
            AspControlEventHandler objEventHandler = this.HostedControlDisposed;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspControlEventArgs((System.Web.UI.Control)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedPageDisposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPageDisposed(object sender, EventArgs e)
        {
            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedPageDisposed;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspPageEventHandler HostedHostedPageDataBinding;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedPageDataBinding(object sender, EventArgs e)
        {
            // Raise event if needed
            AspPageEventHandler objEventHandler = this.HostedHostedPageDataBinding;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspPageEventArgs((System.Web.UI.Page)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal virtual void OnSubmit(object sender, AspSubmitArgs e)
        {
            // Raise event if needed
            AspSubmitHandler objEventHandler = this.Submit;
            if (objEventHandler != null)
            {
                objEventHandler(sender, e);
            }
        }

        /// <summary>
        /// Does the submit.
        /// </summary>
        /// <param name="strEventArgument">The STR event argument.</param>
        public void DoSubmit(string strEventArgument)
        {
            this.InvokeMethodWithId("Web_SubmitHostedForm", strEventArgument);
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspControlEventHandler HostedControlDataBinding;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedControlDataBinding(object sender, EventArgs e)
        {
            // Raise event if needed
            AspControlEventHandler objEventHandler = this.HostedControlDataBinding;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspControlEventArgs((System.Web.UI.Control)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspControlEventHandler HostedControlUnload;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedControlUnload(object sender, EventArgs e)
        {
            // Raise event if needed
            AspControlEventHandler objEventHandler = this.HostedControlUnload;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspControlEventArgs((System.Web.UI.Control)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspControlEventHandler HostedControlPreRender;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedControlPreRender(object sender, EventArgs e)
        {
            // Raise event if needed
            AspControlEventHandler objEventHandler = this.HostedControlPreRender;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspControlEventArgs((System.Web.UI.Control)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspControlEventHandler HostedControlLoad;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedControlLoad(object sender, EventArgs e)
        {
            // Raise event if needed
            AspControlEventHandler objEventHandler = this.HostedControlLoad;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspControlEventArgs((System.Web.UI.Control)sender));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event AspControlEventHandler HostedControlInit;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnHostedControlInit(object sender, EventArgs e)
        {
            // Raise event if needed
            AspControlEventHandler objEventHandler = this.HostedControlInit;
            if (objEventHandler != null)
            {
                objEventHandler(this, new AspControlEventArgs((System.Web.UI.Control)sender));
            }
        }

        /// <summary>
        /// Creates the hosted control.
        /// </summary>
        /// <returns></returns>
        private System.Web.UI.Control CreateHostedControlContainer(AspPipeLinePage objHostedPage)
        {
            // Creates a new instance of the compiled code 
            System.Web.UI.UserControl objUserControl = Activator.CreateInstance(this.ControlCodeType) as System.Web.UI.UserControl;
            if (objUserControl != null)
            {
                // Initialize the user control so that its child controls will be abailable
                objUserControl.InitializeAsUserControl(objHostedPage);
            }
            return objUserControl;
        }

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
                // Indicate control is in asp request mode
                IsAspRequest = true;

                // Flag to buffer output.
                objHttpContext.Response.Buffer = true;

                try
                {
                    AspPipeLinePage objHostedPage = this.HostedPage;
                    // If there is no valid hosted page
                    if (objHostedPage == null)
                    {
                        this.HostedPage = objHostedPage = CreateHostPage();
                    }

                    // If there is a valid hosted page
                    if (objHostedPage != null)
                    {
                        if (CompatibilityMode != VersionCompatibilityMode.Version6)
                        {
                            // If we are in Get request and not in the first request (SyncPostData != null) it means we are in refresh
                            // and we need to emulate the request with the last post data.
                            if (objHttpContext.Request.HttpMethod == "GET")
                            {
                                if (SyncPostData != null)
                                {
                                    EmulatePost(objHttpContext.Request, SyncPostData);
                                }
                            }
                            else
                            {
                                // Save the post data without the vwg pipeline field.
                                SyncPostData = new NameValueCollection();
                                foreach (string strPostDataItemName in objHttpContext.Request.Form)
                                {
                                    if (strPostDataItemName == AspPipeLinePage.VwgPipelineName) { continue; }

                                    SyncPostData.Add(strPostDataItemName, objHttpContext.Request.Form[strPostDataItemName]);
                                }
                            }
                        }

                        // Process request
                        objHostedPage.ProcessRequest(objHttpContext);
                    }
                }
                finally
                {
                    // Indicate control is not in asp request mode
                    this.IsAspRequest = false;
                    this.HostedPage = null;
                }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// Gets the view state.
        /// </summary>
        /// <returns></returns>
        internal object GetViewStateInternal()
        {
            return ViewState;
        }

        /// <summary>
        /// Sets the view state.
        /// </summary>
        /// <param name="objState">The current view state to set.</param>
        internal void SetViewStateInternal(object objState)
        {
            ViewState = objState;
        }

        /// <summary>
        /// Gets the control state.
        /// </summary>
        /// <returns></returns>
        internal object GetControlStateInternal()
        {
            return ControlState;
        }

        /// <summary>
        /// Sets the control state.
        /// </summary>
        /// <param name="objState">The current control state to set.</param>
        internal void SetControlStateInternal(object objState)
        {
            ControlState = objState;
        }

        /// <summary>
        /// Sets a hosted control property value
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="objValue"></param>
        protected void SetProperty(string strName, object objValue)
        {
            // If there is a property info for this name
            PropertyInfo objPropertyInfo = GetPropertyInfo(strName);
            if (objPropertyInfo != null)
            {
                // If is a writable property
                if (objPropertyInfo.CanWrite)
                {
                    if (!CanAccessHostControl)
                    {
                        Dictionary<string, object> objDesignTimeProperties = this.DesignTimeProperties;
                        // If we do not have a design time property hash create it
                        if (objDesignTimeProperties == null)
                        {
                            objDesignTimeProperties = new Dictionary<string, object>();
                            DesignTimeProperties = objDesignTimeProperties;
                        }
                        objDesignTimeProperties[strName] = objValue;
                    }
                    else
                    {
                        // Set control value
                        objPropertyInfo.SetValue(HostedControl, objValue, null);

                        // Perform asp update.
                        AspUpdate();
                    }
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is parent valid.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is parent valid; otherwise, <c>false</c>.
        /// </value>
        private bool IsParentValid
        {
            get
            {
                return this.Parent != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether control code is valid.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if control code is valid; otherwise, <c>false</c>.
        /// </value>
        private bool IsCodeControlValid
        {
            get
            {
                return !string.IsNullOrEmpty(this.ControlCode);
            }
        }

        /// <summary>
        /// Gets a hosted control boolean property value
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        protected bool GetBoolProperty(string strName)
        {
            return (bool)GetProperty(strName);
        }

        /// <summary>
        /// Gets a hosted control integer property value
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        protected int GetIntProperty(string strName)
        {
            return (int)GetProperty(strName);
        }

        /// <summary>
        /// Gets a hosted control color property value
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        protected Color GetColorProperty(string strName)
        {
            return (Color)GetProperty(strName);
        }

        /// <summary>
        /// Resets the specified property.
        /// </summary>
        /// <param name="strPropertyName">The property name.</param>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected void Reset(string strPropertyName)
        {
            // Get property info for the current property
            PropertyInfo objPropertyInfo = GetPropertyInfo(strPropertyName);
            if (objPropertyInfo != null)
            {
                this.SetProperty(strPropertyName, this.GetPropertyDefaultValue(objPropertyInfo));
            }
        }

        /// <summary>
        /// General purpose should serialize method for evaluating property should serialize methods.
        /// </summary>
        /// <param name="strPropertyName">The property name.</param>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected bool ShouldSerialize(string strPropertyName)
        {
            // Get the current property value
            object objPropertyValue = GetProperty(strPropertyName);

            Dictionary<string, object> objDefaultDesignValues = DefaultDesignValues;
            // If the design time defaults cache is not initialized
            if (objDefaultDesignValues == null)
            {
                // Initialize design time defaults cache
                objDefaultDesignValues = new Dictionary<string, object>();
                DefaultDesignValues = objDefaultDesignValues;
            }

            // If design time default cache does not contain property default value
            if (!objDefaultDesignValues.ContainsKey(strPropertyName))
            {
                // Get property info for the current property
                PropertyInfo objPropertyInfo = GetPropertyInfo(strPropertyName);
                if (objPropertyInfo != null)
                {
                    // Get default value for the property
                    objDefaultDesignValues[strPropertyName] = GetPropertyDefaultValue(objPropertyInfo);
                }
                else
                {
                    // Set the default value to null
                    objDefaultDesignValues[strPropertyName] = null;
                }
            }

            // Get the default value from the cache for this property
            object objDefaultValue = objDefaultDesignValues[strPropertyName];

            // Evaluate if values are the same
            if (objDefaultValue == null && objPropertyValue == null)
            {
                return false;
            }
            else if ((objDefaultValue == null && objPropertyValue != null) || (objDefaultValue != null && objPropertyValue == null))
            {
                return true;
            }
            else
            {
                return !objPropertyValue.Equals(objDefaultValue);
            }

        }

        /// <summary>
        /// Gets a hosted control property value
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        protected object GetProperty(string strName)
        {
            // Get property value
            PropertyInfo objPropertyInfo = GetPropertyInfo(strName);
            if (objPropertyInfo != null)
            {
                if (!CanAccessHostControl)
                {
                    Dictionary<string, object> objDesignTimeProperties = this.DesignTimeProperties;
                    // If there are design time values and there is a value for this property
                    if (objDesignTimeProperties != null && objDesignTimeProperties.ContainsKey(strName))
                    {
                        return objDesignTimeProperties[strName];
                    }
                    else
                    {
                        return GetPropertyDefaultValue(objPropertyInfo);
                    }
                }
                else
                {
                    return objPropertyInfo.GetValue(this.HostedControl, null);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether running in design mode.
        /// </summary>
        /// <value><c>true</c> if in design mode; otherwise, <c>false</c>.</value>
        private bool InDesignMode
        {
            get
            {
                if (!this.DesignMode)
                {
                    return HostContext.Current == null;
                }
                return true;
            }
        }

        #region Events Related

        /// <summary>
        /// Add an event handler to one of the control's event infos.
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="objEventHandler"></param>
        protected void AddEventHandler(string strName, Delegate objEventHandler)
        {
            if (CompatibilityMode == VersionCompatibilityMode.Version6)
            {
                Version6AddEventHandler(strName, objEventHandler);
                return;
            }

            if (CanAccessHostControl)
            {
                AddEventHandler(strName, objEventHandler, HostedControl);
            }
            else
            {
                // Here we will put the handler in a design time event handles dictionary.
                Dictionary<string, List<Delegate>> objDesignTimeEventHandlers = this.DesignTimeEventHandlers;
                if (objDesignTimeEventHandlers == null)
                {
                    objDesignTimeEventHandlers = new Dictionary<string, List<Delegate>>();
                    DesignTimeEventHandlers = objDesignTimeEventHandlers;
                }

                List<Delegate> objEventHandlers;
                if (!objDesignTimeEventHandlers.TryGetValue(strName, out objEventHandlers))
                {
                    objEventHandlers = new List<Delegate>();
                    objDesignTimeEventHandlers.Add(strName, objEventHandlers);
                }

                objEventHandlers.Add(objEventHandler);
            }
        }

        /// <summary>
        /// Add an event handler to one of the control's event infos.
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="objEventHandler"></param>
        private void AddEventHandler(string strName, Delegate objEventHandler, WebUI.Control objHostedControl)
        {
            // If there is an event info for this name
            EventInfo objEventInfo = GetEventInfo(strName);
            if (objEventInfo != null)
            {

                // Get the event info's event handlers sorted list.
                List<Delegate> objEventHandlers = GetEventHandlers(strName, true);
                if (objEventHandlers != null)
                {
                    // Store the event handler
                    objEventHandlers.Add(objEventHandler);
                }

                // Ad an event handler.
                objEventInfo.AddEventHandler(objHostedControl, objEventHandler);
            }
        }

        /// <summary>
        /// Removes an event handler from one of the control's event infos.
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="objEventHandler"></param>
        protected void RemoveEventHandler(string strName, Delegate objEventHandler)
        {
            if (CompatibilityMode == VersionCompatibilityMode.Version6)
            {
                Version6RemoveEventHandler(strName, objEventHandler);
                return;
            }

            if (CanAccessHostControl)
            {
                // If there is an event info for this name
                EventInfo objEventInfo = GetEventInfo(strName);
                if (objEventInfo != null)
                {
                    // Get event handlers list if there is one
                    List<Delegate> objEventHandlers = GetEventHandlers(strName, false);
                    if (objEventHandlers != null)
                    {
                        // If the event handler is contained in the list
                        if (objEventHandlers.Contains(objEventHandler))
                        {
                            // Remove event handler
                            objEventHandlers.Remove(objEventHandler);
                        }
                    }
                }
            }
            else
            {
                // Here we will put the handler in a design time event handles dictionary.
                Dictionary<string, List<Delegate>> objDesignTimeEventHandlers = this.DesignTimeEventHandlers;
                if (objDesignTimeEventHandlers == null) { return; }

                List<Delegate> objEventHandlers;
                if (!objDesignTimeEventHandlers.TryGetValue(strName, out objEventHandlers)) { return; }

                objEventHandlers.Remove(objEventHandler);
            }
        }

        /// <summary>
        /// Gets the event handlers for a given event.
        /// </summary>
        /// <param name="strName">Name of the STR.</param>
        /// <returns></returns>
        private List<Delegate> GetEventHandlers(string strName)
        {
            return GetEventHandlers(strName, false);
        }

        /// <summary>
        /// Gets the event handlers for a given event.
        /// </summary>
        /// <param name="strName">Name of the STR.</param>
        /// <param name="blnCreate">if set to <c>true</c> [BLN create].</param>
        /// <returns></returns>
        private List<Delegate> GetEventHandlers(string strName, bool blnCreate)
        {
            // Event handler delegate list
            List<Delegate> objEventHandlers = null;
            Dictionary<string, List<Delegate>> objEventHandlersList = this.EventHandlers;
            // If there is a valid delegate list
            if (objEventHandlersList.ContainsKey(strName))
            {
                // If the event handlers list is valid
                if (objEventHandlersList[strName] != null)
                {
                    // Get event handler list
                    objEventHandlers = objEventHandlersList[strName] as List<Delegate>;
                }
            }

            // If there is no valid event handler list
            if (objEventHandlers == null)
            {
                // If event handler list should be created
                if (blnCreate)
                {
                    // Create a new delegate list and add it to the event handle list collection
                    objEventHandlers = new List<Delegate>();
                    objEventHandlersList.Add(strName, objEventHandlers);
                }
            }

            return objEventHandlers;
        }

        /// <summary>
        /// Recieve system.web type name (Without assembly) and return its type.
        /// </summary>
        private Type GetSystemWebFullTypeName(string typeName)
        {
            string strFullTypeName = typeName + ", " + CommonUtils.GetFullAssemblyName("System.Web");
            Type objType = Type.GetType(strFullTypeName);
            return objType;
        }

        #endregion

        #region Metadata Related


        /// <summary>
        /// Gets the property default value.
        /// </summary>
        /// <param name="objPropertyInfo">The property info.</param>
        /// <returns></returns>
        private object GetPropertyDefaultValue(PropertyInfo objPropertyInfo)
        {
            object objValue = null;

            // Get property type
            Type objPropertyType = objPropertyInfo.PropertyType;

            // Get the default attribute
            object[] arrDefaultAttributes = new object[0];
            while (arrDefaultAttributes.Length == 0 && objPropertyInfo.ReflectedType.BaseType != null)
            {
                arrDefaultAttributes = objPropertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), true);
                if (objPropertyInfo.ReflectedType.BaseType.GetProperty(objPropertyInfo.Name) != null)
                {
                    objPropertyInfo = objPropertyInfo.ReflectedType.BaseType.GetProperty(objPropertyInfo.Name);
                }
                else
                {
                    break;
                }

            }
            if (arrDefaultAttributes.Length > 0 &&
                ((DefaultValueAttribute)arrDefaultAttributes[0]).Value != null  &&
                objPropertyInfo.PropertyType == ((DefaultValueAttribute)arrDefaultAttributes[0]).Value.GetType())
            {
                
                // Return the default value
                return ((DefaultValueAttribute)arrDefaultAttributes[0]).Value;             
            }
            else
            {
                objValue = CommonUtils.GetTypeDefaultValue(objPropertyType);
            }


            return objValue;
        }


        /// <summary>
        /// Get an event information object.
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        protected EventInfo GetEventInfo(string strName)
        {
            EventInfo objEventInfo = null;
            Dictionary<string, EventInfo> objEvents = this.EventsList;
            // If there is a cached event info
            if (objEvents.ContainsKey(strName))
            {
                // Get cached event info
                objEventInfo = objEvents[strName] as EventInfo;
            }

            // If no cached event info
            if (objEventInfo == null)
            {
                // Get property info
                objEvents[strName] = objEventInfo = this.HostedControlType.GetEvent(strName);
            }

            // Return property info
            return objEventInfo;
        }

        /// <summary>
        /// Get property info
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        protected PropertyInfo GetPropertyInfo(string strName)
        {
            PropertyInfo objPropertyInfo = null;

            Dictionary<string, PropertyInfo> objProperties = this.Properties;

            // If there is a cached property info
            if (objProperties.ContainsKey(strName))
            {
                // Get cached property info
                objPropertyInfo = objProperties[strName] as PropertyInfo;
            }
            else
            {
                // If no cached property info
                if (objPropertyInfo == null)
                {
                    // Get property info
                    objProperties[strName] = objPropertyInfo = this.HostedControlType.GetProperty(strName);
                }
            }

            // Return property info
            return objPropertyInfo;
        }

        #endregion

        #region State related

        /// <summary>
        /// Restores hosted control events
        /// </summary>
        private void RestoreControlDesignEvents(System.Web.UI.Control objHostedControl)
        {
            // If there is a valid hosted control
            if (objHostedControl != null)
            {
                if (CompatibilityMode != VersionCompatibilityMode.Version6)
                {
                    Dictionary<string, List<Delegate>> objDesignTimeEventHandlers = this.DesignTimeEventHandlers;

                    // If there are design time events, we will create the EventHandlers.
                    if (objDesignTimeEventHandlers != null)
                    {
                        string[] arrKeys = new string[objDesignTimeEventHandlers.Keys.Count];
                        objDesignTimeEventHandlers.Keys.CopyTo(arrKeys, 0);

                        //Loop all property values
                        foreach (string strPropertyName in arrKeys)
                        {
                            List<Delegate> objEventHandlers = objDesignTimeEventHandlers[strPropertyName];

                            foreach (Delegate objEventHandle in objEventHandlers)
                            {
                                AddEventHandler(strPropertyName, objEventHandle, objHostedControl);
                            }

                        }

                        // Clear design time properties
                        this.DesignTimeEventHandlers = null;
                    }

                }

                // Add the event handlers to the EventsList of the AspControl.
                Dictionary<string, EventInfo> objEvents = this.EventsList;

                // Loop all event infos
                foreach (EventInfo objEventInfo in objEvents.Values)
                {
                    // If there is an event handler shadow list
                    List<Delegate> objEventHandlers = GetEventHandlers(objEventInfo.Name, false);
                    if (objEventHandlers != null)
                    {
                        // Loop all delegates
                        foreach (Delegate objEventHandler in objEventHandlers)
                        {
                            // Add an event handler to the current event info.
                            objEventInfo.AddEventHandler(objHostedControl, objEventHandler);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Restores hosted control properties
        /// </summary>
        private void TryRestoreControlDesignProperties(System.Web.UI.Control objHostedControl)
        {
            // If there is a valid hosted control
            if (objHostedControl != null)
            {
                Dictionary<string, object> objDesignTimeProperties = this.DesignTimeProperties;
                // If there are design time properties
                if (objDesignTimeProperties != null)
                {
                    string[] arrKeys = new string[objDesignTimeProperties.Keys.Count];
                    objDesignTimeProperties.Keys.CopyTo(arrKeys, 0);

                    //Loop all property values
                    foreach (string strPropertyName in arrKeys)
                    {
                        // Set the propety
                        SetProperty(strPropertyName, objDesignTimeProperties[strPropertyName]);
                    }

                    // Clear design time properties
                    this.DesignTimeProperties = null;
                }
            }
        }

        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderSyncChangesOnVwgPostBack(objWriter, false);
        }

        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                RenderSyncChangesOnVwgPostBack(objWriter, true);
            }
        }

        private void RenderSyncChangesOnVwgPostBack(IAttributeWriter objWriter, bool blnForce)
        {
            if (CompatibilityMode == VersionCompatibilityMode.Version6)
            {
                objWriter.WriteAttributeString(WGAttributes.SyncChangesOnVwgPostBack, "0");
                return;
            }

            if (SyncChangesOnVwgPostBack != SyncPostDataChangesMode.None)
            {
                string strSyncChangesOnVwgPostBack = SyncChangesOnVwgPostBack == SyncPostDataChangesMode.On ? "1" : "0";
                objWriter.WriteAttributeString(WGAttributes.SyncChangesOnVwgPostBack, strSyncChangesOnVwgPostBack);
            }
            else if (blnForce)
            {
                objWriter.WriteAttributeString(WGAttributes.SyncChangesOnVwgPostBack, "");
            }
        }

        public void AspUpdate()
        {
            if (CompatibilityMode == VersionCompatibilityMode.Version6) { return; }

            // Asp update will only be executed in vwg reqeust. 
            // (In asp all the control will be updated automatically)
            if (IsAspRequest) { return; }
            if (IsFirstVwgRequest) { return; }

            mblnAspUpdate = true;
        }

        /// <summary>
        /// Gets or sets the hosted control, that will be saved when in the vwg request there is AspUpdate,
        /// this AspUpdateHostedControl will be set instead of the HostedControl created in the AspRequest in the LoadCompleted stage.
        /// </summary>
        private WebUI.Control HostedControlForAspUpdate
        {
            get
            {
                return mobjHostedControlForAspUpdate;
            }
            set
            {
                mobjHostedControlForAspUpdate = value;
            }
        }

        /// <summary>
        /// An abstract control method rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            base.Render(objContext, objWriter, lngRequestID);

            if (CompatibilityMode == VersionCompatibilityMode.Version6)
            {
                Version6Render(objContext, objWriter, lngRequestID);
                return;
            }
        }

        protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
        {
            base.PreRenderControl(objContext, lngRequestID);

            // Handle AspUpdate.
            // NOTE (IMPORTANT): The easiest way to solve update was just to call AspControl.Submit and thats it, but it does not work,
            // because in this case in vwg the Update would change the ViewState of the control, and the Asp submit would have come with
            // invalid view state to the server.
            // so in order to solve this, we do as follows:
            // VwgRequest (Perform ProcessMainStart -> Update to the AspControl -> Save the AspControl in AspUpdateHostedControl memeber 
            // -> DO NOT perform ProcessMainEnd to not save the Save -> Register client script that will perform Submit on the AspControl
            // AspRequest - Submit (Because the state was not saved in the VwgRequest it starts from "zero" and performs
            // ProcessRequest -> In the LoadComplete event (Where the ProcessMainStart ends) we set the AspUpdateHostedControl instead of the
            // original HostedControl and this way we pass all the updated properties from to the HostedControl.
            if (mblnAspUpdate)
            {
                // Invoke client script that will perform submit in the asp control iframe so the asp control will be updated.
                VWGClientContext.Current.Invoke(this, "AspControlBoxBase_UpdateAspControl", ID);

                // Save the HostedControl, that contains all the updated properties (updated by the user in the VwgRequest)
                HostedControlForAspUpdate = HostedControl;

                // NOTE: Here we do not perform ProcessMainEnd because we dont want to save the state of the control here,
                // we want that the AspControl.Submit will start with the original state and we will update the updated properties of the
                // WrapControl in the Load.
                mblnProcessMainEndRequired = false;
            }
            else if (mblnProcessMainEndRequired)
            {
                HostedPage.ProcessMainEnd();
                mblnProcessMainEndRequired = false;
            }

            // NOTE: Here we delete the HostedPage. Except that it is more "ASP like" behavior because ASP creates the page each request,
            // it is neccessary for example in the ReportViewer.
            // The ReportViewer inits PreRender sets a member that locks the reports and does not allow to change it.
            // so if we will not set the HostedPage to null here, the VWG request will do PreRender and lock the reports, and then in the AspRequest
            // the reports will be locked before the PreRender.
            // NOTE2: We do not want to reset the HostedPage iin AspRequest, because it needs to use it. the ProcessGateway request will reset it.
            if (!IsAspRequest)
            {
                HostedPage = null;
            }

            mblnAspUpdate = false;
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the last sync post data.
        /// </summary>
        private NameValueCollection SyncPostData
        {
            get
            {
                return this.GetValue<NameValueCollection>(AspControlBoxBase.SyncPostDataProperty, null);
            }
            set
            {
                this.SetValue<NameValueCollection>(AspControlBoxBase.SyncPostDataProperty, value);
            }
        }

        /// <summary>
        /// Gets and sets a value indicating whether to synchronize changes of input fields of the asp control in vwg raise events.
        /// In case the value is null, it will synchornize changes only if there are input fields in the control.
        /// </summary>
        [System.ComponentModel.DefaultValue(SyncPostDataChangesMode.None)]
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Synchronize changes of input fields of the asp control in vwg raise events. In case the value is null, it will synchornize changes only if there are input fields in the control.")]
        public virtual SyncPostDataChangesMode SyncChangesOnVwgPostBack
        {
            get
            {
                return this.GetValue<SyncPostDataChangesMode>(AspControlBoxBase.SyncChangesOnVwgPostBackProperty, SyncPostDataChangesMode.None);
            }
            set
            {
                if (this.SetValue<SyncPostDataChangesMode>(AspControlBoxBase.SyncChangesOnVwgPostBackProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets and sets a  
        /// </summary>
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Urls to scripts js that will be registered in the asp page.")]
        public string[] Scripts
        {
            get
            {
                string[] objScripts = this.GetValue<string[]>(AspControlBoxBase.ScriptsProperty);
                if (objScripts == null)
                {
                    objScripts = new string[0];
                    Scripts = objScripts;
                }

                return objScripts;
            }
            set
            {
                if (this.SetValue<string[]>(AspControlBoxBase.ScriptsProperty, value))
                {
                    AspUpdate();
                }                
            }
        }

        private bool ShouldSerializeScripts()
        {
            if (Scripts.Length == 0) { return false; }
            return true;
        }

        /// <summary>
        /// Gets and sets a  
        /// </summary>
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Urls to styles js that will be registered in the asp page.")]
        public string[] Styles
        {
            get
            {
                string[] objStyles = this.GetValue<string[]>(AspControlBoxBase.StylesProperty);
                if (objStyles == null)
                {
                    objStyles = new string[0];
                    Styles = objStyles;
                }

                return objStyles;
            }
            set
            {
                if (this.SetValue<string[]>(AspControlBoxBase.StylesProperty, value))
                {
                    AspUpdate();
                }
            }
        }

        private bool ShouldSerializeStyles()
        {
            if (Styles.Length == 0) { return false; }
            return true;
        }

        /// <summary>
        /// Gets or sets the control ID, which indicates the id of the hosted control with in the control code.
        /// </summary>
        /// <value>The control ID.</value>
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("The control ID of the hosted control in the markup code.")]
        [System.ComponentModel.DefaultValue("hosted_control_id")]
        public string ControlID
        {
            get
            {
                //Get The value from the property store.
               return this.GetValue<string>(AspControlBoxBase.ControlIDProperty, "hosted_control_id");                              
            }
            set
            {
                // If the control code has changed
                if (ControlID != value)
                {
                    if (string.IsNullOrEmpty(value) || value == "hosted_control_id")
                    {
                        //Remove from the property store
                        this.RemoveValue<string>(AspControlBoxBase.ControlIDProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<string>(AspControlBoxBase.ControlIDProperty, value);
                    }
                }
            }
        }

        /// <summary>Gets or sets the control code.</summary>
        /// <value>The control code.</value>
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
#if WG_NET46
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Provides a way to initialize the control using ASP.NET markup.")]
        public string ControlCode
        {
            get
            {
                string strControlCode = this.GetValue<string>(AspControlBoxBase.ControlCodeProperty, string.Empty);

                // If the control code has not been set
                if (string.IsNullOrEmpty(strControlCode))
                {
                    // Set code varialbes
                    string strTagPrefix = "ctrl";
                    string strAssemblyName = this.HostedControlType.Assembly.FullName;
                    string strNamespace = this.HostedControlType.Namespace;
                    string strType = this.HostedControlType.Name;

                    // Build default code
                    StringBuilder objCode = new StringBuilder();
                    objCode.Append("<%@ Control Language=\"C#\"%>");
                    objCode.AppendLine();
                    objCode.AppendFormat("<%@ Register TagPrefix=\"{0}\" Assembly=\"{1}\" Namespace=\"{2}\" %>", strTagPrefix, strAssemblyName, strNamespace);
                    objCode.AppendLine();
                    objCode.AppendFormat("<{0}:{1} ID=\"{2}\" runat=\"server\" />", strTagPrefix, strType, this.ControlID);
                    objCode.AppendLine();

                    // Set the current code to the default code
                    strControlCode = objCode.ToString();
                }

                // Return the control code
                return strControlCode;
            }
            set
            {
                // If the control code has changed
                if (ControlCode != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        //Remove from the property store
                        this.RemoveValue<string>(AspControlBoxBase.ControlCodeProperty);
                    }
                    else
                    {                        
                        //Set the value in the property store
                        this.SetValue<string>(AspControlBoxBase.ControlCodeProperty, value);

                        // Invalidate the instrict code time
                        ControlCodeType = null;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the type of the control container.
        /// </summary>
        /// <value>The type of the control container.</value>
        private Type ControlCodeType
        {
            get
            {
                Type obControlCodeType = this.GetValue<Type>(AspControlBoxBase.ControlCodeTypeProperty, null);

                // If the control code type was not already built
                if (obControlCodeType == null)
                {
                    // Cannot use ResourceProvider which is a VirtualPathProvider in design mode
                    if (!this.DesignModeExtended)
                    {
                        // Get the control code
                        string strControlCode = this.ControlCode;

                        // If the control code is actual code
                        if (strControlCode.IndexOf("<%@") > -1)
                        {
                            // Compile the code to an ASPNET type
                            obControlCodeType = ResourceProvider.GetCompiledType(this.ControlCode);
                        }
                        else
                        {
                            // Compile the code from a Virtual Path
                            obControlCodeType = ResourceProvider.GetVirtualPathType(strControlCode);
                        }

                        this.SetValue<Type>(AspControlBoxBase.ControlCodeTypeProperty, obControlCodeType);
                    }
                }
                return obControlCodeType;
            }
            set
            {
                //If the value changed
                if (this.ControlCodeType != value)
                {
                    //If the value was set to default
                    if (value == null)
                    {
                        //Remove from the property store
                        this.RemoveValue<Type>(AspControlBoxBase.ControlCodeTypeProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<Type>(AspControlBoxBase.ControlCodeTypeProperty, value);
                    }
                }
            }
            
        }

        private bool DesignModeExtended
        {
            get
            {
                return this.DesignMode || HostContext.Current == null;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value>true if the container enables auto-scrolling; otherwise, false. The default value is true.</value>
        [SRCategory("CatLayout"), SRDescription("FormAutoScrollDescr"), DefaultValue(true)]
        public virtual bool AutoScroll
        {
             get
            {
                //Ge the value from the Property store
                return this.GetValue<bool>(AspControlBoxBase.AutoScrollProperty, true);
            }
            set
            {
                //If the value changed
                if (this.AutoScroll != value)
                {
                    //If the value was set to default
                    if (value == true)
                    {
                        //Remove from the property store
                        this.RemoveValue<bool>(AspControlBoxBase.AutoScrollProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<bool>(AspControlBoxBase.AutoScrollProperty, value);
                    }
                    this.UpdateParams(AttributeType.Visual);
                }
            }            
        }

        /// <summary>
        /// Gets or sets a value that specifies the wrap control behavior.
        /// </summary>
        protected internal virtual VersionCompatibilityMode CompatibilityMode
        {
            get
            {
                return VersionCompatibilityMode.Version6;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is ASP request.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this is ASP request; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.Browsable(false)]
        public bool IsAspRequest
        {
            get
            {
                //Get the value in the property store
                return this.GetValue<bool>(AspControlBoxBase.IsAspRequestProperty, false);
            }
            private set
            {
                //If the value changed
                if (this.IsAspRequest != value)
                {
                    //If the value was set to default
                    if (value == false)
                    {
                        //Remove from the property store
                        this.RemoveValue<bool>(AspControlBoxBase.IsAspRequestProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<bool>(AspControlBoxBase.IsAspRequestProperty, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the hosted control accessing is allowed.
        /// </summary>
        private bool CanAccessHostControl
        {
            get
            {
                if (CompatibilityMode == VersionCompatibilityMode.Version6)
                {
                    return Version6CanAccessHostControl;
                }

                // NOTE: Accept from design mode that does not allow to access the host control, 
                // When setting a value to the host control, we will not allow to access the host control 
                // ig it does not have parent. This is made to avoid creation of the host control in Initialization.
                // (Example: InitializeComponent). It is needed because on host control creation all of its events are raised
                // and if we did not subscribe to an event yet, it will not be called.
                // NOTE2: In GetProperty we need this check although in intialization we only to SetProperty, for compaund object.
                // Example: TreeView.Nodes[0].Text - In this case the GetProperty for Nodes will be called.
                if (this.InDesignMode || !this.IsCodeControlValid || IsFirstVwgRequest)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether we are in the first vwg request. (ProcessGateway was not called yet.
        /// </summary>
        internal bool IsFirstVwgRequest
        {
            get
            {
                // If we are not in asp request and the view state is null, it means we are in the first vwg request.

                object objViewState = GetViewStateInternal();
                if (!IsAspRequest && objViewState == null) { return true; }

                return false;
            }
        }

        /// <summary>
        /// Get the currently hosted control
        /// </summary>
        protected System.Web.UI.Control HostedControl
        {
            get
            {
                if (CompatibilityMode == VersionCompatibilityMode.Version6)
                {
                    return Version6HostedControl;
                }

                // Make sure the control is not created in desing mode
                if (this.InDesignMode)
                {
                    // We should not interact with the control in design mode
                    throw new Exception("Hosted control can not be used in design mode.");
                }

                // If hosted page was not created already
                if (HostedPage == null)
                {
                    // Create the hosted page that hosts the control
                    HostedPage = CreateHostPage();

                    // If initialized from a Visual WebGui request
                    if (!IsAspRequest)
                    {
                        //If the hosted page was created store it in the property store

                        HostedPage.ProcessMainStart();
                    }
                }

                // Return back the hosted control from the hosted page
                return HostedPage.HostedControl;
            }
        }

        /// <summary>
        /// The hosted ASP.NET control type
        /// </summary>
        protected virtual Type HostedControlType
        {
            get
            {
                return typeof(System.Web.UI.Control);
            }
        }

        /// <summary>
        /// Gets the name of the form.
        /// </summary>
        /// <value>The name of the form.</value>
        private string FormName
        {
            get
            {
                return string.Format("ctrl1_{0}", this.Name);
            }
        }

        /// <summary>
        /// Gets the name of the script manager.
        /// </summary>
        /// <value>The name of the script manager.</value>
        private string ScriptManagerName
        {
            get
            {
                return string.Format("ctrl0_{0}", this.Name);
            }
        }

        /// <summary>
        /// Gets the control properties.
        /// </summary>
        /// <value>The control properties.</value>
        private Dictionary<string, PropertyInfo> Properties
        {
            get
            {
                //Get the value from the property store
                return this.GetValue<Dictionary<string, PropertyInfo>>(AspControlBoxBase.PropertiesProperty, null);
            }
            set
            {
                //If the value changed
                if (this.Properties != value)
                {
                    //If the value was set to default
                    if (value == null)
                    {
                        //Remove from the property store
                        this.RemoveValue<Dictionary<string, PropertyInfo>>(AspControlBoxBase.PropertiesProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<Dictionary<string, PropertyInfo>>(AspControlBoxBase.PropertiesProperty, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the design time properties.
        /// </summary>
        /// <value>The design time properties.</value>
        private Dictionary<string, object> DesignTimeProperties
        {
            get
            {
                //Gets the value from the property store
                return this.GetValue<Dictionary<string, object>>(AspControlBoxBase.DesignTimePropertiesProperty, null);
            }
            set
            {
                //If a change was made
                if (this.DesignTimeProperties != value)
                {
                    //If set to default
                    if (value == null)
                    {
                        //Remove the value from the proprty store
                        this.RemoveValue<Dictionary<string, object>>(AspControlBoxBase.DesignTimePropertiesProperty);
                    }
                    else
                    {
                        //Set the value in the property store.
                        this.SetValue<Dictionary<string, object>>(AspControlBoxBase.DesignTimePropertiesProperty, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the design time events.
        /// </summary>
        /// <value>The design time events.</value>
        private Dictionary<string, List<Delegate>> DesignTimeEventHandlers
        {
            get
            {
                //Gets the value from the property store
                return this.GetValue<Dictionary<string, List<Delegate>>>(AspControlBoxBase.DesignTimeEventHandlersProperty, null);
            }
            set
            {
                //If a change was made
                if (this.DesignTimeEventHandlers != value)
                {
                    //Set the value in the property store.
                    this.SetValue<Dictionary<string, List<Delegate>>>(AspControlBoxBase.DesignTimeEventHandlersProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the default design values.
        /// </summary>
        /// <value>The default design values.</value>
        private Dictionary<string, object> DefaultDesignValues
        {
            get
            {
                //Get the value from the Property store
                return this.GetValue<Dictionary<string, object>>(AspControlBoxBase.DefaultDesignValuesProperty, null);
            }
            set
            {
                //A change was made
                if (DefaultDesignValues != value)
                {
                    //If the value was set to default
                    if (value == null)
                    {
                        //Remove the value from the property store
                        this.RemoveValue<Dictionary<string, object>>(AspControlBoxBase.DefaultDesignValuesProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<Dictionary<string, object>>(AspControlBoxBase.DefaultDesignValuesProperty, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        private Dictionary<string, EventInfo> EventsList
        {
            get
            {
                //Get the value from the property store
                return this.GetValue<Dictionary<string, EventInfo>>(AspControlBoxBase.EventsProperty, null);
            }
            set
            {
                //If the value changed
                if (this.EventsList != value)
                {
                    //If the value was set to default
                    if (value == null)
                    {
                        //Remove from the property store
                        this.RemoveValue<Dictionary<string, EventInfo>>(AspControlBoxBase.EventsProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<Dictionary<string, EventInfo>>(AspControlBoxBase.EventsProperty, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>The events.</value>
        protected Dictionary<string, List<Delegate>> Events
        {
            get
            {
                return this.EventHandlers;
            }
        }

        /// <summary>
        /// Gets or sets the event handlers.
        /// </summary>
        /// <value>The event handlers.</value>
        private Dictionary<string, List<Delegate>> EventHandlers
        {
            get
            {
                //Get the value from the Property store
                return this.GetValue<Dictionary<string, List<Delegate>>>(AspControlBoxBase.EventHandlersProperty, null);
            }
            set
            {
                //If the value changed
                if (this.EventHandlers != value)
                {
                    //Set the value in the property store
                    this.SetValue<Dictionary<string, List<Delegate>>>(AspControlBoxBase.EventHandlersProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the hosted page.
        /// </summary>
        /// <value>The hosted page.</value>
        private AspPipeLinePage HostedPage
        {
            get
            {
                if (CompatibilityMode == VersionCompatibilityMode.Version6) { return Version6HostedPage; }

                return mobjHostedPage;
            }
            set
            {
                if (CompatibilityMode == VersionCompatibilityMode.Version6)
                {
                    Version6HostedPage = value;
                    return;
                }

                mobjHostedPage = value;
            }
        }

        /// <summary>
        /// Gets or sets the state of the view.
        /// </summary>
        /// <value>The state of the view.</value>
        private object ViewState
        {
            get
            {
                //Get the value from the property store
                return this.GetValue<object>(AspControlBoxBase.ViewStateProperty, null);
            }
            set
            {
                //If the value changed
                if (this.ViewState != value)
                {
                    //If the value was set to default
                    if (value == null)
                    {
                        //Remove from the property store
                        this.RemoveValue<object>(AspControlBoxBase.ViewStateProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<object>(AspControlBoxBase.ViewStateProperty, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the state of the control.
        /// </summary>
        /// <value>The state of the control.</value>
        private object ControlState
        {
            get
            {
                //Get the value from the property store
                return this.GetValue<object>(AspControlBoxBase.ControlStateProperty, null);
            }
            set
            {
                //If the value changed
                if (this.ControlState != value)
                {
                    //If the value was set to default
                    if (value == null)
                    {
                        //Remove from the property store
                        this.RemoveValue<object>(AspControlBoxBase.ControlStateProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<object>(AspControlBoxBase.ControlStateProperty, value);
                    }
                }
            }
        }

        #endregion

        #region Legacy code

        private void Version6AddEventHandler(string strName, Delegate objEventHandler)
        {
            // If there is an event info for this name
            EventInfo objEventInfo = GetEventInfo(strName);
            if (objEventInfo != null)
            {
                // Get the event info's event handlers sorted list.
                List<Delegate> objEventHandlers = GetEventHandlers(strName, true);
                if (objEventHandlers != null)
                {
                    // Store the event handler
                    objEventHandlers.Add(objEventHandler);
                }

                // We should not interact with the control in design mode
                if (!this.InDesignMode)
                {
                    // If there is a live hosted control
                    if (this.HostedControl != null)
                    {
                        // Ad an event handler.
                        objEventInfo.AddEventHandler(this.HostedControl, objEventHandler);
                    }
                }
            }
        }

        protected void Version6RemoveEventHandler(string strName, Delegate objEventHandler)
        {
            // If there is an event info for this name
            EventInfo objEventInfo = GetEventInfo(strName);
            if (objEventInfo != null)
            {
                // Get event handlers list if there is one
                List<Delegate> objEventHandlers = GetEventHandlers(strName, false);
                if (objEventHandlers != null)
                {
                    // If the event handler is contained in the list
                    if (objEventHandlers.Contains(objEventHandler))
                    {
                        // Remove event handler
                        objEventHandlers.Remove(objEventHandler);
                    }
                }

                // We should not interact with the control in design mode
                if (!this.InDesignMode)
                {
                    // Removes the event's handler.
                    objEventInfo.RemoveEventHandler(this.HostedControl, objEventHandler);
                }
            }
        }

        private void Version6Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            AspPipeLinePage objHostedPage = this.HostedPage;

            if (objHostedPage != null && !this.IsAspRequest)
            {
                objHostedPage.ProcessMainEnd();
                this.HostedPage = null;
            }
        }

        private bool Version6CanAccessHostControl
        {
            get
            {
                if (this.InDesignMode || !this.IsCodeControlValid || !this.IsParentValid) { return false; }
                return true;
            }
        }

        private System.Web.UI.Control Version6HostedControl
        {
            get
            {
                // Make sure the control is not created in desing mode
                if (this.InDesignMode)
                {
                    // We should not interact with the control in design mode
                    throw new Exception("Hosted control can not be used in design mode.");
                }
                AspPipeLinePage objHostedPage = this.HostedPage;
                // If hosted page was not created already
                if (objHostedPage == null)
                {
                    // Create the hosted page that hosts the control
                    objHostedPage = CreateHostPage();

                    // If initialized from a Visual WebGui request
                    if (!this.IsAspRequest && !this.InDesignMode)
                    {
                        // If there is avalid hosted page
                        if (objHostedPage != null)
                        {
                            //If the hosted page was created store it in the property store
                            this.HostedPage = objHostedPage;

                            objHostedPage.ProcessMainStart();
                        }
                    }
                }

                // Return back the hosted control from the hosted page
                return objHostedPage.HostedControl;
            }
        }

        /// <summary>
        /// Gets or sets the hosted page.
        /// </summary>
        /// <value>The hosted page.</value>
        private AspPipeLinePage Version6HostedPage
        {
            get
            {
                //Get the value from the property store
                return this.GetValue<AspPipeLinePage>(AspControlBoxBase.AspPipeLinePageProperty, null);
            }
            set
            {
                //If the value changed
                if (this.Version6HostedPage != value)
                {
                    //If the value was set to default
                    if (value == null)
                    {
                        //Remove from the property store
                        this.RemoveValue<AspPipeLinePage>(AspControlBoxBase.AspPipeLinePageProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<AspPipeLinePage>(AspControlBoxBase.AspPipeLinePageProperty, value);
                    }
                }
            }
        }

        #endregion
    }
}
