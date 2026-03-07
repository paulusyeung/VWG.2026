using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class FolderEditView : EditView
    {
        public FolderEditView()
        {
            InitializeComponent();
        }

        public FolderEditView(SEOFolder objSEOFolder)
            : base(objSEOFolder)
        {
            InitializeComponent();
			Init(objSEOFolder);
        }

		protected virtual void Init(SEOFolder objFolder)
		{
			if (objFolder != null)
			{
				// folder with lobby
				mobjChkLobbyLike.Checked = objFolder.HasLobby;
				mobjChkLobbyLike_CheckedChanged(null, null);
				
				// default item
				mobjCmbDefaultItem.IncludeRoot = false;
				mobjCmbDefaultItem.FoldersOnly = false;
				mobjCmbDefaultItem.Root = objFolder;
				mobjCmbDefaultItem.SelectedNode = objFolder.DefaultPage;

				// Set edited item
				mobjElementsEditView.EditedItem = objFolder;

				// Set the resource editor view
				mobjResourcesEditView.EditedItem = objFolder;

			}
		}

		private void mobjChkLobbyLike_CheckedChanged(object sender, EventArgs e)
		{
			mobjCmbDefaultItem.Enabled = ! mobjChkLobbyLike.Checked;
			mobjElementsEditView.Enabled = mobjChkLobbyLike.Checked;
			// emphase the label font
			mobjLblDefaultItem.Font = new Font(mobjLblDefaultItem.Font, mobjCmbDefaultItem.Enabled? FontStyle.Bold : FontStyle.Regular);
			lblLobbyElelements.Font = new Font(lblLobbyElelements.Font, mobjElementsEditView.Enabled ? FontStyle.Bold : FontStyle.Regular);
		}

		protected override bool OnSave(SEOItem objSEOItem)
		{
            SEOFolder objFolder = objSEOItem as SEOFolder;
			if (objFolder != null)
			{
				// save potentially changed properties
				objFolder.HasLobby = mobjChkLobbyLike.Checked;
				objFolder.DefaultPage = objFolder.HasLobby ? null : mobjCmbDefaultItem.SelectedNode;
				
				// Save elements
				mobjElementsEditView.OnSave();

				// Save resources
				mobjResourcesEditView.SaveIfNeeded(objSEOItem);
			}
			return base.OnSave(objSEOItem);
		}
    }
}
