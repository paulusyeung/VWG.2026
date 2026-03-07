<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='AnchorPanelSkin']" mode="modContent">
    <xsl:call-template name="tplDrawPanelAPI">
      <xsl:with-param name="prmControlClass" select="'Panel-Control'"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
