window.DeviceIntegrator_DeviceReady = function (objCallback) {
    document.addEventListener("deviceready", objCallback, false);
};

/* DeviceInfo */

deviceInfoAccess.getModel = function () {
    return device.model;
};

deviceInfoAccess.getScriptVersion = function () {
    return device.cordova;
};

deviceInfoAccess.getPlatform = function () {
    return device.platform;
};

deviceInfoAccess.getUUID = function () {
    return device.uuid;
};

deviceInfoAccess.getVersion = function () {
    return device.version;
};

/* Connection */

deviceConnectionAccess.getConnectionType = function () {
    var strConnectionType = navigator.connection.type || navigator.network.connection.type;

    // Phonegap 2.2.0 has a bug where 'navigator.connection.type' does not exist, but 'navigator.network.connection.type' does.
    // In future versions the 'navigator.network.connection.type' will be removed
    if (!strConnectionType && navigator.network && navigator.network.connection) {
        strConnectionType = navigator.network.connection.type;
    }

    return strConnectionType;
};

/* Globalization */

deviceGlobalizationAccess.getPreferredLanguage = function (fncSuccess, fncError) {
    return navigator.globalization.getPreferredLanguage(fncSuccess, fncError);
};

deviceGlobalizationAccess.getLocaleName = function (fncSuccess, fncError) {
    return navigator.globalization.getLocaleName(fncSuccess, fncError);
};

deviceGlobalizationAccess.getFirstDayOfWeek = function (fncSuccess, fncError) {
    return navigator.globalization.getFirstDayOfWeek(fncSuccess, fncError);
};

deviceGlobalizationAccess.isDayLightSavingsTime = function (objDate, fncSuccess, fncError) {
    return navigator.globalization.isDayLightSavingsTime(objDate, fncSuccess, fncError);
};

deviceGlobalizationAccess.getCurrencyPattern = function (strCurrencyCode, fncSuccess, fncError) {
    return navigator.globalization.getCurrencyPattern(strCurrencyCode, fncSuccess, fncError);
};

deviceGlobalizationAccess.dateToString = function (objDate, fncSuccess, fncError, objOptions) {
    return navigator.globalization.dateToString(objDate, fncSuccess, fncError, objOptions);
};

deviceGlobalizationAccess.stringToDate = function (strDate, fncSuccess, fncError, objOptions) {
    return navigator.globalization.stringToDate(strDate, fncSuccess, fncError, objOptions);
};

deviceGlobalizationAccess.getDatePattern = function (fncSuccess, fncError, objOptions) {
    return navigator.globalization.getDatePattern(fncSuccess, fncError, objOptions);
};

deviceGlobalizationAccess.getNumberPattern = function (fncSuccess, fncError, objOptions) {
    return navigator.globalization.getDatePattern(fncSuccess, fncError, objOptions);
};

deviceGlobalizationAccess.numberToString = function (objNumber, fncSuccess, fncError, objOptions) {
    return navigator.globalization.numberToString(objNumber, fncSuccess, fncError, objOptions);
};

deviceGlobalizationAccess.stringToNumber = function (strNumber, fncSuccess, fncError, objOptions) {
    return navigator.globalization.stringToNumber(strNumber, fncSuccess, fncError, objOptions);
};

deviceGlobalizationAccess.getDateNames = function (fncSuccess, fncError, objOptions) {
    return navigator.globalization.getDatePattern(fncSuccess, fncError, objOptions);
};


/* Accelerometer */
deviceAccelerometerAccess.getCurrentAcceleration = function (accelerometerSuccess, accelerometerError) {
    return navigator.accelerometer.getCurrentAcceleration(accelerometerSuccess, accelerometerError);
};

deviceAccelerometerAccess.watchAcceleration = function (accelerometerSuccess, accelerometerError, accelerometerOptions) {
    return navigator.accelerometer.watchAcceleration(accelerometerSuccess, accelerometerError, accelerometerOptions);
};

deviceAccelerometerAccess.clearWatch = function (watchID) {
    return navigator.accelerometer.clearWatch(watchID);
};

/* Camera */
deviceCameraAccess.getPicture = function (cameraSuccess, cameraError, cameraOptions) {
    return navigator.camera.getPicture(cameraSuccess, cameraError, cameraOptions);
};

deviceCameraAccess.cleanup = function (cameraSuccess, cameraError) {
    return navigator.camera.cleanup(cameraSuccess, cameraError);
};

/* Capture */
deviceCaptureAccess.captureAudio = function (captureSuccess, captureError, options) {
    return navigator.device.capture.captureAudio(captureSuccess, captureError, options);
};

