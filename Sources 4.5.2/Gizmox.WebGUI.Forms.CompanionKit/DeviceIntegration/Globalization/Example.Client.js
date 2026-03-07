function onGlobalizationGetDataClick(strCurrencyCode, objDate, objDateToStringOptions)
{
    // This sample uses Phonegap integration API directly. (No VWG envolve)
    DeviceIntegrator_DeviceReady(function ()
    {
        vwgContext.deviceIntegrator.Globalization.getPreferredLanguage(function (objValue)
        {
            ClientStorage.Globals["Globalization_LabelId"] = "mobjPrefferedLangText";
            Globalization_UpdateLabelWithValue(objValue.value);
        });

        vwgContext.deviceIntegrator.Globalization.getLocaleName(function (objValue)
        {
            ClientStorage.Globals["Globalization_LabelId"] = "mobjLocaleText";
            Globalization_UpdateLabelWithValue(objValue.value);
        });

        vwgContext.deviceIntegrator.Globalization.isDayLightSavingsTime(objDate, function (objValue)
        {
            ClientStorage.Globals["Globalization_LabelId"] = "mobjIDLSText";
            Globalization_UpdateLabelWithValue("" + objValue.dst);
        });
        
        vwgContext.deviceIntegrator.Globalization.getFirstDayOfWeek(function (objValue)
        {
            ClientStorage.Globals["Globalization_LabelId"] = "mobjFDOWText";
            Globalization_UpdateLabelWithValue(objValue.value);
        });
        
        vwgContext.deviceIntegrator.Globalization.getCurrencyPattern(strCurrencyCode, function (objValue)
        {
            ClientStorage.Globals["Globalization_LabelId"] = "mobjCurrencyText";
            Globalization_UpdateLabelWithValue(objValue.pattern);
        });

        vwgContext.deviceIntegrator.Globalization.dateToString(objDate, function (objValue)
        {
            ClientStorage.Globals["Globalization_LabelId"] = "mobjDateText";
            Globalization_UpdateLabelWithValue(objValue.value);
        }, undefined, objDateToStringOptions);
    });
}

function Globalization_UpdateLabelWithValue(objValue)
{
    var objLabelDom = vwgContext.provider.getComponentByClientId(ClientStorage.Globals["Globalization_LabelId"]);
    if (objLabelDom != null)
    {
        objLabelDom.text(objValue);
        objLabelDom.update();
    }
}