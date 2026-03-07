<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.DateTimePicker[@Attr.VisualTemplate='NativeDateTimePickerVisualTemplate' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varId" select="@Attr.Id"/>
    <xsl:variable name="varControlClass" select="'DateTimePicker-Control'"/>
    <xsl:variable name="varInputClass" select="'DateTimePicker-Input'"/>
    <xsl:attribute name="class">
      <xsl:value-of select="$varControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$varControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:variable name="varType" select="@Attr.VisualTemplateNativeDateTimePickerFormat"/>      
    
    <input id="TRG_{@Id}" required = "required">
      <xsl:attribute name="class">
        <xsl:value-of select="$varInputClass"/>
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$varInputClass,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>
      <xsl:attribute name="type">
        <xsl:value-of select="$varType"/>
      </xsl:attribute>
      <xsl:attribute name="style">height:100%;width:100%;</xsl:attribute>
      <xsl:attribute name="onchange">
        <xsl:value-of select="concat('NativeDateTimePicker_OnChange(&quot;',$varId,'&quot;,this,event,window)')" />
      </xsl:attribute>
      <xsl:attribute name="onmousedown">
        <xsl:value-of select="concat('NativeDateTimePicker_setNowOnClick(event, window, this, &quot;',$varId,'&quot;)')" />
      </xsl:attribute>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:attribute name="disabled">disabled</xsl:attribute>
      </xsl:if>
    </input>
    <xsl:call-template name="tplCallMethod">
      <xsl:with-param name="prmMethod" select="concat('mobjApp.NativeDateTimePicker_Init(',$varId,',window);')"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
