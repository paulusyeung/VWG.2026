<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.DockManager" mode="modScrollbars">
    <xsl:param name="prmContainerElementID" select="@Attr.Id" />
    <xsl:param name="prmScrollbars" select="@Attr.Scrollbars" />
    <xsl:param name="prmArrowsBaseClass" select="'DockingManager-ArrowsClass'" />
    <xsl:param name="prmTopArrowThickness" select="[Skin.ArrowTopThickness]" />
    <xsl:param name="prmRightArrowThickness" select="[Skin.ArrowRightThickness]" />
    <xsl:param name="prmBottomArrowThickness" select="[Skin.ArrowBottomThickness]" />
    <xsl:param name="prmLeftArrowThickness" select="[Skin.ArrowLeftThickness]" />
    <xsl:param name="prmHorizontalHoverSpeed" select="[Skin.HorizontalHoverSpeed]" />
    <xsl:param name="prmHorizontalDownSpeed" select="[Skin.HorizontalDownSpeed]" />
    <xsl:param name="prmVerticalHoverSpeed" select="[Skin.VerticalHoverSpeed]" />
    <xsl:param name="prmVerticalDownSpeed" select="[Skin.VerticalDownSpeed]" />

    <xsl:call-template name="tplDrawScrollbars">
      <xsl:with-param name="prmContainerElementID" select="$prmContainerElementID" />
      <xsl:with-param name="prmScrollbars" select="$prmScrollbars" />
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
  </xsl:template>
  
  <!-- The default style DockManager match template -->
  <xsl:template match="WC:Tags.DockManager" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    
    <xsl:call-template name="tplDrawDockManagerAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Main API for drawing the control -->
  <xsl:template name="tplDrawDockManagerAPI">
    <xsl:param name="prmIsEnabled" />    
    <xsl:param name="prmControlClass" select="'DockManager-Control'"/>
    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
    </xsl:attribute>
    <xsl:apply-templates select="." mode="modFrameCenterContent">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:apply-templates>
  </xsl:template>

  <!-- API for drawing the control content and The default style DockManager content match template -->
  <xsl:template name="tplDrawDockManagerContentAPI" match="WC:Tags.DockManager" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varId" select="@Attr.Id" />
    
    <div class="Common-Strech {substring('Common-InheritDisabled',30*number(not($prmIsEnabled='0')))}">
      <xsl:call-template name="tplDrawContained">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </div>
  </xsl:template>

</xsl:stylesheet>
