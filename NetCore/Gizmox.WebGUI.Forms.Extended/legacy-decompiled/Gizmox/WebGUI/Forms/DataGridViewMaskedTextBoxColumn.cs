using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms;

/// <summary>
///
/// </summary>
[Serializable]
[DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
[ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.DataGidViewMaskedTextBoxColumnController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
public class DataGridViewMaskedTextBoxColumn : DataGridViewTextBoxColumn
{
	private const char mcntPromptChar = '_';

	/// <summary>Gets or sets the template used to model cell appearance.</summary>
	/// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
	/// <exception cref="T:System.InvalidCastException">The set type is not compatible with type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see>. </exception>
	/// <filterpriority>1</filterpriority>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public override DataGridViewCell CellTemplate
	{
		get
		{
			return base.CellTemplate;
		}
		set
		{
			if (value != null && !(value is DataGridViewMaskedTextBoxCell))
			{
				throw new InvalidCastException(string.Format("Value provided for CellTemplate must be of type {0} or derive from it.", new object[1] { "Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxCell" }));
			}
			base.CellTemplate = value;
		}
	}

	/// <summary>
	/// Gets the masked text box cell template.
	/// </summary>
	/// <value>The masked text box cell template.</value>
	private DataGridViewMaskedTextBoxCell MaskedTextBoxCellTemplate => (DataGridViewMaskedTextBoxCell)CellTemplate;

	/// <summary>
	/// Gets or sets the mask.
	/// </summary>
	/// <value>The mask.</value>
	[Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Localizable(true)]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue("")]
	public string Mask
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.Mask;
		}
		set
		{
			if (!(Mask != value))
			{
				return;
			}
			MaskedTextBoxCellTemplate.Mask = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is DataGridViewMaskedTextBoxCell dataGridViewMaskedTextBoxCell)
				{
					dataGridViewMaskedTextBoxCell.Mask = value;
				}
			}
		}
	}

	/// <summary>
	/// Gets or sets the prompt char.
	/// </summary>
	/// <value>The prompt char.</value>
	[Localizable(true)]
	[DefaultValue('_')]
	[RefreshProperties(RefreshProperties.Repaint)]
	public char PromptChar
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.PromptChar;
		}
		set
		{
			if (PromptChar == value)
			{
				return;
			}
			MaskedTextBoxCellTemplate.PromptChar = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is DataGridViewMaskedTextBoxCell dataGridViewMaskedTextBoxCell)
				{
					dataGridViewMaskedTextBoxCell.PromptChar = value;
				}
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether [hide prompt on leave].
	/// </summary>
	/// <value><c>true</c> if [hide prompt on leave]; otherwise, <c>false</c>.</value>
	[DefaultValue(false)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public bool HidePromptOnLeave
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.HidePromptOnLeave;
		}
		set
		{
			if (HidePromptOnLeave == value)
			{
				return;
			}
			MaskedTextBoxCellTemplate.HidePromptOnLeave = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is DataGridViewMaskedTextBoxCell dataGridViewMaskedTextBoxCell)
				{
					dataGridViewMaskedTextBoxCell.HidePromptOnLeave = value;
				}
			}
		}
	}

	/// <summary>
	/// Gets or sets the text mask format.
	/// </summary>
	/// <value>The text mask format.</value>
	[DefaultValue(MaskFormat.IncludeLiterals)]
	public MaskFormat TextMaskFormat
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.TextMaskFormat;
		}
		set
		{
			if (TextMaskFormat == value)
			{
				return;
			}
			MaskedTextBoxCellTemplate.TextMaskFormat = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is DataGridViewMaskedTextBoxCell dataGridViewMaskedTextBoxCell)
				{
					dataGridViewMaskedTextBoxCell.TextMaskFormat = value;
				}
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether System.Windows.Forms.MaskedTextBox.PromptChar
	/// can be entered as valid data by the user.
	/// </summary>
	/// <value>
	///   <c>true</c> if the user can enter the prompt character into the control; otherwise, <c>false</c>.
	/// </value>
	[Category("CatBehavior")]
	[Description("MaskedTextBoxAllowPromptAsInputDescr")]
	[DefaultValue(true)]
	public bool AllowPromptAsInput
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.AllowPromptAsInput;
		}
		set
		{
			if (HidePromptOnLeave == value)
			{
				return;
			}
			MaskedTextBoxCellTemplate.AllowPromptAsInput = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is DataGridViewMaskedTextBoxCell dataGridViewMaskedTextBoxCell)
				{
					dataGridViewMaskedTextBoxCell.AllowPromptAsInput = value;
				}
			}
		}
	}

	/// <summary>
	/// Gets or sets a value that determines how an input character that matches
	/// the prompt character should be handled.
	/// </summary>
	/// <value>
	///   <c>true</c> if the prompt character entered as input causes the current editable
	///     position in the mask to be reset; otherwise, <c>false</c>.to indicate that the prompt
	///     character is to be processed as a normal input character
	/// </value>
	[Description("MaskedTextBoxResetOnPrompt")]
	[DefaultValue(true)]
	[Category("CatBehavior")]
	public bool ResetOnPrompt
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.ResetOnPrompt;
		}
		set
		{
			if (HidePromptOnLeave == value)
			{
				return;
			}
			MaskedTextBoxCellTemplate.ResetOnPrompt = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is DataGridViewMaskedTextBoxCell dataGridViewMaskedTextBoxCell)
				{
					dataGridViewMaskedTextBoxCell.ResetOnPrompt = value;
				}
			}
		}
	}

	[Description("MaskedTextBoxResetOnSpace")]
	[DefaultValue(true)]
	[Category("CatBehavior")]
	public bool ResetOnSpace
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.ResetOnSpace;
		}
		set
		{
			if (HidePromptOnLeave == value)
			{
				return;
			}
			MaskedTextBoxCellTemplate.ResetOnSpace = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is DataGridViewMaskedTextBoxCell dataGridViewMaskedTextBoxCell)
				{
					dataGridViewMaskedTextBoxCell.ResetOnSpace = value;
				}
			}
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxColumn"></see> class to the default state.</summary>
	public DataGridViewMaskedTextBoxColumn()
		: base(new DataGridViewMaskedTextBoxCell())
	{
	}

	/// <summary>
	/// Returns a <see cref="T:System.String" /> that represents this instance.
	/// </summary>
	/// <returns>
	/// A <see cref="T:System.String" /> that represents this instance.
	/// </returns>
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("DataGridViewMaskedTextBoxColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}
}
