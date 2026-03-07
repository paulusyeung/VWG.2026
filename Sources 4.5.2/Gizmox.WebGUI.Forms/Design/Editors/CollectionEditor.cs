using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Reflection;

using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>Provides a user interface that can edit most types of collections at design time.</summary>

    [Serializable()]
    public class CollectionEditor : WebUITypeEditor
    {

        #region Classes

        #region PropertyGridSite Class


        [Serializable()]
        internal class PropertyGridSite : ISite, IServiceProvider
        {
            private IComponent mobjComponent;
            private bool mblnInGetService;
            private IServiceProvider mobjServiceProvider;

            public PropertyGridSite(IServiceProvider objServiceProvider, IComponent comp)
            {
                this.mobjServiceProvider = objServiceProvider;
                this.mobjComponent = comp;
            }

            public object GetService(Type objType)
            {
                if (!this.mblnInGetService && (this.mobjServiceProvider != null))
                {
                    try
                    {
                        this.mblnInGetService = true;
                        return this.mobjServiceProvider.GetService(objType);
                    }
                    finally
                    {
                        this.mblnInGetService = false;
                    }
                }
                return null;
            }

            public IComponent Component
            {
                get
                {
                    return this.mobjComponent;
                }
            }

            public IContainer Container
            {
                get
                {
                    return null;
                }
            }


            public bool DesignMode
            {
                get
                {
                    return false;
                }
            }


            public string Name
            {
                get
                {
                    return null;
                }
                set
                {
                }
            }
        }


        #endregion PropertyGridSite Class

        #region CollectionEditorCollectionForm Class


        [Serializable()]
        protected internal class CollectionEditorCollectionForm : CollectionEditor.CollectionForm
        {
            #region Classes


            [Serializable()]
            private class SelectionWrapper : PropertyDescriptor, ICustomTypeDescriptor
            {
                private ICollection mobjCollection;
                private Type mobjCollectionItemType;
                private Type mobjCollectionType;
                private Control mobjControl;
                private PropertyDescriptorCollection mobjProperties;
                private object mobjValue;

                public SelectionWrapper(Type objCollectionType, Type objCollectionItemType, Control objControl, ICollection objCollection)
                    : base("Value", new Attribute[] { new CategoryAttribute(objCollectionItemType.Name) })
                {
                    this.mobjCollectionType = objCollectionType;
                    this.mobjCollectionItemType = objCollectionItemType;
                    this.mobjControl = objControl;
                    this.mobjCollection = objCollection;
                    this.mobjProperties = new PropertyDescriptorCollection(new PropertyDescriptor[] { this });
                    this.mobjValue = this;
                    foreach (CollectionEditor.CollectionEditorCollectionForm.ListItem objItem in objCollection)
                    {
                        if (this.mobjValue == this)
                        {
                            this.mobjValue = objItem.Value;
                        }
                        else
                        {
                            object obj1 = objItem.Value;
                            if (this.mobjValue != null)
                            {
                                if (obj1 == null)
                                {
                                    this.mobjValue = null;
                                    return;
                                }
                                if (!this.mobjValue.Equals(obj1))
                                {
                                    this.mobjValue = null;
                                    return;
                                }
                                continue;
                            }
                            if (obj1 != null)
                            {
                                this.mobjValue = null;
                                return;
                            }
                        }
                    }
                }

                public override bool CanResetValue(object objComponent)
                {
                    return false;
                }

                public override object GetValue(object objComponent)
                {
                    return this.mobjValue;
                }

                public override void ResetValue(object objComponent)
                {
                }

                public override void SetValue(object objComponent, object objValue)
                {
                    this.mobjValue = objValue;
                    foreach (CollectionEditor.CollectionEditorCollectionForm.ListItem objItem in this.mobjCollection)
                    {
                        objItem.Value = objValue;
                    }
                    this.mobjControl.Invalidate();
                    this.OnValueChanged(objComponent, EventArgs.Empty);
                }

                public override bool ShouldSerializeValue(object objComponent)
                {
                    return false;
                }

                AttributeCollection ICustomTypeDescriptor.GetAttributes()
                {
                    return TypeDescriptor.GetAttributes(this.mobjCollectionItemType);
                }

                string ICustomTypeDescriptor.GetClassName()
                {
                    return this.mobjCollectionItemType.Name;
                }

                string ICustomTypeDescriptor.GetComponentName()
                {
                    return null;
                }

                TypeConverter ICustomTypeDescriptor.GetConverter()
                {
                    return null;
                }

                EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
                {
                    return null;
                }

                PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
                {
                    return this;
                }

                object ICustomTypeDescriptor.GetEditor(Type objEditorBaseType)
                {
                    return null;
                }

                EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
                {
                    return EventDescriptorCollection.Empty;
                }

                EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] arrAttributes)
                {
                    return EventDescriptorCollection.Empty;
                }

                PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
                {
                    return this.mobjProperties;
                }

                PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] arrAttributes)
                {
                    return this.mobjProperties;
                }

                object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor objPropertyDescriptor)
                {
                    return this;
                }


                public override Type ComponentType
                {
                    get
                    {
                        return this.mobjCollectionType;
                    }
                }

                public override bool IsReadOnly
                {
                    get
                    {
                        return false;
                    }
                }

                public override Type PropertyType
                {
                    get
                    {
                        return this.mobjCollectionItemType;
                    }
                }
            }

            [Serializable()]
            private class ListItem
            {
                private CollectionEditor mobjParentCollectionEditor;
                private object mobjUITypeEditor;
                private object mobjValue;
                private string mstrDisplayText = "";

                public ListItem(CollectionEditor objParentCollectionEditor, object objValue)
                {
                    this.mobjValue = objValue;
                    this.mobjParentCollectionEditor = objParentCollectionEditor;
                }

                public override string ToString()
                {
                    return mstrDisplayText;
                }

                public bool UpdateDisplayText()
                {
                    string strDisplayText = this.mobjParentCollectionEditor.GetDisplayText(this.mobjValue);
                    if (strDisplayText != mstrDisplayText)
                    {
                        mstrDisplayText = strDisplayText;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                public string DisplayText
                {
                    get
                    {
                        return mstrDisplayText;
                    }
                }




                public UITypeEditor Editor
                {
                    get
                    {
                        if (this.mobjUITypeEditor == null)
                        {
                            this.mobjUITypeEditor = TypeDescriptor.GetEditor(this.mobjValue, typeof(UITypeEditor));
                            if (this.mobjUITypeEditor == null)
                            {
                                this.mobjUITypeEditor = this;
                            }
                        }
                        if (this.mobjUITypeEditor != this)
                        {
                            return (UITypeEditor)this.mobjUITypeEditor;
                        }
                        return null;
                    }
                }

                public object Value
                {
                    get
                    {
                        return this.mobjValue;
                    }
                    set
                    {
                        this.mobjUITypeEditor = null;
                        this.mobjValue = value;
                    }
                }
            }


            #endregion

            #region Class Members

            #region Controls

            private Gizmox.WebGUI.Forms.Panel mobjPanelButtons;
            private Gizmox.WebGUI.Forms.Panel mobjPanelItems;
            private Gizmox.WebGUI.Forms.Panel mobjPanelProperties;
            private Gizmox.WebGUI.Forms.Label mobjLabelMembers;
            private Gizmox.WebGUI.Forms.Label mobjLabelProperties;
            private Gizmox.WebGUI.Forms.Panel mobjPanelUpDown;
            private Gizmox.WebGUI.Forms.Panel mobjPanelAddRemove;
            private Gizmox.WebGUI.Forms.Button mobjButtonCancel;
            private Gizmox.WebGUI.Forms.Button mobjButtonOk;
            private Gizmox.WebGUI.Forms.ListBox mobjListItems;
            private Gizmox.WebGUI.Forms.PropertyGrid mobjPropertyGrid;
            private Gizmox.WebGUI.Forms.Button mobjButtonUp;
            private Gizmox.WebGUI.Forms.Button mobjButtonDown;
            private Gizmox.WebGUI.Forms.Button mobjButtonAdd;
            private Gizmox.WebGUI.Forms.Button mobjButtonRemove;

            #endregion Class Members

            private ArrayList mobjOriginalItems = null;

            private ArrayList mobjCreatedItems = null;

            private ArrayList mobjRemovedItems = null;

            private bool mblnDirty = false;

            private int mintSuspendEnabledCount = 0;

            private CollectionEditor mobjCollectionEditor = null;


            #endregion

            #region C'Tor

            public CollectionEditorCollectionForm(CollectionEditor objCollectionEditor)
                : base(objCollectionEditor)
            {
                this.mobjCollectionEditor = objCollectionEditor;

                InitializeComponent();
                InitializeComponentExtra();
                this.Text = SR.GetString("CollectionEditorCaption", new object[] { base.CollectionItemType.Name });



            }



            #endregion C'Tor

            #region Methods

            #region WebGUI Designer generated code


            /// <summary>
            /// Adds VWG specifiec initialization
            /// </summary>
            private void InitializeComponentExtra()
            {
                this.mobjButtonDown.Image = new SkinResourceHandle(this.Skin, "ButtonDownArrow.gif");
                this.mobjButtonUp.Image = new SkinResourceHandle(this.Skin, "ButtonUpArrow.gif");

                Type[] arrTypes = base.NewItemTypes;
                if (arrTypes.Length > 1)
                {

                    //this.mobjButtonAdd.ShowSplit = true;
                    ContextMenu objAddDropDownMenu = new ContextMenu();
                    this.mobjButtonAdd.DropDownMenu = objAddDropDownMenu;
                    for (int num1 = 0; num1 < arrTypes.Length; num1++)
                    {
                        Type objType = arrTypes[num1];
                        MenuItem objMenuItem = new MenuItem(base.GetTypeDisplayName(objType));
                        objMenuItem.Tag = objType;
                        objAddDropDownMenu.MenuItems.Add(objMenuItem);
                    }

                    this.mobjButtonAdd.MenuClick += new MenuEventHandler(objAddDropDownMenu_MenuClick);
                }
                else
                {
                    this.mobjButtonAdd.Click += new System.EventHandler(this.mobjButtonAdd_Click);
                }

                this.mobjPropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(mobjPropertyGrid_PropertyValueChanged);
            }

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.mobjPanelButtons = new Gizmox.WebGUI.Forms.Panel();
                this.mobjPanelItems = new Gizmox.WebGUI.Forms.Panel();
                this.mobjPanelProperties = new Gizmox.WebGUI.Forms.Panel();
                this.mobjLabelMembers = new Gizmox.WebGUI.Forms.Label();
                this.mobjLabelProperties = new Gizmox.WebGUI.Forms.Label();
                this.mobjPanelUpDown = new Gizmox.WebGUI.Forms.Panel();
                this.mobjPanelAddRemove = new Gizmox.WebGUI.Forms.Panel();
                this.mobjButtonCancel = new Gizmox.WebGUI.Forms.Button();
                this.mobjButtonOk = new Gizmox.WebGUI.Forms.Button();
                this.mobjListItems = new Gizmox.WebGUI.Forms.ListBox();
                this.mobjPropertyGrid = this.GetPropertyGridInstance();
                this.mobjButtonUp = new Gizmox.WebGUI.Forms.Button();
                this.mobjButtonDown = new Gizmox.WebGUI.Forms.Button();
                this.mobjButtonAdd = new Gizmox.WebGUI.Forms.Button();
                this.mobjButtonRemove = new Gizmox.WebGUI.Forms.Button();
                this.mobjPanelButtons.SuspendLayout();
                this.mobjPanelItems.SuspendLayout();
                this.mobjPanelProperties.SuspendLayout();
                this.mobjPanelUpDown.SuspendLayout();
                this.mobjPanelAddRemove.SuspendLayout();
                this.SuspendLayout();
                // 
                // mobjPanelButtons
                // 
                this.mobjPanelButtons.Controls.Add(this.mobjButtonOk);
                this.mobjPanelButtons.Controls.Add(this.mobjButtonCancel);
                this.mobjPanelButtons.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
                this.mobjPanelButtons.Location = new System.Drawing.Point(5, 377);
                this.mobjPanelButtons.Name = "mobjPanelButtons";
                this.mobjPanelButtons.Size = new System.Drawing.Size(470, 40);
                this.mobjPanelButtons.TabIndex = 0;
                // 
                // mobjPanelItems
                // 
                this.mobjPanelItems.Controls.Add(this.mobjListItems);
                this.mobjPanelItems.Controls.Add(this.mobjPanelAddRemove);
                this.mobjPanelItems.Controls.Add(this.mobjPanelUpDown);
                this.mobjPanelItems.Controls.Add(this.mobjLabelMembers);
                this.mobjPanelItems.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
                this.mobjPanelItems.Location = new System.Drawing.Point(5, 5);
                this.mobjPanelItems.Name = "mobjPanelItems";
                this.mobjPanelItems.Size = new System.Drawing.Size(243, 372);
                this.mobjPanelItems.TabIndex = 1;
                // 
                // mobjPanelProperties
                // 
                this.mobjPanelProperties.Controls.Add(this.mobjPropertyGrid);
                this.mobjPanelProperties.Controls.Add(this.mobjLabelProperties);
                this.mobjPanelProperties.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjPanelProperties.Location = new System.Drawing.Point(248, 5);
                this.mobjPanelProperties.Name = "mobjPanelProperties";
                this.mobjPanelProperties.Size = new System.Drawing.Size(227, 372);
                this.mobjPanelProperties.TabIndex = 2;
                // 
                // mobjLabelMembers
                // 
                this.mobjLabelMembers.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
                this.mobjLabelMembers.Location = new System.Drawing.Point(0, 0);
                this.mobjLabelMembers.Name = "mobjLabelMembers";
                this.mobjLabelMembers.Size = new System.Drawing.Size(243, 23);
                this.mobjLabelMembers.TabIndex = 0;
                this.mobjLabelMembers.Text = "Members:";
                this.mobjLabelMembers.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                // 
                // mobjLabelProperties
                // 
                this.mobjLabelProperties.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
                this.mobjLabelProperties.Location = new System.Drawing.Point(0, 0);
                this.mobjLabelProperties.Name = "mobjLabelProperties";
                this.mobjLabelProperties.Size = new System.Drawing.Size(227, 23);
                this.mobjLabelProperties.TabIndex = 0;
                this.mobjLabelProperties.Text = "{0} properties:";
                this.mobjLabelProperties.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                // 
                // mobjPanelUpDown
                // 
                this.mobjPanelUpDown.Controls.Add(this.mobjButtonDown);
                this.mobjPanelUpDown.Controls.Add(this.mobjButtonUp);
                this.mobjPanelUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
                this.mobjPanelUpDown.Location = new System.Drawing.Point(195, 23);
                this.mobjPanelUpDown.Name = "mobjPanelUpDown";
                this.mobjPanelUpDown.Size = new System.Drawing.Size(48, 349);
                this.mobjPanelUpDown.TabIndex = 1;
                // 
                // mobjPanelAddRemove
                // 
                this.mobjPanelAddRemove.Controls.Add(this.mobjButtonRemove);
                this.mobjPanelAddRemove.Controls.Add(this.mobjButtonAdd);
                this.mobjPanelAddRemove.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
                this.mobjPanelAddRemove.Location = new System.Drawing.Point(0, 332);
                this.mobjPanelAddRemove.Name = "mobjPanelAddRemove";
                this.mobjPanelAddRemove.Size = new System.Drawing.Size(195, 40);
                this.mobjPanelAddRemove.TabIndex = 2;
                // 
                // mobjButtonCancel
                // 
                this.mobjButtonCancel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mobjButtonCancel.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
                this.mobjButtonCancel.Location = new System.Drawing.Point(392, 8);
                this.mobjButtonCancel.Name = "mobjButtonCancel";
                this.mobjButtonCancel.TabIndex = 0;
                this.mobjButtonCancel.Text = "Cancel";
                this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
                // 
                // mobjButtonOk
                // 
                this.mobjButtonOk.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mobjButtonOk.Location = new System.Drawing.Point(304, 8);
                this.mobjButtonOk.Name = "mobjButtonOk";
                this.mobjButtonOk.TabIndex = 1;
                this.mobjButtonOk.Text = "OK";
                this.mobjButtonOk.Click += new System.EventHandler(this.mobjButtonOk_Click);
                // 
                // mobjListItems
                // 
                this.mobjListItems.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjListItems.Location = new System.Drawing.Point(0, 23);
                this.mobjListItems.Name = "mobjListItems";
                this.mobjListItems.Size = new System.Drawing.Size(195, 303);
                this.mobjListItems.TabIndex = 3;
                this.mobjListItems.SelectedIndexChanged += new System.EventHandler(this.mobjListItems_SelectedIndexChanged);
                this.mobjListItems.SelectionMode = SelectionMode.MultiExtended;
                // 
                // mobjPropertyGrid
                // 
                this.mobjPropertyGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                this.mobjPropertyGrid.HelpVisible = false;
                this.mobjPropertyGrid.LargeButtons = false;
                this.mobjPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
                this.mobjPropertyGrid.Location = new System.Drawing.Point(0, 23);
                this.mobjPropertyGrid.Name = "mobjPropertyGrid";
                this.mobjPropertyGrid.Size = new System.Drawing.Size(227, 349);
                this.mobjPropertyGrid.TabIndex = 1;
                this.mobjPropertyGrid.Text = "propertyGrid1";
                this.mobjPropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
                this.mobjPropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
                // 
                // mobjButtonUp
                // 
                this.mobjButtonUp.Location = new System.Drawing.Point(8, 0);
                this.mobjButtonUp.Name = "mobjButtonUp";
                this.mobjButtonUp.Size = new System.Drawing.Size(24, 23);
                this.mobjButtonUp.TabIndex = 0;
                this.mobjButtonUp.Click += new System.EventHandler(this.mobjButtonUp_Click);
                // 
                // mobjButtonDown
                // 
                this.mobjButtonDown.Location = new System.Drawing.Point(8, 32);
                this.mobjButtonDown.Name = "mobjButtonDown";
                this.mobjButtonDown.Size = new System.Drawing.Size(24, 23);
                this.mobjButtonDown.TabIndex = 1;
                this.mobjButtonDown.Click += new System.EventHandler(this.mobjButtonDown_Click);
                // 
                // mobjButtonAdd
                // 
                this.mobjButtonAdd.Location = new System.Drawing.Point(0, 8);
                this.mobjButtonAdd.Name = "mobjButtonAdd";
                this.mobjButtonAdd.Size = new System.Drawing.Size(88, 23);
                this.mobjButtonAdd.TabIndex = 0;
                this.mobjButtonAdd.Text = "Add";
                // 
                // mobjButtonRemove
                // 
                this.mobjButtonRemove.Location = new System.Drawing.Point(96, 8);
                this.mobjButtonRemove.Name = "mobjButtonRemove";
                this.mobjButtonRemove.Size = new System.Drawing.Size(88, 23);
                this.mobjButtonRemove.TabIndex = 1;
                this.mobjButtonRemove.Text = "Remove";
                this.mobjButtonRemove.Click += new System.EventHandler(this.mobjButtonRemove_Click);
                // 
                // Form2
                // 
                this.ClientSize = new System.Drawing.Size(480, 422);
                this.Controls.Add(this.mobjPanelProperties);
                this.Controls.Add(this.mobjPanelItems);
                this.Controls.Add(this.mobjPanelButtons);
                this.DockPadding.All = 5;
                this.Name = "Form2";
                this.Text = "Form2";
                this.mobjPanelButtons.ResumeLayout(false);
                this.mobjPanelItems.ResumeLayout(false);
                this.mobjPanelProperties.ResumeLayout(false);
                this.mobjPanelUpDown.ResumeLayout(false);
                this.mobjPanelAddRemove.ResumeLayout(false);
                this.ResumeLayout(false);

            }

            /// <summary>
            /// Gets the property grid instance.
            /// </summary>
            /// <returns></returns>
            protected internal virtual PropertyGrid GetPropertyGridInstance()
            {
                return new PropertyGrid();
            }

            #endregion

            #region Events

            private void mobjPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
            {
                this.mblnDirty = true;
                this.SuspendEnabledUpdates();
                try
                {
                    CollectionEditor.CollectionEditorCollectionForm.ListItem objListItem = (CollectionEditor.CollectionEditorCollectionForm.ListItem)this.mobjListItems.SelectedItem;
                    if (objListItem != null)
                    {
                        if (objListItem.UpdateDisplayText())
                        {
                            this.mobjListItems.Update();
                            this.mobjLabelProperties.Text = SR.GetString("CollectionEditorProperties", new object[] { this.GetDisplayText(objListItem) });
                        }
                    }
                }
                finally
                {
                    this.ResumeEnabledUpdates(false);
                }
            }

            private void objAddDropDownMenu_MenuClick(object objSource, MenuItemEventArgs objArgs)
            {
                Type objType = objArgs.MenuItem.Tag as Type;
                if (objType != null)
                {
                    this.CreateAndAddInstance(objType);
                }
            }



            private void mobjButtonCancel_Click(object sender, System.EventArgs e)
            {
                try
                {
                    this.mobjCollectionEditor.CancelChanges();
                    if (this.CollectionEditable && this.mblnDirty)
                    {
                        this.mblnDirty = false;
                        this.mobjListItems.Items.Clear();
                        if (this.mobjCreatedItems != null)
                        {
                            object[] arrObjects1 = this.mobjCreatedItems.ToArray();
                            if (((arrObjects1.Length > 0) && (arrObjects1[0] is IComponent)) && (((IComponent)arrObjects1[0]).Site != null))
                            {
                                return;
                            }
                            for (int num1 = 0; num1 < arrObjects1.Length; num1++)
                            {
                                base.DestroyInstance(arrObjects1[num1]);
                            }
                            this.mobjCreatedItems.Clear();
                        }
                        if (this.mobjRemovedItems != null)
                        {
                            this.mobjRemovedItems.Clear();
                        }
                        if ((this.mobjOriginalItems != null) && (this.mobjOriginalItems.Count > 0))
                        {
                            object[] arrObjects2 = new object[this.mobjOriginalItems.Count];
                            for (int num2 = 0; num2 < this.mobjOriginalItems.Count; num2++)
                            {
                                arrObjects2[num2] = this.mobjOriginalItems[num2];
                            }
                            base.Items = arrObjects2;
                            this.mobjOriginalItems.Clear();
                        }
                        else
                        {
                            base.Items = new object[0];
                        }


                    }

                    this.Close();
                }
                catch (Exception objException1)
                {
                    base.DialogResult = DialogResult.None;
                    this.DisplayError(objException1);
                }

            }

            private void mobjButtonOk_Click(object sender, System.EventArgs e)
            {
                try
                {
                    if (!this.mblnDirty || !this.CollectionEditable)
                    {
                        this.mblnDirty = false;
                        base.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        if (this.mblnDirty)
                        {
                            object[] arrItems = new object[this.mobjListItems.Items.Count];
                            for (int num1 = 0; num1 < arrItems.Length; num1++)
                            {
                                arrItems[num1] = ((CollectionEditor.CollectionEditorCollectionForm.ListItem)this.mobjListItems.Items[num1]).Value;
                            }
                            base.Items = arrItems;
                        }
                        if ((this.mobjRemovedItems != null) && this.mblnDirty)
                        {
                            object[] arrObjects2 = this.mobjRemovedItems.ToArray();
                            for (int num2 = 0; num2 < arrObjects2.Length; num2++)
                            {
                                base.DestroyInstance(arrObjects2[num2]);
                            }
                            this.mobjRemovedItems.Clear();
                        }
                        if (this.mobjCreatedItems != null)
                        {
                            this.mobjCreatedItems.Clear();
                        }
                        if (this.mobjOriginalItems != null)
                        {
                            this.mobjOriginalItems.Clear();
                        }
                        this.mobjListItems.Items.Clear();
                        this.mblnDirty = false;
                    }

                    this.Close();
                }
                catch (Exception objException1)
                {
                    base.DialogResult = DialogResult.None;
                    this.DisplayError(objException1);
                }

            }

            private void mobjButtonRemove_Click(object sender, System.EventArgs e)
            {
                this.PerformRemove();
            }

            private void PerformRemove()
            {
                int num1 = this.mobjListItems.SelectedIndex;
                if (num1 != -1)
                {
                    this.SuspendEnabledUpdates();
                    try
                    {
                        if (this.mobjListItems.SelectedItems.Count > 1)
                        {
                            ArrayList objList = new ArrayList(this.mobjListItems.SelectedItems);
                            foreach (CollectionEditor.CollectionEditorCollectionForm.ListItem objItem in objList)
                            {
                                this.RemoveInternal(objItem);
                            }
                        }
                        else
                        {
                            this.RemoveInternal((CollectionEditor.CollectionEditorCollectionForm.ListItem)this.mobjListItems.SelectedItem);
                        }
                        if (num1 < this.mobjListItems.Items.Count)
                        {
                            this.mobjListItems.SelectedIndex = num1;
                        }
                        else if (this.mobjListItems.Items.Count > 0)
                        {
                            this.mobjListItems.SelectedIndex = this.mobjListItems.Items.Count - 1;
                        }
                    }
                    finally
                    {
                        this.ResumeEnabledUpdates();
                    }
                }
            }

            private void RemoveInternal(CollectionEditor.CollectionEditorCollectionForm.ListItem objItem)
            {
                if (objItem != null)
                {
                    this.mobjCollectionEditor.OnItemRemoving(objItem.Value);
                    this.mblnDirty = true;
                    if ((this.mobjCreatedItems != null) && this.mobjCreatedItems.Contains(objItem.Value))
                    {
                        base.DestroyInstance(objItem.Value);
                        this.mobjCreatedItems.Remove(objItem.Value);
                        this.mobjListItems.Items.Remove(objItem);
                    }
                    else
                    {
                        try
                        {
                            if (!base.CanRemoveInstance(objItem.Value))
                            {
                                throw new Exception(SR.GetString("CollectionEditorCantRemoveItem", new object[] { this.GetDisplayText(objItem) }));
                            }
                            if (this.mobjRemovedItems == null)
                            {
                                this.mobjRemovedItems = new ArrayList();
                            }
                            this.mobjRemovedItems.Add(objItem.Value);
                            this.mobjListItems.Items.Remove(objItem);
                        }
                        catch (Exception objException1)
                        {
                            this.DisplayError(objException1);
                        }
                    }
                }
            }





            private void mobjButtonAdd_Click(object sender, System.EventArgs e)
            {
                this.PerformAdd();
            }

            private void PerformAdd()
            {
                this.CreateAndAddInstance(base.NewItemTypes[0]);
            }

            private void CreateAndAddInstance(Type objType)
            {
                try
                {
                    object obj1 = base.CreateInstance(objType);
                    IList objList = this.mobjCollectionEditor.GetObjectsFromInstance(obj1);
                    if (objList != null)
                    {
                        this.AddItems(objList);

                    }
                }
                catch (Exception objException1)
                {
                    this.DisplayError(objException1);
                }
            }

            private void AddItems(IList objInstances)
            {
                if (this.mobjCreatedItems == null)
                {
                    this.mobjCreatedItems = new ArrayList();
                }
                //this.mobjListItems.BeginUpdate();
                try
                {
                    foreach (object obj1 in objInstances)
                    {
                        if (obj1 != null)
                        {
                            this.mblnDirty = true;
                            this.mobjCreatedItems.Add(obj1);
                            CollectionEditor.CollectionEditorCollectionForm.ListItem objItem = new CollectionEditor.CollectionEditorCollectionForm.ListItem(this.mobjCollectionEditor, obj1);
                            objItem.UpdateDisplayText();
                            this.mobjListItems.Items.Add(objItem);
                        }
                    }
                }
                finally
                {
                    //this.mobjListItems.EndUpdate();
                }

                this.SuspendEnabledUpdates();
                try
                {
                    this.mobjListItems.ClearSelected();
                    this.mobjListItems.SelectedIndex = this.mobjListItems.Items.Count - 1;
                    object[] arrItems = new object[this.mobjListItems.Items.Count];
                    for (int num1 = 0; num1 < arrItems.Length; num1++)
                    {
                        arrItems[num1] = ((CollectionEditor.CollectionEditorCollectionForm.ListItem)this.mobjListItems.Items[num1]).Value;
                    }
                    base.Items = arrItems;
                    if ((this.mobjListItems.Items.Count > 0) && (this.mobjListItems.SelectedIndex != (this.mobjListItems.Items.Count - 1)))
                    {
                        this.mobjListItems.ClearSelected();
                        this.mobjListItems.SelectedIndex = this.mobjListItems.Items.Count - 1;
                    }
                }
                finally
                {
                    this.ResumeEnabledUpdates();
                }
            }




            private void mobjListItems_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                this.UpdateEnabled();
            }

            private void mobjButtonUp_Click(object sender, System.EventArgs e)
            {
                int num1 = this.mobjListItems.SelectedIndex;
                if (num1 != 0)
                {
                    this.mblnDirty = true;
                    try
                    {
                        this.SuspendEnabledUpdates();
                        //int num2 = this.mobjListItems.TopIndex;
                        object obj1 = this.mobjListItems.Items[num1];
                        this.mobjListItems.Items[num1] = this.mobjListItems.Items[num1 - 1];
                        this.mobjListItems.Items[num1 - 1] = obj1;
                        //if (num2 > 0)
                        //{
                        //    this.mobjListItems.TopIndex = num2 - 1;
                        //}
                        this.mobjListItems.ClearSelected();
                        this.mobjListItems.SelectedIndex = num1 - 1;
                        Control objControl1 = (Control)sender;
                        if (objControl1.Enabled)
                        {
                            objControl1.Focus();
                        }
                    }
                    finally
                    {
                        this.ResumeEnabledUpdates(false);
                    }
                }

            }

            private void mobjButtonDown_Click(object sender, System.EventArgs e)
            {
                try
                {
                    this.SuspendEnabledUpdates();
                    this.mblnDirty = true;
                    int num1 = this.mobjListItems.SelectedIndex;
                    if (num1 != (this.mobjListItems.Items.Count - 1))
                    {
                        //int num2 = this.mobjListItems.TopIndex;
                        object obj1 = this.mobjListItems.Items[num1];
                        this.mobjListItems.Items[num1] = this.mobjListItems.Items[num1 + 1];
                        this.mobjListItems.Items[num1 + 1] = obj1;
                        //if (num2 < (this.mobjListItems.Items.Count - 1))
                        //{
                        //    this.mobjListItems.TopIndex = num2 + 1;
                        // }
                        this.mobjListItems.ClearSelected();
                        this.mobjListItems.SelectedIndex = num1 + 1;
                        Control objControl1 = (Control)sender;
                        if (objControl1.Enabled)
                        {
                            objControl1.Focus();
                        }
                    }
                }
                finally
                {
                    this.ResumeEnabledUpdates(false);
                }

            }

            #endregion Events

            private void SuspendEnabledUpdates()
            {
                this.mintSuspendEnabledCount++;
            }

            private void ResumeEnabledUpdates()
            {
                ResumeEnabledUpdates(true);
            }

            private void ResumeEnabledUpdates(bool blnUpdateGrid)
            {
                this.mintSuspendEnabledCount--;
                this.UpdateEnabled(blnUpdateGrid);
            }

            protected override void OnEditValueChanged()
            {

                if (this.mobjOriginalItems == null)
                {
                    this.mobjOriginalItems = new ArrayList();
                }
                this.mobjOriginalItems.Clear();
                this.mobjListItems.Items.Clear();
                this.mobjPropertyGrid.Site = new CollectionEditor.PropertyGridSite(base.Context, this.mobjPropertyGrid);
                if (base.EditValue != null)
                {
                    this.SuspendEnabledUpdates();
                    try
                    {
                        object[] arrItems = base.Items;
                        for (int num1 = 0; num1 < arrItems.Length; num1++)
                        {
                            CollectionEditor.CollectionEditorCollectionForm.ListItem objListItem = new CollectionEditor.CollectionEditorCollectionForm.ListItem(this.mobjCollectionEditor, arrItems[num1]);
                            objListItem.UpdateDisplayText();
                            this.mobjListItems.Items.Add(objListItem);
                            this.mobjOriginalItems.Add(arrItems[num1]);
                        }
                        if (this.mobjListItems.Items.Count > 0)
                        {
                            this.mobjListItems.SelectedIndex = 0;
                        }
                        return;
                    }
                    finally
                    {
                        this.ResumeEnabledUpdates();
                    }
                }
                this.UpdateEnabled();



            }

            private void UpdateEnabled()
            {
                UpdateEnabled(true);
            }

            private void UpdateEnabled(bool blnUpdateGrid)
            {
                if (this.mintSuspendEnabledCount <= 0)
                {
                    bool blnFlag1 = (this.mobjListItems.SelectedItem != null) && this.CollectionEditable;
                    this.mobjButtonRemove.Enabled = blnFlag1 && this.AllowRemoveInstance(((CollectionEditor.CollectionEditorCollectionForm.ListItem)this.mobjListItems.SelectedItem).Value);
                    this.mobjButtonUp.Enabled = blnFlag1 && (this.mobjListItems.Items.Count > 1);
                    this.mobjButtonDown.Enabled = blnFlag1 && (this.mobjListItems.Items.Count > 1);
                    this.mobjPropertyGrid.Enabled = blnFlag1;
                    this.mobjButtonAdd.Enabled = this.CollectionEditable;
                    if (this.mobjListItems.SelectedItem == null)
                    {
                        this.mobjLabelProperties.Text = SR.GetString("CollectionEditorPropertiesNone");
                        this.mobjPropertyGrid.SelectedObject = null;
                    }
                    else
                    {
                        object[] arrItems;
                        if (this.IsImmutable)
                        {
                            arrItems = new object[] { new CollectionEditor.CollectionEditorCollectionForm.SelectionWrapper(base.CollectionType, base.CollectionItemType, this.mobjListItems, this.mobjListItems.SelectedItems) };
                        }
                        else
                        {
                            arrItems = new object[this.mobjListItems.SelectedItems.Count];
                            for (int num1 = 0; num1 < arrItems.Length; num1++)
                            {
                                object objValue = ((CollectionEditor.CollectionEditorCollectionForm.ListItem)this.mobjListItems.SelectedItems[num1]).Value;

                                arrItems[num1] = GetPropertyGridSelectedObjectFromValue(objValue);
                            }
                        }
                        switch (this.mobjListItems.SelectedItems.Count)
                        {
                            case 1:
                            case -1:
                                this.mobjLabelProperties.Text = SR.GetString("CollectionEditorProperties", new object[] { this.GetDisplayText((CollectionEditor.CollectionEditorCollectionForm.ListItem)this.mobjListItems.SelectedItem) });
                                break;

                            default:
                                this.mobjLabelProperties.Text = SR.GetString("CollectionEditorPropertiesMultiSelect");
                                break;
                        }
                        if (this.mobjCollectionEditor.IsAnyObjectInheritedReadOnly(arrItems))
                        {
                            this.mobjPropertyGrid.SelectedObjects = null;
                            this.mobjPropertyGrid.Enabled = false;
                            this.mobjButtonRemove.Enabled = false;
                            this.mobjButtonUp.Enabled = false;
                            this.mobjButtonDown.Enabled = false;
                            this.mobjLabelProperties.Text = SR.GetString("CollectionEditorInheritedReadOnlySelection");
                        }
                        else
                        {
                            this.mobjPropertyGrid.Enabled = true;
                            if (blnUpdateGrid)
                            {
                                this.mobjPropertyGrid.SelectedObjects = arrItems;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Gets the property grid selected object from value.
            /// </summary>
            /// <param name="objValue">The object value.</param>
            /// <returns></returns>
            protected internal virtual object GetPropertyGridSelectedObjectFromValue(object objValue)
            {
                return objValue;
            }

            private bool AllowRemoveInstance(object objValue)
            {
                if ((this.mobjCreatedItems != null) && this.mobjCreatedItems.Contains(objValue))
                {
                    return true;
                }
                return base.CanRemoveInstance(objValue);
            }

            private string GetDisplayText(CollectionEditor.CollectionEditorCollectionForm.ListItem objItem)
            {
                if (objItem != null)
                {
                    return objItem.ToString();
                }
                return string.Empty;
            }


            private bool IsImmutable
            {
                get
                {
                    bool blnFlag1 = true;
                    if (!TypeDescriptor.GetConverter(base.CollectionItemType).GetCreateInstanceSupported())
                    {
                        foreach (PropertyDescriptor objPropertyDescriptor1 in TypeDescriptor.GetProperties(base.CollectionItemType))
                        {
                            if (!objPropertyDescriptor1.IsReadOnly)
                            {
                                return false;
                            }
                        }
                    }
                    return blnFlag1;
                }
            }

            #endregion Methods

            #region Properties

            /// <summary>
            /// Gets the property grid.
            /// </summary>
            /// <value>
            /// The property grid.
            /// </value>
            internal PropertyGrid PropertyGrid
            {
                get
                {
                    return mobjPropertyGrid;
                }
            }

            #endregion Properties

        }




        #endregion CollectionEditorCollectionForm Class

        #region CollectionForm Class

        /// <summary>Provides a modal dialog box for editing the contents of a collection using a <see cref="T:System.Drawing.Design.UITypeEditor"></see>.</summary>

        [Serializable()]
        protected internal abstract class CollectionForm : Form
        {
            private const short mcntEditableDynamic = 0;
            private const short mcntEditableNo = 2;
            private short mshortEditableState;
            private const short mcntEditableYes = 1;
            private CollectionEditor mobjEditor;
            private object mobjValue;

            /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm"></see> class.</summary>
            /// <param name="objEditor">The <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> to use for editing the collection. </param>
            public CollectionForm(CollectionEditor objEditor)
            {
                this.mobjEditor = objEditor;
            }

            /// <summary>Indicates whether you can remove the original members of the collection.</summary>
            /// <returns>true if it is permissible to remove this value from the collection; otherwise, false. By default, this method returns the value from <see cref="M:System.ComponentModel.Design.CollectionEditor.CanRemoveInstance(System.Object)"></see> of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> for this form.</returns>
            /// <param name="value">The value to remove. </param>
            protected bool CanRemoveInstance(object objValue)
            {
                return this.mobjEditor.CanRemoveInstance(objValue);
            }

            /// <summary>Indicates whether multiple collection items can be selected at once.</summary>
            /// <returns>true if it multiple collection members can be selected at the same time; otherwise, false. By default, this method returns the value from <see cref="M:System.ComponentModel.Design.CollectionEditor.CanSelectMultipleInstances"></see> of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> for this form.</returns>
            protected virtual bool CanSelectMultipleInstances()
            {
                return this.mobjEditor.CanSelectMultipleInstances();
            }

            /// <summary>Creates a new instance of the specified collection item type.</summary>
            /// <returns>A new instance of the specified object, or null if the user chose to cancel the creation of this instance.</returns>
            /// <param name="objItemType">The type of item to create. </param>
            protected object CreateInstance(Type objItemType)
            {
                return this.mobjEditor.CreateInstance(objItemType);
            }

            /// <summary>Destroys the specified instance of the object.</summary>
            /// <param name="objInstance">The object to destroy. </param>
            protected void DestroyInstance(object objInstance)
            {
                this.mobjEditor.DestroyInstance(objInstance);
            }

            /// <summary>Displays the specified exception to the user.</summary>
            /// <param name="objException">The exception to display. </param>
            protected virtual void DisplayError(Exception objException)
            {
            }

            /// <summary>Gets the requested service, if it is available.</summary>
            /// <returns>An instance of the service, or null if the service cannot be found.</returns>
            /// <param name="objServiceType">The type of service to retrieve. </param>
            protected override object GetService(Type objServiceType)
            {
                return this.mobjEditor.GetService(objServiceType);
            }

            /// <summary>Provides an opportunity to perform processing when a collection value has changed.</summary>
            protected abstract void OnEditValueChanged();
            /// <summary>Shows the dialog box for the collection editor using the specified <see cref="T:Gizmox.WebGUI.Forms.Design.IWindowsFormsEditorService"></see> object.</summary>
            /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> that indicates the result code returned from the dialog box.</returns>
            /// <param name="objEditorService">An <see cref="T:Gizmox.WebGUI.Forms.Design.IWebUIEditorService"></see> that can be used to show the dialog box. </param>
            protected internal virtual void ShowEditorDialog(IWebUIEditorService objEditorService)
            {
                objEditorService.ShowDialog(this);
            }


            internal virtual bool CollectionEditable
            {
                get
                {
                    if (this.mshortEditableState != 0)
                    {
                        return (this.mshortEditableState == 1);
                    }
                    bool blnFlag1 = typeof(IList).IsAssignableFrom(this.mobjEditor.CollectionType);
                    if (blnFlag1)
                    {
                        IList objList = this.EditValue as IList;
                        if (objList != null)
                        {
                            return !objList.IsReadOnly;
                        }
                    }
                    return blnFlag1;
                }
                set
                {
                    if (value)
                    {
                        this.mshortEditableState = 1;
                    }
                    else
                    {
                        this.mshortEditableState = 2;
                    }
                }

            }

            /// <summary>Gets the data type of each item in the collection.</summary>
            /// <returns>The data type of the collection items.</returns>
            protected Type CollectionItemType
            {
                get
                {
                    return this.mobjEditor.CollectionItemType;
                }
            }

            /// <summary>Gets the data type of the collection object.</summary>
            /// <returns>The data type of the collection object.</returns>
            protected Type CollectionType
            {
                get
                {
                    return this.mobjEditor.CollectionType;
                }

            }

            /// <summary>Gets a type descriptor that indicates the current context.</summary>
            /// <returns>An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that indicates the context currently in use, or null if no context is available.</returns>
            new protected ITypeDescriptorContext Context
            {
                get
                {
                    return this.mobjEditor.Context;
                }
            }

            /// <summary>Gets or sets the collection object to edit.</summary>
            /// <returns>The collection object to edit.</returns>
            public object EditValue
            {
                get
                {
                    return this.mobjValue;
                }
                set
                {
                    this.mobjValue = value;
                    this.OnEditValueChanged();
                }

            }

            /// <summary>Gets or sets the array of items for this form to display.</summary>
            /// <returns>An array of objects for the form to display.</returns>
            protected object[] Items
            {
                get
                {
                    return this.mobjEditor.GetItems(this.EditValue);
                }
                set
                {
                    bool blnFlag1 = false;
                    try
                    {
                        blnFlag1 = this.Context.OnComponentChanging();
                    }
                    catch (Exception objException1)
                    {
                        if (ClientUtils.IsCriticalException(objException1))
                        {
                            throw;
                        }
                        this.DisplayError(objException1);
                    }
                    if (blnFlag1)
                    {
                        object obj1 = this.mobjEditor.SetItems(this.EditValue, value);
                        if (obj1 != this.EditValue)
                        {
                            this.EditValue = obj1;
                        }
                        this.Context.OnComponentChanged();
                    }
                }

            }

            /// <summary>Gets the available item types that can be created for this collection.</summary>
            /// <returns>The types of items that can be created.</returns>
            protected Type[] NewItemTypes
            {
                get
                {
                    return this.mobjEditor.NewItemTypes;
                }

            }

            /// <summary>
            /// Gets the display name of the type.
            /// </summary>
            /// <param name="objType">Type of the object.</param>
            /// <returns></returns>
            protected string GetTypeDisplayName(Type objType)
            {
                object[] objAttributes = objType.GetCustomAttributes(typeof(WebCollectionEditorItemTypeNameAttribute), true);
                if (objAttributes.Length == 1)
                {
                    WebCollectionEditorItemTypeNameAttribute objAttribute = objAttributes[0] as WebCollectionEditorItemTypeNameAttribute;

                    return objAttribute.DisplayName;
                }

                return objType.Name;
            }
        }


        #endregion CollectionForm Class

        #endregion

        #region Class Memebers

        private Type mobjCollectionItemType;
        private ITypeDescriptorContext mobjCurrentContext;
        private Type[] marrNewItemTypes;
        private Type mobjType;


        #endregion Class Memebers

        #region C'Tor

        /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> class using the specified collection type.</summary>
        /// <param name="objType">The type of the collection for this editor to edit. </param>
        public CollectionEditor(Type objType)
        {
            this.mobjType = objType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> class using the specified collection type.
        /// </summary>
        public CollectionEditor()
        {
        }

        #endregion C'Tor

        #region Methods

        /// <summary>Cancels changes to the collection.</summary>
        protected virtual void CancelChanges()
        {
        }

        /// <summary>Indicates whether original members of the collection can be removed.</summary>
        /// <returns>true if it is permissible to remove this value from the collection; otherwise, false. The default implementation always returns true.</returns>
        /// <param name="value">The value to remove. </param>
        protected virtual bool CanRemoveInstance(object objValue)
        {
            IComponent objComponent = objValue as IComponent;
            if (objComponent != null)
            {
                InheritanceAttribute objAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(objComponent)[typeof(InheritanceAttribute)];
                if ((objAttribute != null) && (objAttribute.InheritanceLevel != InheritanceLevel.NotInherited))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>Indicates whether multiple collection items can be selected at once.</summary>
        /// <returns>true if it multiple collection members can be selected at the same time; otherwise, false. By default, this returns true.</returns>
        protected virtual bool CanSelectMultipleInstances()
        {
            return true;
        }

        /// <summary>Creates a new form to display and edit the current collection.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm"></see> to provide as the user interface for editing the collection.</returns>
        protected virtual CollectionForm CreateCollectionForm()
        {
            return new CollectionEditor.CollectionEditorCollectionForm(this);
        }

        /// <summary>Gets the data type that this collection contains.</summary>
        /// <returns>The data type of the items in the collection, or an <see cref="T:System.Object"></see> if no Item property can be located on the collection.</returns>
        protected virtual Type CreateCollectionItemType()
        {
            PropertyInfo[] arrPropertyInfos = this.CollectionType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int intIndex = 0; intIndex < arrPropertyInfos.Length; intIndex++)
            {
                if (arrPropertyInfos[intIndex].Name.Equals("Item") || arrPropertyInfos[intIndex].Name.Equals("Items"))
                {
                    return arrPropertyInfos[intIndex].PropertyType;
                }
            }
            return typeof(object);
        }

        /// <summary>Creates a new instance of the specified collection item type.</summary>
        /// <returns>A new instance of the specified object.</returns>
        /// <param name="objItemType">The type of item to create. </param>
        protected virtual object CreateInstance(Type objItemType)
        {
            object objInstance = CollectionEditor.CreateInstance(objItemType, null);

            return objInstance;
        }

        internal static object CreateInstance(Type objItemType, string strName)
        {
            object objInstance = null;
            objInstance = Activator.CreateInstance(objItemType);
            return objInstance;

        }

        /// <summary>Gets the data types that this collection editor can contain.</summary>
        /// <returns>An array of data types that this collection can contain.</returns>
        protected virtual Type[] CreateNewItemTypes()
        {
            return new Type[] { this.CollectionItemType };
        }

        /// <summary>Destroys the specified instance of the object.</summary>
        /// <param name="objInstance">The object to destroy. </param>
        protected virtual void DestroyInstance(object objInstance)
        {
            IComponent objComponent = objInstance as IComponent;
            if (objComponent != null)
            {
                objComponent.Dispose();
            }
            else
            {
                IDisposable objDisposable = objInstance as IDisposable;
                if (objDisposable != null)
                {
                    objDisposable.Dispose();
                }
            }

        }

        /// <summary>Edits the value of the specified object using the specified service provider and context.</summary>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
        /// <param name="objValue">The object to edit the value of. </param>
        /// <param name="objProvider">A service provider object through which editing services can be obtained. </param>
        /// <param name="objHandler"></param>
        /// <exception cref="T:System.ComponentModel.Design.CheckoutException">An attempt to check out a file that is checked into a source code management program did not succeed.</exception>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            if (objProvider != null)
            {
                IWebUIEditorService objService = (IWebUIEditorService)objProvider.GetService(typeof(IWebUIEditorService));
                if (objService == null)
                {
                    return;
                }
                this.mobjCurrentContext = objContext;
                CollectionEditor.CollectionForm objForm = this.CreateCollectionForm();
                ITypeDescriptorContext objContext1 = this.mobjCurrentContext;
                objForm.EditValue = objValue;


                objForm.ShowEditorDialog(objService);

            }
        }

        /// <summary>Retrieves the display text for the given list item.</summary>
        /// <returns>The display text for value.</returns>
        /// <param name="objValue">The list item for which to retrieve display text.</param>
        protected virtual string GetDisplayText(object objValue)
        {
            string strText1;
            if (objValue == null)
            {
                return string.Empty;
            }
            PropertyDescriptor objPropertyDescriptor1 = TypeDescriptor.GetProperties(objValue)["Name"];
            if ((objPropertyDescriptor1 != null) && (objPropertyDescriptor1.PropertyType == typeof(string)))
            {
                strText1 = (string)objPropertyDescriptor1.GetValue(objValue);
                if ((strText1 != null) && (strText1.Length > 0))
                {
                    return strText1;
                }
            }
            objPropertyDescriptor1 = TypeDescriptor.GetDefaultProperty(this.CollectionType);
            if ((objPropertyDescriptor1 != null) && (objPropertyDescriptor1.PropertyType == typeof(string)))
            {
                strText1 = (string)objPropertyDescriptor1.GetValue(objValue);
                if ((strText1 != null) && (strText1.Length > 0))
                {
                    return strText1;
                }
            }
            strText1 = TypeDescriptor.GetConverter(objValue).ConvertToString(objValue);
            if ((strText1 != null) && (strText1.Length != 0))
            {
                return strText1;
            }
            return objValue.GetType().Name;

        }

        /// <summary>Gets the edit style used by the <see cref="M:System.ComponentModel.Design.CollectionEditor.EditValue(System.ComponentModel.ITypeDescriptorContext,System.IServiceProvider,System.Object)"></see> method.</summary>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> enumeration value indicating the provided editing style. If the method is not supported in the specified context, this method will return the <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see> identifier.</returns>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>Gets an array of objects containing the specified collection.</summary>
        /// <returns>An array containing the collection objects, or an empty object array if the specified collection does not inherit from <see cref="T:System.Collections.ICollection"></see>.</returns>
        /// <param name="objEditValue">The collection to edit. </param>
        protected virtual object[] GetItems(object objEditValue)
        {
            if ((objEditValue == null) || !(objEditValue is ICollection))
            {
                return new object[0];
            }
            ArrayList objList = new ArrayList();
            ICollection objCollection1 = (ICollection)objEditValue;
            foreach (object obj1 in objCollection1)
            {
                objList.Add(obj1);
            }
            object[] arrItems = new object[objList.Count];
            objList.CopyTo(arrItems, 0);
            return arrItems;

        }

        /// <summary>Returns a list containing the given object</summary>
        /// <returns>An <see cref="T:System.Collections.ArrayList"></see> which contains the individual objects to be created.</returns>
        /// <param name="objInstance">An <see cref="T:System.Collections.ArrayList"></see> returned as an object.</param>
        protected virtual IList GetObjectsFromInstance(object objInstance)
        {
            ArrayList objList = new ArrayList();
            objList.Add(objInstance);
            return objList;

        }

        /// <summary>Gets the requested service, if it is available.</summary>
        /// <returns>An instance of the service, or null if the service cannot be found.</returns>
        /// <param name="objServiceType">The type of service to retrieve. </param>
        protected object GetService(Type objServiceType)
        {
            if (this.Context != null)
            {
                return this.Context.GetService(objServiceType);
            }
            return null;
        }

        private bool IsAnyObjectInheritedReadOnly(object[] arrItems)
        {

            return false;

        }



        internal virtual void OnItemRemoving(object objItem)
        {
        }

        /// <summary>Sets the specified array as the items of the collection.</summary>
        /// <returns>The newly created collection object or, otherwise, the collection indicated by the editValue parameter.</returns>
        /// <param name="objEditValue">The collection to edit. </param>
        /// <param name="arrValues">An array of objects to set as the collection items. </param>
        protected virtual object SetItems(object objEditValue, object[] arrValues)
        {
            if (objEditValue != null)
            {
                Array objArray = this.GetItems(objEditValue);
                int num2 = objArray.Length;
                int num3 = arrValues.Length;
                if (!(objEditValue is IList))
                {
                    return objEditValue;
                }
                IList objList = (IList)objEditValue;
                objList.Clear();
                for (int num1 = 0; num1 < arrValues.Length; num1++)
                {
                    objList.Add(arrValues[num1]);
                }
            }
            return objEditValue;
        }

        /// <summary>Displays the default Help topic for the collection editor.</summary>
        protected virtual void ShowHelp()
        {
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets the data type of each item in the collection.</summary>
        /// <returns>The data type of the collection items.</returns>
        protected Type CollectionItemType
        {
            get
            {
                if (this.mobjCollectionItemType == null)
                {
                    this.mobjCollectionItemType = this.CreateCollectionItemType();
                }
                return this.mobjCollectionItemType;

            }
        }

        /// <summary>Gets the data type of the collection object.</summary>
        /// <returns>The data type of the collection object.</returns>
        protected Type CollectionType
        {
            get
            {
                return this.mobjType;
            }
        }

        /// <summary>Gets a type descriptor that indicates the current context.</summary>
        /// <returns>An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that indicates the context currently in use, or null if no context is available.</returns>
        protected ITypeDescriptorContext Context
        {
            get
            {
                return this.mobjCurrentContext;
            }
        }


        /// <summary>Gets the available types of items that can be created for this collection.</summary>
        /// <returns>The types of items that can be created.</returns>
        protected Type[] NewItemTypes
        {
            get
            {
                if (this.marrNewItemTypes == null)
                {
                    this.marrNewItemTypes = this.CreateNewItemTypes();
                }
                return this.marrNewItemTypes;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this editor value should support text editing.
        /// </summary>
        /// <value></value>
        /// <returns>true if editor value should support text editing; otherwise, false. </returns>
        public override bool IsTextEditable
        {
            get
            {
                return false;
            }
        }

        #endregion Properties

    }
}