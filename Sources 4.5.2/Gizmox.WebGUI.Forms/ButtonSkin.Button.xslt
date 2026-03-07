<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template name="tplDrawFlatButtonAPI">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmFlatButtonClass" select="'Button-FlatControl'"/>
    <xsl:param name="prmClickHandler" />
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.Button_KeyPress(&quot;',@Attr.Id,'&quot;,this,event);')"/>
    <xsl:param name="prmSupportStateStyle">1</xsl:param>

    <!-- Apply button attributes -->
    <xsl:call-template name="tplApplyButtonAttributes" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmButtonClass" select="$prmFlatButtonClass" />
      <xsl:with-param name="prmClickHandler" select="$prmClickHandler"/>
      <xsl:with-param name="prmKeyDownHandler" select="$prmKeyDownHandler"/>
      <xsl:with-param name="prmSupportStateStyle" select="$prmSupportStateStyle"/>
    </xsl:call-template>

    <!-- Draw button frame -->
    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmLeftFrameWidth" select="0"/>
      <xsl:with-param name="prmRightFrameWidth" select="0" />
      <xsl:with-param name="prmTopFrameHeight"  select="0"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="0"/>
      <xsl:with-param name="prmCenterContent" select="."/>
      <xsl:with-param name="prmApplyPedding" select="1" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Draws the content of a flat button -->
  <xsl:template match="WC:Tags.Button[@Attr.CustomStyle='F']" mode="modContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawFlatButtonAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
  <!-- Draw the button content -->
  <xsl:template match="WC:Tags.Button" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled"/>
    <xsl:call-template name="tplDrawButtonContentAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Disable styles that are not used in button -->
  <xsl:template match="WC:Tags.Button" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBackground" select="0" />
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing control-->
  <xsl:template name="tplDrawButtonAPI">
    <!--Template parameters-->
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmButtonClass" select="'Button-Control'" />
    <xsl:param name="prmLeftBottomClass" select="'Button-BottomLeft'" />
    <xsl:param name="prmLeftClass" select="'Button-Left'" />
    <xsl:param name="prmLeftTopClass" select="'Button-TopLeft'" />
    <xsl:param name="prmTopClass" select="'Button-Top'" />
    <xsl:param name="prmRightTopClass" select="'Button-TopRight'" />
    <xsl:param name="prmRightClass" select="'Button-Right'" />
    <xsl:param name="prmRightBottomClass" select="'Button-BottomRight'" />
    <xsl:param name="prmBottomClass" select="'Button-Bottom'" />
    <xsl:param name="prmFontDataClass" select="'Button-FontData'" />
    <xsl:param name="prmCenterClass" select="'Button-Center'" />
    <xsl:param name="prmCenterTransparentClass" select="'Button-CenterTransparent'" />
    <xsl:param name="prmContentClass" select="'Button-Content'" />
    <xsl:param name="prmClickHandler" />
    <xsl:param name="prmKeyDownHandler" select="concat('mobjApp.Button_KeyPress(&quot;',@Attr.Id,'&quot;,this,event);')"/>
    <xsl:param name="prmSupportStateStyle">1</xsl:param>

    <xsl:param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]" />
    <xsl:param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
    <xsl:param name="prmTopFrameHeight" select="[Skin.TopFrameHeight]" />
    <xsl:param name="prmBottomFrameHeight" select="[Skin.BottomFrameHeight]" />

    <!-- Apply button attributes -->
    <xsl:call-template name="tplApplyButtonAttributes" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmButtonClass" select="$prmButtonClass" />
      <xsl:with-param name="prmClickHandler" select="$prmClickHandler"/>
      <xsl:with-param name="prmKeyDownHandler" select="$prmKeyDownHandler"/>
      <xsl:with-param name="prmSupportStateStyle" select="$prmSupportStateStyle"/>
    </xsl:call-template>

    <!-- Draw button frame -->
    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmLeftBottomClass" select="$prmLeftBottomClass"/>
      <xsl:with-param name="prmLeftClass" select="$prmLeftClass"/>
      <xsl:with-param name="prmLeftTopClass" select="$prmLeftTopClass"/>
      <xsl:with-param name="prmTopClass" select="$prmTopClass"/>
      <xsl:with-param name="prmRightTopClass" select="$prmRightTopClass"/>
      <xsl:with-param name="prmRightClass" select="$prmRightClass"/>
      <xsl:with-param name="prmRightBottomClass" select="$prmRightBottomClass"/>
      <xsl:with-param name="prmBottomClass" select="$prmBottomClass"/>
      <xsl:with-param name="prmCenterClass" select="concat($prmFontDataClass,' Button-CenterBase ',$prmCenterClass)"/>
      <xsl:with-param name="prmContentClass" select="$prmContentClass" />
      <xsl:with-param name="prmLeftFrameWidth" select="$prmLeftFrameWidth"/>
      <xsl:with-param name="prmRightFrameWidth" select="$prmRightFrameWidth" />
      <xsl:with-param name="prmTopFrameHeight"  select="$prmTopFrameHeight"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="$prmBottomFrameHeight"/>
      <xsl:with-param name="prmLeftContentOffset" select="0" />
      <xsl:with-param name="prmRightContentOffset" select="0" />
      <xsl:with-param name="prmTopContentOffset" select="0" />
      <xsl:with-param name="prmBottomContentOffset" select="0" />
      <xsl:with-param name="prmCenterContent" select="."/>
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing control's content-->
  <xsl:template name="tplDrawButtonContentAPI">
    <!--Template parameters-->
    <xsl:param name="prmFontDataClass" select="'Button-FontData'" />
    <xsl:param name="prmImageHeight" select="@Attr.ImageHeight" />
    <xsl:param name="prmImageWidth" select="@Attr.ImageWidth" />
    <xsl:param name="prmDropDownArrowImage" select="'[Skin.DropDownArrowImage]'" />
    <xsl:param name="prmDropDownArrowImageDisabledClass" select="'DropDownArrow-Image_Disabled'"/>
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled"/>
    <xsl:param name="prmImageEnabledClass" select="'Button-Image'"/>
    <xsl:param name="prmImageDisabledClass" select="'Button-Image_Disabled'"/>
    <xsl:param name="prmDropDown" select="@Attr.DropDown" />
    <xsl:param name="prmDropDownClickHandler" select="''"/>
    <xsl:param name="prmApplyFontStyle" select="1" />
    <xsl:param name="prmApplyForeColorStyle" select="1" />

    <xsl:variable name="varImageClass">
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:value-of select="$prmImageEnabledClass"/>
      </xsl:if>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="$prmImageDisabledClass"/>
      </xsl:if>
    </xsl:variable>


    <xsl:variable name="varDropDownArrowImageDisabled">
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="$prmDropDownArrowImageDisabledClass"/>
      </xsl:if>
    </xsl:variable>

    <div class="Common-Strech">
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyStyles" >
          <xsl:with-param name="prmBorder" select="0" />
          <xsl:with-param name="prmBackground" select="1" />
          <xsl:with-param name="prmFont" select="0" />
          <xsl:with-param name="prmCursor" select="0" />
          <xsl:with-param name="prmVisualEffects" select="0" />
        </xsl:call-template>
        <xsl:call-template name="tplApplyPaddings"/>
        overflow:hidden;
      </xsl:attribute>

      <xsl:call-template name="tplDrawButtonContent">
        <xsl:with-param name="prmTextClass" select="$prmFontDataClass"/>
        <xsl:with-param name="prmDropDown" select="$prmDropDown" />
        <xsl:with-param name="prmDropDownClickHandler" select="$prmDropDownClickHandler" />
        <xsl:with-param name="prmDropDownImage" select="$prmDropDownArrowImage" />
        <xsl:with-param name="prmDropDownClass" select="$varDropDownArrowImageDisabled" />
        <xsl:with-param name="prmImageHeight" select="$prmImageHeight" />
        <xsl:with-param name="prmImageWidth" select="$prmImageWidth" />
        <xsl:with-param name="prmImageClass" select="$varImageClass"/>
        <xsl:with-param name="prmApplyFontStyle" select="$prmApplyFontStyle" />
        <xsl:with-param name="prmApplyForeColorStyle" select="$prmApplyForeColorStyle" />
      </xsl:call-template>
    </div>
  </xsl:template>
</xsl:stylesheet>
