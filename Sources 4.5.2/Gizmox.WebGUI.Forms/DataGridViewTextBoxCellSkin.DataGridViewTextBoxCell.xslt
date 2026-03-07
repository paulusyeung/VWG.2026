<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
      xmlns:WC="wgcontrols"
  xmlns:WG="http://www.gizmox.com/webgui">

  <!--Label usage-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='1' and not(@Attr.Active='1')]" mode="modCellContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawLabelAPI">
      <xsl:with-param name="prmControlClass"  select="'Label-Control'"/>
      <xsl:with-param name="prmControlDisabledClass" select="'Label-Disabled'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Draw content text-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='1' and not(@Attr.Active='1')]" mode="modContentText">
    <xsl:call-template name="tplDrawLabelContentAPI" >
      <xsl:with-param name="prmText" select="@Attr.Value" />
      <xsl:with-param name="prmContentContainerClass" select="'Label-ContentContainer'"/>
      <xsl:with-param name="prmWrapContents" select="@Attr.WrapContents"/>
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
