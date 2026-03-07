var mstrOldColor            =   null;
var mstrCurrentColor        =   null;
var mstrPredefiniedColors   =   null;
var marrPredefiniedColors   =   null;
var mobjCursorImage         =   null;
var mobjBlankImage          =   null;
var mintCursorPosition      =   1;
var mstrHexChars            =   "0123456789ABCDEF";
var marrCurrentRGB          =   null;
var marrCurrentHSL          =   null;
var mstrControlId		    =   "";
var mstrControlHtml		    =   "";
var mblnCustomColorsIsDirty =   false;

/// <method name="$">
/// <summary>
/// Get a document element by ID
/// </summary>
function $$(strId)
{
    return document.getElementById(strId);
}
/// </method>


/// <method name="ColorDialog_Init">
/// <summary>
/// Initialize the color control
/// </summary>
function ColorDialog_Init()
{
    mstrOldColor        =   HtmlBox_GetAttribute("Attr.Value","00C000");
    
    //Check the full open property
    var blnOpenFull        =   HtmlBox_GetAttribute("OpenFull","0")=="1";
    
    mstrCurrentColor    =   mstrOldColor;
    mstrPredefiniedColors = ColorDialog_GetValue("predefcolors");
    if (!mstrPredefiniedColors) 
    {
            mstrPredefiniedColors="FFFFFF,FFFFFF,FFFFFF,FFFFFF,FFFFFF,FFFFFF,FFFFFF,FFFFFF,"+
				"FFFFFF,FFFFFF,FFFFFF,FFFFFF,FFFFFF,FFFFFF,FFFFFF,FFFFFF";
	}
    marrPredefiniedColors   =   mstrPredefiniedColors.split(",",16);
    mobjCursorImage         =   new Image ();
    mobjCursorImage.src="[Skin.Path]ColorDialogCross.gif.swgx";
    mobjBlankImage=new Image ();
    mobjBlankImage.src="[Skin.CommonPath]Empty.gif.swgx";
    
    marrCurrentRGB=[ColorDialog_GetIntFromHEX(mstrCurrentColor.substr(0,2)),ColorDialog_GetIntFromHEX(mstrCurrentColor.substr(2,2)),ColorDialog_GetIntFromHEX(mstrCurrentColor.substr(4,2))];
    marrCurrentHSL=ColorDialog_GetHSLFromRGB(marrCurrentRGB[0],marrCurrentRGB[1],marrCurrentRGB[2]);

    ColorDialog_UpdatePredefiniedColors();
    ColorDialog_SetCursor(mintCursorPosition);
    ColorDialog_SetColor(mstrCurrentColor);
    
    // Get the control id
    mstrControlId = mobjApp.Web_GetQueryStringParam(document.location.href,"id");
	
	// Get the control html
	mstrControlHtml = document.body.innerHTML;
    
    mobjApp.Events_AttachOnSubmit(mstrControlId,ColorDialog_OnSubmit);
    HtmlBox_SetExecuter(ColorDialog_Executer);
    
    if(blnOpenFull)
    {
        //Opens the Dialog in expanded mode(with the custom colors)
        ColorDialog_ShowCustomColors();
    }

    mobjApp.Common_ApplyAccessibilityFeatures(document.body);
}
/// </method>

function ColorDialog_Executer(action)
{
    switch (action)
    {
        case "EditCustomColors":
            ColorDialog_ShowCustomColors();
            break;
        case "AddColorToCustomColors":
            ColorDialog_DefinePredefiniedColor();
            break;
        
    }
}

/// <method name="ColorDialog_OnSubmit">
/// <summary>
/// </summary>
function ColorDialog_OnSubmit()
{
    ColorDialog_Save();
}
/// </method>

/// <method name="ShowCustomColors">
/// <summary>
/// </summary>
function ColorDialog_ShowCustomColors()
{

    $$("tdSeperator").style.display = "";
    $$("tdCustomColors").style.display = "";
    $$("VWG_SLIDEARROW").style.display = "";
    $$("VWG_CROSS").style.display = "";
    ColorDialog_Update();
}
/// </method>

