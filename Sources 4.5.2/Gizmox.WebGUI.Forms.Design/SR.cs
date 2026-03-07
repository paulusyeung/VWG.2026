#region Using

using System;
using System.Globalization;
using System.Resources;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
	#region SR Class
	
	/// <summary>
	///
	/// </summary>
    
    internal sealed class SR
	{
		#region Class Members
		
		#region Consts
		
		internal const string Test = "Test";
		
		
		#endregion Consts
		
		#region Statics
		
		/// <summary>
		/// The singltone SR class
		/// </summary>
		private static SR mobjLoader;
		
		
		#endregion Statics
		
		/// <summary>
		/// The string resource resource manegar
		/// </summary>
		private ResourceManager mobjResources;
		
		
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="SR"/> instance.
		/// </summary>
		static SR()
		{
			SR.mobjLoader = null;
		}
		
		/// <summary>
		/// Creates a new <see cref="SR"/> instance.
		/// </summary>
		internal SR()
		{
			this.mobjResources = new ResourceManager("Gizmox.WebGUI.Forms.Design.SR", base.GetType().Assembly);
		}
		
		
		#endregion C'Tor\D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static bool GetBoolean(string name)
		{
			return SR.GetBoolean(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static bool GetBoolean(CultureInfo culture, string name)
		{
			bool blnFlag = false;
			SR objLoader = SR.GetLoader();
			if (objLoader != null)
			{
				object objObject = objLoader.mobjResources.GetObject(name, culture);
				if (objObject is bool)
				{
					blnFlag = (bool) objObject;
				}
			}
			return blnFlag;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static byte GetByte(string name)
		{
			return SR.GetByte(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static byte GetByte(CultureInfo culture, string name)
		{
			byte byteNumber = 0;
			SR objLoader = SR.GetLoader();
			if (objLoader != null)
			{
				object objObject = objLoader.mobjResources.GetObject(name, culture);
				if (objObject is byte)
				{
					byteNumber = (byte) objObject;
				}
			}
			return byteNumber;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static char GetChar(string name)
		{
			return SR.GetChar(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static char GetChar(CultureInfo culture, string name)
		{
			char objChar = '\0';
			SR objLoader = SR.GetLoader();
			if (objLoader != null)
			{
				object objObject = objLoader.mobjResources.GetObject(name, culture);
				if (objObject is char)
				{
					objChar = (char) objObject;
				}
			}
			return objChar;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static double GetDouble(string name)
		{
			return SR.GetDouble(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static double GetDouble(CultureInfo culture, string name)
		{
			double dblNumber = 0;
			SR objLoader = SR.GetLoader();
			if (objLoader == null)
			{
				object objObject = objLoader.mobjResources.GetObject(name, culture);
				if (objObject is double)
				{
					dblNumber = (double) objObject;
				}
			}
			return dblNumber;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static float GetFloat(string name)
		{
			return SR.GetFloat(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static float GetFloat(CultureInfo culture, string name)
		{
			float snglNumber = 0f;
			SR objLoader = SR.GetLoader();
			if (objLoader == null)
			{
				object objObject = objLoader.mobjResources.GetObject(name, culture);
				if (objObject is float)
				{
					snglNumber = (float) objObject;
				}
			}
			return snglNumber;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static int GetInt(string name)
		{
			return SR.GetInt(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static int GetInt(CultureInfo culture, string name)
		{
			int intNumber = 0;
			SR objLoader = SR.GetLoader();
			if (objLoader != null)
			{
				object objObject = objLoader.mobjResources.GetObject(name, culture);
				if (objObject is int)
				{
					intNumber = (int) objObject;
				}
			}
			return intNumber;
		}
		
		/// <summary>
		///
		/// </summary>
		private static SR GetLoader()
		{
			if (SR.mobjLoader == null)
			{
				lock (typeof(SR))
				{
					if (SR.mobjLoader == null)
					{
						SR.mobjLoader = new SR();
					}
				}
			}
			return SR.mobjLoader;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static long GetLong(string name)
		{
			return SR.GetLong(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static long GetLong(CultureInfo culture, string name)
		{
			long lngNumber = 0;
			SR objLoader = SR.GetLoader();
			if (objLoader != null)
			{
				object objObject = objLoader.mobjResources.GetObject(name, culture);
				if (objObject is long)
				{
					lngNumber = (long) objObject;
				}
			}
			return lngNumber;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static object GetObject(string name)
		{
			return SR.GetObject(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static object GetObject(CultureInfo culture, string name)
		{
			SR objLoader = SR.GetLoader();
			if (objLoader == null)
			{
				return null;
			}
			return objLoader.mobjResources.GetObject(name, culture);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static short GetShort(string name)
		{
			return SR.GetShort(null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static short GetShort(CultureInfo culture, string name)
		{
			short shortNumber = 0;
			SR objLoader = SR.GetLoader();
			if (objLoader != null)
			{
				object objObject = objLoader.mobjResources.GetObject(name, culture);
				if (objObject is short)
				{
					shortNumber = (short) objObject;
				}
			}
			return shortNumber;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public static string GetString(string name)
		{
			return SR.GetString((CultureInfo) null, name);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		public static string GetString(CultureInfo culture, string name)
		{
			SR objLoader = SR.GetLoader();
			if (objLoader == null)
			{
				return null;
			}
			string strResource = objLoader.mobjResources.GetString(name, culture);
			return strResource==null?name:strResource;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		/// <param name="args"></param>
		public static string GetString(string name, params object[] args)
		{
			return SR.GetString(null, name, args);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="name"></param>
		/// <param name="args"></param>
		public static string GetString(CultureInfo culture, string name, params object[] args)
		{
			SR objLoader = SR.GetLoader();
			if (objLoader == null)
			{
				return null;
			}
			string strText = objLoader.mobjResources.GetString(name, culture);
			if ((args != null) && (args.Length > 0))
			{
				return string.Format(strText, args);
			}
			return strText;
		}
		
		
		#endregion Methods
		
	}
	
	#endregion SR Class
	
}
