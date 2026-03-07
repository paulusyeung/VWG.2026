using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.IO;
using System.Text.RegularExpressions;

namespace CompanionKit.Controls.UploadControl.Functionality
{
    public partial class UploadControlPage : UserControl
    {
        List<UploadFileModel> mobjList = new List<UploadFileModel>();
        string mstrTempPath = System.IO.Path.GetTempPath();

        public UploadControlPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the UploadControlPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void UploadControlPage_Load(object sender, EventArgs e)
        {
            //Some onload initialization
            mobjUploadControl.UploadTempFilePath = mstrTempPath;
            mobjListBox.SelectedIndex = 0;
            mobjShowFileNameCheckBox.Checked = mobjUploadControl.UploadShowFilenameOnBar;
            mobjShowSpeedCheckBox.Checked = mobjUploadControl.UploadShowSpeedOnBar;
        }

        /// <summary>
        /// Handles the UploadFileCompleted event of the mobjUploadControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UploadCompletedEventArgs"/> instance containing the event data.</param>
        private void mobjUploadControl_UploadFileCompleted(object sender, UploadCompletedEventArgs e)
        {
            UploadFileResult mobjResult = e.Result;
            // Adds record to the list about uploaded file
            mobjList.Add(new UploadFileModel(mobjResult.Name, mobjResult.TempFileFullName, mobjResult.Type, mobjResult.Size));
            // Resets the data source.
            mobjListView.DataSource = null;
            mobjListView.DataSource = mobjList;
            // Resizes ListView's column headers
            ResizeListViewColumnHeaders();
        }

        /// <summary>
        /// Handles the UploadError event of the mobjUploadControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UploadErrorEventArgs"/> instance containing the event data.</param>
        private void mobjUploadControl_UploadError(object sender, UploadErrorEventArgs e)
        {
            MessageBox.Show(e.Error);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjShowFileNameCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShowFileNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjUploadControl.UploadShowFilenameOnBar = mobjShowFileNameCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjShowSpeedCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShowSpeedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjUploadControl.UploadShowSpeedOnBar = mobjShowSpeedCheckBox.Checked;
        }

        /// <summary>
        /// Resizes the list view column headers.
        /// </summary>
        private void ResizeListViewColumnHeaders()
        {
            if (mobjListView.Columns.Count > 0)
            {
                foreach (ColumnHeader mobjColumn in mobjListView.Columns)
                {
                    mobjColumn.Width = -2;
                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mobjUploadControl.UploadFileTypes = mobjListBox.SelectedItem.ToString();
            DisplayCurrentUploadFileType();
        }

        /// <summary>
        /// Displays the type of the current upload file.
        /// </summary>
        private void DisplayCurrentUploadFileType()
        {
            mobjGroupBox.Text = string.Format("File type:{0}", mobjUploadControl.UploadFileTypes);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjDefinedRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjDefinedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mobjCustomRadioButton.Checked = !mobjDefinedRadioButton.Checked;
            if (mobjDefinedRadioButton.Checked)
            {
                mobjListBox_SelectedIndexChanged(this.mobjListBox, new EventArgs());
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCustomRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mobjDefinedRadioButton.Checked = !mobjCustomRadioButton.Checked;
            mobjListBox.Enabled = mobjDefinedRadioButton.Checked;
            mobjTextBox.Enabled = mobjSetButton.Enabled = !mobjDefinedRadioButton.Checked;
        }

        /// <summary>
        /// Handles the Click event of the mobjSetButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSetButton_Click(object sender, EventArgs e)
        {
            //Regular expression, which is validating entered string
            Regex mobjRegex = new Regex(@"^\^\..*\$$", RegexOptions.IgnoreCase);
            if (!string.IsNullOrEmpty(mobjTextBox.Text) && mobjRegex.Match(mobjTextBox.Text).Success)
            {
                    mobjUploadControl.UploadFileTypes = mobjTextBox.Text;
                    DisplayCurrentUploadFileType();
            }
            else { MessageBox.Show(@"Please, check your value for compliance of pattern ^\^\..*\$$ (should starts with '^.' and ends with '$').", "The value is not valid!", MessageBoxButtons.OK , MessageBoxIcon.Warning); }
        }
    }

    class UploadFileModel
    {
        public string TempFullPath;

        private string _name;
        public string Name
        {
            get { return _name;}
            set { _name = value;}
        }
        private string _type;
        public string Type 
        {
            get { return _type; }
            set { _type = value; }
        }

        private long _size;
        public long Size 
        {
            get { return _size; }
            set { _size = value; }
        }

        private DateTime _uploadTime;
        public DateTime UploadTime 
        {
            get { return _uploadTime; }
            set { _uploadTime = value; }
        }

        public UploadFileModel(string strName, string strTempFullPath, string strType, long lngSize)
        {
            this.Name = strName;
            this.TempFullPath = strTempFullPath;
            this.Type = strType;
            this.Size = lngSize;
            this.UploadTime = DateTime.Now;
        }
    }
}