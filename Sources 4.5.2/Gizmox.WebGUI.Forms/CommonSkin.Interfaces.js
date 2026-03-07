

// Create VWG namespaces
window.VWG = {Events:{},Services:{}};


/// <method name="Services_GetApplication">
/// <summary>
/// Creates a new application server event.
/// </summary>
VWG.Services.GetApplication = function()
{
    if(!VWG.Services.Application)
    {
        try
        {
            // Get curret window parent
            var objWindow = window.parent;
            
            // The iterator counter to protect from halting in traversing
            var intWindow = 0;
            
            // If valid window
            while(objWindow!=null && !objWindow.mobjApp)
            {
                // Get window parent
                objWindow = objWindow.parent;
                
                // Increament window index and test if exit is needed
                intWindow++;
                if(intWindow>20) 
                {
                    objWindow = null;
                    break;
                }

            }
            
            if(objWindow!=null)
            {
                VWG.Services.Application = objWindow.mobjApp;
            }
            
        }
        catch(e)
        {
        }
    }
    return VWG.Services.Application;
};
/// </method>

/// <method name="Events_CreateEvent">
/// <summary>
/// Creates a new application server event.
/// </summary>
/// <param name="strSource">The ID of the event source.</param>
/// <param name="strType">The type of the event to be created.</param>
/// <param name="strTarget">The target ID.</param>
/// <param name="blnUnique">Indicates whether an event should be unique</param>
/// <param name="blnTypeOnlyUnique">Indicates whether an event should be unique by type only</param>
VWG.Events.CreateEvent = function(strSource,strType,strTarget,blnUnique,blnTypeOnlyUnique)
{
    var objApp = VWG.Services.GetApplication();
    if(objApp)
    {
        return objApp.Events_CreateEvent(strSource,strType,strTarget,blnUnique,blnTypeOnlyUnique);
    }    
};
/// </method>

/// <method name="Events_SetEventAttribute">
/// <summary>
/// Sets an event object attribute.
/// </summary>
/// <param name="objEvent">The event object to set attribute.</param>
/// <param name="strName">The attribute name.</param>
/// <param name="strValue">The attribute value.</param>
/// <param name="blnIsElement">Indicated an attribute/element mode.</param>
VWG.Events.SetEventAttribute = function(objEvent,strName,strValue,blnIsElement)
{
    var objApp = VWG.Services.GetApplication();
    if(objApp)
    {
        return objApp.Events_SetEventAttribute(objEvent,strName,strValue,blnIsElement);
    }
};
/// </method>

/// <method name="Events_RaiseEvents">
/// <summary>
/// Sends the event buffer to the application server.
/// </summary>
/// <param name="objCallbackDelegate">An Aux_CallbackDelegate which will be called at the end of the events processing.</param>
/// <param name="blnTerminate">The boolean indicating if appliclication should be terminated.</param>
VWG.Events.RaiseEvents = function(objCallbackDelegate)
{
    var objApp = VWG.Services.GetApplication();
    if(objApp)
    {
        return objApp.Events_RaiseEvents(objCallbackDelegate);
    }
};
/// </method>
