#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// 
	///
	/// </summary>
	[Serializable]
	public class DataGridViewCustomFilterDialog : Form
	{
		[Serializable]
		private class FilterOperatorItem
		{
			private string mstrText = string.Empty;

			private FilterComparisonOperator menmFilterComparisionOperator;

			/// 
			/// Gets the text.
			/// </summary>
			public string Text => mstrText;

			/// 
			/// Gets the operator.
			/// </summary>
			public FilterComparisonOperator Operator => menmFilterComparisionOperator;

			public FilterOperatorItem(FilterComparisonOperator enmFilterComparisionOperator, string strText)
			{
				menmFilterComparisionOperator = enmFilterComparisionOperator;
				mstrText = strText;
			}

			/// 
			/// Returns a <see cref="T:System.String" /> that represents this instance.
			/// </summary>
			/// 
			/// A <see cref="T:System.String" /> that represents this instance.
			/// </returns>
			public override string ToString()
			{
				return mstrText;
			}
		}

		private Label mobjLabelFilterMessage;

		private ComboBox mobjComboBoxOperatorA;

		private DataGridViewFilterComboBoxBase mobjComboBoxValueA;

		private RadioButton mobjRadioButtonAnd;

		private RadioButton mobjRadioButtonOr;

		private ComboBox mobjComboBoxOperatorB;

		private DataGridViewFilterComboBoxBase mobjComboBoxValueB;

		private Button mobjButtonCancel;

		private Button mobjButtonOK;

		private DataGridViewColumn mobjDataGridViewColumn = null;

		private DataGridViewCell mobjDataGridViewCell = null;

		private DataGridView mobjDataGridView = null;

		/// 
		/// Gets the column.
		/// </summary>
		internal DataGridViewColumn Column => mobjDataGridViewColumn;

		/// 
		/// Gets the cell.
		/// </summary>
		internal DataGridViewCell Cell => mobjDataGridViewCell;

		/// 
		/// Gets the value A.
		/// </summary>
		internal string ValueA => mobjComboBoxValueA.Text;

		/// 
		/// Gets the value B.
		/// </summary>
		internal string ValueB => mobjComboBoxValueB.Text;

		/// 
		/// Gets the operator A.
		/// </summary>
		internal FilterComparisonOperator OperatorA
		{
			get
			{
				if (!(mobjComboBoxOperatorA.SelectedItem is FilterOperatorItem { Operator: var result }))
				{
					return FilterComparisonOperator.None;
				}
				return result;
			}
		}

		/// 
		/// Gets the operator B.
		/// </summary>
		internal FilterComparisonOperator OperatorB
		{
			get
			{
				if (!(mobjComboBoxOperatorB.SelectedItem is FilterOperatorItem { Operator: var result }))
				{
					return FilterComparisonOperator.None;
				}
				return result;
			}
		}

		/// 
		/// Gets the filters relation.
		/// </summary>
		internal string FiltersRelation
		{
			get
			{
				if (mobjRadioButtonAnd.Checked)
				{
					return "AND";
				}
				return "OR";
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCustomFilterDialog" /> class.
		/// </summary>
		public DataGridViewCustomFilterDialog(DataGridViewCell objDataGridViewCell)
		{
			if (objDataGridViewCell == null)
			{
				throw new ArgumentNullException("objDataGridViewCell");
			}
			mobjDataGridViewCell = objDataGridViewCell;
			mobjDataGridViewColumn = objDataGridViewCell.OwningColumn;
			mobjDataGridView = mobjDataGridViewColumn.DataGridView;
			InitializeComponent();
			mobjLabelFilterMessage.Text = SR.GetString("FilterMessage", mobjDataGridViewColumn.HeaderText);
			Text = SR.GetString("CustomFilterColon");
			mobjButtonCancel.Text = WGLabels.Cancel;
			mobjButtonOK.Text = WGLabels.Ok;
			mobjRadioButtonAnd.Text = SR.GetString("And");
			mobjRadioButtonOr.Text = SR.GetString("Or");
			mobjComboBoxValueA.InitializeFilterValues(blnAddSystemFilterOptions: false, blnCalculateDropDownWidth: false, blnClearBindingSourceFilter: true);
			mobjComboBoxValueB.InitializeFilterValues(blnAddSystemFilterOptions: false, blnCalculateDropDownWidth: false, blnClearBindingSourceFilter: true);
			mobjComboBoxOperatorB.Items.Add("");
			List filterComparisonOperator = DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(mobjDataGridViewColumn.ValueType);
			foreach (FilterComparisonOperator item in filterComparisonOperator)
			{
				string strText = SR.GetString($"FilterComparisionOperator_{item.ToString()}");
				mobjComboBoxOperatorA.Items.Add(new FilterOperatorItem(item, strText));
				mobjComboBoxOperatorB.Items.Add(new FilterOperatorItem(item, strText));
			}
			if (mobjComboBoxOperatorA.Items.Count > 0)
			{
				mobjComboBoxOperatorA.SelectedIndex = 0;
			}
		}

		/// 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			mobjLabelFilterMessage = new Label();
			mobjComboBoxOperatorA = new ComboBox();
			mobjComboBoxValueA = new DataGridViewFilterComboBoxBase(mobjDataGridView, mobjDataGridViewColumn, mobjDataGridViewCell);
			mobjRadioButtonAnd = new RadioButton();
			mobjRadioButtonOr = new RadioButton();
			mobjComboBoxOperatorB = new ComboBox();
			mobjComboBoxValueB = new DataGridViewFilterComboBoxBase(mobjDataGridView, mobjDataGridViewColumn, mobjDataGridViewCell);
			mobjButtonCancel = new Button();
			mobjButtonOK = new Button();
			SuspendLayout();
			mobjLabelFilterMessage.AutoSize = true;
			mobjLabelFilterMessage.Location = new Point(6, 8);
			mobjLabelFilterMessage.Name = "mobjLabelFilterMessage";
			mobjLabelFilterMessage.Size = new Size(35, 13);
			mobjLabelFilterMessage.TabIndex = 0;
			mobjLabelFilterMessage.Text = "Show rows where '{0}' :";
			mobjComboBoxOperatorA.DropDownStyle = ComboBoxStyle.DropDownList;
			mobjComboBoxOperatorA.FormattingEnabled = true;
			mobjComboBoxOperatorA.Location = new Point(9, 34);
			mobjComboBoxOperatorA.Name = "mobjComboBoxOperatorA";
			mobjComboBoxOperatorA.Size = new Size(153, 21);
			mobjComboBoxOperatorA.TabIndex = 1;
			mobjComboBoxValueA.FormattingEnabled = true;
			mobjComboBoxValueA.Location = new Point(208, 34);
			mobjComboBoxValueA.Name = "mobjComboBoxValueA";
			mobjComboBoxValueA.Size = new Size(153, 21);
			mobjComboBoxValueA.TabIndex = 2;
			mobjRadioButtonAnd.AutoSize = true;
			mobjRadioButtonAnd.Location = new Point(9, 67);
			mobjRadioButtonAnd.Name = "mobjRadioButtonAnd";
			mobjRadioButtonAnd.Size = new Size(44, 17);
			mobjRadioButtonAnd.TabIndex = 3;
			mobjRadioButtonAnd.Checked = true;
			mobjRadioButtonAnd.Text = "And";
			mobjRadioButtonOr.AutoSize = true;
			mobjRadioButtonOr.Location = new Point(91, 67);
			mobjRadioButtonOr.Name = "mobjRadioButtonOr";
			mobjRadioButtonOr.Size = new Size(37, 17);
			mobjRadioButtonOr.TabIndex = 4;
			mobjRadioButtonOr.Text = "Or";
			mobjComboBoxOperatorB.DropDownStyle = ComboBoxStyle.DropDownList;
			mobjComboBoxOperatorB.FormattingEnabled = true;
			mobjComboBoxOperatorB.Location = new Point(9, 96);
			mobjComboBoxOperatorB.Name = "mobjComboBoxOperatorB";
			mobjComboBoxOperatorB.Size = new Size(153, 21);
			mobjComboBoxOperatorB.TabIndex = 5;
			mobjComboBoxValueB.FormattingEnabled = true;
			mobjComboBoxValueB.Location = new Point(208, 96);
			mobjComboBoxValueB.Name = "mobjComboBoxValueB";
			mobjComboBoxValueB.Size = new Size(153, 21);
			mobjComboBoxValueB.TabIndex = 6;
			mobjButtonCancel.DialogResult = DialogResult.Cancel;
			mobjButtonCancel.Location = new Point(286, 143);
			mobjButtonCancel.Name = "mobjButtonCancel";
			mobjButtonCancel.Size = new Size(75, 23);
			mobjButtonCancel.TabIndex = 7;
			mobjButtonCancel.Text = "Cancel";
			mobjButtonCancel.Click += mobjButtonCancel_Click;
			mobjButtonOK.Location = new Point(186, 143);
			mobjButtonOK.Name = "mobjButtonOK";
			mobjButtonOK.Size = new Size(75, 23);
			mobjButtonOK.TabIndex = 8;
			mobjButtonOK.Text = "OK";
			mobjButtonOK.Click += mobjButtonOK_Click;
			base.AcceptButton = mobjButtonOK;
			base.CancelButton = mobjButtonCancel;
			base.Controls.Add(mobjButtonOK);
			base.Controls.Add(mobjButtonCancel);
			base.Controls.Add(mobjComboBoxValueB);
			base.Controls.Add(mobjComboBoxOperatorB);
			base.Controls.Add(mobjRadioButtonAnd);
			base.Controls.Add(mobjRadioButtonOr);
			base.Controls.Add(mobjComboBoxValueA);
			base.Controls.Add(mobjComboBoxOperatorA);
			base.Controls.Add(mobjLabelFilterMessage);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Size = new Size(376, 176);
			Text = "Custom Filter:";
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		/// Handles the Click event of the mobjButtonCancel control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjButtonCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		/// 
		/// Handles the Click event of the mobjButtonOK control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjButtonOK_Click(object sender, EventArgs e)
		{
			if (ValidateValues())
			{
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show(SR.GetString("InvalidFilterMessage"), SR.GetString("CustomFilter"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		/// 
		/// Validates the values.
		/// </summary>
		/// </returns>
		private bool ValidateValues()
		{
			if (mobjComboBoxOperatorA.SelectedIndex < 0 || string.IsNullOrEmpty(mobjComboBoxValueA.Text) || (mobjComboBoxOperatorB.SelectedIndex > 0 && string.IsNullOrEmpty(mobjComboBoxValueB.Text)))
			{
				return false;
			}
			if (!mobjComboBoxValueA.IsValidValue() || (mobjComboBoxOperatorB.SelectedIndex > 0 && !mobjComboBoxValueB.IsValidValue()))
			{
				return false;
			}
			return true;
		}
	}
}
