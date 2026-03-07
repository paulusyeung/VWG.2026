<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

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
      <xsl:with-param name="prmLeftBottomClass" select="'FlatToolBarButton-BottomLeft'"/>
      <xsl:with-param name="prmLeftClass" select="'FlatToolBarButton-Left'"/>
      <xsl:with-param name="prmLeftTopClass" select="'FlatToolBarButton-TopLeft'"/>
      <xsl:with-param name="prmTopClass" select="'FlatToolBarButton-Top'"/>
      <xsl:with-param name="prmRightTopClass" select="'FlatToolBarButton-TopRight'"/>
      <xsl:with-param name="prmRightClass" select="'FlatToolBarButton-Right'"/>
      <xsl:with-param name="prmRightBottomClass" select="'FlatToolBarButton-BottomRight'"/>
      <xsl:with-param name="prmBottomClass" select="'FlatToolBarButton-Bottom'"/>
      <xsl:with-param name="prmCenterClass" select="'FlatToolBarButton-Center'"/>
      <xsl:with-param name="prmCenterContent" select="." />

      <xsl:with-param name="prmIsAutoSize" select="1" />

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
