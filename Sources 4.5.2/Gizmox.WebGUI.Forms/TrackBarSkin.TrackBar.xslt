<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols"
	xmlns:Common="http://www.gizmox.com/webgui/common">
  <xsl:template match="WC:Tags.TrackBar[not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />

    <xsl:param name="prmHorizontalEndTickTopWidth" select="'[Skin.HorizontalEndTickTopWidth]'" />
    <xsl:param name="prmHorizontalStartTickTopWidth" select="'[Skin.HorizontalStartTickTopWidth]'"/>
    <xsl:param name="prmHorizontalEndTickBottomWidth" select="'[Skin.HorizontalEndTickBottomWidth]'"/>
    <xsl:param name="prmHorizontalStartTickBottomWidth" select="'[Skin.HorizontalStartTickBottomWidth]'"/>
    <xsl:param name="prmHorizontalEndTickBothWidth" select="'[Skin.HorizontalEndTickBothWidth]'"/>
    <xsl:param name="prmHorizontalStartTickBothWidth" select="'[Skin.HorizontalStartTickBothWidth]'"/>
    <xsl:param name="prmHorizontalEndTickNoneWidth" select="'[Skin.HorizontalEndTickNoneWidth]'"/>
    <xsl:param name="prmHorizontalStartTickNoneWidth" select="'[Skin.HorizontalStartTickNoneWidth]'"/>
    <xsl:param name="prmHorizontalStartTickTop" select="'[Skin.HorizontalStartTickTop]'"/>
    <xsl:param name="prmHorizontalStartTickBottom" select="'[Skin.HorizontalStartTickBottom]'"/>
    <xsl:param name="prmHorizontalStartTickBoth" select="'[Skin.HorizontalStartTickBoth]'"/>
    <xsl:param name="prmHorizontalStartTickNone" select="'[Skin.HorizontalStartTickNone]'"/>
    <xsl:param name="prmHorizontalEndTickTop" select="'[Skin.HorizontalEndTickTop]'"/>
    <xsl:param name="prmHorizontalEndTickBottom" select="'[Skin.HorizontalEndTickBottom]'"/>
    <xsl:param name="prmHorizontalEndTickBoth" select="'[Skin.HorizontalEndTickBoth]'"/>
    <xsl:param name="prmHorizontalEndTickNone" select="'[Skin.HorizontalEndTickNone]'"/>

    <xsl:param name="prmSliderTopWidth" select="'[Skin.SliderTopWidth]'"/>
    <xsl:param name="prmSliderHorizontalBothWidth" select="'[Skin.SliderHorizontalBothWidth]'"/>
    <xsl:param name="prmSliderBottomWidth" select="'[Skin.SliderBottomWidth]'"/>
    <xsl:param name="prmSliderTop" select="'[Skin.SliderTop]'"/>
    <xsl:param name="prmSliderHorizontalBoth" select="'[Skin.SliderHorizontalBoth]'"/>
    <xsl:param name="prmSliderBottom" select="'[Skin.SliderBottom]'"/>

    <xsl:param name="prmVerticalStartTickTopHeight" select="'[Skin.VerticalStartTickTopHeight]'"/>
    <xsl:param name="prmVerticalEndTickTopHeight" select="'[Skin.VerticalEndTickTopHeight]'"/>
    <xsl:param name="prmVerticalStartTickBottomHeight" select="'[Skin.VerticalStartTickBottomHeight]'"/>
    <xsl:param name="prmVerticalEndTickBottomHeight" select="'[Skin.VerticalEndTickBottomHeight]'"/>
    <xsl:param name="prmVerticalStartTickBothHeight" select="'[Skin.VerticalStartTickBothHeight]'"/>
    <xsl:param name="prmVerticalEndTickBothHeight" select="'[Skin.VerticalEndTickBothHeight]'"/>
    <xsl:param name="prmVerticalStartTickNoneHeight" select="'[Skin.VerticalStartTickNoneHeight]'"/>
    <xsl:param name="prmVerticalEndTickNoneHeight" select="'[Skin.VerticalEndTickNoneHeight]'"/>
    <xsl:param name="prmVerticalStartTickTop" select="'[Skin.VerticalStartTickTop]'"/>
    <xsl:param name="prmVerticalStartTickBottom" select="'[Skin.VerticalStartTickBottom]'"/>
    <xsl:param name="prmVerticalStartTickBoth" select="'[Skin.VerticalStartTickBoth]'"/>
    <xsl:param name="prmVerticalStartTickNone" select="'[Skin.VerticalStartTickNone]'"/>
    <xsl:param name="prmVerticalEndTickTop" select="'[Skin.VerticalEndTickTop]'"/>
    <xsl:param name="prmVerticalEndTickBottom" select="'[Skin.VerticalEndTickBottom]'"/>
    <xsl:param name="prmVerticalEndTickBoth" select="'[Skin.VerticalEndTickBoth]'"/>
    <xsl:param name="prmVerticalEndTickNone" select="'[Skin.VerticalEndTickNone]'"/>
    <xsl:param name="prmVerticalEndTickHeight" select="'[Skin.VerticalEndTickHeight]'"/>


    <xsl:param name="prmSliderLeftHeight" select="'[Skin.SliderLeftHeight]'"/>
    <xsl:param name="prmSliderHorizontalBothHeight" select="'[Skin.SliderHorizontalBothHeight]'"/>
    <xsl:param name="prmSliderRightHeight" select="'[Skin.SliderRightHeight]'"/>
    <xsl:param name="prmSliderLeft" select="'[Skin.SliderLeft]'"/>
    <xsl:param name="prmSliderVerticalBoth" select="'[Skin.SliderVerticalBoth]'"/>
    <xsl:param name="prmSliderRight" select="'[Skin.SliderRight]'"/>

    <xsl:param name="prmHorizontalSpaceTickTop" select="'[Skin.HorizontalSpaceTickTop]'"/>
    <xsl:param name="prmHorizontalSpaceTickBoth" select="'[Skin.HorizontalSpaceTickBoth]'"/>
    <xsl:param name="prmHorizontalSpaceTickBottom" select="'[Skin.HorizontalSpaceTickBottom]'"/>
    <xsl:param name="prmHorizontalMiddleTickTopWidth" select="'[Skin.HorizontalMiddleTickTopWidth]'"/>
    <xsl:param name="prmHorizontalMiddleTickBottomWidth" select="'[Skin.HorizontalMiddleTickBottomWidth]'"/>
    <xsl:param name="prmHorizontalMiddleTickBothWidth" select="'[Skin.HorizontalMiddleTickBothWidth]'"/>
    <xsl:param name="prmHorizontalMiddleTickTop" select="'[Skin.HorizontalMiddleTickTop]'"/>
    <xsl:param name="prmHorizontalMiddleTickBottom" select="'[Skin.HorizontalMiddleTickBottom]'"/>
    <xsl:param name="prmHorizontalMiddleTickBoth" select="'[Skin.HorizontalMiddleTickBoth]'"/>

    <xsl:param name="prmVerticalSpaceTickLeft" select="'[Skin.VerticalSpaceTickLeft]'"/>
    <xsl:param name="prmVerticalSpaceTickBoth" select="'[Skin.VerticalSpaceTickBoth]'"/>
    <xsl:param name="prmVerticalSpaceTickRight" select="'[Skin.VerticalSpaceTickRight]'"/>
    <xsl:param name="prmVerticalMiddleTickLeftHeight" select="'[Skin.VerticalMiddleTickLeftHeight]'"/>
    <xsl:param name="prmVerticalMiddleTickRightHeight" select="'[Skin.VerticalMiddleTickRightHeight]'"/>
    <xsl:param name="prmVerticalMiddleTickBothHeight" select="'[Skin.VerticalMiddleTickBothHeight]'"/>
    <xsl:param name="prmVerticalMiddleTickLeft" select="'[Skin.VerticalMiddleTickLeft]'"/>
    <xsl:param name="prmVerticalMiddleTickRight" select="'[Skin.VerticalMiddleTickRight]'"/>
    <xsl:param name="prmVerticalMiddleTickBoth" select="'[Skin.VerticalMiddleTickBoth]'"/>

    <xsl:call-template name="tplDrawTrackBarAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />

      <xsl:with-param name="prmHorizontalEndTickTopWidth" select="$prmHorizontalEndTickTopWidth" />
      <xsl:with-param name="prmHorizontalStartTickTopWidth" select="$prmHorizontalStartTickTopWidth" />
      <xsl:with-param name="prmHorizontalEndTickBottomWidth" select="$prmHorizontalEndTickBottomWidth" />
      <xsl:with-param name="prmHorizontalStartTickBottomWidth" select="$prmHorizontalStartTickBottomWidth" />
      <xsl:with-param name="prmHorizontalEndTickBothWidth" select="$prmHorizontalEndTickBothWidth" />
      <xsl:with-param name="prmHorizontalStartTickBothWidth" select="$prmHorizontalStartTickBothWidth" />
      <xsl:with-param name="prmHorizontalEndTickNoneWidth" select="$prmHorizontalEndTickNoneWidth" />
      <xsl:with-param name="prmHorizontalStartTickNoneWidth" select="$prmHorizontalStartTickNoneWidth" />
      <xsl:with-param name="prmHorizontalStartTickTop" select="$prmHorizontalStartTickTop" />
      <xsl:with-param name="prmHorizontalStartTickBottom" select="$prmHorizontalStartTickBottom" />
      <xsl:with-param name="prmHorizontalStartTickBoth" select="$prmHorizontalStartTickBoth" />
      <xsl:with-param name="prmHorizontalStartTickNone" select="$prmHorizontalStartTickNone" />
      <xsl:with-param name="prmHorizontalEndTickTop" select="$prmHorizontalEndTickTop" />
      <xsl:with-param name="prmHorizontalEndTickBottom" select="$prmHorizontalEndTickBottom" />
      <xsl:with-param name="prmHorizontalEndTickBoth" select="$prmHorizontalEndTickBoth" />
      <xsl:with-param name="prmHorizontalEndTickNone" select="$prmHorizontalEndTickNone" />

      <xsl:with-param name="prmSliderTopWidth" select="$prmSliderTopWidth" />
      <xsl:with-param name="prmSliderHorizontalBothWidth" select="$prmSliderHorizontalBothWidth" />
      <xsl:with-param name="prmSliderBottomWidth" select="$prmSliderBottomWidth" />
      <xsl:with-param name="prmSliderTop" select="$prmSliderTop" />
      <xsl:with-param name="prmSliderHorizontalBoth" select="$prmSliderHorizontalBoth" />
      <xsl:with-param name="prmSliderBottom" select="$prmSliderBottom" />

      <xsl:with-param name="prmVerticalStartTickTopHeight" select="$prmVerticalStartTickTopHeight" />
      <xsl:with-param name="prmVerticalEndTickTopHeight" select="$prmVerticalEndTickTopHeight" />
      <xsl:with-param name="prmVerticalStartTickBottomHeight" select="$prmVerticalStartTickBottomHeight" />
      <xsl:with-param name="prmVerticalEndTickBottomHeight" select="$prmVerticalEndTickBottomHeight" />
      <xsl:with-param name="prmVerticalStartTickBothHeight" select="$prmVerticalStartTickBothHeight" />
      <xsl:with-param name="prmVerticalEndTickBothHeight" select="$prmVerticalEndTickBothHeight" />
      <xsl:with-param name="prmVerticalStartTickNoneHeight" select="$prmVerticalStartTickNoneHeight" />
      <xsl:with-param name="prmVerticalEndTickNoneHeight" select="$prmVerticalEndTickNoneHeight" />
      <xsl:with-param name="prmVerticalStartTickTop" select="$prmVerticalStartTickTop" />
      <xsl:with-param name="prmVerticalStartTickBottom" select="$prmVerticalStartTickBottom" />
      <xsl:with-param name="prmVerticalStartTickBoth" select="$prmVerticalStartTickBoth" />
      <xsl:with-param name="prmVerticalStartTickNone" select="$prmVerticalStartTickNone" />
      <xsl:with-param name="prmVerticalEndTickTop" select="$prmVerticalEndTickTop" />
      <xsl:with-param name="prmVerticalEndTickBottom" select="$prmVerticalEndTickBottom" />
      <xsl:with-param name="prmVerticalEndTickBoth" select="$prmVerticalEndTickBoth" />
      <xsl:with-param name="prmVerticalEndTickNone" select="$prmVerticalEndTickNone" />
      <xsl:with-param name="prmVerticalEndTickHeight" select="$prmVerticalEndTickHeight" />

      <xsl:with-param name="prmSliderLeftHeight" select="$prmSliderLeftHeight" />
      <xsl:with-param name="prmSliderHorizontalBothHeight" select="$prmSliderHorizontalBothHeight" />
      <xsl:with-param name="prmSliderRightHeight" select="$prmSliderRightHeight" />
      <xsl:with-param name="prmSliderLeft" select="$prmSliderLeft" />
      <xsl:with-param name="prmSliderVerticalBoth" select="$prmSliderVerticalBoth" />
      <xsl:with-param name="prmSliderRight" select="$prmSliderRight" />

      <xsl:with-param name="prmHorizontalSpaceTickTop" select="$prmHorizontalSpaceTickTop" />
      <xsl:with-param name="prmHorizontalSpaceTickBoth" select="$prmHorizontalSpaceTickBoth" />
      <xsl:with-param name="prmHorizontalSpaceTickBottom" select="$prmHorizontalSpaceTickBottom" />
      <xsl:with-param name="prmHorizontalMiddleTickTopWidth" select="$prmHorizontalMiddleTickTopWidth" />
      <xsl:with-param name="prmHorizontalMiddleTickBottomWidth" select="$prmHorizontalMiddleTickBottomWidth" />
      <xsl:with-param name="prmHorizontalMiddleTickBothWidth" select="$prmHorizontalMiddleTickBothWidth" />
      <xsl:with-param name="prmHorizontalMiddleTickTop" select="$prmHorizontalMiddleTickTop" />
      <xsl:with-param name="prmHorizontalMiddleTickBottom" select="$prmHorizontalMiddleTickBottom" />
      <xsl:with-param name="prmHorizontalMiddleTickBoth" select="$prmHorizontalMiddleTickBoth" />

      <xsl:with-param name="prmVerticalSpaceTickLeft" select="$prmVerticalSpaceTickLeft" />
      <xsl:with-param name="prmVerticalSpaceTickBoth" select="$prmVerticalSpaceTickBoth" />
      <xsl:with-param name="prmVerticalSpaceTickRight" select="$prmVerticalSpaceTickRight" />
      <xsl:with-param name="prmVerticalMiddleTickLeftHeight" select="$prmVerticalMiddleTickLeftHeight" />
      <xsl:with-param name="prmVerticalMiddleTickRightHeight" select="$prmVerticalMiddleTickRightHeight" />
      <xsl:with-param name="prmVerticalMiddleTickBothHeight" select="$prmVerticalMiddleTickBothHeight" />
      <xsl:with-param name="prmVerticalMiddleTickLeft" select="$prmVerticalMiddleTickLeft" />
      <xsl:with-param name="prmVerticalMiddleTickRight" select="$prmVerticalMiddleTickRight" />
      <xsl:with-param name="prmVerticalMiddleTickBoth" select="$prmVerticalMiddleTickBoth" />
    </xsl:call-template>
  </xsl:template>


  <xsl:template name="tplDrawTrackBarAPI">
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmHorizontalEndTickTopWidth" />
    <xsl:param name="prmHorizontalStartTickTopWidth" />
    <xsl:param name="prmHorizontalEndTickBottomWidth" />
    <xsl:param name="prmHorizontalStartTickBottomWidth" />
    <xsl:param name="prmHorizontalEndTickBothWidth" />
    <xsl:param name="prmHorizontalStartTickBothWidth" />
    <xsl:param name="prmHorizontalEndTickNoneWidth" />
    <xsl:param name="prmHorizontalStartTickNoneWidth" />
    <xsl:param name="prmHorizontalStartTickTop" />
    <xsl:param name="prmHorizontalStartTickBottom" />
    <xsl:param name="prmHorizontalStartTickBoth" />
    <xsl:param name="prmHorizontalStartTickNone" />
    <xsl:param name="prmHorizontalEndTickTop" />
    <xsl:param name="prmHorizontalEndTickBottom" />
    <xsl:param name="prmHorizontalEndTickBoth" />
    <xsl:param name="prmHorizontalEndTickNone" />

    <xsl:param name="prmSliderTopWidth" />
    <xsl:param name="prmSliderHorizontalBothWidth" />
    <xsl:param name="prmSliderBottomWidth" />
    <xsl:param name="prmSliderTop" />
    <xsl:param name="prmSliderHorizontalBoth" />
    <xsl:param name="prmSliderBottom" />

    <xsl:param name="prmVerticalStartTickTopHeight" />
    <xsl:param name="prmVerticalEndTickTopHeight" />
    <xsl:param name="prmVerticalStartTickBottomHeight" />
    <xsl:param name="prmVerticalEndTickBottomHeight" />
    <xsl:param name="prmVerticalStartTickBothHeight" />
    <xsl:param name="prmVerticalEndTickBothHeight" />
    <xsl:param name="prmVerticalStartTickNoneHeight" />
    <xsl:param name="prmVerticalEndTickNoneHeight" />
    <xsl:param name="prmVerticalStartTickTop" />
    <xsl:param name="prmVerticalStartTickBottom" />
    <xsl:param name="prmVerticalStartTickBoth" />
    <xsl:param name="prmVerticalStartTickNone" />
    <xsl:param name="prmVerticalEndTickTop" />
    <xsl:param name="prmVerticalEndTickBottom" />
    <xsl:param name="prmVerticalEndTickBoth" />
    <xsl:param name="prmVerticalEndTickNone" />
    <xsl:param name="prmVerticalEndTickHeight" />

    <xsl:param name="prmSliderLeftHeight" />
    <xsl:param name="prmSliderHorizontalBothHeight" />
    <xsl:param name="prmSliderRightHeight" />
    <xsl:param name="prmSliderLeft" />
    <xsl:param name="prmSliderVerticalBoth" />
    <xsl:param name="prmSliderRight" />

    <xsl:param name="prmHorizontalSpaceTickTop" />
    <xsl:param name="prmHorizontalSpaceTickBoth" />
    <xsl:param name="prmHorizontalSpaceTickBottom" />
    <xsl:param name="prmHorizontalMiddleTickTopWidth" />
    <xsl:param name="prmHorizontalMiddleTickBottomWidth" />
    <xsl:param name="prmHorizontalMiddleTickBothWidth" />
    <xsl:param name="prmHorizontalMiddleTickTop" />
    <xsl:param name="prmHorizontalMiddleTickBottom" />
    <xsl:param name="prmHorizontalMiddleTickBoth" />

    <xsl:param name="prmVerticalSpaceTickLeft" />
    <xsl:param name="prmVerticalSpaceTickBoth" />
    <xsl:param name="prmVerticalSpaceTickRight" />
    <xsl:param name="prmVerticalMiddleTickLeftHeight" />
    <xsl:param name="prmVerticalMiddleTickRightHeight" />
    <xsl:param name="prmVerticalMiddleTickBothHeight" />
    <xsl:param name="prmVerticalMiddleTickLeft" />
    <xsl:param name="prmVerticalMiddleTickRight" />
    <xsl:param name="prmVerticalMiddleTickBoth" />

    <xsl:variable name="varTickCount" select="@Attr.Length"/>
    <xsl:attribute name="class">TrackBar-Control</xsl:attribute>

    <!-- TrackBar left most position -->
    <xsl:variable name="varLeftImgWidth">
      <xsl:choose>
        <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmHorizontalStartTickTopWidth"/></xsl:when>
        <!--1: TopLeft-->
        <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmHorizontalStartTickBottomWidth"/></xsl:when>
        <!--2: BottomRight-->
        <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmHorizontalStartTickBothWidth"/></xsl:when>
        <!--3: Both-->
        <xsl:otherwise><xsl:value-of select="$prmHorizontalStartTickNoneWidth"/></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name="varRightImgWidth">
      <xsl:choose>
        <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmHorizontalEndTickTopWidth"/></xsl:when>
        <!--1: TopLeft-->
        <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmHorizontalEndTickBottomWidth"/></xsl:when>
        <!--2: BottomRight-->
        <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmHorizontalEndTickBothWidth"/></xsl:when>
        <!--3: Both-->
        <xsl:otherwise><xsl:value-of select="$prmHorizontalEndTickNoneWidth"/></xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <!-- Horizontal TrackBar -->
    <xsl:if test="@Attr.Orientation='0'">
      <div>
        <xsl:attribute name="style">
          position:absolute;top:0px;left:0px;width:100%;height:100%;padding:0px <xsl:value-of select="$varRightImgWidth"/>px 0px <xsl:value-of select="$varLeftImgWidth"/>px;
        </xsl:attribute>
        <img alt="">
          <xsl:attribute name="style">
            position:absolute;left:0px;top:0px;width:<xsl:value-of select="$varLeftImgWidth"/>px;
          </xsl:attribute>
          <xsl:attribute name="src">
            <xsl:choose>
              <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmHorizontalStartTickTop"/></xsl:when>
              <!--1: TopLeft-->
              <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmHorizontalStartTickBottom"/></xsl:when>
              <!--2: BottomRight-->
              <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmHorizontalStartTickBoth"/></xsl:when>
              <!--3: Both-->
              <xsl:otherwise><xsl:value-of select="$prmHorizontalStartTickNone"/></xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
        </img>

        <!--Trackbar scale table-->
        <table style="table-layout:fixed;width:100%;height:100%" class="Common-CellSpacing0 Common-CellPadding0">
          <tr>
            <xsl:if test="$varTickCount">
              <xsl:call-template name="tplTrackBarHorz">
                <xsl:with-param name="prmTotal" select="$varTickCount"/>

                <xsl:with-param name="prmHorizontalSpaceTickTop" select="$prmHorizontalSpaceTickTop" />
                <xsl:with-param name="prmHorizontalSpaceTickBoth" select="$prmHorizontalSpaceTickBoth" />
                <xsl:with-param name="prmHorizontalSpaceTickBottom" select="$prmHorizontalSpaceTickBottom" />
                <xsl:with-param name="prmHorizontalMiddleTickTopWidth" select="$prmHorizontalMiddleTickTopWidth" />
                <xsl:with-param name="prmHorizontalMiddleTickBottomWidth" select="$prmHorizontalMiddleTickBottomWidth" />
                <xsl:with-param name="prmHorizontalMiddleTickBothWidth" select="$prmHorizontalMiddleTickBothWidth" />
                <xsl:with-param name="prmHorizontalMiddleTickTop" select="$prmHorizontalMiddleTickTop" />
                <xsl:with-param name="prmHorizontalMiddleTickBottom" select="$prmHorizontalMiddleTickBottom" />
                <xsl:with-param name="prmHorizontalMiddleTickBoth" select="$prmHorizontalMiddleTickBoth" />
              </xsl:call-template>
            </xsl:if>
          </tr>
        </table>

        <!-- TrackBar right most position -->
        <img alt="">
          <xsl:attribute name="style">
            position:absolute;right:0px;top:0px;width:<xsl:value-of select="$varRightImgWidth"/>px;
          </xsl:attribute>
          <xsl:attribute name="src">
            <xsl:choose>
              <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmHorizontalEndTickTop"/></xsl:when>
              <!--1: TopLeft-->
              <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmHorizontalEndTickBottom"/></xsl:when>
              <!--2: BottomRight-->
              <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmHorizontalEndTickBoth"/></xsl:when>
              <!--3: Both-->
              <xsl:otherwise><xsl:value-of select="$prmHorizontalEndTickNone"/></xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
        </img>
      </div>

      <xsl:variable name="varSliderWidth">
         <xsl:choose>
            <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmSliderTopWidth"/></xsl:when>
            <!--1: TopLeft-->
            <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmSliderHorizontalBothWidth"/></xsl:when>
            <!--3: Both-->
            <xsl:otherwise><xsl:value-of select="$prmSliderBottomWidth"/></xsl:otherwise>
          </xsl:choose>
      </xsl:variable>
        
      <div>
        <xsl:attribute name="style">
          position:absolute;top:0px;left:0px;width:100%;height:100%;overflow:hidden;padding-right:<xsl:value-of select="$varSliderWidth"/>px;
        </xsl:attribute>
        <div id="knobContainer_{@Id}" style="position:relative;width:100%;height:100%;">
          <div id="tail_{@Id}" style="width:{@Attr.Value}%;height:100%;position:absolute;left:0px;top:0px;">
            <div>
              <xsl:attribute name="class">
                <xsl:choose>
                  <xsl:when test="@Attr.Style='1'"><xsl:value-of select="'TrackBar-TailHorizontalTop'"/></xsl:when>
                  <!--1: TopLeft-->
                  <xsl:when test="@Attr.Style='2'"><xsl:value-of select="'TrackBar-TailHorizontalBottom'"/></xsl:when>
                  <!--2: BottomRight-->
                  <xsl:when test="@Attr.Style='3'"><xsl:value-of select="'TrackBar-TailHorizontalBoth'"/></xsl:when>
                  <!--3: Both-->
                  <xsl:otherwise><xsl:value-of select="'TrackBar-TailHorizontalNone'"/></xsl:otherwise>
                </xsl:choose>
              </xsl:attribute>
              <xsl:attribute name="style">position:absolute;height:100%;left:<xsl:value-of select="$varLeftImgWidth"/>px;right:-<xsl:value-of select="number($varSliderWidth) div 2"/>px;</xsl:attribute>
            </div>
            <!-- TrackBar slider knob -->
            <img class="Common-Unselectable Common-Undraggable" style="position:absolute;top:0px;right:-{$varSliderWidth}px;" data-vwgdrag="mh" alt="">
              <xsl:attribute name="src">
                <xsl:choose>
                  <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmSliderTop"/></xsl:when>
                  <!--1: TopLeft-->
                  <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmSliderHorizontalBoth"/></xsl:when>
                  <!--3: Both-->
                  <xsl:otherwise><xsl:value-of select="$prmSliderBottom"/></xsl:otherwise>
                </xsl:choose>
              </xsl:attribute>
              <xsl:attribute name="onmousedown">
                <xsl:if test="not($prmIsEnabled='0') and not(@Attr.Frozen='1')">
                  mobjApp.TrackBar_DragStart('<xsl:value-of select="@Id" />',this,window,event);
                </xsl:if>mobjApp.Web_EventCancelBubble(event,true,false);
              </xsl:attribute>
            </img>
          </div>
        </div>
      </div>
    </xsl:if>

    <!-- Vertical TrackBar -->
    <xsl:if test="@Attr.Orientation='1'">
      <!-- TrackBar top most position -->
      <xsl:variable name="varHeightVerticalStart">
        <xsl:choose>
          <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmVerticalStartTickTopHeight"/></xsl:when>
          <!--1: TopLeft-->
          <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmVerticalStartTickBottomHeight"/></xsl:when>
          <!--2: BottomRight-->
          <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmVerticalStartTickBothHeight"/></xsl:when>
          <!--3: Both-->
          <xsl:otherwise><xsl:value-of select="$prmVerticalStartTickNoneHeight"/></xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <!-- TrackBar bottom most position -->
      <xsl:variable name="varHeightVerticalEnd">
        <xsl:choose>
          <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmVerticalEndTickTopHeight"/></xsl:when>
          <!--1: TopLeft-->
          <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmVerticalEndTickBottomHeight"/></xsl:when>
          <!--2: BottomRight-->
          <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmVerticalEndTickBothHeight"/></xsl:when>
          <!--3: Both-->
          <xsl:otherwise><xsl:value-of select="$prmVerticalEndTickNoneHeight"/></xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <div>
        <xsl:attribute name="style">
          position:absolute;top:0px;left:0px;width:100%;height:100%;padding:<xsl:value-of select="$varHeightVerticalStart"/>px 0px <xsl:value-of select="$varHeightVerticalEnd"/>px 0px;
        </xsl:attribute>
        <img alt="">
          <xsl:attribute name="style">
            position:absolute;left:0px;top:0px;height:<xsl:value-of select="$varHeightVerticalStart"/>px;
          </xsl:attribute>
          <xsl:attribute name="src">
            <xsl:choose>
              <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmVerticalStartTickTop"/></xsl:when>
              <!--1: TopLeft-->
              <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmVerticalStartTickBottom"/></xsl:when>
              <!--2: BottomRight-->
              <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmVerticalStartTickBoth"/></xsl:when>
              <!--3: Both-->
              <xsl:otherwise><xsl:value-of select="$prmVerticalStartTickNone"/></xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
        </img>

        <!--Trackbar scale table-->
        <table style="table-layout:fixed;width:100%;height:100%;" class="Common-CellSpacing0 Common-CellPadding0" >
          <xsl:if test="$varTickCount">
            <xsl:call-template name="tplTrackBarVert">
              <xsl:with-param name="prmTotal" select="$varTickCount"/>

              <xsl:with-param name="prmVerticalSpaceTickLeft" select="$prmVerticalSpaceTickLeft" />
              <xsl:with-param name="prmVerticalSpaceTickBoth" select="$prmVerticalSpaceTickBoth" />
              <xsl:with-param name="prmVerticalSpaceTickRight" select="$prmVerticalSpaceTickRight" />
              <xsl:with-param name="prmVerticalMiddleTickLeftHeight" select="$prmVerticalMiddleTickLeftHeight" />
              <xsl:with-param name="prmVerticalMiddleTickRightHeight" select="$prmVerticalMiddleTickRightHeight" />
              <xsl:with-param name="prmVerticalMiddleTickBothHeight" select="$prmVerticalMiddleTickBothHeight" />
              <xsl:with-param name="prmVerticalMiddleTickLeft" select="$prmVerticalMiddleTickLeft" />
              <xsl:with-param name="prmVerticalMiddleTickRight" select="$prmVerticalMiddleTickRight" />
              <xsl:with-param name="prmVerticalMiddleTickBoth" select="$prmVerticalMiddleTickBoth" />
            </xsl:call-template>
          </xsl:if>
        </table>

        <img alt="">
          <xsl:attribute name="style">
            position:absolute;left:0px;bottom:0px;height:<xsl:value-of select="$varHeightVerticalEnd"/>px
          </xsl:attribute>
          <xsl:attribute name="src">
            <xsl:choose>
              <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmVerticalEndTickTop"/></xsl:when>
              <!--1: TopLeft-->
              <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmVerticalEndTickBottom"/></xsl:when>
              <!--2: BottomRight-->
              <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmVerticalEndTickBoth"/></xsl:when>
              <!--3: Both-->
              <xsl:otherwise><xsl:value-of select="$prmVerticalEndTickNone"/></xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
        </img>
      </div>

      <xsl:variable name="varSliderHeight">
        <xsl:choose>
          <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmSliderLeftHeight"/></xsl:when>
          <!--1: TopLeft-->
          <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmSliderHorizontalBothHeight"/></xsl:when>
          <!--3: Both-->
          <xsl:otherwise><xsl:value-of select="$prmSliderRightHeight"/></xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <div>
        <xsl:attribute name="style">
          position:absolute;top:0px;left:0px;width:100%;height:100%;overflow:hidden;padding-bottom:<xsl:value-of select="$varSliderHeight" />px;
        </xsl:attribute>

        <xsl:variable name="varStartPosition">
          <xsl:value-of select="100 - round((100 - number(@Attr.Value)) * 100) div 100"/>
        </xsl:variable>
        <div id="knobContainer_{@Id}" style="position:relative;width:100%;height:100%;">
          <div id="tail_{@Id}" style="position:absolute;bottom:-{$varSliderHeight}px;left:0px;width:100%;height:{$varStartPosition}%;">
            <div >
              <xsl:attribute name="style">position:absolute;width:100%;bottom:<xsl:value-of select="$varHeightVerticalEnd"/>px;top:-<xsl:value-of select="number($varSliderHeight) div 2"/>px;</xsl:attribute>
              <xsl:attribute name="class">
                <xsl:choose>
                  <xsl:when test="@Attr.Style='1'"><xsl:value-of select="'TrackBar-TailVerticalTop'"/></xsl:when>
                  <!--1: TopLeft-->
                  <xsl:when test="@Attr.Style='2'"><xsl:value-of select="'TrackBar-TailVerticalBottom'"/></xsl:when>
                  <!--2: BottomRight-->
                  <xsl:when test="@Attr.Style='3'"><xsl:value-of select="'TrackBar-TailVerticalBoth'"/></xsl:when>
                  <!--3: Both-->
                  <xsl:otherwise><xsl:value-of select="'TrackBar-TailVerticalNone'"/></xsl:otherwise>
                </xsl:choose>
              </xsl:attribute>
            </div>
            <!-- TrackBar slider knob -->
            <img class="Common-Unselectable Common-Undraggable" data-vwgdrag="mv" alt="">
              <xsl:attribute name="style">
                position:absolute;left:0px;top:-<xsl:value-of select="$varSliderHeight"/>px;
              </xsl:attribute>
              <xsl:attribute name="src">
                <xsl:choose>
                  <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmSliderLeft"/></xsl:when>
                  <!--1: TopLeft-->
                  <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmSliderVerticalBoth"/></xsl:when>
                  <!--3: Both-->
                  <xsl:otherwise><xsl:value-of select="$prmSliderRight"/></xsl:otherwise>
                </xsl:choose>
              </xsl:attribute>
              <xsl:attribute name="onmousedown">
                <xsl:if test="not($prmIsEnabled='0') and not(@Attr.Frozen='1')">
                  mobjApp.TrackBar_DragStart('<xsl:value-of select="@Id" />',this,window,event);
                </xsl:if>mobjApp.Web_EventCancelBubble(event,true,false);
              </xsl:attribute>
            </img>
          </div>
        </div>
      </div>
    </xsl:if>

  </xsl:template>

  <xsl:template name="tplTrackBarHorz">
    <xsl:param name="prmIndex" select="1"/>
    <xsl:param name="prmHorizontalSpaceTickTop" />
    <xsl:param name="prmHorizontalSpaceTickBoth" />
    <xsl:param name="prmHorizontalSpaceTickBottom" />
    <xsl:param name="prmHorizontalMiddleTickTopWidth" />
    <xsl:param name="prmHorizontalMiddleTickBottomWidth" />
    <xsl:param name="prmHorizontalMiddleTickBothWidth" />
    <xsl:param name="prmHorizontalMiddleTickTop" />
    <xsl:param name="prmHorizontalMiddleTickBottom" />
    <xsl:param name="prmHorizontalMiddleTickBoth" />

    <xsl:param name="prmTotal" />
    <td class="Common-AlignRight Common-VAlignTop">
      <xsl:attribute name="style">
        width:<xsl:value-of select="@Attr.TickSize"/>%;
        <xsl:choose>
          <xsl:when test="@Attr.Style='1'">background-image:url(<xsl:value-of select="$prmHorizontalSpaceTickTop"/>); background-repeat: repeat-x;</xsl:when><!--1: TopLeft-->
          <xsl:when test="@Attr.Style='3'">background-image:url(<xsl:value-of select="$prmHorizontalSpaceTickBoth"/>); background-repeat: repeat-x;</xsl:when><!--3: Both-->
          <xsl:otherwise>background-image:url(<xsl:value-of select="$prmHorizontalSpaceTickBottom"/>); background-repeat: repeat-x;</xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      
			<xsl:if test="@Attr.Style!='0' and (($dir='LTR' and $prmIndex &lt; $prmTotal) or ($dir='RTL' and $prmIndex &gt; 1))">
          <xsl:variable name="varWidthHorz">
            <xsl:choose>
              <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmHorizontalMiddleTickTopWidth"/>px</xsl:when><!--1: TopLeft-->
              <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmHorizontalMiddleTickBottomWidth"/>px</xsl:when><!--2: BottomRight-->
              <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmHorizontalMiddleTickBothWidth"/>px</xsl:when><!--3: Both-->
            </xsl:choose>
          </xsl:variable>
          <img alt="">
            <xsl:attribute name="style">
              width:<xsl:value-of select="$varWidthHorz"/>;
            </xsl:attribute>
            <xsl:attribute name="src">
              <xsl:choose>
                <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmHorizontalMiddleTickTop"/></xsl:when><!--1: TopLeft-->
                <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmHorizontalMiddleTickBottom"/></xsl:when><!--2: BottomRight-->
                <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmHorizontalMiddleTickBoth"/></xsl:when><!--3: Both-->
              </xsl:choose>
            </xsl:attribute>
          </img>
			</xsl:if>
		</td>
		
		<xsl:if test="$prmIndex &lt; $prmTotal">
			<xsl:call-template name="tplTrackBarHorz">
				<xsl:with-param name="prmIndex" select="$prmIndex + 1"/>
				<xsl:with-param name="prmTotal" select="$prmTotal"/>

        <xsl:with-param name="prmHorizontalSpaceTickTop" select="$prmHorizontalSpaceTickTop" />
        <xsl:with-param name="prmHorizontalSpaceTickBoth" select="$prmHorizontalSpaceTickBoth" />
        <xsl:with-param name="prmHorizontalSpaceTickBottom" select="$prmHorizontalSpaceTickBottom" />
        <xsl:with-param name="prmHorizontalMiddleTickTopWidth" select="$prmHorizontalMiddleTickTopWidth" />
        <xsl:with-param name="prmHorizontalMiddleTickBottomWidth" select="$prmHorizontalMiddleTickBottomWidth" />
        <xsl:with-param name="prmHorizontalMiddleTickBothWidth" select="$prmHorizontalMiddleTickBothWidth" />
        <xsl:with-param name="prmHorizontalMiddleTickTop" select="$prmHorizontalMiddleTickTop" />
        <xsl:with-param name="prmHorizontalMiddleTickBottom" select="$prmHorizontalMiddleTickBottom" />
        <xsl:with-param name="prmHorizontalMiddleTickBoth" select="$prmHorizontalMiddleTickBoth" />
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	
	<xsl:template name="tplTrackBarVert">
    <xsl:param name="prmIndex" select="1"/>
    <xsl:param name="prmVerticalSpaceTickLeft" />
    <xsl:param name="prmVerticalSpaceTickBoth" />
    <xsl:param name="prmVerticalSpaceTickRight" />
    <xsl:param name="prmVerticalMiddleTickLeftHeight" />
    <xsl:param name="prmVerticalMiddleTickRightHeight" />
    <xsl:param name="prmVerticalMiddleTickBothHeight" />
    <xsl:param name="prmVerticalMiddleTickLeft" />
    <xsl:param name="prmVerticalMiddleTickRight" />
    <xsl:param name="prmVerticalMiddleTickBoth" />

    <xsl:param name="prmTotal" />
    <tr>
			<td class="Common-AlignLeft Common-VAlignBottom">
        <xsl:attribute name="style">        
        <xsl:choose>
          <xsl:when test="@Attr.Style='1'">background-image:url(<xsl:value-of select="$prmVerticalSpaceTickLeft"/>); background-repeat: repeat-y; height:<xsl:value-of select="@Attr.TickSize" />%;</xsl:when><!--1: TopLeft-->
          <xsl:when test="@Attr.Style='3'">background-image:url(<xsl:value-of select="$prmVerticalSpaceTickBoth"/>); background-repeat: repeat-y; height:<xsl:value-of select="@Attr.TickSize" />%;</xsl:when><!--3: Both-->
          <xsl:otherwise>background-image:url(<xsl:value-of select="$prmVerticalSpaceTickRight"/>); background-repeat: repeat-y; height:<xsl:value-of select="@Attr.TickSize" />%;</xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
        <xsl:if test="@Attr.Style!='0' and $prmIndex &lt; $prmTotal">
          <img alt="">
            <xsl:variable name="varHeightVerticalMiddle">
              <xsl:choose>
                <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmVerticalMiddleTickLeftHeight"/>px</xsl:when><!--1: TopLeft-->
                <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmVerticalMiddleTickRightHeight"/>px</xsl:when><!--2: BottomRight-->
                <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmVerticalMiddleTickBothHeight"/>px</xsl:when><!--3: Both-->
              </xsl:choose>
            </xsl:variable>
            <xsl:attribute name="style">
              display:block;height:<xsl:value-of select="$varHeightVerticalMiddle"/>;
            </xsl:attribute>
            <xsl:attribute name="src">
              <xsl:choose>
                <xsl:when test="@Attr.Style='1'"><xsl:value-of select="$prmVerticalMiddleTickLeft"/></xsl:when><!--1: TopLeft-->
                <xsl:when test="@Attr.Style='2'"><xsl:value-of select="$prmVerticalMiddleTickRight"/></xsl:when><!--2: BottomRight-->
                <xsl:when test="@Attr.Style='3'"><xsl:value-of select="$prmVerticalMiddleTickBoth"/></xsl:when><!--3: Both-->
              </xsl:choose>
            </xsl:attribute>
          </img>
        </xsl:if>
			</td>
		</tr>
		<xsl:if test="$prmIndex &lt; $prmTotal">
			<xsl:call-template name="tplTrackBarVert">
				<xsl:with-param name="prmIndex" select="$prmIndex + 1"/>
        <xsl:with-param name="prmTotal" select="$prmTotal"/>

        <xsl:with-param name="prmVerticalSpaceTickLeft" select="$prmVerticalSpaceTickLeft" />
        <xsl:with-param name="prmVerticalSpaceTickBoth" select="$prmVerticalSpaceTickBoth" />
        <xsl:with-param name="prmVerticalSpaceTickRight" select="$prmVerticalSpaceTickRight" />
        <xsl:with-param name="prmVerticalMiddleTickLeftHeight" select="$prmVerticalMiddleTickLeftHeight" />
        <xsl:with-param name="prmVerticalMiddleTickRightHeight" select="$prmVerticalMiddleTickRightHeight" />
        <xsl:with-param name="prmVerticalMiddleTickBothHeight" select="$prmVerticalMiddleTickBothHeight" />
        <xsl:with-param name="prmVerticalMiddleTickLeft" select="$prmVerticalMiddleTickLeft" />
        <xsl:with-param name="prmVerticalMiddleTickRight" select="$prmVerticalMiddleTickRight" />
        <xsl:with-param name="prmVerticalMiddleTickBoth" select="$prmVerticalMiddleTickBoth" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
