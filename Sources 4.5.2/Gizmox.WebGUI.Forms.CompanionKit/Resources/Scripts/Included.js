function registerScript(strScriptId, strScriptURL)
{
    if(strScriptId && strScriptURL)
    {
        var objScriptElement = document.createElement('script');

        objScriptElement.setAttribute('src', strScriptURL);
        objScriptElement.setAttribute('type', 'text/javascript');
        objScriptElement.id = strScriptId;

        document.getElementsByTagName('head')[0].appendChild(objScriptElement);
    }
}

function unRegisterScript(strScriptId)
{
    if(strScriptId)
    {
        var objScriptElement = document.getElementById(strScriptId);
        if(objScriptElement)
        {
            if(objScriptElement.parentNode)
            {
                objScriptElement.parentNode.removeChild(objScriptElement);
            }
        }
    }
}
