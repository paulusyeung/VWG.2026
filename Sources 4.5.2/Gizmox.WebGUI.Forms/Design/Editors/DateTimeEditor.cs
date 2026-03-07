using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Design
{
	
    /// <summary>
    /// This date time editor is a WebUITypeEditor suitable for visually editing DateTime objects.
    /// </summary>
    [Serializable()]
    public class DateTimeEditor : WebUITypeEditor
	{
		#region DateTimeEditorDropDown Class
	
		/// <summary>
		///
		/// </summary>

        [Serializable()]
    internal class DateTimeEditorDropDown : Form
		{

		
			#region Class Members
		
			private MonthCalendar	mobjMonthCalendar	= null;
		
			private DateTime		mobjDate;

			private bool mblnIsCompleted = false;
		
			#endregion Class Members
		
			#region C'Tor / D'Tor
		
			/// <summary>
			///
			/// </summary>

			internal DateTimeEditorDropDown()
			{

			
				// draw control
				InitializeComponent();
			
			}
		
		
			#endregion C'Tor / D'Tor
		
			#region Methods
		
			#region Initialize Component
		
			/// <summary>
			///
			/// </summary>
			private void InitializeComponent()
			{
			
				this.mobjMonthCalendar	= new MonthCalendar();
				this.SuspendLayout();
			
			
				//
				// mobjMonthCalendar
				//
				this.mobjMonthCalendar.Dock = DockStyle.Fill;
				
				this.mobjMonthCalendar.DateChanged+=new EventHandler(mobjMonthCalendar_ValueChanged);
			
			
				this.Controls.Add(this.mobjMonthCalendar);
			
			
				this.Size = new Size(175,154);
				this.ClientSize = new Size(175,154);
				this.Text = WGLabels.DatePicker;
				this.ResumeLayout(false);
			}
		
		
			#endregion Initialize Component
		
			public DateTime Value
			{
				get
				{
					return this.mobjDate;
				}
				set
				{
					this.mobjMonthCalendar.Value = this.mobjDate = value;
				}
			}

			public bool IsCompleted
			{
				get
				{
					return mblnIsCompleted;
				}
			}

			#region Events
		
			/// <summary>
			///
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void mobjMonthCalendar_ValueChanged(object sender, EventArgs e)
			{
				this.mobjDate = this.mobjMonthCalendar.Value;
				mblnIsCompleted = true;
				this.Close();
			}
		
		
			#endregion Events
		
			#endregion Methods
		}
	
		#endregion DateTimePickerPopup Class

		private WebUITypeEditorHandler mobjHandler = null;

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
			DateTimeEditorDropDown objDateTimeDialog = new DateTimeEditorDropDown();
			objDateTimeDialog.Value = (DateTime) this.GetEditorValueFromPropertyValue(objValue);
			objDateTimeDialog.Closed += new EventHandler(objDateTimeDialog_Closed);

			// Store handler
			mobjHandler = objHandler;

			// Show dialog
			IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
			if (objEditorService != null)
			{
				objEditorService.ShowDropDown(objDateTimeDialog);
			}
		}

		private void objDateTimeDialog_Closed(object sender, EventArgs e)
		{
			DateTimeEditorDropDown objDateTimeDialog = (DateTimeEditorDropDown)sender;
			if (objDateTimeDialog.IsCompleted)
			{
				object objValue = null;
				try
				{
					objValue = GetPropertyValueFromEditorValue(objDateTimeDialog.Value);
				}
				catch (Exception objException)
				{
					this.OnValueChangeError(objException);
					return;
				}

				mobjHandler(objValue);
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
	}


}
