function startCompassWatch()
{
    // This sample uses Phonegap integration API directly. (No VWG envolve)
    DeviceIntegrator_DeviceReady(function ()
    {
        ClientStorage.Globals["watchID"] = vwgContext.deviceIntegrator.Compass.watchHeading(function (heading)
        {
            var compass = vwgContext.provider.getComponentByClientId("compass1");

            // If compass data exists
            if (!heading.code && !heading.message)
            {
                // Set heading
                vwgContext.compassHeading(heading.magneticHeading);
            }

                // If error..
            else if (heading.message)
            {
                alert("Error: " + heading.message);
            }
        }, undefined, { frequency: 10 });
    });
}

function stopCompassWatch()
{
    if (ClientStorage.Globals["watchID"] != undefined)
    {
        vwgContext.deviceIntegrator.Compass.clearWatch(ClientStorage.Globals["watchID"]);
        ClientStorage.Globals["watchID"] = undefined;
    }
}