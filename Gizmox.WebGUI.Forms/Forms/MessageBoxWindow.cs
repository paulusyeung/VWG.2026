// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MessageBoxWindow
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Implementation of MessageBoxWindow class.</summary>
  [Serializable]
  public class MessageBoxWindow : Form
  {
    private TableLayoutPanel mobjButtonsLayout;
    private Panel mobjIconLayout;
    private PictureBox mobjIcon;
    private Label mobjLabelText;
    private Button mobjButton1;
    private Button mobjButton2;
    private Button mobjButton3;
    private MessageBoxDefaultButton menmDefaultButton;
    /// <summary>Required designer variable.</summary>
    [NonSerialized]
    private System.ComponentModel.Container components;
    private double mintXFactor = 5.7;
    private double mintYFactor = 15.0;
    private MessageBoxButtons menmButtons;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MessageBoxWindow" /> instance.
    /// </summary>
    internal MessageBoxWindow(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions)
      : this((Form) Global.Context.ActiveForm, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions)
    {
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MessageBoxWindow" /> instance.
    /// </summary>
    internal MessageBoxWindow(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions)
      : base(objOwner.Context)
    {
      this.InitializeComponent();
      this.menmButtons = enmButtons;
      this.menmDefaultButton = enmDefaultButton;
      int num1 = 0;
      this.AddTableLayoutRowStyle(this.mobjButtonsLayout, new RowStyle(SizeType.Absolute, 26f));
      this.AddTableLayoutColumnStyle(this.mobjButtonsLayout, new ColumnStyle(SizeType.Percent, 50f));
      int num2 = num1 + 1;
      this.AcceptButton = this.CancelButton = (IButtonControl) null;
      this.mobjButton1 = (Button) new MessageBoxWindow.MessageBoxButton();
      switch (this.menmButtons)
      {
        case MessageBoxButtons.OK:
          this.mobjButton1.Text = WGLabels.Ok;
          this.mobjButton1.DialogResult = DialogResult.OK;
          this.AcceptButton = (IButtonControl) this.mobjButton1;
          this.CancelButton = (IButtonControl) this.mobjButton1;
          break;
        case MessageBoxButtons.OKCancel:
          this.mobjButton1.Text = WGLabels.Ok;
          this.mobjButton1.DialogResult = DialogResult.OK;
          this.AcceptButton = (IButtonControl) this.mobjButton1;
          break;
        case MessageBoxButtons.AbortRetryIgnore:
          this.mobjButton1.Text = WGLabels.Abort;
          this.mobjButton1.DialogResult = DialogResult.Abort;
          break;
        case MessageBoxButtons.YesNoCancel:
        case MessageBoxButtons.YesNo:
          this.mobjButton1.Text = WGLabels.Yes;
          this.mobjButton1.DialogResult = DialogResult.Yes;
          this.mobjButton3 = (Button) null;
          break;
        case MessageBoxButtons.RetryCancel:
          this.mobjButton1.Text = WGLabels.Retry;
          this.mobjButton1.DialogResult = DialogResult.Retry;
          break;
      }
      this.AddTableLayoutColumnStyle(this.mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 76f));
      this.mobjButtonsLayout.Controls.Add((Control) this.mobjButton1, 1, 0);
      if (this.menmButtons != MessageBoxButtons.OK)
      {
        ++num2;
        this.mobjButton2 = (Button) new MessageBoxWindow.MessageBoxButton();
        switch (this.menmButtons)
        {
          case MessageBoxButtons.OKCancel:
          case MessageBoxButtons.RetryCancel:
            this.mobjButton2.Text = WGLabels.Cancel;
            this.mobjButton2.DialogResult = DialogResult.Cancel;
            this.CancelButton = (IButtonControl) this.mobjButton2;
            break;
          case MessageBoxButtons.AbortRetryIgnore:
            this.mobjButton2.Text = WGLabels.Retry;
            this.mobjButton2.DialogResult = DialogResult.Retry;
            break;
          case MessageBoxButtons.YesNoCancel:
          case MessageBoxButtons.YesNo:
            this.mobjButton2.Text = WGLabels.No;
            this.mobjButton2.DialogResult = DialogResult.No;
            break;
        }
        this.AddTableLayoutColumnStyle(this.mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 6f));
        this.AddTableLayoutColumnStyle(this.mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 76f));
        this.mobjButtonsLayout.Controls.Add((Control) this.mobjButton2, 3, 0);
      }
      if (this.menmButtons == MessageBoxButtons.AbortRetryIgnore || this.menmButtons == MessageBoxButtons.YesNoCancel)
      {
        int num3 = num2 + 1;
        this.mobjButton3 = (Button) new MessageBoxWindow.MessageBoxButton();
        switch (this.menmButtons)
        {
          case MessageBoxButtons.AbortRetryIgnore:
            this.mobjButton3.Text = WGLabels.Ignore;
            this.mobjButton3.DialogResult = DialogResult.Ignore;
            break;
          case MessageBoxButtons.YesNoCancel:
            this.mobjButton3.Text = WGLabels.Cancel;
            this.mobjButton3.DialogResult = DialogResult.Cancel;
            this.CancelButton = (IButtonControl) this.mobjButton3;
            break;
        }
        this.AddTableLayoutColumnStyle(this.mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 6f));
        this.AddTableLayoutColumnStyle(this.mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 76f));
        this.mobjButtonsLayout.Controls.Add((Control) this.mobjButton3, 5, 0);
      }
      this.AddTableLayoutColumnStyle(this.mobjButtonsLayout, new ColumnStyle(SizeType.Percent, 50f));
      if (enmIcon != MessageBoxIcon.None)
      {
        this.mobjLabelText.Text = enmIcon.ToString();
        this.mobjIcon.Image = (ResourceHandle) new SkinResourceHandle(typeof (MessageBox), enmIcon.ToString() + ".gif");
      }
      else
        this.Controls.Remove((Control) this.mobjIconLayout);
      this.mobjLabelText.Text = strText;
      this.Text = strCaption;
      if (this.Context != null && this.Context.MainForm != null)
        objOwner = this.Context.MainForm as Form;
      Size stringMeasurements = CommonUtils.GetStringMeasurements(strText, this.mobjLabelText.Font, objOwner.Width - (enmIcon == MessageBoxIcon.None ? 0 : this.mobjIcon.Width));
      int width = Math.Max(this.GetMinimalWidthForButtonsLayout(), stringMeasurements.Width) + (enmIcon == MessageBoxIcon.None ? 0 : this.mobjIconLayout.Width) + this.Padding.All * 2;
      int height = this.mobjButtonsLayout.Height + Math.Max(enmIcon == MessageBoxIcon.None ? 0 : this.mobjIcon.Height, stringMeasurements.Height) + 50;
      this.SuspendLayout();
      this.Size = new Size(width, height);
      this.ClientSize = new Size(width, height);
      this.ResumeLayout(false);
      if (enmButtons == MessageBoxButtons.YesNo || enmButtons == MessageBoxButtons.AbortRetryIgnore)
        this.CloseBox = false;
      this.Load += new EventHandler(this.Form_Load);
    }

    private void Form_Load(object sender, EventArgs e)
    {
      Button button = (Button) null;
      switch (this.menmDefaultButton)
      {
        case MessageBoxDefaultButton.Button1:
          button = this.mobjButton1;
          break;
        case MessageBoxDefaultButton.Button2:
          button = this.mobjButton2;
          break;
        case MessageBoxDefaultButton.Button3:
          button = this.mobjButton3;
          break;
      }
      button?.Focus();
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mobjButtonsLayout = new TableLayoutPanel();
      this.mobjIconLayout = new Panel();
      this.mobjIcon = new PictureBox();
      this.mobjLabelText = new Label();
      this.mobjIconLayout.SuspendLayout();
      this.SuspendLayout();
      this.mobjButtonsLayout.Dock = DockStyle.Bottom;
      this.mobjButtonsLayout.Location = new Point(10, 85);
      this.mobjButtonsLayout.Name = "mobjButtonsLayout";
      this.mobjButtonsLayout.Size = new Size(460, 26);
      this.mobjButtonsLayout.TabIndex = 0;
      this.mobjIconLayout.Controls.Add((Control) this.mobjIcon);
      this.mobjIconLayout.Dock = DockStyle.Left;
      this.mobjIconLayout.Location = new Point(10, 10);
      this.mobjIconLayout.Name = "mobjIconLayout";
      this.mobjIconLayout.Size = new Size(50, 75);
      this.mobjIconLayout.TabIndex = 1;
      this.mobjIcon.Location = new Point(9, 15);
      this.mobjIcon.Name = "mobjIcon";
      this.mobjIcon.Size = new Size(32, 32);
      this.mobjIcon.TabIndex = 0;
      this.mobjIcon.TabStop = false;
      this.mobjLabelText.Dock = DockStyle.Fill;
      this.mobjLabelText.Location = new Point(60, 10);
      this.mobjLabelText.Name = "mobjLabelText";
      this.mobjLabelText.Size = new Size(410, 75);
      this.mobjLabelText.TabIndex = 2;
      this.mobjLabelText.TextAlign = ContentAlignment.MiddleLeft;
      this.mobjLabelText.UseMnemonic = false;
      this.ClientSize = new Size(480, 125);
      this.Controls.Add((Control) this.mobjLabelText);
      this.Controls.Add((Control) this.mobjIconLayout);
      this.Controls.Add((Control) this.mobjButtonsLayout);
      this.DockPadding.All = 10;
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (MessageBoxWindow);
      this.mobjIconLayout.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    /// <summary>Adds the table layout column style.</summary>
    /// <param name="objTableLayoutPanel">The obj table layout panel.</param>
    /// <param name="objColumnStyle">The obj column style.</param>
    private void AddTableLayoutColumnStyle(
      TableLayoutPanel objTableLayoutPanel,
      ColumnStyle objColumnStyle)
    {
      if (objTableLayoutPanel == null || objColumnStyle == null)
        return;
      objTableLayoutPanel.ColumnStyles.Add(objColumnStyle);
      ++objTableLayoutPanel.ColumnCount;
    }

    /// <summary>Adds the table layout row style.</summary>
    /// <param name="objTableLayoutPanel">The obj table layout panel.</param>
    /// <param name="objRowStyle">The obj row style.</param>
    private void AddTableLayoutRowStyle(TableLayoutPanel objTableLayoutPanel, RowStyle objRowStyle)
    {
      if (objTableLayoutPanel == null || objRowStyle == null)
        return;
      objTableLayoutPanel.RowStyles.Add(objRowStyle);
      ++objTableLayoutPanel.RowCount;
    }

    /// <summary>Gets the minimal width for the buttons layout.</summary>
    /// <returns></returns>
    private int GetMinimalWidthForButtonsLayout()
    {
      int forButtonsLayout = 0;
      if (this.mobjButtonsLayout != null)
      {
        foreach (ColumnStyle columnStyle in (IEnumerable) this.mobjButtonsLayout.ColumnStyles)
          forButtonsLayout += Convert.ToInt32(columnStyle.Width);
      }
      return forButtonsLayout;
    }

    [ToolboxItem(false)]
    [Serializable]
    internal class MessageBoxButton : Button
    {
      private bool mblnUserClick;

      protected override void FireEvent(IEvent objEvent)
      {
        if (objEvent.Type == "Click")
          this.mblnUserClick = true;
        base.FireEvent(objEvent);
        if (!(objEvent.Type == "Click"))
          return;
        this.mblnUserClick = false;
      }

      public bool UserClick
      {
        get => this.mblnUserClick;
        set => this.mblnUserClick = value;
      }
    }
  }
}
