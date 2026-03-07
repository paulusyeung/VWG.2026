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

namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features
{
    public partial class FilterPage : UserControl
    {

        /// <summary>
        /// Represents collection of file types filters 
        /// </summary>
        private Dictionary<string, string> _filters = new Dictionary<string, string>();

        /// <summary>
        /// Represnts default file types filters 
        /// </summary>
        private string DEFAULT_FILTER = "All Files(*.*)";
        
        public FilterPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example UserControl
        /// </summary>
        private void FilterPage_Load(object sender, EventArgs e)
        {
            // Fill up dictionary with files filter
            _filters.Add("Image Files (JPEG,GIF,BMP)", "*.jpg;*.jpeg;*.gif;*.bmp");
            _filters.Add("JPEG Files(*.jpg;*.jpeg)", "*.jpg;*.jpeg");
            _filters.Add("GIF Files(*.gif)", "*.gif");
            _filters.Add("BMP Files(*.bmp)", "*.bmp");
            _filters.Add("All Files(*.*)", "*.*");

            // Fill up ListBox with name filter of the file types
            foreach (String curentFilterKey in _filters.Keys)
            {
                this.mobjFiltersOfFileTypesListBox.Items.Add(curentFilterKey);
            }
            this.mobjFiltersOfFileTypesListBox.SelectedValue = "All Files(*.*)";
        }

        /// <summary>
        /// Handles the click event of the button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            // Set images file Filter for Open File Dialog
            this.mobjDemoOpenFileDialog.Filter = GetSelectedFiltersAsString();
            // Set index of default images file Filter for Open File Dialog
            this.mobjDemoOpenFileDialog.FilterIndex = 1;
            // Set initial directory for Open File Dialog
            this.mobjDemoOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            // Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog();
        }

        /// <summary>
        /// Gets string that represents filter of the file types for OpenFileDialog
        /// </summary>
        private string GetSelectedFiltersAsString()
        {
            StringBuilder filters = new StringBuilder();
            if (this.mobjFiltersOfFileTypesListBox.SelectedItems.Count > 0)
            {
                foreach (string selectedFilterKey in this.mobjFiltersOfFileTypesListBox.SelectedItems)
                {
                    AppendsFilterOfFileTypes(filters, selectedFilterKey);
                }
            }
            else
            {   
                AppendsFilterOfFileTypes(filters, DEFAULT_FILTER);
            }
            return filters.ToString();
        }

        /// <summary>
        /// Appends filter of the file types into the Filters string builder.
        /// </summary>
        /// <param name="filters">string builder with filters of the file types</param>
        /// <param name="filterKey">the filter name</param>
        private void AppendsFilterOfFileTypes(StringBuilder filters, string filterKey)
        {
            if (filters.Length > 0)
            {
                filters.Append("|");
            }

            filters.Append(filterKey).Append("|").Append(_filters[filterKey]);
        }
    }
}