using Gizmox.WebGUI.Client;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{
    public class VisualTemplateEditor : UITypeEditor
    {
        private static WebGUIForms.Component mobjEditingComponent;

        private VisualTemplateService mobjVisualTemplateService = new VisualTemplateService();

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTemplateEditor"/> class.
        /// </summary>
        public VisualTemplateEditor()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTemplateEditor"/> class.
        /// </summary>
        /// <param name="objType">Type of the object.</param>
        public VisualTemplateEditor(Type objType)
            : base()
        {

        }

        /// <summary>
        /// Gets the editing component.
        /// </summary>
        public static WebGUIForms.Component EditingComponent
        {
            get
            {
                return mobjEditingComponent;
            }
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue)
        {
            VisualTemplatesTypeConverter objConvertor = new VisualTemplatesTypeConverter();

            // Get the type of the element
            Component objComponent = objContext.Instance as Component;
            IContext objClientContext = objComponent.Context;

            mobjEditingComponent = objComponent as WebGUIForms.Component;
            List<Type> objVisualTemplateTypes = GetVisualTemplateTypes(objClientContext, objComponent);

            WebGUIForms.VisualTemplate objOldVisualTemplate = objValue as WebGUIForms.VisualTemplate;
            WebGUIForms.VisualTemplate objCurrentVisualTemplate = objValue as WebGUIForms.VisualTemplate;

            if (objCurrentVisualTemplate != null)
            {
                objCurrentVisualTemplate = objConvertor.ConvertFromString(objOldVisualTemplate.ConvertToString()) as WebGUIForms.VisualTemplate;
            }

            // Create the dialog and passing it the current source component.
            VisualTemplateControlForm objDialog = new VisualTemplateControlForm(objClientContext, objComponent, objCurrentVisualTemplate, objVisualTemplateTypes);            
            objDialog.StartPosition = WinForms.FormStartPosition.CenterScreen;
            WinForms.DialogResult result = objDialog.ShowDialog();

            WebGUIForms.VisualTemplate objNewVisualTemplate = objDialog.VisualTemplate;

            if (result == WinForms.DialogResult.Cancel || (result == WinForms.DialogResult.OK && objNewVisualTemplate != null && objOldVisualTemplate != null && objOldVisualTemplate.ConvertToString() == objNewVisualTemplate.ConvertToString()))
            {
                return objValue;
            }

            return objNewVisualTemplate;
        }

        /// <summary>
        /// Gets the control visual template types.
        /// </summary>
        /// <returns></returns>
        private List<Type> GetVisualTemplateTypes(IContext objClientContext, Component objComponent)
        {
            return mobjVisualTemplateService.GetVisualTemplates(objComponent.GetType());
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
        {
            return UITypeEditorEditStyle.Modal;
        }

        [Serializable()]
        private class VisualTemplateControlForm : WinForms.Form
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            // Elements on the form
            private WinForms.Panel mobjLeftPanel;
            private WinForms.Splitter mobjSplitter;
            private WinForms.Splitter mobjSplitter2;
            private WinForms.Panel mobjRightPanel;
            private WinForms.Button mbtnOkAction;
            private WinForms.Button mbtnCancelAction;
            private WinForms.PropertyGrid mobjPropertyGrid;
            private WinForms.Panel mobjActionsPanel;
            private WinForms.Panel mobjDescriptionPanel;
            private WinForms.Label mobjDescriptionLabel;
            private WinForms.ListView mobjListOfVisualTemplates;
            private WinForms.ColumnHeader mobjColumnAppearanceName;

            private Component mobjComponent;
            private WebGUIForms.VisualTemplate mobjCurrentVisualTemplate;
            private List<Type> marrVisualTemplateTypes;
            private IContext mobjClientContext;

            /// <summary>
            /// Initializes a new instance of the <see cref="VisualTemplateControlForm"/> class.
            /// </summary>
            /// <param name="objVisualizerControlDialog">The object visualizer control dialog.</param>
            public VisualTemplateControlForm(IContext objClientContext, Component objComponent, WebGUIForms.VisualTemplate objVisualTemplate, List<Type> arrVisualTemplateTypes)
            {
                mobjComponent = objComponent;
                mobjCurrentVisualTemplate = objVisualTemplate;
                mobjClientContext = objClientContext;
                marrVisualTemplateTypes = arrVisualTemplateTypes;

                InitializeComponent();
                this.AcceptButton = mbtnOkAction;
                this.CancelButton = mbtnCancelAction;

                InitializeData();
            }

            /// <summary>
            /// Gets or sets the visual template.
            /// </summary>
            /// <value>
            /// The visual template.
            /// </value>
            public WebGUIForms.VisualTemplate VisualTemplate
            {
                get
                {
                    return mobjCurrentVisualTemplate;
                }
                set
                {
                    mobjCurrentVisualTemplate = value;
                }
            }

            /// <summary>
            /// Initializes the data.
            /// </summary>
            private void InitializeData()
            {
                this.mobjPropertyGrid.Tag = mobjComponent;

                // Getting the source component visual template
                WebGUIForms.VisualTemplate objCurrentVisualAppearnce = VisualTemplate;

                // Creating image list with appearances images. (The list is used because you can control ImageSize with list)
                WinForms.ImageList objImageList = new WinForms.ImageList();

                // Creating the "None" appearance option.
                WinForms.ListViewItem objNoneListViewItem = new WinForms.ListViewItem();

                Image objDefaultImage = GetDefaultSkinResourceHandleImage();
                                
                objImageList.Images.Add(objDefaultImage);
                objNoneListViewItem.ImageIndex = 0;
                objNoneListViewItem.Text = "None";
                if (objCurrentVisualAppearnce == null)
                {
                    objNoneListViewItem.Selected = true;
                }
                mobjListOfVisualTemplates.Items.Add(objNoneListViewItem);

                if (marrVisualTemplateTypes != null)
                {
                    // Adding all the types to the listview, including creating instances added to the Tag property an dimages in the imageList.
                    foreach (Type objVisualTemplateType in marrVisualTemplateTypes)
                    {
                        WinForms.ListViewItem objListViewItem = new WinForms.ListViewItem();

                        WebGUIForms.VisualTemplate objVisualTemplate = Activator.CreateInstance(objVisualTemplateType) as WebGUIForms.VisualTemplate;

                        // Check if the current type from the listview is the selected type as well.
                        if (objCurrentVisualAppearnce != null && objCurrentVisualAppearnce.GetType() == objVisualTemplateType)
                        {
                            objVisualTemplate = objCurrentVisualAppearnce;
                            objListViewItem.Selected = true;
                            mobjPropertyGrid.SelectedObject = objCurrentVisualAppearnce;
                        }

                        objListViewItem.Tag = objVisualTemplate;
                        objListViewItem.Text = objVisualTemplate.ToString();
                        ResourceHandle objResourceHandler = objVisualTemplate.VisualizerImage;
                        Image objImage = null;
                        if (objResourceHandler == null)
                        {
                            objImage = GetDefaultSkinResourceHandleImage();
                        }
                        else
                        {
                            objImage = GetSkinResourceHandleImage(objVisualTemplate, objVisualTemplate.VisualizerImage as SkinResourceHandle);
                        }

                        objImageList.Images.Add(objImage);

                        objListViewItem.ImageIndex = objImageList.Images.Count - 1;

                        mobjListOfVisualTemplates.Items.Add(objListViewItem);
                    }
                }

                mobjListOfVisualTemplates.LargeImageList = objImageList;
                objImageList.ImageSize = new System.Drawing.Size(200, 150);
                mobjListOfVisualTemplates.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                this.Text = "Visual templates available for " + mobjComponent.GetType().Name;

                UpdateScreen();
            }

            /// <summary>
            /// Return image for default visual templage.
            /// </summary>
            private Image GetDefaultSkinResourceHandleImage()
            {
                Image objImage = GetSkinResourceHandleImage(new Control(), VisualTemplate.VisualizerDefaultImage as SkinResourceHandle);
                return objImage;
            }

            /// <summary>
            /// Recieves skin type and resource handle (image), and return the skin image for the resource handle.
            /// </summary>
            private Image GetSkinResourceHandleImage(ISkinable objSkinable, SkinResourceHandle objSkinResourceHandle)
            {
                Image objImage = null;
                Skin objSkin = SkinFactory.GetSkin(objSkinable);
                Dictionary<string, SkinResource> objResources = objSkin.Resources;

                // Loop thru all the skin resources and find the one that matches the resource handle.
                foreach (KeyValuePair<string, SkinResource> objResource in objResources)
                {
                    string strResourceKey = SkinFactory.GetSkinResourcePath(objSkin.GetType(), objResource.Key);
                    if (strResourceKey == objSkinResourceHandle.File)
                    {
                        ImageResource objImageResource = objResource.Value as ImageResource;
                        objImage = Image.FromStream(objImageResource.ContentStream);
                        break;
                    }
                }

                return objImage;
            }

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Visual WebGui Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.mobjLeftPanel = new WinForms.Panel();
                this.mobjSplitter = new WinForms.Splitter();
                this.mobjSplitter2 = new WinForms.Splitter();
                this.mobjRightPanel = new WinForms.Panel();
                this.mbtnCancelAction = new WinForms.Button();
                this.mbtnOkAction = new WinForms.Button();
                this.mobjPropertyGrid = new WinForms.PropertyGrid();
                this.mobjActionsPanel = new WinForms.Panel();
                this.mobjListOfVisualTemplates = new WinForms.ListView();
                this.mobjDescriptionPanel = new WinForms.Panel();
                this.mobjDescriptionLabel = new WinForms.Label();
                this.mobjColumnAppearanceName = new WinForms.ColumnHeader();
                this.mobjRightPanel.SuspendLayout();
                this.mobjActionsPanel.SuspendLayout();
                this.SuspendLayout();
                // 
                // panel1
                // 
                this.mobjLeftPanel.Controls.Add(this.mobjListOfVisualTemplates);
                this.mobjLeftPanel.Controls.Add(mobjSplitter2);
                this.mobjLeftPanel.Controls.Add(mobjDescriptionPanel);
                this.mobjLeftPanel.Dock = WinForms.DockStyle.Fill;
                this.mobjLeftPanel.Location = new System.Drawing.Point(0, 0);
                this.mobjLeftPanel.Name = "panel1";
                this.mobjLeftPanel.Size = new System.Drawing.Size(518, 470);
                this.mobjLeftPanel.TabIndex = 0;
                // 
                // splitter1
                // 
                this.mobjSplitter.Location = new System.Drawing.Point(518, 0);
                this.mobjSplitter.Dock = WinForms.DockStyle.Right;
                this.mobjSplitter.Name = "splitter1";
                this.mobjSplitter.Size = new System.Drawing.Size(3, 470);
                this.mobjSplitter.TabIndex = 1;
                this.mobjSplitter.TabStop = false;
                // 
                // mobjSplitter2
                // 
                this.mobjSplitter2.Location = new System.Drawing.Point(518, 0);
                this.mobjSplitter2.Dock = WinForms.DockStyle.Bottom;
                this.mobjSplitter2.Name = "mobjSplitter2";
                this.mobjSplitter2.Size = new System.Drawing.Size(470, 3);
                this.mobjSplitter2.TabIndex = 1;
                this.mobjSplitter2.TabStop = false;
                // 
                // panel2
                // 
                this.mobjRightPanel.Controls.Add(this.mobjPropertyGrid);
                this.mobjRightPanel.Controls.Add(this.mobjActionsPanel);
                this.mobjRightPanel.Dock = WinForms.DockStyle.Right;
                this.mobjRightPanel.Location = new System.Drawing.Point(521, 0);
                this.mobjRightPanel.Name = "panel2";
                this.mobjRightPanel.Size = new System.Drawing.Size(231, 470);
                this.mobjRightPanel.TabIndex = 2;
                // 
                // mbtnCancelAction
                // 
                this.mbtnCancelAction.Anchor = ((WinForms.AnchorStyles)((WinForms.AnchorStyles.Bottom | WinForms.AnchorStyles.Right)));
                this.mbtnCancelAction.Location = new System.Drawing.Point(150, 11);
                this.mbtnCancelAction.Name = "mbtnCancelAction";
                this.mbtnCancelAction.Size = new System.Drawing.Size(75, 23);
                this.mbtnCancelAction.TabIndex = 0;
                this.mbtnCancelAction.Text = "Cancel";
                // 
                // mbtnOkAction
                // 
                this.mbtnOkAction.Anchor = ((WinForms.AnchorStyles)((WinForms.AnchorStyles.Bottom | WinForms.AnchorStyles.Right)));
                this.mbtnOkAction.Location = new System.Drawing.Point(65, 11);
                this.mbtnOkAction.Name = "mbtnOkAction";
                this.mbtnOkAction.Size = new System.Drawing.Size(75, 23);
                this.mbtnOkAction.TabIndex = 1;
                this.mbtnOkAction.Text = "Ok";
                this.mbtnOkAction.Click += mbtnOkAction_Click;
                // 
                // propertyGrid1
                // 
                this.mobjPropertyGrid.AutoValidate = WinForms.AutoValidate.EnablePreventFocusChange;
                this.mobjPropertyGrid.CommandsVisibleIfAvailable = false;
                this.mobjPropertyGrid.Dock = WinForms.DockStyle.Fill;
                this.mobjPropertyGrid.Location = new System.Drawing.Point(0, 0);
                this.mobjPropertyGrid.Name = "propertyGrid1";
                this.mobjPropertyGrid.Size = new System.Drawing.Size(231, 425);
                this.mobjPropertyGrid.TabIndex = 2;
                //
                // panel3
                //
                this.mobjActionsPanel.Controls.Add(this.mbtnOkAction);
                this.mobjActionsPanel.Controls.Add(this.mbtnCancelAction);
                this.mobjActionsPanel.Dock = WinForms.DockStyle.Bottom;
                this.mobjActionsPanel.Location = new System.Drawing.Point(0, 425);
                this.mobjActionsPanel.Name = "panel3";
                this.mobjActionsPanel.Size = new System.Drawing.Size(231, 45);
                this.mobjActionsPanel.TabIndex = 3;
                //
                // mobjDescriptionPanel
                //
                this.mobjDescriptionPanel.Controls.Add(mobjDescriptionLabel);
                this.mobjDescriptionPanel.Dock = WinForms.DockStyle.Bottom;
                this.mobjDescriptionPanel.Location = new System.Drawing.Point(0, 425);
                this.mobjDescriptionPanel.Name = "mobjDescriptionPanel";
                this.mobjDescriptionPanel.Size = new System.Drawing.Size(231, 80);
                this.mobjDescriptionPanel.TabIndex = 3;
                //
                // mobjDescriptionLabel
                //
                mobjDescriptionLabel.Dock = WinForms.DockStyle.Fill;
                mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                mobjDescriptionLabel.Text = "";
                // 
                // listView1
                // 
                this.mobjListOfVisualTemplates.Columns.AddRange(new WinForms.ColumnHeader[] {
                    this.mobjColumnAppearanceName});
                this.mobjListOfVisualTemplates.Dock = WinForms.DockStyle.Fill;
                this.mobjListOfVisualTemplates.Location = new System.Drawing.Point(0, 0);
                this.mobjListOfVisualTemplates.Name = "listView1";
                this.mobjListOfVisualTemplates.Size = new System.Drawing.Size(518, 470);
                this.mobjListOfVisualTemplates.MultiSelect = false;
                this.mobjListOfVisualTemplates.TabIndex = 0;
                this.mobjListOfVisualTemplates.SelectedIndexChanged += mobjListOfVisualTemplates_SelectedIndexChanged;
                this.mobjListOfVisualTemplates.View = WinForms.View.LargeIcon;
                // 
                // VisualizerControl
                //                 
                this.Controls.Add(this.mobjLeftPanel);
                this.Controls.Add(this.mobjSplitter);
                this.Controls.Add(this.mobjRightPanel);
                this.Size = new System.Drawing.Size(752, 470);
                this.Text = "VisualizerControl";
                this.mobjRightPanel.ResumeLayout(false);
                this.mobjActionsPanel.ResumeLayout(false);
                this.ResumeLayout(false);

            }

            void mbtnOkAction_Click(object sender, EventArgs e)
            {
                DialogResult = WinForms.DialogResult.OK;
                Close();
            }

            /// <summary>
            /// Handles the SelectedIndexChanged event of the mobjListOfVisualTemplates control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            void mobjListOfVisualTemplates_SelectedIndexChanged(object sender, EventArgs e)
            {
                UpdateScreen();
            }

            /// <summary>
            /// Updates the screen.
            /// </summary>
            private void UpdateScreen()
            {
                string strDescription = string.Empty;
                if (mobjListOfVisualTemplates.SelectedItems.Count == 1)
                {
                    WinForms.ListViewItem objListViewItem = mobjListOfVisualTemplates.SelectedItems[0];
                    VisualTemplate objVisualTemplate = objListViewItem.Tag as VisualTemplate;
                    mobjPropertyGrid.SelectedObject = objVisualTemplate;
                    VisualTemplate = objVisualTemplate;

                    if (objVisualTemplate != null)
                    {
                        VisualTemplateAttribute objVisualTemplateAttribute = Attribute.GetCustomAttribute(objVisualTemplate.GetType(),typeof(VisualTemplateAttribute), true) as VisualTemplateAttribute;
                        if (objVisualTemplateAttribute != null)
                        {
                            strDescription = objVisualTemplateAttribute.Description;
                        }
                    }
                }

                mobjDescriptionLabel.Text = strDescription;
            }

            #endregion
        }
    }
}