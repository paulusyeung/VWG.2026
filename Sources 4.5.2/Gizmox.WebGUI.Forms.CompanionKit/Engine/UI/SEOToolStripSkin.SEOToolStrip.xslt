<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.ToolStrip[@Attr.CustomStyle='SEO']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripAPI">
      <xsl:with-param name="prmLeftBottomClass" select="'ToolStrip-BottomLeft'"/>
    <xsl:with-param name="prmLeftClass" select="'ToolStrip-Left'"/>
    <xsl:with-param name="prmLeftTopClass" select="'ToolStrip-TopLeft'"/>
    <xsl:with-param name="prmTopClass" select="'ToolStrip-Top'"/>
    <xsl:with-param name="prmRightTopClass" select="'ToolStrip-TopRight'"/>
    <xsl:with-param name="prmRightClass" select="'ToolStrip-Right'"/>
    <xsl:with-param name="prmRightBottomClass" select="'ToolStrip-BottomRight'"/>
    <xsl:with-param name="prmBottomClass" select="'ToolStrip-Bottom'"/>
    <xsl:with-param name="prmCenterClass" select="'ToolStrip-Center'"/>

    <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
    <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
    <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
    <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStrip[@Attr.CustomStyle='SEO']" mode="modFrameCenterContent">
    <xsl:call-template name="tplDrawToolStripCenterFrameAPI">
      <xsl:with-param name="prmVerticalDropDownButtonClass" select="'TooStrip-VerticalDropDownButton'"/>
    <xsl:with-param name="prmHorizontalDropDownButtonClass" select="'TooStrip-HorizontalDropDownButton'"/>
    <xsl:with-param name="prmHorizontalGripClass" select="'TooStrip-HorizontalGrip'"/>
    <xsl:with-param name="prmVerticalGripClass" select="'TooStrip-VerticalGrip'"/>
    <xsl:with-param name="prmAllowWrapContents" select="not(@Attr.WrapContents='0')"/>
    <xsl:with-param name="prmHorizontalGripWidth"  select="[Skin.HorizontalGripWidth]"/>
    <xsl:with-param name="prmVerticalGripHeight"  select="[Skin.VerticalGripHeight]"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStrip[@Attr.CustomStyle='PG']" mode="modApplyStyle">
    <xsl:call-template name="tplApplyToolStripStyles" />
  </xsl:template>
</xsl:stylesheet>
