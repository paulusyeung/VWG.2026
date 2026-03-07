// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.PropertyGridView
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  /// <summary>
  /// 
  /// </summary>
  [Gizmox.WebGUI.Forms.MetadataTag("PV")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (PropertyGridSkin))]
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class PropertyGridView : Control, IServiceProvider, IWebUIEditorService
  {
    protected const short ERROR_MSGBOX_UP = 2;
    protected const short ERROR_NONE = 0;
    protected const short ERROR_THROWN = 1;
    protected const int mcntDefaultLablesColumnWidth = 100;
    private const short FlagBtnLaunchedEditor = 256;
    private const short FlagInPropertySet = 16;
    private const short FlagIsNewSelection = 2;
    private const short FlagNeedsRefresh = 1;
    private const short FlagNeedUpdateUIBasedOnFont = 128;
    private const short FlagNoDefault = 512;
    private const short FlagResizableDropDown = 1024;
    internal const int MaxRecurseExpand = 10;
    /// <summary>The short property registration.</summary>
    private static readonly SerializableProperty errorStateProperty = SerializableProperty.Register(nameof (errorState), typeof (short), typeof (PropertyGridView));
    /// <summary>The short property registration.</summary>
    private static readonly SerializableProperty flagsProperty = SerializableProperty.Register(nameof (flags), typeof (short), typeof (PropertyGridView));
    /// <summary>The Font property registration.</summary>
    private static readonly SerializableProperty fontBoldProperty = SerializableProperty.Register(nameof (fontBold), typeof (Font), typeof (PropertyGridView));
    /// <summary>The GridEntryCollection property registration.</summary>
    private static readonly SerializableProperty mobjAllGridEntriesProperty = SerializableProperty.Register(nameof (mobjAllGridEntries), typeof (GridEntryCollection), typeof (PropertyGridView));
    /// <summary>The IHelpService property registration.</summary>
    private static readonly SerializableProperty mobjHelpServiceProperty = SerializableProperty.Register(nameof (mobjHelpService), typeof (IHelpService), typeof (PropertyGridView));
    /// <summary>The PropertyGrid property registration.</summary>
    private static readonly SerializableProperty mobjOwnerGridProperty = SerializableProperty.Register(nameof (mobjOwnerGrid), typeof (PropertyGrid), typeof (PropertyGridView));
    /// <summary>The GridEntry property registration.</summary>
    private static readonly SerializableProperty mobjSelectedGridEntryProperty = SerializableProperty.Register(nameof (mobjSelectedGridEntry), typeof (GridEntry), typeof (PropertyGridView));
    /// <summary>The int property registration.</summary>
    private static readonly SerializableProperty mintSelectedRowProperty = SerializableProperty.Register(nameof (mintSelectedRow), typeof (int), typeof (PropertyGridView));
    /// <summary>The IServiceProvider property registration.</summary>
    private static readonly SerializableProperty mobjServiceProviderProperty = SerializableProperty.Register(nameof (mobjServiceProvider), typeof (IServiceProvider), typeof (PropertyGridView));
    /// <summary>The int property registration.</summary>
    private static readonly SerializableProperty mintTipInfoProperty = SerializableProperty.Register(nameof (mintTipInfo), typeof (int), typeof (PropertyGridView));
    /// <summary>The IHelpService property registration.</summary>
    private static readonly SerializableProperty mobjTopHelpServiceProperty = SerializableProperty.Register(nameof (mobjTopHelpService), typeof (IHelpService), typeof (PropertyGridView));
    /// <summary>The GridEntryCollection property registration.</summary>
    private static readonly SerializableProperty mobjTopLevelGridEntriesProperty = SerializableProperty.Register(nameof (mobjTopLevelGridEntries), typeof (GridEntryCollection), typeof (PropertyGridView));
    /// <summary>The int property registration.</summary>
    private static readonly SerializableProperty mintTotalPropsProperty = SerializableProperty.Register(nameof (mintTotalProps), typeof (int), typeof (PropertyGridView));
    /// <summary>The int property registration.</summary>
    private static readonly SerializableProperty mintLablesColumnWidthProperty = SerializableProperty.Register(nameof (mintLablesColumnWidth), typeof (int), typeof (PropertyGridView));

    private short errorState
    {
      get => this.GetValue<short>(PropertyGridView.errorStateProperty);
      set => this.SetValue<short>(PropertyGridView.errorStateProperty, value);
    }

    private short flags
    {
      get => this.GetValue<short>(PropertyGridView.flagsProperty, (short) 131);
      set => this.SetValue<short>(PropertyGridView.flagsProperty, value);
    }

    private Font fontBold
    {
      get => this.GetValue<Font>(PropertyGridView.fontBoldProperty);
      set => this.SetValue<Font>(PropertyGridView.fontBoldProperty, value);
    }

    private GridEntryCollection mobjAllGridEntries
    {
      get => this.GetValue<GridEntryCollection>(PropertyGridView.mobjAllGridEntriesProperty);
      set => this.SetValue<GridEntryCollection>(PropertyGridView.mobjAllGridEntriesProperty, value);
    }

    private IHelpService mobjHelpService
    {
      get => this.GetValue<IHelpService>(PropertyGridView.mobjHelpServiceProperty);
      set => this.SetValue<IHelpService>(PropertyGridView.mobjHelpServiceProperty, value);
    }

    private PropertyGrid mobjOwnerGrid
    {
      get => this.GetValue<PropertyGrid>(PropertyGridView.mobjOwnerGridProperty);
      set => this.SetValue<PropertyGrid>(PropertyGridView.mobjOwnerGridProperty, value);
    }

    private GridEntry mobjSelectedGridEntry
    {
      get => this.GetValue<GridEntry>(PropertyGridView.mobjSelectedGridEntryProperty);
      set => this.SetValue<GridEntry>(PropertyGridView.mobjSelectedGridEntryProperty, value);
    }

    private int mintSelectedRow
    {
      get => this.GetValue<int>(PropertyGridView.mintSelectedRowProperty, -1);
      set => this.SetValue<int>(PropertyGridView.mintSelectedRowProperty, value);
    }

    private IServiceProvider mobjServiceProvider
    {
      get => this.GetValue<IServiceProvider>(PropertyGridView.mobjServiceProviderProperty);
      set => this.SetValue<IServiceProvider>(PropertyGridView.mobjServiceProviderProperty, value);
    }

    private int mintTipInfo
    {
      get => this.GetValue<int>(PropertyGridView.mintTipInfoProperty, -1);
      set => this.SetValue<int>(PropertyGridView.mintTipInfoProperty, value);
    }

    private IHelpService mobjTopHelpService
    {
      get => this.GetValue<IHelpService>(PropertyGridView.mobjTopHelpServiceProperty);
      set => this.SetValue<IHelpService>(PropertyGridView.mobjTopHelpServiceProperty, value);
    }

    private GridEntryCollection mobjTopLevelGridEntries
    {
      get => this.GetValue<GridEntryCollection>(PropertyGridView.mobjTopLevelGridEntriesProperty);
      set => this.SetValue<GridEntryCollection>(PropertyGridView.mobjTopLevelGridEntriesProperty, value);
    }

    internal int mintTotalProps
    {
      get => this.GetValue<int>(PropertyGridView.mintTotalPropsProperty, -1);
      set => this.SetValue<int>(PropertyGridView.mintTotalPropsProperty, value);
    }

    private int mintLablesColumnWidth
    {
      get => this.GetValue<int>(PropertyGridView.mintLablesColumnWidthProperty, 100);
      set => this.SetValue<int>(PropertyGridView.mintLablesColumnWidthProperty, value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objServiceProvider"></param>
    /// <param name="objPropertyGrid"></param>
    public PropertyGridView(IServiceProvider objServiceProvider, PropertyGrid objPropertyGrid)
    {
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, false);
      this.SetStyle(ControlStyles.UserMouse, true);
      this.mobjOwnerGrid = objPropertyGrid;
      this.mobjServiceProvider = objServiceProvider;
      this.TabStop = true;
      this.Text = nameof (PropertyGridView);
      this.CreateUI();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (!this.OwnerGrid.HelpVisible)
        objWriter.WriteAttributeString("HV", "0");
      if (this.LablesColumnWidth == 100)
        return;
      objWriter.WriteAttributeString("LCW", this.LablesColumnWidth.ToString());
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
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnFullRedraw)
    {
      if (this.mobjTopLevelGridEntries == null)
        return;
      foreach (IRenderableComponentMember topLevelGridEntry in (GridItemCollection) this.mobjTopLevelGridEntries)
        topLevelGridEntry.RenderComponent(objContext, objWriter, lngRequestID, !blnFullRedraw);
    }

    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Member == string.Empty)
      {
        base.FireEvent(objEvent);
        if (!(objEvent.Type == "SplitterChange") || objEvent["W"] == null)
          return;
        this.LablesColumnWidth = Convert.ToInt32(Convert.ToDouble(objEvent["W"], (IFormatProvider) CultureInfo.InvariantCulture));
      }
      else
        this.GetGridEntry(int.Parse(objEvent.Member))?.FireEvent(objEvent);
    }

    private IRegisteredComponentMember GetGridEntry(int intMemberID) => this.GetGridEntry(intMemberID, this.mobjTopLevelGridEntries);

    private IRegisteredComponentMember GetGridEntry(
      int intMemberID,
      GridEntryCollection objGridEntries)
    {
      if (objGridEntries != null)
      {
        foreach (GridEntry objGridEntry in (GridItemCollection) objGridEntries)
        {
          IRegisteredComponentMember gridEntry1 = (IRegisteredComponentMember) objGridEntry;
          if (gridEntry1.MemberID == (long) intMemberID)
            return gridEntry1;
          IRegisteredComponentMember gridEntry2 = this.GetGridEntry(intMemberID, objGridEntry.Children);
          if (gridEntry2 != null)
            return gridEntry2;
        }
      }
      return (IRegisteredComponentMember) null;
    }

    /// <summary>Clears all properties</summary>
    public void ClearProps()
    {
      if (!this.HasEntries)
        return;
      this.mobjTopLevelGridEntries = (GridEntryCollection) null;
      this.mobjAllGridEntries = (GridEntryCollection) null;
      this.mintSelectedRow = -1;
      this.mintTipInfo = -1;
    }

    /// <summary>Closes the current opened drop down</summary>
    public void CloseDropDown()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool Commit() => true;

    /// <summary>Commits the text.</summary>
    /// <param name="strText">The text.</param>
    /// <param name="objGridEntry">The grid entry.</param>
    /// <returns></returns>
    internal bool CommitText(string strText, GridEntry objGridEntry)
    {
      if (objGridEntry == null)
        return true;
      object objValue;
      try
      {
        objValue = objGridEntry.ConvertTextToValue(strText);
      }
      catch (Exception ex)
      {
        this.SetCommitError((short) 1);
        this.ShowInvalidMessage(objGridEntry.PropertyLabel, (object) strText, ex);
        return false;
      }
      this.SetCommitError((short) 0);
      return this.CommitValue(objGridEntry, objValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strText"></param>
    /// <returns></returns>
    private bool CommitText(string strText) => this.CommitText(strText, this.mobjSelectedGridEntry);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objValue"></param>
    /// <returns></returns>
    private bool CommitValue(object objValue)
    {
      GridEntry selectedGridEntry = this.mobjSelectedGridEntry;
      if (selectedGridEntry == null)
        return true;
      PropertyValueChangingEventArgs changingEventArgs = this.mobjOwnerGrid.OnPropertyValueSetting((GridItem) selectedGridEntry, objValue);
      objValue = changingEventArgs.NewValue;
      if (changingEventArgs.Cancel)
      {
        selectedGridEntry.Update();
        return false;
      }
      object objOldValue = (object) null;
      try
      {
        objOldValue = selectedGridEntry.PropertyValue;
      }
      catch
      {
      }
      int num = this.DoCommitValue(selectedGridEntry, objValue) ? 1 : 0;
      this.mobjOwnerGrid.OnPropertyValueSet((GridItem) selectedGridEntry, objOldValue);
      return num != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objGridEntry"></param>
    /// <param name="objValue"></param>
    /// <returns></returns>
    private bool DoCommitValue(GridEntry objGridEntry, object objValue) => objGridEntry.SetPropertyValue(objValue, true);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objGridEntry"></param>
    /// <param name="objValue"></param>
    /// <returns></returns>
    internal bool CommitValue(GridEntry objGridEntry, object objValue)
    {
      PropertyValueChangingEventArgs changingEventArgs = this.mobjOwnerGrid.OnPropertyValueSetting((GridItem) objGridEntry, objValue);
      objValue = changingEventArgs.NewValue;
      if (changingEventArgs.Cancel)
      {
        objGridEntry.Update();
        return false;
      }
      object objOldValue = (object) null;
      try
      {
        objOldValue = objGridEntry.PropertyValue;
      }
      catch
      {
      }
      int num = this.DoCommitValue(objGridEntry, objValue) ? 1 : 0;
      this.mobjOwnerGrid.OnPropertyValueSet((GridItem) objGridEntry, objOldValue);
      if (num == 0)
        return num != 0;
      this.UpdateResetButtonUI(objGridEntry);
      return num != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objEntries"></param>
    /// <returns></returns>
    private int CountPropsFromOutline(GridEntryCollection objEntries)
    {
      if (objEntries == null)
        return 0;
      int count = objEntries.Count;
      for (int index = 0; index < objEntries.Count; ++index)
      {
        if (((GridEntry) objEntries[index]).InternalExpanded)
          count += this.CountPropsFromOutline(((GridEntry) objEntries[index]).Children);
      }
      return count;
    }

    private Bitmap CreateDownArrow()
    {
      Bitmap downArrow;
      try
      {
        Icon icon = new Icon(typeof (PropertyGrid), "Arrow.ico");
        downArrow = icon.ToBitmap();
        icon.Dispose();
      }
      catch (Exception ex)
      {
        downArrow = new Bitmap(16, 16);
      }
      return downArrow;
    }

    protected virtual void CreateUI()
    {
    }

    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
      {
        this.mobjOwnerGrid = (PropertyGrid) null;
        this.mobjTopLevelGridEntries = (GridEntryCollection) null;
        this.mobjAllGridEntries = (GridEntryCollection) null;
        this.mobjServiceProvider = (IServiceProvider) null;
        this.mobjTopHelpService = (IHelpService) null;
        if (this.mobjHelpService != null && this.mobjHelpService is IDisposable)
          ((IDisposable) this.mobjHelpService).Dispose();
        this.mobjHelpService = (IHelpService) null;
        if (this.fontBold != null)
        {
          this.fontBold.Dispose();
          this.fontBold = (Font) null;
        }
      }
      base.Dispose(blnDisposing);
    }

    public void DoCopyCommand()
    {
      int num = this.CanCopy ? 1 : 0;
    }

    public void DoCutCommand()
    {
      int num = this.CanCut ? 1 : 0;
    }

    public void DoPasteCommand()
    {
      int num = this.CanPaste ? 1 : 0;
    }

    public void DoubleClickRow(int intRow, bool blnToggleExpand, int type)
    {
    }

    private GridEntry GetGridEntryFromRow(int intRow) => (GridEntry) null;

    public void DoUndoCommand()
    {
      int num = this.CanUndo ? 1 : 0;
    }

    public virtual void DropDownDone() => this.CloseDropDown();

    public virtual void DropDownUpdate()
    {
    }

    public bool EnsurePendingChangesCommitted()
    {
      this.CloseDropDown();
      return this.Commit();
    }

    private GridEntry FindEquivalentGridEntry(GridEntryCollection objEntries)
    {
      if (objEntries == null || objEntries.Count == 0)
        return (GridEntry) null;
      GridEntryCollection allGridEntries = this.GetAllGridEntries();
      if (allGridEntries == null || allGridEntries.Count == 0)
        return (GridEntry) null;
      GridEntry equivalentGridEntry = (GridEntry) null;
      int index1 = 0;
      int num1 = allGridEntries.Count;
      for (int index2 = 0; index2 < objEntries.Count; ++index2)
      {
        if (objEntries[index2] != null)
        {
          if (equivalentGridEntry != null)
          {
            int count = allGridEntries.Count;
            if (!equivalentGridEntry.InternalExpanded)
              allGridEntries = this.GetAllGridEntries();
            num1 = equivalentGridEntry.VisibleChildCount;
          }
          int num2 = index1;
          equivalentGridEntry = (GridEntry) null;
          for (; index1 < allGridEntries.Count && index1 - num2 <= num1; ++index1)
          {
            if (objEntries.GetEntry(index2).NonParentEquals((object) allGridEntries[index1]))
            {
              equivalentGridEntry = allGridEntries.GetEntry(index1);
              ++index1;
              break;
            }
          }
          if (equivalentGridEntry == null)
            return equivalentGridEntry;
        }
      }
      return equivalentGridEntry;
    }

    public virtual void Flush()
    {
    }

    private GridEntryCollection GetAllGridEntries() => this.GetAllGridEntries(false);

    private GridEntryCollection GetAllGridEntries(bool fUpdateCache)
    {
      if (this.mintTotalProps == -1 || !this.HasEntries)
        return (GridEntryCollection) null;
      if (this.mobjAllGridEntries == null | fUpdateCache)
      {
        GridEntry[] gridEntryArray = new GridEntry[this.mintTotalProps];
        try
        {
          this.GetGridEntriesFromOutline(this.mobjTopLevelGridEntries, 0, 0, gridEntryArray);
        }
        catch (Exception ex)
        {
        }
        this.mobjAllGridEntries = new GridEntryCollection((GridEntry) null, gridEntryArray);
      }
      return this.mobjAllGridEntries;
    }

    private int GetCurrentValueIndex(GridEntry objGridEntry)
    {
      if (objGridEntry.Enumerable)
      {
        try
        {
          object[] propertyValueList = objGridEntry.GetPropertyValueList();
          object propertyValue = objGridEntry.PropertyValue;
          string strA = objGridEntry.TypeConverter.ConvertToString((ITypeDescriptorContext) objGridEntry, propertyValue);
          if (propertyValueList != null)
          {
            if (propertyValueList.Length != 0)
            {
              int currentValueIndex1 = -1;
              int currentValueIndex2 = -1;
              for (int index = 0; index < propertyValueList.Length; ++index)
              {
                object obj = propertyValueList[index];
                string strB = objGridEntry.TypeConverter.ConvertToString(obj);
                if (propertyValue == obj || string.Compare(strA, strB, true, CultureInfo.InvariantCulture) == 0)
                  currentValueIndex1 = index;
                if (propertyValue != null && obj != null && obj.Equals(propertyValue))
                  currentValueIndex2 = index;
                if (currentValueIndex1 == currentValueIndex2 && currentValueIndex1 != -1)
                  return currentValueIndex1;
              }
              if (currentValueIndex1 != -1)
                return currentValueIndex1;
              if (currentValueIndex2 != -1)
                return currentValueIndex2;
            }
          }
        }
        catch (Exception ex)
        {
        }
      }
      return -1;
    }

    public virtual int GetDefaultOutlineIndent() => 10;

    private bool GetFlag(short shortFlag) => ((uint) this.flags & (uint) shortFlag) > 0U;

    private int GetGridEntriesFromOutline(
      GridEntryCollection objEntries,
      int cCur,
      int cTarget,
      GridEntry[] arrGridEntries)
    {
      if (objEntries != null && objEntries.Count != 0)
      {
        --cCur;
        for (int index = 0; index < objEntries.Count; ++index)
        {
          ++cCur;
          if (cCur >= cTarget + arrGridEntries.Length)
            return cCur;
          GridEntry entry = objEntries.GetEntry(index);
          if (cCur >= cTarget)
            arrGridEntries[cCur - cTarget] = entry;
          if (entry.InternalExpanded)
          {
            GridEntryCollection children = entry.Children;
            if (children != null && children.Count > 0)
              cCur = this.GetGridEntriesFromOutline(children, cCur + 1, cTarget, arrGridEntries);
          }
        }
      }
      return cCur;
    }

    private GridEntry GetGridEntryFromOffset(int offset)
    {
      GridEntryCollection allGridEntries = this.GetAllGridEntries();
      return allGridEntries != null && offset >= 0 && offset < allGridEntries.Count ? allGridEntries.GetEntry(offset) : (GridEntry) null;
    }

    private GridEntryCollection GetGridEntryHierarchy(GridEntry objGridEntry)
    {
      if (objGridEntry == null)
        return (GridEntryCollection) null;
      int propertyDepth = objGridEntry.PropertyDepth;
      if (propertyDepth > 0)
      {
        GridEntry[] arrEntries = new GridEntry[propertyDepth + 1];
        for (; objGridEntry != null && propertyDepth >= 0; propertyDepth = objGridEntry.PropertyDepth)
        {
          arrEntries[propertyDepth] = objGridEntry;
          objGridEntry = objGridEntry.ParentGridEntry;
        }
        return new GridEntryCollection((GridEntry) null, arrEntries);
      }
      return new GridEntryCollection((GridEntry) null, new GridEntry[1]
      {
        objGridEntry
      });
    }

    private IHelpService GetHelpService()
    {
      if (this.mobjHelpService == null && this.ServiceProvider != null)
      {
        this.mobjTopHelpService = (IHelpService) this.ServiceProvider.GetService(typeof (IHelpService));
        if (this.mobjTopHelpService != null)
        {
          IHelpService localContext = this.mobjTopHelpService.CreateLocalContext(HelpContextType.ToolWindowSelection);
          if (localContext != null)
            this.mobjHelpService = localContext;
        }
      }
      return this.mobjHelpService;
    }

    public new object GetService(Type objClassService)
    {
      if (objClassService == typeof (IWebUIEditorService))
        return (object) this;
      return this.ServiceProvider != null ? this.mobjServiceProvider.GetService(objClassService) : (object) null;
    }

    private int GetRowFromGridEntry(GridEntry objGridEntry) => -1;

    protected virtual void OnRecreateChildren(object s, GridEntryRecreateChildrenEventArgs e)
    {
      GridEntry gridEntry = (GridEntry) s;
      if (gridEntry.Expanded)
      {
        GridEntry[] gridEntryArray = new GridEntry[this.mobjAllGridEntries.Count];
        this.mobjAllGridEntries.CopyTo((Array) gridEntryArray, 0);
        int num = -1;
        for (int index = 0; index < gridEntryArray.Length; ++index)
        {
          if (gridEntryArray[index] == gridEntry)
          {
            num = index;
            break;
          }
        }
        if (e.OldChildCount != e.NewChildCount)
        {
          GridEntry[] destinationArray = new GridEntry[gridEntryArray.Length + (e.NewChildCount - e.OldChildCount)];
          Array.Copy((Array) gridEntryArray, 0, (Array) destinationArray, 0, num + 1);
          Array.Copy((Array) gridEntryArray, num + e.OldChildCount + 1, (Array) destinationArray, num + e.NewChildCount + 1, gridEntryArray.Length - (num + e.OldChildCount + 1));
          gridEntryArray = destinationArray;
        }
        GridEntryCollection children = gridEntry.Children;
        int count = children.Count;
        for (int index = 0; index < count; ++index)
          gridEntryArray[num + index + 1] = children.GetEntry(index);
        this.mobjAllGridEntries.Clear();
        this.mobjAllGridEntries.AddRange(gridEntryArray);
      }
      if (e.OldChildCount != e.NewChildCount)
        this.mintTotalProps = this.CountPropsFromOutline(this.mobjTopLevelGridEntries);
      this.Invalidate();
    }

    private void OnSysColorChange(object sender, UserPreferenceChangedEventArgs e)
    {
      if (e.Category != UserPreferenceCategory.Color && e.Category != UserPreferenceCategory.Accessibility)
        return;
      this.SetFlag((short) 128, true);
    }

    public virtual void PopupDialog(int intRow) => this.GetGridEntryFromRow(intRow);

    protected virtual void RecalculateProps()
    {
      int num = this.CountPropsFromOutline(this.mobjTopLevelGridEntries);
      if (this.mintTotalProps == num)
        return;
      this.mintTotalProps = num;
      this.mobjAllGridEntries = (GridEntryCollection) null;
    }

    public new void Refresh()
    {
      this.Refresh(false, -1, -1);
      this.Invalidate();
    }

    public void Refresh(bool blnFullRefresh) => this.Refresh(blnFullRefresh, -1, -1);

    private void Refresh(bool blnFullRefresh, int intRowStart, int intRowEnd)
    {
      this.SetFlag((short) 1, true);
      GridEntry gridEntry = (GridEntry) null;
      if (this.IsDisposed)
        return;
      if (intRowStart == -1)
        intRowStart = 0;
      if (blnFullRefresh || this.mobjOwnerGrid.HavePropEntriesChanged())
      {
        int mintTotalProps = this.mintTotalProps;
        if (this.mobjTopLevelGridEntries != null && this.mobjTopLevelGridEntries.Count != 0)
          ((GridEntry) this.mobjTopLevelGridEntries[0]).GetValueOwner();
        if (blnFullRefresh)
          this.mobjOwnerGrid.RefreshProperties(true);
        this.UpdateHelpAttributes(this.mobjSelectedGridEntry, (GridEntry) null);
        this.SetFlag((short) 2, true);
        this.mobjTopLevelGridEntries = this.mobjOwnerGrid.GetPropEntries();
        this.mobjAllGridEntries = (GridEntryCollection) null;
        this.RecalculateProps();
        if (this.mintTotalProps > 0)
        {
          if (gridEntry == null)
          {
            gridEntry = this.mobjOwnerGrid.GetDefaultGridEntry();
            this.SetFlag((short) 512, gridEntry == null && this.mintTotalProps > 0);
          }
          if (gridEntry == null)
          {
            this.mintSelectedRow = 0;
            this.mobjSelectedGridEntry = this.GetGridEntryFromRow(this.mintSelectedRow);
          }
        }
        else if (mintTotalProps == 0)
          return;
      }
      if (!this.HasEntries)
      {
        this.mobjOwnerGrid.SetStatusBox((string) null, (string) null);
        this.mintSelectedRow = -1;
        this.Invalidate();
      }
      else
        this.mobjOwnerGrid.ClearValueCaches();
    }

    internal void RemoveSelectedEntryHelpAttributes() => this.UpdateHelpAttributes(this.mobjSelectedGridEntry, (GridEntry) null);

    /// <summary>Resets this property.</summary>
    public virtual void Reset()
    {
      GridEntry selectedGridEntry = this.SelectedGridEntry;
      if (selectedGridEntry == null)
        return;
      selectedGridEntry.ResetPropertyValue();
      selectedGridEntry.Update();
      this.UpdateResetButtonUI(selectedGridEntry);
    }

    protected virtual void ResetOrigin(Graphics objGraphics) => objGraphics.ResetTransform();

    public virtual void RunDialog(Form objDialog) => this.ShowDialog(objDialog);

    private void SetCommitError(short shortError)
    {
      int shortError1 = (int) shortError;
      this.SetCommitError((short) shortError1, shortError1 == 1);
    }

    private void SetCommitError(short shortError, bool blnCapture) => this.errorState = shortError;

    private void SetFlag(short shortFlag, bool blnValue)
    {
      if (blnValue)
        this.flags = (short) ((int) (ushort) this.flags | (int) (ushort) shortFlag);
      else
        this.flags &= ~shortFlag;
    }

    /// <summary>
    /// Shows the specified <see cref="T:.Gizmox.WebGUI.Forms.CommonDialog"></see>.
    /// </summary>
    /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> to display.</param>
    public void ShowDialog(CommonDialog objDialog)
    {
      if (objDialog == null)
        return;
      DialogTypes dialogTypes = DialogTypes.ModalWindow;
      if (this.OwnerGrid != null && this.OwnerGrid.Form != null)
        dialogTypes = this.OwnerGrid.Form.DialogType;
      if (dialogTypes == DialogTypes.PopupWindow)
      {
        int num1 = (int) objDialog.ShowPopup(this.TopLevelControl as Form, (IRegisteredComponentMember) this.SelectedGridEntry, (EventHandler) null, DialogAlignment.Below, Point.Empty);
      }
      else
      {
        int num2 = (int) objDialog.ShowDialog();
      }
    }

    /// <summary>
    /// Shows the specified <see cref="T:Gizmox.WebGUI.Forms.Form"></see>.
    /// </summary>
    /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to display.</param>
    public void ShowDialog(Form objDialog)
    {
      if (objDialog == null)
        return;
      DialogTypes dialogTypes = DialogTypes.ModalWindow;
      if (this.OwnerGrid != null && this.OwnerGrid.Form != null)
        dialogTypes = this.OwnerGrid.Form.DialogType;
      if (dialogTypes == DialogTypes.PopupWindow)
      {
        int num1 = (int) objDialog.ShowPopup();
      }
      else
      {
        int num2 = (int) objDialog.ShowDialog();
      }
    }

    private void ShowInvalidMessage(string strPropName, object objValue, Exception objException)
    {
    }

    public void ShowDropDown(Form objDialog)
    {
      if (objDialog == null)
        return;
      if (this.SelectedGridEntry != null)
      {
        objDialog.Width = this.Width - this.LablesColumnWidth - 15;
        int num = (int) objDialog.ShowPopup(this.TopLevelControl as Form, (IRegisteredComponentMember) this.SelectedGridEntry, DialogAlignment.Below);
      }
      else
      {
        int num1 = (int) objDialog.ShowPopup();
      }
    }

    private void UpdateHelpAttributes(GridEntry objOldEntry, GridEntry objNewEntry)
    {
      IHelpService helpService = this.GetHelpService();
      if (helpService == null || objOldEntry == objNewEntry)
        return;
      GridEntry gridEntry = objOldEntry;
      if (objOldEntry != null && !objNewEntry.Disposed)
      {
        for (; gridEntry != null; gridEntry = gridEntry.ParentGridEntry)
          helpService.RemoveContextAttribute("Keyword", gridEntry.HelpKeyword);
      }
      if (objNewEntry == null)
        return;
      GridEntry objGridEntry = objNewEntry;
      this.UpdateHelpAttributes(helpService, objGridEntry, true);
    }

    private void UpdateHelpAttributes(
      IHelpService objHelpService,
      GridEntry objGridEntry,
      bool blnAddAsF1)
    {
      if (objGridEntry == null)
        return;
      this.UpdateHelpAttributes(objHelpService, objGridEntry.ParentGridEntry, false);
      string helpKeyword = objGridEntry.HelpKeyword;
      if (helpKeyword == null)
        return;
      objHelpService.AddContextAttribute("Keyword", helpKeyword, blnAddAsF1 ? HelpKeywordType.F1Keyword : HelpKeywordType.GeneralKeyword);
    }

    private void UpdateResetCommand(GridEntry objGridEntry)
    {
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool CanCopy => false;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public bool CanCut => this.CanCopy && this.mobjSelectedGridEntry.IsTextEditable;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool CanPaste => this.mobjSelectedGridEntry != null && this.mobjSelectedGridEntry.IsTextEditable;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool CanUndo => false;

    protected override bool IsDelayedDrawing => true;

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    private bool HasEntries => this.mobjTopLevelGridEntries != null && this.mobjTopLevelGridEntries.Count > 0;

    protected bool NeedsCommit => false;

    public PropertyGrid OwnerGrid => this.mobjOwnerGrid;

    internal void SetActiveGridEntry(GridEntry objGridEntry) => this.OwnerGrid.SetActiveGridEntry(objGridEntry);

    internal GridEntry SelectedGridEntry
    {
      get => this.mobjSelectedGridEntry;
      set
      {
        this.mobjSelectedGridEntry = value;
        this.UpdateResetButtonUI(value);
      }
    }

    /// <summary>Updates the Reset button UI.</summary>
    /// <param name="objGridEntry">The value.</param>
    internal void UpdateResetButtonUI(GridEntry objGridEntry)
    {
      PropertyGrid ownerGrid = this.OwnerGrid;
      if (ownerGrid == null)
        return;
      ToolStripButton resetButton = ownerGrid.ResetButton;
      if (resetButton == null)
        return;
      bool flag = resetButton.Enabled = ownerGrid.CanResetPropertyValue(objGridEntry);
      resetButton.Text = flag ? string.Format("{0} {1}", (object) Gizmox.WebGUI.Forms.SR.GetString("PBRSToolTipReset"), (object) objGridEntry.PropertyName) : string.Empty;
      resetButton.Update();
    }

    public IServiceProvider ServiceProvider
    {
      get => this.mobjServiceProvider;
      set
      {
        if (value == this.mobjServiceProvider)
          return;
        this.mobjServiceProvider = value;
        this.mobjTopHelpService = (IHelpService) null;
        if (this.mobjHelpService != null && this.mobjHelpService is IDisposable)
          ((IDisposable) this.mobjHelpService).Dispose();
        this.mobjHelpService = (IHelpService) null;
      }
    }

    private int TipColumn
    {
      get => (this.mintTipInfo & -65536) >> 16;
      set
      {
        this.mintTipInfo &= (int) ushort.MaxValue;
        this.mintTipInfo |= (value & (int) ushort.MaxValue) << 16;
      }
    }

    private int TipRow
    {
      get => this.mintTipInfo & (int) ushort.MaxValue;
      set
      {
        this.mintTipInfo &= -65536;
        this.mintTipInfo |= value & (int) ushort.MaxValue;
      }
    }

    private int LablesColumnWidth
    {
      get => this.mintLablesColumnWidth;
      set
      {
        if (this.mintLablesColumnWidth == value)
          return;
        this.mintLablesColumnWidth = value;
      }
    }
  }
}
