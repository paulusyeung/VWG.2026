<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.Label[@Attr.CustomStyle='ZoneHeaderLabelSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawLabelAPI">
      <xsl:with-param name="prmControlClass" select="'Label-Control'"/>
      <xsl:with-param name="prmControlDisabledClass" select="'Label-Disabled'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.Label[@Attr.CustomStyle='ZoneHeaderLabelSkin']" mode="modContentText">
    <xsl:call-template name="tplDrawLabelContentAPI">
      <xsl:with-param name="prmContentContainerClass" select="'Label-ContentContainer'"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
