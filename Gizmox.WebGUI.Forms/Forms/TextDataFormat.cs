// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TextDataFormat
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the formats used with text-related methods of the <see cref="T:System.Windows.Forms.Clipboard"></see> and <see cref="T:System.Windows.Forms.DataObject"></see> classes.</summary>
  /// <filterpriority>2</filterpriority>
  public enum TextDataFormat : byte
  {
    /// <summary>Specifies the standard ANSI text format.</summary>
    Text,
    /// <summary>Specifies the standard Windows Unicode text format.</summary>
    UnicodeText,
    /// <summary>
    /// Specifies text consisting of rich text format (RTF) data
    /// </summary>
    Rtf,
    /// <summary>pecifies text consisting of HTML data.</summary>
    Html,
    /// <summary>
    /// Specifies a comma-separated value (CSV) format, which is a common interchange format used by spreadsheets.
    /// </summary>
    CommaSeparatedValue,
  }
}
