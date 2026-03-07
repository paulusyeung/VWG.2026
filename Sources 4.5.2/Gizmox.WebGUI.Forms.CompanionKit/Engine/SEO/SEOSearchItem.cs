using System;
using System.Text;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.SEO
{
	/// <summary>
	/// Class describes an item found as a result of search
	/// </summary>
	public class SEOSearchItem
	{
		private SEOItem mobjItem;
		private string mstrMessage = string.Empty;

		/// <summary>
		/// The SEOItem that was found during the search
		/// </summary>
		public SEOItem Item
		{
			get { return mobjItem; }
			set { mobjItem = value; }
		}

		/// <summary>
		/// The message associated with the Item, to provide additional information.
		/// </summary>
		public string Message
		{
			get { return mstrMessage; }
			set { mstrMessage = value; }
		}

		public SEOSearchItem(SEOItem objItem):
			this(objItem, string.Empty)
		{
		}

		public SEOSearchItem(SEOItem objItem, string strMessage)
		{
			this.Item = objItem;
			this.Message = strMessage;
		}
	}

	public class SEOSearchItems : List<SEOSearchItem>
	{
		public SEOSearchItems()
		{
		}

		public SEOSearchItems(IEnumerable<SEOSearchItem> collection)
			: base(collection)
		{
		}
		
		public SEOSearchItems(int capacity)
			: base(capacity)
		{
		}
	}
}
