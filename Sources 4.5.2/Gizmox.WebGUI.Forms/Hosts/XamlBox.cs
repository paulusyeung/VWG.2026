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
using Gizmox.WebGUI.Forms.Hosts.Skins;



#endregion

namespace Gizmox.WebGUI.Forms.Hosts
{

	#region Enums

	/// <summary>
	/// The silverlight content type
	/// </summary>
    
	public enum XamlBoxType
	{
        /// <summary>
        /// XAML file
        /// </summary>
		XAML,
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

    #region XamlBox Class

    /// <summary>
	/// A html control
	/// </summary>
	[System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(XamlBox), "XamlBox_45.png")]
#else
    [ToolboxBitmapAttribute(typeof(XamlBox), "XamlBox.bmp")]
#endif
    [ToolboxItemCategory("Host Controls")]
    [Serializable()]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(XamlBoxSkin))]
    public class XamlBox : ObjectBox
	{

        #region Classes

        /// <summary>
        /// Xaml gateway handler
        /// </summary>

        [Serializable()]
    public class XamlGateway : GatewayWriter
        {
            private XamlBox mobjXamlBox;

            /// <summary>
            /// Initializes a new instance of the <see cref="XamlGateway"/> class.
            /// </summary>
            /// <param name="objXamlBox">The obj xaml box.</param>
            public XamlGateway(XamlBox objXamlBox)
            {
                mobjXamlBox = objXamlBox;
            }

            /// <summary>
            /// Processes the request.
            /// </summary>
            protected override void ProcessRequest()
            {
                if (mobjXamlBox != null)
                {
                    if (mobjXamlBox.Type == XamlBoxType.XAML)
                    {
                        if(mobjXamlBox.Xaml!=string.Empty)
                        {
                            Write(mobjXamlBox.Xaml);
                        }
                        else
                        {
                            Write("<Canvas xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" Height=\"500\" Width=\"500\"></Canvas>");
                        }
                    }
                    else
                    {
                        WriteFile(mobjXamlBox.Path);
                    }
                    this.ContentType = "text/xml";
                }
            }
        }

        #endregion 

		#region Class Members

      
        private string mstrXaml = string.Empty;
        private string mstrUrl;
        private XamlBoxType menmType = XamlBoxType.XAML;
        private XamlBox.XamlGateway mobjGateway = null;
        private ResourceHandle mobjResourceHandle = null;

		#endregion
		
		#region C'Tor/D'Tor
		
		/// <summary>
		/// Creates a new <see cref="HtmlBox"/> instance.
		/// </summary>
        public XamlBox()
		{
			// Set the default size
			this.Size = new System.Drawing.Size(200,200);
            this.ObjectType = "application/x-silverlight-2";
            this.ObjectData = "data:application/x-silverlight-2,";
		}
		
		#endregion
		
		#region Methods

        /// <summary>
        /// Resets the resource.
        /// </summary>
        private void ResetResource()
        {
            this.Resource = null;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public override void Update()
        {
            base.Update();
            FireObservableItemPropertyChanged("Content");
        }

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the Xaml code of the control.
		/// </summary>
		/// <value></value>
        [DefaultValue("")]
		public string Xaml
		{
            get
            {
                return Type == XamlBoxType.XAML ? mstrXaml : "";
            }
            set
            {
                menmType = XamlBoxType.XAML;
                mstrXaml = value;
                mstrUrl = "";
                FireObservableItemPropertyChanged("Content");
            }
		}

        /// <summary>
        /// Gets or sets a flag indicating if the Xaml control should be windowless.
        /// </summary>
        [DefaultValue(true)]
        public bool Windowless
        {
            get
            {
                if (this.Parameters.Contains("windowless"))
                {
                    return bool.Parse(this.Parameters["windowless"].ToString());
                }
                else
                {
                    return false;
                }
            }
            set
            {
                this.Parameters["windowless"] = value;
            }
        }

		/// <summary>
		/// Gets or sets the URL to the Xaml code.
		/// </summary>
		/// <value></value>
        [DefaultValue("")]
		public string Url
		{
            get
            {
                if (this.Parameters.Contains("source"))
                {
                    return this.Parameters["source"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                string strTempValue;
                
                // if the url is not a valid url 
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    //Add ~/ to the url if needed
                    if (!value.Contains("~/"))
                    {
                        strTempValue = "~/" + value;
                    }
                    else
                    {
                        strTempValue = value;
                    }

                    //set the url from the Url Resource Handle to the paramter
                   this.Parameters["source"] = new UrlResourceHandle(strTempValue).ToString();
                }
                else
                {
                    //set the url to the paramter
                    this.Parameters["source"] = value;
                }
            }
		}

		/// <summary>
		/// Gets or sets the path to the Xaml code.
		/// </summary>
		/// <value></value>
        [DefaultValue("")]
		public string Path
		{
            get
            {
                return Type == XamlBoxType.UNC ? mstrUrl : "";
            }
            set
            {
                menmType = XamlBoxType.UNC;
                mstrUrl = value;
                mstrXaml = "";
                FireObservableItemPropertyChanged("Content");
            }
		}

		/// <summary>
		/// Gets or sets a resource that contains Xaml.
		/// </summary>
		/// <value></value>
        [DefaultValue(null)]
		public ResourceHandle Resource
		{
			get
			{
                return Type == XamlBoxType.RESOURCE ? this.mobjResourceHandle : null;
			}
			set
			{
                menmType = XamlBoxType.RESOURCE;
				mobjResourceHandle  = value;
                mstrXaml = "";
                FireObservableItemPropertyChanged("Content");
			}
		}

		/// <summary>
		/// Gets the html box type.
		/// </summary>
		/// <value></value>    
		public XamlBoxType Type
		{
			get
			{
				return menmType;
			}
		}


		#endregion 

		#region IGatewayControl Members

        /// <summary>
        /// Gets the gateway handler.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="strAction">The STR action.</param>
        /// <returns></returns>
		public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
		{
			if(strAction=="Xaml")
			{
				return new XamlGateway(this);
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
