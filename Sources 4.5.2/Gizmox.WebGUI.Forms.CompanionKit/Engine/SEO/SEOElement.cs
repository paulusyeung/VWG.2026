using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// Provides the base SEO element
    /// </summary>
    [Serializable]
    public abstract class SEOElement
    {
        /// <summary>
        /// Loads the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public abstract void Load(XmlElement objSEOItemElement);


        /// <summary>
        /// Saves the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public abstract void Save(XmlElement objSEOItemElement);

    }

	public abstract class SEOPropertiesElement : SEOElement
	{
        protected Dictionary<string, string> mobjProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="SEOPropertiesElement"/> class.
        /// </summary>
        internal SEOPropertiesElement()
        {
            mobjProperties = new Dictionary<string, string>();
        }
        
        /// <summary>
        /// Loads the specified item element.
        /// </summary>
		public override void Load(XmlElement objElement)
        {
			if (mobjProperties == null)
			{
				mobjProperties = new Dictionary<string, string>();
			}
			else
			{
				mobjProperties.Clear();
			}

            foreach (XmlAttribute objAttribute in objElement.Attributes)
            {
                mobjProperties[objAttribute.Name] = objAttribute.Value;
            }
        }

        /// <summary>
        /// Saves the specified item element.
        /// </summary>
        public override void Save(XmlElement objElement)
        {
            foreach (string strKey in mobjProperties.Keys)
            {
				string value = mobjProperties[strKey];
				if (value.Trim().Length >0)
				{
					objElement.SetAttribute(strKey, mobjProperties[strKey]);
				}
            }
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        protected virtual void SetPropertyValue(string strProperty, string strValue)
        {
            if (strValue == null)
            {
                strValue = string.Empty;
            }

            mobjProperties[strProperty] = strValue;
        }

        /// <summary>
        /// Sets the properteis.
        /// </summary>
        protected virtual void SetProperteis(Dictionary<string, string> objProperties)
        {
            mobjProperties.Clear();
            foreach (string strKey in objProperties.Keys)
            {
                mobjProperties[strKey] = objProperties[strKey];
            }
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        protected virtual string GetPropertyValue(string strProperty)
        {
            if (mobjProperties.ContainsKey(strProperty))
            {
                return mobjProperties[strProperty];
            }
            return string.Empty;
        }

	}
}
