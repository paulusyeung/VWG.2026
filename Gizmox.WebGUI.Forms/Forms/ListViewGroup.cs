// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewGroup
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a group of items displayed within a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [DefaultProperty("Header")]
  [DesignTimeVisible(false)]
  [TypeConverter(typeof (ListViewGroupConverter))]
  [ToolboxItem(false)]
  [Serializable]
  public sealed class ListViewGroup : SerializableObject
  {
    private string mstrHeader;
    private HorizontalAlignment menmHeaderAlignment;
    private ListView.ListViewItemCollection mobjItems;
    private ListView listView;
    private string mstrName;
    private static int mintNextHeader = 1;
    private object mobjUserData;
    /// <summary>The group property registration.</summary>
    private static readonly SerializableProperty GroupProperty = SerializableProperty.Register(nameof (Group), typeof (ListViewGroup), typeof (ListViewGroup), new SerializablePropertyMetadata((object) null));
    /// <summary>The groups collection</summary>
    private static readonly SerializableProperty GroupsProperty = SerializableProperty.Register(nameof (Groups), typeof (ListViewGroupCollection), typeof (ListViewGroup), new SerializablePropertyMetadata((object) null));

    /// <filterpriority>1</filterpriority>
    public override string ToString() => this.Header;

    /// <summary>Gets or sets the header text for the group.</summary>
    /// <returns>The text to display for the group header. The default is "ListViewGroup".</returns>
    [SRCategory("CatAppearance")]
    public string Header
    {
      get => this.mstrHeader != null ? this.mstrHeader : "";
      set
      {
        if (!(this.mstrHeader != value))
          return;
        this.mstrHeader = value;
      }
    }

    /// <summary>Gets or sets the alignment of the group header text.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values that specifies the alignment of the header text. The default is <see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatAppearance")]
    [DefaultValue(0)]
    public HorizontalAlignment HeaderAlignment
    {
      get => this.menmHeaderAlignment;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (HorizontalAlignment));
        if (this.menmHeaderAlignment == value)
          return;
        this.menmHeaderAlignment = value;
        this.UpdateListView();
      }
    }

    /// <summary>Gets or sets the group to which the item is assigned.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to which the item is assigned.</returns>
    [Localizable(true)]
    [DefaultValue(null)]
    [SRCategory("CatBehavior")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ListViewGroup Group
    {
      get => this.GetValue<ListViewGroup>(ListViewGroup.GroupProperty);
      set
      {
        ListViewGroup group = this.Group;
        if (group == value)
          return;
        if (value != null)
          value.Groups.Add(this);
        else
          group?.Groups.Remove(this);
      }
    }

    /// <summary>Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> objects assigned to the control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> that contains all the groups in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
    [MergableProperty(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    [SRDescription("ListViewGroupsDescr")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ListViewGroupCollection Groups
    {
      get
      {
        ListViewGroupCollection objValue = this.GetValue<ListViewGroupCollection>(ListViewGroup.GroupsProperty);
        if (objValue == null)
        {
          objValue = new ListViewGroupCollection(this);
          this.SetValue<ListViewGroupCollection>(ListViewGroup.GroupsProperty, objValue);
        }
        return objValue;
      }
    }

    /// <summary>Gets a collection containing all items associated with this group.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> that contains all the items in the group. If there are no items in the group, an empty <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> object is returned.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public ListView.ListViewItemCollection Items
    {
      get
      {
        if (this.mobjItems == null)
          this.mobjItems = new ListView.ListViewItemCollection(this);
        return this.mobjItems;
      }
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains this group. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains this group.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public ListView ListView => this.listView;

    internal ListView ListViewInternal
    {
      get => this.listView;
      set
      {
        if (this.listView == value)
          return;
        this.listView = value;
      }
    }

    /// <summary>Gets or sets the name of the group.</summary>
    /// <returns>The name of the group.</returns>
    [SRCategory("CatBehavior")]
    [Browsable(true)]
    [DefaultValue("")]
    [SRDescription("ListViewGroupNameDescr")]
    public string Name
    {
      get => this.mstrName;
      set => this.mstrName = value;
    }

    /// <summary>Gets or sets the object that contains data about the group.</summary>
    /// <returns>An <see cref="T:System.Object"></see> for storing the additional data. </returns>
    /// <filterpriority>1</filterpriority>
    [Localizable(false)]
    [DefaultValue(null)]
    [TypeConverter(typeof (StringConverter))]
    [SRCategory("CatData")]
    [SRDescription("ControlTagDescr")]
    [Bindable(true)]
    public object Tag
    {
      get => this.mobjUserData;
      set => this.mobjUserData = value;
    }

    private void UpdateListView()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the default header text of "ListViewGroup" and the default left header alignment.</summary>
    public ListViewGroup()
      : this(SR.GetString("ListViewGroupDefaultHeader", (object) ListViewGroup.mintNextHeader++))
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified value to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property and using the default left header alignment.</summary>
    /// <param name="strHeader">The text to display for the group header. </param>
    public ListViewGroup(string strHeader) => this.mstrHeader = strHeader;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified values to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> and <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> properties. </summary>
    /// <param name="strHeaderText">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property.</param>
    /// <param name="strKey">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property.</param>
    public ListViewGroup(string strKey, string strHeaderText)
      : this()
    {
      this.mstrName = strKey;
      this.mstrHeader = strHeaderText;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified header text and the specified header alignment.</summary>
    /// <param name="strHeader">The text to display for the group header. </param>
    /// <param name="enmHeaderAlignment">One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values that specifies the alignment of the header text. </param>
    public ListViewGroup(string strHeader, HorizontalAlignment enmHeaderAlignment)
      : this(strHeader)
    {
      this.menmHeaderAlignment = enmHeaderAlignment;
    }
  }
}
