<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
  <!--Match for a form which is displayed whithin a popup window-->
  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and @Attr.CustomStyle='Menu']">
    <xsl:param name="prmIsEnabled" select="@Attr.Enabled" />

    <xsl:variable name="varBoxShadowSupport"><xsl:call-template name="tplSupportsCSS3BrowserCapability"><xsl:with-param name="prmCSS3BrowserCapability" select="32"/></xsl:call-template></xsl:variable>
    <div class="Menu-PopupWindow" style="height:100%;width:100%;">
        <xsl:call-template name="tplDrawFrame">
            <xsl:with-param name="prmLeftBottomClass">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                    <xsl:otherwise><xsl:value-of select="'Menu-BottomLeft'"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmLeftClass">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                    <xsl:otherwise><xsl:value-of select="'Menu-Left'"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmLeftTopClass">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                    <xsl:otherwise><xsl:value-of select="'Menu-TopLeft'"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmTopClass">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                    <xsl:otherwise><xsl:value-of select="'Menu-Top'"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmRightTopClass">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                    <xsl:otherwise><xsl:value-of select="'Menu-TopRight'"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmRightClass">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                    <xsl:otherwise><xsl:value-of select="'Menu-Right'"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmRightBottomClass">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                    <xsl:otherwise><xsl:value-of select="'Menu-BottomRight'"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmBottomClass">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">''</xsl:when>
                    <xsl:otherwise><xsl:value-of select="'Menu-Bottom'"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmCenterClass" select="'Menu-Center'"/>
            <xsl:with-param name="prmCenterContent" select="." />

            <xsl:with-param name="prmLeftFrameWidth">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
                    <xsl:otherwise><xsl:value-of select="[Skin.LeftPopupWindowFrameWidth]"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmRightFrameWidth">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
                    <xsl:otherwise><xsl:value-of select="[Skin.RightPopupWindowFrameWidth]"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmTopFrameHeight">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
                    <xsl:otherwise><xsl:value-of select="[Skin.TopPopupWindowFrameHeight]"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmBottomFrameHeight">
                <xsl:choose>
                    <xsl:when test="$varBoxShadowSupport='true'">0</xsl:when>
                    <xsl:otherwise><xsl:value-of select="[Skin.BottomPopupWindowFrameHeight]"/></xsl:otherwise>
                </xsl:choose>
            </xsl:with-param>
            <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
        </xsl:call-template>
    </div>          
  </xsl:template>

  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and @Attr.CustomStyle='Menu']" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplWriteFormBody">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmClassName" select="Menu-DialogBody"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.Form[@Attr.Type='PopupWindow' and @Attr.CustomStyle='Menu']" mode="modScrollbars">
    <xsl:call-template name="tplMenuFormScrollBars" />
  </xsl:template>

  <xsl:template name="tplMenuFormScrollBars">
    <xsl:param name="prmContainerElementID" select="@Attr.Id" />
    <xsl:param name="prmScrollbars" select="'V'" />
    <xsl:param name="prmArrowsBaseClass" select="'Form-ArrowsClass'" />
    <xsl:param name="prmTopArrowThickness" select="[Skin.ArrowTopThickness]" />
    <xsl:param name="prmRightArrowThickness" select="[Skin.ArrowRightThickness]" />
    <xsl:param name="prmBottomArrowThickness" select="[Skin.ArrowBottomThickness]" />
    <xsl:param name="prmLeftArrowThickness" select="[Skin.ArrowLeftThickness]" />
    <xsl:param name="prmHorizontalHoverSpeed" select="[Skin.HorizontalHoverSpeed]" />
    <xsl:param name="prmHorizontalDownSpeed" select="[Skin.HorizontalDownSpeed]" />
    <xsl:param name="prmVerticalHoverSpeed" select="[Skin.VerticalHoverSpeed]" />
    <xsl:param name="prmVerticalDownSpeed" select="[Skin.VerticalDownSpeed]" />

    <xsl:call-template name="tplDrawScrollbars">
      <xsl:with-param name="prmContainerElementID" select="$prmContainerElementID" />
      <xsl:with-param name="prmScrollbars" select="$prmScrollbars" />
      <xsl:with-param name="prmArrowsBaseClass" select="$prmArrowsBaseClass" />
      <xsl:with-param name="prmTopArrowThickness" select="$prmTopArrowThickness" />
      <xsl:with-param name="prmRightArrowThickness" select="$prmRightArrowThickness" />
      <xsl:with-param name="prmBottomArrowThickness" select="$prmBottomArrowThickness" />
      <xsl:with-param name="prmLeftArrowThickness" select="$prmLeftArrowThickness" />
      <xsl:with-param name="prmHorizontalHoverSpeed" select="$prmHorizontalHoverSpeed" />
      <xsl:with-param name="prmHorizontalDownSpeed" select="$prmHorizontalDownSpeed" />
      <xsl:with-param name="prmVerticalHoverSpeed" select="$prmVerticalHoverSpeed" />
      <xsl:with-param name="prmVerticalDownSpeed" select="$prmVerticalDownSpeed" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>