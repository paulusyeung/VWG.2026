<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:*[not(@Attr.ExtendedToolTipKey)]" mode="modToolTip">
    <xsl:call-template name="tplSetExtendedToolTipAPI">
      <xsl:with-param name="prmSkinPath" select="'[Skin.Path]'"/>
    </xsl:call-template>
  </xsl:template>
    
  <xsl:template name="tplSetExtendedToolTipAPI"> 
    <xsl:param name="prmSkinPath" />
    <xsl:param name="prmExtendedToolTip" select="@Attr.ExtendedToolTip"/>
    <xsl:param name="prmTemplateName" select="@Attr.ExtendedToolTipTemplateName"/>
    <xsl:param name="prmIsEnabled" />
  
    <xsl:if test="$prmIsEnabled='1' or not($prmIsEnabled)">
      <xsl:if test="$prmSkinPath and $prmExtendedToolTip and not($prmExtendedToolTip='') and $prmTemplateName and not($prmTemplateName='')">
        <xsl:call-template name="tplCallMethod">
          <xsl:with-param name="prmMethod">
            mobjApp.ToolTip_SetToolTip(<xsl:value-of select="@Attr.Id"/>, '<xsl:value-of select="$prmSkinPath"/>', window);
          </xsl:with-param>
        </xsl:call-template>
      </xsl:if>      
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>