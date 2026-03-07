<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="Tags.Row[(../@Attr.View='Details') and (../@Attr.CustomStyle='$safeitemname$')]">
    <xsl:param name="prmIsEnabled">
      <xsl:call-template name="tplIsEnabled" />
    </xsl:param>
    <xsl:call-template name="tplDrawDetailsRow">
      <xsl:with-param name="prmListViewFontDataClass" select="'ListView-FontData'" />
      <xsl:with-param name="prmListViewGroupHeaderClass" select="'ListView-GroupHeader'" />
      <xsl:with-param name="prmListViewFontGroupHeaderSeperatorClass" select="'ListView-FontGroupHeaderSeperator'" />
      <xsl:with-param name="prmListViewCheckBoxImageClass" select="'ListView-CheckBoxImage'" />
      <xsl:with-param name="prmListViewDataRowClass" select="'ListView-DataRow'" />
      <xsl:with-param name="prmListViewDataFullRowClass" select="'ListView-DataFullRow'"/>
      <xsl:with-param name="prmListViewDataRow0Class" select="'ListView-DataRow0'" />
      <xsl:with-param name="prmListViewDataRow1Class" select="'ListView-DataRow1'" />
      <xsl:with-param name="prmListViewCellClass" select="'ListView-Cell'" />
      <xsl:with-param name="prmListViewItemCellClass" select="'ListView-ItemCell'" />
      <xsl:with-param name="prmListViewDataCellClass" select="'ListView-DataCell'" />

      <xsl:with-param name="prmCheckBoxes" select="../@Attr.CheckBoxes" />
      <xsl:with-param name="prmCols" select="../Tags.Column" />
      <xsl:with-param name="prmPanel" select="0" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>


</xsl:stylesheet>
