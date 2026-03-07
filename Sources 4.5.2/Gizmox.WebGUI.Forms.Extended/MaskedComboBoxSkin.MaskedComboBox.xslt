<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.ComboBox[@Attr.CustomStyle='M']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawComboBoxAPI">

      <!-- Params for using the ComboBox from other controls -->
      <xsl:with-param name="prmControlClass" select="'ComboBox-Control'" />
      <xsl:with-param name="prmContentClass" select="'ComboBox-Content'" />
      <xsl:with-param name="prmInputClass" select="'ComboBox-Input'" />
      <xsl:with-param name="prmInputContainerClass">
        <xsl:if test="@Attr.Style='S'">
          <xsl:value-of select="'ComboBox-InputContainer'"/>
        </xsl:if>
      </xsl:with-param>
      <xsl:with-param name="prmDataContainerDropDownMode" select="'ComboBox-DataContainerDropDownMode'" />
      <xsl:with-param name="prmDataContainerDropDownListMode" select="'ComboBox-DataContainerDropDownListMode'" />
      <xsl:with-param name="prmDataContainerSimpleMode" select="'ComboBox-DataContainerSimpleMode'" />
      <xsl:with-param name="prmItemsContainer" select="'ComboBox-ItemsContainer'" />
      <xsl:with-param name="prmInputHeight" select="[Skin.SimpleComboBoxInputHeight]" />
      <xsl:with-param name="prmButtonClass" select="'ComboBox-Button'" />
      <xsl:with-param name="prmButtonContainerClass" select="'ComboBox-ButtonContainer'" />
      <xsl:with-param name="prmButtonWidth" select="[Skin.DropDownImageWidth]" />
      <xsl:with-param name="prmItemClass" select="'ComboBox-Item'" />
      <xsl:with-param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Params for using the ComboBox popup window  -->
  <xsl:template match="Tags.Options[../@Attr.CustomStyle='M']" >
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawOptionsAPI" >
      <xsl:with-param name="prmLeftBottomClass" select="'ComboBox-BottomLeft'" />
      <xsl:with-param name="prmLeftClass" select="'ComboBox-Left'" />
      <xsl:with-param name="prmLeftTopClass" select="'ComboBox-TopLeft'" />
      <xsl:with-param name="prmTopClass" select="'ComboBox-Top'" />
      <xsl:with-param name="prmRightTopClass" select="'ComboBox-TopRight'" />
      <xsl:with-param name="prmRightClass" select="'ComboBox-Right'" />
      <xsl:with-param name="prmRightBottomClass" select="'ComboBox-BottomRight'" />
      <xsl:with-param name="prmBottomClass" select="'ComboBox-Bottom'" />
      <xsl:with-param name="prmCenterClass" select="'ComboBox-Center'" />

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftPopupWindowFrameWidth]" />
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightPopupWindowFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopPopupWindowFrameHeight]" />
      <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomPopupWindowFrameHeight]"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Params for using the ComboBox content popup window  -->
  <xsl:template match="Tags.Options[../@Attr.CustomStyle='M']" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCenterContentOptionsAPI" >
      <xsl:with-param name="prmItemClass" select="'ComboBox-Item'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmItemTableClass" select="'ComboBox-ItemTable'" />
    </xsl:call-template>
  </xsl:template>
  
  <!--Match for applying input's attributes-->
  <xsl:template match="WC:Tags.ComboBox[@Attr.CustomStyle='M' and @Attr.Mask]" mode="modApplyAttributes">
    <xsl:param name="prmControlId" />
    <xsl:param name="prmValue" />
    <xsl:param name="prmControlReadOnly" />
      
    <xsl:param name="prmMaskPasteHandler" select="'mobjApp.Common_MaskOnPaste(this);'"/>
    <xsl:param name="prmMaskKeyDownHandler" select="'return mobjApp.Common_MaskKeyDown(this,event);'"/>
    <xsl:param name="prmMaskBlurHandler" select="concat('mobjApp.Common_MaskBlur(&quot;',$prmControlId,'&quot;,this,event,window);')"/>
    <xsl:param name="prmMaskFocusHandler" select="concat('mobjApp.Common_MaskFocus(this,event,&quot;',$prmControlId,'&quot;);')"/>
    <xsl:param name="prmMaskDragEnterHandler" select="'return false;'"/>
    <xsl:param name="prmMaskKeyUpHandler" select="''"/>
    <xsl:param name="prmMaskKeyPressHandler" select="''"/>
      

    <xsl:call-template name="tplApplyMaskCapabilities">
      <xsl:with-param name="prmId" select="$prmControlId" />
      <xsl:with-param name="prmValue" select="@Attr.Value"/>

      <xsl:with-param name="prmOnPasteHandler" select="$prmMaskPasteHandler"/>
      <xsl:with-param name="prmOnKeyDownHandler" select="$prmMaskKeyDownHandler"/>
      <xsl:with-param name="prmOnBlurHandler"  select="$prmMaskBlurHandler"/>
      <xsl:with-param name="prmOnFocusHandler" select="$prmMaskFocusHandler"/>
      <xsl:with-param name="prmOnKeyUpHandler" select="$prmMaskKeyUpHandler"/>
      <xsl:with-param name="prmOnKeyPressHandler" select="$prmMaskKeyPressHandler"/>
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
