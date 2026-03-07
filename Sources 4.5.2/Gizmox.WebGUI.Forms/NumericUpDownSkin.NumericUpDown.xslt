<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols"
	xmlns:Common="http://www.gizmox.com/webgui/common">

  <!-- The default style NumericUpDown match template -->
  <xsl:template name="tplDrawNumericUpDownAPI" match="WC:Tags.NumericUpDown" mode="modContent">
    <xsl:param name="prmControlClass" select="'NumericUpDown-Control'"/>
    <xsl:param name="prmInputClass" select="'NumericUpDown-Input'"/>
    <xsl:param name="prmDownCellClass" select="'NumericUpDown-DownCell'"/>
    <xsl:param name="prmUpCellClass" select="'NumericUpDown-UpCell'"/>
    <xsl:param name="prmImageCellWidth" select="'[Skin.ImageCellWidth]'"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmButtonsContainerClass" select="'NumericUpDown-ButtonsContainer'" />

    
    <xsl:call-template name="tplDrawUpDownAPI">
      <xsl:with-param name="prmEventsHandler" select="'mobjApp.NumericUpDown_HandleEvents'"/>
      <xsl:with-param name="prmMouseEventsHandler" select="'mobjApp.NumericUpDown_HandleMouseEvents'"/>
      <xsl:with-param name="prmControlClass" select="$prmControlClass"/>
      <xsl:with-param name="prmInputClass" select="$prmInputClass"/>
      <xsl:with-param name="prmDownCellClass" select="$prmDownCellClass"/>
      <xsl:with-param name="prmUpCellClass" select="$prmUpCellClass"/>
      <xsl:with-param name="prmImageCellWidth" select="$prmImageCellWidth"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmButtonsContainerClass" select="$prmButtonsContainerClass" />
    </xsl:call-template>
	</xsl:template>

  <!-- Disable styles that are not used in NumericUpDown control -->
  <xsl:template match="WC:Tags.NumericUpDown" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBorder" select="0" />
      <xsl:with-param name="prmBackground" select="1" />
      <xsl:with-param name="prmFont" select="1" />
      <xsl:with-param name="prmCursor" select="1" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
