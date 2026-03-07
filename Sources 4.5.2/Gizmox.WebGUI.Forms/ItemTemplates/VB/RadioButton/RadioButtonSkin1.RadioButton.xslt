<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.RadioButton[@Attr.CustomStyle='$safeitemname$']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawRadioButtonAPI">
      <xsl:with-param name="prmControlClass" select="'RadioButton-Control'" />
      <xsl:with-param name="prmLabelClass" select="'RadioButton-Label'" />
      <xsl:with-param name="prmCheckedRadioImage" select="'[Skin.CheckedRadioImage]'"/>
      <xsl:with-param name="prmUnCheckedRadioImage" select="'[Skin.UnCheckedRadioImage]'"/>
      <xsl:with-param name="prmStateImageHeight" select="[Skin.RadioImageHeight]" />
      <xsl:with-param name="prmStateImageWidth" select="[Skin.RadioImageWidth]" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.RadioButton[@Attr.CustomStyle='$safeitemname$' and @Attr.Appearance='1']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawRadioButtonInButtonAppereanceAPI">
      <xsl:with-param name="prmRadioButtonClass" select="'RadioButton-ButtonControl'"/>
      <xsl:with-param name="prmCheckedRadioButtonClass" select="'RadioButton-ButtonControlChecked'"/>
      <xsl:with-param name="prmLeftBottomClass" select="'RadioButton-BottomLeft'" />
      <xsl:with-param name="prmLeftClass" select="'RadioButton-Left'" />
      <xsl:with-param name="prmLeftTopClass" select="'RadioButton-TopLeft'" />
      <xsl:with-param name="prmTopClass" select="'RadioButton-Top'" />
      <xsl:with-param name="prmRightTopClass" select="'RadioButton-TopRight'" />
      <xsl:with-param name="prmRightClass" select="'RadioButton-Right'" />
      <xsl:with-param name="prmRightBottomClass" select="'RadioButton-BottomRight'" />
      <xsl:with-param name="prmBottomClass" select="'RadioButton-Bottom'" />
      <xsl:with-param name="prmFontDataClass" select="'RadioButton-FontData'" />
      <xsl:with-param name="prmCenterClass" select="'RadioButton-Center'" />
      <xsl:with-param name="prmCenterTransparentClass" select="'RadioButton-CenterTransparent'" />
      <xsl:with-param name="prmContentClass" select="'RadioButton-Content'" />
	  <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
	  <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
	  <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
	  <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.RadioButton[@Attr.CustomStyle='$safeitemname$' and @Attr.Appearance='1']" mode="modFrameCenterContent">
    <xsl:call-template name="tplDrawRadioButtonInButtonAppereanceCenterContentAPI">
      <xsl:with-param name="prmFontDataClass" select="'RadioButton-FontData'" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
