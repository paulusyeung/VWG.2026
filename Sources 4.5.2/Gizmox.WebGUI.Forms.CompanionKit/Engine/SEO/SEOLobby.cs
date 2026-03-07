using System;
using System.Collections.Generic;
using System.Text;

using Gizmox.WebGUI.Forms.SEO;
using System.Xml;

namespace Gizmox.WebGUI.Forms.SEO
{
	public class SEOLobby : SEOItem
	{
		public class Section : SEOElement, ICloneable
		{
			/// <summary>
			/// Default amount of columns
			/// </summary>
			public const	int					AMOUNT_COLUMNS	= 3;

			private			int					mintColumns		= AMOUNT_COLUMNS;
			// Contains informating regarding appearance of elements on that lobby
			private			SectionStyle		mobjStyle;

			private 		string 				mstrTitle		= string.Empty;
			private 		string 				mstrPreText		= string.Empty;
			private			string				mstrStyleName	= string.Empty;
			private			string				mstrID			= string.Empty;

			public Section()
			{
				mobjStyle = new SectionStyle();
			}

			public object Clone()
			{
				Section objClone = (Section)this.MemberwiseClone();
				objClone.Style = (SectionStyle)this.Style.Clone();
				return objClone;
			}
			
			public SectionStyle Style
			{
				get { return mobjStyle; }
				set { mobjStyle = value; }
			}

			/// <summary>
			/// Gets or sets the number of columns section.
			/// </summary>
			public int Columns
			{
				get { return mintColumns; }
				set { mintColumns = value; }
			}

			public string Title
			{
				get { return mstrTitle; }
				set { mstrTitle = value; }
			}

			public string PreText
			{
				get { return mstrPreText; }
				set { mstrPreText = value; }
			}

			public string StyleName
			{
				get { return mstrStyleName; }
				set { mstrStyleName = value; }
			}

			public string ID
			{
				get { return mstrID; }
				set { mstrID = value; }
			}


			public override void Load(XmlElement objItemElement)
			{
				this.ID = SEOUtils.GetAttribute(objItemElement,"ID", string.Empty);
				this.StyleName = SEOUtils.GetAttribute(objItemElement,"style", string.Empty);
				this.Columns = SEOUtils.GetAttribute(objItemElement,"cols", AMOUNT_COLUMNS);
				this.PreText = SEOUtils.GetValue(objItemElement, "PreText", string.Empty);
				this.Title   = SEOUtils.GetValue(objItemElement, "Title", string.Empty);

				// deserialize style of lobby section
				XmlElement objStyleNode = (XmlElement)objItemElement.SelectSingleNode("Style");
				if(objStyleNode != null)
					this.Style.Load(objStyleNode);
			}

			public override void Save(XmlElement objItemElement)
			{
				XmlElement objSectionNode = objItemElement.OwnerDocument.CreateElement("Section");

				if (!String.IsNullOrEmpty(this.ID))
					SEOUtils.SetAttribute(objSectionNode,"ID", this.ID);

				if (!String.IsNullOrEmpty(this.StyleName))
					SEOUtils.SetAttribute(objSectionNode,"style", this.StyleName);

				if (this.Columns != AMOUNT_COLUMNS)
					SEOUtils.SetAttribute(objSectionNode, "cols", this.Columns);

				if (!String.IsNullOrEmpty(this.PreText))
					SEOUtils.SetValue(objSectionNode, "PreText",  this.PreText);
				
				if (!String.IsNullOrEmpty(this.Title))
					SEOUtils.SetValue(objSectionNode, "Title",  this.Title);

				// serialize style of lobby item
				XmlElement objStyleNode = objSectionNode.OwnerDocument.CreateElement("Style");
				this.Style.Save(objStyleNode);
				
				objSectionNode.AppendChild(objStyleNode);
				objItemElement.AppendChild(objSectionNode);
			}
		}

		public class SectionStyle : SEOPropertiesElement, ICloneable
		{
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

			public string PreTextCSS
			{
				get{ return this.GetPropertyValue("precss"); }
				set{ this.SetPropertyValue("precss", value); }
			}

			public object Clone()
			{
				SectionStyle objStyle = new SectionStyle();
				objStyle.SetProperteis(this.mobjProperties);
				return objStyle;
			}
		}

        /// <summary>
        /// The page elements
        /// </summary>
        private			List<SEOPageElement>	mobjElements		= null;
		private			List<Section>		mobjSections		= new List<Section>();