function ColorDialog_Save()
{
    var objValueChangeEvent = null;

    if (mblnCustomColorsIsDirty)
    {
        objValueChangeEvent = HtmlBox_CreateEvent("ValueChange",null,true);
        mobjApp.Events_SetEventAttribute(objValueChangeEvent,"Attr.CustomColors",marrPredefiniedColors.toString());
    }
    
    if (mstrCurrentColor != mstrOldColor)
    {
        if (!objValueChangeEvent)
        {
            objValueChangeEvent = HtmlBox_CreateEvent("ValueChange",null,true);
        }

        mobjApp.Events_SetEventAttribute(objValueChangeEvent,"Attr.Color",mstrCurrentColor);
    }
}

/// <method name="ColorDialog_StoreValue">
/// <summary>
/// Store a signle value
/// </summary>
/// <param name="strName"></param>
/// <param name="strValue"></param>
function ColorDialog_StoreValue(strName, strValue)
{
   // Add store value
}
/// </method>


/// <method name="ColorDialog_GetValue">
/// <summary>
/// Gets a stored value
/// </summary>
/// <param name="strName"></param>
function ColorDialog_GetValue(strName) 
{
    switch(strName)
    {
        case "predefcolors":
            return HtmlBox_GetAttribute("Attr.CustomColors");
            break;
        default:
            return null;
    }
   // Add get value
}
/// </method>

/// <method name="ColorDialog_GetIntFromHEX">
/// <summary>
/// 
/// </summary>
/// <param name="strValue"></param>
function ColorDialog_GetIntFromHEX(strValue) 
{
	var intResult=0;
	for (intIndex=strValue.length-1;intIndex>=0;intIndex--) 
	{
		intResult += Math.pow(16,strValue.length-intIndex-1) * mstrHexChars.indexOf(strValue.charAt(intIndex));	
	}
	return intResult;
}
/// </method>

/// <method name="ColorDialog_GetHEXFromInt">
/// <summary>
/// 
/// </summary>
/// <param name="intValue"></param>
function ColorDialog_GetHEXFromInt(intValue) 
{
	var intResult = mstrHexChars.charAt(intValue/16);
	intResult += mstrHexChars.charAt(intValue%16);
	return intResult;
}
/// </method>

/// <method name="ColorDialog_UpdatePredefiniedColors">
/// <summary>
/// 
/// </summary>
function ColorDialog_UpdatePredefiniedColors() 
{
	for (intIndex=1;intIndex<=16;intIndex++) 
	{
		$$("VWG_PRECELL"+intIndex).bgColor=marrPredefiniedColors[intIndex-1];
	}
}
/// </method>

/// <method name="ColorDialog_DefinePredefiniedColor">
/// <summary>
/// 
/// </summary>
function ColorDialog_DefinePredefiniedColor() 
{
	marrPredefiniedColors[mintCursorPosition-1]=mstrCurrentColor;
	mblnCustomColorsIsDirty = true;
	ColorDialog_UpdatePredefiniedColors();
	ColorDialog_SetCursor(mintCursorPosition+1>16?1:mintCursorPosition+1);
}
/// </method>

/// <method name="ColorDialog_Preset">
/// <summary>
/// 
/// </summary>
/// <param name="intValue"></param>
function ColorDialog_Preset(intValue) 
{
	ColorDialog_SetColor(marrPredefiniedColors[intValue-1]);
	ColorDialog_SetCursor(intValue);
	mblnCustomColorsIsDirty = true;
}
/// </method>

/// <method name="ColorDialog_SetCursor">
/// <summary>
/// 
/// </summary>
/// <param name="intValue"></param>
function ColorDialog_SetCursor(intValue) 
{
	$$("preimg"+mintCursorPosition).src=mobjBlankImage.src;
	mintCursorPosition=intValue;
	$$("preimg"+mintCursorPosition).src=mobjCursorImage.src;
}
/// </method>

