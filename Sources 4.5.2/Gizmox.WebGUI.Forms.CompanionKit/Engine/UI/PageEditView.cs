#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class PageEditView : EditView
    {

        public PageEditView()
        {
            InitializeComponent();
        }

        public PageEditView(SEOPage objSEOPage) : base(objSEOPage)
        {
            InitializeComponent();

            // Set the resource editor view
            mobjResourcesEditView.EditedItem = objSEOPage;
            // set inspector control
			mobjInspectorEditView.Inspector = objSEOPage.Inspector;
			// ste user control height value, leave empty if default
			mobjTxtHeight.Text = objSEOPage.UserControlHeight == 0 ? "" : objSEOPage.UserControlHeight.ToString();
        }

        protected override void OnLoad(SEOItem objSEOItem)
        {
            base.OnLoad(objSEOItem);
        }

        protected override bool OnSave(SEOItem objSEOItem)
        {
			int		intHeight			= 0;
            SEOPage objSEOPage = objSEOItem as SEOPage;
            
			mobjResourcesEditView.SaveIfNeeded(objSEOItem);
            
			if (objSEOPage != null)
            {
                objSEOPage.Inspector = mobjInspectorEditView.Inspector;

				// at this time already passed validation, set the value or set the default
				if (mobjTxtHeight.Text.Length > 0)
				{
					int.TryParse(mobjTxtHeight.Text, out intHeight);
					objSEOPage.UserControlHeight = intHeight;
				}
				else
				{
					// set default
					objSEOPage.UserControlHeight = 0;
				}
            }
            
			return base.OnSave(objSEOItem);
        }

        protected override bool ValidateBeforeSave(SEOItem objSEOItem)
        {
			Control objIndicateError	= null;
			int		intHeight			= 0;
			bool	blnValid			= base.ValidateBeforeSave(objSEOItem);
			string  strMessage			= "Invalid control height, leave empty or 0 to apply desing time settings.";
			bool	blnParseHeigh		= int.TryParse(mobjTxtHeight.Text, out intHeight);

			// validate control height entered
			if ( mobjTxtHeight.Text.Length >0 && (!blnParseHeigh || intHeight < 0))
			{
				objIndicateError = mobjTxtHeight;
				blnValid = false;
                this.Errors.SetError(objIndicateError, strMessage);
			}

			return blnValid;
        }

		/// <summary>
		/// User control height description
		/// </summary>
		private void objCmdHelp_Click(object sender, EventArgs e)
		{
			base.cmdHelp_Click(sender, e);
		}

    }
}