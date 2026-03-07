using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.SEO;


namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
	public partial class LobbySections : Form
	{	
		// Raise event to ensure that no elements associated with section to delete
		public delegate bool ConfirmDeleteDelegate(SEOLobby.Section objSection);
		public event ConfirmDeleteDelegate ConfirmDelete;

		// Colleciton of sections for editing
		private List<SEOLobby.Section> mobjSections = new List<SEOLobby.Section>();


		public LobbySections()
		{
			InitializeComponent();

			// fill available style names
			mobjCmbStyle.Items.AddRange(new string[]{"Demo","Feature"});
			mobjCmbStyle.SelectedIndex = 0;
		}
		
		private void Init()
		{
			this.Text = "Managing Lobby sections";

			// bind section collection to the listbox
			mobjLstSections.Items.Clear();
			mobjLstSections.DisplayMember = "ID";
			mobjLstSections.ValueMember = "ID";
			mobjLstSections.Items.AddRange(this.EditedSections);
			if (this.EditedSections.Count >0)
			{
				mobjLstSections.SelectedIndex = 0;
			}

		}

        /// <summary>
        /// Gets or sets the item to edit elements.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<SEOLobby.Section> EditedSections
        {
            get
            {
                return mobjSections;
            }
            set
            {
                if (value != null)
                {
					if (mobjSections == null)
					{
						mobjSections = new List<SEOLobby.Section>();
					}
					
					mobjSections.Clear();

					// clone sections for further editing, without changing original objects
					foreach (SEOLobby.Section section in value)
					{
						mobjSections.Add((SEOLobby.Section)section.Clone());
					}

					// bind to UI
					Init();
                }
                else
                {
					throw new ArgumentException("The settings object cannot be null");
                }
            }
        }

		/// <summary>
		/// Gets or sets the selected section ID.
		/// </summary>
		/// <value>The selected section ID.</value>
		/// <remarks>
		/// Set EditedSections before call to the property.
		/// </remarks>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SelectedSectionID
		{
			get
			{
				if (mobjLstSections.SelectedIndex > -1)
				{
					return ((SEOLobby.Section)mobjLstSections.SelectedValue).ID;
				}
				else
				{
					return null;
				}
			}
			set
			{ 
				SEOLobby.Section objSection = this.EditedSections.Find(delegate(SEOLobby.Section section)
				{
					return section.ID == value;
				});
				if (objSection != null)
				{
					mobjLstSections.SelectedItem = objSection;
				}
			}
		}


		private void mobjLstSections_SelectedIndexChanged(object sender, EventArgs e)
		{
			SEOLobby.Section section = mobjLstSections.SelectedItem as SEOLobby.Section;
			if (section != null)
			{
				mobjCmbStyle.SelectedIndex = mobjCmbStyle.Items.IndexOf(section.StyleName);
				mobjColumns.Value = section.Columns;
				mobjTxtTitle.Text = section.Title;
				mobjPreText.Text = section.PreText;
				
				Highlight(section);
			}
		}

		private void Highlight(SEOLobby.Section section)
		{
			Font objHighlight = new Font(this.label1.Font, FontStyle.Bold);
			Font objRegular = new Font(this.label1.Font, FontStyle.Regular);

			mobjCmdConCss.Font = section.Style.ContainerCSS.Length >0 ? objHighlight : objRegular;
			mobjCmdPreTextCss.Font = section.Style.PreTextCSS.Length >0 ? objHighlight : objRegular;
			mobjCmdTitleCss.Font = section.Style.TitleCSS.Length >0 ? objHighlight : objRegular;
		}

		private void mobjCmdCss_Click(object sender, EventArgs e)
		{
			StringEditorForm editor = new StringEditorForm();

			SEOLobby.Section section = mobjLstSections.SelectedItem as SEOLobby.Section;
			if (section != null)
			{
				if (sender == mobjCmdConCss)
				{
					editor.EditedText = section.Style.ContainerCSS;
				}
				else if (sender == mobjCmdPreTextCss)
				{
					editor.EditedText = section.Style.PreTextCSS;
				}
				else if (sender == mobjCmdTitleCss)
				{
					editor.EditedText = section.Style.TitleCSS;
				}

				editor.ShowPopup(this, (Button)sender, DialogAlignment.Below);
				editor.FormClosed += (Form.FormClosedEventHandler)delegate(object form, FormClosedEventArgs closeevent)
				{
					if (((Form)form).DialogResult == DialogResult.OK)
					{
						if (sender == mobjCmdConCss)
						{
							section.Style.ContainerCSS = editor.EditedText;
						}
						else if (sender == mobjCmdPreTextCss)
						{
							section.Style.PreTextCSS = editor.EditedText;
						}
						else if (sender == mobjCmdTitleCss)
						{
							section.Style.TitleCSS = editor.EditedText;
						}
						Highlight(section);
					}
					editor.Dispose();
				};
			}
		}

        private void mobjButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void mobjButtonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
			this.Close();
        }

		private void mobjCmdAddDelete(object sender, EventArgs e)
		{
			if (sender == mobjCmdAdd)
			{
				SEOLobby.Section section = new SEOLobby.Section();
				section.StyleName = "Demo";
				section.ID = GetUniqueSectionID();

				mobjSections.Add(section);
				
				mobjLstSections.Items.Add(section);
				mobjLstSections.SelectedIndex = mobjLstSections.Items.Count -1;
			}
			else if (sender == mobjCmdDelete)
			{
				SEOLobby.Section section = mobjLstSections.SelectedItem as SEOLobby.Section;
				if (section != null)
				{
					if (ConfirmDelete != null)
					{
						if (ConfirmDelete(section))
						{
							// delete from section listbox and list
							mobjLstSections.Items.Remove(section);
							mobjSections.Remove(section);

							// select first item
							if (mobjLstSections.Items.Count >0)
								mobjLstSections.SelectedIndex = 0;
						}
						else
						{
							MessageBox.Show("Can't delete the section because it has associated elements." + Environment.NewLine + 
								"Close the form and change association of elements with Edit or double click.");
						}
					}
				}				
			}
		}

		private string GetUniqueSectionID()
		{
			return SEOUtils.GetUniqueSectionID(mobjSections);
		}

		// handle changes of texts: Title, PreText
		private void Text_Changed(object sender, EventArgs e)
		{
			SEOLobby.Section section = mobjLstSections.SelectedItem as SEOLobby.Section;
			if (section != null)
			{
				if (sender == mobjTxtTitle)
				{
					section.Title = mobjTxtTitle.Text;
				}
				else if (sender == mobjPreText)
				{
					section.PreText = mobjPreText.Text;
				}
			}
		}

		// handle changes of number columns
		private void mobjColumns_ValueChanged(object sender, EventArgs e)
		{
			SEOLobby.Section section = mobjLstSections.SelectedItem as SEOLobby.Section;
			if (section != null)
			{
				section.Columns = (int)mobjColumns.Value;
			}
		}

		// handle changes of style name
		private void mobjCmbStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			SEOLobby.Section section = mobjLstSections.SelectedItem as SEOLobby.Section;
			if (section != null)
			{
				section.StyleName = (string)mobjCmbStyle.SelectedItem;
			}
		}

		// clear extended CSS formatting
		private void mobjCmdClearCss_Click(object sender, EventArgs e)
		{
			SEOLobby.Section section = mobjLstSections.SelectedItem as SEOLobby.Section;
			if (section != null)
			{
				section.Style.ContainerCSS =
				section.Style.PreTextCSS =
				section.Style.TitleCSS = string.Empty;
				Highlight(section);
			}
		}

		// opening resizeble window for comfortable editing of the text
		private void mobjEditorText_Click(object sender, EventArgs e)
		{
			StringEditorForm editor = new StringEditorForm();
			editor.Size =  new Size(670,380);
			editor.StartPosition = FormStartPosition.CenterScreen;

			TextBox objTextBox = null;

			if (sender == mobjEditorTitle)
			{
				objTextBox = mobjTxtTitle;
			}
			else if (sender == mobjEditorText)
			{
				objTextBox = mobjPreText;
			}

			if (objTextBox != null)
			{
				editor.EditedText = objTextBox.Text;
				editor.FormClosed += (Form.FormClosedEventHandler)delegate(object form, FormClosedEventArgs closeevent)
				{
					if (((Form)form).DialogResult == DialogResult.OK)
					{
						objTextBox.Text = editor.EditedText;
					}
				};
				editor.ShowDialog();
			}
		}

	}
}