/// <method name="ColorDialog_Update">
/// <summary>
/// 
/// </summary>
function ColorDialog_Update() 
{
	$$("VWG_CURRENTCOLOR").style.backgroundColor="#"+mstrCurrentColor;
	$$("VWG_RGB_r").value=marrCurrentRGB[0];
	$$("VWG_RGB_g").value=marrCurrentRGB[1];
	$$("VWG_RGB_b").value=marrCurrentRGB[2];
	$$("VWG_HTMLCOLOR").value=mstrCurrentColor;
	$$("VWG_HSL_h").value=marrCurrentHSL[0];
	$$("VWG_HSL_s").value=marrCurrentHSL[1];
	$$("VWG_HSL_l").value=marrCurrentHSL[2];
	ColorDialog_SetCursor(mintCursorPosition);
	
	// set the cross on the colorpic
	var objCrossStyle=$$("VWG_CROSS").style;
	var objColorPicture=$$("VWG_COLORSPIC");
	var intXd=0;
	var intYd=0;
	var intLr=objColorPicture;
	while(intLr!=null)
	{
	    intXd+=intLr.offsetLeft;
	    intYd+=intLr.offsetTop;
	    intLr=intLr.offsetParent;
	}
	
	objCrossStyle.top=(intYd-9+191-191*marrCurrentHSL[1]/255)+"px";
	objCrossStyle.left=(intXd-9+191*marrCurrentHSL[0]/255)+"px";
	// ColorDialog_Update slider pointer
	
	var objSlideArrowStyle=$$("VWG_SLIDEARROW").style;
	var objSlider=$$("VWG_SLIDER");
	
	intXd=0;
	intYd=0;
	intLr=objSlider;
	while(intLr!=null)
	{
	    intXd+=intLr.offsetLeft;
	    intYd+=intLr.offsetTop;
	    intLr=intLr.offsetParent;
	}
	objSlideArrowStyle.top=(intYd+187-191*marrCurrentHSL[2]/255)+"px";
	objSlideArrowStyle.left=(intXd+14)+"px"
	
	// ColorDialog_Update slider colors
	for (intIndex=0;intIndex<192;intIndex++)
	{
		var objRgb=ColorDialog_GetRGBFromHSL(marrCurrentHSL[0],marrCurrentHSL[1],255-255*intIndex/191);
		$$("VWG_SC"+(intIndex+1)).bgColor=ColorDialog_GetHEXFromInt(objRgb[0])+ColorDialog_GetHEXFromInt(objRgb[1])+ColorDialog_GetHEXFromInt(objRgb[2]);
	}
}
/// </method>

/// <method name="ColorDialog_GetRGBFromHSL">
/// <summary>
/// 
/// </summary>
/// <param name="intH"></param>
/// <param name="intS"></param>
/// <param name="intL"></param>
function ColorDialog_GetRGBFromHSL(intH,intS,intL) 
{
	if (intS == 0)
	    return [intL,intL,intL]; // achromatic
	intH=intH*360/255;
	intS/=255;
	intL/=255;
	if (intL <= 0.5)
	    intRm2 = intL + intL * intS;
	else
	    intRm2 = intL + intS - intL * intS;
	intRm1 = 2.0 * intL - intRm2;
	return [ColorDialog_ToRGB1(intRm1, intRm2, intH + 120.0),ColorDialog_ToRGB1(intRm1, intRm2, intH),ColorDialog_ToRGB1(intRm1, intRm2, intH - 120.0)];
}
/// </method>

/// <method name="ColorDialog_ToRGB1">
/// <summary>
/// 
/// </summary>
/// <param name="intRm1"></param>
/// <param name="intRm2"></param>
/// <param name="intRh"></param>
function ColorDialog_ToRGB1(intRm1,intRm2,intRh) 
{
	if      (intRh > 360.0) intRh -= 360.0;
	else if (intRh <   0.0) intRh += 360.0;
	if      (intRh <  60.0) intRm1 = intRm1 + (intRm2 - intRm1) * intRh / 60.0;
	else if (intRh < 180.0) intRm1 = intRm2;
	else if (intRh < 240.0) intRm1 = intRm1 + (intRm2 - intRm1) * (240.0 - intRh) / 60.0; 
	return Math.round(intRm1 * 255);
}
/// </method>

