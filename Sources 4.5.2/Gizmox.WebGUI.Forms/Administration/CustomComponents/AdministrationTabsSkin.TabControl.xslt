<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.TabControl[@Attr.CustomStyle='AdministrationTabsSkin' and not(@Attr.Appearance='32')]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawTabControlAPI" >
      <xsl:with-param name="prmControlClass" select="'TabControl-Control'"/>

      <!-- Bottom Frame Classes -->
      <xsl:with-param name="prmLeftBottomFrameClass" select="'TabControl-LeftBottomFrame'"/>
      <xsl:with-param name="prmCenterBottomFrameClass" select="'TabControl-CenterBottomFrame'"/>
      <xsl:with-param name="prmRightBottomFrameClass" select="'TabControl-RightBottomFrame'"/>

      <!-- Middle Frame Classes -->
      <xsl:with-param name="prmLeftFrameClass" select="'TabControl-LeftFrame'"/>
      <xsl:with-param name="prmCenterFrameClass" select="'TabControl-CenterFrame'"/>
      <xsl:with-param name="prmRightFrameClass" select="'TabControl-RightFrame'"/>

      <!-- Top Frame Classes -->
      <xsl:with-param name="prmLeftTopFrameClass" />
      <xsl:with-param name="prmCenterTopFrameClass" />
      <xsl:with-param name="prmRightTopFrameClass" />
      <!-- Seperator Classes -->
      <xsl:with-param name="prmLeftSeperatorClass" select="'TabControl-SeperatorLeftFrame'"/>
      <xsl:with-param name="prmCenterSeperatorClass" select="'TabControl-SeperatorCenterFrame'"/>
      <xsl:with-param name="prmRightSeperatorClass" select="'TabControl-SeperatorRightFrame'"/>

      <xsl:with-param name="prmTabsContainerClass" select="'TabControl-TabsTopContainer'"/>
      <xsl:with-param name="prmTabControlContainerClass" select="'TabControl-Container'"/>

      <xsl:with-param name="prmTabClass" select="'TabControl-Tab'"/>
      <xsl:with-param name="prmTabLeftClass" select="'TabControl-TabTopLeft'"/>
      <xsl:with-param name="prmTabCenterClass" select="'Common-FontData TabControl-TabTopCenter'"/>
      <xsl:with-param name="prmTabRightClass" select="'TabControl-TabTopRight'"/>
      <xsl:with-param name="prmTabLeftWidth" select="[Skin.LeftTopTabWidth]" />
      <xsl:with-param name="prmTabRightWidth" select="[Skin.RightTopTabWidth]" />
      <xsl:with-param name="prmTabHeaderTextClass" select="'TabControl-PageHeaderText'"/>

      <xsl:with-param name="prmTabsBottomContainerClass" select="'TabControl-TabsBottomContainer'"/>
      <xsl:with-param name="prmTabBottomLeftClass" select="'TabControl-TabBottomLeft'"/>
      <xsl:with-param name="prmTabBottomCenterClass" select="'Common-FontData TabControl-TabBottomCenter'"/>
      <xsl:with-param name="prmTabBottomRightClass" select="'TabControl-TabBottomRight'"/>
      <xsl:with-param name="prmTabBottomLeftWidth" select="[Skin.LeftBottomTabWidth]" />
      <xsl:with-param name="prmTabBottomRightWidth" select="[Skin.RightBottomTabWidth]" />

      <xsl:with-param name="prmSeperatorHeight" select="[Skin.SeperatorFrameHeight]" />

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]" />
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomFrameHeight]" />
      <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopFrameHeight]" />
      <xsl:with-param name="prmTabHeight" select="[Skin.TabHeight]"/>
      <xsl:with-param name="prmHeadersRowClass"/>
      <xsl:with-param name="prmHeadersOffset" select="[Skin.HeadersOffset]"/>
      <xsl:with-param name="prmHasExtra" select="0"/>

      <xsl:with-param name="prmExtraTabLeftClass" select="'TabControl-TabTopLeft'"/>
      <xsl:with-param name="prmExtraTabCenterClass" select="'Common-FontData TabControl-TabTopCenter'"/>
      <xsl:with-param name="prmExtraTabRightClass" select="'TabControl-TabTopRight'"/>
      <xsl:with-param name="prmExtraTabLeftWidth" select="[Skin.LeftTopTabWidth]" />
      <xsl:with-param name="prmExtraTabRightWidth" select="[Skin.RightTopTabWidth]" />

      <xsl:with-param name="prmLeftScrollButtonClass" select="'TabControl-LeftScrollButton'" />
      <xsl:with-param name="prmRightScrollButtonClass" select="'TabControl-RightScrollButton'" />
      <xsl:with-param name="prmCloseButtonClass" select="'TabControl-CloseButton'" />
      <xsl:with-param name="prmExpandButtonClass" select="'TabControl-ExpandButton'" />
      <xsl:with-param name="prmCollapseButtonClass" select="'TabControl-CollapseButton'" />

      <xsl:with-param name="prmLeftScrollButtonWidth" select="'[Skin.LeftScrollButtonWidth]'" />
      <xsl:with-param name="prmRightScrollButtonWidth" select="'[Skin.RightScrollButtonWidth]'" />
      <xsl:with-param name="prmCloseButtonWidth" select="'[Skin.CloseButtonWidth]'" />
      <xsl:with-param name="prmExpandButtonWidth" select="[Skin.ExpandButtonWidth]" />
      <xsl:with-param name="prmCollapseButtonWidth" select="[Skin.CollapseButtonWidth]" />
      <xsl:with-param name="prmTabImageSize" select="'TabControl-ImageSize'" />
      <xsl:with-param name="prmContextualTabGroupHeight" select="[Skin.ContextualTabGroupHeight]"/>
      <xsl:with-param name="prmContextualTabGroupClass" select="'TabControl-ContextualTabGroup'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.TabControl[@Attr.CustomStyle='AdministrationTabsSkin' and @Attr.Appearance='32']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawTabControlAPI" >
      <xsl:with-param name="prmControlClass" select="'TabControl-Control'"/>

      <!-- Bottom Frame Classes -->
      <xsl:with-param name="prmLeftBottomFrameClass" select="'TabControl-LeftBottomFrame'"/>
      <xsl:with-param name="prmCenterBottomFrameClass" select="'TabControl-CenterBottomFrame'"/>
      <xsl:with-param name="prmRightBottomFrameClass" select="'TabControl-RightBottomFrame'"/>

      <!-- Middle Frame Classes -->
      <xsl:with-param name="prmLeftFrameClass" select="'TabControl-LeftFrame'"/>
      <xsl:with-param name="prmCenterFrameClass" select="'TabControl-CenterFrame'"/>
      <xsl:with-param name="prmRightFrameClass" select="'TabControl-RightFrame'"/>

      <!-- Top Frame Classes -->
      <xsl:with-param name="prmLeftTopFrameClass" select="'TabControl-LeftTopFrame'"/>
      <xsl:with-param name="prmCenterTopFrameClass" select="'TabControl-CenterTopFrame'"/>
      <xsl:with-param name="prmRightTopFrameClass" select="'TabControl-RightTopFrame'"/>
      <!-- Seperator Classes -->
      <xsl:with-param name="prmLeftSeperatorClass" select="'TabControl-SeperatorLeftFrame'"/>
      <xsl:with-param name="prmCenterSeperatorClass" select="'TabControl-SeperatorCenterFrame'"/>
      <xsl:with-param name="prmRightSeperatorClass" select="'TabControl-SeperatorRightFrame'"/>

      <xsl:with-param name="prmTabsContainerClass" select="'TabControl-TabsTopContainer'"/>
      <xsl:with-param name="prmTabControlContainerClass" select="'TabControlSpread-Container'"/>

      <xsl:with-param name="prmTabClass" select="'TabControl-Tab'"/>
      <xsl:with-param name="prmTabLeftClass" select="'TabControl-TabTopLeft'"/>
      <xsl:with-param name="prmTabCenterClass" select="'TabControlSpread-TabTopCenter'"/>
      <xsl:with-param name="prmTabRightClass" select="'TabControl-TabTopRight'"/>
      <xsl:with-param name="prmTabLeftWidth" select="[Skin.LeftTopTabWidth]" />
      <xsl:with-param name="prmTabRightWidth" select="[Skin.RightTopTabWidth]" />
      <xsl:with-param name="prmTabHeaderTextClass" select="'TabControl-PageHeaderText'"/>

      <xsl:with-param name="prmTabsBottomContainerClass" select="'TabControl-TabsBottomContainer'"/>
      <xsl:with-param name="prmTabBottomLeftClass" select="'TabControl-TabBottomLeft'"/>
      <xsl:with-param name="prmTabBottomCenterClass" select="'TabControlSpread-TabBottomCenter'"/>
      <xsl:with-param name="prmTabBottomRightClass" select="'TabControl-TabBottomRight'"/>
      <xsl:with-param name="prmTabBottomLeftWidth" select="[Skin.LeftBottomTabWidth]" />
      <xsl:with-param name="prmTabBottomRightWidth" select="[Skin.RightBottomTabWidth]" />

      <xsl:with-param name="prmSeperatorHeight" select="[Skin.SeperatorFrameHeight]" />

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]" />
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomFrameHeight]" />
      <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopFrameHeight]" />
      <xsl:with-param name="prmTabDivContainer" select="'TabControl-TabDivContainer'" />
      <xsl:with-param name="prmTabHeight" select="[Skin.TabSpreadHeight]"/>
      <xsl:with-param name="prmHeadersRowClass"/>
      <xsl:with-param name="prmHeadersOffset" select="[Skin.HeadersOffset]"/>
      <xsl:with-param name="prmHasExtra" select="0"/>

      <xsl:with-param name="prmExtraTabLeftClass" select="'TabControl-TabTopLeft'"/>
      <xsl:with-param name="prmExtraTabCenterClass" select="'TabControlSpread-TabTopCenter'"/>
      <xsl:with-param name="prmExtraTabRightClass" select="'TabControl-TabTopRight'"/>
      <xsl:with-param name="prmExtraTabLeftWidth" select="[Skin.LeftTopTabWidth]" />
      <xsl:with-param name="prmExtraTabRightWidth" select="[Skin.RightTopTabWidth]" />

      <xsl:with-param name="prmLeftScrollButtonClass" select="'TabControl-LeftScrollButton'" />
      <xsl:with-param name="prmRightScrollButtonClass" select="'TabControl-RightScrollButton'" />
      <xsl:with-param name="prmCloseButtonClass" select="'TabControl-CloseButton'" />
      <xsl:with-param name="prmExpandButtonClass" select="'TabControl-ExpandButton'" />
      <xsl:with-param name="prmCollapseButtonClass" select="'TabControl-CollapseButton'" />

      <xsl:with-param name="prmLeftScrollButtonWidth" select="'[Skin.LeftScrollButtonWidth]'" />
      <xsl:with-param name="prmRightScrollButtonWidth" select="'[Skin.RightScrollButtonWidth]'" />
      <xsl:with-param name="prmCloseButtonWidth" select="'[Skin.CloseButtonWidth]'" />
      <xsl:with-param name="prmExpandButtonWidth" select="[Skin.ExpandButtonWidth]" />
      <xsl:with-param name="prmCollapseButtonWidth" select="[Skin.CollapseButtonWidth]" />
      <xsl:with-param name="prmTabImageSize" select="'TabControlSpread-ImageSize'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="WC:Tags.TabControl[@Attr.CustomStyle='AdministrationTabsSkin' and not(@Attr.Appearance='32')]" mode="modPagesHeaderContent">
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabLeftClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabRightClass"/>
    <xsl:param name="prmTabLeftWidth" />
    <xsl:param name="prmTabRightWidth"/>
    <xsl:param name="prmTabHeaderTextClass"/>
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmTabDivContainer"/>
    <xsl:param name="prmTabImageSize"/>
    <xsl:param name="prmIsEnabled"/>
    
    <ul class="AdministrationTabs-HeadersContainer">
      <xsl:for-each select="WC:Tags.TabPage">
        <li>
          <xsl:apply-templates select="." mode="modHeaderContent">
            <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
            <xsl:with-param name="prmTabLeftClass" select="$prmTabLeftClass"/>
            <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
            <xsl:with-param name="prmTabRightClass" select="$prmTabRightClass"/>
            <xsl:with-param name="prmTabLeftWidth" select="$prmTabLeftWidth" />
            <xsl:with-param name="prmTabRightWidth" select="$prmTabRightWidth" />
            <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
            <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
            <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
            <xsl:with-param name="prmTabImageSize" select="$prmTabImageSize" />
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>
        </li>
      </xsl:for-each>
    </ul>
  </xsl:template>
  
</xsl:stylesheet>
