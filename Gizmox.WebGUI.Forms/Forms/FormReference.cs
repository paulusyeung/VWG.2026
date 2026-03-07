// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FormReference
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>References a form</summary>
  [Serializable]
  public class FormReference : IFormLink, ILink
  {
    /// <summary>The webgui configuration object</summary>
    private static Config mobjConfig = Config.GetInstance();
    /// <summary>The form type</summary>
    private Type mobjType;
    /// <summary>The form reference instance id</summary>
    private Guid mobjInstance = Guid.Empty;
    /// <summary>The form link url</summary>
    private string mstrUrl;
    /// <summary>The form application name</summary>
    private string mstrApplication;

    /// <summary>Initialize form reference by application code</summary>
    /// <param name="strApplication">The application code as defined in the web config</param>
    public FormReference(string strApplication)
    {
      this.mstrApplication = strApplication != null ? strApplication : throw new ArgumentNullException("application");
      this.mobjType = Type.GetType(FormReference.mobjConfig.GetApplication(strApplication.ToLower(CultureInfo.InvariantCulture)) ?? throw new ArgumentException(string.Format("Cound not find application definition for '{0}'.", (object) strApplication), "application"), false);
      if (this.mobjType == (Type) null)
        throw new ArgumentException(string.Format("Cound not find application definition for '{0}'.", (object) strApplication), "application");
      this.mstrUrl = string.Format("{0}{1}", (object) strApplication, (object) FormReference.mobjConfig.DynamicExtension);
      this.mobjInstance = Guid.NewGuid();
    }

    /// <summary>Gets the form reference type</summary>
    Type IFormLink.FormType => this.mobjType;

    /// <summary>Gets the form instance id</summary>
    string IFormLink.FormInstance => this.mobjInstance.ToString();

    /// <summary>Gets the form application name</summary>
    string IFormLink.FormApplication => this.mstrApplication;

    /// <summary>Returns the url to open</summary>
    string ILink.Url => this.mstrUrl;
  }
}
