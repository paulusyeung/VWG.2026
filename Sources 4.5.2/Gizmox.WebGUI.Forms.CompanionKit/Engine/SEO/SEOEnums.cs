using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Gizmox.WebGUI.Forms.SEO
{

    /// <summary>
    /// 
    /// </summary>
    public enum SEOItemStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Draft,

        /// <summary>
        /// 
        /// </summary>
        Publish
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SEOItemType
    {
        /// <summary>
        /// 
        /// </summary>
        Folder,

        /// <summary>
        /// 
        /// </summary>
        Lobby,

        /// <summary>
        /// 
        /// </summary>
        Page,

        /// <summary>
        /// 
        /// </summary>
        Article
    }


    /// <summary>
    /// 
    /// </summary>
    public enum SEOPageInspectorDocking
    {
        /// <summary>
        /// 
        /// </summary>
        Bottom,

        /// <summary>
        /// 
        /// </summary>
        Right
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SEOPageChangeFrequency
    {
        /// <summary>
        /// 
        /// </summary>
        Always,

        /// <summary>
        /// 
        /// </summary>
        Hourly,

        /// <summary>
        /// 
        /// </summary>
        Daily,

        /// <summary>
        /// 
        /// </summary>
        Weekly,

        /// <summary>
        /// 
        /// </summary>
        Monthly,

        /// <summary>
        /// 
        /// </summary>
        Yearly,

        /// <summary>
        /// 
        /// </summary>
        Never
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SEOPagePriority
    {
        /// <summary>
        /// 
        /// </summary>
        Low,
        /// <summary>
        /// 
        /// </summary>
        Normal,
        /// <summary>
        /// 
        /// </summary>
        High
    }
}
