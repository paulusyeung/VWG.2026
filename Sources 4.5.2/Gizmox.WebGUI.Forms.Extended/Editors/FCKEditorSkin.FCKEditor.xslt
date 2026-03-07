<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:FCKE" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:attribute name="class">
      <xsl:text>Common-FontData FCKEditor-Control</xsl:text>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> FCKEditor-Control_Disabled</xsl:text>
      </xsl:if>
    </xsl:attribute>
    <form id="{@ClientID}___Form" method="POST" data-vwgguid="{@Id}" style="width:100%;height:100%">
      <input type="hidden" id="{@ClientID}" name="{@UniqueID}" >        
          <xsl:attribute name="value">
            <xsl:call-template name="tplDecodeTextAsHtml">
              <xsl:with-param name="prmText" select="@Attr.Value"/>
            </xsl:call-template>
          </xsl:attribute>        
      </input>
        <input type="hidden" id="{@ClientID}___Config" value="{@Config}" />
        <iframe id="{@ClientID}___Frame" onload="mobjApp.FCKEditor_OnLoad(this,'{@ClientID}___Form'); mobjApp.Web_EnforceIFrameTheming('{@Attr.Id}');" src="{@Attr.Source}" class="Common-Strech Common-AllowTransparency Common-NoBorder">
          <xsl:if test="$varBrowserObsoleteIE='1'">
            <xsl:attribute name ="frameborder">0</xsl:attribute>
            <xsl:attribute name ="allowtransparency">true</xsl:attribute>
            <xsl:attribute name ="scrolling">no</xsl:attribute>
          </xsl:if>
        </iframe>
    </form>
  </xsl:template>

</xsl:stylesheet>