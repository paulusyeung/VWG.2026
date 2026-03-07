<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:WC="wgcontrols">
	

	<xsl:template match="WC:Tags.MdiClient" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:attribute name="class">
      <xsl:value-of select="'MdiClient-Control'"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> MdiClient-Control_Disabled</xsl:text>
      </xsl:if>
    </xsl:attribute>
    
    <xsl:variable name="varDataId" select="@Attr.Id"/>

    <xsl:call-template name="tplCompleteScrollCapabilities"/>
    <div id="VWGE_WindowsBox{@Attr.MdiParent}" class="MdiClient-Container" onscroll="mobjApp.Controls_StoreScroll(window,'{$varDataId}',this);" style="z-index:0;">
      <xsl:call-template name="tplRestoreScroll">
        <xsl:with-param name="prmGuid" select="$varDataId" />
      </xsl:call-template>
    </div>
	</xsl:template>
	
</xsl:stylesheet>
  
  

  