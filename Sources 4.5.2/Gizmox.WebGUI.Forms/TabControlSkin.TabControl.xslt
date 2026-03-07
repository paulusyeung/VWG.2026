<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	              xmlns:WC="wgcontrols"
	              xmlns:Common="http://www.gizmox.com/webgui/common">

  <!-- The default style TabControl match template -->
  <xsl:template match="WC:Tags.TabControl[not(@Attr.Appearance='32')]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawTabControlAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Main API for drawing the control -->
  <xsl:template name="tplDrawTabControlAPI">

    <xsl:param name="prmControlClass" select="'TabControl-Control'"/>

    <!-- Bottom Frame Classes -->
    <xsl:param name="prmLeftBottomFrameClass" select="'TabControl-LeftBottomFrame'"/>
    <xsl:param name="prmCenterBottomFrameClass" select="'TabControl-CenterBottomFrame'"/>
    <xsl:param name="prmRightBottomFrameClass" select="'TabControl-RightBottomFrame'"/>

    <!-- Middle Frame Classes -->
    <xsl:param name="prmLeftFrameClass" select="'TabControl-LeftFrame'"/>
    <xsl:param name="prmCenterFrameClass" select="'TabControl-CenterFrame'"/>
    <xsl:param name="prmRightFrameClass" select="'TabControl-RightFrame'"/>

    <!-- Top Frame Classes -->
    <xsl:param name="prmLeftTopFrameClass" />
    <xsl:param name="prmCenterTopFrameClass" />
    <xsl:param name="prmRightTopFrameClass" />


    <!-- Seperator Classes -->
    <xsl:param name="prmLeftSeperatorClass" select="'TabControl-SeperatorLeftFrame'"/>
    <xsl:param name="prmCenterSeperatorClass" select="'TabControl-SeperatorCenterFrame'"/>
    <xsl:param name="prmRightSeperatorClass" select="'TabControl-SeperatorRightFrame'"/>

    <xsl:param name="prmTabsContainerClass" select="'TabControl-TabsTopContainer'"/>
    <xsl:param name="prmTabControlContainerClass" select="'TabControl-Container'"/>


    <xsl:param name="prmTabClass" select="'TabControl-Tab'"/>
    <xsl:param name="prmTabLeftClass" select="'TabControl-TabTopLeft'"/>
    <xsl:param name="prmTabCenterClass" select="'Common-FontData TabControl-TabTopCenter'"/>
    <xsl:param name="prmTabRightClass" select="'TabControl-TabTopRight'"/>
    <xsl:param name="prmTabLeftWidth" select="[Skin.LeftTopTabWidth]"/>
    <xsl:param name="prmTabRightWidth" select="[Skin.RightTopTabWidth]" />
    <xsl:param name="prmTabHeaderTextClass" select="'TabControl-PageHeaderText'"/>

    <xsl:param name="prmTabsBottomContainerClass" select="'TabControl-TabsBottomContainer'"/>
    <xsl:param name="prmTabBottomLeftClass" select="'TabControl-TabBottomLeft'"/>
    <xsl:param name="prmTabBottomCenterClass" select="'Common-FontData TabControl-TabBottomCenter'"/>
    <xsl:param name="prmTabBottomRightClass" select="'TabControl-TabBottomRight'"/>
    <xsl:param name="prmTabBottomLeftWidth" select="[Skin.LeftBottomTabWidth]" />
    <xsl:param name="prmTabBottomRightWidth" select="[Skin.RightBottomTabWidth]" />

    <xsl:param name="prmSeperatorHeight" select="[Skin.SeperatorFrameHeight]" />

    <xsl:param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]" />
    <xsl:param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
    <xsl:param name="prmBottomFrameHeight" select="[Skin.BottomFrameHeight]" />
    <xsl:param name="prmTopFrameHeight" select="[Skin.TopFrameHeight]" />
    <xsl:param name="prmTabDivContainer" select="'TabControl-TabDivContainer'" />
    <xsl:param name="prmTabHeight" select="[Skin.TabHeight]"/>
    <xsl:param name="prmHeadersOffset" select="[Skin.HeadersOffset]"/>
    <xsl:param name="prmHeadersRowClass"/>
    <xsl:param name="prmHasExtra" select="0"/>

    <xsl:param name="prmExtraTabLeftClass" select="'TabControl-TabTopLeft'"/>
    <xsl:param name="prmExtraTabCenterClass" select="'Common-FontData TabControl-TabTopCenter'"/>
    <xsl:param name="prmExtraTabRightClass" select="'TabControl-TabTopRight'"/>
    <xsl:param name="prmExtraTabLeftWidth" select="[Skin.LeftTopTabWidth]" />
    <xsl:param name="prmExtraTabRightWidth" select="[Skin.RightTopTabWidth]" />

    <xsl:param name="prmLeftScrollButtonClass" select="'TabControl-LeftScrollButton'" />
    <xsl:param name="prmRightScrollButtonClass" select="'TabControl-RightScrollButton'" />
    <xsl:param name="prmCloseButtonClass" select="'TabControl-CloseButton'" />
    <xsl:param name="prmExpandButtonClass" select="'TabControl-ExpandButton'" />
    <xsl:param name="prmCollapseButtonClass" select="'TabControl-CollapseButton'" />

    <xsl:param name="prmLeftScrollButtonWidth" select="[Skin.LeftScrollButtonWidth]" />
    <xsl:param name="prmRightScrollButtonWidth" select="[Skin.RightScrollButtonWidth]" />
    <xsl:param name="prmCloseButtonWidth" select="[Skin.CloseButtonWidth]" />
    <xsl:param name="prmExpandButtonWidth" select="[Skin.ExpandButtonWidth]" />
    <xsl:param name="prmCollapseButtonWidth" select="[Skin.CollapseButtonWidth]" />

    <xsl:param name="prmTabImageSize" select="'TabControl-ImageSize'" />

    <xsl:param name="prmContextualTabGroupHeight" select="[Skin.ContextualTabGroupHeight]"/>
    <xsl:param name="prmContextualTabGroupClass" select="'TabControl-ContextualTabGroup'" />
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmTabLayout" select="@Attr.TabLayout"/>

    <!--Arrow Scrollers parameters-->
    <xsl:param name="prmArrowsBaseClass"     select="'TabControl-ArrowsClass'" />
    <xsl:param name="prmTopArrowThickness"     select="[Skin.ArrowTopThickness]" />
    <xsl:param name="prmRightArrowThickness"     select="[Skin.ArrowRightThickness]" />
    <xsl:param name="prmBottomArrowThickness"     select="[Skin.ArrowBottomThickness]" />
    <xsl:param name="prmLeftArrowThickness"     select="[Skin.ArrowLeftThickness]" />
    <xsl:param name="prmHorizontalHoverSpeed"     select="[Skin.HorizontalHoverSpeed]" />
    <xsl:param name="prmHorizontalDownSpeed"     select="[Skin.HorizontalDownSpeed]" />
    <xsl:param name="prmVerticalHoverSpeed"     select="[Skin.VerticalHoverSpeed]" />
    <xsl:param name="prmVerticalDownSpeed"     select="[Skin.VerticalDownSpeed]" />

    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <xsl:variable name="varIsCollapsed" select="@Attr.Expanded='0'" />
    <xsl:variable name="varHasContextualTabGroups" select="count(Tags.Group) &gt; 0"/>
    <xsl:variable name="varTabHeaderContainerHeight" select="number($prmContextualTabGroupHeight) + number($prmTabHeight)"/>


    <div id="VWGTCMD_{@Attr.Id}" style="position:relative;height:100%;width:100%;">
      <xsl:attribute name="data-vwgnormalclass"><xsl:value-of select="concat($prmTabDivContainer,' Common-HandCursor ',$prmTabClass)"/></xsl:attribute>
      <xsl:attribute name="data-vwgselectedclass"><xsl:value-of select="concat($prmTabDivContainer,' TabControl-TabTable ',$prmTabClass,' ',$prmTabClass,'_Selected')"/></xsl:attribute>
      <xsl:attribute name="data-vwgtabheight"><xsl:value-of select="$prmTabHeight"/></xsl:attribute>
      <xsl:attribute name="data-vwggroupedtabheight"><xsl:value-of select="number($prmTabHeight) + number($prmContextualTabGroupHeight)"/></xsl:attribute>

      <!-- If is top or bottom alignment-->
      <xsl:if test="$prmTabLayout='0'or $prmTabLayout='1'">
        <!-- Headers in top mode -->
        <xsl:if test="$prmTabLayout=0">
          <xsl:apply-templates select="." mode="modHeader">
            <xsl:with-param name="prmTabsContainerClass" select="$prmTabsContainerClass"/>
            <xsl:with-param name="prmTabControlContainerClass" select="$prmTabControlContainerClass"/>
            <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
            <xsl:with-param name="prmTabLeftClass" select="$prmTabLeftClass"/>
            <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
            <xsl:with-param name="prmTabRightClass" select="$prmTabRightClass"/>
            <xsl:with-param name="prmTabLeftWidth" select="$prmTabLeftWidth" />
            <xsl:with-param name="prmTabRightWidth" select="$prmTabRightWidth" />
            <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass"/>
            <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
            <xsl:with-param name="prmHeadersOffset" select="$prmHeadersOffset"/>
            <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
            <xsl:with-param name="prmTabImageSize" select="$prmTabImageSize" />
            <xsl:with-param name="prmTabLayout" select="$prmTabLayout"/>
            <xsl:with-param name="prmHeadersRowClass" select="$prmHeadersRowClass"/>
            <xsl:with-param name="prmRightFrameWidth" select="$prmRightFrameWidth"/>
            <xsl:with-param name="prmLeftFrameWidth" select="$prmLeftFrameWidth"/>
            <xsl:with-param name="prmLeftScrollButtonWidth" select="$prmLeftScrollButtonWidth"/>
            <xsl:with-param name="prmRightScrollButtonWidth" select="$prmRightScrollButtonWidth"/>
            <xsl:with-param name="prmCloseButtonWidth" select="$prmCloseButtonWidth"/>
            <xsl:with-param name="prmExpandButtonWidth" select="$prmExpandButtonWidth"/>
            <xsl:with-param name="prmCollapseButtonWidth" select="$prmCollapseButtonWidth"/>
            <xsl:with-param name="prmLeftScrollButtonClass" select="$prmLeftScrollButtonClass"/>
            <xsl:with-param name="prmRightScrollButtonClass" select="$prmRightScrollButtonClass"/>
            <xsl:with-param name="prmCloseButtonClass" select="$prmCloseButtonClass"/>
            <xsl:with-param name="prmExpandButtonClass" select="$prmExpandButtonClass"/>
            <xsl:with-param name="prmCollapseButtonClass" select="$prmCollapseButtonClass" />
            <xsl:with-param name="prmContextualTabGroupHeight" select="$prmContextualTabGroupHeight"/>
            <xsl:with-param name="prmContextualTabGroupClass" select="$prmContextualTabGroupClass" />
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>

          <!-- Seperator in top mode -->
          <xsl:if test="$prmSeperatorHeight>0">
            <xsl:variable name="varSeperatorTop">
              <xsl:choose>
                <xsl:when test="$varHasContextualTabGroups">
                  <xsl:value-of select="$varTabHeaderContainerHeight"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="$prmTabHeight"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:variable>
            <div id="VWGTCSP_{@Attr.Id}">
              <xsl:attribute name="vwgsepheight"><xsl:value-of select="$prmSeperatorHeight"/></xsl:attribute>
              <xsl:attribute name="style">position:absolute;width:100%;height:<xsl:value-of select="$prmSeperatorHeight"/>px;top:<xsl:value-of select="$varSeperatorTop"/>px;</xsl:attribute>
              <xsl:if test="$prmLeftFrameWidth>0">
                <div class="{$prmLeftSeperatorClass}">
                  <xsl:attribute name="style">position:absolute;left:0;top:0px;height:100%;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;</xsl:attribute>
                  <xsl:call-template name="tplDrawEmptyImage">
                    <xsl:with-param name="prmImageWidth" select="concat($prmLeftFrameWidth, 'px')"/>
                  </xsl:call-template>
                </div>
              </xsl:if>
              <div class="{$prmCenterSeperatorClass}">
                <xsl:attribute name="style">position:absolute;top:0px;height:100%;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;</xsl:attribute>
                <xsl:call-template name="tplDrawEmptyImage"/>
              </div>
              <xsl:if test="$prmRightFrameWidth>0">
                <div class="{$prmRightSeperatorClass}">
                  <xsl:attribute name="style">position:absolute;right:0;top:0px;height:100%;width:<xsl:value-of select="$prmRightFrameWidth"/>px;</xsl:attribute>
                  <xsl:call-template name="tplDrawEmptyImage">
                    <xsl:with-param name="prmImageWidth" select="concat($prmRightFrameWidth, 'px')"/>
                  </xsl:call-template>
                </div>
              </xsl:if>
            </div>
          </xsl:if>
        </xsl:if>

        <!-- Top frame cells in Bottom mode) -->
        <xsl:if test="$prmBottomFrameHeight>0 and $prmTabLayout=1 and not($varIsCollapsed)">
          <xsl:if test="$prmLeftFrameWidth>0">
            <div class="{$prmLeftBottomFrameClass}">
              <xsl:attribute name="style">position:absolute;left:0;top:0;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
          </xsl:if>
          <div  class="{$prmCenterBottomFrameClass}">
            <xsl:attribute name="style">position:absolute;top:0;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;height:{$prmBottomFrameHeight}px;</xsl:attribute>
            <xsl:call-template name="tplDrawEmptyImage"/>
          </div>
          <xsl:if test="$prmRightFrameWidth>0">
            <div class="{$prmRightBottomFrameClass}">
              <xsl:attribute name="style">position:absolute;right:0;top:0;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
          </xsl:if>
        </xsl:if>

        <!-- Body content in top or bottom mode -->
        <xsl:variable name="varBodyContentTop">
          <xsl:choose>
            <xsl:when test="$prmTabLayout=0">
              <xsl:choose>
                <xsl:when test="$varHasContextualTabGroups">
                  <xsl:value-of select="number($prmSeperatorHeight) + number($varTabHeaderContainerHeight)"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="number($prmSeperatorHeight) + number($prmTabHeight)"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:when>
            <xsl:otherwise>
              <xsl:choose>
                <xsl:when test="$prmBottomFrameHeight>0 and not($varIsCollapsed)">
                  <xsl:value-of select="$prmBottomFrameHeight"/>
                </xsl:when>
                <xsl:otherwise>0</xsl:otherwise>
              </xsl:choose>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:variable>

        <xsl:variable name="varBodyContentBottom">
          <xsl:choose>
            <xsl:when test="$prmTabLayout=0">
              <xsl:value-of select="$prmBottomFrameHeight"/>
            </xsl:when>
            <xsl:otherwise>
              <xsl:choose>
                <xsl:when test="$varHasContextualTabGroups">
                  <xsl:value-of select="number($prmSeperatorHeight) + number($varTabHeaderContainerHeight)"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="number($prmSeperatorHeight) + number($prmTabHeight)"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:variable>

        <div id="VWGTCBC_{@Attr.Id}">
          <xsl:attribute name="style">position:absolute;width:100%;top:<xsl:value-of select="$varBodyContentTop"/>px;bottom:<xsl:value-of select="$varBodyContentBottom"/>px;<xsl:if test="$varIsCollapsed">display:none;</xsl:if></xsl:attribute>
          <xsl:if test="$prmLeftFrameWidth>0">
            <div class="{$prmLeftFrameClass}">
              <xsl:attribute name="style">position:absolute;left:0;top:0;height:100%;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageWidth" select="concat($prmLeftFrameWidth, 'px')"/>
              </xsl:call-template>
            </div>
          </xsl:if>

          <div id="VWGTCTC_{@Attr.Id}" class="{$prmCenterFrameClass}">
            <xsl:attribute name="style">position:absolute;top:0;height:100%;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;overflow:hidden;</xsl:attribute>
            <xsl:apply-templates select="." mode="modBodyContent">
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:apply-templates>
          </div>

          <xsl:if test="$prmRightFrameWidth>0">
            <div class="{$prmRightFrameClass}">
              <xsl:attribute name="style">position:absolute;right:0;top:0;height:100%;width:<xsl:value-of select="$prmRightFrameWidth"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageWidth" select="concat($prmRightFrameWidth, 'px')"/>
              </xsl:call-template>
            </div>
          </xsl:if>

          <xsl:if test="@Attr.Multiline=1">
            <xsl:call-template name="tplCallMethod">
              <xsl:with-param name="prmMethod" select="concat('mobjApp.TabControl_OnResize(',@Attr.Id,',window,false,true,',$prmTabLayout,');')"/>
            </xsl:call-template>
          </xsl:if>
        </div>

        <!-- Seperator content in bottom mode -->
        <xsl:if test="$prmSeperatorHeight>0 and $prmTabLayout=1">
          <xsl:variable name="varSeperatorBottom">
            <xsl:choose>
              <xsl:when test="$varHasContextualTabGroups">
                <xsl:value-of select="$varTabHeaderContainerHeight"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:value-of select="$prmTabHeight"/>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:variable>
          <div id="VWGTCSP_{@Attr.Id}">
            <xsl:attribute name="vwgsepheight"><xsl:value-of select="$prmSeperatorHeight"/></xsl:attribute>
            <xsl:attribute name="style">position:absolute;width:100%;height:<xsl:value-of select="$prmSeperatorHeight"/>px;bottom:<xsl:value-of select="$varSeperatorBottom"/>px;</xsl:attribute>
            <xsl:if test="$prmLeftFrameWidth>0">
              <div class="{$prmLeftSeperatorClass}">
                <xsl:attribute name="style">position:absolute;left:0;bottom:0px;height:100%;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;height:100%;</xsl:attribute>
                <xsl:call-template name="tplDrawEmptyImage"/>
              </div>
            </xsl:if>
            <div class="{$prmCenterSeperatorClass}">
              <xsl:attribute name="style">position:absolute;bottom:0px;height:100%;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;height:{$prmSeperatorHeight}px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
            <xsl:if test="$prmRightFrameWidth>0">
              <div class="{$prmRightSeperatorClass}">
                <xsl:attribute name="style">position:absolute;right:0;bottom:0px;height:100%;width:<xsl:value-of select="$prmRightFrameWidth"/>px;</xsl:attribute>
                <xsl:call-template name="tplDrawEmptyImage"/>
              </div>
            </xsl:if>
          </div>
        </xsl:if>

        <!-- Bottom frame cells in top mode -->
        <xsl:if test="$prmBottomFrameHeight>0 and $prmTabLayout=0 and not($varIsCollapsed)">
          <xsl:if test="$prmLeftFrameWidth>0">
            <div class="{$prmLeftBottomFrameClass}">
              <xsl:attribute name="style">position:absolute;left:0;bottom:0px;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
          </xsl:if>
          <div class="{$prmCenterBottomFrameClass}">
            <xsl:attribute name="style">position:absolute;bottom:0;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;</xsl:attribute>
            <xsl:call-template name="tplDrawEmptyImage"/>
          </div>
          <xsl:if test="$prmRightFrameWidth>0">
            <div class="{$prmRightBottomFrameClass}">
              <xsl:attribute name="style">position:absolute;right:0;bottom:0;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
          </xsl:if>
        </xsl:if>

        <!-- Headers in Bottom mode -->
        <xsl:if test="$prmTabLayout=1">
          <xsl:apply-templates select="." mode="modHeader">
            <xsl:with-param name="prmTabsContainerClass" select="$prmTabsBottomContainerClass"/>
            <xsl:with-param name="prmTabControlContainerClass" select="$prmTabControlContainerClass"/>
            <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
            <xsl:with-param name="prmTabLeftClass" select="$prmTabBottomLeftClass"/>
            <xsl:with-param name="prmTabCenterClass" select="$prmTabBottomCenterClass"/>
            <xsl:with-param name="prmTabRightClass" select="$prmTabBottomRightClass"/>
            <xsl:with-param name="prmTabLeftWidth" select="$prmTabBottomLeftWidth" />
            <xsl:with-param name="prmTabRightWidth" select="$prmTabBottomRightWidth" />
            <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass"/>
            <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
            <xsl:with-param name="prmHeadersOffset" select="$prmHeadersOffset"/>
            <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
            <xsl:with-param name="prmTabImageSize" select="$prmTabImageSize" />
            <xsl:with-param name="prmTabLayout" select="$prmTabLayout"/>
            <xsl:with-param name="prmHeadersRowClass" select="$prmHeadersRowClass"/>
            <xsl:with-param name="prmRightFrameWidth" select="$prmRightFrameWidth"/>
            <xsl:with-param name="prmLeftFrameWidth" select="$prmLeftFrameWidth"/>
            <xsl:with-param name="prmLeftScrollButtonWidth" select="$prmLeftScrollButtonWidth"/>
            <xsl:with-param name="prmRightScrollButtonWidth" select="$prmRightScrollButtonWidth"/>
            <xsl:with-param name="prmCloseButtonWidth" select="$prmCloseButtonWidth"/>
            <xsl:with-param name="prmExpandButtonWidth" select="$prmExpandButtonWidth"/>
            <xsl:with-param name="prmCollapseButtonWidth" select="$prmCollapseButtonWidth"/>
            <xsl:with-param name="prmLeftScrollButtonClass" select="$prmLeftScrollButtonClass"/>
            <xsl:with-param name="prmRightScrollButtonClass" select="$prmRightScrollButtonClass"/>
            <xsl:with-param name="prmCloseButtonClass" select="$prmCloseButtonClass"/>
            <xsl:with-param name="prmExpandButtonClass" select="$prmExpandButtonClass"/>
            <xsl:with-param name="prmCollapseButtonClass" select="$prmCollapseButtonClass" />
            <xsl:with-param name="prmContextualTabGroupHeight" select="$prmContextualTabGroupHeight"/>
            <xsl:with-param name="prmContextualTabGroupClass" select="$prmContextualTabGroupClass" />
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>
        </xsl:if>
      </xsl:if>

      <!-- If is stack alignment-->
      <xsl:if test="$prmTabLayout=4">
        <!-- draw top frame-->
        <xsl:if test="$prmTopFrameHeight>0">
          <xsl:if test="$prmLeftFrameWidth>0">
            <div class="{$prmLeftTopFrameClass}">
              <xsl:attribute name="style">position:absolute;left:0;top:0;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;height:<xsl:value-of select="$prmTopFrameHeight"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
          </xsl:if>
          <div id="VWGTCHC_{@Attr.Id}" dir="{$dir}" class="{$prmCenterTopFrameClass}">
            <xsl:attribute name="style">position:absolute;top:0px;height:<xsl:value-of select="$prmTopFrameHeight"/>px;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;line-height:<xsl:value-of select="$prmTopFrameHeight"/>px;</xsl:attribute>
            <xsl:apply-templates select="." mode="modHeaderContent" >
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass"/>
            </xsl:apply-templates>
          </div>
          <xsl:if test="$prmRightFrameWidth>0">
            <div class="{$prmRightTopFrameClass}">
              <xsl:attribute name="style">position:absolute;right:0;top:0;width:<xsl:value-of select="$prmRightFrameWidth"/>px;height:<xsl:value-of select="$prmTopFrameHeight"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
          </xsl:if>
        </xsl:if>

        <xsl:variable name="varNormalTabPages" select="WC:Tags.TabPage[not(@Attr.Extra='1')]"/>
        <xsl:variable name="varNormalTabPagesCount" select="count($varNormalTabPages)"/>
        <xsl:variable name="varCenterFrameBottom" select="$prmTabHeight * ($varNormalTabPagesCount + $prmHasExtra) + $prmSeperatorHeight + $prmBottomFrameHeight"/>

        <!-- draw body-->
        <xsl:if test="$prmLeftFrameWidth>0">
          <div class="{$prmLeftFrameClass}">
            <xsl:attribute name="style">position:absolute;left:0;top:<xsl:value-of select="$prmTopFrameHeight"/>px;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;bottom:<xsl:value-of select="$varCenterFrameBottom"/>px;</xsl:attribute>
            <xsl:call-template name="tplDrawEmptyImage"/>
          </div>
        </xsl:if>
        <div id="VWGTCTC_{@Attr.Id}" class="{$prmCenterFrameClass}">
          <xsl:attribute name="style">position:absolute;top:<xsl:value-of select="$prmTopFrameHeight"/>px;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;bottom:<xsl:value-of select="$varCenterFrameBottom"/>px;</xsl:attribute>
          <xsl:apply-templates select="." mode="modBodyContent">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>
        </div>
        <xsl:if test="$prmRightFrameWidth>0">
          <div class="{$prmRightFrameClass}">
            <xsl:attribute name="style">position:absolute;right:0;top:<xsl:value-of select="$prmTopFrameHeight"/>px;width:<xsl:value-of select="$prmRightFrameWidth"/>px;bottom:<xsl:value-of select="$varCenterFrameBottom"/>px;</xsl:attribute>
            <xsl:call-template name="tplDrawEmptyImage"/>
          </div>
        </xsl:if>
        <xsl:variable name="varSeperatorBottom" select="$prmTabHeight * ($varNormalTabPagesCount + $prmHasExtra) + $prmBottomFrameHeight"/>
        <!-- draw seperator-->
        <xsl:if test="$prmSeperatorHeight>0">
          <xsl:if test="$prmLeftFrameWidth>0">
            <div class="{$prmLeftSeperatorClass}">
              <xsl:attribute name="style">position:absolute;left:0;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;bottom:<xsl:value-of select="$varSeperatorBottom"/>px;height:<xsl:value-of select="$prmSeperatorHeight"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
          </xsl:if>
          <div id="Sep_{@Attr.Id}" class="{$prmCenterSeperatorClass}">
            <xsl:attribute name="style">
              position:absolute;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;bottom:<xsl:value-of select="$varSeperatorBottom"/>px;height:<xsl:value-of select="$prmSeperatorHeight"/>px;
            </xsl:attribute>
            <xsl:apply-templates select="."  mode="modTabControlSeperatorContent">
              <xsl:with-param name="prmTabHeight" select="$prmTabHeight" />
            </xsl:apply-templates>
          </div>
          <xsl:if test="$prmRightFrameWidth>0">
            <div class="{$prmRightSeperatorClass}">
              <xsl:attribute name="style">position:absolute;right:0;width:<xsl:value-of select="$prmRightFrameWidth"/>px;bottom:<xsl:value-of select="$varSeperatorBottom"/>px;height:<xsl:value-of select="$prmSeperatorHeight"/>px;</xsl:attribute>
              <xsl:call-template name="tplDrawEmptyImage"/>
            </div>
          </xsl:if>
        </xsl:if>

        <!-- draw the tab pages headers -->
        <div id="VWGTCHD_{@Attr.Id}">
          <xsl:attribute name="style">position:absolute;width:100%;height:<xsl:value-of select="$varSeperatorBottom"/>px;bottom:<xsl:value-of select="$prmBottomFrameHeight"/>px;</xsl:attribute>
          <xsl:for-each select="$varNormalTabPages">
            <xsl:variable name="varTabPagePosition" select="count(preceding-sibling::WC:Tags.TabPage[not(@Attr.Extra='1')])+1" />
            <xsl:variable name="varTabPageBottom" select="$prmTabHeight * ($varNormalTabPagesCount + $prmHasExtra - $varTabPagePosition) + $prmBottomFrameHeight"/>
            <xsl:if test="$prmLeftFrameWidth>0">
              <div class="{$prmLeftFrameClass}">
                <xsl:attribute name="style">position:absolute;left:0;height:<xsl:value-of select="$prmTabHeight"/>px;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;bottom:<xsl:value-of select="$varTabPageBottom"/>px;</xsl:attribute>
                <xsl:call-template name="tplDrawEmptyImage"/>
              </div>
            </xsl:if>
            <div>
              <xsl:attribute name="style">position:absolute;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;bottom:<xsl:value-of select="$varTabPageBottom"/>px;height:<xsl:value-of select="$prmTabHeight"/>px;</xsl:attribute>
              <xsl:apply-templates select="." mode="modHeaderContent" >
                <xsl:with-param name="prmStyle" select="'width:100%;'" />
                <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
                <xsl:with-param name="prmTabLeftClass" select="$prmTabLeftClass"/>
                <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
                <xsl:with-param name="prmTabRightClass" select="$prmTabRightClass"/>
                <xsl:with-param name="prmTabLeftWidth" select="$prmTabLeftWidth" />
                <xsl:with-param name="prmTabRightWidth" select="$prmTabRightWidth" />
                <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass"/>
                <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
                <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
                <xsl:with-param name="prmTabImageSize" select="$prmTabImageSize" />
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:apply-templates>
            </div>
            <xsl:if test="$prmRightFrameWidth>0">
              <div class="{$prmRightFrameClass}">
                <xsl:attribute name="style">position:absolute;right:0;height:<xsl:value-of select="$prmTabHeight"/>px;width:<xsl:value-of select="$prmRightFrameWidth"/>px;bottom:<xsl:value-of select="$varTabPageBottom"/>px;</xsl:attribute>
              </div>
            </xsl:if>
          </xsl:for-each>
          <xsl:if test="$prmHasExtra = 1">
            <!-- draw the extra tabs header -->
            <xsl:if test="$prmLeftFrameWidth>0">
              <div class="{$prmLeftFrameClass}">
                <xsl:attribute name="style">position:absolute;left:0;bottom:<xsl:value-of select="$prmBottomFrameHeight"/>px;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;height:<xsl:value-of select="$prmTabHeight"/>px;</xsl:attribute>
              </div>
            </xsl:if>
            <div>
              <xsl:attribute name="style">position:absolute;bottom:<xsl:value-of select="$prmBottomFrameHeight"/>px;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;height:<xsl:value-of select="$prmTabHeight"/>px;</xsl:attribute>
              <div style="height:{$prmTabHeight}px;position:relative;">
                <xsl:attribute name="class">
                  <xsl:value-of select="concat('Common-HandCursor ',$prmTabClass)"/>
                </xsl:attribute>

                <xsl:if test="$prmTabLeftWidth>0">
                  <div>
                    <xsl:attribute name="style">
                      width:<xsl:value-of select="$prmTabLeftWidth"/>px;position:absolute;top:0px;bottom:0px;<xsl:value-of select="$left"/>:0px;
                    </xsl:attribute>
                    <xsl:attribute name="class">
                      <xsl:value-of select="$prmTabLeftClass"/>;
                    </xsl:attribute>
                  </div>
                </xsl:if>
                <div id="ExtraTabsContainer_{@Id}" class="{$prmTabCenterClass}">
                  <xsl:attribute name="style">
                    <xsl:value-of select="$left"/>:<xsl:value-of select="$prmTabLeftWidth"/>px;
                    <xsl:value-of select="$right"/>:<xsl:value-of select="$prmTabRightWidth"/>px;top:0px;bottom:0px;position:absolute;/>;
                  </xsl:attribute>

                  <xsl:call-template name="tplApplyScrollableAttributes" />
                  <xsl:call-template name="tplDrawScrollbars">
                    <xsl:with-param name="prmScrollerType" select="'1'" />
                    <xsl:with-param name="prmScrollbars" select="'H'" />
                    <xsl:with-param name="prmArrowsBaseClass" select="$prmArrowsBaseClass" />
                    <xsl:with-param name="prmTopArrowThickness" select="$prmTopArrowThickness" />
                    <xsl:with-param name="prmRightArrowThickness" select="$prmRightArrowThickness" />
                    <xsl:with-param name="prmBottomArrowThickness" select="$prmBottomArrowThickness" />
                    <xsl:with-param name="prmLeftArrowThickness" select="$prmLeftArrowThickness" />
                    <xsl:with-param name="prmHorizontalHoverSpeed" select="$prmHorizontalHoverSpeed" />
                    <xsl:with-param name="prmHorizontalDownSpeed" select="$prmHorizontalDownSpeed" />
                    <xsl:with-param name="prmVerticalHoverSpeed" select="$prmVerticalHoverSpeed" />
                    <xsl:with-param name="prmVerticalDownSpeed" select="$prmVerticalDownSpeed" />
                  </xsl:call-template>

                  <div>
                    <xsl:attribute name="style">
                      <xsl:apply-templates select="." mode="modTabControlExtraHeadersContainerStyle">
                        <xsl:with-param name="prmTabLeftWidth" select="$prmExtraTabLeftWidth" />
                        <xsl:with-param name="prmTabRightWidth" select="$prmExtraTabRightWidth" />
                        <xsl:with-param name="prmTabPagesCount" select="count(WC:Tags.TabPage[@Attr.Extra='1'])" />
                      </xsl:apply-templates>;height:100%;
                    </xsl:attribute>

                    <xsl:apply-templates select="WC:Tags.TabPage[@Attr.Extra='1']" mode="modHeaderContent">
                      <xsl:with-param name="prmStyle" select="'width:100%;'" />
                      <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
                      <xsl:with-param name="prmTabLeftClass" select="$prmExtraTabLeftClass"/>
                      <xsl:with-param name="prmTabCenterClass" select="$prmExtraTabCenterClass"/>
                      <xsl:with-param name="prmTabRightClass" select="$prmExtraTabRightClass"/>
                      <xsl:with-param name="prmTabLeftWidth" select="$prmExtraTabLeftWidth" />
                      <xsl:with-param name="prmTabRightWidth" select="$prmExtraTabRightWidth" />
                      <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass"/>
                      <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
                      <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
                      <xsl:with-param name="prmTabImageSize" select="$prmTabImageSize" />
                      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                    </xsl:apply-templates>
                  </div>
                </div>
                <xsl:if test="$prmTabRightWidth>0">
                  <div class="{$prmTabRightClass}" style="position:absolute;top:0px;bottom:0px;{$right}:0px;width:{$prmTabRightWidth}px;">
                  </div>
                </xsl:if>
              </div>
            </div>
            <xsl:if test="$prmRightFrameWidth>0">
              <div class="{$prmRightFrameClass}">
                <xsl:attribute name="style">position:absolute;right:0;bottom:<xsl:value-of select="$prmBottomFrameHeight"/>px;width:<xsl:value-of select="$prmRightFrameWidth"/>px;height:<xsl:value-of select="$prmTabHeight"/>px;</xsl:attribute>
              </div>
            </xsl:if>
          </xsl:if>
        </div>

        <!-- draw bottom frame-->
        <xsl:if test="$prmBottomFrameHeight>0">
          <xsl:if test="$prmLeftFrameWidth>0">
            <div class="{$prmLeftBottomFrameClass}">
              <xsl:attribute name="style">position:absolute;left:0;bottom:0;width:<xsl:value-of select="$prmLeftFrameWidth"/>px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;</xsl:attribute>
            </div>
          </xsl:if>
          <div class="{$prmCenterBottomFrameClass}">
            <xsl:attribute name="style">position:absolute;bottom:0px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;left:<xsl:value-of select="$prmLeftFrameWidth"/>px;right:<xsl:value-of select="$prmRightFrameWidth"/>px;height:{$prmBottomFrameHeight}px;</xsl:attribute>
          </div>
          <xsl:if test="$prmRightFrameWidth>0">
            <div class="{$prmRightBottomFrameClass}">
              <xsl:attribute name="style">position:absolute;right:0;bottom:0;width:<xsl:value-of select="$prmRightFrameWidth"/>px;height:<xsl:value-of select="$prmBottomFrameHeight"/>px;</xsl:attribute>
            </div>
          </xsl:if>
        </xsl:if>
      </xsl:if>

      <!-- If is logical mode alignment-->
      <xsl:if test="$prmTabLayout=-1">
        <div id="VWGTCTC_{@Attr.Id}" style="height:100%;width:100%">
          <xsl:apply-templates select="." mode="modBodyContent">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>
        </div>
      </xsl:if>
    </div>
  </xsl:template>

  <!-- API for drawing the control header content and The default style TabControl header content match template -->
  <xsl:template name="tplDrawTabControlHeaderContentAPI" match="WC:Tags.TabControl[not(@Attr.Appearance='32')]" mode="modHeaderContent">
    <xsl:param name="prmTabHeaderTextClass" select="'TabControl-PageHeaderText'"/>
    <span class="nobr">
      <!-- For the NavigationTabs control header-->
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyFontStyles"/>
      </xsl:attribute>
      <span class="{$prmTabHeaderTextClass}" id="TXTH_{@Id}">
        <xsl:call-template name="tplDecodeTextAsHtml">
          <xsl:with-param name="prmText" select="WC:Tags.TabPage[@Id=../@Attr.Selected]/@Attr.Text"/>
        </xsl:call-template>
      </span>
    </span>
  </xsl:template>

  <!-- The default style TabControl body content match template -->
  <xsl:template name="tplDrawTabControlBodyContentAPI"  match="WC:Tags.TabControl[not(@Attr.Appearance='32')]" mode="modBodyContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:apply-templates select="WC:Tags.TabPage[@Id=../@Attr.Selected]"  mode="modBodyContent">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:apply-templates>
    <xsl:if test="@Attr.ClientUpdateHandler">
      <xsl:apply-templates select="WC:Tags.TabPage[not(@Id=../@Attr.Selected)]"  mode="modBodyContent">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>
    </xsl:if>
  </xsl:template>

  <!-- Draws the tab page header content -->
  <xsl:template name="tplDrawTabPageHeaderContentAPI" match="WC:Tags.TabPage[not(../@Attr.Appearance='32')]" mode="modHeaderContent">
    <xsl:param name="prmStyle"/>
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabLeftClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabRightClass"/>
    <xsl:param name="prmTabLeftWidth" select="'0'"/>
    <xsl:param name="prmTabRightWidth" select="0"/>
    <xsl:param name="prmTabHeaderTextClass" />
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmTabDivContainer" />
    <xsl:param name="prmTabImageSize"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varMultiline" select="../@Attr.Multiline" />

    <div id="TAB_{@Id}" onclick="mobjApp.TabControl_ChangeTab('{@Id}',window,event,false)">
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyFontStyles">
          <xsl:with-param name="prmTarget" select="./.."/>
        </xsl:call-template>
        <xsl:value-of select="$prmStyle" />
        <xsl:if test="$varMultiline = '1'">
          float:<xsl:value-of select="$left" />;
        </xsl:if>
        height:<xsl:value-of select="$prmTabHeight"/>px;
        overflow:hidden;
      </xsl:attribute>

      <xsl:if test="@Attr.HeaderToolTip">
        <xsl:attribute name="title">
          <xsl:value-of select="@Attr.HeaderToolTip" />
        </xsl:attribute>
      </xsl:if>

      <xsl:variable name="varSelectOnRightClick" select="ancestor::WC:Tags.TabControl[1]/@Attr.SelectOnRightClick"/>

      <xsl:if test="not(../@Attr.Expanded='0') and @Id=../@Attr.Selected">
        <xsl:attribute name="class">
          <xsl:value-of select="concat($prmTabDivContainer,' ',$prmTabClass,' ',$prmTabClass,'_Selected')"/>
        </xsl:attribute>
        <xsl:attribute name="data-vwgsuspendmouseevents">1</xsl:attribute>
      </xsl:if>
      <xsl:if test="(../@Attr.Expanded='0') or not(@Id=../@Attr.Selected)">
        <xsl:attribute name="class">
          <xsl:value-of select="concat($prmTabDivContainer,' ','Common-HandCursor ',$prmTabClass)"/>
        </xsl:attribute>
      </xsl:if>

      <xsl:if test="$varSelectOnRightClick='1'">
        <xsl:attribute name="oncontextmenu">mobjApp.TabControl_ChangeTab('<xsl:value-of select="@Attr.Id"/>', window, event, true);</xsl:attribute>
      </xsl:if>
      <xsl:if test="$prmIsEnabled">
        <xsl:call-template name="tplSetMouseEvents">
          <xsl:with-param name="prmHandler" select="'mobjApp.TabControl_HandleMouseEvents'"/>
        </xsl:call-template>
      </xsl:if>
      <div dir="ltr" style="white-space:nowrap;height:100%;">
        <xsl:if test="$prmTabLeftWidth>0">
          <div  class="{$prmTabClass} {$prmTabLeftClass}" style="width:{$prmTabLeftWidth}px;height:100%;float:left;">
            <xsl:call-template name="tplDrawEmptyImage">
              <xsl:with-param name="prmImageHeight" select="concat($prmTabHeight, 'px')"/>
              <xsl:with-param name="prmImageWidth" select="concat($prmTabLeftWidth, 'px')"/>
            </xsl:call-template>
          </div>
        </xsl:if>
        <div  class="{$prmTabClass} {$prmTabCenterClass}" dir="{$dir}">
          <xsl:attribute name="style">overflow:hidden; height:100%;float:left;</xsl:attribute>
          <span class="nobr">
            <xsl:if test="@Attr.Image">
              <img class="Common-VAlignMiddle {$prmTabImageSize}" id="IMG_{@Id}" src="{@Attr.Image}" alt="{@Attr.Text}"/>&#160;
            </xsl:if>
            <span class="{$prmTabHeaderTextClass}" id="TXT_{@Id}">
              <xsl:attribute name="style">
                <xsl:call-template name="tplHeaderStyle"/>
              </xsl:attribute>
              <xsl:call-template name="tplDecodeTextAsHtml"/>
            </span>
          </span>
        </div>
        <xsl:if test="$prmTabRightWidth>0">
          <div  class="{$prmTabClass} {$prmTabRightClass}" style="width:{$prmTabRightWidth}px;height:100%;float:left;">
            <xsl:call-template name="tplDrawEmptyImage">
              <xsl:with-param name="prmImageHeight" select="concat($prmTabHeight, 'px')"/>
              <xsl:with-param name="prmImageWidth" select="concat($prmTabRightWidth, 'px')"/>
            </xsl:call-template>
          </div>
        </xsl:if>
      </div>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawTabControlNonSpreadHeader" match="WC:Tags.TabControl[not(@Attr.Appearance='32')]"  mode="modHeader">
    <xsl:param name="prmTabsContainerClass"/>
    <xsl:param name="prmTabControlContainerClass"/>
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabLeftClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabRightClass"/>
    <xsl:param name="prmTabLeftWidth"/>
    <xsl:param name="prmTabRightWidth"/>
    <xsl:param name="prmTabHeaderTextClass"/>
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmHeadersOffset"/>
    <xsl:param name="prmTabDivContainer"/>
    <xsl:param name="prmTabImageSize"/>
    <xsl:param name="prmTabLayout"/>
    <xsl:param name="prmHeadersRowClass"/>
    <xsl:param name="prmRightFrameWidth"/>
    <xsl:param name="prmLeftFrameWidth"/>
    <xsl:param name="prmLeftScrollButtonWidth"/>
    <xsl:param name="prmRightScrollButtonWidth"/>
    <xsl:param name="prmCloseButtonWidth"/>
    <xsl:param name="prmExpandButtonWidth"/>
    <xsl:param name="prmCollapseButtonWidth"/>
    <xsl:param name="prmLeftScrollButtonClass"/>
    <xsl:param name="prmRightScrollButtonClass"/>
    <xsl:param name="prmCloseButtonClass"/>
    <xsl:param name="prmExpandButtonClass"/>
    <xsl:param name="prmCollapseButtonClass"/>
    <xsl:param name="prmContextualTabGroupHeight"/>
    <xsl:param name="prmContextualTabGroupClass"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawTabControlHeader">
      <xsl:with-param name="prmTabsContainerClass" select="$prmTabsContainerClass"/>
      <xsl:with-param name="prmTabControlContainerClass" select="$prmTabControlContainerClass"/>
      <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
      <xsl:with-param name="prmTabLeftClass" select="$prmTabLeftClass"/>
      <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
      <xsl:with-param name="prmTabRightClass" select="$prmTabRightClass"/>
      <xsl:with-param name="prmTabLeftWidth" select="$prmTabLeftWidth" />
      <xsl:with-param name="prmTabRightWidth" select="$prmTabRightWidth" />
      <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
      <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
      <xsl:with-param name="prmHeadersOffset" select="$prmHeadersOffset"/>
      <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
      <xsl:with-param name="prmTabImageSize" select="$prmTabImageSize" />
      <xsl:with-param name="prmTabLayout" select="$prmTabLayout"/>
      <xsl:with-param name="prmHeadersRowClass" select="$prmHeadersRowClass"/>
      <xsl:with-param name="prmRightFrameWidth" select="$prmRightFrameWidth"/>
      <xsl:with-param name="prmLeftFrameWidth" select="$prmLeftFrameWidth"/>
      <xsl:with-param name="prmLeftScrollButtonWidth" select="$prmLeftScrollButtonWidth"/>
      <xsl:with-param name="prmRightScrollButtonWidth" select="$prmRightScrollButtonWidth"/>
      <xsl:with-param name="prmCloseButtonWidth" select="$prmCloseButtonWidth"/>
      <xsl:with-param name="prmExpandButtonWidth" select="$prmExpandButtonWidth"/>
      <xsl:with-param name="prmCollapseButtonWidth" select="$prmCollapseButtonWidth"/>
      <xsl:with-param name="prmLeftScrollButtonClass" select="$prmLeftScrollButtonClass"/>
      <xsl:with-param name="prmRightScrollButtonClass" select="$prmRightScrollButtonClass"/>
      <xsl:with-param name="prmCloseButtonClass" select="$prmCloseButtonClass"/>
      <xsl:with-param name="prmExpandButtonClass" select="$prmExpandButtonClass"/>
      <xsl:with-param name="prmCollapseButtonClass" select="$prmCollapseButtonClass" />
      <xsl:with-param name="prmContextualTabGroupHeight" select="$prmContextualTabGroupHeight"/>
      <xsl:with-param name="prmContextualTabGroupClass" select="$prmContextualTabGroupClass" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Draws the tab control headers in top/bottom mode -->
  <xsl:template name="tplDrawTabControlHeader">
    <xsl:param name="prmTabsContainerClass"/>
    <xsl:param name="prmTabControlContainerClass" />
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabLeftClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabRightClass"/>
    <xsl:param name="prmTabLeftWidth"/>
    <xsl:param name="prmTabRightWidth"/>
    <xsl:param name="prmTabHeaderTextClass"/>
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmHeadersOffset"/>
    <xsl:param name="prmTabDivContainer"/>
    <xsl:param name="prmTabImageSize"/>
    <xsl:param name="prmTabLayout"/>
    <xsl:param name="prmHeadersRowClass"/>
    <xsl:param name="prmRightFrameWidth"/>
    <xsl:param name="prmLeftFrameWidth"/>
    <xsl:param name="prmLeftScrollButtonWidth"/>
    <xsl:param name="prmRightScrollButtonWidth"/>
    <xsl:param name="prmCloseButtonWidth"/>
    <xsl:param name="prmExpandButtonWidth"/>
    <xsl:param name="prmCollapseButtonWidth"/>
    <xsl:param name="prmLeftScrollButtonClass"/>
    <xsl:param name="prmRightScrollButtonClass"/>
    <xsl:param name="prmCloseButtonClass"/>
    <xsl:param name="prmExpandButtonClass"/>
    <xsl:param name="prmCollapseButtonClass"/>
    <xsl:param name="prmContextualTabGroupHeight"/>
    <xsl:param name="prmContextualTabGroupClass"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varTabHeaderContainerHeight" select="number($prmContextualTabGroupHeight) + number($prmTabHeight)"/>
    <xsl:variable name="varHasContextualTabGroups" select="count(Tags.Group) &gt; 0"/>

    <xsl:variable name="varExpandButtonWidth">
      <xsl:choose>
        <xsl:when test="not(@Attr.Expanded='0')">
          <xsl:value-of select="$prmExpandButtonWidth"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="$prmCollapseButtonWidth"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varHeaderPosition">
      <xsl:choose>
        <xsl:when test="$prmTabLayout='0'">top</xsl:when>
        <xsl:otherwise>bottom</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <div id="VWGTCHD_{@Attr.Id}">
      <xsl:attribute name="style">position:absolute;<xsl:value-of select="$varHeaderPosition"/>:0px;position:absulote;width:100%;
        <xsl:if test="not(@Attr.Multiline = '1')">
          height:
          <xsl:choose>
            <xsl:when test="$varHasContextualTabGroups"><xsl:value-of select="$varTabHeaderContainerHeight"/>px;</xsl:when>
            <xsl:otherwise><xsl:value-of select="$prmTabHeight"/>px;</xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:attribute>
      <xsl:attribute name="class">
        <xsl:value-of select="$prmHeadersRowClass"/>
      </xsl:attribute>
      <div style="width:100%; height:100%;">
        <table dir="{$dir}" class="Common-CellSpacing0 Common-CellPadding0">
          <xsl:attribute name="style">
            width:100%; height:100%;
            <xsl:if test="not(@Attr.Multiline = '1')">
              table-layout:fixed
            </xsl:if>
          </xsl:attribute>
          <colgroup>
            <xsl:choose>
              <xsl:when test="not(@Attr.Multiline = '1')">
                <col style="width:100%"/>
              </xsl:when>
              <xsl:otherwise>
                <col/>
              </xsl:otherwise>
            </xsl:choose>
            <xsl:if test="not(@Attr.Multiline = '1')">
              <col style="width:{$prmLeftScrollButtonWidth}px"/>
              <col style="width:{$prmRightScrollButtonWidth}px"/>
            </xsl:if>
            <xsl:if test="@Attr.ExpansionIndicator='1'">
              <col style="width:{$varExpandButtonWidth}px"/>
            </xsl:if>
            <xsl:if test="@Attr.ShowCloseButton='1'">
              <col style="width:{$prmCloseButtonWidth}px"/>
            </xsl:if>
          </colgroup>
          <tr>
            <td>
              <xsl:call-template name="tplDrawTabControlHeaders" >
                <xsl:with-param name="prmTabsContainerClass" select="$prmTabsContainerClass"/>
                <xsl:with-param name="prmTabControlContainerClass" select="$prmTabControlContainerClass"/>
                <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
                <xsl:with-param name="prmTabLeftClass" select="$prmTabLeftClass"/>
                <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
                <xsl:with-param name="prmTabRightClass" select="$prmTabRightClass"/>
                <xsl:with-param name="prmTabLeftWidth" select="$prmTabLeftWidth" />
                <xsl:with-param name="prmTabRightWidth" select="$prmTabRightWidth" />
                <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
                <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
                <xsl:with-param name="prmHeadersOffset" select="$prmHeadersOffset"/>
                <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
                <xsl:with-param name="prmTabImageSize" select="$prmTabImageSize" />
                <xsl:with-param name="prmTabLayout" select="$prmTabLayout"/>
                <xsl:with-param name="prmContextualTabGroupHeight" select="$prmContextualTabGroupHeight" />
                <xsl:with-param name="prmContextualTabGroupClass" select="$prmContextualTabGroupClass"/>
                <xsl:with-param name="prmTabHeaderContainerHeight" select="$varTabHeaderContainerHeight" />
                <xsl:with-param name="prmHasContextualTabGroups" select="$varHasContextualTabGroups"/>
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>
            </td>
            <xsl:variable name="varHeaderHeight">
              <xsl:choose>
                <xsl:when test="$varHasContextualTabGroups">
                  <xsl:value-of select="$varTabHeaderContainerHeight"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="$prmTabHeight"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:variable>
            <xsl:if test="not(@Attr.Multiline = '1')">
              <td onclick="return true;"
                onmousedown="mobjApp.TabControl_StartScroll(mobjApp.Web_GetElementById('VWGScrollable_{@Id}',window),-({30-number($dir='RTL')*60}),10,1,window,event);"
                onmouseleave="mobjApp.TabControl_StopScroll()"
                onmouseup="mobjApp.TabControl_StopScroll()">
                <xsl:attribute name="class">
                  <xsl:value-of select="$prmTabsContainerClass"/>
                </xsl:attribute>
                <xsl:attribute name="style">
                  height:<xsl:value-of select="$varHeaderHeight"/>px;padding:0;
                </xsl:attribute>
                <div style="width:100%;height:100%;font-size:xx-small; visibility:hidden;" id="VWG_NavigatePrev_{@Id}"  class="{$prmLeftScrollButtonClass}">
                  <xsl:call-template name="tplSetHighlight" >
                    <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                  </xsl:call-template>
                </div>
                <xsl:call-template name="tplCallMethod">
                  <xsl:with-param name="prmMethod" select="concat('mobjApp.TabControl_OnResize(',@Attr.Id,',window,false,false,',$prmTabLayout,');')"/>
                </xsl:call-template>
              </td>
              <td onclick="return true;"
                  onmousedown="mobjApp.TabControl_StartScroll(mobjApp.Web_GetElementById('VWGScrollable_{@Id}',window),({30-number($dir='RTL')*60}),10,1,window,event);"
                  onmouseleave="mobjApp.TabControl_StopScroll()"
                  onmouseup="mobjApp.TabControl_StopScroll()">
                <xsl:attribute name="class">
                  <xsl:value-of select="$prmTabsContainerClass"/>
                </xsl:attribute>
                <xsl:attribute name="style">height:<xsl:value-of select="$varHeaderHeight"/>px;padding:0;</xsl:attribute>
                <div style="width:100%;height:100%;font-size:xx-small; visibility:hidden;"  id="VWG_NavigateNext_{@Id}"  class="{$prmRightScrollButtonClass}">
                  <xsl:call-template name="tplSetHighlight" >
                    <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                  </xsl:call-template>
                </div>
                <xsl:call-template name="tplCallMethod">
                  <xsl:with-param name="prmMethod" select="concat('mobjApp.TabControl_OnResize(',@Attr.Id,',window,false,false,',$prmTabLayout,');')"/>
                </xsl:call-template>
              </td>
            </xsl:if>
            <xsl:if test="@Attr.ExpansionIndicator='1'">
              <td id="VWGTCET_{@Attr.Id}" onclick="mobjApp.TabControl_ExpandToggle('{@Id}',window,event)">
                <xsl:attribute name="class">
                  <xsl:value-of select="$prmTabsContainerClass"/>
                </xsl:attribute>
                <xsl:attribute name="style">height:<xsl:value-of select="$varHeaderHeight"/>px;padding:0;</xsl:attribute>
                <xsl:variable name="varExpandButtonClass">
                  <xsl:choose>
                    <!--check if the tab control is expand-->
                    <xsl:when test="not(@Attr.Expanded='0')">
                      <xsl:choose>
                        <!--check if tab layout is up-->
                        <xsl:when test="$prmTabLayout='0'">
                          <!--render collapse class-->
                          <xsl:value-of select="$prmCollapseButtonClass"/>
                        </xsl:when>
                        <!--tab layout is bottom-->
                        <xsl:otherwise>
                          <!--render expand class-->
                          <xsl:value-of select="$prmExpandButtonClass"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </xsl:when>
                    <!--tab control is collapsed-->
                    <xsl:otherwise>
                      <xsl:choose>
                        <!--check if tab layout is up-->
                        <xsl:when test="$prmTabLayout='0'">
                          <!--render expand class-->
                          <xsl:value-of select="$prmExpandButtonClass"/>
                        </xsl:when>
                        <!--tab layout is bottom-->
                        <xsl:otherwise>
                          <!--render collapse class-->
                          <xsl:value-of select="$prmCollapseButtonClass"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:variable>
                <div>
                  <xsl:attribute name="style">width:100%;height:100%</xsl:attribute>
                  <xsl:attribute name="class">
                    <xsl:value-of select="$varExpandButtonClass"/>
                  </xsl:attribute>
                  <xsl:call-template name="tplSetHighlight" >
                    <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                  </xsl:call-template>
                </div>
              </td>
            </xsl:if>
            <xsl:if test="@Attr.ShowCloseButton='1'">
              <td onclick="mobjApp.TabControl_CloseTab('{@Id}',event)">
                <xsl:attribute name="class">
                  <xsl:value-of select="$prmTabsContainerClass"/>
                </xsl:attribute>
                <xsl:attribute name="style">height:<xsl:value-of select="$varHeaderHeight"/>px;padding:0;</xsl:attribute>
                <div style="width:100%;height:100%" class="{$prmCloseButtonClass}">
                  <xsl:call-template name="tplSetHighlight" >
                    <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                  </xsl:call-template>
                </div>
              </td>
            </xsl:if>
          </tr>
        </table>
      </div>
    </div>
  </xsl:template>

  <!-- Draws the tab control headers in floating mode -->
  <xsl:template name="tplDrawTabControlHeaders">
    <xsl:param name="prmTabsContainerClass"/>
    <xsl:param name="prmTabControlContainerClass" />
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabLeftClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabRightClass"/>
    <xsl:param name="prmTabLeftWidth"/>
    <xsl:param name="prmTabRightWidth"/>
    <xsl:param name="prmTabHeaderTextClass" />
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmHeadersOffset"/>
    <xsl:param name="prmTabDivContainer"/>
    <xsl:param name="prmTabImageSize"/>
    <xsl:param name="prmTabLayout"/>
    <xsl:param name="prmContextualTabGroupHeight"/>
    <xsl:param name="prmContextualTabGroupClass" />
    <xsl:param name="prmTabHeaderContainerHeight" />
    <xsl:param name="prmHasContextualTabGroups" />
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varIsMultiline" select="@Attr.Multiline = '1'"/>
    <xsl:variable name="varHeaderHeight">
      <xsl:choose>
        <xsl:when test="$prmHasContextualTabGroups">
          <xsl:value-of select="$prmTabHeaderContainerHeight"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="$prmTabHeight"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:if test="not($varIsMultiline)">
      <xsl:call-template name="tplCompleteScrollCapabilities"/>
    </xsl:if>
    <div id="VWGScrollable_{@Id}"  class="Common-Unselectable {$prmTabsContainerClass} " >
      <xsl:attribute name="style">line-height:0px;overflow:hidden;width:100%;<xsl:if test="not($varIsMultiline)">height:<xsl:value-of select="$varHeaderHeight"/>px;</xsl:if></xsl:attribute>

      <xsl:attribute name="onresize">mobjApp.TabControl_OnResize(<xsl:value-of select="@Attr.Id"/>,window,false,<xsl:value-of select="$varIsMultiline"/>,<xsl:value-of select="$prmTabLayout"/>)</xsl:attribute>
      <xsl:if test="not($varIsMultiline)"><xsl:call-template name="tplApplyScrollableAttributes" /><xsl:call-template name="tplRestoreScroll" /></xsl:if>
      <div class="{$prmTabControlContainerClass} Common-Unselectable" dir="{$dir}">
        <xsl:attribute name="style">
          <xsl:if test="$varIsMultiline">height:100%;</xsl:if>
          <xsl:if test="not($varIsMultiline)">height:<xsl:value-of select="$varHeaderHeight"/>px;white-space:nowrap;</xsl:if>
        </xsl:attribute>
        <xsl:variable name="varHeadersOffset">
          <xsl:choose>
            <xsl:when test="@Attr.HeadersOffset">
              <xsl:value-of select="@Attr.HeadersOffset"/>
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="$prmHeadersOffset"/>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:variable>
        <xsl:if test="not($varHeadersOffset = 0) and not($varIsMultiline)">
          <div style="width:{$varHeadersOffset}px;height:{$prmTabHeight}px;">
            <img src="[Skin.Path]Empty.gif.wgx" style="position:absolute;width:1px;height:1px;top:0px;left:0px;" alt=""/>
          </div>
        </xsl:if>
        <xsl:choose>
          <xsl:when test="$prmHasContextualTabGroups">
            <xsl:for-each select="WC:Tags.TabPage[not(@Attr.ContextualTabGroup) or @Attr.ContextualTabGroup='']">
              <xsl:call-template name="tplContextualTabGroup">
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
                <xsl:with-param name="prmTabLayout" select="$prmTabLayout" />
                <xsl:with-param name="prmTabPages" select="." />
                <xsl:with-param name="prmContextualTabGroupHeight" select="$prmContextualTabGroupHeight" />
                <xsl:with-param name="prmTabHeaderContainerHeight" select="$prmTabHeaderContainerHeight" />
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>
            </xsl:for-each>
            <xsl:for-each select="Tags.Group">
              <xsl:variable name="varIndex" select="@Attr.Index"/>
              <xsl:variable name="varTabPages" select="../WC:Tags.TabPage[@Attr.ContextualTabGroup=$varIndex]"  migration-select="this.xpath(&quot;../WC:Tags.TabPage[@Attr.ContextualTabGroup = '&quot; + varIndex + &quot;']&quot;)"/>
              <xsl:variable name="varTabPagesCount" select="count($varTabPages)"/>
              <xsl:if test="$varTabPagesCount &gt; 0">
                <xsl:call-template name="tplContextualTabGroup">
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
                  <xsl:with-param name="prmTabLayout" select="$prmTabLayout" />
                  <xsl:with-param name="prmTabPages" select="$varTabPages" />
                  <xsl:with-param name="prmContextualTabText" select="@Attr.Text" />
                  <xsl:with-param name="prmContextualTabGroupHeight" select="$prmContextualTabGroupHeight" />
                  <xsl:with-param name="prmContextualTabGroupClass" select="$prmContextualTabGroupClass" />
                  <xsl:with-param name="prmTabHeaderContainerHeight" select="$prmTabHeaderContainerHeight" />
                  <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                </xsl:call-template>
              </xsl:if>
            </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
            <xsl:apply-templates select="." mode="modPagesHeaderContent">
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
          </xsl:otherwise>
        </xsl:choose>
      </div>
    </div>

    <xsl:if test="not($varIsMultiline)">
      <xsl:variable name="varSelectedTabId" select="@Attr.Selected"/>
      <xsl:if test="$varSelectedTabId and not($varSelectedTabId='')">
        <xsl:call-template name="tplCallMethod">
          <xsl:with-param name="prmMethod" select="concat('mobjApp.TabControl_ScrollIntoView(window,',$varSelectedTabId,',',@Attr.Id,',2);')"/>
        </xsl:call-template>
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDrawPagesHeaderContent" match="WC:Tags.TabControl[not(../@Attr.Appearance='32')]" mode="modPagesHeaderContent">
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

    <xsl:for-each select="WC:Tags.TabPage">
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
    </xsl:for-each>
  </xsl:template>

  <!-- Draws the contextual tab group and its tabs headers -->
  <xsl:template name="tplContextualTabGroup">
    <xsl:param name="prmStyle"/>
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabLeftClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabRightClass"/>
    <xsl:param name="prmTabLeftWidth"/>
    <xsl:param name="prmTabRightWidth"/>
    <xsl:param name="prmTabHeaderTextClass"/>
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmTabDivContainer" />
    <xsl:param name="prmTabImageSize"/>
    <xsl:param name="prmTabLayout"/>
    <xsl:param name="prmContextualTabText" select ="''"/>
    <xsl:param name="prmTabPages"/>
    <xsl:param name="prmContextualTabGroupHeight"/>
    <xsl:param name="prmContextualTabGroupClass" />
    <xsl:param name="prmTabHeaderContainerHeight" />
    <xsl:param name="prmIsEnabled" />

    <div>
      <xsl:attribute name="style">height:<xsl:value-of select="$prmTabHeaderContainerHeight"/>px;</xsl:attribute>
      <table style="table-layout:auto;" class="Common-CellSpacing0 Common-CellPadding0 Common-Table">
        <xsl:if test="$prmTabLayout=1">
          <tr>
            <td>
              <xsl:attribute name="style">height:<xsl:value-of select="$prmTabHeight"/>px;</xsl:attribute>
              <xsl:for-each select="$prmTabPages">
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
              </xsl:for-each>
            </td>
          </tr>
        </xsl:if>
        <tr>
          <td>
            <xsl:attribute name="style">width:100%;height:<xsl:value-of select="$prmContextualTabGroupHeight"/>px;</xsl:attribute>
            <xsl:if test="$prmContextualTabText!=''">
              <xsl:attribute name="class">Common-AlignCenter Common-VAlignMiddle Common-FontData <xsl:value-of select="$prmContextualTabGroupClass"></xsl:value-of></xsl:attribute>
              <xsl:attribute name="onclick">mobjApp.TabControl_ChangeTab('<xsl:value-of select="$prmTabPages[1]/@Attr.Id"  migration-select="prmTabPages.xposition(1).attr(&quot;Attr.Id&quot;)" />',window,event,false);</xsl:attribute>
              <span class="nobr">
                <xsl:call-template name="tplDecodeTextAsHtml">
                  <xsl:with-param name="prmText" select="$prmContextualTabText"/>
                </xsl:call-template>
              </span>
            </xsl:if>
          </td>
        </tr>
        <xsl:if test="$prmTabLayout=0">
          <tr>
            <td>
              <xsl:attribute name="style">height:<xsl:value-of select="$prmTabHeight"/>px;</xsl:attribute>
              <xsl:for-each select="$prmTabPages">
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
              </xsl:for-each>
            </td>
          </tr>
        </xsl:if>
      </table>
    </div>
  </xsl:template>

  <!-- Apply Font Styles to the headers according to parent and page specifications -->
  <xsl:template name="tplHeaderStyle">

    <!-- Set ForeColor if defined, if not take from parent control. -->
    <xsl:variable name="varForeColor">
      <xsl:choose>
        <xsl:when test="@Attr.Fore">
          <xsl:value-of select="@Attr.Fore"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="./../@Attr.Fore"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <!-- Set Font if defined, if not take from parent control. -->
    <xsl:variable name="varFont">
      <xsl:choose>
        <xsl:when test="@Attr.Font">
          <xsl:value-of select="@Attr.Font"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="./../@Attr.Font"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:call-template name="tplApplyFontStyles">
      <xsl:with-param name="prmFont" select="$varFont"/>
      <xsl:with-param name="prmForeColor" select="$varForeColor"/>
    </xsl:call-template>

  </xsl:template>

  <!--Spread Appearance templates-->
  <xsl:template match="WC:Tags.TabControl[@Attr.Appearance='32']" mode="modContent">
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
      <xsl:with-param name="prmTabHeaderTextClass" select="'TabControl-PageHeaderText'" />

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

      <xsl:with-param name="prmLeftScrollButtonWidth" select="'[Skin.LeftScrollButtonWidth]px'" />
      <xsl:with-param name="prmRightScrollButtonWidth" select="'[Skin.RightScrollButtonWidth]px'" />
      <xsl:with-param name="prmCloseButtonWidth" select="'[Skin.CloseButtonWidth]px'" />
      <xsl:with-param name="prmExpandButtonWidth" select="[Skin.ExpandButtonWidth]" />
      <xsl:with-param name="prmCollapseButtonWidth" select="[Skin.CollapseButtonWidth]" />
      <xsl:with-param name="prmTabImageSize" select="'TabControlSpread-ImageSize'" />
      <xsl:with-param name="prmContextualTabGroupHeight" select="'0'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawTabControlSpreadHeader" match="WC:Tags.TabControl[@Attr.Appearance='32']"  mode="modHeader">
    <xsl:param name="prmTabsContainerClass"/>
    <xsl:param name="prmTabControlContainerClass"/>
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabLeftClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabRightClass"/>
    <xsl:param name="prmTabLeftWidth"/>
    <xsl:param name="prmTabRightWidth"/>
    <xsl:param name="prmTabHeaderTextClass"/>
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmHeadersOffset"/>
    <xsl:param name="prmTabDivContainer"/>
    <xsl:param name="prmTabImageSize"/>
    <xsl:param name="prmTabLayout"/>
    <xsl:param name="prmHeadersRowClass"/>
    <xsl:param name="prmRightFrameWidth"/>
    <xsl:param name="prmLeftFrameWidth"/>
    <xsl:param name="prmLeftScrollButtonWidth"/>
    <xsl:param name="prmRightScrollButtonWidth"/>
    <xsl:param name="prmCloseButtonWidth"/>
    <xsl:param name="prmExpandButtonWidth"/>
    <xsl:param name="prmCollapseButtonWidth"/>
    <xsl:param name="prmLeftScrollButtonClass"/>
    <xsl:param name="prmRightScrollButtonClass"/>
    <xsl:param name="prmCloseButtonClass"/>
    <xsl:param name="prmExpandButtonClass"/>
    <xsl:param name="prmCollapseButtonClass"/>
    <xsl:param name="prmContextualTabGroupHeight"/>
    <xsl:param name="prmContextualTabGroupClass"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varHeaderPosition">
      <xsl:choose>
        <xsl:when test="$prmTabLayout='0'">top</xsl:when>
        <xsl:otherwise>bottom</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varIsMultiline" select="@Attr.Multiline = '1'"/>

    <div id="VWGTCHD_{@Attr.Id}">
      <xsl:attribute name="style">
        position:absolute;<xsl:value-of select="$varHeaderPosition"/>:0px;position:absulote;width:100%;height:<xsl:value-of select="$prmTabHeight"/>px;
      </xsl:attribute>
      <xsl:attribute name="class">
        <xsl:value-of select="$prmHeadersRowClass"/>
      </xsl:attribute>

      <xsl:variable name="varNumberOfTabs" select="count(WC:Tags.TabPage)" />

      <xsl:variable name="varMaximumTabPageHeaders">
        <xsl:choose>
          <xsl:when test="@Attr.MaximumTabPageHeaders">
            <xsl:value-of select="@Attr.MaximumTabPageHeaders"/>
          </xsl:when>
          <xsl:otherwise>0</xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <div id="VWGScrollable_{@Id}" class="Common-Unselectable {$prmTabsContainerClass} ">
        <xsl:attribute name="style">
          line-height:0px;overflow:hidden;width:100%;height:<xsl:value-of select="$prmTabHeight"/>px;
        </xsl:attribute>
        <xsl:if test="$varMaximumTabPageHeaders=0">
          <xsl:attribute name="onresize">
            mobjApp.TabControl_OnResize(<xsl:value-of select="@Attr.Id"/>,window, true)
          </xsl:attribute>
        </xsl:if>
        <div class="{$prmTabControlContainerClass} Common-Unselectable" dir="{$dir}">
          <xsl:attribute name="style">
            height:<xsl:value-of select="$prmTabHeight"/>px;
          </xsl:attribute>
          <xsl:choose>
            <xsl:when test="$varMaximumTabPageHeaders &gt; 0">
              <xsl:variable name="varNumberOfTabsToDisplay">
                <xsl:choose>
                  <xsl:when test="$varNumberOfTabs &gt; $varMaximumTabPageHeaders">
                    <xsl:value-of select="$varMaximumTabPageHeaders"/>
                  </xsl:when>
                  <xsl:otherwise>
                    <xsl:value-of select="$varNumberOfTabs"/>
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:variable>
              <xsl:variable name="varHasMoreTab">
                <xsl:choose>
                  <xsl:when test="$varNumberOfTabs !=$varNumberOfTabsToDisplay">1</xsl:when>
                  <xsl:otherwise>0</xsl:otherwise>
                </xsl:choose>
              </xsl:variable>
              <xsl:apply-templates select="." mode="modTabControlHeaderMaxTabsSpreadContent">
                <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
                <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
                <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
                <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
                <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
                <xsl:with-param name="prmTabImageStyle" select="$prmTabImageSize" />
                <xsl:with-param name="prmNumberOfTabs" select="$varNumberOfTabsToDisplay" />
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                <xsl:with-param name="prmNumberOfTabsToDisplay" select="$varNumberOfTabsToDisplay" />
                <xsl:with-param name="prmHasMoreTab" select="$varHasMoreTab" />
              </xsl:apply-templates>
              <xsl:if test="$varHasMoreTab='1'">
                <!-- Creating the "MORE" button -->
                <xsl:call-template name="tplTabControlMoreTab">
                  <xsl:with-param name="prmTabClass" select="$prmTabClass" />
                  <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass" />
                  <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
                  <xsl:with-param name="prmTabHeight" select="$prmTabHeight" />
                  <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
                  <xsl:with-param name="prmTabImageStyle" select="$prmTabImageSize" />
                  <xsl:with-param name="prmNumberOfTabs" select="$varNumberOfTabsToDisplay" />
                  <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                </xsl:call-template>
              </xsl:if>
            </xsl:when>
            <xsl:otherwise>
              <xsl:variable name="varRelativeHeight" select="$prmTabHeight - [Skin.TabPageHeadersContainerSpreadStylePaddingTop] - [Skin.TabPageHeadersContainerSpreadStylePaddingBottom]" />
              <table style="width:100%;table-layout:auto;" class="Common-CellSpacing0 Common-CellPadding0">
                <tr>
                  <td class="Common-VAlignTop">
                    <div id="TABHEADERS_{@Attr.Id}">
                      <xsl:attribute name="style">
                        height:<xsl:value-of select="$varRelativeHeight"/>px;overflow:hidden;
                      </xsl:attribute>

                      <xsl:apply-templates select="." mode="modTabControlHeaderSpreadContent">
                        <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
                        <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
                        <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
                        <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
                        <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
                        <xsl:with-param name="prmTabImageStyle" select="$prmTabImageSize" />
                        <xsl:with-param name="prmNumberOfTabs" select="0" />
                        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                      </xsl:apply-templates>
                    </div>
                  </td>
                  <td>
                    <xsl:attribute name="style">
                      height:<xsl:value-of select="$varRelativeHeight"/>px;
                    </xsl:attribute>
                    <!-- Creating the "k" button -->
                    <xsl:call-template name="tplTabControlMoreTab">
                      <xsl:with-param name="prmTabClass" select="$prmTabClass" />
                      <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass" />
                      <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
                      <xsl:with-param name="prmTabHeight" select="$prmTabHeight" />
                      <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
                      <xsl:with-param name="prmTabImageStyle" select="$prmTabImageSize" />
                      <xsl:with-param name="prmNumberOfTabs" select="0" />
                      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                    </xsl:call-template>
                  </td>
                </tr>
              </table>
              <xsl:call-template name="tplCallMethod">
                <xsl:with-param name="prmMethod" select="concat('mobjApp.TabControl_OnResizeEnd(',@Attr.Id,',window,',$varMaximumTabPageHeaders=0,',',$varIsMultiline,',',$prmTabLayout,');')"/>
              </xsl:call-template>
            </xsl:otherwise>
          </xsl:choose>
        </div>
      </div>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawTabControlHeaderSpreadContent" match="WC:Tags.TabControl[@Attr.Appearance='32']" mode="modTabControlHeaderSpreadContent">
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabHeaderTextClass" />
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmTabDivContainer" />
    <xsl:param name="prmTabImageStyle" />
    <xsl:param name="prmNumberOfTabs" />
    <xsl:param name="prmIsEnabled"/>

    <xsl:for-each select="WC:Tags.TabPage">
      <xsl:apply-templates select="." mode="modHeaderContent">
        <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
        <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
        <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
        <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
        <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
        <xsl:with-param name="prmTabImageStyle" select="$prmTabImageStyle" />
        <xsl:with-param name="prmNumberOfTabs" select="$prmNumberOfTabs" />
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="tplDrawTabControlHeaderMaxTabsSpreadContent" match="WC:Tags.TabControl[@Attr.Appearance='32']" mode="modTabControlHeaderMaxTabsSpreadContent">
    <xsl:param name="prmTabClass"/>
    <xsl:param name="prmTabCenterClass"/>
    <xsl:param name="prmTabHeaderTextClass" />
    <xsl:param name="prmTabHeight"/>
    <xsl:param name="prmTabDivContainer" />
    <xsl:param name="prmTabImageStyle" />
    <xsl:param name="prmNumberOfTabs" />
    <xsl:param name="prmIsEnabled"/>
    <xsl:param name="prmNumberOfTabsToDisplay" />
    <xsl:param name="prmHasMoreTab" />

    <xsl:for-each select="WC:Tags.TabPage" migration-index="intPosition">
      <xsl:if test="position()&lt;=($prmNumberOfTabsToDisplay - $prmHasMoreTab)" migration-test="intPosition &lt;=(prmNumberOfTabsToDisplay-1 - prmHasMoreTab)">
        <xsl:apply-templates select="." mode="modHeaderContent">
          <xsl:with-param name="prmTabClass" select="$prmTabClass"/>
          <xsl:with-param name="prmTabCenterClass" select="$prmTabCenterClass"/>
          <xsl:with-param name="prmTabHeaderTextClass" select="$prmTabHeaderTextClass" />
          <xsl:with-param name="prmTabHeight" select="$prmTabHeight"/>
          <xsl:with-param name="prmTabDivContainer" select="$prmTabDivContainer" />
          <xsl:with-param name="prmTabImageStyle" select="$prmTabImageStyle" />
          <xsl:with-param name="prmNumberOfTabs" select="$prmNumberOfTabsToDisplay" />
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:apply-templates>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <!-- Draws the tab page header content -->
  <xsl:template name="tplDrawPageHeaderSpreadContent" match="WC:Tags.TabPage[../@Attr.Appearance='32']" mode="modHeaderContent">
    <xsl:param name="prmTabClass" />
    <xsl:param name="prmTabCenterClass" />
    <xsl:param name="prmTabHeaderTextClass" />
    <xsl:param name="prmTabHeight" />
    <xsl:param name="prmTabDivContainer" />
    <xsl:param name="prmTabImageStyle" />
    <xsl:param name="prmNumberOfTabs" />

    <div id="TAB_{@Id}" onclick="mobjApp.TabControl_ClearMode('{../@Attr.Id}');mobjApp.TabControl_ChangeTab('{@Id}',window,event)">
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyFontStyles">
          <xsl:with-param name="prmTarget" select="./.." />
        </xsl:call-template>
        <xsl:choose>
          <xsl:when test="$prmNumberOfTabs>0">
            width:<xsl:value-of select="100 div number($prmNumberOfTabs)" />%;
          </xsl:when>
          <xsl:otherwise>float:left;</xsl:otherwise>
        </xsl:choose>
        <xsl:text>height:100%;overflow:hidden;</xsl:text>
      </xsl:attribute>
      <xsl:attribute name="class">
        <xsl:value-of select="concat($prmTabDivContainer,' ',$prmTabClass)" />
        <xsl:if test="@Attr.Id=../@Attr.Selected and not(../@Attr.Mode='M')">
          <xsl:value-of select="concat(' ',$prmTabClass,'_Selected')" />
        </xsl:if>
      </xsl:attribute>
      <xsl:if test="@Attr.HeaderToolTip">
        <xsl:attribute name="title"><xsl:value-of select="@Attr.HeaderToolTip" /></xsl:attribute>
      </xsl:if>
      <table class="{$prmTabCenterClass} Common-Table Common-CellSpacing0 Common-CellPadding0">
        <xsl:attribute name="style">
          <xsl:text>height:100%;</xsl:text>
          <xsl:if test="$prmNumberOfTabs>0">width:100%;</xsl:if>
        </xsl:attribute>
        <tr>
          <td>
            <xsl:attribute name ="class">
              <xsl:value-of select ="$prmTabImageStyle"/>
            </xsl:attribute>
              <xsl:choose>
              <xsl:when test="@Attr.Image">
                <img class="{$prmTabImageStyle}" src="{@Attr.Image}" alt="{@Attr.Text}"></img>
              </xsl:when>
              <xsl:otherwise>
                <span>
                  <xsl:attribute name="style">
                    <xsl:text>display:inline-block;</xsl:text>
                  </xsl:attribute>
                  <xsl:attribute name ="class"><xsl:value-of select ="$prmTabImageStyle"/>
                  </xsl:attribute>
                  &#160;
                </span>
              </xsl:otherwise>
            </xsl:choose>
          </td>
        </tr>
        <tr>
          <td class="TabControl-SpreadTabHeaderTextColumn">
            <span class="{$prmTabHeaderTextClass}" id="TXT_{@Id}" >
              <xsl:attribute name="style">
                <xsl:call-template name="tplHeaderStyle" />
              </xsl:attribute>
              <xsl:call-template name="tplDecodeTextAsHtml" />
            </span>
          </td>
        </tr>
      </table>
    </div>
  </xsl:template>

  <!-- Draws the MORE button tab header-->
  <xsl:template name="tplTabControlMoreTab">
    <xsl:param name="prmStyle" />
    <xsl:param name="prmTabClass" />
    <xsl:param name="prmTabCenterClass" />
    <xsl:param name="prmTabHeaderTextClass"/>
    <xsl:param name="prmTabHeight" />
    <xsl:param name="prmTabDivContainer" />
    <xsl:param name="prmTabImageStyle" />
    <xsl:param name="prmNumberOfTabs" />
    <xsl:param name="prmIsEnabled" />

    <div id="TABMORE_{@Attr.Id}" >
      <!-- If button is enabled -->
      <xsl:if test="not($prmIsEnabled='0')">
        <xsl:attribute name="onclick">mobjApp.TabControl_MoreTab('<xsl:value-of select="@Attr.Id"/>',window);</xsl:attribute>
      </xsl:if>
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyFontStyles">
          <xsl:with-param name="prmTarget" select="./.." />
        </xsl:call-template>
        <xsl:value-of select="$prmStyle" />
        <xsl:text>height:100%;overflow:hidden;</xsl:text>
        <!--<xsl:if test="$prmNumberOfTabs>0">width:<xsl:value-of select="100 div number($prmNumberOfTabs)" />%;</xsl:if>-->


        <xsl:choose>
          <xsl:when test="$prmNumberOfTabs>0">
            width:<xsl:value-of select="100 div number($prmNumberOfTabs)" />%;
          </xsl:when>
          <xsl:otherwise>
            <xsl:if test="@Attr.MoreTabVisible=0">display:none;</xsl:if>
          </xsl:otherwise>
        </xsl:choose>


      </xsl:attribute>
      <xsl:attribute name="class">
        <xsl:value-of select="concat($prmTabDivContainer,' ',$prmTabClass)" />
        <xsl:if test="@Attr.Mode='M'">
          <xsl:value-of select="concat(' ',$prmTabClass,'_Selected')" />
        </xsl:if>
      </xsl:attribute>
      <table class="{$prmTabCenterClass} Common-Table Common-CellSpacing0 Common-CellPadding0">
        <xsl:attribute name="style">
          <xsl:text>height:100%;</xsl:text>
          <xsl:if test="$prmNumberOfTabs>0">width:100%;</xsl:if>
        </xsl:attribute>
        <tr>
          <td>
            <xsl:attribute name ="class">
              <xsl:value-of select ="$prmTabImageStyle"/>
            </xsl:attribute>
            <img class="{$prmTabImageStyle}" src="[Skin.TabMoreImage]" alt="" />
          </td>
        </tr>
        <tr>
          <td class="TabControl-SpreadTabHeaderTextColumn">
            <span class="{$prmTabHeaderTextClass}" id="TXT_{@Id}" >
              <xsl:call-template name="tplDecodeTextAsHtml" >
                <xsl:with-param name="prmText" select="'Labels.More'" />
              </xsl:call-template>
            </span>
          </td>
        </tr>
      </table>
    </div>
  </xsl:template>

  <xsl:template name="tplTabControlMoreTabContent">
    <xsl:param name="prmTabPageClass" select="'TabPage-Control'"/>
    <xsl:param name="prmTabDivContainer" select="'TabControl-TabDivContainer'"/>
    <xsl:param name="prmTabClass" select="'TabControl-Tab'"/>
    <xsl:param name="prmTabImageStyle" select="'TabControl-ImageSize'"/>
    <xsl:param name="prmTabHeaderTextClass" select="'TabControl-PageHeaderText'" />

    <xsl:variable name="varMaximumTabPageHeaders">
      <xsl:choose>
        <xsl:when test="@Attr.MaximumTabPageHeaders">
          <xsl:value-of select="@Attr.MaximumTabPageHeaders"/>
        </xsl:when>
        <xsl:otherwise>0</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <div id="TABMORE_CONTENT_{@Id}" dir="{$dir}">
      <xsl:attribute name="class">
        <xsl:value-of select="$prmTabPageClass"/>
      </xsl:attribute>
      <xsl:variable name="varMoreTabStartIndex">
        <xsl:choose>
          <xsl:when test="$varMaximumTabPageHeaders>0">
            <xsl:value-of select="$varMaximumTabPageHeaders - 1"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="@Attr.MaximumTabPageHeaders"/>
          </xsl:otherwise>
        </xsl:choose>
        <xsl:value-of select="@Attr.MoreTabStartIndex"/>
      </xsl:variable>
      <xsl:attribute name="style">
        <xsl:text>overflow:auto;position:relative;width:100%;height:100%;</xsl:text>
        <xsl:if test="not(@Attr.Mode='M')">display:none;</xsl:if>
        <xsl:call-template name="tplApplyStyles">
          <xsl:with-param name="prmBorder" select="0"/>
        </xsl:call-template>
      </xsl:attribute>
      <div style="height:100%;width:100%;position:absolute;">
        <xsl:for-each select="WC:Tags.TabPage" migration-index="intPosition">
          <xsl:if test="position() &gt; $varMoreTabStartIndex" migration-test="intPosition &gt;=varMoreTabStartIndex">
            <div id="TAB_{@Attr.Id}" onclick="mobjApp.TabControl_ClearMode('{../@Attr.Id}');mobjApp.TabControl_ChangeTab('{@Attr.Id}',window,event)">
              <xsl:call-template name="tplSetHighlight"/>
              <xsl:attribute name="class">
                <xsl:value-of select="concat($prmTabDivContainer,' ',$prmTabClass)" />
              </xsl:attribute>
              <table class="Common-CellSpacing0 Common-CellPadding0 Common-Table" style="width:100%;height:100%;" >
                <tr>
                  <td class="{$prmTabImageStyle}">
                    <xsl:if test="@Attr.Image">
                      <!-- the image of the row -->
                      <img class="{$prmTabImageStyle}" src="{@Attr.Image}" alt="{@Attr.Text}" />
                    </xsl:if>
                  </td>
                  <td>
                    <span style="padding-{$left}:5px;" class="{$prmTabHeaderTextClass}" id="TXT_{@Id}" >
                      <xsl:call-template name="tplDecodeTextAsHtml" />
                    </span>
                  </td>
                  <td class="Common-VAlignMiddle Common-AlignCenter" style="width:20px;">
                    <img class="Common-VAlignMiddle" width="[Skin.TabShowContentImageWidth]" height="[Skin.TabShowContentImageHeight]" src="[Skin.TabShowContentImage]" alt="" />
                  </td>
                </tr>
              </table>
            </div>
          </xsl:if>
        </xsl:for-each>
      </div>
    </div>
  </xsl:template>

  <!-- The default style TabControl body content match template -->
  <xsl:template name="tplDrawTabControlSpreadBody" match="WC:Tags.TabControl[@Attr.Appearance='32']" mode="modBodyContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:choose>
      <xsl:when test="@Attr.Mode='M'">
        <xsl:call-template name="tplTabControlMoreTabContent"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:apply-templates select="WC:Tags.TabPage[@Id=../@Attr.Selected]" mode="modBodyContent">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:apply-templates>
      </xsl:otherwise>
    </xsl:choose>
    <xsl:if test="@Attr.ClientUpdateHandler">
      <xsl:apply-templates select="WC:Tags.TabPage[not(@Id=../@Attr.Selected)]" mode="modBodyContent">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:apply-templates>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
