<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.LinkLabel[@Attr.CustomStyle='$safeitemname$']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawLinkLabelAPI">
      <xsl:with-param name="prmControlClass" select="'LinkLabel-Control'"/>
      <xsl:with-param name="prmControlDisabledClass" select="'LinkLabel-Disabled'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.LinkLabel[@Attr.CustomStyle='$safeitemname$']" mode="modContentText">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawLinkLabelContentAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmFocusClass" select="'LinkLabel-ContentContainer'"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
