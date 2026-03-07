/// <method name="Silverlight_ErrorHandler">
/// <summary>
/// Default error handling function to be used when a custom error handler is
/// not present
/// </summary>
/// <param name="objSender">The error sender.</param>
/// <param name="objArgs">The error arguments.</param>
function Silverlight_ErrorHandler(objSender, objArgs) 
{
    var intErrorCode    = objArgs.ErrorCode;
    var strErrorType    = objArgs.ErrorType;
    var strErrorMessage = "\nSilverlight error message     \n" ;    
    strErrorMessage += "ErrorCode: "+ intErrorCode + "\n";
    strErrorMessage += "ErrorType: " + strErrorType + "       \n";
    strErrorMessage += "Message: " + objArgs.ErrorMessage + "     \n";
    switch(strErrorType)
    {   
        case "ParserError":
            strErrorMessage += "XamlFile: " + objArgs.xamlFile + "     \n";
            strErrorMessage += "Line: " + objArgs.lineNumber + "     \n";
            strErrorMessage += "Position: " + objArgs.charPosition + "     \n";
            break;
        case "RuntimeError":
            if (objArgs.lineNumber != 0)
            {
                strErrorMessage += "Line: " + objArgs.lineNumber + "     \n";
                strErrorMessage += "Position: " +  objArgs.charPosition + "     \n";
            }
            strErrorMessage += "MethodName: " + objArgs.methodName + "     \n";
            break;
    }    
    alert(strErrorMessage);
}
/// </method> 
