// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Help
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Encapsulates the HTML Help 1.0 engine.</summary>
  /// <filterpriority>1</filterpriority>
  [Serializable]
  public class Help
  {
    private Help()
    {
    }

    private static int GetHelpFileType(string strUrl)
    {
      if (strUrl != null)
      {
        Uri uri = Help.Resolve(strUrl);
        if (uri == (Uri) null || uri.Scheme == "file")
        {
          string lower = Path.GetExtension(uri == (Uri) null ? strUrl : uri.LocalPath + uri.Fragment).ToLower(CultureInfo.InvariantCulture);
          if (lower == ".chm" || lower == ".col")
            return 2;
        }
      }
      return 3;
    }

    private static string GetLocalPath(string strFileName)
    {
      Uri uri = new Uri(strFileName);
      return uri.LocalPath + uri.Fragment;
    }

    private static Uri Resolve(string strPartialUri)
    {
      Uri uri = (Uri) null;
      if (!CommonUtils.IsNullOrEmpty(strPartialUri))
      {
        try
        {
          uri = new Uri(strPartialUri);
        }
        catch (UriFormatException ex)
        {
        }
        catch (ArgumentNullException ex)
        {
        }
      }
      if (uri != (Uri) null && uri.Scheme == "file")
      {
        string localPath = Help.GetLocalPath(strPartialUri);
        new FileIOPermission(FileIOPermissionAccess.Read, localPath).Assert();
        try
        {
          if (!File.Exists(localPath))
            uri = (Uri) null;
        }
        finally
        {
          CodeAccessPermission.RevertAssert();
        }
      }
      if (uri == (Uri) null)
      {
        try
        {
          uri = new Uri(new Uri(AppDomain.CurrentDomain.SetupInformation.ApplicationBase), strPartialUri);
        }
        catch (UriFormatException ex)
        {
        }
        catch (ArgumentNullException ex)
        {
        }
        if (uri == (Uri) null || uri.Scheme != "file")
          return uri;
        string path = uri.LocalPath + uri.Fragment;
        new FileIOPermission(FileIOPermissionAccess.Read, path).Assert();
        try
        {
          if (!File.Exists(path))
            uri = (Uri) null;
        }
        finally
        {
          CodeAccessPermission.RevertAssert();
        }
      }
      return uri;
    }

    /// <summary>Displays the contents of the Help file at the specified URL.</summary>
    /// <param name="strUrl">The path and name of the Help file. </param>
    /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public static void ShowHelp(Control objParent, string strUrl) => Help.ShowHelp(objParent, strUrl, HelpNavigator.TableOfContents, (object) null);

    /// <summary>Displays the contents of the Help file found at the specified URL for a specific keyword.</summary>
    /// <param name="strKeyword">The keyword to display Help for. </param>
    /// <param name="strUrl">The path and name of the Help file. </param>
    /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public static void ShowHelp(Control objParent, string strUrl, string strKeyword)
    {
      if (strKeyword != null && strKeyword.Length != 0)
        Help.ShowHelp(objParent, strUrl, HelpNavigator.Topic, (object) strKeyword);
      else
        Help.ShowHelp(objParent, strUrl, HelpNavigator.TableOfContents, (object) null);
    }

    /// <summary>Displays the contents of the Help file found at the specified URL for a specific topic.</summary>
    /// <param name="strUrl">The path and name of the Help file. </param>
    /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
    /// <param name="enmNavigator">One of the <see cref="T:Gizmox.WebGUI.Forms.HelpNavigator"></see> values. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public static void ShowHelp(Control objParent, string strUrl, HelpNavigator enmNavigator) => Help.ShowHelp(objParent, strUrl, enmNavigator, (object) null);

    /// <summary>
    /// Displays the contents of the Help file located at the URL supplied by the user.
    /// </summary>
    /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box.</param>
    /// <param name="strUrl">The path and name of the Help file.</param>
    /// <param name="enmCommand">One of the <see cref="T:Gizmox.WebGUI.Forms.HelpNavigator"></see> values.</param>
    /// <param name="objParameter">The parameter.</param>
    /// <exception cref="T:System.ArgumentException">param is an integer.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public static void ShowHelp(
      Control objParent,
      string strUrl,
      HelpNavigator enmCommand,
      object objParameter)
    {
      switch (Help.GetHelpFileType(strUrl))
      {
        case 2:
          Help.ShowHTMLFile(objParent, strUrl, enmCommand, objParameter);
          break;
        case 3:
          Help.ShowHTML10Help(objParent, strUrl, enmCommand, objParameter);
          break;
      }
    }

    /// <summary>Displays the index of the specified Help file.</summary>
    /// <param name="strUrl">The path and name of the Help file. </param>
    /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public static void ShowHelpIndex(Control objParent, string strUrl) => Help.ShowHelp(objParent, strUrl, HelpNavigator.Index, (object) null);

    private static void ShowHTML10Help(
      Control objParent,
      string strUrl,
      HelpNavigator enmCommand,
      object objParameter)
    {
    }

    private static void ShowHTMLFile(
      Control objParent,
      string strUrl,
      HelpNavigator enmCommand,
      object objParameter)
    {
      Type type = Type.GetType("Gizmox.WebGUI.Forms.HelpDialog, Gizmox.WebGUI.Forms.Help");
      if (type != (Type) null)
      {
        type.InvokeMember("ShowHelp", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, (Binder) null, (object) null, new object[4]
        {
          (object) objParent,
          (object) strUrl,
          (object) enmCommand,
          objParameter
        });
      }
      else
      {
        int num = (int) MessageBox.Show("Could not find Gizmox.WebGUI.Forms.Help assembly.", "Help Projection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>Displays a Help pop-up window.</summary>
    /// <param name="strCaption">The message to display in the pop-up window. </param>
    /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
    /// <param name="objLocation">A value specifying the horizontal and vertical coordinates at which to display the pop-up window. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public static void ShowPopup(Control objParent, string strCaption, Point objLocation) => throw new NotImplementedException();
  }
}
