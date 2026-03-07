<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template name="tplDrawToolStripVerticalSeparatorAPI">
    <xsl:param name="prmMenuItemSeperatorClass" select="'ToolStripSeparator-VerticalSeperator'"/>
    
    <div style="float:{$dir};height:100%;width:100%;position:relative" class="{$prmMenuItemSeperatorClass}">
      <xsl:call-template name="tplDrawEmptyImage">
        <xsl:with-param name="prmDisplayStyle" select="'block'" />
      </xsl:call-template>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawToolStripHorizontalSeparatorAPI">
    <xsl:param name="prmMenuItemSeperatorClass" select="'ToolStripSeparator-HorizontalSeperator'"/>
    
    <div style="width:100%;height:100%;position:relative" class="{$prmMenuItemSeperatorClass}">
      <xsl:call-template name="tplDrawEmptyImage" >
        <xsl:with-param name="prmDisplayStyle" select="'block'" />
      </xsl:call-template>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawToolStripSeparatorAPI">
    <xsl:param name="prmMenuItemVerticalSeperatorClass" select="'ToolStripSeparator-VerticalSeperator'"/>
    <xsl:param name="prmMenuItemHorizontalSeperatorClass" select="'ToolStripSeparator-HorizontalSeperator'"/>
    <xsl:variable name="varIsVerticalOrientedStrip" select="../@Attr.Orientation='1'"/>

    <xsl:if test="$varIsVerticalOrientedStrip">
      <xsl:call-template name="tplDrawToolStripHorizontalSeparatorAPI">
        <xsl:with-param name="prmMenuItemSeperatorClass" select="$prmMenuItemHorizontalSeperatorClass" />
      </xsl:call-template>
    </xsl:if>
    <xsl:if test="not($varIsVerticalOrientedStrip)">
      <xsl:call-template name="tplDrawToolStripVerticalSeparatorAPI">
        <xsl:with-param name="prmMenuItemSeperatorClass" select="$prmMenuItemVerticalSeperatorClass" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  
  <xsl:template match="WC:Tags.ToolStrip/WC:Tags.ToolStripItem[@Attr.Type='4' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:call-template name="tplDrawToolStripSeparatorAPI"/>
  </xsl:template>

  <xsl:template match="WC:Tags.MenuStrip/WC:Tags.ToolStripItem[@Attr.Type='4' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:call-template name="tplDrawToolStripSeparatorAPI"/>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='4' and not(@Attr.CustomStyle)]" mode="modDropDownMenu">
    <xsl:call-template name="tplDrawToolStripHorizontalSeparatorAPI"/>
  </xsl:template>
</xsl:stylesheet>