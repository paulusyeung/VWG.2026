using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using  Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class StandardValuesEditor : WebUITypeEditor
	{
		private WebUITypeEditorHandler mobjHandler = null;

		private TypeConverter mobjTypeConvertor = null;


        [Serializable()]
        private class ListBoxForm : Form
		{

			private bool mblnIsCompleted = false;
			private ListBox mobjListBox = null;

            [ToolboxItem(false), Serializable()]
			
	        private class TempListBox : ListBox
			{
				protected override bool IsDelayedDrawing
				{
					get
					{
						return false;
					}
				}

			}
            public ListBoxForm(ICollection objCollection)
			{
				mobjListBox = new TempListBox();
				mobjListBox.Dock = DockStyle.Fill;
				mobjListBox.BorderStyle = BorderStyle.FixedSingle;
				mobjListBox.SelectionMode = SelectionMode.One;
				mobjListBox.Items.AddRange(objCollection);
				mobjListBox.SelectedIndexChanged+=new EventHandler(objListBox_SelectedIndexChanged); 
				this.SuspendLayout();
				this.BackColor = Color.White;
                
                // Listbox skin border
                int intVerticalBorder = 2;

                //.ListBox-Container
                int intListBoxContainerBorder = 2;

                int intPopupFormBorder = 0;

                FormSkin objFormSkin = this.Skin as FormSkin;
                if(objFormSkin!=null)
                {
                    if (objFormSkin.CenterPopupWindowStyle.BorderStyle != Forms.BorderStyle.None)
                    {
                        intPopupFormBorder = objFormSkin.CenterPopupWindowStyle.BorderWidth.Bottom + objFormSkin.CenterPopupWindowStyle.BorderWidth.Top;
                    }
                }

                // Get listbox skin
                ListBoxSkin objSkin = mobjListBox.Skin as ListBoxSkin;
                if (objSkin != null)
                {
                    // Get skin border width
                    intVerticalBorder = objSkin.BorderWidth.Top + objSkin.BorderWidth.Bottom;
                }

                this.Height = mobjListBox.GetPreferdItemHeight() * (objCollection.Count > 15 ? 15 : objCollection.Count) + intVerticalBorder + intListBoxContainerBorder + intPopupFormBorder;
				this.Width = 130;
				this.Controls.Add(mobjListBox);
				this.ResumeLayout(true);
			}

			private void objListBox_SelectedIndexChanged(object sender,EventArgs e)
			{
				mblnIsCompleted = true;
				this.Close();
			}

			public bool IsCompleted
			{
				get
				{
					return this.mblnIsCompleted;
				}
			}

			public object Value 
			{
				get
				{
					return this.mobjListBox.SelectedItem;
				}
			}
		}

        public StandardValuesEditor()
        {
        }

		public StandardValuesEditor(TypeConverter objTypeConvertor)
		{
			mobjTypeConvertor = objTypeConvertor;
		}

        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
		{
            ArrayList objList = GetListValues(objContext);

            if (objList.Count > 0)
            {
                ListBoxForm objListBoxForm = new ListBoxForm(objList);
                objListBoxForm.Closed += new EventHandler(objListBoxForm_Closed);
                // Store handler
                mobjHandler = objHandler;

                // Show dialog
                IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
                if (objEditorService != null)
                {
                    objEditorService.ShowDropDown(objListBoxForm);
                }
            }
		}

        protected virtual ArrayList GetListValues(ITypeDescriptorContext objContext)
        {
            TypeConverter.StandardValuesCollection objStandardValuesCollection = mobjTypeConvertor.GetStandardValues(objContext);
            ArrayList objList = new ArrayList();
            foreach (object objValue2 in objStandardValuesCollection)
            {
                if (objValue2 != null)
                {
                    objList.Add(objValue2);
                }
            }
            return objList;
        }

		private void objListBoxForm_Closed(object sender, EventArgs e)
		{
			ListBoxForm objListBoxForm = (ListBoxForm)sender;
			if (objListBoxForm.IsCompleted)
			{
				if (mobjHandler != null)
				{
					mobjHandler(this.GetPropertyValueFromEditorValue(objListBoxForm.Value));
				}
			}
		}

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}
}