/// <method name="ColorDialog_GetHSLFromRGB">
/// <summary>
/// 
/// </summary>
/// <param name="intR"></param>
/// <param name="intG"></param>
/// <param name="intB"></param>
function ColorDialog_GetHSLFromRGB(intR,intG,intB) 
{
	intMin = Math.min(intR,Math.min(intG,intB));
	intMax = Math.max(intR,Math.max(intG,intB));
	// intL
	intL = Math.round((intMax+intMin)/2);
	// achromatic ?
	if(intMax==intMin) {intH=160;intS=0;}
	else {
	// intS
		if (intL<128) intS=Math.round(255*(intMax-intMin)/(intMax+intMin));
		else intS=Math.round(255*(intMax-intMin)/(510-intMax-intMin));
	// intH	
		if (intR==intMax)	intH=(intG-intB)/(intMax-intMin);
		else if (intG==intMax) intH=2+(intB-intR)/(intMax-intMin);
		else intH=4+(intR-intG)/(intMax-intMin);
		intH*=60;
		if (intH<0) intH+=360;
		intH=Math.round(intH*255/360);
	}
	return [intH,intS,intL];
}
/// </method>

/// <method name="ColorDialog_SetColor">
/// <summary>
/// 
/// </summary>
/// <param name="strValue"></param>
function ColorDialog_SetColor(strValue) 
{
	strValue = strValue.toUpperCase();
	if (strValue.length!=6) 
	{
	    strValue=mstrCurrentColor;
	}
	for (intIndex=0;intIndex<6;intIndex++)
    {
		if (mstrHexChars.indexOf(strValue.charAt(intIndex))==-1) 
		{
			strValue=mstrCurrentColor;
			break;
		}
	}
	mstrCurrentColor=strValue;
	marrCurrentRGB=[ColorDialog_GetIntFromHEX(mstrCurrentColor.substr(0,2)),ColorDialog_GetIntFromHEX(mstrCurrentColor.substr(2,2)),ColorDialog_GetIntFromHEX(mstrCurrentColor.substr(4,2))];
	marrCurrentHSL=ColorDialog_GetHSLFromRGB(marrCurrentRGB[0],marrCurrentRGB[1],marrCurrentRGB[2]);
	ColorDialog_Update();
}
/// </method>

/// <method name="ColorDialog_SetRGB">
/// <summary>
/// 
/// </summary>
/// <param name="intR"></param>
/// <param name="intG"></param>
/// <param name="intB"></param>
function ColorDialog_SetRGB(intR,intG,intB) 
{
	if (intR>255||intR<0||intG>255||intG<0||intB>255||intB<0)
	{
	    intR=marrCurrentRGB[0];
	    intG=marrCurrentRGB[1];
	    intB=marrCurrentRGB[2];
	}
	marrCurrentRGB=[intR,intG,intB];
	mstrCurrentColor=ColorDialog_GetHEXFromInt(intR)+ColorDialog_GetHEXFromInt(intG)+ColorDialog_GetHEXFromInt(intB);
	marrCurrentHSL=ColorDialog_GetHSLFromRGB(intR,intG,intB);
	ColorDialog_Update();
}
/// </method>

/// <method name="ColorDialog_SetHSL">
/// <summary>
/// 
/// </summary>
/// <param name="intH"></param>
/// <param name="intS"></param>
/// <param name="intL"></param>
function ColorDialog_SetHSL(intH,intS,intL) 
{
	if (intH>255||intH<0||intS>255||intS<0||intL>255||intL<0)
	{
	    intS=marrCurrentHSL[0];
	    intS=marrCurrentHSL[1];
	    intL=marrCurrentHSL[2];
	}
	marrCurrentHSL=[intH,intS,intL];
	marrCurrentRGB=ColorDialog_GetRGBFromHSL(intH,intS,intL);
	mstrCurrentColor=ColorDialog_GetHEXFromInt(marrCurrentRGB[0])+ColorDialog_GetHEXFromInt(marrCurrentRGB[1])+ColorDialog_GetHEXFromInt(marrCurrentRGB[2]);
	ColorDialog_Update();
}
/// </method>

/// <method name="ColorDialog_SetFromRGB">
/// <summary>
/// 
/// </summary>
function ColorDialog_SetFromRGB() 
{
	var intR = $$("VWG_RGB_r").value;
	var intG = $$("VWG_RGB_g").value;
	var intB = $$("VWG_RGB_b").value;
	ColorDialog_SetRGB(intR,intG,intB);
}
/// </method>

