using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ObjectBox.Programming
{
    public partial class ProvideParametersPage : UserControl
    {
        public ProvideParametersPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ProvideParametersPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ProvideParametersPage_Load(object sender, EventArgs e)
        {
            CustomObjectBox demoObjectBox = new CustomObjectBox();

            demoObjectBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            demoObjectBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            demoObjectBox.Location = new System.Drawing.Point(0, 0);
            demoObjectBox.Name = "demoActiveXBox";
            demoObjectBox.Movie = "../../../../../../../Resources/Flash/FC_2_3_Area2D.swf";
            demoObjectBox.Parameters.Add("FlashVars", "&dataURL=../../../../../../../Resources/Flash/FC_2_3_DATA.xml");
            demoObjectBox.Parameters.Add("quality", "high");
            demoObjectBox.Size = new System.Drawing.Size(391, 450);
            demoObjectBox.TabIndex = 0;
            
            this.Controls.Add(demoObjectBox);
        }

        /// <summary>
        /// This class is used display flash animation.
        /// </summary>
        class CustomObjectBox : Gizmox.WebGUI.Forms.Hosts.ObjectBox
        {
            public CustomObjectBox()
                : base()
            {
                this.ObjectClassId = "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000";
                this.ObjectCodeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0";
                this.ObjectPluginsPageType = "http://www.macromedia.com/go/getflashplayer";
                this.ObjectType = "application/x-shockwave-flash";
            }
            /// <summary>
            /// Gets or sets Class Id for object box
            /// </summary>
            public string ClassId
            {
                get
                {
                    return base.ObjectClassId;
                }

                set
                {
                    base.ObjectClassId = value;
                }
            }

            /// <summary>
            /// Gets or sets CodeBase for object box
            /// </summary>
            public string CodeBase
            {
                get
                {
                    return base.ObjectCodeBase;
                }

                set
                {
                    base.ObjectCodeBase = value;
                }
            }
            /// <summary>
            /// Gets or sets Type for object box
            /// </summary>
            public string Type
            {
                get
                {
                    return base.ObjectType;
                }

                set
                {
                    base.ObjectType = value;
                }
            }

            /// <summary>
            /// Gets or sets Flash movie
            /// </summary>
            public string Movie
            {
                get
                {
                    if (this.Parameters.Contains("src"))
                    {
                        return this.Parameters["src"].ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                set
                {
                    this.Parameters["src"] = value;
                }
            }


        }
    }
}
