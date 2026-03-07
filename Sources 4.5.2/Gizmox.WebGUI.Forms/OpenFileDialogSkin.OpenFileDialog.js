var mintTotalFiles = 0;
var mintUploaderIndex = 0;
var mintUploaderCount = 0;
var mobjSelectedFileRow = null;
var mblnMultiselect = false;
var mstrWindowGuid = "";
var mobjSWFUpload = null;
var mstrSWFUploadError = "";
var mblnUseFlash = false;
var mintTotalBytes = 0;
var mintSumBytesOfUploadedFiles = 0;
var mobjFiles = [];
var mstrEnabledButtonTextStyle = ".theFont {[Skin.FlashAddButtonFont];text-align:center;}";
var mstrDisabledButtonTextStyle = ".theFont {[Skin.FlashAddButtonFont];color: #B7B4C9;text-align:center;}";

/// <method name="Upload_Init">
/// <summary>
///
/// </summary>
function Upload_Init()
{
    // Get the multi select attribute value.
    mblnMultiselect = HtmlBox_GetAttribute("Multiselect", "1") == "1";

    // Get the use flash attribute value.
    mblnUseFlash = HtmlBox_GetAttribute("UseFlash", "1") == "1";

    // If the Flash version of the OpenFileDialog needs to be used, and the Flash plugin is installed on the
    // the client, and the version of the Flash plugin is 9 or higher.
    if (!(mblnUseFlash && Plugin.isInstalled("Flash") && parseFloat(Plugin.getVersion("Flash")) >= 9))
    {
        mblnUseFlash = false;
    }

    // Show / hide the flash progress display.
    mobjApp.OpenFileDialog_ShowHideProgressMessage(Upload_GetGatewayId(), mblnUseFlash);

    // Get upload script.
    var strUploadScript = Upload_GetUploadScript();

    // Set upload form action
    $$("UploadForm").setAttribute("action", strUploadScript);

    // Store window guid
    mstrWindowGuid = Upload_GetGatewayId();

    // If use flash
    if (mblnUseFlash)
    {

        Upload_NormalizeFlashFontSize();

        // used to test swf uploading
        mobjSWFUpload = Upload_CreateSWFUpload
	    (
        /* arg_flash_url                        */ "[Skin.Path]OpenFileDialog.SWFUpload.swf.wgx",
        /* arg_upload_url                       */ strUploadScript,
        /* arg_post_params                      */ null,
        /* arg_file_size_limit                  */ parseInt(HtmlBox_GetAttribute("MaxFileSize", "4096")),
        /* arg_file_types                       */ HtmlBox_GetAttribute("AllowedFileTypes", "*.*"),
	    /* arg_file_types_description           */ HtmlBox_GetAttribute("AllowedFileTypesDescription", "All files..."),
        /* arg_file_upload_limit                */ 0,
        /* arg_file_queue_limit                 */ 0,
        /* arg_custom_settings_progressTarget   */ null,
        /* arg_custom_settings_cancelButtonId   */ null,
        /* arg_debug                            */ false,
	    /* arg_multiselect                      */ mblnMultiselect,
        /* arg_button_image_url                 */ "[Skin.Path]Button75X92BG.gif.wgx",
        /* arg_button_width                     */ 75,
        /* arg_button_height                    */ 23,
        /* arg_button_placeholder_id            */ "StandardUploadButton",
        /* arg_button_text                      */ "<span class=\"theFont\">Labels.Add</span>",
        /* arg_button_text_style                */ mstrEnabledButtonTextStyle,
        /* arg_button_text_left_padding         */ 0,
        /* arg_button_text_top_padding          */ 2,
        /* arg_file_queued_handler              */ Upload_FileQueued,
        /* arg_file_queue_error_handler         */ Upload_QueueError,
        /* arg_file_dialog_complete_handler     */ Upload_DialogComplete,
        /* arg_upload_start_handler             */ Upload_FileStart,
        /* arg_upload_progress_handler          */ Upload_UploadProgress,
        /* arg_upload_error_handler             */ Upload_Error,
        /* arg_upload_success_handler           */ Upload_Success,
        /* arg_upload_complete_handler          */ Upload_FileCompleted,
        /* arg_queue_complete_handler           */ Upload_QueueCompleted,
        /* arg_debug_handler                    */ Upload_Debug
        )
    }
    else
    {
        // Set arbitrary percentage
        mobjApp.OpenFileDialog_UpdateProgress(Upload_GetGatewayId(), 50, 50);

        // Set the message
        mobjApp.OpenFileDialog_SetUploadMessage(Upload_GetGatewayId(), "Uploading", true);

        $$("StandardUploadButton").className = "Upload-Button Upload-ButtonNormal";
    }

    // Initialize the actions container.
    Upload_InitActions();
    mobjApp.Common_ApplyAccessibilityFeatures(document.body);
}
/// </method>

