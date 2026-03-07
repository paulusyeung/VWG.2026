using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.Design
{
    [Serializable()]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class WebCollectionEditorItemTypeNameAttribute : Attribute
    {
        #region Fields

        private string mstrDisplayName = string.Empty;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebCollectionEditorItemTypeNameAttribute"/> class.
        /// </summary>
        /// <param name="strDisplayName">Display name of the string.</param>
        public WebCollectionEditorItemTypeNameAttribute(string strDisplayName)
        {
            mstrDisplayName = strDisplayName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName
        {
            get { return mstrDisplayName; }
            set { mstrDisplayName = value; }
        }

        #endregion Properties
    }
}
