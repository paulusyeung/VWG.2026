window.DeviceIntegrator_DeviceReady = function (objCallback) {
    objCallback();
};

/* DeviceInfo */
deviceInfoAccess.getModel = function () {
    if (navigator.appName) {
        return navigator.appName;
    }
};

deviceInfoAccess.getScriptVersion = function () {
    return "HTML5";
};

deviceInfoAccess.getPlatform = function () {
    if (navigator.platform) {
        return navigator.platform;
    }
};

deviceInfoAccess.getUUID = function () {
    if (navigator.userAgent) {
        return navigator.userAgent;
    }
};

deviceInfoAccess.getVersion = function () {
    if (navigator.appVersion) {
        return navigator.appVersion;
    }
};


/* Accelerometer */
//Gets current accelerometer data
deviceAccelerometerAccess.getCurrentAcceleration = function (accelerometerSuccess, accelerometerError) {
    if (deviceAccelerometerAccess.currentdata.currentdata !== undefined) {
        accelerometerSuccess(deviceAccelerometerAccess.currentdata);
    }
};

//Creates accelerometer watch
deviceAccelerometerAccess.watchAcceleration = function (accelerometerSuccess, accelerometerError, objAccelerometerOptions) {
    window.addEventListener('deviceorientation', watchAccelerationHandler);
    var objWatchId = window.setInterval(function () {
        accelerometerSuccess(deviceAccelerometerAccess.currentdata);
    }, objAccelerometerOptions.frequency);

    return objWatchId;
};

//Remove accelerometer watch
deviceAccelerometerAccess.clearWatch = function (objWatchId) {
    clearInterval(objWatchId);
    window.removeEventListener('deviceorientation', watchAccelerationHandler);
    deviceAccelerometerAccess.currentdata.currentdata = undefined;
};

/// <method name="watchAccelerationHandler">
/// <summary>
/// This is the eventhandler for the "deviceorientation" event, and it returns an object with the current accelerometer data
/// </summary>
function watchAccelerationHandler(objEventData) {
    var objResult = {};
    objResult.x = objEventData.gamma * (-1);
    objResult.y = objEventData.beta;
    objResult.z = objEventData.alpha;
    objResult.timestamp = objEventData.timeStamp;
    deviceAccelerometerAccess.currentdata = objResult;
};

/* Camera */

/// <method name="getCrossBrowserUserMedia">
/// <summary>
/// This is a graceful cross browser implementation of navigator.getUserMedia(), which is being depreciated by Mozilla.
/// The preference is on using navigator.mediaDevices.getUserMedia, with fallback to navigator.getUserMedia.
/// </summary>
navigator.getCrossBrowserUserMedia = function (constraints, successCallback, errorCallback) {
    // Get reference to legacy getUserMedia
    var legacyUserMedia = (navigator.getUserMedia ||
                           navigator.webkitGetUserMedia ||
                           navigator.mozGetUserMedia ||
                           navigator.msGetUserMedia);

    // Does browser support mediaDevices.getUserMedia, or as fallback, does it support navigator.getUserMedia
    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices.getUserMedia(constraints).then(successCallback).catch(errorCallback);
        return;
    }
    else if (legacyUserMedia) {
        legacyUserMedia.call(navigator, constraints, successCallback, errorCallback);
    }
};

/// <method name="crossBrowserStopStream">
/// <summary>
/// This is a graceful cross browser implementation of navigator.stream.stop(), which is being depreciated by Chrome and Mozilla.
/// </summary>
navigator.crossBrowserStopStream = function () {
    if (navigator.stream) {
        if (navigator.stream.stop) {
            navigator.stream.stop();
        }
        else if (navigator.stream.getTracks) {
            var objTracks = navigator.stream.getTracks();
            for (var i = 0; i < objTracks.length ; i++) {
                var objTrack = objTracks[i];
                objTrack.stop();
            }
        }
    }
};

navigator.localMediaStream = null;

//Initialization of constants (to match Phonegap)
if (typeof Camera == 'undefined') {
    Camera = {};
}
if (typeof Camera.DestinationType == 'undefined') {
    Camera.DestinationType = {};
}
Camera.DestinationType.DATA_URL = 0;

/// <method name="getPictureInContainer">
/// <summary>
/// Gets the stream of the camera and display it in a container
/// </summary>

