<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.ToolBarButton" mode="modButtonContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmControlClass" select="'ToolBarButton-Control'" />
    <xsl:attribute name="class">
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:text>Common-HandCursor </xsl:text>
      </xsl:if>
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled' ,' Common-Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:if test="@Attr.Pushed='1'">
      <xsl:call-template name="tplDrawFrame">
        <xsl:with-param name="prmContentClass" select="'ToolBarButton-Content'" />
        <xsl:with-param name="prmFrameClass" select="'ToolBarButton-Frame'"/>
        <xsl:with-param name="prmLeftBottomClass" select="'ToolBarButton-PushedBottomLeft'"/>
        <xsl:with-param name="prmLeftClass" select="'ToolBarButton-PushedLeft'"/>
        <xsl:with-param name="prmLeftTopClass" select="'ToolBarButton-PushedTopLeft'"/>
        <xsl:with-param name="prmTopClass" select="'ToolBarButton-PushedTop'"/>
        <xsl:with-param name="prmRightTopClass" select="'ToolBarButton-PushedTopRight'"/>
        <xsl:with-param name="prmRightClass" select="'ToolBarButton-PushedRight'"/>
        <xsl:with-param name="prmRightBottomClass" select="'ToolBarButton-PushedBottomRight'"/>
        <xsl:with-param name="prmBottomClass" select="'ToolBarButton-PushedBottom'"/>
        <xsl:with-param name="prmCenterClass" select="'ToolBarButton-PushedCenter'"/>
        <xsl:with-param name="prmCenterContent" select="." />

        <xsl:with-param name="prmIsAutoSize" select="1" />

        <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
        <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
        <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
        <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>

        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:if>

    <xsl:if test="not(@Attr.Pushed='1')">
      <xsl:call-template name="tplDrawFrame">
        <xsl:with-param name="prmContentClass" select="'ToolBarButton-Content'" />
        <xsl:with-param name="prmFrameClass" select="'ToolBarButton-Frame'"/>
        <xsl:with-param name="prmLeftBottomClass" select="'ToolBarButton-BottomLeft'"/>
        <xsl:with-param name="prmLeftClass" select="'ToolBarButton-Left'"/>
        <xsl:with-param name="prmLeftTopClass" select="'ToolBarButton-TopLeft'"/>
        <xsl:with-param name="prmTopClass" select="'ToolBarButton-Top'"/>
        <xsl:with-param name="prmRightTopClass" select="'ToolBarButton-TopRight'"/>
        <xsl:with-param name="prmRightClass" select="'ToolBarButton-Right'"/>
        <xsl:with-param name="prmRightBottomClass" select="'ToolBarButton-BottomRight'"/>
        <xsl:with-param name="prmBottomClass" select="'ToolBarButton-Bottom'"/>
        <xsl:with-param name="prmCenterClass" select="'ToolBarButton-Center'"/>
        <xsl:with-param name="prmCenterContent" select="." />

        <xsl:with-param name="prmIsAutoSize" select="1" />

        <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
        <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
        <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
        <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>

        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  
</xsl:stylesheet>
