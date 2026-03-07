<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.ToolBarButton[../@Attr.Style='F']" mode="modButtonContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmControlClass" select="'FlatToolBarButton-Control'" />
    <xsl:attribute name="class">
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:text>Common-HandCursor </xsl:text>
      </xsl:if>
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' Common-Disabled ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmFrameClass" select="'FlatToolBarButton-Frame'"/>
      <xsl:with-param name="prmLeftBottomClass" select="''"/>
      <xsl:with-param name="prmLeftClass" select="''"/>
      <xsl:with-param name="prmLeftTopClass" select="''"/>
      <xsl:with-param name="prmTopClass" select="''"/>
      <xsl:with-param name="prmRightTopClass" select="''"/>
      <xsl:with-param name="prmRightClass" select="''"/>
      <xsl:with-param name="prmRightBottomClass" select="''"/>
      <xsl:with-param name="prmBottomClass" select="''"/>
      <xsl:with-param name="prmCenterClass" select="'FlatToolBarButton-Center'"/>
      <xsl:with-param name="prmCenterContent" select="." />

      <xsl:with-param name="prmIsAutoSize" select="1" />

      <xsl:with-param name="prmLeftFrameWidth" select="0"/>
      <xsl:with-param name="prmRightFrameWidth" select="0" />
      <xsl:with-param name="prmTopFrameHeight"  select="0"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="0"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
