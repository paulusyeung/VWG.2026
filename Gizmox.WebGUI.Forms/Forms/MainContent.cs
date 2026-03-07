// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MainContent
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
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
  internal class MainContent : ContentChangeNotifierUserControl, IContentUpdateable
  {
    /// <summary>The mobj administration tabs</summary>
    private AdministrationTabs mobjAdministrationTabs;
    /// <summary>The mobj devider panel</summary>
    private Panel mobjDeviderPanel;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MainContent" /> class.
    /// </summary>
    public MainContent() => this.InitializeComponent();

    /// <summary>Initializes the component.</summary>
    private void InitializeComponent()
    {
      this.mobjDeviderPanel = new Panel();
      this.mobjAdministrationTabs = new AdministrationTabs();
      this.mobjDeviderPanel.Dock = DockStyle.Top;
      this.mobjDeviderPanel.Height = 30;
      this.mobjDeviderPanel.BackColor = Color.Transparent;
      this.mobjAdministrationTabs.Dock = DockStyle.Fill;
      this.mobjAdministrationTabs.SelectedIndexChanged += new EventHandler(this.mobjAdministrationTabs_SelectedIndexChanged);
      this.Load += new EventHandler(this.MainContent_Load);
      this.Controls.Add((Control) this.mobjAdministrationTabs);
      this.Controls.Add((Control) this.mobjDeviderPanel);
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the mobjAdministrationTabs control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjAdministrationTabs_SelectedIndexChanged(object sender, EventArgs e) => this.UpdateContentState();

    internal void UpdateContentState()
    {
      if (this.mobjAdministrationTabs.SelectedTab is AdministrationTabPage selectedTab)
      {
        bool fullScreen = selectedTab.Content.ContentProperties.FullScreen;
        selectedTab.SetFullScrean(fullScreen);
        if (fullScreen)
        {
          this.mobjDeviderPanel.Visible = false;
          this.mobjAdministrationTabs.Appearance = TabAppearance.Logical;
        }
        else
        {
          this.mobjDeviderPanel.Visible = true;
          this.mobjAdministrationTabs.Appearance = TabAppearance.Normal;
        }
        if (this.Context.Arguments["hosted"] != null && this.Context.Arguments["hosted"] == "1")
          this.mobjAdministrationTabs.Appearance = TabAppearance.Logical;
      }
      this.OnContentChanged();
    }

    /// <summary>Handles the Load event of the MainContent control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void MainContent_Load(object sender, EventArgs e)
    {
      this.PopulateTabs();
      this.RedirectByArguments();
    }

    /// <summary>
    /// Checks for "page" and "form" arguments in the querystring for redirecting to a specified page and form
    /// </summary>
    private void RedirectByArguments()
    {
      if (this.Context.Arguments["page"] == null)
        return;
      string str = this.Context.Arguments["page"];
      foreach (AdministrationTabPage tabPage in this.mobjAdministrationTabs.TabPages)
      {
        if (tabPage.Name == str.ToLower())
        {
          this.mobjAdministrationTabs.SelectedIndex = tabPage.TabIndex;
          this.mobjAdministrationTabs.Update();
        }
        if (this.Context.Arguments["form"] != null)
        {
          string objData = this.Context.Arguments["form"];
          tabPage.Content.PerformAutomateAction((object) objData);
        }
      }
    }

    /// <summary>Populates the tabs.</summary>
    private void PopulateTabs()
    {
      List<AdministrationContent> administrationContent = this.GetSupportedAdministrationContent();
      administrationContent.Sort((IComparer<AdministrationContent>) new AdministrationContent.AdministrationContentSorter());
      foreach (AdministrationContent objContent in administrationContent)
        this.mobjAdministrationTabs.TabPages.Add((TabPage) new AdministrationTabPage(objContent));
    }

    /// <summary>Gets the content of the supported administration.</summary>
    /// <returns></returns>
    private List<AdministrationContent> GetSupportedAdministrationContent()
    {
      List<AdministrationContent> administrationContent = new List<AdministrationContent>();
      foreach (Type administrationContentTypes in this.GetAdministrationContentTypesList())
      {
        if (administrationContentTypes != (Type) null && Activator.CreateInstance(administrationContentTypes) is AdministrationContent instance)
          administrationContent.Add(instance);
      }
      return administrationContent;
    }

    /// <summary>Gets the administration content types list.</summary>
    /// <returns></returns>
    private List<Type> GetAdministrationContentTypesList()
    {
      List<Type> contentTypesList = new List<Type>();
      foreach (Type type in this.GetType().Assembly.GetTypes())
      {
        if (!type.IsAbstract && typeof (AdministrationContent).IsAssignableFrom(type))
          contentTypesList.Add(type);
      }
      Type emulationFormNodeType = this.GetEmulationFormNodeType();
      if (emulationFormNodeType != (Type) null)
        contentTypesList.Add(emulationFormNodeType);
      return contentTypesList;
    }

    /// <summary>Gets the type of the emulation form node.</summary>
    /// <returns></returns>
    private Type GetEmulationFormNodeType() => Type.GetType(string.Format("{0}, {1}", (object) "Gizmox.WebGUI.Forms.EmulationContentControl", (object) CommonUtils.GetFullAssemblyName("Gizmox.WebGUI.Emulation")));

    /// <summary>Gets the name of the current content.</summary>
    /// <returns></returns>
    public override string GetCurrentContentName()
    {
      if (this.mobjAdministrationTabs.SelectedTab is AdministrationTabPage selectedTab)
      {
        ContentProperties contentProperties = selectedTab.Content.ContentProperties;
        if (contentProperties != null && !string.IsNullOrEmpty(contentProperties.ContentName))
          return !string.IsNullOrEmpty(contentProperties.ContentDescription) ? string.Format("{0} - {1}", (object) contentProperties.ContentName, (object) contentProperties.ContentDescription) : string.Format("{0}", (object) contentProperties.ContentName);
      }
      return string.Empty;
    }

    /// <summary>Updates the content.</summary>
    void IContentUpdateable.UpdateContent() => this.UpdateContentState();

    /// <summary>Gets the status.</summary>
    /// <returns></returns>
    public override List<StatusData> GetStatus() => this.mobjAdministrationTabs.SelectedTab is AdministrationTabPage selectedTab ? selectedTab.Content.ContentProperties.StatusData : (List<StatusData>) null;
  }
}
