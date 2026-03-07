
// setItem function callback
function setItemCallback(strKey, strItem)
{
    console.log("'" + strItem + "' saved in storage on key '" + strKey + "'.");
}

// store local storage.
function storeLocalStorage(strWatermarkTextBox1Id, strWatermarkTextBox2Id, strWatermarkTextBox3Id, strWatermarkTextBox4Id)
{
    // This sample uses Phonegap integration API directly. (No VWG envolve)
    DeviceIntegrator_DeviceReady(function ()
    {
        var watermarkTextBox1 = vwgContext.provider.getComponentById(strWatermarkTextBox1Id);
        var watermarkTextBox3 = vwgContext.provider.getComponentById(strWatermarkTextBox2Id);
        var watermarkTextBox4 = vwgContext.provider.getComponentById(strWatermarkTextBox3Id);
        var watermarkTextBox2 = vwgContext.provider.getComponentById(strWatermarkTextBox4Id);
        if (!watermarkTextBox4.text() || !watermarkTextBox3.text() || !watermarkTextBox1.text() || !watermarkTextBox2.text())
        {
            alert("Please fill all data fields");
        }
        else
        {
            vwgContext.deviceIntegrator.Storage.setItem("address", watermarkTextBox4.text());
            setItemCallback("address", watermarkTextBox4.text());

            vwgContext.deviceIntegrator.Storage.setItem("email", watermarkTextBox3.text());
            setItemCallback("email", watermarkTextBox3.text());

            vwgContext.deviceIntegrator.Storage.setItem("name", watermarkTextBox1.text());
            setItemCallback("name", watermarkTextBox1.text());

            vwgContext.deviceIntegrator.Storage.setItem("phone", watermarkTextBox2.text());
            setItemCallback("phone", watermarkTextBox2.text());

            alert("Data saved successfully.");
        }
    });
}
