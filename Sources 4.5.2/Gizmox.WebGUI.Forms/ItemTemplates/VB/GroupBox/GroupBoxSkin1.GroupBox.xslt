<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style GroupBox match template -->
  <xsl:template match="WC:Tags.GroupBox[@Attr.CustomStyle='$safeitemname$']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawGroupBoxAPI">
      <xsl:with-param name="prmControlClass" select="'GroupBox-Control'"/>
      <xsl:with-param name="prmLeftBottomClass" select="'GroupBox-LeftBottom'"/>
      <xsl:with-param name="prmLeftClass" select="'GroupBox-Left'"/>
      <xsl:with-param name="prmLeftTopClass" select="'GroupBox-LeftTop'"/>
      <xsl:with-param name="prmRightTopClass" select="'GroupBox-RightTop'"/>
      <xsl:with-param name="prmRightClass" select="'GroupBox-Right'"/>
      <xsl:with-param name="prmRightBottomClass" select="'GroupBox-RightBottom'"/>
      <xsl:with-param name="prmBottomClass" select="'GroupBox-Bottom'"/>
      <xsl:with-param name="prmCenterClass" select="'GroupBox-Center'"/>
      <xsl:with-param name="prmTopClass"/>
      <xsl:with-param name="prmTopPosition"/>

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>

      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

  <!-- The custom style GroupBox header match template -->
  <xsl:template match="WC:Tags.GroupBox[@Attr.CustomStyle='$safeitemname$']" mode="modFrameHeaderContent">
    <xsl:call-template name="tplDrawGroupBoxFrameHeaderAPI">
      <xsl:with-param name ="prmLabelLeftClass" select="'GroupBox-LabelLeft'"/>
      <xsl:with-param name ="prmLabelRightClass" select="'GroupBox-LabelRight'"/>
      <xsl:with-param name ="prmLabelClass" select="'GroupBox-Label'"/>
      <xsl:with-param name ="prmTopClass" select="'GroupBox-Top'"/>
    </xsl:call-template>
  </xsl:template>

  <!-- The custom style GroupBox content match template -->
  <xsl:template match="WC:Tags.GroupBox[@Attr.CustomStyle='$safeitemname$']" mode="modFrameCenterContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawGroupBoxFrameCenterAPI">
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
      <xsl:with-param name ="prmLayoutType" select="'D'"/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