/// <method name="Upload_NormalizeFlashFontSize">
/// <summary>
/// 
/// </summary>
function Upload_NormalizeFlashFontSize()
{
    var objRegExp = new RegExp("font-size:[0-9]+\\.?[0-9]*pt;");

    //  Check if font size value is in pt
    var objResult = objRegExp.exec(mstrEnabledButtonTextStyle);
    if (objResult && objResult.length == 1)
    {
        // Get screen dpi
        var intDpi = mobjApp.Web_GetWebElement("VWG_DPI", window).offsetHeight;

        // Get size string value
        var strSize = objResult[0].split(":")[1];

        // Calculate scale size
        var dblSize = Math.round(parseFloat(strSize.substring(0, strSize.length - 3)) * intDpi / 72);

        // Build new font size
        var strNewSize = "font-size:" + dblSize.toString() + ";";

        // Update size values
        mstrEnabledButtonTextStyle = mstrEnabledButtonTextStyle.replace(objResult[0], strNewSize);
        mstrDisabledButtonTextStyle = mstrDisabledButtonTextStyle.replace(objResult[0], strNewSize);
    }
}
/// </method>

/// <method name="Upload_GetGatewayId">
/// <summary>
/// 
/// </summary>
function Upload_GetGatewayId()
{
    return HtmlBox_GetAttribute("GatewayId");
}
/// </method>

/// <method name="Upload_DisableUploadButton">
/// <summary>
/// 
/// </summary>
function Upload_DisableUploadButton(blnDisable)
{
    if (mblnUseFlash && mobjSWFUpload)
    {
        // Disable / Enable button.
        mobjSWFUpload.setButtonDisabled(blnDisable);

        // Set Disable / Enable button style.
        mobjSWFUpload.setButtonTextStyle(blnDisable ? mstrDisabledButtonTextStyle : mstrEnabledButtonTextStyle);
    }
    else
    {
        $$("StandardUploadButton").disabled = blnDisable;
    }
}
/// </method>

/// <method name="Upload_Submit">
/// <summary>
/// Submits the current file queue
/// </summary>
function Upload_Submit()
{
    // If at least one file was selected
    if (mintTotalFiles > 0)
    {
        // Clear error message.
        mstrSWFUploadError = "";

        // Disable all action buttons.
        $$("UploadOkButton").disabled = true;

        // Display the prgoress panel.
        mobjApp.OpenFileDialog_ShowHideProgress(Upload_GetGatewayId(), true);

        if (mobjSWFUpload != null)
        {
            // Initialize counters.
            mintTotalBytes = 0;
            mintSumBytesOfUploadedFiles = 0;

            // Start uploading local files queue.
            Upload_UploadNextFile();
        }
        else
        {
            $$("UploadForm").submit();
        }
    }
}
/// </method>

/// <method name="Upload_GetFileName">
/// <summary>
/// 
/// </summary>
function Upload_GetFileName(strFullName)
{
    var arrFullName = strFullName.split("\\");
    return arrFullName.pop();
}
/// </method>

