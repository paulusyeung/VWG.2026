<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols"
	xmlns:Common="http://www.gizmox.com/webgui/common">

  <!-- The default style DomainUpDown match template -->
  <xsl:template name="tplDrawDomainUpDownAPI" match="WC:Tags.DomainUpDown" mode="modContent">
    <xsl:param name="prmControlClass" select="'DomainUpDown-Control'"/>
    <xsl:param name="prmInputClass" select="'DomainUpDown-Input'"/>
    <xsl:param name="prmDownCellClass" select="'DomainUpDown-DownCell'"/>
    <xsl:param name="prmUpCellClass" select="'DomainUpDown-UpCell'"/>
    <xsl:param name="prmImageCellWidth" select="'[Skin.ImageCellWidth]'"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmButtonsContainerClass" select="'DomainUpDown-ButtonsContainer'" />

    <xsl:call-template name="tplDrawUpDownAPI">
			<xsl:with-param name="prmEventsHandler" select="'mobjApp.DomainUpDown_HandleEvents'"/>
      <xsl:with-param name="prmMouseEventsHandler" select="'mobjApp.DomainUpDown_HandleMouseEvents'"/>
      <xsl:with-param name="prmControlClass" select="$prmControlClass"/>
      <xsl:with-param name="prmInputClass" select="$prmInputClass"/>
      <xsl:with-param name="prmDownCellClass" select="$prmDownCellClass"/>
      <xsl:with-param name="prmUpCellClass" select="$prmUpCellClass"/>
      <xsl:with-param name="prmImageCellWidth" select="$prmImageCellWidth"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmButtonsContainerClass" select="$prmButtonsContainerClass" />
    </xsl:call-template>
	</xsl:template>

  <!-- Disable styles that are not used in DomainUpDown control -->
  <xsl:template match="WC:Tags.DomainUpDown" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" >
      <xsl:with-param name="prmBorder" select="0" />
      <xsl:with-param name="prmBackground" select="1" />
      <xsl:with-param name="prmFont" select="1" />
      <xsl:with-param name="prmCursor" select="1" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
