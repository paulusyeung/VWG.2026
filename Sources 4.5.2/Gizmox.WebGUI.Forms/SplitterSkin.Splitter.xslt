<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols"
	xmlns:Common="http://www.gizmox.com/webgui/common">
  <xsl:template match="WC:Tags.Splitter" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varIsSplitterFixed" select="@Attr.IsSplitterFixed"/>
    <xsl:variable name="varEnabled" select="$prmIsEnabled"/>

    <xsl:attribute name="class">
      <xsl:text>Common-Unselectable Splitter-Control</xsl:text>
      <xsl:if test="not($varEnabled='0') and not($varIsSplitterFixed='1')">
        <xsl:if test="@D='T' or @D='B'"> Common-VerticalResize</xsl:if>
        <xsl:if test="@D='L' or @D='R'"> Common-HorizontalResize</xsl:if>
      </xsl:if>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> Splitter-Control_Disabled</xsl:text>
      </xsl:if>
    </xsl:attribute>
    <xsl:if test="not($varEnabled='0') and not($varIsSplitterFixed='1')">
      <xsl:attribute name="onmousedown">mobjApp.Splitter_MouseDown('<xsl:value-of select="@Id"/>','<xsl:value-of select="@D"/>',window,event)</xsl:attribute>
    </xsl:if>
    <xsl:call-template name="tplDrawEmptyImage"/>
  </xsl:template>
</xsl:stylesheet>
