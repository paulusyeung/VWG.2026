<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	              xmlns:WC="wgcontrols"
	              xmlns:Common="http://www.gizmox.com/webgui/common">
  
  <!-- Draws the tab page body content -->
  <xsl:template match="WC:Tags.TabPage[@Attr.Appearance='4' and not(@Attr.CustomStyle)]"  mode="modBodyContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawTabPageBodyContent">
      <xsl:with-param name="prmTabPageClass" select="'WorkspaceTab-Control'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>

