using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.KB.Engine.Data;
using Gizmox.WebGUI.Forms.CompanionKit.Engine;

namespace Gizmox.WebGUI.Forms.SEO
{

    /// <summary>
    /// Implements additional SEOItem type for displaying
    /// external HTML resources
    /// </summary>
    public class SEOArticle : SEOItem
    {
        private string  mstrCode     = string.Empty;

        public string Code
        {
            get { return mstrCode; }
            set { mstrCode = value; }
        }

        /// <summary>
        /// Initializes a new (not saved) instance of the <see cref="SEOArticle"/> class.
        /// </summary>
        /// <param name="strFSOFile">The FSO file.</param>
        /// <param name="objSEOParent">The SEO parent.</param>
        /// <param name="blnIsNew">if set to <c>true</c> is new (not saved).</param>
        public SEOArticle(string strFSOFile, SEOFolder objSEOParent)
            : base(strFSOFile, objSEOParent)
        {
            this.Type = SEOItemType.Article;
        }

        public SEOArticle(string strFSOItem, XmlElement objElement, SEOFolder objSEOParent)
            : base(strFSOItem, objElement, objSEOParent)
        {
            this.Type = SEOItemType.Article;
        }

        /// <summary>
        /// Loads the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Load(XmlElement objSEOItemElement)
        {
            base.Load(objSEOItemElement);

            mstrCode = SEOUtils.GetValue(objSEOItemElement, "Code", string.Empty);
         }

        /// <summary>
        /// Saves the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Save(XmlElement objSEOItemElement)
        {
            base.Save(objSEOItemElement);

			// the new article will have an empty code
			if (mstrCode == string.Empty)
			{
				mstrCode = this.Name;
			}

            SEOUtils.SetValue(objSEOItemElement, "Code", mstrCode);
        }

        public override void GetReferencesTo(SEOItem objSEOItem, List<SEOItem> objReferences)
        {
            // currently, the article has no references to other SEOItem-s
        }
    }
}
