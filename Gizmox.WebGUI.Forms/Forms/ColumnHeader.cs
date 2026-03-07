// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColumnHeader
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for ColumnHeader.</summary>
  [ToolboxItem(false)]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DesignTimeVisible(false)]
  [TypeConverter(typeof (ColumnHeaderConverter))]
  [Serializable]
  public class ColumnHeader : Component, IComparable
  {
    /// <summary>The column header name</summary>
    [NonSerialized]
    private string mstrName = string.Empty;
    /// <summary>The column header label</summary>
    [NonSerialized]
    private string mstrLabel = string.Empty;
    /// <summary>The column header type</summary>
    [NonSerialized]
    private ListViewColumnType menmType;
    /// <summary>The column header width</summary>
    [NonSerialized]
    private int mintWidth = 150;
    /// <summary>The column header internal width</summary>
    [NonSerialized]
    private int mintInternalWidth = 150;
    /// <summary>The column header text align</summary>
    [NonSerialized]
    private HorizontalAlignment menmTextAlign;
    /// <summary>The coumn header content alignment</summary>
    [NonSerialized]
    private ExtendedHorizontalAlignment menmContentAlignment = ExtendedHorizontalAlignment.Inherit;
    /// <summary>The column header index</summary>
    [NonSerialized]
    private int mintIndex = -1;
    /// <summary>The column header resource</summary>
    [NonSerialized]
    private ResourceHandle mobjResourceHandler;
    /// <summary>The column header display index</summary>
    [NonSerialized]
    private int mintDisplayIndexInternal = -1;
    /// <summary>Sort direction</summary>
    [NonSerialized]
    private SortOrder menmSortOrder;
    /// <summary>Sort position</summary>
    [NonSerialized]
    private int mintSortPosition = 1000;
    /// <summary>The column header group by flag</summary>
    [NonSerialized]
    private bool mblnGroupBy;
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private int mintGroupByPosition = -1;
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private int mintPreferedItemHeight;
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private int mintImageIndex = -1;
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private string mstrImageKey = string.Empty;
    /// <summary>The amount of fields that the control writes / reads</summary>
    private const int mcntSerializableDataFieldCount = 15;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> class.
    /// </summary>
    public ColumnHeader() => this.InitializeState(true);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> class.
    /// </summary>
    /// <param name="strLabel">The STR label.</param>
    public ColumnHeader(string strLabel)
    {
      this.mstrLabel = strLabel;
      this.InitializeState(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="strLabel"></param>
    public ColumnHeader(string strName, string strLabel)
    {
      this.mstrName = strName;
      this.mstrLabel = strLabel;
      this.InitializeState(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="strLabel"></param>
    /// <param name="blnLoaded"></param>
    public ColumnHeader(string strName, string strLabel, bool blnLoaded)
    {
      this.mstrName = strName;
      this.mstrLabel = strLabel;
      this.InitializeState(blnLoaded);
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> instance.
    /// </summary>
    /// <param name="strName">Name.</param>
    /// <param name="strLabel">Label.</param>
    /// <param name="intWidth">Width.</param>
    public ColumnHeader(string strName, string strLabel, int intWidth)
    {
      this.mstrName = strName;
      this.mstrLabel = strLabel;
      this.mintWidth = intWidth;
      this.InternalWidth = intWidth;
      this.InitializeState(true);
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> instance.
    /// </summary>
    /// <param name="strName">Name.</param>
    /// <param name="strLabel">Label.</param>
    /// <param name="intWidth">Width.</param>
    /// <param name="blnLoaded"></param>
    public ColumnHeader(string strName, string strLabel, int intWidth, bool blnLoaded)
    {
      this.mstrName = strName;
      this.mstrLabel = strLabel;
      this.mintWidth = intWidth;
      this.InternalWidth = intWidth;
      this.InitializeState(blnLoaded);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="strLabel"></param>
    /// <param name="intWidth"></param>
    /// <param name="enmType"></param>
    public ColumnHeader(string strName, string strLabel, int intWidth, ListViewColumnType enmType)
    {
      this.mstrName = strName;
      this.mstrLabel = strLabel;
      this.mintWidth = intWidth;
      this.InternalWidth = intWidth;
      this.menmType = enmType;
      this.InitializeState(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="strLabel"></param>
    /// <param name="intWidth"></param>
    /// <param name="enmType"></param>
    /// <param name="blnLoaded"></param>
    public ColumnHeader(
      string strName,
      string strLabel,
      int intWidth,
      ListViewColumnType enmType,
      bool blnLoaded)
    {
      this.mstrName = strName;
      this.mstrLabel = strLabel;
      this.mintWidth = intWidth;
      this.InternalWidth = intWidth;
      this.menmType = enmType;
      this.InitializeState(blnLoaded);
    }

    /// <summary>Should serialize the display index.</summary>
    /// <returns></returns>
    private bool ShouldSerializeDisplayIndex() => this.DisplayIndex != this.Index;

    /// <summary>Should serialize the name.</summary>
    /// <returns></returns>
    private bool ShouldSerializeName() => !string.IsNullOrEmpty(this.Name);

    /// <summary>Should serialize the text.</summary>
    /// <returns></returns>
    internal bool ShouldSerializeText() => this.Text != null;

    /// <summary>Shoulds the serialize image.</summary>
    /// <returns></returns>
    internal bool ShouldSerializeImage() => this.mobjResourceHandler != null;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (this.Visible)
      {
        switch (objEvent.Type)
        {
          case "ChangeColumnWidth":
            double dblValue = 0.0;
            if (CommonUtils.TryParse(objEvent["Width"], out dblValue))
            {
              this.mintWidth = Convert.ToInt32(dblValue);
              if (this.InternalParent is ListView internalParent)
              {
                internalParent.InternalColumnWidthChanged(this.Index);
                break;
              }
              break;
            }
            break;
          case "Sort":
            if (this.InternalParent is ListView internalParent1)
            {
              internalParent1.SortBy(this);
              break;
            }
            break;
        }
      }
      base.FireEvent(objEvent);
    }

    /// <summary>Renders the column header.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    /// <param name="lngRequestID">Request ID.</param>
    internal void RenderColumn(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      if (!this.IsDirty(lngRequestID) || !this.IsValidColumn)
        return;
      objWriter.WriteStartElement("C");
      objWriter.WriteAttributeString("Id", this.GetProxyPropertyValue<long>("ID", this.ID).ToString());
      IResponseWriter responseWriter1 = objWriter;
      int num = this.Index;
      string strValue1 = "c" + num.ToString();
      responseWriter1.WriteAttributeString("N", strValue1);
      objWriter.WriteAttributeText("TX", this.Label, TextFilter.NewLine | TextFilter.CarriageReturn);
      IResponseWriter responseWriter2 = objWriter;
      num = Math.Max(this.Width, 1);
      string strValue2 = num.ToString();
      responseWriter2.WriteAttributeString("W", strValue2);
      objWriter.WriteAttributeString("TP", this.Type.ToString());
      objWriter.WriteAttributeString("TA", this.GetTextAlign());
      objWriter.WriteAttributeString("CA", this.GetContentAlign());
      ResourceHandle image = this.Image;
      if (image != null)
        objWriter.WriteAttributeString("IM", image.ToString());
      if (this.SortOrder != SortOrder.None)
        objWriter.WriteAttributeString("SRT", this.SortOrder == SortOrder.Ascending ? "1" : "0");
      this.RenderComponentVisualEffectsAttributes(objContext, (IAttributeWriter) objWriter);
      this.RenderComponentEventAttributes(objContext, (IAttributeWriter) objWriter, false);
      this.RenderClientID((IAttributeWriter) objWriter, false);
      this.RenderExtendedComponentAttributes(objContext, (IAttributeWriter) objWriter);
      objWriter.WriteEndElement();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string GetTextAlign()
    {
      switch (this.TextAlign)
      {
        case HorizontalAlignment.Left:
          return !this.Context.RightToLeft ? "left" : "right";
        case HorizontalAlignment.Right:
          return !this.Context.RightToLeft ? "right" : "left";
        default:
          return "center";
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string GetContentAlign()
    {
      switch (this.ContentAlign)
      {
        case ExtendedHorizontalAlignment.Left:
          return !this.Context.RightToLeft ? "left" : "right";
        case ExtendedHorizontalAlignment.Right:
          return !this.Context.RightToLeft ? "right" : "left";
        case ExtendedHorizontalAlignment.Inherit:
          return this.GetTextAlign();
        default:
          return "center";
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString() => "ColumnHeader: Text: " + this.Text;

    /// <summary>Resizes the width of the column as indicated by the resize style.</summary>
    /// <param name="enmHeaderAutoResize">One of the <see cref="T:System.Windows.Forms.ColumnHeaderAutoResizeStyle"></see>  values.</param>
    /// <exception cref="T:System.InvalidOperationException">A value other than <see cref="F:System.Windows.Forms.ColumnHeaderAutoResizeStyle.None"></see> is passed to the <see cref="M:System.Windows.Forms.ColumnHeader.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle)"></see> method when the <see cref="P:System.Windows.Forms.ListView.View"></see> property is a value other than <see cref="F:System.Windows.Forms.View.Details"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void AutoResize(ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
    {
      if (enmHeaderAutoResize < ColumnHeaderAutoResizeStyle.None || enmHeaderAutoResize > ColumnHeaderAutoResizeStyle.ColumnContent)
        throw new InvalidEnumArgumentException("headerAutoResize", (int) enmHeaderAutoResize, typeof (ColumnHeaderAutoResizeStyle));
      if (this.Owner == null)
        return;
      this.Owner.AutoResizeColumn(this.Index, enmHeaderAutoResize);
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 15;

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mblnGroupBy = objReader.ReadBoolean();
      this.menmContentAlignment = (ExtendedHorizontalAlignment) objReader.ReadObject();
      this.menmSortOrder = (SortOrder) objReader.ReadObject();
      this.menmTextAlign = (HorizontalAlignment) objReader.ReadObject();
      this.menmType = (ListViewColumnType) objReader.ReadObject();
      this.mintDisplayIndexInternal = objReader.ReadInt32();
      this.mintGroupByPosition = objReader.ReadInt32();
      this.mintIndex = objReader.ReadInt32();
      this.mintInternalWidth = objReader.ReadInt32();
      this.mintPreferedItemHeight = objReader.ReadInt32();
      this.mintSortPosition = objReader.ReadInt32();
      this.mintWidth = objReader.ReadInt32();
      this.mobjResourceHandler = (ResourceHandle) objReader.ReadObject();
      this.mstrLabel = objReader.ReadString();
      this.mstrName = objReader.ReadString();
      this.mintImageIndex = objReader.ReadInt32();
      this.mstrImageKey = objReader.ReadString();
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteObject((object) this.mblnGroupBy);
      objWriter.WriteObject((object) this.menmContentAlignment);
      objWriter.WriteObject((object) this.menmSortOrder);
      objWriter.WriteObject((object) this.menmTextAlign);
      objWriter.WriteObject((object) this.menmType);
      objWriter.WriteInt32(this.mintDisplayIndexInternal);
      objWriter.WriteInt32(this.mintGroupByPosition);
      objWriter.WriteInt32(this.mintIndex);
      objWriter.WriteInt32(this.mintInternalWidth);
      objWriter.WriteInt32(this.mintPreferedItemHeight);
      objWriter.WriteInt32(this.mintSortPosition);
      objWriter.WriteInt32(this.mintWidth);
      objWriter.WriteObject((object) this.mobjResourceHandler);
      objWriter.WriteString(this.mstrLabel);
      objWriter.WriteString(this.mstrName);
      objWriter.WriteObject((object) this.mintImageIndex);
      objWriter.WriteObject((object) this.mstrImageKey);
    }

    /// <summary>Gets or sets the display index.</summary>
    /// <value>The display index.</value>
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [SRDescription("ColumnHeaderDisplayIndexDescr")]
    public int DisplayIndex
    {
      get => this.DisplayIndexInternal;
      set
      {
        if (this.Owner == null)
        {
          this.DisplayIndexInternal = value;
        }
        else
        {
          if (value < 0 || value > this.Owner.Columns.Count - 1)
            throw new ArgumentOutOfRangeException(nameof (DisplayIndex), SR.GetString("ColumnHeaderBadDisplayIndex"));
          int num1 = Math.Min(this.DisplayIndexInternal, value);
          int num2 = Math.Max(this.DisplayIndexInternal, value);
          int[] numArray = new int[this.Owner.Columns.Count];
          bool flag = value > this.DisplayIndexInternal;
          ColumnHeader columnHeader = (ColumnHeader) null;
          for (int intIndex = 0; intIndex < this.Owner.Columns.Count; ++intIndex)
          {
            ColumnHeader column = this.Owner.Columns[intIndex];
            if (column.DisplayIndex == this.DisplayIndexInternal)
              columnHeader = column;
            else if (column.DisplayIndex >= num1 && column.DisplayIndex <= num2)
              column.DisplayIndexInternal -= flag ? 1 : -1;
            if (intIndex != this.Index)
              numArray[column.DisplayIndexInternal] = intIndex;
          }
          columnHeader.DisplayIndexInternal = value;
          this.Owner.Columns.ClearSortedColumns();
        }
      }
    }

    /// <summary>Gets or sets the display index internal.</summary>
    /// <value>The display index internal.</value>
    internal int DisplayIndexInternal
    {
      get => this.mintDisplayIndexInternal;
      set
      {
        this.mintDisplayIndexInternal = value;
        if (this.InternalParent == null)
          return;
        this.InternalParent.Update();
      }
    }

    private ListView Owner => this.InternalParent as ListView;

    /// <summary>
    /// Gets or sets the image displayed in the <see cref="T:System.Windows.Forms.ColumnHeader"></see>.
    /// </summary>
    /// <returns>
    /// The image displayed in the <see cref="T:System.Windows.Forms.ColumnHeader"></see>.
    /// </returns>
    public ResourceHandle Image
    {
      get
      {
        ResourceHandle resourceHandle = (ResourceHandle) null;
        if (this.ImageList != null)
          resourceHandle = this.GetImage((SerializableProperty) null, this.ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
        return resourceHandle ?? this.mobjResourceHandler;
      }
      set
      {
        if (this.mobjResourceHandler == value)
          return;
        this.mobjResourceHandler = value;
        this.mintImageIndex = -1;
        this.mstrImageKey = string.Empty;
        this.ListView?.Update();
      }
    }

    /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
    /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("ListViewItemImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public int ImageIndex
    {
      get => this.mintImageIndex;
      set
      {
        if (this.mintImageIndex == value)
          return;
        this.mintImageIndex = value;
        this.mobjResourceHandler = (ResourceHandle) null;
        this.mstrImageKey = string.Empty;
        this.ListView?.Update();
      }
    }

    /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
    /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Localizable(true)]
    [DefaultValue("")]
    public string ImageKey
    {
      get => this.mstrImageKey;
      set
      {
        if (this.mstrImageKey.Equals(value))
          return;
        this.mstrImageKey = value;
        this.mobjResourceHandler = (ResourceHandle) null;
        this.mintImageIndex = -1;
        this.ListView?.Update();
      }
    }

    /// <summary>Gets the image list.</summary>
    [Browsable(false)]
    public ImageList ImageList
    {
      get
      {
        if (this.ListView != null)
        {
          switch (this.ListView.View)
          {
            case View.Details:
            case View.List:
            case View.SmallIcon:
              return this.ListView.SmallImageList;
            case View.LargeIcon:
              return this.ListView.LargeImageList;
          }
        }
        return (ImageList) null;
      }
    }

    /// <summary>Gets the list view.</summary>
    /// <value></value>
    [Browsable(false)]
    public ListView ListView => this.InternalParent as ListView;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> is visible.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if visible; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [Browsable(false)]
    public bool Visible
    {
      get => this.GetState(Component.ComponentState.Visible);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Visible, value) || this.InternalParent == null)
          return;
        this.InternalParent.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> is loaded.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if loaded; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Loaded
    {
      get => this.GetState(Component.ComponentState.Loaded);
      set => this.SetState(Component.ComponentState.Loaded, value);
    }

    /// <summary>Initializes the state.</summary>
    private void InitializeState(bool blnLoaded)
    {
      this.SetState(Component.ComponentState.Visible, true);
      this.SetState(Component.ComponentState.Loaded, blnLoaded);
    }

    /// <summary>Gets or sets the index.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int Index => this.mintIndex;

    /// <summary>Sets the internal index.</summary>
    /// <value></value>
    internal int InternalIndex
    {
      set
      {
        if (this.InternalParent != null)
          this.InternalParent.Update();
        this.mintIndex = value;
      }
    }

    /// <summary>Gets or sets the name.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string Name
    {
      get => this.mstrName;
      set
      {
        if (this.InternalParent != null)
          this.InternalParent.Update();
        this.mstrName = value;
      }
    }

    /// <summary>Gets or sets the text displayed in the column header.</summary>
    /// <returns>The text displayed in the column header.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Localizable(true)]
    [SRDescription("ColumnCaption")]
    public string Text
    {
      get => this.Label;
      set
      {
        this.Label = value;
        this.FireObservableItemPropertyChanged(nameof (Text));
      }
    }

    /// <summary>Gets or sets the label.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string Label
    {
      get => this.mstrLabel;
      set
      {
        if (this.InternalParent != null)
          this.InternalParent.Update();
        this.mstrLabel = value;
      }
    }

    /// <summary>Gets or sets the width.</summary>
    /// <value></value>
    public int Width
    {
      get => this.mintWidth;
      set
      {
        this.InternalWidth = value;
        if (this.InternalWidth > 0)
          this.mintWidth = this.InternalWidth;
        else if (this.Owner != null && this.Owner.InUpadte <= 0)
          this.mintWidth = this.Owner.GetColumnFixedWidth(this.Index, this.InternalWidth, false);
        if (this.InternalParent != null)
          this.InternalParent.Update();
        this.FireObservableItemPropertyChanged(nameof (Width));
      }
    }

    /// <summary>Gets or sets the internal width.</summary>
    /// <value></value>
    internal int InternalWidth
    {
      get => this.mintInternalWidth;
      set => this.mintInternalWidth = value;
    }

    /// <summary>Gets or sets the type.</summary>
    /// <value></value>
    [Browsable(true)]
    [DefaultValue(ListViewColumnType.Text)]
    public ListViewColumnType Type
    {
      get => this.menmType;
      set => this.menmType = value;
    }

    /// <summary>Gets or sets the height of the prefered item.</summary>
    /// <value>The height of the prefered item.</value>
    [Browsable(true)]
    [DefaultValue(0)]
    public int PreferedItemHeight
    {
      get => this.Type == ListViewColumnType.Control ? this.mintPreferedItemHeight : 0;
      set => this.mintPreferedItemHeight = value;
    }

    /// <summary>Should serialize the item prefered height.</summary>
    /// <returns></returns>
    private bool ShouldSerializePreferedItemHeight() => this.Type == ListViewColumnType.Control && this.mintPreferedItemHeight > 0;

    /// <summary>Gets or sets the text alignment.</summary>
    /// <value></value>
    [Browsable(true)]
    [DefaultValue(HorizontalAlignment.Left)]
    public HorizontalAlignment TextAlign
    {
      get => this.menmTextAlign;
      set => this.menmTextAlign = value;
    }

    /// <summary>Gets or sets the column header alignment.</summary>
    /// <value></value>
    [Browsable(true)]
    [DefaultValue(ExtendedHorizontalAlignment.Inherit)]
    public ExtendedHorizontalAlignment ContentAlign
    {
      get => this.menmContentAlignment;
      set
      {
        if (this.menmContentAlignment == value)
          return;
        if (this.InternalParent != null)
          this.InternalParent.Update();
        this.menmContentAlignment = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal bool IsValidColumn => this.Visible && this.Loaded;

    /// <summary>Gets or sets the sort order.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SortOrder SortOrder
    {
      get => this.menmSortOrder;
      set => this.menmSortOrder = value;
    }

    /// <summary>Gets or sets the sort position.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SortPosition
    {
      get => this.mintSortPosition;
      set => this.mintSortPosition = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to group by column.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if group by column; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool GroupBy
    {
      get => this.mblnGroupBy;
      set => this.mblnGroupBy = value;
    }

    /// <summary>Gets or sets the group by position.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int GroupByPosition
    {
      get => this.mintGroupByPosition;
      set => this.mintGroupByPosition = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objObject"></param>
    public int CompareTo(object objObject)
    {
      if (!(objObject is ColumnHeader columnHeader))
        return 0;
      return columnHeader.DisplayIndex >= this.DisplayIndex ? -1 : 1;
    }
  }
}
