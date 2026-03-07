using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Administration;
using System.Reflection;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    internal class MainContent : ContentChangeNotifierUserControl, IContentUpdateable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainContent"/> class.
        /// </summary>
        public MainContent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjDeviderPanel = new Panel();
            this.mobjAdministrationTabs = new AdministrationTabs();
            //
            // mobjDeviderPanel
            //
            mobjDeviderPanel.Dock = DockStyle.Top;
            mobjDeviderPanel.Height = 30;
            mobjDeviderPanel.BackColor = Color.Transparent;
            //
            // mobjAdministrationTabs
            //
            this.mobjAdministrationTabs.Dock = DockStyle.Fill;
            this.mobjAdministrationTabs.SelectedIndexChanged += mobjAdministrationTabs_SelectedIndexChanged;
            //
            // this
            //
            this.Load += MainContent_Load;
            this.Controls.Add(mobjAdministrationTabs);
            this.Controls.Add(mobjDeviderPanel);
        }

        /// <summary>
        /// The mobj administration tabs
        /// </summary>
        private AdministrationTabs mobjAdministrationTabs;

        /// <summary>
        /// The mobj devider panel
        /// </summary>
        private Panel mobjDeviderPanel;

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjAdministrationTabs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void mobjAdministrationTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateContentState();
        }

        internal void UpdateContentState()
        {
            AdministrationTabPage objPage = mobjAdministrationTabs.SelectedTab as AdministrationTabPage;
            if (objPage != null)
            {
                bool blnFullScreen = objPage.Content.ContentProperties.FullScreen;
                objPage.SetFullScrean(blnFullScreen);
                if (blnFullScreen)
                {
                    mobjDeviderPanel.Visible = false;
                    mobjAdministrationTabs.Appearance = TabAppearance.Logical;

                }
                else
                {
                    mobjDeviderPanel.Visible = true;
                    mobjAdministrationTabs.Appearance = TabAppearance.Normal;
                }

                //Hide Tabs if is hosted
                if (Context.Arguments["hosted"] != null && Context.Arguments["hosted"] == "1")
                {
                    mobjAdministrationTabs.Appearance = TabAppearance.Logical;
                }

            }
            OnContentChanged();
        }

        /// <summary>
        /// Handles the Load event of the MainContent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void MainContent_Load(object sender, EventArgs e)
        {
            PopulateTabs();

            RedirectByArguments();
        }

        /// <summary>
        /// Checks for "page" and "form" arguments in the querystring for redirecting to a specified page and form
        /// </summary>
        private void RedirectByArguments()
        {
            if (Context.Arguments["page"] != null)
            {
                string strPage = Context.Arguments["page"];
                foreach (AdministrationTabPage objTabPage in mobjAdministrationTabs.TabPages)
                {
                    if (objTabPage.Name == strPage.ToLower())
                    {
                        mobjAdministrationTabs.SelectedIndex = objTabPage.TabIndex;
                        mobjAdministrationTabs.Update();
                    }

                    if (Context.Arguments["form"] != null)
                    {
                        string strForm = Context.Arguments["form"];
                        objTabPage.Content.PerformAutomateAction(strForm);
                    }
                }
            }
        }


        /// <summary>
        /// Populates the tabs.
        /// </summary>
        private void PopulateTabs()
        {
            List<AdministrationContent> objAdministrationContents = GetSupportedAdministrationContent();
            objAdministrationContents.Sort(new AdministrationContent.AdministrationContentSorter());

            foreach (AdministrationContent objAdministrationContent in objAdministrationContents)
            {
                AdministrationTabPage objPage = new AdministrationTabPage(objAdministrationContent);
                mobjAdministrationTabs.TabPages.Add(objPage);
            }

        }

        /// <summary>
        /// Gets the content of the supported administration.
        /// </summary>
        /// <returns></returns>
        private List<AdministrationContent> GetSupportedAdministrationContent()
        {
            List<AdministrationContent> objAdministrationContents = new List<AdministrationContent>();
            List<Type> objSupportedTypes = GetAdministrationContentTypesList();

            foreach (Type objType in objSupportedTypes)
            {
                if (objType != null)
                {
                    AdministrationContent objAdministrationContent = Activator.CreateInstance(objType) as AdministrationContent;
                    if (objAdministrationContent != null)
                    {
                        objAdministrationContents.Add(objAdministrationContent);
                    }
                }
            }

            return objAdministrationContents;
        }

        /// <summary>
        /// Gets the administration content types list.
        /// </summary>
        /// <returns></returns>
        private List<Type> GetAdministrationContentTypesList()
        {
            List<Type> objTypes = new List<Type>();

            foreach (Type objType in this.GetType().Assembly.GetTypes())
            {
                if (!objType.IsAbstract && typeof(AdministrationContent).IsAssignableFrom(objType))
                {
                    objTypes.Add(objType);
                }
            }

            // NOTE: Emulation form node might not exist is the Ems is not installed on the client.
            Type objEmulationNodeType = GetEmulationFormNodeType();
            if (objEmulationNodeType != null)
            {
                objTypes.Add(objEmulationNodeType);
            }

            return objTypes;
        }

        /// <summary>
        /// Gets the type of the emulation form node.
        /// </summary>
        /// <returns></returns>
        private Type GetEmulationFormNodeType()
        {
            string strNodeType = string.Format("{0}, {1}", "Gizmox.WebGUI.Forms.EmulationContentControl", CommonUtils.GetFullAssemblyName("Gizmox.WebGUI.Emulation"));

            Type objEmulationrFormNodeType = Type.GetType(strNodeType);
            return objEmulationrFormNodeType;
        }

        /// <summary>
        /// Gets the name of the current content.
        /// </summary>
        /// <returns></returns>
        public override string GetCurrentContentName()
        {
            AdministrationTabPage objPage = mobjAdministrationTabs.SelectedTab as AdministrationTabPage;
            if (objPage != null)
            {
                ContentProperties objProperties = objPage.Content.ContentProperties;
                if (objProperties != null)
                {
                    if (!string.IsNullOrEmpty(objProperties.ContentName))
                    {
                        if (!string.IsNullOrEmpty(objProperties.ContentDescription))
                        {
                            return string.Format("{0} - {1}", objProperties.ContentName, objProperties.ContentDescription);
                        }
                        else
                        {
                            return string.Format("{0}", objProperties.ContentName);
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        void IContentUpdateable.UpdateContent()
        {
            this.UpdateContentState();
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <returns></returns>
        public override List<StatusData> GetStatus()
        {
            AdministrationTabPage objPage = mobjAdministrationTabs.SelectedTab as AdministrationTabPage;
            if (objPage != null)
            {
                ContentProperties objProperties = objPage.Content.ContentProperties;
                return objProperties.StatusData;
            }

            return null;
        }
    }
}
