using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.IO;
using Gizmox.WebGUI.Converters.Itenso;
using Gizmox.WebGUI.Common.Resources;

namespace CompanionKit.Controls.RichTextEditor.Functionality
{
    public partial class RTFImportPage : UserControl
    {
        string mstrFilePath = string.Empty;

        public RTFImportPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gets full path to rtf file
            mstrFilePath = AppDomain.CurrentDomain.BaseDirectory + @"Controls\RichTextEditor\Functionality\" + mobjComboBox.SelectedItem.ToString();
            //Creates a new stream
            Stream objInputStream = File.OpenRead(mstrFilePath); 
            //Creates formatConverter object
            FormatConverter objFormatConverter = new FormatConverter();
            //Converting rtf to Html and sets result to richTextEditor control
            Stream objOutputStream = objFormatConverter.Convert(Gizmox.WebGUI.Common.Interfaces.FormatConvertionType.Rtf, Gizmox.WebGUI.Common.Interfaces.FormatConvertionType.Html, objInputStream, null);
            StreamReader objStreamReader = new StreamReader(objOutputStream);
            string strContent = objStreamReader.ReadToEnd();
            mobjRichTextEditor.Value = strContent;
        }

        /// <summary>
        /// Handles the Load event of the RTFImportPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RTFImportPage_Load(object sender, EventArgs e)
        {
            mobjComboBox.SelectedIndex = 1;
        }
    }
}