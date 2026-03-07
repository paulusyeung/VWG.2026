<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.ComboBox[@Attr.VisualTemplate='NativeComboBoxVisualTemplate' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varId" select="@Attr.Id"/>
    <xsl:variable name="varSelectedIndex" select="@Attr.Value"/>
    <xsl:variable name="varControlClass" select="'ComboBox-Control'"/>
    <xsl:variable name="varSelectClass" select="'ComboBox-Select'"/>

    <xsl:attribute name="class">
      <xsl:value-of select="$varControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$varControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <select onchange="mobjApp.NativeComboBox_ValueChanged('{$varId}',this.selectedIndex,window);">
      <xsl:attribute name="class">
        <xsl:value-of select="$varSelectClass"/>
        <xsl:if test="$prmIsEnabled='0'">
          <xsl:value-of select="concat(' ',$varSelectClass,'_Disabled')"/>
        </xsl:if>
      </xsl:attribute>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:attribute name="disabled">disabled</xsl:attribute>
      </xsl:if>
      <xsl:attribute name="style">
        <xsl:text>height: 100%; width: 100%;</xsl:text>
        <xsl:call-template name="tplApplyStyles"/>
      </xsl:attribute>
      <xsl:for-each select="Tags.Options/Tags.Option">
        <option>
          <xsl:if test="$varSelectedIndex=@Attr.Index">
            <xsl:attribute name="selected">1</xsl:attribute>
          </xsl:if>
          <xsl:call-template name="tplDecodeTextAsHtml">
            <xsl:with-param name="prmText" select="@Attr.Text"/>
          </xsl:call-template>
        </option>
      </xsl:for-each>
    </select>
  </xsl:template>
</xsl:stylesheet>
