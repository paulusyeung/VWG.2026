// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingNavigator
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents the navigation and manipulation user interface (UI) for controls on a form that are bound to data.
  /// </summary>
  [ToolboxBitmap(typeof (ToolBar), "BindingNavigator_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [ToolboxItemCategory("Data")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (BindingNavigatorSkin))]
  [Serializable]
  public class BindingNavigator : ToolBar, ISupportInitialize
  {
    /// <summary>
    /// Provides a property reference to Initializing property.
    /// </summary>
    private static SerializableProperty InitializingProperty = SerializableProperty.Register(nameof (Initializing), typeof (bool), typeof (BindingNavigator));
    /// <summary>
    /// Provides a property reference to PositionItem property.
    /// </summary>
    private static SerializableProperty PositionItemProperty = SerializableProperty.Register(nameof (PositionItem), typeof (ToolBarButton), typeof (BindingNavigator));
    /// <summary>
    /// Provides a property reference to MovePreviousItem property.
    /// </summary>
    private static SerializableProperty MovePreviousItemProperty = SerializableProperty.Register(nameof (MovePreviousItem), typeof (ToolBarButton), typeof (BindingNavigator));
    /// <summary>
    /// Provides a property reference to MoveNextItem property.
    /// </summary>
    private static SerializableProperty MoveNextItemProperty = SerializableProperty.Register(nameof (MoveNextItem), typeof (ToolBarButton), typeof (BindingNavigator));
    /// <summary>
    /// Provides a property reference to MoveLastItem property.
    /// </summary>
    private static SerializableProperty MoveLastItemProperty = SerializableProperty.Register(nameof (MoveLastItem), typeof (ToolBarButton), typeof (BindingNavigator));
    /// <summary>
    /// Provides a property reference to MoveFirstItem property.
    /// </summary>
    private static SerializableProperty MoveFirstItemProperty = SerializableProperty.Register(nameof (MoveFirstItem), typeof (ToolBarButton), typeof (BindingNavigator));
    /// <summary>Provides a property reference to DeleteItem property.</summary>
    private static SerializableProperty DeleteItemProperty = SerializableProperty.Register(nameof (DeleteItem), typeof (ToolBarButton), typeof (BindingNavigator));
    /// <summary>
    /// Provides a property reference to CountItemFormat property.
    /// </summary>
    private static SerializableProperty CountItemFormatProperty = SerializableProperty.Register(nameof (CountItemFormat), typeof (string), typeof (BindingNavigator));
    /// <summary>
    /// Provides a property reference to BindingSource property.
    /// </summary>
    private static SerializableProperty BindingSourceProperty = SerializableProperty.Register(nameof (BindingSource), typeof (BindingSource), typeof (BindingNavigator));
    /// <summary>Provides a property reference to AddNewItem property.</summary>
    private static SerializableProperty AddNewItemProperty = SerializableProperty.Register(nameof (AddNewItem), typeof (ToolBarButton), typeof (BindingNavigator));
    /// <summary>The RefreshItems event registration.</summary>
    private static readonly SerializableEvent RefreshItemsEvent = SerializableEvent.Register("RefreshItems", typeof (EventHandler), typeof (BindingNavigator));

    /// <summary>Occurs when the state of the navigational user interface (UI) needs to be refreshed to reflect the current state of the underlying data.</summary>
    [SRDescription("BindingNavigatorRefreshItemsEventDescr")]
    [SRCategory("CatBehavior")]
    public event EventHandler RefreshItems
    {
      add => this.AddHandler(BindingNavigator.RefreshItemsEvent, (Delegate) value);
      remove => this.RemoveHandler(BindingNavigator.RefreshItemsEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the RefreshItems event.</summary>
    private EventHandler RefreshItemsHandler => (EventHandler) this.GetHandler(BindingNavigator.RefreshItemsEvent);

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class, indicating whether to display the standard navigation user interface (UI).</summary>
    /// <param name="blnAddStandardItems">true to show the standard navigational UI; otherwise, false.</param>
    public BindingNavigator(bool blnAddStandardItems)
    {
      this.SetCountItemFormatDirectly(SR.GetString("BindingNavigatorCountItemFormat"));
      if (!blnAddStandardItems)
        return;
      this.AddStandardItems();
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class and adds this new instance to the specified container.</summary>
    /// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to add the new <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> control to.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BindingNavigator(IContainer objContainer)
      : this(false)
    {
      objContainer?.Add((IComponent) this);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class with the specified <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> as the data source.</summary>
    /// <param name="objBindingSource">The <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> used as a data source.</param>
    public BindingNavigator(BindingSource objBindingSource)
      : this(true)
    {
      this.BindingSource = objBindingSource;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BindingNavigator()
      : this(false)
    {
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Add New button.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Add New button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>. The default is null.</returns>
    [SRDescription("BindingNavigatorAddNewItemPropDescr")]
    [TypeConverter(typeof (ReferenceConverter))]
    [SRCategory("CatItems")]
    [DefaultValue(null)]
    public ToolBarButton AddNewItem
    {
      get => this.GetValue<ToolBarButton>(BindingNavigator.AddNewItemProperty);
      set
      {
        if (this.AddNewItem == value)
          return;
        ToolBarButton objValue = this.WireUpButton(this.AddNewItem, value, new EventHandler(this.OnAddNew));
        this.SetValue<ToolBarButton>(BindingNavigator.AddNewItemProperty, objValue);
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> component that is the source of data.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> component associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see>. The default is null.</returns>
    [TypeConverter(typeof (ReferenceConverter))]
    [DefaultValue(null)]
    [SRCategory("CatData")]
    [SRDescription("BindingNavigatorBindingSourcePropDescr")]
    public BindingSource BindingSource
    {
      get => this.GetValue<BindingSource>(BindingNavigator.BindingSourceProperty);
      set
      {
        if (this.BindingSource == value)
          return;
        BindingSource objValue = this.WireUpBindingSource(this.BindingSource, value);
        this.SetValue<BindingSource>(BindingNavigator.BindingSourceProperty, objValue);
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the total number of items in the associated <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the total number of items in the associated <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>. </returns>
    [SRDescription("BindingNavigatorCountItemPropDescr")]
    [SRCategory("CatItems")]
    [TypeConverter(typeof (ReferenceConverter))]
    [DefaultValue(null)]
    [Obsolete("This property is not implemented - please use the PositionItem property which contains both position and count.")]
    public BindingNavigator.BindingNavigatorLabel CountItem
    {
      get => (BindingNavigator.BindingNavigatorLabel) null;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a string used to format the information displayed in the <see cref="P:System.Windows.Forms.BindingNavigator.CountItem"></see> control.
    /// </summary>
    /// <value>The count item format.</value>
    /// <returns>The format <see cref="T:System.String"></see> used to format the item count. The default is the string of {0}.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("BindingNavigatorCountItemFormatPropDescr")]
    public string CountItemFormat
    {
      get => this.GetValue<string>(BindingNavigator.CountItemFormatProperty);
      set
      {
        if (!(this.CountItemFormat != value))
          return;
        this.SetValue<string>(BindingNavigator.CountItemFormatProperty, value);
        this.RefreshItemsInternal();
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Delete functionality.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Delete button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
    [SRCategory("CatItems")]
    [TypeConverter(typeof (ReferenceConverter))]
    [SRDescription("BindingNavigatorDeleteItemPropDescr")]
    [DefaultValue(null)]
    public ToolBarButton DeleteItem
    {
      get => this.GetValue<ToolBarButton>(BindingNavigator.DeleteItemProperty);
      set
      {
        if (this.DeleteItem == value)
          return;
        ToolBarButton objValue = this.WireUpButton(this.DeleteItem, value, new EventHandler(this.OnDelete));
        this.SetValue<ToolBarButton>(BindingNavigator.DeleteItemProperty, objValue);
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move First functionality.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move First button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
    [SRCategory("CatItems")]
    [TypeConverter(typeof (ReferenceConverter))]
    [SRDescription("BindingNavigatorMoveFirstItemPropDescr")]
    [DefaultValue(null)]
    public ToolBarButton MoveFirstItem
    {
      get => this.GetValue<ToolBarButton>(BindingNavigator.MoveFirstItemProperty);
      set
      {
        if (this.MoveFirstItem == value)
          return;
        ToolBarButton objValue = this.WireUpButton(this.MoveFirstItem, value, new EventHandler(this.OnMoveFirst));
        this.SetValue<ToolBarButton>(BindingNavigator.MoveFirstItemProperty, objValue);
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Last functionality.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Last button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
    [SRDescription("BindingNavigatorMoveLastItemPropDescr")]
    [SRCategory("CatItems")]
    [TypeConverter(typeof (ReferenceConverter))]
    [DefaultValue(null)]
    public ToolBarButton MoveLastItem
    {
      get => this.GetValue<ToolBarButton>(BindingNavigator.MoveLastItemProperty);
      set
      {
        if (this.MoveLastItem == value)
          return;
        ToolBarButton objValue = this.WireUpButton(this.MoveLastItem, value, new EventHandler(this.OnMoveLast));
        this.SetValue<ToolBarButton>(BindingNavigator.MoveLastItemProperty, objValue);
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Next functionality.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Next button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
    [SRCategory("CatItems")]
    [SRDescription("BindingNavigatorMoveNextItemPropDescr")]
    [TypeConverter(typeof (ReferenceConverter))]
    [DefaultValue(null)]
    public ToolBarButton MoveNextItem
    {
      get => this.GetValue<ToolBarButton>(BindingNavigator.MoveNextItemProperty);
      set
      {
        if (this.MoveNextItem == value)
          return;
        ToolBarButton objValue = this.WireUpButton(this.MoveNextItem, value, new EventHandler(this.OnMoveNext));
        this.SetValue<ToolBarButton>(BindingNavigator.MoveNextItemProperty, objValue);
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Previous functionality.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Previous button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
    [SRCategory("CatItems")]
    [SRDescription("BindingNavigatorMovePreviousItemPropDescr")]
    [TypeConverter(typeof (ReferenceConverter))]
    [DefaultValue(null)]
    public ToolBarButton MovePreviousItem
    {
      get => this.GetValue<ToolBarButton>(BindingNavigator.MovePreviousItemProperty);
      set
      {
        if (this.MovePreviousItem == value)
          return;
        ToolBarButton objValue = this.WireUpButton(this.MovePreviousItem, value, new EventHandler(this.OnMovePrevious));
        this.SetValue<ToolBarButton>(BindingNavigator.MovePreviousItemProperty, objValue);
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the current position within the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the current position.</returns>
    [SRDescription("BindingNavigatorPositionItemPropDescr")]
    [TypeConverter(typeof (ReferenceConverter))]
    [SRCategory("CatItems")]
    [DefaultValue(null)]
    public BindingNavigator.BindingNavigatorLabel PositionItem
    {
      get => this.GetValue<BindingNavigator.BindingNavigatorLabel>(BindingNavigator.PositionItemProperty);
      set
      {
        if (this.PositionItem == value)
          return;
        BindingNavigator.BindingNavigatorLabel objValue = this.WireUpTextBox((ToolBarButton) this.PositionItem, (ToolBarButton) value, new KeyEventHandler(this.OnPositionKey), new EventHandler(this.OnPositionLostFocus)) as BindingNavigator.BindingNavigatorLabel;
        this.SetValue<BindingNavigator.BindingNavigatorLabel>(BindingNavigator.PositionItemProperty, objValue);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator" /> is initializing.
    /// </summary>
    /// <value><c>true</c> if initializing; otherwise, <c>false</c>.</value>
    private bool Initializing
    {
      get => this.GetValue<bool>(BindingNavigator.InitializingProperty);
      set
      {
        if (this.Initializing == value)
          return;
        this.SetValue<bool>(BindingNavigator.InitializingProperty, value);
      }
    }

    /// <summary>Gets the default text align.</summary>
    /// <value>The default text align.</value>
    protected override ToolBarTextAlign DefaultTextAlign => ToolBarTextAlign.Right;

    /// <summary>Gets the toolbar button collecction</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ToolBarItemCollection Buttons => base.Buttons;

    /// <summary>Adds the standard set of navigation items to the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> control.</summary>
    public virtual void AddStandardItems()
    {
      if (this.DesignMode)
        return;
      bool flag = false;
      this.MoveFirstItem = new ToolBarButton();
      this.MovePreviousItem = new ToolBarButton();
      this.MoveNextItem = new ToolBarButton();
      this.MoveLastItem = new ToolBarButton();
      this.PositionItem = new BindingNavigator.BindingNavigatorLabel();
      this.AddNewItem = new ToolBarButton();
      this.DeleteItem = new ToolBarButton();
      ToolBarButton toolBarButton1 = new ToolBarButton();
      ToolBarButton toolBarButton2 = new ToolBarButton();
      ToolBarButton toolBarButton3 = new ToolBarButton();
      char ch = CommonUtils.IsNullOrEmpty(this.Name) || char.IsLower(this.Name[0]) ? 'b' : 'B';
      this.MoveFirstItem.Name = ch.ToString() + "indingNavigatorMoveFirstItem";
      this.MovePreviousItem.Name = ch.ToString() + "indingNavigatorMovePreviousItem";
      this.MoveNextItem.Name = ch.ToString() + "indingNavigatorMoveNextItem";
      this.MoveLastItem.Name = ch.ToString() + "indingNavigatorMoveLastItem";
      this.PositionItem.Name = ch.ToString() + "indingNavigatorPositionItem";
      this.AddNewItem.Name = ch.ToString() + "indingNavigatorAddNewItem";
      this.DeleteItem.Name = ch.ToString() + "indingNavigatorDeleteItem";
      toolBarButton1.Name = ch.ToString() + "indingNavigatorSeparator";
      toolBarButton2.Name = ch.ToString() + "indingNavigatorSeparator";
      toolBarButton3.Name = ch.ToString() + "indingNavigatorSeparator";
      this.MoveFirstItem.ToolTipText = SR.GetString("BindingNavigatorMoveFirstItemText");
      this.MovePreviousItem.ToolTipText = SR.GetString("BindingNavigatorMovePreviousItemText");
      this.MoveNextItem.ToolTipText = SR.GetString("BindingNavigatorMoveNextItemText");
      this.MoveLastItem.ToolTipText = SR.GetString("BindingNavigatorMoveLastItemText");
      this.AddNewItem.ToolTipText = SR.GetString("BindingNavigatorAddNewItemText");
      this.DeleteItem.ToolTipText = SR.GetString("BindingNavigatorDeleteItemText");
      this.PositionItem.ToolTipText = SR.GetString("BindingNavigatorPositionItemTip");
      if (this.Context != null)
        flag = this.Context.RightToLeft;
      this.MoveFirstItem.Image = (ResourceHandle) new SkinResourceHandle((Gizmox.WebGUI.Forms.Skins.Skin) this.Skin, string.Format("NavigateHome{0}.gif", flag ? (object) "RTL" : (object) "LTR"));
      this.MovePreviousItem.Image = (ResourceHandle) new SkinResourceHandle((Gizmox.WebGUI.Forms.Skins.Skin) this.Skin, string.Format("NavigatePrev{0}.gif", flag ? (object) "RTL" : (object) "LTR"));
      this.MoveNextItem.Image = (ResourceHandle) new SkinResourceHandle((Gizmox.WebGUI.Forms.Skins.Skin) this.Skin, string.Format("NavigateNext{0}.gif", flag ? (object) "RTL" : (object) "LTR"));
      this.MoveLastItem.Image = (ResourceHandle) new SkinResourceHandle((Gizmox.WebGUI.Forms.Skins.Skin) this.Skin, string.Format("NavigateEnd{0}.gif", flag ? (object) "RTL" : (object) "LTR"));
      this.AddNewItem.Image = (ResourceHandle) new SkinResourceHandle((Gizmox.WebGUI.Forms.Skins.Skin) this.Skin, "Add.gif");
      this.DeleteItem.Image = (ResourceHandle) new SkinResourceHandle((Gizmox.WebGUI.Forms.Skins.Skin) this.Skin, "Delete.gif");
      this.MoveFirstItem.Style = ToolBarButtonStyle.PushButton;
      this.MovePreviousItem.Style = ToolBarButtonStyle.PushButton;
      this.MoveNextItem.Style = ToolBarButtonStyle.PushButton;
      this.MoveLastItem.Style = ToolBarButtonStyle.PushButton;
      this.AddNewItem.Style = ToolBarButtonStyle.PushButton;
      this.DeleteItem.Style = ToolBarButtonStyle.PushButton;
      toolBarButton1.Style = ToolBarButtonStyle.Separator;
      toolBarButton2.Style = ToolBarButtonStyle.Separator;
      toolBarButton3.Style = ToolBarButtonStyle.Separator;
      this.Buttons.AddRange(new ToolBarButton[10]
      {
        this.MoveFirstItem,
        this.MovePreviousItem,
        toolBarButton1,
        (ToolBarButton) this.PositionItem,
        toolBarButton2,
        this.MoveNextItem,
        this.MoveLastItem,
        toolBarButton3,
        this.AddNewItem,
        this.DeleteItem
      });
    }

    /// <summary>Disables updates to the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> controls of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> during the component's initialization.</summary>
    public void BeginInit() => this.Initializing = true;

    /// <summary>Enables updates to the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> controls of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> after the component's initialization has concluded.</summary>
    public void EndInit()
    {
      this.Initializing = false;
      this.RefreshItemsInternal();
    }

    /// <summary>Causes form validation to occur and returns whether validation was successful.</summary>
    /// <returns>true if validation was successful and focus can shift to the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see>; otherwise, false.</returns>
    public bool Validate() => true;

    /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> and optionally releases the managed resources. </summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
        this.BindingSource = (BindingSource) null;
      base.Dispose(blnDisposing);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.BindingNavigator.RefreshItems"></see> event.</summary>
    protected virtual void OnRefreshItems()
    {
      this.RefreshItemsCore();
      EventHandler refreshItemsHandler = this.RefreshItemsHandler;
      if (refreshItemsHandler == null)
        return;
      refreshItemsHandler((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Refreshes the state of the standard items to reflect the current state of the data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void RefreshItemsCore()
    {
      ToolBarButton addNewItem = this.AddNewItem;
      BindingSource bindingSource = this.BindingSource;
      ToolBarButton moveFirstItem = this.MoveFirstItem;
      ToolBarButton movePreviousItem = this.MovePreviousItem;
      ToolBarButton moveNextItem = this.MoveNextItem;
      ToolBarButton moveLastItem = this.MoveLastItem;
      ToolBarButton deleteItem = this.DeleteItem;
      ToolBarButton positionItem = (ToolBarButton) this.PositionItem;
      int num1;
      int num2;
      bool flag1;
      bool flag2;
      if (bindingSource == null)
      {
        num1 = 0;
        num2 = 0;
        flag1 = false;
        flag2 = false;
      }
      else
      {
        num1 = this.BindingSource.Count;
        num2 = this.BindingSource.Position + 1;
        flag1 = this.BindingSource.AllowNew;
        flag2 = this.BindingSource.AllowRemove;
      }
      if (!this.DesignMode)
      {
        if (moveFirstItem != null)
          moveFirstItem.Enabled = num2 > 1;
        if (movePreviousItem != null)
          movePreviousItem.Enabled = num2 > 1;
        if (moveNextItem != null)
          moveNextItem.Enabled = num2 < num1;
        if (moveLastItem != null)
          moveLastItem.Enabled = num2 < num1;
        if (this.AddNewItem != null)
          addNewItem.Enabled = flag1;
        if (deleteItem != null)
          deleteItem.Enabled = flag2 && num1 > 0;
        if (positionItem != null)
          positionItem.Enabled = num2 > 0 && num1 > 0;
      }
      if (positionItem == null)
        return;
      ToolBarButton toolBarButton = positionItem;
      string str;
      if (!this.DesignMode)
        str = string.Format((IFormatProvider) CultureInfo.CurrentCulture, this.CountItemFormat, (object) num2.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) num1);
      else
        str = this.CountItemFormat;
      toolBarButton.Text = str;
    }

    private void SetCountItemFormatDirectly(string strValue)
    {
      if (!(this.CountItemFormat != strValue))
        return;
      this.SetValue<string>(BindingNavigator.CountItemFormatProperty, strValue);
    }

    private void AcceptNewPosition()
    {
      BindingSource bindingSource = this.BindingSource;
      ToolBarButton positionItem = (ToolBarButton) this.PositionItem;
      if (positionItem == null || bindingSource == null)
        return;
      int num = bindingSource.Position;
      try
      {
        num = Convert.ToInt32(positionItem.Text, (IFormatProvider) CultureInfo.CurrentCulture) - 1;
      }
      catch (FormatException ex)
      {
      }
      catch (OverflowException ex)
      {
      }
      if (num != bindingSource.Position)
        bindingSource.Position = num;
      this.RefreshItemsInternal();
    }

    private void CancelNewPosition() => this.RefreshItemsInternal();

    private void OnAddNew(object sender, EventArgs e)
    {
      BindingSource bindingSource = this.BindingSource;
      if (!this.Validate() || bindingSource == null)
        return;
      bindingSource.AddNew();
      this.RefreshItemsInternal();
    }

    private void OnBindingSourceListChanged(object sender, ListChangedEventArgs e) => this.RefreshItemsInternal();

    private void OnBindingSourceStateChanged(object sender, EventArgs e) => this.RefreshItemsInternal();

    private void OnDelete(object sender, EventArgs e)
    {
      BindingSource bindingSource = this.BindingSource;
      if (!this.Validate() || bindingSource == null)
        return;
      bindingSource.RemoveCurrent();
      this.RefreshItemsInternal();
    }

    private void OnMoveFirst(object sender, EventArgs e)
    {
      BindingSource bindingSource = this.BindingSource;
      if (!this.Validate() || bindingSource == null)
        return;
      bindingSource.MoveFirst();
      this.RefreshItemsInternal();
    }

    private void OnMoveLast(object sender, EventArgs e)
    {
      BindingSource bindingSource = this.BindingSource;
      if (!this.Validate() || bindingSource == null)
        return;
      bindingSource.MoveLast();
      this.RefreshItemsInternal();
    }

    private void OnMoveNext(object sender, EventArgs e)
    {
      BindingSource bindingSource = this.BindingSource;
      if (!this.Validate() || bindingSource == null)
        return;
      bindingSource.MoveNext();
      this.RefreshItemsInternal();
    }

    private void OnMovePrevious(object sender, EventArgs e)
    {
      BindingSource bindingSource = this.BindingSource;
      if (!this.Validate() || bindingSource == null)
        return;
      bindingSource.MovePrevious();
      this.RefreshItemsInternal();
    }

    private void OnPositionKey(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Enter:
          this.AcceptNewPosition();
          break;
        case Keys.Escape:
          this.CancelNewPosition();
          break;
      }
    }

    private void OnPositionLostFocus(object sender, EventArgs e) => this.AcceptNewPosition();

    private void RefreshItemsInternal()
    {
      if (this.Initializing)
        return;
      this.OnRefreshItems();
    }

    private void ResetCountItemFormat() => this.SetCountItemFormatDirectly(SR.GetString("BindingNavigatorCountItemFormat"));

    private bool ShouldSerializeCountItemFormat() => this.CountItemFormat != SR.GetString("BindingNavigatorCountItemFormat");

    private BindingSource WireUpBindingSource(
      BindingSource oldBindingSource,
      BindingSource newBindingSource)
    {
      if (oldBindingSource != newBindingSource)
      {
        if (oldBindingSource != null)
        {
          oldBindingSource.PositionChanged -= new EventHandler(this.OnBindingSourceStateChanged);
          oldBindingSource.CurrentChanged -= new EventHandler(this.OnBindingSourceStateChanged);
          oldBindingSource.CurrentItemChanged -= new EventHandler(this.OnBindingSourceStateChanged);
          oldBindingSource.DataSourceChanged -= new EventHandler(this.OnBindingSourceStateChanged);
          oldBindingSource.DataMemberChanged -= new EventHandler(this.OnBindingSourceStateChanged);
          oldBindingSource.ListChanged -= new ListChangedEventHandler(this.OnBindingSourceListChanged);
        }
        if (newBindingSource != null)
        {
          newBindingSource.PositionChanged += new EventHandler(this.OnBindingSourceStateChanged);
          newBindingSource.CurrentChanged += new EventHandler(this.OnBindingSourceStateChanged);
          newBindingSource.CurrentItemChanged += new EventHandler(this.OnBindingSourceStateChanged);
          newBindingSource.DataSourceChanged += new EventHandler(this.OnBindingSourceStateChanged);
          newBindingSource.DataMemberChanged += new EventHandler(this.OnBindingSourceStateChanged);
          newBindingSource.ListChanged += new ListChangedEventHandler(this.OnBindingSourceListChanged);
        }
        oldBindingSource = newBindingSource;
        this.RefreshItemsInternal();
      }
      return oldBindingSource;
    }

    private ToolBarButton WireUpButton(
      ToolBarButton oldButton,
      ToolBarButton newButton,
      EventHandler clickHandler)
    {
      if (oldButton != newButton)
      {
        if (oldButton != null)
          oldButton.Click -= clickHandler;
        if (newButton != null)
          newButton.Click += clickHandler;
        oldButton = newButton;
        this.RefreshItemsInternal();
      }
      return oldButton;
    }

    private ToolBarButton WireUpLabel(ToolBarButton oldLabel, ToolBarButton newLabel)
    {
      if (oldLabel != newLabel)
      {
        oldLabel = newLabel;
        this.RefreshItemsInternal();
      }
      return oldLabel;
    }

    private ToolBarButton WireUpTextBox(
      ToolBarButton oldTextBox,
      ToolBarButton newTextBox,
      KeyEventHandler keyUpHandler,
      EventHandler lostFocusHandler)
    {
      if (oldTextBox != newTextBox)
      {
        oldTextBox = newTextBox;
        this.RefreshItemsInternal();
      }
      return oldTextBox;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class BindingNavigatorLabel : ToolBarButton
    {
      /// <summary>
      /// </summary>
      /// <value></value>
      public override string CustomStyle
      {
        get => "Label";
        set => base.CustomStyle = value;
      }
    }
  }
}
