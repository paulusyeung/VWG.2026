<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:WC="wgcontrols"
	xmlns:Common="http://www.gizmox.com/webgui/common">
  <xsl:template match="WC:Tags.TrackBar[@Attr.VisualTemplate='NativeTrackBarVisualTemplate' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varId" select="@Attr.Id"/>
    <xsl:variable name="varControlClass" select="'TrackBar-Control'"/>
    <xsl:variable name="varInputClass" select="'TrackBar-Input'"/>

    <xsl:attribute name="class">
      <xsl:value-of select="$varControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$varControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <input type="range" min="{@Attr.Minimum}" max="{@Attr.Maximum}" step="0.01" value="{@Attr.Value}">
      <xsl:attribute name="class">
        <xsl:value-of select="$varInputClass"/>
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$varInputClass,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>
      <xsl:attribute name="style">height:100%;width:100%;</xsl:attribute>
      <xsl:attribute name="onchange">
        <xsl:value-of select="concat('NativeTrackBar_OnChange(&quot;',$varId,'&quot;,this,event,window)')" />
      </xsl:attribute>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:attribute name="disabled">disabled</xsl:attribute>
      </xsl:if>
    </input>-->
  </xsl:template>  
</xsl:stylesheet>
