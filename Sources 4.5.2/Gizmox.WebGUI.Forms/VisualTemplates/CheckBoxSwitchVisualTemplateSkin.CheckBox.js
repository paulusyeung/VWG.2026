function CheckBoxSwitch_OnClick(objWindow, objEvent, objWrapper, strGuid)
{

    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGuid) && objWrapper)
    {
        var objSwitch = Web_GetElementById("CHK_SWC_" + strGuid, objWindow);
        var objStateLabel = Web_GetElementById("CHK_SLBL_" + strGuid, objWindow);

        // Validate elements.
        if (objSwitch && objStateLabel)
        {
            // Get data node
            var objNode = Data_GetNode(strGuid);
            {
                var intWidth = objWrapper.offsetWidth;
                var intHeight = objWrapper.offsetHeight;
                var intSwitchWidth = objSwitch.offsetWidth;

                // Get the current checked state
                var strOldCheckState = Xml_GetAttribute(objNode, "Attr.Checked", "0");

                // Calculate the new state mode
                var strNewCheckState;
                if (strOldCheckState == "0")
                {
                    strNewCheckState = "1";
                }
                else
                {
                    strNewCheckState = "0";
                }

                if (objWrapper.offsetWidth > objWrapper.offsetHeight)
                {
                    var blnUseAnimation = Web_IsAttribute(objSwitch, "UseAnimation", "True");

                    // Update switch left and state label margin with animation                    

                    if (strNewCheckState == "1")
                    {
                        if (blnUseAnimation)
                        {
                            $(objSwitch).animate(
                               { "left": (intWidth - intSwitchWidth).toString() + "px" },
                               {
                                   step: function (now, fx)
                                   {
                                       var intRange = Math.abs(fx.end - fx.start);
                                       var intPercentage = parseInt(100 * (Math.abs(now - fx.start) / intRange));
                                       objStateLabel.style.marginLeft = "-" + (100 - intPercentage).toString() + "%";
                                   }
                               });
                        }
                        else
                        {
                            objSwitch.style.left = (intWidth - intSwitchWidth).toString() + "px";
                            objStateLabel.style.marginLeft = "0";
                        }
                    }
                    else
                    {
                        if (blnUseAnimation)
                        {
                            $(objSwitch).animate(
                                { "left": 0 },
                                {
                                    step: function (now, fx)
                                    {
                                        var intRange = Math.abs(fx.end - fx.start);
                                        var intPercentage = parseInt(100 * (Math.abs(now - fx.start) / intRange));
                                        objStateLabel.style.marginLeft = "-" + intPercentage.toString() + "%";
                                    }
                                });
                        }
                        else
                        {
                            objSwitch.style.left = "0";
                            objStateLabel.style.marginLeft = "-100%";
                        }
                    }
                }
                else
                {
                    if (strNewCheckState == "1")
                    {
                        objStateLabel.style.marginLeft = "0";
                    }
                    else
                    {
                        objStateLabel.style.marginLeft = "-100%";
                    }
                }

                // Update data behind
                Data_SetNodeAttribute(objNode, "Attr.Checked", strNewCheckState);

                // Raise event
                CheckBox_ValueChange(strGuid, objNode, strNewCheckState, objWindow, objEvent);
            }
        }
    }
}

function CheckBoxSwitch_Init(strGuid, objWindow)
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGuid))
    {
        // Get data node
        var objNode = Data_GetNode(strGuid);
        {
            // Get the current checked state
            var strCheckState = Xml_GetAttribute(objNode, "Attr.Checked", "0");

            // Get state label element
            var objStateLabel = Web_GetElementById("CHK_SLBL_" + strGuid, objWindow);

            // Get switch element
            var objSwitch = Web_GetElementById("CHK_SWC_" + strGuid, objWindow);

            // Get wrapper element
            var objWrapper = Web_GetElementById("CHK_WRP_" + strGuid, objWindow);

            if (objStateLabel && objSwitch && objWrapper)
            {
                var strDiameter;

                var intMinHeightWidth = Math.min(objWrapper.offsetWidth, objWrapper.offsetHeight);

                strDiameter = intMinHeightWidth.toString() + "px";

                if (Web_IsAttribute(objSwitch, "RoundedSwitch", "True"))
                {
                    objWrapper.style.borderRadius = strDiameter;
                    objSwitch.style.borderRadius = strDiameter;
                }

                var strSwitchWidthPercentage = Web_GetAttribute(objSwitch, "SwitchWidthPercentage");

                if (strSwitchWidthPercentage != "0")
                {
                    objSwitch.style.width = strSwitchWidthPercentage + "%";
                }
                else
                {
                    objSwitch.style.width = strDiameter;
                }

                if (objWrapper.offsetWidth <= objWrapper.offsetHeight)
                {
                    objSwitch.style.left = 0;
                }
                else if (strCheckState != "0")
                {
                    objSwitch.style.left = (objWrapper.offsetWidth - objSwitch.offsetWidth).toString() + "px";
                }

                objStateLabel.style.lineHeight = objStateLabel.clientHeight.toString() + "px";
            }
        }
    }
}