        /// <summary>
        /// Initializes a new (not saved yet) instance of the <see cref="SEOLobby"/> class.
        /// </summary>
        /// <param name="strFSOFile">The FSO file where the Item will be saved.</param>
        /// <param name="objSEOParent">The SEO parent to place item in the hierarchy</param>
        public SEOLobby(string strFSOFile, SEOFolder objSEOParent)
            : base(strFSOFile, objSEOParent)
        {
			Init();
        }
        
        /// <summary>
        /// Initializes a new instance of lobby, loaded from existing data .seo file
        /// </summary>
        /// <param name="strFSOItem">path to the data file the item loaded from</param>
        /// <param name="objElement">element contains data to load</param>
        /// <param name="objSEOParent">The SEO parent to place item in the hierarchy</param>
        public SEOLobby(string strFSOItem, XmlElement objElement, SEOFolder objSEOParent)
            : base(strFSOItem, objElement, objSEOParent)
        {
			Init();
        }

		private void Init()
		{
            this.Type = SEOItemType.Lobby;
		}

		public List<Section> Sections
		{
			get{ return mobjSections; }
			set { mobjSections = value; }
		}

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <value>The elements.</value>
        public List<SEOPageElement> Elements
        {
            get
            {
                if (mobjElements == null)
                {
                    mobjElements = new List<SEOPageElement>();
                }
                return mobjElements;
            }
            internal set
            {
                mobjElements = value;
            }
        }

        /// <summary>
        /// Loads the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Load(XmlElement objItemElement)
        {
            base.Load(objItemElement);
			this.Sections.Clear();
			XmlNodeList objSections = objItemElement.SelectNodes("Sections/Section");
			foreach (XmlElement objSectionNode in objSections)
			{
				Section objSection = new Section();
				objSection.Load(objSectionNode);
				this.Sections.Add(objSection);
			}

			// load lobby page elements
            mobjElements = SEOPageElement.GetElements(objItemElement, "Body");
        }

		/// <summary>
        /// Saves the specified SEO item element.
        /// </summary>
        /// <param name="objSEOItemElement">The SEO item element.</param>
        public override void Save(XmlElement objItemElement)
        {
            base.Save(objItemElement);

			// save lobby sections
            XmlElement objSectionsElement = objItemElement.OwnerDocument.CreateElement("Sections");
			foreach (Section objSection in this.Sections)
			{
				objSection.Save(objSectionsElement);
			}

			objItemElement.AppendChild(objSectionsElement);
			
            SEOPageElement.SetElements(objItemElement, "Body", this.Elements);
        }

        /// <summary>
        /// Validates the page:
        /// 1. That all PageElements correctly referencing to Items
        /// </summary>
        public override void Validate(SEOSearchItems objFoundItems, int intMaxResults)
        {
			base.Validate(objFoundItems, intMaxResults);

            bool blnNonValid = false;
            if (objFoundItems != null && objFoundItems.Count < intMaxResults)
            {
				string strReason = string.Empty;

                // That all Page Elements correctly referencing to Items
                foreach (SEOPageElement objElement in this.Elements)
                {
                    if (!objElement.IsValidLink())
                    {
                        blnNonValid |= true;
						strReason = string.Format("Incorrect link provided: '{0}'", objElement.Link);
                        break;
                    }
                }

				// add the page if not passed the validation
                if (blnNonValid)
                {
                    objFoundItems.Add(new SEOSearchItem(this,strReason));
                }
            }
        }

        /// <summary>
        /// Get all SEOItems that are referencing the <paramref name="objSEOItem"/> in terms
        /// of relationship consistensy. For example the consistency could be hit if
        /// <paramref name="objSEOItem"/> deleted and this item has a kind of link to it.
        /// </summary>
        public override void GetReferencesTo(SEOItem objSEOItem, List<SEOItem> objReferences)
        {
            foreach (SEOPageElement objElement in this.Elements)
            {
                if( objElement.GetLinkedItem() == objSEOItem )
                {
                    objReferences.Add(this);
                }
            }
        }

		/// <summary>
		/// Get elements associated with a section
		/// </summary>
		public List<SEOPageElement> GetSectionElements(string strSectionID)
		{
			List<SEOPageElement> result = new List<SEOPageElement>();

			foreach (SEOPageElement objElement in this.Elements)
			{
				if (String.Compare(objElement.SectionID, strSectionID, true) == 0)
				{
					result.Add(objElement);
				}
			}

			return result;
		}

		/// <summary>
		/// Get a section by ID
		/// </summary>
		/// <returns>
		/// A section object or NULL if not found;
		/// </returns>
		public SEOLobby.Section GetSection(string strSectionID)
		{
			SEOLobby.Section objSection = this.Sections.Find(delegate(SEOLobby.Section section)
			{
				return section.ID == strSectionID;
			});	
			return objSection;
		}

	}
}
