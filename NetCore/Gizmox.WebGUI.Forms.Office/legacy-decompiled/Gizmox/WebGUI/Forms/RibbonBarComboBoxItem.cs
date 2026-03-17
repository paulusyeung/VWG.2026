using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarComboBoxItem : RibbonBarItem
{
	protected ComboBox ComboBox => base.Control as ComboBox;

	[DefaultValue(null)]
	public object DataSource
	{
		get
		{
			return ComboBox.DataSource;
		}
		set
		{
			ComboBox.DataSource = value;
		}
	}

	[DefaultValue("")]
	public string DisplayMember
	{
		get
		{
			return ComboBox.DisplayMember;
		}
		set
		{
			ComboBox.DisplayMember = value;
		}
	}

	[DefaultValue("")]
	public string ValueMember
	{
		get
		{
			return ComboBox.ValueMember;
		}
		set
		{
			ComboBox.ValueMember = value;
		}
	}

	[Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ComboBox.ObjectCollection Items => ComboBox.Items;

	public event EventHandler TextChanged;

	protected override Control CreateControl()
	{
		RibbonBar.RibbonBarComboBox ribbonBarComboBox = new RibbonBar.RibbonBarComboBox();
		ribbonBarComboBox.TextChanged += OnComboBoxTextChanged;
		return ribbonBarComboBox;
	}

	private void OnComboBoxTextChanged(object sender, EventArgs e)
	{
		this.TextChanged?.Invoke(this, EventArgs.Empty);
	}
}
