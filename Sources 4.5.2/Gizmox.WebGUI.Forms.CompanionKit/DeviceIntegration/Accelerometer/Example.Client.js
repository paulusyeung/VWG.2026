function startAccelerationWatch()
{
    // This sample uses Phonegap integration API directly. (No VWG envolve)
    DeviceIntegrator_DeviceReady(function ()
    {
        ClientStorage.Globals["watchID"] = vwgContext.deviceIntegrator.Accelerometer.watchAcceleration(function (acceleration)
        {
            var accPanel = vwgContext.provider.getComponentByClientId("accelerationPanel1");

            // If acceleration data exists
            if (!acceleration.code && !acceleration.message)
            {
                var ball = $("#VGA_ACCELERATION_BALL");
                var ballParent = $("#VGA_ACCELERATION_PANEL");

                // Accelerate the ball
                vwgContext.acceleratePanel(acceleration, ball, ballParent);
            }

            // If error..
            else if (acceleration.message)
            {
                alert("Error: " + acceleration.message);
            }
        }, undefined, { frequency: 10 });
    }, false);

}

function stopAccelerationWatch()
{
    if (ClientStorage.Globals["watchID"] != undefined)
    {
        vwgContext.deviceIntegrator.Accelerometer.clearWatch(ClientStorage.Globals["watchID"]);
        ClientStorage.Globals["watchID"] = undefined;
    }
}