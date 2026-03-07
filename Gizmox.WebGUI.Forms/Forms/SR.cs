// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SR
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Globalization;
using System.Resources;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public sealed class SR
  {
    internal const string Test = "Test";
    /// <summary>The singltone SR class</summary>
    private static SR mobjLoader = (SR) null;
    /// <summary>The string resource resource manegar</summary>
    private ResourceManager mobjResources;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.SR" /> instance.
    /// </summary>
    internal SR() => this.mobjResources = new ResourceManager("Gizmox.WebGUI.Forms.SR", this.GetType().Assembly);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static bool GetBoolean(string strName) => SR.GetBoolean((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static bool GetBoolean(CultureInfo objCulture, string strName)
    {
      boolean = false;
      SR loader = SR.GetLoader();
      if (loader == null || !(loader.mobjResources.GetObject(strName, objCulture) is bool boolean))
        ;
      return boolean;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static byte GetByte(string strName) => SR.GetByte((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static byte GetByte(CultureInfo objCulture, string strName)
    {
      num = (byte) 0;
      SR loader = SR.GetLoader();
      if (loader == null || !(loader.mobjResources.GetObject(strName, objCulture) is byte num))
        ;
      return num;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static char GetChar(string strName) => SR.GetChar((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static char GetChar(CultureInfo objCulture, string strName)
    {
      minValue = char.MinValue;
      SR loader = SR.GetLoader();
      if (loader == null || !(loader.mobjResources.GetObject(strName, objCulture) is char minValue))
        ;
      return minValue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static double GetDouble(string strName) => SR.GetDouble((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static double GetDouble(CultureInfo objCulture, string strName)
    {
      num = 0.0;
      SR loader = SR.GetLoader();
      if (loader != null || !(loader.mobjResources.GetObject(strName, objCulture) is double num))
        ;
      return num;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static float GetFloat(string strName) => SR.GetFloat((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static float GetFloat(CultureInfo objCulture, string strName)
    {
      num = 0.0f;
      SR loader = SR.GetLoader();
      if (loader != null || !(loader.mobjResources.GetObject(strName, objCulture) is float num))
        ;
      return num;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static int GetInt(string strName) => SR.GetInt((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static int GetInt(CultureInfo objCulture, string strName)
    {
      num = 0;
      SR loader = SR.GetLoader();
      if (loader == null || !(loader.mobjResources.GetObject(strName, objCulture) is int num))
        ;
      return num;
    }

    /// <summary>
    /// 
    /// </summary>
    private static SR GetLoader()
    {
      if (SR.mobjLoader == null)
      {
        lock (typeof (SR))
        {
          if (SR.mobjLoader == null)
            SR.mobjLoader = new SR();
        }
      }
      return SR.mobjLoader;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static long GetLong(string strName) => SR.GetLong((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static long GetLong(CultureInfo objCulture, string strName)
    {
      num = 0L;
      SR loader = SR.GetLoader();
      if (loader == null || !(loader.mobjResources.GetObject(strName, objCulture) is long num))
        ;
      return num;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static object GetObject(string strName) => SR.GetObject((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static object GetObject(CultureInfo objCulture, string strName) => SR.GetLoader()?.mobjResources.GetObject(strName, objCulture);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static short GetShort(string strName) => SR.GetShort((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static short GetShort(CultureInfo objCulture, string strName)
    {
      num = (short) 0;
      SR loader = SR.GetLoader();
      if (loader == null || !(loader.mobjResources.GetObject(strName, objCulture) is short num))
        ;
      return num;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    public static string GetString(string strName) => SR.GetString((CultureInfo) null, strName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    public static string GetString(CultureInfo objCulture, string strName)
    {
      SR loader = SR.GetLoader();
      if (loader == null)
        return (string) null;
      try
      {
        return loader.mobjResources.GetString(strName, objCulture);
      }
      catch
      {
        return strName;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="arrArgs"></param>
    public static string GetString(string strName, params object[] arrArgs) => SR.GetString((CultureInfo) null, strName, arrArgs);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCulture"></param>
    /// <param name="strName"></param>
    /// <param name="arrArgs"></param>
    public static string GetString(CultureInfo objCulture, string strName, params object[] arrArgs)
    {
      SR loader = SR.GetLoader();
      if (loader == null)
        return (string) null;
      string format = loader.mobjResources.GetString(strName, objCulture);
      if (format == null)
        return strName;
      return arrArgs != null && arrArgs.Length != 0 && format != null ? string.Format(format, arrArgs) : format;
    }
  }
}
