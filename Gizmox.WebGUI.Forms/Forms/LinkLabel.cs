// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LinkLabel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a Gizmox.WebGUI.Forms label control that can display hyperlinks.
  /// </summary>
  [ToolboxBitmap(typeof (LinkLabel), "LinkLabel_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.LinkLabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.LinkLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [SRDescription("DescriptionLinkLabel")]
  [DefaultEvent("LinkClicked")]
  [ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("LL")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (LinkLabelSkin))]
  [Serializable]
  public class LinkLabel : Label, IButtonControl
  {
    /// <summary>Provides a property reference to Link property.</summary>
    private static SerializableProperty LinkProperty = SerializableProperty.Register("Link", typeof (LinkLabel.Link), typeof (LinkLabel));
    /// <summary>Provides a property reference to ClientMode property.</summary>
    private static SerializableProperty ClientModeProperty = SerializableProperty.Register(nameof (ClientMode), typeof (bool), typeof (LinkLabel));
    /// <summary>
    /// Provides a property reference to DialogResult property.
    /// </summary>
    private static SerializableProperty DialogResultProperty = SerializableProperty.Register("DialogResult", typeof (DialogResult), typeof (LinkLabel));
    /// <summary>
    /// 
    /// </summary>
    private static SerializableProperty LinkColorProperty = SerializableProperty.Register(nameof (LinkColor), typeof (Color), typeof (LinkLabel));

    /// <summary>Occurs when a link is clicked within the control.</summary>
    public event LinkLabelLinkClickedEventHandler LinkClicked;

    /// <summary>Gets or sets the color of the link.</summary>
    /// <value>The color of the link.</value>
    [SRDescription("LinkLabelLinkColorDescr")]
    [SRCategory("CatAppearance")]
    public Color LinkColor
    {
      get
      {
        Color linkColor = this.GetValue<Color>(LinkLabel.LinkColorProperty, Color.Empty);
        if (linkColor != Color.Empty)
          return linkColor;
        return this.Skin is LinkLabelSkin skin ? skin.LinkColor : Color.Blue;
      }
      set
      {
        if (!(this.LinkColor != value))
          return;
        if (value == Color.Empty)
          this.RemoveValue<Color>(LinkLabel.LinkColorProperty);
        else
          this.SetValue<Color>(LinkLabel.LinkColorProperty, value);
        this.Update();
      }
    }

    /// <summary>Resets the color of the link.</summary>
    private void ResetLinkColor()
    {
      ControlSkin skin = this.Skin;
      this.LinkColor = Color.Empty;
    }

    /// <summary>
    /// Initializes a new default instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
    /// </summary>
    public LinkLabel()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.StandardClick | ControlStyles.UserPaint, true);
      this.TabStop = true;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
    /// </summary>
    /// <param name="strText">Label text.</param>
    public LinkLabel(string strText)
      : base(strText)
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.StandardClick | ControlStyles.UserPaint, true);
      this.TabStop = true;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> class.
    /// </summary>
    /// <param name="strText">Label text.</param>
    /// <param name="strUrl">Label url.</param>
    public LinkLabel(string strText, string strUrl)
      : base(strText)
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.StandardClick | ControlStyles.UserPaint, true);
      this.InternalLink = new LinkLabel.Link(strUrl);
      this.TabStop = true;
    }

    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderUrlAttribute(objWriter, false);
    }

    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      this.RenderUrlAttribute(objWriter, true);
    }

    /// <summary>Renders the URL attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderUrlAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!this.ClientMode || !(!string.IsNullOrEmpty(this.Url) | blnForceRender))
        return;
      objWriter.WriteAttributeString("VLB", this.Url);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.LinkClicked != null || !this.ClientMode && !string.IsNullOrEmpty(this.Url))
        criticalEventsData.Set("CL");
      return criticalEventsData;
    }

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fitted.
    /// </summary>
    /// <param name="objProposedSize">The custom-sized area for a control.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize)
    {
      Size preferredSize = base.GetPreferredSize(objProposedSize);
      if (this.AutoSize)
      {
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int intWidth = -1;
        if (this.Skin is LinkLabelSkin skin)
        {
          StyleValue contentStyle = skin.ContentStyle;
          if (contentStyle != null)
          {
            num1 = contentStyle.Padding.Horizontal;
            num2 = contentStyle.Margin.Horizontal;
            num3 = contentStyle.Padding.Vertical;
            num4 = contentStyle.Margin.Vertical;
          }
        }
        Size maximumSize = this.MaximumSize;
        if (!maximumSize.IsEmpty)
          intWidth = maximumSize.Width - num1 - num2;
        preferredSize = CommonUtils.GetStringMeasurements(this.Text, this.Font, intWidth);
        preferredSize.Width += num1 + num2;
        preferredSize.Height += num3 + num4;
      }
      return preferredSize;
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
    /// event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnClick(EventArgs objEventArgs)
    {
      base.OnClick(objEventArgs);
      LinkLabel.Link internalLink = this.InternalLink;
      if (!this.ClientMode && internalLink != null && !string.IsNullOrEmpty(internalLink.Url))
        LinkLabel.Link.Open(internalLink);
      this.OnLinkClicked(new LinkLabelLinkClickedEventArgs(internalLink));
    }

    /// <summary>Invokes LinkClicked event.</summary>
    /// <param name="e">Event arguments</param>
    protected virtual void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
    {
      LinkLabelLinkClickedEventHandler linkClicked = this.LinkClicked;
      if (linkClicked == null)
        return;
      linkClicked((object) this, e);
    }

    /// <summary>Renders the color of the fore.</summary>
    /// <returns></returns>
    protected override Color GetForeColor() => this.LinkColor;

    /// <summary>Shoulds the serialize URL.</summary>
    /// <returns></returns>
    private bool ShouldSerializeUrl()
    {
      LinkLabel.Link internalLink = this.InternalLink;
      return internalLink != null && !string.IsNullOrEmpty(internalLink.Url);
    }

    /// <summary>Gets or sets the URL.</summary>
    /// <value>The URL.</value>
    [DefaultValue("")]
    public string Url
    {
      get => this.InternalLink?.Url;
      set => this.InternalLink = new LinkLabel.Link(value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [client mode].
    /// </summary>
    /// <value><c>true</c> if [client mode]; otherwise, <c>false</c>.</value>
    [SRDescription("LinkLabelClientModeDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool ClientMode
    {
      get => this.GetValue<bool>(LinkLabel.ClientModeProperty, false);
      set
      {
        if (this.ClientMode == value)
          return;
        if (!value)
          this.RemoveValue<bool>(LinkLabel.ClientModeProperty);
        else
          this.SetValue<bool>(LinkLabel.ClientModeProperty, value);
        this.Update();
      }
    }

    /// <summary>Gets or sets the internal link.</summary>
    /// <value>The internal link.</value>
    private LinkLabel.Link InternalLink
    {
      get => this.GetValue<LinkLabel.Link>(LinkLabel.LinkProperty, new LinkLabel.Link(""));
      set
      {
        if (this.InternalLink == value)
          return;
        LinkLabel.Link internalLink = this.InternalLink;
        this.SetValue<LinkLabel.Link>(LinkLabel.LinkProperty, value);
        if (this.ClientMode)
        {
          if (!(internalLink.Url != this.InternalLink.Url))
            return;
          this.UpdateParams(AttributeType.Control, false);
        }
        else
        {
          if ((!(internalLink.Url == "") || !(this.InternalLink.Url != "")) && (!(internalLink.Url != "") || !(this.InternalLink.Url == "")))
            return;
          this.UpdateParams(AttributeType.Events, false);
        }
      }
    }

    /// <summary>
    /// Gets or sets the value returned to the parent form when the
    /// button is clicked.
    /// </summary>
    /// <value></value>
    DialogResult IButtonControl.DialogResult
    {
      get => this.GetValue<DialogResult>(LinkLabel.DialogResultProperty, DialogResult.None);
      set
      {
        if (value == DialogResult.None)
          this.RemoveValue<DialogResult>(LinkLabel.DialogResultProperty);
        else
          this.SetValue<DialogResult>(LinkLabel.DialogResultProperty, value);
      }
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [RefreshProperties(RefreshProperties.Repaint)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>
    /// Gets a value indicating whether [supports key navigation].
    /// </summary>
    /// <value>
    /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
    /// </value>
    protected override bool SupportsKeyNavigation => false;

    /// <summary>Performs the click.</summary>
    void IButtonControl.PerformClick() => this.OnClick(EventArgs.Empty);

    /// <summary>Notifies the default.</summary>
    /// <param name="value">Value.</param>
    void IButtonControl.NotifyDefault(bool blnValue)
    {
    }

    /// <summary>
    /// Represents a link within a <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> control.
    /// </summary>
    [Serializable]
    public class Link : ILink
    {
      private string mstrUrl = "";
      private object mobjLinkData;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> class.
      /// </summary>
      internal Link(string strUrl) => this.mstrUrl = strUrl;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel.Link"></see> class.
      /// </summary>
      internal Link(LinkLabel objLinkLabel, string strUrl)
        : this(strUrl)
      {
      }

      /// <summary>Opens the specified link.</summary>
      /// <param name="objLink">The link.</param>
      public static void Open(LinkLabel.Link objLink) => Global.Context.OpenLink((ILink) objLink);

      /// <summary>Gets or sets the URL.</summary>
      /// <value>The URL.</value>
      internal string Url
      {
        get => this.mstrUrl;
        set => this.mstrUrl = value;
      }

      /// <summary>Gets the URL.</summary>
      /// <value>The URL.</value>
      string ILink.Url => this.mstrUrl;

      /// <summary>
      /// Gets or sets a value indicating whether the link is enabled.
      /// </summary>
      /// <returns>true if the link is enabled; otherwise, false.</returns>
      [DefaultValue(true)]
      public bool Enabled
      {
        get => true;
        set
        {
        }
      }

      /// <summary>
      /// Gets or sets the number of characters in the link text.
      /// </summary>
      /// <returns>The number of characters, including spaces, in the link text.</returns>
      public int Length
      {
        get => 0;
        set
        {
        }
      }

      /// <summary>Gets or sets the data associated with the link.</summary>
      /// <returns>An <see cref="T:System.Object"></see> representing the data associated with the link.</returns>
      [DefaultValue(null)]
      public object LinkData
      {
        get => this.mobjLinkData;
        set => this.mobjLinkData = value;
      }

      /// <summary>
      /// Gets or sets the starting location of the link within the text of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see>.
      /// </summary>
      /// <returns>The location within the text of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> control where the link starts.</returns>
      public int Start
      {
        get => 0;
        set
        {
        }
      }

      /// <summary>
      /// Gets or sets a value indicating whether the user has visited the link.
      /// </summary>
      /// <returns>true if the link has been visited; otherwise, false.</returns>
      [DefaultValue(true)]
      public bool Visited
      {
        get => true;
        set
        {
        }
      }
    }
  }
}
