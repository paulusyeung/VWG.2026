using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class ResourceHandleSerializer : CodeDomSerializer
{
	public override object Serialize(IDesignerSerializationManager objManager, object objValue)
	{
		if (objManager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (objValue == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (!(objValue is ResourceHandle resourceHandle))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			Type type = resourceHandle.GetType();
			if (!(type != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				List<CodeExpression> codeExpressionParams = GetCodeExpressionParams(objManager, resourceHandle.File);
				if (codeExpressionParams != null)
				{
					return new CodeObjectCreateExpression(type.FullName, codeExpressionParams.ToArray());
				}
			}
		}
		return base.Serialize(objManager, objValue);
	}

	protected virtual List<CodeExpression> GetCodeExpressionParams(IDesignerSerializationManager objManager, string strFile)
	{
		List<CodeExpression> list = new List<CodeExpression>();
		if (!(base.Serialize(objManager, strFile) is CodeExpression item))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			list.Add(item);
		}
		return list;
	}
}
