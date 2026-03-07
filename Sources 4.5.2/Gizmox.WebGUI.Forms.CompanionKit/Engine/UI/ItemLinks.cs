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
using Gizmox.WebGUI.Hosting;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
	/// <summary>
	/// Form contains textboxes to provide links for direct access to the snipet
	/// </summary>
	public partial class ItemLinks : Form
	{
		private SEOItem mobjItem;

		public SEOItem Item
		{
			get { return mobjItem; }
			set { mobjItem = value; }
		}


		public ItemLinks(SEOItem item)
		{
			InitializeComponent();

			this.Item = item;
			Itit();
		}

		private void Itit()
		{
			string strDomain = SEOUtils.GetDomainValue(HostContext.Current.Request.Url);
			
			mobjTxtItemLink.Text = this.Item.HrefLink;

			mobjTxtCSharpZip.Text = string.Format("{0}{1}", strDomain, this.Item.GetZipLink(LanguageType.CSharp));
			mobjTxtVBZip.Text = string.Format("{0}{1}", strDomain, this.Item.GetZipLink(LanguageType.VBNET));

			mobjTxtItemLink.Focus();
			mobjTxtItemLink.SelectAll();

		}

		private void mobjCmdClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
