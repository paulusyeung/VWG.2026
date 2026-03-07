
//This function will create the actual contact with the server, and will initiate the callback
function vwgAjax(strUrl, strData) 
{
    //incase of giving params in the URL (like vwgInstance), i will delete the unnecessary query string info.
    strUrl = strUrl.split("?")[0];

    // Define a response type variable.
    var strResponseType = "document";

    // Validate navigator and user agent.
    if (navigator && navigator.userAgent) {
        // Check if IE browser is in use through user agent.
        if (new RegExp("MSIE ([^;]*)|Trident.*; rv:([0-9.]+)").test(navigator.userAgent)) {
            // Change response type.
            strResponseType = "msxml-document";
        }
    }

    var objXHR = $.ajax({
        url: strUrl,
        async: true,
        type: "POST",
        data: strData,
        dataType: "text"
    });

    objXHR.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

    objXHR.done(function (strDocument) {
        window.setTimeout(function () {
            // Write the html to the document. 
            // NOTE: We use "replace" so there will be no history for this write.
            window.document.open("text/html", "replace");
            window.document.write(strDocument);
            window.document.close();
        }, 1);
    });
};

//setting the information needed in the server
function Preload_SendClientParamsToServer(strPageName, objFuncArguments, intPageInstance) 
{
    var arrData = ["vwginit=1"];

    arrData.push("vwginstance=" + intPageInstance);

    //Sending some client general information (e.g. sizes)
    //Set screen params
    arrData.push("Attr.DeviceOrientation=" + Preload_DeviceOrientation());
    arrData.push("Attr.ScrAvailHeight=" + screen.availHeight);
    arrData.push("Attr.ScrAvailWidth=" + screen.availWidth);
    arrData.push("Attr.ScrHeight=" + screen.height);
    arrData.push("Attr.ScrWidth=" + screen.width);
    arrData.push("Attr.ScrColorDepth=" + screen.colorDepth);
    if (typeof window.devicePixelRatio != 'undefined') 
    {
        arrData.push("Attr.ScrDevicePixelRatio=" + window.devicePixelRatio);
    }

    // Set browser params
    arrData.push("Attr.BrwClientHeight=" + window.document.body.clientHeight);
    arrData.push("Attr.BrwClientWidth=" + window.document.body.clientWidth);

    // Create a function to be used by each flagSet that holds a promise to support async tests
    var Preload_GetDeferredForModernizer = function (strflagsSetID, strPropertyName)
    {
        var objDefer = new $.Deferred();
        objDefer.done(function (result)
        {
            arrData.push(strPropertyName + result);
        });

        //getting the information from the Modernizr (browser capabilities)
        //this function, without given parameters will return a bitwise number, 
        //representing the browser abilities. later will determine the sources behaviour.
        ModernizrHelper.getFlagsCombo(strflagsSetID, objDefer);

        return objDefer;
    };

    //// Wait until all checks are finished and
    $.when(Preload_GetDeferredForModernizer('CSS3', "Attr.CSS3="), Preload_GetDeferredForModernizer('HTML5', "Attr.HTML5="), Preload_GetDeferredForModernizer('MISC', "Attr.MISC=")).done(function ()
    {
        var strData = arrData.join('&');
        //calling the page, but this time it is expected to set info, and initiate the function.
        //the asynch is false, because there is no need for current user responsive, if changed to true, should add onreadystatechange functionality
        vwgAjax(strPageName, strData);
    });
};

/// <method name="Preload_DeviceOrientation">
/// <summary>
/// Returns the device orientation for server.
/// </summary>
function Preload_DeviceOrientation() {
    if ($(window).width() > $(window).height()) {
        return "1";
    }

    return "0";
}
/// </method>