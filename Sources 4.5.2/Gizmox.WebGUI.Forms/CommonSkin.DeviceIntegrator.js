//Defining all the device integrator empty provider objects (will be overridden when added a device integration provider like phonegap)
function deviceInfoAccess() { };
function deviceConnectionAccess() {};
function deviceGlobalizationAccess() {};
function deviceAccelerometerAccess() {};
function deviceCameraAccess() {};
function deviceCaptureAccess() {};
function deviceCompassAccess() {};
function deviceContactsAccess() {};
function deviceGeolocationAccess() {};
function deviceNotificationAccess() {};
function deviceSplashscreenAccess() {};
function deviceStorageAccess() {};
function deviceEventsAccess() {};
function deviceFileManagerAccess() {};
function deviceMediaAccess() { };

var DeviceIntegrator = {};
// Stores device event handlers for server side events.
DeviceIntegrator.DeviceEventHandlers = {};

DeviceIntegrator.IntegratorID = null;
DeviceIntegrator.DeviceIntegrationNode = null;
/* Basic API and Initialization */

// Basic Event for device ready
if (window.DeviceIntegrator_DeviceReady == undefined) {
    window.DeviceIntegrator_DeviceReady = function (objCallback) {
        if (document.readyState === "complete") {
            objCallback();
        }
        else {
            window.addEventListener("onload", objCallback, false);
        }
    };
}



/// <method name="DeviceIntegrator_RaiseEvent">
/// <summary>
/// 
/// </summary>
function DeviceIntegrator_RaiseEvent(objEvent, objNode, strEventType, blnForceRaise) {
    if (blnForceRaise || Data_IsCriticalEvent(objNode, strEventType, true)) {
        vwgContext.events.raiseEvents();
    }
};
/// </method>

/// <method name="DeviceIntegrator_GetExceptionObject">
/// <summary>
/// 
/// </summary>
function DeviceIntegrator_GetExceptionObject(intErrorCode, strMessage) {
    return { "code": intErrorCode, "message": strMessage };
};
/// </method>

/// <method name="DeviceIntefrator_GetInitializationObject">
/// <summary>
/// 
/// </summary>
function DeviceIntegrator_GetInitializationObject(
    fncCallbackOrStrMethodKey,
    arrArguments,
    intArgumentsStartIndex,
    fncInvokationFunction,
    fncClientSuccessHandler,
    fncErrorCreator,
    fncSuccessEventHandler,
    fncErrorEventHandler,
    objOptions,
    blnNoCallbackArguments) {
    // Get all additional arguments
    var arrNewArguments = [];

    if (!blnNoCallbackArguments) {
        arrNewArguments.push(null);
    }

    if (arrArguments) {
        for (var i = intArgumentsStartIndex; i < arrArguments.length; ++i) {
            arrNewArguments.push(arrArguments[i]);
        }
    }

    var objDelegateOrKey = DeviceIntegrator_ExtractDelegateOrMethodKey(fncCallbackOrStrMethodKey);

    return {
        "isDelegate": objDelegateOrKey.isDelegate,
        "delegate": objDelegateOrKey.delegate,
        "methodKey": objDelegateOrKey.methodKey,
        "arguments": arrNewArguments,
        "invokationFunction": fncInvokationFunction,
        "clientSuccessHandler": fncClientSuccessHandler,
        "clientErrorCreator": fncErrorCreator,
        "successEventHandler": fncSuccessEventHandler,
        "errorEventHandler": fncErrorEventHandler,
        "options": objOptions
    };
};
/// </method>

/// <method name="DeviceIntegrator_Execute">
/// <summary>
/// 
/// </summary>
function DeviceIntegrator_Execute(objInitialization) {
    // Validate invokation function exists
    if (objInitialization.invokationFunction) {
        // Invoke the function and get the return value
        var returnValue = objInitialization.invokationFunction(function () {
            // Collect all success callback arguments and leave the first cell in the array as a place holder for an additional parameter
            var arrArguments = [];
            arrArguments.push(null);
            for (var i = 0; i < arguments.length; i++) {
                arrArguments.push(arguments[i]);
            }

            if (objInitialization.isDelegate) // Client invocation
            {
                arrArguments[0] =
                    {
                        "returnValue": returnValue,
                        "callback": function (sucessArgument) {
                            objInitialization.arguments[0] = sucessArgument;
                            objInitialization.delegate.apply(this, objInitialization.arguments);
                        }
                    };

                // Check for an clientSuccessHandler function
                if (objInitialization.clientSuccessHandler) {
                    // Create the argument for the delegate callback
                    objInitialization.clientSuccessHandler.apply(objInitialization.options || this, arrArguments);
                }
                else {
                    objInitialization.arguments[0] = arrArguments[1];
                    objInitialization.delegate.apply(this, objInitialization.arguments);
                }
            }
            else // Server invocation
            {
                if (objInitialization.methodKey) {
                    // Set the first argument to be the method key
                    arrArguments[0] = objInitialization.methodKey;

                    // Craete a success event
                    objInitialization.successEventHandler.apply(objInitialization.options || this, arrArguments);
                }
            }
        },
        function () // Error
        {
            if (objInitialization.isDelegate) {
                if (objInitialization.clientErrorCreator) {
                    objInitialization.arguments[0] = objInitialization.clientErrorCreator.apply(this, arguments);
                }
                else {
                    objInitialization.arguments[0] = arguments[0];
                }
                objInitialization.delegate.apply(this, objInitialization.arguments);
            }
            else {
                if (objInitialization.methodKey) {
                    var arrArguments = [];
                    arrArguments.push(objInitialization.methodKey);
                    for (var i = 0; i < arguments.length; i++) {
                        arrArguments.push(arguments[i]);
                    }

                    objInitialization.errorEventHandler.apply(this, arrArguments);
                }
            }
        },
        objInitialization.options // Pass options
        );
    }
}
/// </method>

function DeviceIntegrator_InvokeDefaultErrorEvent(intComponentID, strMethodKey, objError) {
    var objEvent = vwgContext.events.createEvent(intComponentID, strMethodKey, null, false);

    vwgContext.events.setEventAttribute(objEvent, "code", objError.code);

    vwgContext.events.raiseEvents();
}

/// <method name="DeviceIntegrator_AddEventListener">
/// <summary>
/// 
/// </summary>
function DeviceIntegrator_AddEventListener(objScope, strEventType, objCallbackArgs) {
    // Try to get function from provided invocation expression.
    var objDelegateOrKey = DeviceIntegrator_ExtractDelegateOrMethodKey(objCallbackArgs[0]);

    // If valid function found..
    if (objDelegateOrKey.delegate) {
        // Copy arguments to array
        var arrArgs = [];
        for (var i = 1; i < objCallbackArgs.length; i++) {
            arrArgs.push(objCallbackArgs[i]);
        }

        // Store callback for removement during DeviceIntegrator.DeviceEvents initialization
        DeviceIntegrator.DeviceEventHandlers[strEventType] = function (batteryInfo) {
            // If this is a battery event callback
            if (batteryInfo && batteryInfo.level && typeof batteryInfo.isPlugged != "undefined") {
                // Add battery info to 1st place in arguments array.
                arrArgs.unshift(batteryInfo);
            }

            // Execute delegate with arguments.
            objDelegateOrKey.delegate.apply(this, arrArgs);

        };

        // Add event listener to provided event type.
        DeviceIntegrator_DeviceReady(function () {
            objScope.addEventListener(strEventType, DeviceIntegrator.DeviceEventHandlers[strEventType], false);
        });
    }
}
/// </method>

/// <method name="DeviceIntegrator_ExtractDelegateOrMethodKey">
/// <summary>
/// Tries to extract function from provided object.
/// </summary>
function DeviceIntegrator_ExtractDelegateOrMethodKey(fncCallbackOrStrMethodKey) {
    if (fncCallbackOrStrMethodKey) {
        // If argument is function, return it.
        if (typeof fncCallbackOrStrMethodKey == 'function') {
            return { isDelegate: true, delegate: fncCallbackOrStrMethodKey };
        }

            // If this is a function name defined on window, return window[name].
        else if (typeof window[fncCallbackOrStrMethodKey] == 'function') {
            return { isDelegate: true, delegate: window[fncCallbackOrStrMethodKey] };
        }

            // If contains namespaces, try to return window[ns1]..[nsN][name]
        else if (fncCallbackOrStrMethodKey.indexOf('.') > 0) {
            var arrSplittedValues = fncCallbackOrStrMethodKey.split('.');

            var fnc = window;

            for (var i = 0; i < arrSplittedValues.length; i++) {
                if (fnc) {
                    if (fnc[arrSplittedValues[i]]) {
                        fnc = fnc[arrSplittedValues[i]];
                    }
                }
                else {
                    break;
                }
            }

            if (typeof fnc == 'function') {
                return { isDelegate: true, delegate: fnc };
            }
        }
    }

    // Otherwise, it is not a function.
    return { isDelegate: false, methodKey: fncCallbackOrStrMethodKey };
}
/// </method>

/// <method name="FileManager_AddEventAttributesFromObject">
/// <summary>
/// 
/// </summary>
function FileManager_AddEventAttributesFromObject(objEvent, strPrefix, objPropertiesContainer) {
    if (objPropertiesContainer && typeof objPropertiesContainer === 'object') {
        for (var strName in objPropertiesContainer) {
            var objValue = objPropertiesContainer[strName];

            if ((objValue && typeof (objValue) !== "function") || objValue === 0) {
                if (objValue instanceof Date) {
                    vwgContext.events.setEventAttribute(objEvent, (strPrefix || "") + strName, objValue);
                }
                else if (typeof (objValue) !== "object") {
                    vwgContext.events.setEventAttribute(objEvent, (strPrefix || "") + strName, objPropertiesContainer[strName]);
                }
            }
        }
    }
}
/// </method>