/// <method name="Upload_SelectFile">
/// <summary>
/// Select a file in the list
/// </summary>
function Upload_SelectFile(objCurrentFileRow)
{
    if (objCurrentFileRow != null)
    {
        // Get the UploadList table element.
        var objUploadList = $$("UploadList");
        if (objUploadList)
        {
            // Set selected
            objCurrentFileRow.className = 'Selected';

            // Clear all rows
            for (intRowIndex = 0; intRowIndex < objUploadList.rows.length; intRowIndex++)
            {
                var objTempFileRow = objUploadList.rows[intRowIndex];
                if (objCurrentFileRow != objTempFileRow)
                {
                    objTempFileRow.className = "";
                }
            }

            // Set selected
            mobjSelectedFileRow = objCurrentFileRow;
        }
    }
}
/// </method>

/// <method name="Upload_RemoveFile">
/// <summary>
/// Removes the current selected file in the list
/// </summary>
function Upload_RemoveFormFile()
{
    // If there is a current selected file
    if (mobjSelectedFileRow && mobjSelectedFileRow.FileID)
    {
        // Get previous sibling
        var objPreviousSibling = mobjSelectedFileRow.previousSibling;
        var objNextSibling = mobjSelectedFileRow.nextSibling;

        // Get seleccted list item uploader
        var objCurrentUploader = $$("UploadForm").elements[mobjSelectedFileRow.FileID];
        if (objCurrentUploader)
        {
            // Remove uploader
            objCurrentUploader.parentNode.removeChild(objCurrentUploader);

            mintUploaderCount--;
            // Update selected files counter
            mintTotalFiles--;

            if (!mblnMultiselect)
            {
                // Disable "Add" button
                Upload_DisableUploadButton(false);
            }

            // Delete the uploader list item
            $$("UploadList").deleteRow(mobjSelectedFileRow.rowIndex);

            // If there are file inputs
            if (mintUploaderCount > 0)
            {
                // Select the next/prev file
                Upload_SelectFile(objNextSibling ? objNextSibling : objPreviousSibling);
            }
        }
    }
}
/// </method>

/// <method name="Upload_CloseWindow">
/// <summary>
/// 
/// </summary>
function Upload_CloseWindow()
{
    if (parent.Forms_CloseWindow)
    {

        parent.Forms_CloseWindow(mstrWindowGuid);
    }
    else
    {
        window.close();
    }
}
/// </method>

/// <method name="Upload_SWFDestroy">
/// <summary>
/// 
/// </summary>
function Upload_SWFDestroy()
{
    // If SWFUploader used, and IE browser, call destroy() to prevent js errors.
    if (mobjSWFUpload && mobjApp.mcntIsIE)
    {
        mobjSWFUpload.destroy();
    }
}
/// </method>


/// </method>

/// <method name="$">
/// <summary>
/// 
/// </summary>
/// <param name="strId..."></param>
function $$()
{
    if (arguments.length == 1)
    {
        return document.getElementById(arguments[0]);
    }
    else if (arguments.length > 1)
    {
        var arrElements = [];
        for (var intIndex = 0; intIndex < arguments.length; intIndex++)
        {
            arrElements.push(document.getElementById(arguments[intIndex]));
        }
        return arrElements;
    }
    else
    {
        return null;
    }
}
/// </method>

/// <method name="Upload_DisplayError">
/// <summary>
/// 
/// </summary>
function Upload_DisplayError(strError)
{
    // Hide the progress panel.
    mobjApp.OpenFileDialog_ShowHideProgress(Upload_GetGatewayId(), false);

    // Shows error message.
    mobjApp.Web_SetInnerText($$("UploadMessageText"), strError);
    $$("UploadMessage").style.display = "block";
}
/// </method>

/// <method name="Upload_UploadProgress">
/// <summary>
/// 
/// </summary>
function Upload_UploadProgress(file, bytesloaded, bytestotal)
{
    var percent = Math.ceil((bytesloaded / bytestotal) * 100);

    // Some chrome bug show percent>100
    if (percent > 100)
    {
        percent = 100;
    }

    var mintTotalBytesLoaded = mintSumBytesOfUploadedFiles + bytesloaded;
    var totalPercent = Math.ceil((mintTotalBytesLoaded / mintTotalBytes) * 100);

    // Some chrome bug show totalPercent>100
    if (totalPercent > 100)
    {
        totalPercent = 100;
    }

    mobjApp.OpenFileDialog_UpdateProgress(Upload_GetGatewayId(), percent, totalPercent);
}
/// </method>

