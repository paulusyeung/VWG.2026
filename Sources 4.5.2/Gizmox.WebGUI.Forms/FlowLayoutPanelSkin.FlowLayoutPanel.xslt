<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template name="tplDrawLayoutItem">
    <xsl:param name="prmIsEnabled" />
    <xsl:variable name="varVisible" select="not(@Attr.IsDelayedDrawing='1') and not(@Attr.Visible='0')"/>
    <xsl:variable name="varHorizontalAlignment" select="../@Attr.HorizontalAlignment"/>
    <xsl:variable name="varApplyMargin" select="(@Attr.MarginAll or @Attr.MarginLeft or @Attr.MarginRight or @Attr.MarginTop or @Attr.MarginBottom)" />

    <div class="FlowLayoutPanel-ControlContainer" data-vwgtype="control"  data-vwgvisible="{number($varVisible)}">
      <xsl:call-template name="tplApplyMinMaxSizeAttributes" />

      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyMinMaxSizeStyle" />
        display:
        <xsl:if test="not($varVisible)">none;</xsl:if>
        <xsl:if test="$varVisible">
          <xsl:choose>
            <xsl:when test="../@Attr.WrapContents='1' and (../@Attr.FlowDirection='1' or ../@Attr.FlowDirection='4')">
              inline-block;float:<xsl:value-of select="$varHorizontalAlignment"/>;
              <xsl:if test="$varHorizontalAlignment='right'">clear:left;</xsl:if>
              <xsl:if test="$varHorizontalAlignment='left'">clear:right;</xsl:if>
            </xsl:when>
            <xsl:otherwise>block;</xsl:otherwise>
          </xsl:choose>
        </xsl:if>
        height:<xsl:value-of select="@H" />px;width:<xsl:value-of select="@W" />px;
        <xsl:if test="$varApplyMargin"><xsl:call-template name="tplApplyMargins"/></xsl:if>
      </xsl:attribute>
      <xsl:call-template name="tplSetControl" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <xsl:choose>
        <xsl:when test="$varVisible">
          <div>
            <xsl:attribute name="style"><xsl:apply-templates mode="modApplyStyle" select="." /></xsl:attribute>
            <xsl:apply-templates select="." mode="modContent" >
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
            </xsl:apply-templates>
            <xsl:apply-templates select="." mode="modToolTip">
              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
            </xsl:apply-templates>
            <xsl:call-template name="tplApplySelectedIndicator"/>
          </div>
        </xsl:when>
        <xsl:otherwise>&#160;</xsl:otherwise>
      </xsl:choose>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawFlowLayoutPanelAPI">
    <xsl:param name="prmAutoSizeMode" select="'0'" />
    <xsl:param name="prmAutoSizeOrientation" />
    <xsl:param name="prmIsEnabled" />
    <xsl:attribute name="class">FlowLayoutPanel-Control</xsl:attribute>
    <table class="Common-CellPadding0 Common-CellSpacing0">
      <xsl:attribute name="style">
        <xsl:choose>
          <xsl:when test="$prmAutoSizeMode='0'">width:100%;height:100%;</xsl:when>
          <xsl:otherwise>
            <xsl:choose>
              <xsl:when test="$prmAutoSizeOrientation='0'">height:100%;</xsl:when>
              <xsl:otherwise>width:100%;</xsl:otherwise>
            </xsl:choose>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <tr>
        <td style="vertical-align:{@Attr.VerticalAlignment}" data-vwgtype="container">
          <xsl:choose>
            <!--In case of LeftToRight and RightToLeft when wrapping contents-->
            <xsl:when test="@Attr.WrapContents='1' and not(@Attr.FlowDirection='2' or @Attr.FlowDirection='8')">
              <xsl:call-template name="tplDrawContained">
                <xsl:with-param name="prmLayoutType" select="'C'" />
                <xsl:with-param name="prmAutoSizeMode" select="$prmAutoSizeMode" />
                <xsl:with-param name="prmAutoSizeOrientation" select="$prmAutoSizeOrientation" />
                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
              </xsl:call-template>
            </xsl:when>
            <xsl:otherwise>
              <xsl:if test="@Attr.Scrollbars and (@Attr.Scrollbars='B' or @Attr.Scrollbars='H' or @Attr.Scrollbars='V')">
                <xsl:call-template name="tplCompleteScrollCapabilities">
                  <xsl:with-param name="prmScrollbars" select="@Attr.Scrollbars" />
                </xsl:call-template>
              </xsl:if>
              <div>
                <xsl:attribute name="style">
                  width:100%;height:100%;top:0px;left:0px;<xsl:if test="$prmAutoSizeMode='0'">position:absolute;</xsl:if>
                  <xsl:call-template name="tplApplyPaddings" />
                </xsl:attribute>
                <xsl:if test="@Attr.Scrollbars and (@Attr.Scrollbars='B' or @Attr.Scrollbars='H' or @Attr.Scrollbars='V')">
                  <xsl:call-template name="tplApplyScrollableAttributes" />
                </xsl:if>
                <xsl:call-template name="tplDrawScrollbars">
                  <xsl:with-param name="prmScrollbars" select="@Attr.Scrollbars" />
                  <xsl:with-param name="prmArrowsBaseClass" select="'FlowLayoutPanel-ArrowsClass'" />
                  <xsl:with-param name="prmTopArrowThickness" select="[Skin.ArrowTopThickness]" />
                  <xsl:with-param name="prmRightArrowThickness" select="[Skin.ArrowRightThickness]" />
                  <xsl:with-param name="prmBottomArrowThickness" select="[Skin.ArrowBottomThickness]" />
                  <xsl:with-param name="prmLeftArrowThickness" select="[Skin.ArrowLeftThickness]" />
                  <xsl:with-param name="prmHorizontalHoverSpeed" select="[Skin.HorizontalHoverSpeed]" />
                  <xsl:with-param name="prmHorizontalDownSpeed" select="[Skin.HorizontalDownSpeed]" />
                  <xsl:with-param name="prmVerticalHoverSpeed" select="[Skin.VerticalHoverSpeed]" />
                  <xsl:with-param name="prmVerticalDownSpeed" select="[Skin.VerticalDownSpeed]" />
                </xsl:call-template>
                <xsl:variable name="arrControls" select="WC:*" />
                <xsl:variable name="varDirection">
                  <xsl:if test="@Attr.HorizontalAlignment='right'">rtl</xsl:if>
                  <xsl:if test="@Attr.HorizontalAlignment='left'">ltr</xsl:if>
                </xsl:variable>
                <xsl:choose>
                  <xsl:when test="@Attr.FlowDirection='2' or @Attr.FlowDirection='8'">
                    <!--BottomUp or TopDown-->
                    <xsl:variable name="varFlexClass">
                      <xsl:if test="@Attr.FlowDirection='2'">
                        FlowLayoutPanel_flexColumnStart
                      </xsl:if>
                      <xsl:if test="@Attr.FlowDirection='8'">
                        FlowLayoutPanel_flexColumnEnd
                      </xsl:if>
                    </xsl:variable>
                    <xsl:variable name="varFlexWrapClass">
                      <xsl:if test="@Attr.WrapContents='1'">
                        FlowLayoutPanel_flexWrap
                      </xsl:if>
                      <xsl:if test="not (@Attr.WrapContents='1')">
                        FlowLayoutPanel_flexNoWrap
                      </xsl:if>
                    </xsl:variable>
                    <div dir="{$varDirection}" class="{$varFlexClass} {$varFlexWrapClass}">
                      <!--Loop all contained controls-->
                      <xsl:for-each select="$arrControls">
                        <div class="Common-VAlignTop">
                          <div style="position:relative;width:100%;height:100%;">
                            <xsl:apply-templates select="." mode="modLayoutItem">
                              <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                            </xsl:apply-templates>
                          </div>
                        </div>
                      </xsl:for-each>
                    </div>
                  </xsl:when>
                  <xsl:otherwise>
                    <!--LeftToRight or RightToLeft-->
                    <table dir="{$varDirection}" class="Common-CellPadding0 Common-CellSpacing0">
                      <!--LeftToRight or RightToLeft-->
                      <xsl:attribute name="style">
                        table-layout:auto;<xsl:if test="$prmAutoSizeMode='0'">position:absolute;</xsl:if><xsl:value-of select="@Attr.HorizontalAlignment" />:0px;
                      </xsl:attribute>
                      <tr>
                        <!--Loop all contained controls-->
                        <xsl:for-each select="$arrControls">
                          <td class="Common-VAlignTop">
                            <div style="position:relative;width:100%;height:100%;">
                              <xsl:apply-templates select="." mode="modLayoutItem">
                                <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
                              </xsl:apply-templates>
                            </div>
                          </td>
                        </xsl:for-each>
                      </tr>
                    </table>
                  </xsl:otherwise>
                </xsl:choose>
              </div>
            </xsl:otherwise>
          </xsl:choose>
        </td>
      </tr>
    </table>
  </xsl:template>

  <xsl:template match="WC:Tags.FlowLayoutPanel" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawFlowLayoutPanelAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.FlowLayoutPanel" mode="modAutoSize">
    <xsl:param name="prmAutoSizeOrientation"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawFlowLayoutPanelAPI">
      <xsl:with-param name="prmAutoSizeMode" select="'1'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmAutoSizeOrientation" select="$prmAutoSizeOrientation"/>
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="WC:Tags.FlowLayoutPanel/WC:*" mode="modLayoutItem">
    <xsl:param name="prmIsEnabled" />

    <xsl:variable name="varIsEnabled">
      <xsl:call-template name="tplIsEnabled">
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
    </xsl:variable>
    
    <xsl:call-template name="tplDrawLayoutItem"  >      
      <xsl:with-param name="prmIsEnabled" select="$varIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.FlowLayoutPanel/WC:*" mode="modAutoSize">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawLayoutItem"  >
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
