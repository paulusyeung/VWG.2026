<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The default style GroupBox match template -->
  <xsl:template match="WC:Tags.GroupBox[not(@Attr.CustomStyle)]" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawGroupBoxAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- Main API for drawing the control -->
  <xsl:template name="tplDrawGroupBoxAPI" >
    <xsl:param name="prmControlClass" select="'GroupBox-Control'"/>
    <xsl:param name="prmLeftBottomClass" select="'GroupBox-LeftBottom'"/>
    <xsl:param name="prmLeftClass" select="'GroupBox-Left'"/>
    <xsl:param name="prmLeftTopClass" select="'GroupBox-LeftTop'"/>
    <xsl:param name="prmRightTopClass" select="'GroupBox-RightTop'"/>
    <xsl:param name="prmRightClass" select="'GroupBox-Right'"/>
    <xsl:param name="prmRightBottomClass" select="'GroupBox-RightBottom'"/>
    <xsl:param name="prmBottomClass" select="'GroupBox-Bottom'"/>
    <xsl:param name="prmTopClass"/>
    <xsl:param name="prmTopPosition"/>

    <xsl:param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
    <xsl:param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
    <xsl:param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
    <xsl:param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>

    <xsl:param name="prmCenterClass" select="'GroupBox-Center'"/>
    <xsl:param name="prmIsEnabled" />

    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="$prmIsEnabled='0'">
        <xsl:value-of select="concat(' ',$prmControlClass,'_Disabled')"/>
      </xsl:if>
    </xsl:attribute>

    <div style="position:relative;width:100%;height:100%" data-vwgtype="container" onresize="mobjApp.Layout_ContainerResized(this);">
      <xsl:call-template name="tplDrawFrame">
        <xsl:with-param name="prmLeftBottomClass" select="$prmLeftBottomClass"/>
        <xsl:with-param name="prmLeftClass" select="$prmLeftClass"/>
        <xsl:with-param name="prmLeftTopClass" select="$prmLeftTopClass"/>
        <xsl:with-param name="prmRightTopClass" select="$prmRightTopClass"/>
        <xsl:with-param name="prmRightClass" select="$prmRightClass"/>
        <xsl:with-param name="prmRightBottomClass" select="$prmRightBottomClass"/>
        <xsl:with-param name="prmBottomClass" select="$prmBottomClass"/>
        <xsl:with-param name="prmCenterClass" select="$prmCenterClass"/>
        <xsl:with-param name="prmTopClass" select="$prmTopClass" />
        <xsl:with-param name="prmCenterContent" select="." />
        <xsl:with-param name="prmHeaderContent" select="." />

        <xsl:with-param name="prmLeftFrameWidth" select="$prmLeftFrameWidth" />
        <xsl:with-param name="prmRightFrameWidth" select="$prmRightFrameWidth" />
        <xsl:with-param name="prmTopFrameHeight"  select="$prmTopFrameHeight" />
        <xsl:with-param name="prmBottomFrameHeight"  select="$prmBottomFrameHeight" />

        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      </xsl:call-template>
      <xsl:apply-templates select="./*[(@A and not(@A=''))]" mode="modLayoutItem" >
        <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
      </xsl:apply-templates>
    </div>
  </xsl:template>

  <!-- The default style GroupBox header match template -->
  <xsl:template match="WC:Tags.GroupBox[not(@Attr.CustomStyle)]" mode="modFrameHeaderContent">
    <xsl:call-template name="tplDrawGroupBoxFrameHeaderAPI"/>
  </xsl:template>

  <!-- API for drawing the control header-->
  <xsl:template name="tplDrawGroupBoxFrameHeaderAPI">
    <xsl:param name ="prmLabelLeftClass" select="'GroupBox-LabelLeft'"/>
    <xsl:param name ="prmLabelRightClass" select="'GroupBox-LabelRight'"/>
    <xsl:param name ="prmLabelClass" select="'GroupBox-Label'"/>
    <xsl:param name ="prmTopClass" select="'GroupBox-Top'"/>

    <table style="table-layout:auto;width:100%;height:100%" class="Common-CellPadding0 Common-CellSpacing0" dir="{$dir}">
      <tr>
        <td>
          <xsl:attribute name="class">
            <xsl:if test="$dir='ltr'"><xsl:value-of select="$prmLabelLeftClass"/></xsl:if>
            <xsl:if test="not($dir='ltr')"><xsl:value-of select="$prmLabelRightClass"/></xsl:if>
          </xsl:attribute>
        </td>
        <xsl:if test="@Attr.Text and not (@Attr.Text = '')">
          <td>
            <span class="{$prmLabelClass} nobr">
              <xsl:attribute name="style">
                <xsl:call-template name="tplApplyFontStyles"/>
              </xsl:attribute>
              &#160;<xsl:call-template name="tplDecodeTextAsHtml"/>&#160;
            </span>
          </td>
        </xsl:if>
        <td>
          <xsl:attribute name="class">
            <xsl:if test="$dir='ltr'"><xsl:value-of select="$prmLabelRightClass"/></xsl:if>
            <xsl:if test="not($dir='ltr')"><xsl:value-of select="$prmLabelLeftClass"/></xsl:if>
          </xsl:attribute>
        </td>
        <td class="{$prmTopClass}" style="width:100%;background-repeat: repeat-x;"/>
      </tr>
    </table>
  </xsl:template>


  <!-- The default style GroupBox content match template -->
  <xsl:template match="WC:Tags.GroupBox[not(@Attr.CustomStyle)]" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawGroupBoxFrameCenterAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- API for drawing the control content -->
  <xsl:template name="tplDrawGroupBoxFrameCenterAPI">
    <xsl:param name="prmLayoutType" select="'D'"/>
    <xsl:param name="prmIsEnabled" />
    <xsl:param name="prmBottom" select="0"/>
    <xsl:call-template name="tplDrawContained">
      <xsl:with-param name="prmLayoutType" select="$prmLayoutType"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name="prmBottom" select="$prmBottom" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
