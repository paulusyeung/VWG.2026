/// <method name="AspControlBoxBase_UpdateAspControl">
/// <summary>
///	Performs submit to the asp control.
/// </summary
function AspControlBoxBase_UpdateAspControl(strDataId) {
    var objControlElement = Web_GetElementByDataId(strDataId, window);
    var objIFrameElement = $(objControlElement).find("iframe");
    var objFormElement = $(objIFrameElement[0].contentWindow.document.documentElement).find("form");
    objFormElement.submit();
}