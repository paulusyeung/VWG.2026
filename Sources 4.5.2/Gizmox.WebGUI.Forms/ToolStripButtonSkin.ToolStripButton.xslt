<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='0' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varChecked" select="@Attr.Checked"/>
    <xsl:variable name="varCheckedOnClick" select="@Attr.CheckOnClick"/>
    <xsl:variable name="varOwnerId" select="@Attr.OwnerID"/>
    <xsl:variable name="varMemberID" select="@Attr.MemberID"/>

    <xsl:call-template name="tplDrawFlatButtonAPI">
      <xsl:with-param name="prmFlatButtonClass">
        <xsl:if test="$varChecked='1'">Button-FlatCheckedControl</xsl:if>
        <xsl:if test="not($varChecked='1')">Button-FlatControl</xsl:if>
      </xsl:with-param>
        <xsl:with-param name="prmClickHandler">
          <xsl:if test="$varCheckedOnClick='1'">
            <xsl:value-of select="concat('mobjApp.ToolStripButton_OnClick(&quot;',$varOwnerId,'_',$varMemberID,'&quot;,window,event);')" />
          </xsl:if>
        </xsl:with-param>
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='0' and not(@Attr.CustomStyle)]" mode="modFrameCenterContent">
      <xsl:param name="prmIsEnabled" select="@Attr.Enabled"/>
      
      <xsl:variable name="varOwnerStrip" select="ancestor::WC:Tags.ToolStrip | ancestor::WC:Tags.StatusStrip | ancestor::WC:Tags.MenuStrip | ancestor::WG:Tags.Form[@Attr.CustomStyle='ToolStripDropDown']"/>
    <xsl:variable name="varImageScaling" select="@Attr.ImageScaling" />

    <xsl:variable name="varOwnerHeight" select="$varOwnerStrip/@Attr.ImageHeight" />
    <xsl:variable name="varOwnerWidth" select="$varOwnerStrip/@Attr.ImageWidth" />

    <xsl:variable name="varImageHeight">
      <xsl:if test="not($varImageScaling and $varImageScaling=0)">
        <xsl:if test="$varOwnerHeight"><xsl:value-of select="$varOwnerHeight"/></xsl:if>
        <xsl:if test="not($varOwnerHeight)">16</xsl:if>
      </xsl:if>
    </xsl:variable>
    <xsl:variable name="varImageWidth">
      <xsl:if test="not($varImageScaling and $varImageScaling=0)">
        <xsl:if test="$varOwnerWidth"><xsl:value-of select="$varOwnerWidth"/></xsl:if>
        <xsl:if test="not($varOwnerWidth)">16</xsl:if>
      </xsl:if>
    </xsl:variable>
    
    <xsl:call-template name="tplDrawButtonContentAPI">
      <xsl:with-param name="prmFontDataClass" select="'Button-FontData'"/>
      <xsl:with-param name="prmImageHeight" select="$varImageHeight" />
      <xsl:with-param name="prmImageWidth" select="$varImageWidth" />
      <xsl:with-param name="prmDropDownArrowImage" select="'[Skin.DropDownArrowImage]'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
      <xsl:with-param name="prmImageEnabledClass" select="'Button-Image'"/>
      <xsl:with-param name="prmImageDisabledClass" select="'Button-Image_Disabled'"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='0' and not(@Attr.CustomStyle)]" mode="modDropDownMenu">
    <xsl:variable name="varIsAutoSize" select="not(@Attr.AutoSize='0')" />
    <xsl:variable name="varHeight">
      <xsl:choose>
        <xsl:when test="$varIsAutoSize">100%</xsl:when>
        <xsl:otherwise><xsl:value-of select="@Attr.Height"/>px</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varWidth">
      <xsl:choose>
        <xsl:when test="$varIsAutoSize">100%</xsl:when>
        <xsl:otherwise><xsl:value-of select="@Attr.Width"/>px</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <div>
      <xsl:attribute name="style">
        position:relative;overflow:hidden;width:<xsl:value-of select="$varWidth" />;height:<xsl:value-of select="$varHeight" />;
      </xsl:attribute>      
      <xsl:apply-templates select="." mode="modContent"/>     
    </div>
  </xsl:template>
</xsl:stylesheet>
