<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <!--Draw content text-->
  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='6' and not(@Attr.CustomStyle)]" mode="modContentText">
    <xsl:call-template name="tplDrawToolStripLabelContentAPI"/>
  </xsl:template>

  <!--Label / LinkLabel usage-->
  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='6' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripLabelAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Applay label backgroud color-->
  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='6' and not(@Attr.CustomStyle)]" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles">
      <xsl:with-param name="prmBorder" select="0" />
      <xsl:with-param name="prmBackground" select="1" />
      <xsl:with-param name="prmFont" select="0" />
      <xsl:with-param name="prmCursor" select="0" />
      <xsl:with-param name="prmVisualEffects" select="0" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
