using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Represents base login mechanism.
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    public abstract class AdministrationLogonControlBase : ContentChangeNotifierUserControl
    {
        /// <summary>
        /// Determines whether valid login data provided.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is valid login data]; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsValidLogonData();
        //public abstract string GetCurrentContentName();

        /// <summary>
        /// Logon action called by user.
        /// </summary>
        public bool Logon()
        {
            bool blnIsLoggedOn = this.IsValidLogonData();
            this.Context.IsLoggedOn = blnIsLoggedOn;
            return blnIsLoggedOn;
        }
    }
}
