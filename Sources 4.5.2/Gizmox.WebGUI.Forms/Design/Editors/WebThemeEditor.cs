using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel;
using System.Collections;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class WebThemeEditor : StandardValuesEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebThemeEditor"/> class.
        /// </summary>
        /// <param name="objTypeConvertor">The obj type convertor.</param>
        public WebThemeEditor(TypeConverter objTypeConvertor)
            : base(objTypeConvertor)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebThemeEditor"/> class.
        /// </summary>
        public WebThemeEditor()
        {
        }

        /// <summary>
        /// Gets the list values.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <returns></returns>
        protected override ArrayList GetListValues(ITypeDescriptorContext objContext)
        {
            ArrayList objArrayList = new ArrayList();

            foreach (string strTheme in ConfigHelper.Themes)
            {
                objArrayList.Add(strTheme);
            }

            return objArrayList;
        }
    }
}
