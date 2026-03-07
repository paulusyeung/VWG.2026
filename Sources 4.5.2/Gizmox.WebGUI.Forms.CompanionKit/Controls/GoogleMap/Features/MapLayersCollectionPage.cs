using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.GoogleMap.Features
{
    public partial class MapLayersCollectionPage : UserControl
    {
        public MapLayersCollectionPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the MapLayersCollectionPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MapLayersCollectionPage_Load(object sender, EventArgs e)
        {
            //Fills checkListBox with all GoogleMapLayer types
            mobjCheckedListBox.Items.AddRange(Enum.GetValues(typeof(Gizmox.WebGUI.Forms.Google.GoogleMapLayerType)));
        }

        /// <summary>
        /// Handles the ItemCheck event of the objCheckedListBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void mobjCheckedListBox_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        {
            //Gets type of selected item
            Gizmox.WebGUI.Forms.Google.GoogleMapLayerType objMapLayerType = (Gizmox.WebGUI.Forms.Google.GoogleMapLayerType)((Gizmox.WebGUI.Forms.CheckedListBox)objSender).Items[objArgs.Index];
            //Gets string with name of type
            string strType = objMapLayerType.ToString();
            //If item checked - add new layer to collection
            if(objArgs.NewValue == CheckState.Checked)
            {
                mobjGoogleMap.MapLayers.Add(GetInstance(strType));
            }
            // if unchecked - remove layer from collection
            else
            {
                mobjGoogleMap.MapLayers.RemoveItemByLayerType((Gizmox.WebGUI.Forms.Google.GoogleMapLayerType)objMapLayerType);
            }
            //Updates googleMap control
            mobjGoogleMap.Update();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="strTypeName">string value of type name.</param>
        /// <returns></returns>
        private Gizmox.WebGUI.Forms.Google.GoogleMapLayer GetInstance(string strTypeName)
        {
            //Returns MapLayer type according to its name
            switch (strTypeName)
            {
                case "BicyclingLayer": return new Gizmox.WebGUI.Forms.Google.GoogleMapBicyclingLayer();
                case "KmlLayer": return new Gizmox.WebGUI.Forms.Google.GoogleMapKmlLayer(); ;
                case "TrafficLayer": return new Gizmox.WebGUI.Forms.Google.GoogleMapTrafficLayer();
                case "TransitLayer": return new Gizmox.WebGUI.Forms.Google.GoogleMapTransitLayer();
                case "CloudLayer": return new Gizmox.WebGUI.Forms.Google.GoogleMapCloudLayer();
                case "WeatherLayer": return new Gizmox.WebGUI.Forms.Google.GoogleMapWeatherLayer();
                case "HeatmapLayer": return new Gizmox.WebGUI.Forms.Google.GoogleMapHeatMapLayer();
                default: return null;
            }
        }
    }
}