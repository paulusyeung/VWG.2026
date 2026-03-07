/// <method name="EditorFrame_OnLoad">
/// <summary>
/// Handles iframe load event.
/// </summary>
/// <param name="objForm"></param>
function EditorFrame_OnLoad()
{
    // Run as page loaded
    if (window.ParentForm)
    {
        EditorFrame_InitEditor();
    }
    else
    {
        setTimeout(function ()
        {
            EditorFrame_InitEditor();
        }, 10);
    }
}
/// </method>

/// <method name="EditorFrame_InitEditor">
/// <summary>
/// Called to initialize FCKEditor
/// </summary>
/// <param name="objForm"></param>
function EditorFrame_InitEditor()
{
    var objConfig = {};

    // If parent form defined on window..   
    if (window.ParentForm)
    {
        // Get control id
        var strGuid = ParentForm.getAttribute("data-vwgguid");

        if (strGuid)
        {
            // Get hidden inputs (value & configuration)
            var objValueElement = ParentForm["CID_" + strGuid];
            var objConfigElement = ParentForm["CID_" + strGuid + "___Config"];

            if (objValueElement && objConfigElement)
            {
                // Get input values
                var strValue = objValueElement.value;
                var strConfig = objConfigElement.value;

                // Build Config object
                var arrConfigSettings = strConfig.split("&");

                for (var i = 0, count = arrConfigSettings.length; i < count; ++i)
                {
                    var strConfigKey = arrConfigSettings[i].split("=")[0];
                    var strConfigValue = arrConfigSettings[i].split("=")[1];

                    // Parse value
                    if (strConfigKey && strConfigValue)
                    {
                        try
                        {
                            objConfig[strConfigKey] = eval(strConfigValue);
                        } 
                        catch (e)
                        {
                            // Notify user if error occured during value parsing. 
                            alert(strConfigKey + " property has invalid value.");
                        }
                    }
                }

                // Set full width.
                objConfig.width = '100%';  

                // Init editor
                var objEditor = CKEDITOR.replace("editor1", objConfig);  
				objEditor.on( 'instanceReady', function(event){ 					
					
					// Enable Save button and submit form on Save
					event.editor.commands.save.enable();
					event.editor.on('save', function(event) { event.editor.VWGSubmitAction = "Save"; window.ParentForm.submit();});
					
					// Maximize editor in edit area - this call never returns so make it the last one on instanceReady
					event.editor.execCommand( 'maximize'); 
				});		
                objEditor.on( 'resize', function(event) {
				    event.editor.execCommand( 'maximize');
				});
				objEditor.setData(strValue);

				
                // Save editor reference on form.
                ParentForm.Editor = objEditor;
            }
        }
    }
}
/// </method>