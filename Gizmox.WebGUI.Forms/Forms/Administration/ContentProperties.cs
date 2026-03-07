// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Administration.ContentProperties
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.Administration
{
  /// <summary>
  /// 
  /// </summary>
  public class ContentProperties
  {
    /// <summary>The MSTR content name</summary>
    private string mstrContentName;
    /// <summary>The MBLN full screen</summary>
    private bool mblnFullScreen;
    /// <summary>The MSTR content description</summary>
    private string mstrContentDescription;
    /// <summary>The mobj status data</summary>
    private List<Gizmox.WebGUI.Forms.Administration.Abstract.StatusData> mobjStatusData;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.ContentProperties" /> class.
    /// </summary>
    /// <param name="strContentName">Name of the string content.</param>
    public ContentProperties(string strContentName) => this.mstrContentName = strContentName;

    /// <summary>
    /// Gets or sets a value indicating whether [full screen].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [full screen]; otherwise, <c>false</c>.
    /// </value>
    public bool FullScreen
    {
      get => this.mblnFullScreen;
      set => this.mblnFullScreen = value;
    }

    /// <summary>Gets or sets the content description.</summary>
    /// <value>The content description.</value>
    public string ContentDescription
    {
      get => this.mstrContentDescription;
      set => this.mstrContentDescription = value;
    }

    /// <summary>Gets or sets the status data.</summary>
    /// <value>The status data.</value>
    public List<Gizmox.WebGUI.Forms.Administration.Abstract.StatusData> StatusData
    {
      get => this.mobjStatusData;
      set => this.mobjStatusData = value;
    }

    /// <summary>Gets the name of the content.</summary>
    /// <value>The name of the content.</value>
    public string ContentName => this.mstrContentName;
  }
}
