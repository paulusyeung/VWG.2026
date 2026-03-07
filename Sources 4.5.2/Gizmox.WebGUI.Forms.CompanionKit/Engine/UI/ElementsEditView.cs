using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;
using System.Collections;


namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class ElementsEditView : UserControl
    {
		private SEOLobby				mobjSEOItem = null;
		
		// deep cloned colleciton of Sections, taken from Lobby Item
		private List<SEOLobby.Section>	mobjSections = null;

		// deep cloned from edited item elements
		private List<SEOPageElement>	mobjElements = null;

		public ElementsEditView()
        {
            InitializeComponent();
        }
		
		/// <summary>
		/// Create new element
		/// </summary>
        private void OnButtonNewClick(object sender, EventArgs e)
        {
            ElementEditForm objNewElementForm = new ElementEditForm(this.EditedItem, new SEOPageElement(), this.EditedSections);
			
			objNewElementForm.NewElement = true;
            objNewElementForm.FormClosed += 
				delegate (object formsender, FormClosedEventArgs closeevent)
				{
					if (objNewElementForm.DialogResult == DialogResult.OK)
					{
						SEOPageElement objNewElement = objNewElementForm.EditedElement;
						ListViewItem objItem = CreateItem(objNewElement);

						mobjElementsList.Items.Add(objItem);
						mobjElements.Add(objNewElement);

						ReGroup();
						objItem.Selected = true;
						objItem.EnsureVisible();
					}
				};
			objNewElementForm.ShowDialog();
        }

		/// <summary>
		/// Edit a selected element
		/// </summary>
        private void OnButtonEditClick(object sender, EventArgs e)
        {
            if (mobjElementsList.SelectedItem != null)
            {
                ElementEditForm objEditElementForm = 
					new ElementEditForm(this.EditedItem, 
						(SEOPageElement)mobjElementsList.SelectedItem.Tag, this.EditedSections);

				objEditElementForm.NewElement = false;
				objEditElementForm.FormClosed += delegate(object formsender, FormClosedEventArgs closeevent)
				{
					if (objEditElementForm.DialogResult == DialogResult.OK)
					{
						// if during editing new element was added, add and save it
						if (objEditElementForm.NewElement)
						{
							mobjElements.Add(objEditElementForm.EditedElement);
						}
						else if (objEditElementForm.DeleteElement)
						{
							mobjElements.Remove(objEditElementForm.EditedElement);
						}

						// it's possible that user moved and changed other item
						// so we have refresh listview items and ensure visibility of last edited item
						Bind();
						foreach (ListViewItem objItem in mobjElementsList.Items)
							if (objEditElementForm.EditedElement == objItem.Tag)
							{
								objItem.EnsureVisible();
								break;
							}
					}
				};
                
				objEditElementForm.MoveToElement += delegate(ElementEditForm.Direction enmDirection)
				{
					int index = -1;
					foreach (ListViewItem objItem in mobjElementsList.Items)
						if (objEditElementForm.EditedElement == objItem.Tag)
						{
							index = objItem.Index;
							break;
						}
					
					SEOPageElement item = null;
					if (index > -1)
					{
						switch (enmDirection)
						{
							case ElementEditForm.Direction.First:
								if (mobjElementsList.Items.Count >0)
									item = (SEOPageElement)mobjElementsList.Items[0].Tag;
								break;
							case ElementEditForm.Direction.Prev:
								if (index >1)
									item = (SEOPageElement)mobjElementsList.Items[index-1].Tag;
								break;
							case ElementEditForm.Direction.Next:
								if (index < mobjElementsList.Items.Count-1)
									item = (SEOPageElement)mobjElementsList.Items[index+1].Tag;
								break;
							case ElementEditForm.Direction.Last:
								if (mobjElementsList.Items.Count >0)
									item = (SEOPageElement)mobjElementsList.Items[mobjElementsList.Items.Count-1].Tag;
								break;
						}
					}
					return item;
				};

				objEditElementForm.ShowDialog();
            }
        }

		/// <summary>
		/// Checks where the Link is valid: references a SEOItem
		/// </summary>
		private string LinkIntegrityFeedback(SEOPageElement objElement)
		{
			if (objElement.Styling.LinkType == SEOPageElement.Style.ItemLinkType.NoLink)
			{
				return "[ None ]";
			}
			else if( objElement.IsValidLink() )
			{
				return "ok";
			}
			else
			{
				return "[ Error ]";
			}
		}

		/// <summary>
		/// Delete selected elements
		/// </summary>
        private void OnButtonDeleteClick(object sender, EventArgs e)
        {
			// get index of first selected items
			int intIndex = -1;
			if (mobjElementsList.SelectedItem != null)
			{
				intIndex = mobjElementsList.SelectedItem.Index;
			}

			foreach (ListViewItem item in mobjElementsList.SelectedItems)
			{
				SEOPageElement element = item.Tag as SEOPageElement;
				if (element != null)
				{
					mobjElements.Remove(element);
				}

				mobjElementsList.Items.Remove(item);
			}

			// select the item before deleted
			if (mobjElementsList.Items.Count > 0 && intIndex > -1)
			{
				mobjElementsList.SelectedIndex = (intIndex - 1 >= 0 ? intIndex - 1 : 0);
			}
        }

		// Relocate selected Items
		private void OnButtonUpDown(object sender, EventArgs e)
		{
			ArrayList colSelected = new ArrayList(mobjElementsList.SelectedItems);

			if (sender == mobjCmdUp)
			{
				// reorder elements/listview items - UP
				foreach (ListViewItem item in colSelected)
				{
					SEOPageElement element = item.Tag as SEOPageElement;
					if (element != null)
					{
						int Index = mobjElements.IndexOf(element);

						if (Index > 0 && mobjElements.Count > 1)
						{
							mobjElements.Remove(element);
							mobjElements.Insert(Index - 1, element);

							mobjElementsList.Items.Remove(item);
							mobjElementsList.Items.Insert(Index - 1, item);
							item.Selected = true;
						}
					}
				}
			}
			else if (sender == mobjCmdDown)
			{
				// reorder elements/listview items - Down
				for (int i = colSelected.Count - 1; i >= 0; i--)
				{
					ListViewItem item = (ListViewItem)colSelected[i];
					SEOPageElement element = item.Tag as SEOPageElement;
					if (element != null)
					{
						int Index = mobjElements.IndexOf(element);
						if (Index < mobjElements.Count - 1 && mobjElements.Count > 1)
						{
							mobjElements.Remove(element);
							mobjElements.Insert(Index + 1, element);

							mobjElementsList.Items.Remove(item);
							mobjElementsList.Items.Insert(Index + 1, item);
							item.Selected = true;
						}
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets the item to edit elements.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SEOLobby EditedItem
        {
            get
            {
                return mobjSEOItem;
            }
            set
            {
                if (value != null)
                {
					mobjSEOItem = value;

					// clone sections for further editing, without changing original objects
					List<SEOLobby.Section> sections = new List<SEOLobby.Section>();
					foreach (SEOLobby.Section section in mobjSEOItem.Sections)
						sections.Add((SEOLobby.Section)section.Clone());
					
					this.EditedSections = sections;
					
					// should follow setting of section !
					this.Elements = mobjSEOItem.Elements;

					// the generation option available only for a SEOFolder
					mobjGenerate.Visible = (value.Type == SEOItemType.Folder);
                }
                else
                {
					this.Elements = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the item to edit elements.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected List<SEOLobby.Section> EditedSections
        {
            get
            {
                return mobjSections;
            }
            set
            {
                if (value != null)
                {
					mobjSections = value;
                }
                else
                {
					throw new ArgumentException("The sections collection cannot be null");
                }
            }
        }

        /// <summary>
        /// Gets or sets the elements.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected List<SEOPageElement> Elements
        {
            get
			{ 
				return mobjElements; 
			}
            set
            {
                if (value != null)
                {
                    mobjElements = SEOPageElement.Clone(value);
                }
                else
                {
                    mobjElements = new List<SEOPageElement>();
                }
                Bind();
            }
        }

        /// <summary>
        /// Binds this instance - loads elements to listview
        /// </summary>
        private void Bind()
        {
            mobjElementsList.Items.Clear();

            if (mobjElements != null)
            {
                foreach (SEOPageElement objElement in mobjElements)
                {
                    ListViewItem objItem = CreateItem(objElement);
                    mobjElementsList.Items.Add(objItem);
                }
				ReGroup();
            }
        }

		/// <summary>
		/// Re-creates groups from sections and re-associates elements to it's groups
		/// </summary>
		private void ReGroup()
		{
			Dictionary<string, ListViewGroup> relation = new Dictionary<string,ListViewGroup>();

			mobjElementsList.Groups.Clear();
			
			if (this.EditedSections != null)
			{
				foreach (SEOLobby.Section section in this.EditedSections)
				{
					ListViewGroup objGroup = new ListViewGroup(
						string.Format("{0}, {1}", section.ID, section.StyleName),
						HorizontalAlignment.Center);
					objGroup.Name = objGroup.Header;
					
					// add a group
					mobjElementsList.Groups.Add(objGroup);
					
					relation[section.ID] = objGroup;
				}
				foreach (ListViewItem objItem in mobjElementsList.Items)
				{
					SEOPageElement element = (SEOPageElement)objItem.Tag;
					if (relation.ContainsKey(element.SectionID))
					{
						ListViewGroup objGroup = relation[element.SectionID];
						objItem.Group = objGroup;
					}
				}
			}
		}

        private ListViewItem CreateItem(SEOPageElement objElement)
        {
            ListViewItem objItem = new ListViewItem(objElement.Title);
            objItem.SubItems.Add(objElement.Image);
            objItem.SubItems.Add(LinkIntegrityFeedback(objElement));
			objItem.Tag = objElement;
            return objItem;
        }

		/// <summary>
		/// Open a form to edit lobby sections
		/// Actually we will edit the cloned sections objects
		/// </summary>
		private void mobjCmdLobbySections_Click(object sender, EventArgs e)
		{
			LobbySections objEditForm = new LobbySections();

			objEditForm.EditedSections = this.EditedSections;

			objEditForm.ConfirmDelete += new LobbySections.ConfirmDeleteDelegate(objEditForm_ConfirmDelete);

			// handle completion of section editing
			objEditForm.FormClosed += delegate(object form, FormClosedEventArgs closeevent)
			{
				// the user confirmed the changes
				if (((Form)form).DialogResult == DialogResult.OK)
				{
					// clear the collection
					this.EditedSections.Clear();

					// replaced with updated section objects
					foreach (SEOLobby.Section section in objEditForm.EditedSections)
						this.EditedSections.Add(section);

					ReGroup();
				}
			};

			objEditForm.ShowDialog();
		}

		/// <summary>
		/// Check where the section has associated elements
		/// </summary>
		private bool objEditForm_ConfirmDelete(SEOLobby.Section objSection)
		{
			bool found = false;
            foreach (ListViewItem objItem in mobjElementsList.Items)
            {
				if (((SEOPageElement)objItem.Tag).SectionID == objSection.ID)
				{
					found =true;
					break;
				}
            }
			return !found;
		}

		public virtual void OnSave()
		{
			this.EditedItem.Elements = this.Elements;
			this.EditedItem.Sections = this.EditedSections;
		}

		/// <summary>
		/// Handle options of Items generation
		/// </summary>
		private void OnGenerate_Click(object sender, EventArgs e)
		{
			SEOFolder objFolder = this.EditedItem as SEOFolder;
			if (objFolder != null)
			{
				// Take all non-folder items recursively or non-recursively
				IEnumerable<SEOItem> objItems = null;
				if (sender == mobjMenuFolderOnly)
					objItems = objFolder.PlainItems;
				else if (sender == mobjMenuRecursively)
					objItems = objFolder.PlainItemsRecursively;

				if (objItems != null)
				{
					// Add a section for generated items
					SEOLobby.Section objSection = new SEOLobby.Section();
					objSection.ID = SEOUtils.GetUniqueSectionID(this.EditedSections);
					objSection.StyleName = "Demo";
					this.EditedSections.Add(objSection);

					// Generate elements with link to Item
					foreach (SEOItem objItem in objItems)
					{
						SEOPageElement element = new SEOPageElement();
						element.Title = objItem.DisplayName;
						element.Body = objItem.Description;
						element.Link = objItem.GetInnerLink();
						element.Styling.LinkType = SEOPageElement.Style.ItemLinkType.InnerItem;
						element.SectionID = objSection.ID;

						mobjElements.Add(element);
					}

					// Refresh the view
					Bind();
				}
			}
		}

	}
}
