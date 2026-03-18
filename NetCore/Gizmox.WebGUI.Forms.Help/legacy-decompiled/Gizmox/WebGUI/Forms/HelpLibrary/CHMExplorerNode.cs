using System;
using System.Collections;
using HtmlHelp;

namespace Gizmox.WebGUI.Forms.HelpLibrary;

internal class CHMExplorerNode
{
	private TOCItem mobjTOCItem = null;

	private CHMExplorerNode[] mobjTOCItems = null;

	private string mstrNodeId = null;

	private CHMExplorerController mobjController = null;

	private CHMExplorerNode mobjParent = null;

	public string Name => (mobjTOCItem != null) ? mobjTOCItem.Name : "";

	public string Local
	{
		get
		{
			if (mstrNodeId == null)
			{
				mstrNodeId = ((mobjTOCItem != null) ? mobjTOCItem.Local : Guid.NewGuid().ToString());
			}
			return mstrNodeId;
		}
	}

	public bool HasNodes => Nodes.Length != 0;

	public CHMExplorerNode Parent => mobjParent;

	public CHMExplorerNode[] Nodes
	{
		get
		{
			if (mobjTOCItems == null)
			{
				mobjTOCItems = new CHMExplorerNode[0];
			}
			return mobjTOCItems;
		}
	}

	public CHMExplorerNode(CHMExplorerController objController, CHMExplorerNode objParent)
	{
		mobjParent = objParent;
		mobjController = objController;
	}

	public void Load(ArrayList objTOCItems)
	{
		Register();
		LoadTOCItems(objTOCItems);
	}

	private void Register()
	{
		mobjController.Register(this);
	}

	public void Load(TOCItem objTOCItem)
	{
		mobjTOCItem = objTOCItem;
		Register();
		LoadTOCItems(mobjTOCItem.Children);
	}

	private void LoadTOCItems(ArrayList objTOCItems)
	{
		ArrayList arrayList = new ArrayList();
		foreach (TOCItem objTOCItem in objTOCItems)
		{
			CHMExplorerNode cHMExplorerNode = new CHMExplorerNode(mobjController, this);
			cHMExplorerNode.Load(objTOCItem);
			arrayList.Add(cHMExplorerNode);
		}
		mobjTOCItems = (CHMExplorerNode[])arrayList.ToArray(typeof(CHMExplorerNode));
	}
}
