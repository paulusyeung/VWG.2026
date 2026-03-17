using System;
using System.CodeDom;

namespace A;

internal sealed class cb61326e3535b3ff39f7574e41092b768
{
	private CodeExpression cad6dbf388260d69e7204802b7a392308;

	private Type c9cdd9ba8b73a244badc9a3b81b0d035b;

	private object cf77e0239ef4d595b7270942decdd1642;

	public CodeExpression Expression => cad6dbf388260d69e7204802b7a392308;

	public Type ExpressionType => c9cdd9ba8b73a244badc9a3b81b0d035b;

	public object Value => cf77e0239ef4d595b7270942decdd1642;

	public cb61326e3535b3ff39f7574e41092b768(CodeExpression expression, object value)
		: this(expression, value, null)
	{
	}

	public cb61326e3535b3ff39f7574e41092b768(CodeExpression expression, object value, Type t)
	{
		cad6dbf388260d69e7204802b7a392308 = expression;
		cf77e0239ef4d595b7270942decdd1642 = value;
		c9cdd9ba8b73a244badc9a3b81b0d035b = t;
	}
}
