using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarGroupController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarGroupController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[ToolboxItem(false)]
public class RibbonBarGroup : RibbonBarItemContainer
{
	[DefaultValue(false)]
	public bool HasAdvanced
	{
		get
		{
			return RibbonBarGroupBox.HasAdvanced;
		}
		set
		{
			if (RibbonBarGroupBox.HasAdvanced != value)
			{
				RibbonBarGroupBox.HasAdvanced = value;
				CalculateWidth();
			}
		}
	}

	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			if (base.Text != value)
			{
				base.Text = value;
				CalculateWidth();
			}
		}
	}

	private RibbonBar.RibbonBarGroupBox RibbonBarGroupBox => base.Control as RibbonBar.RibbonBarGroupBox;

	internal GroupBox GroupBox => base.Control as GroupBox;

	[Editor("Gizmox.WebGUI.Forms.Office.Design.RibonBarGroupItemCollectionEditor, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726", typeof(UITypeEditor))]
	public override RibbonBarItemCollection Items => base.Items;

	protected internal override RibbonBar RibbonBar
	{
		get
		{
			if (base.Owner is RibbonBarGroupCollection ribbonBarGroupCollection)
			{
				return ribbonBarGroupCollection.RibbonBar;
			}
			return base.RibbonBar;
		}
	}

	internal override void SetOwner(object objOwner)
	{
		base.SetOwner(objOwner);
	}

	protected override Control CreateControl()
	{
		RibbonBar.RibbonBarGroupBox ribbonBarGroupBox = new RibbonBar.RibbonBarGroupBox();
		ribbonBarGroupBox.AdvancedClicked += OnAdvancedClicked;
		ribbonBarGroupBox.Dock = DockStyle.Left;
		ribbonBarGroupBox.Padding = new Padding(2, 0, 0, 0);
		return ribbonBarGroupBox;
	}

	private void OnAdvancedClicked(object sender, EventArgs e)
	{
		if (RibbonBar != null)
		{
			RibbonBar.OnAdvancedClicked(this);
		}
	}

	public override string ToString()
	{
		return Text;
	}

	internal override void AppendControl(Control objControl)
	{
		base.AppendControl(objControl);
		objControl.Dock = DockStyle.Left;
		if (objControl is Button button)
		{
			button.Width = 56;
		}
		CalculateWidth();
	}

	internal void CalculateWidth()
	{
		int num = 0;
		foreach (Control control in base.Control.Controls)
		{
			num += control.Width;
		}
		num = Math.Max(20, num);
		RibbonBarGroupBoxSkin ribbonBarGroupBoxSkin = RibbonBarGroupBox.Skin as RibbonBarGroupBoxSkin;
		if (!string.IsNullOrEmpty(Text))
		{
			Size stringMeasurements = CommonUtils.GetStringMeasurements(Text, base.Control.Font);
			if (HasAdvanced)
			{
				stringMeasurements.Width += (ribbonBarGroupBoxSkin.RibbonGroupOpenImageWidth + 1) * 2;
			}
			num = Math.Max(stringMeasurements.Width, num);
		}
		num += base.Control.Padding.Horizontal + ribbonBarGroupBoxSkin.LeftFrameWidth + ribbonBarGroupBoxSkin.RightFrameWidth;
		base.Control.Width = num;
	}

	protected override Type[] GetValidItemTypes()
	{
		return new List<Type>
		{
			typeof(RibbonBarButtonItem),
			typeof(RibbonBarCheckBoxItem),
			typeof(RibbonBarDropDownButtonItem),
			typeof(RibbonBarStackItem),
			typeof(RibbonBarFlowItem)
		}.ToArray();
	}

	public void Apply(ISupportsRibbonBar objGenerator, string strGroupName)
	{
		objGenerator.ApplyGroup(this, strGroupName);
	}

	protected override void Dispose(bool blnDisposing)
	{
		base.Dispose(blnDisposing);
		if (!blnDisposing)
		{
			return;
		}
		foreach (RibbonBarItem item in Items)
		{
			item.Dispose();
		}
	}
}
