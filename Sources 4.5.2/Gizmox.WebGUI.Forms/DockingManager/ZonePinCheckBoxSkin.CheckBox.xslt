<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.CheckBox[@Attr.CustomStyle='ZonePinCheckBoxSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCheckBoxAPI">
      <xsl:with-param name="prmControlClass" select="'CheckBox-Control'" />
      <xsl:with-param name="prmLabelClass" select="'CheckBox-Label'" />
      <xsl:with-param name="prmCheckedCheckBoxImage" select="'[Skin.CheckedCheckBoxImage]'"/>
      <xsl:with-param name="prmUnCheckedCheckBoxImage" select="'[Skin.UnCheckedCheckBoxImage]'"/>
      <xsl:with-param name="prmIndeterminateCheckBoxImage" select="'[Skin.IndeterminateCheckBoxImage]'"/>
      <xsl:with-param name="prmStateImageHeight" select="[Skin.CheckBoxImageHeight]" />
      <xsl:with-param name="prmStateImageWidth" select="[Skin.CheckBoxImageWidth]" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.CheckBox[@Attr.CustomStyle='ZonePinCheckBoxSkin' and @Attr.Appearance='1']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawCheckBoxInButtonAppereanceAPI">
      <xsl:with-param name="prmCheckBoxClass" select="'CheckBox-ButtonControl'"/>
      <xsl:with-param name="prmCheckedCheckBoxClass" select="'CheckBox-ButtonControlChecked'"/>
      <xsl:with-param name="prmLeftBottomClass" select="'CheckBox-BottomLeft'" />
      <xsl:with-param name="prmLeftClass" select="'CheckBox-Left'" />
      <xsl:with-param name="prmLeftTopClass" select="'CheckBox-TopLeft'" />
      <xsl:with-param name="prmTopClass" select="'CheckBox-Top'" />
      <xsl:with-param name="prmRightTopClass" select="'CheckBox-TopRight'" />
      <xsl:with-param name="prmRightClass" select="'CheckBox-Right'" />
      <xsl:with-param name="prmRightBottomClass" select="'CheckBox-BottomRight'" />
      <xsl:with-param name="prmBottomClass" select="'CheckBox-Bottom'" />
      <xsl:with-param name="prmFontDataClass" select="'CheckBox-FontData'" />
      <xsl:with-param name="prmCenterClass" select="'CheckBox-Center'" />
      <xsl:with-param name="prmCenterTransparentClass" select="'CheckBox-CenterTransparent'" />
      <xsl:with-param name="prmContentClass" select="'CheckBox-Content'" />
      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.CheckBox[@Attr.CustomStyle='ZonePinCheckBoxSkin' and @Attr.Appearance='1']" mode="modFrameCenterContent">
    <xsl:call-template name="tplDrawCheckBoxInButtonAppereanceCenterContentAPI">
      <xsl:with-param name="prmFontDataClass" select="'CheckBox-FontData'" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
