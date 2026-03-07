using System;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using System.Configuration;
using System.Web.Configuration;
using System.Drawing;
using System.Collections.Specialized;

namespace Gizmox.WebGUI.Forms.Hosts
{

    /// <summary>
    /// FormBox
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(FormBox), "FormBox_45.png")]
#else
    [ToolboxBitmapAttribute(typeof(FormBox), "FormBox.bmp")]
#endif
#if WG_NET46
    [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]  
    [ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
    [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#endif
    [ToolboxData("<{0}:FormBox runat=server></{0}:FormBox>"), Serializable()]

    public class FormBox : System.Web.UI.WebControls.WebControl
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ApplicationUITypes : byte
        {
            /// <summary>
            /// 
            /// </summary>
            DHTML = 0
        }

        /// <summary>
        /// 
        /// </summary>

        private string mstrInstance = "";

        private IRouter mobjRouter = null;

        private bool mblnStateless = false;

        /// <summary>
        /// Holds the setting by which this control either opens a form as a DHTML
        /// </summary>
        private ApplicationUITypes menmApplicationUiType = ApplicationUITypes.DHTML;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormBox"/> class.
        /// </summary>
        public FormBox():base("IFRAME")
        {
        }


        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified <see cref="T:System.Web.UI.HtmlTextWriterTag"/>. This method is used primarily by control developers.
        /// </summary>
        /// <param name="objWriter">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        protected override void AddAttributesToRender(HtmlTextWriter objWriter)
        {

            if (!string.IsNullOrEmpty(this.Form))
            {
                string strArguments = this.GetArguments();
                if (!strArguments.ToLower().Contains("&vwginstance="))
                    strArguments = string.Format("{0}&vwginstance={1}", strArguments, this.Instance);
                if (!strArguments.ToLower().Contains("&vwgstateless="))
                    strArguments = string.Format("{0}&vwgstateless={1}", strArguments, mblnStateless ? "1" : "0");
                if (strArguments.StartsWith("&"))
                    strArguments = strArguments.Substring(1);

                objWriter.AddAttribute("src", this.ResolveClientUrl(string.Format("~/{0}{1}?{2}", this.Form, this.TypeExtension, strArguments)));
            }

            objWriter.AddAttribute("allowtransparency", "yes");
            objWriter.AddAttribute("frameborder", "no");


            base.AddAttributesToRender(objWriter);
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns></returns>
        private string GetArguments()
        {
            string strArguments = string.Empty;

            // Get form's arguments.
            NameValueCollection objArguments = this.Arguments;
            if (objArguments != null)
            {
                // Loop all arguments.
                foreach (string strArgumentName in this.Arguments)
                {
                    // Build arguments string.
                    strArguments = string.Format("{0}&{1}={2}", strArguments, strArgumentName, this.Arguments[strArgumentName]);
                }
            }

            return strArguments;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this Control show open the
        /// internal form as a DHTML Form (wgx).
        /// </summary>
        /// <value><c>true</c> if [Run as DHTML]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(Gizmox.WebGUI.Forms.Hosts.FormBox.ApplicationUITypes.DHTML)]
        public virtual ApplicationUITypes ApplicationUIType
        {
            get
            {
                return menmApplicationUiType;
            }
            set
            {
                menmApplicationUiType = value;
            }
        }

        /// <summary>
        /// The mapped Visual WebGUI form to be displayed
        /// </summary>
        [Category("Data")]
        [DefaultValue("")]
        public string Form
        {
            get
            {
                if (this.ViewState["Form"] != null)
                {
                    return Convert.ToString(this.ViewState["Form"]);
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                this.ViewState["Form"] = value;
            }
        }

        /// <summary>
        /// The form instance which is used to create instances of the same mapped form
        /// </summary>
        [Category("Data")]
        [DefaultValue("")]
        public string Instance
        {
            get
            {
                return mstrInstance;
            }

            set
            {
                if (mstrInstance != null)
                {
                    mstrInstance = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FormBox"/> is stateless.
        /// </summary>
        /// <value><c>true</c> if stateless; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool Stateless
        {
            get
            {
                return mblnStateless;
            }
            set
            {
                mblnStateless = value;
            }
        }

        /// <summary>
        /// The form arguments which can be used with in the Visual WebGui application
        /// </summary>
        /// <remarks>
        /// Provides a mechanism to send parameters and object references to the Visual WebGui application.
        /// </remarks>
        public NameValueCollection Arguments
        {
            get
            {
                if (this.Router != null)
                {
                    return this.Router.GetArguments(this.Form, this.Instance) as NameValueCollection;
                }
                return null;
            }
        }

        /// <summary>
        /// The form results which can be used to expose parameters and references from the Visual WebGui application
        /// </summary>
        /// <remarks>
        /// Provides a mechanism to return parameters and object references from the Visual WebGui application.
        /// </remarks>
        public NameValueCollection Results
        {
            get
            {
                if (this.Router != null)
                {
                    return this.Router.GetResults(this.Form, this.Instance);
                }
                return null;
            }
        }

        private IRouter Router
        {
            get
            {
                if (mobjRouter == null)
                {
                    mobjRouter = ClientUtils.GetRouter();
                }
                return mobjRouter;
            }
        }

        private string TypeExtension
        {
            get
            {
                string strReturnValue = String.Empty;

                if (menmApplicationUiType == ApplicationUITypes.DHTML)
                {
                    strReturnValue = Config.GetInstance().DynamicExtension;
                }

                return strReturnValue;
            }
        }
    }
}