/// <method name="Upload_Success">
/// <summary>
/// 
/// </summary>
function Upload_Success(objFile, objServerData, objResponse)
{
}
/// </method>

/// <method name="Upload_QueueCompleted">
/// <summary>
/// 
/// </summary>
function Upload_QueueCompleted()
{
}
/// </method>

/// <method name="Upload_UploadNextFile">
/// <summary>
/// 
/// </summary>
function Upload_UploadNextFile()
{
    if (mobjFiles && mobjFiles.length > 0)
    {
        // Define an empty file.
        var objFile = null;

        // Loops for the first file which is not null.
        while (mobjFiles.length > 0 && (objFile = mobjFiles.pop()) == null) { }

        // Validate file.
        if (objFile)
        {
            //Determine the size of the file 
            if (objFile.size > 0)
            {
                // Start flash upload.
                mobjSWFUpload.startUpload(objFile.id);

                // Sum file size.
                mintTotalBytes += objFile.size;
            }
            else
            {
                // Cancel file uplaod.
                Upload_CancelFile(objFile.id);
            }
        }
    }
}
/// </method>

/// <method name="Upload_FileCompleted">
/// <summary>
/// 
/// </summary>
function Upload_FileCompleted(file)
{
    // Sum current file size.
    mintSumBytesOfUploadedFiles += file.size;

    // In case that last file completed uploading - close window.
    if (mobjFiles.length == 0)
    {
        if (mstrSWFUploadError == "")
        {
            Upload_CloseWindow();
        }
        else
        {
            Upload_DisplayError(mstrSWFUploadError);
        }
    }
    else
    {
        // Start upload next file.
        Upload_UploadNextFile();
    }
}
/// </method>

/// <method name="Upload_CancelFile">
/// <summary>
/// 
/// </summary>
function Upload_CancelFile(strFileId)
{
    // Validate file id and local swf uploader.
    if (strFileId && strFileId != "" && mobjSWFUpload)
    {
        // Removes file from local array.
        Upload_RemoveFileById(strFileId);

        // Remove the file from the queue so it wont be uploaded.
        mobjSWFUpload.cancelUpload(strFileId);
    }
}
/// </method>

/// <method name="Upload_Debug">
/// <summary>
/// 
/// </summary>
function Upload_Debug(strMessage)
{
}
/// </method>

/// <method name="Upload_Error">
/// <summary>
/// 
/// </summary>
function Upload_Error(file, errcode, msg)
{
    var strSWFUploadError = "";
    
	switch(errcode) {
		
		case -10:	// HTTP error
            strSWFUploadError = "HTTP Error, File name: " + file.name + ", Message: " + msg;
            break;

        case -20:	// No upload script specified
            strSWFUploadError = "No upload script, File name: " + file.name + ", Message: " + msg;
            break;

        case -30:	// IOError
            strSWFUploadError = "IO Error, File name: " + file.name + ", Message: " + msg;
            break;

        case -40:	// Security error
            strSWFUploadError = "Security Error, File name: " + file.name + ", Message: " + msg;
            break;

        case -50:	// Filesize too big
            strSWFUploadError = "Size of file '" + file.name + "' (" + file.size + " bytes) exceeds allowed limit (" + HtmlBox_GetAttribute("MaxFileSize", 4096) + " kilobytes)";
            break;

    }

    // Check if valid error message.
    if (strSWFUploadError != "")
    {
        // Add a new line character - if needed
        if (mstrSWFUploadError != "")
        {
            mstrSWFUploadError += "\n";
        }

        // Add current error message.
        mstrSWFUploadError += strSWFUploadError;
    }
}
/// </method>

