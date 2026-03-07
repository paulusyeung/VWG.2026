using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Reflection;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Design
{
    
    /// <summary>
    /// Provides a user interface for specifying a Dock property.
    /// </summary>
    [Serializable()]
    public class DockEditor : WebUITypeEditor
    {
		#region DockEditorDropDown Class


        [Serializable()]
        class DockEditorDropDown : Form
		{

			private DockButton mobjButtonNone;
			private DockButton mobjButtonTop;
			private DockButton mobjButtonBottom;
			private DockButton mobjButtonLeft;
			private DockButton mobjButtonRight;
			private DockButton mobjButtonFill;

			private DockStyle menmValue = DockStyle.None;

			private bool mblnIsCompleted = false;

			public DockEditorDropDown()
			{
				InitializeComponent();

			}

			#region Designer generated code
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
			private void InitializeComponent()
			{
				this.mobjButtonNone = new DockButton();
				this.mobjButtonTop = new DockButton();
				this.mobjButtonBottom = new DockButton();
				this.mobjButtonLeft = new DockButton();
				this.mobjButtonRight = new DockButton();
				this.mobjButtonFill = new DockButton();
				this.SuspendLayout();
				// 
				// mobjButtonNone
				// 
				this.mobjButtonNone.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
				this.mobjButtonNone.Location = new System.Drawing.Point(0, 103);
				this.mobjButtonNone.Name = "mobjButtonNone";
				this.mobjButtonNone.Size = new System.Drawing.Size(144, 23);
				this.mobjButtonNone.TabIndex = 0;
				this.mobjButtonNone.Text = "None";
				this.mobjButtonNone.Click += new System.EventHandler(this.mobjButtonNone_Click);
				// 
				// mobjButtonTop
				// 
				this.mobjButtonTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
				this.mobjButtonTop.Location = new System.Drawing.Point(0, 0);
				this.mobjButtonTop.Name = "mobjButtonTop";
				this.mobjButtonTop.Size = new System.Drawing.Size(144, 20);
				this.mobjButtonTop.TabIndex = 1;
				this.mobjButtonTop.Click += new System.EventHandler(this.mobjButtonTop_Click);
				// 
				// mobjButtonBottom
				// 
				this.mobjButtonBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
				this.mobjButtonBottom.Location = new System.Drawing.Point(0, 83);
				this.mobjButtonBottom.Name = "mobjButtonBottom";
				this.mobjButtonBottom.Size = new System.Drawing.Size(144, 20);
				this.mobjButtonBottom.TabIndex = 2;
				this.mobjButtonBottom.Click += new System.EventHandler(this.mobjButtonBottom_Click);
				// 
				// mobjButtonLeft
				// 
				this.mobjButtonLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
				this.mobjButtonLeft.Location = new System.Drawing.Point(0, 20);
				this.mobjButtonLeft.Name = "mobjButtonLeft";
				this.mobjButtonLeft.Size = new System.Drawing.Size(20, 63);
				this.mobjButtonLeft.TabIndex = 3;
				this.mobjButtonLeft.Click += new System.EventHandler(this.mobjButtonLeft_Click);
				// 
				// mobjButtonRight
				// 
				this.mobjButtonRight.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
				this.mobjButtonRight.Location = new System.Drawing.Point(124, 20);
				this.mobjButtonRight.Name = "mobjButtonRight";
				this.mobjButtonRight.Size = new System.Drawing.Size(20, 63);
				this.mobjButtonRight.TabIndex = 4;
				this.mobjButtonRight.Click += new System.EventHandler(this.mobjButtonRight_Click);
				// 
				// mobjButtonFill
				// 
				this.mobjButtonFill.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
				this.mobjButtonFill.Location = new System.Drawing.Point(20, 20);
				this.mobjButtonFill.Name = "mobjButtonFill";
				this.mobjButtonFill.Size = new System.Drawing.Size(104, 63);
				this.mobjButtonFill.TabIndex = 5;
				this.mobjButtonFill.Click += new System.EventHandler(this.mobjButtonFill_Click);
				// 
				// Form3
				// 				
				this.ClientSize = new System.Drawing.Size(144, 126);
				this.Controls.Add(this.mobjButtonFill);
				this.Controls.Add(this.mobjButtonRight);
				this.Controls.Add(this.mobjButtonLeft);
				this.Controls.Add(this.mobjButtonBottom);
				this.Controls.Add(this.mobjButtonTop);
				this.Controls.Add(this.mobjButtonNone);
				this.Name = "Form3";
				this.Text = "Form3";
				this.ResumeLayout(false);

			}

			private void mobjButtonTop_Click(object sender, System.EventArgs e)
			{
				this.menmValue = DockStyle.Top;
				this.mblnIsCompleted = true;
				this.Close();
			}

			private void mobjButtonRight_Click(object sender, System.EventArgs e)
			{
				this.menmValue = DockStyle.Right;
				this.mblnIsCompleted = true;
				this.Close();
			}

			private void mobjButtonFill_Click(object sender, System.EventArgs e)
			{
				this.menmValue = DockStyle.Fill;
				this.mblnIsCompleted = true;
				this.Close();
			}

			private void mobjButtonLeft_Click(object sender, System.EventArgs e)
			{
				this.menmValue = DockStyle.Left;
				this.mblnIsCompleted = true;
				this.Close();
			}

			private void mobjButtonBottom_Click(object sender, System.EventArgs e)
			{
				this.menmValue = DockStyle.Bottom;
				this.mblnIsCompleted = true;
				this.Close();
			}

			private void mobjButtonNone_Click(object sender, System.EventArgs e)
			{
				this.menmValue = DockStyle.None;
				this.mblnIsCompleted = true;
				this.Close();
			}

			#endregion

            /// <summary>
            /// Gets/Sets the controls docking style
            /// </summary>
            /// <value></value>
            new public DockStyle Dock
			{
				get
				{
					return menmValue;
				}
				set
				{
					menmValue = value;
				}
			}


			
			public bool IsCompleted
			{
				get
				{
					return this.mblnIsCompleted;
				}
			}
		}

		#endregion

		#region Class Members

        private WebUITypeEditorHandler mobjHandler = null;

        private DockStyle menmPropertyValue = DockStyle.None;

		#endregion Class Members

		#region C'Tor

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            // Create font dialog
            DockEditorDropDown objDockDialog = new DockEditorDropDown();
            objDockDialog.Dock =  (DockStyle)GetEditorValueFromPropertyValue(objValue);
            objDockDialog.Closed += new EventHandler(objDockDialog_Closed);

			// Store the property value
			menmPropertyValue = objDockDialog.Dock;

            // Store handler
            mobjHandler = objHandler;

            // Show dialog
            IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
            if (objEditorService != null)
            {
                objEditorService.ShowDropDown(objDockDialog);
            }
        }

		#endregion C'Tor

        private void objDockDialog_Closed(object sender, EventArgs e)
        {
            DockEditorDropDown objDockDialog = (DockEditorDropDown)sender;
            if (objDockDialog.IsCompleted)
            {
				if (mobjHandler != null)
				{
					object objValue = null;
					try
					{
						objValue = GetPropertyValueFromEditorValue(objDockDialog.Dock);
					}
					catch (Exception objException)
					{
						this.OnValueChangeError(objException);
						return;
					}

					mobjHandler(objValue);
				}
            }
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <value>The property value.</value>
		protected DockStyle PropertyValue
		{
			get
			{
				return this.menmPropertyValue;
			}
		}

    }


}
