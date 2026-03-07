using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;
using Gizmox.WebGUI.Forms.CompanionKit.Engine;
using Gizmox.WebGUI.Forms.KB.Engine.Data;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class ArticleEditView : EditView
    {
        internal ArticleEditView()
        {
            InitializeComponent();
        }

        internal ArticleEditView(SEOArticle objSEOArticle)
            : base(objSEOArticle)
        {

			// will be called later than OnLoad()!
            InitializeComponent();
			
			// unlock editing if article code is a valid one and the article is available
			mobjTxtCode.Text = objSEOArticle.Code;
			mobjTextName.Enabled = false;
        }

        protected override void OnLoad(SEOItem objSEOItem)
        {
            base.OnLoad(objSEOItem);
        }

        protected override bool OnSave(SEOItem objSEOItem)
        {
			SEOArticle objSEOArticle = (SEOArticle)objSEOItem;
			objSEOArticle.Code = mobjTxtCode.Text;
            return base.OnSave(objSEOItem);
        }

        /// <summary>
        /// Designer is unhappy with direct call to cmdHelp_Click()
        /// So add the intermediate stage to call to base
        /// </summary>
        protected override void cmdHelp_Click(object sender, EventArgs e)
        {
            base.cmdHelp_Click(sender,e);
        }

        protected override bool ValidateBeforeSave(SEOItem objSEOItem)
        {
			Control objIndicateError	= null;
			string	strCode				= string.Empty;
			string	strTitle			= mobjTextTitle.Text.Trim();
			bool	blnValid			= base.ValidateBeforeSave(objSEOItem);

			// if enabled we dealing with new article get the Code from Name
			if (mobjTextName.Enabled == true)
			{
				strCode = mobjTextName.Text.Trim();
				objIndicateError = mobjTextName;
			}
			else
			{
				// we dealing with exisiting item and user only can change the mapping to the article
				// than get the code from the Code field
				strCode = mobjTxtCode.Text;
				objIndicateError = mobjTxtCode;
			}

			string strMessage;
            
			if (blnValid && strTitle == string.Empty)
            {
                this.Errors.SetError(objIndicateError, "The Article title cannot be empty");
                blnValid = false;
            }
			
			return blnValid;
        }
    }
}
