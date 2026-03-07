// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationTabPage
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.Administration.CustomComponents
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class AdministrationTabPage : TabPage
  {
    private AdministrationContent mobjContent;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationTabPage" /> class.
    /// </summary>
    /// <param name="objContent">Content of the object.</param>
    public AdministrationTabPage(AdministrationContent objContent)
    {
      this.InitializeTabPage();
      objContent.Dock = DockStyle.Fill;
      this.Text = objContent.ContentProperties.ContentName;
      this.Name = objContent.Name;
      this.mobjContent = objContent;
      this.Controls.Add((Control) objContent);
    }

    /// <summary>Initializes the tab page.</summary>
    private void InitializeTabPage()
    {
      this.SetFullScrean(false);
      this.ControlAdded += new ControlEventHandler(this.AdministrationTabPage_ControlAdded);
    }

    public void SetFullScrean(bool blnEnabled)
    {
      if (blnEnabled)
      {
        this.DockPadding.Top = 0;
        this.DockPadding.Left = 0;
        this.DockPadding.Right = 0;
      }
      else
      {
        this.DockPadding.Top = 50;
        this.DockPadding.Left = 50;
        this.DockPadding.Right = 50;
      }
    }

    /// <summary>Gets or sets the content.</summary>
    /// <value>The content.</value>
    public AdministrationContent Content => this.mobjContent;

    /// <summary>
    /// Handles the ControlAdded event of the AdministrationTabPage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void AdministrationTabPage_ControlAdded(object sender, ControlEventArgs e)
    {
      if (e.Control is AdministrationContent control)
        return;
      this.Controls.Remove((Control) control);
    }
  }
}
