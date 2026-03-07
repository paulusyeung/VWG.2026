// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AppletBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>
  /// Applet box control can host java applets and embed the in a Visual WebGui
  /// application
  /// </summary>
  /// <example>
  /// 	<code lang="CS">
  /// 		<![CDATA[
  /// AppletBox objAppletBox = new AppletBox();
  /// 
  /// objAppletBox.CodeBase = [URL Relative location]
  /// objAppletBox.Code = [Class filename]
  /// 
  /// //If your class file is located in Resources folder inside project and it's a dedicated server:
  /// 
  /// objAppletBox.CodeBase = "/Resources/";
  /// objAppletBox.Code = "MyClass.class";
  /// 
  /// //If your class files located in virtual directory inside server:
  /// 
  /// objAppletBox.CodeBase = "Resources/";
  /// objAppletBox.Code = "MyClass.class";]]>
  /// 	</code>
  /// 	<code lang="VB">
  /// 		<![CDATA[
  /// Dim objAppletBox As New AppletBox()
  /// 
  /// objAppletBox.CodeBase = [URL Relative location]
  /// objAppletBox.Code = [Class filename]
  /// 
  /// //If your Class file Is located In Resources folder inside project And it's a dedicated server:
  /// 
  /// objAppletBox.CodeBase = "/Resources/"
  /// objAppletBox.Code = "MyClass.class"
  /// 
  /// //If your Class files located In virtual directory inside server:
  /// 
  /// objAppletBox.CodeBase = "Resources/"
  /// objAppletBox.Code = "MyClass.class"]]>
  /// 	</code>
  /// </example>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (AppletBox), "AppletBox_45.png")]
  [Serializable]
  public class AppletBox : AppletBoxBase, IGatewayComponent
  {
    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Hosts.AppletBox" /> instance.
    /// </summary>
    public AppletBox()
      : this((string) null, (string) null)
    {
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Hosts.AppletBox" /> instance.
    /// </summary>
    /// <param name="strCodeBase">Applet code base.</param>
    /// <param name="strArchive">Applet archive.</param>
    /// <param name="strCode">Applet code.</param>
    public AppletBox(string strArchive, string strCode)
      : base(strArchive, strCode)
    {
      this.ObjectType = "application/x-java-applet";
    }

    /// <summary>Gets or sets the archive.</summary>
    /// <value></value>
    [DefaultValue("")]
    public string Archive
    {
      get => this.InternalArchive;
      set => this.InternalArchive = value;
    }

    /// <summary>Gets or sets the code base.</summary>
    /// <value>The code base.</value>
    [DefaultValue("")]
    public string CodeBase
    {
      get => this.ObjectCodeBase;
      set => this.ObjectCodeBase = value;
    }

    /// <summary>Gets or sets the code base.</summary>
    /// <value>The code base.</value>
    [DefaultValue("")]
    public string Code
    {
      get => this.ObjectCode;
      set => this.ObjectCode = value;
    }
  }
}
