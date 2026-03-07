<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"	xmlns:WC="wgcontrols">

  <!-- The default style single-line TextBox match template -->
    <xsl:template match="WC:Tags.TextBox[not(@Attr.Multiline) and @Attr.CustomStyle='Masked']" mode="modContent">
      <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawSingleLineTextBoxAPI">
      <xsl:with-param name="prmControlClass" select="'MaskedTextBox-Control'"/>
      <xsl:with-param name="prmTextClass" select="'MaskedTextBox-Text'"/>
      <xsl:with-param name="prmSingleLineClass" select="'MaskedTextBox-SingleLine'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
