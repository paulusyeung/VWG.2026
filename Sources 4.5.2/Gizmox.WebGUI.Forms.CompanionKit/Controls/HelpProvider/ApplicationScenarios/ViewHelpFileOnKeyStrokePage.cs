using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;

namespace CompanionKit.Controls.HelpProvider.ApplicationScenarios
{
    public partial class ViewHelpFileOnKeyStrokePage : UserControl
    {
        // Create an instance of Config class that contains 
        // settings from web.config file
        private static Config mobjConfig = Config.GetInstance();
        /// <summary>
        /// Contains path to help file
        /// </summary> 
        private static string ProjectCHM
        {
            get
            {
                return System.IO.Path.Combine(mobjConfig.GetDirectory("Data"), "Help.chm");
            }
        }

        public ViewHelpFileOnKeyStrokePage()
        {
            InitializeComponent();
        }        

        /// <summary>
        /// Handles Load event for Page
        /// </summary>
        private void ViewHelpFileOnKeyStrokePage_Load(object sender, EventArgs e)
        {
            // Set help keywords for controls
            mobjHelpProvider.SetHelpKeyword(mobjTextBox, "TextBox class");
            mobjHelpProvider.SetHelpKeyword(mobjComboBox, "ComboBox class");
            mobjHelpProvider.SetHelpKeyword(mobjListBox, "ListBox class");
            mobjHelpProvider.SetHelpKeyword(mobjDomainUpDown, "DomainUpDown class");
            mobjHelpProvider.SetHelpKeyword(mobjNumericUpDown, "NumericUpDown class");
            mobjHelpProvider.SetHelpKeyword(mobjLinkLabel, "LinkLabel class");
            mobjHelpProvider.SetHelpKeyword(mobjRadioButton1, "RadioButton class");
            mobjHelpProvider.SetHelpKeyword(mobjRadioButton2, "RadioButton class");
            mobjHelpProvider.SetHelpKeyword(mobjCheckBox, "CheckBox class");

            // Set KeyDown event handler for controls
            mobjTextBox.KeyDown += new KeyEventHandler(Control_KeyDown);
            mobjComboBox.KeyDown += new KeyEventHandler(Control_KeyDown);
            mobjListBox.KeyDown += new KeyEventHandler(Control_KeyDown);
            mobjDomainUpDown.KeyDown += new KeyEventHandler(Control_KeyDown);
            mobjNumericUpDown.KeyDown += new KeyEventHandler(Control_KeyDown);
            mobjLinkLabel.KeyDown += new KeyEventHandler(Control_KeyDown);
            mobjRadioButton1.KeyDown += new KeyEventHandler(Control_KeyDown);
            mobjRadioButton2.KeyDown += new KeyEventHandler(Control_KeyDown);
            mobjCheckBox.KeyDown += new KeyEventHandler(Control_KeyDown);
        }

        /// <summary>
        /// Handles KeyDown event for control
        /// </summary>
        private void Control_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            // If F1 key pressed
            if (objArgs.KeyCode == Keys.F1)
            {
                // Show help file
                Help.ShowHelp(this, ProjectCHM, HelpNavigator.KeywordIndex, mobjHelpProvider.GetHelpKeyword((Control)objSender));
            }
        }
    }
}