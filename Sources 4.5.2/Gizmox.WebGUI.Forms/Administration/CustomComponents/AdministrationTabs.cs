#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Administration.Abstract;

#endregion Using

namespace Gizmox.WebGUI.Forms.Administration.CustomComponents
{
    /// <summary>
    /// A TabControl control
    /// </summary>
    [Skin(typeof(AdministrationTabsSkin))]
    [Serializable()]
    [ToolboxItem(false)]
    internal class AdministrationTabs : TabControl
    {
        /// <summary>
        /// The mobj content updateable
        /// </summary>
        private IContentUpdateable mobjContentUpdateable;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationTabs"/> class.
        /// </summary>
        public AdministrationTabs()
        {
            this.CustomStyle = "AdministrationTabsSkin";
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        internal void UpdateContent()
        {
            if (ContentUpdateable != null)
            {
                ContentUpdateable.UpdateContent();
            }
        }

        /// <summary>
        /// Gets or sets the content updateable.
        /// </summary>
        /// <value>
        /// The content updateable.
        /// </value>
        public IContentUpdateable ContentUpdateable
        {
            get { return mobjContentUpdateable; }
            set { mobjContentUpdateable = value; }
        }
        
    }

}
