/// <method name="changeImage" access="private">
/// <summary>
/// Changes background image of panel to one of 3 existing images in cycle
/// </summary>
function BackImagePanel_changeImage(clientId) {

    var arrImageUrls = ['[Skin.Path]berry.jpg.wgx', '[Skin.Path]dandelion.jpg.wgx', '[Skin.Path]field.jpg.wgx'];

    //Get client panel
    var objPanel = vwgContext.provider.getComponentById(clientId);

    // Get Background Image Url
    var strBackgroundImageUrl = objPanel.backgroundImageUrl();

    // if not defined, or it is the last image, set the 1st one.
    if (strBackgroundImageUrl == '' || strBackgroundImageUrl == arrImageUrls[2]) {
        objPanel.backgroundImageUrl(arrImageUrls[0]);
    }

    // Else, advance to next image
    else if (strBackgroundImageUrl == arrImageUrls[1]) {
        objPanel.backgroundImageUrl(arrImageUrls[2]);
    }
    else if (strBackgroundImageUrl == arrImageUrls[0]) {
        objPanel.backgroundImageUrl(arrImageUrls[1]);
    }

    objPanel.update();
}
/// </method>

