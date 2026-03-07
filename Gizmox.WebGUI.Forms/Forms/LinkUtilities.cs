// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LinkUtilities
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class LinkUtilities
  {
    private static Color ieactiveLinkColor = Color.Empty;
    private const string IEAnchorColor = "Anchor Color";
    private const string IEAnchorColorHover = "Anchor Color Hover";
    private const string IEAnchorColorVisited = "Anchor Color Visited";
    private static Color ielinkColor = Color.Empty;
    public const string IEMainRegPath = "Software\\Microsoft\\Internet Explorer\\Main";
    private const string IESettingsRegPath = "Software\\Microsoft\\Internet Explorer\\Settings";
    private static Color ievisitedLinkColor = Color.Empty;

    public static void EnsureLinkFonts(
      Font baseFont,
      LinkBehavior link,
      ref Font linkFont,
      ref Font hoverLinkFont)
    {
      if (linkFont != null && hoverLinkFont != null)
        return;
      bool flag1 = true;
      bool flag2 = true;
      if (link == LinkBehavior.SystemDefault)
        link = LinkUtilities.GetIELinkBehavior();
      switch (link - 1)
      {
        case LinkBehavior.SystemDefault:
          flag1 = true;
          flag2 = true;
          break;
        case LinkBehavior.AlwaysUnderline:
          flag1 = false;
          flag2 = true;
          break;
        case LinkBehavior.HoverUnderline:
          flag1 = false;
          flag2 = false;
          break;
      }
      Font prototype = baseFont;
      if (flag2 == flag1)
      {
        FontStyle style = prototype.Style;
        FontStyle newStyle = !flag2 ? style & ~FontStyle.Underline : style | FontStyle.Underline;
        hoverLinkFont = new Font(prototype, newStyle);
        linkFont = hoverLinkFont;
      }
      else
      {
        FontStyle style1 = prototype.Style;
        FontStyle newStyle1 = !flag2 ? style1 & ~FontStyle.Underline : style1 | FontStyle.Underline;
        hoverLinkFont = new Font(prototype, newStyle1);
        FontStyle style2 = prototype.Style;
        FontStyle newStyle2 = !flag1 ? style2 & ~FontStyle.Underline : style2 | FontStyle.Underline;
        linkFont = new Font(prototype, newStyle2);
      }
    }

    private static Color GetIEColor(string strName) => Color.Red;

    public static LinkBehavior GetIELinkBehavior() => LinkBehavior.AlwaysUnderline;

    public static Color IEActiveLinkColor
    {
      get
      {
        if (LinkUtilities.ieactiveLinkColor.IsEmpty)
          LinkUtilities.ieactiveLinkColor = LinkUtilities.GetIEColor("Anchor Color Hover");
        return LinkUtilities.ieactiveLinkColor;
      }
    }

    public static Color IELinkColor
    {
      get
      {
        if (LinkUtilities.ielinkColor.IsEmpty)
          LinkUtilities.ielinkColor = LinkUtilities.GetIEColor("Anchor Color");
        return LinkUtilities.ielinkColor;
      }
    }

    public static Color IEVisitedLinkColor
    {
      get
      {
        if (LinkUtilities.ievisitedLinkColor.IsEmpty)
          LinkUtilities.ievisitedLinkColor = LinkUtilities.GetIEColor("Anchor Color Visited");
        return LinkUtilities.ievisitedLinkColor;
      }
    }
  }
}
