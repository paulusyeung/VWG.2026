<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	              xmlns:WC="wgcontrols"
	              xmlns:Common="http://www.gizmox.com/webgui/common">

  
  <xsl:template match="WC:Tags.TabControl[@Attr.Appearance='4' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawTabControlAPI" >

      <xsl:with-param name="prmControlClass" select="'WorkspaceTabs-Control'"/>

      <xsl:with-param name="prmSeperatorHeight" select="[Skin.SeperatorFrameHeight]" />
      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]" />
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomFrameHeight]" />
      <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopFrameHeight]" />
      <xsl:with-param name="prmLeftBottomFrameClass" select="'WorkspaceTabs-LeftBottomFrame'"/>
      <xsl:with-param name="prmCenterBottomFrameClass" select="'WorkspaceTabs-CenterBottomFrame'"/>
      <xsl:with-param name="prmRightBottomFrameClass" select="'WorkspaceTabs-RightBottomFrame'"/>

      <xsl:with-param name="prmLeftFrameClass" select="'WorkspaceTabs-LeftFrame'"/>
      <xsl:with-param name="prmCenterFrameClass" select="'WorkspaceTabs-CenterFrame'"/>
      <xsl:with-param name="prmRightFrameClass" select="'WorkspaceTabs-RightFrame'"/>

      <xsl:with-param name="prmLeftTopFrameClass" select="'WorkspaceTabs-TopFrame'" />
      <xsl:with-param name="prmCenterTopFrameClass" select="'WorkspaceTabs-CenterTopFrame'" />
      <xsl:with-param name="prmRightTopFrameClass" select="'WorkspaceTabs-RightTopFrame'" />

      <xsl:with-param name="prmLeftSeperatorClass" select="'WorkspaceTabs-SeperatorLeftFrame'"/>
      <xsl:with-param name="prmCenterSeperatorClass" select="'WorkspaceTabs-SeperatorCenterFrame'"/>
      <xsl:with-param name="prmRightSeperatorClass" select="'WorkspaceTabs-SeperatorRightFrame'"/>

      <xsl:with-param name="prmTabsContainerClass" select="'WorkspaceTabs-TabsTopContainer'"/>
      
      
      <xsl:with-param name="prmTabClass" select="'WorkspaceTabs-Tab'"/>
      <xsl:with-param name="prmTabLeftClass" select="'WorkspaceTabs-TabTopLeft'"/>
      <xsl:with-param name="prmTabCenterClass" select="'Common-FontData WorkspaceTabs-TabTopCenter'"/>
      <xsl:with-param name="prmTabRightClass" select="'WorkspaceTabs-TabTopRight'"/>
      <xsl:with-param name="prmTabLeftWidth" select="[Skin.LeftTopTabWidth]" />
      <xsl:with-param name="prmTabRightWidth" select="[Skin.RightTopTabWidth]" />
      <xsl:with-param name="prmTabHeaderTextClass" select="'WorkspaceTabs-PageHeaderText'"/>
      <xsl:with-param name="prmTabHeight" select="[Skin.TabHeight]"/>
      <xsl:with-param name="prmTabDivContainer" select="'WorkspaceTabs-TabDivContainer'"/>
      <xsl:with-param name="prmTabImageSize" select="'WorkspaceTabs-ImageSize'"/>

      <xsl:with-param name="prmTabsBottomContainerClass" select="'WorkspaceTabs-TabsBottomContainer'"/>
      <xsl:with-param name="prmTabBottomLeftClass" select="'WorkspaceTabs-TabBottomLeft'"/>
      <xsl:with-param name="prmTabBottomCenterClass" select="'Common-FontData WorkspaceTabs-TabBottomCenter'"/>
      <xsl:with-param name="prmTabBottomRightClass" select="'WorkspaceTabs-TabBottomRight'"/>
      <xsl:with-param name="prmTabBottomLeftWidth" select="[Skin.LeftBottomTabWidth]" />
      <xsl:with-param name="prmTabBottomRightWidth" select="[Skin.RightBottomTabWidth]" />

      <xsl:with-param name="prmContextualTabGroupHeight" select="[Skin.ContextualTabGroupHeight]"/>
      <xsl:with-param name="prmContextualTabGroupClass" select="'WorkspaceTabs-ContextualTabGroup'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>

