using System;
using System.Collections;
using System.Text;
using Gizmox.WebGUI.Common.Configuration;
using System.IO;

namespace Gizmox.WebGUI.Forms
{
    
	public class HelpForm : HelpFormBase
    {
        private string mstrCHMLocation = null;
        private HelpNavigator menmCommand = HelpNavigator.TableOfContents;
        private object mobjParam = null;
        private bool mblnInitialized = false;

        private void InitializeParams()
        {
            if (!mblnInitialized)
            {
                if (this.Context.Arguments != null && this.Context.Arguments["command"] != null)
                {

                    try
                    {
                        menmCommand = (HelpNavigator)Enum.Parse(typeof(HelpNavigator), (string)this.Context.Arguments["command"]);
                    }
                    catch (Exception)
                    {
                        menmCommand = HelpNavigator.TableOfContents;
                    }
                }

                if (this.Context.Arguments != null && this.Context.Arguments["param"] != null)
                {

                    try
                    {
                        mobjParam = this.Context.Arguments["param"];
                    }
                    catch (Exception)
                    {
                        mobjParam = null;
                    }
                }

                mblnInitialized = true;
            }
        }
        protected override HelpNavigator InitializationCommand
        {
            get 
            {
                InitializeParams();
                return menmCommand;
            }
        }

        protected override object InitializationParam
        {
            get 
            {
                InitializeParams();
                return mobjParam;
            }
        }

        protected override string CHMLocation
        {
            get 
            {
                if (mstrCHMLocation == null)
                {
                    Config objConfig = Config.GetInstance();
                    mstrCHMLocation = Path.Combine(objConfig.GetDirectory("Data"), "Help.chm");
                }
                return mstrCHMLocation;
            }
        }
    }
}
