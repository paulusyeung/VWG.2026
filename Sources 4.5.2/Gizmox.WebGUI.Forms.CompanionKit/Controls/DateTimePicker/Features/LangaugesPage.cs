using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DateTimePicker.Features
{
    public partial class LangaugesPage : UserControl
    {
        private CultureInfo _currentUICulture;
        public LangaugesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void LangaugesPage_Load(object sender, EventArgs e)
        {
            _currentUICulture = Context.CurrentUICulture;
            // Fill up the ConboBox with support languages.
            this.mobjLanguagesComboBox.DataSource = Enum.GetValues(typeof(SupportLanguages));
            
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox that contains 
        /// support languages. Sets selected languages for the current page.
        /// </summary>
        private void mobjLanguagesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set selected languages for the current page.
            SupportLanguages selectedLanguage = (SupportLanguages)this.mobjLanguagesComboBox.SelectedItem;
            switch (selectedLanguage)
            {
                case SupportLanguages.English:
                    Context.CurrentUICulture = new CultureInfo("en-US", false);
                    break;
                case SupportLanguages.French:
                    Context.CurrentUICulture = new CultureInfo("fr-FR", false);
                    break;
                case SupportLanguages.German:
                    Context.CurrentUICulture = new CultureInfo("de-DE", false);
                    break;
                case SupportLanguages.Hebrew:
                    Context.CurrentUICulture = new CultureInfo("he-IL", false);
                    break;
                default:
                    Context.CurrentUICulture = new CultureInfo("en-US", false);
                    break;
            }
            
        }
        /// <summary>
        /// Represents support languages
        /// </summary>
        private enum SupportLanguages
        {
            English,
            French,
            German,
            Hebrew
        }

        /// <summary>
        /// Handles VisibleChanged event of the example' UserControl.
        /// Sets default globalization settings for the project.
        /// </summary>
        private void LangaugesPage_VisibleChanged(object sender, EventArgs e)
        {
            if (_currentUICulture != null)
            {
                Context.CurrentUICulture = _currentUICulture;
            }
        }
    }
}