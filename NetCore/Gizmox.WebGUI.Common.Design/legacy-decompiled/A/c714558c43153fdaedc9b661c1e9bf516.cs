using System;
using System.IO;
using System.Reflection;

namespace A;

internal class c714558c43153fdaedc9b661c1e9bf516
{
	private static readonly Assembly c97a939c92e76413351018fc77a1bf513;

	static c714558c43153fdaedc9b661c1e9bf516()
	{
		if ((object)c97a939c92e76413351018fc77a1bf513 != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string name = executingAssembly.GetName().Name;
		string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
		for (int i = 0; i < manifestResourceNames.Length; i++)
		{
			/*OpCode not supported: LdMemberToken*/;
			string text = manifestResourceNames[i];
			if (name == text)
			{
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
				byte[] rawAssembly = c2aee64b9953eb2782d163182e14d7764.ce041d9d9d766f6f8ac29991be74361c7(manifestResourceStream);
				c97a939c92e76413351018fc77a1bf513 = Assembly.Load(rawAssembly);
				break;
			}
		}
	}

	internal static void c95a07f2efec6c04022d9990b4638f916()
	{
		AppDomain.CurrentDomain.ResourceResolve += ca24b4550905c9e0edac2474a1119fee0;
	}

	private static Assembly ca24b4550905c9e0edac2474a1119fee0(object c3c7f260388ff5aa270b8982517f05e9c, ResolveEventArgs c6a7889fcfe7bfff9c0def383cd4a8785)
	{
		if ((object)c97a939c92e76413351018fc77a1bf513 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return c97a939c92e76413351018fc77a1bf513;
		}
		string[] manifestResourceNames = c97a939c92e76413351018fc77a1bf513.GetManifestResourceNames();
		for (int i = 0; i < manifestResourceNames.Length; i++)
		{
			/*OpCode not supported: LdMemberToken*/;
			string text = manifestResourceNames[i];
			if (!(text == c6a7889fcfe7bfff9c0def383cd4a8785.Name))
			{
				/*OpCode not supported: LdMemberToken*/;
				continue;
			}
			return c97a939c92e76413351018fc77a1bf513;
		}
		return null;
	}
}
