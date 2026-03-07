using System;
using System.Data;



namespace Gizmox.WebGUI.Forms.Catalog
{
    [Serializable]
    public partial class XamlForm : Form
    {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }



        protected void OnSaveClick(object sender, EventArgs e)
        {
            MessageBox.Show("OnSaveClick");
        }

        protected void OnCutClick(object sender, EventArgs e)
        {
            MessageBox.Show("OnCutClick");
        }
    }
}
