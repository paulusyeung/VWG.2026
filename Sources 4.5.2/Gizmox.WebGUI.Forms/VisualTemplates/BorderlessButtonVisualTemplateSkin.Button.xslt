<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <!-- Draws the content of a normal button -->
  <xsl:template match="WC:Tags.Button[@Attr.VisualTemplate='ButtonBorderLessVisualTemplate' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawFlatButtonAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
      <xsl:with-param name="prmFlatButtonClass" select="'Button-FlatControlBorderLess'"/>
    </xsl:call-template>
  </xsl:template>

  <!-- Draw the button content -->
  <xsl:template match="WC:Tags.Button[@Attr.VisualTemplate='ButtonBorderLessVisualTemplate' and not(@Attr.CustomStyle)]" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled"/>
    <xsl:call-template name="tplDrawButtonContentAPI">
      <xsl:with-param name="prmFontDataClass" select="'Button-FontData'"/>
      <xsl:with-param name="prmDropDownArrowImage" select="'[Skin.DropDownArrowImage]'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
      <xsl:with-param name="prmImageEnabledClass" select="'Button-Image'"/>
      <xsl:with-param name="prmImageDisabledClass" select="'Button-Image_Disabled'"/>
      <xsl:with-param name="prmApplyFontStyle" select="0" />
      <xsl:with-param name="prmApplyForeColorStyle" select="1" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.Button[@Attr.VisualTemplate='ButtonBorderLessVisualTemplate' and not(@Attr.CustomStyle)]" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBackground" select="0" />
      <xsl:with-param name="prmFont" select="0" />
      <xsl:with-param name="prmForeColor" select="1" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
