<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:UC" mode="modAutoSize">
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:call-template name="tplDrawUserControl">
      <xsl:with-param name="prmAutoSizeMode" select="'1'"/>
      <xsl:with-param name="prmAutoSizeOrientation" select="$prmAutoSizeOrientation"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="WC:UC" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawUserControl">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawUserControl">
    <xsl:param name="prmAutoSizeMode" select="'0'"/>
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:if test="$prmIsEnabled='0'">
      <xsl:attribute name="class">Common-InheritDisabled</xsl:attribute>
    </xsl:if>
    <xsl:call-template name="tplDrawContained">
      <xsl:with-param name="prmAutoSizeMode" select="$prmAutoSizeMode" />
      <xsl:with-param name="prmAutoSizeOrientation" select="$prmAutoSizeOrientation" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
  
  

  
