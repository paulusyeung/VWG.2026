using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CompanionKit.Controls.ComboBox.Features
{
    public class FormComboBox : Gizmox.WebGUI.Forms.ComboBox
    {
        private ComboBoxForm _comboBoxForm;
         /// <summary>
        /// Initializes a new instance of the <see cref="FormComboBox"/> class.
        /// </summary>
        public FormComboBox()
        {
            _comboBoxForm = new ComboBoxForm();
            this.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDown;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has a custom drop down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
        /// </value>
        protected override bool IsCustomDropDown
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// Gets the custom form to display as drop down
        /// </summary>
        /// <returns></returns>
        protected override global::Gizmox.WebGUI.Forms.Form GetCustomDropDown()
        {
            _comboBoxForm.DialogResult = Gizmox.WebGUI.Forms.DialogResult.None;
            _comboBoxForm.Width = Math.Max(this.Width, _comboBoxForm.Width);
            return _comboBoxForm;
        }
    }
}
