<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.NumericUpDown[@Attr.CustomStyle='$safeitemname$']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawNumericUpDownAPI">
      <xsl:with-param name="prmControlClass" select="'NumericUpDown-Control'"/>
      <xsl:with-param name="prmInputClass" select="'NumericUpDown-Input'"/>
      <xsl:with-param name="prmDownCellClass" select="'NumericUpDown-DownCell'"/>
      <xsl:with-param name="prmUpCellClass" select="'NumericUpDown-UpCell'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