function FileManager_CreateFileReader()
{
    if (typeof (deviceFileManagerAccess.createFileReader) != "function") {
        DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.FileManager.Id, "createFileReader", "FileManager");
        return null;
    }
    return deviceFileManagerAccess.createFileReader();

}
/// <method name="DeviceIntegrator_TryInvokeClientFileOperation">
/// <summary>
/// 
/// </summary>
function DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackData, objThis) {
    var objClientCallbackData = DeviceIntegrator_ExtractDelegateOrMethodKey(objCallbackData.client);
    if (objClientCallbackData.isDelegate) {
        // Try to create the arguments from an existing arguments array (or an emptry array)
        var arrArguments = [];
        if (Object.prototype.toString.call(objCallbackData.clientp) === "[object Array]") {
            arrArguments = objCallbackData.clientp.slice(0);
        }

        // Insert the callback parameter to the head of the arguments array
        arrArguments.unshift(objEventData);

        // Call the delegate with the arguments
        objClientCallbackData.delegate.apply(objThis || this, arrArguments);
    }
}
    /// </method>


    /* Accelerometer API */
    function Accelerometer_Initialize(strID) {
        // Create device watch data for the accelerometer object
        DeviceIntegrator.Accelerometer = {};

        // Create an empty default options object
        DeviceIntegrator.Accelerometer.defaultOptions = {};
        DeviceIntegrator.Accelerometer.Id = strID;
        DeviceIntegrator.Accelerometer.Node = Data_GetNode(strID);

        // Get frequency context variable
        var strFrequency = "Context.AccelerationFrequency";

        // If defined
        if (strFrequency) {
            var intFrequency = parseInt(strFrequency);
            if (typeof intFrequency === "number") {
                // Create the options
                DeviceIntegrator.Accelerometer.defaultOptions.frequency = intFrequency;
            }
        }

        DeviceIntegrator_DeviceReady(function () {
            if (DeviceIntegrator.Accelerometer.watchKey) {
                if (typeof (deviceAccelerometerAccess.clearWatch) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Accelerometer.Id, "clearWatch", "Accelerometer");
                    return;
                }
                deviceAccelerometerAccess.clearWatch(DeviceIntegrator.Accelerometer.watchKey);
            }

            // Check for critical events - Start the watch only if there are critical events (online or offline)!
            if (Data_IsCriticalEventAttribute(DeviceIntegrator.Accelerometer.Node, "Event.DeviceAccelerometer", true, "Attr.Events")) {
                // Invoke the PG's watch acceleration API
                if (typeof (deviceAccelerometerAccess.watchAcceleration) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Accelerometer.Id, "watchAcceleration", "Accelerometer");
                    return;
                }
                DeviceIntegrator.Accelerometer.watchKey = deviceAccelerometerAccess.watchAcceleration(function (objAcceleration) {
                    if (strID && DeviceIntegrator.Accelerometer.Node) {
                        var objEvent = Accelerometer_GetDefaultSuccessEvent("Tags.Accelerometer", objAcceleration);

                        DeviceIntegrator_RaiseEvent(objEvent, DeviceIntegrator.Accelerometer.Node, "Event.DeviceAccelerometer");
                    }
                },
                    function () {
                        if (strID && DeviceIntegrator.Accelerometer.Node) {
                            var objEvent = Accelerometer_GetDefaultErrorEvent();

                            DeviceIntegrator_RaiseEvent(objEvent, DeviceIntegrator.Accelerometer.Node, "Event.DeviceAccelerometer");
                        }
                    },
                    DeviceIntegrator.Accelerometer.defaultOptions
                );
            }
        });

        /// <method name="DeviceIntegrator.Accelerometer.getCurrentAcceleration">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Accelerometer.getCurrentAcceleration = function () {
            var objArguments = arguments;
            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];
                // Push the relevant function to watch the acceleration
                if (typeof (deviceAccelerometerAccess.getCurrentAcceleration) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Accelerometer.Id, "getCurrentAcceleration", "Accelerometer");
                    return;
                }
                arrArguments.push(deviceAccelerometerAccess.getCurrentAcceleration);
                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Accelerometer_InvokeAcceleration.apply(this, arrArguments);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Accelerometer.watchAcceleration">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Accelerometer.watchAcceleration = function () {
            var objArguments = arguments;
            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];
                // Push the relevant function to watch the acceleration
                if (typeof (deviceAccelerometerAccess.watchAcceleration) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Accelerometer.Id, "watchAcceleration", "Accelerometer");
                    return;
                }
                arrArguments.push(deviceAccelerometerAccess.watchAcceleration);
                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Accelerometer_InvokeAcceleration.apply(this, arrArguments);
            });
        };
        /// </method>    

        /// <method name="DeviceIntegrator.Accelerometer.clearAccelerationWatch">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Accelerometer.clearAccelerationWatch = function (strWatchID) {
            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceAccelerometerAccess.clearWatch) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Accelerometer.Id, "clearWatch", "Accelerometer");
                    return;
                }
                deviceAccelerometerAccess.clearWatch(strWatchID);
            });
        };
        /// </method>
    }
    /// </method>

    /// <method name="Accelerometer_InvokeAcceleration">
    /// <summary>
    /// 
    /// </summary>
    function Accelerometer_InvokeAcceleration(fncAccelerationFunction, fncCallbackOrStrMethodKey) {
        var objInitialization = DeviceIntegrator_GetInitializationObject(
            fncCallbackOrStrMethodKey,
            arguments,
            2,
            fncAccelerationFunction,
            Accelerometer_ClientSuccessHandler,
            Accelerometer_ErrorCreator,
            Accelerometer_GetDefaultSuccessEvent,
            Accelerometer_GetDefaultErrorEvent,
            DeviceIntegrator.Accelerometer.defaultOptions);

        DeviceIntegrator_Execute(objInitialization);
    }
    /// </method>


    /// <method name="Accelerometer_GetDefaultSuccessEvent">
    /// <summary>
    /// Create an event from the acceleration arguments
    /// </summary>
    function Accelerometer_GetDefaultSuccessEvent(strMethodKey, objAcceleration) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Accelerometer.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "X", objAcceleration.x);
        vwgContext.events.setEventAttribute(objEvent, "Y", objAcceleration.y);
        vwgContext.events.setEventAttribute(objEvent, "Z", objAcceleration.z);
        vwgContext.events.setEventAttribute(objEvent, "timeStamp", objAcceleration.timestamp);

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="Accelerometer_GetDefaultErrorEvent">
    /// <summary>
    /// 
    /// </summary>
    function Accelerometer_GetDefaultErrorEvent(strMethodKey) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Accelerometer.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "code", -1);
        vwgContext.events.setEventAttribute(objEvent, "message", "Acceleration Error");

        vwgContext.events.raiseEvents();
    }
    /// </method>

    function Accelerometer_ClientSuccessHandler(objArguments, objAcceleration) {
        if (objArguments) {
            if (objArguments.returnValue) {
                objAcceleration.watchID = objArguments.returnValue;
            }

            if (objArguments.callback) {
                objArguments.callback(objAcceleration);
            }
        }
    }

    function Accelerometer_ErrorCreator() {
        return DeviceIntegrator_GetExceptionObject(0, "Accelerometer error");
    }


    /* Camera API */
    /// <method name="Camera_Initialize">
    /// <summary>
    /// 
    /// </summary>
    function Camera_Initialize(strID) {
        // Create the 'Camera' namespace
        DeviceIntegrator.Camera = {};

        // Store the component's ID
        DeviceIntegrator.Camera.Id = strID;

        /// </method>

        /// <method name="DeviceIntegrator.Camera.cleanup">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Camera.cleanup = function (fncCallbackOrStrMethodKey) {
            var arrArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceCameraAccess.cleanup) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Camera.Id, "cleanup", "Camera");
                    return;
                }

                var objInitialization = DeviceIntegrator_GetInitializationObject(
                fncCallbackOrStrMethodKey,
                arrArguments,
                1,
                deviceCameraAccess.cleanup,
                null,
                function (strMessage) { return strMessage; },
                Camera_OnlineSuccessHandler,
                Camera_GetDefaultErrorEvent);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Camera.getPicture">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Camera.getPicture = function (fncCallbackOrStrMethodKey, objOptions) {
            var arrArguments = arguments;
            var fncSuccessHandler = Camera_OnlineSuccessHandler;

            DeviceIntegrator_DeviceReady(function () {
                // Pre-process options:
                if (objOptions && objOptions.destinationType == 2 /* both */) {
                    objOptions.originalDestinationType = 2;
                    objOptions.destinationType = Camera.DestinationType.FILE_URI;
                }
                if (typeof (deviceCameraAccess.getPicture) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Camera.Id, "getPicture", "Camera");
                    return;
                }

                var objInitialization = DeviceIntegrator_GetInitializationObject(
                                        fncCallbackOrStrMethodKey,
                                        arrArguments,
                                        2,
                                        deviceCameraAccess.getPicture,
                                        Camera_ClientSuccessHandler,
                                        Camera_ErrorArgumentCreator,
                                        fncSuccessHandler,
                                        Camera_GetDefaultErrorEvent,
                                        objOptions);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>
    }
    /// </method>

    /// <method name="Camera_OnlineSuccessHandler">
    /// <summary>
    /// Create an event from the acceleration arguments
    /// </summary>
    function Camera_OnlineSuccessHandler(strMethodKey, objImageData) {
        var objThis = this;
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Camera.Id, strMethodKey, null, true);

        if (objImageData) {
            if (this && this.destinationType == Camera.DestinationType.DATA_URL) {
                vwgContext.events.setEventValue(objEvent, objImageData);
                // Raise
                vwgContext.events.raiseEvents();
            }
            else {
                Camera_GetFileEntryFromContentPath(objImageData,
                    function (objFileEntry) {
                        vwgContext.events.setEventAttribute(objEvent, "FileUri", Camera_RemoveFilePrefixFromFilePath(objFileEntry.fullPath));

                        if (objThis && objThis.originalDestinationType == 2) // objImageData must be a file Uri
                        {
                            objFileEntry.file(
                                function (objFile) {
                                    // Create a reader for the file
                                    var reader = FileManager_CreateFileReader();
                                    if (reader == null){
                                        return;
                                    }
                                    reader.onloadend = function (evt) {
                                        var objResult = evt.target.result;

                                        // When reading a file, phonegap add the file's mimeType at the beginning + ',' to seperate it from the REAL Base64 string so we remove it before uploading to hte server.
                                        var intMimeTypeIndex = objResult.indexOf(",");
                                        if (intMimeTypeIndex > 0) {
                                            objResult = objResult.substring(intMimeTypeIndex + 1, objResult.length);
                                        }

                                        vwgContext.events.setEventValue(objEvent, objResult);

                                        // Raise
                                        vwgContext.events.raiseEvents();
                                    };

                                    reader.readAsDataURL(objFile);
                                },
                                function () { console.log("Client camera handler error"); }
                            );
                        }
                        else {
                            // Raise
                            vwgContext.events.raiseEvents();
                        }
                    },
                    function () { }
                );
            }
        }
    }
    /// </method>

    /// <method name="Camera_RemoveFilePrefixFromFilePath">
    /// <summary>
    /// 
    /// </summary>
    function Camera_RemoveFilePrefixFromFilePath(strFilePath) {
        return /file:\/\/.*?(\/.*)/.exec(strFilePath)[1];
    }
    /// </method>

    /// <method name="Camera_GetDefaultErrorEvent">
    /// <summary>
    /// Create an event from the acceleration arguments
    /// </summary>
    function Camera_GetDefaultErrorEvent(strMethodKey, strMessage) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Camera.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "code", 1);
        vwgContext.events.setEventAttribute(objEvent, "message", strMessage);

        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="Camera_ClientSuccessHandler">
    /// <summary>
    /// 
    /// </summary>
    function Camera_ClientSuccessHandler(objReturnValue, strImage) {
        // Check if there's a "Client-callback" function
        if (objReturnValue.callback) {
            // Check if the user asked for both FileUri and DataUrl
            if (this && this.originalDestinationType == 2) {
                Camera_GetFileEntryFromContentPath(strImage, function (objFileEntry) {
                    objFileEntry.file(
                        function (objFile) {
                            var reader = FileManager_CreateFileReader();
                            if (reader == null) {
                                return;
                            }
                            reader.onloadend = function (evt) {
                                // At the end, call the callback with both FileUri and DataUrl
                                objReturnValue.callback({ "FileUri": strImage, "FileData": evt.target.result });
                            };

                            reader.readAsDataURL(objFile);
                        },
                        function () { console.log("Client camera handler error"); }
                    );
                }, function () { console.log("Client camera handler error"); });
            }
            else {
                objReturnValue.callback(strImage);
            }
        }
    }
    /// </method>

    /// <method name="Camera_GetFileEntryFromContentPath">
    /// <summary>
    /// 
    /// </summary>
    function Camera_GetFileEntryFromContentPath(strPath, fncSuccess, fncFail) {
        DeviceIntegrator_DeviceReady(function () {
            // Requext the file system
            window.requestFileSystem(LocalFileSystem.PERSISTENT, 0,
                function (objFileSystem) {
                    if (window.resolveLocalFileSystemURI) {
                        // Resolve the file URI
                        window.resolveLocalFileSystemURI(strPath, fncSuccess, fncFail); // strPath - must be FileUri
                    }
                }, function () { console.log("Client camera handler error"); });
        });
    }
    /// </method>

    function Camera_ErrorArgumentCreator(strMessage) {
        return DeviceIntegrator_GetExceptionObject(0, strMessage);
    }


    /* Capture API */
    function Capture_Initialize(strId) {
        // Create device watch data for the DeviceInfo object
        DeviceIntegrator.Capture = {};

        // Store id
        DeviceIntegrator.Capture.Id = strId;

        DeviceIntegrator.Capture.ServerIdsToClientIds = {};

        /// </method>

        /// <method name="DeviceIntegrator.Capture.getFormatData">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Capture.getFormatData = function (fncCallbackOrStrMethodKey, strFullPath, strType) {
            var arrArguments = arguments;
            DeviceIntegrator_DeviceReady(function () {
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                fncCallbackOrStrMethodKey,
                arrArguments,
                3,
                function (fncSuccess, fncError) {
                    if (typeof (deviceCaptureAccess.getFormatData) != "function") {
                        DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Capture.Id, "getFormatData", "Capture");
                        return;
                    }

                    deviceCaptureAccess.getFormatData({ "fullPath": strFullPath, "type": strType }, fncSuccess, fncError);
                },
                null,
                null,
                function (strMethodKey, objMediaFileData) {
                    var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Capture.Id, strMethodKey, null, false);

                    FileManager_AddEventAttributesFromObject(objEvent, null, objMediaFileData);

                    vwgContext.events.raiseEvents();
                },
                function (strMethodKey, objError) {
                    DeviceIntegrator_InvokeDefaultErrorEvent(DeviceIntegrator.Capture.Id, strMethodKey, objError);
                });

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Capture.capture">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Capture.capture = function (strMethod, fncCallbackOrStrMethodKey, objOptions) {
            var arrArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                fncCallbackOrStrMethodKey,
                arrArguments,
                3,
                deviceCaptureAccess[strMethod],
                null,
                null,
                function (strMethodKey, arrMediaFiles) {
                    if (arrMediaFiles) {
                        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Capture.Id, strMethodKey, null, false);

                        var intCount = arrMediaFiles.length;

                        vwgContext.events.setEventAttribute(objEvent, "count", intCount);

                        for (var i = 0; i < intCount; i++) {
                            var objMediaFile = arrMediaFiles[i];
                            if (parseInt(objMediaFile.lastModifiedDate, 10) > 0) {
                                objMediaFile.lastModifiedDate = "\/Date(" + objMediaFile.lastModifiedDate + ")\/";
                            }
                            vwgContext.events.setEventAttribute(objEvent, "cap" + i, JSON.stringify(objMediaFile));
                        }

                        vwgContext.events.raiseEvents();
                    }
                },
                function (strMethodKey, objError) {
                    DeviceIntegrator_InvokeDefaultErrorEvent(DeviceIntegrator.Capture.Id, strMethodKey, objError);
                },
                objOptions
                );

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>
    }


    /* Compass API */
    /// <method name="Compass_Initialize">
    /// <summary>
    /// 
    /// </summary>
    function Compass_Initialize(strID) {
        // Create device watch data for the Compass object
        DeviceIntegrator.Compass = {};

        // Create an empty default options object
        DeviceIntegrator.Compass.defaultOptions = {};
        DeviceIntegrator.Compass.Id = strID;
        DeviceIntegrator.Compass.Node = Data_GetNode(strID);

        // Get frequency context variable
        var strFrequency = "Context.CompassFrequency";

        // If defined
        if (strFrequency) {
            var intFrequency = parseInt(strFrequency, 10);

            if (typeof intFrequency === "number") {
                // Create the options
                DeviceIntegrator.Compass.defaultOptions.frequency = intFrequency;
            }
        }

        DeviceIntegrator_DeviceReady(function () {
            if (DeviceIntegrator.Compass.watchKey) {
                if (typeof (deviceCompassAccess.clearWatch) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Compass.Id, "clearWatch", "Compass");
                    return;
                }
                deviceCompassAccess.clearWatch(DeviceIntegrator.Compass.watchKey);
            }

            // Check for critical events - Start the watch only if there are critical events.
            if (Data_IsCriticalEventAttribute(DeviceIntegrator.Compass.Node, "Event.DeviceCompass", true, "Attr.Events")) {
                // Invoke the PG's watch CompassHeading API
                if (typeof (deviceCompassAccess.watchHeading) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Compass.Id, "watchHeading", "Compass");
                    return;
                }
                DeviceIntegrator.Compass.watchKey = deviceCompassAccess.watchHeading(function (objCompassHeading) {
                    if (strID && DeviceIntegrator.Compass.Node) {
                        var objEvent = Compass_GetDefaultSuccessEvent("Tags.Compass", objCompassHeading);

                        DeviceIntegrator_RaiseEvent(objEvent, DeviceIntegrator.Compass.Node, "Event.DeviceCompass");
                    }
                },
                    function () {
                        if (strID && DeviceIntegrator.Compass.Node) {
                            var objEvent = Compass_GetDefaultErrorEvent();

                            DeviceIntegrator_RaiseEvent(objEvent, DeviceIntegrator.Compass.Node, "Event.DeviceCompass");
                        }
                    }, DeviceIntegrator.Compass.defaultOptions);
            }
        });

        /// <method name="DeviceIntegrator.Compass.getCurrentHeading">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Compass.getCurrentHeading = function () {
            var objArguments = arguments;
            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];
                // Push the relevant function to watch the CompassHeading
                if (typeof (deviceCompassAccess.getCurrentHeading) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Compass.Id, "getCurrentHeading", "Compass");
                    return;
                }
                arrArguments.push(deviceCompassAccess.getCurrentHeading);
                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Compass_InvokeCompassHeading.apply(this, arrArguments);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Compass.watchHeading">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Compass.watchHeading = function () {
            var objArguments = arguments;
            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];
                // Push the relevant function to watch the CompassHeading
                if (typeof (deviceCompassAccess.watchHeading) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Compass.Id, "watchHeading", "Compass");
                    return;
                }
                arrArguments.push(deviceCompassAccess.watchHeading);
                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Compass_InvokeCompassHeading.apply(this, arrArguments);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Compass.clearHeadingWatch">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Compass.clearHeadingWatch = function (strWatchID) {
            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceCompassAccess.clearWatch) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Compass.Id, "clearWatch", "Compass");
                    return;
                }
                deviceCompassAccess.clearWatch(strWatchID);
            });
        };
        /// </method>
    }
    /// </method>

    /// <method name="Compass_InvokeCompassHeading">
    /// <summary>
    /// 
    /// </summary>
    function Compass_InvokeCompassHeading(fncCompassHeadingFunction, fncCallbackOrStrMethodKey) {
        var objInitialization = DeviceIntegrator_GetInitializationObject(
            fncCallbackOrStrMethodKey,
            arguments,
            2,
            fncCompassHeadingFunction,
            Compass_ClientSuccessHandler,
            Compass_ErrorCreator,
            Compass_GetDefaultSuccessEvent,
            Compass_GetDefaultErrorEvent,
            DeviceIntegrator.Compass.defaultOptions);

        DeviceIntegrator_Execute(objInitialization);
    }
    /// </method>


    /// <method name="Compass_GetDefaultSuccessEvent">
    /// <summary>
    /// Create an event from the CompassHeading arguments
    /// </summary>
    function Compass_GetDefaultSuccessEvent(strMethodKey, objCompassHeading) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Compass.Id, strMethodKey, null, true);
        if (objCompassHeading) {
            vwgContext.events.setEventAttribute(objEvent, "magneticHeading", objCompassHeading.magneticHeading);
            vwgContext.events.setEventAttribute(objEvent, "trueHeading", objCompassHeading.magneticHeading);
            vwgContext.events.setEventAttribute(objEvent, "headingAccuracy", objCompassHeading.headingAccuracy);
            vwgContext.events.setEventAttribute(objEvent, "timeStamp", objCompassHeading.timestamp);
        }

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="Compass_GetDefaultErrorEvent">
    /// <summary>
    /// 
    /// </summary>
    function Compass_GetDefaultErrorEvent(strMethodKey, objCompassError) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Compass.Id, strMethodKey, null, true);

        if (objCompassError) {
            // 0 - internal error; 20 - compass not supported
            vwgContext.events.setEventAttribute(objEvent, "code", objCompassError.code);
        }
        vwgContext.events.raiseEvents();
    }
    /// </method>

    function Compass_ClientSuccessHandler(objArguments, objCompassHeading) {
        if (objArguments) {
            if (objArguments.returnValue) {
                objCompassHeading.watchID = objArguments.returnValue;
            }

            if (objArguments.callback) {
                objArguments.callback(objCompassHeading);
            }
        }
    }

    /// <method name="Compass_ErrorCreator">
    /// <summary>
    /// 
    /// </summary>
    function Compass_ErrorCreator(objError) {
        return objError;
    }
    /// </method>


    /* Connection API */
    // Create the connection object only ifthe main 'DeviceIntegrator' exists
    function Connection_Initialize(strID) {
        // Create device watch data for the connection object
        DeviceIntegrator.Connection = {};

        // Create an empty default options object
        DeviceIntegrator.Connection.defaultOptions = {};
        DeviceIntegrator.Connection.Id = strID;

        /// <method name="DeviceIntegrator.Connection.getConnection">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Connection.getConnection = function (strMethodKey) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceConnectionAccess.getConnectionType) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Connection.Id, "getConnectionType", "Connection");
                    return;
                }
                var strConnectionType = deviceConnectionAccess.getConnectionType();
                Connection_GetDefaultSuccessEvent(strMethodKey, strConnectionType);
            });
        };
        /// </method>
    }
    /// </method>

    /// <method name="Connection_GetDefaultSuccessEvent">
    /// <summary>
    /// Create an event from the connection arguments
    /// </summary>
    function Connection_GetDefaultSuccessEvent(strMethodKey, strConnectionType) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Connection.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "NetworkState", strConnectionType);

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>


    /* Contacts API */
    /// <method name="Contacts_Initialize">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_Initialize(strID) {
        // Create device watch data for the Contacts object
        DeviceIntegrator.Contacts = {};

        DeviceIntegrator.Contacts.Id = strID;

        // Get Contacts node.
        DeviceIntegrator.Contacts.Node = Data_GetNode(strID);

        // Remove contact
        DeviceIntegrator.Contacts.removeContact = function (strMethodKey, objContactInfo) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];

                var objContact = Contacts_CreateContact(objContactInfo);

                arrArguments.push(function (success, error) { objContact.remove(success, error); });

                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Contacts_InvokeRemoveContactFunction.apply(this, arrArguments);
            });
        };

        // Save contact
        DeviceIntegrator.Contacts.saveContact = function (strMethodKey, objContactInfo) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];

                var objContact = Contacts_CreateContact(objContactInfo);

                arrArguments.push(function (success, error) { objContact.save(success, error); });

                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Contacts_InvokeSaveContactFunction.apply(this, arrArguments);
            });
        };

        // Find contacts
        DeviceIntegrator.Contacts.findContacts = function (strMethodKey, objContactFindOptionsData) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];

                var objContactFindOptions = Contacts_CreateFindOptions(objContactFindOptionsData);

                var arrFields = objContactFindOptionsData.fields || ["id"];

                if (typeof (deviceContactsAccess.find) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Contacts.Id, "find", "Contacts");
                    return;
                }
                arrArguments.push(function (success, error) { deviceContactsAccess.find(arrFields, success, error, objContactFindOptions); });

                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Contacts_InvokeFindContactsFunction.apply(this, arrArguments);
            });
        };
    }

    function Contacts_InvokeFindContactsFunction(fncInvocationFunction, strMethodKey) {
        var objInitialization = DeviceIntegrator_GetInitializationObject(
            strMethodKey,
            arguments,
            2,
            fncInvocationFunction,
            Contacts_ClientFindSuccessHandler,
            Contacts_ErrorCreator,
            Contacts_GetDefaultFindSuccessEvent,
            Contacts_GetDefaultErrorEvent,
            null);

        DeviceIntegrator_Execute(objInitialization);
    }


    function Contacts_ClientFindSuccessHandler(objArguments, arrContacts) {
        if (objArguments) {
            if (objArguments.callback) {
                objArguments.callback(arrContacts);
            }
        }
    }
    /// </method>

    function Contacts_GetDefaultFindSuccessEvent(strMethodKey, arrContacts) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Contacts.Id, strMethodKey, null, true);
        if (arrContacts && arrContacts.length > 0) {
            for (var i = 0; i < arrContacts.length; i++) {
                if (arrContacts[i].birthday) {
                    if (parseInt(arrContacts[i].birthday, 10) > 0) {
                        arrContacts[i].birthday = "\/Date(" + arrContacts[i].birthday + ")\/";
                    }
                }

                vwgContext.events.setEventAttribute(objEvent, "contact" + i, JSON.stringify(arrContacts[i]));
            }

            vwgContext.events.setEventAttribute(objEvent, "contacts", arrContacts.length);

        }

        vwgContext.events.raiseEvents();
    }
    /// </method>

    function Contacts_GetDefaultSuccessEvent(strMethodKey, objContact) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Contacts.Id, strMethodKey, null, true);

        vwgContext.events.raiseEvents();
    }

    /// <method name="Contacts_InvokeSaveContactFunction">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_InvokeSaveContactFunction(fncInvocationFunction, strMethodKey, objContactInfo) {
        var objInitialization = DeviceIntegrator_GetInitializationObject(
            strMethodKey,
            arguments,
            3,
            fncInvocationFunction,
            Contacts_ClientDefaultSuccessHandler,
            Contacts_ErrorCreator,
            Contacts_GetDefaultSaveSuccessEvent,
            Contacts_GetDefaultErrorEvent,
            null);

        DeviceIntegrator_Execute(objInitialization);
    }
    /// </method>

    /// <method name="Contacts_InvokeRemoveContactFunction">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_InvokeRemoveContactFunction(fncInvocationFunction, strMethodKey) {

        var objInitialization = DeviceIntegrator_GetInitializationObject(
            strMethodKey,
            arguments,
            2,
            fncInvocationFunction,
            Contacts_ClientDefaultSuccessHandler,
            Contacts_ErrorCreator,
            Contacts_GetDefaultSuccessEvent,
            Contacts_GetDefaultErrorEvent,
            null);

        DeviceIntegrator_Execute(objInitialization);
    }
    /// </method>

    /// <method name="Contacts_ClientDefaultSuccessHandler">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_ClientDefaultSuccessHandler(objArguments, objContact) {
        if (objArguments) {
            if (objArguments.callback) {
                return objArguments.callback(objContact);
            }
        }
    }
    /// </method>

    /// <method name="Contacts_ErrorCreator">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_ErrorCreator(objError) {
        return objError;
    }
    /// </method>

    /// <method name="Contacts_GetDefaultSaveSuccessEvent">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_GetDefaultSaveSuccessEvent(strMethodKey, objContact) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Contacts.Id, strMethodKey, null, true);
        if (objContact) {
            vwgContext.events.setEventAttribute(objEvent, "contactId", objContact.id);
        }

        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="Contacts_GetDefaultErrorEvent">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_GetDefaultErrorEvent(strMethodKey, objContactError) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Contacts.Id, strMethodKey, null, true);

        if (objContactError) {
            vwgContext.events.setEventAttribute(objEvent, "code", objContactError.code);
        }
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="Contacts_CreateContact">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_CreateContact(objContactInfo) {
        // If it is already a contact, return
        if (Contacts_IsContact(objContactInfo)) {
            return objContactInfo;
        }

        // Create empty contact 
        if (typeof (deviceContactsAccess.create) != "function") {
            DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Contacts.Id, "create", "Contacts");
            return;
        }
        var objContact = deviceContactsAccess.create();

        // Fill properties

        // Addresses
        if (objContactInfo.addresses) {
            objContact.addresses = Contacts_MapArrayToContactProperty(objContactInfo.addresses, ContactAddress);
        }

        // Name
        if (objContactInfo.name) {
            if (typeof (deviceContactsAccess.createContactName) != "function") {
                DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Contacts.Id, "createContactName", "Contacts");
                return;
            }
            objContact.name = deviceContactsAccess.createContactName();
            Contacts_CopyObjectProperties(objContact.name, objContactInfo.name);
        }

        // Organizations
        if (objContactInfo.organizations) {
            objContact.organizations = Contacts_MapArrayToContactProperty(objContactInfo.organizations, ContactOrganization);
        }

        // IMs
        if (objContactInfo.ims) {
            objContact.ims = Contacts_MapArrayToContactProperty(objContactInfo.ims, ContactField);
        }

        // URLs
        if (objContactInfo.urls) {
            objContact.urls = Contacts_MapArrayToContactProperty(objContactInfo.urls, ContactField);
        }

        // ID
        if (objContactInfo.id) {
            objContact.id = objContactInfo.id;
        }

        // DisplayName
        if (objContactInfo.displayName) {
            objContact.displayName = objContactInfo.displayName;
        }

        // Nickname
        if (objContactInfo.nickname) {
            objContact.nickname = objContactInfo.nickname;
        }

        // PhoneNumbers
        if (objContactInfo.phoneNumbers) {
            objContact.phoneNumbers = Contacts_MapArrayToContactProperty(objContactInfo.phoneNumbers, ContactField);
        }

        // Emails
        if (objContactInfo.emails) {
            objContact.emails = Contacts_MapArrayToContactProperty(objContactInfo.emails, ContactField);
        }

        // Birthday
        if (objContactInfo.birthday) {
            objContact.birthday = objContactInfo.birthday;
        }

        // Note
        if (objContactInfo.note) {
            objContact.note = objContactInfo.note;
        }

        // Photos
        if (objContactInfo.photos) {
            objContact.photos = Contacts_MapArrayToContactProperty(objContactInfo.photos, ContactField);
        }

        // Categories
        if (objContactInfo.categories) {
            objContact.categories = Contacts_MapArrayToContactProperty(objContactInfo.categories, ContactField);
        }

        return objContact;
    }
    /// </method>

    /// <method name="Contacts_MapArrayToContactProperty">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_MapArrayToContactProperty(arrContactInfoArray, fncContactArrayMember) {
        return arrContactInfoArray.map(
        function (arrayMember) {
            var objContactArrayMember = new fncContactArrayMember();
            Contacts_CopyObjectProperties(objContactArrayMember, arrayMember);
            return objContactArrayMember;
        });
    }
    /// </method>

    /// <method name="Contacts_CopyObjectProperties">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_CopyObjectProperties(objTargetObject, objSourceObject) {
        for (property in objSourceObject) {
            objTargetObject[property] = objSourceObject[property];
        }
    }
    /// </method>

    /// <method name="Contacts_IsContact">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_IsContact(objContactInfo) {
        return typeof objContactInfo.clone === "function" &&
        typeof objContactInfo.save === "function" &&
        typeof objContactInfo.remove === "function";
    }
    /// </method>

    /// <method name="Contacts_CreateFindOptions">
    /// <summary>
    /// 
    /// </summary>
    function Contacts_CreateFindOptions(objFindOptionsData) {
        if (typeof (deviceContactsAccess.createContactFindOptions) != "function") {
            DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Contacts.Id, "createContactFindOptions", "Contacts");
            return;
        }
        var objFindOptions = deviceContactsAccess.createContactFindOptions();

        objFindOptions.filter = objFindOptionsData.filter || "";
        objFindOptions.multiple = objFindOptionsData.multiple || false;

        return objFindOptions;
    }
    /// </method>


    /* Device Events API */
    // Create device watch data for the DeviceEvents object
    DeviceIntegrator.DeviceEvents = {};

    /// <method name="DeviceEvents_Initialize">
    /// <summary>
    /// 
    /// </summary>
    function DeviceEvents_Initialize(strID) {
        DeviceIntegrator.DeviceEvents.Id = strID;

        // Get DeviceEvents node.
        DeviceIntegrator.DeviceEvents.Node = Data_GetNode(strID);

        // Register critical server events.

        // Pause
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DevicePause", DeviceIntegrator.DeviceEvents.pause, "pause");

        // Resume
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceResume", DeviceIntegrator.DeviceEvents.resume, "resume");

        // Online
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceOnline", DeviceIntegrator.DeviceEvents.online, "online");

        // Offline
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceOffline", DeviceIntegrator.DeviceEvents.offline, "offline");

        // BackButton
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceBackButton", DeviceIntegrator.DeviceEvents.backButtonPressed, "backbutton");

        // BatteryCritical
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceBatteryCritical", DeviceIntegrator.DeviceEvents.batteryCritical, "batterycritical");

        // BatteryLow
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceBatteryLow", DeviceIntegrator.DeviceEvents.batteryLow, "batterylow");

        // BatteryStatus
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceBatteryStatus", DeviceIntegrator.DeviceEvents.batteryStatusChanged, "batterystatus");

        // MenuButton
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceMenuButton", DeviceIntegrator.DeviceEvents.menuButtonPressed, "menubutton");

        // SearchButton
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceSearchButton", DeviceIntegrator.DeviceEvents.searchButtonPressed, "searchbutton");

        // StartCallButton
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceStartCallButton", DeviceIntegrator.DeviceEvents.startCallButtonPressed, "startcallbutton");

        // EndCallButton
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceEndCallButton", DeviceIntegrator.DeviceEvents.endCallButtonPressed, "endcallbutton");

        // VolumeDownButton
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceVolumeDownButton", DeviceIntegrator.DeviceEvents.volumeDownButtonPressed, "volumedownbutton");

        // VolumeUpButton
        DeviceEvents_RegisterCriticalEvent(DeviceIntegrator.DeviceEvents.Node, DeviceIntegrator.DeviceEvents.Id, "Event.DeviceVolumeUpButton", DeviceIntegrator.DeviceEvents.volumeUpButtonPressed, "volumeUpButton");
    }
    /// </method>

    /// <method name="DeviceEvents_RegisterCriticalEvent">
    /// <summary>
    /// 
    /// </summary>
    function DeviceEvents_RegisterCriticalEvent(objDeviceEventsNode, strID, cntEventType, fncInvocationFunction, strEventType) {
        // If Event Type is critical
        if (Data_IsCriticalEventAttribute(objDeviceEventsNode, cntEventType, true, "Attr.Events")) {
            // If valid invocation function supplied         
            if (typeof fncInvocationFunction == "function") {
                // Unregister listener if exists (provides single listener for server events)
                if (DeviceIntegrator.DeviceEventHandlers[strEventType]) {
                    if (strEventType.indexOf("battery") != -1) {
                        window.removeEventListener(strEventType, DeviceIntegrator.DeviceEventHandlers[strEventType], false);
                    }
                    else {
                        document.removeEventListener(strEventType, DeviceIntegrator.DeviceEventHandlers[strEventType], false);
                    }
                }

                // Invoke provided function
                fncInvocationFunction(
                    // Callback for server events
                    function (batteryInfo) {
                        if (strID && objDeviceEventsNode) {
                            // Create server event.
                            var objEvent = vwgContext.events.createEvent(strID, cntEventType, null, true);


                            // Set attributes if exist (battery events only).
                            if (batteryInfo && batteryInfo.level && typeof batteryInfo.isPlugged != "undefined") {
                                vwgContext.events.setEventAttribute(objEvent, "level", batteryInfo.level);
                                vwgContext.events.setEventAttribute(objEvent, "isPlugged", batteryInfo.isPlugged);
                            }

                            // Raise event
                            DeviceIntegrator_RaiseEvent(objEvent, objDeviceEventsNode, cntEventType);
                        }
                    }
                );
            }
        }
    }
    /// </method>

    /// <method name="DeviceIntegrator.backButtonPressed">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.backButtonPressed = function () {
        DeviceIntegrator_AddEventListener(document, "backbutton", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.batteryCritical">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.batteryCritical = function () {
        DeviceIntegrator_AddEventListener(window, "batterycritical", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.batteryLow">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.batteryLow = function () {
        DeviceIntegrator_AddEventListener(window, "batterylow", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.batteryStatusChanged">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.batteryStatusChanged = function () {
        DeviceIntegrator_AddEventListener(window, "batterystatus", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.endCallButtonPressed">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.endCallButtonPressed = function () {
        DeviceIntegrator_AddEventListener(document, "endcallbutton", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.menuButtonPressed">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.menuButtonPressed = function () {
        DeviceIntegrator_AddEventListener(document, "menubutton", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.offline">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.offline = function () {
        DeviceIntegrator_AddEventListener(document, "offline", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.online">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.online = function () {
        DeviceIntegrator_AddEventListener(document, "online", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.pause">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.pause = function () {
        DeviceIntegrator_AddEventListener(document, "pause", arguments);
    };

    /// <method name="DeviceIntegratorImpl.resume">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.resume = function () {
        DeviceIntegrator_AddEventListener(document, "resume", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.searchButtonPressed">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.searchButtonPressed = function () {
        DeviceIntegrator_AddEventListener(document, "searchbutton", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.startCallButtonPressed">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.startCallButtonPressed = function () {
        DeviceIntegrator_AddEventListener(document, "startcallbutton", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.volumeDownButtonPressed">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.volumeDownButtonPressed = function () {
        DeviceIntegrator_AddEventListener(document, "volumedownbutton", arguments);
    };
    /// </method>

    /// <method name="DeviceIntegratorImpl.volumeUpButtonPressed">
    /// <summary>
    /// 
    /// </summary>
    DeviceIntegrator.DeviceEvents.volumeUpButtonPressed = function () {
        DeviceIntegrator_AddEventListener(document, "volumeupbutton", arguments);
    };
    /// </method>


    /* Device Info API */
    // Create the DeviceInfo object only if the main 'DeviceIntegrator' exists
    function DeviceInfo_Initialize(strID) {
        // Create device watch data for the DeviceInfo object
        DeviceIntegrator.DeviceInfo = {};

        // Create an empty default options object
        DeviceIntegrator.DeviceInfo.defaultOptions = {};
        DeviceIntegrator.DeviceInfo.Id = strID;

        /// <method name="DeviceIntegrator.DeviceInfo.getDeviceInfo">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.DeviceInfo.getDeviceInfo = function (strMethodKey) {
            DeviceIntegrator_DeviceReady(function () {
                //Check that deviceInfoAccess functions are defined
                if (typeof (deviceInfoAccess.getModel) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.DeviceInfo.Id, "getModel", "DeviceInfo");
                    return;
                }
                if (typeof (deviceInfoAccess.getScriptVersion) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.DeviceInfo.Id, "getScriptVersion", "DeviceInfo");
                    return;
                }
                if (typeof (deviceInfoAccess.getPlatform) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.DeviceInfo.Id, "getPlatform", "DeviceInfo");
                    return;
                }
                if (typeof (deviceInfoAccess.getUUID) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.DeviceInfo.Id, "getUUID", "DeviceInfo");
                    return;
                }
                if (typeof (deviceInfoAccess.getVersion) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.DeviceInfo.Id, "getVersion", "DeviceInfo");
                    return;
                }

                var objDeviceInfo = {
                    Name: deviceInfoAccess.getModel(),
                    JavascriptVersion: deviceInfoAccess.getScriptVersion(),
                    Platform: deviceInfoAccess.getPlatform(),
                    UUID: deviceInfoAccess.getUUID(),
                    Version: deviceInfoAccess.getVersion()
                };

                if (typeof strMethodKey != 'undefined') {
                    DeviceInfo_GetDefaultSuccessEvent(strMethodKey, objDeviceInfo);
                    return;
                }
                return objDeviceInfo;
            });
        };
        /// </method>
    }
    /// </method>

    /// <method name="Accelerometer_GetDefaultSuccessEvent">
    /// <summary>
    /// Create an event from the acceleration arguments
    /// </summary>
    function DeviceInfo_GetDefaultSuccessEvent(strMethodKey, objDeviceInfo) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.DeviceInfo.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "Name", objDeviceInfo.Name);
        vwgContext.events.setEventAttribute(objEvent, "JavascriptVersion", objDeviceInfo.Cordova);
        vwgContext.events.setEventAttribute(objEvent, "Platform", objDeviceInfo.Platform);
        vwgContext.events.setEventAttribute(objEvent, "UUID", objDeviceInfo.UUID);
        vwgContext.events.setEventAttribute(objEvent, "Version", objDeviceInfo.Version);

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>



    /* FileManager API */

    function FileManager_Initialize(strID) {
        DeviceIntegrator.FileManager = {};

        DeviceIntegrator.FileManager.Id = strID;

        /// <method name="DeviceIntegrator.FileManager.requestFileSystem">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.requestFileSystem = function (intType, intSize, fncCallbackOrStrMethodKey) {
            var arrArguments = arguments;
            DeviceIntegrator_DeviceReady(function () {
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                fncCallbackOrStrMethodKey,
                arrArguments,
                3,
                FileManager_GetRequestFileSystemInvoker(intType, intSize),
                FileManager_RequestFileSystemClientSuccessHandler,
                FileManager_RequestFileSystemClientErrorCreator,
                FileManager_RequestFileSystemSuccessHandler,
                FileManager_RequestFileSystemErrorHandler,
                { "size": intSize, "type": intType });// Send file system initialization attributes in order to send them back to the server

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.getDirectoryByPath">
        /// <summary>
        /// Server invoked getDirectory
        /// </summary>
        DeviceIntegrator.FileManager.getDirectoryByPath = function (strOriginalDirectoryPath, strPath, objFlags, fncCallbackOrStrMethodKey) {
            if (strOriginalDirectoryPath) {
                // Get origianal directory entry
                var objDirectoryEntry = FileManager_GetEntry(strOriginalDirectoryPath, true);

                // Modify args
                var arrArgs = Array.prototype.slice.apply(arguments);
                arrArgs[0] = objDirectoryEntry;

                // Call client API.
                DeviceIntegrator.FileManager.getDirectory.apply(this, arrArgs);
            }
        };
        /// </method>

        DeviceIntegrator.FileManager.getDirectory = function (objDirectoryEntry, strPath, objFlags, fncCallback) {
            DeviceIntegrator_DeviceReady(function () {
                if (objDirectoryEntry) {
                    var objInitialization = FileManager_GetShortedInitializationObject(fncCallback, arguments, 4);

                    if (typeof objDirectoryEntry["getDirectory"] === 'function') {
                        objDirectoryEntry.getDirectory(strPath, objFlags, FileManager_GetSuccessGenericCallback(objInitialization, "ent."), FileManager_GetGenericFileErrorCallback(objInitialization));
                    }
                }
            });
        };

        /// <method name="DeviceIntegrator.FileManager.removeByPath">
        /// <summary>
        /// Server invoked remove
        /// </summary>
        DeviceIntegrator.FileManager.removeByPath = function (strEntryPath, blnIsDirectory, fncCallbackOrStrMethodKey) {
            // Get entry to remove
            var objEntry = FileManager_GetEntry(strEntryPath, blnIsDirectory);

            // Modify args
            var arrArgs = Array.prototype.slice.apply(arguments);
            arrArgs.shift();
            arrArgs.shift();
            arrArgs.unshift(objEntry);

            // Call client API.
            DeviceIntegrator.FileManager.remove.apply(this, arrArgs);
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.remove">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.remove = function (objEntry, fncCallback) {
            if (objEntry) {
                DeviceIntegrator_DeviceReady(function () {
                    var objInitialization = FileManager_GetShortedInitializationObject(fncCallback, arguments, 2);
                    objEntry.remove(FileManager_GetSuccessGenericCallback(objInitialization), FileManager_GetGenericFileErrorCallback(objInitialization));
                });
            }
        };

        /// <method name="DeviceIntegrator.FileManager.toURLByPath">
        /// <summary>
        /// Server invoked toURL
        /// </summary>
        DeviceIntegrator.FileManager.toURLByPath = function (strEntryPath, blnIsDirectory, fncCallbackOrStrMethodKey) {
            var objEntry = FileManager_GetEntry(strEntryPath, blnIsDirectory);

            // Modify args
            var arrArgs = Array.prototype.slice.apply(arguments);
            arrArgs.shift();
            arrArgs.shift();
            arrArgs.unshift(objEntry);

            // Call client API.
            DeviceIntegrator.FileManager.toURL.apply(this, arrArgs);

        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.toURL">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.toURL = function (objEntry, fncCallback) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallback, arguments, 2);
            DeviceIntegrator_DeviceReady(function () {
                var strUrl = objEntry.toURL();
                if (strUrl) {
                    FileManager_GetSuccessGenericCallback(objInitialization)({ "url": strUrl });
                }
                else {
                    FileManager_GetGenericFileErrorCallback(objInitialization)({ "code": 1 });
                }
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.getParentByPath">
        /// <summary>
        /// Server invoked getParent
        /// </summary>
        DeviceIntegrator.FileManager.getParentByPath = function (strEntryPath, blnIsDirectory, fncCallbackOrStrMethodKey) {
            var objEntry = FileManager_GetEntry(strEntryPath, blnIsDirectory);

            // Modify args
            var arrArgs = Array.prototype.slice.apply(arguments);
            arrArgs.shift();
            arrArgs.shift();
            arrArgs.unshift(objEntry);

            // Call client API.
            DeviceIntegrator.FileManager.getParent.apply(this, arrArgs);
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.getParent">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.getParent = function (objEntry, fncCallbackOrStrMethodKey) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallbackOrStrMethodKey, arguments, 2);
            DeviceIntegrator_DeviceReady(function () {
                objEntry.getParent(FileManager_GetSuccessGenericCallback(objInitialization, "ent."), FileManager_GetGenericFileErrorCallback(objInitialization));
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.resolveLocalFileSystemURI">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.resolveLocalFileSystemURI = function (strFileFullPath, fncCallbackOrStrMethodKey) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallbackOrStrMethodKey, arguments, 2);
            DeviceIntegrator_DeviceReady(function () {
                window.resolveLocalFileSystemURI(strFileFullPath, FileManager_GetSuccessGenericCallback(objInitialization, "ent."), FileManager_GetGenericFileErrorCallback(objInitialization));
            });
        };
        /// </method> 

        /// <method name="DeviceIntegrator.FileManager.getFileByPath">
        /// <summary>
        /// Server invoked getFile
        /// </summary>
        DeviceIntegrator.FileManager.getFileByPath = function (strOriginalDirectoryPath, strPath, objFlags, fncCallbackOrStrMethodKey) {
            if (strOriginalDirectoryPath) {
                // Get origianal directory entry
                var objDirectoryEntry = FileManager_GetEntry(strOriginalDirectoryPath, true);

                // Modify args
                var arrArgs = Array.prototype.slice.apply(arguments);
                arrArgs[0] = objDirectoryEntry;

                // Call client API.
                DeviceIntegrator.FileManager.getFile.apply(this, arrArgs);
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.getFile">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.getFile = function (objDirectoryEntry, strPath, objFlags, fncCallback) {
            DeviceIntegrator_DeviceReady(function () {
                if (objDirectoryEntry) {
                    var objInitialization = FileManager_GetShortedInitializationObject(fncCallback, arguments, 4);

                    if (typeof objDirectoryEntry.getFile === 'function') {
                        objDirectoryEntry.getFile(strPath, objFlags, FileManager_GetSuccessGenericCallback(objInitialization, "ent."), FileManager_GetGenericFileErrorCallback(objInitialization));
                    }
                }
            });
        };


        /// <method name="DeviceIntegrator.FileManager.copyToByPath">
        /// <summary>
        /// Server invoked
        /// </summary>
        DeviceIntegrator.FileManager.copyToByPath = function (strToDirectoryPath, strFrom, blnIsDirectory, strNewName, fncCallbackOrStrMethodKey) {
            var objParentEntry = FileManager_GetEntry(strToDirectoryPath, true);
            var objFromEntry = FileManager_GetEntry(strFrom, blnIsDirectory);

            // Modify args
            var arrArgs = Array.prototype.slice.apply(arguments);
            arrArgs.shift();
            arrArgs.shift();
            arrArgs.shift();

            arrArgs.unshift(objParentEntry);
            arrArgs.unshift(objFromEntry);

            // Call client API
            DeviceIntegrator.FileManager.copyTo.apply(this, arrArgs);
        };

        /// <method name="DeviceIntegrator.FileManager.copyTo">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.copyTo = function (objEntryToCopy, objParentEntry, strNewName, fncCallback) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallback, arguments, 3);

            if (typeof objEntryToCopy.copyTo === 'function') {
                objEntryToCopy.copyTo(objParentEntry, strNewName, FileManager_GetSuccessGenericCallback(objInitialization, "ent."), FileManager_GetGenericFileErrorCallback(objInitialization));
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.moveToByPath">
        /// <summary>
        /// Server invoked
        /// </summary>
        DeviceIntegrator.FileManager.moveToByPath = function (strToDirectoryPath, strFrom, blnIsDirectory, strNewName, fncCallbackOrStrMethodKey) {
            var objParentEntry = FileManager_GetEntry(strToDirectoryPath, true);
            var objFromEntry = FileManager_GetEntry(strFrom, blnIsDirectory);

            // Modify args
            var arrArgs = Array.prototype.slice.apply(arguments);
            arrArgs.shift();
            arrArgs.shift();
            arrArgs.shift();

            arrArgs.unshift(objParentEntry);
            arrArgs.unshift(objFromEntry);

            // Call client API
            DeviceIntegrator.FileManager.moveTo.apply(this, arrArgs);
        };

        /// <method name="DeviceIntegrator.FileManager.moveTo">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.moveTo = function (objEntryToMove, objParentEntry, strNewName, fncCallback) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallback, arguments, 3);

            if (typeof objEntryToMove.moveTo === 'function') {
                objEntryToMove.moveTo(objParentEntry, strNewName, FileManager_GetSuccessGenericCallback(objInitialization, "ent."), FileManager_GetGenericFileErrorCallback(objInitialization));
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.setMetadataByPath">
        /// <summary>
        /// Server invoked setMetadata
        /// </summary>
        DeviceIntegrator.FileManager.setMetadataByPath = function (objEntryPath, blnIsDirectory, objMetadata, fncCallbackOrStrMethodKey) {
            if (objEntryPath) {
                var objEntry = FileManager_GetEntry(objEntryPath, blnIsDirectory);

                // Modify args
                var arrArgs = Array.prototype.slice.apply(arguments);
                arrArgs.shift();
                arrArgs.shift();
                arrArgs.unshift(objEntry);

                // Call client API.
                DeviceIntegrator.FileManager.setMetadata.apply(this, arrArgs);
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.setMetadata">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.setMetadata = function (objEntry, objMetadata, fncCallbackOrStrMethodKey) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallbackOrStrMethodKey, arguments, 3);

            DeviceIntegrator_DeviceReady(function () {
                if (objEntry) {
                    if (typeof objEntry["setMetadata"] === 'function') {
                        objEntry.setMetadata(FileManager_GetSuccessGenericCallback(objInitialization), FileManager_GetGenericFileErrorCallback(objInitialization, { "code": 1 }), objMetadata);
                    }
                }
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.removeRecursively">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.removeRecursively = function (strDirectoryPath, fncCallbackOrStrMethodKey) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallbackOrStrMethodKey, arguments, 2);

            DeviceIntegrator_DeviceReady(function () {
                if (strDirectoryPath) {
                    var objEntry = FileManager_GetEntry(strDirectoryPath, true);

                    if (objEntry) {
                        objEntry.removeRecursively(FileManager_GetSuccessGenericCallback(objInitialization), FileManager_GetGenericFileErrorCallback(objInitialization, { "code": 1 }));
                    }
                }
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.fileEntryGetFile">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.fileEntryGetFile = function (strFilePath, fncCallbackOrStrMethodKey) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallbackOrStrMethodKey, arguments, 2);

            DeviceIntegrator_DeviceReady(function () {
                if (strFilePath) {
                    var objEntry = FileManager_GetEntry(strFilePath, false);

                    if (objEntry) {
                        objEntry.file(FileManager_GetSuccessGenericCallback(objInitialization), FileManager_GetGenericFileErrorCallback(objInitialization, { "code": 1 }));
                    }
                }
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.fileReaderOperation">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.fileReaderOperation = function (
            strOperation,
            strFilePath,
            strServerHash,
            objData,
            objCallbackData) {
            FileManager_InvokeFileReaderOperation.apply(this, arguments);
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.fileWriterOperation">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.fileWriterOperation = function (
            strOperation,
            strFilePath,
            strServerHash,
            intPosition,
            strWriteData,
            objCallbackData) {
            FileManager_InvokeFileWriterOperation.apply(this, arguments);
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.writeToFile">
        /// <summary>
        /// Writes strData to file
        /// </summary>
        DeviceIntegrator.FileManager.writeToFile = function (objFileWriter, strData, fncWriteStartCallback, fncWriteCallback, fncWriteEndCallback, fncWriteErrorCallback, fncWriteAbortCallback) {
            if (objFileWriter) {
                if (typeof fncWriteStartCallback === "function") {
                    objFileWriter.onwritestart = fncWriteStartCallback;
                }

                if (typeof fncWriteCallback === "function") {
                    objFileWriter.onwrite = fncWriteCallback;
                }

                if (typeof fncWriteEndCallback === "function") {
                    objFileWriter.onwriteend = fncWriteEndCallback;
                }

                if (typeof fncWriteErrorCallback === "function") {
                    objFileWriter.onerror = fncWriteErrorCallback;
                }

                if (typeof fncWriteAbortCallback === "function") {
                    objFileWriter.onabort = fncWriteAbortCallback;
                }

                objFileWriter.write(strData);
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.truncate">
        /// <summary>
        /// Truncates file to intLength
        /// </summary>
        DeviceIntegrator.FileManager.truncate = function (objFileWriter, intLength, fncWriteStartCallback, fncWriteCallback, fncWriteEndCallback, fncWriteErrorCallback, fncWriteAbortCallback) {
            if (objFileWriter) {
                if (typeof fncWriteStartCallback === "function") {
                    objFileWriter.onwritestart = fncWriteStartCallback;
                }

                if (typeof fncWriteCallback === "function") {
                    objFileWriter.onwrite = fncWriteCallback;
                }

                if (typeof fncWriteEndCallback === "function") {
                    objFileWriter.onwriteend = fncWriteEndCallback;
                }

                if (typeof fncWriteErrorCallback === "function") {
                    objFileWriter.onerror = fncWriteErrorCallback;
                }

                if (typeof fncWriteAbortCallback === "function") {
                    objFileWriter.onabort = fncWriteAbortCallback;
                }

                objFileWriter.truncate(intLength);
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.seek">
        /// <summary>
        /// Seeks in file
        /// </summary>
        DeviceIntegrator.FileManager.seek = function (objFileWriter, intPosition) {

            if (objFileWriter) {
                objFileWriter.seek(intPosition);
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.abortFileOperation">
        /// <summary>
        /// Aborts a file operation (read or write)
        /// </summary>
        DeviceIntegrator.FileManager.abortFileOperation = function (objFileOperator) {
            if (objFileOperator) {
                objFileOperator.abort();
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.readFileAsText">
        /// <summary>
        /// Reads file as text, using strEncoding if provided. Defaults to UTF8.
        /// </summary>
        DeviceIntegrator.FileManager.readFileAsText = function (objFileReader, objFile, strEncoding, fncLoadStartCallback, fncLoadCallback, fncLoadEndCallback, fncAbortCallback, fncErrorCallback) {

            objFileReader = objFileReader || FileManager_CreateFileReader();

            if (objFileReader) {
                if (typeof fncLoadStartCallback === "function") {
                    objFileReader.onloadstart = fncLoadStartCallback;
                }

                if (typeof fncLoadCallback === "function") {
                    objFileReader.onload = fncLoadCallback;
                }

                if (typeof fncLoadEndCallback === "function") {
                    objFileReader.onloadend = fncLoadEndCallback;
                }

                if (typeof fncErrorCallback === "function") {
                    objFileReader.onerror = fncErrorCallback;
                }

                if (typeof fncAbortCallback === "function") {
                    objFileReader.onabort = fncAbortCallback;
                }

                if (!Aux_IsNullOrEmpty(strEncoding)) {
                    objFileReader.readAsText(objFile, strEncoding);
                }
                else {
                    console.log("DI.readText: " + objFile.fullPath + ", fileReader = " + objFileReader);
                    objFileReader.readAsText(objFile);
                }
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.readFileAsDataUrl">
        /// <summary>
        /// Reads file as base64 encoded data.
        /// </summary>
        DeviceIntegrator.FileManager.readFileAsDataUrl = function (objFileReader, objFile, fncLoadStartCallback, fncLoadCallback, fncLoadEndCallback, fncAbortCallback, fncErrorCallback) {
            objFileReader = objFileReader || FileManager_CreateFileReader();

            if (objFileReader) {
                if (typeof fncLoadStartCallback === "function") {
                    objFileReader.onloadstart = fncLoadStartCallback;
                }

                if (typeof fncLoadCallback === "function") {
                    objFileReader.onload = fncLoadCallback;
                }

                if (typeof fncLoadEndCallback === "function") {
                    objFileReader.onloadend = fncLoadEndCallback;
                }

                if (typeof fncErrorCallback === "function") {
                    objFileReader.onerror = fncErrorCallback;
                }

                if (typeof fncAbortCallback === "function") {
                    objFileReader.onabort = fncAbortCallback;
                }

                objFileReader.readAsText(objFile);
            }
        };

        /// <method name="DeviceIntegrator.FileManager.getFileWriter">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.getFileWriter = function (strFilePath, fncCallbackOrStrMethodKey) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallbackOrStrMethodKey, arguments, 2);

            DeviceIntegrator_DeviceReady(function () {
                if (strFilePath) {
                    var objEntry = FileManager_GetEntry(strFilePath, false);

                    if (objEntry) {
                        objEntry.createWriter(FileManager_GetSuccessGenericCallback(objInitialization), FileManager_GetGenericFileErrorCallback(objInitialization, { "code": 1 }));
                    }
                }
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.getFileReader">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.getFileReader = function (fncCallback) {
            var objFileReader = FileManager_CreateFileReader();
            if (objFileReader == null) {
                return;
            }
            if (objFileReader && typeof fncCallback === "function") {
                fncCallback(objFileReader);
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.uploadFile">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.uploadFile = function (strFullFilePath, strUploadUrl, objProgressEventData, objOptions, blnTrustAllHosts, fncCallbackOrStrMethodKey) {
            var arrArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceFileManagerAccess.createFileTransfer) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.FileManager.Id, "createFileTransfer", "FileManager");
                    return;
                }
                var objFileTransfer = deviceFileManagerAccess.createFileTransfer();

                FileManager_SetFileTransferProgressEvent(objFileTransfer, objProgressEventData);

                var objInitialization = DeviceIntegrator_GetInitializationObject(
                        fncCallbackOrStrMethodKey,
                        arrArguments,
                        6,
                        function (fncSuccess, fncFail) {
                            objFileTransfer.upload(strFullFilePath, encodeURI(strUploadUrl), fncSuccess, fncFail, objOptions, blnTrustAllHosts);
                        },
                        null,
                        null,
                        FileManager_GenericServerHandler,
                        FileManager_GenericServerHandler,
                        null /* options */);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.downloadFile">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.downloadFile = function (strSourceUrl, strDestinationFileFullPath, objProgressEventData, blnTrustAllHosts, fncCallbackOrStrMethodKey) {
            var arrArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceFileManagerAccess.createFileTransfer) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.FileManager.Id, "createFileTransfer", "FileManager");
                    return;
                }
                var objFileTransfer = deviceFileManagerAccess.createFileTransfer();

                FileManager_SetFileTransferProgressEvent(objFileTransfer, objProgressEventData);

                var objInitialization = DeviceIntegrator_GetInitializationObject(
                        fncCallbackOrStrMethodKey,
                        arrArguments,
                        5,
                        function (fncSuccess, fncFail) {
                            objFileTransfer.download(encodeURI(strSourceUrl), strDestinationFileFullPath, fncSuccess, fncFail, blnTrustAllHosts);
                        },
                        null,
                        null,
                        function (strMethodKey, objFileEntry) {
                            var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id, strMethodKey, null, true);

                            FileManager_AddEventAttributesFromObject(objEvent, "ent.", objFileEntry);

                            vwgContext.events.raiseEvents();
                        },
                        FileManager_GenericServerHandler,
                        null /* options */);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.setMetadata">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.FileManager.readDirectory = function (strDirectoryPath, fncCallbackOrStrMethodKey) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallbackOrStrMethodKey, arguments, 2);

            DeviceIntegrator_DeviceReady(function () {
                if (strDirectoryPath) {
                    var objEntry = FileManager_GetEntry(strDirectoryPath, true);

                    if (objEntry) {
                        var objDirectoryReader = objEntry.createReader();

                        if (objDirectoryReader) {
                            objDirectoryReader.readEntries(function (arrEntries) {
                                if (objInitialization.isDelegate) {
                                    objInitialization.arguments[0] = arrEntries;
                                    objInitialization.delegate.apply(this, objInitialization.arguments);
                                }
                                else {
                                    if (objInitialization.methodKey) {
                                        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id, objInitialization.methodKey, null, true);

                                        var intCount = arrEntries.length;

                                        vwgContext.events.setEventAttribute(objEvent, "count", intCount);

                                        for (var i = 0; i < intCount; i++) {
                                            FileManager_AddEventAttributesFromObject(objEvent, "a" + i + "ent.", arrEntries[i]);
                                        }

                                        vwgContext.events.raiseEvents();
                                    }
                                }
                            }, FileManager_GetGenericFileErrorCallback(objInitialization, { "code": 1 }));
                        }
                    }
                }
            });
        };
        /// </method>


        /// <method name="DeviceIntegrator.FileManager.getMetadataByPath">
        /// <summary>
        /// Server invoked getMetadata
        /// </summary>
        DeviceIntegrator.FileManager.getMetadataByPath = function (objEntryPath, blnIsDirectory, fncCallbackOrStrMethodKey) {
            var objEntry = FileManager_GetEntry(objEntryPath, blnIsDirectory);

            // Modify args
            var arrArgs = Array.prototype.slice.apply(arguments);
            arrArgs.shift();
            arrArgs.shift();
            arrArgs.unshift(objEntry);

            // Call client API.
            DeviceIntegrator.FileManager.getMetadata.apply(this, arrArgs);


        };
        /// </method>

        /// <method name="DeviceIntegrator.FileManager.getMetadata">
        /// <summary>
        ///
        /// </summary>
        DeviceIntegrator.FileManager.getMetadata = function (objEntry, fncCallback) {
            var objInitialization = FileManager_GetShortedInitializationObject(fncCallback, arguments, 2);

            DeviceIntegrator_DeviceReady(function () {
                if (objEntry) {
                    if (typeof objEntry["getMetadata"] === 'function') {
                        objEntry.getMetadata(FileManager_GetSuccessGenericCallback(objInitialization), FileManager_GetGenericFileErrorCallback(objInitialization));
                    }
                }
            });
        };
        /// </method>
    }

    /// <method name="FileManager_RemoveFilePrefixFromFilePath">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_RemoveFilePrefixFromFilePath(strFilePath) {
        return /file:\/\/.*?(\/.*)/.exec(strFilePath)[1];
    }
    /// </method>

    /// <method name="FileManager_GetRequestFileSystemInvoker">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_GetRequestFileSystemInvoker(intType, intSize) {
        return function (fncSuccess, fncFail) {
            if (window.requestFileSystem) {
                window.requestFileSystem(intType, intSize, fncSuccess, fncFail);
            }
        }
    }
    /// </method>

    /// <method name="FileManager_RequestFileSystemClientSuccessHandler">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_RequestFileSystemClientSuccessHandler(objClientResultArguments, objFileSystem) {
        if (objClientResultArguments.callback) {
            objClientResultArguments.callback(objFileSystem);
        }
    }
    /// </method>

    /// <method name="FileManager_RequestFileSystemClientErrorCreator">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_RequestFileSystemClientErrorCreator(objErrorEvent) {
        return { "code": objErrorEvent.target.error.code };
    }
    /// </method>

    /// <method name="FileManager_RequestFileSystemSuccessHandler">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_RequestFileSystemSuccessHandler(strMethodKey, objFileSystem) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id, strMethodKey, null, true);

        FileManager_AddEventAttributesFromFileSystem.call(this, objEvent, objFileSystem);

        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="FileManager_AddEventAttributesFromFileSystem">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_AddEventAttributesFromFileSystem(objEvent, objFileSystem) {
        vwgContext.events.setEventAttribute(objEvent, "filesystemName", objFileSystem.name);

        if (this && (this.size || this.size === 0) && (this.type || this.type === 0)) {
            vwgContext.events.setEventAttribute(objEvent, "filesystemSize", this.size);
            vwgContext.events.setEventAttribute(objEvent, "filesystemType", this.type);
        }

        FileManager_AddEventAttributesFromObject(objEvent, "ent.", objFileSystem.root);
    }
    /// </method>

    /// <method name="FileManager_RequestFileSystemErrorHandler">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_RequestFileSystemErrorHandler(strMethodKey, objErrorEvent) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id, strMethodKey, null, true);

        vwgContext.events.setEventAttribute(objEvent, "code", objErrorEvent.target.error.code);

        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="FileManager_GetGenericFileErrorCallback">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_GetGenericFileErrorCallback(objInitialization, objFallbackError) {
        return function (objError) {
            if (objInitialization.isDelegate) {
                if (objError) {
                    objInitialization.arguments[0] = objError;
                }
                else {
                    objInitialization.arguments[0] = objFallbackError;
                }
                objInitialization.delegate.apply(this, objInitialization.arguments);
            }
            else {
                if (objInitialization.methodKey) {
                    var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id, objInitialization.methodKey, null, true);

                    if (objError) {
                        vwgContext.events.setEventAttribute(objEvent, "code", objError.code);
                    }
                    else if (objFallbackError) {
                        vwgContext.events.setEventAttribute(objEvent, "code", objFallbackError.code);
                    }

                    vwgContext.events.raiseEvents();
                }
            }
        };
    }
    /// </method>

    /// <method name="FileManager_GetShortedInitializationObject">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_GetShortedInitializationObject(fncCallbackOrStrMethodKey, arrArguments, intStartIndex) {
        return DeviceIntegrator_GetInitializationObject(
                        fncCallbackOrStrMethodKey,
                        arrArguments,
                        intStartIndex,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null /* options */);
    }
    /// </method>

    /// <method name="FileManager_GetSuccessGenericCallback">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_GetSuccessGenericCallback(objInitialization, strPrefix) {
        return function (objGenericCallback) {
            if (objInitialization.isDelegate) {
                objInitialization.arguments[0] = objGenericCallback;
                objInitialization.delegate.apply(this, objInitialization.arguments);
            }
            else {
                if (objInitialization.methodKey) {
                    var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id, objInitialization.methodKey, null, true);

                    FileManager_AddEventAttributesFromObject(objEvent, strPrefix, objGenericCallback);

                    vwgContext.events.raiseEvents();
                }
            }
        };
    }
    /// </method>

    /// <method name="FileManager_GetEntry">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_GetEntry(strPath, blnIsDirectoryAndNotFile) {
        var strName = strPath.substring(strPath.lastIndexOf('/') + 1);

        var objEntry;

        if (blnIsDirectoryAndNotFile) {
            if (typeof (deviceFileManagerAccess.createDirectoryEntry) != "function") {
                DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.FileManager.Id, "createDirectoryEntry", "FileManager");
                return;
            }
            objEntry = deviceFileManagerAccess.createDirectoryEntry(strName, strPath);
        }
        else {
            if (typeof (deviceFileManagerAccess.createFileEntry) != "function") {
                DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.FileManager.Id, "createFileEntry", "FileManager");
                return;
            }
            objEntry = deviceFileManagerAccess.createFileEntry(strName, strPath);
        }

        return objEntry;
    }
    /// </method>

    /// <method name="FileManager_GetFileOperationEndCallback">
    /// <summary>
    /// This method returns a function that is dedicated to the 'onwriteend' callback.
    /// It checks the source of the event, and sends it to the server.
    /// </summary>
    function FileManager_GetFileOperationEndCallback(strMethodKey) {
        return function (objEventData) {
            if (strMethodKey) {
                vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id + "_" + (this.invokedFunction ? this.invokedFunction : objEventData.type), strMethodKey, null, false);

                vwgContext.events.raiseEvents();
            }
        };
    }
    /// </method>

    /// <method name="FileManager_InvokeFileWriterOperation">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_InvokeFileWriterOperation(
            strOperation, // Operation we want to excecute on the client
            strFilePath,  // Path of the file to write to
            strServerHash, // The file writer's hash onthe server
            intPosition,  // The position we want to write to
            strWriteData, // Data to use
            objCallbackDataCollection) {
        // Always get a new writer with the most updated data
        DeviceIntegrator.FileManager.getFileWriter(strFilePath, function (objWriter) {
            // Check that there is no error getting the writer
            if (!objWriter.code) {
                /*
                *  Register the relevant callback of the writer:
                */

                // Write start callback
                if (objCallbackDataCollection && objCallbackDataCollection.writeStart) {
                    objWriter.onwritestart = function (objEventData) {
                        FileManager_CreateUpdatedWriterEvent(objWriter, strServerHash);

                        if (objCallbackDataCollection.writeStart.server) {
                            vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id + "_writestart", strServerHash, null, false);

                            vwgContext.events.raiseEvents();
                        }

                        DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.writeStart);
                    };
                }

                // Write callback
                if (objCallbackDataCollection && objCallbackDataCollection.write) {
                    objWriter.onwrite = function (objEventData) {
                        if (objCallbackDataCollection.write.server) {
                            if (!this.invokedFunction) {
                                this.invokedFunction = objEventData.type;
                            }
                        }

                        DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.write);
                    };
                }
                // Error callback
                if (objCallbackDataCollection && objCallbackDataCollection.error) {
                    objWriter.onerror = function (objEventData) {
                        if (objCallbackDataCollection.error.server) {
                            if (!this.invokedFunction) {
                                this.invokedFunction = objEventData.type;
                            }
                        }

                        DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.error);
                    };
                }
                // Abort callback
                if (objCallbackDataCollection && objCallbackDataCollection.abort) {
                    objWriter.onabort = function (objEventData) {
                        if (objCallbackDataCollection.abort.server) {
                            if (!this.invokedFunction) {
                                this.invokedFunction = objEventData.type;
                            }
                        }

                        DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.abort);
                    };
                }
                // Write end callback
                objWriter.onwriteend = function (objEventData) {
                    FileManager_CreateUpdatedWriterEvent(objWriter, strServerHash);

                    if (objCallbackDataCollection.writeEnd.server || this.invokedFunction) {
                        this.invokedFunction = this.invokedFunction || objEventData.type;

                        FileManager_GetFileOperationEndCallback(strServerHash).call(this, objEventData);
                    }

                    DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.writeEnd);
                };

                // Set position to the correct location
                objWriter.seek(intPosition);

                // Invoke the operation
                if (objWriter[strOperation] && typeof objWriter[strOperation] === 'function') {
                    objWriter[strOperation](strWriteData);
                }
            }
        });
    }
    /// </method>


    /// <method name="FileManager_InvokeFileReaderOperation">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_InvokeFileReaderOperation(
        strOperation,
        strFilePath,
        strServerHash,
        objData,
        objCallbackDataCollection) {


        var objFileReader = FileManager_CreateFileReader();
        if (objFileReader == null) {
            return;
        }

        /*
        *  Register the relevant callback of the reader:
        */

        // Load start callback
        if (objCallbackDataCollection && objCallbackDataCollection.loadStart) {
            objFileReader.onloadstart = function (objEventData) {
                if (objCallbackDataCollection.loadStart.server) {
                    vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id + "_loadstart", strServerHash, null, false);

                    vwgContext.events.raiseEvents();
                }

                DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.loadStart);
            };
        }

        // Load callback
        if (objCallbackDataCollection && objCallbackDataCollection.load) {
            objFileReader.onload = function (objEventData) {
                if (objCallbackDataCollection.load.server) {
                    if (!this.invokedFunction) {
                        this.invokedFunction = objEventData.type;
                    }
                }

                DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.load);
            };
        }
        // Error callback
        if (objCallbackDataCollection && objCallbackDataCollection.error) {
            objFileReader.onerror = function (objEventData) {
                if (objCallbackDataCollection.error.server) {
                    if (!this.invokedFunction) {
                        this.invokedFunction = objEventData.type;
                    }
                }

                DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.error);
            };
        }
        // Abort callback
        if (objCallbackDataCollection && objCallbackDataCollection.abort) {
            objFileReader.onabort = function (objEventData) {
                if (objCallbackDataCollection.abort.server) {
                    if (!this.invokedFunction) {
                        this.invokedFunction = objEventData.type;
                    }
                }

                DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.abort);
            };
        }
        // Load end callback - always register to get the updated state
        objFileReader.onloadend = function (objEventData) {
            FileManager_CreateUpdatedReaderEvent(objEventData, strServerHash);

            if (objCallbackDataCollection.loadEnd.server || this.invokedFunction) {
                this.invokedFunction = this.invokedFunction || objEventData.type;

                FileManager_GetFileOperationEndCallback(strServerHash).call(this, objEventData);
            }

            DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objCallbackDataCollection.loadEnd);
        };

        // Invoke the operation
        if (objFileReader[strOperation] && typeof objFileReader[strOperation] === 'function') {
            objFileReader[strOperation](strFilePath, objData);
        }

    }
    /// </method>

    /// <method name="FileManager_CreateUpdatedReaderEvent">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_CreateUpdatedReaderEvent(objEventData, strServerHash) {
        if (objEventData && strServerHash) {
            if (objEventData.target) {
                if (objEventData.target.result) {
                    var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id + "_value", strServerHash, null, false);

                    vwgContext.events.setEventValue(objEvent, objEventData.target.result);

                    if (objEventData.target.error && objEventData.target.error.code) {
                        vwgContext.events.setEventAttribute(objEvent, "error", objEventData.target.error.code);
                    }

                    vwgContext.events.raiseEvents();
                }
            }
        }
    }
    /// </method>

    /// <method name="FileManager_CreateUpdatedWriterEvent">
    /// <summary>
    /// Create an updated data for a FileWriter object on the server
    /// </summary>
    function FileManager_CreateUpdatedWriterEvent(objWriter, strHash) {
        if (strHash && objWriter) {
            var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id + "_update", strHash, null, false);

            FileManager_AddEventAttributesFromObject(objEvent, null, objWriter);

            if (objWriter.error && objWriter.error.code) {
                vwgContext.events.setEventAttribute(objEvent, "error", objWriter.error.code);
            }
        }
    }
    /// </method>

    /// <method name="FileManager_GenericServerHandler">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_GenericServerHandler(strMethodKey, objData) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.FileManager.Id, strMethodKey, null, true);

        FileManager_AddEventAttributesFromObject(objEvent, null, objData);

        vwgContext.events.raiseEvents();
    }
    /// </method>


    /// <method name="FileManager_SetFileTransferProgressEvent">
    /// <summary>
    /// 
    /// </summary>
    function FileManager_SetFileTransferProgressEvent(objFileTransfer, objProgressEventData) {
        if (objProgressEventData) {
            objFileTransfer.onprogress = function (objEventData) {
                DeviceIntegrator_TryInvokeClientFileOperation(objEventData, objProgressEventData);
            };
        }
    }
    /// </method>



    /* Geolocation API */

    /// <method name="Geolocation_Initialize">
    /// <summary>
    /// 
    /// </summary>
    function Geolocation_Initialize(strID) {
        // Create device watch data for the Geolocation object
        DeviceIntegrator.Geolocation = {};

        // Create an empty default options object
        DeviceIntegrator.Geolocation.defaultOptions = {};
        DeviceIntegrator.Geolocation.Id = strID;
        DeviceIntegrator.Geolocation.Node = Data_GetNode(strID);

        // Set options
        // Get timeout context variable
        var strTimeout = "Context.GeolocationTimeout";

        // If defined
        if (strTimeout) {
            var intTimeout = parseInt(strTimeout, 10);

            if (typeof intTimeout === "number") {
                DeviceIntegrator.Geolocation.defaultOptions.timeout = intTimeout;
            }
        }

        // Get MaximumAge context variable
        var strMaximumAge = "Context.GeolocationMaximumAge";

        // If defined
        if (strMaximumAge) {
            var intMaximumAge = parseInt(strMaximumAge, 10);

            if (typeof intMaximumAge === "number") {
                DeviceIntegrator.Geolocation.defaultOptions.maximumAge = intMaximumAge;
            }
        }

        // Get enableHighAccuracy context variable
        var strEnableHighAccuracy = "Context.GeolocationEnableHighAccuracy";

        DeviceIntegrator.Geolocation.defaultOptions.enableHighAccuracy = strEnableHighAccuracy === '1' ? true : false;


        DeviceIntegrator_DeviceReady(function () {
            // Clear existing watches        
            if (DeviceIntegrator.Geolocation.watchKey) {
                if (typeof (deviceGeolocationAccess.clearWatch) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Geolocation.Id, "clearWatch", "Geolocation");
                    return;
                }
                deviceGeolocationAccess.clearWatch(DeviceIntegrator.Geolocation.watchKey);
            }

            // Check for critical events - Start the watch only if there are critical events
            if (Data_IsCriticalEventAttribute(DeviceIntegrator.Geolocation.Node, "Event.DeviceGeolocation", true, "Attr.Events")) {
                // Invoke the PG's watch Geolocation API
                if (typeof (deviceGeolocationAccess.watchPosition) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Geolocation.Id, "watchPosition", "Geolocation");
                    return;
                }
                DeviceIntegrator.Geolocation.watchKey = deviceGeolocationAccess.watchPosition(function (objGeolocation) {
                    if (strID && DeviceIntegrator.Geolocation.Node) {
                        var objEvent = Geolocation_GetDefaultSuccessEvent("Tags.Geolocation", objGeolocation);

                        DeviceIntegrator_RaiseEvent(objEvent, DeviceIntegrator.Geolocation.Node, "Event.DeviceGeolocation");
                    }
                },
                    function () {
                        if (strID && DeviceIntegrator.Geolocation.Node) {
                            var objEvent = Geolocation_GetDefaultErrorEvent();

                            DeviceIntegrator_RaiseEvent(objEvent, DeviceIntegrator.Geolocation.Node, "Event.DeviceGeolocation");
                        }
                    },
                    DeviceIntegrator.Geolocation.defaultOptions
                );
            }
        });

        /// <method name="DeviceIntegrator.Geolocation.getPosition">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Geolocation.getPosition = function () {
            var objArguments = arguments;
            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];
                // Push the relevant function call to get the Geolocation -- wrapped to preevent TypeError exception
                arrArguments.push(function (fncSuccess, fncFail, options) {
                    if (typeof (deviceGeolocationAccess.getCurrentPosition) != "function") {
                        DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Geolocation.Id, "getCurrentPosition", "Geolocation");
                        return;
                    }
                    deviceGeolocationAccess.getCurrentPosition(fncSuccess, fncFail, options);
                });

                // Prepare callback args
                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Geolocation_InvokeGeolocation.apply(this, arrArguments);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Geolocation.watchPosition">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Geolocation.watchPosition = function () {
            var objArguments = arguments;
            DeviceIntegrator_DeviceReady(function () {
                var arrArguments = [];
                // Push the relevant function call to watch the Geolocation -- wrapped to preevent TypeError exception
                arrArguments.push(function (fncSuccess, fncFail, options) {
                    // Return watchID 
                    if (typeof (deviceGeolocationAccess.watchPosition) != "function") {
                        DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Geolocation.Id, "watchPosition", "Geolocation");
                        return;
                    }
                    return deviceGeolocationAccess.watchPosition(fncSuccess, fncFail, options);

                });

                // Prepare callback args
                for (var i = 0; i < objArguments.length; i++) {
                    arrArguments.push(objArguments[i]);
                }

                Geolocation_InvokeGeolocation.apply(this, arrArguments);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Geolocation.clearGeolocationWatch">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Geolocation.clearGeolocationWatch = function (strWatchID) {
            // Clear watch when ready.       
            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGeolocationAccess.clearWatch) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Geolocation.Id, "clearWatch", "Geolocation");
                    return;
                }
                deviceGeolocationAccess.clearWatch(strWatchID);
            });
        };
        /// </method>
    }
    /// </method>

    /// <method name="Geolocation_InvokeGeolocation">
    /// <summary>
    /// 
    /// </summary>
    function Geolocation_InvokeGeolocation(fncGeolocationFunction, fncCallbackOrStrMethodKey) {
        // Create initialization object 
        var objInitialization = DeviceIntegrator_GetInitializationObject(
            fncCallbackOrStrMethodKey,
            arguments,
            2,
            fncGeolocationFunction,
            Geolocation_ClientSuccessHandler,
            Geolocation_ErrorCreator,
            Geolocation_GetDefaultSuccessEvent,
            Geolocation_GetDefaultErrorEvent,
            DeviceIntegrator.Geolocation.defaultOptions);

        DeviceIntegrator_Execute(objInitialization);

    }
    /// </method>


    /// <method name="Geolocation_GetDefaultSuccessEvent">
    /// <summary>
    /// Create an event from the Geolocation arguments
    /// </summary>
    function Geolocation_GetDefaultSuccessEvent(strMethodKey, objPosition) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Geolocation.Id, strMethodKey, null, true);
        if (objPosition && objPosition.coords) {
            vwgContext.events.setEventAttribute(objEvent, "latitude", objPosition.coords.latitude);
            vwgContext.events.setEventAttribute(objEvent, "longitude", objPosition.coords.longitude);
            vwgContext.events.setEventAttribute(objEvent, "altitude", objPosition.coords.altitude);
            vwgContext.events.setEventAttribute(objEvent, "accuracy", objPosition.coords.accuracy);
            vwgContext.events.setEventAttribute(objEvent, "altitudeAccuracy", objPosition.coords.altitudeAccuracy);
            vwgContext.events.setEventAttribute(objEvent, "heading", objPosition.coords.heading);
            vwgContext.events.setEventAttribute(objEvent, "speed", objPosition.coords.speed);
            vwgContext.events.setEventAttribute(objEvent, "timeStamp", objPosition.timeStamp);
        }

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="Geolocation_GetDefaultErrorEvent">
    /// <summary>
    /// 
    /// </summary>
    function Geolocation_GetDefaultErrorEvent(strMethodKey, objGeolocationError) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Geolocation.Id, strMethodKey, null, true);

        if (objGeolocationError) {
            // PERMISSION_DENIED = 1, POSITION_UNAVAILABLE = 2, TIMEOUT = 3;
            vwgContext.events.setEventAttribute(objEvent, "code", objGeolocationError.code);
            vwgContext.events.setEventAttribute(objEvent, "message", objGeolocationError.message);
        }
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="Geolocation_ArgumentsCreator">
    /// <summary>
    /// 
    /// </summary>
    function Geolocation_ClientSuccessHandler(objArguments, objGeolocation) {
        if (objArguments) {
            if (objArguments.returnValue) {
                objGeolocation.watchID = objArguments.returnValue;
            }

            if (objArguments.callback) {
                objArguments.callback(objGeolocation);
            }
        }
    }
    /// </method>

    /// <method name="Geolocation_ErrorCreator">
    /// <summary>
    /// 
    /// </summary>
    function Geolocation_ErrorCreator(objError) {
        return objError;
    }
    /// </method>



    /* Globalization API */
    // Create the Globalization object only ifthe main 'DeviceIntegrator' exists
    function Globalization_Initialize(strID) {
        // Create device watch data for the Globalization object
        DeviceIntegrator.Globalization = {};

        // Create an empty default options object
        DeviceIntegrator.Globalization.defaultOptions = {};
        DeviceIntegrator.Globalization.Id = strID;

        DeviceIntegrator.Globalization.getGlobalizationInfo = function (strMethodKey) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                var objGlobalizationInfo = {};

                // Get the PreferredLanguage from device.
                if (typeof (deviceGlobalizationAccess.getPreferredLanguage) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "getPreferredLanguage", "Globalization");
                    return;
                }
                deviceGlobalizationAccess.getPreferredLanguage(
                    function (objPreferredLanguage) {
                        // Set the PreferredLanguage value in the result.
                        objGlobalizationInfo.preferredLanguage = objPreferredLanguage.value;

                        // Get the PreferredLanguage from device.
                        if (typeof (deviceGlobalizationAccess.getLocaleName) != "function") {
                            DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "getLocaleName", "Globalization");
                            return;
                        }
                        deviceGlobalizationAccess.getLocaleName(
                            function (objLocaleName) {
                                // Set the LocaleName value in the result.
                                objGlobalizationInfo.localeName = objLocaleName.value;

                                // Get the FirstDayOfWeek from device.
                                if (typeof (deviceGlobalizationAccess.getFirstDayOfWeek) != "function") {
                                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "getFirstDayOfWeek", "Globalization");
                                    return;
                                }
                                deviceGlobalizationAccess.getFirstDayOfWeek(
                                    function (objFirstDayOfWeek) {
                                        // Set the FirstDayOfWeek value in the result.
                                        objGlobalizationInfo.firstDayOfWeek = objFirstDayOfWeek.value;

                                        // Go to server..
                                        Globalization_GlobalizationInfoSuccessEvent(strMethodKey, objGlobalizationInfo);
                                    },
                                    function (strErrorCode) {
                                        Globalization_DefaultErrorEvent(strMethodKey, strErrorCode);
                                    });
                            },
                            function (strErrorCode) {
                                Globalization_DefaultErrorEvent(strMethodKey, strErrorCode);
                            });
                    },
                    function (strErrorCode) {
                        Globalization_DefaultErrorEvent(strMethodKey, strErrorCode);
                    });
            });
        };

        /// <method name="DeviceIntegrator.Globalization.isDayLightSavingsTime">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.isDayLightSavingsTime = function (objDate, strFunctionOrMethodKey) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.isDayLightSavingsTime) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "isDayLightSavingsTime", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    2,
                    function (fncSuccess, fncError) { deviceGlobalizationAccess.isDayLightSavingsTime(objDate, fncSuccess, fncError); },
                    null,
                    null,
                    Globalization_DaylightSavingsSuccessEvent,
                    Globalization_DefaultErrorEvent);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Globalization.getCurrencyPattern">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.getCurrencyPattern = function (strCurrencyCode, strFunctionOrMethodKey) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.getCurrencyPattern) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "getCurrencyPattern", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    2,
                    function (fncSuccess, fncError) { deviceGlobalizationAccess.getCurrencyPattern(strCurrencyCode, fncSuccess, fncError); },
                    null,
                    null,
                    Globalization_CurrencySuccessEvent,
                    Globalization_DefaultErrorEvent);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Globalization.dateToString">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.dateToString = function (objDate, strFunctionOrMethodKey, objOptions) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.dateToString) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "dateToString", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    3,
                    function (fncSuccess, fncError) { deviceGlobalizationAccess.dateToString(objDate, fncSuccess, fncError, objOptions); },
                    null,
                    null,
                    Globalization_GeneralSuccessEvent,
                    Globalization_DefaultErrorEvent,
                    objOptions);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Globalization.stringToDate">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.stringToDate = function (strDate, strFunctionOrMethodKey, objOptions) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.stringToDate) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "stringToDate", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    3,
                    function (fncSuccess, fncError) { deviceGlobalizationAccess.stringToDate(strDate, fncSuccess, fncError, objOptions); },
                    null,
                    null,
                    Globalization_DateSuccessEvent,
                    Globalization_DefaultErrorEvent,
                    objOptions);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Globalization.getDatePattern">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.getDatePattern = function (strFunctionOrMethodKey, objOptions) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.getDatePattern) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "getDatePattern", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    2,
                    deviceGlobalizationAccess.getDatePattern,
                    null,
                    null,
                    Globalization_DatePatternSuccessEvent,
                    Globalization_DefaultErrorEvent,
                    objOptions);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Globalization.getNumberPattern">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.getNumberPattern = function (strFunctionOrMethodKey, objOptions) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.getNumberPattern) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "getNumberPattern", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    2,
                    deviceGlobalizationAccess.getNumberPattern,
                    null,
                    null,
                    Globalization_NumberSuccessEvent,
                    Globalization_DefaultErrorEvent,
                    objOptions);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Globalization.numberToString">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.numberToString = function (objNumber, strFunctionOrMethodKey, objOptions) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.numberToString) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "numberToString", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    3,
                    function (fncSuccess, fncError) { deviceGlobalizationAccess.numberToString(objNumber, fncSuccess, fncError, objOptions); },
                    null,
                    null,
                    Globalization_GeneralSuccessEvent,
                    Globalization_DefaultErrorEvent,
                    objOptions);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>


        /// <method name="DeviceIntegrator.Globalization.stringToNumber">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.stringToNumber = function (strNumber, strFunctionOrMethodKey, objOptions) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.stringToNumber) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "stringToNumber", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    3,
                    function (fncSuccess, fncError) { deviceGlobalizationAccess.stringToNumber(strNumber, fncSuccess, fncError, objOptions); },
                    null,
                    null,
                    Globalization_GeneralSuccessEvent,
                    Globalization_DefaultErrorEvent,
                    objOptions);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Globalization.getDateNames">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Globalization.getDateNames = function (strFunctionOrMethodKey, objOptions) {
            var objArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceGlobalizationAccess.getDateNames) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Globalization.Id, "getDateNames", "Globalization");
                    return;
                }
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                    strFunctionOrMethodKey,
                    objArguments,
                    2,
                    deviceGlobalizationAccess.getDateNames,
                    null,
                    null,
                    Globalization_ListSuccessEvent,
                    Globalization_DefaultErrorEvent,
                    objOptions);

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>
    }
    /// </method>

    /// <method name="Accelerometer_GetDefaultSuccessEvent">
    /// <summary>
    /// Create an event from the acceleration arguments
    /// </summary>
    function Globalization_GlobalizationInfoSuccessEvent(strMethodKey, objGlobalizationInfo) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Globalization.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "PreferredLanguage", objGlobalizationInfo.preferredLanguage);
        vwgContext.events.setEventAttribute(objEvent, "LocaleName", objGlobalizationInfo.localeName);
        vwgContext.events.setEventAttribute(objEvent, "FirstDayOfWeek", objGlobalizationInfo.firstDayOfWeek);

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="DeviceIntegrator.Globalization_GeneralSuccessEvent">
    /// <summary>
    /// 
    /// </summary>
    function Globalization_GeneralSuccessEvent(strMethodKey, objReturnValue) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Globalization.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "ReturnValue", objReturnValue.value);

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="DeviceIntegrator.Globalization_DaylightSavingsSuccessEvent">
    /// <summary>
    /// 
    /// </summary>
    function Globalization_DaylightSavingsSuccessEvent(strMethodKey, objReturnValue) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Globalization.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "ReturnValue", "" + objReturnValue.dst);

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="DeviceIntegrator.Globalization_CurrencySuccessEvent">
    /// <summary>
    /// 
    /// </summary>
    function Globalization_CurrencySuccessEvent(strMethodKey, objReturnValue) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Globalization.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "pattern", objReturnValue.pattern);
        vwgContext.events.setEventAttribute(objEvent, "code", objReturnValue.code);
        vwgContext.events.setEventAttribute(objEvent, "fraction", objReturnValue.fraction);
        vwgContext.events.setEventAttribute(objEvent, "rounding", objReturnValue.rounding);
        vwgContext.events.setEventAttribute(objEvent, "decimal", objReturnValue.decimal);
        vwgContext.events.setEventAttribute(objEvent, "grouping", objReturnValue.grouping);

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="DeviceIntegrator.Globalization_NumberSuccessEvent">
    /// <summary>
    /// 
    /// </summary>
    function Globalization_NumberSuccessEvent(strMethodKey, objReturnValue) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Globalization.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "pattern", objReturnValue.pattern);
        vwgContext.events.setEventAttribute(objEvent, "symbol", objReturnValue.symbol);
        vwgContext.events.setEventAttribute(objEvent, "fraction", objReturnValue.fraction);
        vwgContext.events.setEventAttribute(objEvent, "rounding", objReturnValue.rounding);
        vwgContext.events.setEventAttribute(objEvent, "positive", objReturnValue.positive);
        vwgContext.events.setEventAttribute(objEvent, "negative", objReturnValue.negative);
        vwgContext.events.setEventAttribute(objEvent, "decimal", objReturnValue.decimal);
        vwgContext.events.setEventAttribute(objEvent, "grouping", objReturnValue.grouping);

        // Raise
        vwgContext.events.raiseEvents();
    }

    /// <method name="DeviceIntegrator.Globalization_DatePatternSuccessEvent">
    /// <summary>
    /// 
    /// </summary>
    function Globalization_DatePatternSuccessEvent(strMethodKey, objReturnValue) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Globalization.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "pattern", objReturnValue.pattern);
        vwgContext.events.setEventAttribute(objEvent, "timezone", objReturnValue.timezone);
        vwgContext.events.setEventAttribute(objEvent, "utc_offset", objReturnValue.utc_offset);
        vwgContext.events.setEventAttribute(objEvent, "dst_offset", objReturnValue.dst_offset);

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="DeviceIntegrator.Globalization_ListSuccessEvent">
    /// <summary>
    /// 
    /// </summary>
    function Globalization_ListSuccessEvent(strMethodKey, objReturnValue) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Globalization.Id, strMethodKey, null, true);
        var strValues = objReturnValue.value.join();

        vwgContext.events.setEventAttribute(objEvent, "ReturnValue", strValues);
        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="DeviceIntegrator.Globalization_DefaultErrorEvent">
    /// <summary>
    /// 
    /// </summary>
    function Globalization_DefaultErrorEvent(strMethodKey, strErrorCode) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Accelerometer.Id, strMethodKey, null, true);
        vwgContext.events.setEventAttribute(objEvent, "code", strErrorCode);
        vwgContext.events.setEventAttribute(objEvent, "message", "GetLocalte Error");

        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="DeviceIntegrator.Globalization_DefaultErrorEvent">
    /// <summary>
    /// 
    /// </summary>
    function Globalization_DateSuccessEvent(strMethodKey, objDate) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Globalization.Id, strMethodKey, null, true);
        var objDateArray = [objDate.year, objDate.month, objDate.day, objDate.hour, objDate.minute, objDate.second, objDate.millisecond];
        vwgContext.events.setEventAttribute(objEvent, "ReturnValue", objDateArray.join());
        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>



    /* Media API */
    function Media_Initialize(strId) {
        // If Media object already exists, we will just set the new xml.
        if (DeviceIntegrator.Media != undefined) {
            DeviceIntegrator.Media.Id = strId;
            DeviceIntegrator.Media.Node = Data_GetNode(strId);
            return;
        }

        // Create device watch data for the DeviceInfo object
        DeviceIntegrator.Media = {};
        DeviceIntegrator.Media.defaultOptions = {};
        DeviceIntegrator.Media.idMediaMap = {};
        DeviceIntegrator.Media.mediaIdsDurationWatchCompleted = {};
        DeviceIntegrator.Media.mediaIdsDurationWatch = {};
        DeviceIntegrator.Media.mediaIdsPositionWatch = {};

        DeviceIntegrator.Media.Id = strId;
        DeviceIntegrator.Media.Node = Data_GetNode(strId);

        // Get frequency context variable
        var strPositionFrequency = "Context.MediaPositionFrequency";

        // If position frequency defined. 
        var intPositionFrequency = 1000;
        if (strPositionFrequency) {
            intPositionFrequency = parseInt(strPositionFrequency);
            DeviceIntegrator.Media.defaultOptions.positionFrequency = intPositionFrequency;
        }

        /// </method>

        /// <method name="DeviceIntegrator.Media.playBack">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Media.playBack = function (strFunction, strMediaId) {
            DeviceIntegrator_DeviceReady(function () {
                var objMedia = DeviceIntegrator.Media.idMediaMap[strMediaId];
                objMedia[strFunction]();
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Media.seek">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Media.seek = function (strMediaId, lngSeekTo) {
            DeviceIntegrator_DeviceReady(function () {
                var objMedia = DeviceIntegrator.Media.idMediaMap[strMediaId];
                objMedia.seekTo(lngSeekTo);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Media.release">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Media.release = function (strMediaId) {
            var objMedia = DeviceIntegrator.Media.idMediaMap[strMediaId];
            delete DeviceIntegrator.Media.idMediaMap[strMediaId];

            if (objMedia) {
                objMedia.release();
            }
        };
        /// </method>

        /// <method name="DeviceIntegrator.Media.getCurrentPosition">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Media.getCurrentPosition = function (strMediaId, fncCallbackOrStrMethodKey) {
            var arrArguments = arguments;

            DeviceIntegrator_DeviceReady(function () {
                var objMedia = DeviceIntegrator.Media.idMediaMap[strMediaId];
                var objInitialization = DeviceIntegrator_GetInitializationObject(
                fncCallbackOrStrMethodKey,
                arrArguments,
                2,
                function (fncSuccess, fncError) { objMedia.getCurrentPosition(fncSuccess, fncError); },
                null,
                null,
                function (strMethodKey, intPosition) {
                    var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Media.Id, strMethodKey, null, false);

                    vwgContext.events.setEventAttribute(objEvent, "pos", intPosition);

                    vwgContext.events.raiseEvents();
                },
                function (strMethodKey, objError) { DeviceIntegrator_InvokeDefaultErrorEvent(DeviceIntegrator.Media.Id, strMethodKey, objError); }
                );

                DeviceIntegrator_Execute(objInitialization);
            });
        };
        /// </method>
    }

    /// <method name="Media_InitializeMedia">
    /// <summary>
    /// 
    /// </summary>
    function Media_InitializeMedia(strMediaId, strSource, blnSuccessCallbackExist, blnErrorCallbackExist, blnStateCallbackExist, blnPositionChangeWatch) {
        var fncSuccess;
        if (blnSuccessCallbackExist) {
            fncSuccess = Media_CreateSuccessFunction(strMediaId);
        }

        var fncError;
        if (blnErrorCallbackExist) {
            fncError = Media_CreateErrorFunction(strMediaId);
        }

        var fncState;
        if (blnStateCallbackExist) {
            fncState = Media_CreateStateFunction(strMediaId);
        }

        DeviceIntegrator_DeviceReady(function () {
            if (typeof (deviceMediaAccess.createMedia) != "function") {
                DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Media.Id, "createMedia", "Media");
                return;
            }
            var objMedia = deviceMediaAccess.createMedia(strSource, fncSuccess, fncError, fncState);
            DeviceIntegrator.Media.idMediaMap[strMediaId] = objMedia;

            // If the duration of this media, was not loaded yet, we will sign it.
            if (DeviceIntegrator.Media.mediaIdsDurationWatchCompleted[strMediaId] != true) {
                DeviceIntegrator.Media.mediaIdsDurationWatch[strMediaId] = true;
                Media_VerifyDuration();
            }

            // Set watch media position if required.
            if (blnPositionChangeWatch) {
                DeviceIntegrator.Media.mediaIdsPositionWatch[strMediaId] = true;
                Media_VerifyWatchPosition();
            }
            else {
                delete DeviceIntegrator.Media.mediaIdsPositionWatch[strMediaId];
            }
        });
    }

    function Media_VerifyDuration() {
        // Clear watch interval.
        if (DeviceIntegrator.Media.watchDurationKey) {
            window.clearInterval(DeviceIntegrator.Media.watchDurationKey);
        }

        var arrMediaIdsDurationWatchKeys = Object.keys(DeviceIntegrator.Media.mediaIdsDurationWatch);

        // If there are no duration to watch, return.
        if (arrMediaIdsDurationWatchKeys.length == 0) { return; }

        // Start inteval for checking for media duration loading.
        // NOTE: Media duation will be loaded only few seconds after play have been pressed, because only then the media is loaded.
        DeviceIntegrator.Media.watchDurationKey = window.setInterval(function () {
            // If there is no media to get duration, we will clear the interval and exist.
            if (arrMediaIdsDurationWatchKeys.length == 0) {
                window.clearInterval(DeviceIntegrator.Media.watchDurationKey);
                return;
            }

            // Loop thru all the medias that there duration should be watched.
            for (var i = 0; i < arrMediaIdsDurationWatchKeys.length; i++) {
                var strMediaId = arrMediaIdsDurationWatchKeys[i];
                var objMedia = DeviceIntegrator.Media.idMediaMap[strMediaId];
                var intDuration = objMedia.getDuration();
                if (intDuration >= 0) {
                    var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Media.Id, "Duration", null, false);
                    vwgContext.events.setEventAttribute(objEvent, "mid", strMediaId);
                    vwgContext.events.setEventAttribute(objEvent, "dur", intDuration);
                    DeviceIntegrator.Media.mediaIdsDurationWatchCompleted[strMediaId] = true;

                    delete DeviceIntegrator.Media.mediaIdsDurationWatch[strMediaId];
                }
            }
        }, 1000);
    }

    /// <method name="Media_VerifyWatchPosition">
    /// <summary>
    /// Verify the watch position is running
    /// </summary>
    function Media_VerifyWatchPosition() {
        // Clear watch interval.
        if (DeviceIntegrator.Media.watchPositionKey) {
            window.clearInterval(DeviceIntegrator.Media.watchPositionKey);
        }

        // Check for critical events - Start the watch only if there are critical events.
        if (Data_IsCriticalEventAttribute(DeviceIntegrator.Media.Node, "Event.DeviceMediaPosition", true, "Attr.Events")) {
            // Set interval for watch position.
            DeviceIntegrator.Media.watchPositionKey = window.setInterval(function () {
                // Build an array of media ids from the json of media ids for position watch.
                var arrMediaIdsPositionWatchKeys = Object.keys(DeviceIntegrator.Media.mediaIdsPositionWatch);
                var arrMediaIds = [];
                for (var index = 0; index < arrMediaIdsPositionWatchKeys.length; index++) {
                    arrMediaIds.push(arrMediaIdsPositionWatchKeys[index]);
                }

                // If the are no medias to watch, cancel interval..
                if (arrMediaIds.length == 0) {
                    window.clearInterval(DeviceIntegrator.Media.watchPositionKey);
                    return;
                }

                var objMediaIdsWithPositionData = {};
                var intMediaPositionHandled = 0;

                // Loop thru all medias that there position is being tracked.
                for (var i = 0; i < arrMediaIds.length; i++) {
                    var strMediaId = arrMediaIds[i];
                    var objMedia = DeviceIntegrator.Media.idMediaMap[strMediaId];
                    objMedia.getCurrentPosition(
                        function (fltPosition) {
                            intMediaPositionHandled++;

                            // If position of media was not change, do nothing.
                            if (objMedia.lastPosition != undefined && objMedia.lastPosition == fltPosition) { return; }

                            objMediaIdsWithPositionData[strMediaId] = {};
                            objMediaIdsWithPositionData[strMediaId].position = fltPosition;

                            // Update the last position.
                            objMedia.lastPosition = fltPosition;

                            // If we got the last media position, we can go to the server..
                            if (intMediaPositionHandled == arrMediaIds.length) {
                                var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Media.Id, "Position", null, true);

                                var arrMediaIdsForEvent = Object.keys(objMediaIdsWithPositionData);

                                // Build media positions string to send to the server.
                                var strMediaIdsWithPositionData = "";
                                for (var j = 0; j < arrMediaIdsForEvent.length; j++) {
                                    var strMediaIdForEvent = arrMediaIdsForEvent[j];
                                    strMediaIdsWithPositionData += strMediaIdForEvent + "-" + objMediaIdsWithPositionData[strMediaIdForEvent].position;
                                }

                                vwgContext.events.setEventAttribute(objEvent, "mediaIdsPositionData", strMediaIdsWithPositionData);
                                DeviceIntegrator_RaiseEvent(objEvent, DeviceIntegrator.Media.Node, "Event.DeviceMediaPosition");
                            }
                        });
                }
            }, DeviceIntegrator.Media.defaultOptions.positionFrequency);
        }
    }

    /// <method name="Media_CreateSuccessFunction">
    /// <summary>
    /// 
    /// </summary>
    function Media_CreateSuccessFunction(strMediaId) {
        return function () {
            var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Media.Id + "_success", strMediaId, null, false);
            vwgContext.events.raiseEvents();
        };
    }
    /// </method>

    /// <method name="Media_CreateErrorFunction">
    /// <summary>
    /// 
    /// </summary>
    function Media_CreateErrorFunction(strMediaId) {
        return function (objError) {
            var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Media.Id + "_error", strMediaId, null, false);
            vwgContext.events.setEventAttribute(objEvent, "code", objError.code);
            vwgContext.events.raiseEvents();
        };
    }
    /// </method>

    /// <method name="Media_CreateStateFunction">
    /// <summary>
    /// 
    /// </summary>
    function Media_CreateStateFunction(strMediaServerId) {
        var objFunction = function (objState) {
            var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Media.Id + "_state", strMediaServerId, null, false);
            vwgContext.events.setEventAttribute(objEvent, "state", objState);
            vwgContext.events.raiseEvents();
        };

        return objFunction;
    }
    /// </method>


    /* Notifications API */
    /// <method name="Notifications_Initialize">
    /// <summary>
    /// 
    /// </summary>
    function Notifications_Initialize(strID) {
        DeviceIntegrator.Notifications = {};

        // Store the component's ID
        DeviceIntegrator.Notifications.Id = strID;

        /// <method name="DeviceIntegrator.Notifications.confirm">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Notifications.confirm = function (strMessage, fncCallbackOrStrMethodKey, objOptions) {
            var objInitialization = DeviceIntegrator_GetInitializationObject(fncCallbackOrStrMethodKey, arguments, 3,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null);

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceNotificationAccess.confirm) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Notifications.Id, "confirm", "Notifications");
                    return;
                }
                var strButtons = null;
                if (objOptions && objOptions.buttons && objOptions.buttons instanceof Array) {
                    strButtons = objOptions.buttons.toString();
                }

                if (typeof (deviceNotificationAccess.confirm) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Notifications.Id, "confirm", "Notifications");
                    return;
                }
                deviceNotificationAccess.confirm(strMessage, function (intButtonIndex) {
                    if (objInitialization.isDelegate) // Client invocation
                    {
                        // *Remember: The first index is a placeholder for the result
                        objInitialization.arguments[0] = intButtonIndex;

                        // Create the argument for the delegate callback
                        objInitialization.delegate.apply(this, objInitialization.arguments);

                    }
                    else {
                        if (objInitialization.methodKey) {
                            var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Notifications.Id, objInitialization.methodKey, null, true);

                            vwgContext.events.setEventAttribute(objEvent, "ButtonIndex", intButtonIndex);

                            vwgContext.events.raiseEvents();
                        }
                    }
                },
                objOptions ? objOptions.title : null,
                strButtons);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Notifications.alert">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Notifications.alert = function (strMessage, fncCallbackOrStrMethodKey, objOptions) {
            var objInitialization = DeviceIntegrator_GetInitializationObject(fncCallbackOrStrMethodKey, arguments, 3,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    true); // No return value - no need to save a place for it.

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceNotificationAccess.alert) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Notifications.Id, "alert", "Notifications");
                    return;
                }
                deviceNotificationAccess.alert(strMessage, function () {
                    if (objInitialization.isDelegate) // Client invocation
                    {
                        if (objInitialization.delegate) {
                            // Create the argument for the delegate callback
                            objInitialization.delegate.apply(this, objInitialization.arguments);
                        }
                    }
                    else {
                        if (objInitialization.methodKey) {
                            var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Notifications.Id, objInitialization.methodKey, null, true);

                            vwgContext.events.raiseEvents();
                        }
                    }
                }, objOptions ? objOptions.title : null, objOptions ? objOptions.buttonText : null);
            });
        };
        /// </method>

        DeviceIntegrator.Notifications.beep = function (intTimes, fncCallbackOrStrMethodKey) {
            var objInitialization = DeviceIntegrator_GetInitializationObject(fncCallbackOrStrMethodKey, arguments, 2,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    true); // No return value - no need to save a place for it.

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceNotificationAccess.beep) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Notifications.Id, "beep", "Notifications");
                    return;
                }
                deviceNotificationAccess.beep(intTimes); // This is a sync call

                if (objInitialization.isDelegate) // Client invocation
                {
                    // Create the argument for the delegate callback
                    objInitialization.delegate.apply(this, objInitialization.arguments);
                }
                else {
                    if (objInitialization.methodKey) {
                        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Notifications.Id, objInitialization.methodKey, null, true);

                        vwgContext.events.raiseEvents();
                    }
                }
            });
        };

        DeviceIntegrator.Notifications.vibrate = function (intDurationInMilliseconds, fncCallbackOrStrMethodKey) {
            var objInitialization = DeviceIntegrator_GetInitializationObject(fncCallbackOrStrMethodKey, arguments, 2,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    true); // No return value - no need to save a place for it.

            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceNotificationAccess.vibrate) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Notifications.Id, "vibrate", "Notifications");
                    return;
                }
                deviceNotificationAccess.vibrate(intDurationInMilliseconds);

                // Call the invokation callback after the vibration is finished.. (intDurationInMilliseconds)
                window.setTimeout(function () {
                    if (objInitialization.isDelegate) // Client invocation
                    {
                        // Create the argument for the delegate callback
                        objInitialization.delegate.apply(this, objInitialization.arguments);
                    }
                    else {
                        if (objInitialization.methodKey) {
                            var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Notifications.Id, objInitialization.methodKey, null, true);

                            vwgContext.events.raiseEvents();
                        }
                    }
                }, intDurationInMilliseconds);
            });
        };
    }
    /// </method>



    /* Splashscreen API */
    // Create the Phonegap Splashscreen object only ifthe main 'DeviceIntegrator' exists
    function Splashscreen_Initialize(strID) {
        // Create device watch data for the splashscreen object
        DeviceIntegrator.Splashscreen = {};

        // Create an empty default options object
        DeviceIntegrator.Splashscreen.defaultOptions = {};
        DeviceIntegrator.Splashscreen.Id = strID;

        /// <method name="DeviceIntegrator.Splashscreen.getConnection">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Splashscreen.show = function () {
            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceSplashscreenAccess.show) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Splashscreen.Id, "show", "Splashscreen");
                    return;
                }
                deviceSplashscreenAccess.show();
            });
        };

        /// <method name="DeviceIntegrator.Splashscreen.getConnection">
        /// <summary>
        /// 
        /// </summary>
        DeviceIntegrator.Splashscreen.hide = function () {
            DeviceIntegrator_DeviceReady(function () {
                if (typeof (deviceSplashscreenAccess.hide) != "function") {
                    DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Splashscreen.Id, "hide", "Splashscreen");
                    return;
                }
                deviceSplashscreenAccess.hide();
            });
        };
    }


    /* Storage API */
    // Create the Phonegap Storage object only ifthe main 'DeviceIntegrator' exists
    function Storage_Initialize(strID) {
        // Create device watch data for the LocalStorage object
        DeviceIntegrator.Storage = {};

        DeviceIntegrator.Storage.Id = strID;
        DeviceIntegrator.Storage.TransactionCommands = {};

        /// <method name="DeviceIntegrator.Storage.key">
        /// <summary>
        /// Gets key by position in array.
        /// </summary>
        DeviceIntegrator.Storage.key = function (strMethodKey, intPosition) {
            var objArguments = arguments;

            // When ready..
            DeviceIntegrator_DeviceReady(function () {
                // Get key by position in array.
                var strKey = deviceStorageAccess.key(intPosition);

                // Create and raise event to server, with method key and local storage data provided.
                Storage_GetDefaultSuccessLocalStorageEvent(strMethodKey, { "key": strKey });
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Storage.getItem">
        /// <summary>
        /// Gets item by key.
        /// </summary>
        DeviceIntegrator.Storage.getItem = function (strMethodKey, strKey) {
            var objArguments = arguments;

            // When ready..
            DeviceIntegrator_DeviceReady(function () {
                // Get item by key.
                var objItem = deviceStorageAccess.getItem(strKey);

                // Create and raise event to server, with method key and local storage data provided.
                Storage_GetDefaultSuccessLocalStorageEvent(strMethodKey, { "key": strKey, "item": objItem });
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Storage.clear">
        /// <summary>
        /// Clears local storage.
        /// </summary>
        DeviceIntegrator.Storage.clear = function (strMethodKey) {
            var objArguments = arguments;

            // When ready..
            DeviceIntegrator_DeviceReady(function () {
                //Clear local storage.
                deviceStorageAccess.clear();

                // Create and raise event to server, with method key provided.                
                Storage_GetDefaultSuccessLocalStorageEvent(strMethodKey);
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Storage.setItem">
        /// <summary>
        /// Sets item by key.
        /// </summary>
        DeviceIntegrator.Storage.setItem = function (strMethodKey, strKey, objItem) {
            var objArguments = arguments;

            // When ready..
            DeviceIntegrator_DeviceReady(function () {
                // Set item by key.
                deviceStorageAccess.setItem(strKey, (typeof objItem === "string" ? objItem : JSON.stringify(objItem)));

                // Create and raise event to server, with method key and local storage data provided.
                Storage_GetDefaultSuccessLocalStorageEvent(strMethodKey, { "key": strKey, "item": (typeof objItem === "string" ? objItem : JSON.stringify(objItem)) });
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Storage.removeItem">
        /// <summary>
        /// Removes item by key.
        /// </summary>
        DeviceIntegrator.Storage.removeItem = function (strMethodKey, strKey) {
            var objArguments = arguments;

            // When ready..
            DeviceIntegrator_DeviceReady(function () {
                // Remove item by key.
                deviceStorageAccess.removeItem(strKey);

                // Create and raise event to server, with method key and local storage data provided.                
                Storage_GetDefaultSuccessLocalStorageEvent(strMethodKey, { "key": strKey });
            });
        };
        /// </method>

        /// <method name="DeviceIntegrator.Storage.transaction">
        /// <summary>
        /// Runs and returns SQL transaction object.
        /// </summary>
        DeviceIntegrator.Storage.transaction = function (strMethodKey, dbInfo, strTransactionID) {
            var objArguments = arguments;

            // Initialize transaction commands array for this transaction.
            DeviceIntegrator.Storage.TransactionCommands[strTransactionID] = [];

            // Continue after timeout to ensure that commands have been added to transaction commands array
            setTimeout(function () {
                // If database info exists
                if (dbInfo) {
                    // When ready..            
                    DeviceIntegrator_DeviceReady(function () {
                        var arrArguments = [];
                        var fncTransactionCallback = Storage_TransactionCompleteHandler;
                        arrArguments.push(strMethodKey);

                        // Open database according to provided params
                        if (typeof (deviceStorageAccess.openDatabase) != "function") {
                            DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Storage.Id, "openDatabase", "Storage");
                            return;
                        }
                        var objDatabase = deviceStorageAccess.openDatabase(dbInfo.name, dbInfo.version, dbInfo.displayName, dbInfo.size);

                        // Call transaction
                        objDatabase.transaction(

                        // On transaction success..
                        function (objTransaction) {
                            // Run each command 
                            for (var commandIndex = 0; commandIndex < DeviceIntegrator.Storage.TransactionCommands[strTransactionID].length; commandIndex++) {
                                // Get the command
                                var objCommand = DeviceIntegrator.Storage.TransactionCommands[strTransactionID][commandIndex];

                                objTransaction.executeSql(objCommand.sqlExpression, [], Storage_GetQuerySuccessCallback(objCommand), Storage_GetQueryErrorCallback(objCommand));
                            }

                            // After all commands executed, delete array.
                            delete (DeviceIntegrator.Storage.TransactionCommands[strTransactionID]);

                            // Push the relevant params      
                            arrArguments.push(objTransaction);

                            for (var i = 3; i < objArguments.length; i++) {
                                arrArguments.push(objArguments[i]);
                            }

                            // Call it with relevant params.
                            fncTransactionCallback.apply(this, arrArguments);


                        },

                        // On transaction error..
                        function (objError) {
                            // Push the relevant params      
                            arrArguments.push(objError);

                            for (var i = 3; i < objArguments.length; i++) {
                                arrArguments.push(objArguments[i]);
                            }

                            // Call it with relevant params.
                            fncTransactionCallback.apply(this, arrArguments);
                        });
                    });
                }

            }, 100);

        };
        /// </method>

        /// <method name="DeviceIntegrator.Storage.executeSQLByTransaction">
        /// <summary>
        /// Prepares and stores SQL command in transaction commands array.
        /// </summary>
        DeviceIntegrator.Storage.executeSQLByTransaction = function (strMethodKey, strSQLCommand, strTransactionID) {
            var objArguments = arguments;

            // Initialize transaction commands array for this transaction if not exists
            if (typeof DeviceIntegrator.Storage.TransactionCommands[strTransactionID] === "undefined") {
                DeviceIntegrator.Storage.TransactionCommands[strTransactionID] = [];
            }

            // New command
            var objCommand = {};

            objCommand.sqlExpression = strSQLCommand;

            // Prepare arguments for callback
            objCommand.arguments = [];
            objCommand.callbackParams = [];

            objCommand.queryExecutionCallback = Storage_QuerySuccessHandler;

            // Store server method key.
            objCommand.arguments.push(strMethodKey);

            objCommand.arguments.push(strSQLCommand);

            for (var i = 3; i < objArguments.length; i++) {
                objCommand.callbackParams.push(objArguments[i]);
            }

            // Store command in Transaction Commands by transaction ID.
            DeviceIntegrator.Storage.TransactionCommands[strTransactionID].push(objCommand);
        };
        /// </method>

        /// <method name="DeviceIntegrator.Storage.executeSQL">
        /// <summary>
        /// Prepares and stores SQL command in transaction commands array.
        /// </summary>
        DeviceIntegrator.Storage.executeSQL = function (fncCallback, objDatabaseInfo, strSQLCommand) {
            // If database info exists
            if (objDatabaseInfo) {
                var objArguments = arguments;
                // When ready..            
                DeviceIntegrator_DeviceReady(function () {
                    var arrArguments = [];

                    // Open database according to provided params
                    if (typeof (deviceStorageAccess.openDatabase) != "function") {
                        DeviceIntegrator_RaiseDeviceNotImplementedEvent(DeviceIntegrator.Storage.Id, "openDatabase", "Storage");
                        return;
                    }
                    var objDatabase = deviceStorageAccess.openDatabase(objDatabaseInfo.name, objDatabaseInfo.version, objDatabaseInfo.displayName, objDatabaseInfo.size);

                    // Call transaction
                    objDatabase.transaction(

                    // On transaction success..
                    function (objTransaction) {
                        objTransaction.executeSql(strSQLCommand, [],

                            // On execution success..
                            function (objTransaction, objSQLResult) {
                                arrArguments.push(objSQLResult);

                                for (var i = 3; i < objArguments.length; i++) {
                                    arrArguments.push(objArguments[i]);
                                }

                                // Call it with relevant params.
                                fncCallback.apply(this, arrArguments);

                            },

                            // On execution error..
                            function (objError) {
                                // Push the relevant params      
                                arrArguments.push(objError);

                                for (var i = 3; i < objArguments.length; i++) {
                                    arrArguments.push(objArguments[i]);
                                }

                                // Call it with relevant params.
                                fncCallback.apply(this, arrArguments);
                            });
                    },

                    // On transaction error..
                    function (objError) {
                        // Push the relevant params      
                        arrArguments.push(objError);

                        for (var i = 3; i < objArguments.length; i++) {
                            arrArguments.push(objArguments[i]);
                        }

                        // Call it with relevant params.
                        fncCallback.apply(this, arrArguments);
                    });
                });
            }
        };
        /// </method>
    }
    /// </method>

    function Storage_TransactionCompleteHandler(strMethodKey, objResult) {
        // Create event
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Storage.Id, strMethodKey, null, true);

        if (typeof objResult.code === "number") {
            vwgContext.events.setEventAttribute(objEvent, "code", objResult.code);
        }

        // Raise event.
        vwgContext.events.raiseEvents();
    }

    /// <method name="Storage_QuerySuccessHandler">
    /// <summary>
    /// 
    /// </summary>
    function Storage_QuerySuccessHandler(strMethodKey, strSQLCommand, objResult) {
        // Create event
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Storage.Id, strMethodKey, null, true);
        // Add relevant attributes
        if (objResult.hasOwnProperty("code")) {
            vwgContext.events.setEventAttribute(objEvent, "code", objResult.code);
        }
        else {
            if (objResult.hasOwnProperty("rows") && objResult.rows.length > 0) {
                vwgContext.events.setEventAttribute(objEvent, "rows", objResult.rows.length);

                for (var i = 0; i < objResult.rows.length; i++) {
                    vwgContext.events.setEventAttribute(objEvent, "row" + i, JSON.stringify(objResult.rows.item(i)));
                }
            }

            if (objResult.hasOwnProperty("rowsAffected") && objResult.rowsAffected > 0) {
                vwgContext.events.setEventAttribute(objEvent, "rowsAffected", objResult.rowsAffected);
            }

            // PHONEGAP CRASHES
            /*if (strSQLCommand.toLowerCase().indexOf("insert ") !== -1 && typeof objResult.insertId === "number" && objResult.insertId > 0)
            {
                vwgContext.events.setEventAttribute(objEvent, "insertId", objResult.insertId);
            }*/
        }

        vwgContext.events.setEventAttribute(objEvent, "command", strSQLCommand);

    }
    /// </method>

    /// <method name="Storage_GetDefaultSuccessLocalStorageEvent">
    /// <summary>
    /// Create an event from the LocalStorage arguments
    /// </summary>
    function Storage_GetDefaultSuccessLocalStorageEvent(strMethodKey, objItem) {
        var objEvent = vwgContext.events.createEvent(DeviceIntegrator.Storage.Id, strMethodKey, null, true);

        if (objItem) {
            objItem = JSON.stringify(objItem);

            vwgContext.events.setEventAttribute(objEvent, "localStorageArgs", objItem);
        }

        // Raise
        vwgContext.events.raiseEvents();
    }
    /// </method>

    /// <method name="Storage_GetQuerySuccessCallback">
    /// <summary>
    /// 
    /// </summary>
    function Storage_GetQuerySuccessCallback(objCommand) {
        return function (objRunningTransaction, objResultSet) {
            // Push result set
            objCommand.arguments.push(objResultSet);

            // Copy callback params to arguments
            for (var i = 0; i < objCommand.callbackParams.length; i++) {
                objCommand.arguments.push(objCommand.callbackParams[i]);
            }

            // Call callback with arguments
            objCommand.queryExecutionCallback.apply(this, objCommand.arguments);
        };
    }
    /// </method>

    /// <method name="Storage_GetQueryErrorCallback">
    /// <summary>
    /// 
    /// </summary>
    function Storage_GetQueryErrorCallback(objCommand) {
        return function (objError) {
            // Push error object
            objCommand.arguments.push(objError);

            // Copy callback params to arguments
            for (var i = 0; i < objCommand.callbackParams.length; i++) {
                objCommand.arguments.push(objCommand.callbackParams[i]);
            }

            // Call callback with arguments
            objCommand.queryExecutionCallback.apply(this, objCommand.arguments);
        };
    }
    /// </method>


    /* Unimplemented Error handling API */
    function DeviceIntegrator_RaiseDeviceNotImplementedEvent(id, strMethod, strFeature) {
        var objEvent = vwgContext.events.createEvent(id, "Event.DeviceNotImplementedError", null, true);
        vwgContext.events.setEventAttribute(objEvent, "methodName", strMethod);
        vwgContext.events.setEventAttribute(objEvent, "featureName", strFeature);
        vwgContext.events.raiseEvents();
    }
