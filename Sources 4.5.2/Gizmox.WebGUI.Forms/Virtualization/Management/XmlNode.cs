#region Using

using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Microsoft.Win32;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Gizmox.WebGUI.Virtualization.Management
{
	#region XmlDocumentNode Class
	
	/// <summary>
	///
	/// </summary>

    [Serializable()]
    internal class XmlDocumentNode : ServerExplorerNode
	{
		#region Class Members
		
		private XmlDocument mobjDocument;
		
		
		#endregion Class Members
		
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strLabel"></param>
		/// <param name="strPath"></param>
		internal XmlDocumentNode(string strLabel,string strPath)
		{
			
			mobjDocument = new XmlDocument();
			mobjDocument.Load(strPath);
			Label		= strLabel;
			Tag			= strPath;
			Image		= new IconResourceHandle("Folder.gif");
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void LoadNodes()
		{
			foreach(XmlNode objNode in mobjDocument.DocumentElement.ChildNodes)
			{
				if(objNode.NodeType==XmlNodeType.Element)
				{
					Nodes.Add(new XmlNodeNode(objNode));
				}
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objColumns"></param>
		protected override void LoadColumns(Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection objColumns)
		{
			objColumns.Add("Name",200,HorizontalAlignment.Left);
			objColumns.Add("Value",300,HorizontalAlignment.Left);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objItems"></param>
		protected override void LoadItems(Gizmox.WebGUI.Forms.ListView.ListViewItemCollection objItems)
		{
			
		}
		
		
		#endregion Methods
		
	}
	
	#endregion XmlDocumentNode Class
	
	#region XmlNodeNode Class
	
	/// <summary>
	///
	/// </summary>

    [Serializable()]
    internal class XmlNodeNode : ServerExplorerNode
	{
		#region Class Members
		
		private XmlNode mobjNode;
		
		
		#endregion Class Members
		
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objNode"></param>
		internal XmlNodeNode(XmlNode objNode)
		{
			mobjNode = objNode;
			Label = objNode.Name;
			HasNodes = objNode.ChildNodes.Count>0;
			Image = new IconResourceHandle("file.gif");
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void LoadNodes()
		{
			foreach(XmlNode objNode in mobjNode.ChildNodes)
			{
				if(objNode.NodeType==XmlNodeType.Element)
				{
					Nodes.Add(new XmlNodeNode(objNode));
				}
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objColumns"></param>
		protected override void LoadColumns(Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection objColumns)
		{
			objColumns.Add("Name",200,HorizontalAlignment.Left);
			objColumns.Add("Value",300,HorizontalAlignment.Left);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objItems"></param>
		protected override void LoadItems(Gizmox.WebGUI.Forms.ListView.ListViewItemCollection objItems)
		{
			foreach(XmlAttribute objAttribute in mobjNode.Attributes)
			{
				objItems.Add(objAttribute.Name).SubItems.Add(objAttribute.Value);
			}
		}
		
		
		#endregion Methods
		
	}
	
	#endregion XmlNodeNode Class
	
}
