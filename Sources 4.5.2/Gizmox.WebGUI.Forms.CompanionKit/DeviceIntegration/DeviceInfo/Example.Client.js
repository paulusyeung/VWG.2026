function onGetDeviceInfoClick()
{
    // This sample uses Phonegap integration API directly. (No VWG envolve)
    DeviceIntegrator_DeviceReady(function ()
    {
        ClientStorage.Globals["DeviceInfo_LabelId"] = "mobjNameText";
        setLabelValue(vwgContext.deviceIntegrator.Info.getModel());

        ClientStorage.Globals["DeviceInfo_LabelId"] = "mobjPlatformText";
        setLabelValue(vwgContext.deviceIntegrator.Info.getPlatform());

        ClientStorage.Globals["DeviceInfo_LabelId"] = "mobjJavascriptVersionText";
        setLabelValue(vwgContext.deviceIntegrator.Info.getScriptVersion());

        ClientStorage.Globals["DeviceInfo_LabelId"] = "mobjUUIDText";
        setLabelValue(vwgContext.deviceIntegrator.Info.getUUID());

        ClientStorage.Globals["DeviceInfo_LabelId"] = "mobjVersionText";
        setLabelValue(vwgContext.deviceIntegrator.Info.getVersion());
    });
}

function setLabelValue(strDeviceValue)
{
    var objLabelDom = vwgContext.provider.getComponentByClientId(ClientStorage.Globals["DeviceInfo_LabelId"]);
    objLabelDom.text(strDeviceValue);
    objLabelDom.update();
}