deviceCameraAccess.getPicture = function (cameraSuccess, cameraError, objCameraOptions) {
    //clean video and stream if exists
    navigator.crossBrowserStopStream();

    var objVideoCapture = $('#videocapture');
    if (objVideoCapture.length > 0) {
        $('#videocapture').get(0).src = null;
        $('#videocapture').remove();
    }

    //Get access to the device camera and run a callback when success
    navigator.getCrossBrowserUserMedia(
          {
              video: true,
              audio: false
          },
          //this function runs when the access to the camera is allowed
          function (objStream) {
              //start capture stream and view it in the video tag
              var objContainer = $(Web_GetElementByDataId(objCameraOptions.streamContainerID, window));
              navigator.stream = objStream;
              objVideoCapture = $("<video id='videocapture' autoplay></video>");
              objVideoCapture.css("width", objContainer.css("width"));
              objCanvasCapture = $('<canvas style="display:none;" />');
              objVideoCapture.get(0).src = window.URL.createObjectURL(navigator.stream);
              objVideoCapture.get(0).play();
              //put the video element in the container
              objContainer.html(objVideoCapture);

              //when the video is clicked, capture the picture
              objVideoCapture.click(function () {
                  //draw the captured picture in a canvas
                  var objCanvasElement = objCanvasCapture.get(0);
                  objCanvasElement.width = this.videoWidth;
                  objCanvasElement.height = this.videoHeight;
                  objCanvasElement.getContext('2d').drawImage(this, 0, 0);
                  //stop the stream(s)
                  navigator.crossBrowserStopStream();
                  //get a base64 represantation of the picture
                  var strBase64 = objCanvasElement.toDataURL('image/jpeg', 1);
                  strBase64 = strBase64.replace("data:image/jpeg;base64,", "");
                  objVideoCapture.src = null;
                  objVideoCapture.remove();
                  objCanvasCapture.remove();
                  //send the base64 represantation to thesuccess callback
                  cameraSuccess(strBase64);
              });
          },
          function (err) {
              cameraError(err);
          });
};

/* Compass */
//Gets current compass data
deviceCompassAccess.getCurrentHeading = function (compassSuccess, compassError, objCompassOptions) {
    if (deviceCompassAccess.currentdata !== undefined) {
        compassSuccess(deviceCompassAccess.currentdata);
    }
};

//Creates compass watch
deviceCompassAccess.watchHeading = function (compassSuccess, compassError, objCompassOptions) {
    window.addEventListener('deviceorientation', watchHeadingHandler);
    var objWatchId = window.setInterval(function () {
        compassSuccess(deviceCompassAccess.currentdata);
    }, objCompassOptions.frequency);

    return objWatchId;
};

//Clears compass watch
deviceCompassAccess.clearWatch = function (objWatchId) {
    clearInterval(objWatchId);
    window.removeEventListener('deviceorientation', watchHeadingHandler);
    deviceCompassAccess.currentdata = undefined;
};

/// <method name="watchHeadingHandler">
/// <summary>
/// This is the eventhandler for the "deviceorientation" event, and it returns an object with the current compass data
/// </summary>
function watchHeadingHandler(objEventData) {
    var objResult = {};
    objResult.magneticHeading = 360 - objEventData.alpha;
    objResult.trueHeading = null;
    objResult.headingAccuracy = null;
    objResult.timestamp = objEventData.timeStamp;
    deviceCompassAccess.currentdata = objResult;
};

/* Geolocation */
//Get current position
deviceGeolocationAccess.getCurrentPosition = function (geolocationSuccess, geolocationError, objGeolocationOptions) {
    if (navigator.geolocation && navigator.geolocation.getCurrentPosition) {
        return navigator.geolocation.getCurrentPosition(geolocationSuccess);
    }
};

//Creates position watch
deviceGeolocationAccess.watchPosition = function (geolocationSuccess, geolocationError, objGeolocationOptions) {
    if (navigator.geolocation && navigator.geolocation.watchPosition) {
        return navigator.geolocation.watchPosition(geolocationSuccess);
    }

};

//Clears position watch
deviceGeolocationAccess.clearWatch = function (objWatchId) {
    if (navigator.geolocation && navigator.geolocation.clearWatch) {
        return navigator.geolocation.clearWatch(objWatchId);
    }
};

/* Notification */
//Show alert0
deviceNotificationAccess.alert = function (strMessage, alertCallback, strTitle, buttonName) {
    alert(strMessage);
    alertCallback();
};
//Show confirm box
deviceNotificationAccess.confirm = function (strMessage, confirmCallback, strTitle, buttonLabels) {
    var blnResult = confirm(strMessage);
    if (blnResult == true) {
        confirmCallback();
    }
};

//Vibrates
deviceNotificationAccess.vibrate = function (intMilliseconds) {
    if (navigator.vibrate) {
        return navigator.vibrate(intMilliseconds);
    }
};

/* Storage */
//Opens a database
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