using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Resources;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Hosts
{
    /// <summary>
    /// 
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(ActiveXBox), "ActiveXBox_45.png")]
#else
    [ToolboxBitmap(typeof(ActiveXBox), "ActiveXBox.bmp")]
#endif
    [Serializable]
    public class ActiveXBox : ObjectBox
    {     
        /// <summary>
        /// Gets or sets the class id.
        /// </summary>
        /// <value>The class id.</value>
        [DefaultValue("")]
        public string ClassId
        {
            get
            {
                return this.ObjectClassId;
            }
            set
            {
                this.ObjectClassId = value;
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [DefaultValue("")]
        public string Data
        {
            get
            {
                return this.ObjectData;
            }
            set
            {
                this.ObjectData = value;
            }
        }

        /// <summary>
        /// Gets or sets the code base.
        /// </summary>
        /// <value>The code base.</value>
        [DefaultValue("")]
        public string CodeBase
        {
            get
            {
                return this.ObjectCodeBase;
            }
            set
            {
                this.ObjectCodeBase = value;
            }
        }

        /// <summary>
        /// Gets or sets the stand by.
        /// </summary>
        /// <value>The stand by.</value>
        [DefaultValue("")]
        public string StandBy
        {
            get
            {
                return this.ObjectStandBy;
            }
            set
            {
                this.ObjectStandBy = value;
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [DefaultValue("")]
        public string Type
        {
            get
            {
                return this.ObjectType;
            }
            set
            {
                this.ObjectType = value;
            }
        }

    }
}
