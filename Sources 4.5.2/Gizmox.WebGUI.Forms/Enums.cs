#region Using

using System;
using System.ComponentModel;

#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Specifies the Tool Tip Icon
    /// </summary>
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public enum ToolTipIcon
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        Info,
        /// <summary>
        /// 
        /// </summary>
        Warning,
        /// <summary>
        /// 
        /// </summary>
        Error
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ScrollerType
    {
        /// <summary>
        /// 
        /// </summary>
        Default = 0,
        /// <summary>
        /// 
        /// </summary>
        Arrows = 1,
    }

    /// <summary>Specifies the position of the text and image relative to each other on a control.</summary>
    /// <filterpriority>2</filterpriority>
    public enum TextImageRelation
    {
        /// <summary>Specifies that the image is displayed vertically above the text of a control.</summary>
        /// <filterpriority>1</filterpriority>
        ImageAboveText = 1,
        /// <summary>Specifies that the image is displayed horizontally before the text of a control.</summary>
        /// <filterpriority>1</filterpriority>
        ImageBeforeText = 4,
        /// <summary>Specifies that the image and text share the same space on a control.</summary>
        /// <filterpriority>1</filterpriority>
        Overlay = 0,
        /// <summary>Specifies that the text is displayed vertically above the image of a control.</summary>
        /// <filterpriority>1</filterpriority>
        TextAboveImage = 2,
        /// <summary>Specifies that the text is displayed horizontally before the image of a control.</summary>
        /// <filterpriority>1</filterpriority>
        TextBeforeImage = 8
    }

    /// <summary>Provides static, predefined <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see> format names. Use them to identify the format of data that you store in an <see cref="T:Gizmox.WebGUI.Forms.IDataObject"></see>.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataFormats
    {
        /// <summary>Specifies a Windows bitmap format. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Bitmap;
        /// <summary>Specifies a comma-separated value (CSV) format, which is a common interchange format used by spreadsheets. This format is not used directly by Windows Forms. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string CommaSeparatedValue;
        /// <summary>Specifies the Windows device-independent bitmap (DIB) format. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Dib;
        /// <summary>Specifies the Windows Data Interchange Format (DIF), which Windows Forms does not directly use. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Dif;
        /// <summary>Specifies the Windows enhanced metafile format. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string EnhancedMetafile;
        /// <summary>Specifies the Windows file drop format, which Windows Forms does not directly use. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string FileDrop;
        /// <summary>Specifies text consisting of HTML data. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Html;
        /// <summary>Specifies the Windows culture format, which Windows Forms does not directly use. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Locale;
        /// <summary>Specifies the Windows metafile format, which Windows Forms does not directly use. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string MetafilePict;
        /// <summary>Specifies the standard Windows original equipment manufacturer (OEM) text format. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string OemText;
        /// <summary>Specifies the Windows palette format. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Palette;
        /// <summary>Specifies the Windows pen data format, which consists of pen strokes for handwriting software; Windows Forms does not use this format. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string PenData;
        /// <summary>Specifies the Resource Interchange File Format (RIFF) audio format, which Windows Forms does not directly use. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Riff;
        /// <summary>Specifies text consisting of Rich Text Format (RTF) data. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Rtf;
        /// <summary>Specifies a format that encapsulates any type of Windows Forms object. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Serializable;
        /// <summary>Specifies the Windows Forms string class format, which Windows Forms uses to store string objects. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string StringFormat;
        /// <summary>Specifies the Windows symbolic link format, which Windows Forms does not directly use. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string SymbolicLink;
        /// <summary>Specifies the standard ANSI text format. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Text;
        /// <summary>Specifies the Tagged Image File Format (TIFF), which Windows Forms does not directly use. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Tiff;
        /// <summary>Specifies the standard Windows Unicode text format. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string UnicodeText;
        /// <summary>Specifies the wave audio format, which Windows Forms does not directly use. This static field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string WaveAudio;

        private static int mintFormatCount;
        private static Format[] marrFormatList;
        private static object mobjInternalSyncObject;

        static DataFormats()
        {
            DataFormats.Text = "Text";
            DataFormats.UnicodeText = "UnicodeText";
            DataFormats.Dib = "DeviceIndependentBitmap";
            DataFormats.Bitmap = "Bitmap";
            DataFormats.EnhancedMetafile = "EnhancedMetafile";
            DataFormats.MetafilePict = "MetaFilePict";
            DataFormats.SymbolicLink = "SymbolicLink";
            DataFormats.Dif = "DataInterchangeFormat";
            DataFormats.Tiff = "TaggedImageFileFormat";
            DataFormats.OemText = "OEMText";
            DataFormats.Palette = "Palette";
            DataFormats.PenData = "PenData";
            DataFormats.Riff = "RiffAudio";
            DataFormats.WaveAudio = "WaveAudio";
            DataFormats.FileDrop = "FileDrop";
            DataFormats.Locale = "Locale";
            DataFormats.Html = "HTML Format";
            DataFormats.Rtf = "Rich Text Format";
            DataFormats.CommaSeparatedValue = "Csv";
            DataFormats.StringFormat = typeof(string).FullName;
            DataFormats.mintFormatCount = 0;
            DataFormats.mobjInternalSyncObject = new object();
        }

        private DataFormats() { }

        private static void EnsureFormatSpace(int intSize)
        {
            if ((DataFormats.marrFormatList == null) || (DataFormats.marrFormatList.Length <= (DataFormats.mintFormatCount + intSize)))
            {
                int num1 = DataFormats.mintFormatCount + 20;
                Format[] arrFormats = new Format[num1];
                for (int num2 = 0; num2 < DataFormats.mintFormatCount; num2++)
                {
                    arrFormats[num2] = DataFormats.marrFormatList[num2];
                }
                DataFormats.marrFormatList = arrFormats;
            }
        }

        private static void EnsurePredefined()
        {
            if (DataFormats.mintFormatCount == 0)
            {
                DataFormats.marrFormatList = new Format[] { new Format(DataFormats.UnicodeText, 13), new Format(DataFormats.Text, 1), new Format(DataFormats.Bitmap, 2), new Format(DataFormats.MetafilePict, 3), new Format(DataFormats.EnhancedMetafile, 14), new Format(DataFormats.Dif, 5), new Format(DataFormats.Tiff, 6), new Format(DataFormats.OemText, 7), new Format(DataFormats.Dib, 8), new Format(DataFormats.Palette, 9), new Format(DataFormats.PenData, 10), new Format(DataFormats.Riff, 11), new Format(DataFormats.WaveAudio, 12), new Format(DataFormats.SymbolicLink, 4), new Format(DataFormats.FileDrop, 15), new Format(DataFormats.Locale, 0x10) };
                DataFormats.mintFormatCount = DataFormats.marrFormatList.Length;
            }
        }

        /// <summary>Returns a <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> with the Windows Clipboard numeric ID and name for the specified ID.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> that has the Windows Clipboard numeric ID and the name of the format.</returns>
        /// <param name="id">The format ID. </param>
        /// <filterpriority>1</filterpriority>
        public static Format GetFormat(int id)
        {
            return null;
        }

        /// <summary>Returns a <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> with the Windows Clipboard numeric ID and name for the specified format.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> that has the Windows Clipboard numeric ID and the name of the format.</returns>
        /// <param name="strFormat">The format name. </param>
        /// <exception cref="T:System.ComponentModel.Win32Exception">Registering a new <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see> format failed. </exception>
        /// <filterpriority>1</filterpriority>
        public static Format GetFormat(string strFormat)
        {
            return null;
        }

        /// <summary>Represents a Clipboard format type.</summary>

        [Serializable()]
        public class Format
        {
            /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> class with a Boolean that indicates whether a Win32 handle is expected.</summary>
            /// <param name="strName">The name of this format. </param>
            /// <param name="intId">The ID number for this format. </param>
            public Format(string strName, int intId)
            {
                this.mstrName = strName;
                this.mintId = intId;
            }

            /// <summary>Gets the ID number for this format.</summary>
            /// <returns>The ID number for this format.</returns>
            public int Id
            {
                get
                {
                    return this.mintId;
                }
            }

            /// <summary>Gets the name of this format.</summary>
            /// <returns>The name of this format.</returns>
            public string Name
            {
                get
                {
                    return this.mstrName;
                }
            }

            private readonly int mintId;
            private readonly string mstrName;
        }
    }

    /// <summary>Determines when changes to a data source value get propagated to the corresponding data-bound control property.</summary>

    public enum ControlUpdateMode : byte
    {
        /// <summary>
        /// The bound control is updated when the data source value changes, or the data source position changes.
        /// </summary>
        OnPropertyChanged,
        /// <summary>
        /// The bound control is never updated when a data source value changes. The data source is write-only.
        /// </summary>
        Never
    }

    /// <summary>
    /// <summary>Specifies the style and behavior of a control.</summary>
    /// </summary>
    [Flags]
    public enum ControlStyles
    {
        /// <summary>If true, the control ignores the window message WM_ERASEBKGND to reduce flicker. This style should only be applied if the <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> bit is set to true.</summary>
        AllPaintingInWmPaint = 0x2000,
        /// <summary>If true, the control keeps a copy of the text rather than getting it from the <see cref="P:System.Windows.Forms.Control.Handle"></see> each time it is needed. This style defaults to false. This behavior improves performance, but makes it difficult to keep the text synchronized.</summary>
        CacheText = 0x4000,
        /// <summary>If true, the control is a container-like control.</summary>
        ContainerControl = 1,
        /// <summary>If true, drawing is performed in a buffer, and after it completes, the result is output to the screen. Double-buffering prevents flicker caused by the redrawing of the control. If you set <see cref="F:System.Windows.Forms.ControlStyles.DoubleBuffer"></see> to true, you should alsoset <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> and <see cref="F:System.Windows.Forms.ControlStyles.AllPaintingInWmPaint"></see> to true.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DoubleBuffer = 0x10000,
        /// <summary>If true, the <see cref="M:System.Windows.Forms.Control.OnNotifyMessage(System.Windows.Forms.Message)"></see> method is called for every message sent to the control's <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)"></see>. This style defaults to false. <see cref="F:System.Windows.Forms.ControlStyles.EnableNotifyMessage"></see> does not work in partial trust.</summary>
        EnableNotifyMessage = 0x8000,
        /// <summary>If true, the control has a fixed height when auto-scaled. For example, if a layout operation attempts to rescale the control to accommodate a new <see cref="T:System.Drawing.Font"></see>, the control's <see cref="P:System.Windows.Forms.Control.Height"></see> remains unchanged.</summary>
        /// <filterpriority>1</filterpriority>
        FixedHeight = 0x40,
        /// <summary>If true, the control has a fixed width when auto-scaled. For example, if a layout operation attempts to rescale the control to accommodate a new <see cref="T:System.Drawing.Font"></see>, the control's <see cref="P:System.Windows.Forms.Control.Width"></see> remains unchanged.</summary>
        FixedWidth = 0x20,
        /// <summary>If true, the control is drawn opaque and the background is not painted.</summary>
        Opaque = 4,
        /// <summary>If true, the control is first drawn to a buffer rather than directly to the screen, which can reduce flicker. If you set this property to true, you should also set the <see cref="F:System.Windows.Forms.ControlStyles.AllPaintingInWmPaint"></see> to true.</summary>
        /// <filterpriority>1</filterpriority>
        OptimizedDoubleBuffer = 0x20000,
        /// <summary>If true, the control is redrawn when it is resized.</summary>
        ResizeRedraw = 0x10,
        /// <summary>If true, the control can receive focus.</summary>
        Selectable = 0x200,
        /// <summary>If true, the control implements the standard <see cref="E:System.Windows.Forms.Control.Click"></see> behavior.</summary>
        StandardClick = 0x100,
        /// <summary>If true, the control implements the standard <see cref="E:System.Windows.Forms.Control.DoubleClick"></see> behavior. This style is ignored if the <see cref="F:System.Windows.Forms.ControlStyles.StandardClick"></see> bit is not set to true.</summary>
        StandardDoubleClick = 0x1000,
        /// <summary>If true, the control accepts a <see cref="P:System.Windows.Forms.Control.BackColor"></see> with an alpha component of less than 255 to simulate transparency. Transparency will be simulated only if the <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> bit is set to true and the parent control is derived from <see cref="T:System.Windows.Forms.Control"></see>.</summary>
        SupportsTransparentBackColor = 0x800,
        /// <summary>If true, the control does its own mouse processing, and mouse events are not handled by the operating system.</summary>
        UserMouse = 0x400,
        /// <summary>If true, the control paints itself rather than the operating system doing so. If false, the <see cref="E:System.Windows.Forms.Control.Paint"></see> event is not raised. This style only applies to classes derived from <see cref="T:System.Windows.Forms.Control"></see>.</summary>
        UserPaint = 2,
        /// <summary>Specifies that the value of the control's Text property, if set, determines the control's default Active Accessibility name and shortcut key.</summary>
        UseTextForAccessibility = 0x40000
    }


    #region Layout

    /// <summary>Specifies the day of the week.</summary>
    /// <filterpriority>2</filterpriority>

    public enum Day : byte
    {
        /// <summary>
        /// The day Monday.
        /// </summary>
        Monday,
        /// <summary>
        /// The day Tuesday
        /// </summary>
        Tuesday,
        /// <summary>
        /// The day Wednesday
        /// </summary>
        Wednesday,
        /// <summary>
        /// The day Thursday
        /// </summary>
        Thursday,
        /// <summary>
        /// The day Friday
        /// </summary>
        Friday,
        /// <summary>
        /// The day Saturday
        /// </summary>
        Saturday,
        /// <summary>
        /// The day Sunday
        /// </summary>
        Sunday,
        /// <summary>
        /// The day Default
        /// </summary>
        Default
    }
    /// <summary>
    /// Specifies how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
    /// </summary>

    public enum AutoSizeMode : byte
    {
        /// <summary>
        /// The control grows or shrinks to fit its contents. The control cannot be resized manually.
        /// </summary>
        GrowAndShrink,
        /// <summary>
        ///     The control grows as much as necessary to fit its contents but does not shrink
        ///     smaller than the value of its <see cref="Gizmox.WebGUI.Forms.Control.Size">Size</see> property.
        ///     The form can be resized, but cannot be made so small that any of its contained
        ///     controls are hidden.
        /// </summary>
        GrowOnly
    }

    /// <summary>
    /// Specifies which scroll bars will be visible on a control.
    /// </summary>
    [Serializable()]
    public enum ScrollBars : byte
    {
        /// <summary>Displays only a horizontal scroll bar.</summary>
        Horizontal = 1,

        /// <summary>Displays no scroll bars.</summary>
        None = 0,

        /// <summary>Displays both a horizontal and a vertical scroll bar.</summary>
        Both = 3,

        /// <summary>Displays only a vertical scroll bar.</summary>
        Vertical = 2
    }

    /// <summary>Specifies a value indicating whether the text appears from right to left, such as when using Hebrew or Arabic fonts.</summary>
    /// <filterpriority>2</filterpriority>

    public enum RightToLeft : byte
    {
        /// <summary>
        /// The text reads from left to right. This is the default.
        /// </summary>
        No = 0,
        /// <summary>
        /// The text reads from right to left.
        /// </summary>
        Yes = 1,
        /// <summary>
        /// The direction the text read is inherited from the parent control.
        /// </summary>
        Inherit = 2
    }    

    /// <summary>
    /// Specifies how an object or text in a control is horizontally aligned relative to an element of the control.  
    /// </summary>

    public enum HorizontalAlignment : byte
    {
        /// <summary>
        ///  The object or text is aligned in the center of the control element.   
        /// </summary>
        Left,
        /// <summary>
        ///  The object or text is aligned on the left of the control element.   
        /// </summary>
        Right,
        /// <summary>
        ///  The object or text is aligned on the right of the control element.   
        /// </summary>
        Center
    }

    /// <summary>
    /// Specifies how an object or text in a control is horizontally aligned relative to an element of the control and includes inheritance definition.  
    /// </summary>

    public enum ExtendedHorizontalAlignment : byte
    {
        /// <summary>
        ///  The object or text is aligned in the center of the control element.   
        /// </summary>
        Center,
        /// <summary>
        ///  The object or text is aligned on the left of the control element.   
        /// </summary>
        Left,
        /// <summary>
        ///  The object or text is aligned on the right of the control element.   
        /// </summary>
        Right,
        /// <summary>
        ///  The object or text is aligned according to the inherited definition.   
        /// </summary>
        Inherit
    }


    /// <summary>
    /// Specifies the selection behavior of a list box. 
    /// </summary>

    public enum SelectionMode : byte
    {
        /// <summary>
        ///  Multiple items can be selected, and the user can use the SHIFT, CTRL, and arrow keys to make selections 
        /// </summary>
        MultiExtended,
        /// <summary>
        ///  Multiple items can be selected.  
        /// </summary>
        MultiSimple,
        /// <summary>
        ///  No items can be selected.  
        /// </summary>
        None,
        /// <summary>
        ///  Only one item can be selected.  
        /// </summary>
        One
    }

    #endregion

    #region Borders

    /// <summary>
    /// Border style types
    /// </summary>
    [Serializable()]
    public enum BorderStyle
    {
        /// <summary>
        /// No border.
        /// </summary>
        None,
        /// <summary>
        /// A Single line border.
        /// </summary>
        FixedSingle,
        /// <summary>
        /// A three-dimensional border.
        /// </summary>
        Fixed3D,
        /// <summary>
        /// A Clear border.
        /// </summary>
        Clear,
        /// <summary>
        /// A dashed line border.
        /// </summary>
        Dashed,
        /// <summary>
        /// A dotted line border.
        /// </summary>
        Dotted,
        /// <summary>
        /// An inset border for a sunken control appearance.
        /// </summary>
        Inset,
        /// <summary>
        /// An outset border for a raised control appearance.
        /// </summary>
        Outset
    }

    /// <summary>
    /// The component style (WinForms Complaint)
    /// </summary>

    public enum FlatStyle
    {
        /// <summary>
        /// The control appears flat.
        /// </summary>
        Flat = 0,
        /// <summary>
        /// A control appears flat until the mouse pointer moves over it, at which point it appears three-dimensional.
        /// </summary>
        Popup = 1,
        /// <summary>
        /// The control appears three-dimensional.
        /// </summary>
        Standard = 2,
        /// <summary>
        /// The appearance of the control is determined by the user's operating system.
        /// </summary>
        System = 3
    }

    #endregion

    /// <summary>Specifies the case of characters in a <see cref="T:System.Windows.Forms.TextBox"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    public enum CharacterCasing : byte
    {
        /// <summary>
        /// The case of characters is left unchanged.
        /// </summary>
        Normal,
        /// <summary>
        /// Converts all characters to uppercase.
        /// </summary>
        Upper,
        /// <summary>
        /// Converts all characters to lowercase.
        /// </summary>
        Lower
    }

    /// <summary>Specifies the formats used with text-related methods of the <see cref="T:System.Windows.Forms.Clipboard"></see> and <see cref="T:System.Windows.Forms.DataObject"></see> classes.</summary>
    /// <filterpriority>2</filterpriority>

    public enum TextDataFormat : byte
    {
        /// <summary>
        /// Specifies the standard ANSI text format.
        /// </summary>
        Text,
        /// <summary>
        /// Specifies the standard Windows Unicode text format.
        /// </summary>
        UnicodeText,
        /// <summary>
        /// Specifies text consisting of rich text format (RTF) data
        /// </summary>
        Rtf,
        /// <summary>
        /// pecifies text consisting of HTML data.
        /// </summary>
        Html,
        /// <summary>
        /// Specifies a comma-separated value (CSV) format, which is a common interchange format used by spreadsheets.
        /// </summary>
        CommaSeparatedValue
    }

    /// <summary>Specifies the position of the image on the control.</summary>
    /// <filterpriority>2</filterpriority>    
    public enum ImageLayout : byte
    {
        /// <summary>
        /// The image is left-aligned at the top across the control's client rectangle.
        /// </summary>
        None,
        /// <summary>
        /// The image is tiled across the control's client rectangle.
        /// </summary>
        Tile,
        /// <summary>
        /// The image is centered within the control's client rectangle
        /// </summary>
        Center,
        /// <summary>
        /// The image is streched across the control's client rectangle.
        /// </summary>
        Stretch,
        /// <summary>
        /// The image is enlarged within the control's client rectangle.
        /// </summary>
        Zoom
    }

    /// <summary>
    /// Specifies the layout of the image when used as a backgound image
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public enum BackgroundImageRepeat : byte
    {
        /// <summary>
        /// The image is centered within the control's client rectangle
        /// </summary>
        None,

        /// <summary>
        /// The image is tiled across the control's client rectangle.
        /// </summary>
        Repeat,

        /// <summary>
        /// The image will be tiled across the control's horizontaly only
        /// </summary>
        RepeatX,

        /// <summary>
        /// The image will be tiled across the control's verticaly only
        /// </summary>
        RepeatY
    }

    /// <summary>
    /// Specifies position of the image when used as a backgound image
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public enum BackgroundImagePosition : byte
    {
        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned at the center.
        /// </summary>
        BottomCenter,

        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned on the left.
        /// </summary>
        BottomLeft,

        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned on the right.
        /// </summary>
        BottomRight,

        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned at the center.
        /// </summary>
        MiddleCenter,

        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned on the left.
        /// </summary>
        MiddleLeft,

        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned on the right.
        /// </summary>
        MiddleRight,

        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned at the center.
        /// </summary>
        TopCenter,

        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned on the left.
        /// </summary>
        TopLeft,

        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned on the right.
        /// </summary>
        TopRight
    }


    /// <summary>Specifies when a data source is updated when changes occur in the bound control.</summary>    
    public enum DataSourceUpdateMode : byte
    {
        /// <summary>
        /// Data source is updated when the control property is validated,
        /// </summary>
        OnValidation,
        /// <summary>
        /// Data source is updated whenever the value of the control property changes.
        /// </summary>
        OnPropertyChanged,
        /// <summary>
        /// Data source is never updated and values entered into the control are not parsed, validated or re-formatted.
        /// </summary>
        Never
    }

    /// <summary>Specifies the display and layout information for text strings.</summary>
    [Flags]

    public enum TextFormatFlags
    {
        /// <summary>Aligns the text on the bottom of the bounding rectangle. Applied only when the text is a single line.</summary>
        Bottom = 8,
        /// <summary>Applies the default formatting, which is left-aligned.</summary>
        Default = 0,
        /// <summary>Removes the end of trimmed lines, and replaces them with an ellipsis.</summary>
        EndEllipsis = 0x8000,
        /// <summary>Expands tab characters. The default number of characters per tab is eight. The <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.WordEllipsis"></see>, <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.PathEllipsis"></see>, and <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.EndEllipsis"></see> values cannot be used with <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.ExpandTabs"></see>.</summary>
        ExpandTabs = 0x40,
        /// <summary>Includes the font external leading in line height. Typically, external leading is not included in the height of a line of text.</summary>
        ExternalLeading = 0x200,
        /// <summary>Adds padding to the bounding rectangle to accommodate overhanging glyphs. </summary>
        GlyphOverhangPadding = 0,
        /// <summary>Applies to Windows 2000 and Windows XP only: </summary>
        HidePrefix = 0x100000,
        /// <summary>Centers the text horizontally within the bounding rectangle.</summary>
        HorizontalCenter = 1,
        /// <summary>Uses the system font to calculate text metrics.</summary>
        Internal = 0x1000,
        /// <summary>Aligns the text on the left side of the clipping area.</summary>
        Left = 0,
        /// <summary>Adds padding to both sides of the bounding rectangle.</summary>
        LeftAndRightPadding = 0x20000000,
        /// <summary>Modifies the specified string to match the displayed text. This value has no effect unless <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.EndEllipsis"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.PathEllipsis"></see> is also specified.</summary>
        ModifyString = 0x10000,
        /// <summary>Allows the overhanging parts of glyphs and unwrapped text reaching outside the formatting rectangle to show.</summary>
        NoClipping = 0x100,
        /// <summary>Applies to Windows 98, Windows Me, Windows 2000, or Windows XP only:</summary>
        NoFullWidthCharacterBreak = 0x80000,
        /// <summary>Does not add padding to the bounding rectangle.</summary>
        NoPadding = 0x10000000,
        /// <summary>Turns off processing of prefix characters. Typically, the ampersand (&amp;) mnemonic-prefix character is interpreted as a directive to underscore the character that follows, and the double-ampersand (&amp;&amp;) mnemonic-prefix characters as a directive to print a single ampersand. By specifying <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.NoPrefix"></see>, this processing is turned off. For example, an input string of "A&amp;bc&amp;&amp;d" with <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.NoPrefix"></see> applied would result in output of "A&amp;bc&amp;&amp;d".</summary>
        NoPrefix = 0x800,
        /// <summary>Removes the center of trimmed lines and replaces it with an ellipsis. </summary>
        PathEllipsis = 0x4000,
        /// <summary>Applies to Windows 2000 or Windows XP only: </summary>
        PrefixOnly = 0x200000,
        /// <summary>Preserves the clipping specified by a <see cref="T:System.Drawing.Graphics"></see> object. Applies only to methods receiving an <see cref="T:System.Drawing.IDeviceContext"></see> that is a <see cref="T:System.Drawing.Graphics"></see>.</summary>
        PreserveGraphicsClipping = 0x1000000,
        /// <summary>Preserves the transformation specified by a <see cref="T:System.Drawing.Graphics"></see>. Applies only to methods receiving an <see cref="T:System.Drawing.IDeviceContext"></see> that is a <see cref="T:System.Drawing.Graphics"></see>.</summary>
        PreserveGraphicsTranslateTransform = 0x2000000,
        /// <summary>Aligns the text on the right side of the clipping area.</summary>
        Right = 2,
        /// <summary>Displays the text from right to left.</summary>
        RightToLeft = 0x20000,
        /// <summary>Displays the text in a single line.</summary>
        SingleLine = 0x20,
        /// <summary>Specifies the text should be formatted for display on a <see cref="T:Gizmox.WebGUI.Forms.TextBox"></see> control.</summary>
        TextBoxControl = 0x2000,
        /// <summary>Aligns the text on the top of the bounding rectangle.</summary>
        Top = 0,
        /// <summary>Centers the text vertically, within the bounding rectangle.</summary>
        VerticalCenter = 4,
        /// <summary>Breaks the text at the end of a word.</summary>
        WordBreak = 0x10,
        /// <summary>Trims the line to the nearest word and an ellipsis is placed at the end of a trimmed line.</summary>
        WordEllipsis = 0x40000
    }


    /// <summary>
    /// 
    /// </summary>
    public enum FormWindowState : byte
    {
        /// <summary>
        /// A maximized window.
        /// </summary>
        Maximized = 2,
        /// <summary>
        /// A minimized window.
        /// </summary>
        Minimized = 1,
        /// <summary>
        /// A default sized window.
        /// </summary>
        Normal = 0
    }


    /// <summary>
    /// 
    /// </summary>
    public enum FormStartPosition : byte
    {
        /// <summary>
        /// The form is centered within the bounds of its parent form.
        /// </summary>
        CenterParent = 4,
        /// <summary>
        /// The form is centered on the current display, and has the dimensions specified in the form's size.
        /// </summary>
        CenterScreen = 1,
        /// <summary>
        /// The position of the form is determined by the Location property.
        /// </summary>
        Manual = 0,
        /// <summary>
        /// The form is positioned at the Windows default location and has the bounds determined by Windows default.
        /// </summary>
        WindowsDefaultBounds = 3,
        /// <summary>
        /// The form is positioned at the Windows default location and has the dimensions specified in the form's size.
        /// </summary>
        WindowsDefaultLocation = 2
    }

    /// <summary>
    /// Specifies shortcut keys that can be used.
    /// </summary>
    public enum Shortcut
    {
        /// <summary>
        /// The shortcut keys Alt+0
        /// </summary>        
        Alt0 = 0x40030,

        /// <summary>
        /// The shortcut keys Alt+1
        /// </summary>
        Alt1 = 0x40031,

        /// <summary>
        /// The shortcut keys Alt+2
        /// </summary>
        Alt2 = 0x40032,

        /// <summary>
        /// The shortcut keys Alt+3
        /// </summary>
        Alt3 = 0x40033,

        /// <summary>
        /// The shortcut keys Alt+4
        /// </summary>
        Alt4 = 0x40034,

        /// <summary>
        /// The shortcut keys Alt+5
        /// </summary>
        Alt5 = 0x40035,

        /// <summary>
        /// The shortcut keys Alt+6
        /// </summary>
        Alt6 = 0x40036,

        /// <summary>
        /// The shortcut keys Alt+7
        /// </summary>
        Alt7 = 0x40037,

        /// <summary>
        /// The shortcut keys Alt+8
        /// </summary>
        Alt8 = 0x40038,

        /// <summary>
        /// The shortcut keys Alt+9
        /// </summary>
        Alt9 = 0x40039,

        /// <summary>
        /// The shortcut keys Alt+Bksp
        /// </summary>
        AltBksp = 0x40008,

        /// <summary>
        /// The shortcut keys Alt+F1
        /// </summary>
        AltF1 = 0x40070,

        /// <summary>
        /// The shortcut keys Alt+F10
        /// </summary>
        AltF10 = 0x40079,

        /// <summary>
        /// The shortcut keys Alt+F11
        /// </summary>
        AltF11 = 0x4007a,

        /// <summary>
        /// The shortcut keys Alt+F12
        /// </summary>
        AltF12 = 0x4007b,

        /// <summary>
        /// The shortcut keys Alt+F2
        /// </summary>
        AltF2 = 0x40071,

        /// <summary>
        /// The shortcut keys Alt+F3
        /// </summary>
        AltF3 = 0x40072,

        /// <summary>
        /// The shortcut keys Alt+F4
        /// </summary>
        AltF4 = 0x40073,

        /// <summary>
        /// The shortcut keys Alt+F5
        /// </summary>
        AltF5 = 0x40074,

        /// <summary>
        /// The shortcut keys Alt+F6
        /// </summary>
        AltF6 = 0x40075,

        /// <summary>
        /// The shortcut keys Alt+F7
        /// </summary>
        AltF7 = 0x40076,

        /// <summary>
        /// The shortcut keys Alt+F8
        /// </summary>
        AltF8 = 0x40077,

        /// <summary>
        /// The shortcut keys Alt+F9
        /// </summary>
        AltF9 = 0x40078,

        /// <summary>
        /// The shortcut keys Ctrl+0
        /// </summary>
        Ctrl0 = 0x20030,

        /// <summary>
        /// The shortcut keys Ctrl+1
        /// </summary>
        Ctrl1 = 0x20031,

        /// <summary>
        /// The shortcut keys Ctrl+2
        /// </summary>
        Ctrl2 = 0x20032,

        /// <summary>
        /// The shortcut keys Ctrl+3
        /// </summary>
        Ctrl3 = 0x20033,

        /// <summary>
        /// The shortcut keys Ctrl+4
        /// </summary>
        Ctrl4 = 0x20034,

        /// <summary>
        /// The shortcut keys Ctrl+5
        /// </summary>
        Ctrl5 = 0x20035,

        /// <summary>
        /// The shortcut keys Ctrl+6
        /// </summary>
        Ctrl6 = 0x20036,

        /// <summary>
        /// The shortcut keys Ctrl+7
        /// </summary>
        Ctrl7 = 0x20037,

        /// <summary>
        /// The shortcut keys Ctrl+8
        /// </summary>
        Ctrl8 = 0x20038,

        /// <summary>
        /// The shortcut keys Ctrl+9
        /// </summary>
        Ctrl9 = 0x20039,

        /// <summary>
        /// The shortcut keys Ctrl+A
        /// </summary>
        CtrlA = 0x20041,

        /// <summary>
        /// The shortcut keys Ctrl+B
        /// </summary>
        CtrlB = 0x20042,

        /// <summary>
        /// The shortcut keys Ctrl+C
        /// </summary>
        CtrlC = 0x20043,

        /// <summary>
        /// The shortcut keys Ctrl+D
        /// </summary>
        CtrlD = 0x20044,

        /// <summary>
        /// The shortcut keys Ctrl+Del
        /// </summary>
        CtrlDel = 0x2002e,

        /// <summary>
        /// The shortcut keys Ctrl+E
        /// </summary>
        CtrlE = 0x20045,

        /// <summary>
        /// The shortcut keys Ctrl+F
        /// </summary>
        CtrlF = 0x20046,

        /// <summary>
        /// The shortcut keys Ctrl+F1
        /// </summary>
        CtrlF1 = 0x20070,

        /// <summary>
        /// The shortcut keys Ctrl+F10
        /// </summary>
        CtrlF10 = 0x20079,

        /// <summary>
        /// The shortcut keys Ctrl+F11
        /// </summary>
        CtrlF11 = 0x2007a,

        /// <summary>
        /// The shortcut keys Ctrl+F12
        /// </summary>
        CtrlF12 = 0x2007b,

        /// <summary>
        /// The shortcut keys Ctrl+F2
        /// </summary>
        CtrlF2 = 0x20071,

        /// <summary>
        /// The shortcut keys Ctrl+F3
        /// </summary>
        CtrlF3 = 0x20072,

        /// <summary>
        /// The shortcut keys Ctrl+F4
        /// </summary>
        CtrlF4 = 0x20073,

        /// <summary>
        /// The shortcut keys Ctrl+F5
        /// </summary>
        CtrlF5 = 0x20074,

        /// <summary>
        /// The shortcut keys Ctrl+F6
        /// </summary>
        CtrlF6 = 0x20075,

        /// <summary>
        /// The shortcut keys Ctrl+F7
        /// </summary>
        CtrlF7 = 0x20076,

        /// <summary>
        /// The shortcut keys Ctrl+F8
        /// </summary>
        CtrlF8 = 0x20077,

        /// <summary>
        /// The shortcut keys Ctrl+F9
        /// </summary>
        CtrlF9 = 0x20078,

        /// <summary>
        /// The shortcut keys Ctrl+G
        /// </summary>
        CtrlG = 0x20047,

        /// <summary>
        /// The shortcut keys Ctrl+H
        /// </summary>
        CtrlH = 0x20048,

        /// <summary>
        /// The shortcut keys Ctrl+I
        /// </summary>
        CtrlI = 0x20049,

        /// <summary>
        /// The shortcut keys Ctrl+Ins
        /// </summary>
        CtrlIns = 0x2002d,

        /// <summary>
        /// The shortcut keys Ctrl+J
        /// </summary>
        CtrlJ = 0x2004a,

        /// <summary>
        /// The shortcut keys Ctrl+K
        /// </summary>
        CtrlK = 0x2004b,

        /// <summary>
        /// The shortcut keys Ctrl+L
        /// </summary>
        CtrlL = 0x2004c,

        /// <summary>
        /// The shortcut keys Ctrl+M
        /// </summary>
        CtrlM = 0x2004d,

        /// <summary>
        /// The shortcut keys Ctrl+N
        /// </summary>
        CtrlN = 0x2004e,

        /// <summary>
        /// The shortcut keys Ctrl+O
        /// </summary>
        CtrlO = 0x2004f,

        /// <summary>
        /// The shortcut keys Ctrl+P
        /// </summary>
        CtrlP = 0x20050,

        /// <summary>
        /// The shortcut keys Ctrl+Q
        /// </summary>
        CtrlQ = 0x20051,

        /// <summary>
        /// The shortcut keys Ctrl+R
        /// </summary>
        CtrlR = 0x20052,

        /// <summary>
        /// The shortcut keys Ctrl+S
        /// </summary>
        CtrlS = 0x20053,

        /// <summary>
        /// The shortcut keys CtrlShift+0
        /// </summary>
        CtrlShift0 = 0x30030,

        /// <summary>
        /// The shortcut keys CtrlShift+1
        /// </summary>
        CtrlShift1 = 0x30031,

        /// <summary>
        /// The shortcut keys CtrlShift+2
        /// </summary>
        CtrlShift2 = 0x30032,

        /// <summary>
        /// The shortcut keys CtrlShift+3
        /// </summary>
        CtrlShift3 = 0x30033,

        /// <summary>
        /// The shortcut keys CtrlShift+4
        /// </summary>
        CtrlShift4 = 0x30034,

        /// <summary>
        /// The shortcut keys CtrlShift+5
        /// </summary>
        CtrlShift5 = 0x30035,

        /// <summary>
        /// The shortcut keys CtrlShift+6
        /// </summary>
        CtrlShift6 = 0x30036,

        /// <summary>
        /// The shortcut keys CtrlShift+7
        /// </summary>
        CtrlShift7 = 0x30037,

        /// <summary>
        /// The shortcut keys CtrlShift+8
        /// </summary>
        CtrlShift8 = 0x30038,

        /// <summary>
        /// The shortcut keys CtrlShift+9
        /// </summary>
        CtrlShift9 = 0x30039,

        /// <summary>
        /// The shortcut keys CtrlShift+A
        /// </summary>
        CtrlShiftA = 0x30041,

        /// <summary>
        /// The shortcut keys CtrlShift+B
        /// </summary>
        CtrlShiftB = 0x30042,

        /// <summary>
        /// The shortcut keys CtrlShift+C
        /// </summary>
        CtrlShiftC = 0x30043,

        /// <summary>
        /// The shortcut keys CtrlShift+D
        /// </summary>
        CtrlShiftD = 0x30044,

        /// <summary>
        /// The shortcut keys CtrlShift+E
        /// </summary>
        CtrlShiftE = 0x30045,

        /// <summary>
        /// The shortcut keys CtrlShift+F
        /// </summary>
        CtrlShiftF = 0x30046,

        /// <summary>
        /// The shortcut keys CtrlShift+F1
        /// </summary>
        CtrlShiftF1 = 0x30070,

        /// <summary>
        /// The shortcut keys CtrlShift+F10
        /// </summary>
        CtrlShiftF10 = 0x30079,

        /// <summary>
        /// The shortcut keys CtrlShift+F11
        /// </summary>
        CtrlShiftF11 = 0x3007a,

        /// <summary>
        /// The shortcut keys CtrlShift+F12
        /// </summary>
        CtrlShiftF12 = 0x3007b,

        /// <summary>
        /// The shortcut keys CtrlShift+F2
        /// </summary>
        CtrlShiftF2 = 0x30071,

        /// <summary>
        /// The shortcut keys CtrlShift+F3
        /// </summary>
        CtrlShiftF3 = 0x30072,

        /// <summary>
        /// The shortcut keys CtrlShift+F4
        /// </summary>
        CtrlShiftF4 = 0x30073,

        /// <summary>
        /// The shortcut keys CtrlShift+F5
        /// </summary>
        CtrlShiftF5 = 0x30074,

        /// <summary>
        /// The shortcut keys CtrlShift+F6
        /// </summary>
        CtrlShiftF6 = 0x30075,

        /// <summary>
        /// The shortcut keys CtrlShift+F7
        /// </summary>
        CtrlShiftF7 = 0x30076,

        /// <summary>
        /// The shortcut keys CtrlShift+F8
        /// </summary>
        CtrlShiftF8 = 0x30077,

        /// <summary>
        /// The shortcut keys CtrlShift+F9
        /// </summary>
        CtrlShiftF9 = 0x30078,

        /// <summary>
        /// The shortcut keys CtrlShift+G
        /// </summary>
        CtrlShiftG = 0x30047,

        /// <summary>
        /// The shortcut keys CtrlShift+H
        /// </summary>
        CtrlShiftH = 0x30048,

        /// <summary>
        /// The shortcut keys CtrlShift+I
        /// </summary>
        CtrlShiftI = 0x30049,

        /// <summary>
        /// The shortcut keys CtrlShift+J
        /// </summary>
        CtrlShiftJ = 0x3004a,

        /// <summary>
        /// The shortcut keys CtrlShift+K
        /// </summary>
        CtrlShiftK = 0x3004b,

        /// <summary>
        /// The shortcut keys CtrlShift+L
        /// </summary>
        CtrlShiftL = 0x3004c,

        /// <summary>
        /// The shortcut keys CtrlShift+M
        /// </summary>
        CtrlShiftM = 0x3004d,

        /// <summary>
        /// The shortcut keys CtrlShift+N
        /// </summary>
        CtrlShiftN = 0x3004e,

        /// <summary>
        /// The shortcut keys CtrlShift+O
        /// </summary>
        CtrlShiftO = 0x3004f,

        /// <summary>
        /// The shortcut keys CtrlShift+P
        /// </summary>
        CtrlShiftP = 0x30050,

        /// <summary>
        /// The shortcut keys CtrlShift+Q
        /// </summary>
        CtrlShiftQ = 0x30051,

        /// <summary>
        /// The shortcut keys CtrlShift+R
        /// </summary>
        CtrlShiftR = 0x30052,

        /// <summary>
        /// The shortcut keys CtrlShift+S
        /// </summary>
        CtrlShiftS = 0x30053,

        /// <summary>
        /// The shortcut keys CtrlShift+T
        /// </summary>
        CtrlShiftT = 0x30054,

        /// <summary>
        /// The shortcut keys CtrlShift+U
        /// </summary>
        CtrlShiftU = 0x30055,

        /// <summary>
        /// The shortcut keys CtrlShift+V
        /// </summary>
        CtrlShiftV = 0x30056,

        /// <summary>
        /// The shortcut keys CtrlShift+W
        /// </summary>
        CtrlShiftW = 0x30057,

        /// <summary>
        /// The shortcut keys CtrlShift+X
        /// </summary>
        CtrlShiftX = 0x30058,

        /// <summary>
        /// The shortcut keys CtrlShift+Y
        /// </summary>
        CtrlShiftY = 0x30059,

        /// <summary>
        /// The shortcut keys CtrlShift+Z
        /// </summary>
        CtrlShiftZ = 0x3005a,

        /// <summary>
        /// The shortcut keys Ctrl+T
        /// </summary>
        CtrlT = 0x20054,

        /// <summary>
        /// The shortcut keys Ctrl+U
        /// </summary>
        CtrlU = 0x20055,

        /// <summary>
        /// The shortcut keys Ctrl+V
        /// </summary>
        CtrlV = 0x20056,

        /// <summary>
        /// The shortcut keys Ctrl+W
        /// </summary>
        CtrlW = 0x20057,

        /// <summary>
        /// The shortcut keys Ctrl+X
        /// </summary>
        CtrlX = 0x20058,

        /// <summary>
        /// The shortcut keys Ctrl+Y
        /// </summary>
        CtrlY = 0x20059,

        /// <summary>
        /// The shortcut keys Ctrl+Z
        /// </summary>
        CtrlZ = 0x2005a,

        /// <summary>
        /// The shortcut keys Del
        /// </summary>
        Del = 0x2e,

        /// <summary>
        /// The shortcut keys F1
        /// </summary>
        F1 = 0x70,

        /// <summary>
        /// The shortcut keys 10
        /// </summary>
        F10 = 0x79,

        /// <summary>
        /// The shortcut keys F11
        /// </summary>
        F11 = 0x7a,

        /// <summary>
        /// The shortcut keys F1
        /// </summary>
        F12 = 0x7b,

        /// <summary>
        /// The shortcut keys F2
        /// </summary>
        F2 = 0x71,

        /// <summary>
        /// The shortcut keys F3
        /// </summary>
        F3 = 0x72,

        /// <summary>
        /// The shortcut keys F4
        /// </summary>
        F4 = 0x73,

        /// <summary>
        /// The shortcut keys F5
        /// </summary>
        F5 = 0x74,

        /// <summary>
        /// The shortcut keys F6
        /// </summary>
        F6 = 0x75,

        /// <summary>
        /// The shortcut keys F7
        /// </summary>
        F7 = 0x76,

        /// <summary>
        /// The shortcut keys F8
        /// </summary>
        F8 = 0x77,

        /// <summary>
        /// The shortcut keys F9
        /// </summary>
        F9 = 120,

        /// <summary>
        /// The shortcut keys Ins
        /// </summary>
        Ins = 0x2d,

        /// <summary>
        /// The shortcut keys None
        /// </summary>
        None = 0,

        /// <summary>
        /// The shortcut keys Shift+Del
        /// </summary>
        ShiftDel = 0x1002e,

        /// <summary>
        /// The shortcut keys Shift+F1
        /// </summary>
        ShiftF1 = 0x10070,

        /// <summary>
        /// The shortcut keys Shift+F10
        /// </summary>
        ShiftF10 = 0x10079,

        /// <summary>
        /// The shortcut keys Shift+F11
        /// </summary>
        ShiftF11 = 0x1007a,

        /// <summary>
        /// The shortcut keys Shift+F12
        /// </summary>
        ShiftF12 = 0x1007b,

        /// <summary>
        /// The shortcut keys Shift+F2
        /// </summary>
        ShiftF2 = 0x10071,

        /// <summary>
        /// The shortcut keys Shift+F3
        /// </summary>
        ShiftF3 = 0x10072,

        /// <summary>
        /// The shortcut keys Shift+F4
        /// </summary>
        ShiftF4 = 0x10073,

        /// <summary>
        /// The shortcut keys Shift+F5
        /// </summary>
        ShiftF5 = 0x10074,

        /// <summary>
        /// The shortcut keys Shift+F6
        /// </summary>
        ShiftF6 = 0x10075,

        /// <summary>
        /// The shortcut keys Shift+F7
        /// </summary>
        ShiftF7 = 0x10076,

        /// <summary>
        /// The shortcut keys Shift+F8
        /// </summary>
        ShiftF8 = 0x10077,

        /// <summary>
        /// The shortcut keys Shift+F9
        /// </summary>
        ShiftF9 = 0x10078,

        /// <summary>
        /// The shortcut keys Shift+Ins
        /// </summary>
        ShiftIns = 0x1002d
    }



    /// <summary>Defines constants that inform <see cref="M:System.Windows.Forms.ContainerControl.ValidateChildren(System.Windows.Forms.ValidationConstraints)"></see> about how it should validate a container's child controls. </summary>
    [Flags]
    public enum ValidationConstraints
    {
        /// <summary>Validates child controls whose <see cref="P:System.Windows.Forms.Control.Enabled"></see> property is set to true.</summary>
        Enabled = 2,
        /// <summary>Validates child controls that are directly hosted within the container. Does not validate any of the children of these children. For example, if you have a <see cref="T:System.Windows.Forms.Form"></see> that contains a custom <see cref="T:System.Windows.Forms.UserControl"></see>, and the <see cref="T:System.Windows.Forms.UserControl"></see> contains a <see cref="T:System.Windows.Forms.Button"></see>, using <see cref="F:System.Windows.Forms.ValidationConstraints.ImmediateChildren"></see> will cause the <see cref="E:System.Windows.Forms.Control.Validating"></see> event of the <see cref="T:System.Windows.Forms.UserControl"></see> to occur, but not the <see cref="E:System.Windows.Forms.Control.Validating"></see> event of the <see cref="T:System.Windows.Forms.Button"></see>. </summary>
        ImmediateChildren = 0x10,
        /// <summary>Validates all child controls, and all children of these child controls, regardless of their property settings. </summary>
        None = 0,
        /// <summary>Validates child controls that can be selected.</summary>
        Selectable = 1,
        /// <summary>Validates child controls that have a <see cref="P:System.Windows.Forms.Control.TabStop"></see> value set, which means that the user can navigate to the control using the TAB key. </summary>
        TabStop = 8,
        /// <summary>Validates child controls whose <see cref="P:System.Windows.Forms.Control.Visible"></see> property is set to true.</summary>
        Visible = 4
    }

    /// <summary>Determines how a control validates its data when it loses user input focus.</summary>
    /// <filterpriority>2</filterpriority>
    public enum AutoValidate
    {
        /// <summary>Implicit validation will not occur. Setting this value will not interfere with explicit calls to <see cref="M:System.Windows.Forms.ContainerControl.Validate"></see> or <see cref="M:System.Windows.Forms.ContainerControl.ValidateChildren"></see>.</summary>
        Disable = 0,
        /// <summary>Implicit validation occurs, but if validation fails, focus will still change to the new control. If validation fails, the <see cref="E:System.Windows.Forms.Control.Validated"></see> event will not fire.</summary>
        EnableAllowFocusChange = 2,
        /// <summary>Implicit validation occurs when the control loses focus.</summary>
        EnablePreventFocusChange = 1,
        /// <summary>The control inherits its <see cref="T:System.Windows.Forms.AutoValidate"></see> behavior from its container (such as a form or another control). If there is no container control, it defaults to <see cref="F:System.Windows.Forms.AutoValidate.EnablePreventFocusChange"></see>.</summary>
        /// <filterpriority>1</filterpriority>
        Inherit = -1
    }

    /// <summary>
    /// Appearance enumaration.
    /// </summary>
    public enum Appearance
    {
        /// <summary>
        /// 
        /// </summary>
        Normal,
        /// <summary>
        /// 
        /// </summary>
        Button,
        /// <summary>
        /// 
        /// </summary>
        [Obsolete("This appearance is deprecated, please use the CheckBoxSwitchVisualTemplate instead"), Browsable(false), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        Switch
    }


    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public enum Border3DStyle
    {
        Adjust = 0x2000,
        Bump = 9,
        Etched = 6,
        Flat = 0x400a,
        Raised = 5,
        RaisedInner = 4,
        RaisedOuter = 1,
        Sunken = 10,
        SunkenInner = 8,
        SunkenOuter = 2
    }


    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public enum ColorDepth
    {
        Depth16Bit = 0x10,
        Depth24Bit = 0x18,
        Depth32Bit = 0x20,
        Depth4Bit = 4,
        Depth8Bit = 8
    }

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public enum ImeMode
    {

        Alpha = 8,
        AlphaFull = 7,
        Close = 11,
        Disable = 3,
        Hangul = 10,
        HangulFull = 9,
        Hiragana = 4,
        Inherit = -1,
        Katakana = 5,
        KatakanaHalf = 6,
        NoControl = 0,
        Off = 2,
        On = 1,
        OnHalf = 12
    }

    /// <summary>Specifies the style of the sizing grip on a <see cref="T:System.Windows.Forms.Form"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public enum SizeGripStyle
    {
        Auto,
        Show,
        Hide
    }

    /// <summary>Specifies values representing possible roles for an accessible object.</summary>
    /// <filterpriority>2</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public enum AccessibleRole
    {
        /// <summary>An alert or condition that you can notify a user about. Use this role only for objects that embody an alert but are not associated with another user interface element, such as a message box, graphic, text, or sound.</summary>
        /// <filterpriority>1</filterpriority>
        Alert = 8,
        /// <summary>An animation control, which contains content that is changing over time, such as a control that displays a series of bitmap frames, like a filmstrip. Animation controls are usually displayed when files are being copied, or when some other time-consuming task is being performed.</summary>
        /// <filterpriority>1</filterpriority>
        Animation = 0x36,
        /// <summary>The main window for an application.</summary>
        /// <filterpriority>1</filterpriority>
        Application = 14,
        /// <summary>A window border. The entire border is represented by a single object, rather than by separate objects for each side.</summary>
        /// <filterpriority>1</filterpriority>
        Border = 0x13,
        /// <summary>A button that drops down a list of items.</summary>
        /// <filterpriority>1</filterpriority>
        ButtonDropDown = 0x38,
        /// <summary>A button that drops down a grid.</summary>
        /// <filterpriority>1</filterpriority>
        ButtonDropDownGrid = 0x3a,
        /// <summary>A button that drops down a menu.</summary>
        /// <filterpriority>1</filterpriority>
        ButtonMenu = 0x39,
        /// <summary>A caret, which is a flashing line, block, or bitmap that marks the location of the insertion point in a window's client area.</summary>
        /// <filterpriority>1</filterpriority>
        Caret = 7,
        /// <summary>A cell within a table.</summary>
        /// <filterpriority>1</filterpriority>
        Cell = 0x1d,
        /// <summary>A cartoon-like graphic object, such as Microsoft Office Assistant, which is typically displayed to provide help to users of an application.</summary>
        /// <filterpriority>1</filterpriority>
        Character = 0x20,
        /// <summary>A graphical image used to represent data.</summary>
        /// <filterpriority>1</filterpriority>
        Chart = 0x11,
        /// <summary>A check box control, which is an option that can be turned on or off independent of other options.</summary>
        /// <filterpriority>1</filterpriority>
        CheckButton = 0x2c,
        /// <summary>A window's user area.</summary>
        /// <filterpriority>1</filterpriority>
        Client = 10,
        /// <summary>A control that displays the time.</summary>
        /// <filterpriority>1</filterpriority>
        Clock = 0x3d,
        /// <summary>A column of cells within a table.</summary>
        /// <filterpriority>1</filterpriority>
        Column = 0x1b,
        /// <summary>A column header, which provides a visual label for a column in a table.</summary>
        /// <filterpriority>1</filterpriority>
        ColumnHeader = 0x19,
        /// <summary>A combo box, which is an edit control with an associated list box that provides a set of predefined choices.</summary>
        /// <filterpriority>1</filterpriority>
        ComboBox = 0x2e,
        /// <summary>A mouse pointer.</summary>
        /// <filterpriority>1</filterpriority>
        Cursor = 6,
        /// <summary>A system-provided role.</summary>
        /// <filterpriority>1</filterpriority>
        Default = -1,
        /// <summary>A graphical image used to diagram data.</summary>
        /// <filterpriority>1</filterpriority>
        Diagram = 0x35,
        /// <summary>A dial or knob. This can also be a read-only object, like a speedometer.</summary>
        /// <filterpriority>1</filterpriority>
        Dial = 0x31,
        /// <summary>A dialog box or message box.</summary>
        /// <filterpriority>1</filterpriority>
        Dialog = 0x12,
        /// <summary>A document window, which is always contained within an application window. This role applies only to multiple-document interface (MDI) windows and refers to an object that contains the MDI title bar.</summary>
        /// <filterpriority>1</filterpriority>
        Document = 15,
        /// <summary>A drop-down list box. This control shows one item and allows the user to display and select another from a list of alternative choices.</summary>
        /// <filterpriority>1</filterpriority>
        DropList = 0x2f,
        /// <summary>A mathematical equation.</summary>
        /// <filterpriority>1</filterpriority>
        Equation = 0x37,
        /// <summary>A picture.</summary>
        /// <filterpriority>1</filterpriority>
        Graphic = 40,
        /// <summary>A special mouse pointer, which allows a user to manipulate user interface elements such as a window. For example, a user can click and drag a sizing grip in the lower-right corner of a window to resize it.</summary>
        /// <filterpriority>1</filterpriority>
        Grip = 4,
        /// <summary>The objects grouped in a logical manner. There can be a parent-child relationship between the grouping object and the objects it contains.</summary>
        /// <filterpriority>1</filterpriority>
        Grouping = 20,
        /// <summary>A Help display in the form of a ToolTip or Help balloon, which contains buttons and labels that users can click to open custom Help topics.</summary>
        /// <filterpriority>1</filterpriority>
        HelpBalloon = 0x1f,
        /// <summary>A hot-key field that allows the user to enter a combination or sequence of keystrokes to be used as a hot key, which enables users to perform an action quickly. A hot-key control displays the keystrokes entered by the user and ensures that the user selects a valid key combination.</summary>
        /// <filterpriority>1</filterpriority>
        HotkeyField = 50,
        /// <summary>An indicator, such as a pointer graphic, that points to the current item.</summary>
        /// <filterpriority>1</filterpriority>
        Indicator = 0x27,
        IpAddress = 0x3f,
        /// <summary>A link, which is a connection between a source document and a destination document. This object might look like text or a graphic, but it acts like a button.</summary>
        /// <filterpriority>1</filterpriority>
        Link = 30,
        /// <summary>A list box, which allows the user to select one or more items.</summary>
        /// <filterpriority>1</filterpriority>
        List = 0x21,
        /// <summary>An item in a list box or the list portion of a combo box, drop-down list box, or drop-down combo box.</summary>
        /// <filterpriority>1</filterpriority>
        ListItem = 0x22,
        /// <summary>A menu bar, usually beneath the title bar of a window, from which users can select menus.</summary>
        /// <filterpriority>1</filterpriority>
        MenuBar = 2,
        /// <summary>A menu item, which is an entry in a menu that a user can choose to carry out a command, select an option, or display another menu. Functionally, a menu item can be equivalent to a push button, radio button, check box, or menu.</summary>
        /// <filterpriority>1</filterpriority>
        MenuItem = 12,
        /// <summary>A menu, which presents a list of options from which the user can make a selection to perform an action. All menu types must have this role, including drop-down menus that are displayed by selection from a menu bar, and shortcut menus that are displayed when the right mouse button is clicked.</summary>
        /// <filterpriority>1</filterpriority>
        MenuPopup = 11,
        /// <summary>No role.</summary>
        /// <filterpriority>1</filterpriority>
        None = 0,
        /// <summary>An outline or tree structure, such as a tree view control, which displays a hierarchical list and usually allows the user to expand and collapse branches.</summary>
        /// <filterpriority>1</filterpriority>
        Outline = 0x23,
        OutlineButton = 0x40,
        /// <summary>An item in an outline or tree structure.</summary>
        /// <filterpriority>1</filterpriority>
        OutlineItem = 0x24,
        /// <summary>A property page that allows a user to view the attributes for a page, such as the page's title, whether it is a home page, or whether the page has been modified. Normally, the only child of this control is a grouped object that contains the contents of the associated page.</summary>
        /// <filterpriority>1</filterpriority>
        PageTab = 0x25,
        /// <summary>A container of page tab controls.</summary>
        /// <filterpriority>1</filterpriority>
        PageTabList = 60,
        /// <summary>A separate area in a frame, a split document window, or a rectangular area of the status bar that can be used to display information. Users can navigate between panes and within the contents of the current pane, but cannot navigate between items in different panes. Thus, panes represent a level of grouping lower than frame windows or documents, but above individual controls. Typically, the user navigates between panes by pressing TAB, F6, or CTRL+TAB, depending on the context.</summary>
        /// <filterpriority>1</filterpriority>
        Pane = 0x10,
        /// <summary>A progress bar, which indicates the progress of a lengthy operation by displaying colored lines inside a horizontal rectangle. The length of the lines in relation to the length of the rectangle corresponds to the percentage of the operation that is complete. This control does not take user input.</summary>
        /// <filterpriority>1</filterpriority>
        ProgressBar = 0x30,
        /// <summary>A property page, which is a dialog box that controls the appearance and the behavior of an object, such as a file or resource. A property page's appearance differs according to its purpose.</summary>
        /// <filterpriority>1</filterpriority>
        PropertyPage = 0x26,
        /// <summary>A push button control, which is a small rectangular control that a user can turn on or off. A push button, also known as a command button, has a raised appearance in its default off state and a sunken appearance when it is turned on.</summary>
        /// <filterpriority>1</filterpriority>
        PushButton = 0x2b,
        /// <summary>An option button, also known as a radio button. All objects sharing a single parent that have this attribute are assumed to be part of a single mutually exclusive group. You can use grouped objects to divide option buttons into separate groups when necessary.</summary>
        /// <filterpriority>1</filterpriority>
        RadioButton = 0x2d,
        /// <summary>A row of cells within a table.</summary>
        /// <filterpriority>1</filterpriority>
        Row = 0x1c,
        /// <summary>A row header, which provides a visual label for a table row.</summary>
        /// <filterpriority>1</filterpriority>
        RowHeader = 0x1a,
        /// <summary>A vertical or horizontal scroll bar, which can be either part of the client area or used in a control.</summary>
        /// <filterpriority>1</filterpriority>
        ScrollBar = 3,
        /// <summary>A space divided visually into two regions, such as a separator menu item or a separator dividing split panes within a window.</summary>
        /// <filterpriority>1</filterpriority>
        Separator = 0x15,
        /// <summary>A control, sometimes called a trackbar, that enables a user to adjust a setting in given increments between minimum and maximum values by moving a slider. The volume controls in the Windows operating system are slider controls.</summary>
        /// <filterpriority>1</filterpriority>
        Slider = 0x33,
        /// <summary>A system sound, which is associated with various system events.</summary>
        /// <filterpriority>1</filterpriority>
        Sound = 5,
        /// <summary>A spin box, also known as an up-down control, which contains a pair of arrow buttons. A user clicks the arrow buttons with a mouse to increment or decrement a value. A spin button control is most often used with a companion control, called a buddy window, where the current value is displayed.</summary>
        /// <filterpriority>1</filterpriority>
        SpinButton = 0x34,
        SplitButton = 0x3e,
        /// <summary>The read-only text, such as in a label, for other controls or instructions in a dialog box. Static text cannot be modified or selected.</summary>
        /// <filterpriority>1</filterpriority>
        StaticText = 0x29,
        /// <summary>A status bar, which is an area typically at the bottom of an application window that displays information about the current operation, state of the application, or selected object. The status bar can have multiple fields that display different kinds of information, such as an explanation of the currently selected menu command in the status bar.</summary>
        /// <filterpriority>1</filterpriority>
        StatusBar = 0x17,
        /// <summary>A table containing rows and columns of cells and, optionally, row headers and column headers.</summary>
        /// <filterpriority>1</filterpriority>
        Table = 0x18,
        /// <summary>The selectable text that can be editable or read-only.</summary>
        /// <filterpriority>1</filterpriority>
        Text = 0x2a,
        /// <summary>A title or caption bar for a window.</summary>
        /// <filterpriority>1</filterpriority>
        TitleBar = 1,
        /// <summary>A toolbar, which is a grouping of controls that provide easy access to frequently used features.</summary>
        /// <filterpriority>1</filterpriority>
        ToolBar = 0x16,
        /// <summary>A tool tip, which is a small rectangular pop-up window that displays a brief description of the purpose of a button.</summary>
        /// <filterpriority>1</filterpriority>
        ToolTip = 13,
        /// <summary>A blank space between other objects.</summary>
        /// <filterpriority>1</filterpriority>
        WhiteSpace = 0x3b,
        /// <summary>A window frame, which usually contains child objects such as a title bar, client, and other objects typically contained in a window.</summary>
        /// <filterpriority>1</filterpriority>
        Window = 9
    }

    /// <summary>Specifies how tabs in a tab control are sized.</summary>
    /// <filterpriority>2</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public enum TabSizeMode
    {
        Normal,
        FillToRight,
        Fixed
    }

    /// <summary>Specifies how items align in the <see cref="T:Gizmox.WebGui.Forms.ListView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public enum ListViewAlignment
    {
        /// <summary>When the user moves an item, it remains where it is dropped.</summary>
        /// <filterpriority>1</filterpriority>
        Default = 0,
        /// <summary>Items are aligned to the left of the <see cref="T:System.Windows.Forms.ListView"></see> control.</summary>
        /// <filterpriority>1</filterpriority>
        Left = 1,
        /// <summary>Items are aligned to an invisible grid in the control. When the user moves an item, it moves to the closest juncture in the grid.</summary>
        /// <filterpriority>1</filterpriority>
        SnapToGrid = 5,
        /// <summary>Items are aligned to the top of the <see cref="T:System.Windows.Forms.ListView"></see> control.</summary>
        /// <filterpriority>1</filterpriority>
        Top = 2
    }
}
