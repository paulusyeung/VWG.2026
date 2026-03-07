<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template name="tplDrawToolStripLabelAPI">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varOwnerStrip" select="ancestor::WC:Tags.ToolStrip | ancestor::WC:Tags.StatusStrip | ancestor::WC:Tags.MenuStrip"/>
    <xsl:variable name="varImageScaling" select="@Attr.ImageScaling" />
    <xsl:variable name="varOwnerHeight" select="$varOwnerStrip/@Attr.ImageHeight" />
    <xsl:variable name="varOwnerWidth" select="$varOwnerStrip/@Attr.ImageWidth" />

    <xsl:variable name="varImageHeight">
      <xsl:if test="not($varImageScaling and $varImageScaling=0)">
        <xsl:if test="$varOwnerHeight">
          <xsl:value-of select="$varOwnerHeight"/>
        </xsl:if>
        <xsl:if test="not($varOwnerHeight)">16</xsl:if>
      </xsl:if>
    </xsl:variable>
    
    <xsl:variable name="varImageWidth">
      <xsl:if test="not($varImageScaling and $varImageScaling=0)">
        <xsl:if test="$varOwnerWidth">
          <xsl:value-of select="$varOwnerWidth"/>
        </xsl:if>
        <xsl:if test="not($varOwnerWidth)">16</xsl:if>
      </xsl:if>
    </xsl:variable>
    
    <xsl:variable name="varControlClass">
      <xsl:choose>
        <xsl:when test="@Attr.LinkState='1' and not($prmIsEnabled='0')">LinkLabel-Control</xsl:when>
        <xsl:when test="@Attr.LinkState='1'">LinkLabel-Control LinkLabel-Disabled</xsl:when>
        <xsl:when test="not($prmIsEnabled='0')">Label-Control</xsl:when>
        <xsl:otherwise>Label-Control Label-Disabled</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <xsl:variable name="varTextClass">
      <xsl:choose>
        <xsl:when test="@Attr.LinkState='1'">LinkLabel-ContentContainer</xsl:when>
        <xsl:otherwise>Label-ContentContainer</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <div class="{$varControlClass}" style="height:100%; width:100%">
      <xsl:call-template name="tplDrawButtonContent">
        <xsl:with-param name="prmText" select="@Attr.Value"/>
        <xsl:with-param name="prmTextClass" select="$varTextClass"/>
        <xsl:with-param name="prmImageHeight" select="$varImageHeight" />
        <xsl:with-param name="prmImageWidth" select="$varImageWidth" />
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
      </xsl:call-template>
    </div>
  </xsl:template>

  <!--Label / LinkLabel usage-->
  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='1' and not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripLabelAPI" >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="tplDrawToolStripLabelContentAPI">
    <xsl:choose>
      <xsl:when test="@Attr.LinkState='1'">
        <xsl:call-template name="tplDrawLabelContentAPI" >
          <xsl:with-param name="prmContentClass" select="'Common-HandCursor'"/>
          <xsl:with-param name="prmWrapContents" select="0"/>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplDrawLabelContentAPI" >
          <xsl:with-param name="prmContentClass" select="'Common-DefaultCursor'"/>
          <xsl:with-param name="prmText" select="@Attr.Value" />
          <xsl:with-param name="prmWrapContents" select="0"/>
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--Draw content text-->
  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='1' and not(@Attr.CustomStyle)]" mode="modContentText">
    <xsl:call-template name="tplDrawToolStripLabelContentAPI"/>
  </xsl:template>

  <!--Applay label backgroud color-->
  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='1' and not(@Attr.CustomStyle)]" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles">
      <xsl:with-param name="prmBorder" select="0" />
      <xsl:with-param name="prmBackground" select="1" />
      <xsl:with-param name="prmFont" select="0" />
      <xsl:with-param name="prmCursor" select="0" />
      <xsl:with-param name="prmVisualEffects" select="0" />
    </xsl:call-template>
  </xsl:template>

  <!--Draw dropdown menu text-->
  <xsl:template match="WC:Tags.ToolStripItem[@Attr.Type='1' and not(@Attr.CustomStyle)]" mode="modDropDownMenu">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawToolStripLabelAPI">  
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