/// <method name="Upload_FileStart">
/// <summary>
/// 
/// </summary>
function Upload_FileStart(file)
{
    mobjApp.OpenFileDialog_SetUploadMessage(Upload_GetGatewayId(), "Uploading file: " + file.name);
}
/// </method>

/// <method name="Upload_DialogComplete">
/// <summary>
/// 
/// </summary>
function Upload_DialogComplete(intSelectedFiles, intQueuedFiles, intTotalFiles)
{
}
/// </method>

/// <method name="Upload_QueueError">
/// <summary>
/// 
/// </summary>
function Upload_QueueError(objFile, objErrorCode, strMessage)
{
    switch (objErrorCode)
    {
        case -110:	// File size exceeds allowed limit.
        case -120:	// File is zero bytes and cannot be uploaded.
            alert(strMessage);
            break;
    }
}
/// </method>

/// <method name="Upload_FileQueued">
/// <summary>
/// 
/// </summary>
function Upload_FileQueued(objFile)
{
    // If single file upload mode
    if (!mblnMultiselect)
    {
        // Disable "Add" button
        Upload_DisableUploadButton(true);
    }

    var objUploadRow = Upload_CreateRecord(objFile.id, objFile.name, objFile.name);

    // Select the created row
    Upload_SelectFile(objUploadRow);

    // Push file int oarray.
    mobjFiles.push(objFile);

    // Increase total number of files.
    mintTotalFiles++;
}
/// </method>

/// <method name="Upload_CreateRecord">
/// <summary>
/// 
/// </summary>
function Upload_CreateRecord(strId, strText, strTooltip)
{
    // Create row
    var objUploadRow = document.createElement("TR");

    // Create cell
    var objUploadRowCell = document.createElement("TD");

    // Add cell
    objUploadRow.appendChild(objUploadRowCell);

    // Set cell style
    objUploadRowCell.className = "Common-WaitCursor";

    // Create text node
    var objUploadRowText = document.createElement("SPAN");
    objUploadRowText.className = "nobr";

    // Add text node
    objUploadRowCell.appendChild(objUploadRowText);

    // Set the list item text
    objUploadRowText.innerHTML = strText;
    objUploadRow.title = strTooltip;
    objUploadRowCell.id = "Cell_" + strId;
    objUploadRow.FileID = strId;

    // Wireup click event
    mobjApp.Web_AttachEvent(objUploadRow, "click", Upload_RowClick);

    // Add current row
    $$("UploadList").tBodies[0].appendChild(objUploadRow);

    // Return row
    return objUploadRow;
}
/// </method>

/// <method name="Upload_RemoveFile">
/// <summary>
/// Removes the current selected file in the list
/// </summary>
function Upload_RemoveFile()
{
    if (mblnUseFlash && mobjSWFUpload)
    {
        if (mobjSelectedFileRow)
        {
            // Cancel file's upload.
            Upload_CancelFile(mobjSelectedFileRow.FileID);

            // Delete file from list.
            $$("UploadList").deleteRow(mobjSelectedFileRow.rowIndex);

            // Clean selected file row.
            mobjSelectedFileRow = null;

            // Updating selected files counter
            mintTotalFiles--;

            // If single file upload mode
            if (!mblnMultiselect)
            {
                // Enable "Add" button
                Upload_DisableUploadButton(false);
            }
        }
    }
    else
    {
        Upload_RemoveFormFile();
    }
}
/// </method>

