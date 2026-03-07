using System;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

using HtmlHelp;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.HelpLibrary
{
	/// <summary>
	/// Summary description for CHMExplorerNode.
	/// </summary>
	
	internal class CHMExplorerNode
	{
		/// <summary>
		/// Current toc items
		/// </summary>
		private TOCItem mobjTOCItem = null;

		/// <summary>
		/// Child toc items
		/// </summary>
		private CHMExplorerNode[] mobjTOCItems = null;

		/// <summary>
		/// Current node id
		/// </summary>
		private string  mstrNodeId = null;


		/// <summary>
		/// The owner controller
		/// </summary>
		private CHMExplorerController mobjController = null;

		/// <summary>
		/// The current node parent
		/// </summary>
		private CHMExplorerNode mobjParent = null;

		/// <summary>
		/// Create a new CHMExplorerNode
		/// </summary>
		public CHMExplorerNode(CHMExplorerController objController,CHMExplorerNode objParent)
		{
			// Set the current node parent
			mobjParent = objParent;

			// set current controller
			mobjController = objController;
		}

		/// <summary>
		/// The TOC item name
		/// </summary>
		public string Name
		{
			get
			{
				return mobjTOCItem!=null?mobjTOCItem.Name:"";				
			}
		}

		/// <summary>
		/// Gets the current node id
		/// </summary>
		public string Local
		{
			get
			{
				if(mstrNodeId==null)
				{					
					mstrNodeId = mobjTOCItem!=null?mobjTOCItem.Local:Guid.NewGuid().ToString();
				}
				return mstrNodeId;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        public bool HasNodes
        {
            get
            {
                return this.Nodes.Length > 0;
            }
        }

		/// <summary>
		/// The current node parent
		/// </summary>
		public CHMExplorerNode Parent
		{
			get
			{
				return mobjParent;
			}
		}

		/// <summary>
		/// The current TOC item nodes
		/// </summary>
		public CHMExplorerNode[] Nodes
		{
			get
			{
				if(mobjTOCItems==null)
				{
					mobjTOCItems = new CHMExplorerNode[]{};
				}
				return mobjTOCItems;
			}
		}




		/// <summary>
		/// Create a new CHMExplorerNode
		/// </summary>
		/// <param name="objTOCItems"></param>
		public void Load(ArrayList objTOCItems)
		{
			// Register current node
			this.Register();

			// Load child toc items
			this.LoadTOCItems(objTOCItems);
		}

		/// <summary>
		/// 
		/// </summary>
		private void Register()
		{
			this.mobjController.Register(this);
		}

		/// <summary>
		/// Create a new CHMExplorerNode
		/// </summary>
		/// <param name="objTOCItem"></param>
		public void Load(TOCItem objTOCItem)
		{
			// Set current toc item
			this.mobjTOCItem = objTOCItem;

			// Register current node
			this.Register();

			// Load child toc items
			this.LoadTOCItems(mobjTOCItem.Children);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objTOCItems"></param>
		private void LoadTOCItems(ArrayList objTOCItems)
		{
			// Create toc items array
			ArrayList objList = new ArrayList();

			// Add all toc items to array
			foreach(TOCItem objTOCItem in objTOCItems)
			{
				// Create chm explorer node
				CHMExplorerNode objCHMExplorerNode = new CHMExplorerNode(mobjController,this);
				objCHMExplorerNode.Load(objTOCItem);

				// Add chm explorer node
				objList.Add(objCHMExplorerNode);
			}

			// Create toc items
			mobjTOCItems = (CHMExplorerNode[])objList.ToArray(typeof(CHMExplorerNode));
		}		
	}
}
