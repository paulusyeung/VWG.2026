using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms.SEO;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class ElementEditForm : Form
    {
		/// <summary>
		/// Describes direction to display item regarding current item
		/// </summary>
		public enum Direction
		{
			First, Prev, Next, Last
		}
		public delegate SEOPageElement MoveToElementDelegate(Direction enmDirection);
		public event MoveToElementDelegate MoveToElement;


		private SEOLobby		mobjEditedItem		= null;
        private SEOPageElement	mobjEditedElement	= null;

		/// <summary>
		/// Gets or sets a value indicating whether the element deleted.
		/// </summary>
		private bool mblnDeleteElement = false;

		/// <summary>
		/// Gets or sets a value indicating the form opened or in state of adding new element.
		/// Default - false.
		/// </summary>
		private bool mblnNewElement;
        
		
		public ElementEditForm()
        {
            InitializeComponent();

            mobjEditedElement = new SEOPageElement();

            InititlizeCustom(null, null, null);
        }

        public ElementEditForm(	SEOLobby	objEditedItem, 
								SEOPageElement objEditedElement, 
								List<SEOLobby.Section> objSections)
        {
            InitializeComponent();
            
			InititlizeCustom(objEditedItem, objEditedElement, objSections);
        }

        private void InititlizeCustom(	SEOLobby	objEditedLobby, 
										SEOPageElement objEditedElement, 
										List<SEOLobby.Section> objSections)
        {
			this.NewElement = false;
            this.Text = "Set element properties";
			
			mobjCmbLink.Root = SEOSite.Root;

			// Set available sections
			mobjCmbSections.Items.Clear();
			mobjCmbSections.DisplayMember = "ID";
			mobjCmbSections.ValueMember = "ID";
			if (objSections != null)
			{
				mobjCmbSections.Items.AddRange(objSections);

				// select the first if only one section available
				if(mobjCmbSections.Items.Count == 1)
				{
					mobjCmbSections.SelectedIndex = 0;
				}
			}

			if (objEditedLobby != null)
			{
				mobjEditedItem = objEditedLobby;
				// Set available resources
				mobjResources.Items.Clear();
				mobjResources.DisplayMember = "Name";
				mobjResources.Items.AddRange(objEditedLobby.Resources);
				mobjResources.SelectedIndex = -1;
			}


			// Init navigation drop down menu
			// all available elements in all sections
			mobjBtnList.DropDownMenu = new ContextMenu();
			foreach (SEOPageElement element in mobjEditedItem.Elements)
			{
				MenuItem mnuItem = new MenuItem(element.Title);
				mnuItem.Tag = element;
				mnuItem.Click += MenuItemClicked;
				mobjBtnList.DropDownMenu.MenuItems.Add(mnuItem);
			}

			SetToUI(objEditedElement);
        }

		/// <summary>
		/// Load element and lobby section details to UI controls
		/// </summary>
		private void SetToUI(SEOPageElement objEditedElement)
		{					 
			if (objEditedElement != null && mobjEditedItem != null)
			{
				mobjEditedElement = objEditedElement;
				mobjTextBody.Text = objEditedElement.Body;
				mobjTextTitle.Text = objEditedElement.Title;

				// set selected section, according to ID				
				foreach (SEOLobby.Section section in mobjCmbSections.Items)
				{
					if (section.ID == objEditedElement.SectionID)
					{
						mobjCmbSections.SelectedIndex = mobjCmbSections.Items.IndexOf(section);
						break;
					}
				}

				// Set image selected
				mobjResources.SelectedIndex = -1;
				if (!String.IsNullOrEmpty(objEditedElement.Image))
				{
					// find selected Image among resources item
					foreach (SEOItemResource objResource in mobjEditedItem.Resources)
					{
						if (objResource.Name == objEditedElement.Image &&
						    mobjResources.Items.IndexOf(objResource) > -1) 
						{
								mobjResources.SelectedItem = objResource;
								break;
						}
					}
				}

				// Set Link properties
				if (objEditedElement.Styling.LinkType == SEOPageElement.Style.ItemLinkType.InnerItem)
				{
					mobjCmbLink.SelectedNode = objEditedElement.GetLinkedItem();
					mobjRadioTypeInner.Checked = true;
				}
				else if (objEditedElement.Styling.LinkType == SEOPageElement.Style.ItemLinkType.HyperLink)
				{
					mobjRadioTypeHyper.Checked = true;
					mobjTxtHyperLink.Text = objEditedElement.Link;
					mobjChkNewWindow.Checked = objEditedElement.Styling.OpenLinkInNewWindow;
				}
				else if (objEditedElement.Styling.LinkType == SEOPageElement.Style.ItemLinkType.NoLink)
				{
					mobjRadioTypeNoLink.Checked = true;
				}
				mobjRadioType_Click(null, null);

				// Set the text of CSS buttons bold if specified
				Highlight();
			}
		}

		/// <summary>
		/// Load values from UI to EditedElement
		/// </summary>
		private void GetFromUI()
		{
			mobjEditedElement.Body = mobjTextBody.Text;
			mobjEditedElement.Title = mobjTextTitle.Text;
            
			// Get Element Type
			mobjEditedElement.SectionID = ((SEOLobby.Section)mobjCmbSections.SelectedItem).ID;

			// Get Element Image
			mobjEditedElement.Image = mobjResources.SelectedIndex > -1 ?
					((SEOItemResource)mobjResources.SelectedItem).Name : "";

			// Get properties of the link
			if (mobjRadioTypeHyper.Checked)
			{
				this.EditedElement.Styling.LinkType = SEOPageElement.Style.ItemLinkType.HyperLink;
				this.EditedElement.Styling.OpenLinkInNewWindow = mobjChkNewWindow.Checked;
				mobjEditedElement.Link = mobjTxtHyperLink.Text;

			}
			else if(mobjRadioTypeInner.Checked)
			{
				// Set item to jump when clicked
				mobjEditedElement.Link = SEOPageElement.GetLinkFromItem(mobjCmbLink.SelectedNode);
				this.EditedElement.Styling.LinkType = SEOPageElement.Style.ItemLinkType.InnerItem;
			}
			else if (mobjRadioTypeNoLink.Checked)
			{
				this.EditedElement.Styling.LinkType = SEOPageElement.Style.ItemLinkType.NoLink;
				mobjEditedElement.Link = string.Empty;
			}		
		}

        // Cancel pressed
		private void mobjButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

		// OK pressed
        private void mobjButtonOk_Click(object sender, EventArgs e)
        {
			if (ValidateUI())
			{
			    this.DialogResult = DialogResult.OK;

				GetFromUI();

				this.Close();
			}
         }

		protected bool ValidateUI()
		{
			// validate section
			if (mobjCmbSections.SelectedIndex == -1 || mobjCmbSections.Items.Count == 0)
			{
				string message = string.Concat(
					"You have to associate the element to a section",
					Environment.NewLine,
					"Select a section from available or close the form with cancel and add new section (Press 'Sections' button)");
					
				MessageBox.Show(message,"Invalid section",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				// set error provider with image
				mobjError.SetError(mobjCmbSections, message);
				return false;
			}

			if (mobjRadioTypeInner.Checked && mobjCmbLink.SelectedNode == null)
			{
				string message = string.Concat(
					"You have to select an inner item to to link",
					Environment.NewLine,
					"Drop down the combo and select an Item.");
					
				MessageBox.Show(message,"Invalid section",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				// set error provider with image
				mobjError.SetError(mobjCmdNoLink, message);
				return false;
			}

			if (mobjRadioTypeHyper.Checked && mobjTxtHyperLink.Text.Trim() == string.Empty)
			{
				string message = string.Concat(
					"You have to specify a valid URL for the link",
					Environment.NewLine,
					"Type an URL in the textbox.");
					
				MessageBox.Show(message,"Invalid section",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				// set error provider with image
				mobjError.SetError(mobjEditorLink, message);
				return false;
			}


			return true;
		}

		// Set element without image - disassociate the image with element
		private void mobjCmdNoImage_Click(object sender, EventArgs e)
		{
			mobjResources.SelectedIndex = -1;
		}

		// Set element without link - disassociate the link with element
		private void mobjCmdNoLink_Click(object sender, EventArgs e)
		{
			mobjCmbLink.SelectedNode = null;
		}

		#region CSS changes edit/copy/paste/highlight
		/// <summary>
		/// Highligh the button in case the user have entered the custom css style in a field
		/// </summary>
		private void Highlight()
		{
			Font objHighlight = new Font(this.label1.Font, FontStyle.Bold);
			Font objRegular = new Font(this.label1.Font, FontStyle.Regular);

			mobjCmdContainerCss.Font = this.EditedElement.Styling.ContainerCSS.Length > 0 ? objHighlight : objRegular;
			mobjCmdBodyCss.Font = this.EditedElement.Styling.BodyCSS.Length > 0 ? objHighlight : objRegular;
			mobjCmdImageCss.Font = this.EditedElement.Styling.ImageCSS.Length > 0 ? objHighlight : objRegular;
			mobjCmdTitleCss.Font = this.EditedElement.Styling.TitleCSS.Length > 0 ? objHighlight : objRegular;
		}

		/// <summary>
		/// Open a editor for custom CSS and enter the value to the element's property
		/// </summary>
		private void mobjCmdCss_Click(object sender, EventArgs e)
		{
			StringEditorForm editor = new StringEditorForm();
			if (sender == mobjCmdContainerCss)
			{
				editor.EditedText = this.EditedElement.Styling.ContainerCSS;
			}
			else if (sender == mobjCmdBodyCss)
			{
				editor.EditedText = this.EditedElement.Styling.BodyCSS;
			}
			else if (sender == mobjCmdImageCss)
			{
				editor.EditedText = this.EditedElement.Styling.ImageCSS;
			}
			else if (sender == mobjCmdTitleCss)
			{
				editor.EditedText = this.EditedElement.Styling.TitleCSS;
			}
			editor.ShowPopup(this, (Button)sender, DialogAlignment.Below);
			editor.FormClosed += (Form.FormClosedEventHandler)delegate(object form, FormClosedEventArgs closeevent)
			{
				if (((Form)form).DialogResult == DialogResult.OK)
				{
					if (sender == mobjCmdContainerCss)
					{
						this.EditedElement.Styling.ContainerCSS = editor.EditedText;
					}
					else if (sender == mobjCmdBodyCss)
					{
						this.EditedElement.Styling.BodyCSS = editor.EditedText;
					}
					else if (sender == mobjCmdImageCss)
					{
						this.EditedElement.Styling.ImageCSS = editor.EditedText;
					}
					else if (sender == mobjCmdTitleCss)
					{
						this.EditedElement.Styling.TitleCSS = editor.EditedText;
					}

					Highlight();
				}
				editor.Dispose();
			};
		}

		// Clear extended CSS formatting
		private void mobjCmdClearCss_Click(object sender, EventArgs e)
		{
			this.EditedElement.Styling.ContainerCSS =
			this.EditedElement.Styling.BodyCSS =
			this.EditedElement.Styling.ImageCSS =
			this.EditedElement.Styling.SeparatorCSS =
			this.EditedElement.Styling.TitleCSS = string.Empty;

			Highlight();
		}

		/// <summary>
		/// Static variable to hold CSS styling of edited element and copy/paste from/to other elements
		/// </summary>
		private static SEOPageElement.Style mobjClipboardCSS = null;

		public static SEOPageElement.Style ClipboardCSS
		{
			get { return mobjClipboardCSS; }
			set { mobjClipboardCSS = value; }
		}

		/// <summary>
		/// Handles clicks on Copy CSS/ Paste CSS
		/// </summary>
		private void CopyPasteCSS_Click(object sender, EventArgs e)
		{
			// copy style for further usege
			if (sender == mobjBtnCopyCSS)
			{
				if (ClipboardCSS == null) ClipboardCSS = new SEOPageElement.Style();
				ClipboardCSS.ContainerCSS = this.EditedElement.Styling.ContainerCSS;
				ClipboardCSS.BodyCSS = this.EditedElement.Styling.BodyCSS;
				ClipboardCSS.ImageCSS = this.EditedElement.Styling.ImageCSS;
				ClipboardCSS.SeparatorCSS = this.EditedElement.Styling.SeparatorCSS;
				ClipboardCSS.TitleCSS = this.EditedElement.Styling.TitleCSS;
			}
			// paste style to the element
			else if (sender == mobjBtnPasteCSS && ClipboardCSS != null)
			{
				this.EditedElement.Styling.ContainerCSS = ClipboardCSS.ContainerCSS;
				this.EditedElement.Styling.BodyCSS = ClipboardCSS.BodyCSS;
				this.EditedElement.Styling.ImageCSS = ClipboardCSS.ImageCSS;
				this.EditedElement.Styling.SeparatorCSS = ClipboardCSS.SeparatorCSS;
				this.EditedElement.Styling.TitleCSS = ClipboardCSS.TitleCSS;
				Highlight();
			}
		}

		#endregion

		// Handle click of Radio buttons for Type of link
		private void mobjRadioType_Click(object sender, EventArgs e)
		{
			// if nolink selected
			if (mobjRadioTypeNoLink.Checked)
			{
				// for inner item
				mobjCmbLink.Enabled = false;
				mobjCmdNoLink.Enabled = mobjCmbLink.Enabled;
				// for hyper link
				mobjTxtHyperLink.Enabled = false;
				mobjChkNewWindow.Enabled = mobjTxtHyperLink.Enabled;
			}
			else
			{
				// the link should be specified
				// for inner item
				mobjCmbLink.Enabled = mobjRadioTypeInner.Checked;
				mobjCmdNoLink.Enabled = mobjCmbLink.Enabled;
				// for hyper link
				mobjTxtHyperLink.Enabled = !mobjCmbLink.Enabled;
				mobjChkNewWindow.Enabled = mobjTxtHyperLink.Enabled;
			}
		}

		// Opening resizeble window for comfortable editing of the text
		private void mobjEditorText_Click(object sender, EventArgs e)
		{
			StringEditorForm editor = new StringEditorForm();
			editor.Size =  new Size(670,380);
			editor.StartPosition = FormStartPosition.CenterScreen;

			TextBox objTextBox = null;

			if (sender == mobjEditorTitle)
			{
				objTextBox = mobjTextTitle;
			}
			else if (sender == mobjEditorText)
			{
				objTextBox = mobjTextBody;
			}
			else if (sender == mobjEditorLink)
			{
				objTextBox = mobjTxtHyperLink;
			}

			if (objTextBox != null)
			{
				editor.EditedText = objTextBox.Text;
				editor.FormClosed += (Form.FormClosedEventHandler)delegate(object form, FormClosedEventArgs closeevent)
				{
					if (((Form)form).DialogResult == DialogResult.OK)
					{
						objTextBox.Text = editor.EditedText;
					}
				};
				editor.ShowDialog();
			}
		}

		// Handle navigation to prev/next/last/first element
		private void MoveToElement_Click(object sender, EventArgs e)
		{
			Direction enmDirect = Direction.First;
			if (sender == mobjBtnFirst) enmDirect = Direction.First;
			else if (sender == mobjBtnPrevious) enmDirect = Direction.Prev;
			else if (sender == mobjBtnNext) enmDirect = Direction.Next;
			else if (sender == mobjBtnLast) enmDirect = Direction.Last;

			if (ValidateUI())
			{
				GetFromUI();

				SEOPageElement item = MoveToElement != null ? MoveToElement(enmDirect) : MoveToElementInternal(enmDirect);

				if (item != null)
				{
					mobjEditedElement = item;
					SetToUI(item);
				}
			}
		}

		// Support movement between elements - internally
		private SEOPageElement MoveToElementInternal(Direction enmDirection)
		{
			List<SEOPageElement> Elements = mobjEditedItem.Elements;
			int index = Elements.IndexOf(this.EditedElement);
			SEOPageElement element = null;
			if (index > -1)
			{
				switch (enmDirection)
				{
					case ElementEditForm.Direction.First:
						if (Elements.Count > 0) element = (SEOPageElement)Elements[0];
						break;
					case ElementEditForm.Direction.Prev:
						if (index > 1) element = (SEOPageElement)Elements[index - 1];
						break;
					case ElementEditForm.Direction.Next:
						if (index < Elements.Count - 1)
							element = (SEOPageElement)Elements[index + 1];
						break;
					case ElementEditForm.Direction.Last:
						if (Elements.Count > 0)
							element = (SEOPageElement)Elements[Elements.Count - 1];
						break;
				}
			}
			return element;
		}

		// Show drop down menu with elements
		private void GetElements_Click(object sender, EventArgs e)
		{
			List<SEOPageElement> elements = null;

			// With according to the selected section
			if(mobjCmbSections.SelectedIndex >-1)
			{
				elements = mobjEditedItem.GetSectionElements(((SEOLobby.Section)mobjCmbSections.SelectedItem).ID);

				// attach event handler and show menu
				mobjMenuElements.MenuItems.Clear();
				foreach (SEOPageElement element in elements)
				{
					MenuItem mnuItem = new MenuItem(element.Title);
					mnuItem.Tag = element;
					mnuItem.Click += MenuItemClicked;
					mobjMenuElements.MenuItems.Add(mnuItem);
				}

				// show menu under the pressed button
				mobjMenuElements.Show((Component)sender, new Point(0, ((Control)sender).Size.Height));
			}
		}

		// Navigate to an element clicked in the displayed menu
		private void MenuItemClicked(object menuclicked, EventArgs e)
		{
			if (ValidateUI())
			{
				GetFromUI();
				SEOPageElement item = ((MenuItem)menuclicked).Tag as SEOPageElement;
				if (item != null)
				{
					mobjEditedElement = item;
					SetToUI(item);
				}
			}
		}

		// Add a new or delete element
		private void CmdNewDeleteElement_Click(object sender, EventArgs e)
		{
			if (!this.NewElement)
			{
				if (sender == mobjBtnDelete)
				{
					MessageBox.Show("Are you sure to delete the element?","",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, delegate(object box, EventArgs eventarg)
					{
						if (((Form)box).DialogResult == DialogResult.OK)
						{
							this.DeleteElement = true;
							this.DialogResult = DialogResult.OK;
							this.Close();
						}
					});
				}
				else if(sender == mobjBtnNew)
				{
					if (ValidateUI())
					{
						GetFromUI();

						// block navigation to other elements
						this.NewElement = true;

						SEOPageElement item = new SEOPageElement();
						mobjEditedElement = item;
						SetToUI(item);
					}
				}
			}
		}

        public SEOPageElement EditedElement
        {
            get { return mobjEditedElement; }
        }

		/// <summary>
		/// Gets or sets a value indicating the form opened or in state of adding new element.
		/// Default - false.
		/// </summary>
		public bool NewElement
		{
			get { return mblnNewElement; }
			set { 
				mblnNewElement = value; 

				// disable navigation
				mobjBtnFirst.Enabled = 
				mobjBtnLast.Enabled = 
				mobjBtnNext.Enabled =
				mobjBtnPrevious.Enabled =
				
				mobjBtnList.Enabled =
				mobjCmdGetSectionElements.Enabled = 
				
				mobjBtnNew.Enabled = 
				mobjBtnDelete.Enabled = !value;
			}
		}		
		
		/// <summary>
		/// Gets or sets a value indicating whether the element deleted.
		/// </summary>
		public bool DeleteElement
		{
			get { return mblnDeleteElement; }
			set { mblnDeleteElement = value; }
		}

    }
}
