<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.Button[@Attr.CustomStyle='ColumnChooserButtonSkin']" mode="modFrameCenterContent">
    <xsl:call-template name="tplDrawButtonContentAPI">
      <xsl:with-param name="prmFontDataClass" select="'Button-FontData'"/>
      <xsl:with-param name="prmDropDownArrowImage" select="'[Skin.DropDownArrowImage]'"/>
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
