#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.WebGUI
{
	[Serializable]
	public class WGAttributes
	{
		public const string SkipMultiTheme = "SMT";

		public const string SyncChangesOnVwgPostBack = "SCV";

		public const string CancelEditingMode = "CLM";

		public const string ControlEditMode = "CEM";

		public const string Emulation = "EMU";

		public const string MethodName = "ME";

		public const string BeforeEntranceEffect = "BEE";

		public const string AfterEntranceEffect = "AEE";

		public const string BeforeExitEffect = "BXE";

		public const string AfterExitEffect = "AXE";

		public const string Before = "BFR";

		public const string ExtendedToolTip = "ETT";

		public const string ExtendedToolTipTemplateName = "ETTN";

		public const string ExtendedToolTipKey = "ETTK";

		public const string ClientEventsPropogationTags = "OEPT";

		public const string PrimaryKey = "PK";

		public const string Default = "DEF";

		public const string AutoIncreased = "AI";

		public const string ZoneAnimationSpeed = "ZAS";

		public const string GroupingAreaBackColor = "GABG";

		public const string GroupingAreaBackgroundImage = "GABI";

		public const string GroupingAreaBackgroundImagePosition = "GABIP";

		public const string GroupingAreaBackgroundImageRepeat = "GABIR";

		public const string DropAreaHeight = "DAH";

		public const string GroupingAreaBorder = "GABR";

		public const string SelectionEndDay = "ESD";

		public const string SelectionEndMonth = "ESM";

		public const string SelectionEndYear = "ESY";

		public const string SelectionStartDay = "SSD";

		public const string WebSocketsConnectionId = "WSC";

		public const string WebSocketsData = "WSD";

		public const string SelectionStartMonth = "SSM";

		public const string SelectionStartYear = "SSY";

		public const string ShowGroupingDropArea = "SGDA";

		public const string FilterRow = "FTR";

		public const string CursorPositionX = "CPX";

		public const string CursorPositionY = "CPY";

		public const string StandardTab = "STAB";

		public const string SupportEditMode = "SEM";

		public const string EditMode = "EMD";

		public const string SupportActiveMode = "SAM";

		public const string NumberDecimalSeparator = "NDS";

		public const string CancelSelectOnDropDownNaviagation = "CSD";

		public const string HeaderHeight = "HH";

		public const string IsButtonControl = "IBC";

		public const string TickSize = "TSZ";

		public const string ShareFocus = "SF";

		public const string Title = "TL";

		public const string Mask = "MK";

		public const string CustomColors = "CCS";

		public const string ItemHeight = "IMH";

		public const string UpDownAlign = "UDA";

		public const string EffectedFormats = "EF";

		public const string ForceChildRedraw = "FCR";

		public const string OptionsComponent = "OC";

		public const string DraggedColumn = "DCN";

		public const string TargetColumn = "TCN";

		public const string AllowUserToOrderColumns = "AOC";

		public const string Password = "PWD";

		public const string MaxLength = "MH";

		public const string MinimumHeight = "MNH";

		public const string MaximumHeight = "MXH";

		public const string MinimumWidth = "MNW";

		public const string ShowModalMask = "SMM";

		public const string MaximumWidth = "MXW";

		public const string Rows = "RS";

		public const string Cols = "CS";

		public const string Rowspan = "RSP";

		public const string Colspan = "CSP";

		public const string Bounded = "BOD";

		public const string IsSplitterFixed = "ISF";

		public const string ShowUpDown = "SUD";

		public const string LabelEdit = "LE";

		public const string BeforeUnloadMessage = "BUM";

		public const string Advanced = "ADV";

		public const string LablesColumnWidth = "LCW";

		public const string SelectOnRightClick = "SOR";

		public const string DisableNavigation = "DNV";

		public const string UseItemStyleForSubItems = "UIS";

		public const string LinkState = "LS";

		public const string LinkColor = "LC";

		public const string ActiveLinkColor = "ALC";

		public const string VisitedLinkColor = "VLC";

		public const string AutoEllipsis = "AE";

		public const string AutoCheck = "ACK";

		public const string CharacterCasing = "CC";

		public const string GrowStyle = "GS";

		public const string ExplicitTarget = "ET";

		public const string Message = "MS";

		public const string Trace = "TRC";

		public const string CursorPosition = "CPS";

		public const string RelativePosition = "RPS";

		public const string AllowDrop = "AD";

		public const string AllowDrag = "ADG";

		public const string DropIndicatorPropogation = "DIP";

		public const string ExcludedDragTargets = "EDT";

		public const string KeyState = "KS";

		public const string DragTargets = "DTS";

		public const string DragTargetsComponent = "DTC";

		public const string AllowDragTargetsToPropegateChild = "APC";

		public const string DragSource = "DS";

		public const string DragSourceMember = "DSM";

		public const string IsMdiContainer = "IMC";

		public const string ObjectType = "OT";

		public const string Data = "DAT";

		public const string HasRedrawingParent = "HRP";

		public const string FlowDirection = "FD";

		public const string HidePromptOnLeave = "HPOL";

		public const string TextImageRelation = "TIR";

		public const string Relation = "REL";

		public const string ImageScaling = "IMSC";

		public const string Multiline = "MLT";

		public const string AcceptsTab = "ACT";

		public const string WordWrap = "WW";

		public const string DropDownWidth = "DDW";

		public const string Timer = "TM";

		public const string DateTime = "DT";

		public const string MinDate = "MND";

		public const string MaxDate = "MXD";

		public const string FirstDayOfWeek = "FDW";

		public const string MdiParent = "MDP";

		public const string Color = "CO";

		public const string ActiveForm = "AF";

		public const string Active = "AC";

		public const string IsDelayedDrawing = "IDD";

		public const string IsWindowSized = "IWS";

		public const string View = "VW";

		public const string OnDrawVisualEffects = "ODVE";

		public const string AfterDrawVisualEffects = "ADVE";

		public const string MinorVersion = "MINV";

		public const string MajorVersion = "MAJV";

		public const string Unique = "UNQ";

		public const string Description = "DSC";

		public const string FormStartPosition = "FSP";

		public const string FormBorderStyle = "FBS";

		public const string WindowState = "WS";

		public const string LastRender = "LR";

		public const string Id = "Id";

		public const string IsNew = "IN";

		public const string ChildGridHeight = "CGH";

		public const string IsExpanded = "IEX";

		public const string ExpansionIndicator = "EIN";

		public const string NumberOfChildRows = "NOC";

		public const string IsHierarchic = "IHC";

		public const string ColumnsCount = "ACH";

		public const string ColumnChooser = "CCH";

		public const string Width = "W";

		public const string Height = "H";

		public const string Docking = "D";

		public const string Anchoring = "A";

		public const string Done = "DN";

		public const string ToolBar = "TB";

		public const string Left = "L";

		public const string Right = "R";

		public const string Top = "T";

		public const string Bottom = "B";

		public const string Focus = "F";

		public const string Format = "FMT";

		public const string Frozen = "FZ";

		public const string Name = "N";

		public const string AccessibleName = "ACN";

		public const string Menu = "M";

		public const string Enabled = "En";

		public const string Pushed = "PU";

		public const string Events = "E";

		public const string Captures = "EC";

		public const string Border = "BR";

		public const string Visible = "V";

		public const string Background = "BG";

		public const string BackgroundImage = "BI";

		public const string BackgroundImageLayout = "BIL";

		public const string CustomStyle = "ES";

		public const string Font = "FN";

		public const string Fore = "FR";

		public const string Size = "SZ";

		public const string Scrollbars = "SB";

		public const string Text = "TX";

		public const string Type = "TP";

		public const string Image = "IM";

		public const string LargeImage = "LIM";

		public const string LargeImageWidth = "LIW";

		public const string LargeImageHeight = "LIH";

		public const string ImageSize = "IMS";

		public const string SelectedImage = "SIM";

		public const string StateImage = "TIM";

		public const string StateImageChecked = "TIMC";

		public const string StateImageUnchecked = "TIMU";

		public const string ExpandedImage = "EIM";

		public const string ImageAlign = "IA";

		public const string InterceptArrowKeys = "IAK";

		public const string Value = "VLB";

		public const string Code = "CD";

		public const string ToolTip = "TT";

		public const string HeaderToolTip = "HTT";

		public const string ZoneHeaderToolTip = "ZTT";

		public const string Style = "S";

		public const string AutoCompleteMode = "ACM";

		public const string IsAutoComplete = "IAC";

		public const string TextAlign = "TA";

		public const string HideButtons = "HB";

		public const string ContentAlign = "CA";

		public const string Icon = "I";

		public const string DropDown = "DD";

		public const string Selected = "SE";

		public const string Selectable = "SA";

		public const string Index = "IX";

		public const string Checked = "C";

		public const string Appearance = "AP";

		public const string VisualTemplate = "VS";

		public const string CheckBoxes = "CB";

		public const string RadioButtons = "RB";

		public const string HidePlusMinus = "HP";

		public const string ShowLines = "SL";

		public const string AlignTo = "AT";

		public const string AlignType = "ATP";

		public const string HasNodes = "HN";

		public const string HasSelected = "HS";

		public const string HasChecked = "HC";

		public const string Expanded = "EX";

		public const string Loaded = "LO";

		public const string GridLines = "GL";

		public const string SelectionIcons = "SI";

		public const string SelectionButtons = "SBTN";

		public const string SelectionMode = "SM";

		public const string SelectionStart = "SST";

		public const string SelectionLength = "SLN";

		public const string SelectionBackColor = "SBC";

		public const string SelectionForeColor = "SFC";

		public const string Shortcut = "SC";

		public const string ShortcutWidth = "SCW";

		public const string Multiple = "MU";

		public const string ErrorMessage = "EM";

		public const string ErrorCode = "ECD";

		public const string ErrorIconPadding = "EIP";

		public const string ErrorIconAlignment = "EIA";

		public const string ErrorIcon = "EI";

		public const string TabIndex = "TI";

		public const string ButtonHeight = "BH";

		public const string ButtonWidth = "BW";

		public const string ImageHeight = "IH";

		public const string ImageWidth = "IW";

		public const string CellBorderStyle = "CBS";

		public const string CustomTemplate = "CT";

		public const string IdentCount = "IDC";

		public const string FullRowSelect = "FRS";

		public const string TotalPages = "TOP";

		public const string CurrentPage = "CP";

		public const string CurrentCell = "CRC";

		public const string EnforceEqualRowSize = "EER";

		public const string Cursor = "CUR";

		public const string HeaderStyle = "HDS";

		public const string RowHeaders = "RHS";

		public const string ColumnHeaders = "CHS";

		public const string Sort = "SRT";

		public const string SortOrder = "SOD";

		public const string HelpVisible = "HV";

		public const string LoadingMessage = "LM";

		public const string WrapContents = "WC";

		public const string VerticalAlignment = "VA";

		public const string HorizontalAlignment = "HA";

		public const string ReadOnly = "RO";

		public const string AutoSize = "AS";

		public const string BorderStyle = "BS";

		public const string BorderColor = "BC";

		public const string BorderWidth = "BRW";

		public const string AcceptButton = "FAB";

		public const string ControlBox = "CBX";

		public const string CancelButton = "FCB";

		public const string Minimize = "MNE";

		public const string Maximize = "MXE";

		public const string Close = "CE";

		public const string Resize = "RE";

		public const string Windowless = "WL";

		public const string Mode = "MD";

		public const string Source = "SR";

		public const string Target = "TRG";

		public const string Member = "MM";

		public const string MemberID = "mId";

		public const string OwnerID = "oId";

		public const string OwnerEntryID = "oeId";

		public const string Return = "RET";

		public const string Argument = "ARG";

		public const string ArgumentType = "ARGT";

		public const string Animation = "AN";

		public const string PaddingAll = "PA";

		public const string PaddingLeft = "PL";

		public const string PaddingRight = "PR";

		public const string PaddingTop = "PT";

		public const string PaddingBottom = "PB";

		public const string MarginAll = "MA";

		public const string MarginLeft = "ML";

		public const string MarginRight = "MR";

		public const string MarginTop = "MT";

		public const string MarginBottom = "MB";

		public const string Maximum = "MAX";

		public const string Minimum = "MIN";

		public const string ThousandsSeparator = "TSS";

		public const string Increment = "INC";

		public const string Hexadecimal = "HEX";

		public const string DecimalPlaces = "DPL";

		public const string Depth = "DP";

		public const string Length = "LEN";

		public const string Frequency = "FRQ";

		public const string Orientation = "ORI";

		public const string Movie = "MO";

		public const string Quality = "QU";

		public const string KeyCode = "KC";

		public const string AltKey = "AK";

		public const string ControlKey = "CK";

		public const string ShiftKey = "SK";

		public const string KeyFilter = "KF";

		public const string ScrollTop = "SCT";

		public const string ScrollLeft = "SCL";

		public const string PromptChar = "PC";

		public const string LastEditCell = "LEC";

		public const string ClickOnce = "CL1";

		public const string Redraw = "RD";

		[EditorBrowsable(EditorBrowsableState.Never)]
		public const string Mashup = "MP";

		public const string Opacity = "OP";

		public const string Rotation = "RN";

		public const string ScaleX = "SCX";

		public const string ScaleY = "SCY";

		public const string SkewX = "SKX";

		public const string SkewY = "SKY";

		public const string Mapping = "MAP";

		public const string Assembly = "ASM";

		public const string ValueValidationExpression = "VVE";

		public const string CharacterValidationMask = "CVM";

		public const string CharacterValidationExpression = "CVE";

		public const string InValidateMessage = "IVM";

		public const string ClientUniqeId = "CUID";

		public const string ClientId = "CID";

		public const string RadioCheck = "RC";

		public const string IsSeperator = "ISS";

		public const string IsInline = "II";

		public const string MenuItemLabelWidth = "MILW";

		public const string MenuItemShortCutWidth = "MISW";

		public const string MenuItemArrowWidth = "MIAW";

		public const string MenuItemImageMaxWidth = "MIMW";

		public const string BoldedDays = "BD";

		public const string ShowColor = "SHC";

		public const string ShowImage = "SHI";

		public const string PopupOffsetHeight = "PUOH";

		[EditorBrowsable(EditorBrowsableState.Never)]
		public const string ClientInvocationTarget = "CIT";

		[EditorBrowsable(EditorBrowsableState.Never)]
		public const string ClientUpdateHandler = "CUH";

		[EditorBrowsable(EditorBrowsableState.Never)]
		public const string ClientInvocationMember = "CIM";

		[EditorBrowsable(EditorBrowsableState.Never)]
		public const string PreventDefaultAction = "CIP";

		[EditorBrowsable(EditorBrowsableState.Never)]
		public const string ClientInvocationArgument = "CIA";

		public const string ObjectStandBy = "OSB";

		public const string CheckOnClick = "COC";

		public const string CalanderViewType = "CVT";

		public const string TabLayout = "TBL";

		public const string ShowCloseButton = "SCB";

		public const string TabFontContainerHeight = "TFH";

		public const string MinimumClientHeight = "MCH";

		public const string MinimumClientWidth = "MCW";

		public const string RestoredWindowState = "RWS";

		public const string Extra = "EXT";

		public const string DisplayYearMonth = "DYM";

		public const string RestoredHeight = "RH";

		public const string RestoredWidth = "RW";

		public const string RestoredLeft = "RL";

		public const string RestoredTop = "RT";

		public const string OffsetY = "OY";

		public const string HeadersOffset = "HO";

		public const string SupportKeydownAccumulating = "SKA";

		public const string VirtualBlockSize = "VBS";

		public const string Virtual = "VR";

		public const string Direction = "DR";

		public const string Swipable = "SW";

		public const string RightToLeft = "RTL";

		public const string SupportMenuStickiness = "SMS";

		public const string HideOnWrap = "HOW";

		public const string ShowToolTip = "STT";

		public const string ShowGrip = "SG";

		public const string ModifierKeys = "MDK";

		public const string ShowDropDownItemsOnEnter = "SDOE";

		public const string IsCaptionVisible = "ICV";

		public const string UseClientUpdateHandler = "UCU";

		public const string ContextualTabGroup = "CTG";

		public const string RowCount = "RCT";

		public const string CaptionHeight = "CH";

		public const string DeviceOrientation = "DOR";

		public const string ScrAvailHeight = "SAH";

		public const string ScrAvailWidth = "SAW";

		public const string ScrHeight = "SCH";

		public const string ScrWidth = "SCW";

		public const string ScrColorDepth = "SCD";

		public const string ScrDevicePixelRatio = "SDPR";

		public const string BrwClientHeight = "BRH";

		public const string BrwClientWidth = "BRW";

		public const string CSS3 = "CSS3";

		public const string HTML5 = "H5";

		public const string MISC = "MSC";

		public const string WheelZoom = "WZ";

		public const string WheelSuspension = "WN";

		public const string StorageName = "SN";

		public const string ClientEvents = "OTS";

		public const string ClientComponentsEvents = "OCE";

		public const string ClientTag = "OTG";

		public const string CanGroupBy = "CG";

		public const string StartDay = "SD";

		public const string EndDay = "ED";

		public const string StartTime = "ST1";

		public const string EndTime = "ET1";

		public const string Subject = "SUB";

		public const string HourFormat = "HF";

		public const string IsToday = "ITD";

		public const string Duration = "DUR";

		public const string Start = "ST";

		public const string DisplayMonthHeader = "DMH";

		public const string FullMonth = "FM";

		public const string WorkStartHour = "WSH";

		public const string WorkEndHour = "WEH";

		public const string DisplayFirstWeekDay = "DFWD";

		public const string CurrentMonthHeader = "CMH";

		public const string DisplayStart = "DST";

		public const string DisplayDays = "DDS";

		public const string MonthDays = "MDS";

		public const string MonthHeader = "MHD";

		public const string MaximumDateDay = "XDD";

		public const string MaximumDateMonth = "XDM";

		public const string MaximumDateYear = "XDY";

		public const string MinimumDateDay = "NDD";

		public const string MinimumDateMonth = "NDM";

		public const string MinimumDateYear = "NDY";

		public const string EmptyDateYear = "EDY";

		public const string EventAvailability = "EA";

		public const string MaximumTabPageHeaders = "MTH";

		public const string MoreTabStartIndex = "MTS";

		public const string MoreTabVisible = "MTV";

		public const string RepeatCheck = "RCK";

		public const string EnableHighAccuracy = "EHA";

		public const string MaximumAge = "MAG";

		public const string Timeout = "TOT";

		public const string Latitude = "LAT";

		public const string Longitude = "LNG";

		public const string ShowEditingIcon = "SEI";

		public const string IsCustomFilter = "ICF";

		public const string NavigationKeyFilter = "NKF";

		public const string IsDirty = "IY";

		public const string TabControlDrawDirtyPages = "TDP";

		public const string Draggable = "DA";

		public const string DraggableParams = "DAP";

		public const string Resizable = "RA";

		public const string Droppable = "DPA";

		public const string DroppedControl = "DPC";

		public const string ExtendedPanelType = "EPT";

		public const string ColumnIndex = "CIX";

		public const string RowIndex = "RIX";

		public const string SupportsKeyNavigation = "SKN";

		public const string EnableGroupTabbing = "EGT";

		public const string ShowDropDownArrow = "SDA";

		public const string ResetOnSpace = "ROS";

		public const string ResetOnPrompt = "ROP";

		public const string AllowPromptAsInput = "API";

		public const string AcceptCotnrolId = "ACI";

		public const string AcceptCotnrol = "ACL";

		public const string CustomDropDown = "CDD";

		public const string ResizableParams = "REP";

		public const string ScrollerType = "SCTP";

		public const string AutoDrawn = "ADN";

		public const string DockingZoneId = "DZI";

		public const string ToolStripDropDown = "TSDD";

		public const string SelectedIndicator = "SIR";

		public const string AutoClose = "ACDD";

		public const string VisualTemplateListViewGrouping = "VIS_LV_GR";

		public const string VisualTemplateListViewItemRowTemplate = "VIS_LVI_TPL";

		public const string VisualTemplateListViewNewColumnOrder = "VIS_LV_CO";

		public const string VisualTemplateUseOriginalFont = "VIS_OF";

		public const string TextBoxRealTimeKeyEvents = "TBKEY";

		public const string VisualTemplateNativeDateTimePickerFormat = "VIS_DP_F";

		public const string FormattedText = "FT";

		public const string VisualTemplateCheckBoxCheckedText = "VIS_CH_CT";

		public const string VisualTemplateCheckBoxUnCheckedText = "VIS_CH_UT";

		public const string VisualTemplateCheckBoxShowLabel = "VIS_CH_SL";

		public const string VisualTemplateCheckBoxSwitchWidth = "VIS_CH_SW";

		public const string VisualTemplateCheckBoxSwitchSizing = "VIS_CHSS";

		public const string CheckOnDoubleClick = "CODC";

		public const string VisualTemplateTreeViewItemHeight = "VIS_TV_IH";

		public const string VisualTemplateTreeViewBackButtonHeight = "VIS_TV_BBH";

		public const string VisualTemplateTreeViewBackButtonText = "VIS_TV_BBT";

		public const string VisualTemplateDataGridViewNumberOfDisplayedColumns = "VIS_DGV_NOC";

		public const string VisualTemplateDataGridViewCaptionHeight = "VIS_DGV_CH";

		public const string VisualTemplateDataGridViewBottomMenuHeight = "VIS_DGV_BMH";

		public const string VisualTemplateDataGridViewDataPagesRowHeight = "VIS_DGV_DORH";

		public const string VisualTemplateDataGridViewDataPagesFilterOptions = "VIS_DGV_FO";

		public const string UploadControlMaxNumberOfFiles = "ULFiles";

		public const string UploadControlMaxFileSize = "ULMax";

		public const string UploadControlMinFileSize = "ULMin";

		public const string UploadControlFileTypes = "ULTypes";

		public const string UploadControlPost = "ULP";

		public const string UploadControlText = "ULT";

		public const string UploadControlShowFilenameOnBar = "ULBF";

		public const string UploadControlShowSpeedOnBar = "ULBS";

		public const string UploadControlClientChunkSize = "ULC";

		public const string UploadControlEnabled = "ULEN";

		public const string TextBoxRealTimeKeyboardEvents = "TBRTKE";

		public const string GrayedReadOnlyTextBox = "GROTB";

		public const string TreeNodeClickEventsOnToggle = "TNCEOT";

		public const string ToolBarItemAutoSizePreservedPlaceholders = "TBIASPP";

		public const string RecursiveResizeEvent = "RRE";

		public const string ForceSelectedIndexChanged = "FSIC";

		public const string ListViewShowGridLinesOnEmptyRows = "LVSGLOER";

		public const string Theme = "TH";

		public const string DataGridViewHierarchyLevel = "DGVHL";
	}
}
