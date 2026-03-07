<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
      xmlns:WC="wgcontrols"
  xmlns:WG="http://www.gizmox.com/webgui">

  <!--Multiline textbox usage-->
  <xsl:template match="WG:Tags.DataGridViewCell[@Attr.Type='1' and @Attr.Active='1']" mode="modCellContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varDataGridView" select="ancestor::WC:Tags.DataGridView[1]"/>
    <xsl:choose>
      <xsl:when test="@Attr.Mask">
        <xsl:call-template name="tplDrawSingleLineTextBoxAPI" >
          <xsl:with-param name="prmId" select="concat($varDataGridView/@Attr.Id,'_',@Attr.MemberID)" />
          <xsl:with-param name="prmAttachTextBoxSelectionEvents" select="0" />
          <xsl:with-param name="prmControlClass" select="'DataGridViewActiveTextBox-Control'" />
          <xsl:with-param name="prmTextClass" select="'DataGridViewActiveTextBox-Text'"/>
          <xsl:with-param name="prmSingleLineClass" select="'DataGridViewActiveTextBox-SingleLine'"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          <xsl:with-param name="prmAccessibleName" select="'Labels.ActiveCell'" />
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplDrawMultilineTextBoxAPI" >
          <xsl:with-param name="prmId" select="concat($varDataGridView/@Attr.Id,'_',@Attr.MemberID)" />
          <xsl:with-param name="prmAttachTextBoxSelectionEvents" select="0" />
          <xsl:with-param name="prmSupportTextAreaNullableValue" select="0" />
          <xsl:with-param name="prmControlClass" select="'DataGridViewActiveTextBox-Control'" />
          <xsl:with-param name="prmMultiLineClass" select="'DataGridViewActiveTextBox-MultiLine'"/>
          <xsl:with-param name="prmTextClass" select="'DataGridViewActiveTextBox-Text'"/>
          <xsl:with-param name="prmWordWrap" select="'0'"/>
          <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          <xsl:with-param name="prmAccessibleName" select="'Labels.ActiveCell'" />
        </xsl:call-template>
      </xsl:otherwise>
    
  </xsl:choose>
  </xsl:template>
  
</xsl:stylesheet>
