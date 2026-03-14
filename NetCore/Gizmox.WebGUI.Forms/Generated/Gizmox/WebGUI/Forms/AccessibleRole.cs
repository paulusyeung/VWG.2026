#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
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
using Gizmox.WebGUI.Common.Extensibility;
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
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// Specifies values representing possible roles for an accessible object.</summary>
	/// 2</filterpriority>
	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum AccessibleRole
	{
		/// An alert or condition that you can notify a user about. Use this role only for objects that embody an alert but are not associated with another user interface element, such as a message box, graphic, text, or sound.</summary>
		/// 1</filterpriority>
		Alert = 8,
		/// An animation control, which contains content that is changing over time, such as a control that displays a series of bitmap frames, like a filmstrip. Animation controls are usually displayed when files are being copied, or when some other time-consuming task is being performed.</summary>
		/// 1</filterpriority>
		Animation = 54,
		/// The main window for an application.</summary>
		/// 1</filterpriority>
		Application = 14,
		/// A window border. The entire border is represented by a single object, rather than by separate objects for each side.</summary>
		/// 1</filterpriority>
		Border = 19,
		/// A button that drops down a list of items.</summary>
		/// 1</filterpriority>
		ButtonDropDown = 56,
		/// A button that drops down a grid.</summary>
		/// 1</filterpriority>
		ButtonDropDownGrid = 58,
		/// A button that drops down a menu.</summary>
		/// 1</filterpriority>
		ButtonMenu = 57,
		/// A caret, which is a flashing line, block, or bitmap that marks the location of the insertion point in a window's client area.</summary>
		/// 1</filterpriority>
		Caret = 7,
		/// A cell within a table.</summary>
		/// 1</filterpriority>
		Cell = 29,
		/// A cartoon-like graphic object, such as Microsoft Office Assistant, which is typically displayed to provide help to users of an application.</summary>
		/// 1</filterpriority>
		Character = 32,
		/// A graphical image used to represent data.</summary>
		/// 1</filterpriority>
		Chart = 17,
		/// A check box control, which is an option that can be turned on or off independent of other options.</summary>
		/// 1</filterpriority>
		CheckButton = 44,
		/// A window's user area.</summary>
		/// 1</filterpriority>
		Client = 10,
		/// A control that displays the time.</summary>
		/// 1</filterpriority>
		Clock = 61,
		/// A column of cells within a table.</summary>
		/// 1</filterpriority>
		Column = 27,
		/// A column header, which provides a visual label for a column in a table.</summary>
		/// 1</filterpriority>
		ColumnHeader = 25,
		/// A combo box, which is an edit control with an associated list box that provides a set of predefined choices.</summary>
		/// 1</filterpriority>
		ComboBox = 46,
		/// A mouse pointer.</summary>
		/// 1</filterpriority>
		Cursor = 6,
		/// A system-provided role.</summary>
		/// 1</filterpriority>
		Default = -1,
		/// A graphical image used to diagram data.</summary>
		/// 1</filterpriority>
		Diagram = 53,
		/// A dial or knob. This can also be a read-only object, like a speedometer.</summary>
		/// 1</filterpriority>
		Dial = 49,
		/// A dialog box or message box.</summary>
		/// 1</filterpriority>
		Dialog = 18,
		/// A document window, which is always contained within an application window. This role applies only to multiple-document interface (MDI) windows and refers to an object that contains the MDI title bar.</summary>
		/// 1</filterpriority>
		Document = 15,
		/// A drop-down list box. This control shows one item and allows the user to display and select another from a list of alternative choices.</summary>
		/// 1</filterpriority>
		DropList = 47,
		/// A mathematical equation.</summary>
		/// 1</filterpriority>
		Equation = 55,
		/// A picture.</summary>
		/// 1</filterpriority>
		Graphic = 40,
		/// A special mouse pointer, which allows a user to manipulate user interface elements such as a window. For example, a user can click and drag a sizing grip in the lower-right corner of a window to resize it.</summary>
		/// 1</filterpriority>
		Grip = 4,
		/// The objects grouped in a logical manner. There can be a parent-child relationship between the grouping object and the objects it contains.</summary>
		/// 1</filterpriority>
		Grouping = 20,
		/// A Help display in the form of a ToolTip or Help balloon, which contains buttons and labels that users can click to open custom Help topics.</summary>
		/// 1</filterpriority>
		HelpBalloon = 31,
		/// A hot-key field that allows the user to enter a combination or sequence of keystrokes to be used as a hot key, which enables users to perform an action quickly. A hot-key control displays the keystrokes entered by the user and ensures that the user selects a valid key combination.</summary>
		/// 1</filterpriority>
		HotkeyField = 50,
		/// An indicator, such as a pointer graphic, that points to the current item.</summary>
		/// 1</filterpriority>
		Indicator = 39,
		IpAddress = 63,
		/// A link, which is a connection between a source document and a destination document. This object might look like text or a graphic, but it acts like a button.</summary>
		/// 1</filterpriority>
		Link = 30,
		/// A list box, which allows the user to select one or more items.</summary>
		/// 1</filterpriority>
		List = 33,
		/// An item in a list box or the list portion of a combo box, drop-down list box, or drop-down combo box.</summary>
		/// 1</filterpriority>
		ListItem = 34,
		/// A menu bar, usually beneath the title bar of a window, from which users can select menus.</summary>
		/// 1</filterpriority>
		MenuBar = 2,
		/// A menu item, which is an entry in a menu that a user can choose to carry out a command, select an option, or display another menu. Functionally, a menu item can be equivalent to a push button, radio button, check box, or menu.</summary>
		/// 1</filterpriority>
		MenuItem = 12,
		/// A menu, which presents a list of options from which the user can make a selection to perform an action. All menu types must have this role, including drop-down menus that are displayed by selection from a menu bar, and shortcut menus that are displayed when the right mouse button is clicked.</summary>
		/// 1</filterpriority>
		MenuPopup = 11,
		/// No role.</summary>
		/// 1</filterpriority>
		None = 0,
		/// An outline or tree structure, such as a tree view control, which displays a hierarchical list and usually allows the user to expand and collapse branches.</summary>
		/// 1</filterpriority>
		Outline = 35,
		OutlineButton = 64,
		/// An item in an outline or tree structure.</summary>
		/// 1</filterpriority>
		OutlineItem = 36,
		/// A property page that allows a user to view the attributes for a page, such as the page's title, whether it is a home page, or whether the page has been modified. Normally, the only child of this control is a grouped object that contains the contents of the associated page.</summary>
		/// 1</filterpriority>
		PageTab = 37,
		/// A container of page tab controls.</summary>
		/// 1</filterpriority>
		PageTabList = 60,
		/// A separate area in a frame, a split document window, or a rectangular area of the status bar that can be used to display information. Users can navigate between panes and within the contents of the current pane, but cannot navigate between items in different panes. Thus, panes represent a level of grouping lower than frame windows or documents, but above individual controls. Typically, the user navigates between panes by pressing TAB, F6, or CTRL+TAB, depending on the context.</summary>
		/// 1</filterpriority>
		Pane = 16,
		/// A progress bar, which indicates the progress of a lengthy operation by displaying colored lines inside a horizontal rectangle. The length of the lines in relation to the length of the rectangle corresponds to the percentage of the operation that is complete. This control does not take user input.</summary>
		/// 1</filterpriority>
		ProgressBar = 48,
		/// A property page, which is a dialog box that controls the appearance and the behavior of an object, such as a file or resource. A property page's appearance differs according to its purpose.</summary>
		/// 1</filterpriority>
		PropertyPage = 38,
		/// A push button control, which is a small rectangular control that a user can turn on or off. A push button, also known as a command button, has a raised appearance in its default off state and a sunken appearance when it is turned on.</summary>
		/// 1</filterpriority>
		PushButton = 43,
		/// An option button, also known as a radio button. All objects sharing a single parent that have this attribute are assumed to be part of a single mutually exclusive group. You can use grouped objects to divide option buttons into separate groups when necessary.</summary>
		/// 1</filterpriority>
		RadioButton = 45,
		/// A row of cells within a table.</summary>
		/// 1</filterpriority>
		Row = 28,
		/// A row header, which provides a visual label for a table row.</summary>
		/// 1</filterpriority>
		RowHeader = 26,
		/// A vertical or horizontal scroll bar, which can be either part of the client area or used in a control.</summary>
		/// 1</filterpriority>
		ScrollBar = 3,
		/// A space divided visually into two regions, such as a separator menu item or a separator dividing split panes within a window.</summary>
		/// 1</filterpriority>
		Separator = 21,
		/// A control, sometimes called a trackbar, that enables a user to adjust a setting in given increments between minimum and maximum values by moving a slider. The volume controls in the Windows operating system are slider controls.</summary>
		/// 1</filterpriority>
		Slider = 51,
		/// A system sound, which is associated with various system events.</summary>
		/// 1</filterpriority>
		Sound = 5,
		/// A spin box, also known as an up-down control, which contains a pair of arrow buttons. A user clicks the arrow buttons with a mouse to increment or decrement a value. A spin button control is most often used with a companion control, called a buddy window, where the current value is displayed.</summary>
		/// 1</filterpriority>
		SpinButton = 52,
		SplitButton = 62,
		/// The read-only text, such as in a label, for other controls or instructions in a dialog box. Static text cannot be modified or selected.</summary>
		/// 1</filterpriority>
		StaticText = 41,
		/// A status bar, which is an area typically at the bottom of an application window that displays information about the current operation, state of the application, or selected object. The status bar can have multiple fields that display different kinds of information, such as an explanation of the currently selected menu command in the status bar.</summary>
		/// 1</filterpriority>
		StatusBar = 23,
		/// A table containing rows and columns of cells and, optionally, row headers and column headers.</summary>
		/// 1</filterpriority>
		Table = 24,
		/// The selectable text that can be editable or read-only.</summary>
		/// 1</filterpriority>
		Text = 42,
		/// A title or caption bar for a window.</summary>
		/// 1</filterpriority>
		TitleBar = 1,
		/// A toolbar, which is a grouping of controls that provide easy access to frequently used features.</summary>
		/// 1</filterpriority>
		ToolBar = 22,
		/// A tool tip, which is a small rectangular pop-up window that displays a brief description of the purpose of a button.</summary>
		/// 1</filterpriority>
		ToolTip = 13,
		/// A blank space between other objects.</summary>
		/// 1</filterpriority>
		WhiteSpace = 59,
		/// A window frame, which usually contains child objects such as a title bar, client, and other objects typically contained in a window.</summary>
		/// 1</filterpriority>
		Window = 9
	}
}
