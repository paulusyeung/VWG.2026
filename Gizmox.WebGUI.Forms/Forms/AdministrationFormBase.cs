// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.AdministrationFormBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.VisualEffects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  internal abstract class AdministrationFormBase : Form, IAdministrationForm
  {
    /// <summary>Required designer variable.</summary>
    private IContainer components;
    private PictureBox mobjLogo;
    private PictureBox mobjFooterLogo;
    private AdministrationFooterPanel mobjFooterPanelTop;
    private Panel mobjTopPanel;
    private Panel mobjFooterPanel;
    private AdministrationHeaderLabel mobjHeaderLabel;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.AdministrationFormBase" /> class.
    /// </summary>
    public AdministrationFormBase()
    {
      ContentChangeNotifierUserControl content = this.GetContent();
      if (content == null)
        throw new Exception();
      content.Dock = DockStyle.Fill;
      this.Controls.Add((Control) content);
      this.InitializeComponent();
      content.ContentChanged += new EventHandler(this.objContent_ContentChanged);
      content.Load += new EventHandler(this.objContent_Load);
    }

    /// <summary>Handles the Load event of the objContent control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objContent_Load(object sender, EventArgs e)
    {
      this.UpdateContent(sender as ContentChangeNotifierUserControl);
      if (this.Context.Arguments["hosted"] == null || !(this.Context.Arguments["hosted"] == "1"))
        return;
      this.HidePanels();
    }

    /// <summary>Hide the header and footer panels</summary>
    protected void HidePanels()
    {
      this.mobjFooterPanel.Visible = false;
      this.mobjTopPanel.Visible = false;
    }

    /// <summary>Objects the content_ content changed.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    private void objContent_ContentChanged(object sender, EventArgs e) => this.UpdateContent(sender as ContentChangeNotifierUserControl);

    /// <summary>Updates the content.</summary>
    /// <param name="objControl">The object control.</param>
    private void UpdateContent(ContentChangeNotifierUserControl objControl)
    {
      string str = string.Empty;
      List<StatusData> objDatas = (List<StatusData>) null;
      if (objControl != null)
      {
        str = objControl.GetCurrentContentName();
        objDatas = objControl.GetStatus();
      }
      this.mobjHeaderLabel.Text = str;
      this.mobjFooterPanelTop.SetLabels(objDatas);
    }

    /// <summary>Gets the content.</summary>
    /// <returns></returns>
    public abstract ContentChangeNotifierUserControl GetContent();

    /// <summary>Clean up any resources being used.</summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.mobjLogo = new PictureBox();
      this.mobjFooterLogo = new PictureBox();
      this.mobjTopPanel = new Panel();
      this.mobjFooterPanelTop = new AdministrationFooterPanel();
      this.mobjFooterPanel = new Panel();
      this.mobjHeaderLabel = new AdministrationHeaderLabel();
      this.mobjFooterPanelTop.Height = 30;
      this.mobjFooterPanelTop.Controls.Add((Control) this.mobjFooterLogo);
      this.mobjFooterPanelTop.Dock = DockStyle.Top;
      this.mobjFooterPanelTop.BorderWidth = new BorderWidth(0, 0, 0, 1);
      this.mobjFooterPanelTop.BorderColor = (BorderColor) Color.LightGray;
      this.mobjFooterPanelTop.BorderStyle = BorderStyle.FixedSingle;
      this.mobjFooterPanelTop.DockPadding.Right = 50;
      this.mobjFooterPanelTop.DockPadding.Left = 3;
      this.mobjFooterPanelTop.DockPadding.Top = 3;
      this.mobjFooterLogo.Image = (ResourceHandle) new AssemblyResourceHandle(typeof (AdministrationFormBase), "Resources.LogoBottom.png");
      this.mobjFooterLogo.Dock = DockStyle.Right;
      this.mobjFooterLogo.Width = 216;
      this.mobjHeaderLabel.Dock = DockStyle.Fill;
      this.mobjHeaderLabel.TextAlign = ContentAlignment.BottomLeft;
      this.mobjLogo.Image = (ResourceHandle) new AssemblyResourceHandle(typeof (AdministrationFormBase), "Resources.LogoTop.png");
      this.mobjLogo.Dock = DockStyle.Left;
      this.mobjLogo.Width = 236;
      this.mobjFooterPanel.Dock = DockStyle.Bottom;
      this.mobjFooterPanel.Height = 50;
      this.mobjFooterPanel.Controls.Add((Control) this.mobjFooterPanelTop);
      this.mobjTopPanel.Dock = DockStyle.Top;
      this.mobjTopPanel.Height = 64;
      this.mobjTopPanel.Controls.Add((Control) this.mobjHeaderLabel);
      this.mobjTopPanel.Controls.Add((Control) this.mobjLogo);
      this.mobjTopPanel.VisualEffect = (VisualEffect) new BoxShadowVisualEffect(0, 5, 35, 0, Color.FromArgb(1, 68, 68, 68), false);
      this.mobjTopPanel.DockPadding.Top = 17;
      this.mobjTopPanel.DockPadding.Bottom = 17;
      this.mobjTopPanel.DockPadding.Left = 50;
      this.Text = "Administration";
      this.Controls.Add((Control) this.mobjTopPanel);
      this.Controls.Add((Control) this.mobjFooterPanel);
    }
  }
}
