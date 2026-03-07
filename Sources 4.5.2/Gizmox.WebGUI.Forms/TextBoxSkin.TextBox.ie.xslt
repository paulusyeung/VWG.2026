<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template name="tplApplyTransperentLayout">
    <xsl:param name="prmIsStyle"/>
    <xsl:if test="@Attr.Background='Transparent'">
      <xsl:if test="$prmIsStyle='1'">                    
        POSITION: absolute;
        </xsl:if>
      <xsl:if test="$prmIsStyle='0'">
        <div style="opacity:0; filter: alpha(opacity=0); background-color: white; position:absolute;width: 100%; height:100%;"></div>
      </xsl:if>
    </xsl:if>    
  </xsl:template>

  <xsl:template name="tplUpdateTextAreaNullableValue">
  </xsl:template>

  <xsl:template name="tplSetTextAreaNullableValue">
    <xsl:param name="prmText" select="@Attr.Value"/>
    <xsl:call-template name="tplSetTextAreaValue">
      <xsl:with-param name="prmText" select="$prmText"/>
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>