/// <method name="Upload_CreateSWFUpload">
/// <summary>
/// 
/// </summary>
function Upload_CreateSWFUpload(
                                arg_flash_url,
                                arg_upload_url,
                                arg_post_params,
                                arg_file_size_limit,
                                arg_file_types,
                                arg_file_types_description,
                                arg_file_upload_limit,
                                arg_file_queue_limit,
                                arg_custom_settings_progressTarget,
                                arg_custom_settings_cancelButtonId,
                                arg_debug,
                                arg_multiselect,
                                arg_button_image_url,
                                arg_button_width,
                                arg_button_height,
                                arg_button_placeholder_id,
                                arg_button_text,
                                arg_button_text_style,
                                arg_button_text_left_padding,
                                arg_button_text_top_padding,
                                arg_file_queued_handler,
                                arg_file_queue_error_handler,
                                arg_file_dialog_complete_handler,
                                arg_upload_start_handler,
                                arg_upload_progress_handler,
                                arg_upload_error_handler,
                                arg_upload_success_handler,
                                arg_upload_complete_handler,
                                arg_queue_complete_handler,
                                arg_debug_handler
                               )
{
    var objSettings =
    {
        flash_url: arg_flash_url,
        upload_url: arg_upload_url,
        post_params: arg_post_params,
        file_size_limit: arg_file_size_limit,
        file_types: arg_file_types,
        file_types_description: arg_file_types_description,
        file_upload_limit: arg_file_upload_limit,
        file_queue_limit: arg_file_queue_limit,

        // Custom settings	    
        custom_settings:
	    {
	        progressTarget: arg_custom_settings_progressTarget,
	        cancelButtonId: arg_custom_settings_cancelButtonId
	    },

        // Debug switch.    
        debug: arg_debug,

        // Button settings
        button_image_url: arg_button_image_url,
        button_width: arg_button_width,
        button_height: arg_button_height,
        button_placeholder_id: arg_button_placeholder_id,
        button_text: arg_button_text,
        button_text_style: arg_button_text_style,
        button_text_left_padding: arg_button_text_left_padding,
        button_text_top_padding: arg_button_text_top_padding,
        button_action: (arg_multiselect ? SWFUpload.BUTTON_ACTION.SELECT_FILES : SWFUpload.BUTTON_ACTION.SELECT_FILE),
        button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,

        // The event handler functions are defined in handlers.js
        file_queued_handler: arg_file_queued_handler,
        file_queue_error_handler: arg_file_queue_error_handler,
        file_dialog_complete_handler: arg_file_dialog_complete_handler,
        upload_start_handler: arg_upload_start_handler,
        upload_progress_handler: arg_upload_progress_handler,
        upload_error_handler: arg_upload_error_handler,
        upload_success_handler: arg_upload_success_handler,
        upload_complete_handler: arg_upload_complete_handler,
        queue_complete_handler: arg_queue_complete_handler,
        debug_handler: arg_debug_handler
    };

    return new SWFUpload(objSettings);
}
/// </method>

/// <method name="Upload_RemoveFileById">
/// <summary>
/// 
/// </summary>
function Upload_RemoveFileById(strFileId)
{
    // Validate recieved arguments.
    if (strFileId && strFileId != "" &&
        mobjFiles && mobjFiles.length > 0)
    {
        // Define a new files array.
        var arrFiles = [];

        // Loop all files in current array.
        for (var i = 0; i < mobjFiles.length; i++)
        {
            // Check if current file does not have the requested id.
            if (mobjFiles[i].id != strFileId)
            {
                // Push current file into new array.
                arrFiles.push(mobjFiles[i]);
            }
        }

        mobjFiles = arrFiles;
    }
}
/// </method>

/// <method name="Upload_RowClick">
/// <summary>
/// 
/// </summary>
function Upload_RowClick(objEvent)
{
    if (objEvent)
    {
        // Get event source.
        var objSource = mobjApp.Web_GetEventSource(objEvent);
        if (objSource)
        {
            // Loop to TR element.
            while (objSource && objSource.tagName.toLowerCase() != "tr")
            {
                objSource = objSource.parentNode;
            }

            // Select source TR.
            if (objSource)
            {
                Upload_SelectFile(objSource);
            }
        }
    }
}
/// </method>

/// <method name="Upload_GetUploadScript">
/// <summary>
/// 
/// </summary>		
function Upload_GetUploadScript()
{
    if (mblnUseFlash)
    {
        return mobjApp.Web_GetGatewayUrl(true, mobjApp.mstrBasePage, mobjApp.mstrPageInstance, Upload_GetGatewayId(), "UploadFlash", "SessionId=" + escape(HtmlBox_GetAttribute("SessionId")));
    }
    else
    {
        return mobjApp.Web_GetGatewayUrl(false, mobjApp.mstrBasePage, mobjApp.mstrPageInstance, Upload_GetGatewayId(), "Upload");
    }
}
/// </method>

