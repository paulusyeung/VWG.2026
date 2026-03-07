using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Xml;

namespace Gizmox.WebGUI.Forms.SEO
{
    public class SEOProperties : NameValueCollection
    {

        internal SEOProperties()
        {

        }

        internal SEOProperties(XmlNodeList objNodes)
        {
            foreach (XmlNode objNode in objNodes)
            {
                this[objNode.Attributes["name"].Value] = objNode.Attributes["value"].Value;
            }

            this.IsReadOnly = true;
            
        }

    
    }
}
