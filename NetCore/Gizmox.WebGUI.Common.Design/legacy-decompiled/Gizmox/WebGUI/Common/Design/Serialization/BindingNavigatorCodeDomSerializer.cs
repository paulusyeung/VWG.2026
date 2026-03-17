using System.CodeDom;
using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class BindingNavigatorCodeDomSerializer : ControlCodeDomSerializer
{
	public override object Serialize(IDesignerSerializationManager manager, object value)
	{
		object obj = base.Serialize(manager, value);
		if (!(obj is CodeStatementCollection codeStatementCollection))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			CodeMethodInvokeExpression value2 = new CodeMethodInvokeExpression(GetExpression(manager, value), "AddStandardItems");
			codeStatementCollection.Add(value2);
		}
		return obj;
	}
}
