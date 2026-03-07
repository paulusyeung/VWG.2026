<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.Label[@Attr.VisualTemplate='TitleLabelVisualTemplate' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawLabelAPI">
      <xsl:with-param name="prmControlClass" select="'Label-Control'"/>
      <xsl:with-param name="prmControlDisabledClass" select="'Label-Disabled'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.Label[@Attr.VisualTemplate='TitleLabelVisualTemplate' and not(@Attr.CustomStyle)]" mode="modContentText">
    <xsl:call-template name="tplDrawLabelContentAPI">
      <xsl:with-param name="prmContentContainerClass" select="'Label-ContentContainer'"/>
      <xsl:with-param name="prmApplyFontStyles" select="0"/>
    </xsl:call-template>
  </xsl:template>


  <xsl:template match="WC:Tags.Label[@Attr.VisualTemplate='TitleLabelVisualTemplate' and not(@Attr.CustomStyle)]" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBackground" select="0" />
      <xsl:with-param name="prmFont" select="0" />
      <xsl:with-param name="prmForeColor" select="1" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