/// <method name="Web_SetRowVisibility">
/// <summary>
/// Sets the visibility of a table row
/// </summary>
/// <param name="objRow">The table row element.</param>
/// <param name="blnVisible">A flag indicating if row should be visible.</param>
function Web_SetRowVisibility(objRow, blnVisible)
{
    objRow.style.display = blnVisible ? "table-row" : "none";
}
/// </method>

/// <method name="Upload_InitActions">
/// <summary>
/// Initialize the actions container.
/// </summary>
function Upload_InitActions()
{
    // Hide the standardactions container. 
    $$("StandardUploadingActions").style.display = (mblnUseFlash ? "" : "none");

    // Show the classic actions container.
    $$("ClassicUploadingActions").style.display = (mblnUseFlash ? "none" : "");
}
/// </method>

/// <method name="Upload_BrowseFile">
/// <summary>
/// Browse for a file or create a new file input.
/// </summary>
function Upload_BrowseFile()
{
    // Check the use flash indicator.
    // Get the upload file template.
    var objUploadFileTemplate = $$("ClassicUploadFileTemplate");

    // Get the upload file list.
    var objUploadFileList = $$("ClassicUploadFileList");

    // Validate elements.
    if (objUploadFileTemplate && objUploadFileList)
    {
        // Create a new upload file div element.
        var objNewUploadFile = document.createElement("DIV");

        if (objNewUploadFile)
        {
            // Set the new upload file inner html.
            mobjApp.Web_SetInnerHtml(objNewUploadFile, objUploadFileTemplate.innerHTML);

            // Set the new upload file style.
            objNewUploadFile.style.height = "23px";
            objNewUploadFile.style.width = "100%";
            objNewUploadFile.style.position = "relative";
            objNewUploadFile.style.overflow = "hidden";

            // Set the new upload file id.
            objNewUploadFile.childNodes[0].id = "File" + objUploadFileList.childNodes.length;
            objNewUploadFile.childNodes[0].name = "File" + objUploadFileList.childNodes.length;

            // Append the new upload file to the upload file list.
            objUploadFileList.appendChild(objNewUploadFile);

            // Disable the upload button in case of single select.
            if (HtmlBox_GetAttribute("Multiselect", "1") != "1")
            {
                $$("ClassicUploadButton").disabled = true;
            }

            // Updates selected files counter
            mintTotalFiles++;
        }
    }
}
/// </method>

/// <method name="Upload_RemoveClassicFile">
/// <summary>
/// Removes an upload file DIV.
/// </summary>
function Upload_RemoveClassicFile(objUploadFile)
{
    // Validate the received upload file element.
    if (objUploadFile)
    {
        // Get the upload file list.
        var objUploadFileList = $$("ClassicUploadFileList");

        if (objUploadFileList)
        {
            // Remove the received upload file element from the upload file list.
            objUploadFileList.removeChild(objUploadFile);

            // Enable the upload button in case of single select.
            if (HtmlBox_GetAttribute("Multiselect", "1") != "1")
            {
                $$("ClassicUploadButton").disabled = false;
            }

            // Updates selected files counter
            mintTotalFiles--;
        }
    }
}

/// <method name="Upload_GetThemePrefix">
/// <summary>
///
/// </summary>
/// <param name="strGuid">Component guid.</param>Upload_GetThemePrefix
function Upload_GetThemePrefix()
{
    var strDataID = HtmlBox_GetAttribute("Attr.Id");
    if (!mobjApp.Aux_IsNullOrEmpty(strDataID))
    {
        var strTheme = mobjApp.Controls_GetTheme(strDataID);
        if (!mobjApp.Aux_IsNullOrEmpty(strTheme))
        {
            strTheme += " ";
        }

        return strTheme;
    }

    return null;
}
/// </method>