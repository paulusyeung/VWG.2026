/// <method name="VisualEffects_ChangeVisualEffect">
/// <summary>
/// 
/// </summary>
function VisualEffects_ChangeVisualEffect(objTargetNode, objTragetPreviousValues, objWindow, strBeforeEffectAttributeName, strAfterEffectAttributeName, fncAfterEffectCallback)
{
    // If before/after effect attributes not defined, use default.
    strBeforeEffectAttributeName = strBeforeEffectAttributeName || "Attr.OnDrawVisualEffects";
    strAfterEffectAttributeName = strAfterEffectAttributeName || "Attr.AfterDrawVisualEffects";

    // Take the element's ID
    var strId = Xml_GetAttribute(objTargetNode, "Attr.Id");
    if (strId)
    {
        // Get element from DOM
        var objElement = Web_GetElementByDataId(strId, objWindow);
        if (objElement)
        {            
            // Get the new visual effect value from the XML
            var strVisualEffectValue = Xml_GetAttribute(objTargetNode, strBeforeEffectAttributeName);

            // Get the visual effect's old value
            var strOldValues = Web_GetAttribute(objElement, "vwgondrawvisualeffects", true) || objTragetPreviousValues[strBeforeEffectAttributeName];

            if (strVisualEffectValue || strOldValues)
            {
                // Preserve new on draw visual effects on eoement for future use (in case of update VisualEffect parameters)
                Web_SetAttribute(objElement, "vwgondrawvisualeffects", strVisualEffectValue);

                // Parse values to Key-Value pair
                var objNewValues = VisualEffects_ParseVisualEffectValue(strVisualEffectValue);
                var objOldValues = VisualEffects_ParseVisualEffectValue(strOldValues);

                var jqElement = $(objElement);

                // If an old effect is not a member of the new effect, remove it
                for (var strAttribute in objOldValues)
                {
                    jqElement.css(strAttribute, "");
                }

                // The transitions themselves should be inserted only after the "before" styles have been inserted
                var objTransitionRelatedAttributes = {};

                for (var objStyleName in objNewValues)
                {
                    if (objStyleName.indexOf("transition") != -1)
                    {
                        // Save the Transition attributtes
                        objTransitionRelatedAttributes[objStyleName] = objNewValues[objStyleName];
                    }
                    else
                    {
                        // Set the styles on the element
                        jqElement.css(objStyleName, objNewValues[objStyleName]);
                    }
                }

                // This line has no logical meaning. All it does is redrawing the element because the browser needs to calculate the offsetWidth property
                var objDummy = objElement.offsetWidth;

                // Set the transitions
                jqElement.css(objTransitionRelatedAttributes);                

                // Apply the after effects
                VisualEffects_ApplyVisualEffectsAfterDraw(window, strId, Xml_GetAttribute(objTargetNode, strAfterEffectAttributeName), objElement, objTargetNode, strBeforeEffectAttributeName, strAfterEffectAttributeName, fncAfterEffectCallback);
            }
            else
            {
                // If callback provided, call it.
                if (typeof fncAfterEffectCallback === "function")
                {
                    fncAfterEffectCallback();
                }

                // If it is after entrance effect, hide underlying elements.
                if (strAfterEffectAttributeName === "Attr.AfterEntranceEffect")
                {
                    $('#' + mstrActiveWindowGuid).siblings().css("display", "none");
                }
            }
        }
    }
}
/// </method>

/// <method name="VisualEffects_ParseVisualEffectValue">
/// <summary>
/// 
/// </summary>
function VisualEffects_ParseVisualEffectValue(strValues)
{
    var objKeyValue = {};
    if (strValues)
    {
        var arrAttributes = strValues.split(";");
        for (var i = 0; i < arrAttributes.length; ++i)
        {
            if (arrAttributes[i])
            {
                var arrKeyValue = arrAttributes[i].split(":");

                if (arrKeyValue.length == 2)
                {
                    objKeyValue[arrKeyValue[0]] = arrKeyValue[1];
                }
            }
        }
    }
    return objKeyValue;
}
/// </method> 

