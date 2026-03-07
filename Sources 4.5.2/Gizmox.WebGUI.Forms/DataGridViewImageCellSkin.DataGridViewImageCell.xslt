<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols"
  xmlns:WG="http://www.gizmox.com/webgui">

  <!--Image-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='3']" mode="modCellContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplMatchPictureBoxNormal">
      <xsl:with-param name="prmImageSize">
        <xsl:if test="@Attr.ImageSize"><xsl:value-of select="@Attr.ImageSize"/></xsl:if>
        <xsl:if test="not(@Attr.ImageSize)">3</xsl:if>
      </xsl:with-param>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
