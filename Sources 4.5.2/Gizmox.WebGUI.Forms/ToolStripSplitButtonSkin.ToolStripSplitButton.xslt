<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='2' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawFlatButtonAPI">
      <xsl:with-param name="prmFlatButtonClass" select="'Button-FlatControl'" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='2' and not(@Attr.CustomStyle)]" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled"/>
    <xsl:variable name="varOwnerStrip" select="ancestor::WC:Tags.ToolStrip | ancestor::WC:Tags.StatusStrip | ancestor::WC:Tags.MenuStrip"/>
    <xsl:variable name="varImageScaling" select="@Attr.ImageScaling" />
    
    <xsl:variable name="varImageHeight">
      <xsl:if test="not($varImageScaling and $varImageScaling=0)"><xsl:value-of select="$varOwnerStrip/@Attr.ImageHeight"/></xsl:if>
    </xsl:variable>
    <xsl:variable name="varImageWidth">
      <xsl:if test="not($varImageScaling and $varImageScaling=0)"><xsl:value-of select="$varOwnerStrip/@Attr.ImageWidth"/></xsl:if>
    </xsl:variable>

      <xsl:call-template name="tplDrawButtonContentAPI">
        <xsl:with-param name="prmFontDataClass" select="'Button-FontData'"/>
        <xsl:with-param name="prmImageHeight" select="$varImageHeight" />
        <xsl:with-param name="prmImageWidth" select="$varImageWidth" />
        <xsl:with-param name="prmDropDownArrowImage" select="'[Skin.DropDownArrowImage]'"/>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
        <xsl:with-param name="prmImageEnabledClass" select="'Button-Image'"/>
        <xsl:with-param name="prmImageDisabledClass" select="'Button-Image_Disabled'"/>
        <xsl:with-param name="prmDropDownClickHandler">
          <xsl:choose>
            <xsl:when test="not($prmIsEnabled='0')">
              <xsl:text>mobjApp.ToolStripSplitButton_DropDownClick(this,event);</xsl:text>
            </xsl:when>
            <xsl:otherwise>
              <xsl:text></xsl:text>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:with-param>
      </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