/// <summary>
/// Handles the aplly of the visual effect after draw css changes, creating the animation.
/// </summary>
function VisualEffects_ApplyVisualEffectsAfterDraw(objWindow, intClientId, strListOfStyles, objElement, objNodeElement, strBeforeEffectAttributeName, strAfterEffectAttributeName, fncAfterEffectCallback)
{
    // If attribute names not provided, use OnDraw and AfterDraw by default.
    strBeforeEffectAttributeName = strBeforeEffectAttributeName ||  "Attr.OnDrawVisualEffects";
    strAfterEffectAttributeName = strAfterEffectAttributeName || "Attr.AfterDrawVisualEffects";

    if (strListOfStyles && intClientId)
    {
        if (!objElement)
        {
            objElement = Web_GetElementByDataId(intClientId, null);
        }

        var arrStyles = strListOfStyles.split(';');
        var dblTransitionTotalTime = 0;
        var blnHasTransitionTotalTime = false;
        var strProcessedAfterStyles = "";
        
        for (var i = 0; i < arrStyles.length; i++)
        {

            var strOneStyle = arrStyles[i].split(':'); //gets true or false according the checked property. The key should be a lower case modernizr property.
            if (strOneStyle.length == 2 && strOneStyle[0] != '')
            {
                // Checking the total time of all the effects to make sure all be seen before throwing the end event.
                if (strOneStyle[0] == "Labels.TransitionTotalTime")
                {
                    dblTransitionTotalTime = strOneStyle[1] * 1.0;
                    // Indicates the event should be fired.
                    blnHasTransitionTotalTime = true;
                }
                else
                {
                    $(objElement).css($.trim(strOneStyle[0]), $.trim(strOneStyle[1]));
                    strProcessedAfterStyles += strOneStyle[0] + ":" + strOneStyle[1] + ";";
                }
            }
        }       

        //setting client side after transition position to the xml in case of redraw
        if (!objNodeElement)
        {
            objNodeElement = Data_GetNode(Data_GetDataId(intClientId));
        }

        // Preserve original entrance effects for navigation.
        if (strBeforeEffectAttributeName == "Attr.BeforeEntranceEffect" && strAfterEffectAttributeName == "Attr.AfterEntranceEffect")
        {
            // Do it once.
            if (!Xml_HasAttribute(objNodeElement, "RBEE"))
            {
                var strBeforeEffect = Xml_GetAttribute(objNodeElement, strBeforeEffectAttributeName, null);
                var strAfterEffect = Xml_GetAttribute(objNodeElement, strAfterEffectAttributeName, null);

                if (strBeforeEffect && strAfterEffect)
                {
                    Xml_SetAttribute(objNodeElement, "RBEE", strBeforeEffect);
                    Xml_SetAttribute(objNodeElement, "RAEE", strAfterEffect);
                }
            }
        }

        Xml_SetAttribute(objNodeElement, strBeforeEffectAttributeName, strProcessedAfterStyles);
        Xml_RemoveAttribute(objNodeElement, strAfterEffectAttributeName);

        if (blnHasTransitionTotalTime) 
        {
            objWindow.setTimeout(
            function ()
            {
                // If callback provided, call it.
                if (typeof fncAfterEffectCallback === "function")
                {
                    fncAfterEffectCallback();
                }

                // If it is after entrance effect, hide underlying elements.
                if (strAfterEffectAttributeName === "Attr.AfterEntranceEffect")
                {
                    // Hide active form siblings.
                    $('#' + mstrActiveWindowGuid).siblings().css("display", "none");
                }

                VisualEffects_CreateTransitionEndedEvent(intClientId);
            }, dblTransitionTotalTime * 1000 + 500);
        }
    }
    else
    {
        // If callback provided, call it.
        if (typeof fncAfterEffectCallback === "function")
        {
            fncAfterEffectCallback();
        }

        // If it is after entrance effect, hide underlying elements.
        if (strAfterEffectAttributeName === "Attr.AfterEntranceEffect")
        {
            $('#' + mstrActiveWindowGuid).siblings().css("display", "none");
        }
    }
}

/// <summary>
/// Handles the transition end event call.
/// </summary>
function VisualEffects_CreateTransitionEndedEvent(intClientId)
{
    // Create event. 
    var objEvent = Events_CreateEvent(intClientId, "TransitionEnded");
    
    // Raise critical event.
    if (Data_IsCriticalEvent(intClientId, "Event.TransitionVisualEffectEnd"))
    {
        Events_RaiseEvents();
    }

    Events_ProcessClientEvent(objEvent);
    
}