// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.CollectionEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>Provides a user interface that can edit most types of collections at design time.</summary>
  [Serializable]
  public class CollectionEditor : WebUITypeEditor
  {
    private Type mobjCollectionItemType;
    private ITypeDescriptorContext mobjCurrentContext;
    private Type[] marrNewItemTypes;
    private Type mobjType;

    /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> class using the specified collection type.</summary>
    /// <param name="objType">The type of the collection for this editor to edit. </param>
    public CollectionEditor(Type objType) => this.mobjType = objType;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> class using the specified collection type.
    /// </summary>
    public CollectionEditor()
    {
    }

    /// <summary>Cancels changes to the collection.</summary>
    protected virtual void CancelChanges()
    {
    }

    /// <summary>Indicates whether original members of the collection can be removed.</summary>
    /// <returns>true if it is permissible to remove this value from the collection; otherwise, false. The default implementation always returns true.</returns>
    /// <param name="value">The value to remove. </param>
    protected virtual bool CanRemoveInstance(object objValue)
    {
      if (objValue is IComponent component)
      {
        InheritanceAttribute attribute = (InheritanceAttribute) TypeDescriptor.GetAttributes((object) component)[typeof (InheritanceAttribute)];
        if (attribute != null && attribute.InheritanceLevel != InheritanceLevel.NotInherited)
          return false;
      }
      return true;
    }

    /// <summary>Indicates whether multiple collection items can be selected at once.</summary>
    /// <returns>true if it multiple collection members can be selected at the same time; otherwise, false. By default, this returns true.</returns>
    protected virtual bool CanSelectMultipleInstances() => true;

    /// <summary>Creates a new form to display and edit the current collection.</summary>
    /// <returns>A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm"></see> to provide as the user interface for editing the collection.</returns>
    protected virtual CollectionEditor.CollectionForm CreateCollectionForm() => (CollectionEditor.CollectionForm) new CollectionEditor.CollectionEditorCollectionForm(this);

    /// <summary>Gets the data type that this collection contains.</summary>
    /// <returns>The data type of the items in the collection, or an <see cref="T:System.Object"></see> if no Item property can be located on the collection.</returns>
    protected virtual Type CreateCollectionItemType()
    {
      PropertyInfo[] properties = this.CollectionType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
      for (int index = 0; index < properties.Length; ++index)
      {
        if (properties[index].Name.Equals("Item") || properties[index].Name.Equals("Items"))
          return properties[index].PropertyType;
      }
      return typeof (object);
    }

    /// <summary>Creates a new instance of the specified collection item type.</summary>
    /// <returns>A new instance of the specified object.</returns>
    /// <param name="objItemType">The type of item to create. </param>
    protected virtual object CreateInstance(Type objItemType) => CollectionEditor.CreateInstance(objItemType, (string) null);

    internal static object CreateInstance(Type objItemType, string strName) => Activator.CreateInstance(objItemType);

    /// <summary>Gets the data types that this collection editor can contain.</summary>
    /// <returns>An array of data types that this collection can contain.</returns>
    protected virtual Type[] CreateNewItemTypes() => new Type[1]
    {
      this.CollectionItemType
    };

    /// <summary>Destroys the specified instance of the object.</summary>
    /// <param name="objInstance">The object to destroy. </param>
    protected virtual void DestroyInstance(object objInstance)
    {
      switch (objInstance)
      {
        case IComponent component:
          component.Dispose();
          break;
        case IDisposable disposable:
          disposable.Dispose();
          break;
      }
    }

    /// <summary>Edits the value of the specified object using the specified service provider and context.</summary>
    /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
    /// <param name="objValue">The object to edit the value of. </param>
    /// <param name="objProvider">A service provider object through which editing services can be obtained. </param>
    /// <param name="objHandler"></param>
    /// <exception cref="T:System.ComponentModel.Design.CheckoutException">An attempt to check out a file that is checked into a source code management program did not succeed.</exception>
    public override void EditValue(
      ITypeDescriptorContext objContext,
      IServiceProvider objProvider,
      object objValue,
      WebUITypeEditorHandler objHandler)
    {
      if (objProvider == null)
        return;
      IWebUIEditorService service = (IWebUIEditorService) objProvider.GetService(typeof (IWebUIEditorService));
      if (service == null)
        return;
      this.mobjCurrentContext = objContext;
      CollectionEditor.CollectionForm collectionForm = this.CreateCollectionForm();
      ITypeDescriptorContext mobjCurrentContext = this.mobjCurrentContext;
      collectionForm.EditValue = objValue;
      collectionForm.ShowEditorDialog(service);
    }

    /// <summary>Retrieves the display text for the given list item.</summary>
    /// <returns>The display text for value.</returns>
    /// <param name="objValue">The list item for which to retrieve display text.</param>
    protected virtual string GetDisplayText(object objValue)
    {
      if (objValue == null)
        return string.Empty;
      PropertyDescriptor property = TypeDescriptor.GetProperties(objValue)["Name"];
      if (property != null && property.PropertyType == typeof (string))
      {
        string displayText = (string) property.GetValue(objValue);
        if (displayText != null && displayText.Length > 0)
          return displayText;
      }
      PropertyDescriptor defaultProperty = TypeDescriptor.GetDefaultProperty(this.CollectionType);
      if (defaultProperty != null && defaultProperty.PropertyType == typeof (string))
      {
        string displayText = (string) defaultProperty.GetValue(objValue);
        if (displayText != null && displayText.Length > 0)
          return displayText;
      }
      string str = TypeDescriptor.GetConverter(objValue).ConvertToString(objValue);
      return str != null && str.Length != 0 ? str : objValue.GetType().Name;
    }

    /// <summary>Gets the edit style used by the <see cref="M:System.ComponentModel.Design.CollectionEditor.EditValue(System.ComponentModel.ITypeDescriptorContext,System.IServiceProvider,System.Object)"></see> method.</summary>
    /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> enumeration value indicating the provided editing style. If the method is not supported in the specified context, this method will return the <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see> identifier.</returns>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext) => UITypeEditorEditStyle.Modal;

    /// <summary>Gets an array of objects containing the specified collection.</summary>
    /// <returns>An array containing the collection objects, or an empty object array if the specified collection does not inherit from <see cref="T:System.Collections.ICollection"></see>.</returns>
    /// <param name="objEditValue">The collection to edit. </param>
    protected virtual object[] GetItems(object objEditValue)
    {
      if (objEditValue == null || !(objEditValue is ICollection))
        return new object[0];
      ArrayList arrayList = new ArrayList();
      foreach (object obj in (IEnumerable) objEditValue)
        arrayList.Add(obj);
      object[] items = new object[arrayList.Count];
      arrayList.CopyTo((Array) items, 0);
      return items;
    }

    /// <summary>Returns a list containing the given object</summary>
    /// <returns>An <see cref="T:System.Collections.ArrayList"></see> which contains the individual objects to be created.</returns>
    /// <param name="objInstance">An <see cref="T:System.Collections.ArrayList"></see> returned as an object.</param>
    protected virtual IList GetObjectsFromInstance(object objInstance) => (IList) new ArrayList()
    {
      objInstance
    };

    /// <summary>Gets the requested service, if it is available.</summary>
    /// <returns>An instance of the service, or null if the service cannot be found.</returns>
    /// <param name="objServiceType">The type of service to retrieve. </param>
    protected object GetService(Type objServiceType) => this.Context != null ? this.Context.GetService(objServiceType) : (object) null;

    private bool IsAnyObjectInheritedReadOnly(object[] arrItems) => false;

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
        int length1 = this.GetItems(objEditValue).Length;
        int length2 = arrValues.Length;
        if (!(objEditValue is IList))
          return objEditValue;
        IList list = (IList) objEditValue;
        list.Clear();
        for (int index = 0; index < arrValues.Length; ++index)
          list.Add(arrValues[index]);
      }
      return objEditValue;
    }

    /// <summary>Displays the default Help topic for the collection editor.</summary>
    protected virtual void ShowHelp()
    {
    }

    /// <summary>Gets the data type of each item in the collection.</summary>
    /// <returns>The data type of the collection items.</returns>
    protected Type CollectionItemType
    {
      get
      {
        if (this.mobjCollectionItemType == (Type) null)
          this.mobjCollectionItemType = this.CreateCollectionItemType();
        return this.mobjCollectionItemType;
      }
    }

    /// <summary>Gets the data type of the collection object.</summary>
    /// <returns>The data type of the collection object.</returns>
    protected Type CollectionType => this.mobjType;

    /// <summary>Gets a type descriptor that indicates the current context.</summary>
    /// <returns>An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that indicates the context currently in use, or null if no context is available.</returns>
    protected ITypeDescriptorContext Context => this.mobjCurrentContext;

    /// <summary>Gets the available types of items that can be created for this collection.</summary>
    /// <returns>The types of items that can be created.</returns>
    protected Type[] NewItemTypes
    {
      get
      {
        if (this.marrNewItemTypes == null)
          this.marrNewItemTypes = this.CreateNewItemTypes();
        return this.marrNewItemTypes;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this editor value should support text editing.
    /// </summary>
    /// <value></value>
    /// <returns>true if editor value should support text editing; otherwise, false. </returns>
    public override bool IsTextEditable => false;

    [Serializable]
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
        if (!this.mblnInGetService)
        {
          if (this.mobjServiceProvider != null)
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
        }
        return (object) null;
      }

      public IComponent Component => this.mobjComponent;

      public IContainer Container => (IContainer) null;

      public bool DesignMode => false;

      public string Name
      {
        get => (string) null;
        set
        {
        }
      }
    }

    [Serializable]
    protected internal class CollectionEditorCollectionForm : CollectionEditor.CollectionForm
    {
      private Panel mobjPanelButtons;
      private Panel mobjPanelItems;
      private Panel mobjPanelProperties;
      private Label mobjLabelMembers;
      private Label mobjLabelProperties;
      private Panel mobjPanelUpDown;
      private Panel mobjPanelAddRemove;
      private Button mobjButtonCancel;
      private Button mobjButtonOk;
      private ListBox mobjListItems;
      private PropertyGrid mobjPropertyGrid;
      private Button mobjButtonUp;
      private Button mobjButtonDown;
      private Button mobjButtonAdd;
      private Button mobjButtonRemove;
      private ArrayList mobjOriginalItems;
      private ArrayList mobjCreatedItems;
      private ArrayList mobjRemovedItems;
      private bool mblnDirty;
      private int mintSuspendEnabledCount;
      private CollectionEditor mobjCollectionEditor;

      public CollectionEditorCollectionForm(CollectionEditor objCollectionEditor)
        : base(objCollectionEditor)
      {
        this.mobjCollectionEditor = objCollectionEditor;
        this.InitializeComponent();
        this.InitializeComponentExtra();
        this.Text = Gizmox.WebGUI.Forms.SR.GetString("CollectionEditorCaption", (object) this.CollectionItemType.Name);
      }

      /// <summary>Adds VWG specifiec initialization</summary>
      private void InitializeComponentExtra()
      {
        this.mobjButtonDown.Image = (ResourceHandle) new SkinResourceHandle((Skin) this.Skin, "ButtonDownArrow.gif");
        this.mobjButtonUp.Image = (ResourceHandle) new SkinResourceHandle((Skin) this.Skin, "ButtonUpArrow.gif");
        Type[] newItemTypes = this.NewItemTypes;
        if (newItemTypes.Length > 1)
        {
          ContextMenu contextMenu = new ContextMenu();
          this.mobjButtonAdd.DropDownMenu = (Menu) contextMenu;
          for (int index = 0; index < newItemTypes.Length; ++index)
          {
            Type objType = newItemTypes[index];
            MenuItem objMenuItem = new MenuItem(this.GetTypeDisplayName(objType));
            objMenuItem.Tag = (object) objType;
            contextMenu.MenuItems.Add(objMenuItem);
          }
          this.mobjButtonAdd.MenuClick += new MenuEventHandler(this.objAddDropDownMenu_MenuClick);
        }
        else
          this.mobjButtonAdd.Click += new EventHandler(this.mobjButtonAdd_Click);
        this.mobjPropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(this.mobjPropertyGrid_PropertyValueChanged);
      }

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
        this.mobjPanelButtons = new Panel();
        this.mobjPanelItems = new Panel();
        this.mobjPanelProperties = new Panel();
        this.mobjLabelMembers = new Label();
        this.mobjLabelProperties = new Label();
        this.mobjPanelUpDown = new Panel();
        this.mobjPanelAddRemove = new Panel();
        this.mobjButtonCancel = new Button();
        this.mobjButtonOk = new Button();
        this.mobjListItems = new ListBox();
        this.mobjPropertyGrid = this.GetPropertyGridInstance();
        this.mobjButtonUp = new Button();
        this.mobjButtonDown = new Button();
        this.mobjButtonAdd = new Button();
        this.mobjButtonRemove = new Button();
        this.mobjPanelButtons.SuspendLayout();
        this.mobjPanelItems.SuspendLayout();
        this.mobjPanelProperties.SuspendLayout();
        this.mobjPanelUpDown.SuspendLayout();
        this.mobjPanelAddRemove.SuspendLayout();
        this.SuspendLayout();
        this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonOk);
        this.mobjPanelButtons.Controls.Add((Control) this.mobjButtonCancel);
        this.mobjPanelButtons.Dock = DockStyle.Bottom;
        this.mobjPanelButtons.Location = new Point(5, 377);
        this.mobjPanelButtons.Name = "mobjPanelButtons";
        this.mobjPanelButtons.Size = new Size(470, 40);
        this.mobjPanelButtons.TabIndex = 0;
        this.mobjPanelItems.Controls.Add((Control) this.mobjListItems);
        this.mobjPanelItems.Controls.Add((Control) this.mobjPanelAddRemove);
        this.mobjPanelItems.Controls.Add((Control) this.mobjPanelUpDown);
        this.mobjPanelItems.Controls.Add((Control) this.mobjLabelMembers);
        this.mobjPanelItems.Dock = DockStyle.Left;
        this.mobjPanelItems.Location = new Point(5, 5);
        this.mobjPanelItems.Name = "mobjPanelItems";
        this.mobjPanelItems.Size = new Size(243, 372);
        this.mobjPanelItems.TabIndex = 1;
        this.mobjPanelProperties.Controls.Add((Control) this.mobjPropertyGrid);
        this.mobjPanelProperties.Controls.Add((Control) this.mobjLabelProperties);
        this.mobjPanelProperties.Dock = DockStyle.Fill;
        this.mobjPanelProperties.Location = new Point(248, 5);
        this.mobjPanelProperties.Name = "mobjPanelProperties";
        this.mobjPanelProperties.Size = new Size(227, 372);
        this.mobjPanelProperties.TabIndex = 2;
        this.mobjLabelMembers.Dock = DockStyle.Top;
        this.mobjLabelMembers.Location = new Point(0, 0);
        this.mobjLabelMembers.Name = "mobjLabelMembers";
        this.mobjLabelMembers.Size = new Size(243, 23);
        this.mobjLabelMembers.TabIndex = 0;
        this.mobjLabelMembers.Text = "Members:";
        this.mobjLabelMembers.TextAlign = ContentAlignment.BottomLeft;
        this.mobjLabelProperties.Dock = DockStyle.Top;
        this.mobjLabelProperties.Location = new Point(0, 0);
        this.mobjLabelProperties.Name = "mobjLabelProperties";
        this.mobjLabelProperties.Size = new Size(227, 23);
        this.mobjLabelProperties.TabIndex = 0;
        this.mobjLabelProperties.Text = "{0} properties:";
        this.mobjLabelProperties.TextAlign = ContentAlignment.BottomLeft;
        this.mobjPanelUpDown.Controls.Add((Control) this.mobjButtonDown);
        this.mobjPanelUpDown.Controls.Add((Control) this.mobjButtonUp);
        this.mobjPanelUpDown.Dock = DockStyle.Right;
        this.mobjPanelUpDown.Location = new Point(195, 23);
        this.mobjPanelUpDown.Name = "mobjPanelUpDown";
        this.mobjPanelUpDown.Size = new Size(48, 349);
        this.mobjPanelUpDown.TabIndex = 1;
        this.mobjPanelAddRemove.Controls.Add((Control) this.mobjButtonRemove);
        this.mobjPanelAddRemove.Controls.Add((Control) this.mobjButtonAdd);
        this.mobjPanelAddRemove.Dock = DockStyle.Bottom;
        this.mobjPanelAddRemove.Location = new Point(0, 332);
        this.mobjPanelAddRemove.Name = "mobjPanelAddRemove";
        this.mobjPanelAddRemove.Size = new Size(195, 40);
        this.mobjPanelAddRemove.TabIndex = 2;
        this.mobjButtonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        this.mobjButtonCancel.DialogResult = DialogResult.Cancel;
        this.mobjButtonCancel.Location = new Point(392, 8);
        this.mobjButtonCancel.Name = "mobjButtonCancel";
        this.mobjButtonCancel.TabIndex = 0;
        this.mobjButtonCancel.Text = "Cancel";
        this.mobjButtonCancel.Click += new EventHandler(this.mobjButtonCancel_Click);
        this.mobjButtonOk.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        this.mobjButtonOk.Location = new Point(304, 8);
        this.mobjButtonOk.Name = "mobjButtonOk";
        this.mobjButtonOk.TabIndex = 1;
        this.mobjButtonOk.Text = "OK";
        this.mobjButtonOk.Click += new EventHandler(this.mobjButtonOk_Click);
        this.mobjListItems.Dock = DockStyle.Fill;
        this.mobjListItems.Location = new Point(0, 23);
        this.mobjListItems.Name = "mobjListItems";
        this.mobjListItems.Size = new Size(195, 303);
        this.mobjListItems.TabIndex = 3;
        this.mobjListItems.SelectedIndexChanged += new EventHandler(this.mobjListItems_SelectedIndexChanged);
        this.mobjListItems.SelectionMode = SelectionMode.MultiExtended;
        this.mobjPropertyGrid.Dock = DockStyle.Fill;
        this.mobjPropertyGrid.HelpVisible = false;
        this.mobjPropertyGrid.LargeButtons = false;
        this.mobjPropertyGrid.LineColor = SystemColors.ScrollBar;
        this.mobjPropertyGrid.Location = new Point(0, 23);
        this.mobjPropertyGrid.Name = "mobjPropertyGrid";
        this.mobjPropertyGrid.Size = new Size(227, 349);
        this.mobjPropertyGrid.TabIndex = 1;
        this.mobjPropertyGrid.Text = "propertyGrid1";
        this.mobjPropertyGrid.ViewBackColor = SystemColors.Window;
        this.mobjPropertyGrid.ViewForeColor = SystemColors.WindowText;
        this.mobjButtonUp.Location = new Point(8, 0);
        this.mobjButtonUp.Name = "mobjButtonUp";
        this.mobjButtonUp.Size = new Size(24, 23);
        this.mobjButtonUp.TabIndex = 0;
        this.mobjButtonUp.Click += new EventHandler(this.mobjButtonUp_Click);
        this.mobjButtonDown.Location = new Point(8, 32);
        this.mobjButtonDown.Name = "mobjButtonDown";
        this.mobjButtonDown.Size = new Size(24, 23);
        this.mobjButtonDown.TabIndex = 1;
        this.mobjButtonDown.Click += new EventHandler(this.mobjButtonDown_Click);
        this.mobjButtonAdd.Location = new Point(0, 8);
        this.mobjButtonAdd.Name = "mobjButtonAdd";
        this.mobjButtonAdd.Size = new Size(88, 23);
        this.mobjButtonAdd.TabIndex = 0;
        this.mobjButtonAdd.Text = "Add";
        this.mobjButtonRemove.Location = new Point(96, 8);
        this.mobjButtonRemove.Name = "mobjButtonRemove";
        this.mobjButtonRemove.Size = new Size(88, 23);
        this.mobjButtonRemove.TabIndex = 1;
        this.mobjButtonRemove.Text = "Remove";
        this.mobjButtonRemove.Click += new EventHandler(this.mobjButtonRemove_Click);
        this.ClientSize = new Size(480, 422);
        this.Controls.Add((Control) this.mobjPanelProperties);
        this.Controls.Add((Control) this.mobjPanelItems);
        this.Controls.Add((Control) this.mobjPanelButtons);
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

      /// <summary>Gets the property grid instance.</summary>
      /// <returns></returns>
      protected internal virtual PropertyGrid GetPropertyGridInstance() => new PropertyGrid();

      private void mobjPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {
        this.mblnDirty = true;
        this.SuspendEnabledUpdates();
        try
        {
          CollectionEditor.CollectionEditorCollectionForm.ListItem selectedItem = (CollectionEditor.CollectionEditorCollectionForm.ListItem) this.mobjListItems.SelectedItem;
          if (selectedItem == null || !selectedItem.UpdateDisplayText())
            return;
          this.mobjListItems.Update();
          this.mobjLabelProperties.Text = Gizmox.WebGUI.Forms.SR.GetString("CollectionEditorProperties", (object) this.GetDisplayText(selectedItem));
        }
        finally
        {
          this.ResumeEnabledUpdates(false);
        }
      }

      private void objAddDropDownMenu_MenuClick(object objSource, MenuItemEventArgs objArgs)
      {
        Type tag = objArgs.MenuItem.Tag as Type;
        if (!(tag != (Type) null))
          return;
        this.CreateAndAddInstance(tag);
      }

      private void mobjButtonCancel_Click(object sender, EventArgs e)
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
              object[] array = this.mobjCreatedItems.ToArray();
              if (array.Length != 0 && array[0] is IComponent && ((IComponent) array[0]).Site != null)
                return;
              for (int index = 0; index < array.Length; ++index)
                this.DestroyInstance(array[index]);
              this.mobjCreatedItems.Clear();
            }
            if (this.mobjRemovedItems != null)
              this.mobjRemovedItems.Clear();
            if (this.mobjOriginalItems != null && this.mobjOriginalItems.Count > 0)
            {
              object[] objArray = new object[this.mobjOriginalItems.Count];
              for (int index = 0; index < this.mobjOriginalItems.Count; ++index)
                objArray[index] = this.mobjOriginalItems[index];
              this.Items = objArray;
              this.mobjOriginalItems.Clear();
            }
            else
              this.Items = new object[0];
          }
          this.Close();
        }
        catch (Exception ex)
        {
          this.DialogResult = DialogResult.None;
          this.DisplayError(ex);
        }
      }

      private void mobjButtonOk_Click(object sender, EventArgs e)
      {
        try
        {
          if (!this.mblnDirty || !this.CollectionEditable)
          {
            this.mblnDirty = false;
            this.DialogResult = DialogResult.Cancel;
          }
          else
          {
            if (this.mblnDirty)
            {
              object[] objArray = new object[this.mobjListItems.Items.Count];
              for (int intIndex = 0; intIndex < objArray.Length; ++intIndex)
                objArray[intIndex] = ((CollectionEditor.CollectionEditorCollectionForm.ListItem) this.mobjListItems.Items[intIndex]).Value;
              this.Items = objArray;
            }
            if (this.mobjRemovedItems != null && this.mblnDirty)
            {
              foreach (object objInstance in this.mobjRemovedItems.ToArray())
                this.DestroyInstance(objInstance);
              this.mobjRemovedItems.Clear();
            }
            if (this.mobjCreatedItems != null)
              this.mobjCreatedItems.Clear();
            if (this.mobjOriginalItems != null)
              this.mobjOriginalItems.Clear();
            this.mobjListItems.Items.Clear();
            this.mblnDirty = false;
          }
          this.Close();
        }
        catch (Exception ex)
        {
          this.DialogResult = DialogResult.None;
          this.DisplayError(ex);
        }
      }

      private void mobjButtonRemove_Click(object sender, EventArgs e) => this.PerformRemove();

      private void PerformRemove()
      {
        int selectedIndex = this.mobjListItems.SelectedIndex;
        if (selectedIndex == -1)
          return;
        this.SuspendEnabledUpdates();
        try
        {
          if (this.mobjListItems.SelectedItems.Count > 1)
          {
            foreach (CollectionEditor.CollectionEditorCollectionForm.ListItem objItem in new ArrayList((ICollection) this.mobjListItems.SelectedItems))
              this.RemoveInternal(objItem);
          }
          else
            this.RemoveInternal((CollectionEditor.CollectionEditorCollectionForm.ListItem) this.mobjListItems.SelectedItem);
          if (selectedIndex < this.mobjListItems.Items.Count)
          {
            this.mobjListItems.SelectedIndex = selectedIndex;
          }
          else
          {
            if (this.mobjListItems.Items.Count <= 0)
              return;
            this.mobjListItems.SelectedIndex = this.mobjListItems.Items.Count - 1;
          }
        }
        finally
        {
          this.ResumeEnabledUpdates();
        }
      }

      private void RemoveInternal(
        CollectionEditor.CollectionEditorCollectionForm.ListItem objItem)
      {
        if (objItem == null)
          return;
        this.mobjCollectionEditor.OnItemRemoving(objItem.Value);
        this.mblnDirty = true;
        if (this.mobjCreatedItems != null && this.mobjCreatedItems.Contains(objItem.Value))
        {
          this.DestroyInstance(objItem.Value);
          this.mobjCreatedItems.Remove(objItem.Value);
          this.mobjListItems.Items.Remove((object) objItem);
        }
        else
        {
          try
          {
            if (!this.CanRemoveInstance(objItem.Value))
              throw new Exception(Gizmox.WebGUI.Forms.SR.GetString("CollectionEditorCantRemoveItem", (object) this.GetDisplayText(objItem)));
            if (this.mobjRemovedItems == null)
              this.mobjRemovedItems = new ArrayList();
            this.mobjRemovedItems.Add(objItem.Value);
            this.mobjListItems.Items.Remove((object) objItem);
          }
          catch (Exception ex)
          {
            this.DisplayError(ex);
          }
        }
      }

      private void mobjButtonAdd_Click(object sender, EventArgs e) => this.PerformAdd();

      private void PerformAdd() => this.CreateAndAddInstance(this.NewItemTypes[0]);

      private void CreateAndAddInstance(Type objType)
      {
        try
        {
          IList objectsFromInstance = this.mobjCollectionEditor.GetObjectsFromInstance(this.CreateInstance(objType));
          if (objectsFromInstance == null)
            return;
          this.AddItems(objectsFromInstance);
        }
        catch (Exception ex)
        {
          this.DisplayError(ex);
        }
      }

      private void AddItems(IList objInstances)
      {
        if (this.mobjCreatedItems == null)
          this.mobjCreatedItems = new ArrayList();
        try
        {
          foreach (object objInstance in (IEnumerable) objInstances)
          {
            if (objInstance != null)
            {
              this.mblnDirty = true;
              this.mobjCreatedItems.Add(objInstance);
              CollectionEditor.CollectionEditorCollectionForm.ListItem objObject = new CollectionEditor.CollectionEditorCollectionForm.ListItem(this.mobjCollectionEditor, objInstance);
              objObject.UpdateDisplayText();
              this.mobjListItems.Items.Add((object) objObject);
            }
          }
        }
        finally
        {
        }
        this.SuspendEnabledUpdates();
        try
        {
          this.mobjListItems.ClearSelected();
          this.mobjListItems.SelectedIndex = this.mobjListItems.Items.Count - 1;
          object[] objArray = new object[this.mobjListItems.Items.Count];
          for (int intIndex = 0; intIndex < objArray.Length; ++intIndex)
            objArray[intIndex] = ((CollectionEditor.CollectionEditorCollectionForm.ListItem) this.mobjListItems.Items[intIndex]).Value;
          this.Items = objArray;
          if (this.mobjListItems.Items.Count <= 0 || this.mobjListItems.SelectedIndex == this.mobjListItems.Items.Count - 1)
            return;
          this.mobjListItems.ClearSelected();
          this.mobjListItems.SelectedIndex = this.mobjListItems.Items.Count - 1;
        }
        finally
        {
          this.ResumeEnabledUpdates();
        }
      }

      private void mobjListItems_SelectedIndexChanged(object sender, EventArgs e) => this.UpdateEnabled();

      private void mobjButtonUp_Click(object sender, EventArgs e)
      {
        int selectedIndex = this.mobjListItems.SelectedIndex;
        if (selectedIndex == 0)
          return;
        this.mblnDirty = true;
        try
        {
          this.SuspendEnabledUpdates();
          object obj = this.mobjListItems.Items[selectedIndex];
          this.mobjListItems.Items[selectedIndex] = this.mobjListItems.Items[selectedIndex - 1];
          this.mobjListItems.Items[selectedIndex - 1] = obj;
          this.mobjListItems.ClearSelected();
          this.mobjListItems.SelectedIndex = selectedIndex - 1;
          Control control = (Control) sender;
          if (!control.Enabled)
            return;
          control.Focus();
        }
        finally
        {
          this.ResumeEnabledUpdates(false);
        }
      }

      private void mobjButtonDown_Click(object sender, EventArgs e)
      {
        try
        {
          this.SuspendEnabledUpdates();
          this.mblnDirty = true;
          int selectedIndex = this.mobjListItems.SelectedIndex;
          if (selectedIndex == this.mobjListItems.Items.Count - 1)
            return;
          object obj = this.mobjListItems.Items[selectedIndex];
          this.mobjListItems.Items[selectedIndex] = this.mobjListItems.Items[selectedIndex + 1];
          this.mobjListItems.Items[selectedIndex + 1] = obj;
          this.mobjListItems.ClearSelected();
          this.mobjListItems.SelectedIndex = selectedIndex + 1;
          Control control = (Control) sender;
          if (!control.Enabled)
            return;
          control.Focus();
        }
        finally
        {
          this.ResumeEnabledUpdates(false);
        }
      }

      private void SuspendEnabledUpdates() => ++this.mintSuspendEnabledCount;

      private void ResumeEnabledUpdates() => this.ResumeEnabledUpdates(true);

      private void ResumeEnabledUpdates(bool blnUpdateGrid)
      {
        --this.mintSuspendEnabledCount;
        this.UpdateEnabled(blnUpdateGrid);
      }

      protected override void OnEditValueChanged()
      {
        if (this.mobjOriginalItems == null)
          this.mobjOriginalItems = new ArrayList();
        this.mobjOriginalItems.Clear();
        this.mobjListItems.Items.Clear();
        this.mobjPropertyGrid.Site = (ISite) new CollectionEditor.PropertyGridSite((IServiceProvider) this.Context, (IComponent) this.mobjPropertyGrid);
        if (this.EditValue != null)
        {
          this.SuspendEnabledUpdates();
          try
          {
            object[] items = this.Items;
            for (int index = 0; index < items.Length; ++index)
            {
              CollectionEditor.CollectionEditorCollectionForm.ListItem objObject = new CollectionEditor.CollectionEditorCollectionForm.ListItem(this.mobjCollectionEditor, items[index]);
              objObject.UpdateDisplayText();
              this.mobjListItems.Items.Add((object) objObject);
              this.mobjOriginalItems.Add(items[index]);
            }
            if (this.mobjListItems.Items.Count <= 0)
              return;
            this.mobjListItems.SelectedIndex = 0;
          }
          finally
          {
            this.ResumeEnabledUpdates();
          }
        }
        else
          this.UpdateEnabled();
      }

      private void UpdateEnabled() => this.UpdateEnabled(true);

      private void UpdateEnabled(bool blnUpdateGrid)
      {
        if (this.mintSuspendEnabledCount > 0)
          return;
        bool flag = this.mobjListItems.SelectedItem != null && this.CollectionEditable;
        this.mobjButtonRemove.Enabled = flag && this.AllowRemoveInstance(((CollectionEditor.CollectionEditorCollectionForm.ListItem) this.mobjListItems.SelectedItem).Value);
        this.mobjButtonUp.Enabled = flag && this.mobjListItems.Items.Count > 1;
        this.mobjButtonDown.Enabled = flag && this.mobjListItems.Items.Count > 1;
        this.mobjPropertyGrid.Enabled = flag;
        this.mobjButtonAdd.Enabled = this.CollectionEditable;
        if (this.mobjListItems.SelectedItem == null)
        {
          this.mobjLabelProperties.Text = Gizmox.WebGUI.Forms.SR.GetString("CollectionEditorPropertiesNone");
          this.mobjPropertyGrid.SelectedObject = (object) null;
        }
        else
        {
          object[] arrItems;
          if (this.IsImmutable)
          {
            arrItems = new object[1]
            {
              (object) new CollectionEditor.CollectionEditorCollectionForm.SelectionWrapper(this.CollectionType, this.CollectionItemType, (Control) this.mobjListItems, (ICollection) this.mobjListItems.SelectedItems)
            };
          }
          else
          {
            arrItems = new object[this.mobjListItems.SelectedItems.Count];
            for (int index = 0; index < arrItems.Length; ++index)
            {
              object objValue = ((CollectionEditor.CollectionEditorCollectionForm.ListItem) this.mobjListItems.SelectedItems[index]).Value;
              arrItems[index] = this.GetPropertyGridSelectedObjectFromValue(objValue);
            }
          }
          switch (this.mobjListItems.SelectedItems.Count)
          {
            case -1:
            case 1:
              this.mobjLabelProperties.Text = Gizmox.WebGUI.Forms.SR.GetString("CollectionEditorProperties", (object) this.GetDisplayText((CollectionEditor.CollectionEditorCollectionForm.ListItem) this.mobjListItems.SelectedItem));
              break;
            default:
              this.mobjLabelProperties.Text = Gizmox.WebGUI.Forms.SR.GetString("CollectionEditorPropertiesMultiSelect");
              break;
          }
          if (this.mobjCollectionEditor.IsAnyObjectInheritedReadOnly(arrItems))
          {
            this.mobjPropertyGrid.SelectedObjects = (object[]) null;
            this.mobjPropertyGrid.Enabled = false;
            this.mobjButtonRemove.Enabled = false;
            this.mobjButtonUp.Enabled = false;
            this.mobjButtonDown.Enabled = false;
            this.mobjLabelProperties.Text = Gizmox.WebGUI.Forms.SR.GetString("CollectionEditorInheritedReadOnlySelection");
          }
          else
          {
            this.mobjPropertyGrid.Enabled = true;
            if (!blnUpdateGrid)
              return;
            this.mobjPropertyGrid.SelectedObjects = arrItems;
          }
        }
      }

      /// <summary>Gets the property grid selected object from value.</summary>
      /// <param name="objValue">The object value.</param>
      /// <returns></returns>
      protected internal virtual object GetPropertyGridSelectedObjectFromValue(object objValue) => objValue;

      private bool AllowRemoveInstance(object objValue) => this.mobjCreatedItems != null && this.mobjCreatedItems.Contains(objValue) || this.CanRemoveInstance(objValue);

      private string GetDisplayText(
        CollectionEditor.CollectionEditorCollectionForm.ListItem objItem)
      {
        return objItem != null ? objItem.ToString() : string.Empty;
      }

      private bool IsImmutable
      {
        get
        {
          bool isImmutable = true;
          if (!TypeDescriptor.GetConverter(this.CollectionItemType).GetCreateInstanceSupported())
          {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this.CollectionItemType))
            {
              if (!property.IsReadOnly)
                return false;
            }
          }
          return isImmutable;
        }
      }

      /// <summary>Gets the property grid.</summary>
      /// <value>The property grid.</value>
      internal PropertyGrid PropertyGrid => this.mobjPropertyGrid;

      [Serializable]
      private class SelectionWrapper : PropertyDescriptor, ICustomTypeDescriptor
      {
        private ICollection mobjCollection;
        private Type mobjCollectionItemType;
        private Type mobjCollectionType;
        private Control mobjControl;
        private PropertyDescriptorCollection mobjProperties;
        private object mobjValue;

        public SelectionWrapper(
          Type objCollectionType,
          Type objCollectionItemType,
          Control objControl,
          ICollection objCollection)
          : base("Value", new Attribute[1]
          {
            (Attribute) new CategoryAttribute(objCollectionItemType.Name)
          })
        {
          this.mobjCollectionType = objCollectionType;
          this.mobjCollectionItemType = objCollectionItemType;
          this.mobjControl = objControl;
          this.mobjCollection = objCollection;
          this.mobjProperties = new PropertyDescriptorCollection(new PropertyDescriptor[1]
          {
            (PropertyDescriptor) this
          });
          this.mobjValue = (object) this;
          foreach (CollectionEditor.CollectionEditorCollectionForm.ListItem listItem in (IEnumerable) objCollection)
          {
            if (this.mobjValue == this)
            {
              this.mobjValue = listItem.Value;
            }
            else
            {
              object obj = listItem.Value;
              if (this.mobjValue != null)
              {
                if (obj == null)
                {
                  this.mobjValue = (object) null;
                  break;
                }
                if (!this.mobjValue.Equals(obj))
                {
                  this.mobjValue = (object) null;
                  break;
                }
              }
              else if (obj != null)
              {
                this.mobjValue = (object) null;
                break;
              }
            }
          }
        }

        public override bool CanResetValue(object objComponent) => false;

        public override object GetValue(object objComponent) => this.mobjValue;

        public override void ResetValue(object objComponent)
        {
        }

        public override void SetValue(object objComponent, object objValue)
        {
          this.mobjValue = objValue;
          foreach (CollectionEditor.CollectionEditorCollectionForm.ListItem mobj in (IEnumerable) this.mobjCollection)
            mobj.Value = objValue;
          this.mobjControl.Invalidate();
          this.OnValueChanged(objComponent, EventArgs.Empty);
        }

        public override bool ShouldSerializeValue(object objComponent) => false;

        AttributeCollection ICustomTypeDescriptor.GetAttributes() => TypeDescriptor.GetAttributes(this.mobjCollectionItemType);

        string ICustomTypeDescriptor.GetClassName() => this.mobjCollectionItemType.Name;

        string ICustomTypeDescriptor.GetComponentName() => (string) null;

        TypeConverter ICustomTypeDescriptor.GetConverter() => (TypeConverter) null;

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() => (EventDescriptor) null;

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() => (PropertyDescriptor) this;

        object ICustomTypeDescriptor.GetEditor(Type objEditorBaseType) => (object) null;

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => EventDescriptorCollection.Empty;

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] arrAttributes) => EventDescriptorCollection.Empty;

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() => this.mobjProperties;

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] arrAttributes) => this.mobjProperties;

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor objPropertyDescriptor) => (object) this;

        public override Type ComponentType => this.mobjCollectionType;

        public override bool IsReadOnly => false;

        public override Type PropertyType => this.mobjCollectionItemType;
      }

      [Serializable]
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

        public override string ToString() => this.mstrDisplayText;

        public bool UpdateDisplayText()
        {
          string displayText = this.mobjParentCollectionEditor.GetDisplayText(this.mobjValue);
          if (!(displayText != this.mstrDisplayText))
            return false;
          this.mstrDisplayText = displayText;
          return true;
        }

        public string DisplayText => this.mstrDisplayText;

        public UITypeEditor Editor
        {
          get
          {
            if (this.mobjUITypeEditor == null)
            {
              this.mobjUITypeEditor = TypeDescriptor.GetEditor(this.mobjValue, typeof (UITypeEditor));
              if (this.mobjUITypeEditor == null)
                this.mobjUITypeEditor = (object) this;
            }
            return this.mobjUITypeEditor != this ? (UITypeEditor) this.mobjUITypeEditor : (UITypeEditor) null;
          }
        }

        public object Value
        {
          get => this.mobjValue;
          set
          {
            this.mobjUITypeEditor = (object) null;
            this.mobjValue = value;
          }
        }
      }
    }

    /// <summary>Provides a modal dialog box for editing the contents of a collection using a <see cref="T:System.Drawing.Design.UITypeEditor"></see>.</summary>
    [Serializable]
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
      public CollectionForm(CollectionEditor objEditor) => this.mobjEditor = objEditor;

      /// <summary>Indicates whether you can remove the original members of the collection.</summary>
      /// <returns>true if it is permissible to remove this value from the collection; otherwise, false. By default, this method returns the value from <see cref="M:System.ComponentModel.Design.CollectionEditor.CanRemoveInstance(System.Object)"></see> of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> for this form.</returns>
      /// <param name="value">The value to remove. </param>
      protected bool CanRemoveInstance(object objValue) => this.mobjEditor.CanRemoveInstance(objValue);

      /// <summary>Indicates whether multiple collection items can be selected at once.</summary>
      /// <returns>true if it multiple collection members can be selected at the same time; otherwise, false. By default, this method returns the value from <see cref="M:System.ComponentModel.Design.CollectionEditor.CanSelectMultipleInstances"></see> of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> for this form.</returns>
      protected virtual bool CanSelectMultipleInstances() => this.mobjEditor.CanSelectMultipleInstances();

      /// <summary>Creates a new instance of the specified collection item type.</summary>
      /// <returns>A new instance of the specified object, or null if the user chose to cancel the creation of this instance.</returns>
      /// <param name="objItemType">The type of item to create. </param>
      protected object CreateInstance(Type objItemType) => this.mobjEditor.CreateInstance(objItemType);

      /// <summary>Destroys the specified instance of the object.</summary>
      /// <param name="objInstance">The object to destroy. </param>
      protected void DestroyInstance(object objInstance) => this.mobjEditor.DestroyInstance(objInstance);

      /// <summary>Displays the specified exception to the user.</summary>
      /// <param name="objException">The exception to display. </param>
      protected virtual void DisplayError(Exception objException)
      {
      }

      /// <summary>Gets the requested service, if it is available.</summary>
      /// <returns>An instance of the service, or null if the service cannot be found.</returns>
      /// <param name="objServiceType">The type of service to retrieve. </param>
      protected override object GetService(Type objServiceType) => this.mobjEditor.GetService(objServiceType);

      /// <summary>Provides an opportunity to perform processing when a collection value has changed.</summary>
      protected abstract void OnEditValueChanged();

      /// <summary>Shows the dialog box for the collection editor using the specified <see cref="T:Gizmox.WebGUI.Forms.Design.IWindowsFormsEditorService"></see> object.</summary>
      /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> that indicates the result code returned from the dialog box.</returns>
      /// <param name="objEditorService">An <see cref="T:Gizmox.WebGUI.Forms.Design.IWebUIEditorService"></see> that can be used to show the dialog box. </param>
      protected internal virtual void ShowEditorDialog(IWebUIEditorService objEditorService) => objEditorService.ShowDialog((Form) this);

      internal virtual bool CollectionEditable
      {
        get
        {
          if (this.mshortEditableState != (short) 0)
            return this.mshortEditableState == (short) 1;
          bool flag = typeof (IList).IsAssignableFrom(this.mobjEditor.CollectionType);
          return flag && this.EditValue is IList editValue ? !editValue.IsReadOnly : flag;
        }
        set
        {
          if (value)
            this.mshortEditableState = (short) 1;
          else
            this.mshortEditableState = (short) 2;
        }
      }

      /// <summary>Gets the data type of each item in the collection.</summary>
      /// <returns>The data type of the collection items.</returns>
      protected Type CollectionItemType => this.mobjEditor.CollectionItemType;

      /// <summary>Gets the data type of the collection object.</summary>
      /// <returns>The data type of the collection object.</returns>
      protected Type CollectionType => this.mobjEditor.CollectionType;

      /// <summary>Gets a type descriptor that indicates the current context.</summary>
      /// <returns>An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that indicates the context currently in use, or null if no context is available.</returns>
      protected ITypeDescriptorContext Context => this.mobjEditor.Context;

      /// <summary>Gets or sets the collection object to edit.</summary>
      /// <returns>The collection object to edit.</returns>
      public object EditValue
      {
        get => this.mobjValue;
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
        get => this.mobjEditor.GetItems(this.EditValue);
        set
        {
          bool flag = false;
          try
          {
            flag = this.Context.OnComponentChanging();
          }
          catch (Exception ex)
          {
            if (Gizmox.WebGUI.Forms.ClientUtils.IsCriticalException(ex))
              throw;
            else
              this.DisplayError(ex);
          }
          if (!flag)
            return;
          object obj = this.mobjEditor.SetItems(this.EditValue, value);
          if (obj != this.EditValue)
            this.EditValue = obj;
          this.Context.OnComponentChanged();
        }
      }

      /// <summary>Gets the available item types that can be created for this collection.</summary>
      /// <returns>The types of items that can be created.</returns>
      protected Type[] NewItemTypes => this.mobjEditor.NewItemTypes;

      /// <summary>Gets the display name of the type.</summary>
      /// <param name="objType">Type of the object.</param>
      /// <returns></returns>
      protected string GetTypeDisplayName(Type objType)
      {
        object[] customAttributes = objType.GetCustomAttributes(typeof (WebCollectionEditorItemTypeNameAttribute), true);
        return customAttributes.Length == 1 ? (customAttributes[0] as WebCollectionEditorItemTypeNameAttribute).DisplayName : objType.Name;
      }
    }
  }
}
