<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols"
	xmlns:WG="http://www.gizmox.com/webgui">

  <!--Property grid category entries -->
  <xsl:template match="WG:Tags.PropertyGridEntry[@Attr.Type='C']">
    <xsl:param name="prmGridView" select="ancestor::WC:Tags.PropertyGridView" />
    <table vwg_fetchedElement="1">
      <xsl:call-template name="tplDrawCategoryGridEntry">
        <xsl:with-param name="prmGridView" select="$prmGridView"/>
        <xsl:with-param name="prmFlagMatchedElement" select="1"/>
      </xsl:call-template>
    </table>
  </xsl:template>

  <!--Property grid entries: not category type entries -->
  <xsl:template match="WG:Tags.PropertyGridEntry[not(@Attr.Type='C')]">
    <xsl:param name="prmGridView" select="ancestor::WC:Tags.PropertyGridView" />
    <xsl:param name="prmHasLabelPlus" select="@Attr.HasNodes='1' and @Attr.Depth>0" />
    <table vwg_fetchedElement="1">
      <xsl:call-template name="tplDrawValueGridEntry">
        <xsl:with-param name="prmGridView" select="$prmGridView" />
        <xsl:with-param name="prmHasLabelPlus" select="$prmHasLabelPlus" />
        <xsl:with-param name="prmFlagMatchedElement" select="1"/>
      </xsl:call-template>
    </table>
  </xsl:template>

</xsl:stylesheet>
