<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
       xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
       xmlns:WC="wgcontrols">
  
  <xsl:template name="tplDrawFrameControlAPI">
    <xsl:param name="prmAutoSizeMode" select="'0'"/>
    <xsl:param name="prmAutoSizeOrientation"/>
    
    <xsl:attribute name="class">FrameControl-Control</xsl:attribute>
    <xsl:if test="not(@Attr.IsInline='1') and not(@Attr.Source='')">
      <iframe id="TRG_{@Id}" class="Common-NoBorder Common-AllowTransparency FrameControl-Frame" src="{@Attr.Source}" onload="mobjApp.Web_EnforceIFrameTheming('{@Attr.Id}');">
        <xsl:if test="$varBrowserObsoleteIE='1'">
          <xsl:attribute name ="frameborder">0</xsl:attribute>
          <xsl:attribute name ="allowtransparency">true</xsl:attribute>
        </xsl:if>
        &#160;</iframe>
    </xsl:if>
    <xsl:if test="@Attr.IsInline='1'">
      <xsl:call-template name="tplCompleteScrollCapabilities"/>
      <div>
        <xsl:attribute name="style">
          <xsl:choose>
            <xsl:when test="$prmAutoSizeMode='0'">top:0px;bottom:0px;left:0px;right:0px;position:absolute;</xsl:when>
            <xsl:otherwise>position:relative;width:100%;height:100%;</xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        
        <img src="[Skin.CommonPath]Empty.gif.wgx" onload="$(this).replaceWith($(this).attr('vwgsource'))" alt="">
          <xsl:attribute name="vwgsource">
            <xsl:call-template name="tplDecodeText">
              <xsl:with-param name="prmText" select="@Attr.Source"/>
            </xsl:call-template>
          </xsl:attribute>
        </img>
      </div>
    </xsl:if>
  </xsl:template>
  
  <xsl:template match="WC:Tags.FrameControl" mode="modContent">
    <xsl:call-template name="tplDrawFrameControlAPI"/>
  </xsl:template>

  <xsl:template match="WC:Tags.FrameControl" mode="modAutoSize">
    <xsl:param name="prmAutoSizeOrientation"/>

    <xsl:call-template name="tplDrawFrameControlAPI">
      <xsl:with-param name="prmAutoSizeMode" select="'1'"/>
      <xsl:with-param name="prmAutoSizeOrientation" select="$prmAutoSizeOrientation"/>
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>