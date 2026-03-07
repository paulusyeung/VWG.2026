<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.ListBox[@Attr.CustomStyle='$safeitemname$']|WC:Tags.ColorListBox[@Attr.CustomStyle='$safeitemname$']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawListBoxAPI">
      <xsl:with-param name="prmControlClass" select="'ListBox-Control'"/>
      <xsl:with-param name="prmFontClass" select="'ListBox-FontData'"/>
      <xsl:with-param name="prmCheckBoxColumnWidth" select="'[Skin.CheckBoxCellWidth]'"/>
      <xsl:with-param name="prmRowClass" select="'ListBox-Row'"/>
      <xsl:with-param name="prmRowSelectedClass" select="'ListBox-Row_Selected'"/>
      <xsl:with-param name="prmImageBoxClass" select="'ListBox-ImageBox'"/>
      <xsl:with-param name="prmColorBoxClass" select="'ListBox-ColorBox'"/>
      <xsl:with-param name="prmContainerClass" select="'ListBox-Container'"/>
      <xsl:with-param name="prmCheckedRadioButtonImage" select="'[Skin.CheckedRadioButtonImage]'"/>
      <xsl:with-param name="prmUncheckedRadioButtonImage" select="'[Skin.UncheckedRadioButtonImage]'"/>
      <xsl:with-param name="prmCheckedCheckBoxImage" select="'[Skin.CheckedCheckBoxImage]'"/>
      <xsl:with-param name="prmUncheckedCheckBoxImage" select="'[Skin.UncheckedCheckBoxImage]'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  
</xsl:stylesheet>
