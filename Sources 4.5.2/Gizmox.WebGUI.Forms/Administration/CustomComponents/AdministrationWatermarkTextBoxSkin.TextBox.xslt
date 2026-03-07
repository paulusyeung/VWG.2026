<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.WatermarkTextBox[not(@Attr.Multiline) and (@Attr.CustomStyle='AdministrationWatermarkTextBoxSkin')]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawSingleLineWatermarkTextBox">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmControlClass" select="'WatermarkTextBox-Control'"/>
      <xsl:with-param name="prmTextClass" select="'WatermarkTextBox-Text'" />
      <xsl:with-param name="prmWatermarkTextClass" select="'WatermarkTextBox-Watermark'" />
      <xsl:with-param name="prmSingleLineClass" select="'WatermarkTextBox-SingleLine'"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
