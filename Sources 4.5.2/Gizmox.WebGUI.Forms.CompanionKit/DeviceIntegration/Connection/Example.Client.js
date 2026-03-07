function onCheckConnectionClick()
{
    DeviceIntegrator_DeviceReady(function ()
    {
        alert('Connection type: ' + vwgContext.deviceIntegrator.Connection.getConnectionType());
    });
}
