/// <method name="loadAddress">
/// <summary>
/// Loads address to HTMLBox from entered string
/// </summary>
function loadAddress() {
    //Get instances of controls
    var objTextBox = vwgContext.provider.getComponentByClientId("textBox");
    var objHTMLBox = vwgContext.provider.getComponentByClientId("htmlBox");
    //RegEx url pattern
    var strRegex = /^(https?\:\:?\/\/)?(www.)?[^.]+\.\w{2,8}/;
    //Get textBox's text
    var strSourceURL = objTextBox.text();
    //Verify on "http://" contents, add it if not contains
    strSourceURL = strSourceURL.indexOf("http://") == -1 ? "http://" + strSourceURL : strSourceURL;
    //Validates input string according to pattern
    if (strRegex.test(strSourceURL)) { 
        //If valid - set string as source
        objHTMLBox.source(strSourceURL);
        objHTMLBox.update();
    }
}
/// </method>