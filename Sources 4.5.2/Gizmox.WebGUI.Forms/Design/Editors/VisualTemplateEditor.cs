using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Text;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// The editor for the visual templates.
    /// </summary>
    [Serializable()]
    public class VisualTemplateEditor : WebUITypeEditor
    {
        private Component mobjComponent = null;

        /// <summary>
        /// The handler of the propertygrid.
        /// </summary>
        private WebUITypeEditorHandler mobjHandler = null;

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
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            // Get the type of the element
            mobjComponent = objContext.Instance as Component;

            if (mobjComponent != null)
            {
                Type objTypeForEditor = mobjComponent.GetType();

                // Check maybe the type is proxy type, and then take the type from the source component.
                ProxyComponent objProxyComponent = mobjComponent as ProxyComponent;
                if (objProxyComponent != null && objProxyComponent.SourceComponent != null)
                {
                    objTypeForEditor = objProxyComponent.SourceComponent.GetType();

                    // Changing the component to point the sourcecomponent, since this is what we want as a parameter.
                    mobjComponent = objProxyComponent.SourceComponent;
                }

                VisualTemplate objCurrentVisualTemplate = objValue as VisualTemplate;

                // Try to get the current device from Context or from Emulator
                IContextParams objVWGContextParams = VWGContext.Current as IContextParams;

                string strCurrentDeviceId = null;

                if (objVWGContextParams != null)
                {
                    // Check for emulatorForm existance
                    IEmulatorForm objEmulatorForm = objVWGContextParams.EmulatorForm;

                    if (objEmulatorForm != null)
                    {
                        strCurrentDeviceId = objEmulatorForm.CurrentBrowserInfo.BrowserId;
                    }
                }

                // Create the dialog and passing it the current source component.
                VisualTemplateControlDialog objVisualizerControlDialog = new VisualTemplateControlDialog(objTypeForEditor, objCurrentVisualTemplate, mobjComponent, strCurrentDeviceId);
                objVisualizerControlDialog.Closed += new EventHandler(objVisualizerControlDialog_Closed);

                // Store handler
                mobjHandler = objHandler;

                // Show dialog
                IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
                if (objEditorService != null)
                {
                    objEditorService.ShowDialog(objVisualizerControlDialog);
                }
            }
        }

        /// <summary>
        /// Handles the Closed event of the objVisualizerControlDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objVisualizerControlDialog_Closed(object sender, EventArgs e)
        {
            VisualTemplateControlDialog objVisualizerControlDialog = (VisualTemplateControlDialog)sender;
            if (objVisualizerControlDialog.DialogResult == DialogResult.OK)
            {
                if (mobjHandler != null)
                {
                    mobjHandler(this.GetPropertyValueFromEditorValue(objVisualizerControlDialog.VisualTemplate));
                    
                    // Updating the control to be rerendered to client
                    if (mobjComponent != null)
                    {
                        mobjComponent.UpdateParams(AttributeType.Visual);
                    }
                }
            }
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


    }



    /// <summary>
    /// The dialog for the visual templates.
    /// </summary>
    [Serializable()]
    public class VisualTemplateControlDialog : CommonDialog
    {
        private VisualTemplate mobjCurrentControlVisualTemplate = null;
        private Type mobjControlType;
        private Component mobjComponent;
        private string mstrDeviceId;
        private VisualTemplateService mobjVisualTemplateService = new VisualTemplateService();

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTemplateControlDialog" /> class.
        /// </summary>
        /// <param name="objControlType">Type of the object control.</param>
        /// <param name="objCurrentControlVisualTemplate">The object current control visual template.</param>
        /// <param name="objComponent">The object component.</param>
        public VisualTemplateControlDialog(Type objControlType, VisualTemplate objCurrentControlVisualTemplate, Component objComponent)
        {
            mobjControlType = objControlType;
            mobjCurrentControlVisualTemplate = objCurrentControlVisualTemplate;
            mstrDeviceId = null;
            mobjComponent = objComponent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTemplateControlDialog" /> class.
        /// </summary>
        /// <param name="objControlType">Type of the object control.</param>
        /// <param name="objCurrentControlVisualTemplate">The object current control visual template.</param>
        /// <param name="objComponent">The object component.</param>
        /// <param name="strDeviceId">The string device unique identifier.</param>
        public VisualTemplateControlDialog(Type objControlType, VisualTemplate objCurrentControlVisualTemplate, Component objComponent, string strDeviceId)
        {
            mobjControlType = objControlType;
            mobjCurrentControlVisualTemplate = objCurrentControlVisualTemplate;
            mstrDeviceId = strDeviceId;
            mobjComponent = objComponent;
        }

        [Serializable()]
        protected class VisualTemplateControlForm : CommonDialogForm
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            // Elements on the form
            private Panel mobjLeftPanel;
            private Splitter mobjSplitter;
            private Splitter mobjSplitter2;
            private Panel mobjRightPanel;
            private Button mbtnOkAction;
            private Button mbtnCancelAction;
            private PropertyGrid mobjPropertyGrid;
            private Panel mobjActionsPanel;
            private Panel mobjDescriptionPanel;
            private Label mobjDescriptionLabel;
            private ListView mobjListOfVisualTemplates;
            private ColumnHeader mobjColumnAppearanceName;

            /// <summary>
            /// Initializes a new instance of the <see cref="VisualTemplateControlForm"/> class.
            /// </summary>
            /// <param name="objVisualizerControlDialog">The object visualizer control dialog.</param>
            public VisualTemplateControlForm(VisualTemplateControlDialog objVisualizerControlDialog)
                : base(objVisualizerControlDialog)
            {
                InitializeComponent();
                this.AcceptButton = mbtnOkAction;
                this.CancelButton = mbtnCancelAction;

                InitializeData();
            }

            /// <summary>
            /// Initializes the data.
            /// </summary>
            private void InitializeData()
            {
                VisualTemplateControlDialog objDialogOwner = this.CommonDialogOwner as VisualTemplateControlDialog;

                this.mobjPropertyGrid.Tag = objDialogOwner.mobjComponent;

                // Validating the dialog.
                if (objDialogOwner != null)
                {
                    // Getting possible appearances based on the type given to the dialog,
                    List<Type> objListOfVisualTemplateTypes = objDialogOwner.GetControlVisualTemplateTypes();

                    // Getting the source component visual template
                    VisualTemplate objCurrentVisualAppearnce = objDialogOwner.VisualTemplate;

                    // Creating image list with appearances images. (The list is used because you can control ImageSize with list)
                    ImageList objImageList = new ImageList();
                    // Creating the "None" appearance option.
                    ListViewItem objNoneListViewItem = new ListViewItem();
                    objImageList.Images.Add(VisualTemplate.VisualizerDefaultImage);
                    objNoneListViewItem.ImageIndex = 0;
                    objNoneListViewItem.SubItems.Add("None");
                    objNoneListViewItem.SubItems.Add(string.Empty);
                    if (objCurrentVisualAppearnce == null)
                    {
                        objNoneListViewItem.Selected = true;
                    }
                    mobjListOfVisualTemplates.Items.Add(objNoneListViewItem);

                    if (objListOfVisualTemplateTypes != null)
                    {
                        // Adding all the types to the listview, including creating instances added to the Tag property an dimages in the imageList.
                        foreach (Type objTypeOfVA in objListOfVisualTemplateTypes)
                        {
                            ListViewItem objListViewItem = new ListViewItem();

                            VisualTemplate objVisualTemplate = Activator.CreateInstance(objTypeOfVA) as VisualTemplate;

                            // Giving any list view item a default value known for the current visual template.
                            VisualTemplate objVisualTemplateDefault = null;
                            if (objVisualTemplate != null)
                            {
                                // Checking if the component is a control.
                                Control objTempControl = objDialogOwner.mobjComponent as Control;

                                if (objTempControl != null)
                                {
                                    objVisualTemplateDefault = objVisualTemplate.GetDefault(objTempControl);

                                    // Setting the visual template to work with as the default one
                                    // The default is valid only when the type returned is the same type (because it can get default from base class, and give wrong behavior)
                                    if (objVisualTemplateDefault != null && objVisualTemplateDefault.GetType() == objVisualTemplate.GetType())
                                    {
                                        objVisualTemplate = objVisualTemplateDefault;
                                    }
                                }
                            }

                            // Check if the current type from the listview is the selected type as well.
                            if (objCurrentVisualAppearnce != null && objCurrentVisualAppearnce.GetType() == objTypeOfVA)
                            {
                                objVisualTemplate = objCurrentVisualAppearnce;
                                objListViewItem.Selected = true;
                                mobjPropertyGrid.SelectedObject = objCurrentVisualAppearnce;
                            }

                            objListViewItem.Tag = objVisualTemplate;
                            objListViewItem.SubItems.Add(objVisualTemplate.ToString());
                            objListViewItem.SubItems.Add(GetVisualTemplateDescription(objTypeOfVA));
                            ResourceHandle objResourceHandler = objVisualTemplate.VisualizerImage;
                            if (objResourceHandler != null)
                            {
                                objImageList.Images.Add(objResourceHandler);
                            }
                            else
                            {
                                objImageList.Images.Add(VisualTemplate.VisualizerDefaultImage);
                            }
                            objListViewItem.ImageIndex = objImageList.Images.Count - 1;

                            mobjListOfVisualTemplates.Items.Add(objListViewItem);
                        }
                    }
                    
                    mobjListOfVisualTemplates.LargeImageList = objImageList;
                    objImageList.ImageSize = new System.Drawing.Size(200, 150);
                    mobjListOfVisualTemplates.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                    this.Text = "Visual templates available for " + objDialogOwner.mobjControlType.Name;

                    UpdateScreen();
                }
            }

            /// <summary>
            /// Gets the visual template description.
            /// </summary>
            /// <param name="objTypeOfVisualTemplate">The obj type of visual template.</param>
            /// <returns></returns>
            private string GetVisualTemplateDescription(Type objTypeOfVisualTemplate)
            {
                VisualTemplateControlDialog objDialogOwner = this.CommonDialogOwner as VisualTemplateControlDialog;

                return objDialogOwner.GetVisualTemplateDescription(objTypeOfVisualTemplate);
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
                this.mobjLeftPanel = new Gizmox.WebGUI.Forms.Panel();
                this.mobjSplitter = new Gizmox.WebGUI.Forms.Splitter();
                this.mobjSplitter2 = new Gizmox.WebGUI.Forms.Splitter();
                this.mobjRightPanel = new Gizmox.WebGUI.Forms.Panel();
                this.mbtnCancelAction = new Gizmox.WebGUI.Forms.Button();
                this.mbtnOkAction = new Gizmox.WebGUI.Forms.Button();
                this.mobjPropertyGrid = new Gizmox.WebGUI.Forms.PropertyGrid();
                this.mobjActionsPanel = new Gizmox.WebGUI.Forms.Panel();
                this.mobjListOfVisualTemplates = new Gizmox.WebGUI.Forms.ListView();
                this.mobjDescriptionPanel = new Gizmox.WebGUI.Forms.Panel();
                this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
                this.mobjColumnAppearanceName = new Gizmox.WebGUI.Forms.ColumnHeader();                
                this.mobjRightPanel.SuspendLayout();
                this.mobjActionsPanel.SuspendLayout();
                this.SuspendLayout();
                // 
                // panel1
                // 
                this.mobjLeftPanel.Controls.Add(this.mobjListOfVisualTemplates);
                this.mobjLeftPanel.Controls.Add(mobjSplitter2);
                this.mobjLeftPanel.Controls.Add(mobjDescriptionPanel);
                this.mobjLeftPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjLeftPanel.Location = new System.Drawing.Point(0, 0);
                this.mobjLeftPanel.Name = "panel1";
                this.mobjLeftPanel.Size = new System.Drawing.Size(518, 470);
                this.mobjLeftPanel.TabIndex = 0;
                // 
                // splitter1
                // 
                this.mobjSplitter.Location = new System.Drawing.Point(518, 0);
                this.mobjSplitter.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
                this.mobjSplitter.Name = "splitter1";
                this.mobjSplitter.Size = new System.Drawing.Size(3, 470);
                this.mobjSplitter.TabIndex = 1;
                this.mobjSplitter.TabStop = false;
                // 
                // mobjSplitter2
                // 
                this.mobjSplitter2.Location = new System.Drawing.Point(518, 0);
                this.mobjSplitter2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
                this.mobjSplitter2.Name = "mobjSplitter2";
                this.mobjSplitter2.Size = new System.Drawing.Size(470, 3);
                this.mobjSplitter2.TabIndex = 1;
                this.mobjSplitter2.TabStop = false;
                // 
                // panel2
                // 
                this.mobjRightPanel.Controls.Add(this.mobjPropertyGrid);
                this.mobjRightPanel.Controls.Add(this.mobjActionsPanel);
                this.mobjRightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
                this.mobjRightPanel.Location = new System.Drawing.Point(521, 0);
                this.mobjRightPanel.Name = "panel2";
                this.mobjRightPanel.Size = new System.Drawing.Size(231, 470);
                this.mobjRightPanel.TabIndex = 2;
                // 
                // mbtnCancelAction
                // 
                this.mbtnCancelAction.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mbtnCancelAction.Location = new System.Drawing.Point(157, 11);
                this.mbtnCancelAction.Name = "mbtnCancelAction";
                this.mbtnCancelAction.Size = new System.Drawing.Size(75, 23);
                this.mbtnCancelAction.TabIndex = 0;
                this.mbtnCancelAction.Text = "Cancel";
                this.mbtnCancelAction.Click += new EventHandler(mbtnCancelAction_Click);
                // 
                // mbtnOkAction
                // 
                this.mbtnOkAction.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mbtnOkAction.Location = new System.Drawing.Point(72, 11);
                this.mbtnOkAction.Name = "mbtnOkAction";
                this.mbtnOkAction.Size = new System.Drawing.Size(75, 23);
                this.mbtnOkAction.TabIndex = 1;
                this.mbtnOkAction.Text = "Ok";
                this.mbtnOkAction.Click += new EventHandler(mbtnOkAction_Click);
                // 
                // propertyGrid1
                // 
                this.mobjPropertyGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
                this.mobjPropertyGrid.CategoryForeColor = System.Drawing.Color.Empty;
                this.mobjPropertyGrid.CommandsVisibleIfAvailable = false;
                this.mobjPropertyGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjPropertyGrid.HelpForeColor = System.Drawing.Color.Black;
                this.mobjPropertyGrid.LineColor = System.Drawing.Color.Empty;
                this.mobjPropertyGrid.Location = new System.Drawing.Point(0, 0);
                this.mobjPropertyGrid.Name = "propertyGrid1";
                this.mobjPropertyGrid.Size = new System.Drawing.Size(231, 425);
                this.mobjPropertyGrid.TabIndex = 2;
                this.mobjPropertyGrid.ViewBackColor = System.Drawing.Color.White;
                this.mobjPropertyGrid.ViewForeColor = System.Drawing.Color.Black;
                //
                // panel3
                //
                this.mobjActionsPanel.Controls.Add(this.mbtnOkAction);
                this.mobjActionsPanel.Controls.Add(this.mbtnCancelAction);
                this.mobjActionsPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
                this.mobjActionsPanel.Location = new System.Drawing.Point(0, 425);
                this.mobjActionsPanel.Name = "panel3";
                this.mobjActionsPanel.Size = new System.Drawing.Size(231, 45);
                this.mobjActionsPanel.TabIndex = 3;
                //
                // mobjDescriptionPanel
                //
                this.mobjDescriptionPanel.Controls.Add(mobjDescriptionLabel);
                this.mobjDescriptionPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
                this.mobjDescriptionPanel.Location = new System.Drawing.Point(0, 425);
                this.mobjDescriptionPanel.Name = "mobjDescriptionPanel";
                this.mobjDescriptionPanel.Size = new System.Drawing.Size(231, 80);
                this.mobjDescriptionPanel.TabIndex = 3;
                //
                // mobjDescriptionLabel
                //
                mobjDescriptionLabel.Dock = DockStyle.Fill;                
                mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                mobjDescriptionLabel.Text = "";
                // 
                // listView1
                // 
                this.mobjListOfVisualTemplates.DataMember = null;
                this.mobjListOfVisualTemplates.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
                    this.mobjColumnAppearanceName});
                this.mobjListOfVisualTemplates.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjListOfVisualTemplates.Location = new System.Drawing.Point(0, 0);
                this.mobjListOfVisualTemplates.Name = "listView1";
                this.mobjListOfVisualTemplates.Size = new System.Drawing.Size(518, 470);
                this.mobjListOfVisualTemplates.MultiSelect = false;
                this.mobjListOfVisualTemplates.TabIndex = 0;
                this.mobjListOfVisualTemplates.SelectedIndexChanged += mobjListOfVisualTemplates_SelectedIndexChanged;
                this.mobjListOfVisualTemplates.View = View.LargeIcon;
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

                ListViewItem objListViewItem = mobjListOfVisualTemplates.SelectedItem;

                if (objListViewItem != null)
                {
					mobjPropertyGrid.SelectedObject = objListViewItem.Tag;

                    VisualTemplateControlDialog objDialogOwner = this.CommonDialogOwner as VisualTemplateControlDialog;

                    if (objDialogOwner != null)
                    {
                        objDialogOwner.VisualTemplate = objListViewItem.Tag as VisualTemplate;
                    }
                    strDescription = objListViewItem.SubItems[1].Text;
                }

                mobjDescriptionLabel.Text = strDescription;
            }

            /// <summary>
            /// Handles the Click event of the mbtnCacnelAction control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void mbtnCancelAction_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            /// <summary>
            /// Handles the Click event of the mbtnOkAction control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void mbtnOkAction_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            #endregion

        }


        /// <summary>
        /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
        /// </summary>
        public override void Reset()
        {

        }

        /// <summary>
        /// Creates a dialog for instance for the current common dialog
        /// </summary>
        /// <returns></returns>
        protected override CommonDialog.CommonDialogForm CreateForm()
        {
            return new VisualTemplateControlForm(this);
        }

        /// <summary>
        /// Gets or sets the visual template.
        /// </summary>
        /// <value>
        /// The visual template.
        /// </value>
        public VisualTemplate VisualTemplate
        {
            get
            {
                return mobjCurrentControlVisualTemplate;
            }
            set
            {
                mobjCurrentControlVisualTemplate = value;
            }
        }

        /// <summary>
        /// Gets the control visual template types.
        /// </summary>
        /// <returns></returns>
        private List<Type> GetControlVisualTemplateTypes()
        {
            return mobjVisualTemplateService.GetVisualTemplates(mobjControlType);
            
        }


        /// <summary>
        /// Gets the visual template description.
        /// </summary>
        /// <param name="objTypeOfVisualTemplate">The obj type of visual template.</param>
        /// <returns></returns>
        private string GetVisualTemplateDescription(Type objTypeOfVisualTemplate)
        {
            string strDescription = string.Empty;
            VisualTemplateAttribute objVisualTemplateAttribute = Attribute.GetCustomAttribute(objTypeOfVisualTemplate,typeof(VisualTemplateAttribute), true) as VisualTemplateAttribute;
            if (objVisualTemplateAttribute != null)
            {
                strDescription = objVisualTemplateAttribute.Description;
            }


            return strDescription;
        }
    }

}
