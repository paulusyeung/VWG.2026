using System;
using System.Data;
using System.Text;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class LobbyEditView : EditView
    {
        internal LobbyEditView()
        {
            InitializeComponent();
        }

        internal LobbyEditView(SEOLobby objItem)
            : base(objItem)
        {
            InitializeComponent();

            // Set the resource editor view
            mobjResourcesEditView.EditedItem = objItem;

            // Set the elements editor view
			mobjElementsEditView.EditedItem = objItem;
        }

        protected override bool OnSave(SEOItem objSEOItem)
        {
            SEOLobby objItem = objSEOItem as SEOLobby;
            if (objItem != null)
            {
				mobjResourcesEditView.SaveIfNeeded(objItem);

				mobjElementsEditView.OnSave();
            }

            return base.OnSave(objSEOItem);
        }

    }
}