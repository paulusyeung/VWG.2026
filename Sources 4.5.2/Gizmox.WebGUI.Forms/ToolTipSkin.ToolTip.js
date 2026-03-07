var mobjToolTipTemplatesCache = {};

/// <method name="ToolTip_GetTemplateByAccessName">
/// <summary>
/// Gets tooltip template by its access name. Assumes html template existance in skin.
/// </summary>
function ToolTip_GetTemplateByAccessName(strTemplateAccessName, strSkinPath, fncCallback)
{
    // Construct access name.
    strTemplateAccessName = strSkinPath + strTemplateAccessName;

    // Get cached template.
    var strTemplate = mobjToolTipTemplatesCache[strTemplateAccessName];

    // If still does not exist in cache..
    if (Aux_IsNullOrEmpty(strTemplate))
    {
        // Get it from server.
        $.ajax({
            url: strTemplateAccessName + ".wgx",
            success: function (strData) {
                // Add to cache
                strTemplate = mobjToolTipTemplatesCache[strTemplateAccessName] = strData;

                // Call provided callback.
                fncCallback(strTemplate);
            },
            error: function () {

                // Add error to cache
                strTemplate = mobjToolTipTemplatesCache[strTemplateAccessName] = "Could not retrieve tooltip template";

                // Call provided callback.
                fncCallback(strTemplate);
            }
        });
    }

    // If already cached..
    else
    {
        // Call provided callback.
        fncCallback(strTemplate);        
    }
}
/// </method>

/// <method name="ToolTip_SetToolTip">
/// <summary>
/// Prepares and caches tooltip template + data.
/// </summary>
function ToolTip_SetToolTip(strGuid, strSkinPath, objWindow)
{
    var strKeyValueSeparator = "_VWG_KVS_";
    var strEntrySeparator = "_VWG_ETT_";
    var objToolTipData = {};
    var arrToolTipEntries = null;

    // Get extended tooltip attributes.
    var strToolTipData = Aux_DecodeText(Data_GetAttribute(strGuid, "Attr.ExtendedToolTip", ""));
    var strTemplateAccessName = Data_GetAttribute(strGuid, "Attr.ExtendedToolTipTemplateName", "");

    if (!Aux_IsNullOrEmpty(strToolTipData))
    {
        // Parse tooltip data
        arrToolTipEntries = strToolTipData.split(strEntrySeparator);
        
        for (var i = 0, length = arrToolTipEntries.length; i < length; i++)
        {
            var arrKeyValuePair = arrToolTipEntries[i].split(strKeyValueSeparator);
            var strKey = arrKeyValuePair[0];
            var strValue = arrKeyValuePair[1];

            if (!Aux_IsNullOrEmpty(strKey) && !Aux_IsNullOrEmpty(strValue))
            {
                objToolTipData[strKey] = strValue;
            }
        }

        // Get template by name.
        ToolTip_GetTemplateByAccessName(strTemplateAccessName, strSkinPath,

        function (strTemplate)
        {
            // Apply template data on template.
            if (!Aux_IsNullOrEmpty(strTemplate) && objToolTipData)
            {
                for (strToolTipProperty in objToolTipData)
                {
                    strTemplate = strTemplate.replace("{:" + strToolTipProperty + "}", objToolTipData[strToolTipProperty]);
                }
            }

            // Apply tooltip template + data on element.
            ToolTip_ApplyToolTip(strGuid, strTemplate, objWindow);
        });
    }   
}
/// </method>

/// <method name="ToolTip_ApplyToolTip">
/// <summary>
/// Applies tooltip template + data on element.
/// </summary>
function ToolTip_ApplyToolTip(strGuid, strToolTipContent, objWindow)
{
    // Get tooltip target html element.
    var objElement = Web_GetElementByDataId(strGuid, objWindow);
	if(objElement)
	{
    	// Reset/add title (needed by plugin, since we do not have info to set 'items' tooltip attribute)
	    objElement.title = "";

    	// Apply tooltip on element.
	    objWindow.$(objElement).tooltip({ content: strToolTipContent });
	}
}

function ToolTip_CloseToolTip(strGuid, objWindow)
{
    // Get tooltip target html element.
    var objElement = Web_GetElementByDataId(strGuid, objWindow);
    if (objElement) {
        // If tooltip defined on element
        if (typeof objWindow.$(objElement).tooltip === "function") {
            // Close tooltip.
            objWindow.$(objElement).tooltip("close");
        }
    }
}

