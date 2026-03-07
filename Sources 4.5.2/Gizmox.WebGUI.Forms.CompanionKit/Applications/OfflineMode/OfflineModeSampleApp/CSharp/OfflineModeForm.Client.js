/// <method name="offlineConfirming" access="private">
/// <summary>
/// Switch form to offline mode
/// </summary>
function offlineConfirming() {
        // Get responce object (xmlHttp)
        var mobjXmlHttp = vwgContext.events.eventArgs().xmlHttp;
        var mintStatus = mobjXmlHttp.status;

        // If status is not OK
        if (mintStatus != 200) {
            // Switch to offline mode
            vwgContext.events.eventArgs().offlineConfirm = true;
        }
}
/// </method>

/// <method name="offlineInitializing" access="private">
/// <summary>
/// Establish timeout for reconnect
/// </summary>
function offlineInitializing() {
    //switch app's appearance
    switchAppearance(false);
    //write to log
    var mobjXmlHttp = vwgContext.events.eventArgs().xmlHttp;
    var mintStatus = mobjXmlHttp.status;

    var mstrMessage = "Switched to offline mode - Status code: " + mintStatus + ", status text: " + mobjXmlHttp.statusText;
    writeLineToLog(mstrMessage);
    //call reconnect on timeout
    setTimeout(function () { reconnect(window.location.href); }, 15000);
}
/// </method>

/// <method name="reconnect" access="private">
/// <summary>
/// Perform an asynchronous HTTP request.
/// </summary>
function reconnect(syncURL) {
    $.ajax({
        type: "POST",
        url: syncURL,
        dataType: "html",
        success: function (strHtml, strMessage, objXmlHttp) {
            switchToOnline();
        }, error: function () {
            setTimeout(function () { reconnect(window.location.href); }, 15000);
        }
    });
}
/// </method>

/// <method name="switchToOnline" access="private">
/// <summary>
/// Switch form to online mode
/// </summary>
function switchToOnline() {
    // If the user has allowed -- switch to online mode
    if (confirm("Go back online?")) {
        writeLineToLog("Switched to online mode");
        window.location.reload();
    }
}
/// </method>

/// <method name="switchAppearance" access="private">
/// <summary>
/// Switch form's appearance to appropriate state
/// </summary>
function switchAppearance(blnIsOnline) {
    var mobjPictureBox = vwgContext.provider.getComponentByClientId("pictureBox");
    var mobjStatusLabel = vwgContext.provider.getComponentByClientId("statusStripLabel");
    var strState = blnIsOnline == true ? "Online" : "Offline"; // == true is redundant
    var strColor = blnIsOnline == true ? "Green" : "Red";
    mobjPictureBox.imageUrl("Images." + strState + ".png.wgx");
    mobjStatusLabel.parent().backColor(strColor);
    mobjStatusLabel.text(strState);
    mobjPictureBox.update();
    mobjStatusLabel.parent().update();
    mobjStatusLabel.update();
}
/// </method>

/// <method name="writeLineToLog" access="private">
/// <summary>
/// Append message string to Log (TextBox control)
/// </summary>
function writeLineToLog(strMessage) {
    var mobjTextBox = vwgContext.provider.getComponentByClientId("textBox");
    var mstrResult = !mobjTextBox.text() ? "" : mobjTextBox.text();
    var mobjDate = new Date();
    mstrResult += mobjDate.toUTCString() + ": " + strMessage + "\n";
    mobjTextBox.text(mstrResult);
    mobjTextBox.update();
}
/// </method>