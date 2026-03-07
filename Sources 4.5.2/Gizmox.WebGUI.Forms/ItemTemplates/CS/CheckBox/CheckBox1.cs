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
    /// A checkbox control
    /// </summary>
    [Skin(typeof($safeitemname$Skin))]
    [Serializable()]
    public class $safeitemname$ : CheckBox
    {
        public $safeitemname$()
        {
            this.CustomStyle = "$safeitemname$Skin";
        }
    }

}
