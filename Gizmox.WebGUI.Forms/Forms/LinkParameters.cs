// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LinkParameters
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Holds window parameters for opening links</summary>
  [Serializable]
  public class LinkParameters : ILinkParameters
  {
    /// <summary>The link window stule</summary>
    private LinkWindowStyle menmWindowStyle;
    /// <summary>The link window size</summary>
    private Size mobjWindowSize = Size.Empty;
    /// <summary>
    /// A flag indicating if window should be opened in full screen
    /// </summary>
    private bool mblnFullScreen;
    /// <summary>The link window location</summary>
    private Point mobjLocation = Point.Empty;
    /// <summary>
    /// A flag indicating of location bar should be displayed in the link window
    /// </summary>
    private bool mblnShowLocationBar;
    /// <summary>
    /// A flag indicating of menu bar should be displayed in the link window
    /// </summary>
    private bool mblnShowMenuBar;
    /// <summary>
    /// A flag indicating of title bar should be displayed in the link window
    /// </summary>
    private bool mblnShowTitleBar = true;
    /// <summary>
    /// A flag indicating of toolbar should be displayed in the link window
    /// </summary>
    private bool mblnShowToolBar;
    /// <summary>
    /// A flag indicating of status bar should be displayed in the link window
    /// </summary>
    private bool mblnShowStatusBar;
    /// <summary>
    /// A flag indicating if the link window should be resizable
    /// </summary>
    private bool mblnResizable = true;
    /// <summary>
    /// A flag indicating if the link window should have scrollbars
    /// </summary>
    private bool mblnScrollBars = true;
    /// <summary>The target window name</summary>
    private string mstrTarget = "_blank";
    /// <summary>Holds form related arguments</summary>
    private ILinkArguments mobjFormArguments;
    /// <summary>Holds form related arguments</summary>
    private ILinkArguments mobjQueryArguments;

    /// <summary>Create a new link parameters instance</summary>
    public LinkParameters()
    {
    }

    /// <summary>Create a new link parameters instance</summary>
    /// <param name="enmWindowStyle">The link window style</param>
    public LinkParameters(LinkWindowStyle enmWindowStyle)
    {
    }

    /// <summary>Create a new link parameters instance</summary>
    /// <param name="enmWindowStyle">The link window style</param>
    /// <param name="objWindowSize">The link window size</param>
    public LinkParameters(LinkWindowStyle enmWindowStyle, Size objWindowSize)
    {
      this.menmWindowStyle = enmWindowStyle;
      this.mobjWindowSize = objWindowSize;
    }

    /// <summary>Gets or sets query string arguments</summary>
    public ILinkArguments QueryString
    {
      get
      {
        if (this.mobjQueryArguments == null)
          this.mobjQueryArguments = (ILinkArguments) new LinkParameters.LinkArguments();
        return this.mobjQueryArguments;
      }
    }

    /// <summary>Gets or sets form arguments</summary>
    public ILinkArguments Form
    {
      get
      {
        if (this.mobjFormArguments == null)
          this.mobjFormArguments = (ILinkArguments) new LinkParameters.LinkArguments();
        return this.mobjFormArguments;
      }
    }

    /// <summary>Get or sets the window style</summary>
    public LinkWindowStyle WindowStyle
    {
      get => this.menmWindowStyle;
      set => this.menmWindowStyle = value;
    }

    /// <summary>Gets or sets the window size</summary>
    public Size Size
    {
      get => this.mobjWindowSize;
      set => this.mobjWindowSize = value;
    }

    /// <summary>Gets or sets the link window full screen mode</summary>
    public bool FullScreen
    {
      get => this.mblnFullScreen;
      set => this.mblnFullScreen = value;
    }

    /// <summary>Gets or sets the link window location</summary>
    public Point Location
    {
      get => this.mobjLocation;
      set => this.mobjLocation = value;
    }

    /// <summary>Gets or sets the link windows location bar visibility</summary>
    public bool ShowLocationBar
    {
      get => this.mblnShowLocationBar;
      set => this.mblnShowLocationBar = value;
    }

    /// <summary>Gets or sets the link windows menu bar visibility</summary>
    public bool ShowMenuBar
    {
      get => this.mblnShowMenuBar;
      set => this.mblnShowMenuBar = value;
    }

    /// <summary>Gets or sets the link windows title bar visibility</summary>
    public bool ShowTitleBar
    {
      get => this.mblnShowTitleBar;
      set => this.mblnShowTitleBar = value;
    }

    /// <summary>Gets or sets the link windows toolbar visibility</summary>
    public bool ShowToolBar
    {
      get => this.mblnShowToolBar;
      set => this.mblnShowToolBar = value;
    }

    /// <summary>Gets or sets the link windows status bar visibility</summary>
    public bool ShowStatusBar
    {
      get => this.mblnShowStatusBar;
      set => this.mblnShowStatusBar = value;
    }

    /// <summary>Gets or sets the resizable mode of the link window</summary>
    public bool Resizable
    {
      get => this.mblnResizable;
      set => this.mblnResizable = value;
    }

    /// <summary>
    /// Gets or sets the scrollbars visibility in the link window
    /// </summary>
    public bool ScrollBars
    {
      get => this.mblnScrollBars;
      set => this.mblnScrollBars = value;
    }

    /// <summary>Gets or sets the link targer</summary>
    public string Target
    {
      get => this.mstrTarget;
      set => this.mstrTarget = value;
    }

    /// <summary>Holds arguments to open links with</summary>
    [Serializable]
    public class LinkArguments : ILinkArguments
    {
      /// <summary>Arguments storage</summary>
      private Hashtable mobjArguments;

      /// <summary>Set or get arguments</summary>
      /// <param name="strName"></param>
      /// <returns></returns>
      public string this[string strName]
      {
        get => this.mobjArguments != null ? this.mobjArguments[(object) strName] as string : (string) null;
        set
        {
          if (this.mobjArguments == null)
            this.mobjArguments = new Hashtable();
          this.mobjArguments[(object) strName] = (object) value;
        }
      }

      /// <summary>Gets an array of argument names</summary>
      public string[] Names => this.mobjArguments == null ? new string[0] : (string[]) new ArrayList(this.mobjArguments.Keys).ToArray(typeof (string));

      /// <summary>Gets the arguments count</summary>
      public int Count => this.Names.Length;

      /// <summary>Clears the argument collection</summary>
      public void Clear()
      {
        if (this.mobjArguments == null)
          return;
        this.mobjArguments.Clear();
      }
    }
  }
}
