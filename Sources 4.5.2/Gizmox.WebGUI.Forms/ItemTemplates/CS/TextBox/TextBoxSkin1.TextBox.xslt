<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.TextBox[not(@Attr.Multiline) and (@Attr.CustomStyle='$safeitemname$')]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawSingleLineTextBoxAPI">
      <xsl:with-param name="prmControlClass" select="'TextBox-Control'"/>
      <xsl:with-param name="prmTextClass" select="'TextBox-Text'"/>
      <xsl:with-param name="prmSingleLineClass" select="'TextBox-SingleLine'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>


  <xsl:template match="WC:Tags.TextBox[@Attr.Multiline and (@Attr.CustomStyle='$safeitemname$')]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawMultilineTextBoxAPI">
      <xsl:with-param name="prmControlClass" select="'TextBox-Control'"/>
      <xsl:with-param name="prmTextClass" select="'TextBox-Text'"/>
      <xsl:with-param name="prmMultiLineClass" select="'TextBox-MultiLine'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
