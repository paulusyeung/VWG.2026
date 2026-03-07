/**
* Modernizer Helper - This is a utility object, aimed at providing flags combos 
* that indicates of features detected by the modernizr library (CSS3, HTML5 features)
* http://www.modernizr.com/
*/

/* Copy of the constant that are in the Constants.js file, because i can't get it with it's current forking settings. */


var Constants =
 {
     Screen:
     {
         // Screen Params
         AvailHeight: "Attr.ScrAvailHeight",
         AvailWidth: "Attr.ScrAvailWidth",
         Height: "Attr.ScrHeight",
         Width: "Attr.ScrWidth",
         ColorDepth: "Attr.ScrColorDepth"
     },

     Browser:
     {
         // Browser Params
         ClientHeight: "Attr.BrwClientHeight",
         ClientWidth: "Attr.BrwClientWidth"
     },

     Modernizr:
    {
        // request params
        CSS3Common: "Attr.ModCSS3Common",
        CSS3Anim: "Attr.ModCSS3A",
        HTML5: "Attr.ModHTML5",
        HTML5InputTypes: "Attr.ModHTML5InputTypes",
        HTML5InputAttributes: "Attr.ModHTML5InputAttributes",
        MISC: "Attr.ModMISC",

        // Propery names
        Properties:
        {
            //The properties will be filled dynamically during the page load.



            // HTML5InputTypes_Date: ["date", 16384],
            // HTML5InputAttributes_PlaceHolder: ["placeholder", 32768],
        },

        // Special cases, such as "input types"
        PropNames:
        {
            HTML5InputTypes: "inputtypes",
            HTML5InputAttributes: "input"
        }
    }
 };


 var ModernizrHelper = (function () {

    // Define local hash arrays.
    var _modProperties = Constants.Modernizr.Properties;
    var _modPropNames = Constants.Modernizr.PropNames;

    // Define a local set property function.
    var _setProperties = function (_strPropertyPrefix, _arrEnumsValues)
    {
        // Create a new object for current property.
        _modProperties[_strPropertyPrefix] = new Object;

        // Split all values contain in property value.
        var _arrValues = _arrEnumsValues.split(',');

        // Loop all values contain in property value.
        for (var _index in _arrValues)
        {
            // Split current value with the equal character.
            var _splittedItem = _arrValues[_index].split('=');
            if (_splittedItem && _splittedItem.length == 2)
            {
                // Add current property.
                _modProperties[_strPropertyPrefix][_splittedItem[0].toLowerCase()] = _splittedItem[1];
            }
        }
    }

    // Generates the constants related to the modernizr dynamically
    var _strEnumsValues = "Context.BrowserCapabilitiesEnums";

    var _arrEnumsValues = _strEnumsValues.split('|');

    _setProperties('CSS3', _arrEnumsValues[0]);
    _setProperties('HTML5', _arrEnumsValues[1]);
    _setProperties('MISC', _arrEnumsValues[2]);

    var _resolveProperty = function (key, objKeyDefer)
    {
        switch (key)
        {
            case "scrollbarsupport":
                if (document)
                {
                    // Create a div element with scroller and append it to body element.
                    var objDivElement = document.createElement("DIV");
                    objDivElement.style.cssText = "overflow:scroll;width:50px;height:50px;";
                    document.body.appendChild(objDivElement);

                    // Test if div's client area and offset area are equals.
                    var blnIsScrollbarSupported = (objDivElement.clientWidth != objDivElement.offsetWidth || objDivElement.clientHeight != objDivElement.offsetHeight);

                    // Remove div from body element and return test result.
                    document.body.removeChild(objDivElement);

                    // Resolve promise
                    objKeyDefer.resolve([blnIsScrollbarSupported, key]);
                }
                break;
            case "virtualkeyboardpopuponfocus":
                var objInput = $("#input");

                // Make sure that the inpur is blurred before starting the measure
                objInput.blur();
                setTimeout(function ()
                {
                    // Calculate the window's height before focusing
                    var intHeightBefore = $(window).height();
                    objInput.focus();

                    setTimeout(function ()
                    {
                        // Calculate the window's height after focusing
                        var intHeightAfter = $(window).height();

                        // If the delta is > 0 then just by focusing the input the window got smaller - so we have a virtual keyboard
                        var blnIsVirtualKeyboardPopupOnFocus = intHeightBefore !== intHeightAfter;

                        // Resolve promise
                        objKeyDefer.resolve([blnIsVirtualKeyboardPopupOnFocus, key]);
                    }, 400);
                }, 400);
                break;
            default:
                // Resolve promise as not supported for non existing keys
                objKeyDefer.resolve(false);
                break;
        }
    };

    var _getFlagsCombo = function (flagsSetID, modObject, objFlagsDefer)
    {
        var supported = [];

        if (_modProperties)
        {
            var arrAllKeysDefers = [];
            for (var key in _modProperties[flagsSetID])
            {
                var objKeyDefer = new $.Deferred();
                arrAllKeysDefers.push(objKeyDefer);
                var value = modObject[key]; //gets true or false according the checked property. The key should be a lower case modernizr property.

                if (value)
                {
                    supported.push(key);
                    objKeyDefer.resolve();
                }
                else
                {
                    objKeyDefer.done(function (resultArray)
                    {
                        if (resultArray && resultArray[0])
                        {
                            supported.push(resultArray[1]);
                        }
                    });

                    _resolveProperty(key, objKeyDefer);
                }
            }

            $.when.apply(null, arrAllKeysDefers).done(function ()
            {
                var result = 0;
                var len = supported.length;
                for (var i = 0; i < len; i++)
                {
                    result = result | _modProperties[flagsSetID][supported[i]];
                }

                objFlagsDefer.resolve(result);
            });
        }
    };

    var getFlagsCombo = function (flagsSetID, objFlagsDefer)
    {
        var modObject = Modernizr;
        if (flagsSetID in _modPropNames)
        {
            modObject = modObject[_modPropNames[flagsSetID]];
        }

        if (modObject)
        {
            return _getFlagsCombo(flagsSetID, modObject, objFlagsDefer);
        }
    };

    return {

        getFlagsCombo: getFlagsCombo
    }

}());