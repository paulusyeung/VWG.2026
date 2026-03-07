<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template name="tplApplyTransperentLayout">
  </xsl:template>

  <xsl:template name="tplSetTextAreaNullableValue">
    <xsl:param name="prmText" select="@Attr.Value"/>
    <xsl:if test="not ($prmText) or $prmText=''">&#160;</xsl:if>
    <xsl:if test="$prmText and not ($prmText='')">
      <xsl:if test="starts-with($prmText,'&#xD;')">
        <xsl:call-template name="tplDecodeText">
          <xsl:with-param name="prmText" select="concat('&#xD;',$prmText)"/>
        </xsl:call-template>
      </xsl:if>
      <xsl:if test="not(starts-with($prmText,'&#xD;'))">
        <xsl:call-template name="tplDecodeText">
          <xsl:with-param name="prmText" select="$prmText"/>
        </xsl:call-template>
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplUpdateTextAreaNullableValue">
    <xsl:param name="prmText" select="@Attr.Value"/>
    <xsl:if test="not($prmText) or $prmText=''">
      <xsl:call-template name="tplCallMethod">
        <xsl:with-param name="prmMethod" select="'mobjApp.TextBox_ClearValue(this.parentNode.firstChild);'"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  
</xsl:stylesheet>