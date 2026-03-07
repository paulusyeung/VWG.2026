#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Runtime.Serialization;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;



#endregion

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// The html box content type
    /// </summary>

    [Serializable]
    public enum HtmlBoxType
    {
        /// <summary>
        /// HTML
        /// </summary>
        HTML,
        /// <summary>
        /// URL
        /// </summary>
        URL,
        /// <summary>
        /// UNC
        /// </summary>
        UNC,
        /// <summary>
        /// RESOURCE
        /// </summary>
        RESOURCE
    }

    #endregion

    #region HtmlBox Class

    /// <summary>
    /// A html control
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(HtmlBox), "HtmlBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(HtmlBox), "HtmlBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable]
    [ToolboxItemCategory("Common Controls")]
    [Skin(typeof(HtmlBoxSkin))]
    public class HtmlBox : FrameControl
    {


        /// <summary>
        /// Provides a property reference to GatewayReference property.
        /// </summary>
        private static SerializableProperty GatewayReferenceProperty = SerializableProperty.Register("GatewayReference", typeof(GatewayReference), typeof(HtmlBox));



        /// <summary>
        /// Provides a property reference to Expires property.
        /// </summary>
        private static SerializableProperty ExpiresProperty = SerializableProperty.Register("Expires", typeof(int), typeof(HtmlBox));



        /// <summary>
        /// Provides a property reference to ContentType property.
        /// </summary>
        private static SerializableProperty ContentTypeProperty = SerializableProperty.Register("ContentType", typeof(string), typeof(HtmlBox));



        /// <summary>
        /// Provides a property reference to Type property.
        /// </summary>
        private static SerializableProperty TypeProperty = SerializableProperty.Register("Type", typeof(HtmlBoxType), typeof(HtmlBox));



        /// <summary>
        /// Provides a property reference to ResourceHandle property.
        /// </summary>
        private static SerializableProperty ResourceHandleProperty = SerializableProperty.Register("ResourceHandle", typeof(ResourceHandle), typeof(HtmlBox));



        /// <summary>
        /// Provides a property reference to Path property.
        /// </summary>
        private static SerializableProperty PathProperty = SerializableProperty.Register("Path", typeof(string), typeof(HtmlBox));



        /// <summary>
        /// Provides a property reference to Url property.
        /// </summary>
        private static SerializableProperty UrlProperty = SerializableProperty.Register("Url", typeof(string), typeof(HtmlBox));



        /// <summary>
        /// Provides a property reference to Html property.
        /// </summary>
        private static SerializableProperty HtmlProperty = SerializableProperty.Register("Html", typeof(string), typeof(HtmlBox));

        /// <summary>
        /// Provides a property reference to IsWindowless property.
        /// </summary>
        private static SerializableProperty IsWindowlessProperty = SerializableProperty.Register("IsWindowless", typeof(bool), typeof(HtmlBox), new SerializablePropertyMetadata(false));


        #region Classes

        /// <summary>
        /// Html gateway handler
        /// </summary>

        [Serializable()]
        public class HtmlGateway : GatewayWriter
        {
            private HtmlBox mobjHtmlBox;

            /// <summary>
            /// Initializes a new instance of the <see cref="HtmlGateway"/> class.
            /// </summary>
            /// <param name="objHtmlBox">The obj HTML box.</param>
            public HtmlGateway(HtmlBox objHtmlBox)
            {
                mobjHtmlBox = objHtmlBox;
            }

            /// <summary>
            /// Processes the request.
            /// </summary>
            protected override void ProcessRequest()
            {
                if (mobjHtmlBox != null)
                {
                    if (mobjHtmlBox.Type == HtmlBoxType.HTML)
                    {
                        Write(mobjHtmlBox.Html);
                    }
                    else
                    {
                        WriteFile(mobjHtmlBox.Path);
                        ContentType = mobjHtmlBox.ContentType;
                    }
                }
            }
        }

        #endregion

        #region Class Members
        #endregion

        #region C'Tor/D'Tor

        /// <summary>
        /// Creates a new <see cref="HtmlBox"/> instance.
        /// </summary>
        public HtmlBox()
        {
            // Set the default size
            this.Size = new System.Drawing.Size(200, 200);

        }

        #endregion


        #region Methods


        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        protected override string Source
        {
            get
            {
                // If is windowless we return the actual html markup as source
                if (this.IsWindowless)
                {
                    return this.Html;
                }
                else
                {
                    // If is resource content type
                    if (Type == HtmlBoxType.RESOURCE)
                    {
                        // Get the resource  
                        ResourceHandle objResourceHandle = this.Resource;

                        // If there is a valid resource
                        if (objResourceHandle != null)
                        {
                            return objResourceHandle.ToString();
                        }
                    }
                    else
                    {
                        // If is html or unc type
                        if (Type == HtmlBoxType.UNC || Type == HtmlBoxType.HTML)
                        {
                            // Thry to get the gateway reference
                            GatewayReference objGatewayReference = this.GatewayReference;

                            // If there is no valid gateway reference
                            if (objGatewayReference == null)
                            {
                                // Create gateay reference
                                objGatewayReference = new GatewayReference(this, "Html");

                                // Store the gateway reference
                                this.GatewayReference = objGatewayReference;
                            }

                            // Return the gateway resource url
                            return objGatewayReference.ToString();
                        }
                        else
                        {
                            // Return the url back 
                            return this.Url;
                        }
                    }
                }

                // This should not happen
                return string.Empty;

            }
        }


        /// <summary>
        /// Prints this instance.
        /// </summary>
        public void Print()
        {
            this.InvokeMethod("FrameControl_Print", this.ID.ToString());
        }

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        public override void Update()
        {
            base.Update();

            FireObservableItemPropertyChanged("Content");
        }


        /// <summary>
        /// Resets the resource.
        /// </summary>
        private void ResetResource()
        {
            this.Resource = null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the HTML code of the control.
        /// </summary>
        /// <value></value>
        public virtual string Html
        {
            get
            {
                // Get the property from the property story                
                return Type == HtmlBoxType.HTML ? this.GetValue<string>(HtmlBox.HtmlProperty, "<HTML>No content.</HTML>") : string.Empty;
            }
            set
            {
                string strHtml = this.Html;
                if (strHtml != value)
                {
                    //If the new value is null or empty remove the property from the property store
                    if (string.IsNullOrEmpty(value))
                    {
                        // Remove the property from the property store
                        this.RemoveValue<string>(HtmlBox.HtmlProperty);
                    }
                    else
                    {
                        // Set the property value in the property story  
                        this.Type = HtmlBoxType.HTML;

                        // Set the property value in the property story  
                        this.SetValue<string>(HtmlBox.HtmlProperty, value);

                        // Remove the property from the property story  
                        this.RemoveValue<string>(HtmlBox.UrlProperty);
                        this.Update();
                        FireObservableItemPropertyChanged("Content");
                    }
                }
            }
        }

        /// <summary>
        /// Resets the HTML.
        /// </summary>
        private void ResetHtml()
        {
            this.Html = Type == HtmlBoxType.HTML ? "<HTML>No content.</HTML>" : string.Empty;
        }

        /// <summary>
        /// Gets or sets the value indicating if html should be rendered without an iframe.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is windowless; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool IsWindowless
        {
            get
            {
                return this.GetValue<bool>(HtmlBox.IsWindowlessProperty);
            }
            set
            {
                // Make sure we are in HTML mode
                if (value && this.Type!= HtmlBoxType.HTML)
                {
                    throw new ArgumentOutOfRangeException("HtmlBox must be in HTML mode to use windowless mode.");
                }

                // If the value of window less had changed
                if (this.SetValue<bool>(HtmlBox.IsWindowlessProperty, value))
                {
                    // Redraw the control
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Indicates if the framecontrol should render source as inline html of as a url for
        /// a frame.
        /// </summary>
        /// <value></value>
        protected override bool IsInline
        {
            get
            {
                return this.IsWindowless;
            }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value></value>
        [DefaultValue("")]
        public virtual string Url
        {
            get
            {
                // Get the property from the property story  
                return Type == HtmlBoxType.URL ? this.GetValue<string>(HtmlBox.UrlProperty, string.Empty) : string.Empty;
            }
            set
            {
                //If the new value is null or empty remove the property from the property store

                string strUrl = this.Url;
                // Get the property from the property story  
                HtmlBoxType objHtmlBoxType = Type;
                if (objHtmlBoxType != HtmlBoxType.URL ||
                    strUrl != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        // Remove the property from the property store
                        this.RemoveValue<string>(HtmlBox.UrlProperty);

                    }
                    else
                    {
                        // Set the Value in the property story  
                        this.Type = HtmlBoxType.URL;

                        // Set the Value in the property story  
                        this.SetValue(HtmlBox.UrlProperty, value);
                        strUrl = value;

                        // Remove the value from the property story  
                        this.RemoveValue<string>(HtmlBox.HtmlProperty);
                    }
                    FireObservableItemPropertyChanged("Content");
                    this.InvokeMethodWithId("FrameControl_SetUrl", strUrl);
                }
            }
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value></value>
        [DefaultValue("")]
        public virtual string Path
        {
            get
            {
                // Get the property from the property story      
                return Type == HtmlBoxType.UNC ? this.GetValue<string>(HtmlBox.PathProperty, string.Empty) : string.Empty;
            }
            set
            {

                {
                    string strPath = this.Path;
                    if (strPath != value)
                    {
                        //If the new value is null or empty remove the property from the property store
                        if (string.IsNullOrEmpty(value))
                        {
                            // Remove the property from the property store
                            this.RemoveValue<string>(HtmlBox.UrlProperty);
                        }
                        else
                        {
                            // Set the property value in the property story      
                            this.Type = HtmlBoxType.UNC;

                            // Set the property value in the property story      
                            this.SetValue<string>(HtmlBox.PathProperty, value);
                            this.SetValue<string>(HtmlBox.UrlProperty, value);
                            // Remove the property from the property story      
                            this.RemoveValue<string>(HtmlBox.HtmlProperty);
                        }
                        FireObservableItemPropertyChanged("Content");
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        /// <value></value>
        [DefaultValue(null)]
        public virtual ResourceHandle Resource
        {
            get
            {
                // Get the property from the property story      
                return Type == HtmlBoxType.RESOURCE ? this.GetValue<ResourceHandle>(HtmlBox.ResourceHandleProperty, null) : null;
            }
            set
            {
                if (this.Resource != value)
                {
                    //If the new value is null remove the property from the property store
                    if (value == null)
                    {
                        // Remove the property from the property store
                        this.RemoveValue<string>(HtmlBox.ResourceHandleProperty);
                    }
                    else
                    {
                        // Set the property value in the property story      
                        this.Type = HtmlBoxType.RESOURCE;

                        // Set the property value in the property story      
                        this.SetValue<ResourceHandle>(HtmlBox.ResourceHandleProperty, value);

                        // Remove the property from the property story      
                        this.RemoveValue<string>(HtmlBox.HtmlProperty);
                    }
                    FireObservableItemPropertyChanged("Content");
                }
            }
        }

        /// <summary>
        /// Gets the html box type.
        /// </summary>
        /// <value></value>
        public HtmlBoxType Type
        {
            get
            {
                // Get the property from the property story      
                return this.GetValue<HtmlBoxType>(HtmlBox.TypeProperty, HtmlBoxType.HTML); ;
            }
            internal set
            {

                if (this.Type != value)
                {
                    //If the new value is null or empty remove the property from the property store
                    if (value == HtmlBoxType.HTML)
                    {
                        // Remove the property from the property store
                        this.RemoveValue<HtmlBoxType>(HtmlBox.TypeProperty);
                    }
                    else
                    {
                        // Set the property value in the property story     
                        this.SetValue<HtmlBoxType>(HtmlBox.TypeProperty, value);
                    }
                }

            }
        }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        /// <value></value>
        public string ContentType
        {
            get
            {
                // Get the property from the property story     
                return this.GetValue<string>(HtmlBox.ContentTypeProperty, "text/html");
            }
            set
            {
                string strContentType = this.ContentType;
                if (strContentType != value)
                {
                    //If the new value is null or empty remove the property from the property store
                    if (string.IsNullOrEmpty(value))
                    {
                        // Remove the property from the property store
                        this.RemoveValue<string>(HtmlBox.ContentTypeProperty);
                    }
                    else
                    {
                        // Set the property value in the property story     
                        this.SetValue<string>(HtmlBox.ContentTypeProperty, value);
                    }
                }

            }
        }

        /// <summary>
        /// Gets or sets the expire time in secodns.
        /// </summary>
        /// <value></value>
        [DefaultValue(-1)]
        public int Expires
        {
            get
            {
                // Get the property from the property story     
                return this.GetValue<int>(HtmlBox.ExpiresProperty, -1);
            }
            set
            {

                if (this.Expires != value)
                {
                    //If the new value -1 remove the property from the property store
                    if (value == -1)
                    {
                        // Remove the property from the property store
                        this.RemoveValue<string>(HtmlBox.ExpiresProperty);
                    }
                    else
                    {
                        // Set the property value in the property story  
                        this.SetValue<int>(HtmlBox.ExpiresProperty, value);
                    }
                }
            }

        }

        /// <summary>
        /// Gets or sets the gateway reference.
        /// </summary>
        /// <value>The gateway reference.</value>
        private GatewayReference GatewayReference
        {
            get
            {
                //Get the value from the property store
                return this.GetValue<GatewayReference>(HtmlBox.GatewayReferenceProperty, null);
            }
            set
            {
                //If achange was made
                if (this.GatewayReference != value)
                {
                    //If the value was set to default
                    if (value == null)
                    {
                        //Remove valuefrom property store
                        this.RemoveValue<GatewayReference>(HtmlBox.GatewayReferenceProperty);
                    }
                    else
                    {
                        //Set the valu in the property store
                        this.SetValue<GatewayReference>(HtmlBox.GatewayReferenceProperty, value);
                    }
                }
            }
        }
        #endregion

        #region IGatewayControl Members

        /// <summary>
        /// Provides a way to handle gateway requests.
        /// </summary>
        /// <param name="objHostContext">The gateway request host context.</param>
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
        protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
        {
            if (strAction == "Html")
            {
                return new HtmlGateway(this);
            }
            else
            {
                return null;
            }
        }

        #endregion

    }

    #endregion


}
