#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace $rootnamespace$
{
    /// <summary>
    /// A NumericUpDown control
    /// </summary>
    [Skin(typeof($safeitemname$Skin))]
    [Serializable()]
    public class $safeitemname$ : NumericUpDown
    {
        public $safeitemname$()
        {
            this.CustomStyle = "$safeitemname$Skin";
        }
    }

}
