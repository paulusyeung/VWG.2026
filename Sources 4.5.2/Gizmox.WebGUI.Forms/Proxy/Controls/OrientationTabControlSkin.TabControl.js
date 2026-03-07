/// <method name="OrientationTabControl_UpdateProxyOrientation">
/// <summary>
/// Set the selected tab according to the device orienation.
/// </summary>
function OrientationTabControl_UpdateOrientation(strDataId, blnDeviceLandscape) {
    var objTabControl = vwgContext.provider.getComponentById(strDataId);
    if (!objTabControl) { return; }

    var blnWindowLandscape = Web_IsWindowLandscape();
    if (blnWindowLandscape == blnDeviceLandscape) {
        objTabControl.selectedIndex(0);
    }
    else
    {
        objTabControl.selectedIndex(1);
    }
        
    objTabControl.update();
}