/// <method name="ColorDialog_SetFromHTML">
/// <summary>
/// 
/// </summary>
function ColorDialog_SetFromHTML() 
{
	strValue=$$("VWG_HTMLCOLOR").value.toUpperCase();
	if (strValue.length!=6)
	{
	    ColorDialog_SetColor(mstrCurrentColor);
	    return;
	}
	for (intIndex=0;intIndex<6;intIndex++)
	{
		if (mstrHexChars.indexOf(strValue.charAt(intIndex))==-1) 
		{
			ColorDialog_SetColor(mstrCurrentColor);
			return;
		}
	}
	ColorDialog_SetColor(strValue);
}
/// </method>

/// <method name="ColorDialog_SetFromHSL">
/// <summary>
/// 
/// </summary>
function ColorDialog_SetFromHSL() 
{
	var intH=$$("VWG_HSL_h").value;
	var intS=$$("VWG_HSL_s").value;
	var intL=$$("VWG_HSL_l").value;
	if (intH>255||intH<0||intS>255||intS<0||intL>255||intL<0)
	{
	    ColorDialog_SetHSL(marrCurrentHSL[0],marrCurrentHSL[1],marrCurrentHSL[2]);
	    return;
	}
	ColorDialog_SetHSL(intH,intS,intL);
}
/// </method>

/// <method name="ColorDialog_SetFromImage">
/// <summary>
/// 
/// </summary>
/// <param name="objEvent"></param>
function ColorDialog_SetFromImage(objEvent) 
{
	var intX=objEvent.offsetX;
	var intY=objEvent.offsetY;
	if (intX == undefined)
	{
		intXd=0;intYd=0;intLr=$$("VWG_COLORSPIC");
		while(intLr!=null)
		{
		    intXd+=intLr.offsetLeft;
		    intYd+=intLr.offsetTop;
		    intLr=intLr.offsetParent;
		}
		intX=objEvent.pageX-intXd;
		intY=objEvent.pageY-intYd;
	}

    // In case of mouse down event.	
	if(objEvent && objEvent.type=="mousedown")
	{
	    // Cancel bubble so drag won't occur.
	    mobjApp.Web_EventCancelBubble(objEvent,true,false);
	}

	ColorDialog_SetHSL(Math.round(intX*255/191),Math.round(255-intY*255/191),marrCurrentHSL[2]);
}
/// </method>

/// <method name="ColorDialog_SetFromSlider">
/// <summary>
/// 
/// </summary>
/// <param name="objEvent"></param>
function ColorDialog_SetFromSlider(objEvent) 
{
	var intYd=0;
	var intLr=$$("VWG_SLIDER");
	while(intLr!=null) {intYd+=intLr.offsetTop; intLr=intLr.offsetParent;}
	intY=objEvent.clientY-intYd;
	ColorDialog_SetHSL(marrCurrentHSL[0],marrCurrentHSL[1],Math.round(255-intY*255/191));
}

/// </method>
/// <method name="ColorDialog_OnKeyDown">
/// <summary>
/// Check the pressed key in the RGB and HSL text boxes and decide if to cancle the operation.
/// </summary>
function ColorDialog_OnKeyDown(objEvent)
{
    //Get the key code
    var intKeyCode = mobjApp.Web_GetEventKeyCode(objEvent);
    
    //When the key is: digit, navigation key,delete/backspace or tab
    //don't cancle the key down operation.
	if( !mobjApp.Aux_IsDigitKeyCode(intKeyCode,false) && !mobjApp.Web_IsNavigationKey(intKeyCode) 
	    && !ColorDialog_IsInputRequiredKey(intKeyCode))
	{
		// Prevent default.
        mobjApp.Web_EventCancelBubble(objEvent,true,false); 
    }
}
/// </method>

/// </method>
/// <method name="ColorDialog_IsInputRequiredKey">
/// <summary>
/// Check if the key is an input required key.
/// </summary>
function ColorDialog_IsInputRequiredKey(intKeyCode)
{
    return (intKeyCode==mobjApp.mcntDeleteKey || intKeyCode==mobjApp.mcntBackspaceKey || intKeyCode==mobjApp.mcntTabKey);
}
/// </method>