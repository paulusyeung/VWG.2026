<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='ToolStripDropDownContentPanel']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    
    <xsl:variable name="varScrollUpButtonDisabledClass" select="'ToolStripDropDown-ScrollUpButton_Disabled'" />
    <xsl:variable name="varScrollDownButtonClass" select="'ToolStripDropDown-ScrollDownButton'" />
    <xsl:variable name="varToolStripDropDownId" select="number(../../@Attr.Id)"/>
    <xsl:variable name="varScrollUpButtonHeight" select="'[Skin.ScrollUpButtonHeight]'"/>
    <xsl:variable name="varScrollDownButtonHeight" select="'[Skin.ScrollDownButtonHeight]'"/>
    
    <div style="width:100%;position:absolute;overflow:hidden;top:0px;bottom:0px;" data-vwgscrollable="1">
      <xsl:apply-templates select="WC:Tags.ToolStripItem" />
      <xsl:call-template name="tplDrawScrollbars">
        <xsl:with-param name="prmArrowsBaseClass" select="'Panel-ArrowsClass'" />
        <xsl:with-param name="prmTopArrowThickness" select="[Skin.ArrowTopThickness]" />
        <xsl:with-param name="prmRightArrowThickness" select="[Skin.ArrowRightThickness]" />
        <xsl:with-param name="prmBottomArrowThickness" select="[Skin.ArrowBottomThickness]" />
        <xsl:with-param name="prmLeftArrowThickness" select="[Skin.ArrowLeftThickness]" />
        <xsl:with-param name="prmHorizontalHoverSpeed" select="[Skin.HorizontalHoverSpeed]" />
        <xsl:with-param name="prmHorizontalDownSpeed" select="[Skin.HorizontalDownSpeed]" />
        <xsl:with-param name="prmVerticalHoverSpeed" select="[Skin.VerticalHoverSpeed]" />
        <xsl:with-param name="prmVerticalDownSpeed" select="[Skin.VerticalDownSpeed]" />
      </xsl:call-template>
    </div>
    
  </xsl:template>
</xsl:stylesheet>
