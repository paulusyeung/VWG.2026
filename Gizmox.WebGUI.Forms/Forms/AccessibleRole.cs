// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.AccessibleRole
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies values representing possible roles for an accessible object.</summary>
  /// <filterpriority>2</filterpriority>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public enum AccessibleRole
  {
    /// <summary>A system-provided role.</summary>
    /// <filterpriority>1</filterpriority>
    Default = -1, // 0xFFFFFFFF
    /// <summary>No role.</summary>
    /// <filterpriority>1</filterpriority>
    None = 0,
    /// <summary>A title or caption bar for a window.</summary>
    /// <filterpriority>1</filterpriority>
    TitleBar = 1,
    /// <summary>A menu bar, usually beneath the title bar of a window, from which users can select menus.</summary>
    /// <filterpriority>1</filterpriority>
    MenuBar = 2,
    /// <summary>A vertical or horizontal scroll bar, which can be either part of the client area or used in a control.</summary>
    /// <filterpriority>1</filterpriority>
    ScrollBar = 3,
    /// <summary>A special mouse pointer, which allows a user to manipulate user interface elements such as a window. For example, a user can click and drag a sizing grip in the lower-right corner of a window to resize it.</summary>
    /// <filterpriority>1</filterpriority>
    Grip = 4,
    /// <summary>A system sound, which is associated with various system events.</summary>
    /// <filterpriority>1</filterpriority>
    Sound = 5,
    /// <summary>A mouse pointer.</summary>
    /// <filterpriority>1</filterpriority>
    Cursor = 6,
    /// <summary>A caret, which is a flashing line, block, or bitmap that marks the location of the insertion point in a window's client area.</summary>
    /// <filterpriority>1</filterpriority>
    Caret = 7,
    /// <summary>An alert or condition that you can notify a user about. Use this role only for objects that embody an alert but are not associated with another user interface element, such as a message box, graphic, text, or sound.</summary>
    /// <filterpriority>1</filterpriority>
    Alert = 8,
    /// <summary>A window frame, which usually contains child objects such as a title bar, client, and other objects typically contained in a window.</summary>
    /// <filterpriority>1</filterpriority>
    Window = 9,
    /// <summary>A window's user area.</summary>
    /// <filterpriority>1</filterpriority>
    Client = 10, // 0x0000000A
    /// <summary>A menu, which presents a list of options from which the user can make a selection to perform an action. All menu types must have this role, including drop-down menus that are displayed by selection from a menu bar, and shortcut menus that are displayed when the right mouse button is clicked.</summary>
    /// <filterpriority>1</filterpriority>
    MenuPopup = 11, // 0x0000000B
    /// <summary>A menu item, which is an entry in a menu that a user can choose to carry out a command, select an option, or display another menu. Functionally, a menu item can be equivalent to a push button, radio button, check box, or menu.</summary>
    /// <filterpriority>1</filterpriority>
    MenuItem = 12, // 0x0000000C
    /// <summary>A tool tip, which is a small rectangular pop-up window that displays a brief description of the purpose of a button.</summary>
    /// <filterpriority>1</filterpriority>
    ToolTip = 13, // 0x0000000D
    /// <summary>The main window for an application.</summary>
    /// <filterpriority>1</filterpriority>
    Application = 14, // 0x0000000E
    /// <summary>A document window, which is always contained within an application window. This role applies only to multiple-document interface (MDI) windows and refers to an object that contains the MDI title bar.</summary>
    /// <filterpriority>1</filterpriority>
    Document = 15, // 0x0000000F
    /// <summary>A separate area in a frame, a split document window, or a rectangular area of the status bar that can be used to display information. Users can navigate between panes and within the contents of the current pane, but cannot navigate between items in different panes. Thus, panes represent a level of grouping lower than frame windows or documents, but above individual controls. Typically, the user navigates between panes by pressing TAB, F6, or CTRL+TAB, depending on the context.</summary>
    /// <filterpriority>1</filterpriority>
    Pane = 16, // 0x00000010
    /// <summary>A graphical image used to represent data.</summary>
    /// <filterpriority>1</filterpriority>
    Chart = 17, // 0x00000011
    /// <summary>A dialog box or message box.</summary>
    /// <filterpriority>1</filterpriority>
    Dialog = 18, // 0x00000012
    /// <summary>A window border. The entire border is represented by a single object, rather than by separate objects for each side.</summary>
    /// <filterpriority>1</filterpriority>
    Border = 19, // 0x00000013
    /// <summary>The objects grouped in a logical manner. There can be a parent-child relationship between the grouping object and the objects it contains.</summary>
    /// <filterpriority>1</filterpriority>
    Grouping = 20, // 0x00000014
    /// <summary>A space divided visually into two regions, such as a separator menu item or a separator dividing split panes within a window.</summary>
    /// <filterpriority>1</filterpriority>
    Separator = 21, // 0x00000015
    /// <summary>A toolbar, which is a grouping of controls that provide easy access to frequently used features.</summary>
    /// <filterpriority>1</filterpriority>
    ToolBar = 22, // 0x00000016
    /// <summary>A status bar, which is an area typically at the bottom of an application window that displays information about the current operation, state of the application, or selected object. The status bar can have multiple fields that display different kinds of information, such as an explanation of the currently selected menu command in the status bar.</summary>
    /// <filterpriority>1</filterpriority>
    StatusBar = 23, // 0x00000017
    /// <summary>A table containing rows and columns of cells and, optionally, row headers and column headers.</summary>
    /// <filterpriority>1</filterpriority>
    Table = 24, // 0x00000018
    /// <summary>A column header, which provides a visual label for a column in a table.</summary>
    /// <filterpriority>1</filterpriority>
    ColumnHeader = 25, // 0x00000019
    /// <summary>A row header, which provides a visual label for a table row.</summary>
    /// <filterpriority>1</filterpriority>
    RowHeader = 26, // 0x0000001A
    /// <summary>A column of cells within a table.</summary>
    /// <filterpriority>1</filterpriority>
    Column = 27, // 0x0000001B
    /// <summary>A row of cells within a table.</summary>
    /// <filterpriority>1</filterpriority>
    Row = 28, // 0x0000001C
    /// <summary>A cell within a table.</summary>
    /// <filterpriority>1</filterpriority>
    Cell = 29, // 0x0000001D
    /// <summary>A link, which is a connection between a source document and a destination document. This object might look like text or a graphic, but it acts like a button.</summary>
    /// <filterpriority>1</filterpriority>
    Link = 30, // 0x0000001E
    /// <summary>A Help display in the form of a ToolTip or Help balloon, which contains buttons and labels that users can click to open custom Help topics.</summary>
    /// <filterpriority>1</filterpriority>
    HelpBalloon = 31, // 0x0000001F
    /// <summary>A cartoon-like graphic object, such as Microsoft Office Assistant, which is typically displayed to provide help to users of an application.</summary>
    /// <filterpriority>1</filterpriority>
    Character = 32, // 0x00000020
    /// <summary>A list box, which allows the user to select one or more items.</summary>
    /// <filterpriority>1</filterpriority>
    List = 33, // 0x00000021
    /// <summary>An item in a list box or the list portion of a combo box, drop-down list box, or drop-down combo box.</summary>
    /// <filterpriority>1</filterpriority>
    ListItem = 34, // 0x00000022
    /// <summary>An outline or tree structure, such as a tree view control, which displays a hierarchical list and usually allows the user to expand and collapse branches.</summary>
    /// <filterpriority>1</filterpriority>
    Outline = 35, // 0x00000023
    /// <summary>An item in an outline or tree structure.</summary>
    /// <filterpriority>1</filterpriority>
    OutlineItem = 36, // 0x00000024
    /// <summary>A property page that allows a user to view the attributes for a page, such as the page's title, whether it is a home page, or whether the page has been modified. Normally, the only child of this control is a grouped object that contains the contents of the associated page.</summary>
    /// <filterpriority>1</filterpriority>
    PageTab = 37, // 0x00000025
    /// <summary>A property page, which is a dialog box that controls the appearance and the behavior of an object, such as a file or resource. A property page's appearance differs according to its purpose.</summary>
    /// <filterpriority>1</filterpriority>
    PropertyPage = 38, // 0x00000026
    /// <summary>An indicator, such as a pointer graphic, that points to the current item.</summary>
    /// <filterpriority>1</filterpriority>
    Indicator = 39, // 0x00000027
    /// <summary>A picture.</summary>
    /// <filterpriority>1</filterpriority>
    Graphic = 40, // 0x00000028
    /// <summary>The read-only text, such as in a label, for other controls or instructions in a dialog box. Static text cannot be modified or selected.</summary>
    /// <filterpriority>1</filterpriority>
    StaticText = 41, // 0x00000029
    /// <summary>The selectable text that can be editable or read-only.</summary>
    /// <filterpriority>1</filterpriority>
    Text = 42, // 0x0000002A
    /// <summary>A push button control, which is a small rectangular control that a user can turn on or off. A push button, also known as a command button, has a raised appearance in its default off state and a sunken appearance when it is turned on.</summary>
    /// <filterpriority>1</filterpriority>
    PushButton = 43, // 0x0000002B
    /// <summary>A check box control, which is an option that can be turned on or off independent of other options.</summary>
    /// <filterpriority>1</filterpriority>
    CheckButton = 44, // 0x0000002C
    /// <summary>An option button, also known as a radio button. All objects sharing a single parent that have this attribute are assumed to be part of a single mutually exclusive group. You can use grouped objects to divide option buttons into separate groups when necessary.</summary>
    /// <filterpriority>1</filterpriority>
    RadioButton = 45, // 0x0000002D
    /// <summary>A combo box, which is an edit control with an associated list box that provides a set of predefined choices.</summary>
    /// <filterpriority>1</filterpriority>
    ComboBox = 46, // 0x0000002E
    /// <summary>A drop-down list box. This control shows one item and allows the user to display and select another from a list of alternative choices.</summary>
    /// <filterpriority>1</filterpriority>
    DropList = 47, // 0x0000002F
    /// <summary>A progress bar, which indicates the progress of a lengthy operation by displaying colored lines inside a horizontal rectangle. The length of the lines in relation to the length of the rectangle corresponds to the percentage of the operation that is complete. This control does not take user input.</summary>
    /// <filterpriority>1</filterpriority>
    ProgressBar = 48, // 0x00000030
    /// <summary>A dial or knob. This can also be a read-only object, like a speedometer.</summary>
    /// <filterpriority>1</filterpriority>
    Dial = 49, // 0x00000031
    /// <summary>A hot-key field that allows the user to enter a combination or sequence of keystrokes to be used as a hot key, which enables users to perform an action quickly. A hot-key control displays the keystrokes entered by the user and ensures that the user selects a valid key combination.</summary>
    /// <filterpriority>1</filterpriority>
    HotkeyField = 50, // 0x00000032
    /// <summary>A control, sometimes called a trackbar, that enables a user to adjust a setting in given increments between minimum and maximum values by moving a slider. The volume controls in the Windows operating system are slider controls.</summary>
    /// <filterpriority>1</filterpriority>
    Slider = 51, // 0x00000033
    /// <summary>A spin box, also known as an up-down control, which contains a pair of arrow buttons. A user clicks the arrow buttons with a mouse to increment or decrement a value. A spin button control is most often used with a companion control, called a buddy window, where the current value is displayed.</summary>
    /// <filterpriority>1</filterpriority>
    SpinButton = 52, // 0x00000034
    /// <summary>A graphical image used to diagram data.</summary>
    /// <filterpriority>1</filterpriority>
    Diagram = 53, // 0x00000035
    /// <summary>An animation control, which contains content that is changing over time, such as a control that displays a series of bitmap frames, like a filmstrip. Animation controls are usually displayed when files are being copied, or when some other time-consuming task is being performed.</summary>
    /// <filterpriority>1</filterpriority>
    Animation = 54, // 0x00000036
    /// <summary>A mathematical equation.</summary>
    /// <filterpriority>1</filterpriority>
    Equation = 55, // 0x00000037
    /// <summary>A button that drops down a list of items.</summary>
    /// <filterpriority>1</filterpriority>
    ButtonDropDown = 56, // 0x00000038
    /// <summary>A button that drops down a menu.</summary>
    /// <filterpriority>1</filterpriority>
    ButtonMenu = 57, // 0x00000039
    /// <summary>A button that drops down a grid.</summary>
    /// <filterpriority>1</filterpriority>
    ButtonDropDownGrid = 58, // 0x0000003A
    /// <summary>A blank space between other objects.</summary>
    /// <filterpriority>1</filterpriority>
    WhiteSpace = 59, // 0x0000003B
    /// <summary>A container of page tab controls.</summary>
    /// <filterpriority>1</filterpriority>
    PageTabList = 60, // 0x0000003C
    /// <summary>A control that displays the time.</summary>
    /// <filterpriority>1</filterpriority>
    Clock = 61, // 0x0000003D
    SplitButton = 62, // 0x0000003E
    IpAddress = 63, // 0x0000003F
    OutlineButton = 64, // 0x00000040
  }
}
