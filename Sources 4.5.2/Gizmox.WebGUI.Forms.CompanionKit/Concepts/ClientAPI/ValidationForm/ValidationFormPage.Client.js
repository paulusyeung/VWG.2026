/// <method name="validateInputData" access="private">
/// <summary>
/// Validating input data and raising event on server
/// </summary>
function validateInputData() {
    //Get controls objects 
    var objEmailTextBox = vwgContext.provider.getComponentByClientId("email");
    var objPasswordTextBox = vwgContext.provider.getComponentByClientId("password");
    var objLoginForm = vwgContext.provider.getComponentByClientId("form");

    //Get input data from textBoxes
    var strEmail = objEmailTextBox.text();
    var strPassword = objPasswordTextBox.text();

    //Validate
    if (strEmail && strEmail != '' && strPassword && strPassword != '' && /\S+@\S+\.\S+/.test(strEmail)) {

        //Create event
        var objValidationEvent = vwgContext.events.createEvent(objLoginForm.id(), "validation");

        //Set event attributes
        vwgContext.events.setEventAttribute(objValidationEvent, "email", strEmail);
        vwgContext.events.setEventAttribute(objValidationEvent, "password", strPassword);

        //Set green textboxes indication
        objEmailTextBox.backColor("Green");
        objPasswordTextBox.backColor("Green");

        //Raise event to server
        vwgContext.events.raiseEvents();
    }
    else {
        //Set red textboxes indication
        objEmailTextBox.backColor("Red");
        objPasswordTextBox.backColor("Red");
       
        //Show message
        alert("Please type correct input data!!!");
    }
    //Update textboxes with according color
    objEmailTextBox.update();
    objPasswordTextBox.update();
}
/// </method>
