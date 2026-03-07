// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.VisualTemplate
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [WebEditor(typeof (VisualTemplateEditor), typeof (WebUITypeEditor))]
  [TypeConverter(typeof (VisualTemplatesTypeConverter))]
  [Serializable]
  public abstract class VisualTemplate : ISkinable
  {
    /// <summary>Renders the specified object context.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    public virtual void Render(IContext objContext, IAttributeWriter objWriter) => objWriter.WriteAttributeString("VS", this.VisualTemplateName);

    /// <summary>Gets the constroctor arguments. (For TypeConverter)</summary>
    /// <returns></returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual object[] GetConsturctorArguments() => new object[0];

    /// <summary>Gets the constroctor types. (For TypeConverter)</summary>
    public virtual Type[] GetConstructorTypes() => new Type[0];

    public virtual VisualTemplate GetDefault(Control objControl) => (VisualTemplate) null;

    /// <summary>Gets the name of the visual template.</summary>
    /// <value>The name of the visual template.</value>
    [Browsable(false)]
    public abstract string VisualTemplateName { get; }

    /// <summary>Gets the visualizer image.</summary>
    /// <value>The visualizer image.</value>
    [Browsable(false)]
    public virtual ResourceHandle VisualizerImage => (ResourceHandle) null;

    /// <summary>Gets the visualizer default image.</summary>
    /// <value>The visualizer default image.</value>
    internal static ResourceHandle VisualizerDefaultImage => (ResourceHandle) new SkinResourceHandle(typeof (ControlSkin), "VisualTemplate_None.png");

    /// <summary>Gets the theme related to the skinable component.</summary>
    /// <value>The theme related to the skinable component.</value>
    [Browsable(false)]
    public string Theme
    {
      get
      {
        if (CommonUtils.IsDesignMode && !ConfigHelper.ApplySelectedThemeInDesignTime)
          return "Default";
        return VWGContext.Current != null ? VWGContext.Current.CurrentTheme : ConfigHelper.SelectedTheme;
      }
    }

    /// <summary>Converts to string.</summary>
    /// <returns></returns>
    internal virtual string ConvertToString() => string.Format("{0}, {1}", (object) this.GetType().FullName, (object) this.GetType().Assembly.GetName().Name);

    /// <summary>Converts from string.</summary>
    /// <param name="objVisualTemplateValues">The object visual template values.</param>
    internal virtual void ConvertFromString(List<string> objVisualTemplateValues)
    {
    }

    /// <summary>Fires the event.</summary>
    /// <param name="objEvent">The object event.</param>
    protected internal virtual void FireEvent(Control objControl, IEvent objEvent)
    {
    }
  }
}
