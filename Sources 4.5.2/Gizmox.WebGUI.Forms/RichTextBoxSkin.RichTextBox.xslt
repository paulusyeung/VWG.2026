<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

	<xsl:template match="WC:Tags.RichTextBox" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:attribute name="class">
      <xsl:text>RichTextBox-Control</xsl:text>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:text> RichTextBox-Control_Disabled</xsl:text>
      </xsl:if>
    </xsl:attribute>
    <iframe id="TRG_{@Id}" style="overflow:auto;" src="[Skin.Path]RichTextBox.Frame.htm.wgx?id={@Id}" class="Common-Strech Common-AllowTransparency RichTextBox-Frame" onload="mobjApp.Web_EnforceIFrameTheming('{@Attr.Id}');">
      <xsl:if test="$varBrowserObsoleteIE='1'">
        <xsl:attribute name ="frameborder">0</xsl:attribute>
        <xsl:attribute name ="allowtransparency">true</xsl:attribute>
      </xsl:if>
      &#160;
    </iframe>
	</xsl:template>
</xsl:stylesheet>

