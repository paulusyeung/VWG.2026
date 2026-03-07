using System;
using System.Text;
using System.IO;

namespace Gizmox.WebGUI.Forms
{
    
	public class HelpDialog : HelpFormBase
    {
        private string mstrCHMLocation = null;
        private HelpNavigator menmCommand = HelpNavigator.TableOfContents;
        private object mobjParam = null;

        public HelpDialog(string strCHMLocation, HelpNavigator enmCommand, object objParam)
        {
            mstrCHMLocation = strCHMLocation;
            menmCommand = enmCommand;
            mobjParam = objParam;
        }

        /// <summary>
        /// Gets the help dialog initialization command.
        /// </summary>
        protected override HelpNavigator InitializationCommand
        {
            get
            {
                return menmCommand;
            }
        }

        /// <summary>
        /// Gets the help dialog initialization paramter.
        /// </summary>
        protected override object InitializationParam
        {
            get
            {
                return mobjParam;
            }
        }


        protected override string CHMLocation
        {
            get
            {
                return mstrCHMLocation;
            }
        }

        public static void ShowHelp(Control objParent, string strCHMLocation, HelpNavigator enmCommand, object objParam)
        {
            if (File.Exists(strCHMLocation))
            {
                HelpFormBase objHelpDialog = new HelpDialog(strCHMLocation, enmCommand, objParam);
                objHelpDialog.ShowDialog();
            }
        }
    }
}
