<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols"
  xmlns:WG="http://www.gizmox.com/webgui">

  <!--CellContent-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='2']" mode="modCellContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varDataGridView" select="ancestor::WC:Tags.DataGridView[1]"/>
    <xsl:variable name="varColumns" select="$varDataGridView/WG:Tags.DataGridViewColumn" />
    <xsl:variable name="varIsDataGridViewReadOnly" select="$varDataGridView/@Attr.ReadOnly" />
    <xsl:variable name="varIsRowReadOnly" select="../@Attr.ReadOnly" />
    <xsl:variable name="varCellPosition" select="count(preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')])+1" />
    <xsl:variable name="varIsColumnReadOnly" select="$varColumns[position()=$varCellPosition]/@Attr.ReadOnly='1'" migration-select="varColumns.xposition( varCellPosition).attr(&quot;Attr.ReadOnly&quot;)=='1'" />
    <xsl:variable name="varEditable">
      <xsl:choose>
        <xsl:when test="(($varIsDataGridViewReadOnly='1' or $varIsColumnReadOnly='1' or $varIsRowReadOnly='1') and not(@Attr.ReadOnly='0')) or @Attr.ReadOnly='1'">0</xsl:when>
        <xsl:otherwise>1</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:call-template name="tplDrawCheckBoxAPI" >
      <xsl:with-param  name="prmControlClass" select="'CheckBox-Control'" />
      <xsl:with-param  name="prmLabelClass" select="'CheckBox-Label'" />
      <xsl:with-param  name="prmCheckedCheckBoxImage" select="'[Skin.CheckedCheckBoxImage]'"/>
      <xsl:with-param  name="prmUnCheckedCheckBoxImage" select="'[Skin.UnCheckedCheckBoxImage]'"/>
      <xsl:with-param  name="prmIndeterminateCheckBoxImage" select="'[Skin.IndeterminateCheckBoxImage]'"/>
      <xsl:with-param  name="prmStateImageHeight" select="[Skin.CheckBoxImageHeight]" />
      <xsl:with-param  name="prmStateImageWidth" select="[Skin.CheckBoxImageWidth]" />
      <xsl:with-param name="prmId" select="concat($varDataGridView/@Attr.Id,'_',@Attr.MemberID)" />
      <xsl:with-param name="prmAssignEvents" select="$varEditable"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>  
</xsl:stylesheet>
