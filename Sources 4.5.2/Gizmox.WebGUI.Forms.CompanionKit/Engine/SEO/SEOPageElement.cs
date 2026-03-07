using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms.SEO;

namespace Gizmox.WebGUI.Forms.SEO
{
    [Serializable]
    public class SEOPageElement : SEOPropertiesElement, ICloneable
    {
		public class Style : SEOPropertiesElement, ICloneable
		{
			/// <summary>
			/// Defines a type of action performed when an element clicked
			/// </summary>
			public enum ItemLinkType
			{
				InnerItem,
				HyperLink,
				NoLink
			}			
			
			public object Clone()
			{
				Style objStyle = new Style();
				objStyle.SetProperteis(this.mobjProperties);
				return objStyle;
			}

			public string ContainerCSS
			{
				get{ return this.GetPropertyValue("concss"); }
				set{ this.SetPropertyValue("concss", value); }
			}
			
			public string TitleCSS
			{
				get{ return this.GetPropertyValue("titlecss"); }
				set{ this.SetPropertyValue("titlecss", value); }
			}
			
			public string SeparatorCSS
			{
				get{ return this.GetPropertyValue("linecss"); }
				set{ this.SetPropertyValue("linecss", value); }
			}

			public string ImageCSS
			{
				get{ return this.GetPropertyValue("imgcss"); }
				set{ this.SetPropertyValue("imgcss", value); }
			}			
		
			public string BodyCSS
			{
				get{ return this.GetPropertyValue("bodycss"); }
				set{ this.SetPropertyValue("bodycss", value); }
			}

			/// <summary>
			/// Link could be a one of from ItemLinkType
			/// </summary>
			public ItemLinkType LinkType
			{
				get
				{
					string strValue = this.GetPropertyValue("linktype");
					strValue = String.IsNullOrEmpty(strValue)? ItemLinkType.NoLink.ToString() : strValue;
					return (ItemLinkType)Enum.Parse(typeof(ItemLinkType), strValue);
				}
				set
				{ 
					this.SetPropertyValue("linktype", value.ToString()); 
				}
			}

			/// <summary>
			/// Defines where a new window/tab should be open when an URL link clicked
			/// </summary>
			public bool OpenLinkInNewWindow
			{
				get
				{
					string strValue = this.GetPropertyValue("innew");
					strValue = strValue == string.Empty ? "false" : strValue;
					bool blnValue = false;
					bool.TryParse(strValue, out blnValue);
					return blnValue;
				}
				set
				{ 
					this.SetPropertyValue("innew", value.ToString()); 
				}
			}
		}

		// Contains informating regarding appearance of element
		private Style mobjStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SEOPageElement"/> class.
        /// </summary>
        internal SEOPageElement()
        {
			mobjStyle = new Style();
        }
		
		/// <summary>
		/// Contains informating regarding appearance of element
		/// </summary>
		public Style Styling
		{
			get { return mobjStyle; }
			set { mobjStyle = value; }
		}
        /// <summary>
        /// Gets the section ID that element associated with
        /// </summary>
        public string SectionID
        {
            get
            {
                return this.GetPropertyValue("Section");
            }
            set
            {
                this.SetPropertyValue("Section", value);
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return this.GetPropertyValue("Title");
            }
            set
            {
                this.SetPropertyValue("Title", value);
            }
        }

        /// <summary>
        /// Gets or sets the resource name for an image.
        /// </summary>
		/// <remarks>
		/// The resource taken from list of SEOItem resources collection.
		/// </remarks>
        public string Image
        {
            get
            {
                return this.GetPropertyValue("Image");
            }
            set
            {
                this.SetPropertyValue("Image", value);
            }
        }


        /// <summary>
        /// Gets or sets the link.
        /// </summary>
		/// <remarks>
		/// Additional information regarding to link available in Styling element.
		/// </remarks>
        public string Link
        {
            get
            {
                return this.GetPropertyValue("Link");
            }
            set
            {
                this.SetPropertyValue("Link", value);
            }
        }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body
        {
            get
            {
                return this.GetPropertyValue("Body");
            }
            set
            {
                this.SetPropertyValue("Body", value);
            }
        }

