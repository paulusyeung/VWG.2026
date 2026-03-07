// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ComboBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a Gizmox.WebGUI.Forms combo box control.</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ComboBox), "ComboBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ComboBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ComboBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DefaultEvent("SelectedIndexChanged")]
  [SRDescription("DescriptionComboBox")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("CB")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ComboBoxSkin))]
  [Serializable]
  public class ComboBox : ListControl
  {
    /// <summary>
    /// Provides a property reference to CharacterCasing property.
    /// </summary>
    private static SerializableProperty CharacterCasingProperty = SerializableProperty.Register(nameof (CharacterCasing), typeof (CharacterCasing), typeof (ComboBox), new SerializablePropertyMetadata((object) CharacterCasing.Normal));
    /// <summary>The mintDropDownWidth property registration.</summary>
    private static readonly SerializableProperty DropDownWidthProperty = SerializableProperty.Register(nameof (DropDownWidth), typeof (int), typeof (ComboBox), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to SelectionLength property.
    /// </summary>
    private static readonly SerializableProperty SelectionLengthProperty = SerializableProperty.Register(nameof (SelectionLength), typeof (int), typeof (ComboBox), new SerializablePropertyMetadata((object) 0));
    /// <summary>
    /// Provides a property reference to SelectionStart property.
    /// </summary>
    private static readonly SerializableProperty SelectionStartProperty = SerializableProperty.Register(nameof (SelectionStart), typeof (int), typeof (ComboBox), new SerializablePropertyMetadata((object) 0));
    /// <summary>The mblnSorted property registration.</summary>
    private static readonly SerializableProperty SortedProperty = SerializableProperty.Register(nameof (Sorted), typeof (bool), typeof (ComboBox), new SerializablePropertyMetadata((object) false));
    /// <summary>The mintSelectedIndex property registration.</summary>
    private static readonly SerializableProperty SelectedIndexProperty = SerializableProperty.Register(nameof (SelectedIndex), typeof (int), typeof (ComboBox), new SerializablePropertyMetadata((object) -1));
    /// <summary>The menmDropDownStyle property registration.</summary>
    private static readonly SerializableProperty DropDownStyleProperty = SerializableProperty.Register(nameof (DropDownStyle), typeof (ComboBoxStyle), typeof (ComboBox), new SerializablePropertyMetadata((object) ComboBoxStyle.DropDown));
    /// <summary>The menmAutoCompleteMode property registration.</summary>
    private static readonly SerializableProperty AutoCompleteModeProperty = SerializableProperty.Register(nameof (AutoCompleteMode), typeof (AutoCompleteMode), typeof (ComboBox), new SerializablePropertyMetadata((object) AutoCompleteMode.None));
    /// <summary>The menmAutoCompleteSource property registration.</summary>
    private static readonly SerializableProperty AutoCompleteSourceProperty = SerializableProperty.Register(nameof (AutoCompleteSource), typeof (AutoCompleteSource), typeof (ComboBox), new SerializablePropertyMetadata((object) AutoCompleteSource.None));
    /// <summary>The CodeMember property registration.</summary>
    private static readonly SerializableProperty CodeMemberProperty = SerializableProperty.Register(nameof (CodeMember), typeof (string), typeof (ComboBox), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>The mintMaxItems property registration.</summary>
    private static readonly SerializableProperty MaxItemsProperty = SerializableProperty.Register("MaxItems", typeof (int), typeof (ComboBox), new SerializablePropertyMetadata((object) 8));
    /// <summary>The SelectedIndexChangedQueued event registration.</summary>
    private static readonly SerializableEvent SelectedIndexChangedQueuedEvent = SerializableEvent.Register("SelectedIndexChangedQueued", typeof (EventHandler), typeof (ComboBox));
    /// <summary>The SelectedIndexChanged event registration.</summary>
    private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof (EventHandler), typeof (ComboBox));
    /// <summary>The SelectionChangeCommitted event registration.</summary>
    private static readonly SerializableEvent SelectionChangeCommittedEvent = SerializableEvent.Register("SelectionChangeCommitted", typeof (EventHandler), typeof (ComboBox));
    /// <summary>The IntegralHeight property registration.</summary>
    private static readonly SerializableProperty IntegralHeightProperty = SerializableProperty.Register(nameof (IntegralHeight), typeof (bool), typeof (ComboBox), new SerializablePropertyMetadata((object) true));
    /// <summary>The SelectedText property registration.</summary>
    private static readonly SerializableProperty SelectedTextProperty = SerializableProperty.Register(nameof (SelectedText), typeof (string), typeof (ComboBox));
    /// <summary>The MaxBindedDropDownItems property registration.</summary>
    private static readonly SerializableProperty MaxBoundDropDownItemsProperty = SerializableProperty.Register("MaxBindedDropDownItems", typeof (int), typeof (ComboBox), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// 
    /// </summary>
    private static SerializableProperty IsAutoCompleteProperty = SerializableProperty.Register(nameof (IsAutoComplete), typeof (bool), typeof (ComboBox), new SerializablePropertyMetadata((object) true));
    /// <summary>The dropped down property</summary>
    private static readonly SerializableProperty DroppedDownProperty = SerializableProperty.Register(nameof (DroppedDown), typeof (bool), typeof (ComboBox), new SerializablePropertyMetadata((object) false));
    /// <summary>The drop down event</summary>
    private static readonly SerializableEvent DropDownEvent = SerializableEvent.Register("DropDown", typeof (EventHandler), typeof (ComboBox));
    /// <summary>The drop down closed event</summary>
    private static readonly SerializableEvent DropDownClosedEvent = SerializableEvent.Register("DropDownClosed", typeof (EventHandler), typeof (ComboBox));
    /// <summary>The list box item collection</summary>
    [NonSerialized]
    private ComboBox.ObjectCollection mobjItems;

    /// <summary>Occurs when [selection change committed].</summary>
    [SRCategory("CatBehavior")]
    [SRDescription("selectionChangeCommittedEventDescr")]
    public event EventHandler SelectionChangeCommitted
    {
      add => this.AddCriticalHandler(ComboBox.SelectionChangeCommittedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ComboBox.SelectionChangeCommittedEvent, (Delegate) value);
    }

    /// <summary>Gets the selection change committed handler.</summary>
    private EventHandler SelectionChangeCommittedHandler => (EventHandler) this.GetHandler(ComboBox.SelectionChangeCommittedEvent);

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox.SelectedIndex"></see> property has changed.
    /// </summary>
    [SRDescription("selectedIndexChangedEventDescr")]
    [SRCategory("CatBehavior")]
    public event EventHandler SelectedIndexChanged
    {
      add => this.AddCriticalHandler(ComboBox.SelectedIndexChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ComboBox.SelectedIndexChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox"></see> value has changed.
    /// </summary>
    [SRDescription("Occurs in client mode when the control selected index is changing.")]
    [Category("Client")]
    public event ClientEventHandler ClientSelectedIndexChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Occurs when [client text changed].</summary>
    [SRDescription("Occurs in client mode when the control text has been changed.")]
    [Category("Client")]
    public event ClientEventHandler ClientTextChanged
    {
      add => this.AddClientHandler("TextChange", value);
      remove => this.RemoveClientHandler("TextChange", value);
    }

    /// <summary>Occurs when [client text changed].</summary>
    [SRDescription("Occurs when DropDown window displayed in Client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientDropDown
    {
      add => this.AddClientHandler("DropDownWindow", value);
      remove => this.RemoveClientHandler("DropDownWindow", value);
    }

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ComboBox.SelectedItem"></see> property has changed.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler SelectedItemChanged
    {
      add => this.SelectedIndexChanged += value;
      remove => this.SelectedIndexChanged -= value;
    }

    /// <summary>Gets the hanlder for the SelectedIndexChanged event.</summary>
    private EventHandler SelectedIndexChangedHandler => (EventHandler) this.GetHandler(ComboBox.SelectedIndexChangedEvent);

    /// <summary>Gets or sets the number of characters selected in the editable portion of the combo box.</summary>
    /// <returns>The number of characters selected in the combo box.</returns>
    /// <exception cref="T:System.ArgumentException">The value was less than zero. </exception>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("TextBoxSelectionLengthDescr")]
    [SRCategory("CatAppearance")]
    [Browsable(false)]
    public virtual int SelectionLength
    {
      get => this.GetValue<int>(ComboBox.SelectionLengthProperty);
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (SelectionLength), SR.GetString("InvalidArgument", (object) nameof (SelectionLength), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(ComboBox.SelectionLengthProperty, value))
          return;
        this.InvokeSelection(this.SelectionStart, value);
      }
    }

    /// <summary>Gets or sets the starting index of text selected in the combo box.</summary>
    /// <returns>The zero-based index of the first character in the string of the current text selection.</returns>
    /// <exception cref="T:System.ArgumentException">The value is less than zero. </exception>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatAppearance")]
    [SRDescription("TextBoxSelectionStartDescr")]
    public int SelectionStart
    {
      get => this.GetValue<int>(ComboBox.SelectionStartProperty);
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (SelectionStart), SR.GetString("InvalidArgument", (object) nameof (SelectionStart), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(ComboBox.SelectionStartProperty, value))
          return;
        this.InvokeSelection(value, this.SelectionLength);
      }
    }

    /// <summary>
    /// Occurs when the SelectedIndex property has changed (Queued).
    /// </summary>
    public event EventHandler SelectedIndexChangedQueued
    {
      add => this.AddHandler(ComboBox.SelectedIndexChangedQueuedEvent, (Delegate) value);
      remove => this.RemoveHandler(ComboBox.SelectedIndexChangedQueuedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the SelectedIndexChangedQueued event.
    /// </summary>
    private EventHandler SelectedIndexChangedQueuedHandler => (EventHandler) this.GetHandler(ComboBox.SelectedIndexChangedQueuedEvent);

    /// <summary>Occurs when [drop down].</summary>
    [SRDescription("ComboBoxOnDropDownDescr")]
    [SRCategory("CatBehavior")]
    public event EventHandler DropDown
    {
      add => this.AddCriticalHandler(ComboBox.DropDownEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ComboBox.DropDownEvent, (Delegate) value);
    }

    /// <summary>Gets the drop down handler.</summary>
    /// <value>The drop down handler.</value>
    private EventHandler DropDownHandler => (EventHandler) this.GetHandler(ComboBox.DropDownEvent);

    /// <summary>Occurs when [drop down closed].</summary>
    [SRCategory("CatBehavior")]
    [SRDescription("ComboBoxOnDropDownClosedDescr")]
    public event EventHandler DropDownClosed
    {
      add => this.AddCriticalHandler(ComboBox.DropDownClosedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ComboBox.DropDownClosedEvent, (Delegate) value);
    }

    /// <summary>Gets the drop down closed handler.</summary>
    /// <value>The drop down closed handler.</value>
    private EventHandler DropDownClosedHandler => (EventHandler) this.GetHandler(ComboBox.DropDownClosedEvent);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> class.
    /// </summary>
    public ComboBox()
    {
      this.mobjItems = this.CreateItemCollection();
      this.SetStyle(ControlStyles.StandardClick | ControlStyles.UserPaint | ControlStyles.UseTextForAccessibility, false);
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjItems);

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mobjItems = this.CreateItemCollection();
      this.mobjItems.SetItemsInternal(objReader.ReadArray());
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteArray((ICollection) this.mobjItems);
    }

    /// <summary>Renders the current control.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      string codeMember = this.CodeMember;
      bool blnUseCode = !string.IsNullOrEmpty(codeMember);
      bool blnShouldRenderItemImage = this.ShouldRenderImage();
      bool blnShouldRenderItemColor = this.ShouldRenderColor();
      bool blnUseIndexCode = codeMember == "#Index";
      PropertyInfo objUseCodeProp = (PropertyInfo) null;
      if (blnUseCode && !blnUseIndexCode && this.mobjItems.Count > 0)
      {
        objUseCodeProp = this.mobjItems[0].GetType().GetProperty(this.CodeMember);
        if (objUseCodeProp == (PropertyInfo) null)
          blnUseCode = false;
      }
      objWriter.WriteStartElement("OS");
      this.RenderAnimationAttributes((IAttributeWriter) objWriter);
      this.RenderOptions(objWriter, blnUseCode, blnShouldRenderItemImage, blnShouldRenderItemColor, blnUseIndexCode, objUseCodeProp);
      objWriter.WriteEndElement();
    }

    /// <summary>Renders the options.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnUseCode">if set to <c>true</c> [BLN use code].</param>
    /// <param name="blnShouldRenderItemImage">if set to <c>true</c> [BLN should render item image].</param>
    /// <param name="blnShouldRenderItemColor">if set to <c>true</c> [BLN should render item color].</param>
    /// <param name="blnUseIndexCode">if set to <c>true</c> [BLN use index code].</param>
    /// <param name="objUseCodeProp">The obj use code prop.</param>
    protected virtual void RenderOptions(
      IResponseWriter objWriter,
      bool blnUseCode,
      bool blnShouldRenderItemImage,
      bool blnShouldRenderItemColor,
      bool blnUseIndexCode,
      PropertyInfo objUseCodeProp)
    {
      for (int intIndex = 0; intIndex < this.mobjItems.Count; ++intIndex)
      {
        objWriter.WriteStartElement("O");
        objWriter.WriteAttributeString("IX", intIndex.ToString());
        if (blnUseCode)
        {
          if (blnUseIndexCode)
            objWriter.WriteAttributeString("CD", intIndex.ToString());
          else
            objWriter.WriteAttributeString("CD", objUseCodeProp.GetValue(this.mobjItems[intIndex], (object[]) null) as string);
        }
        object mobjItem = this.mobjItems[intIndex];
        if (mobjItem == null)
        {
          objWriter.WriteAttributeString("TX", string.Empty);
        }
        else
        {
          this.RenderItemIdAttribute(objWriter, mobjItem);
          objWriter.WriteAttributeText("TX", this.GetItemText(mobjItem), TextFilter.NewLine | TextFilter.CarriageReturn);
          this.RenderColorAndImageAttribute(objWriter, blnShouldRenderItemImage, blnShouldRenderItemColor, mobjItem);
        }
        objWriter.WriteEndElement();
      }
    }

    /// <summary>Writes the color attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="strColor">Color of the STR.</param>
    protected override void WriteColorAttribute(IResponseWriter objWriter, string strColor) => objWriter.WriteAttributeString("CO", string.Format("background:{0};", (object) strColor));

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.IsCustomDropDown)
        objWriter.WriteAttributeString("CDD", "1");
      switch (this.DropDownStyle)
      {
        case ComboBoxStyle.Simple:
          objWriter.WriteAttributeString("S", "S");
          break;
        case ComboBoxStyle.DropDown:
          objWriter.WriteAttributeString("S", "DD");
          break;
        case ComboBoxStyle.DropDownList:
          objWriter.WriteAttributeString("S", "DDL");
          break;
      }
      int num = this.GetValue<int>(ComboBox.DropDownWidthProperty);
      if (num != -1)
        objWriter.WriteAttributeString("DDW", num.ToString());
      switch (this.AutoCompleteMode)
      {
        case AutoCompleteMode.None:
          objWriter.WriteAttributeString("ACM", "N");
          break;
        case AutoCompleteMode.Suggest:
          objWriter.WriteAttributeString("ACM", "S");
          break;
        case AutoCompleteMode.Append:
          objWriter.WriteAttributeString("ACM", "A");
          break;
        case AutoCompleteMode.SuggestAppend:
          objWriter.WriteAttributeString("ACM", "SA");
          break;
      }
      this.RenderValue(objWriter);
      this.RenderText(objWriter);
      this.RenderItemDefinitions(objWriter);
      objWriter.WriteAttributeString("PUOH", this.GetPopupOffsetHeight());
      if (this.ShouldRenderColor())
        objWriter.WriteAttributeString("SHC", "1");
      if (this.ShouldRenderImage())
        objWriter.WriteAttributeString("SHI", "1");
      this.RenderCharacterCasingAttribute(objWriter, false);
      this.RenderIsAutoCompleteAttribute(objWriter, false);
    }

    /// <summary>Renders the is auto complete attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderIsAutoCompleteAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool isAutoComplete = this.IsAutoComplete;
      if (!(!isAutoComplete | blnForceRender))
        return;
      objWriter.WriteAttributeString("IAC", isAutoComplete ? "1" : "0");
    }

    /// <summary>Renders the character casing attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderCharacterCasingAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      CharacterCasing characterCasing = this.CharacterCasing;
      if (!(characterCasing != 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("CC", ((byte) characterCasing).ToString());
    }

    /// <summary>Render the text attrbute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected virtual void RenderText(IAttributeWriter objWriter) => objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);

    /// <summary>Renders the value.</summary>
    /// <param name="objWriter">The writer.</param>
    protected virtual void RenderValue(IAttributeWriter objWriter) => objWriter.WriteAttributeString("VLB", this.SelectedIndex.ToString());

    /// <summary>Renders the item definitions.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderItemDefinitions(IAttributeWriter objWriter)
    {
      int preferdItemHeight = this.GetPreferdItemHeight();
      int num1;
      if (this.DropDownStyle == ComboBoxStyle.Simple)
      {
        int num2 = 17;
        if (this.Skin is ComboBoxSkin skin)
          num2 = skin.SimpleComboBoxInputHeight;
        num1 = (this.Height - num2) / preferdItemHeight;
      }
      else
        num1 = Math.Min(this.MaxDropDownItems, this.Items.Count);
      objWriter.WriteAttributeString("MAX", num1.ToString());
      objWriter.WriteAttributeString("IMH", preferdItemHeight);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        this.RenderText(objWriter);
        this.RenderValue(objWriter);
        this.RenderIsAutoCompleteAttribute(objWriter, true);
      }
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
        this.RenderItemDefinitions(objWriter);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderCharacterCasingAttribute(objWriter, true);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      bool result = false;
      bool.TryParse(objEvent["UpdateDroppedDownOnly"], out result);
      switch (objEvent.Type)
      {
        case "ValueChange":
          int objValue = int.Parse(objEvent["VLB"]);
          if (objValue > -1 && (this.SetValue<int>(ComboBox.SelectedIndexProperty, objValue) || this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick))
          {
            this.OnSelectionChangeCommitted(EventArgs.Empty);
            this.UpdateText();
            this.OnSelectedIndexChanged(EventArgs.Empty);
            break;
          }
          break;
        case "TextChange":
          string strValue = CommonUtils.DecodeText(objEvent["VLB"]);
          if (strValue == string.Empty)
            strValue = (string) null;
          this.InternalText = strValue;
          int stringExact = this.FindStringExact(strValue);
          this.SetValue<int>(ComboBox.SelectedIndexProperty, stringExact);
          break;
        case "DropDownWindow":
          if (this.DropDownHandler != null)
            this.OnDropDown(EventArgs.Empty);
          this.DroppedDownInternal = true;
          Form customDropDown = this.GetCustomDropDown();
          if (customDropDown != null)
          {
            customDropDown.Closed += new EventHandler(this.CustomDropDown_Closed);
            int num = (int) customDropDown.ShowPopup(this.Form, (IRegisteredComponent) this, DialogAlignment.Below);
            break;
          }
          break;
        case "DropDown":
          if (!result)
            this.OpenDropDownPopup();
          this.DroppedDownInternal = true;
          break;
        case "DropDownClosed":
          this.DroppedDownInternal = false;
          if (!result)
          {
            this.OnDropDownClosed(EventArgs.Empty);
            break;
          }
          break;
      }
      base.FireEvent(objEvent);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.SelectedValueChangedHandler != null || this.SelectedIndexChangedHandler != null || this.SelectionChangeCommittedHandler != null || this.IsPostBackRequired)
        criticalEventsData.Set("VC");
      if (this.DropDownHandler != null)
        criticalEventsData.Set("CBDD");
      if (this.DropDownClosedHandler != null)
        criticalEventsData.Set("CBDDC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("ValueChange"))
        clientEventsData.Set("VC");
      return clientEventsData;
    }

    /// <summary>Gets the key event captures.</summary>
    /// <returns></returns>
    protected override KeyCaptures GetKeyEventCaptures() => base.GetKeyEventCaptures() | KeyCaptures.UpKeyCapture | KeyCaptures.DownKeyCapture | KeyCaptures.EndKeyCapture | KeyCaptures.HomeKeyCapture | KeyCaptures.EscKeyCapture | KeyCaptures.PageDownKeyCapture | KeyCaptures.PageUpKeyCapture;

    /// <summary>
    /// Raises the <see cref="E:SelectionChangeCommitted" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnSelectionChangeCommitted(EventArgs e)
    {
      EventHandler committedHandler = this.SelectionChangeCommittedHandler;
      if (committedHandler == null)
        return;
      committedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:SelectedIndexChanged" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnSelectedIndexChanged(EventArgs objEventArgs)
    {
      base.OnSelectedIndexChanged(objEventArgs);
      this.OnSelectedIndexChangedQueued(objEventArgs);
      EventHandler indexChangedHandler = this.SelectedIndexChangedHandler;
      if (indexChangedHandler != null)
        indexChangedHandler((object) this, objEventArgs);
      CurrencyManager dataManager = this.DataManager;
      int selectedIndex = this.SelectedIndex;
      if (dataManager == null || dataManager.Position == selectedIndex || this.FormattingEnabled && selectedIndex == -1)
        return;
      dataManager.Position = selectedIndex;
    }

    /// <summary>Raises the OnSelectedIndexChangedQueued event</summary>
    /// <param name="objEventArgs"></param>
    protected virtual void OnSelectedIndexChangedQueued(EventArgs objEventArgs)
    {
      EventHandler changedQueuedHandler = this.SelectedIndexChangedQueuedHandler;
      if (changedQueuedHandler == null)
        return;
      changedQueuedHandler((object) this, objEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnDataSourceChanged(EventArgs e)
    {
      bool sorted = this.Sorted;
      object dataSource = this.DataSource;
      if (sorted && dataSource != null)
      {
        this.DataSource = (object) null;
        throw new InvalidOperationException(SR.GetString("ComboBoxDataSourceWithSort"));
      }
      if (dataSource == null)
      {
        this.SelectedIndex = -1;
        this.Items.ClearInternal();
      }
      if (!sorted)
        base.OnDataSourceChanged(e);
      this.RefreshItems();
    }

    /// <summary>
    /// Raises the <see cref="E:DropDown" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnDropDown(EventArgs objEventArgs)
    {
      EventHandler dropDownHandler = this.DropDownHandler;
      if (dropDownHandler == null)
        return;
      dropDownHandler((object) this, objEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:DropDownClosed" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnDropDownClosed(EventArgs objEventArgs)
    {
      EventHandler downClosedHandler = this.DropDownClosedHandler;
      if (downClosedHandler == null)
        return;
      downClosedHandler((object) this, objEventArgs);
    }

    /// <summary>
    /// Handles the Closed event of the CustomDropDown control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void CustomDropDown_Closed(object sender, EventArgs e)
    {
      if (sender is Form)
        ((Form) sender).Closed -= new EventHandler(this.CustomDropDown_Closed);
      this.DroppedDownInternal = false;
      this.OnDropDownClosed(EventArgs.Empty);
    }

    /// <summary>Updates the text according to selected index.</summary>
    /// <returns>Return boolean that indicates if text has been changed.</returns>
    private bool UpdateText()
    {
      bool flag = false;
      string str = string.Empty;
      if (this.SelectedIndex != -1)
      {
        object objItem = this.Items[this.SelectedIndex];
        if (objItem != null)
          str = this.GetItemText(objItem);
      }
      if (this.Text != str)
      {
        this.InternalText = str;
        flag = true;
      }
      return flag;
    }

    /// <summary>Gets the popup height offset.</summary>
    /// <returns></returns>
    private double GetPopupOffsetHeight() => this.Skin is ComboBoxSkin skin ? (double) skin.PopupWindowOffsetHeight : 0.0;

    /// <summary>Gets the height of the preferd item font.</summary>
    /// <returns></returns>
    internal int GetPreferdItemHeight()
    {
      if (!(this.Skin is ComboBoxSkin skin))
        return 0;
      PaddingValue padding = skin.PopupItemStyle.Padding;
      int val2_1 = 0;
      if (this.ShouldRenderColor())
        val2_1 = skin.ColorBoxHeight;
      int val1 = 0;
      if (this.ShouldRenderImage())
        val1 = skin.ImageBoxHeight;
      int num = 0;
      if (padding != null)
        num = padding.Top + padding.Bottom;
      int val2_2 = Math.Max(CommonUtils.GetFontHeight(this.Font), val2_1);
      return Math.Max(val1, val2_2) + num;
    }

    /// <summary>Creates the item collection.</summary>
    protected virtual ComboBox.ObjectCollection CreateItemCollection() => new ComboBox.ObjectCollection(this);

    /// <summary>When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
    /// <param name="intIndex">The zero-based index of the item whose data to refresh. </param>
    protected override void RefreshItem(int intIndex) => this.Update();

    /// <summary>When overridden in a derived class, sets the specified array of objects in a collection in the derived class.</summary>
    /// <param name="objItems">An array of items.</param>
    protected override void SetItemsCore(IList objItems)
    {
      this.Items.ClearInternal();
      if (objItems == null)
        return;
      object[] objArray = new object[objItems.Count];
      objItems.CopyTo((Array) objArray, 0);
      if (this.MaxBoundDropDownItems != -1 && objItems.Count > this.MaxBoundDropDownItems)
      {
        object[] sourceArray = new object[objItems.Count];
        objItems.CopyTo((Array) sourceArray, 0);
        objArray = new object[this.MaxBoundDropDownItems];
        Array.Copy((Array) sourceArray, (Array) objArray, this.MaxBoundDropDownItems);
      }
      this.Items.AddRangeInternal(objArray);
    }

    /// <summary>
    /// When overridden in a derived class, sets the object with the specified index in the derived class.
    /// </summary>
    /// <param name="intIndex">The array index of the object.</param>
    /// <param name="objValue">The object.</param>
    protected override void SetItemCore(int intIndex, object objValue) => this.Items.SetItemInternal(intIndex, objValue);

    /// <summary>Resets the width of the drop down.</summary>
    internal void ResetDropDownWidth() => this.RemoveValue<int>(ComboBox.DropDownWidthProperty);

    /// <summary>Shoulds the width of the serialize drop down.</summary>
    /// <returns></returns>
    internal bool ShouldSerializeDropDownWidth() => this.ContainsValue<int>(ComboBox.DropDownWidthProperty);

    /// <summary>Finds the item in the ListBox that has this code.</summary>
    /// <param name="strCode">The STR code.</param>
    /// <returns></returns>
    public int FindCode(string strCode)
    {
      string codeMember = this.CodeMember;
      if (!string.IsNullOrEmpty(codeMember))
      {
        int code = 0;
        bool flag = codeMember == "#Index";
        PropertyInfo propertyInfo = (PropertyInfo) null;
        if (this.mobjItems.Count > 0)
          propertyInfo = this.mobjItems[0].GetType().GetProperty(codeMember);
        foreach (object mobjItem in this.mobjItems)
        {
          if (flag)
          {
            if (code.ToString() == strCode)
              return code;
          }
          else if (propertyInfo != (PropertyInfo) null && propertyInfo.GetValue(mobjItem, (object[]) null) as string == strCode)
            return code;
          ++code;
        }
      }
      return -1;
    }

    /// <summary>Finds the first item in the combo box that starts with the specified string.</summary>
    /// <returns>The zero-based index of the first item found; returns -1 if no match is found.</returns>
    /// <param name="strFindValue">The <see cref="T:System.String"></see> to search for. </param>
    /// <filterpriority>1</filterpriority>
    public int FindString(string strFindValue) => this.FindString(strFindValue, -1);

    /// <summary>Finds the first item after the given index which starts with the given string. The search is not case sensitive.</summary>
    /// <returns>The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
    /// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
    /// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex is less than -1.-or- The startIndex is greater than the last index in the collection. </exception>
    /// <filterpriority>1</filterpriority>
    public int FindString(string strValue, int intStartIndex)
    {
      if (strValue == null || this.Items == null || this.Items.Count == 0)
        return -1;
      if (intStartIndex < -1 || intStartIndex >= this.Items.Count)
        throw new ArgumentOutOfRangeException("startIndex");
      return this.FindStringInternal(strValue, (IList) this.Items, intStartIndex, false);
    }

    /// <summary>Finds the first item in the combo box that matches the specified string.</summary>
    /// <returns>The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
    /// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
    /// <filterpriority>1</filterpriority>
    public int FindStringExact(string strValue) => this.FindStringExact(strValue, -1, true);

    /// <summary>Finds the first item after the specified index that matches the specified string.</summary>
    /// <returns>The zero-based index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies <see cref="F:System.String.Empty"></see>.</returns>
    /// <param name="strValue">The <see cref="T:System.String"></see> to search for. </param>
    /// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex is less than -1.-or- The startIndex is equal to the last index in the collection. </exception>
    /// <filterpriority>1</filterpriority>
    public int FindStringExact(string strValue, int intStartIndex) => this.FindStringExact(strValue, intStartIndex, true);

    /// <summary>Finds the string exact.</summary>
    /// <param name="strValue">The string.</param>
    /// <param name="intStartIndex">The start index.</param>
    /// <param name="blnIgnoreCase">if set to <c>true</c> should ignorecase.</param>
    /// <returns></returns>
    internal int FindStringExact(string strValue, int intStartIndex, bool blnIgnoreCase)
    {
      if (strValue == null || this.Items == null || this.Items.Count == 0)
        return -1;
      if (intStartIndex < -1 || intStartIndex >= this.Items.Count)
        throw new ArgumentOutOfRangeException("startIndex");
      return this.FindStringInternal(strValue, (IList) this.Items, intStartIndex, true, blnIgnoreCase);
    }

    /// <summary>Finds the string and ignores case.</summary>
    /// <param name="strValue">The value.</param>
    /// <returns></returns>
    internal int FindStringIgnoreCase(string strValue)
    {
      int stringExact = this.FindStringExact(strValue, -1, false);
      if (stringExact == -1)
        stringExact = this.FindStringExact(strValue, -1, true);
      return stringExact;
    }

    /// <summary>
    /// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> control.
    /// </summary>
    /// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>. The string includes the type and the number of items in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> control.</returns>
    public override string ToString() => base.ToString() + ", Items.Count: " + (this.mobjItems == null ? 0.ToString() : this.mobjItems.Count.ToString());

    /// <summary>Refreshes all <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> items.</summary>
    protected override void RefreshItems()
    {
      int selectedIndex = this.SelectedIndex;
      ComboBox.ObjectCollection mobjItems = this.mobjItems;
      this.mobjItems = this.CreateItemCollection();
      object[] objArray = (object[]) null;
      if (this.DataManager != null && this.DataManager.Count != -1)
      {
        int val2 = this.DataManager.Count;
        if (this.MaxBoundDropDownItems != -1)
          val2 = Math.Min(this.MaxBoundDropDownItems, val2);
        objArray = new object[val2];
        for (int index = 0; index < val2; ++index)
        {
          if (this.DataManager[index] != null)
            objArray[index] = this.DataManager[index];
        }
      }
      else if (mobjItems != null)
      {
        objArray = new object[mobjItems.Count];
        mobjItems.CopyTo((Array) objArray, 0);
      }
      if (objArray != null)
        this.Items.AddRangeInternal(objArray);
      if (this.DataManager != null)
        this.SelectedIndex = this.DataManager.Position;
      else
        this.SelectedIndex = selectedIndex;
    }

    /// <summary>Operated on this instance after clear items action</summary>
    internal void Clear()
    {
      this.RemoveValue<int>(ComboBox.SelectedIndexProperty);
      if (this.DropDownStyle != ComboBoxStyle.DropDownList)
        return;
      this.UpdateText();
    }

    /// <summary>Checks the no data source.</summary>
    private void CheckNoDataSource()
    {
      if (this.DataSource != null)
        throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
    }

    /// <summary>Selects all the text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void SelectAll() => this.Select(0, int.MaxValue);

    /// <summary>Selects a range of text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</summary>
    /// <param name="intStart">The position of the first character in the current text selection within the text box. </param>
    /// <param name="intLength">The number of characters to select. </param>
    /// <exception cref="T:System.ArgumentException">The start is less than zero.-or- start plus length is less than zero. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Select(int intStart, int intLength)
    {
      if (intStart < 0)
        throw new ArgumentOutOfRangeException("start", SR.GetString("InvalidArgument", (object) "start", (object) intStart.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      if (intStart + intLength < 0)
        throw new ArgumentOutOfRangeException("length", SR.GetString("InvalidArgument", (object) "length", (object) intLength.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      this.SetValue<int>(ComboBox.SelectionLengthProperty, intLength);
      this.SetValue<int>(ComboBox.SelectionStartProperty, intStart);
      this.InvokeSelection(intStart, intLength);
    }

    /// <summary>Opens the drop down popup.</summary>
    private void OpenDropDownPopup()
    {
      this.InvokeMethodWithId("ComboBox_InvokeOpenPopup", (object) true);
      if (this.IsCustomDropDown)
        return;
      this.OnDropDown(EventArgs.Empty);
    }

    /// <summary>Closes the drop down popup.</summary>
    private void CloseDropDownPopup() => this.InvokeMethodWithId("ComboBox_InvokeClosePopup", (object) true);

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new ComboBoxRenderer(this);

    /// <summary>
    /// Gets or sets a value indicating whether this instance is auto complete.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is auto complete; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool IsAutoComplete
    {
      get => this.GetValue<bool>(ComboBox.IsAutoCompleteProperty);
      set
      {
        if (!this.SetValue<bool>(ComboBox.IsAutoCompleteProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Indicates if all characters should be left alone or converted to uppercase or lowercase
    /// </summary>
    /// <value></value>
    [SRCategory("CatBehavior")]
    [SRDescription("TextBoxCharacterCasingDescr")]
    [DefaultValue(CharacterCasing.Normal)]
    public virtual CharacterCasing CharacterCasing
    {
      get => this.GetValue<CharacterCasing>(ComboBox.CharacterCasingProperty);
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (CharacterCasing));
        if (!this.SetValue<CharacterCasing>(ComboBox.CharacterCasingProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets a value indicating whether animation is enabled by default.
    /// </summary>
    /// <value><c>true</c> if animation is enabled by default; otherwise, <c>false</c>.</value>
    protected override bool DefaultAnimation => this.AnimationEnabled;

    /// <summary>
    /// Gets a value indicating whether this instance has a custom drop down.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool IsCustomDropDown => false;

    /// <summary>Gets the custom form to display as drop down</summary>
    /// <returns></returns>
    protected virtual Form GetCustomDropDown() => (Form) null;

    /// <summary>
    /// Gets or sets the maximum number of items to be shown in the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
    /// </summary>
    /// <returns>The maximum number of items of in the drop-down portion. The minimum for this property is 1 and the maximum is 100.</returns>
    /// <exception cref="T:System.ArgumentException">The maximum number is set less than one or greater than 100. </exception>
    [DefaultValue(8)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    [SRDescription("ComboBoxMaxDropDownItemsDescr")]
    public int MaxDropDownItems
    {
      get => this.GetValue<int>(ComboBox.MaxItemsProperty);
      set
      {
        if (value < 1 || value > 100)
          throw new ArgumentOutOfRangeException(nameof (MaxDropDownItems), SR.GetString("InvalidBoundArgument", (object) nameof (MaxDropDownItems), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 1.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 100.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(ComboBox.MaxItemsProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the items in the combo box are sorted.
    /// </summary>
    /// <returns>true if the combo box is sorted; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.ArgumentException">An attempt was made to sort a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> that is attached to a data source. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ComboBoxSortedDescr")]
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    public bool Sorted
    {
      get => this.GetValue<bool>(ComboBox.SortedProperty);
      set
      {
        if (!this.SetValue<bool>(ComboBox.SortedProperty, value))
          return;
        this.RefreshItems();
        this.SelectedIndex = -1;
        this.Update();
      }
    }

    /// <summary>Gets or sets the max bound drop down items.</summary>
    /// <value>The max bound drop down items.</value>
    [DefaultValue(-1)]
    [SRCategory("CatData")]
    [SRDescription("Gets or sets a value indicating the maximal number of bound drop down items.")]
    public int MaxBoundDropDownItems
    {
      get => this.GetValue<int>(ComboBox.MaxBoundDropDownItemsProperty);
      set
      {
        if (!this.SetValue<int>(ComboBox.MaxBoundDropDownItemsProperty, value))
          return;
        this.RefreshItems();
        this.Update();
      }
    }

    /// <summary>Gets or sets the auto complete mode.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [DefaultValue(AutoCompleteMode.None)]
    [SRDescription("ComboBoxAutoCompleteModeDescr")]
    public AutoCompleteMode AutoCompleteMode
    {
      get => this.GetValue<AutoCompleteMode>(ComboBox.AutoCompleteModeProperty);
      set
      {
        if (!this.SetValue<AutoCompleteMode>(ComboBox.AutoCompleteModeProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the drop down style.</summary>
    /// <value></value>
    [DefaultValue(ComboBoxStyle.DropDown)]
    public virtual ComboBoxStyle DropDownStyle
    {
      get => this.GetValue<ComboBoxStyle>(ComboBox.DropDownStyleProperty);
      set
      {
        if (!this.SetValue<ComboBoxStyle>(ComboBox.DropDownStyleProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the width of the of the drop-down portion of a combo box.</summary>
    /// <returns>The width, in pixels, of the drop-down box.</returns>
    /// <exception cref="T:System.ArgumentException">The specified value is less than one. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ComboBoxDropDownWidthDescr")]
    [SRCategory("CatBehavior")]
    public int DropDownWidth
    {
      get
      {
        int num = this.GetValue<int>(ComboBox.DropDownWidthProperty);
        return num != -1 ? num : this.Width;
      }
      set
      {
        if (value < 1)
          throw new ArgumentOutOfRangeException(nameof (DropDownWidth), SR.GetString("InvalidArgument", (object) nameof (DropDownWidth), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(ComboBox.DropDownWidthProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the auto-completion source.</summary>
    [DefaultValue(AutoCompleteSource.None)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [SRDescription("ComboBoxAutoCompleteSourceDescr")]
    [Browsable(true)]
    public AutoCompleteSource AutoCompleteSource
    {
      get => this.GetValue<AutoCompleteSource>(ComboBox.AutoCompleteSourceProperty);
      set => this.SetValue<AutoCompleteSource>(ComboBox.AutoCompleteSourceProperty, value);
    }

    /// <summary>
    /// Gets an object representing the collection of the items contained in this <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ComboBox.ObjectCollection Items => this.mobjItems;

    /// <summary>
    /// Gets or sets the index specifying the currently selected item.
    /// </summary>
    /// <returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified index is less than or equal to -2.-or- The specified index is greater than or equal to the number of items in the combo box. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ComboBoxSelectedIndexDescr")]
    public override int SelectedIndex
    {
      get => this.mobjItems.Count > 0 ? this.GetValue<int>(ComboBox.SelectedIndexProperty) : -1;
      set
      {
        int num = 0;
        if (this.mobjItems != null)
          num = this.mobjItems.Count;
        if (value < -1 || value >= num)
          throw new ArgumentOutOfRangeException(nameof (SelectedIndex), SR.GetString("InvalidArgument", (object) nameof (SelectedIndex), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        bool flag;
        if (this.SetValue<int>(ComboBox.SelectedIndexProperty, value))
        {
          this.UpdateText();
          this.OnSelectedIndexChanged(EventArgs.Empty);
          flag = true;
        }
        else
          flag = this.UpdateText();
        if (!flag)
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Override the Control Text.
    /// When the combo control is bound to a BindingSource Text property (a string data member in the DB),
    /// we have to set the combo index to match the text.
    /// </summary>
    public override string Text
    {
      get
      {
        if (this.SelectedItem != null && !this.BindingFieldEmpty)
        {
          if (!this.FormattingEnabled)
            return this.FilterItemOnProperty(this.SelectedItem).ToString();
          string itemText = this.GetItemText(this.SelectedItem);
          if (!string.IsNullOrEmpty(itemText) && string.Compare(itemText, base.Text, true, CultureInfo.CurrentCulture) == 0)
            return itemText;
        }
        return base.Text;
      }
      set
      {
        if (!(this.Text != value))
          return;
        this.InternalText = value;
        this.Update();
      }
    }

    /// <summary>Set text without raising any events</summary>
    /// <value></value>
    internal override string InternalText
    {
      set
      {
        if (this.DropDownStyle == ComboBoxStyle.DropDownList && !string.IsNullOrEmpty(value) && this.FindStringExact(value) == -1)
          return;
        base.InternalText = value;
        object selectedItem = this.SelectedItem;
        if (this.DesignMode)
          return;
        if (value == null)
        {
          this.SetValue<int>(ComboBox.SelectedIndexProperty, -1);
        }
        else
        {
          if (value == null || selectedItem != null && string.Compare(value, this.GetItemText(selectedItem), false, CultureInfo.CurrentCulture) == 0)
            return;
          int stringIgnoreCase = this.FindStringIgnoreCase(value);
          if (stringIgnoreCase == -1 || !this.SetValue<int>(ComboBox.SelectedIndexProperty, stringIgnoreCase))
            return;
          this.OnSelectedIndexChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
    /// </summary>
    /// <returns>The object that is the currently selected item or null if there is no currently selected item.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ComboBoxSelectedItemDescr")]
    [Bindable(true)]
    public object SelectedItem
    {
      get
      {
        if (this.mobjItems.Count == 0)
          return (object) null;
        int selectedIndex = this.SelectedIndex;
        return selectedIndex == -1 ? (object) null : this.mobjItems[selectedIndex];
      }
      set => this.SelectedIndex = this.mobjItems.IndexOf(value);
    }

    /// <summary>Gets or sets the code member.</summary>
    /// <value>The code member.</value>
    [DefaultValue("")]
    public string CodeMember
    {
      get => this.GetValue<string>(ComboBox.CodeMemberProperty);
      set
      {
        if (!this.SetValue<string>(ComboBox.CodeMemberProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>Gets the items comparer object.</summary>
    [Browsable(false)]
    public virtual IComparer ItemsComparer => (IComparer) new ComboBox.ItemComparer(this);

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>
    /// Gets or sets a value indicating whether [integral height].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [integral height]; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IntegralHeight
    {
      get => this.GetValue<bool>(ComboBox.IntegralHeightProperty);
      set => this.SetValue<bool>(ComboBox.IntegralHeightProperty, value);
    }

    /// <summary>Gets or sets a value indicating the currently selected text in the control.</summary>
    /// <returns>A string that represents the currently selected text in the text box.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string SelectedText
    {
      get => this.GetValue<string>(ComboBox.SelectedTextProperty);
      set => this.SetValue<string>(ComboBox.SelectedTextProperty, value);
    }

    /// <summary>Gets or sets the appearance of the <see cref="T:Gizmox.WebGui.Forms.ComboBox"></see>.</summary>
    /// <returns>One of the values of <see cref="T:Gizmox.WebGui.Forms.FlatStyle"></see>. The options are Flat, Popup, Standard, and System. The default is Standard.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:Gizmox.WebGui.Forms.FlatStyle"></see>. </exception>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [DefaultValue(FlatStyle.Standard)]
    [SRDescription("ComboBoxFlatStyleDescr")]
    [SRCategory("CatAppearance")]
    public FlatStyle FlatStyle
    {
      get => FlatStyle.Standard;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [dropped down].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [dropped down]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("ComboBoxDroppedDownDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(true)]
    public bool DroppedDown
    {
      get => this.DroppedDownInternal;
      set
      {
        if (value && this.DropDownStyle != ComboBoxStyle.Simple)
          this.OpenDropDownPopup();
        this.DroppedDownInternal = value;
        if (value || this.DropDownStyle == ComboBoxStyle.Simple)
          return;
        this.CloseDropDownPopup();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [dropped down internal].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [dropped down internal]; otherwise, <c>false</c>.
    /// </value>
    internal bool DroppedDownInternal
    {
      get => this.GetValue<bool>(ComboBox.DroppedDownProperty);
      set => this.SetValue<bool>(ComboBox.DroppedDownProperty, value);
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(121, this.PreferredHeight);

    /// <summary>Gets the height of the preferred.</summary>
    /// <value>The height of the preferred.</value>
    private int PreferredHeight => this.DropDownStyle == ComboBoxStyle.Simple ? this.GetSimpleComboHeight() : this.GetComboHeight();

    /// <summary>Gets the height of the simple combo.</summary>
    /// <returns></returns>
    private int GetSimpleComboHeight()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = this.GetPreferdItemHeight() * 8;
      if (this.Skin is ComboBoxSkin skin)
      {
        int comboBoxInputHeight = skin.SimpleComboBoxInputHeight;
        if (skin.BorderStyle != BorderStyle.None)
          num1 = (int) skin.BorderWidth * 2;
        num2 = skin.Padding.Horizontal;
      }
      int num4 = num2;
      return num3 + num4 + num1;
    }

    /// <summary>Gets the height of the combo.</summary>
    /// <returns></returns>
    private int GetComboHeight()
    {
      int num1 = 0;
      int num2 = 0;
      Size stringMeasurements = CommonUtils.GetStringMeasurements("0", this.Font);
      if (this.Skin is ComboBoxSkin skin)
      {
        if (skin.BorderStyle != BorderStyle.None)
          num1 = (int) skin.BorderWidth * 2;
        num2 = skin.Padding.Horizontal;
      }
      return stringMeasurements.Height + num2 + num1;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private sealed class ItemComparer : IComparer
    {
      private ComboBox mobjComboBox;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ComboBox.ItemComparer" /> class.
      /// </summary>
      /// <param name="objComboBox">The combo box.</param>
      public ItemComparer(ComboBox objComboBox) => this.mobjComboBox = objComboBox;

      /// <summary>Compares the specified item1.</summary>
      /// <param name="objItem1">The obj item1.</param>
      /// <param name="objItem2">The obj item2.</param>
      /// <returns></returns>
      public int Compare(object objItem1, object objItem2) => objItem1 == null ? (objItem2 == null ? 0 : -1) : (objItem2 == null ? 1 : Application.CurrentCulture.CompareInfo.Compare(this.mobjComboBox.GetItemText(objItem1), this.mobjComboBox.GetItemText(objItem2), CompareOptions.StringSort));
    }

    /// <summary>
    /// Represents the collection of items in a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
    /// </summary>
    [ListBindable(false)]
    [Serializable]
    public class ObjectCollection : ICollection, IEnumerable, IList
    {
      /// <summary>The owner tab control</summary>
      private ArrayList mobjList;
      /// <summary>The object collection parent control</summary>
      private ComboBox mobjParent;
      private IComparer mobjComparer;

      /// <summary>
      /// Initializes a new instance of <see cref="T:Gizmox.WebGUI.Forms.ComboBox.ObjectCollection"></see>.
      /// </summary>
      /// <param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> that owns this object collection. </param>
      protected internal ObjectCollection(ComboBox objOwner)
      {
        if (objOwner == null)
          throw new NullReferenceException("ComboBox.ObjectCollection has been initialized with a null owner");
        this.mobjList = new ArrayList();
        this.mobjParent = objOwner;
      }

      /// <summary>
      /// For a description of this member, see <see cref="P:System.Collections.ICollection.IsSynchronized"></see>.
      /// </summary>
      public bool IsSynchronized => this.mobjList.IsSynchronized;

      /// <summary>Gets the number of items in the collection.</summary>
      /// <returns>The number of items in the collection.</returns>
      public int Count => this.mobjList.Count;

      /// <summary>
      /// For a description of this member, see <see cref="M:System.Collections.ICollection.CopyTo(System.Array,System.Int32)"></see>.
      /// </summary>
      /// <param name="objDestination">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
      /// <param name="intIndex">The zero-based index in the array at which copying begins.</param>
      public void CopyTo(Array objDestination, int intIndex) => this.mobjList.CopyTo(objDestination, intIndex);

      /// <summary>Gets the sync root.</summary>
      /// <value></value>
      public object SyncRoot => this.mobjList.SyncRoot;

      /// <summary>
      /// Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
      /// </summary>
      /// <returns>The zero-based index of the item in the collection.</returns>
      /// <param name="objItem">An object representing the item to add to the collection. </param>
      /// <exception cref="T:System.ArgumentNullException">The item parameter was null. </exception>
      public virtual int Add(object objItem)
      {
        this.mobjParent.CheckNoDataSource();
        int num = this.AddInternal(objItem);
        this.mobjParent.Update();
        return num;
      }

      /// <summary>Adds an item with sorting.</summary>
      /// <param name="objItem">The obj item.</param>
      /// <returns></returns>
      private int AddInternal(object objItem)
      {
        if (objItem == null)
          throw new ArgumentNullException("item");
        int index;
        if (!this.mobjParent.Sorted)
        {
          index = this.mobjList.Add(objItem);
        }
        else
        {
          index = this.mobjList.BinarySearch(objItem, this.Comparer);
          if (index < 0)
            index = ~index;
          this.mobjList.Insert(index, objItem);
        }
        return index;
      }

      /// <summary>Gets the comparer.</summary>
      private IComparer Comparer => this.mobjParent.ItemsComparer;

      /// <summary>
      /// Determines if the specified item is located within the collection.
      /// </summary>
      /// <returns>true if the item is located within the collection; otherwise, false.</returns>
      /// <param name="objValue">An object representing the item to locate in the collection. </param>
      public bool Contains(object objValue) => this.mobjList.Contains(objValue);

      /// <summary>
      /// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
      /// </summary>
      /// <param name="arrObjects">An array of objects to add to the list. </param>
      /// <exception cref="T:System.ArgumentNullException">An item in the items parameter was null. </exception>
      public virtual void AddRange(object[] arrObjects) => this.AddRangeInternal(arrObjects);

      /// <summary>Adds the range internal.</summary>
      /// <param name="arrObjects">The objects.</param>
      internal void AddRangeInternal(object[] arrObjects)
      {
        foreach (object arrObject in arrObjects)
          this.AddInternal(arrObject);
        this.mobjParent.Update();
      }

      /// <summary>Adds the range internal.</summary>
      /// <param name="objObjects">The objects.</param>
      internal void AddRangeInternal(ICollection objObjects)
      {
        if (objObjects == null)
          throw new ArgumentNullException(nameof (objObjects));
        foreach (object objObject in (IEnumerable) objObjects)
          this.AddInternal(objObject);
        this.mobjParent.Update();
      }

      /// <summary>Sets the item with a new value.</summary>
      /// <param name="intIndex">The index.</param>
      /// <param name="objValue">The value.</param>
      internal void SetItemInternal(int intIndex, object objValue)
      {
        if (objValue == null)
          throw new ArgumentNullException("value");
        if (intIndex < 0 || intIndex >= this.mobjList.Count)
          throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", (object) "index", (object) intIndex.ToString()));
        this.mobjList[intIndex] = objValue;
        this.mobjParent.Update();
      }

      /// <summary>Adds a range of objects.</summary>
      /// <param name="objObjects">objects.</param>
      public void AddRange(ICollection objObjects)
      {
        if (objObjects == null)
          throw new ArgumentNullException(nameof (objObjects));
        this.mobjParent.CheckNoDataSource();
        this.AddRangeInternal(objObjects);
      }

      /// <summary>
      /// Removes the specified item from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
      /// </summary>
      /// <param name="objValue">The <see cref="T:System.Object"></see> to remove from the list. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection. </exception>
      public void Remove(object objValue)
      {
        this.mobjParent.Update();
        this.mobjList.Remove(objValue);
      }

      /// <summary>
      /// Returns an enumerator that can be used to iterate through the item collection.
      /// </summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
      public IEnumerator GetEnumerator() => this.mobjList.GetEnumerator();

      /// <summary>Clears the collection.</summary>
      internal void ClearInternal()
      {
        this.mobjList.Clear();
        this.mobjParent.Clear();
        this.mobjParent.Update();
      }

      /// <summary>
      /// Removes all items from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
      /// </summary>
      public void Clear()
      {
        this.mobjParent.CheckNoDataSource();
        this.ClearInternal();
      }

      /// <summary>
      /// Retrieves the index within the collection of the specified item.
      /// </summary>
      /// <returns>The zero-based index where the item is located within the collection; otherwise, -1.</returns>
      /// <param name="objValue">An object representing the item to locate in the collection. </param>
      /// <exception cref="T:System.ArgumentNullException">The value parameter was null. </exception>
      public int IndexOf(object objValue) => this.mobjList.IndexOf(objValue);

      /// <summary>
      /// Gets the <see cref="T:System.Object" /> with the specified int index.
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      [Browsable(false)]
      public object this[int intIndex]
      {
        get => this.mobjList[intIndex];
        set
        {
          if (this.mobjList == null || this.mobjList[intIndex] == value)
            return;
          this.mobjList[intIndex] = value;
          this.mobjParent.Update();
        }
      }

      /// <summary>
      /// Provides a way to initialize the collection from serialization
      /// </summary>
      /// <param name="arrItems"></param>
      internal void SetItemsInternal(object[] arrItems) => this.mobjList.AddRange((ICollection) arrItems);

      /// <summary>
      /// Gets a value indicating whether this collection can be modified.
      /// </summary>
      /// <returns>Always false.</returns>
      public bool IsReadOnly => false;

      /// <summary>
      /// Gets or sets the <see cref="T:System.Object" /> at the specified index.
      /// </summary>
      object IList.this[int intIndex]
      {
        get => this.mobjList[intIndex];
        set => this.mobjList[intIndex] = value;
      }

      /// <summary>
      /// Removes an item from the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> at the specified index.
      /// </summary>
      /// <param name="intIndex">The index of the item to remove. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection. </exception>
      public void RemoveAt(int intIndex)
      {
        this.mobjParent.CheckNoDataSource();
        if (intIndex < 0 || intIndex >= this.mobjList.Count)
          throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", (object) "index", (object) intIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        this.mobjParent.SetValue<int>(ComboBox.SelectedIndexProperty, -1);
        this.mobjList.RemoveAt(intIndex);
        this.mobjParent.UpdateText();
        this.mobjParent.UpdateParams(AttributeType.Control);
      }

      /// <summary>
      /// Inserts an item into the collection at the specified index.
      /// </summary>
      /// <returns>The zero-based index of the newly added item.</returns>
      /// <param name="objItem">An object representing the item to insert. </param>
      /// <param name="intIndex">The zero-based index location where the item is inserted. </param>
      /// <exception cref="T:System.ArgumentNullException">The item was null. </exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index was less than zero.-or- The index was greater than the count of items in the collection. </exception>
      public void Insert(int intIndex, object objItem)
      {
        this.mobjParent.CheckNoDataSource();
        this.mobjParent.Update();
        this.mobjList.Insert(intIndex, objItem);
      }

      /// <summary>
      /// For a description of this member, see <see cref="P:System.Collections.IList.IsFixedSize"></see>.
      /// </summary>
      /// <returns>false in all cases.</returns>
      public bool IsFixedSize => false;
    }
  }
}
