using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;


namespace Gizmox.WebGUI.Forms.Administration
{
    /// <summary>
    /// 
    /// </summary>
    public class ContentProperties
    {
        /// <summary>
        /// The MSTR content name
        /// </summary>
        private string mstrContentName;
        /// <summary>
        /// The MBLN full screen
        /// </summary>
        private bool mblnFullScreen;

        /// <summary>
        /// The MSTR content description
        /// </summary>
        private string mstrContentDescription;

        /// <summary>
        /// The mobj status data
        /// </summary>
        private List<StatusData> mobjStatusData;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentProperties"/> class.
        /// </summary>
        /// <param name="strContentName">Name of the string content.</param>
        public ContentProperties(string strContentName)
        {
            this.mstrContentName = strContentName;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [full screen].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [full screen]; otherwise, <c>false</c>.
        /// </value>
        public bool FullScreen
        {
            get { return mblnFullScreen; }
            set { mblnFullScreen = value; }
        }

        /// <summary>
        /// Gets or sets the content description.
        /// </summary>
        /// <value>
        /// The content description.
        /// </value>
        public string ContentDescription
        {
            get { return mstrContentDescription; }
            set { mstrContentDescription = value; }
        }

        /// <summary>
        /// Gets or sets the status data.
        /// </summary>
        /// <value>
        /// The status data.
        /// </value>
        public List<StatusData> StatusData
        {
            get { return mobjStatusData; }
            set { mobjStatusData = value; }
        }

        /// <summary>
        /// Gets the name of the content.
        /// </summary>
        /// <value>
        /// The name of the content.
        /// </value>
        public string ContentName
        {
            get { return mstrContentName; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public abstract class AdministrationContent : UserControl
    {
        /// <summary>
        /// Gets the content properties.
        /// </summary>
        /// <value>
        /// The content properties.
        /// </value>
        public abstract ContentProperties ContentProperties { get; }
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public abstract int Index { get; }

        /// <summary>
        /// Updates the content.
        /// </summary>
        protected void UpdateContent()
        {
            Control objContent = this;

            while (!(objContent is IContentUpdateable || objContent is AdministrationFormBase))
            {
                objContent = objContent.Parent;

                if (objContent is IContentUpdateable)
                {
                    (objContent as IContentUpdateable).UpdateContent();
                    break;
                }
            }
        }

        /// <summary>
        /// On loading of the AdministrationContent, first do the functionality here
        /// </summary>
        /// <param name="objData">Data used by the automatic functionality</param>
        public virtual void PerformAutomateAction(object objData)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        public class AdministrationContentSorter : IComparer<AdministrationContent>
        {
            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns>
            /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.
            /// </returns>
            public int Compare(AdministrationContent x, AdministrationContent y)
            {
                return x.Index.CompareTo(y.Index);
            }
        }
    }
}
