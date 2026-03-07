using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms.Administration.CustomComponents
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false), Browsable(false)]
    [Serializable()]
    public class AdministrationFooterPanel : Panel
    {
        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        private class StatusLabel : Label
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusLabel" /> class.
            /// </summary>
            public StatusLabel()
            {
                this.AutoSize = true;
                this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.Dock = DockStyle.Left;
            }
        }

        /// <summary>
        /// The mobj labels
        /// </summary>
        private List<Label> mobjLabels;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationFooterPanel" /> class.
        /// </summary>
        public AdministrationFooterPanel()
        {
            mobjLabels = new List<Label>();
        }

        /// <summary>
        /// Sets the labels.
        /// </summary>
        /// <param name="objDatas">The object datas.</param>
        public void SetLabels(List<StatusData> objDatas)
        {
            if (objDatas != null)
            {
                while (objDatas.Count > this.mobjLabels.Count)
                {
                    Label objLabel = new StatusLabel();
                    mobjLabels.Insert(0,objLabel);
                    this.Controls.Add(objLabel);
                }

                int i = 0;
                foreach (StatusData objData in objDatas)
                {
                    UpdateLabel(objData, mobjLabels[i]);
                    ++i;
                }

                for (int j = i; j < mobjLabels.Count; j++)
                {
                    mobjLabels[j].Visible = false;
                }
            }
            else
            {
                foreach (Label objLabel in mobjLabels)
                {
                    objLabel.Visible = false;
                }
            }
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="objData">The object data.</param>
        /// <param name="objLabel">The label.</param>
        private void UpdateLabel(StatusData objData, Label objLabel)
        {
            objLabel.Visible = true;
            objLabel.Text = objData.Text;
            System.Drawing.Font objFont = objData.Font;

            if (objFont != null)
            {
                objLabel.Font = objFont;
            }
            else
            {
                objLabel.Font = DefaultControlFont;
            }
        }
    }
}
