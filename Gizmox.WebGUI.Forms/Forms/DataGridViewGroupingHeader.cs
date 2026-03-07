// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewGroupingHeader
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  public class DataGridViewGroupingHeader : UserControl
  {
    private string mstrDataPropertyName = string.Empty;
    private string mstrCurrentValue = string.Empty;
    private BindingSource mobjRowBindingSource;
    private DataGridViewRow mobjOwnerRow;
    /// <summary>Required designer variable.</summary>
    private IContainer components;
    private Label mobjHeaderLabel;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewGroupingHeader" /> class.
    /// </summary>
    public DataGridViewGroupingHeader() => this.InitializeComponent();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewGroupingHeader" /> class.
    /// </summary>
    /// <param name="strDataPropertyName">Name of the STR data property.</param>
    /// <param name="strCurrentValue">The STR current value.</param>
    /// <param name="objRowBindingSource">The obj row binding source.</param>
    public DataGridViewGroupingHeader(
      string strDataPropertyName,
      string strCurrentValue,
      BindingSource objRowBindingSource,
      DataGridViewRow objRow)
      : this()
    {
      this.mobjOwnerRow = objRow;
      this.InitializeHeader(strDataPropertyName, strCurrentValue, objRowBindingSource);
    }

    /// <summary>Initializes the header.</summary>
    /// <param name="strDataPropertyName">Name of the STR data property.</param>
    /// <param name="strCurrentValue">The STR current value.</param>
    /// <param name="objRowBindingSource">The obj row binding source.</param>
    private void InitializeHeader(
      string strDataPropertyName,
      string strCurrentValue,
      BindingSource objRowBindingSource)
    {
      this.mstrDataPropertyName = strDataPropertyName;
      this.mstrCurrentValue = strCurrentValue;
      this.mobjRowBindingSource = objRowBindingSource;
      this.UpdateHeader();
      if (this.mobjRowBindingSource == null)
        return;
      this.mobjRowBindingSource.ListChanged += new ListChangedEventHandler(this.OnListChanged);
    }

    /// <summary>
    /// Handles the ListChanged event of the objRowBindingSource control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.ComponentModel.ListChangedEventArgs" /> instance containing the event data.</param>
    private void OnListChanged(object sender, ListChangedEventArgs e) => this.UpdateHeader();

    /// <summary>Updates the header.</summary>
    private void UpdateHeader()
    {
      int intCount = this.mobjRowBindingSource != null ? this.mobjRowBindingSource.Count : -1;
      if (this.mobjOwnerRow.DataGridView == null)
        return;
      if (intCount == 0)
      {
        this.mobjOwnerRow.DataGridView.CurrentCell = (DataGridViewCell) null;
        this.mobjOwnerRow.SetVisibleInternal(false);
      }
      else
      {
        if (this.mobjOwnerRow.DataGridView.OnGroupHeaderFormatting(this.mobjHeaderLabel, this.mstrDataPropertyName, this.mstrCurrentValue, intCount, this.mobjOwnerRow).FormattingApplied)
          return;
        this.FormatLabelByDefault(this.mobjHeaderLabel, this.mstrDataPropertyName, this.mstrCurrentValue, intCount);
      }
    }

    /// <summary>Formats the label by default.</summary>
    /// <param name="objHeaderLabel">The obj header label.</param>
    /// <param name="strDataPropertyName">Name of the STR data property.</param>
    /// <param name="strValue">The STR value.</param>
    /// <param name="intCount">The int count.</param>
    private void FormatLabelByDefault(
      Label objHeaderLabel,
      string strDataPropertyName,
      string strValue,
      int intCount)
    {
      objHeaderLabel.BackColor = Color.Gray;
      objHeaderLabel.BorderStyle = BorderStyle.Fixed3D;
      objHeaderLabel.Dock = DockStyle.Fill;
      objHeaderLabel.Location = new Point(0, 0);
      objHeaderLabel.TabIndex = 0;
      if (intCount >= 0)
        objHeaderLabel.Text = string.Format("{0}: {1} ({2} item{3})", (object) this.mstrDataPropertyName, !string.IsNullOrEmpty(this.mstrCurrentValue) ? (object) ("'" + this.mstrCurrentValue + "'") : (object) "NULL", (object) intCount.ToString(), intCount > 1 ? (object) "s" : (object) string.Empty);
      else
        objHeaderLabel.Text = string.Format("{0}: {1}", (object) this.mstrDataPropertyName, !string.IsNullOrEmpty(this.mstrCurrentValue) ? (object) ("'" + this.mstrCurrentValue + "'") : (object) "NULL");
    }

    internal event GroupHeaderFormattingEventHandler GroupHeaderFormatting;

    /// <summary>Clean up any resources being used.</summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mobjHeaderLabel = new Label();
      this.SuspendLayout();
      this.mobjHeaderLabel.BackColor = Color.Gray;
      this.mobjHeaderLabel.BorderStyle = BorderStyle.Fixed3D;
      this.mobjHeaderLabel.Dock = DockStyle.Fill;
      this.mobjHeaderLabel.Location = new Point(0, 0);
      this.mobjHeaderLabel.Name = "mobjHeaderLabel";
      this.mobjHeaderLabel.Size = new Size(296, 40);
      this.mobjHeaderLabel.TabIndex = 0;
      this.Controls.Add((Control) this.mobjHeaderLabel);
      this.Size = new Size(296, 40);
      this.Text = nameof (DataGridViewGroupingHeader);
      this.ResumeLayout(false);
    }
  }
}
