// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HelpNavigator
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies constants indicating which elements of the Help file to display.
  /// </summary>
  public enum HelpNavigator
  {
    /// <summary>
    /// The Help file opens to a specified topic, if the topic exists.
    /// </summary>
    Topic = -2147483647, // 0x80000001
    /// <summary>The Help file opens to the table of contents.</summary>
    TableOfContents = -2147483646, // 0x80000002
    /// <summary>The Help file opens to the index.</summary>
    Index = -2147483645, // 0x80000003
    /// <summary>The Help file opens to the search page.</summary>
    Find = -2147483644, // 0x80000004
    /// <summary>
    /// The Help file opens to the index entry for the first letter of a specified topic.
    /// </summary>
    AssociateIndex = -2147483643, // 0x80000005
    /// <summary>
    /// The Help file opens to the topic with the specified index entry, if one exists; otherwise, the index entry closest to the specified keyword is displayed.
    /// </summary>
    KeywordIndex = -2147483642, // 0x80000006
  }
}
