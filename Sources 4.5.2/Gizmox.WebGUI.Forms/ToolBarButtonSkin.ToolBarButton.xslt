<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:WC="wgcontrols"
                xmlns:WG="http://www.gizmox.com/webgui">  
  
  <xsl:template match="WC:Tags.ToolBarButton" mode="modFrameCenterContent">
    <xsl:variable name="varText">
      <xsl:if test="@Attr.Text"><xsl:value-of select="@Attr.Text"/></xsl:if> 
      <xsl:if test="../@Attr.TextImageRelation=1 and ../@Attr.ToolBarItemAutoSizePreservedPlaceholders=1">
        <xsl:if test="(not(@Attr.Text) or @Attr.Text='') and count(../WC:Tags.ToolBarButton[(@Attr.Text and not(@Attr.Text=''))]) > 0">&#160;</xsl:if>
      </xsl:if>
    </xsl:variable>
    <xsl:call-template name="tplDrawButtonContent">
      <xsl:with-param name="prmText" select="$varText"/>
      <xsl:with-param name="prmTextClass" select="'ToolBarButton-FontData'"/>
      <xsl:with-param name="prmTextAlign" select="'CenterMiddle'" />
      <xsl:with-param name="prmImageAlign" select="'CenterMiddle'" />
      <xsl:with-param name="prmImageHeight" select="../@Attr.ImageHeight" />
      <xsl:with-param name="prmImageWidth" select="../@Attr.ImageWidth" />
      <xsl:with-param name="prmTextImageRelation" select="../@Attr.TextImageRelation" />
      <xsl:with-param name="prmLayoutPadding" select="0" />
      <xsl:with-param name="prmDropDown" select="@Attr.DropDown" />
      <xsl:with-param name="prmDropDownWidth" select="[Skin.DropDownImageWidth]" />
      <xsl:with-param name="prmDropDownClass" select="'ToolBarButton-DropDown'" />
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="WC:Tags.ToolBarButton" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:choose>
      <xsl:when test="@Attr.Icon='#Before' or @Attr.Icon='#Space' or @Attr.Icon='#After'">
      </xsl:when>
      <xsl:when test="@Attr.Style='3'">
        <div style="float:{$dir};height:100%;position:relative" class="ToolBarButton-Seperator">
          <xsl:call-template name="tplDrawEmptyImage"/>
        </div>
      </xsl:when>
      <xsl:otherwise>
        <div style="width:100%;height:100%;position:relative">
          <xsl:if test="not($prmIsEnabled='0') and not($prmIsEnabled='0') and not(@Attr.CustomStyle='Label')">
            <xsl:call-template name="tplSetHighlight" >
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:call-template>
          </xsl:if>
          <xsl:apply-templates select="." mode="modButtonContent">
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
          </xsl:apply-templates>
        </div>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
</xsl:stylesheet>
