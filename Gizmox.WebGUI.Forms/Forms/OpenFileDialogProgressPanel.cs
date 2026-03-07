// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.OpenFileDialogProgressPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A Panel control</summary>
  [ToolboxItem(false)]
  [Serializable]
  internal class OpenFileDialogProgressPanel : Form
  {
    private IRegisteredComponent mobjContainerComponent;
    private TableLayoutPanel mobjLayout;
    private ProgressBar mobjFileProgress;
    private ProgressBar mobjTotalProgress;
    private Label mobjFileProgressLabel;
    private Label mobjTotalProgressLabel;
    private PictureBox pictureBox1;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.OpenFileDialogProgressPanel" /> class.
    /// </summary>
    /// <param name="objComponent">The object component.</param>
    public OpenFileDialogProgressPanel(IRegisteredComponent objComponent)
    {
      this.mobjContainerComponent = objComponent;
      this.InitialzieComponent();
    }

    /// <summary>Initialzies the component.</summary>
    private void InitialzieComponent()
    {
      this.mobjLayout = new TableLayoutPanel();
      this.mobjFileProgress = new ProgressBar();
      this.mobjTotalProgress = new ProgressBar();
      this.mobjFileProgressLabel = new Label();
      this.mobjTotalProgressLabel = new Label();
      this.pictureBox1 = new PictureBox();
      this.mobjLayout.SuspendLayout();
      this.SuspendLayout();
      this.mobjLayout.BorderColor = Color.FromArgb(101, 147, 207);
      this.mobjLayout.ColumnCount = 3;
      this.mobjLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
      this.mobjLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80f));
      this.mobjLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
      this.mobjLayout.Controls.Add((Control) this.mobjFileProgress, 1, 2);
      this.mobjLayout.Controls.Add((Control) this.mobjTotalProgress, 1, 5);
      this.mobjLayout.Controls.Add((Control) this.mobjFileProgressLabel, 1, 1);
      this.mobjLayout.Controls.Add((Control) this.mobjTotalProgressLabel, 1, 4);
      this.mobjLayout.Controls.Add((Control) this.pictureBox1, 1, 0);
      this.mobjLayout.Dock = DockStyle.Fill;
      this.mobjLayout.Location = new Point(0, 0);
      this.mobjLayout.Name = "tableLayoutPanel1";
      this.mobjLayout.RowCount = 7;
      this.mobjLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60f));
      this.mobjLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.mobjLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.mobjLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
      this.mobjLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.mobjLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.mobjLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30f));
      this.mobjLayout.Size = new Size(620, 474);
      this.mobjLayout.TabIndex = 0;
      this.mobjFileProgress.Dock = DockStyle.Fill;
      this.mobjFileProgress.Location = new Point(62, 195);
      this.mobjFileProgress.Name = "progressBar1";
      this.mobjFileProgress.Size = new Size(496, 20);
      this.mobjFileProgress.TabIndex = 0;
      this.mobjTotalProgress.Dock = DockStyle.Fill;
      this.mobjTotalProgress.Location = new Point(62, 278);
      this.mobjTotalProgress.Name = "progressBar2";
      this.mobjTotalProgress.Size = new Size(496, 20);
      this.mobjTotalProgress.TabIndex = 0;
      this.mobjFileProgressLabel.AutoSize = true;
      this.mobjFileProgressLabel.Dock = DockStyle.Fill;
      this.mobjFileProgressLabel.Location = new Point(62, 175);
      this.mobjFileProgressLabel.Name = "label1";
      this.mobjFileProgressLabel.Size = new Size(496, 20);
      this.mobjFileProgressLabel.TabIndex = 0;
      this.mobjFileProgressLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.mobjTotalProgressLabel.AutoSize = true;
      this.mobjTotalProgressLabel.Dock = DockStyle.Fill;
      this.mobjTotalProgressLabel.Location = new Point(62, 258);
      this.mobjTotalProgressLabel.Name = "label2";
      this.mobjTotalProgressLabel.Size = new Size(496, 20);
      this.mobjTotalProgressLabel.TabIndex = 0;
      this.mobjTotalProgressLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.pictureBox1.Dock = DockStyle.Bottom;
      this.pictureBox1.Location = new Point(62, 99);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(496, 56);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Image = (ResourceHandle) new SkinResourceHandle(typeof (OpenFileDialogSkin), "Uploading.gif");
      this.Visible = true;
      this.TopLevel = false;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Controls.Add((Control) this.mobjLayout);
      this.Size = new Size(620, 474);
      this.mobjLayout.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    /// <summary>Pre-render control.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
    {
      if (this.mobjContainerComponent != null && this.mobjContainerComponent.IsRegistered)
      {
        long id = this.mobjContainerComponent.ID;
        this.mobjFileProgress.ClientId = string.Format("FileProgress_{0}", (object) id);
        this.mobjTotalProgress.ClientId = string.Format("TotalProgress_{0}", (object) id);
        this.mobjFileProgressLabel.ClientId = string.Format("FileLabel_{0}", (object) id);
        this.mobjTotalProgressLabel.ClientId = string.Format("TotalLabel_{0}", (object) id);
      }
      base.PreRenderControl(objContext, lngRequestID);
    }
  }
}
