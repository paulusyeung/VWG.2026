// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Controls.ItemChooser
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Controls
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ItemChooser : UserControl
  {
    private Button mobjButtonMoveUp;
    private Button mobjButtonMoveDown;
    private Button mobjButtonShow;
    private Panel mobjPanelButtons;
    private Button mobjButtonHide;
    private CheckedListBox mobjListItems;

    /// <summary>Occurs when an item is selected</summary>
    public event EventHandler ItemSelected;

    /// <summary>Occurs when an item is checked</summary>
    public event ItemCheckHandler ItemCheck;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Controls.ItemChooser" /> instance.
    /// </summary>
    public ItemChooser()
    {
      this.InitializeComponent();
      this.mobjButtonMoveUp.Click += new EventHandler(this.mobjButtonMoveUp_Click);
      this.mobjButtonMoveDown.Click += new EventHandler(this.mobjButtonMoveDown_Click);
      this.mobjButtonShow.Click += new EventHandler(this.mobjButtonShow_Click);
      this.mobjButtonHide.Click += new EventHandler(this.mobjButtonHide_Click);
      this.mobjListItems.SelectedIndexChanged += new EventHandler(this.mobjListItems_SelectedIndexChanged);
      this.mobjListItems.ItemCheck += new ItemCheckHandler(this.mobjListItems_ItemCheck);
      this.mobjButtonHide.Text = WGLabels.Hide;
      this.mobjButtonMoveDown.Text = WGLabels.MoveDown;
      this.mobjButtonMoveUp.Text = WGLabels.MoveUp;
      this.mobjButtonShow.Text = WGLabels.Show;
      this.mobjListItems.DisplayMember = "Text";
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mobjListItems = new CheckedListBox();
      this.mobjPanelButtons = new Panel();
      this.mobjButtonMoveUp = new Button();
      this.mobjButtonMoveDown = new Button();
      this.mobjButtonShow = new Button();
      this.mobjButtonHide = new Button();
      this.mobjPanelButtons.SuspendLayout();
      this.SuspendLayout();
      this.mobjListItems.Dock = DockStyle.Fill;
      this.mobjListItems.Location = new Point(0, 0);
      this.mobjListItems.Name = "mobjListItems";
      this.mobjListItems.Size = new Size(821, 454);
      this.mobjListItems.TabIndex = 0;
      this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonHide);
      this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonShow);
      this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonMoveDown);
      this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonMoveUp);
      this.mobjPanelButtons.Dock = DockStyle.Right;
      this.mobjPanelButtons.Location = new Point(710, 0);
      this.mobjPanelButtons.Name = "mobjPanelButtons";
      this.mobjPanelButtons.Size = new Size(111, 454);
      this.mobjPanelButtons.TabIndex = 1;
      this.mobjButtonHide.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
      this.mobjButtonHide.Location = new Point(4, 87);
      this.mobjButtonHide.Name = "mobjButtonHide";
      this.mobjButtonHide.Size = new Size(103, 23);
      this.mobjButtonHide.TabIndex = 3;
      this.mobjButtonHide.Text = "Hide";
      this.mobjButtonShow.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
      this.mobjButtonShow.Location = new Point(4, 58);
      this.mobjButtonShow.Name = "mobjButtonShow";
      this.mobjButtonShow.Size = new Size(103, 23);
      this.mobjButtonShow.TabIndex = 2;
      this.mobjButtonShow.Text = "Show";
      this.mobjButtonMoveDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
      this.mobjButtonMoveDown.Location = new Point(4, 29);
      this.mobjButtonMoveDown.Name = "mobjButtonMoveDown";
      this.mobjButtonMoveDown.Size = new Size(103, 23);
      this.mobjButtonMoveDown.TabIndex = 1;
      this.mobjButtonMoveDown.Text = "Move Down";
      this.mobjButtonMoveUp.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
      this.mobjButtonMoveUp.Location = new Point(4, 0);
      this.mobjButtonMoveUp.Name = "mobjButtonMoveUp";
      this.mobjButtonMoveUp.Size = new Size(103, 23);
      this.mobjButtonMoveUp.TabIndex = 0;
      this.mobjButtonMoveUp.Text = "Move Up";
      this.Controls.Add((Control) this.mobjListItems);
      this.Controls.Add((Control) this.mobjPanelButtons);
      this.Name = nameof (ItemChooser);
      this.Size = new Size(320, 190);
      this.mobjPanelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    /// <summary>Updates the state of the buttons.</summary>
    public void UpdateButtonsState()
    {
      int selectedIndex = this.mobjListItems.SelectedIndex;
      int num = this.mobjListItems.Items.Count - 1;
      bool itemChecked = this.mobjListItems.GetItemChecked(selectedIndex);
      this.mobjButtonMoveUp.Enabled = selectedIndex != 0;
      this.mobjButtonMoveDown.Enabled = selectedIndex != num;
      this.mobjButtonHide.Enabled = itemChecked;
      this.mobjButtonShow.Enabled = !itemChecked;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjButtonHide_Click(object sender, EventArgs e)
    {
      this.mobjListItems.SetItemChecked(this.mobjListItems.SelectedIndex, false);
      this.UpdateButtonsState();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjButtonShow_Click(object sender, EventArgs e)
    {
      this.mobjListItems.SetItemChecked(this.mobjListItems.SelectedIndex, true);
      this.UpdateButtonsState();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjButtonMoveUp_Click(object sender, EventArgs e)
    {
      if (this.mobjListItems.SelectedIndex > 0)
        this.mobjListItems.SwapItems(this.mobjListItems.SelectedIndex, this.mobjListItems.SelectedIndex - 1);
      this.UpdateButtonsState();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjButtonMoveDown_Click(object sender, EventArgs e)
    {
      if (this.mobjListItems.SelectedIndex < this.mobjListItems.Items.Count - 1)
        this.mobjListItems.SwapItems(this.mobjListItems.SelectedIndex, this.mobjListItems.SelectedIndex + 1);
      this.UpdateButtonsState();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mobjListItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateButtonsState();
      if (this.ItemSelected == null)
        return;
      this.ItemSelected((object) this, new EventArgs());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objSender"></param>
    /// <param name="objArgs"></param>
    private void mobjListItems_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
    {
      if (this.ItemCheck != null)
        this.ItemCheck(objSender, objArgs);
      this.UpdateButtonsState();
    }

    /// <summary>Gets the selected item.</summary>
    /// <value></value>
    public object SelectedItem => this.mobjListItems.SelectedItem;

    /// <summary>Gets or sets the items collection.</summary>
    /// <value></value>
    public ICollection Items
    {
      get => (ICollection) this.mobjListItems.Items;
      set
      {
        this.mobjListItems.Items.AddRange(value);
        if (this.mobjListItems.Items.Count <= 0)
          return;
        this.mobjListItems.SelectedIndex = 0;
      }
    }

    /// <summary>Gets or sets the checked collection.</summary>
    /// <value></value>
    public ICollection Checked
    {
      get
      {
        ArrayList arrayList = new ArrayList();
        foreach (object objItem in (ListBox.ObjectCollection) this.mobjListItems.Items)
        {
          int intIndex = this.mobjListItems.Items.IndexOf(objItem);
          if (intIndex != -1 && this.mobjListItems.GetItemChecked(intIndex))
            arrayList.Add(objItem);
        }
        return (ICollection) arrayList;
      }
      set
      {
        foreach (object objItem in (IEnumerable) value)
        {
          int intIndex = this.mobjListItems.Items.IndexOf(objItem);
          if (intIndex != -1)
            this.mobjListItems.SetItemChecked(intIndex, true);
        }
      }
    }

    /// <summary>Gets or sets the check label.</summary>
    /// <value></value>
    public string CheckLabel
    {
      get => this.mobjButtonShow.Text;
      set => this.mobjButtonShow.Text = value;
    }

    /// <summary>Gets or sets the uncheck label.</summary>
    /// <value></value>
    public string UncheckLabel
    {
      get => this.mobjButtonHide.Text;
      set => this.mobjButtonHide.Text = value;
    }

    /// <summary>Gets or sets the moveup label.</summary>
    /// <value></value>
    public string MoveUpLabel
    {
      get => this.mobjButtonMoveUp.Text;
      set => this.mobjButtonMoveUp.Text = value;
    }

    /// <summary>Gets or sets the move down label.</summary>
    /// <value></value>
    public string MoveDownLabel
    {
      get => this.mobjButtonMoveDown.Text;
      set => this.mobjButtonMoveDown.Text = value;
    }
  }
}
