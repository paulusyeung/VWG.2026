/// <method name="ClientHandler" access="private">
/// <summary>
/// Handles controls on WebSocket data received
/// </summary>
function ClientHandler() {
    //Get data from WebSocket
    var strData = vwgContext.events.eventArgs()["WSD"];
    var strConnectionId = vwgContext.events.eventArgs()["WSC"];
    //Define page instance
    var mobjPage = vwgContext.provider.getComponentByClientId("page");
    //Parse string data to object
    var mobjData = jQuery.parseJSON(strData);
    //If parsed object contains RandomValues array and message was send by itself, then proceed
    if (mobjData.RandomValues) {
        //Fills labels and progress bar with random data
        for (var i = 0; i < mobjData.RandomValues.length; i++) {
            var mstrProgressBarClientId = "ProgressBar" + (i + 1);
            var mstrLabelClientId = "Label" + (i + 1);
            var mobjLabel = vwgContext.provider.getComponentByClientId(mstrLabelClientId);
            var mobjProgressBar = vwgContext.provider.getComponentByClientId(mstrProgressBarClientId);
            mobjProgressBar.value(mobjData.RandomValues[i]);
            mobjLabel.text(mobjData.RandomValues[i].toString());
        }
        //Update page
        mobjPage.update();
    }
}
/// </method>