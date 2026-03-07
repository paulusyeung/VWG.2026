#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
    [Serializable]
    public partial class ListViewControlPanel : UserControl
    {
        private string mstrPrevFrom = "";
        private string mstrPrevSubject = "";
        private bool mblnPrevImportant = false;
        private bool mblnPrevRead = false;
        private bool mblnPrevAttachemnts = false;
        private string mstrPrevMailSize = "";

        public ListViewControlPanel()
        {
            InitializeComponent();
        }

        internal bool IsPanelDirty
        {
            get
            {
                return
                    mblnPrevAttachemnts != Attachemnts ||
                    mstrPrevSubject != Subject ||
                    mstrPrevFrom != From ||
                    mstrPrevMailSize != MailSize ||
                    mblnPrevImportant != Important ||
                    mblnPrevRead != Read;
            }
        }

        internal void SetPrevValues()
        {
            mblnPrevAttachemnts = Attachemnts;
            mstrPrevSubject = Subject;
            mstrPrevFrom = From;
            mstrPrevMailSize = MailSize;
            mblnPrevImportant = Important;
            mblnPrevRead = Read;
        }

        internal string Subject
        {
            get
            {
                return textBoxSubject.Text;
            }
            set
            {
                textBoxSubject.Text = value;
            }
        }

        internal string From
        {
            get
            {
                return textBoxFrom.Text;
            }
            set
            {
                textBoxFrom.Text = value;
            }
        }

        internal string MailSize
        {
            get
            {
                return textBoxSize.Text;
            }
            set
            {
                textBoxSize.Text = value;
            }
        }

        internal bool Attachemnts
        {
            get
            {
                return checkBoxAttachments.Checked;
            }
            set
            {
                checkBoxAttachments.Checked = value;
            }
        }

        internal bool Important
        {
            get
            {
                return checkBoxImportant.Checked;
            }
            set
            {
                checkBoxImportant.Checked = value;
            }
        }

        internal bool Read
        {
            get
            {
                return checkBoxRead.Checked;
            }
            set
            {
                checkBoxRead.Checked = value;
            }
        }
    }
}