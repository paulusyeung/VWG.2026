using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true), Serializable()]
    public sealed class RelatedImageListAttribute : Attribute
    {

        #region Members

        /// <summary>
        /// 
        /// </summary>
        private string mstrRelatedImageList;
        
        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="RelatedImageListAttribute"/> class.
        /// </summary>
        /// <param name="strRelatedImageList">The related image list.</param>
        public RelatedImageListAttribute(string strRelatedImageList)
        {
            this.mstrRelatedImageList = strRelatedImageList;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the related image list.
        /// </summary>
        /// <value>The related image list.</value>
        public string RelatedImageList
        {
            get
            {
                return this.mstrRelatedImageList;
            }
        } 

        #endregion
    }
 

}
