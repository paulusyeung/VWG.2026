using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Common.Design.Skins;

internal class DocumentDesignerTree : TreeView
{
	private DocumentDesignerFrame mobjDocumentDesignerFrame;

	private Dictionary<object, TreeNode> mobjTreeNodesByObject;

	private List<Type> mobjSkinTypes;

	private ImageList mobjTreeIcons;

	private Dictionary<Type, Type> mobjSkinContainer = new Dictionary<Type, Type>();

	private Type mobjSkinContainerAttributeType;

	public Type SkinContainerAttributeType
	{
		get
		{
			if (mobjSkinContainerAttributeType == null)
			{
				ThemeDocumentDesigner themeDocumentDesigner = (ThemeDocumentDesigner)GetService(typeof(ThemeDocumentDesigner));
				if (themeDocumentDesigner != null)
				{
					mobjSkinContainerAttributeType = themeDocumentDesigner.SkinContainerAttributeType;
				}
			}
			return mobjSkinContainerAttributeType;
		}
	}

	private Dictionary<object, TreeNode> NodesByObject => mobjTreeNodesByObject;

	private List<Type> SkinTypes => mobjSkinTypes;

	public DocumentDesignerTree()
	{
		mobjTreeNodesByObject = new Dictionary<object, TreeNode>();
		mobjSkinTypes = new List<Type>();
		mobjTreeIcons = new ImageList();
		base.ImageList = mobjTreeIcons;
	}

	protected override void OnAfterSelect(TreeViewEventArgs e)
	{
		base.OnAfterSelect(e);
		SetSelection(e.Node);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		SetSelection(base.SelectedNode);
	}

	internal void ResetSelection()
	{
		TreeNode selection = base.SelectedNode;
		ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		if (selectionService != null)
		{
			selectionService.SetSelectedComponents(null);
			SetSelection(selection);
		}
	}

	private void SetSelection(TreeNode objSelectedNode)
	{
		if (objSelectedNode != null)
		{
			ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
			if (selectionService != null && selectionService.PrimarySelection != objSelectedNode.Tag)
			{
				selectionService.SetSelectedComponents(new object[1] { objSelectedNode.Tag }, SelectionTypes.Click);
			}
		}
	}

	private IComponent GetSkinInstance(Type objSkinType)
	{
		INestedContainer nestedContainer = (INestedContainer)GetService(typeof(INestedContainer));
		if (nestedContainer != null)
		{
			foreach (IComponent component in nestedContainer.Components)
			{
				if (component.GetType() == objSkinType)
				{
					return component;
				}
			}
			return null;
		}
		return null;
	}

	public void Initialize(DocumentDesignerFrame objDocumentDesignerFrame)
	{
		mobjDocumentDesignerFrame = objDocumentDesignerFrame;
		InitializeNodes();
	}

	private void InitializeNodes()
	{
		base.Nodes.Clear();
		NodesByObject.Clear();
		SkinTypes.Clear();
		ThemeDocumentDesigner themeDocumentDesigner = (ThemeDocumentDesigner)GetService(typeof(ThemeDocumentDesigner));
		if (themeDocumentDesigner == null)
		{
			return;
		}
		mobjSkinTypes = themeDocumentDesigner.SkinTypes;
		IComponent component = mobjDocumentDesignerFrame.Component;
		if (component != null)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Tag = component;
			treeNode.Text = "Theme";
			treeNode.ToolTipText = component.GetType().FullName;
			treeNode.ImageIndex = GetImageIndex(component.GetType());
			treeNode.SelectedImageIndex = treeNode.ImageIndex;
			NodesByObject[component] = treeNode;
			base.Nodes.Add(treeNode);
			InitializeNodes(themeDocumentDesigner, themeDocumentDesigner.SkinType, treeNode);
			Sort();
			treeNode.ExpandAll();
			if (treeNode.FirstNode != null)
			{
				base.SelectedNode = treeNode.FirstNode;
			}
			base.SelectedNode = treeNode;
		}
	}

	private int GetImageIndex(Type objType)
	{
		ToolboxBitmapAttribute toolboxBitmapAttribute = (ToolboxBitmapAttribute)TypeDescriptor.GetAttributes(objType)[typeof(ToolboxBitmapAttribute)];
		if (toolboxBitmapAttribute != null)
		{
			Bitmap bitmap = toolboxBitmapAttribute.GetImage(objType, large: false) as Bitmap;
			if (bitmap != null && (bitmap.Width != 16 || bitmap.Height != 16))
			{
				bitmap = new Bitmap(bitmap, new Size(16, 16));
			}
			if (bitmap != null)
			{
				mobjTreeIcons.Images.Add(bitmap);
				return mobjTreeIcons.Images.Count - 1;
			}
		}
		return -1;
	}

	private void InitializeNodes(ThemeDocumentDesigner objThemeDocumentDesigner, Type objCurrentSkinType, TreeNode objParentNode)
	{
		if (objThemeDocumentDesigner == null || !(objCurrentSkinType != null) || objParentNode == null)
		{
			return;
		}
		foreach (Type skinType in SkinTypes)
		{
			if (!IsContainedSkin(skinType, objCurrentSkinType))
			{
				continue;
			}
			TreeNode treeNode = objParentNode;
			if (objThemeDocumentDesigner.IsVisibleSkinType(skinType))
			{
				IComponent skinInstance = GetSkinInstance(skinType);
				if (skinInstance != null)
				{
					treeNode = new TreeNode();
					treeNode.Tag = skinInstance;
					treeNode.Text = GetDisplayName(skinType.Name);
					treeNode.ToolTipText = skinType.FullName;
					treeNode.ImageIndex = GetImageIndex(skinType);
					TreeNode treeNode2 = treeNode;
					treeNode2.SelectedImageIndex = treeNode2.ImageIndex;
					NodesByObject[skinType] = treeNode;
					NodesByObject[skinInstance] = treeNode;
					objParentNode.Nodes.Add(treeNode);
				}
			}
			InitializeNodes(objThemeDocumentDesigner, skinType, treeNode);
		}
	}

	private string GetDisplayName(string strTypeName)
	{
		if (strTypeName.Length > 4 && strTypeName.EndsWith("Skin"))
		{
			return strTypeName.Substring(0, strTypeName.Length - 4);
		}
		return strTypeName;
	}

	private bool IsContainedSkin(Type objSkinType, Type objCurrentSkinType)
	{
		if (!mobjSkinContainer.ContainsKey(objSkinType))
		{
			bool flag = false;
			if (SkinContainerAttributeType != null)
			{
				object[] customAttributes = objSkinType.GetCustomAttributes(SkinContainerAttributeType, inherit: false);
				if (customAttributes.Length != 0)
				{
					Type type = DocumentUtils.GetPropertyValue(customAttributes[0], "SkinType") as Type;
					if (type != null)
					{
						mobjSkinContainer[objSkinType] = type;
						flag = true;
					}
				}
			}
			if (!flag)
			{
				mobjSkinContainer[objSkinType] = objSkinType.BaseType;
			}
		}
		return mobjSkinContainer[objSkinType] == objCurrentSkinType;
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 123)
		{
			mobjDocumentDesignerFrame.ShowContextMenu();
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	protected override object GetService(Type objServiceType)
	{
		if (mobjDocumentDesignerFrame != null)
		{
			object serviceInternal = mobjDocumentDesignerFrame.GetServiceInternal(objServiceType);
			if (serviceInternal != null)
			{
				return serviceInternal;
			}
		}
		return base.GetService(objServiceType);
	}
}
