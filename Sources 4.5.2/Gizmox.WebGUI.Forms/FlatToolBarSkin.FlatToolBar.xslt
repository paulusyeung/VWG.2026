<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                xmlns:WC="wgcontrols" 
                xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.ToolBarControl[@Attr.Style='F']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmLeftBottomClass" select="'FlatToolBar-BottomLeft'"/>
      <xsl:with-param name="prmLeftClass" select="'FlatToolBar-Left'"/>
      <xsl:with-param name="prmLeftTopClass" select="'FlatToolBar-TopLeft'"/>
      <xsl:with-param name="prmTopClass" select="'FlatToolBar-Top'"/>
      <xsl:with-param name="prmRightTopClass" select="'FlatToolBar-TopRight'"/>
      <xsl:with-param name="prmRightClass" select="'FlatToolBar-Right'"/>
      <xsl:with-param name="prmRightBottomClass" select="'FlatToolBar-BottomRight'"/>
      <xsl:with-param name="prmBottomClass" select="'FlatToolBar-Bottom'"/>
      <xsl:with-param name="prmCenterClass" select="'FlatToolBar-Center'"/>

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
      
      <xsl:with-param name="prmCenterContent" select="." />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
