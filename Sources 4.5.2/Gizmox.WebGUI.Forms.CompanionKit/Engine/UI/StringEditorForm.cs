using System;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
	public partial class StringEditorForm : Form
	{
		public StringEditorForm()
		{
			InitializeComponent();
		}

		public string EditedText
		{
			get { return mobjTxtEdited.Text; }
			set { mobjTxtEdited.Text = value; }
		}

		private void mobjCmdOK_Click(object sender, EventArgs e)
		{
            this.DialogResult = DialogResult.OK;
            this.Close();
		}

		private void mobjCmdCancel_Click(object sender, EventArgs e)
		{
            this.DialogResult = DialogResult.Cancel;
            this.Close();
		}

		// clear text
		private void mobjCmdClear_Click(object sender, EventArgs e)
		{
			this.EditedText = string.Empty;
		}
	}
}