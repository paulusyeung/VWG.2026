// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridView
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Displays data in a customizable grid.</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (DataGridView), "DataGridView_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGridViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGridViewController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ComplexBindingProperties("DataSource", "DataMember")]
  [Editor("System.Windows.Forms.Design.DataGridViewComponentEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (ComponentEditor))]
  [SRDescription("DescriptionDataGridView")]
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [ToolboxItemCategory("Data")]
  [Gizmox.WebGUI.Forms.MetadataTag("DG")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewSkin))]
  [Serializable]
  public class DataGridView : Control, ISupportInitialize
  {
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTOADDROWSCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTODELETEROWSCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTOORDERCOLUMNSCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTORESIZECOLUMNSCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTORESIZEROWSCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALTERNATINGROWSDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWAUTOGENERATECOLUMNSCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWAUTOSIZECOLUMNMODECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWAUTOSIZECOLUMNSMODECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWAUTOSIZEROWSMODECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWBACKGROUNDCOLORCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWBORDERSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCANCELROWEDIT = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLBEGINEDIT = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLBORDERSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTENTCLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTEXTMENUCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTEXTMENUSTRIPNEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLDOUBLECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLENDEDIT = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLENTER = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLERRORTEXTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLERRORTEXTNEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLFORMATTING = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLLEAVE = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEDOUBLECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEDOWN = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEENTER = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSELEAVE = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEMOVE = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEUP = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLPAINTING = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLPARSING = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLSTATECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLSTYLECONTENTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLTOOLTIPTEXTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLTOOLTIPTEXTNEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALIDATED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALIDATING = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALUECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALUENEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALUEPUSHED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNADDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNCONTEXTMENUSTRIPCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDATAPROPERTYNAMECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDISPLAYINDEXCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDIVIDERDOUBLECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDIVIDERWIDTHCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERCELLCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERSBORDERSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERSDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERSHEIGHTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERSHEIGHTSIZEMODECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNMINIMUMWIDTHCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNNAMECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNREMOVED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNSORTMODECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNSTATECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNTOOLTIPTEXTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCURRENTCELLCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCURRENTCELLDIRTYSTATECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDATABINDINGCOMPLETE = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDATAERROR = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDATAMEMBERCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDATASOURCECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDEFAULTVALUESNEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWEDITINGCONTROLSHOWING = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWEDITMODECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWGRIDCOLORCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWMULTISELECTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWNEWROWNEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWREADONLYCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWCONTEXTMENUCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWCONTEXTMENUNEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWDIRTYSTATENEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWDIVIDERDOUBLECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWDIVIDERHEIGHTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWENTER = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWERRORTEXTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWERRORTEXTNEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERCELLCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERSBORDERSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERSDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERSWIDTHCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERSWIDTHSIZEMODECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEIGHTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEIGHTINFONEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEIGHTINFOPUSHED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWLEAVE = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWMINIMUMHEIGHTCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWPOSTPAINT = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWPREPAINT = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWSADDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWSDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWSREMOVED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWSTATECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWUNSHARED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWVALIDATED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWVALIDATING = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWSCROLL = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWSELECTIONCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWSORTCOMPARE = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWSORTED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWUSERADDEDROW = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWUSERDELETEDROW = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWUSERDELETINGROW = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTEXTMENUNEEDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_HIERARCHICGRIDCREATED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_COLUMNCHOOSERCOLUMNSVISIBILITYCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_ROWEXPANDING = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_ROWEXPANDED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_ROWCOLLAPSED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    internal static readonly SerializableEvent EVENT_ROWCOLLAPSING = SerializableEvent.Register("Event", typeof (Delegate), typeof (DataGridView));
    private const int DATAGRIDVIEWSTATE1_allowUserToAddRows = 1;
    private const int DATAGRIDVIEWSTATE1_allowUserToDeleteRows = 2;
    private const int DATAGRIDVIEWSTATE1_allowUserToOrderColumns = 4;
    private const int DATAGRIDVIEWSTATE1_ambientColumnHeadersFont = 67108864;
    private const int DATAGRIDVIEWSTATE1_ambientFont = 33554432;
    private const int DATAGRIDVIEWSTATE1_ambientForeColor = 1024;
    private const int DATAGRIDVIEWSTATE1_ambientRowHeadersFont = 134217728;
    private const int DATAGRIDVIEWSTATE1_autoGenerateColumns = 8388608;
    private const int DATAGRIDVIEWSTATE1_columnHeadersVisible = 8;
    private const int DATAGRIDVIEWSTATE1_currentCellInEditMode = 32768;
    private const int DATAGRIDVIEWSTATE1_customCursorSet = 16777216;
    private const int DATAGRIDVIEWSTATE1_editedCellChanged = 131072;
    private const int DATAGRIDVIEWSTATE1_editedRowChanged = 262144;
    private const int DATAGRIDVIEWSTATE1_editingControlChanging = 16384;
    private const int DATAGRIDVIEWSTATE1_editingControlHidden = 4096;
    private const int DATAGRIDVIEWSTATE1_forwardCharMessage = 32;
    private const int DATAGRIDVIEWSTATE1_ignoringEditingChanges = 512;
    private const int DATAGRIDVIEWSTATE1_isAutoSized = 1073741824;
    private const int DATAGRIDVIEWSTATE1_isRestricted = 536870912;
    private const int DATAGRIDVIEWSTATE1_isRestrictedChecked = 268435456;
    private const int DATAGRIDVIEWSTATE1_leavingWithTabKey = 64;
    private const int DATAGRIDVIEWSTATE1_multiSelect = 128;
    private const int DATAGRIDVIEWSTATE1_newRowCreatedByEditing = 2097152;
    private const int DATAGRIDVIEWSTATE1_newRowEdited = 524288;
    private const int DATAGRIDVIEWSTATE1_readOnly = 1048576;
    private const int DATAGRIDVIEWSTATE1_rowHeadersVisible = 16;
    private const int DATAGRIDVIEWSTATE1_scrolledSinceMouseDown = 2048;
    private const int DATAGRIDVIEWSTATE1_standardTab = 8192;
    private const int DATAGRIDVIEWSTATE1_temporarilyResetCurrentCell = 4194304;
    private const int DATAGRIDVIEWSTATE1_virtualMode = 65536;
    private const int DATAGRIDVIEWSTATE2_allowHorizontalScrollbar = 33554432;
    private const int DATAGRIDVIEWSTATE2_allowUserToResizeColumns = 2;
    private const int DATAGRIDVIEWSTATE2_allowUserToResizeRows = 4;
    private const int DATAGRIDVIEWSTATE2_autoSizedWithoutHandle = 1048576;
    private const int DATAGRIDVIEWSTATE2_cellMouseDownInContentBounds = 268435456;
    private const int DATAGRIDVIEWSTATE2_currentCellWantsInputKey = 8192;
    private const int DATAGRIDVIEWSTATE2_discardEditingControl = 536870912;
    private const int DATAGRIDVIEWSTATE2_enableHeadersVisualStyles = 64;
    private const int DATAGRIDVIEWSTATE2_ignoreCursorChange = 2097152;
    private const int DATAGRIDVIEWSTATE2_inBindingContextChanged = 16777216;
    private const int DATAGRIDVIEWSTATE2_initializing = 524288;
    private const int DATAGRIDVIEWSTATE2_messageFromEditingCtrls = 134217728;
    private const int DATAGRIDVIEWSTATE2_mouseEnterExpected = 32;
    private const int DATAGRIDVIEWSTATE2_mouseOverRemovedEditingCtrl = 8;
    private const int DATAGRIDVIEWSTATE2_mouseOverRemovedEditingPanel = 16;
    private const int DATAGRIDVIEWSTATE2_nextMouseUpIsDouble = 8388608;
    private const int DATAGRIDVIEWSTATE2_raiseSelectionChanged = 262144;
    private const int DATAGRIDVIEWSTATE2_replacedCellReadOnly = 131072;
    private const int DATAGRIDVIEWSTATE2_replacedCellSelected = 65536;
    private const int DATAGRIDVIEWSTATE2_rightToLeftMode = 2048;
    private const int DATAGRIDVIEWSTATE2_rightToLeftValid = 4096;
    private const int DATAGRIDVIEWSTATE2_rowsCollectionClearedInSetCell = 4194304;
    private const int DATAGRIDVIEWSTATE2_showCellErrors = 128;
    private const int DATAGRIDVIEWSTATE2_showCellToolTips = 256;
    private const int DATAGRIDVIEWSTATE2_showColumnRelocationInsertion = 1024;
    private const int DATAGRIDVIEWSTATE2_showEditingIcon = 1;
    private const int DATAGRIDVIEWSTATE2_showRowErrors = 512;
    private const int DATAGRIDVIEWSTATE2_stopRaisingHorizontalScroll = 32768;
    private const int DATAGRIDVIEWSTATE2_stopRaisingVerticalScroll = 16384;
    private const int DATAGRIDVIEWSTATE2_usedFillWeightsDirty = 67108864;
    private const int DATAGRIDVIEWOPER_inAdjustFillingColumn = 524288;
    private const int DATAGRIDVIEWOPER_inAdjustFillingColumns = 262144;
    private const int DATAGRIDVIEWOPER_inBeginEdit = 2097152;
    private const int DATAGRIDVIEWOPER_inBorderStyleChange = 65536;
    private const int DATAGRIDVIEWOPER_inCellValidating = 32768;
    private const int DATAGRIDVIEWOPER_inCurrentCellChange = 131072;
    private const int DATAGRIDVIEWOPER_inDisplayIndexAdjustments = 2048;
    private const int DATAGRIDVIEWOPER_inDispose = 1048576;
    private const int DATAGRIDVIEWOPER_inEndEdit = 4194304;
    private const int DATAGRIDVIEWOPER_inMouseDown = 8192;
    private const int DATAGRIDVIEWOPER_inReadOnlyChange = 16384;
    private const int DATAGRIDVIEWOPER_inRefreshColumns = 1024;
    private const int DATAGRIDVIEWOPER_inSort = 64;
    private const int DATAGRIDVIEWOPER_lastEditCtrlClickDoubled = 4096;
    private const int DATAGRIDVIEWOPER_resizingOperationAboutToStart = 8388608;
    private const int DATAGRIDVIEWOPER_trackCellSelect = 16;
    private const int DATAGRIDVIEWOPER_trackColHeadersResize = 128;
    private const int DATAGRIDVIEWOPER_trackColRelocation = 32;
    private const int DATAGRIDVIEWOPER_trackColResize = 1;
    private const int DATAGRIDVIEWOPER_trackColSelect = 4;
    private const int DATAGRIDVIEWOPER_trackMouseMoves = 512;
    private const int DATAGRIDVIEWOPER_trackRowHeadersResize = 256;
    private const int DATAGRIDVIEWOPER_trackRowResize = 2;
    private const int DATAGRIDVIEWOPER_trackRowSelect = 8;
    private const byte DATAGRIDVIEW_columnSizingHotZone = 6;
    private const byte DATAGRIDVIEW_rowSizingHotZone = 5;
    private const byte DATAGRIDVIEW_insertionBarWidth = 3;
    private const byte DATAGRIDVIEW_bulkPaintThreshold = 8;
    private const int mcntState2_Initializing = 524288;
    private const int VERTICAL_SCROLLBAR_WIDTH = 17;
    private int mintBulkLayoutCount;
    private int mintColumnHeadersHeight;
    private int mintRowHeadersWidth;
    private int mintBulkPaintCount;
    private int mintAutoSizeCount;
    private int mintDimensionChangeCount;
    private int mintSelectionChangeCount;
    private int mintNewRowIndex = -1;
    private bool mblnDisableNavigation;
    private bool mblnShowFilterRow;
    private bool mblnLazyMode;
    private bool mblnIsSelectionChangeCritical;
    private bool mblnSelectOnRightClick;
    private bool mblnEnforceEqualRowSize;
    private bool mblnIsCaptionVisible;
    private DataGridView.PreRenderUpdateType menmPreRenderUpdateTypes;
    private DataGridViewCellBorderStyle menmCellBorderStyle = DataGridViewCellBorderStyle.Single;
    private DataGridViewAutoSizeRowsMode menmAutoSizeRowsMode;
    private DataGridViewAutoSizeColumnsMode menmAutoSizeColumnsMode;
    private DataGridViewClipboardCopyMode menmClipboardCopyMode;
    private ScrollBars menmScrollBars;
    private DataGridViewSelectionMode menmSelectionMode;
    private DataGridViewColumnHeadersHeightSizeMode menmColumnHeadersHeightSizeMode;
    private DataGridViewEditMode menmEditMode;
    private SortOrder menmSortOrder;
    private DataGridViewRowHeadersWidthSizeMode menmRowHeadersWidthSizeMode;
    private DataGridViewIntLinkedList mobjSelectedBandSnapshotIndexes;
    private DataGridViewCellLinkedList mobjIndividualSelectedCells;
    private DataGridViewIntLinkedList mobjSelectedBandIndexes;
    private DataGridViewCellStyleChangedEventArgs mobjCellStyleChangedEventArgs;
    private DataGridView.DataGridViewDataConnection mobjDataConnection;
    private object mobjUneditedFormattedValue;
    private Color mobjGridColor;
    private Color mobjBackgroundColor;
    private Point mobjCurrentCellCache;
    private Point mobjCurrentCellPoint = Point.Empty;
    private DataGridViewCellValueEventArgs mobjCellValueEventArgs;
    private DataGridViewCellLinkedList mobjIndividualReadOnlyCells;
    private DataGridView.DisplayedBandsData mobjDisplayedBandsInfo;
    private DataGridViewAdvancedBorderStyle mobjAdvancedDataGridViewBorderStyle;
    private DataGridView.LayoutData mobjLayoutInfo;
    private DataGridViewCellStyle mobjDefaultCellStyle;
    private DataGridViewCellStyle mobjColumnHeadersDefaultCellStyle;
    private DataGridViewCellStyle mobjAlternatingRowsDefaultCellStyle;
    private DataGridViewCellStyle mobjRowHeadersDefaultCellStyle;
    private DataGridViewCellStyle mobjPlaceholderCellStyle;
    private DataGridViewCellStyle mobjRowsDefaultCellStyle;
    private Control mobjLatestEditingControl;
    private Control mobjCachedEditingControl;
    private Control mobjEditingControl;
    private DataGridViewHeaderCell mobjTopLeftHeaderCell;
    private DataGridViewColumnCollection mobjColumns;
    private DataGridViewRowCollection mobjRows;
    private DataGridViewRow mobjRowTemplate;
    private DataGridViewColumn mobjSortedColumn;
    private DataGridView.DataGridViewBlocksManager mobjDataGridViewBlocksManager;
    private DataGridViewFilterRow mobjDataGridViewFilterRow;
    private NavigationKeyFilter menmNavigationKeyFilter;
    private int mintMaxFilterOptions = 100;
    internal bool mblnSuspendFilterInitialization;
    private int minPerformLayoutCount;
    private ObservableCollection<HierarchicInfo> mobjHierarchicInfos;
    private Dictionary<string, string> mobjRealFilteringDataMemberIndexByProposedFilteringDataMember;
    private DataGridView mobjRootGrid;
    private string mstrFilterTemplate;
    private int mintHierarchyLevel;
    private ShowExpansionIndicator menmExpansionIndicator;
    private int mintCaptionHeight;
    private bool mblnShowExpansionIndicator;
    private ObservableCollection<HierarchicInfo> mobjSystemHierarchicInfos;
    private UniqueObservableCollection<string> mobjGroupingColumns;
    private bool mblnShowGroupingDropArea;
    private bool mblnSupportGroupCount;
    private bool mblnHideGroupedColumns;
    private DataGridViewGroupingTreeView mobjGroupingTreeView;
    private Color mobjGroupingAreaBackColor;
    private BorderColor mobjGroupingAreaBorderColor;
    private BorderStyle mobjGroupingAreaBorderStyle;
    private BorderWidth mobjGroupingAreaBorderWidth;
    private int mintGroupingAreaHeight;
    private ResourceHandle mobjGroupingAreaBackgroundImage;
    private BackgroundImagePosition menmGroupingAreaBackgroundImagePosition;
    private BackgroundImageRepeat menmGroupingAreaBackgroundImageRepeat;
    private int mintPrevGroupHeaderCellPanelIndex = -1;
    private ExtendedColumnHeaders mobjExtendedColumnHeaders;
    private bool mblnShowColumnChooser;
    private IComparer mblnColumnChooserSorter;
    private List<HeaderFilterInfo> mobjHeadersFilterInfo;
    private static readonly SerializableEvent ColumnDividerDoubleClickEvent = SerializableEvent.Register("ColumnDividerDoubleClick", typeof (DataGridViewColumnDividerDoubleClickEventHandler), typeof (DataGridView));
    /// <summary>The CurrentCellChanged event registration.</summary>
    private static readonly SerializableEvent CurrentCellChangedEvent = SerializableEvent.Register("CurrentCellChanged", typeof (EventHandler), typeof (DataGridView));
    /// <summary>The GroupHeaderFormatting event registration.</summary>
    private static readonly SerializableEvent GroupHeaderFormattingEvent = SerializableEvent.Register("GroupHeaderFormatting", typeof (GroupHeaderFormattingEventHandler), typeof (DataGridView));
    /// <summary>The GroupingChangedEvent event registration.</summary>
    private static readonly SerializableEvent GroupingChangedEvent = SerializableEvent.Register(nameof (GroupingChangedEvent), typeof (GroupingChangedEventHandler), typeof (DataGridView));
    /// <summary>The SelectionChanged event registration.</summary>
    private static readonly SerializableEvent SelectionChangedEvent = SerializableEvent.Register("SelectionChanged", typeof (EventHandler), typeof (DataGridView));
    /// <summary>ShowCustomFilter event registration.</summary>
    private static readonly SerializableEvent CustomHeaderFilterClickedEvent = SerializableEvent.Register(nameof (CustomHeaderFilterClickedEvent), typeof (CustomFilterApplyingEventHandler), typeof (DataGridView));
    [NonSerialized]
    private Graphics mobjCachedGraphics;
    /// <summary>Gets or sets the data grid view state1.</summary>
    /// <value>The data grid view state2.</value>
    private SerializableBitVector32 mobjDataGridViewState1;
    /// <summary>Gets or sets the data grid view state2.</summary>
    /// <value>The data grid view state2.</value>
    private SerializableBitVector32 mobjDataGridViewState2;
    /// <summary>Gets or sets the data grid view oper.</summary>
    /// <value>The data grid view oper.</value>
    private SerializableBitVector32 mobjDataGridViewOper;
    private int mintTotalPages = 1;
    private int mintCurrentPage = 1;
    private int mintItemsPerPage = 20;
    private int mintVirtualBlockSize = 20;
    private bool mblnUseInternalPaging = true;
    /// <summary>The PagingChanged event registration.</summary>
    private static readonly SerializableEvent PagingChangedEvent = SerializableEvent.Register("PagingChanged", typeof (EventHandler), typeof (DataGridView));

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridViewOnAllowUserToAddRowsChangedDescr")]
    public event EventHandler AllowUserToAddRowsChanged;

    /// <summary>Occurs when the value of the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToDeleteRowsChanged"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewOnAllowUserToDeleteRowsChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AllowUserToDeleteRowsChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToOrderColumns"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewOnAllowUserToOrderColumnsChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AllowUserToOrderColumnsChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeColumns"></see> property changes.</summary>
    [SRDescription("DataGridViewOnAllowUserToResizeColumnsChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AllowUserToResizeColumnsChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property changes.</summary>
    [SRDescription("DataGridViewOnAllowUserToResizeRowsChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AllowUserToResizeRowsChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AlternatingRowsDefaultCellStyle"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewAlternatingRowsDefaultCellStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AlternatingRowsDefaultCellStyleChanged;

    /// <summary>Occurs when the value of the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoGenerateColumnsChanged"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public event EventHandler AutoGenerateColumnsChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property of a column changes.</summary>
    [SRDescription("DataGridViewAutoSizeColumnModeChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewAutoSizeColumnModeEventHandler AutoSizeColumnModeChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsMode"></see> property changes.</summary>
    [SRDescription("DataGridViewAutoSizeColumnsModeChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewAutoSizeColumnsModeEventHandler AutoSizeColumnsModeChanged;

    /// <summary>Occurs when the value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewAutoSizeRowsModeChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewAutoSizeModeEventHandler AutoSizeRowsModeChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BackColor"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler BackColorChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BackgroundColor"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewBackgroundColorChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler BackgroundColorChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BackgroundImage"></see> property changes.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler BackgroundImageChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BackgroundImageLayout"></see> property changes.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler BackgroundImageLayoutChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BorderStyle"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewBorderStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler BorderStyleChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is true and the cancels edits in a row.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CancelRowEditDescr")]
    [SRCategory("CatAction")]
    public event QuestionEventHandler CancelRowEdit;

    /// <summary>Occurs when edit mode starts for the selected cell.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [SRDescription("DataGridView_CellBeginEditDescr")]
    public event DataGridViewCellCancelEventHandler CellBeginEdit
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLBEGINEDIT, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLBEGINEDIT, (Delegate) value);
    }

    /// <summary>Occurs when an hierarchic grid is created.</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when a child grid is created")]
    public event HierarchicDataGridViewCreatedEventHandler HierarchicGridCreated
    {
      add => this.AddHandler(DataGridView.EVENT_HIERARCHICGRIDCREATED, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_HIERARCHICGRIDCREATED, (Delegate) value);
    }

    /// <summary>
    /// ColumnChooser dialig is closed, and at least one column's visibility is changed
    /// </summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when ColumnChooser dialig is closed, and at least one column's visibility is changed")]
    public event ColumnChooserColumnsVisibilityChangedHandler ColumnChooserColumnsVisibilityChanged
    {
      add => this.AddHandler(DataGridView.EVENT_COLUMNCHOOSERCOLUMNSVISIBILITYCHANGED, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_COLUMNCHOOSERCOLUMNSVISIBILITYCHANGED, (Delegate) value);
    }

    /// <summary>Occurs when [row expanding].</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when a row is expanding")]
    public event RowExpandingEventHandler RowExpanding
    {
      add => this.AddCriticalHandler(DataGridView.EVENT_ROWEXPANDING, (Delegate) value);
      remove => this.RemoveCriticalHandler(DataGridView.EVENT_ROWEXPANDING, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CurrentCellChanged event.</summary>
    private Delegate RowExpandingHandler => this.GetHandler(DataGridView.EVENT_ROWEXPANDING);

    /// <summary>Occurs when [row expanded].</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when a row is expanded")]
    public event RowExpandedEventHandler RowExpanded
    {
      add => this.AddCriticalHandler(DataGridView.EVENT_ROWEXPANDED, (Delegate) value);
      remove => this.RemoveCriticalHandler(DataGridView.EVENT_ROWEXPANDED, (Delegate) value);
    }

    /// <summary>Occurs when [row collapses].</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when a row is collapse")]
    public event RowCollapsedEventHandler RowCollapsed
    {
      add => this.AddCriticalHandler(DataGridView.EVENT_ROWCOLLAPSED, (Delegate) value);
      remove => this.RemoveCriticalHandler(DataGridView.EVENT_ROWCOLLAPSED, (Delegate) value);
    }

    /// <summary>Occurs when [row collapsing].</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when a row is collapsing")]
    public event RowCollapsingEventHandler RowCollapsing
    {
      add => this.AddCriticalHandler(DataGridView.EVENT_ROWCOLLAPSING, (Delegate) value);
      remove => this.RemoveCriticalHandler(DataGridView.EVENT_ROWCOLLAPSING, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CurrentCellChanged event.</summary>
    private Delegate RowExpandedHandler => this.GetHandler(DataGridView.EVENT_ROWEXPANDED);

    /// <summary>Occurs when the border style of a cell changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellBorderStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler CellBorderStyleChanged;

    /// <summary>Occurs when any part of a cell is clicked.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellClickDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellEventHandler CellClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCLICK, (Delegate) value);
    }

    /// <summary>Occurs when the content within a cell is clicked.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellContentClick")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellEventHandler CellContentClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTCLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTCLICK, (Delegate) value);
    }

    /// <summary>Occurs when the user double-clicks a cell's contents.</summary>
    [SRDescription("DataGridView_CellContentDoubleClick")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellEventHandler CellContentDoubleClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK, (Delegate) value);
    }

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ContextMenuStrip"></see> property changes.
    /// </summary>
    [SRDescription("DataGridView_CellContextMenuChanged")]
    [SRCategory("CatAction")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event DataGridViewCellEventHandler CellContextMenuChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ContextMenuStrip"></see> property changes. </summary>
    [SRDescription("DataGridView_CellContextMenuStripChanged")]
    [SRCategory("CatAction")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CellContextMenuStripChanged event is obsolete use CellContextMenuChanged instead")]
    public event DataGridViewCellEventHandler CellContextMenuStripChanged;

    /// <summary>Occurs when the user double-clicks anywhere in a cell.</summary>
    [SRCategory("CatMouse")]
    [SRDescription("DataGridView_CellDoubleClickDescr")]
    public event DataGridViewCellEventHandler CellDoubleClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLDOUBLECLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLDOUBLECLICK, (Delegate) value);
    }

    /// <summary>Occurs when edit mode stops for the currently selected cell.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [SRDescription("DataGridView_CellEndEditDescr")]
    public event DataGridViewCellEventHandler CellEndEdit
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLENDEDIT, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLENDEDIT, (Delegate) value);
    }

    /// <summary>Occurs when the current cell changes in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or when the control receives input focus. </summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatFocus")]
    [SRDescription("DataGridView_CellEnterDescr")]
    public event DataGridViewCellEventHandler CellEnter;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ErrorText"></see> property of a cell changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellErrorTextChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewCellEventHandler CellErrorTextChanged;

    /// <summary>Occurs when a cell's error text is needed.</summary>
    [SRDescription("DataGridView_CellErrorTextNeededDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRCategory("CatData")]
    public event DataGridViewCellErrorTextNeededEventHandler CellErrorTextNeeded;

    /// <summary>Occurs when the contents of a cell need to be formatted for display.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellFormattingDescr")]
    [SRCategory("CatDisplay")]
    public event DataGridViewCellFormattingEventHandler CellFormatting;

    /// <summary>Occurs when a cell loses input focus and is no longer the current cell.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellLeaveDescr")]
    [SRCategory("CatFocus")]
    public event DataGridViewCellEventHandler CellLeave;

    /// <summary>Occurs whenever the user clicks anywhere on a cell with the mouse.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellMouseClickDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellMouseEventHandler CellMouseClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSECLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSECLICK, (Delegate) value);
    }

    /// <summary>Occurs when a cell within the <see cref="T:System.Windows.Forms.DataGridView"></see> is double-clicked.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellMouseDoubleClickDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellMouseEventHandler CellMouseDoubleClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOUBLECLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOUBLECLICK, (Delegate) value);
    }

    /// <summary>Occurs when the user presses a mouse button while the mouse pointer is within the boundaries of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellMouseDownDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellMouseEventHandler CellMouseDown
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOWN, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOWN, (Delegate) value);
    }

    /// <summary>Occurs when the mouse pointer enters a cell.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellMouseEnterDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellEventHandler CellMouseEnter;

    /// <summary>Occurs when the mouse pointer leaves a cell.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellMouseLeaveDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellEventHandler CellMouseLeave;

    /// <summary>Occurs when the mouse pointer moves over the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellMouseMoveDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellMouseEventHandler CellMouseMove;

    /// <summary>Occurs when the user releases a mouse button while over a cell.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellMouseUpDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellMouseEventHandler CellMouseUp
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEUP, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEUP, (Delegate) value);
    }

    /// <summary>Occurs when a cell leaves edit mode if the cell value has been modified.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatDisplay")]
    [SRDescription("DataGridView_CellParsingDescr")]
    public event DataGridViewCellParsingEventHandler CellParsing;

    /// <summary>Occurs when a cell state changes, such as when the cell loses or gains focus.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellStateChangedDescr")]
    [SRCategory("CatBehavior")]
    public event DataGridViewCellStateChangedEventHandler CellStateChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewCellEventHandler CellStyleChanged;

    /// <summary>Occurs when one of the values of a cell style changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellStyleContentChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewCellStyleContentChangedEventHandler CellStyleContentChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ToolTipText"></see> property value changes for a cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridView_CellToolTipTextChangedDescr")]
    public event DataGridViewCellEventHandler CellToolTipTextChanged;

    /// <summary>Occurs when a cell's ToolTip text is needed.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_CellToolTipTextNeededDescr")]
    public event DataGridViewCellToolTipTextNeededEventHandler CellToolTipTextNeeded;

    /// <summary>Occurs after the cell has finished validating.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellValidatedDescr")]
    [SRCategory("CatFocus")]
    public event DataGridViewCellEventHandler CellValidated;

    /// <summary>Occurs when a cell loses input focus, enabling content validation.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellValidatingDescr")]
    [SRCategory("CatFocus")]
    public event DataGridViewCellValidatingEventHandler CellValidating;

    /// <summary>Occurs when the value of a cell changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellValueChangedDescr")]
    [SRCategory("CatAction")]
    public event DataGridViewCellEventHandler CellValueChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is true and the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> requires a value for a cell in order to format and display the cell.</summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("DataGridView_CellValueNeededDescr")]
    [SRCategory("CatData")]
    public event DataGridViewCellValueEventHandler CellValueNeeded;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is true and a cell value has changed and requires storage in the underlying data source.</summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("DataGridView_CellValuePushedDescr")]
    [SRCategory("CatData")]
    public event DataGridViewCellValueEventHandler CellValuePushed;

    /// <summary>Occurs when a column is added to the control.</summary>
    [SRDescription("DataGridView_ColumnAddedDescr")]
    [SRCategory("CatAction")]
    public event DataGridViewColumnEventHandler ColumnAdded;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.ContextMenuStrip"></see> property of a column changes.</summary>
    [SRDescription("DataGridView_ColumnContextMenuStripChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewColumnEventHandler ColumnContextMenuStripChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DataPropertyName"></see> property for a column changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridView_ColumnDataPropertyNameChangedDescr")]
    public event DataGridViewColumnEventHandler ColumnDataPropertyNameChanged
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNDATAPROPERTYNAMECHANGED, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNDATAPROPERTYNAMECHANGED, (Delegate) value);
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property for a column changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnDefaultCellStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewColumnEventHandler ColumnDefaultCellStyleChanged;

    /// <summary>Occurs when the value the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property for a column changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnDisplayIndexChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewColumnEventHandler ColumnDisplayIndexChanged;

    /// <summary>Occurs when the user double-clicks a divider between two columns.</summary>
    [SRDescription("DataGridView_ColumnDividerDoubleClickDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewColumnDividerDoubleClickEventHandler ColumnDividerDoubleClick
    {
      add => this.AddHandler(DataGridView.ColumnDividerDoubleClickEvent, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.ColumnDividerDoubleClickEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client column divider double click].</summary>
    [SRDescription("Occurs when control's column divider double-clicked in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientColumnDividerDoubleClick
    {
      add => this.AddClientHandler("DividerDoubleClick", value);
      remove => this.RemoveClientHandler("DividerDoubleClick", value);
    }

    /// <summary>Occurs when [client cell begin edit].</summary>
    [SRDescription("Occurs when control's cell editing starts in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientCellBeginEdit
    {
      add => this.AddClientHandler("BeginEdit", value);
      remove => this.RemoveClientHandler("BeginEdit", value);
    }

    /// <summary>Occurs when [client cell value change].</summary>
    [SRDescription("Occurs when control's cell value changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientCellValueChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Occurs when [client cell end edit].</summary>
    [SRDescription("Occurs when control's cell editing ends in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientCellEndEdit
    {
      add => this.AddClientHandler("EndEdit", value);
      remove => this.RemoveClientHandler("EndEdit", value);
    }

    /// <summary>Occurs when [client row expanding].</summary>
    [SRDescription("Occurs when control's row is expanding in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientRowExpanding
    {
      add => this.AddClientHandler("Expand", value);
      remove => this.RemoveClientHandler("Expand", value);
    }

    /// <summary>Occurs when [client column width changed].</summary>
    [SRDescription("Occurs when control's column/row resized in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientRowColumnResized
    {
      add => this.AddClientHandler("Resize", value);
      remove => this.RemoveClientHandler("Resize", value);
    }

    /// <summary>Gets the column divider double click handler.</summary>
    private DataGridViewColumnDividerDoubleClickEventHandler ColumnDividerDoubleClickHandler => (DataGridViewColumnDividerDoubleClickEventHandler) this.GetHandler(DataGridView.ColumnDividerDoubleClickEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DividerWidth"></see> property changes.</summary>
    [SRDescription("DataGridView_ColumnDividerWidthChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewColumnEventHandler ColumnDividerWidthChanged;

    /// <summary>Occurs when the contents of a column header cell change.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnHeaderCellChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewColumnEventHandler ColumnHeaderCellChanged;

    /// <summary>Occurs when a column header is double-clicked.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnHeaderMouseDoubleClickDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellMouseEventHandler ColumnHeaderMouseDoubleClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK, (Delegate) value);
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersBorderStyle"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridView_ColumnHeadersBorderStyleChangedDescr")]
    public event EventHandler ColumnHeadersBorderStyleChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersDefaultCellStyle"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewColumnHeadersDefaultCellStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler ColumnHeadersDefaultCellStyleChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersHeight"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewColumnHeadersHeightChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler ColumnHeadersHeightChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersHeightSizeMode"></see> property changes.</summary>
    [SRDescription("DataGridView_ColumnHeadersHeightSizeModeChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewAutoSizeModeEventHandler ColumnHeadersHeightSizeModeChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.MinimumWidth"></see> property for a column changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnMinimumWidthChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewColumnEventHandler ColumnMinimumWidthChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Name"></see> property for a column changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnNameChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewColumnEventHandler ColumnNameChanged;

    /// <summary>Occurs when a column is removed from the control.</summary>
    [SRDescription("DataGridView_ColumnRemovedDescr")]
    [SRCategory("CatAction")]
    public event DataGridViewColumnEventHandler ColumnRemoved;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property for a column changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewColumnSortModeChangedDescr")]
    [SRCategory("CatBehavior")]
    public event DataGridViewColumnEventHandler ColumnSortModeChanged;

    /// <summary>Occurs when a column changes state, such as gaining or losing focus.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnStateChangedDescr")]
    [SRCategory("CatBehavior")]
    public event DataGridViewColumnStateChangedEventHandler ColumnStateChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.ToolTipText"></see> property value changes for a column in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnToolTipTextChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewColumnEventHandler ColumnToolTipTextChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Width"></see> property for a column changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAction")]
    [SRDescription("DataGridView_ColumnWidthChangedDescr")]
    public event DataGridViewColumnEventHandler ColumnWidthChanged
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED, (Delegate) value);
    }

    /// <summary>Occurs when the column header mouse click.</summary>
    [SRCategory("CatAction")]
    [SRDescription("DataGridView_ColumnHeaderMouseClick")]
    public event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CurrentCellChanged event.</summary>
    private EventHandler CurrentCellChangedHandler => (EventHandler) this.GetHandler(DataGridView.CurrentCellChangedEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.CurrentCell"></see> property changes.</summary>
    [SRCategory("CatAction")]
    [SRDescription("DataGridView_CurrentCellChangedDescr")]
    public event EventHandler CurrentCellChanged
    {
      add => this.AddCriticalHandler(DataGridView.CurrentCellChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(DataGridView.CurrentCellChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the group header formatting handler.</summary>
    private GroupHeaderFormattingEventHandler GroupHeaderFormattingHandler => (GroupHeaderFormattingEventHandler) this.GetHandler(DataGridView.GroupHeaderFormattingEvent);

    /// <summary>Occurs when [group header formatting].</summary>
    public event GroupHeaderFormattingEventHandler GroupHeaderFormatting
    {
      add => this.AddHandler(DataGridView.GroupHeaderFormattingEvent, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.GroupHeaderFormattingEvent, (Delegate) value);
    }

    /// <summary>Gets the grouping changed event handler.</summary>
    private GroupingChangedEventHandler GroupingChangedEventHandler => (GroupingChangedEventHandler) this.GetHandler(DataGridView.GroupingChangedEvent);

    /// <summary>Occurs when [grouping changed].</summary>
    public event GroupingChangedEventHandler GroupingChanged
    {
      add => this.AddHandler(DataGridView.GroupingChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.GroupingChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when the state of a cell changes in relation to a change in its contents.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("DataGridView_CurrentCellDirtyStateChangedDescr")]
    public event EventHandler CurrentCellDirtyStateChanged;

    /// <summary>Occurs after a data-binding operation has finished.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_DataBindingCompleteDescr")]
    [SRCategory("CatData")]
    public event DataGridViewBindingCompleteEventHandler DataBindingComplete;

    /// <summary>Occurs when an external data-parsing or validation operation throws an exception, or when an attempt to commit data to a data source fails.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_DataErrorDescr")]
    public event DataGridViewDataErrorEventHandler DataError;

    /// <summary>Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataMember"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewDataMemberChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler DataMemberChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewDataSourceChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler DataSourceChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DefaultCellStyle"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewDefaultCellStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler DefaultCellStyleChanged;

    /// <summary>Occurs when the user enters the row for new records so that it can be populated with default values.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [SRDescription("DataGridView_DefaultValuesNeededDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event DataGridViewRowEventHandler DefaultValuesNeeded;

    /// <summary>Occurs when a control for editing a cell is showing.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_EditingControlShowingDescr")]
    [SRCategory("CatAction")]
    public event DataGridViewEditingControlShowingEventHandler EditingControlShowing;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditMode"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_EditModeChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler EditModeChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.Font"></see> property value changes. </summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public new event EventHandler FontChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.GridColor"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridViewOnGridColorChangedDescr")]
    public event EventHandler GridColorChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.MultiSelect"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewOnMultiSelectChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler MultiSelectChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is true and the user navigates to the new row at the bottom of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [SRDescription("DataGridView_NewRowNeededDescr")]
    public event DataGridViewRowEventHandler NewRowNeeded;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ReadOnly"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridViewOnReadOnlyChangedDescr")]
    public event EventHandler ReadOnlyChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.ContextMenuStrip"></see> property changes.</summary>
    [SRDescription("DataGridView_RowContextMenuStripChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewRowEventHandler RowContextMenuStripChanged;

    /// <summary>Occurs when a row's shortcut menu is needed.</summary>
    [SRCategory("CatData")]
    [SRDescription("DataGridView_RowContextMenuStripNeededDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event DataGridViewRowContextMenuStripNeededEventHandler RowContextMenuStripNeeded;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property for a row changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowDefaultCellStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewRowEventHandler RowDefaultCellStyleChanged;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is true and the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> needs to determine whether the current row has uncommitted changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowDirtyStateNeededDescr")]
    [SRCategory("CatData")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event QuestionEventHandler RowDirtyStateNeeded;

    /// <summary>Occurs when the user double-clicks the divider between two rows.</summary>
    [SRDescription("DataGridView_RowDividerDoubleClickDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewRowDividerDoubleClickEventHandler RowDividerDoubleClick;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.DividerHeight"></see> property changes. </summary>
    [SRDescription("DataGridView_RowDividerHeightChangedDescr")]
    [SRCategory("CatAppearance")]
    public event DataGridViewRowEventHandler RowDividerHeightChanged;

    /// <summary>Occurs when a row receives input focus and becomes the current row.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowEnterDescr")]
    [SRCategory("CatFocus")]
    public event DataGridViewCellEventHandler RowEnter;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.ErrorText"></see> property of a row changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowErrorTextChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewRowEventHandler RowErrorTextChanged;

    /// <summary>Occurs when a row's error text is needed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [SRDescription("DataGridView_RowErrorTextNeededDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event DataGridViewRowErrorTextNeededEventHandler RowErrorTextNeeded;

    /// <summary>Occurs when the user changes the contents of a row header cell.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowHeaderCellChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewRowEventHandler RowHeaderCellChanged;

    /// <summary>Occurs when the user clicks within the boundaries of a row header.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowHeaderMouseClickDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellMouseEventHandler RowHeaderMouseClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK, (Delegate) value);
    }

    /// <summary>Occurs when a row header is double-clicked.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowHeaderMouseDoubleClickDescr")]
    [SRCategory("CatMouse")]
    public event DataGridViewCellMouseEventHandler RowHeaderMouseDoubleClick
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK, (Delegate) value);
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersBorderStyle"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowHeadersBorderStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler RowHeadersBorderStyleChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersDefaultCellStyle"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridViewRowHeadersDefaultCellStyleChangedDescr")]
    public event EventHandler RowHeadersDefaultCellStyleChanged;

    /// <summary>Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidth"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridViewRowHeadersWidthChangedDescr")]
    public event EventHandler RowHeadersWidthChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeMode"></see> property changes.</summary>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridView_RowHeadersWidthSizeModeChangedDescr")]
    public event DataGridViewAutoSizeModeEventHandler RowHeadersWidthSizeModeChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Height"></see> property for a row changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowHeightChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event DataGridViewRowEventHandler RowHeightChanged
    {
      add => this.AddHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEIGHTCHANGED, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEIGHTCHANGED, (Delegate) value);
    }

    /// <summary>Occurs when information about row height is requested. </summary>
    [SRCategory("CatData")]
    [SRDescription("DataGridView_RowHeightInfoNeededDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event DataGridViewRowHeightInfoNeededEventHandler RowHeightInfoNeeded;

    /// <summary>Occurs when the user changes the height of a row.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("DataGridView_RowHeightInfoPushedDescr")]
    [SRCategory("CatData")]
    public event DataGridViewRowHeightInfoPushedEventHandler RowHeightInfoPushed;

    /// <summary>Occurs when a row loses input focus and is no longer the current row.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_RowLeaveDescr")]
    [SRCategory("CatFocus")]
    public event DataGridViewCellEventHandler RowLeave;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.MinimumHeight"></see> property for a row changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("DataGridView_RowMinimumHeightChangedDescr")]
    public event DataGridViewRowEventHandler RowMinimumHeightChanged;

    /// <summary>Occurs after a new row is added to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    [SRDescription("DataGridView_RowsAddedDescr")]
    [SRCategory("CatAction")]
    public event DataGridViewRowsAddedEventHandler RowsAdded;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowsDefaultCellStyle"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewRowsDefaultCellStyleChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler RowsDefaultCellStyleChanged;

    /// <summary>Occurs when a row or rows are deleted from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    [SRCategory("CatAction")]
    [SRDescription("DataGridView_RowsRemovedDescr")]
    public event DataGridViewRowsRemovedEventHandler RowsRemoved;

    /// <summary>Occurs when a row changes state, such as losing or gaining input focus.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_RowStateChangedDescr")]
    public event DataGridViewRowStateChangedEventHandler RowStateChanged;

    /// <summary>Occurs when a row's state changes from shared to unshared.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_RowUnsharedDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event DataGridViewRowEventHandler RowUnshared;

    /// <summary>Occurs after a row has finished validating.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatFocus")]
    [SRDescription("DataGridView_RowValidatedDescr")]
    public event DataGridViewCellEventHandler RowValidated;

    /// <summary>Occurs when a row is validating.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatFocus")]
    [SRDescription("DataGridView_RowValidatingDescr")]
    public event DataGridViewCellCancelEventHandler RowValidating;

    /// <summary>Gets the hanlder for the SelectionChanged event.</summary>
    private EventHandler SelectionChangedHandler => (EventHandler) this.GetHandler(DataGridView.SelectionChangedEvent);

    /// <summary>Occurs when the current selection changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAction")]
    [SRDescription("DataGridView_SelectionChangedDescr")]
    public event EventHandler SelectionChanged
    {
      add => this.AddCriticalHandler(DataGridView.SelectionChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(DataGridView.SelectionChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client selection changed].</summary>
    [SRDescription("Occurs when control's selection changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientSelectionChanged
    {
      add => this.AddClientHandler("SelectionChanged", value);
      remove => this.RemoveClientHandler("SelectionChanged", value);
    }

    /// <summary>Occurs when [client paging changed].</summary>
    [SRDescription("Occurs when control navigated to another page in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientPagingChanged
    {
      add => this.AddClientHandler("Navigate", value);
      remove => this.RemoveClientHandler("Navigate", value);
    }

    [SRDescription("Occurs when user is deleting data row in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientUserDeletingRow
    {
      add => this.AddClientHandler("Delete", value);
      remove => this.RemoveClientHandler("Delete", value);
    }

    /// <summary>Occurs when the current selection changes (queued version).</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAction")]
    [SRDescription("DataGridView_SelectionChangedDescr")]
    public event EventHandler SelectionChangedQueued;

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> compares two cell values to perform a sort operation.</summary>
    [SRCategory("CatData")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("DataGridView_SortCompareDescr")]
    public event DataGridViewSortCompareEventHandler SortCompare;

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control completes a sorting operation.</summary>
    [SRCategory("CatData")]
    [SRDescription("DataGridView_SortedDescr")]
    public event EventHandler Sorted;

    /// <summary>Occurs when the control style changes.</summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public event EventHandler StyleChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.Text"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler TextChanged;

    /// <summary>Occurs when the Text property value changes (Queued).</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler TextChangedQueued;

    /// <summary>Occurs when the user has finished adding a row to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_UserAddedRowDescr")]
    [SRCategory("CatAction")]
    public event DataGridViewRowEventHandler UserAddedRow;

    /// <summary>Occurs when the user has finished deleting a row from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAction")]
    [SRDescription("DataGridView_UserDeletedRowDescr")]
    public event DataGridViewRowEventHandler UserDeletedRow;

    /// <summary>Occurs when the user deletes a row from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAction")]
    [SRDescription("DataGridView_UserDeletingRowDescr")]
    public event DataGridViewRowCancelEventHandler UserDeletingRow;

    /// <summary>Gets the custom filter applying event handler.</summary>
    internal CustomFilterApplyingEventHandler CustomHeaderFilterClickedEventHandler => (CustomFilterApplyingEventHandler) this.GetHandler(DataGridView.CustomHeaderFilterClickedEvent);

    /// <summary>Occurs when [custom header filter clicked].</summary>
    public event CustomFilterApplyingEventHandler CustomHeaderFilterClicked
    {
      add => this.AddHandler(DataGridView.CustomHeaderFilterClickedEvent, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.CustomHeaderFilterClickedEvent, (Delegate) value);
    }

    /// <summary>
    /// Raises the <see cref="E:CustomHeaderFilterClicked" /> event.
    /// </summary>
    /// <param name="objCustomFilterApplyingEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.CustomFilterApplyingEventArgs" /> instance containing the event data.</param>
    internal void OnCustomHeaderFilterClicked(
      CustomFilterApplyingEventArgs objCustomFilterApplyingEventArgs)
    {
      CustomFilterApplyingEventHandler clickedEventHandler = this.CustomHeaderFilterClickedEventHandler;
      if (clickedEventHandler == null)
        return;
      clickedEventHandler((object) this, objCustomFilterApplyingEventArgs);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> class.
    /// </summary>
    public DataGridView()
    {
      this.menmEditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
      this.menmRowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
      this.mobjCurrentCellPoint = new Point(-1, -1);
      this.mintRowHeadersWidth = 41;
      this.mintColumnHeadersHeight = 23;
      this.menmColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      this.mobjAdvancedDataGridViewBorderStyle = new DataGridViewAdvancedBorderStyle(this);
      this.NewRowIndex = -1;
      this.mobjDataGridViewState1[8388635] = true;
      this.mobjDataGridViewState1[128] = true;
      this.mobjDataGridViewState2[100664295] = true;
      this.DisplayedBandsInfo = new DataGridView.DisplayedBandsData();
      this.ColumnHeadersVisible = true;
      this.mobjBackgroundColor = DataGridView.DefaultBackgroundBrush.Color;
      this.DimensionChangeCount = 0;
      this.SelectedBandIndexes = new DataGridViewIntLinkedList();
      this.IndividualSelectedCells = new DataGridViewCellLinkedList();
      this.IndividualReadOnlyCells = new DataGridViewCellLinkedList();
      this.menmSelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
      this.menmExpansionIndicator = ShowExpansionIndicator.CheckOnExpand;
      this.SortOrder = SortOrder.None;
      this.menmScrollBars = ScrollBars.Both;
      this.menmClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
      this.HierarchyLevel = -1;
      this.SetStyle(ControlStyles.Opaque | ControlStyles.UserMouse | ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
      this.LayoutInfo = new DataGridView.LayoutData()
      {
        TopLeftHeader = Rectangle.Empty,
        ColumnHeaders = Rectangle.Empty,
        RowHeaders = Rectangle.Empty,
        ColumnHeadersVisible = true,
        RowHeadersVisible = true
      };
      this.BorderStyle = BorderStyle.FixedSingle;
      this.menmAutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
      this.menmAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
      this.InitializeGroupingStyleProperties();
    }

    /// <summary>Initializes the grouping style properties.</summary>
    private void InitializeGroupingStyleProperties()
    {
      if (!(SkinFactory.GetSkin((ISkinable) this) is DataGridViewSkin skin))
        return;
      this.mobjGroupingAreaBackColor = skin.GroupingDropAreaStyle.BackColor;
      this.mobjGroupingAreaBorderColor = skin.GroupingDropAreaStyle.BorderColor;
      this.mobjGroupingAreaBorderStyle = skin.GroupingDropAreaStyle.BorderStyle;
      this.mobjGroupingAreaBorderWidth = skin.GroupingDropAreaStyle.BorderWidth;
      this.menmGroupingAreaBackgroundImageRepeat = skin.BackgroundImageRepeat;
      this.menmGroupingAreaBackgroundImagePosition = skin.BackgroundImagePosition;
      this.mintGroupingAreaHeight = skin.DropAreaHeight;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.SelectionChangedHandler != null || this.CurrentCellChangedHandler != null || this.IsSelectionChangeCritical)
        criticalEventsData.Set("SLC");
      if (this.ColumnDividerDoubleClickHandler != null)
        criticalEventsData.Set("CDD");
      if ((object) this.RowExpandingHandler != null || (object) this.RowExpandedHandler != null)
        criticalEventsData.Set("EXP");
      if ((object) this.GetHandler(DataGridView.EVENT_ROWCOLLAPSED) != null || (object) this.GetHandler(DataGridView.EVENT_ROWCOLLAPSING) != null)
        criticalEventsData.Set("COL");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("SelectionChanged"))
        clientEventsData.Set("SLC");
      if (this.HasClientHandler("DividerDoubleClick"))
        clientEventsData.Set("CDD");
      if (this.HasClientHandler("Expand"))
        clientEventsData.Set("EXP");
      if (this.HasClientHandler("Collapse"))
        clientEventsData.Set("COL");
      if (this.HasClientHandler("BeginEdit"))
        clientEventsData.Set("BE");
      if (this.HasClientHandler("EndEdit"))
        clientEventsData.Set("EE");
      return clientEventsData;
    }

    /// <summary>
    /// Gets the list of tags that client events are propogated to.
    /// </summary>
    /// <value>The client event propogated tags.</value>
    protected override string ClientEventsPropogationTags => string.Format("WG:{0},WG:{1},WG:{2}", (object) "DR", (object) "DC", (object) "DL");

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      string member = objEvent.Member;
      if (objEvent.Type == "VisualTemplate")
        base.FireEvent(objEvent);
      else if (string.IsNullOrEmpty(member))
      {
        base.FireEvent(objEvent);
        string type = objEvent.Type;
        // ISSUE: reference to a compiler-generated method
        switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(type))
        {
          case 993820015:
            if (!(type == "ColumnsReorder") || !objEvent.Contains("DCN") || !objEvent.Contains("TCN"))
              break;
            int int32_1 = Convert.ToInt32(objEvent["DCN"]);
            int int32_2 = Convert.ToInt32(objEvent["TCN"]);
            if (int32_1 < 0 || int32_1 >= this.Columns.Count || int32_2 < 0 || int32_2 >= this.Columns.Count || this.Columns[int32_1] == null || this.Columns[int32_2] == null)
              break;
            int displayIndex = this.Columns[int32_2].DisplayIndex;
            if (this.Columns[int32_1].DisplayIndex > displayIndex && !(objEvent["BFR"] == "1"))
              ++displayIndex;
            this.Columns[int32_1].DisplayIndex = displayIndex;
            this.Columns.InvalidateCachedColumnsOrder();
            this.Update();
            break;
          case 1221547915:
            if (!(type == "SelectionChanged"))
              break;
            ++this.NoSelectionChangeCount;
            bool flag1 = objEvent["Incremental"] == "1";
            try
            {
              string str = objEvent["VLB"];
              if (str != null)
              {
                bool flag2 = str == "*";
                DataGridViewSelectionMode selectionMode = this.SelectionMode;
                string[] arrValues = str.Split(',');
                foreach (DataGridViewRow dataGridViewRow in this.MultiSelect & flag1 ? (IEnumerable) this.PageRows : (IEnumerable) this.Rows)
                {
                  if (dataGridViewRow.Visible | flag2)
                  {
                    if (selectionMode == DataGridViewSelectionMode.CellSelect || selectionMode == DataGridViewSelectionMode.RowHeaderSelect)
                    {
                      foreach (DataGridViewCell cell in (BaseCollection) dataGridViewRow.Cells)
                      {
                        if (cell.Selected)
                        {
                          if (!flag2 && !this.HasValue(arrValues, cell.MemberIDInternal))
                          {
                            cell.ClientState |= DataGridViewElementClientStates.Selected;
                            this.SetSelectedCellCore(cell.ColumnIndex, cell.RowIndex, false, true);
                            cell.ClientState &= ~DataGridViewElementClientStates.Selected;
                          }
                        }
                        else if (flag2 || this.HasValue(arrValues, cell.MemberIDInternal))
                        {
                          cell.ClientState |= DataGridViewElementClientStates.Selected;
                          this.SetSelectedCellCore(cell.ColumnIndex, cell.RowIndex, true, true);
                          cell.ClientState &= ~DataGridViewElementClientStates.Selected;
                        }
                      }
                    }
                    if (selectionMode == DataGridViewSelectionMode.FullRowSelect || selectionMode == DataGridViewSelectionMode.RowHeaderSelect)
                    {
                      if (dataGridViewRow.Selected)
                      {
                        if (!flag2 && !this.HasValue(arrValues, dataGridViewRow.MemberIDInternal))
                        {
                          dataGridViewRow.ClientState |= DataGridViewElementClientStates.Selected;
                          this.SetSelectedRowCore(dataGridViewRow.Index, false, true);
                          dataGridViewRow.ClientState &= ~DataGridViewElementClientStates.Selected;
                        }
                      }
                      else if (flag2 || this.HasValue(arrValues, dataGridViewRow.MemberIDInternal))
                      {
                        dataGridViewRow.ClientState |= DataGridViewElementClientStates.Selected;
                        this.SetSelectedRowCore(dataGridViewRow.Index, true, true);
                        dataGridViewRow.ClientState &= ~DataGridViewElementClientStates.Selected;
                      }
                    }
                  }
                }
              }
              if (!objEvent.Contains("CRC"))
                break;
              Point memberPosition = this.GetMemberPosition(objEvent["CRC"]);
              if (this.IsInnerCellOutOfBounds(memberPosition.X, memberPosition.Y) || !this.PageRows.Contains((object) this.Rows.SharedRow(memberPosition.Y)))
                break;
              bool blnValidateCurrentCell = this.mobjCurrentCellPoint.Y != memberPosition.Y || this.mobjCurrentCellPoint.X != memberPosition.X;
              this[memberPosition.X, memberPosition.Y].ClientState |= DataGridViewElementClientStates.CurrentCell;
              this.SetCurrentCellAddressCore(memberPosition.X, memberPosition.Y, true, blnValidateCurrentCell, false, true);
              if (this.IsInnerCellOutOfBounds(memberPosition.X, memberPosition.Y))
                break;
              this[memberPosition.X, memberPosition.Y].ClientState &= ~DataGridViewElementClientStates.CurrentCell;
              break;
            }
            finally
            {
              --this.NoSelectionChangeCount;
            }
          case 1469573738:
            if (!(type == "Delete") || !this.ProcessDeleteKey(Keys.Delete))
              break;
            this.Update();
            this.SetFocus();
            break;
          case 1944243723:
            if (!(type == "InsertGroup"))
              break;
            string strTargetDataPropertyName = objEvent["TCN"] ?? string.Empty;
            string str1 = objEvent["DCN"];
            if (string.IsNullOrEmpty(str1))
              break;
            this.InsertGroupingColumn(strTargetDataPropertyName, str1);
            this.OnGroupingChanged(DataGridViewGroupingAction.Add, str1);
            break;
          case 2045844646:
            if (!(type == "Navigate"))
              break;
            string s = objEvent["To"];
            switch (s)
            {
              case "End":
                this.CurrentPage = this.TotalPages;
                break;
              case "Home":
                this.CurrentPage = 1;
                break;
              case "Next":
                if (this.CurrentPage < this.TotalPages)
                {
                  ++this.CurrentPage;
                  break;
                }
                break;
              case "Back":
                if (this.CurrentPage > 1)
                {
                  --this.CurrentPage;
                  break;
                }
                break;
              default:
                int result;
                if (int.TryParse(s, out result) && result > 0 && result <= this.TotalPages)
                {
                  this.CurrentPage = result;
                  break;
                }
                break;
            }
            EventHandler pagingChangedHandler = this.PagingChangedHandler;
            if (pagingChangedHandler == null)
              break;
            pagingChangedHandler((object) this, EventArgs.Empty);
            break;
          case 2359582348:
            if (!(type == "OpenColumnChooser"))
              break;
            this.ShowColumnPickerDialog();
            break;
          case 2723052125:
            if (!(type == "ClearFilters"))
              break;
            this.ClearAllFilters();
            break;
        }
      }
      else if (member.StartsWith("DGVB"))
      {
        int result = -1;
        if (!int.TryParse(member.Substring(4), out result) || !(objEvent.Type == "Load"))
          return;
        DataGridView.DataGridRowBlockInfo blockInfo = this.GetBlockInfo(result);
        if (blockInfo == null)
          return;
        blockInfo.LoadRows();
        blockInfo.Update();
      }
      else
      {
        Point memberPosition = this.GetMemberPosition(member);
        if (memberPosition.X != -1 && memberPosition.Y != -1)
        {
          switch (member[0])
          {
            case 'C':
              this.Columns[memberPosition.X].FireEvent(objEvent);
              break;
            case 'D':
              this.Rows.SharedRow(memberPosition.Y)?.Cells[memberPosition.X].FireEvent(objEvent);
              break;
            case 'R':
              (!this.ShowFilterRow ? this.Rows.SharedRow(memberPosition.Y) : (memberPosition.Y != 0 ? this.Rows.SharedRow(memberPosition.Y - 1) : (DataGridViewRow) this.mobjDataGridViewFilterRow))?.FireEvent(objEvent);
              break;
          }
        }
        else if (memberPosition.X != -1)
          this.Columns[memberPosition.X].HeaderCell?.FireEvent(objEvent);
        else if (memberPosition.Y != -1)
        {
          this.Rows[memberPosition.Y].HeaderCell?.FireEvent(objEvent);
        }
        else
        {
          if (!(member == this.TopLeftHeaderCell.MemberIDInternal))
            return;
          this.TopLeftHeaderCell.FireEvent(objEvent);
        }
      }
    }

    /// <summary>Called when [grouping changed].</summary>
    /// <param name="strColumnDataPropertyName">Name of the STR dragged column data property.</param>
    internal void OnGroupingChanged(
      DataGridViewGroupingAction enmAction,
      string strColumnDataPropertyName)
    {
      if (string.IsNullOrEmpty(strColumnDataPropertyName))
        return;
      DataGridViewColumnCollection columns = this.Columns;
      DataGridViewColumn objColumn = columns[columns.GetRealDataMemberForProposedMember(strColumnDataPropertyName)];
      if (objColumn == null || this.GroupingChangedEventHandler == null)
        return;
      this.GroupingChangedEventHandler((object) this, new GroupingChangedEventArgs(enmAction, objColumn));
    }

    /// <summary>Clears all filters.</summary>
    public void ClearAllFilters()
    {
      this.mblnSuspendFilterInitialization = true;
      try
      {
        if (this.ShowFilterRow && this.mobjDataGridViewFilterRow != null)
        {
          foreach (DataGridViewFilterCell cell in (BaseCollection) this.mobjDataGridViewFilterRow.Cells)
            cell.ClearFilter(true);
        }
        else
        {
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
            column.ClearFilter(true);
        }
      }
      finally
      {
        this.mblnSuspendFilterInitialization = false;
      }
      this.ApplyDataGridViewFilter();
    }

    /// <summary>Sets the focus abck to the grid.</summary>
    private void SetFocus()
    {
      if (!(this.Context is IApplicationContext context))
        return;
      context.SetFocused((IControl) this, true);
    }

    /// <summary>Sets the selected cell core.</summary>
    /// <param name="intColumnIndex">Index of the int column.</param>
    /// <param name="intRowIndex">Index of the int row.</param>
    /// <param name="blnSelected">if set to <c>true</c> [BLN selected].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    private void SetSelectedCellCore(
      int intColumnIndex,
      int intRowIndex,
      bool blnSelected,
      bool blnClientSource)
    {
      if (intColumnIndex < 0 || intColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("columnIndex");
      DataGridViewRowCollection rows = this.Rows;
      if (intRowIndex < 0 || intRowIndex >= rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
      DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
      if (this.IsSharedCellSelected(dataGridViewRow.Cells[intColumnIndex], intRowIndex) == blnSelected)
        return;
      DataGridViewCell cell1 = rows[intRowIndex].Cells[intColumnIndex];
      DataGridViewIntLinkedList viewIntLinkedList = (DataGridViewIntLinkedList) null;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      if (blnSelected)
      {
        if ((rowState & DataGridViewElementStates.Selected) != DataGridViewElementStates.None || this.Columns[intColumnIndex].Selected)
          return;
        individualSelectedCells.Add(cell1);
        this.SetSelectedCellCore(cell1, true, blnClientSource);
      }
      else
      {
        if ((cell1.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
        {
          individualSelectedCells.Remove(cell1);
        }
        else
        {
          bool flag = false;
          if (this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
          {
            if (this.Rows.Count > 8)
            {
              ++this.BulkPaintCount;
              flag = true;
            }
            try
            {
              this.SelectedBandIndexes.Remove(intColumnIndex);
              this.Columns[intColumnIndex].SelectedInternal = false;
              for (int index = 0; index < intRowIndex; ++index)
              {
                DataGridViewCell cell2 = rows[index].Cells[intColumnIndex];
                this.SetSelectedCellCore(cell2, true, blnClientSource);
                individualSelectedCells.Add(cell2);
              }
              for (int index = intRowIndex + 1; index < rows.Count; ++index)
              {
                DataGridViewCell cell3 = rows[index].Cells[intColumnIndex];
                this.SetSelectedCellCore(cell3, true, blnClientSource);
                individualSelectedCells.Add(cell3);
              }
              if (!cell1.Selected)
                return;
              this.SetSelectedCellCore(cell1, false, blnClientSource);
              return;
            }
            finally
            {
              if (flag)
                this.ExitBulkPaint(intColumnIndex, -1);
            }
          }
          else if (this.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
          {
            if (this.Columns.Count > 8)
            {
              ++this.BulkPaintCount;
              flag = true;
            }
            try
            {
              if (viewIntLinkedList == null)
                viewIntLinkedList = this.SelectedBandIndexes;
              viewIntLinkedList.Remove(intRowIndex);
              rows.SetRowState(intRowIndex, DataGridViewElementStates.Selected, false);
              for (int index = 0; index < intColumnIndex; ++index)
              {
                DataGridViewCell cell4 = rows[intRowIndex].Cells[index];
                this.SetSelectedCellCore(cell4, true, blnClientSource);
                individualSelectedCells.Add(cell4);
              }
              for (int index = intColumnIndex + 1; index < this.Columns.Count; ++index)
              {
                DataGridViewCell cell5 = rows[intRowIndex].Cells[index];
                this.SetSelectedCellCore(cell5, true, blnClientSource);
                individualSelectedCells.Add(cell5);
              }
            }
            finally
            {
              if (flag)
                this.ExitBulkPaint(-1, intRowIndex);
            }
          }
        }
        if (!cell1.Selected)
          return;
        this.SetSelectedCellCore(cell1, false, blnClientSource);
      }
    }

    /// <summary>Sets the selected cell core.</summary>
    /// <param name="objDataGridViewCell">The obj data grid view cell.</param>
    /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    internal void SetSelectedCellCore(
      DataGridViewCell objDataGridViewCell,
      bool blnValue,
      bool blnClientSource)
    {
      if (objDataGridViewCell == null)
        return;
      if (!blnClientSource && (objDataGridViewCell.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected != blnValue)
        objDataGridViewCell.UpdateParams(AttributeType.Visual);
      objDataGridViewCell.SelectedInternal = blnValue;
    }

    /// <summary>Gets the member position.</summary>
    /// <param name="strMember">The STR member.</param>
    /// <returns></returns>
    internal Point GetMemberPosition(string strMember)
    {
      Point memberPosition = new Point(-1, -1);
      if (!string.IsNullOrEmpty(strMember))
      {
        if (strMember.Contains("GHC"))
          memberPosition = new Point(-1, -1);
        else if (strMember.Contains("HC"))
        {
          int num = int.Parse(strMember.Substring(3));
          memberPosition = !strMember.Contains("RHC") ? new Point(num, -1) : new Point(-1, num);
        }
        else
        {
          int num1 = int.Parse(strMember.Substring(1));
          switch (strMember[0])
          {
            case 'C':
            case 'R':
              ref Point local = ref memberPosition;
              int num2 = num1;
              local = new Point(num2, num2);
              break;
            case 'D':
              int num3 = (int) Math.Floor((double) (num1 / this.ColumnCount));
              memberPosition = new Point(num1 - num3 * this.ColumnCount, num3 - (!this.ShowFilterRow || num3 <= 0 ? 0 : 1));
              break;
          }
        }
      }
      return memberPosition;
    }

    /// <summary>Checks if a string collection has value</summary>
    /// <param name="arrValues"></param>
    /// <param name="strValue"></param>
    /// <returns></returns>
    private bool HasValue(string[] arrValues, string strValue)
    {
      foreach (string arrValue in arrValues)
      {
        if (arrValue == strValue)
          return true;
      }
      return false;
    }

    /// <summary>Renders the row data.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    private void RenderRowData(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      objWriter.WriteStartElement("XCR");
      foreach (ExtendedHeaderRowData row in (Collection<ExtendedHeaderRowData>) this.mobjExtendedColumnHeaders.Rows)
        row.RenderRow(objWriter);
      objWriter.WriteEndElement();
    }

    /// <summary>
    /// Renders the user controls in extended column header cells collection.
    /// </summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    private void RenderExtendedColumnHeaderCellUserControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      objWriter.WriteStartElement("XC");
      foreach (Control headerControl in (Collection<ExtendedHeaderUserControl>) this.mobjExtendedColumnHeaders.HeaderControls)
        headerControl.RenderControl(objContext, objWriter, lngRequestID);
      objWriter.WriteEndElement();
    }

    /// <summary>
    /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
    /// </summary>
    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      if (this.mobjCurrentCellPoint.X != -1)
        this.ScrollIntoView(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y, false);
      this.OnGlobalAutoSize();
    }

    /// <summary>Pre-render control.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
    {
      if (this.IsDirty(lngRequestID))
      {
        if (this.ShouldPreRenderUpdate(DataGridView.PreRenderUpdateType.GroupingData))
          this.InitializeGroupingData();
        if (this.ShouldPreRenderUpdate(DataGridView.PreRenderUpdateType.GroupHeaders))
          this.PreRenderGroupingData();
        if (this.ShouldPreRenderUpdate(DataGridView.PreRenderUpdateType.FilterRow))
          this.PreRenderFilterRowCells();
      }
      this.PreRenderTopLeftHeaderCell(objContext, lngRequestID, this.IsDirty(lngRequestID));
      this.PreRenderColumns(objContext, lngRequestID, this.IsDirty(lngRequestID));
      this.PreRenderRows(objContext, lngRequestID, this.IsDirty(lngRequestID));
      base.PreRenderControl(objContext, lngRequestID);
    }

    /// <summary>Initializes grouping system hierarchies and treeview.</summary>
    private void InitializeGroupingData()
    {
      this.ResetDataBinding();
      if (this.HideGroupedColumns)
      {
        UniqueObservableCollection<string> groupingColumns = this.GroupingColumns;
        DataGridViewColumnCollection columns = this.Columns;
        foreach (string strFilteringDataMember in (Collection<string>) groupingColumns)
        {
          string forProposedMember = columns.GetRealDataMemberForProposedMember(strFilteringDataMember);
          if (!string.IsNullOrEmpty(forProposedMember))
            columns[forProposedMember].Visible = false;
        }
      }
      if (this.mobjGroupingTreeView == null)
        this.mobjGroupingTreeView = new DataGridViewGroupingTreeView(this);
      else
        this.mobjGroupingTreeView.InitializeGroupingNodes();
      this.SwitchPreRenderUpdate(~DataGridView.PreRenderUpdateType.GroupingData);
    }

    /// <summary>Prerenders filter row cells.</summary>
    private void PreRenderFilterRowCells()
    {
      this.InitializeFilterRow();
      this.SwitchPreRenderUpdate(~DataGridView.PreRenderUpdateType.FilterRow);
    }

    /// <summary>Posts the render control.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal override void PostRenderControl(IContext objContext, long lngRequestID)
    {
      base.PostRenderControl(objContext, lngRequestID);
      this.PostRenderTopLeftHeaderCell(objContext, lngRequestID, this.IsDirty(lngRequestID));
      this.PostRenderColumns(objContext, lngRequestID, this.IsDirty(lngRequestID));
      this.PostRenderRows(objContext, lngRequestID, this.IsDirty(lngRequestID));
    }

    /// <summary>Pres the render control internal.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    internal void PreRenderControlInternal(IContext objContext, long lngRequestID) => this.PreRenderControl(objContext, lngRequestID);

    /// <summary>Posts the render control internal.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    internal void PostRenderControlInternal(IContext objContext, long lngRequestID) => this.PostRenderControl(objContext, lngRequestID);

    /// <summary>Pres the render top left header cell.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    private void PreRenderTopLeftHeaderCell(
      IContext objContext,
      long lngRequestID,
      bool blnForcePreRender)
    {
      this.TopLeftHeaderCell?.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
    }

    /// <summary>Posts the render top left header cell.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
    private void PostRenderTopLeftHeaderCell(
      IContext objContext,
      long lngRequestID,
      bool blnForcePostRender)
    {
      this.TopLeftHeaderCell?.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
    }

    /// <summary>
    /// Checks if the current control needs rendering and
    /// continues to process sub tree/
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected internal override void RenderControl(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      base.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the control's meta attributes</summary>
    /// <param name="objContext">The current VWG Context</param>
    /// <param name="objWriter">The XML stream writer</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.IsVirtualDataGridView)
        objWriter.WriteAttributeString("VR", "1");
      this.RenderStandardTabAttribute(objWriter, false);
      this.RenderEnforceEqualRowSizeAttribute(objWriter, false);
      this.RenderIsCaptionVisibleAttribute(objWriter, false);
      this.RenderCaptionHeightAttribute(objWriter, false);
      this.RenderShowGroupingDropAreaAttribute(objWriter, false);
      this.RenderGroupingAreaStyleProperties(objWriter, objContext, false);
      IAttributeWriter attributeWriter1 = objWriter;
      int num1 = (int) this.SupportedSelectionMode;
      string strValue1 = num1.ToString();
      attributeWriter1.WriteAttributeString("SM", strValue1);
      this.RenderTextAttribute(objWriter, false);
      this.RenderDisableNavigation(objWriter, false);
      this.RenderScrollbarsAttribute(objWriter, false);
      this.RenderCurrentCell(objContext, objWriter, false);
      if (this.IsHierarchic(HierarchicInfoSelector.Any))
        this.RenderHierarchicAttributes(objWriter);
      objWriter.WriteAttributeString("DGVHL", this.mintHierarchyLevel.ToString());
      IAttributeWriter attributeWriter2 = objWriter;
      num1 = this.CurrentPage;
      string strValue2 = num1.ToString();
      attributeWriter2.WriteAttributeString("CP", strValue2);
      IAttributeWriter attributeWriter3 = objWriter;
      num1 = this.TotalPages;
      string strValue3 = num1.ToString();
      attributeWriter3.WriteAttributeString("TOP", strValue3);
      this.RenderMultiSelect(objWriter, false);
      this.RenderShowEditingIcon(objWriter, false);
      if (!this.RowHeadersVisible)
      {
        objWriter.WriteAttributeString("RHS", "0");
      }
      else
      {
        IAttributeWriter attributeWriter4 = objWriter;
        num1 = this.RowHeadersWidth;
        string strValue4 = num1.ToString();
        attributeWriter4.WriteAttributeString("RHS", strValue4);
      }
      if (!this.ColumnHeadersVisible)
      {
        objWriter.WriteAttributeString("CHS", "0");
      }
      else
      {
        IAttributeWriter attributeWriter5 = objWriter;
        num1 = this.ColumnHeadersHeight;
        string strValue5 = num1.ToString();
        attributeWriter5.WriteAttributeString("CHS", strValue5);
      }
      if (this.CellBorderStyle != DataGridViewCellBorderStyle.Single)
        objWriter.WriteAttributeString("CBS", ((byte) this.CellBorderStyle).ToString());
      if (this.ReadOnly)
        objWriter.WriteAttributeString("RO", "1");
      if (this.IsVirtualDataGridView)
      {
        IAttributeWriter attributeWriter6 = objWriter;
        num1 = this.Rows.Count + (this.ShowFilterRow ? 1 : 0);
        string strValue6 = num1.ToString();
        attributeWriter6.WriteAttributeString("RCT", strValue6);
        int num2 = this.UseInternalPaging ? this.ItemsPerPage : this.VirtualBlockSize;
        objWriter.WriteAttributeString("VBS", num2.ToString());
      }
      this.RenderColumnsCount(objWriter);
      this.RenderAllowUserToOrderColumns(objWriter, false);
      this.RenderSelectOnRightClick(objWriter, false);
      this.RenderEditModeAttribute(objWriter, false);
      this.RenderShowColumnChooserAttribute(objWriter, false);
      this.RenderNavigationKeyFilterAttribute(objWriter, false);
    }

    /// <summary>Renders the navigation key filter attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderNavigationKeyFilterAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!(this.menmNavigationKeyFilter != 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("NKF", ((int) this.menmNavigationKeyFilter).ToString());
    }

    /// <summary>Renders the grouping area style properties.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objContext">The obj context.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderGroupingAreaStyleProperties(
      IAttributeWriter objWriter,
      IContext objContext,
      bool blnForceRender)
    {
      if (!(SkinFactory.GetSkin((ISkinable) this) is DataGridViewSkin skin))
        return;
      if (this.GroupingAreaStyleProperties.BackColor != skin.GroupingDropAreaStyle.BackColor | blnForceRender)
        objWriter.WriteAttributeText("GABG", CommonUtils.GetHtmlColor(this.GroupingAreaBackColor));
      if (this.ShouldRenderGroupingAreaBorder(skin) | blnForceRender)
        objWriter.WriteAttributeString("GABR", new BorderValue()
        {
          Width = this.GroupingAreaBorderWidth,
          Color = this.GroupingAreaBorderColor,
          Style = this.GroupingAreaBorderStyle
        }.GetValue(objContext));
      if (this.GroupingAreaBackgroundImage != null)
        objWriter.WriteAttributeString("GABI", this.GroupingAreaBackgroundImage.ToString());
      if (this.ShouldRenderGroupingAreaBackgroundImagePosition(skin) | blnForceRender)
        objWriter.WriteAttributeString("GABIP", (int) this.GroupingAreaBackgroundImagePosition);
      if (this.ShouldRenderGroupingAreaBackgroundImageRepeat(skin) | blnForceRender)
        objWriter.WriteAttributeString("GABIR", (int) this.GroupingAreaBackgroundImageRepeat);
      if (!(this.ShouldRenderGroupingAreaHeight(skin) | blnForceRender))
        return;
      objWriter.WriteAttributeString("DAH", this.GroupingAreaHeight);
    }

    /// <summary>Defines whether to render grouping area border.</summary>
    /// <param name="objSkin">The obj skin.</param>
    /// <returns></returns>
    private bool ShouldRenderGroupingAreaBorder(DataGridViewSkin objSkin) => this.GroupingAreaBorderColor != objSkin.GroupingDropAreaStyle.BorderColor && this.GroupingAreaBorderStyle != objSkin.GroupingDropAreaStyle.BorderStyle && this.GroupingAreaBorderWidth != objSkin.GroupingDropAreaStyle.BorderWidth;

    /// <summary>
    ///  Defines whether to render grouping area background image repeat.
    /// </summary>
    /// <param name="objSkin">The obj skin.</param>
    /// <returns></returns>
    private bool ShouldRenderGroupingAreaBackgroundImageRepeat(DataGridViewSkin objSkin) => this.GroupingAreaBackgroundImageRepeat != objSkin.GroupingDropAreaStyle.BackgroundImageRepeat;

    /// <summary>Defines whether to render grouping area height.</summary>
    /// <param name="objSkin">The obj skin.</param>
    /// <returns></returns>
    private bool ShouldRenderGroupingAreaHeight(DataGridViewSkin objSkin) => this.GroupingAreaHeight != objSkin.DropAreaHeight;

    /// <summary>
    ///  Defines whether to render grouping area background image Position.
    /// </summary>
    /// <param name="objSkin">The obj skin.</param>
    /// <returns></returns>
    private bool ShouldRenderGroupingAreaBackgroundImagePosition(DataGridViewSkin objSkin) => this.GroupingAreaBackgroundImagePosition != objSkin.GroupingDropAreaStyle.BackgroundImagePosition;

    /// <summary>Renders the hidden columns count.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderColumnsCount(IAttributeWriter objWriter) => objWriter.WriteAttributeString("ACH", this.Columns.Count);

    /// <summary>Renders the show grouping drop area attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowGroupingDropAreaAttribute(
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      if (!blnForceRender && !this.ShowGroupingDropArea)
        return;
      objWriter.WriteAttributeText("SGDA", this.ShowGroupingDropArea ? "1" : "0");
    }

    /// <summary>Renders the scrollbars attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderScrollbarsAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!blnForceRender && this.ScrollBars == ScrollBars.Both)
        return;
      objWriter.WriteAttributeString("SB", ((int) this.ScrollBars).ToString());
    }

    /// <summary>Renders the hierarchic attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderHierarchicAttributes(IAttributeWriter objWriter)
    {
      objWriter.WriteAttributeText("IHC", "1");
      if (this.IsHierarchic(HierarchicInfoSelector.Bounded))
        objWriter.WriteAttributeString("BOD", "1");
      this.RenderExpansionIndicator(objWriter, false);
    }

    /// <summary>Renders the expansion indicator.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderExpansionIndicator(IAttributeWriter objWriter, bool blnForceRender)
    {
      ShowExpansionIndicator expansionIndicator = this.ExpansionIndicator;
      if (!(expansionIndicator != ShowExpansionIndicator.CheckOnExpand | blnForceRender))
        return;
      objWriter.WriteAttributeString("EIN", ((int) expansionIndicator).ToString());
    }

    /// <summary>Renders the text attribute.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderTextAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      string text = this.Text;
      if (!(!string.IsNullOrEmpty(text) | blnForceRender))
        return;
      objWriter.WriteAttributeText("TX", text);
    }

    /// <summary>Renders the edit mode attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderEditModeAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      DataGridViewEditMode editMode = this.EditMode;
      if (!(editMode != DataGridViewEditMode.EditOnKeystrokeOrF2 | blnForceRender))
        return;
      objWriter.WriteAttributeString("EMD", ((int) editMode).ToString());
    }

    /// <summary>Renders the standard tab attribute.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderStandardTabAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool standardTab = this.StandardTab;
      if (!(standardTab | blnForceRender))
        return;
      objWriter.WriteAttributeString("STAB", standardTab ? "1" : "0");
    }

    /// <summary>Renders the allow user to order columns.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> force render.</param>
    private void RenderAllowUserToOrderColumns(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.AllowUserToOrderColumns)
      {
        objWriter.WriteAttributeString("AOC", "1");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("AOC", "0");
      }
    }

    /// <summary>Renders the select on right click.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool selectOnRightClick = this.SelectOnRightClick;
      if (!(selectOnRightClick | blnForceRender))
        return;
      objWriter.WriteAttributeString("SOR", selectOnRightClick ? "1" : "0");
    }

    /// <summary>Renders the show column chooser attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowColumnChooserAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool showColumnChooser = this.ShowColumnChooser;
      if (!(showColumnChooser | blnForceRender))
        return;
      objWriter.WriteAttributeString("CCH", showColumnChooser ? "1" : "0");
    }

    /// <summary>Renders the disable navigation.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> force render.</param>
    private void RenderDisableNavigation(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.DisableNavigation)
      {
        objWriter.WriteAttributeString("DNV", "1");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("DNV", "0");
      }
    }

    /// <summary>Renders the multi select.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> force render.</param>
    private void RenderMultiSelect(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!this.MultiSelect)
      {
        objWriter.WriteAttributeString("MU", "0");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("MU", "1");
      }
    }

    /// <summary>Renders the show editing icon.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowEditingIcon(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!this.ShowEditingIcon)
      {
        objWriter.WriteAttributeString("SEI", "0");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("SEI", "1");
      }
    }

    /// <summary>Renders only the control's updated meta attributes</summary>
    /// <param name="objContext">The current VWG Context</param>
    /// <param name="objWriter">The XML stream writer</param>
    /// <param name="lngRequestID">The ID of the request currently being handled</param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        this.RenderAllowUserToOrderColumns(objWriter, true);
        this.RenderDisableNavigation(objWriter, true);
        this.RenderMultiSelect(objWriter, true);
        this.RenderStandardTabAttribute(objWriter, true);
        this.RenderSelectOnRightClick(objWriter, true);
        this.RenderEditModeAttribute(objWriter, true);
        this.RenderTextAttribute(objWriter, true);
        this.RenderExpansionIndicator(objWriter, true);
        this.RenderShowColumnChooserAttribute(objWriter, true);
        this.RenderShowEditingIcon(objWriter, true);
        this.RenderNavigationKeyFilterAttribute(objWriter, true);
      }
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
      {
        objWriter.WriteAttributeString("CBS", ((byte) this.CellBorderStyle).ToString());
        this.RenderCurrentCell(objContext, objWriter, true);
        this.RenderGroupingAreaStyleProperties(objWriter, objContext, true);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
        return;
      this.RenderEnforceEqualRowSizeAttribute(objWriter, true);
      this.RenderIsCaptionVisibleAttribute(objWriter, true);
      this.RenderShowGroupingDropAreaAttribute(objWriter, true);
      this.RenderScrollbarsAttribute(objWriter, true);
      this.RenderCaptionHeightAttribute(objWriter, true);
    }

    /// <summary>Renders the resize all rows attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderEnforceEqualRowSizeAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool enforceEqualRowSize = this.EnforceEqualRowSize;
      if (!(enforceEqualRowSize | blnForceRender))
        return;
      objWriter.WriteAttributeString("EER", enforceEqualRowSize ? "1" : "0");
    }

    /// <summary>Renders the is caption visible attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderIsCaptionVisibleAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool isCaptionVisible = this.IsCaptionVisible;
      if (!(isCaptionVisible | blnForceRender))
        return;
      objWriter.WriteAttributeString("ICV", isCaptionVisible ? "1" : "0");
    }

    /// <summary>Renders the caption height attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderCaptionHeightAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!this.IsCaptionVisible)
        return;
      int num = this.CaptionHeight;
      if (num == 0 && this.Skin is DataGridViewSkin skin)
      {
        StyleValue captionStyle = skin.CaptionStyle;
        num = CommonUtils.GetFontHeight(captionStyle.Font) + captionStyle.Padding.Vertical;
      }
      objWriter.WriteAttributeString("CH", num.ToString());
    }

    /// <summary>Renders the current cell.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderCurrentCell(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      if (this.CurrentCell != null)
      {
        objWriter.WriteAttributeString("CRC", this.CurrentCell.MemberIDInternal.ToString());
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("CRC", string.Empty);
      }
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      bool blnRenderOwner = !this.IsDirty(lngRequestID);
      this.RenderExtendedColumnHeader(objContext, objWriter, lngRequestID, blnRenderOwner);
      this.RenderGroupingDropArea(objContext, objWriter, lngRequestID);
      this.RenderTopLeftHeaderCell(objContext, objWriter, lngRequestID, blnRenderOwner);
      this.RenderColumns(objContext, objWriter, lngRequestID, blnRenderOwner);
      this.RenderRows(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Renders the extended column Header.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    private void RenderExtendedColumnHeader(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      if (!this.IsExtendedColumnHeaderVisible())
        return;
      this.RenderRowData(objContext, objWriter, lngRequestID);
      this.RenderExtendedColumnHeaderCellUserControls(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the grouping drop area.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    private void RenderGroupingDropArea(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (!this.ShowGroupingDropArea || this.mobjGroupingTreeView == null || this.mobjGroupingTreeView.Nodes.Count <= 0)
        return;
      ((IRenderableComponent) this.mobjGroupingTreeView).RenderComponent(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the top left header cell.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    private void RenderTopLeftHeaderCell(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      ((IRenderableComponentMember) this.TopLeftHeaderCell)?.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Pres the render columns.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    private void PreRenderColumns(IContext objContext, long lngRequestID, bool blnForcePreRender)
    {
      for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
        objDataGridViewColumnStart.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
    }

    /// <summary>Posts the render columns.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
    private void PostRenderColumns(IContext objContext, long lngRequestID, bool blnForcePostRender)
    {
      for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
        objDataGridViewColumnStart.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
    }

    /// <summary>Renders the columns.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected void RenderColumns(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
        ((IRenderableComponentMember) objDataGridViewColumnStart).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Pres the render rows.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    private void PreRenderRows(IContext objContext, long lngRequestID, bool blnForcePreRender)
    {
      bool blnContainsFrozeRows = false;
      IList rows = this.GetRows(out blnContainsFrozeRows);
      if (rows == null)
        return;
      foreach (DataGridViewElement dataGridViewElement in (IEnumerable) rows)
        dataGridViewElement.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
    }

    /// <summary>Posts the render rows.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
    private void PostRenderRows(IContext objContext, long lngRequestID, bool blnForcePostRender)
    {
      bool blnContainsFrozeRows = false;
      IList rows = this.GetRows(out blnContainsFrozeRows);
      if (rows == null)
        return;
      foreach (DataGridViewElement dataGridViewElement in (IEnumerable) rows)
        dataGridViewElement.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
    }

    /// <summary>Checks whether filter row should be processed.</summary>
    /// <returns></returns>
    private bool ShouldProcessFilterRow() => this.ShowFilterRow && this.mobjDataGridViewFilterRow != null && this.Columns.GetColumnCount(DataGridViewElementStates.Visible) > 0;

    /// <summary>Gets the rows.</summary>
    /// <param name="blnContainsFrozeRows">if set to <c>true</c> [BLN contains froze rows].</param>
    /// <returns></returns>
    private IList GetRows(out bool blnContainsFrozeRows)
    {
      IList rows1 = this.GetPagedRows(out blnContainsFrozeRows);
      if (this.ShouldProcessFilterRow())
      {
        int length = rows1.Count + 1;
        DataGridViewRow[] collection = new DataGridViewRow[length];
        collection[0] = (DataGridViewRow) this.mobjDataGridViewFilterRow;
        for (int index = 1; index < length; ++index)
          collection[index] = rows1[index - 1] as DataGridViewRow;
        rows1 = (IList) new List<DataGridViewRow>((IEnumerable<DataGridViewRow>) collection);
        blnContainsFrozeRows = true;
      }
      DataGridViewRowCollection rows2 = this.Rows;
      if (this.NewRowIndex >= 0 && this.NewRowIndex < rows2.Count)
      {
        DataGridViewRow dataGridViewRow = rows2[this.NewRowIndex];
        if (dataGridViewRow != null && !rows1.Contains((object) dataGridViewRow))
          rows1.Add((object) dataGridViewRow);
      }
      return rows1;
    }

    /// <summary>Renders the datagridview rows.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected void RenderRows(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      if (this.IsVirtualDataGridView)
      {
        if (lngRequestID == 0L && this.mobjDataGridViewBlocksManager != null)
          this.mobjDataGridViewBlocksManager.ClearBlockInfoCache();
        int intTopPosition = 0;
        int scrollTop = this.ScrollTop;
        int height = this.Height;
        foreach (DataGridView.DataGridRowBlock rowBlock in this.GetRowBlocks())
        {
          rowBlock.RenderBlock(objContext, objWriter, lngRequestID, blnRenderOwner, this.IsDirty(lngRequestID), intTopPosition, scrollTop, height);
          intTopPosition += rowBlock.BlockHeight;
        }
      }
      else
      {
        bool blnContainsFrozeRows = false;
        IList rows = this.GetRows(out blnContainsFrozeRows);
        if (rows == null)
          return;
        foreach (DataGridViewRow dataGridViewRow in (IEnumerable) rows)
        {
          if (dataGridViewRow.Visible)
            ((IRenderableComponentMember) dataGridViewRow).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
        }
      }
    }

    /// <summary>Gets the row blocks.</summary>
    /// <returns></returns>
    private IEnumerable<DataGridView.DataGridRowBlock> GetRowBlocks()
    {
      List<DataGridView.DataGridRowBlock> dataGridRowBlockList = new List<DataGridView.DataGridRowBlock>();
      bool blnContainsFrozeRows = false;
      IList rows = this.GetRows(out blnContainsFrozeRows);
      if (rows != null)
      {
        if (this.UseInternalPaging)
        {
          dataGridRowBlockList.Add(new DataGridView.DataGridRowBlock(this, rows, 1, blnContainsFrozeRows));
        }
        else
        {
          List<DataGridViewRow> objBlockRows = new List<DataGridViewRow>();
          bool blnContainsFrozenRows = false;
          for (int index = 0; index < rows.Count; ++index)
          {
            if (objBlockRows.Count == this.VirtualBlockSize)
            {
              dataGridRowBlockList.Add(new DataGridView.DataGridRowBlock(this, (IList) objBlockRows, dataGridRowBlockList.Count + 1, blnContainsFrozenRows));
              objBlockRows = new List<DataGridViewRow>();
              blnContainsFrozenRows = false;
            }
            if (rows[index] is DataGridViewRow dataGridViewRow1)
            {
              DataGridViewRow dataGridViewRow = dataGridViewRow1;
              if (dataGridViewRow.GetVisible(dataGridViewRow.Index))
              {
                if (dataGridViewRow1.Frozen)
                  blnContainsFrozenRows = true;
                objBlockRows.Add(dataGridViewRow1);
              }
            }
          }
          if (objBlockRows.Count > 0)
            dataGridRowBlockList.Add(new DataGridView.DataGridRowBlock(this, (IList) objBlockRows, dataGridRowBlockList.Count + 1, blnContainsFrozenRows));
        }
      }
      return (IEnumerable<DataGridView.DataGridRowBlock>) dataGridRowBlockList.ToArray();
    }

    /// <summary>
    /// Gets a new instance of a data grid view column by recieved type.
    /// </summary>
    /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
    /// <returns></returns>
    public virtual DataGridViewColumn GetColumnByPropertyDescriptor(
      PropertyDescriptor objPropertyDescriptor)
    {
      if (objPropertyDescriptor != null)
      {
        Type propertyType = objPropertyDescriptor.PropertyType;
        if (propertyType != (Type) null)
        {
          TypeConverter converter = TypeDescriptor.GetConverter(typeof (Image));
          if (propertyType.Equals(typeof (bool)) || propertyType.Equals(typeof (CheckState)))
            return (DataGridViewColumn) new DataGridViewCheckBoxColumn(propertyType.Equals(typeof (CheckState)));
          if (typeof (Image).IsAssignableFrom(propertyType) || converter.CanConvertFrom(propertyType) || typeof (ResourceHandle).IsAssignableFrom(propertyType))
            return (DataGridViewColumn) new DataGridViewImageColumn();
        }
      }
      return (DataGridViewColumn) new DataGridViewTextBoxColumn();
    }

    /// <summary>Gets the type of the child grid.</summary>
    /// <param name="objDataGridViewRow">The obj data grid view row.</param>
    /// <returns></returns>
    public virtual Type GetChildGridType(DataGridViewRow objDataGridViewRow) => typeof (HierarchicDataGridView);

    /// <summary>Gets the data grid view default column.</summary>
    /// <returns></returns>
    internal DataGridViewColumn GetDataGridViewDefaultColumn() => this.GetColumnByPropertyDescriptor((PropertyDescriptor) null);

    /// <summary>Gets the block manager.</summary>
    /// <value>The block manager.</value>
    private DataGridView.DataGridRowBlockInfo GetBlockInfo(DataGridView.DataGridRowBlock objBlock) => this.BlocksManager.GetBlockInfo(objBlock);

    /// <summary>Gets the last modified.</summary>
    /// <returns></returns>
    internal long GetLastModified() => this.LastModified;

    /// <summary>Gets the block info.</summary>
    /// <param name="intBlockId">The block id.</param>
    /// <returns></returns>
    private DataGridView.DataGridRowBlockInfo GetBlockInfo(int intBlockId) => this.BlocksManager.GetBlockInfo(intBlockId);

    /// <summary>
    /// Determines whether [is extended column header visible].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if [is extended column header visible]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsExtendedColumnHeaderVisible() => this.mobjExtendedColumnHeaders != null && this.mobjExtendedColumnHeaders.ShowExtendedColumnHeader && this.mobjExtendedColumnHeaders.Rows.Count > 0;

    /// <summary>Determines whether [is new row visible].</summary>
    /// <returns>
    ///   <c>true</c> if [is new row visible]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsNewRowVisible()
    {
      bool flag = this.AllowUserToAddRows;
      if (flag)
      {
        DataGridView.DataGridViewDataConnection dataConnection = this.DataConnection;
        if (dataConnection != null)
          flag = dataConnection.AllowAdd;
      }
      return flag;
    }

    /// <summary>Shows the column chooser dialog.</summary>
    public void ShowColumnPickerDialog()
    {
      ColumnChooserDialog columnChooserDialog = new ColumnChooserDialog(this);
      columnChooserDialog.Closed += new EventHandler(this.DataGridView_ClosedForColumnVisibility);
      int num = (int) columnChooserDialog.ShowDialog();
    }

    /// <summary>
    /// Handles the ClosedForColumnVisibility event of the DataGridView control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DataGridView_ClosedForColumnVisibility(object sender, EventArgs e)
    {
      if (!(sender is ColumnChooserDialog objDialog) || objDialog.DialogResult != DialogResult.OK)
        return;
      this.UpdateColumnsVisibility(objDialog);
    }

    /// <summary>
    /// Updates the columns visibility according to the column chooser.
    /// </summary>
    /// <param name="objDialog">The obj dialog.</param>
    internal virtual void UpdateColumnsVisibility(ColumnChooserDialog objDialog)
    {
      foreach (KeyValuePair<DataGridViewColumn, ColumnCheckedStatus> chosenRootColumn in objDialog.ChosenRootColumns)
      {
        DataGridViewColumn key = chosenRootColumn.Key;
        if (key != null)
        {
          List<DataGridViewColumn> objChangedColumnsVisibility = new List<DataGridViewColumn>();
          if (chosenRootColumn.Value.IsChanged)
          {
            key.Visible = chosenRootColumn.Value.IsChecked;
            objChangedColumnsVisibility.Add(key);
          }
          this.OnColumnChooserColumnsVisibilityChanged(objChangedColumnsVisibility);
        }
      }
      this.UpdateChildGridColumnsVisibility(objDialog);
    }

    /// <summary>Updates the child grid columns visibility.</summary>
    /// <param name="objDialog">The obj dialog.</param>
    internal void UpdateChildGridColumnsVisibility(ColumnChooserDialog objDialog)
    {
      if (!this.IsHierarchic(HierarchicInfoSelector.Public))
        return;
      foreach (HierarchicInfo key in objDialog.ChosenColumnsIndexByTheirHierarchy.Keys)
        this.UpdateSingleHierarchyColumnsVisibility(key, objDialog.ChosenColumnsIndexByTheirHierarchy[key]);
    }

    /// <summary>Updates the single hierarchy columns visibility.</summary>
    /// <param name="objInfo">The obj info.</param>
    /// <param name="objColumnsState">The list.</param>
    internal void UpdateSingleHierarchyColumnsVisibility(
      HierarchicInfo objInfo,
      List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> objColumnsState)
    {
      List<string> objVisibleItems = new List<string>();
      List<string> objNotVisibleItems = new List<string>();
      foreach (KeyValuePair<DataGridViewColumn, ColumnCheckedStatus> keyValuePair in objColumnsState)
      {
        if (keyValuePair.Value.IsChanged)
        {
          if (keyValuePair.Value.IsChecked)
            objVisibleItems.Add(keyValuePair.Key.Name);
          else
            objNotVisibleItems.Add(keyValuePair.Key.Name);
        }
      }
      DataGridView.UpdateHierarchyInfosColumnsVisibility(objInfo, objVisibleItems, objNotVisibleItems);
    }

    /// <summary>Updates the hierarchy infos columns visibility.</summary>
    /// <param name="objInfo">The obj info.</param>
    /// <param name="objVisibleItems">The obj visible items.</param>
    /// <param name="objNotVisibleItems">The obj not visible items.</param>
    private static void UpdateHierarchyInfosColumnsVisibility(
      HierarchicInfo objInfo,
      List<string> objVisibleItems,
      List<string> objNotVisibleItems)
    {
      objInfo.HiddenColumns.SuspendCollectionChangeNotification();
      objInfo.HiddenColumns.AddRange((IEnumerable<string>) objNotVisibleItems);
      objInfo.HiddenColumns.RemoveRange((IEnumerable<string>) objVisibleItems);
      objInfo.HiddenColumns.ResumeCollectionChangeNotification(true);
    }

    /// <summary>Updates the single hierarchy columns visibility.</summary>
    /// <param name="objInfo">The obj info.</param>
    /// <param name="objColumnsState">The list.</param>
    internal void UpdateSingleHierarchyColumnsVisibility(
      HierarchicInfo objInfo,
      List<KeyValuePair<string, ColumnCheckedStatus>> objColumnsState)
    {
      List<string> objVisibleItems = new List<string>();
      List<string> objNotVisibleItems = new List<string>();
      foreach (KeyValuePair<string, ColumnCheckedStatus> keyValuePair in objColumnsState)
      {
        if (keyValuePair.Value.IsChanged)
        {
          if (keyValuePair.Value.IsChecked)
            objVisibleItems.Add(keyValuePair.Key);
          else
            objNotVisibleItems.Add(keyValuePair.Key);
        }
      }
      DataGridView.UpdateHierarchyInfosColumnsVisibility(objInfo, objVisibleItems, objNotVisibleItems);
    }

    /// <summary>Determines whether this instance has rows.</summary>
    /// <returns>
    ///   <c>true</c> if this instance has rows; otherwise, <c>false</c>.
    /// </returns>
    internal bool HasRows() => this.AllowUserToAddRows ? this.Rows.Count > 1 : this.Rows.Count > 0;

    private void OnGlobalAutoSize()
    {
      this.Invalidate();
      if (this.AutoSizeCount > 0)
        return;
      DataGridViewRowHeadersWidthSizeMode headersWidthSizeMode = this.RowHeadersWidthSizeMode;
      DataGridViewAutoSizeRowsMode autoSizeRowsMode = this.AutoSizeRowsMode;
      int num = headersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing ? 0 : (headersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing ? 1 : 0);
      if (num != 0)
        this.AutoResizeRowHeadersWidth(headersWidthSizeMode, this.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize, autoSizeRowsMode == DataGridViewAutoSizeRowsMode.None);
      if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
        this.AutoResizeColumnHeadersHeight(true, false);
      if (autoSizeRowsMode != DataGridViewAutoSizeRowsMode.None)
        this.AdjustShrinkingRows(autoSizeRowsMode, false, true);
      this.AutoResizeAllVisibleColumnsInternal(DataGridViewAutoSizeColumnCriteriaInternal.AllRows | DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows | DataGridViewAutoSizeColumnCriteriaInternal.Header, true);
      if (num != 0 && (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize || autoSizeRowsMode != DataGridViewAutoSizeRowsMode.None))
        this.AutoResizeRowHeadersWidth(headersWidthSizeMode, true, true);
      if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
        this.AutoResizeColumnHeadersHeight(true, true);
      if (autoSizeRowsMode == DataGridViewAutoSizeRowsMode.None)
        return;
      this.AdjustShrinkingRows(autoSizeRowsMode, true, true);
    }

    private void SortDataBoundDataGridView_PerformCheck(DataGridViewColumn objDataGridViewColumn)
    {
      if (!(this.DataConnection.List is IBindingList list))
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotSortDataBoundDataGridViewBoundToNonIBindingList"));
      if (!list.SupportsSorting)
        throw new InvalidOperationException(SR.GetString("DataGridView_IBindingListNeedsToSupportSorting"));
      if (!objDataGridViewColumn.IsDataBound)
        throw new ArgumentException(SR.GetString("DataGridView_ColumnNeedsToBeDataBoundWhenSortingDataBoundDataGridView"), "dataGridViewColumn");
    }

    /// <summary>Updates the state of the rows displayed.</summary>
    /// <param name="blnDisplayed">if set to <c>true</c> [displayed].</param>
    private void UpdateRowsDisplayedState(bool blnDisplayed)
    {
      DataGridView.DisplayedBandsData displayedBandsInfo = this.DisplayedBandsInfo;
      int displayedFrozenRows = displayedBandsInfo.NumDisplayedFrozenRows;
      DataGridViewRowCollection rows = this.Rows;
      if (displayedFrozenRows > 0)
      {
        int num = rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
        for (; displayedFrozenRows > 0; --displayedFrozenRows)
        {
          if ((rows.GetRowState(num) & DataGridViewElementStates.Displayed) == DataGridViewElementStates.None == blnDisplayed)
            rows.SetRowState(num, DataGridViewElementStates.Displayed, blnDisplayed);
          num = rows.GetNextRow(num, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
        }
      }
      int num1 = displayedBandsInfo.FirstDisplayedScrollingRow;
      if (num1 <= -1)
        return;
      for (int displayedScrollingRows = displayedBandsInfo.NumDisplayedScrollingRows; displayedScrollingRows > 0; --displayedScrollingRows)
      {
        if ((rows.GetRowState(num1) & DataGridViewElementStates.Displayed) == DataGridViewElementStates.None == blnDisplayed)
          rows.SetRowState(num1, DataGridViewElementStates.Displayed, blnDisplayed);
        num1 = rows.GetNextRow(num1, DataGridViewElementStates.Visible);
      }
    }

    internal void OnRowErrorTextChanged(DataGridViewRow objDataGridViewRow) => this.OnRowErrorTextChanged(new DataGridViewRowEventArgs(objDataGridViewRow));

    internal void OnCellStyleContentChanged(
      DataGridViewCellStyle objDataGridViewCellStyle,
      DataGridViewCellStyle.DataGridViewCellStylePropertyInternal property)
    {
      switch (property)
      {
        case DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Font:
          if ((objDataGridViewCellStyle.Scope & DataGridViewCellStyleScopes.DataGridView) != DataGridViewCellStyleScopes.None && this.mobjDataGridViewState1[33554432])
            this.mobjDataGridViewState1[33554432] = false;
          if ((objDataGridViewCellStyle.Scope & DataGridViewCellStyleScopes.ColumnHeaders) != DataGridViewCellStyleScopes.None && this.mobjDataGridViewState1[67108864])
            this.mobjDataGridViewState1[67108864] = false;
          if ((objDataGridViewCellStyle.Scope & DataGridViewCellStyleScopes.RowHeaders) != DataGridViewCellStyleScopes.None && this.mobjDataGridViewState1[134217728])
          {
            this.mobjDataGridViewState1[134217728] = false;
            break;
          }
          break;
        case DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.ForeColor:
          if ((objDataGridViewCellStyle.Scope & DataGridViewCellStyleScopes.DataGridView) != DataGridViewCellStyleScopes.None && this.mobjDataGridViewState1[1024])
          {
            this.mobjDataGridViewState1[1024] = false;
            break;
          }
          break;
      }
      this.OnCellStyleContentChanged(new DataGridViewCellStyleContentChangedEventArgs(objDataGridViewCellStyle, property != DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Color && property != DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.ForeColor));
    }

    /// <summary>Notifies the accessible client applications when a new cell becomes the current cell. </summary>
    /// <param name="objCellAddress">A <see cref="T:System.Drawing.Point"></see> indicating the row and column indexes of the new current cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Drawing.Point.X"></see> property of cellAddress is less than 0 or greater than the number of columns in the control minus 1. -or-The value of the <see cref="P:System.Drawing.Point.Y"></see> property of cellAddress is less than 0 or greater than the number of rows in the control minus 1.</exception>
    protected virtual void AccessibilityNotifyCurrentCellChanged(Point objCellAddress)
    {
    }

    /// <summary>Adjusts the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> for a column header cell of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that is currently being painted.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the border style for the current column header.</returns>
    /// <param name="objDataGridViewAdvancedBorderStylePlaceholder">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that is used to store intermediate changes to the column header border style.</param>
    /// <param name="blnIsFirstDisplayedColumn">true to indicate that the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that is currently being painted is in the first column displayed on the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>; otherwise, false.</param>
    /// <param name="objDataGridViewAdvancedBorderStyleInput">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that that represents the column header border style to modify.</param>
    /// <param name="blnIsLastVisibleColumn">true to indicate that the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that is currently being painted is in the last column in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that has the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Visible"></see> property set to true; otherwise, false.</param>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual DataGridViewAdvancedBorderStyle AdjustColumnHeaderBorderStyle(
      DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStyleInput,
      DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder,
      bool blnIsFirstDisplayedColumn,
      bool blnIsLastVisibleColumn)
    {
      return (DataGridViewAdvancedBorderStyle) null;
    }

    /// <summary>Returns a value indicating whether all the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cells are currently selected.</summary>
    /// <returns>true if all cells (or all visible cells) are selected or if there are no cells (or no visible cells); otherwise, false.</returns>
    /// <param name="blnIncludeInvisibleCells">true to include the rows and columns with <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.Visible"></see> property values of false; otherwise, false. </param>
    /// <filterpriority>1</filterpriority>
    public bool AreAllCellsSelected(bool blnIncludeInvisibleCells)
    {
      DataGridViewRowCollection rows = this.Rows;
      if (this.Columns.Count == 0 && rows.Count == 0 || !blnIncludeInvisibleCells && (rows.GetFirstRow(DataGridViewElementStates.Visible) == -1 || this.Columns.GetFirstColumn(DataGridViewElementStates.Visible) == null))
        return true;
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.CellSelect:
          bool flag1 = this.IndividualSelectedCells.Count == this.Columns.Count * rows.Count;
          if (flag1 | blnIncludeInvisibleCells)
            return flag1;
          for (int index = rows.GetFirstRow(DataGridViewElementStates.Visible); index != -1; index = rows.GetNextRow(index, DataGridViewElementStates.Visible))
          {
            DataGridViewRow dataGridViewRow = rows[index];
            for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
            {
              if (!dataGridViewRow.Cells[objDataGridViewColumnStart.Index].Selected)
                return false;
            }
          }
          return true;
        case DataGridViewSelectionMode.FullRowSelect:
        case DataGridViewSelectionMode.RowHeaderSelect:
          bool flag2 = this.SelectedBandIndexes.Count * this.Columns.Count + this.IndividualSelectedCells.Count == this.Columns.Count * rows.Count;
          if (flag2 | blnIncludeInvisibleCells)
            return flag2;
          for (int index = rows.GetFirstRow(DataGridViewElementStates.Visible); index != -1; index = rows.GetNextRow(index, DataGridViewElementStates.Visible))
          {
            if ((rows.GetRowState(index) & DataGridViewElementStates.Selected) == DataGridViewElementStates.None)
            {
              DataGridViewRow dataGridViewRow = rows[index];
              for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
              {
                if (!dataGridViewRow.Cells[objDataGridViewColumnStart.Index].Selected)
                  return false;
              }
            }
          }
          return true;
        case DataGridViewSelectionMode.FullColumnSelect:
        case DataGridViewSelectionMode.ColumnHeaderSelect:
          DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
          bool flag3 = selectedBandIndexes.Count * rows.Count + this.IndividualSelectedCells.Count == this.Columns.Count * rows.Count;
          if (flag3 | blnIncludeInvisibleCells)
            return flag3;
          for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
          {
            if (!selectedBandIndexes.Contains(objDataGridViewColumnStart.Index))
            {
              for (int index = rows.GetFirstRow(DataGridViewElementStates.Visible); index != -1; index = rows.GetNextRow(index, DataGridViewElementStates.Visible))
              {
                if (!rows[index].Cells[objDataGridViewColumnStart.Index].Selected)
                  return false;
              }
            }
          }
          return true;
        default:
          return false;
      }
    }

    /// <summary>Adjusts the width of the specified column to fit the contents of all its cells, including the header cell. </summary>
    /// <param name="intColumnIndex">The index of the column to resize.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
    public void AutoResizeColumn(int intColumnIndex) => this.AutoResizeColumn(intColumnIndex, DataGridViewAutoSizeColumnMode.AllCells);

    /// <summary>Adjusts the width of the specified column using the specified size mode.</summary>
    /// <param name="intColumnIndex">The index of the column to resize. </param>
    /// <param name="enmAutoSizeColumnMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> values. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeColumnMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> is false. </exception>
    /// <exception cref="T:System.ArgumentException">autoSizeColumnMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see>. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value.</exception>
    public void AutoResizeColumn(
      int intColumnIndex,
      DataGridViewAutoSizeColumnMode enmAutoSizeColumnMode)
    {
      this.AutoResizeColumn(intColumnIndex, enmAutoSizeColumnMode, true);
    }

    /// <summary>Adjusts the width of the specified column using the specified size mode, optionally calculating the width with the expectation that row heights will subsequently be adjusted. </summary>
    /// <param name="intColumnIndex">The index of the column to resize. </param>
    /// <param name="enmAutoSizeColumnMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> values. </param>
    /// <param name="blnFixedHeight">true to calculate the new width based on the current row heights; false to calculate the width with the expectation that the row heights will also be adjusted.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeColumnMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> is false. </exception>
    /// <exception cref="T:System.ArgumentException">autoSizeColumnMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see>. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value.</exception>
    protected void AutoResizeColumn(
      int intColumnIndex,
      DataGridViewAutoSizeColumnMode enmAutoSizeColumnMode,
      bool blnFixedHeight)
    {
      if (enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.NotSet || enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.None || enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.Fill)
        throw new ArgumentException(SR.GetString("DataGridView_NeedColumnAutoSizingCriteria", (object) "autoSizeColumnMode"));
      switch (enmAutoSizeColumnMode)
      {
        case DataGridViewAutoSizeColumnMode.NotSet:
        case DataGridViewAutoSizeColumnMode.None:
        case DataGridViewAutoSizeColumnMode.ColumnHeader:
        case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
        case DataGridViewAutoSizeColumnMode.AllCells:
        case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
        case DataGridViewAutoSizeColumnMode.DisplayedCells:
        case DataGridViewAutoSizeColumnMode.Fill:
          if (intColumnIndex < 0 || intColumnIndex >= this.Columns.Count)
            throw new ArgumentOutOfRangeException("columnIndex");
          if (enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.ColumnHeader && !this.ColumnHeadersVisible)
            throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeInvisibleColumnHeader"));
          this.AutoResizeColumnInternal(intColumnIndex, (DataGridViewAutoSizeColumnCriteriaInternal) enmAutoSizeColumnMode, blnFixedHeight);
          break;
        default:
          throw new InvalidEnumArgumentException("autoSizeColumnMode", (int) enmAutoSizeColumnMode, typeof (DataGridViewAutoSizeColumnMode));
      }
    }

    /// <summary>Adjusts the height of the column headers to fit the contents of the largest column header.</summary>
    public void AutoResizeColumnHeadersHeight() => this.AutoResizeColumnHeadersHeight(true, true);

    /// <summary>Adjusts the height of the column headers based on changes to the contents of the header in the specified column.</summary>
    /// <param name="intColumnIndex">The index of the column containing the header with the changed content.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1.</exception>
    public void AutoResizeColumnHeadersHeight(int intColumnIndex) => this.AutoResizeColumnHeadersHeight(intColumnIndex, true, true);

    /// <summary>Adjusts the height of the column headers to fit their contents, optionally calculating the height with the expectation that the column and/or row header widths will subsequently be adjusted.</summary>
    /// <param name="blnFixedRowHeadersWidth">true to calculate the new height based on the current width of the row headers; false to calculate the height with the expectation that the row headers width will also be adjusted. </param>
    /// <param name="blnFixedColumnsWidth">true to calculate the new height based on the current column widths; false to calculate the height with the expectation that the column widths will also be adjusted.</param>
    protected void AutoResizeColumnHeadersHeight(
      bool blnFixedRowHeadersWidth,
      bool blnFixedColumnsWidth)
    {
      if (!this.ColumnHeadersVisible)
        return;
      int num = 0;
      Size preferredSize;
      if (this.LayoutInfo.TopLeftHeader.Width > 0)
      {
        if (blnFixedRowHeadersWidth)
        {
          num = this.TopLeftHeaderCell.GetPreferredHeight(-1, this.LayoutInfo.TopLeftHeader.Width);
        }
        else
        {
          preferredSize = this.TopLeftHeaderCell.GetPreferredSize(-1);
          num = preferredSize.Height;
        }
      }
      int count = this.Columns.Count;
      for (int index = 0; index < count; ++index)
      {
        if (this.Columns[index].Visible)
        {
          if (blnFixedColumnsWidth)
          {
            num = Math.Max(num, this.Columns[index].HeaderCell.GetPreferredHeight(-1, this.Columns[index].Thickness));
          }
          else
          {
            int val1 = num;
            preferredSize = this.Columns[index].HeaderCell.GetPreferredSize(-1);
            int height = preferredSize.Height;
            num = Math.Max(val1, height);
          }
        }
      }
      if (num < 4)
        num = 4;
      if (num > 32768)
        num = 32768;
      if (num == this.ColumnHeadersHeight)
        return;
      this.SetColumnHeadersHeightInternal(num, !blnFixedColumnsWidth);
    }

    /// <summary>Adjusts the height of the column headers based on changes to the contents of the header in the specified column, optionally calculating the height with the expectation that the column and/or row header widths will subsequently be adjusted.</summary>
    /// <param name="blnFixedRowHeadersWidth">true to calculate the new height based on the current width of the row headers; false to calculate the height with the expectation that the row headers width will also be adjusted.</param>
    /// <param name="intColumnIndex">The index of the column header whose contents should be used to determine new height.</param>
    /// <param name="blnFixedColumnWidth">true to calculate the new height based on the current width of the specified column; false to calculate the height with the expectation that the column width will also be adjusted.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
    protected void AutoResizeColumnHeadersHeight(
      int intColumnIndex,
      bool blnFixedRowHeadersWidth,
      bool blnFixedColumnWidth)
    {
      if (this.DesignMode)
        return;
      if (intColumnIndex < -1 || intColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("columnIndex");
      if (!this.ColumnHeadersVisible)
        return;
      int num = 0;
      Size preferredSize;
      if (this.LayoutInfo.TopLeftHeader.Width > 0)
      {
        if (intColumnIndex != -1 | blnFixedRowHeadersWidth)
        {
          num = this.TopLeftHeaderCell.GetPreferredHeight(-1, this.LayoutInfo.TopLeftHeader.Width);
        }
        else
        {
          preferredSize = this.TopLeftHeaderCell.GetPreferredSize(-1);
          num = preferredSize.Height;
        }
      }
      int count = this.Columns.Count;
      for (int index = 0; index < count; ++index)
      {
        if (this.Columns[index].Visible)
        {
          if (intColumnIndex != index | blnFixedColumnWidth)
          {
            num = Math.Max(num, this.Columns[index].HeaderCell.GetPreferredHeight(-1, this.Columns[index].Thickness));
          }
          else
          {
            int val1 = num;
            preferredSize = this.Columns[index].HeaderCell.GetPreferredSize(-1);
            int height = preferredSize.Height;
            num = Math.Max(val1, height);
          }
        }
      }
      if (num < 4)
        num = 4;
      if (num > 32768)
        num = 32768;
      if (num == this.ColumnHeadersHeight)
        return;
      this.SetColumnHeadersHeightInternal(num, !blnFixedColumnWidth);
    }

    /// <summary>Adjusts the width of all columns to fit the contents of all their cells, including the header cells.</summary>
    public void AutoResizeColumns() => this.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

    /// <summary>Adjusts the width of all columns using the specified size mode.</summary>
    /// <param name="enmAutoSizeColumnsMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> values. </param>
    /// <exception cref="T:System.ArgumentException">autoSizeColumnsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.None"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill"></see>. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> value.</exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeColumnsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> is false. </exception>
    public void AutoResizeColumns(
      DataGridViewAutoSizeColumnsMode enmAutoSizeColumnsMode)
    {
      this.AutoResizeColumns(enmAutoSizeColumnsMode, true);
    }

    /// <summary>Adjusts the width of all columns using the specified size mode, optionally calculating the widths with the expectation that row heights will subsequently be adjusted. </summary>
    /// <param name="enmAutoSizeColumnsMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> values. </param>
    /// <param name="blnFixedHeight">true to calculate the new widths based on the current row heights; false to calculate the widths with the expectation that the row heights will also be adjusted.</param>
    /// <exception cref="T:System.ArgumentException">autoSizeColumnsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.None"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill"></see>. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> value.</exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeColumnsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> is false. </exception>
    protected void AutoResizeColumns(
      DataGridViewAutoSizeColumnsMode enmAutoSizeColumnsMode,
      bool blnFixedHeight)
    {
      for (int intColumnIndex = 0; intColumnIndex < this.Columns.Count; ++intColumnIndex)
        this.AutoResizeColumn(intColumnIndex, (DataGridViewAutoSizeColumnMode) enmAutoSizeColumnsMode, blnFixedHeight);
      this.Update();
    }

    /// <summary>Adjusts the height of the specified row to fit the contents of all its cells including the header cell.</summary>
    /// <param name="intRowIndex">The index of the row to resize.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1. </exception>
    public void AutoResizeRow(int intRowIndex) => this.AutoResizeRow(intRowIndex, DataGridViewAutoSizeRowMode.AllCells);

    /// <summary>Adjusts the height of the specified row using the specified size mode.</summary>
    /// <param name="enmAutoSizeRowMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> values. </param>
    /// <param name="intRowIndex">The index of the row to resize. </param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> value. </exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeRowMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode.RowHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1.</exception>
    public void AutoResizeRow(int intRowIndex, DataGridViewAutoSizeRowMode enmAutoSizeRowMode) => this.AutoResizeRow(intRowIndex, enmAutoSizeRowMode, true);

    /// <summary>Adjusts the height of the specified row using the specified size mode, optionally calculating the height with the expectation that column widths will subsequently be adjusted. </summary>
    /// <param name="enmAutoSizeRowMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> values. </param>
    /// <param name="intRowIndex">The index of the row to resize. </param>
    /// <param name="blnFixedWidth">true to calculate the new height based on the current width of the columns; false to calculate the height with the expectation that the column widths will also be adjusted.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> value. </exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeRowMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode.RowHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1.</exception>
    protected void AutoResizeRow(
      int intRowIndex,
      DataGridViewAutoSizeRowMode enmAutoSizeRowMode,
      bool blnFixedWidth)
    {
      if (intRowIndex < 0 || intRowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      if ((enmAutoSizeRowMode & ~DataGridViewAutoSizeRowMode.AllCells) != (DataGridViewAutoSizeRowMode) 0)
        throw new InvalidEnumArgumentException("autoSizeRowMode", (int) enmAutoSizeRowMode, typeof (DataGridViewAutoSizeRowMode));
      if (enmAutoSizeRowMode == DataGridViewAutoSizeRowMode.RowHeader && !this.RowHeadersVisible)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeRowInvisibleRowHeader"));
      this.AutoResizeRowInternal(intRowIndex, enmAutoSizeRowMode, blnFixedWidth, false);
    }

    /// <summary>Adjusts the width of the row headers using the specified size mode.</summary>
    /// <param name="enmRowHeadersWidthSizeMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> values.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">rowHeadersWidthSizeMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value. </exception>
    /// <exception cref="T:System.ArgumentException">rowHeadersWidthSizeMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see>.</exception>
    public void AutoResizeRowHeadersWidth(
      DataGridViewRowHeadersWidthSizeMode enmRowHeadersWidthSizeMode)
    {
    }

    /// <summary>Adjusts the width of the row headers based on changes to the contents of the header in the specified row and using the specified size mode.</summary>
    /// <param name="enmRowHeadersWidthSizeMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> values.</param>
    /// <param name="intRowIndex">The index of the row header with the changed content.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">rowHeadersWidthSizeMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value. </exception>
    /// <exception cref="T:System.ArgumentException">rowHeadersWidthSizeMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see></exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1. </exception>
    public void AutoResizeRowHeadersWidth(
      int intRowIndex,
      DataGridViewRowHeadersWidthSizeMode enmRowHeadersWidthSizeMode)
    {
    }

    /// <summary>Adjusts the width of the row headers using the specified size mode, optionally calculating the width with the expectation that the row and/or column header widths will subsequently be adjusted.</summary>
    /// <param name="blnFixedColumnHeadersHeight">true to calculate the new width based on the current height of the column headers; false to calculate the width with the expectation that the height of the column headers will also be adjusted.</param>
    /// <param name="enmRowHeadersWidthSizeMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> values.</param>
    /// <param name="blnFixedRowsHeight">true to calculate the new width based on the current row heights; false to calculate the width with the expectation that the row heights will also be adjusted.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">rowHeadersWidthSizeMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value. </exception>
    /// <exception cref="T:System.ArgumentException">rowHeadersWidthSizeMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see>.</exception>
    protected void AutoResizeRowHeadersWidth(
      DataGridViewRowHeadersWidthSizeMode enmRowHeadersWidthSizeMode,
      bool blnFixedColumnHeadersHeight,
      bool blnFixedRowsHeight)
    {
    }

    /// <summary>Adjusts the width of the row headers based on changes to the contents of the header in the specified row and using the specified size mode, optionally calculating the width with the expectation that the row and/or column header widths will subsequently be adjusted.</summary>
    /// <param name="blnFixedColumnHeadersHeight">true to calculate the new width based on the current height of the column headers; false to calculate the width with the expectation that the height of the column headers will also be adjusted.</param>
    /// <param name="enmRowHeadersWidthSizeMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> values.</param>
    /// <param name="blnFixedRowHeight">true to calculate the new width based on the current height of the specified row; false to calculate the width with the expectation that the row height will also be adjusted.</param>
    /// <param name="intRowIndex">The index of the row containing the header with the changed content.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">rowHeadersWidthSizeMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value. </exception>
    /// <exception cref="T:System.ArgumentException">rowHeadersWidthSizeMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see>.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1. </exception>
    protected void AutoResizeRowHeadersWidth(
      int intRowIndex,
      DataGridViewRowHeadersWidthSizeMode enmRowHeadersWidthSizeMode,
      bool blnFixedColumnHeadersHeight,
      bool blnFixedRowHeight)
    {
    }

    /// <summary>Adjusts the heights of all rows to fit the contents of all their cells, including the header cells.</summary>
    public void AutoResizeRows() => this.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

    /// <summary>Adjusts the heights of the rows using the specified size mode value.</summary>
    /// <param name="enmAutoSizeRowsMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> values. </param>
    /// <exception cref="T:System.ArgumentException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value. </exception>
    public void AutoResizeRows(DataGridViewAutoSizeRowsMode enmAutoSizeRowsMode) => this.AutoResizeRows(enmAutoSizeRowsMode, true);

    /// <summary>
    /// Adjusts the heights of all rows using the specified size mode, optionally calculating the heights with the expectation that column widths will subsequently be adjusted.
    /// </summary>
    /// <param name="enmAutoSizeRowsMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> values.</param>
    /// <param name="blnFixedWidth">true to calculate the new heights based on the current column widths; false to calculate the heights with the expectation that the column widths will also be adjusted.</param>
    /// <exception cref="T:System.ArgumentException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value. </exception>
    protected void AutoResizeRows(
      DataGridViewAutoSizeRowsMode enmAutoSizeRowsMode,
      bool blnFixedWidth)
    {
      switch (enmAutoSizeRowsMode)
      {
        case DataGridViewAutoSizeRowsMode.None:
        case DataGridViewAutoSizeRowsMode.AllHeaders:
        case DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders:
        case DataGridViewAutoSizeRowsMode.AllCells:
        case DataGridViewAutoSizeRowsMode.DisplayedHeaders:
        case DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders:
        case DataGridViewAutoSizeRowsMode.DisplayedCells:
          if (enmAutoSizeRowsMode == DataGridViewAutoSizeRowsMode.None)
            throw new ArgumentException(SR.GetString("DataGridView_NeedAutoSizingCriteria", (object) "autoSizeRowsMode"));
          if ((enmAutoSizeRowsMode == DataGridViewAutoSizeRowsMode.AllHeaders || enmAutoSizeRowsMode == DataGridViewAutoSizeRowsMode.DisplayedHeaders) && !this.RowHeadersVisible)
            throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeRowsInvisibleRowHeader"));
          this.AdjustShrinkingRows(enmAutoSizeRowsMode, blnFixedWidth, false);
          this.Update();
          break;
        default:
          throw new InvalidEnumArgumentException("value", (int) enmAutoSizeRowsMode, typeof (DataGridViewAutoSizeRowsMode));
      }
    }

    /// <summary>Adjusts the shrinking rows.</summary>
    /// <param name="enmAutoSizeRowsMode">The auto size rows mode.</param>
    /// <param name="blnFixedWidth">if set to <c>true</c> [fixed width].</param>
    /// <param name="blnInternalAutosizing">if set to <c>true</c> [internal autosizing].</param>
    protected void AdjustShrinkingRows(
      DataGridViewAutoSizeRowsMode enmAutoSizeRowsMode,
      bool blnFixedWidth,
      bool blnInternalAutosizing)
    {
      if ((enmAutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) == DataGridViewAutoSizeRowsMode.None && ((enmAutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 1) == DataGridViewAutoSizeRowsMode.None || !this.RowHeadersVisible))
        return;
      ++this.BulkPaintCount;
      try
      {
        DataGridViewRowCollection rows = this.Rows;
        if ((enmAutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 4) != DataGridViewAutoSizeRowsMode.None)
        {
          ++this.BulkLayoutCount;
          try
          {
            for (int index = rows.GetFirstRow(DataGridViewElementStates.Visible); index != -1; index = rows.GetNextRow(index, DataGridViewElementStates.Visible))
              this.AutoResizeRowInternal(index, DataGridView.MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
          }
          finally
          {
            this.ExitBulkLayout(false);
          }
        }
        else
        {
          int height = this.LayoutInfo.Data.Height;
          int num1 = 0;
          for (int index = rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible); index != -1 && num1 < height; index = rows.GetNextRow(index, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible))
          {
            this.AutoResizeRowInternal(index, DataGridView.MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
            num1 += rows.SharedRow(index).GetHeight(index);
          }
          if (num1 >= height)
            return;
          int num2 = num1;
          int scrollingRowIndex1 = this.FirstDisplayedScrollingRowIndex;
          for (int index = scrollingRowIndex1; index != -1 && num1 < height && scrollingRowIndex1 == this.FirstDisplayedScrollingRowIndex; index = rows.GetNextRow(index, DataGridViewElementStates.Visible))
          {
            this.AutoResizeRowInternal(index, DataGridView.MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
            num1 += rows.SharedRow(index).GetHeight(index);
          }
          int scrollingRowIndex2;
          do
          {
            scrollingRowIndex2 = this.FirstDisplayedScrollingRowIndex;
            if (num1 < height)
            {
              int previousRow = rows.GetPreviousRow(this.FirstDisplayedScrollingRowIndex, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
              if (previousRow != -1)
                this.AutoResizeRowInternal(previousRow, DataGridView.MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
            }
            num1 = num2;
            for (int index = this.FirstDisplayedScrollingRowIndex; index != -1 && num1 < height; index = rows.GetNextRow(index, DataGridViewElementStates.Visible))
            {
              this.AutoResizeRowInternal(index, DataGridView.MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
              num1 += rows.SharedRow(index).GetHeight(index);
            }
          }
          while (scrollingRowIndex2 != this.FirstDisplayedScrollingRowIndex);
        }
      }
      finally
      {
        this.ExitBulkPaint(-1, -1);
      }
    }

    /// <summary>Exits the bulk layout.</summary>
    /// <param name="blnInvalidInAdjustFillingColumns">if set to <c>true</c> [invalid in adjust filling columns].</param>
    protected void ExitBulkLayout(bool blnInvalidInAdjustFillingColumns)
    {
      if (this.BulkLayoutCount <= 0)
        return;
      --this.BulkLayoutCount;
      if (this.BulkLayoutCount != 0)
        return;
      this.PerformLayoutPrivate(blnInvalidInAdjustFillingColumns);
    }

    /// <summary>Adjusts the heights of the specified rows using the specified size mode, optionally calculating the heights with the expectation that column widths will subsequently be adjusted. </summary>
    /// <param name="intRowIndexStart">The index of the first row to resize. </param>
    /// <param name="enmAutoSizeRowMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> values. </param>
    /// <param name="blnFixedWidth">true to calculate the new heights based on the current column widths; false to calculate the heights with the expectation that the column widths will also be adjusted.</param>
    /// <param name="intRowsCount">The number of rows to resize. </param>
    /// <exception cref="T:System.ArgumentException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndexStart is less than 0.-or-rowsCount is less than 0.</exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value. </exception>
    protected void AutoResizeRows(
      int intRowIndexStart,
      int intRowsCount,
      DataGridViewAutoSizeRowMode enmAutoSizeRowMode,
      bool blnFixedWidth)
    {
    }

    /// <summary>Puts the current cell in edit mode.</summary>
    /// <returns>true if the current cell is already in edit mode or successfully enters edit mode; otherwise, false.</returns>
    /// <param name="blnSelectAll">true to select all the cell's contents; false to not select any contents.</param>
    /// <exception cref="T:System.Exception">Initialization of the editing cell value failed and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <exception cref="T:System.InvalidCastException">The type indicated by the cell's <see cref="P:System.Windows.Forms.DataGridViewCell.EditType"></see> property does not derive from the <see cref="T:System.Windows.Forms.Control"></see> type.-or-The type indicated by the cell's <see cref="P:System.Windows.Forms.DataGridViewCell.EditType"></see> property does not implement the <see cref="T:System.Windows.Forms.IDataGridViewEditingControl"></see> interface.</exception>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Forms.DataGridView.CurrentCell"></see> is not set to a valid cell.-or-This method was called in a handler for the <see cref="E:System.Windows.Forms.DataGridView.CellBeginEdit"></see> event.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual bool BeginEdit(bool blnSelectAll) => this.BeginEdit(blnSelectAll, false);

    /// <summary>Begins edit.</summary>
    /// <param name="blnSelectAll">if set to <c>true</c> [BLN select all].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <returns></returns>
    internal virtual bool BeginEdit(bool blnSelectAll, bool blnClientSource)
    {
      if (this.mobjCurrentCellPoint.X == -1)
        throw new InvalidOperationException(SR.GetString("DataGridView_NoCurrentCell"));
      int num = this.IsCurrentCellInEditMode ? 1 : (this.BeginEditInternal(blnSelectAll, blnClientSource) ? 1 : 0);
      if (num == 0)
        return num != 0;
      if (blnClientSource)
        return num != 0;
      DataGridViewCell currentCellInternal = this.CurrentCellInternal;
      if (currentCellInternal == null)
        return num != 0;
      this.BeginCellEdit(currentCellInternal);
      return num != 0;
    }

    /// <summary>Begins the cell edit.</summary>
    /// <param name="objDataGridViewCell">The obj data grid view cell.</param>
    internal void BeginCellEdit(DataGridViewCell objDataGridViewCell)
    {
      if (objDataGridViewCell == null)
        return;
      this.InvokeMethodWithId("DataGridView_BeginEdit", (object) string.Format("{0}_{1}", (object) this.ID.ToString(), (object) objDataGridViewCell.MemberIDInternal));
    }

    /// <summary>Cancels edit mode for the currently selected cell and discards any changes.</summary>
    /// <returns>true if the cancel was successful; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool CancelEdit() => false;

    /// <summary>Clears the current selection by unselecting all selected cells.</summary>
    /// <filterpriority>1</filterpriority>
    public void ClearSelection()
    {
      ++this.DimensionChangeCount;
      ++this.SelectionChangeCount;
      bool flag = false;
      DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      if (selectedBandIndexes.Count > 8 || individualSelectedCells.Count > 8)
      {
        ++this.BulkPaintCount;
        flag = true;
      }
      try
      {
        this.RemoveIndividuallySelectedCells();
        switch (this.SelectionMode)
        {
          case DataGridViewSelectionMode.FullRowSelect:
          case DataGridViewSelectionMode.RowHeaderSelect:
            while (selectedBandIndexes.Count > 0)
              this.SetSelectedRowCore(selectedBandIndexes.HeadInt, false);
            break;
          case DataGridViewSelectionMode.FullColumnSelect:
          case DataGridViewSelectionMode.ColumnHeaderSelect:
            while (selectedBandIndexes.Count > 0)
              this.SetSelectedColumnCore(selectedBandIndexes.HeadInt, false);
            break;
        }
      }
      finally
      {
        --this.DimensionChangeCount;
        --this.NoSelectionChangeCount;
        if (flag)
          this.ExitBulkPaint(-1, -1);
      }
    }

    /// <summary>Cancels the selection of all currently selected cells except the one indicated, optionally ensuring that the indicated cell is selected. </summary>
    /// <param name="intColumnIndexException">The column index to exclude.</param>
    /// <param name="blnSelectExceptionElement">true to select the excluded cell, row, or column; false to retain its original state.</param>
    /// <param name="intRowIndexException">The row index to exclude.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndexException is greater than the highest column index.-or-columnIndexException is less than -1 when <see cref="P:System.Windows.Forms.DataGridView.SelectionMode"></see> is <see cref="F:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect"></see>; otherwise, columnIndexException is less than 0.-or- rowIndexException is greater than the highest row index.-or-rowIndexException is less than -1 when <see cref="P:System.Windows.Forms.DataGridView.SelectionMode"></see> is <see cref="F:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect"></see>; otherwise, rowIndexException is less than 0.</exception>
    protected void ClearSelection(
      int intColumnIndexException,
      int intRowIndexException,
      bool blnSelectExceptionElement)
    {
      this.ClearSelection(intColumnIndexException, intRowIndexException, blnSelectExceptionElement, false);
    }

    /// <summary>Cancels the selection of all currently selected cells except the one indicated, optionally ensuring that the indicated cell is selected. </summary>
    /// <param name="intColumnIndexException">The column index to exclude.</param>
    /// <param name="blnSelectExceptionElement">true to select the excluded cell, row, or column; false to retain its original state.</param>
    /// <param name="intRowIndexException">The row index to exclude.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndexException is greater than the highest column index.-or-columnIndexException is less than -1 when <see cref="P:System.Windows.Forms.DataGridView.SelectionMode"></see> is <see cref="F:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect"></see>; otherwise, columnIndexException is less than 0.-or- rowIndexException is greater than the highest row index.-or-rowIndexException is less than -1 when <see cref="P:System.Windows.Forms.DataGridView.SelectionMode"></see> is <see cref="F:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect"></see>; otherwise, rowIndexException is less than 0.</exception>
    private void ClearSelection(
      int intColumnIndexException,
      int intRowIndexException,
      bool blnSelectExceptionElement,
      bool blnClientSource)
    {
      DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.CellSelect:
        case DataGridViewSelectionMode.FullColumnSelect:
        case DataGridViewSelectionMode.ColumnHeaderSelect:
          if (intColumnIndexException < 0 || intColumnIndexException >= this.Columns.Count)
            throw new ArgumentOutOfRangeException("columnIndexException");
          break;
        case DataGridViewSelectionMode.FullRowSelect:
        case DataGridViewSelectionMode.RowHeaderSelect:
          if (intColumnIndexException < -1 || intColumnIndexException >= this.Columns.Count)
            throw new ArgumentOutOfRangeException("columnIndexException");
          break;
      }
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.CellSelect:
        case DataGridViewSelectionMode.FullRowSelect:
        case DataGridViewSelectionMode.RowHeaderSelect:
          if (intRowIndexException < 0 || intRowIndexException >= this.Rows.Count)
            throw new ArgumentOutOfRangeException("rowIndexException");
          break;
        case DataGridViewSelectionMode.FullColumnSelect:
        case DataGridViewSelectionMode.ColumnHeaderSelect:
          if (intRowIndexException < -1 || intRowIndexException >= this.Rows.Count)
            throw new ArgumentOutOfRangeException("rowIndexException");
          break;
      }
      ++this.DimensionChangeCount;
      ++this.SelectionChangeCount;
      bool flag = false;
      if (selectedBandIndexes.Count > 8 || this.IndividualSelectedCells.Count > 8)
      {
        ++this.BulkPaintCount;
        flag = true;
      }
      try
      {
        switch (this.SelectionMode)
        {
          case DataGridViewSelectionMode.CellSelect:
            this.RemoveIndividuallySelectedCells(intColumnIndexException, intRowIndexException);
            break;
          case DataGridViewSelectionMode.FullRowSelect:
          case DataGridViewSelectionMode.RowHeaderSelect:
            int index1 = 0;
            while (index1 < selectedBandIndexes.Count)
            {
              if (selectedBandIndexes[index1] != intRowIndexException)
                this.SetSelectedRowCore(selectedBandIndexes[index1], false, blnClientSource);
              else
                ++index1;
            }
            if (this.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
            {
              this.RemoveIndividuallySelectedCells(intColumnIndexException, intRowIndexException, blnClientSource);
              break;
            }
            break;
          case DataGridViewSelectionMode.FullColumnSelect:
          case DataGridViewSelectionMode.ColumnHeaderSelect:
            int index2 = 0;
            while (index2 < selectedBandIndexes.Count)
            {
              if (selectedBandIndexes[index2] != intColumnIndexException)
                this.SetSelectedColumnCore(selectedBandIndexes[index2], false);
              else
                ++index2;
            }
            if (this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
            {
              this.RemoveIndividuallySelectedCells(intColumnIndexException, intRowIndexException);
              break;
            }
            break;
        }
        if (!blnSelectExceptionElement)
          return;
        this.SetSelectedElementCore(intColumnIndexException, intRowIndexException, true, blnClientSource);
      }
      finally
      {
        --this.DimensionChangeCount;
        --this.NoSelectionChangeCount;
        if (flag)
          this.ExitBulkPaint(-1, -1);
      }
    }

    /// <summary>Commits changes in the current cell to the data cache without ending edit mode.</summary>
    /// <returns>true if the changes were committed; otherwise false.</returns>
    /// <param name="enmContext">A bitwise combination of <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which an error can occur. </param>
    /// <exception cref="T:System.Exception">The cell value could not be committed and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    public bool CommitEdit(DataGridViewDataErrorContexts enmContext)
    {
      if (this.IsCurrentCellInEditMode)
      {
        DataGridViewCell currentCellInternal = this.CurrentCellInternal;
        DataGridViewDataErrorEventArgs dataErrorEventArgs = this.CommitEdit(ref currentCellInternal, enmContext, DataGridView.DataGridViewValidateCellInternal.Never, false, false, false, false, false);
        if (dataErrorEventArgs != null)
        {
          if (dataErrorEventArgs.ThrowException)
            throw dataErrorEventArgs.Exception;
          if (dataErrorEventArgs.Cancel)
            return false;
        }
      }
      return true;
    }

    /// <summary>Commits the edit for operation.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnForCurrentCellChange">if set to <c>true</c> [for current cell change].</param>
    /// <returns></returns>
    internal bool CommitEditForOperation(
      int intColumnIndex,
      int intRowIndex,
      bool blnForCurrentCellChange)
    {
      return this.CommitEditForOperation(intColumnIndex, intRowIndex, blnForCurrentCellChange, false);
    }

    /// <summary>Commits the edit for operation.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnForCurrentCellChange">if set to <c>true</c> [for current cell change].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <returns></returns>
    internal bool CommitEditForOperation(
      int intColumnIndex,
      int intRowIndex,
      bool blnForCurrentCellChange,
      bool blnClientSource)
    {
      if (blnForCurrentCellChange)
      {
        if (!this.EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.CurrentCellChange | DataGridViewDataErrorContexts.Parsing, DataGridView.DataGridViewValidateCellInternal.Always, true, true, this.mobjCurrentCellPoint.Y != intRowIndex, this.mobjCurrentCellPoint.Y != intRowIndex, false, this.EditMode != 0, false, false, blnClientSource))
          return false;
        if (this.mobjCurrentCellPoint.Y != intRowIndex && this.mobjCurrentCellPoint.Y != -1)
        {
          DataGridViewCell objDataGridViewCell = (DataGridViewCell) null;
          int x = this.mobjCurrentCellPoint.X;
          int y = this.mobjCurrentCellPoint.Y;
          if (this.OnRowValidating(ref objDataGridViewCell, x, y))
          {
            if (!this.IsInnerCellOutOfBounds(x, y))
            {
              this.OnRowEnter(ref objDataGridViewCell, x, y, true, true);
              if (this.IsInnerCellOutOfBounds(x, y))
                return false;
              this.OnCellEnter(ref objDataGridViewCell, x, y);
              if (this.IsInnerCellOutOfBounds(x, y) || !this.Focused || this.IsCurrentCellInEditMode || this.EditMode != DataGridViewEditMode.EditOnEnter && (this.EditMode == DataGridViewEditMode.EditProgrammatically || !(this.CurrentCellInternal.EditType == (Type) null)))
                return false;
              this.BeginEditInternal(true);
            }
            return false;
          }
          if (this.IsInnerCellOutOfBounds(x, y))
            return false;
          this.OnRowValidated(ref objDataGridViewCell, x, y);
        }
      }
      else if (!this.CommitEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Scroll, false, this.mobjCurrentCellPoint.Y != intRowIndex))
        return false;
      if (this.IsColumnOutOfBounds(intColumnIndex))
        return false;
      DataGridViewRowCollection rows = this.Rows;
      if (intRowIndex >= rows.Count)
      {
        int lastRow = rows.GetLastRow(DataGridViewElementStates.Visible);
        if (blnForCurrentCellChange && this.mobjCurrentCellPoint.X == -1 && lastRow != -1)
          this.SetAndSelectCurrentCellAddress(intColumnIndex, lastRow, true, false, false, false, false);
        return false;
      }
      return intRowIndex <= -1 || (rows.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None;
    }

    /// <summary>Commits the edit.</summary>
    /// <param name="enmContext">The context.</param>
    /// <param name="blnForCurrentCellChange">if set to <c>true</c> [for current cell change].</param>
    /// <param name="blnForCurrentRowChange">if set to <c>true</c> [for current row change].</param>
    /// <returns></returns>
    private bool CommitEdit(
      DataGridViewDataErrorContexts enmContext,
      bool blnForCurrentCellChange,
      bool blnForCurrentRowChange)
    {
      if (this.mobjDataGridViewOper[32768])
        return false;
      DataGridViewCell currentCellInternal = this.CurrentCellInternal;
      ref DataGridViewCell local = ref currentCellInternal;
      int enmContext1 = (int) enmContext;
      int validateCell = blnForCurrentCellChange ? 1 : 2;
      int num1 = blnForCurrentCellChange ? 1 : 0;
      int num2 = blnForCurrentRowChange ? 1 : 0;
      DataGridViewDataErrorEventArgs dataErrorEventArgs1 = this.CommitEdit(ref local, (DataGridViewDataErrorContexts) enmContext1, (DataGridView.DataGridViewValidateCellInternal) validateCell, num1 != 0, num1 != 0, num2 != 0, num2 != 0, false);
      if (dataErrorEventArgs1 != null)
      {
        if (dataErrorEventArgs1.ThrowException)
          throw dataErrorEventArgs1.Exception;
        if (dataErrorEventArgs1.Cancel)
          return false;
        DataGridViewDataErrorEventArgs dataErrorEventArgs2 = this.CancelEditPrivate();
        if (dataErrorEventArgs2 != null)
        {
          if (dataErrorEventArgs2.ThrowException)
            throw dataErrorEventArgs2.Exception;
          if (dataErrorEventArgs2.Cancel)
            return false;
        }
      }
      if (blnForCurrentRowChange & blnForCurrentCellChange)
      {
        if (this.mobjCurrentCellPoint.X == -1)
          return false;
        int x = this.mobjCurrentCellPoint.X;
        int y = this.mobjCurrentCellPoint.Y;
        if (this.OnRowValidating(ref currentCellInternal, x, y))
        {
          if (!this.IsInnerCellOutOfBounds(x, y))
          {
            this.OnRowEnter(ref currentCellInternal, x, y, true, true);
            if (this.IsInnerCellOutOfBounds(x, y))
              return false;
            this.OnCellEnter(ref currentCellInternal, x, y);
          }
          return false;
        }
        if (this.IsInnerCellOutOfBounds(x, y))
          return false;
        this.OnRowValidated(ref currentCellInternal, x, y);
      }
      return true;
    }

    /// <summary>Commits the edit.</summary>
    /// <param name="objDataGridViewCurrentCell">The data grid view current cell.</param>
    /// <param name="enmContext">The context.</param>
    /// <param name="validateCell">The validate cell.</param>
    /// <param name="blnFireCellLeave">if set to <c>true</c> [fire cell leave].</param>
    /// <param name="blnFireCellEnter">if set to <c>true</c> [fire cell enter].</param>
    /// <param name="blnFireRowLeave">if set to <c>true</c> [fire row leave].</param>
    /// <param name="blnFireRowEnter">if set to <c>true</c> [fire row enter].</param>
    /// <param name="blnFireLeave">if set to <c>true</c> [fire leave].</param>
    /// <returns></returns>
    private DataGridViewDataErrorEventArgs CommitEdit(
      ref DataGridViewCell objDataGridViewCurrentCell,
      DataGridViewDataErrorContexts enmContext,
      DataGridView.DataGridViewValidateCellInternal validateCell,
      bool blnFireCellLeave,
      bool blnFireCellEnter,
      bool blnFireRowLeave,
      bool blnFireRowEnter,
      bool blnFireLeave)
    {
      return this.CommitEdit(ref objDataGridViewCurrentCell, enmContext, validateCell, blnFireCellLeave, blnFireCellEnter, blnFireRowLeave, blnFireRowEnter, blnFireLeave, false);
    }

    /// <summary>Commits the edit.</summary>
    /// <param name="objDataGridViewCurrentCell">The data grid view current cell.</param>
    /// <param name="enmContext">The context.</param>
    /// <param name="validateCell">The validate cell.</param>
    /// <param name="blnFireCellLeave">if set to <c>true</c> [fire cell leave].</param>
    /// <param name="blnFireCellEnter">if set to <c>true</c> [fire cell enter].</param>
    /// <param name="blnFireRowLeave">if set to <c>true</c> [fire row leave].</param>
    /// <param name="blnFireRowEnter">if set to <c>true</c> [fire row enter].</param>
    /// <param name="blnFireLeave">if set to <c>true</c> [fire leave].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <returns></returns>
    private DataGridViewDataErrorEventArgs CommitEdit(
      ref DataGridViewCell objDataGridViewCurrentCell,
      DataGridViewDataErrorContexts enmContext,
      DataGridView.DataGridViewValidateCellInternal validateCell,
      bool blnFireCellLeave,
      bool blnFireCellEnter,
      bool blnFireRowLeave,
      bool blnFireRowEnter,
      bool blnFireLeave,
      bool blnClientSource)
    {
      Control editingControl = this.EditingControl;
      if (validateCell == DataGridView.DataGridViewValidateCellInternal.Always)
      {
        if (blnFireCellLeave)
        {
          if (this.mobjCurrentCellPoint.X == -1)
            return (DataGridViewDataErrorEventArgs) null;
          this.OnCellLeave(ref objDataGridViewCurrentCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
        }
        if (blnFireRowLeave)
        {
          if (this.mobjCurrentCellPoint.X == -1)
            return (DataGridViewDataErrorEventArgs) null;
          this.OnRowLeave(ref objDataGridViewCurrentCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
        }
        if (blnFireLeave)
        {
          this.OnLeave(EventArgs.Empty);
          if (this.mobjCurrentCellPoint.X > -1 && this.mobjCurrentCellPoint.Y > -1)
            this.InvalidateCellPrivate(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
        }
        if (this.CanValidateDataBoundDataGridViewCell(objDataGridViewCurrentCell))
        {
          if (this.mobjCurrentCellPoint.X == -1)
            return (DataGridViewDataErrorEventArgs) null;
          if (this.OnCellValidating(ref objDataGridViewCurrentCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y, enmContext))
          {
            if (blnFireRowEnter)
            {
              if (this.mobjCurrentCellPoint.X == -1)
                return (DataGridViewDataErrorEventArgs) null;
              this.OnRowEnter(ref objDataGridViewCurrentCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y, true, true);
            }
            if (blnFireCellEnter)
            {
              if (this.mobjCurrentCellPoint.X == -1)
                return (DataGridViewDataErrorEventArgs) null;
              this.OnCellEnter(ref objDataGridViewCurrentCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
            }
            if (this.mobjCurrentCellPoint.X == -1)
              return (DataGridViewDataErrorEventArgs) null;
            DataGridViewDataErrorEventArgs dataErrorEventArgs = new DataGridViewDataErrorEventArgs((Exception) null, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y, enmContext);
            dataErrorEventArgs.Cancel = true;
            return dataErrorEventArgs;
          }
          if (!this.IsCurrentCellInEditMode || !this.IsCurrentCellDirty)
          {
            if (this.mobjCurrentCellPoint.X == -1)
              return (DataGridViewDataErrorEventArgs) null;
            this.OnCellValidated(ref objDataGridViewCurrentCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
          }
        }
      }
      if (this.mobjCurrentCellPoint.X != -1 && this.IsCurrentCellInEditMode && this.IsCurrentCellDirty)
      {
        bool flag = this.CanValidateDataBoundDataGridViewCell(objDataGridViewCurrentCell);
        if (flag)
        {
          if (validateCell == DataGridView.DataGridViewValidateCellInternal.WhenChanged)
          {
            if (this.mobjCurrentCellPoint.X == -1)
              return (DataGridViewDataErrorEventArgs) null;
            if (this.OnCellValidating(ref objDataGridViewCurrentCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y, enmContext))
            {
              if (this.mobjCurrentCellPoint.X == -1)
                return (DataGridViewDataErrorEventArgs) null;
              DataGridViewDataErrorEventArgs dataErrorEventArgs = new DataGridViewDataErrorEventArgs((Exception) null, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y, enmContext);
              dataErrorEventArgs.Cancel = true;
              return dataErrorEventArgs;
            }
          }
          object objFormattedValue = editingControl == null ? this.CurrentCellInternal.EditingProposedValue : ((IDataGridViewEditingControl) editingControl).GetEditingControlFormattedValue(enmContext);
          Exception objException;
          if (!this.PushFormattedValue(ref objDataGridViewCurrentCell, objFormattedValue, out objException, blnClientSource))
          {
            if (this.mobjCurrentCellPoint.X == -1)
              return (DataGridViewDataErrorEventArgs) null;
            DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(objException, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y, enmContext);
            e.Cancel = true;
            this.OnDataErrorInternal(e);
            return e;
          }
          if (!this.IsCurrentCellInEditMode)
            return (DataGridViewDataErrorEventArgs) null;
          this.UneditedFormattedValue = objFormattedValue;
        }
        if (editingControl != null)
          ((IDataGridViewEditingControl) editingControl).EditingControlValueChanged = false;
        else
          ((IDataGridViewEditingCell) this.CurrentCellInternal).EditingCellValueChanged = false;
        this.SetIsCurrentCellDirtyInternal(false, blnClientSource);
        this.SetIsCurrentRowDirtyInternal(true, blnClientSource);
        if (flag && (validateCell == DataGridView.DataGridViewValidateCellInternal.Always || validateCell == DataGridView.DataGridViewValidateCellInternal.WhenChanged))
        {
          if (this.mobjCurrentCellPoint.X == -1)
            return (DataGridViewDataErrorEventArgs) null;
          this.OnCellValidated(ref objDataGridViewCurrentCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
        }
      }
      return (DataGridViewDataErrorEventArgs) null;
    }

    /// <summary>Pushes the formatted value.</summary>
    /// <param name="objDataGridViewCurrentCell">The data grid view current cell.</param>
    /// <param name="objFormattedValue">The formatted value.</param>
    /// <param name="objException">The exception.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <returns></returns>
    private bool PushFormattedValue(
      ref DataGridViewCell objDataGridViewCurrentCell,
      object objFormattedValue,
      out Exception objException,
      bool blnClientSource)
    {
      objException = (Exception) null;
      DataGridViewCellStyle editingCellStyle = this.InheritedEditingCellStyle;
      DataGridViewCellParsingEventArgs parsingEventArgs = this.OnCellParsing(this.mobjCurrentCellPoint.Y, this.mobjCurrentCellPoint.X, objFormattedValue, objDataGridViewCurrentCell.ValueType, editingCellStyle);
      if (parsingEventArgs.ParsingApplied && parsingEventArgs.Value != null && objDataGridViewCurrentCell.ValueType != (Type) null && objDataGridViewCurrentCell.ValueType.IsAssignableFrom(parsingEventArgs.Value.GetType()))
      {
        if (objDataGridViewCurrentCell.RowIndex == -1)
          objDataGridViewCurrentCell = this.Rows[this.mobjCurrentCellPoint.Y].Cells[this.mobjCurrentCellPoint.X];
        objDataGridViewCurrentCell.Update();
        return objDataGridViewCurrentCell.SetValueInternal(this.mobjCurrentCellPoint.Y, parsingEventArgs.Value);
      }
      object formattedValue;
      try
      {
        formattedValue = objDataGridViewCurrentCell.ParseFormattedValue(objFormattedValue, parsingEventArgs.InheritedCellStyle, (TypeConverter) null, (TypeConverter) null);
      }
      catch (Exception ex)
      {
        if (ClientUtils.IsCriticalException(ex))
        {
          throw;
        }
        else
        {
          objException = ex;
          return false;
        }
      }
      if (objDataGridViewCurrentCell.RowIndex == -1)
        objDataGridViewCurrentCell = this.Rows[this.mobjCurrentCellPoint.Y].Cells[this.mobjCurrentCellPoint.X];
      return objDataGridViewCurrentCell.SetValueInternal(this.mobjCurrentCellPoint.Y, formattedValue, blnClientSource);
    }

    /// <summary>Creates and returns a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see>.</summary>
    /// <returns>An empty <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual DataGridViewColumnCollection CreateColumnsInstance() => new DataGridViewColumnCollection(this);

    /// <summary>Creates and returns a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</summary>
    /// <returns>An empty <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual DataGridViewRowCollection CreateRowsInstance() => new DataGridViewRowCollection(this);

    /// <summary>Returns the number of columns displayed to the user.</summary>
    /// <returns>The number of columns displayed to the user.</returns>
    /// <param name="blnIncludePartialColumns">true to include partial columns in the displayed column count; otherwise, false. </param>
    /// <filterpriority>1</filterpriority>
    public int DisplayedColumnCount(bool blnIncludePartialColumns) => -1;

    private void RemoveIndividuallySelectedCells()
    {
      bool flag = false;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      if (individualSelectedCells.Count > 8)
      {
        ++this.BulkPaintCount;
        flag = true;
      }
      try
      {
        while (individualSelectedCells.Count > 0)
        {
          DataGridViewCell headCell = individualSelectedCells.HeadCell;
          this.SetSelectedCellCore(headCell.ColumnIndex, headCell.RowIndex, false);
        }
      }
      finally
      {
        if (flag)
          this.ExitBulkPaint(-1, -1);
      }
    }

    /// <summary>Removes the individually selected cells.</summary>
    /// <param name="intColumnIndexException">The int column index exception.</param>
    /// <param name="intRowIndexException">The int row index exception.</param>
    private void RemoveIndividuallySelectedCells(
      int intColumnIndexException,
      int intRowIndexException)
    {
      this.RemoveIndividuallySelectedCells(intColumnIndexException, intRowIndexException, false);
    }

    /// <summary>Removes the individually selected cells.</summary>
    /// <param name="intColumnIndexException">The int column index exception.</param>
    /// <param name="intRowIndexException">The int row index exception.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    private void RemoveIndividuallySelectedCells(
      int intColumnIndexException,
      int intRowIndexException,
      bool blnClientSource)
    {
      bool flag = false;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      if (individualSelectedCells.Count > 8)
      {
        ++this.BulkPaintCount;
        flag = true;
      }
      try
      {
        while (individualSelectedCells.Count > 0)
        {
          DataGridViewCell headCell = individualSelectedCells.HeadCell;
          if (headCell.ColumnIndex != intColumnIndexException || headCell.RowIndex != intRowIndexException)
          {
            this.SetSelectedCellCore(headCell.ColumnIndex, headCell.RowIndex, false, blnClientSource);
          }
          else
          {
            while (individualSelectedCells.Count > 1)
            {
              DataGridViewCell dataGridViewCell = individualSelectedCells[1];
              this.SetSelectedCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, false);
            }
            break;
          }
        }
      }
      finally
      {
        if (flag)
          this.ExitBulkPaint(-1, -1);
      }
    }

    private void RefreshColumnsAndRows()
    {
      this.Rows.ClearInternal(false);
      this.RefreshColumns();
      this.RefreshRows(true);
    }

    private void RefreshColumns()
    {
      bool visible = this.Visible;
      int num = visible ? 1 : 0;
      this.mobjDataGridViewOper[1024] = true;
      try
      {
        DataGridViewColumnCollection columns = this.Columns;
        DataGridViewColumn[] arrBoundColumns = (DataGridViewColumn[]) null;
        if (this.DataConnection != null)
          arrBoundColumns = this.DataConnection.GetCollectionOfBoundDataGridViewColumns();
        if (this.AutoGenerateColumns)
        {
          this.AutoGenerateDataBoundColumns(arrBoundColumns);
        }
        else
        {
          for (int index = 0; index < columns.Count; ++index)
          {
            columns[index].IsDataBoundInternal = false;
            columns[index].BoundColumnIndex = -1;
            columns[index].BoundColumnConverter = (TypeConverter) null;
            if (this.DataSource != null && columns[index].DataPropertyName.Length != 0)
              this.MapDataGridViewColumnToDataBoundField(columns[index]);
          }
        }
        if (this.DataSource == null)
          return;
        this.DataConnection.ApplySortingInformationFromBackEnd();
      }
      finally
      {
        this.mobjDataGridViewOper[1024] = false;
        if (visible)
          this.Invalidate(true);
      }
    }

    private void MapDataGridViewColumnToDataBoundField(DataGridViewColumn objDataGridViewColumn)
    {
      DataGridView.DataGridViewDataConnection dataConnection = this.DataConnection;
      int intBoundColumnIndex = dataConnection == null ? -1 : dataConnection.BoundColumnIndex(objDataGridViewColumn.DataPropertyName);
      if (intBoundColumnIndex != -1)
      {
        objDataGridViewColumn.IsDataBoundInternal = true;
        objDataGridViewColumn.BoundColumnIndex = intBoundColumnIndex;
        objDataGridViewColumn.BoundColumnConverter = dataConnection.BoundColumnConverter(intBoundColumnIndex);
        objDataGridViewColumn.ValueType = dataConnection.BoundColumnValueType(intBoundColumnIndex);
        objDataGridViewColumn.ReadOnly = dataConnection.DataFieldIsReadOnly(objDataGridViewColumn.BoundColumnIndex) || objDataGridViewColumn.ReadOnly;
        this.InvalidateColumnInternal(objDataGridViewColumn.Index);
        if (objDataGridViewColumn.SortMode == DataGridViewColumnSortMode.NotSortable || this.mobjDataGridViewOper[1024])
          return;
        objDataGridViewColumn.HeaderCell.SortGlyphDirection = dataConnection.BoundColumnSortOrder(intBoundColumnIndex);
        if (this.SortedColumn != null || objDataGridViewColumn.HeaderCell.SortGlyphDirection == SortOrder.None)
          return;
        this.SortedColumn = objDataGridViewColumn;
        this.SortOrder = objDataGridViewColumn.HeaderCell.SortGlyphDirection;
      }
      else
      {
        objDataGridViewColumn.IsDataBoundInternal = false;
        objDataGridViewColumn.BoundColumnIndex = -1;
        objDataGridViewColumn.BoundColumnConverter = (TypeConverter) null;
        this.InvalidateColumnInternal(objDataGridViewColumn.Index);
      }
    }

    private void AutoGenerateDataBoundColumns(DataGridViewColumn[] arrBoundColumns)
    {
      DataGridViewColumnCollection columns = this.Columns;
      DataGridViewColumn[] sourceArray = new DataGridViewColumn[columns.Count];
      int length = 0;
      for (int index = 0; index < columns.Count; ++index)
      {
        if (this.DataSource != null)
        {
          if (!CommonUtils.IsNullOrEmpty(columns[index].DataPropertyName) && !columns[index].IsDataBound)
            this.MapDataGridViewColumnToDataBoundField(columns[index]);
        }
        if (columns[index].IsDataBound && this.DataConnection != null && this.DataConnection.BoundColumnIndex(columns[index].DataPropertyName) != -1)
        {
          sourceArray[length] = (DataGridViewColumn) columns[index].Clone();
          sourceArray[length].DisplayIndex = columns[index].DisplayIndex;
          ++length;
        }
      }
      int index1 = 0;
      while (index1 < columns.Count)
      {
        if (columns[index1].IsDataBound)
          columns.RemoveAtInternal(index1, true);
        else
          ++index1;
      }
      DataGridViewColumn[] destinationArray;
      if (sourceArray.Length == length)
      {
        destinationArray = sourceArray;
      }
      else
      {
        destinationArray = new DataGridViewColumn[length];
        Array.Copy((Array) sourceArray, (Array) destinationArray, length);
      }
      Array.Sort((Array) destinationArray, DataGridViewColumnCollection.ColumnCollectionOrderComparer);
      if (arrBoundColumns == null)
        return;
      for (int index2 = 0; index2 < arrBoundColumns.Length; ++index2)
      {
        if (arrBoundColumns[index2] != null && arrBoundColumns[index2].IsBrowsableInternal)
        {
          bool flag = true;
          int index3;
          for (index3 = 0; index3 < length; ++index3)
          {
            if (destinationArray[index3] != null && string.Compare(destinationArray[index3].DataPropertyName, arrBoundColumns[index2].DataPropertyName, true, CultureInfo.InvariantCulture) == 0)
            {
              flag = false;
              break;
            }
          }
          if (flag)
          {
            columns.Add(arrBoundColumns[index2]);
          }
          else
          {
            columns.Add(destinationArray[index3]);
            this.MapDataGridViewColumnToDataBoundField(destinationArray[index3]);
            destinationArray[index3] = (DataGridViewColumn) null;
          }
        }
      }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void RefreshRows(bool blnScrollIntoView)
    {
      bool visible = this.Visible;
      int num = visible ? 1 : 0;
      try
      {
        if (this.mobjDataGridViewOper[131072])
          this.mobjDataGridViewState2[4194304] = true;
        DataGridViewRowCollection rows = this.Rows;
        rows.ClearInternal(true);
        if (this.DataConnection == null || this.Columns.Count <= 0)
          return;
        IList list = this.DataConnection.List;
        if (list == null || list.Count <= 0)
          return;
        int count = list.Count;
        bool theCurrencyManager = this.DataConnection.DoNotChangePositionInTheCurrencyManager;
        bool flag = !this.InSortOperation;
        if (flag)
          this.DataConnection.DoNotChangePositionInTheCurrencyManager = true;
        try
        {
          rows.AddInternal(this.RowTemplateClone);
          if (count > 1)
            rows.AddCopiesInternal(0, count - 1);
        }
        finally
        {
          this.DataConnection.DoNotChangePositionInTheCurrencyManager = theCurrencyManager;
        }
        if (!flag)
          return;
        this.DataConnection.MatchCurrencyManagerPosition(blnScrollIntoView, true);
      }
      finally
      {
        if (visible)
          this.Invalidate(true);
      }
    }

    /// <summary>Returns the number of rows displayed to the user.</summary>
    /// <returns>The number of rows displayed to the user.</returns>
    /// <param name="blnIncludePartialRow">true to include partial rows in the displayed row count; otherwise, false. </param>
    /// <filterpriority>1</filterpriority>
    public int DisplayedRowCount(bool blnIncludePartialRow) => -1;

    /// <summary>Gets a type convertor or creates a new one</summary>
    /// <param name="objType"></param>
    /// <returns></returns>
    internal TypeConverter GetCachedTypeConverter(Type objType) => new TypeConverter();

    /// <summary>Commits and ends the edit operation on the current cell using the default error context.</summary>
    /// <returns>true if the edit operation is committed and ended; otherwise, false.</returns>
    /// <exception cref="T:System.Exception">The cell value could not be committed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    public bool EndEdit() => this.EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing);

    /// <summary>Scrolls the into view.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnForCurrentCellChange">if set to <c>true</c> [for current cell change].</param>
    /// <returns></returns>
    private bool ScrollIntoView(int intColumnIndex, int intRowIndex, bool blnForCurrentCellChange)
    {
      if (this.mobjCurrentCellPoint.X >= 0 && (this.mobjCurrentCellPoint.X != intColumnIndex || this.mobjCurrentCellPoint.Y != intRowIndex) && (!this.CommitEditForOperation(intColumnIndex, intRowIndex, blnForCurrentCellChange) || this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex)) || this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
        return false;
      DataGridViewRow dataGridViewRow = this.Rows.SharedRow(intRowIndex);
      if (dataGridViewRow != null)
        this.PerformScrollIntoView(dataGridViewRow.Cells[intColumnIndex], false);
      return true;
    }

    /// <summary>Commits and ends the edit operation on the current cell using the specified error context.</summary>
    /// <returns>true if the edit operation is committed and ended; otherwise, false.</returns>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which an error can occur. </param>
    /// <exception cref="T:System.Exception">The cell value could not be committed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    public bool EndEdit(DataGridViewDataErrorContexts enmContext) => this.EditMode == DataGridViewEditMode.EditOnEnter ? this.CommitEdit(enmContext) : this.EndEdit(enmContext, DataGridView.DataGridViewValidateCellInternal.Never, false, false, false, false, false, true, true, true);

    /// <summary>
    /// Determines whether this instance [can validate data bound data grid view cell] the specified data grid view current cell.
    /// </summary>
    /// <param name="objDataGridViewCurrentCell">The data grid view current cell.</param>
    /// <returns>
    /// 	<c>true</c> if this instance [can validate data bound data grid view cell] the specified data grid view current cell; otherwise, <c>false</c>.
    /// </returns>
    private bool CanValidateDataBoundDataGridViewCell(DataGridViewCell objDataGridViewCurrentCell)
    {
      if (objDataGridViewCurrentCell == null && this.mobjCurrentCellPoint.X > -1)
        objDataGridViewCurrentCell = this.CurrentCellInternal;
      return objDataGridViewCurrentCell == null || !objDataGridViewCurrentCell.OwningColumn.IsDataBoundInternal || !this.mobjDataGridViewOper[1048576] && (this.DataConnection == null || !this.DataConnection.ProcessingMetaDataChanges && (!this.DataConnection.CancellingRowEdit || this.DataConnection.RestoreRow) && this.DataConnection.CurrencyManager.Count > this.mobjCurrentCellPoint.Y && !this.DataConnection.PositionChangingOutsideDataGridView && !this.DataConnection.ListWasReset);
    }

    /// <summary>Called when [cell validating].</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="enmContext">The context.</param>
    /// <returns></returns>
    internal bool OnCellValidating(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex,
      DataGridViewDataErrorContexts enmContext)
    {
      DataGridViewCell dataGridViewCell = objDataGridViewCell == null ? this.CurrentCellInternal : objDataGridViewCell;
      dataGridViewCell.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, false);
      dataGridViewCell.GetValueInternal(intRowIndex);
      object objFormattedValue = dataGridViewCell.EditingProposedValue == null ? dataGridViewCell.FormattedValue : dataGridViewCell.EditingProposedValue;
      DataGridViewCellValidatingEventArgs e = new DataGridViewCellValidatingEventArgs(intColumnIndex, intRowIndex, objFormattedValue);
      this.OnCellValidating(e);
      if (objDataGridViewCell != null)
        objDataGridViewCell = !this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex) ? this.Rows.SharedRow(intRowIndex).Cells[intColumnIndex] : (DataGridViewCell) null;
      return e.Cancel;
    }

    /// <summary>Called when [cell validated].</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    internal void OnCellValidated(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex)
    {
      this.OnCellValidated(new DataGridViewCellEventArgs(intColumnIndex, intRowIndex));
      if (objDataGridViewCell == null)
        return;
      if (this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
        objDataGridViewCell = (DataGridViewCell) null;
      else
        objDataGridViewCell = this.Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
    }

    /// <summary>Ends the edit.</summary>
    /// <param name="enmContext">The context.</param>
    /// <param name="validateCell">The validate cell.</param>
    /// <param name="blnFireCellLeave">if set to <c>true</c> [fire cell leave].</param>
    /// <param name="blnFireCellEnter">if set to <c>true</c> [fire cell enter].</param>
    /// <param name="blnFireRowLeave">if set to <c>true</c> [fire row leave].</param>
    /// <param name="blnFireRowEnter">if set to <c>true</c> [fire row enter].</param>
    /// <param name="blnFireLeave">if set to <c>true</c> [fire leave].</param>
    /// <param name="blnKeepFocus">Obsolete(not used), performed on client side.</param>
    /// <param name="blnResetCurrentCell">if set to <c>true</c> [reset current cell].</param>
    /// <param name="blnResetAnchorCell">if set to <c>true</c> [reset anchor cell].</param>
    /// <returns></returns>
    private bool EndEdit(
      DataGridViewDataErrorContexts enmContext,
      DataGridView.DataGridViewValidateCellInternal validateCell,
      bool blnFireCellLeave,
      bool blnFireCellEnter,
      bool blnFireRowLeave,
      bool blnFireRowEnter,
      bool blnFireLeave,
      bool blnKeepFocus,
      bool blnResetCurrentCell,
      bool blnResetAnchorCell)
    {
      return this.EndEdit(enmContext, validateCell, blnFireCellLeave, blnFireCellEnter, blnFireRowLeave, blnFireRowEnter, blnFireLeave, blnKeepFocus, blnResetCurrentCell, blnResetAnchorCell, false);
    }

    /// <summary>Ends the edit.</summary>
    /// <param name="enmContext">The context.</param>
    /// <param name="validateCell">The validate cell.</param>
    /// <param name="blnFireCellLeave">if set to <c>true</c> [fire cell leave].</param>
    /// <param name="blnFireCellEnter">if set to <c>true</c> [fire cell enter].</param>
    /// <param name="blnFireRowLeave">if set to <c>true</c> [fire row leave].</param>
    /// <param name="blnFireRowEnter">if set to <c>true</c> [fire row enter].</param>
    /// <param name="blnFireLeave">if set to <c>true</c> [fire leave].</param>
    /// <param name="blnKeepFocus">Obsolete(not used), performed on client side.</param>
    /// <param name="blnResetCurrentCell">if set to <c>true</c> [reset current cell].</param>
    /// <param name="blnResetAnchorCell">if set to <c>true</c> [reset anchor cell].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <returns></returns>
    private bool EndEdit(
      DataGridViewDataErrorContexts enmContext,
      DataGridView.DataGridViewValidateCellInternal validateCell,
      bool blnFireCellLeave,
      bool blnFireCellEnter,
      bool blnFireRowLeave,
      bool blnFireRowEnter,
      bool blnFireLeave,
      bool blnKeepFocus,
      bool blnResetCurrentCell,
      bool blnResetAnchorCell,
      bool blnClientSource)
    {
      if (this.mobjCurrentCellPoint.X == -1)
        return true;
      this.mobjDataGridViewOper[4194304] = true;
      try
      {
        int y = this.mobjCurrentCellPoint.Y;
        int x = this.mobjCurrentCellPoint.X;
        DataGridViewCell currentCellInternal = this.CurrentCellInternal;
        DataGridViewDataErrorEventArgs dataErrorEventArgs1 = this.CommitEdit(ref currentCellInternal, enmContext, validateCell, blnFireCellLeave, blnFireCellEnter, blnFireRowLeave, blnFireRowEnter, blnFireLeave, blnClientSource);
        if (dataErrorEventArgs1 != null)
        {
          if (dataErrorEventArgs1.ThrowException)
            throw dataErrorEventArgs1.Exception;
          if (dataErrorEventArgs1.Cancel)
            return false;
          DataGridViewDataErrorEventArgs dataErrorEventArgs2 = this.CancelEditPrivate();
          if (dataErrorEventArgs2 != null)
          {
            if (dataErrorEventArgs2.ThrowException)
              throw dataErrorEventArgs2.Exception;
            if (dataErrorEventArgs2.Cancel)
              return false;
          }
        }
        if (!this.IsCurrentCellInEditMode || y != this.mobjCurrentCellPoint.Y || x != this.mobjCurrentCellPoint.X)
          return true;
        if (this.EditingControl != null)
        {
          this.mobjDataGridViewState1[16384] = true;
          try
          {
            currentCellInternal.DetachEditingControl();
          }
          finally
          {
            this.mobjDataGridViewState1[16384] = false;
          }
          this.LatestEditingControl = this.EditingControl;
          this.EditingControl = (Control) null;
          if (!blnClientSource)
            this.InvalidateCellPrivate(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
          if (this.EditMode == DataGridViewEditMode.EditOnEnter & blnResetCurrentCell)
            this.SetCurrentCellAddressCore(-1, -1, blnResetAnchorCell, false, false);
        }
        else
        {
          this.mobjDataGridViewState1[32768] = false;
          this.InvalidateCellPrivate(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
        }
        if (!this.IsInnerCellOutOfBounds(x, y))
          this.OnCellEndEdit(new DataGridViewCellEventArgs(x, y));
      }
      finally
      {
        this.mobjDataGridViewOper[4194304] = false;
      }
      return true;
    }

    /// <summary>Gets the owner form.</summary>
    public override Form Form
    {
      get
      {
        DataGridView rootGrid = this.RootGrid;
        return rootGrid != null && rootGrid != this ? rootGrid.Form : base.Form;
      }
    }

    private bool IsColumnOutOfBounds(int intColumnIndex) => intColumnIndex >= this.Columns.Count || intColumnIndex == -1;

    private DataGridViewDataErrorEventArgs CancelEditPrivate()
    {
      bool currentCellDirty = this.IsCurrentCellDirty;
      bool isCurrentRowDirty = this.IsCurrentRowDirty;
      if (this.IsCurrentCellInEditMode)
      {
        if (this.EditingControl != null)
          ((IDataGridViewEditingControl) this.EditingControl).EditingControlValueChanged = false;
        else
          ((IDataGridViewEditingCell) this.CurrentCellInternal).EditingCellValueChanged = false;
        this.IsCurrentCellDirtyInternal = false;
      }
      if (this.DataSource != null || this.VirtualMode)
      {
        if (isCurrentRowDirty && !currentCellDirty || this.mobjDataGridViewState1[524288] && !this.mobjDataGridViewState1[262144])
        {
          bool blnResponse = this.mobjDataGridViewState1[524288];
          this.IsCurrentRowDirtyInternal = false;
          if (this.VirtualMode)
          {
            QuestionEventArgs e = new QuestionEventArgs(blnResponse);
            this.OnCancelRowEdit(e);
            blnResponse &= e.Response;
          }
          if (this.DataSource != null)
          {
            int x = this.mobjCurrentCellPoint.X;
            this.DataConnection.CancelRowEdit(true, this.mobjDataGridViewState1[524288]);
            if (this.DataConnection.List.Count == 0)
            {
              if (currentCellDirty || this.mobjCurrentCellPoint.Y == -1 || this.mobjCurrentCellPoint.X == -1)
              {
                if (!this.IsColumnOutOfBounds(x) && this.Columns[x].Visible)
                  this.SetAndSelectCurrentCellAddress(x, 0, true, false, false, true, false);
              }
              else
                this.DataConnection.OnNewRowNeeded();
            }
            blnResponse = false;
          }
          if (this.mobjCurrentCellPoint.Y > -1)
          {
            this.InvalidateRowPrivate(this.mobjCurrentCellPoint.Y);
            DataGridViewCell currentCellInternal = this.CurrentCellInternal;
            if (this.IsCurrentCellInEditMode)
            {
              DataGridViewCellStyle inheritedStyle = currentCellInternal.GetInheritedStyle((DataGridViewCellStyle) null, this.mobjCurrentCellPoint.Y, true);
              if (this.EditingControl != null)
                this.InitializeEditingControlValue(ref inheritedStyle, currentCellInternal);
              else
                this.InitializeEditingCellValue(ref inheritedStyle, ref currentCellInternal);
            }
          }
          if (blnResponse && this.mobjCurrentCellPoint.Y == this.NewRowIndex - 1)
            this.DiscardNewRow();
        }
      }
      else if (!this.IsCurrentRowDirty && this.mobjCurrentCellPoint.Y == this.NewRowIndex - 1 && this.mobjDataGridViewState1[2097152])
        this.DiscardNewRow();
      return (DataGridViewDataErrorEventArgs) null;
    }

    private void DiscardNewRow()
    {
      DataGridViewRowCollection rows = this.Rows;
      DataGridViewRowCancelEventArgs e = new DataGridViewRowCancelEventArgs(rows[this.NewRowIndex]);
      this.OnUserDeletingRow(e);
      if (e.Cancel)
        return;
      DataGridViewRow objDataGridViewRow = rows[this.NewRowIndex];
      rows.RemoveAtInternal(this.NewRowIndex, false);
      this.OnUserDeletedRow(new DataGridViewRowEventArgs(objDataGridViewRow));
      if (!this.AllowUserToAddRowsInternal)
        return;
      this.NewRowIndex = rows.Count - 1;
      this.OnDefaultValuesNeeded(new DataGridViewRowEventArgs(rows[this.NewRowIndex]));
      this.InvalidateRowPrivate(this.NewRowIndex);
    }

    /// <summary>Gets the number of cells that satisfy the provided filter.</summary>
    /// <returns>The number of cells that match the includeFilter parameter.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values specifying the cells to count.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter includes the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewElementStates.ResizableSet"></see>.</exception>
    public int GetCellCount(DataGridViewElementStates enmIncludeFilter)
    {
      DataGridViewRowCollection rows = this.Rows;
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      int cellCount = 0;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      if ((enmIncludeFilter & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
      {
        if (enmIncludeFilter == DataGridViewElementStates.Selected)
        {
          cellCount = individualSelectedCells.Count;
          switch (this.SelectionMode)
          {
            case DataGridViewSelectionMode.CellSelect:
              return cellCount;
            case DataGridViewSelectionMode.FullRowSelect:
            case DataGridViewSelectionMode.RowHeaderSelect:
              return cellCount + this.SelectedBandIndexes.Count * this.Columns.Count;
            case DataGridViewSelectionMode.FullColumnSelect:
            case DataGridViewSelectionMode.ColumnHeaderSelect:
              return cellCount + this.SelectedBandIndexes.Count * rows.Count;
          }
        }
        bool blnDisplayedRequired = (enmIncludeFilter & DataGridViewElementStates.Displayed) == DataGridViewElementStates.Displayed;
        bool blnFrozenRequired = (enmIncludeFilter & DataGridViewElementStates.Frozen) == DataGridViewElementStates.Frozen;
        bool blnResizableRequired = (enmIncludeFilter & DataGridViewElementStates.Resizable) == DataGridViewElementStates.Resizable;
        bool blnReadOnlyRequired = (enmIncludeFilter & DataGridViewElementStates.ReadOnly) == DataGridViewElementStates.ReadOnly;
        bool blnVisibleRequired = (enmIncludeFilter & DataGridViewElementStates.Visible) == DataGridViewElementStates.Visible;
        foreach (DataGridViewCell objDataGridViewCell in (IEnumerable) individualSelectedCells)
        {
          if (this.GetCellCount_CellIncluded(objDataGridViewCell, objDataGridViewCell.RowIndex, blnDisplayedRequired, blnFrozenRequired, blnResizableRequired, blnReadOnlyRequired, blnVisibleRequired))
            ++cellCount;
        }
        switch (this.SelectionMode)
        {
          case DataGridViewSelectionMode.CellSelect:
            return cellCount;
          case DataGridViewSelectionMode.FullRowSelect:
          case DataGridViewSelectionMode.RowHeaderSelect:
            foreach (int selectedBandIndex in (IEnumerable) this.SelectedBandIndexes)
            {
              foreach (DataGridViewCell cell in (BaseCollection) rows.SharedRow(selectedBandIndex).Cells)
              {
                if (this.GetCellCount_CellIncluded(cell, selectedBandIndex, blnDisplayedRequired, blnFrozenRequired, blnResizableRequired, blnReadOnlyRequired, blnVisibleRequired))
                  ++cellCount;
              }
            }
            return cellCount;
          case DataGridViewSelectionMode.FullColumnSelect:
          case DataGridViewSelectionMode.ColumnHeaderSelect:
            for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
            {
              DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
              foreach (int selectedBandIndex in (IEnumerable) this.SelectedBandIndexes)
              {
                if (this.GetCellCount_CellIncluded(dataGridViewRow.Cells[selectedBandIndex], intRowIndex, blnDisplayedRequired, blnFrozenRequired, blnResizableRequired, blnReadOnlyRequired, blnVisibleRequired))
                  ++cellCount;
              }
            }
            return cellCount;
        }
      }
      if (enmIncludeFilter == DataGridViewElementStates.ReadOnly && this.ReadOnly || enmIncludeFilter == DataGridViewElementStates.None)
        return rows.Count * this.Columns.Count;
      bool blnDisplayedRequired1 = (enmIncludeFilter & DataGridViewElementStates.Displayed) == DataGridViewElementStates.Displayed;
      bool blnFrozenRequired1 = (enmIncludeFilter & DataGridViewElementStates.Frozen) == DataGridViewElementStates.Frozen;
      bool blnResizableRequired1 = (enmIncludeFilter & DataGridViewElementStates.Resizable) == DataGridViewElementStates.Resizable;
      bool blnReadOnlyRequired1 = (enmIncludeFilter & DataGridViewElementStates.ReadOnly) == DataGridViewElementStates.ReadOnly;
      bool blnVisibleRequired1 = (enmIncludeFilter & DataGridViewElementStates.Visible) == DataGridViewElementStates.Visible;
      for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
      {
        DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
        if (!blnVisibleRequired1 || (rows.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
        {
          foreach (DataGridViewCell cell in (BaseCollection) dataGridViewRow.Cells)
          {
            if (this.GetCellCount_CellIncluded(cell, intRowIndex, blnDisplayedRequired1, blnFrozenRequired1, blnResizableRequired1, blnReadOnlyRequired1, blnVisibleRequired1))
              ++cellCount;
          }
        }
      }
      return cellCount;
    }

    /// <summary>Indicates if a specific row is resizable</summary>
    /// <param name="intRowIndex"></param>
    /// <returns></returns>
    private bool RowIsResizable(int intRowIndex)
    {
      DataGridViewElementStates rowState = this.Rows.GetRowState(intRowIndex);
      return (rowState & DataGridViewElementStates.ResizableSet) == DataGridViewElementStates.ResizableSet ? (rowState & DataGridViewElementStates.Resizable) == DataGridViewElementStates.Resizable : this.AllowUserToResizeRows;
    }

    /// <summary>Check if cell is included</summary>
    /// <param name="objDataGridViewCell"></param>
    /// <param name="intRowIndex"></param>
    /// <param name="blnDisplayedRequired"></param>
    /// <param name="blnFrozenRequired"></param>
    /// <param name="blnResizableRequired"></param>
    /// <param name="blnReadOnlyRequired"></param>
    /// <param name="blnVisibleRequired"></param>
    /// <returns></returns>
    private bool GetCellCount_CellIncluded(
      DataGridViewCell objDataGridViewCell,
      int intRowIndex,
      bool blnDisplayedRequired,
      bool blnFrozenRequired,
      bool blnResizableRequired,
      bool blnReadOnlyRequired,
      bool blnVisibleRequired)
    {
      DataGridViewElementStates rowState = this.Rows.GetRowState(intRowIndex);
      return (!blnDisplayedRequired || (rowState & DataGridViewElementStates.Displayed) != DataGridViewElementStates.None && objDataGridViewCell.OwningColumn.Displayed) && (!blnFrozenRequired || (rowState & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None || objDataGridViewCell.OwningColumn.Frozen || objDataGridViewCell.StateIncludes(DataGridViewElementStates.Frozen)) && (!blnResizableRequired || this.RowIsResizable(intRowIndex) || objDataGridViewCell.OwningColumn.Resizable == DataGridViewTriState.True) && (!blnReadOnlyRequired || this.ReadOnly || (rowState & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || objDataGridViewCell.OwningColumn.ReadOnly || objDataGridViewCell.StateIncludes(DataGridViewElementStates.ReadOnly)) && (!blnVisibleRequired || (rowState & DataGridViewElementStates.Visible) != DataGridViewElementStates.None && objDataGridViewCell.OwningColumn.Visible);
    }

    /// <summary>Retrieves the formatted values that represent the contents of the selected cells for copying to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> that represents the contents of the selected cells.</returns>
    /// <exception cref="T:System.NotSupportedException"><see cref="P:Gizmox.WebGUI.Forms.DataGridView.ClipboardCopyMode"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode.Disable"></see>.</exception>
    public virtual DataObject GetClipboardContent() => this.GetClipboardContentInternal(new string[4]
    {
      DataFormats.Html,
      DataFormats.Text,
      DataFormats.UnicodeText,
      DataFormats.CommaSeparatedValue
    });

    private static string ConvertToDataFormats(TextDataFormat enmFormat)
    {
      switch (enmFormat)
      {
        case TextDataFormat.Text:
          return DataFormats.Text;
        case TextDataFormat.UnicodeText:
          return DataFormats.UnicodeText;
        case TextDataFormat.Rtf:
          return DataFormats.Rtf;
        case TextDataFormat.Html:
          return DataFormats.Html;
        case TextDataFormat.CommaSeparatedValue:
          return DataFormats.CommaSeparatedValue;
        default:
          return DataFormats.UnicodeText;
      }
    }

    /// <summary>Retrieves the formatted values that represent the contents of the selected cells for copying to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
    /// <param name="enmFormat">The serializing format to be produced.</param>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> that represents the contents of the selected cells.</returns>
    /// <exception cref="T:System.NotSupportedException"><see cref="P:Gizmox.WebGUI.Forms.DataGridView.ClipboardCopyMode"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode.Disable"></see>.</exception>
    public virtual DataObject GetClipboardContent(TextDataFormat enmFormat) => this.GetClipboardContentInternal(new string[1]
    {
      DataGridView.ConvertToDataFormats(enmFormat)
    });

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrText"></param>
    /// <returns></returns>
    private DataObject GetClipboardContentInternal(string[] arrText)
    {
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      DataGridViewRowCollection rows = this.Rows;
      if (this.ClipboardCopyMode == DataGridViewClipboardCopyMode.Disable)
        throw new NotSupportedException(SR.GetString("DataGridView_DisabledClipboardCopy"));
      DataObject clipboardContentInternal1 = new DataObject();
      StringBuilder sbContent = (StringBuilder) null;
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.CellSelect:
        case DataGridViewSelectionMode.RowHeaderSelect:
        case DataGridViewSelectionMode.ColumnHeaderSelect:
          bool flag1 = false;
          bool flag2 = false;
          bool flag3 = false;
          if (this.SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
          {
            if (this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
            {
              flag2 = this.Columns.GetColumnCount(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) != 0;
              flag1 = flag2 && rows.GetRowCount(DataGridViewElementStates.Visible) != 0;
            }
          }
          else
          {
            flag3 = rows.GetRowCount(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) != 0;
            flag1 = flag3 && this.Columns.GetColumnCount(DataGridViewElementStates.Visible) != 0;
          }
          if (!flag1 && individualSelectedCells.Count > 0)
          {
            foreach (DataGridViewCell dataGridViewCell in (IEnumerable) individualSelectedCells)
            {
              if (dataGridViewCell.Visible)
              {
                flag1 = true;
                break;
              }
            }
          }
          if (!flag1)
            return (DataObject) null;
          bool flag4;
          bool flag5;
          if (this.SelectionMode == DataGridViewSelectionMode.CellSelect)
          {
            bool flag6;
            flag4 = (flag6 = this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText) & this.ColumnHeadersVisible;
            flag5 = flag6 & this.RowHeadersVisible;
          }
          else
          {
            flag4 = flag5 = false;
            if (this.ColumnHeadersVisible)
            {
              if (this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)
              {
                if (flag2)
                  flag4 = true;
              }
              else
                flag4 = this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            }
            if (this.RowHeadersVisible)
            {
              if (this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)
              {
                if (flag3)
                  flag5 = true;
              }
              else
                flag5 = this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            }
          }
          int num1 = int.MaxValue;
          int num2 = -1;
          DataGridViewColumn dataGridViewColumn1 = (DataGridViewColumn) null;
          DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn) null;
          if (this.SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
          {
            if (this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
            {
              int firstRow = rows.GetFirstRow(DataGridViewElementStates.Visible);
              int lastRow = rows.GetLastRow(DataGridViewElementStates.Visible);
              foreach (int selectedBandIndex in (IEnumerable) this.SelectedBandIndexes)
              {
                if (this.Columns[selectedBandIndex].Visible)
                {
                  if (dataGridViewColumn1 == null || this.Columns.DisplayInOrder(selectedBandIndex, dataGridViewColumn1.Index))
                    dataGridViewColumn1 = this.Columns[selectedBandIndex];
                  if (dataGridViewColumn2 == null || this.Columns.DisplayInOrder(dataGridViewColumn2.Index, selectedBandIndex))
                    dataGridViewColumn2 = this.Columns[selectedBandIndex];
                  num1 = firstRow;
                  num2 = lastRow;
                }
              }
            }
          }
          else
          {
            DataGridViewColumn firstColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
            DataGridViewColumn lastColumn = this.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);
            foreach (int selectedBandIndex in (IEnumerable) this.SelectedBandIndexes)
            {
              if ((rows.GetRowState(selectedBandIndex) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
              {
                if (selectedBandIndex < num1)
                  num1 = selectedBandIndex;
                if (selectedBandIndex > num2)
                  num2 = selectedBandIndex;
                dataGridViewColumn1 = firstColumn;
                dataGridViewColumn2 = lastColumn;
              }
            }
          }
          foreach (DataGridViewCell dataGridViewCell in (IEnumerable) individualSelectedCells)
          {
            if (dataGridViewCell.Visible)
            {
              if (dataGridViewCell.RowIndex < num1)
                num1 = dataGridViewCell.RowIndex;
              if (dataGridViewCell.RowIndex > num2)
                num2 = dataGridViewCell.RowIndex;
              if (dataGridViewColumn1 == null || this.Columns.DisplayInOrder(dataGridViewCell.ColumnIndex, dataGridViewColumn1.Index))
                dataGridViewColumn1 = dataGridViewCell.OwningColumn;
              if (dataGridViewColumn2 == null || this.Columns.DisplayInOrder(dataGridViewColumn2.Index, dataGridViewCell.ColumnIndex))
                dataGridViewColumn2 = dataGridViewCell.OwningColumn;
            }
          }
          foreach (string strFormat in arrText)
          {
            if (sbContent == null)
              sbContent = new StringBuilder(1024);
            else
              sbContent.Length = 0;
            if (flag4)
            {
              if (this.RightToLeftInternal)
              {
                DataGridViewColumn previousColumn;
                for (DataGridViewColumn objDataGridViewColumnStart = dataGridViewColumn2; objDataGridViewColumnStart != null; objDataGridViewColumnStart = previousColumn)
                {
                  previousColumn = objDataGridViewColumnStart == dataGridViewColumn1 ? (DataGridViewColumn) null : this.Columns.GetPreviousColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (objDataGridViewColumnStart.HeaderCell.GetClipboardContentInternal(-1, objDataGridViewColumnStart == dataGridViewColumn2, !flag5 && previousColumn == null, true, false, strFormat) is string clipboardContentInternal2)
                    sbContent.Append(clipboardContentInternal2);
                }
                if (flag5 && this.TopLeftHeaderCell.GetClipboardContentInternal(-1, false, true, true, false, strFormat) is string clipboardContentInternal3)
                  sbContent.Append(clipboardContentInternal3);
              }
              else
              {
                if (flag5 && this.TopLeftHeaderCell.GetClipboardContentInternal(-1, true, false, true, false, strFormat) is string clipboardContentInternal4)
                  sbContent.Append(clipboardContentInternal4);
                DataGridViewColumn nextColumn;
                for (DataGridViewColumn objDataGridViewColumnStart = dataGridViewColumn1; objDataGridViewColumnStart != null; objDataGridViewColumnStart = nextColumn)
                {
                  nextColumn = objDataGridViewColumnStart == dataGridViewColumn2 ? (DataGridViewColumn) null : this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (objDataGridViewColumnStart.HeaderCell.GetClipboardContentInternal(-1, !flag5 && objDataGridViewColumnStart == dataGridViewColumn1, nextColumn == null, true, false, strFormat) is string clipboardContentInternal5)
                    sbContent.Append(clipboardContentInternal5);
                }
              }
            }
            bool flag7 = true;
            int num3 = num1;
            while (num3 != -1)
            {
              int num4 = num3 == num2 ? -1 : rows.GetNextRow(num3, DataGridViewElementStates.Visible);
              if (this.RightToLeftInternal)
              {
                DataGridViewColumn previousColumn;
                for (DataGridViewColumn objDataGridViewColumnStart = dataGridViewColumn2; objDataGridViewColumnStart != null; objDataGridViewColumnStart = previousColumn)
                {
                  previousColumn = objDataGridViewColumnStart == dataGridViewColumn1 ? (DataGridViewColumn) null : this.Columns.GetPreviousColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (rows.SharedRow(num3).Cells[objDataGridViewColumnStart.Index].GetClipboardContentInternal(num3, objDataGridViewColumnStart == dataGridViewColumn2, !flag5 && previousColumn == null, !flag4 & flag7, num4 == -1, strFormat) is string clipboardContentInternal6)
                    sbContent.Append(clipboardContentInternal6);
                }
                if (flag5 && rows.SharedRow(num3).HeaderCell.GetClipboardContentInternal(num3, false, true, !flag4 & flag7, num4 == -1, strFormat) is string clipboardContentInternal7)
                  sbContent.Append(clipboardContentInternal7);
              }
              else
              {
                if (flag5 && rows.SharedRow(num3).HeaderCell.GetClipboardContentInternal(num3, true, false, !flag4 & flag7, num4 == -1, strFormat) is string clipboardContentInternal8)
                  sbContent.Append(clipboardContentInternal8);
                DataGridViewColumn nextColumn;
                for (DataGridViewColumn objDataGridViewColumnStart = dataGridViewColumn1; objDataGridViewColumnStart != null; objDataGridViewColumnStart = nextColumn)
                {
                  nextColumn = objDataGridViewColumnStart == dataGridViewColumn2 ? (DataGridViewColumn) null : this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (rows.SharedRow(num3).Cells[objDataGridViewColumnStart.Index].GetClipboardContentInternal(num3, !flag5 && objDataGridViewColumnStart == dataGridViewColumn1, nextColumn == null, !flag4 & flag7, num4 == -1, strFormat) is string clipboardContentInternal9)
                    sbContent.Append(clipboardContentInternal9);
                }
              }
              num3 = num4;
              flag7 = false;
            }
            if (strFormat == DataFormats.Html)
              DataGridView.GetClipboardContentForHtml(sbContent);
            clipboardContentInternal1.SetData(strFormat, false, (object) sbContent.ToString());
          }
          return clipboardContentInternal1;
        case DataGridViewSelectionMode.FullRowSelect:
          if (rows.GetRowCount(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) == 0)
            return (DataObject) null;
          bool flag8;
          bool flag9;
          if (this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)
          {
            flag8 = rows.GetFirstRow(DataGridViewElementStates.Visible, DataGridViewElementStates.Selected) == -1;
            flag9 = true;
          }
          else
            flag8 = flag9 = this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
          bool flag10 = flag8 & this.ColumnHeadersVisible;
          bool flag11 = flag9 & this.RowHeadersVisible;
          foreach (string strFormat in arrText)
          {
            if (sbContent == null)
              sbContent = new StringBuilder(1024);
            else
              sbContent.Length = 0;
            if (flag10)
            {
              if (this.RightToLeftInternal)
              {
                DataGridViewColumn lastColumn = this.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                if (lastColumn != null)
                {
                  DataGridViewColumn previousColumn = this.Columns.GetPreviousColumn(lastColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (lastColumn.HeaderCell.GetClipboardContentInternal(-1, true, !flag11 && previousColumn == null, true, false, strFormat) is string clipboardContentInternal10)
                    sbContent.Append(clipboardContentInternal10);
                  while (previousColumn != null)
                  {
                    DataGridViewColumn objDataGridViewColumnStart = previousColumn;
                    previousColumn = this.Columns.GetPreviousColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    if (objDataGridViewColumnStart.HeaderCell.GetClipboardContentInternal(-1, false, !flag11 && previousColumn == null, true, false, strFormat) is string clipboardContentInternal11)
                      sbContent.Append(clipboardContentInternal11);
                  }
                }
                if (flag11 && this.TopLeftHeaderCell.GetClipboardContentInternal(-1, this.Columns.GetColumnCount(DataGridViewElementStates.Visible) == 0, true, true, false, strFormat) is string clipboardContentInternal12)
                  sbContent.Append(clipboardContentInternal12);
              }
              else
              {
                if (flag11 && this.TopLeftHeaderCell.GetClipboardContentInternal(-1, true, this.Columns.GetColumnCount(DataGridViewElementStates.Visible) == 0, true, false, strFormat) is string clipboardContentInternal13)
                  sbContent.Append(clipboardContentInternal13);
                DataGridViewColumn firstColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
                if (firstColumn != null)
                {
                  DataGridViewColumn nextColumn = this.Columns.GetNextColumn(firstColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (firstColumn.HeaderCell.GetClipboardContentInternal(-1, !flag11, nextColumn == null, true, false, strFormat) is string clipboardContentInternal14)
                    sbContent.Append(clipboardContentInternal14);
                  while (nextColumn != null)
                  {
                    DataGridViewColumn objDataGridViewColumnStart = nextColumn;
                    nextColumn = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    if (objDataGridViewColumnStart.HeaderCell.GetClipboardContentInternal(-1, false, nextColumn == null, true, false, strFormat) is string clipboardContentInternal15)
                      sbContent.Append(clipboardContentInternal15);
                  }
                }
              }
            }
            bool flag12 = true;
            int num5 = rows.GetFirstRow(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
            int nextRow = rows.GetNextRow(num5, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
            while (num5 != -1)
            {
              if (this.RightToLeftInternal)
              {
                DataGridViewColumn lastColumn = this.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                if (lastColumn != null)
                {
                  DataGridViewColumn previousColumn = this.Columns.GetPreviousColumn(lastColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (rows.SharedRow(num5).Cells[lastColumn.Index].GetClipboardContentInternal(num5, true, !flag11 && previousColumn == null, !flag10 & flag12, nextRow == -1, strFormat) is string clipboardContentInternal16)
                    sbContent.Append(clipboardContentInternal16);
                  while (previousColumn != null)
                  {
                    DataGridViewColumn objDataGridViewColumnStart = previousColumn;
                    previousColumn = this.Columns.GetPreviousColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    if (rows.SharedRow(num5).Cells[objDataGridViewColumnStart.Index].GetClipboardContentInternal(num5, false, !flag11 && previousColumn == null, !flag10 & flag12, nextRow == -1, strFormat) is string clipboardContentInternal17)
                      sbContent.Append(clipboardContentInternal17);
                  }
                }
                if (flag11 && rows.SharedRow(num5).HeaderCell.GetClipboardContentInternal(num5, this.Columns.GetColumnCount(DataGridViewElementStates.Visible) == 0, true, !flag10 & flag12, nextRow == -1, strFormat) is string clipboardContentInternal18)
                  sbContent.Append(clipboardContentInternal18);
              }
              else
              {
                DataGridViewColumn firstColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
                if (flag11 && rows.SharedRow(num5).HeaderCell.GetClipboardContentInternal(num5, true, firstColumn == null, !flag10 & flag12, nextRow == -1, strFormat) is string clipboardContentInternal19)
                  sbContent.Append(clipboardContentInternal19);
                if (firstColumn != null)
                {
                  DataGridViewColumn nextColumn = this.Columns.GetNextColumn(firstColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (rows.SharedRow(num5).Cells[firstColumn.Index].GetClipboardContentInternal(num5, !flag11, nextColumn == null, !flag10 & flag12, nextRow == -1, strFormat) is string clipboardContentInternal20)
                    sbContent.Append(clipboardContentInternal20);
                  while (nextColumn != null)
                  {
                    DataGridViewColumn objDataGridViewColumnStart = nextColumn;
                    nextColumn = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    if (rows.SharedRow(num5).Cells[objDataGridViewColumnStart.Index].GetClipboardContentInternal(num5, false, nextColumn == null, !flag10 & flag12, nextRow == -1, strFormat) is string clipboardContentInternal21)
                      sbContent.Append(clipboardContentInternal21);
                  }
                }
              }
              num5 = nextRow;
              if (num5 != -1)
                nextRow = rows.GetNextRow(num5, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
              flag12 = false;
            }
            if (strFormat == DataFormats.Html)
              DataGridView.GetClipboardContentForHtml(sbContent);
            clipboardContentInternal1.SetData(strFormat, false, (object) sbContent.ToString());
          }
          return clipboardContentInternal1;
        case DataGridViewSelectionMode.FullColumnSelect:
          if (this.Columns.GetColumnCount(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) == 0)
            return (DataObject) null;
          bool flag13;
          bool flag14;
          if (this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)
          {
            flag13 = true;
            flag14 = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.Selected) == null;
          }
          else
            flag13 = flag14 = this.ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
          bool flag15 = flag13 & this.ColumnHeadersVisible;
          bool flag16 = flag14 & this.RowHeadersVisible;
          int firstRow1 = rows.GetFirstRow(DataGridViewElementStates.Visible);
          foreach (string strFormat in arrText)
          {
            if (sbContent == null)
              sbContent = new StringBuilder(1024);
            else
              sbContent.Length = 0;
            if (flag15)
            {
              if (this.RightToLeftInternal)
              {
                DataGridViewColumn lastColumn = this.Columns.GetLastColumn(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                DataGridViewColumn objDataGridViewColumnStart1 = lastColumn;
                if (objDataGridViewColumnStart1 != null)
                {
                  DataGridViewColumn previousColumn = this.Columns.GetPreviousColumn(objDataGridViewColumnStart1, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (objDataGridViewColumnStart1.HeaderCell.GetClipboardContentInternal(-1, true, !flag16 && previousColumn == null, true, firstRow1 == -1, strFormat) is string clipboardContentInternal22)
                    sbContent.Append(clipboardContentInternal22);
                  while (previousColumn != null)
                  {
                    DataGridViewColumn objDataGridViewColumnStart2 = previousColumn;
                    previousColumn = this.Columns.GetPreviousColumn(objDataGridViewColumnStart2, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    if (objDataGridViewColumnStart2.HeaderCell.GetClipboardContentInternal(-1, false, !flag16 && previousColumn == null, true, firstRow1 == -1, strFormat) is string clipboardContentInternal23)
                      sbContent.Append(clipboardContentInternal23);
                  }
                }
                if (flag16 && this.TopLeftHeaderCell.GetClipboardContentInternal(-1, lastColumn == null, true, true, firstRow1 == -1, strFormat) is string clipboardContentInternal24)
                  sbContent.Append(clipboardContentInternal24);
              }
              else
              {
                DataGridViewColumn firstColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
                if (flag16 && this.TopLeftHeaderCell.GetClipboardContentInternal(-1, true, firstColumn == null, true, firstRow1 == -1, strFormat) is string clipboardContentInternal25)
                  sbContent.Append(clipboardContentInternal25);
                if (firstColumn != null)
                {
                  DataGridViewColumn nextColumn = this.Columns.GetNextColumn(firstColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (firstColumn.HeaderCell.GetClipboardContentInternal(-1, !flag16, nextColumn == null, true, firstRow1 == -1, strFormat) is string clipboardContentInternal26)
                    sbContent.Append(clipboardContentInternal26);
                  while (nextColumn != null)
                  {
                    DataGridViewColumn objDataGridViewColumnStart = nextColumn;
                    nextColumn = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    if (objDataGridViewColumnStart.HeaderCell.GetClipboardContentInternal(-1, false, nextColumn == null, true, firstRow1 == -1, strFormat) is string clipboardContentInternal27)
                      sbContent.Append(clipboardContentInternal27);
                  }
                }
              }
            }
            bool flag17 = true;
            int num6 = firstRow1;
            int num7 = -1;
            if (num6 != -1)
              num7 = rows.GetNextRow(num6, DataGridViewElementStates.Visible);
            while (num6 != -1)
            {
              if (this.RightToLeftInternal)
              {
                DataGridViewColumn lastColumn = this.Columns.GetLastColumn(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                DataGridViewColumn objDataGridViewColumnStart3 = lastColumn;
                if (objDataGridViewColumnStart3 != null)
                {
                  DataGridViewColumn previousColumn = this.Columns.GetPreviousColumn(objDataGridViewColumnStart3, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (rows.SharedRow(num6).Cells[objDataGridViewColumnStart3.Index].GetClipboardContentInternal(num6, true, !flag16 && previousColumn == null, !flag15 & flag17, num7 == -1, strFormat) is string clipboardContentInternal28)
                    sbContent.Append(clipboardContentInternal28);
                  while (previousColumn != null)
                  {
                    DataGridViewColumn objDataGridViewColumnStart4 = previousColumn;
                    previousColumn = this.Columns.GetPreviousColumn(objDataGridViewColumnStart4, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    if (rows.SharedRow(num6).Cells[objDataGridViewColumnStart4.Index].GetClipboardContentInternal(num6, false, !flag16 && previousColumn == null, !flag15 & flag17, num7 == -1, strFormat) is string clipboardContentInternal29)
                      sbContent.Append(clipboardContentInternal29);
                  }
                }
                if (flag16 && rows.SharedRow(num6).HeaderCell.GetClipboardContentInternal(num6, lastColumn == null, true, !flag15 & flag17, num7 == -1, strFormat) is string clipboardContentInternal30)
                  sbContent.Append(clipboardContentInternal30);
              }
              else
              {
                DataGridViewColumn firstColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
                if (flag16 && rows.SharedRow(num6).HeaderCell.GetClipboardContentInternal(num6, true, firstColumn == null, !flag15 & flag17, num7 == -1, strFormat) is string clipboardContentInternal31)
                  sbContent.Append(clipboardContentInternal31);
                if (firstColumn != null)
                {
                  DataGridViewColumn nextColumn = this.Columns.GetNextColumn(firstColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                  if (rows.SharedRow(num6).Cells[firstColumn.Index].GetClipboardContentInternal(num6, !flag16, nextColumn == null, !flag15 & flag17, num7 == -1, strFormat) is string clipboardContentInternal32)
                    sbContent.Append(clipboardContentInternal32);
                  while (nextColumn != null)
                  {
                    DataGridViewColumn objDataGridViewColumnStart = nextColumn;
                    nextColumn = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    if (rows.SharedRow(num6).Cells[objDataGridViewColumnStart.Index].GetClipboardContentInternal(num6, false, nextColumn == null, !flag15 & flag17, num7 == -1, strFormat) is string clipboardContentInternal33)
                      sbContent.Append(clipboardContentInternal33);
                  }
                }
              }
              num6 = num7;
              if (num6 != -1)
                num7 = rows.GetNextRow(num6, DataGridViewElementStates.Visible);
              flag17 = false;
            }
            if (strFormat == DataFormats.Html)
              DataGridView.GetClipboardContentForHtml(sbContent);
            clipboardContentInternal1.SetData(strFormat, false, (object) sbContent.ToString());
          }
          return clipboardContentInternal1;
        default:
          return clipboardContentInternal1;
      }
    }

    private static void GetClipboardContentForHtml(StringBuilder sbContent)
    {
      int num = 135 + sbContent.Length;
      string str = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Version:1.0\r\nStartHTML:00000097\r\nEndHTML:{0}\r\nStartFragment:00000133\r\nEndFragment:{1}\r\n", (object) (num + 36).ToString("00000000", (IFormatProvider) CultureInfo.InvariantCulture), (object) num.ToString("00000000", (IFormatProvider) CultureInfo.InvariantCulture)) + "<HTML>\r\n<BODY>\r\n<!--StartFragment-->";
      sbContent.Insert(0, str);
      sbContent.Append("\r\n<!--EndFragment-->\r\n</BODY>\r\n</HTML>");
    }

    /// <summary>Notifies the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that the current cell has uncommitted changes.</summary>
    /// <param name="blnDirty">true to indicate the cell has uncommitted changes; otherwise, false. </param>
    /// <filterpriority>1</filterpriority>
    public virtual void NotifyCurrentCellDirty(bool blnDirty) => this.NotifyCurrentCellDirty(blnDirty, false);

    /// <summary>Notifies the current cell dirty.</summary>
    /// <param name="blnDirty">if set to <c>true</c> [BLN dirty].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    internal void NotifyCurrentCellDirty(bool blnDirty, bool blnClientSource)
    {
      if (this.mobjDataGridViewState1[512])
        return;
      this.SetIsCurrentCellDirtyInternal(blnDirty, blnClientSource);
    }

    /// <summary>Invalidates the specified cell of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, forcing it to be repainted.</summary>
    /// <param name="objDataGridViewCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to invalidate. </param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewCell is null.</exception>
    /// <exception cref="T:System.ArgumentException">dataGridViewCell does not belong to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    public void InvalidateCell(DataGridViewCell objDataGridViewCell) => objDataGridViewCell?.Update();

    /// <summary>Invalidates the cell with the specified row and column indexes, forcing it to be repainted.</summary>
    /// <param name="intColumnIndex">The column index of the cell to invalidate.</param>
    /// <param name="intRowIndex">The row index of the cell to invalidate. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1 or greater than the number of columns in the control minus 1.-or-rowIndex is less than -1 or greater than the number of rows in the control minus 1. </exception>
    /// <filterpriority>1</filterpriority>
    public void InvalidateCell(int intColumnIndex, int intRowIndex)
    {
      if (intColumnIndex < -1 || intColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("columnIndex");
      if (intRowIndex < -1 || intRowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      this.InvalidateCellPrivate(intColumnIndex, intRowIndex);
    }

    /// <summary>Invalidates the specified column of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, forcing it to be repainted.</summary>
    /// <param name="intColumnIndex">The index of the column to invalidate. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
    /// <filterpriority>1</filterpriority>
    public void InvalidateColumn(int intColumnIndex)
    {
    }

    /// <summary>Invalidates the specified row of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, forcing it to be repainted.</summary>
    /// <param name="intRowIndex">The index of the row to invalidate. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1. </exception>
    /// <filterpriority>1</filterpriority>
    public void InvalidateRow(int intRowIndex)
    {
    }

    private void InvalidateRowHeights()
    {
      this.Rows.InvalidateCachedRowsHeights();
      if (!this.IsHandleCreated)
        return;
      this.PerformLayoutPrivate(false);
      this.Invalidate();
    }

    /// <summary>Performs the layout private.</summary>
    /// <param name="blnInvalidInAdjustFillingColumns">if set to <c>true</c> [invalid in adjust filling columns].</param>
    private void PerformLayoutPrivate(bool blnInvalidInAdjustFillingColumns)
    {
      ++this.minPerformLayoutCount;
      try
      {
        if (blnInvalidInAdjustFillingColumns && this.InAdjustFillingColumns)
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterAutoFillColumnParameter"));
        if (this.IsHandleCreated)
        {
          if (!this.ComputeLayout() || this.minPerformLayoutCount >= 3)
            return;
          if ((this.AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) != DataGridViewAutoSizeRowsMode.None)
            this.AdjustShrinkingRows(this.AutoSizeRowsMode, true, true);
          if (this.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize)
            return;
          this.AutoResizeColumnHeadersHeight(true, true);
        }
        else
        {
          this.DisplayedBandsInfo.FirstDisplayedFrozenCol = -1;
          this.DisplayedBandsInfo.FirstDisplayedFrozenRow = -1;
          this.DisplayedBandsInfo.FirstDisplayedScrollingRow = -1;
          this.DisplayedBandsInfo.FirstDisplayedScrollingCol = -1;
          this.DisplayedBandsInfo.NumDisplayedFrozenRows = 0;
          this.DisplayedBandsInfo.NumDisplayedFrozenCols = 0;
          this.DisplayedBandsInfo.NumDisplayedScrollingRows = 0;
          this.DisplayedBandsInfo.NumDisplayedScrollingCols = 0;
          this.DisplayedBandsInfo.NumTotallyDisplayedFrozenRows = 0;
          this.DisplayedBandsInfo.NumTotallyDisplayedScrollingRows = 0;
          this.DisplayedBandsInfo.LastDisplayedScrollingRow = -1;
          this.DisplayedBandsInfo.LastTotallyDisplayedScrollingCol = -1;
          if (this.LayoutInfo == null)
            return;
          this.LayoutInfo.dirty = true;
        }
      }
      finally
      {
        --this.minPerformLayoutCount;
      }
    }

    /// <summary>Computes the layout.</summary>
    /// <returns></returns>
    private bool ComputeLayout()
    {
      DataGridView.LayoutData layoutData = new DataGridView.LayoutData(this.mobjLayoutInfo);
      Rectangle resizeBoxRect = this.mobjLayoutInfo.ResizeBoxRect;
      if (this is HierarchicDataGridView hierarchicDataGridView)
      {
        DataGridView dataGridView = hierarchicDataGridView.ContainingRow.DataGridView;
        if (dataGridView != null)
        {
          int width = 0;
          this.VisualTemplate = dataGridView.VisualTemplate;
          if (dataGridView.ExpansionIndicator != ShowExpansionIndicator.Never && dataGridView.Skin is DataGridViewSkin skin)
            width = skin.ExpandCollapseColumnWidth;
          for (DataGridViewColumn objDataGridViewColumnStart = dataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = dataGridView.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
            width += objDataGridViewColumnStart.Width;
          layoutData.Inside = new Rectangle(0, 0, width, this.Height);
        }
      }
      else
        layoutData.Inside = this.mobjLayoutInfo.ClientRectangle.Width > 0 || this.mobjLayoutInfo.ClientRectangle.Height > 0 ? this.mobjLayoutInfo.ClientRectangle : this.ClientRectangle;
      Rectangle inside = layoutData.Inside;
      int borderWidth = (int) this.BorderWidth;
      inside.Inflate(-borderWidth, -borderWidth);
      if (inside.Height < 0)
        inside.Height = 0;
      if (inside.Width < 0)
        inside.Width = 0;
      Rectangle rectangle1 = inside;
      if (this.mobjLayoutInfo.ColumnHeadersVisible)
      {
        Rectangle rectangle2 = rectangle1;
        rectangle2.Height = Math.Min(this.mintColumnHeadersHeight, rectangle2.Height);
        rectangle1.Y += rectangle2.Height;
        rectangle1.Height -= rectangle2.Height;
        layoutData.ColumnHeaders = rectangle2;
      }
      else
        layoutData.ColumnHeaders = Rectangle.Empty;
      if (this.RowHeadersVisible)
      {
        Rectangle rectangle3 = rectangle1;
        rectangle3.Width = Math.Min(this.mintRowHeadersWidth, rectangle3.Width);
        if (this.RightToLeftInternal)
          rectangle3.X += rectangle1.Width - rectangle3.Width;
        else
          rectangle1.X += rectangle3.Width;
        rectangle1.Width -= rectangle3.Width;
        layoutData.RowHeaders = rectangle3;
        if (this.mobjLayoutInfo.ColumnHeadersVisible)
        {
          Rectangle columnHeaders = layoutData.ColumnHeaders;
          Rectangle rectangle4 = columnHeaders;
          rectangle4.Width = Math.Min(this.mintRowHeadersWidth, rectangle4.Width);
          columnHeaders.Width -= rectangle4.Width;
          if (this.RightToLeftInternal)
            rectangle4.X += rectangle1.Width;
          else
            columnHeaders.X += rectangle4.Width;
          layoutData.TopLeftHeader = rectangle4;
          layoutData.ColumnHeaders = columnHeaders;
        }
        else
          layoutData.TopLeftHeader = Rectangle.Empty;
      }
      else
      {
        layoutData.RowHeaders = Rectangle.Empty;
        layoutData.TopLeftHeader = Rectangle.Empty;
      }
      if (this.SingleVerticalBorderAdded)
      {
        if (!this.RightToLeftInternal)
          ++rectangle1.X;
        if (rectangle1.Width > 0)
          --rectangle1.Width;
      }
      if (this.SingleHorizontalBorderAdded)
      {
        ++rectangle1.Y;
        if (rectangle1.Height > 0)
          --rectangle1.Height;
      }
      layoutData.Data = rectangle1;
      layoutData.Inside = inside;
      this.mobjLayoutInfo = layoutData;
      this.mobjLayoutInfo.dirty = false;
      int num = this.AdjustFillingColumns() ? 1 : 0;
      this.mobjLayoutInfo = layoutData;
      return num != 0;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRowsChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnAllowUserToAddRowsChanged(EventArgs e)
    {
      this.PushAllowUserToAddRows();
      EventHandler toAddRowsChanged = this.AllowUserToAddRowsChanged;
      if (toAddRowsChanged == null)
        return;
      toAddRowsChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToDeleteRowsChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnAllowUserToDeleteRowsChanged(EventArgs e)
    {
      EventHandler deleteRowsChanged = this.AllowUserToDeleteRowsChanged;
      if (deleteRowsChanged == null)
        return;
      deleteRowsChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToOrderColumnsChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnAllowUserToOrderColumnsChanged(EventArgs e)
    {
      EventHandler orderColumnsChanged = this.AllowUserToOrderColumnsChanged;
      if (orderColumnsChanged == null)
        return;
      orderColumnsChanged((object) this, e);
    }

    internal void OnAutoSizeColumnModeChanged(
      DataGridViewColumn objDataGridViewColumn,
      DataGridViewAutoSizeColumnMode enmPreviousInheritedMode)
    {
      this.OnAutoSizeColumnModeChanged(new DataGridViewAutoSizeColumnModeEventArgs(objDataGridViewColumn, enmPreviousInheritedMode));
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeColumnsChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnAllowUserToResizeColumnsChanged(EventArgs e)
    {
      EventHandler resizeColumnsChanged = this.AllowUserToResizeColumnsChanged;
      if (resizeColumnsChanged == null)
        return;
      resizeColumnsChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRowsChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnAllowUserToResizeRowsChanged(EventArgs e)
    {
      EventHandler resizeRowsChanged = this.AllowUserToResizeRowsChanged;
      if (resizeRowsChanged == null)
        return;
      resizeRowsChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AlternatingRowsDefaultCellStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnAlternatingRowsDefaultCellStyleChanged(EventArgs e)
    {
      EventHandler cellStyleChanged = this.AlternatingRowsDefaultCellStyleChanged;
      if (cellStyleChanged == null)
        return;
      cellStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoGenerateColumnsChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnAutoGenerateColumnsChanged(EventArgs e)
    {
      if (this.AutoGenerateColumns && this.DataSource != null)
        this.RefreshColumnsAndRows();
      EventHandler generateColumnsChanged = this.AutoGenerateColumnsChanged;
      if (generateColumnsChanged == null)
        return;
      generateColumnsChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnModeChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs.Column"></see> property of e is null.</exception>
    protected virtual void OnAutoSizeColumnModeChanged(DataGridViewAutoSizeColumnModeEventArgs e)
    {
      DataGridViewColumn column = e.Column;
      if (e.Column == null)
        throw new InvalidOperationException(SR.GetString("InvalidNullArgument", (object) "e.Column"));
      DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = column.InheritedAutoSizeMode;
      DataGridViewAutoSizeColumnMode previousMode = e.PreviousMode;
      int num;
      switch (previousMode)
      {
        case DataGridViewAutoSizeColumnMode.None:
        case DataGridViewAutoSizeColumnMode.Fill:
          num = 0;
          break;
        default:
          num = previousMode != 0 ? 1 : 0;
          break;
      }
      bool flag = num != 0;
      if (inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || previousMode == DataGridViewAutoSizeColumnMode.Fill)
        this.mobjDataGridViewState2[67108864] = true;
      bool blnFixedHeight = (this.AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) == DataGridViewAutoSizeRowsMode.None;
      switch (inheritedAutoSizeMode)
      {
        case DataGridViewAutoSizeColumnMode.None:
          if (column.Thickness != column.CachedThickness & flag)
          {
            column.ThicknessInternal = Math.Max(column.MinimumWidth, column.CachedThickness);
            goto case DataGridViewAutoSizeColumnMode.Fill;
          }
          else
            goto case DataGridViewAutoSizeColumnMode.Fill;
        case DataGridViewAutoSizeColumnMode.Fill:
          this.PerformLayoutPrivate(true);
          if (!blnFixedHeight)
          {
            this.AdjustShrinkingRows(this.AutoSizeRowsMode, true, true);
            if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
              this.AutoResizeColumnHeadersHeight(column.Index, true, true);
            if (inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.None && inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
              this.AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal) inheritedAutoSizeMode, true);
          }
          DataGridViewAutoSizeColumnModeEventHandler columnModeChanged = this.AutoSizeColumnModeChanged;
          if (columnModeChanged == null)
            break;
          columnModeChanged((object) this, e);
          break;
        default:
          if (!flag)
          {
            DataGridViewColumn dataGridViewColumn = column;
            dataGridViewColumn.CachedThickness = dataGridViewColumn.Thickness;
          }
          this.AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal) inheritedAutoSizeMode, blnFixedHeight);
          goto case DataGridViewAutoSizeColumnMode.Fill;
      }
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsModeChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The number of entries in the array returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs.PreviousModes"></see> property of e is not equal to the number of columns in the control.</exception>
    /// <exception cref="T:System.ArgumentNullException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs.PreviousModes"></see> property of e is null.</exception>
    protected virtual void OnAutoSizeColumnsModeChanged(DataGridViewAutoSizeColumnsModeEventArgs e)
    {
      DataGridViewAutoSizeColumnMode[] previousModes = e.PreviousModes;
      if (previousModes == null)
        throw new ArgumentNullException("e.PreviousModes");
      if (previousModes.Length != this.Columns.Count)
        throw new ArgumentException(SR.GetString("DataGridView_PreviousModesHasWrongLength"));
      DataGridViewAutoSizeRowsMode autoSizeRowsMode = this.AutoSizeRowsMode;
      foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
      {
        if (column.Visible)
        {
          DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = column.InheritedAutoSizeMode;
          DataGridViewAutoSizeColumnMode autoSizeColumnMode = previousModes[column.Index];
          int num;
          switch (autoSizeColumnMode)
          {
            case DataGridViewAutoSizeColumnMode.None:
            case DataGridViewAutoSizeColumnMode.Fill:
              num = 0;
              break;
            default:
              num = autoSizeColumnMode != 0 ? 1 : 0;
              break;
          }
          bool flag = num != 0;
          if (inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || autoSizeColumnMode == DataGridViewAutoSizeColumnMode.Fill)
            this.mobjDataGridViewState2[67108864] = true;
          switch (inheritedAutoSizeMode)
          {
            case DataGridViewAutoSizeColumnMode.None:
              if (column.Thickness != column.CachedThickness & flag)
              {
                column.ThicknessInternal = Math.Max(column.MinimumWidth, column.CachedThickness);
                continue;
              }
              continue;
            case DataGridViewAutoSizeColumnMode.Fill:
              continue;
            default:
              if (!flag)
              {
                DataGridViewColumn dataGridViewColumn = column;
                dataGridViewColumn.CachedThickness = dataGridViewColumn.Thickness;
              }
              this.AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal) inheritedAutoSizeMode, (autoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) == DataGridViewAutoSizeRowsMode.None);
              continue;
          }
        }
      }
      this.PerformLayoutPrivate(true);
      if ((autoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) != DataGridViewAutoSizeRowsMode.None)
      {
        this.AdjustShrinkingRows(autoSizeRowsMode, true, true);
        if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
          this.AutoResizeColumnHeadersHeight(true, true);
        foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
        {
          DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = column.InheritedAutoSizeMode;
          switch (inheritedAutoSizeMode)
          {
            case DataGridViewAutoSizeColumnMode.None:
            case DataGridViewAutoSizeColumnMode.Fill:
              continue;
            default:
              this.AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal) inheritedAutoSizeMode, true);
              continue;
          }
        }
      }
      DataGridViewAutoSizeColumnsModeEventHandler columnsModeChanged = this.AutoSizeColumnsModeChanged;
      if (columnsModeChanged != null && !this.mobjDataGridViewOper[1048576] && !this.IsDisposed)
        columnsModeChanged((object) this, e);
      this.Update();
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsModeChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> that contains the event data. </param>
    protected virtual void OnAutoSizeRowsModeChanged(DataGridViewAutoSizeModeEventArgs e)
    {
      DataGridViewAutoSizeModeEventHandler sizeRowsModeChanged = this.AutoSizeRowsModeChanged;
      if (sizeRowsModeChanged == null)
        return;
      sizeRowsModeChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.BackgroundColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnBackgroundColorChanged(EventArgs e)
    {
      EventHandler backgroundColorChanged = this.BackgroundColorChanged;
      if (backgroundColorChanged == null)
        return;
      backgroundColorChanged((object) this, e);
    }

    internal string OnCellToolTipTextNeeded(
      int intColumnIndex,
      int intRowIndex,
      string strToolTipText)
    {
      DataGridViewCellToolTipTextNeededEventArgs e = new DataGridViewCellToolTipTextNeededEventArgs(intColumnIndex, intRowIndex, strToolTipText);
      this.OnCellToolTipTextNeeded(e);
      return e.ToolTipText;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BindingContextChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected override void OnBindingContextChanged(EventArgs e)
    {
      if (this.mobjDataGridViewState2[16777216])
        return;
      this.mobjDataGridViewState2[16777216] = true;
      try
      {
        if (this.DataConnection != null)
        {
          this.CurrentCell = (DataGridViewCell) null;
          try
          {
            this.DataConnection.SetDataConnection(this.DataSource, this.DataMember);
          }
          catch (ArgumentException ex)
          {
            if (this.DesignMode)
            {
              this.DataMember = string.Empty;
              this.RefreshColumnsAndRows();
              return;
            }
            throw;
          }
          this.RefreshColumnsAndRows();
          base.OnBindingContextChanged(e);
          if (this.DataConnection.CurrencyManager == null)
            return;
          this.OnDataBindingComplete(ListChangedType.Reset);
        }
        else
          base.OnBindingContextChanged(e);
      }
      finally
      {
        this.mobjDataGridViewState2[16777216] = false;
      }
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.BorderStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnBorderStyleChanged(EventArgs e)
    {
      EventHandler borderStyleChanged = this.BorderStyleChanged;
      if (borderStyleChanged == null)
        return;
      borderStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CancelRowEdit"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.QuestionEventArgs"></see> that contains the event data. </param>
    protected virtual void OnCancelRowEdit(QuestionEventArgs e)
    {
      QuestionEventHandler cancelRowEdit = this.CancelRowEdit;
      if (cancelRowEdit == null)
        return;
      cancelRowEdit((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellBeginEdit"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected internal virtual void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLBEGINEDIT) is DataGridViewCellCancelEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellEndEdit"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected internal virtual void OnCellEndEdit(DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLENDEDIT) is DataGridViewCellEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellBorderStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnCellBorderStyleChanged(EventArgs e)
    {
      EventHandler borderStyleChanged = this.CellBorderStyleChanged;
      if (borderStyleChanged == null)
        return;
      borderStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellErrorTextChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is less than -1 or greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is less than -1 or greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellErrorTextChanged(DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      this.UpdateCellErrorText(e.ColumnIndex, e.RowIndex);
      DataGridViewCellEventHandler errorTextChanged = this.CellErrorTextChanged;
      if (errorTextChanged == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      errorTextChanged((object) this, e);
    }

    internal void OnCellErrorTextChanged(DataGridViewCell objDataGridViewCell) => this.OnCellErrorTextChanged(new DataGridViewCellEventArgs(objDataGridViewCell));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellErrorTextNeeded"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellErrorTextNeededEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellErrorTextNeededEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellErrorTextNeededEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellErrorTextNeeded(DataGridViewCellErrorTextNeededEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      DataGridViewCellErrorTextNeededEventHandler cellErrorTextNeeded = this.CellErrorTextNeeded;
      if (cellErrorTextNeeded == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      cellErrorTextNeeded((object) this, e);
    }

    internal string OnCellErrorTextNeeded(int intColumnIndex, int intRowIndex, string strErrorText)
    {
      DataGridViewCellErrorTextNeededEventArgs e = new DataGridViewCellErrorTextNeededEventArgs(intColumnIndex, intRowIndex, strErrorText);
      this.OnCellErrorTextNeeded(e);
      return e.ErrorText;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellFormatting"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      DataGridViewCellFormattingEventHandler cellFormatting = this.CellFormatting;
      if (cellFormatting == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      cellFormatting((object) this, e);
    }

    internal virtual DataGridViewCellFormattingEventArgs OnCellFormatting(
      int intColumnIndex,
      int intRowIndex,
      object objValue,
      Type objFormattedValueType,
      DataGridViewCellStyle objCellStyle)
    {
      DataGridViewCellFormattingEventArgs e = new DataGridViewCellFormattingEventArgs(intColumnIndex, intRowIndex, objValue, objFormattedValueType, objCellStyle);
      this.OnCellFormatting(e);
      return e;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellParsing"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    internal virtual void OnCellParsing(DataGridViewCellParsingEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      DataGridViewCellParsingEventHandler cellParsing = this.CellParsing;
      if (cellParsing == null)
        return;
      cellParsing((object) this, e);
    }

    /// <summary>Called when [cell parsing].</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="objFormattedValue">The formatted value.</param>
    /// <param name="objValueType">Type of the value.</param>
    /// <param name="objCellStyle">The cell style.</param>
    /// <returns></returns>
    internal DataGridViewCellParsingEventArgs OnCellParsing(
      int intRowIndex,
      int intColumnIndex,
      object objFormattedValue,
      Type objValueType,
      DataGridViewCellStyle objCellStyle)
    {
      DataGridViewCellParsingEventArgs e = new DataGridViewCellParsingEventArgs(intRowIndex, intColumnIndex, objFormattedValue, objValueType, objCellStyle);
      this.OnCellParsing(e);
      return e;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStateChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStateChangedEventArgs"></see> that contains the event data. </param>
    protected virtual void OnCellStateChanged(DataGridViewCellStateChangedEventArgs e)
    {
      DataGridViewCell cell = e.Cell;
      if (e.StateChanged == DataGridViewElementStates.Selected && this.BulkPaintCount == 0 && (cell.ClientState | DataGridViewElementClientStates.Selected) != DataGridViewElementClientStates.Selected)
        this.InvalidateCellPrivate(cell);
      DataGridViewCellStateChangedEventHandler cellStateChanged = this.CellStateChanged;
      if (cellStateChanged != null && !this.mobjDataGridViewOper[1048576] && !this.IsDisposed)
        cellStateChanged((object) this, e);
      if (e.StateChanged != DataGridViewElementStates.ReadOnly || this.mobjCurrentCellPoint.X != cell.ColumnIndex || this.mobjCurrentCellPoint.Y != cell.RowIndex || cell.RowIndex <= -1 || this.mobjDataGridViewOper[16384] || cell.ReadOnly || !this.ColumnEditable(this.mobjCurrentCellPoint.X) || this.IsCurrentCellInEditMode || this.EditMode != DataGridViewEditMode.EditOnEnter && (this.EditMode == DataGridViewEditMode.EditProgrammatically || !(this.CurrentCellInternal.EditType == (Type) null)))
        return;
      this.BeginEditInternal(true);
    }

    private void CorrectRowFrozenStates(
      DataGridViewRow objDataGridViewRow,
      int intRowIndex,
      bool blnFrozenStateChanging)
    {
      DataGridViewRowCollection rows = this.Rows;
      if ((rows.GetRowState(intRowIndex) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None && !blnFrozenStateChanging || (rows.GetRowState(intRowIndex) & DataGridViewElementStates.Frozen) == DataGridViewElementStates.None & blnFrozenStateChanging)
      {
        int num = rows.GetPreviousRow(intRowIndex, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
        if (num == -1)
        {
          int firstRow = rows.GetFirstRow(DataGridViewElementStates.Visible);
          if (firstRow != intRowIndex)
            num = firstRow;
        }
        for (; num != -1 && num < intRowIndex; num = rows.GetNextRow(num, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen))
          rows.SetRowState(num, DataGridViewElementStates.Frozen, true);
      }
      else
      {
        int num = rows.GetNextRow(intRowIndex, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
        if (num == -1)
        {
          int indexStart = intRowIndex;
          do
          {
            num = rows.GetNextRow(indexStart, DataGridViewElementStates.Visible);
            if (num != -1)
              indexStart = num;
          }
          while (num != -1);
          if (indexStart != intRowIndex)
            num = indexStart;
        }
        for (; num != -1 && num > intRowIndex; num = rows.GetPreviousRow(num, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible))
          rows.SetRowState(num, DataGridViewElementStates.Frozen, false);
      }
    }

    private void CorrectColumnFrozenStates(
      DataGridViewColumn objDataGridViewColumn,
      bool blnFrozenStateChanging)
    {
      if (!objDataGridViewColumn.Frozen | blnFrozenStateChanging && (objDataGridViewColumn.Frozen || !blnFrozenStateChanging))
      {
        DataGridViewColumn objDataGridViewColumnStart1 = this.Columns.GetNextColumn(objDataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
        if (objDataGridViewColumnStart1 == null)
        {
          DataGridViewColumn objDataGridViewColumnStart2 = objDataGridViewColumn;
          do
          {
            objDataGridViewColumnStart1 = this.Columns.GetNextColumn(objDataGridViewColumnStart2, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
            if (objDataGridViewColumnStart1 != null)
              objDataGridViewColumnStart2 = objDataGridViewColumnStart1;
          }
          while (objDataGridViewColumnStart1 != null);
          if (objDataGridViewColumnStart2 != objDataGridViewColumn)
            objDataGridViewColumnStart1 = objDataGridViewColumnStart2;
        }
        for (; objDataGridViewColumnStart1 != null && this.Columns.DisplayInOrder(objDataGridViewColumn.Index, objDataGridViewColumnStart1.Index); objDataGridViewColumnStart1 = this.Columns.GetPreviousColumn(objDataGridViewColumnStart1, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible, DataGridViewElementStates.None))
          objDataGridViewColumnStart1.Frozen = false;
      }
      else
      {
        DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetPreviousColumn(objDataGridViewColumn, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
        if (objDataGridViewColumnStart == null)
        {
          DataGridViewColumn firstColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
          if (firstColumn != objDataGridViewColumn)
            objDataGridViewColumnStart = firstColumn;
        }
        for (; objDataGridViewColumnStart != null && this.Columns.DisplayInOrder(objDataGridViewColumnStart.Index, objDataGridViewColumn.Index); objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen))
          objDataGridViewColumnStart.Frozen = true;
      }
    }

    internal void OnDataGridViewElementStateChanging(
      DataGridViewElement objElement,
      int index,
      DataGridViewElementStates elementState)
    {
      switch (objElement)
      {
        case DataGridViewColumn objDataGridViewColumn:
          switch (elementState)
          {
            case DataGridViewElementStates.Frozen:
            case DataGridViewElementStates.Visible:
              if (elementState == DataGridViewElementStates.Visible)
              {
                if (!objDataGridViewColumn.Visible && objDataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader && !this.ColumnHeadersVisible)
                  throw new InvalidOperationException("DataGridView_CannotMakeAutoSizedColumnVisible");
                if (!objDataGridViewColumn.Visible && objDataGridViewColumn.Frozen && objDataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
                  objDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                else if (objDataGridViewColumn.Visible && this.mobjCurrentCellPoint.X == objDataGridViewColumn.Index)
                  this.ResetCurrentCell();
              }
              if (elementState == DataGridViewElementStates.Frozen && !objDataGridViewColumn.Frozen && objDataGridViewColumn.Visible && objDataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
                objDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
              this.CorrectColumnFrozenStates(objDataGridViewColumn, elementState == DataGridViewElementStates.Frozen);
              return;
            case DataGridViewElementStates.ReadOnly:
              if (this.mobjCurrentCellPoint.X != objDataGridViewColumn.Index || !this.IsCurrentCellInEditMode || objDataGridViewColumn.ReadOnly || this.mobjDataGridViewOper[16384] || this.EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing, DataGridView.DataGridViewValidateCellInternal.Always, false, false, false, false, false, true, false, false))
                return;
              throw new InvalidOperationException("DataGridView_CommitFailedCannotCompleteOperation");
            default:
              return;
          }
        case DataGridViewRow objDataGridViewRow:
          int intRowIndex = objDataGridViewRow.Index > -1 ? objDataGridViewRow.Index : index;
          switch (elementState)
          {
            case DataGridViewElementStates.Frozen:
            case DataGridViewElementStates.Visible:
              if (elementState == DataGridViewElementStates.Visible && this.mobjCurrentCellPoint.Y == intRowIndex)
              {
                if (this.DataSource != null && this.GroupingColumns.Count == 0)
                  throw new InvalidOperationException("DataGridView_CurrencyManagerRowCannotBeInvisible");
                this.ResetCurrentCell();
              }
              this.CorrectRowFrozenStates(objDataGridViewRow, intRowIndex, elementState == DataGridViewElementStates.Frozen);
              return;
            case DataGridViewElementStates.ReadOnly:
              if (this.mobjCurrentCellPoint.Y != intRowIndex || (this.Rows.GetRowState(intRowIndex) & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || this.ReadOnly || !this.IsCurrentCellInEditMode || this.mobjDataGridViewOper[16384] || this.EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing, DataGridView.DataGridViewValidateCellInternal.Always, false, false, false, false, false, true, false, false))
                return;
              throw new InvalidOperationException("DataGridView_CommitFailedCannotCompleteOperation");
            default:
              return;
          }
        case DataGridViewCell dataGridViewCell:
          if (elementState != DataGridViewElementStates.ReadOnly || this.mobjCurrentCellPoint.X != dataGridViewCell.ColumnIndex || this.mobjCurrentCellPoint.Y != dataGridViewCell.RowIndex || !this.IsCurrentCellInEditMode || dataGridViewCell.ReadOnly || this.mobjDataGridViewOper[16384] || this.EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing, DataGridView.DataGridViewValidateCellInternal.Always, false, false, false, false, false, true, false, false))
            break;
          throw new InvalidOperationException("DataGridView_CommitFailedCannotCompleteOperation");
      }
    }

    internal void OnDataGridViewElementStateChanged(
      DataGridViewElement objElement,
      int index,
      DataGridViewElementStates elementState)
    {
      switch (objElement)
      {
        case DataGridViewColumn objDataGridViewColumn:
          this.OnColumnStateChanged(new DataGridViewColumnStateChangedEventArgs(objDataGridViewColumn, elementState));
          break;
        case DataGridViewRow row:
          if (this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWROWSTATECHANGED) is DataGridViewRowStateChangedEventHandler && row.DataGridView != null && row.Index == -1)
            row = this.Rows[index];
          DataGridViewRowStateChangedEventArgs e = new DataGridViewRowStateChangedEventArgs(row, elementState);
          this.OnRowStateChanged(row.Index == -1 ? index : row.Index, e);
          break;
        case DataGridViewCell objDataGridViewCell:
          this.OnCellStateChanged(new DataGridViewCellStateChangedEventArgs(objDataGridViewCell, elementState));
          break;
      }
      if ((elementState & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected)
        return;
      if (this.SelectionChangeCount > 0)
        this.mobjDataGridViewState2[262144] = true;
      else
        this.OnSelectionChanged(EventArgs.Empty);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStyleChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellStyleChanged(DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      DataGridViewCellEventHandler cellStyleChanged = this.CellStyleChanged;
      if (cellStyleChanged == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      cellStyleChanged((object) this, e);
    }

    internal void OnCellStyleChanged(DataGridViewCell objDataGridViewCell) => this.OnCellStyleChanged(new DataGridViewCellEventArgs(objDataGridViewCell));

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.RowHeaderMouseClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was clicked.</param>
    internal void OnRowHeaderMouseClickInternal(DataGridViewCellMouseEventArgs e) => this.OnRowHeaderMouseClick(e);

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.RowHeaderMouseClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was clicked.</param>
    internal void OnCellEnterInternal(DataGridViewCellEventArgs e) => this.OnCellEnter(e);

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.RowHeaderMouseClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was clicked.</param>
    internal void OnRowHeaderMouseDoubleClickInternal(DataGridViewCellMouseEventArgs e) => this.OnRowHeaderMouseDoubleClick(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStyleContentChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyleContentChangedEventArgs"></see> that contains the event data. </param>
    protected virtual void OnCellStyleContentChanged(DataGridViewCellStyleContentChangedEventArgs e)
    {
      if ((e.CellStyleScope & DataGridViewCellStyleScopes.Cell) == DataGridViewCellStyleScopes.Cell && (e.CellStyleScope & DataGridViewCellStyleScopes.DataGridView) == DataGridViewCellStyleScopes.None && e.ChangeAffectsPreferredSize)
        this.OnGlobalAutoSize();
      this.Invalidate();
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellToolTipTextChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains information about the cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellToolTipTextChanged(DataGridViewCellEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellToolTipTextNeeded"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellToolTipTextNeededEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellToolTipTextNeededEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellToolTipTextNeededEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellToolTipTextNeeded(DataGridViewCellToolTipTextNeededEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      DataGridViewCellToolTipTextNeededEventHandler toolTipTextNeeded = this.CellToolTipTextNeeded;
      if (toolTipTextNeeded == null)
        return;
      toolTipTextNeeded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    internal virtual void OnCellValidated(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler cellValidated = this.CellValidated;
      if (cellValidated == null)
        return;
      cellValidated((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    internal virtual void OnCellValidating(DataGridViewCellValidatingEventArgs e)
    {
      DataGridViewCellValidatingEventHandler cellValidating = this.CellValidating;
      if (cellValidating == null)
        return;
      cellValidating((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueChanged"></see> event.
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellValueChanged(DataGridViewCellEventArgs e, bool blnClientSource)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      this.OnCellCommonChange(e.ColumnIndex, e.RowIndex, blnClientSource);
      if (this.IsHierarchic(HierarchicInfoSelector.Bounded))
        this.HandleHierarchicValueChanged(e.ColumnIndex, e.RowIndex);
      DataGridViewCellEventHandler cellValueChanged = this.CellValueChanged;
      if (cellValueChanged != null && !this.mobjDataGridViewOper[1048576] && !this.IsDisposed)
        cellValueChanged((object) this, e);
      if (!this.ShowFilterRow || this.FilterRow == null || !this.Columns[e.ColumnIndex].AllowRowFiltering)
        return;
      (this.FilterRow.Cells[e.ColumnIndex] as DataGridViewFilterCell).UpdateFilterComboBox();
    }

    /// <summary>Handles the hierarchic value changed.</summary>
    /// <param name="intColumnIndex">Index of the int column.</param>
    /// <param name="intRowIndex">Index of the int row.</param>
    private void HandleHierarchicValueChanged(int intColumnIndex, int intRowIndex)
    {
      if (this.mobjRealFilteringDataMemberIndexByProposedFilteringDataMember == null || !this.mobjRealFilteringDataMemberIndexByProposedFilteringDataMember.ContainsValue(this.Columns[intColumnIndex].Name))
        return;
      DataGridViewRow row = this.Rows[intRowIndex];
      bool expanded = row.Expanded;
      row.ResetChildGrid();
      if (!expanded)
        return;
      row.Expanded = true;
    }

    internal void OnCellCommonChange(int intColumnIndex, int intRowIndex) => this.OnCellCommonChange(intColumnIndex, intRowIndex, false);

    private void OnRowHeaderGlobalAutoSize(int rowIndex)
    {
      if (!this.RowHeadersVisible)
        return;
      this.InvalidateCellPrivate(-1, rowIndex);
      if (this.AutoSizeCount > 0)
        return;
      bool flag1 = false;
      if (rowIndex != -1)
        flag1 = (this.Rows.GetRowState(rowIndex) & DataGridViewElementStates.Displayed) != 0;
      bool blnFixedColumnHeadersHeight = rowIndex != -1 || this.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      bool blnFixedRowHeight = rowIndex == -1 || (this.AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 1) == DataGridViewAutoSizeRowsMode.None || (this.AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 8) != DataGridViewAutoSizeRowsMode.None && rowIndex != -1 && !flag1;
      bool flag2 = false;
      if (this.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders || ((this.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders ? 0 : (rowIndex != -1 ? 1 : 0)) & (flag1 ? 1 : 0)) != 0 || this.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && this.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing && rowIndex == -1 || this.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader && rowIndex != -1 && rowIndex == this.Rows.GetFirstRow(DataGridViewElementStates.Visible))
      {
        this.AutoResizeRowHeadersWidth(rowIndex, this.RowHeadersWidthSizeMode, blnFixedColumnHeadersHeight, blnFixedRowHeight);
        flag2 = true;
      }
      if (!blnFixedColumnHeadersHeight)
        this.AutoResizeColumnHeadersHeight(-1, true, true);
      if (!blnFixedRowHeight)
        this.AutoResizeRowInternal(rowIndex, DataGridView.MapAutoSizeRowsModeToRowMode(this.AutoSizeRowsMode), true, true);
      if (!flag2 || blnFixedColumnHeadersHeight && blnFixedRowHeight)
        return;
      this.AutoResizeRowHeadersWidth(rowIndex, this.RowHeadersWidthSizeMode, true, true);
    }

    private void OnColumnHeaderGlobalAutoSize(int columnIndex)
    {
      if (!this.ColumnHeadersVisible)
        return;
      this.InvalidateCellPrivate(columnIndex, -1);
      if (this.AutoSizeCount > 0)
        return;
      DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal) this.Columns[columnIndex].InheritedAutoSizeMode;
      bool blnFixedColumnWidth = (inheritedAutoSizeMode & DataGridViewAutoSizeColumnCriteriaInternal.Header) == DataGridViewAutoSizeColumnCriteriaInternal.NotSet;
      if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
        this.AutoResizeColumnHeadersHeight(columnIndex, true, blnFixedColumnWidth);
      if (blnFixedColumnWidth)
        return;
      bool blnFixedHeight = (this.AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) == DataGridViewAutoSizeRowsMode.None;
      this.AutoResizeColumnInternal(columnIndex, inheritedAutoSizeMode, blnFixedHeight);
      if (!blnFixedHeight)
      {
        this.AdjustShrinkingRows(this.AutoSizeRowsMode, true, true);
        this.AutoResizeColumnInternal(columnIndex, inheritedAutoSizeMode, true);
      }
      if (this.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize)
        return;
      this.AutoResizeColumnHeadersHeight(columnIndex, true, true);
    }

    private void OnCellCommonChange(int intColumnIndex, int intRowIndex, bool blnClientSource)
    {
      if (intColumnIndex == -1)
        this.OnRowHeaderGlobalAutoSize(intRowIndex);
      else if (intRowIndex == -1)
      {
        this.OnColumnHeaderGlobalAutoSize(intColumnIndex);
      }
      else
      {
        DataGridViewAutoSizeRowsMode autoSizeRowsMode = this.AutoSizeRowsMode;
        if (!blnClientSource)
          this.InvalidateCellPrivate(intColumnIndex, intRowIndex);
        bool flag1 = false;
        if (intRowIndex != -1)
          flag1 = (this.Rows.GetRowState(intRowIndex) & DataGridViewElementStates.Displayed) != 0;
        DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal) this.Columns[intColumnIndex].InheritedAutoSizeMode;
        bool flag2 = (inheritedAutoSizeMode & DataGridViewAutoSizeColumnCriteriaInternal.AllRows) != 0;
        if (flag1)
          flag2 |= (inheritedAutoSizeMode & DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows) != 0;
        bool flag3 = (autoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) != 0;
        if (flag3)
          this.AutoResizeRowInternal(intRowIndex, DataGridView.MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), !flag2, true);
        if (!flag2)
          return;
        this.AutoResizeColumnInternal(intColumnIndex, inheritedAutoSizeMode, true);
        if (!flag3)
          return;
        this.AutoResizeRowInternal(intRowIndex, DataGridView.MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), true, true);
      }
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueNeeded"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs.ColumnIndex"></see> property of e is less than zero or greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs.RowIndex"></see> property of e is less than zero or greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
    {
      if (e.ColumnIndex < 0 || e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex < 0 || e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      DataGridViewCellValueEventHandler cellValueNeeded = this.CellValueNeeded;
      if (cellValueNeeded == null)
        return;
      cellValueNeeded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValuePushed"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs.ColumnIndex"></see> property of e is less than zero or greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs.RowIndex"></see> property of e is less than zero or greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellValuePushed(DataGridViewCellValueEventArgs e)
    {
      if (e.ColumnIndex < 0 || e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex < 0 || e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      DataGridViewCellValueEventHandler cellValuePushed = this.CellValuePushed;
      if (cellValuePushed == null)
        return;
      cellValuePushed((object) this, e);
    }

    internal void OnCellValuePushed(int intColumnIndex, int intRowIndex, object objValue)
    {
      DataGridViewCellValueEventArgs cellValueEventArgs = this.CellValueEventArgs;
      cellValueEventArgs.SetProperties(intColumnIndex, intRowIndex, objValue);
      this.OnCellValuePushed(cellValueEventArgs);
    }

    internal object OnCellValueNeeded(int intColumnIndex, int intRowIndex)
    {
      DataGridViewCellValueEventArgs cellValueEventArgs = this.CellValueEventArgs;
      cellValueEventArgs.SetProperties(intColumnIndex, intRowIndex, (object) null);
      this.OnCellValueNeeded(cellValueEventArgs);
      return cellValueEventArgs.Value;
    }

    internal void OnColumnCommonChange(int intColumnIndex) => this.OnColumnGlobalAutoSize(intColumnIndex);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intColumnIndex"></param>
    private void OnColumnGlobalAutoSize(int intColumnIndex)
    {
      if (!this.Columns[intColumnIndex].Visible)
        return;
      this.InvalidateColumnInternal(intColumnIndex);
      if (this.AutoSizeCount > 0)
        return;
      bool blnFixedHeight = (this.AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) == DataGridViewAutoSizeRowsMode.None;
      DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal) this.Columns[intColumnIndex].InheritedAutoSizeMode;
      switch (inheritedAutoSizeMode)
      {
        case DataGridViewAutoSizeColumnCriteriaInternal.None:
        case DataGridViewAutoSizeColumnCriteriaInternal.Fill:
          if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
            this.AutoResizeColumnHeadersHeight(intColumnIndex, true, true);
          if (blnFixedHeight || inheritedAutoSizeMode == DataGridViewAutoSizeColumnCriteriaInternal.None || inheritedAutoSizeMode == DataGridViewAutoSizeColumnCriteriaInternal.Fill)
            break;
          this.AutoResizeColumnInternal(intColumnIndex, inheritedAutoSizeMode, true);
          break;
        default:
          this.AutoResizeColumnInternal(intColumnIndex, inheritedAutoSizeMode, blnFixedHeight);
          goto case DataGridViewAutoSizeColumnCriteriaInternal.None;
      }
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnAdded"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnAdded(DataGridViewColumnEventArgs e)
    {
      if (e.Column.DataGridView != this)
        throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"));
      DataGridViewColumnEventHandler columnAdded = this.ColumnAdded;
      if (columnAdded == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      columnAdded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnContextMenuStripChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnContextMenuStripChanged(DataGridViewColumnEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDataPropertyNameChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnDataPropertyNameChanged(DataGridViewColumnEventArgs e)
    {
      if (this.ShowFilterRow && this.mobjDataGridViewFilterRow != null && e.Column.AllowRowFiltering && this.mobjDataGridViewFilterRow.Cells.Count > e.Column.Index)
        (this.mobjDataGridViewFilterRow.Cells[e.Column.Index] as DataGridViewFilterCell).RefreshFilterCell();
      if (e.Column.DataGridView != this)
        throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"));
      if (this.DataSource != null && e.Column.DataPropertyName.Length != 0 && !this.mobjDataGridViewOper[1024])
        this.MapDataGridViewColumnToDataBoundField(e.Column);
      else if (this.DataSource != null && e.Column.DataPropertyName.Length == 0 && e.Column.IsDataBound)
      {
        e.Column.IsDataBoundInternal = false;
        e.Column.BoundColumnIndex = -1;
        e.Column.BoundColumnConverter = (TypeConverter) null;
        this.InvalidateColumnInternal(e.Column.Index);
      }
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNDATAPROPERTYNAMECHANGED) is DataGridViewColumnEventHandler handler) || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      handler((object) this, e);
    }

    /// <summary>Corrects the column frozen states for move.</summary>
    /// <param name="objDataGridViewColumn">The data grid view column.</param>
    /// <param name="intNewDisplayIndex">New index of the display.</param>
    private void CorrectColumnFrozenStatesForMove(
      DataGridViewColumn objDataGridViewColumn,
      int intNewDisplayIndex)
    {
      if (!objDataGridViewColumn.Visible || intNewDisplayIndex < objDataGridViewColumn.DisplayIndex && objDataGridViewColumn.Frozen || intNewDisplayIndex > objDataGridViewColumn.DisplayIndex && !objDataGridViewColumn.Frozen)
        return;
      int count = this.Columns.Count;
      if (intNewDisplayIndex < objDataGridViewColumn.DisplayIndex)
      {
        int intDisplayIndex = intNewDisplayIndex;
        DataGridViewColumn columnAtDisplayIndex;
        do
        {
          columnAtDisplayIndex = this.Columns.GetColumnAtDisplayIndex(intDisplayIndex);
          ++intDisplayIndex;
        }
        while (intDisplayIndex < count && (columnAtDisplayIndex == null || columnAtDisplayIndex == objDataGridViewColumn || !columnAtDisplayIndex.Visible));
        if (columnAtDisplayIndex != null && columnAtDisplayIndex.Frozen)
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotMoveNonFrozenColumn"));
      }
      else
      {
        int intDisplayIndex = intNewDisplayIndex;
        DataGridViewColumn columnAtDisplayIndex;
        do
        {
          columnAtDisplayIndex = this.Columns.GetColumnAtDisplayIndex(intDisplayIndex);
          --intDisplayIndex;
        }
        while (intDisplayIndex >= 0 && (columnAtDisplayIndex == null || !columnAtDisplayIndex.Visible));
        if (columnAtDisplayIndex != null && !columnAtDisplayIndex.Frozen)
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotMoveFrozenColumn"));
      }
    }

    /// <summary>Called when [column display index changing].</summary>
    /// <param name="objDataGridViewColumn">The data grid view column.</param>
    /// <param name="intNewDisplayIndex">New index of the display.</param>
    internal void OnColumnDisplayIndexChanging(
      DataGridViewColumn objDataGridViewColumn,
      int intNewDisplayIndex)
    {
      if (this.mobjDataGridViewOper[2048])
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
      this.CorrectColumnFrozenStatesForMove(objDataGridViewColumn, intNewDisplayIndex);
      try
      {
        this.mobjDataGridViewOper[2048] = true;
        if (intNewDisplayIndex < objDataGridViewColumn.DisplayIndex)
        {
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
          {
            if (intNewDisplayIndex <= column.DisplayIndex && column.DisplayIndex < objDataGridViewColumn.DisplayIndex)
            {
              DataGridViewColumn dataGridViewColumn = column;
              dataGridViewColumn.DisplayIndexInternal = dataGridViewColumn.DisplayIndex + 1;
              column.DisplayIndexHasChanged = true;
            }
          }
        }
        else
        {
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
          {
            if (objDataGridViewColumn.DisplayIndex < column.DisplayIndex && column.DisplayIndex <= intNewDisplayIndex)
            {
              DataGridViewColumn dataGridViewColumn = column;
              dataGridViewColumn.DisplayIndexInternal = dataGridViewColumn.DisplayIndex - 1;
              column.DisplayIndexHasChanged = true;
            }
          }
        }
      }
      finally
      {
        this.mobjDataGridViewOper[2048] = false;
      }
    }

    /// <summary>
    /// Called when [column display index changed_ pre notification].
    /// </summary>
    internal void OnColumnDisplayIndexChanged_PreNotification()
    {
      this.Columns.InvalidateCachedColumnsOrder();
      this.PerformLayoutPrivate(true);
    }

    /// <summary>
    /// Called when [column display index changed_ post notification].
    /// </summary>
    internal void OnColumnDisplayIndexChanged_PostNotification() => this.FlushDisplayIndexChanged(true);

    internal void OnColumnDataPropertyNameChanged(DataGridViewColumn objDataGridViewColumn) => this.OnColumnDataPropertyNameChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));

    internal void OnColumnNameChanged(DataGridViewColumn objDataGridViewColumn) => this.OnColumnNameChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDefaultCellStyleChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnDefaultCellStyleChanged(DataGridViewColumnEventArgs e)
    {
      DataGridViewColumnEventHandler cellStyleChanged = this.ColumnDefaultCellStyleChanged;
      if (cellStyleChanged == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      cellStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDisplayIndexChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnDisplayIndexChanged(DataGridViewColumnEventArgs e)
    {
      DataGridViewColumnEventHandler displayIndexChanged = this.ColumnDisplayIndexChanged;
      if (displayIndexChanged == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      displayIndexChanged((object) this, e);
    }

    /// <summary>Called when [column display index changed].</summary>
    /// <param name="objDataGridViewColumn">The obj data grid view column.</param>
    internal void OnColumnDisplayIndexChanged(DataGridViewColumn objDataGridViewColumn)
    {
      this.Update();
      this.OnColumnDisplayIndexChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDividerDoubleClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDividerDoubleClickEventArgs"></see> that contains the event data. </param>
    protected virtual void OnColumnDividerDoubleClick(
      DataGridViewColumnDividerDoubleClickEventArgs e)
    {
      DataGridViewColumnDividerDoubleClickEventHandler doubleClickHandler = this.ColumnDividerDoubleClickHandler;
      if (doubleClickHandler == null)
        return;
      doubleClickHandler((object) this, e);
    }

    /// <summary>Raises the column divider double click.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDividerDoubleClickEventArgs" /> instance containing the event data.</param>
    internal void RaiseColumnDividerDoubleClick(DataGridViewColumnDividerDoubleClickEventArgs e) => this.OnColumnDividerDoubleClick(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDividerWidthChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnDividerWidthChanged(DataGridViewColumnEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeaderCellChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnHeaderCellChanged(DataGridViewColumnEventArgs e)
    {
    }

    /// <summary>Fires the column header mouse click.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
    internal void FireColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e) => this.OnColumnHeaderMouseClick(e);

    /// <summary>Fires the column header mouse double click.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
    internal void FireColumnHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e) => this.OnColumnHeaderMouseDoubleClick(e);

    /// <summary>Fires the row header mouse click.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
    internal void FireRowHeaderMouseClick(DataGridViewCellMouseEventArgs e) => this.OnRowHeaderMouseClick(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeaderMouseClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is less than zero or greater than the number of columns in the control minus one.</exception>
    protected virtual void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left && this.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && this.SelectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
      {
        DataGridViewColumn column = this.Columns[e.ColumnIndex];
        if (column.SortMode == DataGridViewColumnSortMode.Automatic && (!this.VirtualMode || column.IsDataBound))
        {
          ListSortDirection enmDirection = ListSortDirection.Ascending;
          if (this.SortedColumn == column && this.SortOrder == SortOrder.Ascending)
            enmDirection = ListSortDirection.Descending;
          if (this.DataSource == null || this.DataSource != null && this.DataConnection.List is IBindingList && ((IBindingList) this.DataConnection.List).SupportsSorting && column.IsDataBound)
            this.Sort(column, enmDirection);
        }
      }
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK) is DataGridViewCellMouseEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeaderMouseDoubleClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the cell and the position of the mouse pointer.</param>
    protected virtual void OnColumnHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK) is DataGridViewCellMouseEventHandler handler) || this.mobjDataGridViewOper[1048576] || this.IsDisposed || handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersBorderStyleChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnColumnHeadersBorderStyleChanged(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersDefaultCellStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnColumnHeadersDefaultCellStyleChanged(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersHeightChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnColumnHeadersHeightChanged(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersHeightSizeModeChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> that contains the event data. </param>
    protected virtual void OnColumnHeadersHeightSizeModeChanged(DataGridViewAutoSizeModeEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnMinimumWidthChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnMinimumWidthChanged(DataGridViewColumnEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnNameChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnNameChanged(DataGridViewColumnEventArgs e)
    {
      if (e.Column.DataGridView != this)
        throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"));
      DataGridViewColumn column = e.Column;
      if (!column.HasHeaderCell || !(column.HeaderCell.Value is string) || string.Compare((string) column.HeaderCell.Value, column.Name, false, CultureInfo.InvariantCulture) != 0)
        return;
      this.InvalidateCellPrivate(column.Index, -1);
      DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal) column.InheritedAutoSizeMode;
      bool blnFixedColumnWidth = (inheritedAutoSizeMode & DataGridViewAutoSizeColumnCriteriaInternal.Header) == DataGridViewAutoSizeColumnCriteriaInternal.NotSet || !this.ColumnHeadersVisible;
      if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
        this.AutoResizeColumnHeadersHeight(column.Index, true, blnFixedColumnWidth);
      if (blnFixedColumnWidth)
        return;
      bool blnFixedHeight = (this.AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) == DataGridViewAutoSizeRowsMode.None;
      this.AutoResizeColumnInternal(column.Index, inheritedAutoSizeMode, blnFixedHeight);
      if (!blnFixedHeight)
      {
        this.AdjustShrinkingRows(this.AutoSizeRowsMode, true, true);
        this.AutoResizeColumnInternal(column.Index, inheritedAutoSizeMode, true);
      }
      if (this.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize)
        return;
      this.AutoResizeColumnHeadersHeight(column.Index, true, true);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnRemoved"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    protected virtual void OnColumnRemoved(DataGridViewColumnEventArgs e)
    {
      DataGridViewColumnEventHandler columnRemoved = this.ColumnRemoved;
      if (columnRemoved == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      columnRemoved((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnSortModeChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnSortModeChanged(DataGridViewColumnEventArgs e)
    {
    }

    internal void OnColumnSortModeChanged(DataGridViewColumn objDataGridViewColumn) => this.OnColumnSortModeChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnStateChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnStateChangedEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.InvalidCastException">The column changed from read-only to read/write, enabling the current cell to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    protected virtual void OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e)
    {
      DataGridViewColumn column = e.Column;
      switch (e.StateChanged)
      {
        case DataGridViewElementStates.Frozen:
          if (column.Visible)
          {
            this.mobjDataGridViewState2[67108864] = true;
            this.PerformLayoutPrivate(true);
            this.Invalidate();
            break;
          }
          break;
        case DataGridViewElementStates.Selected:
          if (column.Visible && this.BulkPaintCount == 0)
          {
            this.InvalidateColumnInternal(column.Index);
            break;
          }
          break;
        case DataGridViewElementStates.Visible:
          if (!column.Visible && column.Displayed)
            column.DisplayedInternal = false;
          this.mobjDataGridViewState2[67108864] = true;
          this.PerformLayoutPrivate(true);
          DataGridViewAutoSizeRowsMode autoSizeRowsMode = this.AutoSizeRowsMode;
          bool flag1 = (autoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) != DataGridViewAutoSizeRowsMode.None || (autoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 1) != DataGridViewAutoSizeRowsMode.None && this.RowHeadersVisible;
          bool flag2 = false;
          DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = column.InheritedAutoSizeMode;
          switch (inheritedAutoSizeMode)
          {
            case DataGridViewAutoSizeColumnMode.None:
            case DataGridViewAutoSizeColumnMode.Fill:
              if (flag1)
              {
                if (column.Visible)
                  this.AdjustExpandingRows(column.Index, true);
                else
                  this.AdjustShrinkingRows(autoSizeRowsMode, true, true);
                if (flag2)
                {
                  this.AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal) inheritedAutoSizeMode, true);
                  break;
                }
                break;
              }
              this.Invalidate();
              break;
            default:
              int thicknessInternal = column.ThicknessInternal;
              if (column.Visible)
              {
                column.CachedThickness = thicknessInternal;
                this.AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal) inheritedAutoSizeMode, !flag1);
                flag2 = true;
                goto case DataGridViewAutoSizeColumnMode.None;
              }
              else if (thicknessInternal != column.CachedThickness)
              {
                column.ThicknessInternal = Math.Max(column.MinimumWidth, column.CachedThickness);
                goto case DataGridViewAutoSizeColumnMode.None;
              }
              else
                goto case DataGridViewAutoSizeColumnMode.None;
          }
          break;
      }
      DataGridViewColumnStateChangedEventHandler columnStateChanged = this.ColumnStateChanged;
      if (columnStateChanged != null)
        columnStateChanged((object) this, e);
      if (e.StateChanged != DataGridViewElementStates.ReadOnly || column.Index != this.mobjCurrentCellPoint.X || this.mobjDataGridViewOper[16384] || column.ReadOnly || !this.ColumnEditable(this.mobjCurrentCellPoint.X) || (this.Rows.GetRowState(this.mobjCurrentCellPoint.Y) & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || this.IsCurrentCellInEditMode || this.EditMode != DataGridViewEditMode.EditOnEnter && (this.EditMode == DataGridViewEditMode.EditProgrammatically || !(this.CurrentCellInternal.EditType == (Type) null)))
        return;
      this.BeginEditInternal(true);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnToolTipTextChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains information about the column.</param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnToolTipTextChanged(DataGridViewColumnEventArgs e)
    {
    }

    internal void OnColumnToolTipTextChanged(DataGridViewColumn objDataGridViewColumn) => this.OnColumnToolTipTextChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnWidthChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED) is DataGridViewColumnEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CurrentCellChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnCurrentCellChanged(EventArgs e)
    {
      EventHandler cellChangedHandler = this.CurrentCellChangedHandler;
      if (cellChangedHandler == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      cellChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:CurrentCellDirtyStateChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCurrentCellDirtyStateChanged(EventArgs e) => this.OnCurrentCellDirtyStateChanged(e, false);

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CurrentCellDirtyStateChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    private void OnCurrentCellDirtyStateChanged(EventArgs e, bool blnClientSource)
    {
      if (!blnClientSource && this.RowHeadersVisible && this.ShowEditingIcon)
        this.InvalidateCellPrivate(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
      if (this.IsCurrentCellDirty && this.NewRowIndex == this.mobjCurrentCellPoint.Y)
      {
        this.NewRowIndex = -1;
        this.AddNewRow(true);
      }
      EventHandler dirtyStateChanged = this.CurrentCellDirtyStateChanged;
      if (dirtyStateChanged == null)
        return;
      dirtyStateChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.CursorChanged"></see> event and updates the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.UserSetCursor"></see> property if the cursor was changed in user code.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected override void OnCursorChanged(EventArgs e)
    {
    }

    /// <summary>Called when [data binding complete].</summary>
    /// <param name="enmListChangedType">Type of the list changed.</param>
    internal void OnDataBindingComplete(ListChangedType enmListChangedType)
    {
      this.OnDataBindingComplete(new DataGridViewBindingCompleteEventArgs(enmListChangedType));
      if (enmListChangedType == ListChangedType.Reset && this.ShowFilterRow && !this.mblnSuspendFilterInitialization)
        this.SwitchPreRenderUpdate(DataGridView.PreRenderUpdateType.FilterRow);
      this.SwitchPreRenderUpdate(DataGridView.PreRenderUpdateType.GroupHeaders);
    }

    /// <summary>Gets the column header info.</summary>
    /// <param name="objDataGridViewColumn">The obj data grid view column.</param>
    /// <returns></returns>
    internal HeaderFilterInfo GetColumnHeaderInfo(DataGridViewColumn objDataGridViewColumn)
    {
      List<HeaderFilterInfo> headersFilterInfo = this.mobjHeadersFilterInfo;
      if (headersFilterInfo != null)
      {
        foreach (HeaderFilterInfo columnHeaderInfo in headersFilterInfo)
        {
          if (columnHeaderInfo.DataPropertyName == objDataGridViewColumn.DataPropertyName)
            return columnHeaderInfo;
        }
      }
      return (HeaderFilterInfo) null;
    }

    /// <summary>Initializes the grouping data.</summary>
    private void PreRenderGroupingData()
    {
      if (this.DataSource is BindingSource dataSource && dataSource.SupportsSorting && this.GroupingColumns.Count > 0)
      {
        string groupingColumn = this.GroupingColumns[0];
        string forProposedMember = this.Columns.GetRealDataMemberForProposedMember(groupingColumn);
        if (!string.IsNullOrEmpty(forProposedMember) && !string.IsNullOrEmpty(groupingColumn))
        {
          DataGridViewColumn column = this.Columns[forProposedMember];
          if (!column.CanGroupBy)
            throw new InvalidOperationException(SR.GetString("DataGridView_CannotGroupByThisColumn", (object) column.HeaderText));
          if (column != null)
          {
            if (this.SortedColumn != column || this.SortOrder != SortOrder.Ascending)
              this.Sort(column, ListSortDirection.Ascending);
            int columnCount = this.Columns.GetColumnCount(DataGridViewElementStates.Visible);
            if (columnCount > 0)
            {
              DataGridViewRow dataGridViewRow = (DataGridViewRow) null;
              int num = this.Rows.GetFirstRow(DataGridViewElementStates.None);
              DataGridViewColumn firstColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
              if (firstColumn != null)
              {
                bool flag = false;
                int index = firstColumn.Index;
                if (this.mintPrevGroupHeaderCellPanelIndex >= 0 && index != this.mintPrevGroupHeaderCellPanelIndex)
                  flag = true;
                while (num >= 0)
                {
                  DataGridViewRow row = this.Rows[num];
                  if (row != null)
                  {
                    if (flag)
                      row.Cells[this.mintPrevGroupHeaderCellPanelIndex].Panel = (DataGridViewCellPanel) null;
                    object objB = row.Cells[forProposedMember].Value;
                    if (dataGridViewRow != null && object.Equals(dataGridViewRow.Cells[forProposedMember].Value, objB))
                    {
                      if (row.Visible)
                        row.Visible = false;
                      row.Cells[0].Rowspan = 0;
                      row.Cells[0].Colspan = 0;
                    }
                    else
                    {
                      if (this.SystemHierarchicInfos.Count > 0)
                      {
                        if (!row.IsNewRow)
                          this.CreateGroupHeader(groupingColumn, index, columnCount, row.Cells[forProposedMember].Value, row);
                        else
                          this.CreateGroupHeader("New Row", index, columnCount, (object) "Empty", row);
                      }
                      dataGridViewRow = row;
                    }
                    num = this.Rows.GetNextRow(num, DataGridViewElementStates.None);
                  }
                }
                this.mintPrevGroupHeaderCellPanelIndex = index;
              }
            }
          }
          else
            throw new Exception(SR.GetString("DataGridView_InvalidGroupingColumnName", (object) groupingColumn));
        }
      }
      this.SwitchPreRenderUpdate(~DataGridView.PreRenderUpdateType.GroupHeaders);
    }

    /// <summary>Creates the group header.</summary>
    /// <param name="strColumnDataPropertyName">Name of the STR column data property.</param>
    /// <param name="intFirstVisibleColumnIndex">Index of the int first visible column.</param>
    /// <param name="intVisibleColumnsCount">The int visible columns count.</param>
    /// <param name="objCurrentValue">The obj current value.</param>
    /// <param name="objCurrentRow">The obj current row.</param>
    private void CreateGroupHeader(
      string strColumnDataPropertyName,
      int intFirstVisibleColumnIndex,
      int intVisibleColumnsCount,
      object objCurrentValue,
      DataGridViewRow objCurrentRow)
    {
      if (!objCurrentRow.Visible)
        objCurrentRow.Visible = true;
      BindingSource objRowBindingSource = (BindingSource) null;
      if (this.mblnSupportGroupCount && !objCurrentRow.IsNewRow)
        objRowBindingSource = this.GetClonedBindingSourceWithFilterForNextLevel(objCurrentRow);
      DataGridViewCell cell = objCurrentRow.Cells[intFirstVisibleColumnIndex];
      if (cell == null)
        return;
      string empty = string.Empty;
      if (objCurrentValue != null)
        empty = objCurrentValue.ToString();
      this.FormatGroupHeader(cell, intVisibleColumnsCount, strColumnDataPropertyName, empty, objRowBindingSource);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventArgs"></see> that contains the event data.</param>
    protected virtual void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
    {
      DataGridViewBindingCompleteEventHandler dataBindingComplete = this.DataBindingComplete;
      if (dataBindingComplete == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      dataBindingComplete((object) this, e);
    }

    internal void OnDataErrorInternal(DataGridViewDataErrorEventArgs e) => this.OnDataError(!this.DesignMode, e);

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellContentClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains information regarding the cell whose content was clicked.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellContentClick(DataGridViewCellEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTCLICK) is DataGridViewCellEventHandler handler))
        return;
      handler((object) this, e);
    }

    internal void OnCellContentClickInternal(DataGridViewCellEventArgs e) => this.OnCellContentClick(e);

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellContentDoubleClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellContentDoubleClick(DataGridViewCellEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK) is DataGridViewCellEventHandler handler))
        return;
      handler((object) this, e);
    }

    internal void OnCellContentDoubleClickInternal(DataGridViewCellEventArgs e) => this.OnCellContentDoubleClick(e);

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellClick(DataGridViewCellEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCLICK) is DataGridViewCellEventHandler handler))
        return;
      handler((object) this, e);
    }

    internal void OnCellClickInternal(DataGridViewCellEventArgs e) => this.OnCellClick(e);

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSECLICK) is DataGridViewCellMouseEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseDoubleClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellMouseDoubleClick(DataGridViewCellMouseEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOUBLECLICK) is DataGridViewCellMouseEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Fires the click events.</summary>
    /// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
    /// <param name="objDataGridViewCellEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
    /// <param name="objDataGridViewCellMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
    internal void FireClickEvents(
      MouseEventArgs objMouseEventArgs,
      DataGridViewCellEventArgs objDataGridViewCellEventArgs,
      DataGridViewCellMouseEventArgs objDataGridViewCellMouseEventArgs)
    {
      int num = objMouseEventArgs.Button == MouseButtons.Right ? 1 : 0;
      if (num == 0)
        this.OnCellContentClick(objDataGridViewCellEventArgs);
      this.OnCellMouseDown(objDataGridViewCellMouseEventArgs);
      this.OnCellMouseUp(objDataGridViewCellMouseEventArgs);
      if (num == 0)
        this.OnCellClick(objDataGridViewCellEventArgs);
      this.OnClick((EventArgs) objMouseEventArgs);
    }

    /// <summary>Fires the double click events.</summary>
    /// <param name="objDataGridViewCellEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
    internal void FireDoubleClickEvents(
      DataGridViewCellEventArgs objDataGridViewCellEventArgs)
    {
      this.OnCellContentDoubleClick(objDataGridViewCellEventArgs);
      this.OnCellDoubleClick(objDataGridViewCellEventArgs);
      this.OnDoubleClick(EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objDataGridViewCell"></param>
    /// <param name="intColumnIndex"></param>
    /// <param name="intRowIndex"></param>
    internal void OnCellEnter(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex)
    {
      this.OnCellEnter(new DataGridViewCellEventArgs(intColumnIndex, intRowIndex));
      if (objDataGridViewCell == null)
        return;
      if (this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
        objDataGridViewCell = (DataGridViewCell) null;
      else
        objDataGridViewCell = this.Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
    }

    /// <summary>Columns the editable.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <returns></returns>
    private bool ColumnEditable(int intColumnIndex) => !this.Columns[intColumnIndex].IsDataBound || this.DataConnection == null || this.DataConnection.AllowEdit;

    /// <summary>Begins the edit internal.</summary>
    /// <param name="blnSelectAll">if set to <c>true</c> [BLN select all].</param>
    /// <returns></returns>
    private bool BeginEditInternal(bool blnSelectAll) => this.BeginEditInternal(blnSelectAll, false);

    /// <summary>Begins the edit internal.</summary>
    /// <param name="blnSelectAll">if set to <c>true</c> [select all].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <returns></returns>
    private bool BeginEditInternal(bool blnSelectAll, bool blnClientSource)
    {
      Control editingControl = this.EditingControl;
      Control latestEditingControl = this.LatestEditingControl;
      if (this.mobjDataGridViewOper[2097152])
        throw new InvalidOperationException(SR.GetString("DataGridView_BeginEditNotReentrant"));
      try
      {
        this.mobjDataGridViewOper[2097152] = true;
        DataGridViewCell currentCellInternal1 = this.CurrentCellInternal;
        if (!this.IsSharedCellReadOnly(currentCellInternal1, this.mobjCurrentCellPoint.Y) && this.ColumnEditable(this.mobjCurrentCellPoint.X))
        {
          Type editType = currentCellInternal1.EditType;
          if (editType != (Type) null || currentCellInternal1.GetType().GetInterface("Gizmox.WebGUI.Forms.IDataGridViewEditingCell") != (Type) null)
          {
            DataGridViewCellCancelEventArgs e1 = new DataGridViewCellCancelEventArgs(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
            this.OnCellBeginEdit(e1);
            if (e1.Cancel || this.mobjCurrentCellPoint.X <= -1)
              return false;
            DataGridViewCell currentCellInternal2 = this.CurrentCellInternal;
            DataGridViewCellStyle inheritedStyle = currentCellInternal2.GetInheritedStyle((DataGridViewCellStyle) null, this.mobjCurrentCellPoint.Y, true);
            if (editType == (Type) null)
            {
              this.mobjDataGridViewState1[32768] = true;
              this.InitializeEditingCellValue(ref inheritedStyle, ref currentCellInternal2);
              ((IDataGridViewEditingCell) currentCellInternal2).PrepareEditingCellForEdit(blnSelectAll);
              return true;
            }
            Type type = editType.GetInterface("Gizmox.WebGUI.Forms.IDataGridViewEditingControl");
            if (!editType.IsSubclassOf(Type.GetType("Gizmox.WebGUI.Forms.Control")) || type == (Type) null)
              throw new InvalidCastException(SR.GetString("DataGridView_InvalidEditingControl"));
            Control objControl;
            if (latestEditingControl != null && editType.IsInstanceOfType((object) latestEditingControl) && !latestEditingControl.GetType().IsSubclassOf(editType))
            {
              objControl = latestEditingControl;
              this.EditingControl = objControl;
            }
            else
            {
              objControl = (Control) SecurityUtils.SecureCreateInstance(editType);
              this.EditingControl = objControl;
              ((IDataGridViewEditingControl) objControl).EditingControlDataGridView = this;
              latestEditingControl?.Dispose();
            }
            ((IDataGridViewEditingControl) objControl).EditingControlRowIndex = this.mobjCurrentCellPoint.Y;
            this.InitializeEditingControlValue(ref inheritedStyle, currentCellInternal2);
            DataGridViewEditingControlShowingEventArgs e2 = new DataGridViewEditingControlShowingEventArgs(objControl, inheritedStyle);
            this.OnEditingControlShowing(e2);
            if (objControl == null)
              return false;
            ((IDataGridViewEditingControl) objControl).ApplyCellStyleToEditingControl(e2.CellStyle);
            if (objControl == null)
              return false;
            ((IDataGridViewEditingControl) objControl).PrepareEditingControlForEdit(blnSelectAll);
            if (!blnClientSource)
              this.InvalidateCellPrivate(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
            return true;
          }
        }
        return false;
      }
      finally
      {
        this.mobjDataGridViewOper[2097152] = false;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected override void OnEnter(EventArgs e)
    {
      if (this.EditingControl != null && this.EditingControl.ContainsFocus)
        return;
      base.OnEnter(e);
      if (this.DesignMode)
        return;
      this.mobjDataGridViewState1[64] = false;
      if (this.mobjCurrentCellPoint.X > -1)
      {
        DataGridViewCell objDataGridViewCell = (DataGridViewCell) null;
        this.OnRowEnter(ref objDataGridViewCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y, false, false);
        if (this.mobjCurrentCellPoint.X == -1)
          return;
        this.OnCellEnter(ref objDataGridViewCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
      }
      else
      {
        if (this.mobjDataGridViewOper[8192])
          return;
        this.MakeFirstDisplayedCellCurrentCell(true);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objDataGridViewCell"></param>
    /// <param name="intColumnIndex"></param>
    /// <param name="intRowIndex"></param>
    /// <param name="blnCanCreateNewRow"></param>
    /// <param name="blnValidationFailureOccurred"></param>
    internal void OnRowEnter(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex,
      bool blnCanCreateNewRow,
      bool blnValidationFailureOccurred)
    {
      if (!blnValidationFailureOccurred)
        this.mobjDataGridViewState1[524288] = false;
      DataGridViewRowCollection rows = this.Rows;
      if (intRowIndex >= rows.Count || intColumnIndex >= this.Columns.Count)
        return;
      bool flag = false;
      if (!blnValidationFailureOccurred && this.AllowUserToAddRowsInternal && this.NewRowIndex == intRowIndex)
      {
        this.mobjDataGridViewState1[524288] = true;
        if (blnCanCreateNewRow)
        {
          DataGridViewRowEventArgs e = new DataGridViewRowEventArgs(rows[this.NewRowIndex]);
          if (this.VirtualMode || this.DataSource != null)
          {
            if (this.DataConnection != null && this.DataConnection.InterestedInRowEvents)
            {
              this.DataConnection.OnNewRowNeeded();
              flag = true;
            }
            if (this.VirtualMode)
              this.OnNewRowNeeded(e);
          }
          if (this.AllowUserToAddRowsInternal)
          {
            this.OnDefaultValuesNeeded(e);
            this.InvalidateRowPrivate(this.NewRowIndex);
          }
        }
      }
      if (flag && intRowIndex > rows.Count - 1)
        intRowIndex = Math.Min(intRowIndex, rows.Count - 1);
      DataGridViewCellEventArgs e1 = new DataGridViewCellEventArgs(intColumnIndex, intRowIndex);
      this.OnRowEnter(e1);
      if (this.DataConnection != null && this.DataConnection.InterestedInRowEvents && !this.DataConnection.PositionChangingOutsideDataGridView && !this.DataConnection.ListWasReset && (!flag || this.DataConnection.List.Count > 0))
        this.DataConnection.OnRowEnter(e1);
      if (objDataGridViewCell == null)
        return;
      if (this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
        objDataGridViewCell = (DataGridViewCell) null;
      else
        objDataGridViewCell = rows.SharedRow(intRowIndex).Cells[intColumnIndex];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected void OnCellEnter(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler cellEnter = this.CellEnter;
      if (cellEnter == null)
        return;
      cellEnter((object) this, e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected void OnCellLeave(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler cellLeave = this.CellLeave;
      if (cellLeave == null)
        return;
      cellLeave((object) this, e);
    }

    /// <summary>Called when [cell leave].</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    internal void OnCellLeave(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex)
    {
      this.OnCellLeave(new DataGridViewCellEventArgs(intColumnIndex, intRowIndex));
      if (objDataGridViewCell == null)
        return;
      if (this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
        objDataGridViewCell = (DataGridViewCell) null;
      else
        objDataGridViewCell = this.Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellDoubleClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellDoubleClick(DataGridViewCellEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLDOUBLECLICK) is DataGridViewCellEventHandler handler))
        return;
      handler((object) this, e);
    }

    internal void OnColumnMinimumWidthChanging(
      DataGridViewColumn objDataGridViewColumn,
      int intMinimumWidth)
    {
      if (objDataGridViewColumn.InheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
        return;
      if (objDataGridViewColumn.Width >= intMinimumWidth)
        return;
      try
      {
        this.mobjDataGridViewState2[67108864] = true;
        objDataGridViewColumn.DesiredMinimumWidth = intMinimumWidth;
      }
      finally
      {
        objDataGridViewColumn.DesiredMinimumWidth = 0;
      }
    }

    internal void OnMouseWheelInternal(MouseEventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs"></see> that contains the event data. </param>
    /// <param name="blnDisplayErrorDialogIfNoHandler">true to display an error dialog box if there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event.</param>
    protected virtual void OnDataError(
      bool blnDisplayErrorDialogIfNoHandler,
      DataGridViewDataErrorEventArgs e)
    {
      if (this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      DataGridViewDataErrorEventHandler dataError = this.DataError;
      if (dataError == null)
      {
        if (!blnDisplayErrorDialogIfNoHandler)
          return;
        string strText;
        if (e.Exception == null)
          strText = SR.GetString("DataGridView_ErrorMessageText_NoException");
        else
          strText = SR.GetString("DataGridView_ErrorMessageText_WithException", (object) e.Exception);
        bool flag = true;
        if (ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread")
        {
          RequestProcessingState requestProcessingState = this.Context.RequestProcessingState;
          int num;
          switch (requestProcessingState)
          {
            case RequestProcessingState.PreRenderResponse:
            case RequestProcessingState.RenderResponse:
              num = 0;
              break;
            default:
              num = requestProcessingState != RequestProcessingState.PostRrenderResponse ? 1 : 0;
              break;
          }
          flag = num != 0;
        }
        if (!flag)
          return;
        int num1 = (int) MessageBox.Show(strText, SR.GetString("DataGridView_ErrorMessageCaption"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        dataError((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataMemberChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDataMemberChanged(EventArgs e)
    {
      this.RefreshColumnsAndRows();
      this.InvalidateRowHeights();
      EventHandler dataMemberChanged = this.DataMemberChanged;
      if (dataMemberChanged != null)
        dataMemberChanged((object) this, e);
      if (this.DataConnection == null || this.DataConnection.CurrencyManager == null)
        return;
      this.OnDataBindingComplete(ListChangedType.Reset);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataSourceChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDataSourceChanged(EventArgs e)
    {
      this.RefreshColumnsAndRows();
      this.InvalidateRowHeights();
      EventHandler dataSourceChanged = this.DataSourceChanged;
      if (dataSourceChanged != null)
        dataSourceChanged((object) this, e);
      if (this.DataConnection == null || this.DataConnection.CurrencyManager == null)
        return;
      this.OnDataBindingComplete(ListChangedType.Reset);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DefaultCellStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDefaultCellStyleChanged(EventArgs e)
    {
      if (e is DataGridViewCellStyleChangedEventArgs changedEventArgs && !changedEventArgs.ChangeAffectsPreferredSize)
        this.Invalidate();
      else
        this.OnGlobalAutoSize();
      EventHandler cellStyleChanged = this.DefaultCellStyleChanged;
      if (cellStyleChanged == null)
        return;
      cellStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DefaultValuesNeeded"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    protected virtual void OnDefaultValuesNeeded(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler defaultValuesNeeded = this.DefaultValuesNeeded;
      if (defaultValuesNeeded == null)
        return;
      defaultValuesNeeded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.EditingControlShowing"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewEditingControlShowingEventArgs"></see> that contains information about the editing control.</param>
    protected virtual void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
    {
      DataGridViewEditingControlShowingEventHandler editingControlShowing = this.EditingControlShowing;
      if (editingControlShowing == null)
        return;
      editingControlShowing((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.EditModeChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.InvalidCastException">When entering edit mode, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    protected virtual void OnEditModeChanged(EventArgs e)
    {
      EventHandler editModeChanged = this.EditModeChanged;
      if (editModeChanged == null)
        return;
      editModeChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.FontChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);
      Font font = base.Font;
      if (this.mobjDataGridViewState1[67108864] && this.ColumnHeadersDefaultCellStyle.Font != font)
      {
        this.ColumnHeadersDefaultCellStyle.Font = font;
        this.mobjDataGridViewState1[67108864] = true;
        this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = true;
        this.OnColumnHeadersDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
      }
      if (this.mobjDataGridViewState1[134217728] && this.RowHeadersDefaultCellStyle.Font != font)
      {
        this.RowHeadersDefaultCellStyle.Font = font;
        this.mobjDataGridViewState1[134217728] = true;
        this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = true;
        this.OnRowHeadersDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
      }
      if (!this.mobjDataGridViewState1[33554432] || this.DefaultCellStyle.Font == font)
        return;
      this.DefaultCellStyle.Font = font;
      this.mobjDataGridViewState1[33554432] = true;
      this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = true;
      this.OnDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ForeColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected override void OnForeColorChanged(EventArgs e)
    {
      base.OnForeColorChanged(e);
      Color foreColor = base.ForeColor;
      if (!this.mobjDataGridViewState1[1024] || !(this.DefaultCellStyle.ForeColor != foreColor))
        return;
      this.DefaultCellStyle.ForeColor = foreColor;
      this.mobjDataGridViewState1[1024] = true;
      this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = false;
      this.OnDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.GridColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnGridColorChanged(EventArgs e)
    {
      EventHandler gridColorChanged = this.GridColorChanged;
      if (gridColorChanged == null)
        return;
      gridColorChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.Exception">This action would cause the control to enter edit mode but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
    protected override void OnKeyDown(KeyEventArgs e) => base.OnKeyDown(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyUp"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
    protected override void OnKeyUp(KeyEventArgs e) => base.OnKeyUp(e);

    /// <summary>
    /// Raises the <see cref="E:LostFocus" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnLostFocus(EventArgs e) => base.OnLostFocus(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.Exception">The control is configured to enter edit mode when it receives focus, but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    protected override void OnMouseClick(MouseEventArgs e) => base.OnMouseClick(e);

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDoubleClick"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data.</param>
    protected override void OnMouseDoubleClick(MouseEventArgs e) => base.OnMouseDoubleClick(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDown"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.Exception">The control is configured to enter edit mode when it receives focus, but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    [Obsolete("Implemented by design as Click (Use Click instead).")]
    protected override void OnMouseDown(MouseEventArgs e) => base.OnMouseDown(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    [Obsolete("Implemented by design as Click (Use Click instead).")]
    protected override void OnMouseUp(MouseEventArgs e) => base.OnMouseUp(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.MultiSelectChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnMultiSelectChanged(EventArgs e)
    {
      EventHandler multiSelectChanged = this.MultiSelectChanged;
      if (multiSelectChanged == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      multiSelectChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.NewRowNeeded"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnNewRowNeeded(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler newRowNeeded = this.NewRowNeeded;
      if (newRowNeeded == null)
        return;
      newRowNeeded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ReadOnlyChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.InvalidCastException">The control changed from read-only to read/write, enabling the current cell to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    protected virtual void OnReadOnlyChanged(EventArgs e)
    {
      EventHandler readOnlyChanged = this.ReadOnlyChanged;
      if (readOnlyChanged == null)
        return;
      readOnlyChanged((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Layout" /> event.
    /// </summary>
    /// <param name="objEventArgs"></param>
    protected override void OnLayout(LayoutEventArgs objEventArgs)
    {
      base.OnLayout(objEventArgs);
      if (!this.NeedToAdjustFillingColumns)
        return;
      this.ResetUIState(false, false);
    }

    internal void OnReplacingCell(DataGridViewRow objDataGridViewRow, int intColumnIndex)
    {
    }

    internal void OnReplacedCell(DataGridViewRow objDataGridViewRow, int intColumnIndex)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowContextMenuStripChanged(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler menuStripChanged = this.RowContextMenuStripChanged;
      if (menuStripChanged == null)
        return;
      menuStripChanged((object) this, e);
    }

    /// <summary>Called when [row context menu strip needed].</summary>
    /// <param name="rowIndex">Index of the row.</param>
    /// <param name="contextMenuStrip">The context menu strip.</param>
    /// <returns></returns>
    internal ContextMenuStrip OnRowContextMenuStripNeeded(
      int rowIndex,
      ContextMenuStrip contextMenuStrip)
    {
      DataGridViewRowContextMenuStripNeededEventArgs e = new DataGridViewRowContextMenuStripNeededEventArgs(rowIndex, contextMenuStrip);
      this.OnRowContextMenuStripNeeded(e);
      return e.ContextMenuStrip;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripNeeded"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowContextMenuStripNeededEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowContextMenuStripNeeded(
      DataGridViewRowContextMenuStripNeededEventArgs e)
    {
      DataGridViewRowContextMenuStripNeededEventHandler contextMenuStripNeeded = this.RowContextMenuStripNeeded;
      if (contextMenuStripNeeded == null)
        return;
      contextMenuStripNeeded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDefaultCellStyleChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowDefaultCellStyleChanged(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler cellStyleChanged = this.RowDefaultCellStyleChanged;
      if (cellStyleChanged == null)
        return;
      cellStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDirtyStateNeeded"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.QuestionEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowDirtyStateNeeded(QuestionEventArgs e)
    {
      QuestionEventHandler dirtyStateNeeded = this.RowDirtyStateNeeded;
      if (dirtyStateNeeded == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      dirtyStateNeeded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDividerDoubleClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowDividerDoubleClickEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowDividerDoubleClick(DataGridViewRowDividerDoubleClickEventArgs e)
    {
      DataGridViewRowDividerDoubleClickEventHandler dividerDoubleClick = this.RowDividerDoubleClick;
      if (dividerDoubleClick == null)
        return;
      dividerDoubleClick((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDividerHeightChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowDividerHeightChanged(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler dividerHeightChanged = this.RowDividerHeightChanged;
      if (dividerHeightChanged == null)
        return;
      dividerHeightChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowEnter(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler rowEnter = this.RowEnter;
      if (rowEnter == null)
        return;
      rowEnter((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowErrorTextChanged(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler errorTextChanged = this.RowErrorTextChanged;
      if (errorTextChanged == null)
        return;
      errorTextChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextNeeded"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowErrorTextNeededEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowErrorTextNeeded(DataGridViewRowErrorTextNeededEventArgs e)
    {
      DataGridViewRowErrorTextNeededEventHandler rowErrorTextNeeded = this.RowErrorTextNeeded;
      if (rowErrorTextNeeded == null)
        return;
      rowErrorTextNeeded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeaderCellChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowHeaderCellChanged(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler headerCellChanged = this.RowHeaderCellChanged;
      if (headerCellChanged == null)
        return;
      headerCellChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.RowHeaderMouseClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was clicked.</param>
    protected virtual void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK) is DataGridViewCellMouseEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeaderMouseDoubleClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was double-clicked.</param>
    protected virtual void OnRowHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK) is DataGridViewCellMouseEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersBorderStyleChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowHeadersBorderStyleChanged(EventArgs e)
    {
      EventHandler borderStyleChanged = this.RowHeadersBorderStyleChanged;
      if (borderStyleChanged == null || this.mobjDataGridViewOper[1048576] || this.IsDisposed)
        return;
      borderStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersDefaultCellStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowHeadersDefaultCellStyleChanged(EventArgs e)
    {
      EventHandler cellStyleChanged = this.RowHeadersDefaultCellStyleChanged;
      if (cellStyleChanged == null)
        return;
      cellStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowHeadersWidthChanged(EventArgs e)
    {
      if (this.NeedToAdjustFillingColumns)
        this.ResetUIState(false, false);
      EventHandler headersWidthChanged = this.RowHeadersWidthChanged;
      if (headersWidthChanged == null)
        return;
      headersWidthChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeModeChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowHeadersWidthSizeModeChanged(DataGridViewAutoSizeModeEventArgs e)
    {
      DataGridViewAutoSizeModeEventHandler widthSizeModeChanged = this.RowHeadersWidthSizeModeChanged;
      if (widthSizeModeChanged == null)
        return;
      widthSizeModeChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowHeightChanged(DataGridViewRowEventArgs e)
    {
      if (this.EnforceEqualRowSize)
      {
        int thicknessInternal = e.Row.ThicknessInternal;
        foreach (DataGridViewRow row in (IEnumerable) this.Rows)
        {
          if (row.ThicknessInternal != thicknessInternal)
            row.SetThicknessInternal(thicknessInternal);
        }
      }
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWROWHEIGHTCHANGED) is DataGridViewRowEventHandler handler))
        return;
      if (this.NeedToAdjustFillingColumns)
        this.ResetUIState(false, false);
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoNeeded"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeightInfoNeededEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowHeightInfoNeeded(DataGridViewRowHeightInfoNeededEventArgs e)
    {
      DataGridViewRowHeightInfoNeededEventHandler heightInfoNeeded = this.RowHeightInfoNeeded;
      if (heightInfoNeeded == null)
        return;
      heightInfoNeeded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoPushed"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeightInfoPushedEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowHeightInfoPushed(DataGridViewRowHeightInfoPushedEventArgs e)
    {
      DataGridViewRowHeightInfoPushedEventHandler heightInfoPushed = this.RowHeightInfoPushed;
      if (heightInfoPushed == null)
        return;
      heightInfoPushed((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowLeave(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler rowLeave = this.RowLeave;
      if (rowLeave == null)
        return;
      rowLeave((object) this, e);
    }

    /// <summary>Called when [row leave].</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    private void OnRowLeave(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex)
    {
      DataGridViewRowCollection rows = this.Rows;
      if (intRowIndex >= rows.Count || intColumnIndex >= this.Columns.Count)
        return;
      this.OnRowLeave(new DataGridViewCellEventArgs(intColumnIndex, intRowIndex));
      if (objDataGridViewCell == null)
        return;
      if (this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
        objDataGridViewCell = (DataGridViewCell) null;
      else
        objDataGridViewCell = rows.SharedRow(intRowIndex).Cells[intColumnIndex];
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowMinimumHeightChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowMinimumHeightChanged(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler minimumHeightChanged = this.RowMinimumHeightChanged;
      if (minimumHeightChanged == null)
        return;
      minimumHeightChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsAdded"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowsAddedEventArgs"></see> that contains information about the added rows. </param>
    protected virtual void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
    {
      DataGridViewRowsAddedEventHandler rowsAdded = this.RowsAdded;
      if (rowsAdded == null)
        return;
      rowsAdded((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsDefaultCellStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowsDefaultCellStyleChanged(EventArgs e)
    {
      EventHandler cellStyleChanged = this.RowsDefaultCellStyleChanged;
      if (cellStyleChanged == null)
        return;
      cellStyleChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsRemoved"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowsRemovedEventArgs"></see> that contains information about the deleted rows. </param>
    protected virtual void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
    {
      DataGridViewRowsRemovedEventHandler rowsRemoved = this.RowsRemoved;
      if (rowsRemoved == null)
        return;
      rowsRemoved((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowStateChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowStateChangedEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the row that is changing state.</param>
    /// <exception cref="T:System.InvalidCastException">The row changed from read-only to read/write, enabling the current cell to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    protected virtual void OnRowStateChanged(
      int intRowIndex,
      DataGridViewRowStateChangedEventArgs e)
    {
      DataGridViewRow row = e.Row;
      DataGridViewElementStates viewElementStates = DataGridViewElementStates.None;
      bool flag1 = false;
      DataGridViewRowCollection rows = this.Rows;
      if (intRowIndex >= 0)
      {
        viewElementStates = rows.GetRowState(intRowIndex);
        flag1 = (viewElementStates & DataGridViewElementStates.Visible) != 0;
      }
      switch (e.StateChanged)
      {
        case DataGridViewElementStates.Frozen:
          if (flag1)
          {
            this.PerformLayoutPrivate(true);
            this.Invalidate();
            break;
          }
          break;
        case DataGridViewElementStates.Selected:
          if (flag1 && this.BulkPaintCount == 0)
          {
            this.InvalidateRowPrivate(intRowIndex);
            break;
          }
          break;
        case DataGridViewElementStates.Visible:
          if (!flag1 && (viewElementStates & DataGridViewElementStates.Displayed) != DataGridViewElementStates.None)
            rows.SetRowState(intRowIndex, DataGridViewElementStates.Displayed, false);
          this.PerformLayoutPrivate(true);
          this.Invalidate();
          bool flag2 = (rows.GetRowState(intRowIndex) & DataGridViewElementStates.Displayed) != 0;
          DataGridViewAutoSizeRowsMode autoSizeRowsMode = this.AutoSizeRowsMode;
          DataGridViewAutoSizeRowsModeInternal rowsModeInternal = (DataGridViewAutoSizeRowsModeInternal) autoSizeRowsMode;
          bool flag3 = false;
          if (rowsModeInternal != DataGridViewAutoSizeRowsModeInternal.None)
          {
            int thicknessInternal = row.ThicknessInternal;
            if (flag1)
            {
              row.CachedThickness = thicknessInternal;
              if ((rowsModeInternal & DataGridViewAutoSizeRowsModeInternal.DisplayedRows) == DataGridViewAutoSizeRowsModeInternal.None || flag2)
              {
                this.AutoResizeRowInternal(intRowIndex, DataGridView.MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), false, true);
                flag3 = true;
              }
            }
            else if (thicknessInternal != row.CachedThickness)
            {
              if (row.Index == -1)
                row = rows[intRowIndex];
              row.ThicknessInternal = Math.Max(row.MinimumHeight, row.CachedThickness);
            }
          }
          DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaFilter = DataGridViewAutoSizeColumnCriteriaInternal.AllRows;
          if (flag2)
            autoSizeColumnCriteriaFilter |= DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows;
          if (flag1 && rows.GetRowCount(DataGridViewElementStates.Visible) > 1)
            this.AdjustExpandingColumns(autoSizeColumnCriteriaFilter, intRowIndex);
          else
            this.AutoResizeAllVisibleColumnsInternal(autoSizeColumnCriteriaFilter, true);
          if (flag3)
          {
            this.AutoResizeRowInternal(intRowIndex, DataGridView.MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), true, true);
            break;
          }
          break;
      }
      DataGridViewRowStateChangedEventHandler rowStateChanged = this.RowStateChanged;
      if (rowStateChanged != null)
        rowStateChanged((object) this, e);
      if (e.StateChanged != DataGridViewElementStates.ReadOnly || intRowIndex != this.mobjCurrentCellPoint.Y || this.mobjDataGridViewOper[16384] || (viewElementStates & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || this.ReadOnly || this.Columns[this.mobjCurrentCellPoint.X].ReadOnly || !this.ColumnEditable(this.mobjCurrentCellPoint.X) || this.IsCurrentCellInEditMode || this.EditMode != DataGridViewEditMode.EditOnEnter && (this.EditMode == DataGridViewEditMode.EditProgrammatically || !(this.CurrentCellInternal.EditType == (Type) null)))
        return;
      this.BeginEditInternal(true);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowUnshared"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowUnshared(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler rowUnshared = this.RowUnshared;
      if (rowUnshared == null)
        return;
      rowUnshared((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowValidated(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler rowValidated = this.RowValidated;
      if (rowValidated == null)
        return;
      rowValidated((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowValidating(DataGridViewCellCancelEventArgs e)
    {
      DataGridViewCellCancelEventHandler rowValidating = this.RowValidating;
      if (rowValidating == null)
        return;
      rowValidating((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.SortCompare"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSortCompareEventArgs"></see> that contains the event data. </param>
    protected virtual void OnSortCompare(DataGridViewSortCompareEventArgs e)
    {
      DataGridViewSortCompareEventHandler sortCompare = this.SortCompare;
      if (sortCompare == null)
        return;
      sortCompare((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.Sorted"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnSorted(EventArgs e)
    {
      EventHandler sorted = this.Sorted;
      if (sorted == null)
        return;
      sorted((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserAddedRow"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnUserAddedRow(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler userAddedRow = this.UserAddedRow;
      if (userAddedRow == null)
        return;
      userAddedRow((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserDeletedRow"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    protected virtual void OnUserDeletedRow(DataGridViewRowEventArgs e)
    {
      DataGridViewRowEventHandler userDeletedRow = this.UserDeletedRow;
      if (userDeletedRow == null)
        return;
      userDeletedRow((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserDeletingRow"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCancelEventArgs"></see> that contains the event data. </param>
    protected virtual void OnUserDeletingRow(DataGridViewRowCancelEventArgs e)
    {
      DataGridViewRowCancelEventHandler userDeletingRow = this.UserDeletingRow;
      if (userDeletingRow == null)
        return;
      userDeletingRow((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Validating"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.Exception">Validation failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    protected override void OnValidating(CancelEventArgs e)
    {
      Control editingControl = this.EditingControl;
      if (!this.BecomingActiveControl && (editingControl == null || !editingControl.BecomingActiveControl))
      {
        if (!this.mobjDataGridViewState1[64] && !this.EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.LeaveControl | DataGridViewDataErrorContexts.Parsing, DataGridView.DataGridViewValidateCellInternal.Always, false, false, false, false, false, false, false, false))
        {
          e.Cancel = true;
          return;
        }
        if (this.mobjCurrentCellPoint.X >= 0)
        {
          DataGridViewCell objDataGridViewCell = (DataGridViewCell) null;
          if (this.OnRowValidating(ref objDataGridViewCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y))
          {
            e.Cancel = true;
            return;
          }
          if (this.mobjCurrentCellPoint.X == -1)
            return;
          this.OnRowValidated(ref objDataGridViewCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
          if (this.DataSource != null && this.mobjCurrentCellPoint.X >= 0 && this.AllowUserToAddRowsInternal && this.NewRowIndex == this.mobjCurrentCellPoint.Y)
          {
            int previousRow = this.Rows.GetPreviousRow(this.mobjCurrentCellPoint.Y, DataGridViewElementStates.Visible);
            if (previousRow > -1)
              this.SetAndSelectCurrentCellAddress(this.mobjCurrentCellPoint.X, previousRow, true, false, false, false, false);
            else
              this.SetCurrentCellAddressCore(-1, -1, true, false, false);
          }
        }
      }
      base.OnValidating(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected override void OnVisibleChanged(EventArgs e)
    {
      base.OnVisibleChanged(e);
      if (!this.NeedToAdjustFillingColumns)
        return;
      this.ResetUIState(false, false);
    }

    /// <summary>Paints the background of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to paint the background.</param>
    /// <param name="objClipBounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the area of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that needs to be painted.</param>
    /// <param name="objGridBounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the area in which cells are drawn.</param>
    protected virtual void PaintBackground(
      Graphics objGraphics,
      Rectangle objClipBounds,
      Rectangle objGridBounds)
    {
    }

    /// <summary>Processes the A key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    protected bool ProcessAKey(Keys enmKeyData) => false;

    /// <summary>Processes keys used for navigating in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="e">Contains information about the key that was pressed.</param>
    /// <exception cref="T:System.InvalidCastException">The key pressed would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true.-or-The DELETE key would delete one or more rows, but an error in the data source prevents the deletion and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected virtual bool ProcessDataGridViewKey(KeyEventArgs e) => false;

    /// <summary>Processes the DELETE key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.Exception">The DELETE key would delete one or more rows, but an error in the data source prevents the deletion and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessDeleteKey(Keys enmKeyData)
    {
      if (this.AllowUserToDeleteRowsInternal)
      {
        switch (this.SelectionMode)
        {
          case DataGridViewSelectionMode.FullRowSelect:
          case DataGridViewSelectionMode.RowHeaderSelect:
            int index = 0;
            try
            {
              this.SelectedBandSnapshotIndexes = new DataGridViewIntLinkedList(this.SelectedBandIndexes);
              while (this.SelectedBandSnapshotIndexes.Count > index)
              {
                int bandSnapshotIndex = this.SelectedBandSnapshotIndexes[index];
                if (bandSnapshotIndex == this.NewRowIndex || bandSnapshotIndex >= this.Rows.Count)
                {
                  ++index;
                }
                else
                {
                  DataGridViewRowCancelEventArgs e1 = new DataGridViewRowCancelEventArgs(this.Rows[bandSnapshotIndex]);
                  this.OnUserDeletingRow(e1);
                  if (!e1.Cancel)
                  {
                    DataGridViewRow row = this.Rows[bandSnapshotIndex];
                    if (this.DataSource != null)
                    {
                      int count = this.Rows.Count;
                      DataGridViewDataErrorEventArgs e2 = (DataGridViewDataErrorEventArgs) null;
                      try
                      {
                        this.DataConnection.DeleteRow(bandSnapshotIndex);
                      }
                      catch (Exception ex)
                      {
                        if (ClientUtils.IsCriticalException(ex))
                        {
                          throw;
                        }
                        else
                        {
                          int intRowIndex = bandSnapshotIndex;
                          e2 = new DataGridViewDataErrorEventArgs(ex, -1, intRowIndex, DataGridViewDataErrorContexts.RowDeletion);
                          this.OnDataErrorInternal(e2);
                          if (e2.ThrowException)
                            throw e2.Exception;
                          ++index;
                        }
                      }
                      if (count != this.Rows.Count)
                        this.OnUserDeletedRow(new DataGridViewRowEventArgs(row));
                      else if (e2 == null)
                        ++index;
                    }
                    else
                    {
                      this.Rows.RemoveAtInternal(bandSnapshotIndex, false);
                      this.OnUserDeletedRow(new DataGridViewRowEventArgs(row));
                    }
                  }
                  else
                    ++index;
                }
              }
            }
            finally
            {
              this.SelectedBandSnapshotIndexes = (DataGridViewIntLinkedList) null;
            }
            return true;
        }
      }
      return false;
    }

    /// <summary>Processes the DOWN ARROW key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.InvalidCastException">The DOWN ARROW key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessDownKey(Keys enmKeyData) => false;

    /// <summary>Processes the END key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.InvalidCastException">The END key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessEndKey(Keys enmKeyData) => false;

    /// <summary>Processes the ENTER key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    /// <exception cref="T:System.InvalidCastException">The ENTER key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    protected bool ProcessEnterKey(Keys enmKeyData) => false;

    /// <summary>Processes the ESC key.</summary>
    /// <returns>true if the key was processed; otherwise, false. </returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    protected bool ProcessEscapeKey(Keys enmKeyData) => false;

    /// <summary>Processes the F2 key.</summary>
    /// <returns>true if the key was processed; otherwise, false. </returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.Exception">The F2 key would cause the control to enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    /// <exception cref="T:System.InvalidCastException">The F2 key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    protected bool ProcessF2Key(Keys enmKeyData) => false;

    /// <summary>Processes the HOME key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">The key that was pressed.</param>
    /// <exception cref="T:System.InvalidCastException">The HOME key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessHomeKey(Keys enmKeyData) => false;

    /// <summary>Processes the INSERT key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">One of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key to process.</param>
    protected bool ProcessInsertKey(Keys enmKeyData) => false;

    /// <summary>Processes the LEFT ARROW key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.InvalidCastException">The LEFT ARROW key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessLeftKey(Keys enmKeyData) => false;

    /// <summary>Processes the PAGE DOWN key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.InvalidCastException">The PAGE DOWN key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessNextKey(Keys enmKeyData) => false;

    /// <summary>Processes the PAGE UP key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.InvalidCastException">The PAGE UP key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessPriorKey(Keys enmKeyData) => false;

    /// <summary>Processes the RIGHT ARROW key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.InvalidCastException">The RIGHT ARROW key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessRightKey(Keys enmKeyData) => false;

    /// <summary>Processes the SPACEBAR.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">One of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key to process.</param>
    protected bool ProcessSpaceKey(Keys enmKeyData) => false;

    /// <summary>Processes the TAB key.</summary>
    /// <returns>true if the key was processed; otherwise, false. </returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    /// <exception cref="T:System.InvalidCastException">The TAB key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    protected bool ProcessTabKey(Keys enmKeyData) => false;

    /// <summary>Processes the UP ARROW key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.InvalidCastException">The UP ARROW key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessUpKey(Keys enmKeyData) => false;

    /// <summary>Processes the 0 key.</summary>
    /// <returns>true if the key was processed; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
    /// <exception cref="T:System.InvalidCastException">The 0 key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.Exception">This action would cause the control to enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected bool ProcessZeroKey(Keys enmKeyData) => false;

    /// <summary>Refreshes the value of the current cell with the underlying cell value when the cell is in edit mode, discarding any previous value.</summary>
    /// <returns>true if successful; false if a <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event occurred.</returns>
    /// <filterpriority>1</filterpriority>
    public bool RefreshEdit()
    {
      if (this.mobjCurrentCellPoint.X == -1 || !this.IsCurrentCellInEditMode)
        return true;
      DataGridViewCell currentCellInternal = this.CurrentCellInternal;
      DataGridViewCellStyle inheritedStyle = currentCellInternal.GetInheritedStyle((DataGridViewCellStyle) null, this.mobjCurrentCellPoint.Y, true);
      if (this.EditingControl != null)
      {
        if (!this.InitializeEditingControlValue(ref inheritedStyle, currentCellInternal))
          return false;
        ((IDataGridViewEditingControl) this.EditingControl).PrepareEditingControlForEdit(true);
        ((IDataGridViewEditingControl) this.EditingControl).EditingControlValueChanged = false;
        this.IsCurrentCellDirtyInternal = false;
        return true;
      }
      if (!this.InitializeEditingCellValue(ref inheritedStyle, ref currentCellInternal))
        return false;
      IDataGridViewEditingCell gridViewEditingCell = currentCellInternal as IDataGridViewEditingCell;
      gridViewEditingCell.PrepareEditingCellForEdit(true);
      gridViewEditingCell.EditingCellValueChanged = false;
      this.IsCurrentCellDirtyInternal = false;
      return true;
    }

    /// <summary>Resets the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.Text"></see> property to its default value.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override void ResetText()
    {
    }

    /// <summary>Resets the color of the background.</summary>
    private void ResetBackgroundColor() => this.BackgroundColor = DataGridView.DefaultBackgroundBrush.Color;

    private bool InitializeEditingCellValue(
      ref DataGridViewCellStyle objDataGridViewCellStyle,
      ref DataGridViewCell objDataGridViewCell)
    {
      DataGridViewDataErrorEventArgs e = (DataGridViewDataErrorEventArgs) null;
      object formattedValue = objDataGridViewCell.GetFormattedValue(this.mobjCurrentCellPoint.Y, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);
      this.UneditedFormattedValue = objDataGridViewCell.GetFormattedValue(this.mobjCurrentCellPoint.Y, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);
      this.mobjDataGridViewState1[512] = true;
      try
      {
        object cellFormattedValue = (objDataGridViewCell as IDataGridViewEditingCell).GetEditingCellFormattedValue(DataGridViewDataErrorContexts.Formatting);
        if ((cellFormattedValue != null || formattedValue == null) && (cellFormattedValue == null || formattedValue != null))
        {
          if (cellFormattedValue != null)
          {
            if (formattedValue.Equals(cellFormattedValue))
              goto label_9;
          }
          else
            goto label_9;
        }
        objDataGridViewCell = this.Rows[this.mobjCurrentCellPoint.Y].Cells[this.mobjCurrentCellPoint.X];
        IDataGridViewEditingCell gridViewEditingCell = objDataGridViewCell as IDataGridViewEditingCell;
        gridViewEditingCell.EditingCellFormattedValue = formattedValue;
        gridViewEditingCell.EditingCellValueChanged = false;
      }
      catch (Exception ex)
      {
        if (ClientUtils.IsCriticalException(ex))
        {
          throw;
        }
        else
        {
          int x = this.mobjCurrentCellPoint.X;
          int y = this.mobjCurrentCellPoint.Y;
          e = new DataGridViewDataErrorEventArgs(ex, x, y, DataGridViewDataErrorContexts.InitialValueRestoration);
          this.OnDataErrorInternal(e);
        }
      }
      finally
      {
        this.mobjDataGridViewState1[512] = false;
      }
label_9:
      if (e == null)
        return true;
      if (e.ThrowException)
        throw e.Exception;
      return !e.Cancel;
    }

    private bool InitializeEditingControlValue(
      ref DataGridViewCellStyle objDataGridViewCellStyle,
      DataGridViewCell objDataGridViewCell)
    {
      DataGridViewDataErrorEventArgs e = (DataGridViewDataErrorEventArgs) null;
      object formattedValue = objDataGridViewCell.GetFormattedValue(this.mobjCurrentCellPoint.Y, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);
      this.mobjDataGridViewState1[16384] = true;
      this.mobjDataGridViewState1[512] = true;
      try
      {
        objDataGridViewCell.InitializeEditingControl(this.mobjCurrentCellPoint.Y, formattedValue, objDataGridViewCellStyle);
        ((IDataGridViewEditingControl) this.EditingControl).EditingControlValueChanged = false;
      }
      catch (Exception ex)
      {
        if (ClientUtils.IsCriticalException(ex))
        {
          throw;
        }
        else
        {
          int x = this.mobjCurrentCellPoint.X;
          int y = this.mobjCurrentCellPoint.Y;
          e = new DataGridViewDataErrorEventArgs(ex, x, y, DataGridViewDataErrorContexts.InitialValueRestoration);
          this.OnDataErrorInternal(e);
        }
      }
      finally
      {
        this.mobjDataGridViewState1[16384] = false;
        this.mobjDataGridViewState1[512] = false;
      }
      if (e != null)
      {
        if (e.ThrowException)
          throw e.Exception;
        return !e.Cancel;
      }
      this.UneditedFormattedValue = formattedValue;
      return true;
    }

    private void PushAllowUserToAddRows()
    {
      if (this.AllowUserToAddRowsInternal)
      {
        if (this.Columns.Count <= 0 || this.NewRowIndex != -1)
          return;
        this.AddNewRow(false);
      }
      else
      {
        if (this.NewRowIndex == -1)
          return;
        this.Rows.RemoveAtInternal(this.NewRowIndex, false);
      }
    }

    internal void AddNewRow(bool blnCreatedByEditing)
    {
      DataGridViewRowCollection rows = this.Rows;
      rows.AddInternal(true, (object[]) null);
      this.NewRowIndex = rows.Count - 1;
      this.mobjDataGridViewState1[2097152] = blnCreatedByEditing;
      if (blnCreatedByEditing)
        this.OnUserAddedRow(new DataGridViewRowEventArgs(rows[this.NewRowIndex]));
      this.Update();
    }

    private void InvalidateRows(int intLow, int intHigh)
    {
    }

    private void PopulateNewRowWithDefaultValues()
    {
      if (this.NewRowIndex == -1)
        return;
      DataGridViewRowCollection rows = this.Rows;
      DataGridViewCellCollection cells = rows.SharedRow(this.NewRowIndex).Cells;
      foreach (DataGridViewCell dataGridViewCell in (BaseCollection) cells)
      {
        if (dataGridViewCell.DefaultNewRowValue != null)
        {
          cells = rows[this.NewRowIndex].Cells;
          break;
        }
      }
      foreach (DataGridViewCell dataGridViewCell in (BaseCollection) cells)
        dataGridViewCell.SetValueInternal(this.NewRowIndex, dataGridViewCell.DefaultNewRowValue);
    }

    /// <summary>Selects all the cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    public void SelectAll()
    {
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"></see> and its child controls and optionally releases the managed resources.
    /// </summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
      {
        this.mobjDataGridViewOper[1048576] = true;
        try
        {
          for (int index = 0; index < this.Columns.Count; ++index)
            this.Columns[index].Dispose();
          this.Columns.Clear();
          Control latestEditingControl = this.LatestEditingControl;
          if (latestEditingControl != null)
          {
            latestEditingControl.Dispose();
            this.LatestEditingControl = (Control) null;
          }
          Control editingControl = this.EditingControl;
          if (editingControl != null)
          {
            editingControl.Dispose();
            this.EditingControl = (Control) null;
          }
          this.DataConnection?.Dispose();
        }
        finally
        {
          this.mobjDataGridViewOper[1048576] = false;
        }
      }
      base.Dispose(blnDisposing);
    }

    /// <summary>Sets the currently active cell.</summary>
    /// <returns>true if the current cell was successfully set; otherwise, false.</returns>
    /// <param name="blnValidateCurrentCell">true to validate the value in the old current cell and cancel the change if validation fails; otherwise, false.</param>
    /// <param name="intColumnIndex">The index of the column containing the cell.</param>
    /// <param name="blnThroughMouseClick">true if the current cell is being set as a result of a mouse click; otherwise, false.</param>
    /// <param name="intRowIndex">The index of the row containing the cell.</param>
    /// <param name="blnSetAnchorCellAddress">true to make the new current cell the anchor cell for a subsequent multicell selection using the SHIFT key; otherwise, false.</param>
    /// <exception cref="T:System.InvalidCastException">The new current cell tried to enter edit mode, but its <see cref="P:System.Windows.Forms.DataGridViewCell.EditType"></see> property does not indicate a class that derives from <see cref="T:System.Windows.Forms.Control"></see> and implements <see cref="T:System.Windows.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than 0 or greater than the number of columns in the control minus 1, and rowIndex is not -1.-or-rowIndex is less than 0 or greater than the number of rows in the control minus 1, and columnIndex is not -1.</exception>
    /// <exception cref="T:System.InvalidOperationException">The specified cell has a <see cref="P:System.Windows.Forms.DataGridViewCell.Visible"></see> property value of false.-or-This method was called for a reason other than the underlying data source being reset, and another thread is currently executing this method.</exception>
    protected virtual bool SetCurrentCellAddressCore(
      int intColumnIndex,
      int intRowIndex,
      bool blnSetAnchorCellAddress,
      bool blnValidateCurrentCell,
      bool blnThroughMouseClick)
    {
      return this.SetCurrentCellAddressCore(intColumnIndex, intRowIndex, blnSetAnchorCellAddress, blnValidateCurrentCell, blnThroughMouseClick, false);
    }

    /// <summary>Sets the currently active cell.</summary>
    /// <param name="intColumnIndex">The index of the column containing the cell.</param>
    /// <param name="intRowIndex">The index of the row containing the cell.</param>
    /// <param name="blnSetAnchorCellAddress">true to make the new current cell the anchor cell for a subsequent multicell selection using the SHIFT key; otherwise, false.</param>
    /// <param name="blnValidateCurrentCell">true to validate the value in the old current cell and cancel the change if validation fails; otherwise, false.</param>
    /// <param name="blnThroughMouseClick">true if the current cell is being set as a result of a mouse click; otherwise, false.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <returns>
    /// true if the current cell was successfully set; otherwise, false.
    /// </returns>
    /// <exception cref="T:System.InvalidCastException">The new current cell tried to enter edit mode, but its <see cref="P:System.Windows.Forms.DataGridViewCell.EditType"></see> property does not indicate a class that derives from <see cref="T:System.Windows.Forms.Control"></see> and implements <see cref="T:System.Windows.Forms.IDataGridViewEditingControl"></see>.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than 0 or greater than the number of columns in the control minus 1, and rowIndex is not -1.-or-rowIndex is less than 0 or greater than the number of rows in the control minus 1, and columnIndex is not -1.</exception>
    /// <exception cref="T:System.InvalidOperationException">The specified cell has a <see cref="P:System.Windows.Forms.DataGridViewCell.Visible"></see> property value of false.-or-This method was called for a reason other than the underlying data source being reset, and another thread is currently executing this method.</exception>
    private bool SetCurrentCellAddressCore(
      int intColumnIndex,
      int intRowIndex,
      bool blnSetAnchorCellAddress,
      bool blnValidateCurrentCell,
      bool blnThroughMouseClick,
      bool blnClientSource)
    {
      DataGridViewRowCollection rows = this.Rows;
      if (intColumnIndex < -1 || intColumnIndex >= 0 && intRowIndex == -1 || intColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("columnIndex");
      if (intRowIndex < -1 || intColumnIndex == -1 && intRowIndex >= 0 || intRowIndex >= rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      if (intColumnIndex > -1 && intRowIndex > -1 && !this.IsSharedCellVisible(rows.SharedRow(intRowIndex).Cells[intColumnIndex], intRowIndex))
        throw new InvalidOperationException(SR.GetString("DataGridView_CurrentCellCannotBeInvisible"));
      DataGridView.DataGridViewDataConnection dataConnection = this.DataConnection;
      Control editingControl = this.EditingControl;
      Control cachedEditingControl = this.CachedEditingControl;
      if (this.mobjDataGridViewOper[131072] && (dataConnection == null || !dataConnection.ProcessingListChangedEvent))
        throw new InvalidOperationException(SR.GetString("DataGridView_SetCurrentCellAddressCoreNotReentrant"));
      this.mobjDataGridViewOper[131072] = true;
      try
      {
        DataGridViewCell objDataGridViewCell = (DataGridViewCell) null;
        Control control1;
        if (intColumnIndex > -1)
        {
          if (this.mobjCurrentCellPoint.X != intColumnIndex || this.mobjCurrentCellPoint.Y != intRowIndex)
          {
            if (this.mobjDataGridViewState1[4194304])
            {
              this.mobjDataGridViewState1[4194304] = false;
              this.mobjCurrentCellPoint.X = intColumnIndex;
              this.mobjCurrentCellPoint.Y = intRowIndex;
              if (!blnClientSource)
                this.UpdateParams(AttributeType.Visual);
              if (cachedEditingControl != null)
              {
                ((IDataGridViewEditingControl) (this.EditingControl = cachedEditingControl)).EditingControlRowIndex = intRowIndex;
                control1 = this.CachedEditingControl = (Control) null;
              }
              this.OnCurrentCellChanged(EventArgs.Empty);
              return true;
            }
            int x = this.mobjCurrentCellPoint.X;
            int y = this.mobjCurrentCellPoint.Y;
            if (x >= 0)
            {
              DataGridViewCell dataGridViewCell = this.CurrentCellInternal;
              if (!this.EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.CurrentCellChange | DataGridViewDataErrorContexts.Parsing, blnValidateCurrentCell ? DataGridView.DataGridViewValidateCellInternal.Always : DataGridView.DataGridViewValidateCellInternal.Never, blnValidateCurrentCell, false, blnValidateCurrentCell && y != intRowIndex, false, false, this.EditMode != 0, false, false, blnClientSource))
                return false;
              if (!this.IsInnerCellOutOfBounds(x, y))
              {
                dataGridViewCell = rows.SharedRow(y).Cells[x];
                if (dataGridViewCell.LeaveUnsharesRowInternal(y, blnThroughMouseClick))
                  dataGridViewCell = rows[y].Cells[x];
                dataGridViewCell.OnLeaveInternal(y, blnThroughMouseClick);
              }
              if (this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
                return false;
              if (y != intRowIndex & blnValidateCurrentCell)
              {
                if (this.OnRowValidating(ref objDataGridViewCell, x, y))
                {
                  if (!this.IsInnerCellOutOfBounds(x, y))
                  {
                    this.OnRowEnter(ref objDataGridViewCell, x, y, true, true);
                    if (!this.IsInnerCellOutOfBounds(x, y))
                    {
                      dataGridViewCell.OnEnterInternal(y, blnThroughMouseClick);
                      this.OnCellEnter(ref objDataGridViewCell, x, y);
                    }
                  }
                  return false;
                }
                if (!this.IsInnerCellOutOfBounds(x, y))
                  this.OnRowValidated(ref objDataGridViewCell, x, y, blnClientSource);
              }
            }
            this.mobjDataGridViewState2[4194304] = false;
            try
            {
              if (y != intRowIndex && !this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
                this.OnRowEnter(ref objDataGridViewCell, intColumnIndex, intRowIndex, true, false);
              if (this.mobjDataGridViewState2[4194304] && intRowIndex >= rows.Count || this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
                return false;
              this.mobjCurrentCellPoint.X = intColumnIndex;
              this.mobjCurrentCellPoint.Y = intRowIndex;
              if (!blnClientSource)
                this.UpdateParams(AttributeType.Visual);
              if (editingControl != null)
                ((IDataGridViewEditingControl) editingControl).EditingControlRowIndex = intRowIndex;
              this.OnCurrentCellChanged(EventArgs.Empty);
              DataGridViewCell dataGridViewCell = this.CurrentCellInternal;
              if (dataGridViewCell.EnterUnsharesRowInternal(intRowIndex, blnThroughMouseClick))
                dataGridViewCell = rows[intRowIndex].Cells[intColumnIndex];
              dataGridViewCell.OnEnterInternal(intRowIndex, blnThroughMouseClick);
              this.OnCellEnter(ref objDataGridViewCell, this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
              if (x >= 0)
              {
                if (x < this.Columns.Count && y < rows.Count && (this[x, y].ClientState | DataGridViewElementClientStates.CurrentCell) != DataGridViewElementClientStates.CurrentCell)
                  this.InvalidateCellPrivate(x, y);
                if (y != this.mobjCurrentCellPoint.Y && this.RowHeadersVisible && y < rows.Count)
                  this.InvalidateCellPrivate(-1, y);
              }
              if ((this[this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y].ClientState | DataGridViewElementClientStates.CurrentCell) != DataGridViewElementClientStates.CurrentCell)
                this.InvalidateCellPrivate(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
              if (this.RowHeadersVisible && y != this.mobjCurrentCellPoint.Y)
                this.InvalidateCellPrivate(-1, this.mobjCurrentCellPoint.Y);
              if (this.Focused)
              {
                if (this.mobjCurrentCellPoint.X != -1)
                {
                  if (!this.IsCurrentCellInEditMode)
                  {
                    if (!this.mobjDataGridViewState2[4194304])
                    {
                      if (this.EditMode != DataGridViewEditMode.EditOnEnter)
                      {
                        if (this.EditMode != DataGridViewEditMode.EditProgrammatically)
                        {
                          if (!(dataGridViewCell.EditType == (Type) null))
                            goto label_63;
                        }
                        else
                          goto label_63;
                      }
                      this.BeginEditInternal(true, blnClientSource);
                    }
                  }
                }
              }
            }
            finally
            {
              this.mobjDataGridViewState2[4194304] = false;
            }
label_63:
            if (this.mobjCurrentCellPoint.X != -1)
              this.AccessibilityNotifyCurrentCellChanged(new Point(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y));
          }
          else if (this.Focused)
          {
            if (!this.IsCurrentCellInEditMode)
            {
              if (this.EditMode != DataGridViewEditMode.EditOnEnter)
              {
                if (this.EditMode != DataGridViewEditMode.EditProgrammatically)
                {
                  if (!(this.CurrentCellInternal.EditType == (Type) null))
                    goto label_104;
                }
                else
                  goto label_104;
              }
              this.BeginEditInternal(true, blnClientSource);
            }
          }
        }
        else
        {
          int x = this.mobjCurrentCellPoint.X;
          int y = this.mobjCurrentCellPoint.Y;
          if (x >= 0 && !this.mobjDataGridViewState1[4194304] && !this.mobjDataGridViewOper[1048576])
          {
            DataGridViewCell dataGridViewCell = this.CurrentCellInternal;
            if (!this.EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.CurrentCellChange | DataGridViewDataErrorContexts.Parsing, blnValidateCurrentCell ? DataGridView.DataGridViewValidateCellInternal.Always : DataGridView.DataGridViewValidateCellInternal.Never, blnValidateCurrentCell, false, blnValidateCurrentCell, false, false, this.EditMode != 0, false, false))
              return false;
            if (!this.IsInnerCellOutOfBounds(x, y))
            {
              dataGridViewCell = rows.SharedRow(y).Cells[x];
              if (dataGridViewCell.LeaveUnsharesRowInternal(y, blnThroughMouseClick))
                dataGridViewCell = rows[y].Cells[x];
              dataGridViewCell.OnLeaveInternal(y, blnThroughMouseClick);
            }
            if (blnValidateCurrentCell)
            {
              if (this.OnRowValidating(ref objDataGridViewCell, x, y))
              {
                if (!this.IsInnerCellOutOfBounds(x, y))
                {
                  this.OnRowEnter(ref objDataGridViewCell, x, y, true, true);
                  if (!this.IsInnerCellOutOfBounds(x, y))
                  {
                    dataGridViewCell.OnEnterInternal(y, blnThroughMouseClick);
                    this.OnCellEnter(ref objDataGridViewCell, x, y);
                  }
                }
                return false;
              }
              if (!this.IsInnerCellOutOfBounds(x, y))
                this.OnRowValidated(ref objDataGridViewCell, x, y);
            }
          }
          if (this.mobjCurrentCellPoint.X != -1)
          {
            this.mobjCurrentCellPoint.X = -1;
            this.mobjCurrentCellPoint.Y = -1;
            if (!blnClientSource)
              this.UpdateParams(AttributeType.Visual);
            this.OnCurrentCellChanged(EventArgs.Empty);
          }
          if (this.mobjDataGridViewState1[4194304])
          {
            if (editingControl != null)
            {
              if (this.mobjDataGridViewState2[536870912])
                this.mobjDataGridViewState2[536870912] = false;
              else
                control1 = this.CachedEditingControl = editingControl;
              Control control2 = this.EditingControl = (Control) null;
            }
          }
          else if (x >= 0)
          {
            if (!this.mobjDataGridViewOper[1048576])
            {
              if (x < this.Columns.Count && y < rows.Count && (this[x, y].ClientState | DataGridViewElementClientStates.CurrentCell) != DataGridViewElementClientStates.CurrentCell)
                this.InvalidateCellPrivate(x, y);
              if (this.RowHeadersVisible)
              {
                if (y < rows.Count)
                  this.InvalidateCellPrivate(-1, y);
              }
            }
          }
        }
      }
      finally
      {
        this.mobjDataGridViewOper[131072] = false;
      }
label_104:
      return true;
    }

    /// <summary>
    /// Determines whether [is shared cell visible] [the specified data grid view cell].
    /// </summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns>
    /// 	<c>true</c> if [is shared cell visible] [the specified data grid view cell]; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsSharedCellVisible(DataGridViewCell objDataGridViewCell, int intRowIndex) => (this.Rows.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None && objDataGridViewCell.OwningColumn != null && objDataGridViewCell.OwningColumn.Visible;

    /// <summary>Called when [row validated].</summary>
    /// <param name="objDataGridViewCell">The obj data grid view cell.</param>
    /// <param name="intColumnIndex">Index of the int column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    private void OnRowValidated(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex)
    {
      this.OnRowValidated(ref objDataGridViewCell, intColumnIndex, intRowIndex, false);
    }

    /// <summary>Called when [row validated].</summary>
    /// <param name="objDataGridViewCell">The obj data grid view cell.</param>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    private void OnRowValidated(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex,
      bool blnClientSource)
    {
      this.SetIsCurrentRowDirtyInternal(false, blnClientSource);
      this.mobjDataGridViewState1[2097152] = false;
      if (intRowIndex == this.NewRowIndex)
        this.InvalidateRowPrivate(intRowIndex);
      this.OnRowValidated(new DataGridViewCellEventArgs(intColumnIndex, intRowIndex));
      if (objDataGridViewCell == null)
        return;
      if (this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
        objDataGridViewCell = (DataGridViewCell) null;
      else
        objDataGridViewCell = this.Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
    }

    /// <summary>Called when [row validating].</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    private bool OnRowValidating(
      ref DataGridViewCell objDataGridViewCell,
      int intColumnIndex,
      int intRowIndex)
    {
      DataGridViewCellCancelEventArgs e = new DataGridViewCellCancelEventArgs(intColumnIndex, intRowIndex);
      this.OnRowValidating(e);
      if (!e.Cancel && this.DataConnection != null && this.DataConnection.InterestedInRowEvents && !this.DataConnection.PositionChangingOutsideDataGridView && !this.DataConnection.ListWasReset)
        this.DataConnection.OnRowValidating(e);
      DataGridViewRowCollection rows = this.Rows;
      if (objDataGridViewCell != null && intRowIndex < rows.Count && intColumnIndex < this.Columns.Count)
        objDataGridViewCell = rows.SharedRow(intRowIndex).Cells[intColumnIndex];
      return e.Cancel;
    }

    /// <summary>Exits the bulk paint.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    private void ExitBulkPaint(int intColumnIndex, int intRowIndex)
    {
      if (this.BulkPaintCount <= 0)
        return;
      --this.BulkPaintCount;
      if (this.BulkPaintCount != 0)
        return;
      if (intColumnIndex >= 0)
        this.InvalidateColumnInternal(intColumnIndex);
      else if (intRowIndex >= 0)
        this.InvalidateRowPrivate(intRowIndex);
      else
        this.Invalidate();
    }

    /// <summary>Invalidates the column internal.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    internal void InvalidateColumnInternal(int intColumnIndex)
    {
      if (!this.IsHandleCreated)
        return;
      this.Update();
    }

    /// <summary>Invalidates the row private.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    private void InvalidateRowPrivate(int intRowIndex)
    {
    }

    /// <summary>Sets the selected column core.</summary>
    /// <param name="intColumnIndex">The index of the column.</param>
    /// <param name="blnSelected">true to select the column; false to cancel the selection of the column.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than 0 or greater than the number of columns in the control minus 1.</exception>
    protected virtual void SetSelectedColumnCore(int intColumnIndex, bool blnSelected)
    {
      if (intColumnIndex < 0 || intColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("columnIndex");
      ++this.SelectionChangeCount;
      try
      {
        if (this.Columns[intColumnIndex].Selected != blnSelected)
        {
          if (blnSelected)
          {
            this.RemoveIndividuallySelectedCellsInColumn(intColumnIndex);
            this.Columns[intColumnIndex].SelectedInternal = true;
            this.SelectedBandIndexes.Add(intColumnIndex);
          }
          else
          {
            this.Columns[intColumnIndex].SelectedInternal = false;
            this.SelectedBandIndexes.Remove(intColumnIndex);
          }
        }
        else
        {
          if (blnSelected)
            return;
          this.RemoveIndividuallySelectedCellsInColumn(intColumnIndex);
        }
      }
      finally
      {
        --this.NoSelectionChangeCount;
      }
    }

    /// <summary>Removes the individually selected cells in column.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    private void RemoveIndividuallySelectedCellsInColumn(int intColumnIndex)
    {
      int index = 0;
      int num = 0;
      bool flag = false;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      while (index < individualSelectedCells.Count)
      {
        DataGridViewCell dataGridViewCell = individualSelectedCells[index];
        if (dataGridViewCell.ColumnIndex == intColumnIndex)
        {
          this.SetSelectedCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, false);
          ++num;
          if (num > 8)
          {
            flag = true;
            break;
          }
        }
        else
          ++index;
      }
      if (!flag)
        return;
      ++this.BulkPaintCount;
      try
      {
        while (index < individualSelectedCells.Count)
        {
          DataGridViewCell dataGridViewCell = individualSelectedCells[index];
          if (dataGridViewCell.ColumnIndex == intColumnIndex)
            this.SetSelectedCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, false);
          else
            ++index;
        }
      }
      finally
      {
        this.ExitBulkPaint(intColumnIndex, -1);
      }
    }

    /// <summary>Sets the selected row core.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnSelected">if set to <c>true</c> [selected].</param>
    protected virtual void SetSelectedRowCore(int intRowIndex, bool blnSelected) => this.SetSelectedRowCore(intRowIndex, blnSelected, false);

    private void SetSelectedRowCore(int intRowIndex, bool blnSelected, bool blnClientSource)
    {
      DataGridViewRowCollection rows = this.Rows;
      if (intRowIndex < 0 || intRowIndex >= rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      ++this.SelectionChangeCount;
      try
      {
        if ((rows.GetRowState(intRowIndex) & DataGridViewElementStates.Selected) != 0 != blnSelected)
        {
          if (blnSelected)
          {
            this.RemoveIndividuallySelectedCellsInRow(intRowIndex, blnClientSource);
            this.SelectedBandIndexes.Add(intRowIndex);
            rows.SetRowState(intRowIndex, DataGridViewElementStates.Selected, true);
          }
          else
          {
            this.SelectedBandIndexes.Remove(intRowIndex);
            rows.SetRowState(intRowIndex, DataGridViewElementStates.Selected, false);
          }
          if (blnClientSource)
            return;
          rows[intRowIndex].UpdateParams(AttributeType.Visual);
        }
        else
        {
          if (blnSelected)
            return;
          this.RemoveIndividuallySelectedCellsInRow(intRowIndex, blnClientSource);
        }
      }
      finally
      {
        --this.NoSelectionChangeCount;
      }
    }

    /// <summary>Gets or sets the auto size count.</summary>
    /// <value>The auto size count.</value>
    private int AutoSizeCount
    {
      get => this.mintAutoSizeCount;
      set => this.mintAutoSizeCount = value;
    }

    /// <summary>Gets or sets the no selection change count.</summary>
    /// <value>The no selection change count.</value>
    private int NoSelectionChangeCount
    {
      get => this.SelectionChangeCount;
      set
      {
        this.SelectionChangeCount = value;
        if (value != 0)
          return;
        this.FlushSelectionChanged();
      }
    }

    /// <summary>Flushes the selection changed.</summary>
    private void FlushSelectionChanged()
    {
      if (!this.mobjDataGridViewState2[262144])
        return;
      this.OnSelectionChanged(EventArgs.Empty);
    }

    private void RemoveIndividuallySelectedCellsInRow(int intRowIndex, bool blnClientSource)
    {
      int index = 0;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      while (index < individualSelectedCells.Count)
      {
        DataGridViewCell dataGridViewCell = individualSelectedCells[index];
        if (dataGridViewCell.RowIndex == intRowIndex)
          this.SetSelectedCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, false, blnClientSource);
        else
          ++index;
      }
    }

    /// <summary>Sorts the contents of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control using an implementation of the <see cref="T:System.Collections.IComparer"></see> interface.</summary>
    /// <param name="objComparer">An implementation of <see cref="T:System.Collections.IComparer"></see> that performs the custom sorting operation. </param>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> is set to true.-or- <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> is not null.</exception>
    /// <exception cref="T:System.ArgumentNullException">comparer is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Sort(IComparer objComparer)
    {
      if (objComparer == null)
        throw new ArgumentNullException("comparer");
      if (this.VirtualMode)
        throw new InvalidOperationException(SR.GetString("DataGridView_OperationDisabledInVirtualMode"));
      if (this.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotUseAComparerToSortDataGridViewWhenDataBound"));
      this.SortInternal(objComparer, (DataGridViewColumn) null, ListSortDirection.Ascending);
    }

    private void SortInternal(
      IComparer objComparer,
      DataGridViewColumn objDataGridViewColumn,
      ListSortDirection enmDirection)
    {
      DataGridView.DisplayedBandsData displayedBandsInfo = this.DisplayedBandsInfo;
      this.mobjCurrentCellCache.X = this.mobjCurrentCellPoint.X;
      this.mobjCurrentCellCache.Y = this.mobjCurrentCellPoint.Y;
      this.mobjDataGridViewOper[64] = true;
      try
      {
        if (!this.SetCurrentCellAddressCore(-1, -1, true, true, false))
          return;
        int displayedScrollingRow = displayedBandsInfo.FirstDisplayedScrollingRow;
        DataGridViewRowCollection rows = this.Rows;
        int rowCount = rows.GetRowCount(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
        if (rowCount > 0 && this.DataSource == null)
        {
          int firstRow = rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
          rows.SetRowState(firstRow, DataGridViewElementStates.Frozen, false);
        }
        if (this.SortedColumn != null && this.SortedColumn.SortMode == DataGridViewColumnSortMode.Automatic && this.SortedColumn.HasHeaderCell)
          this.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
        if (objComparer == null)
        {
          this.SortedColumn = objDataGridViewColumn;
          this.SortOrder = enmDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
          if (objDataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && objDataGridViewColumn.HasHeaderCell)
            objDataGridViewColumn.HeaderCell.SortGlyphDirection = this.SortOrder;
        }
        else
        {
          this.SortedColumn = (DataGridViewColumn) null;
          this.SortOrder = SortOrder.None;
        }
        if (this.DataSource == null)
        {
          this.UpdateRowsDisplayedState(false);
          rows.Sort(objComparer, enmDirection == ListSortDirection.Ascending);
        }
        else
        {
          this.SortDataBoundDataGridView_PerformCheck(objDataGridViewColumn);
          this.DataConnection.Sort(objDataGridViewColumn, enmDirection);
        }
        if (this.mobjCurrentCellCache.X != -1 && !this.IsInnerCellOutOfBounds(this.mobjCurrentCellCache.X, this.mobjCurrentCellCache.Y))
          this.SetAndSelectCurrentCellAddress(this.mobjCurrentCellCache.X, this.mobjCurrentCellCache.Y, true, false, false, false, false);
        if (rowCount > 0)
        {
          int num = rows.GetFirstRow(DataGridViewElementStates.Visible);
          for (; rowCount > 1; --rowCount)
            num = rows.GetNextRow(num, DataGridViewElementStates.Visible);
          rows.SetRowState(num, DataGridViewElementStates.Frozen, true);
        }
        displayedBandsInfo.FirstDisplayedScrollingRow = displayedScrollingRow;
      }
      finally
      {
        this.mobjDataGridViewOper[64] = false;
      }
      this.OnGlobalAutoSize();
      if (this.DataSource == null)
        displayedBandsInfo.EnsureDirtyState();
      this.ResetUIState(false, false);
      this.OnSorted(EventArgs.Empty);
    }

    /// <summary>Sorts the contents of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control in ascending or descending order based on the contents of the specified column.</summary>
    /// <param name="enmDirection">One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values. </param>
    /// <param name="objDataGridViewColumn">The column by which to sort the contents of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </param>
    /// <exception cref="T:System.ArgumentException">The specified column is not part of this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property has been set and the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.IsDataBound"></see> property of the specified column returns false.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property is set to true and the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.IsDataBound"></see> property of the specified column returns false.-or-The object specified by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property does not implement the <see cref="T:System.ComponentModel.IBindingList"></see> interface.-or-The object specified by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property has a <see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> property value of false.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Sort(
      DataGridViewColumn objDataGridViewColumn,
      ListSortDirection enmDirection)
    {
      if (objDataGridViewColumn == null)
        throw new ArgumentNullException("dataGridViewColumn");
      if (enmDirection != ListSortDirection.Ascending && enmDirection != ListSortDirection.Descending)
        throw new InvalidEnumArgumentException("direction", (int) enmDirection, typeof (ListSortDirection));
      if (objDataGridViewColumn.DataGridView != this)
        throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"));
      if (this.VirtualMode && !objDataGridViewColumn.IsDataBound)
        throw new InvalidOperationException(SR.GetString("DataGridView_OperationDisabledInVirtualMode"));
      this.mblnSuspendFilterInitialization = true;
      this.SortInternal((IComparer) null, objDataGridViewColumn, enmDirection);
      this.mblnSuspendFilterInitialization = false;
    }

    /// <summary>Forces the cell at the specified location to update its error text.</summary>
    /// <param name="intColumnIndex">The column index of the cell to update, or -1 to indicate a row header cell.</param>
    /// <param name="intRowIndex">The row index of the cell to update, or -1 to indicate a column header cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1 or greater than the number of columns in the control minus 1.- or -rowIndex is less than -1 or greater than the number of rows in the control minus 1.</exception>
    public void UpdateCellErrorText(int intColumnIndex, int intRowIndex)
    {
    }

    /// <summary>Forces the control to update its display of the cell at the specified location based on its new value, applying any automatic sizing modes currently in effect. </summary>
    /// <param name="intColumnIndex">The zero-based column index of the cell with the new value.</param>
    /// <param name="intRowIndex">The zero-based row index of the cell with the new value.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than zero or greater than the number of columns in the control minus one.-or-rowIndex is less than zero or greater than the number of rows in the control minus one.</exception>
    public void UpdateCellValue(int intColumnIndex, int intRowIndex)
    {
    }

    /// <summary>Forces the row at the given row index to update its error text.</summary>
    /// <param name="intRowIndex">The zero-based index of the row to update.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows in the control minus 1.</exception>
    public void UpdateRowErrorText(int intRowIndex)
    {
    }

    /// <summary>Forces the rows in the given range to update their error text.</summary>
    /// <param name="intRowIndexStart">The zero-based index of the first row in the set of rows to update.</param>
    /// <param name="intRowIndexEnd">The zero-based index of the last row in the set of rows to update.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndexStart is not in the valid range of 0 to the number of rows in the control minus 1.-or-rowIndexEnd is not in the valid range of 0 to the number of rows in the control minus 1.-or-rowIndexEnd is less than rowIndexStart.</exception>
    public void UpdateRowErrorText(int intRowIndexStart, int intRowIndexEnd)
    {
    }

    /// <summary>Forces the specified row or rows to update their height information.</summary>
    /// <param name="intRowIndex">The zero-based index of the first row to update.</param>
    /// <param name="blnUpdateToEnd">true to update the specified row and all subsequent rows.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 and updateToEnd is true.- or -rowIndex is less than -1 and updateToEnd is false.- or -rowIndex is greater than the highest row index in the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.Rows"></see> collection.</exception>
    public void UpdateRowHeightInfo(int intRowIndex, bool blnUpdateToEnd) => this.UpdateRowHeightInfoPrivate(intRowIndex, blnUpdateToEnd, true);

    private void UpdateRowHeightInfoPrivate(
      int intRowIndex,
      bool blnUpdateToEnd,
      bool blnInvalidInAdjustFillingColumns)
    {
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is hierarchic.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is hierarchic; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool ExpansionIndicatorColumnVisible
    {
      get => this.IsHierarchic(HierarchicInfoSelector.Any);
      set
      {
        if (this.mblnShowExpansionIndicator == value)
          return;
        this.mblnShowExpansionIndicator = value;
        this.Update();
      }
    }

    /// <summary>
    /// Determines whether the datagridview is hierarchic, according to selector.
    /// </summary>
    /// <param name="enmHierarchicInfoSelector">The hierarchicinfo selector.</param>
    /// <returns>
    ///   <c>true</c> if the datagridview is hierarchic; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsHierarchic(HierarchicInfoSelector enmHierarchicInfoSelector)
    {
      switch (enmHierarchicInfoSelector)
      {
        case HierarchicInfoSelector.Any:
          return this.mobjHierarchicInfos != null && this.mobjHierarchicInfos.Count > 0 || this.mobjSystemHierarchicInfos != null && this.mobjSystemHierarchicInfos.Count > 0 || this.mblnShowExpansionIndicator;
        case HierarchicInfoSelector.System:
          return this.mobjSystemHierarchicInfos != null && this.mobjSystemHierarchicInfos.Count > 0;
        case HierarchicInfoSelector.Public:
          return this.mobjHierarchicInfos != null && this.mobjHierarchicInfos.Count > 0;
        case HierarchicInfoSelector.Bounded:
          if (this.mobjHierarchicInfos != null && this.mobjHierarchicInfos.Count > 0)
            return true;
          return this.mobjSystemHierarchicInfos != null && this.mobjSystemHierarchicInfos.Count > 0;
        default:
          throw new NotImplementedException();
      }
    }

    /// <summary>Gets the relevant hierarchic infos.</summary>
    /// <returns></returns>
    public ObservableCollection<HierarchicInfo> GetRelevantHierarchicInfos() => this.SystemHierarchicInfos.Count > 0 ? this.SystemHierarchicInfos : this.HierarchicInfos;

    /// <summary>
    /// API for rows to notify that they have created a child grid view
    /// </summary>
    /// <param name="objCreatedGrid">The obj created grid.</param>
    internal void NotifyHierarchicGridCreated(HierarchicDataGridView objCreatedGrid) => this.OnHierarchicGridCreated(objCreatedGrid);

    /// <summary>Called when [hierarchic grid created].</summary>
    /// <param name="objCreatedGrid">The obj created grid.</param>
    private void OnHierarchicGridCreated(HierarchicDataGridView objCreatedGrid)
    {
      if (!(this.GetHandler(DataGridView.EVENT_HIERARCHICGRIDCREATED) is HierarchicDataGridViewCreatedEventHandler handler))
        return;
      handler((object) this, new HierarchicDataGridViewCreatedEventArgs(objCreatedGrid));
    }

    /// <summary>
    /// Called when [column chooser columns visibility changed].
    /// </summary>
    /// <param name="objChangedColumnsVisibility">The obj changed columns visibility.</param>
    internal void OnColumnChooserColumnsVisibilityChanged(
      List<DataGridViewColumn> objChangedColumnsVisibility)
    {
      if (objChangedColumnsVisibility.Count <= 0 || !(this.GetHandler(DataGridView.EVENT_COLUMNCHOOSERCOLUMNSVISIBILITYCHANGED) is ColumnChooserColumnsVisibilityChangedHandler handler))
        return;
      handler((object) this, new ColumnChooserColumnsVisibilityChangedEventArgs(objChangedColumnsVisibility));
    }

    /// <summary>
    /// Raises the <see cref="E:RowExpanding" /> event.
    /// </summary>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Forms.RowExpandingEventArgs" /> instance containing the event data.</param>
    internal void OnRowExpanding(RowExpandingEventArgs objArgs)
    {
      if (!(this.GetHandler(DataGridView.EVENT_ROWEXPANDING) is RowExpandingEventHandler handler))
        return;
      handler((object) this, objArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:RowExpanded" /> event.
    /// </summary>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Forms.RowExpandedEventArgs" /> instance containing the event data.</param>
    internal void OnRowExpanded(RowExpandedEventArgs objArgs)
    {
      if (!(this.GetHandler(DataGridView.EVENT_ROWEXPANDED) is RowExpandedEventHandler handler))
        return;
      handler((object) this, objArgs);
    }

    /// <summary>Called when [row collapsed].</summary>
    /// <param name="objRow">The obj row.</param>
    internal void OnRowCollapsed(DataGridViewRow objRow)
    {
      if (!(this.GetHandler(DataGridView.EVENT_ROWCOLLAPSED) is RowCollapsedEventHandler handler))
        return;
      handler((object) objRow, new RowCollapsedEventArgs(objRow));
    }

    /// <summary>Called when [row collapsing].</summary>
    /// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.RowCollapsingEventArgs" /> instance containing the event data.</param>
    internal void OnRowCollapsing(RowCollapsingEventArgs objEventArgs)
    {
      if (!(this.GetHandler(DataGridView.EVENT_ROWCOLLAPSING) is RowCollapsingEventHandler handler))
        return;
      handler((object) objEventArgs.CollapsingRow, objEventArgs);
    }

    /// <summary>
    /// Gets the cloned binding source with filter for next level.
    /// </summary>
    /// <param name="objRow">The obj row.</param>
    /// <returns></returns>
    internal BindingSource GetClonedBindingSourceWithFilterForNextLevel(DataGridViewRow objRow)
    {
      ObservableCollection<HierarchicInfo> relevantHierarchicInfos = this.GetRelevantHierarchicInfos();
      if (relevantHierarchicInfos.Count > 0)
      {
        BindingSource filterForNextLevel = DataGridView.CloneBindingSource(relevantHierarchicInfos[0]);
        string filterForRowChildGrid = this.GetFilterForRowChildGrid(objRow);
        if (!string.IsNullOrEmpty(filterForRowChildGrid))
        {
          filterForNextLevel.Filter = filterForRowChildGrid;
          return filterForNextLevel;
        }
      }
      return (BindingSource) null;
    }

    /// <summary>Clones the binding source.</summary>
    /// <param name="objNextInfoLevel">The obj next info level.</param>
    /// <returns></returns>
    private static BindingSource CloneBindingSource(HierarchicInfo objNextInfoLevel)
    {
      BindingSource bindingSource1 = objNextInfoLevel.BindedSource.Clone() as BindingSource;
      BindingSource bindingSource2 = bindingSource1;
      for (BindingSource dataSource = bindingSource1.DataSource as BindingSource; dataSource != null; dataSource = dataSource.DataSource as BindingSource)
        bindingSource2 = dataSource;
      if (bindingSource2.DataSource is DataTable dataSource1)
        bindingSource2.DataSource = (object) new DataView(dataSource1);
      return bindingSource1;
    }

    /// <summary>Gets the filter for row child grid.</summary>
    /// <param name="objRow">The obj row.</param>
    /// <returns></returns>
    internal string GetFilterForRowChildGrid(DataGridViewRow objRow)
    {
      ObservableCollection<HierarchicInfo> relevantHierarchicInfos = this.GetRelevantHierarchicInfos();
      if (relevantHierarchicInfos.Count <= 0)
        return string.Empty;
      HierarchicInfo objNextInfoLevel = relevantHierarchicInfos[0];
      if (string.IsNullOrEmpty(this.mstrFilterTemplate))
        this.mstrFilterTemplate = this.GetFilterTemplate(objNextInfoLevel);
      return string.Format(this.mstrFilterTemplate, (object[]) this.CreateRowFilterValueList(objRow, (IList<string>) objNextInfoLevel.Keys));
    }

    /// <summary>Creates the row filter value list.</summary>
    /// <param name="objRow">The obj row.</param>
    /// <param name="objFilteringDataMembers">The obj filtering data members.</param>
    /// <returns></returns>
    private string[] CreateRowFilterValueList(
      DataGridViewRow objRow,
      IList<string> objFilteringDataMembers)
    {
      int num = 0;
      string[] rowFilterValueList = new string[objFilteringDataMembers.Count];
      foreach (string filteringDataMember in (IEnumerable<string>) objFilteringDataMembers)
      {
        if (!this.RealFilteringDataMemberIndexByProposedFilteringDataMember.ContainsKey(filteringDataMember))
          this.CreateRealDataMemberForProposedMember(filteringDataMember);
        object obj = objRow.Cells[this.RealFilteringDataMemberIndexByProposedFilteringDataMember[filteringDataMember]].Value;
        string str;
        switch (obj)
        {
          case null:
          case DBNull _:
            str = "IS NULL";
            break;
          default:
            string strComparisionValue = obj.ToString();
            str = string.Format("= {0}", (object) this.GetQueryComparisionValue(obj.GetType(), strComparisionValue));
            break;
        }
        rowFilterValueList[num++] = str;
      }
      return rowFilterValueList;
    }

    /// <summary>
    /// Creates the real data member from the proposed member.
    /// </summary>
    /// <param name="strFilteringDataMember">The STR filtering data member.</param>
    private void CreateRealDataMemberForProposedMember(string strFilteringDataMember)
    {
      string forProposedMember = this.Columns.GetRealDataMemberForProposedMember(strFilteringDataMember);
      if (string.IsNullOrEmpty(forProposedMember))
        throw new Exception("The grid does not contain a columns with the given filter data member name: Given name - '" + strFilteringDataMember + "'");
      this.RealFilteringDataMemberIndexByProposedFilteringDataMember.Add(strFilteringDataMember, forProposedMember);
    }

    /// <summary>Creates a template for the filter field</summary>
    /// <param name="objCurrentInfoLevel">The obj current info level.</param>
    /// <param name="objNextInfoLevel">The obj next info level.</param>
    /// <returns></returns>
    private string GetFilterTemplate(HierarchicInfo objNextInfoLevel)
    {
      int num = 0;
      string str = string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      foreach (FilterRelation filteringDataMember in (Collection<FilterRelation>) objNextInfoLevel.FilteringDataMembers)
      {
        stringBuilder.Append(str);
        stringBuilder.Append("[");
        stringBuilder.Append(filteringDataMember.TargetColumnDataName);
        stringBuilder.Append("]");
        stringBuilder.Append(" ");
        stringBuilder.Append("{");
        stringBuilder.Append(num++);
        stringBuilder.Append("}");
        str = " AND ";
      }
      return stringBuilder.ToString();
    }

    /// <summary>Removes the grouping column.</summary>
    /// <param name="strColumnDataPropertyName">Name of the STR column data property.</param>
    private void RemoveGroupingColumn(string strColumnDataPropertyName) => this.GroupingColumns.Remove(strColumnDataPropertyName);

    /// <summary>Inserts the grouping column.</summary>
    /// <param name="strTargetDataPropertyName">Name of the STR target data property.</param>
    /// <param name="strDraggedDataPropertyName">Name of the STR dragged data property.</param>
    internal void InsertGroupingColumn(
      string strTargetDataPropertyName,
      string strDraggedDataPropertyName)
    {
      if (!string.IsNullOrEmpty(strTargetDataPropertyName))
      {
        if (this.GroupingColumns.Contains(strDraggedDataPropertyName) || !this.GroupingColumns.Contains(strTargetDataPropertyName))
          return;
        this.GroupingColumns.Insert(this.GroupingColumns.IndexOf(strTargetDataPropertyName) + 1, strDraggedDataPropertyName);
      }
      else
      {
        if (this.GroupingColumns.Contains(strDraggedDataPropertyName))
          return;
        this.GroupingColumns.Insert(0, strDraggedDataPropertyName);
      }
    }

    /// <summary>Adds or removes datagroups events.</summary>
    /// <param name="blnIsAdd">if set to <c>true</c> [BLN is add].</param>
    private void AddRemoveGroupingColumnEvents(bool blnIsAdd)
    {
      if (blnIsAdd)
        this.mobjGroupingColumns.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnGroupingColumnsCollectionChanged);
      else
        this.mobjGroupingColumns.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.OnGroupingColumnsCollectionChanged);
    }

    /// <summary>Called when [grouping columns collection changed].</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
    private void OnGroupingColumnsCollectionChanged(
      object sender,
      NotifyCollectionChangedEventArgs e)
    {
      this.Update();
      if (e.Action == NotifyCollectionChangedAction.Remove && !this.AutoGenerateColumns && this.HideGroupedColumns)
      {
        string oldItem = e.OldItems[0] as string;
        if (!string.IsNullOrEmpty(oldItem))
        {
          DataGridViewColumnCollection columns = this.Columns;
          string forProposedMember = columns.GetRealDataMemberForProposedMember(oldItem);
          if (!string.IsNullOrEmpty(forProposedMember) && columns[forProposedMember] != null)
            columns[forProposedMember].Visible = true;
        }
      }
      this.SwitchPreRenderUpdate(DataGridView.PreRenderUpdateType.GroupingData);
    }

    /// <summary>Switches the prerender update flag.</summary>
    /// <param name="enmPreRenderUpdateType">The enm update params.</param>
    internal void SwitchPreRenderUpdate(
      DataGridView.PreRenderUpdateType enmPreRenderUpdateType)
    {
      if (enmPreRenderUpdateType > DataGridView.PreRenderUpdateType.None)
        this.menmPreRenderUpdateTypes |= enmPreRenderUpdateType;
      else
        this.menmPreRenderUpdateTypes &= enmPreRenderUpdateType;
    }

    /// <summary>
    /// Determines whether the specified prerender update type is dirty.
    /// </summary>
    /// <param name="enmPreRenderUpdateType">The prerender update type.</param>
    /// <returns>
    ///   <c>true</c> if the specified prerender update type dirty; otherwise, <c>false</c>.
    /// </returns>
    private bool ShouldPreRenderUpdate(
      DataGridView.PreRenderUpdateType enmPreRenderUpdateType)
    {
      return (this.menmPreRenderUpdateTypes & enmPreRenderUpdateType) != 0;
    }

    /// <summary>Initializes the system hierarchic infos.</summary>
    private void InitializeSystemHierarchicInfos()
    {
      if (!(this.DataSource is BindingSource dataSource))
        return;
      this.SystemHierarchicInfos.Clear();
      for (int index1 = 0; index1 < this.GroupingColumns.Count; ++index1)
      {
        HierarchicInfo hierarchicInfo = new HierarchicInfo();
        hierarchicInfo.BindedSource = dataSource;
        for (int index2 = 0; index2 <= index1; ++index2)
          hierarchicInfo.FilteringDataMembers.Add(new FilterRelation()
          {
            SourceColumnDataName = this.GroupingColumns[index2],
            TargetColumnDataName = this.GroupingColumns[index2]
          });
        this.SystemHierarchicInfos.Add(hierarchicInfo);
      }
    }

    /// <summary>Called when [group header formatting].</summary>
    /// <param name="objCurrentCell">The obj current cell.</param>
    /// <param name="strDataPropertyName">Name of the STR data property.</param>
    /// <param name="strCurrentValue">The STR current value.</param>
    /// <param name="intCount">The int count.</param>
    /// <returns></returns>
    internal GroupHeaderFormattingEventArgs OnGroupHeaderFormatting(
      Label objHeaderLabel,
      string strDataPropertyName,
      string strCurrentValue,
      int intCount,
      DataGridViewRow objOwningRow)
    {
      GroupHeaderFormattingEventArgs e = new GroupHeaderFormattingEventArgs(objHeaderLabel, strDataPropertyName, intCount, strCurrentValue, objOwningRow);
      this.OnGroupHeaderFormatting(this, e);
      return e;
    }

    /// <summary>
    /// Raises the <see cref="E:GroupHeaderFormatting" /> event.
    /// </summary>
    /// <param name="objCell">The obj cell.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.GroupHeaderFormattingEventArgs" /> instance containing the event data.</param>
    private void OnGroupHeaderFormatting(
      DataGridView objDataGridView,
      GroupHeaderFormattingEventArgs e)
    {
      if (this.GroupHeaderFormattingHandler == null)
        return;
      this.GroupHeaderFormattingHandler((object) objDataGridView, e);
    }

    /// <summary>Formats the group header.</summary>
    /// <param name="objCurrentCell">The obj current cell.</param>
    /// <param name="strDataPropertyName">Name of the STR data property.</param>
    /// <param name="strCurrentValue">The STR current value.</param>
    /// <param name="intCount">The int count.</param>
    private void FormatGroupHeader(
      DataGridViewCell objCurrentCell,
      int intVisibleColumnsCount,
      string strDataPropertyName,
      string strCurrentValue,
      BindingSource objRowBindingSource)
    {
      DataGridViewRow owningRow = objCurrentCell.OwningRow;
      if (owningRow == null)
        return;
      objCurrentCell.Panel.Controls.Clear();
      objCurrentCell.Rowspan = 1;
      objCurrentCell.Colspan = intVisibleColumnsCount;
      DataGridViewGroupingHeader objValue = new DataGridViewGroupingHeader(strDataPropertyName, strCurrentValue, objRowBindingSource, owningRow);
      objValue.Dock = DockStyle.Fill;
      objCurrentCell.Panel.Controls.Add((Control) objValue);
    }

    /// <summary>Called when [cell context menu needed].</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objContextMenu">The context menu.</param>
    /// <returns></returns>
    internal ContextMenu OnCellContextMenuNeeded(
      int intColumnIndex,
      int intRowIndex,
      ContextMenu objContextMenu)
    {
      DataGridViewCellContextMenuNeededEventArgs e = new DataGridViewCellContextMenuNeededEventArgs(intColumnIndex, intRowIndex, objContextMenu);
      this.OnCellContextMenuNeeded(e);
      return e.ContextMenu;
    }

    /// <summary>Called when [cell context menu strip needed].</summary>
    /// <param name="columnIndex">Index of the column.</param>
    /// <param name="rowIndex">Index of the row.</param>
    /// <param name="contextMenuStrip">The context menu strip.</param>
    /// <returns></returns>
    internal ContextMenuStrip OnCellContextMenuStripNeeded(
      int columnIndex,
      int rowIndex,
      ContextMenuStrip contextMenuStrip)
    {
      DataGridViewCellContextMenuStripNeededEventArgs e = new DataGridViewCellContextMenuStripNeededEventArgs(columnIndex, rowIndex, contextMenuStrip);
      this.OnCellContextMenuStripNeeded(e);
      return e.ContextMenuStrip;
    }

    /// <summary>
    /// Raises the <see cref="E:CellContextMenuStripNeeded" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellContextMenuStripNeededEventArgs" /> instance containing the event data.</param>
    internal virtual void OnCellContextMenuStripNeeded(
      DataGridViewCellContextMenuStripNeededEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCONTEXTMENUSTRIPNEEDED) is DataGridViewCellContextMenuStripNeededEventHandler handler) || this.IsDisposed)
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuStripNeeded"></see> event. </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellContextMenuNeeded(DataGridViewCellContextMenuNeededEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLCONTEXTMENUNEEDED) is DataGridViewCellContextMenuNeededEventHandler handler) || this.IsDisposed)
        return;
      handler((object) this, e);
    }

    /// <summary>Called when [row context menu needed].</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objContextMenu">The context menu.</param>
    /// <returns></returns>
    internal ContextMenu OnRowContextMenuNeeded(int intRowIndex, ContextMenu objContextMenu)
    {
      DataGridViewRowContextMenuNeededEventArgs e = new DataGridViewRowContextMenuNeededEventArgs(intRowIndex, objContextMenu);
      this.OnRowContextMenuNeeded(e);
      return e.ContextMenu;
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.RowContextMenuStripNeeded"></see> event. </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventArgs"></see> that contains the event data. </param>
    protected virtual void OnRowContextMenuNeeded(DataGridViewRowContextMenuNeededEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWROWCONTEXTMENUNEEDED) is DataGridViewRowContextMenuNeededEventHandler handler) || this.IsDisposed)
        return;
      handler((object) this, e);
    }

    /// <summary>Called when [band context menu strip changed].</summary>
    /// <param name="objDataGridViewBand">The data grid view band.</param>
    internal void OnBandContextMenuChanged(DataGridViewBand objDataGridViewBand)
    {
      if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
        this.OnColumnContextMenuStripChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
      else
        this.OnRowContextMenuChanged(new DataGridViewRowEventArgs((DataGridViewRow) objDataGridViewBand));
    }

    /// <summary>Called when [band context menu strip changed].</summary>
    /// <param name="dataGridViewBand">The data grid view band.</param>
    internal void OnBandContextMenuStripChanged(DataGridViewBand dataGridViewBand)
    {
      if (dataGridViewBand is DataGridViewColumn objDataGridViewColumn)
        this.OnColumnContextMenuStripChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
      else
        this.OnRowContextMenuStripChanged(new DataGridViewRowEventArgs((DataGridViewRow) dataGridViewBand));
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.RowContextMenuStripChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:System.Windows.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:System.Windows.Forms.DataGridView"></see> control.</exception>
    protected virtual void OnRowContextMenuChanged(DataGridViewRowEventArgs e)
    {
      if (e.Row.DataGridView != this)
        throw new ArgumentException(SR.GetString("DataGridView_RowDoesNotBelongToDataGridView"), "e.Row");
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWROWCONTEXTMENUCHANGED) is DataGridViewRowEventHandler handler) || this.IsDisposed)
        return;
      handler((object) this, e);
    }

    internal void OnAddingColumn(DataGridViewColumn objDataGridViewColumn)
    {
      if (objDataGridViewColumn == null)
        throw new ArgumentNullException("dataGridViewColumn");
      if (objDataGridViewColumn.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridView_ColumnAlreadyBelongsToDataGridView"));
      if (!this.InInitialization && objDataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && (this.SelectionMode == DataGridViewSelectionMode.FullColumnSelect || this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
        throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", (object) DataGridViewColumnSortMode.Automatic.ToString(), (object) this.SelectionMode.ToString()));
      if (objDataGridViewColumn.Visible)
      {
        if (!this.ColumnHeadersVisible && (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader || objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && this.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader))
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoSizedColumn"));
        if (objDataGridViewColumn.Frozen && (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && this.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill))
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoFillColumn"));
        this.mobjDataGridViewState2[67108864] = true;
      }
      if ((double) this.Columns.GetColumnsFillWeight(DataGridViewElementStates.None) + (double) objDataGridViewColumn.FillWeight > (double) ushort.MaxValue)
        throw new InvalidOperationException(SR.GetString("DataGridView_WeightSumCannotExceedLongMaxValue", (object) ((int) ushort.MaxValue).ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      this.CorrectColumnFrozenState(objDataGridViewColumn, this.Columns.Count);
      DataGridViewRowCollection rows = this.Rows;
      if (rows.Count <= 0)
        return;
      if (objDataGridViewColumn.CellType == (Type) null)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddUntypedColumn"));
      if (objDataGridViewColumn.CellTemplate.DefaultNewRowValue != null && this.NewRowIndex != -1)
      {
        DataGridViewRow dataGridViewRow1 = rows[this.NewRowIndex];
      }
      int num = this.Columns.Count + 1;
      try
      {
        for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
        {
          DataGridViewRow dataGridViewRow2 = rows.SharedRow(intRowIndex);
          if (dataGridViewRow2.Cells.Count < num)
          {
            DataGridViewCell objDataGridViewCell = (DataGridViewCell) objDataGridViewColumn.CellTemplate.Clone();
            dataGridViewRow2.Cells.AddInternal(objDataGridViewCell);
            if (intRowIndex == this.NewRowIndex)
              objDataGridViewCell.SetValueInternal(intRowIndex, objDataGridViewCell.DefaultNewRowValue);
            objDataGridViewCell.DataGridViewInternal = this;
            objDataGridViewCell.OwningRowInternal = dataGridViewRow2;
            objDataGridViewCell.OwningColumnInternal = objDataGridViewColumn;
          }
        }
      }
      catch
      {
        for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
        {
          DataGridViewRow dataGridViewRow3 = rows.SharedRow(intRowIndex);
          if (dataGridViewRow3.Cells.Count == num)
            dataGridViewRow3.Cells.RemoveAtInternal(num - 1);
          else
            break;
        }
        throw;
      }
    }

    private void CorrectColumnFrozenState(
      DataGridViewColumn objDataGridViewColumn,
      int intAnticipatedColumnIndex)
    {
      int num = objDataGridViewColumn.DisplayIndex == -1 || objDataGridViewColumn.DisplayIndex > this.Columns.Count ? intAnticipatedColumnIndex : objDataGridViewColumn.DisplayIndex;
      int intDisplayIndex1 = num - 1;
      DataGridViewColumn columnAtDisplayIndex1;
      do
      {
        columnAtDisplayIndex1 = this.Columns.GetColumnAtDisplayIndex(intDisplayIndex1);
        --intDisplayIndex1;
      }
      while (intDisplayIndex1 >= 0 && (columnAtDisplayIndex1 == null || !columnAtDisplayIndex1.Visible));
      if (columnAtDisplayIndex1 != null && !columnAtDisplayIndex1.Frozen && objDataGridViewColumn.Frozen)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddFrozenColumn"));
      int intDisplayIndex2 = num;
      DataGridViewColumn columnAtDisplayIndex2;
      do
      {
        columnAtDisplayIndex2 = this.Columns.GetColumnAtDisplayIndex(intDisplayIndex2);
        ++intDisplayIndex2;
      }
      while (intDisplayIndex2 < this.Columns.Count && (columnAtDisplayIndex2 == null || !columnAtDisplayIndex2.Visible));
      if (columnAtDisplayIndex2 != null && columnAtDisplayIndex2.Frozen && !objDataGridViewColumn.Frozen)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddNonFrozenColumn"));
    }

    private void CorrectColumnFrozenStates(DataGridViewColumn[] arrDataGridViewColumns)
    {
      DataGridView dataGridView = new DataGridView();
      foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
      {
        DataGridViewColumn objDataGridViewColumn = (DataGridViewColumn) column.Clone();
        objDataGridViewColumn.DisplayIndex = column.DisplayIndex;
        dataGridView.Columns.Add(objDataGridViewColumn);
      }
      foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
      {
        DataGridViewColumn objDataGridViewColumn = (DataGridViewColumn) dataGridViewColumn.Clone();
        objDataGridViewColumn.DisplayIndex = dataGridViewColumn.DisplayIndex;
        dataGridView.Columns.Add(objDataGridViewColumn);
      }
    }

    private void CorrectRowFrozenState(
      DataGridViewRow objDataGridViewRow,
      DataGridViewElementStates enmRowState,
      int intAnticipatedRowIndex)
    {
      DataGridViewRowCollection rows = this.Rows;
      int previousRow = rows.GetPreviousRow(intAnticipatedRowIndex, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
      if (previousRow != -1 && (rows.GetRowState(previousRow) & DataGridViewElementStates.Frozen) == DataGridViewElementStates.None && (enmRowState & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddFrozenRow"));
      int nextRow = rows.GetNextRow(previousRow == -1 ? intAnticipatedRowIndex - 1 : previousRow, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
      if (nextRow != -1 && (rows.GetRowState(nextRow) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None && (enmRowState & DataGridViewElementStates.Frozen) == DataGridViewElementStates.None)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddNonFrozenRow"));
    }

    internal void OnAddingColumns(DataGridViewColumn[] arrDataGridViewColumns)
    {
      float columnsFillWeight = this.Columns.GetColumnsFillWeight(DataGridViewElementStates.None);
      DataGridViewRowCollection rows = this.Rows;
      foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
      {
        if (dataGridViewColumn == null)
          throw new InvalidOperationException(SR.GetString("DataGridView_AtLeastOneColumnIsNull"));
        if (dataGridViewColumn.DataGridView != null)
          throw new InvalidOperationException(SR.GetString("DataGridView_ColumnAlreadyBelongsToDataGridView"));
        if (rows.Count > 0 && dataGridViewColumn.CellType == (Type) null)
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddUntypedColumn"));
        if (!this.InInitialization && dataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && (this.SelectionMode == DataGridViewSelectionMode.FullColumnSelect || this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", (object) DataGridViewColumnSortMode.Automatic.ToString(), (object) this.SelectionMode.ToString()));
        if (dataGridViewColumn.Visible)
        {
          if (!this.ColumnHeadersVisible && (dataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader || dataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && this.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader))
            throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoSizedColumn"));
          if (dataGridViewColumn.Frozen && (dataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || dataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && this.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill))
            throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoFillColumn"));
          this.mobjDataGridViewState2[67108864] = true;
        }
        columnsFillWeight += dataGridViewColumn.FillWeight;
        if ((double) columnsFillWeight > (double) ushort.MaxValue)
          throw new InvalidOperationException(SR.GetString("DataGridView_WeightSumCannotExceedLongMaxValue", (object) ((int) ushort.MaxValue).ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      }
      int length = arrDataGridViewColumns.Length;
      for (int index1 = 0; index1 < length - 1; ++index1)
      {
        for (int index2 = index1 + 1; index2 < length; ++index2)
        {
          if (arrDataGridViewColumns[index1] == arrDataGridViewColumns[index2])
            throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddIdenticalColumns"));
        }
      }
      this.CorrectColumnFrozenStates(arrDataGridViewColumns);
      if (rows.Count <= 0)
        return;
      foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
      {
        if (dataGridViewColumn.CellTemplate.DefaultNewRowValue != null && this.NewRowIndex != -1)
        {
          DataGridViewRow dataGridViewRow = rows[this.NewRowIndex];
          break;
        }
      }
      int count = this.Columns.Count;
      int num = 0;
      try
      {
        foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
        {
          ++num;
          for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
          {
            DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
            if (dataGridViewRow.Cells.Count < count + num)
            {
              DataGridViewCell objDataGridViewCell = (DataGridViewCell) dataGridViewColumn.CellTemplate.Clone();
              dataGridViewRow.Cells.AddInternal(objDataGridViewCell);
              if (intRowIndex == this.NewRowIndex)
              {
                DataGridViewCell dataGridViewCell = objDataGridViewCell;
                dataGridViewCell.Value = dataGridViewCell.DefaultNewRowValue;
              }
              objDataGridViewCell.DataGridViewInternal = this;
              objDataGridViewCell.OwningRowInternal = dataGridViewRow;
              objDataGridViewCell.OwningColumnInternal = dataGridViewColumn;
            }
          }
        }
      }
      catch
      {
        for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
        {
          DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
          while (dataGridViewRow.Cells.Count > count)
            dataGridViewRow.Cells.RemoveAtInternal(dataGridViewRow.Cells.Count - 1);
        }
        throw;
      }
    }

    /// <summary>Called when [clearing columns].</summary>
    internal void OnClearingColumns()
    {
      this.CurrentCell = (DataGridViewCell) null;
      this.Rows.ClearInternal(false);
      this.SortedColumn = (DataGridViewColumn) null;
      this.SortOrder = SortOrder.None;
    }

    /// <summary>Called when [column hidden].</summary>
    /// <param name="objDataGridViewColumn">The data grid view column.</param>
    internal void OnColumnHidden(DataGridViewColumn objDataGridViewColumn)
    {
      if (!objDataGridViewColumn.Displayed)
        return;
      objDataGridViewColumn.DisplayedInternal = false;
      this.OnColumnStateChanged(new DataGridViewColumnStateChangedEventArgs(objDataGridViewColumn, DataGridViewElementStates.Displayed));
    }

    /// <summary>Called when [inserted column_ pre notification].</summary>
    /// <param name="objDataGridViewColumn">The data grid view column.</param>
    internal void OnInsertedColumn_PreNotification(DataGridViewColumn objDataGridViewColumn)
    {
      this.DisplayedBandsInfo.CorrectColumnIndexAfterInsertion(objDataGridViewColumn.Index, 1);
      this.CorrectColumnIndexesAfterInsertion(objDataGridViewColumn, 1);
      this.OnAddedColumn(objDataGridViewColumn);
    }

    /// <summary>Called when [inserted column_ post notification].</summary>
    /// <param name="objNewCurrentCell">The new current cell.</param>
    internal void OnInsertedColumn_PostNotification(Point objNewCurrentCell)
    {
      if (objNewCurrentCell.X == -1)
        return;
      this.SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, true, false, false, false, this.Columns.GetColumnCount(DataGridViewElementStates.Visible) == 1);
    }

    /// <summary>Corrects the column indexes after insertion.</summary>
    /// <param name="objDataGridViewColumn">The data grid view column.</param>
    /// <param name="intInsertionCount">The insertion count.</param>
    private void CorrectColumnIndexesAfterInsertion(
      DataGridViewColumn objDataGridViewColumn,
      int intInsertionCount)
    {
      for (int index = objDataGridViewColumn.Index + intInsertionCount; index < this.Columns.Count; ++index)
        this.Columns[index].IndexInternal = index;
    }

    /// <summary>Called when [removed column_ post notification].</summary>
    /// <param name="objDataGridViewColumn">The data grid view column.</param>
    /// <param name="objNewCurrentCell">The new current cell.</param>
    internal void OnRemovedColumn_PostNotification(
      DataGridViewColumn objDataGridViewColumn,
      Point objNewCurrentCell)
    {
      if (objNewCurrentCell.X != -1)
        this.SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, true, false, false, false, false);
      this.FlushSelectionChanged();
      this.OnColumnHidden(objDataGridViewColumn);
    }

    /// <summary>
    /// Called when [column collection changed_ post notification].
    /// </summary>
    /// <param name="objDataGridViewColumn">The data grid view column.</param>
    internal void OnColumnCollectionChanged_PostNotification(
      DataGridViewColumn objDataGridViewColumn)
    {
      if (this.Columns.Count == 0 || this.Rows.Count != 0)
        return;
      if (this.DataSource != null && !this.mobjDataGridViewOper[1024])
      {
        this.RefreshRows(true);
      }
      else
      {
        if (!this.AllowUserToAddRowsInternal)
          return;
        this.AddNewRow(false);
      }
    }

    /// <summary>Initializes the filter row.</summary>
    private void InitializeFilterRow()
    {
      BindingSource dataSource = this.DataSource as BindingSource;
      if (this.mobjDataGridViewFilterRow == null)
      {
        this.mobjDataGridViewFilterRow = new DataGridViewFilterRow();
        this.mobjDataGridViewFilterRow.IndexInternal = 0;
        this.mobjDataGridViewFilterRow.Height = 24;
      }
      this.mobjDataGridViewFilterRow.DataGridViewInternal = (DataGridView) null;
      this.mobjDataGridViewFilterRow.HeaderCell.DataGridViewInternal = this;
      List<string> stringList = new List<string>();
      if (this.mobjDataGridViewFilterRow.Cells != null)
      {
        if (dataSource != null)
        {
          foreach (DataGridViewFilterCell cell in (BaseCollection) this.mobjDataGridViewFilterRow.Cells)
          {
            if (!cell.AllowRowFiltering)
              stringList.Add(cell.DataPropertyName);
          }
        }
        this.mobjDataGridViewFilterRow.Cells.Clear();
      }
      foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
      {
        if (stringList.Contains(column.DataPropertyName))
          column.AllowRowFilteringInternal = false;
        DataGridViewFilterCell objDataGridViewCell = new DataGridViewFilterCell(this, column, dataSource != null);
        this.mobjDataGridViewFilterRow.Cells.Add((DataGridViewCell) objDataGridViewCell);
        if (dataSource != null)
          objDataGridViewCell.FilterChanged += new EventHandler(this.OnFilterCellChanged);
      }
      this.mobjDataGridViewFilterRow.DataGridViewInternal = this;
    }

    /// <summary>Called when [filter cell changed].</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnFilterCellChanged(object sender, EventArgs e) => this.ApplyDataGridViewFilter();

    /// <summary>Applies the data grid view filter.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    internal void ApplyDataGridViewFilter()
    {
      if (!(this.DataSource is BindingSource dataSource))
        return;
      dataSource.Filter = this.ConstructFullFilterExpression();
    }

    /// <summary>
    /// Constructs the full filter expression from every FilterRow cell and column header expressions.
    /// </summary>
    /// <returns></returns>
    internal string ConstructFullFilterExpression()
    {
      string str1 = this is HierarchicDataGridView hierarchicDataGridView ? hierarchicDataGridView.ContainingRow.DataGridView.GetFilterForRowChildGrid(hierarchicDataGridView.ContainingRow) : string.Empty;
      if (this.mobjDataGridViewFilterRow != null)
      {
        foreach (DataGridViewFilterCell cell in (BaseCollection) this.mobjDataGridViewFilterRow.Cells)
        {
          DataGridViewColumn owningColumn = cell.OwningColumn;
          string str2 = owningColumn.CustomFilterExpression;
          if (string.IsNullOrEmpty(str2))
            str2 = this.GetFilterStatement(cell.ComparisonOperator, cell.DataPropertyName, cell.ValueType, cell.ComparisionValue, cell.ComparisionItem);
          if (string.IsNullOrEmpty(str2))
          {
            DataGridViewColumnHeaderCell headerCell = owningColumn.HeaderCell;
            if (headerCell != null)
              str2 = this.GetFilterStatement(FilterComparisonOperator.Equals, owningColumn.DataPropertyName, owningColumn.ValueType, headerCell.FilterComboBox.Text, headerCell.FilterComboBox.SelectedItem);
          }
          if (!string.IsNullOrEmpty(str2))
          {
            if (!string.IsNullOrEmpty(str1))
              str1 = string.Format("{0} AND ", (object) str1);
            str1 = string.Format("{0}{1}", (object) str1, (object) str2);
          }
        }
      }
      else
      {
        for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
        {
          string str3 = objDataGridViewColumnStart.CustomFilterExpression;
          if (string.IsNullOrEmpty(str3) && objDataGridViewColumnStart.HeaderCell != null && objDataGridViewColumnStart.ShowHeaderFilter)
          {
            DataGridViewColumnHeaderCell headerCell = objDataGridViewColumnStart.HeaderCell;
            if (headerCell != null && string.IsNullOrEmpty(objDataGridViewColumnStart.CustomFilterExpression))
              str3 = this.GetFilterStatement(FilterComparisonOperator.Equals, objDataGridViewColumnStart.DataPropertyName, objDataGridViewColumnStart.ValueType, headerCell.FilterComboBox.Text, headerCell.FilterComboBox.SelectedItem);
          }
          if (!string.IsNullOrEmpty(str3))
          {
            if (!string.IsNullOrEmpty(str1))
              str1 = string.Format("{0} AND ", (object) str1);
            str1 = string.Format("{0}{1}", (object) str1, (object) str3);
          }
        }
      }
      return str1;
    }

    /// <summary>Gets the filter statement according to operator.</summary>
    /// <param name="enmComparisionOperator">The comparision operator.</param>
    /// <param name="strDataPropertyName">Name of the data property.</param>
    /// <param name="objComparisionValueType">Type of the value.</param>
    /// <param name="strComparisionValue">The comparision value.</param>
    /// <returns></returns>
    private string GetFilterStatement(
      FilterComparisonOperator enmComparisionOperator,
      string strDataPropertyName,
      Type objComparisionValueType,
      string strComparisionValue,
      object objComparisionItem)
    {
      string filterStatement = (string) null;
      if (!string.IsNullOrEmpty(strDataPropertyName) && !string.IsNullOrEmpty(strComparisionValue) && objComparisionValueType != (Type) null)
      {
        filterStatement = this.GetSystemFilterStatement(strDataPropertyName, objComparisionItem);
        if (filterStatement == null)
        {
          switch (enmComparisionOperator)
          {
            case FilterComparisonOperator.Equals:
              filterStatement = string.Format("[{0}]={1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, strComparisionValue));
              break;
            case FilterComparisonOperator.NotEquals:
              filterStatement = string.Format("[{0}]<>{1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, strComparisionValue));
              break;
            case FilterComparisonOperator.LessThan:
              filterStatement = string.Format("[{0}]<{1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, strComparisionValue));
              break;
            case FilterComparisonOperator.LessThanOrEqualTo:
              filterStatement = string.Format("[{0}]<={1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, strComparisionValue));
              break;
            case FilterComparisonOperator.GreaterThan:
              filterStatement = string.Format("[{0}]>{1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, strComparisionValue));
              break;
            case FilterComparisonOperator.GreaterThanOrEqualTo:
              filterStatement = string.Format("[{0}]>={1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, strComparisionValue));
              break;
            case FilterComparisonOperator.Like:
            case FilterComparisonOperator.Contains:
              filterStatement = string.Format("[{0}] LIKE {1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, string.Format("%{0}%", (object) strComparisionValue)));
              break;
            case FilterComparisonOperator.NotLike:
            case FilterComparisonOperator.DoesNotContain:
              filterStatement = string.Format("[{0}] NOT LIKE {1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, string.Format("%{0}%", (object) strComparisionValue)));
              break;
            case FilterComparisonOperator.StartsWith:
              filterStatement = string.Format("[{0}] LIKE {1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, string.Format("{0}%", (object) strComparisionValue)));
              break;
            case FilterComparisonOperator.DoesNotStartWith:
              filterStatement = string.Format("[{0}] NOT LIKE {1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, string.Format("{0}%", (object) strComparisionValue)));
              break;
            case FilterComparisonOperator.EndsWith:
              filterStatement = string.Format("[{0}] LIKE {1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, string.Format("%{0}", (object) strComparisionValue)));
              break;
            case FilterComparisonOperator.DoesNotEndWith:
              filterStatement = string.Format("[{0}] NOT LIKE {1}", (object) strDataPropertyName, (object) this.GetQueryComparisionValue(objComparisionValueType, string.Format("%{0}", (object) strComparisionValue)));
              break;
            default:
              filterStatement = string.Empty;
              break;
          }
        }
      }
      return filterStatement;
    }

    /// <summary>Gets the system filter statement.</summary>
    /// <param name="strDataPropertyName">Name of the STR data property.</param>
    /// <param name="strComparisionValue">The STR comparision value.</param>
    /// <returns></returns>
    private string GetSystemFilterStatement(string strDataPropertyName, object objComparisionItem)
    {
      if (objComparisionItem is DataGridViewSystemFilterOption systemFilterOption)
      {
        if (systemFilterOption.Option == SystemFilterOptions.All)
          return string.Empty;
        if (systemFilterOption.Option == SystemFilterOptions.Blanks)
          return string.Format("[{0}] IS NULL", (object) strDataPropertyName);
        if (systemFilterOption.Option == SystemFilterOptions.NonBlanks)
          return string.Format("[{0}] IS NOT NULL", (object) strDataPropertyName);
      }
      return (string) null;
    }

    /// <summary>Called while initializing filter values.</summary>
    /// <param name="objFilterValuesComboBox">The filter values combo box.</param>
    /// <param name="objCurrentColumn">The current column.</param>
    protected internal virtual void FilterValuesInitializing(
      ComboBox objFilterValuesComboBox,
      DataGridViewColumn objCurrentColumn)
    {
    }

    /// <summary>
    /// Gets the query comparision value according to its type.
    /// </summary>
    /// <param name="objComparisionValueType">Type of the comparision value.</param>
    /// <param name="strComparisionValue">The STR comparision value.</param>
    /// <returns></returns>
    protected virtual string GetQueryComparisionValue(
      Type objComparisionValueType,
      string strComparisionValue)
    {
      if (strComparisionValue != null)
      {
        strComparisionValue = strComparisionValue.Replace("'", "''");
        if (objComparisionValueType == typeof (DateTime))
        {
          try
          {
            strComparisionValue = string.Format("'{0}'", (object) Convert.ToDateTime(strComparisionValue, (IFormatProvider) VWGContext.Current.CurrentUICulture).ToString(VWGContext.Current.CurrentUICulture.DateTimeFormat.UniversalSortableDateTimePattern));
          }
          catch (Exception ex)
          {
            strComparisionValue = string.Format("#{0}#", (object) strComparisionValue);
          }
        }
        else if (objComparisionValueType == typeof (Decimal) || objComparisionValueType == typeof (float) || objComparisionValueType == typeof (double))
        {
          try
          {
            strComparisionValue = string.Format("{0}", (object) Convert.ToDouble(strComparisionValue, (IFormatProvider) VWGContext.Current.CurrentUICulture).ToString((IFormatProvider) CultureInfo.InvariantCulture));
          }
          catch (Exception ex)
          {
            strComparisionValue = string.Format("{0}", (object) strComparisionValue);
          }
        }
        else if (objComparisionValueType != typeof (sbyte) && objComparisionValueType != typeof (short) && objComparisionValueType != typeof (int) && objComparisionValueType != typeof (long) && objComparisionValueType != typeof (byte) && objComparisionValueType != typeof (ushort) && objComparisionValueType != typeof (uint) && objComparisionValueType != typeof (long) && objComparisionValueType != typeof (bool) && objComparisionValueType != typeof (char))
          strComparisionValue = string.Format("'{0}'", (object) strComparisionValue);
        else if (objComparisionValueType == typeof (bool))
          strComparisionValue = string.Format("{0}", strComparisionValue.ToLower() == "true" ? (object) "1" : (object) "0");
      }
      return strComparisionValue;
    }

    /// <summary>
    /// Raises the <see cref="E:ColumnCollectionChanged_PreNotification" /> event.
    /// </summary>
    /// <param name="objCcEventArgs">The <see cref="T:System.ComponentModel.CollectionChangeEventArgs" /> instance containing the event data.</param>
    internal void OnColumnCollectionChanged_PreNotification(CollectionChangeEventArgs objCcEventArgs)
    {
      if (this.DataSource != null && !this.mobjDataGridViewOper[1024])
      {
        if (objCcEventArgs.Action == CollectionChangeAction.Add)
        {
          DataGridViewColumn element = (DataGridViewColumn) objCcEventArgs.Element;
          if (element.DataPropertyName.Length != 0)
            this.MapDataGridViewColumnToDataBoundField(element);
        }
        else if (objCcEventArgs.Action == CollectionChangeAction.Refresh)
        {
          for (int index = 0; index < this.Columns.Count; ++index)
          {
            if (this.Columns[index].DataPropertyName.Length != 0)
              this.MapDataGridViewColumnToDataBoundField(this.Columns[index]);
          }
        }
      }
      this.ResetUIState(false, false);
    }

    private void InvalidateScrollBars()
    {
    }

    internal void ResetUIState(bool blnUseRowShortcut, bool blnComputeVisibleRows)
    {
      this.PerformLayoutPrivate(true);
      if (blnUseRowShortcut)
        return;
      this.Invalidate();
      this.InvalidateScrollBars();
    }

    internal void OnRemovingColumn(
      DataGridViewColumn objDataGridViewColumn,
      out Point objNewCurrentCell,
      bool blnForce)
    {
      this.mobjDataGridViewState1[4194304] = false;
      int index1 = objDataGridViewColumn.Index;
      if (this.mobjCurrentCellPoint.X != -1)
      {
        int num = this.mobjCurrentCellPoint.X;
        if (index1 == this.mobjCurrentCellPoint.X)
        {
          DataGridViewColumn nextColumn = this.Columns.GetNextColumn(this.Columns[index1], DataGridViewElementStates.Visible, DataGridViewElementStates.None);
          if (nextColumn != null)
          {
            num = nextColumn.Index <= index1 ? nextColumn.Index : nextColumn.Index - 1;
          }
          else
          {
            DataGridViewColumn previousColumn = this.Columns.GetPreviousColumn(this.Columns[index1], DataGridViewElementStates.Visible, DataGridViewElementStates.None);
            num = previousColumn == null ? -1 : (previousColumn.Index <= index1 ? previousColumn.Index : previousColumn.Index - 1);
          }
        }
        else if (index1 < this.mobjCurrentCellPoint.X)
          num = this.mobjCurrentCellPoint.X - 1;
        ref Point local = ref objNewCurrentCell;
        int x = num;
        Point point = new Point(x, x == -1 ? -1 : this.mobjCurrentCellPoint.Y);
        local = point;
        if (index1 == this.mobjCurrentCellPoint.X)
          this.SetCurrentCellAddressCore(-1, -1, true, false, false);
        else if (blnForce)
        {
          this.mobjDataGridViewState1[4194304] = true;
          this.SetCurrentCellAddressCore(-1, -1, true, false, false);
        }
      }
      else
        objNewCurrentCell = new Point(-1, -1);
      DataGridViewRowCollection rows = this.Rows;
      if (this.Columns.Count == 1)
        rows.ClearInternal(false);
      int num1 = this.Columns.Count - 1;
      for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
      {
        DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
        if (dataGridViewRow.Cells.Count > num1)
          dataGridViewRow.Cells.RemoveAtInternal(index1);
      }
      if (objDataGridViewColumn.HasHeaderCell)
        objDataGridViewColumn.HeaderCell.DataGridViewInternal = (DataGridView) null;
      if (objDataGridViewColumn == this.SortedColumn)
      {
        this.SortedColumn = (DataGridViewColumn) null;
        this.SortOrder = SortOrder.None;
        if (objDataGridViewColumn.IsDataBound)
        {
          for (int index2 = 0; index2 < this.Columns.Count; ++index2)
          {
            if (objDataGridViewColumn != this.Columns[index2] && this.Columns[index2].SortMode != DataGridViewColumnSortMode.NotSortable && string.Compare(objDataGridViewColumn.DataPropertyName, this.Columns[index2].DataPropertyName, true, CultureInfo.InvariantCulture) == 0)
            {
              this.SortedColumn = this.Columns[index2];
              this.SortOrder = this.Columns[index2].HeaderCell.SortGlyphDirection;
              break;
            }
          }
        }
      }
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.FullColumnSelect:
        case DataGridViewSelectionMode.ColumnHeaderSelect:
          DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
          int count = selectedBandIndexes.Count;
          int index3 = 0;
          while (index3 < count)
          {
            int num2 = selectedBandIndexes[index3];
            if (index1 == num2)
            {
              selectedBandIndexes.RemoveAt(index3);
              --count;
            }
            else
            {
              if (index1 < num2)
                selectedBandIndexes[index3] = num2 - 1;
              ++index3;
            }
          }
          break;
      }
      this.IndividualSelectedCells.RemoveAllCellsAtBand(true, index1);
      this.IndividualReadOnlyCells.RemoveAllCellsAtBand(true, index1);
    }

    internal void OnRemovedColumn_PreNotification(DataGridViewColumn objDataGridViewColumn)
    {
      if (objDataGridViewColumn.HasHeaderCell)
        objDataGridViewColumn.HeaderCell.SortGlyphDirectionInternal = SortOrder.None;
      this.CorrectColumnIndexesAfterDeletion(objDataGridViewColumn);
      this.CorrectColumnDisplayIndexesAfterDeletion(objDataGridViewColumn);
      this.OnColumnRemoved(objDataGridViewColumn);
    }

    private void CorrectColumnIndexesAfterDeletion(DataGridViewColumn objDataGridViewColumn)
    {
      for (int index = objDataGridViewColumn.Index; index < this.Columns.Count; ++index)
        this.Columns[index].IndexInternal = this.Columns[index].Index - 1;
    }

    internal void OnColumnRemoved(DataGridViewColumn objDataGridViewColumn) => this.OnColumnRemoved(new DataGridViewColumnEventArgs(objDataGridViewColumn));

    internal void OnAddedColumn(DataGridViewColumn objDataGridViewColumn)
    {
      if (objDataGridViewColumn.DisplayIndex == -1 || objDataGridViewColumn.DisplayIndex >= this.Columns.Count)
      {
        DataGridViewColumn dataGridViewColumn = objDataGridViewColumn;
        dataGridViewColumn.DisplayIndexInternal = dataGridViewColumn.Index;
      }
      this.CorrectColumnDisplayIndexesAfterInsertion(objDataGridViewColumn);
      if (objDataGridViewColumn.HasHeaderCell)
        objDataGridViewColumn.HeaderCell.DataGridViewInternal = this;
      this.AdjustExpandingRows(objDataGridViewColumn.Index, false);
      DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = objDataGridViewColumn.InheritedAutoSizeMode;
      bool blnFixedColumnWidth = inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.None || inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill;
      if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
        this.AutoResizeColumnHeadersHeight(objDataGridViewColumn.Index, true, blnFixedColumnWidth);
      if (!blnFixedColumnWidth)
      {
        this.AutoResizeColumnInternal(objDataGridViewColumn.Index, (DataGridViewAutoSizeColumnCriteriaInternal) inheritedAutoSizeMode, true);
        if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
          this.AutoResizeColumnHeadersHeight(objDataGridViewColumn.Index, true, true);
      }
      this.OnColumnAdded(new DataGridViewColumnEventArgs(objDataGridViewColumn));
    }

    private void CorrectColumnDisplayIndexesAfterInsertion(DataGridViewColumn objDataGridViewColumn)
    {
      try
      {
        this.mobjDataGridViewOper[2048] = true;
        foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
        {
          if (column != objDataGridViewColumn && column.DisplayIndex >= objDataGridViewColumn.DisplayIndex)
          {
            DataGridViewColumn dataGridViewColumn = column;
            dataGridViewColumn.DisplayIndexInternal = dataGridViewColumn.DisplayIndex + 1;
            column.DisplayIndexHasChanged = true;
          }
        }
        this.FlushDisplayIndexChanged(true);
      }
      finally
      {
        this.mobjDataGridViewOper[2048] = false;
        this.FlushDisplayIndexChanged(false);
      }
    }

    private bool AutoResizeColumnInternal(
      int intColumnIndex,
      DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaInternal,
      bool blnFixedHeight)
    {
      bool flag = false;
      try
      {
        ++this.AutoSizeCount;
        DataGridViewColumn column = this.Columns[intColumnIndex];
        int intWidth = column.GetPreferredWidth((DataGridViewAutoSizeColumnMode) autoSizeColumnCriteriaInternal, blnFixedHeight);
        if (intWidth < column.MinimumThickness)
          intWidth = column.MinimumThickness;
        if (intWidth > 65536)
          intWidth = 65536;
        if (intWidth == column.Thickness)
          return flag;
        if (column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
          this.AdjustFillingColumn(column, intWidth);
        else
          this.Columns[intColumnIndex].ThicknessInternal = intWidth;
        return true;
      }
      finally
      {
        --this.AutoSizeCount;
      }
    }

    private void AdjustExpandingRows(int intColumnIndex, bool blnFixedWidth)
    {
    }

    private int AdjustExpandingRow(int intRowIndex, int intColumnIndex, bool blnFixedWidth)
    {
      int intWidth = 0;
      DataGridViewRowCollection rows = this.Rows;
      DataGridViewCell dataGridViewCell;
      if (intColumnIndex > -1 && (this.AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode) 2) != DataGridViewAutoSizeRowsMode.None)
      {
        dataGridViewCell = rows.SharedRow(intRowIndex).Cells[intColumnIndex];
        if (blnFixedWidth)
          intWidth = this.Columns[intColumnIndex].Thickness;
      }
      else
      {
        dataGridViewCell = (DataGridViewCell) rows.SharedRow(intRowIndex).HeaderCell;
        if (blnFixedWidth)
          intWidth = this.RowHeadersWidth;
      }
      int num = !blnFixedWidth ? dataGridViewCell.GetPreferredSize(intRowIndex).Height : dataGridViewCell.GetPreferredHeight(intRowIndex, intWidth);
      int intHeight;
      rows.SharedRow(intRowIndex).GetHeightInfo(intRowIndex, out intHeight, out int _);
      if (num < intHeight)
        num = intHeight;
      if (num > 65536)
        num = 65536;
      if (intHeight != num)
        rows[intRowIndex].Thickness = num;
      return num;
    }

    /// <summary>
    /// Computes the height of fitting trailing scrolling rows.
    /// </summary>
    /// <param name="totalVisibleFrozenHeight">Total height of the visible frozen.</param>
    /// <returns></returns>
    private int ComputeHeightOfFittingTrailingScrollingRows(int totalVisibleFrozenHeight)
    {
      int num1 = this.mobjLayoutInfo.Data.Height - totalVisibleFrozenHeight;
      int trailingScrollingRows1 = 0;
      int trailingScrollingRows2 = 0;
      int count = this.Rows.Count;
      if (count == 0 || num1 <= 0)
        return 0;
      int num2 = count - 1;
      DataGridViewElementStates rowState = this.Rows.GetRowState(num2);
      if ((rowState & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
        return 0;
      if ((rowState & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
        num2 = this.Rows.GetPreviousRow(num2, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
      if (num2 != -1)
      {
        trailingScrollingRows1 = this.Rows.SharedRow(num2).GetHeight(num2);
        if (trailingScrollingRows1 > num1)
          return trailingScrollingRows1;
      }
      while (num2 != -1 && trailingScrollingRows2 + trailingScrollingRows1 <= num1)
      {
        trailingScrollingRows2 += trailingScrollingRows1;
        num2 = this.Rows.GetPreviousRow(num2, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
        if (num2 != -1)
          trailingScrollingRows1 = this.Rows.SharedRow(num2).GetHeight(num2);
      }
      return trailingScrollingRows2;
    }

    /// <summary>Adjusts the filling columns.</summary>
    /// <returns></returns>
    internal bool AdjustFillingColumns()
    {
      int num1 = 0;
      if (this.mobjDataGridViewOper[262144])
        return false;
      this.mobjDataGridViewOper[262144] = true;
      bool flag1 = false;
      try
      {
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        float num5 = 0.0f;
        ArrayList arrayList = (ArrayList) null;
        foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
        {
          if (column.Visible)
          {
            if (column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
            {
              ++num2;
              num4 += column.DesiredMinimumWidth > 0 ? column.DesiredMinimumWidth : column.MinimumWidth;
              num5 += column.FillWeight;
              if (arrayList == null)
                arrayList = new ArrayList(this.Columns.Count);
              arrayList.Add((object) column);
            }
            else
              num3 += column.Width;
          }
        }
        if (num2 <= 0)
          return flag1;
        int num6 = 0;
        if (this.ExpansionIndicator != ShowExpansionIndicator.Never && this.IsHierarchic(HierarchicInfoSelector.Any) && this.Skin is DataGridViewSkin skin)
          num6 = skin.ExpandCollapseColumnWidth;
        int num7 = this.mobjLayoutInfo.Data.Width - num3 - num6;
        if (this.menmScrollBars == ScrollBars.Both || this.menmScrollBars == ScrollBars.Vertical)
        {
          int rowCount = this.Rows.GetRowCount(DataGridViewElementStates.Visible);
          int num8 = 0;
          int rowsHeight = this.Rows.GetRowsHeight(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
          if (this.UseInternalPaging)
          {
            foreach (DataGridViewRow pageRow in (IEnumerable) this.PageRows)
              num8 += pageRow.Height;
          }
          else
            num8 = this.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
          if (this.DisplayedBandsInfo.NumTotallyDisplayedFrozenRows == this.Rows.GetRowCount(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible) && this.DisplayedBandsInfo.NumTotallyDisplayedScrollingRows != rowCount - this.Rows.GetRowCount(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible) && num8 - rowsHeight > this.ComputeHeightOfFittingTrailingScrollingRows(rowsHeight) && this.mobjLayoutInfo.Data.Height > rowsHeight && 17 <= this.mobjLayoutInfo.Data.Width)
            num7 -= 17;
        }
        int num9;
        if (num7 <= num4)
        {
          int num10 = 0;
          for (int index = 0; index < arrayList.Count; ++index)
          {
            DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index];
            int num11 = dataGridViewColumn.DesiredMinimumWidth > 0 ? dataGridViewColumn.DesiredMinimumWidth : dataGridViewColumn.MinimumWidth;
            if (dataGridViewColumn.Thickness != num11)
            {
              flag1 = true;
              dataGridViewColumn.ThicknessInternal = num11;
            }
            num10 += dataGridViewColumn.Thickness;
          }
          for (int index = 0; index < arrayList.Count; ++index)
          {
            DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index];
            dataGridViewColumn.UsedFillWeight = (float) dataGridViewColumn.Width * num5 / (float) num10;
          }
          this.mobjDataGridViewState2[67108864] = false;
          num9 = num10;
          return flag1;
        }
        int num12 = 0;
        if (this.mobjDataGridViewState2[67108864])
        {
          bool flag2 = false;
          for (int index = 0; index < arrayList.Count; ++index)
          {
            DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index];
            if (index == arrayList.Count - 1)
            {
              dataGridViewColumn.DesiredFillWidth = num7 - num12;
            }
            else
            {
              float num13 = dataGridViewColumn.FillWeight / num5 * (float) num7;
              dataGridViewColumn.DesiredFillWidth = (int) Math.Round((double) num13, MidpointRounding.AwayFromZero);
              num12 += dataGridViewColumn.DesiredFillWidth;
            }
            int num14 = dataGridViewColumn.DesiredMinimumWidth > 0 ? dataGridViewColumn.DesiredMinimumWidth : dataGridViewColumn.MinimumWidth;
            if (dataGridViewColumn.DesiredFillWidth < num14)
            {
              flag2 = true;
              dataGridViewColumn.DesiredFillWidth = -1;
            }
          }
          if (flag2)
          {
            float num15 = num5;
            float num16 = num5;
            for (int index = 0; index < arrayList.Count; ++index)
            {
              DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index];
              if (dataGridViewColumn.DesiredFillWidth == -1)
              {
                int num17 = dataGridViewColumn.DesiredMinimumWidth > 0 ? dataGridViewColumn.DesiredMinimumWidth : dataGridViewColumn.MinimumWidth;
                dataGridViewColumn.UsedFillWeight = num5 * (float) num17 / (float) num7;
                num15 -= dataGridViewColumn.UsedFillWeight;
                num16 -= dataGridViewColumn.FillWeight;
              }
            }
            for (int index = 0; index < arrayList.Count; ++index)
            {
              DataGridViewColumn dataGridViewColumn1 = (DataGridViewColumn) arrayList[index];
              if (dataGridViewColumn1.DesiredFillWidth != -1)
              {
                DataGridViewColumn dataGridViewColumn2 = dataGridViewColumn1;
                dataGridViewColumn2.UsedFillWeight = dataGridViewColumn2.FillWeight * num15 / num16;
              }
            }
          }
          else
          {
            for (int index = 0; index < arrayList.Count; ++index)
            {
              DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index];
              dataGridViewColumn.UsedFillWeight = dataGridViewColumn.FillWeight;
            }
          }
          this.mobjDataGridViewState2[67108864] = false;
          num9 = num7;
        }
        else if (num7 != num1)
        {
          if (num7 > num1)
          {
            int num18 = num7 - num1;
            for (int index = 0; index < arrayList.Count; ++index)
            {
              DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index];
              dataGridViewColumn.DesiredFillWidth = dataGridViewColumn.Width;
            }
            float[] numArray = new float[arrayList.Count];
            for (int index1 = 0; index1 < num18; ++index1)
            {
              float num19 = 0.0f;
              bool flag3 = false;
              for (int index2 = 0; index2 < arrayList.Count; ++index2)
              {
                DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index2];
                num19 += dataGridViewColumn.FillWeight / dataGridViewColumn.UsedFillWeight;
                if (dataGridViewColumn.DesiredFillWidth <= dataGridViewColumn.MinimumWidth)
                  flag3 = true;
              }
              for (int index3 = 0; index3 < arrayList.Count; ++index3)
              {
                DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index3];
                if (index1 == 0)
                  numArray[index3] = (float) num1 * dataGridViewColumn.UsedFillWeight / num5;
                if (flag3)
                  numArray[index3] += dataGridViewColumn.FillWeight / dataGridViewColumn.UsedFillWeight / num19;
                else
                  numArray[index3] += dataGridViewColumn.FillWeight / num5;
              }
            }
            for (int index = 0; index < arrayList.Count; ++index)
              ((DataGridViewColumn) arrayList[index]).UsedFillWeight = num5 / (float) num7 * numArray[index];
          }
          else
          {
            int num20 = num1 - num7;
            int num21 = 0;
            for (int index = 0; index < arrayList.Count; ++index)
            {
              DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList[index];
              dataGridViewColumn.DesiredFillWidth = dataGridViewColumn.Width;
            }
            do
            {
              int num22 = num1 - num21;
              int num23 = Math.Min(num22 - num7, Math.Max(1, (int) ((double) num22 * 0.10000000149011612)));
              num21 += num23;
              bool flag4;
              do
              {
                flag4 = false;
                float num24 = 0.0f;
                float num25 = 0.0f;
                DataGridViewColumn dataGridViewColumn3 = (DataGridViewColumn) null;
                for (int index = 0; index < arrayList.Count; ++index)
                {
                  DataGridViewColumn dataGridViewColumn4 = (DataGridViewColumn) arrayList[index];
                  if (dataGridViewColumn4.DesiredFillWidth > dataGridViewColumn4.MinimumWidth)
                  {
                    float num26 = dataGridViewColumn4.UsedFillWeight / dataGridViewColumn4.FillWeight;
                    num25 += num26;
                    if ((double) num26 > (double) num24)
                    {
                      dataGridViewColumn3 = dataGridViewColumn4;
                      num24 = num26;
                    }
                  }
                }
                if (dataGridViewColumn3 != null)
                {
                  float num27 = (float) ((double) num22 * (double) dataGridViewColumn3.UsedFillWeight / (double) num5 - (double) num23 * (double) dataGridViewColumn3.UsedFillWeight / (double) dataGridViewColumn3.FillWeight / (double) num25);
                  if ((double) num27 < (double) dataGridViewColumn3.MinimumWidth)
                    num27 = (float) dataGridViewColumn3.MinimumWidth;
                  int desiredFillWidth = dataGridViewColumn3.DesiredFillWidth;
                  dataGridViewColumn3.DesiredFillWidth = Math.Min(desiredFillWidth, (int) Math.Round((double) num27, MidpointRounding.AwayFromZero));
                  flag4 = desiredFillWidth != dataGridViewColumn3.DesiredFillWidth;
                  if (!flag4 && num23 == 1 && desiredFillWidth > dataGridViewColumn3.MinimumWidth)
                  {
                    --dataGridViewColumn3.DesiredFillWidth;
                    flag4 = true;
                  }
                  num23 -= desiredFillWidth - dataGridViewColumn3.DesiredFillWidth;
                  if (flag4)
                  {
                    num22 -= desiredFillWidth - dataGridViewColumn3.DesiredFillWidth;
                    for (int index = 0; index < arrayList.Count; ++index)
                    {
                      DataGridViewColumn dataGridViewColumn5 = (DataGridViewColumn) arrayList[index];
                      dataGridViewColumn5.UsedFillWeight = num5 / (float) num22 * (float) dataGridViewColumn5.DesiredFillWidth;
                    }
                  }
                }
              }
              while (flag4 && num23 > 0);
            }
            while (num21 < num20);
          }
          num9 = num7;
        }
        try
        {
          this.mobjDataGridViewState2[33554432] = false;
          int num28 = 0;
          float num29 = 0.0f;
          while (arrayList.Count > 0)
          {
            DataGridViewColumn dataGridViewColumn6 = (DataGridViewColumn) null;
            if (arrayList.Count == 1)
            {
              dataGridViewColumn6 = (DataGridViewColumn) arrayList[0];
              dataGridViewColumn6.DesiredFillWidth = Math.Max(num7 - num28, dataGridViewColumn6.MinimumWidth);
              arrayList.Clear();
            }
            else
            {
              float num30 = 0.0f;
              for (int index = 0; index < arrayList.Count; ++index)
              {
                DataGridViewColumn dataGridViewColumn7 = (DataGridViewColumn) arrayList[index];
                float num31 = Math.Abs(dataGridViewColumn7.UsedFillWeight - dataGridViewColumn7.FillWeight) / dataGridViewColumn7.FillWeight;
                if ((double) num31 > (double) num30 || dataGridViewColumn6 == null)
                {
                  dataGridViewColumn6 = dataGridViewColumn7;
                  num30 = num31;
                }
              }
              float num32 = dataGridViewColumn6.UsedFillWeight * (float) num7 / num5 + num29;
              dataGridViewColumn6.DesiredFillWidth = Math.Max(dataGridViewColumn6.MinimumWidth, (int) Math.Round((double) num32, MidpointRounding.AwayFromZero));
              num29 = num32 - (float) dataGridViewColumn6.DesiredFillWidth;
              num28 += dataGridViewColumn6.DesiredFillWidth;
              arrayList.Remove((object) dataGridViewColumn6);
            }
            if (dataGridViewColumn6.DesiredFillWidth != dataGridViewColumn6.Thickness)
            {
              flag1 = true;
              DataGridViewColumn dataGridViewColumn8 = dataGridViewColumn6;
              dataGridViewColumn8.ThicknessInternal = dataGridViewColumn8.DesiredFillWidth;
            }
          }
        }
        finally
        {
          this.mobjDataGridViewState2[33554432] = true;
        }
      }
      finally
      {
        this.mobjDataGridViewOper[262144] = false;
      }
      return flag1;
    }

    /// <summary>Adjusts the filling column.</summary>
    /// <param name="objDataGridViewColumn">The obj data grid view column.</param>
    /// <param name="intWidth">Width of the int.</param>
    internal void AdjustFillingColumn(DataGridViewColumn objDataGridViewColumn, int intWidth)
    {
      if (this.InAdjustFillingColumns)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterAutoFillColumnParameter"));
      this.mobjDataGridViewOper[524288] = true;
      try
      {
        DataGridView.LayoutData layoutInfo = this.LayoutInfo;
        if (this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) > layoutInfo.Data.Width)
          return;
        int width = layoutInfo.Data.Width;
        if (this.DesignMode || objDataGridViewColumn == this.Columns.GetFirstColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen) || objDataGridViewColumn == this.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen))
        {
          float num1 = 0.0f;
          int num2 = 0;
          int num3 = 0;
          bool flag1 = false;
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
          {
            if (column.Visible)
            {
              if (column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
              {
                num2 += column.Width;
                if (column.Index != objDataGridViewColumn.Index)
                {
                  num3 += column.MinimumWidth;
                  flag1 = true;
                }
                num1 += column.FillWeight;
              }
              else
              {
                num3 += column.Width;
                width -= column.Width;
              }
            }
          }
          if (!flag1)
            return;
          int num4 = layoutInfo.Data.Width - num3;
          if (intWidth > num4)
            intWidth = num4;
          float fillWeight = objDataGridViewColumn.FillWeight;
          float num5 = (float) intWidth * num1 / (float) num2;
          bool flag2 = false;
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
          {
            if (column.Index != objDataGridViewColumn.Index && column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
            {
              column.FillWeightInternal = (float) (((double) num1 - (double) num5) * (double) column.FillWeight / ((double) num1 - (double) fillWeight));
              if ((double) column.FillWeight < (double) column.MinimumWidth * (double) num1 / (double) num2)
              {
                flag2 = true;
                column.DesiredFillWidth = -1;
              }
              else
                column.DesiredFillWidth = 0;
            }
          }
          objDataGridViewColumn.FillWeightInternal = num5;
          if (flag2)
          {
            float num6 = num1;
            float num7 = num1;
            float num8 = 0.0f;
            foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
            {
              if (column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
              {
                if (column.Index == objDataGridViewColumn.Index)
                {
                  DataGridViewColumn dataGridViewColumn = column;
                  dataGridViewColumn.UsedFillWeight = dataGridViewColumn.FillWeight;
                  num6 -= column.UsedFillWeight;
                  num7 -= column.FillWeight;
                  num8 += column.UsedFillWeight;
                }
                else if (column.DesiredFillWidth == -1)
                {
                  column.UsedFillWeight = num1 * (float) column.MinimumWidth / (float) num2;
                  num6 -= column.UsedFillWeight;
                  num7 -= column.FillWeight;
                  num8 += column.UsedFillWeight;
                }
              }
            }
            foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
            {
              if (column.Index != objDataGridViewColumn.Index && column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && column.DesiredFillWidth != -1)
              {
                column.UsedFillWeight = Math.Max(column.FillWeight * num6 / num7, num1 * (float) column.MinimumWidth / (float) num2);
                num8 += column.UsedFillWeight;
              }
            }
            objDataGridViewColumn.UsedFillWeight += num1 - num8;
          }
          else
          {
            foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
            {
              if (column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
              {
                DataGridViewColumn dataGridViewColumn = column;
                dataGridViewColumn.UsedFillWeight = dataGridViewColumn.FillWeight;
              }
            }
          }
        }
        else
        {
          int num9 = 0;
          float num10 = 0.0f;
          float num11 = 0.0f;
          bool flag3 = false;
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
          {
            if (column.Visible)
            {
              if (column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
              {
                if (column.Index != objDataGridViewColumn.Index)
                {
                  if (this.Columns.DisplayInOrder(objDataGridViewColumn.Index, column.Index))
                  {
                    num9 += column.MinimumWidth;
                    num11 += column.FillWeight;
                  }
                  else
                    num9 += column.Width;
                  flag3 = true;
                }
                num10 += column.FillWeight;
              }
              else
              {
                num9 += column.Width;
                width -= column.Width;
              }
            }
          }
          if (!flag3)
            return;
          int num12 = layoutInfo.Data.Width - num9;
          if (intWidth > num12)
            intWidth = num12;
          float fillWeight = objDataGridViewColumn.FillWeight;
          float num13 = num10 * (float) intWidth / (float) width;
          float num14 = num11 + fillWeight - num13;
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
          {
            if (column.Index != objDataGridViewColumn.Index && column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && this.Columns.DisplayInOrder(objDataGridViewColumn.Index, column.Index))
            {
              DataGridViewColumn dataGridViewColumn = column;
              dataGridViewColumn.FillWeightInternal = dataGridViewColumn.FillWeight * num14 / num11;
            }
          }
          objDataGridViewColumn.FillWeightInternal = num13;
          bool flag4 = false;
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
          {
            if (column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
            {
              if ((double) column.FillWeight < (double) column.MinimumWidth * (double) num10 / (double) width)
              {
                flag4 = true;
                column.DesiredFillWidth = -1;
              }
              else
                column.DesiredFillWidth = 0;
            }
          }
          if (flag4)
          {
            float num15 = num10;
            float num16 = num10;
            float num17 = 0.0f;
            foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
            {
              if (column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
              {
                if (column.Index == objDataGridViewColumn.Index || this.Columns.DisplayInOrder(column.Index, objDataGridViewColumn.Index))
                {
                  if (column.Index == objDataGridViewColumn.Index)
                  {
                    DataGridViewColumn dataGridViewColumn = column;
                    dataGridViewColumn.UsedFillWeight = dataGridViewColumn.FillWeight;
                  }
                  else
                    column.UsedFillWeight = num10 * (float) column.Width / (float) width;
                  num15 -= column.UsedFillWeight;
                  num16 -= column.FillWeight;
                  num17 += column.UsedFillWeight;
                }
                else if (column.DesiredFillWidth == -1)
                {
                  column.UsedFillWeight = num10 * (float) column.MinimumWidth / (float) width;
                  num15 -= column.UsedFillWeight;
                  num16 -= column.FillWeight;
                  num17 += column.UsedFillWeight;
                }
              }
            }
            foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
            {
              if (this.Columns.DisplayInOrder(objDataGridViewColumn.Index, column.Index) && column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && column.DesiredFillWidth != -1)
              {
                column.UsedFillWeight = Math.Max(column.FillWeight * num15 / num16, num10 * (float) column.MinimumWidth / (float) width);
                num17 += column.UsedFillWeight;
              }
            }
            objDataGridViewColumn.UsedFillWeight += num10 - num17;
          }
          else
          {
            foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
            {
              if (column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
              {
                DataGridViewColumn dataGridViewColumn = column;
                dataGridViewColumn.UsedFillWeight = dataGridViewColumn.FillWeight;
              }
            }
          }
        }
        this.mobjDataGridViewState2[67108864] = false;
        this.PerformLayoutPrivate(false);
      }
      finally
      {
        this.mobjDataGridViewOper[524288] = false;
      }
    }

    private void CorrectColumnDisplayIndexesAfterDeletion(DataGridViewColumn objDataGridViewColumn)
    {
      try
      {
        this.mobjDataGridViewOper[2048] = true;
        foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
        {
          if (column.DisplayIndex > objDataGridViewColumn.DisplayIndex)
          {
            DataGridViewColumn dataGridViewColumn = column;
            dataGridViewColumn.DisplayIndexInternal = dataGridViewColumn.DisplayIndex - 1;
            column.DisplayIndexHasChanged = true;
          }
        }
        this.FlushDisplayIndexChanged(true);
      }
      finally
      {
        this.mobjDataGridViewOper[2048] = false;
        this.FlushDisplayIndexChanged(false);
      }
    }

    private void FlushDisplayIndexChanged(bool blnRaiseEvent)
    {
      foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
      {
        if (column.DisplayIndexHasChanged)
        {
          column.DisplayIndexHasChanged = false;
          if (blnRaiseEvent)
            this.OnColumnDisplayIndexChanged(column);
        }
      }
    }

    internal void OnInsertingColumn(
      int intColumnIndexInserted,
      DataGridViewColumn objDataGridViewColumn,
      out Point objNewCurrentCell)
    {
      if (objDataGridViewColumn.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridView_ColumnAlreadyBelongsToDataGridView"));
      if (!this.InInitialization && objDataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && (this.SelectionMode == DataGridViewSelectionMode.FullColumnSelect || this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
        throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", (object) DataGridViewColumnSortMode.Automatic.ToString(), (object) this.SelectionMode.ToString()));
      if (objDataGridViewColumn.Visible)
      {
        if (!this.ColumnHeadersVisible && (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader || objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && this.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader))
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoSizedColumn"));
        if (objDataGridViewColumn.Frozen && (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && this.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill))
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoFillColumn"));
      }
      this.CorrectColumnFrozenState(objDataGridViewColumn, intColumnIndexInserted);
      if (this.mobjCurrentCellPoint.X != -1)
      {
        objNewCurrentCell = new Point(intColumnIndexInserted <= this.mobjCurrentCellPoint.X ? this.mobjCurrentCellPoint.X + 1 : this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
        this.ResetCurrentCell();
      }
      else
        objNewCurrentCell = new Point(-1, -1);
      DataGridViewRowCollection rows = this.Rows;
      if (rows.Count > 0)
      {
        if (objDataGridViewColumn.CellType == (Type) null)
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddUntypedColumn"));
        if (objDataGridViewColumn.CellTemplate.DefaultNewRowValue != null && this.NewRowIndex != -1)
        {
          DataGridViewRow dataGridViewRow1 = rows[this.NewRowIndex];
        }
        int num = this.Columns.Count + 1;
        try
        {
          for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
          {
            DataGridViewRow dataGridViewRow2 = rows.SharedRow(intRowIndex);
            if (dataGridViewRow2.Cells.Count < num)
            {
              DataGridViewCell objDataGridViewCell = (DataGridViewCell) objDataGridViewColumn.CellTemplate.Clone();
              dataGridViewRow2.Cells.InsertInternal(intColumnIndexInserted, objDataGridViewCell);
              if (intRowIndex == this.NewRowIndex)
              {
                DataGridViewCell dataGridViewCell = objDataGridViewCell;
                dataGridViewCell.Value = dataGridViewCell.DefaultNewRowValue;
              }
              objDataGridViewCell.DataGridViewInternal = this;
              objDataGridViewCell.OwningRowInternal = dataGridViewRow2;
              objDataGridViewCell.OwningColumnInternal = objDataGridViewColumn;
            }
          }
        }
        catch
        {
          for (int intRowIndex = 0; intRowIndex < rows.Count; ++intRowIndex)
          {
            DataGridViewRow dataGridViewRow3 = rows.SharedRow(intRowIndex);
            if (dataGridViewRow3.Cells.Count == num)
              dataGridViewRow3.Cells.RemoveAtInternal(intColumnIndexInserted);
            else
              break;
          }
          throw;
        }
      }
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.FullColumnSelect:
        case DataGridViewSelectionMode.ColumnHeaderSelect:
          DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
          int count1 = selectedBandIndexes.Count;
          for (int index = 0; index < count1; ++index)
          {
            int num = selectedBandIndexes[index];
            if (intColumnIndexInserted <= num)
              selectedBandIndexes[index] = num + 1;
          }
          DataGridViewIntLinkedList bandSnapshotIndexes = this.SelectedBandSnapshotIndexes;
          if (bandSnapshotIndexes == null)
            break;
          int count2 = bandSnapshotIndexes.Count;
          for (int index = 0; index < count2; ++index)
          {
            int num = bandSnapshotIndexes[index];
            if (intColumnIndexInserted <= num)
              bandSnapshotIndexes[index] = num + 1;
          }
          break;
      }
    }

    internal void OnSortGlyphDirectionChanged(
      DataGridViewColumnHeaderCell dataGridViewColumnHeaderCell)
    {
      if (dataGridViewColumnHeaderCell.OwningColumn == this.SortedColumn)
      {
        if (dataGridViewColumnHeaderCell.SortGlyphDirection == SortOrder.None)
        {
          this.SortedColumn = (DataGridViewColumn) null;
          DataGridViewColumn owningColumn = dataGridViewColumnHeaderCell.OwningColumn;
          if (owningColumn.IsDataBound)
          {
            for (int index = 0; index < this.Columns.Count; ++index)
            {
              if (owningColumn != this.Columns[index] && this.Columns[index].SortMode != DataGridViewColumnSortMode.NotSortable && string.Compare(owningColumn.DataPropertyName, this.Columns[index].DataPropertyName, true, CultureInfo.InvariantCulture) == 0)
              {
                this.SortedColumn = this.Columns[index];
                break;
              }
            }
          }
        }
        this.SortOrder = this.SortedColumn != null ? this.SortedColumn.HeaderCell.SortGlyphDirection : SortOrder.None;
      }
      this.InvalidateCellPrivate((DataGridViewCell) dataGridViewColumnHeaderCell);
    }

    internal string OnRowErrorTextNeeded(int intRowIndex, string strErrorText)
    {
      DataGridViewRowErrorTextNeededEventArgs e = new DataGridViewRowErrorTextNeededEventArgs(intRowIndex, strErrorText);
      this.OnRowErrorTextNeeded(e);
      return e.ErrorText;
    }

    internal void OnAddingRow(
      DataGridViewRow objDataGridViewRow,
      DataGridViewElementStates enmRowState,
      bool blnCheckFrozenState)
    {
      if (objDataGridViewRow == null)
        throw new ArgumentNullException("dataGridViewRow");
      if (blnCheckFrozenState)
        this.CorrectRowFrozenState(objDataGridViewRow, enmRowState, this.Rows.Count);
      if (this.ReadOnly && objDataGridViewRow.DataGridView == null && objDataGridViewRow.ReadOnly)
        objDataGridViewRow.ReadOnly = false;
      int index = 0;
      foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
      {
        DataGridViewCell cell = objDataGridViewRow.Cells[index];
        if ((this.ReadOnly || column.ReadOnly) && cell.StateIncludes(DataGridViewElementStates.ReadOnly))
          cell.ReadOnlyInternal = false;
        ++index;
      }
    }

    internal void OnAddedRow_PreNotification(int intRowIndex)
    {
      if (this.AllowUserToAddRowsInternal && this.NewRowIndex == -1)
        this.NewRowIndex = intRowIndex;
      DataGridViewRowCollection rows = this.Rows;
      if ((rows.GetRowState(intRowIndex) & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || this.ReadOnly)
        return;
      foreach (DataGridViewCell cell in (BaseCollection) rows.SharedRow(intRowIndex).Cells)
      {
        if (!cell.OwningColumn.ReadOnly && this.IsSharedCellReadOnly(cell, intRowIndex))
          this.IndividualReadOnlyCells.Add(cell);
      }
    }

    private bool IsSharedCellReadOnly(DataGridViewCell objDataGridViewCell, int intRowIndex)
    {
      DataGridViewElementStates rowState = this.Rows.GetRowState(intRowIndex);
      return this.ReadOnly || (rowState & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || objDataGridViewCell.OwningColumn != null && objDataGridViewCell.OwningColumn.ReadOnly || objDataGridViewCell.StateIncludes(DataGridViewElementStates.ReadOnly);
    }

    internal void OnAddedRow_PostNotification(int intRowIndex)
    {
      DataGridViewRowCollection rows = this.Rows;
      DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
      if ((rowState & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
        return;
      bool flag1 = (rowState & DataGridViewElementStates.Displayed) != 0;
      DataGridViewAutoSizeRowsMode autoSizeRowsMode = this.AutoSizeRowsMode;
      DataGridViewAutoSizeRowsModeInternal rowsModeInternal = (DataGridViewAutoSizeRowsModeInternal) autoSizeRowsMode;
      bool flag2 = false;
      if (rowsModeInternal != DataGridViewAutoSizeRowsModeInternal.None && (rowsModeInternal & DataGridViewAutoSizeRowsModeInternal.DisplayedRows) == DataGridViewAutoSizeRowsModeInternal.None | flag1)
      {
        int height = rows.SharedRow(intRowIndex).GetHeight(intRowIndex);
        rows.SharedRow(intRowIndex).CachedThickness = height;
        this.AutoResizeRowInternal(intRowIndex, DataGridView.MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), false, true);
        flag2 = true;
      }
      DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaFilter = DataGridViewAutoSizeColumnCriteriaInternal.AllRows;
      if (flag1)
        autoSizeColumnCriteriaFilter |= DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows;
      bool flag3 = rows.GetRowCount(DataGridViewElementStates.Visible) <= 1 ? this.AutoResizeAllVisibleColumnsInternal(autoSizeColumnCriteriaFilter, true) : this.AdjustExpandingColumns(autoSizeColumnCriteriaFilter, intRowIndex);
      bool blnFixedColumnHeadersHeight = this.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      DataGridViewRowHeadersWidthSizeMode headersWidthSizeMode = this.RowHeadersWidthSizeMode;
      int num = headersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing ? 0 : (headersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing ? 1 : 0);
      if (num == 0 && !flag3)
        blnFixedColumnHeadersHeight = true;
      if (num != 0)
        this.AutoResizeRowHeadersWidth(intRowIndex, headersWidthSizeMode, blnFixedColumnHeadersHeight, true);
      if (!blnFixedColumnHeadersHeight)
        this.AutoResizeColumnHeadersHeight(true, true);
      if (flag2)
        this.AutoResizeRowInternal(intRowIndex, DataGridView.MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), true, true);
      if (num == 0 || blnFixedColumnHeadersHeight)
        return;
      this.AutoResizeRowHeadersWidth(intRowIndex, headersWidthSizeMode, true, true);
    }

    private static DataGridViewAutoSizeRowMode MapAutoSizeRowsModeToRowMode(
      DataGridViewAutoSizeRowsMode enmAutoSizeRowsMode)
    {
      switch (enmAutoSizeRowsMode)
      {
        case DataGridViewAutoSizeRowsMode.AllHeaders:
          return DataGridViewAutoSizeRowMode.RowHeader;
        case DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders:
          return DataGridViewAutoSizeRowMode.AllCellsExceptHeader;
        case DataGridViewAutoSizeRowsMode.AllCells:
          return DataGridViewAutoSizeRowMode.AllCells;
        case DataGridViewAutoSizeRowsMode.DisplayedHeaders:
          return DataGridViewAutoSizeRowMode.RowHeader;
        case DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders:
          return DataGridViewAutoSizeRowMode.AllCellsExceptHeader;
        case DataGridViewAutoSizeRowsMode.DisplayedCells:
          return DataGridViewAutoSizeRowMode.AllCells;
        default:
          return DataGridViewAutoSizeRowMode.RowHeader;
      }
    }

    private bool AutoResizeAllVisibleColumnsInternal(
      DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaFilter,
      bool blnFixedHeight)
    {
      bool flag = false;
      for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
      {
        DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal) objDataGridViewColumnStart.InheritedAutoSizeMode;
        if ((inheritedAutoSizeMode & autoSizeColumnCriteriaFilter) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
          flag |= this.AutoResizeColumnInternal(objDataGridViewColumnStart.Index, inheritedAutoSizeMode, blnFixedHeight);
      }
      return flag;
    }

    private bool AdjustExpandingColumns(
      DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaFilter,
      int intRowIndex)
    {
      bool flag = false;
      for (DataGridViewColumn dataGridViewColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = this.Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
      {
        DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal) dataGridViewColumn.InheritedAutoSizeMode;
        if ((inheritedAutoSizeMode & autoSizeColumnCriteriaFilter) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
          flag |= this.AdjustExpandingColumn(dataGridViewColumn, inheritedAutoSizeMode, intRowIndex);
      }
      return flag;
    }

    private bool AdjustExpandingColumn(
      DataGridViewColumn objDataGridViewColumn,
      DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaInternal,
      int intRowIndex)
    {
      bool flag = false;
      try
      {
        ++this.AutoSizeCount;
        DataGridViewRow dataGridViewRow = this.Rows.SharedRow(intRowIndex);
        int num = dataGridViewRow.Cells[objDataGridViewColumn.Index].GetPreferredWidth(intRowIndex, dataGridViewRow.GetHeight(intRowIndex));
        if (num > 65536)
          num = 65536;
        if (objDataGridViewColumn.Width < num)
        {
          objDataGridViewColumn.ThicknessInternal = num;
          flag = true;
        }
      }
      finally
      {
        --this.AutoSizeCount;
      }
      return flag;
    }

    /// <summary>Gets the cached graphics.</summary>
    /// <value>The cached graphics.</value>
    internal Graphics CachedGraphics
    {
      get
      {
        if (this.mobjCachedGraphics == null)
          this.mobjCachedGraphics = CommonUtils.GetMeasurementGraphics();
        return this.mobjCachedGraphics;
      }
    }

    /// <summary>Called when [row height info pushed].</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="intHeight">The height.</param>
    /// <param name="intMinimumHeight">The minimum height.</param>
    /// <returns></returns>
    private bool OnRowHeightInfoPushed(int intRowIndex, int intHeight, int intMinimumHeight)
    {
      if (this.VirtualMode || this.DataSource != null)
      {
        DataGridViewRowHeightInfoPushedEventArgs e = new DataGridViewRowHeightInfoPushedEventArgs(intRowIndex, intHeight, intMinimumHeight);
        this.OnRowHeightInfoPushed(e);
        if (e.Handled)
        {
          this.UpdateRowHeightInfo(intRowIndex, false);
          return true;
        }
      }
      return false;
    }

    private void AutoResizeRowInternal(
      int intRowIndex,
      DataGridViewAutoSizeRowMode enmAutoSizeRowMode,
      bool blnFixedWidth,
      bool blnInternalAutosizing)
    {
      try
      {
        ++this.AutoSizeCount;
        DataGridViewRowCollection rows = this.Rows;
        DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
        int intHeight1;
        int intMinimumHeight;
        dataGridViewRow.GetHeightInfo(intRowIndex, out intHeight1, out intMinimumHeight);
        int intHeight2 = dataGridViewRow.GetPreferredHeight(intRowIndex, enmAutoSizeRowMode, blnFixedWidth);
        if (intHeight2 < intMinimumHeight)
          intHeight2 = intMinimumHeight;
        if (intHeight2 > 65536)
          intHeight2 = 65536;
        if (intHeight1 == intHeight2)
          return;
        if (this.AutoSizeRowsMode == DataGridViewAutoSizeRowsMode.None)
        {
          if (this.OnRowHeightInfoPushed(intRowIndex, intHeight2, intMinimumHeight))
            return;
          rows[intRowIndex].ThicknessInternal = intHeight2;
        }
        else if (blnInternalAutosizing)
          rows[intRowIndex].ThicknessInternal = intHeight2;
        else
          rows[intRowIndex].Thickness = intHeight2;
      }
      finally
      {
        --this.AutoSizeCount;
      }
    }

    internal void OnAddedRows_PreNotification(DataGridViewRow[] arrDataGridViewRows)
    {
      foreach (DataGridViewBand arrDataGridViewRow in arrDataGridViewRows)
        this.OnAddedRow_PreNotification(arrDataGridViewRow.Index);
    }

    internal void OnAddedRows_PostNotification(DataGridViewRow[] arrDataGridViewRows)
    {
      foreach (DataGridViewBand arrDataGridViewRow in arrDataGridViewRows)
        this.OnAddedRow_PostNotification(arrDataGridViewRow.Index);
    }

    internal void OnClearingRows()
    {
      this.CurrentPage = 1;
      this.CurrentCell = (DataGridViewCell) null;
      this.NewRowIndex = -1;
      DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      this.mobjDataGridViewState2[262144] = selectedBandIndexes.Count > 0 || individualSelectedCells.Count > 0;
      selectedBandIndexes.Clear();
      this.SelectedBandSnapshotIndexes?.Clear();
      individualSelectedCells.Clear();
      this.IndividualReadOnlyCells.Clear();
    }

    /// <summary>Called when [inserting row].</summary>
    /// <param name="intRowIndexInserted">The row index inserted.</param>
    /// <param name="objDataGridViewRow">The data grid view row.</param>
    /// <param name="enmRowState">State of the row.</param>
    /// <param name="objNewCurrentCell">The new current cell.</param>
    /// <param name="blnFirstInsertion">if set to <c>true</c> [first insertion].</param>
    /// <param name="intInsertionCount">The insertion count.</param>
    /// <param name="blnForce">if set to <c>true</c> [force].</param>
    internal void OnInsertingRow(
      int intRowIndexInserted,
      DataGridViewRow objDataGridViewRow,
      DataGridViewElementStates enmRowState,
      ref Point objNewCurrentCell,
      bool blnFirstInsertion,
      int intInsertionCount,
      bool blnForce)
    {
      if (blnFirstInsertion)
      {
        if (this.mobjCurrentCellPoint.Y != -1 && intRowIndexInserted <= this.mobjCurrentCellPoint.Y)
        {
          objNewCurrentCell = new Point(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y + intInsertionCount);
          if (blnForce)
          {
            this.mobjDataGridViewState1[4194304] = true;
            this.SetCurrentCellAddressCore(-1, -1, true, false, false);
          }
          else
            this.ResetCurrentCell();
        }
        else
          objNewCurrentCell = new Point(-1, -1);
      }
      else if (objNewCurrentCell.Y != -1)
        objNewCurrentCell.Y += intInsertionCount;
      this.OnAddingRow(objDataGridViewRow, enmRowState, false);
      this.CorrectRowFrozenState(objDataGridViewRow, enmRowState, intRowIndexInserted);
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.FullRowSelect:
        case DataGridViewSelectionMode.RowHeaderSelect:
          int count1 = this.SelectedBandIndexes.Count;
          for (int index = 0; index < count1; ++index)
          {
            int selectedBandIndex = this.SelectedBandIndexes[index];
            if (intRowIndexInserted <= selectedBandIndex)
              this.SelectedBandIndexes[index] = selectedBandIndex + intInsertionCount;
          }
          if (this.SelectedBandSnapshotIndexes == null)
            break;
          int count2 = this.SelectedBandSnapshotIndexes.Count;
          for (int index = 0; index < count2; ++index)
          {
            int bandSnapshotIndex = this.SelectedBandSnapshotIndexes[index];
            if (intRowIndexInserted <= bandSnapshotIndex)
              this.SelectedBandSnapshotIndexes[index] = bandSnapshotIndex + intInsertionCount;
          }
          break;
      }
    }

    internal void OnInsertedRow_PreNotification(int intRowIndex, int insertionCount)
    {
      this.DisplayedBandsInfo.CorrectRowIndexAfterInsertion(intRowIndex, insertionCount);
      this.CorrectRowIndexesAfterInsertion(intRowIndex, insertionCount);
      this.OnAddedRow_PreNotification(intRowIndex);
    }

    internal void OnInsertedRow_PostNotification(
      int intRowIndex,
      Point objNewCurrentCell,
      bool blnLastInsertion)
    {
      this.OnAddedRow_PostNotification(intRowIndex);
      if (!blnLastInsertion || objNewCurrentCell.Y == -1)
        return;
      this.SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, true, false, false, false, this.Rows.GetRowCount(DataGridViewElementStates.Visible) == 1);
    }

    private void ResetCurrentCell()
    {
      if (this.mobjCurrentCellPoint.X != -1 && !this.SetCurrentCellAddressCore(-1, -1, true, true, false))
        throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
    }

    /// <summary>Called when [inserting rows].</summary>
    /// <param name="intRowIndexInserted">The row index inserted.</param>
    /// <param name="arrDataGridViewRows">The data grid view rows.</param>
    /// <param name="objNewCurrentCell">The new current cell.</param>
    internal void OnInsertingRows(
      int intRowIndexInserted,
      DataGridViewRow[] arrDataGridViewRows,
      ref Point objNewCurrentCell)
    {
      if (this.mobjCurrentCellPoint.Y != -1 && intRowIndexInserted <= this.mobjCurrentCellPoint.Y)
      {
        objNewCurrentCell = new Point(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y + arrDataGridViewRows.Length);
        this.ResetCurrentCell();
      }
      else
        objNewCurrentCell = new Point(-1, -1);
      this.OnAddingRows(arrDataGridViewRows, false);
      this.CorrectRowFrozenStates(arrDataGridViewRows, intRowIndexInserted);
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.FullRowSelect:
        case DataGridViewSelectionMode.RowHeaderSelect:
          int count1 = this.SelectedBandIndexes.Count;
          for (int index = 0; index < count1; ++index)
          {
            int selectedBandIndex = this.SelectedBandIndexes[index];
            if (intRowIndexInserted <= selectedBandIndex)
              this.SelectedBandIndexes[index] = selectedBandIndex + arrDataGridViewRows.Length;
          }
          if (this.SelectedBandSnapshotIndexes == null)
            break;
          int count2 = this.SelectedBandSnapshotIndexes.Count;
          for (int index = 0; index < count2; ++index)
          {
            int bandSnapshotIndex = this.SelectedBandSnapshotIndexes[index];
            if (intRowIndexInserted <= bandSnapshotIndex)
              this.SelectedBandSnapshotIndexes[index] = bandSnapshotIndex + arrDataGridViewRows.Length;
          }
          break;
      }
    }

    /// <summary>Called when [inserted rows_ pre notification].</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="arrDataGridViewRows">The data grid view rows.</param>
    internal void OnInsertedRows_PreNotification(
      int intRowIndex,
      DataGridViewRow[] arrDataGridViewRows)
    {
      this.DisplayedBandsInfo.CorrectRowIndexAfterInsertion(intRowIndex, arrDataGridViewRows.Length);
      this.CorrectRowIndexesAfterInsertion(intRowIndex, arrDataGridViewRows.Length);
      this.OnAddedRows_PreNotification(arrDataGridViewRows);
    }

    internal void OnInsertedRows_PostNotification(
      DataGridViewRow[] arrDataGridViewRows,
      Point objNewCurrentCell)
    {
      this.OnAddedRows_PostNotification(arrDataGridViewRows);
      if (objNewCurrentCell.Y == -1)
        return;
      this.SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, true, false, false, false, false);
    }

    internal void CompleteCellsCollection(DataGridViewRow objDataGridViewRow)
    {
      int count = objDataGridViewRow.Cells.Count;
      if (this.Columns.Count <= count)
        return;
      int index1 = 0;
      DataGridViewCell[] dataGridViewCellArray = new DataGridViewCell[this.Columns.Count - count];
      for (int index2 = count; index2 < this.Columns.Count; ++index2)
      {
        if (this.Columns[index2].CellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridView_AColumnHasNoCellTemplate"));
        DataGridViewCell dataGridViewCell = (DataGridViewCell) this.Columns[index2].CellTemplate.Clone();
        dataGridViewCellArray[index1] = dataGridViewCell;
        ++index1;
      }
      objDataGridViewRow.Cells.AddRange(dataGridViewCellArray);
    }

    internal void OnRowsRemovedInternal(int intRowIndex, int intRowCount)
    {
      if (this.UseInternalPaging && this.CurrentPage > this.TotalPages)
        this.CurrentPage = this.TotalPages;
      this.OnRowsRemoved(new DataGridViewRowsRemovedEventArgs(intRowIndex, intRowCount));
    }

    internal void OnRowsAddedInternal(int intRowIndex, int intRowCount) => this.OnRowsAdded(new DataGridViewRowsAddedEventArgs(intRowIndex, intRowCount));

    internal void OnRemovedRow_PreNotification(int intRowIndexDeleted) => this.CorrectRowIndexesAfterDeletion(intRowIndexDeleted);

    internal void OnClearedRows()
    {
      this.CurrentCell = (DataGridViewCell) null;
      this.NewRowIndex = -1;
      DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      this.mobjDataGridViewState2[262144] = selectedBandIndexes.Count > 0 || individualSelectedCells.Count > 0;
      selectedBandIndexes.Clear();
      individualSelectedCells.Clear();
      this.IndividualReadOnlyCells.Clear();
    }

    internal void OnRemovingRow(int intRowIndexDeleted, out Point objNewCurrentCell, bool blnForce)
    {
      DataGridViewRowCollection rows = this.Rows;
      this.mobjDataGridViewState1[4194304] = false;
      objNewCurrentCell = new Point(-1, -1);
      if (this.mobjCurrentCellPoint.Y != -1 && intRowIndexDeleted <= this.mobjCurrentCellPoint.Y)
      {
        int y;
        if (intRowIndexDeleted == this.mobjCurrentCellPoint.Y)
        {
          int previousRow = rows.GetPreviousRow(intRowIndexDeleted, DataGridViewElementStates.Visible);
          int nextRow = rows.GetNextRow(intRowIndexDeleted, DataGridViewElementStates.Visible);
          y = previousRow <= -1 || !this.AllowUserToAddRowsInternal ? (nextRow <= -1 ? previousRow : nextRow - 1) : (nextRow <= -1 || nextRow >= rows.Count - 1 ? previousRow : nextRow - 1);
          this.IsCurrentCellDirtyInternal = false;
          this.IsCurrentRowDirtyInternal = false;
        }
        else
          y = this.mobjCurrentCellPoint.Y - 1;
        objNewCurrentCell = new Point(this.mobjCurrentCellPoint.X, y);
        if (intRowIndexDeleted == this.mobjCurrentCellPoint.Y)
          this.SetCurrentCellAddressCore(-1, -1, true, false, false);
        else if (blnForce)
        {
          this.mobjDataGridViewState1[4194304] = true;
          this.SetCurrentCellAddressCore(-1, -1, true, false, false);
        }
        else
          this.ResetCurrentCell();
      }
      bool flag = false;
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.FullRowSelect:
        case DataGridViewSelectionMode.RowHeaderSelect:
          DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
          int count1 = selectedBandIndexes.Count;
          int index1 = 0;
          while (index1 < count1)
          {
            int num = selectedBandIndexes[index1];
            if (intRowIndexDeleted == num)
            {
              flag = true;
              selectedBandIndexes.RemoveAt(index1);
              --count1;
            }
            else
            {
              if (intRowIndexDeleted < num)
                selectedBandIndexes[index1] = num - 1;
              ++index1;
            }
          }
          DataGridViewIntLinkedList bandSnapshotIndexes = this.SelectedBandSnapshotIndexes;
          if (bandSnapshotIndexes != null)
          {
            int count2 = bandSnapshotIndexes.Count;
            int index2 = 0;
            while (index2 < count2)
            {
              int num = bandSnapshotIndexes[index2];
              if (intRowIndexDeleted == num)
              {
                bandSnapshotIndexes.RemoveAt(index2);
                --count2;
              }
              else
              {
                if (intRowIndexDeleted < num)
                  bandSnapshotIndexes[index2] = num - 1;
                ++index2;
              }
            }
            break;
          }
          break;
      }
      this.mobjDataGridViewState2[262144] = ((this.mobjDataGridViewState2[262144] ? 1 : (this.IndividualSelectedCells.RemoveAllCellsAtBand(false, intRowIndexDeleted) > 0 ? 1 : 0)) | (flag ? 1 : 0)) != 0;
      this.IndividualReadOnlyCells.RemoveAllCellsAtBand(false, intRowIndexDeleted);
    }

    internal void OnRemovedRow_PostNotification(
      DataGridViewRow objDataGridViewRow,
      Point objNewCurrentCell)
    {
      if (objNewCurrentCell.Y != -1)
        this.SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, true, false, false, false, false);
      this.FlushSelectionChanged();
      int num = objDataGridViewRow.DataGridView != null ? 0 : (objDataGridViewRow.Displayed ? 1 : 0);
      if (num != 0)
      {
        objDataGridViewRow.DisplayedInternal = false;
        this.OnRowStateChanged(-1, new DataGridViewRowStateChangedEventArgs(objDataGridViewRow, DataGridViewElementStates.Displayed));
      }
      if (this.AutoSizeRowsMode != DataGridViewAutoSizeRowsMode.None && objDataGridViewRow.ThicknessInternal != objDataGridViewRow.CachedThickness)
        objDataGridViewRow.ThicknessInternal = Math.Max(objDataGridViewRow.MinimumHeight, objDataGridViewRow.CachedThickness);
      DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaFilter = DataGridViewAutoSizeColumnCriteriaInternal.AllRows;
      if (num != 0)
        autoSizeColumnCriteriaFilter |= DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows;
      bool flag1 = this.AutoResizeAllVisibleColumnsInternal(autoSizeColumnCriteriaFilter, true);
      bool flag2 = this.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      DataGridViewRowHeadersWidthSizeMode headersWidthSizeMode = this.RowHeadersWidthSizeMode;
      bool blnFixedRowHeadersWidth = headersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing || headersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      if (blnFixedRowHeadersWidth && !flag1)
        flag2 = true;
      if (!flag2)
        this.AutoResizeColumnHeadersHeight(blnFixedRowHeadersWidth, true);
      if (!blnFixedRowHeadersWidth)
        this.AutoResizeRowHeadersWidth(headersWidthSizeMode, true, true);
      if (flag2 || blnFixedRowHeadersWidth)
        return;
      this.AutoResizeColumnHeadersHeight(true, true);
    }

    private void CorrectRowIndexesAfterDeletion(int intRowIndexDeleted)
    {
      DataGridViewRowCollection rows = this.Rows;
      int count = rows.Count;
      for (int intRowIndex = intRowIndexDeleted; intRowIndex < count; ++intRowIndex)
      {
        DataGridViewRow dataGridViewRow1 = rows.SharedRow(intRowIndex);
        if (dataGridViewRow1.Index >= 0)
        {
          DataGridViewRow dataGridViewRow2 = dataGridViewRow1;
          dataGridViewRow2.IndexInternal = dataGridViewRow2.Index - 1;
        }
      }
      if (this.NewRowIndex == intRowIndexDeleted)
      {
        this.NewRowIndex = -1;
      }
      else
      {
        if (this.NewRowIndex == -1)
          return;
        --this.NewRowIndex;
      }
    }

    private void CorrectRowIndexesAfterInsertion(int intRowIndexInserted, int insertionCount)
    {
      DataGridViewRowCollection rows = this.Rows;
      int count = rows.Count;
      for (int intRowIndex = intRowIndexInserted + insertionCount; intRowIndex < count; ++intRowIndex)
      {
        DataGridViewRow dataGridViewRow1 = rows.SharedRow(intRowIndex);
        if (dataGridViewRow1.Index >= 0)
        {
          DataGridViewRow dataGridViewRow2 = dataGridViewRow1;
          dataGridViewRow2.IndexInternal = dataGridViewRow2.Index + insertionCount;
        }
      }
      if (this.NewRowIndex == -1)
        return;
      this.NewRowIndex += insertionCount;
    }

    private void SetSelectedElementCore(int intColumnIndex, int intRowIndex, bool blnSelected) => this.SetSelectedElementCore(intColumnIndex, intRowIndex, blnSelected, false);

    private void SetSelectedElementCore(
      int intColumnIndex,
      int intRowIndex,
      bool blnSelected,
      bool blnClientSource)
    {
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.CellSelect:
          this.SetSelectedCellCore(intColumnIndex, intRowIndex, blnSelected);
          break;
        case DataGridViewSelectionMode.FullRowSelect:
          this.SetSelectedRowCore(intRowIndex, blnSelected, blnClientSource);
          break;
        case DataGridViewSelectionMode.FullColumnSelect:
          this.SetSelectedColumnCore(intColumnIndex, blnSelected);
          break;
        case DataGridViewSelectionMode.RowHeaderSelect:
          if (intColumnIndex != -1)
          {
            this.SetSelectedCellCore(intColumnIndex, intRowIndex, blnSelected, blnClientSource);
            break;
          }
          this.SetSelectedRowCore(intRowIndex, blnSelected);
          break;
        case DataGridViewSelectionMode.ColumnHeaderSelect:
          if (intRowIndex != -1)
          {
            this.SetSelectedCellCore(intColumnIndex, intRowIndex, blnSelected);
            break;
          }
          this.SetSelectedColumnCore(intColumnIndex, blnSelected);
          break;
      }
    }

    private bool SetAndSelectCurrentCellAddress(
      int intColumnIndex,
      int intRowIndex,
      bool blnSetAnchorCellAddress,
      bool blnValidateCurrentCell,
      bool blnThroughMouseClick,
      bool blnClearSelection,
      bool blnForceCurrentCellSelection)
    {
      if (!this.SetCurrentCellAddressCore(intColumnIndex, intRowIndex, blnSetAnchorCellAddress, blnValidateCurrentCell, blnThroughMouseClick) || this.IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
        return false;
      DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      if (blnClearSelection)
        this.ClearSelection(intColumnIndex, intRowIndex, true);
      else if (blnForceCurrentCellSelection)
      {
        this.SetSelectedElementCore(intColumnIndex, intRowIndex, true);
      }
      else
      {
        if (this.MultiSelect && individualSelectedCells.Count + selectedBandIndexes.Count > 1)
          return true;
        if (individualSelectedCells.Count == 1)
        {
          DataGridViewCell headCell = individualSelectedCells.HeadCell;
          if (headCell.ColumnIndex != intColumnIndex || headCell.RowIndex != intRowIndex)
            return true;
        }
        else if (selectedBandIndexes.Count == 1)
        {
          switch (this.SelectionMode)
          {
            case DataGridViewSelectionMode.FullRowSelect:
            case DataGridViewSelectionMode.RowHeaderSelect:
              if (selectedBandIndexes.HeadInt != intRowIndex)
                return true;
              break;
            case DataGridViewSelectionMode.FullColumnSelect:
            case DataGridViewSelectionMode.ColumnHeaderSelect:
              if (selectedBandIndexes.HeadInt != intColumnIndex)
                return true;
              break;
          }
        }
        this.SetSelectedElementCore(intColumnIndex, intRowIndex, true);
      }
      return true;
    }

    private void MakeFirstDisplayedCellCurrentCell(bool blnIncludeNewRow)
    {
      Point displayedCellAddress = this.FirstDisplayedCellAddress;
      if (displayedCellAddress.X == -1 || !blnIncludeNewRow && this.AllowUserToAddRowsInternal && displayedCellAddress.Y == this.Rows.Count - 1)
        return;
      this.SetAndSelectCurrentCellAddress(displayedCellAddress.X, displayedCellAddress.Y, true, false, false, true, false);
    }

    internal void OnRowCollectionChanged_PostNotification(
      bool blnRecreateNewRow,
      bool blnAllowSettingCurrentCell,
      CollectionChangeAction enmCca,
      DataGridViewRow objDataGridViewRow,
      int intRowIndex)
    {
      if (blnRecreateNewRow && enmCca == CollectionChangeAction.Refresh && this.Columns.Count != 0 && this.Rows.Count == 0 && this.AllowUserToAddRowsInternal)
        this.AddNewRow(false);
      if (enmCca == CollectionChangeAction.Refresh)
        this.FlushSelectionChanged();
      if ((enmCca == CollectionChangeAction.Refresh || enmCca == CollectionChangeAction.Add) && this.mobjCurrentCellPoint.X == -1 & blnAllowSettingCurrentCell && !this.InSortOperation)
        this.MakeFirstDisplayedCellCurrentCell(false);
      if (!this.AutoSize)
        return;
      switch (enmCca)
      {
        case CollectionChangeAction.Add:
          int rowState = (int) this.Rows.GetRowState(intRowIndex);
          break;
        case CollectionChangeAction.Remove:
          int num = objDataGridViewRow.DataGridView != null ? 0 : (objDataGridViewRow.Visible ? 1 : 0);
          break;
      }
    }

    internal void OnAddingRows(DataGridViewRow[] arrDataGridViewRows, bool blnCheckFrozenStates)
    {
      foreach (DataGridViewRow arrDataGridViewRow in arrDataGridViewRows)
      {
        if (arrDataGridViewRow == null)
          throw new InvalidOperationException(SR.GetString("DataGridView_AtLeastOneRowIsNull"));
        if (arrDataGridViewRow.DataGridView != null)
          throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
        if (arrDataGridViewRow.Selected)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotAddOrInsertSelectedRow"));
        if (arrDataGridViewRow.Cells.Count > this.Columns.Count)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_TooManyCells"));
      }
      int length = arrDataGridViewRows.Length;
      for (int index1 = 0; index1 < length - 1; ++index1)
      {
        for (int index2 = index1 + 1; index2 < length; ++index2)
        {
          if (arrDataGridViewRows[index1] == arrDataGridViewRows[index2])
            throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddIdenticalRows"));
        }
      }
      if (blnCheckFrozenStates)
        this.CorrectRowFrozenStates(arrDataGridViewRows, this.Rows.Count);
      foreach (DataGridViewRow arrDataGridViewRow in arrDataGridViewRows)
      {
        this.CompleteCellsCollection(arrDataGridViewRow);
        DataGridViewRow objDataGridViewRow = arrDataGridViewRow;
        this.OnAddingRow(objDataGridViewRow, objDataGridViewRow.State, false);
      }
    }

    private void CorrectRowFrozenStates(
      DataGridViewRow[] arrDataGridViewRows,
      int intRowIndexInserted)
    {
      bool flag1 = false;
      bool flag2 = true;
      bool flag3 = false;
      DataGridViewRowCollection rows = this.Rows;
      int previousRow = rows.GetPreviousRow(intRowIndexInserted, DataGridViewElementStates.Visible);
      if (previousRow != -1)
        flag2 = (rows.GetRowState(previousRow) & DataGridViewElementStates.Frozen) == DataGridViewElementStates.Frozen;
      int nextRow = rows.GetNextRow(intRowIndexInserted - 1, DataGridViewElementStates.Visible);
      if (nextRow != -1)
      {
        flag1 = true;
        flag3 = (rows.GetRowState(nextRow) & DataGridViewElementStates.Frozen) == DataGridViewElementStates.Frozen;
      }
      for (int index = 0; index < arrDataGridViewRows.Length; ++index)
      {
        bool frozen = arrDataGridViewRows[index].Frozen;
        flag2 = !(!flag2 & frozen) ? frozen : throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddFrozenRow"));
        if (index == arrDataGridViewRows.Length - 1 && !frozen && flag1 & flag3)
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddNonFrozenRow"));
      }
    }

    internal bool OnSortCompare(
      DataGridViewColumn objDataGridViewSortedColumn,
      object objValue1,
      object objValue2,
      int intRowIndex1,
      int intRowIndex2,
      out int intSortResult)
    {
      DataGridViewSortCompareEventArgs e = new DataGridViewSortCompareEventArgs(objDataGridViewSortedColumn, objValue1, objValue2, intRowIndex1, intRowIndex2);
      this.OnSortCompare(e);
      intSortResult = e.SortResult;
      return e.Handled;
    }

    internal void OnRowUnshared(DataGridViewRow objDataGridViewRow2)
    {
    }

    internal void SwapSortedRows(int intRowIndex1, int intRowIndex2)
    {
      if (intRowIndex1 == intRowIndex2)
        return;
      if (intRowIndex1 == this.mobjCurrentCellCache.Y)
        this.mobjCurrentCellCache.Y = intRowIndex2;
      else if (intRowIndex2 == this.mobjCurrentCellCache.Y)
        this.mobjCurrentCellCache.Y = intRowIndex1;
      switch (this.SelectionMode)
      {
        case DataGridViewSelectionMode.FullRowSelect:
        case DataGridViewSelectionMode.RowHeaderSelect:
          DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
          int index1 = selectedBandIndexes.IndexOf(intRowIndex1);
          int index2 = selectedBandIndexes.IndexOf(intRowIndex2);
          if (index1 == -1 || index2 != -1)
          {
            if (index1 == -1 && index2 != -1)
              selectedBandIndexes[index2] = intRowIndex1;
          }
          else
            selectedBandIndexes[index1] = intRowIndex2;
          DataGridViewIntLinkedList bandSnapshotIndexes = this.SelectedBandSnapshotIndexes;
          if (bandSnapshotIndexes == null)
            break;
          int index3 = bandSnapshotIndexes.IndexOf(intRowIndex1);
          int index4 = bandSnapshotIndexes.IndexOf(intRowIndex2);
          if (index3 != -1 && index4 == -1)
          {
            bandSnapshotIndexes[index3] = intRowIndex2;
            break;
          }
          if (index3 != -1 || index4 == -1)
            break;
          bandSnapshotIndexes[index4] = intRowIndex1;
          break;
      }
    }

    internal void OnBandMinimumThicknessChanged(DataGridViewBand objDataGridViewBand)
    {
      if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
        this.OnColumnMinimumWidthChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
      else
        this.OnRowMinimumHeightChanged(new DataGridViewRowEventArgs((DataGridViewRow) objDataGridViewBand));
    }

    internal void OnBandThicknessChanged(DataGridViewBand objDataGridViewBand)
    {
      if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
        this.OnColumnWidthChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
      else
        this.OnRowHeightChanged(new DataGridViewRowEventArgs((DataGridViewRow) objDataGridViewBand));
    }

    internal void OnBandThicknessChanging()
    {
      if (this.InAdjustFillingColumns)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterAutoFillColumnParameter"));
    }

    internal void OnBandHeaderCellChanged(DataGridViewBand objDataGridViewBand)
    {
      if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
        this.OnColumnHeaderCellChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
      else
        this.OnRowHeaderCellChanged(new DataGridViewRowEventArgs((DataGridViewRow) objDataGridViewBand));
    }

    internal void OnCellValueChangedInternal(DataGridViewCellEventArgs e, bool blnClientSource) => this.OnCellValueChanged(e, blnClientSource);

    internal void OnBandDefaultCellStyleChanged(DataGridViewBand objDataGridViewBand)
    {
      if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
        this.OnColumnDefaultCellStyleChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
      else
        this.OnRowDefaultCellStyleChanged(new DataGridViewRowEventArgs((DataGridViewRow) objDataGridViewBand));
    }

    internal void OnColumnFillWeightChanging(
      DataGridViewColumn objDataGridViewColumn,
      float fillWeight)
    {
      if (this.InAdjustFillingColumns)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterAutoFillColumnParameter"));
      if ((double) this.Columns.GetColumnsFillWeight(DataGridViewElementStates.None) - (double) objDataGridViewColumn.FillWeight + (double) fillWeight > (double) ushort.MaxValue)
        throw new InvalidOperationException(SR.GetString("DataGridView_WeightSumCannotExceedLongMaxValue", (object) ((int) ushort.MaxValue).ToString((IFormatProvider) CultureInfo.CurrentCulture)));
    }

    internal void OnColumnFillWeightChanged(DataGridViewColumn objDataGridViewColumn)
    {
      if (objDataGridViewColumn.InheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
        return;
      this.mobjDataGridViewState2[67108864] = true;
      this.PerformLayoutPrivate(false);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellContextMenuChanged(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler contextMenuChanged = this.CellContextMenuChanged;
      if (contextMenuChanged == null)
        return;
      contextMenuChanged((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:CellContextMenuStripChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellContextMenuStripChanged(DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("e.ColumnIndex");
      if (e.RowIndex >= this.Rows.Count)
        throw new ArgumentOutOfRangeException("e.RowIndex");
      DataGridViewCellEventHandler menuStripChanged = this.CellContextMenuStripChanged;
      if (menuStripChanged == null)
        return;
      menuStripChanged((object) this, e);
    }

    /// <summary>Called when [cell context menu changed].</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    internal void OnCellContextMenuChanged(DataGridViewCell objDataGridViewCell) => this.OnCellContextMenuChanged(new DataGridViewCellEventArgs(objDataGridViewCell));

    /// <summary>Called when [cell context menu strip changed].</summary>
    /// <param name="dataGridViewCell">The data grid view cell.</param>
    internal void OnCellContextMenuStripChanged(DataGridViewCell dataGridViewCell) => this.OnCellContextMenuStripChanged(new DataGridViewCellEventArgs(dataGridViewCell));

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseDown"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    /// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
    protected virtual void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOWN) is DataGridViewCellMouseEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseEnter"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellMouseEnter(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler cellMouseEnter = this.CellMouseEnter;
      if (cellMouseEnter == null)
        return;
      cellMouseEnter((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseLeave"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellMouseLeave(DataGridViewCellEventArgs e)
    {
      DataGridViewCellEventHandler cellMouseLeave = this.CellMouseLeave;
      if (cellMouseLeave == null)
        return;
      cellMouseLeave((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseMove"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
    {
      DataGridViewCellMouseEventHandler cellMouseMove = this.CellMouseMove;
      if (cellMouseMove == null)
        return;
      cellMouseMove((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseUp"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
    protected virtual void OnCellMouseUp(DataGridViewCellMouseEventArgs e)
    {
      if (!(this.GetHandler(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEUP) is DataGridViewCellMouseEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Gets or sets the extended column headers.</summary>
    /// <value>The extended column headers.</value>
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ExtendedColumnHeaders ExtendedColumnHeaders => this.mobjExtendedColumnHeaders ?? (this.mobjExtendedColumnHeaders = new ExtendedColumnHeaders(this));

    /// <summary>Gets the filter row.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public DataGridViewFilterRow FilterRow => this.mobjDataGridViewFilterRow;

    /// <summary>
    /// Gets or sets a value indicating whether [show column chooser].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show column chooser]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool ShowColumnChooser
    {
      get => this.mblnShowColumnChooser;
      set
      {
        if (this.mblnShowColumnChooser == value)
          return;
        this.mblnShowColumnChooser = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the column chooser sorter.</summary>
    /// <value>The column chooser sorter.</value>
    [DefaultValue(null)]
    [Browsable(false)]
    public IComparer ColumnChooserSorter
    {
      get => this.mblnColumnChooserSorter;
      set
      {
        if (this.mblnColumnChooserSorter == value)
          return;
        this.mblnColumnChooserSorter = value;
      }
    }

    /// <summary>Gets or sets the expansion indicator.</summary>
    /// <value>The expansion indicator.</value>
    [DefaultValue(ShowExpansionIndicator.CheckOnExpand)]
    public virtual ShowExpansionIndicator ExpansionIndicator
    {
      get => this.menmExpansionIndicator;
      set
      {
        if (this.menmExpansionIndicator == value)
          return;
        this.menmExpansionIndicator = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the hierarchy level.</summary>
    /// <value>The hierarchy level.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int HierarchyLevel
    {
      get => this.mintHierarchyLevel;
      internal set => this.mintHierarchyLevel = value;
    }

    /// <summary>
    /// Gets the real filtering data member index by proposed filtering data member.
    /// </summary>
    internal Dictionary<string, string> RealFilteringDataMemberIndexByProposedFilteringDataMember
    {
      get
      {
        if (this.mobjRealFilteringDataMemberIndexByProposedFilteringDataMember == null)
          this.mobjRealFilteringDataMemberIndexByProposedFilteringDataMember = new Dictionary<string, string>();
        return this.mobjRealFilteringDataMemberIndexByProposedFilteringDataMember;
      }
    }

    /// <summary>Gets the root grid.</summary>
    public DataGridView RootGrid
    {
      get => this.mobjRootGrid;
      internal set => this.mobjRootGrid = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is selection change critical.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is selection change critical; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(false)]
    [Description("Gets or sets a value indicating whether this instance is selection change critical.")]
    [Category("Behavior")]
    public bool IsSelectionChangeCritical
    {
      get => this.mblnIsSelectionChangeCritical;
      set => this.mblnIsSelectionChangeCritical = value;
    }

    /// <summary>Gets or sets the select on right click.</summary>
    /// <value>The select on right click.</value>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_SelectOnRightClickDescr")]
    [DefaultValue(false)]
    public bool SelectOnRightClick
    {
      get => this.mblnSelectOnRightClick;
      set
      {
        if (this.mblnSelectOnRightClick == value)
          return;
        this.mblnSelectOnRightClick = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(false)]
    [Description("Gets or sets a value indicating whether caption is visible.")]
    [Category("Behavior")]
    public bool IsCaptionVisible
    {
      get => this.mblnIsCaptionVisible;
      set
      {
        if (this.mblnIsCaptionVisible == value)
          return;
        this.mblnIsCaptionVisible = value;
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [resize all rows].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [resize all rows]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Description("Gets or sets a value indicating whether all rows height will change if only one them is changed by the user")]
    [Category("Behavior")]
    public bool EnforceEqualRowSize
    {
      get => this.mblnEnforceEqualRowSize;
      set
      {
        if (this.mblnEnforceEqualRowSize == value)
          return;
        this.mblnEnforceEqualRowSize = value;
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is virtual.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is virtual; otherwise, <c>false</c>.
    /// </value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    protected virtual bool IsVirtualDataGridView => !this.DesignMode && this.Context != null && this.Context.Config.IsFeatureEnabled("ForceVirtualDataGridView", false);

    /// <summary>Gets or sets the control custom style.</summary>
    /// <value></value>
    public override string CustomStyle
    {
      get => !this.DesignMode && this.Context != null && this.Context.Config.IsFeatureEnabled("ForceVirtualDataGridView", false) ? "V" : base.CustomStyle;
      set => base.CustomStyle = value;
    }

    private DataGridViewCell CurrentCellInternal => this.Rows.SharedRow(this.mobjCurrentCellPoint.Y).Cells[this.mobjCurrentCellPoint.X];

    /// <summary>Gets or sets the displayed bands info.</summary>
    /// <value>The displayed bands info.</value>
    private DataGridView.DisplayedBandsData DisplayedBandsInfo
    {
      get => this.mobjDisplayedBandsInfo;
      set => this.mobjDisplayedBandsInfo = value;
    }

    /// <summary>Gets the editing control.</summary>
    /// <value>The editing control.</value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public Control EditingControl
    {
      get => this.mobjEditingControl;
      private set => this.mobjEditingControl = value;
    }

    /// <summary>Gets or sets the cached editing control.</summary>
    /// <value>The cached editing control.</value>
    private Control CachedEditingControl
    {
      get => this.mobjCachedEditingControl;
      set => this.mobjCachedEditingControl = value;
    }

    /// <summary>Gets a value indicating whether [in begin edit].</summary>
    /// <value><c>true</c> if [in begin edit]; otherwise, <c>false</c>.</value>
    internal bool InBeginEdit => this.mobjDataGridViewOper[2097152];

    /// <summary>Gets or sets the bulk paint count.</summary>
    /// <value>The bulk paint count.</value>
    private int BulkPaintCount
    {
      get => this.mintBulkPaintCount;
      set => this.mintBulkPaintCount = value;
    }

    internal bool InEndEdit => this.mobjDataGridViewOper[4194304];

    /// <summary>Gets or sets the individual read only cells.</summary>
    /// <value>The individual read only cells.</value>
    private DataGridViewCellLinkedList IndividualReadOnlyCells
    {
      get => this.mobjIndividualReadOnlyCells;
      set => this.mobjIndividualReadOnlyCells = value;
    }

    internal bool InSortOperation => false;

    internal bool InInitialization => false;

    internal bool NoDimensionChangeAllowed => this.DimensionChangeCount > 0;

    internal bool InDisplayIndexAdjustments
    {
      get => this.mobjDataGridViewOper[2048];
      set => this.mobjDataGridViewOper[2048] = value;
    }

    private Point FirstDisplayedCellAddress
    {
      get
      {
        Point displayedCellAddress = new Point(-1, -1);
        displayedCellAddress.Y = this.Rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
        if (displayedCellAddress.Y == -1 && this.FirstDisplayedScrollingRowIndex >= 0)
          displayedCellAddress.Y = this.FirstDisplayedScrollingRowIndex;
        if (displayedCellAddress.Y >= 0)
          displayedCellAddress.X = this.FirstDisplayedScrollingColumnIndex;
        return displayedCellAddress;
      }
    }

    /// <summary>Gets the border style for the upper-left cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the style of the border of the upper-left cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual DataGridViewAdvancedBorderStyle AdjustedTopLeftHeaderBorderStyle => (DataGridViewAdvancedBorderStyle) null;

    /// <summary>Gets the border style of the cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the border style of the cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public DataGridViewAdvancedBorderStyle AdvancedCellBorderStyle => (DataGridViewAdvancedBorderStyle) null;

    /// <summary>Gets the border style of the column header cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the border style of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public DataGridViewAdvancedBorderStyle AdvancedColumnHeadersBorderStyle => (DataGridViewAdvancedBorderStyle) null;

    /// <summary>Gets the border style of the row header cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the border style of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public DataGridViewAdvancedBorderStyle AdvancedRowHeadersBorderStyle => (DataGridViewAdvancedBorderStyle) null;

    /// <summary>Gets or sets a value indicating whether the option to add rows is displayed to the user.</summary>
    /// <returns>true if the add-row option is displayed to the user; otherwise false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_AllowUserToAddRowsDescr")]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public bool AllowUserToAddRows
    {
      get => this.mobjDataGridViewState1[1];
      set
      {
        if (this.AllowUserToAddRows == value)
          return;
        this.mobjDataGridViewState1[1] = value;
        if (this.DataSource != null)
          this.DataConnection.ResetCachedAllowUserToAddRowsInternal();
        this.OnAllowUserToAddRowsChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets a value indicating whether the user is allowed to delete rows from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>true if the user can delete rows; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(true)]
    [SRDescription("DataGridView_AllowUserToDeleteRowsDescr")]
    [SRCategory("CatBehavior")]
    public bool AllowUserToDeleteRows
    {
      get => this.mobjDataGridViewState1[2];
      set
      {
        if (this.AllowUserToDeleteRows == value)
          return;
        this.mobjDataGridViewState1[2] = value;
        this.OnAllowUserToDeleteRowsChanged(EventArgs.Empty);
      }
    }

    /// <summary>
    /// Checks datasource and definition for permission to delete rows
    /// </summary>
    internal bool AllowUserToDeleteRowsInternal
    {
      get
      {
        if (this.DataSource == null)
          return this.AllowUserToDeleteRows;
        return this.AllowUserToDeleteRows && this.DataConnection.AllowRemove;
      }
    }

    /// <summary>Gets or sets a value indicating whether manual column repositioning is enabled.</summary>
    /// <returns>true if the user can change the column order; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("DataGridView_AllowUserToOrderColumnsDescr")]
    public bool AllowUserToOrderColumns
    {
      get => this.mobjDataGridViewState1[4];
      set
      {
        if (this.AllowUserToOrderColumns == value)
          return;
        this.mobjDataGridViewState1[4] = !value || !this.ShowGroupingDropArea ? value : throw new InvalidOperationException("Columns reordering and grouping are not supported simultaneously.");
        this.OnAllowUserToOrderColumnsChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets a value indicating whether users can resize columns.</summary>
    /// <returns>true if users can resize columns; otherwise, false. The default is true.</returns>
    [SRDescription("DataGridView_AllowUserToResizeColumnsDescr")]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public bool AllowUserToResizeColumns
    {
      get => this.mobjDataGridViewState2[2];
      set
      {
        if (this.AllowUserToResizeColumns == value)
          return;
        this.mobjDataGridViewState2[2] = value;
        this.OnAllowUserToResizeColumnsChanged(EventArgs.Empty);
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether users can resize rows.</summary>
    /// <returns>true if all the rows are resizable; otherwise, false. The default is true.</returns>
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_AllowUserToResizeRowsDescr")]
    public bool AllowUserToResizeRows
    {
      get => this.mobjDataGridViewState2[4];
      set
      {
        if (this.AllowUserToResizeRows == value)
          return;
        this.mobjDataGridViewState2[4] = value;
        this.OnAllowUserToResizeRowsChanged(EventArgs.Empty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the bulk layout count.</summary>
    /// <value>The bulk layout count.</value>
    private int BulkLayoutCount
    {
      get => this.mintBulkLayoutCount;
      set => this.mintBulkLayoutCount = value;
    }

    /// <summary>Gets or sets the default cell style applied to odd-numbered rows of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to apply to the odd-numbered rows.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_AlternatingRowsDefaultCellStyleDescr")]
    [SRCategory("CatAppearance")]
    public DataGridViewCellStyle AlternatingRowsDefaultCellStyle
    {
      get
      {
        if (this.mobjAlternatingRowsDefaultCellStyle == null)
        {
          this.mobjAlternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
          this.mobjAlternatingRowsDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.AlternatingRows);
        }
        return this.mobjAlternatingRowsDefaultCellStyle;
      }
      set
      {
        DataGridViewCellStyle defaultCellStyle = this.AlternatingRowsDefaultCellStyle;
        defaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.AlternatingRows);
        this.mobjAlternatingRowsDefaultCellStyle = value;
        if (value != null)
          this.mobjAlternatingRowsDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.AlternatingRows);
        DataGridViewCellStyleDifferences differencesFrom = defaultCellStyle.GetDifferencesFrom(this.AlternatingRowsDefaultCellStyle);
        if (differencesFrom == DataGridViewCellStyleDifferences.None)
          return;
        this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
        this.OnAlternatingRowsDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
      }
    }

    /// <summary>Gets or sets a value indicating whether columns are created automatically when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> or <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataMember"></see> properties are set.</summary>
    /// <returns>true if the columns should be created automatically; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(true)]
    public bool AutoGenerateColumns
    {
      get => this.mobjDataGridViewState1[8388608];
      set
      {
        if (this.mobjDataGridViewState1[8388608] == value)
          return;
        this.mobjDataGridViewState1[8388608] = value;
        this.OnAutoGenerateColumnsChanged(EventArgs.Empty);
      }
    }

    internal bool AllowUserToAddRowsInternal
    {
      get
      {
        if (this.DataSource == null)
          return this.AllowUserToAddRows;
        return this.AllowUserToAddRows && this.DataConnection.AllowAdd;
      }
    }

    /// <summary>Gets or sets a value indicating how column widths are determined.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> value. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.None"></see>. </returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> value. </exception>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader"></see>, column headers are hidden, and at least one visible column has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill"></see> and at least one visible column with an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see> is frozen.</exception>
    [DefaultValue(DataGridViewAutoSizeColumnsMode.None)]
    [SRCategory("CatLayout")]
    [SRDescription("DataGridView_AutoSizeColumnsModeDescr")]
    public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
    {
      get => this.menmAutoSizeColumnsMode;
      set
      {
        switch (value)
        {
          case DataGridViewAutoSizeColumnsMode.None:
          case DataGridViewAutoSizeColumnsMode.ColumnHeader:
          case DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader:
          case DataGridViewAutoSizeColumnsMode.AllCells:
          case DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader:
          case DataGridViewAutoSizeColumnsMode.DisplayedCells:
          case DataGridViewAutoSizeColumnsMode.Fill:
            if (this.AutoSizeColumnsMode == value)
              break;
            foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
            {
              if (column.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && column.Visible)
              {
                if (value == DataGridViewAutoSizeColumnsMode.ColumnHeader && !this.ColumnHeadersVisible)
                  throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeColumnsInvisibleColumnHeaders"));
                if (value == DataGridViewAutoSizeColumnsMode.Fill && column.Frozen)
                  throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoFillFrozenColumns"));
              }
            }
            DataGridViewAutoSizeColumnMode[] arrPreviousModes = new DataGridViewAutoSizeColumnMode[this.Columns.Count];
            foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
              arrPreviousModes[column.Index] = column.InheritedAutoSizeMode;
            DataGridViewAutoSizeColumnsModeEventArgs e = new DataGridViewAutoSizeColumnsModeEventArgs(arrPreviousModes);
            this.menmAutoSizeColumnsMode = value;
            this.OnAutoSizeColumnsModeChanged(e);
            break;
          default:
            throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewAutoSizeColumnsMode));
        }
      }
    }

    /// <summary>Gets or sets a value indicating how row heights are determined. </summary>
    /// <returns>A <see cref="T:System.Windows.Forms.DataGridViewAutoSizeRowsMode"></see> value indicating the sizing mode. The default is <see cref="F:System.Windows.Forms.DataGridViewAutoSizeRowsMode.None"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is <see cref="F:System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see> and row headers are hidden. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.DataGridViewAutoSizeRowsMode"></see> value. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_AutoSizeRowsModeDescr")]
    [DefaultValue(DataGridViewAutoSizeRowsMode.None)]
    [SRCategory("CatLayout")]
    public DataGridViewAutoSizeRowsMode AutoSizeRowsMode
    {
      get => this.menmAutoSizeRowsMode;
      set
      {
        switch (value)
        {
          case DataGridViewAutoSizeRowsMode.None:
          case DataGridViewAutoSizeRowsMode.AllHeaders:
          case DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders:
          case DataGridViewAutoSizeRowsMode.AllCells:
          case DataGridViewAutoSizeRowsMode.DisplayedHeaders:
          case DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders:
          case DataGridViewAutoSizeRowsMode.DisplayedCells:
            if ((value == DataGridViewAutoSizeRowsMode.AllHeaders || value == DataGridViewAutoSizeRowsMode.DisplayedHeaders) && !this.RowHeadersVisible)
              throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeRowsInvisibleRowHeader"));
            DataGridViewAutoSizeRowsMode autoSizeRowsMode = this.AutoSizeRowsMode;
            if (autoSizeRowsMode == value)
              break;
            DataGridViewAutoSizeModeEventArgs e = new DataGridViewAutoSizeModeEventArgs(autoSizeRowsMode != 0);
            this.menmAutoSizeRowsMode = value;
            this.OnAutoSizeRowsModeChanged(e);
            break;
          default:
            throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewAutoSizeRowsMode));
        }
      }
    }

    /// <summary>Gets or sets the background color for the control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the control. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultBackColor"></see> property.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Color BackColor
    {
      get => base.BackColor;
      set => base.BackColor = value;
    }

    /// <summary>Gets or sets the background color of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. The default is <see cref="P:System.Drawing.SystemColors.AppWorkspace"></see>. </returns>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:System.Drawing.Color.Empty"></see>. -or-The specified value when setting this property has a <see cref="P:System.Drawing.Color.A"></see> property value that is less that 255.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewBackgroundColorDescr")]
    [SRCategory("CatAppearance")]
    public Color BackgroundColor
    {
      get => this.mobjBackgroundColor;
      set
      {
        if (value.IsEmpty)
          throw new ArgumentException(SR.GetString("DataGridView_EmptyColor", (object) nameof (BackgroundColor)));
        if (value.A < byte.MaxValue)
          throw new ArgumentException(SR.GetString("DataGridView_TransparentColor", (object) nameof (BackgroundColor)));
        if (value.Equals((object) this.BackgroundColor))
          return;
        this.mobjBackgroundColor = value;
        this.OnBackgroundColorChanged(EventArgs.Empty);
        if (!(this.BackColor != value))
          return;
        this.BackColor = value;
      }
    }

    private bool ShouldSerializeAlternatingRowsDefaultCellStyle() => !this.AlternatingRowsDefaultCellStyle.Equals((object) new DataGridViewCellStyle());

    private bool ShouldSerializeBackgroundColor() => !this.BackgroundColor.Equals((object) DataGridView.DefaultBackgroundBrush.Color);

    private bool ShouldSerializeColumnHeadersDefaultCellStyle() => !this.ColumnHeadersDefaultCellStyle.Equals((object) this.DefaultColumnHeadersDefaultCellStyle);

    private bool ShouldSerializeColumnHeadersHeight() => this.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize && 23 != this.ColumnHeadersHeight;

    private bool ShouldSerializeDefaultCellStyle() => !this.DefaultCellStyle.Equals((object) this.DefaultDefaultCellStyle);

    private bool ShouldSerializeGridColor() => false;

    private bool ShouldSerializeRowHeadersDefaultCellStyle() => !this.RowHeadersDefaultCellStyle.Equals((object) this.DefaultRowHeadersDefaultCellStyle);

    private bool ShouldSerializeRowHeadersWidth()
    {
      switch (this.RowHeadersWidthSizeMode)
      {
        case DataGridViewRowHeadersWidthSizeMode.EnableResizing:
        case DataGridViewRowHeadersWidthSizeMode.DisableResizing:
          return 41 != this.RowHeadersWidth;
        default:
          return false;
      }
    }

    private bool ShouldSerializeRowsDefaultCellStyle() => !this.RowsDefaultCellStyle.Equals((object) new DataGridViewCellStyle());

    private bool ShouldSerializeRowTemplate() => this.mobjRowTemplate != null;

    /// <summary>Gets or sets the background image displayed in the control.</summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> value indicating the background image layout. The default is <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>Gets or sets the border style for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.BorderStyle.FixedSingle"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> value. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(1)]
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_BorderStyleDescr")]
    public override BorderStyle BorderStyle
    {
      get => base.BorderStyle;
      set
      {
        if (base.BorderStyle == value)
          return;
        base.BorderStyle = value;
        this.OnBorderStyleChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets the cell border style for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellBorderStyle"></see> that represents the border style of the cells contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellBorderStyle"></see> value.</exception>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewCellBorderStyle.Custom"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CellBorderStyleDescr")]
    [DefaultValue(DataGridViewCellBorderStyle.Single)]
    [SRCategory("CatAppearance")]
    [Browsable(true)]
    public DataGridViewCellBorderStyle CellBorderStyle
    {
      get => this.menmCellBorderStyle;
      set
      {
        if (this.CellBorderStyle == value || !Enum.IsDefined(typeof (DataGridViewCellBorderStyle), (object) value))
          return;
        this.menmCellBorderStyle = value;
        this.UpdateParams(AttributeType.Visual);
        this.OnCellBorderStyleChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets the cell value event args.</summary>
    /// <value>The cell value event args.</value>
    internal DataGridViewCellValueEventArgs CellValueEventArgs
    {
      get
      {
        if (this.mobjCellValueEventArgs == null)
          this.mobjCellValueEventArgs = new DataGridViewCellValueEventArgs();
        return this.mobjCellValueEventArgs;
      }
    }

    /// <summary>Gets or sets a value that indicates whether users can copy cell text values to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see> and whether row and column header text is included.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)]
    [Browsable(true)]
    [SRDescription("DataGridView_ClipboardCopyModeDescr")]
    [SRCategory("CatBehavior")]
    public DataGridViewClipboardCopyMode ClipboardCopyMode
    {
      get => this.menmClipboardCopyMode;
      set => this.menmClipboardCopyMode = value;
    }

    /// <summary>Gets or sets the number of columns displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>The number of columns displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property has been set. </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 0. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(0)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int ColumnCount
    {
      get => this.Columns.Count;
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (ColumnCount), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (ColumnCount), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (this.DataSource != null)
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotSetColumnCountOnDataBoundDataGridView"));
        if (value == this.Columns.Count)
          return;
        if (value == 0)
          this.Columns.Clear();
        else if (value >= this.Columns.Count)
        {
          while (value > this.Columns.Count)
          {
            int count = this.Columns.Count;
            this.Columns.Add((string) null, (string) null);
            if (this.Columns.Count <= count)
              break;
          }
        }
        else
        {
          while (value < this.Columns.Count)
          {
            int count = this.Columns.Count;
            this.Columns.RemoveAt(count - 1);
            if (this.Columns.Count >= count)
              break;
          }
        }
      }
    }

    /// <summary>Gets the border style applied to the column headers.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle"></see> values.</returns>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle.Custom"></see>.</exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [DefaultValue(DataGridViewHeaderBorderStyle.Raised)]
    [SRDescription("DataGridView_ColumnHeadersBorderStyleDescr")]
    [Browsable(true)]
    public DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
    {
      get => DataGridViewHeaderBorderStyle.Raised;
      set
      {
      }
    }

    /// <summary>Gets or sets the default column header style.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the default column header style.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnHeadersDefaultCellStyleDescr")]
    [AmbientValue(null)]
    [SRCategory("CatAppearance")]
    public DataGridViewCellStyle ColumnHeadersDefaultCellStyle
    {
      get
      {
        if (this.mobjColumnHeadersDefaultCellStyle == null)
          this.mobjColumnHeadersDefaultCellStyle = this.DefaultColumnHeadersDefaultCellStyle;
        return this.mobjColumnHeadersDefaultCellStyle;
      }
      set
      {
        DataGridViewCellStyle defaultCellStyle = this.ColumnHeadersDefaultCellStyle;
        defaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.ColumnHeaders);
        this.mobjColumnHeadersDefaultCellStyle = value;
        if (value != null)
          this.mobjColumnHeadersDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.ColumnHeaders);
        DataGridViewCellStyleDifferences differencesFrom = defaultCellStyle.GetDifferencesFrom(this.ColumnHeadersDefaultCellStyle);
        if (differencesFrom == DataGridViewCellStyleDifferences.None)
          return;
        this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
        this.OnColumnHeadersDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
      }
    }

    /// <summary>Gets or sets the height, in pixels, of the column headers row </summary>
    /// <returns>The height, in pixels, of the row that contains the column headers. The default is 23.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than the minimum height of 4 pixels or is greater than the maximum height of 32768 pixels.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    [SRDescription("DataGridView_ColumnHeadersHeightDescr")]
    public int ColumnHeadersHeight
    {
      get => this.mintColumnHeadersHeight;
      set
      {
        if (value < 4)
          throw new ArgumentOutOfRangeException(nameof (ColumnHeadersHeight), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (ColumnHeadersHeight), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 4.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (value > 32768)
          throw new ArgumentOutOfRangeException(nameof (ColumnHeadersHeight), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (ColumnHeadersHeight), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 32768.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize || this.ColumnHeadersHeight == value)
          return;
        this.SetColumnHeadersHeightInternal(value, true);
      }
    }

    private void SetColumnHeadersHeightInternal(
      int columnHeadersHeight,
      bool blnInvalidInAdjustFillingColumns)
    {
      this.mintColumnHeadersHeight = columnHeadersHeight;
      if (this.AutoSize)
        this.Invalidate();
      else if (this.LayoutInfo.ColumnHeadersVisible)
      {
        this.PerformLayoutPrivate(blnInvalidInAdjustFillingColumns);
        this.Invalidate();
      }
      this.OnColumnHeadersHeightChanged(EventArgs.Empty);
    }

    /// <summary>Gets or sets a value indicating whether the height of the column headers is adjustable and whether it can be adjusted by the user or is automatically adjusted to fit the contents of the headers. </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode"></see> value indicating the mode by which the height of the column headers row can be adjusted. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode"></see> value.</exception>
    [DefaultValue(DataGridViewColumnHeadersHeightSizeMode.EnableResizing)]
    [RefreshProperties(RefreshProperties.All)]
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_ColumnHeadersHeightSizeModeDescr")]
    public DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
    {
      get => this.menmColumnHeadersHeightSizeMode;
      set
      {
        if (this.ColumnHeadersHeightSizeMode == value)
          return;
        DataGridViewAutoSizeModeEventArgs e = new DataGridViewAutoSizeModeEventArgs(this.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize);
        this.menmColumnHeadersHeightSizeMode = value;
        this.OnColumnHeadersHeightSizeModeChanged(e);
      }
    }

    /// <summary>Gets or sets a value indicating whether the column header row is displayed.</summary>
    /// <returns>true if the column headers are displayed; otherwise, false. The default is true.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is false and one or more columns have an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewColumnHeadersVisibleDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    public bool ColumnHeadersVisible
    {
      get => this.mobjDataGridViewState1[8];
      set
      {
        if (this.ColumnHeadersVisible == value)
          return;
        if (!value)
        {
          for (DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null; objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
          {
            if (objDataGridViewColumnStart.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader)
              throw new InvalidOperationException(SR.GetString("DataGridView_ColumnHeadersCannotBeInvisible"));
          }
        }
        this.mobjDataGridViewState1[8] = value;
        this.Update();
      }
    }

    /// <summary>Gets a collection that contains all the columns in the control.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> that contains all the columns in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
    /// <filterpriority>1</filterpriority>
    [MergableProperty(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public DataGridViewColumnCollection Columns
    {
      get
      {
        if (this.mobjColumns == null)
          this.mobjColumns = this.CreateColumnsInstance();
        return this.mobjColumns;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is delayed drawing.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is delayed drawing; otherwise, <c>false</c>.
    /// </value>
    protected override bool IsDelayedDrawing => true;

    private bool InAdjustFillingColumns => this.mobjDataGridViewOper[524288] || this.mobjDataGridViewOper[262144];

    /// <summary>Gets or sets the currently active cell.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that represents the current cell, or null if there is no current cell. The default is the first cell in the first column or null if there are no cells in the control.</returns>
    /// <exception cref="T:System.ArgumentException">The specified cell when setting this property is not in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">The value of this property cannot be set because changes to the current cell cannot be committed or canceled.-or-The specified cell when setting this property is in a hidden row or column. </exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public DataGridViewCell CurrentCell
    {
      get => this.mobjCurrentCellPoint.X == -1 && this.mobjCurrentCellPoint.Y == -1 ? (DataGridViewCell) null : this.Rows[this.mobjCurrentCellPoint.Y].Cells[this.mobjCurrentCellPoint.X];
      set => this.SetCurrentCell(value, false);
    }

    /// <summary>Sets the current cell.</summary>
    /// <param name="objValue">The obj value.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    internal void SetCurrentCell(DataGridViewCell objValue, bool blnClientSource)
    {
      if ((objValue == null || objValue.RowIndex == this.mobjCurrentCellPoint.Y && objValue.ColumnIndex == this.mobjCurrentCellPoint.X) && (objValue != null || this.mobjCurrentCellPoint.X == -1))
        return;
      if (objValue == null)
      {
        this.ClearSelection();
        if (!this.SetCurrentCellAddressCore(-1, -1, true, true, false))
          throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
      }
      else
      {
        if (objValue.DataGridView != this)
          throw new ArgumentException(SR.GetString("DataGridView_CellDoesNotBelongToDataGridView"));
        if (!this.Columns[objValue.ColumnIndex].Visible || (this.Rows.GetRowState(objValue.RowIndex) & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
          throw new InvalidOperationException(SR.GetString("DataGridView_CurrentCellCannotBeInvisible"));
        if (!this.IsInnerCellOutOfBounds(objValue.ColumnIndex, objValue.RowIndex))
        {
          this.ClearSelection(objValue.ColumnIndex, objValue.RowIndex, true, blnClientSource);
          if (!this.SetCurrentCellAddressCore(objValue.ColumnIndex, objValue.RowIndex, true, false, false, blnClientSource))
            throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
        }
        if (!blnClientSource)
        {
          this.PerformScrollIntoView(objValue, false);
          if (this.UseInternalPaging)
            this.CurrentPage = this.GetCellPageNumber(objValue);
        }
      }
      if (blnClientSource)
        return;
      this.UpdateParams(AttributeType.Visual);
    }

    /// <summary>Scrolls cell into view.</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    public virtual void ScrollIntoView(DataGridViewCell objDataGridViewCell)
    {
      if (objDataGridViewCell == null || objDataGridViewCell.DataGridView == null || objDataGridViewCell.DataGridView != this)
        return;
      if (this.UseInternalPaging)
      {
        int num = objDataGridViewCell.RowIndex / this.ItemsPerPage + 1;
        if (num > 0 && num <= this.TotalPages)
          this.CurrentPage = num;
      }
      this.PerformScrollIntoView(objDataGridViewCell, false);
    }

    /// <summary>Performs scroll into view.</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="blnHidePopups">if set to <c>true</c> [BLN hide popups].</param>
    internal void PerformScrollIntoView(DataGridViewCell objDataGridViewCell, bool blnHidePopups)
    {
      if (objDataGridViewCell == null || !(this.Context is IContextMethodInvoker context))
        return;
      object[] objArray = new object[3]
      {
        (object) this.ID,
        (object) objDataGridViewCell.MemberIDInternal.ToString(),
        blnHidePopups ? (object) "1" : (object) "0"
      };
      context.InvokeMethod((ISkinable) this, InvokationUniqueness.Component, "DataGridView_PerformScrollIntoView", objArray);
    }

    /// <summary>Gets the cell page number.</summary>
    /// <param name="objDataGridViewCell">The obj data grid view cell.</param>
    /// <returns></returns>
    private int GetCellPageNumber(DataGridViewCell objDataGridViewCell) => objDataGridViewCell.RowIndex / this.ItemsPerPage + 1;

    /// <summary>Gets the paged rows.</summary>
    /// <param name="blnPageContainsFrozenRows">if set to <c>true</c> [BLN page contains frozen rows].</param>
    /// <returns></returns>
    private IList GetPagedRows(out bool blnPageContainsFrozenRows)
    {
      blnPageContainsFrozenRows = false;
      DataGridViewRowCollection rows = this.Rows;
      if (!this.UseInternalPaging)
        return (IList) rows;
      List<DataGridViewRow> pagedRows = new List<DataGridViewRow>();
      int num1 = (this.CurrentPage - 1) * this.ItemsPerPage;
      int index = 0;
      int num2 = -1;
      for (int count = rows.Count; index < count && pagedRows.Count < this.ItemsPerPage; ++index)
      {
        if (rows[index].Visible)
        {
          ++num2;
          if (num2 >= num1)
          {
            DataGridViewRow dataGridViewRow = rows[index];
            if (dataGridViewRow != null)
            {
              if (dataGridViewRow.Frozen)
                blnPageContainsFrozenRows = true;
              pagedRows.Add(dataGridViewRow);
            }
          }
        }
      }
      return (IList) pagedRows;
    }

    /// <summary>
    /// Determines whether [is inner cell out of bounds] [the specified column index].
    /// </summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns>
    /// 	<c>true</c> if [is inner cell out of bounds] [the specified column index]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsInnerCellOutOfBounds(int intColumnIndex, int intRowIndex) => intColumnIndex >= this.Columns.Count || intRowIndex >= this.Rows.Count || intColumnIndex == -1 || intRowIndex == -1;

    /// <summary>
    /// Gets a value indicating whether datagridview or any of its columns autosizemode set to fill.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [need to adjust filling columns]; otherwise, <c>false</c>.
    /// </value>
    internal bool NeedToAdjustFillingColumns
    {
      get
      {
        bool flag = this.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill;
        foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
        {
          if (column.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || flag && column.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
            return true;
        }
        return false;
      }
    }

    /// <summary>
    /// Gets a value indicating whether [single vertical border added].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [single vertical border added]; otherwise, <c>false</c>.
    /// </value>
    internal bool SingleVerticalBorderAdded
    {
      get
      {
        if (this.mobjLayoutInfo.RowHeadersVisible)
          return false;
        return this.AdvancedCellBorderStyle.All == DataGridViewAdvancedCellBorderStyle.Single || this.CellBorderStyle == DataGridViewCellBorderStyle.SingleVertical;
      }
    }

    /// <summary>
    /// Gets a value indicating whether [single horizontal border added].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [single horizontal border added]; otherwise, <c>false</c>.
    /// </value>
    internal bool SingleHorizontalBorderAdded
    {
      get
      {
        if (this.mobjLayoutInfo.ColumnHeadersVisible)
          return false;
        return this.AdvancedCellBorderStyle.All == DataGridViewAdvancedCellBorderStyle.Single || this.CellBorderStyle == DataGridViewCellBorderStyle.SingleHorizontal;
      }
    }

    /// <summary>Gets the row and column indexes of the currently active cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Point"></see> that represents the row and column indexes of the currently active cell.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public Point CurrentCellAddress => this.CurrentCellPoint;

    /// <summary>Gets the row containing the current cell.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that represents the row containing the current cell, or null if there is no current cell.</returns>
    [Browsable(false)]
    public DataGridViewRow CurrentRow => this.mobjCurrentCellPoint.X == -1 ? (DataGridViewRow) null : this.Rows[this.mobjCurrentCellPoint.Y];

    /// <summary>Gets or sets the name of the list or table in the data source for which the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is displaying data.</summary>
    /// <returns>The name of the table or list in the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> for which the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is displaying data. The default is <see cref="F:System.String.Empty"></see>.</returns>
    /// <exception cref="T:System.Exception">An error occurred in the data source and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [DefaultValue("")]
    [SRCategory("CatData")]
    [SRDescription("DataGridViewDataMemberDescr")]
    public string DataMember
    {
      get => this.DataConnection == null ? string.Empty : this.DataConnection.DataMember;
      set
      {
        if (!(value != this.DataMember))
          return;
        this.CurrentCell = (DataGridViewCell) null;
        if (this.DataConnection == null)
          this.DataConnection = new DataGridView.DataGridViewDataConnection(this);
        this.DataConnection.SetDataConnection(this.DataSource, value);
        this.OnDataMemberChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets a value indicating whether [lazy mode].</summary>
    /// <value><c>true</c> if [lazy mode]; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    [SRCategory("CatData")]
    [SRDescription("DataGridViewLazyModeDescr")]
    public bool LazyMode
    {
      get => this.mblnLazyMode;
      set => this.mblnLazyMode = value;
    }

    /// <summary>Gets or sets the data source that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is displaying data for.</summary>
    /// <returns>The object that contains data for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> to display.</returns>
    /// <exception cref="T:System.Exception">An error occurred in the data source and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewDataSourceDescr")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRCategory("CatData")]
    [DefaultValue(null)]
    [AttributeProvider(typeof (Binding.IDataSourceAttributeProvider))]
    public object DataSource
    {
      get => this.DataConnection == null ? (object) null : this.DataConnection.DataSource;
      set
      {
        if (value == this.DataSource)
          return;
        this.CurrentCell = (DataGridViewCell) null;
        if (this.DataConnection == null)
        {
          this.DataConnection = new DataGridView.DataGridViewDataConnection(this);
          this.DataConnection.SetDataConnection(value, this.DataMember);
        }
        else
        {
          if (this.DataConnection.ShouldChangeDataMember(value))
            this.DataMember = "";
          this.DataConnection.SetDataConnection(value, this.DataMember);
          if (value == null)
            this.DataConnection = (DataGridView.DataGridViewDataConnection) null;
        }
        this.OnDataSourceChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets the default background brush.</summary>
    /// <value>The default background brush.</value>
    private static SolidBrush DefaultBackgroundBrush => (SolidBrush) SystemBrushes.AppWorkspace;

    /// <summary>Gets the default back brush.</summary>
    /// <value>The default back brush.</value>
    private static SolidBrush DefaultBackBrush => (SolidBrush) SystemBrushes.Window;

    /// <summary>Gets the default fore brush.</summary>
    /// <value>The default fore brush.</value>
    private static SolidBrush DefaultForeBrush => (SolidBrush) SystemBrushes.WindowText;

    /// <summary>Gets the default headers back brush.</summary>
    /// <value>The default headers back brush.</value>
    private static SolidBrush DefaultHeadersBackBrush => (SolidBrush) SystemBrushes.Control;

    /// <summary>Gets the default selection back brush.</summary>
    /// <value>The default selection back brush.</value>
    private static SolidBrush DefaultSelectionBackBrush => (SolidBrush) SystemBrushes.Highlight;

    /// <summary>Gets the default selection fore brush.</summary>
    /// <value>The default selection fore brush.</value>
    private static SolidBrush DefaultSelectionForeBrush => (SolidBrush) SystemBrushes.HighlightText;

    /// <summary>Gets or sets the default cell style to be applied to the cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> if no other cell style properties are set.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_DefaultCellStyleDescr")]
    [AmbientValue(null)]
    public DataGridViewCellStyle DefaultCellStyle
    {
      get
      {
        if (this.mobjDefaultCellStyle == null)
        {
          this.mobjDefaultCellStyle = this.DefaultDefaultCellStyle;
          return this.mobjDefaultCellStyle;
        }
        if (this.mobjDefaultCellStyle.BackColor != Color.Empty && this.mobjDefaultCellStyle.ForeColor != Color.Empty && this.mobjDefaultCellStyle.SelectionBackColor != Color.Empty && this.mobjDefaultCellStyle.SelectionForeColor != Color.Empty && this.mobjDefaultCellStyle.Font != null && this.mobjDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet && this.mobjDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet)
          return this.mobjDefaultCellStyle;
        DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle(this.mobjDefaultCellStyle);
        defaultCellStyle.Scope = DataGridViewCellStyleScopes.None;
        if (this.mobjDefaultCellStyle.BackColor == Color.Empty)
          defaultCellStyle.BackColor = DataGridView.DefaultBackBrush.Color;
        if (this.mobjDefaultCellStyle.ForeColor == Color.Empty)
        {
          defaultCellStyle.ForeColor = base.ForeColor;
          this.mobjDataGridViewState1[1024] = true;
        }
        if (this.mobjDefaultCellStyle.SelectionBackColor == Color.Empty)
          defaultCellStyle.SelectionBackColor = DataGridView.DefaultSelectionBackBrush.Color;
        if (this.mobjDefaultCellStyle.SelectionForeColor == Color.Empty)
          defaultCellStyle.SelectionForeColor = DataGridView.DefaultSelectionForeBrush.Color;
        if (this.mobjDefaultCellStyle.Font == null)
        {
          defaultCellStyle.Font = base.Font;
          this.mobjDataGridViewState1[33554432] = true;
        }
        if (this.mobjDefaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet)
          defaultCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleLeft;
        if (this.mobjDefaultCellStyle.WrapMode == DataGridViewTriState.NotSet)
          defaultCellStyle.WrapModeInternal = DataGridViewTriState.False;
        defaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.DataGridView);
        return defaultCellStyle;
      }
      set
      {
        DataGridViewCellStyle defaultCellStyle = this.DefaultCellStyle;
        defaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.DataGridView);
        this.mobjDefaultCellStyle = value;
        if (value != null)
          this.mobjDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.DataGridView);
        DataGridViewCellStyleDifferences differencesFrom = defaultCellStyle.GetDifferencesFrom(this.DefaultCellStyle);
        if (differencesFrom == DataGridViewCellStyleDifferences.None)
          return;
        this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
        this.OnDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
      }
    }

    /// <summary>
    /// To be able to get the DefaultDefaultCellStyle from outside.
    /// </summary>
    internal DataGridViewCellStyle DefaultDefaultCellStyleInternal => this.DefaultDefaultCellStyle;

    /// <summary>Gets the default default cell style.</summary>
    /// <value>The default default cell style.</value>
    private DataGridViewCellStyle DefaultDefaultCellStyle
    {
      get
      {
        DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
        defaultCellStyle.BackColor = DataGridView.DefaultBackBrush.Color;
        defaultCellStyle.ForeColor = base.ForeColor;
        defaultCellStyle.SelectionBackColor = DataGridView.DefaultSelectionBackBrush.Color;
        defaultCellStyle.SelectionForeColor = DataGridView.DefaultSelectionForeBrush.Color;
        defaultCellStyle.Font = base.Font;
        defaultCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleLeft;
        defaultCellStyle.WrapModeInternal = DataGridViewTriState.False;
        defaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.DataGridView);
        this.mobjDataGridViewState1[33554432] = true;
        this.mobjDataGridViewState1[1024] = true;
        return defaultCellStyle;
      }
    }

    /// <summary>Gets the default initial size of the control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> representing the initial size of the control, which is 240 pixels wide by 150 pixels high.</returns>
    protected override Size DefaultSize => new Size(240, 150);

    /// <summary>Gets the panel that contains the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Panel"></see> that contains the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public Panel EditingPanel => (Panel) null;

    /// <summary>Gets or sets a value indicating how to begin editing a cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewEditMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewEditMode"></see> value.</exception>
    /// <exception cref="T:System.Exception">The specified value when setting this property would cause the control to enter edit mode, but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DataGridViewEditMode.EditOnKeystrokeOrF2)]
    [SRDescription("DataGridView_EditModeDescr")]
    [SRCategory("CatBehavior")]
    public DataGridViewEditMode EditMode
    {
      get => this.menmEditMode;
      set
      {
        if (this.menmEditMode == value)
          return;
        this.menmEditMode = value;
        this.OnEditModeChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets a value indicating whether row and column headers use the visual styles of the user's current theme if visual styles are enabled for the application.</summary>
    /// <returns>true if visual styles are enabled for the headers; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_EnableHeadersVisualStylesDescr")]
    [DefaultValue(true)]
    public bool EnableHeadersVisualStyles
    {
      get => this.mobjDataGridViewState2[64];
      set
      {
        if (this.mobjDataGridViewState2[64] == value)
          return;
        this.mobjDataGridViewState2[64] = value;
        this.OnGlobalAutoSize();
      }
    }

    /// <summary>Gets or sets the first cell currently displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>; typically, this cell is in the upper left corner.</summary>
    /// <returns>The first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> currently displayed in the control.</returns>
    /// <exception cref="T:System.ArgumentException">The specified cell when setting this property is not is not in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">The specified cell when setting this property has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> or <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property value of -1, indicating that it is a header cell or a shared cell. -or-The specified cell when setting this property has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Visible"></see> property value of false.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataGridViewCell FirstDisplayedCell
    {
      get
      {
        if (this.Rows.Count > 0)
        {
          DataGridViewRow dataGridViewRow = (DataGridViewRow) null;
          IEnumerator enumerator = this.PageRows.GetEnumerator();
          try
          {
            if (enumerator.MoveNext())
              dataGridViewRow = (DataGridViewRow) enumerator.Current;
          }
          finally
          {
            if (enumerator is IDisposable disposable)
              disposable.Dispose();
          }
          if (dataGridViewRow != null && dataGridViewRow.Cells.Count > 0)
            return dataGridViewRow.Cells[0];
        }
        return (DataGridViewCell) null;
      }
      set
      {
      }
    }

    /// <summary>Gets the width of the portion of the column that is currently scrolled out of view..</summary>
    /// <returns>The width of the portion of the column that is scrolled out of view.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public int FirstDisplayedScrollingColumnHiddenWidth => -1;

    /// <summary>Gets or sets the font of the text displayed by the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <returns>The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the control. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultFont"></see> property.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public override Font Font
    {
      get => base.Font;
      set => base.Font = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [disable navigation].
    /// </summary>
    /// <value><c>true</c> if [disable navigation]; otherwise, <c>false</c>.</value>
    [SRDescription("DataGridView_DisableNavigation")]
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    public bool DisableNavigation
    {
      get => this.mblnDisableNavigation;
      set
      {
        if (this.DisableNavigation == value)
          return;
        this.mblnDisableNavigation = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the foreground color of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultForeColor"></see> property.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    /// <summary>Gets or sets the color of the grid lines separating the cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> or <see cref="T:System.Drawing.SystemColors"></see> that represents the color of the grid lines. The default is <see cref="F:System.Drawing.KnownColor.ControlDarkDark"></see>.</returns>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:System.Drawing.Color.Empty"></see>. -or-The specified value when setting this property has a <see cref="P:System.Drawing.Color.A"></see> property value that is less that 255.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridViewGridColorDescr")]
    public Color GridColor
    {
      get => this.mobjGridColor;
      set => this.mobjGridColor = value;
    }

    /// <summary>Resets the color of the grid.</summary>
    private void ResetGridColor()
    {
      if (SkinFactory.GetSkin((ISkinable) this) is DataGridViewSkin skin)
        this.GridColor = skin.GridLinesColor;
      else
        this.GridColor = SystemColors.ControlDark;
    }

    /// <summary>Gets a value indicating whether the current cell has uncommitted changes.</summary>
    /// <returns>true if the current cell has uncommitted changes; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public bool IsCurrentCellDirty => this.mobjDataGridViewState1[131072];

    /// <summary>Gets or sets the max filter options.</summary>
    /// <value>The max filter options.</value>
    [DefaultValue(100)]
    public int MaxFilterOptions
    {
      get => this.mintMaxFilterOptions;
      set
      {
        if (this.mintMaxFilterOptions == value || value <= 0)
          return;
        this.mintMaxFilterOptions = value;
        if (this.mobjDataGridViewFilterRow == null)
          return;
        for (int index = 0; index < this.mobjDataGridViewFilterRow.Cells.Count; ++index)
        {
          if (this.Columns[index].Visible)
            (this.mobjDataGridViewFilterRow.Cells[index] as DataGridViewFilterCell).RefreshFilterCell();
        }
      }
    }

    /// <summary>Gets or sets the unedited formatted value.</summary>
    /// <value>The unedited formatted value.</value>
    private object UneditedFormattedValue
    {
      get => this.mobjUneditedFormattedValue;
      set => this.mobjUneditedFormattedValue = value;
    }

    /// <summary>Sets the is current cell dirty internal.</summary>
    /// <param name="blnDirty">if set to <c>true</c> [BLN dirty].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    private void SetIsCurrentCellDirtyInternal(bool blnDirty, bool blnClientSource)
    {
      if (blnDirty == this.mobjDataGridViewState1[131072])
        return;
      this.mobjDataGridViewState1[131072] = blnDirty;
      this.OnCurrentCellDirtyStateChanged(EventArgs.Empty, blnClientSource);
    }

    /// <summary>
    /// Sets a value indicating whether this instance is current cell dirty internal.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is current cell dirty internal; otherwise, <c>false</c>.
    /// </value>
    private bool IsCurrentCellDirtyInternal
    {
      set => this.SetIsCurrentCellDirtyInternal(value, false);
    }

    /// <summary>Gets a value indicating whether the currently active cell is being edited.</summary>
    /// <returns>true if the current cell is being edited; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public bool IsCurrentCellInEditMode => this.EditingControl != null || this.mobjDataGridViewState1[32768];

    /// <summary>Gets a value indicating whether the current row has uncommitted changes.</summary>
    /// <returns>true if the current row has uncommitted changes; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public bool IsCurrentRowDirty
    {
      get
      {
        if (!this.VirtualMode)
          return this.mobjDataGridViewState1[262144] || this.IsCurrentCellDirty;
        QuestionEventArgs e = new QuestionEventArgs(this.mobjDataGridViewState1[262144] || this.IsCurrentCellDirty);
        this.OnRowDirtyStateNeeded(e);
        return e.Response;
      }
    }

    /// <summary>Gets or sets the data connection.</summary>
    /// <value>The data connection.</value>
    internal DataGridView.DataGridViewDataConnection DataConnection
    {
      get => this.mobjDataConnection;
      set => this.mobjDataConnection = value;
    }

    /// <summary>Gets or sets the cell located at the intersection of the row with the specified index and the column with the specified name. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> at the specified location.</returns>
    /// <param name="strColumnName">The name of the column containing the cell.</param>
    /// <param name="intRowIndex">The index of the row containing the cell.</param>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public DataGridViewCell this[string strColumnName, int intRowIndex]
    {
      get => this.Rows[intRowIndex].Cells[strColumnName];
      set => this.Rows[intRowIndex].Cells[strColumnName] = value;
    }

    /// <summary>Gets or sets the cell located at the intersection of the row and column with the specified indexes. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> at the specified location.</returns>
    /// <param name="intColumnIndex">The index of the column containing the cell.</param>
    /// <param name="intRowIndex">The index of the row containing the cell.</param>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public DataGridViewCell this[int intColumnIndex, int intRowIndex]
    {
      get => this.Rows[intRowIndex].Cells[intColumnIndex];
      set => this.Rows[intRowIndex].Cells[intColumnIndex] = value;
    }

    /// <summary>Gets or sets a value indicating whether the user is allowed to select more than one cell, row, or column of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> at a time.</summary>
    /// <returns>true if the user can select more than one cell, row, or column at a time; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    [SRDescription("DataGridView_MultiSelectDescr")]
    public bool MultiSelect
    {
      get => this.mobjDataGridViewState1[128];
      set
      {
        if (this.MultiSelect == value)
          return;
        this.ClearSelection();
        this.mobjDataGridViewState1[128] = value;
        this.OnMultiSelectChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets the index of the row for new records.</summary>
    /// <returns>The index of the row for new records, or -1 if <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is false.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int NewRowIndex
    {
      get => this.mintNewRowIndex;
      set => this.mintNewRowIndex = value;
    }

    /// <summary>This property is not relevant for this control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> instance.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>Gets a value indicating whether the user can edit the cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <returns>true if the user cannot edit the cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is true, the current cell is in edit mode, and the current cell contains changes that cannot be committed. </exception>
    /// <exception cref="T:System.Exception">The specified value when setting this property would cause the control to enter edit mode, but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ReadOnlyDescr")]
    [DefaultValue(false)]
    [Browsable(true)]
    [SRCategory("CatBehavior")]
    public bool ReadOnly
    {
      get => this.mobjDataGridViewState1[1048576];
      set
      {
        if (value == this.mobjDataGridViewState1[1048576])
          return;
        if (this.IsCurrentCellInEditMode)
          throw new InvalidOperationException(SR.GetString("DataGridView_CommitFailedCannotCompleteOperation"));
        this.mobjDataGridViewState1[1048576] = value;
        if (value)
        {
          try
          {
            this.mobjDataGridViewOper[16384] = true;
            for (int intColumnIndex = 0; intColumnIndex < this.Columns.Count; ++intColumnIndex)
              this.SetReadOnlyColumnCore(intColumnIndex, false);
            int count = this.Rows.Count;
            for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
              this.SetReadOnlyRowCore(intRowIndex, false);
          }
          finally
          {
            this.mobjDataGridViewOper[16384] = false;
          }
        }
        this.OnReadOnlyChanged(EventArgs.Empty);
        this.Update();
      }
    }

    internal void SetReadOnlyColumnCore(int intColumnIndex, bool blnReadOnly)
    {
      if (this.Columns[intColumnIndex].ReadOnly != blnReadOnly)
      {
        if (blnReadOnly)
        {
          try
          {
            this.mobjDataGridViewOper[16384] = true;
            this.RemoveIndividualReadOnlyCellsInColumn(intColumnIndex);
          }
          finally
          {
            this.mobjDataGridViewOper[16384] = false;
          }
          this.Columns[intColumnIndex].ReadOnlyInternal = true;
        }
        else
          this.Columns[intColumnIndex].ReadOnlyInternal = false;
      }
      else
      {
        if (blnReadOnly)
          return;
        this.RemoveIndividualReadOnlyCellsInColumn(intColumnIndex);
      }
    }

    private void RemoveIndividualReadOnlyCellsInColumn(int intColumnIndex)
    {
      DataGridViewCellLinkedList individualReadOnlyCells = this.IndividualReadOnlyCells;
      int index = 0;
      while (index < individualReadOnlyCells.Count)
      {
        DataGridViewCell dataGridViewCell = individualReadOnlyCells[index];
        if (dataGridViewCell.ColumnIndex == intColumnIndex)
          this.SetReadOnlyCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, false);
        else
          ++index;
      }
    }

    internal void SetReadOnlyRowCore(int intRowIndex, bool blnReadOnly)
    {
      DataGridViewRowCollection rows = this.Rows;
      if ((rows.GetRowState(intRowIndex) & DataGridViewElementStates.ReadOnly) != 0 != blnReadOnly)
      {
        if (blnReadOnly)
        {
          try
          {
            this.mobjDataGridViewOper[16384] = true;
            this.RemoveIndividualReadOnlyCellsInRow(intRowIndex);
          }
          finally
          {
            this.mobjDataGridViewOper[16384] = false;
          }
          rows.SetRowState(intRowIndex, DataGridViewElementStates.ReadOnly, true);
        }
        else
          rows.SetRowState(intRowIndex, DataGridViewElementStates.ReadOnly, false);
      }
      else
      {
        if (blnReadOnly)
          return;
        this.RemoveIndividualReadOnlyCellsInRow(intRowIndex);
      }
    }

    private void RemoveIndividualReadOnlyCellsInRow(int intRowIndex)
    {
      DataGridViewCellLinkedList individualReadOnlyCells = this.IndividualReadOnlyCells;
      int index = 0;
      while (index < individualReadOnlyCells.Count)
      {
        DataGridViewCell dataGridViewCell = individualReadOnlyCells[index];
        if (dataGridViewCell.RowIndex == intRowIndex)
          this.SetReadOnlyCellCore(dataGridViewCell.ColumnIndex, intRowIndex, false);
        else
          ++index;
      }
    }

    internal void SetReadOnlyCellCore(int intColumnIndex, int intRowIndex, bool blnReadOnly)
    {
      DataGridViewRowCollection rows = this.Rows;
      DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
      DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
      DataGridViewCellLinkedList individualReadOnlyCells = this.IndividualReadOnlyCells;
      if (this.IsSharedCellReadOnly(dataGridViewRow.Cells[intColumnIndex], intRowIndex) != blnReadOnly)
      {
        DataGridViewCell cell1 = rows[intRowIndex].Cells[intColumnIndex];
        if (blnReadOnly)
        {
          if ((rowState & DataGridViewElementStates.ReadOnly) == DataGridViewElementStates.None && !this.Columns[intColumnIndex].ReadOnly)
          {
            individualReadOnlyCells.Add(cell1);
            cell1.ReadOnlyInternal = true;
          }
        }
        else
        {
          if (individualReadOnlyCells.Contains(cell1))
          {
            individualReadOnlyCells.Remove(cell1);
          }
          else
          {
            if (this.Columns[intColumnIndex].ReadOnly)
            {
              this.Columns[intColumnIndex].ReadOnlyInternal = false;
              for (int index = 0; index < intRowIndex; ++index)
              {
                DataGridViewCell cell2 = rows[index].Cells[intColumnIndex];
                cell2.ReadOnlyInternal = true;
                individualReadOnlyCells.Add(cell2);
              }
              for (int index = intRowIndex + 1; index < rows.Count; ++index)
              {
                DataGridViewCell cell3 = rows[index].Cells[intColumnIndex];
                cell3.ReadOnlyInternal = true;
                individualReadOnlyCells.Add(cell3);
              }
            }
            if ((rowState & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
            {
              rows.SetRowState(intRowIndex, DataGridViewElementStates.ReadOnly, false);
              for (int index = 0; index < intColumnIndex; ++index)
              {
                DataGridViewCell cell4 = rows[intRowIndex].Cells[index];
                cell4.ReadOnlyInternal = true;
                individualReadOnlyCells.Add(cell4);
              }
              for (int index = intColumnIndex + 1; index < this.Columns.Count; ++index)
              {
                DataGridViewCell cell5 = rows[intRowIndex].Cells[index];
                cell5.ReadOnlyInternal = true;
                individualReadOnlyCells.Add(cell5);
              }
            }
          }
          if (cell1.ReadOnly)
            cell1.ReadOnlyInternal = false;
        }
      }
      this.IndividualReadOnlyCells = individualReadOnlyCells;
    }

    /// <summary>Gets or sets the current page internal.</summary>
    /// <value>The current page internal.</value>
    private int CurrentPageInternal
    {
      get => this.mintCurrentPage;
      set => this.mintCurrentPage = value;
    }

    /// <summary>Gets or sets the items per page internal.</summary>
    /// <value>The items per page internal.</value>
    private int ItemsPerPageInternal
    {
      get => this.mintItemsPerPage;
      set => this.mintItemsPerPage = value;
    }

    /// <summary>Gets or sets the virtual block size internal.</summary>
    /// <value>The virtual block size internal.</value>
    private int VirtualBlockSizeInternal
    {
      get => this.mintVirtualBlockSize;
      set => this.mintVirtualBlockSize = value;
    }

    /// <summary>Gets or sets the total pages internal.</summary>
    /// <value>The total pages internal.</value>
    private int TotalPagesInternal
    {
      get => this.mintTotalPages;
      set => this.mintTotalPages = value;
    }

    /// <summary>Occurs when the paging params have changed.</summary>
    public event EventHandler PagingChanged
    {
      add => this.AddHandler(DataGridView.PagingChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(DataGridView.PagingChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the PagingChanged event.</summary>
    private EventHandler PagingChangedHandler => (EventHandler) this.GetHandler(DataGridView.PagingChangedEvent);

    /// <summary>Clears the paging parameters</summary>
    internal void ClearPaging()
    {
      this.CurrentPageInternal = 1;
      this.TotalPagesInternal = 1;
    }

    /// <summary>Uses internal paging algorithem</summary>
    [DefaultValue(true)]
    public virtual bool UseInternalPaging
    {
      get => this.mblnUseInternalPaging;
      set
      {
        if (this.mblnUseInternalPaging == value)
          return;
        this.mblnUseInternalPaging = value;
        this.Update();
      }
    }

    /// <summary>Gets the first item's index in the current page</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("PageFirstIndex property is obsolete use FirstDisplayedRowIndex instead")]
    public int PageFirstIndex => -1;

    /// <summary>Gets the last item's index in the current page</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("PageLastIndex property is obsolete use PageRows.Count instead")]
    public int PageLastIndex => -1;

    /// <summary>Gets or sets the total items.</summary>
    /// <value></value>
    [DefaultValue(0)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("TotalItems property is obsolete use GetRowCount() instead")]
    public int TotalItems
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets the page rows.</summary>
    /// <value>The page rows.</value>
    internal IList PageRows
    {
      get
      {
        bool blnPageContainsFrozenRows = false;
        return this.GetPagedRows(out blnPageContainsFrozenRows);
      }
    }

    /// <summary>Gets or sets the current page.</summary>
    /// <value></value>
    [DefaultValue(1)]
    public int CurrentPage
    {
      get => this.CurrentPageInternal;
      set
      {
        if (value <= -1 || value > this.TotalPages)
          throw new ArgumentOutOfRangeException(nameof (CurrentPage));
        if (this.CurrentPageInternal == value)
          return;
        this.CurrentPageInternal = value;
        if (!this.UseInternalPaging)
          return;
        this.ScrollTop = 0;
        this.Update();
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is initializing.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is initializing; otherwise, <c>false</c>.
    /// </value>
    private bool IsInitializing => this.mobjDataGridViewState2[524288];

    /// <summary>Gets or sets the current page.</summary>
    /// <value></value>
    [DefaultValue(20)]
    public int ItemsPerPage
    {
      get => this.ItemsPerPageInternal;
      set
      {
        if (this.ItemsPerPageInternal == value)
          return;
        this.ItemsPerPageInternal = value > 0 ? value : throw new ArgumentOutOfRangeException("CurrentPage");
        this.ClearPaging();
        this.Update();
      }
    }

    /// <summary>Gets or sets the size of the virtual block.</summary>
    /// <value>The size of the virtual block.</value>
    [DefaultValue(20)]
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_VirtualBlockSizeDescr")]
    public int VirtualBlockSize
    {
      get => this.VirtualBlockSizeInternal;
      set
      {
        if (this.VirtualBlockSizeInternal == value)
          return;
        this.VirtualBlockSizeInternal = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof (VirtualBlockSize));
        this.Update();
      }
    }

    /// <summary>Gets or sets the total pages.</summary>
    /// <value></value>
    [DefaultValue(1)]
    public int TotalPages
    {
      get
      {
        if (!this.UseInternalPaging)
          return this.TotalPagesInternal;
        double totalVisibleItems = (double) this.TotalVisibleItems;
        return totalVisibleItems == 0.0 ? 1 : Convert.ToInt32((int) Math.Ceiling(totalVisibleItems / (double) this.ItemsPerPage));
      }
      set
      {
        if (this.UseInternalPaging)
          return;
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (TotalPages));
        if (this.TotalPagesInternal == value)
          return;
        this.TotalPagesInternal = value;
        this.Update();
      }
    }

    /// <summary>Gets the total visible rows.</summary>
    /// <value>The total visible rows.</value>
    private int TotalVisibleItems
    {
      get
      {
        int rowCount = this.Rows.GetRowCount(DataGridViewElementStates.Visible);
        if (rowCount > 0 && this.IsNewRowVisible())
          --rowCount;
        return rowCount;
      }
    }

    /// <summary>Gets the inherited editing cell style.</summary>
    /// <value>The inherited editing cell style.</value>
    private DataGridViewCellStyle InheritedEditingCellStyle => this.mobjCurrentCellPoint.X == -1 ? (DataGridViewCellStyle) null : this.CurrentCellInternal.GetInheritedStyleInternal(this.mobjCurrentCellPoint.Y);

    /// <summary>
    /// Gets a value indicating whether [right to left internal].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [right to left internal]; otherwise, <c>false</c>.
    /// </value>
    internal bool RightToLeftInternal
    {
      get
      {
        if (!this.mobjDataGridViewState2[4096])
        {
          this.mobjDataGridViewState2[2048] = this.RightToLeft == RightToLeft.Yes;
          this.mobjDataGridViewState2[4096] = true;
        }
        return this.mobjDataGridViewState2[2048];
      }
    }

    /// <summary>
    /// Gets a value indicating whether animation is enabled by default.
    /// </summary>
    /// <value><c>true</c> if animation is enabled by default; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal bool DefaultAnimationEnabled => this.AnimationEnabled;

    /// <summary>Gets or sets the number of rows displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>The number of rows to display in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is less than 0.-or-The specified value is less than 1 and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is set to true. </exception>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property is set. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(0)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public int RowCount
    {
      get => this.Rows.Count;
      set
      {
        if (this.AllowUserToAddRowsInternal)
        {
          if (value < 1)
            throw new ArgumentOutOfRangeException(nameof (RowCount), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (RowCount), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 1.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        }
        else if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (RowCount), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (RowCount), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (this.DataSource != null)
          throw new InvalidOperationException(SR.GetString("DataGridView_CannotSetRowCountOnDataBoundDataGridView"));
        DataGridViewRowCollection rows = this.Rows;
        if (value == rows.Count)
          return;
        if (value == 0)
          rows.Clear();
        else if (value < rows.Count)
        {
          while (value < rows.Count)
          {
            int count = rows.Count;
            rows.RemoveAt(count - (this.AllowUserToAddRowsInternal ? 2 : 1));
            if (rows.Count >= count)
              break;
          }
        }
        else
        {
          if (this.Columns.Count == 0)
            this.Columns.Add(this.GetDataGridViewDefaultColumn());
          int intCount = value - rows.Count;
          if (intCount <= 0)
            return;
          rows.Add(intCount);
        }
      }
    }

    /// <summary>Gets or sets the selection change count.</summary>
    /// <value>The selection change count.</value>
    private int SelectionChangeCount
    {
      get => this.mintSelectionChangeCount;
      set => this.mintSelectionChangeCount = value;
    }

    /// <summary>Gets or sets the dimension change count.</summary>
    /// <value>The dimension change count.</value>
    private int DimensionChangeCount
    {
      get => this.mintDimensionChangeCount;
      set => this.mintDimensionChangeCount = value;
    }

    /// <summary>Gets or sets the border style of the row header cells.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle"></see> values.</returns>
    /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle.Custom"></see>.</exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [DefaultValue(DataGridViewHeaderBorderStyle.None)]
    [Browsable(true)]
    [SRDescription("DataGridView_RowHeadersBorderStyleDescr")]
    public DataGridViewHeaderBorderStyle RowHeadersBorderStyle
    {
      get
      {
        switch (this.mobjAdvancedDataGridViewBorderStyle.All)
        {
          case DataGridViewAdvancedCellBorderStyle.NotSet:
            return DataGridViewHeaderBorderStyle.Custom;
          case DataGridViewAdvancedCellBorderStyle.None:
            return DataGridViewHeaderBorderStyle.None;
          case DataGridViewAdvancedCellBorderStyle.Single:
            return DataGridViewHeaderBorderStyle.Single;
          case DataGridViewAdvancedCellBorderStyle.InsetDouble:
            return DataGridViewHeaderBorderStyle.Sunken;
          case DataGridViewAdvancedCellBorderStyle.OutsetPartial:
            return DataGridViewHeaderBorderStyle.Raised;
          default:
            return DataGridViewHeaderBorderStyle.Custom;
        }
      }
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 4))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewHeaderBorderStyle));
        if (value == this.RowHeadersBorderStyle)
          return;
        if (value == DataGridViewHeaderBorderStyle.Custom)
          throw new ArgumentException(SR.GetString("DataGridView_CustomCellBorderStyleInvalid", (object) nameof (RowHeadersBorderStyle)));
        this.mobjDataGridViewOper[65536] = true;
        try
        {
          switch (value)
          {
            case DataGridViewHeaderBorderStyle.Single:
              this.mobjAdvancedDataGridViewBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
              this.OnRowHeadersBorderStyleChanged(EventArgs.Empty);
              break;
            case DataGridViewHeaderBorderStyle.Raised:
              this.mobjAdvancedDataGridViewBorderStyle.All = DataGridViewAdvancedCellBorderStyle.OutsetPartial;
              this.OnRowHeadersBorderStyleChanged(EventArgs.Empty);
              break;
            case DataGridViewHeaderBorderStyle.Sunken:
              this.mobjAdvancedDataGridViewBorderStyle.All = DataGridViewAdvancedCellBorderStyle.InsetDouble;
              this.OnRowHeadersBorderStyleChanged(EventArgs.Empty);
              break;
            case DataGridViewHeaderBorderStyle.None:
              this.mobjAdvancedDataGridViewBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
              this.OnRowHeadersBorderStyleChanged(EventArgs.Empty);
              break;
          }
        }
        finally
        {
          this.mobjDataGridViewOper[65536] = false;
        }
      }
    }

    internal DataGridViewCellStyle DefaultColumnHeadersDefaultCellStyleInternal => this.DefaultColumnHeadersDefaultCellStyle;

    internal DataGridViewCellStyle DefaultRowHeadersDefaultCellStyleInternal => this.DefaultRowHeadersDefaultCellStyle;

    private DataGridViewCellStyle DefaultColumnHeadersDefaultCellStyle
    {
      get
      {
        DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
        defaultCellStyle.BackColor = DataGridView.DefaultHeadersBackBrush.Color;
        defaultCellStyle.ForeColor = DataGridView.DefaultForeBrush.Color;
        defaultCellStyle.SelectionBackColor = DataGridView.DefaultSelectionBackBrush.Color;
        defaultCellStyle.SelectionForeColor = DataGridView.DefaultSelectionForeBrush.Color;
        defaultCellStyle.Font = base.Font;
        defaultCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleLeft;
        defaultCellStyle.WrapModeInternal = DataGridViewTriState.True;
        defaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.ColumnHeaders);
        this.mobjDataGridViewState1[67108864] = true;
        return defaultCellStyle;
      }
    }

    private DataGridViewCellStyle DefaultRowHeadersDefaultCellStyle
    {
      get
      {
        DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
        defaultCellStyle.BackColor = DataGridView.DefaultHeadersBackBrush.Color;
        defaultCellStyle.ForeColor = DataGridView.DefaultForeBrush.Color;
        defaultCellStyle.SelectionBackColor = DataGridView.DefaultSelectionBackBrush.Color;
        defaultCellStyle.SelectionForeColor = DataGridView.DefaultSelectionForeBrush.Color;
        defaultCellStyle.Font = base.Font;
        defaultCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleLeft;
        defaultCellStyle.WrapModeInternal = DataGridViewTriState.True;
        defaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.RowHeaders);
        this.mobjDataGridViewState1[134217728] = true;
        return defaultCellStyle;
      }
    }

    private DataGridViewCellStyleChangedEventArgs CellStyleChangedEventArgs
    {
      get
      {
        if (this.mobjCellStyleChangedEventArgs == null)
          this.mobjCellStyleChangedEventArgs = new DataGridViewCellStyleChangedEventArgs();
        return this.mobjCellStyleChangedEventArgs;
      }
    }

    /// <summary>Gets or sets the selected band indexes.</summary>
    /// <value>The selected band indexes.</value>
    private DataGridViewIntLinkedList SelectedBandIndexes
    {
      get => this.mobjSelectedBandIndexes;
      set => this.mobjSelectedBandIndexes = value;
    }

    /// <summary>Gets or sets the individual selected cells.</summary>
    /// <value>The individual selected cells.</value>
    private DataGridViewCellLinkedList IndividualSelectedCells
    {
      get => this.mobjIndividualSelectedCells;
      set => this.mobjIndividualSelectedCells = value;
    }

    /// <summary>Gets or sets the selected band snapshot indexes.</summary>
    /// <value>The selected band snapshot indexes.</value>
    private DataGridViewIntLinkedList SelectedBandSnapshotIndexes
    {
      get => this.mobjSelectedBandSnapshotIndexes;
      set => this.mobjSelectedBandSnapshotIndexes = value;
    }

    /// <summary>Gets or sets the default style applied to the row header cells.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the default style applied to the row header cells.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_RowHeadersDefaultCellStyleDescr")]
    [AmbientValue(null)]
    public DataGridViewCellStyle RowHeadersDefaultCellStyle
    {
      get
      {
        if (this.mobjRowHeadersDefaultCellStyle == null)
          this.mobjRowHeadersDefaultCellStyle = this.DefaultRowHeadersDefaultCellStyle;
        return this.mobjRowHeadersDefaultCellStyle;
      }
      set
      {
        DataGridViewCellStyle defaultCellStyle = this.RowHeadersDefaultCellStyle;
        defaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.RowHeaders);
        this.mobjRowHeadersDefaultCellStyle = value;
        if (value != null)
          this.mobjRowHeadersDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.RowHeaders);
        DataGridViewCellStyleDifferences differencesFrom = defaultCellStyle.GetDifferencesFrom(this.RowHeadersDefaultCellStyle);
        if (differencesFrom == DataGridViewCellStyleDifferences.None)
          return;
        this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
        this.OnRowHeadersDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the column that contains row headers is displayed.
    /// </summary>
    /// <value><c>true</c> if [row headers visible]; otherwise, <c>false</c>.</value>
    /// <returns>true if the column that contains row headers is displayed; otherwise, false. The default is true.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is false and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsMode"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see>.</exception>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridViewRowHeadersVisibleDescr")]
    [DefaultValue(true)]
    public bool RowHeadersVisible
    {
      get => this.mobjDataGridViewState1[16];
      set
      {
        if (this.RowHeadersVisible == value)
          return;
        this.mobjDataGridViewState1[16] = value;
        this.Update();
        if (!this.NeedToAdjustFillingColumns)
          return;
        this.ResetUIState(false, false);
      }
    }

    /// <summary>Sets the is current row dirty internal.</summary>
    /// <param name="blnDirty">if set to <c>true</c> [BLN dirty].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    internal void SetIsCurrentRowDirtyInternal(bool blnDirty, bool blnClientSource)
    {
      if (blnDirty == this.mobjDataGridViewState1[262144])
        return;
      this.mobjDataGridViewState1[262144] = blnDirty;
      if (blnClientSource || !this.RowHeadersVisible || !this.ShowEditingIcon || this.mobjCurrentCellPoint.Y < 0)
        return;
      this.InvalidateCellPrivate(this.mobjCurrentCellPoint.X, this.mobjCurrentCellPoint.Y);
    }

    /// <summary>
    /// Sets a value indicating whether this instance is current row dirty internal.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is current row dirty internal; otherwise, <c>false</c>.
    /// </value>
    internal bool IsCurrentRowDirtyInternal
    {
      set => this.SetIsCurrentRowDirtyInternal(value, false);
    }

    /// <summary>Gets or sets the layout info.</summary>
    /// <value>The layout info.</value>
    internal DataGridView.LayoutData LayoutInfo
    {
      get
      {
        DataGridView.LayoutData mobjLayoutInfo = this.mobjLayoutInfo;
        if (!mobjLayoutInfo.dirty || !this.IsHandleCreated)
          return mobjLayoutInfo;
        this.PerformLayoutPrivate(false);
        return mobjLayoutInfo;
      }
      set => this.mobjLayoutInfo = value;
    }

    /// <summary>Invalidates the cell private.</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    private void InvalidateCellPrivate(DataGridViewCell objDataGridViewCell) => this.InvalidateCell(objDataGridViewCell.ColumnIndex, objDataGridViewCell.RowIndex);

    /// <summary>Invalidates the cell private.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    private void InvalidateCellPrivate(int intColumnIndex, int intRowIndex)
    {
      if (intColumnIndex == -1 || intRowIndex == -1)
        return;
      this[intColumnIndex, intRowIndex]?.Update();
    }

    /// <summary>Gets or sets the width, in pixels, of the column that contains the row headers.</summary>
    /// <returns>The width, in pixels, of the column that contains row headers. The default is 43.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than the minimum width of 4 pixels or is greater than the maximum width of 32768 pixels.</exception>
    /// <filterpriority>1</filterpriority>
    [Localizable(true)]
    [SRDescription("DataGridView_RowHeadersWidthDescr")]
    [SRCategory("CatLayout")]
    [DefaultValue(41)]
    public int RowHeadersWidth
    {
      get => this.mintRowHeadersWidth;
      set
      {
        if (value < 4)
          throw new ArgumentOutOfRangeException(nameof (RowHeadersWidth), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (RowHeadersWidth), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 4.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (value > 32768)
          throw new ArgumentOutOfRangeException(nameof (RowHeadersWidth), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (RowHeadersWidth), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 32768.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (this.RowHeadersWidth != value)
          this.Update();
        if (this.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && this.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing || this.RowHeadersWidth == value)
          return;
        this.RowHeadersWidthInternal = value;
      }
    }

    /// <summary>Sets the row headers width internal.</summary>
    /// <value>The row headers width internal.</value>
    private int RowHeadersWidthInternal
    {
      set
      {
        this.mintRowHeadersWidth = value;
        this.OnRowHeadersWidthChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets a value indicating whether the width of the row headers is adjustable and whether it can be adjusted by the user or is automatically adjusted to fit the contents of the headers. </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value indicating the mode by which the width of the row headers can be adjusted. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value.</exception>
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("DataGridView_RowHeadersWidthSizeModeDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(DataGridViewRowHeadersWidthSizeMode.EnableResizing)]
    public DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
    {
      get => this.menmRowHeadersWidthSizeMode;
      set
      {
        DataGridViewRowHeadersWidthSizeMode headersWidthSizeMode = this.RowHeadersWidthSizeMode;
        if (this.menmRowHeadersWidthSizeMode == value)
          return;
        DataGridViewAutoSizeModeEventArgs e = new DataGridViewAutoSizeModeEventArgs(headersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && headersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing);
        this.menmRowHeadersWidthSizeMode = value;
        this.OnRowHeadersWidthSizeModeChanged(e);
      }
    }

    /// <summary>Gets a collection that contains all the rows in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> that contains all the rows in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public DataGridViewRowCollection Rows
    {
      get
      {
        if (this.mobjRows == null)
          this.mobjRows = this.CreateRowsInstance();
        return this.mobjRows;
      }
    }

    /// <summary>Gets the hierarchic infos.</summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ObservableCollection<HierarchicInfo> HierarchicInfos
    {
      get
      {
        if (this.mobjHierarchicInfos == null)
          this.HierarchicInfos = new ObservableCollection<HierarchicInfo>();
        return this.mobjHierarchicInfos;
      }
      set
      {
        if (this.mobjHierarchicInfos == value)
          return;
        if (this.mobjHierarchicInfos != null)
          this.AddRemoveHierarchicInfosEvents(false);
        this.mobjHierarchicInfos = value;
        if (this.mobjHierarchicInfos == null)
          return;
        if (!(this is HierarchicDataGridView))
        {
          this.RootGrid = this;
          this.mintHierarchyLevel = 0;
        }
        this.AddRemoveHierarchicInfosEvents(true);
        this.ResetDataBinding();
      }
    }

    /// <summary>Gets or sets the system hierarchic infos.</summary>
    /// <value>The system hierarchic infos.</value>
    internal ObservableCollection<HierarchicInfo> SystemHierarchicInfos
    {
      get
      {
        if (this.mobjSystemHierarchicInfos == null)
          this.SystemHierarchicInfos = new ObservableCollection<HierarchicInfo>();
        return this.mobjSystemHierarchicInfos;
      }
      set
      {
        if (this.mobjSystemHierarchicInfos == value)
          return;
        this.mobjSystemHierarchicInfos = value;
        if (this is HierarchicDataGridView)
          return;
        this.RootGrid = this;
        this.mintHierarchyLevel = 0;
      }
    }

    /// <summary>Gets or sets the data groups.</summary>
    /// <value>The data groups.</value>
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewGroupingColumnsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public UniqueObservableCollection<string> GroupingColumns
    {
      get
      {
        if (this.mobjGroupingColumns == null)
          this.GroupingColumns = new UniqueObservableCollection<string>();
        return this.mobjGroupingColumns;
      }
      set
      {
        if (value == this.mobjGroupingColumns)
          return;
        if (this.mobjGroupingColumns != null)
          this.AddRemoveGroupingColumnEvents(false);
        this.mobjGroupingColumns = value;
        this.AddRemoveGroupingColumnEvents(true);
      }
    }

    /// <summary>Add or remove hierarchic infos events.</summary>
    /// <param name="blnIsAdd">if set to <c>true</c> [BLN is add].</param>
    private void AddRemoveHierarchicInfosEvents(bool blnIsAdd)
    {
      if (blnIsAdd)
      {
        this.mobjHierarchicInfos.CollectionChanged += new NotifyCollectionChangedEventHandler(this.mobjHierarchicInfos_CollectionChanged);
        if (this.mobjHierarchicInfos.Count <= 0)
          return;
        this.mobjHierarchicInfos[0].PropertyChanged += new PropertyChangedEventHandler(this.objHierarchicInfo_PropertyChanged);
      }
      else
      {
        this.mobjHierarchicInfos.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.mobjHierarchicInfos_CollectionChanged);
        if (this.mobjHierarchicInfos.Count <= 0)
          return;
        this.mobjHierarchicInfos[0].PropertyChanged -= new PropertyChangedEventHandler(this.objHierarchicInfo_PropertyChanged);
      }
    }

    /// <summary>
    /// Handles the PropertyChanged event of the objHierarchicInfo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
    private void objHierarchicInfo_PropertyChanged(object sender, PropertyChangedEventArgs e) => this.ResetDataBinding();

    /// <summary>
    /// Handles the CollectionChanged event of the mobjHierarchicInfos control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
    private void mobjHierarchicInfos_CollectionChanged(
      object sender,
      NotifyCollectionChangedEventArgs e)
    {
      switch (e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          if (this.mobjHierarchicInfos.Count == e.NewItems.Count)
          {
            foreach (DataGridViewBand column in (BaseCollection) this.Columns)
            {
              if (column.Frozen)
                throw new Exception("DataGridView does not support hierarchies with frozen columns");
            }
          }
          IEnumerator enumerator1 = e.NewItems.GetEnumerator();
          try
          {
            while (enumerator1.MoveNext())
            {
              HierarchicInfo current = (HierarchicInfo) enumerator1.Current;
              if (e.NewStartingIndex == 0)
                current.PropertyChanged += new PropertyChangedEventHandler(this.objHierarchicInfo_PropertyChanged);
            }
            break;
          }
          finally
          {
            if (enumerator1 is IDisposable disposable)
              disposable.Dispose();
          }
        case NotifyCollectionChangedAction.Remove:
          IEnumerator enumerator2 = e.OldItems.GetEnumerator();
          try
          {
            while (enumerator2.MoveNext())
            {
              HierarchicInfo current = (HierarchicInfo) enumerator2.Current;
              if (e.OldStartingIndex == 0)
                current.PropertyChanged -= new PropertyChangedEventHandler(this.objHierarchicInfo_PropertyChanged);
            }
            break;
          }
          finally
          {
            if (enumerator2 is IDisposable disposable)
              disposable.Dispose();
          }
      }
      this.ResetDataBinding();
    }

    /// <summary>Resets the data binding.</summary>
    internal void ResetDataBinding()
    {
      if (this.IsLayoutSuspended)
        return;
      this.mstrFilterTemplate = (string) null;
      this.mobjRealFilteringDataMemberIndexByProposedFilteringDataMember = (Dictionary<string, string>) null;
      if (this.DataSource != null && this.DataSource is BindingSource)
        (this.DataSource as BindingSource).ResetBindings(true);
      this.InitializeSystemHierarchicInfos();
    }

    /// <summary>Gets or sets the default style applied to the row cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to apply to the row cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_RowsDefaultCellStyleDescr")]
    public DataGridViewCellStyle RowsDefaultCellStyle
    {
      get
      {
        if (this.mobjRowsDefaultCellStyle == null)
        {
          this.mobjRowsDefaultCellStyle = new DataGridViewCellStyle();
          this.mobjRowsDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.Rows);
        }
        return this.mobjRowsDefaultCellStyle;
      }
      set
      {
        this.mobjRowsDefaultCellStyle = this.RowsDefaultCellStyle;
        this.mobjRowsDefaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.Rows);
        this.mobjRowsDefaultCellStyle = value;
        if (value != null)
          this.mobjRowsDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.Rows);
        DataGridViewCellStyleDifferences differencesFrom = this.mobjRowsDefaultCellStyle.GetDifferencesFrom(this.RowsDefaultCellStyle);
        if (differencesFrom == DataGridViewCellStyleDifferences.None)
          return;
        this.CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
        this.OnRowsDefaultCellStyleChanged((EventArgs) this.CellStyleChangedEventArgs);
      }
    }

    /// <summary>Gets or sets the latest editing control.</summary>
    /// <value>The latest editing control.</value>
    private Control LatestEditingControl
    {
      get => this.mobjLatestEditingControl;
      set => this.mobjLatestEditingControl = value;
    }

    /// <summary>Gets or sets the row that represents the template for all the rows in the control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> representing the row template.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified row when setting this property has its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property set.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatAppearance")]
    [Browsable(true)]
    [SRDescription("DataGridView_RowTemplateDescr")]
    public DataGridViewRow RowTemplate
    {
      get
      {
        if (this.mobjRowTemplate == null)
          this.mobjRowTemplate = new DataGridViewRow();
        return this.mobjRowTemplate;
      }
      set
      {
        DataGridViewRow dataGridViewRow = value;
        this.mobjRowTemplate = dataGridViewRow == null || dataGridViewRow.DataGridView == null ? dataGridViewRow : throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
      }
    }

    internal DataGridViewRow RowTemplateClone
    {
      get
      {
        DataGridViewRow objDataGridViewRow = (DataGridViewRow) this.RowTemplate.Clone();
        this.CompleteCellsCollection(objDataGridViewRow);
        return objDataGridViewRow;
      }
    }

    /// <summary>Gets or sets the type of scroll bars to display for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollBars"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ScrollBars.Both"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.ScrollBars"></see> value. </exception>
    /// <exception cref="T:System.InvalidOperationException">The value of this property cannot be set because the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is unable to scroll due to a cell change that cannot be committed or canceled. </exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatLayout")]
    [DefaultValue(ScrollBars.Both)]
    [Localizable(true)]
    [SRDescription("DataGridView_ScrollBarsDescr")]
    public ScrollBars ScrollBars
    {
      get => this.menmScrollBars;
      set
      {
        if (this.menmScrollBars == value)
          return;
        this.menmScrollBars = value;
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets or sets a value indicating whether to show cell errors.</summary>
    /// <returns>true if a red glyph will appear in a cell that fails validation; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ShowCellErrorsDescr")]
    [DefaultValue(true)]
    [SRCategory("CatAppearance")]
    public bool ShowCellErrors
    {
      get => this.mobjDataGridViewState2[128];
      set
      {
        if (this.ShowCellErrors == value)
          return;
        this.mobjDataGridViewState2[128] = value;
        if (this.DesignMode)
          return;
        this.OnGlobalAutoSize();
      }
    }

    /// <summary>Gets the grouping area style properties.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public GroupingAreaStyleProperties GroupingAreaStyleProperties => new GroupingAreaStyleProperties(this);

    /// <summary>
    /// Gets or sets a value indicating whether to [show grouping drop area].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [show grouping drop area]; otherwise, <c>false</c>.
    /// </value>
    [Description("Gets or sets a value indicating whether to show the grouping drop area.")]
    [DefaultValue(false)]
    [Category("CatAppearance")]
    public bool ShowGroupingDropArea
    {
      get => this.mblnShowGroupingDropArea;
      set
      {
        if (this.mblnShowGroupingDropArea == value)
          return;
        this.mblnShowGroupingDropArea = !value || !this.AllowUserToOrderColumns ? value : throw new InvalidOperationException("Columns reordering and grouping are not supported simultaneously.");
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether grouping columns should be hidden.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [hide grouping columns]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool HideGroupedColumns
    {
      get => this.mblnHideGroupedColumns;
      set
      {
        if (this.mblnHideGroupedColumns == value)
          return;
        this.mblnHideGroupedColumns = value;
        this.SwitchPreRenderUpdate(DataGridView.PreRenderUpdateType.GroupingData);
        this.Update();
      }
    }

    /// <summary>Gets or sets the backcolor of the grouping area.</summary>
    /// <value>The backcolor of the grouping area.</value>
    internal Color GroupingAreaBackColor
    {
      get => this.mobjGroupingAreaBackColor;
      set
      {
        if (!(this.mobjGroupingAreaBackColor != value))
          return;
        this.mobjGroupingAreaBackColor = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the height of the grouping area.</summary>
    /// <value>The height of the grouping area.</value>
    internal int GroupingAreaHeight
    {
      get => this.mintGroupingAreaHeight;
      set
      {
        if (this.mintGroupingAreaHeight == value)
          return;
        this.mintGroupingAreaHeight = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the color of the grouping area border.</summary>
    /// <value>The color of the grouping area border.</value>
    internal BorderColor GroupingAreaBorderColor
    {
      get => this.mobjGroupingAreaBorderColor;
      set
      {
        if (!(this.mobjGroupingAreaBorderColor != value))
          return;
        this.mobjGroupingAreaBorderColor = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the grouping area background image.</summary>
    /// <value>The grouping area background image.</value>
    internal ResourceHandle GroupingAreaBackgroundImage
    {
      get => this.mobjGroupingAreaBackgroundImage;
      set
      {
        if (this.mobjGroupingAreaBackgroundImage == value)
          return;
        this.mobjGroupingAreaBackgroundImage = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets or sets the grouping area background image position.
    /// </summary>
    /// <value>The grouping area background image position.</value>
    internal BackgroundImagePosition GroupingAreaBackgroundImagePosition
    {
      get => this.menmGroupingAreaBackgroundImagePosition;
      set
      {
        if (this.menmGroupingAreaBackgroundImagePosition == value)
          return;
        this.menmGroupingAreaBackgroundImagePosition = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets or sets the grouping area background image repeat.
    /// </summary>
    /// <value>The grouping area background image repeat.</value>
    internal BackgroundImageRepeat GroupingAreaBackgroundImageRepeat
    {
      get => this.menmGroupingAreaBackgroundImageRepeat;
      set
      {
        if (this.menmGroupingAreaBackgroundImageRepeat == value)
          return;
        this.menmGroupingAreaBackgroundImageRepeat = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the grouping area border style.</summary>
    /// <value>The grouping area border style.</value>
    internal BorderStyle GroupingAreaBorderStyle
    {
      get => this.mobjGroupingAreaBorderStyle;
      set
      {
        if (this.mobjGroupingAreaBorderStyle == value)
          return;
        this.mobjGroupingAreaBorderStyle = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the width of the grouping area border.</summary>
    /// <value>The width of the grouping area border.</value>
    internal BorderWidth GroupingAreaBorderWidth
    {
      get => this.mobjGroupingAreaBorderWidth;
      set
      {
        if (!(this.mobjGroupingAreaBorderWidth != value))
          return;
        this.mobjGroupingAreaBorderWidth = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [support group count].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [support group count]; otherwise, <c>false</c>.
    /// </value>
    [Description("Gets or sets a value indicating whether to show the items count in group header.")]
    [DefaultValue(false)]
    [Category("CatAppearance")]
    public bool SupportGroupCount
    {
      get => this.mblnSupportGroupCount;
      set
      {
        if (this.mblnSupportGroupCount == value)
          return;
        this.mblnSupportGroupCount = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show filter row].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show filter row]; otherwise, <c>false</c>.
    /// </value>
    [Description("Gets or sets a value indicating whether to show the filter row.")]
    [DefaultValue(false)]
    [Category("CatAppearance")]
    public bool ShowFilterRow
    {
      get => this.mblnShowFilterRow;
      set
      {
        if (this.mblnShowFilterRow == value)
          return;
        this.mblnShowFilterRow = value;
        if (this.IsLayoutSuspended || this.DesignMode)
          return;
        if (value && this.mobjDataGridViewFilterRow == null)
          this.SwitchPreRenderUpdate(DataGridView.PreRenderUpdateType.FilterRow);
        this.Update();
      }
    }

    /// <summary>Creates the cell panel.</summary>
    /// <param name="objCell">The obj cell.</param>
    /// <returns></returns>
    protected internal virtual DataGridViewCellPanel CreateCellPanel(DataGridViewCell objCell) => new DataGridViewCellPanel(objCell);

    /// <summary>Gets or sets a value indicating whether or not ToolTips will show when the mouse pointer pauses on a cell.</summary>
    /// <returns>true if cell ToolTips are enabled; otherwise, false.</returns>
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    [SRDescription("DataGridView_ShowCellToolTipsDescr")]
    public bool ShowCellToolTips
    {
      get => this.mobjDataGridViewState2[256];
      set
      {
        if (this.ShowCellToolTips == value)
          return;
        this.mobjDataGridViewState2[256] = value;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether or not the editing glyph is visible in the row header of the cell being edited.</summary>
    /// <returns>true if the editing glyph is visible; otherwise, false. The default is true.</returns>
    [SRDescription("DataGridView_ShowEditingIconDescr")]
    [DefaultValue(true)]
    [SRCategory("CatAppearance")]
    public bool ShowEditingIcon
    {
      get => this.mobjDataGridViewState2[1];
      set
      {
        if (this.ShowEditingIcon == value)
          return;
        this.mobjDataGridViewState2[1] = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets a value indicating whether row headers will display error glyphs for each row that contains a data entry error. </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> indicates there is an error; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_ShowRowErrorsDescr")]
    [DefaultValue(true)]
    public bool ShowRowErrors
    {
      get => this.mobjDataGridViewState2[512];
      set
      {
        if (this.ShowRowErrors == value)
          return;
        this.mobjDataGridViewState2[512] = value;
      }
    }

    /// <summary>Gets the column by which the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> contents are currently sorted.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> by which the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> contents are currently sorted.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public DataGridViewColumn SortedColumn
    {
      get => this.mobjSortedColumn;
      private set => this.mobjSortedColumn = value;
    }

    /// <summary>Gets a value indicating whether the items in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control are sorted in ascending or descending order, or are not sorted.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.SortOrder"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public SortOrder SortOrder
    {
      get => this.menmSortOrder;
      private set => this.menmSortOrder = value;
    }

    /// <summary>Gets or sets the data grid view blocks manager.</summary>
    /// <value>The data grid view blocks manager.</value>
    private DataGridView.DataGridViewBlocksManager BlocksManager
    {
      get
      {
        if (this.mobjDataGridViewBlocksManager == null)
          this.mobjDataGridViewBlocksManager = new DataGridView.DataGridViewBlocksManager(this);
        return this.mobjDataGridViewBlocksManager;
      }
    }

    /// <summary>Gets or sets a value indicating whether the TAB key moves the focus to the next control in the tab order rather than moving focus to the next cell in the control.</summary>
    /// <returns>true if the TAB key moves the focus to the next control in the tab order; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    [SRDescription("DataGridView_StandardTabDescr")]
    [SRCategory("CatBehavior")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool StandardTab
    {
      get => this.mobjDataGridViewState1[8192];
      set
      {
        if (this.mobjDataGridViewState1[8192] == value)
          return;
        this.mobjDataGridViewState1[8192] = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the header cell located in the upper left corner of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see> located at the upper left corner of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataGridViewHeaderCell TopLeftHeaderCell
    {
      get
      {
        if (this.mobjTopLeftHeaderCell == null)
          this.TopLeftHeaderCell = (DataGridViewHeaderCell) new DataGridViewTopLeftHeaderCell();
        return this.mobjTopLeftHeaderCell;
      }
      set
      {
        if (this.mobjTopLeftHeaderCell == value)
          return;
        if (this.mobjTopLeftHeaderCell != null)
          this.mobjTopLeftHeaderCell.DataGridViewInternal = (DataGridView) null;
        this.mobjTopLeftHeaderCell = value;
        if (value != null)
          this.mobjTopLeftHeaderCell.DataGridViewInternal = this;
        if (this.ColumnHeadersVisible && this.RowHeadersVisible)
          this.OnColumnHeadersGlobalAutoSize();
        this.mobjTopLeftHeaderCell = value;
      }
    }

    private void OnColumnHeadersGlobalAutoSize()
    {
    }

    /// <summary>Gets the default or user-specified value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property. </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> representing the normal value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public Cursor UserSetCursor => (Cursor) null;

    /// <summary>Gets the number of pixels by which the control is scrolled vertically.</summary>
    /// <returns>The number of pixels by which the control is scrolled vertically.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int VerticalScrollingOffset => -1;

    /// <summary>Gets or sets a value indicating whether you have provided your own data-management operations for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> uses data-management operations that you provide; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("DataGridViewVirtualModeDescr")]
    public bool VirtualMode
    {
      get => this.mobjDataGridViewState1[65536];
      set
      {
        if (this.mobjDataGridViewState1[65536] == value)
          return;
        this.mobjDataGridViewState1[65536] = value;
        this.InvalidateRowHeights();
      }
    }

    /// <summary>Gets the placeholder cell style.</summary>
    /// <value>The placeholder cell style.</value>
    internal DataGridViewCellStyle PlaceholderCellStyle
    {
      get
      {
        if (this.mobjPlaceholderCellStyle == null)
          this.mobjPlaceholderCellStyle = new DataGridViewCellStyle();
        return this.mobjPlaceholderCellStyle;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>Gets or sets the height of the caption.</summary>
    /// <value>The height of the caption.</value>
    [DefaultValue(0)]
    public int CaptionHeight
    {
      get => this.mintCaptionHeight;
      set
      {
        if (this.mintCaptionHeight == value)
          return;
        this.mintCaptionHeight = value;
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets or sets the navigation key filter.</summary>
    /// <value>The navigation key filter.</value>
    [DefaultValue(NavigationKeyFilter.None)]
    public NavigationKeyFilter NavigationKeyFilter
    {
      get => this.menmNavigationKeyFilter;
      set
      {
        if (this.menmNavigationKeyFilter == value)
          return;
        this.menmNavigationKeyFilter = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets the headers filter info.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public List<HeaderFilterInfo> HeadersFilterInfo
    {
      get
      {
        if (this.mobjHeadersFilterInfo == null)
          this.mobjHeadersFilterInfo = new List<HeaderFilterInfo>();
        return this.mobjHeadersFilterInfo;
      }
    }

    void ISupportInitialize.BeginInit()
    {
      if (this.mobjDataGridViewState2[524288])
        throw new InvalidOperationException(SR.GetString("DataGridViewBeginInit"));
      this.mobjDataGridViewState2[524288] = true;
    }

    void ISupportInitialize.EndInit()
    {
      this.mobjDataGridViewState2[524288] = false;
      foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
      {
        if (column.Frozen && column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
          column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      }
      DataGridViewSelectionMode selectionMode = this.SelectionMode;
      switch (selectionMode)
      {
        case DataGridViewSelectionMode.FullColumnSelect:
        case DataGridViewSelectionMode.ColumnHeaderSelect:
          IEnumerator enumerator = this.Columns.GetEnumerator();
          try
          {
            while (enumerator.MoveNext())
            {
              if (((DataGridViewColumn) enumerator.Current).SortMode == DataGridViewColumnSortMode.Automatic)
              {
                this.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                throw new InvalidOperationException(SR.GetString("DataGridView_SelectionModeReset", (object) SR.GetString("DataGridView_SelectionModeAndSortModeClash", (object) selectionMode.ToString()), (object) DataGridViewSelectionMode.RowHeaderSelect.ToString()));
              }
            }
            break;
          }
          finally
          {
            if (enumerator is IDisposable disposable)
              disposable.Dispose();
          }
      }
      this.ResetDataBinding();
    }

    /// <summary>Gets the collection of cells selected by the user.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedCellCollection"></see> that represents the cells selected by the user.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public DataGridViewSelectedCellCollection SelectedCells
    {
      get
      {
        DataGridViewSelectedCellCollection selectedCells = new DataGridViewSelectedCellCollection();
        DataGridViewIntLinkedList viewIntLinkedList = (DataGridViewIntLinkedList) null;
        switch (this.SelectionMode)
        {
          case DataGridViewSelectionMode.CellSelect:
            selectedCells.AddCellLinkedList(this.IndividualSelectedCells);
            return selectedCells;
          case DataGridViewSelectionMode.FullRowSelect:
          case DataGridViewSelectionMode.RowHeaderSelect:
            foreach (int selectedBandIndex in (IEnumerable) this.SelectedBandIndexes)
            {
              foreach (DataGridViewCell cell in (BaseCollection) this.Rows[selectedBandIndex].Cells)
                selectedCells.Add(cell);
            }
            if (this.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
              selectedCells.AddCellLinkedList(this.IndividualSelectedCells);
            return selectedCells;
          case DataGridViewSelectionMode.FullColumnSelect:
          case DataGridViewSelectionMode.ColumnHeaderSelect:
            if (viewIntLinkedList == null)
              viewIntLinkedList = this.SelectedBandIndexes;
            foreach (int index in (IEnumerable) viewIntLinkedList)
            {
              foreach (DataGridViewRow row in (IEnumerable) this.Rows)
                selectedCells.Add(row.Cells[index]);
            }
            if (this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
              selectedCells.AddCellLinkedList(this.IndividualSelectedCells);
            return selectedCells;
          default:
            return selectedCells;
        }
      }
    }

    /// <summary>Gets the collection of columns selected by the user.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection"></see> that represents the columns selected by the user.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public DataGridViewSelectedColumnCollection SelectedColumns
    {
      get
      {
        DataGridViewSelectedColumnCollection selectedColumns = new DataGridViewSelectedColumnCollection();
        switch (this.SelectionMode)
        {
          case DataGridViewSelectionMode.CellSelect:
          case DataGridViewSelectionMode.FullRowSelect:
          case DataGridViewSelectionMode.RowHeaderSelect:
            return selectedColumns;
          case DataGridViewSelectionMode.FullColumnSelect:
          case DataGridViewSelectionMode.ColumnHeaderSelect:
            foreach (int selectedBandIndex in (IEnumerable) this.SelectedBandIndexes)
              selectedColumns.Add(this.Columns[selectedBandIndex]);
            return selectedColumns;
          default:
            return selectedColumns;
        }
      }
    }

    /// <summary>Gets the collection of rows selected by the user.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedRowCollection"></see> that contains the rows selected by the user.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public DataGridViewSelectedRowCollection SelectedRows
    {
      get
      {
        DataGridViewSelectedRowCollection selectedRows = new DataGridViewSelectedRowCollection();
        switch (this.SelectionMode)
        {
          case DataGridViewSelectionMode.CellSelect:
          case DataGridViewSelectionMode.FullColumnSelect:
            return selectedRows;
          case DataGridViewSelectionMode.FullRowSelect:
          case DataGridViewSelectionMode.RowHeaderSelect:
            foreach (int selectedBandIndex in (IEnumerable) this.SelectedBandIndexes)
              selectedRows.Add(this.Rows[selectedBandIndex]);
            return selectedRows;
          case DataGridViewSelectionMode.CellSelect | DataGridViewSelectionMode.FullRowSelect:
            return selectedRows;
          default:
            goto case DataGridViewSelectionMode.CellSelect;
        }
      }
    }

    /// <summary>Gets the scroll poisition.</summary>
    /// <value>The scroll poisition.</value>
    internal Point ScrollPoisition => new Point(this.ScrollLeft, this.ScrollTop);

    /// <summary>Gets or sets the index of the column that is the first column displayed on the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <returns>The index of the column that is the first column displayed on the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 0 or greater than the number of columns in the control minus 1.</exception>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property indicates a column with a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Visible"></see> property value of false.-or-The specified value when setting this property indicates a column with a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int FirstDisplayedScrollingColumnIndex
    {
      get
      {
        int scrollingColumnIndex = -1;
        if (this.Columns.Count > 0 && this.Width > 0)
        {
          DataGridViewColumn objDataGridViewColumnStart = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
          int num = 0;
          while (objDataGridViewColumnStart != null)
          {
            if (num >= this.ScrollLeft)
            {
              scrollingColumnIndex = objDataGridViewColumnStart.Index;
              objDataGridViewColumnStart = (DataGridViewColumn) null;
            }
            else
            {
              num += objDataGridViewColumnStart.Width;
              objDataGridViewColumnStart = this.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
            }
          }
        }
        return scrollingColumnIndex;
      }
      set
      {
        if (value < 0 || value >= this.Columns.Count)
          throw new ArgumentOutOfRangeException(nameof (value));
        if (!this.Columns[value].Visible)
          throw new InvalidOperationException(SR.GetString("DataGridView_FirstDisplayedScrollingColumnCannotBeInvisible"));
        if (this.Columns[value].Frozen)
          throw new InvalidOperationException(SR.GetString("DataGridView_FirstDisplayedScrollingColumnCannotBeFrozen"));
        int width = this.LayoutInfo.Data.Width;
        if (width <= 0)
          throw new InvalidOperationException(SR.GetString("DataGridView_NoRoomForDisplayedColumns"));
        if (this.Columns.GetColumnsWidth(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible) >= width)
          throw new InvalidOperationException(SR.GetString("DataGridView_FrozenColumnsPreventFirstDisplayedScrollingColumn"));
        if (value == this.DisplayedBandsInfo.FirstDisplayedScrollingCol || this.mobjCurrentCellPoint.X >= 0 && !this.CommitEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Scroll, false, false) || this.IsColumnOutOfBounds(value))
          return;
        this.PerformScrollIntoView(this.Rows[this.mobjCurrentCellPoint.Y].Cells[value], false);
      }
    }

    /// <summary>Gets the first index of the displayed column.</summary>
    /// <value>The first index of the displayed column.</value>
    internal int FirstDisplayedColumnIndex
    {
      get
      {
        if (!this.IsHandleCreated)
          return -1;
        int displayedColumnIndex = -1;
        DataGridViewColumn firstColumn = this.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
        if (firstColumn != null)
        {
          if (firstColumn.Frozen)
            return firstColumn.Index;
          if (this.FirstDisplayedScrollingColumnIndex >= 0)
            displayedColumnIndex = this.FirstDisplayedScrollingColumnIndex;
        }
        return displayedColumnIndex;
      }
    }

    /// <summary>Gets the first index of the displayed row.</summary>
    /// <value>The first index of the displayed row.</value>
    internal int FirstDisplayedRowIndex
    {
      get
      {
        if (!this.IsHandleCreated)
          return -1;
        DataGridViewRowCollection rows = this.Rows;
        int intRowIndex = rows.GetFirstRow(DataGridViewElementStates.Visible);
        if (intRowIndex != -1 && (rows.GetRowState(intRowIndex) & DataGridViewElementStates.Frozen) == DataGridViewElementStates.None && this.FirstDisplayedScrollingRowIndex >= 0)
          intRowIndex = this.FirstDisplayedScrollingRowIndex;
        return intRowIndex;
      }
    }

    /// <summary>
    /// Gets or sets the first index of the displayed scrolling row.
    /// </summary>
    /// <value>The first index of the displayed scrolling row.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int FirstDisplayedScrollingRowIndex
    {
      get
      {
        int scrollingRowIndex = -1;
        IList pageRows = this.PageRows;
        if (pageRows.Count > 0 && this.Height > 0)
        {
          int num = 0;
          foreach (DataGridViewRow dataGridViewRow in (IEnumerable) pageRows)
          {
            if (dataGridViewRow.Visible)
            {
              if (num >= this.ScrollTop)
              {
                scrollingRowIndex = dataGridViewRow.Index;
                break;
              }
              num += dataGridViewRow.Height;
            }
          }
        }
        return scrollingRowIndex;
      }
      set
      {
        DataGridViewRowCollection rows = this.Rows;
        if (value < 0 || value >= rows.Count)
          throw new ArgumentOutOfRangeException(nameof (value));
        if ((rows.GetRowState(value) & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
          throw new InvalidOperationException(SR.GetString("DataGridView_FirstDisplayedScrollingRowCannotBeInvisible"));
        if ((rows.GetRowState(value) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
          throw new InvalidOperationException(SR.GetString("DataGridView_FirstDisplayedScrollingRowCannotBeFrozen"));
        if (value == this.FirstDisplayedScrollingRowIndex || this.mobjCurrentCellPoint.X >= 0 && !this.CommitEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Scroll, false, false))
          return;
        this.PerformScrollIntoView(rows[value].Cells[this.mobjCurrentCellPoint.X], false);
      }
    }

    /// <summary>Gets or sets a value indicating how the cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> can be selected.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectionMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.RowHeaderSelect"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property of one or more columns is set to <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see>.</exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectionMode"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DataGridViewSelectionMode.RowHeaderSelect)]
    [Browsable(true)]
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_SelectionModeDescr")]
    public DataGridViewSelectionMode SelectionMode
    {
      get => this.menmSelectionMode;
      set
      {
        if (this.SelectionMode == value)
          return;
        if (!this.mobjDataGridViewState2[524288] && (value == DataGridViewSelectionMode.FullColumnSelect || value == DataGridViewSelectionMode.ColumnHeaderSelect))
        {
          foreach (DataGridViewColumn column in (BaseCollection) this.Columns)
          {
            if (column.SortMode == DataGridViewColumnSortMode.Automatic)
              throw new InvalidOperationException(SR.GetString("DataGridView_SelectionModeAndSortModeClash", (object) value.ToString()));
          }
        }
        this.ClearSelection();
        this.menmSelectionMode = value;
        this.InvokeMethodWithId("DataGridView_InvokeSetSelectionMode", (object) Convert.ToInt32((object) this.SupportedSelectionMode).ToString());
      }
    }

    /// <summary>Gets the supported selection mode.</summary>
    /// <value>The supported selection mode.</value>
    private DataGridViewSelectionMode SupportedSelectionMode
    {
      get
      {
        switch (this.SelectionMode)
        {
          case DataGridViewSelectionMode.CellSelect:
          case DataGridViewSelectionMode.FullRowSelect:
          case DataGridViewSelectionMode.RowHeaderSelect:
            return this.SelectionMode;
          default:
            return DataGridViewSelectionMode.CellSelect;
        }
      }
    }

    /// <summary>Gets or sets the current cell point.</summary>
    /// <value>The current cell point.</value>
    internal Point CurrentCellPoint
    {
      get => this.mobjCurrentCellPoint;
      set => this.mobjCurrentCellPoint = value;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.SelectionChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains information about the event.</param>
    protected virtual void OnSelectionChanged(EventArgs e)
    {
      this.mobjDataGridViewState2[262144] = false;
      EventHandler selectionChangedHandler = this.SelectionChangedHandler;
      if (selectionChangedHandler != null)
        selectionChangedHandler((object) this, e);
      EventHandler selectionChangedQueued = this.SelectionChangedQueued;
      if (selectionChangedQueued == null)
        return;
      selectionChangedQueued((object) this, e);
    }

    /// <summary>Sets the selected cell core internal.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnSelected">if set to <c>true</c> [selected].</param>
    internal void SetSelectedCellCoreInternal(
      int intColumnIndex,
      int intRowIndex,
      bool blnSelected)
    {
      if (intColumnIndex < 0 || intColumnIndex >= this.Columns.Count)
        throw new ArgumentOutOfRangeException("columnIndex");
      DataGridViewRowCollection rows = this.Rows;
      if (intRowIndex < 0 || intRowIndex >= rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
      DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
      if (this.IsSharedCellSelected(dataGridViewRow.Cells[intColumnIndex], intRowIndex) == blnSelected)
        return;
      DataGridViewCellLinkedList individualSelectedCells = this.IndividualSelectedCells;
      DataGridViewCell cell1 = rows[intRowIndex].Cells[intColumnIndex];
      DataGridViewIntLinkedList viewIntLinkedList = (DataGridViewIntLinkedList) null;
      if (blnSelected)
      {
        if ((rowState & DataGridViewElementStates.Selected) != DataGridViewElementStates.None || this.Columns[intColumnIndex].Selected)
          return;
        individualSelectedCells.Add(cell1);
        this.SetSelectedCellCore(cell1, true, false);
      }
      else
      {
        if ((cell1.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
        {
          individualSelectedCells.Remove(cell1);
        }
        else
        {
          bool flag = false;
          if (this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
          {
            if (rows.Count > 8)
            {
              ++this.BulkPaintCount;
              flag = true;
            }
            try
            {
              this.SelectedBandIndexes.Remove(intColumnIndex);
              this.Columns[intColumnIndex].SelectedInternal = false;
              for (int index = 0; index < intRowIndex; ++index)
              {
                DataGridViewCell cell2 = rows[index].Cells[intColumnIndex];
                this.SetSelectedCellCore(cell2, true, false);
                individualSelectedCells.Add(cell2);
              }
              for (int index = intRowIndex + 1; index < rows.Count; ++index)
              {
                DataGridViewCell cell3 = rows[index].Cells[intColumnIndex];
                this.SetSelectedCellCore(cell3, true, false);
                individualSelectedCells.Add(cell3);
              }
              if (!cell1.Selected)
                return;
              this.SetSelectedCellCore(cell1, false, false);
              return;
            }
            finally
            {
              if (flag)
                this.ExitBulkPaint(intColumnIndex, -1);
            }
          }
          else if (this.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
          {
            if (this.Columns.Count > 8)
            {
              ++this.BulkPaintCount;
              flag = true;
            }
            try
            {
              if (viewIntLinkedList == null)
                viewIntLinkedList = this.SelectedBandIndexes;
              viewIntLinkedList.Remove(intRowIndex);
              rows.SetRowState(intRowIndex, DataGridViewElementStates.Selected, false);
              for (int index = 0; index < intColumnIndex; ++index)
              {
                DataGridViewCell cell4 = rows[intRowIndex].Cells[index];
                this.SetSelectedCellCore(cell4, true, false);
                individualSelectedCells.Add(cell4);
              }
              for (int index = intColumnIndex + 1; index < this.Columns.Count; ++index)
              {
                DataGridViewCell cell5 = rows[intRowIndex].Cells[index];
                this.SetSelectedCellCore(cell5, true, false);
                individualSelectedCells.Add(cell5);
              }
            }
            finally
            {
              if (flag)
                this.ExitBulkPaint(-1, intRowIndex);
            }
          }
        }
        if (!cell1.Selected)
          return;
        this.SetSelectedCellCore(cell1, false, false);
      }
    }

    /// <summary>Sets the selected cell core.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnSelected">if set to <c>true</c> [selected].</param>
    protected virtual void SetSelectedCellCore(
      int intColumnIndex,
      int intRowIndex,
      bool blnSelected)
    {
      this.SetSelectedCellCore(intColumnIndex, intRowIndex, blnSelected, false);
    }

    /// <summary>
    /// Determines whether [is shared cell selected] [the specified data grid view cell].
    /// </summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns>
    /// 	<c>true</c> if [is shared cell selected] [the specified data grid view cell]; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsSharedCellSelected(DataGridViewCell objDataGridViewCell, int intRowIndex) => (this.Rows.GetRowState(intRowIndex) & DataGridViewElementStates.Selected) != DataGridViewElementStates.None || objDataGridViewCell.OwningColumn != null && objDataGridViewCell.OwningColumn.Selected || objDataGridViewCell.StateIncludes(DataGridViewElementStates.Selected);

    /// <summary>Sets the selected column core internal.</summary>
    /// <param name="intColumnIndex">Index of the column.</param>
    /// <param name="blnSelected">if set to <c>true</c> [selected].</param>
    internal void SetSelectedColumnCoreInternal(int intColumnIndex, bool blnSelected)
    {
      ++this.SelectionChangeCount;
      try
      {
        DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
        if (!this.MultiSelect && selectedBandIndexes.Count > 0)
        {
          int headInt = selectedBandIndexes.HeadInt;
          if (headInt != intColumnIndex)
            this.SetSelectedColumnCore(headInt, false);
        }
        this.SetSelectedColumnCore(intColumnIndex, blnSelected);
      }
      finally
      {
        --this.NoSelectionChangeCount;
      }
    }

    internal void SetSelectedRowCoreInternal(int intRowIndex, bool blnSelected)
    {
      ++this.SelectionChangeCount;
      try
      {
        DataGridViewIntLinkedList selectedBandIndexes = this.SelectedBandIndexes;
        if (!this.MultiSelect && selectedBandIndexes.Count > 0)
        {
          int headInt = selectedBandIndexes.HeadInt;
          if (headInt != intRowIndex)
            this.SetSelectedRowCore(headInt, false);
        }
        this.SetSelectedRowCore(intRowIndex, blnSelected);
      }
      finally
      {
        --this.NoSelectionChangeCount;
      }
    }

    /// <summary>Opens the custom filter dialog.</summary>
    /// <param name="objDataGridViewCell">The obj data grid view cell.</param>
    internal void OpenCustomFilterDialog(DataGridViewCell objDataGridViewCell)
    {
      DataGridViewCustomFilterDialog customFilterDialog = new DataGridViewCustomFilterDialog(objDataGridViewCell);
      customFilterDialog.Closed += new EventHandler(this.objCustomFilterDialog_Closed);
      int num = (int) customFilterDialog.ShowDialog();
    }

    /// <summary>
    /// Handles the Closed event of the objCustomFilterDialog control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objCustomFilterDialog_Closed(object sender, EventArgs e)
    {
      if (!(sender is DataGridViewCustomFilterDialog customFilterDialog))
        return;
      if (customFilterDialog.DialogResult == DialogResult.OK)
      {
        DataGridViewColumn column = customFilterDialog.Column;
        string filterStatement = this.GetFilterStatement(customFilterDialog.OperatorA, column.DataPropertyName, column.ValueType, customFilterDialog.ValueA, (object) null);
        string str = string.Empty;
        if (customFilterDialog.OperatorB != FilterComparisonOperator.None && customFilterDialog.ValueB != string.Empty)
          str = this.GetFilterStatement(customFilterDialog.OperatorB, column.DataPropertyName, column.ValueType, customFilterDialog.ValueB, (object) null);
        if (str != string.Empty)
          column.CustomFilterExpression = string.Format("(({0}) {1} ({2}))", (object) filterStatement, (object) customFilterDialog.FiltersRelation, (object) str);
        else
          column.CustomFilterExpression = string.Format("({0})", (object) filterStatement);
      }
      else if (customFilterDialog.Cell is DataGridViewColumnHeaderCell cell)
        cell.FilterComboBox.SelectedIndex = -1;
      else
        customFilterDialog.Column?.ClearFilter(false);
    }

    [Serializable]
    internal enum DataGridViewValidateCellInternal
    {
      Never,
      Always,
      WhenChanged,
    }

    /// <summary>
    /// Represents DataGridView aspect flags that have to be updated with awareness.
    /// </summary>
    [Serializable]
    internal enum PreRenderUpdateType
    {
      /// <summary>Nothing to update</summary>
      None = 0,
      /// <summary>GroupingData changed and has to be updated</summary>
      GroupingData = 1,
      /// <summary>FilterRow has to be updated</summary>
      FilterRow = 2,
      /// <summary>GroupHeaders have to be rebuilt</summary>
      GroupHeaders = 4,
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class DataGridRowBlockInfo
    {
      /// <summary>
      /// 
      /// </summary>
      private bool mblnIsLoaded;
      /// <summary>Gets or sets the last modified.</summary>
      /// <value>The last modified.</value>
      private long mlngLastModified;
      /// <summary>
      /// 
      /// </summary>
      private DataGridView.DataGridViewBlocksManager mobjManager;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView.DataGridRowBlockInfo" /> class.
      /// </summary>
      /// <param name="objManager">The manager.</param>
      public DataGridRowBlockInfo(DataGridView.DataGridViewBlocksManager objManager)
      {
        this.mobjManager = objManager;
        this.mlngLastModified = this.mobjManager.GetDataGridLastModified();
      }

      /// <summary>Gets the last modified.</summary>
      /// <value>The last modified.</value>
      public long LastModified => this.mlngLastModified;

      /// <summary>
      /// Gets a value indicating whether this instance is loaded.
      /// </summary>
      /// <value><c>true</c> if this instance is loaded; otherwise, <c>false</c>.</value>
      public bool IsLoaded => this.mblnIsLoaded;

      /// <summary>Loads the rows.</summary>
      public void LoadRows()
      {
        if (this.mblnIsLoaded)
          return;
        this.mblnIsLoaded = true;
      }

      /// <summary>Updates this block.</summary>
      internal void Update() => this.mlngLastModified = this.mobjManager.GetCurrentTicks();

      /// <summary>Determines whether the specified block is dirty.</summary>
      /// <param name="lngRequestID">Request ID.</param>
      /// <returns>
      /// 	<c>true</c> if the specified block is dirty; otherwise, <c>false</c>.
      /// </returns>
      internal bool IsDirty(long lngRequestID) => this.LastModified > lngRequestID;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class DataGridViewBlocksManager
    {
      /// <summary>
      /// 
      /// </summary>
      private readonly DataGridView mobjDataGridView;
      /// <summary>
      /// 
      /// </summary>
      private readonly Dictionary<int, DataGridView.DataGridRowBlockInfo> mobjRowBlockInfos = new Dictionary<int, DataGridView.DataGridRowBlockInfo>();

      /// <summary>
      /// Initializes a new instance of the <see cref="!:DataGridRowBlockManager" /> class.
      /// </summary>
      /// <param name="objDataGridView">The data grid view.</param>
      public DataGridViewBlocksManager(DataGridView objDataGridView) => this.mobjDataGridView = objDataGridView;

      /// <summary>Gets the block info.</summary>
      /// <param name="intBlockId">The int block id.</param>
      /// <returns></returns>
      public DataGridView.DataGridRowBlockInfo GetBlockInfo(int intBlockId)
      {
        DataGridView.DataGridRowBlockInfo blockInfo = (DataGridView.DataGridRowBlockInfo) null;
        if (!this.mobjRowBlockInfos.TryGetValue(intBlockId, out blockInfo))
          this.mobjRowBlockInfos[intBlockId] = blockInfo = new DataGridView.DataGridRowBlockInfo(this);
        return blockInfo;
      }

      /// <summary>Gets the block info.</summary>
      /// <param name="objBlock">The block.</param>
      /// <returns></returns>
      public DataGridView.DataGridRowBlockInfo GetBlockInfo(DataGridView.DataGridRowBlock objBlock)
      {
        DataGridView.DataGridRowBlockInfo blockInfo = (DataGridView.DataGridRowBlockInfo) null;
        if (objBlock != null)
          blockInfo = this.GetBlockInfo(objBlock.BlockId);
        return blockInfo;
      }

      /// <summary>Gets the current ticks.</summary>
      /// <returns></returns>
      internal long GetCurrentTicks() => this.mobjDataGridView.GetCurrentTicks();

      /// <summary>Clears the block info cache.</summary>
      internal void ClearBlockInfoCache() => this.mobjRowBlockInfos.Clear();

      /// <summary>Gets the data grid last modified.</summary>
      /// <returns></returns>
      internal long GetDataGridLastModified() => this.mobjDataGridView.GetLastModified();
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class DataGridRowBlock : IEnumerable
    {
      /// <summary>
      /// 
      /// </summary>
      private int mintBlockHeight = -1;
      /// <summary>
      /// 
      /// </summary>
      private readonly int mintBlockId;
      /// <summary>
      /// 
      /// </summary>
      private DataGridView.DataGridRowBlockInfo mobjBlockInfo;
      /// <summary>
      /// 
      /// </summary>
      private readonly IList mobjBlockRows;
      /// <summary>
      /// 
      /// </summary>
      private readonly DataGridView mobjDataGrid;
      /// <summary>
      /// 
      /// </summary>
      private readonly bool mblnContainsFrozenRows;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView.DataGridRowBlock" /> class.
      /// </summary>
      /// <param name="objBlockRows">The block rows.</param>
      /// <param name="intBlockId">The block id.</param>
      public DataGridRowBlock(
        DataGridView objDataGrid,
        IList objBlockRows,
        int intBlockId,
        bool blnContainsFrozenRows)
      {
        this.mobjBlockRows = objBlockRows;
        this.mintBlockId = intBlockId;
        this.mobjDataGrid = objDataGrid;
        this.mblnContainsFrozenRows = blnContainsFrozenRows;
      }

      /// <summary>Gets the height of the block.</summary>
      /// <value>The height of the block.</value>
      internal int BlockHeight
      {
        get
        {
          if (this.mintBlockHeight == -1)
          {
            int num = 0;
            foreach (DataGridViewRow dataGridViewRow in (IEnumerable) this)
            {
              if (!dataGridViewRow.Frozen)
              {
                num += dataGridViewRow.Height;
                if (dataGridViewRow.Expanded && this.mobjDataGrid.IsHierarchic(HierarchicInfoSelector.Bounded))
                  num += dataGridViewRow.ChildGrid.Height;
              }
            }
            this.mintBlockHeight = num;
          }
          return this.mintBlockHeight;
        }
      }

      /// <summary>Gets the block id.</summary>
      /// <value>The block id.</value>
      public int BlockId => this.mintBlockId;

      /// <summary>Gets the block info.</summary>
      /// <value>The block info.</value>
      public DataGridView.DataGridRowBlockInfo BlockInfo
      {
        get
        {
          if (this.mobjBlockInfo == null)
            this.mobjBlockInfo = this.mobjDataGrid.GetBlockInfo(this);
          return this.mobjBlockInfo;
        }
      }

      /// <summary>
      /// Gets a value indicating whether [contains frozen rows].
      /// </summary>
      /// <value><c>true</c> if [contains frozen rows]; otherwise, <c>false</c>.</value>
      public bool ContainsFrozenRows => this.mblnContainsFrozenRows;

      /// <summary>Renders the row block</summary>
      /// <param name="objContext">The context.</param>
      /// <param name="objWriter">The writer.</param>
      /// <param name="lngRequestID">The request ID.</param>
      /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
      /// <param name="blnFullRender">if set to <c>true</c> [BLN full render].</param>
      /// <param name="intTopPosition">The block's top position.</param>
      /// <param name="intGridScrollTop">The grid scroll top.</param>
      /// <param name="intGridHeight">Height of the grid.</param>
      public void RenderBlock(
        IContext objContext,
        IResponseWriter objWriter,
        long lngRequestID,
        bool blnRenderOwner,
        bool blnFullRender,
        int intTopPosition,
        int intGridScrollTop,
        int intGridHeight)
      {
        DataGridView.DataGridRowBlockInfo blockInfo = this.BlockInfo;
        if (blockInfo == null)
          return;
        int blockHeight = this.BlockHeight;
        int num1 = intTopPosition + blockHeight;
        int num2 = intGridScrollTop + intGridHeight;
        bool blnIsDirtyBlock = blockInfo.IsDirty(lngRequestID);
        bool flag = blockInfo.IsLoaded || this.ContainsFrozenRows;
        if (blnFullRender && !flag)
        {
          if (intTopPosition >= intGridScrollTop && intTopPosition < num2)
            flag = true;
          else if (num1 > intGridScrollTop && num1 <= num2)
            flag = true;
          else if (intTopPosition <= intGridScrollTop && num1 >= num2)
            flag = true;
          if (flag)
            blockInfo.LoadRows();
        }
        if (blnFullRender | blnIsDirtyBlock)
        {
          objWriter.WriteStartElement(WGConst.Prefix, "DGVB", WGConst.Namespace);
          objWriter.WriteAttributeString("mId", string.Format("{0}{1}", (object) "DGVB", (object) this.mintBlockId.ToString()));
          objWriter.WriteAttributeString("oId", this.mobjDataGrid.ID.ToString());
          objWriter.WriteAttributeString("H", blockHeight.ToString());
          objWriter.WriteAttributeString("LO", flag ? "1" : "0");
          if (flag)
          {
            objWriter.WriteAttributeString("V", "1");
            this.RenderBlockRows(objContext, objWriter, lngRequestID, blnRenderOwner, blnIsDirtyBlock);
          }
          objWriter.WriteEndElement();
        }
        else
          this.RenderBlockRows(objContext, objWriter, lngRequestID, blnRenderOwner, blnIsDirtyBlock);
      }

      /// <summary>Render the block's rows.</summary>
      /// <param name="objContext"></param>
      /// <param name="objWriter"></param>
      /// <param name="lngRequestID"></param>
      /// <param name="blnRenderOwner"></param>
      /// <param name="blnIsDirtyBlock"></param>
      private void RenderBlockRows(
        IContext objContext,
        IResponseWriter objWriter,
        long lngRequestID,
        bool blnRenderOwner,
        bool blnIsDirtyBlock)
      {
        foreach (IRenderableComponentMember renderableComponentMember in (IEnumerable) this)
          renderableComponentMember.RenderComponent(objContext, objWriter, blnIsDirtyBlock ? 0L : lngRequestID, blnRenderOwner);
      }

      /// <summary>
      /// Returns an enumerator that iterates through a collection.
      /// </summary>
      /// <returns>
      /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
      /// </returns>
      IEnumerator IEnumerable.GetEnumerator() => this.mobjBlockRows.GetEnumerator();
    }

    [Serializable]
    internal class DataGridViewDataConnection : SerializableObject
    {
      private string mstrDataMember;
      private CurrencyManager mobjCurrencyManager;
      private int mintLastListCount;
      [NonSerialized]
      private PropertyDescriptorCollection mobjProps;
      private const int DATACONNECTIONSTATE_cachedAllowUserToAddRowsInternal = 65536;
      private const int DATACONNECTIONSTATE_cancellingRowEdit = 64;
      private const int DATACONNECTIONSTATE_dataConnection_inSetDataConnection = 1;
      private const int DATACONNECTIONSTATE_dataSourceInitializedHookedUp = 262144;
      private const int DATACONNECTIONSTATE_didNotDeleteRowFromDataGridView = 8192;
      private const int DATACONNECTIONSTATE_doNotChangePositionInTheCurrencyManager = 16;
      private const int DATACONNECTIONSTATE_doNotChangePositionInTheDataGridViewControl = 8;
      private const int DATACONNECTIONSTATE_finishedAddNew = 4;
      private const int DATACONNECTIONSTATE_inAddNew = 512;
      private const int DATACONNECTIONSTATE_inDeleteOperation = 4096;
      private const int DATACONNECTIONSTATE_inEndCurrentEdit = 32768;
      private const int DATACONNECTIONSTATE_interestedInRowEvents = 32;
      private const int DATACONNECTIONSTATE_itemAddedInDeleteOperation = 16384;
      private const int DATACONNECTIONSTATE_listWasReset = 1024;
      private const int DATACONNECTIONSTATE_positionChangingInCurrencyManager = 2048;
      private const int DATACONNECTIONSTATE_processingListChangedEvent = 131072;
      private const int DATACONNECTIONSTATE_processingMetaDataChanges = 2;
      private const int DATACONNECTIONSTATE_restoreRow = 128;
      private const int DATACONNECTIONSTATE_rowValidatingInAddNew = 256;
      /// <summary>Gets the state of the data connection.</summary>
      /// <value>The state of the data connection.</value>
      private SerializableBitVector32 mobjDataConnectionState;
      private object mobjDataSource;
      private DataGridView mobjOwner;

      internal void OnNewRowNeeded()
      {
        this.mobjDataConnectionState[8] = true;
        try
        {
          this.AddNew();
        }
        finally
        {
          this.mobjDataConnectionState[8] = false;
        }
      }

      internal void OnRowEnter(DataGridViewCellEventArgs e)
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        if (this.mobjDataConnectionState[2] || !currencyManager.ShouldBind)
          return;
        this.mobjDataConnectionState[8] = true;
        try
        {
          if (e.RowIndex == this.Owner.NewRowIndex || this.mobjDataConnectionState[16])
            return;
          if (currencyManager.Position == e.RowIndex)
            return;
          try
          {
            currencyManager.Position = e.RowIndex;
          }
          catch (Exception ex)
          {
            if (ClientUtils.IsCriticalException(ex))
            {
              throw;
            }
            else
            {
              DataGridViewCellCancelEventArgs e1 = new DataGridViewCellCancelEventArgs(e.ColumnIndex, e.RowIndex);
              this.ProcessException(ex, e1, false);
            }
          }
          if (!(currencyManager.Current is IEditableObject current))
            return;
          current.BeginEdit();
        }
        finally
        {
          this.mobjDataConnectionState[8] = false;
        }
      }

      internal void OnRowValidating(DataGridViewCellCancelEventArgs e)
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        if (!currencyManager.ShouldBind)
          return;
        DataGridView owner = this.Owner;
        if (!this.mobjDataConnectionState[4] && !owner.IsCurrentRowDirty)
        {
          if (!this.mobjDataConnectionState[64])
          {
            this.mobjDataConnectionState[8] = true;
            try
            {
              this.CancelRowEdit(false, false);
            }
            finally
            {
              this.mobjDataConnectionState[8] = false;
            }
          }
        }
        else if (owner.IsCurrentRowDirty)
        {
          this.mobjDataConnectionState[256] = true;
          try
          {
            currencyManager.EndCurrentEdit();
          }
          catch (Exception ex)
          {
            if (ClientUtils.IsCriticalException(ex))
              throw;
            else
              this.ProcessException(ex, e, true);
          }
          finally
          {
            this.mobjDataConnectionState[256] = false;
          }
        }
        this.mobjDataConnectionState[4] = true;
      }

      public bool ShouldChangeDataMember(object objNewDataSource)
      {
        DataGridView owner = this.Owner;
        if (owner.BindingContext == null)
          return false;
        if (objNewDataSource != null)
        {
          if (!(owner.BindingContext[objNewDataSource] is CurrencyManager currencyManager))
            return false;
          PropertyDescriptorCollection itemProperties = currencyManager.GetItemProperties();
          string dataMember = this.DataMember;
          if (dataMember.Length != 0 && itemProperties[dataMember] != null)
            return false;
        }
        return true;
      }

      public void Sort(DataGridViewColumn objDataGridViewColumn, ListSortDirection enmDirection) => ((IBindingList) this.List).ApplySort(this.Props[objDataGridViewColumn.BoundColumnIndex], enmDirection);

      private void UnWireEvents()
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        if (currencyManager == null)
          return;
        currencyManager.PositionChanged -= new EventHandler(this.currencyManager_PositionChanged);
        currencyManager.ListChanged -= new ListChangedEventHandler(this.currencyManager_ListChanged);
        this.mobjDataConnectionState[32] = false;
      }

      private void WireEvents()
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        if (currencyManager == null)
          return;
        currencyManager.PositionChanged += new EventHandler(this.currencyManager_PositionChanged);
        currencyManager.ListChanged += new ListChangedEventHandler(this.currencyManager_ListChanged);
        this.mobjDataConnectionState[32] = true;
      }

      public void ProcessException(
        Exception objException,
        DataGridViewCellCancelEventArgs e,
        bool beginEdit)
      {
        DataGridViewDataErrorEventArgs e1 = new DataGridViewDataErrorEventArgs(objException, e.ColumnIndex, e.RowIndex, DataGridViewDataErrorContexts.Commit);
        this.Owner.OnDataErrorInternal(e1);
        if (e1.ThrowException)
          throw e1.Exception;
        if (e1.Cancel)
        {
          e.Cancel = true;
          if (!beginEdit || !(this.CurrencyManager.Current is IEditableObject current))
            return;
          current.BeginEdit();
        }
        else
          this.CancelRowEdit(false, false);
      }

      private void ProcessListChanged(ListChangedEventArgs e)
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        DataGridView owner = this.Owner;
        if (e.ListChangedType == ListChangedType.PropertyDescriptorAdded || e.ListChangedType == ListChangedType.PropertyDescriptorDeleted || e.ListChangedType == ListChangedType.PropertyDescriptorChanged)
        {
          this.mobjDataConnectionState[2] = true;
          try
          {
            this.DataSourceMetaDataChanged();
          }
          finally
          {
            this.mobjDataConnectionState[2] = false;
          }
        }
        else if (this.mobjDataConnectionState[65536] != owner.AllowUserToAddRowsInternal)
        {
          this.mobjDataConnectionState[1024] = true;
          try
          {
            DataGridView dataGridView = owner;
            dataGridView.RefreshRows(!dataGridView.InSortOperation);
            owner.PushAllowUserToAddRows();
          }
          finally
          {
            this.ResetDataConnectionState();
          }
        }
        else if (!this.mobjDataConnectionState[4] && owner.NewRowIndex == e.NewIndex)
        {
          if (e.ListChangedType == ListChangedType.ItemAdded)
          {
            if (this.mobjDataConnectionState[512] || this.mobjDataConnectionState[256])
              return;
            if (owner.Columns.Count > 0)
            {
              do
              {
                owner.NewRowIndex = -1;
                owner.AddNewRow(false);
              }
              while (this.DataBoundRowsCount() < currencyManager.Count);
            }
            this.mobjDataConnectionState[4] = true;
            this.MatchCurrencyManagerPosition(true, true);
          }
          else
          {
            if (e.ListChangedType != ListChangedType.ItemDeleted)
              return;
            if (this.mobjDataConnectionState[64])
              owner.PopulateNewRowWithDefaultValues();
            else if (this.mobjDataConnectionState[32768] || this.mobjDataConnectionState[512])
            {
              this.mobjDataConnectionState[1024] = true;
              try
              {
                DataGridView dataGridView = owner;
                dataGridView.RefreshRows(!dataGridView.InSortOperation);
                owner.PushAllowUserToAddRows();
              }
              finally
              {
                this.mobjDataConnectionState[1024] = false;
              }
            }
            else
            {
              if (!this.mobjDataConnectionState[4096] || currencyManager.List.Count != 0)
                return;
              this.AddNew();
            }
          }
        }
        else if (e.ListChangedType == ListChangedType.ItemAdded && currencyManager.List.Count == (owner.AllowUserToAddRowsInternal ? owner.Rows.Count - 1 : owner.Rows.Count))
        {
          if (!this.mobjDataConnectionState[4096] || !this.mobjDataConnectionState[8192])
            return;
          this.mobjDataConnectionState[16384] = true;
        }
        else
        {
          if (e.ListChangedType == ListChangedType.ItemDeleted)
          {
            if (this.mobjDataConnectionState[4096] && this.mobjDataConnectionState[16384] && this.mobjDataConnectionState[8192])
              this.mobjDataConnectionState[16384] = false;
            else if (!this.mobjDataConnectionState[4] && this.mobjDataConnectionState[32768])
            {
              this.mobjDataConnectionState[1024] = true;
              try
              {
                DataGridView dataGridView = owner;
                dataGridView.RefreshRows(!dataGridView.InSortOperation);
                owner.PushAllowUserToAddRows();
                return;
              }
              finally
              {
                this.mobjDataConnectionState[1024] = false;
              }
            }
            else if (currencyManager.List.Count == this.DataBoundRowsCount())
              return;
          }
          this.mobjDataConnectionState[16] = true;
          try
          {
            switch (e.ListChangedType)
            {
              case ListChangedType.Reset:
                this.mobjDataConnectionState[1024] = true;
                bool visible = owner.Visible;
                try
                {
                  DataGridView dataGridView = owner;
                  dataGridView.RefreshRows(!dataGridView.InSortOperation);
                  owner.PushAllowUserToAddRows();
                  this.ApplySortingInformationFromBackEnd();
                  break;
                }
                finally
                {
                  this.ResetDataConnectionState();
                  if (visible)
                    owner.Invalidate(true);
                }
              case ListChangedType.ItemAdded:
                if (owner.NewRowIndex != -1 && e.NewIndex == owner.Rows.Count)
                  throw new InvalidOperationException();
                owner.Rows.InsertInternal(e.NewIndex, owner.RowTemplateClone, true);
                break;
              case ListChangedType.ItemDeleted:
                owner.Rows.RemoveAtInternal(e.NewIndex, true);
                this.mobjDataConnectionState[8192] = false;
                break;
              case ListChangedType.ItemMoved:
                int intLow = Math.Min(e.OldIndex, e.NewIndex);
                int intHigh = Math.Max(e.OldIndex, e.NewIndex);
                owner.InvalidateRows(intLow, intHigh);
                break;
              case ListChangedType.ItemChanged:
                string strB = (string) null;
                if (!CommonUtils.IsMono && e.PropertyDescriptor != null)
                  strB = e.PropertyDescriptor.Name;
                for (int index = 0; index < owner.Columns.Count; ++index)
                {
                  DataGridViewColumn column = owner.Columns[index];
                  if (column.Visible && column.IsDataBound)
                  {
                    if (!CommonUtils.IsNullOrEmpty(strB))
                    {
                      if (string.Compare(column.DataPropertyName, strB, true, CultureInfo.InvariantCulture) == 0)
                        owner.OnCellCommonChange(index, e.NewIndex);
                    }
                    else
                      owner.OnCellCommonChange(index, e.NewIndex);
                  }
                }
                if (owner.CurrentCellAddress.Y == e.NewIndex && owner.IsCurrentCellInEditMode)
                {
                  owner.RefreshEdit();
                  break;
                }
                break;
            }
            if (owner.Rows.Count <= 0 || this.mobjDataConnectionState[8] || owner.InSortOperation)
              return;
            this.MatchCurrencyManagerPosition(false, e.ListChangedType == ListChangedType.Reset);
          }
          finally
          {
            this.mobjDataConnectionState[16] = false;
          }
        }
      }

      public bool PushValue(
        int intBoundColumnIndex,
        int intColumnIndex,
        int intRowIndex,
        object objValue)
      {
        try
        {
          if (objValue != null)
          {
            DataGridView owner = this.Owner;
            Type type = objValue.GetType();
            Type valueType = owner.Columns[intColumnIndex].ValueType;
            if (!valueType.IsAssignableFrom(type))
            {
              TypeConverter typeConverter = this.BoundColumnConverter(intBoundColumnIndex);
              if (typeConverter != null && typeConverter.CanConvertFrom(type))
              {
                objValue = typeConverter.ConvertFrom(objValue);
              }
              else
              {
                TypeConverter cachedTypeConverter = owner.GetCachedTypeConverter(type);
                if (cachedTypeConverter != null && cachedTypeConverter.CanConvertTo(valueType))
                  objValue = cachedTypeConverter.ConvertTo(objValue, valueType);
              }
            }
          }
          this.Props[intBoundColumnIndex].SetValue(this.CurrencyManager[intRowIndex], objValue);
        }
        catch (Exception ex)
        {
          if (ClientUtils.IsCriticalException(ex))
          {
            throw;
          }
          else
          {
            DataGridViewCellCancelEventArgs e = new DataGridViewCellCancelEventArgs(intColumnIndex, intRowIndex);
            this.ProcessException(ex, e, false);
            return !e.Cancel;
          }
        }
        return true;
      }

      public void ResetCachedAllowUserToAddRowsInternal() => this.mobjDataConnectionState[65536] = this.Owner.AllowUserToAddRowsInternal;

      private void ResetDataConnectionState()
      {
        this.mobjDataConnectionState = new SerializableBitVector32(4);
        if (this.CurrencyManager != null)
          this.mobjDataConnectionState[32] = true;
        this.ResetCachedAllowUserToAddRowsInternal();
      }

      public void SetDataConnection(object objDataSource, string strDataMember)
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        if (this.mobjDataConnectionState[1])
          return;
        this.ResetDataConnectionState();
        if (strDataMember == null)
          strDataMember = string.Empty;
        if (this.DataSource is ISupportInitializeNotification dataSource && this.mobjDataConnectionState[262144])
        {
          dataSource.Initialized -= new EventHandler(this.DataSource_Initialized);
          this.mobjDataConnectionState[262144] = false;
        }
        object objDataSource1 = objDataSource;
        this.DataSource = objDataSource1;
        this.DataMember = strDataMember;
        DataGridView owner = this.Owner;
        if (owner.BindingContext == null)
          return;
        this.mobjDataConnectionState[1] = true;
        try
        {
          this.UnWireEvents();
          if (objDataSource1 != null && owner.BindingContext != null && objDataSource1 != Convert.DBNull)
          {
            if (objDataSource1 is ISupportInitializeNotification initializeNotification && !initializeNotification.IsInitialized)
            {
              if (!this.mobjDataConnectionState[262144])
              {
                initializeNotification.Initialized += new EventHandler(this.DataSource_Initialized);
                this.mobjDataConnectionState[262144] = true;
              }
              currencyManager = (CurrencyManager) null;
              this.CurrencyManager = currencyManager;
            }
            else
            {
              currencyManager = owner.BindingContext[objDataSource1, this.DataMember] as CurrencyManager;
              this.CurrencyManager = currencyManager;
            }
          }
          else
          {
            currencyManager = (CurrencyManager) null;
            this.CurrencyManager = currencyManager;
          }
          this.WireEvents();
          this.Props = currencyManager == null ? (PropertyDescriptorCollection) null : currencyManager.GetItemProperties();
        }
        finally
        {
          this.mobjDataConnectionState[1] = false;
        }
        this.ResetCachedAllowUserToAddRowsInternal();
        if (currencyManager != null)
          this.LastListCount = currencyManager.Count;
        else
          this.LastListCount = -1;
      }

      public void AddNew()
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        if (currencyManager == null || !currencyManager.ShouldBind)
          return;
        this.mobjDataConnectionState[4] = false;
        this.mobjDataConnectionState[32768] = true;
        try
        {
          currencyManager.EndCurrentEdit();
        }
        finally
        {
          this.mobjDataConnectionState[32768] = false;
        }
        this.mobjDataConnectionState[512] = true;
        try
        {
          currencyManager.AddNew();
        }
        finally
        {
          this.mobjDataConnectionState[512] = false;
        }
      }

      public void ApplySortingInformationFromBackEnd()
      {
        if (this.CurrencyManager == null)
          return;
        PropertyDescriptor sortProperty = (PropertyDescriptor) null;
        DataGridView owner = this.Owner;
        SortOrder objSortOrder;
        this.GetSortingInformationFromBackend(out sortProperty, out objSortOrder);
        if (sortProperty == null)
        {
          for (int index = 0; index < owner.Columns.Count; ++index)
          {
            if (owner.Columns[index].IsDataBound)
              owner.Columns[index].HeaderCell.SortGlyphDirection = SortOrder.None;
          }
          owner.SortedColumn = (DataGridViewColumn) null;
          owner.SortOrder = SortOrder.None;
        }
        else
        {
          bool flag = false;
          for (int index = 0; index < owner.Columns.Count; ++index)
          {
            DataGridViewColumn column = owner.Columns[index];
            if (column.IsDataBound && column.SortMode != DataGridViewColumnSortMode.NotSortable)
            {
              if (ClientUtils.IsEquals(column.DataPropertyName, sortProperty.Name, StringComparison.OrdinalIgnoreCase))
              {
                if (!flag && !owner.InSortOperation)
                {
                  owner.SortedColumn = column;
                  owner.SortOrder = objSortOrder;
                  flag = true;
                }
                column.HeaderCell.SortGlyphDirection = objSortOrder;
              }
              else
                column.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
          }
        }
      }

      public TypeConverter BoundColumnConverter(int intBoundColumnIndex) => this.Props[intBoundColumnIndex].Converter;

      public int BoundColumnIndex(string strDataPropertyName)
      {
        PropertyDescriptorCollection props = this.Props;
        if (props == null)
          return -1;
        int num = -1;
        for (int index = 0; index < props.Count; ++index)
        {
          if (string.Compare(props[index].Name, strDataPropertyName, true, CultureInfo.InvariantCulture) == 0)
            return index;
        }
        return num;
      }

      public SortOrder BoundColumnSortOrder(int intBoundColumnIndex)
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        IBindingList list = currencyManager != null ? currencyManager.List as IBindingList : (IBindingList) null;
        if (list != null && list.SupportsSorting && list.IsSorted)
        {
          PropertyDescriptor sortProperty;
          SortOrder objSortOrder;
          this.GetSortingInformationFromBackend(out sortProperty, out objSortOrder);
          if (objSortOrder != SortOrder.None && string.Compare(this.Props[intBoundColumnIndex].Name, sortProperty.Name, true, CultureInfo.InvariantCulture) == 0)
            return objSortOrder;
        }
        return SortOrder.None;
      }

      public Type BoundColumnValueType(int intBoundColumnIndex) => this.Props[intBoundColumnIndex].PropertyType;

      public void CancelRowEdit(bool blnRestoreRow, bool blnAddNewFinished)
      {
        this.mobjDataConnectionState[64] = true;
        this.mobjDataConnectionState[128] = blnRestoreRow;
        try
        {
          object obj = (object) null;
          CurrencyManager currencyManager = this.CurrencyManager;
          if (currencyManager.Position >= 0 && currencyManager.Position < currencyManager.List.Count)
            obj = currencyManager.Current;
          currencyManager.CancelCurrentEdit();
          IEditableObject editableObject = (IEditableObject) null;
          if (currencyManager.Position >= 0 && currencyManager.Position < currencyManager.List.Count)
            editableObject = currencyManager.Current as IEditableObject;
          if (editableObject != null)
          {
            if (obj == editableObject)
              editableObject.BeginEdit();
          }
        }
        finally
        {
          this.mobjDataConnectionState[64] = false;
        }
        if (!blnAddNewFinished)
          return;
        this.mobjDataConnectionState[4] = true;
      }

      private void currencyManager_ListChanged(object sender, ListChangedEventArgs e)
      {
        this.mobjDataConnectionState[131072] = true;
        try
        {
          this.ProcessListChanged(e);
        }
        finally
        {
          this.mobjDataConnectionState[131072] = false;
        }
        this.Owner.OnDataBindingComplete(e.ListChangedType);
        this.LastListCount = this.CurrencyManager.Count;
      }

      private void currencyManager_PositionChanged(object sender, EventArgs e)
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        DataGridView owner = this.Owner;
        if (owner.Columns.Count == 0 || owner.Rows.Count == (owner.AllowUserToAddRowsInternal ? 1 : 0) || this.mobjDataConnectionState[8] || owner.AllowUserToAddRowsInternal && this.mobjDataConnectionState[4] && !this.mobjDataConnectionState[512] && currencyManager.Position > -1 && currencyManager.Position == owner.NewRowIndex && owner.CurrentCellAddress.Y != owner.NewRowIndex && currencyManager.Count == this.DataBoundRowsCount() + 1)
          return;
        this.mobjDataConnectionState[2048] = true;
        try
        {
          if (owner.InSortOperation)
            return;
          bool blnScrollIntoView = true;
          if (this.mobjDataConnectionState[256] && currencyManager.List is IBindingList list && list.SupportsSorting && list.IsSorted)
            blnScrollIntoView = false;
          bool flag = this.mobjDataConnectionState[64] && !this.mobjDataConnectionState[4];
          int lastListCount = this.LastListCount;
          bool blnClearSelection = ((flag ? 1 : 0) | (lastListCount == -1 ? 1 : (lastListCount == currencyManager.Count ? 1 : 0))) != 0;
          this.MatchCurrencyManagerPosition(blnScrollIntoView, blnClearSelection);
        }
        finally
        {
          this.mobjDataConnectionState[2048] = false;
        }
      }

      private int DataBoundRowsCount()
      {
        DataGridView owner = this.Owner;
        int count = owner.Rows.Count;
        if (owner.AllowUserToAddRowsInternal && owner.Rows.Count > 0 && (owner.CurrentCellAddress.Y != owner.NewRowIndex || owner.IsCurrentRowDirty))
          --count;
        return count;
      }

      public bool DataFieldIsReadOnly(int intBoundColumnIndex)
      {
        PropertyDescriptorCollection props = this.Props;
        return props != null && props[intBoundColumnIndex].IsReadOnly;
      }

      private void DataSource_Initialized(object sender, EventArgs e)
      {
        object dataSource = this.DataSource;
        if (dataSource is ISupportInitializeNotification initializeNotification)
          initializeNotification.Initialized -= new EventHandler(this.DataSource_Initialized);
        this.mobjDataConnectionState[262144] = false;
        this.SetDataConnection(dataSource, this.DataMember);
        DataGridView owner = this.Owner;
        owner.RefreshColumnsAndRows();
        owner.OnDataBindingComplete(ListChangedType.Reset);
      }

      private void DataSourceMetaDataChanged()
      {
        this.Props = this.CurrencyManager.GetItemProperties();
        this.Owner.RefreshColumnsAndRows();
      }

      public void DeleteRow(int intRowIndex)
      {
        this.mobjDataConnectionState[8] = true;
        try
        {
          CurrencyManager currencyManager = this.CurrencyManager;
          if (!this.mobjDataConnectionState[4])
          {
            DataGridView owner = this.Owner;
            if (owner.NewRowIndex != currencyManager.List.Count ? intRowIndex == owner.NewRowIndex : intRowIndex == owner.NewRowIndex - 1)
            {
              this.CancelRowEdit(false, true);
            }
            else
            {
              this.mobjDataConnectionState[4096] = true;
              this.mobjDataConnectionState[8192] = true;
              try
              {
                currencyManager.RemoveAt(intRowIndex);
              }
              finally
              {
                this.mobjDataConnectionState[4096] = false;
                this.mobjDataConnectionState[8192] = false;
              }
            }
          }
          else
          {
            this.mobjDataConnectionState[4096] = true;
            this.mobjDataConnectionState[8192] = true;
            try
            {
              currencyManager.RemoveAt(intRowIndex);
            }
            finally
            {
              this.mobjDataConnectionState[4096] = false;
              this.mobjDataConnectionState[8192] = false;
            }
          }
        }
        finally
        {
          this.mobjDataConnectionState[8] = false;
        }
      }

      public void Dispose()
      {
        this.UnWireEvents();
        this.CurrencyManager = (CurrencyManager) null;
      }

      public DataGridViewColumn[] GetCollectionOfBoundDataGridViewColumns()
      {
        PropertyDescriptorCollection props = this.Props;
        if (props == null)
          return (DataGridViewColumn[]) null;
        ArrayList arrayList = new ArrayList();
        for (int index = 0; index < props.Count; ++index)
        {
          if (!typeof (IList).IsAssignableFrom(props[index].PropertyType) || TypeDescriptor.GetConverter(typeof (Image)).CanConvertFrom(props[index].PropertyType))
          {
            DataGridViewColumn propertyDescriptor = this.Owner.GetColumnByPropertyDescriptor(props[index]);
            propertyDescriptor.IsDataBoundInternal = true;
            propertyDescriptor.BoundColumnIndex = index;
            propertyDescriptor.DataPropertyName = props[index].Name;
            propertyDescriptor.Name = props[index].Name;
            propertyDescriptor.BoundColumnConverter = props[index].Converter;
            propertyDescriptor.HeaderText = !CommonUtils.IsNullOrEmpty(props[index].DisplayName) ? props[index].DisplayName : props[index].Name;
            propertyDescriptor.ValueType = props[index].PropertyType;
            propertyDescriptor.IsBrowsableInternal = props[index].IsBrowsable;
            propertyDescriptor.ReadOnly = props[index].IsReadOnly;
            arrayList.Add((object) propertyDescriptor);
          }
        }
        DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[arrayList.Count];
        arrayList.CopyTo((Array) dataGridViewColumns);
        return dataGridViewColumns;
      }

      public string GetError(int intRowIndex)
      {
        IDataErrorInfo dataErrorInfo = (IDataErrorInfo) null;
        try
        {
          dataErrorInfo = this.CurrencyManager[intRowIndex] as IDataErrorInfo;
        }
        catch (Exception ex)
        {
          if (ClientUtils.IsCriticalException(ex) && !(ex is IndexOutOfRangeException))
          {
            throw;
          }
          else
          {
            DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(ex, -1, intRowIndex, DataGridViewDataErrorContexts.Display);
            this.Owner.OnDataErrorInternal(e);
            if (e.ThrowException)
              throw e.Exception;
          }
        }
        if (dataErrorInfo != null)
          return dataErrorInfo.Error;
        return string.Empty;
      }

      public string GetError(int intBoundColumnIndex, int intColumnIndex, int intRowIndex)
      {
        IDataErrorInfo dataErrorInfo = (IDataErrorInfo) null;
        try
        {
          dataErrorInfo = this.CurrencyManager[intRowIndex] as IDataErrorInfo;
        }
        catch (Exception ex)
        {
          if (ClientUtils.IsCriticalException(ex) && !(ex is IndexOutOfRangeException))
          {
            throw;
          }
          else
          {
            DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(ex, intColumnIndex, intRowIndex, DataGridViewDataErrorContexts.Display);
            this.Owner.OnDataErrorInternal(e);
            if (e.ThrowException)
              throw e.Exception;
          }
        }
        if (dataErrorInfo != null)
          return dataErrorInfo[this.Props[intBoundColumnIndex].Name];
        return string.Empty;
      }

      private void GetSortingInformationFromBackend(
        out PropertyDescriptor sortProperty,
        out SortOrder objSortOrder)
      {
        CurrencyManager currencyManager = this.CurrencyManager;
        IBindingList list = currencyManager != null ? currencyManager.List as IBindingList : (IBindingList) null;
        IBindingListView bindingListView = list != null ? list as IBindingListView : (IBindingListView) null;
        if (list == null || !list.SupportsSorting || !list.IsSorted)
        {
          objSortOrder = SortOrder.None;
          sortProperty = (PropertyDescriptor) null;
        }
        else if (list.SortProperty != null)
        {
          sortProperty = list.SortProperty;
          objSortOrder = list.SortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
        else if (bindingListView != null)
        {
          ListSortDescriptionCollection sortDescriptions = bindingListView.SortDescriptions;
          if (sortDescriptions != null && sortDescriptions.Count > 0 && sortDescriptions[0].PropertyDescriptor != null)
          {
            sortProperty = sortDescriptions[0].PropertyDescriptor;
            objSortOrder = sortDescriptions[0].SortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
          }
          else
          {
            sortProperty = (PropertyDescriptor) null;
            objSortOrder = SortOrder.None;
          }
        }
        else
        {
          sortProperty = (PropertyDescriptor) null;
          objSortOrder = SortOrder.None;
        }
      }

      public object GetValue(int intBoundColumnIndex, int intColumnIndex, int intRowIndex)
      {
        object obj = (object) null;
        try
        {
          obj = this.Props[intBoundColumnIndex].GetValue(this.CurrencyManager[intRowIndex]);
        }
        catch (Exception ex)
        {
          if (ClientUtils.IsCriticalException(ex) && !(ex is IndexOutOfRangeException))
          {
            throw;
          }
          else
          {
            DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(ex, intColumnIndex, intRowIndex, DataGridViewDataErrorContexts.Display);
            this.Owner.OnDataErrorInternal(e);
            if (e.ThrowException)
              throw e.Exception;
          }
        }
        return obj;
      }

      /// <summary>Matches the currency manager position.</summary>
      /// <param name="blnScrollIntoView">if set to <c>true</c> [scroll into view].</param>
      /// <param name="blnClearSelection">if set to <c>true</c> [clear selection].</param>
      public void MatchCurrencyManagerPosition(bool blnScrollIntoView, bool blnClearSelection)
      {
        DataGridView owner = this.Owner;
        if (owner.Columns.Count == 0)
          return;
        Point currentCellAddress;
        int num1;
        if (owner.CurrentCellAddress.X != -1)
        {
          currentCellAddress = owner.CurrentCellAddress;
          num1 = currentCellAddress.X;
        }
        else
          num1 = owner.FirstDisplayedColumnIndex;
        int num2 = num1;
        if (num2 == -1)
        {
          DataGridViewColumn firstColumn = owner.Columns.GetFirstColumn(DataGridViewElementStates.None);
          firstColumn.Visible = true;
          num2 = firstColumn.Index;
        }
        int position = this.CurrencyManager.Position;
        if (position == -1)
        {
          if (!owner.SetCurrentCellAddressCore(-1, -1, false, false, false))
            throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
        }
        else
        {
          if (position >= owner.Rows.Count)
            return;
          if ((owner.Rows.GetRowState(position) & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
            owner.Rows[position].Visible = true;
          DataGridView dataGridView = owner;
          if (!dataGridView.IsSharedCellVisible(dataGridView.Rows.SharedRow(position).Cells[num2], position) && owner.GroupingColumns.Count != 0)
            return;
          int num3 = position;
          currentCellAddress = owner.CurrentCellAddress;
          int y = currentCellAddress.Y;
          if (num3 == y)
          {
            int num4 = num2;
            currentCellAddress = owner.CurrentCellAddress;
            int x = currentCellAddress.X;
            if (num4 == x)
              return;
          }
          if (blnScrollIntoView && !owner.ScrollIntoView(num2, position, true) || num2 < owner.Columns.Count && position < owner.Rows.Count && !owner.SetAndSelectCurrentCellAddress(num2, position, true, false, false, blnClearSelection, false))
            throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
        }
      }

      /// <summary>Gets or sets the last list count.</summary>
      /// <value>The last list count.</value>
      private int LastListCount
      {
        get => this.mintLastListCount;
        set => this.mintLastListCount = value;
      }

      public bool AllowAdd
      {
        get
        {
          CurrencyManager currencyManager = this.CurrencyManager;
          return currencyManager != null && currencyManager.List is IBindingList && currencyManager.AllowAdd && ((IBindingList) currencyManager.List).SupportsChangeNotification;
        }
      }

      public bool AllowEdit
      {
        get
        {
          CurrencyManager currencyManager = this.CurrencyManager;
          return currencyManager != null && currencyManager.AllowEdit;
        }
      }

      public bool AllowRemove
      {
        get
        {
          CurrencyManager currencyManager = this.CurrencyManager;
          return currencyManager != null && currencyManager.List is IBindingList && currencyManager.AllowRemove && ((IBindingList) currencyManager.List).SupportsChangeNotification;
        }
      }

      public bool CancellingRowEdit => this.mobjDataConnectionState[64];

      /// <summary>Gets the currency manager.</summary>
      /// <value>The currency manager.</value>
      public CurrencyManager CurrencyManager
      {
        get => this.mobjCurrencyManager;
        private set => this.mobjCurrencyManager = value;
      }

      public string DataMember
      {
        get => this.mstrDataMember;
        private set => this.mstrDataMember = value;
      }

      public object DataSource
      {
        get => this.mobjDataSource;
        private set => this.mobjDataSource = value;
      }

      public bool DoNotChangePositionInTheCurrencyManager
      {
        get => this.mobjDataConnectionState[16];
        set => this.mobjDataConnectionState[16] = value;
      }

      public bool InterestedInRowEvents => this.mobjDataConnectionState[32];

      public IList List => this.CurrencyManager?.List;

      public bool ListWasReset => this.mobjDataConnectionState[1024];

      public bool PositionChangingOutsideDataGridView => !this.mobjDataConnectionState[8] && this.mobjDataConnectionState[2048];

      public bool ProcessingListChangedEvent => this.mobjDataConnectionState[131072];

      public bool ProcessingMetaDataChanges => this.mobjDataConnectionState[2];

      public bool RestoreRow => this.mobjDataConnectionState[128];

      /// <summary>Gets or sets the owner.</summary>
      /// <value>The owner.</value>
      private DataGridView Owner
      {
        get => this.mobjOwner;
        set => this.mobjOwner = value;
      }

      /// <summary>Gets or sets the props.</summary>
      /// <value>The props.</value>
      private PropertyDescriptorCollection Props
      {
        get
        {
          if (this.mobjProps == null && this.CurrencyManager != null)
            this.mobjProps = this.CurrencyManager.GetItemProperties();
          return this.mobjProps;
        }
        set => this.mobjProps = value;
      }

      public DataGridViewDataConnection(DataGridView objOwner)
      {
        this.DataMember = string.Empty;
        this.LastListCount = -1;
        this.Owner = objOwner;
        this.mobjDataConnectionState[4] = true;
      }
    }

    [Serializable]
    internal class LayoutData
    {
      public Rectangle ClientRectangle;
      public Rectangle ColumnHeaders;
      public bool ColumnHeadersVisible;
      public Rectangle Data;
      internal bool dirty;
      public Rectangle Inside;
      public Rectangle ResizeBoxRect;
      public Rectangle RowHeaders;
      public bool RowHeadersVisible;
      public Rectangle TopLeftHeader;

      public LayoutData()
      {
        this.dirty = true;
        this.ClientRectangle = Rectangle.Empty;
        this.Inside = Rectangle.Empty;
        this.RowHeaders = Rectangle.Empty;
        this.ColumnHeaders = Rectangle.Empty;
        this.TopLeftHeader = Rectangle.Empty;
        this.Data = Rectangle.Empty;
        this.ResizeBoxRect = Rectangle.Empty;
      }

      public LayoutData(DataGridView.LayoutData src)
      {
        this.dirty = true;
        this.ClientRectangle = Rectangle.Empty;
        this.Inside = Rectangle.Empty;
        this.RowHeaders = Rectangle.Empty;
        this.ColumnHeaders = Rectangle.Empty;
        this.TopLeftHeader = Rectangle.Empty;
        this.Data = Rectangle.Empty;
        this.ResizeBoxRect = Rectangle.Empty;
        this.ClientRectangle = src.ClientRectangle;
        this.TopLeftHeader = src.TopLeftHeader;
        this.ColumnHeaders = src.ColumnHeaders;
        this.RowHeaders = src.RowHeaders;
        this.Inside = src.Inside;
        this.Data = src.Data;
        this.ResizeBoxRect = src.ResizeBoxRect;
        this.ColumnHeadersVisible = src.ColumnHeadersVisible;
        this.RowHeadersVisible = src.RowHeadersVisible;
      }

      public override string ToString()
      {
        StringBuilder stringBuilder = new StringBuilder(100);
        stringBuilder.Append(base.ToString());
        stringBuilder.Append(" { \n");
        stringBuilder.Append("ClientRectangle = ");
        stringBuilder.Append(this.ClientRectangle.ToString());
        stringBuilder.Append('\n');
        stringBuilder.Append("Inside = ");
        stringBuilder.Append(this.Inside.ToString());
        stringBuilder.Append('\n');
        stringBuilder.Append("TopLeftHeader = ");
        stringBuilder.Append(this.TopLeftHeader.ToString());
        stringBuilder.Append('\n');
        stringBuilder.Append("ColumnHeaders = ");
        stringBuilder.Append(this.ColumnHeaders.ToString());
        stringBuilder.Append('\n');
        stringBuilder.Append("RowHeaders = ");
        stringBuilder.Append(this.RowHeaders.ToString());
        stringBuilder.Append('\n');
        stringBuilder.Append("Data = ");
        stringBuilder.Append(this.Data.ToString());
        stringBuilder.Append('\n');
        stringBuilder.Append("ResizeBoxRect = ");
        stringBuilder.Append(this.ResizeBoxRect.ToString());
        stringBuilder.Append('\n');
        stringBuilder.Append("ColumnHeadersVisible = ");
        stringBuilder.Append(this.ColumnHeadersVisible.ToString());
        stringBuilder.Append('\n');
        stringBuilder.Append("RowHeadersVisible = ");
        stringBuilder.Append(this.RowHeadersVisible.ToString());
        stringBuilder.Append(" }");
        return stringBuilder.ToString();
      }
    }

    [Serializable]
    internal class DisplayedBandsData
    {
      private bool mblnColumnInsertionOccurred;
      private bool mblnDirty;
      private int mintFirstDisplayedFrozenCol = -1;
      private int mintFirstDisplayedFrozenRow = -1;
      private int mintFirstDisplayedScrollingCol = -1;
      private int mintFirstDisplayedScrollingRow = -1;
      private int mintLastDisplayedFrozenCol = -1;
      private int mintLastDisplayedFrozenRow = -1;
      private int mintLastDisplayedScrollingRow = -1;
      private int mintLastTotallyDisplayedScrollingCol = -1;
      private int mintNumDisplayedFrozenCols;
      private int mintNumDisplayedFrozenRows;
      private int mintNumDisplayedScrollingCols;
      private int mintNumDisplayedScrollingRows;
      private int mintNumTotallyDisplayedFrozenRows;
      private int mintNumTotallyDisplayedScrollingRows;
      private int mintOldFirstDisplayedScrollingCol = -1;
      private int mintOldFirstDisplayedScrollingRow = -1;
      private int mintOldNumDisplayedFrozenRows;
      private int mintOldNumDisplayedScrollingRows;
      private bool mblnRowInsertionOccurred;

      public void CorrectColumnIndexAfterInsertion(int intColumnIndex, int insertionCount)
      {
        this.EnsureDirtyState();
        if (this.mintOldFirstDisplayedScrollingCol != -1 && intColumnIndex <= this.mintOldFirstDisplayedScrollingCol)
          this.mintOldFirstDisplayedScrollingCol += insertionCount;
        this.mblnColumnInsertionOccurred = true;
      }

      public void CorrectRowIndexAfterDeletion(int intRowIndex)
      {
        this.EnsureDirtyState();
        if (this.mintOldFirstDisplayedScrollingRow == -1 || intRowIndex > this.mintOldFirstDisplayedScrollingRow)
          return;
        --this.mintOldFirstDisplayedScrollingRow;
      }

      public void CorrectRowIndexAfterInsertion(int intRowIndex, int insertionCount)
      {
        this.EnsureDirtyState();
        if (this.mintOldFirstDisplayedScrollingRow != -1 && intRowIndex <= this.mintOldFirstDisplayedScrollingRow)
          this.mintOldFirstDisplayedScrollingRow += insertionCount;
        this.mblnRowInsertionOccurred = true;
        this.mintOldNumDisplayedScrollingRows += insertionCount;
        this.mintOldNumDisplayedFrozenRows += insertionCount;
      }

      public void EnsureDirtyState()
      {
        if (this.mblnDirty)
          return;
        this.mblnDirty = true;
        this.mblnRowInsertionOccurred = false;
        this.mblnColumnInsertionOccurred = false;
        this.SetOldValues();
      }

      private void SetOldValues()
      {
        this.mintOldFirstDisplayedScrollingRow = this.mintFirstDisplayedScrollingRow;
        this.mintOldFirstDisplayedScrollingCol = this.mintFirstDisplayedScrollingCol;
        this.mintOldNumDisplayedFrozenRows = this.mintNumDisplayedFrozenRows;
        this.mintOldNumDisplayedScrollingRows = this.mintNumDisplayedScrollingRows;
      }

      public bool ColumnInsertionOccurred => this.mblnColumnInsertionOccurred;

      public bool Dirty
      {
        get => this.mblnDirty;
        set => this.mblnDirty = value;
      }

      public int FirstDisplayedFrozenCol
      {
        set
        {
          if (value == this.mintFirstDisplayedFrozenCol)
            return;
          this.EnsureDirtyState();
          this.mintFirstDisplayedFrozenCol = value;
        }
      }

      public int FirstDisplayedFrozenRow
      {
        set
        {
          if (value == this.mintFirstDisplayedFrozenRow)
            return;
          this.EnsureDirtyState();
          this.mintFirstDisplayedFrozenRow = value;
        }
      }

      public int FirstDisplayedScrollingCol
      {
        get => this.mintFirstDisplayedScrollingCol;
        set
        {
          if (value == this.mintFirstDisplayedScrollingCol)
            return;
          this.EnsureDirtyState();
          this.mintFirstDisplayedScrollingCol = value;
        }
      }

      public int FirstDisplayedScrollingRow
      {
        get => this.mintFirstDisplayedScrollingRow;
        set
        {
          if (value == this.mintFirstDisplayedScrollingRow)
            return;
          this.EnsureDirtyState();
          this.mintFirstDisplayedScrollingRow = value;
        }
      }

      public int LastDisplayedFrozenCol
      {
        set
        {
          if (value == this.mintLastDisplayedFrozenCol)
            return;
          this.EnsureDirtyState();
          this.mintLastDisplayedFrozenCol = value;
        }
      }

      public int LastDisplayedFrozenRow
      {
        set
        {
          if (value == this.mintLastDisplayedFrozenRow)
            return;
          this.EnsureDirtyState();
          this.mintLastDisplayedFrozenRow = value;
        }
      }

      public int LastDisplayedScrollingRow
      {
        set
        {
          if (value == this.mintLastDisplayedScrollingRow)
            return;
          this.EnsureDirtyState();
          this.mintLastDisplayedScrollingRow = value;
        }
      }

      public int LastTotallyDisplayedScrollingCol
      {
        get => this.mintLastTotallyDisplayedScrollingCol;
        set
        {
          if (value == this.mintLastTotallyDisplayedScrollingCol)
            return;
          this.EnsureDirtyState();
          this.mintLastTotallyDisplayedScrollingCol = value;
        }
      }

      public int NumDisplayedFrozenCols
      {
        get => this.mintNumDisplayedFrozenCols;
        set
        {
          if (value == this.mintNumDisplayedFrozenCols)
            return;
          this.EnsureDirtyState();
          this.mintNumDisplayedFrozenCols = value;
        }
      }

      public int NumDisplayedFrozenRows
      {
        get => this.mintNumDisplayedFrozenRows;
        set
        {
          if (value == this.mintNumDisplayedFrozenRows)
            return;
          this.EnsureDirtyState();
          this.mintNumDisplayedFrozenRows = value;
        }
      }

      public int NumDisplayedScrollingCols
      {
        get => this.mintNumDisplayedScrollingCols;
        set
        {
          if (value == this.mintNumDisplayedScrollingCols)
            return;
          this.EnsureDirtyState();
          this.mintNumDisplayedScrollingCols = value;
        }
      }

      public int NumDisplayedScrollingRows
      {
        get => this.mintNumDisplayedScrollingRows;
        set
        {
          if (value == this.mintNumDisplayedScrollingRows)
            return;
          this.EnsureDirtyState();
          this.mintNumDisplayedScrollingRows = value;
        }
      }

      public int NumTotallyDisplayedFrozenRows
      {
        get => this.mintNumTotallyDisplayedFrozenRows;
        set
        {
          if (value == this.mintNumTotallyDisplayedFrozenRows)
            return;
          this.EnsureDirtyState();
          this.mintNumTotallyDisplayedFrozenRows = value;
        }
      }

      public int NumTotallyDisplayedScrollingRows
      {
        get => this.mintNumTotallyDisplayedScrollingRows;
        set
        {
          if (value == this.mintNumTotallyDisplayedScrollingRows)
            return;
          this.EnsureDirtyState();
          this.mintNumTotallyDisplayedScrollingRows = value;
        }
      }

      public int OldFirstDisplayedScrollingCol => this.mintOldFirstDisplayedScrollingCol;

      public int OldFirstDisplayedScrollingRow => this.mintOldFirstDisplayedScrollingRow;

      public int OldNumDisplayedFrozenRows => this.mintOldNumDisplayedFrozenRows;

      public int OldNumDisplayedScrollingRows => this.mintOldNumDisplayedScrollingRows;

      public bool RowInsertionOccurred => this.mblnRowInsertionOccurred;
    }
  }
}