deviceCaptureAccess.captureImage = function (captureSuccess, captureError, options) {
    return navigator.device.capture.captureImage(captureSuccess, captureError, options);
};

deviceCaptureAccess.captureVideo = function (captureSuccess, captureError, options) {
    return navigator.device.capture.captureVideo(captureSuccess, captureError, options);
};

deviceCaptureAccess.getFormatData = function (successCallback, errorCallback) {
    return mediaFile.getFormatData(successCallback, errorCallback);
};

deviceCaptureAccess.createMediaFile = function () {
    return new MediaFile();
};

/* Compass */
deviceCompassAccess.getCurrentHeading = function (compassSuccess, compassError, compassOptions) {
    return navigator.compass.getCurrentHeading(compassSuccess, compassError, compassOptions);
};

deviceCompassAccess.watchHeading = function (compassSuccess, compassError, compassOptions) {
    return navigator.compass.watchHeading(compassSuccess, compassError, compassOptions);
};

deviceCompassAccess.clearWatch = function (watchID) {
    return navigator.compass.clearWatch(watchID);
};


/* Contacts */
deviceContactsAccess.create = function (properties) {
    return navigator.contacts.create(properties);
};

deviceContactsAccess.find = function (contactFields, contactSuccess, contactError, contactFindOptions) {
    return navigator.contacts.find(contactFields, contactSuccess, contactError, contactFindOptions);
};

deviceContactsAccess.createContactName = function () {
    return new ContactName();
};

deviceContactsAccess.createContactFindOptions = function () {
    return new ContactFindOptions();
};


/* Geolocation */
deviceGeolocationAccess.getCurrentPosition = function (geolocationSuccess, geolocationError, geolocationOptions) {
    return navigator.geolocation.getCurrentPosition(geolocationSuccess, geolocationError, geolocationOptions);
};

deviceGeolocationAccess.watchPosition = function (geolocationSuccess, geolocationError, geolocationOptions) {
    return navigator.geolocation.watchPosition(geolocationSuccess, geolocationError, geolocationOptions);
};

deviceGeolocationAccess.clearWatch = function (watchID) {
    return navigator.geolocation.clearWatch(watchID);
};

/* Notification */
deviceNotificationAccess.alert = function (message, alertCallback, title, buttonName) {
    return navigator.notification.alert(message, alertCallback, title, buttonName);
};

deviceNotificationAccess.confirm = function (message, confirmCallback, title, buttonLabels) {
    return navigator.notification.confirm(message, confirmCallback, title, buttonLabels);
};

deviceNotificationAccess.beep = function (times) {
    return navigator.notification.beep(times);
};

deviceNotificationAccess.vibrate = function (milliseconds) {
    return navigator.notification.vibrate(milliseconds)
};

/* SplashScreen */
deviceSplashscreenAccess.show = function () {
    return navigator.splashscreen.show();
};

deviceSplashscreenAccess.hide = function () {
    return navigator.splashscreen.hide();
};

/* Storage */
deviceStorageAccess.openDatabase = function (strDatabaseName, strDatabaseVersion, strDatabaseDisplayname, strDatabaseSize) {
    return window.openDatabase(strDatabaseName, strDatabaseVersion, strDatabaseDisplayname, strDatabaseSize);
};

//Get item by Key from storage
deviceStorageAccess.getItem = function (strKey) {
    return window.localStorage.getItem(strKey);
};

//set item by Key from storage
deviceStorageAccess.setItem = function (strKey, strVal) {
    return window.localStorage.setItem(strKey, strVal);
};

//remove item by Key from storage
deviceStorageAccess.removeItem = function (strKey) {
    return window.localStorage.removeItem(strKey);
};

// Get key by position in array form storage.
deviceStorageAccess.key = function (intPosition) {
    return window.localStorage.key(intPosition);
};

//clear Keys from storage
deviceStorageAccess.clear = function () {
    return window.localStorage.clear();
};
/* File Manager */
deviceFileManagerAccess.createDirectoryEntry = function (strName, strPath) {
    return new DirectoryEntry(strName, strPath);
};

deviceFileManagerAccess.createFileEntry = function (strName, strPath) {
    return new FileEntry(strName, strPath);
};

deviceFileManagerAccess.createFileTransfer = function () {
    return new FileTransfer();
};

deviceFileManagerAccess.createFileReader = function () {
    return new FileReader();
};

/* Media */
deviceMediaAccess.createMedia = function (src, mediaSuccess, mediaError, mediaStatus) {
    return new Media(src, mediaSuccess, mediaError, mediaStatus);
};