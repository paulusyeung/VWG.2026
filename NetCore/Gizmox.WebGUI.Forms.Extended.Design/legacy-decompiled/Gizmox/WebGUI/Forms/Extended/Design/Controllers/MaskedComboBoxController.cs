using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Extended.Design.Controllers;

public class MaskedComboBoxController : ComboBoxController
{
	public MaskedComboBox WebMaskedComboBox => base.SourceObject as MaskedComboBox;

	public System.Windows.Forms.ComboBox WinMaskedComboBox => base.TargetObject as System.Windows.Forms.ComboBox;

	public MaskedComboBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
		: base(objContext, objWebTreeView, objWinTreeView)
	{
	}

	public MaskedComboBoxController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
	}

	protected override void InitializeController()
	{
		base.InitializeController();
		SetWinMaskedComboBoxText();
	}

	protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
	{
		switch (objPropertyChangeArgs.Property)
		{
		case "PromptChar":
		case "Mask":
		case "Text":
			SetWinMaskedComboBoxText();
			break;
		default:
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			break;
		}
	}

	protected virtual void SetWinMaskedComboBoxText()
	{
		string text = WebMaskedComboBox.Mask;
		if (string.IsNullOrEmpty(text))
		{
			text = "<>";
		}
		MaskedTextProvider maskedTextProvider = new MaskedTextProvider(text, CultureInfo.CurrentCulture);
		maskedTextProvider.PromptChar = WebMaskedComboBox.PromptChar;
		maskedTextProvider.IncludeLiterals = true;
		maskedTextProvider.IncludePrompt = true;
		maskedTextProvider.Set(WebMaskedComboBox.Text);
		WinMaskedComboBox.Text = maskedTextProvider.ToString();
	}
}
