<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.ComboBox[@Attr.CustomStyle='DataGridViewHeaderFilterComboBoxSkin']">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled" />
    <xsl:call-template name="tplDataGridViewHeaderFilterComboBoxAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!--Main API for drawing control-->
  <xsl:template name="tplDataGridViewHeaderFilterComboBoxAPI">
    <xsl:param name="prmControlClass" select="'ComboBox-Control'" />
    <xsl:param name="prmIsEnabled"/>
    <xsl:param name="prmFilterNormalImageWidth" select="'[Skin.FilterNormalImageWidth]'"/>
    <xsl:variable name="varIsCustomFilter" select="@Attr.IsCustomFilter" />

    <xsl:variable name="varId" select="@Id" />
    <div id="VWG_{$varId}">
      <xsl:attribute name="class">
        <xsl:value-of select="$prmControlClass"/>
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>
      <xsl:attribute name="style">
        <xsl:text>position:absolute;height:100%;width:</xsl:text>
        <xsl:value-of select="$prmFilterNormalImageWidth"/>
        <xsl:text>px;</xsl:text>
      </xsl:attribute>
      <xsl:call-template name="tplSetHighlight">
        <xsl:with-param name="prmHandler" select="'DataGridViewHeaderFilterComboBox_HandleEvents'"/>
      </xsl:call-template>
    </div>    
  </xsl:template>
</xsl:stylesheet>
