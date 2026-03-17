using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class TypeResourceHandleSerializer : ResourceHandleSerializer
{
	protected override List<CodeExpression> GetCodeExpressionParams(IDesignerSerializationManager objManager, string strFile)
	{
		List<CodeExpression> list = base.GetCodeExpressionParams(objManager, strFile);
		if (list != null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			list = new List<CodeExpression>();
		}
		if (objManager.GetService(typeof(IDesignerHost)) is IDesignerHost designerHost)
		{
			CodeTypeOfExpression codeTypeOfExpression = new CodeTypeOfExpression(designerHost.RootComponentClassName);
			if (codeTypeOfExpression != null)
			{
				list.Insert(0, codeTypeOfExpression);
			}
		}
		return list;
	}
}
