<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
    <xsl:template match="WC:Tags.WatermarkTextBox[not(@Attr.Multiline)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    
    <xsl:call-template name="tplDrawSingleLineWatermarkTextBox">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmControlClass" select="'WatermarkTextBox-Control'"/>
      <xsl:with-param name="prmTextClass" select="'WatermarkTextBox-Text'" />
      <xsl:with-param name="prmWatermarkTextClass" select="'WatermarkTextBox-Watermark'" />
      <xsl:with-param name="prmSingleLineClass" select="'WatermarkTextBox-SingleLine'"/>
      <xsl:with-param name="prmValue" select="@Attr.Value" />
      <xsl:with-param name="prmWatermarkText" select="@Attr.Message" />
      <xsl:with-param name="prmBlurHandler" select="concat('mobjApp.WatermarkTextBox_Blur(&quot;',@Attr.Id,'&quot;,this,window);')" />
      <xsl:with-param name="prmFocusHandler" select="concat('mobjApp.WatermarkTextBox_Focus(&quot;',@Attr.Id,'&quot;,this,window);')" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawSingleLineWatermarkTextBox">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmControlClass" select="'WatermarkTextBox-Control'"/>
    <xsl:param name="prmTextClass" select="'WatermarkTextBox-Text'" />
    <xsl:param name="prmWatermarkTextClass" select="'WatermarkTextBox-Watermark'" />
    <xsl:param name="prmSingleLineClass" select="'WatermarkTextBox-SingleLine'"/>
    <xsl:param name="prmValue" select="@Attr.Value" />
    <xsl:param name="prmWatermarkText" select="@Attr.Message" />
    <xsl:param name="prmInputType">
      <xsl:choose>
        <xsl:when test="@Attr.Password='1'">password</xsl:when>
        <xsl:otherwise>text</xsl:otherwise>
      </xsl:choose>
    </xsl:param>
    <xsl:param name="prmBlurHandler" select="concat('mobjApp.WatermarkTextBox_Blur(&quot;',@Attr.Id,'&quot;,this,window);')" />
    <xsl:param name="prmFocusHandler" select="concat('mobjApp.WatermarkTextBox_Focus(&quot;',@Attr.Id,'&quot;,this,window);')" />

    <!-- We need to set the target-type here (and not on the input itself) because the type may change. Here we save the ORIGINAL type-->
    <xsl:attribute name="data-vwgtargettype">
      <xsl:value-of select="$prmInputType"/>
    </xsl:attribute>

    <xsl:call-template name="tplDrawSingleLineTextBoxAPI">
      <xsl:with-param name="prmControlClass" select="$prmControlClass"/>
      <xsl:with-param name="prmTextClass">
        Common-FontData <xsl:choose>
          <xsl:when test="@Attr.Value and not(@Attr.Value='')"><xsl:value-of select="$prmTextClass"/></xsl:when>
          <xsl:otherwise><xsl:value-of select="$prmWatermarkTextClass"/></xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmSingleLineClass" select="$prmSingleLineClass"/>
      <xsl:with-param name="prmValue">
        <xsl:choose>
          <xsl:when test="@Attr.Value and not(@Attr.Value='')">
            <xsl:value-of select="$prmValue"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$prmWatermarkText"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmInputType">
        
        <xsl:choose>
          <!-- If there is value and password type is needed, we need to display the text as password -->
          <xsl:when test="(@Attr.Value and not(@Attr.Value='') and $prmInputType='password')">password</xsl:when>
          <!-- We passed the above condition, so we don't have a value. So even if we set 'password' as the type, we set the type to 'text' because we need to display the watermark -->
          <xsl:when test="$prmInputType='password'">text</xsl:when>
          <!-- We don't have a password type, so just set the given type-->
          <xsl:otherwise><xsl:value-of select="$prmInputType" /></xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmBlurHandler" select="$prmBlurHandler"/>
      <xsl:with-param name="prmFocusHandler" select="$prmFocusHandler"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>  
  </xsl:template>
  
  
  
  <xsl:template match="WC:Tags.WatermarkTextBox[@Attr.Multiline]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawMultilineWatermarkTextBox">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmControlClass" select="'WatermarkTextBox-Control'"/>
      <xsl:with-param name="prmWatermarkTextClass" select="'WatermarkTextBox-Watermark'" />
      <xsl:with-param name="prmMultiLineClass" select="'WatermarkTextBox-MultiLine'"/>
      <xsl:with-param name="prmText" select="@Attr.Value" />
      <xsl:with-param name="prmWatermarkText" select="@Attr.Message" />
      <xsl:with-param name="prmBlurHandler" select="concat('mobjApp.WatermarkTextBox_Blur(&quot;',@Attr.Id,'&quot;,this,window);')" />
      <xsl:with-param name="prmFocusHandler" select="concat('mobjApp.WatermarkTextBox_Focus(&quot;',@Attr.Id,'&quot;,this,window);')" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawMultilineWatermarkTextBox">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmControlClass" select="'WatermarkTextBox-Control'"/>
    <xsl:param name="prmTextClass" select="'WatermarkTextBox-Text'" />
    <xsl:param name="prmWatermarkTextClass" select="'WatermarkTextBox-Watermark'" />
    <xsl:param name="prmMultiLineClass" select="'WatermarkTextBox-MultiLine'"/>
    <xsl:param name="prmText" select="@Attr.Value" />
    <xsl:param name="prmWatermarkText" select="@Attr.Message" />
    <xsl:param name="prmBlurHandler" select="concat('mobjApp.WatermarkTextBox_Blur(&quot;',@Attr.Id,'&quot;,this,window);')" />
    <xsl:param name="prmFocusHandler" select="concat('mobjApp.WatermarkTextBox_Focus(&quot;',@Attr.Id,'&quot;,this,window);')" />
    
    <xsl:call-template name="tplDrawMultilineTextBoxAPI">
      <xsl:with-param name="prmSupportTextAreaNullableValue" select="0" />
      <xsl:with-param name="prmControlClass" select="$prmControlClass"/>
      <xsl:with-param name="prmTextClass">
        Common-FontData <xsl:choose>
          <xsl:when test="@Attr.Value and not(@Attr.Value='')"><xsl:value-of select="$prmTextClass"/></xsl:when>
          <xsl:otherwise><xsl:value-of select="$prmWatermarkTextClass"/></xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmMultiLineClass" select="$prmMultiLineClass"/>
      <xsl:with-param name="prmText">
        <xsl:choose>
          <xsl:when test="@Attr.Value and not(@Attr.Value='')">
            <xsl:value-of select="$prmText"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$prmWatermarkText"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmKeyPressWithoutMaxLengthHandler" select="''"/>
      <xsl:with-param name="prmBlurHandler" select="$prmBlurHandler"/>      
      <xsl:with-param name="prmFocusHandler" select="$prmFocusHandler"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.WatermarkTextBox" mode="modCustomAttributes">
    <xsl:param name="prmId" select="@Attr.Id" />
    <xsl:param name="prmWatermarkTextClassName" select="'WatermarkTextBox-Watermark'" />
    <xsl:param name="prmWatermarkSinglelineClassName" select="'WatermarkTextBox-SingleLine'" />
    <xsl:param name="prmWatermarkMultilineClassName" select="'WatermarkTextBox-MultiLine'" />

    <xsl:call-template name="tplDrawWatermarkTextBoxCustomAttributes">
      <xsl:with-param name="prmId" select="$prmId" />
      <xsl:with-param name="prmWatermarkTextClassName" select="'WatermarkTextBox-Watermark'" />
      <xsl:with-param name="prmWatermarkSinglelineClassName" select="'WatermarkTextBox-SingleLine'" />
      <xsl:with-param name="prmWatermarkMultilineClassName" select="'WatermarkTextBox-MultiLine'" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawWatermarkTextBoxCustomAttributes">
    <xsl:param name="prmId" select="@Attr.Id" />
    <xsl:param name="prmWatermarkTextClassName" select="'WatermarkTextBox-Watermark'" />
    <xsl:param name="prmWatermarkSinglelineClassName" select="'WatermarkTextBox-SingleLine'" />
    <xsl:param name="prmWatermarkMultilineClassName" select="'WatermarkTextBox-MultiLine'" />
    <xsl:attribute name="data-vwgiswatermark">
      <xsl:choose>
        <xsl:when test="@Attr.Value and not(@Attr.Value='')">0</xsl:when>
        <xsl:otherwise>1</xsl:otherwise>
      </xsl:choose>
    </xsl:attribute>
    <xsl:attribute name="data-vwgwatermarktextclass">
      <xsl:value-of select="$prmWatermarkTextClassName"/>
    </xsl:attribute>
    <xsl:attribute name="data-vwgwatermarksinglelineclass">
      <xsl:value-of select="$prmWatermarkSinglelineClassName"/>
    </xsl:attribute>
    <xsl:attribute name="data-vwgwatermarkmultilineclass">
      <xsl:value-of select="$prmWatermarkMultilineClassName"/>
    </xsl:attribute>
  </xsl:template>


</xsl:stylesheet>
