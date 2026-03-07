function onConnectivityOffline(offlineImageUrl)
{
    DeviceIntegrator.offline("updateUIOfflineEvent", offlineImageUrl);
}

function updateUIOfflineEvent(offlineImageUrl)
{
    var pictureBox = vwgContext.provider.getComponentByClientId("mobjConnectivityStatePictureBox");
    pictureBox.imageUrl(offlineImageUrl);
    pictureBox.update();
}