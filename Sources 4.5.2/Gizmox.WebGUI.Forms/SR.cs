#region Using

using System;
using System.Globalization;
using System.Resources;
using Gizmox.WebGUI.Common;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region SR Class

    /// <summary>
    ///
    /// </summary>

    [Serializable()]
    public sealed class SR
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
            this.mobjResources = new ResourceManager("Gizmox.WebGUI.Forms.SR", base.GetType().Assembly);
        }

        #endregion C'Tor\D'Tor

        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static bool GetBoolean(string strName)
        {
            return SR.GetBoolean(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static bool GetBoolean(CultureInfo objCulture, string strName)
        {
            bool blnFlag = false;
            SR objLoader = SR.GetLoader();
            if (objLoader != null)
            {
                object objObject = objLoader.mobjResources.GetObject(strName, objCulture);
                if (objObject is bool)
                {
                    blnFlag = (bool)objObject;
                }
            }
            return blnFlag;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static byte GetByte(string strName)
        {
            return SR.GetByte(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static byte GetByte(CultureInfo objCulture, string strName)
        {
            byte byteNumber = 0;
            SR objLoader = SR.GetLoader();
            if (objLoader != null)
            {
                object objObject = objLoader.mobjResources.GetObject(strName, objCulture);
                if (objObject is byte)
                {
                    byteNumber = (byte)objObject;
                }
            }
            return byteNumber;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static char GetChar(string strName)
        {
            return SR.GetChar(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static char GetChar(CultureInfo objCulture, string strName)
        {
            char chr = '\0';
            SR objLoader = SR.GetLoader();
            if (objLoader != null)
            {
                object objObject = objLoader.mobjResources.GetObject(strName, objCulture);
                if (objObject is char)
                {
                    chr = (char)objObject;
                }
            }
            return chr;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static double GetDouble(string strName)
        {
            return SR.GetDouble(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static double GetDouble(CultureInfo objCulture, string strName)
        {
            double dblNumber = 0;
            SR objLoader = SR.GetLoader();
            if (objLoader == null)
            {
                object objObject = objLoader.mobjResources.GetObject(strName, objCulture);
                if (objObject is double)
                {
                    dblNumber = (double)objObject;
                }
            }
            return dblNumber;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static float GetFloat(string strName)
        {
            return SR.GetFloat(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static float GetFloat(CultureInfo objCulture, string strName)
        {
            float fltSnglNumber = 0f;
            SR objLoader = SR.GetLoader();
            if (objLoader == null)
            {
                object objObject = objLoader.mobjResources.GetObject(strName, objCulture);
                if (objObject is float)
                {
                    fltSnglNumber = (float)objObject;
                }
            }
            return fltSnglNumber;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static int GetInt(string strName)
        {
            return SR.GetInt(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static int GetInt(CultureInfo objCulture, string strName)
        {
            int intNumber = 0;
            SR objLoader = SR.GetLoader();
            if (objLoader != null)
            {
                object objObject = objLoader.mobjResources.GetObject(strName, objCulture);
                if (objObject is int)
                {
                    intNumber = (int)objObject;
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
        /// <param name="strName"></param>
        public static long GetLong(string strName)
        {
            return SR.GetLong(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static long GetLong(CultureInfo objCulture, string strName)
        {
            long lngNumber = 0;
            SR objLoader = SR.GetLoader();
            if (objLoader != null)
            {
                object objObject = objLoader.mobjResources.GetObject(strName, objCulture);
                if (objObject is long)
                {
                    lngNumber = (long)objObject;
                }
            }
            return lngNumber;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static object GetObject(string strName)
        {
            return SR.GetObject(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static object GetObject(CultureInfo objCulture, string strName)
        {
            SR objLoader = SR.GetLoader();
            if (objLoader == null)
            {
                return null;
            }
            return objLoader.mobjResources.GetObject(strName, objCulture);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static short GetShort(string strName)
        {
            return SR.GetShort(null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static short GetShort(CultureInfo objCulture, string strName)
        {
            short shortNumber = 0;
            SR objLoader = SR.GetLoader();
            if (objLoader != null)
            {
                object objObject = objLoader.mobjResources.GetObject(strName, objCulture);
                if (objObject is short)
                {
                    shortNumber = (short)objObject;
                }
            }
            return shortNumber;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        public static string GetString(string strName)
        {
            return SR.GetString((CultureInfo)null, strName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        public static string GetString(CultureInfo objCulture, string strName)
        {
            SR objLoader = SR.GetLoader();
            if (objLoader == null)
            {
                return null;
            }

            try
            {
                return objLoader.mobjResources.GetString(strName, objCulture);
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
        public static string GetString(string strName, params object[] arrArgs)
        {
            return SR.GetString(null, strName, arrArgs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objCulture"></param>
        /// <param name="strName"></param>
        /// <param name="arrArgs"></param>
        public static string GetString(CultureInfo objCulture, string strName, params object[] arrArgs)
        {
            SR objLoader = SR.GetLoader();
            if (objLoader == null)
            {
                return null;
            }
            string strText = objLoader.mobjResources.GetString(strName, objCulture);
            if (strText == null)
            {
                return strName;
            }
            if ((arrArgs != null) && (arrArgs.Length > 0) && (strText != null))
            {
                return string.Format(strText, arrArgs);
            }
            return strText;
        }

        #endregion Methods
    }

    #endregion SR Class

    #region WGInternalLabels Class

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    internal class WGInternalLabels
    {
        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        private static string GetString(string strName)
        {
            return SR.GetString(Global.Context.CurrentUICulture, strName);
        }

        #endregion Methods
    }

    #endregion WGInternalLabels Class
}
