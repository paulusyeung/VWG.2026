<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.DomainUpDown[@Attr.CustomStyle='$safeitemname$']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawDomainUpDownAPI">
      <xsl:with-param name="prmControlClass" select="'DomainUpDown-Control'"/>
      <xsl:with-param name="prmInputClass" select="'DomainUpDown-Input'"/>
      <xsl:with-param name="prmDownCellClass" select="'DomainUpDown-DownCell'"/>
      <xsl:with-param name="prmUpCellClass" select="'DomainUpDown-UpCell'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmButtonsContainerClass" select="'DomainUpDown-ButtonsContainer'" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
