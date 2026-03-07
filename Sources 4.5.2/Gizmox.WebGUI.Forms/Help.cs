#region Using

using System;
using System.Drawing;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Globalization;
using System.Reflection;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
	#region Enums
	
	/// <summary>
	/// Specifies constants indicating which elements of the Help file to display.
	/// </summary>
	
	public enum HelpNavigator
	{
        /// <summary>
        /// The Help file opens to the index entry for the first letter of a specified topic.
        /// </summary>
		AssociateIndex = -2147483643,
        /// <summary>
        /// The Help file opens to the search page.
        /// </summary>
		Find = -2147483644,
        /// <summary>
        /// The Help file opens to the index.
        /// </summary>
		Index = -2147483645,
        /// <summary>
        /// The Help file opens to the topic with the specified index entry, if one exists; otherwise, the index entry closest to the specified keyword is displayed.
        /// </summary>
		KeywordIndex = -2147483642,
        /// <summary>
        /// The Help file opens to the table of contents.
        /// </summary>
		TableOfContents = -2147483646,
        /// <summary>
        /// The Help file opens to a specified topic, if the topic exists.
        /// </summary>
		Topic = -2147483647
	}
	
	
	#endregion Enums
	
	#region Help Class

    /// <summary>Encapsulates the HTML Help 1.0 engine.</summary>
    /// <filterpriority>1</filterpriority>

    [Serializable()]
    public class Help
    {

        private Help()
        {
        }

        private static int GetHelpFileType(string strUrl)
        {
            if (strUrl != null)
            {
                Uri uri = Resolve(strUrl);
                if ((uri == null) || (uri.Scheme == "file"))
                {
                    switch (Path.GetExtension((uri == null) ? strUrl : (uri.LocalPath + uri.Fragment)).ToLower(CultureInfo.InvariantCulture))
                    {
                        case ".chm":
                        case ".col":
                            return 2;
                    }
                }
            }
            return 3;
        }

        private static string GetLocalPath(string strFileName)
        {
            Uri uri = new Uri(strFileName);
            return (uri.LocalPath + uri.Fragment);
        }

 

 


        private static Uri Resolve(string strPartialUri)
        {
            Uri uri = null;
            if (!CommonUtils.IsNullOrEmpty(strPartialUri))
            {
                try
                {
                    uri = new Uri(strPartialUri);
                }
                catch (UriFormatException)
                {
                }
                catch (ArgumentNullException)
                {
                }
            }
            if ((uri != null) && (uri.Scheme == "file"))
            {
                string strPath = Help.GetLocalPath(strPartialUri);
                new FileIOPermission(FileIOPermissionAccess.Read, strPath).Assert();
                try
                {
                    if (!File.Exists(strPath))
                    {
                        uri = null;
                    }
                }
                finally
                {
                    CodeAccessPermission.RevertAssert();
                }
            }
            if (uri == null)
            {
                try
                {
                    uri = new Uri(new Uri(AppDomain.CurrentDomain.SetupInformation.ApplicationBase), strPartialUri);
                }
                catch (UriFormatException)
                {
                }
                catch (ArgumentNullException)
                {
                }
                if ((uri == null) || (uri.Scheme != "file"))
                {
                    return uri;
                }
                string strText2 = uri.LocalPath + uri.Fragment;
                new FileIOPermission(FileIOPermissionAccess.Read, strText2).Assert();
                try
                {
                    if (!File.Exists(strText2))
                    {
                        uri = null;
                    }
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
        public static void ShowHelp(Control objParent, string strUrl)
        {
            ShowHelp(objParent, strUrl, HelpNavigator.TableOfContents, null);
        }

        /// <summary>Displays the contents of the Help file found at the specified URL for a specific keyword.</summary>
        /// <param name="strKeyword">The keyword to display Help for. </param>
        /// <param name="strUrl">The path and name of the Help file. </param>
        /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public static void ShowHelp(Control objParent, string strUrl, string strKeyword)
        {
            if ((strKeyword != null) && (strKeyword.Length != 0))
            {
                ShowHelp(objParent, strUrl, HelpNavigator.Topic, strKeyword);
            }
            else
            {
                ShowHelp(objParent, strUrl, HelpNavigator.TableOfContents, null);
            }
        }

        /// <summary>Displays the contents of the Help file found at the specified URL for a specific topic.</summary>
        /// <param name="strUrl">The path and name of the Help file. </param>
        /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
        /// <param name="enmNavigator">One of the <see cref="T:Gizmox.WebGUI.Forms.HelpNavigator"></see> values. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public static void ShowHelp(Control objParent, string strUrl, HelpNavigator enmNavigator)
        {
            ShowHelp(objParent, strUrl, enmNavigator, null);
        }

        /// <summary>
        /// Displays the contents of the Help file located at the URL supplied by the user.
        /// </summary>
        /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box.</param>
        /// <param name="strUrl">The path and name of the Help file.</param>
        /// <param name="enmCommand">One of the <see cref="T:Gizmox.WebGUI.Forms.HelpNavigator"></see> values.</param>
        /// <param name="objParameter">The parameter.</param>
        /// <exception cref="T:System.ArgumentException">param is an integer.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void ShowHelp(Control objParent, string strUrl, HelpNavigator enmCommand, object objParameter)
        {
            switch (GetHelpFileType(strUrl))
            {
                case 3:
                    ShowHTML10Help(objParent, strUrl, enmCommand, objParameter);
                    return;

                case 2:
                    ShowHTMLFile(objParent, strUrl, enmCommand, objParameter);
                    return;
            }
        }

        /// <summary>Displays the index of the specified Help file.</summary>
        /// <param name="strUrl">The path and name of the Help file. </param>
        /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public static void ShowHelpIndex(Control objParent, string strUrl)
        {
            ShowHelp(objParent, strUrl, HelpNavigator.Index, null);
        }

        private static void ShowHTML10Help(Control objParent, string strUrl, HelpNavigator enmCommand, object objParameter)
        {
            
        }

        private static void ShowHTMLFile(Control objParent, string strUrl, HelpNavigator enmCommand, object objParameter)
        {
            Type objType = Type.GetType("Gizmox.WebGUI.Forms.HelpDialog, Gizmox.WebGUI.Forms.Help");
            if (objType != null)
            {
                objType.InvokeMember("ShowHelp", BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public, null, null, new object[] { objParent, strUrl, enmCommand, objParameter });
            }
            else
            {
                MessageBox.Show("Could not find Gizmox.WebGUI.Forms.Help assembly.", "Help Projection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Displays a Help pop-up window.</summary>
        /// <param name="strCaption">The message to display in the pop-up window. </param>
        /// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
        /// <param name="objLocation">A value specifying the horizontal and vertical coordinates at which to display the pop-up window. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public static void ShowPopup(Control objParent, string strCaption, Point objLocation)
        {
            throw new NotImplementedException();
        }
    }
	
	#endregion Help Class

    #region HelpEventArgs Class
    
    /// <summary>Represents the method that will handle the <see cref="E:S Gizmox.WebGUI.Forms.Control.HelpRequested"></see> event of a <see cref="T:S Gizmox.WebGUI.Forms.Control"></see>.</summary>
    public delegate void HelpEventHandler(object sender, HelpEventArgs hlpevent);

    /// <summary>Provides data for the <see cref="E:S Gizmox.WebGUI.Forms.Control.HelpRequested"></see> event.</summary>
    [Serializable()]
    public class HelpEventArgs : EventArgs
    {
        private bool mblnHandled;
        private readonly Point mobjMousePosition;

        /// <summary>Initializes a new instance of the <see cref="T:S Gizmox.WebGUI.Forms.HelpEventArgs"></see> class.</summary>
        /// <param name="objMousePosition">The coordinates of the mouse pointer. </param>
        public HelpEventArgs(Point objMousePosition)
        {
            this.mobjMousePosition = objMousePosition;
        }

        /// <summary>Gets or sets a value indicating whether the help event was handled.</summary>
        /// <returns>true if the event is handled; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool Handled
        {
            get
            {
                return this.mblnHandled;
            }
            set
            {
                this.mblnHandled = value;
            }
        }

        /// <summary>Gets the screen coordinates of the mouse pointer.</summary>
        /// <returns>A <see cref="T:System.Drawing.Point"></see> representing the screen coordinates of the mouse pointer.</returns>
        /// <filterpriority>1</filterpriority>
        public Point MousePos
        {
            get
            {
                return this.mobjMousePosition;
            }
        }
    }

    
    #endregion

}
