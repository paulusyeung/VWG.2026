<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols"
	xmlns:WG="http://www.gizmox.com/webgui">

  <!--Link-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='4']" mode="modCellContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varDataGridView" select="ancestor::WC:Tags.DataGridView[1]"/>
    
    <xsl:call-template name="tplDrawLinkLabelAPI" >
      <xsl:with-param name="prmControlClass" select="'LinkLabel-Control'"/>
      <xsl:with-param name="prmControlDisabledClass" select="'LinkLabel-Disabled'"/>
      <xsl:with-param name="prmId" select="concat($varDataGridView/@Attr.Id,'_',@Attr.MemberID)" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='4']" mode="modContentText">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varDataGridView" select="ancestor::WC:Tags.DataGridView"/>
    <xsl:variable name="varColumns" select="$varDataGridView/WG:Tags.DataGridViewColumn" />
    <xsl:variable name="varIsDataGridViewReadOnly" select="$varDataGridView/@Attr.ReadOnly" />
    <xsl:variable name="varIsRowReadOnly" select="../@Attr.ReadOnly" />
    <xsl:variable name="varCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    <xsl:variable name="varIsColumnReadOnly" select="$varColumns[position()=$varCellPosition]/@Attr.ReadOnly='1'" migration-select="varColumns.xposition( varCellPosition).attr(&quot;Attr.ReadOnly&quot;)=='1'" />
    <xsl:variable name="varAllowHref">
      <xsl:choose>
        <xsl:when test="(($varIsDataGridViewReadOnly='1' or $varIsColumnReadOnly='1' or $varIsRowReadOnly='1') and not(@Attr.ReadOnly='0')) or @Attr.ReadOnly='1'">0</xsl:when>
        <xsl:otherwise>1</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:call-template name="tplDrawLinkLabelContentAPI" >
      <xsl:with-param name="prmAssignHref" select="$varAllowHref" />
      <xsl:with-param name="prmFocusable" select="0"/>      
      <xsl:with-param name="prmFocusClass" select="'LinkLabel-ContentContainer'"/>      
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmWrapContents" select="@Attr.WrapContents"/>
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
