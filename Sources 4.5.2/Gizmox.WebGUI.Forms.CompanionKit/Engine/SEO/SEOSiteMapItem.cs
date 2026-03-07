using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// The base class for item included in the sitemap
    /// </summary>
    public class SEOSiteMapItem : SEOElement
    {
        /// <summary>
        /// Determines where exposed in sitemap.wgx application
        /// </summary>
        protected bool mblnSiteMap = true;

        /// <summary>
        /// Indicates if item is part of the SEO sitemap
        /// </summary>
        internal bool SiteMap
        {
            get
            {
                return mblnSiteMap;
            }
            set
            {
                mblnSiteMap = value;
            }
        }

        /// <summary>
        /// Gets the change frequency.
        /// </summary>
        /// <value>The change frequency.</value>
        internal SEOPageChangeFrequency ChangeFrequency
        {
            get
            {
                return SEOPageChangeFrequency.Daily;
            }
        }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>The priority.</value>
        internal SEOPagePriority Priority
        {
            get
            {
                return SEOPagePriority.Normal;
            }
        }


        public override void Load(XmlElement objSEOItemElement)
        {
            mblnSiteMap = SEOUtils.GetAttribute(objSEOItemElement, "SiteMap", false);
        }

        public override void Save(XmlElement objSEOItemElement)
        {
            SEOUtils.SetAttribute(objSEOItemElement, "SiteMap", mblnSiteMap);
        }
    }
}