        #region ICloneable Members

        /// <summary>
        /// Creates a new object (deep clone) that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            SEOPageElement objSEOPageElement = new SEOPageElement();
            if (objSEOPageElement != null)
            {
                objSEOPageElement.SetProperteis(mobjProperties);
				objSEOPageElement.Styling = (SEOPageElement.Style)this.Styling.Clone();
            }
            return objSEOPageElement;
        }

        #endregion

        /// <summary>
        /// Clone an array of page items for editing
        /// </summary>
        /// <param name="objElements"></param>
        /// <returns></returns>
        internal static List<SEOPageElement> Clone(List<SEOPageElement> objElements)
        {
            List<SEOPageElement> objClonedElements = new List<SEOPageElement>();
            foreach (SEOPageElement objElement in objElements)
            {
                objClonedElements.Add((SEOPageElement)objElement.Clone());
            }
            return objClonedElements;
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        /// <param name="strElement">The element.</param>
        /// <returns></returns>
        internal static List<SEOPageElement> GetElements(XmlElement objSEOItemElement, string strElement)
        {
            List<SEOPageElement> objElements = new List<SEOPageElement>();

            XmlNodeList objNodes = objSEOItemElement.SelectNodes(string.Format("{0}/Element", strElement));

            foreach (XmlNode objNode in objNodes)
            {
                XmlElement objElement = objNode as XmlElement;
                if (objElement != null)
                {
                    SEOPageElement objSEOPageElement = new SEOPageElement();
                    objSEOPageElement.Load(objElement);
					
					XmlElement objStyleNode = (XmlElement)objElement.SelectSingleNode("Style");
					if(objStyleNode != null)
						objSEOPageElement.Styling.Load(objStyleNode);

                    objElements.Add(objSEOPageElement);
                }
            }

            return objElements;
        }

        /// <summary>
        /// Sets the elements.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        /// <param name="strElement">The element.</param>
        /// <param name="objSEOPageElements">The obj SEO page elements.</param>
        internal static void SetElements(XmlElement objSEOItemElement, string strElement, List<SEOPageElement> objSEOPageElements)
        {
            XmlDocument objDocument = objSEOItemElement.OwnerDocument;

            XmlElement objPageElementRoot = objDocument.CreateElement(strElement);
            objSEOItemElement.AppendChild(objPageElementRoot);

            foreach (SEOPageElement objSEOPageElement in objSEOPageElements)
            {
                XmlElement objPageElement = objDocument.CreateElement("Element");
                objPageElementRoot.AppendChild(objPageElement);
                objSEOPageElement.Save(objPageElement);

				// serialize style of page element
                XmlElement objStyleElement = objDocument.CreateElement("Style");
				objPageElement.AppendChild(objStyleElement);
				objSEOPageElement.Styling.Save(objStyleElement);

            }
        }

        /// <summary>
        /// Validateds the reference(link).
        /// </summary>
        /// <returns>
		/// true: if the Link to an InnerItem and if referenced item is found
		/// true: if the Link is URL and the Link text is not empty
		/// true: if the Link's type is Style.LinkType.NoLink
		/// else: false
		/// </returns>
        public bool IsValidLink()
        {
			if (this.Styling.LinkType == Style.ItemLinkType.InnerItem)
			{
				return !String.IsNullOrEmpty(this.Link) && (GetLinkedItem() != null);
			}
			else if (this.Styling.LinkType == Style.ItemLinkType.HyperLink)
			{
				return !String.IsNullOrEmpty(this.Link);
			}
			else if (this.Styling.LinkType == Style.ItemLinkType.NoLink)
			{
				return true;
			}

			return false;
        }

        public SEOItem GetLinkedItem()
        {
            return SEOSite.GetItem(this.Link);
        }

		public static string GetLinkFromItem(SEOItem objSEOItem)
        {
			if (objSEOItem != null)
            {
				return objSEOItem.GetInnerLink();
            }
            return string.Empty;
        }
    }
}
