// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DomainUpDown
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

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a Windows spin box (also known as an up-down control) that displays string values.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (DomainUpDown), "DomainUpDown_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DefaultProperty("Items")]
  [DefaultEvent("SelectedItemChanged")]
  [SRDescription("DescriptionDomainUpDown")]
  [Gizmox.WebGUI.Forms.MetadataTag("DUD")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DomainUpDownSkin))]
  [Serializable]
  public class DomainUpDown : UpDownBase
  {
    /// <summary>The SelectedItemChanged event registration.</summary>
    private static readonly SerializableEvent SelectedItemChangedEvent = SerializableEvent.Register("SelectedItemChanged", typeof (EventHandler), typeof (DomainUpDown));
    /// <summary>Provides a property reference to Wrap property.</summary>
    private static SerializableProperty WrapProperty = SerializableProperty.Register(nameof (Wrap), typeof (bool), typeof (DomainUpDown), new SerializablePropertyMetadata((object) false));
    /// <summary>The index of the domain.</summary>
    private int mintDomainIndex = -1;
    /// <summary>A flag indicating if items we sorted</summary>
    private bool mblnItemsWhereSorted;
    /// <summary>The domain up down items collection</summary>
    private DomainUpDown.DomainUpDownItemCollection mobjItems;
    /// <summary>The current editing value</summary>
    private string mstrStringValue = string.Empty;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DomainUpDown"></see> class.</summary>
    public DomainUpDown() => this.Text = string.Empty;

    /// <summary>A collection of objects assigned to the spin box (also known as an up-down control).</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.DomainUpDown.DomainUpDownItemCollection"></see> that contains an <see cref="T:System.Object"></see> collection.</returns>
    /// <filterpriority>1</filterpriority>
    [Localizable(true)]
    [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [SRCategory("CatData")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRDescription("DomainUpDownItemsDescr")]
    public DomainUpDown.DomainUpDownItemCollection Items
    {
      get
      {
        if (this.mobjItems == null)
          this.mobjItems = new DomainUpDown.DomainUpDownItemCollection(this);
        return this.mobjItems;
      }
    }

    /// <summary>Gets or sets the spacing between the <see cref="T:System.Windows.Forms.DomainUpDown"></see> control's contents and its edges.</summary>
    /// <returns><see cref="F:System.Windows.Forms.Padding.Empty"></see> in all cases.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>Gets or sets the index value of the selected item.</summary>
    /// <returns>The zero-based index value of the selected item. The default value is -1.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than the default, -1.-or- The assigned value is greater than the <see cref="P:System.Windows.Forms.DomainUpDown.Items"></see> count. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(-1)]
    [SRDescription("DomainUpDownSelectedIndexDescr")]
    [SRCategory("CatAppearance")]
    [Browsable(false)]
    public int SelectedIndex
    {
      get => this.UserEdit ? -1 : this.mintDomainIndex;
      set
      {
        if (value == this.SelectedIndex)
          return;
        this.SelectedIndexInternal = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>The currently selected index</summary>
    private int SelectedIndexInternal
    {
      set
      {
        if (value < -1 || value >= this.Items.Count)
          throw new ArgumentOutOfRangeException("SelectedIndex", SR.GetString("InvalidArgument", (object) "SelectedIndex", (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (value == this.SelectedIndex)
          return;
        this.SelectIndex(value);
      }
    }

    /// <summary>Gets or sets the selected item based on the index value of the selected item in the collection.</summary>
    /// <returns>The selected item based on the <see cref="P:System.Windows.Forms.DomainUpDown.SelectedIndex"></see> value. The default value is null.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("DomainUpDownSelectedItemDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object SelectedItem
    {
      get
      {
        int selectedIndex = this.SelectedIndex;
        return selectedIndex != -1 ? this.Items[selectedIndex] : (object) null;
      }
      set
      {
        if (value == null)
        {
          this.SelectedIndex = -1;
        }
        else
        {
          for (int index = 0; index < this.Items.Count; ++index)
          {
            if (value != null && value.Equals(this.Items[index]))
            {
              this.SelectedIndex = index;
              break;
            }
          }
        }
      }
    }

    /// <summary>Gets the selected item changed handler.</summary>
    /// <value>The selected item changed handler.</value>
    private EventHandler SelectedItemChangedHandler => (EventHandler) this.GetHandler(DomainUpDown.SelectedItemChangedEvent);

    /// <summary>Gets or sets a value indicating whether the item collection is sorted.</summary>
    /// <returns>true if the item collection is sorted; otherwise, false. The default value is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("DomainUpDownSortedDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool Sorted
    {
      get => this.GetState(Control.ControlState.Sorted);
      set
      {
        if (!this.SetStateWithCheck(Control.ControlState.Sorted, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether the collection of items continues to the first or last item if the user continues past the end of the list.</summary>
    /// <returns>true if the list starts again when the user reaches the beginning or end of the collection; otherwise, false. The default value is false.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DomainUpDownWrapDescr")]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    [DefaultValue(false)]
    public bool Wrap
    {
      get => this.GetValue<bool>(DomainUpDown.WrapProperty);
      set
      {
        if (!this.SetValue<bool>(DomainUpDown.WrapProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.DomainUpDown.Padding"></see> property changes.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler PaddingChanged
    {
      add => base.PaddingChanged += value;
      remove => base.PaddingChanged -= value;
    }

    /// <summary>Occurs when the <see cref="P:System.Windows.Forms.DomainUpDown.SelectedItem"></see> property has been changed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("DomainUpDownOnSelectedItemChangedDescr")]
    public event EventHandler SelectedItemChanged
    {
      add => this.AddCriticalHandler(DomainUpDown.SelectedItemChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(DomainUpDown.SelectedItemChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("DomainUpDownOnSelectedItemChangedDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientSelectedItemChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Displays the next item in the object collection.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override void DownButton()
    {
      if (this.Items == null || this.Items.Count <= 0)
        return;
      int index = -1;
      if (this.UserEdit)
        index = this.MatchIndex(this.Text, false, this.mintDomainIndex);
      if (index != -1)
        this.SelectIndex(index);
      else if (this.mintDomainIndex < this.Items.Count - 1)
      {
        this.SelectIndex(this.mintDomainIndex + 1);
      }
      else
      {
        if (!this.Wrap)
          return;
        this.SelectIndex(0);
      }
    }

    /// <summary>Returns a string that represents the <see cref="T:System.Windows.Forms.DomainUpDown"></see> control.</summary>
    /// <returns>A string that represents the current <see cref="T:System.Windows.Forms.DomainUpDown"></see>. </returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      string str = base.ToString();
      if (this.Items != null)
        str = str + ", Items.Count: " + this.Items.Count.ToString((IFormatProvider) CultureInfo.CurrentCulture) + ", SelectedIndex: " + this.SelectedIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      return str;
    }

    /// <summary>Displays the previous item in the collection.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override void UpButton()
    {
      if (this.Items == null || this.Items.Count <= 0 || this.mintDomainIndex == -1)
        return;
      int index = -1;
      if (this.UserEdit)
        index = this.MatchIndex(this.Text, false, this.mintDomainIndex);
      if (index != -1)
        this.SelectIndex(index);
      else if (this.mintDomainIndex > 0)
      {
        this.SelectIndex(this.mintDomainIndex - 1);
      }
      else
      {
        if (!this.Wrap)
          return;
        this.SelectIndex(this.Items.Count - 1);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.SelectedItemChangedHandler != null)
        criticalEventsData.Set("VC");
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

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DomainUpDown.SelectedItemChanged"></see> event.</summary>
    /// <param name="objSource">The source of the event.</param>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnChanged(object objSource, EventArgs e) => this.OnSelectedItemChanged(objSource, e);

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DomainUpDown.SelectedItemChanged"></see> event.</summary>
    /// <param name="objSource">The source of the event. </param>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected void OnSelectedItemChanged(object objSource, EventArgs e)
    {
      EventHandler itemChangedHandler = this.SelectedItemChangedHandler;
      if (itemChangedHandler == null)
        return;
      itemChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event. </summary>
    /// <param name="objSource">The source of the event. </param>
    /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
    protected override void OnTextBoxKeyPress(object objSource, KeyPressEventArgs e)
    {
      if (this.ReadOnly)
      {
        char[] chArray = new char[1]{ e.KeyChar };
        switch (char.GetUnicodeCategory(chArray[0]))
        {
          case UnicodeCategory.UppercaseLetter:
          case UnicodeCategory.LowercaseLetter:
          case UnicodeCategory.OtherLetter:
          case UnicodeCategory.DecimalDigitNumber:
          case UnicodeCategory.LetterNumber:
          case UnicodeCategory.OtherNumber:
          case UnicodeCategory.MathSymbol:
            int index = this.MatchIndex(new string(chArray), false, this.mintDomainIndex + 1);
            if (index != -1)
              this.SelectIndex(index);
            e.Handled = true;
            break;
        }
      }
      base.OnTextBoxKeyPress(objSource, e);
    }

    /// <summary>Renders the specified obj context.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      DomainUpDown.DomainUpDownItemCollection items = this.Items;
      objWriter.WriteStartElement("OS");
      for (int index = 0; index < items.Count; ++index)
      {
        objWriter.WriteStartElement("O");
        this.RenderItemAttributes(objWriter, items[index], index);
        objWriter.WriteEndElement();
      }
      objWriter.WriteEndElement();
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.mintDomainIndex >= 0)
        objWriter.WriteAttributeString("VLB", this.mintDomainIndex.ToString());
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Renders the item attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objItem">The obj item.</param>
    /// <param name="intIndex">Index of the int.</param>
    protected internal virtual void RenderItemAttributes(
      IResponseWriter objWriter,
      object objItem,
      int intIndex)
    {
      objWriter.WriteAttributeString("IX", intIndex.ToString());
      if (objItem == null)
        return;
      objWriter.WriteAttributeText("TX", objItem.ToString(), TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Renders the updated attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      objWriter.WriteAttributeString("VLB", this.mintDomainIndex.ToString());
      objWriter.WriteAttributeText("TX", this.Text.ToString(), TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Sets up down value.</summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="blnIsIndex">if set to <c>true</c> [BLN is index].</param>
    protected override void SetUpDownValue(string strValue, bool blnIsIndex)
    {
      if (string.IsNullOrEmpty(strValue))
        return;
      if (blnIsIndex)
      {
        int int32 = Convert.ToInt32(strValue);
        if (int32 < 0 || int32 >= this.Items.Count)
          return;
        this.SelectedIndexInternal = int32;
      }
      else
        this.SetTextInternal(strValue);
    }

    /// <summary>Updates the text in the spin box (also known as an up-down control) to display the selected item.</summary>
    protected override void UpdateEditText()
    {
      this.UserEdit = false;
      this.ChangingText = true;
      this.Text = this.mstrStringValue;
    }

    /// <summary>Selects the index.</summary>
    /// <param name="index">The index.</param>
    private void SelectIndex(int index)
    {
      if (this.Items == null || index < -1 || index >= this.Items.Count)
      {
        index = -1;
      }
      else
      {
        this.mintDomainIndex = index;
        if (this.mintDomainIndex >= 0)
        {
          this.mstrStringValue = this.Items[this.mintDomainIndex].ToString();
          this.UserEdit = false;
          this.UpdateEditText();
        }
        else
          this.UserEdit = true;
      }
    }

    /// <summary>Sorts the domain items.</summary>
    private void SortDomainItems()
    {
      if (this.mblnItemsWhereSorted)
        return;
      this.mblnItemsWhereSorted = true;
      try
      {
        if (!this.Sorted || this.Items == null)
          return;
        ArrayList.Adapter((IList) this.Items).Sort((IComparer) new DomainUpDown.DomainUpDownItemCompare());
        if (this.UserEdit)
          return;
        int index = this.MatchIndex(this.mstrStringValue, true);
        if (index == -1)
          return;
        this.SelectIndex(index);
      }
      finally
      {
        this.mblnItemsWhereSorted = false;
      }
    }

    /// <summary>Matches the index.</summary>
    /// <param name="strText">The text.</param>
    /// <param name="blnComplete">if set to <c>true</c> [complete].</param>
    /// <returns></returns>
    internal int MatchIndex(string strText, bool blnComplete) => this.MatchIndex(strText, blnComplete, this.mintDomainIndex);

    /// <summary>Matches the index.</summary>
    /// <param name="strText">The text.</param>
    /// <param name="blnComplete">if set to <c>true</c> [complete].</param>
    /// <param name="intStartPosition">The start position.</param>
    /// <returns></returns>
    internal int MatchIndex(string strText, bool blnComplete, int intStartPosition)
    {
      if (this.Items == null || strText.Length < 1 || this.Items.Count <= 0)
        return -1;
      if (intStartPosition < 0)
        intStartPosition = this.Items.Count - 1;
      if (intStartPosition >= this.Items.Count)
        intStartPosition = 0;
      int index = intStartPosition;
      int num = -1;
      if (!blnComplete)
        strText = strText.ToUpper(CultureInfo.InvariantCulture);
      bool flag;
      do
      {
        flag = !blnComplete ? this.Items[index].ToString().ToUpper(CultureInfo.InvariantCulture).StartsWith(strText) : this.Items[index].ToString().Equals(strText);
        if (flag)
          num = index;
        ++index;
        if (index >= this.Items.Count)
          index = 0;
      }
      while (!flag && index != intStartPosition);
      return num;
    }

    /// <summary>Encapsulates a collection of objects for use by the <see cref="T:System.Windows.Forms.DomainUpDown"></see> class.</summary>
    [Serializable]
    public class DomainUpDownItemCollection : ArrayList
    {
      private DomainUpDown mobjOwner;

      internal DomainUpDownItemCollection(DomainUpDown objOwner) => this.mobjOwner = objOwner;

      /// <summary>Adds the specified object to the end of the collection.</summary>
      /// <returns>The zero-based index value of the <see cref="T:System.Object"></see> added to the collection.</returns>
      /// <param name="objItem">The <see cref="T:System.Object"></see> to be added to the end of the collection. </param>
      public override int Add(object objItem)
      {
        int num = base.Add(objItem);
        if (this.mobjOwner.Sorted)
          this.mobjOwner.SortDomainItems();
        this.mobjOwner.Update();
        return num;
      }

      /// <summary>Inserts the specified object into the collection at the specified location.</summary>
      /// <param name="objItem">The <see cref="T:System.Object"></see> to insert. </param>
      /// <param name="index">The indexed location within the collection to insert the <see cref="T:System.Object"></see>. </param>
      public override void Insert(int index, object objItem)
      {
        base.Insert(index, objItem);
        if (this.mobjOwner.Sorted)
          this.mobjOwner.SortDomainItems();
        this.mobjOwner.Update();
      }

      /// <summary>Removes the specified item from the collection.</summary>
      /// <param name="objItem">The <see cref="T:System.Object"></see> to remove from the collection. </param>
      public override void Remove(object objItem)
      {
        int index = this.IndexOf(objItem);
        if (index == -1)
          throw new ArgumentOutOfRangeException("item", SR.GetString("InvalidArgument", (object) "item", (object) objItem.ToString()));
        this.RemoveAt(index);
        this.mobjOwner.Update();
      }

      /// <summary>Removes the item from the specified location in the collection.</summary>
      /// <param name="intItem">The indexed location of the <see cref="T:System.Object"></see> in the collection. </param>
      public override void RemoveAt(int intItem)
      {
        base.RemoveAt(intItem);
        if (intItem < this.mobjOwner.mintDomainIndex)
          this.mobjOwner.SelectIndex(this.mobjOwner.mintDomainIndex - 1);
        else if (intItem == this.mobjOwner.mintDomainIndex)
          this.mobjOwner.SelectIndex(-1);
        else
          this.mobjOwner.Update();
      }

      /// <summary>Gets or sets the item at the specified indexed location in the collection.</summary>
      /// <returns>An <see cref="T:System.Object"></see> that represents the item at the specified indexed location.</returns>
      /// <param name="index">The indexed location of the item in the collection. </param>
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public override object this[int index]
      {
        get => base[index];
        set
        {
          base[index] = value;
          if (this.mobjOwner.SelectedIndex == index)
            this.mobjOwner.SelectIndex(index);
          if (!this.mobjOwner.Sorted)
            return;
          this.mobjOwner.SortDomainItems();
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private sealed class DomainUpDownItemCompare : IComparer
    {
      public int Compare(object obj1, object obj2) => obj1 != obj2 && obj1 != null && obj2 != null ? string.Compare(obj1.ToString(), obj2.ToString(), false, CultureInfo.CurrentCulture) : 0;
    }
  }
}
