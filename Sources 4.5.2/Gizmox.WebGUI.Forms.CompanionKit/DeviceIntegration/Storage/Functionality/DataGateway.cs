using Gizmox.WebGUI.Forms.Client;

namespace CompanionKit.DeviceIntegration.Storage.Functionality
{
    public class DataGateway : ClientStaticGateway
    {
        protected override void ProcessGateway(ClientGatewayContext objGatewayContext)
        {
            // Mock data
            string[] arrNames = { "Alex", "Eyal", "Nir", "Tal", "Shlomi" };
            int intID = 0;

            // Write response in JSON fromat.
            foreach (string strName in arrNames)
            {
                objGatewayContext.WriteStartRow();

                string id = (++intID).ToString();
                objGatewayContext.WriteRowValue("ID", id);
                objGatewayContext.WriteRowValue("Name", strName);
                objGatewayContext.WriteEndRow();
            }
        }
    }
}