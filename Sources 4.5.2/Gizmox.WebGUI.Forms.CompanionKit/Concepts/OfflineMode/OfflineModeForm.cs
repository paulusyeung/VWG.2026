#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;

#endregion

namespace OfflineModeSampleAppCS
{
    public partial class OfflineModeForm : Form
    {
        public OfflineModeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the ClientPreload event of the OfflineModeForm control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void OfflineModeForm_ClientPreload(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.PreloadResources(OnResourceLoad);
        }

        /// <summary>
        /// Handles the OfflineConfirming event of the OfflineModeForm control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void OfflineModeForm_OfflineConfirming(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("offlineConfirming");
        }

        /// <summary>
        /// Handles the OfflineInitializing event of the OfflineModeForm control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void OfflineModeForm_OfflineInitializing(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("offlineInitializing");
        }

        /// <summary>
        /// Called when [resource load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PreloadResourcesCompleteEventArgs"/> instance containing the event data.</param>
        void OnResourceLoad(object sender, PreloadResourcesCompleteEventArgs e)
        {
            string mstrMessage = string.Format("Resources preloading complete ({0} resources loaded, {1} loading errors)", e.ResourceLoadedCount, e.ResourceErrorCount);
            VWGClientContext.Current.Invoke("writeLineToLog", mstrMessage);
        }

    }
}