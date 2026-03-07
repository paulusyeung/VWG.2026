using System;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;

namespace VWGApplication
{
    /// <summary>
    /// This Control used for attaching resource files to the Form
    /// including script resource file
    /// </summary>
    [Skin(typeof(VwgAdapterSkin))]
    public class VwgAdapter : Control
    {
    }
}
