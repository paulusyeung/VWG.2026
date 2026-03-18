using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using HtmlHelp;

namespace Gizmox.WebGUI.Forms;

public class TopicsDialog : Form
{
	private Label mobjLabelInstructions;

	private Panel mobjPanelButtons;

	private Button mobjButtonDisplay;

	private Button mobjButtonCancel;

	private ListView mobjListTopics;

	private ColumnHeader mobjColumnTitle;

	private ColumnHeader mobjBolumnLocation;

	private bool mblnIsCompleted = false;

	private IndexTopic mobjSelectedItem = null;

	private IContainer components = null;

	public IndexTopic SelectedItem => mobjSelectedItem;

	public bool IsCompleted => mblnIsCompleted;

	public TopicsDialog()
	{
		InitializeComponent();
	}

	public TopicsDialog(ArrayList objTopics)
	{
		InitializeComponent();
		foreach (IndexTopic objTopic in objTopics)
		{
			ListViewItem listViewItem = mobjListTopics.Items.Add(objTopic.Title);
			listViewItem.Tag = objTopic;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		mobjLabelInstructions = new Label();
		mobjPanelButtons = new Panel();
		mobjListTopics = new ListView();
		mobjColumnTitle = new ColumnHeader();
		mobjBolumnLocation = new ColumnHeader();
		mobjButtonCancel = new Button();
		mobjButtonDisplay = new Button();
		SuspendLayout();
		mobjLabelInstructions.BackgroundImageLayout = ImageLayout.Tile;
		mobjLabelInstructions.ClientSize = new Size(448, 23);
		mobjLabelInstructions.Cursor = Cursors.Default;
		mobjLabelInstructions.Dock = DockStyle.Top;
		mobjLabelInstructions.FlatStyle = FlatStyle.Flat;
		mobjLabelInstructions.Location = new Point(10, 10);
		mobjLabelInstructions.Margin = new Padding(0);
		mobjLabelInstructions.Name = "mobjLabelInstructions";
		mobjLabelInstructions.Size = new Size(448, 23);
		mobjLabelInstructions.TabIndex = 0;
		mobjLabelInstructions.Text = "Click a topic, then click display.";
		mobjLabelInstructions.TextAlign = ContentAlignment.MiddleLeft;
		mobjPanelButtons.BackgroundImageLayout = ImageLayout.Tile;
		mobjPanelButtons.ClientSize = new Size(448, 38);
		mobjPanelButtons.Controls.Add(mobjButtonDisplay);
		mobjPanelButtons.Controls.Add(mobjButtonCancel);
		mobjPanelButtons.Cursor = Cursors.Default;
		mobjPanelButtons.Dock = DockStyle.Bottom;
		mobjPanelButtons.Location = new Point(10, 194);
		mobjPanelButtons.Margin = new Padding(0);
		mobjPanelButtons.Name = "mobjPanelButtons";
		mobjPanelButtons.Size = new Size(448, 38);
		mobjPanelButtons.TabIndex = 0;
		mobjListTopics.BackgroundImageLayout = ImageLayout.Tile;
		mobjListTopics.ClientSize = new Size(448, 387);
		mobjListTopics.Columns.AddRange(new ColumnHeader[2] { mobjColumnTitle, mobjBolumnLocation });
		mobjListTopics.Cursor = Cursors.Default;
		mobjListTopics.Dock = DockStyle.Fill;
		mobjListTopics.ItemsPerPage = 20;
		mobjListTopics.Location = new Point(10, 33);
		mobjListTopics.Margin = new Padding(0);
		mobjListTopics.MultiSelect = false;
		mobjListTopics.Name = "mobjListTopics";
		mobjListTopics.Size = new Size(448, 387);
		mobjListTopics.TabIndex = 0;
		mobjListTopics.SelectedIndexChanged += mobjListTopics_SelectedIndexChanged;
		mobjListTopics.DoubleClick += mobjListTopics_DoubleClick;
		mobjColumnTitle.Image = null;
		mobjColumnTitle.Text = "Title";
		mobjColumnTitle.Width = 230;
		mobjBolumnLocation.Image = null;
		mobjBolumnLocation.Text = "Location";
		mobjBolumnLocation.Width = 180;
		mobjButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		mobjButtonCancel.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonCancel.ClientSize = new Size(75, 23);
		mobjButtonCancel.Cursor = Cursors.Default;
		mobjButtonCancel.Location = new Point(373, 15);
		mobjButtonCancel.Margin = new Padding(0);
		mobjButtonCancel.Name = "mobjButtonCancel";
		mobjButtonCancel.Size = new Size(75, 23);
		mobjButtonCancel.TabIndex = 0;
		mobjButtonCancel.Text = "Cancel";
		mobjButtonCancel.Click += mobjButtonCancel_Click;
		mobjButtonDisplay.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		mobjButtonDisplay.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonDisplay.ClientSize = new Size(75, 23);
		mobjButtonDisplay.Cursor = Cursors.Default;
		mobjButtonDisplay.Location = new Point(292, 15);
		mobjButtonDisplay.Margin = new Padding(0);
		mobjButtonDisplay.Name = "mobjButtonDisplay";
		mobjButtonDisplay.Size = new Size(75, 23);
		mobjButtonDisplay.TabIndex = 0;
		mobjButtonDisplay.Text = "Display";
		mobjButtonDisplay.Click += mobjButtonDisplay_Click;
		mobjButtonDisplay.Enabled = false;
		base.ClientSize = new Size(468, 242);
		base.Controls.Add(mobjListTopics);
		base.Controls.Add(mobjPanelButtons);
		base.Controls.Add(mobjLabelInstructions);
		base.DockPadding.All = 10;
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Size = new Size(468, 242);
		Text = "Topics";
		ResumeLayout(blnPerformLayout: false);
	}

	private void mobjListTopics_DoubleClick(object sender, EventArgs e)
	{
		if (mobjListTopics.SelectedItem != null)
		{
			mobjSelectedItem = (IndexTopic)mobjListTopics.SelectedItem.Tag;
			mblnIsCompleted = true;
			Close();
		}
	}

	private void mobjListTopics_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (mobjListTopics.SelectedItem != null)
		{
			mobjSelectedItem = (IndexTopic)mobjListTopics.SelectedItem.Tag;
			mobjButtonDisplay.Enabled = true;
		}
		else
		{
			mobjButtonDisplay.Enabled = false;
		}
	}

	private void mobjButtonDisplay_Click(object sender, EventArgs e)
	{
		if (mobjListTopics.SelectedItem != null)
		{
			mobjSelectedItem = (IndexTopic)mobjListTopics.SelectedItem.Tag;
			mblnIsCompleted = true;
			Close();
		}
		else
		{
			mobjButtonDisplay.Enabled = false;
		}
	}

	private void mobjButtonCancel_Click(object sender, EventArgs e)
	{
		Close();
	}
}
