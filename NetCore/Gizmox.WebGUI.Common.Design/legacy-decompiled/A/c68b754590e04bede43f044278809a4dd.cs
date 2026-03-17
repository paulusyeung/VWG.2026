using System;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace A;

internal sealed class c68b754590e04bede43f044278809a4dd
{
	internal const string c64d45953b548da8dab771c3b9c270e13 = "Test";

	private static c68b754590e04bede43f044278809a4dd caabf22f92c3ae90cad681cae2043a1af;

	private ResourceManager ce1dbedcbe803f3f17028cb4b0dcb7778;

	static c68b754590e04bede43f044278809a4dd()
	{
		caabf22f92c3ae90cad681cae2043a1af = null;
	}

	internal c68b754590e04bede43f044278809a4dd()
	{
		ce1dbedcbe803f3f17028cb4b0dcb7778 = new ResourceManager("A.c68b754590e04bede43f044278809a4dd", GetType().Assembly);
	}

	public static bool GetBoolean(string name)
	{
		return GetBoolean(null, name);
	}

	public static bool GetBoolean(CultureInfo culture, string name)
	{
		bool result = false;
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			object obj = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
			if (!(obj is bool))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = (bool)obj;
			}
		}
		return result;
	}

	public static byte GetByte(string name)
	{
		return GetByte(null, name);
	}

	public static byte GetByte(CultureInfo culture, string name)
	{
		byte result = 0;
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			object obj = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
			if (!(obj is byte))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = (byte)obj;
			}
		}
		return result;
	}

	public static char GetChar(string name)
	{
		return GetChar(null, name);
	}

	public static char GetChar(CultureInfo culture, string name)
	{
		char result = '\0';
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			object obj = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
			if (!(obj is char))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = (char)obj;
			}
		}
		return result;
	}

	public static double GetDouble(string name)
	{
		return GetDouble(null, name);
	}

	public static double GetDouble(CultureInfo culture, string name)
	{
		double result = 0.0;
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader != null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			object obj = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
			if (!(obj is double))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = (double)obj;
			}
		}
		return result;
	}

	public static float GetFloat(string name)
	{
		return GetFloat(null, name);
	}

	public static float GetFloat(CultureInfo culture, string name)
	{
		float result = 0f;
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader != null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			object obj = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
			if (!(obj is float))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = (float)obj;
			}
		}
		return result;
	}

	public static int GetInt(string name)
	{
		return GetInt(null, name);
	}

	public static int GetInt(CultureInfo culture, string name)
	{
		int result = 0;
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			object obj = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
			if (!(obj is int))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = (int)obj;
			}
		}
		return result;
	}

	private static c68b754590e04bede43f044278809a4dd GetLoader()
	{
		if (caabf22f92c3ae90cad681cae2043a1af != null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			Type typeFromHandle = typeof(c68b754590e04bede43f044278809a4dd);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(typeFromHandle, ref lockTaken);
				if (caabf22f92c3ae90cad681cae2043a1af != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					caabf22f92c3ae90cad681cae2043a1af = new c68b754590e04bede43f044278809a4dd();
				}
			}
			finally
			{
				if (!lockTaken)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Monitor.Exit(typeFromHandle);
				}
			}
		}
		return caabf22f92c3ae90cad681cae2043a1af;
	}

	public static long GetLong(string name)
	{
		return GetLong(null, name);
	}

	public static long GetLong(CultureInfo culture, string name)
	{
		long result = 0L;
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			object obj = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
			if (!(obj is long))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = (long)obj;
			}
		}
		return result;
	}

	public static object GetObject(string name)
	{
		return GetObject(null, name);
	}

	public static object GetObject(CultureInfo culture, string name)
	{
		return GetLoader()?.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
	}

	public static short GetShort(string name)
	{
		return GetShort(null, name);
	}

	public static short GetShort(CultureInfo culture, string name)
	{
		short result = 0;
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader != null)
		{
			object obj = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetObject(name, culture);
			if (!(obj is short))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = (short)obj;
			}
		}
		return result;
	}

	public static string GetString(string name)
	{
		return GetString(null, name);
	}

	public static string GetString(CultureInfo culture, string name)
	{
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			string text = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetString(name, culture);
			if (text == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return name;
			}
			return text;
		}
		return null;
	}

	public static string GetString(string name, params object[] args)
	{
		return GetString(null, name, args);
	}

	public static string GetString(CultureInfo culture, string name, params object[] args)
	{
		c68b754590e04bede43f044278809a4dd loader = GetLoader();
		if (loader != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			string text = loader.ce1dbedcbe803f3f17028cb4b0dcb7778.GetString(name, culture);
			if (args == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (args.Length != 0)
				{
					return string.Format(text, args);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return text;
		}
		return null;
	}
}
