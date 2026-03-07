<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
  
  <!-- Match for tabpage in update mode. -->
  <xsl:template match="WC:Tags.TabPage" >
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    
    <xsl:apply-templates select="."  mode="modBodyContent">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
    </xsl:apply-templates>
  </xsl:template>

  <!-- Draws the tab page body content -->
  <xsl:template match="WC:Tags.TabPage"  mode="modBodyContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawTabPageBodyContent">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawTabPageBodyContent">
    <xsl:param name="prmTabPageClass" select="'TabPage-Control'"/>
    <xsl:param name="prmIsEnabled" />
    <!-- TabControlDrawDirtyPages may be different than '1' in some cases in order to prevent drawing the content (For Example: NavigationTabs.js) -->
    <xsl:variable name="varTabControlDrawDirtyPages" select="../@Attr.TabControlDrawDirtyPages"/>
    <xsl:if test="not($varTabControlDrawDirtyPages) or ($varTabControlDrawDirtyPages='1' and @Attr.IsDirty='1')">
      <div>
        <xsl:attribute name="style">
          width:100%;height:100%;position:relative;<xsl:if test="not(@Attr.Id=../@Attr.Selected)">display:none;</xsl:if>
          <xsl:call-template name="tplApplyStyles"/>
        </xsl:attribute>
        <xsl:call-template name="tplSetControl" >
          <xsl:with-param name="prmClassName" select="$prmTabPageClass" />
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
        <xsl:call-template name="tplDrawContained">
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
      </div>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
