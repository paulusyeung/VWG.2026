function AddItemToList(itemName)
{
    if(!mobjApp.Aux_IsNullOrEmpty(mstrWindowGuid))
    {
        var objEvent = mobjApp.Events_CreateEvent(mstrWindowGuid, 'AddListBoxItem', null, true);
        Events_SetEventAttribute(objEvent, "ItemName", itemName);
        mobjApp.Events_RaiseEvents();
    }
}