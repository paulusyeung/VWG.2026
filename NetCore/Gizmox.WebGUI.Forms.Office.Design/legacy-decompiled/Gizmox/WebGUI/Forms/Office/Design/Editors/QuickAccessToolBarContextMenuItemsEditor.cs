using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Gizmox.WebGUI.Forms.Office.Design.Editors;

public class QuickAccessToolBarContextMenuItemsEditor : UITypeEditor
{
	private class ToolStripItemsCheckedListBox : System.Windows.Forms.CheckedListBox
	{
		public string[] SelectedToolStripItems
		{
			get
			{
				List<string> list = new List<string>();
				foreach (object checkedItem in base.CheckedItems)
				{
					ToolStripItemsCheckedListBoxItem toolStripItemsCheckedListBoxItem = checkedItem as ToolStripItemsCheckedListBoxItem;
					list.Add(toolStripItemsCheckedListBoxItem.Key);
				}
				if (list.Count > 0)
				{
					return list.ToArray();
				}
				return null;
			}
		}

		public ToolStripItemsCheckedListBox(ToolStripItemCollection objAllItems, string[] arrSelectedItemsKeys)
		{
			base.CheckOnClick = true;
			SelectionMode = System.Windows.Forms.SelectionMode.One;
			List<string> list = new List<string>();
			if (arrSelectedItemsKeys != null && arrSelectedItemsKeys.Length != 0)
			{
				list.AddRange(arrSelectedItemsKeys);
			}
			if (objAllItems == null)
			{
				return;
			}
			foreach (ToolStripItem objAllItem in objAllItems)
			{
				bool isChecked = false;
				if (list.Contains(objAllItem.Name))
				{
					isChecked = true;
				}
				base.Items.Add(new ToolStripItemsCheckedListBoxItem(objAllItem.Name, objAllItem.Text), isChecked);
			}
		}
	}

	private class ToolStripItemsCheckedListBoxItem
	{
		private string mstrKey;

		private string mstrDisplayName;

		public string Key
		{
			get
			{
				return mstrKey;
			}
			set
			{
				mstrKey = value;
			}
		}

		public string DisplayName
		{
			get
			{
				return mstrDisplayName;
			}
			set
			{
				mstrDisplayName = value;
			}
		}

		internal ToolStripItemsCheckedListBoxItem(string strKey, string strDisplayName)
		{
			mstrKey = strKey;
			mstrDisplayName = strDisplayName;
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(mstrDisplayName))
			{
				return mstrKey;
			}
			return mstrKey + "[" + mstrDisplayName + "]";
		}
	}

	public override bool IsDropDownResizable => true;

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (context != null && context.Instance != null && context.Instance is Component && context.Container != null && provider != null)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService != null)
			{
				RibbonBar ribbonBar = context.Instance as RibbonBar;
				ToolStripItemsCheckedListBox toolStripItemsCheckedListBox = new ToolStripItemsCheckedListBox(ribbonBar.QuickAccessToolBarItems, ribbonBar.QuickAccessToolBarContextMenuItems);
				windowsFormsEditorService.DropDownControl(toolStripItemsCheckedListBox);
				value = toolStripItemsCheckedListBox.SelectedToolStripItems;
			}
		}
		return value;
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.DropDown;
	}
}
